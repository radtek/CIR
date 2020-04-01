function onChangeView() {
    var viewId = $('#ddlCirViews').val();
    if (viewId == 0) {

        //alert("Please select a valid CIR View!");
        //return false;
        CirAlert.alert('Please select a valid CIR View!', 'Cir App', null, 'error').done(function () {
            return false;
        });
    }
    if (viewId == -1) {
        $("#btnEditView").hide();
    }
    else {
        $("#btnEditView").show();
    }
}


function GetView(viewId) {

    $.each(allViews, function (i, item) {
        if (viewId == item.viewId) {
            CreateView(item);
            return;
        }
    });

}



//Bind the Dropdrown with the View List
function bindCirViewDropDown(data) {
    var prefix = "UNKNOWN";
    $('#ddlCirViews').empty();
    var list = data.viewDetailList;
    _ViewList = [];

    $.each(list, function (i, item) {
        switch (item.type) {
            case "System":
                prefix = "SBU";
                break;
            case "Public":
                prefix = "Public";
                break;
            case "Private":
                prefix = "Private";
                break;
        }
        var _view = {};
        _view.ViewId = item.viewId;
        _view.Name = item.name;
        _view.CreatedBy = item.createdBy;
        _view.Type = item.type;
        _view.InspectionAvailable = item.inspectionAvailable;
        _view.GeneralInspectionApplicable = item.generalInspectionApplicable;
        _view.GBXInspectionApplicable = item.gbxInspectionApplicable;
        _ViewList.push(_view);

        $('#ddlCirViews').append($('<option>', {
            value: item.viewId,
            text: prefix + ": " + item.name
        }));

    });

    $("#btnEditView").show();
    $("#btnEditView").removeAttr('disabled');
    $("#btnCreateView").removeAttr('disabled');
    $("#inbox").removeAttr('disabled');
    $("#accept").removeAttr('disabled');
    $("#reject").removeAttr('disabled');

    if (ViewId != "0") {
        $('#ddlCirViews').val(ViewId);
    }
    var vid = $('#ddlCirViews').val();
    if (vid == -1) {
        $("#btnEditView").hide();

    }
    else {
        if (!hasRole("Administrator")) {
            var v = findView(vid);
            if (v[0].CreatedBy != CurrentUserInfo.Name) {
                $("#btnEditView").hide();
            }
        }
    }
}


//Call Wep Api to get list of all views
function loadAllViews() {
    CallClientApi("GetAllViewList/0", "GET", "").done(function (result) {
        if (result) {
            bindCirViewDropDown(result);
            LoadUserInfo().done(function () {
                var userValid_Visitor = hasRole("Visitor");
                if (userValid_Visitor == true) {
                    $("#btnCreateView").hide();
                    $("#btnEditView").hide();
                }
                var v = findView(ViewId);
                if (v.length = 0) {
                    ViewId = -1;
                }
                loadGrid(1, 1, 1, 1);

            });
        }
        else {
            NotifyCirMessage('Error : ', "Cir View loading error", 'danger');
        }
    });



}




//////////////////////////////////////////////////





function ValidateView() {
    var isValid = true;
    $('#txtViewName,#ddlOrderFields').removeClass('validationerror red-tooltip');
    if ($.trim($('#txtViewName').val()) == '') {
        $('.nav-tabs a[href="#menu1"]').tab('show');
        $('#txtViewName').addClass('validationerror red-tooltip');
        ScrollTo('txtViewName');
        isValid = false;
        $("#txtViewName").focus();
    }
    if ($('#ddlOrderFields').val() == null || $('#ddlOrderFields').val() == 0) {
        $('.nav-tabs a[href="#menu1"]').tab('show');
        $('#ddlOrderFields').addClass('validationerror red-tooltip');
        ScrollTo('ddlOrderFields');
        isValid = false;
        $("#ddlOrderFields").focus();
    }

    var flg = 0;
    $(".form-inline .btnselectview").each(function (i, item) {

        flg = 1;

    });
    if (flg == 0) {
        NotifyCirMessage('Error : ', "Please add at least one field in the Selected section!", 'danger');
        $('.nav-tabs a[href="#menu2"]').tab('show');
        isValid = false;
    }

    return isValid;
}


