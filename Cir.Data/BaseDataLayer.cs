using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Cir.Data.LLBLGen.DatabaseSpecific;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data {
	public abstract class BaseDataLayer {
		private string _connectionString = String.Empty;

		public BaseDataLayer(string connectionString) {
			_connectionString = connectionString;
		}

		public string ConnectionString {
			get {
				return _connectionString;
			}
		}

		protected DataAccessAdapter GetDataAccessAdapter() {
			return new DataAccessAdapter(ConnectionString, false);
		}

		protected void AddParameter(SqlCommand cmd, string parameterName, object parameterValue, SqlDbType type) {
			var param = new SqlParameter();
			param.ParameterName = "@" + parameterName;
			param.Value = parameterValue;
			param.SqlDbType = type;
			cmd.Parameters.Add(param);
		}

		protected string SafeString(string message, IEntityField2 field) {
			return message.Substring(0, (message.Length >= field.MaxLength ? field.MaxLength - 1 : message.Length));
		}
	}
}
