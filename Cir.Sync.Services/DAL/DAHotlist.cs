using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.Edmx;
using Cir.Sync.Services.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DAL
{
    public class DAHotlist
    {
        public static DataContracts.Hotlist GetHotlist(int hotlistid)
        {
            Hotlist hotlist = new Hotlist();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                hotlist = context.HotItem.Where(x => x.HotItemId == hotlistid).OrderBy(x => x.ComponentInspectionReportTypeId).Select(x => new Hotlist
                {
                    ReportTypeId = (long)x.ComponentInspectionReportTypeId,
                    VestasItemNumber = x.VestasItemNumber,
                    VestasItemName = x.VestasItemName,
                    ManufacturerName = x.ManufacturerName,
                    Email = x.Email,
                    Cc = x.Cc,
                    HotItemDisplay = x.HotItemDisplay
                    //ReportType = GetReportType(x.ComponentInspectionReportTypeId)
                }).FirstOrDefault();


            }
            return hotlist;
        }
        public static List<DataContracts.Hotlist> GetAllHotlist()
        {
            List<Hotlist> hotlistall = new List<Hotlist>();
            using (CIM_CIREntities context = new CIM_CIREntities())
            {
                

                hotlistall = context.HotItem.OrderBy(x => x.ComponentInspectionReportTypeId).ThenBy(x => x.ManufacturerName).Select(x => new Hotlist
                {
                    ReportTypeId = (long)x.ComponentInspectionReportTypeId,
                    VestasItemNumber = x.VestasItemNumber,
                    VestasItemName = x.VestasItemName,
                    ManufacturerName = x.ManufacturerName,
                    Email = x.Email,
                    Cc = x.Cc,
                    HotItemDisplay = x.HotItemDisplay,
                    HotItemId = x.HotItemId
                    //ReportType=(string) x.ComponentInspectionReportType
                   
                }).ToList();

            }
            return hotlistall;
        }
        public static bool SaveHotList(Hotlist hotlist)
        {
            try
            {

                using (CIM_CIREntities context = new CIM_CIREntities())
                {


                    var m = context.HotItem.Where(x => x.HotItemId == hotlist.HotItemId).FirstOrDefault();
                    if (m == null)
                    {
                        HotItem hotitem = new HotItem();
                        hotitem.ComponentInspectionReportTypeId = hotlist.ReportTypeId;
                        hotitem.VestasItemNumber = hotlist.VestasItemNumber;
                        hotitem.VestasItemName = hotlist.VestasItemName;
                        hotitem.ManufacturerName = hotlist.ManufacturerName;
                        hotitem.Email = hotlist.Email;
                        hotitem.Cc = hotlist.Cc;
                        hotitem.HotItemDisplay = hotlist.VestasItemNumber + "[" + GetReportType(hotlist.ReportTypeId) + "]:" + hotlist.VestasItemName;
                        hotitem.LanguageId = 1;
                        hotitem.Sort = 1;
                        context.HotItem.Add(hotitem);
                        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Hot Item" + hotlist.ManufacturerName + " created!", LogType.Information, "");
                    }
                    else
                    {
                        m.ComponentInspectionReportTypeId = hotlist.ReportTypeId;
                        m.VestasItemNumber = hotlist.VestasItemNumber;
                        m.VestasItemName = hotlist.VestasItemName;
                        m.ManufacturerName = hotlist.ManufacturerName;
                        m.Email = hotlist.Email;
                        m.Cc = hotlist.Cc;
                        m.HotItemDisplay = hotlist.VestasItemNumber + "[" + GetReportType(hotlist.ReportTypeId) + "]:" + hotlist.VestasItemName;
                        m.LanguageId = 1;
                        m.Sort = 1;
                        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Hot Item" + hotlist.ManufacturerName + " updated!", LogType.Information, "");
                    }
                    context.SaveChanges();
                }
            }

            catch (Exception e)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error Saving hotlist item  " + hotlist.ManufacturerName + " !", LogType.Error, e.Message.ToString());
                return false;
            }
            return true;
        }

        public static bool DeleteHotList(int id)
        {
            try
            {
                using (CIM_CIREntities context = new CIM_CIREntities())
                {
                    var m = context.HotItem.Where(x => x.HotItemId == id).FirstOrDefault();
                    if (m != null)
                    {
                        context.HotItem.Remove(m);
                        context.SaveChanges();
                        ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Blade Manufacturer with Name  " + m.ManufacturerName + " deleted!", LogType.Information, "");
                    }
                }
            }
            catch (Exception e)
            {
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Error Deleting Manufacturer!", LogType.Error, e.Message.ToString());
                return false;
            }
            return true;


        }

        public static string GetReportType(long? reporttypeid)
        {
            var reporttypename = string.Empty;

            if (reporttypeid == 1)
            {
                reporttypename = "Blade";

            }
            else if (reporttypeid == 2)
            {
                reporttypename = "Gearbox";

            }
            else if (reporttypeid == 3)
            {

                reporttypename = "General";

            }
            else if (reporttypeid == 4)
            {
                reporttypename = "Generator";


            }
            else if (reporttypeid == 5)
            {
                reporttypename = "Transformer";

            }
            else if (reporttypeid == 6)
            {

                reporttypename = "Main Bearing";

            }
            else if (reporttypeid == 7)
            {
                reporttypename = "Skiipack";

            }
            return reporttypename;
        }

    }
}