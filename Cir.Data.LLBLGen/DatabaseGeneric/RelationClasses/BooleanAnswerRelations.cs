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
	/// <summary>Implements the static Relations variant for the entity: BooleanAnswer. </summary>
	public partial class BooleanAnswerRelations
	{
		/// <summary>CTor</summary>
		public BooleanAnswerRelations()
		{
		}

		/// <summary>Gets all relations of the BooleanAnswerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BooleanAnswerEntityUsingParentBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingMountedOnMainComponentBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingSecondGeneratorBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingReconstructionBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportBladeEntityUsingBladeClaimRelevantBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportBladeEntityUsingBladePicturesIncludedBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxClaimRelevantBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxOffLineFilterId);
			toReturn.Add(this.ComponentInspectionReportGeneralEntityUsingGeneralPicturesIncludedBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportGeneralEntityUsingGeneralClaimRelevantBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingGeneratorClaimRelevantBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportMainBearingEntityUsingMainBearingClaimRelevantBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv521BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv522BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv526BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv524BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv525BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv525xBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv526xBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv522BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv523BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv524xBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv525yBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv526yBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv524yBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv521BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiPclaimRelevantBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP850Kwv526BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv523BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP850Kwv525BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP850Kwv520BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiP850Kwv524BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingTransformerClaimRelevantBooleanAnswerId);

			toReturn.Add(this.BooleanAnswerEntityUsingBooleanAnswerIdParentBooleanAnswerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and BooleanAnswerEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - BooleanAnswer.ParentBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingParentBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BooleanAnswer_" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, BooleanAnswerFields.ParentBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReport.MountedOnMainComponentBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingMountedOnMainComponentBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport__" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReport.SecondGeneratorBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingSecondGeneratorBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport_" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportFields.SecondGeneratorBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReport.ReconstructionBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingReconstructionBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportFields.ReconstructionBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportBladeEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportBlade.BladeClaimRelevantBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeEntityUsingBladeClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBlade_" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportBladeFields.BladeClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportBladeEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportBlade.BladePicturesIncludedBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeEntityUsingBladePicturesIncludedBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBlade" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportBladeFields.BladePicturesIncludedBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportGearbox.GearboxClaimRelevantBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportGearboxFields.GearboxClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportGearbox.GearboxOffLineFilterId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxOffLineFilterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportGearboxFields.GearboxOffLineFilterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportGeneralEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportGeneral.GeneralPicturesIncludedBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneralEntityUsingGeneralPicturesIncludedBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGeneral_" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportGeneralFields.GeneralPicturesIncludedBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportGeneralEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportGeneral.GeneralClaimRelevantBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneralEntityUsingGeneralClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGeneral" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportGeneralFields.GeneralClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportGenerator.GeneratorClaimRelevantBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingGeneratorClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportGeneratorFields.GeneratorClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportMainBearingEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportMainBearing.MainBearingClaimRelevantBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportMainBearingEntityUsingMainBearingClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportMainBearing" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportMainBearingFields.MainBearingClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP3Mwv521BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv521BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP_____________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv521BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP3Mwv522BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv522BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP______________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv522BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP2Mwv526BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv526BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP____________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv526BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP2Mwv524BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv524BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP__________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv524BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP2Mwv525BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv525BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP___________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv525BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP3Mwv525xBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv525xBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP__________________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv525xBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP3Mwv526xBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv526xBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP___________________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv526xBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP2Mwv522BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv522BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP_________________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv522BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP3Mwv523BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv523BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP_______________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv523BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP3Mwv524xBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv524xBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP________________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv524xBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP3Mwv525yBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv525yBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP___" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv525yBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP3Mwv526yBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv526yBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP____" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv526yBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP3Mwv524yBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP3Mwv524yBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP__" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv524yBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP2Mwv521BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv521BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiPclaimRelevantBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiPclaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP_" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiPclaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP850Kwv526BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP850Kwv526BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP850Kwv526BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP2Mwv523BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP2Mwv523BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP_________" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv523BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP850Kwv525BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP850Kwv525BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP_______" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP850Kwv525BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP850Kwv520BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP850Kwv520BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP_____" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP850Kwv520BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportSkiiP.SkiiP850Kwv524BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiP850Kwv524BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP______" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP850Kwv524BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// BooleanAnswer.BooleanAnswerId - ComponentInspectionReportTransformer.TransformerClaimRelevantBooleanAnswerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingTransformerClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer" , true);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportTransformerFields.TransformerClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between BooleanAnswerEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// BooleanAnswer.ParentBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingBooleanAnswerIdParentBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, BooleanAnswerFields.ParentBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", true);
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
