using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.BirPdf
{
    public class Placeholders
    {
        #region Private properties
        private long _id;
        private string _placeholder;
        private Guid _field;
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
        public Guid Field { get { return _field; } set { _field = value; } }
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
        public Placeholders(long id, string Placeholders, Guid Field, long? ComponentInspectionReportTypeId)
        {
            _id = id;
            _placeholder = Placeholder;
            _field = Field;
            _componentInspectionReportTypeId = ComponentInspectionReportTypeId;
        }

        #endregion Public properties
    }
}
