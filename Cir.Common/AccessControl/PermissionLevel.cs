using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.AccessControl {
	public enum PermissionLevel {
		Visitor = -1,
		Viewer = 0,
		Editor = 1,
		Member = 2,
		Owner = 3,
        BIRCreator = 4,
		Administrator = 5        
	}
}
