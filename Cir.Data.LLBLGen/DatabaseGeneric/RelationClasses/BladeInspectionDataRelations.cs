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
	/// <summary>Implements the static Relations variant for the entity: BladeInspectionData. </summary>
	public partial class BladeInspectionDataRelations
	{
		/// <summary>CTor</summary>
		public BladeInspectionDataRelations()
		{
		}

		/// <summary>Gets all relations of the BladeInspectionDataEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BladeInspectionDataEntityUsingParentBladeInspectionDataId);
			toReturn.Add(this.ComponentInspectionReportBladeDamageEntityUsingBladeInspectionDataId);

			toReturn.Add(this.BladeInspectionDataEntityUsingBladeInspectionDataIdParentBladeInspectionDataId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BladeInspectionDataEntity and BladeInspectionDataEntity over the 1:n relation they have, using the relation between the fields:
		/// BladeInspectionData.BladeInspectionDataId - BladeInspectionData.ParentBladeInspectionDataId
		/// </summary>
		public virtual IEntityRelation BladeInspectionDataEntityUsingParentBladeInspectionDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BladeInspectionData_" , true);
				relation.AddEntityFieldPair(BladeInspectionDataFields.BladeInspectionDataId, BladeInspectionDataFields.ParentBladeInspectionDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeInspectionDataEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeInspectionDataEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BladeInspectionDataEntity and ComponentInspectionReportBladeDamageEntity over the 1:n relation they have, using the relation between the fields:
		/// BladeInspectionData.BladeInspectionDataId - ComponentInspectionReportBladeDamage.BladeInspectionDataId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeDamageEntityUsingBladeInspectionDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBladeDamage" , true);
				relation.AddEntityFieldPair(BladeInspectionDataFields.BladeInspectionDataId, ComponentInspectionReportBladeDamageFields.BladeInspectionDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeInspectionDataEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeDamageEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between BladeInspectionDataEntity and BladeInspectionDataEntity over the m:1 relation they have, using the relation between the fields:
		/// BladeInspectionData.ParentBladeInspectionDataId - BladeInspectionData.BladeInspectionDataId
		/// </summary>
		public virtual IEntityRelation BladeInspectionDataEntityUsingBladeInspectionDataIdParentBladeInspectionDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BladeInspectionData", false);
				relation.AddEntityFieldPair(BladeInspectionDataFields.BladeInspectionDataId, BladeInspectionDataFields.ParentBladeInspectionDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeInspectionDataEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeInspectionDataEntity", true);
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
