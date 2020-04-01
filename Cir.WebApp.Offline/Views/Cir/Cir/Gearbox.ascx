<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<style type="text/css">
    .popover{
        max-width:600px;
    }
</style>
<fieldset>
    <legend>Gearbox Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Gearbox Manufacturer<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlGearboxGManufacturer" class="form-control ddlvalidation"  data-fieldType="select" data-dataTable="GearboxManufacturer" data-textField="text" data-valueField="GearboxManufacturerID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Other Gearbox Manufacturer</label>
        <div class="col-lg-9">
            <input type="text" id="txtOtherGearboxGManufacturer" placeholder="Other Gearbox Manufacturer" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Gearbox Type<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlGearboxGType" class="form-control ddlvalidation" >
            </select>
        </div>
    </div>


    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkOtherGearboxGType" class="badge">Click here to insert Other Gearbox Type..</a></label>
    </div>
    <div id="divOtherGearboxGType" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Other Gearbox Type</label>
            <div class="col-lg-9">
                <input type="text" id="txtOtherGearboxGType" placeholder="Other Gearbox Type" class="form-control" />
            </div>
        </div>
    </div>



    <div class="form-group">
        <label class="col-lg-3 control-label">Gearbox Revision<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlGearboxGRevision" class="form-control ddlvalidation" data-fieldType="select" data-dataTable="GearboxRevision" data-textField="text" data-valueField="GearboxRevisionID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Gearbox Serial Number<span class="errorSpan">*</span><a tabindex="0" id="GearboxSerialNumberHelp" data-html="true" data-toggle="popover" data-trigger="hover" title="Help for Gearbox serial number:" data-content="<b><u>Hansen Transmissions:</u></b><br/> Can be a 6-digit number i.e. “236588” or an up to 21 character no.  i.e. “RW_EF901A-001L/LM0001”. “RW” is a prefix used when gears have been returned from Hansen Transmissions after repair. <br/> <b><u>Metso/Valmet/Santasalo/Moventas:</u></b><br/>Can be 5- 8 digit number i.e. “J51236R1” “R1” is a suffix used by this supplier to indicate that this gear unit has been refurbished/repaired once.  <br/><b><u>Winergy/Flender:</u></b><br/>Has 16-18 characters i.e. 421.106.802–0010–1 or 4.803.487–0020–2<br/><b><u>Lohmann/Rexroth:</u></b><br/>Can either be a 4 digit number i.e. “3928”, a 7 digit number i.e. “1027063” or a 11 digit number i.e. “10306083765”. However if a gearbox has been refurbished/repaired the serial number can have a suffix i.e. “R”, “RR”, or “REX” <br/> <b><u>Jahnel-Kestermann:</u></b><br/>Is a 16 characters number i.e. “31.00.6259.01.03.” Exception: If the gearbox is refurbished/repaired a rep. number is added in front of the original s/n i.e. “30.02.7914.01/31.98.3813.02.07.”<br/><b><u>Wind World: </u></b><br/>Is either a 3 or 4 digit number i.e. “948” or “1037”<br/><b><u>Kumera:</u></b><br/>Is a 10 digit number i.e. “270690/97-4/1”">
                <img src="../Images/info-icon.png" />
            </a></label>
        <div class="col-lg-9">
            <input type="text" id="txtGearboxSerialNumber" placeholder="Gearbox Serial Number" class="form-control ddlvalidation" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Aux. equipment<span class="errorSpan">*</span><a tabindex="0" id="AuxequipmentHelp" data-html="true" data-toggle="popover" data-trigger="hover" title="Help for Aux Equipment:" data-content="<b><u>Help for Aux. Equipment (failure reports only):</u></b><br/>Select yes if the item is an aux. equipment mounted on the main component e.g :<br/>- torque arm<br/>- mech. Oil pump<br/>- brake<br/> Select no if the item is e.g:<br/>-  bearings. ">
                <img src="../Images/info-icon.png" />
            </a></label>
        <div class="col-lg-9">
            <select id="ddlAuxGearEquipment" class="form-control">
                <option value="1">NO</option>
                <option value="2">YES</option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Date For Last Oil Change</label>
        <div class="col-lg-9">
            <input type="text" id="txtDateForLastOilChange" placeholder="Date For Last Oil Change" class="form-control" style="background-color:#fff" readonly="readonly" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Oil Type<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlOilGearType" class="form-control ddlvalidation"  data-fieldType="select" data-dataTable="OilType" data-textField="text" data-valueField="OilTypeID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Type of Mechanical Oil Pump<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTypeOfMechanicalOilPump" class="form-control ddlvalidation"  data-fieldType="select" data-dataTable="MechanicalOilPump" data-textField="text" data-valueField="MechanicalOilPumpID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Oil Level in Gearbox (in %)<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlOilLevelInGearbox" class="form-control ddlvalidation" data-fieldType="select" data-dataTable="OilLevel" data-textField="text" data-valueField="OilLevelID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Gearbox (hrs)</label>
        <div class="col-lg-9">
            <input type="number" id="txtGearboxHrs" placeholder="Gearbox (hrs)" class="form-control numbersOnly" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Oil Temperature at oil level check (ºC)<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtOilTemperatureAtOilLevelCheck" placeholder="Oil Temperature at oil level check (ºC)" class="form-control  numbersOnly" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Gearbox Production (kWh)</label>
        <div class="col-lg-9">
            <input type="number" id="txtGearboxProduction" placeholder="Gearbox Production (kWh)" class="form-control numbersOnly" />
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>Additional Gearbox Data</legend>
    <div class="form-group" data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5,6">
        <label class="col-lg-3 control-label" id="lblActionToBeTakenOnGearbox">Action performed on gearbox</label>
        <div class="col-lg-9">
            <select id="ddlActionToBeTakenOnGearbox" class="form-control ddlvalidation"  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5,6" data-fieldType="select" data-dataTable="ActionToBeTakenOnGearbox" data-textField="text" data-valueField="ActionToBeTakenOnGearboxID">
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkGeneratorGManufacturer" class="badge">Click here to insert Generator Manufacturer..</a></label>
    </div>
    <div id="divGeneratorGManufacturer" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Generator Manufacturer</label>
            <div class="col-lg-9">
                <select id="ddlGeneratorGManufacturer" class="form-control "  data-fieldType="select" data-dataTable="GeneratorManufacturer" data-textField="text" data-valueField="GeneratorManufacturerID" data-sort="true">
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Second Generator Manufacturer</label>
            <div class="col-lg-9">
                <select id="ddlSecondGeneratorGManufacturer" class="form-control "  data-fieldType="select" data-dataTable="GeneratorManufacturer" data-textField="text" data-valueField="GeneratorManufacturerID" data-sort="true">
                </select>
            </div>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkElectricalPump" class="badge">Click here to insert Electrical Pump..</a></label>
    </div>
    <div id="divElectricalPump" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Electrical Pump</label>
            <div class="col-lg-9">
                <select id="ddlElectricalPump" class="form-control" data-fieldType="select" data-dataTable="ElectricalPump" data-textField="text" data-valueField="ElectricalPumpID" data-sort="true">
                </select>
            </div>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkShrinkElement" class="badge">Click here to insert Shrink Element..</a></label>
    </div>
    <div id="divShrinkElement" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Shrink Element</label>
            <div class="col-lg-9">
                <select id="ddlShrinkElement" class="form-control ddlvalidation" data-fieldType="select" data-dataTable="ShrinkElement" data-textField="text" data-valueField="ShrinkElementID" data-sort="true">
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number of Shrink Element<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" id="txtSerialNumberofShrinkElement" class="form-control" placeholder="Serial Number of Shrink Element" />
            </div>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Coupling</label>
        <div class="col-lg-9">
            <select id="ddlGearboxCoupling" class="form-control" data-fieldType="select" data-dataTable="Coupling" data-textField="text" data-valueField="CouplingID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Filter Block Type</label>
        <div class="col-lg-9">
            <select id="ddlFilterBlockType" class="form-control " data-fieldType="select" data-dataTable="FilterBlockType" data-textField="text" data-valueField="FilterBlockTypeID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">In-line Filter</label>
        <div class="col-lg-9">
            <select id="ddlInlineFilter" class="form-control " data-fieldType="select" data-dataTable="InlineFilter" data-textField="text" data-valueField="InlineFilterID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Off-line Filter</label>
        <div class="col-lg-9">
            <select id="ddlOfflineFilter" class="form-control">
                <option value="1">NO</option>
                <option value="2">YES</option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Software Release</label>
        <div class="col-lg-9">
            <input type="text" id="txtGearSoftwareRelease" class="form-control" placeholder="Software Release" />
        </div>
    </div>

