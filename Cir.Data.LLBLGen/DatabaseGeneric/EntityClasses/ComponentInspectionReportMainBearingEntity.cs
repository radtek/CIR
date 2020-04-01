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
	/// Entity class which represents the entity 'ComponentInspectionReportMainBearing'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ComponentInspectionReportMainBearingEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private BooleanAnswerEntity _booleanAnswer;
		private ComponentInspectionReportEntity _componentInspectionReport;
		private MainBearingErrorLocationEntity _mainBearingErrorLocation;
		private MainBearingManufacturerEntity _mainBearingManufacturer_;
		private MainBearingManufacturerEntity _mainBearingManufacturer;
		private OilTypeEntity _oilType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name BooleanAnswer</summary>
			public static readonly string BooleanAnswer = "BooleanAnswer";
			/// <summary>Member name ComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReport = "ComponentInspectionReport";
			/// <summary>Member name MainBearingErrorLocation</summary>
			public static readonly string MainBearingErrorLocation = "MainBearingErrorLocation";
			/// <summary>Member name MainBearingManufacturer_</summary>
			public static readonly string MainBearingManufacturer_ = "MainBearingManufacturer_";
			/// <summary>Member name MainBearingManufacturer</summary>
			public static readonly string MainBearingManufacturer = "MainBearingManufacturer";
			/// <summary>Member name OilType</summary>
			public static readonly string OilType = "OilType";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ComponentInspectionReportMainBearingEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ComponentInspectionReportMainBearingEntity():base("ComponentInspectionReportMainBearingEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ComponentInspectionReportMainBearingEntity(IEntityFields2 fields):base("ComponentInspectionReportMainBearingEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportMainBearingEntity</param>
		public ComponentInspectionReportMainBearingEntity(IValidator validator):base("ComponentInspectionReportMainBearingEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportMainBearingId">PK value for ComponentInspectionReportMainBearing which data should be fetched into this ComponentInspectionReportMainBearing object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportMainBearingEntity(System.Int64 componentInspectionReportMainBearingId):base("ComponentInspectionReportMainBearingEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ComponentInspectionReportMainBearingId = componentInspectionReportMainBearingId;
		}

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportMainBearingId">PK value for ComponentInspectionReportMainBearing which data should be fetched into this ComponentInspectionReportMainBearing object</param>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportMainBearingEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportMainBearingEntity(System.Int64 componentInspectionReportMainBearingId, IValidator validator):base("ComponentInspectionReportMainBearingEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ComponentInspectionReportMainBearingId = componentInspectionReportMainBearingId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ComponentInspectionReportMainBearingEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_booleanAnswer = (BooleanAnswerEntity)info.GetValue("_booleanAnswer", typeof(BooleanAnswerEntity));
				if(_booleanAnswer!=null)
				{
					_booleanAnswer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_componentInspectionReport = (ComponentInspectionReportEntity)info.GetValue("_componentInspectionReport", typeof(ComponentInspectionReportEntity));
				if(_componentInspectionReport!=null)
				{
					_componentInspectionReport.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_mainBearingErrorLocation = (MainBearingErrorLocationEntity)info.GetValue("_mainBearingErrorLocation", typeof(MainBearingErrorLocationEntity));
				if(_mainBearingErrorLocation!=null)
				{
					_mainBearingErrorLocation.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_mainBearingManufacturer_ = (MainBearingManufacturerEntity)info.GetValue("_mainBearingManufacturer_", typeof(MainBearingManufacturerEntity));
				if(_mainBearingManufacturer_!=null)
				{
					_mainBearingManufacturer_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_mainBearingManufacturer = (MainBearingManufacturerEntity)info.GetValue("_mainBearingManufacturer", typeof(MainBearingManufacturerEntity));
				if(_mainBearingManufacturer!=null)
				{
					_mainBearingManufacturer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_oilType = (OilTypeEntity)info.GetValue("_oilType", typeof(OilTypeEntity));
				if(_oilType!=null)
				{
					_oilType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ComponentInspectionReportMainBearingFieldIndex)fieldIndex)
			{
				case ComponentInspectionReportMainBearingFieldIndex.ComponentInspectionReportId:
					DesetupSyncComponentInspectionReport(true, false);
					break;
				case ComponentInspectionReportMainBearingFieldIndex.MainBearingManufacturerId:
					DesetupSyncMainBearingManufacturer(true, false);
					break;
				case ComponentInspectionReportMainBearingFieldIndex.MainBearingLubricationOilTypeId:
					DesetupSyncOilType(true, false);
					break;
				case ComponentInspectionReportMainBearingFieldIndex.MainBearingTypeId:
					DesetupSyncMainBearingManufacturer_(true, false);
					break;
				case ComponentInspectionReportMainBearingFieldIndex.MainBearingErrorLocationId:
					DesetupSyncMainBearingErrorLocation(true, false);
					break;
				case ComponentInspectionReportMainBearingFieldIndex.MainBearingClaimRelevantBooleanAnswerId:
					DesetupSyncBooleanAnswer(true, false);
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
				case "BooleanAnswer":
					this.BooleanAnswer = (BooleanAnswerEntity)entity;
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport = (ComponentInspectionReportEntity)entity;
					break;
				case "MainBearingErrorLocation":
					this.MainBearingErrorLocation = (MainBearingErrorLocationEntity)entity;
					break;
				case "MainBearingManufacturer_":
					this.MainBearingManufacturer_ = (MainBearingManufacturerEntity)entity;
					break;
				case "MainBearingManufacturer":
					this.MainBearingManufacturer = (MainBearingManufacturerEntity)entity;
					break;
				case "OilType":
					this.OilType = (OilTypeEntity)entity;
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
				case "BooleanAnswer":
					SetupSyncBooleanAnswer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					SetupSyncComponentInspectionReport(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "MainBearingErrorLocation":
					SetupSyncMainBearingErrorLocation(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "MainBearingManufacturer_":
					SetupSyncMainBearingManufacturer_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "MainBearingManufacturer":
					SetupSyncMainBearingManufacturer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OilType":
					SetupSyncOilType(relatedEntity);
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
				case "BooleanAnswer":
					DesetupSyncBooleanAnswer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					DesetupSyncComponentInspectionReport(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "MainBearingErrorLocation":
					DesetupSyncMainBearingErrorLocation(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "MainBearingManufacturer_":
					DesetupSyncMainBearingManufacturer_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "MainBearingManufacturer":
					DesetupSyncMainBearingManufacturer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OilType":
					DesetupSyncOilType(false, true);
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
			if(_booleanAnswer!=null)
			{
				toReturn.Add(_booleanAnswer);
			}
			if(_componentInspectionReport!=null)
			{
				toReturn.Add(_componentInspectionReport);
			}
			if(_mainBearingErrorLocation!=null)
			{
				toReturn.Add(_mainBearingErrorLocation);
			}
			if(_mainBearingManufacturer_!=null)
			{
				toReturn.Add(_mainBearingManufacturer_);
			}
			if(_mainBearingManufacturer!=null)
			{
				toReturn.Add(_mainBearingManufacturer);
			}
			if(_oilType!=null)
			{
				toReturn.Add(_oilType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();


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


				info.AddValue("_booleanAnswer", (!this.MarkedForDeletion?_booleanAnswer:null));
				info.AddValue("_componentInspectionReport", (!this.MarkedForDeletion?_componentInspectionReport:null));
				info.AddValue("_mainBearingErrorLocation", (!this.MarkedForDeletion?_mainBearingErrorLocation:null));
				info.AddValue("_mainBearingManufacturer_", (!this.MarkedForDeletion?_mainBearingManufacturer_:null));
				info.AddValue("_mainBearingManufacturer", (!this.MarkedForDeletion?_mainBearingManufacturer:null));
				info.AddValue("_oilType", (!this.MarkedForDeletion?_oilType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ComponentInspectionReportMainBearingFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ComponentInspectionReportMainBearingFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ComponentInspectionReportMainBearingRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.MainBearingClaimRelevantBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportFields.ComponentInspectionReportId, null, ComparisonOperator.Equal, this.ComponentInspectionReportId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MainBearingErrorLocation' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMainBearingErrorLocation()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MainBearingErrorLocationFields.MainBearingErrorLocationId, null, ComparisonOperator.Equal, this.MainBearingErrorLocationId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MainBearingManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMainBearingManufacturer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MainBearingManufacturerFields.MainBearingManufacturerId, null, ComparisonOperator.Equal, this.MainBearingTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MainBearingManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMainBearingManufacturer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MainBearingManufacturerFields.MainBearingManufacturerId, null, ComparisonOperator.Equal, this.MainBearingManufacturerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OilType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOilType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OilTypeFields.OilTypeId, null, ComparisonOperator.Equal, this.MainBearingLubricationOilTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportMainBearingEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{


			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);


		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("BooleanAnswer", _booleanAnswer);
			toReturn.Add("ComponentInspectionReport", _componentInspectionReport);
			toReturn.Add("MainBearingErrorLocation", _mainBearingErrorLocation);
			toReturn.Add("MainBearingManufacturer_", _mainBearingManufacturer_);
			toReturn.Add("MainBearingManufacturer", _mainBearingManufacturer);
			toReturn.Add("OilType", _oilType);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_booleanAnswer!=null)
			{
				_booleanAnswer.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReport!=null)
			{
				_componentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_mainBearingErrorLocation!=null)
			{
				_mainBearingErrorLocation.ActiveContext = base.ActiveContext;
			}
			if(_mainBearingManufacturer_!=null)
			{
				_mainBearingManufacturer_.ActiveContext = base.ActiveContext;
			}
			if(_mainBearingManufacturer!=null)
			{
				_mainBearingManufacturer.ActiveContext = base.ActiveContext;
			}
			if(_oilType!=null)
			{
				_oilType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_booleanAnswer = null;
			_componentInspectionReport = null;
			_mainBearingErrorLocation = null;
			_mainBearingManufacturer_ = null;
			_mainBearingManufacturer = null;
			_oilType = null;

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

			_fieldsCustomProperties.Add("ComponentInspectionReportMainBearingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VestasUniqueIdentifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingLastLubricationDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingTemperature", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingLubricationOilTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingGrease", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingLubricationRunHours", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingOilTemperature", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingRevision", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingErrorLocationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingSerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingRunHours", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingMechanicalOilPump", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("MainBearingClaimRelevantBooleanAnswerId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _booleanAnswer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportMainBearingEntity.Relations.BooleanAnswerEntityUsingMainBearingClaimRelevantBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportMainBearing", resetFKFields, new int[] { (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingClaimRelevantBooleanAnswerId } );		
			_booleanAnswer = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer(true, true);
			_booleanAnswer = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportMainBearingEntity.Relations.BooleanAnswerEntityUsingMainBearingClaimRelevantBooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _componentInspectionReport</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncComponentInspectionReport(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportMainBearingEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, signalRelatedEntity, "ComponentInspectionReportMainBearing", resetFKFields, new int[] { (int)ComponentInspectionReportMainBearingFieldIndex.ComponentInspectionReportId } );		
			_componentInspectionReport = null;
		}

		/// <summary> setups the sync logic for member _componentInspectionReport</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncComponentInspectionReport(IEntity2 relatedEntity)
		{
			DesetupSyncComponentInspectionReport(true, true);
			_componentInspectionReport = (ComponentInspectionReportEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportMainBearingEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnComponentInspectionReportPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _mainBearingErrorLocation</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMainBearingErrorLocation(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _mainBearingErrorLocation, new PropertyChangedEventHandler( OnMainBearingErrorLocationPropertyChanged ), "MainBearingErrorLocation", ComponentInspectionReportMainBearingEntity.Relations.MainBearingErrorLocationEntityUsingMainBearingErrorLocationId, true, signalRelatedEntity, "ComponentInspectionReportMainBearing", resetFKFields, new int[] { (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingErrorLocationId } );		
			_mainBearingErrorLocation = null;
		}

		/// <summary> setups the sync logic for member _mainBearingErrorLocation</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMainBearingErrorLocation(IEntity2 relatedEntity)
		{
			DesetupSyncMainBearingErrorLocation(true, true);
			_mainBearingErrorLocation = (MainBearingErrorLocationEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _mainBearingErrorLocation, new PropertyChangedEventHandler( OnMainBearingErrorLocationPropertyChanged ), "MainBearingErrorLocation", ComponentInspectionReportMainBearingEntity.Relations.MainBearingErrorLocationEntityUsingMainBearingErrorLocationId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _mainBearingManufacturer_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMainBearingManufacturer_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _mainBearingManufacturer_, new PropertyChangedEventHandler( OnMainBearingManufacturer_PropertyChanged ), "MainBearingManufacturer_", ComponentInspectionReportMainBearingEntity.Relations.MainBearingManufacturerEntityUsingMainBearingTypeId, true, signalRelatedEntity, "ComponentInspectionReportMainBearing_", resetFKFields, new int[] { (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingTypeId } );		
			_mainBearingManufacturer_ = null;
		}

		/// <summary> setups the sync logic for member _mainBearingManufacturer_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMainBearingManufacturer_(IEntity2 relatedEntity)
		{
			DesetupSyncMainBearingManufacturer_(true, true);
			_mainBearingManufacturer_ = (MainBearingManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _mainBearingManufacturer_, new PropertyChangedEventHandler( OnMainBearingManufacturer_PropertyChanged ), "MainBearingManufacturer_", ComponentInspectionReportMainBearingEntity.Relations.MainBearingManufacturerEntityUsingMainBearingTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMainBearingManufacturer_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _mainBearingManufacturer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMainBearingManufacturer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _mainBearingManufacturer, new PropertyChangedEventHandler( OnMainBearingManufacturerPropertyChanged ), "MainBearingManufacturer", ComponentInspectionReportMainBearingEntity.Relations.MainBearingManufacturerEntityUsingMainBearingManufacturerId, true, signalRelatedEntity, "ComponentInspectionReportMainBearing", resetFKFields, new int[] { (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingManufacturerId } );		
			_mainBearingManufacturer = null;
		}

		/// <summary> setups the sync logic for member _mainBearingManufacturer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMainBearingManufacturer(IEntity2 relatedEntity)
		{
			DesetupSyncMainBearingManufacturer(true, true);
			_mainBearingManufacturer = (MainBearingManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _mainBearingManufacturer, new PropertyChangedEventHandler( OnMainBearingManufacturerPropertyChanged ), "MainBearingManufacturer", ComponentInspectionReportMainBearingEntity.Relations.MainBearingManufacturerEntityUsingMainBearingManufacturerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMainBearingManufacturerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _oilType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOilType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _oilType, new PropertyChangedEventHandler( OnOilTypePropertyChanged ), "OilType", ComponentInspectionReportMainBearingEntity.Relations.OilTypeEntityUsingMainBearingLubricationOilTypeId, true, signalRelatedEntity, "ComponentInspectionReportMainBearing", resetFKFields, new int[] { (int)ComponentInspectionReportMainBearingFieldIndex.MainBearingLubricationOilTypeId } );		
			_oilType = null;
		}

		/// <summary> setups the sync logic for member _oilType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOilType(IEntity2 relatedEntity)
		{
			DesetupSyncOilType(true, true);
			_oilType = (OilTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _oilType, new PropertyChangedEventHandler( OnOilTypePropertyChanged ), "OilType", ComponentInspectionReportMainBearingEntity.Relations.OilTypeEntityUsingMainBearingLubricationOilTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOilTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ComponentInspectionReportMainBearingEntity</param>
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
		public  static ComponentInspectionReportMainBearingRelations Relations
		{
			get	{ return new ComponentInspectionReportMainBearingRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportMainBearingEntity.Relations.BooleanAnswerEntityUsingMainBearingClaimRelevantBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReport
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),
					ComponentInspectionReportMainBearingEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportMainBearingEntity.Relations.MainBearingErrorLocationEntityUsingMainBearingErrorLocationId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity, (int)Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity, 0, null, null, null, null, "MainBearingErrorLocation", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MainBearingManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMainBearingManufacturer_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingManufacturerEntityFactory))),
					ComponentInspectionReportMainBearingEntity.Relations.MainBearingManufacturerEntityUsingMainBearingTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity, (int)Cir.Data.LLBLGen.EntityType.MainBearingManufacturerEntity, 0, null, null, null, null, "MainBearingManufacturer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MainBearingManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMainBearingManufacturer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MainBearingManufacturerEntityFactory))),
					ComponentInspectionReportMainBearingEntity.Relations.MainBearingManufacturerEntityUsingMainBearingManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity, (int)Cir.Data.LLBLGen.EntityType.MainBearingManufacturerEntity, 0, null, null, null, null, "MainBearingManufacturer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OilType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOilType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OilTypeEntityFactory))),
					ComponentInspectionReportMainBearingEntity.Relations.OilTypeEntityUsingMainBearingLubricationOilTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity, (int)Cir.Data.LLBLGen.EntityType.OilTypeEntity, 0, null, null, null, null, "OilType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ComponentInspectionReportMainBearingEntity.CustomProperties;}
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
			get { return ComponentInspectionReportMainBearingEntity.FieldsCustomProperties;}
		}

		/// <summary> The ComponentInspectionReportMainBearingId property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."ComponentInspectionReportMainBearingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ComponentInspectionReportMainBearingId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.ComponentInspectionReportMainBearingId, true); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.ComponentInspectionReportMainBearingId, value); }
		}

		/// <summary> The ComponentInspectionReportId property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."ComponentInspectionReportId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.ComponentInspectionReportId, true); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.ComponentInspectionReportId, value); }
		}

		/// <summary> The VestasUniqueIdentifier property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."VestasUniqueIdentifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String VestasUniqueIdentifier
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.VestasUniqueIdentifier, true); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.VestasUniqueIdentifier, value); }
		}

		/// <summary> The MainBearingLastLubricationDate property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingLastLubricationDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime MainBearingLastLubricationDate
		{
			get { return (System.DateTime)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingLastLubricationDate, true); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingLastLubricationDate, value); }
		}

		/// <summary> The MainBearingManufacturerId property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MainBearingManufacturerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingManufacturerId, false); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingManufacturerId, value); }
		}

		/// <summary> The MainBearingTemperature property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingTemperature"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MainBearingTemperature
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingTemperature, false); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingTemperature, value); }
		}

		/// <summary> The MainBearingLubricationOilTypeId property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingLubricationOilTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MainBearingLubricationOilTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingLubricationOilTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingLubricationOilTypeId, value); }
		}

		/// <summary> The MainBearingGrease property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingGrease"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean MainBearingGrease
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingGrease, true); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingGrease, value); }
		}

		/// <summary> The MainBearingLubricationRunHours property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingLubricationRunHours"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 MainBearingLubricationRunHours
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingLubricationRunHours, true); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingLubricationRunHours, value); }
		}

		/// <summary> The MainBearingOilTemperature property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingOilTemperature"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MainBearingOilTemperature
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingOilTemperature, false); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingOilTemperature, value); }
		}

		/// <summary> The MainBearingTypeId property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MainBearingTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingTypeId, value); }
		}

		/// <summary> The MainBearingRevision property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingRevision"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MainBearingRevision
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingRevision, false); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingRevision, value); }
		}

		/// <summary> The MainBearingErrorLocationId property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingErrorLocationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MainBearingErrorLocationId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingErrorLocationId, false); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingErrorLocationId, value); }
		}

		/// <summary> The MainBearingSerialNumber property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingSerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MainBearingSerialNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingSerialNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingSerialNumber, value); }
		}

		/// <summary> The MainBearingRunHours property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingRunHours"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MainBearingRunHours
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingRunHours, false); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingRunHours, value); }
		}

		/// <summary> The MainBearingMechanicalOilPump property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingMechanicalOilPump"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String MainBearingMechanicalOilPump
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingMechanicalOilPump, true); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingMechanicalOilPump, value); }
		}

		/// <summary> The MainBearingClaimRelevantBooleanAnswerId property of the Entity ComponentInspectionReportMainBearing<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportMainBearing"."MainBearingClaimRelevantBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> MainBearingClaimRelevantBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingClaimRelevantBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportMainBearingFieldIndex.MainBearingClaimRelevantBooleanAnswerId, value); }
		}



		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer
		{
			get
			{
				return _booleanAnswer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer != null)
						{
							_booleanAnswer.UnsetRelatedEntity(this, "ComponentInspectionReportMainBearing");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportMainBearing");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ComponentInspectionReportEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ComponentInspectionReportEntity ComponentInspectionReport
		{
			get
			{
				return _componentInspectionReport;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncComponentInspectionReport(value);
				}
				else
				{
					if(value==null)
					{
						if(_componentInspectionReport != null)
						{
							_componentInspectionReport.UnsetRelatedEntity(this, "ComponentInspectionReportMainBearing");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportMainBearing");
					}
				}
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
							_mainBearingErrorLocation.UnsetRelatedEntity(this, "ComponentInspectionReportMainBearing");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportMainBearing");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MainBearingManufacturerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MainBearingManufacturerEntity MainBearingManufacturer_
		{
			get
			{
				return _mainBearingManufacturer_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMainBearingManufacturer_(value);
				}
				else
				{
					if(value==null)
					{
						if(_mainBearingManufacturer_ != null)
						{
							_mainBearingManufacturer_.UnsetRelatedEntity(this, "ComponentInspectionReportMainBearing_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportMainBearing_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MainBearingManufacturerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MainBearingManufacturerEntity MainBearingManufacturer
		{
			get
			{
				return _mainBearingManufacturer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMainBearingManufacturer(value);
				}
				else
				{
					if(value==null)
					{
						if(_mainBearingManufacturer != null)
						{
							_mainBearingManufacturer.UnsetRelatedEntity(this, "ComponentInspectionReportMainBearing");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportMainBearing");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OilTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OilTypeEntity OilType
		{
			get
			{
				return _oilType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOilType(value);
				}
				else
				{
					if(value==null)
					{
						if(_oilType != null)
						{
							_oilType.UnsetRelatedEntity(this, "ComponentInspectionReportMainBearing");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportMainBearing");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity; }
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
