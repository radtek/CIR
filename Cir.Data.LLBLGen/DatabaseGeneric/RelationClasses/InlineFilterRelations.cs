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
	/// <summary>Implements the static Relations variant for the entity: InlineFilter. </summary>
	public partial class InlineFilterRelations
	{
		/// <summary>CTor</summary>
		public InlineFilterRelations()
		{
		}

		/// <summary>Gets all relations of the InlineFilterEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxInLineFilterId);
			toReturn.Add(this.InlineFilterEntityUsingParentInlineFilterId);

			toReturn.Add(this.InlineFilterEntityUsingInlineFilterIdParentInlineFilterId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between InlineFilterEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// InlineFilter.InlineFilterId - ComponentInspectionReportGearbox.GearboxInLineFilterId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxInLineFilterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(InlineFilterFields.InlineFilterId, ComponentInspectionReportGearboxFields.GearboxInLineFilterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InlineFilterEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between InlineFilterEntity and InlineFilterEntity over the 1:n relation they have, using the relation between the fields:
		/// InlineFilter.InlineFilterId - InlineFilter.ParentInlineFilterId
		/// </summary>
		public virtual IEntityRelation InlineFilterEntityUsingParentInlineFilterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InlineFilter_" , true);
				relation.AddEntityFieldPair(InlineFilterFields.InlineFilterId, InlineFilterFields.ParentInlineFilterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InlineFilterEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InlineFilterEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between InlineFilterEntity and InlineFilterEntity over the m:1 relation they have, using the relation between the fields:
		/// InlineFilter.ParentInlineFilterId - InlineFilter.InlineFilterId
		/// </summary>
		public virtual IEntityRelation InlineFilterEntityUsingInlineFilterIdParentInlineFilterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "InlineFilter", false);
				relation.AddEntityFieldPair(InlineFilterFields.InlineFilterId, InlineFilterFields.ParentInlineFilterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InlineFilterEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InlineFilterEntity", true);
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
