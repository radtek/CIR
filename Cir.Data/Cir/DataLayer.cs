using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SD.LLBLGen.Pro.ORMSupportClasses;
using System.Data.SqlClient;
using Cir.Common.Cir;
using System.Xml;
using Cir.Common.Utilities;
using Cir.Common.Metadata;
using System.Data;
using Cir.Data.LLBLGen.DatabaseSpecific;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen;

namespace Cir.Data.Cir {
	public class DataLayer : BaseDataLayer {
		public DataLayer(string connectionString)
			: base(connectionString) {
		}

		public bool SetStatus(long cirDataId, State newState, Progress newProgress, string modifiedBy) {
			return SetStatus(cirDataId, newState, newProgress, modifiedBy, null);
		}

		public bool SetStatus(long cirDataId, State newState, Progress newProgress, string modifiedBy, string comment) {
			bool updated = false;
			using (var daa = GetDataAccessAdapter()) {
			    var entity = new CirDataEntity(cirDataId);
			    daa.FetchEntity(entity);
			    if (entity != null && entity.Deleted == false) {
			        entity.State = (byte)newState;
			        entity.Progress = (byte)newProgress;
					entity.Modified = DateTime.Now;
					entity.ModifiedBy = modifiedBy;
					if (comment != null) {
						var commentType = CirComment.Type.General;
						switch(newProgress) {
							case Progress.PendingInitial:
								commentType = CirComment.Type.MoveToInitial;
								break;
							case Progress.PendingApprove:
								commentType = CirComment.Type.Approve;
								break;
							case Progress.PendingReject:
								commentType = CirComment.Type.Reject;
								break;
						}
						AddComment(cirDataId, modifiedBy, comment, commentType, daa);
					}
			        daa.SaveEntity(entity);
					updated = true;
			    }
			}
			return updated;
		}

		public CirData NewCir(long cirId, Guid guid, string fromEmail, string fromInitials, string originalFilename, XmlDocument xml) {

			using (var daa = GetDataAccessAdapter()) {
			    var cirEntity = new CirDataEntity();
			    cirEntity.CirId = cirId;
			    cirEntity.Guid = guid.ToString();
			    cirEntity.Email = fromEmail;
			    cirEntity.CreatedBy = fromInitials;
			    cirEntity.Created = DateTime.Now;
			    cirEntity.ModifiedBy = fromInitials;
			    cirEntity.Modified = DateTime.Now;
			    cirEntity.Filename = originalFilename;
			    cirEntity.State = (byte)State.Initial;
			    cirEntity.Progress = (byte)Progress.PendingInitial;
				cirEntity.Deleted = false;

				//daa.StartTransaction(IsolationLevel.ReadUncommitted, "NewCirTransaction");

				try {
					daa.CommandTimeOut = 120;
					daa.SaveEntity(cirEntity, true);

					var xmlEntity = new CirXmlEntity();
					xmlEntity.Xml = xml.OuterXml;
					cirEntity.CirXml.Add(xmlEntity);

					var metadataEntity = new CirMetadataEntity();
					metadataEntity.Metadata = Serializer.ToBinary<MetadataItem>(new MetadataItem());
					metadataEntity.TurbineId = "0";
					cirEntity.CirMetadata.Add(metadataEntity);

					daa.SaveEntity(cirEntity, false, true);
					//daa.Commit();
				}
				catch (Exception) {
					//daa.Rollback();
					throw;
				}

				cirEntity.CirXml.Clear();
				return CreateCirData(cirEntity);
			}
		}

		public List<CirData> GetPendingCir() {
			var items = new List<CirData>();

			using (var daa = GetDataAccessAdapter()) {
				var resultSetFields = new ResultsetFields(12);
				resultSetFields[0] = CirDataFields.CirDataId;
				resultSetFields[1] = CirDataFields.Guid;
				resultSetFields[2] = CirDataFields.CirId;
				resultSetFields[3] = CirDataFields.State;
				resultSetFields[4] = CirDataFields.Progress;
				resultSetFields[5] = CirDataFields.Email;
				resultSetFields[6] = CirDataFields.Filename;
				resultSetFields[7] = CirDataFields.Created;
				resultSetFields[8] = CirDataFields.CreatedBy;
				resultSetFields[9] = CirDataFields.Modified;
				resultSetFields[10] = CirDataFields.ModifiedBy;
				resultSetFields[11] = CirXmlFields.Xml;

			    var progressFilter = new RelationPredicateBucket();
			    progressFilter.PredicateExpression.Add(CirDataFields.Progress == (byte)Progress.PendingApprove);
			    progressFilter.PredicateExpression.AddWithOr(CirDataFields.Progress == (byte)Progress.PendingReject);
			    progressFilter.PredicateExpression.AddWithOr(CirDataFields.Progress == (byte)Progress.PendingInitial);
			    var fb = new RelationPredicateBucket();
			    fb.PredicateExpression.Add(CirDataFields.Deleted == false);
			    fb.PredicateExpression.AddWithAnd(progressFilter.PredicateExpression);

				// add relation to CIR XML 
				fb.Relations.Add(CirDataEntity.Relations.CirXmlEntityUsingCirDataId);

				// using a custom reader here because we're potentially fetching a lot of data (XML) and the LLBLGen FetchEntityCollection might time out
				var reader = daa.FetchDataReader(resultSetFields, fb, CommandBehavior.Default, 0, true);

				while (reader.Read()) {
					var xml = new XmlDocument();
					xml.LoadXml(reader.GetString(reader.GetOrdinal(CirXmlFields.Xml.Name)));
					items.Add(
						CreateCirData(
							reader.GetInt64(reader.GetOrdinal(CirDataFields.CirDataId.Name)),
							new Guid(reader.GetString(reader.GetOrdinal(CirDataFields.Guid.Name))),
							reader.GetInt64(reader.GetOrdinal(CirDataFields.CirId.Name)),
							xml,
							reader.GetByte(reader.GetOrdinal(CirDataFields.State.Name)),
							reader.GetByte(reader.GetOrdinal(CirDataFields.Progress.Name)),
							reader.GetString(reader.GetOrdinal(CirDataFields.Email.Name)),
							reader.GetString(reader.GetOrdinal(CirDataFields.Filename.Name)),
							reader.GetDateTime(reader.GetOrdinal(CirDataFields.Created.Name)),
							reader.GetString(reader.GetOrdinal(CirDataFields.CreatedBy.Name)),
							reader.GetDateTime(reader.GetOrdinal(CirDataFields.Modified.Name)),
							reader.GetString(reader.GetOrdinal(CirDataFields.ModifiedBy.Name))
						)
					);
				}

				reader.Close();
			}
			return items;
		}

