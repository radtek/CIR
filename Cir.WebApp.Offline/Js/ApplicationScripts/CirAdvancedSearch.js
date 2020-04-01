// override jQuery val function for conflict handling of cir template.
// this function will check if the object passed as argument is undefined then
// it will use '' to set the value of input element.
// the changes made is aonly efective for setter no change in getter
// Created By :Jayanta Nath
// Created on : 01-June-2016
(function ($) {
    var originalVal = $.fn.val;
    $.fn.val = function (value) {
        if (arguments.length >= 1) {
            // setter invoked, do processing
            if (value === 'undefined')
                return originalVal.call(this, '');
            return originalVal.call(this, value);
        }
        //getter invoked do processing
        return originalVal.call(this);
    };
})(jQuery);
var SearchResultTable;

var cirAdvancedSearch = new function () {
     
    this.LoadDropDowns = function (callback) {
        var selectelements = $('*[data-fieldType="select"]');
        var elecount = selectelements.length;
        selectelements.each(function (index) {
            //new code

             
            dbtransaction.BindDropDown($(this), index, function (selectitem, compltedidx) {
                if (compltedidx >= elecount) {
                    callback();
                }

            });
        });



        var selectelementsRemote = $('*[data-fieldType="select-remote"]');
        selectelementsRemote.each(function (index) {
           
            var selectprop = $(this).data();
            var table = selectprop.datatable;
            //if ($(this).attr('loaded') == undefined || $(this).attr('loaded') == null || $(this).attr('loaded') == false) {
            CallClientApi("MasterDataByTable/" + table, "GET", "").done(function (result) {
                if (result && result.length > 0) {
                    var selectelementtoLoad = $('*[data-datatable="' + result[0].key + '"]');
                    selectelementtoLoad.each(function (i) {
                        if ($(this).attr('loaded') !== undefined && $(this).attr('loaded') !== null && $(this).attr('loaded') === "true") {
                            //$(this).option.remove();
                            $(this).children('option').remove();
                            $(this).attr('loaded', false);
                        }
                        if ($(this).attr('loaded') == undefined || $(this).attr('loaded') == null || $(this).attr('loaded') == "false") {
                            var el = $(this);
                            el.append($('<option>', {
                                value: "-1",
                                text: "-- Please Select --"
                            }));
                            result.forEach(function (item) {
                                el.append($('<option>', {
                                    value: item[selectprop.valuefield],
                                    text: item[selectprop.textfield]
                                }));
                            });
                            el.attr('loaded', true);

                            $(el).trigger("chosen:updated");

                        }
                    });

                    //for (var i = 0, obj; obj = result[i]; i++) {
                    //}
                }
                else {
                    NotifyCirMessage('Error : ', "unable to load select list", 'danger');
                }
            });
            //}
        });

    }
};
$(document).ready(function () {

    loadBrandTypes();
    // NotifyCirMessage("", 'Choose the appropriate template from the CIR type or Hot list selectors below:<br /> 1. Blade, Gearbox, Generator and Transformer are mandatory. The templates can be found under "CIR type".<br /> 2. Hot list items are mandatory. The templates can be found under "Hot list". <br />3. Other types of the templates (General, Main Bearing and Skiipack) can be found under "CIR type".', "info");
    $('.Cir-help').css('cursor', 'pointer');

    $('#cirLocalID').val(Date.now()); // Local CIR ID
    $("[data-toggle=popover]").popover({
        container: 'body'
    });

    $(".numbersOnly").keypress(function (event) {
        // Backspace, tab, enter, end, home, left, right
        // We don't support the del key in Opera because del == . == 46.
        var controlKeys = [8, 9, 13, 35, 36, 37, 39];
        // IE doesn't support indexOf
        var isControlKey = controlKeys.join(",").match(new RegExp(event.which));
        // Some browsers just don't raise events for control keys. Easy.
        // e.g. Safari backspace.
        if (!event.which || // Control keys in most browsers. e.g. Firefox tab is 0
            (49 <= event.which && event.which <= 57) || // Always 1 through 9
            (48 == event.which && ($(this).val() >= 0)) || // No 0 first digit
            isControlKey) { // Opera assigns values for control keys.
            return;
        } else {
            event.preventDefault();
        }
    });
    $('.fixedRow').prop('readonly', 'true');

    //Get user initials
    dbtransaction.openDatabase(function () {
        dbtransaction.getItemfromTable('UserInfo', function UserInfo(user) {
            if (user) {
                if (user.length > 0) {
                    user.forEach(function (item) {
                        $('#hdnUserInitial').val(item.Email);
                    });
                }
            }
        });
    });
  
    cirAdvancedSearch.LoadDropDowns(function () { });


    //For Advanced Search Start
    $("#CIRWTDCommisioningDateFrom_txtDate,#CIRWTDCommisioningDateTo_txtDate,#CIRWTDFailureDateFrom_txtDate,#CIRWTDFailureDateTo_txtDate,#CIRWTDInspectionDateTo_txtDate,#CIRWTDInspectionDateFrom_txtDate,#CIRWTDInstallationDateFrom_txtDate,#CIRWTDInstallationDateTo_txtDate").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true,
    });

    $('#CIRBDLSCalibrationDateFrom_txtDate,#CIRBDLSCalibrationDateTo_txtDate,#CIRBDHardenerTypeExpiryDateFrom_txtDate,#CIRBDHardenerTypeExpiryDateTo_txtDate,#CIRBDResinTypeExpiryDateFrom_txtDate,#CIRBDResinTypeExpiryDateTo_txtDate,#CIRBDHeatersEtcOffFrom_txtDate,#CIRBDHeatersEtcOffTo_txtDate').datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true,
    });
    //For Advanced Search End



    //CIR accordion
    $("#cirTemplates").accordion({
        collapsible: true,
        heightStyle: "content",
        beforeActivate: function (event, ui) {
            var newIndex = jQuery(this).find("h3").index(ui.newHeader[0]);
            var oldIndex = jQuery(this).find("h3").index(ui.oldHeader[0]);
        }
    });


    //$('#linkCirAdvancedSearch,#linkCirAdvancedSearch_Profile,#linkCirAdvSearch_Common,#linkCirAdvSearch_Blade,#linkCirAdvSearch_Gearbox,linkCirAdvSearch_General,#linkCirAdvSearch_Generator,#linkCirAdvSearch_BIR,#linkCirAdvSearch_Transformer,#linkCirAdvSearch_MainBearing,linkCirAdvSearch_Skiipack').click(function () {
    //    $('#cirTemplateSection').slideUp('normal');
    //    $('#cirBladeSection').slideUp('normal');
    //    $('#cirAdvancedSearchResultSection').slideDown('normal');

    //});

    $("#linkSearchClose").click(function () {
        if (SearchResultTable != null)
            SearchResultTable.destroy();
        SearchResultTable = null;
        resultdata = [];
        //  $('#cirAdvancedSearchResult').empty();
        $('#cirBladeSection').slideUp('normal');
        $('#cirTemplateSection').slideDown('normal');
        $('#cirAdvancedSearchResultSection').slideUp('normal');
    });

    function listToAray(fullString, separator) {
        var fullArray = [];

        if (fullString !== undefined) {
            linkCirAdvancedSearchlinkCirAdvancedSearch
            if (fullString.indexOf(separator) == -1) {
                fullAray.push(fullString);
            } else {
                fullArray = fullString.split(separator);
            }
        }

        return fullArray;
    }

    $('#my-btn').click(function () {
        $('#addChangeModal').modal('show');
        $('[data-toggle=popover]').popover('hide'); //EDIT: added this line to hide popover on button click.
    })

    //$("#ddlCirSearchType").change(function () {

    //    $("#cirBladeSection").find("input:text").val('');
    //    $('#ComponentName').text($('#ddlCirSearchType :selected').text());

    //    switch ($(this).val()) {

    //        case 'Blade': // Blade
    //            $('.templateItem').hide(); // hidding all component
    //            $('#blade').show(); // showing specific compnent
    //            break;
    //        case 'Gearbox': // Gearbox
    //            $('.templateItem').hide(); // hidding all component
    //            $('#gearbox').show(); // showing specific compnent
    //            break;
    //        case 'General': // General
    //            $('.templateItem').hide(); // hidding all component
    //            $('#general').show(); // showing specific compnent
    //            break;
    //        case 'Generator': // Generator
    //            $('.templateItem').hide(); // hidding all component
    //            $('#generator').show(); // showing specific compnent
    //            break;
    //        case 'Transformer': // Transformer
    //            $('.templateItem').hide(); // hidding all component
    //            $('#transformer').show(); // showing specific compnent
    //            break;
    //        case 'MainBearing': // Main Bearing
    //            $('.templateItem').hide(); // hidding all component
    //            $('#mainbearing').show(); // showing specific compnent
    //            break;
    //        case 'Skiipack': // Skiipack
    //            $('.templateItem').hide(); // hidding all component
    //            $('#skiipack').show(); // showing specific compnent
    //            break;
    //        case 'Common': // Common
    //            $('.templateItem').hide(); // hidding all component
    //            $('#Common').show(); // showing specific compnent
    //            break;
    //        case 'BIR': // BIR
    //            $('.templateItem').hide(); // hidding all component
    //            $('#BIR').show(); // showing specific compnent
    //            break;
    //    }
    //});

    $('#fsProfile').hide()
    $('#AdvancedSearchButtons').show();

    $('.btn[data-radio-name]').click(function () {
        $('.btn[data-radio-name="' + $(this).data('radioName') + '"]').removeClass('active');
        $('input[name="' + $(this).data('radioName') + '"]').val($(this).attr('id'));
        if ($(this).attr('id') == 'rdManual') {
            $('#ComponentName').text($('#ddlCirSearchType :selected').text());
            $('#fsProfile').hide();
            $('#AdvancedSearchButtons').show();
        }
        else if ($(this).attr('id') == 'rdProfile') {
            $('#fsProfile').show();
            $('#AdvancedSearchButtons').hide();

        }
        return true;
    });

    var AdvancedSearchProfileId = 0;
    $('#linkCirLoadProfile').click(function () {

        

        $('#CIRProfile').removeClass('validationerror');
        $('#CIRProfile').removeClass('red-tooltip');


        if ($.trim($('#CIRProfile').val()) === "-1") {
            $('#CIRProfile').addClass('validationerror');
            $('#CIRProfile').addClass('red-tooltip');
            return;
        }
        else {
            $('#CIRProfile').removeClass('validationerror');
            $('#CIRProfile').removeClass('red-tooltip');
        }

        AdvancedSearchProfileId = $('#CIRProfile').val();

        //Clearing the Form data
        //document.getElementById("cirBladeSection").reset();
        $('#FrmAdvancedSearch')[0].reset();
        $('#CIRProfileIsPublic').parent().removeClass('checked');
        $('#CIRMainBearingGrease').parent().removeClass('checked');
        //Clearing the Form data

        $('#CIRProfile').val(AdvancedSearchProfileId);

        CallClientApi("LoadProfile/" + AdvancedSearchProfileId, "GET", "").done(function (result) {
            if (result) {
                if (result.isPublic)
                    $('#CIRProfileIsPublic').parent().addClass('checked');
                else
                    $('#CIRProfileIsPublic').parent().removeClass('checked');

                $('#CIRProfileSaveName').val(result.profileName);

                $(result.inputFields).each(function (index, item) {
                    $('#cirTemplates').find('input, select, textarea').each(function () {

                        if ($(this).attr('id') !== undefined && $(this).attr('id') !== "CIRProfile" && $(this).attr('id') !== "CIRProfileSaveName" && $(this).attr('id') !== "CIRProfileIsPublic") {

                            if ($(this).attr('id') === item.inputId) {
                                if (item.inputType === "ListBox") {

                                    //ctrl.val('').trigger('chosen:updated');
                                    //  $('#' + this.id).val('').trigger('chosen:updated');

                                    var dataarray = item.value.split(",");
                                    $(this).val(dataarray);
                                    //$(this).multiselect("refresh");
                                    $(this).trigger("chosen:updated");


                                }
                                else if (item.inputType === "CheckBox") {
                                    if (item.value)
                                        $(this).parent().addClass('checked');
                                    else
                                        $(this).parent().removeClass('checked');
                                }
                                else {
                                    $(this).val(item.value)
                                }
                            }
                        }
                    });
                });

                $("#linkCirSaveProfile").text("Update");
                //$("#ddlCirSearchType").trigger("change");
                NotifyCirMessage('Success : ', 'Profile loaded successfully!', 'success');

            }
            else {
                AdvancedSearchProfileId = 0;
                NotifyCirMessage('Error : ', "Profile loading failed!", 'danger');
            }
        });
    });

    $('#linkCirDeleteProfile').click(function () {

        $('#CIRProfile').removeClass('validationerror');
        $('#CIRProfile').removeClass('red-tooltip');


        if ($.trim($('#CIRProfile').val()) === "-1") {
            $('#CIRProfile').addClass('validationerror');
            $('#CIRProfile').addClass('red-tooltip');
            return;
        }
        else {
            $('#CIRProfile').removeClass('validationerror');
            $('#CIRProfile').removeClass('red-tooltip');
        }

        AdvancedSearchProfileId = $('#CIRProfile').val();

        //Clearing the Form data
        //document.getElementById("cirBladeSection").reset();
        $('#FrmAdvancedSearch')[0].reset();
        $('#CIRProfileIsPublic').parent().removeClass('checked');
        $('#CIRMainBearingGrease').parent().removeClass('checked');
        //Clearing the Form data

        $('#CIRProfile').val(AdvancedSearchProfileId);

        CallClientApi("CirAdvancedSearch?ProfileId=" + AdvancedSearchProfileId, "DELETE", "").done(function (result) {
            if (result) {
                if (result.result != undefined || result.result !== '') {
                    var ProfileSaveStatus = result.result;

                    if (ProfileSaveStatus === 'Success') {

                      cirAdvancedSearch.LoadDropDowns(function () { });
                        //$('#CIRProfileSaveName').val(null);

                        NotifyCirMessage('Success : ', result.responseString, 'success');
                        waitingDialog.hide();
                        return true;
                    }
                    else {
                        NotifyCirMessage('Error : ', result.responseString, 'danger');
                        waitingDialog.hide();
                        return false;
                    }
                }
            }
        });
    });

    var resultdata = [];
    var footable = null
    $('.AdvancedSearchButton').click(function () {
        
        resultdata = [];
        if (SearchResultTable != null)
            SearchResultTable.destroy();
        SearchResultTable = null;
        //   $('#cirAdvancedSearchResult').empty();
        var ServiceMethodName;

        $('#CIRProfileSaveName').removeClass('validationerror');
        $('#CIRProfileSaveName').removeClass('red-tooltip');
        if ($(this).attr('id') === "linkCirSaveProfile") {
            ServiceMethodName = 'SaveProfile';
            if ($.trim($('#CIRProfileSaveName').val()) === "") {
                $('#CIRProfileSaveName').addClass('validationerror');
                $('#CIRProfileSaveName').addClass('red-tooltip');
                return;
            }
            else {

                if (!$.trim($('#CIRProfileSaveName').val().match(/(\w+)\/(\w+)\/(\w+)$/))) {
                    $('#CIRProfileSaveName').addClass('validationerror');
                    $('#CIRProfileSaveName').addClass('red-tooltip');
                    return;
                }
                else {

                    $('#CIRProfileSaveName').removeClass('validationerror');
                    $('#CIRProfileSaveName').removeClass('red-tooltip');
                }
            }
        }
        else {
            ServiceMethodName = 'AdvancedSearch';
        }

        waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });



        var AdvancedSearchModel = {};
        //AdvancedSearchModel.SearchType = $('#ddlCirSearchType').val();
        //AdvancedSearchModel.ExcludeCIMCase = $('#ExcludeCIMCase').val();
        AdvancedSearchModel.ProfileName = $('#CIRProfileSaveName').val();
        AdvancedSearchModel.ProfileID = AdvancedSearchProfileId;
        AdvancedSearchModel.isPublic = $('#CIRProfileIsPublic').is(':checked');

        var InputFields = [];

        if ($(this).attr('id') === "linkCirAdvSearch_BIR") {
            var Control = {};
            Control.InputId = "ddlCirSearchType";
            Control.Value = "BIR";
            Control.InputType = "select-multiple";

            InputFields.push(Control);
        }

        $('#cirTemplates').find('input, select, textarea').each(function () {
            var Control = {};
            if ($(this).attr('id') !== undefined) {
                if ($(this).val() !== null && $(this).val() !== "" && $(this).val() !== "-1" && $(this).attr('id') !== "CIRProfileSaveName" && $(this).attr('id') !== "CIRProfileIsPublic") {
                    if ($(this).prop('type') === "select-multiple") {
                        if ($(this).val()[0] !== "") {
                            InputFields.push({ InputId: $(this).attr('id'), InputType: "ListBox", Value: $(this).val().join(",") });

                        }
                    }
                    else if ($(this).prop('type') === "checkbox") {
                        InputFields.push({ InputId: $(this).attr('id'), InputType: "CheckBox", Value: $(this).is(':checked') });
                    }
                    else {
                        InputFields.push({ InputId: $(this).attr('id'), InputType: "TextBox", Value: $(this).val() });
                    }
                }
            }
        });
       
        var data = $.grep(InputFields, function (e) {
            return ( e.Value != -1);
        });
        AdvancedSearchModel.InputFields = data;
       
        CallClientApi(ServiceMethodName, "POST", AdvancedSearchModel).done(function (result) {
            resultdata = [];
            if (ServiceMethodName === 'AdvancedSearch') {
                if (result) {
                    if (result.result != undefined && result.result !== '') {
                        resultdata = JSON.parse(result.result);
                        if (resultdata.rows.length >= 100) {
                            $('#AdvanceSearchMessage').show();
                        }
                        else {
                            $('#AdvanceSearchMessage').hide();
                        }
                        if (resultdata != null && resultdata.columns != null && resultdata.columns.length > 0) {
                            /* var objheader = [];
                             for (var prop in resultdata[0]) {
                                 objheader.push({ data: prop, title: prop });
                             }*/

                            //SearchResultTable = $('#cirAdvancedSearchResult').DataTable({
                            //    data: resultdata.rows,
                            //    columns: resultdata.columns
                            //});
                            // $("#cirAdvancedSearchResult").remove();
                            //$('<table>').attr({ 'id': 'tblSRNDetails', 'class': 'footable' }).appendTo('[data-role="content"]');

                            var th = "";
                            $.each(resultdata.columns, function (i, item) {
                                var numberic = "";
                                var colName = item.title;

                                if (colName.indexOf("ID") > 1 || colName.indexOf("No") > 1 || colName.indexOf("Number") > 1)
                                    numberic = " data-type='numeric' ";

                                if (i > 6)
                                    th = th + "<th nowrap " + numberic + " data-hide='phone,tablet' style='display:none'>" + item.title + "</th>";
                                else if (i > 2)
                                    th = th + "<th nowrap " + numberic + " data-hide='phone'>" + item.title + "</th>";
                                else
                                    th = th + "<th nowrap " + numberic + ">" + item.title + "</th>";
                            });
                            $("#cirAdvancedSearchResult > thead").empty();
                            $("#cirAdvancedSearchResult > thead").append(
                                "<tr>" + th +
                                "</tr>");
                            $("#cirAdvancedSearchResult > tbody").empty();
                            $.each(resultdata.rows, function (i, ritem) {
                                var td = "";
                                $.each(resultdata.columns, function (x, citem) {
                                    td = td + "<td>" + ritem[citem.data] + "</td>";

                                });

                                $("#cirAdvancedSearchResult > tbody").append("<tr>" + td + "</tr>");
                            });

                            if (footable == null) {
                                footable = $('#cirAdvancedSearchResult').footable();
                                $('#cirAdvancedSearchResult').trigger('footable_initialize');

                                $(window).trigger('resize');
                            }
                            else {
                                $('#cirAdvancedSearchResult').trigger('footable_initialize');
                                $('#cirAdvancedSearchResult').trigger('footable_redraw');
                                $(window).trigger('resize');
                            }


                            //  }
                            // else {
                            //     $('#cirAdvancedSearchResult').trigger('footable_redraw');
                            //  }



                            $('#divExport').show();
                            $('#cirTemplateSection').slideUp('normal');
                            $('#Common').slideUp('normal');
                            $('#cirBladeSection').slideUp('normal');
                            $('#cirAdvancedSearchResultSection').slideDown('normal');

                            waitingDialog.hide();
                        }
                        else {
                            $('#divExport').hide();
                            waitingDialog.hide();
                            NotifyCirMessage('No data found : ', result.responseString, 'info');

                            return;
                        }
                    }
                    else {
                        waitingDialog.hide();
                        NotifyCirMessage('No data found : ', result.responseString, 'info');
                        return;
                    }
                }
            }
            else {

                if (result) {
                    if (result.result != undefined || result.result !== '') {
                        var ProfileSaveStatus = result.result;

                        if (ProfileSaveStatus === 'Success') {
                            //Clearing the Form data
                            //document.getElementById("cirBladeSection").reset();
                            //$('#FrmAdvancedSearch')[0].reset();
                            //$('#CIRProfileIsPublic').parent().removeClass('checked');
                            //$('#CIRMainBearingGrease').parent().removeClass('checked');
                            //Clearing the Form data
                            //$('.chosen-select').val('').trigger('liszt:updated');

                            cirAdvancedSearch.LoadDropDowns(function () { });
                            //$('#CIRProfileSaveName').val(null);
                            //$('.chosen-select').trigger('chosen:updated');

                            NotifyCirMessage('Success : ', result.responseString, 'success');
                            waitingDialog.hide();
                            return true;
                        }
                        else {
                            NotifyCirMessage('Error : ', result.responseString, 'danger');
                            waitingDialog.hide();
                            return false;
                        }
                    }
                }

            }
            //}
        });
    });
    var loading = 0;
    $('#exportexcel').click(function () {
        if (loading == 1)
            return;
        loading = 1;
        if (resultdata.rows != null || resultdata.rows.length)
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });

        try {
            var DataForExcel = [];
            for (var i = 0, d; d = resultdata.rows[i]; i++) {
                if (d.ComponentInspectionReportId != undefined) {
                    d.ComponentInspectionReportId = $(d.ComponentInspectionReportId).text();
                }
                if (d.CimcaseNumber != undefined) {
                    d.CimcaseNumber = $(d.CimcaseNumber).text();
                }
                DataForExcel.push(d);
            }
            JSONToXlSXConvertor(DataForExcel, "CirList_AdvanceSearch", true);
        }
        catch (err) {
            NotifyCirMessage("Error", err, "danger")
        }
        waitingDialog.hide();
        loading = 0;
    });

    $('.AdvancedSearchReset_Main').click(function () {
        //document.getElementById("FrmAdvancedSearch").reset();
        if (SearchResultTable != null)
            SearchResultTable.destroy();
        SearchResultTable = null;
        resultdata = [];
        // $('#cirAdvancedSearchResult').empty();
        $('#cirAdvancedSearchResultSection').slideUp('normal');

        $('#FrmAdvancedSearch')[0].reset();
        $("#linkCirSaveProfile").text("Save");
        $('#CIRProfileIsPublic').parent().removeClass('checked');
        $('#CIRMainBearingGrease').parent().removeClass('checked');
        $('#ComponentName').text($('#ddlCirSearchType :selected').text());
        //$('.chosen-select option').prop('selected', false).trigger('chosen:updated');
        ////$('.chosen-select option').trigger('chosen:updated');
        //$('.chosen-select option').prop('selected', true).trigger('chosen:updated');

        //var form = $(this).closest('form').get(0);
        //form.reset();
        $('#CIRColumnsInResultList').trigger('chosen:updated');


        // $('#CIRColumnsInResultList').val('').trigger('liszt:updated');
        //$('.templateItem').hide();
        //$('#blade').show();
        AdvancedSearchProfileId = 0;
    });

    $('.AdvancedSearchReset').click(function () {
        //document.getElementById("FrmAdvancedSearch").reset();
        if (SearchResultTable != null)
            SearchResultTable.destroy();
        SearchResultTable = null;
        resultdata = [];
        //   $('#cirAdvancedSearchResult').empty();
        $('#cirAdvancedSearchResultSection').slideUp('normal');

        $('#FrmAdvancedSearch')[0].reset();
        $("#linkCirSaveProfile").text("Save");
        $('#CIRProfileIsPublic').parent().removeClass('checked');
        $('#CIRMainBearingGrease').parent().removeClass('checked');
        $('.chosen-select').trigger('chosen:updated');
        AdvancedSearchProfileId = 0;

    });

    $('#AdvanceSearchMessage').hide();
});

