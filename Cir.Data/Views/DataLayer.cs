using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Common.Views;
using System.Data.SqlClient;
using Cir.Common.Utilities;
using System.Data;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data.Views {
	public class DataLayer : BaseDataLayer {
		private List<View> _allViews = null;

		public DataLayer(string connectionString)
			: base(connectionString) {
		}

		private List<View> AllViews {
			get {
				if (_allViews == null) {
					using (var daa = GetDataAccessAdapter()) {
						var ec = new EntityCollection<CirViewEntity>();
						daa.FetchEntityCollection(ec, null);

						_allViews = new List<View>(from e in ec select CreateView(e));
					}					
				}
				return _allViews;
			}
		}

		//public IEnumerable<View> GetViews() {
		//    var views = new List<View>();

		//    var conn = new SqlConnection(ConnectionString);
		//    conn.Open();

		//    var cmd = new SqlCommand();
		//    cmd.Connection = conn;
		//    cmd.CommandText = "SELECT CirViewId, ViewData, Created, CreatedBy, Type FROM CirView";

		//    var reader = cmd.ExecuteReader();
		//    while (reader.Read()) {
		//        var v = Serializer.FromXml<View>(reader.GetString(reader.GetOrdinal("ViewData")));
		//        v.ViewId = reader.GetInt32(reader.GetOrdinal("CirViewId"));
		//        v.Type = (View.ViewType)reader.GetInt16(reader.GetOrdinal("Type"));
		//        v.Created = reader.GetDateTime(reader.GetOrdinal("Created"));
		//        v.CreatedBy = reader.GetString(reader.GetOrdinal("CreatedBy"));
		//        views.Add(v);
		//    }

		//    reader.Close();
		//    conn.Close();

		//    return views;
		//}

		public IEnumerable<View> GetViews() {
			return AllViews;
			//IEnumerable<View> views = null;

			//using (var daa = GetDataAccessAdapter()) {
			//    var ec = new EntityCollection<CirViewEntity>();
			//    //var excludedFields = new ExcludeIncludeFieldsList();
			//    //excludedFields.Add(CirViewFields.ViewData);
			//    //daa.FetchEntityCollection(ec, excludedFields, null);
			//    daa.FetchEntityCollection(ec, null);

			//    views = from e in ec select CreateView(e);
			//}

			//return views;
		}

		public View GetView(int viewId) {
			return AllViews.FirstOrDefault(v => v.ViewId == viewId);
			//View view = null;
			//using (var daa = GetDataAccessAdapter()) {
			//    var entity = new CirViewEntity();
			//    entity.CirViewId = viewId;
			//    if (daa.FetchEntity(entity)) {
			//        view = CreateView(entity);
			//    }
			//}
			//return view;
		}

		private View CreateView(CirViewEntity entity) {
			if(entity == null) {
				return null;
			}
			View view;
			if (string.IsNullOrEmpty(entity.ViewData)) {
				view = new View();
			}
			else {
				view = Serializer.FromXml<View>(entity.ViewData);				
			}
			view.ViewId = entity.CirViewId;
			view.Type = (View.ViewType) entity.Type;
			view.Created = entity.Created;
			view.CreatedBy = entity.CreatedBy;
            view.InspectionApplicable = entity.InspectionApplicable;
			return view;
		}

		public int AddView(View view, string createdBy) {
			int returnValue = -1;
			using (var daa = GetDataAccessAdapter()) {
				CirViewEntity entity = new CirViewEntity();
			
				if (view.ViewId > 0) {
					entity.CirViewId = view.ViewId;
					daa.FetchEntity(entity);
				}
				entity.Created = DateTime.Now;
				entity.CreatedBy = createdBy;
				entity.Type = (short)view.Type;
                entity.InspectionApplicable = view.InspectionApplicable;

				entity.ViewData = Serializer.ToXml<View>(view);
				daa.SaveEntity(entity, true);

				returnValue = entity.CirViewId;
			}
			return returnValue;
		}

		public bool DeleteView(int viewId) {
			bool returnValue = false;
			using (var daa = GetDataAccessAdapter()) {
				CirViewEntity entity = new CirViewEntity();
				entity.CirViewId = viewId;
				returnValue = daa.DeleteEntity(entity);
			}
			return returnValue;
		}
	}
}