		private static CirData CreateCirData(CirDataEntity entity) {
			//var xml = new XmlDocument();
			XmlDocument xml = null;
			if (entity.CirXml.Count > 0) {
				xml = new XmlDocument();
				xml.LoadXml(entity.CirXml[0].Xml);
			}
			return CreateCirData(
				entity.CirDataId,
				new Guid(entity.Guid),
				entity.CirId,
				xml,
				entity.State,
				entity.Progress,
				entity.Email,
				entity.Filename,
				entity.Created,
				entity.CreatedBy,
				entity.Modified,
				entity.ModifiedBy
			);
		}

		private static CirData CreateCirData(long cirDataId, Guid guid, long cirId, XmlDocument xml, byte state, byte progress, string email, string filename, DateTime created, string createdBy, DateTime modified, string modifiedBy) {
			return new CirData(
				cirDataId,
				guid,
				cirId,
				xml,
				(State)state,
				(Progress)progress,
				email,
				filename,
				createdBy,
				created,
				modifiedBy,
				modified
				);
		}

		public void Delete(Guid uniqueId, State state, string modifiedBy) {
			Delete(uniqueId, state, modifiedBy, null);
		}

		public void Delete(Guid uniqueId, State state, string modifiedBy, string comment) {
			using (var daa = GetDataAccessAdapter()) {
				// fetch the CirData entity with the given GUID and state
				var fb = new RelationPredicateBucket();
				fb.PredicateExpression.Add(CirDataFields.Guid == uniqueId.ToString());
				fb.PredicateExpression.Add(CirDataFields.State == (byte)state);
				fb.PredicateExpression.Add(CirDataFields.Deleted == false);
				var ec = new EntityCollection<CirDataEntity>();
				daa.FetchEntityCollection(ec, fb, 2);

				if(ec.Count == 1) {
					var entity = ec[0];
					entity.Deleted = true;
					entity.Modified = DateTime.Now;
					entity.ModifiedBy = modifiedBy;
					daa.SaveEntity(entity);
					AddComment(entity.CirDataId, modifiedBy, comment, CirComment.Type.Deleted, daa);

					//// delete all existing lookup data for this CIR
					//fb = new RelationPredicateBucket();
					//fb.Relations.Add(CirMetadataLookupEntity.Relations.CirDataEntityUsingCirDataId);
					//fb.PredicateExpression.Add(CirDataFields.Guid == uniqueId.ToString());
					//fb.PredicateExpression.AddWithAnd(CirDataFields.State == (byte)state);
					//daa.DeleteEntitiesDirectly(typeof(CirMetadataLookupEntity), fb);

				}
			}
		}

		public void Update(long cirDataId, XmlDocument cir, string modifiedBy) {
			Update(cirDataId, cir, null, modifiedBy);
		}

		public void Update(long cirDataId, XmlDocument cir, MetadataItem metadata, string modifiedBy) {
			Update(cirDataId, cir, metadata, modifiedBy, null);
		}

		public void Update(long cirDataId, XmlDocument cir, MetadataItem metadata, string modifiedBy, string filename) {
			using (var daa = GetDataAccessAdapter()) {
				var entity = new CirDataEntity();
				entity.CirDataId = cirDataId;
				IPrefetchPath2 pp = new PrefetchPath2(EntityType.CirDataEntity);
				pp.Add(CirDataEntity.PrefetchPathCirXml);
				if (metadata != null) {
					pp.Add(CirDataEntity.PrefetchPathCirMetadata);
				}

				if (daa.FetchEntity(entity, pp) == false) {
					throw new ArgumentException("No CIR found with CIR data ID " + cirDataId);
				}

				entity.Modified = DateTime.Now;
				entity.ModifiedBy = modifiedBy;
				if(!string.IsNullOrEmpty(filename)) {
					entity.Filename = filename;
				}
				entity.CirXml.First().Xml = cir.OuterXml;
				if(metadata != null) {
					var metaEntity = entity.CirMetadata.First();
					metaEntity.Metadata = Serializer.ToBinary<MetadataItem>(metadata);
					metaEntity.TurbineId = metadata.FieldValues[MetadataItem.SystemFields.TurbineId];
				}
				daa.SaveEntity(entity, false, true);

				if (metadata != null) {
					// delete lookup data for all deleted CIR (clean up lookup table)
					var filter = new RelationPredicateBucket();
					filter.Relations.Add(CirMetadataLookupEntity.Relations.CirDataEntityUsingCirDataId);
					filter.PredicateExpression.Add(CirDataFields.Deleted == true);
					filter.PredicateExpression.AddWithOr(CirDataFields.CirDataId == cirDataId);
					daa.DeleteEntitiesDirectly(typeof(CirMetadataLookupEntity), filter);

					// create new lookup data
					var lookupFields = new Dictionary<int, KeyValuePair<string, int?>>();
					foreach (var fieldValue in metadata.FieldValues) {
						// only store lookup data that has any value
						if (fieldValue.Value.Length > 0) {
							lookupFields[Template.GetFieldLookupId(fieldValue.Key)] = new KeyValuePair<string, int?>(fieldValue.Value,
								(Template.IsNumericField(fieldValue.Key) ? metadata.FieldIntegerValues[fieldValue.Key] : (int?)null));
						}
					}

					// save new lookup data to DB
					var lookupData = new EntityCollection<CirMetadataLookupEntity>();
					foreach(var lookupField in lookupFields) {
						lookupData.Add(
							new CirMetadataLookupEntity() {
							                              	CirDataId = cirDataId,
															FieldId = lookupField.Key,
															FieldValue = SafeString(lookupField.Value.Key, CirMetadataLookupFields.FieldValue),
															FieldIntegerValue = lookupField.Value.Value
							                              }
						);
					}
					daa.SaveEntityCollection(lookupData);
				}
			}
		}

