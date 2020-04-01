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
	/// <summary>Implements the static Relations variant for the entity: ReportType. </summary>
	public partial class ReportTypeRelations
	{
		/// <summary>CTor</summary>
		public ReportTypeRelations()
		{
		}

		/// <summary>Gets all relations of the ReportTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportEntityUsingReportTypeId);
			toReturn.Add(this.ReportTypeEntityUsingParentReportTypeId);

			toReturn.Add(this.ReportTypeEntityUsingReportTypeIdParentReportTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ReportTypeEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// ReportType.ReportTypeId - ComponentInspectionReport.ReportTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport" , true);
				relation.AddEntityFieldPair(ReportTypeFields.ReportTypeId, ComponentInspectionReportFields.ReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ReportTypeEntity and ReportTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// ReportType.ReportTypeId - ReportType.ParentReportTypeId
		/// </summary>
		public virtual IEntityRelation ReportTypeEntityUsingParentReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ReportType_" , true);
				relation.AddEntityFieldPair(ReportTypeFields.ReportTypeId, ReportTypeFields.ParentReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ReportTypeEntity and ReportTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ReportType.ParentReportTypeId - ReportType.ReportTypeId
		/// </summary>
		public virtual IEntityRelation ReportTypeEntityUsingReportTypeIdParentReportTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ReportType", false);
				relation.AddEntityFieldPair(ReportTypeFields.ReportTypeId, ReportTypeFields.ParentReportTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ReportTypeEntity", true);
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
