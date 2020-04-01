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
	/// <summary>Implements the static Relations variant for the entity: ComponentInspectionReportGearbox. </summary>
	public partial class ComponentInspectionReportGearboxRelations
	{
		/// <summary>CTor</summary>
		public ComponentInspectionReportGearboxRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentInspectionReportGearboxEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.BearingErrorEntityUsingGearboxBearingsDamage4BearingErrorId);
			toReturn.Add(this.BearingErrorEntityUsingGearboxBearingsDamage5BearingErrorId);
			toReturn.Add(this.BearingErrorEntityUsingGearboxBearingsDamage6BearingErrorId);
			toReturn.Add(this.BearingErrorEntityUsingGearboxBearingsDamage1BearingErrorId);
			toReturn.Add(this.BearingErrorEntityUsingGearboxBearingsDamage2BearingErrorId);
			toReturn.Add(this.BearingErrorEntityUsingGearboxBearingsDamage3BearingErrorId);
			toReturn.Add(this.BearingPosEntityUsingGearboxBearingsPosition5BearingPosId);
			toReturn.Add(this.BearingPosEntityUsingGearboxBearingsPosition6BearingPosId);
			toReturn.Add(this.BearingPosEntityUsingGearboxBearingsPosition4BearingPosId);
			toReturn.Add(this.BearingPosEntityUsingGearboxBearingsPosition1BearingPosId);
			toReturn.Add(this.BearingPosEntityUsingGearboxBearingsPosition2BearingPosId);
			toReturn.Add(this.BearingPosEntityUsingGearboxBearingsPosition3BearingPosId);
			toReturn.Add(this.BearingTypeEntityUsingGearboxBearingsLocation1BearingTypeId);
			toReturn.Add(this.BearingTypeEntityUsingGearboxBearingsLocation6BearingTypeId);
			toReturn.Add(this.BearingTypeEntityUsingGearboxBearingsLocation5BearingTypeId);
			toReturn.Add(this.BearingTypeEntityUsingGearboxBearingsLocation4BearingTypeId);
			toReturn.Add(this.BearingTypeEntityUsingGearboxBearingsLocation3BearingTypeId);
			toReturn.Add(this.BearingTypeEntityUsingGearboxBearingsLocation2BearingTypeId);
			toReturn.Add(this.BooleanAnswerEntityUsingGearboxClaimRelevantBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingGearboxOffLineFilterId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingComponentInspectionReportId);
			toReturn.Add(this.CouplingEntityUsingGearboxCouplingId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision1DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision2DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision14DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision15DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision4DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision5DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision6DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision3DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxBearingDecision4DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxBearingDecision3DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxBearingDecision5DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxBearingDecision6DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision12DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision13DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision10DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision11DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision7DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxBearingDecision1DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxBearingDecision2DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision8DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingGearboxGearDecision9DamageDecisionId);
			toReturn.Add(this.DebrisGearboxEntityUsingGearboxDebrisGearBoxId);
			toReturn.Add(this.DebrisOnMagnetEntityUsingGearboxDebrisOnMagnetId);
			toReturn.Add(this.ElectricalPumpEntityUsingGearboxElectricalPumpId);
			toReturn.Add(this.FilterBlockTypeEntityUsingGearboxFilterBlockTypeId);
			toReturn.Add(this.GearboxManufacturerEntityUsingGearboxManufacturerId);
			toReturn.Add(this.GearboxRevisionEntityUsingGearboxRevisionId);
			toReturn.Add(this.GearboxTypeEntityUsingGearboxTypeId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage6GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage12GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage13GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage10GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage11GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage7GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage8GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage14GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage15GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage3GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage9GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage5GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage4GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage1GearErrorId);
			toReturn.Add(this.GearErrorEntityUsingGearboxTypeofDamage2GearErrorId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation12GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation14GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation13GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation6GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation9GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation5GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation7GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation8GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation3GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation2GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation1GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation4GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation11GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation10GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingGearboxExactLocation15GearTypeId);
			toReturn.Add(this.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId2);
			toReturn.Add(this.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId);
			toReturn.Add(this.HousingErrorEntityUsingGearboxHsstageHousingErrorId);
			toReturn.Add(this.HousingErrorEntityUsingGearboxAuxStageHousingErrorId);
			toReturn.Add(this.HousingErrorEntityUsingGearboxFrontPlateHousingErrorId);
			toReturn.Add(this.HousingErrorEntityUsingGearboxPlanetStage1HousingErrorId);
			toReturn.Add(this.HousingErrorEntityUsingGearboxPlanetStage2HousingErrorId);
			toReturn.Add(this.HousingErrorEntityUsingGearboxHelicalStageHousingErrorId);
			toReturn.Add(this.InlineFilterEntityUsingGearboxInLineFilterId);
			toReturn.Add(this.MagnetPosEntityUsingGearboxDebrisStagesMagnetPosId);
			toReturn.Add(this.MechanicalOilPumpEntityUsingGearboxMechanicalOilPumpId);
			toReturn.Add(this.NoiseEntityUsingGearboxNoiseId);
			toReturn.Add(this.OilLevelEntityUsingGearboxOilLevelId);
			toReturn.Add(this.OilTypeEntityUsingGearboxOilTypeId);
			toReturn.Add(this.OverallGearboxConditionEntityUsingGearboxOverallGearboxConditionId);
			toReturn.Add(this.ShaftErrorEntityUsingGearboxShaftsTypeofDamage3ShaftErrorId);
			toReturn.Add(this.ShaftErrorEntityUsingGearboxShaftsTypeofDamage4ShaftErrorId);
			toReturn.Add(this.ShaftErrorEntityUsingGearboxShaftsTypeofDamage1ShaftErrorId);
			toReturn.Add(this.ShaftErrorEntityUsingGearboxShaftsTypeofDamage2ShaftErrorId);
			toReturn.Add(this.ShaftTypeEntityUsingGearboxShaftsExactLocation4ShaftTypeId);
			toReturn.Add(this.ShaftTypeEntityUsingGearboxShaftsExactLocation3ShaftTypeId);
			toReturn.Add(this.ShaftTypeEntityUsingGearboxShaftsExactLocation2ShaftTypeId);
			toReturn.Add(this.ShaftTypeEntityUsingGearboxShaftsExactLocation1ShaftTypeId);
			toReturn.Add(this.ShrinkElementEntityUsingGearboxShrinkElementId);
			toReturn.Add(this.VibrationsEntityUsingGearboxVibrationsId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsDamage4BearingErrorId - BearingError.BearingErrorId
		/// </summary>
		public virtual IEntityRelation BearingErrorEntityUsingGearboxBearingsDamage4BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingError___", false);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage4BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsDamage5BearingErrorId - BearingError.BearingErrorId
		/// </summary>
		public virtual IEntityRelation BearingErrorEntityUsingGearboxBearingsDamage5BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingError____", false);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage5BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsDamage6BearingErrorId - BearingError.BearingErrorId
		/// </summary>
		public virtual IEntityRelation BearingErrorEntityUsingGearboxBearingsDamage6BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingError_____", false);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage6BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsDamage1BearingErrorId - BearingError.BearingErrorId
		/// </summary>
		public virtual IEntityRelation BearingErrorEntityUsingGearboxBearingsDamage1BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingError", false);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage1BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsDamage2BearingErrorId - BearingError.BearingErrorId
		/// </summary>
		public virtual IEntityRelation BearingErrorEntityUsingGearboxBearingsDamage2BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingError_", false);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage2BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsDamage3BearingErrorId - BearingError.BearingErrorId
		/// </summary>
		public virtual IEntityRelation BearingErrorEntityUsingGearboxBearingsDamage3BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingError__", false);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage3BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingPosEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsPosition5BearingPosId - BearingPos.BearingPosId
		/// </summary>
		public virtual IEntityRelation BearingPosEntityUsingGearboxBearingsPosition5BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingPos____", false);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition5BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingPosEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsPosition6BearingPosId - BearingPos.BearingPosId
		/// </summary>
		public virtual IEntityRelation BearingPosEntityUsingGearboxBearingsPosition6BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingPos_____", false);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition6BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingPosEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsPosition4BearingPosId - BearingPos.BearingPosId
		/// </summary>
		public virtual IEntityRelation BearingPosEntityUsingGearboxBearingsPosition4BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingPos___", false);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition4BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingPosEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsPosition1BearingPosId - BearingPos.BearingPosId
		/// </summary>
		public virtual IEntityRelation BearingPosEntityUsingGearboxBearingsPosition1BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingPos", false);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition1BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingPosEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsPosition2BearingPosId - BearingPos.BearingPosId
		/// </summary>
		public virtual IEntityRelation BearingPosEntityUsingGearboxBearingsPosition2BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingPos_", false);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition2BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingPosEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsPosition3BearingPosId - BearingPos.BearingPosId
		/// </summary>
		public virtual IEntityRelation BearingPosEntityUsingGearboxBearingsPosition3BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingPos__", false);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition3BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsLocation1BearingTypeId - BearingType.BearingTypeId
		/// </summary>
		public virtual IEntityRelation BearingTypeEntityUsingGearboxBearingsLocation1BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingType", false);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation1BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsLocation6BearingTypeId - BearingType.BearingTypeId
		/// </summary>
		public virtual IEntityRelation BearingTypeEntityUsingGearboxBearingsLocation6BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingType_____", false);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation6BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsLocation5BearingTypeId - BearingType.BearingTypeId
		/// </summary>
		public virtual IEntityRelation BearingTypeEntityUsingGearboxBearingsLocation5BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingType____", false);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation5BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsLocation4BearingTypeId - BearingType.BearingTypeId
		/// </summary>
		public virtual IEntityRelation BearingTypeEntityUsingGearboxBearingsLocation4BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingType___", false);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation4BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsLocation3BearingTypeId - BearingType.BearingTypeId
		/// </summary>
		public virtual IEntityRelation BearingTypeEntityUsingGearboxBearingsLocation3BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingType__", false);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation3BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BearingTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingsLocation2BearingTypeId - BearingType.BearingTypeId
		/// </summary>
		public virtual IEntityRelation BearingTypeEntityUsingGearboxBearingsLocation2BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingType_", false);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation2BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxClaimRelevantBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingGearboxClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer_", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportGearboxFields.GearboxClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxOffLineFilterId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingGearboxOffLineFilterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportGearboxFields.GearboxOffLineFilterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and ComponentInspectionReportEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.ComponentInspectionReportId - ComponentInspectionReport.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReport", false);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportGearboxFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and CouplingEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxCouplingId - Coupling.CouplingId
		/// </summary>
		public virtual IEntityRelation CouplingEntityUsingGearboxCouplingId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Coupling", false);
				relation.AddEntityFieldPair(CouplingFields.CouplingId, ComponentInspectionReportGearboxFields.GearboxCouplingId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CouplingEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision1DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision1DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision____________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision1DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision2DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision2DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision_____________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision2DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision14DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision14DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision__________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision14DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision15DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision15DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision___________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision15DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision4DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision4DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision_______________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision4DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision5DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision5DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision________________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision5DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision6DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision6DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision_________________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision6DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision3DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision3DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision______________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision3DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingDecision4DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxBearingDecision4DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision___", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision4DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingDecision3DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxBearingDecision3DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision__", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision3DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingDecision5DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxBearingDecision5DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision____", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision5DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingDecision6DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxBearingDecision6DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision_____", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision6DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision12DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision12DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision12DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision13DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision13DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision_________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision13DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision10DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision10DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision______", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision10DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision11DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision11DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision_______", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision11DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision7DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision7DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision__________________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision7DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingDecision1DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxBearingDecision1DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision_", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision1DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxBearingDecision2DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxBearingDecision2DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision2DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision8DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision8DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision___________________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision8DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGearDecision9DamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingGearboxGearDecision9DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision____________________", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision9DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DebrisGearboxEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxDebrisGearBoxId - DebrisGearbox.DebrisGearboxId
		/// </summary>
		public virtual IEntityRelation DebrisGearboxEntityUsingGearboxDebrisGearBoxId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DebrisGearbox", false);
				relation.AddEntityFieldPair(DebrisGearboxFields.DebrisGearboxId, ComponentInspectionReportGearboxFields.GearboxDebrisGearBoxId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisGearboxEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and DebrisOnMagnetEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxDebrisOnMagnetId - DebrisOnMagnet.DebrisOnMagnetId
		/// </summary>
		public virtual IEntityRelation DebrisOnMagnetEntityUsingGearboxDebrisOnMagnetId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DebrisOnMagnet", false);
				relation.AddEntityFieldPair(DebrisOnMagnetFields.DebrisOnMagnetId, ComponentInspectionReportGearboxFields.GearboxDebrisOnMagnetId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisOnMagnetEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and ElectricalPumpEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxElectricalPumpId - ElectricalPump.ElectricalPumpId
		/// </summary>
		public virtual IEntityRelation ElectricalPumpEntityUsingGearboxElectricalPumpId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ElectricalPump", false);
				relation.AddEntityFieldPair(ElectricalPumpFields.ElectricalPumpId, ComponentInspectionReportGearboxFields.GearboxElectricalPumpId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ElectricalPumpEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and FilterBlockTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxFilterBlockTypeId - FilterBlockType.FilterBlockTypeId
		/// </summary>
		public virtual IEntityRelation FilterBlockTypeEntityUsingGearboxFilterBlockTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FilterBlockType", false);
				relation.AddEntityFieldPair(FilterBlockTypeFields.FilterBlockTypeId, ComponentInspectionReportGearboxFields.GearboxFilterBlockTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FilterBlockTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearboxManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxManufacturerId - GearboxManufacturer.GearboxManufacturerId
		/// </summary>
		public virtual IEntityRelation GearboxManufacturerEntityUsingGearboxManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearboxManufacturer", false);
				relation.AddEntityFieldPair(GearboxManufacturerFields.GearboxManufacturerId, ComponentInspectionReportGearboxFields.GearboxManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearboxRevisionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxRevisionId - GearboxRevision.GearboxRevisionId
		/// </summary>
		public virtual IEntityRelation GearboxRevisionEntityUsingGearboxRevisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearboxRevision", false);
				relation.AddEntityFieldPair(GearboxRevisionFields.GearboxRevisionId, ComponentInspectionReportGearboxFields.GearboxRevisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxRevisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearboxTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeId - GearboxType.GearboxTypeId
		/// </summary>
		public virtual IEntityRelation GearboxTypeEntityUsingGearboxTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearboxType", false);
				relation.AddEntityFieldPair(GearboxTypeFields.GearboxTypeId, ComponentInspectionReportGearboxFields.GearboxTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage6GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage6GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError___________", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage6GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage12GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage12GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError_______", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage12GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage13GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage13GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError________", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage13GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage10GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage10GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError_____", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage10GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage11GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage11GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError______", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage11GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage7GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage7GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError____________", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage7GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage8GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage8GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError_____________", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage8GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage14GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage14GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError_________", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage14GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage15GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage15GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError__________", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage15GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage3GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage3GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError__", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage3GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage9GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage9GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError______________", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage9GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage5GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage5GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError____", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage5GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage4GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage4GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError___", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage4GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage1GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage1GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage1GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxTypeofDamage2GearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearboxTypeofDamage2GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError_", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage2GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation12GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation12GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType________", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation12GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation14GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation14GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType__________", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation14GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation13GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation13GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType_________", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation13GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation6GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation6GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType_____", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation6GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation9GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation9GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType______________", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation9GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation5GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation5GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType____", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation5GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation7GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation7GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType____________", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation7GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation8GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation8GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType_____________", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation8GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation3GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation3GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType__", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation3GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation2GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation2GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType_", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation2GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation1GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation1GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation1GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation4GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation4GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType___", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation4GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation11GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation11GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType_______", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation11GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation10GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation10GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType______", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation10GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxExactLocation15GearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearboxExactLocation15GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType___________", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation15GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GeneratorManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGeneratorManufacturerId2 - GeneratorManufacturer.GeneratorManufacturerId
		/// </summary>
		public virtual IEntityRelation GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId2
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorManufacturer_", false);
				relation.AddEntityFieldPair(GeneratorManufacturerFields.GeneratorManufacturerId, ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId2);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and GeneratorManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxGeneratorManufacturerId - GeneratorManufacturer.GeneratorManufacturerId
		/// </summary>
		public virtual IEntityRelation GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorManufacturer", false);
				relation.AddEntityFieldPair(GeneratorManufacturerFields.GeneratorManufacturerId, ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and HousingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxHsstageHousingErrorId - HousingError.HousingErrorId
		/// </summary>
		public virtual IEntityRelation HousingErrorEntityUsingGearboxHsstageHousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HousingError_____", false);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxHsstageHousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and HousingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxAuxStageHousingErrorId - HousingError.HousingErrorId
		/// </summary>
		public virtual IEntityRelation HousingErrorEntityUsingGearboxAuxStageHousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HousingError____", false);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxAuxStageHousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and HousingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxFrontPlateHousingErrorId - HousingError.HousingErrorId
		/// </summary>
		public virtual IEntityRelation HousingErrorEntityUsingGearboxFrontPlateHousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HousingError___", false);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxFrontPlateHousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and HousingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxPlanetStage1HousingErrorId - HousingError.HousingErrorId
		/// </summary>
		public virtual IEntityRelation HousingErrorEntityUsingGearboxPlanetStage1HousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HousingError", false);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxPlanetStage1HousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and HousingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxPlanetStage2HousingErrorId - HousingError.HousingErrorId
		/// </summary>
		public virtual IEntityRelation HousingErrorEntityUsingGearboxPlanetStage2HousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HousingError_", false);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxPlanetStage2HousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and HousingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxHelicalStageHousingErrorId - HousingError.HousingErrorId
		/// </summary>
		public virtual IEntityRelation HousingErrorEntityUsingGearboxHelicalStageHousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HousingError__", false);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxHelicalStageHousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and InlineFilterEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxInLineFilterId - InlineFilter.InlineFilterId
		/// </summary>
		public virtual IEntityRelation InlineFilterEntityUsingGearboxInLineFilterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "InlineFilter", false);
				relation.AddEntityFieldPair(InlineFilterFields.InlineFilterId, ComponentInspectionReportGearboxFields.GearboxInLineFilterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InlineFilterEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and MagnetPosEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxDebrisStagesMagnetPosId - MagnetPos.MagnetPosId
		/// </summary>
		public virtual IEntityRelation MagnetPosEntityUsingGearboxDebrisStagesMagnetPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MagnetPos", false);
				relation.AddEntityFieldPair(MagnetPosFields.MagnetPosId, ComponentInspectionReportGearboxFields.GearboxDebrisStagesMagnetPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MagnetPosEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and MechanicalOilPumpEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxMechanicalOilPumpId - MechanicalOilPump.MechanicalOilPumpId
		/// </summary>
		public virtual IEntityRelation MechanicalOilPumpEntityUsingGearboxMechanicalOilPumpId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MechanicalOilPump", false);
				relation.AddEntityFieldPair(MechanicalOilPumpFields.MechanicalOilPumpId, ComponentInspectionReportGearboxFields.GearboxMechanicalOilPumpId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MechanicalOilPumpEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and NoiseEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxNoiseId - Noise.NoiseId
		/// </summary>
		public virtual IEntityRelation NoiseEntityUsingGearboxNoiseId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Noise", false);
				relation.AddEntityFieldPair(NoiseFields.NoiseId, ComponentInspectionReportGearboxFields.GearboxNoiseId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("NoiseEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and OilLevelEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxOilLevelId - OilLevel.OilLevelId
		/// </summary>
		public virtual IEntityRelation OilLevelEntityUsingGearboxOilLevelId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OilLevel", false);
				relation.AddEntityFieldPair(OilLevelFields.OilLevelId, ComponentInspectionReportGearboxFields.GearboxOilLevelId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilLevelEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and OilTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxOilTypeId - OilType.OilTypeId
		/// </summary>
		public virtual IEntityRelation OilTypeEntityUsingGearboxOilTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OilType", false);
				relation.AddEntityFieldPair(OilTypeFields.OilTypeId, ComponentInspectionReportGearboxFields.GearboxOilTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and OverallGearboxConditionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxOverallGearboxConditionId - OverallGearboxCondition.OverallGearboxConditionId
		/// </summary>
		public virtual IEntityRelation OverallGearboxConditionEntityUsingGearboxOverallGearboxConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OverallGearboxCondition", false);
				relation.AddEntityFieldPair(OverallGearboxConditionFields.OverallGearboxConditionId, ComponentInspectionReportGearboxFields.GearboxOverallGearboxConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OverallGearboxConditionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and ShaftErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxShaftsTypeofDamage3ShaftErrorId - ShaftError.ShaftErrorId
		/// </summary>
		public virtual IEntityRelation ShaftErrorEntityUsingGearboxShaftsTypeofDamage3ShaftErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShaftError__", false);
				relation.AddEntityFieldPair(ShaftErrorFields.ShaftErrorId, ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage3ShaftErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and ShaftErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxShaftsTypeofDamage4ShaftErrorId - ShaftError.ShaftErrorId
		/// </summary>
		public virtual IEntityRelation ShaftErrorEntityUsingGearboxShaftsTypeofDamage4ShaftErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShaftError___", false);
				relation.AddEntityFieldPair(ShaftErrorFields.ShaftErrorId, ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage4ShaftErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and ShaftErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxShaftsTypeofDamage1ShaftErrorId - ShaftError.ShaftErrorId
		/// </summary>
		public virtual IEntityRelation ShaftErrorEntityUsingGearboxShaftsTypeofDamage1ShaftErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShaftError", false);
				relation.AddEntityFieldPair(ShaftErrorFields.ShaftErrorId, ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage1ShaftErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and ShaftErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxShaftsTypeofDamage2ShaftErrorId - ShaftError.ShaftErrorId
		/// </summary>
		public virtual IEntityRelation ShaftErrorEntityUsingGearboxShaftsTypeofDamage2ShaftErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShaftError_", false);
				relation.AddEntityFieldPair(ShaftErrorFields.ShaftErrorId, ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage2ShaftErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and ShaftTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxShaftsExactLocation4ShaftTypeId - ShaftType.ShaftTypeId
		/// </summary>
		public virtual IEntityRelation ShaftTypeEntityUsingGearboxShaftsExactLocation4ShaftTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShaftType___", false);
				relation.AddEntityFieldPair(ShaftTypeFields.ShaftTypeId, ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation4ShaftTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and ShaftTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxShaftsExactLocation3ShaftTypeId - ShaftType.ShaftTypeId
		/// </summary>
		public virtual IEntityRelation ShaftTypeEntityUsingGearboxShaftsExactLocation3ShaftTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShaftType__", false);
				relation.AddEntityFieldPair(ShaftTypeFields.ShaftTypeId, ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation3ShaftTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and ShaftTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxShaftsExactLocation2ShaftTypeId - ShaftType.ShaftTypeId
		/// </summary>
		public virtual IEntityRelation ShaftTypeEntityUsingGearboxShaftsExactLocation2ShaftTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShaftType_", false);
				relation.AddEntityFieldPair(ShaftTypeFields.ShaftTypeId, ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation2ShaftTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and ShaftTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxShaftsExactLocation1ShaftTypeId - ShaftType.ShaftTypeId
		/// </summary>
		public virtual IEntityRelation ShaftTypeEntityUsingGearboxShaftsExactLocation1ShaftTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShaftType", false);
				relation.AddEntityFieldPair(ShaftTypeFields.ShaftTypeId, ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation1ShaftTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and ShrinkElementEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxShrinkElementId - ShrinkElement.ShrinkElementId
		/// </summary>
		public virtual IEntityRelation ShrinkElementEntityUsingGearboxShrinkElementId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShrinkElement", false);
				relation.AddEntityFieldPair(ShrinkElementFields.ShrinkElementId, ComponentInspectionReportGearboxFields.GearboxShrinkElementId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShrinkElementEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportGearboxEntity and VibrationsEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportGearbox.GearboxVibrationsId - Vibrations.VibrationsId
		/// </summary>
		public virtual IEntityRelation VibrationsEntityUsingGearboxVibrationsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Vibrations", false);
				relation.AddEntityFieldPair(VibrationsFields.VibrationsId, ComponentInspectionReportGearboxFields.GearboxVibrationsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("VibrationsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", true);
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
