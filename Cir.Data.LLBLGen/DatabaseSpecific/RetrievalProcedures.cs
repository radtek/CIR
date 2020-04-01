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
using SD.LLBLGen.Pro.ORMSupportClasses;
namespace Cir.Data.LLBLGen.DatabaseSpecific
{
	/// <summary>
	/// Class which contains the static logic to execute retrieval stored procedures in the database.
	/// </summary>
	public partial class RetrievalProcedures
	{
		/// <summary>
		/// private CTor so no instance can be created.
		/// </summary>
		private RetrievalProcedures()
		{
		}

	
		/// <summary>
		/// Calls stored procedure 'BIRDataGet'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="user">Input parameter of stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable BirdataGet(System.String user)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return BirdataGet(user,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'BIRDataGet'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="user">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable BirdataGet(System.String user, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[1];
			parameters[0] = new SqlParameter("@User", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, user);

			DataTable toReturn = new DataTable("BirdataGet");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[CIM_ComponentInspectionReports].[dbo].[BIRDataGet]", parameters, toReturn);

			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'BIRDataGet'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="user">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable BirdataGet(System.String user, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return BirdataGet(user, ref returnValue, adapter);
			}
		}
	
	
		/// <summary>
		/// Calls stored procedure 'BIRDataGet'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="user">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable BirdataGet(System.String user, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[1 + 1];
			parameters[0] = new SqlParameter("@User", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, user);

			parameters[1] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			DataTable toReturn = new DataTable("BirdataGet");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[CIM_ComponentInspectionReports].[dbo].[BIRDataGet]", parameters, toReturn);


			returnValue = (int)parameters[1].Value;
			return toReturn;
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'BIRDataGet'.
		/// 
		/// </summary>
		/// <param name="user">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetBirdataGetCallAsQuery( System.String user)
		{
			RetrievalQuery toReturn = new RetrievalQuery( new SqlCommand("[CIM_ComponentInspectionReports].[dbo].[BIRDataGet]" ) );
			toReturn.Parameters.Add(new SqlParameter("@User", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, "",  DataRowVersion.Current, user));

			toReturn.Command.CommandType = CommandType.StoredProcedure;
			return toReturn;
		}
	

		/// <summary>
		/// Calls stored procedure 'GetBIRData'.<br/><br/>
		/// 
		/// </summary>
		/// <returns>Filled DataSet with resultset(s) of stored procedure</returns>
		public static DataSet GetBirdata()
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return GetBirdata( adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'GetBIRData'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataSet with resultset(s) of stored procedure</returns>
		public static DataSet GetBirdata(DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[0];


			DataSet toReturn = new DataSet("GetBirdata");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[CIM_ComponentInspectionReports].[dbo].[GetBIRData]", parameters, toReturn);

			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'GetBIRData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataSet with resultset(s) of stored procedure</returns>
		public static DataSet GetBirdata(ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return GetBirdata(ref returnValue, adapter);
			}
		}
	
	
		/// <summary>
		/// Calls stored procedure 'GetBIRData'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataSet with resultset(s) of stored procedure</returns>
		public static DataSet GetBirdata(ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[0 + 1];


			parameters[0] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			DataSet toReturn = new DataSet("GetBirdata");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[CIM_ComponentInspectionReports].[dbo].[GetBIRData]", parameters, toReturn);


			returnValue = (int)parameters[0].Value;
			return toReturn;
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'GetBIRData'.
		/// 
		/// </summary>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetGetBirdataCallAsQuery( )
		{
			RetrievalQuery toReturn = new RetrievalQuery( new SqlCommand("[CIM_ComponentInspectionReports].[dbo].[GetBIRData]" ) );


			toReturn.Command.CommandType = CommandType.StoredProcedure;
			return toReturn;
		}
	

		/// <summary>
		/// Calls stored procedure 'GetContractHolder'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable GetContractHolder(System.Int64 turbineId)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return GetContractHolder(turbineId,  adapter);
			}
		}


		/// <summary>
		/// Calls stored procedure 'GetContractHolder'.<br/><br/>
		/// 
		/// </summary>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable GetContractHolder(System.Int64 turbineId, DataAccessAdapter adapter)
		{
			SqlParameter[] parameters = new SqlParameter[1];
			parameters[0] = new SqlParameter("@TurbineID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, turbineId);

			DataTable toReturn = new DataTable("GetContractHolder");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[CIM_ComponentInspectionReports].[dbo].[GetContractHolder]", parameters, toReturn);

			return toReturn;
		}


		/// <summary>
		/// Calls stored procedure 'GetContractHolder'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable GetContractHolder(System.Int64 turbineId, ref System.Int32 returnValue)
		{
			using(DataAccessAdapter adapter = new DataAccessAdapter()) 
			{
				return GetContractHolder(turbineId, ref returnValue, adapter);
			}
		}
	
	
		/// <summary>
		/// Calls stored procedure 'GetContractHolder'. This version also returns the return value of the stored procedure.<br/><br/>
		/// 
		/// </summary>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <param name="returnValue">Return value of the stored procedure</param>
		/// <param name="adapter">The DataAccessAdapter object to use for the call</param>
		/// <returns>Filled DataTable with resultset(s) of stored procedure</returns>
		public static DataTable GetContractHolder(System.Int64 turbineId, ref System.Int32 returnValue, DataAccessAdapter adapter)
		{
			// create parameters. Add 1 to make room for the return value parameter.
			SqlParameter[] parameters = new SqlParameter[1 + 1];
			parameters[0] = new SqlParameter("@TurbineID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, turbineId);

			parameters[1] = new SqlParameter("RETURNVALUE", SqlDbType.Int, 0, ParameterDirection.ReturnValue, true, 10, 0, "",  DataRowVersion.Current, returnValue);
			DataTable toReturn = new DataTable("GetContractHolder");
			bool hasSucceeded = adapter.CallRetrievalStoredProcedure("[CIM_ComponentInspectionReports].[dbo].[GetContractHolder]", parameters, toReturn);


			returnValue = (int)parameters[1].Value;
			return toReturn;
		}

		/// <summary>Creates an IRetrievalQuery object for a call to the procedure 'GetContractHolder'.
		/// 
		/// </summary>
		/// <param name="turbineId">Input parameter of stored procedure</param>
		/// <returns>IRetrievalQuery object which is ready to use for datafetching</returns>
		public static IRetrievalQuery GetGetContractHolderCallAsQuery( System.Int64 turbineId)
		{
			RetrievalQuery toReturn = new RetrievalQuery( new SqlCommand("[CIM_ComponentInspectionReports].[dbo].[GetContractHolder]" ) );
			toReturn.Parameters.Add(new SqlParameter("@TurbineID", SqlDbType.BigInt, 0, ParameterDirection.Input, true, 19, 0, "",  DataRowVersion.Current, turbineId));

			toReturn.Command.CommandType = CommandType.StoredProcedure;
			return toReturn;
		}
	

		#region Included Code

		#endregion
	}
}
#endif