function AddFilterRow() {
    var $newRow = $('#FilterDivRow').clone(true);
    //$newRow.find('*').andSelf().removeAttr('id');

    $('#FilterDiv tr:last').after($newRow);
    $('#FilterDiv tr:last').find('*').andSelf().removeClass('notvisible');
    $('#FilterDiv tr:last').find('input').andSelf().val('');
    return false;
}

function CreateView(viewId) {
    var isChecked = $("#chkPublicView").is(':checked');

    var sortFields = $('#ddlOrderFields').val().split(":");
    var sortFieldsText = $("option:selected", '#ddlOrderFields').text();

    var cirViewData = {
        ViewId: viewId,
        Name: $("#txtViewName").val(),
        Type: (isChecked == true) ? "Public" : "Private",
        InspectionApplicable: $("#chkInspectionApplicable").is(':checked'),
        GeneralInspectionApplicable: $("#chkGeneralInspectionApplicable").is(':checked'),
        GBXInspectionApplicable: $("#chkGBXInspectionApplicable").is(':checked'),
        ResultsPerPage: $("#ddlResultsPerPage").val(),
        CreatedBy: CurrentUserInfo.Name,
        Created: null,
        FieldMapping: null,
        QuickFilter: null,
        QuickFilterList: null,
        QuickFilterId: $("#ddlQuickFilter").val(),
        Sort: {
            Ascending: $('#ddlSort').val(),
            FieldItem: { ColumnName: sortFields[0], TableName: sortFields[1], ColumnDisplayName: sortFieldsText }
        },
        Fields: {
            FieldItems: GetFieldItems(),
        },

        Filter: {
            FilterItems: GetFilterItems(),
            MatchAll: $('#FilterMatchAll').val()
        }
    };

    var data = JSON.stringify(cirViewData);

    return cirViewData;
}

function GetFieldItems() {
    var FieldItems = [];

    var FieldTempDataArray = [];
    $(".form-inline .btnselectview").each(function (i, item) {
        var v = $(item).val();
        var id = $(item).attr("id");
        var t = $(item).attr("data-table");
        if (v.trim() != "") {
            var idData = id.split("_");
            var FieldTempData = {};
            FieldTempData.Order = i;
            FieldTempData.ColumnName = idData[0];
            FieldTempData.TableName = t;
            FieldTempData.ColumnDisplayName = v;
            FieldTempDataArray.push(FieldTempData);
        }
    });


    $.each(FieldTempDataArray, function (i, item) {
        FieldItems.push({ ColumnName: item.ColumnName, TableName: item.TableName, ColumnDisplayName: item.ColumnDisplayName });
    });

    return FieldItems;
}

function SortByColumnOrder(x, y) {
    return ((x.Order == y.Order) ? 0 : ((parseInt(x.Order) > parseInt(y.Order)) ? 1 : -1));
}

function GetFilterItems() {
    var rows = $('#FilterDiv tr');
    var FilterItems = [];
    $.each(rows, function (i, item) {
        var $row = $(item);
        $filterField = $row.find('select[class*="ddlFilterField"]');
        $filterNegate = $row.find('select[class*="ddlFilterNegate"]');
        $filterValue = $row.find('input[class*="FilterValue"]');

        var FilterItem = {};
        var FieldItem = {};
        if (!($filterField.val() == null || $filterField.val() == "" || $filterField.val() == 0)) {
            var filterField = $filterField.val().split(":");
            var filterFieldText = $("option:selected", $filterField).text();
            if (filterField.length > 0) {
                FieldItem.ColumnDisplayName = filterFieldText;
                FieldItem.ColumnName = filterField[0];
                FieldItem.TableName = filterField[1];
                FilterItem.FieldItem = FieldItem;
                FilterItem.Match = $filterNegate.val();
                FilterItem.Value = $filterValue.val();
                FilterItems.push(FilterItem);
            }
        }
    });

    return FilterItems;
}



