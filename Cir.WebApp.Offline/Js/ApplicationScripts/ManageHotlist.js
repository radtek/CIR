var cirhotlist = new function () {

    this.Hotlist = {
        hotItemId: 0,
        allhotlist: []
    };

    this.GetHotlistbyId = {
        hotItemId: 0,
        ReportTypeId: 0,
        VestasItemNumber: "",
        VestasItemName: "",
        ManufacturerName: "",
        Email: "",
        cc: "",
        HotItemDisplay: ""
    };

    this.gethotlist = function (id) {
        var deferredObject = $.Deferred();
        //CallClientApi("GetHotlistbyId/" + id, "GET", "").done(function (data) {
        CallSyncApi("HotlistData/GetByHotItemId?hotItemId=" + id, "GET", "").done(function (data) {
            deferredObject.resolve(data.result);
        })
        .fail(function () {
            deferredObject.reject();
        });

        return deferredObject.promise();
    }

    this.getallhotlist = function () {
        var deferredObject = $.Deferred();
        //CallClientApi("GetHotlist", "GET", "").done(function (data) {
        CallSyncApi("HotlistData/GetAll", "GET", "").done(function (data) {
            deferredObject.resolve(data.result);
        })
        .fail(function () {
            deferredObject.reject();
        });

        return deferredObject.promise();
    }

    this.deleteHotlist = function (id) {

        //CallClientApi("Hotlist?id=" + id, "DELETE", "").done(function (data) {
        CallSyncApi("HotlistData/DeleteByHotItemId?hotItemId=" + id, "DELETE", "").done(function (data) {
            NotifyCirMessage('', 'Selected Hotlist deleted!', 'info');
            cirhotlist.loadHotlist();
        });
    }

    this.savehotlist = function () {
        //var reporttypeid;

        //if ($("#ddlInspectionReportType").val() == "Blade") {
        //    reporttypeid = 1;

        //}
        //else if ($("#ddlInspectionReportType").val() == "Gearbox") {
        //    reporttypeid = 2;

        //}
        //else if ($("#ddlInspectionReportType").val() == "General") {

        //    reporttypeid = 3;

        //}
        //else if ($("#ddlInspectionReportType").val() == "Generator") {
        //    reporttypeid = 4;


        //}
        //else if ($("#ddlInspectionReportType").val() == "Transformer") {
        //    reporttypeid = 5;

        //}
        //else if ($("#ddlInspectionReportType").val() == "Main Bearing") {

        //    reporttypeid = 6;

        //}
        //else if ($("#ddlInspectionReportType").val() == "Skiipack") {
        //    reporttypeid = 7;

        //}

        //try { brandTmp = JSON.parse($("#ddlBrand option:selected").val()); } catch (e) { }
        //try { cirTemplateTmp = JSON.parse($("#ddlTemplate option:selected").val()); } catch (e) { }

        var brandTmp = {
            id: $("#ddlBrand option:selected").val(),
            name: $("#ddlBrand option:selected").text(),
            partition: "partition"
        }

        var cirTemplateTmp = {
            id: $("#ddlTemplate option:selected").val(),
            name: $("#ddlTemplate option:selected").text()
        }

        var m = {
            id: $("#txtHdnAzureId").val(),
            brand: brandTmp,
            cirTemplate: cirTemplateTmp,
            //reportType: $("#txtReportType").val(),
           // hotItemDisplay: $("#txtHotItemDisplay").val(),
            hotItemId: $('#hId').val(),
            //ReportTypeId: reporttypeid,
            VestasItemNumber: $("#txtVestasItemNumber").val(),
            VestasItemName: $("#txtVestasItemName").val(),
            ManufacturerName: $("#txtManufacturerName").val(),
            Email: $("#txtTo").val(),
            cc: $("#txtCc").val(),
            //HotlistDisplay: $("#txtHotlistDisplay").val()
            hotItemDisplay: $("#txtVestasItemNumber").val() + $("#ddlBrand option:selected").text() + $("#ddlTemplate option:selected").text() + ":" + $("#txtVestasItemName").val()
        };
        if ($("#hId").val() == "") {
            alert("Invalid Hotlist!");
            return;
        }

        //if ($.trim($('#ddlInspectionReportType').val()) == '') {
        //    $('#ddlInspectionReportType').addClass('validationerror red-tooltip');
        //    // ScrollTo('txtCimNo');
        //    return;
        //}

        if ($.trim($('#txtVestasItemNumber').val()) == '') {
            $('#txtVestasItemNumber').addClass('validationerror red-tooltip');
            // ScrollTo('txtCimNo');
            return;
        }

        if ($.trim($('#txtVestasItemName').val()) == '') {
            $('#txtVestasItemName').addClass('validationerror red-tooltip');
            // ScrollTo('txtCimNo');
            return;
        }

        if ($.trim($('#txtManufacturerName').val()) == '') {
            $('#txtManufacturerName').addClass('validationerror red-tooltip');
            // ScrollTo('txtCimNo');
            return;
        }
        if ($.trim($('#txtTo').val()) == '') {
            $('#txtTo').addClass('validationerror red-tooltip');
            // ScrollTo('txtCimNo');
            return;
        }

        if (parseInt($("#hId").val()) > 0) {
            CirAlert.confirm('Are you sure you want to update this hotlist item?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                //CallClientApi("Hotlist", "POST", m).done(function (data) {
                CallSyncApi("HotlistData/Update", "POST", m).done(function (data) {
                    NotifyCirMessage('', 'Hotlist updated!', 'info');
                    cirhotlist.loadHotlist();
                    $("#myDetailsModal").modal('hide');
                });
            });
        }
        else {
            //CallClientApi("Hotlist", "POST", m).done(function (data) {
            CallSyncApi("HotlistData/Send", "POST", m).done(function (data) {
                NotifyCirMessage('', 'Hotlist created!', 'info');
                cirhotlist.loadHotlist();
                $("#myDetailsModal").modal('hide');
            });
        }
    }

    this.loadHotlist = function () {
        //var type = $('#ddlManufacturerType').val();
        cirhotlist.getallhotlist().done(function (data) {
            var tbllocalHotlistTable = null;
            if (data.length == 0) {
                tbllocalHotlistTable = $('#localHotlistTable').DataTable({
                    destroy: true,
                    "searching": false,
                    "paging": false

                });

            }
            else {
                tbllocalHotlistTable = $('#localHotlistTable').DataTable({
                    destroy: true,
                    "searching": true,
                    "paging": true

                });
            }
            tbllocalHotlistTable.clear().draw();
            $.each(data, function (i, item) {

                //var reporttypename;

                //if (item.reportTypeId == 1) {
                //    reporttypename = "Blade";

                //}
                //else if (item.reportTypeId == 2) {
                //    reporttypename = "Gearbox";

                //}
                //else if (item.reportTypeId == 3) {

                //    reporttypename = "General";

                //}
                //else if (item.reportTypeId == 4) {
                //    reporttypename = "Generator";


                //}
                //else if (item.reportTypeId == 5) {
                //    reporttypename = "Transformer";

                //}
                //else if (item.reportTypeId == 6) {

                //    reporttypename = "Main Bearing";

                //}
                //else if (item.reportTypeId == 7) {
                //    reporttypename = "Skiipack";

                //}

                var brandTemplate = item.brand.name + " " + item.cirTemplate.name;

                var showChar = 2;
                tbllocalHotlistTable.row.add(['<a title="Edit Hotlist" href=javascript:cirhotlist.edithotlist(' + item.hotItemId + ');><i style="color:#0000ff;" class="fa fa-pencil-square-o fa-lg"></i></a></a>'
                     + '&nbsp;' + '&nbsp;' + '&nbsp;' + '<a title="Delete Hotlist" id="' + item.hotItemId + '" href="javascript:void(0);" value="Do you wish to delete this Hotlist Item" class="btn-delete deletehotlist"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg "></i></a>',
                    /*reporttypename*/brandTemplate, item.vestasItemNumber, item.vestasItemName, item.manufacturerName, item.email, item.cc,item.hotItemDisplay]).draw(false);

            });
            waitingDialog.hide();
        });

    };

    this.edithotlist = function (id) {
        $('#txtVestasItemNumber,txtVestasItemName,txtManufacturerName,#txtTo,#txtCc,#txtHotlistDisplay').removeClass('validationerror red-tooltip');
        $("#hId").val(id);
        $("#txtHdnAzureId").val("");
        $("#ddlBrand").val(null);
        $("#ddlTemplate").val(null);
        //$("#txtReportType").val("");
        $("#txtHotItemDisplay").val("");
        //$("#ddlInspectionReportType").val("");
        $("#txtVestasItemNumber").val("");
        $("#txtVestasItemName").val("");
        $("#txtManufacturerName").val("");
        $("#txtTo").val("");
        $("#txtCc").val("");
        $("#txtHotlistDisplay").val("");
        var HotlistHeader = "";
        if (id > 0) {
            HotlistHeader = "Update " + " Hotlist Item";
            cirhotlist.gethotlist(id).done(function (data) {
                $("#hId").val(data.hotItemId);

                //var reporttypename;

                //if (data.reportTypeId == 1) {
                //    reporttypename = "Blade";


                //}
                //else if (data.reportTypeId == 2) {
                //    reporttypename = "Gearbox";

                //}
                //else if (data.reportTypeId == 3) {

                //    reporttypename = "General";

                //}
                //else if (data.reportTypeId == 4) {
                //    reporttypename = "Generator";


                //}
                //else if (data.reportTypeId == 5) {
                //    reporttypename = "Transformer";

                //}
                //else if (data.reportTypeId == 6) {

                //    reporttypename = "Main Bearing";

                //}
                //else if (data.reportTypeId == 7) {
                //    reporttypename = "Skiipack";

                //}
                $("#txtHdnAzureId").val(data.id);
                $("#ddlBrand").val(data.brand.id);

                cirhotlist.PopulateTemplates(data.cirTemplate.id);

                //$("#ddlTemplate").val(data.cirTemplate.id);
                //$("#txtReportType").val(data.reportType);
                $("#txtHotItemDisplay").val(data.hotItemDisplay);
                //$("#ddlInspectionReportType").val(reporttypename);
                $("#txtVestasItemNumber").val(data.vestasItemNumber);
                $("#txtVestasItemName").val(data.vestasItemName);
                $("#txtManufacturerName").val(data.manufacturerName);
                $("#txtTo").val(data.email);
                $("#txtCc").val(data.cc);
                $("#txtHotlistDisplay").val(data.hotItemDisplay);
                $("#myDetailsModal").find('.modal-title').text(HotlistHeader);
                $("#myDetailsModal").modal('show');
                $("#hId").val(id);
                $("#txtHotlistDisplay").attr("disabled", "disabled");
            })
            .fail(function () {
                NotifyCirMessage('Error', 'Error occured while loadding hotlist!', 'error');
                $("#myDetailsModal").modal('hide');
            });

        }
        else {

            //create new hotlist item
            HotlistHeader = "Add New " + "Hotlist Item";
            $("#myDetailsModal").find('.modal-title').text(HotlistHeader);
            $("#myDetailsModal").modal('show');
            $("#txtHotlistDisplay").attr("disabled", "disabled");
            $("#hId").val(id);
            $("#txtHdnAzureId").val(cirOfflineApp.generateKey());
            $("#ddlBrand").val(null);
            $("#ddlTemplate").val(null);
            $("#txtReportType").val("");
            $("#txtHotItemDisplay").val("");
        }
    }

    this.LoadDropDowns = function (callback) {
        var selectelements = $('*[data-fieldType="Blade"]');
        var elecount = selectelements.length;
        selectelements.each(function (index) {
            dbtransaction.BindDropDown($(this), index, function (selectitem, compltedidx) {
                if (compltedidx >= elecount) {
                    callback();
                }
            });
        });

        var ddlBrand = $('#ddlBrand');
        ddlBrand.append($("<option />").val("").text("Please select Brand"));
        this.LoadBrands().done(function (brands) {
            $.each(brands, function () {
                ddlBrand.append($("<option />").val(this.id).text(this.name));
            });
        });
    }

    this.LoadBrands = function () {
        var deferredObject = $.Deferred();
        cirOfflineApp.GetCirTemplateList().done(function (templates) {
            let brandList = [];
            templates.map(t => { return { id: t.cirBrand.id, name: t.cirBrand.name } })
                .forEach(function (item, idx) {
                    if (!brandList.filter(x => x.id == item.id)[0]) {
                        brandList.push(item);
                    }
                });
            deferredObject.resolve(brandList);
        });

        return deferredObject.promise();
    }

    this.LoadTemplates = function () {
        var deferredObject = $.Deferred();
        cirOfflineApp.GetCirTemplateList().done(function (templates) {
            deferredObject.resolve(templates);
        });

        return deferredObject.promise();
    }

    this.PopulateTemplates = function (defaultValue) {
        var selectedBrand = $('#ddlBrand option:selected');
        var ddlTemplate = $('#ddlTemplate');

        ddlTemplate.empty();

        cirhotlist.LoadTemplates().done(function (templates) {

            var filteredTemplates = templates.filter(template => template.cirBrand.id === selectedBrand.val());

            $.each(filteredTemplates, function () {
                ddlTemplate.append($("<option />").val(this.id).text(this.name));
            });

            if (defaultValue) {
                ddlTemplate.val(defaultValue);
            }
        });
    }
}

$(document).ready(function () {

    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
    cirhotlist.loadHotlist();
    $('body').on('click', '.AddHotlist', function () {
        $("#btnNew").html('<i style="color: #ffffff;" class="fa fa-plus"></i>Create New' + ' Hotlist');
        cirhotlist.edithotlist(0);
    });

    cirhotlist.LoadDropDowns();

    $('body').on('click', '.deletehotlist', function () {
        var HotlistId = $(this).attr('id');
        var cirHead = $(this).attr('value');
        if (!HotlistId)
            return;

        CirAlert.confirm(cirHead, 'Cir App', 'Yes', 'No', 'warning').done(function () {
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            cirhotlist.deleteHotlist(HotlistId);
        });
    });

    $('#ddlBrand').on('change', function () {
        cirhotlist.PopulateTemplates();
    });
})