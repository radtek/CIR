using Cir.Data.Access.Models;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cir.Azure.MobileApp.Service.CirSyncService;
using System.Reflection;

namespace CirCosmosDataSync
{
    public class Mapper
    {
        public enum BladeInspection
        {
            badbondingknockingtest = 1,
            bubbles = 2,
            cast = 3,
            chippedcoat = 4,
            coatfault = 5,
            cracks = 6,
            damagedlaminate = 7,
            erosion = 8,
            letapedamaged = 9,
            letapesealerdamaged = 10,
            lightningdamagecomment = 11,
            lightninghitreceptorcomment = 12,
            noise = 13,
            oilinblade = 14,
            rubmark = 15,
            scratch = 16,
            waterinbladetip = 17,
            na = 18,
            tipbreakdamage = 19,
            tipwire = 20
        }

        public enum BladeEdge
        {
            leadingedge = 1,
            trailingedge = 2,
            na = 3,
            tip = 4,
            leewardside = 5,
            windwardside = 6
        }

        public static ExpandoObject Expando(IDictionary<string, object> jsonDictionary, IDictionary<string, object> cosmosDictionary)
        {
            ExpandoObject expandoObject = new ExpandoObject();
            IDictionary<string, object> objects = expandoObject;
            foreach (var item in jsonDictionary)
            {
                bool processed = false;

                if (item.Value.GetType().Name.Equals("String"))
                {
                    if (String.IsNullOrEmpty(item.Value.ToString()))
                    {
                        objects.Add(item.Key, null);
                        processed = true;
                    }
                    else
                    {
                        var dictValue = (from x in cosmosDictionary
                                         where x.Key.ToLower().Equals(item.Value.ToString().ToLower())
                                         select x).ToList();

                        if (dictValue.Count.Equals(0))
                        {
                            var dictval = (from x in cosmosDictionary
                                           where x.Key.ToLower().Contains(item.Value.ToString().ToLower())
                                           select x).ToList();

                            if (dictval.Count.Equals(0))
                            {
                                objects.Add(item.Key, null);
                                processed = true;
                            }
                            else
                            {
                                objects.Add(item.Key, dictval[0].Value);
                                processed = true;
                            }
                        }
                        else
                        {
                            objects.Add(item.Key, dictValue[0].Value);
                            processed = true;
                        }
                    }
                }
                else if (item.Value is ICollection)
                {
                    Dictionary<string, object> itemList = new Dictionary<string, object>();
                    Dictionary<string, object> dictObj = new Dictionary<string, object>();
                    foreach (var item2 in (ICollection)item.Value)
                    {
                        if (item2 is JObject)
                        {
                            IDictionary<string, object> dictJObj = JsonConvert.DeserializeObject<IDictionary<string, object>>(item2.ToString());
                            itemList.Add(((JProperty)item2).Name, Expando(dictJObj, cosmosDictionary));
                        }
                        else if (item2 is JProperty)
                        {
                            if (((JProperty)item2).Value is ICollection)
                            {

                                IDictionary<string, object> dictJObj = JsonConvert.DeserializeObject<IDictionary<string, object>>(((JProperty)item2).Value.ToString());
                                itemList.Add(((JProperty)item2).Name, Expando(dictJObj, cosmosDictionary));
                            }

                            else if (String.IsNullOrEmpty(((JProperty)item2).Value.ToString()))
                            {
                                dictObj.Add(((JProperty)item2).Name, null);
                                processed = true;
                            }
                            else
                            {
                                var dictValue = (from x in cosmosDictionary
                                                 where x.Key.ToLower().Equals(((JProperty)item2).Value.ToString().ToLower())
                                                 select x).ToList();
                                if (dictValue.Count.Equals(0))
                                {
                                    var dictval = (from x in cosmosDictionary
                                                   where x.Key.ToLower().Contains(((JProperty)item2).Value.ToString().ToLower())
                                                   select x).ToList();

                                    if (dictval.Count.Equals(0))
                                    {
                                        dictObj.Add(((JProperty)item2).Name, string.Empty);
                                        processed = true;
                                    }
                                    else
                                    {
                                        dictObj.Add(((JProperty)item2).Name, dictval[0].Value);
                                        processed = true;
                                    }
                                }
                                else
                                {
                                    dictObj.Add(((JProperty)item2).Name, dictValue[0].Value);
                                    processed = true;
                                }
                            }
                        }
                    }

                    if (itemList.Count > 0)
                    {
                        if (dictObj.Count > 0)
                        {
                            foreach (var items in itemList)
                            {
                                dictObj.Add(items.Key, items.Value);
                            }
                            objects.Add(item.Key, dictObj);
                            processed = true;
                        }
                        else
                        {
                            objects.Add(item.Key, itemList);
                            processed = true;
                        }
                    }
                    else if (dictObj.Count > 0)
                    {
                        objects.Add(item.Key, dictObj);
                        processed = true;
                    }
                }

                if (!processed)
                    objects.Add(item);
            }

            return expandoObject;
        }

