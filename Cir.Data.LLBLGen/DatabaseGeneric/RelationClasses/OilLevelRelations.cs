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
	/// <summary>Implements the static Relations variant for the entity: OilLevel. </summary>
	public partial class OilLevelRelations
	{
		/// <summary>CTor</summary>
		public OilLevelRelations()
		{
		}

		/// <summary>Gets all relations of the OilLevelEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxOilLevelId);
			toReturn.Add(this.OilLevelEntityUsingParentOilLevelId);

			toReturn.Add(this.OilLevelEntityUsingOilLevelIdParentOilLevelId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OilLevelEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// OilLevel.OilLevelId - ComponentInspectionReportGearbox.GearboxOilLevelId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxOilLevelId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(OilLevelFields.OilLevelId, ComponentInspectionReportGearboxFields.GearboxOilLevelId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilLevelEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OilLevelEntity and OilLevelEntity over the 1:n relation they have, using the relation between the fields:
		/// OilLevel.OilLevelId - OilLevel.ParentOilLevelId
		/// </summary>
		public virtual IEntityRelation OilLevelEntityUsingParentOilLevelId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OilLevel_" , true);
				relation.AddEntityFieldPair(OilLevelFields.OilLevelId, OilLevelFields.ParentOilLevelId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilLevelEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilLevelEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between OilLevelEntity and OilLevelEntity over the m:1 relation they have, using the relation between the fields:
		/// OilLevel.ParentOilLevelId - OilLevel.OilLevelId
		/// </summary>
		public virtual IEntityRelation OilLevelEntityUsingOilLevelIdParentOilLevelId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OilLevel", false);
				relation.AddEntityFieldPair(OilLevelFields.OilLevelId, OilLevelFields.ParentOilLevelId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilLevelEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilLevelEntity", true);
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
