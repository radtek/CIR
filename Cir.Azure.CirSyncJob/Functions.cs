using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using System.Data.SqlClient;
using System.Data;
using System;
using Newtonsoft.Json;
using Cir.Azure.MobileApp.Service.CirSyncService;
using Cir.Azure.MobileApp.Service.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Cir.Azure.MobileApp.Service.Utilities;
using Cir.Azure.MobileApp.Service.Controllers;

namespace Cir.Azure.CirSyncJob
{
    public class Functions
    {
        // This function will be triggered based on the schedule you have set for this WebJob
        // This function will enqueue a message on an Azure Queue called queue
        [NoAutomaticTrigger]
        public static void ManualTrigger(TextWriter log, int value, [Queue("queue")] out string message)
        {
            //  string str = "{\"componentInspectionReportId\":\"278488\",\"componentInspectionReportTypeId\":\"2\",\"componentInspectionReportName\":\"Denmark_Gearbox_W3700_2016-07-29_1\",\"componentInspectionReportStateId\":1,\"cirDataID\":\"405275\",\"reportTypeId\":\"2\",\"reconstructionBooleanAnswerId\":1,\"cimCaseNumber\":\"1\",\"reasonForService\":\"11\",\"turbineNumber\":\"50875\",\"country\":\"Denmark\",\"siteName\":\"Bogøinddæmning 1-4\",\"turbineType\":\"W3700\",\"beforeInspectionTurbineRunStatusId\":\"1\",\"commisioningDate\":\"29-07-2016\",\"strCommisioningDate\":\"29-07-2016\",\"installationDate\":\"29-07-2016\",\"strInstallationDate\":\"29-07-2016\",\"failureDate\":\"29-07-2016\",\"strFailureDate\":\"29-07-2016\",\"inspectionDate\":\"29-07-2016\",\"strInspectionDate\":\"29-07-2016\",\"serviceReportNumber\":\"1\",\"serviceReportNumberTypeId\":\"3\",\"serviceEngineer\":\"mukes\",\"notificationNumber\":\"1\",\"runHours\":\"1\",\"generator1Hrs\":\"1\",\"totalProduction\":\"1\",\"afterInspectionTurbineRunStatusId\":\"6\",\"vestasItemNumber\":\"111\",\"quantity\":\"1\",\"description\":\"1\",\"descriptionConsquential\":\"\",\"additionalInfo\":\"\",\"sBURecommendation\":\"\",\"alarmLogNumber\":\"0\",\"conductedBy\":1,\"sBUId\":1,\"cIRTemplateGUID\":\"\",\"locationTypeId\":6,\"mountedOnMainComponentBooleanAnswerId\":1,\"templateVersion\":\"7\",\"currentUser\":\"JUJEH_vestas.com#EXT#@VestasTest1.onmicrosoft.com\",\"generator\":{},\"mainBearing\":{},\"gearbox\":{\"componentInspectionReportGearboxId\":\"0\",\"componentInspectionReportId\":\"278488\",\"vestasUniqueIdentifier\":\"111\",\"gearboxManufacturerId\":\"11\",\"gearboxOtherManufacturer\":\"1\",\"gearboxTypeId\":\"109\",\"otherGearboxType\":\"sdfdsf\",\"gearboxRevisionId\":\"18\",\"gearboxSerialNumber\":\"3434\",\"gearboxLastOilChangeDate\":\"2016-07-29\",\"strGearboxLastOilChangeDate\":\"2016-07-29\",\"gearboxOilTypeId\":\"9\",\"gearboxMechanicalOilPumpId\":\"1\",\"gearboxOilLevelId\":\"12\",\"gearboxAuxEquipmentId\":\"1\",\"gearboxActionToBeTakenOnGearboxId\":\"3\",\"gearboxRunHours\":\"34\",\"gearboxOilTemperature\":\"3\",\"gearboxProduction\":\"\",\"gearboxGeneratorManufacturerId\":\"\",\"gearboxGeneratorManufacturerId2\":\"\",\"gearboxElectricalPumpId\":\"\",\"gearboxShrinkElementId\":\"\",\"gearboxShrinkElementSerialNumber\":\"\",\"gearboxCouplingId\":\"\",\"gearboxFilterBlockTypeId\":\"\",\"gearboxInLineFilterId\":\"\",\"gearboxOffLineFilterId\":\"1\",\"gearboxSoftwareRelease\":\"\",\"gearboxShaftsExactLocation1ShaftTypeId\":\"\",\"gearboxShaftsTypeofDamage1ShaftErrorId\":\"\",\"gearboxShaftsExactLocation2ShaftTypeId\":\"\",\"gearboxShaftsTypeofDamage2ShaftErrorId\":\"\",\"gearboxShaftsExactLocation3ShaftTypeId\":\"\",\"gearboxShaftsTypeofDamage3ShaftErrorId\":\"\",\"gearboxShaftsExactLocation4ShaftTypeId\":\"\",\"gearboxShaftsTypeofDamage4ShaftErrorId\":\"\",\"gearboxExactLocation1GearTypeId\":\"30\",\"gearboxExactLocation2GearTypeId\":\"6\",\"gearboxExactLocation3GearTypeId\":\"8\",\"gearboxExactLocation4GearTypeId\":\"9\",\"gearboxExactLocation5GearTypeId\":\"12\",\"gearboxExactLocation6GearTypeId\":\"11\",\"gearboxExactLocation7GearTypeId\":\"23\",\"gearboxExactLocation8GearTypeId\":\"22\",\"gearboxExactLocation9GearTypeId\":\"21\",\"gearboxExactLocation10GearTypeId\":\"1\",\"gearboxExactLocation11GearTypeId\":\"\",\"gearboxExactLocation12GearTypeId\":\"\",\"gearboxExactLocation13GearTypeId\":\"\",\"gearboxExactLocation14GearTypeId\":\"\",\"gearboxExactLocation15GearTypeId\":\"\",\"gearboxTypeofDamage1GearErrorId\":\"1\",\"gearboxTypeofDamage2GearErrorId\":\"1\",\"gearboxTypeofDamage3GearErrorId\":\"1\",\"gearboxTypeofDamage4GearErrorId\":\"1\",\"gearboxTypeofDamage5GearErrorId\":\"1\",\"gearboxTypeofDamage6GearErrorId\":\"1\",\"gearboxTypeofDamage7GearErrorId\":\"1\",\"gearboxTypeofDamage8GearErrorId\":\"1\",\"gearboxTypeofDamage9GearErrorId\":\"1\",\"gearboxTypeofDamage10GearErrorId\":\"1\",\"gearboxTypeofDamage11GearErrorId\":\"\",\"gearboxTypeofDamage12GearErrorId\":\"\",\"gearboxTypeofDamage13GearErrorId\":\"\",\"gearboxTypeofDamage14GearErrorId\":\"\",\"gearboxTypeofDamage15GearErrorId\":\"\",\"gearboxGearDecision1DamageDecisionId\":\"1\",\"gearboxGearDecision2DamageDecisionId\":\"1\",\"gearboxGearDecision3DamageDecisionId\":\"1\",\"gearboxGearDecision4DamageDecisionId\":\"1\",\"gearboxGearDamageClass1DamageId\":\"2\",\"gearboxGearDamageClass2DamageId\":\"2\",\"gearboxGearDamageClass3DamageId\":\"2\",\"gearboxGearDamageClass4DamageId\":\"2\",\"gearboxGearDamageClass5DamageId\":\"2\",\"gearboxGearDamageClass6DamageId\":\"2\",\"gearboxGearDamageClass7DamageId\":\"2\",\"gearboxGearDamageClass8DamageId\":\"2\",\"gearboxGearDamageClass9DamageId\":\"2\",\"gearboxGearDamageClass10DamageId\":\"2\",\"gearboxGearDecision5DamageDecisionId\":\"1\",\"gearboxGearDecision6DamageDecisionId\":\"1\",\"gearboxGearDecision7DamageDecisionId\":\"1\",\"gearboxGearDecision8DamageDecisionId\":\"1\",\"gearboxBearingsLocation1BearingTypeId\":\"7\",\"gearboxBearingsLocation2BearingTypeId\":\"6\",\"gearboxBearingsLocation3BearingTypeId\":\"\",\"gearboxBearingsLocation4BearingTypeId\":\"\",\"gearboxBearingsLocation5BearingTypeId\":\"\",\"gearboxBearingsLocation6BearingTypeId\":\"\",\"gearboxBearingsPosition1BearingPosId\":\"2\",\"gearboxBearingsPosition2BearingPosId\":\"2\",\"gearboxBearingsPosition3BearingPosId\":\"\",\"gearboxBearingsPosition4BearingPosId\":\"\",\"gearboxBearingsPosition5BearingPosId\":\"\",\"gearboxBearingsPosition6BearingPosId\":\"\",\"gearboxBearingsDamage1BearingErrorId\":\"10\",\"gearboxBearingsDamage2BearingErrorId\":\"11\",\"gearboxBearingsDamage3BearingErrorId\":\"\",\"gearboxBearingsDamage4BearingErrorId\":\"\",\"gearboxBearingsDamage5BearingErrorId\":\"\",\"gearboxBearingsDamage6BearingErrorId\":\"\",\"gearboxBearingDecision1DamageDecisionId\":\"1\",\"gearboxBearingDecision2DamageDecisionId\":\"1\",\"gearboxPlanetStage1HousingErrorId\":\"\",\"gearboxPlanetStage2HousingErrorId\":\"\",\"gearboxHelicalStageHousingErrorId\":\"\",\"gearboxFrontPlateHousingErrorId\":\"\",\"gearboxAuxStageHousingErrorId\":\"\",\"gearboxHSStageHousingErrorId\":\"\",\"gearboxLooseBolts\":false,\"gearboxBrokenBolts\":false,\"gearboxDefectDamperElements\":false,\"gearboxTooMuchClearance\":false,\"gearboxCrackedTorqueArm\":false,\"gearboxNeedsToBeAligned\":false,\"gearboxPT100Bearing1\":false,\"gearboxPT100Bearing2\":false,\"gearboxOilLevelSensor\":false,\"gearboxOilPressure\":false,\"gearboxPT100OilSump\":false,\"gearboxFilterIndicator\":false,\"gearboxImmersionHeater\":false,\"gearboxDrainValve\":false,\"gearboxAirBreather\":false,\"gearboxSightGlass\":false,\"gearboxChipDetector\":false,\"gearboxVibrationsId\":\"1\",\"gearboxNoiseId\":\"2\",\"gearboxDebrisOnMagnetId\":\"1\",\"gearboxDebrisStagesMagnetPosId\":\"5\",\"gearboxDebrisGearBoxId\":\"2\",\"gearboxOverallGearboxConditionId\":\"2\",\"gearboxMaxTempResetDate\":\"\",\"gearboxTempBearing1\":\"\",\"gearboxTempBearing2\":\"\",\"gearboxTempBearing3\":\"\",\"gearboxTempOilSump\":\"\",\"gearboxLSSNRend\":false,\"gearboxIMSNRend\":false,\"gearboxIMSRend\":false,\"gearboxHSSNRend\":false,\"gearboxHSSRend\":false,\"gearboxPitchTube\":false,\"gearboxSplitLines\":false,\"gearboxHoseAndPiping\":false,\"gearboxInputShaft\":false,\"gearboxHSSPTO\":false,\"gearboxDefectCategorizationScore\":\"A\"},\"skiip\":{},\"transformer\":{},\"bladeData\":{},\"general\":{},\"imageData\":[],\"imageDataInfo\":{\"IsPlateTypeNotPossible\":true,\"PlateTypeNotPossibleReason\":\"fdgfdgfdg\"},\"dynamicTableInputs\":{\"id\":\"0\",\"cirId\":\"278488\",\"row1Col1\":\"\",\"row1Col2\":\"\",\"row1Col3\":\"\",\"row1Col4\":\"\",\"row2Col1\":\"\",\"row2Col2\":\"\",\"row2Col3\":\"\",\"row2Col4\":\"\",\"row3Col1\":\"\",\"row3Col2\":\"\",\"row3Col3\":\"\",\"row3Col4\":\"\",\"row4Col1\":\"\",\"row4Col2\":\"\",\"row4Col3\":\"\",\"row4Col4\":\"\",\"row5Col1\":\"\",\"row5Col2\":\"\",\"row5Col3\":\"\",\"row5Col4\":\"\",\"row6Col1\":\"\",\"row6Col2\":\"\",\"row6Col3\":\"\",\"row6Col4\":\"\",\"row7Col1\":\"\",\"row7Col2\":\"\",\"row7Col3\":\"\",\"row7Col4\":\"\",\"row8Col1\":\"\",\"row8Col2\":\"\",\"row8Col3\":\"\",\"row8Col4\":\"\",\"row9Col1\":\"\",\"row9Col2\":\"\",\"row9Col3\":\"\",\"row9Col4\":\"\",\"row10Col1\":\"\",\"row10Col2\":\"\",\"row10Col3\":\"\",\"row10Col4\":\"\"},\"turbineData\":{\"turbineCountry\":\"\",\"turbineSite\":\"\",\"rotorDiameter\":\"37\",\"nominelPower\":\"500\",\"voltage\":\"690\",\"powerRegulation\":\"\",\"frequency\":\"50\",\"smallGenerator\":\"0\",\"temperatureVariant\":\"STD\",\"markVersion\":\"MK-\",\"placement\":\"Onshore\",\"manufacturer\":\"Wind World\",\"localTurbineId\":\"0003\"}}";
            //   var Cir1 = JsonConvert.DeserializeObject<ComponentInspectionReport>(str, new CirJsonDateTimeConverter());
            //// log.WriteLine("Function is invoked with value={0}", value);
            message = value.ToString();
            //log.WriteLine("Following message will be written on the Queue={0}", message);
            log.WriteLine("SyncJob v2");
            log.WriteLine("SyncJob Started at " + System.DateTime.Now);

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MS_TableConnectionString"].ConnectionString;
            string schemaname = System.Configuration.ConfigurationManager.AppSettings["MS_MobileServiceName"];
            log.WriteLine("SyncJob v1 schemaname: " + schemaname);
            DataSet dsUserCirData = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string queryString = "SELECT TOP 30 * INTO #userData  FROM [" + schemaname + "].[UserCirDatas] WHERE Status = 2 AND [Deleted] = 0; UPDATE [" + schemaname + "].[UserCirDatas] SET Status = 5 WHERE Id IN (SELECT Id FROM #userData); SELECT * FROM #userData";
                    SqlDataAdapter adapter = new SqlDataAdapter(queryString, con);

                    adapter.Fill(dsUserCirData, "CirUserData");
                    log.WriteLine(dsUserCirData.Tables["CirUserData"].Rows.Count + " records selected at " + System.DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                log.WriteLine("error " + ex.Message + "Details : " + ex.StackTrace);
            }
            if (dsUserCirData.Tables.Count > 0)
            {
                var Service = new Cir.Azure.MobileApp.Service.Utilities.SyncServiceUtilities(System.Configuration.ConfigurationManager.AppSettings["Cir_Sync_Service_Url"]);
                //vestascirmobileappContext context = new vestascirmobileappContext();
                string updateSql = String.Empty;
                SqlCommand oCmd = null;
                foreach (DataRow rw in dsUserCirData.Tables["CirUserData"].Rows)
                {
                    updateSql = "UPDATE [" + schemaname + "].[UserCirDatas] SET Status = @Status, CirStatus = @CirStatus, StatusMessage = @StatusMessage, StatusDetailMessage = @StatusDetailMessage, CirDataLocalID = @CirDataLocalID, CirData = @CirData, RowVersion = @RowVersion WHERE Id = @Id";
                    oCmd = new SqlCommand(updateSql);
                    try
                    {
                        log.WriteLine("Started : id = " + rw["Id"].ToString());
                        bool Approve = false;
                        Int32 CirStatus = 0;
                        if (rw["CirStatus"] != null && rw["CirStatus"] != DBNull.Value && Int32.TryParse(rw["CirStatus"].ToString(), out CirStatus))
                        {
                            Approve = (CirStatus == 10) ? true : false;
                        }
                        ComponentInspectionReport Cir = null;
                        Cir = JsonConvert.DeserializeObject<ComponentInspectionReport>(rw["CirData"].ToString(), new CirJsonDateTimeConverter());

                        long turbineid = 0;
                        turbineid = Cir.TurbineNumber;
                        log.WriteLine("Cirid = " + rw["CirDataLocalID"].ToString());
                        log.WriteLine("Cirid = " + Cir.ComponentInspectionReportId.ToString());
                        Cir.CurrentUser = rw["UpdateBy"].ToString().Split('@')[0];
                        log.WriteLine("User = " + Cir.CurrentUser);
                        var oResponse = Service.SaveCir(Cir);
                        if (oResponse.Status == true)
                        {
                            log.WriteLine("CIR ID = " + oResponse.CirID + " Cir Synced Successfully!");
                           // Task.Run(() =>
                           // {
                               if (Approve)
                               {
                                   try
                                   {
                                       //AuthenticationUtilities au = new AuthenticationUtilities(new CirProcessController());
                                       //string[] AppRoles = au.GetAppRolesAssignmentArray(rw["UserInitial"].ToString());
                                       //bool hasaccess = UserPermission.ApproveCir(AppRoles);
                                       //if (hasaccess == true)
                                       //{
                                           CirDataDetail cirDataDetail = new CirDataDetail();
                                           cirDataDetail.PdfDataUri = "";
                                           cirDataDetail.CIMCaseNumber = "";
                                           cirDataDetail.CirDataId = oResponse.CirDataId;
                                           cirDataDetail.CirId = oResponse.CirID.ToString();
                                           cirDataDetail.CirState = 1;
                                           cirDataDetail.comment = "Approved by " + Cir.CurrentUser;
                                           cirDataDetail.ComponentType = "";
                                           cirDataDetail.Filename = "";
                                           cirDataDetail.Locked = 1;
                                           cirDataDetail.LockedBy = Cir.CurrentUser;
                                           cirDataDetail.modifiedBy = Cir.CurrentUser;
                                           cirDataDetail.Progress = 2;
                                           cirDataDetail.ReportType = "";
                                           cirDataDetail.TurbineNumber = "";
                                           cirDataDetail.TurbineType = "";
                                           var oApproveResponse = Service.CirProcess(cirDataDetail);

                                           if (oApproveResponse.error >= 1)
                                           {
                                               log.WriteLine("CIR ID = " + oResponse.CirID + " Cir Approve Error! Details:" + oApproveResponse.message);
                                           }
                                           log.WriteLine("CIR ID = " + oResponse.CirID + " CIR has been approved!!");
                                       //}
                                       //else
                                       //{
                                       //    log.WriteLine("CIR ID = " + oResponse.CirID + " Cir Approve Error! Details:" + "Unauthorized");
                                       //}

                                   }
                                   catch (Exception ex)
                                   {
                                       log.WriteLine("CIR ID = " + oResponse.CirID + " Cir Approve Error! Details:" + ex.Message);
                                   }
                               }
                          // });
                            Cir = new ComponentInspectionReport();
                            // log.WriteLine("CIR ID = " + oResponse.CirID + " Cir Synced Successfully!");
                            Cir.ComponentInspectionReportName = oResponse.CirName;
                            Cir.ComponentInspectionReportId = oResponse.CirID;
                            Cir.Country = oResponse.Turbine.Country;
                            Cir.SiteName = oResponse.Turbine.Site;
                            Cir.TurbineType = oResponse.Turbine.TurbineType;
                            Cir.CirDataID = oResponse.CirDataId;
                            Cir.CIMCaseNumber = Convert.ToInt64(oResponse.CIMCaseNumber);
                            // long.TryParse(oResponse.Turbine.TurbineID, out turbineid);
                            Cir.TurbineNumber = turbineid;
                            Cir.TurbineData = new TurbineProperties
                            {
                                RotorDiameter = Convert.ToDecimal(oResponse.Turbine.RotorDiameter),
                                NominelPower = Convert.ToInt32(oResponse.Turbine.NominelPower),
                                Voltage = Convert.ToInt32(oResponse.Turbine.Voltage),
                                PowerRegulation = oResponse.Turbine.PowerRegulation,
                                Frequency = Convert.ToByte(oResponse.Turbine.Frequency),
                                SmallGenerator = Convert.ToInt32(oResponse.Turbine.SmallGenerator),
                                TemperatureVariant = oResponse.Turbine.TemperatureVariant,
                                MarkVersion = oResponse.Turbine.MarkVersion,
                                //Placement= oResponse.Turbine.Placement,
                                Manufacturer = oResponse.Turbine.Manufacturer
                            };


                            oCmd.Parameters.AddWithValue("@Status", 3);
                            oCmd.Parameters.AddWithValue("@CirStatus", 1);
                            oCmd.Parameters.AddWithValue("@StatusMessage", "Cir Synced Successfully!");
                            oCmd.Parameters.AddWithValue("@StatusDetailMessage", "Cir Synced Successfully!");
                            oCmd.Parameters.AddWithValue("@CirDataLocalID", oResponse.CirID);
                            oCmd.Parameters.AddWithValue("@CirData", JsonConvert.SerializeObject(Cir, new JsonSerializerSettings
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            }));
                            oCmd.Parameters.AddWithValue("@RowVersion", DateTime.UtcNow.Ticks);
                            oCmd.Parameters.AddWithValue("@Id", rw["Id"].ToString());
                            log.WriteLine("CIR ID = " + oResponse.CirID + " Cir Update Command Created!");
                        }
                        else
                        {
                            log.WriteLine("CIR ID = " + oResponse.CirID + " Cir Synced Error!");
                            log.WriteLine(oResponse.StatusMessage);
                            log.WriteLine(oResponse.StatusDetailMessage);
                            var strsmmsg = (String.IsNullOrEmpty(oResponse.StatusMessage)) ? " " : oResponse.StatusMessage;
                            var strmsg = (String.IsNullOrEmpty(oResponse.StatusDetailMessage)) ? " " : oResponse.StatusDetailMessage;
                            oCmd.Parameters.AddWithValue("@Status", -1);
                            oCmd.Parameters.AddWithValue("@CirStatus", -1);
                            oCmd.Parameters.AddWithValue("@StatusMessage", strsmmsg);
                            oCmd.Parameters.AddWithValue("@StatusDetailMessage", strmsg);
                            oCmd.Parameters.AddWithValue("@CirDataLocalID", oResponse.CirID);
                            oCmd.Parameters.AddWithValue("@CirData", JsonConvert.SerializeObject(Cir, new JsonSerializerSettings
                            {
                                ContractResolver = new CamelCasePropertyNamesContractResolver()
                            }));
                            oCmd.Parameters.AddWithValue("@RowVersion", DateTime.UtcNow.Ticks);
                            oCmd.Parameters.AddWithValue("@Id", rw["Id"].ToString());
                            log.WriteLine("CIR ID = " + oResponse.CirID + " Cir Update Command Created!");
                        }

                    }
                    catch (Exception ex)
                    {
                        log.WriteLine("error " + ex.Message + "Details : " + ex.StackTrace);
                        updateSql = "UPDATE [" + schemaname + "].[UserCirDatas] SET Status = @Status, CirStatus = @CirStatus, StatusMessage = @StatusMessage, StatusDetailMessage = @StatusDetailMessage, RowVersion = @RowVersion WHERE Id = @Id";
                        oCmd = new SqlCommand(updateSql);
                        var strsmmsg = ex.Message;
                        var strmsg = ex.StackTrace;
                        oCmd.Parameters.AddWithValue("@Status", -1);
                        oCmd.Parameters.AddWithValue("@CirStatus", -1);
                        oCmd.Parameters.AddWithValue("@StatusMessage", strsmmsg);
                        oCmd.Parameters.AddWithValue("@StatusDetailMessage", strmsg);
                        oCmd.Parameters.AddWithValue("@RowVersion", DateTime.UtcNow.Ticks);
                        oCmd.Parameters.AddWithValue("@Id", rw["Id"].ToString());
                        log.WriteLine("CIR ID = " + rw["Id"].ToString() + " Cir Update Command Created!");
                    }
                    finally
                    {
                        using (SqlConnection con = new SqlConnection(connectionString))
                        {
                            oCmd.Connection = con;
                            oCmd.CommandType = CommandType.Text;
                            con.Open();
                            oCmd.ExecuteNonQuery();
                            con.Close();
                            oCmd = null;
                        }
                    }
                }
                log.WriteLine("RunCompleted At " + DateTime.Now);
            }

        }
    }
}
