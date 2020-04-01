using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Common.StandardText;

using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen;
using SD.LLBLGen.Pro.ORMSupportClasses;


namespace Cir.Data.StandardText
{
    public class DataLayer : BaseDataLayer
    {
        public DataLayer(string connectionString)
            : base(connectionString)
        {
        }


        /// <summary>
        /// Save StandardTexts
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Title"></param>
        /// <param name="Description"></param>
        public void SaveStandardTexts(int id, string Title, string Description, int ComponentInspectionReportType)
        {
            using (var daa = GetDataAccessAdapter())
            {
                var entity = GetStandardTextEntity(id, daa);
                if (entity == null)
                {
                    entity = new CirStandardTextsEntity();
                }
                entity.Id = id;
                entity.Title = Title;
                entity.Description = Description;
                entity.ComponentInspectionReportTypeId = ComponentInspectionReportType;
                entity.Deleted = false;
                entity.Created = DateTime.Today;
                daa.SaveEntity(entity);
            }
        }

        /// <summary>
        /// Authenticates if the current Windows credentials exists in the user table
        /// </summary>
        /// <param name="initials"></param>
        /// <returns></returns>
        public StandardTexts GetStandardText(int ID)
        {
            StandardTexts returnValue = null;
            using (var daa = GetDataAccessAdapter())
            {
                var entity = GetStandardTextEntity(ID, daa);
                if (entity != null)
                {
                    returnValue = CreateStandardTexts(entity);
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Get StandardTexts 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="daa"></param>
        /// <returns></returns>
        private CirStandardTextsEntity GetStandardTextEntity(int id, DataAccessAdapter daa)
        {
            var ec = new EntityCollection<CirStandardTextsEntity>(new CirStandardTextsEntityFactory());
            var fb = new RelationPredicateBucket();
            fb.PredicateExpression.Add(CirStandardTextsFields.Id == id);

            daa.FetchEntityCollection(ec, fb);

            if (ec.Count == 1)
            {
                return ec[0];
            }
            return null;
        }

        /// <summary>
        /// Gets all users with a specific permission level
        /// </summary>
        /// <returns></returns>
        public List<StandardTexts> GetStandardTexts(long ComponentInspectionReportTypeId)
        {
            StandardTexts returnValue = null;
            using (var daa = GetDataAccessAdapter())
            {
                var users = new List<StandardTexts>();
                var ec = new EntityCollection<CirStandardTextsEntity>();
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.AddWithAnd(CirStandardTextsFields.ComponentInspectionReportTypeId == ComponentInspectionReportTypeId);
                daa.FetchEntityCollection(ec, fb);

                foreach (var entity in ec)
                {
                    returnValue = CreateStandardTexts(entity);
                    users.Add(returnValue);
                }
                return users;
            }
        }


        public List<CommonInspectionReportType> GetComponentInspectionReportTypes()
        {
            using (var daa = GetDataAccessAdapter())
            {
                var kvpList = new List<CommonInspectionReportType>();
                var ec = new EntityCollection<ComponentInspectionReportTypeEntity>(new ComponentInspectionReportTypeEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(ComponentInspectionReportTypeFields.Name != "");

                daa.FetchEntityCollection(ec, fb);

                foreach (var entity in ec)
                {
                    CommonInspectionReportType objCommon = new CommonInspectionReportType();
                    objCommon.CommonInspectionReportID = entity.ComponentInspectionReportTypeId;
                    objCommon.ReportName = entity.Name;
                    kvpList.Add(objCommon);
                }
                return kvpList;
            }
        }
        /// <summary>
        /// Delete StandardTexts by ID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteStandardTexts(int id)
        {

            using (var daa = GetDataAccessAdapter())
            {
                var entity = GetStandardTextEntity(id, daa);
                if (entity != null)
                {
                    daa.DeleteEntity(entity);
                }
            }
        }

        /// <summary>
        /// Create new StandardTexts
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private static StandardTexts CreateStandardTexts(CirStandardTextsEntity entity)
        {
            var user = new StandardTexts(entity.Id, entity.Title, entity.Description, entity.ComponentInspectionReportTypeId);
            return user;
        }

        //public StandardTexts GetStandardText(int ID)
        //{
        //    StandardTexts returnValue = null;
        //    using (var daa = GetDataAccessAdapter()) {
        //        var entity = new CirStandardTextsEntity(id);
        //        if(daa.FetchEntity(entity)) {
        //            returnValue = CreateStandardTexts(entity);
        //        }
        //    }
        //    return returnValue;
        //}
    }
}
