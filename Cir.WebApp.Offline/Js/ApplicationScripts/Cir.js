
// override jQuery val function for conflict handling of cir template.
// this function will check if the object passed as argument is undefined then
// it will use '' to set the value of input element.
// the changes made is aonly efective for setter no change in getter
// Created By : Mukul Keshari
// Created on : 12-Nov-2015
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


function GetTypeIfDamage(elementCount, seloption) {
    dbtransaction.getItemfromTable('GearDamageCategory', renderGearDamageCategory);
    //Rendring items in list
    function renderGearDamageCategory(gearDamageCategory) {
        $('#ddlTypeIfDamage' + elementCount).empty();
        $('#ddlTypeIfDamage' + elementCount).append($('<option>', {
            value: "",
            text: " "
        }));
        gearDamageCategory.forEach(function (item) {

            $('#ddlTypeIfDamage' + elementCount).append($('<option>', {
                value: item.GearDamageCategoryID,
                text: item.text
            }));

        });
        var my_options = $('#ddlTypeIfDamage' + elementCount + " option");

        my_options.sort(function (a, b) {
            if (a.text > b.text) return 1;
            else if (a.text < b.text) return -1;
            else return 0
        })

        if ($('#ddlExactLocation' + elementCount).val() == 2000) {//Not required now
            $('#ddlTypeIfDamage' + elementCount).empty();
            $('#ddlDamageClass' + elementCount).empty();
            $('#ddlDecision' + elementCount).empty();
            $('#ddlDecision' + elementCount).prop("disabled", false);
        }
        else {

            $('#ddlTypeIfDamage' + elementCount).append(my_options);
            if (typeof seloption == 'undefined' || seloption == null)
                $('#ddlTypeIfDamage' + elementCount).val($('#ddlTypeIfDamage' + elementCount + " option:first").val());
            else
                $('#ddlTypeIfDamage' + elementCount + " option[value=" + seloption + "]").prop('selected', true);

        }
        CalculateTotalPercentage();
    }
}

function GetBearingDamage(elementCount, seloption) {

    dbtransaction.getItemfromTable('Damage', renderBearingDamage);
    //Rendring items in list
    var i = 1;
    function renderBearingDamage(damage) {
        $('#ddlBearingDamageClass' + elementCount).empty();
        $('#ddlBearingDamageClass' + elementCount).append($('<option>', {
            value: "",
            text: " "
        }));

        damage.forEach(function (item) {
            if (item.DamageID == i) {
                $('#ddlBearingDamageClass' + elementCount).append($('<option>', {
                    value: item.DamageID,
                    text: item.text
                }));
                i++;
            }
        });
        if (typeof seloption != 'undefined')
            $('#ddlBearingDamageClass' + elementCount + " option[value=" + seloption + "]").prop('selected', true);
        else
            $('#ddlBearingDamageClass' + elementCount).val($('#ddlBearingDamageClass' + elementCount + " option:first").val());
    }

}


function GetGearsDamage(elementCount) {

    dbtransaction.getItemfromTable('DamageClassCategoryDecision', renderDamageClassCategoryDecision);
    //Rendring items in list
    var res = [];
    var StrDecision;

    function renderDamageClassCategoryDecision(damageClassCategoryDecision) {
        damageClassCategoryDecision.forEach(function (item) {

            var ArrayDecision = item.text.split(',');
            if ($('#ddlTypeIfDamage' + elementCount).val() == ArrayDecision[0] && $('#ddlDamageClass' + elementCount).val() == ArrayDecision[1]) {
                StrDecision = ArrayDecision[2];
            }
        });
        $('#ddlDecision' + elementCount + " option[value=" + StrDecision + "]").prop('selected', true);
    }

    dbtransaction.getItemfromTable('DamageDecision', renderDamageDecision);
    //Rendring items in list

    function renderDamageDecision(damageDecision) {
        $('#ddlDecision' + elementCount).empty();
        damageDecision.forEach(function (item) {
            //if ($('#ddlDamageClass' + elementCount).val() == 2) {
            //if (item.text == "Re-use") {
            $('#ddlDecision' + elementCount).append($('<option>', {
                value: item.DamageDecisionID,
                text: item.text
            }));
            //}
            //}
            //else if ($('#ddlDamageClass' + elementCount).val() == 3 || $('#ddlDamageClass' + elementCount).val() == 4 || $('#ddlDamageClass' + elementCount).val() == 5) {
            //    if (item.text == "Re-work") {
            //        $('#ddlDecision' + elementCount).append($('<option>', {
            //            value: item.DamageDecisionID,
            //            text: item.text
            //        }));
            //    }
            //}
        });
        $('#ddlDecision' + elementCount).prop("disabled", true);
    }


}

function GetDamageClass(GearDamageCategoryID, elementCount) {
    dbtransaction.getItemfromTable('DamageParentGearError', renderDamageParentGearError);
    //Rendring items in list
    var res = [];
    function renderDamageParentGearError(damageParentGearError) {
        damageParentGearError.forEach(function (item) {
            //for (var elementCount = 1; elementCount <= 15; elementCount++)
            temp = item.text.split(",");
            if (item.text.substring(0, item.text.indexOf(",")) == GearDamageCategoryID) {
                res.push(item.text.substring(item.text.indexOf(",") + 1, item.text.length));

            }
        });
    }

    $('#ddlDamageClass' + elementCount).empty();
    $('#ddlDecision' + elementCount).empty();
    $('#ddlDamageClass' + elementCount).append($('<option>', {
        value: 0,
        text: ""
    }));
    dbtransaction.getItemfromTable('Damage', renderDamage);
    //Rendring items in list
    function renderDamage(damage) {
        res.forEach(function (entry) {
            damage.forEach(function (item) {
                if (item.DamageID == entry) {
                    $('#ddlDamageClass' + elementCount).append($('<option>', {
                        value: item.DamageID,
                        text: item.text
                    }));
                }
            });
        });
    }

}

function GetDamageClass(GearDamageCategoryID, elementCount, StrDecision) {
    dbtransaction.getItemfromTable('DamageParentGearError', renderDamageParentGearError);
    //Rendring items in list
    var res = [];
    function renderDamageParentGearError(damageParentGearError) {
        damageParentGearError.forEach(function (item) {
            //for (var elementCount = 1; elementCount <= 15; elementCount++)
            temp = item.text.split(",");
            if (item.text.substring(0, item.text.indexOf(",")) == GearDamageCategoryID) {
                res.push(item.text.substring(item.text.indexOf(",") + 1, item.text.length));

            }
        });
    }

    $('#ddlDamageClass' + elementCount).empty();
    $('#ddlDecision' + elementCount).empty();
    $('#ddlDamageClass' + elementCount).append($('<option>', {
        value: undefined,
        text: ""
    }));
    dbtransaction.getItemfromTable('Damage', renderDamage);
    //Rendring items in list
    function renderDamage(damage) {
        res.forEach(function (entry) {
            damage.forEach(function (item) {
                if (item.DamageID == entry) {
                    $('#ddlDamageClass' + elementCount).append($('<option>', {
                        value: item.DamageID,
                        text: item.text
                    }));
                }
            });
        });
        if (typeof StrDecision != 'undefined')
            $('#ddlDamageClass' + elementCount + " option[value=" + StrDecision + "]").prop('selected', true);
        else
            $('#ddlDamageClass' + elementCount).val($('#ddlDamageClass' + elementCount + " option:first").val());

        if ($('#ddlDamageClass' + elementCount).val() == "" || $('#ddlDamageClass' + elementCount).val() == null) {
            $('#ddlDecision' + elementCount).empty();
            $('#ddlDecision' + elementCount).prop("disabled", false);
        }
        else {
            $('#ddlDecision' + elementCount).prop("disabled", true);
        }
    }

}

var totalcountslocalhistory = 0;

function GetGearboxType(GearManufacturerID, selected) {

    $('#ddlGearboxGType').empty();

    dbtransaction.getItemfromTable('GearboxType', renderGearboxType);
    var res = [];
    function renderGearboxType(d) {
        d.forEach(function (item) {
            //for (var elementCount = 1; elementCount <= 15; elementCount++)
            if (item.text != null && item.text != "") {
                if ($('#ddlGearboxGManufacturer :selected').text() == "N/A") {
                    if (item.text == "0:N/A") {
                        res.push(item);
                    }
                }
                else if ($('#ddlGearboxGManufacturer :selected').text() == "Other Manufacturer") {
                    if (item.text == "0:N/A") {
                        res.push(item);
                    }
                }
                else {
                    var pid = item.text.split(":")[0];
                    var t = item.text.split(":")[1];
                    if (pid == GearManufacturerID) {
                        res.push(item);

                    }
                }
            }
        });
        res.sort(function (a, b) {
            if (a.text > b.text) return 1;
            else if (a.text < b.text) return -1;
            else return 0
        });
        if ($('#ddlGearboxGManufacturer :selected').text() == "N/A" || $('#ddlGearboxGManufacturer :selected').text() == "Other Manufacturer") {
        } else {
            $('#ddlGearboxGType').append($('<option>', {
                value: "",
                text: " "
            }));
        }
        res.forEach(function (item) {
            $('#ddlGearboxGType').append($('<option>', {
                value: item.GearboxTypeID,
                text: item.text.split(":")[1]
            }));
        });

        if (selected)
            $('#ddlGearboxGType' + "" + " option[value=" + selected + "]").prop('selected', true);


    }



}

function LoadPageData() {
    

    var deferredObject = $.Deferred();
    cirOfflineApp.getLocalDraftCount(getQueryStringValueHash('id')).done(function (count) {
        
            waitingDialog.show('Loading template..', { dialogSize: 'sm', progressType: 'primary' });
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
                    cirOfflineApp.LoadCIMCase().done(function () {
                        cirOfflineApp.loadGearTypeDamageDecision().done(function () {
                            dbtransaction.openDatabase(function () {
                                cirOfflineApp.LoadDropDowns().done(function () {
                                    $('#ddlServiceReportNumberType').change();
                                    deferredObject.resolve();
                                });
                            });
                        });

                    });

                });
            });
        
    });

    return deferredObject.promise();
}

