using System.Linq;
using Cir.Data.Access.Models;

namespace Cir.Data.Access.Helpers
{
    internal static class CirSubmissionDataExtensions
    {
        public static IQueryable<CirSubmissionData> WhereIsRelatedToUser(this IQueryable<CirSubmissionData> cirList,
            string userName)
        {
            return cirList.Where(x => x.CreatedBy.ToLower() == userName ||
                                      x.ModifiedBy.ToLower() == userName ||
                                      ((x.LockedBy.ToLower() == userName ||
                                      x.DelegatedTo.ToLower() == userName ||
                                      x.DelegatedBy.ToLower() == userName ) && x.StatusChangedBy != userName));
                //.Where(x => x.StatusChangedBy != userName || x.CreatedBy == userName || x.ModifiedBy == userName);
        }
        public static IQueryable<CirSubmissionData> WhereIsCreatedUser(this IQueryable<CirSubmissionData> cirList,
            string userName)
        {
            return cirList.Where(x => (x.CreatedBy.ToLower() == userName ||
                                      x.ModifiedBy.ToLower() == userName) && x.SqlProcessStatus.ToString().ToLower() == "transferred");//||
                                      //x.LockedBy.ToLower() == userName ||
                                      //x.DelegatedTo.ToLower() == userName ||
                                      //x.DelegatedBy.ToLower() == userName)
                //.Where(x => x.StatusChangedBy != userName || x.CreatedBy == userName || x.ModifiedBy == userName);
        }
    }
}
