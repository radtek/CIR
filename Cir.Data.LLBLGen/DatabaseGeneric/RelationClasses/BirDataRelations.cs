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
	/// <summary>Implements the static Relations variant for the entity: BirData. </summary>
	public partial class BirDataRelations
	{
		/// <summary>CTor</summary>
		public BirDataRelations()
		{
		}

		/// <summary>Gets all relations of the BirDataEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BirWordDocumentEntityUsingBirDataId);
			toReturn.Add(this.MapBirCirEntityUsingBirDataId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BirDataEntity and BirWordDocumentEntity over the 1:n relation they have, using the relation between the fields:
		/// BirData.BirDataId - BirWordDocument.BirDataId
		/// </summary>
		public virtual IEntityRelation BirWordDocumentEntityUsingBirDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BirWordDocument" , true);
				relation.AddEntityFieldPair(BirDataFields.BirDataId, BirWordDocumentFields.BirDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BirDataEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BirWordDocumentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BirDataEntity and MapBirCirEntity over the 1:n relation they have, using the relation between the fields:
		/// BirData.BirDataId - MapBirCir.BirDataId
		/// </summary>
		public virtual IEntityRelation MapBirCirEntityUsingBirDataId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MapBirCir" , true);
				relation.AddEntityFieldPair(BirDataFields.BirDataId, MapBirCirFields.BirDataId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BirDataEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MapBirCirEntity", false);
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
