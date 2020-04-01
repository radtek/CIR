<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <legend>BIR Data</legend>
   
        <div class="form-group">
            <label class="col-lg-3 control-label">BIR ID</label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="BIR_lbBIRID" placeholder="BIR Id" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">BIR Name</label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="BIR_lbBirName" placeholder="BIR Name" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Rev No</label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="BIR_lbRevNo" placeholder="Rev No" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">SBU</label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="BIR_lbSBU" placeholder="SBU" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Site</label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="BIR_lbSite" placeholder="Site" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label">Turbine No</label>
            <div class="col-lg-9">
                <input type="text" class="form-control" id="BIR_lbTurbine" placeholder="Turbine No" />
            </div>
        </div>
   
        
    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkCirAdvSearch_BIR" class="btn btn-primary AdvancedSearchButton">Search</a>
            <a href="javascript:void(0);" id="linkCirReset_BIR" class="btn btn-primary AdvancedSearchReset">Reset</a>
        </div>
    </div>
</fieldset>