$(document).ready(function () {

    $('#lblTurbineWait').hide();
    $('#lblTurbineWait_flang').hide();
    // NotifyCirMessage("", 'Choose the appropriate template from the CIR type or Hot list selectors below:<br /> 1. Blade, Gearbox, Generator and Transformer are mandatory. The templates can be found under "CIR type".<br /> 2. Hot list items are mandatory. The templates can be found under "Hot list". <br />3. Other types of the templates (General, Main Bearing and Skiipack) can be found under "CIR type".', "info");
    $('.Cir-help').css('cursor', 'pointer');

    $("[data-toggle=popover]").popover({
        container: 'body'
    });
    $('#cirDynamicTableLink').hide();
    $('#cirDynamicAccord1').hide();
    $('#cirDynamicAccord2').hide();
    $('#cirDynamicAccord3').hide();
    $('#cirDynamicAccord4').hide();
    $('#cirDynamicAccord5').hide();
    $('#cirDynamicAccord6').hide();
    $('#cirSBURecommendationLink').hide();
    $(".decimalsOnly").focusout(function (event) {
        if ($("#ddlCirType").val() != 8) {
            $("#" + this.id).removeClass('validationerror red-tooltip');
            $("#lblDecimalsOnly" + this.id).remove();
            if (/^(\d+(?:[\.\,]\d{1,2})?|)$/.test($(this).val()) || $(this).val() == '') {
            } else {
                $("#" + this.id).after('<label id="lblDecimalsOnly' + this.id + '" data-id="lblDecimalsOnly" style="color: red"> Please enter decimal values only!</label>');
                $("#" + this.id).addClass('validationerror red-tooltip');
            }
        }
        else {
            var parentdivId = $(this).closest('.ui-accordion-content-active').attr("id");
            if (parentdivId == "cirBladeSection") {
                $("#" + this.id).removeClass('validationerror red-tooltip');
                $("#lblDecimalsOnly" + this.id).remove();
                if (/^(\d+(?:[\.\,]\d{1,2})?|)$/.test($(this).val()) || $(this).val() == '') {
                } else {
                    $("#" + this.id).after('<label id="lblDecimalsOnly' + this.id + '" data-id="lblDecimalsOnly" style="color: red"> Please enter decimal values only!</label>');
                    $("#" + this.id).addClass('validationerror red-tooltip');
                }
            }
            else {
                $("#" + parentdivId + " #" + this.id).removeClass('validationerror red-tooltip');
                var lblerrorId = parentdivId + this.id;
                $("#lblDecimalsOnly" + lblerrorId).remove();
                if (/^(\d+(?:[\.\,]\d{1,2})?|)$/.test($("#" + parentdivId + " #" + this.id).val()) || $("#" + parentdivId + " #" + this.id).val() == '') {
                } else {
                    $("#" + parentdivId + " #" + this.id).after('<label id="lblDecimalsOnly' + lblerrorId + '" data-id="lblDecimalsOnly" style="color: red"> Please enter decimal values only!</label>');
                    $("#" + parentdivId + " #" + this.id).addClass('validationerror red-tooltip');
                }
            }
        }
    });

    $(".numbersOnly").focusout(function (event) {
        if ($("#ddlCirType").val() != 8) {
            $("#" + this.id).removeClass('validationerror red-tooltip');
            $("#lblNumbersOnly" + this.id).remove();
            if (/^\d+$/.test($(this).val()) || $(this).val() == '') {
            } else {
                $("#" + this.id).after('<label id="lblNumbersOnly' + this.id + '" data-id="lblNumbersOnly" style="color: red"> Please enter numbers only!</label>');
                $("#" + this.id).addClass('validationerror red-tooltip');
            }
        }
        else {
            var parentdivId = $(this).closest('.ui-accordion-content-active').attr("id");
            if (parentdivId == "cirBladeSection") {
                $("#" + this.id).removeClass('validationerror red-tooltip');
                $("#lblNumbersOnly" + this.id).remove();
                if (/^\d+$/.test($(this).val()) || $(this).val() == '') {
                } else {
                    $("#" + this.id).after('<label id="lblNumbersOnly' + this.id + '" data-id="lblNumbersOnly" style="color: red"> Please enter numbers only!</label>');
                    $("#" + this.id).addClass('validationerror red-tooltip');
                }
            }
            else {
                $("#" + parentdivId + " #" + this.id).removeClass('validationerror red-tooltip');
                var lblerrorId = parentdivId + this.id;
                $("#lblNumbersOnly" + lblerrorId).remove();
                if (/^\d+$/.test($("#" + parentdivId + " #" + this.id).val()) || $("#" + parentdivId + " #" + this.id).val() == '') {
                } else {
                    $("#" + parentdivId + " #" + this.id).after('<label id="lblNumbersOnly' + lblerrorId + '" data-id="lblNumbersOnly" style="color: red"> Please enter numbers only!</label>');
                    $("#" + parentdivId + " #" + this.id).addClass('validationerror red-tooltip');
                }
            }
        }

        // Backspace, tab, enter, end, home, left, right
        // We don't support the del key in Opera because del == . == 46.
        //var controlKeys = [8, 9, 13, 35, 36, 37, 39];
        //// IE doesn't support indexOf
        //var isControlKey = controlKeys.join(",").match(new RegExp(event.which));
        //// Some browsers just don't raise events for control keys. Easy.
        //// e.g. Safari backspace.
        //if (!event.which || // Control keys in most browsers. e.g. Firefox tab is 0
        //    (49 <= event.which && event.which <= 57) || // Always 1 through 9
        //    (48 == event.which && ($(this).val() >= 0)) || // No 0 first digit
        //    isControlKey) { // Opera assigns values for control keys.
        //    return;
        //} else {
        //    event.preventDefault();
        //}
    });
    $('.fixedRow').prop('readonly', 'true');



    LoadPageData().done(function () {
        console.log("page loaded");

        var id = getQueryStringValueHash('id');
        var RemoteCirID = getQueryStringValue('remotecirID');
        var CirrevisionID = getQueryStringValue('cirrevisionID');
        var tempkey = cirOfflineApp.generateKey();
        $('#CirDataCommonID').val((id == "" ? tempkey : id));
        $('#cirLocalID').val(0); // Local CIR ID
        if (id.length > 0) {
            setTimeout(function () {
                waitingDialog.updateMessage('Reading Draft data..');

                cirOfflineApp.loadCIRData(id).done(function () {
                    setTimeout(function () {
                        $("#ddlCirType").change(); cirOfflineApp.UpdateTemplateFields(); $("#ddlReportType").change(); waitingDialog.hide();
                        cirOfflineApp.StartSaveTimer();
                        setGeneratorInsulationData();
                        if ($("#Error1").val() != "") {
                            NotifyCirMessage('', 'Please correct the below Error which was found during Migration of this CIR <br>(This message will be shown till the CIR is submitted)<br><b>Solution :</b> <br>' + $("#Error1").val(), 'danger', 0);
                        }
                    }, 3000);
                });
            }
                , 2000);
        }
        else if (RemoteCirID && parseFloat(RemoteCirID) > 0) {
            setTimeout(function () {
                waitingDialog.updateMessage('Reading CIR data..');
                cirOfflineApp.LoadRemoteCirData(RemoteCirID, false, function () {
                    $("#ddlCirType").change(); cirOfflineApp.UpdateTemplateFields(); $("#ddlReportType").change(); waitingDialog.hide();
                    $('#cirLocalID').val(RemoteCirID);
                    waitingDialog.hide();
                    setGeneratorInsulationData();
                    cirOfflineApp.StartSaveTimer();
                    if ($("#Error1").val() != "") {
                        NotifyCirMessage('', 'Please correct the below Error which was found during Migration of this CIR <br>(This message will be shown till the CIR is submitted)<br><b>Solution :</b> <br>' + $("#Error1").val(), 'danger', 0);
                    }
                }, function () { });
            }, 1000);
        }
        else if (CirrevisionID && parseFloat(CirrevisionID) > 0) {
            setTimeout(function () {
                waitingDialog.updateMessage('Reading CIR revision data..');
                cirOfflineApp.LoadRemoteCirData(CirrevisionID, true, function () {
                    $("#ddlCirType").change(); cirOfflineApp.UpdateTemplateFields(); $("#ddlReportType").change();
                    waitingDialog.hide();
                    setGeneratorInsulationData();
                    cirOfflineApp.StartSaveTimer();
                    if ($("#Error1").val() != "") {
                        NotifyCirMessage('', 'Please correct the below Error which was found during Migration of this CIR <br> <b>(This message will be shown till the CIR is submitted)</b><br><b>Solution :</b> <br>' + $("#Error1").val(), 'danger', 0);
                    }
                }, function () { });
            }, 1000);
        }
        else {
            setTimeout(function () {
                $("#ddlCirType").change();
                setTimeout(function () {
                    $('#ddlServiceReportNumberType').change(); $("#ddlReportType").change();
                }, 3000);
                cirOfflineApp.StartSaveTimer();
                setGeneratorInsulationData();
                waitingDialog.hide();

            }, 1000);
        }

        //Online Validation

        //TurbineNumber
        $("#txtTurbineNumber").blur(function () {
            if (Offline.state == "up") {
                $('#lblTurbineError').text('');
                $('#lblTurbineError').hide();
                $('#txtTurbineNumber').removeClass('validationerror');
                $('#txtTurbineNumber').removeClass('red-tooltip');
                if ($("#txtTurbineNumber").val() != null && $("#txtTurbineNumber").val().trim() != "") {
                    $('#lblTurbineWait').show();
                    CallClientApi("ValidateTurbineNumber/" + $("#txtTurbineNumber").val(), "GET", "").done(function (result) {
                        if (!result) {
                            $('#txtTurbineNumber').addClass('validationerror');
                            $('#txtTurbineNumber').addClass('red-tooltip');
                            $('#lblTurbineError').show();
                            $('#lblTurbineError').text('Entered Turbine Number is not valid !');

                            $('#txtTurbineCountry').val('');
                            $('#txtTurbineSite').val('');
                            $('#txtTurbineType').val('');
                            $('#txtRotorDiameter').val('');
                            $('#txtNominelPower').val('');
                            $('#txtVoltage').val('');
                            $('#txtPowerRegulation').val('');
                            $('#txtFrequency').val('');
                            $('#txtSmallGenerator').val('');
                            $('#txtTemperatureVariant').val('');
                            $('#txtMKVersion').val('');
                            $('#txtOnshoreOffshore').val('');
                            $('#txtTurbineManufacturer').val('');
                            $('#txtLocalTurbineID').val('');

                            $('#lblTurbineWait').hide();
                        }
                        else {
                            $('#txtTurbineNumber').removeClass('validationerror');
                            $('#txtTurbineNumber').removeClass('red-tooltip');
                            $('#lblTurbineError').hide();
                            $('#lblTurbineError').text('');

                            //====================

                            CallClientApi("ValidateGetTurbineData/" + $("#txtTurbineNumber").val(), "GET", "").done(function (turbinedata) {
                                if (turbinedata) {
                                    $('#txtTurbineCountry').val(turbinedata.country);
                                    $('#txtTurbineSite').val(turbinedata.site);
                                    $('#txtTurbineType').val(turbinedata.turbine);
                                    $('#txtRotorDiameter').val(turbinedata.rotorDiameter);
                                    $('#txtNominelPower').val(turbinedata.nominelPower);
                                    $('#txtVoltage').val(turbinedata.voltage);
                                    $('#txtPowerRegulation').val(turbinedata.powerRegulation);
                                    $('#txtFrequency').val(turbinedata.frequency);
                                    $('#txtSmallGenerator').val(turbinedata.SmallGenerator);
                                    $('#txtTemperatureVariant').val(turbinedata.temperatureVariant);
                                    $('#txtMKVersion').val(turbinedata.markVersion);
                                    $('#txtOnshoreOffshore').val(turbinedata.placement);
                                    $('#txtTurbineManufacturer').val(turbinedata.manufacturer);
                                    $('#txtLocalTurbineID').val(turbinedata.localTurbineID);
                                    $('#lblTurbineWait').hide();
                                }
                            });

                            //====================
                        }
                    });
                }

            }
        });

        //turbine number simplified cir
        $("#txtTurbineNumber_Flang").blur(function () {
            if (Offline.state == "up") {
                $('#lblTurbineError_Flang').text('');
                $('#lblTurbineError_Flang').hide();
                $('#txtTurbineNumber_Flang').removeClass('validationerror');
                $('#txtTurbineNumber_Flang').removeClass('red-tooltip');
                if ($("#txtTurbineNumber_Flang").val() != null && $("#txtTurbineNumber_Flang").val().trim() != "") {
                    //  $('#lblTurbineWait_flang').show();
                    CallClientApi("ValidateTurbineNumber/" + $("#txtTurbineNumber_Flang").val(), "GET", "").done(function (result) {
                        if (!result) {
                            $('#txtTurbineNumber_Flang').addClass('validationerror');
                            $('#txtTurbineNumber_Flang').addClass('red-tooltip');
                            $('#lblTurbineError_Flang').show();
                            $('#lblTurbineError_Flang').text('Entered Turbine Number is not valid !');
                            //$('#lblTurbineWait_flang').hide();
                        }
                        else {
                            $('#lblTurbineWait_Flang').hide();
                            $('#txtTurbineNumber_Flang').removeClass('validationerror');
                            $('#txtTurbineNumber_Flang').removeClass('red-tooltip');
                            $('#lblTurbineError_Flang').hide();
                            $('#lblTurbineError_Flang').text('');

                        }
                    });
                    $('#lblTurbineWait_Flang').hide();
                    $('#lblTurbineWait_Flang').css("display", "none");
                }

            }
        });
        //CIM Case Number
        $("#txtCimNo").blur(function () {
            if (Offline.state == "up") {
                $('#lblCIMCaseError').text('');
                $('#lblCIMCaseError').hide();
                $('#txtCimNo').removeClass('validationerror');
                $('#txtCimNo').removeClass('red-tooltip');
                if ($("#txtCimNo").val() != null && $("#txtCimNo").val().trim() != "") {
                    CallClientApi("ValidateCIMCaseNumber/" + $("#txtCimNo").val(), "GET", "").done(function (result) {
                        if (!result) {
                            $('#txtCimNo').addClass('validationerror');
                            $('#txtCimNo').addClass('red-tooltip');
                            $('#lblCIMCaseError').show();
                            $('#lblCIMCaseError').text('Entered CIM Case Number is not valid !');
                        }
                        else {
                            $('#txtCimNo').removeClass('validationerror');
                            $('#txtCimNo').removeClass('red-tooltip');
                            $('#lblCIMCaseError').hide();
                            $('#lblCIMCaseError').text('');
                        }
                    });
                }
            }
        });

        //CIM Case Number
        $("#txtCimNo_Flang").blur(function () {
            if (Offline.state == "up") {
                $('#lblCIMCaseError_Flang').text('');
                $('#lblCIMCaseError_Flang').hide();
                $('#txtCimNo_Flang').removeClass('validationerror');
                $('#txtCimNo_Flang').removeClass('red-tooltip');
                if ($("#txtCimNo_Flang").val() != null && $("#txtCimNo_Flang").val().trim() != "") {
                    CallClientApi("ValidateCIMCaseNumber/" + $("#txtCimNo_Flang").val(), "GET", "").done(function (result) {
                        if (!result) {
                            $('#txtCimNo_Flang').addClass('validationerror');
                            $('#txtCimNo_Flang').addClass('red-tooltip');
                            $('#lblCIMCaseError_Flang').show();
                            $('#lblCIMCaseError_Flang').text('Entered CIM Case Number is not valid !');
                        }
                        else {
                            $('#txtCimNo_Flang').removeClass('validationerror');
                            $('#txtCimNo_Flang').removeClass('red-tooltip');
                            $('#lblCIMCaseError_Flang').hide();
                            $('#lblCIMCaseError_Flang').text('');
                        }
                    });
                }
            }
        });

        //ServiceReportNumber
        $("#txtServicePortNo").blur(function () {
            if (Offline.state == "up") {
                $('#lblServicReportError').text('');
                $('#lblServicReportError').hide();
                $('#txtServicePortNo').removeClass('validationerror');
                $('#txtServicePortNo').removeClass('red-tooltip');
                if ($("#txtTurbineNumber").val() != null && $("#txtTurbineNumber").val().trim() != "" && $("#txtServicePortNo").val() != null && $("#txtServicePortNo").val().trim() != "" && $("#ddlServiceReportNumberType option:selected").text() == "MAM/SAP") {
                    CallClientApi("ValidateServiceReportNumber/" + $("#txtServicePortNo").val() + "/" + $("#txtTurbineNumber").val(), "GET", "").done(function (result) {
                        if (!result) {
                            $('#txtServicePortNo').addClass('validationerror');
                            $('#txtServicePortNo').addClass('red-tooltip');
                            $('#lblServicReportError').show();
                            $('#lblServicReportError').text('Entered Service Report Number is not valid for the entered Turbine Number !');
                        }
                        else {
                            $('#txtServicePortNo').removeClass('validationerror');
                            $('#txtServicePortNo').removeClass('red-tooltip');
                            $('#lblServicReportError').hide();
                            $('#lblServicReportError').text('');
                        }
                    });
                }
            }
        });

        //ServiceReportNumber
        $("#txtServicePortNo_Flang").blur(function () {
            if (Offline.state == "up") {
                $('#lblServicReportError_Flang').text('');
                $('#lblServicReportError_Flang').hide();
                $('#txtServicePortNo_Flang').removeClass('validationerror');
                $('#txtServicePortNo_Flang').removeClass('red-tooltip');
                //$("#txtTurbineNumber_Flang").val() != null && $("#txtTurbineNumber_Flang").val().trim() != "" &&
                if ($("#txtServicePortNo_Flang").val() != null && $("#txtServicePortNo_Flang").val().trim() != "" && $("#ddlServiceReportNumberType_Flang option:selected").text() == "MAM/SAP") {
                    CallClientApi("ValidateServiceReportNumber/" + $("#txtServicePortNo_Flang").val() + "/" + $("#txtTurbineNumber_Flang").val(), "GET", "").done(function (result) {
                        if (!result) {
                            $('#txtServicePortNo_Flang').addClass('validationerror');
                            $('#txtServicePortNo_Flang').addClass('red-tooltip');
                            $('#lblServicReportError_Flang').show();
                            $('#lblServicReportError_Flang').text('Entered Service Report Number is not valid for the entered Turbine Number !');
                        }
                        else {
                            $('#txtServicePortNo_Flang').removeClass('validationerror');
                            $('#txtServicePortNo_Flang').removeClass('red-tooltip');
                            $('#lblServicReportError_Flang').hide();
                            $('#lblServicReportError_Flang').text('');
                        }
                    });
                }
            }
        });
       
        //ServiceReportNumberType
        $("#ddlServiceReportNumberType").change(function () {
            $('#lblServicReportError').text('');
            $('#lblServicReportError').hide();
            $('#txtServicePortNo').removeClass('validationerror');
            $('#txtServicePortNo').removeClass('red-tooltip');
            if ($("#txtTurbineNumber").val() != null && $("#txtTurbineNumber").val().trim() != "" && $("#txtServicePortNo").val() != null && $("#txtServicePortNo").val().trim() != "" && $("#ddlServiceReportNumberType option:selected").text() == "MAM/SAP") {
                CallClientApi("ValidateServiceReportNumber/" + $("#txtServicePortNo").val() + "/" + $("#txtTurbineNumber").val(), "GET", "").done(function (result) {
                    if (!result) {
                        $('#txtServicePortNo').addClass('validationerror');
                        $('#txtServicePortNo').addClass('red-tooltip');
                        $('#lblServicReportError').show();
                        $('#lblServicReportError').text('Entered Service Report Number is not valid for the entered Turbine Number !');
                    }
                    else {
                        $('#txtServicePortNo').removeClass('validationerror');
                        $('#txtServicePortNo').removeClass('red-tooltip');
                        $('#lblServicReportError').hide();
                        $('#lblServicReportError').text('');
                    }
                });
            }

        });

        //ServiceReportNumberType
        $("#ddlServiceReportNumberType_Flang").change(function () {
            $('#lblServicReportError_Flang').text('');
            $('#lblServicReportError_Flang').hide();
            $('#txtServicePortNo_Flang').removeClass('validationerror');
            $('#txtServicePortNo_Flang').removeClass('red-tooltip');

            //$("#txtTurbineNumber_Flang").val() != null && $("#txtTurbineNumber_Flang").val().trim() != "" &&
            if ($("#txtServicePortNo_Flang").val() != null && $("#txtServicePortNo_Flang").val().trim() != "" && $("#ddlServiceReportNumberType_Flang option:selected").text() == "MAM/SAP") {
                CallClientApi("ValidateServiceReportNumber/" + $("#txtServicePortNo_Flang").val() + "/" + $("#txtTurbineNumber_Flang").val(), "GET", "").done(function (result) {
                    if (!result) {
                        $('#txtServicePortNo_Flang').addClass('validationerror');
                        $('#txtServicePortNo_Flang').addClass('red-tooltip');
                        $('#lblServicReportError_Flang').show();
                        $('#lblServicReportError_Flang').text('Entered Service Report Number is not valid for the entered Turbine Number !');
                    }
                    else {
                        $('#txtServicePortNo_Flang').removeClass('validationerror');
                        $('#txtServicePortNo_Flang').removeClass('red-tooltip');
                        $('#lblServicReportError_Flang').hide();
                        $('#lblServicReportError_Flang').text('');
                    }
                });
            }
        });
        //Online validation

    });
    var YearRange = "-50:+50";
    $("#txtCommisioningDate").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true,
        yearRange: YearRange,
        onClose: function (selectedDate) {
            $("#txtInstallationDate").datepicker("option", "minDate", selectedDate);
            $("#txtFailureDate").datepicker("option", "minDate", selectedDate);
            $("#txtCommisioningDate").removeClass('validationerror');
            $("#txtCommisioningDate").removeClass('red-tooltip');

        }
    });
    $("#txtInstallationDate").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true,
        yearRange: YearRange,
        onClose: function (selectedDate) {
            $("#txtFailureDate").datepicker("option", "minDate", selectedDate);
            $("#txtCommisioningDate").datepicker("option", "maxDate", selectedDate);
            $("#txtInstallationDate").removeClass('validationerror');
            $("#txtInstallationDate").removeClass('red-tooltip');
        }
    });
    $("#txtFailureDate").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true,
        yearRange: YearRange,
        onClose: function (selectedDate) {
            $("#txtCommisioningDate").datepicker("option", "maxDate", selectedDate);
            $("#txtInspectionDate").datepicker("option", "minDate", selectedDate);
            $("#txtFailureDate").removeClass('validationerror');
            $("#txtFailureDate").removeClass('red-tooltip');

        }
    });
    $("#txtInspectionDate").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true,
        yearRange: YearRange,
        onClose: function (selectedDate) {
            $("#txtCommisioningDate").datepicker("option", "maxDate", selectedDate);
            $("#txtInspectionDate").removeClass('validationerror');
            $("#txtInspectionDate").removeClass('red-tooltip');

        }
    });


    $("#txtTransformerMaxTempDate").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        yearRange: YearRange,
        changeYear: true

    });
    $("#txtMainBearingLubricationchangeDate").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        yearRange: YearRange,
        changeYear: true
    });
    $("#txtGeneratorMaxTempResetDate").datepicker({
        dateFormat: 'dd-mm-yy',
        yearRange: YearRange,
        changeMonth: true,
        changeYear: true
    });
    $("#txtDateForLastOilChange").datepicker({
        dateFormat: 'dd-mm-yy',
        yearRange: YearRange,
        changeMonth: true,
        changeYear: true
    });
    $("#txtCalibrationDate").datepicker({
        dateFormat: 'dd-mm-yy',
        yearRange: YearRange,
        changeMonth: true,
        changeYear: true
    });
    $("#txtDateMaxTemperatureResetDate").datepicker({
        dateFormat: 'dd-mm-yy',
        yearRange: YearRange,
        changeMonth: true,
        changeYear: true
    });
    $("#txtheaterinsulationandvacuumoff").datetimepicker({
        dateFormat: 'dd-mm-yy',
        //changeMonth: true,
        //yearRange: YearRange,
        //changeYear: true,
        //timeFormat: "HM:mm"

    });
    $("#txtInspectionDate_Flang").datepicker('setDate', new Date());
    $("#txtInspectionDate_Flang").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true,
        yearRange: YearRange,
        maxDate: new Date(),
        onClose: function (selectedDate) {

            $("#txtInspectionDate_Flang").removeClass('validationerror');
            $("#txtInspectionDate_Flang").removeClass('red-tooltip');

        }
    });
    $("#txtInspectionDate_Flang").datepicker('setDate', new Date());
    $("#txthardnertypeexpirydate").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        yearRange: YearRange,
        changeYear: true

    });
    $("#txtResinTypeexpirydate").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        yearRange: YearRange,
        changeYear: true

    });

    // Cir tempate section next/prev
    var IsCloneCommLink = 0;
    var IsCloneBladeLink = 0;
    $('#cirCommonLink').click(function () {
        var tableOffset = $("#cirCommonLink").offset().top;
        var $fixedHeader;
        var $TfixedHeader;


        $('#header-fixed > #cloneid-Blade').addClass("hidden");
        $('#header-fixed > #cloneid-Comm').removeClass("hidden");
        if (IsCloneCommLink != 1) {
            IsCloneCommLink = 1;
            $('#cirTemplates').show();
            $header = $(".persist-area > #cirCommonLink").clone().attr("id", "cloneid-Comm").addClass("floatingHeader ui-state-active").css("width", $("#cirTemplates").width());
            $fixedHeader = $("#header-fixed").append($header);

            $fixedHeader.removeClass("ui-accordion-header ui-helper-reset ui-state-default ui-corner-all ui-accordion-icons");
            $("#header-fixed > span").removeClass("ui-accordion-header-icon ui-icon ui-icon-triangle-1-e");

        }
        else {
            $('#header-fixed > #cloneid-Blade').addClass("hidden");
        }


        if ($("Div > #cloneid-Blade").length > 1) {
            alert(("#cloneid-Blade").length);
            $(this).parents("#cloneid-Blade").remove();
            $fixedHeader = $("#header-fixed").append($header);
            //$('#divCommonStatic').removeClass("floatingHeader");
        }

        $(window)
                .scroll(UpdateTableHeaders)
                .trigger("scroll");

    });
    //CIR accordion
    $("#cirTemplates").accordion({
        collapsible: true,
        heightStyle: "content",
        beforeActivate: function (event, ui) {
            var newIndex = jQuery(this).find("h3").index(ui.newHeader[0]);
            var oldIndex = jQuery(this).find("h3").index(ui.oldHeader[0]);

            if (newIndex == '1' && oldIndex != newIndex) {
                $('#cirTemplateLink').removeClass("ui-state-default");
                $('#cirTemplateLink').addClass("ui-state-success");
                //alert($('input[name="radio"]').val());
            }
            else if (newIndex == '2' && oldIndex != newIndex) {

                if (SaveCommonSection(true)) {
                    $('html, body').animate({ scrollTop: 0 }, 800); // scroll to top 
                    //$('#header-fixed > #cloneid-Blade').addClass("visible");
                    $('#header-fixed > #cloneid-Comm').addClass("hidden");
                    $('#header-fixed > #cloneid-Blade').removeClass("hidden");



                    var clonedHeaderRow;
                    var tableOffset = $("#cirBladeLink").offset().top;
                    var $fixedHeader;
                    var $TfixedHeader;
                    if (IsCloneBladeLink != 1) {
                        IsCloneBladeLink = 1;
                        $header = $(".persist-area > #cirBladeLink").clone().attr("id", "cloneid-Blade").addClass("floatingHeader ui-state-active").css("width", $("#cirTemplates").width());
                        $fixedHeader = $("#header-fixed").append($header);

                        $fixedHeader.removeClass("ui-accordion-header ui-helper-reset ui-state-default ui-corner-all ui-accordion-icons");
                        $("#header-fixed > span").removeClass("ui-accordion-header-icon ui-icon ui-icon-triangle-1-e");

                    }
                    else {
                        $('#header-fixed > #cloneid-Comm').addClass("hidden");
                    }



                    $(window)
                         .scroll(UpdateTableHeaders)
                         .trigger("scroll");
                }

            }
            else if (newIndex == '3' && oldIndex != newIndex) {
                var isValid = false;
                // alert($('input[name="radio"]').val());
                if ($('input[name="radio"]').val() == 'rdHotlist') {
                    var hotlistCirType = $('#ddlHotlist :selected').text();
                    hotlistCirType = hotlistCirType.split(":")[0];
                    hotlistCirType = hotlistCirType.substring(hotlistCirType.lastIndexOf("[") + 1, hotlistCirType.lastIndexOf("]"));
                    switch (hotlistCirType) {
                        case 'Blade':
                            isValid = SaveBladeSection(true);
                            break;
                        case 'Gearbox':
                            isValid = SaveGearboxSection(true);
                            break;
                        case 'General':
                            isValid = SaveGeneralSection(true);
                            break;
                        case 'Generator':
                            isValid = SaveGeneratorSection(true);
                            break;
                        case 'Transformer':
                            isValid = SaveTransformerSection(true);
                            break;
                        case 'Main Bearing':
                            isValid = SaveMainBearingSection(true);
                            break;
                        case 'Skiipack':
                            isValid = SaveSkiipackSection(true);
                            break;
                    }
                }
                else {
                    switch ($('#ddlCirType :selected').val()) {
                        case '1':

                            isValid = SaveBladeSection(true);
                            break;
                        case '2':

                            isValid = SaveGearboxSection(true);
                            break;
                        case '3':

                            isValid = SaveGeneralSection(true);
                            break;
                        case '4':

                            isValid = SaveGeneratorSection(true);
                            break;
                        case '5':
                            isValid = SaveTransformerSection(true);
                            break;
                        case '6':

                            isValid = SaveMainBearingSection(true);
                            break;
                        case '7':

                            isValid = SaveSkiipackSection(true);
                            break;
                    }
                }
            }
            else if (newIndex == '5' && oldIndex != newIndex) {
                var ivld = SaveCIRImages(true);
                return ivld;

            }
            else if (newIndex == '6' && oldIndex != newIndex) {
                if ($('input[name="radio"]').val() == 'rdHotlist')
                    $('#spanSuccessMessage').html('CIR <strong>' + $('#txtTurbineCountry').val() + '_General    _' + $('#txtTurbineNumber').val() + '_' + $('#txtInspectionDate').val() + '_' + $('#txtCimNo').val() + '</strong> has been created successfully.<br />You need to submit the CIR for further process.');
                else
                    $('#spanSuccessMessage').html('CIR <strong>' + $('#txtTurbineCountry').val() + '_' + $('#ddlCirType :selected').text() + '_' + $('#txtTurbineNumber').val() + '_' + $('#txtInspectionDate').val() + '_' + $('#txtCimNo').val() + '</strong> has been created successfully.<br />You need to submit the CIR for further process.');

                $('#cirDynamicTableLink').removeClass("ui-state-error");
                $('#cirDynamicTableLink').addClass("ui-state-success");

                SaveDynamicTable();
                return true;
            }
            else
                return true;
        }

    });
    function UpdateTableHeaders() {
        return;
        //Not Useed Now
        $(".persist-area").each(function () {
            var $fixedHeader = $("#header-fixed", this)
            var el = $(this),
                offset = el.offset(),
                scrollTop = $(window).scrollTop(),
                floatingHeader = $(".floatingHeader", this)

            if ((scrollTop > offset.top) && (scrollTop < offset.top + el.height())) {
                floatingHeader.css({
                    "visibility": "visible"
                });
                $fixedHeader.show();
            } else {
                floatingHeader.css({
                    "visibility": "hidden"
                });
                $fixedHeader.hide();
            };
        });
    }
    function listToAray(fullString, separator) {
        var fullArray = [];

        if (fullString !== undefined) {
            if (fullString.indexOf(separator) == -1) {
                fullAray.push(fullString);
            } else {
                fullArray = fullString.split(separator);
            }
        }

        return fullArray;
    }
    $('#linkInserOtherBladeSet').click(function () {
        $('#otherBladeSet').slideToggle(500);
        if ($(this).text() == 'Insert other blade in set..') {
            $(this).text('Remove other blade in set..');
        }
        else {
            $(this).text('Insert other blade in set..');
        }
    });
    $('#linkInserBladeDamage').click(function () {
        $('#bladeDamageArea').append($('<div id="' + Date.now() + '" class="bladeDamageSection"></div>').append($('#bladeDamageSection').html()));
    });

    $('#linkInserFlangSection').click(function () {
        $('#FlangeArea').append($('<div id="' + Date.now() + '"></div>').append($('#FlangeSection').html()));
    });

    $('body').on('click', '.linkRemove', function () {
        $(this).parent().parent().parent().hide();
    });
    $('.iCheck-helper').click(function () {
        if ($('#chkDamageIdentified').is(':checked') == false) {
            $('.bladeDamageSection').hide();
            $('#linkInserBladeDamage').hide();
        }
        else {
            $('.bladeDamageSection').show();
            $('#linkInserBladeDamage').show();
        }
    });

    $('.iCheck-helper').click(function () {
        if ($('#chkComponentSerialNumber').is(':checked') == false) {
            $('.ComponentSerialNumberSection').show();
        }
        else {
            $('.ComponentSerialNumberSection').hide();
        }
    });

    //Added by Siddharth Chauhan on 22-06-2016-->
    //Removed "*" from checkbox and added text with checkbox-->
    //Bug : 80806-->
    $('.iCheck-helper').click(function () {
        if ($('#chkMainBearingGrease').is(':checked') == true) {
            if ($('#txtMainBearingOilTemperature').hasClass('validationerror red-tooltip')) {
                $('#txtMainBearingOilTemperature').removeClass('validationerror red-tooltip');
            }
            $('#spanMainBearingOilTemp').hide();
        }
        else {
            $('#spanMainBearingOilTemp').show();
        }

    });

    function ClearDynamicControlsValue(parentID) {
        var DynamicVal = parentID.substr(parentID.length - 1);
        $('#' + parentID + ' #controlHeader2').val('-1');
        $('#' + parentID + ' #controlHeader1').val('-1');
        $('#' + parentID + ' #txtrowHeader13').val('');
        $('#' + parentID + ' #txtrowHeader14').val('');
        $('#' + parentID + ' #txtrowHeader3').val('');
        $('#' + parentID + ' #controlHeader4').val('-1');
        $('#' + parentID + ' #txtrowHeader5').val('');
        $('#' + parentID + ' #txtrowHeader6').val('');
        $('#' + parentID + ' #txtrowHeader7').val('');
        $('#' + parentID + ' .manMovFlang').hide();
        $('#' + parentID + ' #chkrowHeader8').val('-1');
        $('#' + parentID + ' #txtrowHeader9').val('');
        $('#' + parentID + ' #txtrowHeader10').val('');
        $('#' + parentID + ' #txtrowHeader11').val('');
        $('#' + parentID + ' #txtrowHeader12').val('');
        $('#' + parentID + ' #controlDecision').val('-1');
        $('#' + parentID + ' #controlRepeatedInspection').val('-1');
        $('#' + parentID + ' #chkReplaceAffectedBolts').attr('checked', false);
        $('#' + parentID + ' #chkReplaceAffectedBolts').parent().removeClass('checked');
        $('#' + parentID + ' #chkReplaceAffectedBolts').parent().attr('aria-checked', 'false');
        $('#' + parentID + ' #chkDamageIdentifiedSimplified').attr('checked', false);
        $('#' + parentID + ' #chkDamageIdentifiedSimplified').parent().removeClass('checked');
        $('#' + parentID + ' #chkDamageIdentifiedSimplified').parent().attr('aria-checked', 'false');
        $('#' + parentID + ' #txtImgInspectionDescription' + DynamicVal).val("");
        var imageID = DynamicVal == 1 ? "imagedropA" : (DynamicVal == 2 ? "imagedropB" : (DynamicVal == 3 ? "imagedropC" : (DynamicVal == 4 ? "imagedropD" : (DynamicVal == 5 ? "imagedropE" : "imagedropF"))))
        FileToUpload = FileToUpload.filter(function (obj) {
            return obj.id !== imageID;
        });
        $("#list" + DynamicVal).html("");
    };

    $('.iCheck-helper').click(function () {
        var chkID = this.previousSibling.id;
        if (this.previousSibling.attributes['data-id'] != undefined) {
            var parentID = this.previousSibling.attributes['data-id'].value;
            if (parentID != '' && parentID != undefined) {
                if ($('#' + parentID + ' #' + chkID).is(':checked') == false) {

                    var DynamicVal = parentID.substr(parentID.length - 1);
                    var FlangeNumber = $('#cirDynamicAccord' + DynamicVal + ' > a').text();

                    CirAlert.confirm('If you uncheck this. you will loose <b>' + FlangeNumber + '</b> data. Are you sure you want to continue?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                        $('#' + parentID + ' #showHideFlangeSections').hide();
                        ClearDynamicControlsValue(parentID);

                        var DynamicVal = parentID.substr(parentID.length - 1);
                        $('#cirDynamicAccord' + DynamicVal).removeClass("ui-state-error");
                        $('#cirDynamicAccord' + DynamicVal).addClass("ui-state-success");
                        $('#' + parentID + ' #chkDamageIdentifiedSimplified').attr('checked', false);
                        $('#' + parentID + ' #chkDamageIdentifiedSimplified').parent().removeClass('checked');
                        $('#' + parentID + ' #chkDamageIdentifiedSimplified').parent().attr('aria-checked', 'false');
                        $('#' + parentID + ' #' + chkID)["0"].checked = false;

                    }).fail(function (e) {
                        $('#' + parentID + ' #chkDamageIdentifiedSimplified').attr('checked', true);
                        $('#' + parentID + ' #chkDamageIdentifiedSimplified').parent().addClass('checked');
                        $('#' + parentID + ' #chkDamageIdentifiedSimplified').parent().attr('aria-checked', 'true');
                        $('#' + parentID + ' #' + chkID)["0"].checked = true;
                    });

                }
                else {
                    $('#' + parentID + ' #showHideFlangeSections').show();

                }
            }
        }

    });

    // Cir tempate section next/prev
    $('#linkCirTemplteNext').click(function () {
        if (SaveTemplateSection(true)) {
            if ($('#ddlCirType :selected').val() == 8) {
                $('#cirBladeLink').click();
            }
            else {
                $('#cirCommonLink').click();
            }
        }
    });

    // Cir common section next/prev
    $('#linkCirCommonPrev').click(function () {
        $('#cirCommonSection').hide('slide', { direction: 'right' }, 200);
        $('#cirTemplateSection').show('slide', { direction: 'left' }, 500);
    });
    $('#linkCirCommonNext').click(function () {
        //Task No. : 72530, Commented by Siddharth Chauhan on 25-05-2016.
        //if (SaveCommonSection()) {
        //Task No. : 72530, Added and modified by Siddharth Chauhan on 25-05-2016.
        //To navigate one tab to another without blocking a user.
        if (SaveCommonSection(true)) {
            $('#cirBladeLink').click();
        }
    });

    // Cir blade section next/prev
    $('#linkBladeDataPrev,#linkGeneralDataPrev').click(function () {
        $('#cirCommonLink').click();
    });

    $('#linkBladeDataNext').click(function () {
        //Task No. : 72530, Commented by Siddharth Chauhan on 25-05-2016.
        //if (SaveBladeSection())
        //Task No. : 72530, Added and modified by Siddharth Chauhan on 25-05-2016.
        //To navigate one tab to another without blocking a user.
        if (SaveBladeSection(true))
            $('#cirImagesLink').click();
    });

    $('#linkGeneralDataNext').click(function () {
        //Task No. : 72530, Commented by Siddharth Chauhan on 25-05-2016.
        //if (SaveGeneralSection())
        //Task No. : 72530, Added and modified by Siddharth Chauhan on 25-05-2016.
        //To navigate one tab to another without blocking a user.
        if (SaveGeneralSection(true))
            $('#cirImagesLink').click();
    });

    $('#linkSimplifiedCirPrev').click(function () {
        //$('#cirCommonLink').click();
    });

    $('#linkSimplifiedCirNext').click(function () {
        if (SaveSimplifiedCIRSection(true, 'Next')) {
        }
        else {

            return false;
        }
    });

    $('#linkGeneralDataNext').click(function () {
        //Task No. : 72530, Commented by Siddharth Chauhan on 25-05-2016.
        //if (SaveGeneralSection())
        //Task No. : 72530, Added and modified by Siddharth Chauhan on 25-05-2016.
        //To navigate one tab to another without blocking a user.
        if (SaveGeneralSection(true))
            $('#cirImagesLink').click();
    });

    $('#linkGearboxDataNext').click(function () {
        //Task No. : 72530, Commented by Siddharth Chauhan on 25-05-2016.
        //if (SaveGearboxSection())
        //Task No. : 72530, Added and modified by Siddharth Chauhan on 25-05-2016.
        //To navigate one tab to another without blocking a user.
        if (SaveGearboxSection(true))
            $('#cirImagesLink').click();
    });

    $('#linkSkiipackDataNext').click(function () {
        //Task No. : 72530, Commented by Siddharth Chauhan on 25-05-2016.
        //if (SaveSkiipackSection())
        //Task No. : 72530, Added and modified by Siddharth Chauhan on 25-05-2016.
        //To navigate one tab to another without blocking a user.
        if (SaveSkiipackSection(true))
            $('#cirImagesLink').click();
    });

    $('#linkTransformerDataNext').click(function () {
        //Task No. : 72530, Commented by Siddharth Chauhan on 25-05-2016.
        //if (SaveTransformerSection())
        //Task No. : 72530, Added and modified by Siddharth Chauhan on 25-05-2016.
        //To navigate one tab to another without blocking a user.
        if (SaveTransformerSection(true))
            $('#cirImagesLink').click();
    });

    $('#linkMainbearingDataNext').click(function () {
        //Task No. : 72530, Commented by Siddharth Chauhan on 25-05-2016.
        //if (SaveMainBearingSection())
        //Task No. : 72530, Added and modified by Siddharth Chauhan on 25-05-2016.
        //To navigate one tab to another without blocking a user.
        if (SaveMainBearingSection(true))
            $('#cirImagesLink').click();
    });

    $('#linkGeneratorDataNext').click(function () {
        //Task No. : 72530, Commented by Siddharth Chauhan on 25-05-2016.
        //if (SaveGeneratorSection())
        //Task No. : 72530, Added and modified by Siddharth Chauhan on 25-05-2016.
        //To navigate one tab to another without blocking a user.
        if (SaveGeneratorSection(true))
            $('#cirImagesLink').click();
    });

    // Cir image section next/prev
    $('#linkImageDataPrev').click(function () {
        $('#cirBladeLink').click();
    });
    $('#linkImageDataNext').click(function () {
        SaveCIRImages();
        var display = $("#cirDynamicTableLink").css("display");
        if (display == "none") {
            $('#cirSubmitLink').click();
        }
        else {
            $('#cirDynamicTableLink').click();
        }


    });

    $('#linkDynamicTableNext').click(function () {
        if ($('input[name="radio"]').val() == 'rdHotlist')
            $('#spanSuccessMessage').html('CIR <strong>' + $('#txtTurbineCountry').val() + '_General    _' + $('#txtTurbineNumber').val() + '_' + $('#txtInspectionDate').val() + '_' + $('#txtCimNo').val() + '</strong> has been created successfully.<br />You need to submit the CIR for further process.');
        else
            $('#spanSuccessMessage').html('CIR <strong>' + $('#txtTurbineCountry').val() + '_' + $('#ddlCirType :selected').text() + '_' + $('#txtTurbineNumber').val() + '_' + $('#txtInspectionDate').val() + '_' + $('#txtCimNo').val() + '</strong> has been created successfully.<br />You need to submit the CIR for further process.');
        SaveDynamicTable();
        $('#cirSubmitLink').click();
    });

    //$('#linkDynamicControlNext').click(function () {        
    //    var value = $(this).attr('data-parentdiv');
    //    SaveSimplifiedCirFlange(value);
    //});

    $('#linkSaveCIR').click(function () {

        if ($("#tType").val() == "rdCirType" && ($('#ddlCirType :selected').val()) == -1) {

            CirAlert.alert('Please select a valid Cir Type.', 'Cir App', null, 'error').done(function () {
                return false;
            });
            return;
        }
        if ($("#tType").val() == "rdHotlist" && ($('#ddlHotlist :selected').val()) == "") {

            CirAlert.alert('Please select a valid Hot list.', 'Cir App', null, 'error').done(function () {
                return false;
            });
            return;
        }
        waitingDialog.show('Saving..Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        cirOfflineApp.SaveThisCir(false).done(function () {
            waitingDialog.hide();
            window.location.href = '/cir/local-history#syncnow=1';
        });


    });

    $('#linkSubmitCIR').click(function () {
        if ($("#tType").val() == "rdCirType" && ($('#ddlCirType :selected').val()) == -1) {

            CirAlert.alert('Please select a valid Cir Type.', 'Cir App', null, 'error').done(function () {
                return false;
            });
            return;
        }
        if ($("#tType").val() == "rdHotlist" && ($('#ddlHotlist :selected').val()) == "") {

            CirAlert.alert('Please select a valid Hot list.', 'Cir App', null, 'error').done(function () {
                return false;
            });
            return;
        }
        if (($('#ddlCirType :selected').val()) == 8) {
            if (!CheckSimplifiedValidationOnSubmit()) {

                CirAlert.alert('Please complete all validations before submitting.', 'Cir App', null, 'error').done(function () {
                    return false;
                });
            }
            else {
                waitingDialog.show('Submitting..Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                cirOfflineApp.SaveThisCir(true).done(function () {
                    waitingDialog.hide();
                    window.location.href = '/cir/local-history#syncnow=1';
                });
            }
        }
        else {
            if (!CheckValidationOnSubmit()) {

                CirAlert.alert('Please complete all validations before submitting.', 'Cir App', null, 'error').done(function () {
                    return false;
                });
            }
            else {
                waitingDialog.show('Submitting..Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                cirOfflineApp.SaveThisCir(true).done(function () {
                    waitingDialog.hide();
                    window.location.href = '/cir/local-history#syncnow=1';
                });
            }
        }
    });

    $('#linkSubmitApproveCIR').click(function () {
        if ($("#tType").val() == "rdCirType" && ($('#ddlCirType :selected').val()) == -1) {

            CirAlert.alert('Please select a valid Cir Type.', 'Cir App', null, 'error').done(function () {
                return false;
            });
            return;
        }
        if ($("#tType").val() == "rdHotlist" && ($('#ddlHotlist :selected').val()) == "") {

            CirAlert.alert('Please select a valid Hot list.', 'Cir App', null, 'error').done(function () {
                return false;
            });
            return;
        }
        if (($('#ddlCirType :selected').val()) == 8) {
            if (!CheckSimplifiedValidationOnSubmit()) {

                CirAlert.alert('Please complete all validations before submitting.', 'Cir App', null, 'error').done(function () {
                    return false;
                });
            }
            else {
                CirAlert.confirm('Are you sure you want to approve, while submitting this CIR ?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                    waitingDialog.show('Submitting..Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                    cirOfflineApp.SaveThisCir(true, true).done(function () {
                        waitingDialog.hide();
                        window.location.href = '/cir/local-history#syncnow=1';
                    });
                });
            }
        }
        else {
            if (!CheckValidationOnSubmit()) {

                CirAlert.alert('Please complete all validations before submitting.', 'Cir App', null, 'error').done(function () {
                    return false;
                });
            }
            else {
                CirAlert.confirm('Are you sure you want to approve, while submitting this CIR ?', 'Cir App', 'Yes', 'No', 'question').done(function () {
                    waitingDialog.show('Submitting..Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
                    cirOfflineApp.SaveThisCir(true, true).done(function () {
                        waitingDialog.hide();
                        window.location.href = '/cir/local-history#syncnow=1';
                    });
                });

            }
        }
    });


    $('#txtCimNo,#txtTurbineNumber,#txtCommisioningDate,#txtServiceEngineer,#txtInstallationDate,#txtFailureDate,#txtInspectionDate,#txtRunHr,#txtGenerator1Hr,#txtTotalProduction,#txtVestasItemNo,#txtQuantityOfFailedComponent,#txtDescription,#txtBladeSerialNo,#ddlOverallBladeCondition,#txtBladeSerialNoOtherBlade,#txtBladeSerialNoOtherBlade2,#txtGeneratorSearialNo,#txtTransformerSerialNumber,#ddlGeneratorAuxEquipment,#ddlTransformerAuxEquipment,#txtCimNo_Flang,#txtInspectionDate_Flang').blur(function () {


        var fieldVal = $(this).val();


        if (this.id == "ddlOverallBladeCondition") {
            if (fieldVal == '0') {
                fieldVal = '';
            }
        }


        if (fieldVal != '') {
            $(this).removeClass('validationerror red-tooltip');
        }
        else {
            if (!$(this).hasClass('validationerror red-tooltip'))
                $(this).addClass('validationerror red-tooltip');
        }
        if ($(this).attr('id') == 'txtCimNo') {
            PopulateDynamicTable($(this).val());
        }

        if ($(this).attr('id') == 'txtCimNo_Flang') {
            PopulateDynamicAccordian($(this).val());
        }
        if (/^\d+$/.test(fieldVal) == false && $(this).hasClass('numbersOnly') && fieldVal != '') {
            $("#lblNumbersOnly" + this.id).remove();
            $("#" + this.id).after('<label id="lblNumbersOnly' + this.id + '" data-id="lblNumbersOnly" style="color: red"> Please enter numbers only!</label>');
            $("#" + this.id).addClass('validationerror red-tooltip');
        }
    });
    if ($('#ddlServiceReportNumberType').val() == 4) {
        $('#txtServicePortNo').blur(function () {
            if ($(this).val() != '') {
                $(this).removeClass('validationerror red-tooltip');
            }
            else {
                if (!$(this).hasClass('validationerror red-tooltip'))
                    $(this).addClass('validationerror red-tooltip');
            }
        });
    }
    //$('#ddlRunStatus').blur(function () {
    //    if ($(this).val() != '0') {
    //        $(this).removeClass('validationerror red-tooltip');
    //    }
    //    else {
    //        if (!$(this).hasClass('validationerror red-tooltip'))
    //            $(this).addClass('validationerror red-tooltip');
    //    }
    //});
    $('.ddlvalidation').blur(function () {
        if ($(this).val() != '0') {
            $(this).removeClass('validationerror red-tooltip');
        }
        else {
            if (!$(this).hasClass('validationerror red-tooltip'))
                $(this).addClass('validationerror red-tooltip');
        }
    });


    $('#txtBladeSerialNo').focus(function () {
        if ($(this).val() != '') {
            $(this).removeClass('validationerror red-tooltip');
        }
        else {
            $(this).removeClass('validationerror red-tooltip');
            $(this).addClass('validationerror red-tooltip');
        }
        NotifyCirMessage("", 'Is either a 4-6 digit number. i.e. 2354 or 35854 If the whole batch number is noted it is a 6 digit number-warehouse letter and a 4-6 digit number. i.e. 761003WHBY35964<br /><b>Old NEGMicon blades: </b>A 4 digit number<br /><b>LM blades: </b>A letter followed by a number. i.e. E-1234', "info");
    });
    $('#txtTurbineNumber').focus(function () {
        if ($(this).val() != '') {
            $(this).removeClass('validationerror red-tooltip');
        }
        else {
            $(this).removeClass('validationerror red-tooltip');
            $(this).addClass('validationerror red-tooltip');
        }
        NotifyCirMessage("", 'Country, site name and wind turbine parameters are filled out automatically once the CIR is submitted.', "info");
    });

    $('#txtGeneratorSearialNo').focus(function () {
        NotifyCirMessage("", 'Weier/VND: 6 digit number like 123456<br /> Siemens: 6 digits number like 123456<br /> ABB: 7 digit number like 1234567 or 11 digit number like 1234-1234567<br /> Leroy Somer: Can be either a 10 or 12 digit number. 600 – 2000 kW generators are typically like 123456 78AB90. <br /> 3,0 MW generators are typically 123456AB78<br /> Elin: Typically 11 or 12 digits like: 123456A-12345 or 123456-12345<br /> Loher/Winergy: Typically 7 digits like 1234567', "info");

    });

    $('#txtTransformerSerialNumber').focus(function () {
        NotifyCirMessage("", 'SGB: typically 6 digits like 123456<br/> France Transfo:Typically 8 digits like 123456-78 <br />ABB: Old resiblock transformers: 12345-5678/123. <br /> Cast Resin transformers: Typically 9 digits like 1ABC23456 <br />Siemens: typically 7 digits like A123456', "info");

    });

    $('#ddlGeneratorAuxEquipment').focus(function () {
        NotifyCirMessage("", 'Select yes if the item is an aux. equipment mounted on the main component e.g :- Auto lubrication unit - Slibrings <br /> Select no if the item is e.g:-  bearings. ', "info");

    });

    $('#ddlTransformerAuxEquipment').focus(function () {
        NotifyCirMessage("", 'Select yes if the item is an aux. equipment mounted on the main component e.g :<br /> - Fan , - Surge arrester <br /> 5.10.020 Manufacturer N/AABBFrance TransfoSGBSiemens <br /> 5.10.030 Serial Number  <br /> 5.10.060 Aux. equipment NoYes <br /> 5.10.040 Max. transformer temp. (ºC)  <br />5.10.050 Max. transformer temp. reset date (dd-mm-yy) Choose max. transformer temp. reset date ', "info");

    });

    $('.btn[data-radio-name]').click(function () {
        $('.btn[data-radio-name="' + $(this).data('radioName') + '"]').removeClass('active');
        $('input[name="' + $(this).data('radioName') + '"]').val($(this).attr('id'));
        $(this).button('complete');
        //alert( $(this).data('radioName') )
        if ($(this).attr('id') == 'rdCirType') {
            $('#txtVestasItemNo').val('');
            //Commented by Siddharth Chauhan on 02-06-2016
            //To show the selected cirtype text in the dynamic tab of Cir Page.
            //(SPRINT 1)Bug No. : 75525             
            //$('#ComponentName').text($('#ddlCirType :selected').text());

            //Added by Siddharth Chauhan on 02-06-2016
            //To show the selected cirtype text in the dynamic tab of Cir Page.
            //(SPRINT 1)Bug No. : 75525 
            $('#cirBladeLink').find('a').text($('#ddlCirType :selected').text())

            switch ($('#ddlCirType :selected').val()) {
                case '1': // Blade
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#blade').show(); // showing specific compnent
                    break;
                case '2': // Gearbox
                    break;
                case '3': // General
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#general').show(); // showing specific compnent
                    break;
                case '4': // Generator
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#generator').show(); // showing specific compnent
                    break;
                case '5': // General
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#transformer').show(); // showing specific compnent
                    break;
                case '6': // Main Bearing
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#mainbearing').show(); // showing specific compnent
                    break;
                case '7': // Skiipack
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#skiipack').show(); // showing specific compnent
                    break;
                case '8': // Simplified CIR
                    $('#txtCimNo_Flang').text('3664');
                    $('#txtCimNo_Flang').val('3664');
                    $('#txtCimNo_Flang').attr("readonly", true);
                    PopulateDynamicAccordian('3664');
                    if ($.trim($('#txtServiceEngineer_Flang').val()) == '') {
                        $('#txtServiceEngineer_Flang').text(CurrentUserInfo.Name);
                        $('#txtServiceEngineer_Flang').val(CurrentUserInfo.Name);
                    }
                    $('#txtServiceEngineer_Flang').attr('readonly', true);
                    $('.defaultItem').hide();
                    $('.templateItem').hide(); // hidding all component
                    $('#SimplifiedCIR').show(); // showing specific compnent
                    $('#cirSBURecommendationLink').show();
                    //$('#cirSBURecommendationSection').show();
                    break;
            }
            $('#lblTemplate').html('CIR Type');
            $('#ddlHotlist').hide();
            $('#ddlCirType').fadeIn(300);
        }
        else if ($(this).attr('id') == 'rdHotlist') {
            $('.simplifiedDT').hide();
            $('#blade').hide();
            $('#gearbox').hide();
            $('#general').hide();
            $('#generator').hide();
            $('#transformer').hide();
            $('#mainbearing').hide();
            $('#skiipack').hide();
            $('#cirSBURecommendationLink').hide();
            $('#cirSBURecommendationSection').hide();
            $('#txtVestasItemNo').val($('#ddlHotlist :selected').val());
            $('#cirBladeLink').find('a').text($('#ddlHotlist :selected').text());
            $('#lblTemplate').html('Hot List');
            $('.templateItem').hide();
            $('#cirCommonLink').show();
            $('.defaultItem').show();
            var hotlistCirType = $('#ddlHotlist :selected').text();
            hotlistCirType = hotlistCirType.split(":")[0];
            hotlistCirType = hotlistCirType.substring(hotlistCirType.lastIndexOf("[") + 1, hotlistCirType.lastIndexOf("]"));
            switch (hotlistCirType) {
                case 'Blade':
                    $('#blade').show();
                    break;
                case 'Gearbox':
                    $('#gearbox').show();

                    break;
                case 'General':
                    $('#general').show();
                    break;
                case 'Generator':
                    $('#generator').show();
                    break;
                case 'Transformer':
                    $('#transformer').show();
                    break;
                case 'Main Bearing':
                    $('#mainbearing').show();
                    break;
                case 'Skiipack':
                    $('#skiipack').show();
                    break;
                case 'Simplified CIR':
                    $('#txtCimNo_Flang').text('3664');
                    $('#txtCimNo_Flang').val('3664');
                    $('#txtCimNo_Flang').attr("readonly", true);
                    PopulateDynamicAccordian('3664');
                    if ($.trim($('#txtServiceEngineer_Flang').val()) == '') {
                        $('#txtServiceEngineer_Flang').text(CurrentUserInfo.Name);
                        $('#txtServiceEngineer_Flang').val(CurrentUserInfo.Name);
                    }
                    $('#txtServiceEngineer_Flang').attr('readonly', true);
                    $('.defaultItem').hide();
                    $('.templateItem').hide(); // hidding all component
                    $('#SimplifiedCIR').show(); // showing specific compnent
                    $('#cirSBURecommendationLink').show();
                    break; // showing specific compnent
            }
            //Commented by Siddharth Chauhan on 02-06-2016
            //To show the selected cirtype text in the dynamic tab of Cir Page.
            //(SPRINT 1)Bug No. : 75525 
            //$('#ComponentName').text($('#ddlHotlist :selected').text());
            //Added by Siddharth Chauhan on 02-06-2016
            //To show the selected cirtype text in the dynamic tab of Cir Page.
            //(SPRINT 1)Bug No. : 75525 

            $('#ddlCirType').hide();
            $('#ddlHotlist').fadeIn(300);
        }
        return true;
    });

    $('#my-btn').click(function () {
        $('#addChangeModal').modal('show');
        $('[data-toggle=popover]').popover('hide'); //EDIT: added this line to hide popover on button click.
    })
    $('.iCheck-helper').click(function () {
        var radioID = $(this).parent().find('input:radio');
        $(this).button('complete');
        if (radioID.attr('id') == 'rdCirType') {
            $('#txtVestasItemNo').val('');
            //Commented by Siddharth Chauhan on 02-06-2016
            //To show the selected cirtype text in the dynamic tab of Cir Page.
            //(SPRINT 1)Bug No. : 75525            
            // $('#ComponentName').text($('#ddlCirType :selected').text());

            //Added by Siddharth Chauhan on 02-06-2016
            //To show the selected cirtype text in the dynamic tab of Cir Page.
            //(SPRINT 1)Bug No. : 75525 
            $('#cirBladeLink').find('a').text($('#ddlCirType :selected').text());

            switch ($('#ddlCirType :selected').val()) {
                case '1': // Blade
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show(); // hidding all component
                    $('#blade').show(); // showing specific compnent
                    $('#cirCommonLink').show();

                    break;
                case '2': // Gearbox
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#gearbox').show(); // showing specific compnent
                    $('#cirCommonLink').show();
                    break;
                    break;
                case '3': // General
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#general').show(); // showing specific compnent
                    $('#cirCommonLink').show();
                    break;
                case '4': // Generator
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#generator').show(); // showing specific compnent
                    $('#cirCommonLink').show();
                    break;
                case '5': // General
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#transformer').show(); // showing specific compnent
                    $('#cirCommonLink').show();
                    break;
                case '6': // Main Bearing
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#mainbearing').show(); // showing specific compnent
                    $('#cirCommonLink').show();
                    break;
                case '7': // Skiipack
                    $('.templateItem').hide(); // hidding all component
                    $('#cirSBURecommendationLink').hide();
                    $('#cirSBURecommendationSection').hide();
                    $('.defaultItem').show();
                    $('#skiipack').show(); // showing specific compnent
                    $('#cirCommonLink').show();
                    break;
                case '8': // Simplified CIR
                    $('#txtCimNo_Flang').text('3664');
                    $('#txtCimNo_Flang').val('3664');
                    $('#txtCimNo_Flang').attr("readonly", true);
                    PopulateDynamicAccordian('3664');
                    if ($.trim($('#txtServiceEngineer_Flang').val()) == '') {
                        $('#txtServiceEngineer_Flang').text(CurrentUserInfo.Name);
                        $('#txtServiceEngineer_Flang').val(CurrentUserInfo.Name);
                    }
                    $('#txtServiceEngineer_Flang').attr('readonly', true);
                    $('.defaultItem').hide();
                    $('.templateItem').hide(); // hidding all component
                    $('#SimplifiedCIR').show(); // showing specific compnent
                    $('#cirSBURecommendationLink').show();
                    //$('#cirSBURecommendationSection').show();
                    break;

            }
            $('#lblTemplate').html('CIR Type');
            $('#ddlHotlist').hide();
            $('#ddlCirType').fadeIn(300);

        }
        else if (radioID.attr('id') == 'rdHotlist') {
            $('.simplifiedDT').hide();
            $('#blade').hide();
            $('#gearbox').hide();
            $('#general').hide();
            $('#generator').hide();
            $('#transformer').hide();
            $('#mainbearing').hide();
            $('#skiipack').hide();
            $('#cirSBURecommendationLink').hide();
            $('#cirSBURecommendationSection').hide();
            $('.defaultItem').show();
            $('#cirCommonLink').show();
            $('#txtVestasItemNo').val($('#ddlHotlist :selected').val());
            $('#cirBladeLink').find('a').text($('#ddlHotlist :selected').text());
            $('#lblTemplate').html('Hot List');
            $('.templateItem').hide(); // hidding all component
            var hotlistCirType = $('#ddlHotlist :selected').text();
            hotlistCirType = hotlistCirType.split(":")[0];
            hotlistCirType = hotlistCirType.substring(hotlistCirType.lastIndexOf("[") + 1, hotlistCirType.lastIndexOf("]"));
            switch (hotlistCirType) {
                case 'Blade':
                    $('#blade').show();
                    break;
                case 'Gearbox':
                    $('#gearbox').show();
                    break;
                case 'General':
                    $('#general').show();
                    break;
                case 'Generator':
                    $('#generator').show();
                    break;
                case 'Transformer':
                    $('#transformer').show();
                    break;
                case 'Main Bearing':
                    $('#mainbearing').show();
                    break;
                case 'Skiipack':
                    $('#skiipack').show();
                    break;
                case 'Simplified CIR':
                    $('#txtCimNo_Flang').text('3664');
                    $('#txtCimNo_Flang').val('3664');
                    $('#txtCimNo_Flang').attr("readonly", true);
                    PopulateDynamicAccordian('3664');
                    if ($.trim($('#txtServiceEngineer_Flang').val()) == '') {
                        $('#txtServiceEngineer_Flang').text(CurrentUserInfo.Name);
                        $('#txtServiceEngineer_Flang').val(CurrentUserInfo.Name);
                    }
                    $('#txtServiceEngineer_Flang').attr('readonly', true);
                    $('.defaultItem').hide();
                    $('.templateItem').hide(); // hidding all component
                    $('#SimplifiedCIR').show(); // showing specific compnent
                    $('#cirSBURecommendationLink').show();
                    break; // showing specific compnent
            }
            //Commented by Siddharth Chauhan on 02-06-2016
            //To show the selected cirtype text in the dynamic tab of Cir Page.
            //(SPRINT 1)Bug No. : 75525 
            //$('#ComponentName').text($('#ddlHotlist :selected').text());
            //Added by Siddharth Chauhan on 02-06-2016
            //To show the selected cirtype text in the dynamic tab of Cir Page.
            //(SPRINT 1)Bug No. : 75525 

            $('#ddlCirType').hide();
            $('#ddlHotlist').fadeIn(300);
        }
        return true;
    });

    $('#ddlServiceReportNumberType').change(function () {
        if ($('#ddlServiceReportNumberType').val() == 4) {
            $('.manServicePortNo').show();
        }
        else {
            $('.manServicePortNo').hide();
        }
    });

    $('#ddlServiceReportNumberType_Flang').change(function () {
        if ($('#ddlServiceReportNumberType_Flang').val() == 4) {
            $('.manServiceReportNo').show();
        }
        else {
            $('.manServiceReportNo').hide();
        }
    });

    $('#ddlOutSideSign').change(function () {
        if ($('#ddlOutSideSign').val() == 1) {
            $('.manDesFlangNo').show();
        }
        else {
            $('.manDesFlangNo').hide();
            $('#txtDescFlangNo').removeClass('validationerror red-tooltip');
        }
    });


    $('#ddlInstallationDateType').change(function () {
        if ($('#ddlInstallationDateType').val() == 1) {
            $('.manInstallationDate').hide();
        }
        else {
            $('.manInstallationDate').show();
        }
    });

    //$("#ddlHotlist").change(function () {
    //    $('#txtVestasItemNo').val($(this).val());
    //    //Commented by Siddharth Chauhan on 02-06-2016
    //    //To show the selected cirtype text in the dynamic tab of Cir Page.
    //    //(SPRINT 1)Bug No. : 75525 
    //    //$('#ComponentName').text($('#ddlHotlist :selected').text());

    //    //Added by Siddharth Chauhan on 02-06-2016
    //    //To show the selected cirtype text in the dynamic tab of Cir Page.
    //    //(SPRINT 1)Bug No. : 75525 
    //    $('#cirBladeLink').find('a').text($('#ddlHotlist :selected').text());
    //});

    $("#ddlOverallGearboxCondition").change(function () {
        NotifyCirMessage("Help for Overall Gearbox Condition:", '*See INS 0022-7865 in DMS for more information<br/>A <b><u>Category 1</u></b> is indicative of a normal gearbox condition.  This may include manufacturing marks that do not affect the performance of the gearbox nor require any further actions.  It is recommended that the turbine be placed in RUN status as no further actions are required.  <br />A <b><u>Category 2</u></b> demonstrates indications of minor gearbox damage and wear. These signs do not affect the performance of the gearbox in their current state but should be documented in a CIR for tracking purposes.<br />A <b><u>Category 3</u></b> demonstrates indications of advanced gearbox damage or wear. The submittal of a CIR is required for engineering monitoring and potential further recommendations. <br />A <b><u>Category 4</u></b> implies that damage in the gearbox has advanced to potential failure. A full gearbox inspection should be conducted as soon as possible to determine the extent of the damage. The engineering department in the local SBU should be consulted to determine whether the turbine is safe to run. <br /> A <b><u>Category 5</u></b> implies that the gearbox has a potentially serious failure that could cause catastrophic failure. Often accompanied by abnormal noise and vibration. A full gearbox inspection should be conducted as soon as possible to investigate the extent of the damage.', "info");
    });

    $("#ddlReportType").change(function () {
        switch ($(this).val()) {
            case '1': // Inspection
                $('#Reporhelp').attr('data-content', '');
                $('#Reporhelp').attr('data-content', 'Select “Inspection” when the component was inspected and not failed.');
                $('#Reporhelp').attr('data-original-title', 'Inspection:');
                NotifyCirMessage("", 'Select “Inspection” when the component was inspected and not failed.', "info");
                // $('#Reporhelp').attr('title', 'Inspection:');
                $('#lblActionToBeTakenOnGearbox span').remove();
                $('#lblfailuredate span').remove();
                $('#bladerepairsection').hide();
                break;
            case '2': // Failure
                $('#Reporhelp').attr('data-content', '');
                $('#Reporhelp').attr('data-content', 'If a component has failed, always select “Failure” as primary. “Failure” reports are used for statistics and notifications to supplier.');
                $('#Reporhelp').attr('data-original-title', 'Failure:');
                NotifyCirMessage("", 'If a component has failed, always select “Failure” as primary. “Failure” reports are used for statistics and notifications to supplier.', "info");
                // $('#Reporhelp').attr('title', 'Failure:');
                $('#lblActionToBeTakenOnGearbox').append('<span class="errorSpan">*</span>');
                $('#lblfailuredate span').remove();
                $('#lblfailuredate').append('<span class="errorSpan">*</span>');
                $('#bladerepairsection').hide();

                break;
            case '3': // 'Repair:'
                $('#Reporhelp').attr('data-content', '');
                $('#Reporhelp').attr('data-content', 'Select only “Repair” in situations where a “failure” already is submitted.');
                $('#Reporhelp').attr('data-original-title', 'Repair:');
                NotifyCirMessage("", 'Select only “Repair” in situations where a “failure” already is submitted.', "info");
                // $('#Reporhelp').attr('title', 'Repair:');
                $('#lblActionToBeTakenOnGearbox span').remove();
                $('#lblfailuredate span').remove();
                $('#bladerepairsection').show();
                break;
            case '4': // Replacement
                $('#Reporhelp').attr('data-content', '');
                $('#Reporhelp').attr('data-content', 'Select “Replacement” when CIM cases require replacement of unfailed components or if a “failure” CIR has been submitted already.');
                $('#Reporhelp').attr('data-original-title', 'Replacement:');
                NotifyCirMessage("", 'Select “Replacement” when CIM cases require replacement of unfailed components or if a “failure” CIR has been submitted already.', "info");
                /// $('#Reporhelp').attr('title', 'Replacement:');
                $('#lblActionToBeTakenOnGearbox span').remove();
                $('#lblfailuredate span').remove();
                $('#bladerepairsection').hide();
                break;
            case '5': // Retrofit
                $('#Reporhelp').attr('data-title', '');
                $('#Reporhelp').attr('data-title', 'Select “Retrofit” when CIM cases require replacement/repair of unfailed components.');
                $('#Reporhelp').attr('data-original-title', 'Retrofit:');
                NotifyCirMessage("", 'Select “Retrofit” when CIM cases require replacement/repair of unfailed components.', "info");
                // $('#Reporhelp').attr('title', 'Retrofit');
                $('#lblActionToBeTakenOnGearbox span').remove();
                $('#lblfailuredate span').remove();
                $('#bladerepairsection').hide();
                break;
            case '6': // CMS Inspection
                $('#Reporhelp').attr('data-title', '');
                $('#Reporhelp').attr('data-title', 'Select CMS inspections when component has been inspected due to a CMS alarm.');
                $('#Reporhelp').attr('data-original-title', 'CMS Inspection:');
                NotifyCirMessage("", 'Select CMS inspections when component has been inspected due to a CMS alarm.', "info");
                //$('#Reporhelp').attr('title', 'CMS Inspection');
                $('#lblActionToBeTakenOnGearbox span').remove();
                $('#lblfailuredate span').remove();
                $('#bladerepairsection').hide();
                break;
        }
    });

    $("#ddlOverallBladeCondition").change(function () {
        switch ($(this).val()) {
            case '1':
                $('#FaultBladeHelp').attr('data-content', '');
                $('#FaultBladeHelp').attr('data-content', ' Cosmetic. No intervention required.');
                $('#FaultBladeHelp').attr('data-original-title', 'Blade Condition 1:');
                NotifyCirMessage("", "Blade Condition 1: Cosmetic. No intervention required.", "info");
                // $('#Reporhelp').attr('title', 'Inspection:');
                break;
            case '2':
                $('#FaultBladeHelp').attr('data-content', '');
                $('#FaultBladeHelp').attr('data-content', 'Similar to cosmetic, intervention is done only if there are other problems in the blade or turbine. ');
                $('#FaultBladeHelp').attr('data-original-title', 'Blade Condition 2:');
                NotifyCirMessage("", "Blade Condition 2: Similar to cosmetic, intervention is done only if there are other problems in the blade or turbine. ", "info");
                break;
            case '3':
                $('#FaultBladeHelp').attr('data-content', '');
                $('#FaultBladeHelp').attr('data-content', 'Damage is not serious. Intervention is done during planned inspection of the turbine. Blade must be repaired within 6 months.   A modified timeframe for repair may be specified by blade specialist.');
                $('#FaultBladeHelp').attr('data-original-title', 'Blade Condition 3:');
                NotifyCirMessage("", "Blade Condition 3: Damage is not serious. Intervention is done during planned inspection of the turbine. Blade must be repaired within 6 months.   A modified timeframe for repair may be specified by blade specialist.", "info");
                break;
            case '4':
                $('#FaultBladeHelp').attr('data-content', '');
                $('#FaultBladeHelp').attr('data-content', 'Serious damage, but not threatening continued turbine operation within next 3 months. Blade must be repaired within 3 months or during next planned turbine inspection, whichever occurs first.  A modified timeframe for repair may be specified by blade specialist.');
                $('#FaultBladeHelp').attr('data-original-title', 'Blade Condition 4:');
                NotifyCirMessage("", "Blade Condition 4: Serious damage, but not threatening continued turbine operation within next 3 months. Blade must be repaired within 3 months or during next planned turbine inspection, whichever occurs first.  A modified timeframe for repair may be specified by blade specialist.", "info");
                break;
            case '5':
                $('#FaultBladeHelp').attr('data-content', '');
                $('#FaultBladeHelp').attr('data-content', 'Very Serious damage, but not threatening continued turbine operation within next 3 months. Blade must be repaired within 3 months or during next planned turbine inspection, whichever occurs first.  A modified timeframe for repair may be specified by blade specialist.');
                $('#FaultBladeHelp').attr('data-original-title', 'Blade Condition 5:');
                NotifyCirMessage("", "Blade Condition 5: Very Serious damage, but not threatening continued turbine operation within next 3 months. Blade must be repaired within 3 months or during next planned turbine inspection, whichever occurs first.  A modified timeframe for repair may be specified by blade specialist.", "info");
                break;
        }
    });


    $("#ddlHotlist").change(function () {
        $('#txtVestasItemNo').val($('#ddlHotlist :selected').val());
        $('#cirBladeLink').find('a').text($('#ddlHotlist :selected').text());
        $('#lblTemplate').html('Hot List');
        $('#cirCommonLink').show();
        $('.defaultItem').show();
        var hotlistCirType = $('#ddlHotlist :selected').text();
        hotlistCirType = hotlistCirType.split(":")[0];
        hotlistCirType = hotlistCirType.substring(hotlistCirType.lastIndexOf("[") + 1, hotlistCirType.lastIndexOf("]"));
        switch (hotlistCirType) {
            case 'Blade':
                $('#blade').show();
                break;
            case 'Gearbox':
                $('#gearbox').show();
                break;
            case 'General':
                $('#general').show();
                break;
            case 'Generator':
                $('#generator').show();
                break;
            case 'Transformer':
                $('#transformer').show();
                break;
            case 'Main Bearing':
                $('#mainbearing').show();
                break;
            case 'Skiipack':
                $('#skiipack').show();
                break;
            case 'Simplified CIR':
                $('#txtCimNo_Flang').text('3664');
                $('#txtCimNo_Flang').val('3664');
                $('#txtCimNo_Flang').attr("readonly", true);
                PopulateDynamicAccordian('3664');
                if ($.trim($('#txtServiceEngineer_Flang').val()) == '') {
                    $('#txtServiceEngineer_Flang').text(CurrentUserInfo.Name);
                    $('#txtServiceEngineer_Flang').val(CurrentUserInfo.Name);
                }
                $('#txtServiceEngineer_Flang').attr('readonly', true);
                $('.defaultItem').hide();
                $('.templateItem').hide(); // hidding all component
                $('#SimplifiedCIR').show(); // showing specific compnent
                $('#cirSBURecommendationLink').show();
                break; // showing specific compnent
            default:
                break;
        }
    });

    $("#ddlCirType").change(function () {

        //Commented by Siddharth Chauhan on 02-06-2016
        //To show the selected cirtype text in the dynamic tab of Cir Page.
        //(SPRINT 1)Bug No. : 75525         
        //$('#ComponentName').text($('#ddlCirType :selected').text());

        //Added by Siddharth Chauhan on 02-06-2016
        //To show the selected cirtype text in the dynamic tab of Cir Page.
        //(SPRINT 1)Bug No. : 75525 
        var cirTypesItemsCount = $('#ddlCirType').children('option').length;
        if (cirTypesItemsCount > 0) {

            if ($(this).val() == 8) {
                $('#cirBladeLink').find('a').text($('#ddlCirType :selected').text()).append('<i class="fa fa-fighter-jet" style="float: right; padding-right: 5px"></i>');
            }
            else {
                $('#cirBladeLink').find('a').text($('#ddlCirType :selected').text());
            }
        }

        switch ($(this).val()) {

            case '-1': //blank selection
                $('.templateItem').hide();
                $('.simplifiedDT').hide();
                $('#blade').hide();
                $('#gearbox').hide();
                $('#general').hide();
                $('#generator').hide();
                $('#transformer').hide();
                $('#mainbearing').hide();
                $('#skiipack').hide();
                $('#cirSBURecommendationLink').hide();
                $('#cirSBURecommendationSection').hide();
                $('#cirBladeLink').find('a').text("[CIR Type]");
                break;
            case '1': // Blade
                $(this).attr('data-title', 'g')
                      .attr('title', 'G');
                $('.templateItem').hide();
                $('.simplifiedDT').hide(); // hidding all component
                $('#cirSBURecommendationLink').hide();
                $('#cirSBURecommendationSection').hide();
                $('.defaultItem').show();

                $('#blade').show(); // showing specific compnent
                break;
            case '2': // Gearbox
                $('#Reporhelp').attr('data-title', '');
                $('#Reporhelp').attr('data-title', 'mala');
                $('#Reporhelp').attr('data-original-title', 'mala');
                $('#Reporhelp').attr('title', 'mala');
                $('#cirSBURecommendationLink').hide();
                $('#cirSBURecommendationSection').hide();
                $('.templateItem').hide();
                $('.simplifiedDT').hide(); // hidding all component
                $('.defaultItem').show();
                $('#gearbox').show(); // showing specific compnent

                break;
            case '3': // General
                $(this).attr('data-title', 'mala1');
                $(this).attr('title', 'mala1');
                $('.templateItem').hide();
                $('.simplifiedDT').hide(); // hidding all component
                $('#cirSBURecommendationLink').hide();
                $('#cirSBURecommendationSection').hide();
                $('.defaultItem').show();
                $('#general').show(); // showing specific compnent
                break;
            case '4': // Generator
                $('.templateItem').hide();
                $('.simplifiedDT').hide();  // hidding all component
                $('#cirSBURecommendationLink').hide();
                $('#cirSBURecommendationSection').hide();
                $('.defaultItem').show();
                $('#generator').show(); // showing specific compnent
                break;
            case '5': // General
                $('.templateItem').hide();
                $('.simplifiedDT').hide();  // hidding all component
                $('#cirSBURecommendationLink').hide();
                $('#cirSBURecommendationSection').hide();
                $('.defaultItem').show();
                $('#transformer').show(); // showing specific compnent
                break;
            case '6': // Main Bearing
                $('.templateItem').hide();
                $('.simplifiedDT').hide();  // hidding all component
                $('#cirSBURecommendationLink').hide();
                $('#cirSBURecommendationSection').hide();
                $('.defaultItem').show();
                $('#mainbearing').show(); // showing specific compnent
                break;
            case '7': // Skiipack
                $('.templateItem').hide();
                $('.simplifiedDT').hide(); // hidding all component
                $('#cirSBURecommendationLink').hide();
                $('#cirSBURecommendationSection').hide();
                $('.defaultItem').show();
                $('#skiipack').show(); // showing specific compnent
                break;
            case '8': // Simplified CIR
                $('#txtCimNo_Flang').text('3664');
                $('#txtCimNo_Flang').val('3664');
                $('#txtCimNo_Flang').attr("readonly", true);
                PopulateDynamicAccordian('3664');
                if ($.trim($('#txtServiceEngineer_Flang').val()) == '') {
                    $('#txtServiceEngineer_Flang').text(CurrentUserInfo.Name);
                    $('#txtServiceEngineer_Flang').val(CurrentUserInfo.Name);
                }
                $('#txtServiceEngineer_Flang').attr('readonly', true);
                $('.defaultItem').hide();
                $('.simplifiedDT').hide();
                $('.defaultDT').hide();
                $('.templateItem').hide(); // hidding all component
                $('#SimplifiedCIR').show(); // showing specific compnent
                $('#cirSBURecommendationLink').show();
                //$('#cirSBURecommendationSection').show();
                break;
        }
    });

    $('#linkOtherGearboxType').click(function () {
        $('#divOtherGearboxType').slideToggle(500);
        if ($(this).text() == 'Click here to insert Other Gearbox Type..') {
            $(this).text('Click here to remove Other Gearbox Type..');
        }
        else {
            $(this).text('Click here to insert Other Gearbox Type..');
        }
    });

    $('#linkAdditionalManufacturer').click(function () {
        $('#divAdditionalManufacturer').slideToggle(500);
        if ($(this).text() == 'Click here to insert Additional Manufacturer..') {
            $(this).text('Click here to remove Additional Manufacturer..');
        }
        else {
            $(this).text('Click here to insert Additional Manufacturer..');
        }
    });

    $('#linkTowerInformation').click(function () {

        $('#divTowerInformation').slideToggle(500);
        if ($(this).text() == 'Click here to insert Tower Information..') {
            $(this).text('Click here to remove Tower Information..');
        }
        else {
            $(this).text('Click here to insert Tower Information..');
        }
    });

    $('#linkGeneratorGManufacturer').click(function () {

        $('#divGeneratorGManufacturer').slideToggle(500);
        if ($(this).text() == 'Click here to insert Generator Manufacturer..') {
            $(this).text('Click here to remove Generator Manufacturer..');
        }
        else {
            $(this).text('Click here to insert Generator Manufacturer..');
        }
    });

    $('#linkElectricalPump').click(function () {
        $('#divElectricalPump').slideToggle(500);
        if ($(this).text() == 'Click here to insert Electrical Pump..') {
            $(this).text('Click here to remove Electrical Pump..');
        }
        else {
            $(this).text('Click here to insert Electrical Pump..');
        }
    });

    $('#linkShrinkElement').click(function () {

        $('#divShrinkElement').slideToggle(500);
        if ($(this).text() == 'Click here to insert Shrink Element..') {
            $(this).text('Click here to remove Shrink Element..');
        }
        else {
            $(this).text('Click here to insert Shrink Element..');
        }
    });

    $('#linkShafts').click(function () {

        $('#divShafts').slideToggle(500);
        if ($(this).text() == 'Click here to insert Shafts..') {
            $(this).text('Click here to remove Shafts..');
        }
        else {
            $(this).text('Click here to insert Shafts..');
        }
    });

    $('#linkTorqueArmSystem').click(function () {

        $('#divTorqueArmSystem').slideToggle(500);
        if ($(this).text() == 'Click here to insert Damages Torque Arm System..') {
            $(this).text('Click here to remove Torque Arm System..');
        }
        else {
            $(this).text('Click here to insert Damages Torque Arm System..');
        }
    });

    $('#linkDefectAccessories').click(function () {

        $('#divDefectAccessories').slideToggle(500);
        if ($(this).text() == 'Click here to insert Defect Accessories..') {
            $(this).text('Click here to remove Defect Accessories..');
        }
        else {
            $(this).text('Click here to insert Defect Accessories..');
        }
    });

    $('#linkMaxTemperature').click(function () {

        $('#divMaxTemperature').slideToggle(500);
        if ($(this).text() == 'Click here to insert Max Temperature..') {
            $(this).text('Click here to remove Max Temperature..');
        }
        else {
            $(this).text('Click here to insert Max Temperature..');
        }
    });

    $('#linkLeakageDroplets').click(function () {

        $('#divLeakageDroplets').slideToggle(500);
        if ($(this).text() == 'Click here to insert presence of leakage or droplets in gearbox..') {
            $(this).text('Click here to remove Leakage Droplets..');
        }
        else {
            $(this).text('Click here to insert presence of leakage or droplets in gearbox..');
        }
    });

    $('#linkOtherGearboxGType').click(function () {

        $('#divOtherGearboxGType').slideToggle(500);
        if ($(this).text() == 'Click here to insert Other Gearbox Type..') {
            $(this).text('Click here to remove Other Gearbox Type..');
        }
        else {
            $(this).text('Click here to insert Other Gearbox Type..');
        }
    });

    $('#linkBladeSlNo').click(function () {

        $('#divBladeSlNo').slideToggle(500);
        if ($(this).text() == 'Click here to insert Blade Sl No..') {
            $(this).text('Click here to remove Other Blade Sl No..');
        }
        else {
            $(this).text('Click here to insert Other Blade Sl No..');
        }
    });

    $("#ddlNumberOfComponentsSkiip").change(function () {
        var itemCount = parseInt($(this).val());
        console.log(itemCount);
        for (var i = 1; i <= 9; i++) {
            if (i > itemCount) {
                $('#divComponentIdentification' + i.toString()).hide();
                $('#divComponentIdentificationNew' + i.toString()).hide();
            }
            else {
                $('#divComponentIdentification' + i.toString()).fadeIn(200);
                $('#divComponentIdentificationNew' + i.toString()).fadeIn(200);
            }
        }
    });

    $('#ddlGearboxGManufacturer').change(function () {
        var id = $(this).val();
        GetGearboxType(id)

    });



    function checkMandatefields(parentID) {
        if ($('#' + parentID + ' #controlHeader4').val() == 12) {
            $('#' + parentID + ' .manMovFlang').show();
        }
        else {
            $('#' + parentID + ' .manMovFlang').hide();
        }
    }

    $('#cirDynamicAccordSection1 #controlHeader4').change(function () {
        var parentID = $(this).attr('data-parentId');
        checkMandatefields(parentID)

    });

    $('#cirDynamicAccordSection2 #controlHeader4').change(function () {
        var parentID = $(this).attr('data-parentId');
        checkMandatefields(parentID)

    });

    $('#cirDynamicAccordSection3 #controlHeader4').change(function () {
        var parentID = $(this).attr('data-parentId');
        checkMandatefields(parentID)

    });

    $('#cirDynamicAccordSection4 #controlHeader4').change(function () {
        var parentID = $(this).attr('data-parentId');
        checkMandatefields(parentID)

    });
    $('#cirDynamicAccordSection5 #controlHeader4').change(function () {
        var parentID = $(this).attr('data-parentId');
        checkMandatefields(parentID)

    });

    $('#cirDynamicAccordSection6 #controlHeader4').change(function () {
        var parentID = $(this).attr('data-parentId');
        checkMandatefields(parentID)

    });



    $.fn.selectOptionWithText = function selectOptionWithText(targetText) {
        return this.each(function () {
            var $selectElement, $options, $targetOption;

            $selectElement = jQuery(this);
            $options = $selectElement.find('option');
            $targetOption = $options.filter(
                function () { return jQuery(this).text() == targetText }
            );

            // We use `.prop` if it's available (which it should be for any jQuery
            // versions above and including 1.6), and fall back on `.attr` (which
            // was used for changing DOM properties in pre-1.6) otherwise.
            if ($targetOption.prop) {
                $targetOption.prop('selected', true);
            }
            else {
                $targetOption.attr('selected', 'true');
            }
        });
    }
    $('#ddlActionToBeTakenOnGearbox').change(function () {
        var t = $("option:selected", this).text();
        var d = ["", "", "", "", "", "", "", "", "", "", "", "", "", "", ""];
        $.each(d, function (i, item) {
            $("#ddlExactLocation" + (i + 1)).val("");
            $("#ddlTypeIfDamage" + (i + 1)).val("");
            $("#ddlDamageClass" + (i + 1)).val("");
            $("#ddlDecision" + (i + 1)).val("");
            $("#ddlExactLocation" + (i + 1)).removeClass('validationerror red-tooltip');
            $("#ddlTypeIfDamage" + (i + 1)).removeClass('validationerror red-tooltip');
            $("#ddlDamageClass" + (i + 1)).removeClass('validationerror red-tooltip');
            $("#ddlTypeIfDamage" + (i + 1)).empty();
            $("#ddlDamageClass" + (i + 1)).empty();
            $("#ddlDecision" + (i + 1)).empty();
            $('#ddlDecision' + (i + 1)).prop("disabled", false);
        });

        $('#ddlDecision2').prop("disabled", false);

        if (t == 'Endoscopic inspection') {
            var d = ["High Speed Pinion", "Intermediate Speed Gear Wheel", "Intermediate Speed Pinion", "Low Speed Gear Wheel", "Sun Pinion", "Planet Gear Wheel 3", "Planet Gear Wheel 2", "Planet Gear Wheel 1", "Annulus Gear (Ring gear)", "", "", "", "", ""];
            $.each(d, function (i, item) {
                $("#ddlExactLocation" + (i + 1)).selectOptionWithText(item);
                GetTypeIfDamage((i + 1));
                // $("#ddlExactLocation" + (i + 1) + " option").filter(function () { return $(this).text() == item; }).attr("selected", 'selected');
                // $("#ddlExactLocation" + (i + 1)).find('option:contains(' + item + ')').attr("selected", true);
                $("#ddlTypeIfDamage" + (i + 1)).val("");
                $("#ddlDamageClass" + (i + 1)).val("");
                $("#ddlDecision" + (i + 1)).val("");
            });

            d = ["", "", "", "", "", ""];
            $.each(d, function (i, item) {
                //$("#ddlLocation" + (i + 1) + " option").filter(function () { return $(this).text() == item; }).attr("selected", 'selected');
                $("#ddlLocation" + (i + 1)).selectOptionWithText(item);
                // $("#ddlExactLocation" + (i + 1)).find('option:contains(' + item + ')').attr("selected", true);
                $("#ddlPosition" + (i + 1)).val("");
                $("#ddlTypeofDamage" + (i + 1)).val("");
                $("#ddlBearingDamageClass" + (i + 1)).val("");
            });

        }
        if (t == 'Visual inspection') {
            var d = ["", "", "", "", "", "", "", "", "", "", "", "", "", "", ""];
            $.each(d, function (i, item) {
                $("#ddlExactLocation" + (i + 1)).val("");
                $("#ddlTypeIfDamage" + (i + 1)).val("");
                $("#ddlDamageClass" + (i + 1)).val("");
                $("#ddlDecision" + (i + 1)).val("");
                $("#ddlExactLocation" + (i + 1)).removeClass('validationerror red-tooltip');
                $("#ddlTypeIfDamage" + (i + 1)).removeClass('validationerror red-tooltip');
                $("#ddlDamageClass" + (i + 1)).removeClass('validationerror red-tooltip');
            });
            d = ["", "", "", "", "", ""];
            $.each(d, function (i, item) {
                $("#ddlLocation" + (i + 1) + " option").filter(function () { return $(this).text() == item; }).attr("selected", true);
                // $("#ddlExactLocation" + (i + 1)).find('option:contains(' + item + ')').attr("selected", true);
                $("#ddlPosition" + (i + 1)).val("");
                $("#ddlTypeofDamage" + (i + 1)).val("");
                $("#ddlBearingDamageClass" + (i + 1)).val("");
            });

        }
        checkDamageTypeRequired();
    });

    function checkDamageTypeRequired() {
        var v = "";
        $("#_sTypeDamageRequired").hide();
        $('._GearExactLocation').each(function () {
            if (parseInt($(this).val()) > 0) {
                $("#_sTypeDamageRequired").show();
            }
        });

        var v = "";
        $("#_sClassDamageRequired").hide();
        $('._TypeOfDamage').each(function () {
            var t = $("option:selected", this).text();
            if (parseInt($(this).val()) > 0) {
                if (t != "N/A")
                    $("#_sClassDamageRequired").show();
            }
        });
    }

    $('._GearExactLocation').change(function () {
        $(this).removeClass('validationerror red-tooltip');
        var id = this.id;
        var index = id.replace(/[^\d.]/g, '');

        $('#ddlTypeIfDamage' + index).empty();
        $('#ddlDamageClass' + index).empty();
        $('#ddlDecision' + index).empty();
        $('#ddlDecision' + index).prop("disabled", false);

        if ($('#ddlExactLocation' + index).val() != "") {

            GetTypeIfDamage(index);
        }
        else {
            $('#ddlTypeIfDamage' + index).append($('<option>', {
                value: "",
                text: " "
            }));
        }
        checkDamageTypeRequired();
    });

    $('._TypeOfDamage').change(function () {
        $(this).removeClass('validationerror red-tooltip');

        var id = this.id;
        var index = id.replace(/[^\d.]/g, '');
        $('#ddlDamageClass' + index).removeClass('validationerror red-tooltip');
        $('#ddlDamageClass' + index).empty();
        $('#ddlDecision' + index).empty();
        $('#ddlDecision' + index).prop("disabled", false);
        if (parseInt($('#ddlTypeIfDamage' + index).val()) > 0) {
            var t = $('#ddlTypeIfDamage' + index + ' option:selected').text();
            if (t == "N/A") {

            } else {
                GetDamageClass($('#ddlTypeIfDamage' + index).val(), index);
            }
        }
        else {

        }
        checkDamageTypeRequired();

    });

    $('._DamageClass').change(function () {
        $(this).removeClass('validationerror red-tooltip');
        var id = this.id;
        var index = id.replace(/[^\d.]/g, '');

        $('#ddlDecision' + index).empty();
        if (parseInt($('#ddlDamageClass' + index).val()) > 0) {

            GetGearsDamage(index);
        }
        else {
            $('#ddlDecision' + index).prop("disabled", false);
        }
        checkDamageTypeRequired();

    });

    $('._BearLocation').change(function () {
        $(this).removeClass('validationerror red-tooltip');
    });

    $('._BearPosition').change(function () {
        $(this).removeClass('validationerror red-tooltip');
    });
    $('._BearTypeOfDamage').change(function () {
        $(this).removeClass('validationerror red-tooltip');
        var id = this.id;
        var index = id.replace(/[^\d.]/g, '');
        if ($(this).val() != 1)
            GetBearingDamage(index)
        else
            $('#ddlBearingDamageClass' + index).empty();
    });
    $('._BearDamageClass').change(function () {
        $(this).removeClass('validationerror red-tooltip');
    });


    $("#ddlCirType").prepend("<option value='-1' selected='selected'></option>");

    $('.iCheck-helper').click(function () {
        setGeneratorInsulationData();
    });

    $('#bladerepairsection').hide();



});

