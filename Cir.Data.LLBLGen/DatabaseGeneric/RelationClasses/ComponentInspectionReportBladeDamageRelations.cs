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
	/// <summary>Implements the static Relations variant for the entity: ComponentInspectionReportBladeDamage. </summary>
	public partial class ComponentInspectionReportBladeDamageRelations
	{
		/// <summary>CTor</summary>
		public ComponentInspectionReportBladeDamageRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentInspectionReportBladeDamageEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.BladeDamagePlacementEntityUsingBladeDamagePlacementId);
			toReturn.Add(this.BladeEdgeEntityUsingBladeEdgeId);
			toReturn.Add(this.BladeInspectionDataEntityUsingBladeInspectionDataId);
			toReturn.Add(this.ComponentInspectionReportBladeEntityUsingComponentInspectionReportBladeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeDamageEntity and BladeDamagePlacementEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBladeDamage.BladeDamagePlacementId - BladeDamagePlacement.BladeDamagePlacementId
		/// </summary>
		public virtual IEntityRelation BladeDamagePlacementEntityUsingBladeDamagePlacementId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BladeDamagePlacement", false);
				relation.AddEntityFieldPair(BladeDamagePlacementFields.BladeDamagePlacementId, ComponentInspectionReportBladeDamageFields.BladeDamagePlacementId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeDamagePlacementEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeDamageEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeDamageEntity and BladeEdgeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBladeDamage.BladeEdgeId - BladeEdge.BladeEdgeId
		/// </summary>
		public virtual IEntityRelation BladeEdgeEntityUsingBladeEdgeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BladeEdge", false);
				relation.AddEntityFieldPair(BladeEdgeFields.BladeEdgeId, ComponentInspectionReportBladeDamageFields.BladeEdgeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeEdgeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeDamageEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeDamageEntity and BladeInspectionDataEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBladeDamage.BladeInspectionDataId - BladeInspectionData.BladeInspectionDataId
		/// </summary>
		public virtual IEntityRelation BladeInspectionDataEntityUsingBladeInspectionDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BladeInspectionData", false);
				relation.AddEntityFieldPair(BladeInspectionDataFields.BladeInspectionDataId, ComponentInspectionReportBladeDamageFields.BladeInspectionDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeInspectionDataEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeDamageEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeDamageEntity and ComponentInspectionReportBladeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBladeDamage.ComponentInspectionReportBladeId - ComponentInspectionReportBlade.ComponentInspectionReportBladeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeEntityUsingComponentInspectionReportBladeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReportBlade", false);
				relation.AddEntityFieldPair(ComponentInspectionReportBladeFields.ComponentInspectionReportBladeId, ComponentInspectionReportBladeDamageFields.ComponentInspectionReportBladeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeDamageEntity", true);
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
