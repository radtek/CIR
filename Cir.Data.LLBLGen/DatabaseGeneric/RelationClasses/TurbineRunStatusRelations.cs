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
	/// <summary>Implements the static Relations variant for the entity: TurbineRunStatus. </summary>
	public partial class TurbineRunStatusRelations
	{
		/// <summary>CTor</summary>
		public TurbineRunStatusRelations()
		{
		}

		/// <summary>Gets all relations of the TurbineRunStatusEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId);
			toReturn.Add(this.TurbineRunStatusEntityUsingParentTurbineRunStatusId);

			toReturn.Add(this.TurbineRunStatusEntityUsingTurbineRunStatusIdParentTurbineRunStatusId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TurbineRunStatusEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// TurbineRunStatus.TurbineRunStatusId - ComponentInspectionReport.AfterInspectionTurbineRunStatusId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingAfterInspectionTurbineRunStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport_" , true);
				relation.AddEntityFieldPair(TurbineRunStatusFields.TurbineRunStatusId, ComponentInspectionReportFields.AfterInspectionTurbineRunStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineRunStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TurbineRunStatusEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// TurbineRunStatus.TurbineRunStatusId - ComponentInspectionReport.BeforeInspectionTurbineRunStatusId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingBeforeInspectionTurbineRunStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport" , true);
				relation.AddEntityFieldPair(TurbineRunStatusFields.TurbineRunStatusId, ComponentInspectionReportFields.BeforeInspectionTurbineRunStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineRunStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TurbineRunStatusEntity and TurbineRunStatusEntity over the 1:n relation they have, using the relation between the fields:
		/// TurbineRunStatus.TurbineRunStatusId - TurbineRunStatus.ParentTurbineRunStatusId
		/// </summary>
		public virtual IEntityRelation TurbineRunStatusEntityUsingParentTurbineRunStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TurbineRunStatus_" , true);
				relation.AddEntityFieldPair(TurbineRunStatusFields.TurbineRunStatusId, TurbineRunStatusFields.ParentTurbineRunStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineRunStatusEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineRunStatusEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TurbineRunStatusEntity and TurbineRunStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineRunStatus.ParentTurbineRunStatusId - TurbineRunStatus.TurbineRunStatusId
		/// </summary>
		public virtual IEntityRelation TurbineRunStatusEntityUsingTurbineRunStatusIdParentTurbineRunStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineRunStatus", false);
				relation.AddEntityFieldPair(TurbineRunStatusFields.TurbineRunStatusId, TurbineRunStatusFields.ParentTurbineRunStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineRunStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineRunStatusEntity", true);
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
