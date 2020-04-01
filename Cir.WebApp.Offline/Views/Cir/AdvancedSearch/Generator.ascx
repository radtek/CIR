<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<fieldset>
    <legend>Generator Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Turbine Number</label>
        <div class="col-lg-9">
            <input id="CIRWTDTurbineNo4" data-toggle="tooltip" data-placement="top" placeholder="Turbine Number" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator Action To Be Taken</label>
        <div class="col-lg-9">
            <select id="CIRGEGeneratorActionToBeTaken" class="chosen-select" style="width:350px;" multiple="multiple" data-fieldType="select" data-dataTable="ActionToBeTakenOnGenerator" data-valueField="ActionToBeTakenOnGeneratorID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator Aux. Equipment</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGEGeneratorMountedOnMainComponent" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator Comment</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorComment" data-toggle="tooltip" data-placement="top" placeholder="Generator Comment" class="form-control" />
        </div>
    </div>


    <div class="form-group">
        <label class="col-lg-3 control-label">Generator Cover</label>
        <div class="col-lg-9">
            <select id="CIRGEGeneratorCover" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="GeneratorCover" data-valueField="GeneratorCoverID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator Drive End</label>
        <div class="col-lg-9">
           <select id="CIRGEGeneratorDriveEnd" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="GeneratorDriveEnd" data-valueField="GeneratorDriveEndID" data-textField="text" data-sort="true">
               <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator K - Ground (unit)</label>
        <div class="col-lg-9">
            <select id="CIRGEGeneratorKGroundUnit" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="OhmUnit" data-valueField="OhmUnitID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>


    <div class="form-group">
        <label class="col-lg-3 control-label">Generator K - Ground</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorKGround" data-toggle="tooltip" data-placement="top" placeholder="Generator K - Ground" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator K1 - L1</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorK1L1" data-toggle="tooltip" data-placement="top" placeholder="Generator K1 - L1" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator K1 - M1</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorK1M1" data-toggle="tooltip" data-placement="top" placeholder="Generator K1 - M1" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator K2 - L2</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorK2L2" data-toggle="tooltip" data-placement="top" placeholder="enerator K2 - L2" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator K2 - M2</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorK2M2" data-toggle="tooltip" data-placement="top" placeholder="Generator K2 - M2" class="form-control" />
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Generator L - Ground (unit)</label>
        <div class="col-lg-9">
            <select id="CIRGEGeneratorLGroundUnit" class="chosen-select"  style="width:350px;" multiple="multiple" data-fieldType="select" data-dataTable="OhmUnit" data-valueField="OhmUnitID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>


    <div class="form-group">
        <label class="col-lg-3 control-label">Generator L - Ground</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorLGround" data-toggle="tooltip" data-placement="top" placeholder="Generator L - Ground" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator L1 - M1</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorL1M1" data-toggle="tooltip" data-placement="top" placeholder="Generator L1 - M1" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator L2 - M2</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorL2M2" data-toggle="tooltip" data-placement="top" placeholder="Generator L2 - M2" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator M - Ground (unit)</label>
        <div class="col-lg-9">
            <select id="CIRGEGeneratorMGroundUnit" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="OhmUnit" data-valueField="OhmUnitID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator M - Ground</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorMGround" data-toggle="tooltip" data-placement="top" placeholder="Generator M - Ground" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator Manufacturer</label>
        <div class="col-lg-9">
           <select id="CIRGEGeneratorManufacturer" class="chosen-select"  style="width:350px;" multiple="multiple" data-fieldType="select" data-dataTable="GeneratorManufacturer" data-valueField="GeneratorManufacturerID" data-textField="text" data-sort="true">
               <option value="-1"></option>
            </select>
             
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Generator OtherManufacturer</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorOtherManufacturer" data-toggle="tooltip" data-placement="top" placeholder="Generator OtherManufacturer" class="form-control" />
        </div>
    </div>

    
    <div class="form-group">
        <label class="col-lg-3 control-label">Max. Gen. Temp. Reset From Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorMaxTemperatureResetDateFrom_txtDate" data-toggle="tooltip" 
                data-placement="top" readonly="readonly" placeholder="Max. Gen. Temp. Reset From Date" class="form-control hasDatepicker" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Max. Gen. Temp. Reset To Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorMaxTemperatureResetDateTo_txtDate" placeholder="Enter Max. Gen Temp. to date" data-toggle="tooltip" data-placement="top" readonly="readonly" maxlength="10" class="form-control hasDatepicker" />
        </div>
    </div>


    <div class="form-group">
        <label class="col-lg-3 control-label">Generator Max Temperature (ºC)</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorMaxTemperature" placeholder="Generator Max Temperature (ºC)" data-toggle="tooltip" 
                data-placement="top" title="Generator Max Temperature (ºC)" class="form-control" />
        </div>
    </div>


    <div class="form-group">
        <label class="col-lg-3 control-label">Generator Non Drive End</label>
        <div class="col-lg-9">
            <select id="CIRGEGeneratorNonDriveEnd" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="GeneratorNonDriveEnd" data-valueField="GeneratorNonDriveEndID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Generator Rewound Locally</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGEGeneratorRewoundLocally" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator Rotor</label>
        <div class="col-lg-9">
            <select id="CIRGEGeneratorRotor" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="GeneratorRotor" data-valueField="GeneratorRotorID" data-textField="text" data-sort="true">
                  <option value="-1"></option>
            </select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Generator Serial Number</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorSerialNumber" placeholder="Generator Serial Number" data-toggle="tooltip" 
                data-placement="top" title="Generator Serial Number" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator U - Ground (unit)</label>
        <div class="col-lg-9">
           <select id="CIRGEGeneratorUGroundUnit" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="OhmUnit" data-valueField="OhmUnitID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Generator U - Ground</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorUGround" placeholder="Generator U - Ground" data-toggle="tooltip" 
                data-placement="top" title="Generator U - Ground" class="form-control" />
        </div>
    </div>


    <div class="form-group">
        <label class="col-lg-3 control-label">Generator U - V (unit)</label>
        <div class="col-lg-9">
            <select id="CIRGEGeneratorUVUnit" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="OhmUnit" data-valueField="OhmUnitID" data-textField="text" data-sort="true">
                  <option value="-1"></option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Generator U - V</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorUV" placeholder="Generator U - V" data-toggle="tooltip" 
                data-placement="top" title="Generator U - V" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator U - W (unit)</label>
        <div class="col-lg-9">
            <select id="CIRGEGeneratorUWUnit" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="OhmUnit" data-valueField="OhmUnitID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Generator U - W</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorUW" placeholder="Generator U - W" data-toggle="tooltip" 
                data-placement="top" title="Generator U - W" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator U1 - U2</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorU1U2" placeholder="Generator U1 - U2" data-toggle="tooltip" 
                data-placement="top" title="Generator U1 - U2" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator V - Ground (unit)</label>
        <div class="col-lg-9">
            <select id="CIRGEGeneratorVGroundUnit" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="OhmUnit" data-valueField="OhmUnitID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Generator V - Ground</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorVGround" placeholder="Generator V - Ground" data-toggle="tooltip" 
                data-placement="top" title="Generator V - Ground" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator V - W (unit)</label>
        <div class="col-lg-9">
             <select id="CIRGEGeneratorVWUnit" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="OhmUnit" data-valueField="OhmUnitID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
                 </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Generator V - W</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorVW" placeholder="Generator V - W" data-toggle="tooltip" 
                data-placement="top" title="Generator V - W" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator V1 - V2</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorV1V2" placeholder="Generator V1 - V2" data-toggle="tooltip" 
                data-placement="top" title="Generator V1 - V2" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator W - Ground (unit)</label>
        <div class="col-lg-9">
             <select id="CIRGEGeneratorWGroundUnit" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="OhmUnit" data-valueField="OhmUnitID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
			</select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Generator W - Ground</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorWGround" placeholder="Generator W - Ground" data-toggle="tooltip" 
                data-placement="top" title="Generator W - Ground" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Generator W1 - W2</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGEGeneratorW1W2" placeholder="Generator W1 - W2" data-toggle="tooltip" 
                data-placement="top" title="Generator W1 - W2" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkCirAdvSearch_Generator" class="btn btn-primary AdvancedSearchButton">Search</a>
            <a href="javascript:void(0);" id="linkCirReset_Generator" class="btn btn-primary AdvancedSearchReset">Reset</a>
        </div>
    </div>
</fieldset>
