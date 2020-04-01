<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DemoSwipeToDel.aspx.cs" Inherits="Cir.WebApp.Offline.DemoSwipeToDel" %>

<!DOCTYPE html>

<html>
  <head runat="server">
<meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
  <script src="//code.jquery.com/jquery-1.10.2.js"></script>
  <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>



      
      

       <script>
           $(document).ready(function () {
               $("#txtCommisioningDate").datepicker({
                   dateFormat: 'mm-dd-yy',
                   onClose: function (selectedDate) {
                       $("#txtInstallationDate").datepicker("option", "minDate", selectedDate);
                       $("#txtFailureDate").datepicker("option", "minDate", selectedDate);
                   }
               });
               $("#txtCommisioningDate").tooltip({
                   content: "Awesome title!"
               });
               $("#txtFailureDate").datepicker({
                   dateFormat: 'mm-dd-yy',
                   onClose: function (selectedDate) {
                       $("#txtCommisioningDate").datepicker("option", "maxDate", selectedDate);
                       $("#txtInspectionDate").datepicker("option", "minDate", selectedDate);
                       alert('Failure Date should be greater than Commission Date and less than Inspection Date.');
                   }
               });
               $("#txtInspectionDate").datepicker({
                   dateFormat: 'mm-dd-yy',
                   onClose: function (selectedDate) {
                       $("#txtFailureDate").datepicker("option", "maxDate", selectedDate);
                       alert('Inspection Date should be greater than Failure Date.');
                   }
               });
               $("#txtInstallationDate").datepicker({
                   dateFormat: 'mm-dd-yy',
                   onClose: function (selectedDate) {
                       $("#txtCommisioningDate").datepicker("option", "maxDate", selectedDate);
                       alert('Installation Date should be greater than Commission Date.');
                   }
               });
           });
        </script>
  </head>
  <body>
<div data-role="page">
    <div data-role="header" data-position="fixed">
         <h1>Header</h1>

    </div>



    
    <div class="form-group">
        <label class="col-lg-3 control-label">Commissioning date<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtCommisioningDate" placeholder="Commissioning date"   readonly="readonly"  maxlength="10" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Installation date<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtInstallationDate" placeholder="Installation date" readonly="readonly" maxlength="10" class="form-control" />
        </div>
    </div>



    <div class="form-group">
        <label class="col-lg-3 control-label">Failure date<span class="errorSpan">*</span> </label>
        <div class="col-lg-9">
            <input type="text" id="txtFailureDate" placeholder="Failure date"  readonly="readonly"  maxlength="10" class="form-control" />
        </div>
    </div>

    <div class="form-group">
        <label class="col-lg-3 control-label">Inspection Date<span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <input type="text" id="txtInspectionDate" placeholder="Inspection Date"  readonly="readonly"  maxlength="10" class="form-control" />
        </div>
    </div>


</div>
    </body>
  </html>