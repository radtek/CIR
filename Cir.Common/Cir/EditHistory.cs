using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.Cir {
	public class EditHistory {
		public string ReasonForChange { get; private set; }
		public string Initials { get; private set; }
		public DateTime EditDate { get; private set; }

		public EditHistory(string initials, DateTime editDate, string reasonForChange) {
			Initials = initials;
			EditDate = editDate;
			ReasonForChange = reasonForChange;
		}
	}
}
