using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.EntityClasses;

namespace Cir.Data.Surveillance {
	public class DataLayer : BaseDataLayer {
		public DataLayer(string connectionString)
			: base(connectionString) {
		}

		public void RecordSurveillanceTime() {
			var entity = CirInboxTimestamp;
			using (var daa = GetDataAccessAdapter()) {
				daa.FetchEntity(entity);
				entity.Timestamp = DateTime.Now;
				entity.MailSent = 0;
				daa.SaveEntity(entity);
			}
		}

		public void RecordSurveillanceMailSent() {
			var entity = CirInboxTimestamp;
			using (var daa = GetDataAccessAdapter()) {
				daa.FetchEntity(entity);
				entity.MailSent = 1;
				daa.SaveEntity(entity);
			}
		}

		public DateTime LastSurveillanceMailRecieved(out bool mailSent) {
			var returnValue = DateTime.MinValue;
			var entity = CirInboxTimestamp;
			using (var daa = GetDataAccessAdapter()) {
				daa.FetchEntity(entity);
				mailSent = (entity.MailSent == 1);
				returnValue = entity.Timestamp;
			}
			return returnValue;
		}

		public bool NotificationWarningPreviouslySent() {
			var entity = CirSystemMonitor;
			using (var daa = GetDataAccessAdapter()) {
				daa.FetchEntity(entity);
			}
			return entity.NotificationWarningSent;
		}

		public void RecordNotificationWarningSent(bool sent) {
			var entity = CirSystemMonitor;
			using (var daa = GetDataAccessAdapter()) {
				daa.FetchEntity(entity);
				entity.LastUpdate = DateTime.Now;
				entity.NotificationWarningSent = sent;
				daa.SaveEntity(entity);
			}			
		}

		public DateTime GetLastWatchDogTimeStamp() {
			var entity = CirSystemMonitor;
			using (var daa = GetDataAccessAdapter()) {
				daa.FetchEntity(entity);
				return entity.LastUpdate;
			}
		}

		public void RecordWatchDogWarningSent(bool sent) {
			var entity = CirSystemMonitor;
			using (var daa = GetDataAccessAdapter()) {
				daa.FetchEntity(entity);
				entity.WatchDogWarningSent = sent;
				daa.SaveEntity(entity);
			}
		}

		public bool WatchDogWarningPreviouslySent() {
			var entity = CirSystemMonitor;
			using (var daa = GetDataAccessAdapter()) {
				daa.FetchEntity(entity);
			}
			return entity.WatchDogWarningSent;
		}

		private static CirSystemMonitorEntity CirSystemMonitor {
			get {
				return new CirSystemMonitorEntity(1);
			}
		}

		private static CirinboxTimestampEntity CirInboxTimestamp {
			get {
				return new CirinboxTimestampEntity(1);
			}
		}
	}
}
