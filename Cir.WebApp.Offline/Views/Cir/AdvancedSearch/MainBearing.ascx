<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <legend>Main Bearing Data</legend>

    <div class="form-group">
        <label class="col-lg-3 control-label">Turbine Number</label>
        <div class="col-lg-9">
            <input id="CIRWTDTurbineNo6" data-toggle="tooltip" data-placement="top" placeholder="Turbine Number" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Error Location</label>
        <div class="col-lg-9">
            <select id="CIRMainBearingErrorLocation" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="MainBearingErrorLocation" data-valueField="MainBearingErrorLocationID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Grease</label>
        <div class="col-lg-9">
            <input id="CIRMainBearingGrease" type="checkbox">
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Last Lubrication From Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRMainBearingLastLubricationDateFrom_txtDate" data-toggle="tooltip" 
                data-placement="top" readonly="readonly" placeholder="Main Bearing Last Lubrication From Date" class="form-control hasDatepicker" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Last Lubrication To Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRMainBearingLastLubricationDateTo_txtDate" placeholder="Main Bearing Last Lubrication To Date" data-toggle="tooltip" data-placement="top" readonly="readonly" maxlength="10" class="form-control hasDatepicker"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Lubrication Oil Temperature</label>
        <div class="col-lg-9">
            <input type="text" id="CIRMainBearingLubricationOilTemperature" data-toggle="tooltip" data-placement="top" placeholder="Main Bearing Lubrication Oil Temperature" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Lubrication Run Hours</label>
        <div class="col-lg-9">
            <input type="text" id="CIRMainBearingLubricationRunHours" data-toggle="tooltip" data-placement="top" placeholder="Main Bearing Lubrication Run Hours" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Lubrication Type</label>
        <div class="col-lg-9">
            <select id="CIRMainBearingLubricationType" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="OilType" data-valueField="OilTypeID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Manufacturer</label>
        <div class="col-lg-9">
            <select id="CIRMainBearingManufacturer" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="MainBearingManufacturer" data-valueField="MainBearingManufacturerID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Mechanical Oil Pump</label>
        <div class="col-lg-9">
            <input type="text" id="CIRMainBearingMechanicalOilPump" data-toggle="tooltip" data-placement="top" placeholder="Main Bearing Mechanical Oil Pump" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Revision</label>
        <div class="col-lg-9">
            <input type="text" id="CIRMainBearingRevision" data-toggle="tooltip" data-placement="top" placeholder="Main Bearing Revision" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Run Hours</label>
        <div class="col-lg-9">
            <input type="text" id="CIRMainBearingRunHours" data-toggle="tooltip" data-placement="top" placeholder="Main Bearing Run Hours" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Serial Number</label>
        <div class="col-lg-9">
            <input type="text" id="CIRMainBearingSerialNumber" data-toggle="tooltip" data-placement="top" placeholder="Main Bearing Serial Number" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Temperature</label>
        <div class="col-lg-9">
            <input type="text" id="CIRMainBearingTemperature" data-toggle="tooltip" data-placement="top" placeholder="Main Bearing Lubrication Oil Temperature" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Type</label>
        <div class="col-lg-9">
            <select id="CIRMainBearingType" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="MainBearingManufacturer" data-valueField="MainBearingManufacturerID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkCirAdvSearch_MainBearing" class="btn btn-primary AdvancedSearchButton">Search</a>
            <a href="javascript:void(0);" id="linkCirReset_MainBearing" class="btn btn-primary AdvancedSearchReset">Reset</a>
        </div>
    </div>
</fieldset>
