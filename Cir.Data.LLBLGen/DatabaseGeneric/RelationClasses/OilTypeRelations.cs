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
	/// <summary>Implements the static Relations variant for the entity: OilType. </summary>
	public partial class OilTypeRelations
	{
		/// <summary>CTor</summary>
		public OilTypeRelations()
		{
		}

		/// <summary>Gets all relations of the OilTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxOilTypeId);
			toReturn.Add(this.ComponentInspectionReportMainBearingEntityUsingMainBearingLubricationOilTypeId);
			toReturn.Add(this.GearboxDefectCategorizationEntityUsingOilTypeId);
			toReturn.Add(this.OilTypeEntityUsingParentOilTypeId);

			toReturn.Add(this.OilTypeEntityUsingOilTypeIdParentOilTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OilTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// OilType.OilTypeId - ComponentInspectionReportGearbox.GearboxOilTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxOilTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(OilTypeFields.OilTypeId, ComponentInspectionReportGearboxFields.GearboxOilTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OilTypeEntity and ComponentInspectionReportMainBearingEntity over the 1:n relation they have, using the relation between the fields:
		/// OilType.OilTypeId - ComponentInspectionReportMainBearing.MainBearingLubricationOilTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportMainBearingEntityUsingMainBearingLubricationOilTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportMainBearing" , true);
				relation.AddEntityFieldPair(OilTypeFields.OilTypeId, ComponentInspectionReportMainBearingFields.MainBearingLubricationOilTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OilTypeEntity and GearboxDefectCategorizationEntity over the 1:n relation they have, using the relation between the fields:
		/// OilType.OilTypeId - GearboxDefectCategorization.OilTypeId
		/// </summary>
		public virtual IEntityRelation GearboxDefectCategorizationEntityUsingOilTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GearboxDefectCategorization" , true);
				relation.AddEntityFieldPair(OilTypeFields.OilTypeId, GearboxDefectCategorizationFields.OilTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxDefectCategorizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OilTypeEntity and OilTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// OilType.OilTypeId - OilType.ParentOilTypeId
		/// </summary>
		public virtual IEntityRelation OilTypeEntityUsingParentOilTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OilType_" , true);
				relation.AddEntityFieldPair(OilTypeFields.OilTypeId, OilTypeFields.ParentOilTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilTypeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between OilTypeEntity and OilTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// OilType.ParentOilTypeId - OilType.OilTypeId
		/// </summary>
		public virtual IEntityRelation OilTypeEntityUsingOilTypeIdParentOilTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OilType", false);
				relation.AddEntityFieldPair(OilTypeFields.OilTypeId, OilTypeFields.ParentOilTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilTypeEntity", true);
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
