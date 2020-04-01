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
	/// Entity class which represents the entity 'MainBearingErrorLocation'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class MainBearingErrorLocationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportMainBearingEntity> _componentInspectionReportMainBearing;
		private EntityCollection<MainBearingErrorLocationEntity> _mainBearingErrorLocation_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportMainBearing;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportMainBearing;
		private EntityCollection<MainBearingManufacturerEntity> _mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_;
		private EntityCollection<MainBearingManufacturerEntity> _mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing;
		private EntityCollection<OilTypeEntity> _oilTypeCollectionViaComponentInspectionReportMainBearing;
		private MainBearingErrorLocationEntity _mainBearingErrorLocation;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name MainBearingErrorLocation</summary>
			public static readonly string MainBearingErrorLocation = "MainBearingErrorLocation";
			/// <summary>Member name ComponentInspectionReportMainBearing</summary>
			public static readonly string ComponentInspectionReportMainBearing = "ComponentInspectionReportMainBearing";
			/// <summary>Member name MainBearingErrorLocation_</summary>
			public static readonly string MainBearingErrorLocation_ = "MainBearingErrorLocation_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportMainBearing</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportMainBearing = "BooleanAnswerCollectionViaComponentInspectionReportMainBearing";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportMainBearing</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportMainBearing = "ComponentInspectionReportCollectionViaComponentInspectionReportMainBearing";
			/// <summary>Member name MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_</summary>
			public static readonly string MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_ = "MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_";
			/// <summary>Member name MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing</summary>
			public static readonly string MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing = "MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing";
			/// <summary>Member name OilTypeCollectionViaComponentInspectionReportMainBearing</summary>
			public static readonly string OilTypeCollectionViaComponentInspectionReportMainBearing = "OilTypeCollectionViaComponentInspectionReportMainBearing";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static MainBearingErrorLocationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public MainBearingErrorLocationEntity():base("MainBearingErrorLocationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public MainBearingErrorLocationEntity(IEntityFields2 fields):base("MainBearingErrorLocationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this MainBearingErrorLocationEntity</param>
		public MainBearingErrorLocationEntity(IValidator validator):base("MainBearingErrorLocationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="mainBearingErrorLocationId">PK value for MainBearingErrorLocation which data should be fetched into this MainBearingErrorLocation object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MainBearingErrorLocationEntity(System.Int64 mainBearingErrorLocationId):base("MainBearingErrorLocationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.MainBearingErrorLocationId = mainBearingErrorLocationId;
		}

		/// <summary> CTor</summary>
		/// <param name="mainBearingErrorLocationId">PK value for MainBearingErrorLocation which data should be fetched into this MainBearingErrorLocation object</param>
		/// <param name="validator">The custom validator object for this MainBearingErrorLocationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public MainBearingErrorLocationEntity(System.Int64 mainBearingErrorLocationId, IValidator validator):base("MainBearingErrorLocationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.MainBearingErrorLocationId = mainBearingErrorLocationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected MainBearingErrorLocationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReportMainBearing = (EntityCollection<ComponentInspectionReportMainBearingEntity>)info.GetValue("_componentInspectionReportMainBearing", typeof(EntityCollection<ComponentInspectionReportMainBearingEntity>));
				_mainBearingErrorLocation_ = (EntityCollection<MainBearingErrorLocationEntity>)info.GetValue("_mainBearingErrorLocation_", typeof(EntityCollection<MainBearingErrorLocationEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportMainBearing = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportMainBearing", typeof(EntityCollection<BooleanAnswerEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportMainBearing = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportMainBearing", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_ = (EntityCollection<MainBearingManufacturerEntity>)info.GetValue("_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_", typeof(EntityCollection<MainBearingManufacturerEntity>));
				_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing = (EntityCollection<MainBearingManufacturerEntity>)info.GetValue("_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing", typeof(EntityCollection<MainBearingManufacturerEntity>));
				_oilTypeCollectionViaComponentInspectionReportMainBearing = (EntityCollection<OilTypeEntity>)info.GetValue("_oilTypeCollectionViaComponentInspectionReportMainBearing", typeof(EntityCollection<OilTypeEntity>));
				_mainBearingErrorLocation = (MainBearingErrorLocationEntity)info.GetValue("_mainBearingErrorLocation", typeof(MainBearingErrorLocationEntity));
				if(_mainBearingErrorLocation!=null)
				{
					_mainBearingErrorLocation.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((MainBearingErrorLocationFieldIndex)fieldIndex)
			{
				case MainBearingErrorLocationFieldIndex.ParentMainBearingErrorLocationId:
					DesetupSyncMainBearingErrorLocation(true, false);
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
				case "MainBearingErrorLocation":
					this.MainBearingErrorLocation = (MainBearingErrorLocationEntity)entity;
					break;
				case "ComponentInspectionReportMainBearing":
					this.ComponentInspectionReportMainBearing.Add((ComponentInspectionReportMainBearingEntity)entity);
					break;
				case "MainBearingErrorLocation_":
					this.MainBearingErrorLocation_.Add((MainBearingErrorLocationEntity)entity);
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportMainBearing":
					this.BooleanAnswerCollectionViaComponentInspectionReportMainBearing.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportMainBearing.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportMainBearing.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportMainBearing":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportMainBearing.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportMainBearing.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportMainBearing.IsReadOnly = true;
					break;
				case "MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_":
					this.MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_.IsReadOnly = false;
					this.MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_.Add((MainBearingManufacturerEntity)entity);
					this.MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_.IsReadOnly = true;
					break;
				case "MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing":
					this.MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing.IsReadOnly = false;
					this.MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing.Add((MainBearingManufacturerEntity)entity);
					this.MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing.IsReadOnly = true;
					break;
				case "OilTypeCollectionViaComponentInspectionReportMainBearing":
					this.OilTypeCollectionViaComponentInspectionReportMainBearing.IsReadOnly = false;
					this.OilTypeCollectionViaComponentInspectionReportMainBearing.Add((OilTypeEntity)entity);
					this.OilTypeCollectionViaComponentInspectionReportMainBearing.IsReadOnly = true;
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
				case "MainBearingErrorLocation":
					SetupSyncMainBearingErrorLocation(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportMainBearing":
					this.ComponentInspectionReportMainBearing.Add((ComponentInspectionReportMainBearingEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "MainBearingErrorLocation_":
					this.MainBearingErrorLocation_.Add((MainBearingErrorLocationEntity)relatedEntity);
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
				case "MainBearingErrorLocation":
					DesetupSyncMainBearingErrorLocation(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportMainBearing":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportMainBearing, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "MainBearingErrorLocation_":
					base.PerformRelatedEntityRemoval(this.MainBearingErrorLocation_, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_mainBearingErrorLocation!=null)
			{
				toReturn.Add(_mainBearingErrorLocation);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReportMainBearing);
			toReturn.Add(this.MainBearingErrorLocation_);

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
				info.AddValue("_componentInspectionReportMainBearing", ((_componentInspectionReportMainBearing!=null) && (_componentInspectionReportMainBearing.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportMainBearing:null);
				info.AddValue("_mainBearingErrorLocation_", ((_mainBearingErrorLocation_!=null) && (_mainBearingErrorLocation_.Count>0) && !this.MarkedForDeletion)?_mainBearingErrorLocation_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportMainBearing", ((_booleanAnswerCollectionViaComponentInspectionReportMainBearing!=null) && (_booleanAnswerCollectionViaComponentInspectionReportMainBearing.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportMainBearing:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportMainBearing", ((_componentInspectionReportCollectionViaComponentInspectionReportMainBearing!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportMainBearing.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportMainBearing:null);
				info.AddValue("_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_", ((_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_!=null) && (_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_.Count>0) && !this.MarkedForDeletion)?_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_:null);
				info.AddValue("_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing", ((_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing!=null) && (_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing.Count>0) && !this.MarkedForDeletion)?_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing:null);
				info.AddValue("_oilTypeCollectionViaComponentInspectionReportMainBearing", ((_oilTypeCollectionViaComponentInspectionReportMainBearing!=null) && (_oilTypeCollectionViaComponentInspectionReportMainBearing.Count>0) && !this.MarkedForDeletion)?_oilTypeCollectionViaComponentInspectionReportMainBearing:null);
				info.AddValue("_mainBearingErrorLocation", (!this.MarkedForDeletion?_mainBearingErrorLocation:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(MainBearingErrorLocationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(MainBearingErrorLocationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new MainBearingErrorLocationRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportMainBearing' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportMainBearing()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportMainBearingFields.MainBearingErrorLocationId, null, ComparisonOperator.Equal, this.MainBearingErrorLocationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MainBearingErrorLocation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMainBearingErrorLocation_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MainBearingErrorLocationFields.ParentMainBearingErrorLocationId, null, ComparisonOperator.Equal, this.MainBearingErrorLocationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportMainBearing()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId, "MainBearingErrorLocationEntity__", "ComponentInspectionReportMainBearing_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportMainBearingEntity.Relations.BooleanAnswerEntityUsingMainBearingClaimRelevantBooleanAnswerId, "ComponentInspectionReportMainBearing_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MainBearingErrorLocationFields.MainBearingErrorLocationId, null, ComparisonOperator.Equal, this.MainBearingErrorLocationId, "MainBearingErrorLocationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportMainBearing()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId, "MainBearingErrorLocationEntity__", "ComponentInspectionReportMainBearing_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportMainBearingEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportMainBearing_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MainBearingErrorLocationFields.MainBearingErrorLocationId, null, ComparisonOperator.Equal, this.MainBearingErrorLocationId, "MainBearingErrorLocationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MainBearingManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId, "MainBearingErrorLocationEntity__", "ComponentInspectionReportMainBearing_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportMainBearingEntity.Relations.MainBearingManufacturerEntityUsingMainBearingTypeId, "ComponentInspectionReportMainBearing_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MainBearingErrorLocationFields.MainBearingErrorLocationId, null, ComparisonOperator.Equal, this.MainBearingErrorLocationId, "MainBearingErrorLocationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MainBearingManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMainBearingManufacturerCollectionViaComponentInspectionReportMainBearing()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId, "MainBearingErrorLocationEntity__", "ComponentInspectionReportMainBearing_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportMainBearingEntity.Relations.MainBearingManufacturerEntityUsingMainBearingManufacturerId, "ComponentInspectionReportMainBearing_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MainBearingErrorLocationFields.MainBearingErrorLocationId, null, ComparisonOperator.Equal, this.MainBearingErrorLocationId, "MainBearingErrorLocationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OilType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOilTypeCollectionViaComponentInspectionReportMainBearing()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId, "MainBearingErrorLocationEntity__", "ComponentInspectionReportMainBearing_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportMainBearingEntity.Relations.OilTypeEntityUsingMainBearingLubricationOilTypeId, "ComponentInspectionReportMainBearing_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MainBearingErrorLocationFields.MainBearingErrorLocationId, null, ComparisonOperator.Equal, this.MainBearingErrorLocationId, "MainBearingErrorLocationEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MainBearingErrorLocation' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMainBearingErrorLocation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MainBearingErrorLocationFields.MainBearingErrorLocationId, null, ComparisonOperator.Equal, this.ParentMainBearingErrorLocationId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(MainBearingErrorLocationEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReportMainBearing);
			collectionsQueue.Enqueue(this._mainBearingErrorLocation_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportMainBearing);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportMainBearing);
			collectionsQueue.Enqueue(this._mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_);
			collectionsQueue.Enqueue(this._mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing);
			collectionsQueue.Enqueue(this._oilTypeCollectionViaComponentInspectionReportMainBearing);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReportMainBearing = (EntityCollection<ComponentInspectionReportMainBearingEntity>) collectionsQueue.Dequeue();
			this._mainBearingErrorLocation_ = (EntityCollection<MainBearingErrorLocationEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportMainBearing = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportMainBearing = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_ = (EntityCollection<MainBearingManufacturerEntity>) collectionsQueue.Dequeue();
			this._mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing = (EntityCollection<MainBearingManufacturerEntity>) collectionsQueue.Dequeue();
			this._oilTypeCollectionViaComponentInspectionReportMainBearing = (EntityCollection<OilTypeEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReportMainBearing != null)
			{
				return true;
			}
			if (this._mainBearingErrorLocation_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportMainBearing != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportMainBearing != null)
			{
				return true;
			}
			if (this._mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_ != null)
			{
				return true;
			}
			if (this._mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing != null)
			{
				return true;
			}
			if (this._oilTypeCollectionViaComponentInspectionReportMainBearing != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportMainBearingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportMainBearingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MainBearingErrorLocationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingErrorLocationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MainBearingManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MainBearingManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OilTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OilTypeEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("MainBearingErrorLocation", _mainBearingErrorLocation);
			toReturn.Add("ComponentInspectionReportMainBearing", _componentInspectionReportMainBearing);
			toReturn.Add("MainBearingErrorLocation_", _mainBearingErrorLocation_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportMainBearing", _booleanAnswerCollectionViaComponentInspectionReportMainBearing);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportMainBearing", _componentInspectionReportCollectionViaComponentInspectionReportMainBearing);
			toReturn.Add("MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_", _mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_);
			toReturn.Add("MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing", _mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing);
			toReturn.Add("OilTypeCollectionViaComponentInspectionReportMainBearing", _oilTypeCollectionViaComponentInspectionReportMainBearing);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReportMainBearing!=null)
			{
				_componentInspectionReportMainBearing.ActiveContext = base.ActiveContext;
			}
			if(_mainBearingErrorLocation_!=null)
			{
				_mainBearingErrorLocation_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportMainBearing!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportMainBearing.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportMainBearing!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportMainBearing.ActiveContext = base.ActiveContext;
			}
			if(_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_!=null)
			{
				_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_.ActiveContext = base.ActiveContext;
			}
			if(_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing!=null)
			{
				_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing.ActiveContext = base.ActiveContext;
			}
			if(_oilTypeCollectionViaComponentInspectionReportMainBearing!=null)
			{
				_oilTypeCollectionViaComponentInspectionReportMainBearing.ActiveContext = base.ActiveContext;
			}
			if(_mainBearingErrorLocation!=null)
			{
				_mainBearingErrorLocation.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReportMainBearing = null;
			_mainBearingErrorLocation_ = null;
			_booleanAnswerCollectionViaComponentInspectionReportMainBearing = null;
			_componentInspectionReportCollectionViaComponentInspectionReportMainBearing = null;
			_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_ = null;
			_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing = null;
			_oilTypeCollectionViaComponentInspectionReportMainBearing = null;
			_mainBearingErrorLocation = null;

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

			_fieldsCustomProperties.Add("MainBearingErrorLocationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentMainBearingErrorLocationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _mainBearingErrorLocation</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMainBearingErrorLocation(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _mainBearingErrorLocation, new PropertyChangedEventHandler( OnMainBearingErrorLocationPropertyChanged ), "MainBearingErrorLocation", MainBearingErrorLocationEntity.Relations.MainBearingErrorLocationEntityUsingMainBearingErrorLocationIdParentMainBearingErrorLocationId, true, signalRelatedEntity, "MainBearingErrorLocation_", resetFKFields, new int[] { (int)MainBearingErrorLocationFieldIndex.ParentMainBearingErrorLocationId } );		
			_mainBearingErrorLocation = null;
		}

		/// <summary> setups the sync logic for member _mainBearingErrorLocation</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMainBearingErrorLocation(IEntity2 relatedEntity)
		{
			DesetupSyncMainBearingErrorLocation(true, true);
			_mainBearingErrorLocation = (MainBearingErrorLocationEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _mainBearingErrorLocation, new PropertyChangedEventHandler( OnMainBearingErrorLocationPropertyChanged ), "MainBearingErrorLocation", MainBearingErrorLocationEntity.Relations.MainBearingErrorLocationEntityUsingMainBearingErrorLocationIdParentMainBearingErrorLocationId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMainBearingErrorLocationPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this MainBearingErrorLocationEntity</param>
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
		public  static MainBearingErrorLocationRelations Relations
		{
			get	{ return new MainBearingErrorLocationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportMainBearing' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportMainBearing
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportMainBearingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportMainBearingEntityFactory))),
					MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId, 
					(int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity, 0, null, null, null, null, "ComponentInspectionReportMainBearing", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MainBearingErrorLocation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMainBearingErrorLocation_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<MainBearingErrorLocationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingErrorLocationEntityFactory))),
					MainBearingErrorLocationEntity.Relations.MainBearingErrorLocationEntityUsingParentMainBearingErrorLocationId, 
					(int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity, (int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity, 0, null, null, null, null, "MainBearingErrorLocation_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportMainBearing
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportMainBearing_");
				relations.Add(MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId, "MainBearingErrorLocationEntity__", "ComponentInspectionReportMainBearing_", JoinHint.None);
				relations.Add(ComponentInspectionReportMainBearingEntity.Relations.BooleanAnswerEntityUsingMainBearingClaimRelevantBooleanAnswerId, "ComponentInspectionReportMainBearing_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportMainBearing", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportMainBearing
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportMainBearing_");
				relations.Add(MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId, "MainBearingErrorLocationEntity__", "ComponentInspectionReportMainBearing_", JoinHint.None);
				relations.Add(ComponentInspectionReportMainBearingEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportMainBearing_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportMainBearing", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MainBearingManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportMainBearing_");
				relations.Add(MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId, "MainBearingErrorLocationEntity__", "ComponentInspectionReportMainBearing_", JoinHint.None);
				relations.Add(ComponentInspectionReportMainBearingEntity.Relations.MainBearingManufacturerEntityUsingMainBearingTypeId, "ComponentInspectionReportMainBearing_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<MainBearingManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity, (int)Cir.Data.LLBLGen.EntityType.MainBearingManufacturerEntity, 0, null, null, relations, null, "MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MainBearingManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMainBearingManufacturerCollectionViaComponentInspectionReportMainBearing
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportMainBearing_");
				relations.Add(MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId, "MainBearingErrorLocationEntity__", "ComponentInspectionReportMainBearing_", JoinHint.None);
				relations.Add(ComponentInspectionReportMainBearingEntity.Relations.MainBearingManufacturerEntityUsingMainBearingManufacturerId, "ComponentInspectionReportMainBearing_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<MainBearingManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity, (int)Cir.Data.LLBLGen.EntityType.MainBearingManufacturerEntity, 0, null, null, relations, null, "MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OilType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOilTypeCollectionViaComponentInspectionReportMainBearing
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportMainBearing_");
				relations.Add(MainBearingErrorLocationEntity.Relations.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId, "MainBearingErrorLocationEntity__", "ComponentInspectionReportMainBearing_", JoinHint.None);
				relations.Add(ComponentInspectionReportMainBearingEntity.Relations.OilTypeEntityUsingMainBearingLubricationOilTypeId, "ComponentInspectionReportMainBearing_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OilTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OilTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity, (int)Cir.Data.LLBLGen.EntityType.OilTypeEntity, 0, null, null, relations, null, "OilTypeCollectionViaComponentInspectionReportMainBearing", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MainBearingErrorLocation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMainBearingErrorLocation
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingErrorLocationEntityFactory))),
					MainBearingErrorLocationEntity.Relations.MainBearingErrorLocationEntityUsingMainBearingErrorLocationIdParentMainBearingErrorLocationId, 
					(int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity, (int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity, 0, null, null, null, null, "MainBearingErrorLocation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return MainBearingErrorLocationEntity.CustomProperties;}
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
			get { return MainBearingErrorLocationEntity.FieldsCustomProperties;}
		}

		/// <summary> The MainBearingErrorLocationId property of the Entity MainBearingErrorLocation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "MainBearingErrorLocation"."MainBearingErrorLocationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 MainBearingErrorLocationId
		{
			get { return (System.Int64)GetValue((int)MainBearingErrorLocationFieldIndex.MainBearingErrorLocationId, true); }
			set	{ SetValue((int)MainBearingErrorLocationFieldIndex.MainBearingErrorLocationId, value); }
		}

		/// <summary> The Name property of the Entity MainBearingErrorLocation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "MainBearingErrorLocation"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)MainBearingErrorLocationFieldIndex.Name, true); }
			set	{ SetValue((int)MainBearingErrorLocationFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity MainBearingErrorLocation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "MainBearingErrorLocation"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)MainBearingErrorLocationFieldIndex.LanguageId, true); }
			set	{ SetValue((int)MainBearingErrorLocationFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentMainBearingErrorLocationId property of the Entity MainBearingErrorLocation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "MainBearingErrorLocation"."ParentMainBearingErrorLocationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentMainBearingErrorLocationId
		{
			get { return (Nullable<System.Int64>)GetValue((int)MainBearingErrorLocationFieldIndex.ParentMainBearingErrorLocationId, false); }
			set	{ SetValue((int)MainBearingErrorLocationFieldIndex.ParentMainBearingErrorLocationId, value); }
		}

		/// <summary> The Sort property of the Entity MainBearingErrorLocation<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "MainBearingErrorLocation"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)MainBearingErrorLocationFieldIndex.Sort, true); }
			set	{ SetValue((int)MainBearingErrorLocationFieldIndex.Sort, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportMainBearingEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportMainBearingEntity))]
		public virtual EntityCollection<ComponentInspectionReportMainBearingEntity> ComponentInspectionReportMainBearing
		{
			get
			{
				if(_componentInspectionReportMainBearing==null)
				{
					_componentInspectionReportMainBearing = new EntityCollection<ComponentInspectionReportMainBearingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportMainBearingEntityFactory)));
					_componentInspectionReportMainBearing.SetContainingEntityInfo(this, "MainBearingErrorLocation");
				}
				return _componentInspectionReportMainBearing;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MainBearingErrorLocationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MainBearingErrorLocationEntity))]
		public virtual EntityCollection<MainBearingErrorLocationEntity> MainBearingErrorLocation_
		{
			get
			{
				if(_mainBearingErrorLocation_==null)
				{
					_mainBearingErrorLocation_ = new EntityCollection<MainBearingErrorLocationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingErrorLocationEntityFactory)));
					_mainBearingErrorLocation_.SetContainingEntityInfo(this, "MainBearingErrorLocation");
				}
				return _mainBearingErrorLocation_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportMainBearing
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportMainBearing==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportMainBearing = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportMainBearing.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportMainBearing;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportMainBearing
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportMainBearing==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportMainBearing = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportMainBearing.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportMainBearing;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MainBearingManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MainBearingManufacturerEntity))]
		public virtual EntityCollection<MainBearingManufacturerEntity> MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_
		{
			get
			{
				if(_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_==null)
				{
					_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_ = new EntityCollection<MainBearingManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingManufacturerEntityFactory)));
					_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_.IsReadOnly=true;
				}
				return _mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MainBearingManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MainBearingManufacturerEntity))]
		public virtual EntityCollection<MainBearingManufacturerEntity> MainBearingManufacturerCollectionViaComponentInspectionReportMainBearing
		{
			get
			{
				if(_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing==null)
				{
					_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing = new EntityCollection<MainBearingManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingManufacturerEntityFactory)));
					_mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing.IsReadOnly=true;
				}
				return _mainBearingManufacturerCollectionViaComponentInspectionReportMainBearing;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OilTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OilTypeEntity))]
		public virtual EntityCollection<OilTypeEntity> OilTypeCollectionViaComponentInspectionReportMainBearing
		{
			get
			{
				if(_oilTypeCollectionViaComponentInspectionReportMainBearing==null)
				{
					_oilTypeCollectionViaComponentInspectionReportMainBearing = new EntityCollection<OilTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OilTypeEntityFactory)));
					_oilTypeCollectionViaComponentInspectionReportMainBearing.IsReadOnly=true;
				}
				return _oilTypeCollectionViaComponentInspectionReportMainBearing;
			}
		}

		/// <summary> Gets / sets related entity of type 'MainBearingErrorLocationEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MainBearingErrorLocationEntity MainBearingErrorLocation
		{
			get
			{
				return _mainBearingErrorLocation;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMainBearingErrorLocation(value);
				}
				else
				{
					if(value==null)
					{
						if(_mainBearingErrorLocation != null)
						{
							_mainBearingErrorLocation.UnsetRelatedEntity(this, "MainBearingErrorLocation_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "MainBearingErrorLocation_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity; }
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
