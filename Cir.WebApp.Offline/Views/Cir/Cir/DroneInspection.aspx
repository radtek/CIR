<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Drone Inspection Main Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Css/footable.core.css" rel="stylesheet" type="text/css" />
    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <script src="../Js/jquery.dataTables.min.js"></script>  
    <script src="../Js/footable.all.min.js"></script>  
    <script src="../Js/ApplicationScripts/localHistory.js"></script>
    <script src="http://vjs.zencdn.net/ie8/1.1.2/videojs-ie8.min.js"></script>
    <script src="../Js/BladeInspections/NonDroneInspection.js"></script>      
    <section class="content" style="background: transparent">
        <h2>Select Inspection:</h2>
        <a href=""><button type="button" class="btn btn-primary" id="drone-inspection-btn">Drone Inspection</button></a>
        <a href="/cir/non-drone-inspection"><button type="button" class="btn btn-primary" id="non-drone-inspection-btn">Non Drone Inspection</button></a>        
        
        
        
    </section>
   
  

</asp:Content>

