using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Common.AccessControl;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data.AccessControl {
    public class DataLayer : BaseDataLayer
    {
        public DataLayer(string connectionString)
            : base(connectionString)
        {
        }

        public void SaveUser(string initials, string userName, PermissionLevel permissionLevel)
        {
            using (var daa = GetDataAccessAdapter())
            {
                var entity = GetUserEntity(initials, daa);
                if (entity == null)
                {
                    entity = new CirUserEntity();
                }
                entity.Initials = initials;
                entity.UserName = userName;
                entity.PermissionLevel = (int)permissionLevel;
                daa.SaveEntity(entity);
            }
        }

        /// <summary>
        /// Authenticates if the current Windows credentials exists in the user table
        /// </summary>
        /// <param name="initials"></param>
        /// <returns></returns>
        public User GetUser(string initials)
        {
            User returnValue = null;
            using (var daa = GetDataAccessAdapter())
            {
                var entity = GetUserEntity(initials, daa);
                if (entity != null)
                {
                    returnValue = CreateUserData(entity);
                }
            }
            return returnValue;
        }

        private CirUserEntity GetUserEntity(string initials, DataAccessAdapter daa)
        {
            var ec = new EntityCollection<CirUserEntity>(new CirUserEntityFactory());
            var fb = new RelationPredicateBucket();
            fb.PredicateExpression.Add(CirUserFields.Initials == initials);

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
        public List<User> GetUsers(PermissionLevel level)
        {
            User returnValue = null;
            using (var daa = GetDataAccessAdapter())
            {
                var users = new List<User>();
                var ec = new EntityCollection<CirUserEntity>(new CirUserEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(CirUserFields.PermissionLevel == (int)level);
                daa.FetchEntityCollection(ec, fb);

                foreach (var entity in ec)
                {
                    returnValue = CreateUserData(entity);
                    users.Add(returnValue);
                }
                return users;
            }
        }

        public void DeleteUser(string initials)
        {

            using (var daa = GetDataAccessAdapter())
            {
                var entity = GetUserEntity(initials, daa);
                if (entity != null)
                {
                    daa.DeleteEntity(entity);
                }
            }
        }

        private static User CreateUserData(CirUserEntity entity)
        {
            var user = new User(entity.CirUserId, entity.Initials, entity.UserName, (PermissionLevel)entity.PermissionLevel);
            return user;
        }

        public User GetUser(long userId)
        {
            User returnValue = null;
            using (var daa = GetDataAccessAdapter())
            {
                var entity = new CirUserEntity(userId);
                if (daa.FetchEntity(entity))
                {
                    returnValue = CreateUserData(entity);
                }
            }
            return returnValue;
        }

        public void SaveBIRView(BIRView _BIRView, ref int RetVal)
        {
            using (DataAccessAdapter daa = GetDataAccessAdapter()) {
                ActionProcedures.SaveBircirvalueinDatabase
                    (_BIRView.MAsterCIRid, 
                    _BIRView.CIRIDs, 
                    _BIRView.RepairingSol,
                    _BIRView.RawMaterial,
                    _BIRView.ConculsionRecomm,
                    _BIRView.TurbineID,
                    _BIRView.Createdby, ref RetVal,
                    daa);
            }
                                
        
        }


        ////public DataSet GetBIRData(string strUSerID)
        ////{
        ////    DataSet dsbirdata = new DataSet();
        ////    BIRView returnValue = null;
        ////    using (DataAccessAdapter daa = GetDataAccessAdapter())
        ////    {

        ////        return dsbirdata = RetrievalProcedures.BirdataGet(strUSerID);
        ////    }
        ////}
	}
}
	

