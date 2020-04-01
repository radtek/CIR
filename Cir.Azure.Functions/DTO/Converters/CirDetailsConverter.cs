using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Azure.Functions
{
    class CirDetailsConverter : IConverter
    {
        public string Format => "details";

        public JObject Convert(IList<JObject> cirs)
        {
            if (cirs == null)
                throw new ArgumentNullException("cirs");

            try
            {
                var result = new CirDetailsListDto
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
                var result = new CirDetailsSingleDto
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

        private IEnumerable<CirDetailsData> ConvertData(IList<JObject> cirs)
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

        private CirDetailsData ConvertData(JObject cir)
        {
            var result = new CirDetailsData();
            var cirSubmissionData = cir["cirSubmissionData"];
            if (cirSubmissionData?["state"]?.ValueOrDefault<string>() == "Removed")
            {
                return null;
            }
            if (cirSubmissionData?["state"]?.ValueOrDefault<string>() == "Rejected")
            {
                return null;
            }
            var data = cirSubmissionData?["data"];
            var bladeLength = data?["ddlBladeLength"]?.ValueOrDefault<string>();
            if (bladeLength != null)
            {
                BladeLengthMap.TryGetValue(bladeLength, out var newBladeLength);
                if (newBladeLength != null)
                {
                    bladeLength = newBladeLength;
                }
            }

            result.CirId = cirSubmissionData?["cirId"]?.ValueOrDefault<int?>();
            result.CirGuid = cirSubmissionData?["id"]?.ValueOrDefault<string>();
            result.TurbineId = data?["txtTurbineNumber"]?.ValueOrDefault<int?>();
            result.LocalTurbineId = data?["txtLocalturbineId"]?.ValueOrDefault<string>();
            result.BladeLength = bladeLength;
            result.BladeSerialNumber = data?["txtBladeSerialNumber"]?.ValueOrDefault<string>();
            result.CommissioningDate = data?["dtCommissioningdate"]?.ValueOrDefault<string>();
            result.InspectionDate = data?["dtInspectionDate"]?.ValueOrDefault<string>();
            result.MkVersion = data?["txtMKversion"]?.ValueOrDefault<string>();
            result.State = cirSubmissionData?["state"]?.ValueOrDefault<string>();
            result.SbuRecommendation = data?["txtSBURecommendation"]?.ValueOrDefault<string>();
            result.Section1 = GetSection(cir, 1);
            result.Section2 = GetSection(cir, 2);
            result.Section3 = GetSection(cir, 3);
            result.Section4 = GetSection(cir, 4);
            result.Section5 = GetSection(cir, 5);
            result.Section6 = GetSection(cir, 6);
            result.Section7 = GetSection(cir, 7);
            result.Section8 = GetSection(cir, 8);
            result.Section9 = GetSection(cir, 9);
            result.Section10 = GetSection(cir, 10);
            result.Section11 = GetSection(cir, 11);
            result.Section12 = GetSection(cir, 12);
            result.NoSection = GetNoSection(cir);
            result.PlateImageUrl = GetPlateImageUrl(cir);
            return result;
        }


        private Section GetSection(JObject cir, int sectionId)
        {
            var section = GetCirSection(cir, sectionId);
            if (section == null)
            {
                return null;
            }
            IEnumerable<Image> images = GetImages(cir, section);
            return new Section
            {
                Side = section["side"]?.ValueOrDefault<string>(),
                Images = images.ToList()
            };
        }

        private IEnumerable<Image> GetImages(JObject cir, JObject section)
        {
            foreach (var image in section["images"])
            {
                JObject cache = GetUploadedImageCacheForImage(cir, (string)image["imageId"]);
                JObject reference = GetImageReferenceForImage(cir, (string)image["imageId"]);
                yield return new Image
                {
                    ImageGuid = image["imageId"]?.ValueOrDefault<string>(),
                    ImageNumber = image["number"]?.ValueOrDefault<int?>(),
                    Severity = cache?["damageSeverity"]?.ValueOrDefault<int?>(),
                    Url = reference?["url"]?.ValueOrDefault<string>(),
                    DamageType = cache?["damageType"]?.ValueOrDefault<string>(),
                    DamageDescription = image["damageDescription"]?.ValueOrDefault<string>()
            };
            }
        }

        private JObject GetUploadedImageCacheForImage(JObject cir, string imageGuid)
        {
            var cache = cir["cirSubmissionData"]?["data"]?["imagecomponentKey"]?["uploadedImagesCache"];
            if (cache == null)
            {
                return null;
            }
            foreach (var image in cache)
            {
                if (image["imageId"]?.ValueOrDefault<string>() == imageGuid)
                {
                    return (JObject)image;
                }
            }

            return null;
        }

        private JObject GetImageReferenceForImage(JObject cir, string imageGuid)
        {
            var references = cir["cirSubmissionData"]?["imageReferences"];
            if (references == null)
            {
                return null;
            }
            foreach (var image in references)
            {
                if (image["imageId"]?.ValueOrDefault<string>() == imageGuid)
                {
                    return (JObject)image;
                }
            }
            return null;
        }


        private JObject GetCirSection(JObject cir, int sectionId)
        {
            JToken sections = cir["cirSubmissionData"]?["data"]?["imagecomponentKey"]?["sections"];

            if (sections == null || !sections.HasValues)
            {
                return null;
            }

            var section = sections?["section" + sectionId];

            if (!(section is JObject))
            {
                return null;
            }
            else
            {
                return (JObject)section;
            }
        }



        private Dictionary<string, string> BladeLengthMap = new Dictionary<string, string>
        {
             { "1", "20.5" },
            { "2", "23" },
            { "3", "25" },
            { "4", "32" },
            { "5", "39" },
            { "6", "44" },
            { "7", "49" },
            { "8", "AL23,8" },
            { "9", "AL26,8" },
            { "10", "AL31,8" },
            { "11", "AL35,8" },
            { "12", "AL40,8" },
            { "13", "LM19,1" },
            { "14", "LM21,5" },
            { "15", "LM23,2" },
            { "16", "LM23,5" },
            { "17", "LM25,2" },
            { "18", "LM25,5" },
            { "19", "LM26,0" },
            { "20", "LM26,1" },
            { "21", "LM29,0" },
            { "22", "LM29,1" },
            { "23", "LM31,2" },
            { "24", "LM35,0" },
            { "25", "LM35.0 P2" },
            { "26", "LM38,8" },
            { "27", "LM44,8" },
            { "28", "LM54,0" },
            { "29", "N/A" },
            { "30", "10.5" },
            { "31", "11.5" },
            { "32", "13" },
            { "33", "17" },
            { "34", "19" },
            { "35", "LM40,1" },
            { "36", "55" },
            { "37", "51" },
            { "38", "54" },
            { "39", "62" },
            { "40", "67" },
            { "41", "57" },
            { "42", "43.8m" },
            { "43", "40m" },
            { "44", "45m" },
            { "45", "34" },
            { "46", "37.3" },
            { "47", "40.3" },
            { "48", "48.7" },
            { "49", "38.8" },
            { "50", "40" },
            { "51", "43" },
            { "52", "46" },
            { "53", "50.2" },
            { "54", "23" },
            { "55", "25" },
            { "56", "27.5" },
            { "57", "39" },
            { "58", "40" },
            { "59", "42.5" },
            { "60", "44" },
            { "61", "47.5" },
            { "62", "59" },
            { "63", "74" },
            { "65", "45.3" },
            { "66", "45" },
            { "67", "46.5" },
            { "68", "37.3" }
        };

        private string GetPlateImageUrl(JObject cir)
        {
            var cache = cir["cirSubmissionData"]?["data"]?["imagecomponentKey"]?["uploadedImagesCache"];
            if (cache == null)
            {
                return null;
            }
            foreach (var image in cache)
            {
                if (image["imageNumber"]?.ValueOrDefault<int>() == 0)
                {
                    var referenceImage = cir["cirSubmissionData"]?["imageReferences"]
                        .SingleOrDefault(i => i["imageId"]?.ValueOrDefault<string>() == image["imageId"].ValueOrDefault<string>());
                    return referenceImage?["url"]?.ValueOrDefault<string>();
                }
            }

            return null;
        }

        // Template 0.8 / 1
        private NoSection GetNoSection(JObject cir)
        {
            IEnumerable<Image> images = GetImages(cir);
            return new NoSection
            {
                OverallBladeCondition = cir["cirSubmissionData"]?["data"]?["csOverallBladeCondition"]?.ValueOrDefault<int>(),
                Images = images.ToList()
            };
        }

        private IEnumerable<Image> GetImages(JObject cir)
        {
            var images = cir["cirSubmissionData"]?["data"]?["page3UploadImages"] as JArray;
            if (images == null)
            {
                yield break;
            }

            var damages = GetDamages(cir);

            for (int i = 0; i < images.Count; ++i)
            {
                var referenceImage = cir["cirSubmissionData"]?["imageReferences"]
                    .SingleOrDefault(image => image["imageId"]?.ValueOrDefault<string>() == images[i]["imageId"].ValueOrDefault<string>());
                var damage = damages
                    .FirstOrDefault(dmg => dmg.ImageNumber == i + 1);
                yield return new Image
                {
                    ImageGuid = images[i]["imageId"]?.ValueOrDefault<string>(),
                    ImageNumber = i + 1,
                    Url = referenceImage?["url"]?.ValueOrDefault<string>(),
                    DamageType = damage?.Type,
                    Side = damage?.Side,
                    DamageDescription = damage?.Description
                };
            }
        }

        private IEnumerable<Damage> GetDamages(JObject cir)
        {
            var data = cir["cirSubmissionData"]?["data"];
            if (data == null)
            {
                yield break;
            }

            yield return new Damage(
                data["ddlbladeEdge1"]?.ValueOrDefault<string>(),
                data["ddldamageType1"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno1"]?.ValueOrDefault<int>(),
                data["txtDamageDescription1"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge2"]?.ValueOrDefault<string>(),
                data["ddldamageType2"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno2"]?.ValueOrDefault<int>(),
                data["txtDamageDescription2"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge3"]?.ValueOrDefault<string>(),
                data["ddldamageType3"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno3"]?.ValueOrDefault<int>(),
                data["txtDamageDescription3"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge4"]?.ValueOrDefault<string>(),
                data["ddldamageType4"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno4"]?.ValueOrDefault<int>(),
                data["txtDamageDescription4"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge5"]?.ValueOrDefault<string>(),
                data["ddldamageType5"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno5"]?.ValueOrDefault<int>(),
                data["txtDamageDescription5"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge6"]?.ValueOrDefault<string>(),
                data["ddldamageType6"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno6"]?.ValueOrDefault<int>(),
                data["txtDamageDescription6"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge7"]?.ValueOrDefault<string>(),
                data["ddldamageType7"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno7"]?.ValueOrDefault<int>(),
                data["txtDamageDescription7"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge8"]?.ValueOrDefault<string>(),
                data["ddldamageType8"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno8"]?.ValueOrDefault<int>(),
                data["txtDamageDescription8"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge9"]?.ValueOrDefault<string>(),
                data["ddldamageType9"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno9"]?.ValueOrDefault<int>(),
                data["txtDamageDescription9"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge10"]?.ValueOrDefault<string>(),
                data["ddldamageType10"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno10"]?.ValueOrDefault<int>(),
                data["txtDamageDescription10"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge11"]?.ValueOrDefault<string>(),
                data["ddldamageType11"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno11"]?.ValueOrDefault<int>(),
                data["txtDamageDescription11"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge12"]?.ValueOrDefault<string>(),
                data["ddldamageType12"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno12"]?.ValueOrDefault<int>(),
                data["txtDamageDescription12"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge13"]?.ValueOrDefault<string>(),
                data["ddldamageType13"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno13"]?.ValueOrDefault<int>(),
                data["txtDamageDescription13"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge14"]?.ValueOrDefault<string>(),
                data["ddldamageType14"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno14"]?.ValueOrDefault<int>(),
                data["txtDamageDescription14"]?.ValueOrDefault<string>());

            yield return new Damage(
                data["ddlbladeEdge15"]?.ValueOrDefault<string>(),
                data["ddldamageType15"]?.ValueOrDefault<string>(),
                data["txtDamagePictureno15"]?.ValueOrDefault<int>(),
                data["txtDamageDescription15"]?.ValueOrDefault<string>());
        }



        private class Damage
        {
            public Damage(string edgeEnum, string typeEnum, int? imageNumber, string description)
            {
                ImageNumber = imageNumber;
                Description = description;

                if ((edgeEnum != null) &&
                    (BladeEdgeMap.TryGetValue(edgeEnum, out var edge)))
                {
                    Side = edge;
                }

                if ((typeEnum != null) &&
                    (DamageTypeMap.TryGetValue(typeEnum, out var type)))
                {
                    Type = type;
                }
            }
            public int? ImageNumber { get; set; }
            public string Type { get; set; }
            public string Side { get; set; }
            public string Description { get; set; }

            private Dictionary<string, string> BladeEdgeMap = new Dictionary<string, string>
            {
                { "1", "Leading Edge" },
                { "2", "Trailing Edge" },
                { "3", "N/A" },
                { "4", "Tip" },
                { "5", "Leeward Side (low pressure side)" },
                { "6", "Windward Side (pressure side)"}
            };
            private Dictionary<string, string> DamageTypeMap = new Dictionary<string, string>
            {
                { "1", "Bad bonding - knocking test"},
                { "2", "Bubbles" },
                { "3", "Cast" },
                { "4", "Chipped coat" },
                { "5", "Coat fault" },
                { "6", "Cracks" },
                { "7", "Damaged laminate" },
                { "8", "Erosion" },
                { "9", "LE tape damaged" },
                { "10", "LE tape sealer damaged" },
                { "11", "Lightning damage- comment" },
                { "12", "Lightning hit – receptor - comment"},
                { "13", "Noise" },
                { "14", "Oil in blade" },
                { "15", "Rub Mark" },
                { "16", "Scratch" },
                { "17", "Water in blade tip"},
                { "18", "N/A" },
                { "19", "Tip break damage" },
                { "20", "Tip wire" }
            };
        }
    }



}
