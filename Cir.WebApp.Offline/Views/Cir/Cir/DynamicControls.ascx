<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<fieldset>
        <legend><span id="DynamicHeader"></span></legend>
        <div class="form-group">
            <label class="col-lg-3 control-label">Findings at visual inspection</label>
            <div class="col-lg-9">
                <input type="checkbox" id="chkDamageIdentifiedSimplified"   value="Findings at visual inspection" />
            </div>
        </div>
    <div id="showHideFlangeSections" style="display:none">
        <div class="form-group">
            <label class="col-lg-3 control-label" id="rowHeader1"></label>
            <div class="col-lg-9">
                <select id="controlHeader1" class="form-control" data-fieldtype="selectDynamic" data-datatable="1" data-textfield="Values" data-valuefield="ValueId" data-toggle="tooltip"
                    data-placement="top" data-insertlable="false" data-sort="true">
                    <option value='-1'></option>
            </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label" id="rowHeader2"><span class="errorSpan">*</span></label>
            <div class="col-lg-9">
                <select id="controlHeader2" class="form-control" data-fieldtype="selectDynamic" data-datatable="2" data-textfield="Values" data-valuefield="ValueId" data-toggle="tooltip"
                    data-placement="top" data-insertlable="false" data-sort="true">
                    <option value='-1' ></option>
            </select>
        </div>
            </div>
      <div class="form-group">
            <label class="col-lg-3 control-label" id="rowHeader13"></label>
            <div class="col-lg-9">
                <input type="number" id="txtrowHeader13" data-toggle="tooltip"
                    data-placement="top" title="" class="form-control numbersOnly"  />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label" id="rowHeader3"></label>
            <div class="col-lg-9">
                <input type="number" id="txtrowHeader3" data-toggle="tooltip"
                    data-placement="top" title="" class="form-control numbersOnly"  />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label" id="rowHeader4"></label>
            <div class="col-lg-9">
                 <select id="controlHeader4" class="form-control" data-fieldtype="selectDynamic" data-datatable="4" data-textfield="Values" data-valuefield="ValueId" data-toggle="tooltip"
                    data-placement="top" >     
                     <option value='-1'></option>           
                </select>

            </div>
        </div>
        <div class="form-group manMovFlang" style="display:none">
            <label class="col-lg-3 control-label" id="rowHeader5"></label>
            <div class="col-lg-9">
                <input type="number" id="txtrowHeader5" data-toggle="tooltip"
                    data-placement="top" title="" class="form-control numbersOnly"   />
            </div>
        </div>
        <div class="form-group manMovFlang" style="display:none">
            <label class="col-lg-3 control-label" id="rowHeader6"></label>
            <div class="col-lg-9">
                <input type="number" id="txtrowHeader6" data-toggle="tooltip"
                    data-placement="top" title="" class="form-control numbersOnly"  />
            </div>
        </div>
        <div class="form-group manMovFlang" style="display:none">
            <label class="col-lg-3 control-label" id="rowHeader7"></label>
            <div class="col-lg-9">
                <input type="number" id="txtrowHeader7" data-toggle="tooltip"
                    data-placement="top" title="" class="form-control numbersOnly" />
            </div>
        </div>
         <div class="form-group">
            <label class="col-lg-3 control-label" id="rowHeader14"></label>
            <div class="col-lg-9">
                <input type="number" id="txtrowHeader14" data-toggle="tooltip"
                    data-placement="top" title="" class="form-control numbersOnly"  />
            </div>
        </div>  
        <div class="form-group">
            <label class="col-lg-3 control-label" id="rowHeader8"></label>
            <div class="col-lg-9">
               <%-- <input type="checkbox" id="chkrowHeader8" />--%>
               <select id="chkrowHeader8" class="form-control" data-toggle="tooltip" 
                data-placement="top"  >
                <option value="-1" selected="selected"></option>
                <option value="1">No</option>
                <option value="2">Yes</option>
            </select>
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label" id="rowHeader9"></label>
            <div class="col-lg-9">
                <input type="number" id="txtrowHeader9" data-toggle="tooltip"
                    data-placement="top" title="" class="form-control numbersOnly"  />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label" id="rowHeader10"></label>
            <div class="col-lg-9">
                <input type="number" id="txtrowHeader10" data-toggle="tooltip"
                    data-placement="top" title="" class="form-control numbersOnly" />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label" id="rowHeader11"></label>
            <div class="col-lg-9">
                <input type="number" id="txtrowHeader11" data-toggle="tooltip"
                    data-placement="top" title="" class="form-control numbersOnly"  />
            </div>
        </div>
        <div class="form-group">
            <label class="col-lg-3 control-label" id="rowHeader12"></label>
            <div class="col-lg-9">
                <input type="number" id="txtrowHeader12" data-toggle="tooltip"
                    data-placement="top" title="" class="form-control numbersOnly"  />
            </div>
        </div>
            
        <h4>Images</h4>
       <div id="ImageSection1">            
            <div class="form-group">
                <label class="col-lg-3 control-label">Upload Images</label>
                <div class="col-lg-9">
                    <div class="image-droppable imagedropA">
                        <p>Drag files here or click to upload</p>
                    </div>
                    <input type="file" id="files" name="files[]" accept=".jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|images/*" multiple class="hide" style="display: none">
                    <label for="files" class="btn btn-primary" style="display: none">Choose Image</label>
                    
                    <hr />
                    <b>Preview</b>
                    
                    <div class="form-group">
                        <div id="list1" class="ImageThumbList">
                        </div>                        
                    </div>

                </div>

            </div>
            <div class="form-group">
                <div id="dvPreview1" class="col-xs-12">
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Inspection Description<br /> (Internal Note)</label>
                <div class="col-lg-9">
                    <textarea id="txtImgInspectionDescription1" class="form-control" rows="3" placeholder="Inspection Description"></textarea>
                </div>
            </div>
        </div>       
        <div id="ImageSection2" >            
            <div class="form-group">
                <label class="col-lg-3 control-label">Upload Images</label>
                <div class="col-lg-9">
                    <div class="image-droppable imagedropB">
                        <p>Drag files here or click to upload</p>
                    </div>
                    <input type="file" id="files2" name="files2[]" accept=".jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|images/*" multiple class="hide" style="display: none">
                    <label for="files" class="btn btn-primary" style="display: none">Choose Image</label>
                    
                    <hr />
                    <b>Preview</b>
                    
                    <div class="form-group">
                        <div id="list2" class="ImageThumbList">
                        </div>                        
                    </div>

                </div>

            </div>
            <div class="form-group">
                <div id="dvPreview2" class="col-xs-12">
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Inspection Description<br /> (Internal Note)</label>
                <div class="col-lg-9">
                    <textarea id="txtImgInspectionDescription2" class="form-control" rows="3" placeholder="Inspection Description"></textarea>
                </div>
            </div>
        </div>
      <div id="ImageSection3">
            <div class="form-group">
                <label class="col-lg-3 control-label">Upload Images</label>
                <div class="col-lg-9">
                    <div class="image-droppable imagedropC">
                        <p>Drag files here or click to upload</p>
                    </div>
                    <input type="file" id="files3" name="files3[]" accept=".jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|images/*" multiple class="hide" style="display: none">
                    <label for="files" class="btn btn-primary" style="display: none">Choose Image</label>
                    
                    <hr />
                    <b>Preview</b>
                    
                    <div class="form-group">
                        <div id="list3" class="ImageThumbList">
                        </div>
                        
                    </div>

                </div>

            </div>
            <div class="form-group">
                <div id="dvPreview3" class="col-xs-12">
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Inspection Description<br /> (Internal Note)</label>
                <div class="col-lg-9">
                    <textarea id="txtImgInspectionDescription3" class="form-control" rows="3" placeholder="Inspection Description"></textarea>
                </div>
            </div>
        </div>
        <div id="ImageSection4" >
           <div class="form-group">
                <label class="col-lg-3 control-label">Upload Images</label>
                <div class="col-lg-9">
                    <div class="image-droppable imagedropD">
                        <p>Drag files here or click to upload</p>
                    </div>
                    <input type="file" id="files4" name="files4[]" accept=".jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|images/*" multiple class="hide" style="display: none">
                    <label for="files" class="btn btn-primary" style="display: none">Choose Image</label>
                    
                    <hr />
                    <b>Preview</b>
                    
                    <div class="form-group">
                        <div id="list4" class="ImageThumbList">
                        </div>
                        
                    </div>

                </div>

            </div>
            <div class="form-group">
                <div id="dvPreview4" class="col-xs-12">
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Inspection Description<br /> (Internal Note)</label>
                <div class="col-lg-9">
                    <textarea id="txtImgInspectionDescription4" class="form-control" rows="3" placeholder="Inspection Description"></textarea>
                </div>
            </div>
        </div>
        <div id="ImageSection5" >
           <div class="form-group">
                <label class="col-lg-3 control-label">Upload Images</label>
                <div class="col-lg-9">
                    <div class="image-droppable imagedropE">
                        <p>Drag files here or click to upload</p>
                    </div>
                    <input type="file" id="files5" name="files5[]" accept=".jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|images/*" multiple class="hide" style="display: none">
                    <label for="files" class="btn btn-primary" style="display: none">Choose Image</label>
                    
                    <hr />
                    <b>Preview</b>
                    
                    <div class="form-group">
                        <div id="list5" class="ImageThumbList">
                        </div>
                         
                    </div>

                </div>

            </div>
            <div class="form-group">
                <div id="dvPreview5" class="col-xs-12">
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Inspection Description<br /> (Internal Note)</label>
                <div class="col-lg-9">
                    <textarea id="txtImgInspectionDescription5" class="form-control" rows="3" placeholder="Inspection Description"></textarea>
                </div>
            </div>
        </div>
        <div id="ImageSection6" >
           <div class="form-group">
                <label class="col-lg-3 control-label">Upload Images</label>
                <div class="col-lg-9">
                    <div class="image-droppable imagedropF">
                        <p>Drag files here or click to upload</p>
                    </div>
                    <input type="file" id="files6" name="files6[]" accept=".jpg, .png, .jpeg, .gif, .bmp, .tif, .tiff|images/*" multiple class="hide" style="display: none">
                    <label for="files" class="btn btn-primary" style="display: none">Choose Image</label>
                    
                    <hr />
                    <b>Preview</b>
                    
                    <div class="form-group">
                        <div id="list6" class="ImageThumbList">
                        </div>
                        
                    </div>

                </div>

            </div>
            <div class="form-group">
                <div id="dvPreview6" class="col-xs-12">
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Inspection Description<br /> (Internal Note)</label>
                <div class="col-lg-9">
                    <textarea id="txtImgInspectionDescription6" class="form-control" rows="3" placeholder="Inspection Description"></textarea>
                </div>
            </div>
        </div>
        <div id="DecisionSection">
            <div class="form-group">
                <label class="col-lg-3 control-label">Decision</label>
                <div class="col-lg-9">
                     <select id="controlDecision" class="form-control" data-fieldtype="selectDynamic" data-datatable="13" data-textfield="Values" data-valuefield="ValueId" data-toggle="tooltip"
                    data-placement="top"  data-insertlable="false" data-sort="true">
                         <option value='-1' ></option>
            </select>
                </div>
            </div>
            <h4>Interim actions for WTG continued operation until full tower flange bolt replacement</h4>           
            <div class="form-group">
                <label class="col-lg-3 control-label">Repeated inspection</label>
                <div class="col-lg-9">
                     <select id="controlRepeatedInspection" class="form-control" data-fieldtype="selectDynamic" data-datatable="15" data-textfield="Values" data-valuefield="ValueId" data-toggle="tooltip"
                    data-placement="top" data-insertlable="false" data-sort="true"><option value='-1' ></option></select>
                </div>
            </div>
            <div class="form-group">
                <label class="col-lg-3 control-label">Replace affected Bolts</label>
                <div class="col-lg-9">
                    <input type="checkbox" id="chkReplaceAffectedBolts" value="Replace affected Bolts" />
                </div>
            </div>
        </div>
        </div>
        <div class="form-group">
            <div class="col-xs-12" style="text-align: right;">
                <a href="javascript:void(0);" id="linkDynamicControlPrev" onclick="SaveSimplifiedCirFlange(this,'Prev')" class="btn btn-primary">Previous</a>
                <a href="javascript:void(0);" id="linkDynamicControlNext" onclick="SaveSimplifiedCirFlange(this,'Next')" class="btn btn-primary">Next</a>
            </div>
        </div>
</fieldset>

