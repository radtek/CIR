<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <legend>Blade Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Turbine Number</label>
        <div class="col-lg-9">
            <input  id="CIRWTDTurbineNo1" data-toggle="tooltip" data-placement="top" placeholder="Turbine Number" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Aux. Equipment</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRBDMountedOnMainComponent" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Color</label>
        <div class="col-lg-9">
            <%--<select id="ddlBladeColor" class="form-control" data-toggle="tooltip" data-placement="top" title="Enter Blade Color"  data-fieldType="select" data-dataTable="BladeColor" data-textField="text" data-valueField="BladeColorID" data-sort="true">
            </select>--%>

            <select multiple="multiple" id="CIRBDColor" data-toggle="tooltip" data-placement="top"  title="Enter Blade Color" data-fieldType="select" data-dataTable="BladeColor" data-textField="text" data-valueField="BladeColorID" data-sort="true" class="chosen-select" style="width:350px;">
                <option value="-1"></option>
			</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Damage Identified</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRBDDamageIdentified" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Damage Placement</label>
        <div class="col-lg-9">
        <select size="2" multiple="multiple" id="CIRBDDamagePlacement" class="form-control">
            <option value="1">Internal</option>
            <option value="2">External</option>
        </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Damage Type</label>
        <div class="col-lg-9">
        <select multiple="multiple" id="CIRBDDamageType" data-toggle="tooltip" data-placement="top"   title="Enter Blade Damage Type" data-fieldType="select" data-dataTable="BladeInspectionData" data-textField="text" data-valueField="BladeInspectionDataID" data-sort="true" class="chosen-select" style="width:350px;">
            <option value="-1"></option>
		</select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Blade Description</label>
        <div class="col-lg-9">
            <textarea id="CIRBDDescription" placeholder="Blade Description"  data-toggle="tooltip" 
        data-placement="top" class="form-control"></textarea>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Edge</label>
        <div class="col-lg-9">
        <select multiple="multiple" id="CIRBDEdge" data-toggle="tooltip" data-placement="top" title="Enter Blade Edge" data-fieldType="select" data-dataTable="BladeEdge" data-textField="text" data-valueField="BladeEdgeID" data-sort="true" class="chosen-select" style="width:350px;">
            <option value="-1"></option>
		</select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Fault Code Area</label>
        <div class="col-lg-9">
         <select multiple="multiple" id="CIRBDFCArea" data-toggle="tooltip" data-placement="top" class="chosen-select" title="Enter Blade Fault Code Area" data-fieldType="select" data-dataTable="FaultCodeArea" data-textField="text" data-valueField="FaultCodeAreaID" data-sort="true" style="width:350px;">
             <option value="-1"></option>
		</select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Fault Code Cause</label>
        <div class="col-lg-9">
        <select multiple="multiple" id="CIRBDFCCause" data-toggle="tooltip" data-placement="top"   title="Enter Blade Fault Code Cause" data-fieldType="select" data-dataTable="FaultCodeCause" data-textField="text" data-valueField="FaultCodeCauseID" data-sort="true" class="chosen-select" style="width:350px;">
            <option value="-1"></option>
		</select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Fault Code Type</label>
        <div class="col-lg-9">
        <select multiple="multiple" id="CIRBDFCType" data-toggle="tooltip" data-placement="top"  title="Enter Blade Fault Code Type" data-fieldType="select" data-dataTable="FaultCodeType" data-textField="text" data-valueField="FaultCodeTypeID" data-sort="true" class="chosen-select" style="width:350px;">
            <option value="-1"></option>
		</select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Length (m)</label>
        <div class="col-lg-9">
        <select multiple="multiple" id="CIRBDLength" data-toggle="tooltip" data-placement="top"  title="Enter Blade Length" data-fieldType="select" data-dataTable="BladeLength" data-textField="text" data-valueField="BladeLengthID" data-sort="true" class="chosen-select" style="width:350px;">
            <option value="-1"></option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Calibration From Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSCalibrationDateFrom_txtDate" placeholder="Blade Light. Sys. Calibration from date" data-toggle="tooltip" data-placement="top" readonly="readonly" maxlength="10" class="form-control" data-original-title="Blade Light. Sys. Calibration From Date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Calibration To Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSCalibrationDateTo_txtDate" placeholder="Blade Light. Sys. Calibration to date" readonly="readonly" data-toggle="tooltip" data-placement="top" maxlength="10" class="form-control" data-original-title="Blade Light. Sys. Calibration to date" />
        </div>
    </div>

  
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Leeward Post-rep. 2</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSLeewardSidePostRepair2" class="form-control" placeholder="Blade Light. Sys. Leeward Post-rep. 2"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Leeward Post-rep. 3</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSLeewardSidePostRepair3" class="form-control" placeholder="Blade Light. Sys. Leeward Post-rep. 3"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Leeward Post-rep. 4</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSLeewardSidePostRepair4" class="form-control" placeholder="Blade Light. Sys. Leeward Post-rep. 4"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Leeward Post-rep. 5</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSLeewardSidePostRepair5" class="form-control" placeholder="Blade Light. Sys. Leeward Post-rep. 5"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Leeward Post-rep. Tip</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSLeewardSidePostRepairTip" class="form-control" placeholder="Blade Light. Sys. Leeward Post-rep. Tip"/>
        </div>
    </div>



    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Leeward Pre-rep. 2</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSLeewardSidePreRepair2" class="form-control" placeholder="Blade Light. Sys. Leeward Pre-rep. 2"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Leeward Pre-rep. 3</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSLeewardSidePreRepair3" class="form-control" placeholder="Blade Light. Sys. Leeward Pre-rep. 3"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Leeward Pre-rep. 4</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSLeewardSidePreRepair4" class="form-control" placeholder="Blade Light. Sys. Leeward Post-rep. 4"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Leeward Pre-rep. 5</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSLeewardSidePreRepair5" class="form-control" placeholder="Blade Light. Sys. Leeward Pre-rep. 5"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Leeward Pre-rep. Tip</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSLeewardSidePreRepairTip" class="form-control" placeholder="Blade Light. Sys. Leeward Pre-rep. Tip"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. VT Number</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSVTNumber" class="form-control" placeholder="Blade Light. Sys. VT Number"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Windward Post-rep. 2</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSWindwardSidePostRepair2" class="form-control" placeholder="Blade Light. Sys. Windward Post-rep. 2"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Windward Post-rep. 3</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSWindwardSidePostRepair3" class="form-control" placeholder="Blade Light. Sys. Windward Post-rep. 3"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Windward Post-rep. 4</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSWindwardSidePostRepair4" class="form-control" placeholder="Blade Light. Sys. Windward Post-rep. 4"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Windward Post-rep. 5</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSWindwardSidePostRepair5" class="form-control" placeholder="Blade Light. Sys. Windward Post-rep. 5"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Windward Post-rep. Tip</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSWindwardSidePostRepairTip" class="form-control" placeholder="Blade Light. Sys. Windward Post-rep. Tip"/>
        </div>
    </div>



    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Windward Pre-rep. 2</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSWindwardSidePreRepair2" class="form-control" placeholder="Blade Light. Sys. Windward Pre-rep. 2"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Windward Pre-rep. 3</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSWindwardSidePreRepair3" class="form-control" placeholder="Blade Light. Sys. Windward Pre-rep. 3"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Windward Pre-rep. 4</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSWindwardSidePreRepair4" class="form-control" placeholder="Blade Light. Sys. Windward Post-rep. 4"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Windward Pre-rep. 5</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSWindwardSidePreRepair5" class="form-control" placeholder="Blade Light. Sys. Windward Pre-rep. 5"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Light. Sys. Windward Pre-rep. Tip</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDLSWindwardSidePreRepairTip" class="form-control" placeholder="Blade Light. Sys. Windward Pre-rep. Tip"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Overall Blade Condition</label>
        <div class="col-lg-9">
        <select size="2" multiple="multiple" id="CIRBDFCClassification" class="form-control">
				<option value="1">1</option>
				<option value="2">2</option>
				<option value="3">3</option>
				<option value="4">4</option>
				<option value="5">5</option>
			</select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Pictures Included</label>
        <div class="col-lg-9">
        <select size="2" multiple="multiple" id="CIRBDPicturesIncluded" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Radius (m)</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDRadius" class="form-control" placeholder="Blade Radius (m)"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Add. Document Reference</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDDocumentReference" class="form-control" placeholder="Blade Rep. Rec. Add. Document Reference"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Ambient Temp.</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDAmbientTemp" class="form-control" placeholder="Blade Rep. Rec. Ambient Temp."/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Glass Supp. Batch No.</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDGlassSupplierBatchNo" class="form-control" placeholder="Blade Rep. Rec. Glass Supp. Batch No."/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Glass Supp.</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDGlassSupplier" class="form-control" placeholder="Blade Rep. Rec. Glass Supp."/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Hardener Type Batch No.</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDHardenerTypeBatchNo" class="form-control" placeholder="Blade Rep. Rec. Hardener Type Batch No."/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Hardener Type Exiry From Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDHardenerTypeExpiryDateFrom_txtDate" placeholder="Blade Rep. Rec. Hardener Type Exiry from date" readonly="readonly" data-toggle="tooltip" data-placement="top" maxlength="10    " class="form-control" data-original-title="Blade Rep. Rec. Hardener Type Exiry from date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Hardener Type Exiry To Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDHardenerTypeExpiryDateTo_txtDate" placeholder="Blade Rep. Rec. Hardener Type Exiry to date" readonly="readonly" data-toggle="tooltip" data-placement="top" maxlength="10" class="form-control" data-original-title="Blade Rep. Rec. Hardener Type Exiry to date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Hardener Type</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDHardenerType" class="form-control" placeholder="Blade Rep. Rec. Hardener Type"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Heaters Etc. Off From Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDResinTypeExpiryDateFrom_txtDate" placeholder="Blade Rep. Rec. Heaters Etc. Off from date" readonly="readonly" data-toggle="tooltip" data-placement="top" maxlength="10" class="form-control" data-original-title="Blade Rep. Rec. Heaters Etc. Off from date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Heaters Etc. Off To Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDResinTypeExpiryDateTo_txtDate" placeholder="Blade Rep. Rec. Heaters Etc. Off to date" readonly="readonly" data-toggle="tooltip" data-placement="top" maxlength="10" class="form-control" data-original-title="Blade Rep. Rec. Heaters Etc. Off to date" />
        </div>
    </div>
   
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Humidity</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDHumidity" class="form-control" placeholder="Blade Rep. Rec. Humidity"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Max. Post Cure Surf. Temp</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDPostCureSurfaceTempMax" class="form-control" placeholder="Blade Rep. Rec. Max. Post Cure Surf. Temp"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Max. Surf. Temp/Lam.</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDSurfaceTempMax" class="form-control" placeholder="Blade Rep. Rec. Max. Surf. Temp/Lam."/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Min. Post Cure Surf. Temp</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDPostCureSurfaceTempMin" class="form-control" placeholder="Blade Rep. Rec. Min. Post Cure Surf. Temp"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Min. Surf. Temp/Lam.</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDSurfaceTempMin" class="form-control" placeholder="Blade Rep. Rec. Min. Surf. Temp/Lam."/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Quantity Mixed Resin</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDQuantityOfResin" class="form-control" placeholder="Blade Rep. Rec. Quantity Mixed Resin"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Resin Type Batch No.</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDResinTypeBatchNo" class="form-control" placeholder="Blade Rep. Rec. Resin Type Batch No."/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Resin Type Exiry From Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDHeatersEtcOffFrom_txtDate" placeholder="Blade Rep. Rec. Resin Type Exiry from date" readonly="readonly" data-toggle="tooltip" data-placement="top" maxlength="10" class="form-control" data-original-title="Blade Rep. Rec. Resin Type Exiry from date" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Resin Type Exiry To Date</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDHeatersEtcOffTo_txtDate" placeholder="Blade Rep. Rec. Resin Type Exiry to date" readonly="readonly" data-toggle="tooltip" data-placement="top" maxlength="10" class="form-control" data-original-title="Blade Rep. Rec. Resin Type Exiry to date" />
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Resin Type</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDResinType" class="form-control" placeholder="Blade Rep. Rec. Resin Type"/>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Rep. Rec. Total Cure Time</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDTotalCureTime" class="form-control" placeholder="Blade Rep. Rec. Total Cure Time"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Serial No.</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDSerialNo" class="form-control" placeholder="Blade Serial No."/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Other Blades In Set</label>
        <div class="col-lg-9">
            <input type="text" id="CIRBDSerialNoOther" class="form-control" placeholder="Other Blades In Set"/>
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkCirAdvSearch_Blade" class="btn btn-primary AdvancedSearchButton">Search</a>
            <a href="javascript:void(0);" id="linkCirReset_Blade" class="btn btn-primary AdvancedSearchReset">Reset</a>
        </div>
    </div>
</fieldset>
