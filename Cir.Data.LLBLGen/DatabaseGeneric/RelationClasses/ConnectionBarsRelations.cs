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
	/// <summary>Implements the static Relations variant for the entity: ConnectionBars. </summary>
	public partial class ConnectionBarsRelations
	{
		/// <summary>CTor</summary>
		public ConnectionBarsRelations()
		{
		}

		/// <summary>Gets all relations of the ConnectionBarsEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ComponentInspectionReportTransformerEntityUsingConnectionBarsId);
			toReturn.Add(this.ConnectionBarsEntityUsingParentConnectionBarsId);

			toReturn.Add(this.ConnectionBarsEntityUsingConnectionBarsIdParentConnectionBarsId);
			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between ConnectionBarsEntity and ComponentInspectionReportTransformerEntity over the 1:n relation they have, using the relation between the fields:
		/// ConnectionBars.ConnectionBarsId - ComponentInspectionReportTransformer.ConnectionBarsId
		/// </summary>
		public virtual IEntityRelation ComponentInspectionReportTransformerEntityUsingConnectionBarsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ComponentInspectionReportTransformer" , true);
				relation.AddEntityFieldPair(ConnectionBarsFields.ConnectionBarsId, ComponentInspectionReportTransformerFields.ConnectionBarsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConnectionBarsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ComponentInspectionReportTransformerEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between ConnectionBarsEntity and ConnectionBarsEntity over the 1:n relation they have, using the relation between the fields:
		/// ConnectionBars.ConnectionBarsId - ConnectionBars.ParentConnectionBarsId
		/// </summary>
		public virtual IEntityRelation ConnectionBarsEntityUsingParentConnectionBarsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "ConnectionBars_" , true);
				relation.AddEntityFieldPair(ConnectionBarsFields.ConnectionBarsId, ConnectionBarsFields.ParentConnectionBarsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConnectionBarsEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConnectionBarsEntity", false);
				return relation;
			}
		}


		/// <summary>Returns a new IEntityRelation object, between ConnectionBarsEntity and ConnectionBarsEntity over the m:1 relation they have, using the relation between the fields:
		/// ConnectionBars.ParentConnectionBarsId - ConnectionBars.ConnectionBarsId
		/// </summary>
		public virtual IEntityRelation ConnectionBarsEntityUsingConnectionBarsIdParentConnectionBarsId
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne, "ConnectionBars", false);
				relation.AddEntityFieldPair(ConnectionBarsFields.ConnectionBarsId, ConnectionBarsFields.ParentConnectionBarsId);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConnectionBarsEntity", false);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ConnectionBarsEntity", true);
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
