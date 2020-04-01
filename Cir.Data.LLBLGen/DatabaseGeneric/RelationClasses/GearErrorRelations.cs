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
	/// <summary>Implements the static Relations variant for the entity: GearError. </summary>
	public partial class GearErrorRelations
	{
		/// <summary>CTor</summary>
		public GearErrorRelations()
		{
		}

		/// <summary>Gets all relations of the GearErrorEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage15GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage14GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage13GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage6GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage9GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage8GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage7GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage12GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage3GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage2GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage1GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage4GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage11GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage10GearErrorId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage5GearErrorId);
			toReturn.Add(this.DamageEntityUsingGearErrorId);
			toReturn.Add(this.GearErrorEntityUsingParentGearErrorId);

			toReturn.Add(this.GearErrorEntityUsingGearErrorIdParentGearErrorId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage15GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage15GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__________" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage15GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage14GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage14GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_________" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage14GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage13GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage13GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox________" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage13GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage6GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage6GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___________" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage6GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage9GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage9GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox______________" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage9GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage8GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage8GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_____________" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage8GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage7GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage7GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox____________" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage7GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage12GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage12GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_______" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage12GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage3GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage3GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage3GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage2GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage2GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage2GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage1GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage1GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage1GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage4GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage4GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage4GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage11GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage11GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox______" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage11GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage10GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage10GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_____" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage10GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - ComponentInspectionReportGearbox.GearboxTypeofDamage5GearErrorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxTypeofDamage5GearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox____" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, ComponentInspectionReportGearboxFields.GearboxTypeofDamage5GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and DamageEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - Damage.GearErrorId
		/// </summary>
		public virtual IEntityRelation DamageEntityUsingGearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Damage" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, DamageFields.GearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and GearErrorEntity over the 1:n relation they have, using the relation between the fields:
		/// GearError.GearErrorId - GearError.ParentGearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingParentGearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GearError_" , true);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, GearErrorFields.ParentGearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between GearErrorEntity and GearErrorEntity over the m:1 relation they have, using the relation between the fields:
		/// GearError.ParentGearErrorId - GearError.GearErrorId
		/// </summary>
		public virtual IEntityRelation GearErrorEntityUsingGearErrorIdParentGearErrorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearError", false);
				relation.AddEntityFieldPair(GearErrorFields.GearErrorId, GearErrorFields.ParentGearErrorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearErrorEntity", true);
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
