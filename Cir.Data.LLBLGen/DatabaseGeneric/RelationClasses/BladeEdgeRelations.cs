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
	/// <summary>Implements the static Relations variant for the entity: BladeEdge. </summary>
	public partial class BladeEdgeRelations
	{
		/// <summary>CTor</summary>
		public BladeEdgeRelations()
		{
		}

		/// <summary>Gets all relations of the BladeEdgeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BladeEdgeEntityUsingParentBladeEdgeId);
			toReturn.Add(this.ComponentInspectionReportBladeDamageEntityUsingBladeEdgeId);

			toReturn.Add(this.BladeEdgeEntityUsingBladeEdgeIdParentBladeEdgeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BladeEdgeEntity and BladeEdgeEntity over the 1:n relation they have, using the relation between the fields:
		/// BladeEdge.BladeEdgeId - BladeEdge.ParentBladeEdgeId
		/// </summary>
		public virtual IEntityRelation BladeEdgeEntityUsingParentBladeEdgeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BladeEdge_" , true);
				relation.AddEntityFieldPair(BladeEdgeFields.BladeEdgeId, BladeEdgeFields.ParentBladeEdgeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeEdgeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeEdgeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BladeEdgeEntity and ComponentInspectionReportBladeDamageEntity over the 1:n relation they have, using the relation between the fields:
		/// BladeEdge.BladeEdgeId - ComponentInspectionReportBladeDamage.BladeEdgeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeDamageEntityUsingBladeEdgeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBladeDamage" , true);
				relation.AddEntityFieldPair(BladeEdgeFields.BladeEdgeId, ComponentInspectionReportBladeDamageFields.BladeEdgeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeEdgeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeDamageEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between BladeEdgeEntity and BladeEdgeEntity over the m:1 relation they have, using the relation between the fields:
		/// BladeEdge.ParentBladeEdgeId - BladeEdge.BladeEdgeId
		/// </summary>
		public virtual IEntityRelation BladeEdgeEntityUsingBladeEdgeIdParentBladeEdgeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BladeEdge", false);
				relation.AddEntityFieldPair(BladeEdgeFields.BladeEdgeId, BladeEdgeFields.ParentBladeEdgeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeEdgeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeEdgeEntity", true);
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
