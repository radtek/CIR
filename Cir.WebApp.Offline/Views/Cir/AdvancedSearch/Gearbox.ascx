<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<style type="text/css">
    .popover{
        max-width:600px;
    }
</style>
<fieldset>
    <legend>Gearbox Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Turbine Number</label>
        <div class="col-lg-9">
            <input id="CIRWTDTurbineNo2" data-toggle="tooltip" data-placement="top" placeholder="Turbine Number" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gearbox Serial Number<a tabindex="0" id="GearboxSerialNumberHelp" data-html="true" data-toggle="popover" data-trigger="hover" title="Help for Gearbox serial number:" data-content="<b><u>Hansen Transmissions:</u></b><br/> Can be a 6-digit number i.e. “236588” or an up to 21 character no.  i.e. “RW_EF901A-001L/LM0001”. “RW” is a prefix used when gears have been returned from Hansen Transmissions after repair. <br/> <b><u>Metso/Valmet/Santasalo/Moventas:</u></b><br/>Can be 5- 8 digit number i.e. “J51236R1” “R1” is a suffix used by this supplier to indicate that this gear unit has been refurbished/repaired once.  <br/><b><u>Winergy/Flender:</u></b><br/>Has 16-18 characters i.e. 421.106.802–0010–1 or 4.803.487–0020–2<br/><b><u>Lohmann/Rexroth:</u></b><br/>Can either be a 4 digit number i.e. “3928”, a 7 digit number i.e. “1027063” or a 11 digit number i.e. “10306083765”. However if a gearbox has been refurbished/repaired the serial number can have a suffix i.e. “R”, “RR”, or “REX” <br/> <b><u>Jahnel-Kestermann:</u></b><br/>Is a 16 characters number i.e. “31.00.6259.01.03.” Exception: If the gearbox is refurbished/repaired a rep. number is added in front of the original s/n i.e. “30.02.7914.01/31.98.3813.02.07.”<br/><b><u>Wind World: </u></b><br/>Is either a 3 or 4 digit number i.e. “948” or “1037”<br/><b><u>Kumera:</u></b><br/>Is a 10 digit number i.e. “270690/97-4/1”">
                <img src="../Images/info-icon.png" />
            </a></label>
        <div class="col-lg-9">
            <input type="text" id="CIRGDGearSerialNumber" placeholder="Gearbox Serial Number" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Gearbox Manufacturer</label>
        <div class="col-lg-9">
            <select id="CIRGDGearManufacturer" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="GearboxManufacturer" data-textField="text" data-valueField="GearboxManufacturerID" data-sort="true">
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Type</label>
        <div class="col-lg-9">
            <select id="CIRGDGearType" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="GearboxType" data-textField="text" data-valueField="GearboxTypeID" data-sort="true">
                     <option value="-1"></option>
            </select>
        </div>
    </div> 

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Aux. Equipment</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearMountedOnMainComponent" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>


    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Bearing Damage Type</label>
        <div class="col-lg-9">
            <select id="CIRGDGearBearingDamageType" class="chosen-select"  style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="BearingError" data-valueField="BearingErrorID" data-textField="text" data-sort="true">
                  <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Bearing Location</label>
        <div class="col-lg-9">
            <select id="CIRGDGearBearingLocation" class="chosen-select"  style="width:350px;" multiple="multiple" data-fieldType="select" data-dataTable="BearingType" data-valueField="BearingTypeID" data-textField="text" data-sort="true">
                 
                     <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Bearing Position</label>
        <div class="col-lg-9">
             <select id="CIRGDGearBearingPosition" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="BearingPos" data-valueField="BearingPosID" data-textField="text" data-sort="true">
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Coupling</label>
        <div class="col-lg-9">
            <select id="CIRGDGearCoupling" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="Coupling" data-valueField="CouplingID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
             
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Damage Type</label>
        <div class="col-lg-9">
            
            <select id="CIRGDGearDamageType" class="chosen-select"  style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="GearDamageCategory" data-valueField="GearDamageCategoryID" data-textField="text" data-sort="true">
                    <option value="-1"></option>
             
            </select>

        </div>
    </div>
     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. Air Breather</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccAirBreather" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. Chip Detector</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccChipDetector" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. Drain Valve</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccDrainValve" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. Filter Indicator</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccFilterIndicator" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. Immersion Heater</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccImmersionHeater" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. Oil Level Sensor</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccOilLevelSensor" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. Oil Pressure</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccOilPressure" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. PT100 Bearing 1</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccPT100Bearing1" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. PT100 Bearing 2</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccPT100Bearing2" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. PT100 Bearing 3</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccPT100Bearing3" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. PT100 Oil Sump</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccPT100OilSump" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Defect Acc. Sight Glass</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearDefectAccSightGlass" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Electrical Pump</label>
        <div class="col-lg-9">
             <select id="CIRGDGearElectricalPump" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="ElectricalPump" data-valueField="ElectricalPumpID" data-textField="text" data-sort="true">
                     <option value="-1"></option>
             
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Filter Block Type</label>
        <div class="col-lg-9">
             <select id="CIRGDGearFilterBlockType" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="FilterBlockType" data-valueField="FilterBlockTypeID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Generator Manufacturer</label>
        <div class="col-lg-9">
             <select id="CIRGDGearGeneratorManufacturer" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="GeneratorManufacturer" data-valueField="GeneratorManufacturerID" data-textField="text" data-sort="true">
                  <option value="-1"></option>
            </select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Housing Auxilary Stage</label>
        <div class="col-lg-9">
           <select id="CIRGDGearHousingAuxilaryStage" class="chosen-select"   style="width:350px;" multiple="multiple" data-fieldType="select" data-dataTable="HousingError" data-valueField="HousingErrorID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Housing Front Plate</label>
        <div class="col-lg-9">
             <select id="CIRGDGearHousingFrontPlate" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="HousingError" data-valueField="HousingErrorID" data-textField="text" data-sort="true">
                  <option value="-1"></option>
            </select>
            
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Housing HS Stage</label>
        <div class="col-lg-9">
             <select id="CIRGDGearHousingHSStage" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="HousingError" data-valueField="HousingErrorID" data-textField="text" data-sort="true">
                  <option value="-1"></option>
            </select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Housing Planet Stage 1</label>
        <div class="col-lg-9">
            <select id="CIRGDGearHousingPlanetStage1" class="chosen-select"  style="width:350px;" multiple="multiple" data-fieldType="select" data-dataTable="HousingError" data-valueField="HousingErrorID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Housing Planet Stage 2</label>
        <div class="col-lg-9">
           <select id="CIRGDGearHousingPlanetStage2" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="HousingError" data-valueField="HousingErrorID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Housing Stage</label>
        <div class="col-lg-9">
           <select id="CIRGDGearHousingStage" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="HousingError" data-valueField="HousingErrorID" data-textField="text" data-sort="true">
                <option value="-1"></option>
            </select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Gear In Line Filter</label>
        <div class="col-lg-9">
            <select id="CIRGDGearInLineFilter" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="InlineFilter" data-valueField="InlineFilterID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Leakage Aux. HSS/PTO</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearLeakageAuxHSSPTO" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>
    
     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Leakage Hose Piping</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearLeakageHosePiping" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>
    
     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Leakage HSS NR End</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearLeakageHSSNREnd" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>
    
     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Leakage HSS R End:</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearLeakageHSSREnd" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>
    
     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Leakage IMS NR End</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearLeakageIMSNREnd" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Leakage IMS R End</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearLeakageIMSREnd" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Leakage Input Shaft</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearLeakageInputShaft" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>
    
     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Leakage LSS NR End</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearLeakageLSSNREnd" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Leakage Pitch Tube</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearLeakagePitchTube" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>
    
     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Leakage Split Lines</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearLeakageSplitLines" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Location</label>
        <div class="col-lg-9">
            <select id="CIRGDGearLocation" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="GearType" data-valueField="GearTypeID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Mechanical Oil Pump</label>
        <div class="col-lg-9">
            <select id="CIRGDGearMechanicalOilPump" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="MechanicalOilPump" data-valueField="MechanicalOilPumpID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Off Line Filter</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearOffLineFilter" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Oil Level</label>
        <div class="col-lg-9">
            <select id="CIRGDGearOilLevel" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="OilLevel" data-valueField="OilLevelID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Oil Type</label>
        <div class="col-lg-9">
            <select id="CIRGDGearOilType" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="OilType" data-valueField="OilTypeID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>
    
    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Other Manufacturer</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGDGearOtherManufacturer" placeholder="Gear Other Manufacturer" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Overall Gearbox Condition</label>
        <div class="col-lg-9">
            <select id="CIRGDGearSymptomsOverallGearboxCondition" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="OverallGearboxCondition" data-valueField="OverallGearboxConditionID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Production (kWh)</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGDGearProduction" placeholder="Gear Production (kWh)" class="form-control" />
        </div>
    </div>


     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Revision</label>
        <div class="col-lg-9">
            <select id="CIRGDGearRevision" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="GearboxRevision" data-valueField="GearboxRevisionID" data-textField="text" data-sort="true">
            </select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Second Generator Manufacturer</label>
        <div class="col-lg-9">
            <select id="CIRGDGearSecondGeneratorManufacturer" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="GeneratorManufacturer" data-valueField="GeneratorManufacturerID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Shaft Damage Type</label>
        <div class="col-lg-9">
             <select id="CIRGDGearShaftDamageType" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="ShaftError" data-valueField="ShaftErrorID" data-textField="text" data-sort="true">
                  <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Shaft Location</label>
        <div class="col-lg-9">
            <select id="CIRGDGearShaftLocation" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="ShaftType" data-valueField="ShaftTypeID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Shrink Elem. Ser. No.</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGDGearShrinkElementSerialNumber" placeholder="Gear Shrink Elem. Ser. No." class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Shrink Element</label>
        <div class="col-lg-9">
            <select id="CIRGDGearShrinkElement" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="ShrinkElement" data-valueField="ShrinkElementID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Software Release</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGDGearSoftwareRelease" placeholder="Gear Software Release" class="form-control" />
        </div>
    </div>


    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Symptoms Debris In Gearbox</label>
        <div class="col-lg-9">
            <select id="CIRGDGearSymptomsDebrisInGearbox" class="chosen-select" style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="DebrisGearbox" data-valueField="DebrisGearboxID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Symptoms Debris On Magnet</label>
        <div class="col-lg-9">
             <select id="CIRGDGearSymptomsDebrisOnMagnet" class="chosen-select"  style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="DebrisOnMagnet" data-valueField="DebrisOnMagnetID" data-textField="text" data-sort="true">
                  <option value="-1"></option>
            </select>
            </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Gear Symptoms Magnet Position</label>
        <div class="col-lg-9">
            <select id="CIRGDGearSymptomsMagnetPosition" class="chosen-select" style="width:350px;"  multiple="multiple" data-fieldType="select" data-dataTable="MagnetPos" data-valueField="MagnetPosID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Symptoms Noise</label>
        <div class="col-lg-9">
             <select id="CIRGDGearSymptomsNoise" class="chosen-select"  style="width:350px;"   multiple="multiple" data-fieldType="select" data-dataTable="Noise" data-valueField="NoiseID" data-textField="text" data-sort="true">
                  <option value="-1"></option>
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Symptoms Vibrations</label>
        <div class="col-lg-9">
            <select id="CIRGDGearSymptomsVibrations" class="chosen-select" style="width:350px;"      multiple="multiple" data-fieldType="select" data-dataTable="Vibrations" data-valueField="VibrationsID" data-textField="text" data-sort="true">
                 <option value="-1"></option>
            </select>
        </div>
    </div>
    

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Torque Arm Broken Bolts</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearTorqueBrokenBolts" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Torque Arm Cracked/Broken</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearTorqueCrackedBroken" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Torque Arm Defect Damper</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearTorqueDefectDamper" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Torque Arm Loose Bolts</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearTorqueLooseBolts" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Torque Arm Needs Alignment</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearTorqueNeedsAlignment" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Gear Torque Arm Too Much Clearance</label>
        <div class="col-lg-9">
            <select size="2" multiple="multiple" id="CIRGDGearTorqueTooMuchClearance" class="form-control">
			<option value="1">No</option>
			<option value="2">Yes</option>
		</select>
        </div>
    </div>

    
    <div class="form-group">
        <label class="col-lg-3 control-label">Other Gear Type</label>
        <div class="col-lg-9">
            <input type="text" id="CIRGDOtherGearType" placeholder="Other Gear Type" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkCirAdvSearch_Gearbox" class="btn btn-primary AdvancedSearchButton">Search</a>
            <a href="javascript:void(0);" id="linkCirReset_Gearbox" class="btn btn-primary AdvancedSearchReset">Reset</a>
        </div>
    </div>
    <input type="hidden" id="hdnGearTypeDamageDecision" value="" />
</fieldset>
