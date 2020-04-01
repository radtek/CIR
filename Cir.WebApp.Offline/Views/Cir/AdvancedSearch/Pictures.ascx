<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
    <legend>CIR Images</legend>
    <div class="form-group">
        <label class="control-label">
            Attached pictures are automatically resized to a maximum of 1152*864 pixels (max. 400 KB 
per picture) in compressed jpeg format.
        </label>
    </div>
    <div class="form-group">
        <label class="control-label">
            Please notice that you can insert max. 20 pictures per report.
        </label>
    </div>
    <div class="form-group">
       <label class="col-lg-3 control-label">Plate Type Picture Not possible</label>
        <div class="col-lg-9">
            <input type="checkbox" id="chkIsPlateTypeNotPossible" name="IsPlateTypeNotPossible"  class="form-control" />
        </div>
        </div>
    <div class="form-group" id="ptreason" style="display:none">
       <label class="col-lg-3 control-label" id="plateReason">Reason</label>
        <div class="col-lg-9">
            <textarea id="txtPlateTypeNotPossibleReason" name="PlateTypeNotPossibleReason" class="form-control" rows="3" placeholder="PlateType picture not possible reason" ></textarea>
        </div>
        </div>
    <div class="form-group">
        <label class="col-lg-3 control-label">Upload Images</label>
        <div class="col-lg-9">
            <input type="file" id="files" name="files[]" accept=".jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|images/*" multiple class="hide">
            <label for="files" class="btn btn-primary">Choose Image</label>
            <%--<input type="button" id="btnjson" value="Get Json" />--%>
            <hr />
            <b>Preview</b>
            <div class="form-group">
                <div id="list">
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
            <textarea id="txtImgInspectionDescription" class="form-control" rows="3" placeholder="Inspection Description" ></textarea>
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
          });
      });
      var FileToUpload = [];

      function handleFileSelect(evt) {
          var files = evt.target.files; // FileList object
          LoadUI(files);
          
      }

      function LoadUI(files)
      {// Loop through the FileList and render image files as thumbnails.
          for (var i = 0, f; f = files[i]; i++) {

              // Only process image files.
              if (!f.type.match('image.*')) {
                  continue;
              }
              // var img = document.createElement("img");
              var reader = new FileReader();

              // Closure to capture the file information.
              reader.onload = (function (theFile, idx) {
                  return function (e) {

                      FileToUpload.push(theFile);
                      var idstr = FileToUpload.indexOf(theFile);

                      // Render thumbnail.
                      var imageObj = new Image();
                      imageObj.onload = (function (tf, idx) {
                          return function () {
                              var canvas = document.createElement("canvas");
                              var MAX_WIDTH = 100;
                              var MAX_HEIGHT = 100;
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

                              var span = document.createElement('span');

                              span.setAttribute('data-fileid', idx);
                              var imageId = (tf.imageId) ? tf.imageId : 0;
                              span.setAttribute('data-imageId', imageId);
                              var desc = document.createElement('input');

                              desc.type = "text";
                              desc.name = "desc";
                              desc.className = "desc";
                              desc.setAttribute('title', 'Image description');
                              desc.setAttribute('placeholder', 'Image description');
                              desc.value = escape(tf.name);
                              var order = document.createElement('input');
                              order.type = "number";
                              order.name = "order";
                              order.className = "order";
                              order.setAttribute('title', 'Image order index');
                              order.setAttribute('placeholder', 'Image order');
                              order.value = escape(idx);
                              var del = document.createElement('input');
                              del.type = "button";
                              del.name = "del";
                              del.className = "del";
                              del.value = "x";
                              del.setAttribute('title', 'Remove this image');

                              del.addEventListener('click', handleFileDelete, false);
                              span.innerHTML = ['<img class="thumb" src="', dataurl,
                                                '" title="', escape(tf.name), '"/> &nbsp;Description:&nbsp;'].join('');
                              span.appendChild(desc);
                              span.innerHTML += '&nbsp;Order:&nbsp;';
                              span.appendChild(order);
                              span.appendChild(del);

                              //document.getElementById('list').insertBefore(span, null);
                              document.getElementById('list').appendChild(span);
                              document.getElementById('list').appendChild(document.createElement('br'));
                          };
                      })(theFile, idstr);
                      imageObj.src = e.target.result;
                  };
              })(f, i);

              // Read in the image file as a data URL.
              reader.readAsDataURL(f);
          }

      }

      /* Listener for multiple files input element. */
      document.getElementById('files').addEventListener('change', handleFileSelect, false);
      //document.getElementById('btnjson').addEventListener('click', getImageData, false);
      function handleFileDelete(evt) {
          var btn = evt.target;
          var idstr = $(btn).parent().data('fileid');
          FileToUpload.splice(idstr, 1);
          $(btn).parent().next('br').remove();
          $(btn).parent().remove();

          $('#list').children('span').each(function (index) {
              //$(this).data('fileid', index);
              this.setAttribute('data-fileid', index);
          })
      }
      function getImageData(e) {
          GetJsonFromFile(function (data) {
              console.log(data);
              console.log(JSON.stringify(data));
          });
      }

      function GetJsonFromFile(callback) {
          var ImageList = {
              Images: []
          };
          if (FileToUpload.length == 0) {
              callback(ImageList);
          }
          for (var i = 0, f; f = FileToUpload[i]; i++) {
              var reader = new FileReader();

              // Closure to capture the file information.
              reader.onload = (function (index) {
                  return function (e) {
                      var imageObj = new Image();
                      imageObj.onload = (function (idx) {
                          return function () {
                              var canvas = document.createElement("canvas");
                              var MAX_WIDTH = 1024;
                              var MAX_HEIGHT = 768;
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
                              var jsonData = {};
                              jsonData['ImageDataString'] = dataurl;
                              var valuecontainer = $('#list span[data-fileid="' + idx + '"]').first();
                              jsonData['ImageDescription'] = $(valuecontainer).find('.desc').val();
                              jsonData['ImageOrder'] = $(valuecontainer).find('.order').val();
                              jsonData['ImageId'] = $(valuecontainer).attr('data-imageId');
                              jsonData['InspectionDesc'] = $('#txtImgInspectionDescription').val();
                              ImageList.Images.push(jsonData);
                              if (ImageList.Images.length == FileToUpload.length) {
                                  callback(ImageList);
                              }

                          };
                      })(index);
                      imageObj.src = e.target.result;

                  };
              })(i);

              // Read in the image file as a data URL.
              reader.readAsDataURL(f);
          }
      }

      function LoadFromJsonObject(ImageJsonObject)
      {
          FileToUpload = [];
          var FileFromJson = [];
          for (var i = 0, f; imgObj = ImageJsonObject[i]; i++) {
              if (i == 0)
              {
                  $('#txtImgInspectionDescription').val((imgObj.InspectionDesc) ? imgObj.InspectionDesc : "");
              }
              var filobj = dataURItoBlob(imgObj.ImageDataString, imgObj.ImageDescription, imgObj.ImageId);
              FileFromJson.push(filobj);
          }
          LoadUI(FileFromJson);
      }
      function LoadFromJsonObjectRemote(ImageJsonObject) {
          FileToUpload = [];
          var FileFromJson = [];
          for (var i = 0, f; imgObj = ImageJsonObject[i]; i++) {
              if (i == 0) {
                  $('#txtImgInspectionDescription').val((imgObj.inspectionDesc) ? imgObj.inspectionDesc : "");
              }
              var filobj = dataURItoBlob(imgObj.imageDataString, imgObj.imageDescription, imgObj.imageId);
              FileFromJson.push(filobj);
          }
          LoadUI(FileFromJson);
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
          if(ImageDataInforObj)
          {
              $('#txtPlateTypeNotPossibleReason').val((ImageDataInforObj.PlateTypeNotPossibleReason) ? ImageDataInforObj.PlateTypeNotPossibleReason : "");
              if (ImageDataInforObj.IsPlateTypeNotPossible != null)
                  $('#chkIsPlateTypeNotPossible').attr('checked', ImageDataInforObj.IsPlateTypeNotPossible);
              else
                  $('#chkIsPlateTypeNotPossible').attr('checked', false);

              var parent =  $('#chkIsPlateTypeNotPossible').parent()
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
      function loadinfoFromJsonRemote(ImageDataInforObj) {
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
          ImageDataInforObj.IsPlateTypeNotPossible = $('#chkIsPlateTypeNotPossible').is(':checked');
          ImageDataInforObj.PlateTypeNotPossibleReason = ($('#chkIsPlateTypeNotPossible').is(':checked') == true) ? $('#txtPlateTypeNotPossibleReason').val() : "";
          return ImageDataInforObj;
      }
    </script>