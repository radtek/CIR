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
	/// <summary>Implements the static Relations variant for the entity: GearboxRevision. </summary>
	public partial class GearboxRevisionRelations
	{
		/// <summary>CTor</summary>
		public GearboxRevisionRelations()
		{
		}

		/// <summary>Gets all relations of the GearboxRevisionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxRevisionId);
			toReturn.Add(this.GearboxRevisionEntityUsingParentGearboxRevisionId);

			toReturn.Add(this.GearboxRevisionEntityUsingGearboxRevisionIdParentGearboxRevisionId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GearboxRevisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearboxRevision.GearboxRevisionId - ComponentInspectionReportGearbox.GearboxRevisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxRevisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(GearboxRevisionFields.GearboxRevisionId, ComponentInspectionReportGearboxFields.GearboxRevisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxRevisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearboxRevisionEntity and GearboxRevisionEntity over the 1:n relation they have, using the relation between the fields:
		/// GearboxRevision.GearboxRevisionId - GearboxRevision.ParentGearboxRevisionId
		/// </summary>
		public virtual IEntityRelation GearboxRevisionEntityUsingParentGearboxRevisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GearboxRevision_" , true);
				relation.AddEntityFieldPair(GearboxRevisionFields.GearboxRevisionId, GearboxRevisionFields.ParentGearboxRevisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxRevisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxRevisionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between GearboxRevisionEntity and GearboxRevisionEntity over the m:1 relation they have, using the relation between the fields:
		/// GearboxRevision.ParentGearboxRevisionId - GearboxRevision.GearboxRevisionId
		/// </summary>
		public virtual IEntityRelation GearboxRevisionEntityUsingGearboxRevisionIdParentGearboxRevisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearboxRevision", false);
				relation.AddEntityFieldPair(GearboxRevisionFields.GearboxRevisionId, GearboxRevisionFields.ParentGearboxRevisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxRevisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxRevisionEntity", true);
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
