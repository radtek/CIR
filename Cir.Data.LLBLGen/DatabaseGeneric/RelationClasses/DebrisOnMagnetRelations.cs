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
	/// <summary>Implements the static Relations variant for the entity: DebrisOnMagnet. </summary>
	public partial class DebrisOnMagnetRelations
	{
		/// <summary>CTor</summary>
		public DebrisOnMagnetRelations()
		{
		}

		/// <summary>Gets all relations of the DebrisOnMagnetEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxDebrisOnMagnetId);
			toReturn.Add(this.DebrisOnMagnetEntityUsingParentDebrisOnMagnetId);

			toReturn.Add(this.DebrisOnMagnetEntityUsingDebrisOnMagnetIdParentDebrisOnMagnetId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between DebrisOnMagnetEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// DebrisOnMagnet.DebrisOnMagnetId - ComponentInspectionReportGearbox.GearboxDebrisOnMagnetId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxDebrisOnMagnetId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(DebrisOnMagnetFields.DebrisOnMagnetId, ComponentInspectionReportGearboxFields.GearboxDebrisOnMagnetId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisOnMagnetEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between DebrisOnMagnetEntity and DebrisOnMagnetEntity over the 1:n relation they have, using the relation between the fields:
		/// DebrisOnMagnet.DebrisOnMagnetId - DebrisOnMagnet.ParentDebrisOnMagnetId
		/// </summary>
		public virtual IEntityRelation DebrisOnMagnetEntityUsingParentDebrisOnMagnetId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DebrisOnMagnet_" , true);
				relation.AddEntityFieldPair(DebrisOnMagnetFields.DebrisOnMagnetId, DebrisOnMagnetFields.ParentDebrisOnMagnetId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisOnMagnetEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisOnMagnetEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between DebrisOnMagnetEntity and DebrisOnMagnetEntity over the m:1 relation they have, using the relation between the fields:
		/// DebrisOnMagnet.ParentDebrisOnMagnetId - DebrisOnMagnet.DebrisOnMagnetId
		/// </summary>
		public virtual IEntityRelation DebrisOnMagnetEntityUsingDebrisOnMagnetIdParentDebrisOnMagnetId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "DebrisOnMagnet", false);
				relation.AddEntityFieldPair(DebrisOnMagnetFields.DebrisOnMagnetId, DebrisOnMagnetFields.ParentDebrisOnMagnetId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisOnMagnetEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("DebrisOnMagnetEntity", true);
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
