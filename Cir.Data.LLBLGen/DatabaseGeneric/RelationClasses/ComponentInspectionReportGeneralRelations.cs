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
using System.Collections;
using System.Collections.Generic;
using Cir.Data.LLBLGen;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data.LLBLGen.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: ComponentInspectionReportGeneral. </summary>
	public partial class ComponentInspectionReportGeneralRelations
	{
		/// <summary>CTor</summary>
		public ComponentInspectionReportGeneralRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentInspectionReportGeneralEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.BooleanAnswerEntityUsingGeneralPicturesIncludedBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingGeneralClaimRelevantBooleanAnswerId);
			toReturn.Add(this.ComponentGroupEntityUsingGeneralComponentGroupId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingComponentInspectionReportId);
			toReturn.Add(this.ControllerTypeEntityUsingGeneralControllerTypeId);
			toReturn.Add(this.GearboxManufacturerEntityUsingGeneralGearboxManufacturerId);
			toReturn.Add(this.GeneratorManufacturerEntityUsingGeneralGeneratorManufacturerId);
			toReturn.Add(this.TowerHeightEntityUsingGeneralTowerHeightId);
			toReturn.Add(this.TowerTypeEntityUsingGeneralTowerTypeId);
			toReturn.Add(this.TransformerManufacturerEntityUsingGeneralTransformerManufacturerId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneralEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGeneral.GeneralPicturesIncludedBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingGeneralPicturesIncludedBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer_", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportGeneralFields.GeneralPicturesIncludedBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneralEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGeneral.GeneralClaimRelevantBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingGeneralClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportGeneralFields.GeneralClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneralEntity and ComponentGroupEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGeneral.GeneralComponentGroupId - ComponentGroup.ComponentGroupId
		/// </summary>
		public virtual IEntityRelation ComponentGroupEntityUsingGeneralComponentGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentGroup", false);
				relation.AddEntityFieldPair(ComponentGroupFields.ComponentGroupId, ComponentInspectionReportGeneralFields.GeneralComponentGroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneralEntity and ComponentInspectionReportEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGeneral.ComponentInspectionReportId - ComponentInspectionReport.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReport", false);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportGeneralFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneralEntity and ControllerTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGeneral.GeneralControllerTypeId - ControllerType.ControllerTypeId
		/// </summary>
		public virtual IEntityRelation ControllerTypeEntityUsingGeneralControllerTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ControllerType", false);
				relation.AddEntityFieldPair(ControllerTypeFields.ControllerTypeId, ComponentInspectionReportGeneralFields.GeneralControllerTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ControllerTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneralEntity and GearboxManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGeneral.GeneralGearboxManufacturerId - GearboxManufacturer.GearboxManufacturerId
		/// </summary>
		public virtual IEntityRelation GearboxManufacturerEntityUsingGeneralGearboxManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearboxManufacturer", false);
				relation.AddEntityFieldPair(GearboxManufacturerFields.GearboxManufacturerId, ComponentInspectionReportGeneralFields.GeneralGearboxManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneralEntity and GeneratorManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGeneral.GeneralGeneratorManufacturerId - GeneratorManufacturer.GeneratorManufacturerId
		/// </summary>
		public virtual IEntityRelation GeneratorManufacturerEntityUsingGeneralGeneratorManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorManufacturer", false);
				relation.AddEntityFieldPair(GeneratorManufacturerFields.GeneratorManufacturerId, ComponentInspectionReportGeneralFields.GeneralGeneratorManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneralEntity and TowerHeightEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGeneral.GeneralTowerHeightId - TowerHeight.TowerHeightId
		/// </summary>
		public virtual IEntityRelation TowerHeightEntityUsingGeneralTowerHeightId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TowerHeight", false);
				relation.AddEntityFieldPair(TowerHeightFields.TowerHeightId, ComponentInspectionReportGeneralFields.GeneralTowerHeightId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerHeightEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneralEntity and TowerTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGeneral.GeneralTowerTypeId - TowerType.TowerTypeId
		/// </summary>
		public virtual IEntityRelation TowerTypeEntityUsingGeneralTowerTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TowerType", false);
				relation.AddEntityFieldPair(TowerTypeFields.TowerTypeId, ComponentInspectionReportGeneralFields.GeneralTowerTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneralEntity and TransformerManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGeneral.GeneralTransformerManufacturerId - TransformerManufacturer.TransformerManufacturerId
		/// </summary>
		public virtual IEntityRelation TransformerManufacturerEntityUsingGeneralTransformerManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TransformerManufacturer", false);
				relation.AddEntityFieldPair(TransformerManufacturerFields.TransformerManufacturerId, ComponentInspectionReportGeneralFields.GeneralTransformerManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TransformerManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", true);
				return relation;
			}
		}

		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}
