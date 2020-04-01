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
	/// <summary>Implements the static Relations variant for the entity: MainBearingErrorLocation. </summary>
	public partial class MainBearingErrorLocationRelations
	{
		/// <summary>CTor</summary>
		public MainBearingErrorLocationRelations()
		{
		}

		/// <summary>Gets all relations of the MainBearingErrorLocationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId);
			toReturn.Add(this.MainBearingErrorLocationEntityUsingParentMainBearingErrorLocationId);

			toReturn.Add(this.MainBearingErrorLocationEntityUsingMainBearingErrorLocationIdParentMainBearingErrorLocationId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between MainBearingErrorLocationEntity and ComponentInspectionReportMainBearingEntity over the 1:n relation they have, using the relation between the fields:
		/// MainBearingErrorLocation.MainBearingErrorLocationId - ComponentInspectionReportMainBearing.MainBearingErrorLocationId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportMainBearingEntityUsingMainBearingErrorLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportMainBearing" , true);
				relation.AddEntityFieldPair(MainBearingErrorLocationFields.MainBearingErrorLocationId, ComponentInspectionReportMainBearingFields.MainBearingErrorLocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingErrorLocationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportMainBearingEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MainBearingErrorLocationEntity and MainBearingErrorLocationEntity over the 1:n relation they have, using the relation between the fields:
		/// MainBearingErrorLocation.MainBearingErrorLocationId - MainBearingErrorLocation.ParentMainBearingErrorLocationId
		/// </summary>
		public virtual IEntityRelation MainBearingErrorLocationEntityUsingParentMainBearingErrorLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MainBearingErrorLocation_" , true);
				relation.AddEntityFieldPair(MainBearingErrorLocationFields.MainBearingErrorLocationId, MainBearingErrorLocationFields.ParentMainBearingErrorLocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingErrorLocationEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingErrorLocationEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between MainBearingErrorLocationEntity and MainBearingErrorLocationEntity over the m:1 relation they have, using the relation between the fields:
		/// MainBearingErrorLocation.ParentMainBearingErrorLocationId - MainBearingErrorLocation.MainBearingErrorLocationId
		/// </summary>
		public virtual IEntityRelation MainBearingErrorLocationEntityUsingMainBearingErrorLocationIdParentMainBearingErrorLocationId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MainBearingErrorLocation", false);
				relation.AddEntityFieldPair(MainBearingErrorLocationFields.MainBearingErrorLocationId, MainBearingErrorLocationFields.ParentMainBearingErrorLocationId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingErrorLocationEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MainBearingErrorLocationEntity", true);
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
