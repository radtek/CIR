using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Web.Optimization;

namespace Cir.WebApp.Offline
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js-admin").Include(
                        "~/js/jquery-1.10.1.min.js",
                        "~/js/jquery-ui-1.10.3.min.js",
                        "~/js/bootstrap.min.js",
                        "~/js/jquery.validate.min.js",
                        "~/js/jquery.validate.unobtrusive.min.js",
                        "~/js/app.js",
                        "~/js/common.admin.js"
                        ));

            ScriptBundle multibrandJS = new ScriptBundle("~/bundles/js-multibrand");
            multibrandJS.Orderer = new AsIsBundleOrderer();
            multibrandJS.Include(
                "~/Js/ckeditor.js",
                "~/Js/AngularJS/angular.js",
                "~/Js/angular-json-explorer.js",
                "~/Js/FormIO/formio.js",
                "~/Js/FormIO/ngFormBuilder-full.js",
                "~/Js/lodash.js",
                "~/Js/swiper/swiper.js",
                "~/Js/ApplicationScripts/FormIO/FormBuilder.js",
                "~/Js/ApplicationScripts/FormIO/FormRenderer.js",
                "~/Js/ApplicationScripts/FormIO/ExpandablePanelHandler.js",
                "~/Js/Angular/GlobalVariables.js",
                "~/Js/Angular/Directives/FileDropAreaDirective.js",
                "~/Js/Angular/Directives/FileModelDirective.js",
                "~/Js/Angular/Directives/SortableContainerDirective.js",
                "~/Js/Angular/Directives/FileInputChange.js",
                "~/Js/Angular/Directives/DroppableFileAreaDirective.js",
                "~/Js/Angular/Directives/DraggableElementDirective.js",
                "~/Js/Angular/Components/ImagePreviewComponent.js",
                "~/Js/Angular/Components/ImageMetadataComponent.js",
                "~/Js/Angular/Components/ImageMetadataListComponent.js",
                "~/Js/Angular/Components/ImageUploaderComponent.js",
                "~/Js/Excel/xlsx.js",
                "~/Js/Angular/Directives/ImportExcelSheetDataDirective.js",
                "~/Js/Angular/Components/DropdownDataItemComponent.js",
                "~/Js/Angular/Components/DropdownDataListComponent.js",
                "~/Js/Angular/Components/DropdownDataComponent.js",
                "~/Js/Angular/Components/AdvancedValidationDisplayComponent.js",
                "~/Js/Angular/Components/AdvancedValidationComponent.js",
                "~/Js/Angular/Services/CirDataService.js",
                "~/Js/Angular/Services/CirTemplateService.js",
                "~/Js/Angular/Services/HotListService.js",
                "~/Js/Angular/Services/CirImageService.js",
                "~/Js/Angular/Services/HttpService.js",
                "~/Js/Angular/Services/UrlAnchorService.js",
                "~/Js/Angular/Services/UrlHashService.js",
                "~/Js/ApplicationScripts/Polyfills/array.filter.js",
                "~/Js/ApplicationScripts/Polyfills/array.map.js",
                "~/Js/ApplicationScripts/Polyfills/array.findIndex.js",
                "~/Js/ApplicationScripts/Polyfills/array.reduce.js",
                "~/Js/ApplicationScripts/Polyfills/object.keys.js",
                "~/Js/Angular/Components/CustomSlider.js",
                "~/Js/Angular/Components/DynamicFieldsComponent.js",                
                "~/Js/Angular/Components/DynamicFieldsOtherComponent.js",
                "~/Js/Angular/Components/AdvancedValidationComponent.js",
                "~/Js/Angular/Components/ComponentInspection/BiImageService.js",
                "~/Js/Angular/Components/ComponentInspection/ImageInspectionValidator.js",
                "~/Js/Angular/Components/ComponentInspection/damageDescriptions.js",
                "~/Js/Angular/Components/ComponentInspection/ImageInspectionToolComponent.js",
                "~/Js/Angular/Components/ComponentInspection/CanvasRendererController.js",
                "~/Js/Angular/Components/ComponentInspection/ImageEditModal.js",
                "~/Js/Angular/Components/ComponentInspection/ImageModelMapper.js",
                "~/Js/Angular/Components/ComponentInspection/ImageInspectionUtils.js",
                "~/Js/Angular/Components/ComponentInspection/BlobModelManager.js",
                "~/Js/Angular/Components/ComponentInspection/FilterableSelect.js",
                 "~/Js/Angular/Components/ComponentInspection/ImageInspectionPreviewComponent.js",
                "~/Js/Angular/Components/TurbineDataDisplayComponent.js",
                "~/Js/Angular/Components/TurbineDataComponent.js",
                "~/Js/ApplicationScripts/array.bitcompress.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/CustomDropdown.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/ImageUploader.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/ComponentInspection/Utils.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/ComponentInspection/PixelMatrix.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/ComponentInspection/CanvasController.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/ComponentInspection/LabelingController.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/ComponentInspection/SidesController.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/ComponentInspection/MasterController.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/ComponentInspection/CanvasRegions.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/SubmitForm.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/CustomSlider.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/DynamicFields.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/CirNavigation.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/ValidationConfigurator.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/TurbineData.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/ToggleButton.js",
                "~/Js/ApplicationScripts/FormIO/CustomControls/RoleToggleButton.js",
                "~/Js/material-ui/material-ui-init.js",
                "~/Js/ApplicationScripts/FormIO/FormRules.js",
                "~/Js/BladeInspections/NonDroneInspection.js"
            );

            bundles.Add(multibrandJS);

            bundles.Add(new StyleBundle("~/bundles/css-admin").Include(
                     "~/css/bootstrap.min.css",
                     "~/css/material-ui/formio-material.css",
                     "~/css/font-awesome.min.css",
                     "~/css/ionicons.min.css",
                     "~/css/AdminTheme.css",
                     "~/Css/swiper/swiper.css",
                     "~/css/Admin.css",
                     "~/css/color.css",
                     "~/css/datatables/dataTables.bootstrap.css",
                     "~/css/OfflineCss/offline-language-english.css",
                     "~/css/OfflineCss/offline-theme-chrome.css",
                     "~/css/animate.css",
                     "~/css/AddToHome/addtohomescreen.css",
                     "~/css/jquery.tokenize.css",
                     "~/css/jquery-confirm.min.css"
                     ));

            var ngTemplateBundle = new AngularTemplateBundle("formio", "~/bundles/ng-templates")
                .IncludeDirectory("~/Js/Angular/Templates", "*.html");

            bundles.Add(ngTemplateBundle);

            bundles.Add(new StyleBundle("~/bundles/css-multibrand").Include(
                "~/Css/formio/ngFormBuilder-full.css",
                "~/Css/formio/formio-full.css",
                "~/Css/formio/angular-json-explorer.min.css",
                "~/Css/formio/font-awesome.min.css",
                "~/Css/formio/browsehappy.css",
                "~/css/material-ui/formio-material.css",
                "~/Css/toggleButton.css",
                "~/Css/bootstrap-toggle.min.css"
            ));

            BundleTable.EnableOptimizations = true;
        }
    }

    public class AsIsBundleOrderer : IBundleOrderer
    {
        public virtual IEnumerable<FileInfo> OrderFiles(BundleContext context, IEnumerable<FileInfo> files)
        {
            return files;
        }
    }

    public class AngularTemplateBundle : Bundle
    {
        public AngularTemplateBundle(string moduleName, string virtualPath)
            : base(virtualPath, new[] { new AngularTemplateTransform(moduleName) })
        {
        }
    }

    public class AngularTemplateTransform : IBundleTransform
    {
        private readonly string _moduleName;
        public AngularTemplateTransform(string moduleName)
        {
            _moduleName = moduleName;
        }

        public void Process(BundleContext context, BundleResponse response)
        {
            var angularCacheBuilder = new StringBuilder();
            angularCacheBuilder.Append($"angular.module('{_moduleName}').run(['$templateCache',function(t){{");

            foreach (var file in response.Files)
            {
                var fileContent = File.ReadAllText(file.FullName).Replace("\r\n", "").Replace("'", "\\'");
                angularCacheBuilder.Append($"t.put('{file.Name}','{fileContent}');");
            }
            angularCacheBuilder.Append("}]);");

            response.Files = new FileInfo[] { };
            response.Content = angularCacheBuilder.ToString();
            response.ContentType = "text/javascript";
        }
    }
}