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
	/// <summary>Implements the static Relations variant for the entity: ComponentInspectionReportType. </summary>
	public partial class ComponentInspectionReportTypeRelations
	{
		/// <summary>CTor</summary>
		public ComponentInspectionReportTypeRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentInspectionReportTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CirStandardTextsEntityUsingComponentInspectionReportTypeId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingComponentInspectionReportTypeId);
			toReturn.Add(this.ComponentInspectionReportTypeEntityUsingParentComponentInspectionReportTypeId);
			toReturn.Add(this.HotItemEntityUsingComponentInspectionReportTypeId);

			toReturn.Add(this.ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeIdParentComponentInspectionReportTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTypeEntity and CirStandardTextsEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReportType.ComponentInspectionReportTypeId - CirStandardTexts.ComponentInspectionReportTypeId
		/// </summary>
		public virtual IEntityRelation CirStandardTextsEntityUsingComponentInspectionReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CirStandardTexts" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportTypeFields.ComponentInspectionReportTypeId, CirStandardTextsFields.ComponentInspectionReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirStandardTextsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTypeEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReportType.ComponentInspectionReportTypeId - ComponentInspectionReport.ComponentInspectionReportTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingComponentInspectionReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportTypeFields.ComponentInspectionReportTypeId, ComponentInspectionReportFields.ComponentInspectionReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTypeEntity and ComponentInspectionReportTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReportType.ComponentInspectionReportTypeId - ComponentInspectionReportType.ParentComponentInspectionReportTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTypeEntityUsingParentComponentInspectionReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportType_" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportTypeFields.ComponentInspectionReportTypeId, ComponentInspectionReportTypeFields.ParentComponentInspectionReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTypeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTypeEntity and HotItemEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReportType.ComponentInspectionReportTypeId - HotItem.ComponentInspectionReportTypeId
		/// </summary>
		public virtual IEntityRelation HotItemEntityUsingComponentInspectionReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "HotItem" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportTypeFields.ComponentInspectionReportTypeId, HotItemFields.ComponentInspectionReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("HotItemEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTypeEntity and ComponentInspectionReportTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportType.ParentComponentInspectionReportTypeId - ComponentInspectionReportType.ComponentInspectionReportTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTypeEntityUsingComponentInspectionReportTypeIdParentComponentInspectionReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReportType", false);
				relation.AddEntityFieldPair(ComponentInspectionReportTypeFields.ComponentInspectionReportTypeId, ComponentInspectionReportTypeFields.ParentComponentInspectionReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTypeEntity", true);
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
