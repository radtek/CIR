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
	/// Entity class which represents the entity 'SkiipackFailureCause'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class SkiipackFailureCauseEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportSkiiPEntity> _componentInspectionReportSkiiP;
		private EntityCollection<SkiipackFailureCauseEntity> _skiipackFailureCause_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP______________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP____________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP__________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP___________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP________________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP___;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP____;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP__;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP_______;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP_________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP_____;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportSkiiP______;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportSkiiP;
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
			/// <summary>Member name SkiipackFailureCause</summary>
			public static readonly string SkiipackFailureCause = "SkiipackFailureCause";
			/// <summary>Member name ComponentInspectionReportSkiiP</summary>
			public static readonly string ComponentInspectionReportSkiiP = "ComponentInspectionReportSkiiP";
			/// <summary>Member name SkiipackFailureCause_</summary>
			public static readonly string SkiipackFailureCause_ = "SkiipackFailureCause_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP______________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP______________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP______________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP____________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP____________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP____________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP________________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP________________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP________________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP___</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP___ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP___";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP____</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP____ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP____";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP__</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP__ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP__";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP_</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP_ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportSkiiP______</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportSkiiP______ = "BooleanAnswerCollectionViaComponentInspectionReportSkiiP______";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportSkiiP</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportSkiiP = "ComponentInspectionReportCollectionViaComponentInspectionReportSkiiP";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static SkiipackFailureCauseEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public SkiipackFailureCauseEntity():base("SkiipackFailureCauseEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public SkiipackFailureCauseEntity(IEntityFields2 fields):base("SkiipackFailureCauseEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this SkiipackFailureCauseEntity</param>
		public SkiipackFailureCauseEntity(IValidator validator):base("SkiipackFailureCauseEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="skiipackFailureCauseId">PK value for SkiipackFailureCause which data should be fetched into this SkiipackFailureCause object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SkiipackFailureCauseEntity(System.Int64 skiipackFailureCauseId):base("SkiipackFailureCauseEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.SkiipackFailureCauseId = skiipackFailureCauseId;
		}

		/// <summary> CTor</summary>
		/// <param name="skiipackFailureCauseId">PK value for SkiipackFailureCause which data should be fetched into this SkiipackFailureCause object</param>
		/// <param name="validator">The custom validator object for this SkiipackFailureCauseEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public SkiipackFailureCauseEntity(System.Int64 skiipackFailureCauseId, IValidator validator):base("SkiipackFailureCauseEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.SkiipackFailureCauseId = skiipackFailureCauseId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected SkiipackFailureCauseEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReportSkiiP = (EntityCollection<ComponentInspectionReportSkiiPEntity>)info.GetValue("_componentInspectionReportSkiiP", typeof(EntityCollection<ComponentInspectionReportSkiiPEntity>));
				_skiipackFailureCause_ = (EntityCollection<SkiipackFailureCauseEntity>)info.GetValue("_skiipackFailureCause_", typeof(EntityCollection<SkiipackFailureCauseEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP___ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP___", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP____ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP____", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP__ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP__", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP______ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP______", typeof(EntityCollection<BooleanAnswerEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportSkiiP = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportSkiiP", typeof(EntityCollection<ComponentInspectionReportEntity>));
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
			switch((SkiipackFailureCauseFieldIndex)fieldIndex)
			{
				case SkiipackFailureCauseFieldIndex.ParentSkiipackFailureCauseId:
					DesetupSyncSkiipackFailureCause(true, false);
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
				case "SkiipackFailureCause":
					this.SkiipackFailureCause = (SkiipackFailureCauseEntity)entity;
					break;
				case "ComponentInspectionReportSkiiP":
					this.ComponentInspectionReportSkiiP.Add((ComponentInspectionReportSkiiPEntity)entity);
					break;
				case "SkiipackFailureCause_":
					this.SkiipackFailureCause_.Add((SkiipackFailureCauseEntity)entity);
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP______________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP______________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP______________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP______________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP____________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP____________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP____________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP____________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP________________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP________________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP________________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP________________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP___":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP___.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP___.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP___.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP____":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP____.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP____.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP____.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP__":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP__.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP__.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP__.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportSkiiP______":
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP______.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP______.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportSkiiP______.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportSkiiP":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportSkiiP.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportSkiiP.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportSkiiP.IsReadOnly = true;
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
				case "SkiipackFailureCause":
					SetupSyncSkiipackFailureCause(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportSkiiP":
					this.ComponentInspectionReportSkiiP.Add((ComponentInspectionReportSkiiPEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "SkiipackFailureCause_":
					this.SkiipackFailureCause_.Add((SkiipackFailureCauseEntity)relatedEntity);
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
				case "SkiipackFailureCause":
					DesetupSyncSkiipackFailureCause(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportSkiiP":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportSkiiP, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "SkiipackFailureCause_":
					base.PerformRelatedEntityRemoval(this.SkiipackFailureCause_, relatedEntity, signalRelatedEntityManyToOne);
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
			toReturn.Add(this.ComponentInspectionReportSkiiP);
			toReturn.Add(this.SkiipackFailureCause_);

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
				info.AddValue("_componentInspectionReportSkiiP", ((_componentInspectionReportSkiiP!=null) && (_componentInspectionReportSkiiP.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportSkiiP:null);
				info.AddValue("_skiipackFailureCause_", ((_skiipackFailureCause_!=null) && (_skiipackFailureCause_.Count>0) && !this.MarkedForDeletion)?_skiipackFailureCause_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP___", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP___!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP___.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP___:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP____", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP____!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP____.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP____:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP__", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP__!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP__.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP__:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP_!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP_.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportSkiiP______", ((_booleanAnswerCollectionViaComponentInspectionReportSkiiP______!=null) && (_booleanAnswerCollectionViaComponentInspectionReportSkiiP______.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportSkiiP______:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportSkiiP", ((_componentInspectionReportCollectionViaComponentInspectionReportSkiiP!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportSkiiP.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportSkiiP:null);
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
		public bool TestOriginalFieldValueForNull(SkiipackFailureCauseFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(SkiipackFailureCauseFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new SkiipackFailureCauseRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportSkiiP' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportSkiiP()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportSkiiPFields.SkiiPcauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'SkiipackFailureCause' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSkiipackFailureCause_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.ParentSkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv521BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv522BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv526BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP__________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv524BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP___________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv525BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv525xBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv526xBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv522BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv523BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv524xBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv525yBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv526yBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv524yBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv521BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiPclaimRelevantBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv525BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv526BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP_________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv523BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv520BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportSkiiP______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv524BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportSkiiP()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportSkiiPEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.SkiipackFailureCauseId, "SkiipackFailureCauseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'SkiipackFailureCause' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSkiipackFailureCause()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SkiipackFailureCauseFields.SkiipackFailureCauseId, null, ComparisonOperator.Equal, this.ParentSkiipackFailureCauseId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(SkiipackFailureCauseEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReportSkiiP);
			collectionsQueue.Enqueue(this._skiipackFailureCause_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP______________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP____________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP__________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP___________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP________________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP___);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP____);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP__);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_______);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_____);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportSkiiP______);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportSkiiP);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReportSkiiP = (EntityCollection<ComponentInspectionReportSkiiPEntity>) collectionsQueue.Dequeue();
			this._skiipackFailureCause_ = (EntityCollection<SkiipackFailureCauseEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP______________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP____________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP__________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP___________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP________________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP___ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP____ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP__ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_______ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_____ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportSkiiP______ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportSkiiP = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReportSkiiP != null)
			{
				return true;
			}
			if (this._skiipackFailureCause_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP______________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP____________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP__________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP___________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP________________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP___ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP____ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP__ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_______ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP_____ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportSkiiP______ != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportSkiiP != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportSkiiPEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportSkiiPEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<SkiipackFailureCauseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SkiipackFailureCauseEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("SkiipackFailureCause", _skiipackFailureCause);
			toReturn.Add("ComponentInspectionReportSkiiP", _componentInspectionReportSkiiP);
			toReturn.Add("SkiipackFailureCause_", _skiipackFailureCause_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP______________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP______________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP____________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP____________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP__________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP___________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP________________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP________________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP___", _booleanAnswerCollectionViaComponentInspectionReportSkiiP___);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP____", _booleanAnswerCollectionViaComponentInspectionReportSkiiP____);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP__", _booleanAnswerCollectionViaComponentInspectionReportSkiiP__);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP", _booleanAnswerCollectionViaComponentInspectionReportSkiiP);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP_", _booleanAnswerCollectionViaComponentInspectionReportSkiiP_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______", _booleanAnswerCollectionViaComponentInspectionReportSkiiP_______);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________", _booleanAnswerCollectionViaComponentInspectionReportSkiiP_________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____", _booleanAnswerCollectionViaComponentInspectionReportSkiiP_____);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportSkiiP______", _booleanAnswerCollectionViaComponentInspectionReportSkiiP______);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportSkiiP", _componentInspectionReportCollectionViaComponentInspectionReportSkiiP);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReportSkiiP!=null)
			{
				_componentInspectionReportSkiiP.ActiveContext = base.ActiveContext;
			}
			if(_skiipackFailureCause_!=null)
			{
				_skiipackFailureCause_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP___!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP___.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP____!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP____.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP__!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP__.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP______!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportSkiiP______.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportSkiiP!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportSkiiP.ActiveContext = base.ActiveContext;
			}
			if(_skiipackFailureCause!=null)
			{
				_skiipackFailureCause.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReportSkiiP = null;
			_skiipackFailureCause_ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP___ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP____ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP__ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP_ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____ = null;
			_booleanAnswerCollectionViaComponentInspectionReportSkiiP______ = null;
			_componentInspectionReportCollectionViaComponentInspectionReportSkiiP = null;
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

			_fieldsCustomProperties.Add("SkiipackFailureCauseId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentSkiipackFailureCauseId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _skiipackFailureCause</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSkiipackFailureCause(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _skiipackFailureCause, new PropertyChangedEventHandler( OnSkiipackFailureCausePropertyChanged ), "SkiipackFailureCause", SkiipackFailureCauseEntity.Relations.SkiipackFailureCauseEntityUsingSkiipackFailureCauseIdParentSkiipackFailureCauseId, true, signalRelatedEntity, "SkiipackFailureCause_", resetFKFields, new int[] { (int)SkiipackFailureCauseFieldIndex.ParentSkiipackFailureCauseId } );		
			_skiipackFailureCause = null;
		}

		/// <summary> setups the sync logic for member _skiipackFailureCause</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSkiipackFailureCause(IEntity2 relatedEntity)
		{
			DesetupSyncSkiipackFailureCause(true, true);
			_skiipackFailureCause = (SkiipackFailureCauseEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _skiipackFailureCause, new PropertyChangedEventHandler( OnSkiipackFailureCausePropertyChanged ), "SkiipackFailureCause", SkiipackFailureCauseEntity.Relations.SkiipackFailureCauseEntityUsingSkiipackFailureCauseIdParentSkiipackFailureCauseId, true, new string[] {  } );
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
		/// <param name="validator">The validator object for this SkiipackFailureCauseEntity</param>
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
		public  static SkiipackFailureCauseRelations Relations
		{
			get	{ return new SkiipackFailureCauseRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportSkiiP' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportSkiiP
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportSkiiPEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportSkiiPEntityFactory))),
					SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, 
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportSkiiPEntity, 0, null, null, null, null, "ComponentInspectionReportSkiiP", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'SkiipackFailureCause' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSkiipackFailureCause_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<SkiipackFailureCauseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SkiipackFailureCauseEntityFactory))),
					SkiipackFailureCauseEntity.Relations.SkiipackFailureCauseEntityUsingParentSkiipackFailureCauseId, 
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, 0, null, null, null, null, "SkiipackFailureCause_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv521BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP______________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv522BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP____________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv526BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP__________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv524BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP___________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv525BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv525xBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv526xBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv522BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv523BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP________________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv524xBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv525yBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv526yBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP3Mwv524yBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv521BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiPclaimRelevantBooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv525BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv526BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP_________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP2Mwv523BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv520BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportSkiiP______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.BooleanAnswerEntityUsingSkiiP850Kwv524BooleanAnswerId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportSkiiP______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportSkiiP
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportSkiiP_");
				relations.Add(SkiipackFailureCauseEntity.Relations.ComponentInspectionReportSkiiPEntityUsingSkiiPcauseId, "SkiipackFailureCauseEntity__", "ComponentInspectionReportSkiiP_", JoinHint.None);
				relations.Add(ComponentInspectionReportSkiiPEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportSkiiP_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportSkiiP", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					SkiipackFailureCauseEntity.Relations.SkiipackFailureCauseEntityUsingSkiipackFailureCauseIdParentSkiipackFailureCauseId, 
					(int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, (int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity, 0, null, null, null, null, "SkiipackFailureCause", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return SkiipackFailureCauseEntity.CustomProperties;}
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
			get { return SkiipackFailureCauseEntity.FieldsCustomProperties;}
		}

		/// <summary> The SkiipackFailureCauseId property of the Entity SkiipackFailureCause<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "SkiipackFailureCause"."SkiipackFailureCauseId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 SkiipackFailureCauseId
		{
			get { return (System.Int64)GetValue((int)SkiipackFailureCauseFieldIndex.SkiipackFailureCauseId, true); }
			set	{ SetValue((int)SkiipackFailureCauseFieldIndex.SkiipackFailureCauseId, value); }
		}

		/// <summary> The Name property of the Entity SkiipackFailureCause<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "SkiipackFailureCause"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)SkiipackFailureCauseFieldIndex.Name, true); }
			set	{ SetValue((int)SkiipackFailureCauseFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity SkiipackFailureCause<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "SkiipackFailureCause"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)SkiipackFailureCauseFieldIndex.LanguageId, true); }
			set	{ SetValue((int)SkiipackFailureCauseFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentSkiipackFailureCauseId property of the Entity SkiipackFailureCause<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "SkiipackFailureCause"."ParentSkiipackFailureCauseId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentSkiipackFailureCauseId
		{
			get { return (Nullable<System.Int64>)GetValue((int)SkiipackFailureCauseFieldIndex.ParentSkiipackFailureCauseId, false); }
			set	{ SetValue((int)SkiipackFailureCauseFieldIndex.ParentSkiipackFailureCauseId, value); }
		}

		/// <summary> The Sort property of the Entity SkiipackFailureCause<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "SkiipackFailureCause"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)SkiipackFailureCauseFieldIndex.Sort, true); }
			set	{ SetValue((int)SkiipackFailureCauseFieldIndex.Sort, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportSkiiPEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportSkiiPEntity))]
		public virtual EntityCollection<ComponentInspectionReportSkiiPEntity> ComponentInspectionReportSkiiP
		{
			get
			{
				if(_componentInspectionReportSkiiP==null)
				{
					_componentInspectionReportSkiiP = new EntityCollection<ComponentInspectionReportSkiiPEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportSkiiPEntityFactory)));
					_componentInspectionReportSkiiP.SetContainingEntityInfo(this, "SkiipackFailureCause");
				}
				return _componentInspectionReportSkiiP;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'SkiipackFailureCauseEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(SkiipackFailureCauseEntity))]
		public virtual EntityCollection<SkiipackFailureCauseEntity> SkiipackFailureCause_
		{
			get
			{
				if(_skiipackFailureCause_==null)
				{
					_skiipackFailureCause_ = new EntityCollection<SkiipackFailureCauseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(SkiipackFailureCauseEntityFactory)));
					_skiipackFailureCause_.SetContainingEntityInfo(this, "SkiipackFailureCause");
				}
				return _skiipackFailureCause_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP_____________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP______________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP______________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP______________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP____________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP____________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP____________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP__________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP___________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP__________________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP__________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP___________________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP___________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP_________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP_______________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP________________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP________________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP___
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP___==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP___ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP___.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP____
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP____==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP____ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP____.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP__
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP__==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP__ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP__.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP_
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP_______
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_______.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP_________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP_________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP_____
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP_____.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportSkiiP______
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportSkiiP______==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP______ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportSkiiP______.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportSkiiP______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportSkiiP
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportSkiiP==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportSkiiP = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportSkiiP.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportSkiiP;
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
							_skiipackFailureCause.UnsetRelatedEntity(this, "SkiipackFailureCause_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "SkiipackFailureCause_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.SkiipackFailureCauseEntity; }
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
