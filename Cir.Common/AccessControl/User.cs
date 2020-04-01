using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.AccessControl {
	public class User {
		private string _initials;
		private PermissionLevel _permissions;
        private string _userName;
        private long _id;
		private Operations _operations;

        public User(long id, string initials, string userName, PermissionLevel permissions) {
			_id = id;
			_initials = initials;
			_userName = userName;
			_permissions = permissions;
			_operations = new Operations(this);
		}

		public Operations Operations {
			get {
				return this._operations;
			}
		}

		public long Id {
			get {
				return _id;
			}
		}

		public PermissionLevel Permissions {
			get {
				return _permissions;
			}
		}

		public string Initials {
			get {
				return _initials;
			}
		}

		public string UserName {
			get {
				return _userName;
			}
		}
	}
}
