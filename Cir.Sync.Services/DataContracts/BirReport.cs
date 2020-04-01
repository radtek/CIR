using Cir.Sync.Services.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.DataContracts
{

    public class BIRView
    {
        private string _RepairingSol;
        private string _RawMaterial;
        private string _ConculsionRecomm;
        private string _Createdby;
        private long _MAsterCIRid;
        private string _CIRIDs;
        private string _TurbineID;
        public long BirDataId { get; set; }
        public string BirCode { get; set; }
        public int RevisionNumber { get; set; }
        public long CIRDataId { get; set; }
        public long CIRId { get; set; }
        public string SiteAddress { get; set; }
        public DateTime Created { get; set; }
        public string TurbineNumber { get; set; }
        public string TurbineType { get; set; }
        public string Country { get; set; }
        public string SBU { get; set; }
        public string BladeSln { get; set; }
        public List<long> Cirs { get; set; }
        public List<string> BladeRotors { get; set; }
        public string MasterCreatedBy { get; set; }
        public DateTime CommisionDate { get; set; }
        public BIRView()
        {
        }
        public BIRView(long MAsterCIRid, string CIRIDs, string RepairingSol, string RawMaterial, string ConculsionRecomm, string TurbineID, string Createdby)
        {

            _MAsterCIRid = MAsterCIRid;
            _CIRIDs = CIRIDs;
            _TurbineID = TurbineID;
            _RepairingSol = RepairingSol;
            _RawMaterial = RawMaterial;
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

        public string RepairingSol
        {
            get
            {
                return _RepairingSol;
            }
            set { _RepairingSol = value; }
        }

        public string RawMaterial
        {
            get
            {
                return _RawMaterial;
            }
            set { _RawMaterial = value; }
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



    public class Placeholders
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
        public Placeholders(long id, string Placeholders, string Field, long? ComponentInspectionReportTypeId)
        {
            _id = id;
            _placeholder = Placeholder;
            _field = Field;
            _componentInspectionReportTypeId = ComponentInspectionReportTypeId;
        }

        #endregion Public properties
    }
    public class BIRImageData
    {
        public int? Order { get; set; }
        public string Comment { get; set; }
        public byte[] ImageData { get; set; }

        //BIR3.1
        public long CIRId { get; set; }

        public int ImageId { get; set; }
        public string ImageDataString { get; set; }
        public int? ImageOrder { get; set; }
        public string BladeSection { get; set; }
        public string FormIOImageGUID { get; set; }

        public long BladeDamageId { get; set; }
        public string DamageIdentified { get; set; }
        public string BladeEdge { get; set; }
        public long BladeEdgeId { get; set; }
        public double Radius { get; set; }
        public string DamageDescription { get; set; }
        public int? Category { get; set; }
        public bool? IsPlateType { get; set; }
        public string PicutreNumber { get; set; }
    }

    public class BIRDamangeData
    {
        public long BladeDamageId { get; set; }
        public string BladeRadius { get; set; }
        public string BladeEdge { get; set; }
        public string BladeDescription { get; set; }
        public string BladeDamageType { get; set; }
        public string SBURecommendation { get; set; }
        public long? BladeFaultCodeClassificationId { get; set; }
        public int? DamageSeverity { get; set; }
        public Guid? FORMIOImageGUID { get; set; }
        public long CirId { get; internal set; }
        public bool? IsPlateType { get; set; }
    }
}
