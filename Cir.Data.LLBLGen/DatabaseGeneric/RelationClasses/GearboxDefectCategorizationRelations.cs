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
	/// <summary>Implements the static Relations variant for the entity: GearboxDefectCategorization. </summary>
	public partial class GearboxDefectCategorizationRelations
	{
		/// <summary>CTor</summary>
		public GearboxDefectCategorizationRelations()
		{
		}

		/// <summary>Gets all relations of the GearboxDefectCategorizationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.GearboxDefectCategorizationDetailsEntityUsingGearboxDefectCategorizationId);

			toReturn.Add(this.GearboxTypeEntityUsingGearboxTypeId);
			toReturn.Add(this.OilTypeEntityUsingOilTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GearboxDefectCategorizationEntity and GearboxDefectCategorizationDetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// GearboxDefectCategorization.GearboxDefectCategorizationId - GearboxDefectCategorizationDetails.GearboxDefectCategorizationId
		/// </summary>
		public virtual IEntityRelation GearboxDefectCategorizationDetailsEntityUsingGearboxDefectCategorizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GearboxDefectCategorizationDetails" , true);
				relation.AddEntityFieldPair(GearboxDefectCategorizationFields.GearboxDefectCategorizationId, GearboxDefectCategorizationDetailsFields.GearboxDefectCategorizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxDefectCategorizationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxDefectCategorizationDetailsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between GearboxDefectCategorizationEntity and GearboxTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// GearboxDefectCategorization.GearboxTypeId - GearboxType.GearboxTypeId
		/// </summary>
		public virtual IEntityRelation GearboxTypeEntityUsingGearboxTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearboxType", false);
				relation.AddEntityFieldPair(GearboxTypeFields.GearboxTypeId, GearboxDefectCategorizationFields.GearboxTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxDefectCategorizationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between GearboxDefectCategorizationEntity and OilTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// GearboxDefectCategorization.OilTypeId - OilType.OilTypeId
		/// </summary>
		public virtual IEntityRelation OilTypeEntityUsingOilTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OilType", false);
				relation.AddEntityFieldPair(OilTypeFields.OilTypeId, GearboxDefectCategorizationFields.OilTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxDefectCategorizationEntity", true);
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
