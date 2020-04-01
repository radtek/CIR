using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cir.Common.TurbineData {
	public class TurbineProperties {
		public long TurbineMatrixId = 0;
		public string Turbine = string.Empty;
		public byte Frequency = 0;
		public string Manufacturer = string.Empty;
		public string MarkVersion = string.Empty;
		public int NominelPower = 0;
		public long NominelPowerId = 0;
		public string Placement = string.Empty;
		public string PowerRegulation = string.Empty;
		public decimal RotorDiameter = 0;
		public int SmallGenerator = 0;
		public string TemperatureVariant = string.Empty;
		public int Voltage = 0;
		public int CountryIsoId = 0;
		public string Country = string.Empty;
		public string Site = string.Empty;
		public string LocalTurbineId = string.Empty;
	}
}
