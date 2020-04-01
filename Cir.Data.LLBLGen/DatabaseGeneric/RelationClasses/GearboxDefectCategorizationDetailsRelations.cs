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
	/// <summary>Implements the static Relations variant for the entity: GearboxDefectCategorizationDetails. </summary>
	public partial class GearboxDefectCategorizationDetailsRelations
	{
		/// <summary>CTor</summary>
		public GearboxDefectCategorizationDetailsRelations()
		{
		}

		/// <summary>Gets all relations of the GearboxDefectCategorizationDetailsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.BearingTypeEntityUsingBearingTypeId);
			toReturn.Add(this.GearboxDefectCategorizationEntityUsingGearboxDefectCategorizationId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between GearboxDefectCategorizationDetailsEntity and BearingTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// GearboxDefectCategorizationDetails.BearingTypeId - BearingType.BearingTypeId
		/// </summary>
		public virtual IEntityRelation BearingTypeEntityUsingBearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BearingType", false);
				relation.AddEntityFieldPair(BearingTypeFields.BearingTypeId, GearboxDefectCategorizationDetailsFields.BearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BearingTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxDefectCategorizationDetailsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between GearboxDefectCategorizationDetailsEntity and GearboxDefectCategorizationEntity over the m:1 relation they have, using the relation between the fields:
		/// GearboxDefectCategorizationDetails.GearboxDefectCategorizationId - GearboxDefectCategorization.GearboxDefectCategorizationId
		/// </summary>
		public virtual IEntityRelation GearboxDefectCategorizationEntityUsingGearboxDefectCategorizationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GearboxDefectCategorization", false);
				relation.AddEntityFieldPair(GearboxDefectCategorizationFields.GearboxDefectCategorizationId, GearboxDefectCategorizationDetailsFields.GearboxDefectCategorizationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxDefectCategorizationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GearboxDefectCategorizationDetailsEntity", true);
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
