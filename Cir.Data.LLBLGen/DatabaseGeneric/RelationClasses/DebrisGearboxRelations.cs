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
	/// <summary>Implements the static Relations variant for the entity: DebrisGearbox. </summary>
	public partial class DebrisGearboxRelations
	{
		/// <summary>CTor</summary>
		public DebrisGearboxRelations()
		{
		}

		/// <summary>Gets all relations of the DebrisGearboxEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxDebrisGearBoxId);
			toReturn.Add(this.DebrisGearboxEntityUsingParentDebrisGearboxId);

			toReturn.Add(this.DebrisGearboxEntityUsingDebrisGearboxIdParentDebrisGearboxId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between DebrisGearboxEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DebrisGearbox.DebrisGearboxId - ComponentInspectionReportGearbox.GearboxDebrisGearBoxId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxDebrisGearBoxId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(DebrisGearboxFields.DebrisGearboxId, ComponentInspectionReportGearboxFields.GearboxDebrisGearBoxId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisGearboxEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DebrisGearboxEntity and DebrisGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DebrisGearbox.DebrisGearboxId - DebrisGearbox.ParentDebrisGearboxId
		/// </summary>
		public virtual IEntityRelation DebrisGearboxEntityUsingParentDebrisGearboxId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DebrisGearbox_" , true);
				relation.AddEntityFieldPair(DebrisGearboxFields.DebrisGearboxId, DebrisGearboxFields.ParentDebrisGearboxId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisGearboxEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisGearboxEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between DebrisGearboxEntity and DebrisGearboxEntity over the m:1 relation they have, using the relation between the fields:
		/// DebrisGearbox.ParentDebrisGearboxId - DebrisGearbox.DebrisGearboxId
		/// </summary>
		public virtual IEntityRelation DebrisGearboxEntityUsingDebrisGearboxIdParentDebrisGearboxId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DebrisGearbox", false);
				relation.AddEntityFieldPair(DebrisGearboxFields.DebrisGearboxId, DebrisGearboxFields.ParentDebrisGearboxId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisGearboxEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisGearboxEntity", true);
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
