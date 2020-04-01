using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cir.Common.Metadata;
using System.Data.SqlClient;
using Cir.Common.Utilities;
using Cir.Common.Cir;
using Cir.Common.Views;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.DatabaseSpecific;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen;
using Cir.Common.AccessControl;

namespace Cir.Data.Metadata
{
    public class DataLayer : BaseDataLayer
    {
        public DataLayer(string connectionString)
            : base(connectionString)
        {
        }

        public MetadataItem GetCirData(long cirDataId)
        {
            MetadataItem item = null;
            using (DataAccessAdapter daa = GetDataAccessAdapter())
            {
                var entity = new CirMetadataEntity();
                var fb = new RelationPredicateBucket();
                var pp = new PrefetchPath2(EntityType.CirMetadataEntity);
                pp.Add(CirMetadataEntity.PrefetchPathCirData);
                fb.PredicateExpression.Add(CirMetadataFields.CirDataId == cirDataId);
                if (daa.FetchEntityUsingUniqueConstraint(entity, fb.PredicateExpression, pp))
                {
                    item = CreateItem(entity.Metadata,
                              (State)entity.CirData.State,
                              (Progress)entity.CirData.Progress,
                              entity.CirData.CirDataId,
                              entity.CirData.CirId,
                              entity.CirData.Created,
                              entity.CirData.Modified,
                              entity.CirData.Filename,
                              entity.CirData.Deleted,
                              entity.CirData.CreatedBy,
                              entity.CirData.ModifiedBy);
                }
            }
            return item;
        }