function setGeneratorInsulationData() {
    if ($('#chkInsulationComments').is(':checked')) {
        $(".errorSpanGentrComments").show();
        $(".errorSpanGentr").hide();
    }
    else {
        $(".errorSpanGentrComments").hide();
        $(".errorSpanGentr").show();
    }
}

function getQueryStringValue(key) {
    return unescape(window.location.search.replace(new RegExp("^(?:.*[&\\?]" + escape(key).replace(/[\.\+\*]/g, "\\$&") + "(?:\\=([^&]*))?)?.*$", "i"), "$1"));
}
function ScrollTo(item) {
    try {
        $('html,body').animate({
            scrollTop: $("#" + item).offset().top - 45
        }, 'slow');
    }
    catch (e)
    { }
}

function changeTooltipColorTo(color) {
    $('.tooltip-inner').css('background-color', '#f00')
    $('.tooltip.top .tooltip-arrow').css('border-top-color', color);
    $('.tooltip.right .tooltip-arrow').css('border-right-color', color);
    $('.tooltip.left .tooltip-arrow').css('border-left-color', color);
    $('.tooltip.bottom .tooltip-arrow').css('border-bottom-color', color);
}

function SaveTemplateSection(allowNext) {
    var isValid = true;
    $('#ddlCirType').removeClass('validationerror red-tooltip');
    $('#ddlHotlist').removeClass('validationerror red-tooltip');

    if ($('#ddlCirType').val() == '-1' && $("#tType").val() == "rdCirType") {
        $('#ddlCirType').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlCirType');
        isValid = false;
    }
    if ($("#tType").val() == "rdHotlist" && $('#ddlHotlist').val() == '') {
        $('#ddlHotlist').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlHotlist');
        isValid = false;
    }

    if (!isValid) {
        $('#cirTemplateLink').removeClass("ui-state-default");
        $('#cirTemplateLink').addClass("ui-state-error");

        $('#cloneid-Comm').removeClass("ui-state-default");
        $('#cloneid-Comm').addClass("ui-state-error");
    }
    else {
        $('#cirTemplateLink').removeClass("ui-state-error");
        $('#cirTemplateLink').addClass("ui-state-success");

        $('#cloneid-Comm').removeClass("ui-state-error");
        $('#cloneid-Comm').addClass("ui-state-success");
    }

    if (!isValid && !allowNext)
        return isValid;
    return true;
}

