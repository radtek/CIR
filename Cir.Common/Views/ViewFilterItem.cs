using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.Views {
	public class ViewFilterItem : ICloneable {
		//public bool Negate;
		public Guid ColumnId;
		public string Value;
		public ViewFilter.MatchType Match = ViewFilter.MatchType.Equal;

		#region ICloneable Members

		public object Clone() {
			return this.MemberwiseClone();
		}

		#endregion
	}
}
