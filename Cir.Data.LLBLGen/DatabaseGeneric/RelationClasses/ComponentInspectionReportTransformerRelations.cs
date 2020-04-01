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
	/// <summary>Implements the static Relations variant for the entity: ComponentInspectionReportTransformer. </summary>
	public partial class ComponentInspectionReportTransformerRelations
	{
		/// <summary>CTor</summary>
		public ComponentInspectionReportTransformerRelations()
		{
		}

		/// <summary>Gets all relations of the ComponentInspectionReportTransformerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();


			toReturn.Add(this.ActionOnTransformerEntityUsingActionOnTransformerId);
			toReturn.Add(this.ArcDetectionEntityUsingTransformerArcDetectionId);
			toReturn.Add(this.BooleanAnswerEntityUsingTransformerClaimRelevantBooleanAnswerId);
			toReturn.Add(this.BracketsEntityUsingBracketsId);
			toReturn.Add(this.CableConditionEntityUsingLvcableConditionId);
			toReturn.Add(this.CableConditionEntityUsingHvcableConditionId);
			toReturn.Add(this.ClimateEntityUsingClimateId);
			toReturn.Add(this.CoilConditionEntityUsingLvcoilConditionId);
			toReturn.Add(this.CoilConditionEntityUsingHvcoilConditionId);
			toReturn.Add(this.ComponentInspectionReportEntityUsingComponentInspectionReportId);
			toReturn.Add(this.ConnectionBarsEntityUsingConnectionBarsId);
			toReturn.Add(this.SurgeArrestorEntityUsingSurgeArrestorId);
			toReturn.Add(this.TransformerManufacturerEntityUsingTransformerManufacturerId);
			return toReturn;
		}

		#region Class Property Declarations



		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and ActionOnTransformerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.ActionOnTransformerId - ActionOnTransformer.ActionOnTransformerId
		/// </summary>
		public virtual IEntityRelation ActionOnTransformerEntityUsingActionOnTransformerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ActionOnTransformer", false);
				relation.AddEntityFieldPair(ActionOnTransformerFields.ActionOnTransformerId, ComponentInspectionReportTransformerFields.ActionOnTransformerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ActionOnTransformerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and ArcDetectionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.TransformerArcDetectionId - ArcDetection.ArcDetectionId
		/// </summary>
		public virtual IEntityRelation ArcDetectionEntityUsingTransformerArcDetectionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ArcDetection", false);
				relation.AddEntityFieldPair(ArcDetectionFields.ArcDetectionId, ComponentInspectionReportTransformerFields.TransformerArcDetectionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ArcDetectionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and BooleanAnswerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.TransformerClaimRelevantBooleanAnswerId - BooleanAnswer.BooleanAnswerId
		/// </summary>
		public virtual IEntityRelation BooleanAnswerEntityUsingTransformerClaimRelevantBooleanAnswerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "BooleanAnswer", false);
				relation.AddEntityFieldPair(BooleanAnswerFields.BooleanAnswerId, ComponentInspectionReportTransformerFields.TransformerClaimRelevantBooleanAnswerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BooleanAnswerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and BracketsEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.BracketsId - Brackets.BracketsId
		/// </summary>
		public virtual IEntityRelation BracketsEntityUsingBracketsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Brackets", false);
				relation.AddEntityFieldPair(BracketsFields.BracketsId, ComponentInspectionReportTransformerFields.BracketsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("BracketsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and CableConditionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.LvcableConditionId - CableCondition.CableConditionId
		/// </summary>
		public virtual IEntityRelation CableConditionEntityUsingLvcableConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CableCondition_", false);
				relation.AddEntityFieldPair(CableConditionFields.CableConditionId, ComponentInspectionReportTransformerFields.LvcableConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CableConditionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and CableConditionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.HvcableConditionId - CableCondition.CableConditionId
		/// </summary>
		public virtual IEntityRelation CableConditionEntityUsingHvcableConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CableCondition", false);
				relation.AddEntityFieldPair(CableConditionFields.CableConditionId, ComponentInspectionReportTransformerFields.HvcableConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CableConditionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and ClimateEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.ClimateId - Climate.ClimateId
		/// </summary>
		public virtual IEntityRelation ClimateEntityUsingClimateId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "Climate", false);
				relation.AddEntityFieldPair(ClimateFields.ClimateId, ComponentInspectionReportTransformerFields.ClimateId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ClimateEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and CoilConditionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.LvcoilConditionId - CoilCondition.CoilConditionId
		/// </summary>
		public virtual IEntityRelation CoilConditionEntityUsingLvcoilConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CoilCondition_", false);
				relation.AddEntityFieldPair(CoilConditionFields.CoilConditionId, ComponentInspectionReportTransformerFields.LvcoilConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CoilConditionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and CoilConditionEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.HvcoilConditionId - CoilCondition.CoilConditionId
		/// </summary>
		public virtual IEntityRelation CoilConditionEntityUsingHvcoilConditionId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "CoilCondition", false);
				relation.AddEntityFieldPair(CoilConditionFields.CoilConditionId, ComponentInspectionReportTransformerFields.HvcoilConditionId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("CoilConditionEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and ComponentInspectionReportEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.ComponentInspectionReportId - ComponentInspectionReport.ComponentInspectionReportId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportEntityUsingComponentInspectionReportId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ComponentInspectionReport", false);
				relation.AddEntityFieldPair(ComponentInspectionReportFields.ComponentInspectionReportId, ComponentInspectionReportTransformerFields.ComponentInspectionReportId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and ConnectionBarsEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.ConnectionBarsId - ConnectionBars.ConnectionBarsId
		/// </summary>
		public virtual IEntityRelation ConnectionBarsEntityUsingConnectionBarsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ConnectionBars", false);
				relation.AddEntityFieldPair(ConnectionBarsFields.ConnectionBarsId, ComponentInspectionReportTransformerFields.ConnectionBarsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConnectionBarsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and SurgeArrestorEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.SurgeArrestorId - SurgeArrestor.SurgeArrestorId
		/// </summary>
		public virtual IEntityRelation SurgeArrestorEntityUsingSurgeArrestorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "SurgeArrestor", false);
				relation.AddEntityFieldPair(SurgeArrestorFields.SurgeArrestorId, ComponentInspectionReportTransformerFields.SurgeArrestorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SurgeArrestorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
				return relation;
			}
		}
		/// <summary>Returns a new IEntityRelation object, between ComponentInspectionReportTransformerEntity and TransformerManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// ComponentInspectionReportTransformer.TransformerManufacturerId - TransformerManufacturer.TransformerManufacturerId
		/// </summary>
		public virtual IEntityRelation TransformerManufacturerEntityUsingTransformerManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TransformerManufacturer", false);
				relation.AddEntityFieldPair(TransformerManufacturerFields.TransformerManufacturerId, ComponentInspectionReportTransformerFields.TransformerManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TransformerManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", true);
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
