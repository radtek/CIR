using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cir.Common.Utilities;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Sync.Services.DataContracts;
using Cir.Sync.Services.ErrorHandling;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Configuration;

namespace Cir.Sync.Services.DAL
{
    public class DACirAttachment
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
        }

        public bool SaveAttachment(CirAttachments attachment)
        {
            byte[] fileBytes = Convert.FromBase64String(attachment.StringData);
            SaveAttachment(-1, attachment.CirId, attachment.Filename, attachment.CreatedBy, DateTime.Now, fileBytes);
            return true;
        }

        public void SaveAttachment(long cirAttachmentId, long cirId, string fileName, string createdBy, DateTime created, byte[] binaryData)
        {
            // sanity check
            if (cirId <= 0 || string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("Must supply CIR Id and attachment filename");
            }

            using (var daa = new DataAccessAdapter(GetConnectionString(), false))
            {
                CirAttachmentEntity entity = null;
                if (cirAttachmentId > 0)
                {
                    entity = FetchAttachment(cirAttachmentId, daa, false);
                }
                else
                {
                    entity = FetchAttachment(cirId, fileName, daa, false);
                }

                if (entity == null)
                {
                    entity = new CirAttachmentEntity();
                }
                entity.CirId = cirId;
                entity.Filename = fileName;
                entity.Created = created;
                entity.CreatedBy = createdBy;
                entity.BinaryData = binaryData;

                daa.SaveEntity(entity);
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Upload DefectCategorization Attachment Saved", LogType.Information, "");

            }
        }

        public IEnumerable<CirAttachments> GetAttachments(long cirId)
        {
            var ec = new EntityCollection<CirAttachmentEntity>(new CirAttachmentEntityFactory());
            using (var daa = new DataAccessAdapter(GetConnectionString(), false))
            {
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(CirAttachmentFields.CirId == cirId);

                daa.FetchEntityCollection(ec, fb, 0, null, null, ExcludeFileDataFields);
            }
            return (from entity in ec
                    select new CirAttachments(entity.CirAttachmentId, entity.CirId, entity.Filename, entity.CreatedBy, entity.Created.ToShortDateString(), null));
        }

        public bool Delete(long cirAttachmentId)
        {
            using (var daa = new DataAccessAdapter(GetConnectionString(), false))
            {
                CirAttachmentEntity entity = new CirAttachmentEntity(cirAttachmentId);
                string sfilename = entity.Filename;
                daa.DeleteEntity(entity);
                ErrorHandling.SystemLog.CirServiceLog("Cir.Sync.Service", "Attachment " + sfilename + " Deleted ", LogType.Information, "");

            }
            return true;
        }

        public CirAttachments Get(long cirAttachmentId)
        {
            CirAttachments attachment = null;
            using (var daa = new DataAccessAdapter(GetConnectionString(), false))
            {
                var entity = FetchAttachment(cirAttachmentId, daa, true);
                attachment = new CirAttachments(entity.CirAttachmentId, entity.CirId, entity.Filename, entity.CreatedBy, entity.Created.ToShortDateString(),"");
                attachment.StringData = Convert.ToBase64String(entity.BinaryData);
              
            }
            return attachment;
        }

        private ExcludeIncludeFieldsList ExcludeFileDataFields
        {
            get
            {
                var excludedFields = new ExcludeIncludeFieldsList();
                excludedFields.Add(CirAttachmentFields.BinaryData);
                return excludedFields;
            }
        }

        private CirAttachmentEntity FetchAttachment(long cirAttachmentId, DataAccessAdapter daa, bool fetchFileData)
        {
            var fb = new RelationPredicateBucket();
            fb.PredicateExpression.Add(CirAttachmentFields.CirAttachmentId == cirAttachmentId);
            return FetchAttachment(fb, daa, fetchFileData);
        }

        private CirAttachmentEntity FetchAttachment(RelationPredicateBucket fb, DataAccessAdapter daa, bool fetchFileData)
        {
            var ec = new EntityCollection<CirAttachmentEntity>(new CirAttachmentEntityFactory());
            ExcludeIncludeFieldsList excludedFields = null;
            if (!fetchFileData)
            {
                excludedFields = ExcludeFileDataFields;
            }
            daa.FetchEntityCollection(ec, fb, 1, null, null, excludedFields);
            if (ec.Count > 0)
            {
                return ec[0];
            }
            return null;
        }

        private CirAttachmentEntity FetchAttachment(long cirId, string filename, DataAccessAdapter daa, bool fetchFileData)
        {
            var fb = new RelationPredicateBucket();
            fb.PredicateExpression.Add(CirAttachmentFields.CirId == cirId);
            fb.PredicateExpression.Add(CirAttachmentFields.Filename == filename);
            return FetchAttachment(fb, daa, fetchFileData);
        }

       

        public bool Exists(long cirId, string filename)
        {
            bool exists = false;
            using (var daa = new DataAccessAdapter(GetConnectionString(), false))
            {
                exists = (FetchAttachment(cirId, filename, daa, false) != null);

            }
            return exists;
        }
    }
}