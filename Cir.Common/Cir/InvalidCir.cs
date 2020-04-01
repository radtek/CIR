using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Cir.Common.Cir {
	public class InvalidCir {
		private XmlDocument _xml;
		private long _invalidCirId;
		private string _createdBy;
		private DateTime _created;
		private string _error;
		private string _filename;

		public InvalidCir(long invalidCirId, string filename, string createdBy, DateTime created, string error, XmlDocument xml) {
			this._invalidCirId = invalidCirId;
			this._filename = filename;
			this._createdBy = createdBy;
			this._created = created;
			this._error = error;
			this._xml = xml;
		}

		public XmlDocument Xml {
			get { return _xml; }
		}

		public long InvalidCirId {
			get { return _invalidCirId; }
		}

		public string Filename {
			get { return _filename; }
		}

		public string CreatedBy {
			get { return _createdBy; }
		}

		public DateTime Created {
			get { return _created; }
		}

		public string Error {
			get { return _error; }
		}
	}
}
