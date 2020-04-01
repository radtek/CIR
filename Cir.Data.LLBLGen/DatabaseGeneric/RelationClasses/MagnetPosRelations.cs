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
	/// <summary>Implements the static Relations variant for the entity: MagnetPos. </summary>
	public partial class MagnetPosRelations
	{
		/// <summary>CTor</summary>
		public MagnetPosRelations()
		{
		}

		/// <summary>Gets all relations of the MagnetPosEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportGearboxEntityUsingGearboxDebrisStagesMagnetPosId);
			toReturn.Add(this.MagnetPosEntityUsingParentMagnetPosId);

			toReturn.Add(this.MagnetPosEntityUsingMagnetPosIdParentMagnetPosId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between MagnetPosEntity and ComponentInspectionReportGearboxEntity over the 1:n relation they have, using the relation between the fields:
		/// MagnetPos.MagnetPosId - ComponentInspectionReportGearbox.GearboxDebrisStagesMagnetPosId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportGearboxEntityUsingGearboxDebrisStagesMagnetPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportGearbox" , true);
				relation.AddEntityFieldPair(MagnetPosFields.MagnetPosId, ComponentInspectionReportGearboxFields.GearboxDebrisStagesMagnetPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MagnetPosEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportGearboxEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between MagnetPosEntity and MagnetPosEntity over the 1:n relation they have, using the relation between the fields:
		/// MagnetPos.MagnetPosId - MagnetPos.ParentMagnetPosId
		/// </summary>
		public virtual IEntityRelation MagnetPosEntityUsingParentMagnetPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "MagnetPos_" , true);
				relation.AddEntityFieldPair(MagnetPosFields.MagnetPosId, MagnetPosFields.ParentMagnetPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MagnetPosEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MagnetPosEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between MagnetPosEntity and MagnetPosEntity over the m:1 relation they have, using the relation between the fields:
		/// MagnetPos.ParentMagnetPosId - MagnetPos.MagnetPosId
		/// </summary>
		public virtual IEntityRelation MagnetPosEntityUsingMagnetPosIdParentMagnetPosId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "MagnetPos", false);
				relation.AddEntityFieldPair(MagnetPosFields.MagnetPosId, MagnetPosFields.ParentMagnetPosId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MagnetPosEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("MagnetPosEntity", true);
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
