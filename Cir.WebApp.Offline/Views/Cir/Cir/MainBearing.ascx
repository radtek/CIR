<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <legend>Main Bearing Data</legend>
    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Manufacturer</label>
        <div class="col-lg-9">
            <select id="ddlMainBearingManufacturer" class="form-control" data-placement="top" data-fieldtype="select" data-datatable="MainBearingManufacturer" data-textfield="text" data-valuefield="MainBearingManufacturerID">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Type/Revision<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <table>
                <tr>
                    <td>
                        <select id="ddlMainBearingType" class="form-control" data-placement="top" data-fieldtype="select" data-datatable="MainBearingManufacturer" data-textfield="text" data-valuefield="MainBearingManufacturerID">
                        </select>
                    </td>
                    <td>
                        <select id="ddlMainBearingRevision" class="form-control">
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                        </select>
                    </td>
                </tr>
            </table>

        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Front / Rear</label>
        <div class="col-lg-9">
            <select id="ddlMainBearingFrontRear" class="form-control" data-placement="top" data-fieldtype="select" data-datatable="MainBearingErrorLocation" data-textfield="text" data-valuefield="MainBearingErrorLocationID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Serial Number<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtMainBearingSerialNumber" class="form-control" placeholder="Main Bearing Serial Number" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Lubrication Type<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <select id="ddlMainBearingLubricationType" class="form-control" data-placement="top" data-fieldtype="select" data-datatable="OilType" data-textfield="text" data-valuefield="OilTypeID" data-sort="true">
            </select>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Type of Mechanical Oil Pump</label>
        <div class="col-lg-9">
            <input type="text" id="txtMainBearingMechanicalOilPump" class="form-control" placeholder="Type of Mechanical Oil Pump" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Oil Temperature at inspection<span class="errorSpan" id="spanMainBearingOilTemp">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtMainBearingOilTemperature" class="form-control numbersOnly" placeholder="Oil Temperature at inspection" />
        </div>
    </div>
    <div class="form-group">
        <!--Added by Siddharth Chauhan on 22-06-2016-->
        <!--Removed "*" from checkbox and added text with checkbox-->
        <!--Bug : 80806-->
        <label class="col-lg-3 control-label"><span class="errorSpan"></span></label>
        <div class="col-lg-9">
            <input type="checkbox" id="chkMainBearingGrease" title="N/A" value="N/A" />
            <span>N/A</span>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Hours on Bearing<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtMainBearingHoursBearing" class="form-control numbersOnly" placeholder="Hours on Bearing" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Main Bearing Temperature</label>
        <div class="col-lg-9">
            <input type="number" id="txtMainBearingBearingTemperature" class="form-control numbersOnly" placeholder="Main Bearing Temperature" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Date for last lubrication change<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtMainBearingLubricationchangeDate" class="form-control" placeholder="Date for last lubrication change" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Run hrs on lubrication<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="number" id="txtMainBearingRunLubrication" class="form-control numbersOnly" placeholder="Run hrs on lubrication" />
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkMainbearingDataPrev" class="btn btn-primary">Previous</a>
            <a href="javascript:void(0);" id="linkMainbearingDataNext" class="btn btn-primary">Next</a>
        </div>
    </div>
</fieldset>
