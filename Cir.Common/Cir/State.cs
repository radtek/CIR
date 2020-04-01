using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.Cir {
	// NOTE! 
	// if changing these values, make sure the value of "Approved" corresponds 
	// with the value of "ApprovedState" in the legacy environment class
	public enum State {
		Initial = 1,
		Approved = 2,
		Rejected = 3,
//		Failed = 4
	}
}
