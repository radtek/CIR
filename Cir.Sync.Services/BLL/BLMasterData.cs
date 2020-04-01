using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.DAL;

namespace Cir.Sync.Services.BLL
{
    /// <summary>
    /// Business layer of Master Data
    /// </summary>
    public static class BLMasterData
    {
        /// <summary>
        /// Get cir master data
        /// </summary>
        /// <returns></returns>
        public static List<CirMasterData> GetMasterData()
        {
            return DAL.DAMasterData.GetMasterData();
        }

        /// <summary>
        /// Get cir master data
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static List<CirMasterTable> GetMasterDataByName(string TableName, string UserId)
        {
            return DAL.DAMasterData.GetMasterDataByName(TableName, UserId);
        }

        /// <summary>
        /// Get CIM Case data.
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static List<CirCIMCaseTable> GetCIMCaseData()
        {
            return DAL.DAMasterData.GetCIMCaseData();
        }

        /// <summary>
        /// Get pdf data of a cir
        /// </summary>
        /// <returns></returns>
        public static DataContracts.PDFModel GetCirPDFData(string cirId)
        {
            DataContracts.PDFModel objpdf = new DataContracts.PDFModel();
            var pdfData = DACIRReport.GetCirPDFData(cirId);
            if (pdfData != null)
            {
                objpdf.CIRName = pdfData.CIRName;
                objpdf.CIRState = pdfData.CIRState;
                objpdf.CIRTemplateGUID = pdfData.CIRTemplateGUID;
                objpdf.PDFData = pdfData.PDFData;
                objpdf.PDFId = pdfData.PDFId;
            }
            return objpdf;
        }
    }
}