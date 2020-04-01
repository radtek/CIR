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
	/// <summary>Implements the static Relations variant for the entity: ServiceReportNumberType. </summary>
	public partial class ServiceReportNumberTypeRelations
	{
		/// <summary>CTor</summary>
		public ServiceReportNumberTypeRelations()
		{
		}

		/// <summary>Gets all relations of the ServiceReportNumberTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportEntityUsingServiceReportNumberTypeId);
			toReturn.Add(this.ServiceReportNumberTypeEntityUsingParentServiceReportNumberTypeId);

			toReturn.Add(this.ServiceReportNumberTypeEntityUsingServiceReportNumberTypeIdParentServiceReportNumberTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ServiceReportNumberTypeEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// ServiceReportNumberType.ServiceReportNumberTypeId - ComponentInspectionReport.ServiceReportNumberTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingServiceReportNumberTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport" , true);
				relation.AddEntityFieldPair(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, ComponentInspectionReportFields.ServiceReportNumberTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ServiceReportNumberTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ServiceReportNumberTypeEntity and ServiceReportNumberTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// ServiceReportNumberType.ServiceReportNumberTypeId - ServiceReportNumberType.ParentServiceReportNumberTypeId
		/// </summary>
		public virtual IEntityRelation ServiceReportNumberTypeEntityUsingParentServiceReportNumberTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ServiceReportNumberType_" , true);
				relation.AddEntityFieldPair(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, ServiceReportNumberTypeFields.ParentServiceReportNumberTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ServiceReportNumberTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ServiceReportNumberTypeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ServiceReportNumberTypeEntity and ServiceReportNumberTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ServiceReportNumberType.ParentServiceReportNumberTypeId - ServiceReportNumberType.ServiceReportNumberTypeId
		/// </summary>
		public virtual IEntityRelation ServiceReportNumberTypeEntityUsingServiceReportNumberTypeIdParentServiceReportNumberTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ServiceReportNumberType", false);
				relation.AddEntityFieldPair(ServiceReportNumberTypeFields.ServiceReportNumberTypeId, ServiceReportNumberTypeFields.ParentServiceReportNumberTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ServiceReportNumberTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ServiceReportNumberTypeEntity", true);
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
