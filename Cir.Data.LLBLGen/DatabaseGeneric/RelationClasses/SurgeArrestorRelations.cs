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
	/// <summary>Implements the static Relations variant for the entity: SurgeArrestor. </summary>
	public partial class SurgeArrestorRelations
	{
		/// <summary>CTor</summary>
		public SurgeArrestorRelations()
		{
		}

		/// <summary>Gets all relations of the SurgeArrestorEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingSurgeArrestorId);
			toReturn.Add(this.SurgeArrestorEntityUsingParentSurgeArrestorId);

			toReturn.Add(this.SurgeArrestorEntityUsingSurgeArrestorIdParentSurgeArrestorId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between SurgeArrestorEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// SurgeArrestor.SurgeArrestorId - ComponentInspectionReportTransformer.SurgeArrestorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingSurgeArrestorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer" , true);
				relation.AddEntityFieldPair(SurgeArrestorFields.SurgeArrestorId, ComponentInspectionReportTransformerFields.SurgeArrestorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurgeArrestorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SurgeArrestorEntity and SurgeArrestorEntity over the 1:n relation they have, using the relation between the fields:
		/// SurgeArrestor.SurgeArrestorId - SurgeArrestor.ParentSurgeArrestorId
		/// </summary>
		public virtual IEntityRelation SurgeArrestorEntityUsingParentSurgeArrestorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SurgeArrestor_" , true);
				relation.AddEntityFieldPair(SurgeArrestorFields.SurgeArrestorId, SurgeArrestorFields.ParentSurgeArrestorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurgeArrestorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurgeArrestorEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between SurgeArrestorEntity and SurgeArrestorEntity over the m:1 relation they have, using the relation between the fields:
		/// SurgeArrestor.ParentSurgeArrestorId - SurgeArrestor.SurgeArrestorId
		/// </summary>
		public virtual IEntityRelation SurgeArrestorEntityUsingSurgeArrestorIdParentSurgeArrestorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SurgeArrestor", false);
				relation.AddEntityFieldPair(SurgeArrestorFields.SurgeArrestorId, SurgeArrestorFields.ParentSurgeArrestorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurgeArrestorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurgeArrestorEntity", true);
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
