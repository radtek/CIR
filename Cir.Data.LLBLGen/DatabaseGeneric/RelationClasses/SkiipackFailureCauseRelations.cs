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
	/// <summary>Implements the static Relations variant for the entity: SkiipackFailureCause. </summary>
	public partial class SkiipackFailureCauseRelations
	{
		/// <summary>CTor</summary>
		public SkiipackFailureCauseRelations()
		{
		}

		/// <summary>Gets all relations of the SkiipackFailureCauseEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId);
			toReturn.Add(this.SkiipackFailureCauseEntityUsingParentSkiipackFailureCauseId);

			toReturn.Add(this.SkiipackFailureCauseEntityUsingSkiipackFailureCauseIdParentSkiipackFailureCauseId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between SkiipackFailureCauseEntity and ComponentInspectionReportSkiiPEntity over the 1:n relation they have, using the relation between the fields:
		/// SkiipackFailureCause.SkiipackFailureCauseId - ComponentInspectionReportSkiiP.SkiiPcauseId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiP" , true);
				relation.AddEntityFieldPair(SkiipackFailureCauseFields.SkiipackFailureCauseId, ComponentInspectionReportSkiiPFields.SkiiPcauseId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SkiipackFailureCauseEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SkiipackFailureCauseEntity and SkiipackFailureCauseEntity over the 1:n relation they have, using the relation between the fields:
		/// SkiipackFailureCause.SkiipackFailureCauseId - SkiipackFailureCause.ParentSkiipackFailureCauseId
		/// </summary>
		public virtual IEntityRelation SkiipackFailureCauseEntityUsingParentSkiipackFailureCauseId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SkiipackFailureCause_" , true);
				relation.AddEntityFieldPair(SkiipackFailureCauseFields.SkiipackFailureCauseId, SkiipackFailureCauseFields.ParentSkiipackFailureCauseId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SkiipackFailureCauseEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SkiipackFailureCauseEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between SkiipackFailureCauseEntity and SkiipackFailureCauseEntity over the m:1 relation they have, using the relation between the fields:
		/// SkiipackFailureCause.ParentSkiipackFailureCauseId - SkiipackFailureCause.SkiipackFailureCauseId
		/// </summary>
		public virtual IEntityRelation SkiipackFailureCauseEntityUsingSkiipackFailureCauseIdParentSkiipackFailureCauseId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SkiipackFailureCause", false);
				relation.AddEntityFieldPair(SkiipackFailureCauseFields.SkiipackFailureCauseId, SkiipackFailureCauseFields.ParentSkiipackFailureCauseId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SkiipackFailureCauseEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SkiipackFailureCauseEntity", true);
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
