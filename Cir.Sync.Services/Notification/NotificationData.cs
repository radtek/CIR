using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.Notification
{
    public abstract class NotificationData : Notification
    {
        protected long _ComponentInspectionReportId;
        protected string _EditInitials;
        protected DateTime? _EditDate;
        protected string _Country;
        protected string _SBU;
        protected string _SiteName;
        protected string _TurbineID;
        protected long _TurbineMatrixId;
        protected ComponentType _ComponentType;
        protected State _State;

        public long ComponentInspectionReportId
        {
            get { return _ComponentInspectionReportId; }
        }

        public System.Nullable<System.DateTime> EditDate
        {
            get { return _EditDate; }
            set { _EditDate = value; }
        }

        public string EditInitials
        {
            get
            {
                if (string.IsNullOrEmpty(_EditInitials))
                {
                    return "-";
                }
                return _EditInitials.Trim(' ');
            }
            set { _EditInitials = value; }
        }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>The state.</value>
        public State State
        {
            get { return _State; }
            set { _State = value; }
        }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>The country.</value>
        public string Country
        {
            get
            {
                if (string.IsNullOrEmpty(_Country))
                {
                    return "-";
                }
                return _Country;
            }
            set { _Country = value; }
        }

        /// <summary>
        /// Gets or sets the SBU.
        /// </summary>
        /// <value>The SBU.</value>
        public string SBU
        {
            get
            {
                if (string.IsNullOrEmpty(_SBU))
                {
                    return "-";
                }
                return _SBU;
            }
            set { _SBU = value; }
        }

        public string Turbine
        {
            get { return _TurbineID; }
            set { _TurbineID = value; }
        }

        /// <summary>
        /// Gets or sets the turbine matrix id.
        /// </summary>
        /// <value>The turbine matrix id.</value>
        public long TurbineMatrixId
        {
            get { return _TurbineMatrixId; }
            set { _TurbineMatrixId = value; }
        }
        public string SiteName
        {
            get
            {
                if (string.IsNullOrEmpty(_SiteName))
                {
                    return "-";
                }
                return _SiteName;
            }
            set { _SiteName = value; }
        }

        /// <summary>
        /// Gets or sets the type of the component.
        /// </summary>
        /// <value>The type of the component.</value>
        public ComponentType ComponentType
        {
            get { return _ComponentType; }
            set { _ComponentType = value; }
        }

        /// <summary>
        /// Casts the type of the component.
        /// </summary>
        /// <param name="componentType">Type of the component.</param>
        /// <returns></returns>
        protected ComponentType CastComponentType(string componentType)
        {
            try
            {
                if (componentType.Contains(" "))
                {
                    string temp = "";
                    string[] str = componentType.Split(' ');
                    foreach (string s in str)
                    {
                        temp = temp + s;
                    }
                    return (ComponentType)Enum.Parse(typeof(ComponentType), temp);
                }
                return (ComponentType)Enum.Parse(typeof(ComponentType), componentType);
            }
            catch (Exception ex)
            {
                return (ComponentType)Enum.Parse(typeof(ComponentType), componentType);
            }
        }

       
    }
}