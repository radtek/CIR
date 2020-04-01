using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.Cir {
	public enum Progress {
		Done = 1,
		PendingApprove = 2,
		PendingReject = 3,
		PendingInitial = 4,
		ProcessError = 5,
		InitialError = 6,
		PendingDelete = 7
	}
}
