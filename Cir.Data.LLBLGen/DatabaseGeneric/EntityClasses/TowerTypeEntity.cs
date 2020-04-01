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
	/// Entity class which represents the entity 'TowerType'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TowerTypeEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportGeneralEntity> _componentInspectionReportGeneral;
		private EntityCollection<TowerTypeEntity> _towerType_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGeneral_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<ComponentGroupEntity> _componentGroupCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<ControllerTypeEntity> _controllerTypeCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<GearboxManufacturerEntity> _gearboxManufacturerCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<TowerHeightEntity> _towerHeightCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<TransformerManufacturerEntity> _transformerManufacturerCollectionViaComponentInspectionReportGeneral;
		private TowerTypeEntity _towerType;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name TowerType</summary>
			public static readonly string TowerType = "TowerType";
			/// <summary>Member name ComponentInspectionReportGeneral</summary>
			public static readonly string ComponentInspectionReportGeneral = "ComponentInspectionReportGeneral";
			/// <summary>Member name TowerType_</summary>
			public static readonly string TowerType_ = "TowerType_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGeneral_</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGeneral_ = "BooleanAnswerCollectionViaComponentInspectionReportGeneral_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGeneral = "BooleanAnswerCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name ComponentGroupCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string ComponentGroupCollectionViaComponentInspectionReportGeneral = "ComponentGroupCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGeneral = "ComponentInspectionReportCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name ControllerTypeCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string ControllerTypeCollectionViaComponentInspectionReportGeneral = "ControllerTypeCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name GearboxManufacturerCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string GearboxManufacturerCollectionViaComponentInspectionReportGeneral = "GearboxManufacturerCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGeneral = "GeneratorManufacturerCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name TowerHeightCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string TowerHeightCollectionViaComponentInspectionReportGeneral = "TowerHeightCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name TransformerManufacturerCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string TransformerManufacturerCollectionViaComponentInspectionReportGeneral = "TransformerManufacturerCollectionViaComponentInspectionReportGeneral";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TowerTypeEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TowerTypeEntity():base("TowerTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TowerTypeEntity(IEntityFields2 fields):base("TowerTypeEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TowerTypeEntity</param>
		public TowerTypeEntity(IValidator validator):base("TowerTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="towerTypeId">PK value for TowerType which data should be fetched into this TowerType object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TowerTypeEntity(System.Int64 towerTypeId):base("TowerTypeEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TowerTypeId = towerTypeId;
		}

		/// <summary> CTor</summary>
		/// <param name="towerTypeId">PK value for TowerType which data should be fetched into this TowerType object</param>
		/// <param name="validator">The custom validator object for this TowerTypeEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TowerTypeEntity(System.Int64 towerTypeId, IValidator validator):base("TowerTypeEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TowerTypeId = towerTypeId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TowerTypeEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReportGeneral = (EntityCollection<ComponentInspectionReportGeneralEntity>)info.GetValue("_componentInspectionReportGeneral", typeof(EntityCollection<ComponentInspectionReportGeneralEntity>));
				_towerType_ = (EntityCollection<TowerTypeEntity>)info.GetValue("_towerType_", typeof(EntityCollection<TowerTypeEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGeneral_ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGeneral_", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGeneral = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<BooleanAnswerEntity>));
				_componentGroupCollectionViaComponentInspectionReportGeneral = (EntityCollection<ComponentGroupEntity>)info.GetValue("_componentGroupCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<ComponentGroupEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGeneral = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_controllerTypeCollectionViaComponentInspectionReportGeneral = (EntityCollection<ControllerTypeEntity>)info.GetValue("_controllerTypeCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<ControllerTypeEntity>));
				_gearboxManufacturerCollectionViaComponentInspectionReportGeneral = (EntityCollection<GearboxManufacturerEntity>)info.GetValue("_gearboxManufacturerCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<GearboxManufacturerEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGeneral = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_towerHeightCollectionViaComponentInspectionReportGeneral = (EntityCollection<TowerHeightEntity>)info.GetValue("_towerHeightCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<TowerHeightEntity>));
				_transformerManufacturerCollectionViaComponentInspectionReportGeneral = (EntityCollection<TransformerManufacturerEntity>)info.GetValue("_transformerManufacturerCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<TransformerManufacturerEntity>));
				_towerType = (TowerTypeEntity)info.GetValue("_towerType", typeof(TowerTypeEntity));
				if(_towerType!=null)
				{
					_towerType.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((TowerTypeFieldIndex)fieldIndex)
			{
				case TowerTypeFieldIndex.ParentTowerTypeId:
					DesetupSyncTowerType(true, false);
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
				case "TowerType":
					this.TowerType = (TowerTypeEntity)entity;
					break;
				case "ComponentInspectionReportGeneral":
					this.ComponentInspectionReportGeneral.Add((ComponentInspectionReportGeneralEntity)entity);
					break;
				case "TowerType_":
					this.TowerType_.Add((TowerTypeEntity)entity);
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGeneral_":
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral_.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral_.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral_.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGeneral":
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral.IsReadOnly = true;
					break;
				case "ComponentGroupCollectionViaComponentInspectionReportGeneral":
					this.ComponentGroupCollectionViaComponentInspectionReportGeneral.IsReadOnly = false;
					this.ComponentGroupCollectionViaComponentInspectionReportGeneral.Add((ComponentGroupEntity)entity);
					this.ComponentGroupCollectionViaComponentInspectionReportGeneral.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGeneral":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGeneral.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGeneral.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGeneral.IsReadOnly = true;
					break;
				case "ControllerTypeCollectionViaComponentInspectionReportGeneral":
					this.ControllerTypeCollectionViaComponentInspectionReportGeneral.IsReadOnly = false;
					this.ControllerTypeCollectionViaComponentInspectionReportGeneral.Add((ControllerTypeEntity)entity);
					this.ControllerTypeCollectionViaComponentInspectionReportGeneral.IsReadOnly = true;
					break;
				case "GearboxManufacturerCollectionViaComponentInspectionReportGeneral":
					this.GearboxManufacturerCollectionViaComponentInspectionReportGeneral.IsReadOnly = false;
					this.GearboxManufacturerCollectionViaComponentInspectionReportGeneral.Add((GearboxManufacturerEntity)entity);
					this.GearboxManufacturerCollectionViaComponentInspectionReportGeneral.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGeneral":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGeneral.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGeneral.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGeneral.IsReadOnly = true;
					break;
				case "TowerHeightCollectionViaComponentInspectionReportGeneral":
					this.TowerHeightCollectionViaComponentInspectionReportGeneral.IsReadOnly = false;
					this.TowerHeightCollectionViaComponentInspectionReportGeneral.Add((TowerHeightEntity)entity);
					this.TowerHeightCollectionViaComponentInspectionReportGeneral.IsReadOnly = true;
					break;
				case "TransformerManufacturerCollectionViaComponentInspectionReportGeneral":
					this.TransformerManufacturerCollectionViaComponentInspectionReportGeneral.IsReadOnly = false;
					this.TransformerManufacturerCollectionViaComponentInspectionReportGeneral.Add((TransformerManufacturerEntity)entity);
					this.TransformerManufacturerCollectionViaComponentInspectionReportGeneral.IsReadOnly = true;
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
				case "TowerType":
					SetupSyncTowerType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGeneral":
					this.ComponentInspectionReportGeneral.Add((ComponentInspectionReportGeneralEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TowerType_":
					this.TowerType_.Add((TowerTypeEntity)relatedEntity);
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
				case "TowerType":
					DesetupSyncTowerType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGeneral":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGeneral, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TowerType_":
					base.PerformRelatedEntityRemoval(this.TowerType_, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_towerType!=null)
			{
				toReturn.Add(_towerType);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReportGeneral);
			toReturn.Add(this.TowerType_);

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
				info.AddValue("_componentInspectionReportGeneral", ((_componentInspectionReportGeneral!=null) && (_componentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGeneral:null);
				info.AddValue("_towerType_", ((_towerType_!=null) && (_towerType_.Count>0) && !this.MarkedForDeletion)?_towerType_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGeneral_", ((_booleanAnswerCollectionViaComponentInspectionReportGeneral_!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGeneral_.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGeneral_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGeneral", ((_booleanAnswerCollectionViaComponentInspectionReportGeneral!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_componentGroupCollectionViaComponentInspectionReportGeneral", ((_componentGroupCollectionViaComponentInspectionReportGeneral!=null) && (_componentGroupCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_componentGroupCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGeneral", ((_componentInspectionReportCollectionViaComponentInspectionReportGeneral!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_controllerTypeCollectionViaComponentInspectionReportGeneral", ((_controllerTypeCollectionViaComponentInspectionReportGeneral!=null) && (_controllerTypeCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_controllerTypeCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_gearboxManufacturerCollectionViaComponentInspectionReportGeneral", ((_gearboxManufacturerCollectionViaComponentInspectionReportGeneral!=null) && (_gearboxManufacturerCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_gearboxManufacturerCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGeneral", ((_generatorManufacturerCollectionViaComponentInspectionReportGeneral!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_towerHeightCollectionViaComponentInspectionReportGeneral", ((_towerHeightCollectionViaComponentInspectionReportGeneral!=null) && (_towerHeightCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_towerHeightCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_transformerManufacturerCollectionViaComponentInspectionReportGeneral", ((_transformerManufacturerCollectionViaComponentInspectionReportGeneral!=null) && (_transformerManufacturerCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_transformerManufacturerCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_towerType", (!this.MarkedForDeletion?_towerType:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(TowerTypeFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TowerTypeFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TowerTypeRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGeneral' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneralFields.GeneralTowerTypeId, null, ComparisonOperator.Equal, this.TowerTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TowerType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTowerType_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.ParentTowerTypeId, null, ComparisonOperator.Equal, this.TowerTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGeneral_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralPicturesIncludedBooleanAnswerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.TowerTypeId, null, ComparisonOperator.Equal, this.TowerTypeId, "TowerTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralClaimRelevantBooleanAnswerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.TowerTypeId, null, ComparisonOperator.Equal, this.TowerTypeId, "TowerTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentGroupCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.ComponentGroupEntityUsingGeneralComponentGroupId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.TowerTypeId, null, ComparisonOperator.Equal, this.TowerTypeId, "TowerTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.TowerTypeId, null, ComparisonOperator.Equal, this.TowerTypeId, "TowerTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ControllerType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoControllerTypeCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.ControllerTypeEntityUsingGeneralControllerTypeId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.TowerTypeId, null, ComparisonOperator.Equal, this.TowerTypeId, "TowerTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearboxManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxManufacturerCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.GearboxManufacturerEntityUsingGeneralGearboxManufacturerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.TowerTypeId, null, ComparisonOperator.Equal, this.TowerTypeId, "TowerTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.GeneratorManufacturerEntityUsingGeneralGeneratorManufacturerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.TowerTypeId, null, ComparisonOperator.Equal, this.TowerTypeId, "TowerTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TowerHeight' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTowerHeightCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.TowerHeightEntityUsingGeneralTowerHeightId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.TowerTypeId, null, ComparisonOperator.Equal, this.TowerTypeId, "TowerTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TransformerManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTransformerManufacturerCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.TransformerManufacturerEntityUsingGeneralTransformerManufacturerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.TowerTypeId, null, ComparisonOperator.Equal, this.TowerTypeId, "TowerTypeEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TowerType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTowerType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TowerTypeFields.TowerTypeId, null, ComparisonOperator.Equal, this.ParentTowerTypeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.TowerTypeEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TowerTypeEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._towerType_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGeneral_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._componentGroupCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._controllerTypeCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._gearboxManufacturerCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._towerHeightCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._transformerManufacturerCollectionViaComponentInspectionReportGeneral);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReportGeneral = (EntityCollection<ComponentInspectionReportGeneralEntity>) collectionsQueue.Dequeue();
			this._towerType_ = (EntityCollection<TowerTypeEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGeneral_ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGeneral = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._componentGroupCollectionViaComponentInspectionReportGeneral = (EntityCollection<ComponentGroupEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGeneral = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._controllerTypeCollectionViaComponentInspectionReportGeneral = (EntityCollection<ControllerTypeEntity>) collectionsQueue.Dequeue();
			this._gearboxManufacturerCollectionViaComponentInspectionReportGeneral = (EntityCollection<GearboxManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGeneral = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._towerHeightCollectionViaComponentInspectionReportGeneral = (EntityCollection<TowerHeightEntity>) collectionsQueue.Dequeue();
			this._transformerManufacturerCollectionViaComponentInspectionReportGeneral = (EntityCollection<TransformerManufacturerEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReportGeneral != null)
			{
				return true;
			}
			if (this._towerType_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGeneral_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGeneral != null)
			{
				return true;
			}
			if (this._componentGroupCollectionViaComponentInspectionReportGeneral != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGeneral != null)
			{
				return true;
			}
			if (this._controllerTypeCollectionViaComponentInspectionReportGeneral != null)
			{
				return true;
			}
			if (this._gearboxManufacturerCollectionViaComponentInspectionReportGeneral != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGeneral != null)
			{
				return true;
			}
			if (this._towerHeightCollectionViaComponentInspectionReportGeneral != null)
			{
				return true;
			}
			if (this._transformerManufacturerCollectionViaComponentInspectionReportGeneral != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneralEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneralEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TowerTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TowerTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentGroupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ControllerTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ControllerTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearboxManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TowerHeightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TowerHeightEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TransformerManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TransformerManufacturerEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("TowerType", _towerType);
			toReturn.Add("ComponentInspectionReportGeneral", _componentInspectionReportGeneral);
			toReturn.Add("TowerType_", _towerType_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGeneral_", _booleanAnswerCollectionViaComponentInspectionReportGeneral_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGeneral", _booleanAnswerCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("ComponentGroupCollectionViaComponentInspectionReportGeneral", _componentGroupCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGeneral", _componentInspectionReportCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("ControllerTypeCollectionViaComponentInspectionReportGeneral", _controllerTypeCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("GearboxManufacturerCollectionViaComponentInspectionReportGeneral", _gearboxManufacturerCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGeneral", _generatorManufacturerCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("TowerHeightCollectionViaComponentInspectionReportGeneral", _towerHeightCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("TransformerManufacturerCollectionViaComponentInspectionReportGeneral", _transformerManufacturerCollectionViaComponentInspectionReportGeneral);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReportGeneral!=null)
			{
				_componentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_towerType_!=null)
			{
				_towerType_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGeneral_!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGeneral_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGeneral!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_componentGroupCollectionViaComponentInspectionReportGeneral!=null)
			{
				_componentGroupCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGeneral!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_controllerTypeCollectionViaComponentInspectionReportGeneral!=null)
			{
				_controllerTypeCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_gearboxManufacturerCollectionViaComponentInspectionReportGeneral!=null)
			{
				_gearboxManufacturerCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGeneral!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_towerHeightCollectionViaComponentInspectionReportGeneral!=null)
			{
				_towerHeightCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_transformerManufacturerCollectionViaComponentInspectionReportGeneral!=null)
			{
				_transformerManufacturerCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_towerType!=null)
			{
				_towerType.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReportGeneral = null;
			_towerType_ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGeneral_ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGeneral = null;
			_componentGroupCollectionViaComponentInspectionReportGeneral = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGeneral = null;
			_controllerTypeCollectionViaComponentInspectionReportGeneral = null;
			_gearboxManufacturerCollectionViaComponentInspectionReportGeneral = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGeneral = null;
			_towerHeightCollectionViaComponentInspectionReportGeneral = null;
			_transformerManufacturerCollectionViaComponentInspectionReportGeneral = null;
			_towerType = null;

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

			_fieldsCustomProperties.Add("TowerTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentTowerTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _towerType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTowerType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _towerType, new PropertyChangedEventHandler( OnTowerTypePropertyChanged ), "TowerType", TowerTypeEntity.Relations.TowerTypeEntityUsingTowerTypeIdParentTowerTypeId, true, signalRelatedEntity, "TowerType_", resetFKFields, new int[] { (int)TowerTypeFieldIndex.ParentTowerTypeId } );		
			_towerType = null;
		}

		/// <summary> setups the sync logic for member _towerType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTowerType(IEntity2 relatedEntity)
		{
			DesetupSyncTowerType(true, true);
			_towerType = (TowerTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _towerType, new PropertyChangedEventHandler( OnTowerTypePropertyChanged ), "TowerType", TowerTypeEntity.Relations.TowerTypeEntityUsingTowerTypeIdParentTowerTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTowerTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this TowerTypeEntity</param>
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
		public  static TowerTypeRelations Relations
		{
			get	{ return new TowerTypeRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGeneral' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGeneral
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGeneralEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneralEntityFactory))),
					TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, 0, null, null, null, null, "ComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TowerType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTowerType_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TowerTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TowerTypeEntityFactory))),
					TowerTypeEntity.Relations.TowerTypeEntityUsingParentTowerTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, 0, null, null, null, null, "TowerType_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGeneral_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralPicturesIncludedBooleanAnswerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGeneral_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralClaimRelevantBooleanAnswerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentGroup' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentGroupCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.ComponentGroupEntityUsingGeneralComponentGroupId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentGroupEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentGroupEntity, 0, null, null, relations, null, "ComponentGroupCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ControllerType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathControllerTypeCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.ControllerTypeEntityUsingGeneralControllerTypeId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ControllerTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ControllerTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.ControllerTypeEntity, 0, null, null, relations, null, "ControllerTypeCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearboxManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearboxManufacturerCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.GearboxManufacturerEntityUsingGeneralGearboxManufacturerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearboxManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxManufacturerEntity, 0, null, null, relations, null, "GearboxManufacturerCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.GeneratorManufacturerEntityUsingGeneralGeneratorManufacturerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TowerHeight' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTowerHeightCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.TowerHeightEntityUsingGeneralTowerHeightId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TowerHeightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TowerHeightEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.TowerHeightEntity, 0, null, null, relations, null, "TowerHeightCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TransformerManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTransformerManufacturerCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TowerTypeEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId, "TowerTypeEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.TransformerManufacturerEntityUsingGeneralTransformerManufacturerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TransformerManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TransformerManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, 0, null, null, relations, null, "TransformerManufacturerCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TowerType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTowerType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TowerTypeEntityFactory))),
					TowerTypeEntity.Relations.TowerTypeEntityUsingTowerTypeIdParentTowerTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, (int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, 0, null, null, null, null, "TowerType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TowerTypeEntity.CustomProperties;}
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
			get { return TowerTypeEntity.FieldsCustomProperties;}
		}

		/// <summary> The TowerTypeId property of the Entity TowerType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TowerType"."TowerTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 TowerTypeId
		{
			get { return (System.Int64)GetValue((int)TowerTypeFieldIndex.TowerTypeId, true); }
			set	{ SetValue((int)TowerTypeFieldIndex.TowerTypeId, value); }
		}

		/// <summary> The Name property of the Entity TowerType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TowerType"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)TowerTypeFieldIndex.Name, true); }
			set	{ SetValue((int)TowerTypeFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity TowerType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TowerType"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)TowerTypeFieldIndex.LanguageId, true); }
			set	{ SetValue((int)TowerTypeFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentTowerTypeId property of the Entity TowerType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TowerType"."ParentTowerTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentTowerTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TowerTypeFieldIndex.ParentTowerTypeId, false); }
			set	{ SetValue((int)TowerTypeFieldIndex.ParentTowerTypeId, value); }
		}

		/// <summary> The Sort property of the Entity TowerType<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TowerType"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)TowerTypeFieldIndex.Sort, true); }
			set	{ SetValue((int)TowerTypeFieldIndex.Sort, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneralEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneralEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneralEntity> ComponentInspectionReportGeneral
		{
			get
			{
				if(_componentInspectionReportGeneral==null)
				{
					_componentInspectionReportGeneral = new EntityCollection<ComponentInspectionReportGeneralEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneralEntityFactory)));
					_componentInspectionReportGeneral.SetContainingEntityInfo(this, "TowerType");
				}
				return _componentInspectionReportGeneral;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TowerTypeEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TowerTypeEntity))]
		public virtual EntityCollection<TowerTypeEntity> TowerType_
		{
			get
			{
				if(_towerType_==null)
				{
					_towerType_ = new EntityCollection<TowerTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TowerTypeEntityFactory)));
					_towerType_.SetContainingEntityInfo(this, "TowerType");
				}
				return _towerType_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGeneral_
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGeneral_==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGeneral_ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGeneral_.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGeneral_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGeneral==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGeneral = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGeneral.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGeneral;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentGroupEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentGroupEntity))]
		public virtual EntityCollection<ComponentGroupEntity> ComponentGroupCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				if(_componentGroupCollectionViaComponentInspectionReportGeneral==null)
				{
					_componentGroupCollectionViaComponentInspectionReportGeneral = new EntityCollection<ComponentGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentGroupEntityFactory)));
					_componentGroupCollectionViaComponentInspectionReportGeneral.IsReadOnly=true;
				}
				return _componentGroupCollectionViaComponentInspectionReportGeneral;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGeneral==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGeneral = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGeneral.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGeneral;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ControllerTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ControllerTypeEntity))]
		public virtual EntityCollection<ControllerTypeEntity> ControllerTypeCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				if(_controllerTypeCollectionViaComponentInspectionReportGeneral==null)
				{
					_controllerTypeCollectionViaComponentInspectionReportGeneral = new EntityCollection<ControllerTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ControllerTypeEntityFactory)));
					_controllerTypeCollectionViaComponentInspectionReportGeneral.IsReadOnly=true;
				}
				return _controllerTypeCollectionViaComponentInspectionReportGeneral;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearboxManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearboxManufacturerEntity))]
		public virtual EntityCollection<GearboxManufacturerEntity> GearboxManufacturerCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				if(_gearboxManufacturerCollectionViaComponentInspectionReportGeneral==null)
				{
					_gearboxManufacturerCollectionViaComponentInspectionReportGeneral = new EntityCollection<GearboxManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxManufacturerEntityFactory)));
					_gearboxManufacturerCollectionViaComponentInspectionReportGeneral.IsReadOnly=true;
				}
				return _gearboxManufacturerCollectionViaComponentInspectionReportGeneral;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGeneral==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGeneral = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGeneral.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGeneral;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TowerHeightEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TowerHeightEntity))]
		public virtual EntityCollection<TowerHeightEntity> TowerHeightCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				if(_towerHeightCollectionViaComponentInspectionReportGeneral==null)
				{
					_towerHeightCollectionViaComponentInspectionReportGeneral = new EntityCollection<TowerHeightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TowerHeightEntityFactory)));
					_towerHeightCollectionViaComponentInspectionReportGeneral.IsReadOnly=true;
				}
				return _towerHeightCollectionViaComponentInspectionReportGeneral;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TransformerManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TransformerManufacturerEntity))]
		public virtual EntityCollection<TransformerManufacturerEntity> TransformerManufacturerCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				if(_transformerManufacturerCollectionViaComponentInspectionReportGeneral==null)
				{
					_transformerManufacturerCollectionViaComponentInspectionReportGeneral = new EntityCollection<TransformerManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TransformerManufacturerEntityFactory)));
					_transformerManufacturerCollectionViaComponentInspectionReportGeneral.IsReadOnly=true;
				}
				return _transformerManufacturerCollectionViaComponentInspectionReportGeneral;
			}
		}

		/// <summary> Gets / sets related entity of type 'TowerTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TowerTypeEntity TowerType
		{
			get
			{
				return _towerType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTowerType(value);
				}
				else
				{
					if(value==null)
					{
						if(_towerType != null)
						{
							_towerType.UnsetRelatedEntity(this, "TowerType_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TowerType_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity; }
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
