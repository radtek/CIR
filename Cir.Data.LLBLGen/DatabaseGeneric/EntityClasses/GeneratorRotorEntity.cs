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
	/// Entity class which represents the entity 'GeneratorRotor'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class GeneratorRotorEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGenerator;
		private EntityCollection<GeneratorRotorEntity> _generatorRotor_;
		private EntityCollection<ActionToBeTakenOnGeneratorEntity> _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<CouplingEntity> _couplingCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<GeneratorCoverEntity> _generatorCoverCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<GeneratorDriveEndEntity> _generatorDriveEndCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<GeneratorNonDriveEndEntity> _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<OhmUnitEntity> _ohmUnitCollectionViaComponentInspectionReportGenerator______;
		private EntityCollection<OhmUnitEntity> _ohmUnitCollectionViaComponentInspectionReportGenerator_____;
		private EntityCollection<OhmUnitEntity> _ohmUnitCollectionViaComponentInspectionReportGenerator________;
		private EntityCollection<OhmUnitEntity> _ohmUnitCollectionViaComponentInspectionReportGenerator_______;
		private EntityCollection<OhmUnitEntity> _ohmUnitCollectionViaComponentInspectionReportGenerator____;
		private EntityCollection<OhmUnitEntity> _ohmUnitCollectionViaComponentInspectionReportGenerator_;
		private EntityCollection<OhmUnitEntity> _ohmUnitCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<OhmUnitEntity> _ohmUnitCollectionViaComponentInspectionReportGenerator___;
		private EntityCollection<OhmUnitEntity> _ohmUnitCollectionViaComponentInspectionReportGenerator__;
		private GeneratorRotorEntity _generatorRotor;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name GeneratorRotor</summary>
			public static readonly string GeneratorRotor = "GeneratorRotor";
			/// <summary>Member name ComponentInspectionReportGenerator</summary>
			public static readonly string ComponentInspectionReportGenerator = "ComponentInspectionReportGenerator";
			/// <summary>Member name GeneratorRotor_</summary>
			public static readonly string GeneratorRotor_ = "GeneratorRotor_";
			/// <summary>Member name ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator = "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGenerator = "BooleanAnswerCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGenerator = "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name CouplingCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string CouplingCollectionViaComponentInspectionReportGenerator = "CouplingCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name GeneratorCoverCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string GeneratorCoverCollectionViaComponentInspectionReportGenerator = "GeneratorCoverCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name GeneratorDriveEndCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string GeneratorDriveEndCollectionViaComponentInspectionReportGenerator = "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGenerator = "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator = "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name OhmUnitCollectionViaComponentInspectionReportGenerator______</summary>
			public static readonly string OhmUnitCollectionViaComponentInspectionReportGenerator______ = "OhmUnitCollectionViaComponentInspectionReportGenerator______";
			/// <summary>Member name OhmUnitCollectionViaComponentInspectionReportGenerator_____</summary>
			public static readonly string OhmUnitCollectionViaComponentInspectionReportGenerator_____ = "OhmUnitCollectionViaComponentInspectionReportGenerator_____";
			/// <summary>Member name OhmUnitCollectionViaComponentInspectionReportGenerator________</summary>
			public static readonly string OhmUnitCollectionViaComponentInspectionReportGenerator________ = "OhmUnitCollectionViaComponentInspectionReportGenerator________";
			/// <summary>Member name OhmUnitCollectionViaComponentInspectionReportGenerator_______</summary>
			public static readonly string OhmUnitCollectionViaComponentInspectionReportGenerator_______ = "OhmUnitCollectionViaComponentInspectionReportGenerator_______";
			/// <summary>Member name OhmUnitCollectionViaComponentInspectionReportGenerator____</summary>
			public static readonly string OhmUnitCollectionViaComponentInspectionReportGenerator____ = "OhmUnitCollectionViaComponentInspectionReportGenerator____";
			/// <summary>Member name OhmUnitCollectionViaComponentInspectionReportGenerator_</summary>
			public static readonly string OhmUnitCollectionViaComponentInspectionReportGenerator_ = "OhmUnitCollectionViaComponentInspectionReportGenerator_";
			/// <summary>Member name OhmUnitCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string OhmUnitCollectionViaComponentInspectionReportGenerator = "OhmUnitCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name OhmUnitCollectionViaComponentInspectionReportGenerator___</summary>
			public static readonly string OhmUnitCollectionViaComponentInspectionReportGenerator___ = "OhmUnitCollectionViaComponentInspectionReportGenerator___";
			/// <summary>Member name OhmUnitCollectionViaComponentInspectionReportGenerator__</summary>
			public static readonly string OhmUnitCollectionViaComponentInspectionReportGenerator__ = "OhmUnitCollectionViaComponentInspectionReportGenerator__";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static GeneratorRotorEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public GeneratorRotorEntity():base("GeneratorRotorEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public GeneratorRotorEntity(IEntityFields2 fields):base("GeneratorRotorEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this GeneratorRotorEntity</param>
		public GeneratorRotorEntity(IValidator validator):base("GeneratorRotorEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="generatorRotorId">PK value for GeneratorRotor which data should be fetched into this GeneratorRotor object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorRotorEntity(System.Int64 generatorRotorId):base("GeneratorRotorEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.GeneratorRotorId = generatorRotorId;
		}

		/// <summary> CTor</summary>
		/// <param name="generatorRotorId">PK value for GeneratorRotor which data should be fetched into this GeneratorRotor object</param>
		/// <param name="validator">The custom validator object for this GeneratorRotorEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public GeneratorRotorEntity(System.Int64 generatorRotorId, IValidator validator):base("GeneratorRotorEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.GeneratorRotorId = generatorRotorId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected GeneratorRotorEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReportGenerator = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGenerator", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_generatorRotor_ = (EntityCollection<GeneratorRotorEntity>)info.GetValue("_generatorRotor_", typeof(EntityCollection<GeneratorRotorEntity>));
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator = (EntityCollection<ActionToBeTakenOnGeneratorEntity>)info.GetValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<ActionToBeTakenOnGeneratorEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGenerator = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<BooleanAnswerEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_couplingCollectionViaComponentInspectionReportGenerator = (EntityCollection<CouplingEntity>)info.GetValue("_couplingCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<CouplingEntity>));
				_generatorCoverCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorCoverEntity>)info.GetValue("_generatorCoverCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<GeneratorCoverEntity>));
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorDriveEndEntity>)info.GetValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<GeneratorDriveEndEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorNonDriveEndEntity>)info.GetValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<GeneratorNonDriveEndEntity>));
				_ohmUnitCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<OhmUnitEntity>)info.GetValue("_ohmUnitCollectionViaComponentInspectionReportGenerator______", typeof(EntityCollection<OhmUnitEntity>));
				_ohmUnitCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<OhmUnitEntity>)info.GetValue("_ohmUnitCollectionViaComponentInspectionReportGenerator_____", typeof(EntityCollection<OhmUnitEntity>));
				_ohmUnitCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<OhmUnitEntity>)info.GetValue("_ohmUnitCollectionViaComponentInspectionReportGenerator________", typeof(EntityCollection<OhmUnitEntity>));
				_ohmUnitCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<OhmUnitEntity>)info.GetValue("_ohmUnitCollectionViaComponentInspectionReportGenerator_______", typeof(EntityCollection<OhmUnitEntity>));
				_ohmUnitCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<OhmUnitEntity>)info.GetValue("_ohmUnitCollectionViaComponentInspectionReportGenerator____", typeof(EntityCollection<OhmUnitEntity>));
				_ohmUnitCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<OhmUnitEntity>)info.GetValue("_ohmUnitCollectionViaComponentInspectionReportGenerator_", typeof(EntityCollection<OhmUnitEntity>));
				_ohmUnitCollectionViaComponentInspectionReportGenerator = (EntityCollection<OhmUnitEntity>)info.GetValue("_ohmUnitCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<OhmUnitEntity>));
				_ohmUnitCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<OhmUnitEntity>)info.GetValue("_ohmUnitCollectionViaComponentInspectionReportGenerator___", typeof(EntityCollection<OhmUnitEntity>));
				_ohmUnitCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<OhmUnitEntity>)info.GetValue("_ohmUnitCollectionViaComponentInspectionReportGenerator__", typeof(EntityCollection<OhmUnitEntity>));
				_generatorRotor = (GeneratorRotorEntity)info.GetValue("_generatorRotor", typeof(GeneratorRotorEntity));
				if(_generatorRotor!=null)
				{
					_generatorRotor.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((GeneratorRotorFieldIndex)fieldIndex)
			{
				case GeneratorRotorFieldIndex.ParentGeneratorRotorId:
					DesetupSyncGeneratorRotor(true, false);
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
				case "GeneratorRotor":
					this.GeneratorRotor = (GeneratorRotorEntity)entity;
					break;
				case "ComponentInspectionReportGenerator":
					this.ComponentInspectionReportGenerator.Add((ComponentInspectionReportGeneratorEntity)entity);
					break;
				case "GeneratorRotor_":
					this.GeneratorRotor_.Add((GeneratorRotorEntity)entity);
					break;
				case "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator":
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.Add((ActionToBeTakenOnGeneratorEntity)entity);
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGenerator":
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "CouplingCollectionViaComponentInspectionReportGenerator":
					this.CouplingCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.CouplingCollectionViaComponentInspectionReportGenerator.Add((CouplingEntity)entity);
					this.CouplingCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "GeneratorCoverCollectionViaComponentInspectionReportGenerator":
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator.Add((GeneratorCoverEntity)entity);
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator":
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator.Add((GeneratorDriveEndEntity)entity);
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator":
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator.Add((GeneratorNonDriveEndEntity)entity);
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "OhmUnitCollectionViaComponentInspectionReportGenerator______":
					this.OhmUnitCollectionViaComponentInspectionReportGenerator______.IsReadOnly = false;
					this.OhmUnitCollectionViaComponentInspectionReportGenerator______.Add((OhmUnitEntity)entity);
					this.OhmUnitCollectionViaComponentInspectionReportGenerator______.IsReadOnly = true;
					break;
				case "OhmUnitCollectionViaComponentInspectionReportGenerator_____":
					this.OhmUnitCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = false;
					this.OhmUnitCollectionViaComponentInspectionReportGenerator_____.Add((OhmUnitEntity)entity);
					this.OhmUnitCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = true;
					break;
				case "OhmUnitCollectionViaComponentInspectionReportGenerator________":
					this.OhmUnitCollectionViaComponentInspectionReportGenerator________.IsReadOnly = false;
					this.OhmUnitCollectionViaComponentInspectionReportGenerator________.Add((OhmUnitEntity)entity);
					this.OhmUnitCollectionViaComponentInspectionReportGenerator________.IsReadOnly = true;
					break;
				case "OhmUnitCollectionViaComponentInspectionReportGenerator_______":
					this.OhmUnitCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = false;
					this.OhmUnitCollectionViaComponentInspectionReportGenerator_______.Add((OhmUnitEntity)entity);
					this.OhmUnitCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = true;
					break;
				case "OhmUnitCollectionViaComponentInspectionReportGenerator____":
					this.OhmUnitCollectionViaComponentInspectionReportGenerator____.IsReadOnly = false;
					this.OhmUnitCollectionViaComponentInspectionReportGenerator____.Add((OhmUnitEntity)entity);
					this.OhmUnitCollectionViaComponentInspectionReportGenerator____.IsReadOnly = true;
					break;
				case "OhmUnitCollectionViaComponentInspectionReportGenerator_":
					this.OhmUnitCollectionViaComponentInspectionReportGenerator_.IsReadOnly = false;
					this.OhmUnitCollectionViaComponentInspectionReportGenerator_.Add((OhmUnitEntity)entity);
					this.OhmUnitCollectionViaComponentInspectionReportGenerator_.IsReadOnly = true;
					break;
				case "OhmUnitCollectionViaComponentInspectionReportGenerator":
					this.OhmUnitCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.OhmUnitCollectionViaComponentInspectionReportGenerator.Add((OhmUnitEntity)entity);
					this.OhmUnitCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "OhmUnitCollectionViaComponentInspectionReportGenerator___":
					this.OhmUnitCollectionViaComponentInspectionReportGenerator___.IsReadOnly = false;
					this.OhmUnitCollectionViaComponentInspectionReportGenerator___.Add((OhmUnitEntity)entity);
					this.OhmUnitCollectionViaComponentInspectionReportGenerator___.IsReadOnly = true;
					break;
				case "OhmUnitCollectionViaComponentInspectionReportGenerator__":
					this.OhmUnitCollectionViaComponentInspectionReportGenerator__.IsReadOnly = false;
					this.OhmUnitCollectionViaComponentInspectionReportGenerator__.Add((OhmUnitEntity)entity);
					this.OhmUnitCollectionViaComponentInspectionReportGenerator__.IsReadOnly = true;
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
				case "GeneratorRotor":
					SetupSyncGeneratorRotor(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator":
					this.ComponentInspectionReportGenerator.Add((ComponentInspectionReportGeneratorEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorRotor_":
					this.GeneratorRotor_.Add((GeneratorRotorEntity)relatedEntity);
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
				case "GeneratorRotor":
					DesetupSyncGeneratorRotor(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGenerator, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorRotor_":
					base.PerformRelatedEntityRemoval(this.GeneratorRotor_, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_generatorRotor!=null)
			{
				toReturn.Add(_generatorRotor);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReportGenerator);
			toReturn.Add(this.GeneratorRotor_);

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
				info.AddValue("_componentInspectionReportGenerator", ((_componentInspectionReportGenerator!=null) && (_componentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGenerator:null);
				info.AddValue("_generatorRotor_", ((_generatorRotor_!=null) && (_generatorRotor_.Count>0) && !this.MarkedForDeletion)?_generatorRotor_:null);
				info.AddValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator", ((_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator!=null) && (_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator", ((_booleanAnswerCollectionViaComponentInspectionReportGenerator!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator", ((_componentInspectionReportCollectionViaComponentInspectionReportGenerator!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_couplingCollectionViaComponentInspectionReportGenerator", ((_couplingCollectionViaComponentInspectionReportGenerator!=null) && (_couplingCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_couplingCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_generatorCoverCollectionViaComponentInspectionReportGenerator", ((_generatorCoverCollectionViaComponentInspectionReportGenerator!=null) && (_generatorCoverCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_generatorCoverCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator", ((_generatorDriveEndCollectionViaComponentInspectionReportGenerator!=null) && (_generatorDriveEndCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_generatorDriveEndCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator", ((_generatorManufacturerCollectionViaComponentInspectionReportGenerator!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator", ((_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator!=null) && (_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_ohmUnitCollectionViaComponentInspectionReportGenerator______", ((_ohmUnitCollectionViaComponentInspectionReportGenerator______!=null) && (_ohmUnitCollectionViaComponentInspectionReportGenerator______.Count>0) && !this.MarkedForDeletion)?_ohmUnitCollectionViaComponentInspectionReportGenerator______:null);
				info.AddValue("_ohmUnitCollectionViaComponentInspectionReportGenerator_____", ((_ohmUnitCollectionViaComponentInspectionReportGenerator_____!=null) && (_ohmUnitCollectionViaComponentInspectionReportGenerator_____.Count>0) && !this.MarkedForDeletion)?_ohmUnitCollectionViaComponentInspectionReportGenerator_____:null);
				info.AddValue("_ohmUnitCollectionViaComponentInspectionReportGenerator________", ((_ohmUnitCollectionViaComponentInspectionReportGenerator________!=null) && (_ohmUnitCollectionViaComponentInspectionReportGenerator________.Count>0) && !this.MarkedForDeletion)?_ohmUnitCollectionViaComponentInspectionReportGenerator________:null);
				info.AddValue("_ohmUnitCollectionViaComponentInspectionReportGenerator_______", ((_ohmUnitCollectionViaComponentInspectionReportGenerator_______!=null) && (_ohmUnitCollectionViaComponentInspectionReportGenerator_______.Count>0) && !this.MarkedForDeletion)?_ohmUnitCollectionViaComponentInspectionReportGenerator_______:null);
				info.AddValue("_ohmUnitCollectionViaComponentInspectionReportGenerator____", ((_ohmUnitCollectionViaComponentInspectionReportGenerator____!=null) && (_ohmUnitCollectionViaComponentInspectionReportGenerator____.Count>0) && !this.MarkedForDeletion)?_ohmUnitCollectionViaComponentInspectionReportGenerator____:null);
				info.AddValue("_ohmUnitCollectionViaComponentInspectionReportGenerator_", ((_ohmUnitCollectionViaComponentInspectionReportGenerator_!=null) && (_ohmUnitCollectionViaComponentInspectionReportGenerator_.Count>0) && !this.MarkedForDeletion)?_ohmUnitCollectionViaComponentInspectionReportGenerator_:null);
				info.AddValue("_ohmUnitCollectionViaComponentInspectionReportGenerator", ((_ohmUnitCollectionViaComponentInspectionReportGenerator!=null) && (_ohmUnitCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_ohmUnitCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_ohmUnitCollectionViaComponentInspectionReportGenerator___", ((_ohmUnitCollectionViaComponentInspectionReportGenerator___!=null) && (_ohmUnitCollectionViaComponentInspectionReportGenerator___.Count>0) && !this.MarkedForDeletion)?_ohmUnitCollectionViaComponentInspectionReportGenerator___:null);
				info.AddValue("_ohmUnitCollectionViaComponentInspectionReportGenerator__", ((_ohmUnitCollectionViaComponentInspectionReportGenerator__!=null) && (_ohmUnitCollectionViaComponentInspectionReportGenerator__.Count>0) && !this.MarkedForDeletion)?_ohmUnitCollectionViaComponentInspectionReportGenerator__:null);
				info.AddValue("_generatorRotor", (!this.MarkedForDeletion?_generatorRotor:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(GeneratorRotorFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(GeneratorRotorFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new GeneratorRotorRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotor_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.ParentGeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionToBeTakenOnGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupling' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouplingCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorCover' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorCoverCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDriveEndCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorNonDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnitCollectionViaComponentInspectionReportGenerator______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingKgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnitCollectionViaComponentInspectionReportGenerator_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingVwohmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnitCollectionViaComponentInspectionReportGenerator________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingMgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnitCollectionViaComponentInspectionReportGenerator_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingLgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnitCollectionViaComponentInspectionReportGenerator____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUwohmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnitCollectionViaComponentInspectionReportGenerator_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingVgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnitCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnitCollectionViaComponentInspectionReportGenerator___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUvohmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnitCollectionViaComponentInspectionReportGenerator__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingWgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.GeneratorRotorId, "GeneratorRotorEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotor()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorRotorFields.GeneratorRotorId, null, ComparisonOperator.Equal, this.ParentGeneratorRotorId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._generatorRotor_);
			collectionsQueue.Enqueue(this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._couplingCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._generatorCoverCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._generatorDriveEndCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._ohmUnitCollectionViaComponentInspectionReportGenerator______);
			collectionsQueue.Enqueue(this._ohmUnitCollectionViaComponentInspectionReportGenerator_____);
			collectionsQueue.Enqueue(this._ohmUnitCollectionViaComponentInspectionReportGenerator________);
			collectionsQueue.Enqueue(this._ohmUnitCollectionViaComponentInspectionReportGenerator_______);
			collectionsQueue.Enqueue(this._ohmUnitCollectionViaComponentInspectionReportGenerator____);
			collectionsQueue.Enqueue(this._ohmUnitCollectionViaComponentInspectionReportGenerator_);
			collectionsQueue.Enqueue(this._ohmUnitCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._ohmUnitCollectionViaComponentInspectionReportGenerator___);
			collectionsQueue.Enqueue(this._ohmUnitCollectionViaComponentInspectionReportGenerator__);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReportGenerator = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._generatorRotor_ = (EntityCollection<GeneratorRotorEntity>) collectionsQueue.Dequeue();
			this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator = (EntityCollection<ActionToBeTakenOnGeneratorEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGenerator = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGenerator = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._couplingCollectionViaComponentInspectionReportGenerator = (EntityCollection<CouplingEntity>) collectionsQueue.Dequeue();
			this._generatorCoverCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorCoverEntity>) collectionsQueue.Dequeue();
			this._generatorDriveEndCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorNonDriveEndEntity>) collectionsQueue.Dequeue();
			this._ohmUnitCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<OhmUnitEntity>) collectionsQueue.Dequeue();
			this._ohmUnitCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<OhmUnitEntity>) collectionsQueue.Dequeue();
			this._ohmUnitCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<OhmUnitEntity>) collectionsQueue.Dequeue();
			this._ohmUnitCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<OhmUnitEntity>) collectionsQueue.Dequeue();
			this._ohmUnitCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<OhmUnitEntity>) collectionsQueue.Dequeue();
			this._ohmUnitCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<OhmUnitEntity>) collectionsQueue.Dequeue();
			this._ohmUnitCollectionViaComponentInspectionReportGenerator = (EntityCollection<OhmUnitEntity>) collectionsQueue.Dequeue();
			this._ohmUnitCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<OhmUnitEntity>) collectionsQueue.Dequeue();
			this._ohmUnitCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<OhmUnitEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._generatorRotor_ != null)
			{
				return true;
			}
			if (this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._couplingCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._generatorCoverCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._generatorDriveEndCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._ohmUnitCollectionViaComponentInspectionReportGenerator______ != null)
			{
				return true;
			}
			if (this._ohmUnitCollectionViaComponentInspectionReportGenerator_____ != null)
			{
				return true;
			}
			if (this._ohmUnitCollectionViaComponentInspectionReportGenerator________ != null)
			{
				return true;
			}
			if (this._ohmUnitCollectionViaComponentInspectionReportGenerator_______ != null)
			{
				return true;
			}
			if (this._ohmUnitCollectionViaComponentInspectionReportGenerator____ != null)
			{
				return true;
			}
			if (this._ohmUnitCollectionViaComponentInspectionReportGenerator_ != null)
			{
				return true;
			}
			if (this._ohmUnitCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._ohmUnitCollectionViaComponentInspectionReportGenerator___ != null)
			{
				return true;
			}
			if (this._ohmUnitCollectionViaComponentInspectionReportGenerator__ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("GeneratorRotor", _generatorRotor);
			toReturn.Add("ComponentInspectionReportGenerator", _componentInspectionReportGenerator);
			toReturn.Add("GeneratorRotor_", _generatorRotor_);
			toReturn.Add("ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator", _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGenerator", _booleanAnswerCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGenerator", _componentInspectionReportCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("CouplingCollectionViaComponentInspectionReportGenerator", _couplingCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("GeneratorCoverCollectionViaComponentInspectionReportGenerator", _generatorCoverCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("GeneratorDriveEndCollectionViaComponentInspectionReportGenerator", _generatorDriveEndCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGenerator", _generatorManufacturerCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator", _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("OhmUnitCollectionViaComponentInspectionReportGenerator______", _ohmUnitCollectionViaComponentInspectionReportGenerator______);
			toReturn.Add("OhmUnitCollectionViaComponentInspectionReportGenerator_____", _ohmUnitCollectionViaComponentInspectionReportGenerator_____);
			toReturn.Add("OhmUnitCollectionViaComponentInspectionReportGenerator________", _ohmUnitCollectionViaComponentInspectionReportGenerator________);
			toReturn.Add("OhmUnitCollectionViaComponentInspectionReportGenerator_______", _ohmUnitCollectionViaComponentInspectionReportGenerator_______);
			toReturn.Add("OhmUnitCollectionViaComponentInspectionReportGenerator____", _ohmUnitCollectionViaComponentInspectionReportGenerator____);
			toReturn.Add("OhmUnitCollectionViaComponentInspectionReportGenerator_", _ohmUnitCollectionViaComponentInspectionReportGenerator_);
			toReturn.Add("OhmUnitCollectionViaComponentInspectionReportGenerator", _ohmUnitCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("OhmUnitCollectionViaComponentInspectionReportGenerator___", _ohmUnitCollectionViaComponentInspectionReportGenerator___);
			toReturn.Add("OhmUnitCollectionViaComponentInspectionReportGenerator__", _ohmUnitCollectionViaComponentInspectionReportGenerator__);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReportGenerator!=null)
			{
				_componentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotor_!=null)
			{
				_generatorRotor_.ActiveContext = base.ActiveContext;
			}
			if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator!=null)
			{
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGenerator!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_couplingCollectionViaComponentInspectionReportGenerator!=null)
			{
				_couplingCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_generatorCoverCollectionViaComponentInspectionReportGenerator!=null)
			{
				_generatorCoverCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator!=null)
			{
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator!=null)
			{
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnitCollectionViaComponentInspectionReportGenerator______!=null)
			{
				_ohmUnitCollectionViaComponentInspectionReportGenerator______.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnitCollectionViaComponentInspectionReportGenerator_____!=null)
			{
				_ohmUnitCollectionViaComponentInspectionReportGenerator_____.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnitCollectionViaComponentInspectionReportGenerator________!=null)
			{
				_ohmUnitCollectionViaComponentInspectionReportGenerator________.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnitCollectionViaComponentInspectionReportGenerator_______!=null)
			{
				_ohmUnitCollectionViaComponentInspectionReportGenerator_______.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnitCollectionViaComponentInspectionReportGenerator____!=null)
			{
				_ohmUnitCollectionViaComponentInspectionReportGenerator____.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnitCollectionViaComponentInspectionReportGenerator_!=null)
			{
				_ohmUnitCollectionViaComponentInspectionReportGenerator_.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnitCollectionViaComponentInspectionReportGenerator!=null)
			{
				_ohmUnitCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnitCollectionViaComponentInspectionReportGenerator___!=null)
			{
				_ohmUnitCollectionViaComponentInspectionReportGenerator___.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnitCollectionViaComponentInspectionReportGenerator__!=null)
			{
				_ohmUnitCollectionViaComponentInspectionReportGenerator__.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotor!=null)
			{
				_generatorRotor.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReportGenerator = null;
			_generatorRotor_ = null;
			_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator = null;
			_booleanAnswerCollectionViaComponentInspectionReportGenerator = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGenerator = null;
			_couplingCollectionViaComponentInspectionReportGenerator = null;
			_generatorCoverCollectionViaComponentInspectionReportGenerator = null;
			_generatorDriveEndCollectionViaComponentInspectionReportGenerator = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGenerator = null;
			_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator = null;
			_ohmUnitCollectionViaComponentInspectionReportGenerator______ = null;
			_ohmUnitCollectionViaComponentInspectionReportGenerator_____ = null;
			_ohmUnitCollectionViaComponentInspectionReportGenerator________ = null;
			_ohmUnitCollectionViaComponentInspectionReportGenerator_______ = null;
			_ohmUnitCollectionViaComponentInspectionReportGenerator____ = null;
			_ohmUnitCollectionViaComponentInspectionReportGenerator_ = null;
			_ohmUnitCollectionViaComponentInspectionReportGenerator = null;
			_ohmUnitCollectionViaComponentInspectionReportGenerator___ = null;
			_ohmUnitCollectionViaComponentInspectionReportGenerator__ = null;
			_generatorRotor = null;

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

			_fieldsCustomProperties.Add("GeneratorRotorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentGeneratorRotorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _generatorRotor</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorRotor(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorRotor, new PropertyChangedEventHandler( OnGeneratorRotorPropertyChanged ), "GeneratorRotor", GeneratorRotorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorIdParentGeneratorRotorId, true, signalRelatedEntity, "GeneratorRotor_", resetFKFields, new int[] { (int)GeneratorRotorFieldIndex.ParentGeneratorRotorId } );		
			_generatorRotor = null;
		}

		/// <summary> setups the sync logic for member _generatorRotor</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorRotor(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorRotor(true, true);
			_generatorRotor = (GeneratorRotorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorRotor, new PropertyChangedEventHandler( OnGeneratorRotorPropertyChanged ), "GeneratorRotor", GeneratorRotorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorIdParentGeneratorRotorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorRotorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this GeneratorRotorEntity</param>
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
		public  static GeneratorRotorRelations Relations
		{
			get	{ return new GeneratorRotorRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGenerator
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),
					GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, null, null, "ComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotor_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),
					GeneratorRotorEntity.Relations.GeneratorRotorEntityUsingParentGeneratorRotorId, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, null, null, "GeneratorRotor_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionToBeTakenOnGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity, 0, null, null, relations, null, "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouplingCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, relations, null, "CouplingCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorCover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorCoverCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity, 0, null, null, relations, null, "GeneratorCoverCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDriveEndCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity, 0, null, null, relations, null, "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorNonDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity, 0, null, null, relations, null, "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnitCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingKgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, relations, null, "OhmUnitCollectionViaComponentInspectionReportGenerator______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnitCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingVwohmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, relations, null, "OhmUnitCollectionViaComponentInspectionReportGenerator_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnitCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingMgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, relations, null, "OhmUnitCollectionViaComponentInspectionReportGenerator________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnitCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingLgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, relations, null, "OhmUnitCollectionViaComponentInspectionReportGenerator_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnitCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUwohmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, relations, null, "OhmUnitCollectionViaComponentInspectionReportGenerator____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnitCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingVgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, relations, null, "OhmUnitCollectionViaComponentInspectionReportGenerator_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnitCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, relations, null, "OhmUnitCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnitCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingUvohmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, relations, null, "OhmUnitCollectionViaComponentInspectionReportGenerator___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnitCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(GeneratorRotorEntity.Relations.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId, "GeneratorRotorEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.OhmUnitEntityUsingWgroundOhmUnitId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, relations, null, "OhmUnitCollectionViaComponentInspectionReportGenerator__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotor
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),
					GeneratorRotorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorIdParentGeneratorRotorId, 
					(int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, null, null, "GeneratorRotor", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return GeneratorRotorEntity.CustomProperties;}
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
			get { return GeneratorRotorEntity.FieldsCustomProperties;}
		}

		/// <summary> The GeneratorRotorId property of the Entity GeneratorRotor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorRotor"."GeneratorRotorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 GeneratorRotorId
		{
			get { return (System.Int64)GetValue((int)GeneratorRotorFieldIndex.GeneratorRotorId, true); }
			set	{ SetValue((int)GeneratorRotorFieldIndex.GeneratorRotorId, value); }
		}

		/// <summary> The Name property of the Entity GeneratorRotor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorRotor"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)GeneratorRotorFieldIndex.Name, true); }
			set	{ SetValue((int)GeneratorRotorFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity GeneratorRotor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorRotor"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)GeneratorRotorFieldIndex.LanguageId, true); }
			set	{ SetValue((int)GeneratorRotorFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentGeneratorRotorId property of the Entity GeneratorRotor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorRotor"."ParentGeneratorRotorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentGeneratorRotorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)GeneratorRotorFieldIndex.ParentGeneratorRotorId, false); }
			set	{ SetValue((int)GeneratorRotorFieldIndex.ParentGeneratorRotorId, value); }
		}

		/// <summary> The Sort property of the Entity GeneratorRotor<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "GeneratorRotor"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)GeneratorRotorFieldIndex.Sort, true); }
			set	{ SetValue((int)GeneratorRotorFieldIndex.Sort, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGenerator
		{
			get
			{
				if(_componentInspectionReportGenerator==null)
				{
					_componentInspectionReportGenerator = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGenerator.SetContainingEntityInfo(this, "GeneratorRotor");
				}
				return _componentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorRotorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorRotorEntity))]
		public virtual EntityCollection<GeneratorRotorEntity> GeneratorRotor_
		{
			get
			{
				if(_generatorRotor_==null)
				{
					_generatorRotor_ = new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory)));
					_generatorRotor_.SetContainingEntityInfo(this, "GeneratorRotor");
				}
				return _generatorRotor_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionToBeTakenOnGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionToBeTakenOnGeneratorEntity))]
		public virtual EntityCollection<ActionToBeTakenOnGeneratorEntity> ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator==null)
				{
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator = new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory)));
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGenerator==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGenerator = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouplingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouplingEntity))]
		public virtual EntityCollection<CouplingEntity> CouplingCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_couplingCollectionViaComponentInspectionReportGenerator==null)
				{
					_couplingCollectionViaComponentInspectionReportGenerator = new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory)));
					_couplingCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _couplingCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorCoverEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorCoverEntity))]
		public virtual EntityCollection<GeneratorCoverEntity> GeneratorCoverCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_generatorCoverCollectionViaComponentInspectionReportGenerator==null)
				{
					_generatorCoverCollectionViaComponentInspectionReportGenerator = new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory)));
					_generatorCoverCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _generatorCoverCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDriveEndEntity))]
		public virtual EntityCollection<GeneratorDriveEndEntity> GeneratorDriveEndCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator==null)
				{
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator = new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory)));
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _generatorDriveEndCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorNonDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorNonDriveEndEntity))]
		public virtual EntityCollection<GeneratorNonDriveEndEntity> GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator==null)
				{
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator = new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory)));
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OhmUnitEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OhmUnitEntity))]
		public virtual EntityCollection<OhmUnitEntity> OhmUnitCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				if(_ohmUnitCollectionViaComponentInspectionReportGenerator______==null)
				{
					_ohmUnitCollectionViaComponentInspectionReportGenerator______ = new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory)));
					_ohmUnitCollectionViaComponentInspectionReportGenerator______.IsReadOnly=true;
				}
				return _ohmUnitCollectionViaComponentInspectionReportGenerator______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OhmUnitEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OhmUnitEntity))]
		public virtual EntityCollection<OhmUnitEntity> OhmUnitCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				if(_ohmUnitCollectionViaComponentInspectionReportGenerator_____==null)
				{
					_ohmUnitCollectionViaComponentInspectionReportGenerator_____ = new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory)));
					_ohmUnitCollectionViaComponentInspectionReportGenerator_____.IsReadOnly=true;
				}
				return _ohmUnitCollectionViaComponentInspectionReportGenerator_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OhmUnitEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OhmUnitEntity))]
		public virtual EntityCollection<OhmUnitEntity> OhmUnitCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				if(_ohmUnitCollectionViaComponentInspectionReportGenerator________==null)
				{
					_ohmUnitCollectionViaComponentInspectionReportGenerator________ = new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory)));
					_ohmUnitCollectionViaComponentInspectionReportGenerator________.IsReadOnly=true;
				}
				return _ohmUnitCollectionViaComponentInspectionReportGenerator________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OhmUnitEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OhmUnitEntity))]
		public virtual EntityCollection<OhmUnitEntity> OhmUnitCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				if(_ohmUnitCollectionViaComponentInspectionReportGenerator_______==null)
				{
					_ohmUnitCollectionViaComponentInspectionReportGenerator_______ = new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory)));
					_ohmUnitCollectionViaComponentInspectionReportGenerator_______.IsReadOnly=true;
				}
				return _ohmUnitCollectionViaComponentInspectionReportGenerator_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OhmUnitEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OhmUnitEntity))]
		public virtual EntityCollection<OhmUnitEntity> OhmUnitCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				if(_ohmUnitCollectionViaComponentInspectionReportGenerator____==null)
				{
					_ohmUnitCollectionViaComponentInspectionReportGenerator____ = new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory)));
					_ohmUnitCollectionViaComponentInspectionReportGenerator____.IsReadOnly=true;
				}
				return _ohmUnitCollectionViaComponentInspectionReportGenerator____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OhmUnitEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OhmUnitEntity))]
		public virtual EntityCollection<OhmUnitEntity> OhmUnitCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				if(_ohmUnitCollectionViaComponentInspectionReportGenerator_==null)
				{
					_ohmUnitCollectionViaComponentInspectionReportGenerator_ = new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory)));
					_ohmUnitCollectionViaComponentInspectionReportGenerator_.IsReadOnly=true;
				}
				return _ohmUnitCollectionViaComponentInspectionReportGenerator_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OhmUnitEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OhmUnitEntity))]
		public virtual EntityCollection<OhmUnitEntity> OhmUnitCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_ohmUnitCollectionViaComponentInspectionReportGenerator==null)
				{
					_ohmUnitCollectionViaComponentInspectionReportGenerator = new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory)));
					_ohmUnitCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _ohmUnitCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OhmUnitEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OhmUnitEntity))]
		public virtual EntityCollection<OhmUnitEntity> OhmUnitCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				if(_ohmUnitCollectionViaComponentInspectionReportGenerator___==null)
				{
					_ohmUnitCollectionViaComponentInspectionReportGenerator___ = new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory)));
					_ohmUnitCollectionViaComponentInspectionReportGenerator___.IsReadOnly=true;
				}
				return _ohmUnitCollectionViaComponentInspectionReportGenerator___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OhmUnitEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OhmUnitEntity))]
		public virtual EntityCollection<OhmUnitEntity> OhmUnitCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				if(_ohmUnitCollectionViaComponentInspectionReportGenerator__==null)
				{
					_ohmUnitCollectionViaComponentInspectionReportGenerator__ = new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory)));
					_ohmUnitCollectionViaComponentInspectionReportGenerator__.IsReadOnly=true;
				}
				return _ohmUnitCollectionViaComponentInspectionReportGenerator__;
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorRotorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorRotorEntity GeneratorRotor
		{
			get
			{
				return _generatorRotor;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorRotor(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorRotor != null)
						{
							_generatorRotor.UnsetRelatedEntity(this, "GeneratorRotor_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "GeneratorRotor_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity; }
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