        public static void PopuateOfflineData(ComponentInspectionReport objComp, CirSubmissionData objSubmissionData, Dictionary<string, object> cosmosDict, string cirType, string cirBrandName)
        {
            switch (cirType.ToLower())
            {
                case "gearbox":
                    objComp.ComponentInspectionReportTypeId = 2;
                    objComp.MountedOnMainComponentBooleanAnswerId = objComp.Gearbox.GearboxAuxEquipmentId;
                    PopulateGearboxData(objComp, cosmosDict);
                    break;
                case "bladeinspection":
                    objComp.ComponentInspectionReportTypeId = 1;
                    PopulateBladeInspectionData(objComp, cosmosDict, 1);
                    break;
                case "bladerepair":
                    objComp.ComponentInspectionReportTypeId = 1;
                    objComp.ReportTypeId = 3;
                    PopulateBladeInspectionData(objComp, cosmosDict, 1);
                    break;
                case "transformer":
                    objComp.ComponentInspectionReportTypeId = 5;
                    objComp.MountedOnMainComponentBooleanAnswerId = objComp.Transformer.TransformerClaimRelevantBooleanAnswerId;
                    break;
                case "generator":
                    objComp.ComponentInspectionReportTypeId = 4;
                    objComp.MountedOnMainComponentBooleanAnswerId = objComp.Generator.GeneratorClaimRelevantBooleanAnswerId;
                    break;
                case "mainbearing":
                    objComp.ComponentInspectionReportTypeId = 6;
                    objComp.MountedOnMainComponentBooleanAnswerId = 1;
                    objComp.MainBearing.MainBearingClaimRelevantBooleanAnswerId = 1;
                    break;
                case "general":
                    objComp.ComponentInspectionReportTypeId = 3;
                    objComp.General.GeneralClaimRelevantBooleanAnswerId = 2;
                    if (objComp.General.GeneralPicturesIncludedBooleanAnswerId == 1)
                    {
                        objComp.General.GeneralPicturesIncludedBooleanAnswerId = 2;
                    }
                    else
                    {
                        objComp.General.GeneralPicturesIncludedBooleanAnswerId = 1;
                    }
                    break;
                case "simplifiedcir":
                    objComp.ComponentInspectionReportTypeId = 8;
                    PopulateSimplifiedCirData(objComp, cosmosDict);
                    if (string.IsNullOrEmpty(objComp.DynamicTableInputs.Row1Col1))
                    {
                        objComp.DynamicTableInputs.Row1Col1 = "-1";
                    }
                    objComp.DynamicTableInputs.Row8Col1 = objComp.DynamicTableInputs.Row8Col1 == "Yes" ? "2" : (objComp.DynamicTableInputs.Row8Col1 == "No" ? "1" : "-1");
                    objComp.DynamicTableInputs.Row8Col2 = objComp.DynamicTableInputs.Row8Col2 == "Yes" ? "2" : (objComp.DynamicTableInputs.Row8Col2 == "No" ? "1" : "-1");
                    objComp.DynamicTableInputs.Row8Col3 = objComp.DynamicTableInputs.Row8Col3 == "Yes" ? "2" : (objComp.DynamicTableInputs.Row8Col3 == "No" ? "1" : "-1");
                    objComp.DynamicTableInputs.Row8Col4 = objComp.DynamicTableInputs.Row8Col4 == "Yes" ? "2" : (objComp.DynamicTableInputs.Row8Col4 == "No" ? "1" : "-1");
                    objComp.DynamicTableInputs.Row8Col5 = objComp.DynamicTableInputs.Row8Col5 == "Yes" ? "2" : (objComp.DynamicTableInputs.Row8Col5 == "No" ? "1" : "-1");
                    objComp.DynamicTableInputs.Row8Col6 = objComp.DynamicTableInputs.Row8Col6 == "Yes" ? "2" : (objComp.DynamicTableInputs.Row8Col6 == "No" ? "1" : "-1");
                    break;
                case "skiipack":
                    objComp.ComponentInspectionReportTypeId = 7;
                    objComp.Skiip.SkiiPClaimRelevantBooleanAnswerId = 1;
                    PopulateSkiiPackData(objComp, cosmosDict);
                    break;
                default:
                    objComp.ComponentInspectionReportTypeId = 2;
                    break;
            }
            PopuateDynamicFieldsData(objComp, cosmosDict, objSubmissionData);
            objComp.ReconstructionBooleanAnswerId = 1;
            objComp.LocationTypeId = 6;
            objComp.SBUId = 1;
            objComp.ComponentInspectionReportStateId = (int)objSubmissionData.State;
            objComp.ConductedBy = "1";
            objComp.CurrentUser = objSubmissionData.ModifiedBy;
            if (objSubmissionData.templateVersion < 1 && objSubmissionData.templateVersion.ToString(System.Globalization.CultureInfo.InvariantCulture).Contains('.'))
                objComp.TemplateVersion = objSubmissionData.templateVersion.ToString(System.Globalization.CultureInfo.InvariantCulture).Split('.')[1];
            else
                objComp.TemplateVersion = Convert.ToString(objSubmissionData.templateVersion + 8);

            objComp.CIRID = objSubmissionData.CirId;
            objComp.ComponentInspectionReportId = objSubmissionData.CirId;
            objComp.FormIOGUID = objSubmissionData.Id;
            objComp.Brand = cirBrandName;
        }

        public static void PopulateGearboxData(ComponentInspectionReport objComp, Dictionary<string, object> cosmosDict)
        {
            string defectCatScore = null;
            if (cosmosDict.ContainsKey("page2TextField"))
            {
                defectCatScore = Convert.ToString(cosmosDict["page2TextField"]);
                if (defectCatScore.Contains("Defect Categorization Score "))
                {
                    defectCatScore = defectCatScore.Split(new char[] { '\t' })[1].ToString();
                }
                else
                {
                    defectCatScore = null;
                }
            }
            objComp.Gearbox.GearboxDefectCategorizationScore = defectCatScore;
        }

