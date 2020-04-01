using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Cir.Sync.Services.DataContracts
{
    /// <summary>
    /// Standard Text
    /// </summary>
    [DataContract]
    public class StandardTexts
    {
        #region Private properties
        private int _id;
        private string _title;
        private string _description;
        private DateTime _created;
        private string _createdBy;
        private DateTime _modified;
        private string _modifiedBy;
        private bool _deleted;
        private long? _componentInspectionReportTypeId;
        private bool _Status;
        private string _StatusMessage;
        private string _CallFunction;
        #endregion Private properties

        #region Public properties
        /// <summary>
        /// ID
        /// </summary>
        [DataMember]
        public int Id { get { return _id; } set { _id = value; } }
        /// <summary>
        /// Title
        /// </summary>
        [DataMember]
        public string Title { get { return _title; } set { _title = value; } }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        public string Description { get { return _description; } set { _description = value; } }
        /// <summary>
        /// Created On
        /// </summary>
        [DataMember]
        public DateTime Created { get { return _modified; } set { _modified = value; } }
        /// <summary>
        /// Created By
        /// </summary>
        [DataMember]
        public string CreatedBy { get { return _createdBy; } set { _createdBy = value; } }
        /// <summary>
        /// Modified On
        /// </summary>
        [DataMember]
        public DateTime Modified { get { return _modified; } set { _modified = value; } }
        /// <summary>
        /// Modified By
        /// </summary>
        [DataMember]
        public string ModifiedBy { get { return _modifiedBy; } set { _modifiedBy = value; } }
        /// <summary>
        /// Deleted
        /// </summary>
        [DataMember]
        public bool Deleted { get { return _deleted; } set { _deleted = value; } }
        /// <summary>
        /// ComponentInspectionReportTypeId
        /// </summary>
        [DataMember]
        public long? ComponentInspectionReportTypeId { get { return _componentInspectionReportTypeId; } set { _componentInspectionReportTypeId = value; } }
        /// <summary>
        /// Status
        /// </summary>
        [DataMember]
        public bool Status { get { return _Status; } set { _Status = value; } }
        /// <summary>
        /// StatusMessage
        /// </summary>
        [DataMember]
        public string StatusMessage { get { return _StatusMessage; } set { _StatusMessage = value; } }

        /// <summary>
        /// StatusMessage
        /// </summary>
        [DataMember]
        public string CallFunction { get { return _CallFunction; } set { _CallFunction = value; } }


        #endregion Public properties
    }
}