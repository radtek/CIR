<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <legend>General Component Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Component group<span class="errorSpan">*</span><a tabindex="0" data-toggle="popover" 
            data-trigger="hover" title="Help for Position of failed item:" data-html="true" data-content="Relevant for components used more than once in the turbine e.g: <br />
M204 = Hydraulic pitch pump <br />
K58.1 = CT6215, wind sensor A <br />
N/A if not applicable ">
             <img src="../Images/info-icon.png" /> </a></label>
        <div class="col-lg-9">
            <select id="ddlComponentGroup" class="form-control" data-fieldType="select" data-dataTable="ComponentGroup" data-textField="text" data-valueField="ComponentGroupID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Component Type</label>
        <div class="col-lg-9">
            <input type="text" id="txtComponentType" class="form-control" placeholder="Component Type" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Position of failed item<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtPositionOfFailedItem" class="form-control" data-toggle="tooltip" 
                data-placement="top" title="Enter Position of failed item value"  placeholder="Position of failed item" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Component Manufacturer</label>
        <div class="col-lg-9">
            <input type="text" id="txtComponentManufacturer" class="form-control"  placeholder="Component Manufacturer" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkOtherGearboxType" class="badge">Click here to insert other gearbox type..</a></label>
    </div>
    <div id="divOtherGearboxType" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Other Gearbox Type</label>
            <div class="col-lg-9">
                <input type="text" id="txtOtherGearboxType" class="form-control" placeholder="Other Gearbox Type" />
            </div>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Other Gearbox Manufacturer</label>
        <div class="col-lg-9">
            <input type="text" id="txtOtherGearboxManufacturer" class="form-control" placeholder="Other Gearbox Manufacturer" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Component Serial Number<span id="spComponentSerialNumber" class="errorSpan ComponentSerialNumberSection">*</span></label>
        <div class="col-lg-8">
            <input type="text" id="txtComponentSerialNumber" class="form-control"  data-toggle="tooltip" 
                data-placement="top" title="Enter Component Serial Number value"  placeholder="Component Serial Number" />
        </div>
        <div class="col-lg-1">            
            <input type="checkbox" id="chkComponentSerialNumber" class="control-label" title="Component Serial Number" />
             N/A
        </div>
    </div>
</fieldset>
<fieldset>
    <legend>General Additional Component Data</legend>

    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkAdditionalManufacturer" class="badge">Click here to insert additional manufacturer..</a></label>
    </div>

    <div id="divAdditionalManufacturer" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Generator Manufacturer</label>
            <div class="col-lg-9">
                <select id="ddlGeneratorManufacturer" class="form-control" data-fieldType="select" data-dataTable="GeneratorManufacturer" data-textField="text" data-valueField="GeneratorManufacturerID" data-sort="true">
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Transformer Manufacturer</label>
            <div class="col-lg-9">
                <select id="ddlTransformerManufacturer" class="form-control" data-fieldType="select" data-dataTable="TransformerManufacturer" data-textField="text" data-valueField="TransformerManufacturerID">
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Gearbox Manufacturer</label>
            <div class="col-lg-9">
                <select id="ddlGearboxManufacturer" class="form-control" data-fieldType="select" data-dataTable="GearboxManufacturer" data-textField="text" data-valueField="GearboxManufacturerID" data-sort="true">
                </select>
            </div>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkTowerInformation" class="badge">Click here to insert Tower information..</a></label>
    </div>
    <div id="divTowerInformation" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Tower Type</label>
            <div class="col-lg-9">
                <select id="ddlTowerType" class="form-control" data-fieldType="select" data-dataTable="TowerType" data-textField="text" data-valueField="TowerTypeID" data-sort="true">
                </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Tower Height</label>
            <div class="col-lg-9">
                <select id="ddlTowerHeight" class="form-control" data-fieldType="select" data-dataTable="TowerHeight" data-textField="text" data-valueField="TowerHeightID" data-sort="true">
                </select>
            </div>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label"></label>
        <label class="col-lg-3 control-label"><a href="javascript:void(0);" id="linkBladeSlNo" class="badge">Click here to insert Blade serial number..</a></label>
    </div>
    <div id="divBladeSlNo" style="display: none;">
        <div class="form-group">
            <label class="col-lg-3 control-label">Blade A serial number</label>
            <div class="col-lg-9">
                <input type="text" id="txtBladeASerialNumber" class="form-control" placeholder="Blade A serial number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Blade B serial number</label>
            <div class="col-lg-9">
                <input type="text" id="txtBladeBSerialNumber" class="form-control" placeholder="Blade B serial number" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Blade C serial number</label>
            <div class="col-lg-9">
                <input type="text" id="txtBladeCSerialNumber" class="form-control" placeholder="Blade C serial number" />
            </div>
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Controller Type</label>
        <div class="col-lg-9">
            <select id="ddlControllerType" class="form-control" data-fieldType="select" data-dataTable="ControllerType" data-textField="text" data-valueField="ControllerTypeID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Software Release</label>
        <div class="col-lg-9">
            <input type="text" id="txtSoftwareRelease" class="form-control" placeholder="Software Release" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Ram Dump Number</label>
        <div class="col-lg-9">
            <input type="number" id="txtRamDumpNumber" class="form-control numbersOnly" placeholder="Ram Dump Number" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">VDF Track Number</label>
        <div class="col-lg-9">
            <input type="text" id="txtVDFTrackNumber" class="form-control" placeholder="VDF Track Number" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Pictures Attached?</label>
        <div class="col-lg-9">
            <select id="ddlPicturesAttached" class="form-control">
                <option value="1">NO</option>
                <option value="2">YES</option> 
            </select>
        </div>
    </div>
</fieldset>

<fieldset>
    <legend>General Component Inspection Data</legend>
    <div class="form-group">
        <div class="col-lg-9">
            <table class="col-lg-9">
                <tr>
                    <td>
                        <label class="control-label" id="lblTemplate1">Initiated By</label>
                    </td>
                    <td>
                        <label class="control-label" id="lblTemplate2">Measurements / Examinations Conducted</label>
                    </td>
                    <td>
                        <label class="control-label" id="lblTemplate3">Executed By</label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="txtInitiatedBy1" class="form-control" />
                    </td>
                    <td>
                        <input type="text" id="txtMeasurements1" class="form-control" />
                    </td>
                    <td>
                        <input type="text" id="txtExecutedBy1" class="form-control" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="txtInitiatedBy2" class="form-control" />
                    </td>
                    <td>
                        <input type="text" id="txtMeasurements2" class="form-control" />
                    </td>
                    <td>
                        <input type="text" id="txtExecutedBy2" class="form-control" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="text" id="txtInitiatedBy3" class="form-control" />
                    </td>
                    <td>
                        <input type="text" id="txtMeasurements3" class="form-control" />
                    </td>
                    <td>
                        <input type="text" id="txtExecutedBy3" class="form-control" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkGeneralDataPrev" class="btn btn-primary">Previous</a>
            <a href="javascript:void(0);" id="linkGeneralDataNext" class="btn btn-primary">Next</a>
        </div>
    </div>
</fieldset>
