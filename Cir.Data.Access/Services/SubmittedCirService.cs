using Cir.Data.Access.DataAccessDynamic;
using Cir.Data.Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Cir.Data.Access.Models.Authorization;
using System.Threading.Tasks;

namespace Cir.Data.Access.Services
{
    internal class SubmittedCirService : ISubmittedCirService
    {
        public string TableName => "SubmittedCir";

        public async Task<IList<object>> GetTableData(IList<CirSubmissionData> cirSubmissionData)
        {
            try
            { 
                var data = new List<CirSubmissionData>();

                    var userCirs = cirSubmissionData
                        .Where(r => r.State == CirState.Submitted || r.State == CirState.Approved || r.State == CirState.Rejected).Select(x => new CirSubmissionData
                        {
                            Id = x.Id,
                            CirId = x.CirId,
                            Data = x.Data,
                            State = x.State,
                            Errors = x.Errors,
                            CreatedBy = x.CreatedBy,
                            CreatedOn = x.CreatedOn,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedOn = x.ModifiedOn,
                            DelegatedTo = x.DelegatedTo,
                            DelegatedBy = x.DelegatedBy,
                            LockedBy = x.LockedBy,
                            SqlProcessStatus = x.SqlProcessStatus,
                            CirTemplateId = x.CirTemplateId,
                            CirTemplateName = x.CirTemplateName
                        }).ToList();


                return userCirs.ToList<object>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