function loadViewData() {

    $("#txtViewName").val(View.name);
    if (View.viewId <= 0) {
        $("#txtViewName").val('');
        $('#chkPublicView').iCheck('uncheck');
    } else {
        if (View.type.toUpperCase() == "PUBLIC") {
            $('#chkPublicView').iCheck('check');        
        }
    }
    
    if (View.inspectionApplicable == true) {
        $('#chkInspectionApplicable').iCheck('check');
    }

    if (View.generalInspectionApplicable == true) {
        $('#chkGeneralInspectionApplicable').iCheck('check');
    }
    if (View.gbxInspectionApplicable == true) {
        $('#chkGBXInspectionApplicable').iCheck('check');
    }

    //Set QuickFilter           
    var quickFilterList = View.quickFilterList;

    $.each(quickFilterList, function (i, item) {
        $('#ddlQuickFilter').append($('<option>', {
            value: item.value,
            text: item.name
        }));

    });

    var quickFilterId = View.quickFilterId;

    $('#ddlQuickFilter').val(quickFilterId.trim());


    var fieldMapping = View.fieldMapping;
    var fieldMapping = View.fieldMapping;
    if (View.viewId == -1) {
        var cf = View.fields.fieldItems;
        $.each(cf, function (i, item) {
            fieldMapping.push(item);
        });
        fieldMapping.sort(SortByColumnDisplayName);
    }

    AllFieldData = fieldMapping;
    $.each(fieldMapping, function (i, item) {
        $('.ddlFilterField').append($('<option>', {
            value: item.columnName + ":" + item.tableName,
            text: item.columnDisplayName
        }));
        $('#ddlOrderFields').append($('<option>', {
            value: item.columnName + ":" + item.tableName,
            text: item.columnDisplayName
        }));
    });


    //Set Filters
    if (View.filter != null) {
        var filterData = View.filter.filterItems;
        var l = filterData.length;

        for (var i = 1; i < l; i++) {
            AddFilterRow();
        }

        $.each(filterData, function (i, item) {
            var rows = $('#FilterDiv tr');
            var $row = $(rows[i]);
            $filterField = $row.find('select[class*="ddlFilterField"]');
            $filterNegate = $row.find('select[class*="ddlFilterNegate"]');
            $filterValue = $row.find('input[class*="FilterValue"]');

            var _filterField = item.fieldItem.columnName + ":" + item.fieldItem.tableName;
            $filterField.val(_filterField);
            var _filterNegate = item.match;
            if (_filterNegate.length > 0)
            $filterNegate.val(_filterNegate.toLowerCase());
            var _filterValue = item.value;
            $filterValue.val(_filterValue);


        });
        $('#FilterMatchAll').val(View.filter.matchAll.toString());
    }



    var sortData = View.sort;
    if (sortData) {
        var sortSel = sortData.fieldItem.columnName + ":" + sortData.fieldItem.tableName;
        $('#ddlOrderFields').val(sortSel);
        $('#ddlSort').val(sortData.ascending.toString());
    }
    $('#ddlResultsPerPage').val(View.resultsPerPage);

    //LoadFields
    var CurrentfieldsData = View.fields.fieldItems;
    // if (View.viewId <= 0)
    //// {
    //     CurrentfieldsData = getDefaultField();
    // }
    CurrentfieldsData = GroupCommonFields(CurrentfieldsData);
   // FilteredfieldsData.sort(SortByTableName);

    var str = '<fieldset><form class="form-inline">';
    var inStr = "";

    var c = 1;
   
    $.each(CurrentfieldsData, function (i, item) {
        var id = item.columnName + "_" + item.tableName;
        var colName = item.columnDisplayName;
        colName = (colName.length > 35) ? colName.substring(0,35) + ".." : colName;
     
        var btns = '<div class="col-sm-4 divblocks" style="padding:2px"><div class="input-group">' +
                        '<span class="input-group-addon" style="cursor:pointer" onclick=MoveCurrentElement(this,1);><i style="color:#000;cursor:pointer" class="fa fa-angle-double-left fa-sm" title="Move left"></i></span>' +
                            '<span class="close" onclick=deleteField(\"' + id + '\"); style="display:none">&times;</span><input type="button" onclick=showClose(this); class="btnselectview btn btn-default" id="' + id + '" data-table="' + item.mainTableName + '" value="' + colName + '"  title="Click to remove ' + item.columnDisplayName + '" />' +
                        '<span class="input-group-addon"  style="cursor:pointer"  onclick=MoveCurrentElement(this,2);><i style="color:#000;cursor:pointer" class="fa fa-angle-double-right fa-sm" title="Move right" onclick=""></i></span>' +
                    '</div></div>';
        //inStr = inStr + '<div class="col-sm-3 text-center"><span class="text-center">' + item.columnDisplayName + '</span><span class="text-center"><input type="number" id="' + id + '" value="' + (i + 1) + '" min="0" max="99" onkeydown="limit(this);" onkeyup="limit(this);" class="NUMBERICVALUE form-control form-control-small" data-display="' + item.columnDisplayName + '" maxlength="2" /></span></div>';
        inStr = inStr + btns;// '<div class="col-sm-3 text-center" style="padding:3px"><input type="button" class="btnselectview btn btn-default" id="' + id + '" value="' + item.columnDisplayName + '" /></div>';
        if (c == 5)
        { c = 0; }
        c++;



    });

    str = str + inStr + '</form></fieldset>';
    $("#FieldData_1").html(str);
    /////////


    var AllfieldsData = View.fieldMapping;
    var FilteredfieldsData = RemoveCurrentFields(CurrentfieldsData, AllfieldsData);
    //FilteredfieldsData.sort(SortByColumnDisplayName);
    FilteredfieldsData = GroupCommonFields(FilteredfieldsData);
    FilteredfieldsData.sort(SortByTableName);

    str = '<fieldset><div class="form-group">';
    inStr = "";
    var c = 1;
    var ViewType = 1;
    var groupChar = (ViewType == 1) ? FilteredfieldsData[0].tableName : FilteredfieldsData[0].columnDisplayName.substring(0, 1).toUpperCase();
    var pandelId = 2;
    $.each(FilteredfieldsData, function (i, item) {
        var g = (ViewType == 1) ? item.tableName : item.columnDisplayName.substring(0, 1).toUpperCase();
        if ((groupChar != g) || (i == FilteredfieldsData.length - 1)) {

            AddPanel(groupChar + (groupChar == "Common" ? " + Wind Turbine Data" : ""));
            str = str + inStr + '<div id="holdercend_' + groupChar + '"></div></div></fieldset>';
            $("#FieldData_" + pandelId).html(str);
            str = '<fieldset><div class="form-group">';
            inStr = "";
            c = 1;
            pandelId++; 
            groupChar = (ViewType == 1) ? item.tableName : item.columnDisplayName.substring(0, 1).toUpperCase();


        }

        var id = item.columnName + "_" + item.tableName;
        //inStr = inStr + '<div class="col-lg-3 text-center"><span class="text-center">' + item.columnDisplayName + '</span><span class="text-center"><input type="text" id="' + id + '" class="NUMBERICVALUE form-control form-control-small" min="0" max="99" onkeydown="limit(this);" onkeyup="limit(this);" data-display="' + item.columnDisplayName + '" maxlength="2" /></span></div>';
        var colName = item.columnDisplayName;
        colName = (colName.length > 35) ? colName.substring(0, 35) + ".." : colName;

        inStr = inStr + '<div class="col-sm-3 text-center" style="padding:3px"><input type="button" onclick="MoveElement(this);" class="btnselectview btn btn-default" id="' + id + '" data-table="' + item.mainTableName + '" title="Click to add ' + item.columnDisplayName + ' in selected fields section" value="' + colName + '" /></div>';
        if (c == 5)
        { c = 0; }
        c++;


    });


}