function SaveCommonSection(allowNext) {
    //Data validations
    var isValid = true;
    $('#txtCimNo,#txtTurbineNumber,#txtCommisioningDate,#txtServiceEngineer,#txtInstallationDate,#txtFailureDate,#txtInspectionDate,#txtServicePortNo,#txtRunHr,#txtGenerator1Hr,#txtTotalProduction,#txtVestasItemNo,#txtQuantityOfFailedComponent,#txtDescription,#ddlRunStatusAfterInspection,#ddlServiceReportNumberType').removeClass('validationerror red-tooltip');

    var numberOnlyErrorLength = $("#cirCommonSection  [data-id='lblNumbersOnly']").length;
    if (numberOnlyErrorLength > 0) {
        ScrollTo($("#cirCommonSection  [data-id='lblNumbersOnly']")[0].id.slice(14));
        isValid = false;
    }

    if ($.trim($('#txtCimNo').val()) == '' || parseFloat($('#txtCimNo').val()) == 0) {
        $('#txtCimNo').addClass('validationerror red-tooltip');
        ScrollTo('txtCimNo');
        isValid = false;
    }
    if ($('#ddlRunStatus').val() == '0') {
        $('#ddlRunStatus').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlRunStatus');
        isValid = false;
    }
    if ($.trim($('#txtTurbineNumber').val()) == '' || parseFloat($('#txtTurbineNumber').val()) == 0) {
        $('#txtTurbineNumber').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtTurbineNumber');
        isValid = false;
    }

    if ($.trim($('#txtCommisioningDate').val()) == '') {
        $('#txtCommisioningDate').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtCommisioningDate');
        isValid = false;
    }

    if ($.trim($('#txtInstallationDate').val()) == '') {
        if ($('#ddlInstallationDateType').val() == 2 || $('#ddlInstallationDateType').val() == 0) {
            $('#txtInstallationDate').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtInstallationDate');
            isValid = false;
        }
    }

    if ($('#ddlReportType').val() == '2') {
        if ($.trim($('#txtFailureDate').val()) == '') {
            $('#txtFailureDate').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtFailureDate');
            isValid = false;
        }
        else {
            var isDateValid = CompareDates($('#txtInstallationDate').val(), $('#txtFailureDate').val());
            if (!isDateValid) {
                $('#txtFailureDate').addClass('validationerror red-tooltip');
                if (isValid)
                    ScrollTo('txtFailureDate');
                isValid = false;
            }
        }
    }

    if ($.trim($('#txtInspectionDate').val()) == '') {
        $('#txtInspectionDate').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtInspectionDate');
        isValid = false;
    }
    else {
        var isDateValid = CompareDates($('#txtFailureDate').val(), $('#txtInspectionDate').val());
        if (!isDateValid) {
            $('#txtInspectionDate').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtInspectionDate');
            isValid = false;
        }
    }

    if ($('#ddlServiceReportNumberType').val() == "") {
        $('#ddlServiceReportNumberType').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlServiceReportNumberType');
        isValid = false;
    }
    if ($.trim($('#txtServicePortNo').val()) == '' || parseFloat($('#txtServicePortNo').val()) == 0) {
        if ($('#ddlServiceReportNumberType').val() == 4) {
            $('#txtServicePortNo').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtServicePortNo');
            isValid = false;
        }
    }

    if ($.trim($('#txtServiceEngineer').val()) == '') {
        $('#txtServiceEngineer').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtServiceEngineer');
        isValid = false;
    }

    if ($.trim($('#txtRunHr').val()) == '') {
        $('#txtRunHr').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtRunHr');
        isValid = false;
    }

    if ($.trim($('#txtGenerator1Hr').val()) == '') {
        $('#txtGenerator1Hr').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtGenerator1Hr');
        isValid = false;
    }

    if ($.trim($('#txtTotalProduction').val()) == '') {
        $('#txtTotalProduction').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtTotalProduction');
        isValid = false;
    }

    if ($.trim($('#txtVestasItemNo').val()) == '' || parseFloat($('#txtVestasItemNo').val()) == 0) {
        $('#txtVestasItemNo').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtVestasItemNo');
        isValid = false;
    }

    if ($.trim($('#txtQuantityOfFailedComponent').val()) == '') {
        $('#txtQuantityOfFailedComponent').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtQuantityOfFailedComponent');
        isValid = false;
    }

    if ($.trim($('#ddlRunStatusAfterInspection').val()) == '') {
        $('#ddlRunStatusAfterInspection').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlRunStatusAfterInspection');
        isValid = false;
    }

    if ($.trim($('#txtDescription').val()) == '') {
        $('#txtDescription').addClass('validationerror red-tooltip');
        isValid = false;
    }

    if ($("#lblCIMCaseError").is(':visible') == true ||
       $("#lblTurbineError").is(':visible') == true ||
       $("#lblServicReportError").is(':visible') == true ||
        $("#lblNotificationNumberError").is(':visible') == true) {
        if ($("#lblCIMCaseError").is(':visible') == true)
            $('#txtCimNo').addClass('validationerror red-tooltip');
        if ($("#lblTurbineError").is(':visible') == true)
            $('#txtTurbineNumber').addClass('validationerror red-tooltip');
        if ($("#lblServicReportError").is(':visible') == true)
            $('#txtServicePortNo').addClass('validationerror red-tooltip'); 
        isValid = false;
    }

    if (!isValid) {
        $('#cirCommonLink').removeClass("ui-state-default");
        $('#cirCommonLink').addClass("ui-state-error");

        $('#cloneid-Comm').removeClass("ui-state-default");
        $('#cloneid-Comm').addClass("ui-state-error");
    }
    else {
        $('#cirCommonLink').removeClass("ui-state-error");
        $('#cirCommonLink').addClass("ui-state-success");

        $('#cloneid-Comm').removeClass("ui-state-error");
        $('#cloneid-Comm').addClass("ui-state-success");
    }

    if (!isValid && !allowNext)
        return isValid;
    return true;
}

