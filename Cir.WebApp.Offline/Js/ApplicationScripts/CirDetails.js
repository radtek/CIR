var __file = null;
var CIRID;
var CirDetails = new function () {
   
    var componenttype;
    var cirdataid;
    var file;
    var binaryString;
    var filename;
    this.CirDataDetail = function () {
        var CirDataObj = {};
        CirDataObj.CirDataId = $('#_hCirDataID').val();
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


                if (resps.ciRstate == 2) {
                    $("#CirAttachmentSection").show();
                    CirDetails.CirGetAttachments();
                }
                else {
                    $("#CirAttachmentSection").hide();
                }

                $('#spancirId').text(resps.cirId);
                $('#_hCirID').val(resps.cirId);
                $('#_hComponentType').val(resps.componentType);
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

                cirHtml += '<tr>'
                cirHtml += '<td colspan="4" class="text-center"><a href="/cir/Log-Viewer?ID=' + resps.cirDataId + '" style="text-decoration: underline;">Click here to view CIR full Log history</a></td>'
                cirHtml += '</tr>';


                cirHtml = cirHtml + '</tbody>'
                $('#CirDataDetail').append(cirHtml);

                $('#CirUploadOEMSection').hide();
                if (resps.componentType == "Generator" || resps.componentType == "Gearbox") {
                    $('#CirUploadOEMSection').show();
                }
            }
            else {
                NotifyCirMessage('Error : ', "Cir Details loading error", 'danger');
            }
        }).fail(function (e) {
            NotifyCirMessage('Error : ', "Cir Details loading error", 'danger');
        });



    };

    this.CirGetAttachments = function () {
       
        CallClientApi("GetAttachments/" + CIRID, "GET", "").done(function (data) {
            var cirHtml = '<tbody style="background:transparent">';
            $('#CirAttachments tbody').remove();
            $.each(data, function (i, item) {
                var action = "<a title='Download Attachment'><i style='color:#0000ff;cursor:pointer' id=" + item.cirAttachmentId + " class='fa fa-paperclip fa-lg' title='Download the document' onclick='CirDetails.downloaddoc(" + item.cirAttachmentId + ")'></i></a>&nbsp;&nbsp;&nbsp;"
                                  + '&nbsp;' + "<a title='Delete Attachment'><i style='color:#cc0000;cursor:pointer' id=" + item.cirAttachmentId + " class='fa fa-trash-o fa-lg' title='Delete the document' onclick='CirDetails.deleteDoc(" + item.cirAttachmentId + ")'></i></a>&nbsp;&nbsp;&nbsp;";
                cirHtml += '<tr>'
                cirHtml += '<td>' + action + '</td>'
                cirHtml += '<td>' + item.cirId + '</td>'
                cirHtml += '<td>' + item.filename + '</td>'
                cirHtml += '<td>' + item.createdBy + '</td>'
                cirHtml += '<td>' + item.created + '</td>'
                cirHtml += '</tr>';
            });
            if (data.length == 0) {
                $('#CirAttachments').append('<tr ><td colspan="5" style="text-align:center;">No attachments found</td></td>');
            }
            cirHtml = cirHtml + '</tbody>'
            $('#CirAttachments').append(cirHtml);

        });

    }

    this.UploadAttachment = function () {
        if (__file == null) {
            NotifyCirMessage('Error', 'Please select file to upload!', 'danger');
            return;
        }

        var objFile = {};
        objFile.cirid = CIRID;
        objFile.filename = __file.name;
        objFile.stringData = __file.data;

        waitingDialog.show('Uploading..Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        CallClientApi("CirAttachment", "POST", objFile).done(function (data) {
            waitingDialog.hide();
            __file = null;
            if (data == true) {
                NotifyCirMessage('', 'Document Uploaded Successfully!', 'info');
                CirDetails.CirGetAttachments();

            }
            else
                NotifyCirMessage('Error', 'Error occured while uploading document!', 'danger');

        })
        .fail(function (e) {
            waitingDialog.hide();
            __file = null;
            NotifyCirMessage('Error', 'Error occured while uploading document!', 'danger');
        });;

        $('#documentattachment').val('');

    }

    this.UploadDefectAttachment = function () {
        if (__file == null) {
            NotifyCirMessage('Error', 'Please select an excel file to upload!', 'danger');
            return;
        }
        var ext = $('#defectfileupload').val().split('.').pop().toLowerCase();
        if ($.inArray(ext, ['xlsx', 'xslt', 'xlsm']) == -1) {
            // alert('Please Upload Excel only!');
            // return;
            CirAlert.confirm('Please Upload Excel File only!', 'Cir App', 'Yes', 'No', 'warning').done(function () {

                return false;

            });
        }

        var objFile = {};
        objFile.cirid = CIRID;
        objFile.cirdataid = cirdataid;
        objFile.filename = __file.name;
        objFile.filedata = __file.data;
        if (componenttype == "Gearbox") {
            objFile.componenttype = 2;
        }

        if (componenttype == "Generator") {
            objFile.componenttype = 4;
        }
        waitingDialog.show('Uploading..Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        CallClientApi("UploadDefectCategotization", "POST", objFile).done(function (data) {
            __file = null;
            waitingDialog.hide();
            if (data.message == "Success") {
                NotifyCirMessage('', 'Document Uploaded Successfully!', 'info');
                CirDetails.CirGetAttachments();

            }
            else
                NotifyCirMessage('Error', data.message, 'danger');

        })
         .fail(function (e) {
             waitingDialog.hide();
             __file = null;
             NotifyCirMessage('Error', 'Error occured while uploading document!', 'danger');
         });;
        ;

        $('#defectfileupload').val('');



    }

    this.CirCommentHistory = function () {
        var CirDataObj = {};
        CirDataObj.CirDataId = $('#_hCirDataID').val();
        CallClientApi("GetCirCommentHistory", "POST", CirDataObj).done(function (response) {
            if (response) {
                var resp = response;
                var cirHtml = '<tbody style="background:transparent">';
                if (resp)
                    if (resp.length > 0) {
                        resp.forEach(function (Item) {
                            cirHtml += '<tr class="item" id="' + Item.cirCommentHistoryId + '">'
                            //cirHtml += '<td class="phone"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg"></i></td>'
                            cirHtml += '<td class="phone">' + Item.initials + '</td>'


                            Number.prototype.padLeft = function (base, chr) {
                                var len = (String(base || 10).length - String(this).length) + 1;
                                return len > 0 ? new Array(len).join(chr || '0') + this : this;
                            }
                            var d = new Date(Item.date);
                            //alert(d);
                            dformat = [(d.getUTCMonth() + 1).padLeft(),
                                                    d.getUTCDate().padLeft(),
                                                    d.getUTCFullYear()].join('/') +
                                                    ' ' +
                                                  [d.getUTCHours().padLeft(),
                                                    d.getUTCMinutes().padLeft(),
                                                    d.getUTCSeconds().padLeft()].join(':');


                            cirHtml += '<td data-hide="expand">' + dformat +"GMT" + '</td>'
                            cirHtml += '<td data-hide="expand">' + Item.comment + '</td>'
                            cirHtml += '</tr>';
                        });
                        cirHtml = cirHtml + '</tbody>'
                        //console.log(cirHtml);
                        $('table#CirCommentHistory tr.item').remove();
                        $('table#CirCommentHistory tr.odd').remove();
                        $('#CirCommentHistory').append(cirHtml);
                        //$('#localStandTextTable').dataTable();
                    }
                    else {
                        $('table#CirCommentHistory tr.item').remove();
                        $('table#CirCommentHistory tr.odd').remove();
                        $('#CirCommentHistory').append('<tr class="item"><td colspan="3" style="text-align:center;">No records found</td></td>');
                    }
            }

        }).fail(function (e) {
            NotifyCirMessage('Error : ', "Cir Details loading error", 'danger');
        });

    };

    //Task No. : 72518,72519 & 72520, Added By Siddharth Chauhan on 26-05-2015
    this.CirRevision = function () {
        var userValid_Viewer = hasRole("Viewer") || hasRole("Visitor");
        var CirDataObj = {};
        CirDataObj.CirDataId = $('#_hCirDataID').val();
        CallClientApi("GetCirRevision", "POST", CirDataObj).done(function (response) {
            if (response) {
                var resp = response;
                var cirHtml = '<tbody style="background:transparent">';
                if (resp)
                    if (resp.length > 0) {
                        resp.forEach(function (Item) {
                            var cirId = $('#hdnCirId').val();
                            cirHtml += '<tr class="item" id="' + Item.cirId + '">'
                            //Show Edit action only for Template version 5 and above.
                            if (parseInt(Item.templatedRevisionId) >= 5) {
                                if (userValid_Viewer == true) {
                                    cirHtml += '<td class="phone">&nbsp;</td>'
                                }
                                else {
                                    if (Item.cirId >= cirId)
                                    cirHtml += '<td class="phone"><a title="Edit CIR Revision" href="/cir/formio-cir#id=' + Item.cirId + '"><i style="color:#2E64FE;cursor:pointer" id="iconInfo" class="fa fa-pencil-square-o fa-lg" title="Edit CIR Revision")"></i></a></td>'
                                    else
                                        cirHtml += '<td class="phone"><a title="Edit CIR Revision" href="/cir/manage-cir?cirrevisionID=' + Item.cirDataId + '"><i style="color:#2E64FE;cursor:pointer" id="iconInfo" class="fa fa-pencil-square-o fa-lg" title="Edit CIR Revision")"></i></a></td>'
                                    }
                            }
                            else {
                                cirHtml += '<td class="phone">&nbsp;</td>'

                            }

                            Number.prototype.padLeft = function (base, chr) {
                                var len = (String(base || 10).length - String(this).length) + 1;
                                return len > 0 ? new Array(len).join(chr || '0') + this : this;
                            }
                            
                            var d = new Date(Item.editedOn);
                            dformat = [(d.getUTCMonth() + 1).padLeft(),
                                                     d.getUTCDate().padLeft(),
                                                     d.getUTCFullYear()].join('/') +
                                                     ' ' +
                                                   [d.getUTCHours().padLeft(),
                                                     d.getUTCMinutes().padLeft(),
                                                     d.getUTCSeconds().padLeft()].join(':');


                            cirHtml += '<td data-hide="expand">' + dformat + " GMT" + '</td>'
                            cirHtml += '<td data-hide="expand">' + Item.editedBy
                            cirHtml += '<input id="hdnCirId' + Item.cirDataId + '"  type=hidden value="' + Item.cirId + '"/>' + '</td>'
                            cirHtml += '</tr>';
                        });
                        cirHtml = cirHtml + '</tbody>'
                        $('table#CirRevision tr.item').remove();
                        $('table#CirRevision tr.odd').remove();
                        $('#CirRevision').append(cirHtml);
                    }
                    else {
                        $('table#CirRevision tr.item').remove();
                        $('table#CirRevision tr.odd').remove();
                        $('#CirRevision').append('<tr class="item"><td colspan="3" style="text-align:center;">No records found</td></td>');
                    }
            }

        }).fail(function (e) {
            NotifyCirMessage('Error : ', "Cir Details loading error", 'danger');
        });


        //   
    };

    this.getCosmosDbCirRevisions = function(cirId) {
        let deferred = $.Deferred();

        try {
            CallSyncApi("CirRevisionHistory/GetRevisionHistory?cirId=" + cirId, "GET", {}).done(function(response) {
                deferred.resolve(JSON.parse(response.response));
            });
        } catch (e) {
            deferred.reject(e);
        }

        return deferred.promise();
    };

    this.AddCosmosDbCirRevisions = function (items) {
        var userValid_Viewer = hasRole("Viewer") || hasRole("Visitor");

        if (items && items.length > 0) {
            var cirHtml = '<tbody style="background:transparent">';

            items.forEach(function(item) {
                cirHtml += '<tr class="item" id="' + item.cirId + '">';
                if (userValid_Viewer == true) {
                    cirHtml += '<td class="phone">&nbsp;</td>';
                } else {
                    cirHtml += '<td class="phone"><a title="Edit CIR Revision" href="/cir/formio-cir#id=' +
                        item.id + '&isHistorical=true' +
                        '"><i style="color:#2E64FE;cursor:pointer" id="iconInfo" class="fa fa-pencil-square-o fa-lg" title="Edit CIR Revision")"></i></a></td>';
                }

                Number.prototype.padLeft = function (base, chr) {
                    var len = (String(base || 10).length - String(this).length) + 1;
                    return len > 0 ? new Array(len).join(chr || '0') + this : this;
                }
                var d = new Date(item.modifiedOn);
                dformat = [(d.getUTCMonth() + 1).padLeft(),
                                                     d.getUTCDate().padLeft(),
                                                     d.getUTCFullYear()].join('/') +
                                                     ' ' +
                                                   [d.getUTCHours().padLeft(),
                                                     d.getUTCMinutes().padLeft(),
                                                     d.getUTCSeconds().padLeft()].join(':');


                cirHtml += '<td data-hide="expand">' + dformat +" GMT" + '</td>';
                cirHtml += '<td data-hide="expand">' + item.modifiedBy + '</td>';
                cirHtml += '</tr>';
            });

            cirHtml = cirHtml + '</tbody>';
            $('table#CirRevision tr.item').remove();
            $('table#CirRevision tr.odd').remove();
            $('#CirRevision').append(cirHtml);
        } else {
            $('table#CirRevision tr.item').remove();
            $('table#CirRevision tr.odd').remove();
            $('#CirRevision').append('<tr class="item"><td colspan="3" style="text-align:center;">No records found</td></td>');
        }
    };

    this.downloaddoc = function (id) {

        waitingDialog.show('Downloading document..', {
            dialogSize: 'sm', progressType: 'primary'
        });

        CallClientApi("GetAttachment/" + id, "GET", "").done(function (result) {
            waitingDialog.hide();
            if (result) {
                if (result.stringData) {
                    var blob = b64toBlob(result.stringData, "");
                    saveAs(blob, result.filename);
                    var iOS = /iPad|iPhone|iPod/.test(navigator.userAgent) && !window.MSStream;
                    if (iOS) {
                        window.location = "data:application/xls;base64," + result.stringData;
                        openTab("data:application/pdf;base64," + result.stringData);
                    }
                }
                else {
                    NotifyCirMessage('', "Error Downloading File!", 'danger');
                }

            }
            else {
                waitingDialog.hide();
                NotifyCirMessage('Error : ', "document loading error", 'danger');
            }
        });
    }

    this.deleteDoc = function (id) {

        CirAlert.confirm('Do you want to Delete the document', 'Cir App', 'Yes', 'No', 'warning').done(function () {
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            CallClientApi("CirAttachment?cirAttachmentId=" + id, "DELETE", "").done(function (data) {
                waitingDialog.hide();
                if (data == true) {
                    NotifyCirMessage('', 'Document deleted!', 'info');
                    CirDetails.CirGetAttachments();
                }
                else
                    NotifyCirMessage('Error', 'Error occured while deleting document!', 'danger');

            }).fail(function (e) {
                waitingDialog.hide();
                console.log(e);
            });
        });

    }
};