		public long GetCirId(Guid uniqueId) {
			long cirId = 0;
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				var ec = new EntityCollection<CirDataEntity>(new CirDataEntityFactory());
				var fb = new RelationPredicateBucket();
				fb.PredicateExpression.Add(CirDataFields.Guid == uniqueId.ToString());
				fb.PredicateExpression.AddWithAnd(CirDataFields.CirId != 0);

				daa.FetchEntityCollection(ec, fb);

				if (ec.Count > 0) {
					cirId = ec[0].CirId;
				}
			}
			if (cirId <= 0) {
				cirId = GenerateCirId();
			}
			return cirId;
		}

        public long GetCirId(long? cirDataId)
        {
            long cirId = 0;
            using (DataAccessAdapter daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<CirDataEntity>(new CirDataEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(CirDataFields.CirDataId == cirDataId);
                fb.PredicateExpression.AddWithAnd(CirDataFields.CirId != 0);

                daa.FetchEntityCollection(ec, fb);

                if (ec.Count > 0)
                {
                    cirId = ec[0].CirId;
                }
            }
            if (cirId <= 0)
            {
                cirId = GenerateCirId();
            }
            return cirId;
        }

        public long GetCirDataId(long cirId, State state) {
            long cirDataId = 0;
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
                var ec = new EntityCollection<CirDataEntity>(new CirDataEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(CirDataFields.CirId == cirId);
                fb.PredicateExpression.Add(CirDataFields.State == (byte)state);
                fb.PredicateExpression.Add(CirDataFields.Deleted == 0);
                daa.FetchEntityCollection(ec, fb);
                if(ec.Count > 0) {
                    cirDataId = ec[0].CirDataId;  
                }
                return cirDataId;
            }
        }

        public long GetCirDataId(long cirId)
        {
            long cirDataId = 0;
            using (DataAccessAdapter daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<CirDataEntity>(new CirDataEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(CirDataFields.CirId == cirId);
                fb.PredicateExpression.Add(CirDataFields.Deleted == 0);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    cirDataId = ec[0].CirDataId;
                }
                return cirDataId;
            }
        }

        public List<long> GetCirDataIdFromMetaData(long turbineId)
        {
            var cirDataId = new List<long>();
            using (DataAccessAdapter daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<CirMetadataEntity>(new CirMetadataEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(CirMetadataFields.TurbineId == turbineId);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    foreach(var id in ec) {
                        cirDataId.Add(id.CirDataId);
                    }
                }
                return cirDataId;
            }
        }

		private long GenerateCirId() {
			long cirId = 0;
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				try {
					var gce = new GenerateCiridEntity(0);
					//daa.StartTransaction(System.Data.IsolationLevel.Serializable, "GenerateCIRId");
					daa.SaveEntity(gce, true);
					cirId = gce.Cirid;
					daa.DeleteEntity(gce);
					//daa.Commit();
				}
				catch (Exception) {
					//if (daa.IsTransactionInProgress) {
					//    daa.Rollback();
					//}
					throw;
				}
			}
			return cirId;
		}

		public List<CirData> GetCir(string turbineId) {
			var cir = new List<CirData>();
			using (var daa = GetDataAccessAdapter()) {
				var ec = new EntityCollection<CirDataEntity>();
				var fb = new RelationPredicateBucket();
				fb.Relations.Add(CirDataEntity.Relations.CirMetadataEntityUsingCirDataId);
				fb.PredicateExpression.Add(CirDataFields.Deleted == false);
				fb.PredicateExpression.Add(CirMetadataFields.TurbineId == turbineId);
				daa.FetchEntityCollection(ec, fb);

				cir.AddRange(from entity in ec select CreateCirData(entity));
			}
			return cir;
		}

		public CirData GetCir(long cirDataId, bool getXml) {
			return GetCir(cirDataId, getXml, false);
		}

		public CirData GetCir(long cirDataId, bool getXml, bool getDeleted) {
			var fb = new RelationPredicateBucket();
			fb.PredicateExpression.Add(CirDataFields.CirDataId == cirDataId);
			return GetCir(fb, getXml, getDeleted);
		}

		public CirData GetCir(Guid uniqueId, State state, bool getXml) {
			var fb = new RelationPredicateBucket();
			fb.PredicateExpression.Add(CirDataFields.Guid == uniqueId.ToString());
			fb.PredicateExpression.Add(CirDataFields.State == (byte)state);
			return GetCir(fb, getXml);
		}

		private CirData GetCir(IRelationPredicateBucket filter, bool getXml) {
			return GetCir(filter, getXml, false);
		}
		private CirData GetCir(IRelationPredicateBucket filter, bool getXml, bool getDeleted) {
			if (filter == null) {
				filter = new RelationPredicateBucket();
			}
			if (!getDeleted) {
				filter.PredicateExpression.AddWithAnd(CirDataFields.Deleted == false);
			}
			CirData returnValue = null;
			using (var daa = GetDataAccessAdapter()) {
				var ec = new EntityCollection<CirDataEntity>(new CirDataEntityFactory());
				IPrefetchPath2 pp = null;
				if (getXml) {
					pp = new PrefetchPath2(EntityType.CirDataEntity);
					pp.Add(CirDataEntity.PrefetchPathCirXml);
				}
				daa.FetchEntityCollection(ec, filter, pp);

				if (ec.Count == 1) {
					returnValue = CreateCirData(ec[0]);
				}
			}
			return returnValue;
		}