function CompareDates(smallerDateString, biggerDateString) {
    var retVal = true;
    var pattern = /(\d{2})\-(\d{2})\-(\d{4})/;
    var smallerDate = new Date(smallerDateString.replace(pattern, '$3-$2-$1'));
    var biggerDate = new Date(biggerDateString.replace(pattern, '$3-$2-$1'));
    if (smallerDate > biggerDate) {
        retVal = false;
    }
    return retVal;
}

function SaveBladeSection(allowNext) {
    //Data validations
    var isValid = true;
    $('#txtBladeSerialNo,#ddlOverallBladeCondition,#txtBladeSerialNoOtherBlade,#txtBladeSerialNoOtherBlade2,#ddlBladeManufacturer,#ddlBladeLengthM,#ddlBladeColor,#ddlDamagePlacement,#ddlDamageType,#ddlBladeEdge,#ddlFaultCause,#ddlFaultType,#ddlFaultArea,#txtAmbientTemp,#txtHumidity,#txtglasssupplier,#txtglasssupplierbatchnumber,#txtmaxbladesurfacetemp,#txtminbladesurfacetemp,#txtquantityofmixedresinused,#txtmaxpostcuresurfacetemp,#txtminpostcuresurfacetemp,#txttotalcuretime').removeClass('validationerror red-tooltip');

    var numberOnlyErrorLength = $("#blade  [data-id='lblNumbersOnly']").length;
    if (numberOnlyErrorLength > 0) {
        ScrollTo($("#blade  [data-id='lblNumbersOnly']")[0].id.slice(14));
        isValid = false;
    }
    var decimalOnlyErrorLength = $("#blade  [data-id='lblDecimalsOnly']").length;
    if (decimalOnlyErrorLength > 0) {
        ScrollTo($("#blade  [data-id='lblDecimalsOnly']")[0].id.slice(15));
        isValid = false;
    }

    if ($.trim($('#txtBladeSerialNo').val()) == '' || parseFloat($('#txtBladeSerialNo').val()) == 0) {
        $('#txtBladeSerialNo').addClass('validationerror red-tooltip');
        ScrollTo('txtBladeSerialNo');
        isValid = false;
    }
    if (parseInt($('#ddlOverallBladeCondition').val()) == 0) {
        $('#ddlOverallBladeCondition').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlOverallBladeCondition');
        isValid = false;
    }
    if ($('#linkInserOtherBladeSet').text() == 'Remove other blade in set..') {
        if ($.trim($('#txtBladeSerialNoOtherBlade').val()) == '' || parseFloat($('#txtBladeSerialNoOtherBlade').val()) == 0) {
            $('#txtBladeSerialNoOtherBlade').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtBladeSerialNoOtherBlade');
            isValid = false;
        }
        if ($.trim($('#txtBladeSerialNoOtherBlade2').val()) == '' || parseFloat($('#txtBladeSerialNoOtherBlade2').val()) == 0) {
            $('#txtBladeSerialNoOtherBlade2').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtBladeSerialNoOtherBlade2');
            isValid = false;
        }
    }

    if ($('#ddlReportType').val() == '3') {

        if ($.trim($('#txtAmbientTemp').val()) == '') {
            $('#txtAmbientTemp').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('#txtAmbientTemp');
            isValid = false;
        }

        if ($.trim($('#txtHumidity').val()) == '') {
            $('#txtHumidity').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('#txtHumidity');
            isValid = false;
        }
        if ($.trim($('#txtglasssupplier').val()) == '') {
            $('#txtglasssupplier').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('#txtglasssupplier');
            isValid = false;
        }
        if ($.trim($('#txtglasssupplierbatchnumber').val()) == '') {
            $('#txtglasssupplierbatchnumber').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('#txtglasssupplierbatchnumber');
            isValid = false;
        }
        if ($.trim($('#txtmaxbladesurfacetemp').val()) == '') {
            $('#txtmaxbladesurfacetemp').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('#txtmaxbladesurfacetemp');
            isValid = false;
        }
        if ($.trim($('#txtminbladesurfacetemp').val()) == '') {
            $('#txtminbladesurfacetemp').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('#txtminbladesurfacetemp');
            isValid = false;
        }
        if ($.trim($('#txtquantityofmixedresinused').val()) == '') {
            $('#txtquantityofmixedresinused').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('#txtquantityofmixedresinused');
            isValid = false;
        }
        if ($.trim($('#txtmaxpostcuresurfacetemp').val()) == '') {
            $('#txtmaxpostcuresurfacetemp').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('#txtmaxpostcuresurfacetemp');
            isValid = false;
        }
        if ($.trim($('#txtminpostcuresurfacetemp').val()) == '') {
            $('#txtminpostcuresurfacetemp').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('#txtminpostcuresurfacetemp');
            isValid = false;
        }
        if ($.trim($('#txttotalcuretime').val()) == '') {
            $('#txttotalcuretime').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('#txttotalcuretime');
            isValid = false;
        }
    }

    $('#ddlBladeManufacturer,#ddlBladeLengthM,#ddlBladeColor,#ddlDamagePlacement,#ddlDamageType,#ddlBladeEdge,#ddlFaultCause,#ddlFaultType,#ddlFaultArea').each(function (index) {
        if ($(this).is(":visible") == true && $.trim($(this).val()) == '') {
            $(this).addClass('validationerror red-tooltip');
            isValid = false;
        }
    });

    if (!isValid) {
        $('#cirBladeLink').removeClass("ui-state-default");
        $('#cirBladeLink').addClass("ui-state-error");
    }
    else {
        $('#cirBladeLink').removeClass("ui-state-error");
        $('#cirBladeLink').addClass("ui-state-success");
    }

    if (!isValid && !allowNext)
        return isValid;


    //Blade damage data   
    var damageSections = $('.bladeDamageSection');
    if (damageSections.length > 0) {
        for (var i = 0; i < damageSections.length; i++) {
            if (damageSections[i]) {
                if ($('#' + damageSections[i].id).css('display') != 'none') {
                    var dropDamagePlacement = $('#' + damageSections[i].id).find('#ddlDamagePlacement :selected');
                    var dropDamageType = $('#' + damageSections[i].id).find('#ddlDamageType :selected');
                    var dropBladeEdge = $('#' + damageSections[i].id).find('#ddlBladeEdge :selected');
                    var txBladeRadius = $('#' + damageSections[i].id).find('#txtBladeRadius');
                    var txBladeDamageDescription = $('#' + damageSections[i].id).find('#txtBladeDamageDescription');
                    var txPictureNo = $('#' + damageSections[i].id).find('#txtPictureNo');

                    txBladeRadius.removeClass('validationerror red-tooltip');
                    txBladeDamageDescription.removeClass('validationerror red-tooltip');
                    txPictureNo.removeClass('validationerror red-tooltip');
                    if ($.trim(txBladeRadius.val()) == '' || parseFloat(txBladeRadius.val()) <= 0) {
                        txBladeRadius.addClass('validationerror red-tooltip');
                        txBladeRadius.focus();
                        if (isValid)
                            ScrollTo(txBladeRadius.attr('id'));
                        isValid = false;
                    }
                    if ($.trim(txBladeDamageDescription.val()) == '') {
                        txBladeDamageDescription.addClass('validationerror red-tooltip');
                        txBladeDamageDescription.focus();
                        if (isValid)
                            ScrollTo(txBladeDamageDescription.attr('id'));
                        isValid = false;
                    }
                    if ($.trim(txPictureNo.val()) == '' || parseFloat(txPictureNo.val()) <= 0) {
                        txPictureNo.addClass('validationerror red-tooltip');
                        txPictureNo.focus();
                        if (isValid)
                            ScrollTo(txPictureNo.attr('id'));
                        isValid = false;
                    }
                    if (!isValid) {
                        $('#cirBladeLink').removeClass("ui-state-default");
                        $('#cirBladeLink').addClass("ui-state-error");
                    }
                    else {
                        $('#cirBladeLink').removeClass("ui-state-error");
                        $('#cirBladeLink').addClass("ui-state-success");
                    }

                    if (!isValid && !allowNext)
                        return false;

                }
            }
        }
    }

    return true;
}

function SaveGeneralSection(allowNext) {
    //Data validations
    var isValid = true;
    $('#txtPositionOfFailedItem,#txtComponentSerialNumber').removeClass('validationerror red-tooltip');

    var numberOnlyErrorLength = $("#general  [data-id='lblNumbersOnly']").length;
    if (numberOnlyErrorLength > 0) {
        ScrollTo($("#general  [data-id='lblNumbersOnly']")[0].id.slice(14));
        isValid = false;
    }
    if ($.trim($('#txtPositionOfFailedItem').val()) == '') {
        $('#txtPositionOfFailedItem').addClass('validationerror red-tooltip');
        ScrollTo('txtPositionOfFailedItem');
        isValid = false;
    }
    if ($("#chkComponentSerialNumber").is(':checked') == false) {
        if ($.trim($('#txtComponentSerialNumber').val()) == '') {
            $('#txtComponentSerialNumber').addClass('validationerror red-tooltip');
            ScrollTo('txtComponentSerialNumber');
            isValid = false;
        }
    }
    if ($.trim($('#ddlComponentGroup').val()) == '') {
        $('#ddlComponentGroup').addClass('validationerror red-tooltip');
        ScrollTo('ddlComponentGroup');
        isValid = false;
    }

    if (!isValid) {
        $('#cirBladeLink').removeClass("ui-state-default");
        $('#cirBladeLink').addClass("ui-state-error");
    }
    else {
        $('#cirBladeLink').removeClass("ui-state-error");
        $('#cirBladeLink').addClass("ui-state-success");
    }

    if (!isValid && !allowNext)
        return false;
    return true;
}

