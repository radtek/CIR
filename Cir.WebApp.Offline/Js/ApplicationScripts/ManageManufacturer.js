var cirManufacturer = new function () {

    this.ManufacturerList = {
        manufacturerType: 0,
        manufacturers: []
    };

    this.Manufacturer = {
        manufacturerType: 0,
        id: 0,
        name: "",
        contact: "",
        to: "",
        cc: ""
    };

    this.getManufacturer = function (typeid, id) {
        var deferredObject = $.Deferred();
        CallClientApi("Manufacturer/" + typeid + "/" + id, "GET", "").done(function (data) {
            deferredObject.resolve(data);
        })
        .fail(function () {
            deferredObject.reject();
        });

        return deferredObject.promise();
    }

    this.getManufacturerList = function (typeid) {
        var deferredObject = $.Deferred();
        CallClientApi("ManufacturerList/" + typeid, "GET", "").done(function (data) {
            deferredObject.resolve(data);
        })
        .fail(function () {
            deferredObject.reject();
        });

        return deferredObject.promise();
    }

    this.deleteManufacturer = function (typeid, id) {
    
        CallClientApi("Manufacturer?type=" + typeid + "&id=" + id, "DELETE", "").done(function (data) {
            if (data == true) {
                NotifyCirMessage('', 'Manufacturer deleted!', 'info');
                cirManufacturer.loadManufacturer($('#ddlManufacturerType').val());
            }
            else
                NotifyCirMessage('Error', 'Error occured while deleting manufacturer!', 'danger');

        });
    }

    this.saveManufacturer = function () {
        var m = {
            manufacturerType: $('#ddlManufacturerType').val(),
            id: $("#hId").val(),
            name: $("#txtManufacturerName").val(),
            contact: $("#txtContactName").val(),
            to: $("#txtTo").val(),
            cc: $("#txtCc").val()
        };
        if ($("#hId").val() == "")
        {
            CirAlert.alert('Invalid Manufacturer!', 'Cir App', null, 'error').done(function () {
                return;
            });
            //alert("Invalid Manufacturer!");
            return;
        }
        if ($.trim($('#txtManufacturerName').val()) == '') {
            $('#txtManufacturerName').addClass('validationerror red-tooltip');
            ScrollTo('txtCimNo');
            return;
        }
       
        if (parseInt($("#hId").val()) > 0) {
            CirAlert.confirm('Are you sure you want to update this manufacturer?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                      CallClientApi("Manufacturer", "POST", m).done(function (data) {
                    if (data == true) {
                        NotifyCirMessage('', 'Manufacturer updated!', 'info');
                        cirManufacturer.loadManufacturer($('#ddlManufacturerType').val());
                    }
                    else
                        NotifyCirMessage('Error', 'Error occured while updating manufacturer!', 'danger');
                    $("#myDetailsModal").modal('hide');

                });
            });
        }
        else {
            CallClientApi("Manufacturer", "POST", m).done(function (data) {
                if (data == true) {
                    NotifyCirMessage('', 'Manufacturer created!', 'info');
                    cirManufacturer.loadManufacturer($('#ddlManufacturerType').val());
                }
                else
                    NotifyCirMessage('Error', 'Error occured while creating manufacturer!', 'danger');

                $("#myDetailsModal").modal('hide');
            });
        }
    }

    this.loadManufacturer = function (type) {
        //var type = $('#ddlManufacturerType').val();
        cirManufacturer.getManufacturerList(type).done(function (data) {
            var tbllocalManufacturerTable = null;
            if (data.manufacturers.length == 0) {
                tbllocalManufacturerTable = $('#localManufacturerTable').DataTable({
                    destroy: true,
                    "searching": false,
                    "paging": false
                   
                });

            }
            else {
                tbllocalManufacturerTable = $('#localManufacturerTable').DataTable({
                    destroy: true,
                    "searching": true,
                    "paging": true
                    
                });
            }
            tbllocalManufacturerTable.clear().draw();
            $.each(data.manufacturers, function (i, item) {


                tbllocalManufacturerTable.row.add(['<a title="Edit Manufacturer" href=javascript:cirManufacturer.editManufacturer(' + item.id + ');><i style="color:#0000ff;" class="fa fa-pencil-square-o fa-lg"></i></a></a>',
                    item.name, item.contact, item.to, item.cc]).draw(false);

            });
            waitingDialog.hide();
        });

    };

    this.editManufacturer = function (id) {
        $('#txtManufacturerName,#txtContactName,#txtTo,#txtCc').removeClass('validationerror red-tooltip');

        $("#hId").val(id);        
        $("#txtManufacturerName").val("");
        $("#txtContactName").val("");
        $("#txtTo").val("");
        $("#txtCc").val("");       
        var ManufacturerHeader = "";
        if (id > 0) {
            ManufacturerHeader = "Update " + $('#ddlManufacturerType  option:selected').text() + " Manufacturer";
            cirManufacturer.getManufacturer($('#ddlManufacturerType').val(), id).done(function (data) {
                $("#hId").val(data.id);
                $("#txtManufacturerName").val(data.name);
                $("#txtContactName").val(data.contact);
                $("#txtTo").val(data.to);
                $("#txtCc").val(data.cc);
                $("#myDetailsModal").find('.modal-title').text(ManufacturerHeader);
                $("#myDetailsModal").modal('show');
                $("#hId").val(id);
                $("#txtManufacturerName").attr("disabled", "disabled");
            })
            .fail(function () {
                NotifyCirMessage('Error', 'Error occured while loadding manufacturer!', 'danger');
                $("#myDetailsModal").modal('hide');
            });

        }
        else {
            ManufacturerHeader = "Add New " + $('#ddlManufacturerType  option:selected').text() + " Manufacturer";
            $("#myDetailsModal").find('.modal-title').text(ManufacturerHeader);
            $("#myDetailsModal").modal('show');
            $("#txtManufacturerName").removeAttr("disabled");
            $("#hId").val(id);
        }
       
    }

    this.deleteManufacturerData = function (id) {
        var type = $('#ddlManufacturerType').val();
        if (parseInt(id) > 0) {
            CirAlert.confirm('Are you sure you want to delete this manufacturer?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                cirManufacturer.deleteManufacturer(type, id);
            });
        }
        else
        {
            CirAlert.alert('Invalid Manufacturer!', 'Cir App', null, 'error').done(function () {
                return;
            });
           
        }

    }

   

}



$(document).ready(function () {

    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
    cirManufacturer.loadManufacturer(1);
    $('body').on('click', '.AddManufacturer', function () {       
        cirManufacturer.editManufacturer(0);
    });

   
    $('#ddlManufacturerType').change(function (event) {
        $("#btnNew").html('<i style="color: #ffffff;" class="fa fa-plus"></i>Create New ' + $('#ddlManufacturerType  option:selected').text() + ' Manufacturer');
        cirManufacturer.loadManufacturer($(this).val());
    });

});

