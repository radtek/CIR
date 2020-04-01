<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<fieldset>
    <legend>Generator Data</legend>

    <div class="form-group">
        <label class="col-lg-3 control-label">Manufacturer<span class="errorSpan">*</span> </label>
        <div class="col-lg-9">
            <select id="ddlGeneratorManufacturer2" class="form-control ddlvalidation" data-toggle="tooltip" 
                data-placement="top" title="Select Manufacturer" data-fieldType="select" data-dataTable="GeneratorManufacturer" data-textField="text" data-valueField="GeneratorManufacturerID" data-sort="true" >
            </select>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span><a tabindex="1"  data-toggle="popover" data-trigger="hover"
             title="Generator Serial Number:" data-html="true" data-content="Weier/VND: 6 digit number like 123456<br />
Siemens: 6 digits number like 123456<br />
ABB: 7 digit number like 1234567 or 11 digit number like 1234-1234567<br />
 Leroy Somer: Can be either a 10 or 12 digit number. 600 – 2000 kW generators are typically like 123456 78AB90. <br />
3,0 MW generators are typically 123456AB78<br />
Elin: Typically 11 or 12 digits like: 123456A-12345 or 123456-12345<br />
Loher/Winergy: Typically 7 digits like 1234567">
             <img src="../Images/info-icon.png" /> </a></label>
        <div class="col-lg-9">
            <input type="text" id="txtGeneratorSearialNo" placeholder="Serial Number" data-toggle="tooltip" 
                data-placement="top" title="Enter Numeric Serial Number"  class="form-control" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Aux. equipment<span class="errorSpan">*</span><a tabindex="0" id="Reporhelp" data-toggle="popover" data-trigger="hover" 
            title="Aux. Equipment(failure reports only):" data-html="true" data-content="Select yes if the item is an aux. equipment mounted on the main component e.g :
- Auto lubrication unit
- Slibrings <br />
 Select no if the item is e.g:
