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
	/// Entity class which represents the entity 'BladeLength'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class BladeLengthEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<BladeLengthEntity> _bladeLength_;
		private EntityCollection<ComponentInspectionReportBladeEntity> _componentInspectionReportBlade;
		private EntityCollection<BladeColorEntity> _bladeColorCollectionViaComponentInspectionReportBlade;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportBlade_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportBlade;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportBlade;
		private EntityCollection<FaultCodeAreaEntity> _faultCodeAreaCollectionViaComponentInspectionReportBlade;
		private EntityCollection<FaultCodeCauseEntity> _faultCodeCauseCollectionViaComponentInspectionReportBlade;
		private EntityCollection<FaultCodeClassificationEntity> _faultCodeClassificationCollectionViaComponentInspectionReportBlade;
		private EntityCollection<FaultCodeTypeEntity> _faultCodeTypeCollectionViaComponentInspectionReportBlade;
		private BladeLengthEntity _bladeLength;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name BladeLength</summary>
			public static readonly string BladeLength = "BladeLength";
			/// <summary>Member name BladeLength_</summary>
			public static readonly string BladeLength_ = "BladeLength_";
			/// <summary>Member name ComponentInspectionReportBlade</summary>
			public static readonly string ComponentInspectionReportBlade = "ComponentInspectionReportBlade";
			/// <summary>Member name BladeColorCollectionViaComponentInspectionReportBlade</summary>
			public static readonly string BladeColorCollectionViaComponentInspectionReportBlade = "BladeColorCollectionViaComponentInspectionReportBlade";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportBlade_</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportBlade_ = "BooleanAnswerCollectionViaComponentInspectionReportBlade_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportBlade</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportBlade = "BooleanAnswerCollectionViaComponentInspectionReportBlade";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportBlade</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportBlade = "ComponentInspectionReportCollectionViaComponentInspectionReportBlade";
			/// <summary>Member name FaultCodeAreaCollectionViaComponentInspectionReportBlade</summary>
			public static readonly string FaultCodeAreaCollectionViaComponentInspectionReportBlade = "FaultCodeAreaCollectionViaComponentInspectionReportBlade";
			/// <summary>Member name FaultCodeCauseCollectionViaComponentInspectionReportBlade</summary>
			public static readonly string FaultCodeCauseCollectionViaComponentInspectionReportBlade = "FaultCodeCauseCollectionViaComponentInspectionReportBlade";
			/// <summary>Member name FaultCodeClassificationCollectionViaComponentInspectionReportBlade</summary>
			public static readonly string FaultCodeClassificationCollectionViaComponentInspectionReportBlade = "FaultCodeClassificationCollectionViaComponentInspectionReportBlade";
			/// <summary>Member name FaultCodeTypeCollectionViaComponentInspectionReportBlade</summary>
			public static readonly string FaultCodeTypeCollectionViaComponentInspectionReportBlade = "FaultCodeTypeCollectionViaComponentInspectionReportBlade";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static BladeLengthEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public BladeLengthEntity():base("BladeLengthEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public BladeLengthEntity(IEntityFields2 fields):base("BladeLengthEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this BladeLengthEntity</param>
		public BladeLengthEntity(IValidator validator):base("BladeLengthEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="bladeLengthId">PK value for BladeLength which data should be fetched into this BladeLength object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public BladeLengthEntity(System.Int64 bladeLengthId):base("BladeLengthEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.BladeLengthId = bladeLengthId;
		}

		/// <summary> CTor</summary>
		/// <param name="bladeLengthId">PK value for BladeLength which data should be fetched into this BladeLength object</param>
		/// <param name="validator">The custom validator object for this BladeLengthEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public BladeLengthEntity(System.Int64 bladeLengthId, IValidator validator):base("BladeLengthEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.BladeLengthId = bladeLengthId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected BladeLengthEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_bladeLength_ = (EntityCollection<BladeLengthEntity>)info.GetValue("_bladeLength_", typeof(EntityCollection<BladeLengthEntity>));
				_componentInspectionReportBlade = (EntityCollection<ComponentInspectionReportBladeEntity>)info.GetValue("_componentInspectionReportBlade", typeof(EntityCollection<ComponentInspectionReportBladeEntity>));
				_bladeColorCollectionViaComponentInspectionReportBlade = (EntityCollection<BladeColorEntity>)info.GetValue("_bladeColorCollectionViaComponentInspectionReportBlade", typeof(EntityCollection<BladeColorEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportBlade_ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportBlade_", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportBlade = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportBlade", typeof(EntityCollection<BooleanAnswerEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportBlade = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportBlade", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_faultCodeAreaCollectionViaComponentInspectionReportBlade = (EntityCollection<FaultCodeAreaEntity>)info.GetValue("_faultCodeAreaCollectionViaComponentInspectionReportBlade", typeof(EntityCollection<FaultCodeAreaEntity>));
				_faultCodeCauseCollectionViaComponentInspectionReportBlade = (EntityCollection<FaultCodeCauseEntity>)info.GetValue("_faultCodeCauseCollectionViaComponentInspectionReportBlade", typeof(EntityCollection<FaultCodeCauseEntity>));
				_faultCodeClassificationCollectionViaComponentInspectionReportBlade = (EntityCollection<FaultCodeClassificationEntity>)info.GetValue("_faultCodeClassificationCollectionViaComponentInspectionReportBlade", typeof(EntityCollection<FaultCodeClassificationEntity>));
				_faultCodeTypeCollectionViaComponentInspectionReportBlade = (EntityCollection<FaultCodeTypeEntity>)info.GetValue("_faultCodeTypeCollectionViaComponentInspectionReportBlade", typeof(EntityCollection<FaultCodeTypeEntity>));
				_bladeLength = (BladeLengthEntity)info.GetValue("_bladeLength", typeof(BladeLengthEntity));
				if(_bladeLength!=null)
				{
					_bladeLength.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((BladeLengthFieldIndex)fieldIndex)
			{
				case BladeLengthFieldIndex.ParentBladeLengthId:
					DesetupSyncBladeLength(true, false);
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
				case "BladeLength":
					this.BladeLength = (BladeLengthEntity)entity;
					break;
				case "BladeLength_":
					this.BladeLength_.Add((BladeLengthEntity)entity);
					break;
				case "ComponentInspectionReportBlade":
					this.ComponentInspectionReportBlade.Add((ComponentInspectionReportBladeEntity)entity);
					break;
				case "BladeColorCollectionViaComponentInspectionReportBlade":
					this.BladeColorCollectionViaComponentInspectionReportBlade.IsReadOnly = false;
					this.BladeColorCollectionViaComponentInspectionReportBlade.Add((BladeColorEntity)entity);
					this.BladeColorCollectionViaComponentInspectionReportBlade.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportBlade_":
					this.BooleanAnswerCollectionViaComponentInspectionReportBlade_.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportBlade_.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportBlade_.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportBlade":
					this.BooleanAnswerCollectionViaComponentInspectionReportBlade.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportBlade.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportBlade.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportBlade":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportBlade.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportBlade.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportBlade.IsReadOnly = true;
					break;
				case "FaultCodeAreaCollectionViaComponentInspectionReportBlade":
					this.FaultCodeAreaCollectionViaComponentInspectionReportBlade.IsReadOnly = false;
					this.FaultCodeAreaCollectionViaComponentInspectionReportBlade.Add((FaultCodeAreaEntity)entity);
					this.FaultCodeAreaCollectionViaComponentInspectionReportBlade.IsReadOnly = true;
					break;
				case "FaultCodeCauseCollectionViaComponentInspectionReportBlade":
					this.FaultCodeCauseCollectionViaComponentInspectionReportBlade.IsReadOnly = false;
					this.FaultCodeCauseCollectionViaComponentInspectionReportBlade.Add((FaultCodeCauseEntity)entity);
					this.FaultCodeCauseCollectionViaComponentInspectionReportBlade.IsReadOnly = true;
					break;
				case "FaultCodeClassificationCollectionViaComponentInspectionReportBlade":
					this.FaultCodeClassificationCollectionViaComponentInspectionReportBlade.IsReadOnly = false;
					this.FaultCodeClassificationCollectionViaComponentInspectionReportBlade.Add((FaultCodeClassificationEntity)entity);
					this.FaultCodeClassificationCollectionViaComponentInspectionReportBlade.IsReadOnly = true;
					break;
				case "FaultCodeTypeCollectionViaComponentInspectionReportBlade":
					this.FaultCodeTypeCollectionViaComponentInspectionReportBlade.IsReadOnly = false;
					this.FaultCodeTypeCollectionViaComponentInspectionReportBlade.Add((FaultCodeTypeEntity)entity);
					this.FaultCodeTypeCollectionViaComponentInspectionReportBlade.IsReadOnly = true;
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
				case "BladeLength":
					SetupSyncBladeLength(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BladeLength_":
					this.BladeLength_.Add((BladeLengthEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportBlade":
					this.ComponentInspectionReportBlade.Add((ComponentInspectionReportBladeEntity)relatedEntity);
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
				case "BladeLength":
					DesetupSyncBladeLength(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BladeLength_":
					base.PerformRelatedEntityRemoval(this.BladeLength_, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportBlade":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportBlade, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_bladeLength!=null)
			{
				toReturn.Add(_bladeLength);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.BladeLength_);
			toReturn.Add(this.ComponentInspectionReportBlade);

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
				info.AddValue("_bladeLength_", ((_bladeLength_!=null) && (_bladeLength_.Count>0) && !this.MarkedForDeletion)?_bladeLength_:null);
				info.AddValue("_componentInspectionReportBlade", ((_componentInspectionReportBlade!=null) && (_componentInspectionReportBlade.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportBlade:null);
				info.AddValue("_bladeColorCollectionViaComponentInspectionReportBlade", ((_bladeColorCollectionViaComponentInspectionReportBlade!=null) && (_bladeColorCollectionViaComponentInspectionReportBlade.Count>0) && !this.MarkedForDeletion)?_bladeColorCollectionViaComponentInspectionReportBlade:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportBlade_", ((_booleanAnswerCollectionViaComponentInspectionReportBlade_!=null) && (_booleanAnswerCollectionViaComponentInspectionReportBlade_.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportBlade_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportBlade", ((_booleanAnswerCollectionViaComponentInspectionReportBlade!=null) && (_booleanAnswerCollectionViaComponentInspectionReportBlade.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportBlade:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportBlade", ((_componentInspectionReportCollectionViaComponentInspectionReportBlade!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportBlade.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportBlade:null);
				info.AddValue("_faultCodeAreaCollectionViaComponentInspectionReportBlade", ((_faultCodeAreaCollectionViaComponentInspectionReportBlade!=null) && (_faultCodeAreaCollectionViaComponentInspectionReportBlade.Count>0) && !this.MarkedForDeletion)?_faultCodeAreaCollectionViaComponentInspectionReportBlade:null);
				info.AddValue("_faultCodeCauseCollectionViaComponentInspectionReportBlade", ((_faultCodeCauseCollectionViaComponentInspectionReportBlade!=null) && (_faultCodeCauseCollectionViaComponentInspectionReportBlade.Count>0) && !this.MarkedForDeletion)?_faultCodeCauseCollectionViaComponentInspectionReportBlade:null);
				info.AddValue("_faultCodeClassificationCollectionViaComponentInspectionReportBlade", ((_faultCodeClassificationCollectionViaComponentInspectionReportBlade!=null) && (_faultCodeClassificationCollectionViaComponentInspectionReportBlade.Count>0) && !this.MarkedForDeletion)?_faultCodeClassificationCollectionViaComponentInspectionReportBlade:null);
				info.AddValue("_faultCodeTypeCollectionViaComponentInspectionReportBlade", ((_faultCodeTypeCollectionViaComponentInspectionReportBlade!=null) && (_faultCodeTypeCollectionViaComponentInspectionReportBlade.Count>0) && !this.MarkedForDeletion)?_faultCodeTypeCollectionViaComponentInspectionReportBlade:null);
				info.AddValue("_bladeLength", (!this.MarkedForDeletion?_bladeLength:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(BladeLengthFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(BladeLengthFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new BladeLengthRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BladeLength' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeLength_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeLengthFields.ParentBladeLengthId, null, ComparisonOperator.Equal, this.BladeLengthId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportBlade' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportBlade()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportBladeFields.BladeLengthId, null, ComparisonOperator.Equal, this.BladeLengthId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BladeColor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeColorCollectionViaComponentInspectionReportBlade()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeEntity.Relations.BladeColorEntityUsingBladeColorId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeLengthFields.BladeLengthId, null, ComparisonOperator.Equal, this.BladeLengthId, "BladeLengthEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportBlade_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeEntity.Relations.BooleanAnswerEntityUsingBladeClaimRelevantBooleanAnswerId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeLengthFields.BladeLengthId, null, ComparisonOperator.Equal, this.BladeLengthId, "BladeLengthEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportBlade()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeEntity.Relations.BooleanAnswerEntityUsingBladePicturesIncludedBooleanAnswerId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeLengthFields.BladeLengthId, null, ComparisonOperator.Equal, this.BladeLengthId, "BladeLengthEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportBlade()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeLengthFields.BladeLengthId, null, ComparisonOperator.Equal, this.BladeLengthId, "BladeLengthEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FaultCodeArea' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFaultCodeAreaCollectionViaComponentInspectionReportBlade()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeEntity.Relations.FaultCodeAreaEntityUsingBladeFaultCodeAreaId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeLengthFields.BladeLengthId, null, ComparisonOperator.Equal, this.BladeLengthId, "BladeLengthEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FaultCodeCause' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFaultCodeCauseCollectionViaComponentInspectionReportBlade()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeEntity.Relations.FaultCodeCauseEntityUsingBladeFaultCodeCauseId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeLengthFields.BladeLengthId, null, ComparisonOperator.Equal, this.BladeLengthId, "BladeLengthEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FaultCodeClassification' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFaultCodeClassificationCollectionViaComponentInspectionReportBlade()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeEntity.Relations.FaultCodeClassificationEntityUsingBladeFaultCodeClassificationId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeLengthFields.BladeLengthId, null, ComparisonOperator.Equal, this.BladeLengthId, "BladeLengthEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FaultCodeType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFaultCodeTypeCollectionViaComponentInspectionReportBlade()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportBladeEntity.Relations.FaultCodeTypeEntityUsingBladeFaultCodeTypeId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeLengthFields.BladeLengthId, null, ComparisonOperator.Equal, this.BladeLengthId, "BladeLengthEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BladeLength' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeLength()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeLengthFields.BladeLengthId, null, ComparisonOperator.Equal, this.ParentBladeLengthId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.BladeLengthEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(BladeLengthEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._bladeLength_);
			collectionsQueue.Enqueue(this._componentInspectionReportBlade);
			collectionsQueue.Enqueue(this._bladeColorCollectionViaComponentInspectionReportBlade);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportBlade_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportBlade);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportBlade);
			collectionsQueue.Enqueue(this._faultCodeAreaCollectionViaComponentInspectionReportBlade);
			collectionsQueue.Enqueue(this._faultCodeCauseCollectionViaComponentInspectionReportBlade);
			collectionsQueue.Enqueue(this._faultCodeClassificationCollectionViaComponentInspectionReportBlade);
			collectionsQueue.Enqueue(this._faultCodeTypeCollectionViaComponentInspectionReportBlade);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._bladeLength_ = (EntityCollection<BladeLengthEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportBlade = (EntityCollection<ComponentInspectionReportBladeEntity>) collectionsQueue.Dequeue();
			this._bladeColorCollectionViaComponentInspectionReportBlade = (EntityCollection<BladeColorEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportBlade_ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportBlade = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportBlade = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._faultCodeAreaCollectionViaComponentInspectionReportBlade = (EntityCollection<FaultCodeAreaEntity>) collectionsQueue.Dequeue();
			this._faultCodeCauseCollectionViaComponentInspectionReportBlade = (EntityCollection<FaultCodeCauseEntity>) collectionsQueue.Dequeue();
			this._faultCodeClassificationCollectionViaComponentInspectionReportBlade = (EntityCollection<FaultCodeClassificationEntity>) collectionsQueue.Dequeue();
			this._faultCodeTypeCollectionViaComponentInspectionReportBlade = (EntityCollection<FaultCodeTypeEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._bladeLength_ != null)
			{
				return true;
			}
			if (this._componentInspectionReportBlade != null)
			{
				return true;
			}
			if (this._bladeColorCollectionViaComponentInspectionReportBlade != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportBlade_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportBlade != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportBlade != null)
			{
				return true;
			}
			if (this._faultCodeAreaCollectionViaComponentInspectionReportBlade != null)
			{
				return true;
			}
			if (this._faultCodeCauseCollectionViaComponentInspectionReportBlade != null)
			{
				return true;
			}
			if (this._faultCodeClassificationCollectionViaComponentInspectionReportBlade != null)
			{
				return true;
			}
			if (this._faultCodeTypeCollectionViaComponentInspectionReportBlade != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BladeLengthEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeLengthEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportBladeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BladeColorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeColorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FaultCodeAreaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeAreaEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FaultCodeCauseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeCauseEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FaultCodeClassificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeClassificationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FaultCodeTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeTypeEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("BladeLength", _bladeLength);
			toReturn.Add("BladeLength_", _bladeLength_);
			toReturn.Add("ComponentInspectionReportBlade", _componentInspectionReportBlade);
			toReturn.Add("BladeColorCollectionViaComponentInspectionReportBlade", _bladeColorCollectionViaComponentInspectionReportBlade);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportBlade_", _booleanAnswerCollectionViaComponentInspectionReportBlade_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportBlade", _booleanAnswerCollectionViaComponentInspectionReportBlade);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportBlade", _componentInspectionReportCollectionViaComponentInspectionReportBlade);
			toReturn.Add("FaultCodeAreaCollectionViaComponentInspectionReportBlade", _faultCodeAreaCollectionViaComponentInspectionReportBlade);
			toReturn.Add("FaultCodeCauseCollectionViaComponentInspectionReportBlade", _faultCodeCauseCollectionViaComponentInspectionReportBlade);
			toReturn.Add("FaultCodeClassificationCollectionViaComponentInspectionReportBlade", _faultCodeClassificationCollectionViaComponentInspectionReportBlade);
			toReturn.Add("FaultCodeTypeCollectionViaComponentInspectionReportBlade", _faultCodeTypeCollectionViaComponentInspectionReportBlade);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_bladeLength_!=null)
			{
				_bladeLength_.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportBlade!=null)
			{
				_componentInspectionReportBlade.ActiveContext = base.ActiveContext;
			}
			if(_bladeColorCollectionViaComponentInspectionReportBlade!=null)
			{
				_bladeColorCollectionViaComponentInspectionReportBlade.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportBlade_!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportBlade_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportBlade!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportBlade.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportBlade!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportBlade.ActiveContext = base.ActiveContext;
			}
			if(_faultCodeAreaCollectionViaComponentInspectionReportBlade!=null)
			{
				_faultCodeAreaCollectionViaComponentInspectionReportBlade.ActiveContext = base.ActiveContext;
			}
			if(_faultCodeCauseCollectionViaComponentInspectionReportBlade!=null)
			{
				_faultCodeCauseCollectionViaComponentInspectionReportBlade.ActiveContext = base.ActiveContext;
			}
			if(_faultCodeClassificationCollectionViaComponentInspectionReportBlade!=null)
			{
				_faultCodeClassificationCollectionViaComponentInspectionReportBlade.ActiveContext = base.ActiveContext;
			}
			if(_faultCodeTypeCollectionViaComponentInspectionReportBlade!=null)
			{
				_faultCodeTypeCollectionViaComponentInspectionReportBlade.ActiveContext = base.ActiveContext;
			}
			if(_bladeLength!=null)
			{
				_bladeLength.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_bladeLength_ = null;
			_componentInspectionReportBlade = null;
			_bladeColorCollectionViaComponentInspectionReportBlade = null;
			_booleanAnswerCollectionViaComponentInspectionReportBlade_ = null;
			_booleanAnswerCollectionViaComponentInspectionReportBlade = null;
			_componentInspectionReportCollectionViaComponentInspectionReportBlade = null;
			_faultCodeAreaCollectionViaComponentInspectionReportBlade = null;
			_faultCodeCauseCollectionViaComponentInspectionReportBlade = null;
			_faultCodeClassificationCollectionViaComponentInspectionReportBlade = null;
			_faultCodeTypeCollectionViaComponentInspectionReportBlade = null;
			_bladeLength = null;

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

			_fieldsCustomProperties.Add("BladeLengthId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentBladeLengthId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _bladeLength</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBladeLength(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bladeLength, new PropertyChangedEventHandler( OnBladeLengthPropertyChanged ), "BladeLength", BladeLengthEntity.Relations.BladeLengthEntityUsingBladeLengthIdParentBladeLengthId, true, signalRelatedEntity, "BladeLength_", resetFKFields, new int[] { (int)BladeLengthFieldIndex.ParentBladeLengthId } );		
			_bladeLength = null;
		}

		/// <summary> setups the sync logic for member _bladeLength</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBladeLength(IEntity2 relatedEntity)
		{
			DesetupSyncBladeLength(true, true);
			_bladeLength = (BladeLengthEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bladeLength, new PropertyChangedEventHandler( OnBladeLengthPropertyChanged ), "BladeLength", BladeLengthEntity.Relations.BladeLengthEntityUsingBladeLengthIdParentBladeLengthId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBladeLengthPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this BladeLengthEntity</param>
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
		public  static BladeLengthRelations Relations
		{
			get	{ return new BladeLengthRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeLength' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeLength_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<BladeLengthEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeLengthEntityFactory))),
					BladeLengthEntity.Relations.BladeLengthEntityUsingParentBladeLengthId, 
					(int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, (int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, 0, null, null, null, null, "BladeLength_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportBlade' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportBlade
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportBladeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeEntityFactory))),
					BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, 
					(int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, 0, null, null, null, null, "ComponentInspectionReportBlade", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeColor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeColorCollectionViaComponentInspectionReportBlade
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBlade_");
				relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeEntity.Relations.BladeColorEntityUsingBladeColorId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BladeColorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeColorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, (int)Cir.Data.LLBLGen.EntityType.BladeColorEntity, 0, null, null, relations, null, "BladeColorCollectionViaComponentInspectionReportBlade", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportBlade_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBlade_");
				relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeEntity.Relations.BooleanAnswerEntityUsingBladeClaimRelevantBooleanAnswerId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportBlade_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportBlade
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBlade_");
				relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeEntity.Relations.BooleanAnswerEntityUsingBladePicturesIncludedBooleanAnswerId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportBlade", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportBlade
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBlade_");
				relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportBlade", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FaultCodeArea' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFaultCodeAreaCollectionViaComponentInspectionReportBlade
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBlade_");
				relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeEntity.Relations.FaultCodeAreaEntityUsingBladeFaultCodeAreaId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<FaultCodeAreaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeAreaEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, (int)Cir.Data.LLBLGen.EntityType.FaultCodeAreaEntity, 0, null, null, relations, null, "FaultCodeAreaCollectionViaComponentInspectionReportBlade", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FaultCodeCause' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFaultCodeCauseCollectionViaComponentInspectionReportBlade
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBlade_");
				relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeEntity.Relations.FaultCodeCauseEntityUsingBladeFaultCodeCauseId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<FaultCodeCauseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeCauseEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, (int)Cir.Data.LLBLGen.EntityType.FaultCodeCauseEntity, 0, null, null, relations, null, "FaultCodeCauseCollectionViaComponentInspectionReportBlade", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FaultCodeClassification' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFaultCodeClassificationCollectionViaComponentInspectionReportBlade
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBlade_");
				relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeEntity.Relations.FaultCodeClassificationEntityUsingBladeFaultCodeClassificationId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<FaultCodeClassificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeClassificationEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, (int)Cir.Data.LLBLGen.EntityType.FaultCodeClassificationEntity, 0, null, null, relations, null, "FaultCodeClassificationCollectionViaComponentInspectionReportBlade", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FaultCodeType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFaultCodeTypeCollectionViaComponentInspectionReportBlade
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportBlade_");
				relations.Add(BladeLengthEntity.Relations.ComponentInspectionReportBladeEntityUsingBladeLengthId, "BladeLengthEntity__", "ComponentInspectionReportBlade_", JoinHint.None);
				relations.Add(ComponentInspectionReportBladeEntity.Relations.FaultCodeTypeEntityUsingBladeFaultCodeTypeId, "ComponentInspectionReportBlade_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<FaultCodeTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, (int)Cir.Data.LLBLGen.EntityType.FaultCodeTypeEntity, 0, null, null, relations, null, "FaultCodeTypeCollectionViaComponentInspectionReportBlade", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeLength' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeLength
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BladeLengthEntityFactory))),
					BladeLengthEntity.Relations.BladeLengthEntityUsingBladeLengthIdParentBladeLengthId, 
					(int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, (int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity, 0, null, null, null, null, "BladeLength", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return BladeLengthEntity.CustomProperties;}
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
			get { return BladeLengthEntity.FieldsCustomProperties;}
		}

		/// <summary> The BladeLengthId property of the Entity BladeLength<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "BladeLength"."BladeLengthId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 BladeLengthId
		{
			get { return (System.Int64)GetValue((int)BladeLengthFieldIndex.BladeLengthId, true); }
			set	{ SetValue((int)BladeLengthFieldIndex.BladeLengthId, value); }
		}

		/// <summary> The Name property of the Entity BladeLength<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "BladeLength"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)BladeLengthFieldIndex.Name, true); }
			set	{ SetValue((int)BladeLengthFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity BladeLength<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "BladeLength"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)BladeLengthFieldIndex.LanguageId, true); }
			set	{ SetValue((int)BladeLengthFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentBladeLengthId property of the Entity BladeLength<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "BladeLength"."ParentBladeLengthId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentBladeLengthId
		{
			get { return (Nullable<System.Int64>)GetValue((int)BladeLengthFieldIndex.ParentBladeLengthId, false); }
			set	{ SetValue((int)BladeLengthFieldIndex.ParentBladeLengthId, value); }
		}

		/// <summary> The Sort property of the Entity BladeLength<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "BladeLength"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)BladeLengthFieldIndex.Sort, true); }
			set	{ SetValue((int)BladeLengthFieldIndex.Sort, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BladeLengthEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BladeLengthEntity))]
		public virtual EntityCollection<BladeLengthEntity> BladeLength_
		{
			get
			{
				if(_bladeLength_==null)
				{
					_bladeLength_ = new EntityCollection<BladeLengthEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeLengthEntityFactory)));
					_bladeLength_.SetContainingEntityInfo(this, "BladeLength");
				}
				return _bladeLength_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportBladeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportBladeEntity))]
		public virtual EntityCollection<ComponentInspectionReportBladeEntity> ComponentInspectionReportBlade
		{
			get
			{
				if(_componentInspectionReportBlade==null)
				{
					_componentInspectionReportBlade = new EntityCollection<ComponentInspectionReportBladeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeEntityFactory)));
					_componentInspectionReportBlade.SetContainingEntityInfo(this, "BladeLength");
				}
				return _componentInspectionReportBlade;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BladeColorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BladeColorEntity))]
		public virtual EntityCollection<BladeColorEntity> BladeColorCollectionViaComponentInspectionReportBlade
		{
			get
			{
				if(_bladeColorCollectionViaComponentInspectionReportBlade==null)
				{
					_bladeColorCollectionViaComponentInspectionReportBlade = new EntityCollection<BladeColorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BladeColorEntityFactory)));
					_bladeColorCollectionViaComponentInspectionReportBlade.IsReadOnly=true;
				}
				return _bladeColorCollectionViaComponentInspectionReportBlade;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportBlade_
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportBlade_==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportBlade_ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportBlade_.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportBlade_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportBlade
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportBlade==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportBlade = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportBlade.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportBlade;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportBlade
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportBlade==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportBlade = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportBlade.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportBlade;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FaultCodeAreaEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FaultCodeAreaEntity))]
		public virtual EntityCollection<FaultCodeAreaEntity> FaultCodeAreaCollectionViaComponentInspectionReportBlade
		{
			get
			{
				if(_faultCodeAreaCollectionViaComponentInspectionReportBlade==null)
				{
					_faultCodeAreaCollectionViaComponentInspectionReportBlade = new EntityCollection<FaultCodeAreaEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeAreaEntityFactory)));
					_faultCodeAreaCollectionViaComponentInspectionReportBlade.IsReadOnly=true;
				}
				return _faultCodeAreaCollectionViaComponentInspectionReportBlade;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FaultCodeCauseEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FaultCodeCauseEntity))]
		public virtual EntityCollection<FaultCodeCauseEntity> FaultCodeCauseCollectionViaComponentInspectionReportBlade
		{
			get
			{
				if(_faultCodeCauseCollectionViaComponentInspectionReportBlade==null)
				{
					_faultCodeCauseCollectionViaComponentInspectionReportBlade = new EntityCollection<FaultCodeCauseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeCauseEntityFactory)));
					_faultCodeCauseCollectionViaComponentInspectionReportBlade.IsReadOnly=true;
				}
				return _faultCodeCauseCollectionViaComponentInspectionReportBlade;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FaultCodeClassificationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FaultCodeClassificationEntity))]
		public virtual EntityCollection<FaultCodeClassificationEntity> FaultCodeClassificationCollectionViaComponentInspectionReportBlade
		{
			get
			{
				if(_faultCodeClassificationCollectionViaComponentInspectionReportBlade==null)
				{
					_faultCodeClassificationCollectionViaComponentInspectionReportBlade = new EntityCollection<FaultCodeClassificationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeClassificationEntityFactory)));
					_faultCodeClassificationCollectionViaComponentInspectionReportBlade.IsReadOnly=true;
				}
				return _faultCodeClassificationCollectionViaComponentInspectionReportBlade;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FaultCodeTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FaultCodeTypeEntity))]
		public virtual EntityCollection<FaultCodeTypeEntity> FaultCodeTypeCollectionViaComponentInspectionReportBlade
		{
			get
			{
				if(_faultCodeTypeCollectionViaComponentInspectionReportBlade==null)
				{
					_faultCodeTypeCollectionViaComponentInspectionReportBlade = new EntityCollection<FaultCodeTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FaultCodeTypeEntityFactory)));
					_faultCodeTypeCollectionViaComponentInspectionReportBlade.IsReadOnly=true;
				}
				return _faultCodeTypeCollectionViaComponentInspectionReportBlade;
			}
		}

		/// <summary> Gets / sets related entity of type 'BladeLengthEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BladeLengthEntity BladeLength
		{
			get
			{
				return _bladeLength;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBladeLength(value);
				}
				else
				{
					if(value==null)
					{
						if(_bladeLength != null)
						{
							_bladeLength.UnsetRelatedEntity(this, "BladeLength_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "BladeLength_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.BladeLengthEntity; }
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
