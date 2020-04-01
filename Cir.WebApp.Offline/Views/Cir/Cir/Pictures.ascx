<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>


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
</style>
<div id="myModal" class="swiper-container">
    <span class="close cursor" title="Close" onclick="closeModal('imagedropDefault')">&times;</span>
    <div id="prevlist" class="swiper-wrapper"></div>
    <!-- Add Pagination -->
    <div class="swiper-pagination"></div>
    <!-- Add Navigation -->
    <div class="swiper-button-prev"></div>
    <div class="swiper-button-next"></div>
</div>
<fieldset>
    <legend>CIR Images</legend>
    <div class="form-group">
        <label class="control-label">
            Attached pictures are automatically resized to a maximum of 1152*864 pixels (max. 400 KB 
per picture) in compressed jpeg format.
        </label>
    </div>
   
    <div class="form-group">
        <label class="col-lg-3 control-label">Plate Type Picture Not possible</label>
        <div class="col-lg-9">
            <input type="checkbox" id="chkIsPlateTypeNotPossible" name="IsPlateTypeNotPossible" class="form-control" />
        </div>
    </div>
    <div class="form-group" id="ptreason" style="display: none">
        <label class="col-lg-3 control-label" id="plateReason">Reason <span class="errorSpan">*</span></label>
        <div class="col-lg-9">
            <textarea id="txtPlateTypeNotPossibleReason" name="PlateTypeNotPossibleReason" class="form-control" rows="3" placeholder="PlateType picture not possible reason"></textarea>
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Upload Images</label>
        <div class="col-lg-9">
            <div class="image-droppable imagedropDefault">
                <p>Drag files here or click to upload</p>
            </div>
            <input type="file" id="files" name="files[]" accept=".jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|images/*" multiple class="hide" style="display: none">
            <label for="files" class="btn btn-primary" style="display: none">Choose Image</label>
            <%--<input type="button" id="btnjson" value="Get Json" />--%>
            <hr />
            <b>Preview</b>
            <div class="form-group" id="PlateType" style="text-align: center; display: none;">
                <table style="width: 100%;">
                    <tr style="width: 100%;">
                        <td style="width: 50%;">
                            <label class="control-label" style="color: #cc0000;">The first Image will be treated as Plate Type</label>
                        </td>
                        <td style="width: 50%;"></td>
                    </tr>
                    <tr>
                        <td style="width: 50%;">
                            <label class="fa fa-arrow-down fa-lg"></label>
                        </td>
                        <td style="width: 50%;"></td>
                    </tr>
                </table>
            </div>
            <div class="form-group">
                <div id="list" class="ImageThumbList">
                </div>
            </div>

        </div>

    </div>
    <div class="form-group">
        <div id="dvPreview" class="col-xs-12">
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Inspection Description</label>
        <div class="col-lg-9">
            <textarea id="txtImgInspectionDescription" class="form-control" rows="3" placeholder="Inspection Description"></textarea>
        </div>
    </div>
    <div class="form-group">
        <div class="col-xs-12" style="text-align: right;">
            <a href="javascript:void(0);" id="linkImageDataPrev" class="btn btn-primary">Previous</a>
            <a href="javascript:void(0);" id="linkImageDataNext" class="btn btn-primary">Next</a>
        </div>
    </div>