function ScrollTo(item) {
    try {
        $('html,body').animate({
            scrollTop: $("#" + item).offset().top - 45
        }, 'slow');
    }
    catch (e)
    { }
}
function loadBrandTypes() {
    CallClientApi("GetBrandTypes", "GET", "").done(function (data) {
        if ($('#CIRBrandType').attr('loaded') !== undefined && $('#CIRBrandType').attr('loaded') !== null && $('#CIRBrandType').attr('loaded') === "true") {
            //$(this).option.remove();
            $('#CIRBrandType').children('option').remove();
            $('#CIRBrandType').attr('loaded', false);
        }
        if ($('#CIRBrandType').attr('loaded') == undefined || $('#CIRBrandType').attr('loaded') == null || $('#CIRBrandType').attr('loaded') == "false") {
           
            data.forEach(function (item) {
                $('#CIRBrandType').append($('<option>', {
                    value: item.brandId,
                    text: item.brandName
                }));
            });
            $('#CIRBrandType').attr('loaded', true);

            $('#CIRBrandType').trigger("chosen:updated");

        }
        //$.each(data, function (i, item) {
            


        //    $('#CIRBrandType').append($('<option>', {
        //        value: item.brandId,
        //        text: item.brandName
        //    }));
        //});
    });
}
function stringToDate(_date, _format, _delimiter) {
    var formatLowerCase = _format.toLowerCase();
    var formatItems = formatLowerCase.split(_delimiter);
    var dateItems = _date.split(_delimiter);
    var monthIndex = formatItems.indexOf("mm");
    var dayIndex = formatItems.indexOf("dd");
    var yearIndex = formatItems.indexOf("yyyy");
    var month = parseInt(dateItems[monthIndex]);
    month -= 1;
    var formatedDate = new Date(dateItems[yearIndex], month, dateItems[dayIndex]);
    return formatedDate;
}

