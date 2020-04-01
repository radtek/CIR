using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Cir.WebApp.Offline.Models.Cir.StandardText
{
    /// <summary>
    /// User model
    /// </summary>
    public class StandTextModel
    {
        #region Private properties
        private int _id;
        private string _title;
        private string _description;
        //private DateTime _created;
        private string _createdBy;
        private DateTime _modified;
        private string _modifiedBy;
        private bool _deleted;
        private long? _componentInspectionReportTypeId;
        #endregion Private properties
        #region Public properties
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get { return _id; } set { _id = value; } }
        /// <summary>
        /// Title
        /// </summary>
        [Display(Name = "Stanadard Text Name")]
        [Required(ErrorMessage = "Please enter stanadard text ")]
        public string Title { get { return _title; } set { _title = value; } }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get { return _description; } set { _description = value; } }
        /// <summary>
        /// Created On
        /// </summary>
        public DateTime Created { get { return _modified; } set { _modified = value; } }
        /// <summary>
        /// Created By
        /// </summary>
        public string CreatedBy { get { return _createdBy; } set { _createdBy = value; } }
        /// <summary>
        /// Modified On
        /// </summary>
        public DateTime Modified { get { return _modified; } set { _modified = value; } }
        /// <summary>
        /// Modified By
        /// </summary>
        public string ModifiedBy { get { return _modifiedBy; } set { _modifiedBy = value; } }
        /// <summary>
        /// Deleted
        /// </summary>
        public bool Deleted { get { return _deleted; } set { _deleted = value; } }
        /// <summary>
        /// ComponentInspectionReportTypeId
        /// </summary>
        [Required(ErrorMessage = "Please enter Component Inspection Report Type ID")]
        public long? ComponentInspectionReportTypeId { get { return _componentInspectionReportTypeId; } set { _componentInspectionReportTypeId = value; } }

        public List<CommonInspectionReportType> ReportTypes { get; set; }
        #endregion Public properties
    }
    /// <summary>
    /// Role class
    /// </summary>
    public class CommonInspectionReportType
    {
        public long CommonInspectionReportID { get; set; }
        public string ReportName { get; set; }
    }
}