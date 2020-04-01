using System;
using Microsoft.Azure.Documents.Client;
using System.Collections.Generic;
using System.Linq;
using Cir.Data.Access.Models;
using Cir.Data.Access.DataAccess;
using System.IO;
using System.Reflection;
using Newtonsoft.Json.Linq;
using Cir.Data.Access.DataAccessDynamic;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;

namespace Cir.Data.Multibrand.Database.Integration.Tests
{
    public class DatabaseGenerator : IDisposable
    {
        public DatabaseGenerator()
        {
            InitRepositories();
            SetupJsonSchemaAndData();
            SetupDatabase();
            SetupStaticCollections();
            SetupStoredProcedures();
            PopulateStaticCollections();
            SetupDynamicCollections();
            PopulateDynamicCollections();
        }

        //Readonly properties accessible for tests
        internal string Type1Name => "Gearbox";
        internal string Type2Name => "BladeInspection";
        internal string Brand1Name => "Vestas";
        internal string TestGroupName => "test"; //This name is copied from existing legacy data on Client's premise
        internal string Example1CollectionName => COLLECTION_NAME_REPORT_COMMON_PREFIX + Brand1Name + Type1Name;
        internal string EmailUser1 => "majnc";
        internal string EmailUser2 => "viluk";
        internal string EmailUser3 => "arkor";
        internal string EmailUser4 => "ARKAK";
        internal IGroupUserBrandRepository GroupUserBrandRepository => _groupUserBrandRepository;
        internal ICirTemplateRepository CirTemplateRepository => _cirTemplateRepository;
        internal ICirSubmissionDataDynamicRepository CirSubmissionDataDynamicRepository => _cirSubmissionDataDynamicRepository;
        internal ICirIdRepository CirIdRepository => _cirIdRepository;
        internal ICirSubmissionHistoricDataRepository CirHistoryRepository => _cirHistoryRepository;
        internal IBrandDataRepository BrandDataRepository => _brandDataRepository;
        internal IHotlistRepository HotlistRepository => _hotlistRepository;
        internal string VestasGearboxReportExampleId => Guids[0];
        private List<string> _dynamicReportCollectionsNames;
        private List<CirTemplateShortDataModel> _shortTemplates;
        private HashSet<BrandDataModel> _brands;

        const string ENDPOINT_URL = "https://cir-multibrand-database.documents.azure.com:443/";
        const string PRIMARY_KEY = "AzwD1y1LhnuIw85yrLaRRH6CiHhwaEst09o4OhwjydGr0gsi0PHXuaGReeb7iAO9vi0XY1XnKmpQXcJkkLCqIA==";
        const string DATABASE_NAME = "CirMultibrand";
        const string blobConnectionString = "DefaultEndpointsProtocol=https;AccountName=cirblobstoragedev;AccountKey=MeW/7vHcnbWXi2NU7Fl0r/DgiQK1ARiqfRLXZp8BsrPArm9TG4t1ZH0xWz5ZkXUWmqFmNcIxYBw9k9iXkjGMGA==;EndpointSuffix=core.windows.net";
        const string BLOB_CONTAINER_NAME = "cirdevcontainer";
        const string COLLECTION_NAME_REPORT_COMMON_PREFIX = "CirReport";
        const string COLLECTION_NAME_TEMPLATES = "CirTemplates";
        const string COLLECTION_NAME_BRAND = "Brand";
        const string COLLECTION_NAME_GROUP_USER_BRAND = "GroupUserBrand";
        const string COLLECTION_NAME_CIRID = "CirId";
        const string COLLECTION_NAME_CIRHISTORY = "CirReportHistory";
        const string COLLECTION_NAME_INTEGRATIONREQUESTS = "IntegrationRequests";
        const string COLLECTION_NAME_MESSAGES = "Messages";
        const string COLLECTION_NAME_HOTLIST = "HotList";
        const string COLLECTION_NAME_SYNC_LOG = "CirSyncLog";
        const string PROC_NAME_NEXTCIRID = "GetNextCirId";

        private string _exampleSchema;
        private string _exampleData;
        private string _databaseSelfLink;
        private DocumentClient _documentClient = new DocumentClient(new Uri(ENDPOINT_URL), PRIMARY_KEY);
        private Microsoft.Azure.Documents.Database _database = new Microsoft.Azure.Documents.Database { Id = DATABASE_NAME };
        private BaseRepository _baseRepository;
        private IGroupUserBrandRepository _groupUserBrandRepository;
        private ICirTemplateRepository _cirTemplateRepository;
        private ICirSubmissionDataDynamicRepository _cirSubmissionDataDynamicRepository;
        private CirImageStorageRepository _cirImageStorageRepository;
        private ICirIdRepository _cirIdRepository;
        private ICirSubmissionHistoricDataRepository _cirHistoryRepository;
        private IBrandDataRepository _brandDataRepository;
        private IHotlistRepository _hotlistRepository;
        private List<string> _allTemplatesIds;
        private string _cirReportVestasGearboxId;

