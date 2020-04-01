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
	/// <summary>Implements the static Relations variant for the entity: BearingError. </summary>
	public partial class BearingErrorRelations
	{
		/// <summary>CTor</summary>
		public BearingErrorRelations()
		{
		}

		/// <summary>Gets all relations of the BearingErrorEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BearingErrorEntityUsingParentBearingErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage4BearingErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage5BearingErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage6BearingErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage1BearingErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage2BearingErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage3BearingErrorId);

			toReturn.Add(this.BearingErrorEntityUsingBearingErrorIdParentBearingErrorId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BearingErrorEntity and BearingErrorEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingError.BearingErrorId - BearingError.ParentBearingErrorId
		/// </summary>
		public virtual IEntityRelation BearingErrorEntityUsingParentBearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BearingError_" , true);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, BearingErrorFields.ParentBearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingError.BearingErrorId - ComponentInspectionReportGearbox.GearboxBearingsDamage4BearingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage4BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___" , true);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage4BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingError.BearingErrorId - ComponentInspectionReportGearbox.GearboxBearingsDamage5BearingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage5BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox____" , true);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage5BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingError.BearingErrorId - ComponentInspectionReportGearbox.GearboxBearingsDamage6BearingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage6BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_____" , true);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage6BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingError.BearingErrorId - ComponentInspectionReportGearbox.GearboxBearingsDamage1BearingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage1BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage1BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingError.BearingErrorId - ComponentInspectionReportGearbox.GearboxBearingsDamage2BearingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage2BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_" , true);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage2BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingError.BearingErrorId - ComponentInspectionReportGearbox.GearboxBearingsDamage3BearingErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsDamage3BearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__" , true);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, ComponentInspectionReportGearboxFields.GearboxBearingsDamage3BearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between BearingErrorEntity and BearingErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// BearingError.ParentBearingErrorId - BearingError.BearingErrorId
		/// </summary>
		public virtual IEntityRelation BearingErrorEntityUsingBearingErrorIdParentBearingErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingError", false);
				relation.AddEntityFieldPair(BearingErrorFields.BearingErrorId, BearingErrorFields.ParentBearingErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingErrorEntity", true);
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
