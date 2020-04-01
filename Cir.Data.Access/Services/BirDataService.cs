using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using Cir.Data.Access.CirSyncService;

namespace Cir.Data.Access.Services
{
    internal class BirDataService:IBirDataService
    {

        public string TableName => "BirDetails";
        private IBirDetailsDataRepository _birDetailsDataRepository;
        
        public BirDataService(IBirDetailsDataRepository birDetailsDataRepository)
        {
            _birDetailsDataRepository = birDetailsDataRepository;
           
        }

        public BirDetailsData Get(string id)
        {
            return _birDetailsDataRepository.Get(id);     
        }

        public IEnumerable<BirDetailsData> GetAll()
        {
            return _birDetailsDataRepository.GetAll().AsEnumerable();
        }

        public BirDetailsData Add(BirDetailsData report)
        {
            if (report.BirCode == null)
            {
                var cirIds = string.Join("/", report.CirIDs);

                int? rev = null;
                var existingRevisions = GetAll().Where(p => string.Join("/", report.CirIDs) == cirIds && !p.Deleted).ToList();
                if (existingRevisions.Any())
                {
                    rev = existingRevisions.Max(p => p.RevisionNumber)+1;
                }
                report.Created = DateTime.Now;
                report.Modified = DateTime.Now;
                report.RevisionNumber = rev??1;
                report.BirCode =$"BIR-{cirIds}-Rev{report.RevisionNumber}";
            }
            _birDetailsDataRepository.Add(report);
            return report;                        
        }

        public BirDetailsData Update(BirDetailsData report)
        {
            _birDetailsDataRepository.Update(report);
            return report;
        }

        public void Delete(string id)
        {
            _birDetailsDataRepository.Delete(id);
        }

        public void SaveBirData(Bir bir)
        {
            _birDetailsDataRepository.SaveBirData(bir);
        }
    }
}
