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
	/// <summary>Implements the static Relations variant for the entity: GeneratorMiscDecision. </summary>
	public partial class GeneratorMiscDecisionRelations
	{
		/// <summary>CTor</summary>
		public GeneratorMiscDecisionRelations()
		{
		}

		/// <summary>Gets all relations of the GeneratorMiscDecisionEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.GeneratorDefectCategorizationEntityUsingMiscPtsensorDecision);
			toReturn.Add(this.GeneratorDefectCategorizationEntityUsingMiscWaterDecision);
			toReturn.Add(this.GeneratorDefectCategorizationEntityUsingMiscGroundingDecision);
			toReturn.Add(this.GeneratorDefectCategorizationEntityUsingMiscBearingDecision);
			toReturn.Add(this.GeneratorDefectCategorizationEntityUsingMiscGeneratorDecision);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GeneratorMiscDecisionEntity and GeneratorDefectCategorizationEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorMiscDecision.GeneratorMiscDecisionId - GeneratorDefectCategorization.MiscPtsensorDecision
		/// </summary>
		public virtual IEntityRelation GeneratorDefectCategorizationEntityUsingMiscPtsensorDecision
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GeneratorDefectCategorization___" , true);
				relation.AddEntityFieldPair(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, GeneratorDefectCategorizationFields.MiscPtsensorDecision);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorMiscDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GeneratorMiscDecisionEntity and GeneratorDefectCategorizationEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorMiscDecision.GeneratorMiscDecisionId - GeneratorDefectCategorization.MiscWaterDecision
		/// </summary>
		public virtual IEntityRelation GeneratorDefectCategorizationEntityUsingMiscWaterDecision
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GeneratorDefectCategorization____" , true);
				relation.AddEntityFieldPair(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, GeneratorDefectCategorizationFields.MiscWaterDecision);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorMiscDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GeneratorMiscDecisionEntity and GeneratorDefectCategorizationEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorMiscDecision.GeneratorMiscDecisionId - GeneratorDefectCategorization.MiscGroundingDecision
		/// </summary>
		public virtual IEntityRelation GeneratorDefectCategorizationEntityUsingMiscGroundingDecision
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GeneratorDefectCategorization__" , true);
				relation.AddEntityFieldPair(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, GeneratorDefectCategorizationFields.MiscGroundingDecision);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorMiscDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GeneratorMiscDecisionEntity and GeneratorDefectCategorizationEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorMiscDecision.GeneratorMiscDecisionId - GeneratorDefectCategorization.MiscBearingDecision
		/// </summary>
		public virtual IEntityRelation GeneratorDefectCategorizationEntityUsingMiscBearingDecision
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GeneratorDefectCategorization" , true);
				relation.AddEntityFieldPair(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, GeneratorDefectCategorizationFields.MiscBearingDecision);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorMiscDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GeneratorMiscDecisionEntity and GeneratorDefectCategorizationEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorMiscDecision.GeneratorMiscDecisionId - GeneratorDefectCategorization.MiscGeneratorDecision
		/// </summary>
		public virtual IEntityRelation GeneratorDefectCategorizationEntityUsingMiscGeneratorDecision
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GeneratorDefectCategorization_" , true);
				relation.AddEntityFieldPair(GeneratorMiscDecisionFields.GeneratorMiscDecisionId, GeneratorDefectCategorizationFields.MiscGeneratorDecision);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorMiscDecisionEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorizationEntity", false);
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
