using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.Views {
	public class ViewQuickFilter : ICloneable {
        public ViewQuickFilter()
        { }
		public ViewQuickFilter(int id, string name, Guid columnId, string value) {
			Id = id;
			Name = name;
			ColumnId = columnId;
			Value = value;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public Guid ColumnId { get; set; }
		public string Value { get; set; }

		#region ICloneable Members

		public object Clone() {
			return this.MemberwiseClone();
		}

		#endregion
	}
}