</fieldset>
<fieldset>
    <legend>Clearly Identified Damages</legend>

    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkShafts" class="badge">Click here to insert Shafts..</a></label>
    </div>
    <div id="divShafts" style="display: none;">
        <div class="form-group">
            <h4 class="col-lg-3 control-label">Shafts</h4>
        </div>
        <div class="form-group">
            <div class="col-lg-9">
                <table>
                    <tr>
                        <td></td>
                        <td>
                            <label class="control-label">Exact Location</label></td>

                        <td>
                            <label class="control-label">Type of Damage</label></td>


                    </tr>
                    <tr>
                        <td>1</td>
                        <td>
                            <select id="ddlGearboxShaftsExactLocation1ShaftTypeId" class="form-control"  data-fieldType="select" data-dataTable="ShaftType" data-textField="text" data-valueField="ShaftTypeID" data-sort="true" data-topitem="Not Inspected">
                            </select>
                        </td>
                        <td>
                            <select id="ddlGearboxShaftsTypeofDamage1ShaftErrorId" class="form-control" data-fieldType="select" data-dataTable="ShaftError" data-textField="text" data-valueField="ShaftErrorID" data-sort="true">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>2</td>
                        <td>
                            <select id="ddlGearboxShaftsExactLocation2ShaftTypeId" class="form-control" data-fieldType="select" data-dataTable="ShaftType" data-textField="text" data-valueField="ShaftTypeID" data-sort="true" data-topitem="Not Inspected">
                            </select>
                        </td>
                        <td>
                            <select id="ddlGearboxShaftsTypeofDamage2ShaftErrorId" class="form-control" data-fieldType="select" data-dataTable="ShaftError" data-textField="text" data-valueField="ShaftErrorID" data-sort="true">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>3</td>
                        <td>
                            <select id="ddlGearboxShaftsExactLocation3ShaftTypeId" class="form-control" data-fieldType="select" data-dataTable="ShaftType" data-textField="text" data-valueField="ShaftTypeID" data-sort="true" data-topitem="Not Inspected">
                            </select>
                        </td>
                        <td>
                            <select id="ddlGearboxShaftsTypeofDamage3ShaftErrorId" class="form-control" data-fieldType="select" data-dataTable="ShaftError" data-textField="text" data-valueField="ShaftErrorID" data-sort="true">
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <td>4</td>
                        <td>
                            <select id="ddlGearboxShaftsExactLocation4ShaftTypeId" class="form-control" data-fieldType="select" data-dataTable="ShaftType" data-textField="text" data-valueField="ShaftTypeID" data-sort="true" data-topitem="Not Inspected">
                            </select>
                        </td>
                        <td>
                            <select id="ddlGearboxShaftsTypeofDamage4ShaftErrorId" class="form-control" data-fieldType="select" data-dataTable="ShaftError" data-textField="text" data-valueField="ShaftErrorID" data-sort="true">
                            </select>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <div class="form-group">
        <h4 class="col-lg-3 control-label">Gears defect</h4>
    </div>
    <div class="form-group">
        <div class="col-lg-12">
            <table>
                <tr>
                    <td></td>
                    <td>
                        <label class="control-label">Exact Location</label></td>

                    <td>
                      <span id="_sTypeDamageRequired" style="display:none;color:red"">*</span>  <label class="control-label">Type of Damage</label></td>

                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                         <span id="_sClassDamageRequired" style="display:none;color:red"">*</span> 
                        <label class="control-label">Damage Class</label></td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <label class="control-label">Decision</label></td>
                </tr>
                <tr>
                    <td>1</td>
                    <td>
                        <select id="ddlExactLocation1" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage1" class="form-control _TypeOfDamage" >
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDamageClass1" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDecision1" class="form-control">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>
                        <select id="ddlExactLocation2" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage2" class="form-control _TypeOfDamage">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDamageClass2" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDecision2" class="form-control " >
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>3</td>
                    <td>
                        <select id="ddlExactLocation3" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage3" class="form-control _TypeOfDamage">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDamageClass3" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDecision3" class="form-control">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>4</td>
                    <td>
                        <select id="ddlExactLocation4" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage4" class="form-control _TypeOfDamage"  data-fieldType="select" data-dataTable="GearDamageCategory" data-textField="text" data-valueField="GearDamageCategoryID">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDamageClass4" class="form-control _DamageClass" data-fieldType="select" data-dataTable="Damage" data-textField="text" data-valueField="DamageID">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDecision4" class="form-control">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>5</td>
                    <td>
                        <select id="ddlExactLocation5" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage5" class="form-control _TypeOfDamage"  data-fieldType="select" data-dataTable="GearDamageCategory" data-textField="text" data-valueField="GearDamageCategoryID">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDamageClass5" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDecision5" class="form-control">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>6</td>
                    <td>
                        <select id="ddlExactLocation6" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage6" class="form-control _TypeOfDamage" >
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDamageClass6" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlDecision6" class="form-control">
                        </select>
                    </td>
                </tr>
                <tr  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                    <td>7</td>
                    <td>
                        <select id="ddlExactLocation7" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage7" class="form-control _TypeOfDamage">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDamageClass7" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDecision7" class="form-control">
                        </select>
                    </td>
                </tr>
                <tr  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                    <td>8</td>
                    <td>
                        <select id="ddlExactLocation8" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage8" class="form-control _TypeOfDamage">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDamageClass8" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDecision8" class="form-control">
                        </select>
                    </td>
                </tr>
                <tr  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                    <td>9</td>
                    <td>
                        <select id="ddlExactLocation9" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage9" class="form-control _TypeOfDamage">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDamageClass9" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDecision9" class="form-control">
                        </select>
                    </td>
                </tr>
                <tr  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                    <td>10</td>
                    <td>
                        <select id="ddlExactLocation10" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage10" class="form-control _TypeOfDamage">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDamageClass10" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDecision10" class="form-control">
                        </select>
                    </td>
                </tr>
                <tr  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                    <td>11</td>
                    <td>
                        <select id="ddlExactLocation11" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage11" class="form-control _TypeOfDamage">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDamageClass11" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDecision11" class="form-control">
                        </select>
                    </td>
                </tr>
                <tr  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                    <td>12</td>
                    <td>
                        <select id="ddlExactLocation12" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage12" class="form-control _TypeOfDamage">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDamageClass12" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDecision12" class="form-control" >
                        </select>
                    </td>
                </tr>
                <tr  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                    <td>13</td>
                    <td>
                        <select id="ddlExactLocation13" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage13" class="form-control _TypeOfDamage" >
                        </select>
                    </td>
                    <td>
                        <select id="ddlDamageClass13" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDecision13" class="form-control" >
                        </select>
                    </td>
                </tr>
                <tr  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                    <td>14</td>
                    <td>
                        <select id="ddlExactLocation14" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage14" class="form-control _TypeOfDamage">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDamageClass14" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDecision14" class="form-control" >
                        </select>
                    </td>
                </tr>
                <tr  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                    <td>15</td>
                    <td>
                        <select id="ddlExactLocation15" class="form-control _GearExactLocation" data-fieldType="select" data-dataTable="GearType" data-textField="text" data-valueField="GearTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeIfDamage15" class="form-control _TypeOfDamage">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDamageClass15" class="form-control _DamageClass">
                        </select>
                    </td>
                    <td>
                        <select id="ddlDecision15" class="form-control">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <h4 class="col-lg-3 control-label">Bearings defect</h4>
    </div>
    <div class="form-group">
        <div class="col-lg-12">
            <table>
                <tr>
                    <td></td>
                    <td>
                        <label class="control-label">Location<span class="errorSpan">*</span></label></td>

                    <td>
                        <label class="control-label">Position<span class="errorSpan">*</span></label></td>


                    <td>
                        <label class="control-label">Type of Damage<span class="errorSpan">*</span></label></td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <label class="control-label">Damage Class<span class="errorSpan">*</span></label></td>
                </tr>
                <tr>
                    <td>1</td>
                    <td>
                        <select id="ddlLocation1" class="form-control _BearLocation" data-fieldType="select" data-dataTable="BearingType" data-textField="text" data-valueField="BearingTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlPosition1" class="form-control _BearPosition" data-fieldType="select" data-dataTable="BearingPos" data-textField="text" data-valueField="BearingPosID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>
                    <td>
                        <select id="ddlTypeofDamage1" class="form-control _BearTypeOfDamage" data-fieldType="select" data-dataTable="BearingError" data-textField="text" data-valueField="BearingErrorID">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlBearingDamageClass1" class="form-control _BearDamageClass">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>
                        <select id="ddlLocation2" class="form-control _BearLocation" data-fieldType="select" data-dataTable="BearingType" data-textField="text" data-valueField="BearingTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlPosition2" class="form-control _BearPosition" data-fieldType="select" data-dataTable="BearingPos" data-textField="text" data-valueField="BearingPosID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeofDamage2" class="form-control _BearTypeOfDamage" data-fieldType="select" data-dataTable="BearingError" data-textField="text" data-valueField="BearingErrorID">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlBearingDamageClass2" class="form-control _BearDamageClass">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>3</td>
                    <td>
                        <select id="ddlLocation3" class="form-control _BearLocation" data-fieldType="select" data-dataTable="BearingType" data-textField="text" data-valueField="BearingTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlPosition3" class="form-control _BearPosition" data-fieldType="select" data-dataTable="BearingPos" data-textField="text" data-valueField="BearingPosID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeofDamage3" class="form-control _BearTypeOfDamage" data-fieldType="select" data-dataTable="BearingError" data-textField="text" data-valueField="BearingErrorID">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlBearingDamageClass3" class="form-control _BearDamageClass">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>4</td>
                    <td>
                        <select id="ddlLocation4" class="form-control _BearLocation" data-fieldType="select" data-dataTable="BearingType" data-textField="text" data-valueField="BearingTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlPosition4" class="form-control _BearPosition" data-fieldType="select" data-dataTable="BearingPos" data-textField="text" data-valueField="BearingPosID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeofDamage4" class="form-control _BearTypeOfDamage" data-fieldType="select" data-dataTable="BearingError" data-textField="text" data-valueField="BearingErrorID">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlBearingDamageClass4" class="form-control _BearDamageClass">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>5</td>
                    <td>
                        <select id="ddlLocation5" class="form-control _BearLocation" data-fieldType="select" data-dataTable="BearingType" data-textField="text" data-valueField="BearingTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlPosition5" class="form-control _BearPosition" data-fieldType="select" data-dataTable="BearingPos" data-textField="text" data-valueField="BearingPosID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeofDamage5" class="form-control _BearTypeOfDamage" data-fieldType="select" data-dataTable="BearingError" data-textField="text" data-valueField="BearingErrorID">
                        </select>
                    </td>
                    <td  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                        <select id="ddlBearingDamageClass5" class="form-control _BearDamageClass">
                        </select>
                    </td>
                </tr>
                <tr  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5">
                    <td>6</td>
                    <td>
                        <select id="ddlLocation6" class="form-control _BearLocation" data-fieldType="select" data-dataTable="BearingType" data-textField="text" data-valueField="BearingTypeID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlPosition6" class="form-control _BearPosition" data-fieldType="select" data-dataTable="BearingPos" data-textField="text" data-valueField="BearingPosID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>

                    <td>
                        <select id="ddlTypeofDamage6" class="form-control _BearTypeOfDamage" data-fieldType="select" data-dataTable="BearingError" data-textField="text" data-valueField="BearingErrorID">
                        </select>
                    </td>
                    <td>
                        <select id="ddlBearingDamageClass6" class="form-control _BearDamageClass">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <h4 class="col-lg-3 control-label">Housing</h4>
    </div>
    <div class="form-group">
        <div class="col-lg-9">
            <table>
                <tr>
                    <td style="width: 50%;">
                        <label class="control-label">Planet Stage 1</label>

                    </td>
                    <td>
                        <select id="ddlPlanetStage1" class="form-control" data-fieldType="select" data-dataTable="HousingError" data-textField="text" data-valueField="HousingErrorID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="control-label">Planet Stage 2</label>

                    </td>
                    <td>
                        <select id="ddlPlanetStage2" class="form-control" data-fieldType="select" data-dataTable="HousingError" data-textField="text" data-valueField="HousingErrorID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="control-label">Helical/Parallel Stage</label>

                    </td>
                    <td>
                        <select id="ddlHelicalParallelStage" class="form-control" data-fieldType="select" data-dataTable="HousingError" data-textField="text" data-valueField="HousingErrorID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="control-label">Front Plate</label>

                    </td>
                    <td>
                        <select id="ddlFrontPlate" class="form-control" data-fieldType="select" data-dataTable="HousingError" data-textField="text" data-valueField="HousingErrorID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="control-label">Auxilliary Stage</label>

                    </td>
                    <td>
                        <select id="ddlAuxlliaryStage" class="form-control" data-fieldType="select" data-dataTable="HousingError" data-textField="text" data-valueField="HousingErrorID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="control-label">HS Stage</label>

                    </td>
                    <td>
                        <select id="ddlHSStage" class="form-control" data-fieldType="select" data-dataTable="HousingError" data-textField="text" data-valueField="HousingErrorID" data-sort="true" data-topitem="Not Inspected">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkTorqueArmSystem" class="badge">Click here to insert Damages Torque Arm System..</a></label>
    </div>
    <div id="divTorqueArmSystem" style="display: none;">
        <div class="form-group">
            <h4 class="col-lg-3 control-label">Torque Arm System</h4>
        </div>
        <div class="form-group">
            <div class="col-lg-9">
                <table>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkLooseBolts" class="control-label" title="Loose Bolts" />
                        </td>
                        <td>
                            <label class="control-label">Loose Bolts</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkBrokenBolts" class="control-label" title="Broken Bolts" />
                        </td>
                        <td>
                            <label class="control-label">Borken Bolts</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkDefectDamperElements" class="control-label" title="Defect Damper Elements" />
                        </td>
                        <td>
                            <label class="control-label">Defect Damper Elements</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkTooMuchClearance" class="control-label" title="Too Much Clearance" />
                        </td>
                        <td>
                            <label class="control-label">Too Much Clearance</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkCrackedBrokenTorqueArm" class="control-label" title="Cracked Broken Torque Arm" />
                        </td>
                        <td>
                            <label class="control-label">Cracked Broken Torque Arm</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkNeedsToBeAligned" class="control-label" title="Needs To Be Aligned" />
                        </td>
                        <td>
                            <label class="control-label">Needs To Be Aligned</label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkDefectAccessories" class="badge">Click here to insert Defect Accessories..</a></label>
    </div>
    <div id="divDefectAccessories" style="display: none;">
        <div class="form-group">
            <h4 class="col-lg-3 control-label">Defect Accessories</h4>
        </div>
        <div class="form-group">
            <div class="col-lg-9">
                <table>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkPt100Bearing1" class="control-label" title="Pt 100 Bearing 1" />
                        </td>
                        <td>
                            <label class="control-label">Pt 100 Bearing 1</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkPt100Bearing2" class="control-label" title="Pt 100 Bearing 2" />
                        </td>
                        <td>
                            <label class="control-label">Pt 100 Bearing 2</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkPt100Bearing3" class="control-label" title="Pt 100 Bearing 3" />
                        </td>
                        <td>
                            <label class="control-label">Pt 100 Bearing 3</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkOilLevelsensor" class="control-label" title="Oil Level sensor" />
                        </td>
                        <td>
                            <label class="control-label">Oil Level sensor</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkOilPressures412" class="control-label" title="Oil Pressure (s412)" />
                        </td>
                        <td>
                            <label class="control-label">Oil Pressure (s412)</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkPt100OilSump" class="control-label" title="Pt 100 Oil Sump" />
                        </td>
                        <td>
                            <label class="control-label">Pt 100 Oil Sump</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkFilterIndicator" class="control-label" title="Filter Indicator" />
                        </td>
                        <td>
                            <label class="control-label">Filter Indicator</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkImmersionHeater" class="control-label" title="Immersion Heater" />
                        </td>
                        <td>
                            <label class="control-label">Immersion Heater</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkDrainValve" class="control-label" title="Drain Valve" />
                        </td>
                        <td>
                            <label class="control-label">Drain Valve</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkAirBreather" class="control-label" title="Air Breather" />
                        </td>
                        <td>
                            <label class="control-label">Air Breather</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkSightGlass" class="control-label" title="Sight Glass" />
                        </td>
                        <td>
                            <label class="control-label">Sight Glass</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkChipDetector" class="control-label" title="Chip Detector" />
                        </td>
                        <td>
                            <label class="control-label">Chip Detector</label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="col-lg-11">
            <table>
                <tr>
                    <td>
                        <label class="control-label">Defect Categorization Score : </label>

                    </td>
                    <td>
                        <label id="lblDefectSCategorizationScore" class="control-label"></label>
                    </td>

                </tr>
            </table>
        </div>
    </div>


    <div class="form-group">
        <h4 class="col-lg-3 control-label">Symptoms</h4>
    </div>
    <div class="form-group">
        <div class="col-lg-11">
            <table>
                <tr>
                    <td>
                        <label class="control-label">Vibrations<span class="errorSpan">*</span></label>

                    </td>
                    <td colspan="2">
                        <select id="ddlVibrations" class="form-control ddlvalidation" data-fieldType="select" data-dataTable="Vibrations" data-textField="text" data-valueField="VibrationsID" data-sort="true">
                        </select>
                    </td>
                    <td style="width: 35%;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="control-label">Noise<span class="errorSpan">*</span></label>

                    </td>
                    <td colspan="2">
                        <select id="ddlNoise" class="form-control ddlvalidation" data-fieldType="select" data-dataTable="Noise" data-textField="text" data-valueField="NoiseID" data-sort="true">
                        </select>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="control-label">Debris on Magnet<span class="errorSpan">*</span></label>

                    </td>
                    <td>
                        
                            <select id="ddlDebrisOnMagnet" class="form-control ddlvalidation" data-fieldType="select" data-dataTable="DebrisOnMagnet" data-textField="text" data-valueField="DebrisOnMagnetID" data-sort="true">
                            </select>
                       </td>
                    <td> 
                            <select id="ddlMagnetPos" class="form-control ddlvalidation" data-fieldType="select" data-dataTable="MagnetPos" data-textField="text" data-valueField="MagnetPosID" data-sort="true">
                            </select>
                        
                    </td>
                    <td> 
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="control-label">Debris found in Gearbox<span class="errorSpan">*</span></label>

                    </td>
                    <td colspan="2">
                        <select id="ddlDebrisFoundinGearbox" class="form-control ddlvalidation" data-fieldType="select" data-dataTable="DebrisGearbox" data-textField="text" data-valueField="DebrisGearboxID" data-sort="true">
                        </select>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label class="control-label">Overall Gearbox Condition
                            <a tabindex="0" id="Gearboxhelp" data-html="true"
         data-toggle="popover" data-trigger="hover" title="Help for Overall Gearbox Condition:" data-content="*See INS 0022-7865 in DMS for more information<br/>A <b><u>Category 1</u></b> is indicative of a normal gearbox condition.  This may include manufacturing marks that do not affect the performance of the gearbox nor require any further actions.  It is recommended that the turbine be placed in RUN status as no further actions are required.  <br />A <b><u>Category 2</u></b> demonstrates indications of minor gearbox damage and wear. These signs do not affect the performance of the gearbox in their current state but should be documented in a CIR for tracking purposes.<br />A <b><u>Category 3</u></b> demonstrates indications of advanced gearbox damage or wear. The submittal of a CIR is required for engineering monitoring and potential further recommendations. <br />A <b><u>Category 4</u></b> implies that damage in the gearbox has advanced to potential failure. A full gearbox inspection should be conducted as soon as possible to determine the extent of the damage. The engineering department in the local SBU should be consulted to determine whether the turbine is safe to run. <br /> A <b><u>Category 5</u></b> implies that the gearbox has a potentially serious failure that could cause catastrophic failure. Often accompanied by abnormal noise and vibration. A full gearbox inspection should be conducted as soon as possible to investigate the extent of the damage.">
                <img src="../Images/info-icon.png" />
            </a>
                        </label>
                    </td>
                    <td colspan="2">
                        <select id="ddlOverallGearboxCondition" class="form-control" data-fieldType="select" data-dataTable="OverallGearboxCondition" data-textField="text" data-valueField="OverallGearboxConditionID" data-sort="true">
                        </select>
                    </td>
                    <td>  
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkMaxTemperature" class="badge">Click here to insert Max Temperature..</a></label>
    </div>
    <div id="divMaxTemperature" style="display: none;">
        <div class="form-group">
            <h4 class="col-lg-3 control-label">Max Temperature</h4>
        </div>
        <div class="form-group">
            <div class="col-lg-9">
                <table>
                    <tr>
                        <td>
                            <label class="control-label">Reset Date(dd-mm-yy)</label>

                        </td>
                        <td>
                            <input type="text" id="txtDateMaxTemperatureResetDate" placeholder="Reset Date" class="form-control" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label">Bearing 1</label>

                        </td>
                        <td>
                            <input type="text" id="txtBearing1" placeholder="Bearing 1" class="form-control" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label">Bearing 2</label>

                        </td>
                        <td>
                            <input type="text" id="txtBearing2" placeholder="Bearing 2" class="form-control" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label">Bearing 3</label>

                        </td>
                        <td>
                            <input type="text" id="txtBearing3" placeholder="Bearing 3" class="form-control" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label class="control-label">Oil Sump</label>

                        </td>
                        <td>
                            <input type="text" id="txtOilSump" placeholder="Oil Sump" class="form-control" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkLeakageDroplets" class="badge">Click here to insert presence of leakage or droplets in gearbox..</a></label>
    </div>
    <div id="divLeakageDroplets" style="display: none;">
        <div class="form-group">
            <h4 class="col-lg-3 control-label">Leakage /Droplets</h4>
        </div>
        <div class="form-group">
            <div class="col-lg-9">
                <table>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkLSSNREnd" class="control-label" title="LSS NR-end" />
                        </td>
                        <td>
                            <label class="control-label">LSS NR-end</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkIMSNREnd" class="control-label" title="IMS NR-end" />
                        </td>
                        <td>
                            <label class="control-label">IMS NR-end</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkIMSREnd" class="control-label" title="IMS R-end" />
                        </td>
                        <td>
                            <label class="control-label">IMS R-end</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkHSSNREnd" class="control-label" title="HSS NR-end" />
                        </td>
                        <td>
                            <label class="control-label">HSS NR-end</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkHSSREnd" class="control-label" title="HSS R-end" />
                        </td>
                        <td>
                            <label class="control-label">HSS R-end</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkPitchTube" class="control-label" title="Pitch Tube" />
                        </td>
                        <td>
                            <label class="control-label">Pitch Tube</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkSpliLines" class="control-label" title="Split Lines" />
                        </td>
                        <td>
                            <label class="control-label">Split Lines</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkHoseandPiping" class="control-label" title="Hose and Piping" />
                        </td>
                        <td>
                            <label class="control-label">Hose and Piping</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkInputShaft" class="control-label" title="Input Shaft" />
                        </td>
                        <td>
                            <label class="control-label">Input Shaft</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="checkbox" id="chkAuxHSSPTO" class="control-label" title="Aux. - HSS/PTO" />
                        </td>
                        <td>
                            <label class="control-label">Aux. - HSS/PTO</label>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkGearboxDataPrev" class="btn btn-primary">Previous</a>
            <a href="javascript:void(0);" id="linkGearboxDataNext" class="btn btn-primary">Next</a>
        </div>
    </div>
    <input type="hidden" id="hdnGearTypeDamageDecision" value="" />
