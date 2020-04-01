namespace Cir.Common.HotList {

	public class HotItem {
		private long _hotItemId;
		private long _componentInspectionReportTypeId;
		private string _vestasItemNumber;
		private string _vestasItemName;
		private string _manufacturerName;
		private long _languageId;
		private long _sort;
		private string _email;
		private string _cc;
		private string _hotItemDisplay;

		public HotItem(long hotItemId, long componentInspectionReportTypeId, string vestasItemNumber, string vestasItemName, string manufacturerName, long languageId, long sort, string email, string cc, string hotItemDisplay) {
			_hotItemId = hotItemId;
			_componentInspectionReportTypeId = componentInspectionReportTypeId;
			_vestasItemNumber = vestasItemNumber;
			_vestasItemName = vestasItemName;
			_manufacturerName = manufacturerName;
			_languageId = languageId;
			_sort = sort;
			_email = email;
			_cc = cc;
			_hotItemDisplay = hotItemDisplay;
		}

		public HotItem(long hotItemId, long componentInspectionReportTypeId, string vestasItemNumber, string vestasItemName, string manufacturerName, string email, string cc, string hotItemDisplay) {
			_hotItemId = hotItemId;
			_componentInspectionReportTypeId = componentInspectionReportTypeId;
			_vestasItemNumber = vestasItemNumber;
			_vestasItemName = vestasItemName;
			_manufacturerName = manufacturerName;
			_email = email;
			_cc = cc;
			_hotItemDisplay = hotItemDisplay;
		}

		public long HotItemId {
			get { return _hotItemId; }
			set { _hotItemId = value; }
		}

		public long ComponentInspectionReportTypeId {
			get { return _componentInspectionReportTypeId; }
			set { _componentInspectionReportTypeId = value; }
		}

		public string VestasItemNumber {
			get { return _vestasItemNumber; }
			set { _vestasItemNumber = value; }
		}

		public string VestasItemName {
			get { return _vestasItemName; }
			set { _vestasItemName = value; }
		}

		public string ManufacturerName {
			get { return _manufacturerName; }
			set { _manufacturerName = value; }
		}

		public long LanguageId {
			get { return _languageId; }
			set { _languageId = value; }
		}

		public long Sort {
			get { return _sort; }
			set { _sort = value; }
		}

		public string Email {
			get { return _email; }
			set { _email = value; }
		}

		public string Cc {
			get { return _cc; }
			set { _cc = value; }
		}

		public string HotItemDisplay {
			get { return _hotItemDisplay; }
			set { _hotItemDisplay = value; }
		}

	}
}
