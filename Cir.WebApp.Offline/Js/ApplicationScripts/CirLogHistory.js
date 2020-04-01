var Cirlog = new function () {   
    
    this.loadCirlog = function () {

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
                        var CirDataID = getUrlParameter("ID");
                       
                        if (CirDataID && CirDataID != '0')
                            cirSearchString += '"CirDataId":' + CirDataID;

                        else
                            cirSearchString += '"CirDataId":1';

                        cirSearchString += '}'

                        console.log(cirSearchString);

                        cirSearchjSon = jQuery.parseJSON(cirSearchString);
                        console.log(cirSearchjSon);
                        
                        client.invokeApi('CIRLog', {
                            method: 'Post',
                            body: cirSearchjSon
                        }).done(function (response) {
                            var resp = response.result;
                            var cirHtml = '<tbody style="background:transparent">';
                            if (resp)
                                if (resp.length > 0) {
                                    resp.forEach(function (Item) {
                                        cirHtml += '<tr class="item" id="' + Item.cirDataId + '">'
                                        //cirHtml += '<td class="phone"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg"></i></td>'
                                        cirHtml += '<td class="phone">' + Item.text + '</td>'
                                        cirHtml += '<td data-hide="expand">' + Item.initials + '</td>'

                                        Number.prototype.padLeft = function (base, chr) {
                                            var len = (String(base || 10).length - String(this).length) + 1;
                                            return len > 0 ? new Array(len).join(chr || '0') + this : this;
                                        }
                                        var d = new Date(Item.timestamp);
                                        
                                        //alert(d);
                                        dformat = [(d.getUTCMonth() + 1).padLeft(),
                                                    d.getUTCDate().padLeft(),
                                                    d.getUTCFullYear()].join('/') +
                                                    ' ' +
                                                  [d.getUTCHours().padLeft(),
                                                    d.getUTCMinutes().padLeft(),
                                                    d.getUTCSeconds().padLeft()].join(':');
                                        //alert(dformat);
                                        //var d = Item.timestamp.slice(0, 10).split('-');
                                        //d[1] + '/' + d[2] + '/' + d[0]; // 10/30/2010

                                        cirHtml += '<td data-hide="expand">' + dformat + " GMT" + '</td>'

                                        cirHtml += '</tr>';
                                    });
                                    cirHtml = cirHtml + '</tbody>'
                                    //console.log(cirHtml);
                                    $('table#localCIRLogTable tr.item').remove();
                                    $('table#localCIRLogTable tr.odd').remove();
                                    $('#localCIRLogTable').append(cirHtml);
                                    //$('#localStandTextTable').dataTable();
                                }
                                else
                                {
                                    $('table#localCIRLogTable tr.item').remove();
                                    $('table#localCIRLogTable tr.odd').remove();
                                    $('#localCIRLogTable').append('<tr class="item"><td colspan="3" style="text-align:center;">No records found</td></td>');
                                }

                            //var oTable = $('#localStandTextTable').dataTable();
                            //oTable.fnDestroy();
 
                            ////I put in new values 'newList' on the body
                            //$('#localStandTextTable tbody').html(newList);
 
                            ////I reinitialize the datatable
                            //$('#localStandTextTable').dataTable({ "oLanguage": { "sSearch": 'Search Contacts:' } });
                            
                            //if ($.fn.dataTable.isDataTable('#localStandTextTable')) {
                            //    table = $('#localStandTextTable').DataTable();
                            //}
                            //else {
                            //    table = $('#localStandTextTable').DataTable({
                            //        "bPaginate": true,
                            //        "bFilter": false,
                            //        "bInfo": true,
                            //        "dom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>'
                            //    });
                            //}
                            
                            

                            //$('#localStandTextTable').DataTable({
                            //    //"destroy": true,
                            //    "bPaginate": true,
                            //    "bFilter": false,
                            //    "bInfo": true,
                            //    "dom": '<"top"iflp<"clear">>rt<"bottom"iflp<"clear">>'
                            //});

                            //$('table#localStandTextTable tr.odd').remove();

                            //$('div.top div.dataTables_info').remove();
                            //$('div.bottom div.dataTables_length').remove();

                            //var StandardText = getUrlParameter("Status");
                            //if (StandardText == 'Success' && $('#hdnStatus').val() != '1') {
                            //    //showAndDismissAlert('success', 'Saved Successfully!');
                            //    NotifyCirMessage("", 'Saved Successfully!', "success");
                            //    $('#hdnStatus').val('1');
                            //}
                        }, function (error) {
                            
                            console.log(error);
                        });
                    }
                }
            }
        });


    //   
    };

    this.CirDataDetail = function () {
        var CirDataObj = {};
        var CirDataID = getUrlParameter("ID");
        CirDataObj.CirDataId = CirDataID;
        CallClientApi("GetCirDataDetail", "POST", CirDataObj).done(function (result) {
            if (result) {
                var resps = result;

                CIRID = resps.cirId;
                componenttype = resps.componentType;
                cirdataid = resps.cirDataId;

                var stateName = ""
                if (resps.ciRstate == 1)
                    stateName = "Submitted";
                else if (resps.ciRstate == 2)
                    stateName = "Accepted";
                else
                    stateName = "Rejected";

                $('#spancirId').text(resps.cirId);
                //$('#_hCirID').val(resps.cirId);
                //$('#_hComponentType').val(resps.componentType);
                //alert(resps.cirDataId);

                var cirHtml = '<tbody style="background:transparent">';
                cirHtml += '<tr>'
                cirHtml += '<td><b>CIR Name</b></td>'
                cirHtml += '<td colspan=3>' + resps.filename + '</td>'
                cirHtml += '</tr>';

                cirHtml += '<tr>'
                cirHtml += '<td><b>CIR State</b></td>'
                cirHtml += '<td>' + stateName + '</td>'
                cirHtml += '<td><b>Component Type</b></td>'
                cirHtml += '<td>' + resps.componentType + '</td>'
                cirHtml += '</tr>';

                cirHtml += '<tr>'
                cirHtml += '<td><b>CIM Case</b></td>'
                cirHtml += '<td>' + resps.cimCaseNumber + '</td>'
                cirHtml += '<td><b>Report Type</b></td>'
                cirHtml += '<td>' + resps.reportType + '</td>'
                cirHtml += '</tr>';

                cirHtml += '<tr>'
                cirHtml += '<td><b>Turbine Type</b></td>'
                cirHtml += '<td>' + resps.turbineType + '</td>'
                cirHtml += '<td><b>Turbine Number</b></td>'
                cirHtml += '<td>' + resps.turbineNumber + '</td>'
                cirHtml += '</tr>';

                //cirHtml += '<tr>'
                //cirHtml += '<td colspan="4" class="text-center"><a href="/cir/Log-Viewer?ID=' + resps.cirDataId + '" style="text-decoration: underline;">Click here to view CIR full Log history</a></td>'
                //cirHtml += '</tr>';


                cirHtml = cirHtml + '</tbody>'
                $('#CirDataDetail_Logview').append(cirHtml);

            }
            else {
                NotifyCirMessage('Error : ', "Cir Details loading error", 'danger');
            }
        }).fail(function (e) {
            NotifyCirMessage('Error : ', "Cir Details loading error", 'danger');
        });
    };
};


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
        
        Cirlog.loadCirlog();
        Cirlog.CirDataDetail();
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