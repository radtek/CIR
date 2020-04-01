<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <legend>Blade Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Manufacturer<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlBladeManufacturer" class="form-control ddlvalidation" data-toggle="tooltip" data-placement="top" title="Enter Blade Manufacturer" data-fieldType="select" data-dataTable="BladeManufacturer" data-textField="text" data-valueField="BladeManufacturerID">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Length (m)<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlBladeLengthM" class="form-control ddlvalidation" data-toggle="tooltip" data-placement="top" title="Enter Blade Length" data-fieldType="select" data-dataTable="BladeLength" data-textField="text" data-valueField="BladeLengthID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Color<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlBladeColor" class="form-control ddlvalidation" data-toggle="tooltip" data-placement="top" title="Enter Blade Color"  data-fieldType="select" data-dataTable="BladeColor" data-textField="text" data-valueField="BladeColorID" data-sort="true">
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Blade Serial No<span class="errorSpan">*</span> <a tabindex="0" data-html="true" data-toggle="popover" data-trigger="hover"
             title="Blade Serial No:" data-content="Is either a 4-6 digit number. i.e. 2354 or 35854 If the whole batch number is noted it is a 6 digit number-warehouse letter and a 4-6 digit number. i.e. 761003WHBY35964
 <br /><b>
Old NEGMicon blades: </b>
A 4 digit number
 <br /><b>
