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
	/// <summary>Implements the static Relations variant for the entity: ComponentInspectionReport. </summary>
	public partial class ComponentInspectionReportRelations
	{
		/// <summary>CTor</summary>
		public ComponentInspectionReportRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentInspectionReportEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportBladeEntityUsingComponentInspectionReportId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingComponentInspectionReportId);
			toReturn.Add(this.ComponentInspectionReportGeneralEntityUsingComponentInspectionReportId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportId);
			toReturn.Add(this.ComponentInspectionReportMainBearingEntityUsingComponentInspectionReportId);
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingComponentInspectionReportId);
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingComponentInspectionReportId);

			toReturn.Add(this.BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingReconstructionBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId);
			toReturn.Add(this.CountryIsoEntityUsingCountryIsoid);
			toReturn.Add(this.LocationTypeEntityUsingLocationTypeId);
			toReturn.Add(this.ReportTypeEntityUsingReportTypeId);
			toReturn.Add(this.SbuEntityUsingSbuid);
			toReturn.Add(this.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeId);
			toReturn.Add(this.TurbineMatrixEntityUsingTurbineMatrixId);
			toReturn.Add(this.TurbineRunStatusEntityUsingAfterInspectionTurbineRunStatusId);
			toReturn.Add(this.TurbineRunStatusEntityUsingBeforeInspectionTurbineRunStatusId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and ComponentInspectionReportBladeEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReport.ComponentInspectionReportId - ComponentInspectionReportBlade.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBlade" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportBladeFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReport.ComponentInspectionReportId - ComponentInspectionReportGearbox.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportGearboxFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and ComponentInspectionReportGeneralEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReport.ComponentInspectionReportId - ComponentInspectionReportGeneral.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneralEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGeneral" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportGeneralFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReport.ComponentInspectionReportId - ComponentInspectionReportGenerator.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportGeneratorFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and ComponentInspectionReportMainBearingEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReport.ComponentInspectionReportId - ComponentInspectionReportMainBearing.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportMainBearingEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportMainBearing" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportMainBearingFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReport.ComponentInspectionReportId - ComponentInspectionReportSkiiP.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportSkiiPFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReport.ComponentInspectionReportId - ComponentInspectionReportTransformer.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportTransformerFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.MountedOnMainComponentBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingMountedOnMainComponentBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer__", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportFields.MountedOnMainComponentBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.SecondGeneratorBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSecondGeneratorBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer_", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportFields.SecondGeneratorBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.ReconstructionBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingReconstructionBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportFields.ReconstructionBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and ComponentInspectionReportTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.ComponentInspectionReportTypeId - ComponentInspectionReportType.ComponentInspectionReportTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReportType", false);
				relation.AddEntityFieldPair(ComponentInspectionReportTypeFields.ComponentInspectionReportTypeId, ComponentInspectionReportFields.ComponentInspectionReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and CountryIsoEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.CountryIsoid - CountryIso.CountryIsoid
		/// </summary>
		public virtual IEntityRelation CountryIsoEntityUsingCountryIsoid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CountryIso", false);
				relation.AddEntityFieldPair(CountryIsoFields.CountryIsoid, ComponentInspectionReportFields.CountryIsoid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CountryIsoEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and LocationTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.LocationTypeId - LocationType.LocationTypeId
		/// </summary>
		public virtual IEntityRelation LocationTypeEntityUsingLocationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "LocationType", false);
				relation.AddEntityFieldPair(LocationTypeFields.LocationTypeId, ComponentInspectionReportFields.LocationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and ReportTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.ReportTypeId - ReportType.ReportTypeId
		/// </summary>
		public virtual IEntityRelation ReportTypeEntityUsingReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ReportType", false);
				relation.AddEntityFieldPair(ReportTypeFields.ReportTypeId, ComponentInspectionReportFields.ReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and SbuEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.Sbuid - Sbu.Sbuid
		/// </summary>
		public virtual IEntityRelation SbuEntityUsingSbuid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Sbu", false);
				relation.AddEntityFieldPair(SbuFields.Sbuid, ComponentInspectionReportFields.Sbuid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SbuEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and ServiceReportNumberTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.ServiceReportNumberTypeId - ServiceReportNumberType.ServiceReportNumberTypeId
		/// </summary>
		public virtual IEntityRelation ServiceReportNumberTypeEntityUsingServiceReportNumberTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ServiceReportNumberType", false);
				relation.AddEntityFieldPair(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, ComponentInspectionReportFields.ServiceReportNumberTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ServiceReportNumberTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and TurbineMatrixEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.TurbineMatrixId - TurbineMatrix.TurbineMatrixId
		/// </summary>
		public virtual IEntityRelation TurbineMatrixEntityUsingTurbineMatrixId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineMatrix", false);
				relation.AddEntityFieldPair(TurbineMatrixFields.TurbineMatrixId, ComponentInspectionReportFields.TurbineMatrixId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and TurbineRunStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.AfterInspectionTurbineRunStatusId - TurbineRunStatus.TurbineRunStatusId
		/// </summary>
		public virtual IEntityRelation TurbineRunStatusEntityUsingAfterInspectionTurbineRunStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineRunStatus_", false);
				relation.AddEntityFieldPair(TurbineRunStatusFields.TurbineRunStatusId, ComponentInspectionReportFields.AfterInspectionTurbineRunStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineRunStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportEntity and TurbineRunStatusEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReport.BeforeInspectionTurbineRunStatusId - TurbineRunStatus.TurbineRunStatusId
		/// </summary>
		public virtual IEntityRelation TurbineRunStatusEntityUsingBeforeInspectionTurbineRunStatusId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineRunStatus", false);
				relation.AddEntityFieldPair(TurbineRunStatusFields.TurbineRunStatusId, ComponentInspectionReportFields.BeforeInspectionTurbineRunStatusId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineRunStatusEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", true);
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
