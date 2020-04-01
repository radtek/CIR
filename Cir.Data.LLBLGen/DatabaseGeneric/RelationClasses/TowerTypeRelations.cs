﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: TowerType. </summary>
	public partial class TowerTypeRelations
	{
		/// <summary>CTor</summary>
		public TowerTypeRelations()
		{
		}

		/// <summary>Gets all relations of the TowerTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId);
			toReturn.Add(this.TowerTypeEntityUsingParentTowerTypeId);

			toReturn.Add(this.TowerTypeEntityUsingTowerTypeIdParentTowerTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TowerTypeEntity and ComponentInspectionReportGeneralEntity over the 1:n relation they have, using the relation between the fields:
		/// TowerType.TowerTypeId - ComponentInspectionReportGeneral.GeneralTowerTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneralEntityUsingGeneralTowerTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGeneral" , true);
				relation.AddEntityFieldPair(TowerTypeFields.TowerTypeId, ComponentInspectionReportGeneralFields.GeneralTowerTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TowerTypeEntity and TowerTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// TowerType.TowerTypeId - TowerType.ParentTowerTypeId
		/// </summary>
		public virtual IEntityRelation TowerTypeEntityUsingParentTowerTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TowerType_" , true);
				relation.AddEntityFieldPair(TowerTypeFields.TowerTypeId, TowerTypeFields.ParentTowerTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerTypeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TowerTypeEntity and TowerTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// TowerType.ParentTowerTypeId - TowerType.TowerTypeId
		/// </summary>
		public virtual IEntityRelation TowerTypeEntityUsingTowerTypeIdParentTowerTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TowerType", false);
				relation.AddEntityFieldPair(TowerTypeFields.TowerTypeId, TowerTypeFields.ParentTowerTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerTypeEntity", true);
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