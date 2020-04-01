<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<fieldset>
    <br />
    <br />
     <div class="form-group">
        <label class="col-lg-3 control-label">SBU Recommendation</label>
        <div class="col-lg-9">
            <textarea id="txtSBURecommendation_Flang" class="form-control" data-toggle="tooltip"
                                        data-placement="top" title="SBU Recommendation" placeholder="SBU Recommendation"></textarea>
           
        </div>
    </div> 
</fieldset>
<fieldset>
    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
           <a href="javascript:void(0);" id="linkSbuRecommPrev" onclick="SaveSBURecommendation('Prev')" class="btn btn-primary">Previous</a>
            <a href="javascript:void(0);" id="linkSbuRecommNext" onclick="SaveSBURecommendation('Next')" class="btn btn-primary">Next</a>
        </div>
    </div>
</fieldset>