        public List<HotlistDataModel> Hotlists => new List<HotlistDataModel>
        {
            new HotlistDataModel
            {
                Id = Guids[0],
                CirTemplate = _shortTemplates.FirstOrDefault(template => Equals(template.Name, "MainBearing")),
                Brand = _brands.FirstOrDefault(),
                Email = "cim-hotlist@vestas.com",
                ReportType = "Main Bearing",
                VestasItemNumber = "60079255",
                VestasItemName = "BEARING 240/630 ECJ/W33C2 RE10",
                ManufacturerName = "SKF",
                HotItemDisplay = "60079255 [Main Bearing]: BEARING 240/630 ECJ/W33C2 RE10",
                HotItemId = 246,
                ReportTypeId = 6
            },
            new HotlistDataModel
            {
                Id = Guids[1],
                CirTemplate = _shortTemplates.FirstOrDefault(template => Equals(template.Name, "MainBearing")),
                Brand = _brands.FirstOrDefault(),
                Email = "cim-hotlist@vestas.com",
                ReportType = "Main Bearing",
                VestasItemNumber = "60072935",
                VestasItemName = "Main bearing assembly, NM72/82",
                ManufacturerName = "Vestas Assembly A/S",
                HotItemDisplay = "60072935 [Main Bearing]: Main bearing assembly, NM72/82",
                HotItemId = 23,
                ReportTypeId = 6
            }
        };

        public HotlistDataModel HotlistDataModelTestExample => new HotlistDataModel
        {
            Id = Guids[2],
            CirTemplate = _shortTemplates.FirstOrDefault(template => Equals(template.Name, "MainBearing")),
            Brand = _brands.FirstOrDefault(),
            Email = "test",
            ReportType = "test",
            VestasItemNumber = "test",
            VestasItemName = "test",
            ManufacturerName = "test",
            HotItemDisplay = "test",
            HotItemId = 12345678,
            ReportTypeId = 12345678
        };

    private JObject ExampleSchema => JObject.Parse(_exampleSchema);
        private JObject ExampleData => JObject.Parse(_exampleData);
        private List<string> TypeNames => new List<string> { Type1Name, Type2Name };
        internal List<string> Guids => new List<string>
        {
            "a1099c2e-b5a0-4c32-8a8d-e71ca8e1b831",
            "be1a9648-d339-4caf-beb0-a16953ecec1d",
            "7db89a64-31f8-4a55-983b-3e8ec2c9e809",
            "45e02854-3b7b-48d6-8c8a-0625c9d9c88c",
            "10e9327c-7b9f-4c1b-9acc-5de22950cc77",
            "062ee2c4-dabd-472c-99eb-f07283876e69"
        };

        internal List<string> UsersEmails => new List<string>
        {
            "aasin",
            "akgpt",
            //"arkor",
            //"ARKAK",
            "ASKMR",
            "crose",
            "ciradmin",
            "ciraduser",
            "dessi",
            "dirra",
            "hasam",
            "JUJEH",
            "kuasm",
            "ledje",
            "mamlk",
            "maagl",
            //"majnc",
            "mukul_keshari",
            "mukes",
            "nishm",
            "pamik",
            "pakgu",
            "paoma",
            "pirom",
            "PRAGA",
            "ramkk",
            "REBAT",
            "rebat",
            "shrav",
            "shrwt",
            "shjmi",
            "susig",
            "sunig",
            "surja",
            "TEST1",
            "TEST3",
            //"viluk",
            "yokum",
            "TEST1",
            "TEST2",
            "TEST3",
            "TEST4",
            "TEST5",
            "TEST6"
        };

        internal List<string> AllTemplatesIds => _allTemplatesIds;

