var CirSystemlog = new function () {   

    this.loadCirSystemlog = function (CurrentPageNo) {

        var LogType = $('#LogType').val();
        var ObjLog = {};
        ObjLog.type = parseInt(LogType);
        ObjLog.sortColumnIndex = 0;
        ObjLog.sortDirection = 1;
        ObjLog.currentPageNumber = CurrentPageNo;
        ObjLog.totalRecordCount = 0;
        ObjLog.recordsPerPage = 10;
        ObjLog.logFromDate = $('#txtFromDate').val();
        ObjLog.logToDate = $('#txtToDate').val();

        var currentPageNumber = 0;
        var sortColumnIndex = 0;
        var sortDirection = 0;
        var recordsPerPage = 0;
        var totallRecordCount = 0;

        //var client = new WindowsAzure.MobileServiceClient($('#MobAppURL').val(), $('#MobAppID').val(), ''); // Azure auth

        //var LogType = $('#LogType option:selected').text();
       
        CallClientApi("GetCirSyncLog", "POST", ObjLog).done(function (result) {
            resultdata = [];
            if (result) {
                if (result.data != undefined && result.data !== '') {

                    currentPageNumber = result.currentPageNumber;
                    sortColumnIndex = result.sortColumnIndex;
                    sortDirection = result.sortDirection;
                    recordsPerPage = result.recordsPerPage;
                    totallRecordCount = result.totalRecordCount;

                    $("#page-selection1").empty();
                    $("#page-selection2").empty();

                    var ordertext = "ascending";
                    ordertext = (result.sortDirection == 1) ? "ascending" : "descending";

                    var startNumber = (parseInt((result.currentPageNumber - 1) * result.recordsPerPage) + 1);
                    var lastNumber = (result.currentPageNumber * result.recordsPerPage);
                    if (lastNumber > totallRecordCount)
                        lastNumber = totallRecordCount;

                    $('#lblTotalRecords').text('Showing ' + startNumber + ' to ' + lastNumber + ' of ' + totallRecordCount + ' entries');
                    $('.page-selection').bootpag({
                        total: parseInt(totallRecordCount / result.recordsPerPage) + 1,
                        page: result.currentPageNumber,
                        maxVisible: 5,
                        leaps: true,
                        firstLastUse: true,
                        first: '←',
                        last: '→',
                        wrapClass: 'pagination',
                        activeClass: 'active',
                        disabledClass: 'disabled',
                        nextClass: 'next',
                        prevClass: 'prev',
                        lastClass: 'last',
                        firstClass: 'first'
                    });
                    
                    resultdata = null;
                    resultdata = JSON.parse(result.data);
                    if (resultdata != null) {

                        var tblSystemLogGrid = $('#SystemLogGrid').DataTable({
                            destroy: true,
                            order: [[1, "desc"]],
                            searching: false,
                            paging: false,
                            info: false
                        });
                        tblSystemLogGrid.clear().draw();
                        var showChar = 100; 
                        $.each(resultdata, function (i, item) {
                            //t.row.add([ActionString, Status, item.ComponentInspectionReportId, item.ComponentInspectionReportName, item.CimCaseNumber, item.TurbineType, item.TurbineNumber, item.SiteName, item.CreatedDate]).draw(false);;
                            tblSystemLogGrid.row.add([item.CirSyncLogId, item.Type, item.Message,
                            ((item.Details.length > 100) ? '<span>' + item.Details.substr(0, showChar) + '...</span><span onclick="showdetails(this)" style="cursor:pointer; color:blue; text-decoration:underline;">Show details</span>' + '<span style= "display:none">' + item.Details + '</span>' : item.Details), item.Timestamp]).draw(false);
                        });
                    }
                    waitingDialog.hide();
                }
                else {
                    $("#page-selection1").empty();
                    $("#page-selection2").empty();
                    $('#lblTotalRecords').text('');
                }
            }
        });

       
    };


    function SortGrid(key) {
        if (key == sortColumnIndex)
            sortDirection = (sortDirection == 1) ? 2 : 1;
        else
            sortDirection = 2;
        sortColumnIndex = key;
        waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        CirSystemlog.loadCirSystemlog(num);
    }
};


function showdetails(e) {
    //$("#span1").hide();
    $(e).prev().hide();
    $(e).hide();
    $(e).next().show();
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
        
        CirSystemlog.loadCirSystemlog(1);
    });
    
    $("#txtFromDate,#txtToDate").datepicker({
        dateFormat: 'dd-mm-yy',
        changeMonth: true,
        changeYear: true,
    });

    //$("#LogType").change(function () {
    //    $('#SystemLogGrid').html("");
    //    waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
    //    CirSystemlog.loadCirSystemlog(1);
        
    //});

    $("#linkGetCirLog").click(function () {
        $('#SystemLogGrid').html("");
        waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        CirSystemlog.loadCirSystemlog(1);

    });

    $('#page-selection1').on("page", function (event, num) {
        //currentPageNumber = num;
        $('#SystemLogGrid').html("");
        waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        CirSystemlog.loadCirSystemlog(num);
    });
    $('#page-selection2').on("page", function (event, num) {
        $('#SystemLogGrid').html("");
        waitingDialog.show('Please Wait..', { dialogSize: 'sm', progressType: 'primary' });
        //currentPageNumber = num;
        CirSystemlog.loadCirSystemlog(num);
    });
});