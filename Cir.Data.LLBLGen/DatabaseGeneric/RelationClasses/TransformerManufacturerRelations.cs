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
	/// <summary>Implements the static Relations variant for the entity: TransformerManufacturer. </summary>
	public partial class TransformerManufacturerRelations
	{
		/// <summary>CTor</summary>
		public TransformerManufacturerRelations()
		{
		}

		/// <summary>Gets all relations of the TransformerManufacturerEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId);
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId);
			toReturn.Add(this.TransformerManufacturerEntityUsingParentTransformerManufacturerId);

			toReturn.Add(this.TransformerManufacturerEntityUsingTransformerManufacturerIdParentTransformerManufacturerId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between TransformerManufacturerEntity and ComponentInspectionReportGeneralEntity over the 1:n relation they have, using the relation between the fields:
		/// TransformerManufacturer.TransformerManufacturerId - ComponentInspectionReportGeneral.GeneralTransformerManufacturerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGeneralEntityUsingGeneralTransformerManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGeneral" , true);
				relation.AddEntityFieldPair(TransformerManufacturerFields.TransformerManufacturerId, ComponentInspectionReportGeneralFields.GeneralTransformerManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TransformerManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGeneralEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TransformerManufacturerEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// TransformerManufacturer.TransformerManufacturerId - ComponentInspectionReportTransformer.TransformerManufacturerId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingTransformerManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer" , true);
				relation.AddEntityFieldPair(TransformerManufacturerFields.TransformerManufacturerId, ComponentInspectionReportTransformerFields.TransformerManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TransformerManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between TransformerManufacturerEntity and TransformerManufacturerEntity over the 1:n relation they have, using the relation between the fields:
		/// TransformerManufacturer.TransformerManufacturerId - TransformerManufacturer.ParentTransformerManufacturerId
		/// </summary>
		public virtual IEntityRelation TransformerManufacturerEntityUsingParentTransformerManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "TransformerManufacturer_" , true);
				relation.AddEntityFieldPair(TransformerManufacturerFields.TransformerManufacturerId, TransformerManufacturerFields.ParentTransformerManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TransformerManufacturerEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TransformerManufacturerEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between TransformerManufacturerEntity and TransformerManufacturerEntity over the m:1 relation they have, using the relation between the fields:
		/// TransformerManufacturer.ParentTransformerManufacturerId - TransformerManufacturer.TransformerManufacturerId
		/// </summary>
		public virtual IEntityRelation TransformerManufacturerEntityUsingTransformerManufacturerIdParentTransformerManufacturerId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "TransformerManufacturer", false);
				relation.AddEntityFieldPair(TransformerManufacturerFields.TransformerManufacturerId, TransformerManufacturerFields.ParentTransformerManufacturerId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TransformerManufacturerEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("TransformerManufacturerEntity", true);
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
