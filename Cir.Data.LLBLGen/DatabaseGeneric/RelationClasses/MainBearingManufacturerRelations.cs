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
	/// <summary>Implements the static Relations variant for the entity: MainBearingManufacturer. </summary>
	public partial class MainBearingManufacturerRelations
	{
		/// <summary>CTor</summary>
		public MainBearingManufacturerRelations()
		{
		}

		/// <summary>Gets all relations of the MainBearingManufacturerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportMainBearingEntityUsingMainBearingTypeId);
			toReturn.Add(this.ComponentInspectionReportMainBearingEntityUsingMainBearingManufacturerId);
			toReturn.Add(this.MainBearingManufacturerEntityUsingParentMainBearingManufacturerId);

			toReturn.Add(this.MainBearingManufacturerEntityUsingMainBearingManufacturerIdParentMainBearingManufacturerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between MainBearingManufacturerEntity and ComponentInspectionReportMainBearingEntity over the 1:n relation they have, using the relation between the fields:
		/// MainBearingManufacturer.MainBearingManufacturerId - ComponentInspectionReportMainBearing.MainBearingTypeId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportMainBearingEntityUsingMainBearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportMainBearing_" , true);
				relation.AddEntityFieldPair(MainBearingManufacturerFields.MainBearingManufacturerId, ComponentInspectionReportMainBearingFields.MainBearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MainBearingManufacturerEntity and ComponentInspectionReportMainBearingEntity over the 1:n relation they have, using the relation between the fields:
		/// MainBearingManufacturer.MainBearingManufacturerId - ComponentInspectionReportMainBearing.MainBearingManufacturerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportMainBearingEntityUsingMainBearingManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportMainBearing" , true);
				relation.AddEntityFieldPair(MainBearingManufacturerFields.MainBearingManufacturerId, ComponentInspectionReportMainBearingFields.MainBearingManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MainBearingManufacturerEntity and MainBearingManufacturerEntity over the 1:n relation they have, using the relation between the fields:
		/// MainBearingManufacturer.MainBearingManufacturerId - MainBearingManufacturer.ParentMainBearingManufacturerId
		/// </summary>
		public virtual IEntityRelation MainBearingManufacturerEntityUsingParentMainBearingManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MainBearingManufacturer_" , true);
				relation.AddEntityFieldPair(MainBearingManufacturerFields.MainBearingManufacturerId, MainBearingManufacturerFields.ParentMainBearingManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingManufacturerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between MainBearingManufacturerEntity and MainBearingManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// MainBearingManufacturer.ParentMainBearingManufacturerId - MainBearingManufacturer.MainBearingManufacturerId
		/// </summary>
		public virtual IEntityRelation MainBearingManufacturerEntityUsingMainBearingManufacturerIdParentMainBearingManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MainBearingManufacturer", false);
				relation.AddEntityFieldPair(MainBearingManufacturerFields.MainBearingManufacturerId, MainBearingManufacturerFields.ParentMainBearingManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingManufacturerEntity", true);
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
