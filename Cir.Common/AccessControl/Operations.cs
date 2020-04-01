using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Common.AccessControl;

namespace Cir.Common.AccessControl {
	public class Operations {
		private User _user;

		public Operations(User user) {
			this._user = user;
		}

		public bool CreateUser {
			get {
				return HasPermissions(PermissionLevel.Administrator);
			}
		}

		public bool EditUser {
			get {
				// for now, Edit and Create user requires same priviledges
				return CreateUser;
			}
		}

		public bool CreateView {
			get {
				// creating views requires viewer priviledges (viewers should create private views only)
				return HasPermissions(PermissionLevel.Viewer);
			}
		}

		public bool EditPublicView {
			get {
				// editing public views requires editor priviledges
				return HasPermissions(PermissionLevel.Editor);
			}
		}

		public bool EditSystemView {
			get {
				// editing system views requires administrative rights
				return HasPermissions(PermissionLevel.Administrator);
			}
		}

		public bool EditCir {
			get {
				return HasPermissions(PermissionLevel.Editor);
			}
		}

		public bool ApproveCir {
			get {
				return HasPermissions(PermissionLevel.Member);
			}
		}

		public bool RejectCir {
			get {
				// for now, reject and approve CIR requires same priviledges
				return ApproveCir;
			}
		}

		public bool DeleteCir {
			get {
				// for now, deleting a CIR requires same priviledges as approve/reject
				return ApproveCir;
			}
		}

		public bool RejectApprovedCir {
			get {
				// for now, reject approved CIR and approve CIR requires same priviledges
				return ApproveCir;
			}
		}

		public bool AddRemoveAttachment {
			get {
				return HasPermissions(PermissionLevel.Editor);
			}
		}

		public bool AdministerHotItems {
			get {
				return HasPermissions(PermissionLevel.Member);
			}
		}

		public bool AdministerManufacturers {
			get {
				return HasPermissions(PermissionLevel.Administrator);
			}
		}

		public bool DownloadOldCirVersions {
			get {
				return HasPermissions(PermissionLevel.Editor);
			}
		}

		public bool DownloadEmailsFromArchive {
			get {
				return HasPermissions(PermissionLevel.Administrator);
			}
		}

		private bool HasPermissions(PermissionLevel level) {
			return this.Permissions >= level;
		}

		private PermissionLevel Permissions {
			get {
				return this._user.Permissions;
			}
		}

	}
}
