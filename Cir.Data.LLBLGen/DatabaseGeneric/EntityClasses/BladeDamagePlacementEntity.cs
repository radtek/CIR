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
	/// Entity class which represents the entity 'BladeDamagePlacement'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class BladeDamagePlacementEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<BladeDamagePlacementEntity> _bladeDamagePlacement_;
		private EntityCollection<ComponentInspectionReportBladeDamageEntity> _componentInspectionReportBladeDamage;
		private EntityCollection<BladeEdgeEntity> _bladeEdgeCollectionViaComponentInspectionReportBladeDamage;
		private EntityCollection<BladeInspectionDataEntity> _bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage;
		private EntityCollection<ComponentInspectionReportBladeEntity> _componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage;
		private BladeDamagePlacementEntity _bladeDamagePlacement;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name BladeDamagePlacement</summary>
			public static readonly string BladeDamagePlacement = "BladeDamagePlacement";
			/// <summary>Member name BladeDamagePlacement_</summary>
			public static readonly string BladeDamagePlacement_ = "BladeDamagePlacement_";
			/// <summary>Member name ComponentInspectionReportBladeDamage</summary>
			public static readonly string ComponentInspectionReportBladeDamage = "ComponentInspectionReportBladeDamage";
			/// <summary>Member name BladeEdgeCollectionViaComponentInspectionReportBladeDamage</summary>
			public static readonly string BladeEdgeCollectionViaComponentInspectionReportBladeDamage = "BladeEdgeCollectionViaComponentInspectionReportBladeDamage";
			/// <summary>Member name BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage</summary>
			public static readonly string BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage = "BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage";
			/// <summary>Member name ComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage</summary>
			public static readonly string ComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage = "ComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static BladeDamagePlacementEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public BladeDamagePlacementEntity():base("BladeDamagePlacementEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public BladeDamagePlacementEntity(IEntityFields2 fields):base("BladeDamagePlacementEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this BladeDamagePlacementEntity</param>
		public BladeDamagePlacementEntity(IValidator validator):base("BladeDamagePlacementEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="bladeDamagePlacementId">PK value for BladeDamagePlacement which data should be fetched into this BladeDamagePlacement object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public BladeDamagePlacementEntity(System.Int64 bladeDamagePlacementId):base("BladeDamagePlacementEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.BladeDamagePlacementId = bladeDamagePlacementId;
		}

		/// <summary> CTor</summary>
		/// <param name="bladeDamagePlacementId">PK value for BladeDamagePlacement which data should be fetched into this BladeDamagePlacement object</param>
		/// <param name="validator">The custom validator object for this BladeDamagePlacementEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public BladeDamagePlacementEntity(System.Int64 bladeDamagePlacementId, IValidator validator):base("BladeDamagePlacementEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.BladeDamagePlacementId = bladeDamagePlacementId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected BladeDamagePlacementEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_bladeDamagePlacement_ = (EntityCollection<BladeDamagePlacementEntity>)info.GetValue("_bladeDamagePlacement_", typeof(EntityCollection<BladeDamagePlacementEntity>));
				_componentInspectionReportBladeDamage = (EntityCollection<ComponentInspectionReportBladeDamageEntity>)info.GetValue("_componentInspectionReportBladeDamage", typeof(EntityCollection<ComponentInspectionReportBladeDamageEntity>));
				_bladeEdgeCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<BladeEdgeEntity>)info.GetValue("_bladeEdgeCollectionViaComponentInspectionReportBladeDamage", typeof(EntityCollection<BladeEdgeEntity>));
				_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<BladeInspectionDataEntity>)info.GetValue("_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage", typeof(EntityCollection<BladeInspectionDataEntity>));
				_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<ComponentInspectionReportBladeEntity>)info.GetValue("_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage", typeof(EntityCollection<ComponentInspectionReportBladeEntity>));
				_bladeDamagePlacement = (BladeDamagePlacementEntity)info.GetValue("_bladeDamagePlacement", typeof(BladeDamagePlacementEntity));
				if(_bladeDamagePlacement!=null)
				{
					_bladeDamagePlacement.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((BladeDamagePlacementFieldIndex)fieldIndex)
			{
				case BladeDamagePlacementFieldIndex.ParentBladeDamagePlacementId:
					DesetupSyncBladeDamagePlacement(true, false);
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
				case "BladeDamagePlacement":
					this.BladeDamagePlacement = (BladeDamagePlacementEntity)entity;
					break;
				case "BladeDamagePlacement_":
					this.BladeDamagePlacement_.Add((BladeDamagePlacementEntity)entity);
					break;
				case "ComponentInspectionReportBladeDamage":
					this.ComponentInspectionReportBladeDamage.Add((ComponentInspectionReportBladeDamageEntity)entity);
					break;
				case "BladeEdgeCollectionViaComponentInspectionReportBladeDamage":
					this.BladeEdgeCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = false;
					this.BladeEdgeCollectionViaComponentInspectionReportBladeDamage.Add((BladeEdgeEntity)entity);
					this.BladeEdgeCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = true;
					break;
				case "BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage":
					this.BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = false;
					this.BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.Add((BladeInspectionDataEntity)entity);
					this.BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = true;
					break;
				case "ComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage":
					this.ComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = false;
					this.ComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage.Add((ComponentInspectionReportBladeEntity)entity);
					this.ComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage.IsReadOnly = true;
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
				case "BladeDamagePlacement":
					SetupSyncBladeDamagePlacement(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BladeDamagePlacement_":
					this.BladeDamagePlacement_.Add((BladeDamagePlacementEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportBladeDamage":
					this.ComponentInspectionReportBladeDamage.Add((ComponentInspectionReportBladeDamageEntity)relatedEntity);
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
				case "BladeDamagePlacement":
					DesetupSyncBladeDamagePlacement(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BladeDamagePlacement_":
					base.PerformRelatedEntityRemoval(this.BladeDamagePlacement_, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportBladeDamage":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportBladeDamage, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_bladeDamagePlacement!=null)
			{
				toReturn.Add(_bladeDamagePlacement);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.BladeDamagePlacement_);
			toReturn.Add(this.ComponentInspectionReportBladeDamage);

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
				info.AddValue("_bladeDamagePlacement_", ((_bladeDamagePlacement_!=null) && (_bladeDamagePlacement_.Count>0) && !this.MarkedForDeletion)?_bladeDamagePlacement_:null);
				info.AddValue("_componentInspectionReportBladeDamage", ((_componentInspectionReportBladeDamage!=null) && (_componentInspectionReportBladeDamage.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportBladeDamage:null);
				info.AddValue("_bladeEdgeCollectionViaComponentInspectionReportBladeDamage", ((_bladeEdgeCollectionViaComponentInspectionReportBladeDamage!=null) && (_bladeEdgeCollectionViaComponentInspectionReportBladeDamage.Count>0) && !this.MarkedForDeletion)?_bladeEdgeCollectionViaComponentInspectionReportBladeDamage:null);
				info.AddValue("_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage", ((_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage!=null) && (_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.Count>0) && !this.MarkedForDeletion)?_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage:null);
				info.AddValue("_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage", ((_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage!=null) && (_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage:null);
				info.AddValue("_bladeDamagePlacement", (!this.MarkedForDeletion?_bladeDamagePlacement:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(BladeDamagePlacementFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(BladeDamagePlacementFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new BladeDamagePlacementRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BladeDamagePlacement' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeDamagePlacement_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeDamagePlacementFields.ParentBladeDamagePlacementId, null, ComparisonOperator.Equal, this.BladeDamagePlacementId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportBladeDamage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportBladeDamage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportBladeDamageFields.BladeDamagePlacementId, null, ComparisonOperator.Equal, this.BladeDamagePlacementId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BladeEdge' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeEdgeCollectionViaComponentInspectionReportBladeDamage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(BladeDamagePlacementEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId, "BladeDamagePlacementEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.BladeEdgeEntityUsingBladeEdgeId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeDamagePlacementFields.BladeDamagePlacementId, null, ComparisonOperator.Equal, this.BladeDamagePlacementId, "BladeDamagePlacementEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BladeInspectionData' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeInspectionDataCollectionViaComponentInspectionReportBladeDamage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(BladeDamagePlacementEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId, "BladeDamagePlacementEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.BladeInspectionDataEntityUsingBladeInspectionDataId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeDamagePlacementFields.BladeDamagePlacementId, null, ComparisonOperator.Equal, this.BladeDamagePlacementId, "BladeDamagePlacementEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportBlade' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(BladeDamagePlacementEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId, "BladeDamagePlacementEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.ComponentInspectionReportBladeEntityUsingComponentInspectionReportBladeId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeDamagePlacementFields.BladeDamagePlacementId, null, ComparisonOperator.Equal, this.BladeDamagePlacementId, "BladeDamagePlacementEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BladeDamagePlacement' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeDamagePlacement()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeDamagePlacementFields.BladeDamagePlacementId, null, ComparisonOperator.Equal, this.ParentBladeDamagePlacementId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(BladeDamagePlacementEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._bladeDamagePlacement_);
			collectionsQueue.Enqueue(this._componentInspectionReportBladeDamage);
			collectionsQueue.Enqueue(this._bladeEdgeCollectionViaComponentInspectionReportBladeDamage);
			collectionsQueue.Enqueue(this._bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage);
			collectionsQueue.Enqueue(this._componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._bladeDamagePlacement_ = (EntityCollection<BladeDamagePlacementEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportBladeDamage = (EntityCollection<ComponentInspectionReportBladeDamageEntity>) collectionsQueue.Dequeue();
			this._bladeEdgeCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<BladeEdgeEntity>) collectionsQueue.Dequeue();
			this._bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<BladeInspectionDataEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage = (EntityCollection<ComponentInspectionReportBladeEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._bladeDamagePlacement_ != null)
			{
				return true;
			}
			if (this._componentInspectionReportBladeDamage != null)
			{
				return true;
			}
			if (this._bladeEdgeCollectionViaComponentInspectionReportBladeDamage != null)
			{
				return true;
			}
			if (this._bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage != null)
			{
				return true;
			}
			if (this._componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BladeDamagePlacementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeDamagePlacementEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportBladeDamageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeDamageEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BladeEdgeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeEdgeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BladeInspectionDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeInspectionDataEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportBladeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("BladeDamagePlacement", _bladeDamagePlacement);
			toReturn.Add("BladeDamagePlacement_", _bladeDamagePlacement_);
			toReturn.Add("ComponentInspectionReportBladeDamage", _componentInspectionReportBladeDamage);
			toReturn.Add("BladeEdgeCollectionViaComponentInspectionReportBladeDamage", _bladeEdgeCollectionViaComponentInspectionReportBladeDamage);
			toReturn.Add("BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage", _bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage);
			toReturn.Add("ComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage", _componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_bladeDamagePlacement_!=null)
			{
				_bladeDamagePlacement_.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportBladeDamage!=null)
			{
				_componentInspectionReportBladeDamage.ActiveContext = base.ActiveContext;
			}
			if(_bladeEdgeCollectionViaComponentInspectionReportBladeDamage!=null)
			{
				_bladeEdgeCollectionViaComponentInspectionReportBladeDamage.ActiveContext = base.ActiveContext;
			}
			if(_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage!=null)
			{
				_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage!=null)
			{
				_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage.ActiveContext = base.ActiveContext;
			}
			if(_bladeDamagePlacement!=null)
			{
				_bladeDamagePlacement.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_bladeDamagePlacement_ = null;
			_componentInspectionReportBladeDamage = null;
			_bladeEdgeCollectionViaComponentInspectionReportBladeDamage = null;
			_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage = null;
			_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage = null;
			_bladeDamagePlacement = null;

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

			_fieldsCustomProperties.Add("BladeDamagePlacementId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentBladeDamagePlacementId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _bladeDamagePlacement</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBladeDamagePlacement(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bladeDamagePlacement, new PropertyChangedEventHandler( OnBladeDamagePlacementPropertyChanged ), "BladeDamagePlacement", BladeDamagePlacementEntity.Relations.BladeDamagePlacementEntityUsingBladeDamagePlacementIdParentBladeDamagePlacementId, true, signalRelatedEntity, "BladeDamagePlacement_", resetFKFields, new int[] { (int)BladeDamagePlacementFieldIndex.ParentBladeDamagePlacementId } );		
			_bladeDamagePlacement = null;
		}

		/// <summary> setups the sync logic for member _bladeDamagePlacement</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBladeDamagePlacement(IEntity2 relatedEntity)
		{
			DesetupSyncBladeDamagePlacement(true, true);
			_bladeDamagePlacement = (BladeDamagePlacementEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bladeDamagePlacement, new PropertyChangedEventHandler( OnBladeDamagePlacementPropertyChanged ), "BladeDamagePlacement", BladeDamagePlacementEntity.Relations.BladeDamagePlacementEntityUsingBladeDamagePlacementIdParentBladeDamagePlacementId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBladeDamagePlacementPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this BladeDamagePlacementEntity</param>
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
		public  static BladeDamagePlacementRelations Relations
		{
			get	{ return new BladeDamagePlacementRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeDamagePlacement' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeDamagePlacement_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<BladeDamagePlacementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeDamagePlacementEntityFactory))),
					BladeDamagePlacementEntity.Relations.BladeDamagePlacementEntityUsingParentBladeDamagePlacementId, 
					(int)Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity, (int)Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity, 0, null, null, null, null, "BladeDamagePlacement_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportBladeDamage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportBladeDamage
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportBladeDamageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeDamageEntityFactory))),
					BladeDamagePlacementEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId, 
					(int)Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeDamageEntity, 0, null, null, null, null, "ComponentInspectionReportBladeDamage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeEdge' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeEdgeCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = BladeDamagePlacementEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBladeDamage_");
				relations.Add(BladeDamagePlacementEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId, "BladeDamagePlacementEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.BladeEdgeEntityUsingBladeEdgeId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BladeEdgeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeEdgeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity, (int)Cir.Data.LLBLGen.EntityType.BladeEdgeEntity, 0, null, null, relations, null, "BladeEdgeCollectionViaComponentInspectionReportBladeDamage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeInspectionData' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeInspectionDataCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = BladeDamagePlacementEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBladeDamage_");
				relations.Add(BladeDamagePlacementEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId, "BladeDamagePlacementEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.BladeInspectionDataEntityUsingBladeInspectionDataId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BladeInspectionDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeInspectionDataEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity, (int)Cir.Data.LLBLGen.EntityType.BladeInspectionDataEntity, 0, null, null, relations, null, "BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportBlade' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = BladeDamagePlacementEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBladeDamage_");
				relations.Add(BladeDamagePlacementEntity.Relations.ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId, "BladeDamagePlacementEntity__", "ComponentInspectionReportBladeDamage_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeDamageEntity.Relations.ComponentInspectionReportBladeEntityUsingComponentInspectionReportBladeId, "ComponentInspectionReportBladeDamage_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportBladeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, 0, null, null, relations, null, "ComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeDamagePlacement' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeDamagePlacement
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BladeDamagePlacementEntityFactory))),
					BladeDamagePlacementEntity.Relations.BladeDamagePlacementEntityUsingBladeDamagePlacementIdParentBladeDamagePlacementId, 
					(int)Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity, (int)Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity, 0, null, null, null, null, "BladeDamagePlacement", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return BladeDamagePlacementEntity.CustomProperties;}
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
			get { return BladeDamagePlacementEntity.FieldsCustomProperties;}
		}

		/// <summary> The BladeDamagePlacementId property of the Entity BladeDamagePlacement<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "BladeDamagePlacement"."BladeDamagePlacementId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 BladeDamagePlacementId
		{
			get { return (System.Int64)GetValue((int)BladeDamagePlacementFieldIndex.BladeDamagePlacementId, true); }
			set	{ SetValue((int)BladeDamagePlacementFieldIndex.BladeDamagePlacementId, value); }
		}

		/// <summary> The Name property of the Entity BladeDamagePlacement<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "BladeDamagePlacement"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)BladeDamagePlacementFieldIndex.Name, true); }
			set	{ SetValue((int)BladeDamagePlacementFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity BladeDamagePlacement<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "BladeDamagePlacement"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)BladeDamagePlacementFieldIndex.LanguageId, true); }
			set	{ SetValue((int)BladeDamagePlacementFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentBladeDamagePlacementId property of the Entity BladeDamagePlacement<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "BladeDamagePlacement"."ParentBladeDamagePlacementId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentBladeDamagePlacementId
		{
			get { return (Nullable<System.Int64>)GetValue((int)BladeDamagePlacementFieldIndex.ParentBladeDamagePlacementId, false); }
			set	{ SetValue((int)BladeDamagePlacementFieldIndex.ParentBladeDamagePlacementId, value); }
		}

		/// <summary> The Sort property of the Entity BladeDamagePlacement<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "BladeDamagePlacement"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)BladeDamagePlacementFieldIndex.Sort, true); }
			set	{ SetValue((int)BladeDamagePlacementFieldIndex.Sort, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BladeDamagePlacementEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BladeDamagePlacementEntity))]
		public virtual EntityCollection<BladeDamagePlacementEntity> BladeDamagePlacement_
		{
			get
			{
				if(_bladeDamagePlacement_==null)
				{
					_bladeDamagePlacement_ = new EntityCollection<BladeDamagePlacementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeDamagePlacementEntityFactory)));
					_bladeDamagePlacement_.SetContainingEntityInfo(this, "BladeDamagePlacement");
				}
				return _bladeDamagePlacement_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportBladeDamageEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportBladeDamageEntity))]
		public virtual EntityCollection<ComponentInspectionReportBladeDamageEntity> ComponentInspectionReportBladeDamage
		{
			get
			{
				if(_componentInspectionReportBladeDamage==null)
				{
					_componentInspectionReportBladeDamage = new EntityCollection<ComponentInspectionReportBladeDamageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeDamageEntityFactory)));
					_componentInspectionReportBladeDamage.SetContainingEntityInfo(this, "BladeDamagePlacement");
				}
				return _componentInspectionReportBladeDamage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BladeEdgeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BladeEdgeEntity))]
		public virtual EntityCollection<BladeEdgeEntity> BladeEdgeCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				if(_bladeEdgeCollectionViaComponentInspectionReportBladeDamage==null)
				{
					_bladeEdgeCollectionViaComponentInspectionReportBladeDamage = new EntityCollection<BladeEdgeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeEdgeEntityFactory)));
					_bladeEdgeCollectionViaComponentInspectionReportBladeDamage.IsReadOnly=true;
				}
				return _bladeEdgeCollectionViaComponentInspectionReportBladeDamage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BladeInspectionDataEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BladeInspectionDataEntity))]
		public virtual EntityCollection<BladeInspectionDataEntity> BladeInspectionDataCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				if(_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage==null)
				{
					_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage = new EntityCollection<BladeInspectionDataEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeInspectionDataEntityFactory)));
					_bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage.IsReadOnly=true;
				}
				return _bladeInspectionDataCollectionViaComponentInspectionReportBladeDamage;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportBladeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportBladeEntity))]
		public virtual EntityCollection<ComponentInspectionReportBladeEntity> ComponentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage
		{
			get
			{
				if(_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage==null)
				{
					_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage = new EntityCollection<ComponentInspectionReportBladeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeEntityFactory)));
					_componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage.IsReadOnly=true;
				}
				return _componentInspectionReportBladeCollectionViaComponentInspectionReportBladeDamage;
			}
		}

		/// <summary> Gets / sets related entity of type 'BladeDamagePlacementEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BladeDamagePlacementEntity BladeDamagePlacement
		{
			get
			{
				return _bladeDamagePlacement;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBladeDamagePlacement(value);
				}
				else
				{
					if(value==null)
					{
						if(_bladeDamagePlacement != null)
						{
							_bladeDamagePlacement.UnsetRelatedEntity(this, "BladeDamagePlacement_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "BladeDamagePlacement_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity; }
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
