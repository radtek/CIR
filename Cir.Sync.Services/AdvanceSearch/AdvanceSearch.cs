using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Data.LLBLGen;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.DatabaseSpecific;
using System.Configuration;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Globalization;
using System.Data;
using Newtonsoft.Json;
using System.Text;
using System.Data.SqlClient;
using Cir.Sync.Services.ErrorHandling;
using System.Text.RegularExpressions;

namespace Cir.Sync.Services.AdvanceSearch
{

    public static class AdvanceSearch
    {
        public static AdvanceSearchModel _AdvanceSearchData = new AdvanceSearchModel();
        private const int MaxResultsToShow = 50;
        private static string InputFilterColumn = "";
        private static Dictionary<string, string> ResultColumnMapList = null;


        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }

        public static List<Brand> GetBrandList()
        {
            Brand objBrand = new Brand();
            List<Brand> objBrandList = new List<Brand>();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                conn.Open();
                var cmd = new SqlCommand { Connection = conn };
                SqlDataReader reader = null;


                //string whereClauseOrder = "";
                //whereClauseOrder += "bd.Deleted = 0 AND bd.BirDataID = " + BirID.ToString();

                try
                {
                    cmd.CommandText = string.Format(@"
                                    SELECT DISTINCT LTRIM(RTRIM(UPPER(BRAND))) AS BRAND FROM ComponentInspectionReport
                                    ");

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objBrand = new Brand
                        {
                            BrandId = Convert.ToString(reader["BRAND"]),
                            BrandName = Convert.ToString(reader["BRAND"])
                        };
                        objBrandList.Add(objBrand);
                    }
                    reader.Close();
                }
                catch
                {
                    throw new Exception("Error getting BIR Data");
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                    conn.Close();
                }
            }
            return objBrandList;
        }

        public static AdvanceSearchModel LoadProfile(long ProfileId)
        {
            EntityCollection<SearchProfileEntity> e = new EntityCollection<SearchProfileEntity>(new SearchProfileEntityFactory());

            using (DataAccessAdapter daa = new DataAccessAdapter(GetConnectionString(), false))
            {
                daa.FetchEntityCollection(e, new RelationPredicateBucket(SearchProfileFields.SearchProfileId == ProfileId));

            }

            EntityCollection<SearchProfileDetailEntity> ec = new EntityCollection<SearchProfileDetailEntity>(new SearchProfileDetailEntityFactory());

            using (DataAccessAdapter daa = new DataAccessAdapter(GetConnectionString(), false))
            {
                daa.FetchEntityCollection(ec, new RelationPredicateBucket(SearchProfileDetailFields.SearchProfileId == ProfileId));

            }

            AdvanceSearchModel advanceSearchModel = new AdvanceSearchModel();
            advanceSearchModel.ProfileID = e[0].SearchProfileId;
            advanceSearchModel.UserName = e[0].UserId;
            advanceSearchModel.ProfileName = e[0].Name;
            advanceSearchModel.isPublic = e[0].Public;
            advanceSearchModel.InputFields = new List<InputFields>();
            foreach (SearchProfileDetailEntity entity in ec)
            {
                try
                {
                    InputFields inputfield = new InputFields();
                    inputfield.InputId = entity.InputId;
                    inputfield.InputType = entity.InputType;
                    inputfield.Value = entity.Value;

                    advanceSearchModel.InputFields.Add(inputfield);

                }
                catch
                {
                }
            }
            var d = (from i in advanceSearchModel.InputFields
                     group i.Value by new { i.InputId, i.InputType } into g
                     select new { InputId = g.Key.InputId, InputType = g.Key.InputType, Value = String.Join(",", g.ToArray()) });
            advanceSearchModel.InputFields = d.Select(x => new InputFields { InputId = x.InputId, InputType = x.InputType, Value = x.Value }).ToList();
            return advanceSearchModel;

        }

        public static AdvanceSearchModel DeleteProfile(long ProfileId)
        {
            AdvanceSearchModel advanceSearchModel = new AdvanceSearchModel();
            try
            {
                using (DataAccessAdapter daa = new DataAccessAdapter(GetConnectionString(), false))
                {
                    var fb1 = new RelationPredicateBucket();
                    fb1.PredicateExpression.Add(SearchProfileDetailFields.SearchProfileId == ProfileId);
                    daa.DeleteEntitiesDirectly(typeof(SearchProfileDetailEntity), fb1);

                    var fb2 = new RelationPredicateBucket();
                    fb2.PredicateExpression.Add(SearchProfileFields.SearchProfileId == ProfileId);
                    daa.DeleteEntitiesDirectly(typeof(SearchProfileEntity), fb2);

                    advanceSearchModel.ResponseString = "Search profile deleted!";
                    advanceSearchModel.Result = "Success";
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Search Profile with Id " + ProfileId.ToString() + " deleted!", LogType.Information, "");
                }
            }
            catch (Exception ex)
            {
                advanceSearchModel.ResponseString = "Error Occured!";
                advanceSearchModel.Result = "Error";
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error Deleting Search Profile with Id " + ProfileId.ToString() + " ", LogType.Error, ex.Message.ToString());
            }

            return advanceSearchModel;
        }

        public static AdvanceSearchModel SaveProfile(AdvanceSearchModel advanceSearchModel)
        {
            //advanceSearchModel = LoadProfile(1);
            EntityCollection<SearchProfileEntity> ec = new EntityCollection<SearchProfileEntity>(new SearchProfileEntityFactory());
            RelationPredicateBucket fb = new RelationPredicateBucket();

            fb.PredicateExpression.Add(SearchProfileFields.Name == advanceSearchModel.ProfileName);

            using (DataAccessAdapter daa = new DataAccessAdapter(GetConnectionString(), false))
            {

                daa.FetchEntityCollection(ec, fb);
            }
            if (advanceSearchModel.ProfileID > 0)
            {
                if (ec.Count > 0 && advanceSearchModel.ProfileID != ec[0].SearchProfileId)
                {
                    advanceSearchModel.ResponseString = "Search profile with name [" + advanceSearchModel.ProfileName + "] already exists!";
                    advanceSearchModel.Result = "Error";
                    return advanceSearchModel;
                }
            }


            //  PrefetchPath2 pp = new PrefetchPath2((int)EntityType.SearchProfileEntity);

            //  pp.Add(SearchProfileEntity.PrefetchPathSearchProfileDetail);

            ///
            try
            {
                using (DataAccessAdapter daa = new DataAccessAdapter(GetConnectionString(), false))
                {
                    var fb1 = new RelationPredicateBucket();
                    fb1.PredicateExpression.Add(SearchProfileDetailFields.SearchProfileId == advanceSearchModel.ProfileID);
                    daa.DeleteEntitiesDirectly(typeof(SearchProfileDetailEntity), fb1);
                }

                using (DataAccessAdapter daa = new DataAccessAdapter(GetConnectionString(), false))
                {
                    fb = new RelationPredicateBucket();
                    fb.PredicateExpression.Add(SearchProfileFields.SearchProfileId == advanceSearchModel.ProfileID);
                    daa.FetchEntityCollection(ec, fb);
                    SearchProfileEntity spEntity = null;
                    if (ec.Count > 0)
                    {
                        spEntity = ec[0];
                    }
                    else
                    {
                        spEntity = new SearchProfileEntity();
                    }
                    spEntity.UserId = advanceSearchModel.UserName;
                    spEntity.Name = advanceSearchModel.ProfileName;
                    spEntity.Public = advanceSearchModel.isPublic;

                    foreach (InputFields f in advanceSearchModel.InputFields)
                    {
                        switch (f.InputType.ToUpper())
                        {

                            case "TEXTBOX":

                                if (!String.IsNullOrWhiteSpace(f.Value))
                                {
                                    var spdEntity = spEntity.SearchProfileDetail.AddNew();
                                    spdEntity.InputId = f.InputId;
                                    spdEntity.Value = f.Value;
                                    spdEntity.InputType = f.InputType;
                                }
                                break;
                            case "CHECKBOX":
                                if (!String.IsNullOrWhiteSpace(f.Value))
                                {
                                    var spdEntity = spEntity.SearchProfileDetail.AddNew();
                                    spdEntity.InputId = f.InputId;
                                    spdEntity.Value = f.Value;
                                    spdEntity.InputType = f.InputType;
                                }
                                break;
                            case "LISTBOX":
                                if (!String.IsNullOrWhiteSpace(f.Value))
                                {
                                    string[] data = f.Value.Split(',');
                                    foreach (string d in data)
                                    {
                                        var spdEntity = spEntity.SearchProfileDetail.AddNew();
                                        spdEntity.InputId = f.InputId;
                                        spdEntity.Value = d;
                                        spdEntity.InputType = f.InputType;
                                    }
                                }
                                break;
                        }

                    }
                    //using (DataAccessAdapter daa = new DataAccessAdapter(GetConnectionString(), false))
                    //{

                    daa.SaveEntity(spEntity, false, true);
                    advanceSearchModel.ProfileID = spEntity.SearchProfileId;
                    ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Search Profile with Id " + advanceSearchModel.ProfileID.ToString() + " created/updated!", LogType.Information, "");
                }
                advanceSearchModel.ResponseString = "Search profile with name [" + advanceSearchModel.ProfileName + "] saved successfully!";
                advanceSearchModel.Result = "Success";


            }
            catch (Exception ex)
            {
                advanceSearchModel.ResponseString = "Error occured: " + ex.Message.ToString();
                advanceSearchModel.Result = "Error";
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Search Profile with Id " + advanceSearchModel.ProfileID.ToString() + " created/updated!", LogType.Error, ex.Message.ToString());
            }
            return advanceSearchModel;
        }

        public static AdvanceSearchModel DoAdvanceSearch(AdvanceSearchModel advanceSearchModel)
        {
            //CIM Case No
            // string tbWTDCaseNo = GetValueFromInput("CIRWTDCaseNo").FirstOrDefault();
            // string ddlCIMCase = GetValueFromInput("ExcludeCIMCase").FirstOrDefault(); ;
            _AdvanceSearchData = advanceSearchModel;
            //_AdvanceSearchData.InputFields = new List<InputFields>();
            //InputFields i = new InputFields() { InputId = "CIRWTDCaseNo", InputType = "textbox", Value = "7599" };
            //_AdvanceSearchData.InputFields.Add(i);
            // i = new InputFields() { InputId = "ExcludeCIMCase", InputType = "textbox", Value = "5" };
            //_AdvanceSearchData.InputFields.Add(i);
            //i = new InputFields() { InputId = "CIRColumnsInResultList", InputType = "textbox", Value = "Report Type,Failure Date,CIM Case Number" };
            //_AdvanceSearchData.InputFields.Add(i);

            //_AdvanceSearchData.InputFields = new List<InputFields>();
            //InputFields i = new InputFields() { InputId = "CIRComponentType", InputType = "textbox", Value = "1" };
            //_AdvanceSearchData.InputFields.Add(i);
            // i = new InputFields() { InputId = "CIRWTDReportType", InputType = "textbox", Value = "6" };
            //_AdvanceSearchData.InputFields.Add(i);
            // i = new InputFields() { InputId = "CIRComponentType", InputType = "textbox", Value = "1" };
            //_AdvanceSearchData.InputFields.Add(i);
            //i = new InputFields() { InputId = "CIRMainBearingGrease", InputType = "checkbox", Value = "false" };
            //_AdvanceSearchData.InputFields.Add(i);
            //i = new InputFields() { InputId = "CIRColumnsInResultList", InputType = "textbox", Value = "Component Type" };
            //_AdvanceSearchData.InputFields.Add(i);
            //_AdvanceSearchData.InputFields = new List<InputFields>();
            //InputFields i = new InputFields() { InputId = "BIR_lbBIRID", InputType = "textbox", Value = "25%%" };
            //_AdvanceSearchData.InputFields.Add(i);
            //i = new InputFields() { InputId = "ddlCirSearchType", InputType = "textbox", Value = "BIR" };
            //_AdvanceSearchData.InputFields.Add(i);

            InputFilterColumn = _AdvanceSearchData.InputFields.Where(x => x.InputId.ToUpper() == "CIRColumnsInResultList".ToUpper()).Select(x => x.Value).FirstOrDefault();
            string SearchType = GetValueFromInput("ddlCirSearchType").FirstOrDefault();
            if (SearchType != null)
            {
                if (SearchType.ToUpper() == "BIR")
                {
                    return GetBirAdvanceSearchData();
                }
                else
                {
                    return Search();
                }
            }
            else
            {
                return Search();
            }
        }

        public static string[] GetValueFromInput(string InputId)
        {

            string s = _AdvanceSearchData.InputFields.Where(x => x.InputId.ToUpper() == InputId.ToUpper()).Select(x => x.Value).FirstOrDefault();
            string[] sArray = new string[0];
            if (s != null)
            {
                sArray = s.Split(',');

            }


            return sArray;
        }

        private static void AddPredicateToBucket(ref RelationPredicateBucket filterbucket, EntityField2 field, string value, Type type, bool IsOrPredicate)
        {
            if (value != null)
            {
                value = value.Replace("*", "%");
                long lValue = 0;
                string strippedValue = value.Replace("%", String.Empty);
                bool isLikePredicate = value.Contains("%");

                if (object.ReferenceEquals(type, typeof(long)))
                {
                    if (long.TryParse(strippedValue, out lValue))
                    {
                        AddPredicateExpression(ref filterbucket, ref field, value, isLikePredicate, IsOrPredicate);
                    }
                }
                else if (object.ReferenceEquals(type, typeof(decimal)))
                {
                    decimal dValue = default(decimal);
                    if (decimal.TryParse(strippedValue, out dValue))
                    {
                        AddPredicateExpression(ref filterbucket, ref field, value, isLikePredicate, IsOrPredicate);
                    }
                }
                else
                {
                    if (value.Length > 0)
                    {
                        AddPredicateExpression(ref filterbucket, ref field, value, isLikePredicate, IsOrPredicate);
                    }
                }
            }
        }

        private static void AddPredicateExpression(ref RelationPredicateBucket filterbucket, ref EntityField2 field, string value, bool isLike, bool IsOrPredicate)
        {
            if (isLike & IsOrPredicate)
            {
                filterbucket.PredicateExpression.AddWithOr(field % value);
            }
            else if (isLike & !IsOrPredicate)
            {
                filterbucket.PredicateExpression.Add(field % value);
            }
            else if (!isLike & IsOrPredicate)
            {
                filterbucket.PredicateExpression.AddWithOr(field == value);
            }
            else if (!isLike & !IsOrPredicate)
            {
                filterbucket.PredicateExpression.Add(field == value);
            }
        }

        public static IRelationPredicateBucket WhereClause()
        {

            RelationPredicateBucket fb = new RelationPredicateBucket();
            fb.Relations.ObeyWeakRelations = true;
            //CIR ID (possible to search for multiple cir's separated by ",")
            string[] tbCIRID = GetValueFromInput("CIRCIRID");
            if (tbCIRID.Length > 0)
            {
                // fb.PredicateExpression.Add(ComponentInspectionReportFields.ComponentInspectionReportId == tbCIRID.ToArray());
                foreach (string s in tbCIRID)
                {
                    AddPredicateToBucket(ref fb, ComponentInspectionReportFields.ComponentInspectionReportId, s, typeof(long), true);
                }
            }


            //string lbComponentType = GetValueFromInput("CIRComponentType");
            string[] arrlbComponentType = GetValueFromInput("CIRComponentType");
            if (arrlbComponentType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportFields.ComponentInspectionReportTypeId == arrlbComponentType.ToArray());

            }
            try
            {
                CreateWindTurbineWhereClause(ref fb);
                CreateBladeWhereClause(ref fb);
                CreateGearWhereClause(ref fb);
                CreateGeneralWhereClause(ref fb);
                CreateGeneratorWhereClause(ref fb);
                CreateMainBearingWhereClause(ref fb);
                CreateSkiiPWhereClause(ref fb);
                CreateTransformerWhereClause(ref fb);
            }
            catch (Exception e)
            {
                //mbox(e.Message);
                throw;
            }


            return fb;

        }

        private static void CreateWindTurbineWhereClause(ref RelationPredicateBucket fb)
        {
            long lngParseResult = 0;
            //fb.Relations.Add(ComponentInspectionReportEntity.Relations.TurbineMatrixEntityUsingTurbineMatrixId, JoinHint.Left);


            string[] arrlbWTDReportType = GetValueFromInput("CIRWTDReportType");
            //Report Type
            if (arrlbWTDReportType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportFields.ReportTypeId == arrlbWTDReportType.ToArray());

            }


            //Reconstruction

            string[] arrlbWTDReconstruction = GetValueFromInput("CIRWTDReconstruction");

            if (arrlbWTDReconstruction.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportFields.ReconstructionBooleanAnswerId == arrlbWTDReconstruction.ToArray());

            }

            //CIM Case No
            string tbWTDCaseNo = GetValueFromInput("CIRWTDCaseNo").FirstOrDefault();
            string ddlCIMCase = GetValueFromInput("ExcludeCIMCase").FirstOrDefault(); ;
            switch (ddlCIMCase)
            {
                case "0":
                case "2":
                    if (tbWTDCaseNo != null)
                    {
                        RelationPredicateBucket CaseNo_FilterBucket = new RelationPredicateBucket();
                        string[] arrCaseNo = tbWTDCaseNo.Split(',');
                        foreach (string str in arrCaseNo)
                        {

                            AddPredicateToBucket(ref CaseNo_FilterBucket, ComponentInspectionReportFields.CimcaseNumber, str.Trim(), typeof(long), true);
                        }
                        if (CaseNo_FilterBucket.PredicateExpression.Count > 0)
                            fb.PredicateExpression.Add(CaseNo_FilterBucket.PredicateExpression);
                    }
                    if (ddlCIMCase == "2")
                    {
                        RelationPredicateBucket CaseNo_FilterBucket = new RelationPredicateBucket();
                        CaseNo_FilterBucket.PredicateExpression.Add(ComponentInspectionReportFields.CimcaseNumber != -1);
                        fb.PredicateExpression.Add(CaseNo_FilterBucket.PredicateExpression);
                    }
                    break;
                case "1":
                    RelationPredicateBucket CaseNo_FilterBucket1 = new RelationPredicateBucket();
                    CaseNo_FilterBucket1.PredicateExpression.Add(ComponentInspectionReportFields.CimcaseNumber == -1);
                    fb.PredicateExpression.Add(CaseNo_FilterBucket1.PredicateExpression);
                    break;
                case "4":
                    if (tbWTDCaseNo != null)
                    {
                        RelationPredicateBucket CaseNo_FilterBucket = new RelationPredicateBucket();
                        string[] arrCaseNo = tbWTDCaseNo.Split(',');
                        foreach (string str in arrCaseNo)
                        {

                            AddPredicateToBucket(ref CaseNo_FilterBucket, ComponentInspectionReportFields.CimcaseNumber, str.Trim(), typeof(long), true);
                        }
                        if (CaseNo_FilterBucket.PredicateExpression.Count > 0)
                            fb.PredicateExpression.Add(CaseNo_FilterBucket.PredicateExpression);
                    }
                    RelationPredicateBucket CirUnapproved_FilterBucket1 = new RelationPredicateBucket();
                    CirUnapproved_FilterBucket1.PredicateExpression.Add(ComponentInspectionReportFields.ComponentInspectionReportStateId == 1);
                    CirUnapproved_FilterBucket1.PredicateExpression.AddWithOr(ComponentInspectionReportFields.ComponentInspectionReportStateId == 2);
                    fb.PredicateExpression.Add(CirUnapproved_FilterBucket1.PredicateExpression);
                    break;
                case "5":
                    if (tbWTDCaseNo != null)
                    {
                        RelationPredicateBucket CaseNo_FilterBucket = new RelationPredicateBucket();
                        string[] arrCaseNo = tbWTDCaseNo.Split(',');
                        foreach (string str in arrCaseNo)
                        {

                            AddPredicateToBucket(ref CaseNo_FilterBucket, ComponentInspectionReportFields.CimcaseNumber, str.Trim(), typeof(long), true);
                        }
                        if (CaseNo_FilterBucket.PredicateExpression.Count > 0)
                            fb.PredicateExpression.Add(CaseNo_FilterBucket.PredicateExpression);
                    }
                    RelationPredicateBucket CirAll_FilterBucket1 = new RelationPredicateBucket();
                    CirAll_FilterBucket1.PredicateExpression.Add(ComponentInspectionReportFields.ComponentInspectionReportStateId == 1);
                    CirAll_FilterBucket1.PredicateExpression.AddWithOr(ComponentInspectionReportFields.ComponentInspectionReportStateId == 2);
                    CirAll_FilterBucket1.PredicateExpression.AddWithOr(ComponentInspectionReportFields.ComponentInspectionReportStateId == 4);
                    fb.PredicateExpression.Add(CirAll_FilterBucket1.PredicateExpression);
                    break;

            }

            //Initial = 1,
            //Approved = 2,
            //Rejected = 3
            RelationPredicateBucket CirDeleted_FilterBucket = new RelationPredicateBucket();
            CirDeleted_FilterBucket.PredicateExpression.Add(ComponentInspectionReportFields.DeletedBy == DBNull.Value);

            if (CirDeleted_FilterBucket.PredicateExpression.Count > 0)
            {
                fb.PredicateExpression.Add(CirDeleted_FilterBucket.PredicateExpression);
            }


            string tbWTDReasonForService = GetValueFromInput("CIRWTDReasonForService").FirstOrDefault();
            if (tbWTDReasonForService != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.ReasonForService, tbWTDReasonForService, typeof(string), false);
            }

            //Turbine Number

            string tbWTDTurbineNo0 = GetValueFromInput("CIRWTDTurbineNo").FirstOrDefault();
            AddTurbineNumberPredicate(ref tbWTDTurbineNo0, ref fb);

            //country
            string[] lbWTDCountry = GetValueFromInput("CIRWTDCountry");
            if (lbWTDCountry.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportFields.CountryIsoid == lbWTDCountry.ToArray());
            }


            //Site Name
            string tbWTDSiteName = GetValueFromInput("CIRWTDSiteName").FirstOrDefault();
            if (tbWTDSiteName != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.SiteName, tbWTDSiteName, typeof(string), false);
            }
           
            
            //Turbine Type
            string[] lbWTDTurbineType = GetValueFromInput("CIRWTDTurbineType");
            if (lbWTDTurbineType.Length > 0)
            {
                fb.PredicateExpression.Add(TurbineMatrixFields.TurbineId == lbWTDTurbineType.ToArray());
            }


            //Local Turbine Id
            string tbWTDLocalTurbineId = GetValueFromInput("CIRWTDLocalTurbineId").FirstOrDefault();
            if (tbWTDLocalTurbineId != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.LocalTurbineId, tbWTDLocalTurbineId, typeof(string), false);
            }

            //Second Generator
            string[] lbWTDSecondGenerator = GetValueFromInput("CIRWTDSecondGenerator");
            if (lbWTDSecondGenerator.Length > 0)
            {

                fb.PredicateExpression.Add(ComponentInspectionReportFields.SecondGeneratorBooleanAnswerId == lbWTDSecondGenerator.ToArray());
            }

            //Run Status Before Inspection
            string[] lbWTDRunStatusBeforeInspection = GetValueFromInput("CIRWTDRunStatusBeforeInspection");
            if (lbWTDRunStatusBeforeInspection.Length > 0)
            {

                fb.PredicateExpression.Add(ComponentInspectionReportFields.BeforeInspectionTurbineRunStatusId == lbWTDRunStatusBeforeInspection.ToArray());
            }


            //Commisioning Date
            DateTime dpWTDCommisioningDateFrom = System.DateTime.MinValue; ;
            if (DateTime.TryParseExact(GetValueFromInput("CIRWTDCommisioningDateFrom").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpWTDCommisioningDateFrom))
            {

            }

            DateTime dpWTDCommisioningDateTo = System.DateTime.MaxValue; ;
            if (DateTime.TryParseExact(GetValueFromInput("CIRWTDCommisioningDateTo").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpWTDCommisioningDateFrom))
            {

            }


            if (dpWTDCommisioningDateFrom > System.DateTime.MinValue || dpWTDCommisioningDateTo > System.DateTime.MinValue)
            {
                if (dpWTDCommisioningDateFrom > System.DateTime.MinValue && dpWTDCommisioningDateTo == System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportFields.CommisioningDate >= dpWTDCommisioningDateFrom);
                }
                else if (dpWTDCommisioningDateFrom == System.DateTime.MinValue && dpWTDCommisioningDateTo > System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportFields.CommisioningDate <= dpWTDCommisioningDateTo);
                }
                else if (dpWTDCommisioningDateFrom > System.DateTime.MinValue && dpWTDCommisioningDateTo > System.DateTime.MinValue && dpWTDCommisioningDateFrom > dpWTDCommisioningDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportFields.CommisioningDate, null, dpWTDCommisioningDateTo, dpWTDCommisioningDateFrom));
                }
                else if (dpWTDCommisioningDateFrom > System.DateTime.MinValue && dpWTDCommisioningDateTo > System.DateTime.MinValue && dpWTDCommisioningDateFrom < dpWTDCommisioningDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportFields.CommisioningDate, null, dpWTDCommisioningDateFrom, dpWTDCommisioningDateTo));
                }
            }

            //Installation Date
            DateTime dpWTDInstallationDateFrom = System.DateTime.MinValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRWTDInstallationDateFrom").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpWTDCommisioningDateFrom))
            {

            }

            DateTime dpWTDInstallationDateTo = System.DateTime.MaxValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRWTDInstallationDateTo").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpWTDCommisioningDateFrom))
            {

            }

            if (dpWTDInstallationDateFrom > System.DateTime.MinValue || dpWTDInstallationDateTo > System.DateTime.MinValue)
            {
                if (dpWTDInstallationDateFrom > System.DateTime.MinValue && dpWTDInstallationDateTo == System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportFields.CommisioningDate >= dpWTDInstallationDateFrom);
                }
                else if (dpWTDInstallationDateFrom == System.DateTime.MinValue && dpWTDInstallationDateTo > System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportFields.CommisioningDate <= dpWTDInstallationDateTo);
                }
                else if (dpWTDInstallationDateFrom > System.DateTime.MinValue && dpWTDInstallationDateTo > System.DateTime.MinValue && dpWTDInstallationDateFrom > dpWTDInstallationDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportFields.CommisioningDate, null, dpWTDInstallationDateTo, dpWTDInstallationDateFrom));
                }
                else if (dpWTDInstallationDateFrom > System.DateTime.MinValue && dpWTDInstallationDateTo > System.DateTime.MinValue && dpWTDInstallationDateFrom < dpWTDInstallationDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportFields.CommisioningDate, null, dpWTDInstallationDateFrom, dpWTDInstallationDateTo));
                }
            }

            //Inspection Date
            DateTime dpWTDInspectionDateFrom = System.DateTime.MinValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRWTDInspectionDateFrom").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpWTDCommisioningDateFrom))
            {

            }

            DateTime dpWTDInspectionDateTo = System.DateTime.MaxValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRWTDInspectionDateTo").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpWTDCommisioningDateFrom))
            {

            }

            if (dpWTDInspectionDateFrom > System.DateTime.MinValue || dpWTDInspectionDateTo > System.DateTime.MinValue)
            {
                if (dpWTDInspectionDateFrom > System.DateTime.MinValue && dpWTDInspectionDateTo == System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportFields.CommisioningDate >= dpWTDInspectionDateFrom);
                }
                else if (dpWTDInspectionDateFrom == System.DateTime.MinValue && dpWTDInspectionDateTo > System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportFields.CommisioningDate <= dpWTDInspectionDateTo);
                }
                else if (dpWTDInspectionDateFrom > System.DateTime.MinValue && dpWTDInspectionDateTo > System.DateTime.MinValue && dpWTDInspectionDateFrom > dpWTDInspectionDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportFields.CommisioningDate, null, dpWTDInspectionDateTo, dpWTDInspectionDateFrom));
                }
                else if (dpWTDInspectionDateFrom > System.DateTime.MinValue && dpWTDInspectionDateTo > System.DateTime.MinValue && dpWTDInspectionDateFrom < dpWTDInspectionDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportFields.CommisioningDate, null, dpWTDInspectionDateFrom, dpWTDInspectionDateTo));
                }
            }

            //Failure Date
            DateTime dpWTDFailureDateFrom = System.DateTime.MinValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRWTDFailureDateFrom").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpWTDCommisioningDateFrom))
            {

            }

            DateTime dpWTDFailureDateTo = System.DateTime.MaxValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRWTDFailureDateTo").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpWTDCommisioningDateFrom))
            {

            }

            if (dpWTDFailureDateFrom > System.DateTime.MinValue || dpWTDFailureDateTo > System.DateTime.MinValue)
            {
                if (dpWTDFailureDateFrom > System.DateTime.MinValue && dpWTDFailureDateTo == System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportFields.CommisioningDate >= dpWTDFailureDateFrom);
                }
                else if (dpWTDFailureDateFrom == System.DateTime.MinValue && dpWTDFailureDateTo > System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportFields.CommisioningDate <= dpWTDFailureDateTo);
                }
                else if (dpWTDFailureDateFrom > System.DateTime.MinValue && dpWTDFailureDateTo > System.DateTime.MinValue && dpWTDFailureDateFrom > dpWTDFailureDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportFields.CommisioningDate, null, dpWTDFailureDateTo, dpWTDFailureDateFrom));
                }
                else if (dpWTDFailureDateFrom > System.DateTime.MinValue && dpWTDFailureDateTo > System.DateTime.MinValue && dpWTDFailureDateFrom < dpWTDFailureDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportFields.CommisioningDate, null, dpWTDFailureDateFrom, dpWTDFailureDateTo));
                }
            }

            //Service Report Number
            string tbWTDServiceReportNumber = GetValueFromInput("CIRWTDServiceReportNumber").FirstOrDefault();
            if (tbWTDServiceReportNumber != null)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportFields.ServiceReportNumber == tbWTDServiceReportNumber);
                // AddPredicateToBucket(ref fb, ComponentInspectionReportFields.ServiceReportNumber, tbWTDServiceReportNumber, typeof(string), false);
            }

            //Service Report Number Type
            string lbWTDServiceReportNumberType = GetValueFromInput("CIRWTDServiceReportNumberType").FirstOrDefault(); ;
            if (lbWTDServiceReportNumberType != null)
            {

                fb.PredicateExpression.Add(ComponentInspectionReportFields.ServiceReportNumberTypeId == lbWTDServiceReportNumberType.ToArray());

            }

            //Notification Number
            string tbWTDNotificationNumber = GetValueFromInput("CIRWTDNotificationNumber").FirstOrDefault(); ;
            if (tbWTDNotificationNumber != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.NotificationNumber, tbWTDNotificationNumber, typeof(string), false);
            }

            //Service Engineer
            string tbWTDServiceEngineer = GetValueFromInput("CIRWTDServiceEngineer").FirstOrDefault();
            if (tbWTDServiceEngineer != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.ServiceEngineer, tbWTDServiceEngineer, typeof(string), false);
            }

            //Run Hours
            string tbWTDRunHours = GetValueFromInput("CIRWTDRunHours").FirstOrDefault();
            if (tbWTDRunHours != null && long.TryParse(tbWTDRunHours, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.RunHours, tbWTDRunHours, typeof(long), false);
            }

            //Generator 1 Hours
            string tbWTDGenerator1Hours = GetValueFromInput("CIRWTDGenerator1Hours").FirstOrDefault();
            if (tbWTDGenerator1Hours != null && long.TryParse(tbWTDGenerator1Hours, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.Generator1Hrs, tbWTDGenerator1Hours, typeof(long), false);
            }

            //Generator 2 Hours
            string tbWTDGenerator2Hours = GetValueFromInput("CIRWTDGenerator2Hours").FirstOrDefault();
            if (tbWTDGenerator2Hours != null && long.TryParse(tbWTDGenerator2Hours, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.Generator2Hrs, tbWTDGenerator2Hours, typeof(long), false);
            }

            //Total Production
            string tbWTDTotalProduction = GetValueFromInput("CIRWTDTotalProduction").FirstOrDefault();
            if (tbWTDTotalProduction != null && long.TryParse(tbWTDTotalProduction, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.TotalProduction, tbWTDTotalProduction, typeof(long), false);
            }

            //Run Status After Inspection
            string[] lbWTDRunStatusAfterInspection = GetValueFromInput("CIRWTDRunStatusAfterInspection");

            if (lbWTDRunStatusAfterInspection.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportFields.AfterInspectionTurbineRunStatusId == lbWTDRunStatusAfterInspection.ToArray());

            }

            //Vestas Item No.
            string tbGeneralVestasItemNumber = GetValueFromInput("CIRWTDVestasItemNo").FirstOrDefault();
            if (tbGeneralVestasItemNumber != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.VestasItemNumber, tbGeneralVestasItemNumber, typeof(string), false);
            }

            //Quantity Of Failed Components
            string tbWTDQuantity = GetValueFromInput("CIRWTDQuantity").FirstOrDefault();
            if (tbWTDQuantity != null && long.TryParse(tbWTDQuantity, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.Quantity, tbWTDQuantity, typeof(long), false);
            }

            //Alarm Log Number
            string tbWTDAlarmLogNumber = GetValueFromInput("CIRWTDAlarmLogNumber").FirstOrDefault();
            if (tbWTDAlarmLogNumber != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.AlarmLogNumber, tbWTDAlarmLogNumber, typeof(string), false);
            }

            //Description
            string tbWTDDescription = GetValueFromInput("CIRWTDDescription").FirstOrDefault();
            if (tbWTDDescription != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.Description, tbWTDDescription, typeof(string), false);
            }

            //Description of any consequential problems/damage
            string tbWTDDescriptionConsquential = GetValueFromInput("CIRWTDDescriptionConsequential").FirstOrDefault();
            if (tbWTDDescriptionConsquential != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.DescriptionConsquential, tbWTDDescriptionConsquential, typeof(string), false);
            }

            //Conducted By
            string tbWTDConductedBy = GetValueFromInput("CIRWTDConductedBy").FirstOrDefault();
            if (tbWTDConductedBy != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.ConductedBy, tbWTDConductedBy, typeof(string), false);
            }



            //New added fields 

            //Description of any consequential problems/damage
            string tbWTDDescriptionC = GetValueFromInput("CIRWTDDescriptionConProb").FirstOrDefault();
            if (tbWTDDescriptionC != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.DescriptionConsquential, tbWTDDescriptionC, typeof(string), false);
            }

            //AdditionalInformation
            string tbWTDAdditionalInfo = GetValueFromInput("CIRWTDAdditionalInfo").FirstOrDefault();
            if (tbWTDAdditionalInfo != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.AdditionalInfo, tbWTDAdditionalInfo, typeof(string), false);
            }

            //SBURecommendation
            string tbCIRWTDSBURecommendation = GetValueFromInput("CIRWTDSBURecommendation").FirstOrDefault();
            if (tbCIRWTDSBURecommendation != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.SBURecommendation, tbCIRWTDSBURecommendation, typeof(string), false);
            }

            //Brand Type
            string[] lbWTDBrandType = GetValueFromInput("CIRBrandType");
            if (lbWTDBrandType.Length > 0)
            {                
                fb.PredicateExpression.Add(ComponentInspectionReportFields.Brand == lbWTDBrandType.ToArray());
            }
            //InternalComments
            string tbCIRWTDInternalComments = GetValueFromInput("CIRWTDInternalComments").FirstOrDefault();
            if (tbCIRWTDInternalComments != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.InternalComments, tbCIRWTDInternalComments, typeof(string), false);
            }


            //UpTowerSolution

            string tbCIRWTDUpTowerSolution = GetValueFromInput("CIRWTDUpTowerSolution").FirstOrDefault(); ;

            if (tbCIRWTDUpTowerSolution != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.ComponentUpTowerSolutionId, tbCIRWTDUpTowerSolution, typeof(string), false);

            }

        }

        private static void CreateBladeWhereClause(ref RelationPredicateBucket fb)
        {

            long lngParseResult = 0;
            fb.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportBladeEntityUsingComponentInspectionReportId, JoinHint.Left);
            fb.Relations.Add(ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId, JoinHint.Left);
            fb.Relations.Add(ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportBladeRepairRecordEntityUsingComponentInspectionReportBladeId, JoinHint.Left);

            //Turbine Number
            string tbWTDTurbineNo1 = GetValueFromInput("CIRWTDTurbineNo1").FirstOrDefault();


            AddTurbineNumberPredicate(ref tbWTDTurbineNo1, ref fb);

            //------------

            // Blade mounted on main component
            //AddListboxPredicate(lbBDMountedOnMainComponent, ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId, fb);
            string[] lbBDMountedOnMainComponent = GetValueFromInput("CIRBDMountedOnMainComponent");
            if (lbBDMountedOnMainComponent.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId == lbBDMountedOnMainComponent.ToArray());
            }

            //Blade Length
            string[] lbBDLength = GetValueFromInput("CIRBDLength");
            if (lbBDLength.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeLengthId == lbBDLength.ToArray());
            }

            //Blade Color
            string[] lbBDColor = GetValueFromInput("CIRBDColor");
            if (lbBDColor.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeColorId == lbBDColor.ToArray());
            }

            //Blade Serial Number (possible to search for multiple cases separated by ",")
            //string InputId = "CIRBDSerialNo";
            string[] tbBDSerialNo = GetValueFromInput("CIRBDSerialNo");
            //string tbBDSerialNo = _AdvanceSearchData.InputFields.Where(x => x.InputId.ToUpper() == InputId.ToUpper()).Select(x => x.Value).FirstOrDefault();
            if (tbBDSerialNo.Length > 0)
            {
                //foreach (string s in tbBDSerialNo)
                //{
                // AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeSerialNumber, s, typeof(long), true);
                fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeSerialNumber == tbBDSerialNo.ToArray());
                // }

            }

            //Blade Pictures Included
            string[] lbBDPicturesIncluded = GetValueFromInput("CIRBDPicturesIncluded");
            if (lbBDPicturesIncluded.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladePicturesIncludedBooleanAnswerId == lbBDPicturesIncluded.ToArray());
            }

            //Other Blades In Set

            string tbBDSerialNoOther = GetValueFromInput("CIRBDSerialNoOther").FirstOrDefault();
            if (tbBDSerialNoOther != null)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeOtherSerialNumber1 == tbBDSerialNoOther);
                fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeOtherSerialNumber2 == tbBDSerialNoOther);
            }

            //Blade Damage Identified
            string[] lbBDDamageIdentified = GetValueFromInput("CIRBDDamageIdentified");
            if (lbBDDamageIdentified.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeDamageIdentified == lbBDDamageIdentified.ToArray());
            }

            //Blade Damage Placement
            string[] lbBDDamagePlacement = GetValueFromInput("CIRBDDamagePlacement");
            if (lbBDDamagePlacement.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeDamageFields.BladeDamagePlacementId == lbBDDamagePlacement.ToArray());
            }

            //Blade Damage Type
            string[] lbBDDamageType = GetValueFromInput("CIRBDDamageType");
            if (lbBDDamageType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeDamageFields.BladeInspectionDataId == lbBDDamageType.ToArray());
            }

            //Blade Radius
            string tbBDRadius = GetValueFromInput("CIRBDRadius").FirstOrDefault();
            if (tbBDRadius != null && long.TryParse(tbBDRadius, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeDamageFields.BladeRadius, tbBDRadius, typeof(long), false);
            }

            //Blade Edge
            string[] lbBDEdge = GetValueFromInput("CIRBDEdge");
            if (lbBDEdge.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeDamageFields.BladeEdgeId == lbBDEdge.ToArray());
            }

            //Blade Description

            string tbBDDescription = GetValueFromInput("CIRBDDescription").FirstOrDefault();

            if (tbBDDescription != null)
            {
                tbBDDescription = Regex.Replace(tbBDDescription, @"[^0-9a-zA-Z:.',]+", "");
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeDamageFields.BladeDescription, tbBDDescription, typeof(string), false);
                //fb.PredicateExpression.Add(ComponentInspectionReportBladeDamageFields.BladeDescription == tbBDDescription);
            }


            //Blade Fault Code Classification
            string[] lbBDFCClassification = GetValueFromInput("CIRBDFCClassification");
            if (lbBDFCClassification.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeFaultCodeClassificationId == lbBDFCClassification.ToArray());
            }


            //Blade Fault Code Cause
            string[] lbBDFCCause = GetValueFromInput("CIRBDFCCause");
            if (lbBDFCCause.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeFaultCodeCauseId == lbBDFCCause.ToArray());
            }

            //Blade Fault Code Type

            string[] lbBDFCType = GetValueFromInput("CIRBDFCType");
            if (lbBDFCType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeFaultCodeTypeId == lbBDFCType.ToArray());

            }

            //Blade Fault Code Area
            string[] lbBDFCArea = GetValueFromInput("CIRBDFCArea");
            if (lbBDFCArea.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeFaultCodeAreaId == lbBDFCArea.ToArray());

            }

            // === Blade lighting system test begin ===
            string tbBDLSVTNumber = GetValueFromInput("CIRBDLSVTNumber").FirstOrDefault();
            if (tbBDLSVTNumber != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsVtNumber, tbBDLSVTNumber, typeof(string), false);
            }

            //Calibration Date
            DateTime dpBDLSCalibrationDateFrom = System.DateTime.MinValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRBDLSCalibrationDateFrom").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpBDLSCalibrationDateFrom))
            {

            }

            DateTime dpBDLSCalibrationDateTo = System.DateTime.MaxValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRBDLSCalibrationDateTo").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpBDLSCalibrationDateTo))
            {

            }

            if (dpBDLSCalibrationDateFrom > System.DateTime.MinValue || dpBDLSCalibrationDateTo > System.DateTime.MinValue)
            {
                if (dpBDLSCalibrationDateFrom > System.DateTime.MinValue && dpBDLSCalibrationDateTo == System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeLsCalibrationDate >= dpBDLSCalibrationDateFrom);
                }
                else if (dpBDLSCalibrationDateFrom == System.DateTime.MinValue && dpBDLSCalibrationDateTo > System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportBladeFields.BladeLsCalibrationDate <= dpBDLSCalibrationDateFrom);
                }
                else if (dpBDLSCalibrationDateFrom > System.DateTime.MinValue && dpBDLSCalibrationDateTo > System.DateTime.MinValue && dpBDLSCalibrationDateFrom > dpBDLSCalibrationDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportBladeFields.BladeLsCalibrationDate, null, dpBDLSCalibrationDateTo, dpBDLSCalibrationDateFrom));
                }
                else if (dpBDLSCalibrationDateFrom > System.DateTime.MinValue && dpBDLSCalibrationDateTo > System.DateTime.MinValue && dpBDLSCalibrationDateFrom < dpBDLSCalibrationDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportBladeFields.BladeLsCalibrationDate, null, dpBDLSCalibrationDateFrom, dpBDLSCalibrationDateTo));
                }
            }


            string tbBDLSLeewardSidePreRepairTip = GetValueFromInput("CIRBDLSLeewardSidePreRepairTip").FirstOrDefault();
            if (tbBDLSLeewardSidePreRepairTip != null && long.TryParse(tbBDLSLeewardSidePreRepairTip, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepairTip, tbBDLSLeewardSidePreRepairTip, typeof(long), false);
            }

            string tbBDLSLeewardSidePostRepairTip = GetValueFromInput("CIRBDLSLeewardSidePostRepairTip").FirstOrDefault();
            if (tbBDLSLeewardSidePostRepairTip != null && long.TryParse(tbBDLSLeewardSidePostRepairTip, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepairTip, tbBDLSLeewardSidePostRepairTip, typeof(long), false);
            }

            string tbBDLSLeewardSidePreRepair2 = GetValueFromInput("CIRBDLSLeewardSidePreRepair2").FirstOrDefault();
            if (tbBDLSLeewardSidePreRepair2 != null && long.TryParse(tbBDLSLeewardSidePreRepair2, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair2, tbBDLSLeewardSidePreRepair2, typeof(long), false);
            }

            string tbBDLSLeewardSidePostRepair2 = GetValueFromInput("CIRBDLSLeewardSidePostRepair2").FirstOrDefault();
            if (tbBDLSLeewardSidePostRepair2 != null && long.TryParse(tbBDLSLeewardSidePostRepair2, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair2, tbBDLSLeewardSidePostRepair2, typeof(long), false);
            }


            string tbBDLSLeewardSidePreRepair3 = GetValueFromInput("CIRBDLSLeewardSidePreRepair3").FirstOrDefault();
            if (tbBDLSLeewardSidePreRepair3 != null && long.TryParse(tbBDLSLeewardSidePreRepair3, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair3, tbBDLSLeewardSidePreRepair3, typeof(long), false);
            }


            string tbBDLSLeewardSidePostRepair3 = GetValueFromInput("CIRBDLSLeewardSidePostRepair3").FirstOrDefault();
            if (tbBDLSLeewardSidePostRepair3 != null && long.TryParse(tbBDLSLeewardSidePostRepair2, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair3, tbBDLSLeewardSidePostRepair3, typeof(long), false);
            }



            string tbBDLSLeewardSidePreRepair4 = GetValueFromInput("CIRBDLSLeewardSidePreRepair4").FirstOrDefault();
            if (tbBDLSLeewardSidePreRepair4 != null && long.TryParse(tbBDLSLeewardSidePreRepair4, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair4, tbBDLSLeewardSidePreRepair4, typeof(long), false);
            }


            string tbBDLSLeewardSidePostRepair4 = GetValueFromInput("CIRBDLSLeewardSidePostRepair4").FirstOrDefault();
            if (tbBDLSLeewardSidePostRepair4 != null && long.TryParse(tbBDLSLeewardSidePostRepair4, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair4, tbBDLSLeewardSidePostRepair4, typeof(long), false);
            }


            string tbBDLSLeewardSidePreRepair5 = GetValueFromInput("CIRBDLSLeewardSidePreRepair5").FirstOrDefault();
            if (tbBDLSLeewardSidePreRepair5 != null && long.TryParse(tbBDLSLeewardSidePreRepair5, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair5, tbBDLSLeewardSidePreRepair5, typeof(long), false);
            }


            string tbBDLSLeewardSidePostRepair5 = GetValueFromInput("CIRBDLSLeewardSidePostRepair5").FirstOrDefault();
            if (tbBDLSLeewardSidePostRepair5 != null && long.TryParse(tbBDLSLeewardSidePostRepair5, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair5, tbBDLSLeewardSidePostRepair5, typeof(long), false);
            }



            string tbBDLSWindwardSidePreRepairTip = GetValueFromInput("CIRBDLSWindwardSidePreRepairTip").FirstOrDefault();
            if (tbBDLSWindwardSidePreRepairTip != null && long.TryParse(tbBDLSWindwardSidePreRepairTip, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepairTip, tbBDLSWindwardSidePreRepairTip, typeof(long), false);
            }


            string tbBDLSWindwardSidePostRepairTip = GetValueFromInput("CIRBDLSWindwardSidePostRepairTip").FirstOrDefault();
            if (tbBDLSWindwardSidePostRepairTip != null && long.TryParse(tbBDLSWindwardSidePostRepairTip, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepairTip, tbBDLSWindwardSidePostRepairTip, typeof(long), false);
            }

            string tbBDLSWindwardSidePreRepair2 = GetValueFromInput("CIRBDLSWindwardSidePreRepair2").FirstOrDefault();
            if (tbBDLSWindwardSidePreRepair2 != null && long.TryParse(tbBDLSWindwardSidePreRepair2, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair2, tbBDLSWindwardSidePreRepair2, typeof(long), false);
            }

            string tbBDLSWindwardSidePostRepair2 = GetValueFromInput("CIRBDLSWindwardSidePostRepair2").FirstOrDefault();
            if (tbBDLSWindwardSidePostRepair2 != null && long.TryParse(tbBDLSWindwardSidePostRepair2, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair2, tbBDLSWindwardSidePostRepair2, typeof(long), false);
            }

            string tbBDLSWindwardSidePreRepair3 = GetValueFromInput("CIRBDLSWindwardSidePreRepair3").FirstOrDefault();
            if (tbBDLSWindwardSidePreRepair3 != null && long.TryParse(tbBDLSWindwardSidePreRepair3, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair3, tbBDLSWindwardSidePreRepair3, typeof(long), false);
            }


            string tbBDLSWindwardSidePostRepair3 = GetValueFromInput("CIRBDLSWindwardSidePostRepair3").FirstOrDefault();
            if (tbBDLSWindwardSidePostRepair3 != null && long.TryParse(tbBDLSWindwardSidePostRepair3, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair3, tbBDLSWindwardSidePostRepair3, typeof(long), false);
            }



            string tbBDLSWindwardSidePreRepair4 = GetValueFromInput("CIRBDLSWindwardSidePreRepair4").FirstOrDefault();
            if (tbBDLSWindwardSidePreRepair4 != null && long.TryParse(tbBDLSWindwardSidePreRepair4, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair4, tbBDLSWindwardSidePreRepair4, typeof(long), false);
            }


            string tbBDLSWindwardSidePostRepair4 = GetValueFromInput("CIRBDLSWindwardSidePostRepair4").FirstOrDefault();
            if (tbBDLSWindwardSidePostRepair4 != null && long.TryParse(tbBDLSWindwardSidePostRepair4, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair4, tbBDLSWindwardSidePostRepair4, typeof(long), false);
            }



            string tbBDLSWindwardSidePreRepair5 = GetValueFromInput("CIRBDLSWindwardSidePreRepair5").FirstOrDefault();
            if (tbBDLSWindwardSidePreRepair5 != null && long.TryParse(tbBDLSWindwardSidePreRepair5, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair5, tbBDLSWindwardSidePreRepair5, typeof(long), false);
            }


            string tbBDLSWindwardSidePostRepair5 = GetValueFromInput("CIRBDLSWindwardSidePostRepair5").FirstOrDefault();
            if (tbBDLSWindwardSidePostRepair5 != null && long.TryParse(tbBDLSWindwardSidePostRepair5, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair5, tbBDLSWindwardSidePostRepair5, typeof(long), false);
            }


            // === Blade lighting system test end ===


            //Blade Repair Record Ambient Temperature

            string tbBDAmbientTemp = GetValueFromInput("CIRBDAmbientTemp").FirstOrDefault();
            if (tbBDAmbientTemp != null && long.TryParse(tbBDAmbientTemp, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeAmbientTemp, tbBDAmbientTemp, typeof(long), false);
            }



            //Blade Repair Record Humidity

            string tbBDHumidity = GetValueFromInput("CIRBDHumidity").FirstOrDefault();
            if (tbBDHumidity != null && long.TryParse(tbBDHumidity, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeHumidity, tbBDHumidity, typeof(long), false);
            }


            //Blade Repair Record Additional Document Reference

            string tbBDDocumentReference = GetValueFromInput("CIRBDDocumentReference").FirstOrDefault();
            if (tbBDDocumentReference != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeAdditionalDocumentReference, tbBDDocumentReference, typeof(string), false);
            }

            //Blade Repair Record Resin Type

            string tbBDResinType = GetValueFromInput("CIRBDResinType").FirstOrDefault();
            if (tbBDResinType != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeResinType, tbBDResinType, typeof(string), false);
            }



            //Blade Repair Record Resin Type Batch No.
            string tbBDResinTypeBatchNo = GetValueFromInput("CIRBDResinTypeBatchNo").FirstOrDefault();
            if (tbBDResinTypeBatchNo != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeBatchNumbers, tbBDResinTypeBatchNo, typeof(string), false);
            }



            //Blade Repair Record Resin Type Expiry Date
            DateTime dpBDResinTypeExpiryDateFrom = System.DateTime.MinValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRBDResinTypeExpiryDateFrom").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpBDResinTypeExpiryDateFrom))
            {

            }

            DateTime dpBDResinTypeExpiryDateTo = System.DateTime.MaxValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRBDResinTypeExpiryDateTo").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpBDResinTypeExpiryDateTo))
            {

            }
            if (dpBDResinTypeExpiryDateFrom > System.DateTime.MinValue || dpBDResinTypeExpiryDateTo > System.DateTime.MinValue)
            {
                if (dpBDResinTypeExpiryDateFrom > System.DateTime.MinValue && dpBDResinTypeExpiryDateTo == System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeExpiryDate >= dpBDResinTypeExpiryDateFrom);
                }
                else if (dpBDResinTypeExpiryDateFrom == System.DateTime.MinValue && dpBDResinTypeExpiryDateTo > System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeExpiryDate <= dpBDResinTypeExpiryDateFrom);
                }
                else if (dpBDResinTypeExpiryDateFrom > System.DateTime.MinValue && dpBDResinTypeExpiryDateTo > System.DateTime.MinValue && dpBDResinTypeExpiryDateFrom > dpBDResinTypeExpiryDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeExpiryDate, null, dpBDResinTypeExpiryDateTo, dpBDResinTypeExpiryDateFrom));
                }
                else if (dpBDResinTypeExpiryDateFrom > System.DateTime.MinValue && dpBDResinTypeExpiryDateTo > System.DateTime.MinValue && dpBDResinTypeExpiryDateFrom < dpBDResinTypeExpiryDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeExpiryDate, null, dpBDResinTypeExpiryDateFrom, dpBDResinTypeExpiryDateTo));
                }
            }

            //Blade Repair Record Hardener Type
            string tbBDHardenerType = GetValueFromInput("CIRBDHardenerType").FirstOrDefault();
            if (tbBDHardenerType != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeHardenerType, tbBDHardenerType, typeof(string), false);
            }

            //Blade Repair Record Hardener Type Batch No.
            string tbBDHardenerTypeBatchNo = GetValueFromInput("CIRBDHardenerTypeBatchNo").FirstOrDefault();
            if (tbBDHardenerTypeBatchNo != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeBatchNumbers, tbBDHardenerTypeBatchNo, typeof(string), false);
            }

            //Blade Repair Record Hardener Type Expiry Date
            DateTime dpBDHardenerTypeExpiryDateFrom = System.DateTime.MinValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRBDHardenerTypeExpiryDateFrom").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpBDHardenerTypeExpiryDateFrom))
            {

            }

            DateTime dpBDHardenerTypeExpiryDateTo = System.DateTime.MaxValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRBDHardenerTypeExpiryDateTo").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpBDHardenerTypeExpiryDateTo))
            {

            }
            if (dpBDHardenerTypeExpiryDateFrom > System.DateTime.MinValue || dpBDHardenerTypeExpiryDateTo > System.DateTime.MinValue)
            {
                if (dpBDHardenerTypeExpiryDateFrom > System.DateTime.MinValue && dpBDHardenerTypeExpiryDateTo == System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate >= dpBDHardenerTypeExpiryDateFrom);
                }
                else if (dpBDHardenerTypeExpiryDateFrom == System.DateTime.MinValue && dpBDHardenerTypeExpiryDateTo > System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate <= dpBDHardenerTypeExpiryDateFrom);
                }
                else if (dpBDHardenerTypeExpiryDateFrom > System.DateTime.MinValue && dpBDHardenerTypeExpiryDateTo > System.DateTime.MinValue && dpBDHardenerTypeExpiryDateFrom > dpBDHardenerTypeExpiryDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate, null, dpBDHardenerTypeExpiryDateTo, dpBDHardenerTypeExpiryDateFrom));
                }
                else if (dpBDHardenerTypeExpiryDateFrom > System.DateTime.MinValue && dpBDHardenerTypeExpiryDateTo > System.DateTime.MinValue && dpBDHardenerTypeExpiryDateFrom < dpBDHardenerTypeExpiryDateTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate, null, dpBDHardenerTypeExpiryDateFrom, dpBDHardenerTypeExpiryDateTo));
                }
            }



            //Blade Repair Record Hardener Type Batch No.
            string tbBDGlassSupplier = GetValueFromInput("CIRBDGlassSupplier").FirstOrDefault();
            if (tbBDGlassSupplier != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeGlassSupplier, tbBDGlassSupplier, typeof(string), false);
            }


            //Blade Repair Record Glass Supplier Batch No.

            string tbBDGlassSupplierBatchNo = GetValueFromInput("CIRBDGlassSupplierBatchNo").FirstOrDefault();
            if (tbBDGlassSupplierBatchNo != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeGlassSupplierBatchNumbers, tbBDGlassSupplierBatchNo, typeof(string), false);
            }


            //Blade Repair Record Blade Surface Temperature During Lamination
            string tbBDSurfaceTempMin = GetValueFromInput("CIRBDSurfaceTempMin").FirstOrDefault();
            if (tbBDSurfaceTempMin != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeSurfaceMinTemperature, tbBDSurfaceTempMin, typeof(string), false);
            }

            //Blade Repair Record Blade Surface Temperature During Lamination
            string tbBDSurfaceTempMax = GetValueFromInput("CIRBDSurfaceTempMax").FirstOrDefault();
            if (tbBDSurfaceTempMax != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeSurfaceMaxTemperature, tbBDSurfaceTempMax, typeof(string), false);
            }


            //Blade Repair Record Quantity Of Resin Used

            string tbBDQuantityOfResin = GetValueFromInput("CIRBDQuantityOfResin").FirstOrDefault();
            if (tbBDQuantityOfResin != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeResinUsed, tbBDQuantityOfResin, typeof(string), false);
            }



            //Blade Repair Record Post Cure Temperature

            string tbBDPostCureSurfaceTempMin = GetValueFromInput("CIRBDPostCureSurfaceTempMin").FirstOrDefault();
            if (tbBDPostCureSurfaceTempMin != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladePostCureMinTemperature, tbBDPostCureSurfaceTempMin, typeof(string), false);
            }



            //Blade Repair Record Post Cure Temperature

            string tbBDPostCureSurfaceTempMax = GetValueFromInput("CIRBDPostCureSurfaceTempMax").FirstOrDefault();
            if (tbBDPostCureSurfaceTempMax != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladePostCureMaxTemperature, tbBDPostCureSurfaceTempMax, typeof(string), false);
            }



            //Blade Repair Record Heaters Etc. Off Date

            DateTime dpBDHeatersEtcOffFrom = System.DateTime.MinValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRBDHeatersEtcOffFrom").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpBDHeatersEtcOffFrom))
            {

            }

            DateTime dpBDHeatersEtcOffTo = System.DateTime.MaxValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRBDHeatersEtcOffTo").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpBDHeatersEtcOffTo))
            {

            }
            if (dpBDHeatersEtcOffFrom > System.DateTime.MinValue || dpBDHeatersEtcOffTo > System.DateTime.MinValue)
            {
                if (dpBDHeatersEtcOffFrom > System.DateTime.MinValue && dpBDHeatersEtcOffTo == System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate >= dpBDHeatersEtcOffFrom);
                }
                else if (dpBDHeatersEtcOffFrom == System.DateTime.MinValue && dpBDHeatersEtcOffTo > System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate <= dpBDHeatersEtcOffFrom);
                }
                else if (dpBDHeatersEtcOffFrom > System.DateTime.MinValue && dpBDHeatersEtcOffTo > System.DateTime.MinValue && dpBDHeatersEtcOffFrom > dpBDHeatersEtcOffTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate, null, dpBDHeatersEtcOffTo, dpBDHeatersEtcOffFrom));
                }
                else if (dpBDHeatersEtcOffFrom > System.DateTime.MinValue && dpBDHeatersEtcOffTo > System.DateTime.MinValue && dpBDHeatersEtcOffFrom < dpBDHeatersEtcOffTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate, null, dpBDHeatersEtcOffFrom, dpBDHeatersEtcOffTo));
                }
            }

            //Blade Repair Record Total Cure Time
            string tbBDTotalCureTime = GetValueFromInput("CIRBDTotalCureTime").FirstOrDefault();
            if (tbBDTotalCureTime != null && long.TryParse(tbBDTotalCureTime, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportBladeRepairRecordFields.BladeTotalCureTime, tbBDTotalCureTime, typeof(long), false);
            }
        }

        private static void CreateGearWhereClause(ref RelationPredicateBucket fb)
        {

            long lngParseResult = 0;
            fb.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportGearboxEntityUsingComponentInspectionReportId, JoinHint.Left);

            //Turbine Number
            //AddTurbineNumberPredicate(tbWTDTurbineNo2, fb);
            string tbWTDTurbineNo2 = GetValueFromInput("CIRWTDTurbineNo2").FirstOrDefault();

            AddTurbineNumberPredicate(ref tbWTDTurbineNo2, ref fb);



            //Gear Type
            string[] lbGDGearType = GetValueFromInput("CIRGDGearType");
            if (lbGDGearType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxTypeId == lbGDGearType.ToArray());
            }

            //Other Gear Type

            string[] tbGDOtherGearType = GetValueFromInput("CIRGDOtherGearType");
            if (tbGDOtherGearType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.OtherGearboxType == tbGDOtherGearType.ToArray());
            }

            //Gear Revision

            string[] lbGDGearRevision = GetValueFromInput("CIRGDGearRevision");
            if (lbGDGearRevision.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxRevisionId == lbGDGearRevision.ToArray());
            }

            //Gear Manufacturer
            string[] lbGDGearManufacturer = GetValueFromInput("CIRGDGearManufacturer");
            if (lbGDGearManufacturer.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxManufacturerId == lbGDGearManufacturer.ToArray());
            }


            //Gear Other Manufacturer

            string tbGDGearOtherManufacturer = GetValueFromInput("CIRGDGearOtherManufacturer").FirstOrDefault();
            if (tbGDGearOtherManufacturer != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGearboxFields.GearboxOtherManufacturer, tbGDGearOtherManufacturer, typeof(long), false);
            }

            //Gear Serial Number

            string tbGDGearSerialNumber = GetValueFromInput("CIRGDGearSerialNumber").FirstOrDefault();
            if (tbGDGearSerialNumber != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGearboxFields.GearboxSerialNumber, tbGDGearSerialNumber, typeof(string), false);
            }

            // Gear mounted on main component

            string[] lbGDGearMountedOnMainComponent = GetValueFromInput("CIRGDGearMountedOnMainComponent");
            if (lbGDGearMountedOnMainComponent.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId == lbGDGearMountedOnMainComponent.ToArray());
            }
            //AddListboxPredicate(lbGDGearMountedOnMainComponent, ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId, fb);



            //Gear Oil Type

            string[] lbGDGearOilType = GetValueFromInput("CIRGDGearOilType");
            if (lbGDGearOilType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxOilTypeId == lbGDGearOilType.ToArray());
            }

            //Gear Mechanical Oil Pump

            string[] lbGDGearMechOilPump = GetValueFromInput("CIRGDGearMechanicalOilPump");
            if (lbGDGearMechOilPump.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxMechanicalOilPumpId == lbGDGearMechOilPump.ToArray());
            }

            ////Gear Oil Level
            string[] lbGDGearOilLevel = GetValueFromInput("CIRGDGearOilLevel");
            if (lbGDGearOilLevel.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxOilLevelId == lbGDGearOilLevel.ToArray());
            }



            //Gear Production

            string tbGDGearProduction = GetValueFromInput("CIRGDGearProduction").FirstOrDefault();
            if (tbGDGearProduction != null && long.TryParse(tbGDGearProduction, out lngParseResult))
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGearboxFields.GearboxProduction, tbGDGearProduction, typeof(long), false);
                //AddTurbineNumberPredicate(ref tbGDGearProduction, ref fb);
            }


            //Gear Generator Manufacturer

            string[] lbGDGearGeneratorManufacturer = GetValueFromInput("CIRGDGearGeneratorManufacturer");
            if (lbGDGearGeneratorManufacturer.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId == lbGDGearGeneratorManufacturer.ToArray());
            }

            //Gear Second Generator Manufacturer

            string[] lbGDGearSecondGeneratorManufacturer = GetValueFromInput("CIRGDGearSecondGeneratorManufacturer");
            if (lbGDGearSecondGeneratorManufacturer.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId2 == lbGDGearSecondGeneratorManufacturer.ToArray());
            }

            ////Gear Electrical Pump

            string[] lbGDGearElectricalPump = GetValueFromInput("CIRGDGearElectricalPump");
            if (lbGDGearElectricalPump.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxElectricalPumpId == lbGDGearElectricalPump.ToArray());
            }

            //Gear Shrink Element

            string[] lbGDGearShrinkElement = GetValueFromInput("CIRGDGearShrinkElement");
            if (lbGDGearShrinkElement.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxElectricalPumpId == lbGDGearShrinkElement.ToArray());
            }

            //Gear Shrink Element Serial Number

            string tbGDGearShrinkElementSerialNumber = GetValueFromInput("CIRGDGearShrinkElementSerialNumber").FirstOrDefault();
            if (tbGDGearShrinkElementSerialNumber != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGearboxFields.GearboxShrinkElementSerialNumber, tbGDGearShrinkElementSerialNumber, typeof(string), false);
                //AddTurbineNumberPredicate(ref tbGDGearProduction, ref fb);
            }


            //Gear Coupling
            string[] lbGDGearCoupling = GetValueFromInput("CIRGDGearCoupling");
            if (lbGDGearCoupling.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxCouplingId == lbGDGearCoupling.ToArray());
            }

            //Gear Filter Block Type
            string[] lbGDGearFilterBlockType = GetValueFromInput("CIRGDGearFilterBlockType");
            if (lbGDGearFilterBlockType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxFilterBlockTypeId == lbGDGearFilterBlockType.ToArray());
            }

            ////Gear In Line Filter
            string[] lbGDGearInLineFilter = GetValueFromInput("CIRGDGearInLineFilter");
            if (lbGDGearInLineFilter.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxInLineFilterId == lbGDGearInLineFilter.ToArray());
            }

            //Gear Off Line Filter
            string[] lbGDGearOffLineFilter = GetValueFromInput("CIRGDGearOffLineFilter");
            if (lbGDGearOffLineFilter.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxOffLineFilterId == lbGDGearOffLineFilter.ToArray());
            }

            //Gear Software Release
            string tbGDGearSoftwareRelease = GetValueFromInput("CIRGDGearShrinkElementSerialNumber").FirstOrDefault();
            if (tbGDGearSoftwareRelease != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGearboxFields.GearboxSoftwareRelease, tbGDGearSoftwareRelease, typeof(string), false);
            }

            ////Gear Shaft Location
            string[] lbGDGearShaftLocation = GetValueFromInput("CIRGDGearShaftLocation");
            if (lbGDGearShaftLocation.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation1ShaftTypeId == lbGDGearShaftLocation.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation2ShaftTypeId == lbGDGearShaftLocation.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation3ShaftTypeId == lbGDGearShaftLocation.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation4ShaftTypeId == lbGDGearShaftLocation.ToArray());
            }

            ////Gear Shaft Damage Type
            string[] lbGDGearShaftDamageType = GetValueFromInput("CIRGDGearShaftDamageType");
            if (lbGDGearShaftDamageType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage1ShaftErrorId == lbGDGearShaftDamageType.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage2ShaftErrorId == lbGDGearShaftDamageType.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage3ShaftErrorId == lbGDGearShaftDamageType.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage4ShaftErrorId == lbGDGearShaftDamageType.ToArray());
            }

            //Gear Location
            string[] lbGDGearLocation = GetValueFromInput("CIRGDGearLocation");
            if (lbGDGearLocation.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxExactLocation1GearTypeId == lbGDGearLocation.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxExactLocation2GearTypeId == lbGDGearLocation.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxExactLocation3GearTypeId == lbGDGearLocation.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxExactLocation4GearTypeId == lbGDGearLocation.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxExactLocation5GearTypeId == lbGDGearLocation.ToArray());
            }


            ////Gear Damage Type

            string[] lbGDGearDamageType = GetValueFromInput("CIRGDGearDamageType");
            if (lbGDGearDamageType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxTypeofDamage1GearErrorId == lbGDGearDamageType.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxTypeofDamage2GearErrorId == lbGDGearDamageType.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxTypeofDamage3GearErrorId == lbGDGearDamageType.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxTypeofDamage4GearErrorId == lbGDGearDamageType.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxTypeofDamage5GearErrorId == lbGDGearDamageType.ToArray());
            }

            //Gear Bearing Location

            string[] lbGDGearBearingLocation = GetValueFromInput("CIRGDGearBearingLocation");
            if (lbGDGearBearingLocation.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsLocation1BearingTypeId == lbGDGearBearingLocation.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsLocation2BearingTypeId == lbGDGearBearingLocation.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsLocation3BearingTypeId == lbGDGearBearingLocation.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsLocation4BearingTypeId == lbGDGearBearingLocation.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsLocation5BearingTypeId == lbGDGearBearingLocation.ToArray());
            }


            ////Gear Bearing Position

            string[] lbGDGearBearingPosition = GetValueFromInput("CIRGDGearBearingLocation");
            if (lbGDGearBearingPosition.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition1BearingPosId == lbGDGearBearingPosition.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition2BearingPosId == lbGDGearBearingPosition.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition3BearingPosId == lbGDGearBearingPosition.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition4BearingPosId == lbGDGearBearingPosition.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition5BearingPosId == lbGDGearBearingPosition.ToArray());
            }


            //Gear Bearing Damage Type

            string[] lbGDGearBearingDamageType = GetValueFromInput("CIRGDGearBearingDamageType");
            if (lbGDGearBearingDamageType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition1BearingPosId == lbGDGearBearingDamageType.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition2BearingPosId == lbGDGearBearingDamageType.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition3BearingPosId == lbGDGearBearingDamageType.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition4BearingPosId == lbGDGearBearingDamageType.ToArray());
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition5BearingPosId == lbGDGearBearingDamageType.ToArray());
            }

            //Gear Housing Planet Stage 1

            string[] lbGDGearHousingPlanetStage1 = GetValueFromInput("CIRGDGearHousingPlanetStage1");
            if (lbGDGearHousingPlanetStage1.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition1BearingPosId == lbGDGearHousingPlanetStage1.ToArray());
            }

            //Gear Housing Planet Stage 2

            string[] lbGDGearHousingPlanetStage2 = GetValueFromInput("CIRGDGearHousingPlanetStage2");
            if (lbGDGearHousingPlanetStage2.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxHelicalStageHousingErrorId == lbGDGearHousingPlanetStage2.ToArray());
            }

            //Gear Housing Stage
            string[] lbGDGearHousingStage = GetValueFromInput("CIRGDGearHousingStage");
            if (lbGDGearHousingStage.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxHelicalStageHousingErrorId == lbGDGearHousingStage.ToArray());
            }


            ////Gear Housing Front Plate

            string[] lbGDGearHousingFrontPlate = GetValueFromInput("CIRGDGearHousingFrontPlate");
            if (lbGDGearHousingFrontPlate.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxFrontPlateHousingErrorId == lbGDGearHousingFrontPlate.ToArray());
            }


            //Gear Housing Auxilary Stage

            string[] lbGDGearHousingAuxilaryStage = GetValueFromInput("CIRGDGearHousingAuxilaryStage");
            if (lbGDGearHousingAuxilaryStage.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxAuxStageHousingErrorId == lbGDGearHousingAuxilaryStage.ToArray());
            }


            ////Gear Housing HS Stage

            string[] lbGDGearHousingHSStage = GetValueFromInput("CIRGDGearHousingHSStage");
            if (lbGDGearHousingHSStage.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxHsstageHousingErrorId == lbGDGearHousingHSStage.ToArray());
            }


            ////Gear Torque Loose Bolts
            string[] lbGDGearTorqueLooseBolts = GetValueFromInput("CIRGDGearTorqueLooseBolts");
            if (lbGDGearTorqueLooseBolts.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxLooseBolts == lbGDGearTorqueLooseBolts.ToArray());
            }


            ////Gear Torque Broken Bolts
            string[] lbGDGearTorqueBrokenBolts = GetValueFromInput("CIRGDGearTorqueBrokenBolts");
            if (lbGDGearTorqueBrokenBolts.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxBrokenBolts == lbGDGearTorqueBrokenBolts.ToArray());
            }

            //Gear Torque Defect Damper
            string[] lbGDGearTorqueDefectDamper = GetValueFromInput("CIRGDGearTorqueDefectDamper");
            if (lbGDGearTorqueDefectDamper.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxDefectDamperElements == lbGDGearTorqueDefectDamper.ToArray());
            }

            //Gear Torque Too Much Clearance

            string[] lbGDGearTorqueTooMuchClearance = GetValueFromInput("CIRGDGearTorqueTooMuchClearance");
            if (lbGDGearTorqueTooMuchClearance.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxTooMuchClearance == lbGDGearTorqueTooMuchClearance.ToArray());
            }

            //Gear Torque Cracked Broken
            string[] lbGDGearTorqueCrackedBroken = GetValueFromInput("CIRGDGearTorqueCrackedBroken");
            if (lbGDGearTorqueCrackedBroken.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxCrackedTorqueArm == lbGDGearTorqueCrackedBroken.ToArray());
            }

            ////Gear Torque Needs Alignment

            string[] lbGDGearTorqueNeedsAlignment = GetValueFromInput("CIRGDGearTorqueNeedsAlignment");
            if (lbGDGearTorqueNeedsAlignment.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxNeedsToBeAligned == lbGDGearTorqueNeedsAlignment.ToArray());
            }


            //Gear Defect Acc. PT100 Bearing 1

            string[] lbGDGearDefectAccPT100Bearing1 = GetValueFromInput("CIRGDGearDefectAccPT100Bearing1");
            if (lbGDGearDefectAccPT100Bearing1.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing1 == lbGDGearDefectAccPT100Bearing1.ToArray());
            }


            //Gear Defect Acc. PT100 Bearing 2

            string[] lbGDGearDefectAccPT100Bearing2 = GetValueFromInput("CIRGDGearDefectAccPT100Bearing2");
            if (lbGDGearDefectAccPT100Bearing2.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing2 == lbGDGearDefectAccPT100Bearing2.ToArray());
            }

            //Gear Defect Acc. PT100 Bearing 3


            string[] lbGDGearDefectAccPT100Bearing3 = GetValueFromInput("CIRGDGearDefectAccPT100Bearing3");
            if (lbGDGearDefectAccPT100Bearing3.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing3 == lbGDGearDefectAccPT100Bearing3.ToArray());
            }


            ////Gear Defect Acc. Oil Level Sensor

            string[] lbgdgeardefectaccoillevelsensor = GetValueFromInput("CIRGDGearDefectAccOilLevelSensor");
            if (lbgdgeardefectaccoillevelsensor.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxOilLevelSensor == lbgdgeardefectaccoillevelsensor.ToArray());
            }


            ////Gear Defect Acc. Oil Pressure

            string[] lbGDGearDefectAccOilPressure = GetValueFromInput("CIRGDGearDefectAccOilPressure");
            if (lbGDGearDefectAccOilPressure.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxOilPressure == lbGDGearDefectAccOilPressure.ToArray());
            }

            ////Gear Defect Acc. PT100 Oil Sump
            string[] lbGDGearDefectAccPT100OilSump = GetValueFromInput("CIRGDGearDefectAccPT100OilSump");
            if (lbGDGearDefectAccPT100OilSump.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxPt100OilSump == lbGDGearDefectAccPT100OilSump.ToArray());
            }

            ////Gear Defect Acc. Filter Indicator
            string[] lbGDGearDefectAccFilterIndicator = GetValueFromInput("CIRGDGearDefectAccFilterIndicator");
            if (lbGDGearDefectAccFilterIndicator.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxFilterIndicator == lbGDGearDefectAccFilterIndicator.ToArray());
            }


            ////Gear Defect Acc. Immersion Heater

            string[] lbGDGearDefectAccImmersionHeater = GetValueFromInput("CIRGDGearDefectAccImmersionHeater");
            if (lbGDGearDefectAccImmersionHeater.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxImmersionHeater == lbGDGearDefectAccImmersionHeater.ToArray());
            }


            ////Gear Defect Acc. Drain Valve

            string[] lbGDGearDefectAccDrainValve = GetValueFromInput("CIRGDGearDefectAccDrainValve");
            if (lbGDGearDefectAccDrainValve.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxDrainValve == lbGDGearDefectAccDrainValve.ToArray());
            }

            ////Gear Defect Acc. Air Breather

            string[] lbGDGearDefectAccAirBreather = GetValueFromInput("CIRGDGearDefectAccAirBreather");
            if (lbGDGearDefectAccAirBreather.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxAirBreather == lbGDGearDefectAccAirBreather.ToArray());
            }


            ////Gear Defect Acc. Sight Glass
            string[] lbGDGearDefectAccSightGlass = GetValueFromInput("CIRGDGearDefectAccSightGlass");
            if (lbGDGearDefectAccSightGlass.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxSightGlass == lbGDGearDefectAccSightGlass.ToArray());
            }


            ////Gear Defect Acc. Chip Detector

            string[] lbGDGearDefectAccChipDetector = GetValueFromInput("CIRGDGearDefectAccChipDetector");
            if (lbGDGearDefectAccChipDetector.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxChipDetector == lbGDGearDefectAccChipDetector.ToArray());
            }

            ////Gear Symptoms Vibrations

            string[] lbGDGearSymptomsVibrations = GetValueFromInput("CIRGDGearSymptomsVibrations");
            if (lbGDGearSymptomsVibrations.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxVibrationsId == lbGDGearSymptomsVibrations.ToArray());
            }


            ////Gear Symptoms Noise

            string[] lbGDGearSymptomsNoise = GetValueFromInput("CIRGDGearSymptomsNoise");
            if (lbGDGearSymptomsNoise.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxNoiseId == lbGDGearSymptomsNoise.ToArray());
            }


            ////Gear Symptoms Debris On Magnet

            string[] lbGDGearSymptomsDebrisOnMagnet = GetValueFromInput("CIRGDGearSymptomsDebrisOnMagnet");
            if (lbGDGearSymptomsDebrisOnMagnet.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxDebrisOnMagnetId == lbGDGearSymptomsDebrisOnMagnet.ToArray());
            }

            ////Gear Symptoms Magnet Position

            string[] lbGDGearSymptomsMagnetPosition = GetValueFromInput("CIRGDGearSymptomsMagnetPosition");
            if (lbGDGearSymptomsMagnetPosition.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxDebrisStagesMagnetPosId == lbGDGearSymptomsMagnetPosition.ToArray());
            }


            ////Gear Symptoms Debris In Gearbox

            string[] lbGDGearSymptomsDebrisInGearbox = GetValueFromInput("CIRGDGearSymptomsDebrisInGearbox");
            if (lbGDGearSymptomsDebrisInGearbox.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxDebrisGearBoxId == lbGDGearSymptomsDebrisInGearbox.ToArray());
            }

            ////Gear Overall Gearbox Condition
            string[] lbGDGearSymptomsOverallGearboxCondition = GetValueFromInput("CIRGDGearSymptomsOverallGearboxCondition");
            if (lbGDGearSymptomsOverallGearboxCondition.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxDebrisGearBoxId == lbGDGearSymptomsOverallGearboxCondition.ToArray());
            }


            ////Gear Leakage LSS NR End
            string[] lbGDGearLeakageLSSNREnd = GetValueFromInput("CIRGDGearLeakageLSSNREnd");
            if (lbGDGearLeakageLSSNREnd.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxLssnrend == lbGDGearLeakageLSSNREnd.ToArray());
            }


            ////Gear Leakage IMS NR End
            string[] lbGDGearLeakageIMSNREnd = GetValueFromInput("CIRGDGearLeakageIMSNREnd");
            if (lbGDGearLeakageIMSNREnd.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxImsnrend == lbGDGearLeakageIMSNREnd.ToArray());
            }


            ////Gear Leakage IMS R End

            string[] lbGDGearLeakageIMSREnd = GetValueFromInput("CIRGDGearLeakageIMSREnd");
            if (lbGDGearLeakageIMSREnd.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxImsrend == lbGDGearLeakageIMSREnd.ToArray());
            }


            ////Gear Leakage HSS NR End

            string[] lbGDGearLeakageHSSNREnd = GetValueFromInput("CIRGDGearLeakageHSSNREnd");
            if (lbGDGearLeakageHSSNREnd.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxImsrend == lbGDGearLeakageHSSNREnd.ToArray());
            }


            ////Gear Leakage HSS R End
            string[] lbGDGearLeakageHSSREnd = GetValueFromInput("CIRGDGearLeakageHSSREnd");
            if (lbGDGearLeakageHSSREnd.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxHssrend == lbGDGearLeakageHSSREnd.ToArray());
            }

            //Gear Leakage Pitch Tube
            string[] lbGDGearLeakagePitchTube = GetValueFromInput("CIRGDGearLeakagePitchTube");
            if (lbGDGearLeakagePitchTube.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxPitchTube == lbGDGearLeakagePitchTube.ToArray());
            }

            ////Gear Leakage Split Lines

            string[] lbGDGearLeakageSplitLines = GetValueFromInput("CIRGDGearLeakageSplitLines");
            if (lbGDGearLeakageSplitLines.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxPitchTube == lbGDGearLeakageSplitLines.ToArray());
            }

            ////Gear Leakage Hose Piping
            string[] lbGDGearLeakageHosePiping = GetValueFromInput("CIRGDGearLeakageHosePiping");
            if (lbGDGearLeakageHosePiping.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxHoseAndPiping == lbGDGearLeakageHosePiping.ToArray());
            }


            ////Gear Leakage Input Shaft

            string[] lbGDGearLeakageInputShaft = GetValueFromInput("CIRGDGearLeakageInputShaft");
            if (lbGDGearLeakageInputShaft.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxInputShaft == lbGDGearLeakageInputShaft.ToArray());
            }

            ////Gear Leakage Aux. HSS/PTO

            string[] lbGDGearLeakageAuxHSSPTO = GetValueFromInput("CIRGDGearLeakageAuxHSSPTO");
            if (lbGDGearLeakageAuxHSSPTO.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGearboxFields.GearboxHsspto == lbGDGearLeakageAuxHSSPTO.ToArray());
            }
        }

        private static void CreateGeneralWhereClause(ref RelationPredicateBucket fb)
        {


            fb.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportGeneralEntityUsingComponentInspectionReportId, JoinHint.Left);

            //Turbine Number
            string tbWTDTurbineNo3 = GetValueFromInput("CIRWTDTurbineNo3").FirstOrDefault();
            AddTurbineNumberPredicate(ref tbWTDTurbineNo3, ref fb);

            //General Comp. Group
            string lbGeneralComponentGroup = GetValueFromInput("CIRGCGeneralCompGroup").FirstOrDefault();
            if (lbGeneralComponentGroup != null && lbGeneralComponentGroup.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGeneralFields.GeneralComponentGroupId == lbGeneralComponentGroup.ToArray());

            }

            //General Comp. Type
            string tbGeneralComponentType = GetValueFromInput("CIRGCGeneralCompType").FirstOrDefault();
            if (tbGeneralComponentType != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralComponentType, tbGeneralComponentType, typeof(string), false);
            }

            //General Comp. Manufact.
            string tbGeneralComponentManufacturer = GetValueFromInput("CIRGCGeneralCompManufact").FirstOrDefault();
            if (tbGeneralComponentManufacturer != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralComponentManufacturer, tbGeneralComponentManufacturer, typeof(string), false);
            }

            //General Other Gearbox Type
            string tbGeneralOtherGearboxType = GetValueFromInput("CIRGCGeneralOtherGearboxType").FirstOrDefault();
            if (tbGeneralOtherGearboxType != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralOtherGearboxType, tbGeneralOtherGearboxType, typeof(string), false);
            }



            //General Other Gearbox Manufact.
            string tbGeneralOtherGearboxManufacturer = GetValueFromInput("CIRGCGeneralOtherGearboxManufact").FirstOrDefault();
            if (tbGeneralOtherGearboxManufacturer != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralOtherGearboxManufacturer, tbGeneralOtherGearboxManufacturer, typeof(string), false);
            }

            //General Comp. Ser. No.
            string tbGeneralComponentSerialNumber = GetValueFromInput("CIRGCtbGeneralCompSerNo").FirstOrDefault();
            if (tbGeneralComponentSerialNumber != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralComponentSerialNumber, tbGeneralComponentSerialNumber, typeof(string), false);
            }

            //General Generator Manufact.
            string[] lbGeneralGeneratorManufacturer = GetValueFromInput("CIRGCGeneralGeneratorManufact");
            if (lbGeneralGeneratorManufacturer != null && lbGeneralGeneratorManufacturer.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGeneralFields.GeneralGeneratorManufacturerId == lbGeneralGeneratorManufacturer.ToArray());
            }

            //General Transf. Manufact.
            string[] lbGeneralTransformerManufacturer = GetValueFromInput("CIRGCGeneralTransfManufact");
            if (lbGeneralTransformerManufacturer != null && lbGeneralTransformerManufacturer.Length > 0)
            {

                fb.PredicateExpression.Add(ComponentInspectionReportGeneralFields.GeneralTransformerManufacturerId == lbGeneralTransformerManufacturer.ToArray());
            }

            //General Gearbox Manufact.
            string[] lbGeneralGearboxManufacturer = GetValueFromInput("CIRGCGeneralGearboxManufact");
            if (lbGeneralGearboxManufacturer != null && lbGeneralGearboxManufacturer.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGeneralFields.GeneralGearboxManufacturerId == lbGeneralGearboxManufacturer.ToArray());

            }

            //General Tower Type
            string[] lbGeneralTowerType = GetValueFromInput("CIRGCGeneralTowerType");
            if (lbGeneralTowerType != null && lbGeneralTowerType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGeneralFields.GeneralTowerTypeId == lbGeneralTowerType.ToArray());
            }

            //General Tower Height
            string[] lbGeneralTowerHeight = GetValueFromInput("CIRGCGeneralTowerHeight");
            if (lbGeneralTowerHeight != null && lbGeneralTowerHeight.Length > 0)
            {

                fb.PredicateExpression.Add(ComponentInspectionReportGeneralFields.GeneralTowerHeightId == lbGeneralTowerHeight.ToArray());
            }

            //General Blade Ser. No.
            // AndAlso long.TryParse(tbGeneralBladeSerialNumber.Text, lngParseResult) Then
            string tbGeneralBladeSerialNumber = GetValueFromInput("CIRGCtbGeneralBladeSerNo").FirstOrDefault();
            if (tbGeneralBladeSerialNumber != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralBlade1SerialNumber, tbGeneralBladeSerialNumber, typeof(string), true);
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralBlade2SerialNumber, tbGeneralBladeSerialNumber, typeof(string), true);
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralBlade3SerialNumber, tbGeneralBladeSerialNumber, typeof(string), true);
            }

            //General Ctrl. Type
            string[] lbGeneralControllerType = GetValueFromInput("CIRGCGeneralCtrlType");
            if (lbGeneralControllerType != null && lbGeneralControllerType.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGeneralFields.GeneralControllerTypeId == lbGeneralControllerType.ToArray());

            }

            //General Soft. Rel.
            string tbGeneralSoftwareRelease = GetValueFromInput("CIRGCtbGeneralSoftRel").FirstOrDefault();
            if (tbGeneralSoftwareRelease != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralSoftwareRelease, tbGeneralSoftwareRelease, typeof(string), false);
            }

            //General Ram Dump No.
            string tbGeneralRamDumpNumber = GetValueFromInput("CIRGCtbGeneralRamDumpNo").FirstOrDefault();
            if (tbGeneralRamDumpNumber != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralRamDumpNumber, tbGeneralRamDumpNumber, typeof(long), false);
            }

            //General VDF Track No.
            string tbGeneralVDFTrackNumber = GetValueFromInput("CIRGCtbGeneralVDFTrackNo").FirstOrDefault();
            if (tbGeneralVDFTrackNumber != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralVdftrackNumber, tbGeneralVDFTrackNumber, typeof(long), false);
            }

            //General Pics. Att.
            string[] lbGeneralPicturesAttached = GetValueFromInput("CIRGCGeneralPicsAtt");
            if (lbGeneralPicturesAttached != null && lbGeneralPicturesAttached.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGeneralFields.GeneralPicturesIncludedBooleanAnswerId == lbGeneralPicturesAttached.ToArray());

            }

            // General Initiated By
            string tbGeneralInitiatedBy = GetValueFromInput("CIRGCGeneralInitiatedBy").FirstOrDefault();
            if (tbGeneralInitiatedBy != null)
            {
                RelationPredicateBucket filterBucket = new RelationPredicateBucket();
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralInitiatedBy1, tbGeneralInitiatedBy, typeof(string), true);
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralInitiatedBy2, tbGeneralInitiatedBy, typeof(string), true);
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralInitiatedBy3, tbGeneralInitiatedBy, typeof(string), true);
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralInitiatedBy4, tbGeneralInitiatedBy, typeof(string), true);
                fb.PredicateExpression.Add(filterBucket.PredicateExpression);
            }
            // General Measurements Conducted By
            string tbGeneralMeasurementsConducted = GetValueFromInput("CIRGCGeneralMeasurementsConducted").FirstOrDefault();
            if (tbGeneralMeasurementsConducted != null)
            {
                RelationPredicateBucket filterBucket = new RelationPredicateBucket();
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralMeasurementsConducted1, tbGeneralMeasurementsConducted, typeof(string), true);
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralMeasurementsConducted2, tbGeneralMeasurementsConducted, typeof(string), true);
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralMeasurementsConducted3, tbGeneralMeasurementsConducted, typeof(string), true);
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralMeasurementsConducted4, tbGeneralMeasurementsConducted, typeof(string), true);
                fb.PredicateExpression.Add(filterBucket.PredicateExpression);
            }
            // General Executed By
            string tbGeneralExecutedBy = GetValueFromInput("CIRGCGeneralExecutedBy").FirstOrDefault();
            if (tbGeneralExecutedBy != null)
            {
                RelationPredicateBucket filterBucket = new RelationPredicateBucket();
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralExecutedBy1, tbGeneralExecutedBy, typeof(string), true);
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralExecutedBy2, tbGeneralExecutedBy, typeof(string), true);
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralExecutedBy3, tbGeneralExecutedBy, typeof(string), true);
                AddPredicateToBucket(ref filterBucket, ComponentInspectionReportGeneralFields.GeneralExecutedBy4, tbGeneralExecutedBy, typeof(string), true);
                fb.PredicateExpression.Add(filterBucket.PredicateExpression);
            }

            //Position Of Failed Item
            string tbGeneralPositionOfFailedItem = GetValueFromInput("CIRGCGeneralPositionOfFailedItem").FirstOrDefault();
            if (tbGeneralPositionOfFailedItem != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneralFields.GeneralPositionOfFailedItem, tbGeneralPositionOfFailedItem, typeof(string), false);
            }

        }

        private static void CreateGeneratorWhereClause(ref RelationPredicateBucket fb)
        {

            fb.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportId, JoinHint.Left);

            //Turbine Number
            string tbWTDTurbineNo4 = GetValueFromInput("CIRWTDTurbineNo4").FirstOrDefault();
            AddTurbineNumberPredicate(ref tbWTDTurbineNo4, ref fb);


            //Generator Manufacturer
            string[] lbGeneratorManufacturer = GetValueFromInput("CIRGEGeneratorManufacturer");
            if (lbGeneratorManufacturer.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportGeneratorFields.GeneratorManufacturerId == lbGeneratorManufacturer.ToArray());

            }

            //Generator Other Manufacturer
            string lbGeneratorOtherManufacturer = GetValueFromInput("CIRGEGeneratorOtherManufacturer").FirstOrDefault();
            if (lbGeneratorOtherManufacturer != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.OtherManufacturer, lbGeneratorOtherManufacturer, typeof(string), false);
            }

            //Generator Ser. No.
            string tbGeneratorSerialNumber = GetValueFromInput("CIRGEGeneratorSerialNumber").FirstOrDefault();
            if (tbGeneratorSerialNumber != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.GeneratorSerialNumber, tbGeneratorSerialNumber, typeof(string), false);
            }

            // Generator mounted on main component
            string[] lbGeneratorMountedOnMainComponent = GetValueFromInput("CIRGEGeneratorMountedOnMainComponent");
            if (lbGeneratorMountedOnMainComponent.Length > 0)
            {
                fb.PredicateExpression.Add(ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId == lbGeneratorMountedOnMainComponent.ToArray());

            }

            //Generator Comment
            string tbGeneratorComment = GetValueFromInput("CIRGEGeneratorComment").FirstOrDefault();
            if (tbGeneratorComment != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.GeneratorComments, tbGeneratorComment, typeof(string), false);
            }

            //Generator Rew. Locally
            string[] lbGeneratorRewoundLocally = GetValueFromInput("CIRGEGeneratorRewoundLocally");
            if (lbGeneratorRewoundLocally.Length > 0)
            {

                fb.PredicateExpression.Add(ComponentInspectionReportGeneratorFields.GeneratorRewoundLocally == lbGeneratorRewoundLocally.ToArray());
            }

            //Generator Max Temperature
            string tbGeneratorMaxTemperature = GetValueFromInput("CIRGEGeneratorMaxTemperature").FirstOrDefault();
            if (tbGeneratorMaxTemperature != null)
            {
                decimal maxTemperature = default(decimal);
                if (decimal.TryParse(tbGeneratorMaxTemperature, out maxTemperature))
                {
                    fb.PredicateExpression.Add(ComponentInspectionReportGeneratorFields.GeneratorMaxTemperature == maxTemperature);
                }
            }


            //Generator Max Temperature Reset Date            
            DateTime tbGeneratorMaxTemperatureFrom = System.DateTime.MinValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRGEGeneratorMaxTemperatureResetDateFrom").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tbGeneratorMaxTemperatureFrom))
            {

            }

            DateTime tbGeneratorMaxTemperatureTo = System.DateTime.MaxValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRGEGeneratorMaxTemperatureResetDateTo").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tbGeneratorMaxTemperatureTo))
            {

            }
            AddDatePredicate(ref tbGeneratorMaxTemperatureFrom, ref tbGeneratorMaxTemperatureTo, ComponentInspectionReportGeneratorFields.GeneratorMaxTemperatureResetDate, ref fb);

            //Generator Action To Be Taken

            string[] lbGeneratorActionToBeTaken = GetValueFromInput("CIRGEGeneratorActionToBeTaken");
            AddListboxPredicate(lbGeneratorActionToBeTaken, ComponentInspectionReportGeneratorFields.ActionToBeTakenOnGeneratorId, ref fb);
            //Generator Drive End

            string[] lbGeneratorDriveEnd = GetValueFromInput("CIRGEGeneratorDriveEnd");
            AddListboxPredicate(lbGeneratorDriveEnd, ComponentInspectionReportGeneratorFields.GeneratorDriveEndId, ref fb);
            //Generator Non Drive End

            string[] lbGeneratorNonDriveEnd = GetValueFromInput("CIRGEGeneratorNonDriveEnd");
            AddListboxPredicate(lbGeneratorNonDriveEnd, ComponentInspectionReportGeneratorFields.GeneratorNonDriveEndId, ref fb);
            //Generator Rotor

            string[] lbGeneratorRotor = GetValueFromInput("CIRGEGeneratorRotor");
            AddListboxPredicate(lbGeneratorRotor, ComponentInspectionReportGeneratorFields.GeneratorRotorId, ref fb);
            //Generator Cover

            string[] lbGeneratorCover = GetValueFromInput("CIRGEGeneratorCover");
            AddListboxPredicate(lbGeneratorCover, ComponentInspectionReportGeneratorFields.GeneratorCoverId, ref fb);

            //Generator U1 - U2

            string tbGeneratorU1U2 = GetValueFromInput("CIRGEGeneratorU1U2").FirstOrDefault();
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.U1U2, tbGeneratorU1U2, typeof(long), false);
            //Generator V1 - V2

            string tbGeneratorV1V2 = GetValueFromInput("CIRGEGeneratorV1V2").FirstOrDefault(); ;
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.V1V2, tbGeneratorV1V2, typeof(long), false);
            //Generator W1 - W2

            string tbGeneratorW1W2 = GetValueFromInput("CIRGEGeneratorW1W2").FirstOrDefault(); ;
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.W1W2, tbGeneratorW1W2, typeof(long), false);
            //Generator K1 - L1


            string tbGeneratorK1L1 = GetValueFromInput("CIRGEGeneratorK1L1").FirstOrDefault();
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.K1L1, tbGeneratorK1L1, typeof(long), false);
            //Generator L1 - M1

            string tbGeneratorL1M1 = GetValueFromInput("CIRGEGeneratorL1M1").FirstOrDefault();
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.L1M1, tbGeneratorL1M1, typeof(long), false);
            //Generator K1 - M1

            string tbGeneratorK1M1 = GetValueFromInput("CIRGEGeneratorK1M1").FirstOrDefault();
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.K1M1, tbGeneratorK1M1, typeof(long), false);
            //Generator K2 - L2

            string tbGeneratorK2L2 = GetValueFromInput("CIRGEGeneratorK2L2").FirstOrDefault();
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.K2L2, tbGeneratorK2L2, typeof(long), false);
            //Generator L2 - M2

            string tbGeneratorL2M2 = GetValueFromInput("CIRGEGeneratorL2M2").FirstOrDefault();
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.L2M2, tbGeneratorL2M2, typeof(long), false);
            //Generator K2 - M2

            string tbGeneratorK2M2 = GetValueFromInput("CIRGEGeneratorK2M2").FirstOrDefault();
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.K2M2, tbGeneratorK2M2, typeof(long), false);

            //Generator U - Ground

            string tbGeneratorUGround = GetValueFromInput("CIRGEGeneratorUGround").FirstOrDefault();
            string[] lbGeneratorUGroundUnit = GetValueFromInput("CIRGEGeneratorUGroundUnit");
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.Uground, tbGeneratorUGround, typeof(decimal), false);
            AddListboxPredicate(lbGeneratorUGroundUnit, ComponentInspectionReportGeneratorFields.UgroundOhmUnitId, ref fb);
            //Generator V - Ground

            string tbGeneratorVGround = GetValueFromInput("CIRGEGeneratorVGround").FirstOrDefault();
            string[] lbGeneratorVGroundUnit = GetValueFromInput("CIRGEGeneratorVGroundUnit");
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.Vground, tbGeneratorVGround, typeof(decimal), false);
            AddListboxPredicate(lbGeneratorVGroundUnit, ComponentInspectionReportGeneratorFields.VgroundOhmUnitId, ref fb);
            //Generator W - Ground

            string tbGeneratorWGround = GetValueFromInput("CIRGEGeneratorWGround").FirstOrDefault();
            string[] lbGeneratorWGroundUnit = GetValueFromInput("CIRGEGeneratorWGroundUnit");
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.Wground, tbGeneratorWGround, typeof(decimal), false);
            AddListboxPredicate(lbGeneratorWGroundUnit, ComponentInspectionReportGeneratorFields.WgroundOhmUnitId, ref fb);
            //Generator U - V

            string tbGeneratorUV = GetValueFromInput("CIRGEGeneratorUV").FirstOrDefault();
            string[] lbGeneratorUVUnit = GetValueFromInput("CIRGEGeneratorUVUnit");
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.Uv, tbGeneratorUV, typeof(decimal), false);
            AddListboxPredicate(lbGeneratorUVUnit, ComponentInspectionReportGeneratorFields.UvohmUnitId, ref fb);
            //Generator U - W

            string tbGeneratorUW = GetValueFromInput("CIRGEGeneratorUW").FirstOrDefault();
            string[] lbGeneratorUWUnit = GetValueFromInput("CIRGEGeneratorUWUnit");
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.Uw, tbGeneratorUW, typeof(decimal), false);
            AddListboxPredicate(lbGeneratorUWUnit, ComponentInspectionReportGeneratorFields.UwohmUnitId, ref fb);
            //Generator V - W

            string tbGeneratorVW = GetValueFromInput("CIRGEGeneratorVW").FirstOrDefault();
            string[] lbGeneratorVWUnit = GetValueFromInput("CIRGEGeneratorVWUnit");
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.Vw, tbGeneratorVW, typeof(decimal), false);
            AddListboxPredicate(lbGeneratorVWUnit, ComponentInspectionReportGeneratorFields.VwohmUnitId, ref fb);
            //Generator K - Ground

            string tbGeneratorKGround = GetValueFromInput("CIRGEGeneratorKGround").FirstOrDefault();
            string[] lbGeneratorKGroundUnit = GetValueFromInput("CIRGEGeneratorKGroundUnit");
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.Kground, tbGeneratorKGround, typeof(decimal), false);
            AddListboxPredicate(lbGeneratorKGroundUnit, ComponentInspectionReportGeneratorFields.KgroundOhmUnitId, ref fb);
            //Generator L - Ground

            string tbGeneratorLGround = GetValueFromInput("CIRGEGeneratorLGround").FirstOrDefault();
            string[] lbGeneratorLGroundUnit = GetValueFromInput("CIRGEGeneratorLGroundUnit");
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.Lground, tbGeneratorLGround, typeof(decimal), false);
            AddListboxPredicate(lbGeneratorLGroundUnit, ComponentInspectionReportGeneratorFields.LgroundOhmUnitId, ref fb);
            //Generator M - Ground

            string tbGeneratorMGround = GetValueFromInput("CIRGEGeneratorMGround").FirstOrDefault();
            string[] lbGeneratorMGroundUnit = GetValueFromInput("CIRGEGeneratorMGroundUnit");
            AddPredicateToBucket(ref fb, ComponentInspectionReportGeneratorFields.Mground, tbGeneratorMGround, typeof(decimal), false);
            AddListboxPredicate(lbGeneratorMGroundUnit, ComponentInspectionReportGeneratorFields.MgroundOhmUnitId, ref fb);



        }

        private static void CreateMainBearingWhereClause(ref RelationPredicateBucket fb)
        {

            fb.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportMainBearingEntityUsingComponentInspectionReportId, JoinHint.Left);

            // Turbine Number

            string tbWTDTurbineNo6 = GetValueFromInput("CIRWTDTurbineNo6").FirstOrDefault();
            AddTurbineNumberPredicate(ref tbWTDTurbineNo6, ref fb);

            //Main Bearing Last Lubrication Date
            DateTime dpMainBearingLastLubricationDateFrom = System.DateTime.MinValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRMainBearingLastLubricationDateFrom").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpMainBearingLastLubricationDateFrom))
            {

            }

            DateTime dpMainBearingLastLubricationDateTo = System.DateTime.MaxValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRMainBearingLastLubricationDateTo").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpMainBearingLastLubricationDateTo))
            {

            }
            AddDatePredicate(ref dpMainBearingLastLubricationDateFrom, ref dpMainBearingLastLubricationDateTo, ComponentInspectionReportGeneratorFields.GeneratorMaxTemperatureResetDate, ref fb);


            //Main Bearing Manufacturer
            _AddPredicate(ref fb, ComponentInspectionReportMainBearingFields.MainBearingManufacturerId, "CIRMainBearingManufacturer");


            //Main Bearing Temperature
            _AddPredicate(ref fb, ComponentInspectionReportMainBearingFields.MainBearingTemperature, "CIRtbMainBearingTemperature", typeof(long));




            //Main Bearing Lubrication Type
            string cbMainBearingGrease = GetValueFromInput("CIRMainBearingGrease").FirstOrDefault();
            string[] lbMainBearingLubricationOilId = GetValueFromInput("CIRMainBearingLubricationType");
            if (lbMainBearingLubricationOilId.Length > 0 || cbMainBearingGrease == "true")
            {
                RelationPredicateBucket filterBucket = new RelationPredicateBucket();
                filterBucket.PredicateExpression.AddWithOr(ComponentInspectionReportMainBearingFields.MainBearingManufacturerId == lbMainBearingLubricationOilId.ToArray());

                if (cbMainBearingGrease == "true")
                {
                    filterBucket.PredicateExpression.AddWithOr(ComponentInspectionReportMainBearingFields.MainBearingGrease == true);
                }
                fb.PredicateExpression.Add(filterBucket.PredicateExpression);
            }

            //Main Bearing Lubrication Run Hours
            _AddPredicate(ref fb, ComponentInspectionReportMainBearingFields.MainBearingLubricationRunHours, "CIRMainBearingLubricationRunHours", typeof(long));


            //Main Bearing Oil Temperature
            _AddPredicate(ref fb, ComponentInspectionReportMainBearingFields.MainBearingOilTemperature, "CIRMainBearingLubricationOilTemperature", typeof(long));


            //Main Bearing Type
            _AddPredicate(ref fb, ComponentInspectionReportMainBearingFields.MainBearingTypeId, "CIRMainBearingType");

            //Main Bearing Revision
            _AddPredicate(ref fb, ComponentInspectionReportMainBearingFields.MainBearingRevision, "CIRMainBearingRevision", typeof(long));


            //Main Bearing Error Location
            _AddPredicate(ref fb, ComponentInspectionReportMainBearingFields.MainBearingErrorLocationId, "CIRMainBearingErrorLocation");

            //Main Bearing Serial Number
            _AddPredicate(ref fb, ComponentInspectionReportMainBearingFields.MainBearingSerialNumber, "CIRMainBearingSerialNumber", typeof(long));

            //Main Bearing Run Hours
            _AddPredicate(ref fb, ComponentInspectionReportMainBearingFields.MainBearingRunHours, "CIRMainBearingRunHours", typeof(long));

            //Main Bearing Mechanical Oil Pump
            _AddPredicate(ref fb, ComponentInspectionReportMainBearingFields.MainBearingMechanicalOilPump, "CIRMainBearingMechanicalOilPump", typeof(long));


        }

        private static void CreateTransformerWhereClause(ref RelationPredicateBucket fb)
        {

            fb.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportTransformerEntityUsingComponentInspectionReportId, JoinHint.Left);

            string tbWTDTurbineNo5 = GetValueFromInput("CIRWTDTurbineNo5").FirstOrDefault();
            AddTurbineNumberPredicate(ref tbWTDTurbineNo5, ref fb);

            //SkiiP Failed Component Serial Number
            //  _AddPredicate(ref fb, ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentSerialNumber, "CIRSkiiPFailedComponentSerialNumber", typeof(string));


            //SkiiP Failed Component Vestas Unique Identifier
            _AddPredicate(ref fb, ComponentInspectionReportTransformerFields.TransformerManufacturerId, "CIRSkiiPFailedComponentVestasUniqueIdentifier", typeof(string));


            //Transformer Ser. No.
            _AddPredicate(ref fb, ComponentInspectionReportTransformerFields.TransformerSerialNumber, "CIRTRTransfSerialNumber", typeof(string));

            // Transformer mounted on main component
            string[] lbTransformerMountedOnMainComponent = GetValueFromInput("CIRTRTransfMountedOnMainComponent");
            AddListboxPredicate(lbTransformerMountedOnMainComponent, ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId, ref fb);

            //Transformer Arc Detection
            _AddPredicate(ref fb, ComponentInspectionReportTransformerFields.TransformerArcDetectionId, "CIRTRTransfArcDetection", typeof(string));


            //Transformer Max Temperature
            _AddPredicate(ref fb, ComponentInspectionReportTransformerFields.MaxTemp, "CIRTRTransfSerialNumber");




            //Transformer Max Temperature Reset Date
            DateTime dpTransformerMaxTemperatureResetDateFrom = System.DateTime.MinValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRTRTransformerMaxTemperatureResetDateFrom").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpTransformerMaxTemperatureResetDateFrom))
            {

            }

            DateTime dpTransformerMaxTemperatureResetDateTo = System.DateTime.MaxValue;
            if (DateTime.TryParseExact(GetValueFromInput("CIRTRTransformerMaxTemperatureResetDateTo").FirstOrDefault(), "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dpTransformerMaxTemperatureResetDateTo))
            {

            }
            AddDatePredicate(ref dpTransformerMaxTemperatureResetDateFrom, ref dpTransformerMaxTemperatureResetDateTo, ComponentInspectionReportTransformerFields.MaxTempResetDate, ref fb);

            //Transformer Action To Be Taken
            string[] lbTransformerActionToBeTaken = GetValueFromInput("CIRTRTransformerActionToBeTaken");
            AddListboxPredicate(lbTransformerActionToBeTaken, ComponentInspectionReportTransformerFields.ActionOnTransformerId, ref fb);
            //Transformer HV Coil
            string[] lbTransformerHVCoil = GetValueFromInput("CIRTRTransformerHVCoil");
            AddListboxPredicate(lbTransformerHVCoil, ComponentInspectionReportTransformerFields.HvcoilConditionId, ref fb);
            //Transformer LV Coil
            string[] lbTransformerLVCoil = GetValueFromInput("CIRTRTransformerLVCoil");
            AddListboxPredicate(lbTransformerLVCoil, ComponentInspectionReportTransformerFields.LvcoilConditionId, ref fb);
            //Transformer HV Cable
            string[] lbTransformerHVCable = GetValueFromInput("CIRTRTransformerHVCable");
            AddListboxPredicate(lbTransformerHVCable, ComponentInspectionReportTransformerFields.HvcableConditionId, ref fb);
            //Transformer LV Cable
            string[] lbTransformerLVCable = GetValueFromInput("CIRTRTransformerLVCable");
            AddListboxPredicate(lbTransformerLVCable, ComponentInspectionReportTransformerFields.LvcableConditionId, ref fb);
            //Transformer Brackets
            string[] lbTransformerBrackets = GetValueFromInput("CIRTRTransformerBrackets");
            AddListboxPredicate(lbTransformerBrackets, ComponentInspectionReportTransformerFields.BracketsId, ref fb);
            //Transformer Climate
            string[] lbTransformerClimate = GetValueFromInput("CIRTRTransformerClimate");
            AddListboxPredicate(lbTransformerClimate, ComponentInspectionReportTransformerFields.ClimateId, ref fb);
            //Transformer Surge Arrestor
            string[] lbTransformerSurgeArrestor = GetValueFromInput("CIRTRTransformerSurgeArrestor");
            AddListboxPredicate(lbTransformerSurgeArrestor, ComponentInspectionReportTransformerFields.SurgeArrestorId, ref fb);
            //Transformer Connection Bars
            string[] lbTransformerConnectionBars = GetValueFromInput("CIRTRTransformerConnectionBars");
            AddListboxPredicate(lbTransformerConnectionBars, ComponentInspectionReportTransformerFields.ConnectionBarsId, ref fb);

            //Transformer Comment            
            _AddPredicate(ref fb, ComponentInspectionReportTransformerFields.Comments, "CIRTRTransformerComment", typeof(string));





        }

        private static void CreateSkiiPWhereClause(ref RelationPredicateBucket fb)
        {


            fb.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportSkiiPEntityUsingComponentInspectionReportId, JoinHint.Left);
            fb.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.ComponentInspectionReportSkiiPfailedComponentEntityUsingComponentInspectionReportSkiiPid, JoinHint.Left);
            fb.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.ComponentInspectionReportSkiiPnewComponentEntityUsingComponentInspectionReportSkiiPid, JoinHint.Left);

            // Turbine Number

            string tbWTDTurbineNo7 = GetValueFromInput("CIRWTDTurbineNo7").FirstOrDefault();
            AddTurbineNumberPredicate(ref tbWTDTurbineNo7, ref fb);

            //SkiiP Failed Component Serial Number
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentSerialNumber, "CIRSkiiPFailedComponentSerialNumber", typeof(string));


            //SkiiP Failed Component Vestas Unique Identifier
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentVestasUniqueIdentifier, "CIRSkiiPFailedComponentVestasUniqueIdentifier", typeof(string));


            //SkiiP Failed Component Vestas Item Number
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentVestasItemNumber, "CIRSkiiPFailedComponentVestasUniqueIdentifier", typeof(string));

            //SkiiP New Component Serial Number            
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentSerialNumber, "CIRSkiiPOtherDamagedComponentsReplaced", typeof(string));

            //SkiiP New Component Vestas Unique Identifier
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentVestasUniqueIdentifier, "CIRSkiiPNewComponentVestasUniqueIdentifier", typeof(string));

            //SkiiP New Component Vestas Item Number
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentVestasItemNumber, "CIRSkiiPNewComponentVestasItemNumber", typeof(string));


            //SkiiP Other Damaged Components Replaced
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiPotherDamagedComponentsReplaced, "CIRSkiiPOtherDamagedComponentsReplaced", typeof(string));

            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiPcauseId, "CIRSkiiPCause");

            //SkiiP Quantity Of Failed Modules
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiPotherDamagedComponentsReplaced, "CIRSkiiPOtherDamagedComponentsReplaced", typeof(string));

            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiPquantityOfFailedModules, "CIRSkiiPQuantityOfFailedModules");

            //SkiiP 2MW V521
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP2MWV521");



            //SkiiP 2MW V522
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP2MWV522");


            //SkiiP 2MW V523
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP2MWV523");


            //SkiiP 2MW V524
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP2MWV524");


            //SkiiP 2MW V525
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP2MWV525");


            //SkiiP 2MW V526
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP2MWV526");


            //SkiiP 3MW V521
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP3MWV521");

            //SkiiP 3MW V522
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP3MWV522");

            //SkiiP 3MW V523
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP3MWV523");

            //SkiiP 3MW V524x
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP3MWV524x");


            //SkiiP 3MW V524y
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP3MWV524y");


            //SkiiP 3MW V525x
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP3MWV525x");


            //SkiiP 3MW V525y
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP3MWV525y");


            //SkiiP 3MW V526x
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP3MWV526x");


            //SkiiP 3MW V526y
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP3MWV526y");


            //SkiiP 850KW V520
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP850KWV520");

            //SkiiP 850KW V524
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP850KWV524");

            //SkiiP 850KW V525
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP850KWV525");


            //SkiiP 850KW V526
            _AddPredicate(ref fb, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId, "CIRSkiiP850KWV526");



        }

        private static void AddDatePredicate(ref DateTime dpFrom, ref DateTime dpTo, EntityField2 field, ref RelationPredicateBucket fb)
        {
            if (dpFrom > System.DateTime.MinValue || dpTo > System.DateTime.MinValue)
            {
                if (dpFrom > System.DateTime.MinValue & dpTo == System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(field >= dpFrom);
                }
                else if (dpFrom == System.DateTime.MinValue & dpTo > System.DateTime.MinValue)
                {
                    fb.PredicateExpression.Add(field <= dpTo);
                }
                else if (dpFrom > System.DateTime.MinValue & dpTo > System.DateTime.MinValue & dpFrom > dpTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(field, null, dpTo, dpFrom));
                }
                else if (dpFrom > System.DateTime.MinValue & dpTo > System.DateTime.MinValue & dpFrom < dpTo)
                {
                    fb.PredicateExpression.Add(new FieldBetweenPredicate(field, null, dpFrom, dpTo));
                }
            }
        }

        private static void AddListboxPredicate(string[] values, EntityField2 field, ref RelationPredicateBucket fb)
        {
            if (values.Length > 0)
            {
                fb.PredicateExpression.Add(field == values.ToArray());
            }
        }

        private static void _AddPredicate(ref RelationPredicateBucket fb, EntityField2 e, string field, Type type = null)
        {
            if (type == null)
            {
                string[] values = GetValueFromInput(field);
                AddListboxPredicate(values, e, ref fb);
            }
            else
            {
                string value = GetValueFromInput(field).FirstOrDefault();
                AddPredicateToBucket(ref fb, e, value, type, false);

            }
        }

        private static void AddTurbineNumberPredicate(ref string tbWTDTurbineNo, ref RelationPredicateBucket fb)
        {
            //Turbine Number
            if (tbWTDTurbineNo != null)
            {
                AddPredicateToBucket(ref fb, ComponentInspectionReportFields.TurbineNumber, tbWTDTurbineNo, typeof(string), false);
            }
        }

        public static AdvanceSearchModel Search()
        {

            //Fetch data
            EntityCollection<ComponentInspectionReportEntity> ec = new EntityCollection<ComponentInspectionReportEntity>(new ComponentInspectionReportEntityFactory());

            //Dim Birec As New EntityCollection(Of BirDataEntity)(New BirDataEntityFactory())

            using (DataAccessAdapter daa = new DataAccessAdapter(GetConnectionString(), false))
            {
                PrefetchPath2 pp = new PrefetchPath2((int)EntityType.ComponentInspectionReportEntity);
                //Dim BIRpp As New PrefetchPath2(DirectCast(EntityType.BirDataEntity, Integer))
                IPrefetchPathElement2 ppe = default(IPrefetchPathElement2);
                //Wind Turbine
                pp.Add(ComponentInspectionReportEntity.PrefetchPathComponentInspectionReportType);
                pp.Add(ComponentInspectionReportEntity.PrefetchPathReportType);
                pp.Add(ComponentInspectionReportEntity.PrefetchPathBooleanAnswer);
                pp.Add(ComponentInspectionReportEntity.PrefetchPathCountryIso);
                ppe = pp.Add(ComponentInspectionReportEntity.PrefetchPathTurbineMatrix);
                ppe.SubPath.Add(TurbineMatrixEntity.PrefetchPathTurbine);

                pp.Add(ComponentInspectionReportEntity.PrefetchPathBooleanAnswer_);
                pp.Add(ComponentInspectionReportEntity.PrefetchPathBooleanAnswer__);
                pp.Add(ComponentInspectionReportEntity.PrefetchPathTurbineRunStatus);
                pp.Add(ComponentInspectionReportEntity.PrefetchPathServiceReportNumberType);
                pp.Add(ComponentInspectionReportEntity.PrefetchPathTurbineRunStatus_);
                //Blade
                ppe = pp.Add(ComponentInspectionReportEntity.PrefetchPathComponentInspectionReportBlade);
                ppe.SubPath.Add(ComponentInspectionReportBladeEntity.PrefetchPathBladeLength);
                ppe.SubPath.Add(ComponentInspectionReportBladeEntity.PrefetchPathBladeColor);
                ppe.SubPath.Add(ComponentInspectionReportBladeEntity.PrefetchPathBooleanAnswer);
                ppe.SubPath.Add(ComponentInspectionReportBladeEntity.PrefetchPathComponentInspectionReportBladeRepairRecord);
                ppe.SubPath.Add(ComponentInspectionReportBladeEntity.PrefetchPathFaultCodeClassification);
                ppe.SubPath.Add(ComponentInspectionReportBladeEntity.PrefetchPathFaultCodeCause);
                ppe.SubPath.Add(ComponentInspectionReportBladeEntity.PrefetchPathFaultCodeType);
                ppe.SubPath.Add(ComponentInspectionReportBladeEntity.PrefetchPathFaultCodeArea);
                ppe.SubPath.Add(ComponentInspectionReportBladeEntity.PrefetchPathBooleanAnswer_);
                ppe = ppe.SubPath.Add(ComponentInspectionReportBladeEntity.PrefetchPathComponentInspectionReportBladeDamage);
                ppe.SubPath.Add(ComponentInspectionReportBladeDamageEntity.PrefetchPathBladeDamagePlacement);
                ppe.SubPath.Add(ComponentInspectionReportBladeDamageEntity.PrefetchPathBladeInspectionData);
                ppe.SubPath.Add(ComponentInspectionReportBladeDamageEntity.PrefetchPathBladeEdge);
                //Gearbox
                ppe = pp.Add(ComponentInspectionReportEntity.PrefetchPathComponentInspectionReportGearbox);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearboxType);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearboxRevision);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearboxManufacturer);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathOilType);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathMechanicalOilPump);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathOilLevel);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGeneratorManufacturer);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGeneratorManufacturer_);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathElectricalPump);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathShrinkElement);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathCoupling);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathFilterBlockType);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathInlineFilter);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBooleanAnswer);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathShaftType);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathShaftType_);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathShaftType__);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathShaftType___);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathShaftError);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathShaftError_);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathShaftError__);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathShaftError___);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearType);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearType_);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearType__);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearType___);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearType____);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearError);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearError_);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearError__);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearError___);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathGearError____);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingType);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingType_);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingType__);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingType___);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingType____);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingPos);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingPos_);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingPos__);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingPos___);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingPos____);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingError);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingError_);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingError__);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingError___);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBearingError____);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathHousingError);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathHousingError_);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathHousingError__);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathHousingError___);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathHousingError____);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathHousingError_____);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathVibrations);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathNoise);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathDebrisOnMagnet);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathMagnetPos);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathDebrisGearbox);
                ppe.SubPath.Add(ComponentInspectionReportGearboxEntity.PrefetchPathBooleanAnswer_);
                //General
                ppe = pp.Add(ComponentInspectionReportEntity.PrefetchPathComponentInspectionReportGeneral);
                ppe.SubPath.Add(ComponentInspectionReportGeneralEntity.PrefetchPathComponentGroup);
                ppe.SubPath.Add(ComponentInspectionReportGeneralEntity.PrefetchPathBooleanAnswer);
                ppe.SubPath.Add(ComponentInspectionReportGeneralEntity.PrefetchPathGeneratorManufacturer);
                ppe.SubPath.Add(ComponentInspectionReportGeneralEntity.PrefetchPathTransformerManufacturer);
                ppe.SubPath.Add(ComponentInspectionReportGeneralEntity.PrefetchPathGearboxManufacturer);
                ppe.SubPath.Add(ComponentInspectionReportGeneralEntity.PrefetchPathTowerType);
                ppe.SubPath.Add(ComponentInspectionReportGeneralEntity.PrefetchPathTowerHeight);
                ppe.SubPath.Add(ComponentInspectionReportGeneralEntity.PrefetchPathControllerType);
                ppe.SubPath.Add(ComponentInspectionReportGeneralEntity.PrefetchPathBooleanAnswer_);
                //Generator
                ppe = pp.Add(ComponentInspectionReportEntity.PrefetchPathComponentInspectionReportGenerator);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathGeneratorManufacturer);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathBooleanAnswer);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathActionToBeTakenOnGenerator);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathGeneratorDriveEnd);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathGeneratorNonDriveEnd);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathGeneratorRotor);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathGeneratorCover);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathOhmUnit);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathOhmUnit_);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathOhmUnit__);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathOhmUnit___);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathOhmUnit____);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathOhmUnit_____);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathOhmUnit______);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathOhmUnit_______);
                ppe.SubPath.Add(ComponentInspectionReportGeneratorEntity.PrefetchPathOhmUnit________);

                //Main Bearing
                ppe = pp.Add(ComponentInspectionReportEntity.PrefetchPathComponentInspectionReportMainBearing);
                ppe.SubPath.Add(ComponentInspectionReportMainBearingEntity.PrefetchPathMainBearingManufacturer);
                ppe.SubPath.Add(ComponentInspectionReportMainBearingEntity.PrefetchPathOilType);
                ppe.SubPath.Add(ComponentInspectionReportMainBearingEntity.PrefetchPathMainBearingManufacturer_);
                ppe.SubPath.Add(ComponentInspectionReportMainBearingEntity.PrefetchPathMainBearingErrorLocation);
                ppe.SubPath.Add(ComponentInspectionReportMainBearingEntity.PrefetchPathBooleanAnswer);
                //SkiiP
                ppe = pp.Add(ComponentInspectionReportEntity.PrefetchPathComponentInspectionReportSkiiP);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathComponentInspectionReportSkiiPfailedComponent);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathComponentInspectionReportSkiiPnewComponent);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathSkiipackFailureCause);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer_);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer__);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer___);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer____);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer_____);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer______);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer_______);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer________);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer_________);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer__________);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer___________);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer____________);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer_____________);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer______________);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer_______________);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer________________);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer_________________);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer__________________);
                ppe.SubPath.Add(ComponentInspectionReportSkiiPEntity.PrefetchPathBooleanAnswer___________________);
                //Transformer
                ppe = pp.Add(ComponentInspectionReportEntity.PrefetchPathComponentInspectionReportTransformer);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathTransformerManufacturer);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathArcDetection);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathBooleanAnswer);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathActionOnTransformer);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathCoilCondition);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathCoilCondition_);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathCableCondition);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathCableCondition_);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathBrackets);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathClimate);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathSurgeArrestor);
                ppe.SubPath.Add(ComponentInspectionReportTransformerEntity.PrefetchPathConnectionBars);


                //ppe = BIRpp.Add(BirDataEntity.PrefetchPathBirWordDocument)
                ExcludeIncludeFieldsList eiList = new ExcludeIncludeFieldsList(true);

                eiList.Add(ComponentInspectionReportFields.Cirtemplate);

                // fetch the top [MaxResultsToShow] ordered by CIR ID descending
                //Dim sortOrder As New SortClause(DirectCast(ComponentInspectionReportFields.ComponentInspectionReportId., IEntityField), SortOperator.Descending)
                SortExpression sorter = new SortExpression(ComponentInspectionReportFields.ComponentInspectionReportId | SortOperator.Descending);


                daa.FetchEntityCollection(ec, WhereClause(), MaxResultsToShow, sorter, pp, eiList, 1, 50);

                EntityCollection<ComponentInspectionReportEntity> ec1 = new EntityCollection<ComponentInspectionReportEntity>(new ComponentInspectionReportEntityFactory());
                daa.FetchEntityCollection(ec1, WhereClause(), MaxResultsToShow, sorter, pp, eiList, 2, 50);

                foreach (ComponentInspectionReportEntity e in ec1)
                {
                    ec.Add(e);
                }

            }

            if (ec.Count > 0)
            {

                // result overflow?
                if ((ec.Count > MaxResultsToShow))
                {

                    _AdvanceSearchData.ResponseString = "Your search returned more than " + MaxResultsToShow.ToString() + " results. Only the first " + MaxResultsToShow.ToString() + " are shown in the result list.<br />" + "You can narrow down your search by specifying additional search parameters in the search form below.<br /><br/>" + "Alternatively you can also create a personal view on the Submitted/Accepted/Rejected lists, if this suits your needs better. <br />" + "Contact IT Service (5800) if you experience problems using Advanced Search. <br /><br />";
                }
                else
                {
                    _AdvanceSearchData.ResponseString = "Your search returned " + ec.Count.ToString() + " results. <br /><br />";

                }
                DataTable dt = new DataTable();
                DefineWindTurbineColumns(dt);
                DefineBladeColumns(dt);
                DefineGearColumns(dt);
                DefineGeneralColumns(dt);
                DefineGeneratorColumns(dt);
                DefineMainBearingColumns(dt);
                DefineSkiiPColumns(dt);
                DefineTransformerColumns(dt);
                for (int i = 0; i <= ec.Count - 1; i++)
                {
                    DataRow dr = dt.NewRow();
                    FillWindTurbineColumns(ec[i], dr);
                    FillBladeColumns(ec[i], dr);
                    FillGearColumns(ec[i], dr);
                    FillGeneralColumns(ec[i], dr);
                    FillGeneratorColumns(ec[i], dr);
                    FillMainBearingColumns(ec[i], dr);
                    FillSkiiPColumns(ec[i], dr);
                    FillTransformerColumns(ec[i], dr);
                    dt.Rows.Add(dr);
                }

                string result = ParseColumns(dt);
                _AdvanceSearchData.Result = result;
            }
            else
            {

                _AdvanceSearchData.ResponseString = "No CIR's match search criteria.";
                _AdvanceSearchData.Result = "";
            }

            return _AdvanceSearchData;
        }

        private static string ParseColumns(DataTable dt)
        {
            ResultColumnMap();

            string columns = "";

            //ArrayList rc = ResultListColumns();
            // Dictionary<string, string> ResultColumnToDisplay = new Dictionary<string,string>();
            if (InputFilterColumn != null && !InputFilterColumn.Contains("CIR ID"))
            {
                InputFilterColumn = "CIR ID," + InputFilterColumn;
            }
            ResultColumnMapList = ResultColumnMapList.Where(i => InputFilterColumn.Contains(i.Value)).ToDictionary(p => p.Key, p => p.Value);
            columns = String.Join(",", ResultColumnMapList.Select(x => "{\"data\": \"" + x.Key + "\" , \"title\": \"" + x.Value + "\"}"));
            //foreach (var item in ResultColumnMapList)
            //{
            //    if (InputFilterColumn.Contains(item.Value.ToString()))
            //    {
            //        ResultColumnToDisplay.Add(item.Key, item.Value);
            //        columns = columns + "{\"data\": \"" + item.Key + "\" , \"title\": \"" + item.Value + "\"},";
            //    }
            //}

            //columns = (columns.Length > 0) ? columns.Substring(0, columns.Length - 1) : columns;

            DataView dv = new DataView(dt);
            dt = dv.ToTable(false, ResultColumnMapList.Keys.ToArray());
            //Newtonsoft.Json.Linq.JObject j = Newtonsoft.Json.Linq.JObject.Parse(columns);
            string rows = JsonConvert.SerializeObject(dt);
            string data = "{\"columns\" : [" + columns + "] , \"rows\" : " + rows + " }";

            // Newtonsoft.Json.Linq.JObject j = Newtonsoft.Json.Linq.JObject.Parse(data);
            return data;
            // return dv.ToTable(false, (string[])rc.ToArray(typeof(string)));

        }

        //public static bool GetColumnFilterName(string ColumnName)
        //{
        //    if (InputFilterColumn != null)
        //        return InputFilterColumn.IndexOf(ColumnName) > 0 ? true : false;
        //    else
        //        return false;
        //}

        //public static ArrayList ResultListColumns()
        //{

        //    ArrayList rlc = new ArrayList();
        //    rlc.Add(ComponentInspectionReportFields.ComponentInspectionReportId.Name);
        //    if (GetColumnFilterName("Component Type"))
        //        rlc.Add(ComponentInspectionReportFields.ComponentInspectionReportTypeId.Name);
        //    CreateWindTurbineResultListColumns(ref rlc);
        //    CreateBladeResultListColumns(ref rlc);
        //    CreateGearResultListColumns(ref rlc);
        //    CreateGeneralResultListColumns(ref rlc);
        //    CreateGeneratorResultListColumns(ref rlc);
        //    CreateMainBearingResultListColumns(ref rlc);
        //    CreateSkiiPResultListColumns(ref rlc);
        //    CreateTransformerResultListColumns(ref rlc);

        //    ////BIR create result
        //    //CreateBIRResultListColumns(rlc);
        //    return rlc;

        //}

        //private static void CreateGeneralResultListColumns(ref ArrayList rlc)
        //{
        //    if (GetColumnFilterName("General Comp. Group"))//.Selected || lbGeneralComponentGroup.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralComponentGroupId.Name);
        //    if (GetColumnFilterName("General Comp. Type"))//.Selected || tbGeneralComponentType.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralComponentType.Name);
        //    if (GetColumnFilterName("General Comp. Manufact."))//Selected || tbGeneralComponentManufacturer.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralComponentManufacturer.Name);
        //    if (GetColumnFilterName("General Other Gearbox Type"))//.Selected || tbGeneralOtherGearboxType.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralOtherGearboxType.Name);
        //    //If GetColumnFilterName("General Claim Relevant").Selected OrElse lbGeneralClaimRelevant.SelectedIndex > -1 Then rlc.Add(ComponentInspectionReportGeneralFields.GeneralClaimRelevantBooleanAnswerId.Name)
        //    if (GetColumnFilterName("General Other Gearbox Manufact."))//Selected || tbGeneralOtherGearboxManufacturer.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralOtherGearboxManufacturer.Name);
        //    if (GetColumnFilterName("General Comp. Ser. No."))//.Selected || tbGeneralComponentSerialNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralComponentSerialNumber.Name);
        //    if (GetColumnFilterName("General Generator Manufact."))//Selected || lbGeneralGeneratorManufacturer.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralGeneratorManufacturerId.Name);
        //    if (GetColumnFilterName("General Transf. Manufact."))//.Selected || lbGeneralTransformerManufacturer.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralTransformerManufacturerId.Name);
        //    if (GetColumnFilterName("General Gearbox Manufact."))//.Selected || lbGeneralGearboxManufacturer.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralGearboxManufacturerId.Name);
        //    if (GetColumnFilterName("General Tower Type"))//.Selected || lbGeneralTowerType.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralTowerTypeId.Name);
        //    if (GetColumnFilterName("General Tower Height"))//.Selected || lbGeneralTowerHeight.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralTowerHeightId.Name);
        //    if (GetColumnFilterName("General Blade Ser. No."))//.Selected || tbGeneralBladeSerialNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralBlade1SerialNumber.Name);
        //    if (GetColumnFilterName("General Ctrl. Type"))//.Selected || lbGeneralControllerType.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralControllerTypeId.Name);
        //    if (GetColumnFilterName("General Soft. Rel."))//.Selected || tbGeneralSoftwareRelease.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralSoftwareRelease.Name);
        //    if (GetColumnFilterName("General Ram Dump No."))//.Selected || tbGeneralRamDumpNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralRamDumpNumber.Name);
        //    if (GetColumnFilterName("General VDF Track No."))//.Selected || tbGeneralVDFTrackNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralVdftrackNumber.Name);
        //    if (GetColumnFilterName("General Pics. Att."))//.Selected || lbGeneralPicturesAttached.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralPicturesIncludedBooleanAnswerId.Name);

        //    if (GetColumnFilterName("General Initiated By"))//.Selected || tbGeneralInitiatedBy.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralInitiatedBy1.Name);
        //    if (GetColumnFilterName("General Measurements Conducted"))//Selected || tbGeneralMeasurementsConducted.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralMeasurementsConducted1.Name);
        //    if (GetColumnFilterName("General Executed By"))//.Selected || tbGeneralExecutedBy.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralExecutedBy1.Name);

        //    if (GetColumnFilterName("General Position Of Failed Item"))//Selected || tbGeneralPositionOfFailedItem.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneralFields.GeneralPositionOfFailedItem.Name);
        //}

        //private static void CreateGeneratorResultListColumns(ref ArrayList rlc)
        //{
        //    if (GetColumnFilterName("Generator Manufacturer"))//.Selected || lbGeneratorManufacturer.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.GeneratorManufacturerId.Name);
        //    if (GetColumnFilterName("Generator Ser. No."))//.Selected || tbGeneratorSerialNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.GeneratorSerialNumber.Name);
        //    if (GetColumnFilterName("Generator Comment"))//.Selected || tbGeneratorComment.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.GeneratorComments.Name);
        //    if (GetColumnFilterName("Generator Rew. Locally"))//Selected || lbGeneratorRewoundLocally.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.GeneratorRewoundLocally.Name);
        //    if (GetColumnFilterName("Generator Max Temperature"))//.Selected || tbGeneratorMaxTemperature.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.GeneratorMaxTemperature.Name);
        //    if (GetColumnFilterName("Generator Max Temperature Reset Date"))//.Selected || dpGeneratorMaxTemperatureResetDateFrom.DateValue > System.DateTime.MinValue || dpGeneratorMaxTemperatureResetDateTo.DateValue > System.DateTime.MinValue)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.GeneratorMaxTemperatureResetDate.Name);
        //    if (GetColumnFilterName("Generator Action To Be Taken"))//.Selected || lbGeneratorActionToBeTaken.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.ActionToBeTakenOnGeneratorId.Name);

        //    if (GetColumnFilterName("Generator Drive End"))//.Selected || lbGeneratorDriveEnd.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.GeneratorDriveEndId.Name);
        //    if (GetColumnFilterName("Generator Non Drive End"))//Selected || lbGeneratorNonDriveEnd.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.GeneratorNonDriveEndId.Name);
        //    if (GetColumnFilterName("Generator Rotor"))//.Selected || lbGeneratorRotor.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.GeneratorRotorId.Name);
        //    if (GetColumnFilterName("Generator Cover"))//.Selected || lbGeneratorCover.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.GeneratorCoverId.Name);

        //    if (GetColumnFilterName("Generator U1 - U2"))//.Selected || tbGeneratorU1U2.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.U1U2.Name);
        //    if (GetColumnFilterName("Generator V1 - V2"))//.Selected || tbGeneratorV1V2.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.V1V2.Name);
        //    if (GetColumnFilterName("Generator W1 - W2"))//.Selected || tbGeneratorW1W2.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.W1W2.Name);
        //    if (GetColumnFilterName("Generator K1 - L1"))//Selected || tbGeneratorK1L1.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.K1L1.Name);
        //    if (GetColumnFilterName("Generator L1 - M1"))//.Selected || tbGeneratorL1M1.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.L1M1.Name);
        //    if (GetColumnFilterName("Generator K1 - M1"))//.Selected || tbGeneratorK1M1.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.K1M1.Name);
        //    if (GetColumnFilterName("Generator K2 - L2"))//.Selected || tbGeneratorK2L2.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.K2L2.Name);
        //    if (GetColumnFilterName("Generator L2 - M2"))//.Selected || tbGeneratorL2M2.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.L2M2.Name);
        //    if (GetColumnFilterName("Generator K2 - M2"))//.Selected || tbGeneratorK2M2.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.K2M2.Name);

        //    if (GetColumnFilterName("Generator U - Ground"))//.Selected || tbGeneratorUGround.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.Uground.Name);
        //    if (GetColumnFilterName("Generator U - Ground (unit)"))//.Selected || lbGeneratorUGroundUnit.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.UgroundOhmUnitId.Name);
        //    if (GetColumnFilterName("Generator V - Ground"))//.Selected || tbGeneratorVGround.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.Vground.Name);
        //    if (GetColumnFilterName("Generator V - Ground (unit)"))//.Selected || lbGeneratorVGroundUnit.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.VgroundOhmUnitId.Name);
        //    if (GetColumnFilterName("Generator W - Ground"))//Selected || tbGeneratorWGround.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.Wground.Name);
        //    if (GetColumnFilterName("Generator W - Ground (unit)"))//.Selected || lbGeneratorWGroundUnit.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.WgroundOhmUnitId.Name);
        //    if (GetColumnFilterName("Generator U - V"))//.Selected || tbGeneratorUV.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.Uv.Name);
        //    if (GetColumnFilterName("Generator U - V (unit)"))//.Selected || lbGeneratorUVUnit.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.UvohmUnitId.Name);
        //    if (GetColumnFilterName("Generator U - W"))//Selected || tbGeneratorUW.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.Uw.Name);
        //    if (GetColumnFilterName("Generator U - W (unit)"))//.Selected || lbGeneratorUWUnit.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.UwohmUnitId.Name);
        //    if (GetColumnFilterName("Generator V - W"))//.Selected || tbGeneratorVW.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.Vw.Name);
        //    if (GetColumnFilterName("Generator V - W (unit)"))//.Selected || lbGeneratorVWUnit.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.VwohmUnitId.Name);
        //    if (GetColumnFilterName("Generator K - Ground"))//.Selected || tbGeneratorKGround.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.Kground.Name);
        //    if (GetColumnFilterName("Generator K - Ground (unit)"))//.Selected || lbGeneratorKGroundUnit.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.KgroundOhmUnitId.Name);
        //    if (GetColumnFilterName("Generator L - Ground"))//Selected || tbGeneratorLGround.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.Lground.Name);
        //    if (GetColumnFilterName("Generator L - Ground (unit)"))//.Selected || lbGeneratorLGroundUnit.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.LgroundOhmUnitId.Name);
        //    if (GetColumnFilterName("Generator M - Ground"))//.Selected || tbGeneratorMGround.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.Mground.Name);
        //    if (GetColumnFilterName("Generator M - Ground (unit)"))//.Selected || lbGeneratorMGroundUnit.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGeneratorFields.MgroundOhmUnitId.Name);
        //}

        //private static void CreateMainBearingResultListColumns(ref ArrayList rlc)
        //{
        //    if (GetColumnFilterName("Main Bearing Last Lubrication Date"))//.Selected || dpMainBearingLastLubricationDateFrom.DateValue > System.DateTime.MinValue || dpMainBearingLastLubricationDateTo.DateValue > System.DateTime.MinValue)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingLastLubricationDate.Name);
        //    if (GetColumnFilterName("Main Bearing Manufacturer"))//.Selected || lbMainBearingManufacturerId.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingManufacturerId.Name);
        //    if (GetColumnFilterName("Main Bearing Temperature"))//.Selected || tbMainBearingTemperature.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingTemperature.Name);
        //    if (GetColumnFilterName("Main Bearing Lubrication Type"))//.Selected || lbMainBearingLubricationOilId.SelectedIndex > -1 || cbMainBearingGrease.Checked)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingLubricationOilTypeId.Name);
        //    if (GetColumnFilterName("Main Bearing Lubrication Run Hours"))//.Selected || tbMainBearingLubricationRunHours.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingLubricationRunHours.Name);
        //    if (GetColumnFilterName("Main Bearing Oil Temperature"))//.Selected || tbMainBearingOilTemperature.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingOilTemperature.Name);
        //    if (GetColumnFilterName("Main Bearing Type"))//.Selected || lbMainBearingTypeId.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingTypeId.Name);
        //    if (GetColumnFilterName("Main Bearing Revision"))//Selected || tbMainBearingRevision.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingRevision.Name);
        //    if (GetColumnFilterName("Main Bearing Error Location"))//.Selected || lbMainBearingErrorLocationId.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingErrorLocationId.Name);
        //    if (GetColumnFilterName("Main Bearing Serial Number"))//.Selected || tbMainBearingSerialNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingSerialNumber.Name);
        //    if (GetColumnFilterName("Main Bearing Run Hours"))//.Selected || tbMainBearingRunHours.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingRunHours.Name);
        //    if (GetColumnFilterName("Main Bearing Mechanical Oil Pump"))//Selected || tbMainBearingMechanicalOilPump.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportMainBearingFields.MainBearingMechanicalOilPump.Name);
        //}

        //private static void CreateSkiiPResultListColumns(ref ArrayList rlc)
        //{
        //    if (GetColumnFilterName("SkiiP Failed Component Serial Number"))//.Selected || tbSkiiPFailedComponentSerialNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentSerialNumber.Name);
        //    if (GetColumnFilterName("SkiiP Failed Component Vestas Unique Identifier"))//Selected || tbSkiiPFailedComponentVestasUniqueIdentifier.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentVestasUniqueIdentifier.Name);
        //    if (GetColumnFilterName("SkiiP Failed Component Vestas Item Number"))//.Selected || tbSkiiPFailedComponentVestasItemNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentVestasItemNumber.Name);
        //    if (GetColumnFilterName("SkiiP New Component Serial Number"))//.Selected || tbSkiiPNewComponentSerialNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentSerialNumber.Name);
        //    if (GetColumnFilterName("SkiiP New Component Vestas Unique Identifier"))//.Selected || tbSkiiPNewComponentVestasUniqueIdentifier.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentVestasUniqueIdentifier.Name);
        //    if (GetColumnFilterName("SkiiP New Component Vestas Item Number"))//.Selected || tbSkiiPNewComponentVestasItemNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentVestasItemNumber.Name);
        //    if (GetColumnFilterName("SkiiP Other Damaged Components Replaced"))//.Selected || tbSkiiPOtherDamagedComponentsReplaced.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiPotherDamagedComponentsReplaced.Name);
        //    if (GetColumnFilterName("SkiiP Cause"))//.Selected || lbSkiiPCause.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiPcauseId.Name);
        //    if (GetColumnFilterName("SkiiP Quantity Of Failed Modules"))//.Selected || tbSkiiPQuantityOfFailedModules.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiPquantityOfFailedModules.Name);
        //    if (GetColumnFilterName("SkiiP 2MW V521"))//.Selected || lbSkiiP2MWV521.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 2MW V522"))//.Selected || lbSkiiP2MWV522.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv522BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 2MW V523"))//.Selected || lbSkiiP2MWV523.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv523BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 2MW V524"))//Selected || lbSkiiP2MWV524.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv524BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 2MW V525"))//.Selected || lbSkiiP2MWV525.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv525BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 2MW V526"))//Selected || lbSkiiP2MWV526.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv526BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 3MW V521"))//.Selected || lbSkiiP3MWV521.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv521BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 3MW V522"))//.Selected || lbSkiiP3MWV522.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv522BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 3MW V523"))//Selected || lbSkiiP3MWV523.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv523BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 3MW V524x"))//.Selected || lbSkiiP3MWV524x.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv524xBooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 3MW V524y"))//.Selected || lbSkiiP3MWV524y.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv524yBooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 3MW V525x"))//.Selected || lbSkiiP3MWV525x.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv525xBooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 3MW V525y"))//.Selected || lbSkiiP3MWV525y.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv525yBooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 3MW V526x"))//.Selected || lbSkiiP3MWV526x.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv526xBooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 3MW V526y"))//.Selected || lbSkiiP3MWV526y.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv526yBooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 850KW V520"))//.Selected || lbSkiiP850KWV520.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv520BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 850KW V524"))//Selected || lbSkiiP850KWV524.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv524BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 850KW V525"))//.Selected || lbSkiiP850KWV525.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv525BooleanAnswerId.Name);
        //    if (GetColumnFilterName("SkiiP 850KW V526"))//.Selected || lbSkiiP850KWV526.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv526BooleanAnswerId.Name);
        //}

        //private static void CreateTransformerResultListColumns(ref ArrayList rlc)
        //{
        //    if (GetColumnFilterName("Transformer Manufacturer"))//.Selected || lbTransfManufacturer.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportTransformerFields.TransformerManufacturerId.Name);
        //    if (GetColumnFilterName("Transformer Ser. No."))//.Selected || tbTransfSerialNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportTransformerFields.TransformerSerialNumber.Name);
        //    if (GetColumnFilterName("Transformer Arc Detection"))//.Selected || lbTransfArcDetection.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportTransformerFields.TransformerArcDetectionId.Name);

        //    if (GetColumnFilterName("Transformer Max Temperature"))//.Selected || tbTransformerMaxTemperature.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportTransformerFields.MaxTemp.Name);
        //    if (GetColumnFilterName("Transformer Max Temperature Reset Date"))//.Selected || dpTransformerMaxTemperatureResetDateFrom.DateValue > System.DateTime.MinValue || dpTransformerMaxTemperatureResetDateTo.DateValue > System.DateTime.MinValue)
        //        rlc.Add(ComponentInspectionReportTransformerFields.MaxTempResetDate.Name);

        //    if (GetColumnFilterName("Transformer Action To Be Taken"))//.Selected || lbTransformerActionToBeTaken.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportTransformerFields.ActionOnTransformerId.Name);
        //    if (GetColumnFilterName("Transformer HV Coil"))//.Selected || lbTransformerHVCoil.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportTransformerFields.HvcoilConditionId.Name);
        //    if (GetColumnFilterName("Transformer LV Coil"))//.Selected || lbTransformerLVCoil.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportTransformerFields.LvcoilConditionId.Name);
        //    if (GetColumnFilterName("Transformer HV Cable"))//Selected || lbTransformerHVCable.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportTransformerFields.HvcableConditionId.Name);
        //    if (GetColumnFilterName("Transformer LV Cable"))//.Selected || lbTransformerHVCable.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportTransformerFields.HvcableConditionId.Name);
        //    if (GetColumnFilterName("Transformer Brackets"))//.Selected || lbTransformerBrackets.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportTransformerFields.BracketsId.Name);
        //    if (GetColumnFilterName("Transformer Climate"))//Selected || lbTransformerClimate.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportTransformerFields.ClimateId.Name);
        //    if (GetColumnFilterName("Transformer Surge Arrestor"))//.Selected || lbTransformerSurgeArrestor.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportTransformerFields.SurgeArrestorId.Name);
        //    if (GetColumnFilterName("Transformer Connection Bars"))//Selected || lbTransformerConnectionBars.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportTransformerFields.ConnectionBarsId.Name);

        //    if (GetColumnFilterName("Transformer Comment"))//.Selected || tbTransformerComment.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportTransformerFields.Comments.Name);
        //}

        //private static void CreateGearResultListColumns(ref ArrayList rlc)
        //{
        //    if (GetColumnFilterName("Gear Type"))//.Selected || lbGDGearType.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxTypeId.Name);
        //    if (GetColumnFilterName("Other Gear Type"))//.Selected || tbGDOtherGearType.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGearboxFields.OtherGearboxType.Name);
        //    if (GetColumnFilterName("Gear Revision"))//.Selected || lbGDGearRevision.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxRevisionId.Name);
        //    if (GetColumnFilterName("Gear Manufacturer"))//.Selected || lbGDGearManufacturer.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxManufacturerId.Name);
        //    if (GetColumnFilterName("Gear Other Manufacturer"))//.Selected || tbGDGearOtherManufacturer.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxOtherManufacturer.Name);
        //    if (GetColumnFilterName("Gear Serial Number"))//.Selected || tbGDGearSerialNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxSerialNumber.Name);
        //    //If GetColumnFilterName("Gear Last Oil Change").Selected OrElse dpGDGearLastOilChangeFrom.DateValue > date.MinValue OrElse dpGDGearLastOilChangeTo.DateValue > date.MinValue Then rlc.Add(ComponentInspectionReportGearboxFields.GearboxLastOilChangeDate.Name)
        //    if (GetColumnFilterName("Gear Oil Type"))//.Selected || lbGDGearOilType.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxOilTypeId.Name);
        //    if (GetColumnFilterName("Gear Mechanical Oil Pump"))//Selected || lbGDGearMechOilPump.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxMechanicalOilPumpId.Name);
        //    if (GetColumnFilterName("Gear Oil Level"))//.Selected || lbGDGearOilLevel.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxOilLevelId.Name);
        //    //If GetColumnFilterName("Gear Run Hours").Selected OrElse tbGDGearRunHours.Text.Length > 0 Then rlc.Add(ComponentInspectionReportGearboxFields.GearboxRunHours.Name)
        //    //If GetColumnFilterName("Gear Oil Temp").Selected OrElse tbGDGearOilTemp.Text.Length > 0 Then rlc.Add(ComponentInspectionReportGearboxFields.GearboxOilTemperature.Name)
        //    if (GetColumnFilterName("Gear Production"))//.Selected || tbGDGearProduction.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxProduction.Name);
        //    if (GetColumnFilterName("Gear Generator Manufacturer"))//.Selected || lbGDGearGeneratorManufacturer.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId.Name);
        //    if (GetColumnFilterName("Gear Second Generator Manufacturer"))//.Selected || lbGDGearSecondGeneratorManufacturer.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId2.Name);
        //    if (GetColumnFilterName("Gear Electrical Pump"))//.Selected || lbGDGearElectricalPump.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxElectricalPumpId.Name);
        //    if (GetColumnFilterName("Gear Shrink Element"))//.Selected || lbGDGearShrinkElement.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxShrinkElementId.Name);
        //    if (GetColumnFilterName("Gear Shrink Element Serial Number"))//.Selected || tbGDGearShrinkElementSerialNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxShrinkElementSerialNumber.Name);
        //    if (GetColumnFilterName("Gear Coupling"))//.Selected || lbGDGearCoupling.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxCouplingId.Name);
        //    if (GetColumnFilterName("Gear Filter Block Type"))//.Selected || lbGDGearFilterBlockType.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxFilterBlockTypeId.Name);
        //    if (GetColumnFilterName("Gear In Line Filter"))//.Selected || lbGDGearInLineFilter.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxInLineFilterId.Name);
        //    if (GetColumnFilterName("Gear Off Line Filter"))//.Selected || lbGDGearOffLineFilter.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxOffLineFilterId.Name);
        //    if (GetColumnFilterName("Gear Software Release"))//.Selected || tbGDGearSoftwareRelease.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxSoftwareRelease.Name);
        //    if (GetColumnFilterName("Gear Shaft Location"))//.Selected || lbGDGearShaftLocation.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation1ShaftTypeId.Name);
        //    if (GetColumnFilterName("Gear Shaft Damage Type"))//.Selected || lbGDGearShaftDamageType.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage1ShaftErrorId.Name);
        //    if (GetColumnFilterName("Gear Location"))//.Selected || lbGDGearLocation.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxExactLocation1GearTypeId.Name);
        //    if (GetColumnFilterName("Gear Damage Type"))//.Selected || lbGDGearDamageType.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxTypeofDamage1GearErrorId.Name);
        //    if (GetColumnFilterName("Gear Bearing Location"))//.Selected || lbGDGearBearingLocation.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxBearingsDamage1BearingErrorId.Name);
        //    if (GetColumnFilterName("Gear Bearing Position"))//.Selected || lbGDGearBearingPosition.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition1BearingPosId.Name);
        //    if (GetColumnFilterName("Gear Bearing Damage Type"))//Selected || lbGDGearBearingDamageType.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxTypeofDamage1GearErrorId.Name);
        //    if (GetColumnFilterName("Gear Housing Planet Stage 1"))//.Selected || lbGDGearHousingPlanetStage1.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxPlanetStage1HousingErrorId.Name);
        //    if (GetColumnFilterName("Gear Housing Planet Stage 2"))//.Selected || lbGDGearHousingPlanetStage2.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxPlanetStage2HousingErrorId.Name);
        //    if (GetColumnFilterName("Gear Housing Stage"))//.Selected || lbGDGearHousingStage.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxHelicalStageHousingErrorId.Name);
        //    if (GetColumnFilterName("Gear Housing Front Plate"))//.Selected || lbGDGearHousingFrontPlate.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxFrontPlateHousingErrorId.Name);
        //    if (GetColumnFilterName("Gear Housing Auxilary Stage"))//.Selected || lbGDGearHousingAuxilaryStage.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxAuxStageHousingErrorId.Name);
        //    if (GetColumnFilterName("Gear Housing HS Stage"))//.Selected || lbGDGearHousingHSStage.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxHsstageHousingErrorId.Name);
        //    if (GetColumnFilterName("Gear Torque Loose Bolts"))//.Selected || lbGDGearTorqueLooseBolts.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxLooseBolts.Name);
        //    if (GetColumnFilterName("Gear Torque Broken Bolts"))//.Selected || lbGDGearTorqueBrokenBolts.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxBrokenBolts.Name);
        //    if (GetColumnFilterName("Gear Torque Defect Damper"))//.Selected || lbGDGearTorqueDefectDamper.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxDefectDamperElements.Name);
        //    if (GetColumnFilterName("Gear Torque Too Much Clearance"))//.Selected || lbGDGearTorqueTooMuchClearance.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxTooMuchClearance.Name);
        //    if (GetColumnFilterName("Gear Torque Cracked Broken"))//.Selected || lbGDGearTorqueCrackedBroken.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxCrackedTorqueArm.Name);
        //    if (GetColumnFilterName("Gear Torque Needs Alignment"))//.Selected || lbGDGearTorqueNeedsAlignment.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxNeedsToBeAligned.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. PT100 Bearing 1"))//.Selected || lbGDGearDefectAccPT100Bearing1.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing1.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. PT100 Bearing 2"))//.Selected || lbGDGearDefectAccPT100Bearing2.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing2.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. PT100 Bearing 3"))//.Selected || lbGDGearDefectAccPT100Bearing3.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing3.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. Oil Level Sensor"))//.Selected || lbGDGearDefectAccOilLevelSensor.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxOilLevelSensor.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. Oil Pressure"))//.Selected || lbGDGearDefectAccOilPressure.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxOilPressure.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. PT100 Oil Sump"))//.Selected || lbGDGearDefectAccPT100OilSump.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxPt100OilSump.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. Filter Indicator"))//.Selected || lbGDGearDefectAccFilterIndicator.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxFilterIndicator.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. Immersion Heater"))//.Selected || lbGDGearDefectAccImmersionHeater.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxImmersionHeater.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. Drain Valve"))//.Selected || lbGDGearDefectAccDrainValve.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxDrainValve.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. Air Breather"))//.Selected || lbGDGearDefectAccAirBreather.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxAirBreather.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. Sight Glass"))//.Selected || lbGDGearDefectAccSightGlass.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxSightGlass.Name);
        //    if (GetColumnFilterName("Gear Defect Acc. Chip Detector"))//.Selected || lbGDGearDefectAccChipDetector.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxChipDetector.Name);
        //    if (GetColumnFilterName("Gear Symptoms Vibrations"))//.Selected || lbGDGearSymptomsVibrations.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxVibrationsId.Name);
        //    if (GetColumnFilterName("Gear Symptoms Noise"))//.Selected || lbGDGearSymptomsNoise.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxNoiseId.Name);
        //    if (GetColumnFilterName("Gear Symptoms Debris On Magnet"))//.Selected || lbGDGearSymptomsDebrisOnMagnet.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxDebrisOnMagnetId.Name);
        //    if (GetColumnFilterName("Gear Symptoms Magnet Position"))//.Selected || lbGDGearSymptomsMagnetPosition.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxDebrisStagesMagnetPosId.Name);
        //    if (GetColumnFilterName("Gear Symptoms Debris In Gearbox"))//.Selected || lbGDGearSymptomsDebrisInGearbox.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxDebrisGearBoxId.Name);
        //    //If GetColumnFilterName("Gear Max Temp Reset Date").Selected OrElse dpGDGearMaxTempResetDateFrom.DateValue > date.MinValue OrElse dpGDGearMaxTempResetDateTo.DateValue > date.MinValue Then rlc.Add(ComponentInspectionReportGearboxFields.GearboxMaxTempResetDate.Name)
        //    //If GetColumnFilterName("Gear Max Temp Bearing 1").Selected OrElse tbGDGearMaxTempBearing1.Text.Length > 0 Then rlc.Add(ComponentInspectionReportGearboxFields.GearboxTempBearing1.Name)
        //    //If GetColumnFilterName("Gear Max Temp Bearing 2").Selected OrElse tbGDGearMaxTempBearing2.Text.Length > 0 Then rlc.Add(ComponentInspectionReportGearboxFields.GearboxTempBearing2.Name)
        //    //If GetColumnFilterName("Gear Max Temp Bearing 3").Selected OrElse tbGDGearMaxTempBearing3.Text.Length > 0 Then rlc.Add(ComponentInspectionReportGearboxFields.GearboxTempBearing3.Name)
        //    //If GetColumnFilterName("Gear Max Temp Oil Sump").Selected OrElse tbGDGearMaxTempOilSump.Text.Length > 0 Then rlc.Add(ComponentInspectionReportGearboxFields.GearboxTempOilSump.Name)
        //    if (GetColumnFilterName("Gear Leakage LSS NR End"))//.Selected || lbGDGearLeakageLSSNREnd.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxLssnrend.Name);
        //    if (GetColumnFilterName("Gear Leakage IMS NR End"))//.Selected || lbGDGearLeakageIMSNREnd.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxImsnrend.Name);
        //    if (GetColumnFilterName("Gear Leakage IMS R End"))//.Selected || lbGDGearLeakageIMSREnd.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxImsrend.Name);
        //    if (GetColumnFilterName("Gear Leakage HSS NR End"))//.Selected || lbGDGearLeakageHSSNREnd.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxHssnrend.Name);
        //    if (GetColumnFilterName("Gear Leakage HSS R End"))//.Selected || lbGDGearLeakageHSSREnd.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxHssrend.Name);
        //    if (GetColumnFilterName("Gear Leakage Pitch Tube"))//.Selected || lbGDGearLeakagePitchTube.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxPitchTube.Name);
        //    if (GetColumnFilterName("Gear Leakage Split Lines"))//.Selected || lbGDGearLeakageSplitLines.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxSplitLines.Name);
        //    if (GetColumnFilterName("Gear Leakage Hose Piping"))//.Selected || lbGDGearLeakageHosePiping.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxHoseAndPiping.Name);
        //    if (GetColumnFilterName("Gear Leakage Input Shaft"))//.Selected || lbGDGearLeakageInputShaft.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxInputShaft.Name);
        //    if (GetColumnFilterName("Gear Leakage Aux. HSS/PTO"))//.Selected || lbGDGearLeakageAuxHSSPTO.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportGearboxFields.GearboxHsspto.Name);
        //}

        //private static void CreateBladeResultListColumns(ref ArrayList rlc)
        //{
        //    //If lbColumnsInResultList.Items.FindByText("Blade Claim Relevant").Selected OrElse lbBDClaimRelevant.SelectedIndex > -1 Then rlc.Add(ComponentInspectionReportBladeFields.BladeClaimRelevantBooleanAnswerId.Name)

        //    if (GetColumnFilterName("Blade Length (m)"))//.Selected || lbBDLength.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLengthId.Name);
        //    if (GetColumnFilterName("Blade Color"))//.Selected || lbBDColor.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeColorId.Name);
        //    if (GetColumnFilterName("Blade Serial No."))//.Selected || tbBDSerialNo.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeSerialNumber.Name);
        //    if (GetColumnFilterName("Blade Pictures Included"))//.Selected || lbBDPicturesIncluded.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladePicturesIncludedBooleanAnswerId.Name);
        //    if (GetColumnFilterName("Other Blades In Set"))//.Selected || tbBDSerialNoOther.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeOtherSerialNumber1.Name);
        //    if (GetColumnFilterName("Blade Damage Identified"))//.Selected || lbBDDamageIdentified.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeDamageIdentified.Name);
        //    if (GetColumnFilterName("Blade Damage Placement"))//.Selected || lbBDDamagePlacement.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportBladeDamageFields.BladeDamagePlacementId.Name);
        //    if (GetColumnFilterName("Blade Damage Type"))//.Selected || lbBDDamageType.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportBladeDamageFields.BladeInspectionDataId.Name);
        //    if (GetColumnFilterName("Blade Radius (m)"))//.Selected || tbBDRadius.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeDamageFields.BladeRadius.Name);
        //    if (GetColumnFilterName("Blade Edge"))//.Selected || lbBDEdge.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportBladeDamageFields.BladeEdgeId.Name);
        //    if (GetColumnFilterName("Blade Description"))//.Selected || tbBDDescription.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeDamageFields.BladeDescription.Name);
        //    if (GetColumnFilterName("Blade Fault Code Class"))
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeFaultCodeClassificationId.Name);
        //    if (GetColumnFilterName("Blade Fault Code Cause"))//.Selected || lbBDFCCause.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeFaultCodeCauseId.Name);
        //    if (GetColumnFilterName("Blade Fault Code Type"))//.Selected || lbBDFCType.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeFaultCodeTypeId.Name);
        //    if (GetColumnFilterName("Blade Fault Code Area"))//.Selected || lbBDFCArea.SelectedIndex > -1)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeFaultCodeAreaId.Name);


        //    if (GetColumnFilterName("Blade Light. Sys. VT Number"))//.Selected || tbBDLSVTNumber.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsVtNumber.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Calibration Date"))//.Selected || dpBDLSCalibrationDateFrom.DateValue > System.DateTime.MinValue || dpBDLSCalibrationDateTo.DateValue > System.DateTime.MinValue)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsCalibrationDate.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Leeward Pre-rep. Tip"))//.Selected || tbBDLSLeewardSidePreRepairTip.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepairTip.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Leeward Post-rep. Tip"))//.Selected || tbBDLSLeewardSidePostRepairTip.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepairTip.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Leeward Pre-rep. 2"))
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair2.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Leeward Post-rep. 2"))
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair2.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Leeward Pre-rep. 3"))
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair3.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Leeward Post-rep. 3"))//.Selected || tbBDLSLeewardSidePostRepair3.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair3.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Leeward Pre-rep. 4"))//.Selected || tbBDLSLeewardSidePreRepair4.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair4.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Leeward Post-rep. 4"))//.Selected || tbBDLSLeewardSidePostRepair4.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair4.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Leeward Pre-rep. 5"))//.Selected || tbBDLSLeewardSidePreRepair5.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair5.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Leeward Post-rep. 5"))//.Selected || tbBDLSLeewardSidePostRepair5.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair5.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Windward Pre-rep. Tip"))//.Selected || tbBDLSWindwardSidePreRepairTip.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepairTip.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Windward Post-rep. Tip"))//.Selected || tbBDLSWindwardSidePostRepairTip.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepairTip.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Windward Pre-rep. 2"))//.Selected || tbBDLSWindwardSidePreRepair2.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair2.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Windward Post-rep. 2"))//.Selected || tbBDLSWindwardSidePostRepair2.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair2.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Windward Pre-rep. 3"))//.Selected || tbBDLSWindwardSidePreRepair3.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair3.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Windward Post-rep. 3"))//.Selected || tbBDLSWindwardSidePostRepair3.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair3.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Windward Pre-rep. 4"))//.Selected || tbBDLSWindwardSidePreRepair4.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair4.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Windward Post-rep. 4"))//.Selected || tbBDLSWindwardSidePostRepair4.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair4.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Windward Pre-rep. 5"))//.Selected || tbBDLSWindwardSidePreRepair5.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair5.Name);
        //    if (GetColumnFilterName("Blade Light. Sys. Windward Post-rep. 5"))//.Selected || tbBDLSWindwardSidePostRepair5.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair5.Name);

        //    if (GetColumnFilterName("Blade Rep. Rec. Ambient Temp."))//.Selected || tbBDAmbientTemp.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeAmbientTemp.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Humidity"))//.Selected || tbBDHumidity.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHumidity.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Add. Document Reference"))//.Selected || tbBDDocumentReference.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeAdditionalDocumentReference.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Resin Type"))//.Selected || tbBDResinType.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinType.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Resin Type Batch No."))//.Selected || tbBDResinTypeBatchNo.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeBatchNumbers.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Resin Type Expiry Date"))//.Selected || dpBDResinTypeExpiryDateFrom.DateValue > System.DateTime.MinValue || dpBDResinTypeExpiryDateTo.DateValue > System.DateTime.MinValue)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeExpiryDate.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Hard. Type"))//.Selected || tbBDHardenerType.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerType.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Hard. Type Batch No."))//.Selected || tbBDHardenerTypeBatchNo.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeBatchNumbers.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Hard. Type Expiry Date"))//.Selected || dpBDHardenerTypeExpiryDateFrom.DateValue > System.DateTime.MinValue || dpBDHardenerTypeExpiryDateTo.DateValue > System.DateTime.MinValue)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Glass Supp."))//.Selected || tbBDGlassSupplier.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeGlassSupplier.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Glass Supp. Batch No."))//.Selected || tbBDGlassSupplierBatchNo.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeGlassSupplierBatchNumbers.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Min. Surf. Temp/Lam."))//.Selected || tbBDSurfaceTempMin.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeSurfaceMinTemperature.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Max. Surf. Temp/Lam."))//.Selected || tbBDSurfaceTempMax.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeSurfaceMaxTemperature.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Quantity Mixed Resin"))//.Selected || tbBDQuantityOfResin.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinUsed.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Min. Post Cure Surf. Temp"))//.Selected || tbBDPostCureSurfaceTempMin.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladePostCureMinTemperature.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Max. Post Cure Surf. Temp"))//.Selected || tbBDPostCureSurfaceTempMax.Text.Length > 0)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladePostCureMaxTemperature.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Heaters Etc. Off")) //|| dpBDHeatersEtcOffFrom.DateValue > System.DateTime.MinValue || dpBDHeatersEtcOffTo.DateValue > System.DateTime.MinValue)
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeTurnOffTime.Name);
        //    if (GetColumnFilterName("Blade Rep. Rec. Total Cure Time"))
        //        rlc.Add(ComponentInspectionReportBladeRepairRecordFields.BladeTotalCureTime.Name);
        //}

        //private static void CreateWindTurbineResultListColumns(ref ArrayList rlc)
        //{
        //    if (GetColumnFilterName("Report Type"))
        //        rlc.Add(ComponentInspectionReportFields.ReportTypeId.Name);
        //    if (GetColumnFilterName("Reconstruction"))
        //        rlc.Add(ComponentInspectionReportFields.ReconstructionBooleanAnswerId.Name);
        //    if (GetColumnFilterName("CIM Case Number"))
        //        rlc.Add(ComponentInspectionReportFields.CimcaseNumber.Name);
        //    if (GetColumnFilterName("Reason For Service"))
        //        rlc.Add(ComponentInspectionReportFields.ReasonForService.Name);
        //    if (GetColumnFilterName("Turbine Number"))// || (tbWTDTurbineNo0.Text.Length > 0) | (tbWTDTurbineNo1.Text.Length > 0) | (tbWTDTurbineNo2.Text.Length > 0) | (tbWTDTurbineNo3.Text.Length > 0) | (tbWTDTurbineNo4.Text.Length > 0) | (tbWTDTurbineNo5.Text.Length > 0) | (tbWTDTurbineNo6.Text.Length > 0) | (tbWTDTurbineNo7.Text.Length > 0))
        //    {
        //        rlc.Add(ComponentInspectionReportFields.TurbineNumber.Name);
        //    }

        //    // all mounted on main component
        //    if (GetColumnFilterName("Aux. Equipment"))
        //    {
        //        rlc.Add(ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId.Name);
        //    }

        //    if (GetColumnFilterName("Country"))
        //        rlc.Add(ComponentInspectionReportFields.CountryIsoid.Name);
        //    if (GetColumnFilterName("Site Name"))
        //        rlc.Add(ComponentInspectionReportFields.SiteName.Name);
        //    //If GetColumnFilterName("Turbine Type").Selected OrElse lbWTDTurbineType.SelectedIndex > -1 Then rlc.Add(ComponentInspectionReportFields.TurbineMatrixId.Name)
        //    if (GetColumnFilterName("Turbine Type"))
        //        rlc.Add(TurbineFields.TurbineId.Name);
        //    // KENJA 30-11-10: removing searchable turbine parameters
        //    //If GetColumnFilterName("Rotor Diameter").Selected OrElse lbWTDRotorDiameter.SelectedIndex > -1 Then rlc.Add(TurbineRotorDiameterFields.TurbineRotorDiameterId.Name)
        //    //If GetColumnFilterName("Nominal Power").Selected OrElse lbWTDNominalPower.SelectedIndex > -1 Then rlc.Add(TurbineNominelPowerFields.TurbineNominelPowerId.Name)
        //    //If GetColumnFilterName("Voltage").Selected OrElse lbWTDVoltage.SelectedIndex > -1 Then rlc.Add(TurbineVoltageFields.TurbineVoltageId.Name)
        //    //If GetColumnFilterName("Power Regulation").Selected OrElse lbWTDPowerRegulation.SelectedIndex > -1 Then rlc.Add(TurbinePowerRegulationFields.TurbinePowerRegulationId.Name)
        //    //If GetColumnFilterName("Frequency").Selected OrElse lbWTDFrequency.SelectedIndex > -1 Then rlc.Add(TurbineFrequencyFields.TurbineFrequencyId.Name)
        //    //If GetColumnFilterName("Small Generator").Selected OrElse lbWTDSmallGenerator.SelectedIndex > -1 Then rlc.Add(TurbineSmallGeneratorFields.TurbineSmallGeneratorId.Name)
        //    //If GetColumnFilterName("Temperature Variant").Selected OrElse lbWTDTemperatureVariant.SelectedIndex > -1 Then rlc.Add(TurbineTemperatureVariantFields.TurbineTemperatureVariantId.Name)
        //    //If GetColumnFilterName("MK version").Selected OrElse lbWTDMarkVersion.SelectedIndex > -1 Then rlc.Add(TurbineMarkVersionFields.TurbineMarkVersionId.Name)
        //    //If GetColumnFilterName("Onshore/Offshore").Selected OrElse lbWTDPlacement.SelectedIndex > -1 Then rlc.Add(TurbinePlacementFields.TurbinePlacementId.Name)
        //    //If GetColumnFilterName("Manufacturer").Selected OrElse lbWTDManufacturer.SelectedIndex > -1 Then rlc.Add(TurbineManufacturerFields.TurbineManufacturerId.Name)
        //    //If GetColumnFilterName("Location Type").Selected OrElse lbWTDLocationType.SelectedIndex > -1 Then rlc.Add(ComponentInspectionReportFields.LocationTypeId.Name)
        //    if (GetColumnFilterName("Local Turbine Id"))
        //        rlc.Add(ComponentInspectionReportFields.LocalTurbineId.Name);
        //    if (GetColumnFilterName("Second Generator"))
        //        rlc.Add(ComponentInspectionReportFields.SecondGeneratorBooleanAnswerId.Name);
        //    if (GetColumnFilterName("Run Status Before Inspection"))
        //        rlc.Add(ComponentInspectionReportFields.BeforeInspectionTurbineRunStatusId.Name);
        //    if (GetColumnFilterName("Commisioning Date"))
        //        rlc.Add(ComponentInspectionReportFields.CommisioningDate.Name);
        //    if (GetColumnFilterName("Installation Date"))//.Selected || dpWTDInstallationDateFrom.DateValue > System.DateTime.MinValue || dpWTDInstallationDateTo.DateValue > System.DateTime.MinValue)
        //        rlc.Add(ComponentInspectionReportFields.InstallationDate.Name);
        //    if (GetColumnFilterName("Inspection Date"))
        //        rlc.Add(ComponentInspectionReportFields.InspectionDate.Name);
        //    if (GetColumnFilterName("Failure Date")) 
        //        rlc.Add(ComponentInspectionReportFields.FailureDate.Name);
        //    if (GetColumnFilterName("Service Report Number"))
        //        rlc.Add(ComponentInspectionReportFields.ServiceReportNumber.Name);
        //    if (GetColumnFilterName("Service Report Number Type"))
        //        rlc.Add(ComponentInspectionReportFields.ServiceReportNumberTypeId.Name);
        //    if (GetColumnFilterName("Notification Number"))
        //        rlc.Add(ComponentInspectionReportFields.NotificationNumber.Name);
        //    if (GetColumnFilterName("Service Engineer"))
        //        rlc.Add(ComponentInspectionReportFields.ServiceEngineer.Name);
        //    if (GetColumnFilterName("Run Hours"))
        //        rlc.Add(ComponentInspectionReportFields.RunHours.Name);
        //    if (GetColumnFilterName("Generator 1 Hours"))
        //        rlc.Add(ComponentInspectionReportFields.Generator1Hrs.Name);
        //    if (GetColumnFilterName("Generator 2 Hours"))
        //        rlc.Add(ComponentInspectionReportFields.Generator2Hrs.Name);
        //    if (GetColumnFilterName("Total Production (kWh)"))
        //        rlc.Add(ComponentInspectionReportFields.TotalProduction.Name);
        //    if (GetColumnFilterName("Run Status After Inspection"))
        //        rlc.Add(ComponentInspectionReportFields.AfterInspectionTurbineRunStatusId.Name);
        //    if (GetColumnFilterName("Vestas Item No."))
        //        rlc.Add(ComponentInspectionReportFields.VestasItemNumber.Name);
        //    if (GetColumnFilterName("Quan. Failed Comp."))
        //        rlc.Add(ComponentInspectionReportFields.Quantity.Name);
        //    if (GetColumnFilterName("Alarm Log Number"))
        //        rlc.Add(ComponentInspectionReportFields.AlarmLogNumber.Name);
        //    if (GetColumnFilterName("Description"))
        //        rlc.Add(ComponentInspectionReportFields.Description.Name);
        //    if (GetColumnFilterName("Desc. Of Conseq. Prob./Dam."))
        //        rlc.Add(ComponentInspectionReportFields.DescriptionConsquential.Name);
        //    if (GetColumnFilterName("Conducted By"))
        //        rlc.Add(ComponentInspectionReportFields.ConductedBy.Name);
        //}             

        private static void FillGeneralColumns(ComponentInspectionReportEntity entity, DataRow dr)
        {

            if (entity.ComponentInspectionReportGeneral.Count == 1)
            {
                if (entity.ComponentInspectionReportGeneral[0].ComponentGroup != null)
                    dr[ComponentInspectionReportGeneralFields.GeneralComponentGroupId.Name] = entity.ComponentInspectionReportGeneral[0].ComponentGroup.Name;
                dr[ComponentInspectionReportGeneralFields.GeneralComponentType.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportGeneral[0].GeneralComponentType);
                dr[ComponentInspectionReportGeneralFields.GeneralComponentManufacturer.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportGeneral[0].GeneralComponentManufacturer);
                dr[ComponentInspectionReportGeneralFields.GeneralOtherGearboxType.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportGeneral[0].GeneralOtherGearboxType);
                //If entity.ComponentInspectionReportGeneral[0].BooleanAnswer IsNot Nothing Then dr[ComponentInspectionReportGeneralFields.GeneralClaimRelevantBooleanAnswerId.Name] = entity.ComponentInspectionReportGeneral[0].BooleanAnswer.Name
                dr[ComponentInspectionReportGeneralFields.GeneralOtherGearboxManufacturer.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportGeneral[0].GeneralOtherGearboxManufacturer);
                dr[ComponentInspectionReportGeneralFields.GeneralComponentSerialNumber.Name] = entity.ComponentInspectionReportGeneral[0].GeneralComponentSerialNumber;
                if (entity.ComponentInspectionReportGeneral[0].GeneratorManufacturer != null)
                    dr[ComponentInspectionReportGeneralFields.GeneralGeneratorManufacturerId.Name] = entity.ComponentInspectionReportGeneral[0].GeneratorManufacturer.Name;
                if (entity.ComponentInspectionReportGeneral[0].TransformerManufacturer != null)
                    dr[ComponentInspectionReportGeneralFields.GeneralTransformerManufacturerId.Name] = entity.ComponentInspectionReportGeneral[0].TransformerManufacturer.Name;
                if (entity.ComponentInspectionReportGeneral[0].GearboxManufacturer != null)
                    dr[ComponentInspectionReportGeneralFields.GeneralGearboxManufacturerId.Name] = entity.ComponentInspectionReportGeneral[0].GearboxManufacturer.Name;
                if (entity.ComponentInspectionReportGeneral[0].TowerType != null)
                    dr[ComponentInspectionReportGeneralFields.GeneralTowerTypeId.Name] = entity.ComponentInspectionReportGeneral[0].TowerType.Name;
                if (entity.ComponentInspectionReportGeneral[0].TowerHeight != null)
                    dr[ComponentInspectionReportGeneralFields.GeneralTowerHeightId.Name] = entity.ComponentInspectionReportGeneral[0].TowerHeight.Name;
                StringBuilder sb = new StringBuilder();
                if (entity.ComponentInspectionReportGeneral[0].GeneralBlade1SerialNumber != null)
                    sb.Append(entity.ComponentInspectionReportGeneral[0].GeneralBlade1SerialNumber);
                if (entity.ComponentInspectionReportGeneral[0].GeneralBlade2SerialNumber != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGeneral[0].GeneralBlade2SerialNumber);
                if (entity.ComponentInspectionReportGeneral[0].GeneralBlade3SerialNumber != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGeneral[0].GeneralBlade3SerialNumber);
                dr[ComponentInspectionReportGeneralFields.GeneralBlade1SerialNumber.Name] = sb.ToString();
                if (entity.ComponentInspectionReportGeneral[0].ControllerType != null)
                    dr[ComponentInspectionReportGeneralFields.GeneralControllerTypeId.Name] = entity.ComponentInspectionReportGeneral[0].ControllerType.Name;
                dr[ComponentInspectionReportGeneralFields.GeneralSoftwareRelease.Name] = entity.ComponentInspectionReportGeneral[0].GeneralSoftwareRelease;
                if (entity.ComponentInspectionReportGeneral[0].GeneralRamDumpNumber.HasValue)
                    dr[ComponentInspectionReportGeneralFields.GeneralRamDumpNumber.Name] = entity.ComponentInspectionReportGeneral[0].GeneralRamDumpNumber.Value;
                if (entity.ComponentInspectionReportGeneral[0].GeneralVdftrackNumber.HasValue)
                    dr[ComponentInspectionReportGeneralFields.GeneralVdftrackNumber.Name] = entity.ComponentInspectionReportGeneral[0].GeneralVdftrackNumber.Value;
                dr[ComponentInspectionReportGeneralFields.GeneralPicturesIncludedBooleanAnswerId.Name] = entity.ComponentInspectionReportGeneral[0].BooleanAnswer_.Name;
                sb = new StringBuilder();
                if (entity.ComponentInspectionReportGeneral[0].GeneralInitiatedBy1 != null)
                    sb.Append(entity.ComponentInspectionReportGeneral[0].GeneralInitiatedBy1);
                if (entity.ComponentInspectionReportGeneral[0].GeneralInitiatedBy2 != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGeneral[0].GeneralInitiatedBy2);
                if (entity.ComponentInspectionReportGeneral[0].GeneralInitiatedBy3 != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGeneral[0].GeneralInitiatedBy3);
                if (entity.ComponentInspectionReportGeneral[0].GeneralInitiatedBy4 != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGeneral[0].GeneralInitiatedBy4);
                dr[ComponentInspectionReportGeneralFields.GeneralInitiatedBy1.Name] = sb.ToString();
                sb = new StringBuilder();
                if (entity.ComponentInspectionReportGeneral[0].GeneralMeasurementsConducted1 != null)
                    sb.Append(entity.ComponentInspectionReportGeneral[0].GeneralMeasurementsConducted1);
                if (entity.ComponentInspectionReportGeneral[0].GeneralMeasurementsConducted2 != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGeneral[0].GeneralMeasurementsConducted2);
                if (entity.ComponentInspectionReportGeneral[0].GeneralMeasurementsConducted3 != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGeneral[0].GeneralMeasurementsConducted3);
                if (entity.ComponentInspectionReportGeneral[0].GeneralMeasurementsConducted4 != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGeneral[0].GeneralMeasurementsConducted4);
                dr[ComponentInspectionReportGeneralFields.GeneralMeasurementsConducted1.Name] = sb.ToString();
                sb = new StringBuilder();
                if (entity.ComponentInspectionReportGeneral[0].GeneralExecutedBy1 != null)
                    sb.Append(entity.ComponentInspectionReportGeneral[0].GeneralExecutedBy1);
                if (entity.ComponentInspectionReportGeneral[0].GeneralExecutedBy2 != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGeneral[0].GeneralExecutedBy2);
                if (entity.ComponentInspectionReportGeneral[0].GeneralExecutedBy3 != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGeneral[0].GeneralExecutedBy3);
                if (entity.ComponentInspectionReportGeneral[0].GeneralExecutedBy4 != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGeneral[0].GeneralExecutedBy4);
                dr[ComponentInspectionReportGeneralFields.GeneralExecutedBy1.Name] = sb.ToString();
                if (entity.ComponentInspectionReportGeneral[0].GeneralPositionOfFailedItem != null)
                    dr[ComponentInspectionReportGeneralFields.GeneralPositionOfFailedItem.Name] = entity.ComponentInspectionReportGeneral[0].GeneralPositionOfFailedItem;
            }



        }

        private static void FillGeneratorColumns(ComponentInspectionReportEntity entity, DataRow dr)
        {

            if (entity.ComponentInspectionReportGenerator.Count == 1)
            {
                dr[ComponentInspectionReportGeneratorFields.GeneratorManufacturerId.Name] = entity.ComponentInspectionReportGenerator[0].GeneratorManufacturer.Name;
                //Added new field for Generator OtherManufacturer
                dr[ComponentInspectionReportGeneratorFields.OtherManufacturer.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportGenerator[0].OtherManufacturer);

                dr[ComponentInspectionReportGeneratorFields.GeneratorSerialNumber.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportGenerator[0].GeneratorSerialNumber);
                dr[ComponentInspectionReportGeneratorFields.GeneratorComments.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportGenerator[0].GeneratorComments);
                dr[ComponentInspectionReportGeneratorFields.GeneratorRewoundLocally.Name] = (entity.ComponentInspectionReportGenerator[0].GeneratorRewoundLocally ? "Yes" : "No");
                dr[ComponentInspectionReportGeneratorFields.GeneratorMaxTemperature.Name] = entity.ComponentInspectionReportGenerator[0].GeneratorMaxTemperature;
                dr[ComponentInspectionReportGeneratorFields.GeneratorMaxTemperatureResetDate.Name] = entity.ComponentInspectionReportGenerator[0].GeneratorMaxTemperatureResetDate;
                dr[ComponentInspectionReportGeneratorFields.ActionToBeTakenOnGeneratorId.Name] = entity.ComponentInspectionReportGenerator[0].ActionToBeTakenOnGenerator.Name;

                dr[ComponentInspectionReportGeneratorFields.GeneratorDriveEndId.Name] = entity.ComponentInspectionReportGenerator[0].GeneratorDriveEnd.Name;
                dr[ComponentInspectionReportGeneratorFields.GeneratorNonDriveEndId.Name] = entity.ComponentInspectionReportGenerator[0].GeneratorNonDriveEnd.Name;
                dr[ComponentInspectionReportGeneratorFields.GeneratorRotorId.Name] = entity.ComponentInspectionReportGenerator[0].GeneratorRotor.Name;
                dr[ComponentInspectionReportGeneratorFields.GeneratorCoverId.Name] = entity.ComponentInspectionReportGenerator[0].GeneratorCover.Name;

                if (entity.ComponentInspectionReportGenerator[0].U1U2.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.U1U2.Name] = entity.ComponentInspectionReportGenerator[0].U1U2.Value;
                if (entity.ComponentInspectionReportGenerator[0].V1V2.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.V1V2.Name] = entity.ComponentInspectionReportGenerator[0].V1V2.Value;
                if (entity.ComponentInspectionReportGenerator[0].W1W2.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.W1W2.Name] = entity.ComponentInspectionReportGenerator[0].W1W2.Value;
                if (entity.ComponentInspectionReportGenerator[0].K1L1.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.K1L1.Name] = entity.ComponentInspectionReportGenerator[0].K1L1.Value;
                if (entity.ComponentInspectionReportGenerator[0].L1M1.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.L1M1.Name] = entity.ComponentInspectionReportGenerator[0].L1M1.Value;
                if (entity.ComponentInspectionReportGenerator[0].K1M1.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.K1M1.Name] = entity.ComponentInspectionReportGenerator[0].K1M1.Value;
                if (entity.ComponentInspectionReportGenerator[0].K2L2.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.K2L2.Name] = entity.ComponentInspectionReportGenerator[0].K2L2.Value;
                if (entity.ComponentInspectionReportGenerator[0].L2M2.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.L2M2.Name] = entity.ComponentInspectionReportGenerator[0].L2M2.Value;
                if (entity.ComponentInspectionReportGenerator[0].K2M2.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.K2M2.Name] = entity.ComponentInspectionReportGenerator[0].K2M2.Value;

                if (entity.ComponentInspectionReportGenerator[0].Uground.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.Uground.Name] = entity.ComponentInspectionReportGenerator[0].Uground.Value;
                if (entity.ComponentInspectionReportGenerator[0].Vground.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.Vground.Name] = entity.ComponentInspectionReportGenerator[0].Vground.Value;
                if (entity.ComponentInspectionReportGenerator[0].Wground.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.Wground.Name] = entity.ComponentInspectionReportGenerator[0].Wground.Value;
                if (entity.ComponentInspectionReportGenerator[0].Uv.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.Uv.Name] = entity.ComponentInspectionReportGenerator[0].Uv.Value;
                if (entity.ComponentInspectionReportGenerator[0].Uw.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.Uw.Name] = entity.ComponentInspectionReportGenerator[0].Uw.Value;
                if (entity.ComponentInspectionReportGenerator[0].Vw.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.Vw.Name] = entity.ComponentInspectionReportGenerator[0].Vw.Value;
                if (entity.ComponentInspectionReportGenerator[0].Kground.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.Kground.Name] = entity.ComponentInspectionReportGenerator[0].Kground.Value;
                if (entity.ComponentInspectionReportGenerator[0].Lground.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.Lground.Name] = entity.ComponentInspectionReportGenerator[0].Lground.Value;
                if (entity.ComponentInspectionReportGenerator[0].Mground.HasValue)
                    dr[ComponentInspectionReportGeneratorFields.Mground.Name] = entity.ComponentInspectionReportGenerator[0].Mground.Value;

                if (entity.ComponentInspectionReportGenerator[0].OhmUnit != null)
                    dr[ComponentInspectionReportGeneratorFields.UgroundOhmUnitId.Name] = entity.ComponentInspectionReportGenerator[0].OhmUnit.Name;
                if (entity.ComponentInspectionReportGenerator[0].OhmUnit_ != null)
                    dr[ComponentInspectionReportGeneratorFields.VgroundOhmUnitId.Name] = entity.ComponentInspectionReportGenerator[0].OhmUnit_.Name;
                if (entity.ComponentInspectionReportGenerator[0].OhmUnit__ != null)
                    dr[ComponentInspectionReportGeneratorFields.WgroundOhmUnitId.Name] = entity.ComponentInspectionReportGenerator[0].OhmUnit__.Name;
                if (entity.ComponentInspectionReportGenerator[0].OhmUnit___ != null)
                    dr[ComponentInspectionReportGeneratorFields.UvohmUnitId.Name] = entity.ComponentInspectionReportGenerator[0].OhmUnit___.Name;
                if (entity.ComponentInspectionReportGenerator[0].OhmUnit____ != null)
                    dr[ComponentInspectionReportGeneratorFields.UwohmUnitId.Name] = entity.ComponentInspectionReportGenerator[0].OhmUnit____.Name;
                if (entity.ComponentInspectionReportGenerator[0].OhmUnit_____ != null)
                    dr[ComponentInspectionReportGeneratorFields.VwohmUnitId.Name] = entity.ComponentInspectionReportGenerator[0].OhmUnit_____.Name;
                if (entity.ComponentInspectionReportGenerator[0].OhmUnit______ != null)
                    dr[ComponentInspectionReportGeneratorFields.KgroundOhmUnitId.Name] = entity.ComponentInspectionReportGenerator[0].OhmUnit______.Name;
                if (entity.ComponentInspectionReportGenerator[0].OhmUnit_______ != null)
                    dr[ComponentInspectionReportGeneratorFields.LgroundOhmUnitId.Name] = entity.ComponentInspectionReportGenerator[0].OhmUnit_______.Name;
                if (entity.ComponentInspectionReportGenerator[0].OhmUnit________ != null)
                    dr[ComponentInspectionReportGeneratorFields.MgroundOhmUnitId.Name] = entity.ComponentInspectionReportGenerator[0].OhmUnit________.Name;

            }


        }

        private static void FillMainBearingColumns(ComponentInspectionReportEntity entity, DataRow dr)
        {

            if (entity.ComponentInspectionReportMainBearing.Count == 1)
            {
                dr[ComponentInspectionReportMainBearingFields.MainBearingLastLubricationDate.Name] = entity.ComponentInspectionReportMainBearing[0].MainBearingLastLubricationDate;
                dr[ComponentInspectionReportMainBearingFields.MainBearingManufacturerId.Name] = (entity.ComponentInspectionReportMainBearing[0].MainBearingManufacturerId == null) ? "" : entity.ComponentInspectionReportMainBearing[0].MainBearingManufacturer.Name;
                if (entity.ComponentInspectionReportMainBearing[0].MainBearingTemperature.HasValue)
                    dr[ComponentInspectionReportMainBearingFields.MainBearingTemperature.Name] = entity.ComponentInspectionReportMainBearing[0].MainBearingTemperature;
                if (entity.ComponentInspectionReportMainBearing[0].OilType != null)
                    dr[ComponentInspectionReportMainBearingFields.MainBearingLubricationOilTypeId.Name] = entity.ComponentInspectionReportMainBearing[0].OilType.Name;
                dr[ComponentInspectionReportMainBearingFields.MainBearingLubricationRunHours.Name] = entity.ComponentInspectionReportMainBearing[0].MainBearingLubricationRunHours;
                if (entity.ComponentInspectionReportMainBearing[0].MainBearingOilTemperature.HasValue)
                    dr[ComponentInspectionReportMainBearingFields.MainBearingOilTemperature.Name] = entity.ComponentInspectionReportMainBearing[0].MainBearingOilTemperature;
                dr[ComponentInspectionReportMainBearingFields.MainBearingTypeId.Name] = entity.ComponentInspectionReportMainBearing[0].MainBearingManufacturer_.Name;
                dr[ComponentInspectionReportMainBearingFields.MainBearingRevision.Name] = entity.ComponentInspectionReportMainBearing[0].MainBearingRevision;
                if (entity.ComponentInspectionReportMainBearing[0].MainBearingErrorLocation != null)
                    dr[ComponentInspectionReportMainBearingFields.MainBearingErrorLocationId.Name] = entity.ComponentInspectionReportMainBearing[0].MainBearingErrorLocation.Name;
                dr[ComponentInspectionReportMainBearingFields.MainBearingSerialNumber.Name] = entity.ComponentInspectionReportMainBearing[0].MainBearingSerialNumber;
                if (entity.ComponentInspectionReportMainBearing[0].MainBearingRunHours.HasValue)
                    dr[ComponentInspectionReportMainBearingFields.MainBearingRunHours.Name] = entity.ComponentInspectionReportMainBearing[0].MainBearingRunHours;
                dr[ComponentInspectionReportMainBearingFields.MainBearingMechanicalOilPump.Name] = entity.ComponentInspectionReportMainBearing[0].MainBearingMechanicalOilPump;
            }



        }

        private static void FillSkiiPColumns(ComponentInspectionReportEntity entity, DataRow dr)
        {

            if (entity.ComponentInspectionReportSkiiP.Count == 1)
            {
                StringBuilder sbSNO = new StringBuilder();
                StringBuilder sbVUI = new StringBuilder();
                StringBuilder sbVIN = new StringBuilder();
                foreach (ComponentInspectionReportSkiiPfailedComponentEntity subentity_loopVariable in entity.ComponentInspectionReportSkiiP[0].ComponentInspectionReportSkiiPfailedComponent)
                {

                    sbSNO.AppendFormat("{0}{1}", " ", HttpUtility.HtmlEncode(subentity_loopVariable.SkiiPfailedComponentSerialNumber));
                    sbVUI.AppendFormat("{0}{1}", " ", HttpUtility.HtmlEncode(subentity_loopVariable.SkiiPfailedComponentVestasUniqueIdentifier));
                    sbVIN.AppendFormat("{0}{1}", " ", HttpUtility.HtmlEncode(subentity_loopVariable.SkiiPfailedComponentVestasItemNumber));
                }
                dr[ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentSerialNumber.Name] = sbSNO.ToString();
                dr[ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentVestasUniqueIdentifier.Name] = sbVUI.ToString();
                dr[ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentVestasItemNumber.Name] = sbVIN.ToString();
                sbSNO = new StringBuilder();
                sbVUI = new StringBuilder();
                sbVIN = new StringBuilder();
                foreach (ComponentInspectionReportSkiiPnewComponentEntity subentity_loopVariable in entity.ComponentInspectionReportSkiiP[0].ComponentInspectionReportSkiiPnewComponent)
                {

                    sbSNO.AppendFormat("{0}{1}", " ", HttpUtility.HtmlEncode(subentity_loopVariable.SkiiPnewComponentSerialNumber));
                    sbVUI.AppendFormat("{0}{1}", " ", HttpUtility.HtmlEncode(subentity_loopVariable.SkiiPnewComponentVestasUniqueIdentifier));
                    sbVIN.AppendFormat("{0}{1}", " ", HttpUtility.HtmlEncode(subentity_loopVariable.SkiiPnewComponentVestasItemNumber));
                }
                dr[ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentSerialNumber.Name] = sbSNO.ToString();
                dr[ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentVestasUniqueIdentifier.Name] = sbVUI.ToString();
                dr[ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentVestasItemNumber.Name] = sbVIN.ToString();
                dr[ComponentInspectionReportSkiiPFields.SkiiPotherDamagedComponentsReplaced.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportSkiiP[0].SkiiPotherDamagedComponentsReplaced);
                dr[ComponentInspectionReportSkiiPFields.SkiiPcauseId.Name] = entity.ComponentInspectionReportSkiiP[0].SkiipackFailureCause.Name;
                dr[ComponentInspectionReportSkiiPFields.SkiiPquantityOfFailedModules.Name] = entity.ComponentInspectionReportSkiiP[0].SkiiPquantityOfFailedModules;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP2Mwv522BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer__ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP2Mwv523BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer__.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer___ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP2Mwv524BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer___.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer____ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP2Mwv525BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer____.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_____ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP2Mwv526BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_____.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer______ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP3Mwv521BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer______.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_______ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP3Mwv522BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_______.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer________ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP3Mwv523BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer________.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_________ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP3Mwv524xBooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_________.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer__________ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP3Mwv524yBooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer__________.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer___________ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP3Mwv525xBooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer___________.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer____________ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP3Mwv525yBooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer____________.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_____________ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP3Mwv526xBooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_____________.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer______________ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP3Mwv526yBooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer______________.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_______________ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP850Kwv520BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_______________.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer________________ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP850Kwv524BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer________________.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_________________ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP850Kwv525BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer_________________.Name;
                if (entity.ComponentInspectionReportSkiiP[0].BooleanAnswer__________________ != null)
                    dr[ComponentInspectionReportSkiiPFields.SkiiP850Kwv526BooleanAnswerId.Name] = entity.ComponentInspectionReportSkiiP[0].BooleanAnswer__________________.Name;
            }


        }

        private static void FillTransformerColumns(ComponentInspectionReportEntity entity, DataRow dr)
        {

            if (entity.ComponentInspectionReportTransformer.Count == 1)
            {
                dr[ComponentInspectionReportTransformerFields.TransformerManufacturerId.Name] = entity.ComponentInspectionReportTransformer[0].TransformerManufacturer.Name;
                dr[ComponentInspectionReportTransformerFields.TransformerSerialNumber.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportTransformer[0].TransformerSerialNumber);
                dr[ComponentInspectionReportTransformerFields.TransformerArcDetectionId.Name] = entity.ComponentInspectionReportTransformer[0].ArcDetection.Name;

                if (entity.ComponentInspectionReportTransformer[0].MaxTemp.HasValue)
                {
                    dr[ComponentInspectionReportTransformerFields.MaxTemp.Name] = entity.ComponentInspectionReportTransformer[0].MaxTemp.Value;
                }
                if (entity.ComponentInspectionReportTransformer[0].MaxTempResetDate.HasValue)
                {
                    dr[ComponentInspectionReportTransformerFields.MaxTempResetDate.Name] = entity.ComponentInspectionReportTransformer[0].MaxTempResetDate.Value;
                }

                dr[ComponentInspectionReportTransformerFields.ActionOnTransformerId.Name] = entity.ComponentInspectionReportTransformer[0].ActionOnTransformer.Name;
                dr[ComponentInspectionReportTransformerFields.HvcoilConditionId.Name] = entity.ComponentInspectionReportTransformer[0].CoilCondition.Name;
                dr[ComponentInspectionReportTransformerFields.LvcoilConditionId.Name] = entity.ComponentInspectionReportTransformer[0].CoilCondition_.Name;
                dr[ComponentInspectionReportTransformerFields.HvcableConditionId.Name] = entity.ComponentInspectionReportTransformer[0].CableCondition.Name;
                dr[ComponentInspectionReportTransformerFields.LvcableConditionId.Name] = entity.ComponentInspectionReportTransformer[0].CableCondition_.Name;
                dr[ComponentInspectionReportTransformerFields.BracketsId.Name] = entity.ComponentInspectionReportTransformer[0].Brackets.Name;
                dr[ComponentInspectionReportTransformerFields.ClimateId.Name] = entity.ComponentInspectionReportTransformer[0].Climate.Name;
                dr[ComponentInspectionReportTransformerFields.SurgeArrestorId.Name] = entity.ComponentInspectionReportTransformer[0].SurgeArrestor.Name;
                dr[ComponentInspectionReportTransformerFields.ConnectionBarsId.Name] = entity.ComponentInspectionReportTransformer[0].ConnectionBars.Name;

                if ((entity.ComponentInspectionReportTransformer[0].Comments != null))
                {
                    dr[ComponentInspectionReportTransformerFields.Comments.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportTransformer[0].Comments);
                }
            }



        }

        private static void FillGearColumns(ComponentInspectionReportEntity entity, DataRow dr)
        {

            if (entity.ComponentInspectionReportGearbox.Count == 1)
            {
                if (entity.ComponentInspectionReportGearbox[0].GearboxType != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxTypeId.Name] = entity.ComponentInspectionReportGearbox[0].GearboxType.Name;
                dr[ComponentInspectionReportGearboxFields.OtherGearboxType.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportGearbox[0].OtherGearboxType);
                dr[ComponentInspectionReportGearboxFields.GearboxRevisionId.Name] = entity.ComponentInspectionReportGearbox[0].GearboxRevision.Name;
                dr[ComponentInspectionReportGearboxFields.GearboxManufacturerId.Name] = entity.ComponentInspectionReportGearbox[0].GearboxManufacturer.Name;
                dr[ComponentInspectionReportGearboxFields.GearboxOtherManufacturer.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportGearbox[0].GearboxOtherManufacturer);
                dr[ComponentInspectionReportGearboxFields.GearboxSerialNumber.Name] = entity.ComponentInspectionReportGearbox[0].GearboxSerialNumber;
                if (entity.ComponentInspectionReportGearbox[0].GearboxLastOilChangeDate.HasValue)
                    dr[ComponentInspectionReportGearboxFields.GearboxLastOilChangeDate.Name] = entity.ComponentInspectionReportGearbox[0].GearboxLastOilChangeDate.Value;
                dr[ComponentInspectionReportGearboxFields.GearboxOilTypeId.Name] = entity.ComponentInspectionReportGearbox[0].OilType.Name;
                dr[ComponentInspectionReportGearboxFields.GearboxMechanicalOilPumpId.Name] = entity.ComponentInspectionReportGearbox[0].MechanicalOilPump.Name;
                dr[ComponentInspectionReportGearboxFields.GearboxOilLevelId.Name] = entity.ComponentInspectionReportGearbox[0].OilLevel.Name;
                if (entity.ComponentInspectionReportGearbox[0].GearboxRunHours.HasValue)
                    dr[ComponentInspectionReportGearboxFields.GearboxRunHours.Name] = entity.ComponentInspectionReportGearbox[0].GearboxRunHours.Value;
                dr[ComponentInspectionReportGearboxFields.GearboxOilTemperature.Name] = entity.ComponentInspectionReportGearbox[0].GearboxOilTemperature;
                if (entity.ComponentInspectionReportGearbox[0].GearboxProduction.HasValue)
                    dr[ComponentInspectionReportGearboxFields.GearboxProduction.Name] = entity.ComponentInspectionReportGearbox[0].GearboxProduction.Value;
                if (entity.ComponentInspectionReportGearbox[0].GeneratorManufacturer != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId.Name] = entity.ComponentInspectionReportGearbox[0].GeneratorManufacturer.Name;
                if (entity.ComponentInspectionReportGearbox[0].GeneratorManufacturer_ != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId2.Name] = entity.ComponentInspectionReportGearbox[0].GeneratorManufacturer_.Name;
                if (entity.ComponentInspectionReportGearbox[0].ElectricalPump != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxElectricalPumpId.Name] = entity.ComponentInspectionReportGearbox[0].ElectricalPump.Name;
                if (entity.ComponentInspectionReportGearbox[0].ShrinkElement != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxShrinkElementId.Name] = entity.ComponentInspectionReportGearbox[0].ShrinkElement.Name;
                dr[ComponentInspectionReportGearboxFields.GearboxShrinkElementSerialNumber.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportGearbox[0].GearboxShrinkElementSerialNumber);
                if (entity.ComponentInspectionReportGearbox[0].Coupling != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxCouplingId.Name] = entity.ComponentInspectionReportGearbox[0].Coupling.Name;
                if (entity.ComponentInspectionReportGearbox[0].FilterBlockType != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxFilterBlockTypeId.Name] = entity.ComponentInspectionReportGearbox[0].FilterBlockType.Name;
                if (entity.ComponentInspectionReportGearbox[0].InlineFilter != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxInLineFilterId.Name] = entity.ComponentInspectionReportGearbox[0].InlineFilter.Name;
                if (entity.ComponentInspectionReportGearbox[0].BooleanAnswer != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxOffLineFilterId.Name] = entity.ComponentInspectionReportGearbox[0].BooleanAnswer.Name;
                dr[ComponentInspectionReportGearboxFields.GearboxSoftwareRelease.Name] = entity.ComponentInspectionReportGearbox[0].GearboxSoftwareRelease;
                StringBuilder sb = new StringBuilder();
                if (entity.ComponentInspectionReportGearbox[0].ShaftType != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].ShaftType.Name);
                if (entity.ComponentInspectionReportGearbox[0].ShaftType_ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].ShaftType_.Name);
                if (entity.ComponentInspectionReportGearbox[0].ShaftType__ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].ShaftType__.Name);
                if (entity.ComponentInspectionReportGearbox[0].ShaftType___ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].ShaftType___.Name);
                dr[ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation1ShaftTypeId.Name] = sb.ToString();
                sb = new StringBuilder();
                if (entity.ComponentInspectionReportGearbox[0].ShaftError != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].ShaftError.Name);
                if (entity.ComponentInspectionReportGearbox[0].ShaftError_ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].ShaftError_.Name);
                if (entity.ComponentInspectionReportGearbox[0].ShaftError__ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].ShaftError__.Name);
                if (entity.ComponentInspectionReportGearbox[0].ShaftError___ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].ShaftError___.Name);
                dr[ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage1ShaftErrorId.Name] = sb.ToString();
                sb = new StringBuilder();
                if (entity.ComponentInspectionReportGearbox[0].GearType != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].GearType.Name);
                if (entity.ComponentInspectionReportGearbox[0].GearType_ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].GearType_.Name);
                if (entity.ComponentInspectionReportGearbox[0].GearType__ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].GearType__.Name);
                if (entity.ComponentInspectionReportGearbox[0].GearType___ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].GearType___.Name);
                if (entity.ComponentInspectionReportGearbox[0].GearType____ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].GearType____.Name);
                dr[ComponentInspectionReportGearboxFields.GearboxExactLocation1GearTypeId.Name] = sb.ToString();
                sb = new StringBuilder();
                if (entity.ComponentInspectionReportGearbox[0].GearError != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].GearError.Name);
                if (entity.ComponentInspectionReportGearbox[0].GearError_ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].GearError_.Name);
                if (entity.ComponentInspectionReportGearbox[0].GearError__ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].GearError__.Name);
                if (entity.ComponentInspectionReportGearbox[0].GearError___ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].GearError___.Name);
                if (entity.ComponentInspectionReportGearbox[0].GearError____ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].GearError____.Name);
                dr[ComponentInspectionReportGearboxFields.GearboxTypeofDamage1GearErrorId.Name] = sb.ToString();
                sb = new StringBuilder();
                if (entity.ComponentInspectionReportGearbox[0].BearingType != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingType.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingType_ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingType_.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingType__ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingType__.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingType___ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingType___.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingType____ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingType____.Name);
                dr[ComponentInspectionReportGearboxFields.GearboxBearingsLocation1BearingTypeId.Name] = sb.ToString();
                sb = new StringBuilder();
                if (entity.ComponentInspectionReportGearbox[0].BearingPos != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingPos.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingPos_ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingPos_.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingPos__ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingPos__.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingPos___ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingPos___.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingPos____ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingPos____.Name);
                dr[ComponentInspectionReportGearboxFields.GearboxBearingsPosition1BearingPosId.Name] = sb.ToString();
                sb = new StringBuilder();
                if (entity.ComponentInspectionReportGearbox[0].BearingError != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingError.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingError_ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingError_.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingError__ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingError__.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingError___ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingError___.Name);
                if (entity.ComponentInspectionReportGearbox[0].BearingError____ != null)
                    sb.AppendFormat("{0}{1}", " ", entity.ComponentInspectionReportGearbox[0].BearingError____.Name);
                dr[ComponentInspectionReportGearboxFields.GearboxBearingsDamage1BearingErrorId.Name] = sb.ToString();
                if (entity.ComponentInspectionReportGearbox[0].HousingError != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxPlanetStage1HousingErrorId.Name] = entity.ComponentInspectionReportGearbox[0].HousingError.Name;
                if (entity.ComponentInspectionReportGearbox[0].HousingError_ != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxPlanetStage2HousingErrorId.Name] = entity.ComponentInspectionReportGearbox[0].HousingError_.Name;
                if (entity.ComponentInspectionReportGearbox[0].HousingError__ != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxHelicalStageHousingErrorId.Name] = entity.ComponentInspectionReportGearbox[0].HousingError__.Name;
                if (entity.ComponentInspectionReportGearbox[0].HousingError___ != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxFrontPlateHousingErrorId.Name] = entity.ComponentInspectionReportGearbox[0].HousingError___.Name;
                if (entity.ComponentInspectionReportGearbox[0].HousingError____ != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxAuxStageHousingErrorId.Name] = entity.ComponentInspectionReportGearbox[0].HousingError____.Name;
                if (entity.ComponentInspectionReportGearbox[0].HousingError_____ != null)
                    dr[ComponentInspectionReportGearboxFields.GearboxHsstageHousingErrorId.Name] = entity.ComponentInspectionReportGearbox[0].HousingError_____.Name;
                dr[ComponentInspectionReportGearboxFields.GearboxLooseBolts.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxLooseBolts ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxBrokenBolts.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxBrokenBolts ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxDefectDamperElements.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxDefectDamperElements ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxTooMuchClearance.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxTooMuchClearance ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxCrackedTorqueArm.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxCrackedTorqueArm ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxNeedsToBeAligned.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxNeedsToBeAligned ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxPt100Bearing1.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxPt100Bearing1 ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxPt100Bearing2.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxPt100Bearing2 ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxPt100Bearing3.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxPt100Bearing3 ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxOilLevelSensor.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxOilLevelSensor ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxOilPressure.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxOilPressure ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxPt100OilSump.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxPt100OilSump ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxFilterIndicator.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxFilterIndicator ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxImmersionHeater.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxImmersionHeater ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxDrainValve.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxDrainValve ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxAirBreather.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxAirBreather ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxSightGlass.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxSightGlass ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxChipDetector.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxChipDetector ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxVibrationsId.Name] = entity.ComponentInspectionReportGearbox[0].Vibrations.Name;
                dr[ComponentInspectionReportGearboxFields.GearboxNoiseId.Name] = entity.ComponentInspectionReportGearbox[0].Noise.Name;
                dr[ComponentInspectionReportGearboxFields.GearboxDebrisOnMagnetId.Name] = entity.ComponentInspectionReportGearbox[0].DebrisOnMagnet.Name;
                dr[ComponentInspectionReportGearboxFields.GearboxDebrisStagesMagnetPosId.Name] = entity.ComponentInspectionReportGearbox[0].MagnetPos.Name;
                dr[ComponentInspectionReportGearboxFields.GearboxDebrisGearBoxId.Name] = entity.ComponentInspectionReportGearbox[0].DebrisGearbox.Name;
                if (entity.ComponentInspectionReportGearbox[0].GearboxMaxTempResetDate.HasValue)
                    dr[ComponentInspectionReportGearboxFields.GearboxMaxTempResetDate.Name] = entity.ComponentInspectionReportGearbox[0].GearboxMaxTempResetDate.Value;
                if (entity.ComponentInspectionReportGearbox[0].GearboxTempBearing1.HasValue)
                    dr[ComponentInspectionReportGearboxFields.GearboxTempBearing1.Name] = entity.ComponentInspectionReportGearbox[0].GearboxTempBearing1.Value;
                if (entity.ComponentInspectionReportGearbox[0].GearboxTempBearing2.HasValue)
                    dr[ComponentInspectionReportGearboxFields.GearboxTempBearing2.Name] = entity.ComponentInspectionReportGearbox[0].GearboxTempBearing2.Value;
                if (entity.ComponentInspectionReportGearbox[0].GearboxTempBearing3.HasValue)
                    dr[ComponentInspectionReportGearboxFields.GearboxTempBearing3.Name] = entity.ComponentInspectionReportGearbox[0].GearboxTempBearing3.Value;
                if (entity.ComponentInspectionReportGearbox[0].GearboxTempOilSump.HasValue)
                    dr[ComponentInspectionReportGearboxFields.GearboxTempOilSump.Name] = entity.ComponentInspectionReportGearbox[0].GearboxTempOilSump.Value;
                dr[ComponentInspectionReportGearboxFields.GearboxLssnrend.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxLssnrend ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxImsnrend.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxImsnrend ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxImsrend.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxImsrend ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxHssnrend.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxHssnrend ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxHssrend.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxHssrend ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxPitchTube.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxPitchTube ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxSplitLines.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxSplitLines ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxHoseAndPiping.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxHoseAndPiping ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxInputShaft.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxInputShaft ? "Yes" : "No");
                dr[ComponentInspectionReportGearboxFields.GearboxHsspto.Name] = (entity.ComponentInspectionReportGearbox[0].GearboxHsspto ? "Yes" : "No");
            }



        }

        private static void FillBladeColumns(ComponentInspectionReportEntity entity, DataRow dr)
        {

            if (entity.ComponentInspectionReportBlade.Count == 1)
            {
                //If entity.ComponentInspectionReportBlade(0).BooleanAnswer_ IsNot Nothing Then
                //	dr(ComponentInspectionReportBladeFields.BladeClaimRelevantBooleanAnswerId.Name) = entity.ComponentInspectionReportBlade(0).BooleanAnswer_.Name
                //End If

                dr[ComponentInspectionReportBladeFields.BladeLengthId.Name] = entity.ComponentInspectionReportBlade[0].BladeLength.Name;
                dr[ComponentInspectionReportBladeFields.BladeColorId.Name] = entity.ComponentInspectionReportBlade[0].BladeColor.Name;
                dr[ComponentInspectionReportBladeFields.BladeSerialNumber.Name] = entity.ComponentInspectionReportBlade[0].BladeSerialNumber;
                dr[ComponentInspectionReportBladeFields.BladePicturesIncludedBooleanAnswerId.Name] = entity.ComponentInspectionReportBlade[0].BooleanAnswer.Name;
                if (!string.IsNullOrEmpty(entity.ComponentInspectionReportBlade[0].BladeOtherSerialNumber1))
                    dr[ComponentInspectionReportBladeFields.BladeOtherSerialNumber1.Name] = entity.ComponentInspectionReportBlade[0].BladeOtherSerialNumber1;
                if (!string.IsNullOrEmpty(entity.ComponentInspectionReportBlade[0].BladeOtherSerialNumber2))
                    dr[ComponentInspectionReportBladeFields.BladeOtherSerialNumber1.Name] = String.Concat(dr[ComponentInspectionReportBladeFields.BladeOtherSerialNumber1.Name], " ", entity.ComponentInspectionReportBlade[0].BladeOtherSerialNumber2);
                dr[ComponentInspectionReportBladeFields.BladeDamageIdentified.Name] = (entity.ComponentInspectionReportBlade[0].BladeDamageIdentified ? "Yes" : "No");
                foreach (ComponentInspectionReportBladeDamageEntity bdent in entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeDamage)
                {
                    dr[ComponentInspectionReportBladeDamageFields.BladeDamagePlacementId.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeDamage[0].BladeDamagePlacement.Name;
                    dr[ComponentInspectionReportBladeDamageFields.BladeInspectionDataId.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeDamage[0].BladeInspectionData.Name;
                    dr[ComponentInspectionReportBladeDamageFields.BladeRadius.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeDamage[0].BladeRadius;
                    dr[ComponentInspectionReportBladeDamageFields.BladeEdgeId.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeDamage[0].BladeEdge.Name;
                    dr[ComponentInspectionReportBladeDamageFields.BladeDescription.Name] = HttpUtility.HtmlEncode(entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeDamage[0].BladeDescription);
                }
                if (entity.ComponentInspectionReportBlade[0].FaultCodeClassification != null)
                    dr[ComponentInspectionReportBladeFields.BladeFaultCodeClassificationId.Name] = entity.ComponentInspectionReportBlade[0].FaultCodeClassification.Name;
                if (entity.ComponentInspectionReportBlade[0].FaultCodeCause != null)
                    dr[ComponentInspectionReportBladeFields.BladeFaultCodeCauseId.Name] = entity.ComponentInspectionReportBlade[0].FaultCodeCause.Name;
                if (entity.ComponentInspectionReportBlade[0].FaultCodeType != null)
                    dr[ComponentInspectionReportBladeFields.BladeFaultCodeTypeId.Name] = entity.ComponentInspectionReportBlade[0].FaultCodeType.Name;
                if (entity.ComponentInspectionReportBlade[0].FaultCodeArea != null)
                    dr[ComponentInspectionReportBladeFields.BladeFaultCodeAreaId.Name] = entity.ComponentInspectionReportBlade[0].FaultCodeArea.Name;

                if (entity.ComponentInspectionReportBlade[0].BladeLsVtNumber != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsVtNumber.Name] = entity.ComponentInspectionReportBlade[0].BladeLsVtNumber;
                if (entity.ComponentInspectionReportBlade[0].BladeLsCalibrationDate != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsCalibrationDate.Name] = entity.ComponentInspectionReportBlade[0].BladeLsCalibrationDate;
                if (entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePreRepairTip != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepairTip.Name] = entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePreRepairTip;
                if (entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePostRepairTip != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepairTip.Name] = entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePostRepairTip;
                if (entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePreRepair2 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair2.Name] = entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePreRepair2;
                if (entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePostRepair2 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair2.Name] = entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePostRepair2;
                if (entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePreRepair3 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair3.Name] = entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePreRepair3;
                if (entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePostRepair3 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair3.Name] = entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePostRepair3;
                if (entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePreRepair4 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair4.Name] = entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePreRepair4;
                if (entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePostRepair4 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair4.Name] = entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePostRepair4;
                if (entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePreRepair5 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair5.Name] = entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePreRepair5;
                if (entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePostRepair5 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair5.Name] = entity.ComponentInspectionReportBlade[0].BladeLsLeewardSidePostRepair5;
                if (entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePreRepairTip != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepairTip.Name] = entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePreRepairTip;
                if (entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePostRepairTip != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepairTip.Name] = entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePostRepairTip;
                if (entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePreRepair2 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair2.Name] = entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePreRepair2;
                if (entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePostRepair2 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair2.Name] = entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePostRepair2;
                if (entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePreRepair3 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair3.Name] = entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePreRepair3;
                if (entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePostRepair3 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair3.Name] = entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePostRepair3;
                if (entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePreRepair4 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair4.Name] = entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePreRepair4;
                if (entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePostRepair4 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair4.Name] = entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePostRepair4;
                if (entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePreRepair5 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair5.Name] = entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePreRepair5;
                if (entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePostRepair5 != null)
                    dr[ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair5.Name] = entity.ComponentInspectionReportBlade[0].BladeLsWindwardSidePostRepair5;


                if (entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord.Count == 1)
                {
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeAmbientTemp.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeAmbientTemp;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeHumidity.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeHumidity;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeAdditionalDocumentReference.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeAdditionalDocumentReference;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeResinType.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeResinType;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeBatchNumbers.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeResinTypeBatchNumbers;
                    if (entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeResinTypeExpiryDate != null)
                        dr[ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeExpiryDate.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeResinTypeExpiryDate;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeHardenerType.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeHardenerType;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeBatchNumbers.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeHardenerTypeBatchNumbers;
                    if (entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeHardenerTypeExpiryDate != null)
                        dr[ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeHardenerTypeExpiryDate;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeGlassSupplier.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeGlassSupplier;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeGlassSupplierBatchNumbers.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeGlassSupplierBatchNumbers;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeSurfaceMinTemperature.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeSurfaceMinTemperature;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeSurfaceMaxTemperature.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeSurfaceMaxTemperature;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeResinUsed.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeResinUsed;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladePostCureMinTemperature.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladePostCureMinTemperature;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladePostCureMaxTemperature.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladePostCureMaxTemperature;
                    if (entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeTurnOffTime != null)
                        dr[ComponentInspectionReportBladeRepairRecordFields.BladeTurnOffTime.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeTurnOffTime;
                    dr[ComponentInspectionReportBladeRepairRecordFields.BladeTotalCureTime.Name] = entity.ComponentInspectionReportBlade[0].ComponentInspectionReportBladeRepairRecord[0].BladeTotalCureTime;
                }
            }



        }

        private static void FillWindTurbineColumns(ComponentInspectionReportEntity entity, DataRow dr)
        {

            dr[ComponentInspectionReportFields.ComponentInspectionReportId.Name] = "<a href='/CirView/manage-cirviewlist?cirid=" + entity.ComponentInspectionReportId + "' style='color:#0000ff;cursor:pointer'><u>" + entity.ComponentInspectionReportId.ToString() + "</u></a>";
            dr[ComponentInspectionReportFields.ComponentInspectionReportTypeId.Name] = entity.ComponentInspectionReportType.Name;
            dr[ComponentInspectionReportFields.ReportTypeId.Name] = entity.ReportType.Name;
            dr[ComponentInspectionReportFields.ReconstructionBooleanAnswerId.Name] = entity.BooleanAnswer.Name;
            dr[ComponentInspectionReportFields.CimcaseNumber.Name] = "<a href='http://pman.vestas.net/caseviewer.aspx?brandid=1&caseno=" + entity.CimcaseNumber + "' style='color:#0000ff;cursor:pointer' target='_blank'><u>" + entity.CimcaseNumber + "</u></a>";
            dr[ComponentInspectionReportFields.ReasonForService.Name] = HttpUtility.HtmlEncode(entity.ReasonForService);
            dr[ComponentInspectionReportFields.TurbineNumber.Name] = entity.TurbineNumber;
            dr[ComponentInspectionReportFields.CountryIsoid.Name] = entity.CountryIso.Name;
            dr[ComponentInspectionReportFields.SiteName.Name] = HttpUtility.HtmlEncode(entity.SiteName);
            //dr(ComponentInspectionReportFields.TurbineMatrixId.Name) = entity.TurbineMatrix.Turbine.Turbine
            if (entity.TurbineMatrix != null && entity.TurbineMatrix.Turbine != null)
                dr[TurbineFields.TurbineId.Name] = entity.TurbineMatrix.Turbine.Turbine;
            // KENJA 30-11-10: removing searchable turbine parameters
            //If entity.TurbineMatrix.TurbineRotorDiameter IsNot Nothing Then dr(TurbineRotorDiameterFields.TurbineRotorDiameterId.Name) = entity.TurbineMatrix.TurbineRotorDiameter.RotorDiameter
            //If entity.TurbineMatrix.TurbineNominelPower IsNot Nothing Then dr(TurbineNominelPowerFields.TurbineNominelPowerId.Name) = entity.TurbineMatrix.TurbineNominelPower.NominelPower
            //If entity.TurbineMatrix.TurbineVoltage IsNot Nothing Then dr(TurbineVoltageFields.TurbineVoltageId.Name) = entity.TurbineMatrix.TurbineVoltage.Voltage
            //If entity.TurbineMatrix.TurbinePowerRegulation IsNot Nothing Then dr(TurbinePowerRegulationFields.TurbinePowerRegulationId.Name) = entity.TurbineMatrix.TurbinePowerRegulation.PowerRegulation
            //If entity.TurbineMatrix.TurbineFrequency IsNot Nothing Then dr(TurbineFrequencyFields.TurbineFrequencyId.Name) = entity.TurbineMatrix.TurbineFrequency.Frequency
            //If entity.TurbineMatrix.TurbineSmallGenerator IsNot Nothing Then dr(TurbineSmallGeneratorFields.TurbineSmallGeneratorId.Name) = entity.TurbineMatrix.TurbineSmallGenerator.SmallGenerator
            //If entity.TurbineMatrix.TurbineTemperatureVariant IsNot Nothing Then dr(TurbineTemperatureVariantFields.TurbineTemperatureVariantId.Name) = entity.TurbineMatrix.TurbineTemperatureVariant.TemperatureVariant
            //If entity.TurbineMatrix.TurbineMarkVersion IsNot Nothing Then dr(TurbineMarkVersionFields.TurbineMarkVersionId.Name) = entity.TurbineMatrix.TurbineMarkVersion.MarkVersion
            //If entity.TurbineMatrix.TurbinePlacement IsNot Nothing Then dr(TurbinePlacementFields.TurbinePlacementId.Name) = entity.TurbineMatrix.TurbinePlacement.Placement
            //If entity.TurbineMatrix.TurbineManufacturer IsNot Nothing Then dr(TurbineManufacturerFields.TurbineManufacturerId.Name) = entity.TurbineMatrix.TurbineManufacturer.Manufacturer

            //dr[TurbineRotorDiameterFields.TurbineRotorDiameterId.Name] = entity.TurbineMatrix.TurbineRotorDiameter.RotorDiameter
            //dr[ComponentInspectionReportFields.LocationTypeId.Name] = entity.LocationType.Name
            dr[ComponentInspectionReportFields.LocalTurbineId.Name] = HttpUtility.HtmlEncode(entity.LocalTurbineId);
            if (entity.BooleanAnswer_ != null)
                dr[ComponentInspectionReportFields.SecondGeneratorBooleanAnswerId.Name] = entity.BooleanAnswer_.Name;
            dr[ComponentInspectionReportFields.BeforeInspectionTurbineRunStatusId.Name] = entity.TurbineRunStatus.Name;
            dr[ComponentInspectionReportFields.CommisioningDate.Name] = entity.CommisioningDate;
            if (entity.InstallationDate.HasValue)
                dr[ComponentInspectionReportFields.InstallationDate.Name] = entity.InstallationDate;
            dr[ComponentInspectionReportFields.InspectionDate.Name] = entity.InspectionDate;
            if (entity.FailureDate.HasValue)
                dr[ComponentInspectionReportFields.FailureDate.Name] = entity.FailureDate;
            dr[ComponentInspectionReportFields.ServiceReportNumber.Name] = HttpUtility.HtmlEncode(entity.ServiceReportNumber);
            dr[ComponentInspectionReportFields.ServiceReportNumberTypeId.Name] = entity.ServiceReportNumberType.Name;
            dr[ComponentInspectionReportFields.NotificationNumber.Name] = HttpUtility.HtmlEncode(entity.NotificationNumber);
            dr[ComponentInspectionReportFields.ServiceEngineer.Name] = HttpUtility.HtmlEncode(entity.ServiceEngineer);
            dr[ComponentInspectionReportFields.RunHours.Name] = entity.RunHours;
            dr[ComponentInspectionReportFields.Generator1Hrs.Name] = entity.Generator1Hrs;
            if (entity.Generator2Hrs.HasValue)
                dr[ComponentInspectionReportFields.Generator2Hrs.Name] = entity.Generator2Hrs;
            dr[ComponentInspectionReportFields.TotalProduction.Name] = entity.TotalProduction;
            dr[ComponentInspectionReportFields.AfterInspectionTurbineRunStatusId.Name] = entity.TurbineRunStatus_.Name;
            dr[ComponentInspectionReportFields.VestasItemNumber.Name] = entity.VestasItemNumber;
            dr[ComponentInspectionReportFields.Quantity.Name] = entity.Quantity;
            dr[ComponentInspectionReportFields.AlarmLogNumber.Name] = HttpUtility.HtmlEncode(entity.AlarmLogNumber);
            dr[ComponentInspectionReportFields.Description.Name] = HttpUtility.HtmlEncode(entity.Description);
            dr[ComponentInspectionReportFields.DescriptionConsquential.Name] = HttpUtility.HtmlEncode(entity.DescriptionConsquential);
            dr[ComponentInspectionReportFields.ConductedBy.Name] = HttpUtility.HtmlEncode(entity.ConductedBy);

            if (entity.MountedOnMainComponentBooleanAnswerId != null)
            {
                dr[ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId.Name] = entity.BooleanAnswer__.Name;
            }

            //new added column for AdditionalInfo
            dr[ComponentInspectionReportFields.AdditionalInfo.Name] = HttpUtility.HtmlEncode(entity.AdditionalInformation);
            dr[ComponentInspectionReportFields.SBURecommendation.Name] = HttpUtility.HtmlEncode(entity.SBURecommendation);
            dr[ComponentInspectionReportFields.Brand.Name] = HttpUtility.HtmlEncode(entity.Brand);
            dr[ComponentInspectionReportFields.InternalComments.Name] = HttpUtility.HtmlEncode(entity.InternalComments);
            if (entity.ComponentUpTowerSolutionId != null)
            {
                dr[ComponentInspectionReportFields.ComponentUpTowerSolutionId.Name] = entity.ComponentUpTowerSolutionId;
            }
        }

        private static void DefineTransformerColumns(DataTable dt)
        {
            dt.Columns.Add(ComponentInspectionReportTransformerFields.TransformerManufacturerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.TransformerSerialNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.TransformerArcDetectionId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.MaxTemp.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.MaxTempResetDate.Name, typeof(System.DateTime));

            dt.Columns.Add(ComponentInspectionReportTransformerFields.ActionOnTransformerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.HvcoilConditionId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.LvcoilConditionId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.HvcableConditionId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.LvcableConditionId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.BracketsId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.ClimateId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.SurgeArrestorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportTransformerFields.ConnectionBarsId.Name, typeof(string));

            dt.Columns.Add(ComponentInspectionReportTransformerFields.Comments.Name, typeof(string));

        }

        private static void DefineSkiiPColumns(DataTable dt)
        {

            dt.Columns.Add(ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentSerialNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentVestasUniqueIdentifier.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentVestasItemNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentSerialNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentVestasUniqueIdentifier.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentVestasItemNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiPotherDamagedComponentsReplaced.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiPcauseId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiPquantityOfFailedModules.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv522BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv523BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv524BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv525BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv526BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv521BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv522BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv523BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv524xBooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv524yBooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv525xBooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv525yBooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv526xBooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv526yBooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv520BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv524BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv525BooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv526BooleanAnswerId.Name, typeof(string));
        }

        private static void DefineMainBearingColumns(DataTable dt)
        {

            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingLastLubricationDate.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingManufacturerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingTemperature.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingLubricationOilTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingLubricationRunHours.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingOilTemperature.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingRevision.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingErrorLocationId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingSerialNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingRunHours.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportMainBearingFields.MainBearingMechanicalOilPump.Name, typeof(string));
        }

        private static void DefineGeneralColumns(DataTable dt)
        {
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralComponentGroupId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralComponentType.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralComponentManufacturer.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralOtherGearboxType.Name, typeof(string));

            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralOtherGearboxManufacturer.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralComponentSerialNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralGeneratorManufacturerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralTransformerManufacturerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralGearboxManufacturerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralTowerTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralTowerHeightId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralBlade1SerialNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralControllerTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralSoftwareRelease.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralRamDumpNumber.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralVdftrackNumber.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralPicturesIncludedBooleanAnswerId.Name, typeof(string));

            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralInitiatedBy1.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralMeasurementsConducted1.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralExecutedBy1.Name, typeof(string));

            dt.Columns.Add(ComponentInspectionReportGeneralFields.GeneralPositionOfFailedItem.Name, typeof(string));

        }

        private static void DefineGeneratorColumns(DataTable dt)
        {

            dt.Columns.Add(ComponentInspectionReportGeneratorFields.GeneratorManufacturerId.Name, typeof(string));
            //Added new field for Generator other OtherManufacturer 
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.OtherManufacturer.Name, typeof(string));

            dt.Columns.Add(ComponentInspectionReportGeneratorFields.GeneratorSerialNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.GeneratorComments.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.GeneratorRewoundLocally.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.GeneratorMaxTemperature.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.GeneratorMaxTemperatureResetDate.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.ActionToBeTakenOnGeneratorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.GeneratorDriveEndId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.GeneratorNonDriveEndId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.GeneratorRotorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.GeneratorCoverId.Name, typeof(string));

            dt.Columns.Add(ComponentInspectionReportGeneratorFields.U1U2.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.V1V2.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.W1W2.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.K1L1.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.L1M1.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.K1M1.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.K2L2.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.L2M2.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.K2M2.Name, typeof(long));

            dt.Columns.Add(ComponentInspectionReportGeneratorFields.Uground.Name, typeof(decimal));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.Vground.Name, typeof(decimal));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.Wground.Name, typeof(decimal));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.Uv.Name, typeof(decimal));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.Uw.Name, typeof(decimal));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.Vw.Name, typeof(decimal));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.Kground.Name, typeof(decimal));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.Lground.Name, typeof(decimal));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.Mground.Name, typeof(decimal));

            dt.Columns.Add(ComponentInspectionReportGeneratorFields.UgroundOhmUnitId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.VgroundOhmUnitId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.WgroundOhmUnitId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.UvohmUnitId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.UwohmUnitId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.VwohmUnitId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.KgroundOhmUnitId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.LgroundOhmUnitId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGeneratorFields.MgroundOhmUnitId.Name, typeof(string));
        }

        private static void DefineGearColumns(DataTable dt)
        {
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.OtherGearboxType.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxRevisionId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxManufacturerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxOtherManufacturer.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxSerialNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxLastOilChangeDate.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxOilTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxMechanicalOilPumpId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxOilLevelId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxRunHours.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxOilTemperature.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxProduction.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId2.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxElectricalPumpId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxShrinkElementId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxShrinkElementSerialNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxCouplingId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxFilterBlockTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxInLineFilterId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxOffLineFilterId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxSoftwareRelease.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation1ShaftTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage1ShaftErrorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxExactLocation1GearTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxTypeofDamage1GearErrorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxBearingsLocation1BearingTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition1BearingPosId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxBearingsDamage1BearingErrorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxPlanetStage1HousingErrorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxPlanetStage2HousingErrorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxHelicalStageHousingErrorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxFrontPlateHousingErrorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxAuxStageHousingErrorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxHsstageHousingErrorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxLooseBolts.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxBrokenBolts.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxDefectDamperElements.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxTooMuchClearance.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxCrackedTorqueArm.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxNeedsToBeAligned.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing1.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing2.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing3.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxOilLevelSensor.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxOilPressure.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxPt100OilSump.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxFilterIndicator.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxImmersionHeater.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxDrainValve.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxAirBreather.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxSightGlass.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxChipDetector.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxVibrationsId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxNoiseId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxDebrisOnMagnetId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxDebrisStagesMagnetPosId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxDebrisGearBoxId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxMaxTempResetDate.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxTempBearing1.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxTempBearing2.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxTempBearing3.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxTempOilSump.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxLssnrend.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxImsnrend.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxImsrend.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxHssnrend.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxHssrend.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxPitchTube.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxSplitLines.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxHoseAndPiping.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxInputShaft.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportGearboxFields.GearboxHsspto.Name, typeof(string));

        }

        private static void DefineBladeColumns(DataTable dt)
        {
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLengthId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeColorId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeSerialNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladePicturesIncludedBooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeOtherSerialNumber1.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeDamageIdentified.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeDamageFields.BladeDamagePlacementId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeDamageFields.BladeInspectionDataId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeDamageFields.BladeRadius.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeDamageFields.BladeEdgeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeDamageFields.BladeDescription.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeFaultCodeClassificationId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeFaultCodeCauseId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeFaultCodeTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeFaultCodeAreaId.Name, typeof(string));

            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsVtNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsCalibrationDate.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepairTip.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepairTip.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair2.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair2.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair3.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair3.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair4.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair4.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair5.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair5.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepairTip.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepairTip.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair2.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair2.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair3.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair3.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair4.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair4.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair5.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair5.Name, typeof(long));

            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeAmbientTemp.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHumidity.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeAdditionalDocumentReference.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinType.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeBatchNumbers.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeExpiryDate.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerType.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeBatchNumbers.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeGlassSupplier.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeGlassSupplierBatchNumbers.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeSurfaceMinTemperature.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeSurfaceMaxTemperature.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinUsed.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladePostCureMinTemperature.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladePostCureMaxTemperature.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeTurnOffTime.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportBladeRepairRecordFields.BladeTotalCureTime.Name, typeof(long));

        }

        private static void DefineWindTurbineColumns(DataTable dt)
        {
            dt.Columns.Add(ComponentInspectionReportFields.ComponentInspectionReportId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.ComponentInspectionReportTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.ReportTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.ReconstructionBooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.CimcaseNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.ReasonForService.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.TurbineNumber.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportFields.CountryIsoid.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.SiteName.Name, typeof(string));
            //dt.Columns.Add(ComponentInspectionReportFields.TurbineMatrixId.Name, typeof(string));
            dt.Columns.Add(TurbineFields.TurbineId.Name, typeof(string));
            // KENJA 30-11-10: removing searchable turbine parameters
            //dt.Columns.Add(TurbineRotorDiameterFields.TurbineRotorDiameterId.Name, typeof(string));
            //dt.Columns.Add(TurbineNominelPowerFields.TurbineNominelPowerId.Name, typeof(string));
            //dt.Columns.Add(TurbineVoltageFields.TurbineVoltageId.Name, typeof(string));
            //dt.Columns.Add(TurbinePowerRegulationFields.TurbinePowerRegulationId.Name, typeof(string));
            //dt.Columns.Add(TurbineFrequencyFields.TurbineFrequencyId.Name, typeof(string));
            //dt.Columns.Add(TurbineSmallGeneratorFields.TurbineSmallGeneratorId.Name, typeof(string));
            //dt.Columns.Add(TurbineTemperatureVariantFields.TurbineTemperatureVariantId.Name, typeof(string));
            //dt.Columns.Add(TurbineMarkVersionFields.TurbineMarkVersionId.Name, typeof(string));
            //dt.Columns.Add(TurbinePlacementFields.TurbinePlacementId.Name, typeof(string));
            //dt.Columns.Add(TurbineManufacturerFields.TurbineManufacturerId.Name, typeof(string));
            //dt.Columns.Add(ComponentInspectionReportFields.LocationTypeId.Name, typeof(string));           

            dt.Columns.Add(ComponentInspectionReportFields.LocalTurbineId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.SecondGeneratorBooleanAnswerId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.BeforeInspectionTurbineRunStatusId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.CommisioningDate.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportFields.InstallationDate.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportFields.InspectionDate.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportFields.FailureDate.Name, typeof(System.DateTime));
            dt.Columns.Add(ComponentInspectionReportFields.ServiceReportNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.ServiceReportNumberTypeId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.NotificationNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.ServiceEngineer.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.RunHours.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportFields.Generator1Hrs.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportFields.Generator2Hrs.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportFields.TotalProduction.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportFields.AfterInspectionTurbineRunStatusId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.VestasItemNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.Quantity.Name, typeof(long));
            dt.Columns.Add(ComponentInspectionReportFields.AlarmLogNumber.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.Description.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.DescriptionConsquential.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.ConductedBy.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId.Name, typeof(string));
            //New Added Fields
            dt.Columns.Add(ComponentInspectionReportFields.ComponentUpTowerSolutionId.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.SBURecommendation.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.Brand.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.InternalComments.Name, typeof(string));
            dt.Columns.Add(ComponentInspectionReportFields.AdditionalInfo.Name, typeof(string));







        }

        public static AdvanceSearchModel GetBirAdvanceSearchData()
        {

            //List<BIRViewModel> objBIRViewCollection = new List<BIRViewModel>();
            var conn = new SqlConnection(GetConnectionString());
            conn.Open();
            var cmd = new SqlCommand { Connection = conn };
            SqlDataReader reader = null;

            #region Where clause
            string whereClauseOrder = "";
            whereClauseOrder += "bd.Deleted = 0 ";
            if (!ReferenceEquals(_AdvanceSearchData.InputFields, null))
                foreach (InputFields birfilters in _AdvanceSearchData.InputFields)
                    if (!string.IsNullOrEmpty(birfilters.Value))
                    {
                        //if (!string.IsNullOrEmpty(whereClauseOrder))
                        //{
                        //    whereClauseOrder += " AND ";
                        //}
                        birfilters.Value = birfilters.Value.Replace("*", "%");
                        if (birfilters.InputId == "BIR_lbTurbine")
                        {
                            whereClauseOrder += " AND CMI.TurbineNumber like '" + '%' + birfilters.Value + '%' + "'";
                        }
                        else if (birfilters.InputId == "Created")
                        {
                            whereClauseOrder += " AND  CAST(bd.Created AS DATE) = CONVERT(DATE, '" + birfilters.Value + "', 103) ";
                        }
                        else if (birfilters.InputId == "BIR_lbSBU")
                        {
                            whereClauseOrder += " AND sbu.[Name] like '" + '%' + birfilters.Value + '%' + "'";
                        }
                        else if (birfilters.InputId == "BIR_lbSite")
                        {
                            whereClauseOrder += " AND td.[Site]  like '" + '%' + birfilters.Value + '%' + "'";
                        }

                        else if (birfilters.InputId == "BIR_lbBIRID")
                        {
                            whereClauseOrder += " AND BD.[BirDataID] like '" + '%' + birfilters.Value + '%' + "'";
                        }
                        else if (birfilters.InputId == "BIR_lbRevNo")
                        {
                            whereClauseOrder += " AND BD.[RevisionNumber] = '" + birfilters.Value + "'";
                        }
                        else if (birfilters.InputId == "BIR_lbBirName")
                        {
                            whereClauseOrder += " AND BD.[BirCode] like '" + '%' + birfilters.Value + '%' + "'";
                        }

                    }
            #endregion Where clause

            try
            {
                cmd.CommandText = string.Format(@"
SELECT TOP 100 [BirDataID],[BirCode], [RevisionNumber],CirDataId, CirId,Created,Createdby,SiteAddress,TurbineNumber,TurbineType,Country,SBU,BladeSerialNos
FROM (
	SELECT BD.[BirDataID],BD.[BirCode], BD.[RevisionNumber],
cd.CirDataId, cd.CirId,  bd.Created, bd.Createdby, isnull(td.[Site],'')SiteAddress,CMI.TurbineNumber, td.TurbineType,td.Country,sbu.[Name] as SBU, isnull(bd.BladeSerialNos,BD.[BirCode])BladeSerialNos,ROW_NUMBER() OVER(
		ORDER BY  BD.[Created] desc
	) AS RowNumber
	FROM
	[dbo].[BirData] BD  WITH(NOLOCK)
inner  join [dbo].[MapBirCir] MPC  WITH(NOLOCK)
on MPC.BirDataID = BD.BirDataID and MPC.Master = 1
inner join 
dbo.CIRData cd  WITH(NOLOCK) on cd.[CirDataId] = MPC.CirDataID
left join ComponentInspectionReport CMI on CMI.ComponentInspectionReportId = cd.[CirId] 
left  JOIN [dbo].[SBU] sbu WITH(NOLOCK) ON CMI.SBUId = sbu.[SBUId]
left join TurbineData td on  td.TurbineId = CONVERT(VARCHAR(50),CMI.TurbineNumber)
	WHERE {0} 
		) CirDataPage
ORDER BY 1
", whereClauseOrder);

                //  WHERE RowNumber >= {1}
                //AND RowNumber <= {2}
                //{3}
                reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);


                string columns = "";

                //ArrayList rc = ResultListColumns();
                Dictionary<string, string> ResultColumnMapList = new Dictionary<string, string>();
                ResultColumnMapList.Add("BirDataID", "BIR ID");
                ResultColumnMapList.Add("BirCode", "BIR Code");
                ResultColumnMapList.Add("RevisionNumber", "RevisionNumber");

                ResultColumnMapList.Add("CirDataId", "CirData ID");
                ResultColumnMapList.Add("CirId", "CIR ID");
                ResultColumnMapList.Add("Created", "Created");

                ResultColumnMapList.Add("Createdby", "Created By");
                ResultColumnMapList.Add("SiteAddress", "Site Address");
                ResultColumnMapList.Add("TurbineNumber", "Turbine Number");

                ResultColumnMapList.Add("TurbineType", "Turbine Type");
                ResultColumnMapList.Add("Country", "Country");
                ResultColumnMapList.Add("SBU", "SBU");
                ResultColumnMapList.Add("BladeSerialNos", "Blade Serial Nos");

                columns = String.Join(",", ResultColumnMapList.Select(x => "{\"data\": \"" + x.Key + "\" , \"title\": \"" + x.Value + "\"}"));


                string rows = JsonConvert.SerializeObject(dt);
                string data = "{\"columns\" : [" + columns + "] , \"rows\" : " + rows + " }";

                if (dt.Rows.Count > 0)
                {
                    _AdvanceSearchData.Result = data;
                    _AdvanceSearchData.ResponseString = "Your search returned " + dt.Rows.Count.ToString() + " results. <br /><br />";

                }
                else
                {
                    _AdvanceSearchData.ResponseString = "No BIR's matched search criteria.";
                    _AdvanceSearchData.Result = "";

                }


            }
            catch { }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                conn.Close();
            }

            return _AdvanceSearchData;
        }


        private static void ResultColumnMap()
        {
            //WindTurbine
            ResultColumnMapList = new Dictionary<string, string>();
            ResultColumnMapList.Add(ComponentInspectionReportFields.ComponentInspectionReportId.Name, "CIR ID");
            ResultColumnMapList.Add(ComponentInspectionReportFields.ComponentInspectionReportTypeId.Name, "Component Type");
            ResultColumnMapList.Add(ComponentInspectionReportFields.ReportTypeId.Name, "Report Type");
            ResultColumnMapList.Add(ComponentInspectionReportFields.ReconstructionBooleanAnswerId.Name, "Reconstruction");
            ResultColumnMapList.Add(ComponentInspectionReportFields.CimcaseNumber.Name, "CIM Case Number");
            ResultColumnMapList.Add(ComponentInspectionReportFields.ReasonForService.Name, "Reason For Service");
            ResultColumnMapList.Add(ComponentInspectionReportFields.TurbineNumber.Name, "Turbine Number");
            ResultColumnMapList.Add(ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId.Name, "Aux. Equipment");
            ResultColumnMapList.Add(ComponentInspectionReportFields.CountryIsoid.Name, "Country");
            ResultColumnMapList.Add(ComponentInspectionReportFields.SiteName.Name, "Site Name");
            ResultColumnMapList.Add(TurbineFields.TurbineId.Name, "Turbine Type");
            ResultColumnMapList.Add(ComponentInspectionReportFields.LocalTurbineId.Name, "Local Turbine Id");
            ResultColumnMapList.Add(ComponentInspectionReportFields.SecondGeneratorBooleanAnswerId.Name, "Second Generator");
            ResultColumnMapList.Add(ComponentInspectionReportFields.BeforeInspectionTurbineRunStatusId.Name, "Run Status Before Inspection");
            ResultColumnMapList.Add(ComponentInspectionReportFields.CommisioningDate.Name, "Commissioning Date");
            ResultColumnMapList.Add(ComponentInspectionReportFields.InstallationDate.Name, "Installation Date");
            ResultColumnMapList.Add(ComponentInspectionReportFields.InspectionDate.Name, "Inspection Date");
            ResultColumnMapList.Add(ComponentInspectionReportFields.FailureDate.Name, "Failure Date");
            ResultColumnMapList.Add(ComponentInspectionReportFields.ServiceReportNumber.Name, "Service Report Number");
            ResultColumnMapList.Add(ComponentInspectionReportFields.ServiceReportNumberTypeId.Name, "Service Report Number Type");
            ResultColumnMapList.Add(ComponentInspectionReportFields.NotificationNumber.Name, "Notification Number");
            ResultColumnMapList.Add(ComponentInspectionReportFields.ServiceEngineer.Name, "Service Engineer");
            ResultColumnMapList.Add(ComponentInspectionReportFields.RunHours.Name, "Run Hours");
            ResultColumnMapList.Add(ComponentInspectionReportFields.Generator1Hrs.Name, "Generator 1 Hours");
            ResultColumnMapList.Add(ComponentInspectionReportFields.Generator2Hrs.Name, "Generator 2 Hours");
            ResultColumnMapList.Add(ComponentInspectionReportFields.TotalProduction.Name, "Total Production (kWh)");
            ResultColumnMapList.Add(ComponentInspectionReportFields.AfterInspectionTurbineRunStatusId.Name, "Run Status After Inspection");
            ResultColumnMapList.Add(ComponentInspectionReportFields.VestasItemNumber.Name, "Vestas Item No.");
            ResultColumnMapList.Add(ComponentInspectionReportFields.Quantity.Name, "Quan. Failed Comp.");
            ResultColumnMapList.Add(ComponentInspectionReportFields.AlarmLogNumber.Name, "Alarm Log Number");
            ResultColumnMapList.Add(ComponentInspectionReportFields.Description.Name, "Description");
            ResultColumnMapList.Add(ComponentInspectionReportFields.DescriptionConsquential.Name, "Desc. Of Conseq. Prob./Dam.");
            ResultColumnMapList.Add(ComponentInspectionReportFields.ConductedBy.Name, "Conducted By");

            //new added fields in  Manually Code 
            ResultColumnMapList.Add(ComponentInspectionReportFields.AdditionalInfo.Name, "Additional Information");
            ResultColumnMapList.Add(ComponentInspectionReportFields.InternalComments.Name, "Internal Comments");
            ResultColumnMapList.Add(ComponentInspectionReportFields.SBURecommendation.Name, "Tech. Support recommendation");
            ResultColumnMapList.Add(ComponentInspectionReportFields.Brand.Name, "Brand");
            ResultColumnMapList.Add(ComponentInspectionReportFields.ComponentUpTowerSolutionId.Name, "Up-Tower Solution Available");


            //General
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralComponentGroupId.Name, "General Comp. Group");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralComponentType.Name, "General Comp. Type");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralComponentManufacturer.Name, "General Comp. Manufact.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralOtherGearboxType.Name, "General Other Gearbox Type");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralOtherGearboxManufacturer.Name, "General Other Gearbox Manufact.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralComponentSerialNumber.Name, "General Comp. Ser. No.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralGeneratorManufacturerId.Name, "General Generator Manufact.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralTransformerManufacturerId.Name, "General Transf. Manufact.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralGearboxManufacturerId.Name, "General Gearbox Manufact.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralTowerTypeId.Name, "General Tower Type");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralTowerHeightId.Name, "General Tower Height");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralBlade1SerialNumber.Name, "General Blade Ser. No.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralControllerTypeId.Name, "General Ctrl. Type");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralSoftwareRelease.Name, "General Soft. Rel.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralRamDumpNumber.Name, "General Ram Dump No.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralVdftrackNumber.Name, "General VDF Track No.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralPicturesIncludedBooleanAnswerId.Name, "General Pics. Att.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralInitiatedBy1.Name, "General Initiated By");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralMeasurementsConducted1.Name, "General Measurements Conducted");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralExecutedBy1.Name, "General Executed By");
            ResultColumnMapList.Add(ComponentInspectionReportGeneralFields.GeneralPositionOfFailedItem.Name, "General Position Of Failed Item");

            //Generator
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.GeneratorManufacturerId.Name, "Generator Manufacturer");

            //Added new field for Generator other manufuture 
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.OtherManufacturer.Name, "Generator Other Manufacturer");

            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.GeneratorSerialNumber.Name, "Generator Ser. No.");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.GeneratorComments.Name, "Generator Comment");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.GeneratorRewoundLocally.Name, "Generator Rew. Locally");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.GeneratorMaxTemperature.Name, "Generator Max Temperature");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.GeneratorMaxTemperatureResetDate.Name, "Generator Max Temperature Reset Date");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.ActionToBeTakenOnGeneratorId.Name, "Generator Action To Be Taken");

            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.GeneratorDriveEndId.Name, "Generator Drive End");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.GeneratorNonDriveEndId.Name, "Generator Non Drive End");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.GeneratorRotorId.Name, "Generator Rotor");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.GeneratorCoverId.Name, "Generator Cover");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.U1U2.Name, "Generator U1 - U2");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.V1V2.Name, "Generator V1 - V2");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.W1W2.Name, "Generator W1 - W2");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.K1L1.Name, "Generator K1 - L1");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.L1M1.Name, "Generator L1 - M1");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.K1M1.Name, "Generator K1 - M1");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.K2L2.Name, "Generator K2 - L2");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.L2M2.Name, "Generator L2 - M2");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.K2M2.Name, "Generator K2 - M2");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.Uground.Name, "Generator U - Ground");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.UgroundOhmUnitId.Name, "Generator U - Ground (unit)");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.Vground.Name, "Generator V - Ground");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.VgroundOhmUnitId.Name, "Generator V - Ground (unit)");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.Wground.Name, "Generator W - Ground");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.WgroundOhmUnitId.Name, "Generator W - Ground (unit)");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.Uv.Name, "Generator U - V");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.UvohmUnitId.Name, "Generator U - V (unit)");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.Uw.Name, "Generator U - W");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.UwohmUnitId.Name, "U - V (unit)");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.Vw.Name, "Generator V - W");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.VwohmUnitId.Name, "Generator V - W (unit)");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.Kground.Name, "Generator K - Ground");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.KgroundOhmUnitId.Name, "Generator K - Ground (unit)");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.Lground.Name, "Generator L - Ground");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.LgroundOhmUnitId.Name, "Generator L - Ground (unit)");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.Mground.Name, "Generator M - Ground");
            ResultColumnMapList.Add(ComponentInspectionReportGeneratorFields.MgroundOhmUnitId.Name, "Generator M - Ground (unit)");

            //Main Bearing
            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingLastLubricationDate.Name, "Main Bearing Last Lubrication Date");
            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingManufacturerId.Name, "Main Bearing Manufacturer");
            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingTemperature.Name, "Main Bearing Temperature");
            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingLubricationOilTypeId.Name, "Main Bearing Lubrication Type");
            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingLubricationRunHours.Name, "Main Bearing Lubrication Run Hours");
            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingOilTemperature.Name, "Main Bearing Oil Temperature");

            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingTypeId.Name, "Main Bearing Type");
            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingRevision.Name, "Main Bearing Revision");
            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingErrorLocationId.Name, "Main Bearing Error Location");
            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingSerialNumber.Name, "Main Bearing Serial Number");
            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingRunHours.Name, "Main Bearing Run Hours");
            ResultColumnMapList.Add(ComponentInspectionReportMainBearingFields.MainBearingMechanicalOilPump.Name, "Main Bearing Mechanical Oil Pump");

            //SkiipPack
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentSerialNumber.Name, "SkiiP Failed Component Serial Number");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentVestasUniqueIdentifier.Name, "SkiiP Failed Component Vestas Unique Identifier");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPfailedComponentFields.SkiiPfailedComponentVestasItemNumber.Name, "SkiiP Failed Component Vestas Item Number");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentSerialNumber.Name, "SkiiP New Component Serial Number");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentVestasUniqueIdentifier.Name, "SkiiP New Component Vestas Unique Identifier");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPnewComponentFields.SkiiPnewComponentVestasItemNumber.Name, "SkiiP New Component Vestas Item Number");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiPotherDamagedComponentsReplaced.Name, "SkiiP Other Damaged Components Replaced");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiPcauseId.Name, "SkiiP Cause");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiPquantityOfFailedModules.Name, "SkiiP Quantity Of Failed Modules");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId.Name, "SkiiP 2MW V521");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv522BooleanAnswerId.Name, "SkiiP 2MW V522");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv523BooleanAnswerId.Name, "SkiiP 2MW V523");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv524BooleanAnswerId.Name, "SkiiP 2MW V524");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv525BooleanAnswerId.Name, "SkiiP 2MW V525");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP2Mwv526BooleanAnswerId.Name, "SkiiP 2MW V526");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv521BooleanAnswerId.Name, "SkiiP 3MW V521");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv522BooleanAnswerId.Name, "SkiiP 3MW V522");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv523BooleanAnswerId.Name, "SkiiP 3MW V523");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv524xBooleanAnswerId.Name, "SkiiP 3MW V524x");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv524yBooleanAnswerId.Name, "SkiiP 3MW V524y");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv525xBooleanAnswerId.Name, "SkiiP 3MW V525x");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv525yBooleanAnswerId.Name, "SkiiP 3MW V525y");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv526xBooleanAnswerId.Name, "SkiiP 3MW V526x");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP3Mwv526yBooleanAnswerId.Name, "SkiiP 3MW V526y");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv520BooleanAnswerId.Name, "SkiiP 850KW V520");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv524BooleanAnswerId.Name, "SkiiP 850KW V524");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv525BooleanAnswerId.Name, "SkiiP 850KW V525");
            ResultColumnMapList.Add(ComponentInspectionReportSkiiPFields.SkiiP850Kwv526BooleanAnswerId.Name, "SkiiP 850KW V526");

            //Transformer
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.TransformerManufacturerId.Name, "Transformer Manufacturer");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.TransformerSerialNumber.Name, "Transformer Ser. No.");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.TransformerArcDetectionId.Name, "Transformer Arc Detection");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.MaxTemp.Name, "Transformer Max Temperature");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.MaxTempResetDate.Name, "Transformer Max Temperature Reset Date");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.ActionOnTransformerId.Name, "Transformer Action To Be Taken");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.HvcoilConditionId.Name, "Transformer HV Coil");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.LvcoilConditionId.Name, "Transformer LV Coil");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.HvcableConditionId.Name, "Transformer HV Cable");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.LvcableConditionId.Name, "Transformer LV Cable");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.BracketsId.Name, "Transformer Brackets");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.ClimateId.Name, "Transformer Climate");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.SurgeArrestorId.Name, "Transformer Surge Arrestor");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.ConnectionBarsId.Name, "Transformer Connection Bars");
            ResultColumnMapList.Add(ComponentInspectionReportTransformerFields.Comments.Name, "Transformer Comment");

            //Gearbox
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxTypeId.Name, "Gear Type");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.OtherGearboxType.Name, "Other Gear Type");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxRevisionId.Name, "Gear Revision");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxManufacturerId.Name, "Gear Manufacturer");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxOtherManufacturer.Name, "Gear Other Manufacturer");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxSerialNumber.Name, "Gear Serial Number");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxOilTypeId.Name, "Gear Oil Type");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxMechanicalOilPumpId.Name, "Gear Mechanical Oil Pump");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxOilLevelId.Name, "Gear Oil Level");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxProduction.Name, "Gear Production");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId.Name, "Gear Generator Manufacturer");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId2.Name, "Gear Second Generator Manufacturer");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxElectricalPumpId.Name, "Gear Electrical Pump");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxShrinkElementId.Name, "Gear Shrink Element");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxShrinkElementSerialNumber.Name, "Gear Shrink Element Serial Number");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxCouplingId.Name, "Gear Coupling");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxFilterBlockTypeId.Name, "Gear Filter Block Type");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxInLineFilterId.Name, "Gear In Line Filter");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxOffLineFilterId.Name, "Gear Off Line Filter");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxSoftwareRelease.Name, "Gear Software Release");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation1ShaftTypeId.Name, "Gear Shaft Location");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage1ShaftErrorId.Name, "Gear Shaft Damage Type");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxExactLocation1GearTypeId.Name, "Gear Location");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxTypeofDamage1GearErrorId.Name, "Gear Damage Type");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxBearingsDamage1BearingErrorId.Name, "Gear Bearing Location");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxBearingsPosition1BearingPosId.Name, "Gear Bearing Position");
            //ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxBearingsDamage1BearingErrorId.Name, "Gear Bearing Damage Type");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxPlanetStage1HousingErrorId.Name, "Gear Housing Planet Stage 1");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxPlanetStage2HousingErrorId.Name, "Gear Housing Planet Stage 2");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxHelicalStageHousingErrorId.Name, "Gear Housing Stage");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxFrontPlateHousingErrorId.Name, "Gear Housing Front Plate");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxAuxStageHousingErrorId.Name, "Gear Housing Auxilary Stage");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxHsstageHousingErrorId.Name, "Gear Housing HS Stage");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxLooseBolts.Name, "Gear Torque Loose Bolts");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxBrokenBolts.Name, "Gear Torque Broken Bolts");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxDefectDamperElements.Name, "Gear Torque Defect Damper");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxTooMuchClearance.Name, "Gear Torque Too Much Clearance");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxCrackedTorqueArm.Name, "Gear Torque Cracked Broken");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxNeedsToBeAligned.Name, "Gear Torque Needs Alignment");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing1.Name, "Gear Defect Acc. PT100 Bearing 1");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing2.Name, "Gear Defect Acc. PT100 Bearing 2");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxPt100Bearing3.Name, "Gear Defect Acc. PT100 Bearing 3");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxOilLevelSensor.Name, "Gear Defect Acc. Oil Level Sensor");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxOilPressure.Name, "Gear Defect Acc. Oil Pressure");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxPt100OilSump.Name, "Gear Defect Acc. PT100 Oil Sump");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxFilterIndicator.Name, "Gear Defect Acc. Filter Indicator");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxImmersionHeater.Name, "Gear Defect Acc. Immersion Heater");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxDrainValve.Name, "Gear Defect Acc. Drain Valve");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxAirBreather.Name, "Gear Defect Acc. Air Breather");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxSightGlass.Name, "Gear Defect Acc. Sight Glass");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxChipDetector.Name, "Gear Defect Acc. Chip Detector");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxVibrationsId.Name, "Gear Symptoms Vibrations");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxNoiseId.Name, "Gear Symptoms Noise");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxDebrisOnMagnetId.Name, "Gear Symptoms Debris On Magnet");

            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxDebrisStagesMagnetPosId.Name, "Gear Symptoms Magnet Position");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxDebrisGearBoxId.Name, "Gear Symptoms Debris In Gearbox");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxLssnrend.Name, "Gear Leakage LSS NR End");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxImsnrend.Name, "Gear Leakage IMS NR End");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxImsrend.Name, "Gear Leakage IMS R End");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxHssnrend.Name, "Gear Leakage HSS NR End");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxHssrend.Name, "Gear Leakage HSS R End");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxPitchTube.Name, "Gear Leakage Pitch Tube");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxSplitLines.Name, "Gear Leakage Split Lines");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxHoseAndPiping.Name, "Gear Leakage Hose Piping");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxInputShaft.Name, "Gear Leakage Input Shaft");
            ResultColumnMapList.Add(ComponentInspectionReportGearboxFields.GearboxHsspto.Name, "Gear Leakage Aux. HSS/PTO");

            //Blade
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLengthId.Name, "Blade Length (m)");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeColorId.Name, "Blade Color");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeSerialNumber.Name, "Blade Serial No.");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladePicturesIncludedBooleanAnswerId.Name, "Blade Pictures Included");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeOtherSerialNumber1.Name, "Other Blades In Set");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeDamageIdentified.Name, "Blade Damage Identified");
            ResultColumnMapList.Add(ComponentInspectionReportBladeDamageFields.BladeDamagePlacementId.Name, "Blade Damage Placement");
            ResultColumnMapList.Add(ComponentInspectionReportBladeDamageFields.BladeInspectionDataId.Name, "Blade Damage Type");
            ResultColumnMapList.Add(ComponentInspectionReportBladeDamageFields.BladeRadius.Name, "Blade Radius (m)");
            ResultColumnMapList.Add(ComponentInspectionReportBladeDamageFields.BladeEdgeId.Name, "Blade Edge");
            ResultColumnMapList.Add(ComponentInspectionReportBladeDamageFields.BladeDescription.Name, "Blade Description");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeFaultCodeClassificationId.Name, "Blade Fault Code Class");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeFaultCodeCauseId.Name, "Blade Fault Code Cause");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeFaultCodeTypeId.Name, "Blade Fault Code Type");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeFaultCodeAreaId.Name, "Blade Fault Code Area");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsVtNumber.Name, "Blade Light. Sys. VT Number");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsCalibrationDate.Name, "Blade Light. Sys. Calibration Date");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepairTip.Name, "Blade Light. Sys. Leeward Pre-rep. Tip");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepairTip.Name, "Blade Light. Sys. Leeward Post-rep. Tip");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair2.Name, "Blade Light. Sys. Leeward Pre-rep. 2");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair2.Name, "Blade Light. Sys. Leeward Post-rep. 2");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair3.Name, "Blade Light. Sys. Leeward Pre-rep. 3");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair3.Name, "Blade Light. Sys. Leeward Post-rep. 3");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair4.Name, "Blade Light. Sys. Leeward Pre-rep. 4");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair4.Name, "Blade Light. Sys. Leeward Post-rep. 4");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePreRepair5.Name, "Blade Light. Sys. Leeward Pre-rep. 5");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsLeewardSidePostRepair5.Name, "Blade Light. Sys. Leeward Post-rep. 5");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepairTip.Name, "Blade Light. Sys. Windward Pre-rep. Tip");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepairTip.Name, "Blade Light. Sys. Windward Post-rep. Tip");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair2.Name, "Blade Light. Sys. Windward Pre-rep. 2");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair2.Name, "Blade Light. Sys. Windward Post-rep. 2");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair3.Name, "Blade Light. Sys. Windward Pre-rep. 3");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair3.Name, "Blade Light. Sys. Windward Post-rep. 3");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair4.Name, "Blade Light. Sys. Windward Pre-rep. 4");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair4.Name, "Blade Light. Sys. Windward Post-rep. 4");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePreRepair5.Name, "Blade Light. Sys. Windward Pre-rep. 5");
            ResultColumnMapList.Add(ComponentInspectionReportBladeFields.BladeLsWindwardSidePostRepair5.Name, "Blade Light. Sys. Windward Post-rep. 5");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeAmbientTemp.Name, "Blade Rep. Rec. Ambient Temp.");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHumidity.Name, "Blade Rep. Rec. Humidity");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeAdditionalDocumentReference.Name, "Blade Rep. Rec. Add. Document Reference");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinType.Name, "Blade Rep. Rec. Resin Type");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeBatchNumbers.Name, "Blade Rep. Rec. Resin Type Batch No.");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinTypeExpiryDate.Name, "Blade Rep. Rec. Resin Type Expiry Date");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerType.Name, "Blade Rep. Rec. Hard. Type");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeBatchNumbers.Name, "Blade Rep. Rec. Hard. Type Batch No.");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeHardenerTypeExpiryDate.Name, "Blade Rep. Rec. Hard. Type Expiry Date");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeGlassSupplier.Name, "Blade Rep. Rec. Glass Supp.");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeGlassSupplierBatchNumbers.Name, "Blade Rep. Rec. Glass Supp. Batch No.");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeSurfaceMinTemperature.Name, "Blade Rep. Rec. Min. Surf. Temp/Lam.");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeSurfaceMaxTemperature.Name, "Blade Rep. Rec. Max. Surf. Temp/Lam.");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeResinUsed.Name, "Blade Rep. Rec. Quantity Mixed Resin");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladePostCureMinTemperature.Name, "Blade Rep. Rec. Min. Post Cure Surf. Temp");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladePostCureMaxTemperature.Name, "Blade Rep. Rec. Max. Post Cure Surf. Temp");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeTurnOffTime.Name, "Blade Rep. Rec. Heaters Etc. Off");
            ResultColumnMapList.Add(ComponentInspectionReportBladeRepairRecordFields.BladeTotalCureTime.Name, "Blade Rep. Rec. Total Cure Time");
        }

    }
}