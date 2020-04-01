<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<fieldset>
    <legend>Basic CIR Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            CIM Case Number<span class="errorSpan">*</span>
        </label>

        <div class="col-lg-9">
            <input maxlength="8" id="txtCimNo_Flang"  data-toggle="tooltip"
                data-placement="top" title="Enter Numeric Cim Case Number" class="form-control" />
            <input type="hidden" id="_hCIRID_Flang" value="0" />
            <br/>
            <label id="lblCIMCaseError_Flang" style="color: red; display: none"></label>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">
            Turbine Number<span class="errorSpan">*</span>
           
            <label class='fa fa-spinner fa-spin' id="lblTurbineWait_flang" style="display: none"></label>
        </label>
        <div class="col-lg-9">
            <input type="number" id="txtTurbineNumber_Flang" data-toggle="tooltip" data-placement="top" title="Enter Numeric Turbine Number" class="form-control numbersOnly" />
            <br>
            <label id="lblTurbineError_Flang" style="color: red; display: none"></label>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Inspection Date<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtInspectionDate_Flang" data-toggle="tooltip" data-placement="top" title="Inspection date" maxlength="10" class="form-control" style="background-color:#fff" readonly="readonly" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Service Engineer/Technician<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtServiceEngineer_Flang" data-toggle="tooltip" data-placement="top" title="Enter Service engineer" class="form-control"  />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Service Report Number<span class="errorSpan manServiceReportNo">*</span></label>
        <div class="col-lg-7">
            <input type="text" id="txtServicePortNo_Flang" placeholder="Service report number" class="form-control" />
            <br>
            <label id="lblServicReportError_Flang" style="color: red; display: none"></label>
        </div>
        <div class="col-lg-2">
            <select id="ddlServiceReportNumberType_Flang" class="form-control" data-toggle="tooltip" data-placement="top" title="Enter Service Report Number Type" data-fieldtype="select" data-datatable="ServiceReportNumberType" data-textfield="text" data-valuefield="ServiceReportNumberTypeID" data-defaultvalue="4" data-insertlable="false" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Turbine Status after Inspection<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlRunStatusAfterInspection_Flang" class="form-control" data-fieldtype="select" data-datatable="TurbineRunStatus" data-textfield="text" data-valuefield="TurbineRunStatusID">
            </select>
        </div>
    </div>   
    <div class="form-group">
        <label class="col-lg-3 control-label">Outside Signs [Yes / No]<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlOutSideSign" class="form-control" data-toggle="tooltip" 
                data-placement="top" title="Outside Signs" >
                <option value="0">NO</option>
                <option value="1">YES</option>
            </select>
        </div>
    </div>     
    <div class="form-group">
        <label class="col-lg-3 control-label">Description & Flange no.<span class="errorSpan manDesFlangNo">*</span></label>
        <div class="col-lg-9">
            <textarea id="txtDescFlangNo" class="form-control" data-toggle="tooltip"
                                        data-placement="top" title="Description & Flange no." placeholder="Description & Flange no."></textarea>           
        </div>
    </div>  
     <%--<h4>Location</h4>
        <div class="form-group">
            <label class="col-lg-3 control-label">Latitude<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" id="txtLatitude" data-toggle="tooltip"
                    data-placement="top" title="Latitude" class="form-control" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Longitude<span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <input type="text" id="txtLongitude" data-toggle="tooltip"
                    data-placement="top" title="Longitude" class="form-control" />
            </div>
        </div>--%>
</fieldset>
<fieldset>
    

    
    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
           <div style="display:none;"> <a href="javascript:void(0);" id="linkSimplifiedCirPrev" class="btn btn-primary">Previous</a></div>
            <a href="javascript:void(0);" id="linkSimplifiedCirNext" class="btn btn-primary">Next</a>
        </div>
    </div>
</fieldset>
<script>
    $(document).ready(function () {
        //$('#txtServiceEngineer_Flang').text(CurrentUserInfo.Name);
       // $('#txtServiceEngineer_Flang').val(CurrentUserInfo.Name);
        $('.manDesFlangNo').hide();
        //$('#lblTurbineWait_flang').hide();
    });
</script>

