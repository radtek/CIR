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
	/// <summary>Implements the static Relations variant for the entity: BearingType. </summary>
	public partial class BearingTypeRelations
	{
		/// <summary>CTor</summary>
		public BearingTypeRelations()
		{
		}

		/// <summary>Gets all relations of the BearingTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BearingTypeEntityUsingParentBearingTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation4BearingTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation5BearingTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation6BearingTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation1BearingTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation2BearingTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation3BearingTypeId);
			toReturn.Add(this.GearboxDefectCategorizationDetailsEntityUsingBearingTypeId);

			toReturn.Add(this.BearingTypeEntityUsingBearingTypeIdParentBearingTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BearingTypeEntity and BearingTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingType.BearingTypeId - BearingType.ParentBearingTypeId
		/// </summary>
		public virtual IEntityRelation BearingTypeEntityUsingParentBearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BearingType_" , true);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, BearingTypeFields.ParentBearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingType.BearingTypeId - ComponentInspectionReportGearbox.GearboxBearingsLocation4BearingTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation4BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___" , true);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation4BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingType.BearingTypeId - ComponentInspectionReportGearbox.GearboxBearingsLocation5BearingTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation5BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox____" , true);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation5BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingType.BearingTypeId - ComponentInspectionReportGearbox.GearboxBearingsLocation6BearingTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation6BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_____" , true);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation6BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingType.BearingTypeId - ComponentInspectionReportGearbox.GearboxBearingsLocation1BearingTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation1BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation1BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingType.BearingTypeId - ComponentInspectionReportGearbox.GearboxBearingsLocation2BearingTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation2BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_" , true);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation2BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingType.BearingTypeId - ComponentInspectionReportGearbox.GearboxBearingsLocation3BearingTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingsLocation3BearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__" , true);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, ComponentInspectionReportGearboxFields.GearboxBearingsLocation3BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BearingTypeEntity and GearboxDefectCategorizationDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// BearingType.BearingTypeId - GearboxDefectCategorizationDetails.BearingTypeId
		/// </summary>
		public virtual IEntityRelation GearboxDefectCategorizationDetailsEntityUsingBearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GearboxDefectCategorizationDetails" , true);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, GearboxDefectCategorizationDetailsFields.BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxDefectCategorizationDetailsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between BearingTypeEntity and BearingTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// BearingType.ParentBearingTypeId - BearingType.BearingTypeId
		/// </summary>
		public virtual IEntityRelation BearingTypeEntityUsingBearingTypeIdParentBearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingType", false);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, BearingTypeFields.ParentBearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", true);
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
