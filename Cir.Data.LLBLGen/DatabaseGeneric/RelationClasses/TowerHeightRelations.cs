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
	/// <summary>Implements the static Relations variant for the entity: TowerHeight. </summary>
	public partial class TowerHeightRelations
	{
		/// <summary>CTor</summary>
		public TowerHeightRelations()
		{
		}

		/// <summary>Gets all relations of the TowerHeightEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGeneralEntityUsingGeneralTowerHeightId);
			toReturn.Add(this.TowerHeightEntityUsingParentTowerHeightId);

			toReturn.Add(this.TowerHeightEntityUsingTowerHeightIdParentTowerHeightId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TowerHeightEntity and ComponentInspectionReportGeneralEntity over the 1:n relation they have, using the relation between the fields:
		/// TowerHeight.TowerHeightId - ComponentInspectionReportGeneral.GeneralTowerHeightId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneralEntityUsingGeneralTowerHeightId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGeneral" , true);
				relation.AddEntityFieldPair(TowerHeightFields.TowerHeightId, ComponentInspectionReportGeneralFields.GeneralTowerHeightId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerHeightEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TowerHeightEntity and TowerHeightEntity over the 1:n relation they have, using the relation between the fields:
		/// TowerHeight.TowerHeightId - TowerHeight.ParentTowerHeightId
		/// </summary>
		public virtual IEntityRelation TowerHeightEntityUsingParentTowerHeightId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TowerHeight_" , true);
				relation.AddEntityFieldPair(TowerHeightFields.TowerHeightId, TowerHeightFields.ParentTowerHeightId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerHeightEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerHeightEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TowerHeightEntity and TowerHeightEntity over the m:1 relation they have, using the relation between the fields:
		/// TowerHeight.ParentTowerHeightId - TowerHeight.TowerHeightId
		/// </summary>
		public virtual IEntityRelation TowerHeightEntityUsingTowerHeightIdParentTowerHeightId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TowerHeight", false);
				relation.AddEntityFieldPair(TowerHeightFields.TowerHeightId, TowerHeightFields.ParentTowerHeightId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerHeightEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TowerHeightEntity", true);
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