        public static void PopulateBladeInspectionData(ComponentInspectionReport objComp, Dictionary<string, object> cosmosDict, Int32 componentInspectionReportTypeId)
        {


            objComp.ComponentInspectionReportTypeId = componentInspectionReportTypeId;
            //objComp.InstallationDate = objComp.FailureDate;  //Will introduce in next sprint
            //objComp.strInstallationDate = objComp.strFailureDate; //Will introduce in next sprint
            //objComp.CommisioningDate = objComp.FailureDate; //Will introduce in next sprint
            //objComp.strCommisioningDate = objComp.strFailureDate; //Will introduce in next sprint
            objComp.ServiceEngineer = "vestas";
            objComp.MountedOnMainComponentBooleanAnswerId = cosmosDict.ContainsKey("ctbAuxEquipment") ? Convert.ToInt32(cosmosDict["ctbAuxEquipment"]) + 1 : 1;
            objComp.BladeData.BladePicturesIncludedBooleanAnswerId = 2;
            //objComp.BladeData.BladeFaultCodeAreaId = 5; //Will introduce in next sprint
            //objComp.BladeData.BladeFaultCodeCauseId = 1; //Will introduce in next sprint
            //objComp.BladeData.BladeFaultCodeTypeId = 18; //Will introduce in next sprint
            //objComp.BladeData.RepairRecordData.BladeSurfaceMaxTemperature = 14; //Introduced in the template
            //objComp.BladeData.RepairRecordData.BladeSurfaceMinTemperature = 10;  //Introduced in the template
            //objComp.BladeData.RepairRecordData.BladeResinUsed = 1;  //Introduced in the template
            //objComp.BladeData.RepairRecordData.BladePostCureMaxTemperature = 50;  //Introduced in the template
            //objComp.BladeData.RepairRecordData.BladePostCureMinTemperature = 20;  //Introduced in the template

            if (cosmosDict.ContainsKey("ctbUpTowerSolutionAvailable"))
            {
                objComp.ComponentUpTowerSolutionID = Convert.ToInt32(cosmosDict["ctbUpTowerSolutionAvailable"]) + 1;
            }

            if (objComp.BladeData.BladeFaultCodeClassificationId == 0)
            {
                objComp.BladeData.BladeFaultCodeClassificationId = null;
            }
            var dictval = (from x in cosmosDict
                           where x.Key.ToLower() == "imagecomponentkey"
                           select x).ToList();
            if (dictval.Count > 0)
            {
                ImagecomponentKey lstImageInfo = JsonConvert.DeserializeObject<ImagecomponentKey>(cosmosDict["imagecomponentKey"].ToString());
                int count = 0;
                if ((!Object.ReferenceEquals(lstImageInfo.plate, null)) || (!Object.ReferenceEquals(lstImageInfo.sections, null)))
                {
                    if (objComp.ImageData != null)
                    {
                        if (Object.ReferenceEquals(lstImageInfo.plate, null) || Object.ReferenceEquals(lstImageInfo.plate.imageId, null))
                        {
                            count = objComp.ImageData.Count();
                        }
                        else
                        {
                            count = objComp.ImageData.Count() - 1;
                        }
                    }
                    ComponentInspectionReportBladeDamage[] lstBladeDamage = new ComponentInspectionReportBladeDamage[count];
                   // List<string> damages = new List<string>();
                    int i = 0;
                    if (lstImageInfo.sections != null)
                    {

                        PropertyInfo[] properties = lstImageInfo.sections.GetType().GetProperties();
                        foreach (PropertyInfo property in properties)
                        {

                            dynamic section = null;
                            switch (property.Name)
                            {
                                case "section1": { section = (Section1)property.GetValue(lstImageInfo.sections, null); break; }
                                case "section2": { section = (Section2)property.GetValue(lstImageInfo.sections, null); break; }
                                case "section3": { section = (Section3)property.GetValue(lstImageInfo.sections, null); break; }
                                case "section4": { section = (Section4)property.GetValue(lstImageInfo.sections, null); break; }
                                case "section5": { section = (Section5)property.GetValue(lstImageInfo.sections, null); break; }
                                case "section6": { section = (Section6)property.GetValue(lstImageInfo.sections, null); break; }
                                case "section7": { section = (Section7)property.GetValue(lstImageInfo.sections, null); break; }
                                case "section8": { section = (Section8)property.GetValue(lstImageInfo.sections, null); break; }
                                case "section9": { section = (Section9)property.GetValue(lstImageInfo.sections, null); break; }
                                case "section10": { section = (Section10)property.GetValue(lstImageInfo.sections, null); break; }
                                case "section11": { section = (Section11)property.GetValue(lstImageInfo.sections, null); break; }
                                case "section12": { section = (Section12)property.GetValue(lstImageInfo.sections, null); break; }
                            }
                            if (section != null)
                            {
                                var images = ((List<Images>)section.images).OrderBy(a => a.number);
                                foreach (var img in images)
                                {
                                    //Assuming that img.imageId would always be a Guid passed from Formio

                                    if (!string.IsNullOrEmpty(img.imageId))
                                        img.FormIOImageGUID = new Guid(img.imageId);
                                    if (img.damageIdentified == true)
                                    {
                                       ///if (damages.IndexOf(img.damageDetails[0].damageId) == -1)
                                       // //{
                                            ComponentInspectionReportBladeDamage objCIRBladeDamage = new ComponentInspectionReportBladeDamage();
                                            objCIRBladeDamage.BladeDamagePlacementId = img.damagePlacement.ToLower() == "internal" ? 1 : 2;
                                            string BladeInspectionValue = string.Empty;
                                            if (img.observations[0].findingType == string.Empty)
                                            {
                                                BladeInspectionValue = Regex.Replace(lstImageInfo.uploadedImagesCache.First(item => item.imageId == img.imageId).damageType, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                                            }
                                            else
                                            {
                                                BladeInspectionValue = Regex.Replace(img.observations[0].findingType, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                                            }
                                            BladeInspection BladeInspectionId = (BladeInspection)Enum.Parse(typeof(BladeInspection), BladeInspectionValue.ToLower());
                                            objCIRBladeDamage.BladeInspectionDataId = (int)BladeInspectionId;
                                            objCIRBladeDamage.BladeRadius = img.radius == null ? Convert.ToDouble(9999) : Convert.ToDouble(img.radius);
                                            string BladeEdgeValue = Regex.Replace(img.side, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
                                            BladeEdge BladeEdgeId = (BladeEdge)Enum.Parse(typeof(BladeEdge), BladeEdgeValue.ToLower());
                                            objCIRBladeDamage.BladeEdgeId = (int)BladeEdgeId;
                                            objCIRBladeDamage.BladeDescription = img.damageDescription == null ? "No Damage" : img.damageDescription;
                                            objCIRBladeDamage.BladePictureNumber = Convert.ToString(img.number);
                                            objCIRBladeDamage.PictureOrder = null;
                                            objCIRBladeDamage.DamageSeverity = Convert.ToInt32(img.damageSeverity);
                                            objCIRBladeDamage.FormIOImageGUID = img.FormIOImageGUID;
                                            //objCIRBladeDamage.damageId = img.damageDetails[0].damageId;
                                            lstBladeDamage[i] = objCIRBladeDamage;
                                            i++;
                                           // damages.Add(img.damageDetails[0].damageId);
                                        //}
                                        //else
                                        //{
                                        //    //ComponentInspectionReportBladeDamage item = Array.Find(lstBladeDamage, (x => x.damageId == img.damageDetails[0].damageId));
                                        //    //item.BladePictureNumber = item.BladePictureNumber + "," + Convert.ToString(img.number);
                                        //}
                                    }
                                }
                            }
                        }


                    }
                    lstBladeDamage = lstBladeDamage.Where(c => c != null).ToArray();
                    objComp.BladeData.DamageData = lstBladeDamage;
                }
            }

            else if (cosmosDict.ContainsKey("ddlBladeDamageCount") && Convert.ToInt32(cosmosDict["ddlBladeDamageCount"]) > 0)
            {
                int damageCount = Convert.ToInt32(cosmosDict["ddlBladeDamageCount"]);
                List<ComponentInspectionReportBladeDamage> lstBladeDamage = new List<ComponentInspectionReportBladeDamage>();
                for (int counter = 1; counter <= damageCount; counter++)
                {
                    if (cosmosDict.ContainsKey("ddldamagePlacement" + counter))
                    {
                        ComponentInspectionReportBladeDamage objCIRBladeDamage = new ComponentInspectionReportBladeDamage();
                        objCIRBladeDamage.ComponentInspectionReportBladeDamageId = Convert.ToInt64(cosmosDict["ddlblagedamageInspectionId" + counter]);
                        objCIRBladeDamage.BladeInspectionDataId = Convert.ToInt64(cosmosDict["ddldamageType" + counter]);
                        objCIRBladeDamage.BladeDamagePlacementId = Convert.ToInt64(cosmosDict["ddldamagePlacement" + counter]);
                        objCIRBladeDamage.BladeRadius = Convert.ToInt64(cosmosDict["txtBladeRadius" + counter]);
                        objCIRBladeDamage.BladeEdgeId = Convert.ToInt64(cosmosDict["ddlbladeEdge" + counter]);
                        objCIRBladeDamage.BladeDescription = cosmosDict["txtDamageDescription" + counter].ToString();
                        objCIRBladeDamage.BladePictureNumber = cosmosDict["txtDamagePictureno" + counter].ToString();
                        objCIRBladeDamage.PictureOrder = null;

                        lstBladeDamage.Add(objCIRBladeDamage);

                    }

                }
                //lstBladeDamage = lstBladeDamage.Where(c => c != null).ToList();
                objComp.BladeData.DamageData = lstBladeDamage.ToArray();
            }
        }

        public static void PopulateSimplifiedCirData(ComponentInspectionReport objComp, Dictionary<string, object> cosmosDict)
        {
            objComp.ReportTypeId = 1;
            objComp.BeforeInspectionTurbineRunStatusId = 7;
            objComp.MountedOnMainComponentBooleanAnswerId = 1;
            objComp.OutSideSign = cosmosDict.ContainsKey("ddlOutSideSign") ? Convert.ToBoolean(Convert.ToInt32(cosmosDict["ddlOutSideSign"])) : false;
            DyanamicDecision objDynamic = new DyanamicDecision();
            DyanamicDecision[] lstDynamic = new DyanamicDecision[6];
            int k = 0;
            objDynamic = new DyanamicDecision();
            objDynamic.FlangeDamageIdentified = cosmosDict.ContainsKey("chkDamageIdentifiedSimplifiedFlange1") ? Convert.ToBoolean(cosmosDict["chkDamageIdentifiedSimplifiedFlange1"]) : false;
            objDynamic.Decision = cosmosDict.ContainsKey("ddlDecision-Flange1") ? FetchDecisionValues(Convert.ToString(cosmosDict["ddlDecision-Flange1"])) : -1;
            objDynamic.RepeatedInspections = cosmosDict.ContainsKey("ddlRepeatedinspection-Flange1") ? FetchInspectionValues(Convert.ToString(cosmosDict["ddlRepeatedinspection-Flange1"])) : -1;
            objDynamic.AffectedBolts = cosmosDict.ContainsKey("chkReplaceaffectedBolts-Flange1") ? Convert.ToInt32(cosmosDict["chkReplaceaffectedBolts-Flange1"]) : 0;
            objDynamic.FlangNo = 1;
            objDynamic.InspectionDesc = cosmosDict.ContainsKey("txtInspectionDescription-Flange1") ? Convert.ToString(cosmosDict["txtInspectionDescription-Flange1"]) : string.Empty;
            lstDynamic[k] = objDynamic;
            k++;
            objDynamic = new DyanamicDecision();
            objDynamic.FlangeDamageIdentified = cosmosDict.ContainsKey("chkDamageIdentifiedSimplifiedFlange2") ? Convert.ToBoolean(cosmosDict["chkDamageIdentifiedSimplifiedFlange2"]) : false;
            objDynamic.Decision = cosmosDict.ContainsKey("ddlDecision-Flange2") ? FetchDecisionValues(Convert.ToString(cosmosDict["ddlDecision-Flange2"])) : -1;
            objDynamic.RepeatedInspections = cosmosDict.ContainsKey("ddlRepeatedinspection-Flange2") ? FetchInspectionValues(Convert.ToString(cosmosDict["ddlRepeatedinspection-Flange2"])) : -1;
            objDynamic.AffectedBolts = cosmosDict.ContainsKey("chkReplaceaffectedBolts-Flange2") ? Convert.ToInt32(cosmosDict["chkReplaceaffectedBolts-Flange2"]) : 0;
            objDynamic.FlangNo = 2;
            objDynamic.InspectionDesc = cosmosDict.ContainsKey("txtInspectionDescription-Flange2") ? Convert.ToString(cosmosDict["txtInspectionDescription-Flange2"]) : string.Empty;
            lstDynamic[k] = objDynamic;
            k++;
            objDynamic = new DyanamicDecision();
            objDynamic.FlangeDamageIdentified = cosmosDict.ContainsKey("chkDamageIdentifiedSimplifiedFlange3") ? Convert.ToBoolean(cosmosDict["chkDamageIdentifiedSimplifiedFlange3"]) : false;
            objDynamic.Decision = cosmosDict.ContainsKey("ddlDecision-Flange3") ? FetchDecisionValues(Convert.ToString(cosmosDict["ddlDecision-Flange3"])) : -1;
            objDynamic.RepeatedInspections = cosmosDict.ContainsKey("ddlRepeatedinspection-Flange3") ? FetchInspectionValues(Convert.ToString(cosmosDict["ddlRepeatedinspection-Flange3"])) : -1;
            objDynamic.AffectedBolts = cosmosDict.ContainsKey("chkReplaceaffectedBolts-Flange3") ? Convert.ToInt32(cosmosDict["chkReplaceaffectedBolts-Flange3"]) : 0;
            objDynamic.FlangNo = 3;
            objDynamic.InspectionDesc = cosmosDict.ContainsKey("txtInspectionDescription-Flange3") ? Convert.ToString(cosmosDict["txtInspectionDescription-Flange3"]) : string.Empty;
            lstDynamic[k] = objDynamic;
            k++;
            objDynamic = new DyanamicDecision();
            objDynamic.FlangeDamageIdentified = cosmosDict.ContainsKey("chkDamageIdentifiedSimplifiedFlange4") ? Convert.ToBoolean(cosmosDict["chkDamageIdentifiedSimplifiedFlange4"]) : false;
            objDynamic.Decision = cosmosDict.ContainsKey("ddlDecision-Flange4") ? FetchDecisionValues(Convert.ToString(cosmosDict["ddlDecision-Flange4"])) : -1;
            objDynamic.RepeatedInspections = cosmosDict.ContainsKey("ddlRepeatedinspection-Flange4") ? FetchInspectionValues(Convert.ToString(cosmosDict["ddlRepeatedinspection-Flange4"])) : -1;
            objDynamic.AffectedBolts = cosmosDict.ContainsKey("chkReplaceaffectedBolts-Flange4") ? Convert.ToInt32(cosmosDict["chkReplaceaffectedBolts-Flange4"]) : 0;
            objDynamic.FlangNo = 4;
            objDynamic.InspectionDesc = cosmosDict.ContainsKey("txtInspectionDescription-Flange4") ? Convert.ToString(cosmosDict["txtInspectionDescription-Flange4"]) : string.Empty;
            lstDynamic[k] = objDynamic;
            k++;
            objDynamic = new DyanamicDecision();
            objDynamic.FlangeDamageIdentified = cosmosDict.ContainsKey("chkDamageIdentifiedSimplifiedFlange5") ? Convert.ToBoolean(cosmosDict["chkDamageIdentifiedSimplifiedFlange5"]) : false;
            objDynamic.Decision = cosmosDict.ContainsKey("ddlDecision-Flange5") ? FetchDecisionValues(Convert.ToString(cosmosDict["ddlDecision-Flange5"])) : -1;
            objDynamic.RepeatedInspections = cosmosDict.ContainsKey("ddlRepeatedinspection-Flange5") ? FetchInspectionValues(Convert.ToString(cosmosDict["ddlRepeatedinspection-Flange5"])) : -1;
            objDynamic.AffectedBolts = cosmosDict.ContainsKey("chkReplaceaffectedBolts-Flange5") ? Convert.ToInt32(cosmosDict["chkReplaceaffectedBolts-Flange5"]) : 0;
            objDynamic.FlangNo = 5;
            objDynamic.InspectionDesc = cosmosDict.ContainsKey("txtInspectionDescription-Flange5") ? Convert.ToString(cosmosDict["txtInspectionDescription-Flange5"]) : string.Empty;
            lstDynamic[k] = objDynamic;
            k++;
            objDynamic = new DyanamicDecision();
            objDynamic.FlangeDamageIdentified = cosmosDict.ContainsKey("chkDamageIdentifiedSimplifiedFlange6") ? Convert.ToBoolean(cosmosDict["chkDamageIdentifiedSimplifiedFlange6"]) : false;
            objDynamic.Decision = cosmosDict.ContainsKey("ddlDecision-Flange6") ? FetchDecisionValues(Convert.ToString(cosmosDict["ddlDecision-Flange6"])) : -1;
            objDynamic.RepeatedInspections = cosmosDict.ContainsKey("ddlRepeatedinspection-Flange6") ? FetchInspectionValues(Convert.ToString(cosmosDict["ddlRepeatedinspection-Flange6"])) : -1;
            objDynamic.AffectedBolts = cosmosDict.ContainsKey("chkReplaceaffectedBolts-Flange6") ? Convert.ToInt32(cosmosDict["chkReplaceaffectedBolts-Flange6"]) : 0;
            objDynamic.FlangNo = 6;
            objDynamic.InspectionDesc = cosmosDict.ContainsKey("txtInspectionDescription-Flange6") ? Convert.ToString(cosmosDict["txtInspectionDescription-Flange6"]) : string.Empty;
            lstDynamic[k] = objDynamic;
            k++;

            objComp.DyanamicDecisionData = lstDynamic;
        }

        public static void PopulateSkiiPackData(ComponentInspectionReport objComp, Dictionary<string, object> cosmosDict)
        {
            ComponentInspectionReportSkiiPFailedComponent objSkiiPFailedComponent = null;
            ComponentInspectionReportSkiiPNewComponent objSkiipNewComponent = null;
            int modulesCount = 0;
            if (cosmosDict.ContainsKey("ddlNumberOfComponents"))
            {
                modulesCount = Convert.ToInt32(cosmosDict["ddlNumberOfComponents"]);
            }
            ComponentInspectionReportSkiiPFailedComponent[] lstSkiiPFailedComponent = new ComponentInspectionReportSkiiPFailedComponent[modulesCount];
            ComponentInspectionReportSkiiPNewComponent[] lstSkiiPNewComponent = new ComponentInspectionReportSkiiPNewComponent[modulesCount];
            int k = 0;
            if (modulesCount >= 1)
            {
                objSkiiPFailedComponent = new ComponentInspectionReportSkiiPFailedComponent();
                objSkiipNewComponent = new ComponentInspectionReportSkiiPNewComponent();
                objSkiiPFailedComponent.SkiiPFailedComponentSerialNumber = Convert.ToString(cosmosDict["ComponentId1SerialNumber"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasItemNumber = Convert.ToString(cosmosDict["ComponentId1ItemNo"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["ComponentId1VestasUniqueIdentifier"]);
                lstSkiiPFailedComponent[k] = objSkiiPFailedComponent;
                objSkiipNewComponent.SkiiPNewComponentSerialNumber = Convert.ToString(cosmosDict["NewModule1SerialNumber"]);
                objSkiipNewComponent.SkiiPNewComponentVestasItemNumber = Convert.ToString(cosmosDict["NewModule1ItemNo"]);
                objSkiipNewComponent.SkiiPNewComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["NewModule1VestasUniqueIdentifier"]);
                lstSkiiPNewComponent[k] = objSkiipNewComponent;
                k++;
            }

            if (modulesCount >= 2)
            {
                objSkiiPFailedComponent = new ComponentInspectionReportSkiiPFailedComponent();
                objSkiipNewComponent = new ComponentInspectionReportSkiiPNewComponent();
                objSkiiPFailedComponent.SkiiPFailedComponentSerialNumber = Convert.ToString(cosmosDict["ComponentId2SerialNumber"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasItemNumber = Convert.ToString(cosmosDict["ComponentId2ItemNo"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["ComponentId2VestasUniqueIdentifier"]);
                lstSkiiPFailedComponent[k] = objSkiiPFailedComponent;
                objSkiipNewComponent.SkiiPNewComponentSerialNumber = Convert.ToString(cosmosDict["NewModule2SerialNumber"]);
                objSkiipNewComponent.SkiiPNewComponentVestasItemNumber = Convert.ToString(cosmosDict["NewModule2ItemNo"]);
                objSkiipNewComponent.SkiiPNewComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["NewModule2VestasUniqueIdentifier"]);
                lstSkiiPNewComponent[k] = objSkiipNewComponent;
                k++;
            }
            if (modulesCount >= 3)
            {
                objSkiiPFailedComponent = new ComponentInspectionReportSkiiPFailedComponent();
                objSkiipNewComponent = new ComponentInspectionReportSkiiPNewComponent();
                objSkiiPFailedComponent.SkiiPFailedComponentSerialNumber = Convert.ToString(cosmosDict["ComponentId3SerialNumber"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasItemNumber = Convert.ToString(cosmosDict["ComponentId3ItemNo"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["ComponentId3VestasUniqueIdentifier"]);
                lstSkiiPFailedComponent[k] = objSkiiPFailedComponent;
                objSkiipNewComponent.SkiiPNewComponentSerialNumber = Convert.ToString(cosmosDict["NewModule3SerialNumber"]);
                objSkiipNewComponent.SkiiPNewComponentVestasItemNumber = Convert.ToString(cosmosDict["NewModule3ItemNo"]);
                objSkiipNewComponent.SkiiPNewComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["NewModule3VestasUniqueIdentifier"]);
                lstSkiiPNewComponent[k] = objSkiipNewComponent;
                k++;
            }
            if (modulesCount >= 4)
            {
                objSkiiPFailedComponent = new ComponentInspectionReportSkiiPFailedComponent();
                objSkiipNewComponent = new ComponentInspectionReportSkiiPNewComponent();
                objSkiiPFailedComponent.SkiiPFailedComponentSerialNumber = Convert.ToString(cosmosDict["ComponentId4SerialNumber"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasItemNumber = Convert.ToString(cosmosDict["ComponentId4ItemNo"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["ComponentId4VestasUniqueIdentifier"]);
                lstSkiiPFailedComponent[k] = objSkiiPFailedComponent;
                objSkiipNewComponent.SkiiPNewComponentSerialNumber = Convert.ToString(cosmosDict["NewModule4SerialNumber"]);
                objSkiipNewComponent.SkiiPNewComponentVestasItemNumber = Convert.ToString(cosmosDict["NewModule4ItemNo"]);
                objSkiipNewComponent.SkiiPNewComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["NewModule4VestasUniqueIdentifier"]);
                lstSkiiPNewComponent[k] = objSkiipNewComponent;
                k++;
            }
            if (modulesCount >= 5)
            {
                objSkiiPFailedComponent = new ComponentInspectionReportSkiiPFailedComponent();
                objSkiipNewComponent = new ComponentInspectionReportSkiiPNewComponent();
                objSkiiPFailedComponent.SkiiPFailedComponentSerialNumber = Convert.ToString(cosmosDict["ComponentId5SerialNumber"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasItemNumber = Convert.ToString(cosmosDict["ComponentId5ItemNo"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["ComponentId5VestasUniqueIdentifier"]);
                lstSkiiPFailedComponent[k] = objSkiiPFailedComponent;
                objSkiipNewComponent.SkiiPNewComponentSerialNumber = Convert.ToString(cosmosDict["NewModule5SerialNumber"]);
                objSkiipNewComponent.SkiiPNewComponentVestasItemNumber = Convert.ToString(cosmosDict["NewModule5ItemNo"]);
                objSkiipNewComponent.SkiiPNewComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["NewModule5VestasUniqueIdentifier"]);
                lstSkiiPNewComponent[k] = objSkiipNewComponent;
                k++;
            }
            if (modulesCount >= 6)
            {
                objSkiiPFailedComponent = new ComponentInspectionReportSkiiPFailedComponent();
                objSkiipNewComponent = new ComponentInspectionReportSkiiPNewComponent();
                objSkiiPFailedComponent.SkiiPFailedComponentSerialNumber = Convert.ToString(cosmosDict["ComponentId6SerialNumber"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasItemNumber = Convert.ToString(cosmosDict["ComponentId6ItemNo"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["ComponentId6VestasUniqueIdentifier"]);
                lstSkiiPFailedComponent[k] = objSkiiPFailedComponent;
                objSkiipNewComponent.SkiiPNewComponentSerialNumber = Convert.ToString(cosmosDict["NewModule6SerialNumber"]);
                objSkiipNewComponent.SkiiPNewComponentVestasItemNumber = Convert.ToString(cosmosDict["NewModule6ItemNo"]);
                objSkiipNewComponent.SkiiPNewComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["NewModule6VestasUniqueIdentifier"]);
                lstSkiiPNewComponent[k] = objSkiipNewComponent;
                k++;
            }
            if (modulesCount >= 7)
            {
                objSkiiPFailedComponent = new ComponentInspectionReportSkiiPFailedComponent();
                objSkiipNewComponent = new ComponentInspectionReportSkiiPNewComponent();
                objSkiiPFailedComponent.SkiiPFailedComponentSerialNumber = Convert.ToString(cosmosDict["ComponentId7SerialNumber"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasItemNumber = Convert.ToString(cosmosDict["ComponentId7ItemNo"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["ComponentId7VestasUniqueIdentifier"]);
                lstSkiiPFailedComponent[k] = objSkiiPFailedComponent;
                objSkiipNewComponent.SkiiPNewComponentSerialNumber = Convert.ToString(cosmosDict["NewModule7SerialNumber"]);
                objSkiipNewComponent.SkiiPNewComponentVestasItemNumber = Convert.ToString(cosmosDict["NewModule7ItemNo"]);
                objSkiipNewComponent.SkiiPNewComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["NewModule7VestasUniqueIdentifier"]);
                lstSkiiPNewComponent[k] = objSkiipNewComponent;
                k++;
            }
            if (modulesCount >= 8)
            {
                objSkiiPFailedComponent = new ComponentInspectionReportSkiiPFailedComponent();
                objSkiipNewComponent = new ComponentInspectionReportSkiiPNewComponent();
                objSkiiPFailedComponent.SkiiPFailedComponentSerialNumber = Convert.ToString(cosmosDict["ComponentId8SerialNumber"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasItemNumber = Convert.ToString(cosmosDict["ComponentId8ItemNo"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["ComponentId8VestasUniqueIdentifier"]);
                lstSkiiPFailedComponent[k] = objSkiiPFailedComponent;
                objSkiipNewComponent.SkiiPNewComponentSerialNumber = Convert.ToString(cosmosDict["NewModule8SerialNumber"]);
                objSkiipNewComponent.SkiiPNewComponentVestasItemNumber = Convert.ToString(cosmosDict["NewModule8ItemNo"]);
                objSkiipNewComponent.SkiiPNewComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["NewModule8VestasUniqueIdentifier"]);
                lstSkiiPNewComponent[k] = objSkiipNewComponent;
                k++;
            }

            if (modulesCount >= 9)
            {
                objSkiiPFailedComponent = new ComponentInspectionReportSkiiPFailedComponent();
                objSkiipNewComponent = new ComponentInspectionReportSkiiPNewComponent();
                objSkiiPFailedComponent.SkiiPFailedComponentSerialNumber = Convert.ToString(cosmosDict["ComponentId9SerialNumber"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasItemNumber = Convert.ToString(cosmosDict["ComponentId9ItemNo"]);
                objSkiiPFailedComponent.SkiiPFailedComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["ComponentId9VestasUniqueIdentifier"]);
                lstSkiiPFailedComponent[k] = objSkiiPFailedComponent;
                objSkiipNewComponent.SkiiPNewComponentSerialNumber = Convert.ToString(cosmosDict["NewModule9SerialNumber"]);
                objSkiipNewComponent.SkiiPNewComponentVestasItemNumber = Convert.ToString(cosmosDict["NewModule9VestasItemNo"]);
                objSkiipNewComponent.SkiiPNewComponentVestasUniqueIdentifier = Convert.ToString(cosmosDict["NewModule9VestasUniqueIdentifier"]);
                lstSkiiPNewComponent[k] = objSkiipNewComponent;
                k++;
            }

            objComp.Skiip.SkiipFailedComp = lstSkiiPFailedComponent;
            objComp.Skiip.SkiipNewComp = lstSkiiPNewComponent;
        }

        public static int FetchDecisionValues(string DecisionValue)
        {
            int decisionKey = -1;
            if (DecisionValue.ToLower() == "full flange repair solution")
                decisionKey = 22;
            if (DecisionValue.ToLower() == "single bolt replacement")
                decisionKey = 23;
            if (DecisionValue.ToLower() == "cim implementation decision")
                decisionKey = 24;
            return decisionKey;
        }

        public static int FetchInspectionValues(string InspectionValue)
        {
            int inspectionKey = -1;
            if (InspectionValue.ToLower() == "no")
                inspectionKey = 26;
            if (InspectionValue.ToLower() == "weekly")
                inspectionKey = 27;
            if (InspectionValue.ToLower() == "bi-weekly")
                inspectionKey = 28;
            if (InspectionValue.ToLower() == "monthly")
                inspectionKey = 29;
            if (InspectionValue.ToLower() == "bi-monthly")
                inspectionKey = 30;
            if (InspectionValue.ToLower() == "half yearly")
                inspectionKey = 31;
            return inspectionKey;
        }

        /// <summary>
        /// Populate Dynamic Fields Data
        /// </summary>
        /// <param name="objComp"></param>
        /// <param name="cosmosDict"></param>
        /// <param name="objSubmissionData"></param>
        public static void PopuateDynamicFieldsData(ComponentInspectionReport objComp, Dictionary<string, object> cosmosDict, CirSubmissionData objSubmissionData)
        {
            var dictval = (from x in cosmosDict
                           where x.Key.ToLower() == "page5dynamicfields"
                           select x).ToList();
            if (dictval.Count > 0)
            {
                DynamicFields dynamicFieldsData = JsonConvert.DeserializeObject<DynamicFields>(cosmosDict["page5DynamicFields"].ToString());
                DynamicTable objDynamicField = new DynamicTable();
                objDynamicField.CirId = Convert.ToString(objSubmissionData.CirId);
                objDynamicField.Row1Col1 = dynamicFieldsData.A1;
                objDynamicField.Row1Col2 = dynamicFieldsData.B1;
                objDynamicField.Row1Col3 = dynamicFieldsData.C1;
                objDynamicField.Row1Col4 = dynamicFieldsData.D1;
                objDynamicField.Row1Col5 = dynamicFieldsData.E1;
                objDynamicField.Row1Col6 = dynamicFieldsData.F1;
                objDynamicField.Row2Col1 = dynamicFieldsData.A2;
                objDynamicField.Row2Col2 = dynamicFieldsData.B2;
                objDynamicField.Row2Col3 = dynamicFieldsData.C2;
                objDynamicField.Row2Col4 = dynamicFieldsData.D2;
                objDynamicField.Row2Col5 = dynamicFieldsData.E2;
                objDynamicField.Row2Col6 = dynamicFieldsData.F2;
                objDynamicField.Row3Col1 = dynamicFieldsData.A3;
                objDynamicField.Row3Col2 = dynamicFieldsData.B3;
                objDynamicField.Row3Col3 = dynamicFieldsData.C3;
                objDynamicField.Row3Col4 = dynamicFieldsData.D3;
                objDynamicField.Row3Col5 = dynamicFieldsData.E3;
                objDynamicField.Row3Col6 = dynamicFieldsData.F3;
                objDynamicField.Row4Col1 = dynamicFieldsData.A4;
                objDynamicField.Row4Col2 = dynamicFieldsData.B4;
                objDynamicField.Row4Col3 = dynamicFieldsData.C4;
                objDynamicField.Row4Col4 = dynamicFieldsData.D4;
                objDynamicField.Row4Col5 = dynamicFieldsData.E4;
                objDynamicField.Row4Col6 = dynamicFieldsData.F4;
                objDynamicField.Row5Col1 = dynamicFieldsData.A5;
                objDynamicField.Row5Col2 = dynamicFieldsData.B5;
                objDynamicField.Row5Col3 = dynamicFieldsData.C5;
                objDynamicField.Row5Col4 = dynamicFieldsData.D5;
                objDynamicField.Row5Col5 = dynamicFieldsData.E5;
                objDynamicField.Row5Col6 = dynamicFieldsData.F5;
                objDynamicField.Row6Col1 = dynamicFieldsData.A6;
                objDynamicField.Row6Col2 = dynamicFieldsData.B6;
                objDynamicField.Row6Col3 = dynamicFieldsData.C6;
                objDynamicField.Row6Col4 = dynamicFieldsData.D6;
                objDynamicField.Row6Col5 = dynamicFieldsData.E6;
                objDynamicField.Row6Col6 = dynamicFieldsData.F6;
                objDynamicField.Row7Col1 = dynamicFieldsData.A7;
                objDynamicField.Row7Col2 = dynamicFieldsData.B7;
                objDynamicField.Row7Col3 = dynamicFieldsData.C7;
                objDynamicField.Row7Col4 = dynamicFieldsData.D7;
                objDynamicField.Row7Col5 = dynamicFieldsData.E7;
                objDynamicField.Row7Col6 = dynamicFieldsData.F7;
                objDynamicField.Row8Col1 = dynamicFieldsData.A8;
                objDynamicField.Row8Col2 = dynamicFieldsData.B8;
                objDynamicField.Row8Col3 = dynamicFieldsData.C8;
                objDynamicField.Row8Col4 = dynamicFieldsData.D8;
                objDynamicField.Row8Col5 = dynamicFieldsData.E8;
                objDynamicField.Row8Col6 = dynamicFieldsData.F8;
                objDynamicField.Row9Col1 = dynamicFieldsData.A9;
                objDynamicField.Row9Col2 = dynamicFieldsData.B9;
                objDynamicField.Row9Col3 = dynamicFieldsData.C9;
                objDynamicField.Row9Col4 = dynamicFieldsData.D9;
                objDynamicField.Row9Col5 = dynamicFieldsData.E9;
                objDynamicField.Row9Col6 = dynamicFieldsData.F9;
                objDynamicField.Row10Col1 = dynamicFieldsData.A10;
                objDynamicField.Row10Col2 = dynamicFieldsData.B10;
                objDynamicField.Row10Col3 = dynamicFieldsData.C10;
                objDynamicField.Row10Col4 = dynamicFieldsData.D10;
                objDynamicField.Row10Col5 = dynamicFieldsData.E10;
                objDynamicField.Row10Col6 = dynamicFieldsData.F10;
                objDynamicField.Row11Col1 = dynamicFieldsData.A11;
                objDynamicField.Row11Col2 = dynamicFieldsData.B11;
                objDynamicField.Row11Col3 = dynamicFieldsData.C11;
                objDynamicField.Row11Col4 = dynamicFieldsData.D11;
                objDynamicField.Row11Col5 = dynamicFieldsData.E11;
                objDynamicField.Row11Col6 = dynamicFieldsData.F11;
                objDynamicField.Row12Col1 = dynamicFieldsData.A12;
                objDynamicField.Row12Col2 = dynamicFieldsData.B12;
                objDynamicField.Row12Col3 = dynamicFieldsData.C12;
                objDynamicField.Row12Col4 = dynamicFieldsData.D12;
                objDynamicField.Row12Col5 = dynamicFieldsData.E12;
                objDynamicField.Row12Col6 = dynamicFieldsData.F12;
                objDynamicField.Row13Col1 = dynamicFieldsData.A13;
                objDynamicField.Row13Col2 = dynamicFieldsData.B13;
                objDynamicField.Row13Col3 = dynamicFieldsData.C13;
                objDynamicField.Row13Col4 = dynamicFieldsData.D13;
                objDynamicField.Row13Col5 = dynamicFieldsData.E13;
                objDynamicField.Row13Col6 = dynamicFieldsData.F13;
                objDynamicField.Row14Col1 = dynamicFieldsData.A14;
                objDynamicField.Row14Col2 = dynamicFieldsData.B14;
                objDynamicField.Row14Col3 = dynamicFieldsData.C14;
                objDynamicField.Row14Col4 = dynamicFieldsData.D14;
                objDynamicField.Row14Col5 = dynamicFieldsData.E14;
                objDynamicField.Row14Col6 = dynamicFieldsData.F14;
                objComp.DynamicTableInputs = objDynamicField;
            }

        }

        /// <summary>
        /// Populate Image Data
        /// </summary>
        /// <param name="objSubmissionData"></param>
        /// <param name="objCIR"></param>
        /// <param name="cosmosDict"></param>
        /// <param name="cirType"></param>
        public static void PopulateImageData(CirSubmissionData objSubmissionData, ComponentInspectionReport objCIR, Dictionary<string, object> cosmosDict, string cirType)
        {
            if (cirType.ToLower() == "simplifiedcir")
            {
                PopulateCirSimplifiedImageData(objSubmissionData, objCIR, cosmosDict, cirType);
            }
            else
            {
                var dictval = ((cirType.ToLower() == "bladeinspection" || cirType.ToLower() == "bladerepair") && (objSubmissionData.templateVersion >= 1 || cosmosDict.ContainsKey("imagecomponentKey"))) ? (from x in cosmosDict
                                                                                                                                                                                                             where x.Key.ToLower() == "imagecomponentkey"
                                                                                                                                                                                                             select x).ToList() : (from x in cosmosDict
                                                                                                                                                                                                                                   where x.Key.ToLower() == "page3uploadimages"
                                                                                                                                                                                                                                   select x).ToList();
                if (dictval.Count > 0)
                {
                    if (objSubmissionData.ImageReferences != null)
                    {
                        int i = 0;
                        Cir.Azure.MobileApp.Service.CirSyncService.ImageData[] lstImage = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData[objSubmissionData.ImageReferences.Count];
                        foreach (ImageDataModel objImage in objSubmissionData.ImageReferences)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(objImage.BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(objImage.BinaryDataUrl);

                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = objImage.BinaryDataUrl;

                            if (cirType.ToLower() == "gearbox" || cirType.ToLower() == "transformer" || cirType.ToLower() == "generator" || cirType.ToLower() == "mainbearing" || cirType.ToLower() == "general" || cirType.ToLower() == "skiipack" || (objSubmissionData.templateVersion < 1 && !cosmosDict.ContainsKey("imagecomponentKey")))
                            {
                                List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["page3UploadImages"].ToString());
                                var imageInfo = lstImageInfo.First(item => item.imageId == objImage.ImageId);
                                objImageData.ImageOrder = lstImageInfo.FindIndex(item => item.imageId == objImage.ImageId);
                                objImageData.ImageDescription = imageInfo.fileInfo.name + "##" + imageInfo.description;
                            }
                            else // Populate Image Data for New Blade Inspections
                            {
                                ImagecomponentKey lstImagecomponentKey = JsonConvert.DeserializeObject<ImagecomponentKey>(cosmosDict["imagecomponentKey"].ToString());

                                #region [Populate ImageDataInfo Object]
                                ImageDataInfo objImageDataInfo = new ImageDataInfo();
                                try
                                {
                                    if (!lstImagecomponentKey.withPlatePicture)
                                    {
                                        objImageDataInfo.IsPlateTypeNotPossible = true;
                                        objImageDataInfo.PlateTypeNotPossibleReason = string.IsNullOrEmpty(lstImagecomponentKey.reason) ? string.Empty : lstImagecomponentKey.reason;
                                    }
                                    else
                                    {
                                        objImageDataInfo.IsPlateTypeNotPossible = false;
                                        objImageDataInfo.PlateTypeNotPossibleReason = string.Empty;
                                    }
                                    objCIR.ImageDataInfo = objImageDataInfo;
                                }
                                catch (Exception ex)
                                {
                                    objImageDataInfo.IsPlateTypeNotPossible = false;
                                    objImageDataInfo.PlateTypeNotPossibleReason = string.Empty;
                                    objCIR.ImageDataInfo = objImageDataInfo;
                                }
                                #endregion [Populate ImageDataInfo Object]

                                #region [Populate ImageData Object]

                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section1 != null && lstImagecomponentKey.sections.section1.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section1.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section1", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section2 != null && lstImagecomponentKey.sections.section2.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section2.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section2", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section3 != null && lstImagecomponentKey.sections.section3.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section3.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section3", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section4 != null && lstImagecomponentKey.sections.section4.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section4.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section4", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section5 != null && lstImagecomponentKey.sections.section5.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section5.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section5", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section6 != null && lstImagecomponentKey.sections.section6.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section6.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section6", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section7 != null && lstImagecomponentKey.sections.section7.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section7.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section7", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section8 != null && lstImagecomponentKey.sections.section8.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section8.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section8", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section9 != null && lstImagecomponentKey.sections.section9.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section9.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section9", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section10 != null && lstImagecomponentKey.sections.section10.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section10.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section10", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section11 != null && lstImagecomponentKey.sections.section11.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section11.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section11", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }
                                if (objImageData.ImageDescription == null && lstImagecomponentKey.sections != null && lstImagecomponentKey.sections.section12 != null && lstImagecomponentKey.sections.section12.images.Count > 0)
                                {
                                    List<Images> lstImageInfo = lstImagecomponentKey.sections.section12.images.Where(item => item.imageId == objImage.ImageId).ToList<Images>();
                                    if (lstImageInfo.Count > 0)
                                    {
                                        objImageData.ImageDescription = lstImageInfo[0].fileInfo.name + "##" + SetImageDescriptionforBlade("section12", lstImageInfo[0].damageDescription);
                                        objImageData.ImageOrder = lstImageInfo[0].number;
                                    }
                                }

                                #endregion [Populate ImageData Object]

                                #region [Populate PlateType Image]

                                if (objImageData.ImageDescription == null && lstImagecomponentKey.plate != null)
                                {
                                    if (lstImagecomponentKey.plate.imageId == objImage.ImageId)
                                    {
                                        objImageData.ImageDescription = lstImagecomponentKey.plate.fileInfo.name + "##";
                                        objImageData.ImageOrder = 0;
                                        objImageData.IsPlateType = true;
                                    }
                                }
                                #endregion [Populate PlateType Image]
                            }
                            objImageData.ImageUrl = objImage.BinaryDataUrl;
                            objImageData.FormIOImageGUID = objImage.ImageId;
                            objImageData.InspectionDesc = cosmosDict.ContainsKey("txtInspectionDescription") ? Convert.ToString(cosmosDict["txtInspectionDescription"]) : string.Empty;
                            objImageData.IsNewImageControl = true;
                            lstImage[i] = objImageData;
                            i++;
                        }
                        lstImage = lstImage.OrderBy(x => x.ImageOrder).ToArray();
                        objCIR.ImageData = lstImage;

                    }
                }
            }
        }

        /// <summary>
        /// Set Image Description for Blade
        /// </summary>
        /// <param name="section"></param>
        /// <param name="damageDesc"></param>
        /// <returns></returns>
        public static string SetImageDescriptionforBlade(string section, string damageDesc)
        {
            string imageDescription = string.Empty;
            string imageSide = string.Empty;
            string area = string.Empty;
            switch (section.ToLower())
            {
                case "section2":
                case "section6":
                case "section10":
                    imageSide = "LW";
                    break;
                case "section3":
                case "section7":
                case "section11":
                    imageSide = "LE";
                    break;
                case "section1":
                case "section5":
                case "section9":
                    imageSide = "TE";
                    break;
                case "section4":
                case "section8":
                case "section12":
                    imageSide = "WW";
                    break;
                default:
                    break;
            }
            switch (section.ToLower())
            {
                case "section1":
                case "section2":
                case "section3":
                case "section4":
                    area = "Root";
                    break;
                case "section5":
                case "section6":
                case "section7":
                case "section8":
                    area = "Mid";
                    break;
                case "section9":
                case "section10":
                case "section11":
                case "section12":
                    area = "Tip";
                    break;
                default:
                    break;
            }

            if (string.IsNullOrEmpty(damageDesc))
                damageDesc = "no damage";
            imageDescription = imageSide + " " + area + " - " + damageDesc;
            return imageDescription;
        }

        /// <summary>
        /// Populate Simplified CIR's Image Data 
        /// </summary>
        /// <param name="objSubmissionData"></param>
        /// <param name="objComp"></param>
        /// <param name="cosmosDict"></param>
        /// <param name="cirType"></param>
        public static void PopulateCirSimplifiedImageData(CirSubmissionData objSubmissionData, ComponentInspectionReport objComp, Dictionary<string, object> cosmosDict, string cirType)
        {
            if (objSubmissionData.ImageReferences != null)
            {
                int i = 0;
                Cir.Azure.MobileApp.Service.CirSyncService.ImageData[] lstImage = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData[objSubmissionData.ImageReferences.Count];
                if (cosmosDict.ContainsKey("imageUploader-Flange1"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange1"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 1;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            imageOrder++;
                            i++;
                        }
                    }
                }
                if (cosmosDict.ContainsKey("imageUploader-Flange2"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange2"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 2;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            i++;
                            imageOrder++;
                        }
                    }
                }
                if (cosmosDict.ContainsKey("imageUploader-Flange3"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange3"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 3;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            i++;
                            imageOrder++;
                        }
                    }
                }
                if (cosmosDict.ContainsKey("imageUploader-Flange4"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange4"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 4;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            i++;
                            imageOrder++;
                        }
                    }
                }
                if (cosmosDict.ContainsKey("imageUploader-Flange5"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange5"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 5;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            i++;
                            imageOrder++;
                        }
                    }
                }
                if (cosmosDict.ContainsKey("imageUploader-Flange6"))
                {
                    int imageOrder = 0;
                    List<ImageInfo> lstImageInfo = JsonConvert.DeserializeObject<List<ImageInfo>>(cosmosDict["imageUploader-Flange6"].ToString());
                    foreach (ImageInfo objImageInfo in lstImageInfo)
                    {
                        var imageReference = objSubmissionData.ImageReferences.Where(item => item.ImageId == objImageInfo.imageId).ToList();
                        if (imageReference.Count > 0)
                        {
                            Cir.Azure.MobileApp.Service.CirSyncService.ImageData objImageData = new Cir.Azure.MobileApp.Service.CirSyncService.ImageData();
                            //ImageData obj = new ImageData();
                            //string imageURI = obj.GetByImageUrl(imageReference[0].BinaryDataUrl);
                            //WebClient client = new WebClient();
                            //string dataString = client.DownloadString(imageURI);
                            //objImageData.ImageDataString = "data:image/jpeg;base64," + dataString;

                            objImageData.ImageDataString = imageReference[0].BinaryDataUrl;
                            objImageData.ImageDescription = objImageInfo.fileInfo.name + "##" + objImageInfo.description;
                            objImageData.FlangNo = 6;
                            objImageData.ImageOrder = imageOrder;
                            objImageData.ImageUrl = imageReference[0].BinaryDataUrl;
                            objImageData.FormIOImageGUID = imageReference[0].ImageId;
                            lstImage[i] = objImageData;
                            i++;
                            imageOrder++;
                        }
                    }
                }
                objComp.ImageData = lstImage;
            }
        }
    }
}

