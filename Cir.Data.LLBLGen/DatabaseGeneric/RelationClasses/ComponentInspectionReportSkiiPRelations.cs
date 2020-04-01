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
	/// <summary>Implements the static Relations variant for the entity: ComponentInspectionReportSkiiP. </summary>
	public partial class ComponentInspectionReportSkiiPRelations
	{
		/// <summary>CTor</summary>
		public ComponentInspectionReportSkiiPRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentInspectionReportSkiiPEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportSkiiPfailedComponentEntityUsingComponentInspectionReportSkiiPid);
			toReturn.Add(this.ComponentInspectionReportSkiiPnewComponentEntityUsingComponentInspectionReportSkiiPid);

			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP3Mwv521BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP3Mwv522BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP2Mwv526BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP2Mwv524BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP2Mwv525BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP3Mwv525xBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP3Mwv526xBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP2Mwv522BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP3Mwv523BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP3Mwv524xBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP3Mwv525yBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP3Mwv526yBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP3Mwv524yBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP2Mwv521BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiPclaimRelevantBooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP2Mwv523BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP850Kwv525BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP850Kwv526BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP850Kwv520BooleanAnswerId);
			toReturn.Add(this.BooleanAnswerEntityUsingSkiiP850Kwv524BooleanAnswerId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingComponentInspectionReportId);
			toReturn.Add(this.SkiipackFailureCauseEntityUsingSkiiPcauseId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and ComponentInspectionReportSkiiPfailedComponentEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.ComponentInspectionReportSkiiPid - ComponentInspectionReportSkiiPfailedComponent.ComponentInspectionReportSkiiPid
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPfailedComponentEntityUsingComponentInspectionReportSkiiPid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiPfailedComponent" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportSkiiPFields.ComponentInspectionReportSkiiPid, ComponentInspectionReportSkiiPfailedComponentFields.ComponentInspectionReportSkiiPid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPfailedComponentEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and ComponentInspectionReportSkiiPnewComponentEntity over the 1:n relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.ComponentInspectionReportSkiiPid - ComponentInspectionReportSkiiPnewComponent.ComponentInspectionReportSkiiPid
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportSkiiPnewComponentEntityUsingComponentInspectionReportSkiiPid
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportSkiiPnewComponent" , true);
				relation.AddEntityFieldPair(ComponentInspectionReportSkiiPFields.ComponentInspectionReportSkiiPid, ComponentInspectionReportSkiiPnewComponentFields.ComponentInspectionReportSkiiPid);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPnewComponentEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP3Mwv521BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP3Mwv521BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer_____________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv521BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP3Mwv522BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP3Mwv522BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer______________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv522BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP2Mwv526BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP2Mwv526BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer____________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv526BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP2Mwv524BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP2Mwv524BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer__________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv524BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP2Mwv525BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP2Mwv525BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer___________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv525BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP3Mwv525xBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP3Mwv525xBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer__________________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv525xBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP3Mwv526xBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP3Mwv526xBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer___________________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv526xBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP2Mwv522BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP2Mwv522BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer_________________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv522BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP3Mwv523BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP3Mwv523BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer_______________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv523BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP3Mwv524xBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP3Mwv524xBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer________________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv524xBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP3Mwv525yBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP3Mwv525yBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer___", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv525yBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP3Mwv526yBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP3Mwv526yBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer____", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv526yBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP3Mwv524yBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP3Mwv524yBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer__", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP3Mwv524yBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP2Mwv521BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP2Mwv521BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv521BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiPclaimRelevantBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiPclaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer_", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiPclaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP2Mwv523BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP2Mwv523BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer_________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP2Mwv523BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP850Kwv525BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP850Kwv525BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer_______", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP850Kwv525BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP850Kwv526BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP850Kwv526BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer________", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP850Kwv526BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP850Kwv520BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP850Kwv520BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer_____", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP850Kwv520BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiP850Kwv524BooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingSkiiP850Kwv524BooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer______", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportSkiiPFields.SkiiP850Kwv524BooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and ComponentInspectionReportEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.ComponentInspectionReportId - ComponentInspectionReport.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReport", false);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportSkiiPFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportSkiiPEntity and SkiipackFailureCauseEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportSkiiP.SkiiPcauseId - SkiipackFailureCause.SkiipackFailureCauseId
		/// </summary>
		public virtual IEntityRelation SkiipackFailureCauseEntityUsingSkiiPcauseId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SkiipackFailureCause", false);
				relation.AddEntityFieldPair(SkiipackFailureCauseFields.SkiipackFailureCauseId, ComponentInspectionReportSkiiPFields.SkiiPcauseId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SkiipackFailureCauseEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportSkiiPEntity", true);
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
