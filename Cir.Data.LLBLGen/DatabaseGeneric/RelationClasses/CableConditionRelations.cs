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
	/// <summary>Implements the static Relations variant for the entity: CableCondition. </summary>
	public partial class CableConditionRelations
	{
		/// <summary>CTor</summary>
		public CableConditionRelations()
		{
		}

		/// <summary>Gets all relations of the CableConditionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CableConditionEntityUsingParentCableConditionId);
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingLvcableConditionId);
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingHvcableConditionId);

			toReturn.Add(this.CableConditionEntityUsingCableConditionIdParentCableConditionId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CableConditionEntity and CableConditionEntity over the 1:n relation they have, using the relation between the fields:
		/// CableCondition.CableConditionId - CableCondition.ParentCableConditionId
		/// </summary>
		public virtual IEntityRelation CableConditionEntityUsingParentCableConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CableCondition_" , true);
				relation.AddEntityFieldPair(CableConditionFields.CableConditionId, CableConditionFields.ParentCableConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CableConditionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CableConditionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CableConditionEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// CableCondition.CableConditionId - ComponentInspectionReportTransformer.LvcableConditionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingLvcableConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer_" , true);
				relation.AddEntityFieldPair(CableConditionFields.CableConditionId, ComponentInspectionReportTransformerFields.LvcableConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CableConditionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CableConditionEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// CableCondition.CableConditionId - ComponentInspectionReportTransformer.HvcableConditionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingHvcableConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer" , true);
				relation.AddEntityFieldPair(CableConditionFields.CableConditionId, ComponentInspectionReportTransformerFields.HvcableConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CableConditionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CableConditionEntity and CableConditionEntity over the m:1 relation they have, using the relation between the fields:
		/// CableCondition.ParentCableConditionId - CableCondition.CableConditionId
		/// </summary>
		public virtual IEntityRelation CableConditionEntityUsingCableConditionIdParentCableConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CableCondition", false);
				relation.AddEntityFieldPair(CableConditionFields.CableConditionId, CableConditionFields.ParentCableConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CableConditionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CableConditionEntity", true);
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
