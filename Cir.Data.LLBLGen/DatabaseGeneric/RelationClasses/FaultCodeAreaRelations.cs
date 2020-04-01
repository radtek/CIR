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
	/// <summary>Implements the static Relations variant for the entity: FaultCodeArea. </summary>
	public partial class FaultCodeAreaRelations
	{
		/// <summary>CTor</summary>
		public FaultCodeAreaRelations()
		{
		}

		/// <summary>Gets all relations of the FaultCodeAreaEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportBladeEntityUsingBladeFaultCodeAreaId);
			toReturn.Add(this.FaultCodeAreaEntityUsingParentFaultCodeAreaId);

			toReturn.Add(this.FaultCodeAreaEntityUsingFaultCodeAreaIdParentFaultCodeAreaId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between FaultCodeAreaEntity and ComponentInspectionReportBladeEntity over the 1:n relation they have, using the relation between the fields:
		/// FaultCodeArea.FaultCodeAreaId - ComponentInspectionReportBlade.BladeFaultCodeAreaId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeEntityUsingBladeFaultCodeAreaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBlade" , true);
				relation.AddEntityFieldPair(FaultCodeAreaFields.FaultCodeAreaId, ComponentInspectionReportBladeFields.BladeFaultCodeAreaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeAreaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FaultCodeAreaEntity and FaultCodeAreaEntity over the 1:n relation they have, using the relation between the fields:
		/// FaultCodeArea.FaultCodeAreaId - FaultCodeArea.ParentFaultCodeAreaId
		/// </summary>
		public virtual IEntityRelation FaultCodeAreaEntityUsingParentFaultCodeAreaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FaultCodeArea_" , true);
				relation.AddEntityFieldPair(FaultCodeAreaFields.FaultCodeAreaId, FaultCodeAreaFields.ParentFaultCodeAreaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeAreaEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeAreaEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between FaultCodeAreaEntity and FaultCodeAreaEntity over the m:1 relation they have, using the relation between the fields:
		/// FaultCodeArea.ParentFaultCodeAreaId - FaultCodeArea.FaultCodeAreaId
		/// </summary>
		public virtual IEntityRelation FaultCodeAreaEntityUsingFaultCodeAreaIdParentFaultCodeAreaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FaultCodeArea", false);
				relation.AddEntityFieldPair(FaultCodeAreaFields.FaultCodeAreaId, FaultCodeAreaFields.ParentFaultCodeAreaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeAreaEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeAreaEntity", true);
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
