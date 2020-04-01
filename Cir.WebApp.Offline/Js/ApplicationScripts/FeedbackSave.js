var Feedback = new function () {

    this.loadCirFeedbackTypes = function () {

        var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ''); // Azure auth
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser) {
                if (currentuser.length > 0) {
                    currentuser.forEach(function (item) {
                        client.currentUser = item.objet;
                    });
                    if (client.currentUser) {

                        var cirSearchString = '';

                        console.log(cirSearchString);

                        //cirSearchjSon = jQuery.parseJSON(cirSearchString);
                        //console.log(cirSearchjSon);
                        $('#ddlFeedbackType').empty(); //changed for defect 83725
                        client.invokeApi('FeedbackType', {
                            method: 'Get',
                            body: ''
                        }).done(function (response) {
                            var resp = response.result;

                            if (resp)
                                if (resp.length > 0)
                                    resp.forEach(function (item) {
                                        $('#ddlFeedbackType').append($('<option>', {
                                            value: item.id,
                                            text: item.name

                                        }));
                                    });

                           
                            var text1 = resp[2].name;
                            //$('#ddlFeedbackType :selected').value == "System Support"
                            //$("#ddlFeedbackType option[text=" + text1 + "]").attr("selected", "selected");
                            //$("#ddlFeedbackType").val(text1).change();
                            //$('#ddlFeedbackType').val(text1).attr("selected", "selected");
                            //$("#ddlFeedbackType")[0].selectedIndex = 2; //changed for defect 83420
                            //$("#ddlFeedbackType").val("System Support");
                            $("#ddlFeedbackType option:contains(" + text1 + ")").attr('selected', 'selected'); //changed for defect 83420
                            OnLoad();

                        }, function (error) {

                            console.log(error);
                        });




                    }
                }
            }
        });


        //Rendring items in list
        function renderFeedbackTypes(feedbackTypes) {
            feedbackTypes.forEach(function (item) {
                $('#ddlFeedbackType').append($('<option>', {
                    value: item.FeedbackTypeId,
                    text: item.text
                }));
            });
        }



    }


};


function SaveFeedback() {
  
    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
    $("#btnsave").attr('disabled', true);
    var FeedbackID = getUrlParameter("ID");
    var isValid = true;
    if ($('#txtFeedbackDescription').val() != '') {
        $('#txtFeedbackDescription').removeClass('validationerror red-tooltip');
    }
    else {
        $('#txtFeedbackDescription').removeClass('validationerror red-tooltip');
        $('#txtFeedbackDescription').addClass('validationerror red-tooltip');
        ScrollTo('txtFeedbackDescription');
        $('#txtFeedbackDescription').focus();
        isValid = false;
    }
    //if ($('#txtTitle').val() != '') {
    //    $('#txtTitle').removeClass('validationerror red-tooltip');
    //}
    //else {
    //    $('#txtTitle').removeClass('validationerror red-tooltip');
    //    $('#txtTitle').addClass('validationerror red-tooltip');

    //    ScrollTo('txtTitle');
    //    $('#txtTitle').focus();
    //   isValid = false;
    // }



    if (!isValid) {
        $("#btnsave").attr('disabled', false);
        waitingDialog.hide();
        return false;
    }

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
                    var enviromentDetails = "Browser engine is -" + navigator.userAgent;
                    if (FeedbackID && FeedbackID != '0') {

                        cirSearchString += '"id":' + FeedbackID + ',';
                        // cirSearchString += '"title":"' + $('#txtTitle').val() + '",';
                        cirSearchString += '"Message":"' + $('#txtFeedbackDescription').val().replace(/(?:\r\n|\r|\n)/g, '<br />') + '",';
                        cirSearchString += '"FeedbackTypeId":' + $('#ddlFeedbackType :selected').val() + ',';
                        cirSearchString += '"modified":"1900/01/01",';
                        cirSearchString += '"modifiedBy":"' + $('#hdnUserInitial').val() + '",';
                        cirSearchString += '"enviroment": "' + enviromentDetails + '",';
                        cirSearchString += '"deleted": 0';

                    }
                    else {
                        cirSearchString += '"id":0,';
                        cirSearchString += '"Message":"' + $('#txtFeedbackDescription').val().replace(/(?:\r\n|\r|\n)/g, '<br />') + '",';
                        cirSearchString += '"createdBy":"' + $('#hdnUserInitial').val() + '",';
                        cirSearchString += '"created":"1900/01/01",';
                        cirSearchString += '"FeedbackTypeId":' + $('#ddlFeedbackType :selected').val() + ',';
                        cirSearchString += '"enviroment":"' + enviromentDetails + '",';
                        cirSearchString += '"deleted": 0';
                    }


                    cirSearchString += '}'
                    cirItemjSon = jQuery.parseJSON(cirSearchString);


                    console.log(cirItemjSon);
                    client.invokeApi('Feedback', {
                        method: 'Post',
                        body: cirItemjSon
                    }).done(function (response) {

                        //
                        $('#txtFeedbackDescription').val('');
                        $('#ddlFeedbackType option:first-child').attr("selected", "selected");
                        NotifyCirMessage("Thank you for your feedback!", "Please be aware that this is not a helpdesk replacement and therefore you can't expect any response to your feedback timely. The feedback given is to improve the CIR system and will be evaluated by The Vestas CIR team.", "success", 0);
                        $("#btnsave").attr('disabled', false);
                        waitingDialog.hide();
                    });
                }
            }
        }
    });

};





function SendEmail() {
      
   
    location.href = "mailto:?subject=Please create an IT Ticket ";

}




function OnLoad() {
   
    var feedbacktype = $('#ddlFeedbackType option:selected').text();

    if (feedbacktype == "System Support") {
        document.getElementById("txtFeedbackDescription").style.display = "none";
        document.getElementById("btnsave").style.display = "none";
        document.getElementById("cirissue").style.display = "inline";
       
        document.getElementById("lblmsg").style.display = "none";

    }
    else {

        document.getElementById("txtFeedbackDescription").style.display = "block";
        document.getElementById("btnsave").style.display = "block";
       
        document.getElementById("lblmsg").style.display = "block";
        document.getElementById("cirissue").style.display = "none";
    }

}


function OnChangeFeedBackType() {
  
    var feedbacktype = $('#ddlFeedbackType option:selected').text();

    if (feedbacktype == "System Support") {
        document.getElementById("txtFeedbackDescription").style.display = "none";
        document.getElementById("btnsave").style.display = "none";        
        document.getElementById("cirissue").style.display = "inline";
       
        document.getElementById("lblmsg").style.display = "none";
        
    }
    else {

        document.getElementById("txtFeedbackDescription").style.display = "block";
        document.getElementById("btnsave").style.display = "block";
        
        document.getElementById("lblmsg").style.display = "block";
        document.getElementById("cirissue").style.display = "none";
    }

}





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

        Feedback.loadCirFeedbackTypes();

    });
    //$(document).tooltip(); //jQuery tool tips
    //$("#txtFeedbackDescription").change(function () {
    //    if ($('#txtFeedbackDescription').val() != '') {
    //        $('#txtFeedbackDescription').removeClass('validationerror red-tooltip');
    //    }
    //    else {
    //        $('#txtFeedbackDescription').removeClass('validationerror red-tooltip');
    //        $('#txtFeedbackDescription').addClass('validationerror red-tooltip');

    //        $('#txtFeedbackDescription').Focus();
    //    }
    //});

    waitingDialog.hide();
    //$("#btnsave").attr('disabled', false);
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