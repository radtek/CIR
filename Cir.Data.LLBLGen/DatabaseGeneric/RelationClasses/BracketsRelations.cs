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
	/// <summary>Implements the static Relations variant for the entity: Brackets. </summary>
	public partial class BracketsRelations
	{
		/// <summary>CTor</summary>
		public BracketsRelations()
		{
		}

		/// <summary>Gets all relations of the BracketsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BracketsEntityUsingParentBracketsId);
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingBracketsId);

			toReturn.Add(this.BracketsEntityUsingBracketsIdParentBracketsId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BracketsEntity and BracketsEntity over the 1:n relation they have, using the relation between the fields:
		/// Brackets.BracketsId - Brackets.ParentBracketsId
		/// </summary>
		public virtual IEntityRelation BracketsEntityUsingParentBracketsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "Brackets_" , true);
				relation.AddEntityFieldPair(BracketsFields.BracketsId, BracketsFields.ParentBracketsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BracketsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BracketsEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BracketsEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// Brackets.BracketsId - ComponentInspectionReportTransformer.BracketsId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingBracketsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer" , true);
				relation.AddEntityFieldPair(BracketsFields.BracketsId, ComponentInspectionReportTransformerFields.BracketsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BracketsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between BracketsEntity and BracketsEntity over the m:1 relation they have, using the relation between the fields:
		/// Brackets.ParentBracketsId - Brackets.BracketsId
		/// </summary>
		public virtual IEntityRelation BracketsEntityUsingBracketsIdParentBracketsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Brackets", false);
				relation.AddEntityFieldPair(BracketsFields.BracketsId, BracketsFields.ParentBracketsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BracketsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BracketsEntity", true);
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
