using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using System.Collections;
using Cir.Common.Cir;
using Cir.Common.Localization;

namespace Cir.Common.Metadata {
	[Serializable]
	public class MetadataItem : ICloneable, ISerializable {
		#region System field Ids

		public static class SystemFields {
			public static readonly Guid Created = new Guid("{66CF0F92-D551-459e-8D65-FB5913F7A928}");

			public static readonly Guid CreatedBy = new Guid("{16FD30FF-FE69-40da-AF18-CC926FD9E9DE}");

			public static readonly Guid Modified = new Guid("{4A2AE87B-FD08-4ce5-98D7-278662A9B1F6}");

			public static readonly Guid ModifiedBy = new Guid("{9D6FADAB-003E-468c-824A-4B94622E4BDF}");

			public static readonly Guid Name = new Guid("{F75F91E1-0482-424f-8BF8-02FDC7525306}");

			public static readonly Guid CirId = new Guid("{6F5DD618-1EEE-41CD-A435-9957FFD25AFC}");

			public static readonly Guid CimCaseNumber = new Guid("{6C480CDB-C3CE-43C0-B2A2-EAA005ECCDFE}");

			public static readonly Guid TurbineId = new Guid("{1E67ECAC-06C3-4A6F-99ED-F1B5CAF2C54B}");

			public static readonly Guid LookupSbu = new Guid("37269D45-97B6-4B54-ABFB-6FC94BD1A5EC");
		}

		#endregion

		public MetadataItem() {

		}

		#region ISerializable members

		protected MetadataItem(SerializationInfo info, StreamingContext context) {
			_x_FieldValues = info.GetValue("_x_FieldValues", typeof(DictionaryEntry[])) as DictionaryEntry[];
			_x_FieldIntegerValues = info.GetValue("_x_FieldIntegerValues", typeof(DictionaryEntry[])) as DictionaryEntry[];
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("_x_FieldValues", _x_FieldValues);
			info.AddValue("_x_FieldIntegerValues", _x_FieldIntegerValues);
		}

		#endregion

		[XmlIgnore]
		public SafeDictionary<string> FieldValues = new SafeDictionary<string>();

		[XmlIgnore]
		public SafeDictionary<int> FieldIntegerValues = new SafeDictionary<int>();

		[XmlIgnore]
		public State State = State.Initial;

		[XmlIgnore]
		public Progress Progress = Progress.Done;

		[XmlIgnore]
		public bool Deleted = false;

		[XmlIgnore]
		public long CirDataId;

        [XmlIgnore]
        public long BirDataId;

        [XmlIgnore]
        public int RevisionNumber;

        [XmlIgnore]
        public string Site;

		[XmlIgnore]
		private DateTime _created = DateTime.MinValue;

		[XmlIgnore]
		public DateTime Created {
			get {
				return _created;
			}
			set {
				_created = value;
				FieldValues[SystemFields.Created] = _created.ToString(DateTimeFormatting.Default);
			}
		}

		[XmlIgnore]
		public string CreatedBy {
			get {
				return FieldValues[SystemFields.CreatedBy];
			}
			set {
				FieldValues[SystemFields.CreatedBy] = value;
			}
		}


		[XmlIgnore]
		private DateTime _modified = DateTime.MinValue;

		[XmlIgnore]
		public DateTime Modified {
			get {
				return _modified;
			}
			set {
				_modified = value;
				FieldValues[SystemFields.Modified] = _modified.ToString(DateTimeFormatting.Default);
			}
		}

		[XmlIgnore]
		public string ModifiedBy {
			get {
				return FieldValues[SystemFields.ModifiedBy];
			}
			set {
				FieldValues[SystemFields.ModifiedBy] = value;
			}
		}

		[XmlIgnore]
		public string Name {
			get {
				return FieldValues[SystemFields.Name];
			}
			set {
				FieldValues[SystemFields.Name] = value;
			}
		}

		[XmlIgnore]
		public long CirId {
			get {
				return (long)FieldIntegerValues[SystemFields.CirId];
			}
			set {
				FieldValues[SystemFields.CirId] = value.ToString();
			}
		}

		#region XML Serializer help

		// this region makes it possible to serialize and deserialize the FieldValues dictionaries

		[XmlArray("FieldValues")]
		[XmlArrayItem("FieldValuesLine", Type = typeof(DictionaryEntry))]
		public DictionaryEntry[] _x_FieldValues {
			get {
				return SerializableDictionary<string>(FieldValues);
			}
			set {
				FieldValues.Clear();
				for (int i = 0; i < value.Length; i++) {
					FieldValues.Add((Guid)value[i].Key, (string)value[i].Value);
				}
			}
		}

		[XmlArray("FieldIntegerValues")]
		[XmlArrayItem("FieldIntegerValuesLine", Type = typeof(DictionaryEntry))]
		public DictionaryEntry[] _x_FieldIntegerValues {
			get {
				return SerializableDictionary<int>(FieldIntegerValues);
			}
			set {
				FieldIntegerValues.Clear();
				for (int i = 0; i < value.Length; i++) {
					FieldIntegerValues.Add((Guid)value[i].Key, (int)value[i].Value);
				}
			}
		}

		private DictionaryEntry[] SerializableDictionary<T>(SafeDictionary<T> dictionary) {
			//Make an array of DictionaryEntries to return   
			DictionaryEntry[] ret = new DictionaryEntry[dictionary.Count];
			int i = 0;
			DictionaryEntry de;
			//Iterate through Stuff to load items into the array.   
			foreach (var kvp in dictionary) {
				de = new DictionaryEntry();
				de.Key = kvp.Key;
				de.Value = kvp.Value;
				ret[i] = de;
				i++;
			}
			return ret;
		}

		#endregion

		public object Clone() {
			var clone = this.MemberwiseClone() as MetadataItem;
			clone.FieldIntegerValues = new SafeDictionary<int>();
			foreach (var kvp in this.FieldIntegerValues) {
				clone.FieldIntegerValues.Add(kvp.Key, kvp.Value);
			}
			clone.FieldValues = new SafeDictionary<string>();
			foreach (var kvp in this.FieldValues) {
				clone.FieldValues.Add(kvp.Key, kvp.Value);
			}
			return clone;
		}

		/// <summary>
		/// We need this "safe" dictionary when indexing for not existing field UUIDs 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		public class SafeDictionary<T> : Dictionary<Guid, T> {
			public new T this[Guid key] {
				get {
					if(base.ContainsKey(key)) {
						return base[key];
					}
					return default(T);
				}
				set {
					base[key] = value;
				}
			}

			public SafeDictionary()
				: base() {
			}

			public SafeDictionary(IDictionary<Guid, T> dictionary)
				: base(dictionary) {
			}
		}
	}
}
