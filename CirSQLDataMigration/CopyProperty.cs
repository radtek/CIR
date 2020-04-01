using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirSQLDataMigration
    {
    public class CopyProperty
        {
        public static int totalNumberOfComponentInSkiipack = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static Dictionary<string, object> CopyFieldsSimplifiedCir(Dictionary<string, object> source, IDictionary<string, object> destination, Dictionary<string, object> source1, List<FlangeArray> FlangeArray, Dictionary<string, object> turbineData, string cirType)
            {
            Dictionary<string, object> cosmosdic = new Dictionary<string, object>();
            try
                {
                //var dynamiktable = ((Newtonsoft.Json.Linq.JToken)new System.Collections.Generic.Dictionary<string, object>(source).Item[29].Value)["Row1Col1"];
                foreach (var item in destination)
                    {
                    if (item.Value != null)
                        {
                        if (item.Key.ToString().IndexOf("Flange") > 0)
                            {
                            if (item.Key.ToString() == "chkDamageIdentifiedSimplifiedFlange1")
                                {
                                var flag = FlangeArray.Where(a => a.FlangeNo == 1 && a.FlangeDamageIdentified == true).Select(z => z.FlangeDamageIdentified).FirstOrDefault();
                                if (flag == true)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);

                                    }
                                }

                            else if (item.Key.ToString() == "chkDamageIdentifiedSimplifiedFlange2")
                                {
                                var flag = FlangeArray.Where(a => a.FlangeNo == 2 && a.FlangeDamageIdentified == true).Select(z => z.FlangeDamageIdentified).FirstOrDefault();
                                if (flag == true)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);
                                    }
                                }
                            else if (item.Key.ToString() == "chkDamageIdentifiedSimplifiedFlange3")
                                {
                                var flag = FlangeArray.Where(a => a.FlangeNo == 3 && a.FlangeDamageIdentified == true).Select(z => z.FlangeDamageIdentified).FirstOrDefault();
                                if (flag == true)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);
                                    }
                                }
                            else if (item.Key.ToString() == "chkDamageIdentifiedSimplifiedFlange4")
                                {
                                var flag = FlangeArray.Where(a => a.FlangeNo == 4 && a.FlangeDamageIdentified == true).Select(z => z.FlangeDamageIdentified).FirstOrDefault();
                                if (flag == true)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);
                                    }
                                }
                            else if (item.Key.ToString() == "chkDamageIdentifiedSimplifiedFlange5")
                                {
                                var flag = FlangeArray.Where(a => a.FlangeNo == 5 && a.FlangeDamageIdentified == true).Select(z => z.FlangeDamageIdentified).FirstOrDefault();
                                if (flag == true)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);
                                    }
                                }
                            else if (item.Key.ToString() == "chkDamageIdentifiedSimplifiedFlange6")
                                {
                                var flag = FlangeArray.Where(a => a.FlangeNo == 6 && a.FlangeDamageIdentified == true).Select(z => z.FlangeDamageIdentified).FirstOrDefault();
                                if (flag == true)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);
                                    }
                                }
                            else if (item.Key.ToString() == "chkReplaceaffectedBolts-Flange1")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 1 && a.FlangeDamageIdentified == true).Select(a => a.AffectedBolts).FirstOrDefault();
                                if (FlangeValue == 0)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                }

                            else if (item.Key.ToString() == "ddlDecision-Flange1")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 1 && a.FlangeDamageIdentified == true).Select(a => a.DecisionFlange).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }

                            else if (item.Key.ToString() == "ddlRepeatedinspection-Flange1")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 1 && a.FlangeDamageIdentified == true).Select(a => a.RepeatedInspections).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }
                            else if (item.Key.ToString() == "chkReplaceaffectedBolts-Flange2")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 2 && a.FlangeDamageIdentified == true).Select(a => a.AffectedBolts).FirstOrDefault();
                                if (FlangeValue == 0)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                }

                            else if (item.Key.ToString() == "ddlDecision-Flange2")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 2 && a.FlangeDamageIdentified == true).Select(a => a.DecisionFlange).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }

                            else if (item.Key.ToString() == "ddlRepeatedinspection-Flange2")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 2 && a.FlangeDamageIdentified == true).Select(a => a.RepeatedInspections).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }
                            else if (item.Key.ToString() == "chkReplaceaffectedBolts-Flange3")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 3 && a.FlangeDamageIdentified == true).Select(a => a.AffectedBolts).FirstOrDefault();
                                if (FlangeValue == 0)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                }

                            else if (item.Key.ToString() == "ddlDecision-Flange3")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 3 && a.FlangeDamageIdentified == true).Select(a => a.DecisionFlange).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }

                            else if (item.Key.ToString() == "ddlRepeatedinspection-Flange3")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 3 && a.FlangeDamageIdentified == true).Select(a => a.RepeatedInspections).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }
                            else if (item.Key.ToString() == "chkReplaceaffectedBolts-Flange4")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 4 && a.FlangeDamageIdentified == true).Select(a => a.AffectedBolts).FirstOrDefault();
                                if (FlangeValue == 0)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                }

                            else if (item.Key.ToString() == "ddlDecision-Flange4")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 4 && a.FlangeDamageIdentified == true).Select(a => a.DecisionFlange).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }

                            else if (item.Key.ToString() == "ddlRepeatedinspection-Flange4")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 4 && a.FlangeDamageIdentified == true).Select(a => a.RepeatedInspections).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }
                            else if (item.Key.ToString() == "chkReplaceaffectedBolts-Flange5")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 5 && a.FlangeDamageIdentified == true).Select(a => a.AffectedBolts).FirstOrDefault();
                                if (FlangeValue == 0)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                }

                            else if (item.Key.ToString() == "ddlDecision-Flange5")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 5 && a.FlangeDamageIdentified == true).Select(a => a.DecisionFlange).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }

                            else if (item.Key.ToString() == "ddlRepeatedinspection-Flange5")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 5 && a.FlangeDamageIdentified == true).Select(a => a.RepeatedInspections).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }
                            else if (item.Key.ToString() == "chkReplaceaffectedBolts-Flange6")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 6 && a.FlangeDamageIdentified == true).Select(a => a.AffectedBolts).FirstOrDefault();
                                if (FlangeValue == 0)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), false);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), true);
                                    }
                                }

                            else if (item.Key.ToString() == "ddlDecision-Flange6")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 6 && a.FlangeDamageIdentified == true).Select(a => a.DecisionFlange).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }

                            else if (item.Key.ToString() == "ddlRepeatedinspection-Flange6")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 6 && a.FlangeDamageIdentified == true).Select(a => a.RepeatedInspections).FirstOrDefault();
                                if (FlangeValue == 1 || FlangeValue == 22 || FlangeValue == 23 || FlangeValue == 24 || FlangeValue == 28 || FlangeValue == 30 || FlangeValue == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(FlangeValue));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), FlangeValue));
                                    }
                                }
                            else if (item.Key.ToString() == "txtInspectionDescription-Flange1")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 1 && a.FlangeDamageIdentified == true).Select(a => a.InspectionDescription).FirstOrDefault();
                                if (string.IsNullOrEmpty(FlangeValue))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "");
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), FlangeValue);
                                    }
                                }
                            else if (item.Key.ToString() == "txtInspectionDescription-Flange2")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 2 && a.FlangeDamageIdentified == true).Select(a => a.InspectionDescription).FirstOrDefault();
                                if (string.IsNullOrEmpty(FlangeValue))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "");
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), FlangeValue);
                                    }
                                }
                            else if (item.Key.ToString() == "txtInspectionDescription-Flange3")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 3 && a.FlangeDamageIdentified == true).Select(a => a.InspectionDescription).FirstOrDefault();
                                if (string.IsNullOrEmpty(FlangeValue))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "");
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), FlangeValue);
                                    }
                                }
                            else if (item.Key.ToString() == "txtInspectionDescription-Flange4")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 4 && a.FlangeDamageIdentified == true).Select(a => a.InspectionDescription).FirstOrDefault();
                                if (string.IsNullOrEmpty(FlangeValue))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "");
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), FlangeValue);
                                    }
                                }
                            else if (item.Key.ToString() == "txtInspectionDescription-Flange5")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 5 && a.FlangeDamageIdentified == true).Select(a => a.InspectionDescription).FirstOrDefault();
                                if (string.IsNullOrEmpty(FlangeValue))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "");
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), FlangeValue);
                                    }
                                }
                            else if (item.Key.ToString() == "txtInspectionDescription-Flange6")
                                {
                                var FlangeValue = FlangeArray.Where(a => a.FlangeNo == 6 && a.FlangeDamageIdentified == true).Select(a => a.InspectionDescription).FirstOrDefault();
                                if (string.IsNullOrEmpty(FlangeValue))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "");
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), FlangeValue);
                                    }
                                }
                            else if (item.Key.ToString() == "ddlBoltmanufacture-Flange1" || item.Key.ToString() == "ddlBoltmanufacture-Flange2" || item.Key.ToString() == "ddlBoltmanufacture-Flange3" || item.Key.ToString() == "ddlBoltmanufacture-Flange4" || item.Key.ToString() == "ddlBoltmanufacture-Flange5" || item.Key.ToString() == "ddlBoltmanufacture-Flange6")
                                {
                                var FlangeValue = source1[item.Value.ToString()];
                                if (Convert.ToInt16(FlangeValue) == 1 || Convert.ToInt16(FlangeValue) == 22 || Convert.ToInt16(FlangeValue) == 23 || Convert.ToInt16(FlangeValue) == 24 || Convert.ToInt16(FlangeValue) == 28 || Convert.ToInt16(FlangeValue) == 30 || Convert.ToInt16(FlangeValue) == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(Convert.ToInt16(FlangeValue)));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), Convert.ToInt16(FlangeValue)));
                                    }
                                }
                            else if (item.Key.ToString() == "ddlBoltsizeMxx-Flange1" || item.Key.ToString() == "ddlBoltsizeMxx-Flange2" || item.Key.ToString() == "ddlBoltsizeMxx-Flange3" || item.Key.ToString() == "ddlBoltsizeMxx-Flange4" || item.Key.ToString() == "ddlBoltsizeMxx-Flange5" || item.Key.ToString() == "ddlBoltsizeMxx-Flange6")
                                {
                                var FlangeValue = source1[item.Value.ToString()];
                                if (Convert.ToInt16(FlangeValue) == 10 || Convert.ToInt16(FlangeValue) == 1 || Convert.ToInt16(FlangeValue) == 22 || Convert.ToInt16(FlangeValue) == 23 || Convert.ToInt16(FlangeValue) == 24 || Convert.ToInt16(FlangeValue) == 28 || Convert.ToInt16(FlangeValue) == 30 || Convert.ToInt16(FlangeValue) == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(Convert.ToInt16(FlangeValue)));
                                    }
                                else
                                    if (Convert.ToInt16(FlangeValue) == 10)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "Other");
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), Convert.ToInt16(FlangeValue)));
                                    }
                                }
                            else if (item.Key.ToString() == "ddlMovingFlanges-Flange1" || item.Key.ToString() == "ddlMovingFlanges-Flange2" || item.Key.ToString() == "ddlMovingFlanges-Flange3" || item.Key.ToString() == "ddlMovingFlanges-Flange4" || item.Key.ToString() == "ddlMovingFlanges-Flange5" || item.Key.ToString() == "ddlMovingFlanges-Flange6")
                                {
                                var FlangeValue = source1[item.Value.ToString()];
                                if (Convert.ToInt16(FlangeValue) == 1 || Convert.ToInt16(FlangeValue) == 22 || Convert.ToInt16(FlangeValue) == 23 || Convert.ToInt16(FlangeValue) == 24 || Convert.ToInt16(FlangeValue) == 28 || Convert.ToInt16(FlangeValue) == 30 || Convert.ToInt16(FlangeValue) == 31)
                                    {
                                    cosmosdic.Add(item.Key.ToString(), CopyProperty.getValue(Convert.ToInt16(FlangeValue)));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), Enum.GetName(typeof(Decision), Convert.ToInt16(FlangeValue)));
                                    }
                                }

                            else if (item.Key.ToString() == "ddlCorrosionmarksonplatform-Flange1" || item.Key.ToString() == "ddlCorrosionmarksonplatform-Flange2" || item.Key.ToString() == "ddlCorrosionmarksonplatform-Flange3" || item.Key.ToString() == "ddlCorrosionmarksonplatform-Flange4" || item.Key.ToString() == "ddlCorrosionmarksonplatform-Flange5" || item.Key.ToString() == "ddlCorrosionmarksonplatform-Flange6")
                                {
                                if (source1[item.Value.ToString()].ToString() == "1")
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "No");
                                    }
                                else if (source1[item.Value.ToString()].ToString() == "2")
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "Yes");
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "");
                                    }
                                }
                            else if (item.Key.ToString() == "txtVUIBoltplate-Flange1" || item.Key.ToString() == "txtVUIBoltplate-Flange2" || item.Key.ToString() == "txtVUIBoltplate-Flange3" || item.Key.ToString() == "txtVUIBoltplate-Flange4" || item.Key.ToString() == "txtVUIBoltplate-Flange5" || item.Key.ToString() == "txtVUIBoltplate-Flange6")
                                {
                                if (!string.IsNullOrEmpty(source1[item.Value.ToString()].ToString()) && IsNumeric(source1[item.Value.ToString()].ToString()))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (Convert.ToInt64(source1[item.Value.ToString()])));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (source1[item.Value.ToString()]));
                                    }
                                }
                            else if (item.Key.ToString() == "txtBrokenbolts-Flange1" || item.Key.ToString() == "txtBrokenbolts-Flange2" || item.Key.ToString() == "txtBrokenbolts-Flange3" || item.Key.ToString() == "txtBrokenbolts-Flange4" || item.Key.ToString() == "txtBrokenbolts-Flange5" || item.Key.ToString() == "txtBrokenbolts-Flange6")
                                {
                                if (!string.IsNullOrEmpty(source1[item.Value.ToString()].ToString()) && IsNumeric(source1[item.Value.ToString()].ToString()))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (Convert.ToInt64(source1[item.Value.ToString()])));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (source1[item.Value.ToString()]));
                                    }
                                }
                            else if (item.Key.ToString() == "txtOutsideSigns-Flange1" || item.Key.ToString() == "txtOutsideSigns-Flange2" || item.Key.ToString() == "txtOutsideSigns-Flange3" || item.Key.ToString() == "txtOutsideSigns-Flange4" || item.Key.ToString() == "txtOutsideSigns-Flange5" || item.Key.ToString() == "txtOutsideSigns-Flange6")
                                {
                                if (source1[item.Value.ToString()] != null && IsNumeric(source1[item.Value.ToString()].ToString()))
                                //if (!string.IsNullOrEmpty(source1[item.Value.ToString()].ToString()) && IsNumeric(source1[item.Value.ToString()].ToString()))
                                {
                                    cosmosdic.Add(item.Key.ToString(), (Convert.ToInt64(source1[item.Value.ToString()])));
                                }
                                else
                                {
                                    cosmosdic.Add(item.Key.ToString(), (source1[item.Value.ToString()] == null ? "" : source1[item.Value.ToString()]));
                                }
                                }
                            else if (item.Key.ToString() == "txtSignofserviceloosebolts-Flange1" || item.Key.ToString() == "txtSignofserviceloosebolts-Flange2" || item.Key.ToString() == "txtSignofserviceloosebolts-Flange3" || item.Key.ToString() == "txtSignofserviceloosebolts-Flange4" || item.Key.ToString() == "txtSignofserviceloosebolts-Flange5" || item.Key.ToString() == "txtSignofserviceloosebolts-Flange6")
                                {
                                if (!string.IsNullOrEmpty(source1[item.Value.ToString()].ToString()) && IsNumeric(source1[item.Value.ToString()].ToString()))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (Convert.ToInt64(source1[item.Value.ToString()])));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (source1[item.Value.ToString()]));
                                    }
                                }
                            else if (item.Key.ToString() == "txtWateringressbetweenflanges-Flange1" || item.Key.ToString() == "txtWateringressbetweenflanges-Flange2" || item.Key.ToString() == "txtWateringressbetweenflanges-Flange3" || item.Key.ToString() == "txtWateringressbetweenflanges-Flange4" || item.Key.ToString() == "txtWateringressbetweenflanges-Flange5" || item.Key.ToString() == "txtWateringressbetweenflanges-Flange6")
                                {
                                if (!string.IsNullOrEmpty(source1[item.Value.ToString()].ToString()) && IsNumeric(source1[item.Value.ToString()].ToString()))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (Convert.ToInt64(source1[item.Value.ToString()])));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (source1[item.Value.ToString()]));
                                    }
                                }
                            else if (item.Key.ToString() == "txtWateringressonboltheads-Flange1" || item.Key.ToString() == "txtWateringressonboltheads-Flange2" || item.Key.ToString() == "txtWateringressonboltheads-Flange3" || item.Key.ToString() == "txtWateringressonboltheads-Flange4" || item.Key.ToString() == "txtWateringressonboltheads-Flange5" || item.Key.ToString() == "txtWateringressonboltheads-Flange6")
                                {
                                if (!string.IsNullOrEmpty(source1[item.Value.ToString()].ToString()) && IsNumeric(source1[item.Value.ToString()].ToString()))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (Convert.ToInt64(source1[item.Value.ToString()])));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (source1[item.Value.ToString()]));
                                    }
                                }
                            else if (item.Key.ToString() == "txtObviousloosebolts-Flange1" || item.Key.ToString() == "txtObviousloosebolts-Flange2" || item.Key.ToString() == "txtObviousloosebolts-Flange3" || item.Key.ToString() == "txtObviousloosebolts-Flange4" || item.Key.ToString() == "txtObviousloosebolts-Flange5" || item.Key.ToString() == "txtObviousloosebolts-Flange6")
                                {
                                if (!string.IsNullOrEmpty(source1[item.Value.ToString()].ToString()) && IsNumeric(source1[item.Value.ToString()].ToString()))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (Convert.ToInt64(source1[item.Value.ToString()])));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (source1[item.Value.ToString()]));
                                    }
                                }
                            else if (item.Key.ToString() == "txtSealantingres-Flange1" || item.Key.ToString() == "txtSealantingres-Flange2" || item.Key.ToString() == "txtSealantingres-Flange3" || item.Key.ToString() == "txtSealantingres-Flange4" || item.Key.ToString() == "txtSealantingres-Flange5" || item.Key.ToString() == "txtSealantingres-Flange6")
                                {
                                if (!string.IsNullOrEmpty(source1[item.Value.ToString()].ToString()) && IsNumeric(source1[item.Value.ToString()].ToString()))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (Convert.ToInt64(source1[item.Value.ToString()])));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (source1[item.Value.ToString()]));
                                    }
                                }
                            else if (item.Key.ToString() == "txtCrackedPaint-Flange1" || item.Key.ToString() == "txtCrackedPaint-Flange2" || item.Key.ToString() == "txtCrackedPaint-Flange3" || item.Key.ToString() == "txtCrackedPaint-Flange4" || item.Key.ToString() == "txtCrackedPaint-Flange5" || item.Key.ToString() == "txtCrackedPaint-Flange6")
                                {
                                if (!string.IsNullOrEmpty(source1[item.Value.ToString()].ToString()) && IsNumeric(source1[item.Value.ToString()].ToString()))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (Convert.ToInt64(source1[item.Value.ToString()])));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (source1[item.Value.ToString()]));
                                    }
                                }
                            else if (item.Key.ToString() == "txtMetallizationdust-Flange1" || item.Key.ToString() == "txtMetallizationdust-Flange2" || item.Key.ToString() == "txtMetallizationdust-Flange3" || item.Key.ToString() == "txtMetallizationdust-Flange4" || item.Key.ToString() == "txtMetallizationdust-Flange5" || item.Key.ToString() == "txtMetallizationdust-Flange6")
                                {
                                if (!string.IsNullOrEmpty(source1[item.Value.ToString()].ToString()) && IsNumeric(source1[item.Value.ToString()].ToString()))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (Convert.ToInt64(source1[item.Value.ToString()])));
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), (source1[item.Value.ToString()]));
                                    }
                                }

                            else
                                {

                                if (source1.ContainsKey(item.Value.ToString()))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), source1[item.Value.ToString()]);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "");
                                    }
                                }
                            }
                        else
                            {
                            if (source.ContainsKey(item.Value.ToString()))
                                {
                                if (item.Key.ToString().StartsWith("ddl") && source[item.Value.ToString()] != null && item.Key.ToString().ToLower() != "ddlcimcasenumber")
                                    {
                                    //try
                                    //{
                                    if (item.Key.ToString() == "ddlOutSideSign")
                                        {

                                        cosmosdic.Add(item.Key.ToString(), (source[item.Value.ToString()].ToString() == "False") ? "0" : "1");
                                        }
                                    else
                                        {
                                        cosmosdic.Add(item.Key.ToString(), source[item.Value.ToString()].ToString());
                                        }
                                    //}
                                    //  catch { }
                                    }
                                else if ((item.Key.ToString().StartsWith("dt") || item.Key.ToString().Contains("T00:00:00")) && source[item.Value.ToString()] != null)
                                    {
                                    string formatedDate = ConvertDateType(source[item.Value.ToString()].ToString());
                                    cosmosdic.Add(item.Key.ToString(), formatedDate);
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), source[item.Value.ToString()]);
                                    }
                                }
                            else if (item.Key.ToString() == "txtRotorDiameter")
                                {

                                cosmosdic.Add(item.Key.ToString(), turbineData["RotorDiameter"]);
                                }
                            else if (item.Key.ToString() == "txtNominelPower")
                                {
                                cosmosdic.Add(item.Key.ToString(), turbineData["NominelPower"]);
                                }
                            else if (item.Key.ToString() == "txtVoltage")
                                {
                                cosmosdic.Add(item.Key.ToString(), turbineData["Voltage"]);
                                }
                            else if (item.Key.ToString() == "txtPowerRegulation")
                                { cosmosdic.Add(item.Key.ToString(), turbineData["PowerRegulation"]); }
                            else if (item.Key.ToString() == "txtSmallGenerator")
                                { cosmosdic.Add(item.Key.ToString(), turbineData["SmallGenerator"]); }
                            else if (item.Key.ToString() == "txtTemperatureVariant")
                                { cosmosdic.Add(item.Key.ToString(), turbineData["TemperatureVariant"]); }
                            else if (item.Key.ToString() == "txtMKversion")
                                { cosmosdic.Add(item.Key.ToString(), turbineData["MarkVersion"]); }
                            else if (item.Key.ToString() == "txtOnshoreOffshore")
                                { cosmosdic.Add(item.Key.ToString(), turbineData["Placement"]); }
                            else if (item.Key.ToString() == "txtManufacturer")
                                { cosmosdic.Add(item.Key.ToString(), turbineData["Manufacturer"]); }
                            else if (item.Key.ToString() == "txtLocalturbineId")
                                { cosmosdic.Add(item.Key.ToString(), turbineData["LocalTurbineId"]); }
                            else
                                {
                                cosmosdic.Add(item.Key.ToString(), "");
                                }
                            }
                        }
                    else
                        {
                        cosmosdic.Add(item.Key.ToString(), "");
                        }
                    }


                }

            //Added throw to handle exception in calling method
            catch (Exception ex) { throw; }
            if (cirType.ToLower() == "simplifiedcir")
                {
                RemoveFlange(cosmosdic);
                }

            return cosmosdic;
            }

        public static DateTime getDateTime(string dtDate)
            {
            return Convert.ToDateTime(dtDate).AddHours(5).AddMinutes(30);
            }

        public static Dictionary<string, object> CopyFields(Dictionary<string, object> source, IDictionary<string, object> destination)
            {
            Dictionary<string, object> cosmosdic = new Dictionary<string, object>();
            try
                {
                foreach (var item in destination)
                    {
                    if (item.Value != null)
                        {
                        if (source.ContainsKey(item.Value.ToString()))
                            {
                            if (item.Key.ToString().StartsWith("ddl") && source[item.Value.ToString()] != null && item.Key.ToString().ToLower() != "ddlcimcasenumber")
                                {
                                //try
                                //{
                                cosmosdic.Add(item.Key.ToString(), source[item.Value.ToString()].ToString());
                                //}
                                //catch { }
                                }
                            else if ((item.Key.ToString().StartsWith("dt") || item.Key.ToString().Contains("T00:00:00")) && source[item.Value.ToString()] != null)
                                {
                                string formatedDate = ConvertDateType(source[item.Value.ToString()].ToString());
                                if (formatedDate.Contains("0001-01-01"))
                                    {
                                    cosmosdic.Add(item.Key.ToString(), "");
                                    }
                                else
                                    {
                                    cosmosdic.Add(item.Key.ToString(), formatedDate);
                                    }
                                }
                            else if (item.Key.ToString() == "ddlNumberOfComponents")
                                {
                                cosmosdic.Add(item.Key.ToString(), Convert.ToString(source[item.Value.ToString()]) == "" ? Convert.ToString(totalNumberOfComponentInSkiipack) : source[item.Value.ToString()]);
                                }
                            else if (item.Key.ToString() == "chkInsulationComments")
                                {
                                cosmosdic.Add(item.Key.ToString(), (Convert.ToBoolean(source[item.Value.ToString()]) == true ? false : true));
                                }
                            else
                                {
                                cosmosdic.Add(item.Key.ToString(), source[item.Value.ToString()]);
                                }
                            }
                        else
                            {
                            cosmosdic.Add(item.Key.ToString(), "");
                            }
                        }
                    else
                        {
                        cosmosdic.Add(item.Key.ToString(), "");
                        }
                    }
                }
            //Added throw to handle exception in calling method
            catch (Exception) { throw; }
            return cosmosdic;
            }

        public static void RemoveFlange(Dictionary<string, object> cosmosdic)
            {
            bool val = Convert.ToBoolean(cosmosdic["chkDamageIdentifiedSimplifiedFlange1"]);
            bool val1 = Convert.ToBoolean(cosmosdic["chkDamageIdentifiedSimplifiedFlange2"]);
            bool val2 = Convert.ToBoolean(cosmosdic["chkDamageIdentifiedSimplifiedFlange3"]);
            bool val3 = Convert.ToBoolean(cosmosdic["chkDamageIdentifiedSimplifiedFlange4"]);
            bool val4 = Convert.ToBoolean(cosmosdic["chkDamageIdentifiedSimplifiedFlange5"]);
            bool val5 = Convert.ToBoolean(cosmosdic["chkDamageIdentifiedSimplifiedFlange6"]);

            if (val == false)
                {
                cosmosdic.Remove("txtCrackedPaint-Flange1"); cosmosdic.Remove("txtSignofserviceloosebolts-Flange1"); cosmosdic.Remove("txtWateringressbetweenflanges-Flange1"); cosmosdic.Remove("txtWateringressonboltheads-Flange1");
                cosmosdic.Remove("txtObviousloosebolts-Flange1"); cosmosdic.Remove("txtInspectionDescription-Flange1"); cosmosdic.Remove("ddlDecision-Flange1"); cosmosdic.Remove("ddlRepeatedinspection-Flange1");
                cosmosdic.Remove("chkReplaceaffectedBolts-Flange1"); cosmosdic.Remove("ddlBoltmanufacture-Flange1"); cosmosdic.Remove("ddlBoltsizeMxx-Flange1"); cosmosdic.Remove("txtVUIBoltplate-Flange1"); cosmosdic.Remove("txtBrokenbolts-Flange1"); cosmosdic.Remove("ddlMovingFlanges-Flange1"); cosmosdic.Remove("txtSealantingres-Flange1");
                cosmosdic.Remove("txtMetallizationdust-Flange1"); cosmosdic.Remove("txtOutsideSigns-Flange1"); cosmosdic.Remove("ddlCorrosionmarksonplatform-Flange1"); cosmosdic.Remove("imageUploader-Flange1");
                }
            if (val1 == false)
                {
                cosmosdic.Remove("txtCrackedPaint-Flange2"); cosmosdic.Remove("txtSignofserviceloosebolts-Flange2"); cosmosdic.Remove("txtWateringressbetweenflanges-Flange2"); cosmosdic.Remove("txtWateringressonboltheads-Flange2");
                cosmosdic.Remove("txtObviousloosebolts-Flange2"); cosmosdic.Remove("txtInspectionDescription-Flange2"); cosmosdic.Remove("ddlDecision-Flange2"); cosmosdic.Remove("ddlRepeatedinspection-Flange2");
                cosmosdic.Remove("chkReplaceaffectedBolts-Flange2"); cosmosdic.Remove("ddlBoltmanufacture-Flange2"); cosmosdic.Remove("ddlBoltsizeMxx-Flange2"); cosmosdic.Remove("txtVUIBoltplate-Flange2"); cosmosdic.Remove("txtBrokenbolts-Flange2"); cosmosdic.Remove("ddlMovingFlanges-Flange2"); cosmosdic.Remove("txtSealantingres-Flange2");
                cosmosdic.Remove("txtMetallizationdust-Flange2"); cosmosdic.Remove("txtOutsideSigns-Flange2"); cosmosdic.Remove("ddlCorrosionmarksonplatform-Flange2"); cosmosdic.Remove("imageUploader-Flange2");
                }
            if (val2 == false)
                {
                cosmosdic.Remove("txtCrackedPaint-Flange3"); cosmosdic.Remove("txtSignofserviceloosebolts-Flange3"); cosmosdic.Remove("txtWateringressbetweenflanges-Flange3"); cosmosdic.Remove("txtWateringressonboltheads-Flange3");
                cosmosdic.Remove("txtObviousloosebolts-Flange3"); cosmosdic.Remove("txtInspectionDescription-Flange3"); cosmosdic.Remove("ddlDecision-Flange3"); cosmosdic.Remove("ddlRepeatedinspection-Flange3");
                cosmosdic.Remove("chkReplaceaffectedBolts-Flange3"); cosmosdic.Remove("ddlBoltmanufacture-Flange3"); cosmosdic.Remove("ddlBoltsizeMxx-Flange3"); cosmosdic.Remove("txtVUIBoltplate-Flange3"); cosmosdic.Remove("txtBrokenbolts-Flange3"); cosmosdic.Remove("ddlMovingFlanges-Flange3"); cosmosdic.Remove("txtSealantingres-Flange3");
                cosmosdic.Remove("txtMetallizationdust-Flange3"); cosmosdic.Remove("txtOutsideSigns-Flange3"); cosmosdic.Remove("ddlCorrosionmarksonplatform-Flange3"); cosmosdic.Remove("imageUploader-Flange3");
                }
            if (val3 == false)
                {
                cosmosdic.Remove("txtCrackedPaint-Flange4"); cosmosdic.Remove("txtSignofserviceloosebolts-Flange4"); cosmosdic.Remove("txtWateringressbetweenflanges-Flange4"); cosmosdic.Remove("txtWateringressonboltheads-Flange4");
                cosmosdic.Remove("txtObviousloosebolts-Flange4"); cosmosdic.Remove("txtInspectionDescription-Flange4"); cosmosdic.Remove("ddlDecision-Flange4"); cosmosdic.Remove("ddlRepeatedinspection-Flange4");
                cosmosdic.Remove("chkReplaceaffectedBolts-Flange4"); cosmosdic.Remove("ddlBoltmanufacture-Flange4"); cosmosdic.Remove("ddlBoltsizeMxx-Flange4"); cosmosdic.Remove("txtVUIBoltplate-Flange4"); cosmosdic.Remove("txtBrokenbolts-Flange4"); cosmosdic.Remove("ddlMovingFlanges-Flange4"); cosmosdic.Remove("txtSealantingres-Flange4");
                cosmosdic.Remove("txtMetallizationdust-Flange4"); cosmosdic.Remove("txtOutsideSigns-Flange4"); cosmosdic.Remove("ddlCorrosionmarksonplatform-Flange4"); cosmosdic.Remove("imageUploader-Flange4");
                }
            if (val4 == false)
                {
                cosmosdic.Remove("txtCrackedPaint-Flange5"); cosmosdic.Remove("txtSignofserviceloosebolts-Flange5"); cosmosdic.Remove("txtWateringressbetweenflanges-Flange5"); cosmosdic.Remove("txtWateringressonboltheads-Flange5");
                cosmosdic.Remove("txtObviousloosebolts-Flange5"); cosmosdic.Remove("txtInspectionDescription-Flange5"); cosmosdic.Remove("ddlDecision-Flange5"); cosmosdic.Remove("ddlRepeatedinspection-Flange5");
                cosmosdic.Remove("chkReplaceaffectedBolts-Flange5"); cosmosdic.Remove("ddlBoltmanufacture-Flange5"); cosmosdic.Remove("ddlBoltsizeMxx-Flange5"); cosmosdic.Remove("txtVUIBoltplate-Flange5"); cosmosdic.Remove("txtBrokenbolts-Flange5"); cosmosdic.Remove("ddlMovingFlanges-Flange5"); cosmosdic.Remove("txtSealantingres-Flange5");
                cosmosdic.Remove("txtMetallizationdust-Flange5"); cosmosdic.Remove("txtOutsideSigns-Flange5"); cosmosdic.Remove("ddlCorrosionmarksonplatform-Flange5"); cosmosdic.Remove("imageUploader-Flange5");
                }
            if (val5 == false)
                {
                cosmosdic.Remove("txtCrackedPaint-Flange6"); cosmosdic.Remove("txtSignofserviceloosebolts-Flange6"); cosmosdic.Remove("txtWateringressbetweenflanges-Flange6"); cosmosdic.Remove("txtWateringressonboltheads-Flange6");
                cosmosdic.Remove("txtObviousloosebolts-Flange6"); cosmosdic.Remove("txtInspectionDescription-Flange6"); cosmosdic.Remove("ddlDecision-Flange6"); cosmosdic.Remove("ddlRepeatedinspection-Flange6");
                cosmosdic.Remove("chkReplaceaffectedBolts-Flange6"); cosmosdic.Remove("ddlBoltmanufacture-Flange6"); cosmosdic.Remove("ddlBoltsizeMxx-Flange6"); cosmosdic.Remove("txtVUIBoltplate-Flange6"); cosmosdic.Remove("txtBrokenbolts-Flange6"); cosmosdic.Remove("ddlMovingFlanges-Flange6"); cosmosdic.Remove("txtSealantingres-Flange6");
                cosmosdic.Remove("txtMetallizationdust-Flange6"); cosmosdic.Remove("txtOutsideSigns-Flange6"); cosmosdic.Remove("ddlCorrosionmarksonplatform-Flange6"); cosmosdic.Remove("imageUploader-Flange6");
                }
            }
        public static string getValue(int inputValue)
            {

            string outputValue = string.Empty;
            switch (inputValue)
                {
                case 1:
                    outputValue = "Cooper & Turner";
                    break;
                case 22:
                    outputValue = "Full Flange repair solution";
                    break;
                case 23:
                    outputValue = "Single bolt replacement";
                    break;
                case 24:
                    outputValue = "CIM Implementation Decision";
                    break;
                case 28:
                    outputValue = "Bi-weekly";
                    break;
                case 30:
                    outputValue = "Bi-monthly";
                    break;
                case 31:
                    outputValue = "Half yearly";
                    break;
                case 10:
                    outputValue = "Other";
                    break;
                default:
                    outputValue = "N/A";
                    break;

                }
            return outputValue;

            }

        public static Dictionary<string, object> MergeCollection(Dictionary<string, object> source, string reportType)
            {
            Dictionary<string, object> sourceClone = new Dictionary<string, object>();
            try
                {
                sourceClone = RecursiveFun(source, reportType, sourceClone);
                foreach (KeyValuePair<string, object> item in sourceClone)
                    {
                    if (!source.ContainsKey(item.Key))
                        {
                        source.Add(item.Key, item.Value);
                        }
                    }
                }
            catch { }
            return source;
            }

        private static Dictionary<string, object> RecursiveFun(Dictionary<string, object> source, string reportType, Dictionary<string, object> sourceClone)
            {
            try
                {
                foreach (KeyValuePair<string, object> item in source)
                    {
                    if (item.Value is ICollection)
                        {
                        if (((item.Key.ToLower() == "skiip" || item.Key.ToLower() == "skiipfailedcomp" || item.Key.ToLower() == "skiipnewcomp") && reportType.ToLower() == "skiipack")
                            || item.Key.ToLower() == "turbinedata"
                            || (reportType.ToLower() == "blade" && item.Key.ToLower() == "bladedata")
                            || (reportType.ToLower() == item.Key.ToLower())
                            || item.Key.ToLower() == "imagedatainfo")
                            {
                            var sqlJson = JsonConvert.SerializeObject(item.Value);
                            //sqlJson = sqlJson.Replace("[", "{ '" + item.Key + "': [ ").Replace("]", "]}");
                            Dictionary<string, object> SQLDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(sqlJson);
                            foreach (KeyValuePair<string, object> item2 in SQLDictionary)
                                {
                                if (item2.Value is ICollection)
                                    {
                                    try
                                        {
                                        if (item2.Key == "SkiipNewComp")
                                            {
                                            var sqlChildJson = JsonConvert.SerializeObject(item2.Value);
                                            int counter = 1;
                                            StringBuilder objBuiler = new StringBuilder();
                                            objBuiler.Append("[");
                                            // \"NewModule1SerialNumber\": \"SkiiPNewComponentSerialNumber\",\"NewModule1VestasUniqueIdentifier\": \"SkiiPNewComponentVestasUniqueIdentifier\",\"NewModule1ItemNo\": \"SkiiPNewComponentVestasItemNumber\", 
                                            //\"ComponentId1SerialNumber\": \"SkiiPFailedComponentSerialNumber\",\"ComponentId1VestasUniqueIdentifier\": \"SkiiPFailedComponentVestasUniqueIdentifier\",\"ComponentId1ItemNo\": \"SkiiPFailedComponentVestasItemNumber\",
                                            dynamic dynJson = JsonConvert.DeserializeObject(sqlChildJson);
                                            foreach (var items in dynJson)
                                                {
                                                if (counter == 1)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"NewModule1SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"NewModule1ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"NewModule1VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 2)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"NewModule2SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"NewModule2ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"NewModule2VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 3)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"NewModule3SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"NewModule3ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"NewModule3VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 4)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"NewModule4SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"NewModule4ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"NewModule4VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 5)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"NewModule5SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"NewModule5ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"NewModule5VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 6)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"NewModule6SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"NewModule6ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"NewModule6VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 7)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"NewModule7SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"NewModule7ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"NewModule7VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 8)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"NewModule8SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"NewModule8ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"NewModule8VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 9)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"NewModule9SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"NewModule9ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"NewModule9VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }

                                                counter++;
                                                }
                                            totalNumberOfComponentInSkiipack = counter - 1;
                                            objBuiler.Append("]");
                                            objBuiler.Replace("[", "{").Replace(", ]", "}").Replace(",]", "}");
                                            sqlChildJson = "";
                                            sqlChildJson = objBuiler.ToString();
                                            // sqlChildJson = sqlChildJson.Replace("{", "").Replace("}", "").Replace("[", "{").Replace(",]", "}").Replace(", ]", "}");
                                            Dictionary<string, object> SQLChildDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(sqlChildJson);
                                            RecursiveFun(SQLChildDictionary, reportType, sourceClone);
                                            }
                                        else if (item2.Key == "SkiipFailedComp")
                                            {
                                            var sqlChildJson = JsonConvert.SerializeObject(item2.Value);
                                            int counter = 1;
                                            StringBuilder objBuiler = new StringBuilder();
                                            objBuiler.Append("[");
                                            // \"NewModule1SerialNumber\": \"SkiiPNewComponentSerialNumber\",\"NewModule1VestasUniqueIdentifier\": \"SkiiPNewComponentVestasUniqueIdentifier\",\"NewModule1ItemNo\": \"SkiiPNewComponentVestasItemNumber\", 
                                            //\"ComponentId1SerialNumber\": \"SkiiPFailedComponentSerialNumber\",\"ComponentId1VestasUniqueIdentifier\": \"SkiiPFailedComponentVestasUniqueIdentifier\",\"ComponentId1ItemNo\": \"SkiiPFailedComponentVestasItemNumber\",
                                            dynamic dynJson = JsonConvert.DeserializeObject(sqlChildJson);
                                            foreach (var items in dynJson)
                                                {
                                                if (counter == 1)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"ComponentId1SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"ComponentId1ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"ComponentId1VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 2)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"ComponentId2SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"ComponentId2ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"ComponentId2VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 3)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"ComponentId3SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"ComponentId3ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"ComponentId3VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 4)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"ComponentId4SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"ComponentId4ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"ComponentId4VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 5)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"ComponentId5SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"ComponentId5ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"ComponentId5VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 6)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"ComponentId6SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"ComponentId6ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"ComponentId6VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 7)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"ComponentId7SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"ComponentId7ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"ComponentId7VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 8)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"ComponentId8SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"ComponentId8ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"ComponentId8VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }
                                                else if (counter == 9)
                                                    {
                                                    int innerCounter = 0;
                                                    foreach (var skipField in items)
                                                        {
                                                        innerCounter++;
                                                        if (innerCounter == 3)
                                                            {

                                                            objBuiler.Append("\"ComponentId9SerialNumber\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 4)
                                                            {

                                                            objBuiler.Append("\"ComponentId9ItemNo\" :\"" + skipField.Value + "\",");
                                                            }
                                                        else if (innerCounter == 5)
                                                            {

                                                            objBuiler.Append("\"ComponentId9VestasUniqueIdentifier\" :\"" + skipField.Value + "\",");
                                                            }
                                                        }
                                                    }

                                                counter++;
                                                }
                                            objBuiler.Append("]");
                                            objBuiler.Replace("[", "{").Replace(", ]", "}").Replace(",]", "}");
                                            sqlChildJson = "";
                                            sqlChildJson = objBuiler.ToString();
                                            //sqlChildJson = sqlChildJson.Replace("{", "").Replace("}", "").Replace("[", "{").Replace(",]", "}").Replace(", ]", "}");
                                            Dictionary<string, object> SQLChildDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(sqlChildJson);
                                            RecursiveFun(SQLChildDictionary, reportType, sourceClone);
                                            }
                                        else
                                            {
                                            var sqlChildJson = JsonConvert.SerializeObject(item2.Value);
                                            sqlChildJson = sqlChildJson.Replace("[", "").Replace("]", "");
                                            Dictionary<string, object> SQLChildDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(sqlChildJson);
                                            RecursiveFun(SQLChildDictionary, reportType, sourceClone);
                                            }
                                        //sqlChildJson = sqlChildJson.Replace("{","").Replace("}","").Replace("[", "{").Replace("]", "}");

                                        // dynJson = JsonConvert.DeserializeObject(sqlChildJson);
                                        //foreach (var items in dynJson)
                                        //{
                                        //    counter++;

                                        //    //Console.WriteLine("{0} {1} {2} {3}\n", items.ComponentInspectionReportSkiiPFailedComponentId, items.displayName,
                                        //    //    items.slug, items.imageUrl);
                                        //}
                                        //sqlChildJson = sqlChildJson.Replace("[", "{ '" + item2.Key + "': [ ").Replace("]", "]}");
                                        //Dictionary<string, object> SQLChildDictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(sqlChildJson);
                                        ////Dictionary<string, object> SQLChildDictionary = (Dictionary < string, object>) item2.Value;
                                        //RecursiveFun(SQLChildDictionary, reportType, sourceClone);

                                        }
                                    catch (Exception e) { }
                                    }
                                else
                                    {
                                    if (!sourceClone.ContainsKey(item2.Key))
                                        {
                                        sourceClone.Add(item2.Key, item2.Value);
                                        }
                                    }
                                }
                            }
                        }
                    else
                        {
                        if (!sourceClone.ContainsKey(item.Key))
                            {
                            sourceClone.Add(item.Key, item.Value);
                            }
                        }
                    }
                }
            catch (Exception ex)
                { }
            return sourceClone;
            }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="srcString"></param>
        /// <returns></returns>
        public static string ConvertDateType(string srcString)
            {
            // var dateString = Convert.ToDateTime(srcString).ToString("yyyy/MM/ddThh:mm:ss");
            var dateString = Convert.ToDateTime(srcString).ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
            return dateString.ToString();
            }
        public static bool IsNumeric(string input)
            {
            int value;
            return int.TryParse(input, out value);
            }
        }
    public class FlangeArray
        {
        public int FlangeNo { get; set; }
        public bool FlangeDamageIdentified { get; set; }
        public int RepeatedInspections { get; set; }

        public int AffectedBolts { get; set; }
        public int DecisionFlange { get; set; }
        public string InspectionDescription { get; set; }



        }
    }