function SaveCIRImages(allowNext) {
    var isValid = true;
    if ($('#chkIsPlateTypeNotPossible').is(':checked')) {
        $('#files').removeClass('validationerror');
        $('#files').removeClass('red-tooltip');
        if ($.trim($('#txtPlateTypeNotPossibleReason').val()) == '') {
            $('#txtPlateTypeNotPossibleReason').addClass('validationerror red-tooltip');
            $('#txtPlateTypeNotPossibleReason').focus();
            if (isValid)
                ScrollTo('txtPlateTypeNotPossibleReason');
            isValid = false;
        }
    }
    else {
        $('#txtPlateTypeNotPossibleReason').removeClass('validationerror');
        $('#txtPlateTypeNotPossibleReason').removeClass('red-tooltip');
        if (FileToUpload.length == 0) {
            $('#files').addClass('validationerror red-tooltip');
            $('#files').focus();
            if (isValid)
                ScrollTo('files');
            isValid = false;
        }
    }

    $('#cirImageSection .desc').each(function () {
        if ($.trim($(this).val()) == "") {
            $(this).addClass('validationerror red-tooltip');
            isValid = false;
        }
        else {
            $(this).removeClass('validationerror red-tooltip');
        }
    });
    if (!isValid) {
        $('#cirImagesLink').removeClass("ui-state-success");
        $('#cirImagesLink').addClass("ui-state-error");
    }
    else {
        $('#cirImagesLink').removeClass("ui-state-error");
        $('#cirImagesLink').addClass("ui-state-success");
    }

    if (!isValid && !allowNext)
        return false;

    var parentDiv = $('#dvPreview').find('img');

    return true;
}

function SaveSkiipackSection(allowNext) {
    //Data validations
    var isValid = true;
    $('#txtQuantityOfFailedModulesSkiip,#ddlCauseSkiip').removeClass('validationerror red-tooltip');
    var numberOnlyErrorLength = $("#skiipack  [data-id='lblNumbersOnly']").length;
    if (numberOnlyErrorLength > 0) {
        ScrollTo($("#skiipack  [data-id='lblNumbersOnly']")[0].id.slice(14));
        isValid = false;
    }
    for (var divCount = 1; divCount <= 9; divCount++) {
        if ($('#divComponentIdentification' + divCount).css('display') != 'none') {

            $('#txtSerialNumber' + divCount).removeClass('validationerror red-tooltip');
            $('#txtVestasUniqueIdentifierSkiip' + divCount).removeClass('validationerror red-tooltip');
            $('#txtItemNoSkiip' + divCount).removeClass('validationerror red-tooltip');
            $('#txtSerialNumberNew' + divCount).removeClass('validationerror red-tooltip');
            $('#txtVestasUniqueIdentifierSkiipNew' + divCount).removeClass('validationerror red-tooltip');
            $('#txtItemNoSkiipNew' + divCount).removeClass('validationerror red-tooltip');

            if ($.trim($('#txtSerialNumber' + divCount).val()) == '') {
                $('#txtSerialNumber' + divCount).addClass('validationerror red-tooltip');
                if (isValid)
                    ScrollTo('txtSerialNumber' + divCount);
                isValid = false;
            }

            if ($.trim($('#txtVestasUniqueIdentifierSkiip' + divCount).val()) == '') {
                $('#txtVestasUniqueIdentifierSkiip' + divCount).addClass('validationerror red-tooltip');
                if (isValid)
                    ScrollTo('txtVestasUniqueIdentifierSkiip' + divCount);
                isValid = false;
            }

            if ($.trim($('#txtItemNoSkiip' + divCount).val()) == '') {
                $('#txtItemNoSkiip' + divCount).addClass('validationerror red-tooltip');
                if (isValid)
                    ScrollTo('txtItemNoSkiip' + divCount);
                isValid = false;
            }

        }
        if ($('#divComponentIdentificationNew' + divCount).css('display') != 'none') {
            if ($.trim($('#txtSerialNumberNew' + divCount).val()) == '') {
                $('#txtSerialNumberNew' + divCount).addClass('validationerror red-tooltip');
                if (isValid)
                    ScrollTo('txtSerialNumberNew' + divCount);
                isValid = false;
            }

            if ($.trim($('#txtVestasUniqueIdentifierSkiipNew' + divCount).val()) == '') {
                $('#txtVestasUniqueIdentifierSkiipNew' + divCount).addClass('validationerror red-tooltip');
                if (isValid)
                    ScrollTo('txtVestasUniqueIdentifierSkiipNew' + divCount);
                isValid = false;
            }

            if ($.trim($('#txtItemNoSkiipNew' + divCount).val()) == '') {
                $('#txtItemNoSkiipNew' + divCount).addClass('validationerror red-tooltip');
                if (isValid)
                    ScrollTo('txtItemNoSkiipNew' + divCount);
                isValid = false;
            }
        }
    }

    if ($.trim($('#txtQuantityOfFailedModulesSkiip').val()) == '') {
        $('#txtQuantityOfFailedModulesSkiip').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtQuantityOfFailedModulesSkiip');
        isValid = false;
    }
    if ($.trim($('#ddlCauseSkiip').val()) == '') {
        $('#ddlCauseSkiip').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlCauseSkiip');
        isValid = false;
    }


    if (!isValid) {
        $('#cirBladeLink').removeClass("ui-state-default");
        $('#cirBladeLink').addClass("ui-state-error");
    }
    else {
        $('#cirBladeLink').removeClass("ui-state-error");
        $('#cirBladeLink').addClass("ui-state-success");
    }

    if (!isValid && !allowNext)
        return false;
    return true;
}

function SaveTransformerSection(allowNext) {
    //Data validations
    var isValid = true;
    $('#txtTransformerMaxTemp,#txtTransformerSerialNumber,#txtTransformerMaxTempDate,#ddlTransformerManufacturer2,#ddlActionToTransformer,#ddlTransformerHVCoil,#ddlTransformerLVCoil,#ddlTransformerHVCable,#ddlTransformerLVCable,#ddlTransformerBrackets,#ddlTransformerConnectionBars,#ddlTransformerSurgeArrestor,#ddlTransformerClimateCondition,#ddlTransformerArcDetection').removeClass('validationerror red-tooltip');
    var numberOnlyErrorLength = $("#transformer  [data-id='lblNumbersOnly']").length;
    if (numberOnlyErrorLength > 0) {
        ScrollTo($("#transformer  [data-id='lblNumbersOnly']")[0].id.slice(14));
        isValid = false;
    }
    if ($.trim($('#txtTransformerSerialNumber').val()) == '' || parseFloat($.trim($('#txtTransformerSerialNumber').val())) == 0) {
        $('#txtTransformerSerialNumber').addClass('validationerror red-tooltip');
        ScrollTo('txtTransformerSerialNumber');
        isValid = false;
    }
    if ($.trim($('#txtTransformerMaxTemp').val()) == '') {
        $('#txtTransformerMaxTemp').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtTransformerMaxTemp');
        isValid = false;
    }

    if ($.trim($('#txtTransformerMaxTempDate').val()) == '') {
        $('#txtTransformerMaxTempDate').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtTransformerMaxTempDate');
        isValid = false;
    }

    if ($.trim($('#ddlTransformerManufacturer2').val()) == '') {
        $('#ddlTransformerManufacturer2').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlTransformerManufacturer2');
        isValid = false;
    }
    if ($.trim($('#ddlActionToTransformer').val()) == '') {
        $('#ddlActionToTransformer').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlActionToTransformer');
        isValid = false;
    }
    if ($.trim($('#ddlTransformerHVCoil').val()) == '') {
        $('#ddlTransformerHVCoil').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlTransformerHVCoil');
        isValid = false;
    }
    if ($.trim($('#ddlTransformerLVCoil').val()) == '') {
        $('#ddlTransformerLVCoil').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlTransformerLVCoil');
        isValid = false;
    }
    if ($.trim($('#ddlTransformerHVCable').val()) == '') {
        $('#ddlTransformerHVCable').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlTransformerHVCable');
        isValid = false;
    }
    if ($.trim($('#ddlTransformerLVCable').val()) == '') {
        $('#ddlTransformerLVCable').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlTransformerLVCable');
        isValid = false;
    }
    if ($.trim($('#ddlTransformerBrackets').val()) == '') {
        $('#ddlTransformerBrackets').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlTransformerBrackets');
        isValid = false;
    }
    if ($.trim($('#ddlTransformerConnectionBars').val()) == '') {
        $('#ddlTransformerConnectionBars').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlTransformerConnectionBars');
        isValid = false;
    }
    if ($.trim($('#ddlTransformerSurgeArrestor').val()) == '') {
        $('#ddlTransformerSurgeArrestor').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlTransformerSurgeArrestor');
        isValid = false;
    }
    if ($.trim($('#ddlTransformerClimateCondition').val()) == '') {
        $('#ddlTransformerClimateCondition').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlTransformerClimateCondition');
        isValid = false;
    }
    if ($.trim($('#ddlTransformerArcDetection').val()) == '') {
        $('#ddlTransformerArcDetection').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlTransformerArcDetection');
        isValid = false;
    }

    if (!isValid) {
        $('#cirBladeLink').removeClass("ui-state-default");
        $('#cirBladeLink').addClass("ui-state-error");
    }
    else {
        $('#cirBladeLink').removeClass("ui-state-error");
        $('#cirBladeLink').addClass("ui-state-success");
    }

    if (!isValid && !allowNext)
        return false;



    return true;
}

function SaveMainBearingSection(allowNext) {
    //Data validations
    var isValid = true;
    $('#txtMainBearingSerialNumber,#txtMainBearingOilTemperature,#ddlMainBearingLubricationType,#ddlMainBearingLubricationType').removeClass('validationerror red-tooltip');

    var numberOnlyErrorLength = $("#mainbearing  [data-id='lblNumbersOnly']").length;
    if (numberOnlyErrorLength > 0) {
        ScrollTo($("#mainbearing  [data-id='lblNumbersOnly']")[0].id.slice(14));
        isValid = false;
    }
    if ($.trim($('#txtMainBearingSerialNumber').val()) == '') {
        $('#txtMainBearingSerialNumber').addClass('validationerror red-tooltip');
        ScrollTo('txtMainBearingSerialNumber');
        isValid = false;
    }

    if ($.trim($('#txtMainBearingOilTemperature').val()) == '') {

        if ($('#chkMainBearingGrease').is(':checked') == false) {
            $('#txtMainBearingOilTemperature').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtMainBearingOilTemperature');
            isValid = false;
        }
    }

    if ($.trim($('#txtMainBearingHoursBearing').val()) == '') {
        $('#txtMainBearingHoursBearing').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtMainBearingHoursBearing');
        isValid = false;
    }

    if ($.trim($('#txtMainBearingRunLubrication').val()) == '') {
        $('#txtMainBearingRunLubrication').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtMainBearingRunLubrication');
        isValid = false;
    }

    if ($.trim($('#txtMainBearingLubricationchangeDate').val()) == '') {
        $('#txtMainBearingLubricationchangeDate').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtMainBearingLubricationchangeDate');
        isValid = false;
    }
    if ($.trim($('#ddlMainBearingLubricationType').val()) == '') {
        $('#ddlMainBearingLubricationType').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('ddlMainBearingLubricationType');
        isValid = false;
    }

    if (!isValid) {
        $('#cirBladeLink').removeClass("ui-state-default");
        $('#cirBladeLink').addClass("ui-state-error");
    }
    else {
        $('#cirBladeLink').removeClass("ui-state-error");
        $('#cirBladeLink').addClass("ui-state-success");
    }

    if (!isValid && !allowNext) {
        return false;
    }
    return true;
}

function SaveSimplifiedCIRSection(allowNext, type) {

    //Data validations
    var isValid = true;
    $('#txtCimNo_Flang,#txtTurbineNumber_Flang,#txtInspectionDate_Flang,#txtServiceEngineer_Flang,#txtServicePortNo_Flang,#ddlRunStatusAfterInspection_Flang,#txtSBURecommendation_Flang,#ddlOutSideSign,#txtDescFlangNo').removeClass('validationerror red-tooltip');//#txtLatitude,#txtLongitude


    var numberOnlyErrorLength = $("#SimplifiedCIR  [data-id='lblNumbersOnly']").length;
    if (numberOnlyErrorLength > 0) {
        ScrollTo($("#SimplifiedCIR  [data-id='lblNumbersOnly']")[0].id.slice(14));
        isValid = false;
    }

    if ($.trim($('#txtCimNo_Flang').val()) == '') {
        $('#txtCimNo_Flang').addClass('validationerror red-tooltip');
        ScrollTo('txtCimNo_Flang');
        isValid = false;
    }

    if ($.trim($('#txtTurbineNumber_Flang').val()) == '') {
        $('#txtTurbineNumber_Flang').addClass('validationerror red-tooltip');

        if ($('#ddlServiceReportNumberType_Flang').val() == 4) {
            if ($.trim($('#txtServicePortNo_Flang').val()) != '') {
                $('#txtServicePortNo_Flang').addClass('validationerror red-tooltip');
                $('#lblServicReportError_Flang').show();
                $('#lblServicReportError_Flang').text('Entered Service Report Number is not valid for the entered Turbine Number !');
                isValid = false;
            }
        }


        ScrollTo('txtTurbineNumber_Flang');
        isValid = false;
    }

    if ($.trim($('#txtInspectionDate_Flang').val()) == '') {
        $('#txtInspectionDate_Flang').addClass('validationerror red-tooltip');
        ScrollTo('txtInspectionDate_Flang');
        isValid = false;
    }

    if ($.trim($('#txtServiceEngineer_Flang').val()) == '') {
        $('#txtServiceEngineer_Flang').addClass('validationerror red-tooltip');
        ScrollTo('txtServiceEngineer_Flang');
        isValid = false;
    }
    if ($('#ddlServiceReportNumberType_Flang').val() == 4) {
        if ($.trim($('#txtServicePortNo_Flang').val()) == '') {
            $('#txtServicePortNo_Flang').addClass('validationerror red-tooltip');
            ScrollTo('txtServicePortNo_Flang');
            isValid = false;
        }
    }

    if ($('#ddlOutSideSign').val() == 1) {
        if ($.trim($('#txtDescFlangNo').val()) == '') {
            $('#txtDescFlangNo').addClass('validationerror red-tooltip');
            ScrollTo('txtDescFlangNo');
            isValid = false;
        }
    }


    if ($.trim($('#ddlRunStatusAfterInspection_Flang').val()) == '') {
        $('#ddlRunStatusAfterInspection_Flang').addClass('validationerror red-tooltip');
        ScrollTo('ddlRunStatusAfterInspection_Flang');
        isValid = false;
    }
    if ($.trim($('#ddlOutSideSign').val()) == '') {
        $('#ddlOutSideSign').addClass('validationerror red-tooltip');
        ScrollTo('ddlOutSideSign');
        isValid = false;
    }
    if ($("#lblCIMCaseError_Flang").is(':visible') == true ||
           $("#lblTurbineError_Flang").is(':visible') == true ||
           $("#lblServicReportError_Flang").is(':visible') == true) {
        if ($("#lblCIMCaseError_Flang").is(':visible') == true)
            $('#txtCimNo_Flang').addClass('validationerror red-tooltip');
        if ($("#lblTurbineError_Flang").is(':visible') == true)
            $('#txtTurbineNumber_Flang').addClass('validationerror red-tooltip');
        if ($("#lblServicReportError_Flang").is(':visible') == true)
            $('#txtServicePortNo_Flang').addClass('validationerror red-tooltip');

        isValid = false;
    }

    if (!isValid) {
        $('#cirBladeLink').removeClass("ui-state-default");
        $('#cirBladeLink').addClass("ui-state-error");

        $('#cloneid-Comm').removeClass("ui-state-default");
        $('#cloneid-Comm').addClass("ui-state-error");
    }
    else {
        $('#cirBladeLink').removeClass("ui-state-error");
        $('#cirBladeLink').addClass("ui-state-success");

        $('#cloneid-Comm').removeClass("ui-state-error");
        $('#cloneid-Comm').addClass("ui-state-success");
    }

    if (type == 'Next') { GotoNextTab(0); }
    if (!isValid) {
        return false;
    }
    return true;
}

function SaveSimplifiedCirFlange(e, type, calledfrom) {
    var value;
    if (type == 'Next' || type == 'Prev') {
        value = $(e).attr('data-parentdiv');
    } else {
        value = type;
    }
    var DynamicVal = value.substr(value.length - 1);
    var isValid = true;
    if ($('#' + value + ' #chkDamageIdentifiedSimplified').is(':checked') == true) {

        $('#' + value + ' #controlHeader1').removeClass('validationerror red-tooltip');
        $('#' + value + ' #controlHeader2').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader3').removeClass('validationerror red-tooltip');
        $('#' + value + ' #ddlrowHeader4').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader5').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader6').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader7').removeClass('validationerror red-tooltip');
        $('#' + value + ' #chkrowHeader8').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader9').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader10').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader11').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader12').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader13').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader14').removeClass('validationerror red-tooltip');

        var numberOnlyErrorLength = $("#" + value + "  [data-id='lblNumbersOnly']").length;
        if (numberOnlyErrorLength > 0) {
            ScrollTo($("#" + value + "  [data-id='lblNumbersOnly']")[0].id.slice(14));
            isValid = false;
        }

        if ($.trim($('#' + value + ' #controlHeader1').val()) == 'undefined' || $.trim($('#' + value + ' #controlHeader1').val()) == '' || $.trim($('#' + value + ' #controlHeader1').val()) == '-1') {
            $('#' + value + ' #controlHeader1').addClass('validationerror red-tooltip');
            if (calledfrom != 'damageIdentified') {
                ScrollTo(value + ' #controlHeader1');
            }
            isValid = false;
        }
        if ($.trim($('#' + value + ' #controlHeader2').val()) == 'undefined' || $.trim($('#' + value + ' #controlHeader2').val()) == '' || $.trim($('#' + value + ' #controlHeader2').val()) == '-1') {
            $('#' + value + ' #controlHeader2').addClass('validationerror red-tooltip');
            if (calledfrom != 'damageIdentified') {
                ScrollTo(value + ' #controlHeader2');
            }
            isValid = false;
        }
        if ($.trim($('#' + value + ' #txtrowHeader13').val()) == '') {
            $('#' + value + ' #txtrowHeader13').addClass('validationerror red-tooltip');
            if (calledfrom != 'damageIdentified') {
                ScrollTo(value + ' #txtrowHeader13');
            }
            isValid = false;
        }
        if ($.trim($('#' + value + ' #txtrowHeader14').val()) == '') {
            $('#' + value + ' #txtrowHeader14').addClass('validationerror red-tooltip');
            if (calledfrom != 'damageIdentified') {
                ScrollTo(value + ' #txtrowHeader14');
            }
            isValid = false;
        }
        if ($.trim($('#' + value + ' #txtrowHeader3').val()) == '') {
            $('#' + value + ' #txtrowHeader3').addClass('validationerror red-tooltip');
            if (calledfrom != 'damageIdentified') {
                ScrollTo(value + ' #txtrowHeader3');
            }
            isValid = false;
        }
        if ($('#' + value + ' #controlHeader4').val() == 12) {
            $('#' + value + ' .manMovFlang').show();
            if ($.trim($('#' + value + ' #txtrowHeader5').val()) == '' || $.trim($('#' + value + ' #txtrowHeader5').val()) < 0 || $.trim($('#' + value + ' #txtrowHeader5').val()) > 200) {
                $('#' + value + ' #txtrowHeader5').addClass('validationerror red-tooltip');
                if (calledfrom != 'damageIdentified') {
                    ScrollTo(value + ' #txtrowHeader5');
                }
                isValid = false;
            }
            if ($.trim($('#' + value + ' #txtrowHeader6').val()) == '' || $.trim($('#' + value + ' #txtrowHeader6').val()) < 0 || $.trim($('#' + value + ' #txtrowHeader6').val()) > 200) {
                $('#' + value + ' #txtrowHeader6').addClass('validationerror red-tooltip');
                if (calledfrom != 'damageIdentified') {
                    ScrollTo(value + ' #txtrowHeader6');
                }
                isValid = false;
            }
            if ($.trim($('#' + value + ' #txtrowHeader7').val()) == '' || $.trim($('#' + value + ' #txtrowHeader7').val()) < 0 || $.trim($('#' + value + ' #txtrowHeader7').val()) > 200) {
                $('#' + value + ' #txtrowHeader7').addClass('validationerror red-tooltip');
                if (calledfrom != 'damageIdentified') {
                    ScrollTo(value + ' #txtrowHeader7');
                }
                isValid = false;
            }


        }

        if ($.trim($('#' + value + ' #controlHeader4').val()) == 'undefined' || $.trim($('#' + value + ' #controlHeader4').val()) == '' || $.trim($('#' + value + ' #controlHeader4').val()) == -1) {
            $('#' + value + ' #controlHeader4').addClass('validationerror red-tooltip');
            if (calledfrom != 'damageIdentified') {
                ScrollTo(value + ' #controlHeader4');
            }
            isValid = false;
        }


        if (calledfrom != 'damageIdentified') {
            if ($.trim($('#' + value + ' #txtrowHeader9').val()) != '' && (parseInt($.trim($('#' + value + ' #txtrowHeader9').val())) < 0 || parseInt($.trim($('#' + value + ' #txtrowHeader9').val())) > 200)) {
                $('#' + value + ' #txtrowHeader9').addClass('validationerror red-tooltip');
                ScrollTo(value + ' #txtrowHeader9');
                isValid = false;
            }
        }
        if (calledfrom != 'damageIdentified') {
            if ($.trim($('#' + value + ' #txtrowHeader10').val()) != '' && (parseInt($.trim($('#' + value + ' #txtrowHeader10').val())) < 0 || parseInt($.trim($('#' + value + ' #txtrowHeader10').val())) > 200)) {
                $('#' + value + ' #txtrowHeader10').addClass('validationerror red-tooltip');
                ScrollTo(value + ' #txtrowHeader10');
                isValid = false;
            }
        }
        if (calledfrom != 'damageIdentified') {
            if ($.trim($('#' + value + ' #txtrowHeader11').val()) != '' && (parseInt($.trim($('#' + value + ' #txtrowHeader11').val())) < 0 || parseInt($.trim($('#' + value + ' #txtrowHeader11').val())) > 200)) {
                $('#' + value + ' #txtrowHeader11').addClass('validationerror red-tooltip');
                ScrollTo(value + ' #txtrowHeader11');
                isValid = false;
            }
        }
        if (calledfrom != 'damageIdentified') {
            if ($.trim($('#' + value + ' #txtrowHeader12').val()) != '' && (parseInt($.trim($('#' + value + ' #txtrowHeader12').val())) < 0 || parseInt($.trim($('#' + value + ' #txtrowHeader12').val())) > 200)) {
                $('#' + value + ' #txtrowHeader12').addClass('validationerror red-tooltip');
                ScrollTo(value + ' #txtrowHeader12');
                isValid = false;
            }
        }
    }

    if (calledfrom != 'damageIdentified') {
        if (type == 'Prev') {
            GotoPrevTab(DynamicVal);
        }
        if (type == 'Next') { GotoNextTab(DynamicVal); }

    }

    if (!isValid) {
        $('#cirDynamicAccord' + DynamicVal).removeClass("ui-state-default");
        $('#cirDynamicAccord' + DynamicVal).addClass("ui-state-error");

        $('#cloneid-Comm').removeClass("ui-state-default");
        $('#cloneid-Comm').addClass("ui-state-error");
        return false;
    }
    else {
        $('#cirDynamicAccord' + DynamicVal).removeClass("ui-state-error");
        $('#cirDynamicAccord' + DynamicVal).addClass("ui-state-success");

        $('#' + value + ' #controlHeader1').removeClass('validationerror red-tooltip');
        $('#' + value + ' #controlHeader2').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader3').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader5').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader6').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader7').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader9').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader10').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader11').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader12').removeClass('validationerror red-tooltip');
        $('#' + value + ' #controlHeader4').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader13').removeClass('validationerror red-tooltip');
        $('#' + value + ' #txtrowHeader14').removeClass('validationerror red-tooltip');

        $('#cloneid-Comm').removeClass("ui-state-error");
        $('#cloneid-Comm').addClass("ui-state-success");

    }
    return true;
}
function GotoNextTab(DynamicVal) {
    if (DynamicVal == 6) {
        $('#cirSBURecommendationLink').click();
    }
    else {
        DynamicVal++;
        var display = $("#cirDynamicAccord" + DynamicVal).css("display");
        if (display != "none" && DynamicVal <= 6) {
            $('#cirDynamicAccord' + DynamicVal).click();
        }
        else {
            DynamicVal++;
            GotoNextTab(DynamicVal);
        }
    }
}

