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
	/// <summary>Implements the static Relations variant for the entity: Vibrations. </summary>
	public partial class VibrationsRelations
	{
		/// <summary>CTor</summary>
		public VibrationsRelations()
		{
		}

		/// <summary>Gets all relations of the VibrationsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxVibrationsId);
			toReturn.Add(this.VibrationsEntityUsingParentVibrationsId);

			toReturn.Add(this.VibrationsEntityUsingVibrationsIdParentVibrationsId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between VibrationsEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// Vibrations.VibrationsId - ComponentInspectionReportGearbox.GearboxVibrationsId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxVibrationsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(VibrationsFields.VibrationsId, ComponentInspectionReportGearboxFields.GearboxVibrationsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("VibrationsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between VibrationsEntity and VibrationsEntity over the 1:n relation they have, using the relation between the fields:
		/// Vibrations.VibrationsId - Vibrations.ParentVibrationsId
		/// </summary>
		public virtual IEntityRelation VibrationsEntityUsingParentVibrationsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Vibrations_" , true);
				relation.AddEntityFieldPair(VibrationsFields.VibrationsId, VibrationsFields.ParentVibrationsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("VibrationsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("VibrationsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between VibrationsEntity and VibrationsEntity over the m:1 relation they have, using the relation between the fields:
		/// Vibrations.ParentVibrationsId - Vibrations.VibrationsId
		/// </summary>
		public virtual IEntityRelation VibrationsEntityUsingVibrationsIdParentVibrationsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Vibrations", false);
				relation.AddEntityFieldPair(VibrationsFields.VibrationsId, VibrationsFields.ParentVibrationsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("VibrationsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("VibrationsEntity", true);
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