function deleteField(e) {
    var cDiv = $("#" + e).parent().parent("div");
    var colName = $("#" + e).val()
    colName = (colName.length > 35) ? colName.substring(0, 35) + ".." : colName;
    var btnnew = '<div class="col-sm-3 text-center" style="padding:3px">' +
                         '<input type="button" onclick="MoveElement(this);" title="Click to add ' + $("#" + e).val() + ' in selected fields section" class="btnselectview btn btn-default" id="' + $("#" + e).attr("id") + '" value="' + colName + '" /></div>';

    var v = $("#" + e).attr("id");
    var firstChar = v.split("_")[1];//v.substring(0, 1);
    $(cDiv).fadeOut("slow", function () {
        $(cDiv).remove();
        $(btnnew).insertBefore($("#holdercend_" + firstChar));
    });
}

function hideClose() {
    $(".close").each(function (item) {
        $(this).hide();
    });
}

function showClose(el) {
    $(".close").each(function (item) {
        $(this).hide();
    });
    var id = $(el).attr("id");
    var c = id.split("_")[0];
    if (c == "CIMCaseNumber" || c == "CIRID" || c == "ComponentInspectionReportTypeId" || c == "FileName" || c == "Modified" ||
     c == "ReportTypeId" || c == "TurbineNumber" || c == "Created")
    {
        $(el).attr("title","You cannot removed this field from this section!");
    }
    else
    {
        $(el).attr("title", "");
        $(el).prev().show();
    }
    //CIMCaseNumber_Common
    //CIRID_Common
    //ComponentInspectionReportTypeId_Common
    //FileName_Common
    //Modified
    //ReportTypeId_Common
    //TurbineNumber_Common

   

}