</fieldset>
<script type="text/javascript">
    $(document).ready(function () {
        $("#chkIsPlateTypeNotPossible").next().click(function () {
            $("#ptreason").toggle();
            if ($('#chkIsPlateTypeNotPossible').is(':checked')) {
                $('#PlateType').hide();
            }
            else {
                if ($('#list').children().length > 0) {
                    $('#PlateType').show();
                }

            }
        });
    });
    var FileToUpload = [];
    var defaultValue = 0;

    function handleFileSelect(evt) {
        var files = evt.target.files; // FileList object
        LoadUI(files, "imagedropDefault");
    }

    
    /* Listener for multiple files input element. */
    document.getElementById('files').addEventListener('change', handleFileSelect, false);


    function getImageData(e) {
        GetJsonFromFile(function (data) {
        });
    }

    function GetJsonFromFile(callback) {
        var ImageList = {
            Images: []
        };
        if (FileToUpload.length == 0) {
            callback(ImageList);
        }
        var fileListLength = FileToUpload.length;
        // var i = 0;
        for (var idx = 0; idx < fileListLength; idx++) {
            //var reader = new FileReader();
            //var f = FileToUpload[i];
            //reader.onload = (function (index) {
            //    return function (e) {
            //        var imageObj = new Image();
            //        imageObj.onload = (function (idx) {
            //            return function () {
                            var jsonData = {};
                            jsonData['imageDataString'] = $("#prevlist #" + idx + ".swiper-slide").find("img").first().attr("src");
                            var valuecontainer = $('#list div[data-fileid="' + idx + '"]').first();
                            jsonData['imageDescription'] = $(valuecontainer).find('.imageName').text() + "##" + $(valuecontainer).find('.imageDescription').val();
                            jsonData['imageOrder'] = $(valuecontainer).find('.order').val();
                            jsonData['imageId'] = $(valuecontainer).attr('data-imageId');
                            jsonData['inspectionDesc'] = $('#txtImgInspectionDescription').val();
                            ImageList.Images.push(jsonData);
                            if (ImageList.Images.length == FileToUpload.length) {
                                callback(ImageList);
                            }

            //            };
            //        })(index);
            //        imageObj.src = e.target.result;
            //        //imageObj.src = $("#prevlist #" + index + ".swiper-slide").find("img").first().attr("src");

            //    };
            //})(i);

            //// Read in the image file as a data URL.
            //reader.readAsDataURL(f);
        }
    }

    function LoadFromJsonObject(ImageJsonObject) {
        FileToUpload = [];
        var FileFromJson = [];
        for (var i = 0, f; imgObj = ImageJsonObject[i]; i++) {
            if (i == 0) {
                $('#txtImgInspectionDescription').val((imgObj.inspectionDesc) ? imgObj.inspectionDesc : "");
            }
            var filobj = dataURItoBlob(imgObj.imageDataString, imgObj.imageDescription, imgObj.imageId);
            FileFromJson.push(filobj);
        }
        LoadUI(FileFromJson, "imagedropDefault");
    }
    function dataURItoBlob(dataURI, filename, id) {
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
        blob.name = filename;
        blob.imageId = (id) ? id : 0;;
        return blob;
    }


    function loadinfoFromJson(ImageDataInforObj) {
        if (ImageDataInforObj) {
            $('#txtPlateTypeNotPossibleReason').val((ImageDataInforObj.plateTypeNotPossibleReason) ? ImageDataInforObj.plateTypeNotPossibleReason : "");
            if (ImageDataInforObj.isPlateTypeNotPossible != null)
                $('#chkIsPlateTypeNotPossible').attr('checked', ImageDataInforObj.isPlateTypeNotPossible);
            else
                $('#chkIsPlateTypeNotPossible').attr('checked', false);
            var parent = $('#chkIsPlateTypeNotPossible').parent()
            if ($('#chkIsPlateTypeNotPossible').is(':checked')) {
                $('#ptreason').show();
                parent.addClass('checked');
                parent.attr('aria-checked', 'true');
            }
            else {
                $('#ptreason').hide();
                parent.removeClass('checked');
                parent.attr('aria-checked', 'false');
            }
        }
    }

    function loadInfojsonfromhtml() {
        var ImageDataInforObj = {};
        ImageDataInforObj.isPlateTypeNotPossible = $('#chkIsPlateTypeNotPossible').is(':checked');
        ImageDataInforObj.plateTypeNotPossibleReason = ($('#chkIsPlateTypeNotPossible').is(':checked') == true) ? $('#txtPlateTypeNotPossibleReason').val() : "";
        return ImageDataInforObj;
    }



    (function (window) {
        function triggerCallback(e, callback) {
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
        function makeDroppable(ele, callback) {
            var input = document.createElement('input');
            input.setAttribute('type', 'file');
            input.setAttribute('multiple', true);
            input.setAttribute('accept', '.jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|images/*');
            input.style.display = 'none';
            input.addEventListener('change', function (e) {
                triggerCallback(e, callback);
            });
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
                triggerCallback(e, callback);
            });

            ele.addEventListener('click', function () {
                input.value = null;
                input.click();
            });
        }
        window.makeDroppable = makeDroppable;
    })(this);

</script>
