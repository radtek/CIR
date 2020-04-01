namespace Cir.Data.Access.Models
{
    internal class SapValidationConfig
    {
        public string UseSapWebService { get; private set; }
        public string SapWebServiceUserName { get; private set; }
        public string SapWebServicePassword { get; private set; }
        public string SapNotificationNumberWebServiceUrl { get; private set; }
        public string SapServiceReportNumberWebServiceUrl { get; private set; }

        public SapValidationConfig(string useSapWebService, 
            string sapWebServiceUserName, 
            string sapWebServicePassword, 
            string sapNotificationNumberWebServiceUrl, 
            string sapServiceReportNumberWebServiceUrl)
        {
            UseSapWebService = useSapWebService;
            SapWebServiceUserName = sapWebServiceUserName;
            SapWebServicePassword = sapWebServicePassword;
            SapNotificationNumberWebServiceUrl = sapNotificationNumberWebServiceUrl;
            SapServiceReportNumberWebServiceUrl = sapServiceReportNumberWebServiceUrl;
        }
    }
}
