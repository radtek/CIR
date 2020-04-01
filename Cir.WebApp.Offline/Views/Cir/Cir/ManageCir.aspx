<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Cir.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= System.Configuration.ConfigurationManager.AppSettings["ApplicationName"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Css/jQueryUI/jquery-ui-1.10.3.custom.css" rel="stylesheet" />
    <link href="../Css/jQueryUI/jquery.ui.accordion.css" rel="stylesheet" />
    <link href="../../../Css/jquery-ui-timepicker-addon.css" rel="stylesheet" />
    <script src="../Js/ApplicationScripts/Cir.js"></script>
    <script src="../Js/jquery.ui.accordion.js"></script>
    <script src="../../../Js/ApplicationScripts/jquery-ui-timepicker-addon.js"></script>

    <link href="../../../Css/swiper/swiper.min.css" rel="stylesheet" />
    <style>
        .swiper-container {
            position: fixed;
            top: 5%;
            left: 5%;   
            width: 90%;
            height: 90%;
            margin-top: 0%;
            margin-left: 0%;
            border: 1px solid #ccc;
            background-color: #f3f3f3;
            display: none;
            border-radius: 6px;
        }


        .swiper-slide {
            /*position:absolute;*/
            text-align: center;
            font-size: 18px;
            background: #fff;
            display: -webkit-box;
            display: -ms-flexbox;
            display: -webkit-flex;
            display: flex;
            -webkit-box-pack: center;
            -ms-flex-pack: center;
            -webkit-justify-content: center;
            justify-content: center;
            -webkit-box-align: center;
            -ms-flex-align: center;
            -webkit-align-items: center;
            align-items: center;
        }

            .swiper-slide .subtitle {
                text-align: left;
                position: absolute;
                top: 2%;
                left: 0;
                width: 95%;
                color: white;
                overflow-wrap: break-word;
                margin-left: 1%;
                margin-top: 0.4%;
            }

        .swiper-button-prev {
            left: 0px !important;
            min-height: 100% !important;
            min-width: 5% !important;
            top: 43px !important;
        }

        .swiper-button-next {
            right: 0px !important;
            min-height: 100% !important;
            min-width: 5% !important;
            top: 43px !important;
        }

        .swiper-button-prev:hover {
            background-color: #F5F5F5 !important;
        }

        .swiper-button-next:hover {
            background-color: #F5F5F5 !important;
        }
    </style>
    <%--<div id="myModal" class="swiper-container">
       <span class="close cursor" title="Close" onclick="closeModal('imagedrop')">&times;</span>
        <div id="prevlist" class="swiper-wrapper"></div>
        <!-- Add Pagination -->
        <div class="swiper-pagination"></div>
        <!-- Add Navigation -->
        <div class="swiper-button-prev"></div>
        <div class="swiper-button-next"></div>
    </div>--%>
    <div id="myModal1" class="swiper-container">
        <span class="close cursor" title="Close" onclick="closeModal('imagedropA')">&times;</span>
        <div id="prevlist1" class="swiper-wrapper"></div>
        <!-- Add Pagination -->
        <div class="swiper-pagination"></div>
        <!-- Add Navigation -->
        <div class="swiper-button-prev"></div>
        <div class="swiper-button-next"></div>
    </div>
    <div id="myModal2" class="swiper-container">
        <span class="close cursor" title="Close" onclick="closeModal('imagedropB')">&times;</span>
        <%--<div class="parallax-bg" style="background-image: url(http://lorempixel.com/900/600/nightlife/2/)" data-swiper-parallax="-23%"></div>--%>
        <div id="prevlist2" class="swiper-wrapper"></div>
        <!-- Add Pagination -->
        <div class="swiper-pagination"></div>
        <!-- Add Navigation -->
        <div class="swiper-button-prev"></div>
        <div class="swiper-button-next"></div>
    </div>
    <div id="myModal3" class="swiper-container">
        <span class="close cursor" title="Close" onclick="closeModal('imagedropC')">&times;</span>
        <div id="prevlist3" class="swiper-wrapper"></div>
        <!-- Add Pagination -->
        <div class="swiper-pagination"></div>
        <!-- Add Navigation -->
        <div class="swiper-button-prev"></div>
        <div class="swiper-button-next"></div>
    </div>
    <div id="myModal4" class="swiper-container">
        <span class="close cursor" title="Close" onclick="closeModal('imagedropD')">&times;</span>
        <div id="prevlist4" class="swiper-wrapper"></div>
        <!-- Add Pagination -->
        <div class="swiper-pagination"></div>
        <!-- Add Navigation -->
        <div class="swiper-button-prev"></div>
        <div class="swiper-button-next"></div>
    </div>
    <div id="myModal5" class="swiper-container">
        <span class="close cursor" title="Close" onclick="closeModal('imagedropE')">&times;</span>
        <div id="prevlist5" class="swiper-wrapper"></div>
        <!-- Add Pagination -->
        <div class="swiper-pagination"></div>
        <!-- Add Navigation -->
        <div class="swiper-button-prev"></div>
        <div class="swiper-button-next"></div>
    </div>
    <div id="myModal6" class="swiper-container">
        <span class="close cursor" title="Close" onclick="closeModal('imagedropF')">&times;</span>
        <div id="prevlist6" class="swiper-wrapper"></div>
        <!-- Add Pagination -->
        <div class="swiper-pagination"></div>
        <!-- Add Navigation -->
        <div class="swiper-button-prev"></div>
        <div class="swiper-button-next"></div>
    </div>
    <script src="../../../Js/swiper/swiper.min.js"></script>
    <script>
        $(document).mouseup(function (e) {
            var container = new Array();
            container.push($('#myModal1'));
            container.push($('#myModal2'));
            container.push($('#myModal3'));
            container.push($('#myModal4'));
            container.push($('#myModal5'));
            container.push($('#myModal6'));
            container.push($('#myModal'));

            $.each(container, function (key, value) {
                if (!$(value).is(e.target) // if the target of the click isn't the container...
                    && $(value).has(e.target).length === 0) // ... nor a descendant of the container
                {
                    $(value).hide();
                }
            });
        });

    </script>

    <script type="text/javascript">
        var _cacheCirID = 0;
        _cacheCirID = getQueryStringValueHash("cirID");


        $(window).bind('beforeunload', function () {
            if (cirOfflineApp.showDialog == 1) {
                var isDirty = false;
                $('#CirForm :input').each(function () {
                    if ($(this).data('initialValue') != null && $(this).attr('type') != "hidden") {
                        if ($(this).data('initialValue') != $(this).val()) {
                            isDirty = true;
                        }
                    }
                });
                if (isDirty == true)
                    return 'You have made some changes in the CIR which is not yet saved. Do you want to leave this page and discard your changes or stay on this page?';
            }
        });



    </script>
    <style>
        [data-toggle=buttons] > .btn > input[type=radio] {
            display: none !important;
        }

        .jconfirm .jconfirm-box div.closeIcon {
            font-size: 40px !important;
        }
    </style>
    <section class="content" style="background: transparent">
        <input type="hidden" id="cirLocalID" />
        <input type="hidden" id="cirRemoteID" />
        <input type="hidden" id="CirDataCommonID" />
        <input type="hidden" id="CirName" />
        <%--<input type="hidden" id="hdntemplateVersion" value="7" />--%>
        <input type="hidden" id="hdntemplateVersion" value="8" />

        <input type="hidden" id="cirDataID" value="0" />
        <input type="hidden" id="Error1" value="" />

        <form class="form" id="CirForm">
            <div class="row">
                <div class="col-xs-12">
                    <!--<div class="col-md-8 col-md-offset-2"> -->
                    <div class="well well-White" id="UsePDF">
                        <div class="row">
                            <div class="col-xs-12">
                                <div class="navbar-left navbar-SubHead">
                                    <% if (Request.QueryString["remotecirID"] != null)
                                        {%>
                                    <div id="cirlbl">Update CIR</div>
                                    <%}
                                        else
                                        { %>
                                    <div id="cirlbl">Create New CIR</div>
                                    <script type="text/javascript">
                                        document.getElementById("cirlbl").innerHTML = ((_cacheCirID > 0) ? "Update CIR" : "Create New CIR");
                                    </script>
                                    <%} %>

                                    <div class="Navbar-brandsmall">Component Inspection Report</div>
                                </div>
                            </div>
                        </div>
                        <div>
                            <div class="bs-example form-horizontal">
                                <%--Header Navbar: style can be found in header.less--%>

                                <%--Search--%>

                                <%--Navigations--%>

                                <div id="navCirType" class="alert alert-success" style="display: none;">
                                    CIR Type &nbsp;<strong><span id="cirTypeMessage"></span></strong>
                                </div>
                                <div id="navCirCommon" class="alert alert-success" style="display: none;">
                                    <strong>Wind Turbine Data</strong>
                                </div>
                                <div id="navBladeData" class="alert alert-success" style="display: none;">
                                    <strong>Blade Data</strong>
                                </div>
                                <div id="navPictures" class="alert alert-success" style="display: none;">
                                    <strong>Pictures</strong>
                                </div>

                                <%--Navigations--%>

                                <div id="cirProcessingSection" style="display: none;">
                                    <div id="loading-div" class="ui-corner-all">
                                        <div class="form-group">
                                            <div class="col-xs-12" style="text-align: center;">
                                                <img style="height: 25px; width: 150px;" src="/images/cir-loader.gif" alt="Loading.." /><br>
                                                <strong>Loading CIR data. Please wait<br />
                                                    .....</strong>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%--CIR Type selection--%>
                                <div id="cirTemplates" class="persist-area" style="display: block;">
                                    <%--<div class="cirTemplateSection">--%>
                                    <h3 id="cirTemplateLink"><a href="javascript:void(0);">Choose Template</a> <span class="fa fa-file-o" style="float: right">&nbsp;</span></h3>

                                    <div id="cirTemplateSection" style="background: transparent">
                                        <div class="form-group">
                                            <label class="col-lg-3 control-label">Template Type </label>

                                            <div class="col-md-9">
                                                <input name="radio" id="tType" type='hidden' value="rdCirType" />
                                                <div class="btn-group rd-block" data-toggle="buttons" autocomplete="off">
                                                    <div class="rd-overlay-option">or</div>
                                                    <button type="button" class="btn btn-default active"
                                                        data-radio-name="radio" autocomplete="off" id="rdCirType">
                                                        Cir Type</button>
                                                    <button type="button" class="btn btn-default" autocomplete="off" id="rdHotlist"
                                                        data-radio-name="radio">
                                                        Hot List</button>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-lg-3 control-label" id="lblTemplate">
                                                CIR Type <span class="errorSpan">*</span>
                                            </label>
                                            <div class="col-lg-9">
                                                <select id="ddlCirType" class="form-control" data-fieldtype="select" data-datatable="ComponentInspectionReportType" data-textfield="text" data-valuefield="ComponentInspectionReportTypeID" data-insertlable="false">
                                                </select>
                                                <select id="ddlHotlist" style="display: none;" class="form-control" data-fieldtype="select" data-datatable="HotItem" data-textfield="text" data-valuefield="HotItemID">
                                                </select>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="col-xs-12" style="text-align: right;">
                                                <a href="javascript:void(0);" id="linkCirTemplteNext" class="btn btn-primary">Next</a>
                                            </div>
                                        </div>
                                        <%--CIR Type selection--%>
                                    </div>
                                    <%--</div>--%>

                                    <h3 id="cirCommonLink" class="defaultItem"><a href="javascript:void(0);">Wind Turbine Data
                                 <i class="fa fa-gears" style="float: right">&nbsp;</i></a>
                                    </h3>

                                    <%--Common Fields for all CIR types--%>
                                    <div id="cirCommonSection" style="display: none; background: transparent;">

                                        <% Html.RenderPartial("~/Views/Cir/Cir/Common.ascx"); %>
                                        <div class="form-group">
                                            <div class="col-xs-12" style="text-align: right;">
                                                <%--<a href="javascript:void(0);" id="linkCirCommonPrev" class="btn btn-primary">Previous</a>--%>
                                                <a href="javascript:void(0);" id="linkCirCommonNext" class="btn btn-primary">Next</a>
                                            </div>
                                        </div>
                                    </div>
                                    <%--Common Fields for all CIR types--%>

                                    <%--Commented By Siddharth Chauhan on 03-06-2016. To fix the bug no.75525 of SPRINT 1.  --%>
                                    <%-- <h3 id="cirBladeLink"><a href="javascript:void(0);">
                                    <div class="persist-header-Blade" id="divBladeStatic">
                                        <span id="ComponentName">Blade Data</span>
                                        <i class="fa fa-list-alt" style="float: right; padding-right: 5px"></i>
                                    </div>
                                </a></h3> --%>
                                    <%--Added By Siddharth Chauhan on 03-06-2016. To fix the bug no.75525 of SPRINT 1.  --%>
                                    <h3 id="cirBladeLink"><a href="javascript:void(0);">
                                        <i class="fa fa-list-alt" style="float: right; padding-right: 5px"></i>

                                    </a></h3>
                                    <%--Blade Specific fields--%>
                                    <div id="cirBladeSection" style="display: none;">
                                        <div id="blade" class="templateItem">
                                            <% Html.RenderPartial("~/Views/Cir/Cir/Blade.ascx"); %>
                                        </div>
                                        <div id="gearbox" class="templateItem" style="display: none;">
                                            <% Html.RenderPartial("~/Views/Cir/Cir/Gearbox.ascx"); %>
                                        </div>
                                        <div id="general" class="templateItem" style="display: none;">
                                            <% Html.RenderPartial("~/Views/Cir/Cir/General.ascx"); %>
                                        </div>
                                        <div id="skiipack" class="templateItem" style="display: none;">
                                            <% Html.RenderPartial("~/Views/Cir/Cir/Skiipack.ascx"); %>
                                        </div>
                                        <div id="transformer" class="templateItem" style="display: none;">
                                            <% Html.RenderPartial("~/Views/Cir/Cir/Transformer.ascx"); %>
                                        </div>
                                        <div id="mainbearing" class="templateItem" style="display: none;">
                                            <% Html.RenderPartial("~/Views/Cir/Cir/MainBearing.ascx"); %>
                                        </div>
                                        <div id="generator" class="templateItem" style="display: none;">
                                            <% Html.RenderPartial("~/Views/Cir/Cir/Generator.ascx"); %>
                                        </div>
                                        <div id="SimplifiedCIR" class="templateItem" style="display: none;">
                                            <% Html.RenderPartial("~/Views/Cir/Cir/SimplifiedCIR.ascx"); %>
                                        </div>
                                    </div>
                                    <%--Blade Specific fields--%>

                                    <h3 id="cirImagesLink" class="defaultItem"><a href="javascript:void(0);">Images <i class="fa fa-upload" style="float: right">&nbsp;</i></a></h3>
                                    <%--Cir image section--%>
                                    <div id="cirImageSection" style="display: none;">
                                        <% Html.RenderPartial("~/Views/Cir/Cir/Pictures.ascx"); %>
                                    </div>
                                    <%--Cir image section--%>

                                    <h3 id="cirDynamicTableLink" class="defaultDT"><a href="javascript:void(0);">Dynamic Table <i class="fa fa-list-alt" style="float: right">&nbsp;</i></a></h3>
                                    <%--Cir image section--%>
                                    <div id="cirDynamicTableSection" style="display: none;">
                                        <% Html.RenderPartial("~/Views/Cir/Cir/DynamicTable.ascx"); %>
                                    </div>
                                    <%--Simplified Cir Accord sections - Start--%>
                                    <h3 id="cirDynamicAccord1" class="simplifiedDT" style="display: none;"><a href="javascript:void(0);"><i class="fa fa-puzzle-piece" style="float: right">&nbsp;</i></a></h3>

                                    <div id="cirDynamicAccordSection1" style="display: none;">
                                        <% Html.RenderPartial("~/Views/Cir/Cir/DynamicControls.ascx"); %>
                                    </div>

                                    <h3 id="cirDynamicAccord2" class="simplifiedDT" style="display: none;"><a href="javascript:void(0);"><i class="fa fa-puzzle-piece" style="float: right">&nbsp;</i></a></h3>

                                    <div id="cirDynamicAccordSection2" style="display: none;">
                                        <% Html.RenderPartial("~/Views/Cir/Cir/DynamicControls.ascx"); %>
                                    </div>

                                    <h3 id="cirDynamicAccord3" class="simplifiedDT" style="display: none;"><a href="javascript:void(0);"><i class="fa fa-puzzle-piece" style="float: right">&nbsp;</i></a></h3>

                                    <div id="cirDynamicAccordSection3" style="display: none;">
                                        <% Html.RenderPartial("~/Views/Cir/Cir/DynamicControls.ascx"); %>
                                    </div>

                                    <h3 id="cirDynamicAccord4" class="simplifiedDT" style="display: none;"><a href="javascript:void(0);"><i class="fa fa-puzzle-piece" style="float: right">&nbsp;</i></a></h3>

                                    <div id="cirDynamicAccordSection4" style="display: none;">
                                        <% Html.RenderPartial("~/Views/Cir/Cir/DynamicControls.ascx"); %>
                                    </div>

                                    <h3 id="cirDynamicAccord5" class="simplifiedDT" style="display: none;"><a href="javascript:void(0);"><i class="fa fa-puzzle-piece" style="float: right">&nbsp;</i></a></h3>

                                    <div id="cirDynamicAccordSection5" style="display: none;">
                                        <% Html.RenderPartial("~/Views/Cir/Cir/DynamicControls.ascx"); %>
                                    </div>

                                    <h3 id="cirDynamicAccord6" class="simplifiedDT" style="display: none;"><a href="javascript:void(0);"><i class="fa fa-puzzle-piece" style="float: right">&nbsp;</i></a></h3>

                                    <div id="cirDynamicAccordSection6" style="display: none;">
                                        <% Html.RenderPartial("~/Views/Cir/Cir/DynamicControls.ascx"); %>
                                    </div>
                                    <%--Simplified Cir Accord section - Start--%>
                                    <h3 id="cirSBURecommendationLink" class="simplifiedDefault"><a href="javascript:void(0);">SBU Recommendation <i class="fa fa-check-square-o" style="float: right">&nbsp;</i></a></h3>
                                    <%--Cir image section--%>
                                    <div id="cirSBURecommendationSection" style="display: none;">
                                        <% Html.RenderPartial("~/Views/Cir/Cir/SbuRecommendation.ascx"); %>
                                    </div>
                                    <%--Cir image section--%>

                                    <h3 id="cirSubmitLink"><a href="javascript:void(0);">Submit <i class="fa fa-trophy" style="float: right">&nbsp;</i></a> </h3>
                                    <%--Cir Submit Section--%>
                                    <div id="cirSubmitSection" style="display: none;">
                                        <fieldset>
                                            <legend class="defaultItem">Submit CIR</legend>
                                            <div class="form-group">
                                                <div class="col-xs-12">
                                                    <span id="spanSuccessMessage" class="successSpan defaultItem">CIR has been created/updated successfully. 
                                    <br />
                                                        You need to submit the CIR for further process.
                                    <br />
                                                    </span>
                                                </div>
                                            </div>
                                            <div class="form-group">
                                                <div class="col-xs-12" style="text-align: right;">
                                                    <a href="javascript:void(0);" id="linkSaveCIR" class="btn btn-primary">Save as Draft</a>
                                                    <% if (Request.QueryString["remotecirID"] != null)
                                                        {%>
                                                    <a href="javascript:void(0);" id="linkSubmitCIR" class="btn btn-primary">Update CIR</a>
                                                    <a href="javascript:void(0);" id="linkSubmitApproveCIR" class="btn btn-primary administrator bircreator gircreator gbxircreator member" style="display: inline-block !important">Update & Approve CIR</a>

                                                    <% }
                                                        else
                                                        { %>
                                                    <a href="javascript:void(0);" id="linkSubmitCIR" class="btn btn-primary">Submit CIR</a>
                                                    <a href="javascript:void(0);" id="linkSubmitApproveCIR" class="btn btn-primary administrator bircreator gircreator gbxircreator member" style="display: inline-block !important">Submit & Approve CIR</a>

                                                    <script type="text/javascript">
                                                        if (hasRole("Administrator") || hasRole("Member")) {
                                                            document.getElementById("linkSubmitCIR").innerHTML = ((_cacheCirID > 0) ? "Update CIR" : "Submit CIR");
                                                            document.getElementById("linkSubmitApproveCIR").innerHTML = ((_cacheCirID > 0) ? "Update & Approve CIR" : "Submit & Approve CIR");
                                                            $("#linkSubmitApproveCIR").show();
                                                        }
                                                        else {
                                                            $("#linkSubmitApproveCIR").hide();
                                                        }
                                                    </script>
                                                    <%} %>
                                                </div>
                                            </div>
                                        </fieldset>
                                        <%--<div class="form-group">
                                                <div class="col-xs-12" style="text-align: right;">
                                                    <a href="javascript:void(0);" id="linkSaveCIR" class="btn btn-primary">Save as Draft</a>
                                                    <% if (Request.QueryString["remotecirID"] != null)
                                                        {%>
                                                    <a href="javascript:void(0);" id="linkSubmitCIR" class="btn btn-primary">Update CIR</a>
                                                    <% }
                                                        else
                                                        { %>
                                                    <a href="javascript:void(0);" id="linkSubmitCIR" class="btn btn-primary">Submit CIR</a>
                                                    <script type="text/javascript">
                                                        document.getElementById("linkSubmitCIR").innerHTML = ((_cacheCirID > 0) ? "Update CIR" : "Submit CIR");
                                                    </script>
                                                    <%} %>
                                                </div>
                                            </div>
                                        </fieldset>--%>
                                        <%--Cir Submit Section--%>
                                    </div>


                                    <div id="header-fixed"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- </div> -->
            </div>
        </form>
    </section>
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
    <script type="text/javascript">

        var lstSwipers = [];
        var FileToUpload = [];
        var ImageListRendered = {
            Images: []
        };


        function handleFileSelect(evt) {
            var files = evt.target.files; // FileList object
            //LoadImageUI(files);
            LoadUI(files);
        }

        function showThumbnail(fileListArray, inputId) {
            waitingDialog.show('Uploading Images..', { dialogSize: 'sm', progressType: 'primary' });
            var fileListLength = fileListArray.length;
            var files = [];
            if (fileListLength > 0) {
                files = Array.from(fileListArray);
                if (fileListArray[0].imageId == undefined) {
                    files = files.sort(SortByName);
                }
            }

            var iVar = 0;
            for (var i = 0; i < files.length; i++) {
                var inputType = '';
                var seqNo = i;
                switch (inputId) {
                    case 'imagedropA':
                        inputType = 1;
                        seqNo = $("#list1 div[data-fileid]").length > 0 ? $("#list1 div[data-fileid]").length : 0;
                        break;
                    case 'imagedropB':
                        inputType = 2;
                        seqNo = $("#list2 div[data-fileid]").length > 0 ? $("#list2 div[data-fileid]").length : 0;
                        break;
                    case 'imagedropC':
                        inputType = 3;
                        seqNo = $("#list3 div[data-fileid]").length > 0 ? $("#list3 div[data-fileid]").length : 0;
                        break;
                    case 'imagedropD':
                        inputType = 4;
                        seqNo = $("#list4 div[data-fileid]").length > 0 ? $("#list4 div[data-fileid]").length : 0;
                        break;
                    case 'imagedropE':
                        inputType = 5;
                        seqNo = $("#list5 div[data-fileid]").length > 0 ? $("#list5 div[data-fileid]").length : 0;
                        break;
                    case 'imagedropF':
                        inputType = 6;
                        seqNo = $("#list6 div[data-fileid]").length > 0 ? $("#list6 div[data-fileid]").length : 0;
                        break;
                    default:
                        seqNo = $("#list div[data-fileid]").length > 0 ? $("#list div[data-fileid]").length : i;
                        break;
                }

                var file = files[i]
                var imageType = /image.*/
                if (!file.type.match(imageType)) {
                    console.log("Not an Image");
                    continue;
                }
                var getPath = '';
                if (file.filledDataString != undefined) {
                    getPath = file.filledDataString;
                }
                file.id = inputId;
                var fileIndex = FileToUpload.length;
                file.position = defaultValue;
                FileToUpload.push(file);
                var div = document.createElement('div');
                div.setAttribute('data-fileid', seqNo);
                div.setAttribute('data-length', fileIndex);
                div.setAttribute('data-defaultValue', defaultValue);
                div.setAttribute('data-inputId', inputId);
                var imageId = (file.imageId) ? file.imageId : 0;
                div.setAttribute('data-imageId', imageId);

                var height = 100;
                var width = 100;
                var imageNameDesc = decodeURIComponent(encodeURI(file.name));
                var imageName = '';
                var imageDescription = '';
                if (imageNameDesc != '' && imageNameDesc.split('##').length == 2) {
                    imageName = imageNameDesc.split('##')[0];
                    imageDescription = imageNameDesc.split('##')[1];
                }
                else (imageNameDesc != '' && imageNameDesc.split('##').length == 1)
                {
                    imageName = imageNameDesc.split('##')[0];
                }

                var imgNameLabel = document.createElement('div');
                imgNameLabel.innerHTML = "File Name: ";
                imgNameLabel.setAttribute("style", "border:0;box-shadow:none;float:left;min-width:62px!important;")

                var imgName = document.createElement('div');
                imgName.className = "imageName";
                imgName.innerHTML = imageName;//decodeURIComponent(escape(tf.name));
                imgName.setAttribute("style", "border:0;box-shadow:none;word-wrap:break-word;word-break: break-all;")

                var desc = document.createElement('textarea');
                desc.className = "imageDescription"
                desc.type = "text";
                desc.name = "desc";
                //desc.className = "desc";
                desc.setAttribute('title', 'Image description');

                desc.setAttribute('maxlength', '1000');
                desc.setAttribute('placeholder', 'Image description');
                desc.setAttribute('style', 'rows:3; margin:5px 5px 0px 0px; min-height:57px!important;width:50%;border-radius: 4px;box-shadow: 1px 1px 2px #999;');
                desc.value = imageDescription;//decodeURIComponent(escape(tf.name));

                var order = document.createElement('input');
                order.type = "number";
                order.name = "order";
                order.className = "order";
                order.setAttribute('title', 'Image order index');
                order.setAttribute('placeholder', 'Image order');
                order.value = escape(seqNo);

                var del = document.createElement('button');
                del.type = "button";
                del.name = "del";
                del.className = "del";
                // del.value = "x";
                del.setAttribute('title', 'Remove this image');
                del.innerHTML = '<i class="glyphicon glyphicon-remove" id="' + inputId + '" style=" color: #c74d4d;"></i>';
                del.addEventListener('click', handleFileDelete, false);

                var up = document.createElement('button');
                up.type = "button";
                up.name = "up";
                up.className = "up";
                // up.value = "x";
                up.setAttribute('title', 'Move Up');
                up.innerHTML = '<i class="glyphicon glyphicon-chevron-up" id="' + inputId + '" style=" color: #444;"></i>';
                up.addEventListener('click', handleFileUp, false);

                var dn = document.createElement('button');
                dn.type = "button";
                dn.name = "dn";
                dn.className = "dn";
                // dn.value = "x";
                dn.setAttribute('title', 'Move Down');
                dn.innerHTML = '<i class="glyphicon glyphicon-chevron-down" id="' + inputId + '" style=" color: #444;"></i>';
                dn.addEventListener('click', handleFileDn, false);

                div.setAttribute('style', 'cursor:-webkit-grab;');         

                div.innerHTML = ['<img id="image_' + defaultValue + '" class="thumb" style="height: ' + height + 'px; width: ' + width + 'px;"', 'onclick="openModal(\'', inputId, '\');', 'currentSlide(\'', inputId, '\',', defaultValue, ');"', 'src="', getPath, '" title="', imageNameDesc, '" data-defaultImageId="', defaultValue, '"/>'].join('');
                div.appendChild(desc);
                div.appendChild(order);
                div.appendChild(del);
                div.appendChild(up);
                div.appendChild(dn);

                div.appendChild(imgNameLabel);
                div.appendChild(imgName);


                if (inputType != '') {
                    $('#list' + inputType).append(div);
                }
                else {
                    $('#list').append(div);
                }

                //GetImagePerPreview(fileIndex, seqNo, tf.src).done(function (response) {
                var imageSeq = seqNo;
                var div1 = document.createElement('div');
                div1.setAttribute('id', imageSeq);
                div1.setAttribute('class', 'swiper-slide');
                div1.setAttribute('data-defaultValue', defaultValue);
                div1.id = imageSeq;
                div1.innerHTML = ['<img id="previmage_' + defaultValue + '" style="height:  100%; width:100%;" src="' + getPath + '" name="' + imageNameDesc + '" title="' + imageNameDesc + '"/>'].join('');
                var div2 = document.createElement('div');
                div2.setAttribute('class', 'subtitle');
                div2.id = 'subtitle' + imageSeq;
                var imageDetail = '<font color="white" style="background-color: rgba(0%, 0%, 92%, 0.2); font-weight:bold;">' + imageName + '</font><br/>';
                imageDetail = imageDetail + '<font color="white" id="' + imageSeq + '" style="background-color: rgba(0%, 0%, 92%, 0.2)">' + imageNameDesc + '</font>';
                div2.innerHTML = imageDetail;
                div1.appendChild(div2);
                var prevlist;
                if (inputType != '') {
                    $('#prevlist' + inputType).append(div1);
                    prevlist = document.getElementById('prevlist' + inputType);
                }
                else {
                    $('#prevlist').append(div1);
                    prevlist = document.getElementById('prevlist');
                }

                if (getPath == '') {
                    var reader = new FileReader();
                    reader.onload = (function (tf) {
                        return function (e) {
                            var imageObj = new Image();
                            imageObj.onload = (function (fileObj) {
                                return function () {
                                    var canvasSm = document.createElement("canvas");
                                    var MWIDTH = 100;
                                    var MHEIGHT = 100;
                                    var widthSm = imageObj.width;
                                    var heightSm = imageObj.height;

                                    if (widthSm > heightSm) {
                                        if (widthSm > MWIDTH) {
                                            heightSm *= MWIDTH / widthSm;
                                            widthSm = MWIDTH;
                                        }
                                    } else {
                                        if (heightSm > MHEIGHT) {
                                            widthSm *= MHEIGHT / heightSm;
                                            heightSm = MHEIGHT;
                                        }
                                    }
                                    canvasSm.width = widthSm;
                                    canvasSm.height = heightSm;

                                    var ctxSm = canvasSm.getContext("2d");
                                    ctxSm.drawImage(imageObj, 0, 0, widthSm, heightSm);
                                    var dataSrcSm = canvasSm.toDataURL("image/jpeg");
                                    $("#image_" + fileObj.position).attr("src", dataSrcSm);
                                    var canvas = document.createElement("canvas");
                                    var MAX_WIDTH = 1152;
                                    var MAX_HEIGHT = 864;
                                    var width = imageObj.width;
                                    var height = imageObj.height;

                                    if (width > height) {
                                        if (width > MAX_WIDTH) {
                                            height *= MAX_WIDTH / width;
                                            width = MAX_WIDTH;
                                        }
                                    } else {
                                        if (height > MAX_HEIGHT) {
                                            width *= MAX_HEIGHT / height;
                                            height = MAX_HEIGHT;
                                        }
                                    }
                                    canvas.width = width;
                                    canvas.height = height;
                                    var ctx = canvas.getContext("2d");
                                    ctx.drawImage(imageObj, 0, 0, width, height);

                                    var dataurl = canvas.toDataURL("image/jpeg");
                                    $("#previmage_" + fileObj.position).attr("src", dataurl);
                                    iVar++;
                                    if (iVar == fileListLength) {
                                        waitingDialog.hide();
                                    }
                                }
                            }(tf));
                            // e.preventDefault();
                            //e.stopPropagation();
                            imageObj.src = window.URL.createObjectURL(tf);
                            //imageObj.src = e.target.result;
                        };
                    }(file))
                    reader.readAsDataURL(file);
                }
                defaultValue++;
            }
        }

        function LoadUI(files, inputId) {// Loop through the FileList and render image files as thumbnails.
            var IsPlateTypeVisible = false;
            $('#PlateType').hide();
            if (!$('#chkIsPlateTypeNotPossible').is(':checked') && IsPlateTypeVisible == false) {
                $('#PlateType').show();
                IsPlateTypeVisible = true;
            }
            showThumbnail(files, inputId);
        }

        /* Listener for multiple files input element. */
        document.getElementById('files').addEventListener('change', handleFileSelect, false);
        document.getElementById('files2').addEventListener('change', handleFileSelect, false);
        document.getElementById('files3').addEventListener('change', handleFileSelect, false);
        document.getElementById('files4').addEventListener('change', handleFileSelect, false);
        document.getElementById('files5').addEventListener('change', handleFileSelect, false);
        document.getElementById('files6').addEventListener('change', handleFileSelect, false);
        function handleFileDelete(evt) {
            var btn = evt.target;
            var inputId = evt.target.id;
            var OBJItem;
            if ($(btn)[0].nodeName == "I")
                OBJItem = $(btn).parent().parent();
            else
                OBJItem = $(btn).parent();
            var idstr = OBJItem.attr('data-fileid');

            var idLen = parseInt(OBJItem.attr('data-length'));
            var iDefaultValue = parseInt(OBJItem.attr('data-defaultValue'));
            FileToUpload = $.grep(FileToUpload, function (e) {
                return e != undefined && e.position != iDefaultValue;
            });
            //FileToUpload.splice(idLen, 1);
            inputId = OBJItem.attr('data-inputId');
            OBJItem.fadeOut("slow", function () {
                OBJItem.remove();
                if (inputId == 'imagedropA') {
                    $('#list1').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);
                    });
                    $('#prevlist1 .swiper-slide').each(function () {
                        //if (this.id === (idstr).toString()) {
                        if ($(this).attr('data-defaultValue') == iDefaultValue) {
                            //e.preventDefault();
                            $(this).remove();
                        }
                    });
                    //  ReInitializeSwiper();
                    $('#prevlist1 .swiper-slide').each(function (index) {
                        this.id = index;
                    });
                    $('#prevlist1 .swiper-slide').children('div.subtitle').each(function (index) {
                        this.setAttribute('id', 'subtitle' + index);
                    });
                }
                if (inputId == 'imagedropB') {
                    $('#list2').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);
                    });
                    $('#prevlist2 .swiper-slide').each(function () {
                        //if (this.id === (idstr).toString()) {
                        if ($(this).attr('data-defaultValue') == iDefaultValue) {
                            //e.preventDefault();
                            $(this).remove();
                        }
                    });
                    //  ReInitializeSwiper();
                    $('#prevlist2 .swiper-slide').each(function (index) {
                        this.id = index;
                    });
                    $('#prevlist2 .swiper-slide').children('div.subtitle').each(function (index) {
                        this.setAttribute('id', 'subtitle' + index);
                    });
                }
                if (inputId == 'imagedropC') {
                    $('#list3').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);
                    });
                    $('#prevlist3 .swiper-slide').each(function () {
                        //if (this.id === (idstr).toString()) {
                        if ($(this).attr('data-defaultValue') == iDefaultValue) {
                            //e.preventDefault();
                            $(this).remove();
                        }
                    });
                    //  ReInitializeSwiper();
                    $('#prevlist3 .swiper-slide').each(function (index) {
                        this.id = index;
                    });
                    $('#prevlist3 .swiper-slide').children('div.subtitle').each(function (index) {
                        this.setAttribute('id', 'subtitle' + index);
                    });
                }
                if (inputId == 'imagedropD') {
                    $('#list4').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);
                    });
                    $('#prevlist4 .swiper-slide').each(function () {
                        //if (this.id === (idstr).toString()) {
                        if ($(this).attr('data-defaultValue') == iDefaultValue) {
                            //e.preventDefault();
                            $(this).remove();
                        }
                    });
                    //   ReInitializeSwiper();
                    $('#prevlist4 .swiper-slide').each(function (index) {
                        this.id = index;
                    });
                    $('#prevlist4 .swiper-slide').children('div.subtitle').each(function (index) {
                        this.setAttribute('id', 'subtitle' + index);
                    });
                }
                if (inputId == 'imagedropE') {
                    $('#list5').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);

                    })
                    $('#prevlist5 .swiper-slide').each(function () {
                        //if (this.id === (idstr).toString()) {
                        if ($(this).attr('data-defaultValue') == iDefaultValue) {
                            //e.preventDefault();
                            $(this).remove();
                        }
                    });
                    //  ReInitializeSwiper();
                    $('#prevlist5 .swiper-slide').each(function (index) {
                        this.id = index;
                    });
                    $('#prevlist5 .swiper-slide').children('div.subtitle').each(function (index) {
                        this.setAttribute('id', 'subtitle' + index);
                    });
                }
                if (inputId == 'imagedropF') {
                    $('#list6').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);

                    })
                    $('#prevlist6 .swiper-slide').each(function () {
                        //if (this.id === (idstr).toString()) {
                        if ($(this).attr('data-defaultValue') == iDefaultValue) {
                            //e.preventDefault();
                            $(this).remove();
                        }
                    });
                    //  ReInitializeSwiper();
                    $('#prevlist6 .swiper-slide').each(function (index) {
                        this.id = index;
                    });
                    $('#prevlist6 .swiper-slide').children('div.subtitle').each(function (index) {
                        this.setAttribute('id', 'subtitle' + index);
                    });
                }
                if (inputId == 'imagedropDefault') {
                    var IsPlateTypeVisible = false;
                    $('#PlateType').hide();
                    $('#list').children('div').each(function (index) {
                        //$(this).data('fileid', index);
                        this.setAttribute('data-fileid', index);

                        if (!$('#chkIsPlateTypeNotPossible').is(':checked') && IsPlateTypeVisible == false) {
                            $('#PlateType').show();
                            IsPlateTypeVisible = true;
                        }
                    });
                    $('#prevlist .swiper-slide').each(function () {
                        //if (this.id === (idstr).toString()) {
                        if ($(this).attr('data-defaultValue') == iDefaultValue) {
                            //e.preventDefault();
                            $(this).remove();
                        }
                    });
                    // ReInitializeSwiper();
                    $('#prevlist .swiper-slide').each(function (index) {
                        this.id = index;
                    });
                    $('#prevlist .swiper-slide').children('div.subtitle').each(function (index) {
                        this.setAttribute('id', 'subtitle' + index);
                    });
                }
            });

        }

        function handleFileUp(evt) {
            var btn = evt.target;
            var inputId = evt.target.id;
            var OBJItem;
            var OBJItemOther;
            if ($(btn)[0].nodeName == "I") {
                OBJItem = $(btn).parent().parent();
                OBJItemOther = $(btn).parent().parent().prev();
            }
            else {
                OBJItem = $(btn).parent();
                OBJItemOther = $(btn).parent().prev();
            }

            inputId = OBJItem.attr('data-inputId');
            var idstr = OBJItem.attr('data-fileid');
            var preIdstr = OBJItemOther.attr('data-fileid');
            var idLen = parseInt(OBJItem.attr('data-length'));
            if (preIdstr == undefined || idstr == undefined) {
                return;
            }
            //  var indx = parseInt(idLen);
            var indx = 0;
            for (var i = 0; i < FileToUpload.length; ++i) {
                if (FileToUpload[i].position == OBJItem.attr('data-defaultValue')) {
                    indx = i;
                    break;
                }
            }
            //var indx = parseInt(FileToUpload.findIndex(p => p.position == OBJItem.attr('data-defaultValue')));
            var obj1 = FileToUpload[indx];
            FileToUpload.splice(indx, 1);
            FileToUpload.splice(indx - 1, 0, obj1);

            OBJItem.fadeOut("fast", function () {
                OBJItem.insertBefore(OBJItemOther);
                OBJItem.fadeIn("fast", function () {
                    if (inputId == 'imagedropA') {
                        $("#prevlist1 #" + idstr + ".swiper-slide").insertBefore($("#prevlist1 #" + preIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list1').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist1').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropB') {
                        $("#prevlist2 #" + idstr + ".swiper-slide").insertBefore($("#prevlist2 #" + preIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list2').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist2').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropC') {
                        $("#prevlist3 #" + idstr + ".swiper-slide").insertBefore($("#prevlist3 #" + preIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list3').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist3').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropD') {
                        $("#prevlist4 #" + idstr + ".swiper-slide").insertBefore($("#prevlist4 #" + preIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list4').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist4').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropE') {
                        $("#prevlist5 #" + idstr + ".swiper-slide").insertBefore($("#prevlist5 #" + preIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list5').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist5').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropF') {
                        $("#prevlist6 #" + idstr + ".swiper-slide").insertBefore($("#prevlist6 #" + preIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list6').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist6').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropDefault') {
                        $("#prevlist #" + idstr + ".swiper-slide").insertBefore($("#prevlist #" + preIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                });
            });
        }
        function handleFileDn(evt) {
            var btn = evt.target;
            var inputId = evt.target.id;
            var OBJItem;
            var OBJItemOther;
            if ($(btn)[0].nodeName == "I") {
                OBJItem = $(btn).parent().parent();
                OBJItemOther = $(btn).parent().parent().next();
            }
            else {
                OBJItem = $(btn).parent();
                OBJItemOther = $(btn).parent().next();
            }

            inputId = OBJItem.attr('data-inputId');
            var idstr = OBJItem.attr('data-fileid');
            var nextIdstr = OBJItemOther.attr('data-fileid');
            var idLen = parseInt(OBJItem.attr('data-length'));
            if (nextIdstr == undefined || idstr == undefined) //|| idstr == FileToUpload.length - 1)
            {
                return;
            }
            //  var indx = parseInt(idLen);
            var indx = 0;
            for (var i = 0; i < FileToUpload.length; ++i) {
                if (FileToUpload[i].position == OBJItem.attr('data-defaultValue')) {
                    indx = i;
                    break;
                }
            }
            //var indx = parseInt(FileToUpload.findIndex(p => p.position == OBJItem.attr('data-defaultValue')));
            var obj1 = FileToUpload[indx];
            FileToUpload.splice(indx, 1);
            FileToUpload.splice(indx + 1, 0, obj1);

            OBJItem.fadeOut("fast", function () {
                OBJItem.insertAfter(OBJItemOther);
                OBJItem.fadeIn("fast", function () {
                    if (inputId == 'imagedropA') {
                        $("#prevlist1 #" + idstr + ".swiper-slide").insertAfter($("#prevlist1 #" + nextIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list1').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist1').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropB') {
                        $("#prevlist2 #" + idstr + ".swiper-slide").insertAfter($("#prevlist2 #" + nextIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list2').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist2').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropC') {
                        $("#prevlist3 #" + idstr + ".swiper-slide").insertAfter($("#prevlist3 #" + nextIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list3').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist3').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropD') {
                        $("#prevlist4 #" + idstr + ".swiper-slide").insertAfter($("#prevlist4 #" + nextIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list4').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist4').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropE') {
                        $("#prevlist5 #" + idstr + ".swiper-slide").insertAfter($("#prevlist5 #" + nextIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list5').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist5').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropF') {
                        $("#prevlist6 #" + idstr + ".swiper-slide").insertAfter($("#prevlist6 #" + nextIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list6').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist6').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                    if (inputId == 'imagedropDefault') {
                        $("#prevlist #" + idstr + ".swiper-slide").insertAfter($("#prevlist #" + nextIdstr + ".swiper-slide"));
                        ReInitializeSwiper();
                        $('#list').children('div').each(function (index) {
                            this.setAttribute('data-fileid', index);
                            $(this).find('.order').val(index);
                        });
                        $('#prevlist').children('div').each(function (index) {
                            this.setAttribute('id', index);
                            $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                        });
                    }
                });
            });
        }
        function loadImageReader(files, callback, idx) {
            var InputFileId = files[0].id;
            // Closure to capture the file information.
            var jsonData = {};
            var valuecontainer;
            if (InputFileId == 'imagedropA') {
                jsonData['imageDataString'] = $("#prevlist1 #" + idx + ".swiper-slide").find("img").first().attr("src");
                jsonData['flangNo'] = 1;
                valuecontainer = $('#list1 div[data-fileid="' + idx + '"]').first();
            }
            if (InputFileId == 'imagedropB') {
                jsonData['imageDataString'] = $("#prevlist2 #" + idx + ".swiper-slide").find("img").first().attr("src");
                jsonData['flangNo'] = 2;
                valuecontainer = $('#list2 div[data-fileid="' + idx + '"]').first();
            }
            if (InputFileId == 'imagedropC') {
                jsonData['imageDataString'] = $("#prevlist3 #" + idx + ".swiper-slide").find("img").first().attr("src");
                jsonData['flangNo'] = 3;
                valuecontainer = $('#list3 div[data-fileid="' + idx + '"]').first();
            }
            if (InputFileId == 'imagedropD') {
                jsonData['imageDataString'] = $("#prevlist4 #" + idx + ".swiper-slide").find("img").first().attr("src");
                jsonData['flangNo'] = 4;
                valuecontainer = $('#list4 div[data-fileid="' + idx + '"]').first();

            }
            if (InputFileId == 'imagedropE') {
                jsonData['imageDataString'] = $("#prevlist5 #" + idx + ".swiper-slide").find("img").first().attr("src");
                jsonData['flangNo'] = 5;
                valuecontainer = $('#list5 div[data-fileid="' + idx + '"]').first();

            }
            if (InputFileId == 'imagedropF') {
                jsonData['imageDataString'] = $("#prevlist6 #" + idx + ".swiper-slide").find("img").first().attr("src");
                jsonData['flangNo'] = 6;
                valuecontainer = $('#list6 div[data-fileid="' + idx + '"]').first();

            }
            jsonData['imageDescription'] = $(valuecontainer).find('.imageName').text() + "##" + $(valuecontainer).find('.imageDescription').val();
            jsonData['imageOrder'] = $(valuecontainer).find('.order').val();
            jsonData['imageId'] = $(valuecontainer).attr('data-imageId');
            jsonData['inspectionDesc'] = $('#txtImgInspectionDescription').val();
            ImageListRendered.Images.push(jsonData);
            if (ImageListRendered.Images.length == FileToUpload.length) {
                callback(ImageListRendered);
            }
        }

        function SortById(a, b) {
            var aId = a.id.toLowerCase();
            var bId = b.id.toLowerCase();
            return ((aId < bId) ? -1 : ((aId > bId) ? 1 : 0));
        }
        function SortByName(a, b) {
            var aName = a.name.toLowerCase();
            var bName = b.name.toLowerCase();
            return ((aName < bName) ? -1 : ((aName > bName) ? 1 : 0));
        }


        function GetJsonFromSimplifiedFile(callback) {
            ImageListRendered = {
                Images: []
            };
            if (FileToUpload.length == 0) {
                callback(ImageListRendered);
            }
            var index = 0;
            var sortedFileToUpload = FileToUpload.sort(SortById);
            var fileListLength = sortedFileToUpload.length;
            var i = 0;
            for (var i = 0; i < fileListLength; i++) {
                //  var refreshId = setInterval(function () {
                var f = sortedFileToUpload[i];
                //for (i = 0; i < sortedFileToUpload.length; i++) {
                var fileImageToLoad = [];
                if (i > 0 && sortedFileToUpload[i].id != sortedFileToUpload[i - 1].id) {
                    index = 0;
                }
                fileImageToLoad.push(sortedFileToUpload[i]);
                loadImageReader(fileImageToLoad, callback, index);
                index++;
                // }

                //i++;
                //if (i === fileListLength) {
                //    clearInterval(refreshId);
                //}
                //}, 1000);
            }

        }

        function LoadDynamicImagesFromJsonObject(ImageJsonObject) {
            //imgobj.flangNo
            FileToUpload = [];
            var FileFromJson = [];

            for (var i = 0, f; imgObj = ImageJsonObject[i]; i++) {

                // $('#txtImgInspectionDescription' + imgObj.flangNo).val((imgObj.inspectionDesc) ? imgObj.inspectionDesc : "");               
                var filobj = dataImageURItoBlob(imgObj.imageDataString, imgObj.imageDescription, imgObj.imageId, imgObj.flangNo);
                FileFromJson.push(filobj);

            }
            for (i = 0; i < FileFromJson.length; i++) {
                var inputId = undefined;
                var fileImageToLoad = [];
                if (FileFromJson[i].flangNo == 1) { inputId = 'imagedropA'; }
                if (FileFromJson[i].flangNo == 2) { inputId = 'imagedropB'; }
                if (FileFromJson[i].flangNo == 3) { inputId = 'imagedropC'; }
                if (FileFromJson[i].flangNo == 4) { inputId = 'imagedropD'; }
                if (FileFromJson[i].flangNo == 5) { inputId = 'imagedropE'; }
                if (FileFromJson[i].flangNo == 6) { inputId = 'imagedropF'; }
                fileImageToLoad.push(FileFromJson[i])
                //LoadImageUI(fileImageToLoad, inputId);
                LoadUI(fileImageToLoad, inputId);
                if(i==FileFromJson.length - 1 )
                {
                    waitingDialog.hide();
                }
            }
        }
        function dataImageURItoBlob(dataURI, imageDescription, id, flangNo) {
            // convert base64/URLEncoded data component to raw binary data held in a string
            var byteString;
            if (dataURI.split(',')[0].indexOf('base64') >= 0)
                byteString = atob(dataURI.split(',')[1]);
            else
                byteString = unescape(dataURI.split(',')[1]);

            // separate out the mime component
            var mimeString = dataURI.split(',')[0].split(':')[1].split(';')[0];

            // write the bytes of the string to a typed array
            var ia = new Uint8Array(byteString.length);
            for (var i = 0; i < byteString.length; i++) {
                ia[i] = byteString.charCodeAt(i);
            }
            var blob = new Blob([ia], { type: mimeString });
            blob.lastModifiedDate = new Date();
            blob.name = imageDescription;
            blob.imageId = (id) ? id : 0;
            blob.flangNo = flangNo;
            blob.filledDataString = dataURI;
            return blob;
        }

        function ReInitializeSwiper() {
            lstSwipers = [];

            //swiper.update();           
            $('.swiper-container').each(function () {
                var objSwiper = new Swiper($(this), {
                    pagination: $(this).find('.swiper-pagination'),
                    paginationClickable: $(this).find('.swiper-pagination'),
                    nextButton: $(this).find('.swiper-button-next'),
                    prevButton: $(this).find('.swiper-button-prev'),
                    zoom: true,
                    keyboardControl: true,
                    slidesPerView: 1,

                });
                lstSwipers.push(objSwiper);
                objSwiper.update();
            });
        }

        //function GetImagePerPreview(i, seq,imgSrc) {
        //    var deferredObject = $.Deferred();
        //    try {               
        //                        var jsonData = {};
        //                        jsonData.ImageDataString = imgSrc;
        //                        var valuecontainer;
        //                        var itemType = '';
        //                        if (FileToUpload[i].id == 'imagedropA') {
        //                            valuecontainer = $('#list1 div[data-fileid="' + seq + '"]').first();
        //                            itemType = '1';
        //                        }
        //                        if (FileToUpload[i].id == 'imagedropB') {
        //                            valuecontainer = $('#list2 div[data-fileid="' + seq + '"]').first();
        //                            itemType = '2';
        //                       }
        //                        if (FileToUpload[i].id == 'imagedropC') {
        //                            valuecontainer = $('#list3 div[data-fileid="' + seq + '"]').first();
        //                            itemType = '3';
        //                       }
        //                        if (FileToUpload[i].id == 'imagedropD') {
        //                            valuecontainer = $('#list4 div[data-fileid="' + seq + '"]').first();
        //                            itemType = '4';
        //                       }
        //                        if (FileToUpload[i].id == 'imagedropE') {
        //                            valuecontainer = $('#list5 div[data-fileid="' + seq + '"]').first();
        //                             itemType = '5';
        //                      }
        //                        if (FileToUpload[i].id == 'imagedropF') {
        //                            valuecontainer = $('#list6 div[data-fileid="' + seq + '"]').first();
        //                            itemType = '6';
        //                        }
        //                        if (FileToUpload[i].id == 'imagedropDefault') {
        //                            valuecontainer = $('#list div[data-fileid="' + seq + '"]').first();
        //                        }
        //                        // var valuecontainer = $('#list1 div[data-fileid="' + seq + '"]').first();
        //                        jsonData.ImageDescription = $(valuecontainer).find('.imageName').text() + "##" + $(valuecontainer).find('.imageDescription').val();//$(valuecontainer).find('.desc').val();
        //                        jsonData.ImageOrder = $(valuecontainer).find('.order').val();
        //                        jsonData.ImageId = $(valuecontainer).attr('data-imageId');
        //                        jsonData.ImageName = $(valuecontainer).find('.imageName').text();
        //                        jsonData.ImageNameDesc = $(valuecontainer).find('.imageNameDesc').text();
        //                        jsonData.ImageSequence = seq;
        //                        jsonData.imageType = itemType;
        //                        jsonData.defaultValue = $(valuecontainer).attr('data-defaultValue');
        //                        deferredObject.resolve(jsonData);                           
        //    }
        //    catch (e) {
        //        deferredObject.reject();
        //    }
        //    return deferredObject.promise();
        //}

        (function (window) {
            function triggerImagesCallback(e, callback) {
                NotifyCirMessage("", '- Images can be dragged for reordering.<br /> - Slide images for previews.<br /> - Image descriptions are editable.', "info", 8000);
                if (!callback || typeof callback !== 'function') {
                    return;
                }
                var files;
                if (e.dataTransfer) {
                    files = e.dataTransfer.files;
                } else if (e.target) {
                    files = e.target.files;
                }
                callback.call(null, files);
            }
            function makeImagesDroppable(ele, callback) {
                //  NotifyCirMessage("", 'Images are draggable for reordering.slide images for previews.', "info");
                var input = document.createElement('input');
                input.setAttribute('type', 'file');
                var inputId = ele.className.split(" ")[1];
                input.setAttribute('id', inputId)
                input.setAttribute('multiple', true);
                input.setAttribute('accept', '.jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|images/*');
                input.style.display = 'none';
                input.addEventListener('change', function (e) {
                    triggerImagesCallback(e, callback);
                });
                if (inputId == 'imagedropDefault') {
                    var ele1 = window.document.querySelector(".imagedropDefault");
                    ele.appendChild(input);

                    ele.addEventListener('dragenter', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele.classList.add('dragenter');
                    });
                    ele.addEventListener('dragover', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele.classList.add('dragover');
                    });

                    ele.addEventListener('dragleave', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele.classList.remove('dragover');
                    });

                    ele.addEventListener('drop', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele.classList.remove('dragover');
                        triggerImagesCallback(e, callback);
                    });

                    ele.addEventListener('click', function () {
                        input.value = null;
                        input.click();
                    });
                }
                if (inputId == 'imagedropB') {
                    var ele1 = window.document.querySelector("#cirDynamicAccordSection2 .imagedropB");
                    ele1.appendChild(input);

                    ele1.addEventListener('dragenter', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele1.classList.add('dragenter');
                    });

                    ele1.addEventListener('dragover', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele1.classList.add('dragover');
                    });

                    ele1.addEventListener('dragleave', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele1.classList.remove('dragover');
                    });

                    ele1.addEventListener('drop', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele1.classList.remove('dragover');
                        triggerImagesCallback(e, callback);
                    });
                    ele1.addEventListener('click', function () {

                        input.value = null;
                        input.click();
                    });
                }
                if (inputId == 'imagedropA') {
                    var ele = window.document.querySelector("#cirDynamicAccordSection1 .imagedropA");
                    ele.appendChild(input);

                    ele.addEventListener('dragenter', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele.classList.add('dragenter');
                    });
                    ele.addEventListener('dragover', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele.classList.add('dragover');
                    });

                    ele.addEventListener('dragleave', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele.classList.remove('dragover');
                    });

                    ele.addEventListener('drop', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele.classList.remove('dragover');
                        triggerImagesCallback(e, callback);
                    });
                    ele.addEventListener('click', function () {

                        input.value = null;
                        input.click();
                    });

                }
                if (inputId == 'imagedropC') {
                    var ele2 = window.document.querySelector("#cirDynamicAccordSection3 .imagedropC");
                    ele2.appendChild(input);
                    ele2.addEventListener('dragenter', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele2.classList.add('dragenter');
                    });
                    ele2.addEventListener('dragover', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele2.classList.add('dragover');
                    });

                    ele2.addEventListener('dragleave', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele2.classList.remove('dragover');
                    });

                    ele2.addEventListener('drop', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele2.classList.remove('dragover');
                        triggerImagesCallback(e, callback);
                    });
                    ele2.addEventListener('click', function () {

                        input.value = null;
                        input.click();
                    });
                }
                if (inputId == 'imagedropD') {
                    var ele3 = window.document.querySelector("#cirDynamicAccordSection4 .imagedropD");
                    ele3.appendChild(input);
                    ele3.addEventListener('dragenter', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele3.classList.add('dragenter');
                    });
                    ele3.addEventListener('dragover', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele3.classList.add('dragover');
                    });

                    ele3.addEventListener('dragleave', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele3.classList.remove('dragover');
                    });

                    ele3.addEventListener('drop', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele3.classList.remove('dragover');
                        triggerImagesCallback(e, callback);
                    });
                    ele3.addEventListener('click', function () {
                        input.value = null;
                        input.click();
                    });

                }
                if (inputId == 'imagedropE') {
                    var ele4 = window.document.querySelector("#cirDynamicAccordSection5 .imagedropE");
                    ele4.appendChild(input);
                    ele4.addEventListener('dragenter', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele4.classList.add('dragenter');
                    });
                    ele4.addEventListener('dragover', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele4.classList.add('dragover');
                    });

                    ele4.addEventListener('dragleave', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele4.classList.remove('dragover');
                    });

                    ele4.addEventListener('drop', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele4.classList.remove('dragover');
                        triggerImagesCallback(e, callback);
                    });
                    ele4.addEventListener('click', function () {

                        input.value = null;
                        input.click();
                    });
                }
                if (inputId == 'imagedropF') {
                    var ele5 = window.document.querySelector("#cirDynamicAccordSection6 .imagedropF");
                    ele5.appendChild(input);
                    ele5.addEventListener('dragenter', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele5.classList.add('dragenter');
                    });
                    ele5.addEventListener('dragover', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele5.classList.add('dragover');
                    });

                    ele5.addEventListener('dragleave', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele5.classList.remove('dragover');
                    });

                    ele5.addEventListener('drop', function (e) {
                        e.preventDefault();
                        e.stopPropagation();
                        ele5.classList.remove('dragover');
                        triggerImagesCallback(e, callback);
                    });
                    ele5.addEventListener('click', function () {

                        input.value = null;
                        input.click();
                    });

                }

            }
            window.makeImagesDroppable = makeImagesDroppable;
        })(this);
        (function (window) {
            makeImagesDroppable(window.document.querySelector('.imagedropDefault'), function (files) {
                LoadUI(files, "imagedropDefault");

            });
        })(this);
        (function (window) {
            makeImagesDroppable(window.document.querySelector(".imagedropA"), function (files) {
                //LoadImageUI(files, 'imagedropA');
                LoadUI(files, 'imagedropA');
            });
        })(this);
        (function (window) {
            makeImagesDroppable(window.document.querySelector(".imagedropB"), function (files) {
                //  LoadImageUI(files, 'imagedropB');
                LoadUI(files, 'imagedropB');
            });
        })(this);
        (function (window) {
            makeImagesDroppable(window.document.querySelector(".imagedropC"), function (files) {
                //LoadImageUI(files, 'imagedropC');
                LoadUI(files, 'imagedropC');
            });
        })(this);
        (function (window) {
            makeImagesDroppable(window.document.querySelector(".imagedropD"), function (files) {
                //LoadImageUI(files, 'imagedropD');
                LoadUI(files, 'imagedropD');
            });
        })(this);
        (function (window) {
            makeImagesDroppable(window.document.querySelector(".imagedropE"), function (files) {
                //LoadImageUI(files, 'imagedropE');
                LoadUI(files, 'imagedropE');
            });
        })(this);
        (function (window) {
            makeImagesDroppable(window.document.querySelector(".imagedropF"), function (files) {
                //LoadImageUI(files, 'imagedropF');
                LoadUI(files, 'imagedropF');
            });
        })(this);

        var lstSwipers = [];

        (function (window) {
            $('#cirDynamicAccordSection1 #list1').sortable({
                distance: 5,
                delay: 300,
                opacity: 0.6,
                cursor: 'move',
                start: function (event, ui) {
                    var start_pos = ui.item.index();
                    ui.item.data('start_pos', start_pos);
                    var startposition = 0;
                    for (var i = 0; i < FileToUpload.length; ++i) {
                        if (FileToUpload[i].position == ui.item[0].attributes["data-defaultValue"].value) {
                            startposition = i;
                            break;
                        }
                    }
                    //var startposition = FileToUpload.findIndex(p => p.position == ui.item[0].attributes["data-defaultValue"].value);
                    ui.item.data('startposition', startposition);
                    //ui.item.data('startposition', ui.item["0"].attributes["data-length"].value);
                },
                change: function (event, ui) {
                    var start_pos = ui.item.data('start_pos');
                    var startpos = ui.item.data('startposition');
                    var newIndex = ui.placeholder.index();
                    var new_pos = parseInt(startpos) + parseInt(newIndex) - parseInt(start_pos);
                    start_pos = parseInt(start_pos);
                    //newIndex = parseInt(newIndex);
                    var obj1 = FileToUpload[startpos];

                    FileToUpload.splice(startpos, 1);
                    //FileToUpload.splice(newIndex, 0, obj1);
                    if (newIndex > start_pos) {
                        FileToUpload.splice(new_pos - 1, 0, obj1);
                        $("#prevlist1 #" + start_pos + ".swiper-slide").insertAfter($("#prevlist1 #" + (newIndex - 1) + ".swiper-slide"));
                    }
                    else if (start_pos > newIndex) {
                        FileToUpload.splice(new_pos, 0, obj1);
                        $("#prevlist1 #" + start_pos + ".swiper-slide").insertBefore($("#prevlist1 #" + newIndex + ".swiper-slide"));
                    }
                    ReInitializeSwiper();
                },
                update: function (event, ui) {
                    $('#list1').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);
                        $(this).find('.order').val(index);
                    });
                    $('#prevlist1').children('div').each(function (index) {
                        this.setAttribute('id', index);
                        $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                    });
                }
            });
            $('#cirDynamicAccordSection2 #list2').sortable({
                distance: 5,
                delay: 300,
                opacity: 0.6,
                cursor: 'move',
                start: function (event, ui) {
                    var start_pos = ui.item.index();
                    ui.item.data('start_pos', start_pos);
                    var startposition = 0;
                    for (var i = 0; i < FileToUpload.length; ++i) {
                        if (FileToUpload[i].position == ui.item[0].attributes["data-defaultValue"].value) {
                            startposition = i;
                            break;
                        }
                    }
                    //var startposition = FileToUpload.findIndex(p => p.position == ui.item[0].attributes["data-defaultValue"].value);
                    ui.item.data('startposition', startposition);
                    //ui.item.data('startposition', ui.item["0"].attributes["data-length"].value);
                },
                change: function (event, ui) {
                    var start_pos = ui.item.data('start_pos');
                    var startpos = ui.item.data('startposition');
                    var newIndex = ui.placeholder.index();
                    var new_pos = parseInt(startpos) + parseInt(newIndex) - parseInt(start_pos);
                    start_pos = parseInt(start_pos);
                    //newIndex = parseInt(newIndex);
                    var obj1 = FileToUpload[startpos];

                    FileToUpload.splice(startpos, 1);
                    //FileToUpload.splice(newIndex, 0, obj1);
                    if (newIndex > start_pos) {
                        FileToUpload.splice(new_pos - 1, 0, obj1);
                        $("#prevlist2 #" + start_pos + ".swiper-slide").insertAfter($("#prevlist2 #" + (newIndex - 1) + ".swiper-slide"));
                    }
                    else if (start_pos > newIndex) {
                        FileToUpload.splice(new_pos, 0, obj1);
                        $("#prevlist2 #" + start_pos + ".swiper-slide").insertBefore($("#prevlist2 #" + newIndex + ".swiper-slide"));
                    }
                    ReInitializeSwiper();
                },
                update: function (event, ui) {
                    $('#list2').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);
                        $(this).find('.order').val(index);
                    });
                    $('#prevlist2').children('div').each(function (index) {
                        this.setAttribute('id', index);
                        $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                    });
                }
            });
            $('#cirDynamicAccordSection3 #list3').sortable({
                distance: 5,
                delay: 300,
                opacity: 0.6,
                cursor: 'move',
                start: function (event, ui) {
                    var start_pos = ui.item.index();
                    ui.item.data('start_pos', start_pos);
                    var startposition = 0;
                    for (var i = 0; i < FileToUpload.length; ++i) {
                        if (FileToUpload[i].position == ui.item[0].attributes["data-defaultValue"].value) {
                            startposition = i;
                            break;
                        }
                    }
                    //var startposition = FileToUpload.findIndex(p => p.position == ui.item[0].attributes["data-defaultValue"].value);
                    ui.item.data('startposition', startposition);
                    //ui.item.data('startposition', ui.item["0"].attributes["data-length"].value);
                },
                change: function (event, ui) {
                    var start_pos = ui.item.data('start_pos');
                    var startpos = ui.item.data('startposition');
                    var newIndex = ui.placeholder.index();
                    var new_pos = parseInt(startpos) + parseInt(newIndex) - parseInt(start_pos);
                    start_pos = parseInt(start_pos);
                    //newIndex = parseInt(newIndex);
                    var obj1 = FileToUpload[startpos];

                    FileToUpload.splice(startpos, 1);
                    //FileToUpload.splice(newIndex, 0, obj1);
                    if (newIndex > start_pos) {
                        FileToUpload.splice(new_pos - 1, 0, obj1);
                        $("#prevlist3 #" + start_pos + ".swiper-slide").insertAfter($("#prevlist3 #" + (newIndex - 1) + ".swiper-slide"));
                    }
                    else if (start_pos > newIndex) {
                        FileToUpload.splice(new_pos, 0, obj1);
                        $("#prevlist3 #" + start_pos + ".swiper-slide").insertBefore($("#prevlist3 #" + newIndex + ".swiper-slide"));
                    }
                    ReInitializeSwiper();
                },
                update: function (event, ui) {
                    $('#list3').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);
                        $(this).find('.order').val(index);
                    });
                    $('#prevlist3').children('div').each(function (index) {
                        this.setAttribute('id', index);
                        $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                    });
                }
            });
            $('#cirDynamicAccordSection4 #list4').sortable({
                distance: 5,
                delay: 300,
                opacity: 0.6,
                cursor: 'move',
                start: function (event, ui) {
                    var start_pos = ui.item.index();
                    ui.item.data('start_pos', start_pos);
                    var startposition = 0;
                    for (var i = 0; i < FileToUpload.length; ++i) {
                        if (FileToUpload[i].position == ui.item[0].attributes["data-defaultValue"].value) {
                            startposition = i;
                            break;
                        }
                    }
                    //var startposition = FileToUpload.findIndex(p => p.position == ui.item[0].attributes["data-defaultValue"].value);
                    ui.item.data('startposition', startposition);
                    //ui.item.data('startposition', ui.item["0"].attributes["data-length"].value);
                },
                change: function (event, ui) {
                    var start_pos = ui.item.data('start_pos');
                    var startpos = ui.item.data('startposition');
                    var newIndex = ui.placeholder.index();
                    var new_pos = parseInt(startpos) + parseInt(newIndex) - parseInt(start_pos);
                    start_pos = parseInt(start_pos);
                    //newIndex = parseInt(newIndex);
                    var obj1 = FileToUpload[startpos];

                    FileToUpload.splice(startpos, 1);
                    //FileToUpload.splice(newIndex, 0, obj1);
                    if (newIndex > start_pos) {
                        FileToUpload.splice(new_pos - 1, 0, obj1);
                        $("#prevlist4 #" + start_pos + ".swiper-slide").insertAfter($("#prevlist4 #" + (newIndex - 1) + ".swiper-slide"));
                    }
                    else if (start_pos > newIndex) {
                        FileToUpload.splice(new_pos, 0, obj1);
                        $("#prevlist4 #" + start_pos + ".swiper-slide").insertBefore($("#prevlist4 #" + newIndex + ".swiper-slide"));
                    }
                    ReInitializeSwiper();
                },
                update: function (event, ui) {
                    $('#list4').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);
                        $(this).find('.order').val(index);
                    });
                    $('#prevlist4').children('div').each(function (index) {
                        this.setAttribute('id', index);
                        $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                    });
                }
            });
            $('#cirDynamicAccordSection5 #list5').sortable({
                distance: 5,
                delay: 300,
                opacity: 0.6,
                cursor: 'move',
                start: function (event, ui) {
                    var start_pos = ui.item.index();
                    ui.item.data('start_pos', start_pos);
                    var startposition = 0;
                    for (var i = 0; i < FileToUpload.length; ++i) {
                        if (FileToUpload[i].position == ui.item[0].attributes["data-defaultValue"].value) {
                            startposition = i;
                            break;
                        }
                    }
                    //var startposition = FileToUpload.findIndex(p => p.position == ui.item[0].attributes["data-defaultValue"].value);
                    ui.item.data('startposition', startposition);
                    //ui.item.data('startposition', ui.item["0"].attributes["data-length"].value);
                },
                change: function (event, ui) {
                    var start_pos = ui.item.data('start_pos');
                    var startpos = ui.item.data('startposition');
                    var newIndex = ui.placeholder.index();
                    var new_pos = parseInt(startpos) + parseInt(newIndex) - parseInt(start_pos);
                    start_pos = parseInt(start_pos);
                    //newIndex = parseInt(newIndex);
                    var obj1 = FileToUpload[startpos];

                    FileToUpload.splice(startpos, 1);
                    //FileToUpload.splice(newIndex, 0, obj1);
                    if (newIndex > start_pos) {
                        FileToUpload.splice(new_pos - 1, 0, obj1);
                        $("#prevlist5 #" + start_pos + ".swiper-slide").insertAfter($("#prevlist5 #" + (newIndex - 1) + ".swiper-slide"));
                    }
                    else if (start_pos > newIndex) {
                        FileToUpload.splice(new_pos, 0, obj1);
                        $("#prevlist5 #" + start_pos + ".swiper-slide").insertBefore($("#prevlist5 #" + newIndex + ".swiper-slide"));
                    }
                    ReInitializeSwiper();
                },
                update: function (event, ui) {
                    $('#list5').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);
                        $(this).find('.order').val(index);
                    });
                    $('#prevlist5').children('div').each(function (index) {
                        this.setAttribute('id', index);
                        $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                    });
                }
            });
            $('#cirDynamicAccordSection6 #list6').sortable({
                distance: 5,
                delay: 300,
                opacity: 0.6,
                cursor: 'move',
                start: function (event, ui) {
                    var start_pos = ui.item.index();
                    ui.item.data('start_pos', start_pos);
                    var startposition = 0;
                    for (var i = 0; i < FileToUpload.length; ++i) {
                        if (FileToUpload[i].position == ui.item[0].attributes["data-defaultValue"].value) {
                            startposition = i;
                            break;
                        }
                    }
                    //var startposition = FileToUpload.findIndex(p => p.position == ui.item[0].attributes["data-defaultValue"].value);
                    ui.item.data('startposition', startposition);
                    //ui.item.data('startposition', ui.item["0"].attributes["data-length"].value);
                },
                change: function (event, ui) {
                    var start_pos = ui.item.data('start_pos');
                    var startpos = ui.item.data('startposition');
                    var newIndex = ui.placeholder.index();
                    var new_pos = parseInt(startpos) + parseInt(newIndex) - parseInt(start_pos);
                    start_pos = parseInt(start_pos);
                    //newIndex = parseInt(newIndex);
                    var obj1 = FileToUpload[startpos];

                    FileToUpload.splice(startpos, 1);
                    //FileToUpload.splice(newIndex, 0, obj1);
                    if (newIndex > start_pos) {
                        FileToUpload.splice(new_pos - 1, 0, obj1);
                        $("#prevlist6 #" + start_pos + ".swiper-slide").insertAfter($("#prevlist6 #" + (newIndex - 1) + ".swiper-slide"));
                    }
                    else if (start_pos > newIndex) {
                        FileToUpload.splice(new_pos, 0, obj1);
                        $("#prevlist6 #" + start_pos + ".swiper-slide").insertBefore($("#prevlist6 #" + newIndex + ".swiper-slide"));
                    }
                    ReInitializeSwiper();
                },
                update: function (event, ui) {
                    $('#list6').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);
                        $(this).find('.order').val(index);
                    });
                    $('#prevlist6').children('div').each(function (index) {
                        this.setAttribute('id', index);
                        $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                    });
                }
            });
            $('#list').sortable({
                distance: 5,
                delay: 300,
                opacity: 0.6,
                cursor: 'move',
                start: function (event, ui) {
                    var start_pos = ui.item.index();
                    ui.item.data('start_pos', start_pos);
                    var startposition = 0;
                    for (var i = 0; i < FileToUpload.length; ++i) {
                        if (FileToUpload[i].position == ui.item[0].attributes["data-defaultValue"].value) {
                            startposition = i;
                            break;
                        }
                    }
                    //var startposition = FileToUpload.findIndex(p => p.position == ui.item[0].attributes["data-defaultValue"].value);
                    ui.item.data('startposition', startposition);
                    //ui.item.data('startposition', ui.item["0"].attributes["data-length"].value);
                },
                change: function (event, ui) {
                    var start_pos = ui.item.data('start_pos');
                    var startpos = ui.item.data('startposition');
                    var newIndex = ui.placeholder.index();
                    var new_pos = parseInt(startpos) + parseInt(newIndex) - parseInt(start_pos);
                    start_pos = parseInt(start_pos);
                    //newIndex = parseInt(newIndex);
                    var obj1 = FileToUpload[startpos];

                    FileToUpload.splice(startpos, 1);
                    //FileToUpload.splice(newIndex, 0, obj1);
                    if (newIndex > start_pos) {
                        FileToUpload.splice(new_pos - 1, 0, obj1);
                        $("#prevlist #" + start_pos + ".swiper-slide").insertAfter($("#prevlist #" + (newIndex - 1) + ".swiper-slide"));
                    }
                    else if (start_pos > newIndex) {
                        FileToUpload.splice(new_pos, 0, obj1);
                        $("#prevlist #" + start_pos + ".swiper-slide").insertBefore($("#prevlist #" + newIndex + ".swiper-slide"));
                    }
                    ReInitializeSwiper();
                },
                update: function (event, ui) {
                    $('#list').children('div').each(function (index) {
                        this.setAttribute('data-fileid', index);
                        $(this).find('.order').val(index);
                    });
                    $('#prevlist').children('div').each(function (index) {
                        this.setAttribute('id', index);
                        $(this).children('div.subtitle').attr('id', 'subtitle' + index);
                    });
                }
            });
        })(this);




    </script>
    <script>

        function openModal(flangeNumber) {
            var valContainer;
            if (flangeNumber === 'imagedropDefault') {
                var subtitleLength = $("#prevlist .subtitle").length;
                for (i = 0; i < subtitleLength; i++) {
                    valContainer = $('#list div[data-fileid="' + i + '"]').first();
                    var imageName = $(valContainer).find('.imageName').text();
                    var imageDescription = $(valContainer).find('.imageDescription').val();
                    var imageNameDesc = $(valContainer).find('.imageNameDesc').val();
                    var imageDetail = '<font color="white" style="background-color: rgba(0%, 0%, 92%, 0.2); font-weight:bold;">' + imageName + '</font><br/>';
                    imageDetail = imageDetail + '<font color="white" id="' + i + '" style="background-color: rgba(0%, 0%, 92%, 0.2)">' + imageDescription + '</font>';
                    if ($("#prevlist #subtitle" + i)[0] != undefined) {
                        $("#prevlist #subtitle" + i)[0].innerHTML = imageDetail;
                    }
                }
                document.getElementById('myModal').style.display = "block";
            }
            if (flangeNumber === 'imagedropA') {
                var subtitleLength = $("#prevlist1 .subtitle").length;
                for (i = 0; i < subtitleLength; i++) {
                    valContainer = $('#list1 div[data-fileid="' + i + '"]').first();
                    var imageName = $(valContainer).find('.imageName').text();
                    var imageDescription = $(valContainer).find('.imageDescription').val();
                    var imageNameDesc = $(valContainer).find('.imageNameDesc').val();
                    var imageDetail = '<font color="white" style="background-color: rgba(0%, 0%, 92%, 0.2); font-weight:bold;">' + imageName + '</font><br/>';
                    imageDetail = imageDetail + '<font color="white" id="' + i + '" style="background-color: rgba(0%, 0%, 92%, 0.2)">' + imageDescription + '</font>';
                    if ($("#prevlist1 #subtitle" + i)[0] != undefined) {
                        $("#prevlist1 #subtitle" + i)[0].innerHTML = imageDetail;
                    }
                }
                document.getElementById('myModal1').style.display = "block";
            }
            else if (flangeNumber === 'imagedropB') {
                var subtitleLength = $("#prevlist2 .subtitle").length;
                for (i = 0; i < subtitleLength; i++) {
                    valContainer = $('#list2 div[data-fileid="' + i + '"]').first();
                    var imageName = $(valContainer).find('.imageName').text();
                    var imageDescription = $(valContainer).find('.imageDescription').val();
                    var imageNameDesc = $(valContainer).find('.imageNameDesc').val();
                    var imageDetail = '<font color="white" style="background-color: rgba(0%, 0%, 92%, 0.2); font-weight:bold;">' + imageName + '</font><br/>';
                    imageDetail = imageDetail + '<font color="white" id="' + i + '" style="background-color: rgba(0%, 0%, 92%, 0.2)">' + imageDescription + '</font>';
                    if ($("#prevlist2 #subtitle" + i)[0] != undefined) {
                        $("#prevlist2 #subtitle" + i)[0].innerHTML = imageDetail;
                    }
                }
                document.getElementById('myModal2').style.display = "block";
            }
            else if (flangeNumber === 'imagedropC') {
                var subtitleLength = $("#prevlist3 .subtitle").length;
                for (i = 0; i < subtitleLength; i++) {
                    valContainer = $('#list3 div[data-fileid="' + i + '"]').first();
                    var imageName = $(valContainer).find('.imageName').text();
                    var imageDescription = $(valContainer).find('.imageDescription').val();
                    var imageNameDesc = $(valContainer).find('.imageNameDesc').val();
                    var imageDetail = '<font color="white" style="background-color: rgba(0%, 0%, 92%, 0.2); font-weight:bold;">' + imageName + '</font><br/>';
                    imageDetail = imageDetail + '<font color="white" id="' + i + '" style="background-color: rgba(0%, 0%, 92%, 0.2)">' + imageDescription + '</font>';
                    if ($("#prevlist3 #subtitle" + i)[0] != undefined) {
                        $("#prevlist3 #subtitle" + i)[0].innerHTML = imageDetail;
                    }
                }
                document.getElementById('myModal3').style.display = "block";
            }
            else if (flangeNumber === 'imagedropD') {
                var subtitleLength = $("#prevlist4 .subtitle").length;
                for (i = 0; i < subtitleLength; i++) {
                    valContainer = $('#list4 div[data-fileid="' + i + '"]').first();
                    var imageName = $(valContainer).find('.imageName').text();
                    var imageDescription = $(valContainer).find('.imageDescription').val();
                    var imageNameDesc = $(valContainer).find('.imageNameDesc').val();
                    var imageDetail = '<font color="white" style="background-color: rgba(0%, 0%, 92%, 0.2); font-weight:bold;">' + imageName + '</font><br/>';
                    imageDetail = imageDetail + '<font color="white" id="' + i + '" style="background-color: rgba(0%, 0%, 92%, 0.2)">' + imageDescription + '</font>';
                    if ($("#prevlist4 #subtitle" + i)[0] != undefined) {
                        $("#prevlist4 #subtitle" + i)[0].innerHTML = imageDetail;
                    }
                }
                document.getElementById('myModal4').style.display = "block";
            }
            else if (flangeNumber === 'imagedropE') {
                var subtitleLength = $("#prevlist5 .subtitle").length;
                for (i = 0; i < subtitleLength; i++) {
                    valContainer = $('#list5 div[data-fileid="' + i + '"]').first();
                    var imageName = $(valContainer).find('.imageName').text();
                    var imageDescription = $(valContainer).find('.imageDescription').val();
                    var imageNameDesc = $(valContainer).find('.imageNameDesc').val();
                    var imageDetail = '<font color="white" style="background-color: rgba(0%, 0%, 92%, 0.2); font-weight:bold;">' + imageName + '</font><br/>';
                    imageDetail = imageDetail + '<font color="white" id="' + i + '" style="background-color: rgba(0%, 0%, 92%, 0.2)">' + imageDescription + '</font>';
                    if ($("#prevlist5 #subtitle" + i)[0] != undefined) {
                        $("#prevlist5 #subtitle" + i)[0].innerHTML = imageDetail;
                    }
                }
                document.getElementById('myModal5').style.display = "block";
            }
            else if (flangeNumber === 'imagedropF') {
                var subtitleLength = $("#prevlist6 .subtitle").length;
                for (i = 0; i < subtitleLength; i++) {
                    valContainer = $('#list6 div[data-fileid="' + i + '"]').first();
                    var imageName = $(valContainer).find('.imageName').text();
                    var imageDescription = $(valContainer).find('.imageDescription').val();
                    var imageNameDesc = $(valContainer).find('.imageNameDesc').val();
                    var imageDetail = '<font color="white" style="background-color: rgba(0%, 0%, 92%, 0.2); font-weight:bold;">' + imageName + '</font><br/>';
                    imageDetail = imageDetail + '<font color="white" id="' + i + '" style="background-color: rgba(0%, 0%, 92%, 0.2)">' + imageDescription + '</font>';
                    if ($("#prevlist6 #subtitle" + i)[0] != undefined) {
                        $("#prevlist6 #subtitle" + i)[0].innerHTML = imageDetail;
                    }
                }
                document.getElementById('myModal6').style.display = "block";
            }
            lstSwipers = [];

            //swiper.update();           
            $('.swiper-container').each(function () {
                var objSwiper = new Swiper($(this), {
                    pagination: $(this).find('.swiper-pagination'),
                    paginationClickable: $(this).find('.swiper-pagination'),
                    nextButton: $(this).find('.swiper-button-next'),
                    prevButton: $(this).find('.swiper-button-prev'),
                    zoom: true,
                    keyboardControl: true,
                    slidesPerView: 1,

                });
                lstSwipers.push(objSwiper);
                objSwiper.update();
            });
        }


        function closeModal(flangeNumber) {
            if (flangeNumber === 'imagedropDefault') {
                document.getElementById('myModal').style.display = "none";
            }
            if (flangeNumber === 'imagedropA') {
                document.getElementById('myModal1').style.display = "none";
            }
            else if (flangeNumber === 'imagedropB') {
                document.getElementById('myModal2').style.display = "none";
            }
            else if (flangeNumber === 'imagedropC') {
                document.getElementById('myModal3').style.display = "none";
            }
            else if (flangeNumber === 'imagedropD') {
                document.getElementById('myModal4').style.display = "none";
            }
            else if (flangeNumber === 'imagedropE') {
                document.getElementById('myModal5').style.display = "none";
            }
            else if (flangeNumber === 'imagedropF') {
                document.getElementById('myModal6').style.display = "none";
            }
        }

        function currentSlide(inputId, idx) {
            var currentIdx;
            if (inputId === 'imagedropA') {
                currentIdx = $('#list1').find('img[data-defaultImageId="' + idx + '"]').parent().attr('data-fileid');
                lstSwipers[0].setWrapperTranslate(0);
                lstSwipers[0].slideTo(currentIdx, 0, false);
            }
            if (inputId === 'imagedropB') {
                currentIdx = $('#list2').find('img[data-defaultImageId="' + idx + '"]').parent().attr('data-fileid');
                lstSwipers[1].setWrapperTranslate(0);
                lstSwipers[1].slideTo(currentIdx, 0, false);
            }
            if (inputId === 'imagedropC') {
                currentIdx = $('#list3').find('img[data-defaultImageId="' + idx + '"]').parent().attr('data-fileid');
                lstSwipers[2].setWrapperTranslate(0);
                lstSwipers[2].slideTo(currentIdx, 0, false);
            }
            if (inputId === 'imagedropD') {
                currentIdx = $('#list4').find('img[data-defaultImageId="' + idx + '"]').parent().attr('data-fileid');
                lstSwipers[3].setWrapperTranslate(0);
                lstSwipers[3].slideTo(currentIdx, 0, false);
            }
            if (inputId === 'imagedropE') {
                currentIdx = $('#list5').find('img[data-defaultImageId="' + idx + '"]').parent().attr('data-fileid');
                lstSwipers[4].setWrapperTranslate(0);
                lstSwipers[4].slideTo(currentIdx, 0, false);
            }
            if (inputId === 'imagedropF') {
                currentIdx = $('#list6').find('img[data-defaultImageId="' + idx + '"]').parent().attr('data-fileid');
                lstSwipers[5].setWrapperTranslate(0);
                lstSwipers[5].slideTo(currentIdx, 0, false);
            }
            if (inputId === 'imagedropDefault') {
                currentIdx = $('#list').find('img[data-defaultImageId="' + idx + '"]').parent().attr('data-fileid');
                lstSwipers[6].setWrapperTranslate(0);
                lstSwipers[6].slideTo(currentIdx, 0, false);
            }
        }

        function restrictSpecialChar(e) {
            if (e.shiftKey) {
                e.preventDefault();
            }
        }
        if (!Array.from) {
            Array.from = (function () {
                var toStr = Object.prototype.toString;
                var isCallable = function (fn) {
                    return typeof fn === 'function' || toStr.call(fn) === '[object Function]';
                };
                var toInteger = function (value) {
                    var number = Number(value);
                    if (isNaN(number)) { return 0; }
                    if (number === 0 || !isFinite(number)) { return number; }
                    return (number > 0 ? 1 : -1) * Math.floor(Math.abs(number));
                };
                var maxSafeInteger = Math.pow(2, 53) - 1;
                var toLength = function (value) {
                    var len = toInteger(value);
                    return Math.min(Math.max(len, 0), maxSafeInteger);
                };

                // The length property of the from method is 1.
                return function from(arrayLike/*, mapFn, thisArg */) {
                    // 1. Let C be the this value.
                    var C = this;

                    // 2. Let items be ToObject(arrayLike).
                    var items = Object(arrayLike);

                    // 3. ReturnIfAbrupt(items).
                    if (arrayLike == null) {
                        throw new TypeError("Array.from requires an array-like object - not null or undefined");
                    }

                    // 4. If mapfn is undefined, then let mapping be false.
                    var mapFn = arguments.length > 1 ? arguments[1] : void undefined;
                    var T;
                    if (typeof mapFn !== 'undefined') {
                        // 5. else
                        // 5. a If IsCallable(mapfn) is false, throw a TypeError exception.
                        if (!isCallable(mapFn)) {
                            throw new TypeError('Array.from: when provided, the second argument must be a function');
                        }

                        // 5. b. If thisArg was supplied, let T be thisArg; else let T be undefined.
                        if (arguments.length > 2) {
                            T = arguments[2];
                        }
                    }

                    // 10. Let lenValue be Get(items, "length").
                    // 11. Let len be ToLength(lenValue).
                    var len = toLength(items.length);

                    // 13. If IsConstructor(C) is true, then
                    // 13. a. Let A be the result of calling the [[Construct]] internal method of C with an argument list containing the single item len.
                    // 14. a. Else, Let A be ArrayCreate(len).
                    var A = isCallable(C) ? Object(new C(len)) : new Array(len);

                    // 16. Let k be 0.
                    var k = 0;
                    // 17. Repeat, while k < len… (also steps a - h)
                    var kValue;
                    while (k < len) {
                        kValue = items[k];
                        if (mapFn) {
                            A[k] = typeof T === 'undefined' ? mapFn(kValue, k) : mapFn.call(T, kValue, k);
                        } else {
                            A[k] = kValue;
                        }
                        k += 1;
                    }
                    // 18. Let putStatus be Put(A, "length", len, true).
                    A.length = len;
                    // 20. Return A.
                    return A;
                };
            }());
        }
    </script>
</asp:Content>