//For moving elements from All Fields to Current Fields
function MoveElement(e) {
    hideClose();
   
    var colName = $(e).val();
    colName = (colName.length > 35) ? colName.substring(0, 35) + ".." : colName;
    var btnnew = '<div class="col-sm-4 divblocks" style="padding:2px"><div class="input-group">' +
                        '<span class="input-group-addon" style="cursor:pointer" onclick=MoveCurrentElement(this,1);><i style="color:#000;cursor:pointer" class="fa fa-angle-double-left fa-sm" title="Move left" ></i></span>' +
                            '<span class="close" onclick=deleteField("' + $(e).attr("id") + '"); style="display:none">&times;</span><input type="button" class="btnselectview btn btn-default"  onclick=showClose(this); id="' + $(e).attr("id") + '" data-table="' + $(e).attr("data-table") + '" title="Click to remove ' + $(e).val() + '" value="' + colName + '" />' +
                        '<span class="input-group-addon"  style="cursor:pointer"  onclick=MoveCurrentElement(this,2);><i style="color:#000;cursor:pointer" class="fa fa-angle-double-right fa-sm" title="Move right" ></i></span>' +
                    '</div></div>';


    $(e).fadeOut("slow", function () {
        $(".form-inline").append(btnnew);
        $(e).parent("div").remove();
    });

}

function MoveCurrentElement(e, dir) {
    hideClose();
    var cDiv = $(e).parent().parent();
    var cinput = $(cDiv).find("input");
    var pDiv = null;
    if (dir == 1)
        pDiv = $(cDiv).prev();
    else
        pDiv = $(cDiv).next();
    if (pDiv.length == 0) {
        if (dir == 1)
            pDiv = $(".form-inline .divblocks").last();
        else
            pDiv = $(".form-inline .divblocks").first();
    }
    var pinput = $(pDiv).find("input");
    var pDiv1 = $(pDiv).html(); var cDiv1 = $(cDiv).html();
    $(cDiv).fadeOut("slow", function () {
        $(cDiv).html(pDiv1);
        $(cDiv).fadeIn("slow", function () {
        });
    });
    $(pDiv).fadeOut("slow", function () {
        $(pDiv).html(cDiv1);
        $(pDiv).fadeIn("slow", function () {
        });
    });
    //  $(cinput).swapElement($(pinput));
}
//For moving elements in Current Fields

function GroupCommonFields(d) {
    var newData = [];
    // EditHistory FirstNotification ImageDataInfo SecondNotification GUID
    var result = $.grep(d, function (i) { return (i.tableName == "CirData" || i.tableName == "ComponentInspectionReport" || i.tableName == "TurbineData") });
    $.each(result, function (x, i) {
        if (i.columnName == "Guid") {
        }
        else {
            i.mainTableName = i.tableName;
            i.tableName = "Common";
            i.sortOrder = 0;
            newData.push(i);
        }
    });

    $.each(d, function (x, i) {
        if (i.tableName == "Common" ||
            i.tableName == "EditHistory" || i.tableName == "FirstNotification" || i.tableName == "ImageDataInfo" ||
           // i.tableName == "ComponentInspectionReportSkiiPFailedComponent" || i.tableName == "ComponentInspectionReportSkiiPNewComponent" ||
            i.tableName == "SecondNotification" || i.columnName == "Guid") {
            //if(i.tableName == "Common")
            //{
            //    i.mainTableName = i.tableName;
            //    i.tableName = "Common";
            //}
        }
        else {
            i.mainTableName = i.tableName;
            i.tableName = i.tableName.replace("ComponentInspectionReport", "");
            if (i.tableName == "SkiiPFailedComponent") i.tableName = "Skiipack";
            if (i.tableName == "SkiiPNewComponent") i.tableName = "Skiipack";
            if (i.tableName == "SkiiP") i.tableName = "Skiipack";
           
            i.sortOrder = 1;
            newData.push(i);
        }
    });
    return newData;

}

