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
	/// <summary>Implements the static Relations variant for the entity: ComponentInspectionReportGenerator. </summary>
	public partial class ComponentInspectionReportGeneratorRelations
	{
		/// <summary>CTor</summary>
		public ComponentInspectionReportGeneratorRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentInspectionReportGeneratorEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId);

			toReturn.Add(this.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId);
			toReturn.Add(this.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingComponentInspectionReportId);
			toReturn.Add(this.CouplingEntityUsingCouplingId);
			toReturn.Add(this.GeneratorCoverEntityUsingGeneratorCoverId);
			toReturn.Add(this.GeneratorDriveEndEntityUsingGeneratorDriveEndId);
			toReturn.Add(this.GeneratorManufacturerEntityUsingGeneratorManufacturerId);
			toReturn.Add(this.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId);
			toReturn.Add(this.GeneratorRotorEntityUsingGeneratorRotorId);
			toReturn.Add(this.OhmUnitEntityUsingKgroundOhmUnitId);
			toReturn.Add(this.OhmUnitEntityUsingVwohmUnitId);
			toReturn.Add(this.OhmUnitEntityUsingMgroundOhmUnitId);
			toReturn.Add(this.OhmUnitEntityUsingLgroundOhmUnitId);
			toReturn.Add(this.OhmUnitEntityUsingUwohmUnitId);
			toReturn.Add(this.OhmUnitEntityUsingVgroundOhmUnitId);
			toReturn.Add(this.OhmUnitEntityUsingUgroundOhmUnitId);
			toReturn.Add(this.OhmUnitEntityUsingUvohmUnitId);
			toReturn.Add(this.OhmUnitEntityUsingWgroundOhmUnitId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and GeneratorDefectCategorizationEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.ComponentInspectionReportGeneratorId - GeneratorDefectCategorization.ComponentInspectionReportGeneratorId
		/// </summary>
		public virtual IEntityRelation GeneratorDefectCategorizationEntityUsingComponentInspectionReportGeneratorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GeneratorDefectCategorization" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportGeneratorFields.ComponentInspectionReportGeneratorId, GeneratorDefectCategorizationFields.ComponentInspectionReportGeneratorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and ActionToBeTakenOnGeneratorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.ActionToBeTakenOnGeneratorId - ActionToBeTakenOnGenerator.ActionToBeTakenOnGeneratorId
		/// </summary>
		public virtual IEntityRelation ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ActionToBeTakenOnGenerator", false);
				relation.AddEntityFieldPair(ActionToBeTakenOnGeneratorFields.ActionToBeTakenOnGeneratorId, ComponentInspectionReportGeneratorFields.ActionToBeTakenOnGeneratorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionToBeTakenOnGeneratorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.GeneratorClaimRelevantBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportGeneratorFields.GeneratorClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and ComponentInspectionReportEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.ComponentInspectionReportId - ComponentInspectionReport.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReport", false);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportGeneratorFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and CouplingEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.CouplingId - Coupling.CouplingId
		/// </summary>
		public virtual IEntityRelation CouplingEntityUsingCouplingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Coupling", false);
				relation.AddEntityFieldPair(CouplingFields.CouplingId, ComponentInspectionReportGeneratorFields.CouplingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouplingEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and GeneratorCoverEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.GeneratorCoverId - GeneratorCover.GeneratorCoverId
		/// </summary>
		public virtual IEntityRelation GeneratorCoverEntityUsingGeneratorCoverId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorCover", false);
				relation.AddEntityFieldPair(GeneratorCoverFields.GeneratorCoverId, ComponentInspectionReportGeneratorFields.GeneratorCoverId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorCoverEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and GeneratorDriveEndEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.GeneratorDriveEndId - GeneratorDriveEnd.GeneratorDriveEndId
		/// </summary>
		public virtual IEntityRelation GeneratorDriveEndEntityUsingGeneratorDriveEndId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorDriveEnd", false);
				relation.AddEntityFieldPair(GeneratorDriveEndFields.GeneratorDriveEndId, ComponentInspectionReportGeneratorFields.GeneratorDriveEndId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDriveEndEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and GeneratorManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.GeneratorManufacturerId - GeneratorManufacturer.GeneratorManufacturerId
		/// </summary>
		public virtual IEntityRelation GeneratorManufacturerEntityUsingGeneratorManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorManufacturer", false);
				relation.AddEntityFieldPair(GeneratorManufacturerFields.GeneratorManufacturerId, ComponentInspectionReportGeneratorFields.GeneratorManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and GeneratorNonDriveEndEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.GeneratorNonDriveEndId - GeneratorNonDriveEnd.GeneratorNonDriveEndId
		/// </summary>
		public virtual IEntityRelation GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorNonDriveEnd", false);
				relation.AddEntityFieldPair(GeneratorNonDriveEndFields.GeneratorNonDriveEndId, ComponentInspectionReportGeneratorFields.GeneratorNonDriveEndId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorNonDriveEndEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and GeneratorRotorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.GeneratorRotorId - GeneratorRotor.GeneratorRotorId
		/// </summary>
		public virtual IEntityRelation GeneratorRotorEntityUsingGeneratorRotorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorRotor", false);
				relation.AddEntityFieldPair(GeneratorRotorFields.GeneratorRotorId, ComponentInspectionReportGeneratorFields.GeneratorRotorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorRotorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and OhmUnitEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.KgroundOhmUnitId - OhmUnit.OhmUnitId
		/// </summary>
		public virtual IEntityRelation OhmUnitEntityUsingKgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OhmUnit______", false);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.KgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and OhmUnitEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.VwohmUnitId - OhmUnit.OhmUnitId
		/// </summary>
		public virtual IEntityRelation OhmUnitEntityUsingVwohmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OhmUnit_____", false);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.VwohmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and OhmUnitEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.MgroundOhmUnitId - OhmUnit.OhmUnitId
		/// </summary>
		public virtual IEntityRelation OhmUnitEntityUsingMgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OhmUnit________", false);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.MgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and OhmUnitEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.LgroundOhmUnitId - OhmUnit.OhmUnitId
		/// </summary>
		public virtual IEntityRelation OhmUnitEntityUsingLgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OhmUnit_______", false);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.LgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and OhmUnitEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.UwohmUnitId - OhmUnit.OhmUnitId
		/// </summary>
		public virtual IEntityRelation OhmUnitEntityUsingUwohmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OhmUnit____", false);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.UwohmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and OhmUnitEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.VgroundOhmUnitId - OhmUnit.OhmUnitId
		/// </summary>
		public virtual IEntityRelation OhmUnitEntityUsingVgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OhmUnit_", false);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.VgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and OhmUnitEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.UgroundOhmUnitId - OhmUnit.OhmUnitId
		/// </summary>
		public virtual IEntityRelation OhmUnitEntityUsingUgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OhmUnit", false);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.UgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and OhmUnitEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.UvohmUnitId - OhmUnit.OhmUnitId
		/// </summary>
		public virtual IEntityRelation OhmUnitEntityUsingUvohmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OhmUnit___", false);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.UvohmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGeneratorEntity and OhmUnitEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGenerator.WgroundOhmUnitId - OhmUnit.OhmUnitId
		/// </summary>
		public virtual IEntityRelation OhmUnitEntityUsingWgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OhmUnit__", false);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.WgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", true);
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
