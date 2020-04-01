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
	/// <summary>Implements the static Relations variant for the entity: ComponentInspectionReportSkiiPnewComponent. </summary>
	public partial class ComponentInspectionReportSkiiPnewComponentRelations
	{
		/// <summary>CTor</summary>
		public ComponentInspectionReportSkiiPnewComponentRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentInspectionReportSkiiPnewComponentEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingComponentInspectionReportSkiiPid);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPnewComponentEntity and ComponentInspectionReportSkiiPEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiPnewComponent.ComponentInspectionReportSkiiPid - ComponentInspectionReportSkiiP.ComponentInspectionReportSkiiPid
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingComponentInspectionReportSkiiPid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReportSkiiP", false);
				relation.AddEntityFieldPair(ComponentInspectionReportSkiiPFields.ComponentInspectionReportSkiiPid, ComponentInspectionReportSkiiPnewComponentFields.ComponentInspectionReportSkiiPid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPnewComponentEntity", true);
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
