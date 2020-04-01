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
	/// <summary>Implements the static Relations variant for the entity: ComponentInspectionReportBlade. </summary>
	public partial class ComponentInspectionReportBladeRelations
	{
		/// <summary>CTor</summary>
		public ComponentInspectionReportBladeRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentInspectionReportBladeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId);
			toReturn.Add(this.ComponentInspectionReportBladeRepairRecordEntityUsingComponentInspectionReportBladeId);

			toReturn.Add(this.BladeColorEntityUsingBladeColorId);
			toReturn.Add(this.BladeLengthEntityUsingBladeLengthId);
			toReturn.Add(this.BooleanAnswerEntityUsingBladeClaimRelevantBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingBladePicturesIncludedBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingComponentInspectionReportId);
			toReturn.Add(this.FaultCodeAreaEntityUsingBladeFaultCodeAreaId);
			toReturn.Add(this.FaultCodeCauseEntityUsingBladeFaultCodeCauseId);
			toReturn.Add(this.FaultCodeClassificationEntityUsingBladeFaultCodeClassificationId);
			toReturn.Add(this.FaultCodeTypeEntityUsingBladeFaultCodeTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeEntity and ComponentInspectionReportBladeDamageEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReportBlade.ComponentInspectionReportBladeId - ComponentInspectionReportBladeDamage.ComponentInspectionReportBladeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeDamageEntityUsingComponentInspectionReportBladeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBladeDamage" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportBladeFields.ComponentInspectionReportBladeId, ComponentInspectionReportBladeDamageFields.ComponentInspectionReportBladeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeDamageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeEntity and ComponentInspectionReportBladeRepairRecordEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReportBlade.ComponentInspectionReportBladeId - ComponentInspectionReportBladeRepairRecord.ComponentInspectionReportBladeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeRepairRecordEntityUsingComponentInspectionReportBladeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBladeRepairRecord" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportBladeFields.ComponentInspectionReportBladeId, ComponentInspectionReportBladeRepairRecordFields.ComponentInspectionReportBladeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeRepairRecordEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeEntity and BladeColorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBlade.BladeColorId - BladeColor.BladeColorId
		/// </summary>
		public virtual IEntityRelation BladeColorEntityUsingBladeColorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BladeColor", false);
				relation.AddEntityFieldPair(BladeColorFields.BladeColorId, ComponentInspectionReportBladeFields.BladeColorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeColorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeEntity and BladeLengthEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBlade.BladeLengthId - BladeLength.BladeLengthId
		/// </summary>
		public virtual IEntityRelation BladeLengthEntityUsingBladeLengthId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BladeLength", false);
				relation.AddEntityFieldPair(BladeLengthFields.BladeLengthId, ComponentInspectionReportBladeFields.BladeLengthId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeLengthEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBlade.BladeClaimRelevantBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingBladeClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer_", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportBladeFields.BladeClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBlade.BladePicturesIncludedBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingBladePicturesIncludedBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportBladeFields.BladePicturesIncludedBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeEntity and ComponentInspectionReportEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBlade.ComponentInspectionReportId - ComponentInspectionReport.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReport", false);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportBladeFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeEntity and FaultCodeAreaEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBlade.BladeFaultCodeAreaId - FaultCodeArea.FaultCodeAreaId
		/// </summary>
		public virtual IEntityRelation FaultCodeAreaEntityUsingBladeFaultCodeAreaId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FaultCodeArea", false);
				relation.AddEntityFieldPair(FaultCodeAreaFields.FaultCodeAreaId, ComponentInspectionReportBladeFields.BladeFaultCodeAreaId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeAreaEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeEntity and FaultCodeCauseEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBlade.BladeFaultCodeCauseId - FaultCodeCause.FaultCodeCauseId
		/// </summary>
		public virtual IEntityRelation FaultCodeCauseEntityUsingBladeFaultCodeCauseId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FaultCodeCause", false);
				relation.AddEntityFieldPair(FaultCodeCauseFields.FaultCodeCauseId, ComponentInspectionReportBladeFields.BladeFaultCodeCauseId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeCauseEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeEntity and FaultCodeClassificationEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBlade.BladeFaultCodeClassificationId - FaultCodeClassification.FaultCodeClassificationId
		/// </summary>
		public virtual IEntityRelation FaultCodeClassificationEntityUsingBladeFaultCodeClassificationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FaultCodeClassification", false);
				relation.AddEntityFieldPair(FaultCodeClassificationFields.FaultCodeClassificationId, ComponentInspectionReportBladeFields.BladeFaultCodeClassificationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeClassificationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportBladeEntity and FaultCodeTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportBlade.BladeFaultCodeTypeId - FaultCodeType.FaultCodeTypeId
		/// </summary>
		public virtual IEntityRelation FaultCodeTypeEntityUsingBladeFaultCodeTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FaultCodeType", false);
				relation.AddEntityFieldPair(FaultCodeTypeFields.FaultCodeTypeId, ComponentInspectionReportBladeFields.BladeFaultCodeTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", true);
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
