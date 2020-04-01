using Cir.Sync.Services.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DataContracts
{

    public class GIRView
    {

        private string _ClassificationOfDamage;
        private string _AnalysisOfPicture;
        private string _AnalysisOfMeasurments;
        private string _ConculsionRecomm;
        private string _Createdby;
        private long _MAsterCIRid;
        private string _CIRIDs;
        private string _TurbineID;
        public long GirDataId { get; set; }
        public string GirCode { get; set; }
        public int RevisionNumber { get; set; }
        public long CIRDataId { get; set; }
        public long CIRId { get; set; }
        public string SiteAddress { get; set; }
        public DateTime Created { get; set; }
        public string TurbineNumber { get; set; }
        public string TurbineType { get; set; }
        public string Country { get; set; }
        public string SBU { get; set; }
        public string GeneratorSln { get; set; }
        public List<long> Cirs { get; set; }
        public List<string> BladeRotors { get; set; }
        public string MasterCreatedBy { get; set; }
        public DateTime CommisionDate { get; set; }
        public string FailureDate { get; set; }
        public DateTime InspectionDate { get; set; }
        public string ReasonForService { get; set; }
        public string Description { get; set; }
        public string SBURecommendation { get; set; }
        public string AdditionalInfo { get; set; }
        public decimal UGround { get; set; }
        public decimal VGround { get; set; }
        public decimal WGround { get; set; }
        public decimal UV { get; set; }
        public decimal UW { get; set; }
        public decimal VW { get; set; }
        public long U1U2 { get; set; }
        public long V1V2 { get; set; }
        public long W1W2 { get; set; }
        public long K1M1 { get; set; }
        public long K1L1 { get; set; }
        public long L1M1 { get; set; }
        public long K2L2 { get; set; }
        public long L2M2 { get; set; }
        public long K2M2 { get; set; }
        public decimal KGround { get; set; }
        public decimal LGround { get; set; }
        public decimal MGround { get; set; }
        public string ManufecturerName { get; set; }




        public GIRView()
        {
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

        public string ClassificationOfDamage
        {
            get
            {
                return _ClassificationOfDamage;
            }
            set { _ClassificationOfDamage = value; }
        }

        public string AnalysisOfPicture
        {
            get
            {
                return _AnalysisOfPicture;
            }
            set { _AnalysisOfPicture = value; }
        }
        public string AnalysisOfMeasurments
        {
            get
            {
                return _AnalysisOfMeasurments;
            }
            set { _AnalysisOfMeasurments = value; }
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



    public class GirPlaceholders
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
        public GirPlaceholders(long id, string Placeholders, string Field, long? ComponentInspectionReportTypeId)
        {
            _id = id;
            _placeholder = Placeholder;
            _field = Field;
            _componentInspectionReportTypeId = ComponentInspectionReportTypeId;
        }

        #endregion Public properties
    }
    public class GIRImageData
    {
        public int? Order { get; set; }
        public string Comment { get; set; }
        public byte[] ImageData { get; set; }
    }
}
