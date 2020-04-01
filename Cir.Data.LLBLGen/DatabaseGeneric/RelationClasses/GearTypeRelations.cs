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
	/// <summary>Implements the static Relations variant for the entity: GearType. </summary>
	public partial class GearTypeRelations
	{
		/// <summary>CTor</summary>
		public GearTypeRelations()
		{
		}

		/// <summary>Gets all relations of the GearTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation14GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation13GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation12GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation15GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation9GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation8GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation7GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation11GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation3GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation2GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation1GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation4GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation10GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation6GearTypeId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxExactLocation5GearTypeId);
			toReturn.Add(this.GearTypeEntityUsingParentGearTypeId);

			toReturn.Add(this.GearTypeEntityUsingGearTypeIdParentGearTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation14GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation14GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__________" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation14GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation13GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation13GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_________" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation13GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation12GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation12GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox________" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation12GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation15GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation15GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___________" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation15GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation9GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation9GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox______________" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation9GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation8GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation8GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_____________" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation8GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation7GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation7GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox____________" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation7GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation11GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation11GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_______" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation11GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation3GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation3GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation3GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation2GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation2GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation2GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation1GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation1GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation1GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation4GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation4GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation4GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation10GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation10GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox______" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation10GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation6GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation6GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_____" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation6GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - ComponentInspectionReportGearbox.GearboxExactLocation5GearTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxExactLocation5GearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox____" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, ComponentInspectionReportGearboxFields.GearboxExactLocation5GearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and GearTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// GearType.GearTypeId - GearType.ParentGearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingParentGearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GearType_" , true);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, GearTypeFields.ParentGearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between GearTypeEntity and GearTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// GearType.ParentGearTypeId - GearType.GearTypeId
		/// </summary>
		public virtual IEntityRelation GearTypeEntityUsingGearTypeIdParentGearTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearType", false);
				relation.AddEntityFieldPair(GearTypeFields.GearTypeId, GearTypeFields.ParentGearTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearTypeEntity", true);
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
