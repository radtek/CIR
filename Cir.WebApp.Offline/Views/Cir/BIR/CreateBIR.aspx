<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Local History - CIM Inspection Report
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <link href="../Css/FlexResponive-0.1.css" rel="stylesheet" type="text/css" />
    <link href="../Css/FlexResponive.sortable-0.1.css" rel="stylesheet" type="text/css" />
    <script src="../Js/FlexResponive.js"></script>
    <script src="../Js/FlexResponive.sortable.js"></script>
    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    
    

    <section class="content" style="background: transparent">
       

        <!-- Trigger the modal with a button -->
<button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Create BIR</button>

<!-- Modal -->
<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog" style="width: 82%;">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">Choose Master CIR</h4>
      </div>
      <div class="modal-body">
        <div class="row">
            <div class="col-xs-12">
                <div class="well well-White">
                    
                    
                    <div>
                        <table role="main" id="tblCirPopupTable" class="FlexResponive list">
                            <thead>
                                <tr>
                                    <th data-hide="phone" scope="col"></th>
                                    <th data-class="expand" scope="col" data-sort-initial="true">Name</th>
                                    <th data-hide="phone" scope="col">CIR ID</th>
                                    <th data-hide="phone" scope="col">Component Type</th>
                                    <th data-hide="phone" scope="col">Blade s/n</th>
                                    <th data-hide="phone" scope="col">Report Type</th>
                                    <th data-hide="phone" scope="col">Turbine Number</th>
                                    <th data-hide="phone" scope="col">Created</th>
                                    <th data-hide="phone" scope="col" data-sort-ignore="true" style="width:7%"></th>
                                </tr>
                            </thead>
                        </table>

                       
                    </div>
                     <br />
                <div class="row">
                            <label class="col-lg-3 control-label">Repairing solutions : </label>
                            <div class="col-lg-9">
                                <textarea id="txtRepairingsolutions" data-toggle="tooltip" 
                                    data-placement="top" title="Repairing solutions"  class="form-control" style="width:100%;height:150px;" placeholder="Repairing solutions"></textarea>
                        
                            </div>
                        </div><br />
                    <div class="row">
                            <label class="col-lg-3 control-label">Inspection tool description : </label>
                            <div class="col-lg-9">
                                <textarea id="txtRawMaterialsforrepair" data-toggle="tooltip" 
                                    data-placement="top" title="Inspection tool description"  class="form-control" style="width:100%;height:150px;" placeholder="Inspection tool description"></textarea>
                        
                            </div>
                        </div><br />
                    <div class="row">
                            <label class="col-lg-3 control-label">Conclusions and Recommendations : </label>
                            <div class="col-lg-9">
                                <textarea id="txtConclusionsandRecommendations" data-toggle="tooltip" 
                                    data-placement="top" title="Conclusions and Recommendations"  class="form-control" style="width:100%;height:150px;" placeholder="Conclusions and Recommendations"></textarea>
                        
                            </div>
                        </div><br />
                            

                            <div class="row">
                                <div class="col-lg-9 col-lg-offset-3">
                                    <input type="submit" class="btn btn-primary" value="Retrieve Latest Record" />
                                    
                                </div>
                            </div>
                </div>

                

            </div>
            
               
        

        </div>
      </div>
      <div class="modal-footer">
          <button type="button" class="btn btn-primary">Save changes</button>
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>        
      </div>
    </div>

  </div>
</div>
    </section>
<script>

    $("#tblCirPopupTable").delegate('input.up', 'click', function (e) {

        var it = $(this).closest('tr');
        var prev = $(this).closest('tr').prev('tr');

        if (it.attr("id") != $("tr:first").attr("id")) {
            it.remove();
            it.insertBefore(prev);
        }
    });
    $("#tblCirPopupTable").delegate('input.down', 'click', function (e) {

        var it = $(this).closest('tr');
        var next = $(this).closest('tr').next('tr');

        if (it.attr("id") != $("tr:last").attr("id")) {
            it.remove();
            it.insertAfter(next);
        }
    });

    $(document).ready(function () {

        function setModalMaxHeight(element) {
            this.$element = $(element);
            this.$content = this.$element.find('.modal-content');
            var borderWidth = this.$content.outerHeight() - this.$content.innerHeight();
            var dialogMargin = $(window).width() < 768 ? 20 : 60;
            var contentHeight = $(window).height() - (dialogMargin + borderWidth);
            var headerHeight = this.$element.find('.modal-header').outerHeight() || 0;
            var footerHeight = this.$element.find('.modal-footer').outerHeight() || 0;
            var maxHeight = contentHeight - (headerHeight + footerHeight);

            this.$content.css({
                'overflow': 'hidden'
            });

            this.$element
              .find('.modal-body').css({
                  'max-height': maxHeight,
                  'overflow-y': 'auto'
              });

        }

        $('.modal').on('show.bs.modal', function () {
            $(this).show();
            setModalMaxHeight(this);
        });

        $(window).resize(function () {
            if ($('.modal.in').length != 0) {
                setModalMaxHeight($('.modal.in'));
            }
        });

        

        var $row = $(this).closest("tr");
        var $tds = $row.find("td");
        var tr = $('<tr id="tr1"></tr>');
        $('<td><input type="radio" title="Select master CIR" name="SelectMaster" class="SelectMaster" id="1" checked="checked" /></td>').appendTo(tr);
        $('<td>Test1</td>').appendTo(tr);
        $('<td>Test1</td>').appendTo(tr);
        $('<td>Test1</td>').appendTo(tr);
        $('<td>Test1</td>').appendTo(tr);
        $('<td>Test1</td>').appendTo(tr);
        $('<td>Test1</td>').appendTo(tr);
        $('<td>Test1</td>').appendTo(tr);
        $('<td> <input type="button" class="up" value="&#8679;"/><input type="button" class="down" value="&#8681;"/></td>').appendTo(tr);
        $("#tblCirPopupTable").append(tr);
        tr = $('<tr id="tr2"></tr>');
        $('<td><input type="radio" title="Select master CIR" name="SelectMaster" class="SelectMaster" id="2" /></td>').appendTo(tr);
        $('<td>Test2</td>').appendTo(tr);
        $('<td>Test2</td>').appendTo(tr);
        $('<td>Test2</td>').appendTo(tr);
        $('<td>Test2</td>').appendTo(tr);
        $('<td>Test2</td>').appendTo(tr);
        $('<td>Test2</td>').appendTo(tr);
        $('<td>Test2</td>').appendTo(tr);
        $('<td><input type="button" class="up" value="&#8679;"/><input type="button" class="down" value="&#8681;"/></td>').appendTo(tr);
        $("#tblCirPopupTable").append(tr);
        tr = $('<tr id="tr3"></tr>');
        $('<td><input type="radio" title="Select master CIR" name="SelectMaster" class="SelectMaster" id="3" /></td>').appendTo(tr);
        $('<td>Test3</td>').appendTo(tr);
        $('<td>Test3</td>').appendTo(tr);
        $('<td>Test3</td>').appendTo(tr);
        $('<td>Test3</td>').appendTo(tr);
        $('<td>Test3</td>').appendTo(tr);
        $('<td>Test3</td>').appendTo(tr);
        $('<td>Test3</td>').appendTo(tr);
        $('<td> <input type="button" class="up" value="&#8679;"/><input type="button" class="down" value="&#8681;"/></td>').appendTo(tr);

        $("#tblCirPopupTable").append(tr);


        //$('body').on('click', '.btn', function () {
        //    alert("Test");
        //    move_row("1", "UP", "2")
        //});
    });
        
</script>
</asp:Content>
