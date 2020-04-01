<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <legend>SkiiP - Pack data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Number of Components</label>
        <div class="col-lg-9">
            <select id="ddlNumberOfComponentsSkiip" class="form-control">
                <option value="0">0</option>
                <option value="1">1</option>
                <option value="2">2</option>
                <option value="3">3</option>
                <option value="4">4</option>
                <option value="5">5</option>
                <option value="6">6</option>
                <option value="7">7</option>
                <option value="8">8</option>
                <option value="9">9</option>
            </select>
        </div>
    </div>
    <div id="divComponentIdentification1" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumber1" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiip1" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiip1" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentification2" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumber2" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiip2" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiip2" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentification3" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumber3" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiip3" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiip3" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentification4" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumber4" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiip4" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiip4" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentification5" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumber5" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiip5" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiip5" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentification6" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumber6" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiip6" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiip6" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentification7" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumber7" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiip7" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiip7" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentification8" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumber8" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiip8" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiip8" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentification9" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumber9" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiip9" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiip9" placeholder="Item No" />
            </div>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>Replacements</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Other Damaged Components Replaced</label>
        <div class="col-lg-9">
            <textarea id="txtOtherDamagedComponentsReplaced" class="form-control" placeholder="Other Damaged Components Replaced"></textarea>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">New Modules Installed</label>
    </div>
    <div id="divComponentIdentificationNew1" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumberNew1" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiipNew1" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiipNew1" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentificationNew2" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumberNew2" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiipNew2" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiipNew2" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentificationNew3" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumberNew3" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiipNew3" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiipNew3" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentificationNew4" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumberNew4" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiipNew4" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiipNew4" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentificationNew5" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumberNew5" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiipNew5" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiipNew5" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentificationNew6" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumberNew6" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiipNew6" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiipNew6" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentificationNew7" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumberNew7" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiipNew7" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiipNew7" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentificationNew8" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumberNew8" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiipNew8" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiipNew8" placeholder="Item No" />
            </div>
        </div>
    </div>
    <div id="divComponentIdentificationNew9" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Component Identification</label>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtSerialNumberNew9" placeholder="Serial Number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Vestas Unique Identifier<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtVestasUniqueIdentifierSkiipNew9" placeholder="Vestas Unique Identifier" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Item No.<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="txtItemNoSkiipNew9" placeholder="Item No" />
            </div>
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>Failure Descriptions</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Cause<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlCauseSkiip" class="form-control" data-fieldType="select" data-dataTable="SkiipackFailureCause" data-textField="text" data-valueField="SkiipackFailureCauseID">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Quantity of Failed Modules<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtQuantityOfFailedModulesSkiip" class="form-control numbersOnly" placeholder="Quantity of Failed Modules" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-9 control-label">SkiiP - Pack as seen from the front (choose the relevant Skiipack placements)</label>
    </div>
</fieldset>
<fieldset>
    <legend>WTG Platform</legend>
    <!--<div class="form-group">
        <label class="col-lg-3 control-label">WTG Platform</label>
        <div class="col-lg-9">
            <select id="ddlWTGPlatform" class="form-control">
                <option value="0">Select WTG Platform</option>
                <option value="1">2MW</option>
                <option value="2">3MW</option>
                <option value="3">850kW</option>
            </select>
        </div>
    </div>-->
    <fieldset>
    <legend>2MW</legend>
        <div id="WTGdiv1" class="form-group">
        <table class="col-lg-10">
            <tr>
                <td>
                    <label>7.30.030 V521</label>
                    <div>
                        <select id="ddl2MWV521" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.040 V524</label>
                    <div>
                        <select id="ddl2MWV524" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.050 V522</label>
                    <div>
                        <select id="ddl2MWV522" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.060 V525</label>
                    <div>
                        <select id="ddl2MWV525" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.070 V523</label>
                    <div>
                        <select id="ddl2MWV523" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.080 V526</label>
                    <div>
                        <select id="ddl2MWV526" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
            </tr>
        </table>
    </div>
        </fieldset>    
    <fieldset>
    <legend>3MW</legend>
        <div id="WTGdiv2" class="form-group" >
        <table class="col-lg-10">
            <tr>
                <td>
                    <label>7.30.090 V524y</label>
                    <div>
                        <select id="ddl3MWV524y" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.100 V524x</label>
                    <div>
                        <select id="ddl3MWV524x" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.110 V521</label>
                    <div>
                        <select id="ddl3MWV521" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.120 V525y</label>
                    <div>
                        <select id="ddl3MWV525y" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.130 V525x</label>
                    <div>
                        <select id="ddl3MWV525x" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.140 V522</label>
                    <div>
                        <select id="ddl3MWV522" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <label>7.30.150 V526y</label>
                    <div>
                        <select id="ddl3MWV526y" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.160 V526x</label>
                    <div>
                        <select id="ddl3MWV526x" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.170 V523</label>
                    <div>
                        <select id="ddl3MWV523" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
        </fieldset>
    <fieldset>
    <legend>850kW</legend>
        <div id="WTGdiv3" class="form-group" >       
        <table class="col-lg-10">
            <tr>
                <td>
                    <label>7.30.180 V525</label>
                    <div>
                        <select id="ddl850kWV525" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.190 V526</label>
                    <div>
                        <select id="ddl850kWV526" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.200 V524</label>
                    <div>
                        <select id="ddl850kWV524" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td>
                    <label>7.30.210 V520</label>
                    <div>
                        <select id="ddl850kWV520" class="form-control">
                            <option value="0"></option>
                            <option value="1">NO</option>
                            <option value="2">YES</option>
                        </select>
                    </div>
                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </div>
        </fieldset>
    
    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkSkiipackDataPrev" class="btn btn-primary">Previous</a>
            <a href="javascript:void(0);" id="linkSkiipackDataNext" class="btn btn-primary">Next</a>
        </div>
    </div>
</fieldset>
