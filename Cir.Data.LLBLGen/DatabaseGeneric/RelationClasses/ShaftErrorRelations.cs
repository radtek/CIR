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
	/// <summary>Implements the static Relations variant for the entity: ShaftError. </summary>
	public partial class ShaftErrorRelations
	{
		/// <summary>CTor</summary>
		public ShaftErrorRelations()
		{
		}

		/// <summary>Gets all relations of the ShaftErrorEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxShaftsTypeofDamage3ShaftErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxShaftsTypeofDamage4ShaftErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxShaftsTypeofDamage1ShaftErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxShaftsTypeofDamage2ShaftErrorId);
			toReturn.Add(this.ShaftErrorEntityUsingParentShaftErrorId);

			toReturn.Add(this.ShaftErrorEntityUsingShaftErrorIdParentShaftErrorId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ShaftErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// ShaftError.ShaftErrorId - ComponentInspectionReportGearbox.GearboxShaftsTypeofDamage3ShaftErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxShaftsTypeofDamage3ShaftErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__" , true);
				relation.AddEntityFieldPair(ShaftErrorFields.ShaftErrorId, ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage3ShaftErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShaftErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// ShaftError.ShaftErrorId - ComponentInspectionReportGearbox.GearboxShaftsTypeofDamage4ShaftErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxShaftsTypeofDamage4ShaftErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___" , true);
				relation.AddEntityFieldPair(ShaftErrorFields.ShaftErrorId, ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage4ShaftErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShaftErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// ShaftError.ShaftErrorId - ComponentInspectionReportGearbox.GearboxShaftsTypeofDamage1ShaftErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxShaftsTypeofDamage1ShaftErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(ShaftErrorFields.ShaftErrorId, ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage1ShaftErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShaftErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// ShaftError.ShaftErrorId - ComponentInspectionReportGearbox.GearboxShaftsTypeofDamage2ShaftErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxShaftsTypeofDamage2ShaftErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_" , true);
				relation.AddEntityFieldPair(ShaftErrorFields.ShaftErrorId, ComponentInspectionReportGearboxFields.GearboxShaftsTypeofDamage2ShaftErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ShaftErrorEntity and ShaftErrorEntity over the 1:n relation they have, using the relation between the fields:
		/// ShaftError.ShaftErrorId - ShaftError.ParentShaftErrorId
		/// </summary>
		public virtual IEntityRelation ShaftErrorEntityUsingParentShaftErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ShaftError_" , true);
				relation.AddEntityFieldPair(ShaftErrorFields.ShaftErrorId, ShaftErrorFields.ParentShaftErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ShaftErrorEntity and ShaftErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// ShaftError.ParentShaftErrorId - ShaftError.ShaftErrorId
		/// </summary>
		public virtual IEntityRelation ShaftErrorEntityUsingShaftErrorIdParentShaftErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ShaftError", false);
				relation.AddEntityFieldPair(ShaftErrorFields.ShaftErrorId, ShaftErrorFields.ParentShaftErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ShaftErrorEntity", true);
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
