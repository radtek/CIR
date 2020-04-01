using System.Collections.Generic;
using System.Linq;
using Cir.Data.Access.DataAccess;
using Cir.Data.Access.Models;
using System;

namespace Cir.Data.Access.Services
{
    internal class CirSubmissionService : ICirSubmissionService
    {
        private ICirSubmissionDataRepository _cirSubmissionDataRepository;
        private ICirValidationService _cirValidation;

        public CirSubmissionService(ICirSubmissionDataRepository cirSubmissionDataRepository,
            ICirValidationService cirValidation)
        {
            _cirSubmissionDataRepository = cirSubmissionDataRepository;
            _cirValidation = cirValidation;
        }

        public CirSubmissionData Get(string id)
        {
            return _cirSubmissionDataRepository.Get(id);
        }

        public IEnumerable<CirSubmissionData> GetAll()
        {
            return _cirSubmissionDataRepository.GetAll().AsEnumerable();
        }

        public IEnumerable<CirSubmissionData> SyncRequest(string userId, IEnumerable<CirSubmissionSyncData> reportsToSync)
        {
            var reportsInAzureRelatedToUser = _cirSubmissionDataRepository.GetAllRelatedToUser(userId).ToList();

            var newReportsForAzureToResend = reportsToSync
                .Where(r => !reportsInAzureRelatedToUser.Any(p => Equals(r.Id, p.Id)))
                .ToList();

            var newReportsToInsertInBrowser = reportsInAzureRelatedToUser
                .Select(r => r)
                .Where(r => !reportsToSync.Any(p => Equals(r.Id, p.Id)))
                .ToList();

            var reportsToUpdateInAzure = FilterReportsForUpdate(reportsToSync, newReportsForAzureToResend, reportsInAzureRelatedToUser);
            var reportsIdsToUpdateInBrowser = FilterReportsForUpdate(reportsInAzureRelatedToUser, newReportsToInsertInBrowser, reportsToSync.ToList());

            var reportsToSaveInAzure = new List<CirSubmissionData>();

            reportsToUpdateInAzure
                .Concat(newReportsForAzureToResend)
                .ToList()
                .ForEach(r => reportsToSaveInAzure.Add(new CirSubmissionData
                {
                    Id = r.Id,
                    ModifiedBy = r.ModifiedBy,
                    ModifiedOn = r.ModifiedOn
                }));

            //if no reports needed for Browser skip query
            if (!reportsIdsToUpdateInBrowser.Any() && !newReportsToInsertInBrowser.Any())
                return reportsToSaveInAzure;

            var ids = reportsIdsToUpdateInBrowser.Select(r => r.Id).ToList();

            ids.AddRange(newReportsToInsertInBrowser.Select(r => r.Id).ToList());

            var reportsInAzureToBeSavedInBrowser = _cirSubmissionDataRepository.GetAllByIds(ids);

            return reportsToSaveInAzure.Concat(reportsInAzureToBeSavedInBrowser);
        }

        public void SyncUpdate(CirSubmissionData reportToUpdate)
        {
            if (DateTime.Compare(reportToUpdate.CreatedOn, reportToUpdate.ModifiedOn) == 0)
            {
                _cirSubmissionDataRepository.Add(reportToUpdate);
            }
            else
            {
                _cirSubmissionDataRepository.Update(reportToUpdate);
            }
        }

        public CirSubmissionData Add(CirSubmissionData report)
        {
            if (!_cirValidation.IsDataValid(report))
            {
                report.State = CirState.Error;
            }
            _cirSubmissionDataRepository.Add(report);
            return report;
        }

        public CirSubmissionData Update(CirSubmissionData report)
        {
            if (!_cirValidation.IsDataValid(report))
            {
                report.State = CirState.Error;
            }
            _cirSubmissionDataRepository.Update(report);
            return report;
        }

        public void Delete(string reportId)
        {
            _cirSubmissionDataRepository.Delete(reportId);
        }

        private List<CirSubmissionSyncData> FilterReportsForUpdate(IEnumerable<CirSubmissionSyncData> filterFrom, List<CirSubmissionSyncData> notPresentIn, List<CirSubmissionSyncData> presentIn)
        {
            var filtered = new List<CirSubmissionSyncData>();

            foreach (var reportToUpdate in filterFrom)
            {
                if (notPresentIn.Any(r => Equals(r.Id, reportToUpdate.Id))) continue;
                if (!presentIn.Any(r => Equals(r.Id, reportToUpdate.Id))) continue;

                var reportInAzure = presentIn.First(r => Equals(r.Id, reportToUpdate.Id));

                int dateComparison = DateTime.Compare(reportInAzure.ModifiedOn, reportToUpdate.ModifiedOn);

                if (dateComparison == 0) continue;

                if (dateComparison < 0)
                {
                    filtered.Add(reportToUpdate);
                }
            }

            return filtered;
        }
    }
}