        //public IEnumerable<MetadataItem> GetCirData(View view, ViewFilter customFilter, int page, State state, out Dictionary<State, int> totalPerState) {
        public IEnumerable<MetadataItem> GetCirData(View view, ViewFilter customFilter, int page, State state, out Dictionary<State, int> totalPerState)
        {
            var items = new List<MetadataItem>();

			var conn = new SqlConnection(ConnectionString);
			conn.Open();

            var cmd = new SqlCommand { Connection = conn };

			SqlDataReader reader = null;

			var viewFilterQuery = RenderFilterQuery(view.Filter, false);
			var customFilterQuery = RenderFilterQuery(customFilter, true);

			var viewFilterClause = RenderFilterClause(view.Filter, false);
			var customFilterClause = RenderFilterClause(customFilter, true);

            string orderByColumn;
            var groupByFieldId = 2;	// by default group by field Id 2 (report type) (all CIR should have that)
            string whereClauseOrder = string.Format("AND cml.FieldId = {0}", groupByFieldId);
            ;
            if (view.Sort.Field == MetadataItem.SystemFields.Created)
            {
                orderByColumn = "cd.Created";
            }
            else if (view.Sort.Field == MetadataItem.SystemFields.Modified)
            {
                orderByColumn = "cd.Modified";
            }
            else if (view.Sort.Field == MetadataItem.SystemFields.CirId)
            {
                orderByColumn = "cd.CirId";
            }
            else if (view.Sort.Field == MetadataItem.SystemFields.Name)
            {
                orderByColumn = "cd.[Filename]";
            }
            else
            {
                orderByColumn = (Template.IsNumericField(view.Sort.Field) ? "cml.FieldIntegerValue" : "cml.FieldValue");
                groupByFieldId = Template.GetFieldLookupId(view.Sort.Field);
                whereClauseOrder = string.Format("AND (cml.FieldId = {0} OR (NOT EXISTS (Select * from CirMetadataLookup where FieldId = {0} AND CirDataId = cd.CirDataId) AND cml.FieldId = 4))", groupByFieldId); // OR (NOT EXISTS (Select * from CirMetadataLookup where FieldId = {0} AND CirDataId = cd.CirDataId) AND cml.FieldId = 2))
			}   

            var quickFilterQuery = new StringBuilder();
            if (view.ViewId > 0 && view.QuickFilter != null)
            {
                quickFilterQuery.AppendFormat(@"
JOIN (
SELECT CirDataId FROM CirMetadataLookup WITH(NOLOCK) WHERE (FieldId = {0} AND FieldValue = '{1}')
) qq ON qq.CirDataId = cml.CirDataId
",
 Template.GetFieldLookupId(view.QuickFilter.ColumnId),
 QuerySafeValue(view.QuickFilter.Value)
 );	
			}

            try
            {
                cmd.CommandText = string.Format(@"
SELECT CirDataId, CirId, Metadata, [State], Progress, Created, Modified, [Filename], Deleted
FROM (
	SELECT cd.CirDataId, cd.CirId, cm.Metadata, cd.State, cd.Progress, cd.Created, cd.Modified, cd.[Filename], cd.Deleted, ROW_NUMBER() OVER(
		ORDER BY {0} {1}, cml.CirDataId
	) AS RowNumber
	FROM CirData cd WITH(NOLOCK)
	JOIN CirMetadataLookup cml WITH(NOLOCK) ON cml.CirDataId = cd.CirDataId
	JOIN CirMetadata cm WITH(NOLOCK) ON cm.CirDataId = cd.CirDataId
-- quick filter query
{10}
-- view filter query
{6}
-- custom filter query
{7}
	WHERE 
		cd.Deleted = 0
		AND cd.[State] = {2}
		-- group by field id
		{3}
		AND (
-- view filter clause
{8}
		)
		AND (
-- custom filter clause
{9}
		)

) CirDataPage
WHERE RowNumber >= {4}
AND RowNumber <= {5}
ORDER BY RowNumber
",
	// sorting column
	orderByColumn,
	// sort order
	(view.Sort.Ascending ? "ASC" : "DESC"),
	// CIR state
	(int)state,
	// group by field lookup Id
    
    //string.Format("AND cml.FieldId = {0}", groupByFieldId), // OR (NOT EXISTS (Select * from CirMetadataLookup where FieldId = {0} AND CirDataId = cd.CirDataId) AND cml.FieldId = 2))
    whereClauseOrder,
    
    
    // start result row
	(view.ResultsPerPage * page + 1),
	// end result row
	(view.ResultsPerPage * (page + 1)),
	// view filter query
	viewFilterQuery,
	// custom filter query
	customFilterQuery,
	// view filter clause
	viewFilterClause,
	// custom filter clause
	customFilterClause,
	quickFilterQuery
);

				reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var item = CreateItem(
                        reader.GetSqlBytes(reader.GetOrdinal("Metadata")).Buffer,
                        (State)reader.GetByte(reader.GetOrdinal("State")),
                        (Progress)reader.GetByte(reader.GetOrdinal("Progress")),
                        reader.GetInt64(reader.GetOrdinal("CirDataId")),
                        reader.GetInt64(reader.GetOrdinal("CirId")),
                        reader.GetDateTime(reader.GetOrdinal("Created")),
                        reader.GetDateTime(reader.GetOrdinal("Modified")),
                        reader.GetString(reader.GetOrdinal("Filename")),
                        reader.GetBoolean(reader.GetOrdinal("Deleted")),
                        string.Empty,
                        string.Empty
                        );

					items.Add(item);
				}

				reader.Close();

                cmd = new SqlCommand { Connection = conn };
                cmd.CommandText = string.Format(@"
-- total result number query
SELECT cd.[State], COUNT(DISTINCT(cml.CirDataId)) AS Total
FROM CirMetadataLookup cml WITH(NOLOCK)
JOIN CirData cd WITH(NOLOCK) ON cd.CirDataId = cml.CirDataId
-- quick filter query
{4}
-- view filter query
{0}
-- custom filter query
{1}
WHERE (
	cd.Deleted = 0
	AND (
-- view filter clause
{2}
	)
	AND (
-- custom filter clause
{3}
	)
)
GROUP BY cd.[State]
",
	viewFilterQuery,
	customFilterQuery,
	viewFilterClause,
	customFilterClause,
	quickFilterQuery
 );
				// initialize
				totalPerState = new Dictionary<State, int>();
				totalPerState[State.Initial] = 0;
				totalPerState[State.Rejected] = 0;
				totalPerState[State.Approved] = 0;

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    totalPerState[(State)reader.GetByte(reader.GetOrdinal("State"))] = reader.GetInt32(reader.GetOrdinal("Total"));
                }
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                conn.Close();
            }

