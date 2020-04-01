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
	/// <summary>Implements the static Relations variant for the entity: FirstNotification. </summary>
	public partial class FirstNotificationRelations
	{
		/// <summary>CTor</summary>
		public FirstNotificationRelations()
		{
		}

		/// <summary>Gets all relations of the FirstNotificationEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.CirDataEntityUsingCirDataId);
			toReturn.Add(this.CountryIsoEntityUsingCountryIsoid);
			toReturn.Add(this.SbuEntityUsingSbuid);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between FirstNotificationEntity and CirDataEntity over the m:1 relation they have, using the relation between the fields:
		/// FirstNotification.CirDataId - CirData.CirDataId
		/// </summary>
		public virtual IEntityRelation CirDataEntityUsingCirDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CirData", false);
				relation.AddEntityFieldPair(CirDataFields.CirDataId, FirstNotificationFields.CirDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirDataEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FirstNotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between FirstNotificationEntity and CountryIsoEntity over the m:1 relation they have, using the relation between the fields:
		/// FirstNotification.CountryIsoid - CountryIso.CountryIsoid
		/// </summary>
		public virtual IEntityRelation CountryIsoEntityUsingCountryIsoid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CountryIso", false);
				relation.AddEntityFieldPair(CountryIsoFields.CountryIsoid, FirstNotificationFields.CountryIsoid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CountryIsoEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FirstNotificationEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between FirstNotificationEntity and SbuEntity over the m:1 relation they have, using the relation between the fields:
		/// FirstNotification.Sbuid - Sbu.Sbuid
		/// </summary>
		public virtual IEntityRelation SbuEntityUsingSbuid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Sbu", false);
				relation.AddEntityFieldPair(SbuFields.Sbuid, FirstNotificationFields.Sbuid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SbuEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FirstNotificationEntity", true);
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
