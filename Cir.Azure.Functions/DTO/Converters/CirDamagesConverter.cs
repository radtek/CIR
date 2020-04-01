using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cir.Repository;
using Newtonsoft.Json.Linq;

namespace Cir.Azure.Functions
{
    class CirDamagesConverter : IConverter
    {
        public string Format => "damages";
        public JObject Convert(IList<JObject> cirs)
        {
            if (cirs == null)
                throw new ArgumentNullException("cirs");

            try
            {
                var result = new CirDamagesListDto
                {
                    Data = ConvertData(cirs).ToList()
                };
                return JObject.FromObject(result);
            }
            catch (Exception e)
            {
                throw new ConvertException(
                    $"{GetType().Name} failed to convert: {e.Message}",
                    NoThrowHelpers.ToString(cirs),
                    e);
            }
        }

        public JObject Convert(JObject cir)
        {
            if (cir == null)
                throw new ArgumentNullException("cir");

            try
            {
                var data = ConvertData(cir);
                if (data == null)
                {
                    return null;
                }
                var result = new CirDamagesSingleDto
                {
                    Data = data
                };
                return JObject.FromObject(result);
            }
            catch (Exception e)
            {
                throw new ConvertException(
                    $"{GetType().Name} failed to convert: {e.Message}",
                    NoThrowHelpers.ToString(cir),
                    e);
            }
        }

        private IEnumerable<CirDamagesData> ConvertData(IList<JObject> cirs)
        {
            foreach (var cir in cirs)
            {
                var result = ConvertData(cir);
                if (result != null)
                {
                    yield return result;
                }
            }
        }
        private CirDamagesData ConvertData(JObject cir)
        {
            if (cir["cirSubmissionData"]?["state"]?.ValueOrDefault<string>() == "Removed")
            {
                return null;
            }
            if (cir["cirSubmissionData"]?["state"]?.ValueOrDefault<string>() == "Rejected")
            {
                return null;
            }

            if (HasDamage(cir))
            {
                IEnumerable<CirDamage> damages = GetDamages(cir);
                if (damages.Count() > 0)
                {
                    var result = new CirDamagesData();
                    var cirSubmissionData = cir["cirSubmissionData"];
                    var data = cirSubmissionData?["data"];

                    result.CirId = cirSubmissionData?["cirId"]?.ValueOrDefault<int?>();
                    result.CirGuid = cirSubmissionData?["id"]?.ValueOrDefault<string>();
                    result.TurbineId = data?["txtTurbineNumber"]?.ValueOrDefault<int?>();
                    result.Damages = damages.ToList();
                    result.InspectionDescription = data?["txtReasonforService"]?.ValueOrDefault<string>();
                    result.InspectionDate = data?["dtInspectionDate"]?.ValueOrDefault<string>();
                    return result;
                }
            }
            return null;
        }

        private bool HasDamage(JObject cir)
        {
            try
            {
                var imageComponentKey = cir["cirSubmissionData"]?["data"]?["imagecomponentKey"];
                var sections = GetSections((JObject)imageComponentKey?["sections"]);
                foreach (var section in sections)
                {
                    foreach (var image in section["images"])
                    {
                        var severity = image["damageSeverity"].ValueOrDefault<int?>();
                        if (severity != null && severity.Value > 0)
                        {
                            return true;
                        }
                    }
                }

            }
            catch (Exception)
            {
                //This could happen if on of the above fields are not present
                return false;
            }
            return false;
        }

        private IEnumerable<JObject> GetSections(JObject sections)
        {
            if (sections == null)
                yield break;
            if (sections["section1"] != null)
                yield return (JObject)sections["section1"];
            if (sections["section2"] != null)
                yield return (JObject)sections["section2"];
            if (sections["section3"] != null)
                yield return (JObject)sections["section3"];
            if (sections["section4"] != null)
                yield return (JObject)sections["section4"];
            if (sections["section5"] != null)
                yield return (JObject)sections["section5"];
            if (sections["section6"] != null)
                yield return (JObject)sections["section6"];
            if (sections["section7"] != null)
                yield return (JObject)sections["section7"];
            if (sections["section8"] != null)
                yield return (JObject)sections["section8"];
            if (sections["section9"] != null)
                yield return (JObject)sections["section9"];
            if (sections["section10"] != null)
                yield return (JObject)sections["section10"];
            if (sections["section11"] != null)
                yield return (JObject)sections["section11"];
            if (sections["section12"] != null)
                yield return (JObject)sections["section12"];
        }

