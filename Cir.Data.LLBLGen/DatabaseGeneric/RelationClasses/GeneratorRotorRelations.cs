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
	/// <summary>Implements the static Relations variant for the entity: GeneratorRotor. </summary>
	public partial class GeneratorRotorRelations
	{
		/// <summary>CTor</summary>
		public GeneratorRotorRelations()
		{
		}

		/// <summary>Gets all relations of the GeneratorRotorEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId);
			toReturn.Add(this.GeneratorRotorEntityUsingParentGeneratorRotorId);

			toReturn.Add(this.GeneratorRotorEntityUsingGeneratorRotorIdParentGeneratorRotorId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between GeneratorRotorEntity and ComponentInspectionReportGeneratorEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorRotor.GeneratorRotorId - ComponentInspectionReportGenerator.GeneratorRotorId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneratorEntityUsingGeneratorRotorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGenerator" , true);
				relation.AddEntityFieldPair(GeneratorRotorFields.GeneratorRotorId, ComponentInspectionReportGeneratorFields.GeneratorRotorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorRotorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneratorEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between GeneratorRotorEntity and GeneratorRotorEntity over the 1:n relation they have, using the relation between the fields:
		/// GeneratorRotor.GeneratorRotorId - GeneratorRotor.ParentGeneratorRotorId
		/// </summary>
		public virtual IEntityRelation GeneratorRotorEntityUsingParentGeneratorRotorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "GeneratorRotor_" , true);
				relation.AddEntityFieldPair(GeneratorRotorFields.GeneratorRotorId, GeneratorRotorFields.ParentGeneratorRotorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorRotorEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorRotorEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between GeneratorRotorEntity and GeneratorRotorEntity over the m:1 relation they have, using the relation between the fields:
		/// GeneratorRotor.ParentGeneratorRotorId - GeneratorRotor.GeneratorRotorId
		/// </summary>
		public virtual IEntityRelation GeneratorRotorEntityUsingGeneratorRotorIdParentGeneratorRotorId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "GeneratorRotor", false);
				relation.AddEntityFieldPair(GeneratorRotorFields.GeneratorRotorId, GeneratorRotorFields.ParentGeneratorRotorId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorRotorEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("GeneratorRotorEntity", true);
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
