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
	/// <summary>Implements the static Relations variant for the entity: Coupling. </summary>
	public partial class CouplingRelations
	{
		/// <summary>CTor</summary>
		public CouplingRelations()
		{
		}

		/// <summary>Gets all relations of the CouplingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxCouplingId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingCouplingId);
			toReturn.Add(this.CouplingEntityUsingParentCouplingId);

			toReturn.Add(this.CouplingEntityUsingCouplingIdParentCouplingId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CouplingEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// Coupling.CouplingId - ComponentInspectionReportGearbox.GearboxCouplingId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxCouplingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(CouplingFields.CouplingId, ComponentInspectionReportGearboxFields.GearboxCouplingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouplingEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CouplingEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// Coupling.CouplingId - ComponentInspectionReportGenerator.CouplingId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingCouplingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator" , true);
				relation.AddEntityFieldPair(CouplingFields.CouplingId, ComponentInspectionReportGeneratorFields.CouplingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouplingEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CouplingEntity and CouplingEntity over the 1:n relation they have, using the relation between the fields:
		/// Coupling.CouplingId - Coupling.ParentCouplingId
		/// </summary>
		public virtual IEntityRelation CouplingEntityUsingParentCouplingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Coupling_" , true);
				relation.AddEntityFieldPair(CouplingFields.CouplingId, CouplingFields.ParentCouplingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouplingEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouplingEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CouplingEntity and CouplingEntity over the m:1 relation they have, using the relation between the fields:
		/// Coupling.ParentCouplingId - Coupling.CouplingId
		/// </summary>
		public virtual IEntityRelation CouplingEntityUsingCouplingIdParentCouplingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Coupling", false);
				relation.AddEntityFieldPair(CouplingFields.CouplingId, CouplingFields.ParentCouplingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouplingEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouplingEntity", true);
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
