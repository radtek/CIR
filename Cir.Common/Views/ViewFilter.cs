using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Common.Metadata;

namespace Cir.Common.Views {
	public class ViewFilter : ICloneable {
		public enum MatchType {
			Equal = 1,
			NotEqual,
			In,
			NotIn,
			Contains
		}

		public List<ViewFilterItem> FilterItems = new List<ViewFilterItem>();
		public bool MatchAll;

		public bool Match(MetadataItem item) {
			if (FilterItems.Count == 0) {
				return true;
			}
			bool match = false;
			foreach (var filter in FilterItems) {
				if (item.FieldValues[filter.ColumnId] != null) {
					if (filter.Match == ViewFilter.MatchType.In ||
						filter.Match == ViewFilter.MatchType.NotIn) {
						bool equal = string.Format(",{0},", filter.Value).Contains(string.Format(",{0},", item.FieldValues[filter.ColumnId]));
						match = (equal == (filter.Match == MatchType.In));
					}
					else if(filter.Match == ViewFilter.MatchType.Contains) {
						match = (item.FieldValues[filter.ColumnId].IndexOf(filter.Value, StringComparison.InvariantCultureIgnoreCase) != -1);
					}
					else {
						bool equal = (item.FieldValues[filter.ColumnId].Equals(filter.Value, StringComparison.InvariantCultureIgnoreCase));
						match = (equal == (filter.Match == MatchType.Equal));
					}

					// break early
					if (MatchAll && !match) {
						// match all + no match found
						break;
					}
					if (!MatchAll && match) {
						// match any + match found
						break;
					}
				}
				else {
					match = false;
				}
			}

			return match;
		}

		#region ICloneable Members

		public object Clone() {
			var clone = this.MemberwiseClone() as ViewFilter;
			clone.FilterItems = new List<ViewFilterItem>();
			foreach (var filterItem in this.FilterItems) {
				clone.FilterItems.Add(filterItem.Clone() as ViewFilterItem);
			}
			return clone;
		}

		#endregion
	}

}
