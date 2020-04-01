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
	/// <summary>Implements the static Relations variant for the entity: GearboxManufacturer. </summary>
	public partial class GearboxManufacturerRelations
	{
		/// <summary>CTor</summary>
		public GearboxManufacturerRelations()
		{
		}

		/// <summary>Gets all relations of the GearboxManufacturerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxManufacturerId);
			toReturn.Add(this.ComponentInspectionReportGeneralEntityUsingGeneralGearboxManufacturerId);
			toReturn.Add(this.GearboxManufacturerEntityUsingParentGearboxManufacturerId);
			toReturn.Add(this.GearboxTypeEntityUsingGearboxManufacturerId);

			toReturn.Add(this.GearboxManufacturerEntityUsingGearboxManufacturerIdParentGearboxManufacturerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GearboxManufacturerEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearboxManufacturer.GearboxManufacturerId - ComponentInspectionReportGearbox.GearboxManufacturerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(GearboxManufacturerFields.GearboxManufacturerId, ComponentInspectionReportGearboxFields.GearboxManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearboxManufacturerEntity and ComponentInspectionReportGeneralEntity over the 1:n relation they have, using the relation between the fields:
		/// GearboxManufacturer.GearboxManufacturerId - ComponentInspectionReportGeneral.GeneralGearboxManufacturerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneralEntityUsingGeneralGearboxManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGeneral" , true);
				relation.AddEntityFieldPair(GearboxManufacturerFields.GearboxManufacturerId, ComponentInspectionReportGeneralFields.GeneralGearboxManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearboxManufacturerEntity and GearboxManufacturerEntity over the 1:n relation they have, using the relation between the fields:
		/// GearboxManufacturer.GearboxManufacturerId - GearboxManufacturer.ParentGearboxManufacturerId
		/// </summary>
		public virtual IEntityRelation GearboxManufacturerEntityUsingParentGearboxManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GearboxManufacturer_" , true);
				relation.AddEntityFieldPair(GearboxManufacturerFields.GearboxManufacturerId, GearboxManufacturerFields.ParentGearboxManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxManufacturerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearboxManufacturerEntity and GearboxTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// GearboxManufacturer.GearboxManufacturerId - GearboxType.GearboxManufacturerId
		/// </summary>
		public virtual IEntityRelation GearboxTypeEntityUsingGearboxManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GearboxType" , true);
				relation.AddEntityFieldPair(GearboxManufacturerFields.GearboxManufacturerId, GearboxTypeFields.GearboxManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxTypeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between GearboxManufacturerEntity and GearboxManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// GearboxManufacturer.ParentGearboxManufacturerId - GearboxManufacturer.GearboxManufacturerId
		/// </summary>
		public virtual IEntityRelation GearboxManufacturerEntityUsingGearboxManufacturerIdParentGearboxManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearboxManufacturer", false);
				relation.AddEntityFieldPair(GearboxManufacturerFields.GearboxManufacturerId, GearboxManufacturerFields.ParentGearboxManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxManufacturerEntity", true);
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
