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
	/// <summary>Implements the static Relations variant for the entity: GeneratorDefectCategorization2Details. </summary>
	public partial class GeneratorDefectCategorization2DetailsRelations
	{
		/// <summary>CTor</summary>
		public GeneratorDefectCategorization2DetailsRelations()
		{
		}

		/// <summary>Gets all relations of the GeneratorDefectCategorization2DetailsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.GeneratorComponentDamageEntityUsingGeneratorComponentDamage);
			toReturn.Add(this.GeneratorDefectCategorization2EntityUsingGeneratorDefectCategorization2Id);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between GeneratorDefectCategorization2DetailsEntity and GeneratorComponentDamageEntity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorDefectCategorization2Details.GeneratorComponentDamage - GeneratorComponentDamage.Id
		/// </summary>
		public virtual IEntityRelation GeneratorComponentDamageEntityUsingGeneratorComponentDamage
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorComponentDamage_", false);
				relation.AddEntityFieldPair(GeneratorComponentDamageFields.Id, GeneratorDefectCategorization2DetailsFields.GeneratorComponentDamage);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorComponentDamageEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorization2DetailsEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between GeneratorDefectCategorization2DetailsEntity and GeneratorDefectCategorization2Entity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorDefectCategorization2Details.GeneratorDefectCategorization2Id - GeneratorDefectCategorization2.GeneratorDefectCategorizationId
		/// </summary>
		public virtual IEntityRelation GeneratorDefectCategorization2EntityUsingGeneratorDefectCategorization2Id
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorDefectCategorization2", false);
				relation.AddEntityFieldPair(GeneratorDefectCategorization2Fields.GeneratorDefectCategorizationId, GeneratorDefectCategorization2DetailsFields.GeneratorDefectCategorization2Id);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorization2Entity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorization2DetailsEntity", true);
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