function SaveComment() {


    var isValid = true;
    if ($('#txtComment').val() != '') {
        $('#txtComment').removeClass('validationerror red-tooltip');
    }
    else {
        $('#txtComment').addClass('validationerror red-tooltip');

        $('#txtComment').focus();
        isValid = false;
    }

    if (!isValid)
        return false;

    var cirObj = {};
    cirObj.cirCommentHistoryId = 0;
    cirObj.cirDataId = $('#_hCirDataID').val();
    cirObj.comment = $('#txtComment').val();
    cirObj.date = "1900/01/01";
    cirObj.initials = $('#hdnUserInitial').val();
    cirObj.type = 1;


    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
    CallClientApi("CirCommentHistory", "POST", cirObj).done(function (data) {
        $('#txtComment').val('');
        waitingDialog.hide();
        NotifyCirMessage("", 'Save  Successfully!', "success");
        CirDetails.CirCommentHistory();

    }).fail(function (e) {
        waitingDialog.hide();
        NotifyCirMessage("", 'Error saving Comment!', "danger");
        console.log(e);
    });




};

function ShowCirDetails(id, type) {
    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
    if (type == -1) {    
        window.location = "/cir/Log-Viewer?ID=" + id;
        return;;
    }

    $('#CirDetailsBody').load("/cir/Cir-Details?ID=" + id, function (result) {
        var isFormioCir = $("#_isFormioCir").val();

        waitingDialog.hide();
        $('#_hCirDataID').val(id);
        CirDetails.CirDataDetail();
        if (type == 2) {
            $("#CirCommentsSection").hide();
            $("#CirRevisionSection").hide();

        }
        else {
            $("#CirCommentsSection").show();
            $("#CirRevisionSection").show();
            CirDetails.CirCommentHistory();

            if (isFormioCir) {
                CirDetails.getCosmosDbCirRevisions(id).done(function(response) {
                    CirDetails.AddCosmosDbCirRevisions(response);
                }).fail(function(e) {
                    NotifyCirMessage('Error : ', "Cir Details loading error", 'danger');
                });
            } else {
                CirDetails.CirRevision();
            }
        }

        var handleFileSelect = function (evt) {

            var files = evt.target.files;
            __file = files[0];


            if (files && __file) {
                var reader = new FileReader();

                reader.onload = function (readerEvt) {
                    binaryString = readerEvt.target.result;
                    binaryString = btoa(binaryString);
                    __file.data = binaryString;

                    //document.getElementById("base64textarea").value = btoa(binaryString);
                };

                reader.readAsBinaryString(__file);
            }
        };
        if (window.File && window.FileReader && window.FileList && window.Blob) {
            //  document.getElementById('documentattachment').addEventListener('change', handleFileSelect, false);
            $("#defectfileupload").on("change", handleFileSelect);
        }

        if (window.File && window.FileReader && window.FileList && window.Blob) {
            //  document.getElementById('defectfileupload').addEventListener('change', handleFileSelect, false);
            $("#documentattachment").on("change", handleFileSelect);
        }
        else {
            alert('The File APIs are not fully supported in this browser.');
        }


        //To hide NonAttachmentSection
        var PageType = getUrlParameter("Type");
        if (PageType && PageType == "Attachment") {
            $('#NonAttachmentSection').hide();
            $('#liLogViewerLink').hide();
        }
        $('#ModalCirDetails').modal({ show: true });
    });

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

        //  CirDetails.CirDataDetail();
        //   CirDetails.CirCommentHistory();
        //   CirDetails.CirRevision();

        //CirDetails.UploadAttachment();

        //To hide NonAttachmentSection
        // var PageType = getUrlParameter("Type");
        //  if (PageType && PageType == "Attachment") {
        //    $('#NonAttachmentSection').hide();
        ///     $('#liLogViewerLink').hide();
        //  }
        //To hide NonAttachmentSection
    });



    $('#txtComment').change(function () {
        if ($(this).val() != '') {
            $(this).removeClass('validationerror red-tooltip');
        }
        else {
            $(this).removeClass('validationerror red-tooltip');
            $(this).addClass('validationerror red-tooltip');
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