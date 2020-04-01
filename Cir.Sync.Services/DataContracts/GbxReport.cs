using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DataContracts
{
    public class GbxView
    {
        private string _OilAnalysis;
        private string _CMSAnalysis;
        private string _Analysis;
        private string _ConculsionRecomm;
        private string _Createdby;
        private long _MAsterCIRid;
        private string _CIRIDs;
        private string _TurbineID;
        public long GbxDataId { get; set; }
        public string GbxCode { get; set; }
        public int RevisionNumber { get; set; }
        public long CIRDataId { get; set; }
        public long CIRId { get; set; }
        public string SiteAddress { get; set; }
        public DateTime Created { get; set; }
        public string TurbineNumber { get; set; }
        public string TurbineType { get; set; }
        public string Country { get; set; }
        public string SBU { get; set; }
        public string GearboxSerialNos { get; set; }
        public List<long> Cirs { get; set; }
        public List<string> BladeRotors { get; set; }
        public string MasterCreatedBy { get; set; }
        public DateTime CommisionDate { get; set; }
        public string GearboxType { get; set; }
        public string GearboxRevision { get; set; }
        public DateTime InstallationDate { get; set; }
        public DateTime InspectionDate { get; set; }
        public string ReasonForService { get; set; }
        public string AdditionalInfo { get; set; }
        public string SBURecommendation { get; set; }
        public string Description { get; set; }
        public string gearboxLSSNRend { get; set; }
        public string GearboxIMSNRend { get; set; }
        public string GearboxHSSNRend { get; set; }
        public string GearboxHSSRend { get; set; }
        public string GearboxIMSRend { get; set; }
        

        
        

        



        
        

        

        
        public GbxView()
        {
        }
        public GbxView(long MAsterCIRid, string CIRIDs, string OilAnalysis, string CMSAnalysis, string Analysis, string ConculsionRecomm, string TurbineID, string Createdby)
        {

            _MAsterCIRid = MAsterCIRid;
            _CIRIDs = CIRIDs;
            _TurbineID = TurbineID;
            _OilAnalysis = OilAnalysis;
            _CMSAnalysis = CMSAnalysis;
            _Analysis = Analysis;
            _ConculsionRecomm = ConculsionRecomm;
            _Createdby = Createdby;
        }
        public long MAsterCIRid
        {
            get
            {
                return _MAsterCIRid;
            }
        }

        public string CIRIDs
        {
            get
            {
                return _CIRIDs;
            }
        }

        public string TurbineID
        {
            get
            {
                return _TurbineID;
            }
        }

        public string OilAnalysis
        {
            get
            {
                return _OilAnalysis;
            }
            set { _OilAnalysis = value; }
        }

        public string CMSAnalysis
        {
            get
            {
                return _CMSAnalysis;
            }
            set { _CMSAnalysis = value; }
        }

        public string Analysis
        {
            get
            {
                return _Analysis;
            }
            set { _Analysis = value; }
        }

        public string ConculsionRecomm
        {
            get
            {
                return _ConculsionRecomm;
            }
            set { _ConculsionRecomm = value; }
        }

        public string Createdby
        {
            get
            {
                return _Createdby;
            }
            set
            {
                _Createdby = value;
            }
        }
    }

    public class GBXPlaceholders
    {
        #region Private properties
        private long _id;
        private string _placeholder;
        private string _field;
        private long? _componentInspectionReportTypeId;
        #endregion Private properties


        
        #region Public properties
        /// <summary>
        /// ID
        /// </summary>
        public long Id { get { return _id; } set { _id = value; } }
        /// <summary>
        /// Title
        /// </summary>
        public string Placeholder { get { return _placeholder; } set { _placeholder = value; } }
        /// <summary>
        /// Description
        /// </summary>
        public string Field { get { return _field; } set { _field = value; } }
        /// <summary>
        /// ComponentInspectionReportTypeId
        /// </summary>
        public long? ComponentInspectionReportTypeId { get { return _componentInspectionReportTypeId; } set { _componentInspectionReportTypeId = value; } }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        public GBXPlaceholders(long id, string Placeholders, string Field, long? ComponentInspectionReportTypeId)
        {
            _id = id;
            _placeholder = Placeholder;
            _field = Field;
            _componentInspectionReportTypeId = ComponentInspectionReportTypeId;
        }

        #endregion Public properties
       
    }

    public class GBXImageData
    {
        public int? Order { get; set; }
        public string Comment { get; set; }
        public byte[] ImageData { get; set; }
    }
}