</fieldset>

<script type="text/javascript">


    $("select").change(function () {


        var id = (this).id;
        if (id == "ddlDamageClass1" || id == "ddlDamageClass2" || id == "ddlDamageClass3" || id == "ddlDamageClass4" || id == "ddlDamageClass5" ||
            id == "ddlDamageClass6" || id == "ddlDamageClass7" || id == "ddlDamageClass8" || id == "ddlDamageClass9" || id == "ddlDamageClass10" ||
            id == "ddlDamageClass11" || id == "ddlDamageClass12" || id == "ddlDamageClass13" || id == "ddlDamageClass14" || id == "ddlDamageClass15" ||
            id == "ddlPlanetStage1" || id == "ddlPlanetStage2" || id == "ddlHelicalParallelStage" || id == "ddlFrontPlate" ||
            id == "ddlAuxlliaryStage" || id == "ddlHSStage" || id == "ddlGearboxShaftsExactLocation1ShaftTypeId" || id == "ddlGearboxShaftsExactLocation2ShaftTypeId" ||
            id == "ddlGearboxShaftsExactLocation3ShaftTypeId" || id == "ddlGearboxShaftsExactLocation4ShaftTypeId" ||
            id == "ddlDecision1" || id == "ddlDecision2" || id == "ddlDecision3" || id == "ddlDecision4" || id == "ddlDecision5" ||
            id == "ddlDecision6" || id == "ddlDecision7" || id == "ddlDecision8" || id == "ddlDecision9" || id == "ddlDecision10" ||
            id == "ddlDecision11" || id == "ddlDecision12" || id == "ddlDecision13" || id == "ddlDecision14" || id == "ddlDecision15"
            ) {

            CalculateTotalPercentage();
        }


    })
    function CalculateTotalPercentage() {
        var totalPercentage = 0
        var value = $('#hdnGearTypeDamageDecision').val();
        GearTypeDamageDecisionData = JSON.parse(value);

        for (var elementCount = 1; elementCount <= 15; elementCount++) {
            var exLocVal = $('#ddlExactLocation' + elementCount).val();
            // var exLocVal = $('#ddlExactLocation' + elementCount).text();
            var exactLocation = 0;
            if (parseInt(exLocVal) >= 0) {
                exactLocation = parseInt(exLocVal);
            }
            var deciVal = $('#ddlDecision' + elementCount).val();
            //var deciVal = $('#ddlDecision' + elementCount).text();
            var decision = 0;
            if (parseInt(deciVal) >= 0) {
                decision = parseInt(deciVal);
            }
            for (var eCount = 0; eCount < GearTypeDamageDecisionData.length; eCount++) {
                var d = GearTypeDamageDecisionData[eCount].gearTypeDamageDecisionText;
                var s = d.split(',');
                if (((s[0] == exactLocation) && (s[1] == decision)))
                    totalPercentage = totalPercentage + parseFloat(s[2]);
            }

        }
        if (totalPercentage > 0) {
            totalPercentage = totalPercentage + parseFloat("38.13");
        }
        var planetStage1 = $("#ddlPlanetStage1").val();
        var planetStage2 = $("#ddlPlanetStage2").val();
        var helicalStage = $("#ddlHelicalParallelStage").val();
        var frontPlate = $("#ddlFrontPlate").val();
        var auxStage = $("#ddlAuxlliaryStage").val();
        var hSStage = $("#ddlHSStage").val();
        if (planetStage1 == "1" || planetStage1 == "2" ||
            planetStage2 == "1" || planetStage2 == "2" ||
            helicalStage == "1" || helicalStage == "2" ||
            frontPlate == "1" || frontPlate == "2" ||
            auxStage == "1" || auxStage == "2" || hSStage == "1" || hSStage == "2") {
            totalPercentage = totalPercentage + parseFloat("23.99");
        }


        var ShaftLocation1 = $("#ddlGearboxShaftsExactLocation1ShaftTypeId").val();
        var ShaftLocation2 = $("#ddlGearboxShaftsExactLocation2ShaftTypeId").val();
        var ShaftLocation3 = $("#ddlGearboxShaftsExactLocation3ShaftTypeId").val();
        var ShaftLocation4 = $("#ddlGearboxShaftsExactLocation4ShaftTypeId").val();
        if (((ShaftLocation1 == "13") || ((ShaftLocation2 == "13") || ((ShaftLocation3 == "13") || (ShaftLocation4 == "13"))))) {
            totalPercentage = totalPercentage + parseFloat("12.37");
        }

        if (((ShaftLocation1 == "4") || ((ShaftLocation2 == "4") || ((ShaftLocation3 == "4") || (ShaftLocation4 == "4"))))) {
            totalPercentage = totalPercentage + parseFloat("6.04");
        }



        var score = "";
        if (totalPercentage < 50)
            score = "A";
        else if (totalPercentage < 65)
            score = "B";
        else if (totalPercentage < 80)
            score = "C";
        else
            score = "D";
        $("#lblDefectSCategorizationScore").text(score);

    }
</script>
