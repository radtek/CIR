using Cir.Sync.Services.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Xml.Serialization;

namespace Cir.Sync.Services.DataContracts
{
    /// <summary>
    /// Class which encapsulates a generic list DTO
    /// </summary>

    [DataContract]
    public class CIRList
    {
        [DataMember]
        public int ViewId { get; set; }
        [DataMember]
        public int State { get; set; }
        [DataMember]
        public int SortColumnIndex { get; set; }
        [DataMember]
        public int SortDirection { get; set; }
        [DataMember]
        public int CurrentPageNumber { get; set; }
        [DataMember]
        public int RecordsPerPage { get; set; }
        [DataMember]
        public int TotalRecordCount { get; set; }
        [DataMember]
        public int TotalRecordCountApprove { get; set; }
        [DataMember]
        public int TotalRecordCountReject { get; set; }
        [DataMember]
        public string Data { get; set; }

        //Added by Siddharth Chauhan on 15-06-2016
        //below parameters added Filter the CIR list based on fields.
        //Task No.: 75301
        [DataMember]
        public long CirId { get; set; }
        [DataMember]
        public string CirName { get; set; }
        [DataMember]
        public long CimCase { get; set; }
        [DataMember]
        public long ComponentType { get; set; }
        [DataMember]
        public long ReportType { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string SiteName { get; set; }
        [DataMember]
        public string TurbineType { get; set; }
        [DataMember]
        public long TurbineNumber { get; set; }
        [DataMember]
        public long RunStatus { get; set; }
        [DataMember]
        public string SBU { get; set; }
        [DataMember]
        public Nullable<DateTime> Created { get; set; }
        [DataMember]
        public Nullable<DateTime> Modified { get; set; }
        [DataMember]
        public string ModifiedBy { get; set; }
        [DataMember]
        public string BrandType { get; set; }

    }



    public class CirDataDetail
    {
        public long CirDataId { get; set; }
        public string CirId { get; set; }
        public int CirState { get; set; }
        public string Filename { get; set; }
        public string ComponentType { get; set; }
        public string CIMCaseNumber { get; set; }
        public string ReportType { get; set; }
        public string TurbineType { get; set; }
        public string TurbineNumber { get; set; }
        public int Progress { get; set; }
        public string modifiedBy { get; set; }
        public string comment { get; set; }
        public int Locked { get; set; }
        public string LockedBy { get; set; }
        public string PdfDataUri { get; set; }
        public string CreatedBy { get; set; }
        public string TemplateGUID { get; set; }
        [DataMember]
        public Nullable<DateTime> Created { get; set; }
        [DataMember]
        public Nullable<DateTime> Modified { get; set; }

        public string FileBytes { get; set; }
        public string EmailId { get; set; }

        public string TemplateVersion { get; set; }
        public string FormIOGUID { get; set; }
    }
    public class CirDataActionResponse
    {
        public int error { get; set; }
        public string message { get; set; }

    }
}