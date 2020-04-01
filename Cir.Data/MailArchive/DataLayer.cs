using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Common.MailArchive;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data.MailArchive {
	public class DataLayer : BaseDataLayer {
		public DataLayer(string connectionString)
			: base(connectionString) {
		}

		public void Archive(string mail, MailType type, DateTime date, long cirDataId) {
			using (var daa = GetDataAccessAdapter()) {
				// delete any existing mails in archive
				var entity = new CirMailArchiveEntity();
				entity.Deleted = true;
				var filter = new RelationPredicateBucket();
				filter.PredicateExpression.Add(CirMailArchiveFields.CirDataId == cirDataId);
				filter.PredicateExpression.AddWithAnd(CirMailArchiveFields.Type == (short)type);
				daa.UpdateEntitiesDirectly(entity, filter);
				
				// create new mail
				entity = new CirMailArchiveEntity();

				entity.Mail = mail;
				entity.Type = (short)type;
				entity.CirDataId = cirDataId;

				entity.Date = date;

				daa.SaveEntity(entity);
			}
		}

		public List<MailArchiveData> GetArchivedMails(long cirDataId, bool getMailData) {
			var mails = new List<MailArchiveData>();
			using (var daa = GetDataAccessAdapter()) {
				var ec = new EntityCollection<CirMailArchiveEntity>();
				var filter = new RelationPredicateBucket();
				filter.PredicateExpression.Add(CirMailArchiveFields.CirDataId == cirDataId);
				filter.PredicateExpression.AddWithAnd(CirMailArchiveFields.Deleted == false);

				ExcludeIncludeFieldsList excludedFields = null;
				if(getMailData == false) {
					excludedFields = new ExcludeIncludeFieldsList();
					excludedFields.Add(CirMailArchiveFields.Mail);
				}

				daa.FetchEntityCollection(ec, filter, 0, null, null, excludedFields);

				if(ec.Count > 0) {
					mails.AddRange(
						from entity in ec select CreateMailArchiveData(entity)
					);
				}
			}
			return mails;
		}

        public List<MailArchiveData> GetArchivedMail(long cirDataId, MailType mailType)
        {
            var mails = new List<MailArchiveData>();
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<CirMailArchiveEntity>();
                var filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(CirMailArchiveFields.CirDataId == cirDataId);
                filter.PredicateExpression.Add(CirMailArchiveFields.Type == mailType);
                filter.PredicateExpression.AddWithAnd(CirMailArchiveFields.Deleted == false);

                daa.FetchEntityCollection(ec, filter, 0, null, null);

                if (ec.Count > 0)
                {
                    mails.AddRange(
                        from entity in ec select CreateMailArchiveData(entity)
                    );
                }
            }
            return mails;
        }

		private static MailArchiveData CreateMailArchiveData(CirMailArchiveEntity entity) {
			return new MailArchiveData(entity.CirMailArchiveId, entity.Mail, entity.CirDataId, (MailType)entity.Type, entity.Date);
		}

		public MailArchiveData GetArchivedMail(long mailArchiveDataId) {
			MailArchiveData mail = null;
			using (var daa = GetDataAccessAdapter()) {
				var entity = new CirMailArchiveEntity(mailArchiveDataId);
				if(daa.FetchEntity(entity)) {
					mail = CreateMailArchiveData(entity);
				}
			}
			return mail;
		}
	}
}
