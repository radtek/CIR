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
	/// Entity class which represents the entity 'CountryIso'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CountryIsoEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReport;
		private EntityCollection<CountryIsoEntity> _countryIso_;
		private EntityCollection<FirstNotificationEntity> _firstNotification;
		private EntityCollection<SbunotificationEntity> _sbunotification;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport__;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport;
		private EntityCollection<CirDataEntity> _cirDataCollectionViaFirstNotification;
		private EntityCollection<ComponentInspectionReportTypeEntity> _componentInspectionReportTypeCollectionViaComponentInspectionReport;
		private EntityCollection<LocationTypeEntity> _locationTypeCollectionViaComponentInspectionReport;
		private EntityCollection<ReportTypeEntity> _reportTypeCollectionViaComponentInspectionReport;
		private EntityCollection<SbuEntity> _sbuCollectionViaSbunotification;
		private EntityCollection<SbuEntity> _sbuCollectionViaFirstNotification;
		private EntityCollection<SbuEntity> _sbuCollectionViaComponentInspectionReport;
		private EntityCollection<ServiceReportNumberTypeEntity> _serviceReportNumberTypeCollectionViaComponentInspectionReport;
		private EntityCollection<TurbineMatrixEntity> _turbineMatrixCollectionViaComponentInspectionReport;
		private EntityCollection<TurbineRunStatusEntity> _turbineRunStatusCollectionViaComponentInspectionReport;
		private EntityCollection<TurbineRunStatusEntity> _turbineRunStatusCollectionViaComponentInspectionReport_;
		private CountryIsoEntity _countryIso;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name CountryIso</summary>
			public static readonly string CountryIso = "CountryIso";
			/// <summary>Member name ComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReport = "ComponentInspectionReport";
			/// <summary>Member name CountryIso_</summary>
			public static readonly string CountryIso_ = "CountryIso_";
			/// <summary>Member name FirstNotification</summary>
			public static readonly string FirstNotification = "FirstNotification";
			/// <summary>Member name Sbunotification</summary>
			public static readonly string Sbunotification = "Sbunotification";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport__</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport__ = "BooleanAnswerCollectionViaComponentInspectionReport__";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport_</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport_ = "BooleanAnswerCollectionViaComponentInspectionReport_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReport</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReport = "BooleanAnswerCollectionViaComponentInspectionReport";
			/// <summary>Member name CirDataCollectionViaFirstNotification</summary>
			public static readonly string CirDataCollectionViaFirstNotification = "CirDataCollectionViaFirstNotification";
			/// <summary>Member name ComponentInspectionReportTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReportTypeCollectionViaComponentInspectionReport = "ComponentInspectionReportTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name LocationTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string LocationTypeCollectionViaComponentInspectionReport = "LocationTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name ReportTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string ReportTypeCollectionViaComponentInspectionReport = "ReportTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name SbuCollectionViaSbunotification</summary>
			public static readonly string SbuCollectionViaSbunotification = "SbuCollectionViaSbunotification";
			/// <summary>Member name SbuCollectionViaFirstNotification</summary>
			public static readonly string SbuCollectionViaFirstNotification = "SbuCollectionViaFirstNotification";
			/// <summary>Member name SbuCollectionViaComponentInspectionReport</summary>
			public static readonly string SbuCollectionViaComponentInspectionReport = "SbuCollectionViaComponentInspectionReport";
			/// <summary>Member name ServiceReportNumberTypeCollectionViaComponentInspectionReport</summary>
			public static readonly string ServiceReportNumberTypeCollectionViaComponentInspectionReport = "ServiceReportNumberTypeCollectionViaComponentInspectionReport";
			/// <summary>Member name TurbineMatrixCollectionViaComponentInspectionReport</summary>
			public static readonly string TurbineMatrixCollectionViaComponentInspectionReport = "TurbineMatrixCollectionViaComponentInspectionReport";
			/// <summary>Member name TurbineRunStatusCollectionViaComponentInspectionReport</summary>
			public static readonly string TurbineRunStatusCollectionViaComponentInspectionReport = "TurbineRunStatusCollectionViaComponentInspectionReport";
			/// <summary>Member name TurbineRunStatusCollectionViaComponentInspectionReport_</summary>
			public static readonly string TurbineRunStatusCollectionViaComponentInspectionReport_ = "TurbineRunStatusCollectionViaComponentInspectionReport_";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CountryIsoEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CountryIsoEntity():base("CountryIsoEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CountryIsoEntity(IEntityFields2 fields):base("CountryIsoEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CountryIsoEntity</param>
		public CountryIsoEntity(IValidator validator):base("CountryIsoEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="countryIsoid">PK value for CountryIso which data should be fetched into this CountryIso object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CountryIsoEntity(System.Int64 countryIsoid):base("CountryIsoEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CountryIsoid = countryIsoid;
		}

		/// <summary> CTor</summary>
		/// <param name="countryIsoid">PK value for CountryIso which data should be fetched into this CountryIso object</param>
		/// <param name="validator">The custom validator object for this CountryIsoEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CountryIsoEntity(System.Int64 countryIsoid, IValidator validator):base("CountryIsoEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CountryIsoid = countryIsoid;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CountryIsoEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReport = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReport", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_countryIso_ = (EntityCollection<CountryIsoEntity>)info.GetValue("_countryIso_", typeof(EntityCollection<CountryIsoEntity>));
				_firstNotification = (EntityCollection<FirstNotificationEntity>)info.GetValue("_firstNotification", typeof(EntityCollection<FirstNotificationEntity>));
				_sbunotification = (EntityCollection<SbunotificationEntity>)info.GetValue("_sbunotification", typeof(EntityCollection<SbunotificationEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport__ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport__", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport_ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport_", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport", typeof(EntityCollection<BooleanAnswerEntity>));
				_cirDataCollectionViaFirstNotification = (EntityCollection<CirDataEntity>)info.GetValue("_cirDataCollectionViaFirstNotification", typeof(EntityCollection<CirDataEntity>));
				_componentInspectionReportTypeCollectionViaComponentInspectionReport = (EntityCollection<ComponentInspectionReportTypeEntity>)info.GetValue("_componentInspectionReportTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<ComponentInspectionReportTypeEntity>));
				_locationTypeCollectionViaComponentInspectionReport = (EntityCollection<LocationTypeEntity>)info.GetValue("_locationTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<LocationTypeEntity>));
				_reportTypeCollectionViaComponentInspectionReport = (EntityCollection<ReportTypeEntity>)info.GetValue("_reportTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<ReportTypeEntity>));
				_sbuCollectionViaSbunotification = (EntityCollection<SbuEntity>)info.GetValue("_sbuCollectionViaSbunotification", typeof(EntityCollection<SbuEntity>));
				_sbuCollectionViaFirstNotification = (EntityCollection<SbuEntity>)info.GetValue("_sbuCollectionViaFirstNotification", typeof(EntityCollection<SbuEntity>));
				_sbuCollectionViaComponentInspectionReport = (EntityCollection<SbuEntity>)info.GetValue("_sbuCollectionViaComponentInspectionReport", typeof(EntityCollection<SbuEntity>));
				_serviceReportNumberTypeCollectionViaComponentInspectionReport = (EntityCollection<ServiceReportNumberTypeEntity>)info.GetValue("_serviceReportNumberTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<ServiceReportNumberTypeEntity>));
				_turbineMatrixCollectionViaComponentInspectionReport = (EntityCollection<TurbineMatrixEntity>)info.GetValue("_turbineMatrixCollectionViaComponentInspectionReport", typeof(EntityCollection<TurbineMatrixEntity>));
				_turbineRunStatusCollectionViaComponentInspectionReport = (EntityCollection<TurbineRunStatusEntity>)info.GetValue("_turbineRunStatusCollectionViaComponentInspectionReport", typeof(EntityCollection<TurbineRunStatusEntity>));
				_turbineRunStatusCollectionViaComponentInspectionReport_ = (EntityCollection<TurbineRunStatusEntity>)info.GetValue("_turbineRunStatusCollectionViaComponentInspectionReport_", typeof(EntityCollection<TurbineRunStatusEntity>));
				_countryIso = (CountryIsoEntity)info.GetValue("_countryIso", typeof(CountryIsoEntity));
				if(_countryIso!=null)
				{
					_countryIso.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((CountryIsoFieldIndex)fieldIndex)
			{
				case CountryIsoFieldIndex.ParentCountryIsoid:
					DesetupSyncCountryIso(true, false);
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
				case "CountryIso":
					this.CountryIso = (CountryIsoEntity)entity;
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport.Add((ComponentInspectionReportEntity)entity);
					break;
				case "CountryIso_":
					this.CountryIso_.Add((CountryIsoEntity)entity);
					break;
				case "FirstNotification":
					this.FirstNotification.Add((FirstNotificationEntity)entity);
					break;
				case "Sbunotification":
					this.Sbunotification.Add((SbunotificationEntity)entity);
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
				case "CirDataCollectionViaFirstNotification":
					this.CirDataCollectionViaFirstNotification.IsReadOnly = false;
					this.CirDataCollectionViaFirstNotification.Add((CirDataEntity)entity);
					this.CirDataCollectionViaFirstNotification.IsReadOnly = true;
					break;
				case "ComponentInspectionReportTypeCollectionViaComponentInspectionReport":
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport.Add((ComponentInspectionReportTypeEntity)entity);
					this.ComponentInspectionReportTypeCollectionViaComponentInspectionReport.IsReadOnly = true;
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
				case "SbuCollectionViaSbunotification":
					this.SbuCollectionViaSbunotification.IsReadOnly = false;
					this.SbuCollectionViaSbunotification.Add((SbuEntity)entity);
					this.SbuCollectionViaSbunotification.IsReadOnly = true;
					break;
				case "SbuCollectionViaFirstNotification":
					this.SbuCollectionViaFirstNotification.IsReadOnly = false;
					this.SbuCollectionViaFirstNotification.Add((SbuEntity)entity);
					this.SbuCollectionViaFirstNotification.IsReadOnly = true;
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
				case "TurbineMatrixCollectionViaComponentInspectionReport":
					this.TurbineMatrixCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.TurbineMatrixCollectionViaComponentInspectionReport.Add((TurbineMatrixEntity)entity);
					this.TurbineMatrixCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "TurbineRunStatusCollectionViaComponentInspectionReport":
					this.TurbineRunStatusCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.TurbineRunStatusCollectionViaComponentInspectionReport.Add((TurbineRunStatusEntity)entity);
					this.TurbineRunStatusCollectionViaComponentInspectionReport.IsReadOnly = true;
					break;
				case "TurbineRunStatusCollectionViaComponentInspectionReport_":
					this.TurbineRunStatusCollectionViaComponentInspectionReport_.IsReadOnly = false;
					this.TurbineRunStatusCollectionViaComponentInspectionReport_.Add((TurbineRunStatusEntity)entity);
					this.TurbineRunStatusCollectionViaComponentInspectionReport_.IsReadOnly = true;
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
				case "CountryIso":
					SetupSyncCountryIso(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport.Add((ComponentInspectionReportEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "CountryIso_":
					this.CountryIso_.Add((CountryIsoEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "FirstNotification":
					this.FirstNotification.Add((FirstNotificationEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "Sbunotification":
					this.Sbunotification.Add((SbunotificationEntity)relatedEntity);
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
				case "CountryIso":
					DesetupSyncCountryIso(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReport, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "CountryIso_":
					base.PerformRelatedEntityRemoval(this.CountryIso_, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "FirstNotification":
					base.PerformRelatedEntityRemoval(this.FirstNotification, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "Sbunotification":
					base.PerformRelatedEntityRemoval(this.Sbunotification, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_countryIso!=null)
			{
				toReturn.Add(_countryIso);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReport);
			toReturn.Add(this.CountryIso_);
			toReturn.Add(this.FirstNotification);
			toReturn.Add(this.Sbunotification);

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
				info.AddValue("_countryIso_", ((_countryIso_!=null) && (_countryIso_.Count>0) && !this.MarkedForDeletion)?_countryIso_:null);
				info.AddValue("_firstNotification", ((_firstNotification!=null) && (_firstNotification.Count>0) && !this.MarkedForDeletion)?_firstNotification:null);
				info.AddValue("_sbunotification", ((_sbunotification!=null) && (_sbunotification.Count>0) && !this.MarkedForDeletion)?_sbunotification:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport__", ((_booleanAnswerCollectionViaComponentInspectionReport__!=null) && (_booleanAnswerCollectionViaComponentInspectionReport__.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport__:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport_", ((_booleanAnswerCollectionViaComponentInspectionReport_!=null) && (_booleanAnswerCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport", ((_booleanAnswerCollectionViaComponentInspectionReport!=null) && (_booleanAnswerCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport:null);
				info.AddValue("_cirDataCollectionViaFirstNotification", ((_cirDataCollectionViaFirstNotification!=null) && (_cirDataCollectionViaFirstNotification.Count>0) && !this.MarkedForDeletion)?_cirDataCollectionViaFirstNotification:null);
				info.AddValue("_componentInspectionReportTypeCollectionViaComponentInspectionReport", ((_componentInspectionReportTypeCollectionViaComponentInspectionReport!=null) && (_componentInspectionReportTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_locationTypeCollectionViaComponentInspectionReport", ((_locationTypeCollectionViaComponentInspectionReport!=null) && (_locationTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_locationTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_reportTypeCollectionViaComponentInspectionReport", ((_reportTypeCollectionViaComponentInspectionReport!=null) && (_reportTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_reportTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_sbuCollectionViaSbunotification", ((_sbuCollectionViaSbunotification!=null) && (_sbuCollectionViaSbunotification.Count>0) && !this.MarkedForDeletion)?_sbuCollectionViaSbunotification:null);
				info.AddValue("_sbuCollectionViaFirstNotification", ((_sbuCollectionViaFirstNotification!=null) && (_sbuCollectionViaFirstNotification.Count>0) && !this.MarkedForDeletion)?_sbuCollectionViaFirstNotification:null);
				info.AddValue("_sbuCollectionViaComponentInspectionReport", ((_sbuCollectionViaComponentInspectionReport!=null) && (_sbuCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_sbuCollectionViaComponentInspectionReport:null);
				info.AddValue("_serviceReportNumberTypeCollectionViaComponentInspectionReport", ((_serviceReportNumberTypeCollectionViaComponentInspectionReport!=null) && (_serviceReportNumberTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_serviceReportNumberTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_turbineMatrixCollectionViaComponentInspectionReport", ((_turbineMatrixCollectionViaComponentInspectionReport!=null) && (_turbineMatrixCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_turbineMatrixCollectionViaComponentInspectionReport:null);
				info.AddValue("_turbineRunStatusCollectionViaComponentInspectionReport", ((_turbineRunStatusCollectionViaComponentInspectionReport!=null) && (_turbineRunStatusCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_turbineRunStatusCollectionViaComponentInspectionReport:null);
				info.AddValue("_turbineRunStatusCollectionViaComponentInspectionReport_", ((_turbineRunStatusCollectionViaComponentInspectionReport_!=null) && (_turbineRunStatusCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_turbineRunStatusCollectionViaComponentInspectionReport_:null);
				info.AddValue("_countryIso", (!this.MarkedForDeletion?_countryIso:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CountryIsoFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CountryIsoFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CountryIsoRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CountryIso' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryIso_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.ParentCountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FirstNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFirstNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FirstNotificationFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Sbunotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSbunotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SbunotificationFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingReconstructionBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CirData' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCirDataCollectionViaFirstNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.FirstNotificationEntityUsingCountryIsoid, "CountryIsoEntity__", "FirstNotification_", JoinHint.None);
			bucket.Relations.Add(FirstNotificationEntity.Relations.CirDataEntityUsingCirDataId, "FirstNotification_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'LocationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLocationTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.LocationTypeEntityUsingLocationTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReportTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ReportTypeEntityUsingReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Sbu' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSbuCollectionViaSbunotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.SbunotificationEntityUsingCountryIsoid, "CountryIsoEntity__", "Sbunotification_", JoinHint.None);
			bucket.Relations.Add(SbunotificationEntity.Relations.SbuEntityUsingSbuid, "Sbunotification_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Sbu' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSbuCollectionViaFirstNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.FirstNotificationEntityUsingCountryIsoid, "CountryIsoEntity__", "FirstNotification_", JoinHint.None);
			bucket.Relations.Add(FirstNotificationEntity.Relations.SbuEntityUsingSbuid, "FirstNotification_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Sbu' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSbuCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.SbuEntityUsingSbuid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ServiceReportNumberType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoServiceReportNumberTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineMatrix' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineMatrixCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.TurbineMatrixEntityUsingTurbineMatrixId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineRunStatus' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineRunStatusCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingBeforeInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineRunStatus' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineRunStatusCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingAfterInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid, "CountryIsoEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CountryIso' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryIso()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.ParentCountryIsoid));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.CountryIsoEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReport);
			collectionsQueue.Enqueue(this._countryIso_);
			collectionsQueue.Enqueue(this._firstNotification);
			collectionsQueue.Enqueue(this._sbunotification);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport__);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._cirDataCollectionViaFirstNotification);
			collectionsQueue.Enqueue(this._componentInspectionReportTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._locationTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._reportTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._sbuCollectionViaSbunotification);
			collectionsQueue.Enqueue(this._sbuCollectionViaFirstNotification);
			collectionsQueue.Enqueue(this._sbuCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._serviceReportNumberTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._turbineMatrixCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._turbineRunStatusCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._turbineRunStatusCollectionViaComponentInspectionReport_);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReport = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._countryIso_ = (EntityCollection<CountryIsoEntity>) collectionsQueue.Dequeue();
			this._firstNotification = (EntityCollection<FirstNotificationEntity>) collectionsQueue.Dequeue();
			this._sbunotification = (EntityCollection<SbunotificationEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport__ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport_ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._cirDataCollectionViaFirstNotification = (EntityCollection<CirDataEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportTypeCollectionViaComponentInspectionReport = (EntityCollection<ComponentInspectionReportTypeEntity>) collectionsQueue.Dequeue();
			this._locationTypeCollectionViaComponentInspectionReport = (EntityCollection<LocationTypeEntity>) collectionsQueue.Dequeue();
			this._reportTypeCollectionViaComponentInspectionReport = (EntityCollection<ReportTypeEntity>) collectionsQueue.Dequeue();
			this._sbuCollectionViaSbunotification = (EntityCollection<SbuEntity>) collectionsQueue.Dequeue();
			this._sbuCollectionViaFirstNotification = (EntityCollection<SbuEntity>) collectionsQueue.Dequeue();
			this._sbuCollectionViaComponentInspectionReport = (EntityCollection<SbuEntity>) collectionsQueue.Dequeue();
			this._serviceReportNumberTypeCollectionViaComponentInspectionReport = (EntityCollection<ServiceReportNumberTypeEntity>) collectionsQueue.Dequeue();
			this._turbineMatrixCollectionViaComponentInspectionReport = (EntityCollection<TurbineMatrixEntity>) collectionsQueue.Dequeue();
			this._turbineRunStatusCollectionViaComponentInspectionReport = (EntityCollection<TurbineRunStatusEntity>) collectionsQueue.Dequeue();
			this._turbineRunStatusCollectionViaComponentInspectionReport_ = (EntityCollection<TurbineRunStatusEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReport != null)
			{
				return true;
			}
			if (this._countryIso_ != null)
			{
				return true;
			}
			if (this._firstNotification != null)
			{
				return true;
			}
			if (this._sbunotification != null)
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
			if (this._cirDataCollectionViaFirstNotification != null)
			{
				return true;
			}
			if (this._componentInspectionReportTypeCollectionViaComponentInspectionReport != null)
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
			if (this._sbuCollectionViaSbunotification != null)
			{
				return true;
			}
			if (this._sbuCollectionViaFirstNotification != null)
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
			if (this._turbineMatrixCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._turbineRunStatusCollectionViaComponentInspectionReport != null)
			{
				return true;
			}
			if (this._turbineRunStatusCollectionViaComponentInspectionReport_ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FirstNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FirstNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SbunotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbunotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CirDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirDataEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory))) : null);
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
			toReturn.Add("CountryIso", _countryIso);
			toReturn.Add("ComponentInspectionReport", _componentInspectionReport);
			toReturn.Add("CountryIso_", _countryIso_);
			toReturn.Add("FirstNotification", _firstNotification);
			toReturn.Add("Sbunotification", _sbunotification);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport__", _booleanAnswerCollectionViaComponentInspectionReport__);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport_", _booleanAnswerCollectionViaComponentInspectionReport_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport", _booleanAnswerCollectionViaComponentInspectionReport);
			toReturn.Add("CirDataCollectionViaFirstNotification", _cirDataCollectionViaFirstNotification);
			toReturn.Add("ComponentInspectionReportTypeCollectionViaComponentInspectionReport", _componentInspectionReportTypeCollectionViaComponentInspectionReport);
			toReturn.Add("LocationTypeCollectionViaComponentInspectionReport", _locationTypeCollectionViaComponentInspectionReport);
			toReturn.Add("ReportTypeCollectionViaComponentInspectionReport", _reportTypeCollectionViaComponentInspectionReport);
			toReturn.Add("SbuCollectionViaSbunotification", _sbuCollectionViaSbunotification);
			toReturn.Add("SbuCollectionViaFirstNotification", _sbuCollectionViaFirstNotification);
			toReturn.Add("SbuCollectionViaComponentInspectionReport", _sbuCollectionViaComponentInspectionReport);
			toReturn.Add("ServiceReportNumberTypeCollectionViaComponentInspectionReport", _serviceReportNumberTypeCollectionViaComponentInspectionReport);
			toReturn.Add("TurbineMatrixCollectionViaComponentInspectionReport", _turbineMatrixCollectionViaComponentInspectionReport);
			toReturn.Add("TurbineRunStatusCollectionViaComponentInspectionReport", _turbineRunStatusCollectionViaComponentInspectionReport);
			toReturn.Add("TurbineRunStatusCollectionViaComponentInspectionReport_", _turbineRunStatusCollectionViaComponentInspectionReport_);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReport!=null)
			{
				_componentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_countryIso_!=null)
			{
				_countryIso_.ActiveContext = base.ActiveContext;
			}
			if(_firstNotification!=null)
			{
				_firstNotification.ActiveContext = base.ActiveContext;
			}
			if(_sbunotification!=null)
			{
				_sbunotification.ActiveContext = base.ActiveContext;
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
			if(_cirDataCollectionViaFirstNotification!=null)
			{
				_cirDataCollectionViaFirstNotification.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportTypeCollectionViaComponentInspectionReport!=null)
			{
				_componentInspectionReportTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_locationTypeCollectionViaComponentInspectionReport!=null)
			{
				_locationTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_reportTypeCollectionViaComponentInspectionReport!=null)
			{
				_reportTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_sbuCollectionViaSbunotification!=null)
			{
				_sbuCollectionViaSbunotification.ActiveContext = base.ActiveContext;
			}
			if(_sbuCollectionViaFirstNotification!=null)
			{
				_sbuCollectionViaFirstNotification.ActiveContext = base.ActiveContext;
			}
			if(_sbuCollectionViaComponentInspectionReport!=null)
			{
				_sbuCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_serviceReportNumberTypeCollectionViaComponentInspectionReport!=null)
			{
				_serviceReportNumberTypeCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_turbineMatrixCollectionViaComponentInspectionReport!=null)
			{
				_turbineMatrixCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_turbineRunStatusCollectionViaComponentInspectionReport!=null)
			{
				_turbineRunStatusCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_turbineRunStatusCollectionViaComponentInspectionReport_!=null)
			{
				_turbineRunStatusCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_countryIso!=null)
			{
				_countryIso.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReport = null;
			_countryIso_ = null;
			_firstNotification = null;
			_sbunotification = null;
			_booleanAnswerCollectionViaComponentInspectionReport__ = null;
			_booleanAnswerCollectionViaComponentInspectionReport_ = null;
			_booleanAnswerCollectionViaComponentInspectionReport = null;
			_cirDataCollectionViaFirstNotification = null;
			_componentInspectionReportTypeCollectionViaComponentInspectionReport = null;
			_locationTypeCollectionViaComponentInspectionReport = null;
			_reportTypeCollectionViaComponentInspectionReport = null;
			_sbuCollectionViaSbunotification = null;
			_sbuCollectionViaFirstNotification = null;
			_sbuCollectionViaComponentInspectionReport = null;
			_serviceReportNumberTypeCollectionViaComponentInspectionReport = null;
			_turbineMatrixCollectionViaComponentInspectionReport = null;
			_turbineRunStatusCollectionViaComponentInspectionReport = null;
			_turbineRunStatusCollectionViaComponentInspectionReport_ = null;
			_countryIso = null;

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

			_fieldsCustomProperties.Add("CountryIsoid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ShortName", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentCountryIsoid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sbuid", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _countryIso</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCountryIso(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _countryIso, new PropertyChangedEventHandler( OnCountryIsoPropertyChanged ), "CountryIso", CountryIsoEntity.Relations.CountryIsoEntityUsingCountryIsoidParentCountryIsoid, true, signalRelatedEntity, "CountryIso_", resetFKFields, new int[] { (int)CountryIsoFieldIndex.ParentCountryIsoid } );		
			_countryIso = null;
		}

		/// <summary> setups the sync logic for member _countryIso</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCountryIso(IEntity2 relatedEntity)
		{
			DesetupSyncCountryIso(true, true);
			_countryIso = (CountryIsoEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _countryIso, new PropertyChangedEventHandler( OnCountryIsoPropertyChanged ), "CountryIso", CountryIsoEntity.Relations.CountryIsoEntityUsingCountryIsoidParentCountryIsoid, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCountryIsoPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CountryIsoEntity</param>
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
		public  static CountryIsoRelations Relations
		{
			get	{ return new CountryIsoRelations(); }
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
					CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, 
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CountryIso' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountryIso_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))),
					CountryIsoEntity.Relations.CountryIsoEntityUsingParentCountryIsoid, 
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, 0, null, null, null, null, "CountryIso_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FirstNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFirstNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<FirstNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FirstNotificationEntityFactory))),
					CountryIsoEntity.Relations.FirstNotificationEntityUsingCountryIsoid, 
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.FirstNotificationEntity, 0, null, null, null, null, "FirstNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Sbunotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSbunotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SbunotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbunotificationEntityFactory))),
					CountryIsoEntity.Relations.SbunotificationEntityUsingCountryIsoid, 
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.SbunotificationEntity, 0, null, null, null, null, "Sbunotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingReconstructionBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CirData' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCirDataCollectionViaFirstNotification
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.FirstNotificationEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "FirstNotification_");
				relations.Add(CountryIsoEntity.Relations.FirstNotificationEntityUsingCountryIsoid, "CountryIsoEntity__", "FirstNotification_", JoinHint.None);
				relations.Add(FirstNotificationEntity.Relations.CirDataEntityUsingCirDataId, "FirstNotification_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CirDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirDataEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.CirDataEntity, 0, null, null, relations, null, "CirDataCollectionViaFirstNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTypeEntity, 0, null, null, relations, null, "ComponentInspectionReportTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.LocationTypeEntityUsingLocationTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.LocationTypeEntity, 0, null, null, relations, null, "LocationTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ReportTypeEntityUsingReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.ReportTypeEntity, 0, null, null, relations, null, "ReportTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Sbu' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSbuCollectionViaSbunotification
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.SbunotificationEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "Sbunotification_");
				relations.Add(CountryIsoEntity.Relations.SbunotificationEntityUsingCountryIsoid, "CountryIsoEntity__", "Sbunotification_", JoinHint.None);
				relations.Add(SbunotificationEntity.Relations.SbuEntityUsingSbuid, "Sbunotification_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.SbuEntity, 0, null, null, relations, null, "SbuCollectionViaSbunotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Sbu' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSbuCollectionViaFirstNotification
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.FirstNotificationEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "FirstNotification_");
				relations.Add(CountryIsoEntity.Relations.FirstNotificationEntityUsingCountryIsoid, "CountryIsoEntity__", "FirstNotification_", JoinHint.None);
				relations.Add(FirstNotificationEntity.Relations.SbuEntityUsingSbuid, "FirstNotification_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.SbuEntity, 0, null, null, relations, null, "SbuCollectionViaFirstNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.SbuEntityUsingSbuid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.SbuEntity, 0, null, null, relations, null, "SbuCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, 0, null, null, relations, null, "ServiceReportNumberTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.TurbineMatrixEntityUsingTurbineMatrixId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, 0, null, null, relations, null, "TurbineMatrixCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingBeforeInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, 0, null, null, relations, null, "TurbineRunStatusCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(CountryIsoEntity.Relations.ComponentInspectionReportEntityUsingCountryIsoid, "CountryIsoEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingAfterInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, 0, null, null, relations, null, "TurbineRunStatusCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CountryIso' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountryIso
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))),
					CountryIsoEntity.Relations.CountryIsoEntityUsingCountryIsoidParentCountryIsoid, 
					(int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, (int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, 0, null, null, null, null, "CountryIso", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CountryIsoEntity.CustomProperties;}
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
			get { return CountryIsoEntity.FieldsCustomProperties;}
		}

		/// <summary> The CountryIsoid property of the Entity CountryIso<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CountryISO"."CountryISOId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CountryIsoid
		{
			get { return (System.Int64)GetValue((int)CountryIsoFieldIndex.CountryIsoid, true); }
			set	{ SetValue((int)CountryIsoFieldIndex.CountryIsoid, value); }
		}

		/// <summary> The Name property of the Entity CountryIso<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CountryISO"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)CountryIsoFieldIndex.Name, true); }
			set	{ SetValue((int)CountryIsoFieldIndex.Name, value); }
		}

		/// <summary> The ShortName property of the Entity CountryIso<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CountryISO"."ShortName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ShortName
		{
			get { return (System.String)GetValue((int)CountryIsoFieldIndex.ShortName, true); }
			set	{ SetValue((int)CountryIsoFieldIndex.ShortName, value); }
		}

		/// <summary> The LanguageId property of the Entity CountryIso<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CountryISO"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)CountryIsoFieldIndex.LanguageId, true); }
			set	{ SetValue((int)CountryIsoFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentCountryIsoid property of the Entity CountryIso<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CountryISO"."ParentCountryISOId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentCountryIsoid
		{
			get { return (Nullable<System.Int64>)GetValue((int)CountryIsoFieldIndex.ParentCountryIsoid, false); }
			set	{ SetValue((int)CountryIsoFieldIndex.ParentCountryIsoid, value); }
		}

		/// <summary> The Sort property of the Entity CountryIso<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CountryISO"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)CountryIsoFieldIndex.Sort, true); }
			set	{ SetValue((int)CountryIsoFieldIndex.Sort, value); }
		}

		/// <summary> The Sbuid property of the Entity CountryIso<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CountryISO"."SBUId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> Sbuid
		{
			get { return (Nullable<System.Int64>)GetValue((int)CountryIsoFieldIndex.Sbuid, false); }
			set	{ SetValue((int)CountryIsoFieldIndex.Sbuid, value); }
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
					_componentInspectionReport.SetContainingEntityInfo(this, "CountryIso");
				}
				return _componentInspectionReport;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CountryIsoEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CountryIsoEntity))]
		public virtual EntityCollection<CountryIsoEntity> CountryIso_
		{
			get
			{
				if(_countryIso_==null)
				{
					_countryIso_ = new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory)));
					_countryIso_.SetContainingEntityInfo(this, "CountryIso");
				}
				return _countryIso_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FirstNotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FirstNotificationEntity))]
		public virtual EntityCollection<FirstNotificationEntity> FirstNotification
		{
			get
			{
				if(_firstNotification==null)
				{
					_firstNotification = new EntityCollection<FirstNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FirstNotificationEntityFactory)));
					_firstNotification.SetContainingEntityInfo(this, "CountryIso");
				}
				return _firstNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SbunotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SbunotificationEntity))]
		public virtual EntityCollection<SbunotificationEntity> Sbunotification
		{
			get
			{
				if(_sbunotification==null)
				{
					_sbunotification = new EntityCollection<SbunotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbunotificationEntityFactory)));
					_sbunotification.SetContainingEntityInfo(this, "CountryIso");
				}
				return _sbunotification;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'CirDataEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CirDataEntity))]
		public virtual EntityCollection<CirDataEntity> CirDataCollectionViaFirstNotification
		{
			get
			{
				if(_cirDataCollectionViaFirstNotification==null)
				{
					_cirDataCollectionViaFirstNotification = new EntityCollection<CirDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirDataEntityFactory)));
					_cirDataCollectionViaFirstNotification.IsReadOnly=true;
				}
				return _cirDataCollectionViaFirstNotification;
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
		public virtual EntityCollection<SbuEntity> SbuCollectionViaSbunotification
		{
			get
			{
				if(_sbuCollectionViaSbunotification==null)
				{
					_sbuCollectionViaSbunotification = new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory)));
					_sbuCollectionViaSbunotification.IsReadOnly=true;
				}
				return _sbuCollectionViaSbunotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SbuEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SbuEntity))]
		public virtual EntityCollection<SbuEntity> SbuCollectionViaFirstNotification
		{
			get
			{
				if(_sbuCollectionViaFirstNotification==null)
				{
					_sbuCollectionViaFirstNotification = new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory)));
					_sbuCollectionViaFirstNotification.IsReadOnly=true;
				}
				return _sbuCollectionViaFirstNotification;
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

		/// <summary> Gets / sets related entity of type 'CountryIsoEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CountryIsoEntity CountryIso
		{
			get
			{
				return _countryIso;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCountryIso(value);
				}
				else
				{
					if(value==null)
					{
						if(_countryIso != null)
						{
							_countryIso.UnsetRelatedEntity(this, "CountryIso_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "CountryIso_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity; }
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
