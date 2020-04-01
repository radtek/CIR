using System;
using System.Data;
using System.Data.SqlClient;
using Cir.Data.Access.CirSyncService;

namespace Cir.Data.Access.Validation
{
    public class TurbineNumberValidation : IValidation
    {
        private readonly SyncServiceClient _serviceClient;

        public TurbineNumberValidation()
        {
            _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
        }

        public bool IsValid(params string[] parameters)
        {
            var turbineNumber = parameters[0];
            //bool IsTurbineExist = false;
            //var query = "SELECT * FROM TurbineData WHERE TurbineId = '" + turbineNumber.Trim() + "'";
            //var databaseAccount = System.Configuration.ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
            //using (SqlConnection objCon = new SqlConnection(databaseAccount))
            //{
            //    objCon.Open();
            //    using (SqlCommand cmd = new SqlCommand(query, objCon))
            //    {
            //        SqlDataReader reader = cmd.ExecuteReader();
            //        if (reader.HasRows)
            //        {
            //            IsTurbineExist = true;
            //        }

            //    }
            //    return IsTurbineExist;
            return _serviceClient.ValidateTurbineNumber(Convert.ToString(turbineNumber));

        }
    }
}
