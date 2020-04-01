using AutoFixture;
using AutoFixture.AutoMoq;
using DeepEqual.Syntax;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;

// This allows us to pass anonymous objects from this assembly as dynamic parameters.
// An alternative would be to use an ExpandoObject instead of an anonymous type, but ExpandoObject does not support object initializers.
[assembly: InternalsVisibleTo("Cir.Azure.Functions")]
#if false
namespace Cir.Azure.Functions.Test.Converter
{
    
    public class RepairDetailsConverterTest
    {
        private RepairDetailsConverter sut;
        private dynamic repair;
        private RepairDetailsDto dto;
        private Fixture fixture;


        public RepairDetailsConverterTest()
        {
            fixture = new Fixture();
            fixture.Customize(new AutoMoqCustomization());

            sut = new RepairDetailsConverter();

            repair = new
            {
                cirSubmissionData = new
                {
                    id = fixture.Create<string>(),
                    data = new
                    {
                        txtTurbineNumber = fixture.Create<long>(),
                        txtBladeSerialNumber = fixture.Create<string>(),
                        //dtInspectionDate = fixture.Create<DateTime>().ToString("yyyy-MM-dd"),
                        dtInspectionDate = fixture.Create<DateTime>().ToString("yyyy-MM-ddTHH:mm:ssZ"),
                        imagecomponentKey = new
                        {
                            damageId = fixture.Create<string>(),
                            damageGuid = fixture.Create<string>(),
                            repairSteps = new IRepairStep[]
                            {
                                //new
                                //{
                                //    type = "Lamination",
                                //    description = fixture.Create<string>()
                                //    // TODO
                                //}
                            }
                        }
                    }
                }
            };

            dto = new RepairDetailsDto
            {
                Repair = new RepairDetails
                {
                    BladeId = repair.cirSubmissionData.data.txtBladeSerialNumber,
                    DamageGuid = repair.cirSubmissionData.data.imagecomponentKey.damageGuid,
                    DamageId = repair.cirSubmissionData.data.imagecomponentKey.damageId,
                    Date = repair.cirSubmissionData.data.dtInspectionDate,
                    RepairId = repair.cirSubmissionData.id,
                    TurbineId = repair.cirSubmissionData.data.txtTurbineNumber.ToString(),
                    Steps = new List<IRepairStep>
                    {
                        //new LaminationRepairStep
                        //{
                        //   // HeatersInsulationCoverAndVacuumOff // TODO
                        //}
                    }
                }
            };
        }

        [Fact]
        public void Null()
        {
            Assert.Throws<ArgumentNullException>(() => sut.Convert(null));
        }

        [Fact]
        public void Ok()
        {
            RepairDetailsDto actual = sut.Convert(repair);
            actual.ShouldDeepEqual(dto);
        }
        
    }
}
#endif