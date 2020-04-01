using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Cir.Common.Metadata {
	public class Template {
		private static Dictionary<Guid, TemplateField> _templateFields = null;
		private static object _templateFieldsLock = new object();

		public static Dictionary<Guid, TemplateField> TemplateFields {
			get {
				if (_templateFields == null) {
					lock (_templateFieldsLock) {
						// still not initialized?
						if (_templateFields == null) {
							GetTemplateFields();
						}
					}
				}
				return new Dictionary<Guid, TemplateField>(_templateFields);
			}
		}

		public static int GetFieldLookupId(Guid columnId) {
			if (columnId == MetadataItem.SystemFields.LookupSbu) {
				return -10;
			}
			if (TemplateFields.ContainsKey(columnId)) {
				return TemplateFields[columnId].FieldLookupId;
			}
			return -1;
		}

		public static bool IsNumericField(Guid columnId) {
			if (TemplateFields.ContainsKey(columnId)) {
				return TemplateFields[columnId].Numeric;
			}
			return false;
		}

		private static void GetTemplateFields() {
			_templateFields = new Dictionary<Guid, TemplateField>();

			var manifest = new XmlDocument();
			manifest.LoadXml(Resources.manifest);

			XmlNamespaceManager xmlns = new XmlNamespaceManager(manifest.NameTable);
			xmlns.AddNamespace("xsf", "http://schemas.microsoft.com/office/infopath/2003/solutionDefinition");

			foreach (XmlNode node in manifest.SelectNodes("//xsf:fields/xsf:field", xmlns)) {
				var columnId = new Guid(node.Attributes["columnName"].Value);
				_templateFields[columnId] = CreateTemplateField(
					node.Attributes["name"].Value,
					columnId,
					node.Attributes["node"].Value,
					(node.Attributes["type"].Value == "xsd:integer"),
					int.Parse(node.Attributes["fieldLookupId"].Value)
				);
			}

			// add system fields
			_templateFields[MetadataItem.SystemFields.Created] = CreateTemplateField("Created", MetadataItem.SystemFields.Created, string.Empty, false, -1);
			_templateFields[MetadataItem.SystemFields.CreatedBy] = CreateTemplateField("Created By", MetadataItem.SystemFields.CreatedBy, string.Empty, false, -1);
			_templateFields[MetadataItem.SystemFields.Modified] = CreateTemplateField("Modified", MetadataItem.SystemFields.Modified, string.Empty, false, -1);
			_templateFields[MetadataItem.SystemFields.ModifiedBy] = CreateTemplateField("Modified By", MetadataItem.SystemFields.ModifiedBy, string.Empty, false, -1);
			_templateFields[MetadataItem.SystemFields.Name] = CreateTemplateField("Name", MetadataItem.SystemFields.Name, string.Empty, false, -1);
		}

		private static TemplateField CreateTemplateField(string name, Guid columnId, string xpath, bool numeric, int lookupId) {
			return new TemplateField {
				Name = name,
				ColumnId = columnId,
				XPath = xpath,
				Numeric = numeric,
				FieldLookupId = lookupId
			};
		}

	}
}
