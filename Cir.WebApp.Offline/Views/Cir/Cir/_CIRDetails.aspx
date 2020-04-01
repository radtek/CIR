<html>
<head runat="server">
    <title>CIR Details</title>
    <meta charset="UTF-8" />
    <link href="../Css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
 
    <style type="text/css">
        div.alert-messages {
            position: fixed;
            top: 50px;
            left: 25%;
            right: 25%;
            z-index: 7000;
        }
    </style>
</head>
<body>

    <div class="row" id="CirDetailsSection">
        <div class="col-xs-12">
            <table role="main" id="CirDataDetail" class="tablesaw">
                <thead>
                    <tr>
                        <th colspan="4" scope="col" style="text-align: center">Details of CIR ID : <b><span id="spancirId"></span></b></th>
                    </tr>
                </thead>
            </table>

        </div>
    </div>
    <br />
    <input type="hidden" id="_hCirID" />
    <input type="hidden" id="_hCirDataID" />
    <input type="hidden" id="_hComponentType" />
    <input type="hidden" id="_isFormioCir"/>
    <input type="hidden" id="hdnCirId" value="<%= System.Configuration.ConfigurationManager.AppSettings("hdnCirId") %>" />
    <div class="row" id="CirAttachmentSection">

        <div class="col-xs-12 navbar-left navbar-SubHead">
            &nbsp;Attachments
        </div>
        <div class="col-xs-12">
            <table id="CirAttachments" class="tablesaw">
                <thead>
                    <tr>
                        <th>Action</th>
                        <th>CIR ID</th>
                        <th>File Name</th>
                        <th>Created By</th>
                        <th>Created Date</th>
                    </tr>
                </thead>
            </table>
        </div>

         <div class="col-xs-12">&nbsp;</div>
        <div class="col-xs-12">
            <input type="file" name="documentattachment" id="documentattachment" size="chars">
        </div>
        <div class="col-xs-12 text-left">
            <input type="submit" class="btn btn-sm btn-primary" id="uploaddocument" onclick="CirDetails.UploadAttachment()" value="Upload Document" />

        </div>
    </div>

    <br />
    <div class="col-xs-12"></div>
    <div class="row" id="CirCommentsSection">

        <div class="col-xs-12 navbar-left navbar-SubHead">
            &nbsp;Comments
        </div>
        <div class="col-xs-12">

            <table id="CirCommentHistory" class="tablesaw">
                <thead>
                    <tr>

                        <th data-class="expand" scope="col" data-sort-initial="true">Author</th>
                        <th data-hide="phone" scope="col">Date</th>
                        <th data-hide="phone" scope="col">Comment</th>
                    </tr>
                </thead>
            </table>
        </div>
        <div class="col-xs-12">
            <br />
        </div>
        <div class="col-xs-8">
            <textarea id="txtComment" placeholder="Comment" data-toggle="tooltip"
                data-placement="top" title="Enter Comment" class="form-control" cols="80" rows="5"></textarea>
        </div>
        <div class="col-xs-4">
            <input type="submit" onclick="SaveComment()" class="btn  btn-sm btn-primary" value="Add Comment" />

        </div>
    </div>


    <div class="col-xs-12"></div>
    <div class="row" id="CirRevisionSection">

        <div class="col-xs-12 navbar-left navbar-SubHead">
            &nbsp;Revision
        </div>
        <div class="col-xs-12">
            <table id="CirRevision" class="tablesaw">
                <thead>
                    <tr>
                        <th>Action</th>
                        <th>Edited On</th>
                        <th>Edited By</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>
    <br />

    <div class="col-xs-12"></div>
    <div class="row" id="CirUploadOEMSection" style="display:hide">

        <div class="col-xs-12 navbar-left navbar-SubHead">
            &nbsp;Upload Defect Categorization File
        </div>
        <div class="col-xs-12">
            <input type="file" name="DefectFileUpload" id="defectfileupload" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet,application/vnd.ms-excel.sheet.macroEnabled.12,application/vnd.ms-excel" size="chars">
        </div>
        <div class="col-xs-12 text-left">
            <input type="submit" class="btn  btn-sm btn-primary" id="btnuploaddefectdocument" onclick="CirDetails.UploadDefectAttachment()" value="Upload" />

        </div>
    </div>

</body>
</html>

