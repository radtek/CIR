using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Cir.Common.Metadata;

namespace Cir.Common.Cir {
	public class CirData {
		private XmlDocument _xml;
		private Guid _uniqueId;
		private long _cirDataId;
		private long _cirId;
		private State _state;
		private Progress _progress;
		private string _email;
		private string _filename;
		private string _createdBy;
		private DateTime _created;
		private string _modifiedBy;
		private DateTime _modified;

        public CirData(
				long cirDataId,
				Guid uniqueId,
				long cirId,
				XmlDocument xml,
				State state,
				Progress progress,
				string email,
				string filename,
				string createdBy,
				DateTime created,
				string modifiedBy,
				DateTime modified
			) {
			this._cirDataId = cirDataId;
			this._uniqueId = uniqueId;
			this._cirId = cirId;
			this._xml = xml;
			this._state = state;
			this._progress = progress;
			this._email = email;
			this._filename = filename;
			this._createdBy = createdBy;
			this._created = created;
			this._modifiedBy = modifiedBy;
			this._modified = modified;
		}

		public long CirDataId {
			get {
				return _cirDataId;
			}
		}
		public long CirId {
			get {
				return _cirId;
			}
		}
		public DateTime Created {
			get {
				return _created;
			}
		}
		public string CreatedBy {
			get {
				return _createdBy;
			}
		}
		public string Email {
			get {
				return _email;
			}
		}
		public string Filename {
			get {
				return _filename;
			}
		}
		public DateTime Modified {
			get {
				return _modified;
			}
		}
		public string ModifiedBy {
			get {
				return _modifiedBy;
			}
			set {
				_modifiedBy = value;
			}
		}
		public Progress Progress {
			get {
				return _progress;
			}
		}
		public State State {
			get {
				return _state;
			}
		}
		public Guid UniqueId {
			get {
				return _uniqueId;
			}
		}
		public XmlDocument Xml {
			get {
				return _xml;
			}
			set {
				_xml = value;
			}
		}
	}
}
