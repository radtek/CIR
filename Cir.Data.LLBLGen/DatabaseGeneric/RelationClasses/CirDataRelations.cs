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
	/// <summary>Implements the static Relations variant for the entity: CirData. </summary>
	public partial class CirDataRelations
	{
		/// <summary>CTor</summary>
		public CirDataRelations()
		{
		}

		/// <summary>Gets all relations of the CirDataEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.CirCommentHistoryEntityUsingCirDataId);
			toReturn.Add(this.CirMetadataEntityUsingCirDataId);
			toReturn.Add(this.CirMetadataLookupEntityUsingCirDataId);
			toReturn.Add(this.CirXmlEntityUsingCirDataId);
			toReturn.Add(this.FirstNotificationEntityUsingCirDataId);
			toReturn.Add(this.SecondNotificationEntityUsingCirDataId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between CirDataEntity and CirCommentHistoryEntity over the 1:n relation they have, using the relation between the fields:
		/// CirData.CirDataId - CirCommentHistory.CirDataId
		/// </summary>
		public virtual IEntityRelation CirCommentHistoryEntityUsingCirDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CirCommentHistory" , true);
				relation.AddEntityFieldPair(CirDataFields.CirDataId, CirCommentHistoryFields.CirDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirDataEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirCommentHistoryEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CirDataEntity and CirMetadataEntity over the 1:n relation they have, using the relation between the fields:
		/// CirData.CirDataId - CirMetadata.CirDataId
		/// </summary>
		public virtual IEntityRelation CirMetadataEntityUsingCirDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CirMetadata" , true);
				relation.AddEntityFieldPair(CirDataFields.CirDataId, CirMetadataFields.CirDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirDataEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirMetadataEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CirDataEntity and CirMetadataLookupEntity over the 1:n relation they have, using the relation between the fields:
		/// CirData.CirDataId - CirMetadataLookup.CirDataId
		/// </summary>
		public virtual IEntityRelation CirMetadataLookupEntityUsingCirDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CirMetadataLookup" , true);
				relation.AddEntityFieldPair(CirDataFields.CirDataId, CirMetadataLookupFields.CirDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirDataEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirMetadataLookupEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CirDataEntity and CirXmlEntity over the 1:n relation they have, using the relation between the fields:
		/// CirData.CirDataId - CirXml.CirDataId
		/// </summary>
		public virtual IEntityRelation CirXmlEntityUsingCirDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "CirXml" , true);
				relation.AddEntityFieldPair(CirDataFields.CirDataId, CirXmlFields.CirDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirDataEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirXmlEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CirDataEntity and FirstNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// CirData.CirDataId - FirstNotification.CirDataId
		/// </summary>
		public virtual IEntityRelation FirstNotificationEntityUsingCirDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FirstNotification" , true);
				relation.AddEntityFieldPair(CirDataFields.CirDataId, FirstNotificationFields.CirDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirDataEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FirstNotificationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between CirDataEntity and SecondNotificationEntity over the 1:n relation they have, using the relation between the fields:
		/// CirData.CirDataId - SecondNotification.CirDataId
		/// </summary>
		public virtual IEntityRelation SecondNotificationEntityUsingCirDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SecondNotification" , true);
				relation.AddEntityFieldPair(CirDataFields.CirDataId, SecondNotificationFields.CirDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CirDataEntity", true);
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
