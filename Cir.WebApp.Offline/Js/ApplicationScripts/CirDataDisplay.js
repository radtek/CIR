var cirDataDiplay = new function () {

    //-1 Error  - Grid 1
    // 1 Draft  -- Grid 2
    // 2 Submitted -- Grid 2
    // 3 Synced     -- Grid 3
    // 4 Conflict    -- Grid 2
    // 5 Processing  -- Grid 2 (Same as Submitted)
    // 6 Locked/ReAssigned Obsolete

    // Cir Status 
    //1	Initial
    //2	Awaiting approval
    //3	Rejected
    //4	Accepted
    //5	On Hold

    //Initial = 1,
    //   Approved = 2,
    //   Rejected = 3

    //1	Blade
    //2	Gearbox
    //3	General
    //4	Generator
    //6	Main Bearing
    //7	Skiipack
    //5	Transformer
    this._OrderBy
    this.getName = function (rawJsonItem, template_name) {
        var turbineNumber = rawJsonItem.data["txtTurbineNumber"];
        var cimCaseNo = rawJsonItem.data["ddlCimCaseNumber"];
        var siteName = rawJsonItem.data["txtSiteName"];

        return (turbineNumber ? turbineNumber : "{SiteName}")
            + "_"
            + template.name + "_"
            + (turbineNumber != undefined ? turbineNumber : "{TurbineNo}") + "_" + new Date().toISOString().substring(0, 10) + "_"
            + (cimCaseNo != undefined ? cimCaseNo : "{CimCaseNo}");

    }
    this.getDataRows = function (item, GridType) {
        var userValid = hasRole("BIRCreator") ||
                   hasRole("Owner") ||
                   hasRole("Administrator") ||
                   hasRole("Member") ||
                   hasRole("GIRCreator") ||
                   hasRole("GBXIRCreator");
        //----------------
        var CirLocaldata = [];
        var dataRows = {};
        var RemoveCirClassName;
        var RemoveLocalCirClassName;
        var RevokeDelegateCIRClassName;
        var RevokeDelegateCIRClassName_Owner;


        if (GridType == "1") { //Local History
            RemoveCirClassName = 'RemoveCirs';
            RemoveLocalCirClassName = 'RemoveLocalCirs';
            RemoveLocalSynCirClassName = 'RemoveLocalSynCirs';
            RevokeDelegateCIRClassName = "RevokeDelegateCIR"
            RevokeDelegateCIRClassName_Owner = "RevokeDelegateCIR_Owner";
        } else if (GridType == "2") { //CIR Local Search
            RemoveCirClassName = 'RemoveLocalCir_Search';
            RemoveLocalCirClassName = 'RemoveLocalCir_Search';
            RemoveLocalSynCirClassName = 'RemoveLocalCir_Search';
            RevokeDelegateCIRClassName = "RevokeDelegateCIR_Serach"
            RevokeDelegateCIRClassName_Owner = "RevokeDelegateCIR_Owner_Search";
        }

        dataRows.DisplayCirId = item.DisplayCirId;
        dataRows.ComponentInspectionReportName = item.ComponentInspectionReportName;
        dataRows.CimCaseNumber = item.CimCaseNumber;
        dataRows.TurbineType = item.TurbineType;
        dataRows.TurbineNumber = item.TurbineNumber;
        dataRows.SiteName = item.SiteName;
        dataRows.CreatedDate = item.CreatedDate;
        dataRows.RowId = item.Id;
        dataRows.MError = item.MError;


        if (item.IsNewCir) {
            let cirId = ((item.Status == "Submitted" || item.Status == "Approved") && item.CirId !== undefined) ? item.CirId : item.Id;
            var editAction = "";
            if (item.Status == "Approved") {               
                if (userValid) {
                     editAction = '<a title="Edit CIR" id="' +
                        item.Id +
                        '" href="/cir/formio-cir#id=' +
                        cirId + '&state=2' +
                        '"; ><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;';
                }

            }
            else {
                 editAction = '<a title="Edit CIR" id="' +
                    item.Id +
                    '" href="/cir/formio-cir#id=' +
                    cirId +
                    '"; ><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;';
            }

            var revokeDelegationAction = '<a title="Return CIR to Owner" isNew="true" id="' +
                item.Id +
                '" value= "Do you want to return the CIR to Owner ?" href="javascript:void(0);" class="btn-delegate ' +
                RevokeDelegateCIRClassName +
                '"><i style="color:#cc0000;"  class="fa fa-reply-all fa-lg"></i></a>';
            var revokeDelefatedPermission = '<a title="Revoke delegated permission" isNew="true" id="' +
                item.Id +
                '" value= "Do you want to revoke the delegated permission ?" href="javascript:void(0);" class="btn-revokedelegation ' +
                RevokeDelegateCIRClassName_Owner +
                '"><i style="color:#cc0000;"  class="fa fa-user-times fa-lg"></i></a>';

            var deleteCir = '<a title="Delete CIR" isNew="true" id="' +
                item.Id + "," + cirId +
                '"href="javascript:void(0);" value="Do you wish to delete this CIR?" class="btn-delete ' +
                RemoveCirClassName +
                '"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg "></i></a>&nbsp;&nbsp;&nbsp;'
            var generatePdf = '<a title="Download CIR"><i style="color:#8A0829;cursor:pointer" id="' + item.Id + '" class="fa fa-file-pdf-o fa-lg" title="Download as PDF" onclick="cirDataDiplay.downloadPDF(' + item.CirId + ')"></i></a>&nbsp;&nbsp;&nbsp;'



            if (isNewCirStateError(item)) {
                dataRows.CIRCurrentStaus = 'Error';
                var sqlErrorDetail = "Unknown Error Occured while Syncing";
                if (item.sqlProcessStatus != null) {
                    sqlErrorDetail = item.sqlProcessStatus.replace('"', '\"').replace('ErrorState#', '');
                }
                dataRows.ActionIcons = editAction +
                    deleteCir +
                    '<a title="Delegate CIR" id="' +
                    item.Id +
                    '" value= "' +
                    item.CirDataId +
                    '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' +
                    sqlErrorDetail +
                    '" value="' +
                    sqlErrorDetail +
                    '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#cc0000;cursor:pointer"></a>';


            }
            else if ((item.Status === "Submitted" || item.Status === "Approved" || item.Status === "Rejected") && !isNewCirStateError(item) && item.imageProcessStatus === "Synced" && item.sqlProcessStatus === "Transferred") {
                //Green Section block
                dataRows.CIRCurrentStaus = item.Status;
                dataRows.ActionIcons = generatePdf + editAction;// + deleteCir;

                dataRows.StausIcon = '<i title="' +
                    item.StatusMessage.replace('"', '\"') +
                    '" value="' +
                    item.StatusMessage.replace('"', '\"') +
                    '" class="fa fa-check fa-lg" style="color:#3c763d;cursor:pointer">';
            } else {
                dataRows.CIRCurrentStaus = item.Status;
                var isDelegated = ((item.delegatedTo != null) && (item.delegatedTo.length > 0)) ||
                    ((item.delegatedBy != null) && (item.delegatedBy.length > 0));
                if (isDelegated) {
                    var currentUserIsDelegated = item.delegatedTo.toLowerCase() === CurrentUserInfo.Name.toLowerCase();
                    if (currentUserIsDelegated) {
                        dataRows.ActionIcons = editAction + revokeDelegationAction;
                        //    NotifyCirMessage('', 'CIR [' + item.Name + '], This CIR has been delegated to you by ' + item.delegatedTo, 'danger', 0);
                    }
                    var currentUserIsDelegator = (item.delegatedBy !== undefined && item.delegatedBy !== null) &&
                        item.delegatedBy.toLowerCase() === CurrentUserInfo.Name.toLowerCase();
                    if (currentUserIsDelegator) {
                        dataRows.CIRCurrentStaus = "CIR Delegated to other User";
                        dataRows.ActionIcons = revokeDelefatedPermission;
                        dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' +
                            item.Remarks +
                            '" style="color:#cc0000;cursor:pointer" class="fa fa-lock fa-lg"></i></a>';
                        //NotifyCirMessage('', 'CIR [' + item.Name + '], This CIR has been delegated to ' + item.delegatedTo, 'danger', 0);
                    }
                } else {
                    dataRows.ActionIcons = editAction +
                        '<a title="Unlock CIR" id="' +
                        item.Id +
                        '" isNew="true"  href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History." class="btn-delete ' +
                        RemoveLocalCirClassName +
                        '"><i style="color:#8a6d3b;" class="fa fa-unlock fa-lg "></i></a>&nbsp;&nbsp;&nbsp;' +
                        '<a title="Delegate CIR" isNew="true" id="' +
                        item.Id +
                        '" value= "' +
                        item.CirDataId +
                        '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                    dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' +
                        item.StatusMessage +
                        '" value="' +
                        item.StatusDetailMessage +
                        '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#FF8C00;cursor:pointer"></i></a>';
                }
            }
            CirLocaldata.push(dataRows);
            return CirLocaldata;
        }

        //Error
        if (item.Status == "-1") {
            dataRows.CIRCurrentStaus = 'Error';
            if (item.ComponentInspectionReportId == 0) {
                dataRows.ActionIcons = '<a title="Edit CIR" id="' +
                    item.Id +
                    '" href=javascript:cirDataDiplay.EditCir(-1,"' +
                    item.Id +
                    '"); ><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;' +
                    '<a title="Delete CIR" id="' +
                    item.Id +
                    '"href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History." class="btn-delete ' +
                    RemoveCirClassName +
                    '"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg "></i></a>&nbsp;&nbsp;&nbsp;' +
                    '<a title="Delegate CIR" id="' +
                    item.Id +
                    '" value= "' +
                    item.CirDataId +
                    '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"  ><i title="' +
                    item.StatusMessage.replace('"', '\"') +
                    '" value="' +
                    item.StatusMessage.replace('"', '\"') +
                    '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#cc0000;cursor:pointer"></i></a>';
            } else {
                dataRows.ActionIcons = '<a title="Edit CIR"  id="' +
                    item.Id +
                    '" href=javascript:cirDataDiplay.EditCir(-1,"' +
                    item.Id +
                    '"); ><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;' +
                    '<a title="Delete CIR" id="' +
                    item.Id +
                    '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History. This will also Unlock the CIR and make it available to other users." class="btn-delete ' +
                    RemoveCirClassName +
                    '"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg "></i></a>&nbsp;&nbsp;&nbsp;' +
                    '<a title="Delegate CIR" id="' +
                    item.Id +
                    '" value= "' +
                    item.CirDataId +
                    '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' +
                    item.StatusMessage.replace('"', '\"') +
                    '" value="' +
                    item.StatusMessage.replace('"', '\"') +
                    '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#cc0000;cursor:pointer"></a>';
            }
            CirLocaldata.push(dataRows);

        }
            // Synced cirDataID
        else if (item.Status == "3") {
            var strDownloadCIR = "&nbsp;";
            if (Offline.state != "down") {
                strDownloadCIR = "<a title='Download CIR'><i style='color:#8A0829;cursor:pointer' id=" +
                    item.Id +
                    " class='fa fa-file-pdf-o fa-lg' title='Download as PDF' onclick='cirDataDiplay.downloadPDF(" +
                    item.ComponentInspectionReportId +
                    ")'></i></a>&nbsp;&nbsp;&nbsp;";
            }
            if (item.CirStatus == "1") {
                dataRows.CIRCurrentStaus = 'Submitted'; //"Initial" changed for 83360
                dataRows.ActionIcons = strDownloadCIR +
                    '<a title="Edit CIR"  id="' +
                    item.ComponentInspectionReportId +
                    '" href=javascript:cirDataDiplay.EditCir(3,"' +
                    item.ComponentInspectionReportId +
                    '",' +
                    item.CirDataId +
                    '); ><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;' +
                    '<a title="Delete CIR" id="' +
                    item.Id +
                    '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History." class="btn-delete ' +
                    RemoveLocalSynCirClassName +
                    '"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg "></i></a>&nbsp;&nbsp;&nbsp;'
                //+ '<a title="Delegate CIR" id="' + item.Id + '" value= "' + item.CirDataId + '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                dataRows.StausIcon =
                    '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="Successfully synced Cir" class="fa fa-check fa-lg" style="color:#3c763d;"></i></a>';
            } else if (item.CirStatus == "3") {
                dataRows.CIRCurrentStaus = "<font color='red'>Rejected</font>";
                dataRows.ActionIcons = strDownloadCIR +
                    '<a title="Edit CIR" id="' +
                    item.ComponentInspectionReportId +
                    '" href=javascript:cirDataDiplay.EditCir(3,"' +
                    item.ComponentInspectionReportId +
                    '",' +
                    item.CirDataId +
                    ');  ><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;' +
                    '<a title="Delete CIR" id="' +
                    item.Id +
                    '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History." class="btn-delete ' +
                    RemoveLocalSynCirClassName +
                    '"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg "></i></a>&nbsp;&nbsp;&nbsp;'
                // + '<a title="Delegate CIR" id="' + item.Id + '" value= "' + item.CirDataId + '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                dataRows.StausIcon =
                    '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="Successfully synced Cir" class="fa fa-check fa-lg" style="color:#3c763d;"></i></a>';
            } else if (item.CirStatus == "2") {
                dataRows.CIRCurrentStaus = "<font color='green'>Approved</font>";
                if (userValid) {
                    dataRows.ActionIcons = strDownloadCIR +
                        '<a title="Edit CIR"  id="' +
                        item.ComponentInspectionReportId +
                        '" href=javascript:cirDataDiplay.EditCir(3,"' +
                        item.ComponentInspectionReportId +
                        '",' +
                        item.CirDataId +
                        ');  ><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;' +
                        '<a title="Delete CIR" id="' +
                        item.Id +
                        '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History." class="btn-delete ' +
                        RemoveLocalSynCirClassName +
                        '"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg "></i></a>&nbsp;&nbsp;&nbsp;'
                    // + '<a title="Delegate CIR" id="' + item.Id + '" value= "' + item.CirDataId + '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                    dataRows.StausIcon =
                        '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="Successfully synced Cir" class="fa fa-check fa-lg" style="color:#3c763d;"></i></a>';
                } else {
                    dataRows.ActionIcons = strDownloadCIR +
                        '<a title="Delete CIR" id="' +
                        item.Id +
                        '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History." class="btn-delete ' +
                        RemoveLocalSynCirClassName +
                        '"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg "></i></a>&nbsp;&nbsp;&nbsp;'
                    //+ '<a title="Delegate CIR" id="' + item.Id + '" value= "' + item.CirDataId + '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                    dataRows.StausIcon =
                        '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="Successfully synced Cir" class="fa fa-check fa-lg" style="color:#3c763d;"></i></a>';
                }
            } else {

                dataRows.CIRCurrentStaus = "Submitted"; //"Initial" changed for 83360
                dataRows.ActionIcons = strDownloadCIR +
                    '<a title="Edit CIR" id="' +
                    item.ComponentInspectionReportId +
                    '" href=javascript:cirDataDiplay.EditCir(3,"' +
                    item.ComponentInspectionReportId +
                    '",' +
                    item.CirDataId +
                    ');  ><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;' +
                    '<a title="Delete CIR" id="' +
                    item.Id +
                    '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History." class="btn-delete ' +
                    RemoveLocalSynCirClassName +
                    '"><i style="color:#cc0000;" class="fa fa-trash-o fa-lg "></i></a>&nbsp;&nbsp;&nbsp;'
                // + '<a title="Delegate CIR" id="' + item.Id + '" value= "' + item.CirDataId + '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                dataRows.StausIcon =
                    '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="Successfully synced Cir" class="fa fa-check fa-lg" style="color:#3c763d;"></i></a>';
            }
            CirLocaldata.push(dataRows);
        }
            // 1 Draft 
            // 2 Submitted 
            // 4 Conflict  
            //7 Locked By Admin
        else {


            if (item.Status == "1") { //1 Draft
                dataRows.CIRCurrentStaus = "Draft";
                if (item.RelatedUserCirDataID && item.RelatedUserCirDataID != "-") {
                    dataRows.ActionIcons = '<a title="Edit CIR" id="' +
                        item.Id +
                        '" href=javascript:cirDataDiplay.EditCir(1,"' +
                        item.Id +
                        '"); ><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;' +
                        '<a title="Return CIR to Owner" id="' +
                        item.Id +
                        '" value= "Do you want to return the CIR to Owner ?" href="javascript:void(0);" class="btn-delegate ' +
                        RevokeDelegateCIRClassName +
                        '"><i style="color:#cc0000;"  class="fa fa-reply-all fa-lg"></i></a>';
                    if ((dataRows.MError == "" || dataRows.MError == null))
                        dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' +
                            item.Remarks +
                            '" value="' +
                            item.StatusDetailMessage +
                            '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#6495ED;cursor:pointer"></i></a>';
                    else
                        dataRows.StausIcon =
                            '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="This Draft CIR has Migration Error to be resolved" value="' +
                            item.MError +
                            '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#cccc00;cursor:pointer"></i></a>';

                } else {

                    if (item.ComponentInspectionReportId == 0) {
                        dataRows.ActionIcons = '<a title="Edit CIR" id="' +
                            item.Id +
                            '" href=javascript:cirDataDiplay.EditCir(1,"' +
                            item.Id +
                            '"); ><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;' +
                            '<a title="Unlock CIR" id="' +
                            item.Id +
                            '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History." class="btn-delete ' +
                            RemoveLocalCirClassName +
                            '"><i style="color:#8a6d3b;" class="fa fa-unlock fa-lg "></i></a>&nbsp;&nbsp;&nbsp;' +
                            '<a title="Delegate CIR" id="' +
                            item.Id +
                            '" value= "' +
                            item.CirDataId +
                            '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                        dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' +
                            item.StatusMessage +
                            '" value="' +
                            item.StatusDetailMessage +
                            '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#FF8C00;cursor:pointer"></i></a>';
                    } else {
                        dataRows.ActionIcons = '<a title="Edit CIR" id="' +
                            item.Id +
                            '" href=javascript:cirDataDiplay.EditCir(1,"' +
                            item.Id +
                            '"); ><i class="fa fa-pencil-square-o fa-lg"></i></a>&nbsp;&nbsp;&nbsp;' +
                            '<a title="Unlock CIR" id="' +
                            item.Id +
                            '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History. This will also Unlock the CIR and make it available to other users." class="btn-delete ' +
                            RemoveLocalCirClassName +
                            '"><i style="color:#8a6d3b;" class="fa fa-unlock fa-lg "></i></a>&nbsp;&nbsp;&nbsp;' +
                            '<a title="Delegate CIR" id="' +
                            item.Id +
                            '" value= "' +
                            item.CirDataId +
                            '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                        if ((dataRows.MError == "" || dataRows.MError == null))
                            dataRows.StausIcon =
                                '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' +
                                item.StatusMessage +
                                '" value="' +
                                item.StatusDetailMessage +
                                '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#FF8C00;cursor:pointer"></i></a>';
                        else
                            dataRows.StausIcon =
                                '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="This Draft CIR has Migration Error to be resolved" value="' +
                                item.MError +
                                '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#cccc00;cursor:pointer"></i></a>';

                    }

                }
            } else if (item.Status == "2") { // 2 Submitted 
                dataRows.CIRCurrentStaus = "Submitted";
                dataRows.ActionIcons = '-'
                dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' +
                    item.StatusMessage +
                    '" value="' +
                    item.StatusDetailMessage +
                    '" class="glyphicon glyphicon-refresh glyphicon-spin fa-sm clickable StatusCir" style="color:#3c763d;"></i></a>';
            } else if (item.Status == "7") { //7 Locked By Admin
                dataRows.CIRCurrentStaus = "CIR Delegated to other User";
                dataRows.ActionIcons = '<a title="Revoke delegated permission" id="' + item.Id + '" value= "Do you want to revoke the delegated permission ?" href="javascript:void(0);" class="btn-revokedelegation ' + RevokeDelegateCIRClassName_Owner + '"><i style="color:#cc0000;"  class="fa fa-user-times fa-lg"></i></a>';
                dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' + item.Remarks + '" style="color:#cc0000;cursor:pointer" class="fa fa-lock fa-lg"></i></a>';
            } else { // 4 Conflict
                dataRows.CIRCurrentStaus = "Conflict";
                if (Offline.state == "down") {
                    if (item.ComponentInspectionReportId == 0) {
                        dataRows.ActionIcons = '<a title="Unlock CIR" id="' +
                            item.Id +
                            '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History." class="btn-delete ' +
                            RemoveLocalCirClassName +
                            '"><i style="color:#8a6d3b;" class="fa fa-unlock fa-lg "></i></a>&nbsp;&nbsp;&nbsp;'
                        //+ '<a title="Delegate CIR" id="' + item.Id + '" value= "' + item.CirDataId + '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                        dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' +
                            'Conflict occurred for this CIR' +
                            '" value="' +
                            item.StatusDetailMessage +
                            '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#cc0000;cursor:pointer"></i></a>';
                    } else {
                        dataRows.ActionIcons = '<a title="Unlock CIR" id="' +
                            item.Id +
                            '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History. This will also Unlock the CIR and make it available to other users." class="btn-delete ' +
                            RemoveLocalCirClassName +
                            '"><i style="color:#8a6d3b;" class="fa fa-unlock fa-lg "></i></a>&nbsp;&nbsp;&nbsp;'
                        // + '<a title="Delegate CIR" id="' + item.Id + '" value= "' + item.CirDataId + '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                        dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' +
                            'Conflict occurred for this CIR' +
                            '" value="' +
                            item.StatusDetailMessage +
                            '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#cc0000;cursor:pointer"></i></a>';
                    }
                } else {

                    dataRows.ActionIcons = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i id=' + item.Id + ' class="fa fa-pencil-square-o fa-lg clickable EditConCir" style="color:#cc0000;"></i></a>&nbsp;&nbsp;&nbsp;' + '<a title="Unlock CIR" id="' + item.Id + '" href="javascript:void(0);" value="Do you wish to delete this CIR from your Local History." class="btn-delete ' + RemoveLocalCirClassName + '"><i style="color:#8a6d3b;" class="fa fa-unlock fa-lg "></i></a>&nbsp;&nbsp;&nbsp;'
                    //   + '<a title="Delegate CIR" id="' + item.Id + '" value= "' + item.CirDataId + '" href="javascript:void(0);" class="btn-delegate DelegateCIR"><i class="fa fa-user-plus fa-lg " style="color:#3c763d;"></i></a>';
                    dataRows.StausIcon = '<a tabindex="0" data-toggle="popover" data-trigger="focus"><i title="' + 'Conflict occurred for this CIR' + '" value="' + item.StatusDetailMessage + '" class="fa fa-exclamation-triangle fa-lg StatusCir" style="color:#cc0000;cursor:pointer"></i></a>';
                }
            }

            CirLocaldata.push(dataRows);
        }
        return CirLocaldata;
    }
    this.EditCir = function (status, id, cirDataId) {
        if (status == 3) {
            if (Offline.state != "down") {

                var cirDataDetail = {
                    cirDataId: cirDataId,
                    cirId: "",
                    cirState: 1,
                    filename: "",
                    componentType: "",
                    cIMCaseNumber: "",
                    reportType: "",
                    turbineType: "",
                    turbineNumber: "",
                    progress: 8,
                    modifiedBy: "",
                    comment: "",
                    locked: 1,
                    lockedBy: ""
                }

                CallClientApi("CirProcess", "POST", cirDataDetail).done(function (result) {
                    var error = result.error;
                    var msg = result.message;
                    if (error == 1) {
                        NotifyCirMessage('Error : ', msg, 'danger');
                        return false;
                    }

                    location.href = "/cir/manage-cir?remotecirID=" + id;
                });


            }
            else {

                // alert("You cannot Edit the Synced CIRs in Offline mode!");
                //  return false;
                CirAlert.alert('You cannot Edit the Synced CIRs in Offline mode!', 'Cir App', null, 'error').done(function () {
                    return false;
                });
            }
        }
        else {
            window.location.href = '/cir/manage-cir#id=' + id + '';

        }
    };


    this.downloadPDF = function (CirId) {

        waitingDialog.show('Downloading PDF..', {
            dialogSize: 'sm', progressType: 'primary'
        });

        CallSyncApi("CirSubmissionData/CirPdfFile?cirId=" + CirId, "PUT", "").done(function (result) {
            waitingDialog.hide();
            if (result) {
                if (result.result.downloadUrl) {
                    var blob = b64toBlob(result.result.downloadUrl, "application/pdf");
                    saveAs(blob, result.result.fileName);
                    var iOS = /iPad|iPhone|iPod/.test(navigator.userAgent) && !window.MSStream;
                    if (iOS) {
                        window.location = "data:application/pdf;base64," + result.result.downloadUrl;
                        openTab("data:application/pdf;base64," + result.result.downloadUrl);
                    }
                }
                else {
                    NotifyCirMessage('Error : ', "Cir PDF has not been generated yet!", 'danger');
                }

            }
            else {
                NotifyCirMessage('Error : ', "Cir PDF loading error", 'danger');
            }
        }).fail(function (e) {
            
        });
    }

    //this.DelegateCIRModal = function (id, cirDataLocalID) {
    //    $("#UserList").empty();
    //    $("#txtUserToSearch").val('');
    //    $("#lblUserToSearch_Validation").empty();
    //    $("#DelegateCIRModal").find('.modal-title').text("Delegate CIR");
    //    //$('input[name="testing"]').val(theValue);
    //    $("#CIRId").val(id);
    //    $("#CirDataLocalID").val(cirDataLocalID);


    //    $("#DelegateCIRModal").modal('show');
    //}
    var that = this;
    this.delegateNewCir = function (id, assignedUserName) {
        var deferred = $.Deferred();
        var delegatedTo = cirOfflineApp.convertUserIdFromPrincipalNameToInitials(assignedUserName);

        CallSyncApi("CirDelegation/DelegateTo?id=" + id + "&delegateTo=" + delegatedTo, "POST").done(
            function (response) {
                var delegatedCir = JSON.parse(response.response);

                cirOfflineApp.UpdateCirDataJson(delegatedCir).done(function () {
                    azureSync.SendMessage(delegatedCir.delegatedTo,
                        'CIR [' + delegatedCir.cirId + '] has been delegated to you by ' + delegatedCir.delegatedBy);
                    azureSync.SendMessage(delegatedCir.delegatedBy,
                        'CIR [' + delegatedCir.cirId + '] has been delegated to ' + delegatedCir.delegatedTo);

                    waitingDialog.hide();

                    CirAlert.alert('This CIR is successfully delegated to [' + delegatedCir.delegatedTo + ']',
                        'Cir App',
                        null,
                        'info').done(function () {
                            $("#DelegateCIRModal").modal('hide');

                            deferred.resolve();
                        });
                });
            });

        return deferred.promise();
    };

    this.RevokeNewCir = function (id) {
        var deferred = $.Deferred();

        CallSyncApi("CirDelegation/RevokeDelegate?id=" + id, "POST").done(function (response) {
            var revokedCir = JSON.parse(response.response);

            cirOfflineApp.GetCirDataJsonById(id).done(function (cir) {
                cirOfflineApp.UpdateCirDataJson(revokedCir).done(function () {
                    azureSync.SendMessage(cir.delegatedBy,
                        'CIR [' + cir.cirId + '], This CIR has been returned from: ' + cir.delegatedTo);
                    azureSync.SendMessage(cir.delegatedTo,
                        'CIR [' + cir.cirId + '], This CIR has been returned to owner: ' + cir.delegatedBy);
                    waitingDialog.hide();
                    CirAlert.alert('This CIR is successfully revoked to [' + cir.delegatedBy + ']', 'Cir App', null, 'info')
                        .done(function () {
                            $("#DelegateCIRModal").modal('hide');

                            deferred.resolve();
                        });
                });
            });
        });

        return deferred.promise();
    };

    var that = this;
    this.DelegateCirData = function (id, assignedUserName, isNew, delegationFinishedCallback) {
        waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        waitingDialog.updateMessage('Syncing Data..', false);

        if (isNew) {
            that.delegateNewCir(id, assignedUserName).done(function () {
                delegationFinishedCallback();
            });
        } else {
            azureSync.StartSyncManual().done(function () {
                var newId = $.grep(azureSync.__LocalServerGuidMapping, function (i) {
                    return (i.LocalGuid == id)
                });
                if (newId[0] != null && newId[0].ServerGuid != undefined && newId[0].ServerGuid != null && newId[0].ServerGuid != "")
                    id = newId[0].ServerGuid;
                setTimeout(function () {
                    waitingDialog.show('Delegating CIR..', { dialogSize: 'sm', progressType: 'primary' });
                }, 1000);
                CallClientApi("DelegateCirData/" + id + "/" + encodeURIComponent(assignedUserName), "POST", '').done(function (result) {
                    if (result) {
                        waitingDialog.updateMessage('Syncing Data..', false);
                        azureSync.StartSyncManual().done(function () {
                            waitingDialog.hide();
                            CirAlert.alert('This CIR is successfully delegated to [' + assignedUserName + ']', 'Cir App', null, 'info').done(function () {
                                $("#DelegateCIRModal").modal('hide');
                            });
                        }).fail(function () {
                            waitingDialog.hide();
                            CirAlert.alert('This CIR is successfully delegated to [' + assignedUserName + ']' + ', Error while syncing data', 'Cir App', null, 'error').done(function () {
                                $("#DelegateCIRModal").modal('hide');
                            });
                        });
                    }
                    else {
                        waitingDialog.hide();
                        CirAlert.alert('Error while delegating the CIR !', 'Cir App', null, 'error').done(function () {

                        });
                        return false;
                    }
                }).fail(function (error) {
                    waitingDialog.hide();

                    var err = "Error while deligating the CIR"
                    if (error.request.status == 403)
                        err = "You need permission to access data for other user";
                    else if (error.request.status == 406)
                        err = "<html><body> “Warning” -The CIR has <font color='red'><b> not </b></font>been delegated as the user has already 5 CIRs in “Draft mode” </body></html>";
                    CirAlert.alert(err, 'Cir App', null, 'error').done(function () {
                        waitingDialog.hide();
                        $("#DelegateCIRModal").modal('hide');
                    });
                    return false;
                });
            }).fail(function () {
                waitingDialog.hide();
                CirAlert.alert('Error while syncing data, unable to delegate', 'Cir App', null, 'error').done(function () {

                });
            });
        }
    }

    this.RevokeDelegatedPermission = function (id, IsDelegatedCIRDataRequired, isDelegate, isNew, revokeFinishedCallback) {
        if (isDelegate == undefined || isDelegate == null)
            isDelegate = false;
        if (isNew == undefined || isNew == null)
            isNew = false;

        var msg = 'Delegated permission revoked successfully for this CIR';
        if (isDelegate) {
            msg = 'CIR retured to the owner successfully';
        }
        if (isNew) {
            that.RevokeNewCir(id).done(function () {
                revokeFinishedCallback();
            });
        } else {
            waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
            CallClientApi("ChangeCirDelegation/" + id + "/" + IsDelegatedCIRDataRequired, "POST", '').done(function (result) {
                if (result) {
                    waitingDialog.updateMessage('Syncing Data..', false);
                    azureSync.StartSyncManual().done(function () {
                        waitingDialog.hide();
                        CirAlert.alert(msg, 'Cir App', null, 'info').done(function () {

                        });
                    }).fail(function () {
                        waitingDialog.hide();
                        CirAlert.alert(msg + ', Error while syncing data', 'Cir App', null, 'error').done(function () {

                        });
                    });
                }
                else {
                    waitingDialog.hide();
                    CirAlert.alert('Error while revoking delegated permission for this CIR !', 'Cir App', null, 'error').done(function () {
                        return false;
                    });
                }

            }).fail(function (error) {
                waitingDialog.hide();
                CirAlert.alert('Error while revoking delegated permission for this CIR ! - ' + error, 'Cir App', null, 'error').done(function () {
                    return false;
                });
            });
        }
    }

    this.SearchUsers_LHistory = function (keyword, appUrl, appID) {
        //waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        $("#btnUserSearch_LHistory").text("Please Wait..");
        var client = new WindowsAzure.MobileServiceClient(appUrl, appID, ''); // Azure auth
        $("#UserList").empty();
        $("#lblUserToSearch_Validation").empty();
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser) {
                if (currentuser.length > 0) {
                    currentuser.forEach(function (item) {
                        client.currentUser = item.objet;
                    });
                    if (client.currentUser) {
                        client.invokeApi('GetAssignedUser/' + keyword, {
                            method: 'GET'//,
                            //parameters: { userSearchKeywrod: keyword }
                        }).done(function (response) {
                            var resp = response.result;
                            var Users = resp;
                            console.log(resp);


                            if (Users.length == 0) {
                                console.log("No users found");
                                $("#lblUserToSearch_Validation").text("User is not valid or does not exist");
                            }
                            else {
                                for (var i = 0; i < Users.length; i++) {
                                    $("#UserList").append("<option value=" + Users[i].internalUPN + ">" +
                                        Users[i].extName + "</option>");
                                }
                            }
                            $("#btnUserSearch_LHistory").text("Search");
                            return resp;
                        }, function (error) {
                            NotifyCirMessage(' ', "You do not have valid permission to search User", 'danger');
                            $("#btnUserSearch_LHistory").text("Search");
                        });
                    }
                }
            }
        });
        waitingDialog.hide();
    }

    this.SearchUsers_LSearch = function (keyword, appUrl, appID) {
        //waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        $("#btnUserSearch_LSearch").text("Please Wait..");
        var client = new WindowsAzure.MobileServiceClient(appUrl, appID, ''); // Azure auth
        $("#UserList").empty();
        $("#lblUserToSearch_Validation").empty();
        dbtransaction.getItemfromTable('CurrentUser', function CurrentUser(currentuser) {
            if (currentuser) {
                if (currentuser.length > 0) {
                    currentuser.forEach(function (item) {
                        client.currentUser = item.objet;
                    });
                    if (client.currentUser) {
                        client.invokeApi('GetAssignedUser/' + keyword, {
                            method: 'GET'//,
                            //parameters: { userSearchKeywrod: keyword }
                        }).done(function (response) {
                            var resp = response.result;
                            var Users = resp;
                            console.log(resp);


                            if (Users.length == 0) {
                                console.log("No users found");
                                $("#lblUserToSearch_Validation").text("User is not valid or does not exist");
                            }
                            else {
                                for (var i = 0; i < Users.length; i++) {
                                    $("#UserList").append("<option value=" + Users[i].internalUPN + ">" +
                                        Users[i].extName + "</option>");
                                }
                            }
                            $("#btnUserSearch_LSearch").text("Search");
                            return resp;
                        }, function (error) {
                            NotifyCirMessage(' ', "You do not have valid permission to search User", 'danger');
                            $("#btnUserSearch_LSearch").text("Search");
                        });
                    }
                }
            }
        });
        waitingDialog.hide();
    }
};