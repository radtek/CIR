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
	/// <summary>Implements the static Relations variant for the entity: GeneratorComponentDamage. </summary>
	public partial class GeneratorComponentDamageRelations
	{
		/// <summary>CTor</summary>
		public GeneratorComponentDamageRelations()
		{
		}

		/// <summary>Gets all relations of the GeneratorComponentDamageEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.GeneratorDefectCategorization2DetailsEntityUsingGeneratorComponentDamage);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GeneratorComponentDamageEntity and GeneratorDefectCategorization2DetailsEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorComponentDamage.Id - GeneratorDefectCategorization2Details.GeneratorComponentDamage
		/// </summary>
		public virtual IEntityRelation GeneratorDefectCategorization2DetailsEntityUsingGeneratorComponentDamage
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GeneratorDefectCategorization2Details" , true);
				relation.AddEntityFieldPair(GeneratorComponentDamageFields.Id, GeneratorDefectCategorization2DetailsFields.GeneratorComponentDamage);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorComponentDamageEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDefectCategorization2DetailsEntity", false);
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
