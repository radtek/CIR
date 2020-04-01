using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.MailArchive {
	public enum MailType {
		None = 1,
		FirstNotification = 2,
		SecondNotification = 3,
		FirstNotificationReceipt = 4,
		SecondNotificationReceipt = 5,
        RejectNotification = 6,
        SBUNotification = 7,
    }

	public class MailArchiveData {
		private long _mailArchiveDataId;
		private string _mail;
		private long _cirDataId;
		private MailType _type;
		private DateTime _date;

		public MailArchiveData(long mailArchiveDataId, string mail, long cirDataId, MailType type, DateTime date) {
			_mail = mail;
			_date = date;
			_mailArchiveDataId = mailArchiveDataId;
			_cirDataId = cirDataId;
			_type = type;
		}

		public DateTime Date {
			get { return _date; }
		}

		public long MailArchiveDataId {
			get { return _mailArchiveDataId; }
		}

		public string Mail {
			get { return _mail; }
		}

		public long CirDataId {
			get { return _cirDataId; }
		}

		public MailType Type {
			get { return _type; }
		}
	}
}
