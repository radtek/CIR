using System.Collections.Generic;
using Cir.Data.Access.Models;
using System.Threading.Tasks;
using Cir.Data.Access.DataAccess;
using System.Linq;
using Cir.Data.Access.Models.Authorization;
using System.Data;
using System;

namespace Cir.Data.Access.Services
{
    internal class UserDataService : IUserDataService
    {
        private readonly IList<IUserTable> _userTableServices;
        private readonly ICirTemplateRepository _cirTemplateRepository;
        private readonly IGroupUserBrandRepository _groupUserBrandRepository;
        private readonly ICirTemplateService _cirTemplateService;
        private readonly ICirSubmissionService _cirSubmissionService;
        private readonly ICimCaseService _cimCaseService;
        private readonly ICirSyncLogRepository _cirSyncLogRepository;
        private readonly IHotlistService _hotlistService;

        public UserDataService(ICirTemplateRepository cirTemplateRepository,
                               IGroupUserBrandRepository groupUserBrandRepository,
                               ICirTemplateService cirTemplateService,
                               ICirSubmissionService cirSubmissionService,
                               ICirBlobImageService cirBlobImageService,
                               IHotlistService hotlistService,
                               ICimCaseService cimCaseService,
                               ICirSyncLogRepository cirSyncLogRepository)
        {
            _userTableServices = new List<IUserTable>();
            _userTableServices.Add(cirBlobImageService);
            _cimCaseService = cimCaseService;
            _cirSyncLogRepository = cirSyncLogRepository;
            _cirTemplateRepository = cirTemplateRepository;
            _groupUserBrandRepository = groupUserBrandRepository;
            _cirTemplateService = cirTemplateService;
            _cirSubmissionService = cirSubmissionService;
            _hotlistService = hotlistService;
        }

