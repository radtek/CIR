//////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
// The sourcecode for the ORM Support classes is released as BSD2 licensed 
// open source, so licensees of LLBLGen Pro can modify, update and/or extend it. 
// Distribution of this sourcecode and binary compiled versions of this sourcecode
// are licensed to LLBLGen Pro licensees using the following license below.
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2002-2006 Solutions Design. All rights reserved.
// 
// The ORM Support classes library sourcecode is released under the following license: (BSD2)
// ----------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Frans Bouma [FB]
//////////////////////////////////////////////////////////////////////
using System;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data.Common;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Central base class for all DynamicQueryEngine classes. Shared logic is placed in this class, which can be overriden in the DynamicQueryEngine
	/// classes per database. 
	/// </summary>
	public abstract class DynamicQueryEngineBase
	{
		#region Class Constants
		/// <summary>
		/// Length of buffer in which Insert queries are generated
		/// </summary>
		public readonly static int InsertQueryBufferLength = 1024;
		/// <summary>
		/// Length of buffer in which Delete queries are generated
		/// </summary>
		public readonly static int DeleteQueryBufferLength = 1024;
		/// <summary>
		/// Length of buffer in which Update queries are generated
		/// </summary>
		public readonly static int UpdateQueryBufferLength = 1024;
		/// <summary>
		/// Length of buffer in which Select queries are generated
		/// </summary>
		public readonly static int SelectQueryBufferLength = 2048;
		/// <summary>
		/// Length of buffer in which Join constructs for select queries are generated
		/// </summary>
		public readonly static int SelectJoinQueryBufferLength = 512;
		/// <summary>
		/// Length of buffer in which resultset definitions for select queries are generated
		/// </summary>
		public readonly static int SelectResultSetBufferLength = 512;
		#endregion

		#region Public fields
		/// <summary>
		/// The unique marker for this DQE. Used to make unique parameter names.
		/// This is only set to a value different than 0 when the call originates from a subquery predicate
		/// </summary>
		public int	UniqueMarker=0;

		/// <summary>
		/// The traceswitch used in the DQE. Set in the static constructor of the derived class.
		/// </summary>
		public static TraceSwitch Switch;
		#endregion

		#region Class Member Declarations
		private IDbSpecificCreator				_creator;
		private CatalogNameOverwriteHashtable	_perCallCatalogNameOverwrites;
		private SchemaNameOverwriteHashtable	_perCallSchemaNameOverwrites;

		// static members:
		private static int					_commandTimeOut = 30;		// not supported on firebird.
		#endregion

		/// <summary>
		/// Creates a new <see cref="DynamicQueryEngineBase"/> instance.
		/// </summary>
		public DynamicQueryEngineBase()
		{
			_creator = CreateDbSpecificCreator();
			this.UniqueMarker=0;
		}


		#region Dynamic Insert Query construction methods.
		/// <summary>
		/// Creates a new Insert Query object which is ready to use. 
		/// </summary>
		/// <param name="fields">EntityFields object to use to build the insert query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <returns>IActionQuery Instance which is ready to be used.</returns>
		/// <remarks>Self servicing specific</remarks>
		/// <exception cref="System.ArgumentNullException">When fields is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityField instances.</exception>
		public IActionQuery CreateInsertDQ(IEntityFields fields, IDbConnection connectionToUse)
		{
			return CreateInsertDQ(fields.GetAsEntityFieldCoreArray(), fields.GetAsPersistenceInfoArray(), connectionToUse);
		}


		/// <summary>
		/// Creates a new Insert Query object which is ready to use. 
		/// </summary>
		/// <param name="fields">Array of EntityFieldCore objects to use to build the insert query</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the insert query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <returns>IActionQuery Instance which is ready to be used.</returns>
		/// <remarks>Generic version.</remarks>
		/// <exception cref="System.ArgumentNullException">When fields is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		/// <exception cref="ORMQueryConstructionException">When there are no fields to insert in the fields list. This exception is to prevent 
		/// INSERT INTO table () VALUES () style queries.</exception>
		public IActionQuery CreateInsertDQ(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo, IDbConnection connectionToUse)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateInsertDQ", "Method Enter");

			if(fields == null)
			{
				throw new ArgumentNullException("fields", "fields can't be null.");
			}
			if(fieldsPersistenceInfo == null)
			{
				throw new ArgumentNullException("fieldsPersistenceInfo", "fieldsPersistenceInfo can't be null.");
			}
			if((fields.Length <= 0) || (fieldsPersistenceInfo.Length <= 0))
			{
				throw new ArgumentException("No fields to insert or not enough persistence info objects passed", "fields");
			}
			EntityFieldPersistenceInfoList targetFieldInfos = new EntityFieldPersistenceInfoList(fields, fieldsPersistenceInfo);
			IActionQuery toReturn = null;
			Dictionary<IEntityFieldCore, IDataParameter> fieldToParameter = new Dictionary<IEntityFieldCore,IDataParameter>();
			if(targetFieldInfos.Count>0)
			{
				// multiple targets, use a BatchActionQuery
				BatchActionQuery batchQuery = new BatchActionQuery();
				foreach(TargetEntityFieldPersistenceInfoBucket bucket in targetFieldInfos)
				{
					IActionQuery query = CreateSingleTargetInsertDQ(bucket.Fields, bucket.FieldsPersistenceInfo, connectionToUse, ref fieldToParameter);
					query.ExceptionInfoRetriever = CreateExceptionInfoRetriever();
					foreach(IEntityFieldCore field in bucket.Fields)
					{
						if(field.LinkedSuperTypeField!=null)
						{
							ParameterParameterRelation paramParamLink = new ParameterParameterRelation(
									fieldToParameter[field.LinkedSuperTypeField], fieldToParameter[field]);
							query.ParameterParameterRelations.Add(paramParamLink);
						}
					}
					batchQuery.AddActionQuery(query);
				}

				toReturn = batchQuery;
			}
			else
			{
				toReturn = CreateSingleTargetInsertDQ(fields, fieldsPersistenceInfo, connectionToUse, ref fieldToParameter);
				toReturn.ExceptionInfoRetriever = CreateExceptionInfoRetriever();
			}

			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateInsertDQ", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Creates a new Insert Query object which is ready to use. 
		/// </summary>
		/// <param name="fields">Array of EntityFieldCore objects to use to build the insert query</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the insert query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="fieldToParameter">Hashtable which will contain after the call for each field the parameter which contains or will contain
		/// the field's value.</param>
		/// <returns>IActionQuery Instance which is ready to be used.</returns>
		/// <remarks>Generic version.</remarks>
		/// <exception cref="System.ArgumentNullException">When fields is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		/// <exception cref="ORMQueryConstructionException">When there are no fields to insert in the fields list. This exception is to prevent 
		/// INSERT INTO table () VALUES () style queries.</exception>
		protected virtual IActionQuery CreateSingleTargetInsertDQ(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo,
				IDbConnection connectionToUse, ref Dictionary<IEntityFieldCore, IDataParameter> fieldToParameter )
		{
			return null;
		}
		#endregion

		#region Dynamic Delete Query construction methods.
		/// <summary>
		/// Creates a new Delete Query object which is ready to use.
		/// </summary>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the delete query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="pkFilters">Arraylist, with for each entity (from root to leaf) the PK filter for that entity. </param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When persistenceInfo is null</exception>
		public IActionQuery CreateDeleteDQ(IFieldPersistenceInfo[] fieldsPersistenceInfo, IDbConnection connectionToUse,
				List<IPredicate> pkFilters)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateDeleteDQ(4)", "Method Enter");

			if((fieldsPersistenceInfo == null)||(fieldsPersistenceInfo.Length<=0))
			{
				throw new ArgumentNullException("fieldsPersistenceInfo", "fieldsPersistenceInfo can't be null or empty.");
			}

			if( (pkFilters==null) || (pkFilters.Count<=0))
			{
				throw new ArgumentException("pkFilters can't be null or empty", "pkFilters");
			}
		
			IActionQuery toReturn = null;
			if(pkFilters.Count>1)
			{
				// hierarchy with multiple targets
				EntityFieldPersistenceInfoList targetFieldInfos = new EntityFieldPersistenceInfoList(null, fieldsPersistenceInfo);
				if(pkFilters.Count!=targetFieldInfos.Count)
				{
					throw new ArgumentException(string.Format("pkFilters in CreateDeleteDQE has '{0}' pk filters, though there are {1} targets.", pkFilters.Count, targetFieldInfos.Count), "pkFilters");
				}

				// multiple targets, use a BatchActionQuery
				BatchActionQuery batchQuery = new BatchActionQuery();
				// walk targetfieldinfo's from back to front which means from leaf to root.
				for (int i = targetFieldInfos.Count-1; i >=0 ; i--)
				{
					TargetEntityFieldPersistenceInfoBucket bucket = (TargetEntityFieldPersistenceInfoBucket)targetFieldInfos[i];
					IActionQuery query = CreateSingleTargetDeleteDQ(bucket.FieldsPersistenceInfo, connectionToUse, (IPredicate)pkFilters[i]);
					query.ExceptionInfoRetriever = CreateExceptionInfoRetriever(); 
					batchQuery.AddActionQuery(query);
				}

				toReturn = batchQuery;
			}
			else
			{
				toReturn = CreateSingleTargetDeleteDQ(fieldsPersistenceInfo, connectionToUse, (IPredicate)pkFilters[0]);
				toReturn.ExceptionInfoRetriever = CreateExceptionInfoRetriever();
			}

			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateDeleteDQ(4)", "Method Exit");
			return toReturn;
		}

		/// <summary>
		/// Creates a new Delete Query object which is ready to use.
		/// </summary>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the delete query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="deleteFilter">A complete IPredicate implementing object which contains the filter for the rows to delete</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When persistenceInfo is null</exception>
		protected virtual IActionQuery CreateSingleTargetDeleteDQ(IFieldPersistenceInfo[] fieldsPersistenceInfo, 
				IDbConnection connectionToUse, IPredicate deleteFilter)
		{
			return null;
		}


		/// <summary>
		/// Creates a new Delete Query object which is ready to use.
		/// </summary>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the delete query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="pkFilters">Arraylist, with for each entity (from root to leaf) the PK filter for that entity. </param>
		/// <param name="additionalDeleteFilter">Extra predicate for concurrency purposes.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a second FROM clause with INNER JOINs.</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When persistenceInfo is null or when deleteFilter is null or when relationsToWalk is null</exception>
		public IActionQuery CreateDeleteDQ(IFieldPersistenceInfo[] fieldsPersistenceInfo, IDbConnection connectionToUse, 
			List<IPredicate> pkFilters, IPredicate additionalDeleteFilter, IRelationCollection relationsToWalk)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateDeleteDQ(6)", "Method Enter");

			if((fieldsPersistenceInfo == null)||(fieldsPersistenceInfo.Length<=0))
			{
				throw new ArgumentNullException("fieldsPersistenceInfo", "fieldsPersistenceInfo can't be null or empty.");
			}
			if( (pkFilters!=null) && (pkFilters.Count<=0))
			{
				throw new ArgumentException("pkFilters can't be empty if specified", "pkFilters");
			}

			IPredicate additionalFilterToUse = DetermineFilterToUse(additionalDeleteFilter);

			RelationCollection relationsToUse = (RelationCollection)relationsToWalk;
			if((relationsToWalk != null)&&(relationsToWalk.Count<=0))
			{
				// no relations specified, set to null. 
				// relations are only specified in actions on targetperentity entities (subtypes)
				relationsToUse = null;
			}

			IActionQuery toReturn = null;
			if((pkFilters!=null) && (pkFilters.Count>1))
			{
				EntityFieldPersistenceInfoList targetFieldInfos = new EntityFieldPersistenceInfoList(null, fieldsPersistenceInfo);
				if(pkFilters.Count!=targetFieldInfos.Count)
				{
					throw new ArgumentException(string.Format("pkFilters in CreateDeleteDQE has '{0}' pk filters, though there are {1} targets.", pkFilters.Count, targetFieldInfos.Count), "pkFilters");
				}

				// multiple targets, use a BatchActionQuery
				BatchActionQuery batchQuery = new BatchActionQuery();
				// be sure that if the query fails partly (e.g. the additional filter makes sure the delete doesn't proceed, as the filter fails), the delete
				// query is rolled back completely.
				batchQuery.QuitOnPartlyFailure = true;

				// walk targetfieldinfo's from back to front which means from leaf to root.
				bool firstActionQuery = true;
				for (int i = targetFieldInfos.Count-1; i >=0 ; i--)
				{
					IPredicateExpression deleteFilter = new PredicateExpression();
					deleteFilter.Add(pkFilters[i]);

					TargetEntityFieldPersistenceInfoBucket bucket = (TargetEntityFieldPersistenceInfoBucket)targetFieldInfos[i];
					IActionQuery query = null;
					if(firstActionQuery)
					{
						if(additionalFilterToUse!=null)
						{
							deleteFilter.AddWithAnd(additionalFilterToUse);
						}
						if(relationsToUse == null)
						{
							query = CreateSingleTargetDeleteDQ(bucket.FieldsPersistenceInfo, connectionToUse, deleteFilter);
						}
						else
						{
							query = CreateSingleTargetDeleteDQ(bucket.FieldsPersistenceInfo, connectionToUse, deleteFilter, relationsToUse);
						}
						firstActionQuery=false;
					}
					else
					{
						query = CreateSingleTargetDeleteDQ(bucket.FieldsPersistenceInfo, connectionToUse, deleteFilter);
					}
					query.ExceptionInfoRetriever = CreateExceptionInfoRetriever();
					batchQuery.AddActionQuery(query);
				}

				toReturn = batchQuery;
			}
			else
			{
				IPredicateExpression deleteFilter = new PredicateExpression();
				if(pkFilters!=null)
				{
					deleteFilter.Add((IPredicate)pkFilters[0]);
				}
				if(additionalFilterToUse!=null)
				{
					deleteFilter.AddWithAnd(additionalFilterToUse);
				}
				if(deleteFilter.Count<=0)
				{
					deleteFilter=null;
				}

				if(relationsToUse==null)
				{
					toReturn = CreateSingleTargetDeleteDQ(fieldsPersistenceInfo, connectionToUse, deleteFilter);
				}
				else
				{
					toReturn = CreateSingleTargetDeleteDQ(fieldsPersistenceInfo, connectionToUse, deleteFilter, relationsToUse);
				}
				toReturn.ExceptionInfoRetriever = CreateExceptionInfoRetriever(); 
			}

			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateDeleteDQ(6)", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Creates a new Delete Query object which is ready to use.
		/// </summary>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the delete query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="deleteFilter">A complete IPredicate implementing object which contains the filter for the rows to delete</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a second FROM clause with INNER JOINs.</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When persistenceInfo is null or when deleteFilter is null or when relationsToWalk is null</exception>
		protected virtual IActionQuery CreateSingleTargetDeleteDQ(IFieldPersistenceInfo[] fieldsPersistenceInfo, 
				IDbConnection connectionToUse, IPredicate deleteFilter, IRelationCollection relationsToWalk)
		{
			return null;
		}
		#endregion

		#region Dynamic Update Query construction methods.
		/// <summary>
		/// Creates a new Update Query object which is ready to use. Only 'changed' EntityFields are included in the update query.
		/// Primary Key fields are never updated. 
		/// </summary>
		/// <param name="fields">EntityFields object to use to build the update query.</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="pkFilters">Arraylist, with for each entity (from root to leaf) the PK filter for that entity. </param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <remarks>Selfservicing specific</remarks>
		/// <exception cref="System.ArgumentNullException">When fields is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityField instances.</exception>
		public IActionQuery CreateUpdateDQ(IEntityFields fields, IDbConnection connectionToUse, List<IPredicate> pkFilters)
		{
			// call generic construction code
			return CreateUpdateDQ(fields.GetAsEntityFieldCoreArray(), fields.GetAsPersistenceInfoArray(), connectionToUse, pkFilters);
		}


		/// <summary>
		/// Creates a new Update Query object which is ready to use. Only 'changed' EntityFieldCore are included in the update query. 
		/// Primary Key fields are never updated. 
		/// </summary>
		/// <param name="fields">EntityFields object to use to build the update query.</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="pkFilters">Arraylist, with for each entity (from root to leaf) the PK filter for that entity. </param>
		/// <param name="additionalUpdateFilter">Extra predicate for concurrency purposes.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <remarks>Selfservicing specific</remarks>
		/// <exception cref="System.ArgumentNullException">When fields is null or when updateFilter is null or when relationsToWalk is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityField instances.</exception>
		public IActionQuery CreateUpdateDQ( IEntityFields fields, IDbConnection connectionToUse, List<IPredicate> pkFilters, IPredicate additionalUpdateFilter, 
			IRelationCollection relationsToWalk )
		{
			// call generic construction code
			return CreateUpdateDQ(fields.GetAsEntityFieldCoreArray(), fields.GetAsPersistenceInfoArray(), connectionToUse, pkFilters, additionalUpdateFilter, relationsToWalk);
		}


		/// <summary>
		/// Creates a new Update Query object which is ready to use. Only 'changed' EntityFieldCore fields are included in the update query. 
		/// </summary>
		/// <param name="fields">EntityFieldCore array to use to build the update query.</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the update query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="pkFilters">Arraylist, with for each entity (from root to leaf) the PK filter for that entity. </param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <exception cref="System.ArgumentNullException">When fields is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		public IActionQuery CreateUpdateDQ(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo, 
			IDbConnection connectionToUse, List<IPredicate> pkFilters)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateUpdateDQ(4)", "Method Enter");

			if(fields == null)
			{
				throw new ArgumentNullException("fields", "fields can't be null.");
			}
			if(fieldsPersistenceInfo == null)
			{
				throw new ArgumentNullException("fieldsPersistenceInfo", "fieldsPersistenceInfo can't be null.");
			}
			if((fields.Length <= 0) || (fieldsPersistenceInfo.Length <= 0))
			{
				throw new ArgumentException("No fields to update or not enough persistence info objects passed", "fields");
			}
			if( (pkFilters==null) || (pkFilters.Count<=0))
			{
				throw new ArgumentException("pkFilters can't be null or empty", "pkFilters");
			}

			IActionQuery toReturn = null;
			if(pkFilters.Count>1)
			{
				EntityFieldPersistenceInfoList targetFieldInfos = new EntityFieldPersistenceInfoList(fields, fieldsPersistenceInfo);
				// multiple targets, use a BatchActionQuery
				BatchActionQuery batchQuery = new BatchActionQuery();
				for(int i=0;i<targetFieldInfos.Count;i++)
				{
					TargetEntityFieldPersistenceInfoBucket bucket = (TargetEntityFieldPersistenceInfoBucket)targetFieldInfos[i];
					IActionQuery query = CreateSingleTargetUpdateDQ(bucket.Fields, bucket.FieldsPersistenceInfo, connectionToUse, (IPredicate)pkFilters[i]);
					if(query.Command.CommandText.Length<=0)
					{
						// no fields to update, skip
						continue;
					}
					query.ExceptionInfoRetriever = CreateExceptionInfoRetriever();
					// add the query to the batch.
					batchQuery.AddActionQuery(query);
				}

				toReturn = batchQuery;
			}
			else
			{
				toReturn = CreateSingleTargetUpdateDQ(fields, fieldsPersistenceInfo, connectionToUse, (IPredicate)pkFilters[0]);
				toReturn.ExceptionInfoRetriever = CreateExceptionInfoRetriever();
			}

			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateUpdateDQ(4)", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Creates a new Update Query object which is ready to use. Only 'changed' EntityFieldCore fields are included in the update query. 
		/// Primary Key fields are never updated. 
		/// </summary>
		/// <param name="fields">EntityFieldCore array to use to build the update query.</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the update query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="updateFilter">A complete IPredicate implementing object which contains the filter for the rows to update</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <exception cref="System.ArgumentNullException">When fields is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		protected virtual IActionQuery CreateSingleTargetUpdateDQ(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo,
			IDbConnection connectionToUse, IPredicate updateFilter)
		{
			return null;
		}


		/// <summary>
		/// Creates a new Update Query object which is ready to use. Only 'changed' EntityFieldCore are included in the update query.
		/// Primary Key fields are never updated. 
		/// </summary>
		/// <param name="fields">Array of EntityFieldCore objects to use to build the insert query</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the update query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="pkFilters">Arraylist, with for each entity (from root to leaf) the PK filter for that entity. </param>
		/// <param name="additionalUpdateFilter">Extra predicate for concurrency purposes.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <exception cref="System.ArgumentNullException">When fields is null or when updateFilter is null or 
		/// when relationsToWalk is null or when fieldsPersistence is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		public IActionQuery CreateUpdateDQ(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo,
			IDbConnection connectionToUse, List<IPredicate> pkFilters, IPredicate additionalUpdateFilter, IRelationCollection relationsToWalk)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateUpdateDQ(5)", "Method Enter");

			if(fields == null)
			{
				throw new ArgumentNullException("fields", "fields can't be null.");
			}
			if(fieldsPersistenceInfo == null)
			{
				throw new ArgumentNullException("fieldsPersistenceInfo", "fieldsPersistenceInfo can't be null.");
			}
			if((fields.Length <= 0) || (fieldsPersistenceInfo.Length <= 0))
			{
				throw new ArgumentException("No fields to update or not enough persistence info objects passed", "fields");
			}

			if( (pkFilters!=null) && (pkFilters.Count<=0))
			{
				throw new ArgumentException("pkFilters can't be empty if specified", "pkFilters");
			}

			IPredicate additionalFilterToUse = DetermineFilterToUse(additionalUpdateFilter);

			RelationCollection relationsToUse = (RelationCollection)relationsToWalk;
			if((relationsToWalk != null)&&(relationsToWalk.Count<=0))
			{
				// no relations specified, set to null. 
				// relations are only specified in actions on targetperentity entities (subtypes)
				relationsToUse = null;
			}

			IActionQuery toReturn = null;
			EntityFieldPersistenceInfoList targetFieldInfos = new EntityFieldPersistenceInfoList(fields, fieldsPersistenceInfo);
			if(targetFieldInfos.Count>1)
			{
				// multiple targets, use a BatchActionQuery
				BatchActionQuery batchQuery = new BatchActionQuery();
				// be sure that if the query fails partly (e.g. the additional filter makes sure the delete doesn't proceed, as the filter fails), the delete
				// query is rolled back completely.
				batchQuery.QuitOnPartlyFailure = true;

				bool firstActionQuery = true;
				for(int i=0;i<targetFieldInfos.Count;i++)
				{
					IPredicateExpression updateFilter = new PredicateExpression();
					if((pkFilters != null) && (pkFilters.Count > 1))
					{
						updateFilter.Add(pkFilters[i]);
					}

					TargetEntityFieldPersistenceInfoBucket bucket = targetFieldInfos[i];
					IActionQuery query = null;
					if(firstActionQuery)
					{
						if(additionalFilterToUse!=null)
						{
							updateFilter.AddWithAnd(additionalFilterToUse);
						}
						if(updateFilter.Count <= 0)
						{
							updateFilter = null;
						} 
						if(relationsToUse == null)
						{
							query = CreateSingleTargetUpdateDQ(bucket.Fields, bucket.FieldsPersistenceInfo, connectionToUse, updateFilter);
						}
						else
						{
							query = CreateSingleTargetUpdateDQ(bucket.Fields, bucket.FieldsPersistenceInfo, connectionToUse, updateFilter, relationsToUse);
						}
						// first query has to stay true till a valid query is produced. 
						firstActionQuery = (query.Command.CommandText.Length == 0);
					}
					else
					{
						if(updateFilter.Count <= 0)
						{
							updateFilter = null;
						}
						query = CreateSingleTargetUpdateDQ(bucket.Fields, bucket.FieldsPersistenceInfo, connectionToUse, updateFilter);
					}
					query.ExceptionInfoRetriever = CreateExceptionInfoRetriever();
					batchQuery.AddActionQuery(query);
				}

				toReturn = batchQuery;
			}
			else
			{
				// single target
				IPredicateExpression updateFilter = new PredicateExpression();
				if(pkFilters!=null)
				{
					updateFilter.Add(pkFilters[0]);
				}
				if(additionalFilterToUse!=null)
				{
					updateFilter.AddWithAnd(additionalFilterToUse);
				}
				if(updateFilter.Count<=0)
				{
					updateFilter=null;
				}

				if(relationsToUse==null)
				{
					// no relations specified, do a normal query. 
					toReturn = CreateSingleTargetUpdateDQ(fields, fieldsPersistenceInfo, connectionToUse, updateFilter);
				}
				else
				{
					toReturn = CreateSingleTargetUpdateDQ(fields, fieldsPersistenceInfo, connectionToUse, updateFilter, relationsToUse);
				}
				toReturn.ExceptionInfoRetriever = CreateExceptionInfoRetriever();
			}

			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateUpdateDQ(5)", "Method Exit");
			return toReturn;
		}


		/// <summary>
		/// Creates a new Update Query object which is ready to use. Only 'changed' EntityFieldCore are included in the update query.
		/// Primary Key fields are never updated. 
		/// </summary>
		/// <param name="fields">Array of EntityFieldCore objects to use to build the insert query</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the update query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="updateFilter">A complete IPredicate implementing object which contains the filter for the rows to update</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <returns>IActionQuery instance which is ready to be used.</returns>
		/// <exception cref="System.ArgumentNullException">When fields is null or when updateFilter is null or 
		/// when relationsToWalk is null or when fieldsPersistence is null</exception>
		/// <exception cref="System.ArgumentException">When fields contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		protected virtual IActionQuery CreateSingleTargetUpdateDQ(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo,
			IDbConnection connectionToUse, IPredicate updateFilter, IRelationCollection relationsToWalk)
		{
			return null;
		}
		#endregion

		#region Dynamic Select Query construction methods.
		/// <summary>
		/// Creates a new Select Query which is ready to use. If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of fields to select</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <remarks>SelfServicing specific</remarks>
		/// <exception cref="System.ArgumentNullException">When selectList is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityField instances.</exception>
		/// <exception cref="System.ArgumentException">When selectList contains one or more EntityField instances which are not present in a filled groupByClause.</exception>
		[Obsolete("This method is now obsolete and shouldn't be used in your code. Instead, use the overload which accepts an IEntityFieldCore[] object and an IFieldPersistenceInfo[] object.", true)]
		public IRetrievalQuery CreateSelectDQ(IEntityFields selectList, IDbConnection connectionToUse, IPredicate selectFilter,
			long maxNumberOfItemsToReturn, ISortExpression sortClauses, IGroupByCollection groupByClause)
		{
			// simply do a normal select with duplicates allowed
			return CreateSelectDQ(selectList.GetAsEntityFieldCoreArray(), selectList.GetAsPersistenceInfoArray(), connectionToUse,
				selectFilter, maxNumberOfItemsToReturn, sortClauses, null, true, groupByClause);
		}


		/// <summary>
		/// Creates a new Select Query which is ready to use. If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of fields to select</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <remarks>Selfservicing specific</remarks>
		/// <exception cref="System.ArgumentNullException">When selectList is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityField instances.</exception>
		/// <exception cref="System.ArgumentException">When selectList contains one or more EntityField instances which are not present in a filled groupByClause.</exception>
		[Obsolete("This method is now obsolete and shouldn't be used in your code. Instead, use the overload which accepts an IEntityFieldCore[] object and an IFieldPersistenceInfo[] object.", true)]
		public IRetrievalQuery CreateSelectDQ(IEntityFields selectList, IDbConnection connectionToUse, IPredicate selectFilter,
			long maxNumberOfItemsToReturn, ISortExpression sortClauses, IGroupByCollection groupByClause, bool allowDuplicates)
		{
			// call the generic construction code
			return CreateSelectDQ(selectList.GetAsEntityFieldCoreArray(), selectList.GetAsPersistenceInfoArray(), connectionToUse, selectFilter,
				maxNumberOfItemsToReturn, sortClauses, null, allowDuplicates, groupByClause);
		}


		/// <summary>
		/// Creates a new Select Query which is ready to use, based on the specified select list and the specified set of relations.
		/// If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of fields to select</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <remarks>Selfservicing specific</remarks>
		/// <exception cref="System.ArgumentNullException">When selectList is null or when relationsToWalk is null.</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityField instances.</exception>
		/// <exception cref="System.ArgumentException">When selectList contains one or more EntityField instances which are not present in a filled groupByClause.</exception>
		[Obsolete("This method is now obsolete and shouldn't be used in your code. Instead, use the overload which accepts an IEntityFieldCore[] object and an IFieldPersistenceInfo[] object.", true)]
		public IRetrievalQuery CreateSelectDQ(IEntityFields selectList, IDbConnection connectionToUse, IPredicate selectFilter,
			long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relationsToWalk, bool allowDuplicates, IGroupByCollection groupByClause)
		{
			// call generic construction code
			return CreateSelectDQ(selectList.GetAsEntityFieldCoreArray(), selectList.GetAsPersistenceInfoArray(), connectionToUse, selectFilter, 
				maxNumberOfItemsToReturn, sortClauses, relationsToWalk, allowDuplicates, groupByClause);
		}


		/// <summary>
		/// Creates a new Select Query which is ready to use. If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of IEntityFieldCore objects to select</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the select query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When selectList is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		public IRetrievalQuery CreateSelectDQ(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldsPersistenceInfo,
			IDbConnection connectionToUse, IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses,
			IGroupByCollection groupByClause, bool allowDuplicates)
		{
			return CreateSelectDQ(selectList, fieldsPersistenceInfo, connectionToUse, selectFilter, maxNumberOfItemsToReturn, sortClauses, null, allowDuplicates, 
				groupByClause);
		}


		/// <summary>
		/// Creates a new Select Query which is ready to use, based on the specified select list and the specified set of relations.
		/// If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of IEntityFieldCore objects to select</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the select query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When selectList is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		public IRetrievalQuery CreateSelectDQ(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldsPersistenceInfo,
			IDbConnection connectionToUse, IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses,
			IRelationCollection relationsToWalk, bool allowDuplicates, IGroupByCollection groupByClause)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateSelectDQ", "Method Enter");

			if(selectList == null)
			{
				throw new ArgumentNullException("selectList", "selectList can't be null.");
			}
			if(fieldsPersistenceInfo == null)
			{
				throw new ArgumentNullException("fieldsPersistenceInfo", "fieldsPersistenceInfo can't be null.");
			}
			if((selectList.Length <= 0) || (fieldsPersistenceInfo.Length <= 0))
			{
				throw new ArgumentException("No selectList specified in selectList.", "selectList");
			}
			if(selectList.Length != fieldsPersistenceInfo.Length)
			{
				throw new ORMQueryConstructionException(
						string.Format("The length of the list of fields for the select list ({0}) isn't the same as the length of the list of persistence info objects passed in ({1}). This happens when using adapter the DBSpecific project is out of sync with the DBGeneric project.",
							selectList.Length, fieldsPersistenceInfo.Length));
			}
			
			bool relationsSpecified = false;
			if(relationsToWalk != null)
			{
				relationsSpecified = (((RelationCollection)relationsToWalk).Count > 0);
			}
			bool sortClausesSpecified = false;
			if(sortClauses!=null)
			{
				sortClausesSpecified=(sortClauses.Count>0);
			}
			IPredicate filterToUse = DetermineFilterToUse(selectFilter);

			// check if there are null's in the fieldsPersistenceInfo array. If so, skip the fields with nulls altogether, so the array is compact and without nulls.
			// nulls are present in the fieldspersistenceinfos if the field is to be excluded.
			List<IEntityFieldCore> fieldsOfSelectList = new List<IEntityFieldCore>();
			List<IFieldPersistenceInfo> persistenceInfosOfFields = new List<IFieldPersistenceInfo>();
			for(int i = 0; i < selectList.Length; i++)
			{
				if(fieldsPersistenceInfo[i] != null)
				{
					fieldsOfSelectList.Add(selectList[i]);
					persistenceInfosOfFields.Add(fieldsPersistenceInfo[i]);
				}
			}

			IRetrievalQuery toReturn = CreateSelectDQ(fieldsOfSelectList.ToArray(), persistenceInfosOfFields.ToArray(), connectionToUse, 
					filterToUse, maxNumberOfItemsToReturn, sortClauses,	relationsToWalk, allowDuplicates, groupByClause, relationsSpecified, sortClausesSpecified);
			toReturn.ExceptionInfoRetriever = CreateExceptionInfoRetriever();
			return toReturn;

		}


		/// <summary>
		/// Creates a new Select Query which is ready to use, based on the specified select list and the specified set of relations.
		/// If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of IEntityFieldCore objects to select</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the select query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="relationsSpecified">flag to signal if relations are specified, this is a result of a check. This routine should
		/// simply assume the value of this flag is correct.</param>
		/// <param name="sortClausesSpecified">flag to signal if sortClauses are specified, this is a result of a check. This routine should
		/// simply assume the value of this flag is correct.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <exception cref="System.ArgumentNullException">When selectList is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		protected virtual IRetrievalQuery CreateSelectDQ(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldsPersistenceInfo,
			IDbConnection connectionToUse, IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses,
			IRelationCollection relationsToWalk, bool allowDuplicates, IGroupByCollection groupByClause, 
			bool relationsSpecified, bool sortClausesSpecified)
		{
			return null;
		}


		/// <summary>
		/// Creates a new Select Query which is ready to use, based on the specified select list and the specified set of relations.
		/// If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of fields to select</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="pageNumber">the page number to retrieve. First page starts with 1.</param>
		/// <param name="pageSize">the page size to retrieve. If set to 0 or 1 no paging logic is applied.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <remarks>Selfservicing specific</remarks>
		/// <exception cref="System.ArgumentNullException">When selectList is null or when relationsToWalk is null.</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityField instances.</exception>
		/// <exception cref="System.ArgumentException">When selectList contains one or more EntityField instances which are not present in a filled groupByClause.</exception>
		public IRetrievalQuery CreateSelectDQ(IEntityFields selectList, IDbConnection connectionToUse, IPredicate selectFilter, long maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, IRelationCollection relationsToWalk, bool allowDuplicates, IGroupByCollection groupByClause, int pageNumber, int pageSize)
		{
			return CreatePagingSelectDQ(selectList.GetAsEntityFieldCoreArray(), selectList.GetAsPersistenceInfoArray(), connectionToUse, selectFilter,
				maxNumberOfItemsToReturn, sortClauses, relationsToWalk, allowDuplicates, groupByClause, pageNumber, pageSize);
		}

		/// <summary>
		/// Creates a new Select Query which is ready to use, based on the specified select list and the specified set of relations.
		/// If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of IEntityFieldCore objects to select</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the select query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="pageNumber">the page number to retrieve. First page starts with 1. If set to 0 or lower, no paging logic is applied</param>
		/// <param name="pageSize">the page size to retrieve. If set to 0 no paging logic is applied.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When selectList is null or fieldsPersistenceInfo is null or relationsToWalk is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		public IRetrievalQuery CreateSelectDQ(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldsPersistenceInfo, 
			IDbConnection connectionToUse, IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, 
			IRelationCollection relationsToWalk, bool allowDuplicates, IGroupByCollection groupByClause, int pageNumber, int pageSize)
		{
			return CreatePagingSelectDQ(selectList, fieldsPersistenceInfo, connectionToUse, selectFilter,
				maxNumberOfItemsToReturn, sortClauses, relationsToWalk, allowDuplicates, groupByClause, pageNumber, pageSize);
		}


		/// <summary>
		/// Creates a new Select Query which is ready to use, based on the specified select list and the specified set of relations.
		/// If selectFilter is set to null, all rows are selected.
		/// </summary>
		/// <param name="selectList">list of IEntityFieldCore objects to select</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the select query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="pageNumber">the page number to retrieve. First page starts with 1. If set to 0 or lower, no paging logic is applied</param>
		/// <param name="pageSize">the page size to retrieve. If set to 0 no paging logic is applied.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <remarks>Generic version</remarks>
		/// <exception cref="System.ArgumentNullException">When selectList is null or fieldsPersistenceInfo is null or relationsToWalk is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		protected virtual IRetrievalQuery CreatePagingSelectDQ(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldsPersistenceInfo, 
			IDbConnection connectionToUse, IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, 
			IRelationCollection relationsToWalk, bool allowDuplicates, IGroupByCollection groupByClause, int pageNumber, int pageSize)
		{
			return null;
		}


		/// <summary>
		/// Creates a select query which will be executed as a scalar, and which will return a single value, the number of rows in the query
		/// formed by the elements passed in. 
		/// </summary>
		/// <param name="selectList">list of IEntityFieldCore objects to select</param>
		/// <param name="fieldsPersistenceInfo">Array of IFieldPersistenceInfo objects to use to build the select query</param>
		/// <param name="connectionToUse">The connection to use for the query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="allowDuplicates">Flag which forces the inclusion of DISTINCT if set to true. If the resultset contains fields of type ntext, text or image, no duplicate filtering
		/// is done.</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <exception cref="System.ArgumentNullException">When selectList is null or fieldsPersistenceInfo is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		public virtual IRetrievalQuery CreateRowCountDQ(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldsPersistenceInfo,
			IDbConnection connectionToUse, IPredicate selectFilter, IRelationCollection relationsToWalk, bool allowDuplicates, IGroupByCollection groupByClause)
		{
			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateRowCountDQ", "Method Enter");

			IRetrievalQuery normalQuery = CreateSelectDQ(selectList, fieldsPersistenceInfo, connectionToUse, selectFilter, 0 , null, relationsToWalk, allowDuplicates, groupByClause);
			normalQuery.ExceptionInfoRetriever = CreateExceptionInfoRetriever(); 

			// mangle query to produce the actual count. 
			StringBuilder queryText = new StringBuilder(normalQuery.Command.CommandText.Length + 256);
			queryText.Append("SELECT COUNT(*) AS NumberOfRows FROM (");
			queryText.Append(normalQuery.Command.CommandText);
			queryText.Append(") TmpResult");

			normalQuery.Command.CommandText = queryText.ToString();

			TraceHelper.WriteIf(DynamicQueryEngineBase.Switch.TraceVerbose, normalQuery, "Generated Sql query");
			TraceHelper.WriteLineIf(DynamicQueryEngineBase.Switch.TraceInfo, "CreateRowCountDQ", "Method Exit");
			return normalQuery;
		}

		#endregion


		/// <summary>
		/// Creates the exception info retriever for this DQE
		/// </summary>
		/// <returns>the db specific exception info retriever object.</returns>
		protected virtual ExceptionInfoRetrieverBase CreateExceptionInfoRetriever()
		{
			return null;
		}


		/// <summary>
		/// Appends a GROUP BY clause to the query specified.
		/// </summary>
		/// <param name="queryText">query text currently being build</param>
		/// <param name="groupByClause">group by collection</param>
		/// <param name="cmd">The command of which this query will be the query of. Used to append parameters automatically.</param>
		protected virtual void AppendGroupByClause(StringBuilder queryText, IGroupByCollection groupByClause, IDbCommand cmd)
		{
			if( (groupByClause == null) || (groupByClause.Count <= 0) )
			{
				return;
			}

			// append GROUP BY plus the groupby clauses. 
			groupByClause.DatabaseSpecificCreator = _creator;
			// In v2.0 this is outsourced to the groupByCollection class instead of a local piece of code.
			queryText.AppendFormat(null, " GROUP BY {0}", groupByClause.ToQueryText(ref this.UniqueMarker));

			foreach( IDataParameter parameter in groupByClause.Parameters )
			{
				cmd.Parameters.Add( parameter );
			}
		}


		/// <summary>
		/// Appends an ORDER BY clause to the query specified.
		/// </summary>
		/// <param name="queryText">query text currently being build</param>
		/// <param name="sortClauses">sort clauses collection</param>
		/// <param name="cmd">The command of which this query will be the query of. Used to append parameters automatically.</param>
		protected virtual void AppendOrderByClause( StringBuilder queryText, ISortExpression sortClauses, IDbCommand cmd )
		{
			if( (sortClauses == null) || (sortClauses.Count <= 0) )
			{
				return;
			}

			// append ORDER BY plus the sort clauses. 
			sortClauses.DatabaseSpecificCreator = _creator;
			// In v2.0 this is outsourced to the SortExpression class instead of a local piece of code.
			queryText.AppendFormat(null, " ORDER BY {0}", sortClauses.ToQueryText(ref this.UniqueMarker));

			foreach( IDataParameter parameter in sortClauses.Parameters )
			{
				cmd.Parameters.Add( parameter );
			}
		}


		/// <summary>
		/// Constructs the list of fields to update plus its corresponding fieldpersistenceinfo list.
		/// </summary>
		/// <param name="fields"></param>
		/// <param name="fieldsPersistenceInfo"></param>
		/// <param name="fieldsToUpdate">will be altered</param>
		/// <param name="persistenceInfoFieldsToUpdate">will be altered</param>
		protected virtual void ConstructFieldsToUpdateList(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo, 
			ref List<IEntityFieldCore> fieldsToUpdate, ref List<IFieldPersistenceInfo> persistenceInfoFieldsToUpdate)
		{
			for(int i = 0; i < fields.Length; i++)
			{
				if(fields[i].IsChanged || (fields[i].ExpressionToApply!=null))
				{
					if(fields[i].IsPrimaryKey && fields[i].DbValue==null)
					{
						// changed PK field, do not update this field
						continue;
					}
					if(fields[i].IsReadOnly || ((i<fieldsPersistenceInfo.Length) && fieldsPersistenceInfo[i].IsIdentity))
					{
						continue;
					}
					if(i < fieldsPersistenceInfo.Length)
					{
						// field can be updated
						fieldsToUpdate.Add(fields[i]);
						persistenceInfoFieldsToUpdate.Add(fieldsPersistenceInfo[i]);
					}
				}
			}
		}


		/// <summary>
		/// Checks the if field needs insert action.
		/// </summary>
		/// <param name="field">Field.</param>
		/// <returns>true if the field needs to be included in the insert query. This is the case if the field is
		/// changed or not read only, or that it is linked to a supertype field (which indicates that the field will be receiving its value later)</returns>
		protected virtual bool CheckIfFieldNeedsInsertAction(IEntityFieldCore field)
		{
			// needs insert action when:
			// - field is changed
			// - field is not readonly
			// - field is linked to a supertype field
			// - field is a discriminator column
			return ( (!field.IsReadOnly && field.IsChanged) || (field.LinkedSuperTypeField!=null) || field.GetDiscriminatorColumnFlag());
		}


		/// <summary>
		/// Checks the if fields in the sort clauses are in select list and returns true if so, otherwise false. 
		/// This check is used to determine if the DISTINCT marker has to be emitted or not.
		/// </summary>
		/// <param name="fieldNamesInSelectList">Field names in select list.</param>
		/// <param name="sortClauses">Sort clauses.</param>
		/// <returns></returns>
		protected virtual bool CheckIfSortClausesAreInSelectList(Dictionary<string, object> fieldNamesInSelectList, ISortExpression sortClauses)
		{
			bool toReturn = true;

			for (int i = 0; i < sortClauses.Count; i++)
			{
				string fieldName = sortClauses[i].FieldToSortCore.Alias;
				if((sortClauses[i].FieldToSortCore.ExpressionToApply==null)&&(sortClauses[i].FieldToSortCore.AggregateFunctionToApply==AggregateFunction.None))
				{
					fieldName = this.Creator.CreateFieldName(sortClauses[i].PersistenceInfo, sortClauses[i].FieldToSortCore.Alias, 
												sortClauses[i].ObjectAlias, false, sortClauses[i].FieldToSortCore.ContainingObjectName, 
												sortClauses[i].FieldToSortCore.ActualContainingObjectName);
				}

				toReturn &= fieldNamesInSelectList.ContainsKey(fieldName);
			}

			return toReturn;
		}


		/// <summary>
		/// Determines the filter to use.
		/// </summary>
		/// <param name="filter">Filter.</param>
		/// <returns></returns>
		protected virtual IPredicate DetermineFilterToUse(IPredicate filter)
		{
			IPredicateExpression filterAsExpression = filter as IPredicateExpression;
			if(filterAsExpression==null)
			{
				return filter;
			}

			// IPredicateExpression and not null, check if there is contents
			if(filterAsExpression.Count<=0)
			{
				return null;
			}
			return filterAsExpression;
		}


		/// <summary>
		/// Produces a set of WHERE Clauses to use in the UPDATE queries which have filters spanning multiple entities.
		/// It produces one clause if it finds the updateTable on the PK side and then stops and it produces n clauses if it finds updateTable
		/// on the FK side of n relations in relationsToWalk. 
		/// If the updateTable is on the PK side, it produces a clause: updatedTableAlias.PKField1 = updateTable.PKField1 AND... (for each field in the PK 1 clause)
		/// If the updateTable is on the FK side, it produces updatedTableAlias.Field1 = relatedEntityTable.Field1 AND ... clauses for each relation the table of the 
		/// persistence info is in.
		/// </summary>
		/// <param name="updatedEntity">The entity being updated. This entity is already in the relation list, and should be tied to
		/// entities inside the relation list</param>
		/// <param name="updatedTableAlias">Alias for updatedEntity. To use in the clauses</param>
		/// <param name="relationsToWalk">relations used in the query build up by caller</param>
		/// <returns>predicates to use in WHERE clause in subquery in mentioned update queries.</returns>
		protected virtual string CreateSubqueryConnectionClausesUpdate(string updatedEntity, string updatedTableAlias, RelationCollection relationsToWalk)
		{
			StringBuilder clauses = new StringBuilder(128);
			bool quitOuterLoop = false;
			bool startClauseEmitted = false; 
			for(int i = 0; (i < relationsToWalk.Count) && !quitOuterLoop; i++)
			{
				EntityRelation currentRelation = (EntityRelation)relationsToWalk[i];

				if((currentRelation.GetPKEntityFieldCore(0).ContainingObjectName != updatedEntity) &&
					(currentRelation.GetFKEntityFieldCore(0).ContainingObjectName != updatedEntity))
				{
					// not in this relation
					continue;
				}

				// it's in this relation, use this relation to add a clause
				bool isPKSide = (currentRelation.GetPKEntityFieldCore(0).ContainingObjectName == updatedEntity);
				for(int j = 0; j < currentRelation.AmountFields; j++)
				{
					if(startClauseEmitted)
					{
						clauses.Append(" AND ");
					}

					if(isPKSide)
					{
						// produce: updatedTableAlias.PKFieldn = rightHandSideObjectReference.PKFieldn
						string fieldName = _creator.CreateFieldNameSimple(currentRelation.GetPKFieldPersistenceInfo(j), currentRelation.GetPKEntityFieldCore(j).Name);
						string rightHandSideObjectReference = currentRelation.AliasPKSide;
						if(rightHandSideObjectReference.Length == 0)
						{
							rightHandSideObjectReference = _creator.CreateObjectName(currentRelation.GetPKFieldPersistenceInfo(j));
						}
						clauses.AppendFormat(null, "{0}.{1}={2}.{3}", updatedTableAlias, fieldName, rightHandSideObjectReference, fieldName);
						startClauseEmitted = true;
						// we're done now, as a pk-pk connection is enough to link main query with subquery.
						quitOuterLoop = true;
						break;
					}
					else
					{
						string rightHandSideObjectReference = currentRelation.AliasPKSide;
						if(rightHandSideObjectReference.Length == 0)
						{
							rightHandSideObjectReference = _creator.CreateObjectName(currentRelation.GetPKFieldPersistenceInfo(j));
						}
						clauses.AppendFormat(null, "{0}.{1}={2}.{3}",
							updatedTableAlias,
							_creator.CreateFieldNameSimple(currentRelation.GetFKFieldPersistenceInfo(j), currentRelation.GetFKEntityFieldCore(j).Name),
							rightHandSideObjectReference,
							_creator.CreateFieldNameSimple(currentRelation.GetPKFieldPersistenceInfo(j), currentRelation.GetPKEntityFieldCore(j).Name));
						startClauseEmitted = true;
					}
				}
			}

			return clauses.ToString();
		}


		/// <summary>
		/// Produces a set of WHERE Clauses to use in the DELETE queries which have filters spanning multiple entities.
		/// It produces one clause if it finds the deleteTable on the PK side and then stops and it produces n clauses if it finds deleteTable
		/// on the FK side of n relations in relationsToWalk. 
		/// If the deleteTable is on the PK side, it produces a clause: deleteTableAlias.PKField1 = deleteTable.PKField1 AND... (for each field in the PK 1 clause)
		/// If the deleteTable is on the FK side, it produces deleteTableAlias.Field1 = relatedEntityTable.Field1 AND ... clauses for each relation the table of the 
		/// persistence info is in.
		/// </summary>
		/// <param name="deleteTable">name of table the caller is building the query for</param>
		/// <param name="deleteTableAlias">Alias for deleteTable. To use in the clauses</param>
		/// <param name="relationsToWalk">relations used in the query build up by caller</param>
		/// <returns>predicates to use in WHERE clause in subquery in mentioned delete queries.</returns>
		protected virtual string CreateSubqueryConnectionClausesDelete(string deleteTable, string deleteTableAlias, RelationCollection relationsToWalk)
		{
			StringBuilder clauses = new StringBuilder(128);
			bool quitOuterLoop = false;
			bool startClauseEmitted = false;
			for(int i = 0; (i < relationsToWalk.Count) && !quitOuterLoop; i++)
			{
				EntityRelation currentRelation = (EntityRelation)relationsToWalk[i];

				// check if the deleteTable is in this relation. Access doesn't support schemas, so just do an object compare
				if((_creator.CreateObjectName(currentRelation.GetPKFieldPersistenceInfo(0)) != deleteTable) &&
					(_creator.CreateObjectName(currentRelation.GetFKFieldPersistenceInfo(0)) != deleteTable))
				{
					// not in this relation
					continue;
				}

				// it's in this relation, use this relation to add a clause
				bool isPKSide = (_creator.CreateObjectName(currentRelation.GetPKFieldPersistenceInfo(0)) == deleteTable);
				for(int j = 0; j < currentRelation.AmountFields; j++)
				{
					if(startClauseEmitted)
					{
						clauses.Append(" AND ");
					}

					if(isPKSide)
					{
						// produce: deleteTableAlias.PKFieldn = deleteTable.PKFieldn
						string fieldName = _creator.CreateFieldNameSimple(currentRelation.GetPKFieldPersistenceInfo(j), currentRelation.GetPKEntityFieldCore(j).Name);
						clauses.AppendFormat(null, "{0}.{1}={2}.{3}", deleteTableAlias, fieldName, deleteTable, fieldName);
						startClauseEmitted = true;
						// we're done now, as a pk-pk connection is enough to link main query with subquery.
						quitOuterLoop = true;
						break;
					}
					else
					{
						string rightHandSideObjectReference = currentRelation.AliasPKSide;
						if(rightHandSideObjectReference.Length == 0)
						{
							rightHandSideObjectReference = _creator.CreateObjectName(currentRelation.GetPKFieldPersistenceInfo(j));
						}
						clauses.AppendFormat(null, "{0}.{1}={2}.{3}",
							deleteTableAlias,
							_creator.CreateFieldNameSimple(currentRelation.GetFKFieldPersistenceInfo(j), currentRelation.GetFKEntityFieldCore(j).Name),
							rightHandSideObjectReference,
							_creator.CreateFieldNameSimple(currentRelation.GetPKFieldPersistenceInfo(j), currentRelation.GetPKEntityFieldCore(j).Name));
						startClauseEmitted = true;
					}
				}
			}

			return clauses.ToString();
		}


		/// <summary>
		/// Resets the creator object with a new one. Only used by DAO objects which keep a Dynamic Query Engine object alive.
		/// </summary>
		internal void ResetCreator()
		{
			_creator = CreateDbSpecificCreator();
		}


		/// <summary>
		/// Creates a new IDbCommand object and initializes it
		/// </summary>
		/// <returns>ready to use IDbCommand object</returns>
		protected abstract IDbCommand CreateCommand();
		/// <summary>
		/// Creates a new IDbSpecificCreator and initializes it
		/// </summary>
		/// <returns></returns>
		protected abstract IDbSpecificCreator CreateDbSpecificCreator();

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets the command time out (in seconds). This is a global setting, so every Command object created after you've set this
		/// property to a value will have that value as CommandTimeOut. Default is 30 seconds which is the ADO.NET default.
		/// Do not set this property by hand, use the selfservicing dbUtils class to do that for you.
		/// Adapter's DataAccessAdapter class has its own, per call, command timeout setting, which is recommended over this setting, which is global
		/// for all calls.
		/// </summary>
		public static int CommandTimeOut
		{
			get { return _commandTimeOut; }
			set { _commandTimeOut = value; }
		}

		
		/// <summary>
		/// Gets / sets creator
		/// </summary>
		public IDbSpecificCreator Creator
		{
			get
			{
				return _creator;
			}
			set
			{
				_creator = value;
				_perCallCatalogNameOverwrites = ((DbSpecificCreatorBase)_creator).PerCallCatalogNameOverwrites;
				_perCallSchemaNameOverwrites = ((DbSpecificCreatorBase)_creator).PerCallSchemaNameOverwrites;
			}
		}


		/// <summary>
		/// Gets / sets perCallCatalogNameOverwrites name pairs
		/// </summary>
		public CatalogNameOverwriteHashtable PerCallCatalogNameOverwrites
		{
			get
			{
				return _perCallCatalogNameOverwrites;
			}
			set
			{
				_perCallCatalogNameOverwrites = value;
				((DbSpecificCreatorBase)_creator).PerCallCatalogNameOverwrites = _perCallCatalogNameOverwrites;
			}
		}


		/// <summary>
		/// Gets / sets perCallSchemaNameOverwrites name pairs
		/// </summary>
		public SchemaNameOverwriteHashtable PerCallSchemaNameOverwrites
		{
			get
			{
				return _perCallSchemaNameOverwrites;
			}
			set
			{
				_perCallSchemaNameOverwrites = value;
				((DbSpecificCreatorBase)_creator).PerCallSchemaNameOverwrites = _perCallSchemaNameOverwrites;
			}
		}
		#endregion

	}
}
