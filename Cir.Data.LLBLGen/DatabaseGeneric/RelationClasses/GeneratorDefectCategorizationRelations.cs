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
	/// <summary>Implements the static Relations variant for the entity: GeneratorDefectCategorization. </summary>
	public partial class GeneratorDefectCategorizationRelations
	{
		/// <summary>CTor</summary>
		public GeneratorDefectCategorizationRelations()
		{
		}

		/// <summary>Gets all relations of the GeneratorDefectCategorizationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId);
			toReturn.Add(this.GeneratorMiscDecisionEntityUsingMiscPtsensorDecision);
			toReturn.Add(this.GeneratorMiscDecisionEntityUsingMiscWaterDecision);
			toReturn.Add(this.GeneratorMiscDecisionEntityUsingMiscGroundingDecision);
			toReturn.Add(this.GeneratorMiscDecisionEntityUsingMiscBearingDecision);
			toReturn.Add(this.GeneratorMiscDecisionEntityUsingMiscGeneratorDecision);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between GeneratorDefectCategorizationEntity and ComponentInspectionReportGeneratorEntity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorDefectCategorization.ComponentInspectionReportGeneratorId - ComponentInspectionReportGenerator.ComponentInspectionReportGeneratorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportGeneratorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReportGenerator", false);
				relation.AddEntityFieldPair(ComponentInspectionReportGeneratorFields.ComponentInspectionReportGeneratorId, GeneratorDefectCategorizationFields.ComponentInspectionReportGeneratorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between GeneratorDefectCategorizationEntity and GeneratorMiscDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorDefectCategorization.MiscPtsensorDecision - GeneratorMiscDecision.GeneratorMiscDecisionId
		/// </summary>
		public virtual IEntityRelation GeneratorMiscDecisionEntityUsingMiscPtsensorDecision
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorMiscDecision___", false);
				relation.AddEntityFieldPair(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, GeneratorDefectCategorizationFields.MiscPtsensorDecision);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorMiscDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between GeneratorDefectCategorizationEntity and GeneratorMiscDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorDefectCategorization.MiscWaterDecision - GeneratorMiscDecision.GeneratorMiscDecisionId
		/// </summary>
		public virtual IEntityRelation GeneratorMiscDecisionEntityUsingMiscWaterDecision
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorMiscDecision____", false);
				relation.AddEntityFieldPair(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, GeneratorDefectCategorizationFields.MiscWaterDecision);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorMiscDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between GeneratorDefectCategorizationEntity and GeneratorMiscDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorDefectCategorization.MiscGroundingDecision - GeneratorMiscDecision.GeneratorMiscDecisionId
		/// </summary>
		public virtual IEntityRelation GeneratorMiscDecisionEntityUsingMiscGroundingDecision
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorMiscDecision__", false);
				relation.AddEntityFieldPair(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, GeneratorDefectCategorizationFields.MiscGroundingDecision);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorMiscDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between GeneratorDefectCategorizationEntity and GeneratorMiscDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorDefectCategorization.MiscBearingDecision - GeneratorMiscDecision.GeneratorMiscDecisionId
		/// </summary>
		public virtual IEntityRelation GeneratorMiscDecisionEntityUsingMiscBearingDecision
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorMiscDecision", false);
				relation.AddEntityFieldPair(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, GeneratorDefectCategorizationFields.MiscBearingDecision);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorMiscDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between GeneratorDefectCategorizationEntity and GeneratorMiscDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorDefectCategorization.MiscGeneratorDecision - GeneratorMiscDecision.GeneratorMiscDecisionId
		/// </summary>
		public virtual IEntityRelation GeneratorMiscDecisionEntityUsingMiscGeneratorDecision
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorMiscDecision_", false);
				relation.AddEntityFieldPair(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, GeneratorDefectCategorizationFields.MiscGeneratorDecision);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorMiscDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", true);
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