-  bearings. ">
             <img src="../Images/info-icon.png" /> </a> </label>
        <div class="col-lg-9">
            <select id="ddlGeneratorAuxEquipment" class="form-control" data-toggle="tooltip" 
                data-placement="top" title="Select Aux. equipment" >
                <option value="1">NO</option>
                <option value="2">YES</option>
            </select>
        </div>
    </div>
  
     <div class="form-group">
        <label class="col-lg-3 control-label">Other Manufacturer Name<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtOtherManufacturerName"  class="form-control" disabled placeholder="Other Manufacturer Name" data-toggle="tooltip" 
                data-placement="top" title="Enter Other Manufacturer Name"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Max. Generator Temp. (ºC)<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtGeneratorMaxTemp" placeholder="Max. Generator Temp. (ºC)" data-toggle="tooltip" 
                data-placement="top" title="Enter Max. Generator Temp" class="form-control decimalsOnly" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Max. Gen. Temp. Reset Date<span class="errorSpan">*</span></label>
        <div class="col-lg-9">        
               <input type="text" id="txtGeneratorMaxTempResetDate" placeholder="Max. Gen. Temp. Reset Date" data-toggle="tooltip" data-placement="top" title="Enter Max. Gen Temp." maxlength="10" class="form-control ddlvalidation" style="background-color:#fff" readonly="readonly" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Coupling<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlGeneratorCoupling" class="form-control ddlvalidation" data-toggle="tooltip" 
                data-placement="top" title="Select Coupling" data-fieldType="select" data-dataTable="Coupling" data-textField="text" data-valueField="CouplingID" data-sort="true">
            </select>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>Generator Inspection Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Action to be taken on the generator <span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlGeneratorActionToBeTaken" class="form-control ddlvalidation" data-toggle="tooltip" 
                data-placement="top" title="Select Action" data-fieldType="select" data-dataTable="ActionToBeTakenOnGenerator" data-textField="text" data-valueField="ActionToBeTakenOnGeneratorID" data-sort="true">
            </select>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>Mechanical Condition of the Generator</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Drive End<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlGeneratorDriveEnd" class="form-control ddlvalidation" data-toggle="tooltip" 
                data-placement="top" title="Select Mechnical Condition" data-fieldType="select" data-dataTable="GeneratorDriveEnd" data-textField="text" data-valueField="GeneratorDriveEndID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Non-Drive End<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlGeneratorNonDriveEnd" class="form-control ddlvalidation" data-toggle="tooltip" 
                data-placement="top" title="Select Non-Drive End" data-fieldType="select" data-dataTable="GeneratorNonDriveEnd" data-textField="text" data-valueField="GeneratorNonDriveEndID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Rotor<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlGeneratorRotor" class="form-control ddlvalidation" data-toggle="tooltip" 
                data-placement="top" title="Select Rotor" data-fieldType="select" data-dataTable="GeneratorRotor" data-textField="text" data-valueField="GeneratorRotorID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Cover<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlGeneratorCover" class="form-control ddlvalidation" data-toggle="tooltip" 
                data-placement="top" title="Select Cover" data-fieldType="select" data-dataTable="GeneratorCover" data-textField="text" data-valueField="GeneratorCoverID" data-sort="true">
            </select>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>Condition of the Air to Air Cooler</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Internal</label>
        <div class="col-lg-9">
            <select id="ddlGeneratorConditionInternal" class="form-control ddlvalidation" data-fieldType="select" data-dataTable="AirToAirCoolerInternal" data-textField="text" data-valueField="AirToAirCoolerInternalID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">External</label>
        <div class="col-lg-9">
            <select id="ddlGeneratorConditionExternal" class="form-control ddlvalidation" data-fieldType="select" data-dataTable="AirToAirCoolerExternal" data-textField="text" data-valueField="AirToAirCoolerExternalID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Comments</label>
        <div class="col-lg-9">
            <textarea id="txtGeneratorComments" class="form-control" placeholder="Comments"></textarea>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>Insulation/Induction Test Data not relevant</legend>
    <div class="form-group">
        <label for="chkInsulationComments" class="col-lg-3 control-label">Insulation/Induction Test Data not relevant</label>
        <div class="col-lg-9">
            <input type="checkbox" id="chkInsulationComments" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Comments<span class="errorSpan errorSpanGentrComments">*</span></label>
        <div class="col-lg-9">
            <textarea id="txtGeneratorInsulationComments" class="form-control" placeholder="Comments" title="Comments required if Insulation/Induction Test Data not relevant"></textarea>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>Insulation Test Data - Minimum 1000V Test Voltage</legend>
    <div class="form-group">
        <h4 class="col-lg-3 control-label">Stator Winding</h4>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">U - Ground<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="text" id="txtGeneratorTestResultUGround" class="form-control decimalsOnly" data-toggle="tooltip" 
                data-placement="top" title="Enter U - Ground" placeholder="Enter Test Result"   /></td>
                    <td>
                        <select id="ddlGeneratorTestResultUGroundUnit" class="form-control ex_valid ddlvalidation" data-fieldType="select" data-dataTable="OhmUnit" data-textField="text" data-valueField="OhmUnitID" data-sort="true">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">W - Ground<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="text" id="txtGeneratorTestResultWGround" data-toggle="tooltip" 
                data-placement="top" class="form-control  decimalsOnly"  title="Enter W - Ground" placeholder="Enter Test Result"  /></td>
                    <td>
                        <select id="ddlGeneratorTestResultWGroundUnit" class="form-control ex_valid ddlvalidation" data-fieldType="select" data-dataTable="OhmUnit" data-textField="text" data-valueField="OhmUnitID" data-sort="true">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">V - Ground<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="text" id="txtGeneratorTestResultVGround" data-toggle="tooltip" 
                data-placement="top" class="form-control  decimalsOnly"  title="Enter V - Ground" placeholder="Enter Test Result"  /></td>
                    <td>
                        <select id="ddlGeneratorTestResultVGroundUnit" class="form-control ex_valid ddlvalidation" data-fieldType="select" data-dataTable="OhmUnit" data-textField="text" data-valueField="OhmUnitID" data-sort="true">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">U - V<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="text" id="txtGeneratorTestResultUV" data-toggle="tooltip" 
                data-placement="top" class="form-control  decimalsOnly" title="Enter U - V" placeholder="Enter Test Result"  /></td>
                    <td>
                        <select id="ddlGeneratorTestResultUVUnit" class="form-control ex_valid ddlvalidation" data-fieldType="select" data-dataTable="OhmUnit" data-textField="text" data-valueField="OhmUnitID" data-sort="true">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">U - W<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="text" id="txtGeneratorTestResultUW" data-toggle="tooltip" 
                data-placement="top" class="form-control  decimalsOnly"  title="Enter U - W" placeholder="Enter Test Result"  /></td>
                    <td>
                        <select id="ddlGeneratorTestResultUWUnit" class="form-control ex_valid ddlvalidation" data-fieldType="select" data-dataTable="OhmUnit" data-textField="text" data-valueField="OhmUnitID" data-sort="true">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">V - W<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="text" id="txtGeneratorTestResultVW" data-toggle="tooltip" 
                data-placement="top" class="form-control  decimalsOnly"  title="Enter V - W" placeholder="Enter Test Result"  /></td>
                    <td>
                        <select id="ddlGeneratorTestResultVWUnit" class="form-control ex_valid ddlvalidation" data-fieldType="select" data-dataTable="OhmUnit" data-textField="text" data-valueField="OhmUnitID" data-sort="true">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <h4 class="col-lg-3 control-label">Rotor Winding</h4>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">K - Ground<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="text" id="txtGeneratorTestResultKGround" data-toggle="tooltip" 
                data-placement="top" class="form-control  decimalsOnly"  title="Enter K - Ground" placeholder="Enter Test Result"  /></td>
                    <td>
                        <select id="ddlGeneratorTestResultKGroundUnit" class="form-control ex_valid ddlvalidation" data-fieldType="select" data-dataTable="OhmUnit" data-textField="text" data-valueField="OhmUnitID" data-sort="true">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">L - Ground<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="text" id="txtGeneratorTestResultLGround" data-toggle="tooltip" 
                data-placement="top"   title="Enter L - Ground" placeholder="Enter Test Result" class="form-control decimalsOnly " /></td>
                    <td>
                        <select id="ddlGeneratorTestResultLGroundUnit" class="form-control ex_valid ddlvalidation" data-fieldType="select" data-dataTable="OhmUnit" data-textField="text" data-valueField="OhmUnitID" data-sort="true">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">M - Ground<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <input type="text" id="txtGeneratorTestResultMGround" data-toggle="tooltip" 
                data-placement="top" class="form-control  decimalsOnly"  title="Enter M - Ground values"  placeholder="Enter Test Result"  /></td>
                    <td>
                        <select id="ddlGeneratorTestResultMGroundUnit" class="form-control ex_valid  ddlvalidation" data-fieldType="select" data-dataTable="OhmUnit" data-textField="text" data-valueField="OhmUnitID" data-sort="true">
                        </select>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</fieldset>

