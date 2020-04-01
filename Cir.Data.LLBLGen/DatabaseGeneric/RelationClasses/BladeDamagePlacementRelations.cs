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
	/// <summary>Implements the static Relations variant for the entity: BladeDamagePlacement. </summary>
	public partial class BladeDamagePlacementRelations
	{
		/// <summary>CTor</summary>
		public BladeDamagePlacementRelations()
		{
		}

		/// <summary>Gets all relations of the BladeDamagePlacementEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BladeDamagePlacementEntityUsingParentBladeDamagePlacementId);
			toReturn.Add(this.ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId);

			toReturn.Add(this.BladeDamagePlacementEntityUsingBladeDamagePlacementIdParentBladeDamagePlacementId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BladeDamagePlacementEntity and BladeDamagePlacementEntity over the 1:n relation they have, using the relation between the fields:
		/// BladeDamagePlacement.BladeDamagePlacementId - BladeDamagePlacement.ParentBladeDamagePlacementId
		/// </summary>
		public virtual IEntityRelation BladeDamagePlacementEntityUsingParentBladeDamagePlacementId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BladeDamagePlacement_" , true);
				relation.AddEntityFieldPair(BladeDamagePlacementFields.BladeDamagePlacementId, BladeDamagePlacementFields.ParentBladeDamagePlacementId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeDamagePlacementEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeDamagePlacementEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BladeDamagePlacementEntity and ComponentInspectionReportBladeDamageEntity over the 1:n relation they have, using the relation between the fields:
		/// BladeDamagePlacement.BladeDamagePlacementId - ComponentInspectionReportBladeDamage.BladeDamagePlacementId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeDamageEntityUsingBladeDamagePlacementId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBladeDamage" , true);
				relation.AddEntityFieldPair(BladeDamagePlacementFields.BladeDamagePlacementId, ComponentInspectionReportBladeDamageFields.BladeDamagePlacementId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeDamagePlacementEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeDamageEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between BladeDamagePlacementEntity and BladeDamagePlacementEntity over the m:1 relation they have, using the relation between the fields:
		/// BladeDamagePlacement.ParentBladeDamagePlacementId - BladeDamagePlacement.BladeDamagePlacementId
		/// </summary>
		public virtual IEntityRelation BladeDamagePlacementEntityUsingBladeDamagePlacementIdParentBladeDamagePlacementId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BladeDamagePlacement", false);
				relation.AddEntityFieldPair(BladeDamagePlacementFields.BladeDamagePlacementId, BladeDamagePlacementFields.ParentBladeDamagePlacementId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeDamagePlacementEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeDamagePlacementEntity", true);
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
