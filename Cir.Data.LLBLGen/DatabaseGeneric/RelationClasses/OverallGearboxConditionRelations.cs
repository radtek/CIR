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
	/// <summary>Implements the static Relations variant for the entity: OverallGearboxCondition. </summary>
	public partial class OverallGearboxConditionRelations
	{
		/// <summary>CTor</summary>
		public OverallGearboxConditionRelations()
		{
		}

		/// <summary>Gets all relations of the OverallGearboxConditionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxOverallGearboxConditionId);
			toReturn.Add(this.OverallGearboxConditionEntityUsingParentOverallGearboxConditionId);

			toReturn.Add(this.OverallGearboxConditionEntityUsingOverallGearboxConditionIdParentOverallGearboxConditionId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OverallGearboxConditionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// OverallGearboxCondition.OverallGearboxConditionId - ComponentInspectionReportGearbox.GearboxOverallGearboxConditionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxOverallGearboxConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(OverallGearboxConditionFields.OverallGearboxConditionId, ComponentInspectionReportGearboxFields.GearboxOverallGearboxConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OverallGearboxConditionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OverallGearboxConditionEntity and OverallGearboxConditionEntity over the 1:n relation they have, using the relation between the fields:
		/// OverallGearboxCondition.OverallGearboxConditionId - OverallGearboxCondition.ParentOverallGearboxConditionId
		/// </summary>
		public virtual IEntityRelation OverallGearboxConditionEntityUsingParentOverallGearboxConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OverallGearboxCondition_" , true);
				relation.AddEntityFieldPair(OverallGearboxConditionFields.OverallGearboxConditionId, OverallGearboxConditionFields.ParentOverallGearboxConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OverallGearboxConditionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OverallGearboxConditionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between OverallGearboxConditionEntity and OverallGearboxConditionEntity over the m:1 relation they have, using the relation between the fields:
		/// OverallGearboxCondition.ParentOverallGearboxConditionId - OverallGearboxCondition.OverallGearboxConditionId
		/// </summary>
		public virtual IEntityRelation OverallGearboxConditionEntityUsingOverallGearboxConditionIdParentOverallGearboxConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OverallGearboxCondition", false);
				relation.AddEntityFieldPair(OverallGearboxConditionFields.OverallGearboxConditionId, OverallGearboxConditionFields.ParentOverallGearboxConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OverallGearboxConditionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OverallGearboxConditionEntity", true);
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
