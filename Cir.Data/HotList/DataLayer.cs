using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Cir.Common.HotList;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data.HotList {

	public class DataLayer : BaseDataLayer {
		public DataLayer(string connectionString)
			: base(connectionString) {
		}

		public List<HotItem> GetHotItems() {
			using (var daa = GetDataAccessAdapter()) {
				var resultList = new List<HotItem>();
				var ec = new EntityCollection<HotItemEntity>(new HotItemEntityFactory());
				var fb = new RelationPredicateBucket();
				//fb.PredicateExpression.Add(HotItemFields.ManufacturerName != "");

				daa.FetchEntityCollection(ec, fb);

				foreach (var entity in ec) {
					HotItem item = CreateHotItem(entity);
					resultList.Add(item);
				}
				return resultList;
			}
		}

		public bool IsHotItemAdministrator(string initials) {
			using (var daa = GetDataAccessAdapter()) {
				var ec = new EntityCollection<HotItemAdministratorEntity>(new HotItemAdministratorEntityFactory());
				var fb = new RelationPredicateBucket();
				fb.PredicateExpression.Add(HotItemAdministratorFields.Initials == initials);

				daa.FetchEntityCollection(ec, fb, 1);

				return (ec.Count == 1);
			}
		}

        public HotItem GetHotItem(string vestasItemnumber)
        {
			HotItem item = null;
			using (var daa = GetDataAccessAdapter()) {
				var entity = GetHotItemEntity(0, daa, vestasItemnumber);
				if (entity != null) {
					item = CreateHotItem(entity);
				}
			}
			return item;
		}

      
		public List<KeyValuePair<int, string>> GetComponentInspectionReportTypes() {
			using (var daa = GetDataAccessAdapter()) {
				var kvpList = new List<KeyValuePair<int, string>>();
				var ec = new EntityCollection<ComponentInspectionReportTypeEntity>(new ComponentInspectionReportTypeEntityFactory());
				var fb = new RelationPredicateBucket();
				fb.PredicateExpression.Add(ComponentInspectionReportTypeFields.Name != "");

				daa.FetchEntityCollection(ec, fb);

				foreach (var entity in ec) {
					kvpList.Add(new KeyValuePair<int, string>((int)entity.ComponentInspectionReportTypeId, entity.Name));
				}
				return kvpList;
			}
		}


		public void DeleteHotItemById(long hotItemId) {
			using (var daa = GetDataAccessAdapter()) {
				var fb = new RelationPredicateBucket();
				fb.PredicateExpression.Add(HotItemFields.HotItemId == hotItemId);
				daa.DeleteEntitiesDirectly(typeof (HotItemEntity), fb);
				//var entity = GetHotItemEntity(hotItemId, daa);
				//if (entity != null) {
				//    daa.DeleteEntity(entity);
				//}
			}
		}

		public void UpdateHotItem(HotItem hotItem) {
			using (var daa = GetDataAccessAdapter()) {
				var entity = GetHotItemEntity(hotItem.HotItemId, daa);
				if (entity != null) {
					entity.ComponentInspectionReportTypeId = hotItem.ComponentInspectionReportTypeId;
					entity.VestasItemNumber = hotItem.VestasItemNumber;
					entity.VestasItemName = hotItem.VestasItemName;
					entity.ManufacturerName = hotItem.ManufacturerName;
					entity.Email = hotItem.Email;
					entity.Cc = hotItem.Cc;
					entity.HotItemDisplay = hotItem.HotItemDisplay;

					daa.SaveEntity(entity, false);
				}
			}
		}

		public void AddHotItem(HotItem hotItem) {
			using (var daa = GetDataAccessAdapter()) {
				var entity = new HotItemEntity {
					ComponentInspectionReportTypeId = hotItem.ComponentInspectionReportTypeId,
					VestasItemNumber = hotItem.VestasItemNumber,
					VestasItemName = hotItem.VestasItemName,
					ManufacturerName = hotItem.ManufacturerName,
					Email = hotItem.Email,
					Cc = hotItem.Cc,
					HotItemDisplay = hotItem.HotItemDisplay
				};

				daa.SaveEntity(entity, false);
			}
		}

		private static HotItem CreateHotItem(HotItemEntity entity) {
			var hotitem = new HotItem(entity.HotItemId, (long)entity.ComponentInspectionReportTypeId, entity.VestasItemNumber, entity.VestasItemName, entity.ManufacturerName, entity.Email, entity.Cc, entity.HotItemDisplay);
			return hotitem;
		}

        private static HotItemEntity GetHotItemEntity(long hotItemId, DataAccessAdapter daa, string itemNumber = null){
            //var entity = new HotItemEntity(hotItemId);

            //if(daa.FetchEntity(entity)) {
            //    return entity;
            //}
            //return null;
            var ec = new EntityCollection<HotItemEntity>(new HotItemEntityFactory());
            var fb = new RelationPredicateBucket();

            if (!string.IsNullOrEmpty(itemNumber)) {
                fb.PredicateExpression.Add(HotItemFields.VestasItemNumber == itemNumber);
            }
            else {
                fb.PredicateExpression.Add(HotItemFields.HotItemId == hotItemId);
            }
            //fb.PredicateExpression.Add(itemNumber != null ? HotItemFields.VestasItemNumber == itemNumber : HotItemFields.VestasItemNumber == hotItemId);

            daa.FetchEntityCollection(ec, fb);

            if (ec.Count == 1)
            {
                return ec[0];
            }
            return null;
		}
	}
}
