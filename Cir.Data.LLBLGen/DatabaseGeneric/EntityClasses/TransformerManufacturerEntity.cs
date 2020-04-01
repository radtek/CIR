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
	/// Entity class which represents the entity 'TransformerManufacturer'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TransformerManufacturerEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportGeneralEntity> _componentInspectionReportGeneral;
		private EntityCollection<ComponentInspectionReportTransformerEntity> _componentInspectionReportTransformer;
		private EntityCollection<TransformerManufacturerEntity> _transformerManufacturer_;
		private EntityCollection<ActionOnTransformerEntity> _actionOnTransformerCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<ArcDetectionEntity> _arcDetectionCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGeneral_;
		private EntityCollection<BracketsEntity> _bracketsCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<CableConditionEntity> _cableConditionCollectionViaComponentInspectionReportTransformer_;
		private EntityCollection<CableConditionEntity> _cableConditionCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<ClimateEntity> _climateCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<CoilConditionEntity> _coilConditionCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<CoilConditionEntity> _coilConditionCollectionViaComponentInspectionReportTransformer_;
		private EntityCollection<ComponentGroupEntity> _componentGroupCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<ConnectionBarsEntity> _connectionBarsCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<ControllerTypeEntity> _controllerTypeCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<GearboxManufacturerEntity> _gearboxManufacturerCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<SurgeArrestorEntity> _surgeArrestorCollectionViaComponentInspectionReportTransformer;
		private EntityCollection<TowerHeightEntity> _towerHeightCollectionViaComponentInspectionReportGeneral;
		private EntityCollection<TowerTypeEntity> _towerTypeCollectionViaComponentInspectionReportGeneral;
		private TransformerManufacturerEntity _transformerManufacturer;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name TransformerManufacturer</summary>
			public static readonly string TransformerManufacturer = "TransformerManufacturer";
			/// <summary>Member name ComponentInspectionReportGeneral</summary>
			public static readonly string ComponentInspectionReportGeneral = "ComponentInspectionReportGeneral";
			/// <summary>Member name ComponentInspectionReportTransformer</summary>
			public static readonly string ComponentInspectionReportTransformer = "ComponentInspectionReportTransformer";
			/// <summary>Member name TransformerManufacturer_</summary>
			public static readonly string TransformerManufacturer_ = "TransformerManufacturer_";
			/// <summary>Member name ActionOnTransformerCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string ActionOnTransformerCollectionViaComponentInspectionReportTransformer = "ActionOnTransformerCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name ArcDetectionCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string ArcDetectionCollectionViaComponentInspectionReportTransformer = "ArcDetectionCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportTransformer = "BooleanAnswerCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGeneral = "BooleanAnswerCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGeneral_</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGeneral_ = "BooleanAnswerCollectionViaComponentInspectionReportGeneral_";
			/// <summary>Member name BracketsCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string BracketsCollectionViaComponentInspectionReportTransformer = "BracketsCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name CableConditionCollectionViaComponentInspectionReportTransformer_</summary>
			public static readonly string CableConditionCollectionViaComponentInspectionReportTransformer_ = "CableConditionCollectionViaComponentInspectionReportTransformer_";
			/// <summary>Member name CableConditionCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string CableConditionCollectionViaComponentInspectionReportTransformer = "CableConditionCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name ClimateCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string ClimateCollectionViaComponentInspectionReportTransformer = "ClimateCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name CoilConditionCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string CoilConditionCollectionViaComponentInspectionReportTransformer = "CoilConditionCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name CoilConditionCollectionViaComponentInspectionReportTransformer_</summary>
			public static readonly string CoilConditionCollectionViaComponentInspectionReportTransformer_ = "CoilConditionCollectionViaComponentInspectionReportTransformer_";
			/// <summary>Member name ComponentGroupCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string ComponentGroupCollectionViaComponentInspectionReportGeneral = "ComponentGroupCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGeneral = "ComponentInspectionReportCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportTransformer = "ComponentInspectionReportCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name ConnectionBarsCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string ConnectionBarsCollectionViaComponentInspectionReportTransformer = "ConnectionBarsCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name ControllerTypeCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string ControllerTypeCollectionViaComponentInspectionReportGeneral = "ControllerTypeCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name GearboxManufacturerCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string GearboxManufacturerCollectionViaComponentInspectionReportGeneral = "GearboxManufacturerCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGeneral = "GeneratorManufacturerCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name SurgeArrestorCollectionViaComponentInspectionReportTransformer</summary>
			public static readonly string SurgeArrestorCollectionViaComponentInspectionReportTransformer = "SurgeArrestorCollectionViaComponentInspectionReportTransformer";
			/// <summary>Member name TowerHeightCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string TowerHeightCollectionViaComponentInspectionReportGeneral = "TowerHeightCollectionViaComponentInspectionReportGeneral";
			/// <summary>Member name TowerTypeCollectionViaComponentInspectionReportGeneral</summary>
			public static readonly string TowerTypeCollectionViaComponentInspectionReportGeneral = "TowerTypeCollectionViaComponentInspectionReportGeneral";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TransformerManufacturerEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TransformerManufacturerEntity():base("TransformerManufacturerEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TransformerManufacturerEntity(IEntityFields2 fields):base("TransformerManufacturerEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TransformerManufacturerEntity</param>
		public TransformerManufacturerEntity(IValidator validator):base("TransformerManufacturerEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="transformerManufacturerId">PK value for TransformerManufacturer which data should be fetched into this TransformerManufacturer object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TransformerManufacturerEntity(System.Int64 transformerManufacturerId):base("TransformerManufacturerEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TransformerManufacturerId = transformerManufacturerId;
		}

		/// <summary> CTor</summary>
		/// <param name="transformerManufacturerId">PK value for TransformerManufacturer which data should be fetched into this TransformerManufacturer object</param>
		/// <param name="validator">The custom validator object for this TransformerManufacturerEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TransformerManufacturerEntity(System.Int64 transformerManufacturerId, IValidator validator):base("TransformerManufacturerEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TransformerManufacturerId = transformerManufacturerId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TransformerManufacturerEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReportGeneral = (EntityCollection<ComponentInspectionReportGeneralEntity>)info.GetValue("_componentInspectionReportGeneral", typeof(EntityCollection<ComponentInspectionReportGeneralEntity>));
				_componentInspectionReportTransformer = (EntityCollection<ComponentInspectionReportTransformerEntity>)info.GetValue("_componentInspectionReportTransformer", typeof(EntityCollection<ComponentInspectionReportTransformerEntity>));
				_transformerManufacturer_ = (EntityCollection<TransformerManufacturerEntity>)info.GetValue("_transformerManufacturer_", typeof(EntityCollection<TransformerManufacturerEntity>));
				_actionOnTransformerCollectionViaComponentInspectionReportTransformer = (EntityCollection<ActionOnTransformerEntity>)info.GetValue("_actionOnTransformerCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<ActionOnTransformerEntity>));
				_arcDetectionCollectionViaComponentInspectionReportTransformer = (EntityCollection<ArcDetectionEntity>)info.GetValue("_arcDetectionCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<ArcDetectionEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportTransformer = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGeneral = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGeneral_ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGeneral_", typeof(EntityCollection<BooleanAnswerEntity>));
				_bracketsCollectionViaComponentInspectionReportTransformer = (EntityCollection<BracketsEntity>)info.GetValue("_bracketsCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<BracketsEntity>));
				_cableConditionCollectionViaComponentInspectionReportTransformer_ = (EntityCollection<CableConditionEntity>)info.GetValue("_cableConditionCollectionViaComponentInspectionReportTransformer_", typeof(EntityCollection<CableConditionEntity>));
				_cableConditionCollectionViaComponentInspectionReportTransformer = (EntityCollection<CableConditionEntity>)info.GetValue("_cableConditionCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<CableConditionEntity>));
				_climateCollectionViaComponentInspectionReportTransformer = (EntityCollection<ClimateEntity>)info.GetValue("_climateCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<ClimateEntity>));
				_coilConditionCollectionViaComponentInspectionReportTransformer = (EntityCollection<CoilConditionEntity>)info.GetValue("_coilConditionCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<CoilConditionEntity>));
				_coilConditionCollectionViaComponentInspectionReportTransformer_ = (EntityCollection<CoilConditionEntity>)info.GetValue("_coilConditionCollectionViaComponentInspectionReportTransformer_", typeof(EntityCollection<CoilConditionEntity>));
				_componentGroupCollectionViaComponentInspectionReportGeneral = (EntityCollection<ComponentGroupEntity>)info.GetValue("_componentGroupCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<ComponentGroupEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGeneral = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportTransformer = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_connectionBarsCollectionViaComponentInspectionReportTransformer = (EntityCollection<ConnectionBarsEntity>)info.GetValue("_connectionBarsCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<ConnectionBarsEntity>));
				_controllerTypeCollectionViaComponentInspectionReportGeneral = (EntityCollection<ControllerTypeEntity>)info.GetValue("_controllerTypeCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<ControllerTypeEntity>));
				_gearboxManufacturerCollectionViaComponentInspectionReportGeneral = (EntityCollection<GearboxManufacturerEntity>)info.GetValue("_gearboxManufacturerCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<GearboxManufacturerEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGeneral = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_surgeArrestorCollectionViaComponentInspectionReportTransformer = (EntityCollection<SurgeArrestorEntity>)info.GetValue("_surgeArrestorCollectionViaComponentInspectionReportTransformer", typeof(EntityCollection<SurgeArrestorEntity>));
				_towerHeightCollectionViaComponentInspectionReportGeneral = (EntityCollection<TowerHeightEntity>)info.GetValue("_towerHeightCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<TowerHeightEntity>));
				_towerTypeCollectionViaComponentInspectionReportGeneral = (EntityCollection<TowerTypeEntity>)info.GetValue("_towerTypeCollectionViaComponentInspectionReportGeneral", typeof(EntityCollection<TowerTypeEntity>));
				_transformerManufacturer = (TransformerManufacturerEntity)info.GetValue("_transformerManufacturer", typeof(TransformerManufacturerEntity));
				if(_transformerManufacturer!=null)
				{
					_transformerManufacturer.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((TransformerManufacturerFieldIndex)fieldIndex)
			{
				case TransformerManufacturerFieldIndex.ParentTransformerManufacturerId:
					DesetupSyncTransformerManufacturer(true, false);
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
				case "TransformerManufacturer":
					this.TransformerManufacturer = (TransformerManufacturerEntity)entity;
					break;
				case "ComponentInspectionReportGeneral":
					this.ComponentInspectionReportGeneral.Add((ComponentInspectionReportGeneralEntity)entity);
					break;
				case "ComponentInspectionReportTransformer":
					this.ComponentInspectionReportTransformer.Add((ComponentInspectionReportTransformerEntity)entity);
					break;
				case "TransformerManufacturer_":
					this.TransformerManufacturer_.Add((TransformerManufacturerEntity)entity);
					break;
				case "ActionOnTransformerCollectionViaComponentInspectionReportTransformer":
					this.ActionOnTransformerCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.ActionOnTransformerCollectionViaComponentInspectionReportTransformer.Add((ActionOnTransformerEntity)entity);
					this.ActionOnTransformerCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
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
				case "BooleanAnswerCollectionViaComponentInspectionReportGeneral":
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGeneral_":
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral_.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral_.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGeneral_.IsReadOnly = true;
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
				case "CoilConditionCollectionViaComponentInspectionReportTransformer":
					this.CoilConditionCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.CoilConditionCollectionViaComponentInspectionReportTransformer.Add((CoilConditionEntity)entity);
					this.CoilConditionCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
					break;
				case "CoilConditionCollectionViaComponentInspectionReportTransformer_":
					this.CoilConditionCollectionViaComponentInspectionReportTransformer_.IsReadOnly = false;
					this.CoilConditionCollectionViaComponentInspectionReportTransformer_.Add((CoilConditionEntity)entity);
					this.CoilConditionCollectionViaComponentInspectionReportTransformer_.IsReadOnly = true;
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
				case "SurgeArrestorCollectionViaComponentInspectionReportTransformer":
					this.SurgeArrestorCollectionViaComponentInspectionReportTransformer.IsReadOnly = false;
					this.SurgeArrestorCollectionViaComponentInspectionReportTransformer.Add((SurgeArrestorEntity)entity);
					this.SurgeArrestorCollectionViaComponentInspectionReportTransformer.IsReadOnly = true;
					break;
				case "TowerHeightCollectionViaComponentInspectionReportGeneral":
					this.TowerHeightCollectionViaComponentInspectionReportGeneral.IsReadOnly = false;
					this.TowerHeightCollectionViaComponentInspectionReportGeneral.Add((TowerHeightEntity)entity);
					this.TowerHeightCollectionViaComponentInspectionReportGeneral.IsReadOnly = true;
					break;
				case "TowerTypeCollectionViaComponentInspectionReportGeneral":
					this.TowerTypeCollectionViaComponentInspectionReportGeneral.IsReadOnly = false;
					this.TowerTypeCollectionViaComponentInspectionReportGeneral.Add((TowerTypeEntity)entity);
					this.TowerTypeCollectionViaComponentInspectionReportGeneral.IsReadOnly = true;
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
				case "TransformerManufacturer":
					SetupSyncTransformerManufacturer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGeneral":
					this.ComponentInspectionReportGeneral.Add((ComponentInspectionReportGeneralEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportTransformer":
					this.ComponentInspectionReportTransformer.Add((ComponentInspectionReportTransformerEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "TransformerManufacturer_":
					this.TransformerManufacturer_.Add((TransformerManufacturerEntity)relatedEntity);
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
				case "TransformerManufacturer":
					DesetupSyncTransformerManufacturer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGeneral":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGeneral, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportTransformer":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportTransformer, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "TransformerManufacturer_":
					base.PerformRelatedEntityRemoval(this.TransformerManufacturer_, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_transformerManufacturer!=null)
			{
				toReturn.Add(_transformerManufacturer);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReportGeneral);
			toReturn.Add(this.ComponentInspectionReportTransformer);
			toReturn.Add(this.TransformerManufacturer_);

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
				info.AddValue("_componentInspectionReportTransformer", ((_componentInspectionReportTransformer!=null) && (_componentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportTransformer:null);
				info.AddValue("_transformerManufacturer_", ((_transformerManufacturer_!=null) && (_transformerManufacturer_.Count>0) && !this.MarkedForDeletion)?_transformerManufacturer_:null);
				info.AddValue("_actionOnTransformerCollectionViaComponentInspectionReportTransformer", ((_actionOnTransformerCollectionViaComponentInspectionReportTransformer!=null) && (_actionOnTransformerCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_actionOnTransformerCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_arcDetectionCollectionViaComponentInspectionReportTransformer", ((_arcDetectionCollectionViaComponentInspectionReportTransformer!=null) && (_arcDetectionCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_arcDetectionCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportTransformer", ((_booleanAnswerCollectionViaComponentInspectionReportTransformer!=null) && (_booleanAnswerCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGeneral", ((_booleanAnswerCollectionViaComponentInspectionReportGeneral!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGeneral_", ((_booleanAnswerCollectionViaComponentInspectionReportGeneral_!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGeneral_.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGeneral_:null);
				info.AddValue("_bracketsCollectionViaComponentInspectionReportTransformer", ((_bracketsCollectionViaComponentInspectionReportTransformer!=null) && (_bracketsCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_bracketsCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_cableConditionCollectionViaComponentInspectionReportTransformer_", ((_cableConditionCollectionViaComponentInspectionReportTransformer_!=null) && (_cableConditionCollectionViaComponentInspectionReportTransformer_.Count>0) && !this.MarkedForDeletion)?_cableConditionCollectionViaComponentInspectionReportTransformer_:null);
				info.AddValue("_cableConditionCollectionViaComponentInspectionReportTransformer", ((_cableConditionCollectionViaComponentInspectionReportTransformer!=null) && (_cableConditionCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_cableConditionCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_climateCollectionViaComponentInspectionReportTransformer", ((_climateCollectionViaComponentInspectionReportTransformer!=null) && (_climateCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_climateCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_coilConditionCollectionViaComponentInspectionReportTransformer", ((_coilConditionCollectionViaComponentInspectionReportTransformer!=null) && (_coilConditionCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_coilConditionCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_coilConditionCollectionViaComponentInspectionReportTransformer_", ((_coilConditionCollectionViaComponentInspectionReportTransformer_!=null) && (_coilConditionCollectionViaComponentInspectionReportTransformer_.Count>0) && !this.MarkedForDeletion)?_coilConditionCollectionViaComponentInspectionReportTransformer_:null);
				info.AddValue("_componentGroupCollectionViaComponentInspectionReportGeneral", ((_componentGroupCollectionViaComponentInspectionReportGeneral!=null) && (_componentGroupCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_componentGroupCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGeneral", ((_componentInspectionReportCollectionViaComponentInspectionReportGeneral!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportTransformer", ((_componentInspectionReportCollectionViaComponentInspectionReportTransformer!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_connectionBarsCollectionViaComponentInspectionReportTransformer", ((_connectionBarsCollectionViaComponentInspectionReportTransformer!=null) && (_connectionBarsCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_connectionBarsCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_controllerTypeCollectionViaComponentInspectionReportGeneral", ((_controllerTypeCollectionViaComponentInspectionReportGeneral!=null) && (_controllerTypeCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_controllerTypeCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_gearboxManufacturerCollectionViaComponentInspectionReportGeneral", ((_gearboxManufacturerCollectionViaComponentInspectionReportGeneral!=null) && (_gearboxManufacturerCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_gearboxManufacturerCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGeneral", ((_generatorManufacturerCollectionViaComponentInspectionReportGeneral!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_surgeArrestorCollectionViaComponentInspectionReportTransformer", ((_surgeArrestorCollectionViaComponentInspectionReportTransformer!=null) && (_surgeArrestorCollectionViaComponentInspectionReportTransformer.Count>0) && !this.MarkedForDeletion)?_surgeArrestorCollectionViaComponentInspectionReportTransformer:null);
				info.AddValue("_towerHeightCollectionViaComponentInspectionReportGeneral", ((_towerHeightCollectionViaComponentInspectionReportGeneral!=null) && (_towerHeightCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_towerHeightCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_towerTypeCollectionViaComponentInspectionReportGeneral", ((_towerTypeCollectionViaComponentInspectionReportGeneral!=null) && (_towerTypeCollectionViaComponentInspectionReportGeneral.Count>0) && !this.MarkedForDeletion)?_towerTypeCollectionViaComponentInspectionReportGeneral:null);
				info.AddValue("_transformerManufacturer", (!this.MarkedForDeletion?_transformerManufacturer:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(TransformerManufacturerFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TransformerManufacturerFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TransformerManufacturerRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGeneral' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneralFields.GeneralTransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportTransformer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportTransformerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TransformerManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTransformerManufacturer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.ParentTransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionOnTransformer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionOnTransformerCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.ActionOnTransformerEntityUsingActionOnTransformerId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ArcDetection' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoArcDetectionCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.ArcDetectionEntityUsingTransformerArcDetectionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.BooleanAnswerEntityUsingTransformerClaimRelevantBooleanAnswerId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralClaimRelevantBooleanAnswerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGeneral_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralPicturesIncludedBooleanAnswerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Brackets' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBracketsCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.BracketsEntityUsingBracketsId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CableCondition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCableConditionCollectionViaComponentInspectionReportTransformer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingLvcableConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CableCondition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCableConditionCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingHvcableConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Climate' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoClimateCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.ClimateEntityUsingClimateId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CoilCondition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCoilConditionCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingHvcoilConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'CoilCondition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCoilConditionCollectionViaComponentInspectionReportTransformer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingLvcoilConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentGroup' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentGroupCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.ComponentGroupEntityUsingGeneralComponentGroupId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ConnectionBars' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoConnectionBarsCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.ConnectionBarsEntityUsingConnectionBarsId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ControllerType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoControllerTypeCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.ControllerTypeEntityUsingGeneralControllerTypeId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearboxManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxManufacturerCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.GearboxManufacturerEntityUsingGeneralGearboxManufacturerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.GeneratorManufacturerEntityUsingGeneralGeneratorManufacturerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SurgeArrestor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSurgeArrestorCollectionViaComponentInspectionReportTransformer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportTransformerEntity.Relations.SurgeArrestorEntityUsingSurgeArrestorId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TowerHeight' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTowerHeightCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.TowerHeightEntityUsingGeneralTowerHeightId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TowerType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTowerTypeCollectionViaComponentInspectionReportGeneral()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneralEntity.Relations.TowerTypeEntityUsingGeneralTowerTypeId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.TransformerManufacturerId, "TransformerManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'TransformerManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTransformerManufacturer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TransformerManufacturerFields.TransformerManufacturerId, null, ComparisonOperator.Equal, this.ParentTransformerManufacturerId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TransformerManufacturerEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._componentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._transformerManufacturer_);
			collectionsQueue.Enqueue(this._actionOnTransformerCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._arcDetectionCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGeneral_);
			collectionsQueue.Enqueue(this._bracketsCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._cableConditionCollectionViaComponentInspectionReportTransformer_);
			collectionsQueue.Enqueue(this._cableConditionCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._climateCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._coilConditionCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._coilConditionCollectionViaComponentInspectionReportTransformer_);
			collectionsQueue.Enqueue(this._componentGroupCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._connectionBarsCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._controllerTypeCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._gearboxManufacturerCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._surgeArrestorCollectionViaComponentInspectionReportTransformer);
			collectionsQueue.Enqueue(this._towerHeightCollectionViaComponentInspectionReportGeneral);
			collectionsQueue.Enqueue(this._towerTypeCollectionViaComponentInspectionReportGeneral);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReportGeneral = (EntityCollection<ComponentInspectionReportGeneralEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportTransformer = (EntityCollection<ComponentInspectionReportTransformerEntity>) collectionsQueue.Dequeue();
			this._transformerManufacturer_ = (EntityCollection<TransformerManufacturerEntity>) collectionsQueue.Dequeue();
			this._actionOnTransformerCollectionViaComponentInspectionReportTransformer = (EntityCollection<ActionOnTransformerEntity>) collectionsQueue.Dequeue();
			this._arcDetectionCollectionViaComponentInspectionReportTransformer = (EntityCollection<ArcDetectionEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportTransformer = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGeneral = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGeneral_ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._bracketsCollectionViaComponentInspectionReportTransformer = (EntityCollection<BracketsEntity>) collectionsQueue.Dequeue();
			this._cableConditionCollectionViaComponentInspectionReportTransformer_ = (EntityCollection<CableConditionEntity>) collectionsQueue.Dequeue();
			this._cableConditionCollectionViaComponentInspectionReportTransformer = (EntityCollection<CableConditionEntity>) collectionsQueue.Dequeue();
			this._climateCollectionViaComponentInspectionReportTransformer = (EntityCollection<ClimateEntity>) collectionsQueue.Dequeue();
			this._coilConditionCollectionViaComponentInspectionReportTransformer = (EntityCollection<CoilConditionEntity>) collectionsQueue.Dequeue();
			this._coilConditionCollectionViaComponentInspectionReportTransformer_ = (EntityCollection<CoilConditionEntity>) collectionsQueue.Dequeue();
			this._componentGroupCollectionViaComponentInspectionReportGeneral = (EntityCollection<ComponentGroupEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGeneral = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportTransformer = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._connectionBarsCollectionViaComponentInspectionReportTransformer = (EntityCollection<ConnectionBarsEntity>) collectionsQueue.Dequeue();
			this._controllerTypeCollectionViaComponentInspectionReportGeneral = (EntityCollection<ControllerTypeEntity>) collectionsQueue.Dequeue();
			this._gearboxManufacturerCollectionViaComponentInspectionReportGeneral = (EntityCollection<GearboxManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGeneral = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._surgeArrestorCollectionViaComponentInspectionReportTransformer = (EntityCollection<SurgeArrestorEntity>) collectionsQueue.Dequeue();
			this._towerHeightCollectionViaComponentInspectionReportGeneral = (EntityCollection<TowerHeightEntity>) collectionsQueue.Dequeue();
			this._towerTypeCollectionViaComponentInspectionReportGeneral = (EntityCollection<TowerTypeEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReportGeneral != null)
			{
				return true;
			}
			if (this._componentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._transformerManufacturer_ != null)
			{
				return true;
			}
			if (this._actionOnTransformerCollectionViaComponentInspectionReportTransformer != null)
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
			if (this._booleanAnswerCollectionViaComponentInspectionReportGeneral != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGeneral_ != null)
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
			if (this._coilConditionCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._coilConditionCollectionViaComponentInspectionReportTransformer_ != null)
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
			if (this._componentInspectionReportCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._connectionBarsCollectionViaComponentInspectionReportTransformer != null)
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
			if (this._surgeArrestorCollectionViaComponentInspectionReportTransformer != null)
			{
				return true;
			}
			if (this._towerHeightCollectionViaComponentInspectionReportGeneral != null)
			{
				return true;
			}
			if (this._towerTypeCollectionViaComponentInspectionReportGeneral != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportTransformerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportTransformerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TransformerManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TransformerManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionOnTransformerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionOnTransformerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ArcDetectionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ArcDetectionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BracketsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BracketsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CableConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CableConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ClimateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClimateEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CoilConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CoilConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentGroupEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ConnectionBarsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ConnectionBarsEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ControllerTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ControllerTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearboxManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SurgeArrestorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurgeArrestorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TowerHeightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TowerHeightEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TowerTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TowerTypeEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("TransformerManufacturer", _transformerManufacturer);
			toReturn.Add("ComponentInspectionReportGeneral", _componentInspectionReportGeneral);
			toReturn.Add("ComponentInspectionReportTransformer", _componentInspectionReportTransformer);
			toReturn.Add("TransformerManufacturer_", _transformerManufacturer_);
			toReturn.Add("ActionOnTransformerCollectionViaComponentInspectionReportTransformer", _actionOnTransformerCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("ArcDetectionCollectionViaComponentInspectionReportTransformer", _arcDetectionCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportTransformer", _booleanAnswerCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGeneral", _booleanAnswerCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGeneral_", _booleanAnswerCollectionViaComponentInspectionReportGeneral_);
			toReturn.Add("BracketsCollectionViaComponentInspectionReportTransformer", _bracketsCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("CableConditionCollectionViaComponentInspectionReportTransformer_", _cableConditionCollectionViaComponentInspectionReportTransformer_);
			toReturn.Add("CableConditionCollectionViaComponentInspectionReportTransformer", _cableConditionCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("ClimateCollectionViaComponentInspectionReportTransformer", _climateCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("CoilConditionCollectionViaComponentInspectionReportTransformer", _coilConditionCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("CoilConditionCollectionViaComponentInspectionReportTransformer_", _coilConditionCollectionViaComponentInspectionReportTransformer_);
			toReturn.Add("ComponentGroupCollectionViaComponentInspectionReportGeneral", _componentGroupCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGeneral", _componentInspectionReportCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportTransformer", _componentInspectionReportCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("ConnectionBarsCollectionViaComponentInspectionReportTransformer", _connectionBarsCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("ControllerTypeCollectionViaComponentInspectionReportGeneral", _controllerTypeCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("GearboxManufacturerCollectionViaComponentInspectionReportGeneral", _gearboxManufacturerCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGeneral", _generatorManufacturerCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("SurgeArrestorCollectionViaComponentInspectionReportTransformer", _surgeArrestorCollectionViaComponentInspectionReportTransformer);
			toReturn.Add("TowerHeightCollectionViaComponentInspectionReportGeneral", _towerHeightCollectionViaComponentInspectionReportGeneral);
			toReturn.Add("TowerTypeCollectionViaComponentInspectionReportGeneral", _towerTypeCollectionViaComponentInspectionReportGeneral);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReportGeneral!=null)
			{
				_componentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportTransformer!=null)
			{
				_componentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_transformerManufacturer_!=null)
			{
				_transformerManufacturer_.ActiveContext = base.ActiveContext;
			}
			if(_actionOnTransformerCollectionViaComponentInspectionReportTransformer!=null)
			{
				_actionOnTransformerCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_arcDetectionCollectionViaComponentInspectionReportTransformer!=null)
			{
				_arcDetectionCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportTransformer!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGeneral!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGeneral_!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGeneral_.ActiveContext = base.ActiveContext;
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
			if(_coilConditionCollectionViaComponentInspectionReportTransformer!=null)
			{
				_coilConditionCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_coilConditionCollectionViaComponentInspectionReportTransformer_!=null)
			{
				_coilConditionCollectionViaComponentInspectionReportTransformer_.ActiveContext = base.ActiveContext;
			}
			if(_componentGroupCollectionViaComponentInspectionReportGeneral!=null)
			{
				_componentGroupCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGeneral!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportTransformer!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_connectionBarsCollectionViaComponentInspectionReportTransformer!=null)
			{
				_connectionBarsCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
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
			if(_surgeArrestorCollectionViaComponentInspectionReportTransformer!=null)
			{
				_surgeArrestorCollectionViaComponentInspectionReportTransformer.ActiveContext = base.ActiveContext;
			}
			if(_towerHeightCollectionViaComponentInspectionReportGeneral!=null)
			{
				_towerHeightCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_towerTypeCollectionViaComponentInspectionReportGeneral!=null)
			{
				_towerTypeCollectionViaComponentInspectionReportGeneral.ActiveContext = base.ActiveContext;
			}
			if(_transformerManufacturer!=null)
			{
				_transformerManufacturer.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReportGeneral = null;
			_componentInspectionReportTransformer = null;
			_transformerManufacturer_ = null;
			_actionOnTransformerCollectionViaComponentInspectionReportTransformer = null;
			_arcDetectionCollectionViaComponentInspectionReportTransformer = null;
			_booleanAnswerCollectionViaComponentInspectionReportTransformer = null;
			_booleanAnswerCollectionViaComponentInspectionReportGeneral = null;
			_booleanAnswerCollectionViaComponentInspectionReportGeneral_ = null;
			_bracketsCollectionViaComponentInspectionReportTransformer = null;
			_cableConditionCollectionViaComponentInspectionReportTransformer_ = null;
			_cableConditionCollectionViaComponentInspectionReportTransformer = null;
			_climateCollectionViaComponentInspectionReportTransformer = null;
			_coilConditionCollectionViaComponentInspectionReportTransformer = null;
			_coilConditionCollectionViaComponentInspectionReportTransformer_ = null;
			_componentGroupCollectionViaComponentInspectionReportGeneral = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGeneral = null;
			_componentInspectionReportCollectionViaComponentInspectionReportTransformer = null;
			_connectionBarsCollectionViaComponentInspectionReportTransformer = null;
			_controllerTypeCollectionViaComponentInspectionReportGeneral = null;
			_gearboxManufacturerCollectionViaComponentInspectionReportGeneral = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGeneral = null;
			_surgeArrestorCollectionViaComponentInspectionReportTransformer = null;
			_towerHeightCollectionViaComponentInspectionReportGeneral = null;
			_towerTypeCollectionViaComponentInspectionReportGeneral = null;
			_transformerManufacturer = null;

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

			_fieldsCustomProperties.Add("TransformerManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentTransformerManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Email", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Cc", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EmailContactName", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _transformerManufacturer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncTransformerManufacturer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _transformerManufacturer, new PropertyChangedEventHandler( OnTransformerManufacturerPropertyChanged ), "TransformerManufacturer", TransformerManufacturerEntity.Relations.TransformerManufacturerEntityUsingTransformerManufacturerIdParentTransformerManufacturerId, true, signalRelatedEntity, "TransformerManufacturer_", resetFKFields, new int[] { (int)TransformerManufacturerFieldIndex.ParentTransformerManufacturerId } );		
			_transformerManufacturer = null;
		}

		/// <summary> setups the sync logic for member _transformerManufacturer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncTransformerManufacturer(IEntity2 relatedEntity)
		{
			DesetupSyncTransformerManufacturer(true, true);
			_transformerManufacturer = (TransformerManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _transformerManufacturer, new PropertyChangedEventHandler( OnTransformerManufacturerPropertyChanged ), "TransformerManufacturer", TransformerManufacturerEntity.Relations.TransformerManufacturerEntityUsingTransformerManufacturerIdParentTransformerManufacturerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnTransformerManufacturerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this TransformerManufacturerEntity</param>
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
		public  static TransformerManufacturerRelations Relations
		{
			get	{ return new TransformerManufacturerRelations(); }
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
					TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity, 0, null, null, null, null, "ComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
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
					TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity, 0, null, null, null, null, "ComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TransformerManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTransformerManufacturer_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TransformerManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TransformerManufacturerEntityFactory))),
					TransformerManufacturerEntity.Relations.TransformerManufacturerEntityUsingParentTransformerManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, 0, null, null, null, null, "TransformerManufacturer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionOnTransformer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionOnTransformerCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.ActionOnTransformerEntityUsingActionOnTransformerId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ActionOnTransformerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionOnTransformerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity, 0, null, null, relations, null, "ActionOnTransformerCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.ArcDetectionEntityUsingTransformerArcDetectionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ArcDetectionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ArcDetectionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.ArcDetectionEntity, 0, null, null, relations, null, "ArcDetectionCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.BooleanAnswerEntityUsingTransformerClaimRelevantBooleanAnswerId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralClaimRelevantBooleanAnswerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.BooleanAnswerEntityUsingGeneralPicturesIncludedBooleanAnswerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGeneral_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.BracketsEntityUsingBracketsId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BracketsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BracketsEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.BracketsEntity, 0, null, null, relations, null, "BracketsCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingLvcableConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CableConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.CableConditionEntity, 0, null, null, relations, null, "CableConditionCollectionViaComponentInspectionReportTransformer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.CableConditionEntityUsingHvcableConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CableConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CableConditionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.CableConditionEntity, 0, null, null, relations, null, "CableConditionCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.ClimateEntityUsingClimateId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ClimateEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ClimateEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.ClimateEntity, 0, null, null, relations, null, "ClimateCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingHvcoilConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CoilConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.CoilConditionEntity, 0, null, null, relations, null, "CoilConditionCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.CoilConditionEntityUsingLvcoilConditionId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CoilConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CoilConditionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.CoilConditionEntity, 0, null, null, relations, null, "CoilConditionCollectionViaComponentInspectionReportTransformer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.ComponentGroupEntityUsingGeneralComponentGroupId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentGroupEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentGroupEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentGroupEntity, 0, null, null, relations, null, "ComponentGroupCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.ConnectionBarsEntityUsingConnectionBarsId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ConnectionBarsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ConnectionBarsEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.ConnectionBarsEntity, 0, null, null, relations, null, "ConnectionBarsCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.ControllerTypeEntityUsingGeneralControllerTypeId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ControllerTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ControllerTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.ControllerTypeEntity, 0, null, null, relations, null, "ControllerTypeCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.GearboxManufacturerEntityUsingGeneralGearboxManufacturerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearboxManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxManufacturerEntity, 0, null, null, relations, null, "GearboxManufacturerCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.GeneratorManufacturerEntityUsingGeneralGeneratorManufacturerId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportTransformer_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportTransformer_", JoinHint.None);
				relations.Add(ComponentInspectionReportTransformerEntity.Relations.SurgeArrestorEntityUsingSurgeArrestorId, "ComponentInspectionReportTransformer_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<SurgeArrestorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SurgeArrestorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.SurgeArrestorEntity, 0, null, null, relations, null, "SurgeArrestorCollectionViaComponentInspectionReportTransformer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.TowerHeightEntityUsingGeneralTowerHeightId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TowerHeightEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TowerHeightEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TowerHeightEntity, 0, null, null, relations, null, "TowerHeightCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TowerType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTowerTypeCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGeneral_");
				relations.Add(TransformerManufacturerEntity.Relations.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId, "TransformerManufacturerEntity__", "ComponentInspectionReportGeneral_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneralEntity.Relations.TowerTypeEntityUsingGeneralTowerTypeId, "ComponentInspectionReportGeneral_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TowerTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TowerTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TowerTypeEntity, 0, null, null, relations, null, "TowerTypeCollectionViaComponentInspectionReportGeneral", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TransformerManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTransformerManufacturer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(TransformerManufacturerEntityFactory))),
					TransformerManufacturerEntity.Relations.TransformerManufacturerEntityUsingTransformerManufacturerIdParentTransformerManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity, 0, null, null, null, null, "TransformerManufacturer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TransformerManufacturerEntity.CustomProperties;}
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
			get { return TransformerManufacturerEntity.FieldsCustomProperties;}
		}

		/// <summary> The TransformerManufacturerId property of the Entity TransformerManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TransformerManufacturer"."TransformerManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 TransformerManufacturerId
		{
			get { return (System.Int64)GetValue((int)TransformerManufacturerFieldIndex.TransformerManufacturerId, true); }
			set	{ SetValue((int)TransformerManufacturerFieldIndex.TransformerManufacturerId, value); }
		}

		/// <summary> The Name property of the Entity TransformerManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TransformerManufacturer"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)TransformerManufacturerFieldIndex.Name, true); }
			set	{ SetValue((int)TransformerManufacturerFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity TransformerManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TransformerManufacturer"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)TransformerManufacturerFieldIndex.LanguageId, true); }
			set	{ SetValue((int)TransformerManufacturerFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentTransformerManufacturerId property of the Entity TransformerManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TransformerManufacturer"."ParentTransformerManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentTransformerManufacturerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)TransformerManufacturerFieldIndex.ParentTransformerManufacturerId, false); }
			set	{ SetValue((int)TransformerManufacturerFieldIndex.ParentTransformerManufacturerId, value); }
		}

		/// <summary> The Sort property of the Entity TransformerManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TransformerManufacturer"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)TransformerManufacturerFieldIndex.Sort, true); }
			set	{ SetValue((int)TransformerManufacturerFieldIndex.Sort, value); }
		}

		/// <summary> The Email property of the Entity TransformerManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TransformerManufacturer"."Email"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Email
		{
			get { return (System.String)GetValue((int)TransformerManufacturerFieldIndex.Email, true); }
			set	{ SetValue((int)TransformerManufacturerFieldIndex.Email, value); }
		}

		/// <summary> The Cc property of the Entity TransformerManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TransformerManufacturer"."Cc"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Cc
		{
			get { return (System.String)GetValue((int)TransformerManufacturerFieldIndex.Cc, true); }
			set	{ SetValue((int)TransformerManufacturerFieldIndex.Cc, value); }
		}

		/// <summary> The EmailContactName property of the Entity TransformerManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TransformerManufacturer"."EmailContactName"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EmailContactName
		{
			get { return (System.String)GetValue((int)TransformerManufacturerFieldIndex.EmailContactName, true); }
			set	{ SetValue((int)TransformerManufacturerFieldIndex.EmailContactName, value); }
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
					_componentInspectionReportGeneral.SetContainingEntityInfo(this, "TransformerManufacturer");
				}
				return _componentInspectionReportGeneral;
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
					_componentInspectionReportTransformer.SetContainingEntityInfo(this, "TransformerManufacturer");
				}
				return _componentInspectionReportTransformer;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TransformerManufacturerEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TransformerManufacturerEntity))]
		public virtual EntityCollection<TransformerManufacturerEntity> TransformerManufacturer_
		{
			get
			{
				if(_transformerManufacturer_==null)
				{
					_transformerManufacturer_ = new EntityCollection<TransformerManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TransformerManufacturerEntityFactory)));
					_transformerManufacturer_.SetContainingEntityInfo(this, "TransformerManufacturer");
				}
				return _transformerManufacturer_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionOnTransformerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionOnTransformerEntity))]
		public virtual EntityCollection<ActionOnTransformerEntity> ActionOnTransformerCollectionViaComponentInspectionReportTransformer
		{
			get
			{
				if(_actionOnTransformerCollectionViaComponentInspectionReportTransformer==null)
				{
					_actionOnTransformerCollectionViaComponentInspectionReportTransformer = new EntityCollection<ActionOnTransformerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionOnTransformerEntityFactory)));
					_actionOnTransformerCollectionViaComponentInspectionReportTransformer.IsReadOnly=true;
				}
				return _actionOnTransformerCollectionViaComponentInspectionReportTransformer;
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

		/// <summary> Gets the EntityCollection with the related entities of type 'TowerTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TowerTypeEntity))]
		public virtual EntityCollection<TowerTypeEntity> TowerTypeCollectionViaComponentInspectionReportGeneral
		{
			get
			{
				if(_towerTypeCollectionViaComponentInspectionReportGeneral==null)
				{
					_towerTypeCollectionViaComponentInspectionReportGeneral = new EntityCollection<TowerTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TowerTypeEntityFactory)));
					_towerTypeCollectionViaComponentInspectionReportGeneral.IsReadOnly=true;
				}
				return _towerTypeCollectionViaComponentInspectionReportGeneral;
			}
		}

		/// <summary> Gets / sets related entity of type 'TransformerManufacturerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual TransformerManufacturerEntity TransformerManufacturer
		{
			get
			{
				return _transformerManufacturer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncTransformerManufacturer(value);
				}
				else
				{
					if(value==null)
					{
						if(_transformerManufacturer != null)
						{
							_transformerManufacturer.UnsetRelatedEntity(this, "TransformerManufacturer_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "TransformerManufacturer_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity; }
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
