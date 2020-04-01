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
	/// <summary>Implements the static Relations variant for the entity: GeneratorManufacturer. </summary>
	public partial class GeneratorManufacturerRelations
	{
		/// <summary>CTor</summary>
		public GeneratorManufacturerRelations()
		{
		}

		/// <summary>Gets all relations of the GeneratorManufacturerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGeneratorManufacturerId2);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGeneratorManufacturerId);
			toReturn.Add(this.ComponentInspectionReportGeneralEntityUsingGeneralGeneratorManufacturerId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingGeneratorManufacturerId);
			toReturn.Add(this.GeneratorManufacturerEntityUsingParentGeneratorManufacturerId);

			toReturn.Add(this.GeneratorManufacturerEntityUsingGeneratorManufacturerIdParentGeneratorManufacturerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GeneratorManufacturerEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorManufacturer.GeneratorManufacturerId - ComponentInspectionReportGearbox.GearboxGeneratorManufacturerId2
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGeneratorManufacturerId2
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_" , true);
				relation.AddEntityFieldPair(GeneratorManufacturerFields.GeneratorManufacturerId, ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId2);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GeneratorManufacturerEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorManufacturer.GeneratorManufacturerId - ComponentInspectionReportGearbox.GearboxGeneratorManufacturerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGeneratorManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(GeneratorManufacturerFields.GeneratorManufacturerId, ComponentInspectionReportGearboxFields.GearboxGeneratorManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GeneratorManufacturerEntity and ComponentInspectionReportGeneralEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorManufacturer.GeneratorManufacturerId - ComponentInspectionReportGeneral.GeneralGeneratorManufacturerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneralEntityUsingGeneralGeneratorManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGeneral" , true);
				relation.AddEntityFieldPair(GeneratorManufacturerFields.GeneratorManufacturerId, ComponentInspectionReportGeneralFields.GeneralGeneratorManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GeneratorManufacturerEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorManufacturer.GeneratorManufacturerId - ComponentInspectionReportGenerator.GeneratorManufacturerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingGeneratorManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator" , true);
				relation.AddEntityFieldPair(GeneratorManufacturerFields.GeneratorManufacturerId, ComponentInspectionReportGeneratorFields.GeneratorManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GeneratorManufacturerEntity and GeneratorManufacturerEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorManufacturer.GeneratorManufacturerId - GeneratorManufacturer.ParentGeneratorManufacturerId
		/// </summary>
		public virtual IEntityRelation GeneratorManufacturerEntityUsingParentGeneratorManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GeneratorManufacturer_" , true);
				relation.AddEntityFieldPair(GeneratorManufacturerFields.GeneratorManufacturerId, GeneratorManufacturerFields.ParentGeneratorManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between GeneratorManufacturerEntity and GeneratorManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorManufacturer.ParentGeneratorManufacturerId - GeneratorManufacturer.GeneratorManufacturerId
		/// </summary>
		public virtual IEntityRelation GeneratorManufacturerEntityUsingGeneratorManufacturerIdParentGeneratorManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorManufacturer", false);
				relation.AddEntityFieldPair(GeneratorManufacturerFields.GeneratorManufacturerId, GeneratorManufacturerFields.ParentGeneratorManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorManufacturerEntity", true);
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
