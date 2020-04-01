using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.Attachments {
	public class Attachment {
		private string _filename;
		private string _createdBy;
		private DateTime _created;
		private long _cirId;
		private long _cirAttachmentId;
		private byte[] _binaryData;

		public Attachment(long cirAttachmentId, long cirId, string fileName, string createdBy, DateTime created, byte[] binaryData) {
			_cirAttachmentId = cirAttachmentId;
			_cirId = cirId;
			_filename = fileName;
			_createdBy = createdBy;
			_created = created;
			_binaryData = binaryData;
		}

		public string Filename {
			get {
				return _filename;
			}
		}
		public string CreatedBy {
			get {
				return _createdBy;
			}
		}
		public DateTime Created {
			get {
				return _created;
			}
		}
		public long CirId {
			get {
				return _cirId;
			}
		}
		public long CirAttachmentId {
			get {
				return _cirAttachmentId;
			}
		}
		public byte[] BinaryData {
			get {
				return _binaryData;
			}
		}
	}
}
