using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services.CIR;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.DAL;
using System.Web.UI.WebControls;

namespace Cir.Sync.Services.BLL
{
    /// <summary>
    /// Business layer of Cir View
    /// </summary>
    public static class BLCIRViewData
    {

        /// <summary>
        /// Gets all view.
        /// </summary>
        /// <returns></returns>
        public static List<CirViewData> GetAllView()
        {
            return DAL.DACIRView.ApplicableViews().Values.ToList <CirViewData>();

        }

        public static CirViewData GetAllViewList(string initials = "")
        {
            return DAL.DACIRView.GetAllViewList(initials);
        }
        /// <summary>
        /// Gets the view.
        /// </summary>
        /// <param name="ViewId">The view identifier.</param>
        /// <returns></returns>
        public static CirViewData GetView(int ViewId)
        {
            return DAL.DACIRView.GetView(ViewId);

        }


        /// <summary>
        /// Creates the view.
        /// </summary>
        /// <param name="ViewId">The view identifier.</param>
        /// <returns></returns>
        public static int CreateView(CirViewData cirViewData)
        {
            return DAL.DACIRView.CreateView(cirViewData);

        }

        public static bool DeleteView(int ViewId)
        {
            return DAL.DACIRView.DeleteView(ViewId);

        }


        public static CIRList GetCirList(CIRList cirList)
        {
            return DAL.DACIRView.GetCirList(cirList);

        }

        public static CirDataActionResponse CirProcess(CirDataDetail cirDataDetail)
        {
            return DAL.DACIRView.CirProcess(cirDataDetail);
        }


        public static CirDataActionResponse LockUnlockCir(CirDataDetail cirDataDetail)
        {
            return DAL.DACIRView.LockUnlockCir(cirDataDetail);
        }

        public static CirDataDetail GetCirDataDetails(long CirDataId)
        {
            return DAL.DACIRView.GetCirDataDetails(CirDataId);
        }

        public static int GetBIRViewId()
        {
            return DAL.DACIRView.GetBIRViewId();
        }
        public static int GetGIRViewId()
        {
           return DAL.DACIRView.GetGIRViewId();
        }

        public static int GetGBXIRViewId()
        {
            return DAL.DACIRView.GetGBXIRViewId();
        }

        public static bool ResendSecondMails()
        {
            return DAL.DACIRView.ResendSecondMails();

        }
        public static List<CirDataDetail> GetMigrationCirList()
        {
            return DAL.DACIRData.GetMigrationCirList();

        }
             
    }

}