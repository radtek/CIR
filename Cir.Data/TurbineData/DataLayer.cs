using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Cir.Common.TurbineData;
using System.Data;

namespace Cir.Data.TurbineData
{
    public class DataLayer : BaseDataLayer
    {
        public DataLayer(string connectionString)
            : base(connectionString)
        {
        }

        /// <summary>
        /// Gets the turbine data for a given turbine ID
        /// </summary>
        public TurbineProperties GetTurbineData(string turbineId)
        {
            long turbineMatrixId = 0;
            string turbine = string.Empty;
            byte frequency = 0;
            string manufacturer = string.Empty;
            string markVersion = string.Empty;
            int nominelPower = 0;
            long nominelPowerId = 0;
            string placement = string.Empty;
            string powerRegulation = string.Empty;
            decimal rotorDiameter = 0;
            int smallGenerator = 0;
            string temperatureVariant = string.Empty;
            int voltage = 0;
            int countryIsoId = 0;
            string country = string.Empty;
            string site = string.Empty;
            string localTurbineId = string.Empty;

            using (DataAccessAdapter daa = GetDataAccessAdapter())
            {
                ActionProcedures.TurbineDataGet(
                    turbineId,
                    ref turbineMatrixId,
                    ref turbine,
                    ref frequency,
                    ref manufacturer,
                    ref markVersion,
                    ref nominelPower,
                    ref nominelPowerId,
                    ref placement,
                    ref powerRegulation,
                    ref rotorDiameter,
                    ref smallGenerator,
                    ref temperatureVariant,
                    ref voltage,
                    ref countryIsoId,
                    ref country,
                    ref site,
                    ref localTurbineId,
                    daa);
            }

            return new TurbineProperties
            {
                Country = country,
                CountryIsoId = countryIsoId,
                Frequency = frequency,
                LocalTurbineId = localTurbineId,
                Manufacturer = manufacturer,
                MarkVersion = markVersion,
                NominelPower = nominelPower,
                NominelPowerId = nominelPowerId,
                Placement = placement,
                PowerRegulation = powerRegulation,
                RotorDiameter = rotorDiameter,
                Site = site,
                SmallGenerator = smallGenerator,
                TemperatureVariant = temperatureVariant,
                Turbine = turbine,
                TurbineMatrixId = turbineMatrixId,
                Voltage = voltage
            };
        }


        ///// <summary>
        ///// Gets the turbine data for a given turbine ID
        ///// </summary>
        //public void GetTurbineData(string turbineId, 
        //    ref long turbineMatrixId, ref string turbine, ref byte frequency, ref string manufacturer, ref string markVersion, 
        //    ref int nominelPower, ref long nominelPowerId, ref string placement, ref string powerRegulation, ref decimal rotorDiameter, 
        //    ref int smallGenerator, ref string temperatureVariant, ref int voltage, ref int countryIsoId, ref string country, 
        //    ref string site, ref string localTurbineId) {
        //    using (DataAccessAdapter daa = GetDataAccessAdapter()) {
        //        ActionProcedures.TurbineDataGet(
        //            turbineId,
        //            ref turbineMatrixId,
        //            ref turbine,
        //            ref frequency,
        //            ref manufacturer,
        //            ref markVersion,
        //            ref nominelPower,
        //            ref nominelPowerId,
        //            ref placement,
        //            ref powerRegulation,
        //            ref rotorDiameter,
        //            ref smallGenerator,
        //            ref temperatureVariant,
        //            ref voltage,
        //            ref countryIsoId,
        //            ref country,
        //            ref site,
        //            ref localTurbineId, 
        //            daa);
        //    }
        //}

        /// <summary>
        /// Whether a turbine exists in the turbine data table
        /// </summary>
        /// <param name="turbineId"></param>
        /// <param name="environment"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool TurbineExists(string turbineId)
        {
            using (DataAccessAdapter daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<TurbineDataEntity>(new TurbineDataEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(TurbineDataFields.TurbineId == turbineId);
                daa.FetchEntityCollection(ec, fb, 2);

                if (ec.Count == 1)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Get contract name
        /// </summary>
        /// <param name="turbineID"></param>
        /// <returns></returns>
        public string GetContractName(long turbineID)
        {
            DataTable dt;
            string ContractName = string.Empty;
            using (DataAccessAdapter daa = GetDataAccessAdapter())
            {
                dt = RetrievalProcedures.GetContractHolder
                     (
                         turbineId: turbineID,
                         adapter: daa
                     );
            }
            if (!ReferenceEquals(dt, null) && dt.Rows.Count > 0)
                ContractName = dt.Rows[0][0].ToString();

            return ContractName;
        }
    }
}
