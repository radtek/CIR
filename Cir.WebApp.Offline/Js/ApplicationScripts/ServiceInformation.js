
(function ($) {
    $.ServiceInformation = function () {
        this.Id = 0;
        this.SeverityId = 0;
        this.StrFromDate = "";
        this.StrToDate = "";
        this.Message = "";
        this.Deleted = false;
        this.Created = null;
        this.CreatedBy = null;
        this.Modified = null;
        this.ModifiedBy = null;
    };

    //assigning an object literal to the prototype is a shorter syntax
    //than assigning one property at a time
    $.ServiceInformation.prototype = {
        Load: function (id) {
            var deferredObject = $.Deferred();
            if (id > 0) {
                this.Id = id;
                CallClientApi("ServiceInformations/" + this.Id, "GET", null).done(function (result) {
                    this.Id = result.id;
                    this.SeverityId = result.severityId;
                    this.StrFromDate = result.strFromDate;
                    this.StrToDate = result.strToDate;
                    this.Message = result.message;
                    this.Deleted = result.deleted;
                    this.Created = result.created;
                    this.CreatedBy = result.createdBy;
                    this.Modified = result.modified;
                    this.ModifiedBy = result.modifiedBy;
                    deferredObject.resolve(this);
                }).fail(function (e) {
                    console.log(e);
                    deferredObject.reject();
                });
            }
            else {
                deferredObject.resolve(this);
            }
            return deferredObject.promise();
        },
        Save: function () {

        },
        Delete: function () {

        },
    };

}(jQuery));

