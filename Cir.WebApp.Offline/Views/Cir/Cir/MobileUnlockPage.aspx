<!DOCTYPE html>
<%--<html manifest="/Manifest.txt">--%>
<html>
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta content="yes" name="apple-mobile-web-app-capable">
    <meta name="format-detection" content="telephone=no">
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <title>Pin</title>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="../Css/bootstrap.min.css">
    <script src="../Js/encryption/sjcl.js"></script>
    <script src="../Js/jquery.min.js"></script>
    <script src="../Js/ApplicationScripts/indexeddb.shim.min.js"></script>
    <script src="../Js/ApplicationScripts/offlineTransactions.js"></script>

    <!-- Latest compiled and minified JavaScript -->
    <script src="../Js/bootstrap.min.js"></script>
    <script src="../Js/ApplicationScripts/MobileUnlock.js"></script>
    <link rel="stylesheet" href="../Css/MobileUnlock.css">
</head>
<body>
    <div id="wrapper">
        <input type="hidden" id="hdnUserPin" />
        <input type="hidden" id="hdnSetPin" />
        <input type="hidden" id="hdnConfirmPin" />
        <input type="hidden" id="hdnPinType" />
        <input type="hidden" id="hdnExistingPin" />
        <div id="TopHead" class="navbar">
            <h2></h2>
        </div>
        <div id="DivEnterPass" class='text-center'>
            <h4>Enter Passcode</h4>
        </div>
        <div class='text-center'>
            <div class='col-xs-12'>
                <div id="small-circle1" class='small-circle a1'></div>
                <div id="small-circle2" class='small-circle a2'></div>
                <div id="small-circle3" class='small-circle a3'></div>
                <div id="small-circle4" class='small-circle a4'></div>
            </div>
            <div class='col-xs-4'>
                <div class='main num hover' data-number="1"></div>
            </div>
            <div class='col-xs-4'>
                <div class='main num hover' data-number="2"></div>
            </div>
            <div class='col-xs-4'>
                <div class='main num hover' data-number="3"></div>
            </div>
            <div class='col-xs-4'>
                <div class='main num hover' data-number="4"></div>
            </div>
            <div class='col-xs-4'>
                <div class='main num hover' data-number="5"></div>
            </div>
            <div class='col-xs-4'>
                <div class='main num hover' data-number="6"></div>
            </div>
            <div class='col-xs-4'>
                <div class='main num hover' data-number="7"></div>
            </div>
            <div class='col-xs-4'>
                <div class='main num hover' data-number="8"></div>
            </div>
            <div class='col-xs-4'>
                <div class='main num hover' data-number="9"></div>
            </div>
            <div class='clearfix'></div>

            <div class='col-xs-4'>
            </div>
            <div class='col-xs-4'>
                <div class='bottom_main num hover' data-number="0"></div>
            </div>
            <div class='col-xs-4' title="Clear">
                <div title="Clear" class='numback hover'><span class="glyphicon glyphicon-arrow-left"></span></div>
            </div>


        </div>

    </div>

</body>
</html>
