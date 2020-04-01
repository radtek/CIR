<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <legend>Transformer Data</legend>

    <div class="form-group">
        <label class="col-lg-3 control-label">Turbine Number</label>
        <div class="col-lg-9">
            <input id="CIRWTDTurbineNo5" data-toggle="tooltip" data-placement="top" placeholder="Turbine Number" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Action To Be Taken</label>
        <div class="col-lg-9">
            <select id="CIRTRTransformerActionToBeTaken" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="ActionOnTransformer" data-valueField="ActionOnTransformerID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Arc Detection</label>
        <div class="col-lg-9">
           <select id="CIRTRTransfArcDetection" class="chosen-select" style="width:350px;"    multiple="multiple" data-fieldType="select" data-dataTable="ArcDetection" data-valueField="ArcDetectionID" data-textField="text" data-sort="true">
               <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Aux. Equipment</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRTRTransfMountedOnMainComponent" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Brackets</label>
        <div class="col-lg-9">
           <select id="CIRTRTransformerBrackets" class="chosen-select" style="width:350px;"    multiple="multiple" data-fieldType="select" data-dataTable="Brackets" data-valueField="BracketsID" data-textField="text" data-sort="true">
               <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Climate</label>
        <div class="col-lg-9">
            <select id="CIRTRTransformerClimate" class="chosen-select" style="width:350px;"    multiple="multiple" data-fieldType="select" data-dataTable="Climate" data-valueField="ClimateID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Comment</label>
        <div class="col-lg-9">
            <input type="text" id="CIRTRTransformerComment" data-toggle="tooltip" data-placement="top" title="Transformer Comment" placeholder="Transformer Comment" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Connection Bars</label>
        <div class="col-lg-9">
            <select id="CIRTRTransformerConnectionBars" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="ConnectionBars" data-valueField="ConnectionBarsID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer HV Cable</label>
        <div class="col-lg-9">
            <select id="CIRTRTransformerHVCable" class="chosen-select" style="width:350px;"    multiple="multiple" data-fieldType="select" data-dataTable="CableCondition" data-valueField="CableConditionID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
            
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer HV Coil</label>
        <div class="col-lg-9">
            <select id="CIRTRTransformerHVCoil" class="chosen-select" style="width:350px;"    multiple="multiple" data-fieldType="select" data-dataTable="CoilCondition" data-valueField="CoilConditionID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer LV Cable</label>
        <div class="col-lg-9">
            <select id="CIRTRTransformerLVCable" class="chosen-select" style="width:350px;"    multiple="multiple" data-fieldType="select" data-dataTable="CableCondition" data-valueField="CableConditionID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer LV Coil</label>
        <div class="col-lg-9">
            <select id="CIRTRTransformerLVCoil" class="chosen-select" style="width:350px;"    multiple="multiple" data-fieldType="select" data-dataTable="CoilCondition" data-valueField="CoilConditionID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Manufacturer</label>
        <div class="col-lg-9">
           <select id="CIRTRTransfManufacturer" class="chosen-select" style="width:350px;"    multiple="multiple" data-fieldType="select" data-dataTable="TransformerManufacturer" data-valueField="TransformerManufacturerID" data-textField="text" data-sort="true">
               <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Max Temperature Reset From Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRTRTransformerMaxTemperatureResetDateFrom_txtDate" data-toggle="tooltip" 
                data-placement="top" readonly="readonly" placeholder="Transformer Max Temperature Reset From Date" class="form-control hasDatepicker" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Max Temperature Reset To Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRTRTransformerMaxTemperatureResetDateTo_txtDate" placeholder="Transformer Max Temperature Reset To Date" data-toggle="tooltip" data-placement="top" readonly="readonly" maxlength="10" class="form-control hasDatepicker"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Max Temperature</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGETransformerMaxTemperature" placeholder="Transformer Serial Number" data-toggle="tooltip" 
                data-placement="top" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Serial Number</label>
        <div class="col-lg-9">
            <input type="text" id="CIRTRTransfSerialNumber" placeholder="Transformer Serial Number" data-toggle="tooltip" 
                data-placement="top" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Transformer Surge Arrestor</label>
        <div class="col-lg-9">
            <select id="CIRTRTransformerSurgeArrestor" class="chosen-select" style="width:350px;"    multiple="multiple" data-fieldType="select" data-dataTable="SurgeArrestor" data-valueField="SurgeArrestorID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkCirAdvSearch_Transformer" class="btn btn-primary AdvancedSearchButton">Search</a>
            <a href="javascript:void(0);" id="linkCirReset_Transformer" class="btn btn-primary AdvancedSearchReset">Reset</a>
        </div>
    </div>
</fieldset>
