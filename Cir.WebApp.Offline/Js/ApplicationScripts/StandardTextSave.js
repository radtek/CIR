var StandardText = new function () {
    
    this.loadCirTypes = function () {
        dbtransaction.getItemfromTable('ComponentInspectionReportType', renderReportTypes);

        var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ''); // Azure auth
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser) {
                if (currentuser.length > 0) {
                    currentuser.forEach(function (item) {
                        client.currentUser = item.objet;
                    });
                    if (client.currentUser) {
                        var cirSearchjSon;
                        var cirSearchString = '';

                        console.log(cirSearchString);

                        cirSearchjSon = jQuery.parseJSON(cirSearchString);
                        console.log(cirSearchjSon);

                        client.invokeApi('ComponentInspectionReportType', {
                            method: 'Get',
                            body: cirSearchjSon
                        }).done(function (response) {
                            var resp = response.result;

                            if (resp)
                                if (resp.length > 0)                                    
                                resp.forEach(function (item) {
                                $('#ddlCirType').append($('<option>', {
                                    value: item.ComponentInspectionReportTypeID,
                                    text: item.text
                                }));
                            });

                        }, function (error) {
                            
                            console.log(error);
                        });
                    }
                }
            }
        });


        //Rendring items in list
        function renderReportTypes(reportTypes) {
            reportTypes.forEach(function (item) {
                $('#ddlCirType').append($('<option>', {
                    value: item.ComponentInspectionReportTypeID,
                    text: item.text
                }));
            });
        }
    }
    
    
};

function GetStandardTextByID(ids) {

    var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ''); // Azure auth
    dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
        if (currentuser) {
            var cirSearchString = '';
            var cirSearchjSon;
            if (currentuser.length > 0) {
                currentuser.forEach(function (item) {
                    client.currentUser = item.objet;
                });
                if (client.currentUser) {
                    cirSearchString += '{'
                    cirSearchString += '"Id":' + ids + ',';
                    cirSearchString += '"CallFunction": "GetByID"';
                    cirSearchString += '}'
                    cirSearchjSon = jQuery.parseJSON(cirSearchString);
                    client.invokeApi('StandardTextData', {
                        method: 'Post',
                        body: cirSearchjSon
                    }).done(function (response) {
                        var resps = response.result;
                        //console.log(resps.length);

                        $('#txtTitle').val(resps.title);
                        $('#txtDescription').val(resps.description);                        
                        $('#ddlCirType').val(resps.componentInspectionReportTypeId);
                        
                    });
                }
            }
        }
    });
};

function SaveStandardText() {

    var StandardTextID = getUrlParameter("ID");
    var isValid = true;
    if ($('#txtDescription').val() != '') {
        $('#txtDescription').removeClass('validationerror red-tooltip');
    }
    else {
        $('#txtDescription').removeClass('validationerror red-tooltip');
        $('#txtDescription').addClass('validationerror red-tooltip');
        ScrollTo('txtDescription');
        $('#txtDescription').focus();
        isValid = false;
    }
    if ($('#txtTitle').val() != '') {
        $('#txtTitle').removeClass('validationerror red-tooltip');
    }
    else {
        $('#txtTitle').removeClass('validationerror red-tooltip');
        $('#txtTitle').addClass('validationerror red-tooltip');
       
        ScrollTo('txtTitle');
        $('#txtTitle').focus();
        isValid = false;
    }

    

    if (!isValid)
        return false;

    var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ''); // Azure auth
    dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
        if (currentuser) {
            var cirSearchString = '';
            var cirItemjSon;
            if (currentuser.length > 0) {
                currentuser.forEach(function (item) {
                    client.currentUser = item.objet;
                });
                if (client.currentUser) {
                    cirSearchString += '{'
                    if (StandardTextID && StandardTextID != '0') {
                        
                        cirSearchString += '"id":' + StandardTextID + ',';
                        cirSearchString += '"title":"' + $('#txtTitle').val() + '",';
                        cirSearchString += '"description":"' + $('#txtDescription').val() + '",';
                        cirSearchString += '"componentInspectionReportTypeId":' + $('#ddlCirType :selected').val() + ',';
                        cirSearchString += '"modified":"1900/01/01",';
                        cirSearchString += '"modifiedBy":"' + $('#hdnUserInitial').val() + '",';                        
                        cirSearchString += '"deleted": 0';

                    }
                    else {
                        cirSearchString += '"id":0,';
                        cirSearchString += '"title":"' + $('#txtTitle').val() + '",';
                        cirSearchString += '"description":"' + $('#txtDescription').val() + '",';
                        cirSearchString += '"createdBy":"' + $('#hdnUserInitial').val() + '",';
                        cirSearchString += '"created":"1900/01/01",';
                        cirSearchString += '"componentInspectionReportTypeId":' + $('#ddlCirType :selected').val() + ',';
                        cirSearchString += '"deleted": 0';
                    }

                    
                    cirSearchString += '}'
                    cirItemjSon = jQuery.parseJSON(cirSearchString);
                    
                    
                    console.log(cirItemjSon);
                    client.invokeApi('StandardTextData', {
                        method: 'Post',
                        body: cirItemjSon
                    }).done(function (response) {
                        
                        //

                        location.replace("/cir/Manage-StandardText?Status=Success");
                    });
                }
            }
        }
    });
};
function ScrollTo(item) {
    $('html,body').animate({
        scrollTop: $("#" + item).offset().top - 45
    }, 'slow');
}
function showAndDismissAlert(type, message) {
    var htmlAlert = '<div class="alert alert-' + type + '">' + message + '</div>';

    // Prepend so that alert is on top, could also append if we want new alerts to show below instead of on top.
    $(".alert-messages").prepend(htmlAlert);

    // Since we are prepending, take the first alert and tell it to fade in and then fade out.
    // Note: if we were appending, then should use last() instead of first()
    $(".alert-messages .alert").first().hide().fadeIn(200).delay(2000).fadeOut(1000, function () { $(this).remove(); });
}


$(document).ready(function () {

    
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

        StandardText.loadCirTypes();
        var StandardTextID = getUrlParameter("ID");
        if (StandardTextID && StandardTextID != '0') {
            GetStandardTextByID(StandardTextID)
        }
    });
    //$(document).tooltip(); //jQuery tool tips
    $("#txtDescription").change(function () {
        if ($('#txtDescription').val() != '') {
            $('#txtDescription').removeClass('validationerror red-tooltip');
        }
        else {
            $('#txtDescription').removeClass('validationerror red-tooltip');
            $('#txtDescription').addClass('validationerror red-tooltip');
            
            $('#txtDescription').Focus();
        }
    });

    $("[data-toggle=popover]").popover();
    $("#txtTitle").change(function () {
        if ($('#txtTitle').val() != '') {
            $('#txtTitle').removeClass('validationerror red-tooltip');            
        }
        else {
            $('#txtTitle').removeClass('validationerror red-tooltip');
            $('#txtTitle').addClass('validationerror red-tooltip');
            
            $('#txtTitle').Focus();
        }
    });
    
});

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? '' : sParameterName[1];
        }
    }
    
};