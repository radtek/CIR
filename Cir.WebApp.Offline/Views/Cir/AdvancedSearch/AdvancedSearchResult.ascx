<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <label style="margin-bottom:10px""><span style="font-size:18px;font-weight:bold;">Advanced Search Result</span>
    <span id="AdvanceSearchMessage" style="font-size:14px;font-weight:bold;color:red;margin-left:10px">( Your search returned more than 100 results. Only the first 100 are shown in the result list.
    You can narrow down your search by specifying additional search parameters in the search form below.
  Alternatively you can also create a personal view on the Inbox/Accept/Reject lists, if this suits your needs better. )</span></label>
    <br />
    <div class="form-group">
        <%--<div class="form-group">
                <div class="col-xs-12" style="text-align: right;">
                    <div id="page-selection1-Local" class="page-selection-Local"></div>
                </div>
            </div>--%>
        <%--<div class="form-group" id="AdvanceSearchMessage">--%>

        <%--</div>--%>
        <div class="col-lg-12">
            <table id="cirAdvancedSearchResult" class="footable table sortable toggle-arrow-alt" data-sorting="true" width="100%">
                <thead>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>

    </div>
    <table style="width: 100%">

        <tr>
            <td class="col-xs-12" style="text-align: left; display: none" id="divExport">
                <%--<div class="col-xs-12" style="text-align: left; display: none" id="divExport">--%>
                <a title="Export list to Excel" href="javascript:void(0);" id="exportexcel" style="color: #333;"><i style="color: #2E64FE; cursor: pointer" id="iconInfo" class="fa fa-file-excel-o fa-lg" title="Export list to Excel"></i><b>&nbsp;&nbsp;Export result to Excel</b></a>
            </td>
            <%--<div class="form-group">--%>


            <td class="col-xs-12" style="text-align: right;">
                <%--<div class="col-xs-12" style="text-align: right;">--%>
                <a href="javascript:void(0);" id="linkSearchClose" class="btn btn-primary">Close</a>
            </td>
        </tr>
    </table>
    <%--</div>--%>
</fieldset>
