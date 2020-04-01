using System;
using System.Collections.Generic;
using Cir.Common.Manufacturers;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.HelperClasses;

namespace Cir.Data.Manufacturers {
	public class DataLayer : BaseDataLayer {
		public DataLayer(string connectionString)
			: base(connectionString) {
		}

		public List<BladeManufacturer> GetBladeManufacturers() {
			using (var daa = GetDataAccessAdapter()) {
				var resultList = new List<BladeManufacturer>();
				var ec = new EntityCollection<BladeManufacturerEntity>();

				daa.FetchEntityCollection(ec, null);

				foreach (var entity in ec) {
					resultList.Add(new BladeManufacturer(entity.BladeManufacturerId, entity.Name, entity.Email, entity.Cc, entity.EmailContactName));
				}
				return resultList;
			}
		}

		public List<GeneratorManufacturer> GetGeneratorManufacturers() {
			using (var daa = GetDataAccessAdapter()) {
				var resultList = new List<GeneratorManufacturer>();
				var ec = new EntityCollection<GeneratorManufacturerEntity>();

				daa.FetchEntityCollection(ec, null);

				foreach (var entity in ec) {
					resultList.Add(new GeneratorManufacturer(entity.GeneratorManufacturerId, entity.Name, entity.Email, entity.Cc, entity.EmailContactName));
				}
				return resultList;
			}
		}

		public List<GearboxManufacturer> GetGearboxManufacturers() {
			using (var daa = GetDataAccessAdapter()) {
				var resultList = new List<GearboxManufacturer>();
				var ec = new EntityCollection<GearboxManufacturerEntity>();

				daa.FetchEntityCollection(ec, null);

				foreach (var entity in ec) {
					resultList.Add(new GearboxManufacturer(entity.GearboxManufacturerId, entity.Name, entity.Email, entity.Cc, entity.EmailContactName));
				}
				return resultList;
			}
		}

		public List<TransformerManufacturer> GetTransformerManufacturers() {
			using (var daa = GetDataAccessAdapter()) {
				var resultList = new List<TransformerManufacturer>();
				var ec = new EntityCollection<TransformerManufacturerEntity>();

				daa.FetchEntityCollection(ec, null);

				foreach (var entity in ec) {
					resultList.Add(new TransformerManufacturer(entity.TransformerManufacturerId, entity.Name, entity.Email, entity.Cc, entity.EmailContactName));
				}
				return resultList;
			}
		}

		public void UpdateBladeManufacturer(BladeManufacturer manufacturer) {
			using (var daa = GetDataAccessAdapter()) {
				var entity = new BladeManufacturerEntity(manufacturer.ManufacturerId);
				if (daa.FetchEntity(entity)) {
					entity.Email = manufacturer.Email;
					entity.Cc = manufacturer.Cc;
					entity.EmailContactName = manufacturer.ContactName;
					daa.SaveEntity(entity, false);
				}
			}
		}

		public void UpdateGeneratorManufacturer(GeneratorManufacturer manufacturer) {
			using (var daa = GetDataAccessAdapter()) {
				var entity = new GeneratorManufacturerEntity(manufacturer.ManufacturerId);
				if (daa.FetchEntity(entity)) {
					entity.Email = manufacturer.Email;
					entity.Cc = manufacturer.Cc;
					entity.EmailContactName = manufacturer.ContactName;
					daa.SaveEntity(entity, false);
				}
			}
		}

		public void UpdateGearboxManufacturer(GearboxManufacturer manufacturer) {
			using (var daa = GetDataAccessAdapter()) {
				var entity = new GearboxManufacturerEntity(manufacturer.ManufacturerId);
				if (daa.FetchEntity(entity)) {
					entity.Email = manufacturer.Email;
					entity.Cc = manufacturer.Cc;
					entity.EmailContactName = manufacturer.ContactName;
					daa.SaveEntity(entity, false);
				}
			}
		}

		public void UpdateTransformerManufacturer(TransformerManufacturer manufacturer) {
			using (var daa = GetDataAccessAdapter()) {
				var entity = new TransformerManufacturerEntity(manufacturer.ManufacturerId);
				if (daa.FetchEntity(entity)) {
					entity.Email = manufacturer.Email;
					entity.Cc = manufacturer.Cc;
					entity.EmailContactName = manufacturer.ContactName;
					daa.SaveEntity(entity, false);
				}
			}
		}
	}
}