LM blades: </b>
A letter followed by a number. i.e. E-1234">
             <img src="../Images/info-icon.png" /> </a>  </label>
        <div class="col-lg-9">
            <input type="text" id="txtBladeSerialNo" data-toggle="tooltip" 
                data-placement="top" title="Enter Blade Serial No" placeholder="Blade Serial No" class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Aux. equipment<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlAuxEquipment" class="form-control" data-toggle="tooltip" 
                data-placement="top" title="Aux. equipment" >
                <option value="1">NO</option>
                <option value="2">YES</option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Pictures of the damage included<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlBladePicIncluded" class="form-control" data-toggle="tooltip" 
                data-placement="top" title="Select Pictures of the damage">
                <option value="1">NO</option>
                <option value="2">YES</option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <div class="col-lg-9">
            <a href="javascript:void(0);" id="linkInserOtherBladeSet"  class="badge">Insert other blade in set..</a>
        </div>
    </div>
    <div id="otherBladeSet" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Other blades in set<span class="errorSpan">*</span> </label>
            <div class="col-lg-9">
                <input type="text" id="txtBladeSerialNoOtherBlade" data-toggle="tooltip" 
                data-placement="top" title="Enter serial numbers of other blades set" placeholder="Enter serial numbers of other blades in set if relevant" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label"><span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" id="txtBladeSerialNoOtherBlade2" data-toggle="tooltip" 
                data-placement="top" title="Enter blade serial number consists of 4 to 5 digits" placeholder="A blade serial number consists of 4 to 5 digits" class="form-control" />
            </div>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>Blade Inspection Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Damage Identified</label>
        <input type="checkbox" id="chkDamageIdentified" checked="checked" value="Damage Identified">
    </div>
    <div id="bladeDamageArea">
        <div id="bladeDamageSection" class="bladeDamageSection">
            <h4>Blade Damage</h4>
            <div class="form-group">
                <div class="col-xs-12" style="text-align: right;">
                    <a href="javascript:void(0);"  class="badge linkRemove">Remove</a>
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Damage Placement<span class="errorSpan">*</span></label>
                <div class="col-lg-9">
                    <select id="ddlDamagePlacement" class="form-control ddlvalidation" data-toggle="tooltip" 
                data-placement="top" title="Select Damage Placement" data-fieldType="select" data-dataTable="BladeDamagePlacement" data-textField="text" data-valueField="BladeDamagePlacementID">
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Damage Type<span class="errorSpan">*</span></label>
                <div class="col-lg-9">
                    <select id="ddlDamageType" class="form-control ddlvalidation"  data-toggle="tooltip" 
                data-placement="top" title="Select Damage Type" data-fieldType="select" data-dataTable="BladeInspectionData" data-textField="text" data-valueField="BladeInspectionDataID" data-sort="true">
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Radius (m)<span class="errorSpan">*</span></label>
                <div class="col-lg-9">
                    <input type="text" id="txtBladeRadius" placeholder="Radius (m)" data-toggle="tooltip" 
                data-placement="top" title="Indicate location of damage" class="form-control decimalsOnly " />
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Blade Edge<span class="errorSpan">*</span></label>
                <div class="col-lg-9">
                    <select id="ddlBladeEdge" class="form-control ddlvalidation" data-toggle="tooltip" 
                data-placement="top" title="Select Blade Edge" data-fieldType="select" data-dataTable="BladeEdge" data-textField="text" data-valueField="BladeEdgeID" data-sort="true">
                    </select >
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Description<span class="errorSpan">*</span></label>
                <div class="col-lg-9">
                    <textarea id="txtBladeDamageDescription" placeholder="Damage Description"  data-toggle="tooltip" 
                data-placement="top" title="Enter further description of damage" class="form-control ddlvalidation"></textarea>
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Picture no<span class="errorSpan">*</span></label>
                <div class="col-lg-9">
                    <input type="text" id="txtPictureNo" placeholder="Picture no"  data-toggle="tooltip" 
                data-placement="top" title="Enter number of pictures that shows this damage" class="form-control ddlvalidation" />
                </div>
            </div>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <div class="col-lg-9">
            <a href="javascript:void(0);" id="linkInserBladeDamage" class="badge">Insert more blade damage..</a>
        </div>
    </div>
    <%--<div class="bladeDamageSection">--%>
    <h4>Fault Code</h4>
    <div class="form-group">
        <label class="col-lg-3 control-label">Overall blade condition<span class="errorSpan">*</span><a tabindex="0" id="FaultBladeHelp" data-toggle="popover" 
            data-trigger="hover" title="Inspection:" data-content="Select blade condition">
             <img src="../Images/info-icon.png" /> </a></label>
        <div class="col-lg-9">
            <select id="ddlOverallBladeCondition" class="form-control ddlvalidation"  data-toggle="tooltip" 
                data-placement="top" title="Select Overall blade condition">
                <option value="0"></option>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Cause<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlFaultCause" class="form-control ddlvalidation"  data-toggle="tooltip" 
                data-placement="top" title="Select cause" data-fieldType="select" data-dataTable="FaultCodeCause" data-textField="text" data-valueField="FaultCodeCauseID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Type<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlFaultType" class="form-control"  data-toggle="tooltip" 
                data-placement="top" title="Select Type" data-fieldType="select" data-dataTable="FaultCodeType" data-textField="text" data-valueField="FaultCodeTypeID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Area<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlFaultArea" class="form-control ddlvalidation" data-toggle="tooltip" 
                data-placement="top" title="Select Area" data-fieldType="select" data-dataTable="FaultCodeArea" data-textField="text" data-valueField="FaultCodeAreaID" data-sort="true">
            </select>
        </div>
    </div>
    <div id="bladerepairsection">
    <h4>Blade Repair Record</h4>
     <div class="form-group">
        <label class="col-lg-3 control-label">Ambient temp (°C)<span class="errorSpan">*</span></label>
          
        <div class="col-lg-9">
            <input type="text" id="txtAmbientTemp" placeholder="Enter ambient temperature during repair" data-toggle="tooltip"
                data-placement="top" title="Enter ambient temperature during repair" class="form-control decimalsOnly" />

        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Humidity (%)<span class="errorSpan">*</span></label>
          
        <div class="col-lg-9">
            <input type="text" id="txtHumidity" placeholder="Enter humidity during repair" data-toggle="tooltip"
                data-placement="top" title="Enter humidity during repair" class="form-control decimalsOnly" />

        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Additional document reference</label>
          
        <div class="col-lg-9">
            <input type="text" id="txtAddldocumentref" placeholder="Enter additional document reference" data-toggle="tooltip"
                data-placement="top" title="Enter additional document reference" class="form-control" />

        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Resin type</label>
          
        <div class="col-lg-9">
            <input type="text" id="txtResinType" placeholder="Enter resin type" data-toggle="tooltip"
                data-placement="top" title="Enter resin type" class="form-control"/>

        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Resin type batch number(s)</label>
          
        <div class="col-lg-9">
            <input type="text" id="txtResinTypeBatchNumber" placeholder="Enter resin type batch number(s)" data-toggle="tooltip"
                data-placement="top" title="Enter resin type batch number(s)" class="form-control" />

        </div>
    </div>

     <div class="form-group">
        <label class="col-lg-3 control-label">Resin type expiry date (dd-mm-yyyy)</label>
          
        <div class="col-lg-9">
            <input type="text" id="txtResinTypeexpirydate" placeholder="Choose resin type expiry date" data-toggle="tooltip"
                data-placement="top" title="Choose resin type expiry date" maxlength="10" class="form-control" style="background-color:#fff" readonly="readonly" />

        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Hardener type</label>
          
        <div class="col-lg-9">
            <input type="text" id="txtHardenertype" placeholder="Enter hardener type" data-toggle="tooltip"
                data-placement="top" title="Enter hardener type" class="form-control" />

        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Hardener type batch number(s)</label>
          
        <div class="col-lg-9">
            <input type="text" id="txtHardenertypebatchnumber" placeholder="Enter hardener type batch number(s)" data-toggle="tooltip"
                data-placement="top" title="Enter hardener type batch number(s)" class="form-control" />

        </div>
    </div>
     <div class="form-group">
        <label class="col-lg-3 control-label">Hardener type expiry date (dd-mm-yyyy)</label>
          
        <div class="col-lg-9">
            <input type="text" id="txthardnertypeexpirydate" placeholder="Choose hardener type expiry date" data-toggle="tooltip"
                data-placement="top" title="Choose hardener type expiry date" maxlength="10" class="form-control" style="background-color:#fff" readonly="readonly" />

        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Glass supplier<span class="errorSpan">*</span></label>
          
        <div class="col-lg-9">
            <input type="text" id="txtglasssupplier" placeholder="Enter glass supplier" data-toggle="tooltip"
                data-placement="top" title="Enter glass supplier" class="form-control" />

        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Glass supplier batch number(s)<span class="errorSpan">*</span></label>
          
        <div class="col-lg-9">
            <input type="text" id="txtglasssupplierbatchnumber" placeholder="Enter glass supplier batch number(s)" data-toggle="tooltip"
                data-placement="top" title="Enter glass supplier batch number(s)" class="form-control" />

        </div>
    </div>
    <h5>Blade surface temperature during lamination (°C)</h5>
    <div class="form-group">
        <label class="col-lg-3 control-label">Max<span class="errorSpan">*</span></label>
          
        <div class="col-lg-9">
            <input type="text" id="txtmaxbladesurfacetemp" placeholder="Enter max temp. during lamination" data-toggle="tooltip"
                data-placement="top" title="Enter max temp. during lamination" class="form-control decimalsOnly" />

        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Min<span class="errorSpan">*</span></label>
          
        <div class="col-lg-9">
            <input type="text" id="txtminbladesurfacetemp" placeholder="Enter min. temp. during lamination" data-toggle="tooltip"
                data-placement="top" title="Enter min. temp. during lamination" class="form-control decimalsOnly" />

        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Quantity of mixed resin used (g)<span class="errorSpan">*</span></label>
          
        <div class="col-lg-9">
            <input type="number" id="txtquantityofmixedresinused" placeholder="Enter amount of mixed resin used" data-toggle="tooltip"
                data-placement="top" title="Enter amount of mixed resin used" class="form-control numbersOnly" />

        </div>
    </div>
    <h5>Post cure surface temperature (°C)</h5>
    <div class="form-group">
        <label class="col-lg-3 control-label">Max<span class="errorSpan">*</span></label>
          
        <div class="col-lg-9">
            <input type="text" id="txtmaxpostcuresurfacetemp" placeholder="Enter max post cure surface temp." data-toggle="tooltip"
                data-placement="top" title="Enter max post cure surface temp." class="form-control decimalsOnly" />

        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Min<span class="errorSpan">*</span></label>
          
        <div class="col-lg-9">
            <input type="text" id="txtminpostcuresurfacetemp" placeholder="Enter min post cure surface temp." data-toggle="tooltip"
                data-placement="top" title="Enter min post cure surface temp." class="form-control decimalsOnly" />

        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Heaters, insulation cover and vacuum off (dd-mm-yyyy HH:MM)</label>
          
        <div class="col-lg-9">
            <input type="text" id="txtheaterinsulationandvacuumoff" placeholder="Choose when items were taken off" data-toggle="tooltip"
                data-placement="top" title="Choose when items were taken off" maxlength="10" class="form-control" style="background-color:#fff" readonly="readonly" />

        </div>
        
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Total cure time (hrs)<span class="errorSpan">*</span></label>
          
        <div class="col-lg-9">
            <input type="number" id="txttotalcuretime" placeholder="Enter total cure time" data-toggle="tooltip"
                data-placement="top" title="Enter total cure time" class="form-control numbersOnly" />

        </div>
    </div>
    </div>
    <%--</div>--%>
    <h4>Test of Lightning System</h4>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            VT number
        </label>

        <div class="col-lg-9">
            <input type="number" id="txtVTnumber" placeholder="VT number" data-toggle="tooltip"
                data-placement="top" title="Enter Numeric VT Number" class="form-control numbersOnly" />

        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Calibration date</label>
        <div class="col-lg-9">
            <input type="text" id="txtCalibrationDate" placeholder="Calibration date" data-toggle="tooltip" data-placement="top"  title="Calibration Date" maxlength="10" class="form-control" style="background-color:#fff" readonly="readonly" />
        </div>
    </div>
    
    <div class="form-group">
        <h4 class="col-lg-3 control-label">Receptor Leeward's side</h4>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Tip</label>
       <label class="col-lg-2 control-label">Pre-Repair</label>
        <label class="col-lg-2 control-label">Post-Repair</label>
                    
        
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">1</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtLeewardPreTypeValue1" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtLeewardPostTypeValue1" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
   <div class="form-group">
        <label class="col-lg-3 control-label">2</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtLeewardPreTypeValue2" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtLeewardPostTypeValue2" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">3</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtLeewardPreTypeValue3" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtLeewardPostTypeValue3" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">4</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtLeewardPreTypeValue4" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtLeewardPostTypeValue4" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">5</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtLeewardPreTypeValue5" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtLeewardPostTypeValue5" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">6</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtLeewardPreTypeValue6" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <%--<td data-templateFieldVisibility="show" data-templateFor="5,6,7">--%> <td>
                        <input type="number" id="txtLeewardPostTypeValue6" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
     <div class="form-group">
        <label class="col-lg-3 control-label">7</label>
        <div class="col-lg-9">
            <table>
                <tr><td>
                    <%--<td data-templateFieldVisibility="show" data-templateFor="5,6,7">--%>
                        <input type="number" id="txtLeewardPreTypeValue7" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                 <td>  <%-- <td data-templateFieldVisibility="show" data-templateFor="5,6,7">--%>
                        <input type="number" id="txtLeewardPostTypeValue7" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
     <div class="form-group">
        <label class="col-lg-3 control-label">8</label>
        <div class="col-lg-9">
            <table>
                <tr><td>
                    <%--<td data-templateFieldVisibility="show" data-templateFor="5,6,7">--%>
                        <input type="number" id="txtLeewardPreTypeValue8" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                   <td><%-- <td data-templateFieldVisibility="show" data-templateFor="5,6,7">--%>
                        <input type="number" id="txtLeewardPostTypeValue8" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <h4 class="col-lg-3 control-label">Receptor Windward's side</h4>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Tip</label>
       <label class="col-lg-2 control-label">Pre-Repair</label>
        <label class="col-lg-2 control-label">Post-Repair</label>
                    
        
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">1</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtWindwardPreTypeValue1" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtWindwardPostTypeValue1" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
   <div class="form-group">
        <label class="col-lg-3 control-label">2</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtWindwardPreTypeValue2" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtWindwardPostTypeValue2" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">3</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtWindwardPreTypeValue3" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtWindwardPostTypeValue3" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">4</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtWindwardPreTypeValue4" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtWindwardPostTypeValue4" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">5</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtWindwardPreTypeValue5" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtWindwardPostTypeValue5" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
     <div class="form-group"  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5,6,7" >
        <label class="col-lg-3 control-label">6</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtWindwardPreTypeValue6" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td >
                        <input type="number" id="txtWindwardPostTypeValue6" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
   <div class="form-group"  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5,6,7">
        <label class="col-lg-3 control-label">7</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtWindwardPreTypeValue7" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtWindwardPostTypeValue7" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group"  data-templateFieldVisibility="hide" data-templateFor="1,2,3,4,5,6,7" >
        <label class="col-lg-3 control-label">8</label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="number" id="txtWindwardPreTypeValue8" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" /></td>
                    <td>
                        <input type="number" id="txtWindwardPostTypeValue8" data-toggle="tooltip" 
                data-placement="top" title="Enter Type value (m Ohm)" placeholder="Type value (m Ohm)" class="form-control numbersOnly" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkBladeDataPrev" class="btn btn-primary">Previous</a>
            <a href="javascript:void(0);" id="linkBladeDataNext" class="btn btn-primary">Next</a>
        </div>
    </div>
</fieldset>