			return items;
		}

        //public IEnumerable<MetadataItem> GetCirData(View view, ViewFilter customFilter, int page, State state, out Dictionary<State, int> totalPerState) {
        public List<BIRView> GetBirData(View view, List<ViewQuickFilter> customFilter, int page, string OrderbyClause, out int totalPerState)
        {
            totalPerState = 0;
            List<BIRView> objBIRViewCollection = new List<BIRView>();
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            var cmd = new SqlCommand { Connection = conn };
            SqlDataReader reader = null;

            #region Where clause
            string whereClauseOrder = "";
            whereClauseOrder += "bd.Deleted = 0 ";
            if (!ReferenceEquals(customFilter, null))
                foreach (ViewQuickFilter birfilters in customFilter)
                    if (!string.IsNullOrEmpty(birfilters.Value))
                    {
                        if (!string.IsNullOrEmpty(whereClauseOrder))
                        {
                            whereClauseOrder += " AND ";
                        }
                        if (birfilters.Name == "TurbineNo")
                        {
                            whereClauseOrder += " CMI.TurbineNumber = " + birfilters.Value;
                        }
                        else if (birfilters.Name == "Created")
                        {
                            whereClauseOrder += " CAST(bd.Created AS DATE) = CONVERT(DATE, '" + birfilters.Value + "', 103) ";
                        }
                        else if (birfilters.Name == "SBU")
                        {
                            whereClauseOrder += "sbu.[Name] = '" + birfilters.Value.Trim() +"'";
                        }
                        else if (birfilters.Name == "Site")
                        {
                            whereClauseOrder += "td.[Site] = '" + birfilters.Value.Trim()+"'";
                        }
                        else if (birfilters.Name == "BirCode")
                        {
                            whereClauseOrder += "BD.[BladeSerialNos] like '" + '%' + birfilters.Value + '%' + "'";
                        }
                        else
                            whereClauseOrder += " bd." + birfilters.Name + " = '" + birfilters.Value + "'";
                    }
            #endregion Where clause

            try
            {
                cmd.CommandText = string.Format(@"
SELECT [BirDataID],[BirCode], [RevisionNumber],CirDataId, CirId,Created,Createdby,SiteAddress,TurbineNumber,TurbineType,Country,SBU,BladeSerialNos
FROM (
	SELECT BD.[BirDataID],BD.[BirCode], BD.[RevisionNumber],
cd.CirDataId, cd.CirId,  bd.Created, bd.Createdby, isnull(td.[Site],'')SiteAddress,CMI.TurbineNumber, td.TurbineType,td.Country,sbu.[Name] as SBU, isnull(bd.BladeSerialNos,BD.[BirCode])BladeSerialNos,ROW_NUMBER() OVER(
		ORDER BY  BD.[Created] desc
	) AS RowNumber
	FROM
	[dbo].[BirData] BD  WITH(NOLOCK)
inner  join [dbo].[MapBirCir] MPC  WITH(NOLOCK)
on MPC.BirDataID = BD.BirDataID and MPC.Master = 1
inner join 
dbo.CIRData cd  WITH(NOLOCK) on cd.[CirDataId] = MPC.CirDataID
left join ComponentInspectionReport CMI on CMI.ComponentInspectionReportId = cd.[CirId] 
left  JOIN [dbo].[SBU] sbu WITH(NOLOCK) ON CMI.SBUId = sbu.[SBUId]
left join TurbineData td on  td.TurbineId = CMI.TurbineNumber
	WHERE {0} 
		) CirDataPage
WHERE RowNumber >= {1}
AND RowNumber <= {2}
{3}
", whereClauseOrder, (view.ResultsPerPage * page + 1), (view.ResultsPerPage * (page + 1)), OrderbyClause
);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objBIRViewCollection.Add(new BIRView
                    {
                        BirDataId = reader["BirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["BirDataId"]),
                        BirCode = Convert.ToString(reader["BirCode"]),
                        RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]),
                        CIRDataId = reader["CirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirDataId"]),
                        CIRId = reader["CirId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirId"]),
                        SiteAddress = Convert.ToString(reader["SiteAddress"]),
                        Created = reader.GetDateTime(reader.GetOrdinal("Created")),
                        Createdby = reader.GetString(reader.GetOrdinal("Createdby")),
                        TurbineNumber = Convert.ToString(reader["TurbineNumber"]),//reader.GetString(reader.GetOrdinal("TurbineNumber")),
                        TurbineType = reader.GetString(reader.GetOrdinal("TurbineType")),
                        Country = reader.GetString(reader.GetOrdinal("Country")),
                        BladeSln = Convert.ToString(reader["BladeSerialNos"]),
                        SBU = Convert.ToString(reader["SBU"])

                    });
                }

                reader.Close();

                cmd = new SqlCommand { Connection = conn };
                cmd.CommandText = string.Format(@"
-- total result number query
SELECT  COUNT(DISTINCT(BirDataID)) AS Total
FROM  [dbo].[BirData] WITH(NOLOCK) 
WHERE (
	Deleted = 0
)

"
 );

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    totalPerState = reader.GetInt32(reader.GetOrdinal("Total"));
                }
            }
            catch { }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                conn.Close();
            }

            return objBIRViewCollection;
        }

        //public IEnumerable<MetadataItem> GetCirData(View view, ViewFilter customFilter, int page, State state, out Dictionary<State, int> totalPerState) {
        public List<BIRView> GetBirDataAdvanceSearch(View view, List<ViewQuickFilter> customFilter, int page, string OrderbyClause, out int totalPerState)
        {
            totalPerState = 0;
            List<BIRView> objBIRViewCollection = new List<BIRView>();
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            var cmd = new SqlCommand { Connection = conn };
            SqlDataReader reader = null;

            #region Where clause
            string whereClauseOrder = "";
            whereClauseOrder += "bd.Deleted = 0 ";
            if (!ReferenceEquals(customFilter, null))
                foreach (ViewQuickFilter birfilters in customFilter)
                    if (!string.IsNullOrEmpty(birfilters.Value))
                    {
                        if (!string.IsNullOrEmpty(whereClauseOrder))
                        {
                            whereClauseOrder += " AND ";
                        }
                        if (birfilters.Name == "TurbineNo")
                        {
                            whereClauseOrder += " CMI.TurbineNumber = " + birfilters.Value;
                        }
                        else if (birfilters.Name == "Created")
                        {
                            whereClauseOrder += " CAST(bd.Created AS DATE) = CONVERT(DATE, '" + birfilters.Value + "', 103) ";
                        }
                        else if (birfilters.Name == "SBU")
                        {
                            whereClauseOrder += "sbu.[Name] = '" + birfilters.Value.Trim() + "'";
                        }
                        else if (birfilters.Name == "Site")
                        {
                            whereClauseOrder += "td.[Site] = '" + birfilters.Value.Trim() + "'";
                        }
                        else if (birfilters.Name == "BirCode")
                        {
                            whereClauseOrder += "BD.[BirCode] like '" + '%' + birfilters.Value + '%' + "'";
                        }
                        else if (birfilters.Name == "BirRev")
                        {
                            whereClauseOrder += "BD.[RevisionNumber] = '"  + birfilters.Value +  "'";
                        }
                        else
                            whereClauseOrder += " bd." + birfilters.Name + " = '" + birfilters.Value + "'";
                    }
            #endregion Where clause

            try
            {
                cmd.CommandText = string.Format(@"
SELECT [BirDataID],[BirCode], [RevisionNumber],CirDataId, CirId,Created,Createdby,SiteAddress,TurbineNumber,TurbineType,Country,SBU,BladeSerialNos
FROM (
	SELECT BD.[BirDataID],BD.[BirCode], BD.[RevisionNumber],
cd.CirDataId, cd.CirId,  bd.Created, bd.Createdby, isnull(td.[Site],'')SiteAddress,CMI.TurbineNumber, td.TurbineType,td.Country,sbu.[Name] as SBU, isnull(bd.BladeSerialNos,BD.[BirCode])BladeSerialNos,ROW_NUMBER() OVER(
		ORDER BY  BD.[Created] desc
	) AS RowNumber
	FROM
	[dbo].[BirData] BD  WITH(NOLOCK)
inner  join [dbo].[MapBirCir] MPC  WITH(NOLOCK)
on MPC.BirDataID = BD.BirDataID and MPC.Master = 1
inner join 
dbo.CIRData cd  WITH(NOLOCK) on cd.[CirDataId] = MPC.CirDataID
left join ComponentInspectionReport CMI on CMI.ComponentInspectionReportId = cd.[CirId] 
left  JOIN [dbo].[SBU] sbu WITH(NOLOCK) ON CMI.SBUId = sbu.[SBUId]
left join TurbineData td on  td.TurbineId = CMI.TurbineNumber
	WHERE {0} 
		) CirDataPage
WHERE RowNumber >= {1}
AND RowNumber <= {2}
{3}
", whereClauseOrder, (view.ResultsPerPage * page + 1), (view.ResultsPerPage * (page + 1)), OrderbyClause
);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objBIRViewCollection.Add(new BIRView
                    {
                        BirDataId = reader["BirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["BirDataId"]),
                        BirCode = Convert.ToString(reader["BirCode"]),
                        RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]),
                        CIRDataId = reader["CirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirDataId"]),
                        CIRId = reader["CirId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirId"]),
                        SiteAddress = Convert.ToString(reader["SiteAddress"]),
                        Created = reader.GetDateTime(reader.GetOrdinal("Created")),
                        Createdby = reader.GetString(reader.GetOrdinal("Createdby")),
                        TurbineNumber = Convert.ToString(reader["TurbineNumber"]),//reader.GetString(reader.GetOrdinal("TurbineNumber")),
                        TurbineType = reader.GetString(reader.GetOrdinal("TurbineType")),
                        Country = reader.GetString(reader.GetOrdinal("Country")),
                        BladeSln = Convert.ToString(reader["BladeSerialNos"]),
                        SBU = Convert.ToString(reader["SBU"])

                    });
                }

                reader.Close();

                cmd = new SqlCommand { Connection = conn };
                cmd.CommandText = string.Format(@"
-- total result number query
SELECT  COUNT(DISTINCT(BirDataID)) AS Total
FROM  [dbo].[BirData] WITH(NOLOCK) 
WHERE (
	Deleted = 0
)

"
 );

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    totalPerState = reader.GetInt32(reader.GetOrdinal("Total"));
                }
            }
            catch { }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                conn.Close();
            }

            return objBIRViewCollection;
        }


        public BIRView GetBirDataByID(long BirID, out string relatedCIRs)
        {
            BIRView objBIRView = new BIRView();
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            var cmd = new SqlCommand { Connection = conn };
            SqlDataReader reader = null;
            relatedCIRs = string.Empty;
            #region Where clause
            string whereClauseOrder = "";
            whereClauseOrder += "bd.Deleted = 0 AND bd.BirDataID = " + BirID.ToString();

            #endregion Where clause

            try
            {
                cmd.CommandText = string.Format(@"
SELECT [BirDataID],[BirCode], [RevisionNumber],CirDataId, CirId,Created,Createdby,SiteAddress,TurbineNumber,TurbineType,Country,SBU,BladeSerialNos,RepairingSolutions,RawMaterials,ConclusionsAndRecommendations
FROM (
	SELECT BD.[BirDataID],BD.[BirCode], BD.[RevisionNumber],
cd.CirDataId, cd.CirId,  bd.Created, bd.Createdby, isnull(td.[Site],'')SiteAddress,CMI.TurbineNumber, td.TurbineType,td.Country,sbu.[Name] as SBU,bd.BladeSerialNos,RepairingSolutions,RawMaterials,ConclusionsAndRecommendations,ROW_NUMBER() OVER(
		ORDER BY  BD.[Created] desc
	) AS RowNumber
	FROM
	[dbo].[BirData] BD  WITH(NOLOCK)
inner  join [dbo].[MapBirCir] MPC  WITH(NOLOCK)
on MPC.BirDataID = BD.BirDataID and MPC.Master = 1
inner join 
dbo.CIRData cd  WITH(NOLOCK) on cd.[CirDataId] = MPC.CirDataID
left join ComponentInspectionReport CMI on CMI.ComponentInspectionReportId = cd.[CirId] 
left  JOIN [dbo].[SBU] sbu WITH(NOLOCK) ON CMI.SBUId = sbu.[SBUId]
left join TurbineData td on  td.TurbineId = CMI.TurbineNumber
	WHERE {0} 
		) CirDataPage
", whereClauseOrder);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    objBIRView = new BIRView
                    {
                        BirDataId = reader["BirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["BirDataId"]),
                        BirCode = Convert.ToString(reader["BirCode"]),
                        RevisionNumber = Convert.ToInt32(reader["RevisionNumber"]),
                        CIRDataId = reader["CirDataId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirDataId"]),
                        CIRId = reader["CirId"] == DBNull.Value ? 0 : Convert.ToInt64(reader["CirId"]),
                        SiteAddress = Convert.ToString(reader["SiteAddress"]),
                        Created = reader.GetDateTime(reader.GetOrdinal("Created")),
                        Createdby = reader.GetString(reader.GetOrdinal("Createdby")),
                        TurbineNumber = Convert.ToString(reader["TurbineNumber"]),//reader.GetString(reader.GetOrdinal("TurbineNumber")),
                        TurbineType = reader.GetString(reader.GetOrdinal("TurbineType")),
                        Country = reader.GetString(reader.GetOrdinal("Country")),
                        BladeSln = Convert.ToString(reader["BladeSerialNos"]),
                        RepairingSol = Convert.ToString(reader["RepairingSolutions"]),
                        RawMaterial = Convert.ToString(reader["RawMaterials"]),
                        ConculsionRecomm = Convert.ToString(reader["ConclusionsAndRecommendations"]),
                    };
                }

                reader.Close();

                cmd = new SqlCommand()
                {
                    Connection = conn,
                    CommandText = string.Format(@"SELECT Cirs FROM (
                    SELECT MAP.BirDataID, STUFF(
                    (SELECT ',' + LTRIM(RTRIM(M.CirDataId))
                    FROM MapBirCir M
                    WHERE MAP.BirDataID = M.BirDataID AND M.Deleted = 0 ORDER BY M.CirDataId
                    FOR XML PATH('')),1,1,'') AS Cirs
                    FROM MapBirCir AS MAP WHERE MAP.DELETED = 0
                    GROUP BY MAP.BirDataID
                    ) BIRMAP WHERE BirDataID = {0}", BirID)
                };

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    relatedCIRs = reader.GetString(reader.GetOrdinal("Cirs"));
                }
                reader.Close();
            }
            catch { }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                conn.Close();
            }

            return objBIRView;
        }

        //public IEnumerable<MetadataItem> GetCirData(View view, ViewFilter customFilter, int page, State state, out Dictionary<State, int> totalPerState) {
        public int DeleteBirData(long BIRID)
        {

            var conn = new SqlConnection(ConnectionString);
            conn.Open();

            var cmd = new SqlCommand { Connection = conn };
            string whereClauseOrder = string.Format("AND BIRDataID = {0}", BIRID);
            int Retval = 0;
            try
            {
                cmd.CommandText = string.Format(@"
                Update bd
                 set  bd.Deleted =1
                from [dbo].[BirData] bd
                where bd.BirDataID =  {0}
                ",
                    BIRID);

                Retval = cmd.ExecuteNonQuery();
                if (Retval > 0)
                {
                    cmd.CommandText = string.Format(@"
                        Update MPC
                         set MPC.Deleted =1
                        from [dbo].[BirData] bd
                        inner join
                        [dbo].MapBirCir MPC
                        on bd.BirDataID = MPC.BirDataID
                        where bd.BirDataID =   {0}
                        ",
                           BIRID);
                    Retval = cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                conn.Close();
            }
            return Retval;
        }

        public BIRView GetExistingRevisions(string CirIds)
        {
            BIRView objBirData = new BIRView();
            int intExistingRevcount = 0;
            var conn = new SqlConnection(ConnectionString);
            conn.Open();

            var cmd = new SqlCommand { Connection = conn };

            try
            {

                cmd.CommandText = string.Format(@"select  TOP 1 *
from (
SELECT MAP.BirDataID, STUFF(
					  (SELECT ',' + LTRIM(RTRIM(M.CirDataId))
                    FROM MapBirCir M
                    WHERE MAP.BirDataID = M.BirDataID AND M.Deleted = 0 ORDER BY M.CirDataId
                    FOR XML PATH('')),1,1,'')
					
					 AS Cirs,bd.RepairingSolutions,bd.ConclusionsAndRecommendations,bd.RawMaterials,bd.created,bd.RevisionNumber
                    FROM MapBirCir AS MAP
					inner join BirData bd on bd.BirDataID =MAP.BirDataID
					 WHERE bd.DELETED = 0
					 ) BIR 
					 where Cirs = '{0}' order by created desc", CirIds);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    //intExistingRevcount = reader.GetInt32(reader.GetOrdinal("ExistingRevcount"));

                    objBirData.RevisionNumber = reader.GetInt32(reader.GetOrdinal("RevisionNumber"));
                    objBirData.RepairingSol = reader.GetString(reader.GetOrdinal("RepairingSolutions"));
                    objBirData.ConculsionRecomm = reader.GetString(reader.GetOrdinal("ConclusionsAndRecommendations"));
                    objBirData.RawMaterial = reader.GetString(reader.GetOrdinal("RawMaterials"));

                }
            }
            finally
            {
                conn.Close();
            }
            return objBirData;
        }
        //public IEnumerable<MetadataItem> GetCirData(View view, ViewFilter customFilter, int page, State state, out Dictionary<State, int> totalPerState) {
        public IEnumerable<MetadataItem> GetBirCData(long BIRID)
        {
            var items = new List<MetadataItem>();

            var conn = new SqlConnection(ConnectionString);
            conn.Open();

            var cmd = new SqlCommand { Connection = conn };

            SqlDataReader reader = null;


            string whereClauseOrder = string.Format("AND BIRDataID = {0}", BIRID);




            try
            {
                cmd.CommandText = string.Format(@"
SELECT cd.CirDataId, cd.CirId, cm.Metadata, cd.State, cd.Progress, cd.Created, cd.Modified, cd.[Filename], cd.Deleted

	FROM [dbo].[MapBirCir] MPC WITH(NOLOCK)
inner  join 
dbo.CIRData CD WITH(NOLOCK) on cd.[CirDataId] = MPC.CirDataID
	JOIN CirMetadata cm WITH(NOLOCK) ON cm.CirDataId = cd.CirDataId

	WHERE 
		cd.Deleted = 0 
AND MPC.BirDataID  = {0}
",

    BIRID


);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var item = CreateItem(
                        reader.GetSqlBytes(reader.GetOrdinal("Metadata")).Buffer,
                        (State)reader.GetByte(reader.GetOrdinal("State")),
                        (Progress)reader.GetByte(reader.GetOrdinal("Progress")),
                        reader.GetInt64(reader.GetOrdinal("CirDataId")),
                        reader.GetInt64(reader.GetOrdinal("CirId")),
                        reader.GetDateTime(reader.GetOrdinal("Created")),
                        reader.GetDateTime(reader.GetOrdinal("Modified")),
                        reader.GetString(reader.GetOrdinal("Filename")),
                        reader.GetBoolean(reader.GetOrdinal("Deleted")),
                        string.Empty,
                        string.Empty
                        );

                    items.Add(item);
                }

                reader.Close();
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
                conn.Close();
            }

            return items;
        }

        private static StringBuilder RenderFilterClause(ViewFilter viewFilter, bool customFilter)
        {
            var filterClause = new StringBuilder();
            if (viewFilter != null)
            {
                for (int i = 0; i < viewFilter.FilterItems.Count; i++)
                {
                    if (i > 0)
                    {
                        filterClause.AppendFormat("{0}{1}{0}", Environment.NewLine, (viewFilter.MatchAll ? "AND" : "OR"));
                    }
                    filterClause.AppendFormat("{1}q{0}.CirDataId IS NOT NULL", i, (customFilter ? "c" : "v"));
                }
            }
            if (filterClause.Length == 0)
            {
                filterClause.Append("1 = 1");
            }
            return filterClause;
        }

        private static int? FieldIntegerValue(Guid columnId, string fieldValue)
        {
            int integerValue;
            if (Template.IsNumericField(columnId) && int.TryParse(fieldValue, out integerValue))
            {
                return integerValue;
            }
            return null;
        }

        private static StringBuilder RenderFilterQuery(ViewFilter viewFilter, bool customFilter)
        {
            if (viewFilter == null)
            {
                return new StringBuilder();
            }

            var filterClause = new StringBuilder();

            for (int i = 0; i < viewFilter.FilterItems.Count; i++)
            {
                var filterItem = viewFilter.FilterItems[i];
                filterClause.AppendFormat("LEFT OUTER JOIN ({0}SELECT CirDataId FROM CirMetadataLookup WITH(NOLOCK) WHERE ", Environment.NewLine);

                filterClause.AppendFormat("(FieldId = {0} AND ", Template.GetFieldLookupId(filterItem.ColumnId));

                string value = QuerySafeValue(filterItem.Value);
                switch (filterItem.Match)
                {
                    case ViewFilter.MatchType.Equal:
                    case ViewFilter.MatchType.NotEqual:
                        var integerValue = FieldIntegerValue(filterItem.ColumnId, filterItem.Value);
                        if (integerValue.HasValue)
                        {
                            filterClause.AppendFormat("FieldIntegerValue {0} {1}", (filterItem.Match == ViewFilter.MatchType.Equal ? "=" : "<>"), integerValue.Value);
                        }
                        else
                        {
                            filterClause.AppendFormat("FieldValue {0} '{1}'", (filterItem.Match == ViewFilter.MatchType.Equal ? "=" : "<>"), value);
                        }
                        break;
                    case ViewFilter.MatchType.In:
                    case ViewFilter.MatchType.NotIn:
                        filterClause.AppendFormat("FieldValue {0} ('{1}')", (filterItem.Match == ViewFilter.MatchType.In ? "IN" : "NOT IN"), string.Join("','", value.Split(',')));
                        break;
                    case ViewFilter.MatchType.Contains:
                        filterClause.AppendFormat("FieldValue LIKE '%{0}%'", value);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Unknown filter item match: " + value);
                }

                filterClause.AppendFormat("){1}) {2}q{0} ON {2}q{0}.CirDataId = cml.CirDataId {1}", i, Environment.NewLine, (customFilter ? "c" : "v"));
            }
            return filterClause;
        }

        private static string QuerySafeValue(string value)
        {
            // TODO: prevent SQL injection (use parameters instead?)
            return value.Replace("'", "''");
        }

        private MetadataItem CreateItem(byte[] metadataBinary, State state, Progress progress, long cirDataId, long cirId, DateTime created, DateTime modified, string name, bool deleted, string createdBy, string modifiedBy)
        {
            var item = Serializer.FromBinary<MetadataItem>(metadataBinary);
            item.State = state;
            item.Progress = progress;
            item.CirDataId = cirDataId;
            item.Created = created;
            item.Modified = modified;
            item.Name = name;
            item.Deleted = deleted;
            item.CirId = cirId;
            item.CreatedBy = createdBy;
            item.ModifiedBy = modifiedBy;
            return item;
        }

        //(Progress)reader.GetByte(reader.GetOrdinal("Progress")),
        private MetadataItem BIRCreateItem(byte[] metadataBinary, long BirDataID, string BirCode, int RevisionNumber, long cirDataId, long cirId, DateTime created, string Createdby, DateTime modified, bool deleted, string Site)
        {
            var item = Serializer.FromBinary<MetadataItem>(metadataBinary);
            item.BirDataId = BirDataID;
            item.Name = BirCode;
            item.RevisionNumber = RevisionNumber;
            item.CirDataId = cirDataId;
            item.CirId = cirId;
            item.Created = created;
            item.CreatedBy = Createdby;
            item.Modified = modified;

            item.Deleted = deleted;

            item.Site = Site;
            return item;
        }
    }
}
