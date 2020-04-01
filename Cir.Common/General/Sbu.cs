using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.General {
	public class Sbu {
		public readonly string Name;
		public readonly string ShortName;
		public readonly long SbuId;

		private List<long> _countryIsoIds;

		public Sbu(long sbuId, string name, string shortName, IEnumerable<long> countryIsoIds) {
			this.SbuId = sbuId;
			this.Name = name;
			this.ShortName = shortName;
			this._countryIsoIds = new List<long>(countryIsoIds);
		}

		public IEnumerable<long> CountryIsoIds {
			get {
				return _countryIsoIds;
			}
		}
	}
}
