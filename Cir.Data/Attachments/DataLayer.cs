using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Common.Attachments;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Cir.Data.LLBLGen.FactoryClasses;

namespace Cir.Data.Attachments {
	public class DataLayer : BaseDataLayer {
		public DataLayer(string connectionString)
			: base(connectionString) {

		}

		public IEnumerable<Attachment> GetAttachments(long cirId) {
			var ec = new EntityCollection<CirAttachmentEntity>(new CirAttachmentEntityFactory());
			using (var daa = GetDataAccessAdapter()) {
				var fb = new RelationPredicateBucket();
				fb.PredicateExpression.Add(CirAttachmentFields.CirId == cirId);

				daa.FetchEntityCollection(ec, fb, 0, null, null, ExcludeFileDataFields);
			}
			return (from entity in ec
					select new Attachment(entity.CirAttachmentId, entity.CirId, entity.Filename, entity.CreatedBy, entity.Created, null));
		}

		//public Attachment GetAttachment

		public bool Exists(long cirId, string filename) {
			bool exists = false;
			using (var daa = GetDataAccessAdapter()) {
				exists = (FetchAttachment(cirId, filename, daa, false) != null);
				//var ec = new EntityCollection<CirAttachmentEntity>(new CirAttachmentEntityFactory());
				//var fb = new RelationPredicateBucket();
				//fb.PredicateExpression.Add(CirAttachmentFields.CirId == cirId);
				//fb.PredicateExpression.Add(CirAttachmentFields.Filename == filename);

				//daa.FetchEntityCollection(ec, fb);
				//exists = (ec.Count > 0);
			}
			return exists;
		}

		public void Save(Attachment attachment) {
			// sanity check
			if(attachment.CirId <= 0 || string.IsNullOrEmpty(attachment.Filename)) {
				throw new ArgumentException("Must supply CIR Id and attachment filename");
			}

			using (var daa = GetDataAccessAdapter()) {
				CirAttachmentEntity entity = null;
				if (attachment.CirAttachmentId > 0) {
					entity = FetchAttachment(attachment.CirAttachmentId, daa, false);
				}
				else {
					entity = FetchAttachment(attachment.CirId, attachment.Filename, daa, false);
				}

				if (entity == null) {
					entity = new CirAttachmentEntity();
				}
				entity.CirId = attachment.CirId;
				entity.Filename = attachment.Filename;
				entity.Created = attachment.Created;
				entity.CreatedBy = attachment.CreatedBy;
				entity.BinaryData = attachment.BinaryData;

				daa.SaveEntity(entity);
			}
		}

		public void Delete(long cirAttachmentId) {
			using (var daa = GetDataAccessAdapter()) {
				CirAttachmentEntity entity = new CirAttachmentEntity(cirAttachmentId);
				daa.DeleteEntity(entity);
			}
		}

		public Attachment Get(long cirAttachmentId) {
			Attachment attachment = null;
			using (var daa = GetDataAccessAdapter()) {
				var entity = FetchAttachment(cirAttachmentId, daa, true);
				attachment = new Attachment(entity.CirAttachmentId, entity.CirId, entity.Filename, entity.CreatedBy, entity.Created, entity.BinaryData);
			}
			return attachment;
		}

		private CirAttachmentEntity FetchAttachment(long cirId, string filename, DataAccessAdapter daa, bool fetchFileData) {
			var fb = new RelationPredicateBucket();
			fb.PredicateExpression.Add(CirAttachmentFields.CirId == cirId);
			fb.PredicateExpression.Add(CirAttachmentFields.Filename == filename);
			return FetchAttachment(fb, daa, fetchFileData);
		}

		private CirAttachmentEntity FetchAttachment(long cirAttachmentId, DataAccessAdapter daa, bool fetchFileData) {
			var fb = new RelationPredicateBucket();
			fb.PredicateExpression.Add(CirAttachmentFields.CirAttachmentId == cirAttachmentId);
			return FetchAttachment(fb, daa, fetchFileData);
		}

		private CirAttachmentEntity FetchAttachment(RelationPredicateBucket fb, DataAccessAdapter daa, bool fetchFileData) {
			var ec = new EntityCollection<CirAttachmentEntity>(new CirAttachmentEntityFactory());
			ExcludeIncludeFieldsList excludedFields = null;
			if(!fetchFileData) {
				excludedFields = ExcludeFileDataFields;
			}
			daa.FetchEntityCollection(ec, fb, 1, null, null, excludedFields);
			if (ec.Count > 0) {
				return ec[0];
			}
			return null;
		}

		private ExcludeIncludeFieldsList ExcludeFileDataFields {
			get {
				var excludedFields = new ExcludeIncludeFieldsList();
				excludedFields.Add(CirAttachmentFields.BinaryData);
				return excludedFields;
			}
		}
	}
}
