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
	/// <summary>Implements the static Relations variant for the entity: DamageDecision. </summary>
	public partial class DamageDecisionRelations
	{
		/// <summary>CTor</summary>
		public DamageDecisionRelations()
		{
		}

		/// <summary>Gets all relations of the DamageDecisionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision3DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision4DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision2DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision15DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision1DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision8DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision9DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision7DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision5DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision6DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision14DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision4DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision5DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision3DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision2DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision1DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision12DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision13DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision11DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision6DamageDecisionId);
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxGearDecision10DamageDecisionId);
			toReturn.Add(this.DamageDecisionEntityUsingParentDamageDecisionId);

			toReturn.Add(this.DamageDecisionEntityUsingDamageDecisionIdParentDamageDecisionId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision3DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision3DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox______________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision3DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision4DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision4DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_______________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision4DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision2DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision2DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_____________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision2DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision15DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision15DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision15DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision1DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision1DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox____________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision1DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision8DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision8DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___________________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision8DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision9DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision9DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox____________________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision9DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision7DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision7DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__________________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision7DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision5DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision5DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox________________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision5DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision6DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision6DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_________________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision6DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision14DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision14DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision14DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxBearingDecision4DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision4DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox___" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision4DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxBearingDecision5DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision5DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox____" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision5DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxBearingDecision3DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision3DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox__" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision3DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxBearingDecision2DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision2DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision2DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxBearingDecision1DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision1DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision1DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision12DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision12DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision12DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision13DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision13DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_________" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision13DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision11DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision11DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_______" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision11DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxBearingDecision6DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxBearingDecision6DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox_____" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxBearingDecision6DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - ComponentInspectionReportGearbox.GearboxGearDecision10DamageDecisionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxGearDecision10DamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox______" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, ComponentInspectionReportGearboxFields.GearboxGearDecision10DamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and DamageDecisionEntity over the 1:n relation they have, using the relation between the fields:
		/// DamageDecision.DamageDecisionId - DamageDecision.ParentDamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingParentDamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DamageDecision_" , true);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, DamageDecisionFields.ParentDamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between DamageDecisionEntity and DamageDecisionEntity over the m:1 relation they have, using the relation between the fields:
		/// DamageDecision.ParentDamageDecisionId - DamageDecision.DamageDecisionId
		/// </summary>
		public virtual IEntityRelation DamageDecisionEntityUsingDamageDecisionIdParentDamageDecisionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DamageDecision", false);
				relation.AddEntityFieldPair(DamageDecisionFields.DamageDecisionId, DamageDecisionFields.ParentDamageDecisionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DamageDecisionEntity", true);
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
