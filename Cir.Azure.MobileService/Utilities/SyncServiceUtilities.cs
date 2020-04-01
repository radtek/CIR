using Microsoft.WindowsAzure.Mobile.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Cir.Azure.MobileService.Utilities
{
    public class SyncServiceUtilities
    {
        string _ServiceUrl;
        CirSyncService.SyncServiceClient _ServiceClient;
        public string ServiceUrl { get { return _ServiceUrl; } }


        System.ServiceModel.WSHttpBinding SyncServiceBinding = null;
        System.ServiceModel.EndpointAddress SyncServiceEndpoint = null;


        CirSyncService.SyncServiceClient ServiceClient
        {
            get
            {
                if (_ServiceClient == null)
                {
                    SyncServiceBinding = new System.ServiceModel.WSHttpBinding(SecurityMode.None);
                    SyncServiceBinding.SendTimeout = new TimeSpan(00, 05, 00);
                    SyncServiceEndpoint = new System.ServiceModel.EndpointAddress(ServiceUrl);
                    _ServiceClient = new CirSyncService.SyncServiceClient(SyncServiceBinding, SyncServiceEndpoint);
                }
                return _ServiceClient;
            }
        }

        public SyncServiceUtilities(ApiServices Services)
        {
            Services.Settings.TryGetValue("Cir_Sync_Service_Url", out _ServiceUrl);
        }
        public SyncServiceUtilities(string Url)
        {
            _ServiceUrl = Url;
        }

        public List<Cir.Azure.MobileService.CirSyncService.CirMasterData> GetMasterData()
        {
            return ServiceClient.GetMasterData().ToList<Cir.Azure.MobileService.CirSyncService.CirMasterData>();
        }

        public string SaveCir(string CirJson)
        {
            return ServiceClient.SaveCIRData(CirJson);
        }
    }
}