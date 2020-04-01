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
using System.Collections.Generic;
using Cir.Data.LLBLGen.EntityClasses;
using Cir.Data.LLBLGen.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data.LLBLGen.FactoryClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END
	
	/// <summary>general base class for the generated factories</summary>
	[Serializable]
	public partial class EntityFactoryBase2 : EntityFactoryCore2
	{
		private string _entityName;
		private Cir.Data.LLBLGen.EntityType _typeOfEntity;
		
		/// <summary>CTor</summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		public EntityFactoryBase2(string entityName, Cir.Data.LLBLGen.EntityType typeOfEntity)
		{
			_entityName = entityName;
			_typeOfEntity = typeOfEntity;
		}
		
		/// <summary>Creates, using the generated EntityFieldsFactory, the IEntityFields2 object for the entity to create.</summary>
		/// <returns>Empty IEntityFields2 object.</returns>
		public override IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(_typeOfEntity);
		}
		
		/// <summary>Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value</summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public override IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return GeneralEntityFactory.Create((EntityType)entityTypeValue);
		}

		/// <summary>Creates the relations collection to the entity to join all targets so this entity can be fetched. </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		public override IRelationCollection CreateHierarchyRelations() 
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetHierarchyRelations(_entityName);
		}

		/// <summary>This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.</summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public override IEntityFactory2 GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity) 
		{
			IEntityFactory2 toReturn = (IEntityFactory2)InheritanceInfoProviderSingleton.GetInstance().GetEntityFactory(_entityName, fieldValues, entityFieldStartIndexesPerEntity);
			if(toReturn == null)
			{
				toReturn = this;
			}
			return toReturn;
		}
		
		/// <summary>Gets a predicateexpression which filters on the entity with type belonging to this factory.</summary>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false). </param>
		/// <returns>ready to use predicateexpression, or an empty predicate expression if the belonging entity isn't a hierarchical type.</returns>
		public override IPredicateExpression GetEntityTypeFilter(bool negate) 
		{
			return InheritanceInfoProviderSingleton.GetInstance().GetEntityTypeFilter(this.ForEntityName, negate);
		}
				
		/// <summary>returns the name of the entity this factory is for, e.g. "EmployeeEntity"</summary>
		public override string ForEntityName 
		{ 
			get { return _entityName; }
		}
	}
	
	/// <summary>Factory to create new, empty ActionOnTransformerEntity objects.</summary>
	[Serializable]
	public partial class ActionOnTransformerEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ActionOnTransformerEntityFactory() : base("ActionOnTransformerEntity", Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity) { }

		/// <summary>Creates a new, empty ActionOnTransformerEntity object.</summary>
		/// <returns>A new, empty ActionOnTransformerEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ActionOnTransformerEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewActionOnTransformer
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ActionOnTransformerEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ActionOnTransformerEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewActionOnTransformerUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ActionToBeTakenOnGeneratorEntity objects.</summary>
	[Serializable]
	public partial class ActionToBeTakenOnGeneratorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ActionToBeTakenOnGeneratorEntityFactory() : base("ActionToBeTakenOnGeneratorEntity", Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity) { }

		/// <summary>Creates a new, empty ActionToBeTakenOnGeneratorEntity object.</summary>
		/// <returns>A new, empty ActionToBeTakenOnGeneratorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ActionToBeTakenOnGeneratorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewActionToBeTakenOnGenerator
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ActionToBeTakenOnGeneratorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ActionToBeTakenOnGeneratorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewActionToBeTakenOnGeneratorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ArcDetectionEntity objects.</summary>
	[Serializable]
	public partial class ArcDetectionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ArcDetectionEntityFactory() : base("ArcDetectionEntity", Cir.Data.LLBLGen.EntityType.ArcDetectionEntity) { }

		/// <summary>Creates a new, empty ArcDetectionEntity object.</summary>
		/// <returns>A new, empty ArcDetectionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ArcDetectionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewArcDetection
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ArcDetectionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ArcDetectionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewArcDetectionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BearingDamageCategoryEntity objects.</summary>
	[Serializable]
	public partial class BearingDamageCategoryEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BearingDamageCategoryEntityFactory() : base("BearingDamageCategoryEntity", Cir.Data.LLBLGen.EntityType.BearingDamageCategoryEntity) { }

		/// <summary>Creates a new, empty BearingDamageCategoryEntity object.</summary>
		/// <returns>A new, empty BearingDamageCategoryEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BearingDamageCategoryEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBearingDamageCategory
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BearingDamageCategoryEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BearingDamageCategoryEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBearingDamageCategoryUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BearingErrorEntity objects.</summary>
	[Serializable]
	public partial class BearingErrorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BearingErrorEntityFactory() : base("BearingErrorEntity", Cir.Data.LLBLGen.EntityType.BearingErrorEntity) { }

		/// <summary>Creates a new, empty BearingErrorEntity object.</summary>
		/// <returns>A new, empty BearingErrorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BearingErrorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBearingError
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BearingErrorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BearingErrorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBearingErrorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BearingErrorVendorEntity objects.</summary>
	[Serializable]
	public partial class BearingErrorVendorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BearingErrorVendorEntityFactory() : base("BearingErrorVendorEntity", Cir.Data.LLBLGen.EntityType.BearingErrorVendorEntity) { }

		/// <summary>Creates a new, empty BearingErrorVendorEntity object.</summary>
		/// <returns>A new, empty BearingErrorVendorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BearingErrorVendorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBearingErrorVendor
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BearingErrorVendorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BearingErrorVendorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBearingErrorVendorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BearingPosEntity objects.</summary>
	[Serializable]
	public partial class BearingPosEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BearingPosEntityFactory() : base("BearingPosEntity", Cir.Data.LLBLGen.EntityType.BearingPosEntity) { }

		/// <summary>Creates a new, empty BearingPosEntity object.</summary>
		/// <returns>A new, empty BearingPosEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BearingPosEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBearingPos
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BearingPosEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BearingPosEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBearingPosUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BearingTypeEntity objects.</summary>
	[Serializable]
	public partial class BearingTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BearingTypeEntityFactory() : base("BearingTypeEntity", Cir.Data.LLBLGen.EntityType.BearingTypeEntity) { }

		/// <summary>Creates a new, empty BearingTypeEntity object.</summary>
		/// <returns>A new, empty BearingTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BearingTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBearingType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BearingTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BearingTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBearingTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BirDataEntity objects.</summary>
	[Serializable]
	public partial class BirDataEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BirDataEntityFactory() : base("BirDataEntity", Cir.Data.LLBLGen.EntityType.BirDataEntity) { }

		/// <summary>Creates a new, empty BirDataEntity object.</summary>
		/// <returns>A new, empty BirDataEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BirDataEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBirData
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BirDataEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BirDataEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBirDataUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BirReportPlaceholdersEntity objects.</summary>
	[Serializable]
	public partial class BirReportPlaceholdersEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BirReportPlaceholdersEntityFactory() : base("BirReportPlaceholdersEntity", Cir.Data.LLBLGen.EntityType.BirReportPlaceholdersEntity) { }

		/// <summary>Creates a new, empty BirReportPlaceholdersEntity object.</summary>
		/// <returns>A new, empty BirReportPlaceholdersEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BirReportPlaceholdersEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBirReportPlaceholders
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BirReportPlaceholdersEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BirReportPlaceholdersEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBirReportPlaceholdersUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BirWordDocumentEntity objects.</summary>
	[Serializable]
	public partial class BirWordDocumentEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BirWordDocumentEntityFactory() : base("BirWordDocumentEntity", Cir.Data.LLBLGen.EntityType.BirWordDocumentEntity) { }

		/// <summary>Creates a new, empty BirWordDocumentEntity object.</summary>
		/// <returns>A new, empty BirWordDocumentEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BirWordDocumentEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBirWordDocument
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BirWordDocumentEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BirWordDocumentEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBirWordDocumentUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BladeColorEntity objects.</summary>
	[Serializable]
	public partial class BladeColorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BladeColorEntityFactory() : base("BladeColorEntity", Cir.Data.LLBLGen.EntityType.BladeColorEntity) { }

		/// <summary>Creates a new, empty BladeColorEntity object.</summary>
		/// <returns>A new, empty BladeColorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BladeColorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeColor
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BladeColorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BladeColorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeColorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BladeDamagePlacementEntity objects.</summary>
	[Serializable]
	public partial class BladeDamagePlacementEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BladeDamagePlacementEntityFactory() : base("BladeDamagePlacementEntity", Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity) { }

		/// <summary>Creates a new, empty BladeDamagePlacementEntity object.</summary>
		/// <returns>A new, empty BladeDamagePlacementEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BladeDamagePlacementEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeDamagePlacement
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BladeDamagePlacementEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BladeDamagePlacementEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeDamagePlacementUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BladeEdgeEntity objects.</summary>
	[Serializable]
	public partial class BladeEdgeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BladeEdgeEntityFactory() : base("BladeEdgeEntity", Cir.Data.LLBLGen.EntityType.BladeEdgeEntity) { }

		/// <summary>Creates a new, empty BladeEdgeEntity object.</summary>
		/// <returns>A new, empty BladeEdgeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BladeEdgeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeEdge
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BladeEdgeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BladeEdgeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeEdgeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BladeInspectionDataEntity objects.</summary>
	[Serializable]
	public partial class BladeInspectionDataEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BladeInspectionDataEntityFactory() : base("BladeInspectionDataEntity", Cir.Data.LLBLGen.EntityType.BladeInspectionDataEntity) { }

		/// <summary>Creates a new, empty BladeInspectionDataEntity object.</summary>
		/// <returns>A new, empty BladeInspectionDataEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BladeInspectionDataEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeInspectionData
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BladeInspectionDataEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BladeInspectionDataEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeInspectionDataUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BladeLengthEntity objects.</summary>
	[Serializable]
	public partial class BladeLengthEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BladeLengthEntityFactory() : base("BladeLengthEntity", Cir.Data.LLBLGen.EntityType.BladeLengthEntity) { }

		/// <summary>Creates a new, empty BladeLengthEntity object.</summary>
		/// <returns>A new, empty BladeLengthEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BladeLengthEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeLength
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BladeLengthEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BladeLengthEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeLengthUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BladeManufacturerEntity objects.</summary>
	[Serializable]
	public partial class BladeManufacturerEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BladeManufacturerEntityFactory() : base("BladeManufacturerEntity", Cir.Data.LLBLGen.EntityType.BladeManufacturerEntity) { }

		/// <summary>Creates a new, empty BladeManufacturerEntity object.</summary>
		/// <returns>A new, empty BladeManufacturerEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BladeManufacturerEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeManufacturer
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BladeManufacturerEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BladeManufacturerEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBladeManufacturerUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BooleanAnswerEntity objects.</summary>
	[Serializable]
	public partial class BooleanAnswerEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BooleanAnswerEntityFactory() : base("BooleanAnswerEntity", Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity) { }

		/// <summary>Creates a new, empty BooleanAnswerEntity object.</summary>
		/// <returns>A new, empty BooleanAnswerEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BooleanAnswerEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBooleanAnswer
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BooleanAnswerEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BooleanAnswerEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBooleanAnswerUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty BracketsEntity objects.</summary>
	[Serializable]
	public partial class BracketsEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public BracketsEntityFactory() : base("BracketsEntity", Cir.Data.LLBLGen.EntityType.BracketsEntity) { }

		/// <summary>Creates a new, empty BracketsEntity object.</summary>
		/// <returns>A new, empty BracketsEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new BracketsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBrackets
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new BracketsEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new BracketsEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewBracketsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CableConditionEntity objects.</summary>
	[Serializable]
	public partial class CableConditionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CableConditionEntityFactory() : base("CableConditionEntity", Cir.Data.LLBLGen.EntityType.CableConditionEntity) { }

		/// <summary>Creates a new, empty CableConditionEntity object.</summary>
		/// <returns>A new, empty CableConditionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CableConditionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCableCondition
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CableConditionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CableConditionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCableConditionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CimCaseFailureItemsEntity objects.</summary>
	[Serializable]
	public partial class CimCaseFailureItemsEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CimCaseFailureItemsEntityFactory() : base("CimCaseFailureItemsEntity", Cir.Data.LLBLGen.EntityType.CimCaseFailureItemsEntity) { }

		/// <summary>Creates a new, empty CimCaseFailureItemsEntity object.</summary>
		/// <returns>A new, empty CimCaseFailureItemsEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CimCaseFailureItemsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCimCaseFailureItems
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CimCaseFailureItemsEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CimCaseFailureItemsEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCimCaseFailureItemsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirAttachmentEntity objects.</summary>
	[Serializable]
	public partial class CirAttachmentEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirAttachmentEntityFactory() : base("CirAttachmentEntity", Cir.Data.LLBLGen.EntityType.CirAttachmentEntity) { }

		/// <summary>Creates a new, empty CirAttachmentEntity object.</summary>
		/// <returns>A new, empty CirAttachmentEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirAttachmentEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirAttachment
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirAttachmentEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirAttachmentEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirAttachmentUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirCommentHistoryEntity objects.</summary>
	[Serializable]
	public partial class CirCommentHistoryEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirCommentHistoryEntityFactory() : base("CirCommentHistoryEntity", Cir.Data.LLBLGen.EntityType.CirCommentHistoryEntity) { }

		/// <summary>Creates a new, empty CirCommentHistoryEntity object.</summary>
		/// <returns>A new, empty CirCommentHistoryEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirCommentHistoryEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirCommentHistory
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirCommentHistoryEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirCommentHistoryEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirCommentHistoryUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirDataEntity objects.</summary>
	[Serializable]
	public partial class CirDataEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirDataEntityFactory() : base("CirDataEntity", Cir.Data.LLBLGen.EntityType.CirDataEntity) { }

		/// <summary>Creates a new, empty CirDataEntity object.</summary>
		/// <returns>A new, empty CirDataEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirDataEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirData
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirDataEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirDataEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirDataUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirinboxTimestampEntity objects.</summary>
	[Serializable]
	public partial class CirinboxTimestampEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirinboxTimestampEntityFactory() : base("CirinboxTimestampEntity", Cir.Data.LLBLGen.EntityType.CirinboxTimestampEntity) { }

		/// <summary>Creates a new, empty CirinboxTimestampEntity object.</summary>
		/// <returns>A new, empty CirinboxTimestampEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirinboxTimestampEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirinboxTimestamp
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirinboxTimestampEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirinboxTimestampEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirinboxTimestampUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirInvalidEntity objects.</summary>
	[Serializable]
	public partial class CirInvalidEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirInvalidEntityFactory() : base("CirInvalidEntity", Cir.Data.LLBLGen.EntityType.CirInvalidEntity) { }

		/// <summary>Creates a new, empty CirInvalidEntity object.</summary>
		/// <returns>A new, empty CirInvalidEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirInvalidEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirInvalid
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirInvalidEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirInvalidEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirInvalidUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirLogEntity objects.</summary>
	[Serializable]
	public partial class CirLogEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirLogEntityFactory() : base("CirLogEntity", Cir.Data.LLBLGen.EntityType.CirLogEntity) { }

		/// <summary>Creates a new, empty CirLogEntity object.</summary>
		/// <returns>A new, empty CirLogEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirLogEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirLog
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirLogEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirLogEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirLogUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirMailArchiveEntity objects.</summary>
	[Serializable]
	public partial class CirMailArchiveEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirMailArchiveEntityFactory() : base("CirMailArchiveEntity", Cir.Data.LLBLGen.EntityType.CirMailArchiveEntity) { }

		/// <summary>Creates a new, empty CirMailArchiveEntity object.</summary>
		/// <returns>A new, empty CirMailArchiveEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirMailArchiveEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirMailArchive
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirMailArchiveEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirMailArchiveEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirMailArchiveUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirMetadataEntity objects.</summary>
	[Serializable]
	public partial class CirMetadataEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirMetadataEntityFactory() : base("CirMetadataEntity", Cir.Data.LLBLGen.EntityType.CirMetadataEntity) { }

		/// <summary>Creates a new, empty CirMetadataEntity object.</summary>
		/// <returns>A new, empty CirMetadataEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirMetadataEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirMetadata
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirMetadataEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirMetadataEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirMetadataUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirMetadataLookupEntity objects.</summary>
	[Serializable]
	public partial class CirMetadataLookupEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirMetadataLookupEntityFactory() : base("CirMetadataLookupEntity", Cir.Data.LLBLGen.EntityType.CirMetadataLookupEntity) { }

		/// <summary>Creates a new, empty CirMetadataLookupEntity object.</summary>
		/// <returns>A new, empty CirMetadataLookupEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirMetadataLookupEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirMetadataLookup
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirMetadataLookupEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirMetadataLookupEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirMetadataLookupUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirStandardTextsEntity objects.</summary>
	[Serializable]
	public partial class CirStandardTextsEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirStandardTextsEntityFactory() : base("CirStandardTextsEntity", Cir.Data.LLBLGen.EntityType.CirStandardTextsEntity) { }

		/// <summary>Creates a new, empty CirStandardTextsEntity object.</summary>
		/// <returns>A new, empty CirStandardTextsEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirStandardTextsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirStandardTexts
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirStandardTextsEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirStandardTextsEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirStandardTextsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirSystemLogEntity objects.</summary>
	[Serializable]
	public partial class CirSystemLogEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirSystemLogEntityFactory() : base("CirSystemLogEntity", Cir.Data.LLBLGen.EntityType.CirSystemLogEntity) { }

		/// <summary>Creates a new, empty CirSystemLogEntity object.</summary>
		/// <returns>A new, empty CirSystemLogEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirSystemLogEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirSystemLog
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirSystemLogEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirSystemLogEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirSystemLogUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirSystemMonitorEntity objects.</summary>
	[Serializable]
	public partial class CirSystemMonitorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirSystemMonitorEntityFactory() : base("CirSystemMonitorEntity", Cir.Data.LLBLGen.EntityType.CirSystemMonitorEntity) { }

		/// <summary>Creates a new, empty CirSystemMonitorEntity object.</summary>
		/// <returns>A new, empty CirSystemMonitorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirSystemMonitorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirSystemMonitor
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirSystemMonitorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirSystemMonitorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirSystemMonitorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirUserEntity objects.</summary>
	[Serializable]
	public partial class CirUserEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirUserEntityFactory() : base("CirUserEntity", Cir.Data.LLBLGen.EntityType.CirUserEntity) { }

		/// <summary>Creates a new, empty CirUserEntity object.</summary>
		/// <returns>A new, empty CirUserEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirUserEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirUser
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirUserEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirUserEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirUserUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirViewEntity objects.</summary>
	[Serializable]
	public partial class CirViewEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirViewEntityFactory() : base("CirViewEntity", Cir.Data.LLBLGen.EntityType.CirViewEntity) { }

		/// <summary>Creates a new, empty CirViewEntity object.</summary>
		/// <returns>A new, empty CirViewEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirViewEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirView
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirViewEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirViewEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirViewUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CirXmlEntity objects.</summary>
	[Serializable]
	public partial class CirXmlEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CirXmlEntityFactory() : base("CirXmlEntity", Cir.Data.LLBLGen.EntityType.CirXmlEntity) { }

		/// <summary>Creates a new, empty CirXmlEntity object.</summary>
		/// <returns>A new, empty CirXmlEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CirXmlEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirXml
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CirXmlEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CirXmlEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCirXmlUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ClimateEntity objects.</summary>
	[Serializable]
	public partial class ClimateEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ClimateEntityFactory() : base("ClimateEntity", Cir.Data.LLBLGen.EntityType.ClimateEntity) { }

		/// <summary>Creates a new, empty ClimateEntity object.</summary>
		/// <returns>A new, empty ClimateEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ClimateEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClimate
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ClimateEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ClimateEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewClimateUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CoilConditionEntity objects.</summary>
	[Serializable]
	public partial class CoilConditionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CoilConditionEntityFactory() : base("CoilConditionEntity", Cir.Data.LLBLGen.EntityType.CoilConditionEntity) { }

		/// <summary>Creates a new, empty CoilConditionEntity object.</summary>
		/// <returns>A new, empty CoilConditionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CoilConditionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCoilCondition
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CoilConditionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CoilConditionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCoilConditionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentGroupEntity objects.</summary>
	[Serializable]
	public partial class ComponentGroupEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentGroupEntityFactory() : base("ComponentGroupEntity", Cir.Data.LLBLGen.EntityType.ComponentGroupEntity) { }

		/// <summary>Creates a new, empty ComponentGroupEntity object.</summary>
		/// <returns>A new, empty ComponentGroupEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentGroupEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentGroup
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentGroupEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentGroupEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentGroupUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportEntityFactory() : base("ComponentInspectionReportEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReport
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportBladeEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportBladeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportBladeEntityFactory() : base("ComponentInspectionReportBladeEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportBladeEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportBladeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportBladeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportBlade
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportBladeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportBladeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportBladeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportBladeDamageEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportBladeDamageEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportBladeDamageEntityFactory() : base("ComponentInspectionReportBladeDamageEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeDamageEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportBladeDamageEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportBladeDamageEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportBladeDamageEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportBladeDamage
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportBladeDamageEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportBladeDamageEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportBladeDamageUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportBladeRepairRecordEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportBladeRepairRecordEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportBladeRepairRecordEntityFactory() : base("ComponentInspectionReportBladeRepairRecordEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeRepairRecordEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportBladeRepairRecordEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportBladeRepairRecordEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportBladeRepairRecordEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportBladeRepairRecord
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportBladeRepairRecordEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportBladeRepairRecordEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportBladeRepairRecordUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportGearboxEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportGearboxEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportGearboxEntityFactory() : base("ComponentInspectionReportGearboxEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportGearboxEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportGearboxEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportGearboxEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportGearbox
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportGearboxEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportGearboxEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportGearboxUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportGeneralEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportGeneralEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportGeneralEntityFactory() : base("ComponentInspectionReportGeneralEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportGeneralEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportGeneralEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportGeneralEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportGeneral
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportGeneralEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportGeneralEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportGeneralUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportGeneratorEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportGeneratorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportGeneratorEntityFactory() : base("ComponentInspectionReportGeneratorEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportGeneratorEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportGeneratorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportGeneratorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportGenerator
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportGeneratorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportGeneratorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportGeneratorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportMainBearingEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportMainBearingEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportMainBearingEntityFactory() : base("ComponentInspectionReportMainBearingEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportMainBearingEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportMainBearingEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportMainBearingEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportMainBearing
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportMainBearingEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportMainBearingEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportMainBearingUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportSkiiPEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportSkiiPEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportSkiiPEntityFactory() : base("ComponentInspectionReportSkiiPEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportSkiiPEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportSkiiPEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportSkiiPEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportSkiiP
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportSkiiPEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportSkiiPEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportSkiiPUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportSkiiPfailedComponentEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportSkiiPfailedComponentEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportSkiiPfailedComponentEntityFactory() : base("ComponentInspectionReportSkiiPfailedComponentEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPfailedComponentEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportSkiiPfailedComponentEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportSkiiPfailedComponentEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportSkiiPfailedComponentEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportSkiiPfailedComponent
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportSkiiPfailedComponentEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportSkiiPfailedComponentEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportSkiiPfailedComponentUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportSkiiPnewComponentEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportSkiiPnewComponentEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportSkiiPnewComponentEntityFactory() : base("ComponentInspectionReportSkiiPnewComponentEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPnewComponentEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportSkiiPnewComponentEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportSkiiPnewComponentEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportSkiiPnewComponentEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportSkiiPnewComponent
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportSkiiPnewComponentEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportSkiiPnewComponentEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportSkiiPnewComponentUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportStateEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportStateEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportStateEntityFactory() : base("ComponentInspectionReportStateEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportStateEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportStateEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportStateEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportStateEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportState
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportStateEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportStateEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportStateUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportTransformerEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportTransformerEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportTransformerEntityFactory() : base("ComponentInspectionReportTransformerEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportTransformerEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportTransformerEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportTransformerEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportTransformer
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportTransformerEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportTransformerEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportTransformerUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentInspectionReportTypeEntity objects.</summary>
	[Serializable]
	public partial class ComponentInspectionReportTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentInspectionReportTypeEntityFactory() : base("ComponentInspectionReportTypeEntity", Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTypeEntity) { }

		/// <summary>Creates a new, empty ComponentInspectionReportTypeEntity object.</summary>
		/// <returns>A new, empty ComponentInspectionReportTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentInspectionReportTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentInspectionReportTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentInspectionReportTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentInspectionReportTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ComponentUpTowerSolutionEntity objects.</summary>
	[Serializable]
	public partial class ComponentUpTowerSolutionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ComponentUpTowerSolutionEntityFactory() : base("ComponentUpTowerSolutionEntity", Cir.Data.LLBLGen.EntityType.ComponentUpTowerSolutionEntity) { }

		/// <summary>Creates a new, empty ComponentUpTowerSolutionEntity object.</summary>
		/// <returns>A new, empty ComponentUpTowerSolutionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ComponentUpTowerSolutionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentUpTowerSolution
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ComponentUpTowerSolutionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ComponentUpTowerSolutionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewComponentUpTowerSolutionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ConnectionBarsEntity objects.</summary>
	[Serializable]
	public partial class ConnectionBarsEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ConnectionBarsEntityFactory() : base("ConnectionBarsEntity", Cir.Data.LLBLGen.EntityType.ConnectionBarsEntity) { }

		/// <summary>Creates a new, empty ConnectionBarsEntity object.</summary>
		/// <returns>A new, empty ConnectionBarsEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ConnectionBarsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewConnectionBars
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ConnectionBarsEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ConnectionBarsEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewConnectionBarsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ControllerTypeEntity objects.</summary>
	[Serializable]
	public partial class ControllerTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ControllerTypeEntityFactory() : base("ControllerTypeEntity", Cir.Data.LLBLGen.EntityType.ControllerTypeEntity) { }

		/// <summary>Creates a new, empty ControllerTypeEntity object.</summary>
		/// <returns>A new, empty ControllerTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ControllerTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewControllerType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ControllerTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ControllerTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewControllerTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CountryIsoEntity objects.</summary>
	[Serializable]
	public partial class CountryIsoEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CountryIsoEntityFactory() : base("CountryIsoEntity", Cir.Data.LLBLGen.EntityType.CountryIsoEntity) { }

		/// <summary>Creates a new, empty CountryIsoEntity object.</summary>
		/// <returns>A new, empty CountryIsoEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CountryIsoEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCountryIso
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CountryIsoEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CountryIsoEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCountryIsoUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty CouplingEntity objects.</summary>
	[Serializable]
	public partial class CouplingEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public CouplingEntityFactory() : base("CouplingEntity", Cir.Data.LLBLGen.EntityType.CouplingEntity) { }

		/// <summary>Creates a new, empty CouplingEntity object.</summary>
		/// <returns>A new, empty CouplingEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new CouplingEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCoupling
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new CouplingEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new CouplingEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewCouplingUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty DamageEntity objects.</summary>
	[Serializable]
	public partial class DamageEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public DamageEntityFactory() : base("DamageEntity", Cir.Data.LLBLGen.EntityType.DamageEntity) { }

		/// <summary>Creates a new, empty DamageEntity object.</summary>
		/// <returns>A new, empty DamageEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new DamageEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDamage
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new DamageEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new DamageEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDamageUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty DamageDecisionEntity objects.</summary>
	[Serializable]
	public partial class DamageDecisionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public DamageDecisionEntityFactory() : base("DamageDecisionEntity", Cir.Data.LLBLGen.EntityType.DamageDecisionEntity) { }

		/// <summary>Creates a new, empty DamageDecisionEntity object.</summary>
		/// <returns>A new, empty DamageDecisionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new DamageDecisionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDamageDecision
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new DamageDecisionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new DamageDecisionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDamageDecisionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty DebrisGearboxEntity objects.</summary>
	[Serializable]
	public partial class DebrisGearboxEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public DebrisGearboxEntityFactory() : base("DebrisGearboxEntity", Cir.Data.LLBLGen.EntityType.DebrisGearboxEntity) { }

		/// <summary>Creates a new, empty DebrisGearboxEntity object.</summary>
		/// <returns>A new, empty DebrisGearboxEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new DebrisGearboxEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDebrisGearbox
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new DebrisGearboxEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new DebrisGearboxEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDebrisGearboxUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty DebrisOnMagnetEntity objects.</summary>
	[Serializable]
	public partial class DebrisOnMagnetEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public DebrisOnMagnetEntityFactory() : base("DebrisOnMagnetEntity", Cir.Data.LLBLGen.EntityType.DebrisOnMagnetEntity) { }

		/// <summary>Creates a new, empty DebrisOnMagnetEntity object.</summary>
		/// <returns>A new, empty DebrisOnMagnetEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new DebrisOnMagnetEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDebrisOnMagnet
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new DebrisOnMagnetEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new DebrisOnMagnetEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDebrisOnMagnetUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty DynamicTableInputEntity objects.</summary>
	[Serializable]
	public partial class DynamicTableInputEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public DynamicTableInputEntityFactory() : base("DynamicTableInputEntity", Cir.Data.LLBLGen.EntityType.DynamicTableInputEntity) { }

		/// <summary>Creates a new, empty DynamicTableInputEntity object.</summary>
		/// <returns>A new, empty DynamicTableInputEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new DynamicTableInputEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDynamicTableInput
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new DynamicTableInputEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new DynamicTableInputEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewDynamicTableInputUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty EditHistoryEntity objects.</summary>
	[Serializable]
	public partial class EditHistoryEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public EditHistoryEntityFactory() : base("EditHistoryEntity", Cir.Data.LLBLGen.EntityType.EditHistoryEntity) { }

		/// <summary>Creates a new, empty EditHistoryEntity object.</summary>
		/// <returns>A new, empty EditHistoryEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new EditHistoryEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEditHistory
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new EditHistoryEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new EditHistoryEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewEditHistoryUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ElectricalPumpEntity objects.</summary>
	[Serializable]
	public partial class ElectricalPumpEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ElectricalPumpEntityFactory() : base("ElectricalPumpEntity", Cir.Data.LLBLGen.EntityType.ElectricalPumpEntity) { }

		/// <summary>Creates a new, empty ElectricalPumpEntity object.</summary>
		/// <returns>A new, empty ElectricalPumpEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ElectricalPumpEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewElectricalPump
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ElectricalPumpEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ElectricalPumpEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewElectricalPumpUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty FaultCodeAreaEntity objects.</summary>
	[Serializable]
	public partial class FaultCodeAreaEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public FaultCodeAreaEntityFactory() : base("FaultCodeAreaEntity", Cir.Data.LLBLGen.EntityType.FaultCodeAreaEntity) { }

		/// <summary>Creates a new, empty FaultCodeAreaEntity object.</summary>
		/// <returns>A new, empty FaultCodeAreaEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new FaultCodeAreaEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFaultCodeArea
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new FaultCodeAreaEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new FaultCodeAreaEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFaultCodeAreaUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty FaultCodeCauseEntity objects.</summary>
	[Serializable]
	public partial class FaultCodeCauseEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public FaultCodeCauseEntityFactory() : base("FaultCodeCauseEntity", Cir.Data.LLBLGen.EntityType.FaultCodeCauseEntity) { }

		/// <summary>Creates a new, empty FaultCodeCauseEntity object.</summary>
		/// <returns>A new, empty FaultCodeCauseEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new FaultCodeCauseEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFaultCodeCause
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new FaultCodeCauseEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new FaultCodeCauseEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFaultCodeCauseUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty FaultCodeClassificationEntity objects.</summary>
	[Serializable]
	public partial class FaultCodeClassificationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public FaultCodeClassificationEntityFactory() : base("FaultCodeClassificationEntity", Cir.Data.LLBLGen.EntityType.FaultCodeClassificationEntity) { }

		/// <summary>Creates a new, empty FaultCodeClassificationEntity object.</summary>
		/// <returns>A new, empty FaultCodeClassificationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new FaultCodeClassificationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFaultCodeClassification
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new FaultCodeClassificationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new FaultCodeClassificationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFaultCodeClassificationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty FaultCodeTypeEntity objects.</summary>
	[Serializable]
	public partial class FaultCodeTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public FaultCodeTypeEntityFactory() : base("FaultCodeTypeEntity", Cir.Data.LLBLGen.EntityType.FaultCodeTypeEntity) { }

		/// <summary>Creates a new, empty FaultCodeTypeEntity object.</summary>
		/// <returns>A new, empty FaultCodeTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new FaultCodeTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFaultCodeType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new FaultCodeTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new FaultCodeTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFaultCodeTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty FilterBlockTypeEntity objects.</summary>
	[Serializable]
	public partial class FilterBlockTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public FilterBlockTypeEntityFactory() : base("FilterBlockTypeEntity", Cir.Data.LLBLGen.EntityType.FilterBlockTypeEntity) { }

		/// <summary>Creates a new, empty FilterBlockTypeEntity object.</summary>
		/// <returns>A new, empty FilterBlockTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new FilterBlockTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFilterBlockType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new FilterBlockTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new FilterBlockTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFilterBlockTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty FirstNotificationEntity objects.</summary>
	[Serializable]
	public partial class FirstNotificationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public FirstNotificationEntityFactory() : base("FirstNotificationEntity", Cir.Data.LLBLGen.EntityType.FirstNotificationEntity) { }

		/// <summary>Creates a new, empty FirstNotificationEntity object.</summary>
		/// <returns>A new, empty FirstNotificationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new FirstNotificationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFirstNotification
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new FirstNotificationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new FirstNotificationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewFirstNotificationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GearboxDefectCategorizationEntity objects.</summary>
	[Serializable]
	public partial class GearboxDefectCategorizationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GearboxDefectCategorizationEntityFactory() : base("GearboxDefectCategorizationEntity", Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationEntity) { }

		/// <summary>Creates a new, empty GearboxDefectCategorizationEntity object.</summary>
		/// <returns>A new, empty GearboxDefectCategorizationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GearboxDefectCategorizationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxDefectCategorization
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GearboxDefectCategorizationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GearboxDefectCategorizationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxDefectCategorizationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GearboxDefectCategorizationDetailsEntity objects.</summary>
	[Serializable]
	public partial class GearboxDefectCategorizationDetailsEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GearboxDefectCategorizationDetailsEntityFactory() : base("GearboxDefectCategorizationDetailsEntity", Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationDetailsEntity) { }

		/// <summary>Creates a new, empty GearboxDefectCategorizationDetailsEntity object.</summary>
		/// <returns>A new, empty GearboxDefectCategorizationDetailsEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GearboxDefectCategorizationDetailsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxDefectCategorizationDetails
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GearboxDefectCategorizationDetailsEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GearboxDefectCategorizationDetailsEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxDefectCategorizationDetailsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GearboxManufacturerEntity objects.</summary>
	[Serializable]
	public partial class GearboxManufacturerEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GearboxManufacturerEntityFactory() : base("GearboxManufacturerEntity", Cir.Data.LLBLGen.EntityType.GearboxManufacturerEntity) { }

		/// <summary>Creates a new, empty GearboxManufacturerEntity object.</summary>
		/// <returns>A new, empty GearboxManufacturerEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GearboxManufacturerEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxManufacturer
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GearboxManufacturerEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GearboxManufacturerEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxManufacturerUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GearboxPartTypeEntity objects.</summary>
	[Serializable]
	public partial class GearboxPartTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GearboxPartTypeEntityFactory() : base("GearboxPartTypeEntity", Cir.Data.LLBLGen.EntityType.GearboxPartTypeEntity) { }

		/// <summary>Creates a new, empty GearboxPartTypeEntity object.</summary>
		/// <returns>A new, empty GearboxPartTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GearboxPartTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxPartType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GearboxPartTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GearboxPartTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxPartTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GearboxRevisionEntity objects.</summary>
	[Serializable]
	public partial class GearboxRevisionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GearboxRevisionEntityFactory() : base("GearboxRevisionEntity", Cir.Data.LLBLGen.EntityType.GearboxRevisionEntity) { }

		/// <summary>Creates a new, empty GearboxRevisionEntity object.</summary>
		/// <returns>A new, empty GearboxRevisionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GearboxRevisionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxRevision
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GearboxRevisionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GearboxRevisionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxRevisionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GearboxTypeEntity objects.</summary>
	[Serializable]
	public partial class GearboxTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GearboxTypeEntityFactory() : base("GearboxTypeEntity", Cir.Data.LLBLGen.EntityType.GearboxTypeEntity) { }

		/// <summary>Creates a new, empty GearboxTypeEntity object.</summary>
		/// <returns>A new, empty GearboxTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GearboxTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GearboxTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GearboxTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearboxTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GearDamageCategoryEntity objects.</summary>
	[Serializable]
	public partial class GearDamageCategoryEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GearDamageCategoryEntityFactory() : base("GearDamageCategoryEntity", Cir.Data.LLBLGen.EntityType.GearDamageCategoryEntity) { }

		/// <summary>Creates a new, empty GearDamageCategoryEntity object.</summary>
		/// <returns>A new, empty GearDamageCategoryEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GearDamageCategoryEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearDamageCategory
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GearDamageCategoryEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GearDamageCategoryEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearDamageCategoryUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GearErrorEntity objects.</summary>
	[Serializable]
	public partial class GearErrorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GearErrorEntityFactory() : base("GearErrorEntity", Cir.Data.LLBLGen.EntityType.GearErrorEntity) { }

		/// <summary>Creates a new, empty GearErrorEntity object.</summary>
		/// <returns>A new, empty GearErrorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GearErrorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearError
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GearErrorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GearErrorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearErrorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GearErrorVendorEntity objects.</summary>
	[Serializable]
	public partial class GearErrorVendorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GearErrorVendorEntityFactory() : base("GearErrorVendorEntity", Cir.Data.LLBLGen.EntityType.GearErrorVendorEntity) { }

		/// <summary>Creates a new, empty GearErrorVendorEntity object.</summary>
		/// <returns>A new, empty GearErrorVendorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GearErrorVendorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearErrorVendor
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GearErrorVendorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GearErrorVendorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearErrorVendorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GearTypeEntity objects.</summary>
	[Serializable]
	public partial class GearTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GearTypeEntityFactory() : base("GearTypeEntity", Cir.Data.LLBLGen.EntityType.GearTypeEntity) { }

		/// <summary>Creates a new, empty GearTypeEntity object.</summary>
		/// <returns>A new, empty GearTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GearTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GearTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GearTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGearTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GenerateCiridEntity objects.</summary>
	[Serializable]
	public partial class GenerateCiridEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GenerateCiridEntityFactory() : base("GenerateCiridEntity", Cir.Data.LLBLGen.EntityType.GenerateCiridEntity) { }

		/// <summary>Creates a new, empty GenerateCiridEntity object.</summary>
		/// <returns>A new, empty GenerateCiridEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GenerateCiridEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGenerateCirid
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GenerateCiridEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GenerateCiridEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGenerateCiridUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorBearingDecisionEntity objects.</summary>
	[Serializable]
	public partial class GeneratorBearingDecisionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorBearingDecisionEntityFactory() : base("GeneratorBearingDecisionEntity", Cir.Data.LLBLGen.EntityType.GeneratorBearingDecisionEntity) { }

		/// <summary>Creates a new, empty GeneratorBearingDecisionEntity object.</summary>
		/// <returns>A new, empty GeneratorBearingDecisionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorBearingDecisionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorBearingDecision
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorBearingDecisionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorBearingDecisionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorBearingDecisionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorComponentDamageEntity objects.</summary>
	[Serializable]
	public partial class GeneratorComponentDamageEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorComponentDamageEntityFactory() : base("GeneratorComponentDamageEntity", Cir.Data.LLBLGen.EntityType.GeneratorComponentDamageEntity) { }

		/// <summary>Creates a new, empty GeneratorComponentDamageEntity object.</summary>
		/// <returns>A new, empty GeneratorComponentDamageEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorComponentDamageEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorComponentDamage
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorComponentDamageEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorComponentDamageEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorComponentDamageUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorCoverEntity objects.</summary>
	[Serializable]
	public partial class GeneratorCoverEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorCoverEntityFactory() : base("GeneratorCoverEntity", Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity) { }

		/// <summary>Creates a new, empty GeneratorCoverEntity object.</summary>
		/// <returns>A new, empty GeneratorCoverEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorCoverEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorCover
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorCoverEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorCoverEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorCoverUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorDefectCategorizationEntity objects.</summary>
	[Serializable]
	public partial class GeneratorDefectCategorizationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorDefectCategorizationEntityFactory() : base("GeneratorDefectCategorizationEntity", Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity) { }

		/// <summary>Creates a new, empty GeneratorDefectCategorizationEntity object.</summary>
		/// <returns>A new, empty GeneratorDefectCategorizationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorDefectCategorizationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorDefectCategorization
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorDefectCategorizationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorDefectCategorizationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorDefectCategorizationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorDefectCategorization2Entity objects.</summary>
	[Serializable]
	public partial class GeneratorDefectCategorization2EntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorDefectCategorization2EntityFactory() : base("GeneratorDefectCategorization2Entity", Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2Entity) { }

		/// <summary>Creates a new, empty GeneratorDefectCategorization2Entity object.</summary>
		/// <returns>A new, empty GeneratorDefectCategorization2Entity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorDefectCategorization2Entity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorDefectCategorization2
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorDefectCategorization2Entity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorDefectCategorization2Entity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorDefectCategorization2UsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorDefectCategorization2DetailsEntity objects.</summary>
	[Serializable]
	public partial class GeneratorDefectCategorization2DetailsEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorDefectCategorization2DetailsEntityFactory() : base("GeneratorDefectCategorization2DetailsEntity", Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2DetailsEntity) { }

		/// <summary>Creates a new, empty GeneratorDefectCategorization2DetailsEntity object.</summary>
		/// <returns>A new, empty GeneratorDefectCategorization2DetailsEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorDefectCategorization2DetailsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorDefectCategorization2Details
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorDefectCategorization2DetailsEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorDefectCategorization2DetailsEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorDefectCategorization2DetailsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorDriveEndEntity objects.</summary>
	[Serializable]
	public partial class GeneratorDriveEndEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorDriveEndEntityFactory() : base("GeneratorDriveEndEntity", Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity) { }

		/// <summary>Creates a new, empty GeneratorDriveEndEntity object.</summary>
		/// <returns>A new, empty GeneratorDriveEndEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorDriveEndEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorDriveEnd
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorDriveEndEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorDriveEndEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorDriveEndUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorManufacturerEntity objects.</summary>
	[Serializable]
	public partial class GeneratorManufacturerEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorManufacturerEntityFactory() : base("GeneratorManufacturerEntity", Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity) { }

		/// <summary>Creates a new, empty GeneratorManufacturerEntity object.</summary>
		/// <returns>A new, empty GeneratorManufacturerEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorManufacturerEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorManufacturer
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorManufacturerEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorManufacturerEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorManufacturerUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorMiscDecisionEntity objects.</summary>
	[Serializable]
	public partial class GeneratorMiscDecisionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorMiscDecisionEntityFactory() : base("GeneratorMiscDecisionEntity", Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity) { }

		/// <summary>Creates a new, empty GeneratorMiscDecisionEntity object.</summary>
		/// <returns>A new, empty GeneratorMiscDecisionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorMiscDecisionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorMiscDecision
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorMiscDecisionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorMiscDecisionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorMiscDecisionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorNonDriveEndEntity objects.</summary>
	[Serializable]
	public partial class GeneratorNonDriveEndEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorNonDriveEndEntityFactory() : base("GeneratorNonDriveEndEntity", Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity) { }

		/// <summary>Creates a new, empty GeneratorNonDriveEndEntity object.</summary>
		/// <returns>A new, empty GeneratorNonDriveEndEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorNonDriveEndEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorNonDriveEnd
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorNonDriveEndEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorNonDriveEndEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorNonDriveEndUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorPhaseOutletDecisionEntity objects.</summary>
	[Serializable]
	public partial class GeneratorPhaseOutletDecisionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorPhaseOutletDecisionEntityFactory() : base("GeneratorPhaseOutletDecisionEntity", Cir.Data.LLBLGen.EntityType.GeneratorPhaseOutletDecisionEntity) { }

		/// <summary>Creates a new, empty GeneratorPhaseOutletDecisionEntity object.</summary>
		/// <returns>A new, empty GeneratorPhaseOutletDecisionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorPhaseOutletDecisionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorPhaseOutletDecision
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorPhaseOutletDecisionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorPhaseOutletDecisionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorPhaseOutletDecisionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorRotorEntity objects.</summary>
	[Serializable]
	public partial class GeneratorRotorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorRotorEntityFactory() : base("GeneratorRotorEntity", Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity) { }

		/// <summary>Creates a new, empty GeneratorRotorEntity object.</summary>
		/// <returns>A new, empty GeneratorRotorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorRotorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorRotor
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorRotorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorRotorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorRotorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorRotorDecisionEntity objects.</summary>
	[Serializable]
	public partial class GeneratorRotorDecisionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorRotorDecisionEntityFactory() : base("GeneratorRotorDecisionEntity", Cir.Data.LLBLGen.EntityType.GeneratorRotorDecisionEntity) { }

		/// <summary>Creates a new, empty GeneratorRotorDecisionEntity object.</summary>
		/// <returns>A new, empty GeneratorRotorDecisionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorRotorDecisionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorRotorDecision
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorRotorDecisionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorRotorDecisionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorRotorDecisionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorRotorLeadsDecisionEntity objects.</summary>
	[Serializable]
	public partial class GeneratorRotorLeadsDecisionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorRotorLeadsDecisionEntityFactory() : base("GeneratorRotorLeadsDecisionEntity", Cir.Data.LLBLGen.EntityType.GeneratorRotorLeadsDecisionEntity) { }

		/// <summary>Creates a new, empty GeneratorRotorLeadsDecisionEntity object.</summary>
		/// <returns>A new, empty GeneratorRotorLeadsDecisionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorRotorLeadsDecisionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorRotorLeadsDecision
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorRotorLeadsDecisionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorRotorLeadsDecisionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorRotorLeadsDecisionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty GeneratorStatorDecisionEntity objects.</summary>
	[Serializable]
	public partial class GeneratorStatorDecisionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public GeneratorStatorDecisionEntityFactory() : base("GeneratorStatorDecisionEntity", Cir.Data.LLBLGen.EntityType.GeneratorStatorDecisionEntity) { }

		/// <summary>Creates a new, empty GeneratorStatorDecisionEntity object.</summary>
		/// <returns>A new, empty GeneratorStatorDecisionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new GeneratorStatorDecisionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorStatorDecision
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new GeneratorStatorDecisionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new GeneratorStatorDecisionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewGeneratorStatorDecisionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty HotItemEntity objects.</summary>
	[Serializable]
	public partial class HotItemEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public HotItemEntityFactory() : base("HotItemEntity", Cir.Data.LLBLGen.EntityType.HotItemEntity) { }

		/// <summary>Creates a new, empty HotItemEntity object.</summary>
		/// <returns>A new, empty HotItemEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new HotItemEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewHotItem
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new HotItemEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new HotItemEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewHotItemUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty HotItemAdministratorEntity objects.</summary>
	[Serializable]
	public partial class HotItemAdministratorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public HotItemAdministratorEntityFactory() : base("HotItemAdministratorEntity", Cir.Data.LLBLGen.EntityType.HotItemAdministratorEntity) { }

		/// <summary>Creates a new, empty HotItemAdministratorEntity object.</summary>
		/// <returns>A new, empty HotItemAdministratorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new HotItemAdministratorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewHotItemAdministrator
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new HotItemAdministratorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new HotItemAdministratorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewHotItemAdministratorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty HousingErrorEntity objects.</summary>
	[Serializable]
	public partial class HousingErrorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public HousingErrorEntityFactory() : base("HousingErrorEntity", Cir.Data.LLBLGen.EntityType.HousingErrorEntity) { }

		/// <summary>Creates a new, empty HousingErrorEntity object.</summary>
		/// <returns>A new, empty HousingErrorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new HousingErrorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewHousingError
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new HousingErrorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new HousingErrorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewHousingErrorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty HousingErrorVendorEntity objects.</summary>
	[Serializable]
	public partial class HousingErrorVendorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public HousingErrorVendorEntityFactory() : base("HousingErrorVendorEntity", Cir.Data.LLBLGen.EntityType.HousingErrorVendorEntity) { }

		/// <summary>Creates a new, empty HousingErrorVendorEntity object.</summary>
		/// <returns>A new, empty HousingErrorVendorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new HousingErrorVendorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewHousingErrorVendor
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new HousingErrorVendorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new HousingErrorVendorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewHousingErrorVendorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty InlineFilterEntity objects.</summary>
	[Serializable]
	public partial class InlineFilterEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public InlineFilterEntityFactory() : base("InlineFilterEntity", Cir.Data.LLBLGen.EntityType.InlineFilterEntity) { }

		/// <summary>Creates a new, empty InlineFilterEntity object.</summary>
		/// <returns>A new, empty InlineFilterEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new InlineFilterEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInlineFilter
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new InlineFilterEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new InlineFilterEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInlineFilterUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty InvalidNotificationEntity objects.</summary>
	[Serializable]
	public partial class InvalidNotificationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public InvalidNotificationEntityFactory() : base("InvalidNotificationEntity", Cir.Data.LLBLGen.EntityType.InvalidNotificationEntity) { }

		/// <summary>Creates a new, empty InvalidNotificationEntity object.</summary>
		/// <returns>A new, empty InvalidNotificationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new InvalidNotificationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvalidNotification
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new InvalidNotificationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new InvalidNotificationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewInvalidNotificationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty LocationTypeEntity objects.</summary>
	[Serializable]
	public partial class LocationTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public LocationTypeEntityFactory() : base("LocationTypeEntity", Cir.Data.LLBLGen.EntityType.LocationTypeEntity) { }

		/// <summary>Creates a new, empty LocationTypeEntity object.</summary>
		/// <returns>A new, empty LocationTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new LocationTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocationType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new LocationTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new LocationTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewLocationTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty MagnetPosEntity objects.</summary>
	[Serializable]
	public partial class MagnetPosEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public MagnetPosEntityFactory() : base("MagnetPosEntity", Cir.Data.LLBLGen.EntityType.MagnetPosEntity) { }

		/// <summary>Creates a new, empty MagnetPosEntity object.</summary>
		/// <returns>A new, empty MagnetPosEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new MagnetPosEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMagnetPos
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new MagnetPosEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new MagnetPosEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMagnetPosUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty MainBearingErrorLocationEntity objects.</summary>
	[Serializable]
	public partial class MainBearingErrorLocationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public MainBearingErrorLocationEntityFactory() : base("MainBearingErrorLocationEntity", Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity) { }

		/// <summary>Creates a new, empty MainBearingErrorLocationEntity object.</summary>
		/// <returns>A new, empty MainBearingErrorLocationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new MainBearingErrorLocationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMainBearingErrorLocation
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new MainBearingErrorLocationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new MainBearingErrorLocationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMainBearingErrorLocationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty MainBearingManufacturerEntity objects.</summary>
	[Serializable]
	public partial class MainBearingManufacturerEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public MainBearingManufacturerEntityFactory() : base("MainBearingManufacturerEntity", Cir.Data.LLBLGen.EntityType.MainBearingManufacturerEntity) { }

		/// <summary>Creates a new, empty MainBearingManufacturerEntity object.</summary>
		/// <returns>A new, empty MainBearingManufacturerEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new MainBearingManufacturerEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMainBearingManufacturer
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new MainBearingManufacturerEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new MainBearingManufacturerEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMainBearingManufacturerUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty MapBirCirEntity objects.</summary>
	[Serializable]
	public partial class MapBirCirEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public MapBirCirEntityFactory() : base("MapBirCirEntity", Cir.Data.LLBLGen.EntityType.MapBirCirEntity) { }

		/// <summary>Creates a new, empty MapBirCirEntity object.</summary>
		/// <returns>A new, empty MapBirCirEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new MapBirCirEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMapBirCir
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new MapBirCirEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new MapBirCirEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMapBirCirUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty MechanicalOilPumpEntity objects.</summary>
	[Serializable]
	public partial class MechanicalOilPumpEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public MechanicalOilPumpEntityFactory() : base("MechanicalOilPumpEntity", Cir.Data.LLBLGen.EntityType.MechanicalOilPumpEntity) { }

		/// <summary>Creates a new, empty MechanicalOilPumpEntity object.</summary>
		/// <returns>A new, empty MechanicalOilPumpEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new MechanicalOilPumpEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMechanicalOilPump
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new MechanicalOilPumpEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new MechanicalOilPumpEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewMechanicalOilPumpUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty NoiseEntity objects.</summary>
	[Serializable]
	public partial class NoiseEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public NoiseEntityFactory() : base("NoiseEntity", Cir.Data.LLBLGen.EntityType.NoiseEntity) { }

		/// <summary>Creates a new, empty NoiseEntity object.</summary>
		/// <returns>A new, empty NoiseEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new NoiseEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewNoise
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new NoiseEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new NoiseEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewNoiseUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty OhmUnitEntity objects.</summary>
	[Serializable]
	public partial class OhmUnitEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public OhmUnitEntityFactory() : base("OhmUnitEntity", Cir.Data.LLBLGen.EntityType.OhmUnitEntity) { }

		/// <summary>Creates a new, empty OhmUnitEntity object.</summary>
		/// <returns>A new, empty OhmUnitEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new OhmUnitEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOhmUnit
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new OhmUnitEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new OhmUnitEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOhmUnitUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty OilLevelEntity objects.</summary>
	[Serializable]
	public partial class OilLevelEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public OilLevelEntityFactory() : base("OilLevelEntity", Cir.Data.LLBLGen.EntityType.OilLevelEntity) { }

		/// <summary>Creates a new, empty OilLevelEntity object.</summary>
		/// <returns>A new, empty OilLevelEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new OilLevelEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOilLevel
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new OilLevelEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new OilLevelEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOilLevelUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty OilTypeEntity objects.</summary>
	[Serializable]
	public partial class OilTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public OilTypeEntityFactory() : base("OilTypeEntity", Cir.Data.LLBLGen.EntityType.OilTypeEntity) { }

		/// <summary>Creates a new, empty OilTypeEntity object.</summary>
		/// <returns>A new, empty OilTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new OilTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOilType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new OilTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new OilTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOilTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty OverallGearboxConditionEntity objects.</summary>
	[Serializable]
	public partial class OverallGearboxConditionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public OverallGearboxConditionEntityFactory() : base("OverallGearboxConditionEntity", Cir.Data.LLBLGen.EntityType.OverallGearboxConditionEntity) { }

		/// <summary>Creates a new, empty OverallGearboxConditionEntity object.</summary>
		/// <returns>A new, empty OverallGearboxConditionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new OverallGearboxConditionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOverallGearboxCondition
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new OverallGearboxConditionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new OverallGearboxConditionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewOverallGearboxConditionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty PartNameEntity objects.</summary>
	[Serializable]
	public partial class PartNameEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public PartNameEntityFactory() : base("PartNameEntity", Cir.Data.LLBLGen.EntityType.PartNameEntity) { }

		/// <summary>Creates a new, empty PartNameEntity object.</summary>
		/// <returns>A new, empty PartNameEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new PartNameEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewPartName
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new PartNameEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new PartNameEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewPartNameUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty PdfEntity objects.</summary>
	[Serializable]
	public partial class PdfEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public PdfEntityFactory() : base("PdfEntity", Cir.Data.LLBLGen.EntityType.PdfEntity) { }

		/// <summary>Creates a new, empty PdfEntity object.</summary>
		/// <returns>A new, empty PdfEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new PdfEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewPdf
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new PdfEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new PdfEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewPdfUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ReceiptNotificationEntity objects.</summary>
	[Serializable]
	public partial class ReceiptNotificationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ReceiptNotificationEntityFactory() : base("ReceiptNotificationEntity", Cir.Data.LLBLGen.EntityType.ReceiptNotificationEntity) { }

		/// <summary>Creates a new, empty ReceiptNotificationEntity object.</summary>
		/// <returns>A new, empty ReceiptNotificationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ReceiptNotificationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReceiptNotification
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ReceiptNotificationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ReceiptNotificationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReceiptNotificationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty RejectNotificationEntity objects.</summary>
	[Serializable]
	public partial class RejectNotificationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public RejectNotificationEntityFactory() : base("RejectNotificationEntity", Cir.Data.LLBLGen.EntityType.RejectNotificationEntity) { }

		/// <summary>Creates a new, empty RejectNotificationEntity object.</summary>
		/// <returns>A new, empty RejectNotificationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new RejectNotificationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRejectNotification
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new RejectNotificationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new RejectNotificationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewRejectNotificationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ReportTypeEntity objects.</summary>
	[Serializable]
	public partial class ReportTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ReportTypeEntityFactory() : base("ReportTypeEntity", Cir.Data.LLBLGen.EntityType.ReportTypeEntity) { }

		/// <summary>Creates a new, empty ReportTypeEntity object.</summary>
		/// <returns>A new, empty ReportTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ReportTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReportType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ReportTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ReportTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewReportTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty SbuEntity objects.</summary>
	[Serializable]
	public partial class SbuEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public SbuEntityFactory() : base("SbuEntity", Cir.Data.LLBLGen.EntityType.SbuEntity) { }

		/// <summary>Creates a new, empty SbuEntity object.</summary>
		/// <returns>A new, empty SbuEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new SbuEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSbu
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SbuEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SbuEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSbuUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty SbunotificationEntity objects.</summary>
	[Serializable]
	public partial class SbunotificationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public SbunotificationEntityFactory() : base("SbunotificationEntity", Cir.Data.LLBLGen.EntityType.SbunotificationEntity) { }

		/// <summary>Creates a new, empty SbunotificationEntity object.</summary>
		/// <returns>A new, empty SbunotificationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new SbunotificationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSbunotification
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SbunotificationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SbunotificationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSbunotificationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty SburejectNotificationEntity objects.</summary>
	[Serializable]
	public partial class SburejectNotificationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public SburejectNotificationEntityFactory() : base("SburejectNotificationEntity", Cir.Data.LLBLGen.EntityType.SburejectNotificationEntity) { }

		/// <summary>Creates a new, empty SburejectNotificationEntity object.</summary>
		/// <returns>A new, empty SburejectNotificationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new SburejectNotificationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSburejectNotification
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SburejectNotificationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SburejectNotificationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSburejectNotificationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty SearchProfileEntity objects.</summary>
	[Serializable]
	public partial class SearchProfileEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public SearchProfileEntityFactory() : base("SearchProfileEntity", Cir.Data.LLBLGen.EntityType.SearchProfileEntity) { }

		/// <summary>Creates a new, empty SearchProfileEntity object.</summary>
		/// <returns>A new, empty SearchProfileEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new SearchProfileEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSearchProfile
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SearchProfileEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SearchProfileEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSearchProfileUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty SearchProfileDetailEntity objects.</summary>
	[Serializable]
	public partial class SearchProfileDetailEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public SearchProfileDetailEntityFactory() : base("SearchProfileDetailEntity", Cir.Data.LLBLGen.EntityType.SearchProfileDetailEntity) { }

		/// <summary>Creates a new, empty SearchProfileDetailEntity object.</summary>
		/// <returns>A new, empty SearchProfileDetailEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new SearchProfileDetailEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSearchProfileDetail
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SearchProfileDetailEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SearchProfileDetailEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSearchProfileDetailUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty SecondNotificationEntity objects.</summary>
	[Serializable]
	public partial class SecondNotificationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public SecondNotificationEntityFactory() : base("SecondNotificationEntity", Cir.Data.LLBLGen.EntityType.SecondNotificationEntity) { }

		/// <summary>Creates a new, empty SecondNotificationEntity object.</summary>
		/// <returns>A new, empty SecondNotificationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new SecondNotificationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSecondNotification
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SecondNotificationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SecondNotificationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSecondNotificationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ServiceReportNumberTypeEntity objects.</summary>
	[Serializable]
	public partial class ServiceReportNumberTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ServiceReportNumberTypeEntityFactory() : base("ServiceReportNumberTypeEntity", Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity) { }

		/// <summary>Creates a new, empty ServiceReportNumberTypeEntity object.</summary>
		/// <returns>A new, empty ServiceReportNumberTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ServiceReportNumberTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewServiceReportNumberType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ServiceReportNumberTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ServiceReportNumberTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewServiceReportNumberTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ShaftErrorEntity objects.</summary>
	[Serializable]
	public partial class ShaftErrorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ShaftErrorEntityFactory() : base("ShaftErrorEntity", Cir.Data.LLBLGen.EntityType.ShaftErrorEntity) { }

		/// <summary>Creates a new, empty ShaftErrorEntity object.</summary>
		/// <returns>A new, empty ShaftErrorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ShaftErrorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewShaftError
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ShaftErrorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ShaftErrorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewShaftErrorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ShaftErrorVendorEntity objects.</summary>
	[Serializable]
	public partial class ShaftErrorVendorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ShaftErrorVendorEntityFactory() : base("ShaftErrorVendorEntity", Cir.Data.LLBLGen.EntityType.ShaftErrorVendorEntity) { }

		/// <summary>Creates a new, empty ShaftErrorVendorEntity object.</summary>
		/// <returns>A new, empty ShaftErrorVendorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ShaftErrorVendorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewShaftErrorVendor
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ShaftErrorVendorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ShaftErrorVendorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewShaftErrorVendorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ShaftTypeEntity objects.</summary>
	[Serializable]
	public partial class ShaftTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ShaftTypeEntityFactory() : base("ShaftTypeEntity", Cir.Data.LLBLGen.EntityType.ShaftTypeEntity) { }

		/// <summary>Creates a new, empty ShaftTypeEntity object.</summary>
		/// <returns>A new, empty ShaftTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ShaftTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewShaftType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ShaftTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ShaftTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewShaftTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ShrinkElementEntity objects.</summary>
	[Serializable]
	public partial class ShrinkElementEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ShrinkElementEntityFactory() : base("ShrinkElementEntity", Cir.Data.LLBLGen.EntityType.ShrinkElementEntity) { }

		/// <summary>Creates a new, empty ShrinkElementEntity object.</summary>
		/// <returns>A new, empty ShrinkElementEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ShrinkElementEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewShrinkElement
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ShrinkElementEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ShrinkElementEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewShrinkElementUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty SkiipackFailureCauseEntity objects.</summary>
	[Serializable]
	public partial class SkiipackFailureCauseEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public SkiipackFailureCauseEntityFactory() : base("SkiipackFailureCauseEntity", Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity) { }

		/// <summary>Creates a new, empty SkiipackFailureCauseEntity object.</summary>
		/// <returns>A new, empty SkiipackFailureCauseEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new SkiipackFailureCauseEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSkiipackFailureCause
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SkiipackFailureCauseEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SkiipackFailureCauseEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSkiipackFailureCauseUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty SurgeArrestorEntity objects.</summary>
	[Serializable]
	public partial class SurgeArrestorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public SurgeArrestorEntityFactory() : base("SurgeArrestorEntity", Cir.Data.LLBLGen.EntityType.SurgeArrestorEntity) { }

		/// <summary>Creates a new, empty SurgeArrestorEntity object.</summary>
		/// <returns>A new, empty SurgeArrestorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new SurgeArrestorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSurgeArrestor
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new SurgeArrestorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new SurgeArrestorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewSurgeArrestorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TemplateDynamicTableDefEntity objects.</summary>
	[Serializable]
	public partial class TemplateDynamicTableDefEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TemplateDynamicTableDefEntityFactory() : base("TemplateDynamicTableDefEntity", Cir.Data.LLBLGen.EntityType.TemplateDynamicTableDefEntity) { }

		/// <summary>Creates a new, empty TemplateDynamicTableDefEntity object.</summary>
		/// <returns>A new, empty TemplateDynamicTableDefEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TemplateDynamicTableDefEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTemplateDynamicTableDef
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TemplateDynamicTableDefEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TemplateDynamicTableDefEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTemplateDynamicTableDefUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TemplateInfoEntity objects.</summary>
	[Serializable]
	public partial class TemplateInfoEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TemplateInfoEntityFactory() : base("TemplateInfoEntity", Cir.Data.LLBLGen.EntityType.TemplateInfoEntity) { }

		/// <summary>Creates a new, empty TemplateInfoEntity object.</summary>
		/// <returns>A new, empty TemplateInfoEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TemplateInfoEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTemplateInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TemplateInfoEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TemplateInfoEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTemplateInfoUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty ThreeMwGearboxesEntity objects.</summary>
	[Serializable]
	public partial class ThreeMwGearboxesEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public ThreeMwGearboxesEntityFactory() : base("ThreeMwGearboxesEntity", Cir.Data.LLBLGen.EntityType.ThreeMwGearboxesEntity) { }

		/// <summary>Creates a new, empty ThreeMwGearboxesEntity object.</summary>
		/// <returns>A new, empty ThreeMwGearboxesEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new ThreeMwGearboxesEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewThreeMwGearboxes
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new ThreeMwGearboxesEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new ThreeMwGearboxesEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewThreeMwGearboxesUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TowerHeightEntity objects.</summary>
	[Serializable]
	public partial class TowerHeightEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TowerHeightEntityFactory() : base("TowerHeightEntity", Cir.Data.LLBLGen.EntityType.TowerHeightEntity) { }

		/// <summary>Creates a new, empty TowerHeightEntity object.</summary>
		/// <returns>A new, empty TowerHeightEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TowerHeightEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTowerHeight
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TowerHeightEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TowerHeightEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTowerHeightUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TowerTypeEntity objects.</summary>
	[Serializable]
	public partial class TowerTypeEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TowerTypeEntityFactory() : base("TowerTypeEntity", Cir.Data.LLBLGen.EntityType.TowerTypeEntity) { }

		/// <summary>Creates a new, empty TowerTypeEntity object.</summary>
		/// <returns>A new, empty TowerTypeEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TowerTypeEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTowerType
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TowerTypeEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TowerTypeEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTowerTypeUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TransformerManufacturerEntity objects.</summary>
	[Serializable]
	public partial class TransformerManufacturerEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TransformerManufacturerEntityFactory() : base("TransformerManufacturerEntity", Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity) { }

		/// <summary>Creates a new, empty TransformerManufacturerEntity object.</summary>
		/// <returns>A new, empty TransformerManufacturerEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TransformerManufacturerEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTransformerManufacturer
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TransformerManufacturerEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TransformerManufacturerEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTransformerManufacturerUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineEntity objects.</summary>
	[Serializable]
	public partial class TurbineEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineEntityFactory() : base("TurbineEntity", Cir.Data.LLBLGen.EntityType.TurbineEntity) { }

		/// <summary>Creates a new, empty TurbineEntity object.</summary>
		/// <returns>A new, empty TurbineEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbine
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineDataEntity objects.</summary>
	[Serializable]
	public partial class TurbineDataEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineDataEntityFactory() : base("TurbineDataEntity", Cir.Data.LLBLGen.EntityType.TurbineDataEntity) { }

		/// <summary>Creates a new, empty TurbineDataEntity object.</summary>
		/// <returns>A new, empty TurbineDataEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineDataEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineData
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineDataEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineDataEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineDataUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineFrequencyEntity objects.</summary>
	[Serializable]
	public partial class TurbineFrequencyEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineFrequencyEntityFactory() : base("TurbineFrequencyEntity", Cir.Data.LLBLGen.EntityType.TurbineFrequencyEntity) { }

		/// <summary>Creates a new, empty TurbineFrequencyEntity object.</summary>
		/// <returns>A new, empty TurbineFrequencyEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineFrequencyEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineFrequency
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineFrequencyEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineFrequencyEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineFrequencyUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineManufacturerEntity objects.</summary>
	[Serializable]
	public partial class TurbineManufacturerEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineManufacturerEntityFactory() : base("TurbineManufacturerEntity", Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity) { }

		/// <summary>Creates a new, empty TurbineManufacturerEntity object.</summary>
		/// <returns>A new, empty TurbineManufacturerEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineManufacturerEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineManufacturer
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineManufacturerEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineManufacturerEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineManufacturerUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineMarkVersionEntity objects.</summary>
	[Serializable]
	public partial class TurbineMarkVersionEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineMarkVersionEntityFactory() : base("TurbineMarkVersionEntity", Cir.Data.LLBLGen.EntityType.TurbineMarkVersionEntity) { }

		/// <summary>Creates a new, empty TurbineMarkVersionEntity object.</summary>
		/// <returns>A new, empty TurbineMarkVersionEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineMarkVersionEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineMarkVersion
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineMarkVersionEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineMarkVersionEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineMarkVersionUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineMatrixEntity objects.</summary>
	[Serializable]
	public partial class TurbineMatrixEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineMatrixEntityFactory() : base("TurbineMatrixEntity", Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity) { }

		/// <summary>Creates a new, empty TurbineMatrixEntity object.</summary>
		/// <returns>A new, empty TurbineMatrixEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineMatrixEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineMatrix
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineMatrixEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineMatrixEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineMatrixUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineNominelPowerEntity objects.</summary>
	[Serializable]
	public partial class TurbineNominelPowerEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineNominelPowerEntityFactory() : base("TurbineNominelPowerEntity", Cir.Data.LLBLGen.EntityType.TurbineNominelPowerEntity) { }

		/// <summary>Creates a new, empty TurbineNominelPowerEntity object.</summary>
		/// <returns>A new, empty TurbineNominelPowerEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineNominelPowerEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineNominelPower
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineNominelPowerEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineNominelPowerEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineNominelPowerUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineOldEntity objects.</summary>
	[Serializable]
	public partial class TurbineOldEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineOldEntityFactory() : base("TurbineOldEntity", Cir.Data.LLBLGen.EntityType.TurbineOldEntity) { }

		/// <summary>Creates a new, empty TurbineOldEntity object.</summary>
		/// <returns>A new, empty TurbineOldEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineOldEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineOld
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineOldEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineOldEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineOldUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbinePlacementEntity objects.</summary>
	[Serializable]
	public partial class TurbinePlacementEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbinePlacementEntityFactory() : base("TurbinePlacementEntity", Cir.Data.LLBLGen.EntityType.TurbinePlacementEntity) { }

		/// <summary>Creates a new, empty TurbinePlacementEntity object.</summary>
		/// <returns>A new, empty TurbinePlacementEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbinePlacementEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbinePlacement
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbinePlacementEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbinePlacementEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbinePlacementUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbinePowerRegulationEntity objects.</summary>
	[Serializable]
	public partial class TurbinePowerRegulationEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbinePowerRegulationEntityFactory() : base("TurbinePowerRegulationEntity", Cir.Data.LLBLGen.EntityType.TurbinePowerRegulationEntity) { }

		/// <summary>Creates a new, empty TurbinePowerRegulationEntity object.</summary>
		/// <returns>A new, empty TurbinePowerRegulationEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbinePowerRegulationEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbinePowerRegulation
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbinePowerRegulationEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbinePowerRegulationEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbinePowerRegulationUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineRotorDiameterEntity objects.</summary>
	[Serializable]
	public partial class TurbineRotorDiameterEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineRotorDiameterEntityFactory() : base("TurbineRotorDiameterEntity", Cir.Data.LLBLGen.EntityType.TurbineRotorDiameterEntity) { }

		/// <summary>Creates a new, empty TurbineRotorDiameterEntity object.</summary>
		/// <returns>A new, empty TurbineRotorDiameterEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineRotorDiameterEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineRotorDiameter
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineRotorDiameterEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineRotorDiameterEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineRotorDiameterUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineRunStatusEntity objects.</summary>
	[Serializable]
	public partial class TurbineRunStatusEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineRunStatusEntityFactory() : base("TurbineRunStatusEntity", Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity) { }

		/// <summary>Creates a new, empty TurbineRunStatusEntity object.</summary>
		/// <returns>A new, empty TurbineRunStatusEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineRunStatusEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineRunStatus
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineRunStatusEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineRunStatusEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineRunStatusUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineSmallGeneratorEntity objects.</summary>
	[Serializable]
	public partial class TurbineSmallGeneratorEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineSmallGeneratorEntityFactory() : base("TurbineSmallGeneratorEntity", Cir.Data.LLBLGen.EntityType.TurbineSmallGeneratorEntity) { }

		/// <summary>Creates a new, empty TurbineSmallGeneratorEntity object.</summary>
		/// <returns>A new, empty TurbineSmallGeneratorEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineSmallGeneratorEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineSmallGenerator
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineSmallGeneratorEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineSmallGeneratorEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineSmallGeneratorUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineTemperatureVariantEntity objects.</summary>
	[Serializable]
	public partial class TurbineTemperatureVariantEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineTemperatureVariantEntityFactory() : base("TurbineTemperatureVariantEntity", Cir.Data.LLBLGen.EntityType.TurbineTemperatureVariantEntity) { }

		/// <summary>Creates a new, empty TurbineTemperatureVariantEntity object.</summary>
		/// <returns>A new, empty TurbineTemperatureVariantEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineTemperatureVariantEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineTemperatureVariant
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineTemperatureVariantEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineTemperatureVariantEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineTemperatureVariantUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty TurbineVoltageEntity objects.</summary>
	[Serializable]
	public partial class TurbineVoltageEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public TurbineVoltageEntityFactory() : base("TurbineVoltageEntity", Cir.Data.LLBLGen.EntityType.TurbineVoltageEntity) { }

		/// <summary>Creates a new, empty TurbineVoltageEntity object.</summary>
		/// <returns>A new, empty TurbineVoltageEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new TurbineVoltageEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineVoltage
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new TurbineVoltageEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new TurbineVoltageEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewTurbineVoltageUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}	
	/// <summary>Factory to create new, empty VibrationsEntity objects.</summary>
	[Serializable]
	public partial class VibrationsEntityFactory : EntityFactoryBase2 {
		/// <summary>CTor</summary>
		public VibrationsEntityFactory() : base("VibrationsEntity", Cir.Data.LLBLGen.EntityType.VibrationsEntity) { }

		/// <summary>Creates a new, empty VibrationsEntity object.</summary>
		/// <returns>A new, empty VibrationsEntity object.</returns>
		public override IEntity2 Create() {
			IEntity2 toReturn = new VibrationsEntity();
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewVibrations
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}
		
		/// <summary>Creates a new VibrationsEntity instance but uses a special constructor which will set the Fields object of the new IEntity2 instance to the passed in fields object.</summary>
		/// <param name="fields">Populated IEntityFields2 object for the new IEntity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		public override IEntity2 Create(IEntityFields2 fields) {
			IEntity2 toReturn = new VibrationsEntity(fields);
			
			// __LLBLGENPRO_USER_CODE_REGION_START CreateNewVibrationsUsingFields
			// __LLBLGENPRO_USER_CODE_REGION_END
			return toReturn;
		}

		#region Included Code

		#endregion
	}

	/// <summary>Factory to create new, empty Entity objects based on the entity type specified. Uses  entity specific factory objects</summary>
	[Serializable]
	public partial class GeneralEntityFactory
	{
		/// <summary>Creates a new, empty Entity object of the type specified</summary>
		/// <param name="entityTypeToCreate">The entity type to create.</param>
		/// <returns>A new, empty Entity object.</returns>
		public static IEntity2 Create(EntityType entityTypeToCreate)
		{
			IEntityFactory2 factoryToUse = null;
			switch(entityTypeToCreate)
			{
				case Cir.Data.LLBLGen.EntityType.ActionOnTransformerEntity:
					factoryToUse = new ActionOnTransformerEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity:
					factoryToUse = new ActionToBeTakenOnGeneratorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ArcDetectionEntity:
					factoryToUse = new ArcDetectionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BearingDamageCategoryEntity:
					factoryToUse = new BearingDamageCategoryEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BearingErrorEntity:
					factoryToUse = new BearingErrorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BearingErrorVendorEntity:
					factoryToUse = new BearingErrorVendorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BearingPosEntity:
					factoryToUse = new BearingPosEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BearingTypeEntity:
					factoryToUse = new BearingTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BirDataEntity:
					factoryToUse = new BirDataEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BirReportPlaceholdersEntity:
					factoryToUse = new BirReportPlaceholdersEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BirWordDocumentEntity:
					factoryToUse = new BirWordDocumentEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BladeColorEntity:
					factoryToUse = new BladeColorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity:
					factoryToUse = new BladeDamagePlacementEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BladeEdgeEntity:
					factoryToUse = new BladeEdgeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BladeInspectionDataEntity:
					factoryToUse = new BladeInspectionDataEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BladeLengthEntity:
					factoryToUse = new BladeLengthEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BladeManufacturerEntity:
					factoryToUse = new BladeManufacturerEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity:
					factoryToUse = new BooleanAnswerEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.BracketsEntity:
					factoryToUse = new BracketsEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CableConditionEntity:
					factoryToUse = new CableConditionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CimCaseFailureItemsEntity:
					factoryToUse = new CimCaseFailureItemsEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirAttachmentEntity:
					factoryToUse = new CirAttachmentEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirCommentHistoryEntity:
					factoryToUse = new CirCommentHistoryEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirDataEntity:
					factoryToUse = new CirDataEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirinboxTimestampEntity:
					factoryToUse = new CirinboxTimestampEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirInvalidEntity:
					factoryToUse = new CirInvalidEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirLogEntity:
					factoryToUse = new CirLogEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirMailArchiveEntity:
					factoryToUse = new CirMailArchiveEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirMetadataEntity:
					factoryToUse = new CirMetadataEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirMetadataLookupEntity:
					factoryToUse = new CirMetadataLookupEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirStandardTextsEntity:
					factoryToUse = new CirStandardTextsEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirSystemLogEntity:
					factoryToUse = new CirSystemLogEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirSystemMonitorEntity:
					factoryToUse = new CirSystemMonitorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirUserEntity:
					factoryToUse = new CirUserEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirViewEntity:
					factoryToUse = new CirViewEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CirXmlEntity:
					factoryToUse = new CirXmlEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ClimateEntity:
					factoryToUse = new ClimateEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CoilConditionEntity:
					factoryToUse = new CoilConditionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentGroupEntity:
					factoryToUse = new ComponentGroupEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity:
					factoryToUse = new ComponentInspectionReportEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity:
					factoryToUse = new ComponentInspectionReportBladeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeDamageEntity:
					factoryToUse = new ComponentInspectionReportBladeDamageEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeRepairRecordEntity:
					factoryToUse = new ComponentInspectionReportBladeRepairRecordEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity:
					factoryToUse = new ComponentInspectionReportGearboxEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneralEntity:
					factoryToUse = new ComponentInspectionReportGeneralEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity:
					factoryToUse = new ComponentInspectionReportGeneratorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportMainBearingEntity:
					factoryToUse = new ComponentInspectionReportMainBearingEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity:
					factoryToUse = new ComponentInspectionReportSkiiPEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPfailedComponentEntity:
					factoryToUse = new ComponentInspectionReportSkiiPfailedComponentEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPnewComponentEntity:
					factoryToUse = new ComponentInspectionReportSkiiPnewComponentEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportStateEntity:
					factoryToUse = new ComponentInspectionReportStateEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTransformerEntity:
					factoryToUse = new ComponentInspectionReportTransformerEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentInspectionReportTypeEntity:
					factoryToUse = new ComponentInspectionReportTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ComponentUpTowerSolutionEntity:
					factoryToUse = new ComponentUpTowerSolutionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ConnectionBarsEntity:
					factoryToUse = new ConnectionBarsEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ControllerTypeEntity:
					factoryToUse = new ControllerTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CountryIsoEntity:
					factoryToUse = new CountryIsoEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.CouplingEntity:
					factoryToUse = new CouplingEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.DamageEntity:
					factoryToUse = new DamageEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.DamageDecisionEntity:
					factoryToUse = new DamageDecisionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.DebrisGearboxEntity:
					factoryToUse = new DebrisGearboxEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.DebrisOnMagnetEntity:
					factoryToUse = new DebrisOnMagnetEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.DynamicTableInputEntity:
					factoryToUse = new DynamicTableInputEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.EditHistoryEntity:
					factoryToUse = new EditHistoryEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ElectricalPumpEntity:
					factoryToUse = new ElectricalPumpEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.FaultCodeAreaEntity:
					factoryToUse = new FaultCodeAreaEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.FaultCodeCauseEntity:
					factoryToUse = new FaultCodeCauseEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.FaultCodeClassificationEntity:
					factoryToUse = new FaultCodeClassificationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.FaultCodeTypeEntity:
					factoryToUse = new FaultCodeTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.FilterBlockTypeEntity:
					factoryToUse = new FilterBlockTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.FirstNotificationEntity:
					factoryToUse = new FirstNotificationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationEntity:
					factoryToUse = new GearboxDefectCategorizationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxDefectCategorizationDetailsEntity:
					factoryToUse = new GearboxDefectCategorizationDetailsEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxManufacturerEntity:
					factoryToUse = new GearboxManufacturerEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxPartTypeEntity:
					factoryToUse = new GearboxPartTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxRevisionEntity:
					factoryToUse = new GearboxRevisionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GearboxTypeEntity:
					factoryToUse = new GearboxTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GearDamageCategoryEntity:
					factoryToUse = new GearDamageCategoryEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GearErrorEntity:
					factoryToUse = new GearErrorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GearErrorVendorEntity:
					factoryToUse = new GearErrorVendorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GearTypeEntity:
					factoryToUse = new GearTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GenerateCiridEntity:
					factoryToUse = new GenerateCiridEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorBearingDecisionEntity:
					factoryToUse = new GeneratorBearingDecisionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorComponentDamageEntity:
					factoryToUse = new GeneratorComponentDamageEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity:
					factoryToUse = new GeneratorCoverEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorizationEntity:
					factoryToUse = new GeneratorDefectCategorizationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2Entity:
					factoryToUse = new GeneratorDefectCategorization2EntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorDefectCategorization2DetailsEntity:
					factoryToUse = new GeneratorDefectCategorization2DetailsEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity:
					factoryToUse = new GeneratorDriveEndEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity:
					factoryToUse = new GeneratorManufacturerEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorMiscDecisionEntity:
					factoryToUse = new GeneratorMiscDecisionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity:
					factoryToUse = new GeneratorNonDriveEndEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorPhaseOutletDecisionEntity:
					factoryToUse = new GeneratorPhaseOutletDecisionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity:
					factoryToUse = new GeneratorRotorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorRotorDecisionEntity:
					factoryToUse = new GeneratorRotorDecisionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorRotorLeadsDecisionEntity:
					factoryToUse = new GeneratorRotorLeadsDecisionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.GeneratorStatorDecisionEntity:
					factoryToUse = new GeneratorStatorDecisionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.HotItemEntity:
					factoryToUse = new HotItemEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.HotItemAdministratorEntity:
					factoryToUse = new HotItemAdministratorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.HousingErrorEntity:
					factoryToUse = new HousingErrorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.HousingErrorVendorEntity:
					factoryToUse = new HousingErrorVendorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.InlineFilterEntity:
					factoryToUse = new InlineFilterEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.InvalidNotificationEntity:
					factoryToUse = new InvalidNotificationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.LocationTypeEntity:
					factoryToUse = new LocationTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.MagnetPosEntity:
					factoryToUse = new MagnetPosEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.MainBearingErrorLocationEntity:
					factoryToUse = new MainBearingErrorLocationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.MainBearingManufacturerEntity:
					factoryToUse = new MainBearingManufacturerEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.MapBirCirEntity:
					factoryToUse = new MapBirCirEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.MechanicalOilPumpEntity:
					factoryToUse = new MechanicalOilPumpEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.NoiseEntity:
					factoryToUse = new NoiseEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.OhmUnitEntity:
					factoryToUse = new OhmUnitEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.OilLevelEntity:
					factoryToUse = new OilLevelEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.OilTypeEntity:
					factoryToUse = new OilTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.OverallGearboxConditionEntity:
					factoryToUse = new OverallGearboxConditionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.PartNameEntity:
					factoryToUse = new PartNameEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.PdfEntity:
					factoryToUse = new PdfEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ReceiptNotificationEntity:
					factoryToUse = new ReceiptNotificationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.RejectNotificationEntity:
					factoryToUse = new RejectNotificationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ReportTypeEntity:
					factoryToUse = new ReportTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.SbuEntity:
					factoryToUse = new SbuEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.SbunotificationEntity:
					factoryToUse = new SbunotificationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.SburejectNotificationEntity:
					factoryToUse = new SburejectNotificationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.SearchProfileEntity:
					factoryToUse = new SearchProfileEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.SearchProfileDetailEntity:
					factoryToUse = new SearchProfileDetailEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.SecondNotificationEntity:
					factoryToUse = new SecondNotificationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ServiceReportNumberTypeEntity:
					factoryToUse = new ServiceReportNumberTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ShaftErrorEntity:
					factoryToUse = new ShaftErrorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ShaftErrorVendorEntity:
					factoryToUse = new ShaftErrorVendorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ShaftTypeEntity:
					factoryToUse = new ShaftTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ShrinkElementEntity:
					factoryToUse = new ShrinkElementEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity:
					factoryToUse = new SkiipackFailureCauseEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.SurgeArrestorEntity:
					factoryToUse = new SurgeArrestorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TemplateDynamicTableDefEntity:
					factoryToUse = new TemplateDynamicTableDefEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TemplateInfoEntity:
					factoryToUse = new TemplateInfoEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.ThreeMwGearboxesEntity:
					factoryToUse = new ThreeMwGearboxesEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TowerHeightEntity:
					factoryToUse = new TowerHeightEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TowerTypeEntity:
					factoryToUse = new TowerTypeEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TransformerManufacturerEntity:
					factoryToUse = new TransformerManufacturerEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineEntity:
					factoryToUse = new TurbineEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineDataEntity:
					factoryToUse = new TurbineDataEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineFrequencyEntity:
					factoryToUse = new TurbineFrequencyEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity:
					factoryToUse = new TurbineManufacturerEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineMarkVersionEntity:
					factoryToUse = new TurbineMarkVersionEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity:
					factoryToUse = new TurbineMatrixEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineNominelPowerEntity:
					factoryToUse = new TurbineNominelPowerEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineOldEntity:
					factoryToUse = new TurbineOldEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbinePlacementEntity:
					factoryToUse = new TurbinePlacementEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbinePowerRegulationEntity:
					factoryToUse = new TurbinePowerRegulationEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineRotorDiameterEntity:
					factoryToUse = new TurbineRotorDiameterEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineRunStatusEntity:
					factoryToUse = new TurbineRunStatusEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineSmallGeneratorEntity:
					factoryToUse = new TurbineSmallGeneratorEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineTemperatureVariantEntity:
					factoryToUse = new TurbineTemperatureVariantEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.TurbineVoltageEntity:
					factoryToUse = new TurbineVoltageEntityFactory();
					break;
				case Cir.Data.LLBLGen.EntityType.VibrationsEntity:
					factoryToUse = new VibrationsEntityFactory();
					break;
			}
			IEntity2 toReturn = null;
			if(factoryToUse != null)
			{
				toReturn = factoryToUse.Create();
			}
			return toReturn;
		}		
	}
}
