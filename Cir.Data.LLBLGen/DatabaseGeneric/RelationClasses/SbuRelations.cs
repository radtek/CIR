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
	/// <summary>Implements the static Relations variant for the entity: Sbu. </summary>
	public partial class SbuRelations
	{
		/// <summary>CTor</summary>
		public SbuRelations()
		{
		}

		/// <summary>Gets all relations of the SbuEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportEntityUsingSbuid);
			toReturn.Add(this.FirstNotificationEntityUsingSbuid);
			toReturn.Add(this.InvalidNotificationEntityUsingSbuid);
			toReturn.Add(this.RejectNotificationEntityUsingSbuid);
			toReturn.Add(this.SbunotificationEntityUsingSbuid);
			toReturn.Add(this.SburejectNotificationEntityUsingSbuid);
			toReturn.Add(this.SecondNotificationEntityUsingSbuid);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between SbuEntity and ComponentInspectionReportEntity over the 1:n relation they have, using the relation between the fields:
		/// Sbu.Sbuid - ComponentInspectionReport.Sbuid
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingSbuid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReport" , true);
				relation.AddEntityFieldPair(SbuFields.Sbuid, ComponentInspectionReportFields.Sbuid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SbuEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SbuEntity and FirstNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Sbu.Sbuid - FirstNotification.Sbuid
		/// </summary>
		public virtual IEntityRelation FirstNotificationEntityUsingSbuid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FirstNotification" , true);
				relation.AddEntityFieldPair(SbuFields.Sbuid, FirstNotificationFields.Sbuid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SbuEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FirstNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SbuEntity and InvalidNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Sbu.Sbuid - InvalidNotification.Sbuid
		/// </summary>
		public virtual IEntityRelation InvalidNotificationEntityUsingSbuid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "InvalidNotification" , true);
				relation.AddEntityFieldPair(SbuFields.Sbuid, InvalidNotificationFields.Sbuid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SbuEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("InvalidNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SbuEntity and RejectNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Sbu.Sbuid - RejectNotification.Sbuid
		/// </summary>
		public virtual IEntityRelation RejectNotificationEntityUsingSbuid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "RejectNotification" , true);
				relation.AddEntityFieldPair(SbuFields.Sbuid, RejectNotificationFields.Sbuid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SbuEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("RejectNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SbuEntity and SbunotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Sbu.Sbuid - Sbunotification.Sbuid
		/// </summary>
		public virtual IEntityRelation SbunotificationEntityUsingSbuid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Sbunotification" , true);
				relation.AddEntityFieldPair(SbuFields.Sbuid, SbunotificationFields.Sbuid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SbuEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SbunotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SbuEntity and SburejectNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Sbu.Sbuid - SburejectNotification.Sbuid
		/// </summary>
		public virtual IEntityRelation SburejectNotificationEntityUsingSbuid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SburejectNotification" , true);
				relation.AddEntityFieldPair(SbuFields.Sbuid, SburejectNotificationFields.Sbuid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SbuEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SburejectNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SbuEntity and SecondNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// Sbu.Sbuid - SecondNotification.Sbuid
		/// </summary>
		public virtual IEntityRelation SecondNotificationEntityUsingSbuid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SecondNotification" , true);
				relation.AddEntityFieldPair(SbuFields.Sbuid, SecondNotificationFields.Sbuid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SbuEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SecondNotificationEntity", false);
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