<fieldset>
    <legend>Inductance Test Data (Motor Test)</legend>
    <div class="form-group">
        <h4 class="col-lg-3 control-label">Stator Winding</h4>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">U1 - U2 (%)<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtGeneratorInductanceTestU1U2" data-toggle="tooltip" 
                data-placement="top" title="Enter U1 - U2 values"  placeholder="Enter Result Of Measurement" class="form-control numbersOnly ddlvalidation" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">V1 - V2 (%)<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtGeneratorInductanceTestV1V2" data-toggle="tooltip" 
                data-placement="top"  placeholder="Enter Result Of Measurement" title="Enter V1 - V2 values"   class="form-control numbersOnly ddlvalidation" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">W1 - W2 (%)<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtGeneratorInductanceTestW1W2" data-toggle="tooltip" 
                data-placement="top" placeholder="Enter Result Of Measurement" title="Enter W1 - W2 values"   class="form-control numbersOnly ddlvalidation" />
        </div>
    </div>
    <div class="form-group">
        <h4 class="col-lg-3 control-label">Rotor Winding</h4>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">K1 - L1 (%)<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtGeneratorInductanceTestK1L1" data-toggle="tooltip" 
                data-placement="top" placeholder="Enter Result Of Measurement" title="Enter K1 - L1 values"  class="form-control numbersOnly ddlvalidation" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">L1 - M1(%)<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtGeneratorInductanceTestL1M1" data-toggle="tooltip" 
                data-placement="top"   placeholder="Enter Result Of Measurement" title="Enter L1 - M1 values"   class="form-control numbersOnly ddlvalidation" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">K1 - M1(%)<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtGeneratorInductanceTestK1M1" data-toggle="tooltip" 
                data-placement="top" placeholder="Enter Result Of Measurement" title="Enter K1 - M2 values"  class="form-control numbersOnly ddlvalidation" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">K2 - L2 (%)<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtGeneratorInductanceTestK2L2"  data-toggle="tooltip" 
                data-placement="top" placeholder="Enter Result Of Measurement" title="Enter K2 - L2 values" class="form-control numbersOnly ddlvalidation" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">L2 - M2(%)<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtGeneratorInductanceTestL2M2" data-toggle="tooltip" 
                data-placement="top" title="Enter L2 - M2 values"   placeholder="Enter Result Of Measurement" class="form-control numbersOnly ddlvalidation" />
        </div>
    </div>
    <div class="form-group">
        <!--Added by Siddharth Chauhan on 27-05-2016, as it is mandatory field validation is implemented in Cir.js, so added Required * mark-->
        <label class="col-lg-3 control-label">K2 - M2(%)<span class="errorSpan errorSpanGentr">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtGeneratorInductanceTestK2M2" data-toggle="tooltip" 
                data-placement="top" title="Enter K2 - M2 values"   placeholder="Enter Result Of Measurement" class="form-control numbersOnly ddlvalidation" />
        </div>
    </div>
    <div class="form-group">
        <label for="chkGeneratorRewound" class="col-lg-3 control-label">Generator rewound locally</label>
        <div class="col-lg-9">
            <input type="checkbox" id="chkGeneratorRewound" />
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkGeneratorDataPrev" class="btn btn-primary">Previous</a>
            <a href="javascript:void(0);" id="linkGeneratorDataNext" class="btn btn-primary">Next</a>
        </div>
    </div>
</fieldset>
 
<script type="text/javascript">
 
$(document).ready(function() {
    $('#ddlGeneratorManufacturer2').change(function () {
        
        if ($(this).val() == 5)
            $('#txtOtherManufacturerName').prop('disabled', false);
        else {
            $('#txtOtherManufacturerName').val('');
            $('#txtOtherManufacturerName').prop('disabled', true);
        }
    });
  
});
 
</script>