function GotoPrevTab(DynamicVal) {
    if (DynamicVal == 1) {
        $('#cirBladeLink').click();
    }
    else {
        DynamicVal--;
        var display = $("#cirDynamicAccord" + DynamicVal).css("display");
        if (display != "none" && DynamicVal >= 1) {
            $('#cirDynamicAccord' + DynamicVal).click();
        }
        else {
            DynamicVal--;
            GotoPrevTab(DynamicVal);
        }
    }
}

function SaveSBURecommendation(type) {
    //var isValid = true;
    //if ($.trim($('#txtSBURecommendation_Flang').val()) == '') {
    //    $('#txtSBURecommendation_Flang').addClass('validationerror red-tooltip');
    //    $('#cirSBURecommendationLink').removeClass("ui-state-default");
    //    $('#cirSBURecommendationLink').addClass("ui-state-error");
    //    ScrollTo('txtSBURecommendation_Flang');
    //    isValid = false;
    //}
    //else {
    //    $('#txtSBURecommendation_Flang').removeClass('validationerror red-tooltip');
    $('#cirSBURecommendationLink').removeClass("ui-state-default");
    $('#cirSBURecommendationLink').removeClass("ui-state-error");
    $('#cirSBURecommendationLink').addClass("ui-state-success");
    //}
    if (type == 'Prev') {
        GotoPrevTab(7);
    }
    if (type == 'Next') {
        $('#cirSubmitLink').click();
    }
    //if (!isValid) {
    //    return false;
    //}
    return true;
}

function ValidateSimplifiedCIROnSubmit() {
    var isValid = true;
    for (var i = 1; i <= 6; i++) {
        if (!SaveSimplifiedCirFlange('', 'cirDynamicAccordSection' + i))
        { isValid = false; }
    }
    return isValid;
}

$(document).ready(function () {
    if (hasRole("Administrator") || hasRole("Member")) {
        document.getElementById("linkSubmitCIR").innerHTML = ((_cacheCirID > 0) ? "Update CIR" : "Submit CIR");
        document.getElementById("linkSubmitApproveCIR").innerHTML = ((_cacheCirID > 0) ? "Update & Approve CIR" : "Submit & Approve CIR");
        $("#linkSubmitApproveCIR").show();
    }
    else {
        $("#linkSubmitApproveCIR").hide();
    }
    $(".ex_valid").on('change', function (e) {

        if ($(this).val() == 6) {
            $(this).removeClass('validationerror red-tooltip');
            $(this).closest('div').parent().find('.errorSpanGentr').hide();
            $(this).closest('div').parent().find('input').removeClass('validationerror red-tooltip');
        }
        else {
            $(this).closest('div').parent().find('.errorSpanGentr').show();

        }
    });
});


function ControlIsvalid(controlddlId, textboxId, isValid) {
    if (($(controlddlId).val() != 6)) {
        $("#" + textboxId).addClass('validationerror  red-tooltip');
        if (isValid)
            ScrollTo(textboxId);
        isValid = false;
    }
    return isValid;
}

function SaveGeneratorSection(allowNext) {
    //Data validations
    var isValid = true;
    $('#txtGeneratorSearialNo,#txtGeneratorMaxTemp,#txtGeneratorMaxTempResetDate,#txtGeneratorInsulationComments,#txtGeneratorTestResultUGround,#txtGeneratorTestResultWGround,#txtGeneratorTestResultWGround,#txtGeneratorTestResultVGround,#txtGeneratorTestResultUV,#txtGeneratorTestResultUW,#txtGeneratorTestResultVW,#txtGeneratorTestResultKGround,#txtGeneratorTestResultLGround,#txtGeneratorTestResultMGround,#txtGeneratorInductanceTestU1U2,#txtGeneratorInductanceTestV1V2,#txtGeneratorInductanceTestW1W2,#txtGeneratorInductanceTestK1L1,#txtGeneratorInductanceTestL1M1,#txtGeneratorInductanceTestK1M1,#txtGeneratorInductanceTestK2L2,#txtGeneratorInductanceTestL2M2,#txtGeneratorInductanceTestK2M2,#ddlGeneratorManufacturer2,#ddlGeneratorCoupling,#ddlGeneratorDriveEnd,#ddlGeneratorNonDriveEnd,#ddlGeneratorRotor,#ddlGeneratorCover,#ddlGeneratorTestResultUGroundUnit,#ddlGeneratorTestResultWGroundUnit,#ddlGeneratorTestResultVGroundUnit,#ddlGeneratorTestResultUVUnit,#ddlGeneratorTestResultUWUnit,#ddlGeneratorTestResultVWUnit,#ddlGeneratorTestResultKGroundUnit,#ddlGeneratorTestResultLGroundUnit,#ddlGeneratorTestResultMGroundUnit,#ddlGeneratorActionToBeTaken,#txtOtherManufacturerName').removeClass('validationerror red-tooltip');
    var numberOnlyErrorLength = $("#generator  [data-id='lblNumbersOnly']").length;
    var decimalOnlyErrorLength = $("#generator  [data-id='lblDecimalsOnly']").length;
    if (decimalOnlyErrorLength > 0) {
        ScrollTo($("#generator  [data-id='lblDecimalsOnly']")[0].id.slice(15));
        isValid = false;
    }
    if (numberOnlyErrorLength > 0) {
        ScrollTo($("#generator  [data-id='lblNumbersOnly']")[0].id.slice(14));
        isValid = false;
    }
    if ($.trim($('#txtGeneratorSearialNo').val()) == '') {
        $('#txtGeneratorSearialNo').addClass('validationerror red-tooltip');
        ScrollTo('txtGeneratorSearialNo');
        isValid = false;
    }


    if (($('#ddlGeneratorManufacturer2').val() == '5') && ($.trim($('#txtOtherManufacturerName').val()) == '')) {
        $('#txtOtherManufacturerName').addClass('validationerror red-tooltip');
        ScrollTo('txtOtherManufacturerName');
        isValid = false;
    }

    if ($.trim($('#txtGeneratorMaxTemp').val()) == '') {
        $('#txtGeneratorMaxTemp').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtGeneratorMaxTemp');
        isValid = false;
    }
    if ($.trim($('#txtGeneratorMaxTempResetDate').val()) == '') {
        $('#txtGeneratorMaxTempResetDate').addClass('validationerror red-tooltip');
        if (isValid)
            ScrollTo('txtGeneratorMaxTempResetDate');
        isValid = false;
    }
    if ($('#chkInsulationComments').is(':checked')) {
        if ($.trim($('#txtGeneratorInsulationComments').val()) == '') {
            $('#txtGeneratorInsulationComments').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtGeneratorInsulationComments');
            isValid = false;
        }
    }
    else {
        if ($.trim($('#txtGeneratorTestResultUGround').val()) == '') {
            isValid = ControlIsvalid('#ddlGeneratorTestResultUGroundUnit', 'txtGeneratorTestResultUGround', isValid);
        }
        if ($.trim($('#txtGeneratorTestResultWGround').val()) == '') {
            isValid = ControlIsvalid('#ddlGeneratorTestResultWGroundUnit', 'txtGeneratorTestResultWGround', isValid);
        }
        if ($.trim($('#txtGeneratorTestResultVGround').val()) == '') {
            isValid = ControlIsvalid('#ddlGeneratorTestResultVGroundUnit', 'txtGeneratorTestResultVGround', isValid);
        }

        if ($.trim($('#txtGeneratorTestResultUV').val()) == '') {
            isValid = ControlIsvalid('#ddlGeneratorTestResultUVUnit', 'txtGeneratorTestResultUV', isValid);
        }
        if ($.trim($('#txtGeneratorTestResultUW').val()) == '') {
            isValid = ControlIsvalid('#ddlGeneratorTestResultUWUnit', 'txtGeneratorTestResultUW', isValid);
        }
        if ($.trim($('#txtGeneratorTestResultVW').val()) == '') {
            isValid = ControlIsvalid('#ddlGeneratorTestResultVWUnit', 'txtGeneratorTestResultVW', isValid);
        }
        if ($.trim($('#txtGeneratorTestResultKGround').val()) == '') {
            isValid = ControlIsvalid('#ddlGeneratorTestResultKGroundUnit', 'txtGeneratorTestResultKGround', isValid);
        }
        if ($.trim($('#txtGeneratorTestResultLGround').val()) == '') {
            isValid = ControlIsvalid('#ddlGeneratorTestResultLGroundUnit', 'txtGeneratorTestResultLGround', isValid);
        }
        if ($.trim($('#txtGeneratorTestResultMGround').val()) == '') {
            isValid = ControlIsvalid('#ddlGeneratorTestResultMGroundUnit', 'txtGeneratorTestResultMGround', isValid);
        }
        if ($.trim($('#txtGeneratorInductanceTestU1U2').val()) == '') {
            $('#txtGeneratorInductanceTestU1U2').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtGeneratorInductanceTestU1U2');
            isValid = false;
        }
        if ($.trim($('#txtGeneratorInductanceTestV1V2').val()) == '') {
            $('#txtGeneratorInductanceTestV1V2').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtGeneratorInductanceTestV1V2');
            isValid = false;
        }
        if ($.trim($('#txtGeneratorInductanceTestW1W2').val()) == '') {
            $('#txtGeneratorInductanceTestW1W2').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtGeneratorInductanceTestW1W2');
            isValid = false;
        }
        if ($.trim($('#txtGeneratorInductanceTestK1L1').val()) == '') {
            $('#txtGeneratorInductanceTestK1L1').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtGeneratorInductanceTestK1L1');
            isValid = false;
        }
        if ($.trim($('#txtGeneratorInductanceTestL1M1').val()) == '') {
            $('#txtGeneratorInductanceTestL1M1').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtGeneratorInductanceTestL1M1');
            isValid = false;
        }
        if ($.trim($('#txtGeneratorInductanceTestK1M1').val()) == '') {
            $('#txtGeneratorInductanceTestK1M1').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtGeneratorInductanceTestK1M1');
            isValid = false;
        }
        if ($.trim($('#txtGeneratorInductanceTestK2L2').val()) == '') {
            $('#txtGeneratorInductanceTestK2L2').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtGeneratorInductanceTestK2L2');
            isValid = false;
        }
        if ($.trim($('#txtGeneratorInductanceTestL2M2').val()) == '') {
            $('#txtGeneratorInductanceTestL2M2').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtGeneratorInductanceTestL2M2');
            isValid = false;
        }
        if ($.trim($('#txtGeneratorInductanceTestK2M2').val()) == '') {
            $('#txtGeneratorInductanceTestK2M2').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtGeneratorInductanceTestK2M2');
            isValid = false;
        }

        $('#ddlGeneratorTestResultUGroundUnit,#ddlGeneratorTestResultWGroundUnit,#ddlGeneratorTestResultVGroundUnit,#ddlGeneratorTestResultUVUnit,#ddlGeneratorTestResultUWUnit,#ddlGeneratorTestResultVWUnit,#ddlGeneratorTestResultKGroundUnit,#ddlGeneratorTestResultLGroundUnit,#ddlGeneratorTestResultMGroundUnit').each(function (index) {
            if (($.trim($(this).val()) == '') && ($(this).val() != 6)) {
                //txtGeneratorTestResultUGround
                $(this).addClass('validationerror red-tooltip');
                isValid = false;
            }
        });

    }


    $('#ddlGeneratorManufacturer2,#ddlGeneratorCoupling,#ddlGeneratorDriveEnd,#ddlGeneratorNonDriveEnd,#ddlGeneratorRotor,#ddlGeneratorCover,#ddlGeneratorActionToBeTaken').each(function (index) {
        if ($.trim($(this).val()) == '') {
            $(this).addClass('validationerror red-tooltip');
            isValid = false;
        }
    });


    if (!isValid) {
        $('#cirBladeLink').removeClass("ui-state-default");
        $('#cirBladeLink').addClass("ui-state-error");
    }
    else {
        $('#cirBladeLink').removeClass("ui-state-error");
        $('#cirBladeLink').addClass("ui-state-success");
    }

    if (!isValid && !allowNext)
        return false;

    return true;
}

function SaveGearboxSection(allowNext) {
    //Data validations
    var isValid = true;
    $('#ddlVibrations,#ddlNoise,#ddlDebrisOnMagnet,#ddlMagnetPos,#ddlDebrisFoundinGearbox,#txtGearboxSerialNumber,#txtOilTemperatureAtOilLevelCheck,#txtSerialNumberofShrinkElement,#ddlGearboxGManufacturer,#ddlGearboxGType,#ddlGearboxGRevision,#ddlOilGearType,#ddlTypeOfMechanicalOilPump,#ddlOilLevelInGearbox,#ddlActionToBeTakenOnGearbox').removeClass('validationerror red-tooltip');
    var numberOnlyErrorLength = $("#gearbox  [data-id='lblNumbersOnly']").length;
    if (numberOnlyErrorLength > 0) {
        ScrollTo($("#gearbox  [data-id='lblNumbersOnly']")[0].id.slice(14));
        isValid = false;
    }
    if ($.trim($('#txtGearboxSerialNumber').val()) == '') {
        $('#txtGearboxSerialNumber').addClass('validationerror red-tooltip');
        ScrollTo('txtGearboxSerialNumber');
        isValid = false;
    }
    if ($.trim($('#txtOilTemperatureAtOilLevelCheck').val()) == '') {
        $('#txtOilTemperatureAtOilLevelCheck').addClass('validationerror red-tooltip');
        $('#txtOilTemperatureAtOilLevelCheck').focus();
        if (isValid)
            ScrollTo('txtOilTemperatureAtOilLevelCheck');
        isValid = false;
    }
    if ($.trim($('#txtSerialNumberofShrinkElement').val()) == '') {
        if ($('#linkShrinkElement').text() == 'Click here to remove Shrink Element..') {
            $('#txtSerialNumberofShrinkElement').addClass('validationerror red-tooltip');
            if (isValid)
                ScrollTo('txtSerialNumberofShrinkElement');
            isValid = false;
        }
    }
    $('#ddlGearboxGManufacturer,#ddlGearboxGType,#ddlGearboxGRevision,#ddlOilGearType,#ddlTypeOfMechanicalOilPump,#ddlOilLevelInGearbox').each(function (index) {
        if ($.trim($(this).val()) == '') {
            $(this).addClass('validationerror red-tooltip');
            isValid = false;
        }
    });



    if ($('#ddlReportType').val() == '2') {
        if (parseInt($("#hdntemplateVersion").val()) > 6) {
            $('#ddlActionToBeTakenOnGearbox').each(function (index) {
                if ($.trim($(this).val()) == '') {
                    $(this).addClass('validationerror red-tooltip');
                    isValid = false;
                }
            });
        }
    }
    $('._BearLocation').each(function () {
        $(this).removeClass('validationerror red-tooltip');
    });
    $('._BearPosition').each(function () {
        $(this).removeClass('validationerror red-tooltip');
    });
    $('._BearTypeOfDamage').each(function () {
        $(this).removeClass('validationerror red-tooltip');
    });
    $('._BearDamageClass').each(function () {
        $(this).removeClass('validationerror red-tooltip');
    });

    $('._GearExactLocation').each(function () {
        $(this).removeClass('validationerror red-tooltip');
    });
    $('._TypeOfDamage').each(function () {
        $(this).removeClass('validationerror red-tooltip');
    });
    $('._DamageClass').each(function () {
        $(this).removeClass('validationerror red-tooltip');
    });
    if ($("#ddlActionToBeTakenOnGearbox").is(":visible")) {
        var t = $("#ddlActionToBeTakenOnGearbox option:selected").text();

        //for (var i = 1 ; i <= 10 ; i++) {
        //    if ($("#ddlExactLocation" + i).val() == "") {
        //        $("#ddlExactLocation" + i).addClass('validationerror red-tooltip');
        //        isValid = false;
        //    }
        //    if ($("#ddlTypeIfDamage" + i).val() == "") {
        //        $("#ddlTypeIfDamage" + i).addClass('validationerror red-tooltip');
        //        isValid = false;
        //    }
        //    if ($("#ddlTypeIfDamage" + i).val() != "" && $("#ddlDamageClass" + i).val() == "") {
        //        $("#ddlDamageClass" + i).addClass('validationerror red-tooltip');
        //        isValid = false;
        //    }
        //}
        for (var i = 1 ; i <= 15 ; i++) {
            $("#ddlExactLocation" + i).removeClass('validationerror red-tooltip');
            $("#ddlTypeIfDamage" + i).removeClass('validationerror red-tooltip');
            $("#ddlDamageClass" + i).removeClass('validationerror red-tooltip');
            $("#ddlDecision" + i).removeClass('validationerror red-tooltip');

            var t = $('#ddlTypeIfDamage' + i + ' option:selected').text();

            if ($("#ddlExactLocation" + i).val() == "" && ($("#ddlTypeIfDamage" + i).val() == "" || $("#ddlTypeIfDamage" + i).val() == null)
                && ($("#ddlDamageClass" + i).val() == "" || $("#ddlDamageClass" + i).val() == null) && ($("#ddlDecision" + i).val() == "" || $("#ddlDecision" + i).val() == null)) {

            }
            else {
                if ($("#ddlTypeIfDamage" + i).val() == "" || $("#ddlTypeIfDamage" + i).val() == null || $("#ddlTypeIfDamage" + i).val() == "") {
                    $("#ddlTypeIfDamage" + i).addClass('validationerror red-tooltip');
                    isValid = false;
                }
                else if ($("#ddlDamageClass" + i).val() == "" || $("#ddlDamageClass" + i).val() == null) {
                    if (t != "N/A") {
                        $("#ddlDamageClass" + i).addClass('validationerror red-tooltip');
                        isValid = false;
                    }
                }
                else {
                    if ($("#ddlDecision" + i).val() == "" || $("#ddlDecision" + i).val() == null) {
                        if (t != "N/A") {
                            $("#ddlDecision" + i).addClass('validationerror red-tooltip');
                            isValid = false;
                        }
                    }
                }
            }
        }

        //Validate in both cases 
        //for (var i = 1 ; i <= 2 ; i++) {
        //    if ($("#ddlLocation" + i).val() == "") {
        //        $("#ddlLocation" + i).addClass('validationerror red-tooltip');
        //        isValid = false;
        //    }
        //    if ($("#ddlPosition" + i).val() == "") {
        //        $("#ddlPosition" + i).addClass('validationerror red-tooltip');
        //        isValid = false;
        //    }
        //    if ($("#ddlTypeofDamage" + i).val() == "") {
        //        $("#ddlTypeofDamage" + i).addClass('validationerror red-tooltip');
        //        isValid = false;
        //    }
        //    if ($("#ddlTypeofDamage" + i).val() != "" && $("#ddlBearingDamageClass" + i).val() == "") {
        //        $("#ddlBearingDamageClass" + i).addClass('validationerror red-tooltip');
        //        isValid = false;
        //    }
        //}
        for (var i = 1 ; i <= 6 ; i++) {
            if ($("#ddlLocation" + i).val() == "" && $("#ddlPosition" + i).val() == "" && $("#ddlTypeofDamage" + i).val() == "") {
            }
            else {
                if ($("#ddlLocation" + i).val() == "") {
                    $("#ddlLocation" + i).addClass('validationerror red-tooltip');
                    isValid = false;
                }
                if ($("#ddlPosition" + i).val() == "") {
                    $("#ddlPosition" + i).addClass('validationerror red-tooltip');
                    isValid = false;
                }
                if ($("#ddlTypeofDamage" + i).val() == "") {
                    $("#ddlTypeofDamage" + i).addClass('validationerror red-tooltip');
                    isValid = false;
                }
                if ($("#ddlTypeofDamage" + i).val() != "" && $("#ddlBearingDamageClass" + i).val() == "") {
                    $("#ddlBearingDamageClass" + i).addClass('validationerror red-tooltip');
                    isValid = false;
                }
            }
        }


    }

    if ($.trim($('#ddlVibrations').val()) == '') {
        $('#ddlVibrations').addClass('validationerror red-tooltip');
        ScrollTo('ddlVibrations');
        isValid = false;
    }
    if ($.trim($('#ddlNoise').val()) == '') {
        $('#ddlNoise').addClass('validationerror red-tooltip');
        ScrollTo('ddlNoise');
        isValid = false;
    }
    if ($.trim($('#ddlDebrisOnMagnet').val()) == '') {
        $('#ddlDebrisOnMagnet').addClass('validationerror red-tooltip');
        ScrollTo('ddlDebrisOnMagnet');
        isValid = false;
    }
    if ($.trim($('#ddlMagnetPos').val()) == '') {
        $('#ddlMagnetPos').addClass('validationerror red-tooltip');
        ScrollTo('ddlMagnetPos');
        isValid = false;
    }
    if ($.trim($('#ddlDebrisFoundinGearbox').val()) == '') {
        $('#ddlDebrisFoundinGearbox').addClass('validationerror red-tooltip');
        ScrollTo('ddlDebrisFoundinGearbox');
        isValid = false;
    }

    if (!isValid) {
        $('#cirBladeLink').removeClass("ui-state-default");
        $('#cirBladeLink').addClass("ui-state-error");
    }
    else {
        $('#cirBladeLink').removeClass("ui-state-error");
        $('#cirBladeLink').addClass("ui-state-success");
    }
    //To navigate one tab to another without blocking a user.
    if (!isValid && !allowNext)
        return false;

    return true;
}

