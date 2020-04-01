var materialUiInit = {
    initStyles: function () {
        var materialInterval = setInterval(function () {
            if ($('.form-field-type-textfield').length > 0 || $('.form-field-type-number').length > 0 || $('.form-field-type-textarea').length > 0 || $('.hiddenmastercontrols').length > 0 ) {
                //add floating label for text field
                $('.form-field-type-textfield input').on('focus blur',
                    function (e) {
                        $(this).toggleClass('focused', (e.type === 'focus' || this.value.length > 0));
                        $("label[for='" + $(this).attr('id') + "']").toggleClass('float-label-focused',
                            (e.type === 'focus' || this.value.length > 0));
                    }).trigger('blur');

                //add floating label for number field

                $('.form-field-type-number input').on('focus blur',
                    function (e) {
                       
                        $(this).toggleClass('focused', (e.type === 'focus' || this.value.length > 0));
                        $("label[for='" + $(this).attr('id') + "']").toggleClass('float-label-focused',
                            (e.type === 'focus' || this.value.length > 0));
                    }).trigger('blur');
                //add floating label for textarea field
                $('.form-field-type-textarea textarea').on('focus blur',
                function (e) {
                    
                    $(this).toggleClass('focused', (e.type === 'focus' || this.value.length > 0));
                    $("label[for='" + $(this).attr('id') + "']").toggleClass('float-label-focused',
                        (e.type === 'focus' || this.value.length > 0));
                }).trigger('blur');

                $('.hiddenmastercontrols').off('click').on('click',
                   function (e) {
                       materialUiInit.initStyles();
                   });

              

                //$('.form-field-type-radio').off('click').on('click',
                //function (e) {
                //    if ($(this).attr('id').indexOf("rbReportType") >= 0 && $('#rbReportType-3')["0"].checked == true) {
                //        setReportType(true);
                //    }
                //    else if ($(this).attr('id').indexOf("rbReportType") >= 0) {
                //        setReportType(false);
                //    }
                //});
               
                //var formScope = angular.element('#formio-wizard-form').scope().$parent;
                //if (formScope != undefined && formScope.$root.cir === undefined) {
                //    if (!!$('#ctbDamageIdentified')["0"] && getReportType()) {
                //        if (getDamagedIdentified() != undefined && getDamagedIdentified() == false) {
                //            debugger;
                //            $('#ctbDamageIdentified')["0"].checked = getReportType();
                //            formScope.submission.data["ctbDamageIdentified"] = getReportType();
                //            if (getReportType()) {
                //                $('#form-group-csOverallBladeCondition').show();
                //                $('#form-group-ddlType').show();
                //                $('#form-group-ddlCause').show();
                //                $('#form-group-ddlArea').show();
                //            }
                //            else {
                //                $('#form-group-csOverallBladeCondition').hide();
                //                $('#form-group-ddlType').hide();
                //                $('#form-group-ddlCause').hide();
                //                $('#form-group-ddlArea').hide();
                //            }
                //        }
                //    }
                //    else {
                //        if (getDamagedIdentified() != undefined && getDamagedIdentified() == false && $('#ctbDamageIdentified')["0"] != undefined) {
                //            debugger;
                //            $('#ctbDamageIdentified')["0"].checked = getReportType();
                //            formScope.submission.data["ctbDamageIdentified"] = getReportType();
                //            if (getReportType()) {
                //                $('#form-group-csOverallBladeCondition').show();
                //                $('#form-group-ddlType').show();
                //                $('#form-group-ddlCause').show();
                //                $('#form-group-ddlArea').show();
                //            }
                //            else {
                //                $('#form-group-csOverallBladeCondition').hide();
                //                $('#form-group-ddlType').hide();
                //                $('#form-group-ddlCause').hide();
                //                $('#form-group-ddlArea').hide();
                //            }
                //        }
                //    }
                //}
                

                //$("#ctbDamageIdentified").on('change',
                //    function (e) {
                //        setDamagedIdentified();
                //    });

                //add radio custom radio buttons
                if ($('.form-field-type-radio div.radio-inline label div').length === 0) {
                    $('.form-field-type-radio div.radio-inline label').append('<div class="radioImage" />');
                }

                //add clear left div after select components so it does not break styling
                $('.form-field-type-datetime label.control-label + div').after('<div class="clearfix"></div>');
                $('.form-field-type-dynamicDropdown label.control-label + div').after('<div class="clearfix"></div>');

                clearInterval(materialInterval);
            }
        },
            100);
    }
};