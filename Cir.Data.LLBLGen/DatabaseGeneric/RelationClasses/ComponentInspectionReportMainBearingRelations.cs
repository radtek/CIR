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
	/// <summary>Implements the static Relations variant for the entity: ComponentInspectionReportMainBearing. </summary>
	public partial class ComponentInspectionReportMainBearingRelations
	{
		/// <summary>CTor</summary>
		public ComponentInspectionReportMainBearingRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentInspectionReportMainBearingEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.BooleanAnswerEntityUsingMainBearingClaimRelevantBooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingComponentInspectionReportId);
			toReturn.Add(this.MainBearingErrorLocationEntityUsingMainBearingErrorLocationId);
			toReturn.Add(this.MainBearingManufacturerEntityUsingMainBearingTypeId);
			toReturn.Add(this.MainBearingManufacturerEntityUsingMainBearingManufacturerId);
			toReturn.Add(this.OilTypeEntityUsingMainBearingLubricationOilTypeId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportMainBearingEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportMainBearing.MainBearingClaimRelevantBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingMainBearingClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportMainBearingFields.MainBearingClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportMainBearingEntity and ComponentInspectionReportEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportMainBearing.ComponentInspectionReportId - ComponentInspectionReport.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReport", false);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportMainBearingFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportMainBearingEntity and MainBearingErrorLocationEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportMainBearing.MainBearingErrorLocationId - MainBearingErrorLocation.MainBearingErrorLocationId
		/// </summary>
		public virtual IEntityRelation MainBearingErrorLocationEntityUsingMainBearingErrorLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MainBearingErrorLocation", false);
				relation.AddEntityFieldPair(MainBearingErrorLocationFields.MainBearingErrorLocationId, ComponentInspectionReportMainBearingFields.MainBearingErrorLocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingErrorLocationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportMainBearingEntity and MainBearingManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportMainBearing.MainBearingTypeId - MainBearingManufacturer.MainBearingManufacturerId
		/// </summary>
		public virtual IEntityRelation MainBearingManufacturerEntityUsingMainBearingTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MainBearingManufacturer_", false);
				relation.AddEntityFieldPair(MainBearingManufacturerFields.MainBearingManufacturerId, ComponentInspectionReportMainBearingFields.MainBearingTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportMainBearingEntity and MainBearingManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportMainBearing.MainBearingManufacturerId - MainBearingManufacturer.MainBearingManufacturerId
		/// </summary>
		public virtual IEntityRelation MainBearingManufacturerEntityUsingMainBearingManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MainBearingManufacturer", false);
				relation.AddEntityFieldPair(MainBearingManufacturerFields.MainBearingManufacturerId, ComponentInspectionReportMainBearingFields.MainBearingManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportMainBearingEntity and OilTypeEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportMainBearing.MainBearingLubricationOilTypeId - OilType.OilTypeId
		/// </summary>
		public virtual IEntityRelation OilTypeEntityUsingMainBearingLubricationOilTypeId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OilType", false);
				relation.AddEntityFieldPair(OilTypeFields.OilTypeId, ComponentInspectionReportMainBearingFields.MainBearingLubricationOilTypeId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OilTypeEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", true);
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
