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
	/// <summary>Implements the static Relations variant for the entity: ActionToBeTakenOnGenerator. </summary>
	public partial class ActionToBeTakenOnGeneratorRelations
	{
		/// <summary>CTor</summary>
		public ActionToBeTakenOnGeneratorRelations()
		{
		}

		/// <summary>Gets all relations of the ActionToBeTakenOnGeneratorEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ActionToBeTakenOnGeneratorEntityUsingParentActionToBeTakenOnGeneratorId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingActionToBeTakenOnGeneratorId);

			toReturn.Add(this.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorIdParentActionToBeTakenOnGeneratorId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ActionToBeTakenOnGeneratorEntity and ActionToBeTakenOnGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// ActionToBeTakenOnGenerator.ActionToBeTakenOnGeneratorId - ActionToBeTakenOnGenerator.ParentActionToBeTakenOnGeneratorId
		/// </summary>
		public virtual IEntityRelation ActionToBeTakenOnGeneratorEntityUsingParentActionToBeTakenOnGeneratorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ActionToBeTakenOnGenerator_" , true);
				relation.AddEntityFieldPair(ActionToBeTakenOnGeneratorFields.ActionToBeTakenOnGeneratorId, ActionToBeTakenOnGeneratorFields.ParentActionToBeTakenOnGeneratorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionToBeTakenOnGeneratorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionToBeTakenOnGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ActionToBeTakenOnGeneratorEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// ActionToBeTakenOnGenerator.ActionToBeTakenOnGeneratorId - ComponentInspectionReportGenerator.ActionToBeTakenOnGeneratorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingActionToBeTakenOnGeneratorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator" , true);
				relation.AddEntityFieldPair(ActionToBeTakenOnGeneratorFields.ActionToBeTakenOnGeneratorId, ComponentInspectionReportGeneratorFields.ActionToBeTakenOnGeneratorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionToBeTakenOnGeneratorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ActionToBeTakenOnGeneratorEntity and ActionToBeTakenOnGeneratorEntity over the m:1 relation they have, using the relation between the fields:
		/// ActionToBeTakenOnGenerator.ParentActionToBeTakenOnGeneratorId - ActionToBeTakenOnGenerator.ActionToBeTakenOnGeneratorId
		/// </summary>
		public virtual IEntityRelation ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorIdParentActionToBeTakenOnGeneratorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ActionToBeTakenOnGenerator", false);
				relation.AddEntityFieldPair(ActionToBeTakenOnGeneratorFields.ActionToBeTakenOnGeneratorId, ActionToBeTakenOnGeneratorFields.ParentActionToBeTakenOnGeneratorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionToBeTakenOnGeneratorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionToBeTakenOnGeneratorEntity", true);
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
