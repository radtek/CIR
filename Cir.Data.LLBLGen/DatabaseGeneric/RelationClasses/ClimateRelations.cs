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
	/// <summary>Implements the static Relations variant for the entity: Climate. </summary>
	public partial class ClimateRelations
	{
		/// <summary>CTor</summary>
		public ClimateRelations()
		{
		}

		/// <summary>Gets all relations of the ClimateEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ClimateEntityUsingParentClimateId);
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingClimateId);

			toReturn.Add(this.ClimateEntityUsingClimateIdParentClimateId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ClimateEntity and ClimateEntity over the 1:n relation they have, using the relation between the fields:
		/// Climate.ClimateId - Climate.ParentClimateId
		/// </summary>
		public virtual IEntityRelation ClimateEntityUsingParentClimateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Climate_" , true);
				relation.AddEntityFieldPair(ClimateFields.ClimateId, ClimateFields.ParentClimateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClimateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClimateEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ClimateEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// Climate.ClimateId - ComponentInspectionReportTransformer.ClimateId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingClimateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer" , true);
				relation.AddEntityFieldPair(ClimateFields.ClimateId, ComponentInspectionReportTransformerFields.ClimateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClimateEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ClimateEntity and ClimateEntity over the m:1 relation they have, using the relation between the fields:
		/// Climate.ParentClimateId - Climate.ClimateId
		/// </summary>
		public virtual IEntityRelation ClimateEntityUsingClimateIdParentClimateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Climate", false);
				relation.AddEntityFieldPair(ClimateFields.ClimateId, ClimateFields.ParentClimateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClimateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClimateEntity", true);
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
