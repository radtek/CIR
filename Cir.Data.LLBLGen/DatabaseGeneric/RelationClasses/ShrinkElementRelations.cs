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
	/// <summary>Implements the static Relations variant for the entity: ShrinkElement. </summary>
	public partial class ShrinkElementRelations
	{
		/// <summary>CTor</summary>
		public ShrinkElementRelations()
		{
		}

		/// <summary>Gets all relations of the ShrinkElementEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxShrinkElementId);
			toReturn.Add(this.ShrinkElementEntityUsingParentShrinkElementId);

			toReturn.Add(this.ShrinkElementEntityUsingShrinkElementIdParentShrinkElementId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ShrinkElementEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// ShrinkElement.ShrinkElementId - ComponentInspectionReportGearbox.GearboxShrinkElementId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxShrinkElementId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(ShrinkElementFields.ShrinkElementId, ComponentInspectionReportGearboxFields.GearboxShrinkElementId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShrinkElementEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShrinkElementEntity and ShrinkElementEntity over the 1:n relation they have, using the relation between the fields:
		/// ShrinkElement.ShrinkElementId - ShrinkElement.ParentShrinkElementId
		/// </summary>
		public virtual IEntityRelation ShrinkElementEntityUsingParentShrinkElementId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShrinkElement_" , true);
				relation.AddEntityFieldPair(ShrinkElementFields.ShrinkElementId, ShrinkElementFields.ParentShrinkElementId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShrinkElementEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShrinkElementEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ShrinkElementEntity and ShrinkElementEntity over the m:1 relation they have, using the relation between the fields:
		/// ShrinkElement.ParentShrinkElementId - ShrinkElement.ShrinkElementId
		/// </summary>
		public virtual IEntityRelation ShrinkElementEntityUsingShrinkElementIdParentShrinkElementId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShrinkElement", false);
				relation.AddEntityFieldPair(ShrinkElementFields.ShrinkElementId, ShrinkElementFields.ParentShrinkElementId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShrinkElementEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShrinkElementEntity", true);
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
