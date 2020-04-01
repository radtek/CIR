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
                            //console.log(resp.length)
                            //console.log(resp);

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
    this.loadStandardText = function () {

        //$('table#localStandTextTable tr.item').remove();
        //$('#localStandTextTable').append('<tr class="item"><td colspan="13" style="text-align:center;"><i class="fa fa-refresh fa-spin fa-lg"></i></td></td>');
        

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
                        
                        cirSearchString += '{'
                        var CommonInspectionReportID = $('#ddlCirType :selected').val();
                       
                        if (CommonInspectionReportID && CommonInspectionReportID != '0')
                            cirSearchString += '"ComponentInspectionReportTypeId":' + CommonInspectionReportID ;

                        else
                            cirSearchString += '"ComponentInspectionReportTypeId":1';

                        cirSearchString += '}'

                        console.log(cirSearchString);

                        cirSearchjSon = jQuery.parseJSON(cirSearchString);
                        console.log(cirSearchjSon);
                        
                        client.invokeApi('StandardText', {
                            method: 'Post',
                            body: cirSearchjSon
                        }).done(function (response) {
                            var resp = response.result;
                            var cirHtml = '<tbody style="background:transparent">';
                            if (resp)
                                if (resp.length > 0) {
                                    resp.forEach(function (Item) {
                                        cirHtml += '<tr class="item" id="' + Item.id + '">'

                                        cirHtml += '<td class="phone">' + Item.title + '</td>'
                                        cirHtml += '<td data-hide="expand">' + Item.description + '</td>'
                                        cirHtml += '<td class="item-back"><a title="Edit" href="/cir/save-StandText?ID=' + Item.id + '" ><i class="fa fa-pencil-square-o fa-lg"></i></a>'
                                        cirHtml += '<a style="margin-left:10px;" title="Delete the Stand Text" id="' + Item.id + '" href="javascript:void(0);" class="btn-delete removeStandText"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg"></i></a></td>'


                                        cirHtml += '</tr>';
                                    });
                                    cirHtml = cirHtml + '</tbody>'
                                    //console.log(cirHtml);
                                    $('table#localStandTextTable tr.item').remove();
                                    $('table#localStandTextTable tr.odd').remove();
                                    $('#localStandTextTable').append(cirHtml);
                                    //$('#localStandTextTable').dataTable();
                                }
                                else
                                {
                                    $('table#localStandTextTable tr.item').remove();
                                    $('table#localStandTextTable tr.odd').remove();
                                    $('#localStandTextTable').append('<tr class="item"><td colspan="3" style="text-align:center;">No records found</td></td>');
                                }

                            //var oTable = $('#localStandTextTable').dataTable();
                            //oTable.fnDestroy();
 
                            ////I put in new values 'newList' on the body
                            //$('#localStandTextTable tbody').html(newList);
 
                            ////I reinitialize the datatable
                            //$('#localStandTextTable').dataTable({ "oLanguage": { "sSearch": 'Search Contacts:' } });
                            
                            if ($.fn.dataTable.isDataTable('#localStandTextTable')) {
                                table = $('#localStandTextTable').DataTable();
                            }
                            else {
                                table = $('#localStandTextTable').DataTable({
                                    "bPaginate": true,
                                    "bFilter": false,
                                    "bInfo": true,
                                    "dom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>'
                                });
                            }
                            
                            

                            //$('#localStandTextTable').DataTable({
                            //    //"destroy": true,
                            //    "bPaginate": true,
                            //    "bFilter": false,
                            //    "bInfo": true,
                            //    "dom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>'
                            //});

                            //$('table#localStandTextTable tr.odd').remove();

                            $('div.top div.dataTables_info').remove();
                            $('div.bottom div.dataTables_length').remove();

                            var StandardText = getUrlParameter("Status");
                            if (StandardText == 'Success' && $('#hdnStatus').val() != '1') {
                                //showAndDismissAlert('success', 'Saved Successfully!');
                                NotifyCirMessage("", 'Saved Successfully!', "success");
                                $('#hdnStatus').val('1');
                            }
                        }, function (error) {
                            
                            console.log(error);
                        });
                    }
                }
            }
        });


    //   
    };

    
};

function deleteStandardTextByID(ids) {

    //alert(ids);

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
                    cirSearchString += '"id":' + ids + ',';
                    cirSearchString += '"deleted": 1';
                    cirSearchString += '}'
                    cirSearchjSon = jQuery.parseJSON(cirSearchString);
                    console.log(cirSearchString)
                    client.invokeApi('StandardTextData', {
                        method: 'Post',
                        body: cirSearchjSon
                    }).done(function (response) {
                        var resps = response.result;
                        $('table#localStandTextTable tr#' + ids).remove();
                        //showAndDismissAlert('success', 'Delete Successfully!');
                        NotifyCirMessage("", 'Delete  Successfully!', "success");
                    });
                }
            }
        }
    });


    //   
};



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
        StandardText.loadStandardText();
    });
    //$(document).tooltip(); //jQuery tool tips
    var oTable;
    $("[data-toggle=popover]").popover();
    
    
    //$('#localStandTextTable').DataTable({
    //    "dom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>'
    //});
    //$('#localStandTextTable').DataTable({
    //    "bPaginate": true,
    //    "bFilter": false,
    //    "bInfo": true
    //});

    

    $('body').on('click', '.removeStandText', function () {
        var Id = $(this).attr('id');
        if (!Id)
            return
        //var responce = confirm('Are you sure want to delete this Stand Text');
        /*if (responce==true) {
            
            deleteStandardTextByID(Id);
             
        }*/

        CirAlert.confirm('Are you sure want to delete this Stand Text', 'Cir App', 'Yes', 'No', 'question').done(function () {

            deleteStandardTextByID(Id);
        });


       
    });

    $("#ddlCirType").change(function () {
        //var oTable = $('#localStandTextTable').dataTable();
        //oTable.fnDestroy();
       

        StandardText.loadStandardText();
    });

    

    ///* Initialize table and make first column non-sortable*/
    //oTable = $('#localStandTextTable').dataTable({
    //    ScrollX: true,
    //    ScrollCollapse: true,
    //    //"bJQueryUI": true,
    //    //"aoColumns": [
    //    //   { "bSortable": false, "bSearchable": false },
    //    //   null,
    //    //   null,
    //    //   null, null
    //    //]
    //});

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