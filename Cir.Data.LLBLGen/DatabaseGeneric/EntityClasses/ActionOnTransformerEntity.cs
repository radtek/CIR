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
	/// Entity class which represents the entity 'ActionOnTransformer'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ActionOnTransformerEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ActionOnTransformerEntity> _actionOnTransformer_;
		private EntityCollection<ComponentInspectionReportTransformerEntity> _componentInspectionReportTransformer;
		private EntityCollection<ArcDetectionEntity> _arcDetectionCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<BracketsEntity> _bracketsCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<CableConditionEntity> _cableConditionCollectionViaComponentInspectionReportTransformer_;
		private EntityCollection<CableConditionEntity> _cableConditionCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<ClimateEntity> _climateCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<CoilConditionEntity> _coilConditionCollectionViaComponentInspectionReportTransformer_;
		private EntityCollection<CoilConditionEntity> _coilConditionCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<ConnectionBarsEntity> _connectionBarsCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<SurgeArrestorEntity> _surgeArrestorCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<TransformerManufacturerEntity> _transformerManufacturerCollectionViaComponentInspectionReportTransformer;
		private ActionOnTransformerEntity _actionOnTransformer;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name ActionOnTransformer</summary>
			public static readonly string ActionOnTransformer = "ActionOnTransformer";
			/// <summary>Member name ActionOnTransformer_</summary>
			public static readonly string ActionOnTransformer_ = "ActionOnTransformer_";
			/// <summary>Member name ComponentInspectionReportTransformer</summary>
			public static readonly string ComponentInspectionReportTransformer = "ComponentInspectionReportTransformer";
			/// <summary>Member name ArcDetectionCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string ArcDetectionCollectionViaComponentInspectionReportTransformer = "ArcDetectionCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportTransformer = "BooleanAnswerCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name BracketsCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string BracketsCollectionViaComponentInspectionReportTransformer = "BracketsCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name CableConditionCollectionViaComponentInspectionReportTransformer_</summary>
			public static readonly string CableConditionCollectionViaComponentInspectionReportTransformer_ = "CableConditionCollectionViaComponentInspectionReportTransformer_";
			/// <summary>Member name CableConditionCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string CableConditionCollectionViaComponentInspectionReportTransformer = "CableConditionCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name ClimateCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string ClimateCollectionViaComponentInspectionReportTransformer = "ClimateCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name CoilConditionCollectionViaComponentInspectionReportTransformer_</summary>
			public static readonly string CoilConditionCollectionViaComponentInspectionReportTransformer_ = "CoilConditionCollectionViaComponentInspectionReportTransformer_";
			/// <summary>Member name CoilConditionCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string CoilConditionCollectionViaComponentInspectionReportTransformer = "CoilConditionCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportTransformer = "ComponentInspectionReportCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name ConnectionBarsCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string ConnectionBarsCollectionViaComponentInspectionReportTransformer = "ConnectionBarsCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name SurgeArrestorCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string SurgeArrestorCollectionViaComponentInspectionReportTransformer = "SurgeArrestorCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name TransformerManufacturerCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string TransformerManufacturerCollectionViaComponentInspectionReportTransformer = "TransformerManufacturerCollectionViaComponentInspectionReportTransformer";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ActionOnTransformerEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ActionOnTransformerEntity():base("ActionOnTransformerEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ActionOnTransformerEntity(IEntityFields2 fields):base("ActionOnTransformerEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ActionOnTransformerEntity</param>
		public ActionOnTransformerEntity(IValidator validator):base("ActionOnTransformerEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="actionOnTransformerId">PK value for ActionOnTransformer which data should be fetched into this ActionOnTransformer object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ActionOnTransformerEntity(System.Int64 actionOnTransformerId):base("ActionOnTransformerEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ActionOnTransformerId = actionOnTransformerId;
		}

		/// <summary> CTor</summary>
		/// <param name="actionOnTransformerId">PK value for ActionOnTransformer which data should be fetched into this ActionOnTransformer object</param>
		/// <param name="validator">The custom validator object for this ActionOnTransformerEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ActionOnTransformerEntity(System.Int64 actionOnTransformerId, IValidator validator):base("ActionOnTransformerEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ActionOnTransformerId = actionOnTransformerId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ActionOnTransformerEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_actionOnTransformer_ = (EntityCollection<ActionOnTransformerEntity>)info.GetValue("_actionOnTransformer_", typeof(EntityCollection<ActionOnTransformerEntity>));
				_componentInspectionReportTransformer = (EntityCollection<ComponentInspectionReportTransformerEntity>)info.GetValue("_componentInspectionReportTransformer", typeof(EntityCollection<ComponentInspectionReportTransformerEntity>));
				_arcDetectionCollectionViaComponentInspectionReportTransformer = (EntityCollection<ArcDetectionEntity>)info.GetValue("_arcDetectionCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<ArcDetectionEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportTransformer = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<BooleanAnswerEntity>));
				_bracketsCollectionViaComponentInspectionReportTransformer = (EntityCollection<BracketsEntity>)info.GetValue("_bracketsCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<BracketsEntity>));
				_cableConditionCollectionViaComponentInspectionReportTransformer_ = (EntityCollection<CableConditionEntity>)info.GetValue("_cableConditionCollectionViaComponentInspectionReportTransformer_", typeof(EntityCollection<CableConditionEntity>));
				_cableConditionCollectionViaComponentInspectionReportTransformer = (EntityCollection<CableConditionEntity>)info.GetValue("_cableConditionCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<CableConditionEntity>));
				_climateCollectionViaComponentInspectionReportTransformer = (EntityCollection<ClimateEntity>)info.GetValue("_climateCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<ClimateEntity>));
				_coilConditionCollectionViaComponentInspectionReportTransformer_ = (EntityCollection<CoilConditionEntity>)info.GetValue("_coilConditionCollectionViaComponentInspectionReportTransformer_", typeof(EntityCollection<CoilConditionEntity>));
				_coilConditionCollectionViaComponentInspectionReportTransformer = (EntityCollection<CoilConditionEntity>)info.GetValue("_coilConditionCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<CoilConditionEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportTransformer = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_connectionBarsCollectionViaComponentInspectionReportTransformer = (EntityCollection<ConnectionBarsEntity>)info.GetValue("_connectionBarsCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<ConnectionBarsEntity>));
				_surgeArrestorCollectionViaComponentInspectionReportTransformer = (EntityCollection<SurgeArrestorEntity>)info.GetValue("_surgeArrestorCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<SurgeArrestorEntity>));
				_transformerManufacturerCollectionViaComponentInspectionReportTransformer = (EntityCollection<TransformerManufacturerEntity>)info.GetValue("_transformerManufacturerCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<TransformerManufacturerEntity>));
				_actionOnTransformer = (ActionOnTransformerEntity)info.GetValue("_actionOnTransformer", typeof(ActionOnTransformerEntity));
				if(_actionOnTransformer!=null)
				{
					_actionOnTransformer.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ActionOnTransformerFieldIndex)fieldIndex)
			{
				case ActionOnTransformerFieldIndex.ParentActionOnTransformerId:
					DesetupSyncActionOnTransformer(true, false);
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
				case "ActionOnTransformer":
					this.ActionOnTransformer = (ActionOnTransformerEntity)entity;
					break;
				case "ActionOnTransformer_":
					this.ActionOnTransformer_.Add((ActionOnTransformerEntity)entity);
					break;
				case "ComponentInspectionReportTransformer":
					this.ComponentInspectionReportTransformer.Add((ComponentInspectionReportTransformerEntity)entity);
					break;
				case "ArcDetectionCollectionViaComponentInspectionReportTransformer":
					this.ArcDetectionCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.ArcDetectionCollectionViaComponentInspectionReportTransformer.Add((ArcDetectionEntity)entity);
					this.ArcDetectionCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportTransformer":
					this.BooleanAnswerCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportTransformer.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
					break;
				case "BracketsCollectionViaComponentInspectionReportTransformer":
					this.BracketsCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.BracketsCollectionViaComponentInspectionReportTransformer.Add((BracketsEntity)entity);
					this.BracketsCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
					break;
				case "CableConditionCollectionViaComponentInspectionReportTransformer_":
					this.CableConditionCollectionViaComponentInspectionReportTransformer_.IsReadOnly = false;
					this.CableConditionCollectionViaComponentInspectionReportTransformer_.Add((CableConditionEntity)entity);
					this.CableConditionCollectionViaComponentInspectionReportTransformer_.IsReadOnly = true;
					break;
				case "CableConditionCollectionViaComponentInspectionReportTransformer":
					this.CableConditionCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.CableConditionCollectionViaComponentInspectionReportTransformer.Add((CableConditionEntity)entity);
					this.CableConditionCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
					break;
				case "ClimateCollectionViaComponentInspectionReportTransformer":
					this.ClimateCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.ClimateCollectionViaComponentInspectionReportTransformer.Add((ClimateEntity)entity);
					this.ClimateCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
					break;
				case "CoilConditionCollectionViaComponentInspectionReportTransformer_":
					this.CoilConditionCollectionViaComponentInspectionReportTransformer_.IsReadOnly = false;
					this.CoilConditionCollectionViaComponentInspectionReportTransformer_.Add((CoilConditionEntity)entity);
					this.CoilConditionCollectionViaComponentInspectionReportTransformer_.IsReadOnly = true;
					break;
				case "CoilConditionCollectionViaComponentInspectionReportTransformer":
					this.CoilConditionCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.CoilConditionCollectionViaComponentInspectionReportTransformer.Add((CoilConditionEntity)entity);
					this.CoilConditionCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportTransformer":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportTransformer.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
					break;
				case "ConnectionBarsCollectionViaComponentInspectionReportTransformer":
					this.ConnectionBarsCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.ConnectionBarsCollectionViaComponentInspectionReportTransformer.Add((ConnectionBarsEntity)entity);
					this.ConnectionBarsCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
					break;
				case "SurgeArrestorCollectionViaComponentInspectionReportTransformer":
					this.SurgeArrestorCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.SurgeArrestorCollectionViaComponentInspectionReportTransformer.Add((SurgeArrestorEntity)entity);
					this.SurgeArrestorCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
					break;
				case "TransformerManufacturerCollectionViaComponentInspectionReportTransformer":
					this.TransformerManufacturerCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.TransformerManufacturerCollectionViaComponentInspectionReportTransformer.Add((TransformerManufacturerEntity)entity);
					this.TransformerManufacturerCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
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
				case "ActionOnTransformer":
					SetupSyncActionOnTransformer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ActionOnTransformer_":
					this.ActionOnTransformer_.Add((ActionOnTransformerEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportTransformer":
					this.ComponentInspectionReportTransformer.Add((ComponentInspectionReportTransformerEntity)relatedEntity);
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
				case "ActionOnTransformer":
					DesetupSyncActionOnTransformer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ActionOnTransformer_":
					base.PerformRelatedEntityRemoval(this.ActionOnTransformer_, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportTransformer":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportTransformer, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_actionOnTransformer!=null)
			{
				toReturn.Add(_actionOnTransformer);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ActionOnTransformer_);
			toReturn.Add(this.ComponentInspectionReportTransformer);

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
				info.AddValue("_actionOnTransformer_", ((_actionOnTransformer_!=null) && (_actionOnTransformer_.Count>0) && !this.MarkedForDeletion)?_actionOnTransformer_:null);
				info.AddValue("_componentInspectionReportTransformer", ((_componentInspectionReportTransformer!=null) && (_componentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportTransformer:null);
				info.AddValue("_arcDetectionCollectionViaComponentInspectionReportTransformer", ((_arcDetectionCollectionViaComponentInspectionReportTransformer!=null) && (_arcDetectionCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_arcDetectionCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportTransformer", ((_booleanAnswerCollectionViaComponentInspectionReportTransformer!=null) && (_booleanAnswerCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_bracketsCollectionViaComponentInspectionReportTransformer", ((_bracketsCollectionViaComponentInspectionReportTransformer!=null) && (_bracketsCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_bracketsCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_cableConditionCollectionViaComponentInspectionReportTransformer_", ((_cableConditionCollectionViaComponentInspectionReportTransformer_!=null) && (_cableConditionCollectionViaComponentInspectionReportTransformer_.Count>0) && !this.MarkedForDeletion)?_cableConditionCollectionViaComponentInspectionReportTransformer_:null);
				info.AddValue("_cableConditionCollectionViaComponentInspectionReportTransformer", ((_cableConditionCollectionViaComponentInspectionReportTransformer!=null) && (_cableConditionCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_cableConditionCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_climateCollectionViaComponentInspectionReportTransformer", ((_climateCollectionViaComponentInspectionReportTransformer!=null) && (_climateCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_climateCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_coilConditionCollectionViaComponentInspectionReportTransformer_", ((_coilConditionCollectionViaComponentInspectionReportTransformer_!=null) && (_coilConditionCollectionViaComponentInspectionReportTransformer_.Count>0) && !this.MarkedForDeletion)?_coilConditionCollectionViaComponentInspectionReportTransformer_:null);
				info.AddValue("_coilConditionCollectionViaComponentInspectionReportTransformer", ((_coilConditionCollectionViaComponentInspectionReportTransformer!=null) && (_coilConditionCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_coilConditionCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportTransformer", ((_componentInspectionReportCollectionViaComponentInspectionReportTransformer!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_connectionBarsCollectionViaComponentInspectionReportTransformer", ((_connectionBarsCollectionViaComponentInspectionReportTransformer!=null) && (_connectionBarsCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_connectionBarsCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_surgeArrestorCollectionViaComponentInspectionReportTransformer", ((_surgeArrestorCollectionViaComponentInspectionReportTransformer!=null) && (_surgeArrestorCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_surgeArrestorCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_transformerManufacturerCollectionViaComponentInspectionReportTransformer", ((_transformerManufacturerCollectionViaComponentInspectionReportTransformer!=null) && (_transformerManufacturerCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_transformerManufacturerCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_actionOnTransformer", (!this.MarkedForDeletion?_actionOnTransformer:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ActionOnTransformerFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ActionOnTransformerFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ActionOnTransformerRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionOnTransformer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionOnTransformer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ParentActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportTransformer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ArcDetection' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoArcDetectionCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.ArcDetectionEntityUsingTransformerArcDetectionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.BooleanAnswerEntityUsingTransformerClaimRelevantBooleanAnswerId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Brackets' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBracketsCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.BracketsEntityUsingBracketsId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CableCondition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCableConditionCollectionViaComponentInspectionReportTransformer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingLvcableConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CableCondition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCableConditionCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingHvcableConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Climate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClimateCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.ClimateEntityUsingClimateId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CoilCondition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCoilConditionCollectionViaComponentInspectionReportTransformer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingLvcoilConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CoilCondition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCoilConditionCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingHvcoilConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ConnectionBars' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoConnectionBarsCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.ConnectionBarsEntityUsingConnectionBarsId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurgeArrestor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurgeArrestorCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.SurgeArrestorEntityUsingSurgeArrestorId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TransformerManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTransformerManufacturerCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.TransformerManufacturerEntityUsingTransformerManufacturerId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ActionOnTransformerId, "ActionOnTransformerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ActionOnTransformer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionOnTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ActionOnTransformerFields.ActionOnTransformerId, null, ComparisonOperator.Equal, this.ParentActionOnTransformerId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ActionOnTransformerEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._actionOnTransformer_);
			collectionsQueue.Enqueue(this._componentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._arcDetectionCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._bracketsCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._cableConditionCollectionViaComponentInspectionReportTransformer_);
			collectionsQueue.Enqueue(this._cableConditionCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._climateCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._coilConditionCollectionViaComponentInspectionReportTransformer_);
			collectionsQueue.Enqueue(this._coilConditionCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._connectionBarsCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._surgeArrestorCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._transformerManufacturerCollectionViaComponentInspectionReportTransformer);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._actionOnTransformer_ = (EntityCollection<ActionOnTransformerEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportTransformer = (EntityCollection<ComponentInspectionReportTransformerEntity>) collectionsQueue.Dequeue();
			this._arcDetectionCollectionViaComponentInspectionReportTransformer = (EntityCollection<ArcDetectionEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportTransformer = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._bracketsCollectionViaComponentInspectionReportTransformer = (EntityCollection<BracketsEntity>) collectionsQueue.Dequeue();
			this._cableConditionCollectionViaComponentInspectionReportTransformer_ = (EntityCollection<CableConditionEntity>) collectionsQueue.Dequeue();
			this._cableConditionCollectionViaComponentInspectionReportTransformer = (EntityCollection<CableConditionEntity>) collectionsQueue.Dequeue();
			this._climateCollectionViaComponentInspectionReportTransformer = (EntityCollection<ClimateEntity>) collectionsQueue.Dequeue();
			this._coilConditionCollectionViaComponentInspectionReportTransformer_ = (EntityCollection<CoilConditionEntity>) collectionsQueue.Dequeue();
			this._coilConditionCollectionViaComponentInspectionReportTransformer = (EntityCollection<CoilConditionEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportTransformer = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._connectionBarsCollectionViaComponentInspectionReportTransformer = (EntityCollection<ConnectionBarsEntity>) collectionsQueue.Dequeue();
			this._surgeArrestorCollectionViaComponentInspectionReportTransformer = (EntityCollection<SurgeArrestorEntity>) collectionsQueue.Dequeue();
			this._transformerManufacturerCollectionViaComponentInspectionReportTransformer = (EntityCollection<TransformerManufacturerEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._actionOnTransformer_ != null)
			{
				return true;
			}
			if (this._componentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._arcDetectionCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._bracketsCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._cableConditionCollectionViaComponentInspectionReportTransformer_ != null)
			{
				return true;
			}
			if (this._cableConditionCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._climateCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._coilConditionCollectionViaComponentInspectionReportTransformer_ != null)
			{
				return true;
			}
			if (this._coilConditionCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._connectionBarsCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._surgeArrestorCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._transformerManufacturerCollectionViaComponentInspectionReportTransformer != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionOnTransformerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionOnTransformerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportTransformerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTransformerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ArcDetectionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ArcDetectionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BracketsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BracketsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CableConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CableConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClimateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClimateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CoilConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CoilConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ConnectionBarsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ConnectionBarsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurgeArrestorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurgeArrestorEntityFactory))) : null);
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
			toReturn.Add("ActionOnTransformer", _actionOnTransformer);
			toReturn.Add("ActionOnTransformer_", _actionOnTransformer_);
			toReturn.Add("ComponentInspectionReportTransformer", _componentInspectionReportTransformer);
			toReturn.Add("ArcDetectionCollectionViaComponentInspectionReportTransformer", _arcDetectionCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportTransformer", _booleanAnswerCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("BracketsCollectionViaComponentInspectionReportTransformer", _bracketsCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("CableConditionCollectionViaComponentInspectionReportTransformer_", _cableConditionCollectionViaComponentInspectionReportTransformer_);
			toReturn.Add("CableConditionCollectionViaComponentInspectionReportTransformer", _cableConditionCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("ClimateCollectionViaComponentInspectionReportTransformer", _climateCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("CoilConditionCollectionViaComponentInspectionReportTransformer_", _coilConditionCollectionViaComponentInspectionReportTransformer_);
			toReturn.Add("CoilConditionCollectionViaComponentInspectionReportTransformer", _coilConditionCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportTransformer", _componentInspectionReportCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("ConnectionBarsCollectionViaComponentInspectionReportTransformer", _connectionBarsCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("SurgeArrestorCollectionViaComponentInspectionReportTransformer", _surgeArrestorCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("TransformerManufacturerCollectionViaComponentInspectionReportTransformer", _transformerManufacturerCollectionViaComponentInspectionReportTransformer);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_actionOnTransformer_!=null)
			{
				_actionOnTransformer_.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportTransformer!=null)
			{
				_componentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_arcDetectionCollectionViaComponentInspectionReportTransformer!=null)
			{
				_arcDetectionCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportTransformer!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_bracketsCollectionViaComponentInspectionReportTransformer!=null)
			{
				_bracketsCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_cableConditionCollectionViaComponentInspectionReportTransformer_!=null)
			{
				_cableConditionCollectionViaComponentInspectionReportTransformer_.ActiveContext = base.ActiveContext;
			}
			if(_cableConditionCollectionViaComponentInspectionReportTransformer!=null)
			{
				_cableConditionCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_climateCollectionViaComponentInspectionReportTransformer!=null)
			{
				_climateCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_coilConditionCollectionViaComponentInspectionReportTransformer_!=null)
			{
				_coilConditionCollectionViaComponentInspectionReportTransformer_.ActiveContext = base.ActiveContext;
			}
			if(_coilConditionCollectionViaComponentInspectionReportTransformer!=null)
			{
				_coilConditionCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportTransformer!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_connectionBarsCollectionViaComponentInspectionReportTransformer!=null)
			{
				_connectionBarsCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_surgeArrestorCollectionViaComponentInspectionReportTransformer!=null)
			{
				_surgeArrestorCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_transformerManufacturerCollectionViaComponentInspectionReportTransformer!=null)
			{
				_transformerManufacturerCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_actionOnTransformer!=null)
			{
				_actionOnTransformer.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_actionOnTransformer_ = null;
			_componentInspectionReportTransformer = null;
			_arcDetectionCollectionViaComponentInspectionReportTransformer = null;
			_booleanAnswerCollectionViaComponentInspectionReportTransformer = null;
			_bracketsCollectionViaComponentInspectionReportTransformer = null;
			_cableConditionCollectionViaComponentInspectionReportTransformer_ = null;
			_cableConditionCollectionViaComponentInspectionReportTransformer = null;
			_climateCollectionViaComponentInspectionReportTransformer = null;
			_coilConditionCollectionViaComponentInspectionReportTransformer_ = null;
			_coilConditionCollectionViaComponentInspectionReportTransformer = null;
			_componentInspectionReportCollectionViaComponentInspectionReportTransformer = null;
			_connectionBarsCollectionViaComponentInspectionReportTransformer = null;
			_surgeArrestorCollectionViaComponentInspectionReportTransformer = null;
			_transformerManufacturerCollectionViaComponentInspectionReportTransformer = null;
			_actionOnTransformer = null;

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

			_fieldsCustomProperties.Add("ActionOnTransformerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentActionOnTransformerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _actionOnTransformer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncActionOnTransformer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _actionOnTransformer, new PropertyChangedEventHandler( OnActionOnTransformerPropertyChanged ), "ActionOnTransformer", ActionOnTransformerEntity.Relations.ActionOnTransformerEntityUsingActionOnTransformerIdParentActionOnTransformerId, true, signalRelatedEntity, "ActionOnTransformer_", resetFKFields, new int[] { (int)ActionOnTransformerFieldIndex.ParentActionOnTransformerId } );		
			_actionOnTransformer = null;
		}

		/// <summary> setups the sync logic for member _actionOnTransformer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncActionOnTransformer(IEntity2 relatedEntity)
		{
			DesetupSyncActionOnTransformer(true, true);
			_actionOnTransformer = (ActionOnTransformerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _actionOnTransformer, new PropertyChangedEventHandler( OnActionOnTransformerPropertyChanged ), "ActionOnTransformer", ActionOnTransformerEntity.Relations.ActionOnTransformerEntityUsingActionOnTransformerIdParentActionOnTransformerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnActionOnTransformerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ActionOnTransformerEntity</param>
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
		public  static ActionOnTransformerRelations Relations
		{
			get	{ return new ActionOnTransformerRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionOnTransformer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionOnTransformer_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ActionOnTransformerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionOnTransformerEntityFactory))),
					ActionOnTransformerEntity.Relations.ActionOnTransformerEntityUsingParentActionOnTransformerId, 
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, 0, null, null, null, null, "ActionOnTransformer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportTransformer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportTransformer
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportTransformerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTransformerEntityFactory))),
					ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, 
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, 0, null, null, null, null, "ComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ArcDetection' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathArcDetectionCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.ArcDetectionEntityUsingTransformerArcDetectionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ArcDetectionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ArcDetectionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ArcDetectionEntity, 0, null, null, relations, null, "ArcDetectionCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.BooleanAnswerEntityUsingTransformerClaimRelevantBooleanAnswerId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Brackets' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBracketsCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.BracketsEntityUsingBracketsId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BracketsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BracketsEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.BracketsEntity, 0, null, null, relations, null, "BracketsCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CableCondition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCableConditionCollectionViaComponentInspectionReportTransformer_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingLvcableConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CableConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.CableConditionEntity, 0, null, null, relations, null, "CableConditionCollectionViaComponentInspectionReportTransformer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CableCondition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCableConditionCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingHvcableConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CableConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.CableConditionEntity, 0, null, null, relations, null, "CableConditionCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Climate' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathClimateCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.ClimateEntityUsingClimateId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ClimateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClimateEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ClimateEntity, 0, null, null, relations, null, "ClimateCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CoilCondition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCoilConditionCollectionViaComponentInspectionReportTransformer_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingLvcoilConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CoilConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.CoilConditionEntity, 0, null, null, relations, null, "CoilConditionCollectionViaComponentInspectionReportTransformer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CoilCondition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCoilConditionCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingHvcoilConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CoilConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.CoilConditionEntity, 0, null, null, relations, null, "CoilConditionCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ConnectionBars' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathConnectionBarsCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.ConnectionBarsEntityUsingConnectionBarsId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ConnectionBarsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ConnectionBarsEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ConnectionBarsEntity, 0, null, null, relations, null, "ConnectionBarsCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SurgeArrestor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSurgeArrestorCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.SurgeArrestorEntityUsingSurgeArrestorId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<SurgeArrestorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurgeArrestorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.SurgeArrestorEntity, 0, null, null, relations, null, "SurgeArrestorCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TransformerManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTransformerManufacturerCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(ActionOnTransformerEntity.Relations.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId, "ActionOnTransformerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.TransformerManufacturerEntityUsingTransformerManufacturerId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TransformerManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TransformerManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, 0, null, null, relations, null, "TransformerManufacturerCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionOnTransformer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionOnTransformer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ActionOnTransformerEntityFactory))),
					ActionOnTransformerEntity.Relations.ActionOnTransformerEntityUsingActionOnTransformerIdParentActionOnTransformerId, 
					(int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, (int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, 0, null, null, null, null, "ActionOnTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ActionOnTransformerEntity.CustomProperties;}
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
			get { return ActionOnTransformerEntity.FieldsCustomProperties;}
		}

		/// <summary> The ActionOnTransformerId property of the Entity ActionOnTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ActionOnTransformer"."ActionOnTransformerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ActionOnTransformerId
		{
			get { return (System.Int64)GetValue((int)ActionOnTransformerFieldIndex.ActionOnTransformerId, true); }
			set	{ SetValue((int)ActionOnTransformerFieldIndex.ActionOnTransformerId, value); }
		}

		/// <summary> The Name property of the Entity ActionOnTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ActionOnTransformer"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)ActionOnTransformerFieldIndex.Name, true); }
			set	{ SetValue((int)ActionOnTransformerFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity ActionOnTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ActionOnTransformer"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)ActionOnTransformerFieldIndex.LanguageId, true); }
			set	{ SetValue((int)ActionOnTransformerFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentActionOnTransformerId property of the Entity ActionOnTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ActionOnTransformer"."ParentActionOnTransformerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentActionOnTransformerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ActionOnTransformerFieldIndex.ParentActionOnTransformerId, false); }
			set	{ SetValue((int)ActionOnTransformerFieldIndex.ParentActionOnTransformerId, value); }
		}

		/// <summary> The Sort property of the Entity ActionOnTransformer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ActionOnTransformer"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)ActionOnTransformerFieldIndex.Sort, true); }
			set	{ SetValue((int)ActionOnTransformerFieldIndex.Sort, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionOnTransformerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionOnTransformerEntity))]
		public virtual EntityCollection<ActionOnTransformerEntity> ActionOnTransformer_
		{
			get
			{
				if(_actionOnTransformer_==null)
				{
					_actionOnTransformer_ = new EntityCollection<ActionOnTransformerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionOnTransformerEntityFactory)));
					_actionOnTransformer_.SetContainingEntityInfo(this, "ActionOnTransformer");
				}
				return _actionOnTransformer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportTransformerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportTransformerEntity))]
		public virtual EntityCollection<ComponentInspectionReportTransformerEntity> ComponentInspectionReportTransformer
		{
			get
			{
				if(_componentInspectionReportTransformer==null)
				{
					_componentInspectionReportTransformer = new EntityCollection<ComponentInspectionReportTransformerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTransformerEntityFactory)));
					_componentInspectionReportTransformer.SetContainingEntityInfo(this, "ActionOnTransformer");
				}
				return _componentInspectionReportTransformer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ArcDetectionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ArcDetectionEntity))]
		public virtual EntityCollection<ArcDetectionEntity> ArcDetectionCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				if(_arcDetectionCollectionViaComponentInspectionReportTransformer==null)
				{
					_arcDetectionCollectionViaComponentInspectionReportTransformer = new EntityCollection<ArcDetectionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ArcDetectionEntityFactory)));
					_arcDetectionCollectionViaComponentInspectionReportTransformer.IsReadOnly=true;
				}
				return _arcDetectionCollectionViaComponentInspectionReportTransformer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportTransformer==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportTransformer = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportTransformer.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportTransformer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BracketsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BracketsEntity))]
		public virtual EntityCollection<BracketsEntity> BracketsCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				if(_bracketsCollectionViaComponentInspectionReportTransformer==null)
				{
					_bracketsCollectionViaComponentInspectionReportTransformer = new EntityCollection<BracketsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BracketsEntityFactory)));
					_bracketsCollectionViaComponentInspectionReportTransformer.IsReadOnly=true;
				}
				return _bracketsCollectionViaComponentInspectionReportTransformer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CableConditionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CableConditionEntity))]
		public virtual EntityCollection<CableConditionEntity> CableConditionCollectionViaComponentInspectionReportTransformer_
		{
			get
			{
				if(_cableConditionCollectionViaComponentInspectionReportTransformer_==null)
				{
					_cableConditionCollectionViaComponentInspectionReportTransformer_ = new EntityCollection<CableConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory)));
					_cableConditionCollectionViaComponentInspectionReportTransformer_.IsReadOnly=true;
				}
				return _cableConditionCollectionViaComponentInspectionReportTransformer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CableConditionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CableConditionEntity))]
		public virtual EntityCollection<CableConditionEntity> CableConditionCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				if(_cableConditionCollectionViaComponentInspectionReportTransformer==null)
				{
					_cableConditionCollectionViaComponentInspectionReportTransformer = new EntityCollection<CableConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory)));
					_cableConditionCollectionViaComponentInspectionReportTransformer.IsReadOnly=true;
				}
				return _cableConditionCollectionViaComponentInspectionReportTransformer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ClimateEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ClimateEntity))]
		public virtual EntityCollection<ClimateEntity> ClimateCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				if(_climateCollectionViaComponentInspectionReportTransformer==null)
				{
					_climateCollectionViaComponentInspectionReportTransformer = new EntityCollection<ClimateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClimateEntityFactory)));
					_climateCollectionViaComponentInspectionReportTransformer.IsReadOnly=true;
				}
				return _climateCollectionViaComponentInspectionReportTransformer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CoilConditionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CoilConditionEntity))]
		public virtual EntityCollection<CoilConditionEntity> CoilConditionCollectionViaComponentInspectionReportTransformer_
		{
			get
			{
				if(_coilConditionCollectionViaComponentInspectionReportTransformer_==null)
				{
					_coilConditionCollectionViaComponentInspectionReportTransformer_ = new EntityCollection<CoilConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory)));
					_coilConditionCollectionViaComponentInspectionReportTransformer_.IsReadOnly=true;
				}
				return _coilConditionCollectionViaComponentInspectionReportTransformer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CoilConditionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CoilConditionEntity))]
		public virtual EntityCollection<CoilConditionEntity> CoilConditionCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				if(_coilConditionCollectionViaComponentInspectionReportTransformer==null)
				{
					_coilConditionCollectionViaComponentInspectionReportTransformer = new EntityCollection<CoilConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory)));
					_coilConditionCollectionViaComponentInspectionReportTransformer.IsReadOnly=true;
				}
				return _coilConditionCollectionViaComponentInspectionReportTransformer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportTransformer==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportTransformer = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportTransformer.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportTransformer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ConnectionBarsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ConnectionBarsEntity))]
		public virtual EntityCollection<ConnectionBarsEntity> ConnectionBarsCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				if(_connectionBarsCollectionViaComponentInspectionReportTransformer==null)
				{
					_connectionBarsCollectionViaComponentInspectionReportTransformer = new EntityCollection<ConnectionBarsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ConnectionBarsEntityFactory)));
					_connectionBarsCollectionViaComponentInspectionReportTransformer.IsReadOnly=true;
				}
				return _connectionBarsCollectionViaComponentInspectionReportTransformer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SurgeArrestorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SurgeArrestorEntity))]
		public virtual EntityCollection<SurgeArrestorEntity> SurgeArrestorCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				if(_surgeArrestorCollectionViaComponentInspectionReportTransformer==null)
				{
					_surgeArrestorCollectionViaComponentInspectionReportTransformer = new EntityCollection<SurgeArrestorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurgeArrestorEntityFactory)));
					_surgeArrestorCollectionViaComponentInspectionReportTransformer.IsReadOnly=true;
				}
				return _surgeArrestorCollectionViaComponentInspectionReportTransformer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TransformerManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TransformerManufacturerEntity))]
		public virtual EntityCollection<TransformerManufacturerEntity> TransformerManufacturerCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				if(_transformerManufacturerCollectionViaComponentInspectionReportTransformer==null)
				{
					_transformerManufacturerCollectionViaComponentInspectionReportTransformer = new EntityCollection<TransformerManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TransformerManufacturerEntityFactory)));
					_transformerManufacturerCollectionViaComponentInspectionReportTransformer.IsReadOnly=true;
				}
				return _transformerManufacturerCollectionViaComponentInspectionReportTransformer;
			}
		}

		/// <summary> Gets / sets related entity of type 'ActionOnTransformerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ActionOnTransformerEntity ActionOnTransformer
		{
			get
			{
				return _actionOnTransformer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncActionOnTransformer(value);
				}
				else
				{
					if(value==null)
					{
						if(_actionOnTransformer != null)
						{
							_actionOnTransformer.UnsetRelatedEntity(this, "ActionOnTransformer_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ActionOnTransformer_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity; }
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