        List<GroupUserBrand> GroupsAndUsers
        {
            get
            {
                var user1 = new GroupUserBrand
                {
                    Id = Guids[0],
                    Email = EmailUser1,
                    Brands = new List<string> { Guids[0] }
                };

                var user2 = new GroupUserBrand
                {
                    Id = Guids[1],
                    Email = EmailUser2,
                    Brands = new List<string> { Guids[1] }
                };

                var user3 = new GroupUserBrand
                {
                    Id = Guids[2],
                    Email = EmailUser3,
                    Brands = new List<string> { Guids[0] }
                };

                var user4 = new GroupUserBrand
                {
                    Id = Guids[3],
                    Email = EmailUser4,
                    Brands = new List<string> { Guids[0], Guids[1] }
                };

                var group1 = new GroupUserBrand
                {
                    Id = Guids[4],
                    Name = TestGroupName,
                    Brands = new List<string> { Guids[0], }
                };

                var users = new List<GroupUserBrand>();

                UsersEmails.ForEach(email => users.Add(new GroupUserBrand
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = email,
                    Brands = new List<string> { Guids[0] }
                }));

                return new List<GroupUserBrand>(users) { user1, user2, user3, user4, group1 };
            }
        }

        private static DataRepositoryConfig GetDataRepositoryConfig(string collectionName)
        {
            return new DataRepositoryConfig(
                DATABASE_NAME,
                collectionName
            );
        }

        private static BlobStorageConfig GetBlobStorageConfig(string containerName)
        {
            return new BlobStorageConfig(
                blobConnectionString,
                containerName
            );
        }

        private void InitRepositories()
        {
            _baseRepository = new BaseRepository(ENDPOINT_URL, PRIMARY_KEY);
            _groupUserBrandRepository = new GroupUserBrandRepository(GetDataRepositoryConfig(COLLECTION_NAME_GROUP_USER_BRAND), _baseRepository);
            _cirTemplateRepository = new CirTemplateRepository(GetDataRepositoryConfig(COLLECTION_NAME_TEMPLATES), _baseRepository);
            _cirIdRepository = new CirIdRepository(GetDataRepositoryConfig(COLLECTION_NAME_CIRID), _baseRepository);
            _cirImageStorageRepository = new CirImageStorageRepository(GetBlobStorageConfig(BLOB_CONTAINER_NAME));
            _cirHistoryRepository =
                new CirSubmissionHistoricDataRepository(GetDataRepositoryConfig(COLLECTION_NAME_CIRHISTORY), _baseRepository, _cirImageStorageRepository);
            //_cirSubmissionDataDynamicRepository = new CirSubmissionDataDynamicRepository(GetDataRepositoryConfig(""), _baseRepository,
            //    _cirIdRepository, _cirHistoryRepository);

            _brandDataRepository = new BrandDataRepository(GetDataRepositoryConfig(COLLECTION_NAME_BRAND), _baseRepository);
            _hotlistRepository = new HotlistRepository(GetDataRepositoryConfig(COLLECTION_NAME_HOTLIST), _baseRepository);
        }

        private void SetupJsonSchemaAndData()
        {
            _exampleSchema = File.ReadAllText(
                Path.Combine(Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location), @"exampleSchema.json"));

