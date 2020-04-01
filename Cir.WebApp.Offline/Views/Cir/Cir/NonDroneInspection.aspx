<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Non Drone Inspection
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
        
        <div class="modal" id="myModal" role="dialog">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Vestas blade instruction</h4>
                    </div>
                    <div class="modal-body">
                        <video id="my-video" class="video-js" controls preload="none" width="500" height="264" data-setup="{}">
                            <source src=" /cir/show-video" type='video/mp4'>
                            <p class="vjs-no-js">
                                To view this video please enable JavaScript, and consider upgrading to a web browser that
                                <a href="http://videojs.com/html5-video-support/" target="_blank">supports HTML5 video</a>
                            </p>
                        </video>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary" id="blade-instruction-modal-btn">Ok</button>

                    </div>
                </div>
            </div>
        </div>
    </section>
    
  

</asp:Content>
