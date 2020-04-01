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
	/// <summary>Implements the static Relations variant for the entity: LocationType. </summary>
	public partial class LocationTypeRelations
	{
		/// <summary>CTor</summary>
		public LocationTypeRelations()
		{
		}

		/// <summary>Gets all relations of the LocationTypeEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportEntityUsingLocationTypeId);
			toReturn.Add(this.LocationTypeEntityUsingParentLocationTypeId);

			toReturn.Add(this.LocationTypeEntityUsingLocationTypeIdParentLocationTypeId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between LocationTypeEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// LocationType.LocationTypeId - ComponentInspectionReport.LocationTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingLocationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport" , true);
				relation.AddEntityFieldPair(LocationTypeFields.LocationTypeId, ComponentInspectionReportFields.LocationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between LocationTypeEntity and LocationTypeEntity over the 1:n relation they have, using the relation between the fields:
		/// LocationType.LocationTypeId - LocationType.ParentLocationTypeId
		/// </summary>
		public virtual IEntityRelation LocationTypeEntityUsingParentLocationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "LocationType_" , true);
				relation.AddEntityFieldPair(LocationTypeFields.LocationTypeId, LocationTypeFields.ParentLocationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationTypeEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationTypeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between LocationTypeEntity and LocationTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// LocationType.ParentLocationTypeId - LocationType.LocationTypeId
		/// </summary>
		public virtual IEntityRelation LocationTypeEntityUsingLocationTypeIdParentLocationTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "LocationType", false);
				relation.AddEntityFieldPair(LocationTypeFields.LocationTypeId, LocationTypeFields.ParentLocationTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("LocationTypeEntity", true);
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
