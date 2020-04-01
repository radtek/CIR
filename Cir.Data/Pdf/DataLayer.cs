using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Common.Cir;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.FactoryClasses;

namespace Cir.Data.Pdf {
	public class DataLayer : BaseDataLayer {
		public DataLayer(string connectionString)
		: base(connectionString) {
		}
		public void UpdateState(Guid uniqueId, State fromState, State toState) {
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				try {
					var entity = FetchPdfEntity(uniqueId, fromState, daa);
					if (entity != null) {
						// delete any existing PDF in the target state
						DeletePdfEntity(uniqueId, toState, daa);
						entity.Cirstate = (int)toState;
						daa.SaveEntity(entity);
					}
				}
				finally {
					daa.CloseConnection();
				}
			}
		}

		public byte [] Get(Guid uniqueId, State state) {
			byte[] pdfFile = null;

			// get PDF from database 
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				// fetch existing entity if it exists
				PdfEntity entity = FetchPdfEntity(uniqueId, state, daa);

				if (entity != null) {
					pdfFile = entity.Pdfdata;
				}
			}

			return pdfFile;
		}

		public void Save(Guid uniqueId, State state, string filename, byte[] pdfFile) {
			// save PDF to database (update existing if applicable)
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				// fetch existing entity if it exists
				PdfEntity entity = FetchPdfEntity(uniqueId, state, daa);
				if (entity == null) {
					entity = new PdfEntity();
					entity.Cirstate = (int)state;
					entity.CirtemplateGuid = uniqueId.ToString();
				}

				entity.Cirname = filename;

				// update pdf file data
				entity.Pdfdata = pdfFile;

				// save
				daa.SaveEntity(entity);
			}
		}

        private static PdfEntity FetchPdfEntity(Guid uniqueId, State state, DataAccessAdapter daa) {
			IRelationPredicateBucket fb = new RelationPredicateBucket();
			fb.PredicateExpression.Add(PdfFields.CirtemplateGuid == uniqueId.ToString());
			fb.PredicateExpression.Add(PdfFields.Cirstate == (int)state);

			EntityCollection<PdfEntity> ec = new EntityCollection<PdfEntity>(new PdfEntityFactory());

			daa.FetchEntityCollection(ec, fb);

			if ((ec.Count == 1)) {
				return ec[0];
			}

			return null;
		}

		private void DeletePdfEntity(Guid uniqueId, State state, DataAccessAdapter daa) {
			// delete any old entries in the target state
			IRelationPredicateBucket fb = new RelationPredicateBucket();
			fb.PredicateExpression.Add(PdfFields.CirtemplateGuid == uniqueId.ToString());
			fb.PredicateExpression.Add(PdfFields.Cirstate == (int)state);
			daa.DeleteEntitiesDirectly(typeof(PdfEntity), fb);
		}
	}
}
