using Cir.Common.Cir;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.AccessControl
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
        public List<Metadata.MetadataItem> Cirs { get; set; }
        public List<CIRDataItem> BirCirData { get; set; }
        
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
			get {
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
			get {
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

    public class CIRDataItem
    {
        public State State = State.Initial;

        public Progress Progress = Progress.Done;

        public bool Deleted = false;

        public long CirDataId { get; set; }
        public long CirId { get; set; }
        public long BirDataId { get; set; }
        public long CIMCaseNumber { get; set; }
        public int RevisionNumber { get; set; }

        public string Site { get; set; }

        private DateTime _created = DateTime.MinValue;

        public string Name { get; set; }

        private string _CreatedBy;

        public DateTime Created
        {
            get
            {
                return _created;
            }
            set
            {
                _created = value;
            }
        }

        public string CreatedBy
        {
            get
            {
                return _CreatedBy;
            }
            set
            {
                _CreatedBy = value;
            }
        }


        private DateTime _modified = DateTime.MinValue;

        public DateTime Modified
        {
            get
            {
                return _modified;
            }
            set
            {
                _modified = value;
            }
        }


        
    }
}