function RemoveCurrentFields(CurrentfieldsData, AllfieldsData) {
    var newData = [];
    $.each(AllfieldsData, function (i, aitem) {
        var flg = 0;
        if (aitem.tableName != "SBU") {
            $.each(CurrentfieldsData, function (x, citem) {
                if (citem.columnName == aitem.columnName && citem.maintableName == aitem.maintableName) {
                    flg = 1;
                }
            });
            if (flg == 0) {
                newData.push(aitem);
            }
        }
    });
    return newData;

}

function SortByColumnDisplayName(x, y) {
    return ((x.columnDisplayName == y.columnDisplayName) ? 0 : ((x.columnDisplayName > y.columnDisplayName) ? 1 : -1));
}

function SortByTableName(x, y) {
    // return ((x.tableName == y.tableName) ? 0 : ((x.tableName > y.tableName) ? 1 : -1));
    
    if (x.sortOrder > y.sortOrder) return 1;
    else if (x.sortOrder < y.sortOrder) return -1;
    else if (x.tableName > y.tableName) return 1;
    else if (x.tableName < y.tableName) return -1;
    else if (x.columnDisplayName > y.columnDisplayName) return 1;
    else if (x.columnDisplayName < y.columnDisplayName) return -1;
    else return 0;
}


//Call Wep Api to get list of all views
function loadView(ViewId) {
    CallClientApi("GetView/" + ViewId, "GET", "").done(function (result) {
        View = result;
        var data = JSON.stringify(View);
        loadViewData();
    });
}

function createCookie(name, value, days) {
    if (days) {
        var date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        var expires = "; expires=" + date.toGMTString();
    }
    else var expires = "";
    document.cookie = name + "=" + value + expires + "; path=/";
}

function readCookie(name) {
    var nameEQ = name + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length, c.length);
    }
    return null;
}

function eraseCookie(name) {
    createCookie(name, "", -1);
}

function getDefaultField() {
    var defaultFields = [];
    var defaultFieldItem = {};
    defaultFieldItem.columnName = 'FileName';
    defaultFieldItem.tableName = 'CirData';
    defaultFieldItem.columnDisplayName = 'Name';
    defaultFields.push(defaultFieldItem);

    var defaultFieldItem = {};
    defaultFieldItem.columnName = 'ComponentInspectionReportId';
    defaultFieldItem.tableName = 'ComponentInspectionReport';
    defaultFieldItem.columnDisplayName = 'CIR ID';
    defaultFields.push(defaultFieldItem);

    var defaultFieldItem = {};
    defaultFieldItem.columnName = 'CimCaseNumber';
    defaultFieldItem.tableName = 'ComponentInspectionReport';
    defaultFieldItem.columnDisplayName = 'CIM Case Number';
    defaultFields.push(defaultFieldItem);


    var defaultFieldItem = {};
    defaultFieldItem.columnName = 'Name';
    defaultFieldItem.tableName = 'ComponentInspectionReportType';
    defaultFieldItem.columnDisplayName = 'Component Type';
    defaultFields.push(defaultFieldItem);

    var defaultFieldItem = {};
    defaultFieldItem.columnName = 'Reporttype';
    defaultFieldItem.tableName = 'ComponentInspectionReport';
    defaultFieldItem.columnDisplayName = 'Report Type';
    defaultFields.push(defaultFieldItem);

    var defaultFieldItem = {};
    defaultFieldItem.columnName = 'Name';
    defaultFieldItem.tableName = 'CountryISO';
    defaultFieldItem.columnDisplayName = 'Country';
    defaultFields.push(defaultFieldItem);

    var defaultFieldItem = {};
    defaultFieldItem.columnName = 'Name';
    defaultFieldItem.tableName = 'TurbineRunStatus';
    defaultFieldItem.columnDisplayName = 'Run Status After Inspection';
    defaultFields.push(defaultFieldItem);

    var defaultFieldItem = {};
    defaultFieldItem.columnName = 'Name';
    defaultFieldItem.tableName = 'SBU';
    defaultFieldItem.columnDisplayName = 'SBU';
    defaultFields.push(defaultFieldItem);

    var defaultFieldItem = {};
    defaultFieldItem.columnName = 'Created';
    defaultFieldItem.tableName = 'CirData';
    defaultFieldItem.columnDisplayName = 'Created';
    defaultFields.push(defaultFieldItem);

    var defaultFieldItem = {};
    defaultFieldItem.columnName = 'Modified';
    defaultFieldItem.tableName = 'CirData';
    defaultFieldItem.columnDisplayName = 'Modified';
    defaultFields.push(defaultFieldItem);


    //SELECT 'TurbineType','ComponentInspectionReport','Turbine Type' UNION

    return defaultFields;
}

