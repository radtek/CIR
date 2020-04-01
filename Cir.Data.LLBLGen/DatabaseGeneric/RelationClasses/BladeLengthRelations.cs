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
	/// <summary>Implements the static Relations variant for the entity: BladeLength. </summary>
	public partial class BladeLengthRelations
	{
		/// <summary>CTor</summary>
		public BladeLengthRelations()
		{
		}

		/// <summary>Gets all relations of the BladeLengthEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.BladeLengthEntityUsingParentBladeLengthId);
			toReturn.Add(this.ComponentInspectionReportBladeEntityUsingBladeLengthId);

			toReturn.Add(this.BladeLengthEntityUsingBladeLengthIdParentBladeLengthId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between BladeLengthEntity and BladeLengthEntity over the 1:n relation they have, using the relation between the fields:
		/// BladeLength.BladeLengthId - BladeLength.ParentBladeLengthId
		/// </summary>
		public virtual IEntityRelation BladeLengthEntityUsingParentBladeLengthId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "BladeLength_" , true);
				relation.AddEntityFieldPair(BladeLengthFields.BladeLengthId, BladeLengthFields.ParentBladeLengthId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeLengthEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeLengthEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between BladeLengthEntity and ComponentInspectionReportBladeEntity over the 1:n relation they have, using the relation between the fields:
		/// BladeLength.BladeLengthId - ComponentInspectionReportBlade.BladeLengthId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportBladeEntityUsingBladeLengthId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportBlade" , true);
				relation.AddEntityFieldPair(BladeLengthFields.BladeLengthId, ComponentInspectionReportBladeFields.BladeLengthId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeLengthEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportBladeEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between BladeLengthEntity and BladeLengthEntity over the m:1 relation they have, using the relation between the fields:
		/// BladeLength.ParentBladeLengthId - BladeLength.BladeLengthId
		/// </summary>
		public virtual IEntityRelation BladeLengthEntityUsingBladeLengthIdParentBladeLengthId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BladeLength", false);
				relation.AddEntityFieldPair(BladeLengthFields.BladeLengthId, BladeLengthFields.ParentBladeLengthId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeLengthEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BladeLengthEntity", true);
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
