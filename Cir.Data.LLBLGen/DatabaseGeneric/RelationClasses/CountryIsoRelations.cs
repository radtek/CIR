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
	/// <summary>Implements the static Relations variant for the entity: CountryIso. </summary>
	public partial class CountryIsoRelations
	{
		/// <summary>CTor</summary>
		public CountryIsoRelations()
		{
		}

		/// <summary>Gets all relations of the CountryIsoEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportEntityUsingCountryIsoid);
			toReturn.Add(this.CountryIsoEntityUsingParentCountryIsoid);
			toReturn.Add(this.FirstNotificationEntityUsingCountryIsoid);
			toReturn.Add(this.SbunotificationEntityUsingCountryIsoid);

			toReturn.Add(this.CountryIsoEntityUsingCountryIsoidParentCountryIsoid);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CountryIsoEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// CountryIso.CountryIsoid - ComponentInspectionReport.CountryIsoid
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingCountryIsoid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport" , true);
				relation.AddEntityFieldPair(CountryIsoFields.CountryIsoid, ComponentInspectionReportFields.CountryIsoid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CountryIsoEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CountryIsoEntity and CountryIsoEntity over the 1:n relation they have, using the relation between the fields:
		/// CountryIso.CountryIsoid - CountryIso.ParentCountryIsoid
		/// </summary>
		public virtual IEntityRelation CountryIsoEntityUsingParentCountryIsoid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CountryIso_" , true);
				relation.AddEntityFieldPair(CountryIsoFields.CountryIsoid, CountryIsoFields.ParentCountryIsoid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CountryIsoEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CountryIsoEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CountryIsoEntity and FirstNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// CountryIso.CountryIsoid - FirstNotification.CountryIsoid
		/// </summary>
		public virtual IEntityRelation FirstNotificationEntityUsingCountryIsoid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FirstNotification" , true);
				relation.AddEntityFieldPair(CountryIsoFields.CountryIsoid, FirstNotificationFields.CountryIsoid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CountryIsoEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FirstNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CountryIsoEntity and SbunotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// CountryIso.CountryIsoid - Sbunotification.CountryIsoid
		/// </summary>
		public virtual IEntityRelation SbunotificationEntityUsingCountryIsoid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Sbunotification" , true);
				relation.AddEntityFieldPair(CountryIsoFields.CountryIsoid, SbunotificationFields.CountryIsoid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CountryIsoEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SbunotificationEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between CountryIsoEntity and CountryIsoEntity over the m:1 relation they have, using the relation between the fields:
		/// CountryIso.ParentCountryIsoid - CountryIso.CountryIsoid
		/// </summary>
		public virtual IEntityRelation CountryIsoEntityUsingCountryIsoidParentCountryIsoid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CountryIso", false);
				relation.AddEntityFieldPair(CountryIsoFields.CountryIsoid, CountryIsoFields.ParentCountryIsoid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CountryIsoEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CountryIsoEntity", true);
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