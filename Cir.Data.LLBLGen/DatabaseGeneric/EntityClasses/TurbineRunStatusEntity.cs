///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.5
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Collections.Generic;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;
using Cir.Data.LLBLGen;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data.LLBLGen.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'TurbineRunStatus'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TurbineRunStatusEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReport_;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReport;
		private EntityCollection<TurbineRunStatusEntity> _turbineRunStatus_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport___;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport____;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport_____;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport__;
		private EntityCollection<ComponentInspectionReportTypeEntity> _componentInspectionReportTypeCollectionViaComponentInspectionReport_;
		private EntityCollection<ComponentInspectionReportTypeEntity> _componentInspectionReportTypeCollectionViaComponentInspectionReport;
		private EntityCollection<CountryIsoEntity> _countryIsoCollectionViaComponentInspectionReport_;
		private EntityCollection<CountryIsoEntity> _countryIsoCollectionViaComponentInspectionReport;
		private EntityCollection<LocationTypeEntity> _locationTypeCollectionViaComponentInspectionReport_;
		private EntityCollection<LocationTypeEntity> _locationTypeCollectionViaComponentInspectionReport;
		private EntityCollection<ReportTypeEntity> _reportTypeCollectionViaComponentInspectionReport_;
		private EntityCollection<ReportTypeEntity> _reportTypeCollectionViaComponentInspectionReport;
		private EntityCollection<SbuEntity> _sbuCollectionViaComponentInspectionReport_;
		private EntityCollection<SbuEntity> _sbuCollectionViaComponentInspectionReport;
		private EntityCollection<ServiceReportNumberTypeEntity> _serviceReportNumberTypeCollectionViaComponentInspectionReport_;
		private EntityCollection<ServiceReportNumberTypeEntity> _serviceReportNumberTypeCollectionViaComponentInspectionReport;
		private EntityCollection<TurbineMatrixEntity> _turbineMatrixCollectionViaComponentInspectionReport_;
		private EntityCollection<TurbineMatrixEntity> _turbineMatrixCollectionViaComponentInspectionReport;
		private TurbineRunStatusEntity _turbineRunStatus;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name TurbineRunStatus</summary>
			public static readonly string TurbineRunStatus = "TurbineRunStatus";
			/// <summary>Member name ComponentInspectionReport_</summary>
			public static readonly string ComponentInspectionReport_ = "ComponentInspectionReport_";
			/// <summary>Member name ComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReport = "ComponentInspectionReport";
			/// <summary>Member name TurbineRunStatus_</summary>
			public static readonly string TurbineRunStatus_ = "TurbineRunStatus_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport___</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport___ = "BooleanAnswerCollectionViaComponentInspectionReport___";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport____</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport____ = "BooleanAnswerCollectionViaComponentInspectionReport____";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport_____</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport_____ = "BooleanAnswerCollectionViaComponentInspectionReport_____";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport = "BooleanAnswerCollectionViaComponentInspectionReport";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport_</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport_ = "BooleanAnswerCollectionViaComponentInspectionReport_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport__</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport__ = "BooleanAnswerCollectionViaComponentInspectionReport__";
			/// <summary>Member name ComponentInspectionReportTypeCollectionViaComponentInspectionReport_</summary>
			public static readonly string ComponentInspectionReportTypeCollectionViaComponentInspectionReport_ = "ComponentInspectionReportTypeCollectionViaComponentInspectionReport_";
			/// <summary>Member name ComponentInspectionReportTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReportTypeCollectionViaComponentInspectionReport = "ComponentInspectionReportTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name CountryIsoCollectionViaComponentInspectionReport_</summary>
			public static readonly string CountryIsoCollectionViaComponentInspectionReport_ = "CountryIsoCollectionViaComponentInspectionReport_";
			/// <summary>Member name CountryIsoCollectionViaComponentInspectionReport</summary>
			public static readonly string CountryIsoCollectionViaComponentInspectionReport = "CountryIsoCollectionViaComponentInspectionReport";
			/// <summary>Member name LocationTypeCollectionViaComponentInspectionReport_</summary>
			public static readonly string LocationTypeCollectionViaComponentInspectionReport_ = "LocationTypeCollectionViaComponentInspectionReport_";
			/// <summary>Member name LocationTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string LocationTypeCollectionViaComponentInspectionReport = "LocationTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name ReportTypeCollectionViaComponentInspectionReport_</summary>
			public static readonly string ReportTypeCollectionViaComponentInspectionReport_ = "ReportTypeCollectionViaComponentInspectionReport_";
			/// <summary>Member name ReportTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string ReportTypeCollectionViaComponentInspectionReport = "ReportTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name SbuCollectionViaComponentInspectionReport_</summary>
			public static readonly string SbuCollectionViaComponentInspectionReport_ = "SbuCollectionViaComponentInspectionReport_";
			/// <summary>Member name SbuCollectionViaComponentInspectionReport</summary>
			public static readonly string SbuCollectionViaComponentInspectionReport = "SbuCollectionViaComponentInspectionReport";
			/// <summary>Member name ServiceReportNumberTypeCollectionViaComponentInspectionReport_</summary>
			public static readonly string ServiceReportNumberTypeCollectionViaComponentInspectionReport_ = "ServiceReportNumberTypeCollectionViaComponentInspectionReport_";
			/// <summary>Member name ServiceReportNumberTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string ServiceReportNumberTypeCollectionViaComponentInspectionReport = "ServiceReportNumberTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name TurbineMatrixCollectionViaComponentInspectionReport_</summary>
			public static readonly string TurbineMatrixCollectionViaComponentInspectionReport_ = "TurbineMatrixCollectionViaComponentInspectionReport_";
			/// <summary>Member name TurbineMatrixCollectionViaComponentInspectionReport</summary>
			public static readonly string TurbineMatrixCollectionViaComponentInspectionReport = "TurbineMatrixCollectionViaComponentInspectionReport";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TurbineRunStatusEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TurbineRunStatusEntity():base("TurbineRunStatusEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TurbineRunStatusEntity(IEntityFields2 fields):base("TurbineRunStatusEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TurbineRunStatusEntity</param>
		public TurbineRunStatusEntity(IValidator validator):base("TurbineRunStatusEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="turbineRunStatusId">PK value for TurbineRunStatus which data should be fetched into this TurbineRunStatus object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TurbineRunStatusEntity(System.Int64 turbineRunStatusId):base("TurbineRunStatusEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TurbineRunStatusId = turbineRunStatusId;
		}

		/// <summary> CTor</summary>
		/// <param name="turbineRunStatusId">PK value for TurbineRunStatus which data should be fetched into this TurbineRunStatus object</param>
		/// <param name="validator">The custom validator object for this TurbineRunStatusEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TurbineRunStatusEntity(System.Int64 turbineRunStatusId, IValidator validator):base("TurbineRunStatusEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TurbineRunStatusId = turbineRunStatusId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TurbineRunStatusEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReport_ = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReport_", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_componentInspectionReport = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReport", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_turbineRunStatus_ = (EntityCollection<TurbineRunStatusEntity>)info.GetValue("_turbineRunStatus_", typeof(EntityCollection<TurbineRunStatusEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport___ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport___", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport____ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport____", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport_____ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport_____", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport_ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport_", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport__ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport__", typeof(EntityCollection<BooleanAnswerEntity>));
				_componentInspectionReportTypeCollectionViaComponentInspectionReport_ = (EntityCollection<ComponentInspectionReportTypeEntity>)info.GetValue("_componentInspectionReportTypeCollectionViaComponentInspectionReport_", typeof(EntityCollection<ComponentInspectionReportTypeEntity>));
				_componentInspectionReportTypeCollectionViaComponentInspectionReport = (EntityCollection<ComponentInspectionReportTypeEntity>)info.GetValue("_componentInspectionReportTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<ComponentInspectionReportTypeEntity>));
				_countryIsoCollectionViaComponentInspectionReport_ = (EntityCollection<CountryIsoEntity>)info.GetValue("_countryIsoCollectionViaComponentInspectionReport_", typeof(EntityCollection<CountryIsoEntity>));
				_countryIsoCollectionViaComponentInspectionReport = (EntityCollection<CountryIsoEntity>)info.GetValue("_countryIsoCollectionViaComponentInspectionReport", typeof(EntityCollection<CountryIsoEntity>));
				_locationTypeCollectionViaComponentInspectionReport_ = (EntityCollection<LocationTypeEntity>)info.GetValue("_locationTypeCollectionViaComponentInspectionReport_", typeof(EntityCollection<LocationTypeEntity>));
				_locationTypeCollectionViaComponentInspectionReport = (EntityCollection<LocationTypeEntity>)info.GetValue("_locationTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<LocationTypeEntity>));
				_reportTypeCollectionViaComponentInspectionReport_ = (EntityCollection<ReportTypeEntity>)info.GetValue("_reportTypeCollectionViaComponentInspectionReport_", typeof(EntityCollection<ReportTypeEntity>));
				_reportTypeCollectionViaComponentInspectionReport = (EntityCollection<ReportTypeEntity>)info.GetValue("_reportTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<ReportTypeEntity>));
				_sbuCollectionViaComponentInspectionReport_ = (EntityCollection<SbuEntity>)info.GetValue("_sbuCollectionViaComponentInspectionReport_", typeof(EntityCollection<SbuEntity>));
				_sbuCollectionViaComponentInspectionReport = (EntityCollection<SbuEntity>)info.GetValue("_sbuCollectionViaComponentInspectionReport", typeof(EntityCollection<SbuEntity>));
				_serviceReportNumberTypeCollectionViaComponentInspectionReport_ = (EntityCollection<ServiceReportNumberTypeEntity>)info.GetValue("_serviceReportNumberTypeCollectionViaComponentInspectionReport_", typeof(EntityCollection<ServiceReportNumberTypeEntity>));
				_serviceReportNumberTypeCollectionViaComponentInspectionReport = (EntityCollection<ServiceReportNumberTypeEntity>)info.GetValue("_serviceReportNumberTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<ServiceReportNumberTypeEntity>));
				_turbineMatrixCollectionViaComponentInspectionReport_ = (EntityCollection<TurbineMatrixEntity>)info.GetValue("_turbineMatrixCollectionViaComponentInspectionReport_", typeof(EntityCollection<TurbineMatrixEntity>));
				_turbineMatrixCollectionViaComponentInspectionReport = (EntityCollection<TurbineMatrixEntity>)info.GetValue("_turbineMatrixCollectionViaComponentInspectionReport", typeof(EntityCollection<TurbineMatrixEntity>));
				_turbineRunStatus = (TurbineRunStatusEntity)info.GetValue("_turbineRunStatus", typeof(TurbineRunStatusEntity));
				if(_turbineRunStatus!=null)
				{
					_turbineRunStatus.AfterSave+=new EventHandler(OnEntityAfterSave);
				}

				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((TurbineRunStatusFieldIndex)fieldIndex)
			{
				case TurbineRunStatusFieldIndex.ParentTurbineRunStatusId:
					DesetupSyncTurbineRunStatus(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity2 entity)
		{
			switch(propertyName)
			{
				case "TurbineRunStatus":
					this.TurbineRunStatus = (TurbineRunStatusEntity)entity;
					break;
				case "ComponentInspectionReport_":
					this.ComponentInspectionReport_.Add((ComponentInspectionReportEntity)entity);
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport.Add((ComponentInspectionReportEntity)entity);
					break;
				case "TurbineRunStatus_":
					this.TurbineRunStatus_.Add((TurbineRunStatusEntity)entity);
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReport___":
					this.BooleanAnswerCollectionViaComponentInspectionReport___.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReport___.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReport___.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReport____":
					this.BooleanAnswerCollectionViaComponentInspectionReport____.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReport____.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReport____.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReport_____":
					this.BooleanAnswerCollectionViaComponentInspectionReport_____.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReport_____.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReport_____.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReport":
					this.BooleanAnswerCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReport.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReport_":
					this.BooleanAnswerCollectionViaComponentInspectionReport_.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReport_.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReport_.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReport__":
					this.BooleanAnswerCollectionViaComponentInspectionReport__.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReport__.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReport__.IsReadOnly = true;
					break;
				case "ComponentInspectionReportTypeCollectionViaComponentInspectionReport_":
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport_.IsReadOnly = false;
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport_.Add((ComponentInspectionReportTypeEntity)entity);
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport_.IsReadOnly = true;
					break;
				case "ComponentInspectionReportTypeCollectionViaComponentInspectionReport":
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport.Add((ComponentInspectionReportTypeEntity)entity);
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "CountryIsoCollectionViaComponentInspectionReport_":
					this.CountryIsoCollectionViaComponentInspectionReport_.IsReadOnly = false;
					this.CountryIsoCollectionViaComponentInspectionReport_.Add((CountryIsoEntity)entity);
					this.CountryIsoCollectionViaComponentInspectionReport_.IsReadOnly = true;
					break;
				case "CountryIsoCollectionViaComponentInspectionReport":
					this.CountryIsoCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.CountryIsoCollectionViaComponentInspectionReport.Add((CountryIsoEntity)entity);
					this.CountryIsoCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "LocationTypeCollectionViaComponentInspectionReport_":
					this.LocationTypeCollectionViaComponentInspectionReport_.IsReadOnly = false;
					this.LocationTypeCollectionViaComponentInspectionReport_.Add((LocationTypeEntity)entity);
					this.LocationTypeCollectionViaComponentInspectionReport_.IsReadOnly = true;
					break;
				case "LocationTypeCollectionViaComponentInspectionReport":
					this.LocationTypeCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.LocationTypeCollectionViaComponentInspectionReport.Add((LocationTypeEntity)entity);
					this.LocationTypeCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "ReportTypeCollectionViaComponentInspectionReport_":
					this.ReportTypeCollectionViaComponentInspectionReport_.IsReadOnly = false;
					this.ReportTypeCollectionViaComponentInspectionReport_.Add((ReportTypeEntity)entity);
					this.ReportTypeCollectionViaComponentInspectionReport_.IsReadOnly = true;
					break;
				case "ReportTypeCollectionViaComponentInspectionReport":
					this.ReportTypeCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.ReportTypeCollectionViaComponentInspectionReport.Add((ReportTypeEntity)entity);
					this.ReportTypeCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "SbuCollectionViaComponentInspectionReport_":
					this.SbuCollectionViaComponentInspectionReport_.IsReadOnly = false;
					this.SbuCollectionViaComponentInspectionReport_.Add((SbuEntity)entity);
					this.SbuCollectionViaComponentInspectionReport_.IsReadOnly = true;
					break;
				case "SbuCollectionViaComponentInspectionReport":
					this.SbuCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.SbuCollectionViaComponentInspectionReport.Add((SbuEntity)entity);
					this.SbuCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "ServiceReportNumberTypeCollectionViaComponentInspectionReport_":
					this.ServiceReportNumberTypeCollectionViaComponentInspectionReport_.IsReadOnly = false;
					this.ServiceReportNumberTypeCollectionViaComponentInspectionReport_.Add((ServiceReportNumberTypeEntity)entity);
					this.ServiceReportNumberTypeCollectionViaComponentInspectionReport_.IsReadOnly = true;
					break;
				case "ServiceReportNumberTypeCollectionViaComponentInspectionReport":
					this.ServiceReportNumberTypeCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.ServiceReportNumberTypeCollectionViaComponentInspectionReport.Add((ServiceReportNumberTypeEntity)entity);
					this.ServiceReportNumberTypeCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "TurbineMatrixCollectionViaComponentInspectionReport_":
					this.TurbineMatrixCollectionViaComponentInspectionReport_.IsReadOnly = false;
					this.TurbineMatrixCollectionViaComponentInspectionReport_.Add((TurbineMatrixEntity)entity);
					this.TurbineMatrixCollectionViaComponentInspectionReport_.IsReadOnly = true;
					break;
				case "TurbineMatrixCollectionViaComponentInspectionReport":
					this.TurbineMatrixCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.TurbineMatrixCollectionViaComponentInspectionReport.Add((TurbineMatrixEntity)entity);
					this.TurbineMatrixCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;

				default:
					break;
			}
		}
#if !CF		
		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it
		/// will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool CheckOneWayRelations(string propertyName)
		{
			// use template trick to calculate the # of single-sided / oneway relations
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));


				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity2 relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "TurbineRunStatus":
					SetupSyncTurbineRunStatus(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport_":
					this.ComponentInspectionReport_.Add((ComponentInspectionReportEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport.Add((ComponentInspectionReportEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbineRunStatus_":
					this.TurbineRunStatus_.Add((TurbineRunStatusEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;

				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "TurbineRunStatus":
					DesetupSyncTurbineRunStatus(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport_":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReport_, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReport, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbineRunStatus_":
					base.PerformRelatedEntityRemoval(this.TurbineRunStatus_, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;

				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_turbineRunStatus!=null)
			{
				toReturn.Add(_turbineRunStatus);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReport_);
			toReturn.Add(this.ComponentInspectionReport);
			toReturn.Add(this.TurbineRunStatus_);

			return toReturn;
		}
		


		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_componentInspectionReport_", ((_componentInspectionReport_!=null) && (_componentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_componentInspectionReport_:null);
				info.AddValue("_componentInspectionReport", ((_componentInspectionReport!=null) && (_componentInspectionReport.Count>0) && !this.MarkedForDeletion)?_componentInspectionReport:null);
				info.AddValue("_turbineRunStatus_", ((_turbineRunStatus_!=null) && (_turbineRunStatus_.Count>0) && !this.MarkedForDeletion)?_turbineRunStatus_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport___", ((_booleanAnswerCollectionViaComponentInspectionReport___!=null) && (_booleanAnswerCollectionViaComponentInspectionReport___.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport___:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport____", ((_booleanAnswerCollectionViaComponentInspectionReport____!=null) && (_booleanAnswerCollectionViaComponentInspectionReport____.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport____:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport_____", ((_booleanAnswerCollectionViaComponentInspectionReport_____!=null) && (_booleanAnswerCollectionViaComponentInspectionReport_____.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport_____:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport", ((_booleanAnswerCollectionViaComponentInspectionReport!=null) && (_booleanAnswerCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport_", ((_booleanAnswerCollectionViaComponentInspectionReport_!=null) && (_booleanAnswerCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport__", ((_booleanAnswerCollectionViaComponentInspectionReport__!=null) && (_booleanAnswerCollectionViaComponentInspectionReport__.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport__:null);
				info.AddValue("_componentInspectionReportTypeCollectionViaComponentInspectionReport_", ((_componentInspectionReportTypeCollectionViaComponentInspectionReport_!=null) && (_componentInspectionReportTypeCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportTypeCollectionViaComponentInspectionReport_:null);
				info.AddValue("_componentInspectionReportTypeCollectionViaComponentInspectionReport", ((_componentInspectionReportTypeCollectionViaComponentInspectionReport!=null) && (_componentInspectionReportTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_countryIsoCollectionViaComponentInspectionReport_", ((_countryIsoCollectionViaComponentInspectionReport_!=null) && (_countryIsoCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_countryIsoCollectionViaComponentInspectionReport_:null);
				info.AddValue("_countryIsoCollectionViaComponentInspectionReport", ((_countryIsoCollectionViaComponentInspectionReport!=null) && (_countryIsoCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_countryIsoCollectionViaComponentInspectionReport:null);
				info.AddValue("_locationTypeCollectionViaComponentInspectionReport_", ((_locationTypeCollectionViaComponentInspectionReport_!=null) && (_locationTypeCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_locationTypeCollectionViaComponentInspectionReport_:null);
				info.AddValue("_locationTypeCollectionViaComponentInspectionReport", ((_locationTypeCollectionViaComponentInspectionReport!=null) && (_locationTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_locationTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_reportTypeCollectionViaComponentInspectionReport_", ((_reportTypeCollectionViaComponentInspectionReport_!=null) && (_reportTypeCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_reportTypeCollectionViaComponentInspectionReport_:null);
				info.AddValue("_reportTypeCollectionViaComponentInspectionReport", ((_reportTypeCollectionViaComponentInspectionReport!=null) && (_reportTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_reportTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_sbuCollectionViaComponentInspectionReport_", ((_sbuCollectionViaComponentInspectionReport_!=null) && (_sbuCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_sbuCollectionViaComponentInspectionReport_:null);
				info.AddValue("_sbuCollectionViaComponentInspectionReport", ((_sbuCollectionViaComponentInspectionReport!=null) && (_sbuCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_sbuCollectionViaComponentInspectionReport:null);
				info.AddValue("_serviceReportNumberTypeCollectionViaComponentInspectionReport_", ((_serviceReportNumberTypeCollectionViaComponentInspectionReport_!=null) && (_serviceReportNumberTypeCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_serviceReportNumberTypeCollectionViaComponentInspectionReport_:null);
				info.AddValue("_serviceReportNumberTypeCollectionViaComponentInspectionReport", ((_serviceReportNumberTypeCollectionViaComponentInspectionReport!=null) && (_serviceReportNumberTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_serviceReportNumberTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_turbineMatrixCollectionViaComponentInspectionReport_", ((_turbineMatrixCollectionViaComponentInspectionReport_!=null) && (_turbineMatrixCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_turbineMatrixCollectionViaComponentInspectionReport_:null);
				info.AddValue("_turbineMatrixCollectionViaComponentInspectionReport", ((_turbineMatrixCollectionViaComponentInspectionReport!=null) && (_turbineMatrixCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_turbineMatrixCollectionViaComponentInspectionReport:null);
				info.AddValue("_turbineRunStatus", (!this.MarkedForDeletion?_turbineRunStatus:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(TurbineRunStatusFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TurbineRunStatusFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TurbineRunStatusRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportFields.AfterInspectionTurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportFields.BeforeInspectionTurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineRunStatus' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineRunStatus_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.ParentTurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingReconstructionBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingReconstructionBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportTypeCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CountryIso' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryIsoCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.CountryIsoEntityUsingCountryIsoid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CountryIso' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryIsoCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.CountryIsoEntityUsingCountryIsoid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'LocationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLocationTypeCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.LocationTypeEntityUsingLocationTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'LocationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLocationTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.LocationTypeEntityUsingLocationTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReportTypeCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ReportTypeEntityUsingReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReportTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ReportTypeEntityUsingReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Sbu' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSbuCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.SbuEntityUsingSbuid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Sbu' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSbuCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.SbuEntityUsingSbuid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ServiceReportNumberType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoServiceReportNumberTypeCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ServiceReportNumberType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoServiceReportNumberTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineMatrix' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineMatrixCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.TurbineMatrixEntityUsingTurbineMatrixId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineMatrix' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineMatrixCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.TurbineMatrixEntityUsingTurbineMatrixId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.TurbineRunStatusId, "TurbineRunStatusEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbineRunStatus' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineRunStatus()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRunStatusFields.TurbineRunStatusId, null, ComparisonOperator.Equal, this.ParentTurbineRunStatusId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReport_);
			collectionsQueue.Enqueue(this._componentInspectionReport);
			collectionsQueue.Enqueue(this._turbineRunStatus_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport___);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport____);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport_____);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport__);
			collectionsQueue.Enqueue(this._componentInspectionReportTypeCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._componentInspectionReportTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._countryIsoCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._countryIsoCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._locationTypeCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._locationTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._reportTypeCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._reportTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._sbuCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._sbuCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._serviceReportNumberTypeCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._serviceReportNumberTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._turbineMatrixCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._turbineMatrixCollectionViaComponentInspectionReport);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReport_ = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReport = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._turbineRunStatus_ = (EntityCollection<TurbineRunStatusEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport___ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport____ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport_____ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport_ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport__ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportTypeCollectionViaComponentInspectionReport_ = (EntityCollection<ComponentInspectionReportTypeEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportTypeCollectionViaComponentInspectionReport = (EntityCollection<ComponentInspectionReportTypeEntity>) collectionsQueue.Dequeue();
			this._countryIsoCollectionViaComponentInspectionReport_ = (EntityCollection<CountryIsoEntity>) collectionsQueue.Dequeue();
			this._countryIsoCollectionViaComponentInspectionReport = (EntityCollection<CountryIsoEntity>) collectionsQueue.Dequeue();
			this._locationTypeCollectionViaComponentInspectionReport_ = (EntityCollection<LocationTypeEntity>) collectionsQueue.Dequeue();
			this._locationTypeCollectionViaComponentInspectionReport = (EntityCollection<LocationTypeEntity>) collectionsQueue.Dequeue();
			this._reportTypeCollectionViaComponentInspectionReport_ = (EntityCollection<ReportTypeEntity>) collectionsQueue.Dequeue();
			this._reportTypeCollectionViaComponentInspectionReport = (EntityCollection<ReportTypeEntity>) collectionsQueue.Dequeue();
			this._sbuCollectionViaComponentInspectionReport_ = (EntityCollection<SbuEntity>) collectionsQueue.Dequeue();
			this._sbuCollectionViaComponentInspectionReport = (EntityCollection<SbuEntity>) collectionsQueue.Dequeue();
			this._serviceReportNumberTypeCollectionViaComponentInspectionReport_ = (EntityCollection<ServiceReportNumberTypeEntity>) collectionsQueue.Dequeue();
			this._serviceReportNumberTypeCollectionViaComponentInspectionReport = (EntityCollection<ServiceReportNumberTypeEntity>) collectionsQueue.Dequeue();
			this._turbineMatrixCollectionViaComponentInspectionReport_ = (EntityCollection<TurbineMatrixEntity>) collectionsQueue.Dequeue();
			this._turbineMatrixCollectionViaComponentInspectionReport = (EntityCollection<TurbineMatrixEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReport_ != null)
			{
				return true;
			}
			if (this._componentInspectionReport != null)
			{
				return true;
			}
			if (this._turbineRunStatus_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReport___ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReport____ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReport_____ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReport_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReport__ != null)
			{
				return true;
			}
			if (this._componentInspectionReportTypeCollectionViaComponentInspectionReport_ != null)
			{
				return true;
			}
			if (this._componentInspectionReportTypeCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._countryIsoCollectionViaComponentInspectionReport_ != null)
			{
				return true;
			}
			if (this._countryIsoCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._locationTypeCollectionViaComponentInspectionReport_ != null)
			{
				return true;
			}
			if (this._locationTypeCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._reportTypeCollectionViaComponentInspectionReport_ != null)
			{
				return true;
			}
			if (this._reportTypeCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._sbuCollectionViaComponentInspectionReport_ != null)
			{
				return true;
			}
			if (this._sbuCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._serviceReportNumberTypeCollectionViaComponentInspectionReport_ != null)
			{
				return true;
			}
			if (this._serviceReportNumberTypeCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._turbineMatrixCollectionViaComponentInspectionReport_ != null)
			{
				return true;
			}
			if (this._turbineMatrixCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("TurbineRunStatus", _turbineRunStatus);
			toReturn.Add("ComponentInspectionReport_", _componentInspectionReport_);
			toReturn.Add("ComponentInspectionReport", _componentInspectionReport);
			toReturn.Add("TurbineRunStatus_", _turbineRunStatus_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport___", _booleanAnswerCollectionViaComponentInspectionReport___);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport____", _booleanAnswerCollectionViaComponentInspectionReport____);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport_____", _booleanAnswerCollectionViaComponentInspectionReport_____);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport", _booleanAnswerCollectionViaComponentInspectionReport);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport_", _booleanAnswerCollectionViaComponentInspectionReport_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport__", _booleanAnswerCollectionViaComponentInspectionReport__);
			toReturn.Add("ComponentInspectionReportTypeCollectionViaComponentInspectionReport_", _componentInspectionReportTypeCollectionViaComponentInspectionReport_);
			toReturn.Add("ComponentInspectionReportTypeCollectionViaComponentInspectionReport", _componentInspectionReportTypeCollectionViaComponentInspectionReport);
			toReturn.Add("CountryIsoCollectionViaComponentInspectionReport_", _countryIsoCollectionViaComponentInspectionReport_);
			toReturn.Add("CountryIsoCollectionViaComponentInspectionReport", _countryIsoCollectionViaComponentInspectionReport);
			toReturn.Add("LocationTypeCollectionViaComponentInspectionReport_", _locationTypeCollectionViaComponentInspectionReport_);
			toReturn.Add("LocationTypeCollectionViaComponentInspectionReport", _locationTypeCollectionViaComponentInspectionReport);
			toReturn.Add("ReportTypeCollectionViaComponentInspectionReport_", _reportTypeCollectionViaComponentInspectionReport_);
			toReturn.Add("ReportTypeCollectionViaComponentInspectionReport", _reportTypeCollectionViaComponentInspectionReport);
			toReturn.Add("SbuCollectionViaComponentInspectionReport_", _sbuCollectionViaComponentInspectionReport_);
			toReturn.Add("SbuCollectionViaComponentInspectionReport", _sbuCollectionViaComponentInspectionReport);
			toReturn.Add("ServiceReportNumberTypeCollectionViaComponentInspectionReport_", _serviceReportNumberTypeCollectionViaComponentInspectionReport_);
			toReturn.Add("ServiceReportNumberTypeCollectionViaComponentInspectionReport", _serviceReportNumberTypeCollectionViaComponentInspectionReport);
			toReturn.Add("TurbineMatrixCollectionViaComponentInspectionReport_", _turbineMatrixCollectionViaComponentInspectionReport_);
			toReturn.Add("TurbineMatrixCollectionViaComponentInspectionReport", _turbineMatrixCollectionViaComponentInspectionReport);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReport_!=null)
			{
				_componentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReport!=null)
			{
				_componentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_turbineRunStatus_!=null)
			{
				_turbineRunStatus_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReport___!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReport___.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReport____!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReport____.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReport_____!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReport_____.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReport!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReport_!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReport__!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReport__.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportTypeCollectionViaComponentInspectionReport_!=null)
			{
				_componentInspectionReportTypeCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportTypeCollectionViaComponentInspectionReport!=null)
			{
				_componentInspectionReportTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_countryIsoCollectionViaComponentInspectionReport_!=null)
			{
				_countryIsoCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_countryIsoCollectionViaComponentInspectionReport!=null)
			{
				_countryIsoCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_locationTypeCollectionViaComponentInspectionReport_!=null)
			{
				_locationTypeCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_locationTypeCollectionViaComponentInspectionReport!=null)
			{
				_locationTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_reportTypeCollectionViaComponentInspectionReport_!=null)
			{
				_reportTypeCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_reportTypeCollectionViaComponentInspectionReport!=null)
			{
				_reportTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_sbuCollectionViaComponentInspectionReport_!=null)
			{
				_sbuCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_sbuCollectionViaComponentInspectionReport!=null)
			{
				_sbuCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_serviceReportNumberTypeCollectionViaComponentInspectionReport_!=null)
			{
				_serviceReportNumberTypeCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_serviceReportNumberTypeCollectionViaComponentInspectionReport!=null)
			{
				_serviceReportNumberTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_turbineMatrixCollectionViaComponentInspectionReport_!=null)
			{
				_turbineMatrixCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_turbineMatrixCollectionViaComponentInspectionReport!=null)
			{
				_turbineMatrixCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_turbineRunStatus!=null)
			{
				_turbineRunStatus.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReport_ = null;
			_componentInspectionReport = null;
			_turbineRunStatus_ = null;
			_booleanAnswerCollectionViaComponentInspectionReport___ = null;
			_booleanAnswerCollectionViaComponentInspectionReport____ = null;
			_booleanAnswerCollectionViaComponentInspectionReport_____ = null;
			_booleanAnswerCollectionViaComponentInspectionReport = null;
			_booleanAnswerCollectionViaComponentInspectionReport_ = null;
			_booleanAnswerCollectionViaComponentInspectionReport__ = null;
			_componentInspectionReportTypeCollectionViaComponentInspectionReport_ = null;
			_componentInspectionReportTypeCollectionViaComponentInspectionReport = null;
			_countryIsoCollectionViaComponentInspectionReport_ = null;
			_countryIsoCollectionViaComponentInspectionReport = null;
			_locationTypeCollectionViaComponentInspectionReport_ = null;
			_locationTypeCollectionViaComponentInspectionReport = null;
			_reportTypeCollectionViaComponentInspectionReport_ = null;
			_reportTypeCollectionViaComponentInspectionReport = null;
			_sbuCollectionViaComponentInspectionReport_ = null;
			_sbuCollectionViaComponentInspectionReport = null;
			_serviceReportNumberTypeCollectionViaComponentInspectionReport_ = null;
			_serviceReportNumberTypeCollectionViaComponentInspectionReport = null;
			_turbineMatrixCollectionViaComponentInspectionReport_ = null;
			_turbineMatrixCollectionViaComponentInspectionReport = null;
			_turbineRunStatus = null;

			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineRunStatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentTurbineRunStatusId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _turbineRunStatus</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbineRunStatus(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbineRunStatus, new PropertyChangedEventHandler( OnTurbineRunStatusPropertyChanged ), "TurbineRunStatus", TurbineRunStatusEntity.Relations.TurbineRunStatusEntityUsingTurbineRunStatusIdParentTurbineRunStatusId, true, signalRelatedEntity, "TurbineRunStatus_", resetFKFields, new int[] { (int)TurbineRunStatusFieldIndex.ParentTurbineRunStatusId } );		
			_turbineRunStatus = null;
		}

		/// <summary> setups the sync logic for member _turbineRunStatus</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbineRunStatus(IEntity2 relatedEntity)
		{
			DesetupSyncTurbineRunStatus(true, true);
			_turbineRunStatus = (TurbineRunStatusEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbineRunStatus, new PropertyChangedEventHandler( OnTurbineRunStatusPropertyChanged ), "TurbineRunStatus", TurbineRunStatusEntity.Relations.TurbineRunStatusEntityUsingTurbineRunStatusIdParentTurbineRunStatusId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbineRunStatusPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this TurbineRunStatusEntity</param>
		/// <param name="fields">Fields of this entity</param>
		protected virtual void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			base.Fields = fields;
			base.IsNew=true;
			base.Validator = validator;
			InitClassMembers();

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static TurbineRunStatusRelations Relations
		{
			get	{ return new TurbineRunStatusRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReport_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),
					TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReport
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),
					TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineRunStatus' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineRunStatus_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory))),
					TurbineRunStatusEntity.Relations.TurbineRunStatusEntityUsingParentTurbineRunStatusId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, 0, null, null, null, null, "TurbineRunStatus_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReport___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReport____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReport_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReport
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingReconstructionBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReport_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingReconstructionBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReport__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportTypeCollectionViaComponentInspectionReport_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTypeEntity, 0, null, null, relations, null, "ComponentInspectionReportTypeCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportTypeCollectionViaComponentInspectionReport
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTypeEntity, 0, null, null, relations, null, "ComponentInspectionReportTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CountryIso' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountryIsoCollectionViaComponentInspectionReport_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.CountryIsoEntityUsingCountryIsoid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, 0, null, null, relations, null, "CountryIsoCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CountryIso' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountryIsoCollectionViaComponentInspectionReport
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.CountryIsoEntityUsingCountryIsoid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, 0, null, null, relations, null, "CountryIsoCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'LocationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLocationTypeCollectionViaComponentInspectionReport_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.LocationTypeEntityUsingLocationTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.LocationTypeEntity, 0, null, null, relations, null, "LocationTypeCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'LocationType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathLocationTypeCollectionViaComponentInspectionReport
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.LocationTypeEntityUsingLocationTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.LocationTypeEntity, 0, null, null, relations, null, "LocationTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReportType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReportTypeCollectionViaComponentInspectionReport_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ReportTypeEntityUsingReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.ReportTypeEntity, 0, null, null, relations, null, "ReportTypeCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ReportType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathReportTypeCollectionViaComponentInspectionReport
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ReportTypeEntityUsingReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.ReportTypeEntity, 0, null, null, relations, null, "ReportTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Sbu' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSbuCollectionViaComponentInspectionReport_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.SbuEntityUsingSbuid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.SbuEntity, 0, null, null, relations, null, "SbuCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Sbu' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSbuCollectionViaComponentInspectionReport
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.SbuEntityUsingSbuid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.SbuEntity, 0, null, null, relations, null, "SbuCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ServiceReportNumberType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathServiceReportNumberTypeCollectionViaComponentInspectionReport_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, 0, null, null, relations, null, "ServiceReportNumberTypeCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ServiceReportNumberType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathServiceReportNumberTypeCollectionViaComponentInspectionReport
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, 0, null, null, relations, null, "ServiceReportNumberTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineMatrix' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineMatrixCollectionViaComponentInspectionReport_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.TurbineMatrixEntityUsingTurbineMatrixId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, 0, null, null, relations, null, "TurbineMatrixCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineMatrix' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineMatrixCollectionViaComponentInspectionReport
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineRunStatusEntity.Relations.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId, "TurbineRunStatusEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.TurbineMatrixEntityUsingTurbineMatrixId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, 0, null, null, relations, null, "TurbineMatrixCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineRunStatus' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineRunStatus
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory))),
					TurbineRunStatusEntity.Relations.TurbineRunStatusEntityUsingTurbineRunStatusIdParentTurbineRunStatusId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, 0, null, null, null, null, "TurbineRunStatus", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TurbineRunStatusEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return TurbineRunStatusEntity.FieldsCustomProperties;}
		}

		/// <summary> The TurbineRunStatusId property of the Entity TurbineRunStatus<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineRunStatus"."TurbineRunStatusId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 TurbineRunStatusId
		{
			get { return (System.Int64)GetValue((int)TurbineRunStatusFieldIndex.TurbineRunStatusId, true); }
			set	{ SetValue((int)TurbineRunStatusFieldIndex.TurbineRunStatusId, value); }
		}

		/// <summary> The Name property of the Entity TurbineRunStatus<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineRunStatus"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)TurbineRunStatusFieldIndex.Name, true); }
			set	{ SetValue((int)TurbineRunStatusFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity TurbineRunStatus<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineRunStatus"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)TurbineRunStatusFieldIndex.LanguageId, true); }
			set	{ SetValue((int)TurbineRunStatusFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentTurbineRunStatusId property of the Entity TurbineRunStatus<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineRunStatus"."ParentTurbineRunStatusId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentTurbineRunStatusId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineRunStatusFieldIndex.ParentTurbineRunStatusId, false); }
			set	{ SetValue((int)TurbineRunStatusFieldIndex.ParentTurbineRunStatusId, value); }
		}

		/// <summary> The Sort property of the Entity TurbineRunStatus<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineRunStatus"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)TurbineRunStatusFieldIndex.Sort, true); }
			set	{ SetValue((int)TurbineRunStatusFieldIndex.Sort, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReport_
		{
			get
			{
				if(_componentInspectionReport_==null)
				{
					_componentInspectionReport_ = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReport_.SetContainingEntityInfo(this, "TurbineRunStatus_");
				}
				return _componentInspectionReport_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReport
		{
			get
			{
				if(_componentInspectionReport==null)
				{
					_componentInspectionReport = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReport.SetContainingEntityInfo(this, "TurbineRunStatus");
				}
				return _componentInspectionReport;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineRunStatusEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineRunStatusEntity))]
		public virtual EntityCollection<TurbineRunStatusEntity> TurbineRunStatus_
		{
			get
			{
				if(_turbineRunStatus_==null)
				{
					_turbineRunStatus_ = new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory)));
					_turbineRunStatus_.SetContainingEntityInfo(this, "TurbineRunStatus");
				}
				return _turbineRunStatus_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReport___
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReport___==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReport___ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReport___.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReport___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReport____
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReport____==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReport____ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReport____.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReport____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReport_____
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReport_____==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReport_____ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReport_____.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReport_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReport
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReport==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReport = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReport.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReport;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReport_
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReport_==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReport_ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReport_.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReport_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReport__
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReport__==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReport__ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReport__.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReport__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportTypeEntity))]
		public virtual EntityCollection<ComponentInspectionReportTypeEntity> ComponentInspectionReportTypeCollectionViaComponentInspectionReport_
		{
			get
			{
				if(_componentInspectionReportTypeCollectionViaComponentInspectionReport_==null)
				{
					_componentInspectionReportTypeCollectionViaComponentInspectionReport_ = new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory)));
					_componentInspectionReportTypeCollectionViaComponentInspectionReport_.IsReadOnly=true;
				}
				return _componentInspectionReportTypeCollectionViaComponentInspectionReport_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportTypeEntity))]
		public virtual EntityCollection<ComponentInspectionReportTypeEntity> ComponentInspectionReportTypeCollectionViaComponentInspectionReport
		{
			get
			{
				if(_componentInspectionReportTypeCollectionViaComponentInspectionReport==null)
				{
					_componentInspectionReportTypeCollectionViaComponentInspectionReport = new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory)));
					_componentInspectionReportTypeCollectionViaComponentInspectionReport.IsReadOnly=true;
				}
				return _componentInspectionReportTypeCollectionViaComponentInspectionReport;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CountryIsoEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CountryIsoEntity))]
		public virtual EntityCollection<CountryIsoEntity> CountryIsoCollectionViaComponentInspectionReport_
		{
			get
			{
				if(_countryIsoCollectionViaComponentInspectionReport_==null)
				{
					_countryIsoCollectionViaComponentInspectionReport_ = new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory)));
					_countryIsoCollectionViaComponentInspectionReport_.IsReadOnly=true;
				}
				return _countryIsoCollectionViaComponentInspectionReport_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CountryIsoEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CountryIsoEntity))]
		public virtual EntityCollection<CountryIsoEntity> CountryIsoCollectionViaComponentInspectionReport
		{
			get
			{
				if(_countryIsoCollectionViaComponentInspectionReport==null)
				{
					_countryIsoCollectionViaComponentInspectionReport = new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory)));
					_countryIsoCollectionViaComponentInspectionReport.IsReadOnly=true;
				}
				return _countryIsoCollectionViaComponentInspectionReport;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LocationTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LocationTypeEntity))]
		public virtual EntityCollection<LocationTypeEntity> LocationTypeCollectionViaComponentInspectionReport_
		{
			get
			{
				if(_locationTypeCollectionViaComponentInspectionReport_==null)
				{
					_locationTypeCollectionViaComponentInspectionReport_ = new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory)));
					_locationTypeCollectionViaComponentInspectionReport_.IsReadOnly=true;
				}
				return _locationTypeCollectionViaComponentInspectionReport_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'LocationTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(LocationTypeEntity))]
		public virtual EntityCollection<LocationTypeEntity> LocationTypeCollectionViaComponentInspectionReport
		{
			get
			{
				if(_locationTypeCollectionViaComponentInspectionReport==null)
				{
					_locationTypeCollectionViaComponentInspectionReport = new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory)));
					_locationTypeCollectionViaComponentInspectionReport.IsReadOnly=true;
				}
				return _locationTypeCollectionViaComponentInspectionReport;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ReportTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReportTypeEntity))]
		public virtual EntityCollection<ReportTypeEntity> ReportTypeCollectionViaComponentInspectionReport_
		{
			get
			{
				if(_reportTypeCollectionViaComponentInspectionReport_==null)
				{
					_reportTypeCollectionViaComponentInspectionReport_ = new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory)));
					_reportTypeCollectionViaComponentInspectionReport_.IsReadOnly=true;
				}
				return _reportTypeCollectionViaComponentInspectionReport_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ReportTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ReportTypeEntity))]
		public virtual EntityCollection<ReportTypeEntity> ReportTypeCollectionViaComponentInspectionReport
		{
			get
			{
				if(_reportTypeCollectionViaComponentInspectionReport==null)
				{
					_reportTypeCollectionViaComponentInspectionReport = new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory)));
					_reportTypeCollectionViaComponentInspectionReport.IsReadOnly=true;
				}
				return _reportTypeCollectionViaComponentInspectionReport;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SbuEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SbuEntity))]
		public virtual EntityCollection<SbuEntity> SbuCollectionViaComponentInspectionReport_
		{
			get
			{
				if(_sbuCollectionViaComponentInspectionReport_==null)
				{
					_sbuCollectionViaComponentInspectionReport_ = new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory)));
					_sbuCollectionViaComponentInspectionReport_.IsReadOnly=true;
				}
				return _sbuCollectionViaComponentInspectionReport_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SbuEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SbuEntity))]
		public virtual EntityCollection<SbuEntity> SbuCollectionViaComponentInspectionReport
		{
			get
			{
				if(_sbuCollectionViaComponentInspectionReport==null)
				{
					_sbuCollectionViaComponentInspectionReport = new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory)));
					_sbuCollectionViaComponentInspectionReport.IsReadOnly=true;
				}
				return _sbuCollectionViaComponentInspectionReport;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ServiceReportNumberTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ServiceReportNumberTypeEntity))]
		public virtual EntityCollection<ServiceReportNumberTypeEntity> ServiceReportNumberTypeCollectionViaComponentInspectionReport_
		{
			get
			{
				if(_serviceReportNumberTypeCollectionViaComponentInspectionReport_==null)
				{
					_serviceReportNumberTypeCollectionViaComponentInspectionReport_ = new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory)));
					_serviceReportNumberTypeCollectionViaComponentInspectionReport_.IsReadOnly=true;
				}
				return _serviceReportNumberTypeCollectionViaComponentInspectionReport_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ServiceReportNumberTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ServiceReportNumberTypeEntity))]
		public virtual EntityCollection<ServiceReportNumberTypeEntity> ServiceReportNumberTypeCollectionViaComponentInspectionReport
		{
			get
			{
				if(_serviceReportNumberTypeCollectionViaComponentInspectionReport==null)
				{
					_serviceReportNumberTypeCollectionViaComponentInspectionReport = new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory)));
					_serviceReportNumberTypeCollectionViaComponentInspectionReport.IsReadOnly=true;
				}
				return _serviceReportNumberTypeCollectionViaComponentInspectionReport;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineMatrixEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineMatrixEntity))]
		public virtual EntityCollection<TurbineMatrixEntity> TurbineMatrixCollectionViaComponentInspectionReport_
		{
			get
			{
				if(_turbineMatrixCollectionViaComponentInspectionReport_==null)
				{
					_turbineMatrixCollectionViaComponentInspectionReport_ = new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory)));
					_turbineMatrixCollectionViaComponentInspectionReport_.IsReadOnly=true;
				}
				return _turbineMatrixCollectionViaComponentInspectionReport_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineMatrixEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineMatrixEntity))]
		public virtual EntityCollection<TurbineMatrixEntity> TurbineMatrixCollectionViaComponentInspectionReport
		{
			get
			{
				if(_turbineMatrixCollectionViaComponentInspectionReport==null)
				{
					_turbineMatrixCollectionViaComponentInspectionReport = new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory)));
					_turbineMatrixCollectionViaComponentInspectionReport.IsReadOnly=true;
				}
				return _turbineMatrixCollectionViaComponentInspectionReport;
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbineRunStatusEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbineRunStatusEntity TurbineRunStatus
		{
			get
			{
				return _turbineRunStatus;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbineRunStatus(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbineRunStatus != null)
						{
							_turbineRunStatus.UnsetRelatedEntity(this, "TurbineRunStatus_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineRunStatus_");
					}
				}
			}
		}

	
		
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity; }
		}
		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
