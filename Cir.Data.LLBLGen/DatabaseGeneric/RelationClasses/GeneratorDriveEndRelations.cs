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
	/// <summary>Implements the static Relations variant for the entity: GeneratorDriveEnd. </summary>
	public partial class GeneratorDriveEndRelations
	{
		/// <summary>CTor</summary>
		public GeneratorDriveEndRelations()
		{
		}

		/// <summary>Gets all relations of the GeneratorDriveEndEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingGeneratorDriveEndId);
			toReturn.Add(this.GeneratorDriveEndEntityUsingParentGeneratorDriveEndId);

			toReturn.Add(this.GeneratorDriveEndEntityUsingGeneratorDriveEndIdParentGeneratorDriveEndId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GeneratorDriveEndEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorDriveEnd.GeneratorDriveEndId - ComponentInspectionReportGenerator.GeneratorDriveEndId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingGeneratorDriveEndId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator" , true);
				relation.AddEntityFieldPair(GeneratorDriveEndFields.GeneratorDriveEndId, ComponentInspectionReportGeneratorFields.GeneratorDriveEndId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDriveEndEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GeneratorDriveEndEntity and GeneratorDriveEndEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorDriveEnd.GeneratorDriveEndId - GeneratorDriveEnd.ParentGeneratorDriveEndId
		/// </summary>
		public virtual IEntityRelation GeneratorDriveEndEntityUsingParentGeneratorDriveEndId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GeneratorDriveEnd_" , true);
				relation.AddEntityFieldPair(GeneratorDriveEndFields.GeneratorDriveEndId, GeneratorDriveEndFields.ParentGeneratorDriveEndId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDriveEndEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDriveEndEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between GeneratorDriveEndEntity and GeneratorDriveEndEntity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorDriveEnd.ParentGeneratorDriveEndId - GeneratorDriveEnd.GeneratorDriveEndId
		/// </summary>
		public virtual IEntityRelation GeneratorDriveEndEntityUsingGeneratorDriveEndIdParentGeneratorDriveEndId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorDriveEnd", false);
				relation.AddEntityFieldPair(GeneratorDriveEndFields.GeneratorDriveEndId, GeneratorDriveEndFields.ParentGeneratorDriveEndId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDriveEndEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorDriveEndEntity", true);
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
