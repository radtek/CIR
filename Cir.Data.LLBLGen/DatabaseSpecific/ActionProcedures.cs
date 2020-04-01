///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.5
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SqlServerSpecific.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
#if !CEDesktop
using System;
using System.Data;
using System.Data.SqlClient;

namespace Cir.Data.LLBLGen.DatabaseSpecific
{
	/// <summary>
	/// Class which contains the static logic to execute action stored procedures in the database.
	/// </summary>
	public partial class ActionProcedures
	{
		/// <summary>
		/// private CTor so no instance can be created.
		/// </summary>
		private ActionProcedures()
		{
		}

	
		/// <summary>
		/// Delegate definition for stored procedure 'SaveBIRCIRValueinDatabase' to be used in combination of a UnitOfWork2 object. 
		/// </summary>
		public delegate int SaveBircirvalueinDatabaseCallBack(System.Int64 masterCirid, System.String cirids, System.String repairingSol, System.String rawMaterial, System.String conculsionRecomm, System.String turbineId, System.String createdby, ref System.Int32 returnvalue, DataAccessAdapter adapter);

		/// <summary>
		/// Calls stored procedure 'SaveBIRCIRValueinDatabase'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="masterCirid">Input parameter of stored procedure</param>
		/// <param name="cirids">Input parameter of stored procedure</param>
		/// <param name="repairingSol">Input parameter of stored procedure</param>
		/// <param name="rawMaterial">Input parameter of stored procedure</param>
		/// <param name="conculsionRecomm">Input parameter of stored procedure</param>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <param name="createdby">Input parameter of stored procedure</param>
		/// <param name="returnvalue">InputOutput parameter of stored procedure</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int SaveBircirvalueinDatabase(System.Int64 masterCirid, System.String cirids, System.String repairingSol, System.String rawMaterial, System.String conculsionRecomm, System.String turbineId, System.String createdby, ref System.Int32 returnvalue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter())
			{
				return SaveBircirvalueinDatabase(masterCirid, cirids, repairingSol, rawMaterial, conculsionRecomm, turbineId, createdby, ref returnvalue,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'SaveBIRCIRValueinDatabase'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="masterCirid">Input parameter of stored procedure</param>
		/// <param name="cirids">Input parameter of stored procedure</param>
		/// <param name="repairingSol">Input parameter of stored procedure</param>
		/// <param name="rawMaterial">Input parameter of stored procedure</param>
		/// <param name="conculsionRecomm">Input parameter of stored procedure</param>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <param name="createdby">Input parameter of stored procedure</param>
		/// <param name="returnvalue">InputOutput parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int SaveBircirvalueinDatabase(System.Int64 masterCirid, System.String cirids, System.String repairingSol, System.String rawMaterial, System.String conculsionRecomm, System.String turbineId, System.String createdby, ref System.Int32 returnvalue, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[8];
			parameters[0] = new SqlParameter("@MasterCIRID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, masterCirid);
			parameters[1] = new SqlParameter("@CIRIDs", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, cirids);
			parameters[2] = new SqlParameter("@RepairingSol", SqlDbType.NVarChar, 4000, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, repairingSol);
			parameters[3] = new SqlParameter("@RawMaterial", SqlDbType.NVarChar, 4000, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, rawMaterial);
			parameters[4] = new SqlParameter("@ConculsionRecomm", SqlDbType.NVarChar, 4000, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, conculsionRecomm);
			parameters[5] = new SqlParameter("@TurbineID", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, turbineId);
			parameters[6] = new SqlParameter("@Createdby", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, createdby);
			parameters[7] = new SqlParameter("@RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, returnvalue);
			int toReturn = adapter.CallActionStoredProcedure("[CIM_ComponentInspectionReports].[dbo].[SaveBIRCIRValueinDatabase]", parameters);
			if(parameters[7].Value!=System.DBNull.Value)
			{
				returnvalue = (System.Int32)parameters[7].Value;
			}
			return toReturn;
		}
		

		/// <summary>
		/// Calls stored procedure 'SaveBIRCIRValueinDatabase'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="masterCirid">Input parameter of stored procedure</param>
		/// <param name="cirids">Input parameter of stored procedure</param>
		/// <param name="repairingSol">Input parameter of stored procedure</param>
		/// <param name="rawMaterial">Input parameter of stored procedure</param>
		/// <param name="conculsionRecomm">Input parameter of stored procedure</param>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <param name="createdby">Input parameter of stored procedure</param>
		/// <param name="returnvalue">InputOutput parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int SaveBircirvalueinDatabase(System.Int64 masterCirid, System.String cirids, System.String repairingSol, System.String rawMaterial, System.String conculsionRecomm, System.String turbineId, System.String createdby, ref System.Int32 returnvalue, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter())
			{
				return SaveBircirvalueinDatabase(masterCirid, cirids, repairingSol, rawMaterial, conculsionRecomm, turbineId, createdby, ref returnvalue, ref returnValue, adapter);
			}
		}

		
		/// <summary>
		/// Calls stored procedure 'SaveBIRCIRValueinDatabase'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="masterCirid">Input parameter of stored procedure</param>
		/// <param name="cirids">Input parameter of stored procedure</param>
		/// <param name="repairingSol">Input parameter of stored procedure</param>
		/// <param name="rawMaterial">Input parameter of stored procedure</param>
		/// <param name="conculsionRecomm">Input parameter of stored procedure</param>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <param name="createdby">Input parameter of stored procedure</param>
		/// <param name="returnvalue">InputOutput parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int SaveBircirvalueinDatabase(System.Int64 masterCirid, System.String cirids, System.String repairingSol, System.String rawMaterial, System.String conculsionRecomm, System.String turbineId, System.String createdby, ref System.Int32 returnvalue, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[8 + 1];
			parameters[0] = new SqlParameter("@MasterCIRID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, masterCirid);
			parameters[1] = new SqlParameter("@CIRIDs", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, cirids);
			parameters[2] = new SqlParameter("@RepairingSol", SqlDbType.NVarChar, 4000, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, repairingSol);
			parameters[3] = new SqlParameter("@RawMaterial", SqlDbType.NVarChar, 4000, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, rawMaterial);
			parameters[4] = new SqlParameter("@ConculsionRecomm", SqlDbType.NVarChar, 4000, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, conculsionRecomm);
			parameters[5] = new SqlParameter("@TurbineID", SqlDbType.VarChar, 200, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, turbineId);
			parameters[6] = new SqlParameter("@Createdby", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, createdby);
			parameters[7] = new SqlParameter("@RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, returnvalue);
			parameters[8] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			int toReturn = adapter.CallActionStoredProcedure("[CIM_ComponentInspectionReports].[dbo].[SaveBIRCIRValueinDatabase]", parameters);
			if(parameters[7].Value!=System.DBNull.Value)
			{
				returnvalue = (System.Int32)parameters[7].Value;
			}
			
			returnValue = (int)parameters[8].Value;
			return toReturn;
		}
	

		/// <summary>
		/// Delegate definition for stored procedure 'TurbineDataGet' to be used in combination of a UnitOfWork2 object. 
		/// </summary>
		public delegate int TurbineDataGetCallBack(System.String turbineId, ref System.Int64 turbineMatrixId, ref System.String turbine, ref System.Byte frequency, ref System.String manufacturer, ref System.String markVersion, ref System.Int32 nominelPower, ref System.Int64 nominelPowerId, ref System.String placement, ref System.String powerRegulation, ref System.Decimal rotorDiameter, ref System.Int32 smallGenerator,  
ref System.String temperatureVariant, ref System.Int32 voltage, ref System.Int32 countryIsoId, ref System.String country, ref System.String site, ref System.String localTurbineId, DataAccessAdapter adapter);

		/// <summary>
		/// Calls stored procedure 'TurbineDataGet'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <param name="turbineMatrixId">InputOutput parameter of stored procedure</param>
		/// <param name="turbine">InputOutput parameter of stored procedure</param>
		/// <param name="frequency">InputOutput parameter of stored procedure</param>
		/// <param name="manufacturer">InputOutput parameter of stored procedure</param>
		/// <param name="markVersion">InputOutput parameter of stored procedure</param>
		/// <param name="nominelPower">InputOutput parameter of stored procedure</param>
		/// <param name="nominelPowerId">InputOutput parameter of stored procedure</param>
		/// <param name="placement">InputOutput parameter of stored procedure</param>
		/// <param name="powerRegulation">InputOutput parameter of stored procedure</param>
		/// <param name="rotorDiameter">InputOutput parameter of stored procedure</param>
		/// <param name="smallGenerator">InputOutput parameter of stored procedure</param>
		/// <param name="temperatureVariant">InputOutput parameter of stored procedure</param>
		/// <param name="voltage">InputOutput parameter of stored procedure</param>
		/// <param name="countryIsoId">InputOutput parameter of stored procedure</param>
		/// <param name="country">InputOutput parameter of stored procedure</param>
		/// <param name="site">InputOutput parameter of stored procedure</param>
		/// <param name="localTurbineId">InputOutput parameter of stored procedure</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int TurbineDataGet(System.String turbineId, ref System.Int64 turbineMatrixId, ref System.String turbine, ref System.Byte frequency, ref System.String manufacturer, ref System.String markVersion, ref System.Int32 nominelPower, ref System.Int64 nominelPowerId, ref System.String placement, ref System.String powerRegulation, ref System.Decimal rotorDiameter, ref System.Int32 smallGenerator,  
ref System.String temperatureVariant, ref System.Int32 voltage, ref System.Int32 countryIsoId, ref System.String country, ref System.String site, ref System.String localTurbineId)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter())
			{
				return TurbineDataGet(turbineId, ref turbineMatrixId, ref turbine, ref frequency, ref manufacturer, ref markVersion, ref nominelPower, ref nominelPowerId, ref placement, ref powerRegulation, ref rotorDiameter, ref smallGenerator,  
ref temperatureVariant, ref voltage, ref countryIsoId, ref country, ref site, ref localTurbineId,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'TurbineDataGet'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <param name="turbineMatrixId">InputOutput parameter of stored procedure</param>
		/// <param name="turbine">InputOutput parameter of stored procedure</param>
		/// <param name="frequency">InputOutput parameter of stored procedure</param>
		/// <param name="manufacturer">InputOutput parameter of stored procedure</param>
		/// <param name="markVersion">InputOutput parameter of stored procedure</param>
		/// <param name="nominelPower">InputOutput parameter of stored procedure</param>
		/// <param name="nominelPowerId">InputOutput parameter of stored procedure</param>
		/// <param name="placement">InputOutput parameter of stored procedure</param>
		/// <param name="powerRegulation">InputOutput parameter of stored procedure</param>
		/// <param name="rotorDiameter">InputOutput parameter of stored procedure</param>
		/// <param name="smallGenerator">InputOutput parameter of stored procedure</param>
		/// <param name="temperatureVariant">InputOutput parameter of stored procedure</param>
		/// <param name="voltage">InputOutput parameter of stored procedure</param>
		/// <param name="countryIsoId">InputOutput parameter of stored procedure</param>
		/// <param name="country">InputOutput parameter of stored procedure</param>
		/// <param name="site">InputOutput parameter of stored procedure</param>
		/// <param name="localTurbineId">InputOutput parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int TurbineDataGet(System.String turbineId, ref System.Int64 turbineMatrixId, ref System.String turbine, ref System.Byte frequency, ref System.String manufacturer, ref System.String markVersion, ref System.Int32 nominelPower, ref System.Int64 nominelPowerId, ref System.String placement, ref System.String powerRegulation, ref System.Decimal rotorDiameter, ref System.Int32 smallGenerator,  
ref System.String temperatureVariant, ref System.Int32 voltage, ref System.Int32 countryIsoId, ref System.String country, ref System.String site, ref System.String localTurbineId, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[18];
			parameters[0] = new SqlParameter("@TurbineId", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, turbineId);
			parameters[1] = new SqlParameter("@TurbineMatrixId", SqlDbType.BigInt, 0, ParameterDirection.InputOutput, true, 19, 0, "",  DataRowVersion.Current, turbineMatrixId);
			parameters[2] = new SqlParameter("@Turbine", SqlDbType.NVarChar, 20, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, turbine);
			parameters[3] = new SqlParameter("@Frequency", SqlDbType.TinyInt, 0, ParameterDirection.InputOutput, true, 3, 0, "",  DataRowVersion.Current, frequency);
			parameters[4] = new SqlParameter("@Manufacturer", SqlDbType.NVarChar, 100, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, manufacturer);
			parameters[5] = new SqlParameter("@MarkVersion", SqlDbType.NVarChar, 20, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, markVersion);
			parameters[6] = new SqlParameter("@NominelPower", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, nominelPower);
			parameters[7] = new SqlParameter("@NominelPowerId", SqlDbType.BigInt, 0, ParameterDirection.InputOutput, true, 19, 0, "",  DataRowVersion.Current, nominelPowerId);
			parameters[8] = new SqlParameter("@Placement", SqlDbType.NVarChar, 20, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, placement);
			parameters[9] = new SqlParameter("@PowerRegulation", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, powerRegulation);
			parameters[10] = new SqlParameter("@RotorDiameter", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, true, 18, 0, "",  DataRowVersion.Current, rotorDiameter);
			parameters[11] = new SqlParameter("@SmallGenerator", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, smallGenerator);
			parameters[12] = new SqlParameter("@TemperatureVariant", SqlDbType.NVarChar, 20, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, temperatureVariant);
			parameters[13] = new SqlParameter("@Voltage", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, voltage);
			parameters[14] = new SqlParameter("@CountryIsoId", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, countryIsoId);
			parameters[15] = new SqlParameter("@Country", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, country);
			parameters[16] = new SqlParameter("@Site", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, site);
			parameters[17] = new SqlParameter("@LocalTurbineId", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, localTurbineId);
			int toReturn = adapter.CallActionStoredProcedure("[CIM_ComponentInspectionReports].[dbo].[TurbineDataGet]", parameters);
			if(parameters[1].Value!=System.DBNull.Value)
			{
				turbineMatrixId = (System.Int64)parameters[1].Value;
			}
			if(parameters[2].Value!=System.DBNull.Value)
			{
				turbine = (System.String)parameters[2].Value;
			}
			if(parameters[3].Value!=System.DBNull.Value)
			{
				frequency = (System.Byte)parameters[3].Value;
			}
			if(parameters[4].Value!=System.DBNull.Value)
			{
				manufacturer = (System.String)parameters[4].Value;
			}
			if(parameters[5].Value!=System.DBNull.Value)
			{
				markVersion = (System.String)parameters[5].Value;
			}
			if(parameters[6].Value!=System.DBNull.Value)
			{
				nominelPower = (System.Int32)parameters[6].Value;
			}
			if(parameters[7].Value!=System.DBNull.Value)
			{
				nominelPowerId = (System.Int64)parameters[7].Value;
			}
			if(parameters[8].Value!=System.DBNull.Value)
			{
				placement = (System.String)parameters[8].Value;
			}
			if(parameters[9].Value!=System.DBNull.Value)
			{
				powerRegulation = (System.String)parameters[9].Value;
			}
			if(parameters[10].Value!=System.DBNull.Value)
			{
				rotorDiameter = (System.Decimal)parameters[10].Value;
			}
			if(parameters[11].Value!=System.DBNull.Value)
			{
				smallGenerator = (System.Int32)parameters[11].Value;
			}
			if(parameters[12].Value!=System.DBNull.Value)
			{
				temperatureVariant = (System.String)parameters[12].Value;
			}
			if(parameters[13].Value!=System.DBNull.Value)
			{
				voltage = (System.Int32)parameters[13].Value;
			}
			if(parameters[14].Value!=System.DBNull.Value)
			{
				countryIsoId = (System.Int32)parameters[14].Value;
			}
			if(parameters[15].Value!=System.DBNull.Value)
			{
				country = (System.String)parameters[15].Value;
			}
			if(parameters[16].Value!=System.DBNull.Value)
			{
				site = (System.String)parameters[16].Value;
			}
			if(parameters[17].Value!=System.DBNull.Value)
			{
				localTurbineId = (System.String)parameters[17].Value;
			}
			return toReturn;
		}
		

		/// <summary>
		/// Calls stored procedure 'TurbineDataGet'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <param name="turbineMatrixId">InputOutput parameter of stored procedure</param>
		/// <param name="turbine">InputOutput parameter of stored procedure</param>
		/// <param name="frequency">InputOutput parameter of stored procedure</param>
		/// <param name="manufacturer">InputOutput parameter of stored procedure</param>
		/// <param name="markVersion">InputOutput parameter of stored procedure</param>
		/// <param name="nominelPower">InputOutput parameter of stored procedure</param>
		/// <param name="nominelPowerId">InputOutput parameter of stored procedure</param>
		/// <param name="placement">InputOutput parameter of stored procedure</param>
		/// <param name="powerRegulation">InputOutput parameter of stored procedure</param>
		/// <param name="rotorDiameter">InputOutput parameter of stored procedure</param>
		/// <param name="smallGenerator">InputOutput parameter of stored procedure</param>
		/// <param name="temperatureVariant">InputOutput parameter of stored procedure</param>
		/// <param name="voltage">InputOutput parameter of stored procedure</param>
		/// <param name="countryIsoId">InputOutput parameter of stored procedure</param>
		/// <param name="country">InputOutput parameter of stored procedure</param>
		/// <param name="site">InputOutput parameter of stored procedure</param>
		/// <param name="localTurbineId">InputOutput parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int TurbineDataGet(System.String turbineId, ref System.Int64 turbineMatrixId, ref System.String turbine, ref System.Byte frequency, ref System.String manufacturer, ref System.String markVersion, ref System.Int32 nominelPower, ref System.Int64 nominelPowerId, ref System.String placement, ref System.String powerRegulation, ref System.Decimal rotorDiameter, ref System.Int32 smallGenerator,  
ref System.String temperatureVariant, ref System.Int32 voltage, ref System.Int32 countryIsoId, ref System.String country, ref System.String site, ref System.String localTurbineId, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter())
			{
				return TurbineDataGet(turbineId, ref turbineMatrixId, ref turbine, ref frequency, ref manufacturer, ref markVersion, ref nominelPower, ref nominelPowerId, ref placement, ref powerRegulation, ref rotorDiameter, ref smallGenerator,  
ref temperatureVariant, ref voltage, ref countryIsoId, ref country, ref site, ref localTurbineId, ref returnValue, adapter);
			}
		}

		
		/// <summary>
		/// Calls stored procedure 'TurbineDataGet'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <param name="turbineMatrixId">InputOutput parameter of stored procedure</param>
		/// <param name="turbine">InputOutput parameter of stored procedure</param>
		/// <param name="frequency">InputOutput parameter of stored procedure</param>
		/// <param name="manufacturer">InputOutput parameter of stored procedure</param>
		/// <param name="markVersion">InputOutput parameter of stored procedure</param>
		/// <param name="nominelPower">InputOutput parameter of stored procedure</param>
		/// <param name="nominelPowerId">InputOutput parameter of stored procedure</param>
		/// <param name="placement">InputOutput parameter of stored procedure</param>
		/// <param name="powerRegulation">InputOutput parameter of stored procedure</param>
		/// <param name="rotorDiameter">InputOutput parameter of stored procedure</param>
		/// <param name="smallGenerator">InputOutput parameter of stored procedure</param>
		/// <param name="temperatureVariant">InputOutput parameter of stored procedure</param>
		/// <param name="voltage">InputOutput parameter of stored procedure</param>
		/// <param name="countryIsoId">InputOutput parameter of stored procedure</param>
		/// <param name="country">InputOutput parameter of stored procedure</param>
		/// <param name="site">InputOutput parameter of stored procedure</param>
		/// <param name="localTurbineId">InputOutput parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Amount of rows affected, if the database / routine doesn't surpress rowcounting.</returns>
		public static int TurbineDataGet(System.String turbineId, ref System.Int64 turbineMatrixId, ref System.String turbine, ref System.Byte frequency, ref System.String manufacturer, ref System.String markVersion, ref System.Int32 nominelPower, ref System.Int64 nominelPowerId, ref System.String placement, ref System.String powerRegulation, ref System.Decimal rotorDiameter, ref System.Int32 smallGenerator,  
ref System.String temperatureVariant, ref System.Int32 voltage, ref System.Int32 countryIsoId, ref System.String country, ref System.String site, ref System.String localTurbineId, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[18 + 1];
			parameters[0] = new SqlParameter("@TurbineId", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, turbineId);
			parameters[1] = new SqlParameter("@TurbineMatrixId", SqlDbType.BigInt, 0, ParameterDirection.InputOutput, true, 19, 0, "",  DataRowVersion.Current, turbineMatrixId);
			parameters[2] = new SqlParameter("@Turbine", SqlDbType.NVarChar, 20, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, turbine);
			parameters[3] = new SqlParameter("@Frequency", SqlDbType.TinyInt, 0, ParameterDirection.InputOutput, true, 3, 0, "",  DataRowVersion.Current, frequency);
			parameters[4] = new SqlParameter("@Manufacturer", SqlDbType.NVarChar, 100, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, manufacturer);
			parameters[5] = new SqlParameter("@MarkVersion", SqlDbType.NVarChar, 20, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, markVersion);
			parameters[6] = new SqlParameter("@NominelPower", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, nominelPower);
			parameters[7] = new SqlParameter("@NominelPowerId", SqlDbType.BigInt, 0, ParameterDirection.InputOutput, true, 19, 0, "",  DataRowVersion.Current, nominelPowerId);
			parameters[8] = new SqlParameter("@Placement", SqlDbType.NVarChar, 20, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, placement);
			parameters[9] = new SqlParameter("@PowerRegulation", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, powerRegulation);
			parameters[10] = new SqlParameter("@RotorDiameter", SqlDbType.Decimal, 0, ParameterDirection.InputOutput, true, 18, 0, "",  DataRowVersion.Current, rotorDiameter);
			parameters[11] = new SqlParameter("@SmallGenerator", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, smallGenerator);
			parameters[12] = new SqlParameter("@TemperatureVariant", SqlDbType.NVarChar, 20, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, temperatureVariant);
			parameters[13] = new SqlParameter("@Voltage", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, voltage);
			parameters[14] = new SqlParameter("@CountryIsoId", SqlDbType.Int, 0, ParameterDirection.InputOutput, true, 10, 0, "",  DataRowVersion.Current, countryIsoId);
			parameters[15] = new SqlParameter("@Country", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, country);
			parameters[16] = new SqlParameter("@Site", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, site);
			parameters[17] = new SqlParameter("@LocalTurbineId", SqlDbType.NVarChar, 50, ParameterDirection.InputOutput, true, 0, 0, "",  DataRowVersion.Current, localTurbineId);
			parameters[18] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			int toReturn = adapter.CallActionStoredProcedure("[CIM_ComponentInspectionReports].[dbo].[TurbineDataGet]", parameters);
			if(parameters[1].Value!=System.DBNull.Value)
			{
				turbineMatrixId = (System.Int64)parameters[1].Value;
			}
			if(parameters[2].Value!=System.DBNull.Value)
			{
				turbine = (System.String)parameters[2].Value;
			}
			if(parameters[3].Value!=System.DBNull.Value)
			{
				frequency = (System.Byte)parameters[3].Value;
			}
			if(parameters[4].Value!=System.DBNull.Value)
			{
				manufacturer = (System.String)parameters[4].Value;
			}
			if(parameters[5].Value!=System.DBNull.Value)
			{
				markVersion = (System.String)parameters[5].Value;
			}
			if(parameters[6].Value!=System.DBNull.Value)
			{
				nominelPower = (System.Int32)parameters[6].Value;
			}
			if(parameters[7].Value!=System.DBNull.Value)
			{
				nominelPowerId = (System.Int64)parameters[7].Value;
			}
			if(parameters[8].Value!=System.DBNull.Value)
			{
				placement = (System.String)parameters[8].Value;
			}
			if(parameters[9].Value!=System.DBNull.Value)
			{
				powerRegulation = (System.String)parameters[9].Value;
			}
			if(parameters[10].Value!=System.DBNull.Value)
			{
				rotorDiameter = (System.Decimal)parameters[10].Value;
			}
			if(parameters[11].Value!=System.DBNull.Value)
			{
				smallGenerator = (System.Int32)parameters[11].Value;
			}
			if(parameters[12].Value!=System.DBNull.Value)
			{
				temperatureVariant = (System.String)parameters[12].Value;
			}
			if(parameters[13].Value!=System.DBNull.Value)
			{
				voltage = (System.Int32)parameters[13].Value;
			}
			if(parameters[14].Value!=System.DBNull.Value)
			{
				countryIsoId = (System.Int32)parameters[14].Value;
			}
			if(parameters[15].Value!=System.DBNull.Value)
			{
				country = (System.String)parameters[15].Value;
			}
			if(parameters[16].Value!=System.DBNull.Value)
			{
				site = (System.String)parameters[16].Value;
			}
			if(parameters[17].Value!=System.DBNull.Value)
			{
				localTurbineId = (System.String)parameters[17].Value;
			}
			
			returnValue = (int)parameters[18].Value;
			return toReturn;
		}
	

		#region Included Code

		#endregion
	}
}
#endif