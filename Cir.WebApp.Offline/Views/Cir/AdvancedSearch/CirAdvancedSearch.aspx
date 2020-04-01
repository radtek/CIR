<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= System.Configuration.ConfigurationManager.AppSettings["ApplicationName"] %>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
   <link href="../Css/footable.core.css" rel="stylesheet" type="text/css" />
    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <link href="../Css/jQueryUI/jquery.ui.accordion.css" rel="stylesheet" />

      <link href="../Css/chosenslectionList/style.css" rel="stylesheet" />
    <link href="../Css/chosenslectionList/prism.css" rel="stylesheet" />
    <link href="../Css/chosenslectionList/chosen.css" rel="stylesheet" />
     <script src="../Js/chosenslectionlist/chosen.jquery.js" type="text/javascript"></script>
  <script src="../Js/chosenslectionlist/prism.js" type="text/javascript" charset="utf-8"></script>
    <script src="../Js/ApplicationScripts/CirAdvancedSearch.js"></script>
    <script src="../Js/footable.all.min.js"></script>  
     <script src="../Js/footable.sort.min.js"></script>  

    <script src="../Js/jquery.ui.accordion.js"></script>
  
    <script>

    </script>
    <style>
        .chosen-rtl .chosen-drop { left: -9000px; }

        #cirAdvancedSearchResult th{
            background-color: rgb(0, 114, 187) !important;
            color: white !important;
        }
    </style>
    <section class="content" style="background: transparent">
        <input type="hidden" id="cirLocalID" />
         <input type="hidden" id="cirRemoteID" />
        <%--<input type="hidden" id="hdntemplateVersion" value="7" />--%>
       <input type="hidden" id="hdntemplateVersion" value="8" />
        <form class="form" id="FrmAdvancedSearch">
        <div class="row">
            <div class="col-xs-12">
                <div class="well well-White" id="UsePDF">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="navbar-left navbar-SubHead">
                                 <div id="cirlbl">CIR Advanced Search</div>
                            </div>
                        </div>
                    </div>
                    <div>
                        <div class="bs-example form-horizontal">
                            <div id="cirTemplates" class="persist-area" style="display: block;">
                                <%--<div class="cirTemplateSection">--%>
                                <h3 id="cirTemplateLink"><a href="javascript:void(0);">Search Options</a> <span class="fa fa-file-o" style="float: right">&nbsp;</span></h3>

                                <div id="cirTemplateSection" class="SearchOption" style="background: transparent">
                                    <div class="form-group">
                                    <label class="col-lg-3 control-label">Search Option</label>
                                        
                                        <div class="col-md-9">
                                            <input name="radio" type='hidden' value="rdManual" />
                                            <div class="btn-group rd-block" data-toggle="buttons" autocomplete="off">
                                                <div class="rd-overlay-option-Advance">or</div>
                                                <button type="button" class="btn btn-default active" data-radio-name="radio"         aria- aria-autocomplete ="off" id="rdManual">Manual</button>
                                                <button type="button" class="btn btn-default" autocomplete="off" id="rdProfile" data-radio-name="radio">Profile Based</button>
                                            </div>
                                        </div>
                                    </div>
                                   <%-- <div class="form-group">
                                        <label class="col-lg-3 control-label" id="lblTemplate1">
                                            Search Type 
                                        </label>
                                        <div class="col-lg-9">
                                            <select id="ddlCirSearchType" class="form-control">
                                            <option value="Blade">Blade</option>
                                            <option value="Gearbox">Gearbox</option>
                                            <option value="General">General</option>
                                            <option value="Generator">Generator</option>
                                            <option value="Transformer">Transformer</option>
                                            <option value="MainBearing">Main Bearing</option>
                                            <option value="Skiipack">Skiipack</option>
                                            <option value="BIR">BIR</option>
                                            </select>

                                        </div>
                                    </div>--%>

                                <div class="form-group">
                                    <label class="col-lg-3 control-label" id="lblTemplate">
                                        Search For 
                                    </label>
                                    <div class="col-lg-9">
                                      <%--  <select id="ExcludeCIMCase"   data-placeholder="Select  CIMCASE" style="width:350px;" multiple class="chosen-select" >--%>
                                        <select id="ExcludeCIMCase" class="form-control" >
                                            <option selected="selected" value="0">All CIRs (approved SBU-owned CIRs with CIM case -1 and CIRs related to CIM cases)</option>
                                            <option value="1">SBU CIRs (only approved SBU-owned CIRs with CIM case -1)</option>
                                            <option value="2">CIM CIRs (only approved CIRs related to CIM cases)</option>
                                            <option value="4">All Unapproved CIRs</option>
                                            <option value="5">All CIRs (approved and unapproved)</option>
                                        </select>
                                    </div>
                                </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label" id="lblColumList">
                                    Select Columns for Result 
                                </label>
                                <div class="col-lg-9">
                                     <select id="CIRColumnsInResultList"   style="width:350px;" multiple class="chosen-select" >
                                    <%--<select id="CIRColumnsInResultList"  style="width:350px;" multiple class="chosen-select">--%>
                                    <%--<select id="CIRColumnsInResultList" class="form-control" multiple="multiple">--%>
                                        <option value=""></option>
                                        <option selected="selected" value="CIR ID">CIR ID</option>
                                        <option selected="selected" value="Component Type">Component Type</option>
                                        <option selected="selected" value="Report Type">Report Type</option>     
                                        <option selected="selected" value="Failure Date">Failure Date</option>
                                        <option selected="selected" value="CIM Case Number">CIM Case Number</option>
                                        <option selected="selected" value="Turbine Number">Turbine Number</option>
                                        <option selected="selected" value="Country">Country</option>                                    
                                        <option selected="selected" value="Brand">Brand</option>
                                        <option selected="selected" value="Site Name">Site Name</option>
                                        <option selected="selected" value="Turbine Type">Turbine Type</option>
                                        <option value="Reconstruction">Reconstruction</option>
                                        <option value="Reason For Service">Reason For Service</option>
                                        <option value="Local Turbine Id">Local Turbine Id</option>
                                        <option value="Second Generator">Second Generator</option>
                                        <option value="Run Status Before Inspection">Run Status Before Inspection</option>
                                        <option value="Commissioning Date">Commissioning Date</option>
                                        <option value="Installation Date">Installation Date</option>
                                        <option value="Inspection Date">Inspection Date</option>
                                        <option value="Service Report Number">Service Report Number</option>
                                        <option value="Service Report Number Type">Service Report Number Type</option>
                                        <option value="Notification Number">Notification Number</option>
                                        <option value="Service Engineer">Service Engineer</option>
                                        <option value="Run Hours">Run Hours</option>
                                        <option value="Generator 1 Hours">Generator 1 Hours</option>
                                        <option value="Generator 2 Hours">Generator 2 Hours</option>
                                        <option value="Total Production (kWh)">Total Production (kWh)</option>
                                        <option value="Run Status After Inspection">Run Status After Inspection</option>
                                        <option value="Vestas Item No.">Vestas Item No.</option>
                                        <option value="Quan. Failed Comp.">Quan. Failed Comp.</option>
                                        <option value="Alarm Log Number">Alarm Log Number</option>
                                        <option value="Description">Description</option>
                                        <option value="Desc. Of Conseq. Prob./Dam.">Desc. Of Consquential Prob./Dam.</option>
                                        <option value="Conducted By">Conducted By</option>
                                        <option value="Aux. Equipment">Aux. Equipment</option>
                                        <option value="Blade Length (m)">Blade Length (m)</option>
                                        <option value="Blade Color">Blade Color</option>
                                        <option value="Blade Serial No.">Blade Serial No.</option>
                                        <option value="Blade Pictures Included">Blade Pictures Included</option>
                                        <option value="Other Blades In Set">Other Blades In Set</option>
                                        <option value="Blade Damage Identified">Blade Damage Identified</option>
                                        <option value="Blade Damage Placement">Blade Damage Placement</option>
                                        <option value="Blade Damage Type">Blade Damage Type</option>
                                        <option value="Blade Radius (m)">Blade Radius (m)</option>
                                        <option value="Blade Edge">Blade Edge</option>
                                        <option value="Blade Description">Blade Description</option>
                                        <option value="Blade Fault Code Class">Blade Fault Code Class</option>
                                        <option value="Blade Fault Code Cause">Blade Fault Code Cause</option>
                                        <option value="Blade Fault Code Type">Blade Fault Code Type</option>
                                        <option value="Blade Fault Code Area">Blade Fault Code Area</option>
                                        <option value="Blade Light. Sys. VT Number">Blade Light. Sys. VT Number</option>
                                        <option value="Blade Light. Sys. Calibration Date">Blade Light. Sys. Calibration Date</option>
                                        <option value="Blade Light. Sys. Leeward Pre-rep. Tip">Blade Light. Sys. Leeward Pre-rep. Tip</option>
                                        <option value="Blade Light. Sys. Leeward Post-rep. Tip">Blade Light. Sys. Leeward Post-rep. Tip</option>
                                        <option value="Blade Light. Sys. Leeward Pre-rep. 2">Blade Light. Sys. Leeward Pre-rep. 2</option>
                                        <option value="Blade Light. Sys. Leeward Post-rep. 2">Blade Light. Sys. Leeward Post-rep. 2</option>
                                        <option value="Blade Light. Sys. Leeward Pre-rep. 3">Blade Light. Sys. Leeward Pre-rep. 3</option>
                                        <option value="Blade Light. Sys. Leeward Post-rep. 3">Blade Light. Sys. Leeward Post-rep. 3</option>
                                        <option value="Blade Light. Sys. Leeward Pre-rep. 4">Blade Light. Sys. Leeward Pre-rep. 4</option>
                                        <option value="Blade Light. Sys. Leeward Post-rep. 4">Blade Light. Sys. Leeward Post-rep. 4</option>
                                        <option value="Blade Light. Sys. Leeward Pre-rep. 5">Blade Light. Sys. Leeward Pre-rep. 5</option>
                                        <option value="Blade Light. Sys. Leeward Post-rep. 5">Blade Light. Sys. Leeward Post-rep. 5</option>
                                        <option value="Blade Light. Sys. Windward Pre-rep. Tip">Blade Light. Sys. Windward Pre-rep. Tip</option>
                                        <option value="Blade Light. Sys. Windward Post-rep. Tip">Blade Light. Sys. Windward Post-rep. Tip</option>
                                        <option value="Blade Light. Sys. Windward Pre-rep. 2">Blade Light. Sys. Windward Pre-rep. 2</option>
                                        <option value="Blade Light. Sys. Windward Post-rep. 2">Blade Light. Sys. Windward Post-rep. 2</option>
                                        <option value="Blade Light. Sys. Windward Pre-rep. 3">Blade Light. Sys. Windward Pre-rep. 3</option>
                                        <option value="Blade Light. Sys. Windward Post-rep. 3">Blade Light. Sys. Windward Post-rep. 3</option>
                                        <option value="Blade Light. Sys. Windward Pre-rep. 4">Blade Light. Sys. Windward Pre-rep. 4</option>
                                        <option value="Blade Light. Sys. Windward Post-rep. 4">Blade Light. Sys. Windward Post-rep. 4</option>
                                        <option value="Blade Light. Sys. Windward Pre-rep. 5">Blade Light. Sys. Windward Pre-rep. 5</option>
                                        <option value="Blade Light. Sys. Windward Post-rep. 5">Blade Light. Sys. Windward Post-rep. 5</option>
                                        <option value="Blade Rep. Rec. Ambient Temp.">Blade Rep. Rec. Ambient Temp.</option>
                                        <option value="Blade Rep. Rec. Humidity">Blade Rep. Rec. Humidity</option>
                                        <option value="Blade Rep. Rec. Add. Document Reference">Blade Rep. Rec. Add. Document Reference</option>
                                        <option value="Blade Rep. Rec. Resin Type">Blade Rep. Rec. Resin Type</option>
                                        <option value="Blade Rep. Rec. Resin Type Batch No.">Blade Rep. Rec. Resin Type Batch No.</option>
                                        <option value="Blade Rep. Rec. Resin Type Expiry Date">Blade Rep. Rec. Resin Type Expiry Date</option>
                                        <option value="Blade Rep. Rec. Hard. Type">Blade Rep. Rec. Hard. Type</option>
                                        <option value="Blade Rep. Rec. Hard. Type Batch No.">Blade Rep. Rec. Hard. Type Batch No.</option>
                                        <option value="Blade Rep. Rec. Hard. Type Expiry Date">Blade Rep. Rec. Hard. Type Expiry Date</option>
                                        <option value="Blade Rep. Rec. Glass Supp.">Blade Rep. Rec. Glass Supp.</option>
                                        <option value="Blade Rep. Rec. Glass Supp. Batch No.">Blade Rep. Rec. Glass Supp. Batch No.</option>
                                        <option value="Blade Rep. Rec. Min. Surf. Temp/Lam.">Blade Rep. Rec. Min. Surf. Temp/Lam.</option>
                                        <option value="Blade Rep. Rec. Max. Surf. Temp/Lam.">Blade Rep. Rec. Max. Surf. Temp/Lam.</option>
                                        <option value="Blade Rep. Rec. Quantity Mixed Resin">Blade Rep. Rec. Quantity Mixed Resin</option>
                                        <option value="Blade Rep. Rec. Min. Post Cure Surf. Temp">Blade Rep. Rec. Min. Post Cure Surf. Temp</option>
                                        <option value="Blade Rep. Rec. Max. Post Cure Surf. Temp">Blade Rep. Rec. Max. Post Cure Surf. Temp</option>
                                        <option value="Blade Rep. Rec. Heaters Etc. Off">Blade Rep. Rec. Heaters Etc. Off</option>
                                        <option value="Blade Rep. Rec. Total Cure Time">Blade Rep. Rec. Total Cure Time</option>
                                        <option value="Gear Type">Gear Type</option>
                                        <option value="Other Gear Type">Other Gear Type</option>
                                        <option value="Gear Revision">Gear Revision</option>
                                        <option value="Gear Manufacturer">Gear Manufacturer</option>
                                        <option value="Gear Other Manufacturer">Gear Other Manufacturer</option>
                                        <option value="Gear Serial Number">Gear Serial Number</option>
                                        <option value="Gear Oil Type">Gear Oil Type</option>
                                        <option value="Gear Mechanical Oil Pump">Gear Mechanical Oil Pump</option>
                                        <option value="Gear Oil Level">Gear Oil Level</option>
                                        <option value="Gear Production">Gear Production</option>
                                        <option value="Gear Generator Manufacturer">Gear Generator Manufacturer</option>
                                        <option value="Gear Second Generator Manufacturer">Gear Second Generator Manufacturer</option>
                                        <option value="Gear Electrical Pump">Gear Electrical Pump</option>
                                        <option value="Gear Shrink Element">Gear Shrink Element</option>
                                        <option value="Gear Shrink Element Serial Number">Gear Shrink Element Serial Number</option>
                                        <option value="Gear Coupling">Gear Coupling</option>
                                        <option value="Gear Filter Block Type">Gear Filter Block Type</option>
                                        <option value="Gear In Line Filter">Gear In Line Filter</option>
                                        <option value="Gear Off Line Filter">Gear Off Line Filter</option>
                                        <option value="Gear Software Release">Gear Software Release</option>
                                        <option value="Gear Shaft Location">Gear Shaft Location</option>
                                        <option value="Gear Shaft Damage Type">Gear Shaft Damage Type</option>
                                        <option value="Gear Location">Gear Location</option>
                                        <option value="Gear Damage Type">Gear Damage Type</option>
                                        <option value="Gear Bearing Location">Gear Bearing Location</option>
                                        <option value="Gear Bearing Position">Gear Bearing Position</option>
                                        <option value="Gear Bearing Damage Type">Gear Bearing Damage Type</option>
                                        <option value="Gear Housing Planet Stage 1">Gear Housing Planet Stage 1</option>
                                        <option value="Gear Housing Planet Stage 2">Gear Housing Planet Stage 2</option>
                                        <option value="Gear Housing Stage">Gear Housing Stage</option>
                                        <option value="Gear Housing Front Plate">Gear Housing Front Plate</option>
                                        <option value="Gear Housing Auxilary Stage">Gear Housing Auxilary Stage</option>
                                        <option value="Gear Housing HS Stage">Gear Housing HS Stage</option>
                                        <option value="Gear Torque Loose Bolts">Gear Torque Loose Bolts</option>
                                        <option value="Gear Torque Broken Bolts">Gear Torque Broken Bolts</option>
                                        <option value="Gear Torque Defect Damper">Gear Torque Defect Damper</option>
                                        <option value="Gear Torque Too Much Clearance">Gear Torque Too Much Clearance</option>
                                        <option value="Gear Torque Cracked Broken">Gear Torque Cracked Broken</option>
                                        <option value="Gear Torque Needs Alignment">Gear Torque Needs Alignment</option>
                                        <option value="Gear Defect Acc. PT100 Bearing 1">Gear Defect Acc. PT100 Bearing 1</option>
                                        <option value="Gear Defect Acc. PT100 Bearing 2">Gear Defect Acc. PT100 Bearing 2</option>
                                        <option value="Gear Defect Acc. PT100 Bearing 3">Gear Defect Acc. PT100 Bearing 3</option>
                                        <option value="Gear Defect Acc. Oil Level Sensor">Gear Defect Acc. Oil Level Sensor</option>
                                        <option value="Gear Defect Acc. Oil Pressure">Gear Defect Acc. Oil Pressure</option>
                                        <option value="Gear Defect Acc. PT100 Oil Sump">Gear Defect Acc. PT100 Oil Sump</option>
                                        <option value="Gear Defect Acc. Filter Indicator">Gear Defect Acc. Filter Indicator</option>
                                        <option value="Gear Defect Acc. Immersion Heater">Gear Defect Acc. Immersion Heater</option>
                                        <option value="Gear Defect Acc. Drain Valve">Gear Defect Acc. Drain Valve</option>
                                        <option value="Gear Defect Acc. Air Breather">Gear Defect Acc. Air Breather</option>
                                        <option value="Gear Defect Acc. Sight Glass">Gear Defect Acc. Sight Glass</option>
                                        <option value="Gear Defect Acc. Chip Detector">Gear Defect Acc. Chip Detector</option>
                                        <option value="Gear Symptoms Vibrations">Gear Symptoms Vibrations</option>
                                        <option value="Gear Symptoms Noise">Gear Symptoms Noise</option>
                                        <option value="Gear Symptoms Debris On Magnet">Gear Symptoms Debris On Magnet</option>
                                        <option value="Gear Symptoms Magnet Position">Gear Symptoms Magnet Position</option>
                                        <option value="Gear Symptoms Debris In Gearbox">Gear Symptoms Debris In Gearbox</option>
                                        <option value="Gear Leakage LSS NR End">Gear Leakage LSS NR End</option>
                                        <option value="Gear Leakage IMS NR End">Gear Leakage IMS NR End</option>
                                        <option value="Gear Leakage IMS R End">Gear Leakage IMS R End</option>
                                        <option value="Gear Leakage HSS NR End">Gear Leakage HSS NR End</option>
                                        <option value="Gear Leakage HSS R End">Gear Leakage HSS R End</option>
                                        <option value="Gear Leakage Pitch Tube">Gear Leakage Pitch Tube</option>
                                        <option value="Gear Leakage Split Lines">Gear Leakage Split Lines</option>
                                        <option value="Gear Leakage Hose Piping">Gear Leakage Hose Piping</option>
                                        <option value="Gear Leakage Input Shaft">Gear Leakage Input Shaft</option>
                                        <option value="Gear Leakage Aux. HSS/PTO">Gear Leakage Aux. HSS/PTO</option>
                                        <option value="General Comp. Group">General Comp. Group</option>
                                        <option value="General Comp. Type">General Comp. Type</option>
                                        <option value="General Comp. Manufact.">General Comp. Manufact.</option>
                                        <option value="General Other Gearbox Type">General Other Gearbox Type</option>
                                        <option value="General Other Gearbox Manufact.">General Other Gearbox Manufact.</option>
                                        <option value="General Comp. Ser. No.">General Comp. Ser. No.</option>
                                        <option value="General Generator Manufact.">General Generator Manufact.</option>
                                        <option value="General Transf. Manufact.">General Transf. Manufact.</option>
                                        <option value="General Gearbox Manufact.">General Gearbox Manufact.</option>
                                        <option value="General Tower Type">General Tower Type</option>
                                        <option value="General Tower Height">General Tower Height</option>
                                        <option value="General Blade Ser. No.">General Blade Ser. No.</option>
                                        <option value="General Ctrl. Type">General Ctrl. Type</option>
                                        <option value="General Soft. Rel.">General Soft. Rel.</option>
                                        <option value="General Ram Dump No.">General Ram Dump No.</option>
                                        <option value="General VDF Track No.">General VDF Track No.</option>
                                        <option value="General Pics. Att.">General Pics. Att.</option>
                                        <option value="General Initiated By">General Initiated By</option>
                                        <option value="General Measurements Conducted">General Measurements Conducted</option>
                                        <option value="General Executed By">General Executed By</option>
                                        <option value="General Position Of Failed Item">General Position Of Failed Item</option>
                                        <option value="Generator Manufacturer">Generator Manufacturer</option>
                                        <option value="Generator Ser. No.">Generator Ser. No.</option>
                                        <option value="Generator Comment">Generator Comment</option>
                                        <option value="Generator Rew. Locally">Generator Rew. Locally</option>
                                        <option value="Generator Max Temperature">Generator Max Temperature</option>
                                        <option value="Generator Max Temperature Reset Date">Generator Max Temperature Reset Date</option>
                                        <option value="Generator Action To Be Taken">Generator Action To Be Taken</option>
                                        <option value="Generator Drive End">Generator Drive End</option>
                                        <option value="Generator Non Drive End">Generator Non Drive End</option>
                                        <option value="Generator Rotor">Generator Rotor</option>
                                        <option value="Generator Cover">Generator Cover</option>
                                        <option value="Generator U1 - U2">Generator U1 - U2</option>
                                        <option value="Generator V1 - V2">Generator V1 - V2</option>
                                        <option value="Generator W1 - W2">Generator W1 - W2</option>
                                        <option value="Generator K1 - L1">Generator K1 - L1</option>
                                        <option value="Generator L1 - M1">Generator L1 - M1</option>
                                        <option value="Generator K1 - M1">Generator K1 - M1</option>
                                        <option value="Generator K2 - L2">Generator K2 - L2</option>
                                        <option value="Generator L2 - M2">Generator L2 - M2</option>
                                        <option value="Generator K2 - M2">Generator K2 - M2</option>
                                        <option value="Generator U - Ground">Generator U - Ground</option>
                                        <option value="Generator U - Ground (unit)">Generator U - Ground (unit)</option>
                                        <option value="Generator V - Ground">Generator V - Ground</option>
                                        <option value="Generator V - Ground (unit)">Generator V - Ground (unit)</option>
                                        <option value="Generator W - Ground">Generator W - Ground</option>
                                        <option value="Generator W - Ground (unit)">Generator W - Ground (unit)</option>
                                        <option value="Generator U - V">Generator U - V</option>
                                        <option value="Generator U - V (unit)">Generator U - V (unit)</option>
                                        <option value="Generator U - W">Generator U - W</option>
                                        <option value="Generator U - W (unit)">Generator U - W (unit)</option>
                                        <option value="Generator V - W">Generator V - W</option>
                                        <option value="Generator V - W (unit)">Generator V - W (unit)</option>
                                        <option value="Generator K - Ground">Generator K - Ground</option>
                                        <option value="Generator K - Ground (unit)">Generator K - Ground (unit)</option>
                                        <option value="Generator L - Ground">Generator L - Ground</option>
                                        <option value="Generator L - Ground (unit)">Generator L - Ground (unit)</option>
                                        <option value="Generator M - Ground">Generator M - Ground</option>
                                        <option value="Generator M - Ground (unit)">Generator M - Ground (unit)</option>
                                        <option value="Main Bearing Last Lubrication Date">Main Bearing Last Lubrication Date</option>
                                        <option value="Main Bearing Manufacturer">Main Bearing Manufacturer</option>
                                        <option value="Main Bearing Temperature">Main Bearing Temperature</option>
                                        <option value="Main Bearing Lubrication Type">Main Bearing Lubrication Type</option>
                                        <option value="Main Bearing Lubrication Run Hours">Main Bearing Lubrication Run Hours</option>
                                        <option value="Main Bearing Oil Temperature">Main Bearing Oil Temperature</option>
                                        <option value="Main Bearing Type">Main Bearing Type</option>
                                        <option value="Main Bearing Revision">Main Bearing Revision</option>
                                        <option value="Main Bearing Error Location">Main Bearing Error Location</option>
                                        <option value="Main Bearing Serial Number">Main Bearing Serial Number</option>
                                        <option value="Main Bearing Run Hours">Main Bearing Run Hours</option>
                                        <option value="Main Bearing Mechanical Oil Pump">Main Bearing Mechanical Oil Pump</option>
                                        <option value="SkiiP Failed Component Serial Number">SkiiP Failed Component Serial Number</option>
                                        <option value="SkiiP Failed Component Vestas Unique Identifier">SkiiP Failed Component Vestas Unique Identifier</option>
                                        <option value="SkiiP Failed Component Vestas Item Number">SkiiP Failed Component Vestas Item Number</option>
                                        <option value="SkiiP New Component Serial Number">SkiiP New Component Serial Number</option>
                                        <option value="SkiiP New Component Vestas Unique Identifier">SkiiP New Component Vestas Unique Identifier</option>
                                        <option value="SkiiP New Component Vestas Item Number">SkiiP New Component Vestas Item Number</option>
                                        <option value="SkiiP Other Damaged Components Replaced">SkiiP Other Damaged Components Replaced</option>
                                        <option value="SkiiP Cause">SkiiP Cause</option>
                                        <option value="SkiiP Quantity Of Failed Modules">SkiiP Quantity Of Failed Modules</option>
                                        <option value="SkiiP 2MW V521">SkiiP 2MW V521</option>
                                        <option value="SkiiP 2MW V522">SkiiP 2MW V522</option>
                                        <option value="SkiiP 2MW V523">SkiiP 2MW V523</option>
                                        <option value="SkiiP 2MW V524">SkiiP 2MW V524</option>
                                        <option value="SkiiP 2MW V525">SkiiP 2MW V525</option>
                                        <option value="SkiiP 2MW V526">SkiiP 2MW V526</option>
                                        <option value="SkiiP 3MW V521">SkiiP 3MW V521</option>
                                        <option value="SkiiP 3MW V522">SkiiP 3MW V522</option>
                                        <option value="SkiiP 3MW V523">SkiiP 3MW V523</option>
                                        <option value="SkiiP 3MW V524x">SkiiP 3MW V524x</option>
                                        <option value="SkiiP 3MW V524y">SkiiP 3MW V524y</option>
                                        <option value="SkiiP 3MW V525x">SkiiP 3MW V525x</option>
                                        <option value="SkiiP 3MW V525y">SkiiP 3MW V525y</option>
                                        <option value="SkiiP 3MW V526x">SkiiP 3MW V526x</option>
                                        <option value="SkiiP 3MW V526y">SkiiP 3MW V526y</option>
                                        <option value="SkiiP 850KW V520">SkiiP 850KW V520</option>
                                        <option value="SkiiP 850KW V524">SkiiP 850KW V524</option>
                                        <option value="SkiiP 850KW V525">SkiiP 850KW V525</option>
                                        <option value="SkiiP 850KW V526">SkiiP 850KW V526</option>
                                        <option value="Transformer Manufacturer">Transformer Manufacturer</option>
                                        <option value="Transformer Ser. No.">Transformer Ser. No.</option>
                                        <option value="Transformer Arc Detection">Transformer Arc Detection</option>
                                        <option value="Transformer Max Temperature">Transformer Max Temperature</option>
                                        <option value="Transformer Max Temperature Reset Date">Transformer Max Temperature Reset Date</option>
                                        <option value="Transformer Action To Be Taken">Transformer Action To Be Taken</option>
                                        <option value="Transformer HV Coil">Transformer HV Coil</option>
                                        <option value="Transformer LV Coil">Transformer LV Coil</option>
                                        <option value="Transformer HV Cable">Transformer HV Cable</option>
                                        <option value="Transformer LV Cable">Transformer LV Cable</option>
                                        <option value="Transformer Brackets">Transformer Brackets</option>
                                        <option value="Transformer Climate">Transformer Climate</option>
                                        <option value="Transformer Surge Arrestor">Transformer Surge Arrestor</option>
                                        <option value="Transformer Connection Bars">Transformer Connection Bars</option>
                                        <option value="Transformer Comment">Transformer Comment</option>
                                         <option value="Up-Tower Solution Available">Up-Tower Solution Available</option>
                                         <option value="Tech. Support recommendation">Tech. Support recommendation </option>
                                         <option value="Internal Comments">InternalComments</option>
                                         <option value="Additional Information">AdditionalInfo</option>
                                        <option value="BIR Data ID (m)">BIR Data ID (m)</option>
                                    </select>
                                </div>
                            </div>

                                 <div id="AdvancedSearchButtons" class="col-xs-12" style="text-align: right;">
                                    <a href="javascript:void(0);" id="linkCirAdvancedSearch" class="btn btn-primary AdvancedSearchButton">Search</a>
                                    <a href="javascript:void(0);" id="linkCirReset" class="btn btn-primary AdvancedSearchReset_Main">Reset</a>
                               </div>
                                    
                                 <%--CIR Type selection--%>
                                
                                    <fieldset id="fsProfile" >
                                        <legend>Search Profile - Load / Save</legend>
                                        <table style="width: 100%;">
                                        
                                           

                                        <tr style="height: 10px;">
                                            <td>
                                                <label class="col-lg-3 control-label" id="lblDumy1" style="width: 100%;"></label>
                                            </td>
                                        </tr>
                                            <tr style="width: 100%;">
                                                <td style="width: 30%; text-align: right;">
                                                    <label class="col-lg-3 control-label" id="lblSearchfilters" style="width: 100%;">Select Profile to Load</label>
                                                </td>
                                                <td style="width: 60%; white-space: nowrap;">
                                                    <table style="width: 100%;">
                                                        <tr style="width: 100%;">
                                                            <td style="width: 60%;">
                                                                <select id="CIRProfile" class="form-control" data-fieldtype="select-remote" data-datatable="SearchProfile" 
                                                                data-textfield="text" data-valuefield="value" style="width: 99%"></select>
                                                            </td>
                                                            <td style="width: 40%;">
                                                                <a href="javascript:void(0);" id="linkCirLoadProfile" class="btn btn-primary">Load</a>
                                                                <a href="javascript:void(0);" id="linkCirDeleteProfile" class="btn btn-primary">Delete</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 10%;"></td>
                                            </tr>

                                        <tr style="height: 10px;">
                                            <td>
                                                <label class="col-lg-3 control-label" id="lblDumy2" style="width: 100%;"></label>
                                            </td>
                                        </tr>

                                        <tr style="width: 100%;">
                                            <td style="width: 30%;  text-align: right;">
                                                <label class="col-lg-3 control-label" id="lblSearchProfileName" style="width:100%;">Save Profile as</label>
                                            </td>
                                            <td style="width: 60%;">
                                                <table style="width: 100%;">
                                                    <tr style="width: 100%;">
                                                        <td style="width: 60%;">
                                                            <input type="text" id="CIRProfileSaveName" class="form-control" style="width: 99%;" title="Enter a unique name of the Profile in the form of [Organizational group/Initials/Contents of report]!" placeholder="Organizational Group/Initials/Contents of Report" />
                                                        </td>
                                                        <td style="width: 40%;">
                                                            <a href="javascript:void(0);" id="linkCirSaveProfile" class="btn btn-primary AdvancedSearchButton">Save</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width: 10%;">
                                                
                                            </td>
                                        </tr>

                                        <tr style="width: 100%;">
                                            <td style="width: 30%;  text-align: right;">
                                               
                                            </td>
                                            <td style="width: 60%;">
                                                
                                                        <input id="CIRProfileIsPublic" type="checkbox" name="CIRProfileIsPublic">&nbsp;
                                                        <label for="CIRProfileIsPublic">Publish as Public Profile</label>
                                            </td>
                                            <td style="width: 10%;">
                                            </td>
                                        </tr>
                                            <tr style="width: 100%;">
                                                <td style="width: 30%;"></td>
                                                <td style="width: 60%;"></td>
                                                <td style="width: 10%;"></td>
                                            </tr>

                                        </table>
                                        <div class="col-xs-12" style="text-align: right;">
                                            <a href="javascript:void(0);" id="linkCirAdvancedSearch_Profile" class="btn btn-primary AdvancedSearchButton">Search</a>
                                            <a href="javascript:void(0);" id="linkCirReset_Profile" class="btn btn-primary AdvancedSearchReset_Main">Reset</a>
                                        </div>
                                    </fieldset>
                                </div>

                                <%-- Common Section--%>
                                <h3 id="cirCommonLink"><a href="javascript:void(0);">Common Data (Wind Turbine + Description)
                                 <i class="fa fa-gears" style="float: right">&nbsp;</i></a>
                                </h3>
                                
                                <div id="Common" class="templateItem" background: transparent;">
                                    <% Html.RenderPartial("~/Views/Cir/AdvancedSearch/Common.ascx"); %>
                                </div>
                                <%-- Common Section--%>

                                 <%--CIR Type selection--%>
                               
                                <%--<h3 id="cirBladeLink"><a href="javascript:void(0);">
                                    <div class="persist-header-Blade" id="divBladeStatic">
                                        <span id="ComponentName">Blade</span>
                                        <i class="fa fa-list-alt" style="float: right; padding-right: 5px"></i>
                                    </div>
                                </a></h3>--%>

                                <%--Blade Specific fields--%>
                              <%--<div id="cirBladeSection" style="display: none;">--%>

                                <h3 id="cirBladeLink"><a href="javascript:void(0);">Blade
                                 <i class="fa fa-list-alt" style="float: right">&nbsp;</i></a>
                                </h3>

                                <div id="blade" class="templateItem" style="background: transparent;">
                                    <% Html.RenderPartial("~/Views/Cir/AdvancedSearch/Blade.ascx"); %>
                                </div>

                                <h3 id="cirGearbox"><a href="javascript:void(0);">Gearbox
                                 <i class="fa fa-list-alt" style="float: right">&nbsp;</i></a>
                                </h3>

                                <div id="gearbox" class="templateItem" style="background: transparent;">
                                    <% Html.RenderPartial("~/Views/Cir/AdvancedSearch/Gearbox.ascx"); %>
                                </div>

                                 <h3 id="cirGeneral"><a href="javascript:void(0);">General
                                 <i class="fa fa-list-alt" style="float: right">&nbsp;</i></a>
                                </h3>
                                <div id="general" class="templateItem" style="background: transparent;">
                                    <% Html.RenderPartial("~/Views/Cir/AdvancedSearch/General.ascx"); %>
                                </div>

                                <h3 id="cirGenerator"><a href="javascript:void(0);">Generator
                                 <i class="fa fa-list-alt" style="float: right">&nbsp;</i></a>
                                </h3>
                                <div id="generator" class="templateItem" style="background: transparent;">
                                    <% Html.RenderPartial("~/Views/Cir/AdvancedSearch/Generator.ascx"); %>
                                </div>

                                <h3 id="cirTransformer"><a href="javascript:void(0);">Transformer
                                 <i class="fa fa-list-alt" style="float: right">&nbsp;</i></a>
                                </h3>
                                <div id="transformer" class="templateItem" style="background: transparent;">
                                    <% Html.RenderPartial("~/Views/Cir/AdvancedSearch/Transformer.ascx"); %>
                                </div>

                                <h3 id="cirMainbearing"><a href="javascript:void(0);">Mainbearing
                                 <i class="fa fa-list-alt" style="float: right">&nbsp;</i></a>
                                </h3>
                                <div id="mainbearing" class="templateItem" style="background: transparent;">
                                    <% Html.RenderPartial("~/Views/Cir/AdvancedSearch/MainBearing.ascx"); %>
                                </div>

                                <h3 id="cirSkiipack"><a href="javascript:void(0);">Skiipack
                                 <i class="fa fa-list-alt" style="float: right">&nbsp;</i></a>
                                </h3>
                                <div id="skiipack" class="templateItem" style="background: transparent;">
                                    <% Html.RenderPartial("~/Views/Cir/AdvancedSearch/Skiipack.ascx"); %>
                                </div>

                                <h3 id="cirBIR"><a href="javascript:void(0);">BIR
                                 <i class="fa fa-list-alt" style="float: right">&nbsp;</i></a>
                                </h3>
                                <div id="BIR" class="templateItem" style="background: transparent;">
                                    <% Html.RenderPartial("~/Views/Cir/AdvancedSearch/BIR.ascx"); %>
                                </div>

                                <%--</div>--%>

                                <%-- Search Result Section--%>
                                <h3 id="cirAdvancedSearchResultSectionLink"><a href="javascript:void(0);">Search Result
                                 <i class="fa fa-search" style="float: right">&nbsp;</i></a>
                                </h3>
                                
                                <div id="cirAdvancedSearchResultSection" style="display: none; background: transparent; overflow-x:hidden">
                                    <% Html.RenderPartial("~/Views/Cir/AdvancedSearch/AdvancedSearchResult.ascx"); %>
                                </div>
                                <%-- Search Result Section--%>
                                </div>
                            
                            <%--CIR Type selection--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
          <%-- <script src="../../../Js/chosenslectionlist/prism.js"></script>
            <script src="../../../Js/chosenslectionlist/chosen.jquery.js"></script>--%>


        </form>
    </section>
    
  <script type="text/javascript">
       
    var config = {
      '.chosen-select'           : {},
      '.chosen-select-deselect'  : {allow_single_deselect:true},
      '.chosen-select-no-single' : {disable_search_threshold:10},
      '.chosen-select-no-results': {no_results_text:'Oops, nothing found!'},
      '.chosen-select-width'     : {width:"95%"}
    }
    for (var selector in config) {
      $(selector).chosen(config[selector]);
    }
     
  
    //$(document).ready(function () {
    //    $("#CIRComponentType").trigger("chosen:updated");
    // });
    
  </script>
    <input type="hidden" id="hdnUserInitial" />
    <script type="text/javascript">
       
        
        function supports_input_placeholder() {
            var i = document.createElement('input');
            return 'placeholder' in i;
        }

        if (!supports_input_placeholder()) {
            var fields = document.getElementsByTagName('INPUT');
            for (var i = 0; i < fields.length; i++) {
                if (fields[i].hasAttribute('placeholder')) {
                    fields[i].defaultValue = fields[i].getAttribute('placeholder');
                    fields[i].onfocus = function () { if (this.value == this.defaultValue) this.value = ''; }
                    fields[i].onblur = function () { if (this.value == '') this.value = this.defaultValue; }
                }
            }
        }

    </script>
</asp:Content>
