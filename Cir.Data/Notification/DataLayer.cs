using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using Cir.Common.Cir;
using Cir.Common.MailArchive;
using Cir.Common.Manufacturers;
using Cir.Common.Notification;
using Cir.Common.Utilities;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.DatabaseSpecific;
using cirController = Cir.Data.Cir;
using System.Xml;

namespace Cir.Data.Notification {
	public class DataLayer : BaseDataLayer {
		public DataLayer(string connectionString)
			: base(connectionString) {
		}

		public void AddSbuRejectNotification(long cirId, long? sbuId, string filename, long? cimCaseNo, string rejectedBy, string comment) {
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				SburejectNotificationEntity ec = new SburejectNotificationEntity();
				ec.InfoPathFilename = filename;
				ec.ComponentInspectionReportId = cirId;
				ec.SendOn = null;
				ec.Sbuid = sbuId;
				ec.RejectedBy = rejectedBy;
				ec.Comment = comment;
				ec.CimcaseNo = cimCaseNo;

				daa.SaveEntity(ec);
			}
		}

		public void AddRejectNotification(long cirId, long? sbuId, string filename, string email, string rejectedBy, string comment, long cimCaseNo) {
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				RejectNotificationEntity ec = new RejectNotificationEntity();
				ec.InfoPathFilename = filename;
				ec.ComponentInspectionReportId = cirId;
				ec.SendOn = null;
				ec.SendTo = email;
				ec.RejectedBy = rejectedBy;
				ec.Comment = comment;
				ec.Received = System.DateTime.Now;
				ec.Sbuid = sbuId;
				ec.CimcaseNo = cimCaseNo;

				daa.SaveEntity(ec);
			}
		}

		public void AddReceiptNotification(long cirId, string filename, string email, decimal cirVersion) {
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				ReceiptNotificationEntity ec = new ReceiptNotificationEntity();
				ec.SendOn = null;
				ec.ComponentInspectionReportId = cirId;
				ec.InfoPathFilename = filename;
				ec.SendTo = email;
				ec.CirVersion = cirVersion;

				daa.SaveEntity(ec);
			}
		}

		public void AddSbuNotification(long cirId, long sbuId, long? turbineMatrixId, long? countryIsoId, string componentType, long cimCaseNo, DateTime? editDate, string siteName, bool isNewCir, SbuNotificationType notificationType) {
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				SbunotificationEntity ec = new SbunotificationEntity();

				ec.ComponentInspectionReportId = cirId;
				ec.Sbuid = sbuId;
				ec.TurbineMatrixId = turbineMatrixId;
				ec.CountryIsoid = countryIsoId;
				ec.ComponentType = componentType;
				ec.CimcaseNo = cimCaseNo;
				ec.EditDate = editDate;

				ec.Sitename = siteName;
				ec.SendOn = null;
				// this is to satisfy the legacy notification service
				ec.State = (isNewCir ? "New" : "Updated");
				ec.Warning = (short)notificationType;
				daa.SaveEntity(ec);
			}
		}

		public DateTime ? GetFirstPendingNotificationDate(){

			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				var ec = new EntityCollection<FirstNotificationEntity>();
				var filter = new RelationPredicateBucket();
				var sort = new SortExpression(FirstNotificationFields.QueuedOn | SortOperator.Ascending);
				filter.PredicateExpression.Add(FirstNotificationFields.SendOn == DBNull.Value);
				daa.FetchEntityCollection(ec, filter, 1, sort);
				if(ec.Count == 1) {
					return ec[0].QueuedOn;
				}
			}
			return null;
		}

		public bool FirstNotificationExists(long cirId, long countryIsoId, DateTime? commisioningDate, DateTime? failureDate, string componentType, long turbineMatrixId, long manufacturerId, string siteName, string serialNumber) {
			var filter = new RelationPredicateBucket();
			filter.PredicateExpression.Add(FirstNotificationFields.ComponentInspectionReportId == cirId);
			filter.PredicateExpression.Add(FirstNotificationFields.CountryIsoid == countryIsoId);
			if(commisioningDate.HasValue) {
				filter.PredicateExpression.Add(FirstNotificationFields.CommisioningDate == commisioningDate);
			}
			else {
				filter.PredicateExpression.Add(FirstNotificationFields.CommisioningDate == DBNull.Value);
			}
			if (failureDate.HasValue) {
				filter.PredicateExpression.Add(FirstNotificationFields.FailureDate == failureDate);
			}
			else {
				filter.PredicateExpression.Add(FirstNotificationFields.FailureDate == DBNull.Value);
			}

			filter.PredicateExpression.Add(FirstNotificationFields.ComponentType == componentType);
			filter.PredicateExpression.Add(FirstNotificationFields.TurbineMatrixId == turbineMatrixId);
			filter.PredicateExpression.Add(FirstNotificationFields.ManufacturerId == manufacturerId);
			filter.PredicateExpression.Add(FirstNotificationFields.Sitename == siteName);
			filter.PredicateExpression.Add(FirstNotificationFields.SerialNo == serialNumber);

			var ec = new EntityCollection<FirstNotificationEntity>();
			var count = 0;
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				count = daa.GetDbCount(ec, filter);
			}
			return count > 0;
		}

		public void AddFirstNotification(long cirDataId, long cirId, long sbuId, long countryIsoId, DateTime? commisioningDate, DateTime? failureDate, DateTime? editDate, string componentType, long turbineMatrixId, long manufacturerId, string editInitials, string siteName, string serialNumber){
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {

				var ec = new FirstNotificationEntity();
				ec.CirDataId = cirDataId;
				ec.ComponentInspectionReportId = cirId;
				ec.Sbuid = sbuId;
				ec.TurbineMatrixId = turbineMatrixId;
				ec.CountryIsoid = countryIsoId;
				ec.ComponentType = componentType;
				ec.CommisioningDate = commisioningDate;
				ec.FailureDate = failureDate;
				ec.EditDate = editDate;
				ec.QueuedOn = DateTime.Now;
				ec.SendOn = null;
				ec.ManufacturerId = manufacturerId;
				ec.SerialNo = serialNumber;
				ec.Sitename = siteName;
				ec.EditInitials = editInitials;

				daa.SaveEntity(ec);
			}
		}

		public DateTime ? GetFirstNofiticationDate(long cirId, long manufacturerId) {
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				var ec = new EntityCollection<FirstNotificationEntity>();
				var filter = new RelationPredicateBucket();
				filter.PredicateExpression.Add(FirstNotificationFields.ComponentInspectionReportId == cirId);
				filter.PredicateExpression.Add(FirstNotificationFields.ManufacturerId == manufacturerId);
				daa.FetchEntityCollection(ec, filter, 1);
				if (ec.Count == 1) {
					return ec[0].SendOn;
				}
			}
			return null;
		}

		public void AddSecondNotification(long cirDataId, long cirId, long cimCaseNumber, long sbuId, string componentType, long turbineMatrixId, long manufacturerId){
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				var ec = new SecondNotificationEntity();
				ec.CirDataId = cirDataId;
				ec.ComponentInspectionReportId = cirId;
				ec.Sbuid = sbuId;
				ec.TurbineMatrixId = turbineMatrixId;
				ec.ComponentType = componentType;
				ec.CimcaseNumber = cimCaseNumber;
				ec.ManufacturerId = manufacturerId;

				daa.SaveEntity(ec);
			}
		}

		public DateTime? GetSecondNofiticationDate(long cirId, long manufacturerId) {
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				var ec = new EntityCollection<SecondNotificationEntity>();
				var filter = new RelationPredicateBucket();
				filter.PredicateExpression.Add(SecondNotificationFields.ComponentInspectionReportId == cirId);
				filter.PredicateExpression.Add(SecondNotificationFields.ManufacturerId == manufacturerId);
				daa.FetchEntityCollection(ec, filter, 1);
				if (ec.Count == 1) {
					return ec[0].SendOn;
				}
			}
			return null;
		}



		//public bool HasSecondNofiticationBeenSent(long cirId, long manufacturerId) {
		//    using (DataAccessAdapter daa = GetDataAccessAdapter()) {
		//        var ec = new EntityCollection<SecondNotificationEntity>();
		//        var filter = new RelationPredicateBucket();
		//        filter.PredicateExpression.Add(SecondNotificationFields.ComponentInspectionReportId == cirId);
		//        daa.FetchEntityCollection(ec, filter, 1);
		//        if (ec.Count == 1) {
		//            return (ec[0].ManufacturerId == manufacturerId);
		//        }
		//    }
		//    return false;
		//}

		public string GetReportTypeName(long reportTypeId) {
			using (DataAccessAdapter daa = GetDataAccessAdapter()) {
				var entity = new ReportTypeEntity(reportTypeId);
				if(daa.FetchEntity(entity)) {
					return entity.Name;
				}
				//var ec = new EntityCollection<ReportTypeEntity>();
				//var fb = new RelationPredicateBucket();
				//fb.PredicateExpression.Add(ReportTypeFields.ReportTypeId == reportTypeId);

				//daa.FetchEntityCollection(ec, fb);

				//if(ec.Count == 1) {
				//    return ec[0].Name;
				//}
			}
			return null;
		}

        public void GetAllPendingNotifications(out long receiptNofitications, out long sbuNofitications, out long sbuRejectNofitications, 
                                               out long rejectNofitications, out long firstNofitications, out long secondNofitications) {
            receiptNofitications = GetPendingReceiptNofitications();
            sbuNofitications = GetPendingSbuNofitications();
            sbuRejectNofitications = GetPendingSbuRejectNofitications();
            rejectNofitications = GetPendingRejectNofitications();
            firstNofitications = GetPendingFirstNofitications();
            secondNofitications = GetPendingSecondNofitications();
        }

        public long GetPendingReceiptNofitications(){
            using (DataAccessAdapter daa = GetDataAccessAdapter()){
                var ec = new EntityCollection<ReceiptNotificationEntity>();
                var filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(ReceiptNotificationFields.SendOn == DBNull.Value);
                daa.FetchEntityCollection(ec, filter, 10);
                if (ec.Count > 0){
                    return ec.Count;
                }
            }
            return 0;
        }

        public long GetPendingSbuNofitications(){
            using (DataAccessAdapter daa = GetDataAccessAdapter()){
                var ec = new EntityCollection<SbunotificationEntity>();
                var filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(SbunotificationFields.SendOn == DBNull.Value);
                daa.FetchEntityCollection(ec, filter, 10);
                if (ec.Count > 0){
                    return ec.Count;
                }
            }
            return 0;
        }

        public long GetPendingSbuRejectNofitications(){
            using (DataAccessAdapter daa = GetDataAccessAdapter()){
                var ec = new EntityCollection<SburejectNotificationEntity>();
                var filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(SburejectNotificationFields.SendOn == DBNull.Value);
                daa.FetchEntityCollection(ec, filter, 10);
                if (ec.Count > 0){
                    return ec.Count;
                }
            }
            return 0;
        }

        public long GetPendingRejectNofitications(){
            using (DataAccessAdapter daa = GetDataAccessAdapter()){
                var ec = new EntityCollection<RejectNotificationEntity>();
                var filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(RejectNotificationFields.SendOn == DBNull.Value);
                daa.FetchEntityCollection(ec, filter, 10);
                if (ec.Count > 0)
                {
                    return ec.Count;
                }
            }
            return 0;
        }

        public long GetPendingFirstNofitications(){
            using (DataAccessAdapter daa = GetDataAccessAdapter()){
                var ec = new EntityCollection<FirstNotificationEntity>();
                var filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(FirstNotificationFields.SendOn == DBNull.Value);
                daa.FetchEntityCollection(ec, filter, 10);
                if (ec.Count > 0){
                    return ec.Count;
                }
            }
            return 0;
        }

        public long GetPendingSecondNofitications(){
            using (DataAccessAdapter daa = GetDataAccessAdapter()){
                var ec = new EntityCollection<SecondNotificationEntity>();
                var filter = new RelationPredicateBucket();
                filter.PredicateExpression.Add(SecondNotificationFields.SendOn == DBNull.Value);
                daa.FetchEntityCollection(ec, filter, 10);
                if (ec.Count > 0) {
                    return ec.Count;
                }
            }
            return 0;
        }

		public void AddInvalidNotification(long? sbuId, string fileName, string email) {
			using (var daa = GetDataAccessAdapter()) {
				var ec = new InvalidNotificationEntity();
				ec.Sbuid = sbuId;
				ec.InfoPathFileName = fileName;
				ec.SendTo = email;
				ec.SendOn = null;
				ec.Received = DateTime.Now;
				daa.SaveEntity(ec);
			}
		}

	    public List<Common.Notification.Notification> SearchNotifications(int cirId, int turbineId, int notificationType, string componentType, string serialNumber, int cimCaseNumber, string commissioningDate, string installationDate) {
            var controller = new cirController.DataLayer(ConnectionString);
            //var dl = new Data.MailArchive.DataLayer(ConnectionString);
            //var mail = dl.GetArchivedMail(cirDataId, MailType.FirstNotification);
            //var mime = Mime.Parse(mail[0].Mail);
            var notifications = new List<Common.Notification.Notification>();
            using (var daa = GetDataAccessAdapter()) {
                
                if(notificationType == 1) {
                    var ec = new EntityCollection<FirstNotificationEntity>();
                    var pe1 = new PredicateExpression();
                    var pe2 = new PredicateExpression();
                    var filter = new RelationPredicateBucket();

                    if(cirId != 0) {
                        pe1.Add(FirstNotificationFields.ComponentInspectionReportId == cirId);
                    }
                    if (turbineId != 0)
                    {
                        var cirDataId = controller.GetCirDataIdFromMetaData(turbineId);
                        if(cirDataId.Count == 0) {
                            return null;
                        }
                        pe1.Add(FirstNotificationFields.CirDataId == cirDataId);
                    }
                    if (componentType != ""){
                        pe1.Add(FirstNotificationFields.ComponentType == componentType);
                    }
                    if (serialNumber != ""){
                        pe1.Add(FirstNotificationFields.SerialNo == serialNumber);    
                    }
                    if(commissioningDate != "") {
                        pe1.Add(FirstNotificationFields.CommisioningDate == commissioningDate);    
                    }
                    if(installationDate != "")
                    {
                        var componentInspectionReports = GetCirIdViaInstallationDateFromCir(installationDate);
                        if (componentInspectionReports == null) {
                            return null;
                        }
                        foreach (var componentInspectionReportEntity in componentInspectionReports)
                        {
                            pe2.AddWithOr(FirstNotificationFields.ComponentInspectionReportId == componentInspectionReportEntity.ComponentInspectionReportId);
                        }
                    }


                    filter.PredicateExpression.Add(pe1);    
                    filter.PredicateExpression.Add(pe2);
                    daa.FetchEntityCollection(ec, filter);
                    if (ec.Count > 0)
                    {
                        notifications.AddRange(ec.Select(entity => new Common.Notification.Notification(entity.ComponentInspectionReportId, 
                                                                                                        "First Notification", 
                                                                                                        entity.ComponentType, 
                                                                                                        GetManufacturerName(entity.ManufacturerId, entity.ComponentType), 
                                                                                                        entity.SerialNo,
                                                                                                        GetTurbineIdFromCir(entity.ComponentInspectionReportId).ToString() == "0" ? "N/A" : GetTurbineIdFromCir(entity.ComponentInspectionReportId).ToString(),
                                                                                                        GetCaseNumberFromCir(entity.ComponentInspectionReportId).ToString() == "0" ? "N/A" : GetCaseNumberFromCir(entity.ComponentInspectionReportId).ToString(),
                                                                                                        string.Format("{0:yyyy-MM-dd}",entity.CommisioningDate),
                                                                                                        GetInstallationDateFromCir(entity.ComponentInspectionReportId) == string.Empty ? "N/A" : GetInstallationDateFromCir(entity.ComponentInspectionReportId),
                                                                                                        entity.SendOn.ToString(), 
                                                                                                        entity.EditInitials)));
                    }

                }
                if (notificationType == 2){
                    var ec = new EntityCollection<SecondNotificationEntity>();
                    var pe1 = new PredicateExpression();
                    var pe2 = new PredicateExpression();
                    var filter = new RelationPredicateBucket();
                    if (cirId != 0)
                    {
                        pe1.Add(SecondNotificationFields.ComponentInspectionReportId == cirId);
                    }
                    if (turbineId != 0)
                    {
                        var cirDataId = controller.GetCirDataIdFromMetaData(turbineId);
                        if (cirDataId.Count == 0)
                        {
                            return null;
                        }
                        pe1.Add(SecondNotificationFields.CirDataId == cirDataId);
                    }
                    if (componentType != "")
                    {
                        pe1.Add(SecondNotificationFields.ComponentType == componentType);
                    }
                    if (cimCaseNumber != 0)
                    {
                        pe1.Add(SecondNotificationFields.CimcaseNumber == cimCaseNumber);
                    }
                    if (installationDate != "")
                    {
                        var componentInspectionReports = GetCirIdViaInstallationDateFromCir(installationDate);
                        if (componentInspectionReports == null) {
                            return null;
                        }
                        foreach (var componentInspectionReportEntity in componentInspectionReports)
                        {
                            pe2.AddWithOr(SecondNotificationFields.ComponentInspectionReportId == componentInspectionReportEntity.ComponentInspectionReportId);
                        }
                    }
                    filter.PredicateExpression.Add(pe1);
                    filter.PredicateExpression.Add(pe2);
                    daa.FetchEntityCollection(ec, filter);
                    if (ec.Count > 0)
                    {
                        notifications.AddRange(ec.Select(entity => new Common.Notification.Notification(entity.ComponentInspectionReportId, 
                                                                                                        "Second Notification", 
                                                                                                        entity.ComponentType,
                                                                                                        GetManufacturerName(entity.ManufacturerId, entity.ComponentType),
                                                                                                        GetSerialNumberFromFirstNotification(entity.ComponentInspectionReportId),
                                                                                                        GetTurbineIdFromCir(entity.ComponentInspectionReportId).ToString(),
                                                                                                        entity.CimcaseNumber.ToString(),
                                                                                                        GetCommisioningDateFromFirstNotification(entity.ComponentInspectionReportId),
                                                                                                        GetInstallationDateFromCir(entity.ComponentInspectionReportId),
                                                                                                        entity.SendOn.ToString(),
                                                                                                        GetApproverFromCirData(entity.ComponentInspectionReportId) == string.Empty ? "N/A" : GetApproverFromCirData(entity.ComponentInspectionReportId).ToLowerInvariant())));
                      
                    }

                }    
            }


	        return notifications;
	    }

        /// <summary>
        /// Gets turbine ID from the ComponentInspectionReport table.
        /// </summary>
        /// <param name="cirId"></param>
        /// <returns></returns>
        public string GetApproverFromCirData(long cirId)
        {
            var approver = string.Empty;
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<CirDataEntity>(new CirDataEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(CirDataFields.CirId == cirId);
                fb.PredicateExpression.Add(CirDataFields.State == 2);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    approver = ec[0].ModifiedBy;
                }
                return approver;
            }
        }


        /// <summary>
        /// Gets turbine ID from the ComponentInspectionReport table.
        /// </summary>
        /// <param name="cirId"></param>
        /// <returns></returns>
        public long GetTurbineIdFromCir(long cirId)
        {
            long turbineId = 0;
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<ComponentInspectionReportEntity>(new ComponentInspectionReportEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(ComponentInspectionReportFields.ComponentInspectionReportId == cirId);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    turbineId = ec[0].TurbineNumber;
                }
                return turbineId;
            }
        }

        /// <summary>
        /// Gets CIM Case Number from the ComponentInspectionReport table.
        /// </summary>
        /// <param name="cirId"></param>
        /// <returns></returns>
        public long GetCaseNumberFromCir(long cirId)
        {
            long caseNumber = 0;
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<ComponentInspectionReportEntity>(new ComponentInspectionReportEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(ComponentInspectionReportFields.ComponentInspectionReportId == cirId);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    caseNumber = ec[0].CimcaseNumber;
                }
                return caseNumber;
            }
        }

        /// <summary>
        /// Gets installation date from the ComponentInspectionReport table.
        /// </summary>
        /// <param name="cirId"></param>
        /// <returns></returns>
        public string GetInstallationDateFromCir(long cirId)
        {
            var installationDate = string.Empty;
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<ComponentInspectionReportEntity>(new ComponentInspectionReportEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(ComponentInspectionReportFields.ComponentInspectionReportId == cirId);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    installationDate = string.Format("{0:yyyy-MM-dd}", ec[0].InstallationDate);
                }
                return installationDate;
            }
        }

        /// <summary>
        /// Gets CIRs via installation date from the ComponentInspectionReport table.
        /// </summary>
        /// <param name="installationDate"></param>
        /// <returns></returns>
        public EntityCollection<ComponentInspectionReportEntity> GetCirIdViaInstallationDateFromCir(string installationDate)
        {
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<ComponentInspectionReportEntity>(new ComponentInspectionReportEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(ComponentInspectionReportFields.InstallationDate == installationDate);
                daa.FetchEntityCollection(ec, fb);
                return ec.Count > 0 ? ec : null;
            }
        }

        /// <summary>
        /// Gets serial number from first notification.
        /// </summary>
        /// <param name="cirId"></param>
        /// <returns></returns>
        public string GetSerialNumberFromFirstNotification(long cirId)
        {
            var serialNo = string.Empty;
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<FirstNotificationEntity>(new FirstNotificationEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(FirstNotificationFields.ComponentInspectionReportId == cirId);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    serialNo = ec[0].SerialNo;
                }
                return serialNo;
            }
        }


        /// <summary>
        /// Gets the commisioning date from first notification.
        /// </summary>
        /// <param name="cirId"></param>
        /// <returns></returns>
        public string GetCommisioningDateFromFirstNotification(long cirId)
        {
            var commisioningDate = string.Empty;
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<FirstNotificationEntity>(new FirstNotificationEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(FirstNotificationFields.ComponentInspectionReportId == cirId);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    commisioningDate = string.Format("{0:yyyy-MM-dd}", ec[0].CommisioningDate);
                }
                return commisioningDate;
            }
        }

	    /// <summary>
        /// Gets manufacturer name from the manufacturer id and the component type.
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <param name="componentType"></param>
        /// <returns></returns>
        public string GetManufacturerName(long? manufacturerId, string componentType)
	    {
	        var _manufacturerId = manufacturerId ?? 0;
            switch (componentType)
            {
                case "Blade":
                    return GetBladeManufacturerName(_manufacturerId);

                case "Gearbox":
                    return GetGearboxManufacturerName(_manufacturerId);

                case "Generator":
                    return GetGeneratorManufacturerName(_manufacturerId);

                case "Main Bearing":
                    return GetMainBearingManufacturerName(_manufacturerId);

                case "Transformer":
                    return GetTransformerManufacturerName(_manufacturerId);

                default:
                    return "N/A";
            }
        }


	    /// <summary>
        /// Gets blade manufacturer name from the manufacturer id.
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <returns></returns>
        public string GetBladeManufacturerName(long manufacturerId)
        {
            var bladeManufacturerName = "N/A";
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<BladeManufacturerEntity>(new BladeManufacturerEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(BladeManufacturerFields.BladeManufacturerId == manufacturerId);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    bladeManufacturerName = ec[0].Name;
                }
                return bladeManufacturerName;
            }
        }

        /// <summary>
        /// Gets gearbox manufacturer name from the manufacturer id.
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <returns></returns>
        public string GetGearboxManufacturerName(long manufacturerId)
        {
            var gearboxManufacturerName = "N/A";
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<GearboxManufacturerEntity>(new GearboxManufacturerEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(GearboxManufacturerFields.GearboxManufacturerId== manufacturerId);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    gearboxManufacturerName = ec[0].Name;
                }
                return gearboxManufacturerName;
            }
        }

        /// <summary>
        /// Gets generator manufacturer name from the manufacturer id.
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <returns></returns>
        public string GetGeneratorManufacturerName(long manufacturerId)
        {
            var generatorManufacturerName = "N/A";
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<GeneratorManufacturerEntity>(new GeneratorManufacturerEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(GeneratorManufacturerFields.GeneratorManufacturerId == manufacturerId);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    generatorManufacturerName = ec[0].Name;
                }
                return generatorManufacturerName;
            }
        }

        /// <summary>
        /// Gets main bearing manufacturer name from the manufacturer id.
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <returns></returns>
        public string GetMainBearingManufacturerName(long manufacturerId)
        {
            var mainBearingManufacturerName = "N/A";
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<MainBearingManufacturerEntity>(new MainBearingManufacturerEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(MainBearingManufacturerFields.MainBearingManufacturerId == manufacturerId);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    mainBearingManufacturerName = ec[0].Name;
                }
                return mainBearingManufacturerName;
            }
        }

        /// <summary>
        /// Gets transformer manufacturer name from the manufacturer id.
        /// </summary>
        /// <param name="manufacturerId"></param>
        /// <returns></returns>
        public string GetTransformerManufacturerName(long manufacturerId)
        {
            var transformerManufacturerName = "N/A";
            using (var daa = GetDataAccessAdapter())
            {
                var ec = new EntityCollection<TransformerManufacturerEntity>(new TransformerManufacturerEntityFactory());
                var fb = new RelationPredicateBucket();
                fb.PredicateExpression.Add(TransformerManufacturerFields.TransformerManufacturerId == manufacturerId);
                daa.FetchEntityCollection(ec, fb);
                if (ec.Count > 0)
                {
                    transformerManufacturerName = ec[0].Name;
                }
                return transformerManufacturerName;
            }
        }

	}
}
