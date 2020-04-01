using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Common.Utilities;

namespace Cir.Common.Notification
{
    [Serializable]
    public class Notification
    {
        private long _cirId;
        private string _notificationType;
        private string _componentType;
        private string _manufacturer;
        private string _serialNumber;
        private string _turbineId;
        private string _cimCaseNumber;
        private string _commissioningDate;
        private string _InstallationDate;
        private string _sentOn;
        private string _sentTo;
        
        public Notification()
        {
        }

        public Notification(long cirId, string notificationType, string componentType, string manufacturer, string serialNumber, string turbineId, string cimCaseNumber, string commissioningDate, string installationDate, string sentOn, string sentTo) {
            _cirId = cirId;
            _notificationType = notificationType;
            _componentType = componentType;
            _manufacturer = manufacturer;
            _serialNumber = serialNumber;
            _turbineId = turbineId;
            _cimCaseNumber = cimCaseNumber;
            _commissioningDate = commissioningDate;
            _InstallationDate = installationDate;
            _sentOn = sentOn;
            _sentTo = sentTo;
            }
        
        public long CirId
        {
            get { return _cirId; }
        }

        public string NotificationType
        {
            get { return _notificationType; }
        }

        public string ComponentType
        {
            get { return _componentType; }
        }

        public string Manufacturer
        {
            get { return _manufacturer; }
        }

        public string SerialNumber
        {
            get { return _serialNumber; }
        }

        public string TurbineId
        {
            get { return _turbineId; }
        }

        public string CimCaseNumber
        {
            get { return _cimCaseNumber; }
        }

        public string CommissioningDate
        {
            get { return _commissioningDate; }
        }

        public string InstallationDate
        {
            get { return _InstallationDate; }
        }

        public string SentOn
        {
            get { return _sentOn; }
        }

        public string SentTo
        {
            get { return _sentTo; }
        }

    }
}
