using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Common.BirPdf;
using System.Data;
using Cir.Common.AccessControl;

namespace Cir.Data.BirPdf
{
    public class DataLayer : BaseDataLayer
    {
        public DataLayer(string connectionString)
            : base(connectionString)
        {
        }

        public byte[] Get(long BirDataId)
        {
            byte[] pdfFile = null;

            // get PDF from database 
            using (DataAccessAdapter daa = GetDataAccessAdapter())
            {
                // fetch existing entity if it exists
                BirWordDocumentEntity entity = FetchBirWordDocumentEntity(BirDataId, daa);

                if (entity != null)
                {
                    pdfFile = entity.WordDocBytes;
                }
            }

            return pdfFile;
        }

        public void Save(long BirDataId, string BirCode, byte[] pdfFile)
        {
            // save PDF to database (update existing if applicable)
            using (DataAccessAdapter daa = GetDataAccessAdapter())
            {
                // fetch existing entity if it exists
                BirWordDocumentEntity entity = FetchBirWordDocumentEntity(BirDataId, daa);
                if (entity == null)
                {
                    entity = new BirWordDocumentEntity();
                    entity.BirDataId = BirDataId;
                }

                entity.BirCode = BirCode;

                // update pdf file data
                entity.WordDocBytes = pdfFile;

                // save
                daa.SaveEntity(entity);
            }
        }

        private static BirWordDocumentEntity FetchBirWordDocumentEntity(long BirDataId, DataAccessAdapter daa)
        {
            IRelationPredicateBucket fb = new RelationPredicateBucket();
            fb.PredicateExpression.Add(BirWordDocumentFields.BirDataId == BirDataId.ToString());

            EntityCollection<BirWordDocumentEntity> ec = new EntityCollection<BirWordDocumentEntity>(new BirWordDocumentEntityFactory());

            daa.FetchEntityCollection(ec, fb);

            if ((ec.Count == 1))
            {
                return ec[0];
            }

            return null;
        }

        public List<Placeholders> GetReportPlaceholders(int ComponentInspectionReportTypeId)
        {
            Placeholders returnValue = null;
            using (var daa = GetDataAccessAdapter())
            {
                var users = new List<Placeholders>();
                var ec = new EntityCollection<BirReportPlaceholdersEntity>();
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.AddWithAnd(BirReportPlaceholdersFields.ComponentType == ComponentInspectionReportTypeId);
                daa.FetchEntityCollection(ec, fb);

                foreach (var entity in ec)
                {
                    returnValue = CreatePlaceholder(entity);
                    users.Add(returnValue);
                }
                return users;
            }
        }
        /// <summary>
        /// Create new placeholder
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static Placeholders CreatePlaceholder(BirReportPlaceholdersEntity entity)
        {
            var placeholder = new Placeholders(entity.BirReportPlaceholderId, entity.Placeholder, entity.FieldId, Convert.ToInt64(entity.ComponentType));
            placeholder.Field = entity.FieldId;
            placeholder.Placeholder = entity.Placeholder;
            return placeholder;
        }

        public List<BIRView> GetBIRData(string strUSerID)
        {
            List<BIRView> objBIRViewCollection = new List<BIRView>();
            DataSet dsbirdata = new DataSet();
            using (DataAccessAdapter daa = GetDataAccessAdapter())
            {

                dsbirdata = RetrievalProcedures.GetBirdata();

                objBIRViewCollection = (from row in dsbirdata.Tables[0].AsEnumerable()
                                        group row by new { Birdataid = row.Field<Int64>("BirDataID"), BirCode = row.Field<string>("BirCode"), RevisionNumber = row.Field<int>("RevisionNumber"),
                                                           CIRDataId = row.Field<Int64>("CIRDataId"),CirId = row.Field<Int64>("CirId"),Country = row.Field<string>("Country"),
                                                           TurbineType = row.Field<string>("TurbineType"),TurbineNumber = row.Field<Int64>("TurbineNumber"),SBU = row.Field<string>("SBU"),
                                                           SiteAddress = row.Field<string>("SiteAddress"),Created = row.Field<DateTime>("Created"),Createdby = row.Field<string>("Createdby"),
                                        } into g
                                        select new BIRView { BirDataId = g.Key.Birdataid, BirCode = g.Key.BirCode, RevisionNumber = g.Key.RevisionNumber,
                                            CIRDataId = g.Key.CIRDataId, CIRId = g.Key.CirId, Country = g.Key.Country, TurbineType = g.Key.TurbineType,
                                            TurbineNumber = g.Key.TurbineNumber.ToString(), SBU = g.Key.SBU, SiteAddress = g.Key.SiteAddress,Created = g.Key.Created, Createdby = g.Key.Createdby,
                                                             BirCirData = (from row in dsbirdata.Tables[1].AsEnumerable()
                                        group row by new { Birdataid = row.Field<Int64>("BirDataID"), 
                                                           CIRDataId = row.Field<Int64>("CIRDataId"),CirId = row.Field<Int64>("CirId"),Name = row.Field<string>("FileName"),
                                                           CIMCaseNumber = row.Field<Int64>("CIMCaseNumber"),
                                                           Created = row.Field<DateTime>("Created"),
                                                           Modified = row.Field<DateTime>("Modified"),
                                        } into k
                                                                           select new CIRDataItem
                                                                           {
                                                                               BirDataId = k.Key.Birdataid,
                                                                               CirDataId = k.Key.CIRDataId,
                                                                               CirId = k.Key.CirId,
                                                                               Name = k.Key.Name,
                                                                               CIMCaseNumber = k.Key.CIMCaseNumber,
                                                                               Created = k.Key.Created,
                                                                               Modified = k.Key.Modified,
                                                                           }).ToList()
                                        }).ToList();
            }
            return objBIRViewCollection;
        }

        public List<CIRDataItem> GetBIRCIRData(string strUSerID)
        {
            List<CIRDataItem> objBIRCIRCollection = new List<CIRDataItem>();
            DataSet dsbirdata = new DataSet();
            using (DataAccessAdapter daa = GetDataAccessAdapter())
            {

                dsbirdata = RetrievalProcedures.GetBirdata();

                objBIRCIRCollection = (from row in dsbirdata.Tables[1].AsEnumerable()
                                        group row by new
                                        {

                                            Birdataid = row.Field<Int64>("BirDataID"),
                                            CIRDataId = row.Field<Int64>("CIRDataId"),
                                            CirId = row.Field<Int64>("CirId"),
                                            Name = row.Field<string>("FileName"),
                                            CIMCaseNumber = row.Field<Int64>("CIMCaseNumber"),
                                            Created = row.Field<DateTime>("Created"),
                                            Modified = row.Field<DateTime>("Modified"),
                                        } into k
                                        select new CIRDataItem
                                        {
                                            BirDataId = k.Key.Birdataid,
                                            CirDataId = k.Key.CIRDataId,
                                            CirId = k.Key.CirId,
                                            Name = k.Key.Name,
                                            CIMCaseNumber = k.Key.CIMCaseNumber,
                                            Created = k.Key.Created,
                                            Modified = k.Key.Modified,
                                        }).ToList();
                                        
            }
            return objBIRCIRCollection;
        }

    }
}
