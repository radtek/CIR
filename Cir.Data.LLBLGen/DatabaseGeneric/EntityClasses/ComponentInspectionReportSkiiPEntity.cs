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
using System.ComponentModel;
using System.Collections.Generic;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Xml.Serialization;
using Cir.Data.LLBLGen;
using Cir.Data.LLBLGen.HelperClasses;
using Cir.Data.LLBLGen.FactoryClasses;
using Cir.Data.LLBLGen.RelationClasses;

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Cir.Data.LLBLGen.EntityClasses
{
	
	// __LLBLGENPRO_USER_CODE_REGION_START AdditionalNamespaces
	// __LLBLGENPRO_USER_CODE_REGION_END

	/// <summary>
	/// Entity class which represents the entity 'ComponentInspectionReportSkiiP'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ComponentInspectionReportSkiiPEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportSkiiPfailedComponentEntity> _componentInspectionReportSkiiPfailedComponent;
		private EntityCollection<ComponentInspectionReportSkiiPnewComponentEntity> _componentInspectionReportSkiiPnewComponent;

		private BooleanAnswerEntity _booleanAnswer_____________;
		private BooleanAnswerEntity _booleanAnswer______________;
		private BooleanAnswerEntity _booleanAnswer____________;
		private BooleanAnswerEntity _booleanAnswer__________;
		private BooleanAnswerEntity _booleanAnswer___________;
		private BooleanAnswerEntity _booleanAnswer__________________;
		private BooleanAnswerEntity _booleanAnswer___________________;
		private BooleanAnswerEntity _booleanAnswer_________________;
		private BooleanAnswerEntity _booleanAnswer_______________;
		private BooleanAnswerEntity _booleanAnswer________________;
		private BooleanAnswerEntity _booleanAnswer___;
		private BooleanAnswerEntity _booleanAnswer____;
		private BooleanAnswerEntity _booleanAnswer__;
		private BooleanAnswerEntity _booleanAnswer;
		private BooleanAnswerEntity _booleanAnswer_;
		private BooleanAnswerEntity _booleanAnswer_________;
		private BooleanAnswerEntity _booleanAnswer_______;
		private BooleanAnswerEntity _booleanAnswer________;
		private BooleanAnswerEntity _booleanAnswer_____;
		private BooleanAnswerEntity _booleanAnswer______;
		private ComponentInspectionReportEntity _componentInspectionReport;
		private SkiipackFailureCauseEntity _skiipackFailureCause;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name BooleanAnswer_____________</summary>
			public static readonly string BooleanAnswer_____________ = "BooleanAnswer_____________";
			/// <summary>Member name BooleanAnswer______________</summary>
			public static readonly string BooleanAnswer______________ = "BooleanAnswer______________";
			/// <summary>Member name BooleanAnswer____________</summary>
			public static readonly string BooleanAnswer____________ = "BooleanAnswer____________";
			/// <summary>Member name BooleanAnswer__________</summary>
			public static readonly string BooleanAnswer__________ = "BooleanAnswer__________";
			/// <summary>Member name BooleanAnswer___________</summary>
			public static readonly string BooleanAnswer___________ = "BooleanAnswer___________";
			/// <summary>Member name BooleanAnswer__________________</summary>
			public static readonly string BooleanAnswer__________________ = "BooleanAnswer__________________";
			/// <summary>Member name BooleanAnswer___________________</summary>
			public static readonly string BooleanAnswer___________________ = "BooleanAnswer___________________";
			/// <summary>Member name BooleanAnswer_________________</summary>
			public static readonly string BooleanAnswer_________________ = "BooleanAnswer_________________";
			/// <summary>Member name BooleanAnswer_______________</summary>
			public static readonly string BooleanAnswer_______________ = "BooleanAnswer_______________";
			/// <summary>Member name BooleanAnswer________________</summary>
			public static readonly string BooleanAnswer________________ = "BooleanAnswer________________";
			/// <summary>Member name BooleanAnswer___</summary>
			public static readonly string BooleanAnswer___ = "BooleanAnswer___";
			/// <summary>Member name BooleanAnswer____</summary>
			public static readonly string BooleanAnswer____ = "BooleanAnswer____";
			/// <summary>Member name BooleanAnswer__</summary>
			public static readonly string BooleanAnswer__ = "BooleanAnswer__";
			/// <summary>Member name BooleanAnswer</summary>
			public static readonly string BooleanAnswer = "BooleanAnswer";
			/// <summary>Member name BooleanAnswer_</summary>
			public static readonly string BooleanAnswer_ = "BooleanAnswer_";
			/// <summary>Member name BooleanAnswer_________</summary>
			public static readonly string BooleanAnswer_________ = "BooleanAnswer_________";
			/// <summary>Member name BooleanAnswer_______</summary>
			public static readonly string BooleanAnswer_______ = "BooleanAnswer_______";
			/// <summary>Member name BooleanAnswer________</summary>
			public static readonly string BooleanAnswer________ = "BooleanAnswer________";
			/// <summary>Member name BooleanAnswer_____</summary>
			public static readonly string BooleanAnswer_____ = "BooleanAnswer_____";
			/// <summary>Member name BooleanAnswer______</summary>
			public static readonly string BooleanAnswer______ = "BooleanAnswer______";
			/// <summary>Member name ComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReport = "ComponentInspectionReport";
			/// <summary>Member name SkiipackFailureCause</summary>
			public static readonly string SkiipackFailureCause = "SkiipackFailureCause";
			/// <summary>Member name ComponentInspectionReportSkiiPfailedComponent</summary>
			public static readonly string ComponentInspectionReportSkiiPfailedComponent = "ComponentInspectionReportSkiiPfailedComponent";
			/// <summary>Member name ComponentInspectionReportSkiiPnewComponent</summary>
			public static readonly string ComponentInspectionReportSkiiPnewComponent = "ComponentInspectionReportSkiiPnewComponent";


		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ComponentInspectionReportSkiiPEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ComponentInspectionReportSkiiPEntity():base("ComponentInspectionReportSkiiPEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ComponentInspectionReportSkiiPEntity(IEntityFields2 fields):base("ComponentInspectionReportSkiiPEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportSkiiPEntity</param>
		public ComponentInspectionReportSkiiPEntity(IValidator validator):base("ComponentInspectionReportSkiiPEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportSkiiPid">PK value for ComponentInspectionReportSkiiP which data should be fetched into this ComponentInspectionReportSkiiP object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportSkiiPEntity(System.Int64 componentInspectionReportSkiiPid):base("ComponentInspectionReportSkiiPEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ComponentInspectionReportSkiiPid = componentInspectionReportSkiiPid;
		}

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportSkiiPid">PK value for ComponentInspectionReportSkiiP which data should be fetched into this ComponentInspectionReportSkiiP object</param>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportSkiiPEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportSkiiPEntity(System.Int64 componentInspectionReportSkiiPid, IValidator validator):base("ComponentInspectionReportSkiiPEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ComponentInspectionReportSkiiPid = componentInspectionReportSkiiPid;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ComponentInspectionReportSkiiPEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReportSkiiPfailedComponent = (EntityCollection<ComponentInspectionReportSkiiPfailedComponentEntity>)info.GetValue("_componentInspectionReportSkiiPfailedComponent", typeof(EntityCollection<ComponentInspectionReportSkiiPfailedComponentEntity>));
				_componentInspectionReportSkiiPnewComponent = (EntityCollection<ComponentInspectionReportSkiiPnewComponentEntity>)info.GetValue("_componentInspectionReportSkiiPnewComponent", typeof(EntityCollection<ComponentInspectionReportSkiiPnewComponentEntity>));

				_booleanAnswer_____________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer_____________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer_____________!=null)
				{
					_booleanAnswer_____________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer______________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer______________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer______________!=null)
				{
					_booleanAnswer______________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer____________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer____________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer____________!=null)
				{
					_booleanAnswer____________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer__________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer__________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer__________!=null)
				{
					_booleanAnswer__________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer___________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer___________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer___________!=null)
				{
					_booleanAnswer___________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer__________________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer__________________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer__________________!=null)
				{
					_booleanAnswer__________________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer___________________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer___________________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer___________________!=null)
				{
					_booleanAnswer___________________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer_________________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer_________________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer_________________!=null)
				{
					_booleanAnswer_________________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer_______________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer_______________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer_______________!=null)
				{
					_booleanAnswer_______________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer________________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer________________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer________________!=null)
				{
					_booleanAnswer________________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer___ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer___", typeof(BooleanAnswerEntity));
				if(_booleanAnswer___!=null)
				{
					_booleanAnswer___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer____ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer____", typeof(BooleanAnswerEntity));
				if(_booleanAnswer____!=null)
				{
					_booleanAnswer____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer__ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer__", typeof(BooleanAnswerEntity));
				if(_booleanAnswer__!=null)
				{
					_booleanAnswer__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer = (BooleanAnswerEntity)info.GetValue("_booleanAnswer", typeof(BooleanAnswerEntity));
				if(_booleanAnswer!=null)
				{
					_booleanAnswer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer_ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer_", typeof(BooleanAnswerEntity));
				if(_booleanAnswer_!=null)
				{
					_booleanAnswer_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer_________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer_________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer_________!=null)
				{
					_booleanAnswer_________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer_______ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer_______", typeof(BooleanAnswerEntity));
				if(_booleanAnswer_______!=null)
				{
					_booleanAnswer_______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer________ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer________", typeof(BooleanAnswerEntity));
				if(_booleanAnswer________!=null)
				{
					_booleanAnswer________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer_____ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer_____", typeof(BooleanAnswerEntity));
				if(_booleanAnswer_____!=null)
				{
					_booleanAnswer_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer______ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer______", typeof(BooleanAnswerEntity));
				if(_booleanAnswer______!=null)
				{
					_booleanAnswer______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_componentInspectionReport = (ComponentInspectionReportEntity)info.GetValue("_componentInspectionReport", typeof(ComponentInspectionReportEntity));
				if(_componentInspectionReport!=null)
				{
					_componentInspectionReport.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_skiipackFailureCause = (SkiipackFailureCauseEntity)info.GetValue("_skiipackFailureCause", typeof(SkiipackFailureCauseEntity));
				if(_skiipackFailureCause!=null)
				{
					_skiipackFailureCause.AfterSave+=new EventHandler(OnEntityAfterSave);
				}

				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((ComponentInspectionReportSkiiPFieldIndex)fieldIndex)
			{
				case ComponentInspectionReportSkiiPFieldIndex.ComponentInspectionReportId:
					DesetupSyncComponentInspectionReport(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiPcauseId:
					DesetupSyncSkiipackFailureCause(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv521BooleanAnswerId:
					DesetupSyncBooleanAnswer(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv522BooleanAnswerId:
					DesetupSyncBooleanAnswer_________________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv523BooleanAnswerId:
					DesetupSyncBooleanAnswer_________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv524BooleanAnswerId:
					DesetupSyncBooleanAnswer__________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv525BooleanAnswerId:
					DesetupSyncBooleanAnswer___________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv526BooleanAnswerId:
					DesetupSyncBooleanAnswer____________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv521BooleanAnswerId:
					DesetupSyncBooleanAnswer_____________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv522BooleanAnswerId:
					DesetupSyncBooleanAnswer______________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv523BooleanAnswerId:
					DesetupSyncBooleanAnswer_______________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv524xBooleanAnswerId:
					DesetupSyncBooleanAnswer________________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv524yBooleanAnswerId:
					DesetupSyncBooleanAnswer__(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv525xBooleanAnswerId:
					DesetupSyncBooleanAnswer__________________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv525yBooleanAnswerId:
					DesetupSyncBooleanAnswer___(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv526xBooleanAnswerId:
					DesetupSyncBooleanAnswer___________________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv526yBooleanAnswerId:
					DesetupSyncBooleanAnswer____(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv520BooleanAnswerId:
					DesetupSyncBooleanAnswer_____(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv524BooleanAnswerId:
					DesetupSyncBooleanAnswer______(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv525BooleanAnswerId:
					DesetupSyncBooleanAnswer_______(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv526BooleanAnswerId:
					DesetupSyncBooleanAnswer________(true, false);
					break;
				case ComponentInspectionReportSkiiPFieldIndex.SkiiPclaimRelevantBooleanAnswerId:
					DesetupSyncBooleanAnswer_(true, false);
					break;
				default:
					base.PerformDesyncSetupFKFieldChange(fieldIndex);
					break;
			}
		}
		
		/// <summary> Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.</summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntityProperty(string propertyName, IEntity2 entity)
		{
			switch(propertyName)
			{
				case "BooleanAnswer_____________":
					this.BooleanAnswer_____________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer______________":
					this.BooleanAnswer______________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer____________":
					this.BooleanAnswer____________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer__________":
					this.BooleanAnswer__________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer___________":
					this.BooleanAnswer___________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer__________________":
					this.BooleanAnswer__________________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer___________________":
					this.BooleanAnswer___________________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer_________________":
					this.BooleanAnswer_________________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer_______________":
					this.BooleanAnswer_______________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer________________":
					this.BooleanAnswer________________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer___":
					this.BooleanAnswer___ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer____":
					this.BooleanAnswer____ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer__":
					this.BooleanAnswer__ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer":
					this.BooleanAnswer = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer_":
					this.BooleanAnswer_ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer_________":
					this.BooleanAnswer_________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer_______":
					this.BooleanAnswer_______ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer________":
					this.BooleanAnswer________ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer_____":
					this.BooleanAnswer_____ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer______":
					this.BooleanAnswer______ = (BooleanAnswerEntity)entity;
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport = (ComponentInspectionReportEntity)entity;
					break;
				case "SkiipackFailureCause":
					this.SkiipackFailureCause = (SkiipackFailureCauseEntity)entity;
					break;
				case "ComponentInspectionReportSkiiPfailedComponent":
					this.ComponentInspectionReportSkiiPfailedComponent.Add((ComponentInspectionReportSkiiPfailedComponentEntity)entity);
					break;
				case "ComponentInspectionReportSkiiPnewComponent":
					this.ComponentInspectionReportSkiiPnewComponent.Add((ComponentInspectionReportSkiiPnewComponentEntity)entity);
					break;


				default:
					break;
			}
		}
#if !CF		
		/// <summary>Checks if the relation mapped by the property with the name specified is a one way / single sided relation. If the passed in name is null, it
		/// will return true if the entity has any single-sided relation</summary>
		/// <param name="propertyName">Name of the property which is mapped onto the relation to check, or null to check if the entity has any relation/ which is single sided</param>
		/// <returns>true if the relation is single sided / one way (so the opposite relation isn't present), false otherwise</returns>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override bool CheckOneWayRelations(string propertyName)
		{
			// use template trick to calculate the # of single-sided / oneway relations
			int numberOfOneWayRelations = 0;
			switch(propertyName)
			{
				case null:
					return ((numberOfOneWayRelations > 0) || base.CheckOneWayRelations(null));























				default:
					return base.CheckOneWayRelations(propertyName);
			}
		}
#endif
		/// <summary> Sets the internal parameter related to the fieldname passed to the instance relatedEntity. </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void SetRelatedEntity(IEntity2 relatedEntity, string fieldName)
		{
			switch(fieldName)
			{
				case "BooleanAnswer_____________":
					SetupSyncBooleanAnswer_____________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer______________":
					SetupSyncBooleanAnswer______________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer____________":
					SetupSyncBooleanAnswer____________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer__________":
					SetupSyncBooleanAnswer__________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer___________":
					SetupSyncBooleanAnswer___________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer__________________":
					SetupSyncBooleanAnswer__________________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer___________________":
					SetupSyncBooleanAnswer___________________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_________________":
					SetupSyncBooleanAnswer_________________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_______________":
					SetupSyncBooleanAnswer_______________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer________________":
					SetupSyncBooleanAnswer________________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer___":
					SetupSyncBooleanAnswer___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer____":
					SetupSyncBooleanAnswer____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer__":
					SetupSyncBooleanAnswer__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer":
					SetupSyncBooleanAnswer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_":
					SetupSyncBooleanAnswer_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_________":
					SetupSyncBooleanAnswer_________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_______":
					SetupSyncBooleanAnswer_______(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer________":
					SetupSyncBooleanAnswer________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_____":
					SetupSyncBooleanAnswer_____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer______":
					SetupSyncBooleanAnswer______(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					SetupSyncComponentInspectionReport(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "SkiipackFailureCause":
					SetupSyncSkiipackFailureCause(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportSkiiPfailedComponent":
					this.ComponentInspectionReportSkiiPfailedComponent.Add((ComponentInspectionReportSkiiPfailedComponentEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportSkiiPnewComponent":
					this.ComponentInspectionReportSkiiPnewComponent.Add((ComponentInspectionReportSkiiPnewComponentEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;

				default:
					break;
			}
		}

		/// <summary> Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne)
		{
			switch(fieldName)
			{
				case "BooleanAnswer_____________":
					DesetupSyncBooleanAnswer_____________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer______________":
					DesetupSyncBooleanAnswer______________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer____________":
					DesetupSyncBooleanAnswer____________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer__________":
					DesetupSyncBooleanAnswer__________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer___________":
					DesetupSyncBooleanAnswer___________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer__________________":
					DesetupSyncBooleanAnswer__________________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer___________________":
					DesetupSyncBooleanAnswer___________________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_________________":
					DesetupSyncBooleanAnswer_________________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_______________":
					DesetupSyncBooleanAnswer_______________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer________________":
					DesetupSyncBooleanAnswer________________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer___":
					DesetupSyncBooleanAnswer___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer____":
					DesetupSyncBooleanAnswer____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer__":
					DesetupSyncBooleanAnswer__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer":
					DesetupSyncBooleanAnswer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_":
					DesetupSyncBooleanAnswer_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_________":
					DesetupSyncBooleanAnswer_________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_______":
					DesetupSyncBooleanAnswer_______(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer________":
					DesetupSyncBooleanAnswer________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_____":
					DesetupSyncBooleanAnswer_____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer______":
					DesetupSyncBooleanAnswer______(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					DesetupSyncComponentInspectionReport(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "SkiipackFailureCause":
					DesetupSyncSkiipackFailureCause(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportSkiiPfailedComponent":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportSkiiPfailedComponent, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportSkiiPnewComponent":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportSkiiPnewComponent, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;

				default:
					break;
			}
		}

		/// <summary> Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These entities will have to be persisted after this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependingRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();

			return toReturn;
		}
		
		/// <summary> Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.</summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		public override List<IEntity2> GetDependentRelatedEntities()
		{
			List<IEntity2> toReturn = new List<IEntity2>();
			if(_booleanAnswer_____________!=null)
			{
				toReturn.Add(_booleanAnswer_____________);
			}
			if(_booleanAnswer______________!=null)
			{
				toReturn.Add(_booleanAnswer______________);
			}
			if(_booleanAnswer____________!=null)
			{
				toReturn.Add(_booleanAnswer____________);
			}
			if(_booleanAnswer__________!=null)
			{
				toReturn.Add(_booleanAnswer__________);
			}
			if(_booleanAnswer___________!=null)
			{
				toReturn.Add(_booleanAnswer___________);
			}
			if(_booleanAnswer__________________!=null)
			{
				toReturn.Add(_booleanAnswer__________________);
			}
			if(_booleanAnswer___________________!=null)
			{
				toReturn.Add(_booleanAnswer___________________);
			}
			if(_booleanAnswer_________________!=null)
			{
				toReturn.Add(_booleanAnswer_________________);
			}
			if(_booleanAnswer_______________!=null)
			{
				toReturn.Add(_booleanAnswer_______________);
			}
			if(_booleanAnswer________________!=null)
			{
				toReturn.Add(_booleanAnswer________________);
			}
			if(_booleanAnswer___!=null)
			{
				toReturn.Add(_booleanAnswer___);
			}
			if(_booleanAnswer____!=null)
			{
				toReturn.Add(_booleanAnswer____);
			}
			if(_booleanAnswer__!=null)
			{
				toReturn.Add(_booleanAnswer__);
			}
			if(_booleanAnswer!=null)
			{
				toReturn.Add(_booleanAnswer);
			}
			if(_booleanAnswer_!=null)
			{
				toReturn.Add(_booleanAnswer_);
			}
			if(_booleanAnswer_________!=null)
			{
				toReturn.Add(_booleanAnswer_________);
			}
			if(_booleanAnswer_______!=null)
			{
				toReturn.Add(_booleanAnswer_______);
			}
			if(_booleanAnswer________!=null)
			{
				toReturn.Add(_booleanAnswer________);
			}
			if(_booleanAnswer_____!=null)
			{
				toReturn.Add(_booleanAnswer_____);
			}
			if(_booleanAnswer______!=null)
			{
				toReturn.Add(_booleanAnswer______);
			}
			if(_componentInspectionReport!=null)
			{
				toReturn.Add(_componentInspectionReport);
			}
			if(_skiipackFailureCause!=null)
			{
				toReturn.Add(_skiipackFailureCause);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReportSkiiPfailedComponent);
			toReturn.Add(this.ComponentInspectionReportSkiiPnewComponent);

			return toReturn;
		}
		


		/// <summary>ISerializable member. Does custom serialization so event handlers do not get serialized. Serializes members of this entity class and uses the base class' implementation to serialize the rest.</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				info.AddValue("_componentInspectionReportSkiiPfailedComponent", ((_componentInspectionReportSkiiPfailedComponent!=null) && (_componentInspectionReportSkiiPfailedComponent.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportSkiiPfailedComponent:null);
				info.AddValue("_componentInspectionReportSkiiPnewComponent", ((_componentInspectionReportSkiiPnewComponent!=null) && (_componentInspectionReportSkiiPnewComponent.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportSkiiPnewComponent:null);

				info.AddValue("_booleanAnswer_____________", (!this.MarkedForDeletion?_booleanAnswer_____________:null));
				info.AddValue("_booleanAnswer______________", (!this.MarkedForDeletion?_booleanAnswer______________:null));
				info.AddValue("_booleanAnswer____________", (!this.MarkedForDeletion?_booleanAnswer____________:null));
				info.AddValue("_booleanAnswer__________", (!this.MarkedForDeletion?_booleanAnswer__________:null));
				info.AddValue("_booleanAnswer___________", (!this.MarkedForDeletion?_booleanAnswer___________:null));
				info.AddValue("_booleanAnswer__________________", (!this.MarkedForDeletion?_booleanAnswer__________________:null));
				info.AddValue("_booleanAnswer___________________", (!this.MarkedForDeletion?_booleanAnswer___________________:null));
				info.AddValue("_booleanAnswer_________________", (!this.MarkedForDeletion?_booleanAnswer_________________:null));
				info.AddValue("_booleanAnswer_______________", (!this.MarkedForDeletion?_booleanAnswer_______________:null));
				info.AddValue("_booleanAnswer________________", (!this.MarkedForDeletion?_booleanAnswer________________:null));
				info.AddValue("_booleanAnswer___", (!this.MarkedForDeletion?_booleanAnswer___:null));
				info.AddValue("_booleanAnswer____", (!this.MarkedForDeletion?_booleanAnswer____:null));
				info.AddValue("_booleanAnswer__", (!this.MarkedForDeletion?_booleanAnswer__:null));
				info.AddValue("_booleanAnswer", (!this.MarkedForDeletion?_booleanAnswer:null));
				info.AddValue("_booleanAnswer_", (!this.MarkedForDeletion?_booleanAnswer_:null));
				info.AddValue("_booleanAnswer_________", (!this.MarkedForDeletion?_booleanAnswer_________:null));
				info.AddValue("_booleanAnswer_______", (!this.MarkedForDeletion?_booleanAnswer_______:null));
				info.AddValue("_booleanAnswer________", (!this.MarkedForDeletion?_booleanAnswer________:null));
				info.AddValue("_booleanAnswer_____", (!this.MarkedForDeletion?_booleanAnswer_____:null));
				info.AddValue("_booleanAnswer______", (!this.MarkedForDeletion?_booleanAnswer______:null));
				info.AddValue("_componentInspectionReport", (!this.MarkedForDeletion?_componentInspectionReport:null));
				info.AddValue("_skiipackFailureCause", (!this.MarkedForDeletion?_skiipackFailureCause:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ComponentInspectionReportSkiiPFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ComponentInspectionReportSkiiPFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ComponentInspectionReportSkiiPRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportSkiiPfailedComponent' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportSkiiPfailedComponent()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportSkiiPfailedComponentFields.ComponentInspectionReportSkiiPid, null, ComparisonOperator.Equal, this.ComponentInspectionReportSkiiPid));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportSkiiPnewComponent' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportSkiiPnewComponent()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportSkiiPnewComponentFields.ComponentInspectionReportSkiiPid, null, ComparisonOperator.Equal, this.ComponentInspectionReportSkiiPid));
			return bucket;
		}


		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer_____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP3Mwv521BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP3Mwv522BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP2Mwv526BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer__________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP2Mwv524BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer___________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP2Mwv525BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer__________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP3Mwv525xBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer___________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP3Mwv526xBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer_________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP2Mwv522BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer_______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP3Mwv523BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP3Mwv524xBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP3Mwv525yBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP3Mwv526yBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP3Mwv524yBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP2Mwv521BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiPclaimRelevantBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer_________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP2Mwv523BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP850Kwv525BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP850Kwv526BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP850Kwv520BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.SkiiP850Kwv524BooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReport()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportFields.ComponentInspectionReportId, null, ComparisonOperator.Equal, this.ComponentInspectionReportId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'SkiipackFailureCause' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSkiipackFailureCause()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiiPcauseId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity);
		}

		/// <summary>
		/// Creates the ITypeDefaultValue instance used to provide default values for value types which aren't of type nullable(of T)
		/// </summary>
		/// <returns></returns>
		protected override ITypeDefaultValue CreateTypeDefaultValueProvider()
		{
			return new TypeDefaultValue();
		}

		/// <summary>Creates a new instance of the factory related to this entity</summary>
		protected override IEntityFactory2 CreateEntityFactory()
		{
			return EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportSkiiPEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReportSkiiPfailedComponent);
			collectionsQueue.Enqueue(this._componentInspectionReportSkiiPnewComponent);

		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReportSkiiPfailedComponent = (EntityCollection<ComponentInspectionReportSkiiPfailedComponentEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportSkiiPnewComponent = (EntityCollection<ComponentInspectionReportSkiiPnewComponentEntity>) collectionsQueue.Dequeue();

		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReportSkiiPfailedComponent != null)
			{
				return true;
			}
			if (this._componentInspectionReportSkiiPnewComponent != null)
			{
				return true;
			}

			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportSkiiPfailedComponentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportSkiiPfailedComponentEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportSkiiPnewComponentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportSkiiPnewComponentEntityFactory))) : null);

		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("BooleanAnswer_____________", _booleanAnswer_____________);
			toReturn.Add("BooleanAnswer______________", _booleanAnswer______________);
			toReturn.Add("BooleanAnswer____________", _booleanAnswer____________);
			toReturn.Add("BooleanAnswer__________", _booleanAnswer__________);
			toReturn.Add("BooleanAnswer___________", _booleanAnswer___________);
			toReturn.Add("BooleanAnswer__________________", _booleanAnswer__________________);
			toReturn.Add("BooleanAnswer___________________", _booleanAnswer___________________);
			toReturn.Add("BooleanAnswer_________________", _booleanAnswer_________________);
			toReturn.Add("BooleanAnswer_______________", _booleanAnswer_______________);
			toReturn.Add("BooleanAnswer________________", _booleanAnswer________________);
			toReturn.Add("BooleanAnswer___", _booleanAnswer___);
			toReturn.Add("BooleanAnswer____", _booleanAnswer____);
			toReturn.Add("BooleanAnswer__", _booleanAnswer__);
			toReturn.Add("BooleanAnswer", _booleanAnswer);
			toReturn.Add("BooleanAnswer_", _booleanAnswer_);
			toReturn.Add("BooleanAnswer_________", _booleanAnswer_________);
			toReturn.Add("BooleanAnswer_______", _booleanAnswer_______);
			toReturn.Add("BooleanAnswer________", _booleanAnswer________);
			toReturn.Add("BooleanAnswer_____", _booleanAnswer_____);
			toReturn.Add("BooleanAnswer______", _booleanAnswer______);
			toReturn.Add("ComponentInspectionReport", _componentInspectionReport);
			toReturn.Add("SkiipackFailureCause", _skiipackFailureCause);
			toReturn.Add("ComponentInspectionReportSkiiPfailedComponent", _componentInspectionReportSkiiPfailedComponent);
			toReturn.Add("ComponentInspectionReportSkiiPnewComponent", _componentInspectionReportSkiiPnewComponent);


			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReportSkiiPfailedComponent!=null)
			{
				_componentInspectionReportSkiiPfailedComponent.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportSkiiPnewComponent!=null)
			{
				_componentInspectionReportSkiiPnewComponent.ActiveContext = base.ActiveContext;
			}

			if(_booleanAnswer_____________!=null)
			{
				_booleanAnswer_____________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer______________!=null)
			{
				_booleanAnswer______________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer____________!=null)
			{
				_booleanAnswer____________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer__________!=null)
			{
				_booleanAnswer__________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer___________!=null)
			{
				_booleanAnswer___________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer__________________!=null)
			{
				_booleanAnswer__________________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer___________________!=null)
			{
				_booleanAnswer___________________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer_________________!=null)
			{
				_booleanAnswer_________________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer_______________!=null)
			{
				_booleanAnswer_______________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer________________!=null)
			{
				_booleanAnswer________________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer___!=null)
			{
				_booleanAnswer___.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer____!=null)
			{
				_booleanAnswer____.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer__!=null)
			{
				_booleanAnswer__.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer!=null)
			{
				_booleanAnswer.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer_!=null)
			{
				_booleanAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer_________!=null)
			{
				_booleanAnswer_________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer_______!=null)
			{
				_booleanAnswer_______.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer________!=null)
			{
				_booleanAnswer________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer_____!=null)
			{
				_booleanAnswer_____.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer______!=null)
			{
				_booleanAnswer______.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReport!=null)
			{
				_componentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_skiipackFailureCause!=null)
			{
				_skiipackFailureCause.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReportSkiiPfailedComponent = null;
			_componentInspectionReportSkiiPnewComponent = null;

			_booleanAnswer_____________ = null;
			_booleanAnswer______________ = null;
			_booleanAnswer____________ = null;
			_booleanAnswer__________ = null;
			_booleanAnswer___________ = null;
			_booleanAnswer__________________ = null;
			_booleanAnswer___________________ = null;
			_booleanAnswer_________________ = null;
			_booleanAnswer_______________ = null;
			_booleanAnswer________________ = null;
			_booleanAnswer___ = null;
			_booleanAnswer____ = null;
			_booleanAnswer__ = null;
			_booleanAnswer = null;
			_booleanAnswer_ = null;
			_booleanAnswer_________ = null;
			_booleanAnswer_______ = null;
			_booleanAnswer________ = null;
			_booleanAnswer_____ = null;
			_booleanAnswer______ = null;
			_componentInspectionReport = null;
			_skiipackFailureCause = null;

			PerformDependencyInjection();
			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassMembers
			// __LLBLGENPRO_USER_CODE_REGION_END
			OnInitClassMembersComplete();
		}

		#region Custom Property Hashtable Setup
		/// <summary> Initializes the hashtables for the entity type and entity field custom properties. </summary>
		private static void SetupCustomPropertyHashtables()
		{
			_customProperties = new Dictionary<string, string>();
			_fieldsCustomProperties = new Dictionary<string, Dictionary<string, string>>();

			Dictionary<string, string> fieldHashtable = null;
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportSkiiPid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiPotherDamagedComponentsReplaced", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiPcauseId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiPquantityOfFailedModules", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP2Mwv521BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP2Mwv522BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP2Mwv523BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP2Mwv524BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP2Mwv525BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP2Mwv526BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP3Mwv521BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP3Mwv522BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP3Mwv523BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP3Mwv524xBooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP3Mwv524yBooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP3Mwv525xBooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP3Mwv525yBooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP3Mwv526xBooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP3Mwv526yBooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP850Kwv520BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP850Kwv524BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP850Kwv525BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiP850Kwv526BooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SkiiPclaimRelevantBooleanAnswerId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _booleanAnswer_____________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer_____________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer_____________, new PropertyChangedEventHandler( OnBooleanAnswer_____________PropertyChanged ), "BooleanAnswer_____________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv521BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP_____________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv521BooleanAnswerId } );		
			_booleanAnswer_____________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer_____________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer_____________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer_____________(true, true);
			_booleanAnswer_____________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer_____________, new PropertyChangedEventHandler( OnBooleanAnswer_____________PropertyChanged ), "BooleanAnswer_____________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv521BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer_____________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer______________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer______________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer______________, new PropertyChangedEventHandler( OnBooleanAnswer______________PropertyChanged ), "BooleanAnswer______________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv522BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP______________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv522BooleanAnswerId } );		
			_booleanAnswer______________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer______________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer______________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer______________(true, true);
			_booleanAnswer______________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer______________, new PropertyChangedEventHandler( OnBooleanAnswer______________PropertyChanged ), "BooleanAnswer______________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv522BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer______________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer____________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer____________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer____________, new PropertyChangedEventHandler( OnBooleanAnswer____________PropertyChanged ), "BooleanAnswer____________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv526BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP____________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv526BooleanAnswerId } );		
			_booleanAnswer____________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer____________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer____________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer____________(true, true);
			_booleanAnswer____________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer____________, new PropertyChangedEventHandler( OnBooleanAnswer____________PropertyChanged ), "BooleanAnswer____________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv526BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer____________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer__________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer__________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer__________, new PropertyChangedEventHandler( OnBooleanAnswer__________PropertyChanged ), "BooleanAnswer__________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv524BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP__________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv524BooleanAnswerId } );		
			_booleanAnswer__________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer__________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer__________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer__________(true, true);
			_booleanAnswer__________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer__________, new PropertyChangedEventHandler( OnBooleanAnswer__________PropertyChanged ), "BooleanAnswer__________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv524BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer__________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer___________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer___________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer___________, new PropertyChangedEventHandler( OnBooleanAnswer___________PropertyChanged ), "BooleanAnswer___________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv525BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP___________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv525BooleanAnswerId } );		
			_booleanAnswer___________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer___________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer___________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer___________(true, true);
			_booleanAnswer___________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer___________, new PropertyChangedEventHandler( OnBooleanAnswer___________PropertyChanged ), "BooleanAnswer___________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv525BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer___________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer__________________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer__________________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer__________________, new PropertyChangedEventHandler( OnBooleanAnswer__________________PropertyChanged ), "BooleanAnswer__________________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv525xBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP__________________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv525xBooleanAnswerId } );		
			_booleanAnswer__________________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer__________________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer__________________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer__________________(true, true);
			_booleanAnswer__________________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer__________________, new PropertyChangedEventHandler( OnBooleanAnswer__________________PropertyChanged ), "BooleanAnswer__________________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv525xBooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer__________________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer___________________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer___________________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer___________________, new PropertyChangedEventHandler( OnBooleanAnswer___________________PropertyChanged ), "BooleanAnswer___________________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv526xBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP___________________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv526xBooleanAnswerId } );		
			_booleanAnswer___________________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer___________________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer___________________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer___________________(true, true);
			_booleanAnswer___________________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer___________________, new PropertyChangedEventHandler( OnBooleanAnswer___________________PropertyChanged ), "BooleanAnswer___________________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv526xBooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer___________________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer_________________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer_________________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer_________________, new PropertyChangedEventHandler( OnBooleanAnswer_________________PropertyChanged ), "BooleanAnswer_________________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv522BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP_________________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv522BooleanAnswerId } );		
			_booleanAnswer_________________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer_________________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer_________________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer_________________(true, true);
			_booleanAnswer_________________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer_________________, new PropertyChangedEventHandler( OnBooleanAnswer_________________PropertyChanged ), "BooleanAnswer_________________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv522BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer_________________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer_______________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer_______________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer_______________, new PropertyChangedEventHandler( OnBooleanAnswer_______________PropertyChanged ), "BooleanAnswer_______________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv523BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP_______________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv523BooleanAnswerId } );		
			_booleanAnswer_______________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer_______________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer_______________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer_______________(true, true);
			_booleanAnswer_______________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer_______________, new PropertyChangedEventHandler( OnBooleanAnswer_______________PropertyChanged ), "BooleanAnswer_______________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv523BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer_______________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer________________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer________________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer________________, new PropertyChangedEventHandler( OnBooleanAnswer________________PropertyChanged ), "BooleanAnswer________________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv524xBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP________________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv524xBooleanAnswerId } );		
			_booleanAnswer________________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer________________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer________________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer________________(true, true);
			_booleanAnswer________________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer________________, new PropertyChangedEventHandler( OnBooleanAnswer________________PropertyChanged ), "BooleanAnswer________________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv524xBooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer________________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer___, new PropertyChangedEventHandler( OnBooleanAnswer___PropertyChanged ), "BooleanAnswer___", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv525yBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP___", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv525yBooleanAnswerId } );		
			_booleanAnswer___ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer___(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer___(true, true);
			_booleanAnswer___ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer___, new PropertyChangedEventHandler( OnBooleanAnswer___PropertyChanged ), "BooleanAnswer___", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv525yBooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer____, new PropertyChangedEventHandler( OnBooleanAnswer____PropertyChanged ), "BooleanAnswer____", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv526yBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP____", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv526yBooleanAnswerId } );		
			_booleanAnswer____ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer____(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer____(true, true);
			_booleanAnswer____ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer____, new PropertyChangedEventHandler( OnBooleanAnswer____PropertyChanged ), "BooleanAnswer____", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv526yBooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer__, new PropertyChangedEventHandler( OnBooleanAnswer__PropertyChanged ), "BooleanAnswer__", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv524yBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP__", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv524yBooleanAnswerId } );		
			_booleanAnswer__ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer__(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer__(true, true);
			_booleanAnswer__ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer__, new PropertyChangedEventHandler( OnBooleanAnswer__PropertyChanged ), "BooleanAnswer__", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv524yBooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv521BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv521BooleanAnswerId } );		
			_booleanAnswer = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer(true, true);
			_booleanAnswer = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv521BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer_, new PropertyChangedEventHandler( OnBooleanAnswer_PropertyChanged ), "BooleanAnswer_", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiPclaimRelevantBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP_", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiPclaimRelevantBooleanAnswerId } );		
			_booleanAnswer_ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer_(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer_(true, true);
			_booleanAnswer_ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer_, new PropertyChangedEventHandler( OnBooleanAnswer_PropertyChanged ), "BooleanAnswer_", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiPclaimRelevantBooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer_________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer_________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer_________, new PropertyChangedEventHandler( OnBooleanAnswer_________PropertyChanged ), "BooleanAnswer_________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv523BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP_________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv523BooleanAnswerId } );		
			_booleanAnswer_________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer_________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer_________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer_________(true, true);
			_booleanAnswer_________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer_________, new PropertyChangedEventHandler( OnBooleanAnswer_________PropertyChanged ), "BooleanAnswer_________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv523BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer_________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer_______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer_______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer_______, new PropertyChangedEventHandler( OnBooleanAnswer_______PropertyChanged ), "BooleanAnswer_______", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv525BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP_______", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv525BooleanAnswerId } );		
			_booleanAnswer_______ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer_______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer_______(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer_______(true, true);
			_booleanAnswer_______ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer_______, new PropertyChangedEventHandler( OnBooleanAnswer_______PropertyChanged ), "BooleanAnswer_______", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv525BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer_______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer________, new PropertyChangedEventHandler( OnBooleanAnswer________PropertyChanged ), "BooleanAnswer________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv526BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP________", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv526BooleanAnswerId } );		
			_booleanAnswer________ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer________(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer________(true, true);
			_booleanAnswer________ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer________, new PropertyChangedEventHandler( OnBooleanAnswer________PropertyChanged ), "BooleanAnswer________", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv526BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer_____, new PropertyChangedEventHandler( OnBooleanAnswer_____PropertyChanged ), "BooleanAnswer_____", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv520BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP_____", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv520BooleanAnswerId } );		
			_booleanAnswer_____ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer_____(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer_____(true, true);
			_booleanAnswer_____ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer_____, new PropertyChangedEventHandler( OnBooleanAnswer_____PropertyChanged ), "BooleanAnswer_____", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv520BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _booleanAnswer______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer______, new PropertyChangedEventHandler( OnBooleanAnswer______PropertyChanged ), "BooleanAnswer______", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv524BooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP______", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv524BooleanAnswerId } );		
			_booleanAnswer______ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer______(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer______(true, true);
			_booleanAnswer______ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer______, new PropertyChangedEventHandler( OnBooleanAnswer______PropertyChanged ), "BooleanAnswer______", ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv524BooleanAnswerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBooleanAnswer______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _componentInspectionReport</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncComponentInspectionReport(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportSkiiPEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.ComponentInspectionReportId } );		
			_componentInspectionReport = null;
		}

		/// <summary> setups the sync logic for member _componentInspectionReport</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncComponentInspectionReport(IEntity2 relatedEntity)
		{
			DesetupSyncComponentInspectionReport(true, true);
			_componentInspectionReport = (ComponentInspectionReportEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportSkiiPEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnComponentInspectionReportPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _skiipackFailureCause</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSkiipackFailureCause(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _skiipackFailureCause, new PropertyChangedEventHandler( OnSkiipackFailureCausePropertyChanged ), "SkiipackFailureCause", ComponentInspectionReportSkiiPEntity.Relations.SkiipackFailureCauseEntityUsingSkiiPcauseId, true, signalRelatedEntity, "ComponentInspectionReportSkiiP", resetFKFields, new int[] { (int)ComponentInspectionReportSkiiPFieldIndex.SkiiPcauseId } );		
			_skiipackFailureCause = null;
		}

		/// <summary> setups the sync logic for member _skiipackFailureCause</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSkiipackFailureCause(IEntity2 relatedEntity)
		{
			DesetupSyncSkiipackFailureCause(true, true);
			_skiipackFailureCause = (SkiipackFailureCauseEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _skiipackFailureCause, new PropertyChangedEventHandler( OnSkiipackFailureCausePropertyChanged ), "SkiipackFailureCause", ComponentInspectionReportSkiiPEntity.Relations.SkiipackFailureCauseEntityUsingSkiiPcauseId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSkiipackFailureCausePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ComponentInspectionReportSkiiPEntity</param>
		/// <param name="fields">Fields of this entity</param>
		protected virtual void InitClassEmpty(IValidator validator, IEntityFields2 fields)
		{
			OnInitializing();
			base.Fields = fields;
			base.IsNew=true;
			base.Validator = validator;
			InitClassMembers();

			
			// __LLBLGENPRO_USER_CODE_REGION_START InitClassEmpty
			// __LLBLGENPRO_USER_CODE_REGION_END

			OnInitialized();
		}

		#region Class Property Declarations
		/// <summary> The relations object holding all relations of this entity with other entity classes.</summary>
		public  static ComponentInspectionReportSkiiPRelations Relations
		{
			get	{ return new ComponentInspectionReportSkiiPRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportSkiiPfailedComponent' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportSkiiPfailedComponent
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportSkiiPfailedComponentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportSkiiPfailedComponentEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.ComponentInspectionReportSkiiPfailedComponentEntityUsingComponentInspectionReportSkiiPid, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPfailedComponentEntity, 0, null, null, null, null, "ComponentInspectionReportSkiiPfailedComponent", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportSkiiPnewComponent' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportSkiiPnewComponent
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportSkiiPnewComponentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportSkiiPnewComponentEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.ComponentInspectionReportSkiiPnewComponentEntityUsingComponentInspectionReportSkiiPid, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPnewComponentEntity, 0, null, null, null, null, "ComponentInspectionReportSkiiPnewComponent", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}


		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer_____________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv521BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer_____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer______________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv522BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer____________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv526BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer__________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv524BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer__________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer___________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv525BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer___________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer__________________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv525xBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer__________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer___________________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv526xBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer___________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer_________________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv522BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer_________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer_______________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv523BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer_______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer________________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv524xBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv525yBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv526yBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv524yBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv521BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiPclaimRelevantBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer_________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv523BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer_________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer_______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv525BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv526BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv520BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswer______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv524BooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReport
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SkiipackFailureCause' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSkiipackFailureCause
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SkiipackFailureCauseEntityFactory))),
					ComponentInspectionReportSkiiPEntity.Relations.SkiipackFailureCauseEntityUsingSkiiPcauseId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, (int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, 0, null, null, null, null, "SkiipackFailureCause", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ComponentInspectionReportSkiiPEntity.CustomProperties;}
		}

		/// <summary> The custom properties for the fields of this entity type. The returned Hashtable contains per fieldname a hashtable of name-value
		/// pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, Dictionary<string, string>> FieldsCustomProperties
		{
			get { return _fieldsCustomProperties;}
		}

		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType
		{
			get { return ComponentInspectionReportSkiiPEntity.FieldsCustomProperties;}
		}

		/// <summary> The ComponentInspectionReportSkiiPid property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."ComponentInspectionReportSkiiPId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ComponentInspectionReportSkiiPid
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.ComponentInspectionReportSkiiPid, true); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.ComponentInspectionReportSkiiPid, value); }
		}

		/// <summary> The ComponentInspectionReportId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."ComponentInspectionReportId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.ComponentInspectionReportId, true); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.ComponentInspectionReportId, value); }
		}

		/// <summary> The SkiiPotherDamagedComponentsReplaced property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiPOtherDamagedComponentsReplaced"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SkiiPotherDamagedComponentsReplaced
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiPotherDamagedComponentsReplaced, true); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiPotherDamagedComponentsReplaced, value); }
		}

		/// <summary> The SkiiPcauseId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiPCauseId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 SkiiPcauseId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiPcauseId, true); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiPcauseId, value); }
		}

		/// <summary> The SkiiPquantityOfFailedModules property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiPQuantityOfFailedModules"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 SkiiPquantityOfFailedModules
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiPquantityOfFailedModules, true); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiPquantityOfFailedModules, value); }
		}

		/// <summary> The SkiiP2Mwv521BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP2MWV521BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP2Mwv521BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv521BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv521BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP2Mwv522BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP2MWV522BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP2Mwv522BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv522BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv522BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP2Mwv523BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP2MWV523BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP2Mwv523BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv523BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv523BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP2Mwv524BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP2MWV524BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP2Mwv524BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv524BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv524BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP2Mwv525BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP2MWV525BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP2Mwv525BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv525BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv525BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP2Mwv526BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP2MWV526BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP2Mwv526BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv526BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP2Mwv526BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP3Mwv521BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP3MWV521BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP3Mwv521BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv521BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv521BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP3Mwv522BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP3MWV522BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP3Mwv522BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv522BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv522BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP3Mwv523BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP3MWV523BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP3Mwv523BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv523BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv523BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP3Mwv524xBooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP3MWV524xBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP3Mwv524xBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv524xBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv524xBooleanAnswerId, value); }
		}

		/// <summary> The SkiiP3Mwv524yBooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP3MWV524yBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP3Mwv524yBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv524yBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv524yBooleanAnswerId, value); }
		}

		/// <summary> The SkiiP3Mwv525xBooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP3MWV525xBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP3Mwv525xBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv525xBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv525xBooleanAnswerId, value); }
		}

		/// <summary> The SkiiP3Mwv525yBooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP3MWV525yBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP3Mwv525yBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv525yBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv525yBooleanAnswerId, value); }
		}

		/// <summary> The SkiiP3Mwv526xBooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP3MWV526xBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP3Mwv526xBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv526xBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv526xBooleanAnswerId, value); }
		}

		/// <summary> The SkiiP3Mwv526yBooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP3MWV526yBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP3Mwv526yBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv526yBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP3Mwv526yBooleanAnswerId, value); }
		}

		/// <summary> The SkiiP850Kwv520BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP850KWV520BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP850Kwv520BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv520BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv520BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP850Kwv524BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP850KWV524BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP850Kwv524BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv524BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv524BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP850Kwv525BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP850KWV525BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP850Kwv525BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv525BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv525BooleanAnswerId, value); }
		}

		/// <summary> The SkiiP850Kwv526BooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiP850KWV526BooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiP850Kwv526BooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv526BooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiP850Kwv526BooleanAnswerId, value); }
		}

		/// <summary> The SkiiPclaimRelevantBooleanAnswerId property of the Entity ComponentInspectionReportSkiiP<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportSkiiP"."SkiiPClaimRelevantBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> SkiiPclaimRelevantBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiPclaimRelevantBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportSkiiPFieldIndex.SkiiPclaimRelevantBooleanAnswerId, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportSkiiPfailedComponentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportSkiiPfailedComponentEntity))]
		public virtual EntityCollection<ComponentInspectionReportSkiiPfailedComponentEntity> ComponentInspectionReportSkiiPfailedComponent
		{
			get
			{
				if(_componentInspectionReportSkiiPfailedComponent==null)
				{
					_componentInspectionReportSkiiPfailedComponent = new EntityCollection<ComponentInspectionReportSkiiPfailedComponentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportSkiiPfailedComponentEntityFactory)));
					_componentInspectionReportSkiiPfailedComponent.SetContainingEntityInfo(this, "ComponentInspectionReportSkiiP");
				}
				return _componentInspectionReportSkiiPfailedComponent;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportSkiiPnewComponentEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportSkiiPnewComponentEntity))]
		public virtual EntityCollection<ComponentInspectionReportSkiiPnewComponentEntity> ComponentInspectionReportSkiiPnewComponent
		{
			get
			{
				if(_componentInspectionReportSkiiPnewComponent==null)
				{
					_componentInspectionReportSkiiPnewComponent = new EntityCollection<ComponentInspectionReportSkiiPnewComponentEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportSkiiPnewComponentEntityFactory)));
					_componentInspectionReportSkiiPnewComponent.SetContainingEntityInfo(this, "ComponentInspectionReportSkiiP");
				}
				return _componentInspectionReportSkiiPnewComponent;
			}
		}


		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer_____________
		{
			get
			{
				return _booleanAnswer_____________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer_____________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer_____________ != null)
						{
							_booleanAnswer_____________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP_____________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP_____________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer______________
		{
			get
			{
				return _booleanAnswer______________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer______________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer______________ != null)
						{
							_booleanAnswer______________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP______________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP______________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer____________
		{
			get
			{
				return _booleanAnswer____________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer____________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer____________ != null)
						{
							_booleanAnswer____________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP____________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP____________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer__________
		{
			get
			{
				return _booleanAnswer__________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer__________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer__________ != null)
						{
							_booleanAnswer__________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP__________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP__________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer___________
		{
			get
			{
				return _booleanAnswer___________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer___________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer___________ != null)
						{
							_booleanAnswer___________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP___________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP___________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer__________________
		{
			get
			{
				return _booleanAnswer__________________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer__________________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer__________________ != null)
						{
							_booleanAnswer__________________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP__________________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP__________________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer___________________
		{
			get
			{
				return _booleanAnswer___________________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer___________________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer___________________ != null)
						{
							_booleanAnswer___________________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP___________________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP___________________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer_________________
		{
			get
			{
				return _booleanAnswer_________________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer_________________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer_________________ != null)
						{
							_booleanAnswer_________________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP_________________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP_________________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer_______________
		{
			get
			{
				return _booleanAnswer_______________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer_______________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer_______________ != null)
						{
							_booleanAnswer_______________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP_______________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP_______________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer________________
		{
			get
			{
				return _booleanAnswer________________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer________________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer________________ != null)
						{
							_booleanAnswer________________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP________________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP________________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer___
		{
			get
			{
				return _booleanAnswer___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer___(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer___ != null)
						{
							_booleanAnswer___.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer____
		{
			get
			{
				return _booleanAnswer____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer____(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer____ != null)
						{
							_booleanAnswer____.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer__
		{
			get
			{
				return _booleanAnswer__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer__(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer__ != null)
						{
							_booleanAnswer__.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP__");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer
		{
			get
			{
				return _booleanAnswer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer != null)
						{
							_booleanAnswer.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer_
		{
			get
			{
				return _booleanAnswer_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer_(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer_ != null)
						{
							_booleanAnswer_.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer_________
		{
			get
			{
				return _booleanAnswer_________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer_________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer_________ != null)
						{
							_booleanAnswer_________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP_________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP_________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer_______
		{
			get
			{
				return _booleanAnswer_______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer_______(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer_______ != null)
						{
							_booleanAnswer_______.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP_______");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP_______");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer________
		{
			get
			{
				return _booleanAnswer________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer________(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer________ != null)
						{
							_booleanAnswer________.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer_____
		{
			get
			{
				return _booleanAnswer_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer_____ != null)
						{
							_booleanAnswer_____.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP_____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP_____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BooleanAnswerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BooleanAnswerEntity BooleanAnswer______
		{
			get
			{
				return _booleanAnswer______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBooleanAnswer______(value);
				}
				else
				{
					if(value==null)
					{
						if(_booleanAnswer______ != null)
						{
							_booleanAnswer______.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP______");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP______");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ComponentInspectionReportEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ComponentInspectionReportEntity ComponentInspectionReport
		{
			get
			{
				return _componentInspectionReport;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncComponentInspectionReport(value);
				}
				else
				{
					if(value==null)
					{
						if(_componentInspectionReport != null)
						{
							_componentInspectionReport.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'SkiipackFailureCauseEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual SkiipackFailureCauseEntity SkiipackFailureCause
		{
			get
			{
				return _skiipackFailureCause;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncSkiipackFailureCause(value);
				}
				else
				{
					if(value==null)
					{
						if(_skiipackFailureCause != null)
						{
							_skiipackFailureCause.UnsetRelatedEntity(this, "ComponentInspectionReportSkiiP");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportSkiiP");
					}
				}
			}
		}

	
		
		/// <summary> Gets the type of the hierarchy this entity is in. </summary>
		protected override InheritanceHierarchyType LLBLGenProIsInHierarchyOfType
		{
			get { return InheritanceHierarchyType.None;}
		}
		
		/// <summary> Gets or sets a value indicating whether this entity is a subtype</summary>
		protected override bool LLBLGenProIsSubType
		{
			get { return false;}
		}
		
		/// <summary>Returns the EntityType enum value for this entity.</summary>
		[Browsable(false), XmlIgnore]
		public override int LLBLGenProEntityTypeValue 
		{ 
			get { return (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity; }
		}
		#endregion


		#region Custom Entity code
		
		// __LLBLGENPRO_USER_CODE_REGION_START CustomEntityCode
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Included code

		#endregion
	}
}
