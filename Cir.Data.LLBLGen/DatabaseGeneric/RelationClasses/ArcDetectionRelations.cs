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
	/// <summary>Implements the static Relations variant for the entity: ArcDetection. </summary>
	public partial class ArcDetectionRelations
	{
		/// <summary>CTor</summary>
		public ArcDetectionRelations()
		{
		}

		/// <summary>Gets all relations of the ArcDetectionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ArcDetectionEntityUsingParentArcDetectionId);
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingTransformerArcDetectionId);

			toReturn.Add(this.ArcDetectionEntityUsingArcDetectionIdParentArcDetectionId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ArcDetectionEntity and ArcDetectionEntity over the 1:n relation they have, using the relation between the fields:
		/// ArcDetection.ArcDetectionId - ArcDetection.ParentArcDetectionId
		/// </summary>
		public virtual IEntityRelation ArcDetectionEntityUsingParentArcDetectionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ArcDetection_" , true);
				relation.AddEntityFieldPair(ArcDetectionFields.ArcDetectionId, ArcDetectionFields.ParentArcDetectionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArcDetectionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArcDetectionEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ArcDetectionEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// ArcDetection.ArcDetectionId - ComponentInspectionReportTransformer.TransformerArcDetectionId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingTransformerArcDetectionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer" , true);
				relation.AddEntityFieldPair(ArcDetectionFields.ArcDetectionId, ComponentInspectionReportTransformerFields.TransformerArcDetectionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArcDetectionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ArcDetectionEntity and ArcDetectionEntity over the m:1 relation they have, using the relation between the fields:
		/// ArcDetection.ParentArcDetectionId - ArcDetection.ArcDetectionId
		/// </summary>
		public virtual IEntityRelation ArcDetectionEntityUsingArcDetectionIdParentArcDetectionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ArcDetection", false);
				relation.AddEntityFieldPair(ArcDetectionFields.ArcDetectionId, ArcDetectionFields.ParentArcDetectionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArcDetectionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArcDetectionEntity", true);
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
