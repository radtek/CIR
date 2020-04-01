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
	/// <summary>Implements the static Relations variant for the entity: GearboxType. </summary>
	public partial class GearboxTypeRelations
	{
		/// <summary>CTor</summary>
		public GearboxTypeRelations()
		{
		}

		/// <summary>Gets all relations of the GearboxTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeId);
			toReturn.Add(this.GearboxDefectCategorizationEntityUsingGearboxTypeId);
			toReturn.Add(this.GearboxTypeEntityUsingParentGearboxTypeId);

			toReturn.Add(this.GearboxManufacturerEntityUsingGearboxManufacturerId);
			toReturn.Add(this.GearboxTypeEntityUsingGearboxTypeIdParentGearboxTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GearboxTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearboxType.GearboxTypeId - ComponentInspectionReportGearbox.GearboxTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(GearboxTypeFields.GearboxTypeId, ComponentInspectionReportGearboxFields.GearboxTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearboxTypeEntity and GearboxDefectCategorizationEntity over the 1:n relation they have, using the relation between the fields:
		/// GearboxType.GearboxTypeId - GearboxDefectCategorization.GearboxTypeId
		/// </summary>
		public virtual IEntityRelation GearboxDefectCategorizationEntityUsingGearboxTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GearboxDefectCategorization" , true);
				relation.AddEntityFieldPair(GearboxTypeFields.GearboxTypeId, GearboxDefectCategorizationFields.GearboxTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxDefectCategorizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearboxTypeEntity and GearboxTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// GearboxType.GearboxTypeId - GearboxType.ParentGearboxTypeId
		/// </summary>
		public virtual IEntityRelation GearboxTypeEntityUsingParentGearboxTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GearboxType_" , true);
				relation.AddEntityFieldPair(GearboxTypeFields.GearboxTypeId, GearboxTypeFields.ParentGearboxTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxTypeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between GearboxTypeEntity and GearboxManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// GearboxType.GearboxManufacturerId - GearboxManufacturer.GearboxManufacturerId
		/// </summary>
		public virtual IEntityRelation GearboxManufacturerEntityUsingGearboxManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearboxManufacturer", false);
				relation.AddEntityFieldPair(GearboxManufacturerFields.GearboxManufacturerId, GearboxTypeFields.GearboxManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxTypeEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between GearboxTypeEntity and GearboxTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// GearboxType.ParentGearboxTypeId - GearboxType.GearboxTypeId
		/// </summary>
		public virtual IEntityRelation GearboxTypeEntityUsingGearboxTypeIdParentGearboxTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearboxType", false);
				relation.AddEntityFieldPair(GearboxTypeFields.GearboxTypeId, GearboxTypeFields.ParentGearboxTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxTypeEntity", true);
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
