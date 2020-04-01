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
	/// <summary>Implements the static Relations variant for the entity: BladeColor. </summary>
	public partial class BladeColorRelations
	{
		/// <summary>CTor</summary>
		public BladeColorRelations()
		{
		}

		/// <summary>Gets all relations of the BladeColorEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BladeColorEntityUsingParentBladeColorId);
			toReturn.Add(this.ComponentInspectionReportBladeEntityUsingBladeColorId);

			toReturn.Add(this.BladeColorEntityUsingBladeColorIdParentBladeColorId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BladeColorEntity and BladeColorEntity over the 1:n relation they have, using the relation between the fields:
		/// BladeColor.BladeColorId - BladeColor.ParentBladeColorId
		/// </summary>
		public virtual IEntityRelation BladeColorEntityUsingParentBladeColorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BladeColor_" , true);
				relation.AddEntityFieldPair(BladeColorFields.BladeColorId, BladeColorFields.ParentBladeColorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeColorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeColorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BladeColorEntity and ComponentInspectionReportBladeEntity over the 1:n relation they have, using the relation between the fields:
		/// BladeColor.BladeColorId - ComponentInspectionReportBlade.BladeColorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeEntityUsingBladeColorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBlade" , true);
				relation.AddEntityFieldPair(BladeColorFields.BladeColorId, ComponentInspectionReportBladeFields.BladeColorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeColorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between BladeColorEntity and BladeColorEntity over the m:1 relation they have, using the relation between the fields:
		/// BladeColor.ParentBladeColorId - BladeColor.BladeColorId
		/// </summary>
		public virtual IEntityRelation BladeColorEntityUsingBladeColorIdParentBladeColorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BladeColor", false);
				relation.AddEntityFieldPair(BladeColorFields.BladeColorId, BladeColorFields.ParentBladeColorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeColorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeColorEntity", true);
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
