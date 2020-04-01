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
	/// Entity class which represents the entity 'CirData'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class CirDataEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<CirCommentHistoryEntity> _cirCommentHistory;
		private EntityCollection<CirMetadataEntity> _cirMetadata;
		private EntityCollection<CirMetadataLookupEntity> _cirMetadataLookup;
		private EntityCollection<CirXmlEntity> _cirXml;
		private EntityCollection<FirstNotificationEntity> _firstNotification;
		private EntityCollection<SecondNotificationEntity> _secondNotification;
		private EntityCollection<CountryIsoEntity> _countryIsoCollectionViaFirstNotification;
		private EntityCollection<SbuEntity> _sbuCollectionViaSecondNotification;
		private EntityCollection<SbuEntity> _sbuCollectionViaFirstNotification;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{

			/// <summary>Member name CirCommentHistory</summary>
			public static readonly string CirCommentHistory = "CirCommentHistory";
			/// <summary>Member name CirMetadata</summary>
			public static readonly string CirMetadata = "CirMetadata";
			/// <summary>Member name CirMetadataLookup</summary>
			public static readonly string CirMetadataLookup = "CirMetadataLookup";
			/// <summary>Member name CirXml</summary>
			public static readonly string CirXml = "CirXml";
			/// <summary>Member name FirstNotification</summary>
			public static readonly string FirstNotification = "FirstNotification";
			/// <summary>Member name SecondNotification</summary>
			public static readonly string SecondNotification = "SecondNotification";
			/// <summary>Member name CountryIsoCollectionViaFirstNotification</summary>
			public static readonly string CountryIsoCollectionViaFirstNotification = "CountryIsoCollectionViaFirstNotification";
			/// <summary>Member name SbuCollectionViaSecondNotification</summary>
			public static readonly string SbuCollectionViaSecondNotification = "SbuCollectionViaSecondNotification";
			/// <summary>Member name SbuCollectionViaFirstNotification</summary>
			public static readonly string SbuCollectionViaFirstNotification = "SbuCollectionViaFirstNotification";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static CirDataEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public CirDataEntity():base("CirDataEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public CirDataEntity(IEntityFields2 fields):base("CirDataEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this CirDataEntity</param>
		public CirDataEntity(IValidator validator):base("CirDataEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="cirDataId">PK value for CirData which data should be fetched into this CirData object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CirDataEntity(System.Int64 cirDataId):base("CirDataEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.CirDataId = cirDataId;
		}

		/// <summary> CTor</summary>
		/// <param name="cirDataId">PK value for CirData which data should be fetched into this CirData object</param>
		/// <param name="validator">The custom validator object for this CirDataEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public CirDataEntity(System.Int64 cirDataId, IValidator validator):base("CirDataEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.CirDataId = cirDataId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected CirDataEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_cirCommentHistory = (EntityCollection<CirCommentHistoryEntity>)info.GetValue("_cirCommentHistory", typeof(EntityCollection<CirCommentHistoryEntity>));
				_cirMetadata = (EntityCollection<CirMetadataEntity>)info.GetValue("_cirMetadata", typeof(EntityCollection<CirMetadataEntity>));
				_cirMetadataLookup = (EntityCollection<CirMetadataLookupEntity>)info.GetValue("_cirMetadataLookup", typeof(EntityCollection<CirMetadataLookupEntity>));
				_cirXml = (EntityCollection<CirXmlEntity>)info.GetValue("_cirXml", typeof(EntityCollection<CirXmlEntity>));
				_firstNotification = (EntityCollection<FirstNotificationEntity>)info.GetValue("_firstNotification", typeof(EntityCollection<FirstNotificationEntity>));
				_secondNotification = (EntityCollection<SecondNotificationEntity>)info.GetValue("_secondNotification", typeof(EntityCollection<SecondNotificationEntity>));
				_countryIsoCollectionViaFirstNotification = (EntityCollection<CountryIsoEntity>)info.GetValue("_countryIsoCollectionViaFirstNotification", typeof(EntityCollection<CountryIsoEntity>));
				_sbuCollectionViaSecondNotification = (EntityCollection<SbuEntity>)info.GetValue("_sbuCollectionViaSecondNotification", typeof(EntityCollection<SbuEntity>));
				_sbuCollectionViaFirstNotification = (EntityCollection<SbuEntity>)info.GetValue("_sbuCollectionViaFirstNotification", typeof(EntityCollection<SbuEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((CirDataFieldIndex)fieldIndex)
			{
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

				case "CirCommentHistory":
					this.CirCommentHistory.Add((CirCommentHistoryEntity)entity);
					break;
				case "CirMetadata":
					this.CirMetadata.Add((CirMetadataEntity)entity);
					break;
				case "CirMetadataLookup":
					this.CirMetadataLookup.Add((CirMetadataLookupEntity)entity);
					break;
				case "CirXml":
					this.CirXml.Add((CirXmlEntity)entity);
					break;
				case "FirstNotification":
					this.FirstNotification.Add((FirstNotificationEntity)entity);
					break;
				case "SecondNotification":
					this.SecondNotification.Add((SecondNotificationEntity)entity);
					break;
				case "CountryIsoCollectionViaFirstNotification":
					this.CountryIsoCollectionViaFirstNotification.IsReadOnly = false;
					this.CountryIsoCollectionViaFirstNotification.Add((CountryIsoEntity)entity);
					this.CountryIsoCollectionViaFirstNotification.IsReadOnly = true;
					break;
				case "SbuCollectionViaSecondNotification":
					this.SbuCollectionViaSecondNotification.IsReadOnly = false;
					this.SbuCollectionViaSecondNotification.Add((SbuEntity)entity);
					this.SbuCollectionViaSecondNotification.IsReadOnly = true;
					break;
				case "SbuCollectionViaFirstNotification":
					this.SbuCollectionViaFirstNotification.IsReadOnly = false;
					this.SbuCollectionViaFirstNotification.Add((SbuEntity)entity);
					this.SbuCollectionViaFirstNotification.IsReadOnly = true;
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

				case "CirCommentHistory":
					this.CirCommentHistory.Add((CirCommentHistoryEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "CirMetadata":
					this.CirMetadata.Add((CirMetadataEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "CirMetadataLookup":
					this.CirMetadataLookup.Add((CirMetadataLookupEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "CirXml":
					this.CirXml.Add((CirXmlEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "FirstNotification":
					this.FirstNotification.Add((FirstNotificationEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "SecondNotification":
					this.SecondNotification.Add((SecondNotificationEntity)relatedEntity);
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

				case "CirCommentHistory":
					base.PerformRelatedEntityRemoval(this.CirCommentHistory, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "CirMetadata":
					base.PerformRelatedEntityRemoval(this.CirMetadata, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "CirMetadataLookup":
					base.PerformRelatedEntityRemoval(this.CirMetadataLookup, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "CirXml":
					base.PerformRelatedEntityRemoval(this.CirXml, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "FirstNotification":
					base.PerformRelatedEntityRemoval(this.FirstNotification, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "SecondNotification":
					base.PerformRelatedEntityRemoval(this.SecondNotification, relatedEntity, signalRelatedEntityManyToOne);
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


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.CirCommentHistory);
			toReturn.Add(this.CirMetadata);
			toReturn.Add(this.CirMetadataLookup);
			toReturn.Add(this.CirXml);
			toReturn.Add(this.FirstNotification);
			toReturn.Add(this.SecondNotification);

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
				info.AddValue("_cirCommentHistory", ((_cirCommentHistory!=null) && (_cirCommentHistory.Count>0) && !this.MarkedForDeletion)?_cirCommentHistory:null);
				info.AddValue("_cirMetadata", ((_cirMetadata!=null) && (_cirMetadata.Count>0) && !this.MarkedForDeletion)?_cirMetadata:null);
				info.AddValue("_cirMetadataLookup", ((_cirMetadataLookup!=null) && (_cirMetadataLookup.Count>0) && !this.MarkedForDeletion)?_cirMetadataLookup:null);
				info.AddValue("_cirXml", ((_cirXml!=null) && (_cirXml.Count>0) && !this.MarkedForDeletion)?_cirXml:null);
				info.AddValue("_firstNotification", ((_firstNotification!=null) && (_firstNotification.Count>0) && !this.MarkedForDeletion)?_firstNotification:null);
				info.AddValue("_secondNotification", ((_secondNotification!=null) && (_secondNotification.Count>0) && !this.MarkedForDeletion)?_secondNotification:null);
				info.AddValue("_countryIsoCollectionViaFirstNotification", ((_countryIsoCollectionViaFirstNotification!=null) && (_countryIsoCollectionViaFirstNotification.Count>0) && !this.MarkedForDeletion)?_countryIsoCollectionViaFirstNotification:null);
				info.AddValue("_sbuCollectionViaSecondNotification", ((_sbuCollectionViaSecondNotification!=null) && (_sbuCollectionViaSecondNotification.Count>0) && !this.MarkedForDeletion)?_sbuCollectionViaSecondNotification:null);
				info.AddValue("_sbuCollectionViaFirstNotification", ((_sbuCollectionViaFirstNotification!=null) && (_sbuCollectionViaFirstNotification.Count>0) && !this.MarkedForDeletion)?_sbuCollectionViaFirstNotification:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(CirDataFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(CirDataFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new CirDataRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CirCommentHistory' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCirCommentHistory()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CirCommentHistoryFields.CirDataId, null, ComparisonOperator.Equal, this.CirDataId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CirMetadata' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCirMetadata()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CirMetadataFields.CirDataId, null, ComparisonOperator.Equal, this.CirDataId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CirMetadataLookup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCirMetadataLookup()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CirMetadataLookupFields.CirDataId, null, ComparisonOperator.Equal, this.CirDataId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CirXml' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCirXml()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CirXmlFields.CirDataId, null, ComparisonOperator.Equal, this.CirDataId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FirstNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFirstNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FirstNotificationFields.CirDataId, null, ComparisonOperator.Equal, this.CirDataId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SecondNotification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSecondNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SecondNotificationFields.CirDataId, null, ComparisonOperator.Equal, this.CirDataId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CountryIso' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryIsoCollectionViaFirstNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CirDataEntity.Relations.FirstNotificationEntityUsingCirDataId, "CirDataEntity__", "FirstNotification_", JoinHint.None);
			bucket.Relations.Add(FirstNotificationEntity.Relations.CountryIsoEntityUsingCountryIsoid, "FirstNotification_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CirDataFields.CirDataId, null, ComparisonOperator.Equal, this.CirDataId, "CirDataEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Sbu' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSbuCollectionViaSecondNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CirDataEntity.Relations.SecondNotificationEntityUsingCirDataId, "CirDataEntity__", "SecondNotification_", JoinHint.None);
			bucket.Relations.Add(SecondNotificationEntity.Relations.SbuEntityUsingSbuid, "SecondNotification_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CirDataFields.CirDataId, null, ComparisonOperator.Equal, this.CirDataId, "CirDataEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Sbu' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSbuCollectionViaFirstNotification()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(CirDataEntity.Relations.FirstNotificationEntityUsingCirDataId, "CirDataEntity__", "FirstNotification_", JoinHint.None);
			bucket.Relations.Add(FirstNotificationEntity.Relations.SbuEntityUsingSbuid, "FirstNotification_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CirDataFields.CirDataId, null, ComparisonOperator.Equal, this.CirDataId, "CirDataEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.CirDataEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(CirDataEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._cirCommentHistory);
			collectionsQueue.Enqueue(this._cirMetadata);
			collectionsQueue.Enqueue(this._cirMetadataLookup);
			collectionsQueue.Enqueue(this._cirXml);
			collectionsQueue.Enqueue(this._firstNotification);
			collectionsQueue.Enqueue(this._secondNotification);
			collectionsQueue.Enqueue(this._countryIsoCollectionViaFirstNotification);
			collectionsQueue.Enqueue(this._sbuCollectionViaSecondNotification);
			collectionsQueue.Enqueue(this._sbuCollectionViaFirstNotification);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._cirCommentHistory = (EntityCollection<CirCommentHistoryEntity>) collectionsQueue.Dequeue();
			this._cirMetadata = (EntityCollection<CirMetadataEntity>) collectionsQueue.Dequeue();
			this._cirMetadataLookup = (EntityCollection<CirMetadataLookupEntity>) collectionsQueue.Dequeue();
			this._cirXml = (EntityCollection<CirXmlEntity>) collectionsQueue.Dequeue();
			this._firstNotification = (EntityCollection<FirstNotificationEntity>) collectionsQueue.Dequeue();
			this._secondNotification = (EntityCollection<SecondNotificationEntity>) collectionsQueue.Dequeue();
			this._countryIsoCollectionViaFirstNotification = (EntityCollection<CountryIsoEntity>) collectionsQueue.Dequeue();
			this._sbuCollectionViaSecondNotification = (EntityCollection<SbuEntity>) collectionsQueue.Dequeue();
			this._sbuCollectionViaFirstNotification = (EntityCollection<SbuEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._cirCommentHistory != null)
			{
				return true;
			}
			if (this._cirMetadata != null)
			{
				return true;
			}
			if (this._cirMetadataLookup != null)
			{
				return true;
			}
			if (this._cirXml != null)
			{
				return true;
			}
			if (this._firstNotification != null)
			{
				return true;
			}
			if (this._secondNotification != null)
			{
				return true;
			}
			if (this._countryIsoCollectionViaFirstNotification != null)
			{
				return true;
			}
			if (this._sbuCollectionViaSecondNotification != null)
			{
				return true;
			}
			if (this._sbuCollectionViaFirstNotification != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CirCommentHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirCommentHistoryEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CirMetadataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirMetadataEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CirMetadataLookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirMetadataLookupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CirXmlEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirXmlEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FirstNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FirstNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SecondNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SecondNotificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("CirCommentHistory", _cirCommentHistory);
			toReturn.Add("CirMetadata", _cirMetadata);
			toReturn.Add("CirMetadataLookup", _cirMetadataLookup);
			toReturn.Add("CirXml", _cirXml);
			toReturn.Add("FirstNotification", _firstNotification);
			toReturn.Add("SecondNotification", _secondNotification);
			toReturn.Add("CountryIsoCollectionViaFirstNotification", _countryIsoCollectionViaFirstNotification);
			toReturn.Add("SbuCollectionViaSecondNotification", _sbuCollectionViaSecondNotification);
			toReturn.Add("SbuCollectionViaFirstNotification", _sbuCollectionViaFirstNotification);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_cirCommentHistory!=null)
			{
				_cirCommentHistory.ActiveContext = base.ActiveContext;
			}
			if(_cirMetadata!=null)
			{
				_cirMetadata.ActiveContext = base.ActiveContext;
			}
			if(_cirMetadataLookup!=null)
			{
				_cirMetadataLookup.ActiveContext = base.ActiveContext;
			}
			if(_cirXml!=null)
			{
				_cirXml.ActiveContext = base.ActiveContext;
			}
			if(_firstNotification!=null)
			{
				_firstNotification.ActiveContext = base.ActiveContext;
			}
			if(_secondNotification!=null)
			{
				_secondNotification.ActiveContext = base.ActiveContext;
			}
			if(_countryIsoCollectionViaFirstNotification!=null)
			{
				_countryIsoCollectionViaFirstNotification.ActiveContext = base.ActiveContext;
			}
			if(_sbuCollectionViaSecondNotification!=null)
			{
				_sbuCollectionViaSecondNotification.ActiveContext = base.ActiveContext;
			}
			if(_sbuCollectionViaFirstNotification!=null)
			{
				_sbuCollectionViaFirstNotification.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_cirCommentHistory = null;
			_cirMetadata = null;
			_cirMetadataLookup = null;
			_cirXml = null;
			_firstNotification = null;
			_secondNotification = null;
			_countryIsoCollectionViaFirstNotification = null;
			_sbuCollectionViaSecondNotification = null;
			_sbuCollectionViaFirstNotification = null;


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

			_fieldsCustomProperties.Add("CirDataId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CirId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Guid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("State", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Progress", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Created", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Filename", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Modified", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ModifiedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Deleted", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this CirDataEntity</param>
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
		public  static CirDataRelations Relations
		{
			get	{ return new CirDataRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CirCommentHistory' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCirCommentHistory
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CirCommentHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirCommentHistoryEntityFactory))),
					CirDataEntity.Relations.CirCommentHistoryEntityUsingCirDataId, 
					(int)Cir.Data.LLBLGen.EntityType.CirDataEntity, (int)Cir.Data.LLBLGen.EntityType.CirCommentHistoryEntity, 0, null, null, null, null, "CirCommentHistory", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CirMetadata' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCirMetadata
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CirMetadataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirMetadataEntityFactory))),
					CirDataEntity.Relations.CirMetadataEntityUsingCirDataId, 
					(int)Cir.Data.LLBLGen.EntityType.CirDataEntity, (int)Cir.Data.LLBLGen.EntityType.CirMetadataEntity, 0, null, null, null, null, "CirMetadata", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CirMetadataLookup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCirMetadataLookup
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CirMetadataLookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirMetadataLookupEntityFactory))),
					CirDataEntity.Relations.CirMetadataLookupEntityUsingCirDataId, 
					(int)Cir.Data.LLBLGen.EntityType.CirDataEntity, (int)Cir.Data.LLBLGen.EntityType.CirMetadataLookupEntity, 0, null, null, null, null, "CirMetadataLookup", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CirXml' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCirXml
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<CirXmlEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirXmlEntityFactory))),
					CirDataEntity.Relations.CirXmlEntityUsingCirDataId, 
					(int)Cir.Data.LLBLGen.EntityType.CirDataEntity, (int)Cir.Data.LLBLGen.EntityType.CirXmlEntity, 0, null, null, null, null, "CirXml", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					CirDataEntity.Relations.FirstNotificationEntityUsingCirDataId, 
					(int)Cir.Data.LLBLGen.EntityType.CirDataEntity, (int)Cir.Data.LLBLGen.EntityType.FirstNotificationEntity, 0, null, null, null, null, "FirstNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SecondNotification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSecondNotification
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SecondNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SecondNotificationEntityFactory))),
					CirDataEntity.Relations.SecondNotificationEntityUsingCirDataId, 
					(int)Cir.Data.LLBLGen.EntityType.CirDataEntity, (int)Cir.Data.LLBLGen.EntityType.SecondNotificationEntity, 0, null, null, null, null, "SecondNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CountryIso' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountryIsoCollectionViaFirstNotification
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = CirDataEntity.Relations.FirstNotificationEntityUsingCirDataId;
				intermediateRelation.SetAliases(string.Empty, "FirstNotification_");
				relations.Add(CirDataEntity.Relations.FirstNotificationEntityUsingCirDataId, "CirDataEntity__", "FirstNotification_", JoinHint.None);
				relations.Add(FirstNotificationEntity.Relations.CountryIsoEntityUsingCountryIsoid, "FirstNotification_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CirDataEntity, (int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, 0, null, null, relations, null, "CountryIsoCollectionViaFirstNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Sbu' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSbuCollectionViaSecondNotification
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = CirDataEntity.Relations.SecondNotificationEntityUsingCirDataId;
				intermediateRelation.SetAliases(string.Empty, "SecondNotification_");
				relations.Add(CirDataEntity.Relations.SecondNotificationEntityUsingCirDataId, "CirDataEntity__", "SecondNotification_", JoinHint.None);
				relations.Add(SecondNotificationEntity.Relations.SbuEntityUsingSbuid, "SecondNotification_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CirDataEntity, (int)Cir.Data.LLBLGen.EntityType.SbuEntity, 0, null, null, relations, null, "SbuCollectionViaSecondNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = CirDataEntity.Relations.FirstNotificationEntityUsingCirDataId;
				intermediateRelation.SetAliases(string.Empty, "FirstNotification_");
				relations.Add(CirDataEntity.Relations.FirstNotificationEntityUsingCirDataId, "CirDataEntity__", "FirstNotification_", JoinHint.None);
				relations.Add(FirstNotificationEntity.Relations.SbuEntityUsingSbuid, "FirstNotification_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.CirDataEntity, (int)Cir.Data.LLBLGen.EntityType.SbuEntity, 0, null, null, relations, null, "SbuCollectionViaFirstNotification", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return CirDataEntity.CustomProperties;}
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
			get { return CirDataEntity.FieldsCustomProperties;}
		}

		/// <summary> The CirDataId property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."CirDataId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 CirDataId
		{
			get { return (System.Int64)GetValue((int)CirDataFieldIndex.CirDataId, true); }
			set	{ SetValue((int)CirDataFieldIndex.CirDataId, value); }
		}

		/// <summary> The CirId property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."CirId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CirId
		{
			get { return (System.Int64)GetValue((int)CirDataFieldIndex.CirId, true); }
			set	{ SetValue((int)CirDataFieldIndex.CirId, value); }
		}

		/// <summary> The Guid property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."Guid"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Guid
		{
			get { return (System.String)GetValue((int)CirDataFieldIndex.Guid, true); }
			set	{ SetValue((int)CirDataFieldIndex.Guid, value); }
		}

		/// <summary> The State property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."State"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte State
		{
			get { return (System.Byte)GetValue((int)CirDataFieldIndex.State, true); }
			set	{ SetValue((int)CirDataFieldIndex.State, value); }
		}

		/// <summary> The Progress property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."Progress"<br/>
		/// Table field type characteristics (type, precision, scale, length): TinyInt, 3, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Byte Progress
		{
			get { return (System.Byte)GetValue((int)CirDataFieldIndex.Progress, true); }
			set	{ SetValue((int)CirDataFieldIndex.Progress, value); }
		}

		/// <summary> The Email property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."Email"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 256<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)CirDataFieldIndex.Email, true); }
			set	{ SetValue((int)CirDataFieldIndex.Email, value); }
		}

		/// <summary> The CreatedBy property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CreatedBy
		{
			get { return (System.String)GetValue((int)CirDataFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)CirDataFieldIndex.CreatedBy, value); }
		}

		/// <summary> The Created property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."Created"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime Created
		{
			get { return (System.DateTime)GetValue((int)CirDataFieldIndex.Created, true); }
			set	{ SetValue((int)CirDataFieldIndex.Created, value); }
		}

		/// <summary> The Filename property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."Filename"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 256<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Filename
		{
			get { return (System.String)GetValue((int)CirDataFieldIndex.Filename, true); }
			set	{ SetValue((int)CirDataFieldIndex.Filename, value); }
		}

		/// <summary> The Modified property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."Modified"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime Modified
		{
			get { return (System.DateTime)GetValue((int)CirDataFieldIndex.Modified, true); }
			set	{ SetValue((int)CirDataFieldIndex.Modified, value); }
		}

		/// <summary> The ModifiedBy property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."ModifiedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ModifiedBy
		{
			get { return (System.String)GetValue((int)CirDataFieldIndex.ModifiedBy, true); }
			set	{ SetValue((int)CirDataFieldIndex.ModifiedBy, value); }
		}

		/// <summary> The Deleted property of the Entity CirData<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "CirData"."Deleted"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean Deleted
		{
			get { return (System.Boolean)GetValue((int)CirDataFieldIndex.Deleted, true); }
			set	{ SetValue((int)CirDataFieldIndex.Deleted, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CirCommentHistoryEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CirCommentHistoryEntity))]
		public virtual EntityCollection<CirCommentHistoryEntity> CirCommentHistory
		{
			get
			{
				if(_cirCommentHistory==null)
				{
					_cirCommentHistory = new EntityCollection<CirCommentHistoryEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirCommentHistoryEntityFactory)));
					_cirCommentHistory.SetContainingEntityInfo(this, "CirData");
				}
				return _cirCommentHistory;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CirMetadataEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CirMetadataEntity))]
		public virtual EntityCollection<CirMetadataEntity> CirMetadata
		{
			get
			{
				if(_cirMetadata==null)
				{
					_cirMetadata = new EntityCollection<CirMetadataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirMetadataEntityFactory)));
					_cirMetadata.SetContainingEntityInfo(this, "CirData");
				}
				return _cirMetadata;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CirMetadataLookupEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CirMetadataLookupEntity))]
		public virtual EntityCollection<CirMetadataLookupEntity> CirMetadataLookup
		{
			get
			{
				if(_cirMetadataLookup==null)
				{
					_cirMetadataLookup = new EntityCollection<CirMetadataLookupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirMetadataLookupEntityFactory)));
					_cirMetadataLookup.SetContainingEntityInfo(this, "CirData");
				}
				return _cirMetadataLookup;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CirXmlEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CirXmlEntity))]
		public virtual EntityCollection<CirXmlEntity> CirXml
		{
			get
			{
				if(_cirXml==null)
				{
					_cirXml = new EntityCollection<CirXmlEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CirXmlEntityFactory)));
					_cirXml.SetContainingEntityInfo(this, "CirData");
				}
				return _cirXml;
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
					_firstNotification.SetContainingEntityInfo(this, "CirData");
				}
				return _firstNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SecondNotificationEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SecondNotificationEntity))]
		public virtual EntityCollection<SecondNotificationEntity> SecondNotification
		{
			get
			{
				if(_secondNotification==null)
				{
					_secondNotification = new EntityCollection<SecondNotificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SecondNotificationEntityFactory)));
					_secondNotification.SetContainingEntityInfo(this, "CirData");
				}
				return _secondNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CountryIsoEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CountryIsoEntity))]
		public virtual EntityCollection<CountryIsoEntity> CountryIsoCollectionViaFirstNotification
		{
			get
			{
				if(_countryIsoCollectionViaFirstNotification==null)
				{
					_countryIsoCollectionViaFirstNotification = new EntityCollection<CountryIsoEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory)));
					_countryIsoCollectionViaFirstNotification.IsReadOnly=true;
				}
				return _countryIsoCollectionViaFirstNotification;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SbuEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SbuEntity))]
		public virtual EntityCollection<SbuEntity> SbuCollectionViaSecondNotification
		{
			get
			{
				if(_sbuCollectionViaSecondNotification==null)
				{
					_sbuCollectionViaSecondNotification = new EntityCollection<SbuEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory)));
					_sbuCollectionViaSecondNotification.IsReadOnly=true;
				}
				return _sbuCollectionViaSecondNotification;
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
			get { return (int)Cir.Data.LLBLGen.EntityType.CirDataEntity; }
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
