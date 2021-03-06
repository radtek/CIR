﻿///////////////////////////////////////////////////////////////
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
	/// <summary>Implements the static Relations variant for the entity: TurbineRotorDiameter. </summary>
	public partial class TurbineRotorDiameterRelations
	{
		/// <summary>CTor</summary>
		public TurbineRotorDiameterRelations()
		{
		}

		/// <summary>Gets all relations of the TurbineRotorDiameterEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.TurbineMatrixEntityUsingTurbineRotorDiameterId);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TurbineRotorDiameterEntity and TurbineMatrixEntity over the 1:n relation they have, using the relation between the fields:
		/// TurbineRotorDiameter.TurbineRotorDiameterId - TurbineMatrix.TurbineRotorDiameterId
		/// </summary>
		public virtual IEntityRelation TurbineMatrixEntityUsingTurbineRotorDiameterId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TurbineMatrix" , true);
				relation.AddEntityFieldPair(TurbineRotorDiameterFields.TurbineRotorDiameterId, TurbineMatrixFields.TurbineRotorDiameterId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineRotorDiameterEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TurbineMatrixEntity", false);
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
