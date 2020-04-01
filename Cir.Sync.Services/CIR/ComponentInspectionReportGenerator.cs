using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cir.Sync.Services.CIR
{
    public class ComponentInspectionReportGenerator
    {       
        public long ComponentInspectionReportGeneratorId
        {
            get;
            set;
        }
        public long ComponentInspectionReportId
        {
            get;
            set;
        }
        public string VestasUniqueIdentifier
        {
            get;
            set;
        }
        public long GeneratorManufacturerId
        {
            get;
            set;
        }
        public string GeneratorSerialNumber
        {
            get;
            set;
        }
        public string OtherManufacturer
        {
            get;
            set;
        }
        public decimal GeneratorMaxTemperature
        {
            get;
            set;
        }
        public DateTime GeneratorMaxTemperatureResetDate
        {
            get;
            set;
        }
        public string strGeneratorMaxTemperatureResetDate
        {
            get;
            set;
        }
        public long CouplingId
        {
            get;
            set;
        }
        public long ActionToBeTakenOnGeneratorId
        {
            get;
            set;
        }
        public long GeneratorDriveEndId
        {
            get;
            set;
        }
        public long GeneratorNonDriveEndId
        {
            get;
            set;
        }
        public long GeneratorRotorId
        {
            get;
            set;
        }
        public long GeneratorCoverId
        {
            get;
            set;
        }
        public long? AirToAirCoolerInternalId
        {
            get;
            set;
        }
        public long? AirToAirCoolerExternalId
        {
            get;
            set;
        }
        public string GeneratorComments
        {
            get;
            set;
        }
        public decimal? UGround
        {
            get;
            set;
        }
        public decimal? VGround
        {
            get;
            set;
        }
        public decimal? WGround
        {
            get;
            set;
        }
        public decimal? UV
        {
            get;
            set;
        }
        public decimal? UW
        {
            get;
            set;
        }
        public decimal? VW
        {
            get;
            set;
        }
        public decimal? KGround
        {
            get;
            set;
        }
        public decimal? LGround
        {
            get;
            set;
        }
        public decimal? MGround
        {
            get;
            set;
        }
        public long? UGroundOhmUnitId
        {
            get;
            set;
        }
        public long? VGroundOhmUnitId
        {
            get;
            set;
        }
        public long? WGroundOhmUnitId
        {
            get;
            set;
        }
        public long? UVOhmUnitId
        {
            get;
            set;
        }
        public long? UWOhmUnitId
        {
            get;
            set;
        }
        public long? VWOhmUnitId
        {
            get;
            set;
        }
        public long? KGroundOhmUnitId
        {
            get;
            set;
        }
        public long? LGroundOhmUnitId
        {
            get;
            set;
        }
        public long? MGroundOhmUnitId
        {
            get;
            set;
        }
        public long? U1U2
        {
            get;
            set;
        }
        public long? V1V2
        {
            get;
            set;
        }
        public long? W1W2
        {
            get;
            set;
        }
        public long? K1L1
        {
            get;
            set;
        }
        public long? L1M1
        {
            get;
            set;
        }
        public long? K1M1
        {
            get;
            set;
        }

        
        public long? K2L2
        {
            get;
            set;
        }
        public long? L2M2
        {
            get;
            set;
        }
        public long? K2M2
        {
            get;
            set;
        }
        public bool GeneratorRewoundLocally
        {
            get;
            set;
        }
        public long? GeneratorClaimRelevantBooleanAnswerId
        {
            get;
            set;
        }
        public bool InsulationComments
        {
            get;
            set;
        }
        public string GeneratorInsulationComments
        {
            get;
            set;
        }
    }
}