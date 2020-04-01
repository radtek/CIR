using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.Manufacturers {
	public abstract class Manufacturer {
		private long _manufacturerId;
		private readonly string _name;
		private string _contactName;
		private string _email;
		private string _cc;

		public Manufacturer(long manufacturerId, string name, string email, string cc, string contactName) {
			_manufacturerId = manufacturerId;
			_contactName = contactName;
			_name = name;
			_email = email;
			_cc = cc;
		}

		public string Name {
			get { return _name; }
		}

		public long ManufacturerId {
			get { return _manufacturerId; }
		}

		public string Email {
			get { return _email; }
			set { _email = value; }
		}

		public string Cc {
			get { return _cc; }
			set { _cc = value; }
		}

		public string ContactName {
			get { return _contactName; }
			set { _contactName = value; }
		}
	}
}
