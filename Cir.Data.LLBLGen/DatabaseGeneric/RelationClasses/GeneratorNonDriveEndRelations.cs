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
	/// <summary>Implements the static Relations variant for the entity: GeneratorNonDriveEnd. </summary>
	public partial class GeneratorNonDriveEndRelations
	{
		/// <summary>CTor</summary>
		public GeneratorNonDriveEndRelations()
		{
		}

		/// <summary>Gets all relations of the GeneratorNonDriveEndEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingGeneratorNonDriveEndId);
			toReturn.Add(this.GeneratorNonDriveEndEntityUsingParentGeneratorNonDriveEndId);

			toReturn.Add(this.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndIdParentGeneratorNonDriveEndId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GeneratorNonDriveEndEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorNonDriveEnd.GeneratorNonDriveEndId - ComponentInspectionReportGenerator.GeneratorNonDriveEndId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingGeneratorNonDriveEndId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator" , true);
				relation.AddEntityFieldPair(GeneratorNonDriveEndFields.GeneratorNonDriveEndId, ComponentInspectionReportGeneratorFields.GeneratorNonDriveEndId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorNonDriveEndEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GeneratorNonDriveEndEntity and GeneratorNonDriveEndEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorNonDriveEnd.GeneratorNonDriveEndId - GeneratorNonDriveEnd.ParentGeneratorNonDriveEndId
		/// </summary>
		public virtual IEntityRelation GeneratorNonDriveEndEntityUsingParentGeneratorNonDriveEndId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GeneratorNonDriveEnd_" , true);
				relation.AddEntityFieldPair(GeneratorNonDriveEndFields.GeneratorNonDriveEndId, GeneratorNonDriveEndFields.ParentGeneratorNonDriveEndId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorNonDriveEndEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorNonDriveEndEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between GeneratorNonDriveEndEntity and GeneratorNonDriveEndEntity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorNonDriveEnd.ParentGeneratorNonDriveEndId - GeneratorNonDriveEnd.GeneratorNonDriveEndId
		/// </summary>
		public virtual IEntityRelation GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndIdParentGeneratorNonDriveEndId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorNonDriveEnd", false);
				relation.AddEntityFieldPair(GeneratorNonDriveEndFields.GeneratorNonDriveEndId, GeneratorNonDriveEndFields.ParentGeneratorNonDriveEndId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorNonDriveEndEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorNonDriveEndEntity", true);
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