		public EditHistory UpdateEditHistory(CirData cirData, string fromInitials, long version, string reasonForChange) {
			var history = new EditHistory(fromInitials, DateTime.Now, reasonForChange);
			using (var daa = GetDataAccessAdapter()) {
				var eh = new EditHistoryEntity();
				eh.EditVersion = version;
				eh.EditInitials = history.Initials;
				eh.EditDate = history.EditDate;
				eh.EditReason = SafeString(reasonForChange ?? string.Empty, EditHistoryFields.EditReason);
				eh.ComponentInspectionReportId = cirData.CirId;
				daa.SaveEntity(eh);
			}
			return history;
		}

		public List<EditHistory> GetEditHistory(long cirId) {
			var history = new List<EditHistory>();
			using (var daa = GetDataAccessAdapter()) {
				var ec = new EntityCollection<EditHistoryEntity>();
				var filter = new RelationPredicateBucket();
				filter.PredicateExpression.Add(EditHistoryFields.ComponentInspectionReportId == cirId);

				daa.FetchEntityCollection(ec, filter);

				history.AddRange(
						from entity in ec 
						select new EditHistory(entity.EditInitials, entity.EditDate, entity.EditReason ?? string.Empty)
					);
			}
			return history;
		}

		public List<CirData> GetAllCir(long cirId) {
			List<CirData> cirData = null;
			using (var daa = GetDataAccessAdapter()) {
				var fb = new RelationPredicateBucket();
				fb.PredicateExpression.Add(CirDataFields.CirId == cirId);
				fb.PredicateExpression.Add(CirDataFields.Deleted == false);

				var ec = new EntityCollection<CirDataEntity>(new CirDataEntityFactory());
				daa.CommandTimeOut = 60;
				daa.FetchEntityCollection(ec, fb, 10, new SortExpression((CirDataFields.Modified | SortOperator.Descending)));

				cirData = new List<CirData>(
					from entity in ec
					select CreateCirData(entity)
				);
			}

			return cirData;
		}

		public List<CirData> GetDeletedCir(long cirId) {
			List<CirData> cirData = null;
			using (var daa = GetDataAccessAdapter()) {
				var fb = new RelationPredicateBucket();
				fb.PredicateExpression.Add(CirDataFields.CirId == cirId);
				fb.PredicateExpression.Add(CirDataFields.Deleted == true);

				var ec = new EntityCollection<CirDataEntity>(new CirDataEntityFactory());
				daa.CommandTimeOut = 60;
				daa.FetchEntityCollection(ec, fb, 10, new SortExpression((CirDataFields.Modified | SortOperator.Descending)));

				cirData = new List<CirData>(
					from entity in ec
					select CreateCirData(entity)
				);
			}

			return cirData;
		}