        private IEnumerable<CirDamage> GetDamages(JObject cir)
        {
            var sections = GetSections((JObject)cir["cirSubmissionData"]?["data"]?["imagecomponentKey"]?["sections"]);
            foreach (var section in sections)
            {
                if (section["images"] == null)
                {
                    continue;
                }
                foreach (var image in section["images"])
                {
                    var severity = image["damageSeverity"].ValueOrDefault<int?>();
                    if (severity != null && severity.Value > 0)
                    {
                        if (TryGetImageUrl(cir, (string)image["imageId"], out string imageUrl))
                        {
                            if (TryGetDamageType(cir, (string)image["imageId"], out string damageType))
                            {
                                var damage = new CirDamage();
                                if ((image["damageDetails"] != null) &&
                                    (((JArray)image["damageDetails"]).Count > 0))
                                {
                                    damage.DamageID = image["damageDetails"][0]["damageId"]?.ValueOrDefault<string>();
                                    damage.DamageGuid = image["damageDetails"][0]["damageGuid"]?.ValueOrDefault<string>();
                                }
                                damage.ImageName = image["fileInfo"]?["name"]?.ValueOrDefault<string>();
                                damage.Description = image["damageDescription"]?.ValueOrDefault<string>();
                                damage.Radius = image["radius"]?.ValueOrDefault<int?>();
                                damage.RootCause = image["rootCause"]?.ValueOrDefault<string>();
                                damage.RecommendedActivity = image["recommendedActivity"]?.ValueOrDefault<string>();
                                damage.Severity = image["damageSeverity"]?.ValueOrDefault<int?>();
                                damage.ImageId = image["imageId"]?.ValueOrDefault<string>();
                                damage.DamagePlacement = image["damagePlacement"]?.ValueOrDefault<string>();
                                damage.Side = section["side"]?.ValueOrDefault<string>();
                                damage.ImageUrl = imageUrl;
                                damage.DamageType = damageType;

                                if ((image["observations"] != null) &&
                                    (((JArray)image["observations"]).Count > 0) &&
                                    (image["observations"][0]["polygons"] != null) &&
                                    (((JArray)image["observations"][0]["polygons"]).Count > 0) &&
                                    (image["observations"][0]["polygons"][0]["geometry"] != null) &&
                                    (((JArray)image["observations"][0]["polygons"][0]["geometry"]).Count >= 3))
                                {
                                    var polygon = image["observations"][0]["polygons"][0]["geometry"];
                                    var x1 = polygon[0]["x"].ValueOrDefault<int?>();
                                    var y1 = polygon[0]["y"].ValueOrDefault<int?>();
                                    var x2 = polygon[2]["x"].ValueOrDefault<int?>();
                                    var y2 = polygon[2]["y"].ValueOrDefault<int?>();
                                    if (x1 != null &&
                                        y1 != null &&
                                        x2 != null &&
                                        y2 != null)
                                    {
                                        damage.BoundingBox = new BoundingBox();
                                        damage.BoundingBox.Left = x1.Value;
                                        damage.BoundingBox.Top = y1.Value;
                                        damage.BoundingBox.Width = x2.Value - x1.Value;
                                        damage.BoundingBox.Height = y2.Value - y1.Value;
                                    }
                                }


                                yield return damage;
                            }
                        }
                    };
                }
            }
        }
        private bool TryGetImageUrl(JObject cir, string imageId, out string url)
        {
            var references = cir["cirSubmissionData"]?["imageReferences"];
            if (references == null)
            {
                url = null;
                return false;
            }
            foreach (var i in references)
            {
                if (i["imageId"]?.ValueOrDefault<string>() == imageId)
                {
                    url = i["url"]?.ValueOrDefault<string>();
                    return true;
                }
            }
            url = null;
            return false;
        }

        private bool TryGetDamageType(JObject cir, string imageId, out string damageType)
        {
            var cache = cir["cirSubmissionData"]?["data"]?["imagecomponentKey"]?["uploadedImagesCache"];
            if (cache == null)
            {
                damageType = null;
                return false;
            }
            foreach (var i in cache)
            {
                if (i["imageId"]?.ValueOrDefault<string>() == imageId)
                {
                    damageType = i["damageType"]?.ValueOrDefault<string>();
                    return true;
                }
            }
            damageType = null;
            return false;
        }

    }
}
