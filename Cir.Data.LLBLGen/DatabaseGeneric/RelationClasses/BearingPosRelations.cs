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
	/// <summary>Implements the static Relations variant for the entity: BearingPos. </summary>
	public partial class BearingPosRelations
	{
		/// <summary>CTor</summary>
		public BearingPosRelations()
		{
		}

		/// <summary>Gets all relations of the BearingPosEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BearingPosEntityUsingParentBearingPosId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition4BearingPosId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition5BearingPosId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition6BearingPosId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition1BearingPosId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition2BearingPosId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition3BearingPosId);

			toReturn.Add(this.BearingPosEntityUsingBearingPosIdParentBearingPosId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BearingPosEntity and BearingPosEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingPos.BearingPosId - BearingPos.ParentBearingPosId
		/// </summary>
		public virtual IEntityRelation BearingPosEntityUsingParentBearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BearingPos_" , true);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, BearingPosFields.ParentBearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingPosEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingPos.BearingPosId - ComponentInspectionReportGearbox.GearboxBearingsPosition4BearingPosId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition4BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___" , true);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition4BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingPosEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingPos.BearingPosId - ComponentInspectionReportGearbox.GearboxBearingsPosition5BearingPosId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition5BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox____" , true);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition5BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingPosEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingPos.BearingPosId - ComponentInspectionReportGearbox.GearboxBearingsPosition6BearingPosId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition6BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_____" , true);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition6BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingPosEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingPos.BearingPosId - ComponentInspectionReportGearbox.GearboxBearingsPosition1BearingPosId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition1BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition1BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingPosEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingPos.BearingPosId - ComponentInspectionReportGearbox.GearboxBearingsPosition2BearingPosId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition2BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_" , true);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition2BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingPosEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingPos.BearingPosId - ComponentInspectionReportGearbox.GearboxBearingsPosition3BearingPosId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsPosition3BearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__" , true);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, ComponentInspectionReportGearboxFields.GearboxBearingsPosition3BearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between BearingPosEntity and BearingPosEntity over the m:1 relation they have, using the relation between the fields:
		/// BearingPos.ParentBearingPosId - BearingPos.BearingPosId
		/// </summary>
		public virtual IEntityRelation BearingPosEntityUsingBearingPosIdParentBearingPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingPos", false);
				relation.AddEntityFieldPair(BearingPosFields.BearingPosId, BearingPosFields.ParentBearingPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingPosEntity", true);
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
