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
	/// Entity class which represents the entity 'ServiceReportNumberType'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ServiceReportNumberTypeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReport;
		private EntityCollection<ServiceReportNumberTypeEntity> _serviceReportNumberType_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport__;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReport;
		private EntityCollection<ComponentInspectionReportTypeEntity> _componentInspectionReportTypeCollectionViaComponentInspectionReport;
		private EntityCollection<CountryIsoEntity> _countryIsoCollectionViaComponentInspectionReport;
		private EntityCollection<LocationTypeEntity> _locationTypeCollectionViaComponentInspectionReport;
		private EntityCollection<ReportTypeEntity> _reportTypeCollectionViaComponentInspectionReport;
		private EntityCollection<SbuEntity> _sbuCollectionViaComponentInspectionReport;
		private EntityCollection<TurbineMatrixEntity> _turbineMatrixCollectionViaComponentInspectionReport;
		private EntityCollection<TurbineRunStatusEntity> _turbineRunStatusCollectionViaComponentInspectionReport_;
		private EntityCollection<TurbineRunStatusEntity> _turbineRunStatusCollectionViaComponentInspectionReport;
		private ServiceReportNumberTypeEntity _serviceReportNumberType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name ServiceReportNumberType</summary>
			public static readonly string ServiceReportNumberType = "ServiceReportNumberType";
			/// <summary>Member name ComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReport = "ComponentInspectionReport";
			/// <summary>Member name ServiceReportNumberType_</summary>
			public static readonly string ServiceReportNumberType_ = "ServiceReportNumberType_";
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
			/// <summary>Member name TurbineMatrixCollectionViaComponentInspectionReport</summary>
			public static readonly string TurbineMatrixCollectionViaComponentInspectionReport = "TurbineMatrixCollectionViaComponentInspectionReport";
			/// <summary>Member name TurbineRunStatusCollectionViaComponentInspectionReport_</summary>
			public static readonly string TurbineRunStatusCollectionViaComponentInspectionReport_ = "TurbineRunStatusCollectionViaComponentInspectionReport_";
			/// <summary>Member name TurbineRunStatusCollectionViaComponentInspectionReport</summary>
			public static readonly string TurbineRunStatusCollectionViaComponentInspectionReport = "TurbineRunStatusCollectionViaComponentInspectionReport";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ServiceReportNumberTypeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ServiceReportNumberTypeEntity():base("ServiceReportNumberTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ServiceReportNumberTypeEntity(IEntityFields2 fields):base("ServiceReportNumberTypeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ServiceReportNumberTypeEntity</param>
		public ServiceReportNumberTypeEntity(IValidator validator):base("ServiceReportNumberTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="serviceReportNumberTypeId">PK value for ServiceReportNumberType which data should be fetched into this ServiceReportNumberType object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ServiceReportNumberTypeEntity(System.Int64 serviceReportNumberTypeId):base("ServiceReportNumberTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ServiceReportNumberTypeId = serviceReportNumberTypeId;
		}

		/// <summary> CTor</summary>
		/// <param name="serviceReportNumberTypeId">PK value for ServiceReportNumberType which data should be fetched into this ServiceReportNumberType object</param>
		/// <param name="validator">The custom validator object for this ServiceReportNumberTypeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ServiceReportNumberTypeEntity(System.Int64 serviceReportNumberTypeId, IValidator validator):base("ServiceReportNumberTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ServiceReportNumberTypeId = serviceReportNumberTypeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ServiceReportNumberTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReport = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReport", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_serviceReportNumberType_ = (EntityCollection<ServiceReportNumberTypeEntity>)info.GetValue("_serviceReportNumberType_", typeof(EntityCollection<ServiceReportNumberTypeEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport__ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport__", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport_ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport_", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReport = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReport", typeof(EntityCollection<BooleanAnswerEntity>));
				_componentInspectionReportTypeCollectionViaComponentInspectionReport = (EntityCollection<ComponentInspectionReportTypeEntity>)info.GetValue("_componentInspectionReportTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<ComponentInspectionReportTypeEntity>));
				_countryIsoCollectionViaComponentInspectionReport = (EntityCollection<CountryIsoEntity>)info.GetValue("_countryIsoCollectionViaComponentInspectionReport", typeof(EntityCollection<CountryIsoEntity>));
				_locationTypeCollectionViaComponentInspectionReport = (EntityCollection<LocationTypeEntity>)info.GetValue("_locationTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<LocationTypeEntity>));
				_reportTypeCollectionViaComponentInspectionReport = (EntityCollection<ReportTypeEntity>)info.GetValue("_reportTypeCollectionViaComponentInspectionReport", typeof(EntityCollection<ReportTypeEntity>));
				_sbuCollectionViaComponentInspectionReport = (EntityCollection<SbuEntity>)info.GetValue("_sbuCollectionViaComponentInspectionReport", typeof(EntityCollection<SbuEntity>));
				_turbineMatrixCollectionViaComponentInspectionReport = (EntityCollection<TurbineMatrixEntity>)info.GetValue("_turbineMatrixCollectionViaComponentInspectionReport", typeof(EntityCollection<TurbineMatrixEntity>));
				_turbineRunStatusCollectionViaComponentInspectionReport_ = (EntityCollection<TurbineRunStatusEntity>)info.GetValue("_turbineRunStatusCollectionViaComponentInspectionReport_", typeof(EntityCollection<TurbineRunStatusEntity>));
				_turbineRunStatusCollectionViaComponentInspectionReport = (EntityCollection<TurbineRunStatusEntity>)info.GetValue("_turbineRunStatusCollectionViaComponentInspectionReport", typeof(EntityCollection<TurbineRunStatusEntity>));
				_serviceReportNumberType = (ServiceReportNumberTypeEntity)info.GetValue("_serviceReportNumberType", typeof(ServiceReportNumberTypeEntity));
				if(_serviceReportNumberType!=null)
				{
					_serviceReportNumberType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ServiceReportNumberTypeFieldIndex)fieldIndex)
			{
				case ServiceReportNumberTypeFieldIndex.ParentServiceReportNumberTypeId:
					DesetupSyncServiceReportNumberType(true, false);
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
				case "ServiceReportNumberType":
					this.ServiceReportNumberType = (ServiceReportNumberTypeEntity)entity;
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport.Add((ComponentInspectionReportEntity)entity);
					break;
				case "ServiceReportNumberType_":
					this.ServiceReportNumberType_.Add((ServiceReportNumberTypeEntity)entity);
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
				case "TurbineMatrixCollectionViaComponentInspectionReport":
					this.TurbineMatrixCollectionViaComponentInspectionReport.IsReadOnly = false;
					this.TurbineMatrixCollectionViaComponentInspectionReport.Add((TurbineMatrixEntity)entity);
					this.TurbineMatrixCollectionViaComponentInspectionReport.IsReadOnly = true;
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
				case "ServiceReportNumberType":
					SetupSyncServiceReportNumberType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport.Add((ComponentInspectionReportEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ServiceReportNumberType_":
					this.ServiceReportNumberType_.Add((ServiceReportNumberTypeEntity)relatedEntity);
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
				case "ServiceReportNumberType":
					DesetupSyncServiceReportNumberType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReport, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ServiceReportNumberType_":
					base.PerformRelatedEntityRemoval(this.ServiceReportNumberType_, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_serviceReportNumberType!=null)
			{
				toReturn.Add(_serviceReportNumberType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReport);
			toReturn.Add(this.ServiceReportNumberType_);

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
				info.AddValue("_serviceReportNumberType_", ((_serviceReportNumberType_!=null) && (_serviceReportNumberType_.Count>0) && !this.MarkedForDeletion)?_serviceReportNumberType_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport__", ((_booleanAnswerCollectionViaComponentInspectionReport__!=null) && (_booleanAnswerCollectionViaComponentInspectionReport__.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport__:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport_", ((_booleanAnswerCollectionViaComponentInspectionReport_!=null) && (_booleanAnswerCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReport", ((_booleanAnswerCollectionViaComponentInspectionReport!=null) && (_booleanAnswerCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReport:null);
				info.AddValue("_componentInspectionReportTypeCollectionViaComponentInspectionReport", ((_componentInspectionReportTypeCollectionViaComponentInspectionReport!=null) && (_componentInspectionReportTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_countryIsoCollectionViaComponentInspectionReport", ((_countryIsoCollectionViaComponentInspectionReport!=null) && (_countryIsoCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_countryIsoCollectionViaComponentInspectionReport:null);
				info.AddValue("_locationTypeCollectionViaComponentInspectionReport", ((_locationTypeCollectionViaComponentInspectionReport!=null) && (_locationTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_locationTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_reportTypeCollectionViaComponentInspectionReport", ((_reportTypeCollectionViaComponentInspectionReport!=null) && (_reportTypeCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_reportTypeCollectionViaComponentInspectionReport:null);
				info.AddValue("_sbuCollectionViaComponentInspectionReport", ((_sbuCollectionViaComponentInspectionReport!=null) && (_sbuCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_sbuCollectionViaComponentInspectionReport:null);
				info.AddValue("_turbineMatrixCollectionViaComponentInspectionReport", ((_turbineMatrixCollectionViaComponentInspectionReport!=null) && (_turbineMatrixCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_turbineMatrixCollectionViaComponentInspectionReport:null);
				info.AddValue("_turbineRunStatusCollectionViaComponentInspectionReport_", ((_turbineRunStatusCollectionViaComponentInspectionReport_!=null) && (_turbineRunStatusCollectionViaComponentInspectionReport_.Count>0) && !this.MarkedForDeletion)?_turbineRunStatusCollectionViaComponentInspectionReport_:null);
				info.AddValue("_turbineRunStatusCollectionViaComponentInspectionReport", ((_turbineRunStatusCollectionViaComponentInspectionReport!=null) && (_turbineRunStatusCollectionViaComponentInspectionReport.Count>0) && !this.MarkedForDeletion)?_turbineRunStatusCollectionViaComponentInspectionReport:null);
				info.AddValue("_serviceReportNumberType", (!this.MarkedForDeletion?_serviceReportNumberType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ServiceReportNumberTypeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ServiceReportNumberTypeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ServiceReportNumberTypeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ServiceReportNumberType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoServiceReportNumberType_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ParentServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingReconstructionBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CountryIso' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryIsoCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.CountryIsoEntityUsingCountryIsoid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'LocationType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoLocationTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.LocationTypeEntityUsingLocationTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ReportType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoReportTypeCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.ReportTypeEntityUsingReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Sbu' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSbuCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.SbuEntityUsingSbuid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineMatrix' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineMatrixCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.TurbineMatrixEntityUsingTurbineMatrixId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineRunStatus' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineRunStatusCollectionViaComponentInspectionReport_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingAfterInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineRunStatus' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineRunStatusCollectionViaComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingBeforeInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ServiceReportNumberType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoServiceReportNumberType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, null, ComparisonOperator.Equal, this.ParentServiceReportNumberTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReport);
			collectionsQueue.Enqueue(this._serviceReportNumberType_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport__);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._componentInspectionReportTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._countryIsoCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._locationTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._reportTypeCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._sbuCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._turbineMatrixCollectionViaComponentInspectionReport);
			collectionsQueue.Enqueue(this._turbineRunStatusCollectionViaComponentInspectionReport_);
			collectionsQueue.Enqueue(this._turbineRunStatusCollectionViaComponentInspectionReport);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReport = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._serviceReportNumberType_ = (EntityCollection<ServiceReportNumberTypeEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport__ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport_ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReport = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportTypeCollectionViaComponentInspectionReport = (EntityCollection<ComponentInspectionReportTypeEntity>) collectionsQueue.Dequeue();
			this._countryIsoCollectionViaComponentInspectionReport = (EntityCollection<CountryIsoEntity>) collectionsQueue.Dequeue();
			this._locationTypeCollectionViaComponentInspectionReport = (EntityCollection<LocationTypeEntity>) collectionsQueue.Dequeue();
			this._reportTypeCollectionViaComponentInspectionReport = (EntityCollection<ReportTypeEntity>) collectionsQueue.Dequeue();
			this._sbuCollectionViaComponentInspectionReport = (EntityCollection<SbuEntity>) collectionsQueue.Dequeue();
			this._turbineMatrixCollectionViaComponentInspectionReport = (EntityCollection<TurbineMatrixEntity>) collectionsQueue.Dequeue();
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
			if (this._serviceReportNumberType_ != null)
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
			if (this._turbineMatrixCollectionViaComponentInspectionReport != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))) : null);
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
			toReturn.Add("ServiceReportNumberType", _serviceReportNumberType);
			toReturn.Add("ComponentInspectionReport", _componentInspectionReport);
			toReturn.Add("ServiceReportNumberType_", _serviceReportNumberType_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport__", _booleanAnswerCollectionViaComponentInspectionReport__);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport_", _booleanAnswerCollectionViaComponentInspectionReport_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReport", _booleanAnswerCollectionViaComponentInspectionReport);
			toReturn.Add("ComponentInspectionReportTypeCollectionViaComponentInspectionReport", _componentInspectionReportTypeCollectionViaComponentInspectionReport);
			toReturn.Add("CountryIsoCollectionViaComponentInspectionReport", _countryIsoCollectionViaComponentInspectionReport);
			toReturn.Add("LocationTypeCollectionViaComponentInspectionReport", _locationTypeCollectionViaComponentInspectionReport);
			toReturn.Add("ReportTypeCollectionViaComponentInspectionReport", _reportTypeCollectionViaComponentInspectionReport);
			toReturn.Add("SbuCollectionViaComponentInspectionReport", _sbuCollectionViaComponentInspectionReport);
			toReturn.Add("TurbineMatrixCollectionViaComponentInspectionReport", _turbineMatrixCollectionViaComponentInspectionReport);
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
			if(_serviceReportNumberType_!=null)
			{
				_serviceReportNumberType_.ActiveContext = base.ActiveContext;
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
			if(_turbineMatrixCollectionViaComponentInspectionReport!=null)
			{
				_turbineMatrixCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_turbineRunStatusCollectionViaComponentInspectionReport_!=null)
			{
				_turbineRunStatusCollectionViaComponentInspectionReport_.ActiveContext = base.ActiveContext;
			}
			if(_turbineRunStatusCollectionViaComponentInspectionReport!=null)
			{
				_turbineRunStatusCollectionViaComponentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_serviceReportNumberType!=null)
			{
				_serviceReportNumberType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReport = null;
			_serviceReportNumberType_ = null;
			_booleanAnswerCollectionViaComponentInspectionReport__ = null;
			_booleanAnswerCollectionViaComponentInspectionReport_ = null;
			_booleanAnswerCollectionViaComponentInspectionReport = null;
			_componentInspectionReportTypeCollectionViaComponentInspectionReport = null;
			_countryIsoCollectionViaComponentInspectionReport = null;
			_locationTypeCollectionViaComponentInspectionReport = null;
			_reportTypeCollectionViaComponentInspectionReport = null;
			_sbuCollectionViaComponentInspectionReport = null;
			_turbineMatrixCollectionViaComponentInspectionReport = null;
			_turbineRunStatusCollectionViaComponentInspectionReport_ = null;
			_turbineRunStatusCollectionViaComponentInspectionReport = null;
			_serviceReportNumberType = null;

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

			_fieldsCustomProperties.Add("ServiceReportNumberTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentServiceReportNumberTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _serviceReportNumberType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncServiceReportNumberType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _serviceReportNumberType, new PropertyChangedEventHandler( OnServiceReportNumberTypePropertyChanged ), "ServiceReportNumberType", ServiceReportNumberTypeEntity.Relations.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeIdParentServiceReportNumberTypeId, true, signalRelatedEntity, "ServiceReportNumberType_", resetFKFields, new int[] { (int)ServiceReportNumberTypeFieldIndex.ParentServiceReportNumberTypeId } );		
			_serviceReportNumberType = null;
		}

		/// <summary> setups the sync logic for member _serviceReportNumberType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncServiceReportNumberType(IEntity2 relatedEntity)
		{
			DesetupSyncServiceReportNumberType(true, true);
			_serviceReportNumberType = (ServiceReportNumberTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _serviceReportNumberType, new PropertyChangedEventHandler( OnServiceReportNumberTypePropertyChanged ), "ServiceReportNumberType", ServiceReportNumberTypeEntity.Relations.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeIdParentServiceReportNumberTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnServiceReportNumberTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ServiceReportNumberTypeEntity</param>
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
		public  static ServiceReportNumberTypeRelations Relations
		{
			get	{ return new ServiceReportNumberTypeRelations(); }
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
					ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ServiceReportNumberType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathServiceReportNumberType_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory))),
					ServiceReportNumberTypeEntity.Relations.ServiceReportNumberTypeEntityUsingParentServiceReportNumberTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, 0, null, null, null, null, "ServiceReportNumberType_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
				IEntityRelation intermediateRelation = ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.BooleanAnswerEntityUsingReconstructionBooleanAnswerId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTypeEntity, 0, null, null, relations, null, "ComponentInspectionReportTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.CountryIsoEntityUsingCountryIsoid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, 0, null, null, relations, null, "CountryIsoCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.LocationTypeEntityUsingLocationTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<LocationTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(LocationTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.LocationTypeEntity, 0, null, null, relations, null, "LocationTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.ReportTypeEntityUsingReportTypeId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ReportTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ReportTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.ReportTypeEntity, 0, null, null, relations, null, "ReportTypeCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.SbuEntityUsingSbuid, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.SbuEntity, 0, null, null, relations, null, "SbuCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.TurbineMatrixEntityUsingTurbineMatrixId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, 0, null, null, relations, null, "TurbineMatrixCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingAfterInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, 0, null, null, relations, null, "TurbineRunStatusCollectionViaComponentInspectionReport_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReport_");
				relations.Add(ServiceReportNumberTypeEntity.Relations.ComponentInspectionReportEntityUsingServiceReportNumberTypeId, "ServiceReportNumberTypeEntity__", "ComponentInspectionReport_", JoinHint.None);
				relations.Add(ComponentInspectionReportEntity.Relations.TurbineRunStatusEntityUsingBeforeInspectionTurbineRunStatusId, "ComponentInspectionReport_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineRunStatusEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRunStatusEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity, 0, null, null, relations, null, "TurbineRunStatusCollectionViaComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ServiceReportNumberType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathServiceReportNumberType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory))),
					ServiceReportNumberTypeEntity.Relations.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeIdParentServiceReportNumberTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, (int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity, 0, null, null, null, null, "ServiceReportNumberType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ServiceReportNumberTypeEntity.CustomProperties;}
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
			get { return ServiceReportNumberTypeEntity.FieldsCustomProperties;}
		}

		/// <summary> The ServiceReportNumberTypeId property of the Entity ServiceReportNumberType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ServiceReportNumberType"."ServiceReportNumberTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ServiceReportNumberTypeId
		{
			get { return (System.Int64)GetValue((int)ServiceReportNumberTypeFieldIndex.ServiceReportNumberTypeId, true); }
			set	{ SetValue((int)ServiceReportNumberTypeFieldIndex.ServiceReportNumberTypeId, value); }
		}

		/// <summary> The Name property of the Entity ServiceReportNumberType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ServiceReportNumberType"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)ServiceReportNumberTypeFieldIndex.Name, true); }
			set	{ SetValue((int)ServiceReportNumberTypeFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity ServiceReportNumberType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ServiceReportNumberType"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)ServiceReportNumberTypeFieldIndex.LanguageId, true); }
			set	{ SetValue((int)ServiceReportNumberTypeFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentServiceReportNumberTypeId property of the Entity ServiceReportNumberType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ServiceReportNumberType"."ParentServiceReportNumberTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentServiceReportNumberTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ServiceReportNumberTypeFieldIndex.ParentServiceReportNumberTypeId, false); }
			set	{ SetValue((int)ServiceReportNumberTypeFieldIndex.ParentServiceReportNumberTypeId, value); }
		}

		/// <summary> The Sort property of the Entity ServiceReportNumberType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ServiceReportNumberType"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)ServiceReportNumberTypeFieldIndex.Sort, true); }
			set	{ SetValue((int)ServiceReportNumberTypeFieldIndex.Sort, value); }
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
					_componentInspectionReport.SetContainingEntityInfo(this, "ServiceReportNumberType");
				}
				return _componentInspectionReport;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ServiceReportNumberTypeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ServiceReportNumberTypeEntity))]
		public virtual EntityCollection<ServiceReportNumberTypeEntity> ServiceReportNumberType_
		{
			get
			{
				if(_serviceReportNumberType_==null)
				{
					_serviceReportNumberType_ = new EntityCollection<ServiceReportNumberTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ServiceReportNumberTypeEntityFactory)));
					_serviceReportNumberType_.SetContainingEntityInfo(this, "ServiceReportNumberType");
				}
				return _serviceReportNumberType_;
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

		/// <summary> Gets / sets related entity of type 'ServiceReportNumberTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ServiceReportNumberTypeEntity ServiceReportNumberType
		{
			get
			{
				return _serviceReportNumberType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncServiceReportNumberType(value);
				}
				else
				{
					if(value==null)
					{
						if(_serviceReportNumberType != null)
						{
							_serviceReportNumberType.UnsetRelatedEntity(this, "ServiceReportNumberType_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ServiceReportNumberType_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity; }
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