function SaveDynamicTable() {
    return true;
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

function PopulateDynamicTable(cimCaseNumber) {
    console.log('Populating Dynamic Table for Cim: ' + cimCaseNumber);

    $('#DynamicTableHeader').text('Table Header');
    $('#txtRow0Col1').html('');
    $('#txtRow0Col2').html('');
    $('#txtRow0Col3').html('');
    $('#txtRow0Col4').html('');
    $('#txtRow0Col5').html('');
    $('#txtRow0Col6').html('');
    $('#txtRow1Col0').html('');
    $('#txtRow2Col0').html('');
    $('#txtRow3Col0').html('');
    $('#txtRow4Col0').html('');
    $('#txtRow5Col0').html('');
    $('#txtRow6Col0').html('');
    $('#txtRow7Col0').html('');
    $('#txtRow8Col0').html('');
    $('#txtRow9Col0').html('');
    $('#txtRow10Col0').html('');
    $('#cirDynamicTableLink').hide();
    // hide Simplified CIR Dynamic Accords
    $('#cirDynamicAccord1').hide();
    $('#cirDynamicAccord2').hide();
    $('#cirDynamicAccord3').hide();
    $('#cirDynamicAccord4').hide();
    $('#cirDynamicAccord5').hide();
    $('#cirDynamicAccord6').hide();
    dbtransaction.openDatabase(function () {
        dbtransaction.getDynamicInputFromCimCase(cimCaseNumber, function dynamicInputs(inputs) {
            if (inputs) {
                inputs.forEach(function (item) {
                    var jSonItem = jQuery.parseJSON(item.text.replace(/(\r\n|\n|\r)/gm, ""));
                    if (jSonItem) {
                        if (jSonItem.CIMcaseNo == cimCaseNumber) {
                            $('#DynamicTableHeader').text(jSonItem.TableHeader);
                            $('#txtRow0Col1').html(jSonItem.ColHeader1, 1);
                            $('#txtRow0Col2').html(jSonItem.ColHeader2, 1);
                            $('#txtRow0Col3').html(jSonItem.ColHeader3, 1);
                            $('#txtRow0Col4').html(jSonItem.ColHeader4, 1);
                            $('#txtRow0Col5').html(jSonItem.ColHeader5, 1);
                            $('#txtRow0Col6').html(jSonItem.ColHeader6, 1);
                            $('#txtRow1Col0').html(jSonItem.RowHeader1, 1);
                            $('#txtRow2Col0').html(jSonItem.RowHeader2, 1);
                            $('#txtRow3Col0').html(jSonItem.RowHeader3, 1);
                            $('#txtRow4Col0').html(jSonItem.RowHeader4, 1);
                            $('#txtRow5Col0').html(jSonItem.RowHeader5, 1);
                            $('#txtRow6Col0').html(jSonItem.RowHeader6, 1);
                            $('#txtRow7Col0').html(jSonItem.RowHeader7, 1);
                            $('#txtRow8Col0').html(jSonItem.RowHeader8, 1);
                            $('#txtRow9Col0').html(jSonItem.RowHeader9, 1);
                            $('#txtRow10Col0').html(jSonItem.RowHeader10, 1);
                            $('#cirDynamicTableLink').show();
                        }

                    }
                });
            }
        });
    });
}

function showhideSimCIRDynamicControls(parentID, sectionID, sectionVal, isMandatory) {
    if (sectionVal != '' && sectionVal != undefined) {
        if (isMandatory == 1) {
            $('#cirDynamicAccordSection' + parentID + '  #rowHeader' + sectionID).text(sectionVal).append('<span class="errorSpan">*</span>');
        }
        else {
            $('#cirDynamicAccordSection' + parentID + '  #rowHeader' + sectionID).text(sectionVal);
        }
        if ($('#cirDynamicAccordSection' + parentID + '  #controlHeader' + sectionID) != undefined) {
            $('#cirDynamicAccordSection' + parentID + '  #controlHeader' + sectionID).attr('data-original-title', 'Enter ' + sectionVal);
        }
        if ($('#cirDynamicAccordSection' + parentID + '  #txtrowHeader' + sectionID) != undefined) {
            $('#cirDynamicAccordSection' + parentID + '  #txtrowHeader' + sectionID).attr('data-original-title', 'Enter ' + sectionVal);
        }
        $('#cirDynamicAccordSection' + parentID + '  #rowHeader' + sectionID).show();
        $('#cirDynamicAccordSection' + parentID + '  #txtrowHeader' + sectionID).show();
        $('#cirDynamicAccordSection' + parentID + '  #controlHeader' + sectionID).show();
        if (sectionID == 4) {
            // $('#cirDynamicAccordSection' + parentID + '  #controlHeader' + sectionID).addClass('movFlang' + parentID);
            $('#cirDynamicAccordSection' + parentID + '  #controlHeader' + sectionID).attr('data-parentId', 'cirDynamicAccordSection' + parentID);
        }
    } else {
        $('#cirDynamicAccordSection' + parentID + '  #rowHeader' + sectionID).hide();
        $('#cirDynamicAccordSection' + parentID + '  #txtrowHeader' + sectionID).hide();
        $('#cirDynamicAccordSection' + parentID + '  #controlHeader' + sectionID).hide();
    }
}
function showhideDecisionSection() {
    var isUserAdmin = hasRole("Viewer") || hasRole("Visitor") || hasRole("Turbine Technicians") || hasRole("Contractor Turbine Technicians") || hasRole("Member") || hasRole("Editor") || hasRole("BirCreator") || hasRole("GirCreator") || hasRole("GBXIRCreator");
    if (isUserAdmin == true && (!hasRole("Administrator") && !hasRole("CIR Evaluator"))) {
        for (var i = 1; i <= 6; i++) {

            //$('#cirDynamicAccordSection' + i + ' #DecisionSection').hide();
            for (var i = 1; i <= 6; i++) {
                $('#cirDynamicAccordSection' + i + ' #DecisionSection').show();

                $('#cirDynamicAccordSection' + i + ' #controlDecision').attr("disabled", true);
                $('#cirDynamicAccordSection' + i + ' #controlRepeatedInspection').attr("disabled", true);
                $('#cirDynamicAccordSection' + i + ' #chkReplaceAffectedBolts').attr("disabled", true);

            }
        }

    }
    else {

        for (var i = 1; i <= 6; i++) {

            var userEditAccess = hasRole("CIR Evaluator") || hasRole("Administrator");
            if (userEditAccess) {
                $('#cirDynamicAccordSection' + i + ' #DecisionSection').show();

            }

            //if (userEditAccess == false) {
            //    $('#cirDynamicAccordSection' + i + ' #controlDecision').attr("disabled", true);
            //    $('#cirDynamicAccordSection' + i + ' #controlRepeatedInspection').attr("disabled", true);
            //    $('#cirDynamicAccordSection' + i + ' #chkReplaceAffectedBolts').attr("disabled", true);
            //}
        }
    }
}

function PopulateDynamicAccordian(cimCaseNumber) {
    console.log('Populating Dynamic Accordian for Cim: ' + cimCaseNumber);

    // $('#DynamicHeader').text('Table Header');

    $('#cirDynamicAccord1').hide();
    $('#cirDynamicAccord2').hide();
    $('#cirDynamicAccord3').hide();
    $('#cirDynamicAccord4').hide();
    $('#cirDynamicAccord5').hide();
    $('#cirDynamicAccord6').hide();

    dbtransaction.openDatabase(function () {
        dbtransaction.getDynamicInputFromCimCase(cimCaseNumber, function dynamicInputs(inputs) {
            if (inputs) {
                inputs.forEach(function (item) {
                    var jSonItem = jQuery.parseJSON(item.text.replace(/(\r\n|\n|\r)/gm, ""));
                    if (jSonItem) {
                        if (jSonItem.CIMcaseNo == cimCaseNumber) {

                            cirOfflineApp.LoadDynamicDropDowns(cimCaseNumber).done(function () {
                            });
                            if (jSonItem.ColHeader1 != '' && jSonItem.ColHeader1 != undefined) {
                                $('#cirDynamicAccordSection1 #DynamicHeader').text(jSonItem.TableHeader);

                                $('#cirDynamicAccordSection1 #linkDynamicControlNext').attr('data-parentDiv', 'cirDynamicAccordSection1');
                                $('#cirDynamicAccordSection1 #linkDynamicControlPrev').attr('data-parentDiv', 'cirDynamicAccordSection1');
                                $("#cirDynamicAccordSection1 #ImageSection2").remove();
                                $("#cirDynamicAccordSection1 #ImageSection3").remove();
                                $("#cirDynamicAccordSection1 #ImageSection4").remove();
                                $("#cirDynamicAccordSection1 #ImageSection5").remove();
                                $("#cirDynamicAccordSection1 #ImageSection6").remove();
                                $('#cirDynamicAccord1 > a').text(jSonItem.ColHeader1).append('<i class="fa fa-puzzle-piece" style="float: right; padding-right: 5px"></i>');
                                $('#cirDynamicAccord1').show();
                                $('#cirDynamicAccordSection1 #chkDamageIdentifiedSimplified').attr('data-id', 'cirDynamicAccordSection1');
                                showhideSimCIRDynamicControls(1, 1, jSonItem.RowHeader1, 1);
                                showhideSimCIRDynamicControls(1, 2, jSonItem.RowHeader2, 1);
                                showhideSimCIRDynamicControls(1, 3, jSonItem.RowHeader3, 1);
                                showhideSimCIRDynamicControls(1, 4, jSonItem.RowHeader4, 1);
                                showhideSimCIRDynamicControls(1, 5, jSonItem.RowHeader5, 1);
                                showhideSimCIRDynamicControls(1, 6, jSonItem.RowHeader6, 1);
                                showhideSimCIRDynamicControls(1, 7, jSonItem.RowHeader7, 1);
                                showhideSimCIRDynamicControls(1, 8, jSonItem.RowHeader8);
                                showhideSimCIRDynamicControls(1, 9, jSonItem.RowHeader9);
                                showhideSimCIRDynamicControls(1, 10, jSonItem.RowHeader10);
                                showhideSimCIRDynamicControls(1, 11, jSonItem.RowHeader11);
                                showhideSimCIRDynamicControls(1, 12, jSonItem.RowHeader12);
                                showhideSimCIRDynamicControls(1, 13, jSonItem.RowHeader13, 1);
                                showhideSimCIRDynamicControls(1, 14, jSonItem.RowHeader14, 1);

                            }
                            if (jSonItem.ColHeader2 != '' && jSonItem.ColHeader2 != undefined) {
                                $('#cirDynamicAccordSection2 #DynamicHeader').text(jSonItem.TableHeader);
                                $('#cirDynamicAccordSection2 #linkDynamicControlNext').attr('data-parentDiv', 'cirDynamicAccordSection2');
                                $('#cirDynamicAccordSection2 #linkDynamicControlPrev').attr('data-parentDiv', 'cirDynamicAccordSection2');
                                $("#cirDynamicAccordSection2 #ImageSection1").remove();
                                $("#cirDynamicAccordSection2 #ImageSection3").remove();
                                $("#cirDynamicAccordSection2 #ImageSection4").remove();
                                $("#cirDynamicAccordSection2 #ImageSection5").remove();
                                $("#cirDynamicAccordSection2 #ImageSection6").remove();
                                $('#cirDynamicAccord2 > a').text(jSonItem.ColHeader2).append('<i class="fa fa-puzzle-piece" style="float: right; padding-right: 5px"></i>');
                                $('#cirDynamicAccord2').show();
                                $('#cirDynamicAccordSection2 #chkDamageIdentifiedSimplified').attr('data-id', 'cirDynamicAccordSection2');
                                showhideSimCIRDynamicControls(2, 1, jSonItem.RowHeader1, 1);
                                showhideSimCIRDynamicControls(2, 2, jSonItem.RowHeader2, 1);
                                showhideSimCIRDynamicControls(2, 3, jSonItem.RowHeader3, 1);
                                showhideSimCIRDynamicControls(2, 4, jSonItem.RowHeader4, 1);
                                showhideSimCIRDynamicControls(2, 5, jSonItem.RowHeader5, 1);
                                showhideSimCIRDynamicControls(2, 6, jSonItem.RowHeader6, 1);
                                showhideSimCIRDynamicControls(2, 7, jSonItem.RowHeader7, 1);
                                showhideSimCIRDynamicControls(2, 8, jSonItem.RowHeader8);
                                showhideSimCIRDynamicControls(2, 9, jSonItem.RowHeader9);
                                showhideSimCIRDynamicControls(2, 10, jSonItem.RowHeader10);
                                showhideSimCIRDynamicControls(2, 11, jSonItem.RowHeader11);
                                showhideSimCIRDynamicControls(2, 12, jSonItem.RowHeader12);
                                showhideSimCIRDynamicControls(2, 13, jSonItem.RowHeader13, 1);
                                showhideSimCIRDynamicControls(2, 14, jSonItem.RowHeader14, 1);
                            }
                            if (jSonItem.ColHeader3 != '' && jSonItem.ColHeader3 != undefined) {
                                $('#cirDynamicAccordSection3 #DynamicHeader').text(jSonItem.TableHeader);
                                $('#cirDynamicAccordSection3 #linkDynamicControlNext').attr('data-parentDiv', 'cirDynamicAccordSection3');
                                $('#cirDynamicAccordSection3 #linkDynamicControlPrev').attr('data-parentDiv', 'cirDynamicAccordSection3');
                                $("#cirDynamicAccordSection3 #ImageSection2").remove();
                                $("#cirDynamicAccordSection3 #ImageSection1").remove();
                                $("#cirDynamicAccordSection3 #ImageSection4").remove();
                                $("#cirDynamicAccordSection3 #ImageSection5").remove();
                                $("#cirDynamicAccordSection3 #ImageSection6").remove();
                                $('#cirDynamicAccord3 > a').text(jSonItem.ColHeader3).append('<i class="fa fa-puzzle-piece" style="float: right; padding-right: 5px"></i>');
                                $('#cirDynamicAccord3').show();
                                $('#cirDynamicAccordSection3 #chkDamageIdentifiedSimplified').attr('data-id', 'cirDynamicAccordSection3');
                                showhideSimCIRDynamicControls(3, 1, jSonItem.RowHeader1, 1);
                                showhideSimCIRDynamicControls(3, 2, jSonItem.RowHeader2, 1);
                                showhideSimCIRDynamicControls(3, 3, jSonItem.RowHeader3, 1);
                                showhideSimCIRDynamicControls(3, 4, jSonItem.RowHeader4, 1);
                                showhideSimCIRDynamicControls(3, 5, jSonItem.RowHeader5, 1);
                                showhideSimCIRDynamicControls(3, 6, jSonItem.RowHeader6, 1);
                                showhideSimCIRDynamicControls(3, 7, jSonItem.RowHeader7, 1);
                                showhideSimCIRDynamicControls(3, 8, jSonItem.RowHeader8);
                                showhideSimCIRDynamicControls(3, 9, jSonItem.RowHeader9);
                                showhideSimCIRDynamicControls(3, 10, jSonItem.RowHeader10);
                                showhideSimCIRDynamicControls(3, 11, jSonItem.RowHeader11);
                                showhideSimCIRDynamicControls(3, 12, jSonItem.RowHeader12);
                                showhideSimCIRDynamicControls(3, 13, jSonItem.RowHeader13, 1);
                                showhideSimCIRDynamicControls(3, 14, jSonItem.RowHeader14, 1);
                            }
                            if (jSonItem.ColHeader4 != '' && jSonItem.ColHeader4 != undefined) {
                                $('#cirDynamicAccordSection4 #DynamicHeader').text(jSonItem.TableHeader);
                                $('#cirDynamicAccordSection4 #linkDynamicControlNext').attr('data-parentDiv', 'cirDynamicAccordSection4');
                                $('#cirDynamicAccordSection4 #linkDynamicControlPrev').attr('data-parentDiv', 'cirDynamicAccordSection4');
                                $("#cirDynamicAccordSection4 #ImageSection2").remove();
                                $("#cirDynamicAccordSection4 #ImageSection3").remove();
                                $("#cirDynamicAccordSection4 #ImageSection1").remove();
                                $("#cirDynamicAccordSection4 #ImageSection5").remove();
                                $("#cirDynamicAccordSection4 #ImageSection6").remove();
                                $('#cirDynamicAccord4 > a').text(jSonItem.ColHeader4).append('<i class="fa fa-puzzle-piece" style="float: right; padding-right: 5px"></i>');
                                $('#cirDynamicAccord4').show();
                                $('#cirDynamicAccordSection4 #chkDamageIdentifiedSimplified').attr('data-id', 'cirDynamicAccordSection4');
                                showhideSimCIRDynamicControls(4, 1, jSonItem.RowHeader1, 1);
                                showhideSimCIRDynamicControls(4, 2, jSonItem.RowHeader2, 1);
                                showhideSimCIRDynamicControls(4, 3, jSonItem.RowHeader3, 1);
                                showhideSimCIRDynamicControls(4, 4, jSonItem.RowHeader4, 1);
                                showhideSimCIRDynamicControls(4, 5, jSonItem.RowHeader5, 1);
                                showhideSimCIRDynamicControls(4, 6, jSonItem.RowHeader6, 1);
                                showhideSimCIRDynamicControls(4, 7, jSonItem.RowHeader7, 1);
                                showhideSimCIRDynamicControls(4, 8, jSonItem.RowHeader8);
                                showhideSimCIRDynamicControls(4, 9, jSonItem.RowHeader9);
                                showhideSimCIRDynamicControls(4, 10, jSonItem.RowHeader10);
                                showhideSimCIRDynamicControls(4, 11, jSonItem.RowHeader11);
                                showhideSimCIRDynamicControls(4, 12, jSonItem.RowHeader12);
                                showhideSimCIRDynamicControls(4, 13, jSonItem.RowHeader13, 1);
                                showhideSimCIRDynamicControls(4, 14, jSonItem.RowHeader14, 1);
                            }
                            if (jSonItem.ColHeader5 != '' && jSonItem.ColHeader5 != undefined) {
                                $('#cirDynamicAccordSection5 #DynamicHeader').text(jSonItem.TableHeader);
                                $('#cirDynamicAccordSection5 #linkDynamicControlNext').attr('data-parentDiv', 'cirDynamicAccordSection5');
                                $('#cirDynamicAccordSection5 #linkDynamicControlPrev').attr('data-parentDiv', 'cirDynamicAccordSection5');
                                $("#cirDynamicAccordSection5 #ImageSection2").remove();
                                $("#cirDynamicAccordSection5 #ImageSection3").remove();
                                $("#cirDynamicAccordSection5 #ImageSection4").remove();
                                $("#cirDynamicAccordSection5 #ImageSection1").remove();
                                $("#cirDynamicAccordSection5 #ImageSection6").remove();
                                $('#cirDynamicAccord5 > a').text(jSonItem.ColHeader5).append('<i class="fa fa-puzzle-piece" style="float: right; padding-right: 5px"></i>');
                                $('#cirDynamicAccord5').show();
                                $('#cirDynamicAccordSection5 #chkDamageIdentifiedSimplified').attr('data-id', 'cirDynamicAccordSection5');
                                showhideSimCIRDynamicControls(5, 1, jSonItem.RowHeader1, 1);
                                showhideSimCIRDynamicControls(5, 2, jSonItem.RowHeader2, 1);
                                showhideSimCIRDynamicControls(5, 3, jSonItem.RowHeader3, 1);
                                showhideSimCIRDynamicControls(5, 4, jSonItem.RowHeader4, 1);
                                showhideSimCIRDynamicControls(5, 5, jSonItem.RowHeader5, 1);
                                showhideSimCIRDynamicControls(5, 6, jSonItem.RowHeader6, 1);
                                showhideSimCIRDynamicControls(5, 7, jSonItem.RowHeader7, 1);
                                showhideSimCIRDynamicControls(5, 8, jSonItem.RowHeader8);
                                showhideSimCIRDynamicControls(5, 9, jSonItem.RowHeader9);
                                showhideSimCIRDynamicControls(5, 10, jSonItem.RowHeader10);
                                showhideSimCIRDynamicControls(5, 11, jSonItem.RowHeader11);
                                showhideSimCIRDynamicControls(5, 12, jSonItem.RowHeader12);
                                showhideSimCIRDynamicControls(5, 13, jSonItem.RowHeader13, 1);
                                showhideSimCIRDynamicControls(5, 14, jSonItem.RowHeader14, 1);
                            }
                            if (jSonItem.ColHeader6 != '' && jSonItem.ColHeader6 != undefined) {
                                $('#cirDynamicAccordSection6 #DynamicHeader').text(jSonItem.TableHeader);
                                $('#cirDynamicAccordSection6 #linkDynamicControlNext').attr('data-parentDiv', 'cirDynamicAccordSection6');
                                $('#cirDynamicAccordSection6 #linkDynamicControlPrev').attr('data-parentDiv', 'cirDynamicAccordSection6');
                                $("#cirDynamicAccordSection6 #ImageSection2").remove();
                                $("#cirDynamicAccordSection6 #ImageSection3").remove();
                                $("#cirDynamicAccordSection6 #ImageSection4").remove();
                                $("#cirDynamicAccordSection6 #ImageSection5").remove();
                                $("#cirDynamicAccordSection6 #ImageSection1").remove();
                                $('#cirDynamicAccord6 > a').text(jSonItem.ColHeader6).append('<i class="fa fa-puzzle-piece" style="float: right; padding-right: 5px"></i>');
                                $('#cirDynamicAccord6').show();
                                $('#cirDynamicAccordSection6 #chkDamageIdentifiedSimplified').attr('data-id', 'cirDynamicAccordSection6');
                                showhideSimCIRDynamicControls(6, 1, jSonItem.RowHeader1, 1);
                                showhideSimCIRDynamicControls(6, 2, jSonItem.RowHeader2, 1);
                                showhideSimCIRDynamicControls(6, 3, jSonItem.RowHeader3, 1);
                                showhideSimCIRDynamicControls(6, 4, jSonItem.RowHeader4, 1);
                                showhideSimCIRDynamicControls(6, 5, jSonItem.RowHeader5, 1);
                                showhideSimCIRDynamicControls(6, 6, jSonItem.RowHeader6, 1);
                                showhideSimCIRDynamicControls(6, 7, jSonItem.RowHeader7, 1);
                                showhideSimCIRDynamicControls(6, 8, jSonItem.RowHeader8);
                                showhideSimCIRDynamicControls(6, 9, jSonItem.RowHeader9);
                                showhideSimCIRDynamicControls(6, 10, jSonItem.RowHeader10);
                                showhideSimCIRDynamicControls(6, 11, jSonItem.RowHeader11);
                                showhideSimCIRDynamicControls(6, 12, jSonItem.RowHeader12);
                                showhideSimCIRDynamicControls(6, 13, jSonItem.RowHeader13, 1);
                                showhideSimCIRDynamicControls(6, 14, jSonItem.RowHeader14, 1);
                            }
                            showhideDecisionSection();
                        }

                    }
                });
            }
        });
    });
}
function CheckSimplifiedValidationOnSubmit() {
    var isValid = true;
    var chkCirType = true;

    // if ($('#ddlCirType :selected').val() == '8') {
    if (!SaveSimplifiedCIRSection(true) || !ValidateSimplifiedCIROnSubmit(false) || !SaveSBURecommendation(false)) {
        isValid = false;
    }
    //}
    return isValid;
}
//Task No. : 72530, Added by Siddharth Chauhan on 25-05-2016.
//To check the validation and Save data draft.
//To navigate one tab to another without blocking a user.
function CheckValidationOnSubmit() {
    var isValid = true;
    var chkCirType = true;

    if ($('#ddlCirType :selected').val() == '8') {
        if (!ValidateSimplifiedCIROnSubmit(false)) {
            isValid = false;
        }
    }
    //To save and validate the Common section.
    if (!SaveCommonSection(false)) {
        isValid = false;
        $('#cirCommonLink').removeClass("ui-state-default");
        $('#cirCommonLink').addClass("ui-state-error");

        $('#cloneid-Comm').removeClass("ui-state-default");
        $('#cloneid-Comm').addClass("ui-state-error");
    }
    else {
        $('#cirCommonLink').removeClass("ui-state-error");
        $('#cirCommonLink').addClass("ui-state-success");

        $('#cloneid-Comm').removeClass("ui-state-error");
        $('#cloneid-Comm').addClass("ui-state-success");
    }
    if ($("#tType").val() == "rdCirType") {
        switch ($('#ddlCirType :selected').val()) {
            case '1':
                chkCirType = SaveBladeSection(false);
                break;
            case '2':
                chkCirType = SaveGearboxSection(false);
                break;
            case '3':
                chkCirType = SaveGeneralSection(false);
                break;
            case '4':
                chkCirType = SaveGeneratorSection(false);
                break;
            case '5':
                chkCirType = SaveTransformerSection(false);
                break;
            case '6':
                chkCirType = SaveMainBearingSection(false);
                break;
            case '7':
                chkCirType = SaveSkiipackSection(false);
                break;
        }
    }
    else if ($("#tType").val() == "rdHotlist") {
        var hotlistCirType = $('#ddlHotlist :selected').text();
        hotlistCirType = hotlistCirType.split(":")[0];
        hotlistCirType = hotlistCirType.substring(hotlistCirType.lastIndexOf("[") + 1, hotlistCirType.lastIndexOf("]"));
        switch (hotlistCirType) {
            case 'Blade':
                chkCirType = SaveBladeSection(false);
                break;
            case 'Gearbox':
                chkCirType = SaveGearboxSection(false);
                break;
            case 'General':
                chkCirType = SaveGeneralSection(false);
                break;
            case 'Generator':
                chkCirType = SaveGeneratorSection(false);
                break;
            case 'Transformer':
                chkCirType = SaveTransformerSection(false);
                break;
            case 'Main Bearing':
                chkCirType = SaveMainBearingSection(false);
                break;
            case 'Skiipack':
                chkCirType = SaveSkiipackSection(false);
                break;

        }
    }
    //To save and validate the Cir Type section.
    if (!chkCirType) {
        isValid = false;
        $('#cirBladeLink').removeClass("ui-state-default");
        $('#cirBladeLink').addClass("ui-state-error");
    }
    else {
        $('#cirBladeLink').removeClass("ui-state-error");
        $('#cirBladeLink').addClass("ui-state-success");
    }

    //To save and validate the CIR Images section.
    if (!SaveCIRImages(false)) {
        isValid = false;
        $('#cirImagesLink').removeClass("ui-state-success");
        $('#cirImagesLink').addClass("ui-state-error");
    }
    else {
        $('#cirImagesLink').removeClass("ui-state-error");
        $('#cirImagesLink').addClass("ui-state-success");
    }

    return isValid;
}



