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
	/// <summary>Implements the static Relations variant for the entity: ElectricalPump. </summary>
	public partial class ElectricalPumpRelations
	{
		/// <summary>CTor</summary>
		public ElectricalPumpRelations()
		{
		}

		/// <summary>Gets all relations of the ElectricalPumpEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxElectricalPumpId);
			toReturn.Add(this.ElectricalPumpEntityUsingParentElectricalPumpId);

			toReturn.Add(this.ElectricalPumpEntityUsingElectricalPumpIdParentElectricalPumpId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ElectricalPumpEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// ElectricalPump.ElectricalPumpId - ComponentInspectionReportGearbox.GearboxElectricalPumpId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxElectricalPumpId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(ElectricalPumpFields.ElectricalPumpId, ComponentInspectionReportGearboxFields.GearboxElectricalPumpId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ElectricalPumpEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ElectricalPumpEntity and ElectricalPumpEntity over the 1:n relation they have, using the relation between the fields:
		/// ElectricalPump.ElectricalPumpId - ElectricalPump.ParentElectricalPumpId
		/// </summary>
		public virtual IEntityRelation ElectricalPumpEntityUsingParentElectricalPumpId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ElectricalPump_" , true);
				relation.AddEntityFieldPair(ElectricalPumpFields.ElectricalPumpId, ElectricalPumpFields.ParentElectricalPumpId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ElectricalPumpEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ElectricalPumpEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ElectricalPumpEntity and ElectricalPumpEntity over the m:1 relation they have, using the relation between the fields:
		/// ElectricalPump.ParentElectricalPumpId - ElectricalPump.ElectricalPumpId
		/// </summary>
		public virtual IEntityRelation ElectricalPumpEntityUsingElectricalPumpIdParentElectricalPumpId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ElectricalPump", false);
				relation.AddEntityFieldPair(ElectricalPumpFields.ElectricalPumpId, ElectricalPumpFields.ParentElectricalPumpId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ElectricalPumpEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ElectricalPumpEntity", true);
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
