using System;
using System.Data.SqlClient;
using Cir.Data.Access.CirSyncService;
namespace Cir.Data.Access.Validation
{
    class CIMCaseValidation : IValidation
    {
        private readonly SyncServiceClient _serviceClient;

        public CIMCaseValidation()
        {
            _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
        }

        public bool IsValid(params string[] parameters)
        {
            var CIMCaseNumber = parameters[0];
            
            //bool IsSIMCaseExist = false;
            //var query = "SELECT * FROM CIMCase WHERE CaseNo = '" + CIMCaseNumber.Trim() + "'";
            //var databaseAccount = System.Configuration.ConfigurationManager.ConnectionStrings["CIM_MasterDataConn"].ConnectionString;
            //using (SqlConnection objCon = new SqlConnection(databaseAccount))
            //{
            //    using (SqlCommand cmd = new SqlCommand(query, objCon))
            //    {
            //        objCon.Open();
            //        SqlDataReader reader = cmd.ExecuteReader();
            //        if (reader.HasRows)
            //        {
            //            IsSIMCaseExist = true;
            //        }

            //    }
            //    return IsSIMCaseExist;               
            //}

            return _serviceClient.ValidateCIMCaseNumber(Convert.ToString(CIMCaseNumber));
        }
    }
   
}
