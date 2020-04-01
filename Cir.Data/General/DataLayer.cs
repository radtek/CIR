using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Common.General;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Cir.Data.LLBLGen;

namespace Cir.Data.General
{
    public class DataLayer : BaseDataLayer
    {
        public DataLayer(string connectionString)
            : base(connectionString)
        {
        }

        public List<Sbu> GetSbuList()
        {

            var countries = new EntityCollection<CountryIsoEntity>(new CountryIsoEntityFactory());
            var sbus = new EntityCollection<SbuEntity>(new SbuEntityFactory());

            using (var daa = GetDataAccessAdapter())
            {
                daa.FetchEntityCollection(countries, null);
                daa.FetchEntityCollection(sbus, null);
            }


            var returnValue = new List<Sbu>(
                from sbu in sbus
                select new Sbu(sbu.Sbuid, sbu.Name, sbu.ShortName, (from country in countries
                                                                    where country.Sbuid == sbu.Sbuid
                                                                    select country.CountryIsoid
                    )
                )
            );

            return returnValue;

        }

        public bool Is3MwGearBox(long caseNumber)
        {
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<ThreeMwGearboxesEntity>();
                daa.FetchEntityCollection(ec, new RelationPredicateBucket(ThreeMwGearboxesFields.Casenumber == caseNumber), 1);
                return (ec.Count > 0);
            }
        }
        //76940
        public void SaveDynamicTableDefination(string CimCaseNumber, string TableHeader, string ColHeader1, string ColHeader2, string ColHeader3, string ColHeader4, string RowHeader1, string RowHeader2, string RowHeader3, string RowHeader4, string RowHeader5, string RowHeader6, string RowHeader7, string RowHeader8, string RowHeader9, string RowHeader10)
        {
            using (var daa = GetDataAccessAdapter())
            {
                TemplateDynamicTableDefEntity entity = new TemplateDynamicTableDefEntity();
                entity.CimcaseNo = CimCaseNumber;
                entity.TableHeader = TableHeader;
                entity.ColHeader1 = ColHeader1;
                entity.ColHeader2 = ColHeader2;
                entity.ColHeader3 = ColHeader3;
                entity.ColHeader4 = ColHeader4;
                entity.RowHeader1 = RowHeader1;
                entity.RowHeader2 = RowHeader2;
                entity.RowHeader3 = RowHeader3;
                entity.RowHeader4 = RowHeader4;
                entity.RowHeader5 = RowHeader5;
                entity.RowHeader6 = RowHeader6;
                entity.RowHeader7 = RowHeader7;
                entity.RowHeader8 = RowHeader8;
                entity.RowHeader9 = RowHeader9;
                entity.RowHeader10 = RowHeader10;
                daa.SaveEntity(entity);
            }

        }
        public void SaveDynamicTable(string CIRId, string Row1Col1, string Row1Col2, string Row1Col3, string Row1Col4, string Row2Col1, string Row2Col2, string Row2Col3, string Row2Col4, string Row3Col1, string Row3Col2, string Row3Col3, string Row3Col4, string Row4Col1, string Row4Col2, string Row4Col3, string Row4Col4, string Row5Col1, string Row5Col2, string Row5Col3, string Row5Col4, string Row6Col1, string Row6Col2, string Row6Col3, string Row6Col4,
            string Row7Col1, string Row7Col2, string Row7Col3, string Row7Col4, string Row8Col1, string Row8Col2, string Row8Col3, string Row8Col4,
            string Row9Col1, string Row9Col2, string Row9Col3, string Row9Col4, string Row10Col1, string Row10Col2, string Row10Col3, string Row10Col4)
        {
            using (var daa = GetDataAccessAdapter())
            {
                var entity = GetDynamicTableEntity(CIRId, daa);
                if (entity == null)
                {
                    entity = new DynamicTableInputEntity();
                }

                entity.CirId = CIRId;
                entity.Row1Col1 = Row1Col1;
                entity.Row1Col2 = Row1Col2;
                entity.Row1Col3 = Row1Col3;
                entity.Row1Col4 = Row1Col4;
                entity.Row2Col1 = Row2Col1;
                entity.Row2Col2 = Row2Col2;
                entity.Row2Col3 = Row2Col3;
                entity.Row2Col4 = Row2Col4;
                entity.Row3Col1 = Row3Col1;
                entity.Row3Col2 = Row3Col2;
                entity.Row3Col3 = Row3Col3;
                entity.Row3Col4 = Row3Col4;
                entity.Row4Col1 = Row4Col1;
                entity.Row4Col2 = Row4Col2;
                entity.Row4Col3 = Row4Col3;
                entity.Row4Col4 = Row4Col4;
                entity.Row5Col1 = Row5Col1;
                entity.Row5Col2 = Row5Col2;
                entity.Row5Col3 = Row5Col3;
                entity.Row5Col4 = Row5Col4;
                entity.Row6Col1 = Row6Col1;
                entity.Row6Col2 = Row6Col2;
                entity.Row6Col3 = Row6Col3;
                entity.Row6Col4 = Row6Col4;
                entity.Row7Col1 = Row7Col1;
                entity.Row7Col2 = Row7Col2;
                entity.Row7Col3 = Row7Col3;
                entity.Row7Col4 = Row7Col4;
                entity.Row8Col1 = Row8Col1;
                entity.Row8Col2 = Row8Col2;
                entity.Row8Col3 = Row8Col3;
                entity.Row8Col4 = Row8Col4;
                entity.Row9Col1 = Row9Col1;
                entity.Row9Col2 = Row9Col2;
                entity.Row9Col3 = Row9Col3;
                entity.Row9Col4 = Row9Col4;
                entity.Row10Col1 = Row10Col1;
                entity.Row10Col2 = Row10Col2;
                entity.Row10Col3 = Row10Col3;
                entity.Row10Col4 = Row10Col4;
                daa.SaveEntity(entity);
            }

        }
        public void DeleteDynamicTable(string CirID)
        {
            using (var daa = GetDataAccessAdapter())
            {
                var entity = GetDynamicTableEntity(CirID, daa);
                if (entity != null)
                {
                    daa.DeleteEntity(entity);
                }
            }
        }

        private DynamicTableInputEntity GetDynamicTableEntity(string id, DataAccessAdapter daa)
        {
            var ec = new EntityCollection<DynamicTableInputEntity>(new DynamicTableInputEntityFactory());
            var fb = new RelationPredicateBucket();
            fb.PredicateExpression.Add(DynamicTableInputFields.CirId == id);

            daa.FetchEntityCollection(ec, fb);

            if (ec.Count == 1)
            {
                return ec[0];
            }
            return null;
        }
    }
}
