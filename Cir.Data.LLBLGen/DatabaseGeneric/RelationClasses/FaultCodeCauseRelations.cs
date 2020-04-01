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
	/// <summary>Implements the static Relations variant for the entity: FaultCodeCause. </summary>
	public partial class FaultCodeCauseRelations
	{
		/// <summary>CTor</summary>
		public FaultCodeCauseRelations()
		{
		}

		/// <summary>Gets all relations of the FaultCodeCauseEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportBladeEntityUsingBladeFaultCodeCauseId);
			toReturn.Add(this.FaultCodeCauseEntityUsingParentFaultCodeCauseId);

			toReturn.Add(this.FaultCodeCauseEntityUsingFaultCodeCauseIdParentFaultCodeCauseId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between FaultCodeCauseEntity and ComponentInspectionReportBladeEntity over the 1:n relation they have, using the relation between the fields:
		/// FaultCodeCause.FaultCodeCauseId - ComponentInspectionReportBlade.BladeFaultCodeCauseId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeEntityUsingBladeFaultCodeCauseId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBlade" , true);
				relation.AddEntityFieldPair(FaultCodeCauseFields.FaultCodeCauseId, ComponentInspectionReportBladeFields.BladeFaultCodeCauseId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeCauseEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between FaultCodeCauseEntity and FaultCodeCauseEntity over the 1:n relation they have, using the relation between the fields:
		/// FaultCodeCause.FaultCodeCauseId - FaultCodeCause.ParentFaultCodeCauseId
		/// </summary>
		public virtual IEntityRelation FaultCodeCauseEntityUsingParentFaultCodeCauseId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "FaultCodeCause_" , true);
				relation.AddEntityFieldPair(FaultCodeCauseFields.FaultCodeCauseId, FaultCodeCauseFields.ParentFaultCodeCauseId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeCauseEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeCauseEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between FaultCodeCauseEntity and FaultCodeCauseEntity over the m:1 relation they have, using the relation between the fields:
		/// FaultCodeCause.ParentFaultCodeCauseId - FaultCodeCause.FaultCodeCauseId
		/// </summary>
		public virtual IEntityRelation FaultCodeCauseEntityUsingFaultCodeCauseIdParentFaultCodeCauseId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "FaultCodeCause", false);
				relation.AddEntityFieldPair(FaultCodeCauseFields.FaultCodeCauseId, FaultCodeCauseFields.ParentFaultCodeCauseId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeCauseEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("FaultCodeCauseEntity", true);
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
