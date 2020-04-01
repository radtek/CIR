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
	/// <summary>Implements the static Relations variant for the entity: CoilCondition. </summary>
	public partial class CoilConditionRelations
	{
		/// <summary>CTor</summary>
		public CoilConditionRelations()
		{
		}

		/// <summary>Gets all relations of the CoilConditionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CoilConditionEntityUsingParentCoilConditionId);
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingLvcoilConditionId);
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingHvcoilConditionId);

			toReturn.Add(this.CoilConditionEntityUsingCoilConditionIdParentCoilConditionId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CoilConditionEntity and CoilConditionEntity over the 1:n relation they have, using the relation between the fields:
		/// CoilCondition.CoilConditionId - CoilCondition.ParentCoilConditionId
		/// </summary>
		public virtual IEntityRelation CoilConditionEntityUsingParentCoilConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CoilCondition_" , true);
				relation.AddEntityFieldPair(CoilConditionFields.CoilConditionId, CoilConditionFields.ParentCoilConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CoilConditionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CoilConditionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CoilConditionEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// CoilCondition.CoilConditionId - ComponentInspectionReportTransformer.LvcoilConditionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingLvcoilConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer_" , true);
				relation.AddEntityFieldPair(CoilConditionFields.CoilConditionId, ComponentInspectionReportTransformerFields.LvcoilConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CoilConditionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CoilConditionEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// CoilCondition.CoilConditionId - ComponentInspectionReportTransformer.HvcoilConditionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingHvcoilConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer" , true);
				relation.AddEntityFieldPair(CoilConditionFields.CoilConditionId, ComponentInspectionReportTransformerFields.HvcoilConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CoilConditionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CoilConditionEntity and CoilConditionEntity over the m:1 relation they have, using the relation between the fields:
		/// CoilCondition.ParentCoilConditionId - CoilCondition.CoilConditionId
		/// </summary>
		public virtual IEntityRelation CoilConditionEntityUsingCoilConditionIdParentCoilConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CoilCondition", false);
				relation.AddEntityFieldPair(CoilConditionFields.CoilConditionId, CoilConditionFields.ParentCoilConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CoilConditionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CoilConditionEntity", true);
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
