<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <legend>General Component Data</legend>

    <div class="form-group">
        <label class="col-lg-3 control-label">Turbine Number</label>
        <div class="col-lg-9">
            <input  id="CIRWTDTurbineNo3" data-toggle="tooltip" data-placement="top" placeholder="Turbine Number" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Blade Ser. No.</label>
        <div class="col-lg-9">
            <input  id="CIRGCtbGeneralBladeSerNo" data-toggle="tooltip" data-placement="top" placeholder="General Blade Ser. No." class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Component group</label>
        <div class="col-lg-9">
        <select id="CIRGCGeneralCompGroup" multiple="multiple" class="chosen-select" style="width:350px;" data-dataTable="ComponentGroup"  data-valueField="ComponentGroupID" data-toggle="tooltip" data-placement="top" data-fieldType="select"  data-textField="text" data-sort="true">
             <option value="-1"></option>
        </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Component Manufacturer</label>
        <div class="col-lg-9">
            <input id="CIRGCGeneralCompManufact" data-toggle="tooltip" data-placement="top" placeholder="General Component Manufacturer" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">General Component Manufacturer Serial No.</label>
        <div class="col-lg-9">
            <input id="CIRGCtbGeneralCompSerNo" data-toggle="tooltip" data-placement="top" placeholder="General Component Manufacturer Serial No." class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">General Component Type</label>
        <div class="col-lg-9">
            <input id="CIRGCGeneralCompType" data-toggle="tooltip" data-placement="top" placeholder="General Component Type" class="form-control" />
        </div>
    </div>
    

    <div class="form-group">
        <label class="col-lg-3 control-label">General Control Type</label>
        <div class="col-lg-9">
            <select id="CIRGCGeneralCtrlType" multiple="multiple" class="chosen-select" style="width:350px;" data-dataTable="ControllerType"  data-valueField="ControllerTypeID" data-toggle="tooltip" data-placement="top" data-fieldType="select"  data-textField="text" data-sort="true">
                 <option value="-1"></option>
        </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Gearbox Manufacturer</label>
        <div class="col-lg-9">
        <select id="CIRGCGeneralGearboxManufact" multiple="multiple" class="chosen-select" style="width:350px;" data-dataTable="GearboxManufacturer"  data-valueField="GearboxManufacturerID" data-toggle="tooltip" data-placement="top" data-fieldType="select"  data-textField="text" data-sort="true">
             <option value="-1"></option>
        </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Generator Manufacturer</label>
        <div class="col-lg-9">
            <select id="CIRGCGeneralGeneratorManufact" multiple="multiple" class="chosen-select" style="width:350px;" data-dataTable="GeneratorManufacturer"  data-valueField="GeneratorManufacturerID" data-toggle="tooltip" data-placement="top" data-fieldType="select"  data-textField="text" data-sort="true">
                 <option value="-1"></option>
        </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Initiated By</label>
        <div class="col-lg-9">
            <input id="CIRGCGeneralInitiatedBy" data-toggle="tooltip" data-placement="top" placeholder="General Initiated By" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Executed By</label>
        <div class="col-lg-9">
            <input  id="CIRGCGeneralExecutedBy" data-toggle="tooltip" data-placement="top" placeholder="General Executed By" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Measurements Conducted</label>
        <div class="col-lg-9">
            <input id="CIRGCGeneralMeasurementsConducted" data-toggle="tooltip" data-placement="top" placeholder="General Measurements Conducted" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Other Gearbox Manufacturer</label>
        <div class="col-lg-9">
            <input id="CIRGCGeneralOtherGearboxManufact" data-toggle="tooltip" data-placement="top" placeholder="General Other Gearbox Manufacturer" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Other Gearbox Type</label>
        <div class="col-lg-9">
            <input  id="CIRGCGeneralOtherGearboxType" data-toggle="tooltip" data-placement="top" placeholder="General Other Gearbox Type" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Picture Attachement</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGCGeneralPicsAtt" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Ram Dump Number</label>
        <div class="col-lg-9">
            <input id="CIRGCtbGeneralRamDumpNo" data-toggle="tooltip" data-placement="top" placeholder="General Ram Dump Number" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Software Release</label>
        <div class="col-lg-9">
            <input  id="CIRGCtbGeneralSoftRel" data-toggle="tooltip" data-placement="top" placeholder="General Software Release" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Tower Height</label>
        <div class="col-lg-9">
            <select id="CIRGCGeneralTowerHeight" multiple="multiple" class="chosen-select" style="width:350px;" data-dataTable="TowerHeight"  data-valueField="TowerHeightID" data-toggle="tooltip" data-placement="top" data-fieldType="select"  data-textField="text" data-sort="true">
                 <option value="-1"></option>
			</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Tower Type</label>
        <div class="col-lg-9">
            <select id="CIRGCGeneralTowerType" multiple="multiple" class="chosen-select" style="width:350px;" data-dataTable="TowerType"  data-valueField="TowerTypeID" data-toggle="tooltip" data-placement="top" data-fieldType="select"  data-textField="text" data-sort="true">
                 <option value="-1"></option>
			</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">General Transformar Manufacturer</label>
        <div class="col-lg-9">
             <select id="CIRGCGeneralTransfManufact" multiple="multiple" class="chosen-select" style="width:350px;" data-dataTable="TransformerManufacturer"  data-valueField="TransformerManufacturerID" data-toggle="tooltip" data-placement="top" data-fieldType="select"  data-textField="text" data-sort="true">
			</select>
        </div>
    </div>


    <div class="form-group">
        <label class="col-lg-3 control-label">General VDF Track Number</label>
        <div class="col-lg-9">
            <input id="CIRGCtbGeneralVDFTrackNo" data-toggle="tooltip" data-placement="top" placeholder="General VDF Track Number" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Position Of Failed Item</label>
        <div class="col-lg-9">
            <input id="CIRGCGeneralPositionOfFailedItem" data-toggle="tooltip" data-placement="top" placeholder="Position Of Failed Item" class="form-control" />
        </div>
    </div>


    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkCirAdvSearch_General" class="btn btn-primary AdvancedSearchButton">Search</a>
            <a href="javascript:void(0);" id="linkCirReset_General" class="btn btn-primary AdvancedSearchReset">Reset</a>
        </div>
    </div>
</fieldset>