        public DateTime? GetLastModifiedCir() {
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
                var ec = new EntityCollection<CirDataEntity>();
                var filter = new RelationPredicateBucket();
                var sort = new SortExpression(CirDataFields.Modified | SortOperator.Descending);
                daa.FetchEntityCollection(ec, filter, 1, sort);
                if (ec.Count == 1){
                    return ec[0].Modified;
                }
            }
            return null;
        }

		#region CIR comments

		public List<CirComment> GetComments(long cirId) {
			var comments = new List<CirComment>();
			// fetch the latest 100 comments
			var ec = new EntityCollection<CirCommentHistoryEntity>();
			using (var daa = GetDataAccessAdapter()) {

				var fb = new RelationPredicateBucket();
				fb.Relations.Add(CirCommentHistoryEntity.Relations.CirDataEntityUsingCirDataId);
				fb.PredicateExpression.Add(CirDataFields.CirId == cirId);

				daa.CommandTimeOut = 60;
				// fetch the comments
				daa.FetchEntityCollection(ec, fb, 100, new SortExpression((CirCommentHistoryFields.Date | SortOperator.Descending)));
			}
			comments.AddRange(
				from entity in ec orderby entity.Date select CreateCirComment(entity)
			);
			return comments;
		}

		public CirComment GetLastComment(long cirDataId) {
			var ec = new EntityCollection<CirCommentHistoryEntity>();
			using (var daa = GetDataAccessAdapter()) {
				var fb = new RelationPredicateBucket();
				fb.PredicateExpression.Add(CirCommentHistoryFields.CirDataId == cirDataId);

				daa.CommandTimeOut = 60;
				// fetch the comments
				daa.FetchEntityCollection(ec, fb, 1, new SortExpression((CirCommentHistoryFields.Date | SortOperator.Descending)));
			}
			if(ec.Count == 1) {
				return CreateCirComment(ec[0]);
			}
			return null;
		}

		public void AddComment(long cirDataId, string initials, string comment, CirComment.Type type) {
			using (var daa = GetDataAccessAdapter()) {
				AddComment(cirDataId, initials, comment, type, daa);
			}
		}

		private void AddComment(long cirDataId, string initials, string comment, CirComment.Type type, DataAccessAdapter daa) {
			if(comment == null) {
				return;
			}
			var entity = new CirCommentHistoryEntity();
			entity.Date = DateTime.Now;
			entity.CirDataId = cirDataId;
			entity.Initials = initials;
			entity.Comment = comment;
			entity.Type = (byte)type;
			daa.SaveEntity(entity);
		}

		private CirComment CreateCirComment(CirCommentHistoryEntity entity) {
			return new CirComment(entity.CirCommentHistoryId, entity.CirDataId, entity.Date, entity.Initials, entity.Comment, (CirComment.Type)entity.Type);
		}



		#endregion

		#region Invalid CIR

		public void NewInvalidCir(string filename, string createdBy, XmlDocument xml, string errorMessage) {
			using (var daa = GetDataAccessAdapter()) {
				var invalidEntity = new CirInvalidEntity();
				invalidEntity.Created = DateTime.Now;
				invalidEntity.CreatedBy = createdBy;
				invalidEntity.Filename = filename;
				invalidEntity.Xml = xml.OuterXml;
				invalidEntity.Error = errorMessage;
				daa.SaveEntity(invalidEntity);
			}
		}

		public void DeleteInvalidCir(long invalidCirId) {
			using (var daa = GetDataAccessAdapter()) {
				var fb = new RelationPredicateBucket();
				fb.PredicateExpression.Add(CirInvalidFields.CirInvalidId == invalidCirId);
				daa.DeleteEntitiesDirectly(typeof(CirInvalidEntity), fb);
			}
		}

		public InvalidCir GetInvalidCir(long invalidCirId) {
			InvalidCir cir = null;

			using (var daa = GetDataAccessAdapter()) {
				var entity = new CirInvalidEntity(invalidCirId);
				if (daa.FetchEntity(entity)) {
					var xml = new XmlDocument();
					try {
						xml.LoadXml(entity.Xml);
					}
					catch {
						xml = null;
					}
					cir = new InvalidCir(entity.CirInvalidId, entity.Filename, entity.CreatedBy, entity.Created, entity.Error, xml);
				}
			}

			return cir;
		}

		public List<InvalidCir> GetInvalidCir() {
			var cir = new List<InvalidCir>();

			using (var daa = GetDataAccessAdapter()) {
				daa.CommandTimeOut = 60;
				var ec = new EntityCollection<CirInvalidEntity>();
				var sort = new SortExpression(CirInvalidFields.Created | SortOperator.Descending);
				var excludedFields = new ExcludeIncludeFieldsList();
				excludedFields.Add(CirInvalidFields.Xml);

				daa.FetchEntityCollection(ec, null, 200, sort, null, excludedFields);

				cir.AddRange(
					from entity in ec
					select new InvalidCir(entity.CirInvalidId, entity.Filename, entity.CreatedBy, entity.Created, entity.Error, null)
				);
			}

			return cir;
		}

		#endregion

        #region GeneratorDefectCategorization

        public void AddGeneratorDefectCategorization(long cirId, bool statorInsulation, bool statorInductive, bool statorVibrations, string statorDecision,
                                            bool rotorInsulation, bool rotorInductive, bool rotorVibrations,
                                            bool rotorPostFailure, string rotorDecision,
                                            bool rotorLeadInsulation, bool rotorLeadConnection, string rotorLeadDecision,
                                            bool phaseDamaged, string phaseDamagedDecision, 
                                            bool bearingsBearingFailure, bool bearingsInnerRace, 
                                            bool bearingsOuterRace, bool bearingsNoise,
                                            bool bearingsVibration, bool bearingsSeal, string bearingsDecision,
                                            bool miscBearing, bool miscGenerator, bool miscWater, bool miscPtsensor, bool miscGrounding,
                                            string miscBearingDecision, string miscGeneratorDecision, string miscWaterDecision, string miscPtsensorDecision, string miscGroundingDecision,
                                            string defectCategory, string source)
        {
            using (var daa = GetDataAccessAdapter())
            {
                // fetch booleanentity ids
                var booleanEntity = new EntityCollection<BooleanAnswerEntity>();
                daa.FetchEntityCollection(booleanEntity, null);
                var yesAnswer = (booleanEntity.FirstOrDefault(b => b.Name.ToLower() == "yes") ?? new BooleanAnswerEntity { BooleanAnswerId = 2}).BooleanAnswerId;
                var noAnswer = (booleanEntity.FirstOrDefault(b => b.Name.ToLower() == "no") ?? new BooleanAnswerEntity { BooleanAnswerId = 1 }).BooleanAnswerId;

                // fetch decision lookups
                var statorDecisionEntity = new EntityCollection<GeneratorStatorDecisionEntity>();
                daa.FetchEntityCollection(statorDecisionEntity, new RelationPredicateBucket(GeneratorStatorDecisionFields.Name == statorDecision));
                var rotorDecisionEntity = new EntityCollection<GeneratorRotorDecisionEntity>();
                daa.FetchEntityCollection(rotorDecisionEntity, new RelationPredicateBucket(GeneratorRotorDecisionFields.Name == rotorDecision));
                var rotorLeadDecisionEntity = new EntityCollection<GeneratorRotorLeadsDecisionEntity>();
                daa.FetchEntityCollection(rotorLeadDecisionEntity, new RelationPredicateBucket(GeneratorRotorLeadsDecisionFields.Name == rotorLeadDecision));
                var phaseDamagedDecisionEntity = new EntityCollection<GeneratorPhaseOutletDecisionEntity>();
                daa.FetchEntityCollection(phaseDamagedDecisionEntity, new RelationPredicateBucket(GeneratorPhaseOutletDecisionFields.Name == phaseDamagedDecision));
                var bearingsDecisionEntity = new EntityCollection<GeneratorBearingDecisionEntity>();
                daa.FetchEntityCollection(bearingsDecisionEntity, new RelationPredicateBucket(GeneratorBearingDecisionFields.Name == bearingsDecision));
                var miscDecisionEntity = new EntityCollection<GeneratorMiscDecisionEntity>();
                daa.FetchEntityCollection(miscDecisionEntity, null);

                // assign values
                var entity = new GeneratorDefectCategorizationEntity
                                 {
                                     StatorInsulation = statorInsulation ? yesAnswer : noAnswer, 
                                     StatorInductive = statorInductive  ? yesAnswer : noAnswer, 
                                     StatorVibrations = statorVibrations  ? yesAnswer : noAnswer,                                      
                                     RotorInsulation = rotorInsulation  ? yesAnswer : noAnswer, 
                                     RotorInductive = rotorInductive  ? yesAnswer : noAnswer, 
                                     RotorVibrations = rotorVibrations  ? yesAnswer : noAnswer, 
                                     RotorPostFailure = rotorPostFailure  ? yesAnswer : noAnswer, 
                                     RotorLeadInsulation = rotorLeadInsulation  ? yesAnswer : noAnswer, 
                                     RotorLeadConnection = rotorLeadConnection  ? yesAnswer : noAnswer, 
                                     PhaseDamaged = phaseDamaged  ? yesAnswer : noAnswer, 
                                     BearingsBearingFailure = bearingsBearingFailure  ? yesAnswer : noAnswer, 
                                     BearingsInnerRace = bearingsInnerRace  ? yesAnswer : noAnswer, 
                                     BearingsOuterRace = bearingsOuterRace  ? yesAnswer : noAnswer, 
                                     BearingsNoise = bearingsNoise  ? yesAnswer : noAnswer, 
                                     BearingsVibrations = bearingsVibration  ? yesAnswer : noAnswer, 
                                     BearingsSeal = bearingsSeal  ? yesAnswer : noAnswer, 
                                     MiscBearing = miscBearing  ? yesAnswer : noAnswer, 
                                     MiscGenerator = miscGenerator  ? yesAnswer : noAnswer, 
                                     MiscWater = miscWater  ? yesAnswer : noAnswer, 
                                     MiscPtsensor = miscPtsensor  ? yesAnswer : noAnswer, 
                                     MiscGrounding = miscGrounding  ? yesAnswer : noAnswer, 
                                     DefectCategory = defectCategory,
                                     Source = source
                                 };

                // assign lookup values
                if (statorDecisionEntity.Any())
                    entity.StatorDecision = statorDecisionEntity[0].GeneratorStatorDecisionId;
                if (rotorDecisionEntity.Any())
                    entity.RotorDecision = rotorDecisionEntity[0].GeneratorRotorDecisionId;
                if (rotorLeadDecisionEntity.Any())
                    entity.RotorLeadDecision = rotorLeadDecisionEntity[0].GeneratorRotorLeadsDecisionId;
                if (phaseDamagedDecisionEntity.Any())
                    entity.PhaseDamagedDecision = phaseDamagedDecisionEntity[0].GeneratorPhaseOutletDecisionId;
                if (bearingsDecisionEntity.Any())
                    entity.BearingsDecision = bearingsDecisionEntity[0].GeneratorBearingDecisionId;

                // Misc Values
                var miscDict = miscDecisionEntity.ToDictionary(de => de.Name, de => de.GeneratorMiscDecisionId);
                if (entity.MiscBearing == yesAnswer && !string.IsNullOrEmpty(miscBearingDecision))
                    entity.MiscBearingDecision = miscDict[miscBearingDecision];
                if (entity.MiscGenerator == yesAnswer && !string.IsNullOrEmpty(miscGeneratorDecision))
                    entity.MiscGeneratorDecision = miscDict[miscGeneratorDecision];
                if (entity.MiscWater == yesAnswer && !string.IsNullOrEmpty(miscWaterDecision))
                    entity.MiscWaterDecision = miscDict[miscWaterDecision];
                if (entity.MiscPtsensor == yesAnswer && !string.IsNullOrEmpty(miscPtsensorDecision))
                    entity.MiscPtsensorDecision = miscDict[miscPtsensorDecision];
                if (entity.MiscGrounding == yesAnswer && !string.IsNullOrEmpty(miscGroundingDecision))
                    entity.MiscGroundingDecision = miscDict[miscGroundingDecision];

                // get ComponentInspectionReportGeneratorId
                var cirGeneratorEntity = new EntityCollection<ComponentInspectionReportGeneratorEntity>();
                daa.FetchEntityCollection(cirGeneratorEntity, new RelationPredicateBucket(ComponentInspectionReportGeneratorFields.ComponentInspectionReportId == cirId));
                entity.ComponentInspectionReportGeneratorId = cirGeneratorEntity[0].ComponentInspectionReportGeneratorId;

                // save data
                daa.SaveEntity(entity);
            }
            
        }

        public void AddGeneratorDefectCategorization(long cirId, string statorDecision, string rotorDecision,
                                    string rotorLeadDecision, string bearingsDecision, string miscBearingDecision, 
                                    string miscGeneratorDecision, string miscWaterDecision, string miscPtsensorDecision,
                                    string miscGroundingDecision, string defectCategory, string source)
        {
            using (var daa = GetDataAccessAdapter())
            {
                // fetch decision lookups
                var statorDecisionEntity = new EntityCollection<GeneratorStatorDecisionEntity>();
                daa.FetchEntityCollection(statorDecisionEntity, new RelationPredicateBucket(GeneratorStatorDecisionFields.Name == statorDecision));
                var rotorDecisionEntity = new EntityCollection<GeneratorRotorDecisionEntity>();
                daa.FetchEntityCollection(rotorDecisionEntity, new RelationPredicateBucket(GeneratorRotorDecisionFields.Name == rotorDecision));
                var rotorLeadDecisionEntity = new EntityCollection<GeneratorRotorLeadsDecisionEntity>();
                daa.FetchEntityCollection(rotorLeadDecisionEntity, new RelationPredicateBucket(GeneratorRotorLeadsDecisionFields.Name == rotorLeadDecision));
                var bearingsDecisionEntity = new EntityCollection<GeneratorBearingDecisionEntity>();
                daa.FetchEntityCollection(bearingsDecisionEntity, new RelationPredicateBucket(GeneratorBearingDecisionFields.Name == bearingsDecision));
                var miscDecisionEntity = new EntityCollection<GeneratorMiscDecisionEntity>();
                daa.FetchEntityCollection(miscDecisionEntity, null);

                // assign values
                var miscDict = miscDecisionEntity.ToDictionary(de => de.Name, de => de.GeneratorMiscDecisionId);
                var entity = new GeneratorDefectCategorizationEntity();
                
                // assign values
                if (statorDecisionEntity.Any()) 
                    entity.StatorDecision = statorDecisionEntity[0].GeneratorStatorDecisionId;
                if (rotorDecisionEntity.Any())
                    entity.RotorDecision = rotorDecisionEntity[0].GeneratorRotorDecisionId;
                if (rotorLeadDecisionEntity.Any())
                    entity.RotorLeadDecision = rotorLeadDecisionEntity[0].GeneratorRotorLeadsDecisionId;
                if (bearingsDecisionEntity.Any())
                    entity.BearingsDecision = bearingsDecisionEntity[0].GeneratorBearingDecisionId;
                if (miscDict.Keys.Contains(miscBearingDecision))
                    entity.MiscBearingDecision = miscDict[miscBearingDecision];
                if (miscDict.Keys.Contains(miscGeneratorDecision))
                    entity.MiscGeneratorDecision = miscDict[miscGeneratorDecision];
                if (miscDict.Keys.Contains(miscWaterDecision))
                    entity.MiscWaterDecision = miscDict[miscWaterDecision];
                if (miscDict.Keys.Contains(miscPtsensorDecision))
                    entity.MiscPtsensorDecision = miscDict[miscPtsensorDecision];
                if (miscDict.Keys.Contains(miscGroundingDecision))
                    entity.MiscGroundingDecision = miscDict[miscGroundingDecision];
                entity.DefectCategory = defectCategory;
                entity.Source = source;

                // get ComponentInspectionReportGeneratorId
                var cirGeneratorEntity = new EntityCollection<ComponentInspectionReportGeneratorEntity>();
                daa.FetchEntityCollection(cirGeneratorEntity, new RelationPredicateBucket(ComponentInspectionReportGeneratorFields.ComponentInspectionReportId == cirId));
                if (cirGeneratorEntity.Any())
                    entity.ComponentInspectionReportGeneratorId = cirGeneratorEntity[0].ComponentInspectionReportGeneratorId;
                else
                    throw new ApplicationException("No matching ComponentInspectionReportGenerator for CirId:" + cirId);

                // save data
                daa.SaveEntity(entity);
            }
        }


        public void AddGeneratorDefectCategorization(string vendorName, string generatorType, string kwType,
                                    string hz, string serialNumber, string manufacturer, long cirId,
                                    DateTime? inspectionDate, string inspectedBy, string email, string repairManualNumber,
                                    string jobNumber, string windingsType, string bearingManufacturerDe,
                                    string bearingTypeDe, string bearingNumberDe, string lubricationTypeDe,
                                    string bearingManufacturerNde, string bearingTypeNde, string bearingNumberNde, 
                                    string lubricationTypeNde, string primaryFailure, string secondaryFailure,
                                    string consequentialDamage, string otherFindings,string failuremodes, IEnumerable<GeneratorDetail> details
            )
        {
            using (var daa = GetDataAccessAdapter())
            {

                var entity = new GeneratorDefectCategorization2Entity
                {
                    VendorName = vendorName,
                    GeneratorType = generatorType,
                    Kwtype = kwType,
                    Hz = hz,
                    SerialNumber = serialNumber,
                    Manufacturer = manufacturer,
                    CirId = cirId,
                    InspectionDate = inspectionDate,
                    InspectedBy = inspectedBy,
                    Email = email,
                    RepairManualNumber = repairManualNumber,
                    JobNumber = jobNumber,
                    WindingsType = windingsType,
                    BearingManufacturerDe = bearingManufacturerDe,
                    BearingTypeDe = bearingTypeDe,
                    BearingNumberDe = bearingNumberDe,
                    LubricationTypeDe = lubricationTypeDe,
                    BearingManufacturerNde = bearingManufacturerNde,
                    BearingTypeNde = bearingTypeNde,
                    BearingNumberNde = bearingNumberNde,
                    LubricationTypeNde = lubricationTypeNde,
                    PrimaryFailure = primaryFailure,
                    SecondaryFailure = secondaryFailure,
                    ConsequentialDamage = consequentialDamage,
                    OtherFindings = otherFindings ,
                    FailureModes =failuremodes
                    
                };

                // get list of generator component damage as lookup
                using (var generatorComponentDamage = new EntityCollection<GeneratorComponentDamageEntity>())
                {
                    daa.FetchEntityCollection(generatorComponentDamage, null);
                    var detailEntities = details.Select(dtl =>
                    {
                        // get component damage id
                        var componentDamage = generatorComponentDamage.FirstOrDefault(cd => cd.Component.ToLower() == dtl.Component.ToLower() 
                                                           && cd.FailureDamage.ToLower() == dtl.FailureDamage.ToLower());

                        // cast to details
                        return new GeneratorDefectCategorization2DetailsEntity { GeneratorComponentDamage = componentDamage.Id, 
                                                                                   IsDamage = dtl.IsDamaged, 
                                                                                   Repair = dtl.Repair, 
                                                                                   FailureMode = dtl.FailureMode };
                    });

                    entity.GeneratorDefectCategorization2Details.AddRange(detailEntities.ToArray());
                }
                 
                // save
                daa.SaveEntity(entity);
            }
        }
        #endregion

        public void AddGearboxDefectCategorization(long cirId, string vendorName, string gearboxType,
                                                string serialNumber, string manufacturer, string ratio,
                                                string oilType, string frequency, DateTime? inspectionDate,
                                                string inspectedBy, string email,
                                                string repairManualNumber, string jobNo,                                                
                                                bool[] reasons,
                                                string detailsOfDamage,
                                                string serviceHistory,
                                                string primaryFailure,
                                                string secondaryFailure,
                                                string consequentialDamage,
                                                string otherFindings,
                                                IEnumerable<GearboxDetail> details)
        {

            using (var daa = GetDataAccessAdapter())
            {
                // fetch lookups
                var manufacturerEntity = new GearboxManufacturerEntity();
                daa.FetchEntityUsingUniqueConstraint(manufacturerEntity, new PredicateExpression(GearboxManufacturerFields.Name == manufacturer));                
                if (manufacturerEntity.GearboxManufacturerId == 0) throw new ApplicationException("Missing Manufacturer!");

                var gearboxTypeEntity = new GearboxTypeEntity();
                daa.FetchEntityUsingUniqueConstraint(gearboxTypeEntity, new PredicateExpression(GearboxTypeFields.Name == gearboxType));
                if (gearboxTypeEntity.GearboxTypeId == 0) throw new ApplicationException("Missing GearBoxType!");

                var oilEntity = new OilTypeEntity();
                daa.FetchEntityUsingUniqueConstraint(oilEntity, new PredicateExpression(OilTypeFields.Name == oilType));
                if (oilEntity.OilTypeId == 0) throw new ApplicationException("Missing OilType!");

                var cirGearboxEntity = new ComponentInspectionReportGearboxEntity();
                daa.FetchEntityUsingUniqueConstraint(cirGearboxEntity, new PredicateExpression(ComponentInspectionReportGearboxFields.ComponentInspectionReportId == cirId));

                // assign value & save                
                var entity = new GearboxDefectCategorizationEntity 
                { 
                    ComponentInspectionReportGearboxId = cirGearboxEntity.ComponentInspectionReportGearboxId, 
                    VendorName = vendorName, 
                    GearboxTypeId = gearboxTypeEntity.GearboxTypeId, 
                    SerialNumber = serialNumber, 
                    GearBoxManufacturerId = manufacturerEntity.GearboxManufacturerId, 
                    Ratio = ratio, 
                    OilTypeId = oilEntity.OilTypeId, 
                    Frequency = frequency, 
                    InspectionDate = inspectionDate, 
                    InspectedBy = inspectedBy, 
                    Email = email, 
                    RepairManualNumber = repairManualNumber, 
                    JobNumber = jobNo,
                    Noise = reasons[0],
                    MetalOnMagnet = reasons[1],
                    HighTemperature = reasons[2],
                    Leakage = reasons[3],
                    Painting = reasons[4],
                    Others = reasons[5],
                    None = reasons[6],
                    HssBearingDamage = reasons[7],
                    ImsBearingDamage = reasons[8],
                    LssBearingDamage = reasons[9],
                    PlanetBearingDamage = reasons[10],
                    OtherBearingDamage = reasons[11],
                    NoBearingDamage = reasons[12],
                    HssToothDamage = reasons[13],
                    ImsToothDamage = reasons[14],
                    LssToothDamage = reasons[15],
                    PlanetToothDamage = reasons[16],
                    OtherToothDamage = reasons[17],
                    NoToothDamage = reasons[18],
                    DetailsOfDamage = detailsOfDamage,
                    ServiceHistory = serviceHistory,
                    PrimaryFailure = primaryFailure,
                    SecondaryFailure = secondaryFailure,
                    ConsequentialDamage = consequentialDamage,
                    OtherFindings = otherFindings

                };
                // save collection
                if (details != null)
                {
                    var bearingTypes = new EntityCollection<BearingTypeEntity>();
                    daa.FetchEntityCollection(bearingTypes, null);
                    var bearingTypeDict = bearingTypes.ToDictionary(bt => bt.Name, bt => (long?) bt.BearingTypeId);
                    bearingTypeDict.Add("", null);                    
                
                    var detailsCollection = details.Select(gd => new GearboxDefectCategorizationDetailsEntity
                    {
                        PartName = gd.PartName,
                        GearboxPartTypeId = gd.PartType,
                        ItemNumber = gd.ItemNumber,
                        BearingTypeId = gd.PartType == 2 && !string.IsNullOrEmpty(gd.BearingType) ? (bearingTypeDict[gd.BearingType]) : null,
                        Error1Id = gd.Error1Id,
                        Error2Id = gd.Error2Id,
                        Comments = gd.Comments,
                        DamageDecisionId = gd.DamageDecisionId
                    }).ToList();
                    entity.GearboxDefectCategorizationDetails.AddRange(detailsCollection);
                }

                // save data
                daa.SaveEntity(entity);

            }
        }


        public void LoadGearboxDictionaries(out IDictionary<string, long> gearTypeDict, 
                                            out IDictionary<string, long> bearingTypeDict,
                                            out IDictionary<string, long> shaftTypeDict, 
                                            out IDictionary<string, int> gearErrorDict,
                                            out IDictionary<string, int> bearingErrorDict, 
                                            out IDictionary<string, int> shaftErrorDict,
                                            out IDictionary<string, int> damageDecisionDict)
        {
            using (var daa = GetDataAccessAdapter())
            {                
                // gear type
                var gearTypes = new EntityCollection<GearTypeEntity>();
                daa.FetchEntityCollection(gearTypes, null);
                gearTypeDict = gearTypes.ToDictionary(gt => gt.Name, gt => gt.GearTypeId);
                
                // bearing type
                var bearingTypes = new EntityCollection<BearingTypeEntity>();
                daa.FetchEntityCollection(bearingTypes, null);
                bearingTypeDict = bearingTypes.ToDictionary(gt => gt.Name, gt => gt.BearingTypeId);

                // shaft type
                var shaftTypes = new EntityCollection<ShaftTypeEntity>();
                daa.FetchEntityCollection(shaftTypes, null);
                shaftTypeDict = shaftTypes.ToDictionary(gt => gt.Name, gt => gt.ShaftTypeId);

                // gear error
                var gearError = new EntityCollection<GearErrorVendorEntity>();
                daa.FetchEntityCollection(gearError, null);
                gearErrorDict = gearError.ToDictionary(gt => gt.Name, gt => gt.GearErrorVendorId);

                // bearing error
                var bearingError = new EntityCollection<BearingErrorVendorEntity>();
                daa.FetchEntityCollection(bearingError, null);
                bearingErrorDict = bearingError.ToDictionary(gt => gt.Name, gt => gt.BearingErrorVendorId);

                // shaft error
                var shaftError = new EntityCollection<ShaftErrorVendorEntity>();
                daa.FetchEntityCollection(shaftError, null);
                shaftErrorDict = shaftError.ToDictionary(gt => gt.Name, gt => gt.ShaftErrorVendorId);

                // damage decision
                var damageDecision = new EntityCollection<DamageDecisionEntity>();
                daa.FetchEntityCollection(damageDecision, null);
                damageDecisionDict = damageDecision.ToDictionary(gt => gt.Name, gt => (int) gt.DamageDecisionId);
            }

        }

    }
}