//Added By Siddharth Chauhan on 06-06-2016.
//To load data in the dropdownlists in the Quick Search parameters for filtering records.
//Task No. : 75301
$(document).ready(function () {
    dbtransaction.openDatabase(function () {
        loadCirTypes();
    });
   // dbtransaction.openDatabase(function () {
        loadBrandTypes();
    //});
    dbtransaction.openDatabase(function () {
        loadReportType();
    });
    dbtransaction.openDatabase(function () {
        loadTurbineStatus();
    });
});

function loadBrandTypes() {
    CallClientApi("GetBrandTypes", "GET", "").done(function (data) {
        $.each(data, function (i, item) {
            $('#ddlBrandType').append($('<option>', {
                value: item.brandId,
                text: item.brandName
            }));
        });
    });
    //dbtransaction.getItemfromTable('ComponentInspectionReportType', renderBrandTypes);
    ////Rendring items in list
    //function renderBrandTypes(reportTypes) {
    //    reportTypes.forEach(function (item) {
    //        $('#ddlBrandType').append($('<option>', {
    //            value: item.ComponentInspectionReportTypeID,
    //            text: item.text
    //        }));
    //    });
    //    $("#ddlBrandType option").length;
    //}
}

//Added By Siddharth Chauhan on 06-06-2016.
//To load the CIR Types dropdownlist in the Quick Search parameters for filtering records.
//Task No. : 75301
function loadCirTypes() {
    dbtransaction.getItemfromTable('ComponentInspectionReportType', renderReportTypes);
    //Rendring items in list
    function renderReportTypes(reportTypes) {
        reportTypes.forEach(function (item) {
            $('#ddlQuickCirType').append($('<option>', {
                value: item.ComponentInspectionReportTypeID,
                text: item.text
            }));
        });
        $("#ddlQuickCirType option").length;
    }
}

//Added By Siddharth Chauhan on 06-06-2016.
//To load the Report Types dropdownlist in the Quick Search parameters for filtering records.
//Task No. : 75301
function loadReportType() {
    dbtransaction.getItemfromTable('ReportType', renderReportTypes);
    //Rendring items in list
    function renderReportTypes(reportTypes) {
        reportTypes.forEach(function (item) {
            $('#ddlQuickReportType').append($('<option>', {
                value: item.ReportTypeID,
                text: item.text
            }));
        });
    }
}

//Added By Siddharth Chauhan on 06-06-2016.
//To load the Turbine Status dropdownlist in the Quick Search parameters for filtering records.
//Task No. : 75301
function loadTurbineStatus() {
    dbtransaction.getItemfromTable('TurbineRunStatus', renderTurbineRunStatus);
    //Rendring items in list
    function renderTurbineRunStatus(turbineRunStatus) {
        turbineRunStatus.forEach(function (item) {
            $('#ddlQuickRunStatus').append($('<option>', {
                value: item.TurbineRunStatusID,
                text: item.text
            }));
        });
    }
}