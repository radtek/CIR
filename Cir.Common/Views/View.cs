using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Cir.Common.Views {
	public class View : ICloneable {

		public enum ViewType {
			Public = 1,
			Private = 2,
			System = 3
		}

		public List<Guid> Fields;
		public ViewFilter Filter;

		[XmlIgnore] 
		public ViewQuickFilter QuickFilter = null;
		public int QuickFilterId = -1;

		public ViewSorter Sort;
		public int ResultsPerPage = 50;

		public string Name = "UNNAMED";

		[XmlIgnore]
		public int ViewId = -1;

		[XmlIgnore]
		public ViewType Type = ViewType.Public;

        [XmlIgnore]
        public bool InspectionApplicable = false;

		[XmlIgnore]
		public string CreatedBy = string.Empty;

		[XmlIgnore]
		public DateTime Created = DateTime.MinValue;

		#region ICloneable Members

		public object Clone() {
		    var clone = this.MemberwiseClone() as View;
			clone.Filter = this.Filter.Clone() as ViewFilter;
			clone.Sort = this.Sort.Clone() as ViewSorter;
			return clone;
		}

		#endregion
	}
}
