
$(document).ready(function () {
    Offline.check();
    setTimeout(function () {
        CheckValidUserToken();
        if (Offline.state == "down")
            return;
        else {
            // cirOfflineAppSearch.GetRowCountData($('#MobAppURL').val(), $('#MobAppID').val(), _RecordsPerPage, 1, _state);
            LoadUserInfo().done(function () {
                $('#hdnUserPrincipal').val(CurrentUserInfo.UserPrincipleName);
            });
        }
    }, 2000);
    DoSearch();
});
function DoSearch() {

    if (document.URL.toLowerCase().indexOf('cir-pdf') > -1) {
        setTimeout(function () {
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            loadPDFData($('#MobAppURL').val(), $('#MobAppID').val(), _state);
        }, 1000);

    }

}

function loadPDFData(appUrl, appID, state) {

    if (Offline.state == "down") {
        waitingDialog.hide();
        $("#cirSearchButton").attr("style", "background-color:#0072BB;color:white")
        $("#cirSearchButton").attr("title", "Only local search will work as you are offine!")
        $("#btnLazyLoad").hide();
        $("#cirSearchListRemote > tbody").html('<tr class="item"><td colspan="13" style="text-align:center;">You can not download PDF in <font color=red>Offline Mode</font></td></td>');
    }
    else {
        var client = new WindowsAzure.MobileServiceClient(appUrl, appID, ''); // Azure auth
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser) {
                if (currentuser.length > 0) {
                    currentuser.forEach(function (item) {
                        client.currentUser = item.objet;
                    });
                    if (client.currentUser) {
                        var searchCirID = getQueryStringValueHash("CirID");
                        var cirSearchjSon = {};

                        if (searchCirID && searchCirID != '0') {
                            cirSearchjSon.cirID = searchCirID;
                        }


                        var searchObj = {};
                        searchObj.currentPageNumber = 1;
                        searchObj.recordsPerPage = 1;
                        searchObj.totalRecordCount = 0;

                        cirSearchjSon.search = searchObj;
                        console.log(cirSearchjSon);

                        client.invokeApi('CirSearch', {
                            method: 'POST',
                            body: cirSearchjSon
                        }).done(function (response) {
                            waitingDialog.hide();
                            var resp = response.result;
                            console.log(resp);
                            if (resp.length > 0) {
                                var userValid = hasRole("BirCreator") || hasRole("GirCreator") || hasRole("Administrator") || hasRole("GirCreator") || hasRole("GBXIRCreator");
                                var cirDataID = resp[0].cirDataID;
                                if (resp[0].totalRejectedRecords > 0) {
                                    CirAlert.alert('CIR #' + searchCirID + ' has been Rejected', 'Cir App', null, 'error');
                                }
                                else {
                                    openPDF(cirDataID);
                                }

                            }
                            else {
                                CirAlert.alert('CIR #' + searchCirID + ' has been deleted', 'Cir App', null, 'error');
                            }

                        }, function (error) {
                            waitingDialog.hide();
                            console.log(error);
                        });
                    }
                }
            }
        });
    }
}

function openPDF(ids) {
    waitingDialog.show('Opening PDF..', { dialogSize: 'sm', progressType: 'primary' });

    CallClientApi("CirPdfFile/" + ids, "POST", "").done(function (result) {
        waitingDialog.hide();
        if (result) {
            if (result.downloadUrl) {
                var blob = b64toBlob(result.downloadUrl, "application/pdf");
                //saveAs(blob, result.fileName);
                var iOS = /iPad|iPhone|iPod/.test(navigator.userAgent) && !window.MSStream;
                if (iOS) {
                    window.location = "data:application/pdf;base64," + result.downloadUrl;
                    openTab("data:application/pdf;base64," + result.downloadUrl);
                }
                else {
                    //var urlDoc = document.URL;
                    var fileURL = URL.createObjectURL(blob);
                    window.open(fileURL, "_self");
                    //var w1 = window.open(fileURL, "_self");
                    //w1.location.href = urlDoc;
                }
            }
            else {
                NotifyCirMessage('Error : ', "Cir PDF has not been generated yet!, Please try again in a minute", 'danger');
            }

        }
        else {
            NotifyCirMessage('Error : ', "Cir PDF loading error", 'danger');
        }
    });

}