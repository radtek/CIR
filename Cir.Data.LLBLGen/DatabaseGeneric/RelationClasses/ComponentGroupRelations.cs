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
	/// <summary>Implements the static Relations variant for the entity: ComponentGroup. </summary>
	public partial class ComponentGroupRelations
	{
		/// <summary>CTor</summary>
		public ComponentGroupRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentGroupEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentGroupEntityUsingParentComponentGroupId);
			toReturn.Add(this.ComponentInspectionReportGeneralEntityUsingGeneralComponentGroupId);

			toReturn.Add(this.ComponentGroupEntityUsingComponentGroupIdParentComponentGroupId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ComponentGroupEntity and ComponentGroupEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentGroup.ComponentGroupId - ComponentGroup.ParentComponentGroupId
		/// </summary>
		public virtual IEntityRelation ComponentGroupEntityUsingParentComponentGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentGroup_" , true);
				relation.AddEntityFieldPair(ComponentGroupFields.ComponentGroupId, ComponentGroupFields.ParentComponentGroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentGroupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentGroupEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentGroupEntity and ComponentInspectionReportGeneralEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentGroup.ComponentGroupId - ComponentInspectionReportGeneral.GeneralComponentGroupId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneralEntityUsingGeneralComponentGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGeneral" , true);
				relation.AddEntityFieldPair(ComponentGroupFields.ComponentGroupId, ComponentInspectionReportGeneralFields.GeneralComponentGroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentGroupEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ComponentGroupEntity and ComponentGroupEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentGroup.ParentComponentGroupId - ComponentGroup.ComponentGroupId
		/// </summary>
		public virtual IEntityRelation ComponentGroupEntityUsingComponentGroupIdParentComponentGroupId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentGroup", false);
				relation.AddEntityFieldPair(ComponentGroupFields.ComponentGroupId, ComponentGroupFields.ParentComponentGroupId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentGroupEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentGroupEntity", true);
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