var ServiceInfoEditor = ServiceInfoEditor || (function ($) {
    'use strict';

    // Creating modal dialog's DOM
    var $dialog = $('<div class="modal fade" id="ServiceInfoEditor" data-backdrop="static" data-keyboard="false" tabindex="-1" role="dialog"> <div class="modal-dialog" style="width: 70%;"> <div class="modal-content" data-id="0"> <div class="modal-header"> <button type="button" class="close" data-dismiss="modal">&times;</button> <h5 class="modal-title"></h5> </div><div class="modal-body"> <div class="spinner circles-loader">Please wait...</div> <div class="form-group"> <label class="col-lg-3 control-label">Severity<span class="errorSpan">*</span></label> <div class="col-lg-9"> <select id="ddlSeverity" name="SeverityId" class="form-control"> </select> </div></div><div class="form-group"> <label class="col-lg-3 control-label">From Date/Time<span class="errorSpan">*</span></label> <div class="col-lg-9"> <input type="text" id="txtServiceInfoFromDate" name="StrFromDate" placeholder="From Date" readonly class="form-control"/> </div></div><div class="form-group"> <label class="col-lg-3 control-label">To Date/Time<span class="errorSpan">*</span></label> <div class="col-lg-9"> <input type="text" id="txtServiceInfoToDate" name="StrToDate" placeholder="To Date" readonly class="form-control form_datetime"/> </div></div><div class="form-group"> <label class="col-lg-3 control-label">Message<span class="errorSpan">*</span></label> <div class="col-lg-9"> <textarea id="txtServiceInfoDescription" name="Message" data-toggle="tooltip" data-placement="top" title="Enter Message" class="form-control" style="width: 100%; height: 150px;" placeholder="Message" maxlength="4000"></textarea> </div></div><div class="form-group"  style="text-align:right"> <button type="button" class="btn btn-primary" id="btnsisave" onclick="ServiceInfoEditor.save();">Save changes</button> <button type="button" class="btn btn-default" data-dismiss="modal">Close</button> </div></div></div></div></div>');
    var objServiceInformation = new $.ServiceInformation();
    $dialog.find("#btnsisave").text("Save");
    $dialog.find("#txtServiceInfoFromDate").datetimepicker({
        format: "dd-mm-yyyy hh:ii",
        autoclose: true,
        // todayBtn: true,
        startDate: "2013-02-14 10:00",
        minuteStep: 10
    }).on('changeDate', function (selected) {
        var minDate = new Date(selected.date.valueOf());
        $dialog.find("#txtServiceInfoFromDate").datetimepicker({
            format: "dd-mm-yyyy hh:ii",
            autoclose: true,
            // todayBtn: true,
            startDate: minDate,
            minuteStep: 10
        });
    });
    $dialog.find("#txtServiceInfoToDate").datetimepicker({
        format: "dd-mm-yyyy hh:ii",
        autoclose: true,
        //  todayBtn: true,
        startDate: "2013-02-14 10:00",
        minuteStep: 10
    });
    $dialog.find("#txtServiceInfoFromDate").on('change', function () {
        var mindate = $dialog.find("#txtServiceInfoFromDate").val();
        $dialog.find("#txtServiceInfoFromDate").datetimepicker({
            format: "dd-mm-yyyy hh:ii",
            autoclose: true,
            // todayBtn: true,
            startDate: mindate,
            minuteStep: 10
        });
    });
    $dialog.find("textarea[name='Message']").on('change', function () {
        if ($dialog.find("textarea[name='Message']").val().trim() == '') {
            $dialog.find("textarea[name='Message']").addClass('validationerror red-tooltip');
        }
        else {
            $dialog.find("textarea[name='Message']").removeClass('validationerror red-tooltip');
        }
    });
    $dialog.find("input[name='StrFromDate']").on('change', function () {
        if ($dialog.find("input[name='StrFromDate']").val().trim() == '') {
            $dialog.find("textarea[name='Message']").addClass('validationerror red-tooltip');
        }
        else {
            $dialog.find("input[name='StrFromDate']").removeClass('validationerror red-tooltip');
        }
        var stDate = Date.parse($dialog.find("input[name='StrFromDate']").val());
        var toDate = Date.parse($dialog.find("input[name='StrToDate']").val());
        if (toDate <= stDate) {
            $dialog.find("input[name='StrToDate']").addClass('validationerror red-tooltip');
        }
        else {
            $dialog.find("input[name='StrFromDate']").removeClass('validationerror red-tooltip');
        }
    });
    $dialog.find("input[name='StrToDate']").on('change', function () {
        if ($dialog.find("input[name='StrToDate']").val().trim() == '') {
            $dialog.find("input[name='StrToDate']").addClass('validationerror red-tooltip');
        }
        else {
            $dialog.find("input[name='StrToDate']").removeClass('validationerror red-tooltip');
        }
        var stDate = Date.parse($dialog.find("input[name='StrFromDate']").val());
        var toDate = Date.parse($dialog.find("input[name='StrToDate']").val());
        if (toDate <= stDate) {
            $dialog.find("input[name='StrToDate']").addClass('validationerror red-tooltip');
        }
        else {
            $dialog.find("input[name='StrFromDate']").removeClass('validationerror red-tooltip');
        }
    });

    var validate = function () {
        var iSValid = true;
        if ($dialog.find("textarea[name='Message']").val().trim() == '') {
            $dialog.find("textarea[name='Message']").addClass('validationerror red-tooltip');
            iSValid = false;
        }
        else {
            $dialog.find("textarea[name='Message']").removeClass('validationerror red-tooltip');
        }
        if ($dialog.find("input[name='StrFromDate']").val().trim() == '') {
            $dialog.find("input[name='StrFromDate']").addClass('validationerror red-tooltip');
            iSValid = false;
        }
        else {
            $dialog.find("input[name='StrFromDate']").removeClass('validationerror red-tooltip');
        }
        if ($dialog.find("input[name='StrToDate']").val().trim() == '') {
            $dialog.find("input[name='StrToDate']").addClass('validationerror red-tooltip');
            iSValid = false;
        }
        else {
            $dialog.find("input[name='StrToDate']").removeClass('validationerror red-tooltip');
        }
        var stDate = Date.parse($dialog.find("input[name='StrFromDate']").val());
        var toDate = Date.parse($dialog.find("input[name='StrToDate']").val());
        if (iSValid) {
            if (toDate <= stDate) {
                $dialog.find("input[name='StrToDate']").addClass('validationerror red-tooltip');
                iSValid = false;
            }
            else {
                $dialog.find("input[name='StrFromDate']").removeClass('validationerror red-tooltip');
            }
        }
        return iSValid;
    }
    return {
        /**
		 * Opens ServiceInfoEditor
		 * @param ServiceInformationId. "0" to create new and others to edit
		 */
        show: function (ServiceInformationId) {
            try {
                objServiceInformation = new $.ServiceInformation();
                $dialog.find("#btnsisave").text("Save");
                $dialog.find("#btnsisave").show();
                $dialog.find("#btnsisave").attr('disabled', false);
                $dialog.find("textarea[name='Message']").removeClass('validationerror red-tooltip');
                $dialog.find("input[name='StrToDate']").removeClass('validationerror red-tooltip');
                $dialog.find("input[name='StrFromDate']").removeClass('validationerror red-tooltip');
                $dialog.find('.spinner').show();
                $dialog.find('.form-group').hide();
                CallClientApi("Severity", "GET", null).done(function (result) {

                    if (result) {
                        if (result.length > 0)
                            result.forEach(function (item) {
                                $dialog.find('#ddlSeverity').append($('<option>', {
                                    value: item.id,
                                    text: item.name
                                }));
                            });
                        objServiceInformation.Load(ServiceInformationId).done(function (obj) {
                            objServiceInformation = obj;
                            var options = {};
                            var settings = $.extend({
                                dialogSize: 'm',
                                progressType: '',
                                onHide: null // This callback runs after the dialog was hidden
                            }, options);

                            if (ServiceInformationId == 0) {
                                $dialog.find('h5').text("Create new Service Information");
                            }
                            else {
                                $dialog.find('h5').text("Edit Service Information");
                            }
                            $.each(objServiceInformation, function (key, value) {
                                $dialog.find("input[name='" + key + "'],select[name='" + key + "'],textarea[name='" + key + "']").val(value);
                            });
                            $dialog.find('.modal-content').attr('data-id', objServiceInformation.Id);
                            $dialog.find('.spinner').hide();
                            $dialog.find('.form-group').show();
                            // Opening dialog
                            $dialog.modal();

                        }).fail(function () {
                            throw 'error in loading service inforamation data';
                        });
                    }
                    else {
                        throw "Unable to load Severity";
                    }

                });


            }
            catch (ex) {
                console.log(ex);
                if (OnError != null)
                    OnError();
            }
        },
        view: function (ServiceInformationId) {
            try {
                objServiceInformation = new $.ServiceInformation();
                $dialog.find("#btnsisave").hide();
                $dialog.find("#btnsisave").attr('disabled', false);
                $dialog.find("textarea[name='Message']").removeClass('validationerror red-tooltip');
                $dialog.find("input[name='StrToDate']").removeClass('validationerror red-tooltip');
                $dialog.find("input[name='StrFromDate']").removeClass('validationerror red-tooltip');
                $dialog.find('.spinner').show();
                $dialog.find('.form-group').hide();
                CallClientApi("Severity", "GET", null).done(function (result) {

                    if (result) {
                        if (result.length > 0)
                            result.forEach(function (item) {
                                $dialog.find('#ddlSeverity').append($('<option>', {
                                    value: item.id,
                                    text: item.name
                                }));
                            });
                        objServiceInformation.Load(ServiceInformationId).done(function (obj) {
                            objServiceInformation = obj;
                            var options = {};
                            var settings = $.extend({
                                dialogSize: 'm',
                                progressType: '',
                                onHide: null // This callback runs after the dialog was hidden
                            }, options);


                            $dialog.find('h5').text("Service Information Details");

                            $.each(objServiceInformation, function (key, value) {
                                $dialog.find("input[name='" + key + "'],select[name='" + key + "'],textarea[name='" + key + "']").val(value);
                            });
                            $dialog.find('.modal-content').attr('data-id', objServiceInformation.Id);
                            $dialog.find('.spinner').hide();
                            $dialog.find('.form-group').show();
                            // Opening dialog
                            $dialog.modal();

                        }).fail(function () {
                            throw 'error in loading service inforamation data';
                        });
                    }
                    else {
                        throw "Unable to load Severity";
                    }

                });


            }
            catch (ex) {
                console.log(ex);
                NotifyCirMessage("Service Information : ",ex, "danger");
            }
        },
        save: function (Onsucess, OnError) {
            try {
                var iSValid = validate();
                if (iSValid == false)
                    throw 'Validation error';
                $dialog.find("#btnsisave").text("Please wait...");
                $dialog.find("#btnsisave").attr('disabled', true);
                objServiceInformation.SeverityId = $dialog.find("select[name='SeverityId']").val();
                objServiceInformation.StrFromDate = $dialog.find("input[name='StrFromDate']").val();
                objServiceInformation.StrToDate = $dialog.find("input[name='StrToDate']").val();
                objServiceInformation.Message = $dialog.find("textarea[name='Message']").val().replace(/(?:\r\n|\r|\n)/g, '<br />');
                objServiceInformation.Id = $dialog.find('.modal-content').attr('data-id');
                CallClientApi("ServiceInformations", "PUT", objServiceInformation).done(function () {
                    NotifyCirMessage("Service Information : ", "Saved Successfully!", "success");
                    $dialog.modal('hide');

                    setTimeout(function () { location = location.href }, 1000);

                }).fail(function (e) {
                    NotifyCirMessage("Service Information : ", "Error in saving data", "danger");
                    $dialog.modal('hide');
                    console.log(e);
                    
                });

                //return objServiceInformation;
            }
            catch (ex) {
                console.log(ex);
               
            }
        },
        /**
		 * Closes dialog
		 */
        hide: function () {
            $dialog.modal('hide');
        }

    };

})(jQuery);


