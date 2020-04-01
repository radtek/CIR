using System;
using Cir.Data.Access.CirSyncService;

namespace Cir.Data.Access.Validation
{
    internal class TurbineNumberValidation : IValidation
    {
        public const string MethodKey = "TurbineNumber";
        public static string DisplayKey => MethodKey;
        public string Name => "Turbine Number";
        private readonly SyncServiceClient _serviceClient;

        public TurbineNumberValidation()
        {
            _serviceClient = new SyncServiceClient("WSHttpBinding_ISyncService");
        }

        [Validation(Key = MethodKey,
            DisplayName = "Turbine Number",
            DataKeys = new string[] { "turbineNumberControlId" },
            DataNames = new string[] { "Turbine Number" })]
        public bool IsValid(dynamic cirSubmission, dynamic rule)
        {
            var turbineNumber = cirSubmission.Data[rule.turbineNumberControlId.Value];
            return _serviceClient.ValidateTurbineNumber(Convert.ToString(turbineNumber));
        }
    }
}
