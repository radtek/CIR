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
	/// <summary>Implements the static Relations variant for the entity: HousingError. </summary>
	public partial class HousingErrorRelations
	{
		/// <summary>CTor</summary>
		public HousingErrorRelations()
		{
		}

		/// <summary>Gets all relations of the HousingErrorEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxFrontPlateHousingErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxAuxStageHousingErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxHsstageHousingErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxPlanetStage1HousingErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxPlanetStage2HousingErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxHelicalStageHousingErrorId);
			toReturn.Add(this.HousingErrorEntityUsingParentHousingErrorId);

			toReturn.Add(this.HousingErrorEntityUsingHousingErrorIdParentHousingErrorId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between HousingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// HousingError.HousingErrorId - ComponentInspectionReportGearbox.GearboxFrontPlateHousingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxFrontPlateHousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___" , true);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxFrontPlateHousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HousingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// HousingError.HousingErrorId - ComponentInspectionReportGearbox.GearboxAuxStageHousingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxAuxStageHousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox____" , true);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxAuxStageHousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HousingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// HousingError.HousingErrorId - ComponentInspectionReportGearbox.GearboxHsstageHousingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxHsstageHousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_____" , true);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxHsstageHousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HousingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// HousingError.HousingErrorId - ComponentInspectionReportGearbox.GearboxPlanetStage1HousingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxPlanetStage1HousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxPlanetStage1HousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HousingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// HousingError.HousingErrorId - ComponentInspectionReportGearbox.GearboxPlanetStage2HousingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxPlanetStage2HousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_" , true);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxPlanetStage2HousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HousingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// HousingError.HousingErrorId - ComponentInspectionReportGearbox.GearboxHelicalStageHousingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxHelicalStageHousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__" , true);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, ComponentInspectionReportGearboxFields.GearboxHelicalStageHousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between HousingErrorEntity and HousingErrorEntity over the 1:n relation they have, using the relation between the fields:
		/// HousingError.HousingErrorId - HousingError.ParentHousingErrorId
		/// </summary>
		public virtual IEntityRelation HousingErrorEntityUsingParentHousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HousingError_" , true);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, HousingErrorFields.ParentHousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between HousingErrorEntity and HousingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// HousingError.ParentHousingErrorId - HousingError.HousingErrorId
		/// </summary>
		public virtual IEntityRelation HousingErrorEntityUsingHousingErrorIdParentHousingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "HousingError", false);
				relation.AddEntityFieldPair(HousingErrorFields.HousingErrorId, HousingErrorFields.ParentHousingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HousingErrorEntity", true);
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
