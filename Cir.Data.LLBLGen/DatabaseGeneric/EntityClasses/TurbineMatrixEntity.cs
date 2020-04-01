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
	/// Entity class which represents the entity 'TurbineMatrix'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TurbineMatrixEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReport;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport__;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport;
		private EntityCollection<ComponentInspectionReportTypeEntity> _componentInspectionReportTypeCollectionViaComponentInspectionReport;
		private EntityCollection<CountryIsoEntity> _countryIsoCollectionViaComponentInspectionReport;
		private EntityCollection<LocationTypeEntity> _locationTypeCollectionViaComponentInspectionReport;
		private EntityCollection<ReportTypeEntity> _reportTypeCollectionViaComponentInspectionReport;
		private EntityCollection<SbuEntity> _sbuCollectionViaComponentInspectionReport;
		private EntityCollection<ServiceReportNumberTypeEntity> _serviceReportNumberTypeCollectionViaComponentInspectionReport;
		private EntityCollection<TurbineRunStatusEntity> _turbineRunStatusCollectionViaComponentInspectionReport_;
		private EntityCollection<TurbineRunStatusEntity> _turbineRunStatusCollectionViaComponentInspectionReport;
		private TurbineEntity _turbine;
		private TurbineFrequencyEntity _turbineFrequency;
		private TurbineManufacturerEntity _turbineManufacturer;
		private TurbineMarkVersionEntity _turbineMarkVersion;
		private TurbineNominelPowerEntity _turbineNominelPower;
		private TurbineOldEntity _turbineOld;
		private TurbinePlacementEntity _turbinePlacement;
		private TurbinePowerRegulationEntity _turbinePowerRegulation;
		private TurbineRotorDiameterEntity _turbineRotorDiameter;
		private TurbineSmallGeneratorEntity _turbineSmallGenerator;
		private TurbineTemperatureVariantEntity _turbineTemperatureVariant;
		private TurbineVoltageEntity _turbineVoltage;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name Turbine</summary>
			public static readonly string Turbine = "Turbine";
			/// <summary>Member name TurbineFrequency</summary>
			public static readonly string TurbineFrequency = "TurbineFrequency";
			/// <summary>Member name TurbineManufacturer</summary>
			public static readonly string TurbineManufacturer = "TurbineManufacturer";
			/// <summary>Member name TurbineMarkVersion</summary>
			public static readonly string TurbineMarkVersion = "TurbineMarkVersion";
			/// <summary>Member name TurbineNominelPower</summary>
			public static readonly string TurbineNominelPower = "TurbineNominelPower";
			/// <summary>Member name TurbineOld</summary>
			public static readonly string TurbineOld = "TurbineOld";
			/// <summary>Member name TurbinePlacement</summary>
			public static readonly string TurbinePlacement = "TurbinePlacement";
			/// <summary>Member name TurbinePowerRegulation</summary>
			public static readonly string TurbinePowerRegulation = "TurbinePowerRegulation";
			/// <summary>Member name TurbineRotorDiameter</summary>
			public static readonly string TurbineRotorDiameter = "TurbineRotorDiameter";
			/// <summary>Member name TurbineSmallGenerator</summary>
			public static readonly string TurbineSmallGenerator = "TurbineSmallGenerator";
			/// <summary>Member name TurbineTemperatureVariant</summary>
			public static readonly string TurbineTemperatureVariant = "TurbineTemperatureVariant";
			/// <summary>Member name TurbineVoltage</summary>
			public static readonly string TurbineVoltage = "TurbineVoltage";
			/// <summary>Member name ComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReport = "ComponentInspectionReport";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport__</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport__ = "BooleanAnswerCollectionViaComponentInspectionReport__";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport_</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport_ = "BooleanAnswerCollectionViaComponentInspectionReport_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport = "BooleanAnswerCollectionViaComponentInspectionReport";
			/// <summary>Member name ComponentInspectionReportTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReportTypeCollectionViaComponentInspectionReport = "ComponentInspectionReportTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name CountryIsoCollectionViaComponentInspectionReport</summary>
			public static readonly string CountryIsoCollectionViaComponentInspectionReport = "CountryIsoCollectionViaComponentInspectionReport";
			/// <summary>Member name LocationTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string LocationTypeCollectionViaComponentInspectionReport = "LocationTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name ReportTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string ReportTypeCollectionViaComponentInspectionReport = "ReportTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name SbuCollectionViaComponentInspectionReport</summary>
			public static readonly string SbuCollectionViaComponentInspectionReport = "SbuCollectionViaComponentInspectionReport";
			/// <summary>Member name ServiceReportNumberTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string ServiceReportNumberTypeCollectionViaComponentInspectionReport = "ServiceReportNumberTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name TurbineRunStatusCollectionViaComponentInspectionReport_</summary>
			public static readonly string TurbineRunStatusCollectionViaComponentInspectionReport_ = "TurbineRunStatusCollectionViaComponentInspectionReport_";
			/// <summary>Member name TurbineRunStatusCollectionViaComponentInspectionReport</summary>
			public static readonly string TurbineRunStatusCollectionViaComponentInspectionReport = "TurbineRunStatusCollectionViaComponentInspectionReport";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TurbineMatrixEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TurbineMatrixEntity():base("TurbineMatrixEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TurbineMatrixEntity(IEntityFields2 fields):base("TurbineMatrixEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TurbineMatrixEntity</param>
		public TurbineMatrixEntity(IValidator validator):base("TurbineMatrixEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="turbineMatrixId">PK value for TurbineMatrix which data should be fetched into this TurbineMatrix object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TurbineMatrixEntity(System.Int64 turbineMatrixId):base("TurbineMatrixEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TurbineMatrixId = turbineMatrixId;
		}

		/// <summary> CTor</summary>
		/// <param name="turbineMatrixId">PK value for TurbineMatrix which data should be fetched into this TurbineMatrix object</param>
		/// <param name="validator">The custom validator object for this TurbineMatrixEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TurbineMatrixEntity(System.Int64 turbineMatrixId, IValidator validator):base("TurbineMatrixEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TurbineMatrixId = turbineMatrixId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TurbineMatrixEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReport = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReport", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport__ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport__", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport_ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport_", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport", typeof(EntityCollection<BooleanAnswerEntity>));
				_componentInspectionReportTypeCollectionViaComponentInspectionReport = (EntityCollection<ComponentInspectionReportTypeEntity>)info.GetValue("_componentInspectionReportTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<ComponentInspectionReportTypeEntity>));
				_countryIsoCollectionViaComponentInspectionReport = (EntityCollection<CountryIsoEntity>)info.GetValue("_countryIsoCollectionViaComponentInspectionReport", typeof(EntityCollection<CountryIsoEntity>));
				_locationTypeCollectionViaComponentInspectionReport = (EntityCollection<LocationTypeEntity>)info.GetValue("_locationTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<LocationTypeEntity>));
				_reportTypeCollectionViaComponentInspectionReport = (EntityCollection<ReportTypeEntity>)info.GetValue("_reportTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<ReportTypeEntity>));
				_sbuCollectionViaComponentInspectionReport = (EntityCollection<SbuEntity>)info.GetValue("_sbuCollectionViaComponentInspectionReport", typeof(EntityCollection<SbuEntity>));
				_serviceReportNumberTypeCollectionViaComponentInspectionReport = (EntityCollection<ServiceReportNumberTypeEntity>)info.GetValue("_serviceReportNumberTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<ServiceReportNumberTypeEntity>));
				_turbineRunStatusCollectionViaComponentInspectionReport_ = (EntityCollection<TurbineRunStatusEntity>)info.GetValue("_turbineRunStatusCollectionViaComponentInspectionReport_", typeof(EntityCollection<TurbineRunStatusEntity>));
				_turbineRunStatusCollectionViaComponentInspectionReport = (EntityCollection<TurbineRunStatusEntity>)info.GetValue("_turbineRunStatusCollectionViaComponentInspectionReport", typeof(EntityCollection<TurbineRunStatusEntity>));
				_turbine = (TurbineEntity)info.GetValue("_turbine", typeof(TurbineEntity));
				if(_turbine!=null)
				{
					_turbine.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_turbineFrequency = (TurbineFrequencyEntity)info.GetValue("_turbineFrequency", typeof(TurbineFrequencyEntity));
				if(_turbineFrequency!=null)
				{
					_turbineFrequency.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_turbineManufacturer = (TurbineManufacturerEntity)info.GetValue("_turbineManufacturer", typeof(TurbineManufacturerEntity));
				if(_turbineManufacturer!=null)
				{
					_turbineManufacturer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_turbineMarkVersion = (TurbineMarkVersionEntity)info.GetValue("_turbineMarkVersion", typeof(TurbineMarkVersionEntity));
				if(_turbineMarkVersion!=null)
				{
					_turbineMarkVersion.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_turbineNominelPower = (TurbineNominelPowerEntity)info.GetValue("_turbineNominelPower", typeof(TurbineNominelPowerEntity));
				if(_turbineNominelPower!=null)
				{
					_turbineNominelPower.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_turbineOld = (TurbineOldEntity)info.GetValue("_turbineOld", typeof(TurbineOldEntity));
				if(_turbineOld!=null)
				{
					_turbineOld.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_turbinePlacement = (TurbinePlacementEntity)info.GetValue("_turbinePlacement", typeof(TurbinePlacementEntity));
				if(_turbinePlacement!=null)
				{
					_turbinePlacement.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_turbinePowerRegulation = (TurbinePowerRegulationEntity)info.GetValue("_turbinePowerRegulation", typeof(TurbinePowerRegulationEntity));
				if(_turbinePowerRegulation!=null)
				{
					_turbinePowerRegulation.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_turbineRotorDiameter = (TurbineRotorDiameterEntity)info.GetValue("_turbineRotorDiameter", typeof(TurbineRotorDiameterEntity));
				if(_turbineRotorDiameter!=null)
				{
					_turbineRotorDiameter.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_turbineSmallGenerator = (TurbineSmallGeneratorEntity)info.GetValue("_turbineSmallGenerator", typeof(TurbineSmallGeneratorEntity));
				if(_turbineSmallGenerator!=null)
				{
					_turbineSmallGenerator.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_turbineTemperatureVariant = (TurbineTemperatureVariantEntity)info.GetValue("_turbineTemperatureVariant", typeof(TurbineTemperatureVariantEntity));
				if(_turbineTemperatureVariant!=null)
				{
					_turbineTemperatureVariant.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_turbineVoltage = (TurbineVoltageEntity)info.GetValue("_turbineVoltage", typeof(TurbineVoltageEntity));
				if(_turbineVoltage!=null)
				{
					_turbineVoltage.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((TurbineMatrixFieldIndex)fieldIndex)
			{
				case TurbineMatrixFieldIndex.TurbineId:
					DesetupSyncTurbine(true, false);
					break;
				case TurbineMatrixFieldIndex.TurbinePowerRegulationId:
					DesetupSyncTurbinePowerRegulation(true, false);
					break;
				case TurbineMatrixFieldIndex.TurbineRotorDiameterId:
					DesetupSyncTurbineRotorDiameter(true, false);
					break;
				case TurbineMatrixFieldIndex.TurbineNominelPowerId:
					DesetupSyncTurbineNominelPower(true, false);
					break;
				case TurbineMatrixFieldIndex.TurbineVoltageId:
					DesetupSyncTurbineVoltage(true, false);
					break;
				case TurbineMatrixFieldIndex.TurbineFrequencyId:
					DesetupSyncTurbineFrequency(true, false);
					break;
				case TurbineMatrixFieldIndex.TurbineSmallGeneratorId:
					DesetupSyncTurbineSmallGenerator(true, false);
					break;
				case TurbineMatrixFieldIndex.TurbineTemperatureVariantId:
					DesetupSyncTurbineTemperatureVariant(true, false);
					break;
				case TurbineMatrixFieldIndex.TurbineMarkVersionId:
					DesetupSyncTurbineMarkVersion(true, false);
					break;
				case TurbineMatrixFieldIndex.TurbinePlacementId:
					DesetupSyncTurbinePlacement(true, false);
					break;
				case TurbineMatrixFieldIndex.TurbineManufacturerId:
					DesetupSyncTurbineManufacturer(true, false);
					break;
				case TurbineMatrixFieldIndex.TurbineOldId:
					DesetupSyncTurbineOld(true, false);
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
				case "Turbine":
					this.Turbine = (TurbineEntity)entity;
					break;
				case "TurbineFrequency":
					this.TurbineFrequency = (TurbineFrequencyEntity)entity;
					break;
				case "TurbineManufacturer":
					this.TurbineManufacturer = (TurbineManufacturerEntity)entity;
					break;
				case "TurbineMarkVersion":
					this.TurbineMarkVersion = (TurbineMarkVersionEntity)entity;
					break;
				case "TurbineNominelPower":
					this.TurbineNominelPower = (TurbineNominelPowerEntity)entity;
					break;
				case "TurbineOld":
					this.TurbineOld = (TurbineOldEntity)entity;
					break;
				case "TurbinePlacement":
					this.TurbinePlacement = (TurbinePlacementEntity)entity;
					break;
				case "TurbinePowerRegulation":
					this.TurbinePowerRegulation = (TurbinePowerRegulationEntity)entity;
					break;
				case "TurbineRotorDiameter":
					this.TurbineRotorDiameter = (TurbineRotorDiameterEntity)entity;
					break;
				case "TurbineSmallGenerator":
					this.TurbineSmallGenerator = (TurbineSmallGeneratorEntity)entity;
					break;
				case "TurbineTemperatureVariant":
					this.TurbineTemperatureVariant = (TurbineTemperatureVariantEntity)entity;
					break;
				case "TurbineVoltage":
					this.TurbineVoltage = (TurbineVoltageEntity)entity;
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport.Add((ComponentInspectionReportEntity)entity);
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReport__":
					this.BooleanAnswerCollectionViaComponentInspectionReport__.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReport__.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReport__.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReport_":
					this.BooleanAnswerCollectionViaComponentInspectionReport_.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReport_.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReport_.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReport":
					this.BooleanAnswerCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReport.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "ComponentInspectionReportTypeCollectionViaComponentInspectionReport":
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport.Add((ComponentInspectionReportTypeEntity)entity);
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "CountryIsoCollectionViaComponentInspectionReport":
					this.CountryIsoCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.CountryIsoCollectionViaComponentInspectionReport.Add((CountryIsoEntity)entity);
					this.CountryIsoCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "LocationTypeCollectionViaComponentInspectionReport":
					this.LocationTypeCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.LocationTypeCollectionViaComponentInspectionReport.Add((LocationTypeEntity)entity);
					this.LocationTypeCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "ReportTypeCollectionViaComponentInspectionReport":
					this.ReportTypeCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.ReportTypeCollectionViaComponentInspectionReport.Add((ReportTypeEntity)entity);
					this.ReportTypeCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "SbuCollectionViaComponentInspectionReport":
					this.SbuCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.SbuCollectionViaComponentInspectionReport.Add((SbuEntity)entity);
					this.SbuCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "ServiceReportNumberTypeCollectionViaComponentInspectionReport":
					this.ServiceReportNumberTypeCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.ServiceReportNumberTypeCollectionViaComponentInspectionReport.Add((ServiceReportNumberTypeEntity)entity);
					this.ServiceReportNumberTypeCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "TurbineRunStatusCollectionViaComponentInspectionReport_":
					this.TurbineRunStatusCollectionViaComponentInspectionReport_.IsReadOnly = false;
					this.TurbineRunStatusCollectionViaComponentInspectionReport_.Add((TurbineRunStatusEntity)entity);
					this.TurbineRunStatusCollectionViaComponentInspectionReport_.IsReadOnly = true;
					break;
				case "TurbineRunStatusCollectionViaComponentInspectionReport":
					this.TurbineRunStatusCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.TurbineRunStatusCollectionViaComponentInspectionReport.Add((TurbineRunStatusEntity)entity);
					this.TurbineRunStatusCollectionViaComponentInspectionReport.IsReadOnly = true;
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
				case "Turbine":
					SetupSyncTurbine(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbineFrequency":
					SetupSyncTurbineFrequency(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbineManufacturer":
					SetupSyncTurbineManufacturer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbineMarkVersion":
					SetupSyncTurbineMarkVersion(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbineNominelPower":
					SetupSyncTurbineNominelPower(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbineOld":
					SetupSyncTurbineOld(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbinePlacement":
					SetupSyncTurbinePlacement(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbinePowerRegulation":
					SetupSyncTurbinePowerRegulation(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbineRotorDiameter":
					SetupSyncTurbineRotorDiameter(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbineSmallGenerator":
					SetupSyncTurbineSmallGenerator(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbineTemperatureVariant":
					SetupSyncTurbineTemperatureVariant(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TurbineVoltage":
					SetupSyncTurbineVoltage(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport.Add((ComponentInspectionReportEntity)relatedEntity);
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
				case "Turbine":
					DesetupSyncTurbine(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbineFrequency":
					DesetupSyncTurbineFrequency(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbineManufacturer":
					DesetupSyncTurbineManufacturer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbineMarkVersion":
					DesetupSyncTurbineMarkVersion(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbineNominelPower":
					DesetupSyncTurbineNominelPower(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbineOld":
					DesetupSyncTurbineOld(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbinePlacement":
					DesetupSyncTurbinePlacement(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbinePowerRegulation":
					DesetupSyncTurbinePowerRegulation(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbineRotorDiameter":
					DesetupSyncTurbineRotorDiameter(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbineSmallGenerator":
					DesetupSyncTurbineSmallGenerator(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbineTemperatureVariant":
					DesetupSyncTurbineTemperatureVariant(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TurbineVoltage":
					DesetupSyncTurbineVoltage(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReport, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_turbine!=null)
			{
				toReturn.Add(_turbine);
			}
			if(_turbineFrequency!=null)
			{
				toReturn.Add(_turbineFrequency);
			}
			if(_turbineManufacturer!=null)
			{
				toReturn.Add(_turbineManufacturer);
			}
			if(_turbineMarkVersion!=null)
			{
				toReturn.Add(_turbineMarkVersion);
			}
			if(_turbineNominelPower!=null)
			{
				toReturn.Add(_turbineNominelPower);
			}
			if(_turbineOld!=null)
			{
				toReturn.Add(_turbineOld);
			}
			if(_turbinePlacement!=null)
			{
				toReturn.Add(_turbinePlacement);
			}
			if(_turbinePowerRegulation!=null)
			{
				toReturn.Add(_turbinePowerRegulation);
			}
			if(_turbineRotorDiameter!=null)
			{
				toReturn.Add(_turbineRotorDiameter);
			}
			if(_turbineSmallGenerator!=null)
			{
				toReturn.Add(_turbineSmallGenerator);
			}
			if(_turbineTemperatureVariant!=null)
			{
				toReturn.Add(_turbineTemperatureVariant);
			}
			if(_turbineVoltage!=null)
			{
				toReturn.Add(_turbineVoltage);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReport);

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
				info.AddValue("_componentInspectionReport", ((_componentInspectionReport!=null) && (_componentInspectionReport.Count>0) && !this.MarkedForDeletion)?_componentInspectionReport:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport__", ((_booleanAnswerCollectionViaComponentInspectionReport__!=null) && (_booleanAnswerCollectionViaComponentInspectionReport__.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport__:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport_", ((_booleanAnswerCollectionViaComponentInspectionReport_!=null) && (_booleanAnswerCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport", ((_booleanAnswerCollectionViaComponentInspectionReport!=null) && (_booleanAnswerCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport:null);
				info.AddValue("_componentInspectionReportTypeCollectionViaComponentInspectionReport", ((_componentInspectionReportTypeCollectionViaComponentInspectionReport!=null) && (_componentInspectionReportTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_countryIsoCollectionViaComponentInspectionReport", ((_countryIsoCollectionViaComponentInspectionReport!=null) && (_countryIsoCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_countryIsoCollectionViaComponentInspectionReport:null);
				info.AddValue("_locationTypeCollectionViaComponentInspectionReport", ((_locationTypeCollectionViaComponentInspectionReport!=null) && (_locationTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_locationTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_reportTypeCollectionViaComponentInspectionReport", ((_reportTypeCollectionViaComponentInspectionReport!=null) && (_reportTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_reportTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_sbuCollectionViaComponentInspectionReport", ((_sbuCollectionViaComponentInspectionReport!=null) && (_sbuCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_sbuCollectionViaComponentInspectionReport:null);
				info.AddValue("_serviceReportNumberTypeCollectionViaComponentInspectionReport", ((_serviceReportNumberTypeCollectionViaComponentInspectionReport!=null) && (_serviceReportNumberTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_serviceReportNumberTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_turbineRunStatusCollectionViaComponentInspectionReport_", ((_turbineRunStatusCollectionViaComponentInspectionReport_!=null) && (_turbineRunStatusCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_turbineRunStatusCollectionViaComponentInspectionReport_:null);
				info.AddValue("_turbineRunStatusCollectionViaComponentInspectionReport", ((_turbineRunStatusCollectionViaComponentInspectionReport!=null) && (_turbineRunStatusCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_turbineRunStatusCollectionViaComponentInspectionReport:null);
				info.AddValue("_turbine", (!this.MarkedForDeletion?_turbine:null));
				info.AddValue("_turbineFrequency", (!this.MarkedForDeletion?_turbineFrequency:null));
				info.AddValue("_turbineManufacturer", (!this.MarkedForDeletion?_turbineManufacturer:null));
				info.AddValue("_turbineMarkVersion", (!this.MarkedForDeletion?_turbineMarkVersion:null));
				info.AddValue("_turbineNominelPower", (!this.MarkedForDeletion?_turbineNominelPower:null));
				info.AddValue("_turbineOld", (!this.MarkedForDeletion?_turbineOld:null));
				info.AddValue("_turbinePlacement", (!this.MarkedForDeletion?_turbinePlacement:null));
				info.AddValue("_turbinePowerRegulation", (!this.MarkedForDeletion?_turbinePowerRegulation:null));
				info.AddValue("_turbineRotorDiameter", (!this.MarkedForDeletion?_turbineRotorDiameter:null));
				info.AddValue("_turbineSmallGenerator", (!this.MarkedForDeletion?_turbineSmallGenerator:null));
				info.AddValue("_turbineTemperatureVariant", (!this.MarkedForDeletion?_turbineTemperatureVariant:null));
				info.AddValue("_turbineVoltage", (!this.MarkedForDeletion?_turbineVoltage:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(TurbineMatrixFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TurbineMatrixFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TurbineMatrixRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId, "TurbineMatrixEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId, "TurbineMatrixEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingReconstructionBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId, "TurbineMatrixEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId, "TurbineMatrixEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CountryIso' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryIsoCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.CountryIsoEntityUsingCountryIsoid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId, "TurbineMatrixEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'LocationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLocationTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.LocationTypeEntityUsingLocationTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId, "TurbineMatrixEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReportTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ReportTypeEntityUsingReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId, "TurbineMatrixEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Sbu' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSbuCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.SbuEntityUsingSbuid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId, "TurbineMatrixEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ServiceReportNumberType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoServiceReportNumberTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId, "TurbineMatrixEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineRunStatus' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineRunStatusCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingAfterInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId, "TurbineMatrixEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineRunStatus' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineRunStatusCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingBeforeInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineMatrixId, null, ComparisonOperator.Equal, this.TurbineMatrixId, "TurbineMatrixEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Turbine' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbine()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineFields.TurbineId, null, ComparisonOperator.Equal, this.TurbineId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbineFrequency' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineFrequency()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineFrequencyFields.TurbineFrequencyId, null, ComparisonOperator.Equal, this.TurbineFrequencyId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbineManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineManufacturer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbineMarkVersion' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineMarkVersion()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMarkVersionFields.TurbineMarkVersionId, null, ComparisonOperator.Equal, this.TurbineMarkVersionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbineNominelPower' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineNominelPower()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineNominelPowerFields.TurbineNominelPowerId, null, ComparisonOperator.Equal, this.TurbineNominelPowerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbineOld' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineOld()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineOldFields.TurbineOldId, null, ComparisonOperator.Equal, this.TurbineOldId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbinePlacement' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbinePlacement()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbinePlacementFields.TurbinePlacementId, null, ComparisonOperator.Equal, this.TurbinePlacementId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbinePowerRegulation' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbinePowerRegulation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbinePowerRegulationFields.TurbinePowerRegulationId, null, ComparisonOperator.Equal, this.TurbinePowerRegulationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbineRotorDiameter' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineRotorDiameter()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineRotorDiameterFields.TurbineRotorDiameterId, null, ComparisonOperator.Equal, this.TurbineRotorDiameterId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbineSmallGenerator' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineSmallGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineSmallGeneratorFields.TurbineSmallGeneratorId, null, ComparisonOperator.Equal, this.TurbineSmallGeneratorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbineTemperatureVariant' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineTemperatureVariant()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineTemperatureVariantFields.TurbineTemperatureVariantId, null, ComparisonOperator.Equal, this.TurbineTemperatureVariantId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TurbineVoltage' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineVoltage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineVoltageFields.TurbineVoltageId, null, ComparisonOperator.Equal, this.TurbineVoltageId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReport);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport__);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._componentInspectionReportTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._countryIsoCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._locationTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._reportTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._sbuCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._serviceReportNumberTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._turbineRunStatusCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._turbineRunStatusCollectionViaComponentInspectionReport);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReport = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport__ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport_ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportTypeCollectionViaComponentInspectionReport = (EntityCollection<ComponentInspectionReportTypeEntity>) collectionsQueue.Dequeue();
			this._countryIsoCollectionViaComponentInspectionReport = (EntityCollection<CountryIsoEntity>) collectionsQueue.Dequeue();
			this._locationTypeCollectionViaComponentInspectionReport = (EntityCollection<LocationTypeEntity>) collectionsQueue.Dequeue();
			this._reportTypeCollectionViaComponentInspectionReport = (EntityCollection<ReportTypeEntity>) collectionsQueue.Dequeue();
			this._sbuCollectionViaComponentInspectionReport = (EntityCollection<SbuEntity>) collectionsQueue.Dequeue();
			this._serviceReportNumberTypeCollectionViaComponentInspectionReport = (EntityCollection<ServiceReportNumberTypeEntity>) collectionsQueue.Dequeue();
			this._turbineRunStatusCollectionViaComponentInspectionReport_ = (EntityCollection<TurbineRunStatusEntity>) collectionsQueue.Dequeue();
			this._turbineRunStatusCollectionViaComponentInspectionReport = (EntityCollection<TurbineRunStatusEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReport != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReport__ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReport_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._componentInspectionReportTypeCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._countryIsoCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._locationTypeCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._reportTypeCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._sbuCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._serviceReportNumberTypeCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._turbineRunStatusCollectionViaComponentInspectionReport_ != null)
			{
				return true;
			}
			if (this._turbineRunStatusCollectionViaComponentInspectionReport != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Turbine", _turbine);
			toReturn.Add("TurbineFrequency", _turbineFrequency);
			toReturn.Add("TurbineManufacturer", _turbineManufacturer);
			toReturn.Add("TurbineMarkVersion", _turbineMarkVersion);
			toReturn.Add("TurbineNominelPower", _turbineNominelPower);
			toReturn.Add("TurbineOld", _turbineOld);
			toReturn.Add("TurbinePlacement", _turbinePlacement);
			toReturn.Add("TurbinePowerRegulation", _turbinePowerRegulation);
			toReturn.Add("TurbineRotorDiameter", _turbineRotorDiameter);
			toReturn.Add("TurbineSmallGenerator", _turbineSmallGenerator);
			toReturn.Add("TurbineTemperatureVariant", _turbineTemperatureVariant);
			toReturn.Add("TurbineVoltage", _turbineVoltage);
			toReturn.Add("ComponentInspectionReport", _componentInspectionReport);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport__", _booleanAnswerCollectionViaComponentInspectionReport__);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport_", _booleanAnswerCollectionViaComponentInspectionReport_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport", _booleanAnswerCollectionViaComponentInspectionReport);
			toReturn.Add("ComponentInspectionReportTypeCollectionViaComponentInspectionReport", _componentInspectionReportTypeCollectionViaComponentInspectionReport);
			toReturn.Add("CountryIsoCollectionViaComponentInspectionReport", _countryIsoCollectionViaComponentInspectionReport);
			toReturn.Add("LocationTypeCollectionViaComponentInspectionReport", _locationTypeCollectionViaComponentInspectionReport);
			toReturn.Add("ReportTypeCollectionViaComponentInspectionReport", _reportTypeCollectionViaComponentInspectionReport);
			toReturn.Add("SbuCollectionViaComponentInspectionReport", _sbuCollectionViaComponentInspectionReport);
			toReturn.Add("ServiceReportNumberTypeCollectionViaComponentInspectionReport", _serviceReportNumberTypeCollectionViaComponentInspectionReport);
			toReturn.Add("TurbineRunStatusCollectionViaComponentInspectionReport_", _turbineRunStatusCollectionViaComponentInspectionReport_);
			toReturn.Add("TurbineRunStatusCollectionViaComponentInspectionReport", _turbineRunStatusCollectionViaComponentInspectionReport);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReport!=null)
			{
				_componentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReport__!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReport__.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReport_!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReport!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportTypeCollectionViaComponentInspectionReport!=null)
			{
				_componentInspectionReportTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_countryIsoCollectionViaComponentInspectionReport!=null)
			{
				_countryIsoCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_locationTypeCollectionViaComponentInspectionReport!=null)
			{
				_locationTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_reportTypeCollectionViaComponentInspectionReport!=null)
			{
				_reportTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_sbuCollectionViaComponentInspectionReport!=null)
			{
				_sbuCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_serviceReportNumberTypeCollectionViaComponentInspectionReport!=null)
			{
				_serviceReportNumberTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_turbineRunStatusCollectionViaComponentInspectionReport_!=null)
			{
				_turbineRunStatusCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_turbineRunStatusCollectionViaComponentInspectionReport!=null)
			{
				_turbineRunStatusCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_turbine!=null)
			{
				_turbine.ActiveContext = base.ActiveContext;
			}
			if(_turbineFrequency!=null)
			{
				_turbineFrequency.ActiveContext = base.ActiveContext;
			}
			if(_turbineManufacturer!=null)
			{
				_turbineManufacturer.ActiveContext = base.ActiveContext;
			}
			if(_turbineMarkVersion!=null)
			{
				_turbineMarkVersion.ActiveContext = base.ActiveContext;
			}
			if(_turbineNominelPower!=null)
			{
				_turbineNominelPower.ActiveContext = base.ActiveContext;
			}
			if(_turbineOld!=null)
			{
				_turbineOld.ActiveContext = base.ActiveContext;
			}
			if(_turbinePlacement!=null)
			{
				_turbinePlacement.ActiveContext = base.ActiveContext;
			}
			if(_turbinePowerRegulation!=null)
			{
				_turbinePowerRegulation.ActiveContext = base.ActiveContext;
			}
			if(_turbineRotorDiameter!=null)
			{
				_turbineRotorDiameter.ActiveContext = base.ActiveContext;
			}
			if(_turbineSmallGenerator!=null)
			{
				_turbineSmallGenerator.ActiveContext = base.ActiveContext;
			}
			if(_turbineTemperatureVariant!=null)
			{
				_turbineTemperatureVariant.ActiveContext = base.ActiveContext;
			}
			if(_turbineVoltage!=null)
			{
				_turbineVoltage.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReport = null;
			_booleanAnswerCollectionViaComponentInspectionReport__ = null;
			_booleanAnswerCollectionViaComponentInspectionReport_ = null;
			_booleanAnswerCollectionViaComponentInspectionReport = null;
			_componentInspectionReportTypeCollectionViaComponentInspectionReport = null;
			_countryIsoCollectionViaComponentInspectionReport = null;
			_locationTypeCollectionViaComponentInspectionReport = null;
			_reportTypeCollectionViaComponentInspectionReport = null;
			_sbuCollectionViaComponentInspectionReport = null;
			_serviceReportNumberTypeCollectionViaComponentInspectionReport = null;
			_turbineRunStatusCollectionViaComponentInspectionReport_ = null;
			_turbineRunStatusCollectionViaComponentInspectionReport = null;
			_turbine = null;
			_turbineFrequency = null;
			_turbineManufacturer = null;
			_turbineMarkVersion = null;
			_turbineNominelPower = null;
			_turbineOld = null;
			_turbinePlacement = null;
			_turbinePowerRegulation = null;
			_turbineRotorDiameter = null;
			_turbineSmallGenerator = null;
			_turbineTemperatureVariant = null;
			_turbineVoltage = null;

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

			_fieldsCustomProperties.Add("TurbineMatrixId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbinePowerRegulationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineRotorDiameterId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineNominelPowerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineVoltageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineFrequencyId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineSmallGeneratorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineTemperatureVariantId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineMarkVersionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbinePlacementId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineOldId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Comment", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Created", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Deleted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DeletedBy", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _turbine</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbine(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbine, new PropertyChangedEventHandler( OnTurbinePropertyChanged ), "Turbine", TurbineMatrixEntity.Relations.TurbineEntityUsingTurbineId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbineId } );		
			_turbine = null;
		}

		/// <summary> setups the sync logic for member _turbine</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbine(IEntity2 relatedEntity)
		{
			DesetupSyncTurbine(true, true);
			_turbine = (TurbineEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbine, new PropertyChangedEventHandler( OnTurbinePropertyChanged ), "Turbine", TurbineMatrixEntity.Relations.TurbineEntityUsingTurbineId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbinePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _turbineFrequency</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbineFrequency(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbineFrequency, new PropertyChangedEventHandler( OnTurbineFrequencyPropertyChanged ), "TurbineFrequency", TurbineMatrixEntity.Relations.TurbineFrequencyEntityUsingTurbineFrequencyId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbineFrequencyId } );		
			_turbineFrequency = null;
		}

		/// <summary> setups the sync logic for member _turbineFrequency</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbineFrequency(IEntity2 relatedEntity)
		{
			DesetupSyncTurbineFrequency(true, true);
			_turbineFrequency = (TurbineFrequencyEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbineFrequency, new PropertyChangedEventHandler( OnTurbineFrequencyPropertyChanged ), "TurbineFrequency", TurbineMatrixEntity.Relations.TurbineFrequencyEntityUsingTurbineFrequencyId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbineFrequencyPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _turbineManufacturer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbineManufacturer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbineManufacturer, new PropertyChangedEventHandler( OnTurbineManufacturerPropertyChanged ), "TurbineManufacturer", TurbineMatrixEntity.Relations.TurbineManufacturerEntityUsingTurbineManufacturerId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbineManufacturerId } );		
			_turbineManufacturer = null;
		}

		/// <summary> setups the sync logic for member _turbineManufacturer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbineManufacturer(IEntity2 relatedEntity)
		{
			DesetupSyncTurbineManufacturer(true, true);
			_turbineManufacturer = (TurbineManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbineManufacturer, new PropertyChangedEventHandler( OnTurbineManufacturerPropertyChanged ), "TurbineManufacturer", TurbineMatrixEntity.Relations.TurbineManufacturerEntityUsingTurbineManufacturerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbineManufacturerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _turbineMarkVersion</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbineMarkVersion(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbineMarkVersion, new PropertyChangedEventHandler( OnTurbineMarkVersionPropertyChanged ), "TurbineMarkVersion", TurbineMatrixEntity.Relations.TurbineMarkVersionEntityUsingTurbineMarkVersionId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbineMarkVersionId } );		
			_turbineMarkVersion = null;
		}

		/// <summary> setups the sync logic for member _turbineMarkVersion</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbineMarkVersion(IEntity2 relatedEntity)
		{
			DesetupSyncTurbineMarkVersion(true, true);
			_turbineMarkVersion = (TurbineMarkVersionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbineMarkVersion, new PropertyChangedEventHandler( OnTurbineMarkVersionPropertyChanged ), "TurbineMarkVersion", TurbineMatrixEntity.Relations.TurbineMarkVersionEntityUsingTurbineMarkVersionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbineMarkVersionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _turbineNominelPower</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbineNominelPower(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbineNominelPower, new PropertyChangedEventHandler( OnTurbineNominelPowerPropertyChanged ), "TurbineNominelPower", TurbineMatrixEntity.Relations.TurbineNominelPowerEntityUsingTurbineNominelPowerId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbineNominelPowerId } );		
			_turbineNominelPower = null;
		}

		/// <summary> setups the sync logic for member _turbineNominelPower</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbineNominelPower(IEntity2 relatedEntity)
		{
			DesetupSyncTurbineNominelPower(true, true);
			_turbineNominelPower = (TurbineNominelPowerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbineNominelPower, new PropertyChangedEventHandler( OnTurbineNominelPowerPropertyChanged ), "TurbineNominelPower", TurbineMatrixEntity.Relations.TurbineNominelPowerEntityUsingTurbineNominelPowerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbineNominelPowerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _turbineOld</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbineOld(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbineOld, new PropertyChangedEventHandler( OnTurbineOldPropertyChanged ), "TurbineOld", TurbineMatrixEntity.Relations.TurbineOldEntityUsingTurbineOldId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbineOldId } );		
			_turbineOld = null;
		}

		/// <summary> setups the sync logic for member _turbineOld</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbineOld(IEntity2 relatedEntity)
		{
			DesetupSyncTurbineOld(true, true);
			_turbineOld = (TurbineOldEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbineOld, new PropertyChangedEventHandler( OnTurbineOldPropertyChanged ), "TurbineOld", TurbineMatrixEntity.Relations.TurbineOldEntityUsingTurbineOldId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbineOldPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _turbinePlacement</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbinePlacement(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbinePlacement, new PropertyChangedEventHandler( OnTurbinePlacementPropertyChanged ), "TurbinePlacement", TurbineMatrixEntity.Relations.TurbinePlacementEntityUsingTurbinePlacementId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbinePlacementId } );		
			_turbinePlacement = null;
		}

		/// <summary> setups the sync logic for member _turbinePlacement</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbinePlacement(IEntity2 relatedEntity)
		{
			DesetupSyncTurbinePlacement(true, true);
			_turbinePlacement = (TurbinePlacementEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbinePlacement, new PropertyChangedEventHandler( OnTurbinePlacementPropertyChanged ), "TurbinePlacement", TurbineMatrixEntity.Relations.TurbinePlacementEntityUsingTurbinePlacementId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbinePlacementPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _turbinePowerRegulation</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbinePowerRegulation(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbinePowerRegulation, new PropertyChangedEventHandler( OnTurbinePowerRegulationPropertyChanged ), "TurbinePowerRegulation", TurbineMatrixEntity.Relations.TurbinePowerRegulationEntityUsingTurbinePowerRegulationId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbinePowerRegulationId } );		
			_turbinePowerRegulation = null;
		}

		/// <summary> setups the sync logic for member _turbinePowerRegulation</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbinePowerRegulation(IEntity2 relatedEntity)
		{
			DesetupSyncTurbinePowerRegulation(true, true);
			_turbinePowerRegulation = (TurbinePowerRegulationEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbinePowerRegulation, new PropertyChangedEventHandler( OnTurbinePowerRegulationPropertyChanged ), "TurbinePowerRegulation", TurbineMatrixEntity.Relations.TurbinePowerRegulationEntityUsingTurbinePowerRegulationId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbinePowerRegulationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _turbineRotorDiameter</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbineRotorDiameter(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbineRotorDiameter, new PropertyChangedEventHandler( OnTurbineRotorDiameterPropertyChanged ), "TurbineRotorDiameter", TurbineMatrixEntity.Relations.TurbineRotorDiameterEntityUsingTurbineRotorDiameterId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbineRotorDiameterId } );		
			_turbineRotorDiameter = null;
		}

		/// <summary> setups the sync logic for member _turbineRotorDiameter</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbineRotorDiameter(IEntity2 relatedEntity)
		{
			DesetupSyncTurbineRotorDiameter(true, true);
			_turbineRotorDiameter = (TurbineRotorDiameterEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbineRotorDiameter, new PropertyChangedEventHandler( OnTurbineRotorDiameterPropertyChanged ), "TurbineRotorDiameter", TurbineMatrixEntity.Relations.TurbineRotorDiameterEntityUsingTurbineRotorDiameterId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbineRotorDiameterPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _turbineSmallGenerator</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbineSmallGenerator(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbineSmallGenerator, new PropertyChangedEventHandler( OnTurbineSmallGeneratorPropertyChanged ), "TurbineSmallGenerator", TurbineMatrixEntity.Relations.TurbineSmallGeneratorEntityUsingTurbineSmallGeneratorId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbineSmallGeneratorId } );		
			_turbineSmallGenerator = null;
		}

		/// <summary> setups the sync logic for member _turbineSmallGenerator</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbineSmallGenerator(IEntity2 relatedEntity)
		{
			DesetupSyncTurbineSmallGenerator(true, true);
			_turbineSmallGenerator = (TurbineSmallGeneratorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbineSmallGenerator, new PropertyChangedEventHandler( OnTurbineSmallGeneratorPropertyChanged ), "TurbineSmallGenerator", TurbineMatrixEntity.Relations.TurbineSmallGeneratorEntityUsingTurbineSmallGeneratorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbineSmallGeneratorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _turbineTemperatureVariant</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbineTemperatureVariant(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbineTemperatureVariant, new PropertyChangedEventHandler( OnTurbineTemperatureVariantPropertyChanged ), "TurbineTemperatureVariant", TurbineMatrixEntity.Relations.TurbineTemperatureVariantEntityUsingTurbineTemperatureVariantId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbineTemperatureVariantId } );		
			_turbineTemperatureVariant = null;
		}

		/// <summary> setups the sync logic for member _turbineTemperatureVariant</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbineTemperatureVariant(IEntity2 relatedEntity)
		{
			DesetupSyncTurbineTemperatureVariant(true, true);
			_turbineTemperatureVariant = (TurbineTemperatureVariantEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbineTemperatureVariant, new PropertyChangedEventHandler( OnTurbineTemperatureVariantPropertyChanged ), "TurbineTemperatureVariant", TurbineMatrixEntity.Relations.TurbineTemperatureVariantEntityUsingTurbineTemperatureVariantId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbineTemperatureVariantPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _turbineVoltage</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTurbineVoltage(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _turbineVoltage, new PropertyChangedEventHandler( OnTurbineVoltagePropertyChanged ), "TurbineVoltage", TurbineMatrixEntity.Relations.TurbineVoltageEntityUsingTurbineVoltageId, true, signalRelatedEntity, "TurbineMatrix", resetFKFields, new int[] { (int)TurbineMatrixFieldIndex.TurbineVoltageId } );		
			_turbineVoltage = null;
		}

		/// <summary> setups the sync logic for member _turbineVoltage</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTurbineVoltage(IEntity2 relatedEntity)
		{
			DesetupSyncTurbineVoltage(true, true);
			_turbineVoltage = (TurbineVoltageEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _turbineVoltage, new PropertyChangedEventHandler( OnTurbineVoltagePropertyChanged ), "TurbineVoltage", TurbineMatrixEntity.Relations.TurbineVoltageEntityUsingTurbineVoltageId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTurbineVoltagePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this TurbineMatrixEntity</param>
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
		public  static TurbineMatrixRelations Relations
		{
			get	{ return new TurbineMatrixRelations(); }
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
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReport
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),
					TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
				IEntityRelation intermediateRelation = TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingReconstructionBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTypeEntity, 0, null, null, relations, null, "ComponentInspectionReportTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.CountryIsoEntityUsingCountryIsoid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, 0, null, null, relations, null, "CountryIsoCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.LocationTypeEntityUsingLocationTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.LocationTypeEntity, 0, null, null, relations, null, "LocationTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ReportTypeEntityUsingReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.ReportTypeEntity, 0, null, null, relations, null, "ReportTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.SbuEntityUsingSbuid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.SbuEntity, 0, null, null, relations, null, "SbuCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, 0, null, null, relations, null, "ServiceReportNumberTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineRunStatus' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineRunStatusCollectionViaComponentInspectionReport_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingAfterInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, 0, null, null, relations, null, "TurbineRunStatusCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineRunStatus' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineRunStatusCollectionViaComponentInspectionReport
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(TurbineMatrixEntity.Relations.ComponentInspectionReportEntityUsingTurbineMatrixId, "TurbineMatrixEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingBeforeInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, 0, null, null, relations, null, "TurbineRunStatusCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Turbine' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbine
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbineEntityFactory))),
					TurbineMatrixEntity.Relations.TurbineEntityUsingTurbineId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineEntity, 0, null, null, null, null, "Turbine", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineFrequency' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineFrequency
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbineFrequencyEntityFactory))),
					TurbineMatrixEntity.Relations.TurbineFrequencyEntityUsingTurbineFrequencyId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineFrequencyEntity, 0, null, null, null, null, "TurbineFrequency", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineManufacturer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbineManufacturerEntityFactory))),
					TurbineMatrixEntity.Relations.TurbineManufacturerEntityUsingTurbineManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, 0, null, null, null, null, "TurbineManufacturer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineMarkVersion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineMarkVersion
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMarkVersionEntityFactory))),
					TurbineMatrixEntity.Relations.TurbineMarkVersionEntityUsingTurbineMarkVersionId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineMarkVersionEntity, 0, null, null, null, null, "TurbineMarkVersion", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineNominelPower' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineNominelPower
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbineNominelPowerEntityFactory))),
					TurbineMatrixEntity.Relations.TurbineNominelPowerEntityUsingTurbineNominelPowerId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineNominelPowerEntity, 0, null, null, null, null, "TurbineNominelPower", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineOld' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineOld
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbineOldEntityFactory))),
					TurbineMatrixEntity.Relations.TurbineOldEntityUsingTurbineOldId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineOldEntity, 0, null, null, null, null, "TurbineOld", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbinePlacement' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbinePlacement
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbinePlacementEntityFactory))),
					TurbineMatrixEntity.Relations.TurbinePlacementEntityUsingTurbinePlacementId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbinePlacementEntity, 0, null, null, null, null, "TurbinePlacement", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbinePowerRegulation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbinePowerRegulation
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbinePowerRegulationEntityFactory))),
					TurbineMatrixEntity.Relations.TurbinePowerRegulationEntityUsingTurbinePowerRegulationId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbinePowerRegulationEntity, 0, null, null, null, null, "TurbinePowerRegulation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineRotorDiameter' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineRotorDiameter
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRotorDiameterEntityFactory))),
					TurbineMatrixEntity.Relations.TurbineRotorDiameterEntityUsingTurbineRotorDiameterId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineRotorDiameterEntity, 0, null, null, null, null, "TurbineRotorDiameter", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineSmallGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineSmallGenerator
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbineSmallGeneratorEntityFactory))),
					TurbineMatrixEntity.Relations.TurbineSmallGeneratorEntityUsingTurbineSmallGeneratorId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineSmallGeneratorEntity, 0, null, null, null, null, "TurbineSmallGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineTemperatureVariant' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineTemperatureVariant
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbineTemperatureVariantEntityFactory))),
					TurbineMatrixEntity.Relations.TurbineTemperatureVariantEntityUsingTurbineTemperatureVariantId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineTemperatureVariantEntity, 0, null, null, null, null, "TurbineTemperatureVariant", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineVoltage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineVoltage
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TurbineVoltageEntityFactory))),
					TurbineMatrixEntity.Relations.TurbineVoltageEntityUsingTurbineVoltageId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineVoltageEntity, 0, null, null, null, null, "TurbineVoltage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TurbineMatrixEntity.CustomProperties;}
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
			get { return TurbineMatrixEntity.FieldsCustomProperties;}
		}

		/// <summary> The TurbineMatrixId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbineMatrixId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 TurbineMatrixId
		{
			get { return (System.Int64)GetValue((int)TurbineMatrixFieldIndex.TurbineMatrixId, true); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbineMatrixId, value); }
		}

		/// <summary> The TurbineId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbineId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbineId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbineId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbineId, value); }
		}

		/// <summary> The TurbinePowerRegulationId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbinePowerRegulationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbinePowerRegulationId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbinePowerRegulationId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbinePowerRegulationId, value); }
		}

		/// <summary> The TurbineRotorDiameterId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbineRotorDiameterId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbineRotorDiameterId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbineRotorDiameterId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbineRotorDiameterId, value); }
		}

		/// <summary> The TurbineNominelPowerId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbineNominelPowerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbineNominelPowerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbineNominelPowerId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbineNominelPowerId, value); }
		}

		/// <summary> The TurbineVoltageId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbineVoltageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbineVoltageId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbineVoltageId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbineVoltageId, value); }
		}

		/// <summary> The TurbineFrequencyId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbineFrequencyId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbineFrequencyId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbineFrequencyId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbineFrequencyId, value); }
		}

		/// <summary> The TurbineSmallGeneratorId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbineSmallGeneratorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbineSmallGeneratorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbineSmallGeneratorId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbineSmallGeneratorId, value); }
		}

		/// <summary> The TurbineTemperatureVariantId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbineTemperatureVariantId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbineTemperatureVariantId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbineTemperatureVariantId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbineTemperatureVariantId, value); }
		}

		/// <summary> The TurbineMarkVersionId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbineMarkVersionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbineMarkVersionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbineMarkVersionId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbineMarkVersionId, value); }
		}

		/// <summary> The TurbinePlacementId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbinePlacementId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbinePlacementId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbinePlacementId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbinePlacementId, value); }
		}

		/// <summary> The TurbineManufacturerId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbineManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbineManufacturerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbineManufacturerId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbineManufacturerId, value); }
		}

		/// <summary> The TurbineOldId property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."TurbineOldId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> TurbineOldId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TurbineMatrixFieldIndex.TurbineOldId, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.TurbineOldId, value); }
		}

		/// <summary> The Comment property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."Comment"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Comment
		{
			get { return (System.String)GetValue((int)TurbineMatrixFieldIndex.Comment, true); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.Comment, value); }
		}

		/// <summary> The Created property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."Created"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime Created
		{
			get { return (System.DateTime)GetValue((int)TurbineMatrixFieldIndex.Created, true); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.Created, value); }
		}

		/// <summary> The CreatedBy property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CreatedBy
		{
			get { return (System.String)GetValue((int)TurbineMatrixFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.CreatedBy, value); }
		}

		/// <summary> The Deleted property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."Deleted"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> Deleted
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TurbineMatrixFieldIndex.Deleted, false); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.Deleted, value); }
		}

		/// <summary> The DeletedBy property of the Entity TurbineMatrix<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineMatrix"."DeletedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DeletedBy
		{
			get { return (System.String)GetValue((int)TurbineMatrixFieldIndex.DeletedBy, true); }
			set	{ SetValue((int)TurbineMatrixFieldIndex.DeletedBy, value); }
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
					_componentInspectionReport.SetContainingEntityInfo(this, "TurbineMatrix");
				}
				return _componentInspectionReport;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineRunStatusEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineRunStatusEntity))]
		public virtual EntityCollection<TurbineRunStatusEntity> TurbineRunStatusCollectionViaComponentInspectionReport_
		{
			get
			{
				if(_turbineRunStatusCollectionViaComponentInspectionReport_==null)
				{
					_turbineRunStatusCollectionViaComponentInspectionReport_ = new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory)));
					_turbineRunStatusCollectionViaComponentInspectionReport_.IsReadOnly=true;
				}
				return _turbineRunStatusCollectionViaComponentInspectionReport_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineRunStatusEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineRunStatusEntity))]
		public virtual EntityCollection<TurbineRunStatusEntity> TurbineRunStatusCollectionViaComponentInspectionReport
		{
			get
			{
				if(_turbineRunStatusCollectionViaComponentInspectionReport==null)
				{
					_turbineRunStatusCollectionViaComponentInspectionReport = new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory)));
					_turbineRunStatusCollectionViaComponentInspectionReport.IsReadOnly=true;
				}
				return _turbineRunStatusCollectionViaComponentInspectionReport;
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbineEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbineEntity Turbine
		{
			get
			{
				return _turbine;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbine(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbine != null)
						{
							_turbine.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbineFrequencyEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbineFrequencyEntity TurbineFrequency
		{
			get
			{
				return _turbineFrequency;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbineFrequency(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbineFrequency != null)
						{
							_turbineFrequency.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbineManufacturerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbineManufacturerEntity TurbineManufacturer
		{
			get
			{
				return _turbineManufacturer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbineManufacturer(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbineManufacturer != null)
						{
							_turbineManufacturer.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbineMarkVersionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbineMarkVersionEntity TurbineMarkVersion
		{
			get
			{
				return _turbineMarkVersion;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbineMarkVersion(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbineMarkVersion != null)
						{
							_turbineMarkVersion.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbineNominelPowerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbineNominelPowerEntity TurbineNominelPower
		{
			get
			{
				return _turbineNominelPower;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbineNominelPower(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbineNominelPower != null)
						{
							_turbineNominelPower.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbineOldEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbineOldEntity TurbineOld
		{
			get
			{
				return _turbineOld;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbineOld(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbineOld != null)
						{
							_turbineOld.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbinePlacementEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbinePlacementEntity TurbinePlacement
		{
			get
			{
				return _turbinePlacement;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbinePlacement(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbinePlacement != null)
						{
							_turbinePlacement.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbinePowerRegulationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbinePowerRegulationEntity TurbinePowerRegulation
		{
			get
			{
				return _turbinePowerRegulation;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbinePowerRegulation(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbinePowerRegulation != null)
						{
							_turbinePowerRegulation.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbineRotorDiameterEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbineRotorDiameterEntity TurbineRotorDiameter
		{
			get
			{
				return _turbineRotorDiameter;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbineRotorDiameter(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbineRotorDiameter != null)
						{
							_turbineRotorDiameter.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbineSmallGeneratorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbineSmallGeneratorEntity TurbineSmallGenerator
		{
			get
			{
				return _turbineSmallGenerator;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbineSmallGenerator(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbineSmallGenerator != null)
						{
							_turbineSmallGenerator.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbineTemperatureVariantEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbineTemperatureVariantEntity TurbineTemperatureVariant
		{
			get
			{
				return _turbineTemperatureVariant;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbineTemperatureVariant(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbineTemperatureVariant != null)
						{
							_turbineTemperatureVariant.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'TurbineVoltageEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TurbineVoltageEntity TurbineVoltage
		{
			get
			{
				return _turbineVoltage;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTurbineVoltage(value);
				}
				else
				{
					if(value==null)
					{
						if(_turbineVoltage != null)
						{
							_turbineVoltage.UnsetRelatedEntity(this, "TurbineMatrix");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TurbineMatrix");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity; }
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
