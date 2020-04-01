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
	/// <summary>Implements the static Relations variant for the entity: FaultCodeType. </summary>
	public partial class FaultCodeTypeRelations
	{
		/// <summary>CTor</summary>
		public FaultCodeTypeRelations()
		{
		}

		/// <summary>Gets all relations of the FaultCodeTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportBladeEntityUsingBladeFaultCodeTypeId);
			toReturn.Add(this.FaultCodeTypeEntityUsingParentFaultCodeTypeId);

			toReturn.Add(this.FaultCodeTypeEntityUsingFaultCodeTypeIdParentFaultCodeTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between FaultCodeTypeEntity and ComponentInspectionReportBladeEntity over the 1:n relation they have, using the relation between the fields:
		/// FaultCodeType.FaultCodeTypeId - ComponentInspectionReportBlade.BladeFaultCodeTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeEntityUsingBladeFaultCodeTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBlade" , true);
				relation.AddEntityFieldPair(FaultCodeTypeFields.FaultCodeTypeId, ComponentInspectionReportBladeFields.BladeFaultCodeTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FaultCodeTypeEntity and FaultCodeTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// FaultCodeType.FaultCodeTypeId - FaultCodeType.ParentFaultCodeTypeId
		/// </summary>
		public virtual IEntityRelation FaultCodeTypeEntityUsingParentFaultCodeTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FaultCodeType_" , true);
				relation.AddEntityFieldPair(FaultCodeTypeFields.FaultCodeTypeId, FaultCodeTypeFields.ParentFaultCodeTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeTypeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between FaultCodeTypeEntity and FaultCodeTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// FaultCodeType.ParentFaultCodeTypeId - FaultCodeType.FaultCodeTypeId
		/// </summary>
		public virtual IEntityRelation FaultCodeTypeEntityUsingFaultCodeTypeIdParentFaultCodeTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FaultCodeType", false);
				relation.AddEntityFieldPair(FaultCodeTypeFields.FaultCodeTypeId, FaultCodeTypeFields.ParentFaultCodeTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeTypeEntity", true);
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
