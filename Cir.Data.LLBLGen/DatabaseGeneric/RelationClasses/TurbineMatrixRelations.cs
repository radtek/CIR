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
	/// <summary>Implements the static Relations variant for the entity: TurbineMatrix. </summary>
	public partial class TurbineMatrixRelations
	{
		/// <summary>CTor</summary>
		public TurbineMatrixRelations()
		{
		}

		/// <summary>Gets all relations of the TurbineMatrixEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportEntityUsingTurbineMatrixId);

			toReturn.Add(this.TurbineEntityUsingTurbineId);
			toReturn.Add(this.TurbineFrequencyEntityUsingTurbineFrequencyId);
			toReturn.Add(this.TurbineManufacturerEntityUsingTurbineManufacturerId);
			toReturn.Add(this.TurbineMarkVersionEntityUsingTurbineMarkVersionId);
			toReturn.Add(this.TurbineNominelPowerEntityUsingTurbineNominelPowerId);
			toReturn.Add(this.TurbineOldEntityUsingTurbineOldId);
			toReturn.Add(this.TurbinePlacementEntityUsingTurbinePlacementId);
			toReturn.Add(this.TurbinePowerRegulationEntityUsingTurbinePowerRegulationId);
			toReturn.Add(this.TurbineRotorDiameterEntityUsingTurbineRotorDiameterId);
			toReturn.Add(this.TurbineSmallGeneratorEntityUsingTurbineSmallGeneratorId);
			toReturn.Add(this.TurbineTemperatureVariantEntityUsingTurbineTemperatureVariantId);
			toReturn.Add(this.TurbineVoltageEntityUsingTurbineVoltageId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbineMatrixId - ComponentInspectionReport.TurbineMatrixId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingTurbineMatrixId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport" , true);
				relation.AddEntityFieldPair(TurbineMatrixFields.TurbineMatrixId, ComponentInspectionReportFields.TurbineMatrixId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbineEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbineId - Turbine.TurbineId
		/// </summary>
		public virtual IEntityRelation TurbineEntityUsingTurbineId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Turbine", false);
				relation.AddEntityFieldPair(TurbineFields.TurbineId, TurbineMatrixFields.TurbineId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbineFrequencyEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbineFrequencyId - TurbineFrequency.TurbineFrequencyId
		/// </summary>
		public virtual IEntityRelation TurbineFrequencyEntityUsingTurbineFrequencyId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineFrequency", false);
				relation.AddEntityFieldPair(TurbineFrequencyFields.TurbineFrequencyId, TurbineMatrixFields.TurbineFrequencyId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineFrequencyEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbineManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbineManufacturerId - TurbineManufacturer.TurbineManufacturerId
		/// </summary>
		public virtual IEntityRelation TurbineManufacturerEntityUsingTurbineManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineManufacturer", false);
				relation.AddEntityFieldPair(TurbineManufacturerFields.TurbineManufacturerId, TurbineMatrixFields.TurbineManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbineMarkVersionEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbineMarkVersionId - TurbineMarkVersion.TurbineMarkVersionId
		/// </summary>
		public virtual IEntityRelation TurbineMarkVersionEntityUsingTurbineMarkVersionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineMarkVersion", false);
				relation.AddEntityFieldPair(TurbineMarkVersionFields.TurbineMarkVersionId, TurbineMatrixFields.TurbineMarkVersionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMarkVersionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbineNominelPowerEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbineNominelPowerId - TurbineNominelPower.TurbineNominelPowerId
		/// </summary>
		public virtual IEntityRelation TurbineNominelPowerEntityUsingTurbineNominelPowerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineNominelPower", false);
				relation.AddEntityFieldPair(TurbineNominelPowerFields.TurbineNominelPowerId, TurbineMatrixFields.TurbineNominelPowerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineNominelPowerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbineOldEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbineOldId - TurbineOld.TurbineOldId
		/// </summary>
		public virtual IEntityRelation TurbineOldEntityUsingTurbineOldId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineOld", false);
				relation.AddEntityFieldPair(TurbineOldFields.TurbineOldId, TurbineMatrixFields.TurbineOldId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineOldEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbinePlacementEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbinePlacementId - TurbinePlacement.TurbinePlacementId
		/// </summary>
		public virtual IEntityRelation TurbinePlacementEntityUsingTurbinePlacementId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbinePlacement", false);
				relation.AddEntityFieldPair(TurbinePlacementFields.TurbinePlacementId, TurbineMatrixFields.TurbinePlacementId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbinePlacementEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbinePowerRegulationEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbinePowerRegulationId - TurbinePowerRegulation.TurbinePowerRegulationId
		/// </summary>
		public virtual IEntityRelation TurbinePowerRegulationEntityUsingTurbinePowerRegulationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbinePowerRegulation", false);
				relation.AddEntityFieldPair(TurbinePowerRegulationFields.TurbinePowerRegulationId, TurbineMatrixFields.TurbinePowerRegulationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbinePowerRegulationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbineRotorDiameterEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbineRotorDiameterId - TurbineRotorDiameter.TurbineRotorDiameterId
		/// </summary>
		public virtual IEntityRelation TurbineRotorDiameterEntityUsingTurbineRotorDiameterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineRotorDiameter", false);
				relation.AddEntityFieldPair(TurbineRotorDiameterFields.TurbineRotorDiameterId, TurbineMatrixFields.TurbineRotorDiameterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineRotorDiameterEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbineSmallGeneratorEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbineSmallGeneratorId - TurbineSmallGenerator.TurbineSmallGeneratorId
		/// </summary>
		public virtual IEntityRelation TurbineSmallGeneratorEntityUsingTurbineSmallGeneratorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineSmallGenerator", false);
				relation.AddEntityFieldPair(TurbineSmallGeneratorFields.TurbineSmallGeneratorId, TurbineMatrixFields.TurbineSmallGeneratorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineSmallGeneratorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbineTemperatureVariantEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbineTemperatureVariantId - TurbineTemperatureVariant.TurbineTemperatureVariantId
		/// </summary>
		public virtual IEntityRelation TurbineTemperatureVariantEntityUsingTurbineTemperatureVariantId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineTemperatureVariant", false);
				relation.AddEntityFieldPair(TurbineTemperatureVariantFields.TurbineTemperatureVariantId, TurbineMatrixFields.TurbineTemperatureVariantId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineTemperatureVariantEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between TurbineMatrixEntity and TurbineVoltageEntity over the m:1 relation they have, using the relation between the fields:
		/// TurbineMatrix.TurbineVoltageId - TurbineVoltage.TurbineVoltageId
		/// </summary>
		public virtual IEntityRelation TurbineVoltageEntityUsingTurbineVoltageId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TurbineVoltage", false);
				relation.AddEntityFieldPair(TurbineVoltageFields.TurbineVoltageId, TurbineMatrixFields.TurbineVoltageId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineVoltageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", true);
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
