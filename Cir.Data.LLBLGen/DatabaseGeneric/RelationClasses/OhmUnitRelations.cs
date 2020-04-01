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
	/// <summary>Implements the static Relations variant for the entity: OhmUnit. </summary>
	public partial class OhmUnitRelations
	{
		/// <summary>CTor</summary>
		public OhmUnitRelations()
		{
		}

		/// <summary>Gets all relations of the OhmUnitEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId);
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId);
			toReturn.Add(this.OhmUnitEntityUsingParentOhmUnitId);

			toReturn.Add(this.OhmUnitEntityUsingOhmUnitIdParentOhmUnitId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between OhmUnitEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// OhmUnit.OhmUnitId - ComponentInspectionReportGenerator.KgroundOhmUnitId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator______" , true);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.KgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OhmUnitEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// OhmUnit.OhmUnitId - ComponentInspectionReportGenerator.VwohmUnitId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingVwohmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator_____" , true);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.VwohmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OhmUnitEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// OhmUnit.OhmUnitId - ComponentInspectionReportGenerator.MgroundOhmUnitId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator________" , true);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.MgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OhmUnitEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// OhmUnit.OhmUnitId - ComponentInspectionReportGenerator.LgroundOhmUnitId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator_______" , true);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.LgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OhmUnitEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// OhmUnit.OhmUnitId - ComponentInspectionReportGenerator.UwohmUnitId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingUwohmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator____" , true);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.UwohmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OhmUnitEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// OhmUnit.OhmUnitId - ComponentInspectionReportGenerator.VgroundOhmUnitId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator_" , true);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.VgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OhmUnitEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// OhmUnit.OhmUnitId - ComponentInspectionReportGenerator.UgroundOhmUnitId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator" , true);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.UgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OhmUnitEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// OhmUnit.OhmUnitId - ComponentInspectionReportGenerator.UvohmUnitId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingUvohmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator___" , true);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.UvohmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OhmUnitEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// OhmUnit.OhmUnitId - ComponentInspectionReportGenerator.WgroundOhmUnitId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator__" , true);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, ComponentInspectionReportGeneratorFields.WgroundOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between OhmUnitEntity and OhmUnitEntity over the 1:n relation they have, using the relation between the fields:
		/// OhmUnit.OhmUnitId - OhmUnit.ParentOhmUnitId
		/// </summary>
		public virtual IEntityRelation OhmUnitEntityUsingParentOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "OhmUnit_" , true);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, OhmUnitFields.ParentOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between OhmUnitEntity and OhmUnitEntity over the m:1 relation they have, using the relation between the fields:
		/// OhmUnit.ParentOhmUnitId - OhmUnit.OhmUnitId
		/// </summary>
		public virtual IEntityRelation OhmUnitEntityUsingOhmUnitIdParentOhmUnitId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "OhmUnit", false);
				relation.AddEntityFieldPair(OhmUnitFields.OhmUnitId, OhmUnitFields.ParentOhmUnitId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("OhmUnitEntity", true);
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