        public async Task<IEnumerable<UserData>> GetMasterSyncData(UserInformation user)
        {
            List<CirTemplateDataModel> objTemplate = new List<CirTemplateDataModel>();
            var userDataList = new List<UserData>();
            var brandsIds = new List<string>();
            try
            {
                brandsIds = await _groupUserBrandRepository.GetAssignedBrandsIdsByUserEmailOrGroupName(user); 
            }
            catch (Exception ex) {

            }
            #region workaround for issue with ad group - brand assignment

            //get vestas brand related data for every user
            string vestasBrandId = "a1099c2e-b5a0-4c32-8a8d-e71ca8e1b831";
            string gamesaBrandId = "77b500d1-f7c6-4165-a60f-d0ba8e63e0eb";
            string generalElectricsBrandId = "281b4287-3909-4a8f-961d-873b193c9eac";
            string nordexBrandId = "zd1a9648-d549-4cce-bex1-a16953ecec2a";
            string siemensBrandId = "be1a9648-d339-4caf-beb0-a16953ecec1d";
            string suzlonBrandId = "419fb219-496c-4283-be46-0d9605bb636c";
            string accionaBrandId = "fa5fd8eb-926a-41ab-9acc-3ceeb75503a1";
            string senvionBrandId = "b5243b99-3d31-4bde-87c3-36d635e33011";
            string clipperBrandId = "56abe0df-16ef-48e3-b636-d4c80405b6ad";
            if (!brandsIds.Contains(vestasBrandId))
                brandsIds.Add(vestasBrandId);
            if (!brandsIds.Contains(gamesaBrandId))
                brandsIds.Add(gamesaBrandId);
            if (!brandsIds.Contains(generalElectricsBrandId))
                brandsIds.Add(generalElectricsBrandId);
            if (!brandsIds.Contains(nordexBrandId))
                brandsIds.Add(nordexBrandId);
            if (!brandsIds.Contains(siemensBrandId))
                brandsIds.Add(siemensBrandId);
            if (!brandsIds.Contains(suzlonBrandId))
                brandsIds.Add(suzlonBrandId);
            if (!brandsIds.Contains(accionaBrandId))
                brandsIds.Add(accionaBrandId);
            if (!brandsIds.Contains(senvionBrandId))
                brandsIds.Add(senvionBrandId);
            if (!brandsIds.Contains(clipperBrandId))
                brandsIds.Add(clipperBrandId);
            #endregion
            var tasks = new List<Task>
            {
                Task.Run(() =>
                {
                    userDataList.Add(new UserData
                    {
                        TableName = _cimCaseService.TableName,
                        DataList = _cimCaseService.GetTableData()
                    });
                }),
                Task.Run(() =>
                {
                    userDataList.Add(new UserData
                    {
                        TableName = _hotlistService.TableName,
                        DataList = _hotlistService.GetTableData(brandsIds)
                    });
                }),
                Task.Run(async () =>
                {
                    userDataList.Add(new UserData
                    {
                        TableName = _cirTemplateService.TableName,
                        DataList = (await _cirTemplateRepository.GetTemplatesByBrandIds(brandsIds)).ToList<object>()
                    });
                })
            };

            Task.WaitAll(tasks.ToArray());




            foreach (var tableName in userDataList.ToList())
            {
                if(tableName.TableName.ToLower() == "cirtemplates")
                {
                    foreach (CirTemplateDataModel objCirTemp in tableName.DataList.ToList())
                    {
                        objTemplate.Add(objCirTemp);
                    }

                    var dataListInDescending = objTemplate.OrderByDescending(x => x.VersionNumber).ToList();
                    var finalListOfCirTemplate = dataListInDescending.GroupBy(x => x.CirBrandCollectionName).Select(y => y.First()).ToList();

                    var cirs = _cirSyncLogRepository.GetAllRelatedToUser(user.DisplayName).Where(c => c.Data != null).OrderByDescending(c => c.ModifiedOn).ToList();
                    var TemplateVersionUsedInDraftCIRs = cirs.GroupBy(x => x.CirTemplateId).Select(y => y.First()).Distinct().Where(z => z.State == CirState.Draft).ToList();
                    TemplateVersionUsedInDraftCIRs.RemoveAll(a => finalListOfCirTemplate.Exists(z => z.Id == a.CirTemplateId));

                    foreach (var templateid in TemplateVersionUsedInDraftCIRs)
                    {
                        finalListOfCirTemplate.Add(_cirTemplateRepository.Get(templateid.CirTemplateId));
                    }

                    userDataList.Remove(tableName);

                    userDataList.Add(new UserData
                    {
                        TableName = _cirTemplateService.TableName,
                        DataList = finalListOfCirTemplate.ToList<object>()
                    });
                    
                }
            }

           
            HotlistDataModel objHotList1 = new HotlistDataModel();
            List<object> objHotList = new List<object>();

            foreach (var tableName in userDataList.ToList())
            {
                if (tableName.TableName.ToLower() == "hotlist")
                {
                    var dataListInDescending = objTemplate.OrderByDescending(x => x.VersionNumber).ToList();
                    var finalListOfCirTemplate = dataListInDescending.GroupBy(x => x.CirBrandCollectionName).Select(y => y.First()).ToList();
                    foreach (object objCirTemp in tableName.DataList.ToList())
                    {
                        objHotList1 = (HotlistDataModel)objCirTemp;
                        var latestGuidId = finalListOfCirTemplate.Where(x => x.CirBrand.Name == objHotList1.Brand.Name && x.Name == objHotList1.CirTemplate.Name).Select(x => x.Id).FirstOrDefault();
                        if (!(latestGuidId == null || latestGuidId == ""))
                        {
                            objHotList1.CirTemplate.Id = latestGuidId;
                            objHotList.Add(objHotList1);
                        }
                    }

                    userDataList.Remove(tableName);

                    userDataList.Add(new UserData
                    {
                        TableName = _hotlistService.TableName,
                        DataList = objHotList.ToList<object>()
                    });
                }
            }

            



            return userDataList;
        }

        public async Task<IEnumerable<UserData>> GetData(UserInformation user)
        {

            List<CirTemplateDataModel> objTemplate = new List<CirTemplateDataModel>();
            var userDataList = (await GetMasterSyncData(user)).ToList();
            var cirs = _cirSyncLogRepository.GetAllRelatedToUser(user.DisplayName).Where(c => c.Data != null).ToList();
            var mainCollectionCirs = _cirSyncLogRepository.GetAllMainCollectionCirRelatedToUser(user.DisplayName).Where(c => c.Data != null).ToList();
            foreach (var report in mainCollectionCirs.Where(c => c.DeletedFromCache != "true").ToList())
            {
                cirs.Add(report);
            }
            userDataList.Add(new UserData
            {
                TableName = _cirSubmissionService.TableName,
                DataList = cirs.ToList<object>()
            });

            Task.WaitAll(_userTableServices.Select(repo => Task.Run(async () =>
            {
                var userData = new UserData
                {
                    TableName = repo.TableName,
                    DataList = await repo.GetTableData(cirs)
                };

                userDataList.Add(userData);
            })).ToArray());

            return userDataList;
        }
    }
}