            _exampleData = File.ReadAllText(
                Path.Combine(Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location), @"exampleData.json"));
        }

        private void SetupDatabase()
        {
            _documentClient.CreateDatabaseAsync(_database).Wait();

            Microsoft.Azure.Documents.Database database = _documentClient.CreateDatabaseQuery().Where(db => db.Id == DATABASE_NAME).ToArray().SingleOrDefault();

            if (database == null) throw new Exception("Failed to setup database: " + DATABASE_NAME);

            _databaseSelfLink = database.SelfLink;
        }

        private void SetupStaticCollections()
        {
            var list = new List<string>
            {
                COLLECTION_NAME_TEMPLATES,
                COLLECTION_NAME_BRAND,
                COLLECTION_NAME_GROUP_USER_BRAND,
                COLLECTION_NAME_CIRID,
                COLLECTION_NAME_CIRHISTORY,
                COLLECTION_NAME_INTEGRATIONREQUESTS,
                COLLECTION_NAME_MESSAGES,
                COLLECTION_NAME_HOTLIST,
                COLLECTION_NAME_SYNC_LOG
            };

            list.ForEach(collectionName => SetupCollection(collectionName));
        }

        private void SetupDynamicCollections()
        {
            var list = new List<string>();

            if (_dynamicReportCollectionsNames == null) return;

            _dynamicReportCollectionsNames.ForEach(collectionName => SetupCollection(collectionName));
        }

        private void SetupCollection(string collectionId)
        {
            var collection = new DocumentCollection { Id = collectionId };

            collection.PartitionKey.Paths.Add("/partition");

            _documentClient.CreateDocumentCollectionAsync(
                _databaseSelfLink,
                collection,
                new RequestOptions { OfferThroughput = 400 })
                .Wait();
        }

        private void PopulateStaticCollections()
        {
            PopulateTemplatesCollection();
            PopulateBrandsCollection();
            PopulateGroupUsersCollection();
            PopulateCirId();
            PopulateHotlistCollection();
        }

        private void PopulateBrandsCollection()
        {
            _brands.ToList().ForEach(b => _brandDataRepository.Add(b));
        }

        private void PopulateTemplatesCollection()
        {
            _dynamicReportCollectionsNames = new List<string>();
            _shortTemplates = new List<CirTemplateShortDataModel>();
            _brands = new HashSet<BrandDataModel>();
            _allTemplatesIds = new List<string>();

            ReadTemplatesFromSolutionFilesAndInsertIntoCollection();
        }

        private void PopulateHotlistCollection()
        {
            Hotlists.ForEach(hotlist => _hotlistRepository.Add(hotlist));
        }

        private void ReadTemplatesFromSolutionFilesAndInsertIntoCollection()
        {
            var files = new DirectoryInfo(Path.GetFullPath(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\..\..\CIRTemplates_Form.io")))
                .GetFiles("*.json").ToList();

            files.ForEach(f => SetupTemplateAndCollectionName(f.FullName));
        }

        private void SetupTemplateAndCollectionName(string path)
        {
            var template = ReadTemplate(path);

            if (template != null)
            {
                _dynamicReportCollectionsNames.Add(template.CirBrandCollectionName);
                _cirTemplateRepository.Add(template);
                _allTemplatesIds.Add(template.Id);
                _shortTemplates.Add(new CirTemplateShortDataModel
                {
                    Id = template.Id,
                    Name = template.Name
                });

                _brands.Add(new BrandDataModel()
                {
                    Id = template.CirBrand.Id,
                    Name = template.CirBrand.Name
                });

                if (template.Name.Contains("Gearbox")) _cirReportVestasGearboxId = template.Id;
            }
        }

        private CirTemplateDataModel ReadTemplate(string path)
        {
            CirTemplateDataModel template = null;

            try
            {
                template = JsonConvert.DeserializeObject<CirTemplateDataModel>(File.ReadAllText(path));
            }
            catch { }

            return template;
        }

        private void PopulateGroupUsersCollection()
        {
            GroupsAndUsers.ForEach(u => _groupUserBrandRepository.Add(u));
        }

        private void PopulateCirId()
        {
            _documentClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(_database.Id, COLLECTION_NAME_CIRID), new CirIdModel
                {
                    CirId = 400030,
                    IsCounter = true
                }).Wait();
        }

        private void SetupStoredProcedures()
        {
            CreateCirIdProcedure();
        }

        private void CreateCirIdProcedure()
        {
            var cirIdProcedure = new StoredProcedure
            {
                Id = PROC_NAME_NEXTCIRID,
                        Body = $@"
                        function getNextCirId(cirBrandCollectionName) {{
                            var context = getContext();
                            var collection = context.getCollection();
                            var collectionLink = collection.getSelfLink();
                            var response = context.getResponse();

                            var latestCirIdQuery = ""SELECT TOP 1 * FROM {COLLECTION_NAME_CIRID} c WHERE c.counter = true ORDER BY c.cirId DESC"";

                            collection.queryDocuments(collectionLink, latestCirIdQuery, {{}},
                                function(err, documents, responseOptions) {{
                                    if (err) throw err;
                                    if (documents.length != 1) throw ""Unable to find latest CirId"";

                                    var currentCirId = documents[0];
									currentCirId.cirId = currentCirId.cirId + 1;
                                    currentCirId.cirBrandCollectionName = cirBrandCollectionName;
                                    var isSuccessful = collection.replaceDocument(currentCirId._self, currentCirId, {{etag: currentCirId._etag}}, function(err, doc, options) {{
                                        if (err) throw err;

                                        response.setBody(doc);
                                    }});

                            if (!isSuccessful) throw ""Request to CirId collection failed"";
                            }});
                        }};",
            };

            _documentClient.CreateStoredProcedureAsync(
                UriFactory.CreateDocumentCollectionUri(_database.Id, COLLECTION_NAME_CIRID), cirIdProcedure).Wait();
        }

        private void PopulateDynamicCollections()
        {
            var collectionName = COLLECTION_NAME_REPORT_COMMON_PREFIX + "VestasGearbox";

            _cirSubmissionDataDynamicRepository.Add(new CirSubmissionData
            {
                Id = Guids[0],
                CirTemplateId = _cirReportVestasGearboxId,
                Schema = ExampleSchema,
                Data = ExampleData,
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                CreatedBy = EmailUser1,
                ModifiedBy = EmailUser1,
                State = CirState.Draft,
                CirCollectionName = collectionName
            },
            collectionName);
        }

        public void Dispose()
        {
            _documentClient.DeleteDatabaseAsync(_databaseSelfLink).Wait();
        }
    }
}
