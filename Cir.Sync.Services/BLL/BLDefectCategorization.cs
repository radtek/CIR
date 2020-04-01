using Cir.Sync.Services.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.BLL
{
    public static class BLDefectCategorization
    {
        public static CirDefectCategorization UploadDefectCategotization(CirDefectCategorization dc)
        {
            string DocumentPath = HttpContext.Current.Server.MapPath("CIRTemplates");
            dc.path = DocumentPath;
            DAL.DADefectCategorization d = new DAL.DADefectCategorization();

            return d.UploadDefectCategotization(dc);

        }
      
    }
}