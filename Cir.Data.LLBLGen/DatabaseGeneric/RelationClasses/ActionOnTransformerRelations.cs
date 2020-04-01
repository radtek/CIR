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
	/// <summary>Implements the static Relations variant for the entity: ActionOnTransformer. </summary>
	public partial class ActionOnTransformerRelations
	{
		/// <summary>CTor</summary>
		public ActionOnTransformerRelations()
		{
		}

		/// <summary>Gets all relations of the ActionOnTransformerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ActionOnTransformerEntityUsingParentActionOnTransformerId);
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingActionOnTransformerId);

			toReturn.Add(this.ActionOnTransformerEntityUsingActionOnTransformerIdParentActionOnTransformerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ActionOnTransformerEntity and ActionOnTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// ActionOnTransformer.ActionOnTransformerId - ActionOnTransformer.ParentActionOnTransformerId
		/// </summary>
		public virtual IEntityRelation ActionOnTransformerEntityUsingParentActionOnTransformerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ActionOnTransformer_" , true);
				relation.AddEntityFieldPair(ActionOnTransformerFields.ActionOnTransformerId, ActionOnTransformerFields.ParentActionOnTransformerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionOnTransformerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionOnTransformerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ActionOnTransformerEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// ActionOnTransformer.ActionOnTransformerId - ComponentInspectionReportTransformer.ActionOnTransformerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingActionOnTransformerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer" , true);
				relation.AddEntityFieldPair(ActionOnTransformerFields.ActionOnTransformerId, ComponentInspectionReportTransformerFields.ActionOnTransformerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionOnTransformerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ActionOnTransformerEntity and ActionOnTransformerEntity over the m:1 relation they have, using the relation between the fields:
		/// ActionOnTransformer.ParentActionOnTransformerId - ActionOnTransformer.ActionOnTransformerId
		/// </summary>
		public virtual IEntityRelation ActionOnTransformerEntityUsingActionOnTransformerIdParentActionOnTransformerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ActionOnTransformer", false);
				relation.AddEntityFieldPair(ActionOnTransformerFields.ActionOnTransformerId, ActionOnTransformerFields.ParentActionOnTransformerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionOnTransformerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionOnTransformerEntity", true);
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
