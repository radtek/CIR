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
	/// <summary>Implements the static Relations variant for the entity: FilterBlockType. </summary>
	public partial class FilterBlockTypeRelations
	{
		/// <summary>CTor</summary>
		public FilterBlockTypeRelations()
		{
		}

		/// <summary>Gets all relations of the FilterBlockTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxFilterBlockTypeId);
			toReturn.Add(this.FilterBlockTypeEntityUsingParentFilterBlockTypeId);

			toReturn.Add(this.FilterBlockTypeEntityUsingFilterBlockTypeIdParentFilterBlockTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between FilterBlockTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// FilterBlockType.FilterBlockTypeId - ComponentInspectionReportGearbox.GearboxFilterBlockTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxFilterBlockTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(FilterBlockTypeFields.FilterBlockTypeId, ComponentInspectionReportGearboxFields.GearboxFilterBlockTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FilterBlockTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FilterBlockTypeEntity and FilterBlockTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// FilterBlockType.FilterBlockTypeId - FilterBlockType.ParentFilterBlockTypeId
		/// </summary>
		public virtual IEntityRelation FilterBlockTypeEntityUsingParentFilterBlockTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FilterBlockType_" , true);
				relation.AddEntityFieldPair(FilterBlockTypeFields.FilterBlockTypeId, FilterBlockTypeFields.ParentFilterBlockTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FilterBlockTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FilterBlockTypeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between FilterBlockTypeEntity and FilterBlockTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// FilterBlockType.ParentFilterBlockTypeId - FilterBlockType.FilterBlockTypeId
		/// </summary>
		public virtual IEntityRelation FilterBlockTypeEntityUsingFilterBlockTypeIdParentFilterBlockTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FilterBlockType", false);
				relation.AddEntityFieldPair(FilterBlockTypeFields.FilterBlockTypeId, FilterBlockTypeFields.ParentFilterBlockTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FilterBlockTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FilterBlockTypeEntity", true);
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
