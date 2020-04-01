using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    public class CirBladeDataModel : IDataModel, ICosmosDbIDataModel
    {
        [JsonProperty(PropertyName = "cirSubmissionData")]
        public BladeSubmissionDataModel CirSubmissionData { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; }
    }

    public class BladeSubmissionDataModel
    {
        [JsonProperty(PropertyName = "data")]
        public BladeDataModel Data { get; set; }

        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "partition")]
        public string Partition { get; set; }

        [JsonProperty(PropertyName = "cirTemplateName")]
        public string CirTemplateName { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public string CreatedOn { get; set; }
        [JsonProperty(PropertyName = "modifiedOn")]
        public string ModifiedOn { get; set; }
    }

    public class BladeDataModel
    {
        [JsonProperty(PropertyName = "imagecomponentKey")]
        public ImagecomponentKey ImageComponentKey { get; set; }

        [JsonProperty(PropertyName = "txtBladeSerialNumber")]
        public string TxtBladeSerialNumber { get; set; }

        [JsonProperty(PropertyName = "dtInspectionDate")]
        public string DtInspectionDate { get; set; }

        [JsonProperty(PropertyName = "txtMKversion")]
        public string TxtMKversion { get; set; }

        [JsonProperty(PropertyName = "txtSBURecommendation")]
        public string TxtSBURecommendation { get; set; }

        [JsonProperty(PropertyName = "ddlBladeLength")]
        public string DdlBladeLength { get; set; }

        [JsonProperty(PropertyName = "txtTurbineNumber")]
        public string TxtTurbineNumber { get; set; }

        [JsonProperty(PropertyName = "dtCommissioningdate")]
        public string DtCommissioningdate { get; set; }

        [JsonProperty(PropertyName = "annualInspection")]
        public string AnnualInspection { get; set; }

        [JsonProperty(PropertyName = "relatedCirs")]
        public object RelatedCirs { get; set; }
    }

    public class ImagecomponentKey
    {
        [JsonProperty(PropertyName = "uploadedImagesCache")]
        public List<UploadedImagesCache> UploadedImagesCache { get; set; }

        [JsonProperty(PropertyName = "withPlatePicture")]
        public bool WithPlatePicture { get; set; }
    }


    public class UploadedImagesCache
    {
        [JsonProperty(PropertyName = "groupId")]
        public long GroupId { get; set; }

        [JsonProperty(PropertyName = "width")]
        public double Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public double Height { get; set; }

        [JsonProperty(PropertyName = "imageId")]
        public string ImageId { get; set; }

        [JsonProperty(PropertyName = "checked")]
        public bool @Checked { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "region")]
        public int Region { get; set; }

        [JsonProperty(PropertyName = "imageName")]
        public string ImageName { get; set; }

        [JsonProperty(PropertyName = "imageNumber")]
        public int ImageNumber { get; set; }

        [JsonProperty(PropertyName = "uploadedAt")]
        public string UploadedAt { get; set; }

        [JsonProperty(PropertyName = "damagePlacement")]
        public string DamagePlacement { get; set; }

        [JsonProperty(PropertyName = "damageType")]
        public string DamageType { get; set; }

        [JsonProperty(PropertyName = "side")]
        public string Side { get; set; }

        [JsonProperty(PropertyName = "radius")]
        public string Radius { get; set; }

        [JsonProperty(PropertyName = "damageDescription")]
        public string DamageDescription { get; set; }

        [JsonProperty(PropertyName = "damageDescriptionText")]
        public string DamageDescriptionText { get; set; }

        [JsonProperty(PropertyName = "damageSeverity")]
        public int DamageSeverity { get; set; }

        [JsonProperty(PropertyName = "saved")]
        public bool Saved { get; set; }

        [JsonProperty(PropertyName = "damageIdentified")]
        public bool DamageIdentified { get; set; }
    }
}

