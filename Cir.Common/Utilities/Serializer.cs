using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Cir.Common.Utilities {
	public class Serializer {
		private static Dictionary<Type, XmlSerializer> _serializers = new Dictionary<Type,XmlSerializer>();
		private static object _serializersLock = new object();

		public static T FromXml<T>(string input) where T : class {
			XmlSerializer serializer = GetSerializer<T>();

			StringReader textReader = new StringReader(input);
			T result = serializer.Deserialize(textReader) as T;
			textReader.Close();

			return result;
		}

		public static string ToXml<T>(T item) where T : class {
			XmlSerializer serializer = GetSerializer<T>();

			StringBuilder output = new StringBuilder();

			StringWriter stringWriter = new StringWriter(output);
			serializer.Serialize(stringWriter, item);
			stringWriter.Close();

			return output.ToString();
		}

		private static XmlSerializer GetSerializer<T>() where T : class {
			XmlSerializer serializer;
			lock (_serializersLock) {
				if (_serializers.ContainsKey(typeof(T))) {
					serializer = _serializers[typeof(T)];
				}
				else {
					serializer = new XmlSerializer(typeof(T));
					_serializers[typeof(T)] = serializer;
				}
			}
			return serializer;
		}

		public static T FromBinary<T>(byte[] bytes) where T : class {
			var stream = new MemoryStream(bytes);
			var formatter = new BinaryFormatter();
			return formatter.Deserialize(stream) as T;
		}

		public static byte[] ToBinary<T>(T item) where T : class {
			var formatter = new BinaryFormatter();
			var stream = new MemoryStream();
			formatter.Serialize(stream, item);
			return stream.ToArray();
		}

		public static T FromBase64<T>(string base64) where T : class {
			var bytes = Convert.FromBase64String(base64);

			var stream = new MemoryStream(bytes);
			var formatter = new BinaryFormatter();
			return formatter.Deserialize(stream) as T;
		}

		public static string ToBase64<T>(T item) where T : class {
			var formatter = new BinaryFormatter();
			var stream = new MemoryStream();
			formatter.Serialize(stream, item);
			return Convert.ToBase64String(stream.ToArray());
		}
	}
}
