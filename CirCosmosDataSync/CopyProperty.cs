using Cir.Data.Access.CirSyncService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirCosmosDataSync
{
    public class CopyProperty<TParent, TChild> where TParent : IDictionary<string, object> where TChild : class
    {
        public static void Copy(TParent source, TChild destination)
        {
            foreach (var src in source)
            {
                if (src.Value == null)
                {
                    string key = src.Key.ToString();
                    if (key.ToLower() == "imagedata" || key.ToLower() == "outsidesign")
                    {
                        continue;
                    }
                    var p = destination.GetType().GetProperty(key);
                    if (p == null)
                    {
                        continue;
                    }

                    else if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        p.SetValue(destination, null);
                    }
                    else
                    {
                        string destName = destination.GetType().GetProperty(key).PropertyType.Name.ToLower();
                        switch (destName)
                        {
                            case "int64":
                            case "int32":
                                p.SetValue(destination, 0);
                                break;
                            case "boolean":
                                p.SetValue(destination, false);
                                break;
                            case "string":
                                p.SetValue(destination, string.Empty);
                                break;
                            case "decimal":
                                p.SetValue(destination, Convert.ToDecimal(0));
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    var srcName = src.Value.GetType().Name.ToLower();
                    var srcKey = src.Key.ToString();
                    bool isPropertyNullable = false;
                    if (srcKey.ToLower() == "imagedata" || srcKey.ToLower() == "outsidesign")
                    {
                        continue;
                    }
                    string destName = string.Empty;
                    var p = destination.GetType().GetProperty(srcKey);
                    if (p != null && p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        destName = p.PropertyType.GetGenericArguments()[0].Name.ToString().ToLower();
                        isPropertyNullable = true;
                    }
                    else
                    {
                        if (p != null)
                        {
                            destName = p.PropertyType.Name.ToLower().ToLower();
                        }
                    }
                    if (srcName == "datetime")
                    {
                        var dateString = Convert.ToDateTime(src.Value).ToString("yyyy/MM/ddT00:00:00");
                        var formattedDate = DateTime.ParseExact(dateString, "yyyy/MM/ddThh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        //TimeZoneInfo cetZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
                        //var dt = Convert.ToDateTime(src.Value);
                        //var dateString = TimeZoneInfo.ConvertTimeFromUtc(dt, cetZone).ToString("yyyy/MM/ddT00:00:00");
                        //var formattedDate = DateTime.ParseExact(dateString, "yyyy/MM/ddThh:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                        if (destName == "datetime")
                        {
                            p.SetValue(destination, formattedDate);
                        }
                        else
                        {
                            p.SetValue(destination, dateString);
                        }
                    }
                    else if (srcKey.ToLower() == "gearboxgeardecision1damagedecisionid" || srcKey.ToLower() == "gearboxgeardecision2damagedecisionid"
                        || srcKey.ToLower() == "gearboxgeardecision3damagedecisionid" || srcKey.ToLower() == "gearboxgeardecision4damagedecisionid" || srcKey.ToLower() == "gearboxgeardecision5damagedecisionid"
                        || srcKey.ToLower() == "gearboxgeardecision6damagedecisionid" || srcKey.ToLower() == "gearboxgeardecision7damagedecisionid"
                        || srcKey.ToLower() == "gearboxgeardecision8damagedecisionid" || srcKey.ToLower() == "gearboxgeardecision9damagedecisionid"
                        || srcKey.ToLower() == "gearboxgeardecision10damagedecisionid" || srcKey.ToLower() == "gearboxgeardecision11damagedecisionid"
                        || srcKey.ToLower() == "gearboxgeardecision12damagedecisionid" || srcKey.ToLower() == "gearboxgeardecision13damagedecisionid"
                        || srcKey.ToLower() == "gearboxgeardecision14damagedecisionid" || srcKey.ToLower() == "gearboxgeardecision15damagedecisionid")
                    {
                        if (src.Value.ToString().ToLower() == "re-use")
                            p.SetValue(destination, Convert.ToInt64(1));
                        else if (src.Value.ToString().ToLower() == "re-work")
                            p.SetValue(destination, Convert.ToInt64(2));
                        else if (src.Value.ToString().ToLower() == "scrap")
                            p.SetValue(destination, Convert.ToInt64(3));
                        else if (src.Value.ToString().ToLower() == "upgrade")
                            p.SetValue(destination, Convert.ToInt64(4));
                        else if (src.Value.ToString().ToLower() == "n/a")
                            p.SetValue(destination, Convert.ToInt64(5));
                        else
                            p.SetValue(destination, null);
                    }
                    else if (srcKey.ToLower() == "gearboxgeardamageclass1damageid" || srcKey.ToLower() == "gearboxgeardamageclass2damageid" || srcKey.ToLower() == "gearboxgeardamageclass7damageid" || srcKey.ToLower() == "gearboxgeardamageclass10damageid" || srcKey.ToLower() == "gearboxgeardamageclass15damageid"
                        || srcKey.ToLower() == "gearboxgeardamageclass4damageid" || srcKey.ToLower() == "gearboxgeardamageclass3damageid" || srcKey.ToLower() == "gearboxgeardamageclass8damageid" || srcKey.ToLower() == "gearboxgeardamageclass11damageid" || srcKey.ToLower() == "gearboxgeardamageclass13damageid"
                        || srcKey.ToLower() == "gearboxgeardamageclass5damageid" || srcKey.ToLower() == "gearboxgeardamageclass6damageid" || srcKey.ToLower() == "gearboxgeardamageclass9damageid" || srcKey.ToLower() == "gearboxgeardamageclass12damageid" || srcKey.ToLower() == "gearboxgeardamageclass14damageid")
                    {
                        DamageClass myClass = JsonConvert.DeserializeObject<DamageClass>(src.Value.ToString());
                        if (myClass != null && myClass.value > 0)
                            p.SetValue(destination, Object.Equals(src.Value, "") ? 0 : myClass.value);
                        else
                            p.SetValue(destination, null);
                    }

                    else if (srcName != destName)
                    {
                        switch (destName)
                        {
                            case "int64":
                                if (isPropertyNullable == true && Object.Equals(src.Value, ""))
                                    p.SetValue(destination, null);
                                else
                                    p.SetValue(destination, Object.Equals(src.Value, "") ? 0 : Convert.ToInt64(src.Value));
                                break;
                            case "int32":
                                if (isPropertyNullable == true && Object.Equals(src.Value, ""))
                                    p.SetValue(destination, null);
                                else
                                    p.SetValue(destination, Object.Equals(src.Value, "") ? 0 : Convert.ToInt32(src.Value));
                                break;
                            case "boolean":
                                if (isPropertyNullable == true && Object.Equals(src.Value, ""))
                                    p.SetValue(destination, null);
                                else
                                    p.SetValue(destination, Object.Equals(src.Value, "") ? false : Convert.ToBoolean(src.Value));
                                break;
                            case "decimal":
                                if (isPropertyNullable == true && Object.Equals(src.Value, ""))
                                    p.SetValue(destination, null);
                                else
                                    p.SetValue(destination, Object.Equals(src.Value, "") ? 0 : Convert.ToDecimal(src.Value));
                                break;
                            case "string":
                                if (isPropertyNullable == true && Object.Equals(src.Value, ""))
                                    p.SetValue(destination, null);
                                else
                                    p.SetValue(destination, Convert.ToString(src.Value));
                                break;
                            case "componentinspectionreportgearbox":
                                Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportGearbox objGearBox = new Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportGearbox();
                                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportGearbox>.Copy((IDictionary<string, object>)src.Value, objGearBox);
                                p.SetValue(destination, objGearBox);
                                break;
                            case "turbineproperties":
                                Cir.Azure.MobileApp.Service.CirSyncService.TurbineProperties objTurbineProperties = new Cir.Azure.MobileApp.Service.CirSyncService.TurbineProperties();
                                CopyTurbineProperties(objTurbineProperties, (IDictionary<string, object>)src.Value);
                                p.SetValue(destination, objTurbineProperties);
                                break;
                            case "componentinspectionreportblade":
                                Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportBlade objBladeData = new Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportBlade();
                                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportBlade>.Copy((IDictionary<string, object>)src.Value, objBladeData);
                                p.SetValue(destination, objBladeData);
                                break;
                            case "componentinspectionreportbladedamage":
                                Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportBladeDamage objBladeDamageData = new Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportBladeDamage();
                                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportBladeDamage>.Copy((IDictionary<string, object>)src.Value, objBladeDamageData);
                                p.SetValue(destination, objBladeDamageData);
                                break;
                            case "componentinspectionreportbladerepairrecord":
                                Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportBladeRepairRecord objBladeRepairData = new Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportBladeRepairRecord();
                                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportBladeRepairRecord>.Copy((IDictionary<string, object>)src.Value, objBladeRepairData);
                                p.SetValue(destination, objBladeRepairData);
                                break;
                            case "componentinspectionreporttransformer":
                                Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportTransformer objTransformerData = new Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportTransformer();
                                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportTransformer>.Copy((IDictionary<string, object>)src.Value, objTransformerData);
                                p.SetValue(destination, objTransformerData);
                                break;
                            case "componentinspectionreportgenerator":
                                Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportGenerator objGeneratorData = new Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportGenerator();
                                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportGenerator>.Copy((IDictionary<string, object>)src.Value, objGeneratorData);
                                p.SetValue(destination, objGeneratorData);
                                break; 
                            case "componentinspectionreportmainbearing":
                                Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportMainBearing objMainBearingData = new Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportMainBearing();
                                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportMainBearing>.Copy((IDictionary<string, object>)src.Value, objMainBearingData);
                                p.SetValue(destination, objMainBearingData);
                                break;
                            case "commoninspectiongeneral":
                                Cir.Azure.MobileApp.Service.CirSyncService.CommonInspectionGeneral objGeneralData = new Cir.Azure.MobileApp.Service.CirSyncService.CommonInspectionGeneral();
                                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.CommonInspectionGeneral>.Copy((IDictionary<string, object>)src.Value, objGeneralData);
                                p.SetValue(destination, objGeneralData);
                                break;
                            case "componentinspectionreportskiip":
                                Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportSkiiP objSkiipackData = new Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportSkiiP();
                                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.ComponentInspectionReportSkiiP>.Copy((IDictionary<string, object>)src.Value, objSkiipackData);
                                p.SetValue(destination, objSkiipackData);
                                break;
                            case "dynamictable":
                                Cir.Azure.MobileApp.Service.CirSyncService.DynamicTable objDynamicTableData = new Cir.Azure.MobileApp.Service.CirSyncService.DynamicTable();
                                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.DynamicTable>.Copy((IDictionary<string, object>)src.Value, objDynamicTableData);
                                p.SetValue(destination, objDynamicTableData);
                                break;
                            case "imagedatainfo":
                                Cir.Azure.MobileApp.Service.CirSyncService.ImageDataInfo objImageDataInfo = new Cir.Azure.MobileApp.Service.CirSyncService.ImageDataInfo();
                                CopyProperty<IDictionary<string, object>, Cir.Azure.MobileApp.Service.CirSyncService.ImageDataInfo>.Copy((IDictionary<string, object>)src.Value, objImageDataInfo);
                                p.SetValue(destination, objImageDataInfo);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (isPropertyNullable == true && Object.Equals(src.Value, ""))
                    {
                        p.SetValue(destination, null);
                    }
                    else
                    {
                        p.SetValue(destination, src.Value);
                    }
                }
            }
        }

        public static void CopyTurbineProperties(Cir.Azure.MobileApp.Service.CirSyncService.TurbineProperties objTurbineProperties, IDictionary<string, object> Values)
        {
            objTurbineProperties.Country = Object.Equals(Values["Country"], "") ? string.Empty : Convert.ToString(Values["Country"]);
            objTurbineProperties.CountryIsoId = Object.Equals(Values["CountryIsoId"], "") ? 0 : Convert.ToInt64(Values["CountryIsoId"]);
            objTurbineProperties.Frequency = Object.Equals(Values["Frequency"], "") ? default(byte) : Convert.ToByte(Values["Frequency"]);
            objTurbineProperties.LocalTurbineId = Object.Equals(Values["LocalTurbineId"], "") ? string.Empty : Convert.ToString(Values["LocalTurbineId"]);
            objTurbineProperties.Manufacturer = Object.Equals(Values["Manufacturer"], "") ? string.Empty : Convert.ToString(Values["Manufacturer"]);
            objTurbineProperties.MarkVersion = Object.Equals(Values["MarkVersion"], "") ? string.Empty : Convert.ToString(Values["MarkVersion"]);
            objTurbineProperties.NominelPower = Object.Equals(Values["NominelPower"], "") ? 0 : Convert.ToInt32(Values["NominelPower"]);
            objTurbineProperties.NominelPowerId = Object.Equals(Values["NominelPowerId"], "") ? 0 : Convert.ToInt64(Values["NominelPowerId"]);
            objTurbineProperties.Placement = Object.Equals(Values["Placement"], "") ? string.Empty : Convert.ToString(Values["Placement"]);
            objTurbineProperties.PowerRegulation = Object.Equals(Values["PowerRegulation"], "") ? string.Empty : Convert.ToString(Values["PowerRegulation"]);
            objTurbineProperties.RotorDiameter = Object.Equals(Values["RotorDiameter"], "") ? 0 : Convert.ToDecimal(Values["RotorDiameter"]);
            objTurbineProperties.Site = Object.Equals(Values["Site"], "") ? string.Empty : Convert.ToString(Values["Site"]);
            objTurbineProperties.SmallGenerator = Object.Equals(Values["SmallGenerator"], "") ? 0 : Convert.ToInt32(Values["SmallGenerator"]);
            objTurbineProperties.TemperatureVariant = Object.Equals(Values["TemperatureVariant"], "") ? string.Empty : Convert.ToString(Values["TemperatureVariant"]);
            objTurbineProperties.Turbine = Object.Equals(Values["Turbine"], "") ? string.Empty : Convert.ToString(Values["Turbine"]);
            objTurbineProperties.TurbineMatrixId = Object.Equals(Values["TurbineMatrixId"], "") ? 0 : Convert.ToInt64(Values["TurbineMatrixId"]);
            objTurbineProperties.Voltage = Object.Equals(Values["Voltage"], "") ? 0 : Convert.ToInt32(Values["Voltage"]);

        }
    }
}
