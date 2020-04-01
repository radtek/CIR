<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <legend>Transformer Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Manufacturer<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTransformerManufacturer2" class="form-control" data-fieldType="select" data-dataTable="TransformerManufacturer" data-textField="text" data-valueField="TransformerManufacturerID">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Serial Number<span class="errorSpan">*</span><a tabindex="0" data-html="true" data-toggle="popover" data-trigger="hover"
             title="Serial No:" data-content="SGB: typically 6 digits like 123456<br/> France Transfo:Typically 8 digits like 123456-78 <br />ABB: Old resiblock transformers: 12345-5678/123. <br /> Cast Resin transformers: Typically 9 digits like 1ABC23456 <br />Siemens: typically 7 digits like A123456">
             <img src="../Images/info-icon.png" /> </a></label>
        <div class="col-lg-9">
            <input type="text" id="txtTransformerSerialNumber" placeholder="Serial Number" class="form-control"/>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Aux. equipment<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTransformerAuxEquipment" class="form-control">
                <option value="1">NO</option>
                <option value="2">YES</option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Max. transformer temp. (ºC)<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtTransformerMaxTemp" placeholder="Max. transformer temp. (ºC)" class="form-control numbersOnly" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Max. transformer temp. reset date<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtTransformerMaxTempDate" placeholder="Max. transformer temp. reset date " class="form-control" />
        </div>
    </div>
</fieldset>

<fieldset>
    <legend>Transformer Inspection Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Action to be taken on the transformer<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlActionToTransformer" class="form-control" data-fieldType="select" data-dataTable="ActionOnTransformer" data-textField="text" data-valueField="ActionOnTransformerID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">HV coil<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTransformerHVCoil" class="form-control" data-fieldType="select" data-dataTable="CoilCondition" data-textField="text" data-valueField="CoilConditionID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">LV coil<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTransformerLVCoil" class="form-control" data-fieldType="select" data-dataTable="CoilCondition" data-textField="text" data-valueField="CoilConditionID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">HV cable<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTransformerHVCable" class="form-control" data-fieldType="select" data-dataTable="CableCondition" data-textField="text" data-valueField="CableConditionID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">LV cable<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTransformerLVCable" class="form-control" data-fieldType="select" data-dataTable="CableCondition" data-textField="text" data-valueField="CableConditionID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Brackets<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTransformerBrackets" class="form-control" data-fieldType="select" data-dataTable="Brackets" data-textField="text" data-valueField="BracketsID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Arc detection<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTransformerArcDetection" class="form-control"  data-fieldType="select" data-dataTable="ArcDetection" data-textField="text" data-valueField="ArcDetectionID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Climate Condition<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTransformerClimateCondition" class="form-control"  data-fieldType="select" data-dataTable="Climate" data-textField="text" data-valueField="ClimateID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Surge arrestor<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTransformerSurgeArrestor" class="form-control"  data-fieldType="select" data-dataTable="SurgeArrestor" data-textField="text" data-valueField="SurgeArrestorID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Connection bars<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlTransformerConnectionBars" class="form-control"  data-fieldType="select" data-dataTable="ConnectionBars" data-textField="text" data-valueField="ConnectionBarsID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Comments</label>
        <div class="col-lg-9">
            <textarea id="txtTransformerComments" class="form-control" placeholder="Comments"></textarea>
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkTransformerDataPrev" class="btn btn-primary">Previous</a>
            <a href="javascript:void(0);" id="linkTransformerDataNext" class="btn btn-primary">Next</a>
        </div>
    </div>
</fieldset>
