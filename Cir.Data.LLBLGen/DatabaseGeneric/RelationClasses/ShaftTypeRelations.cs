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
	/// <summary>Implements the static Relations variant for the entity: ShaftType. </summary>
	public partial class ShaftTypeRelations
	{
		/// <summary>CTor</summary>
		public ShaftTypeRelations()
		{
		}

		/// <summary>Gets all relations of the ShaftTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxShaftsExactLocation3ShaftTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxShaftsExactLocation4ShaftTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxShaftsExactLocation1ShaftTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxShaftsExactLocation2ShaftTypeId);
			toReturn.Add(this.ShaftTypeEntityUsingParentShaftTypeId);

			toReturn.Add(this.ShaftTypeEntityUsingShaftTypeIdParentShaftTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ShaftTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// ShaftType.ShaftTypeId - ComponentInspectionReportGearbox.GearboxShaftsExactLocation3ShaftTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxShaftsExactLocation3ShaftTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__" , true);
				relation.AddEntityFieldPair(ShaftTypeFields.ShaftTypeId, ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation3ShaftTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShaftTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// ShaftType.ShaftTypeId - ComponentInspectionReportGearbox.GearboxShaftsExactLocation4ShaftTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxShaftsExactLocation4ShaftTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___" , true);
				relation.AddEntityFieldPair(ShaftTypeFields.ShaftTypeId, ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation4ShaftTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShaftTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// ShaftType.ShaftTypeId - ComponentInspectionReportGearbox.GearboxShaftsExactLocation1ShaftTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxShaftsExactLocation1ShaftTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(ShaftTypeFields.ShaftTypeId, ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation1ShaftTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShaftTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// ShaftType.ShaftTypeId - ComponentInspectionReportGearbox.GearboxShaftsExactLocation2ShaftTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxShaftsExactLocation2ShaftTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_" , true);
				relation.AddEntityFieldPair(ShaftTypeFields.ShaftTypeId, ComponentInspectionReportGearboxFields.GearboxShaftsExactLocation2ShaftTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShaftTypeEntity and ShaftTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// ShaftType.ShaftTypeId - ShaftType.ParentShaftTypeId
		/// </summary>
		public virtual IEntityRelation ShaftTypeEntityUsingParentShaftTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShaftType_" , true);
				relation.AddEntityFieldPair(ShaftTypeFields.ShaftTypeId, ShaftTypeFields.ParentShaftTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ShaftTypeEntity and ShaftTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ShaftType.ParentShaftTypeId - ShaftType.ShaftTypeId
		/// </summary>
		public virtual IEntityRelation ShaftTypeEntityUsingShaftTypeIdParentShaftTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShaftType", false);
				relation.AddEntityFieldPair(ShaftTypeFields.ShaftTypeId, ShaftTypeFields.ParentShaftTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftTypeEntity", true);
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
