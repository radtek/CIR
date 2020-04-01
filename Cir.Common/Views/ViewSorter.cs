using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.Views {
	public class ViewSorter : ICloneable {
		public Guid Field;
		public bool Ascending;

		#region ICloneable Members

		public object Clone() {
			return this.MemberwiseClone();
		}

		#endregion
	}
}
