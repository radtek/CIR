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
	/// Entity class which represents the entity 'ComponentInspectionReportGearbox'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ComponentInspectionReportGearboxEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private BearingErrorEntity _bearingError___;
		private BearingErrorEntity _bearingError____;
		private BearingErrorEntity _bearingError_____;
		private BearingErrorEntity _bearingError;
		private BearingErrorEntity _bearingError_;
		private BearingErrorEntity _bearingError__;
		private BearingPosEntity _bearingPos____;
		private BearingPosEntity _bearingPos_____;
		private BearingPosEntity _bearingPos___;
		private BearingPosEntity _bearingPos;
		private BearingPosEntity _bearingPos_;
		private BearingPosEntity _bearingPos__;
		private BearingTypeEntity _bearingType;
		private BearingTypeEntity _bearingType_____;
		private BearingTypeEntity _bearingType____;
		private BearingTypeEntity _bearingType___;
		private BearingTypeEntity _bearingType__;
		private BearingTypeEntity _bearingType_;
		private BooleanAnswerEntity _booleanAnswer_;
		private BooleanAnswerEntity _booleanAnswer;
		private ComponentInspectionReportEntity _componentInspectionReport;
		private CouplingEntity _coupling;
		private DamageDecisionEntity _damageDecision____________;
		private DamageDecisionEntity _damageDecision_____________;
		private DamageDecisionEntity _damageDecision__________;
		private DamageDecisionEntity _damageDecision___________;
		private DamageDecisionEntity _damageDecision_______________;
		private DamageDecisionEntity _damageDecision________________;
		private DamageDecisionEntity _damageDecision_________________;
		private DamageDecisionEntity _damageDecision______________;
		private DamageDecisionEntity _damageDecision___;
		private DamageDecisionEntity _damageDecision__;
		private DamageDecisionEntity _damageDecision____;
		private DamageDecisionEntity _damageDecision_____;
		private DamageDecisionEntity _damageDecision________;
		private DamageDecisionEntity _damageDecision_________;
		private DamageDecisionEntity _damageDecision______;
		private DamageDecisionEntity _damageDecision_______;
		private DamageDecisionEntity _damageDecision__________________;
		private DamageDecisionEntity _damageDecision_;
		private DamageDecisionEntity _damageDecision;
		private DamageDecisionEntity _damageDecision___________________;
		private DamageDecisionEntity _damageDecision____________________;
		private DebrisGearboxEntity _debrisGearbox;
		private DebrisOnMagnetEntity _debrisOnMagnet;
		private ElectricalPumpEntity _electricalPump;
		private FilterBlockTypeEntity _filterBlockType;
		private GearboxManufacturerEntity _gearboxManufacturer;
		private GearboxRevisionEntity _gearboxRevision;
		private GearboxTypeEntity _gearboxType;
		private GearErrorEntity _gearError___________;
		private GearErrorEntity _gearError_______;
		private GearErrorEntity _gearError________;
		private GearErrorEntity _gearError_____;
		private GearErrorEntity _gearError______;
		private GearErrorEntity _gearError____________;
		private GearErrorEntity _gearError_____________;
		private GearErrorEntity _gearError_________;
		private GearErrorEntity _gearError__________;
		private GearErrorEntity _gearError__;
		private GearErrorEntity _gearError______________;
		private GearErrorEntity _gearError____;
		private GearErrorEntity _gearError___;
		private GearErrorEntity _gearError;
		private GearErrorEntity _gearError_;
		private GearTypeEntity _gearType________;
		private GearTypeEntity _gearType__________;
		private GearTypeEntity _gearType_________;
		private GearTypeEntity _gearType_____;
		private GearTypeEntity _gearType______________;
		private GearTypeEntity _gearType____;
		private GearTypeEntity _gearType____________;
		private GearTypeEntity _gearType_____________;
		private GearTypeEntity _gearType__;
		private GearTypeEntity _gearType_;
		private GearTypeEntity _gearType;
		private GearTypeEntity _gearType___;
		private GearTypeEntity _gearType_______;
		private GearTypeEntity _gearType______;
		private GearTypeEntity _gearType___________;
		private GeneratorManufacturerEntity _generatorManufacturer_;
		private GeneratorManufacturerEntity _generatorManufacturer;
		private HousingErrorEntity _housingError_____;
		private HousingErrorEntity _housingError____;
		private HousingErrorEntity _housingError___;
		private HousingErrorEntity _housingError;
		private HousingErrorEntity _housingError_;
		private HousingErrorEntity _housingError__;
		private InlineFilterEntity _inlineFilter;
		private MagnetPosEntity _magnetPos;
		private MechanicalOilPumpEntity _mechanicalOilPump;
		private NoiseEntity _noise;
		private OilLevelEntity _oilLevel;
		private OilTypeEntity _oilType;
		private OverallGearboxConditionEntity _overallGearboxCondition;
		private ShaftErrorEntity _shaftError__;
		private ShaftErrorEntity _shaftError___;
		private ShaftErrorEntity _shaftError;
		private ShaftErrorEntity _shaftError_;
		private ShaftTypeEntity _shaftType___;
		private ShaftTypeEntity _shaftType__;
		private ShaftTypeEntity _shaftType_;
		private ShaftTypeEntity _shaftType;
		private ShrinkElementEntity _shrinkElement;
		private VibrationsEntity _vibrations;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name BearingError___</summary>
			public static readonly string BearingError___ = "BearingError___";
			/// <summary>Member name BearingError____</summary>
			public static readonly string BearingError____ = "BearingError____";
			/// <summary>Member name BearingError_____</summary>
			public static readonly string BearingError_____ = "BearingError_____";
			/// <summary>Member name BearingError</summary>
			public static readonly string BearingError = "BearingError";
			/// <summary>Member name BearingError_</summary>
			public static readonly string BearingError_ = "BearingError_";
			/// <summary>Member name BearingError__</summary>
			public static readonly string BearingError__ = "BearingError__";
			/// <summary>Member name BearingPos____</summary>
			public static readonly string BearingPos____ = "BearingPos____";
			/// <summary>Member name BearingPos_____</summary>
			public static readonly string BearingPos_____ = "BearingPos_____";
			/// <summary>Member name BearingPos___</summary>
			public static readonly string BearingPos___ = "BearingPos___";
			/// <summary>Member name BearingPos</summary>
			public static readonly string BearingPos = "BearingPos";
			/// <summary>Member name BearingPos_</summary>
			public static readonly string BearingPos_ = "BearingPos_";
			/// <summary>Member name BearingPos__</summary>
			public static readonly string BearingPos__ = "BearingPos__";
			/// <summary>Member name BearingType</summary>
			public static readonly string BearingType = "BearingType";
			/// <summary>Member name BearingType_____</summary>
			public static readonly string BearingType_____ = "BearingType_____";
			/// <summary>Member name BearingType____</summary>
			public static readonly string BearingType____ = "BearingType____";
			/// <summary>Member name BearingType___</summary>
			public static readonly string BearingType___ = "BearingType___";
			/// <summary>Member name BearingType__</summary>
			public static readonly string BearingType__ = "BearingType__";
			/// <summary>Member name BearingType_</summary>
			public static readonly string BearingType_ = "BearingType_";
			/// <summary>Member name BooleanAnswer_</summary>
			public static readonly string BooleanAnswer_ = "BooleanAnswer_";
			/// <summary>Member name BooleanAnswer</summary>
			public static readonly string BooleanAnswer = "BooleanAnswer";
			/// <summary>Member name ComponentInspectionReport</summary>
			public static readonly string ComponentInspectionReport = "ComponentInspectionReport";
			/// <summary>Member name Coupling</summary>
			public static readonly string Coupling = "Coupling";
			/// <summary>Member name DamageDecision____________</summary>
			public static readonly string DamageDecision____________ = "DamageDecision____________";
			/// <summary>Member name DamageDecision_____________</summary>
			public static readonly string DamageDecision_____________ = "DamageDecision_____________";
			/// <summary>Member name DamageDecision__________</summary>
			public static readonly string DamageDecision__________ = "DamageDecision__________";
			/// <summary>Member name DamageDecision___________</summary>
			public static readonly string DamageDecision___________ = "DamageDecision___________";
			/// <summary>Member name DamageDecision_______________</summary>
			public static readonly string DamageDecision_______________ = "DamageDecision_______________";
			/// <summary>Member name DamageDecision________________</summary>
			public static readonly string DamageDecision________________ = "DamageDecision________________";
			/// <summary>Member name DamageDecision_________________</summary>
			public static readonly string DamageDecision_________________ = "DamageDecision_________________";
			/// <summary>Member name DamageDecision______________</summary>
			public static readonly string DamageDecision______________ = "DamageDecision______________";
			/// <summary>Member name DamageDecision___</summary>
			public static readonly string DamageDecision___ = "DamageDecision___";
			/// <summary>Member name DamageDecision__</summary>
			public static readonly string DamageDecision__ = "DamageDecision__";
			/// <summary>Member name DamageDecision____</summary>
			public static readonly string DamageDecision____ = "DamageDecision____";
			/// <summary>Member name DamageDecision_____</summary>
			public static readonly string DamageDecision_____ = "DamageDecision_____";
			/// <summary>Member name DamageDecision________</summary>
			public static readonly string DamageDecision________ = "DamageDecision________";
			/// <summary>Member name DamageDecision_________</summary>
			public static readonly string DamageDecision_________ = "DamageDecision_________";
			/// <summary>Member name DamageDecision______</summary>
			public static readonly string DamageDecision______ = "DamageDecision______";
			/// <summary>Member name DamageDecision_______</summary>
			public static readonly string DamageDecision_______ = "DamageDecision_______";
			/// <summary>Member name DamageDecision__________________</summary>
			public static readonly string DamageDecision__________________ = "DamageDecision__________________";
			/// <summary>Member name DamageDecision_</summary>
			public static readonly string DamageDecision_ = "DamageDecision_";
			/// <summary>Member name DamageDecision</summary>
			public static readonly string DamageDecision = "DamageDecision";
			/// <summary>Member name DamageDecision___________________</summary>
			public static readonly string DamageDecision___________________ = "DamageDecision___________________";
			/// <summary>Member name DamageDecision____________________</summary>
			public static readonly string DamageDecision____________________ = "DamageDecision____________________";
			/// <summary>Member name DebrisGearbox</summary>
			public static readonly string DebrisGearbox = "DebrisGearbox";
			/// <summary>Member name DebrisOnMagnet</summary>
			public static readonly string DebrisOnMagnet = "DebrisOnMagnet";
			/// <summary>Member name ElectricalPump</summary>
			public static readonly string ElectricalPump = "ElectricalPump";
			/// <summary>Member name FilterBlockType</summary>
			public static readonly string FilterBlockType = "FilterBlockType";
			/// <summary>Member name GearboxManufacturer</summary>
			public static readonly string GearboxManufacturer = "GearboxManufacturer";
			/// <summary>Member name GearboxRevision</summary>
			public static readonly string GearboxRevision = "GearboxRevision";
			/// <summary>Member name GearboxType</summary>
			public static readonly string GearboxType = "GearboxType";
			/// <summary>Member name GearError___________</summary>
			public static readonly string GearError___________ = "GearError___________";
			/// <summary>Member name GearError_______</summary>
			public static readonly string GearError_______ = "GearError_______";
			/// <summary>Member name GearError________</summary>
			public static readonly string GearError________ = "GearError________";
			/// <summary>Member name GearError_____</summary>
			public static readonly string GearError_____ = "GearError_____";
			/// <summary>Member name GearError______</summary>
			public static readonly string GearError______ = "GearError______";
			/// <summary>Member name GearError____________</summary>
			public static readonly string GearError____________ = "GearError____________";
			/// <summary>Member name GearError_____________</summary>
			public static readonly string GearError_____________ = "GearError_____________";
			/// <summary>Member name GearError_________</summary>
			public static readonly string GearError_________ = "GearError_________";
			/// <summary>Member name GearError__________</summary>
			public static readonly string GearError__________ = "GearError__________";
			/// <summary>Member name GearError__</summary>
			public static readonly string GearError__ = "GearError__";
			/// <summary>Member name GearError______________</summary>
			public static readonly string GearError______________ = "GearError______________";
			/// <summary>Member name GearError____</summary>
			public static readonly string GearError____ = "GearError____";
			/// <summary>Member name GearError___</summary>
			public static readonly string GearError___ = "GearError___";
			/// <summary>Member name GearError</summary>
			public static readonly string GearError = "GearError";
			/// <summary>Member name GearError_</summary>
			public static readonly string GearError_ = "GearError_";
			/// <summary>Member name GearType________</summary>
			public static readonly string GearType________ = "GearType________";
			/// <summary>Member name GearType__________</summary>
			public static readonly string GearType__________ = "GearType__________";
			/// <summary>Member name GearType_________</summary>
			public static readonly string GearType_________ = "GearType_________";
			/// <summary>Member name GearType_____</summary>
			public static readonly string GearType_____ = "GearType_____";
			/// <summary>Member name GearType______________</summary>
			public static readonly string GearType______________ = "GearType______________";
			/// <summary>Member name GearType____</summary>
			public static readonly string GearType____ = "GearType____";
			/// <summary>Member name GearType____________</summary>
			public static readonly string GearType____________ = "GearType____________";
			/// <summary>Member name GearType_____________</summary>
			public static readonly string GearType_____________ = "GearType_____________";
			/// <summary>Member name GearType__</summary>
			public static readonly string GearType__ = "GearType__";
			/// <summary>Member name GearType_</summary>
			public static readonly string GearType_ = "GearType_";
			/// <summary>Member name GearType</summary>
			public static readonly string GearType = "GearType";
			/// <summary>Member name GearType___</summary>
			public static readonly string GearType___ = "GearType___";
			/// <summary>Member name GearType_______</summary>
			public static readonly string GearType_______ = "GearType_______";
			/// <summary>Member name GearType______</summary>
			public static readonly string GearType______ = "GearType______";
			/// <summary>Member name GearType___________</summary>
			public static readonly string GearType___________ = "GearType___________";
			/// <summary>Member name GeneratorManufacturer_</summary>
			public static readonly string GeneratorManufacturer_ = "GeneratorManufacturer_";
			/// <summary>Member name GeneratorManufacturer</summary>
			public static readonly string GeneratorManufacturer = "GeneratorManufacturer";
			/// <summary>Member name HousingError_____</summary>
			public static readonly string HousingError_____ = "HousingError_____";
			/// <summary>Member name HousingError____</summary>
			public static readonly string HousingError____ = "HousingError____";
			/// <summary>Member name HousingError___</summary>
			public static readonly string HousingError___ = "HousingError___";
			/// <summary>Member name HousingError</summary>
			public static readonly string HousingError = "HousingError";
			/// <summary>Member name HousingError_</summary>
			public static readonly string HousingError_ = "HousingError_";
			/// <summary>Member name HousingError__</summary>
			public static readonly string HousingError__ = "HousingError__";
			/// <summary>Member name InlineFilter</summary>
			public static readonly string InlineFilter = "InlineFilter";
			/// <summary>Member name MagnetPos</summary>
			public static readonly string MagnetPos = "MagnetPos";
			/// <summary>Member name MechanicalOilPump</summary>
			public static readonly string MechanicalOilPump = "MechanicalOilPump";
			/// <summary>Member name Noise</summary>
			public static readonly string Noise = "Noise";
			/// <summary>Member name OilLevel</summary>
			public static readonly string OilLevel = "OilLevel";
			/// <summary>Member name OilType</summary>
			public static readonly string OilType = "OilType";
			/// <summary>Member name OverallGearboxCondition</summary>
			public static readonly string OverallGearboxCondition = "OverallGearboxCondition";
			/// <summary>Member name ShaftError__</summary>
			public static readonly string ShaftError__ = "ShaftError__";
			/// <summary>Member name ShaftError___</summary>
			public static readonly string ShaftError___ = "ShaftError___";
			/// <summary>Member name ShaftError</summary>
			public static readonly string ShaftError = "ShaftError";
			/// <summary>Member name ShaftError_</summary>
			public static readonly string ShaftError_ = "ShaftError_";
			/// <summary>Member name ShaftType___</summary>
			public static readonly string ShaftType___ = "ShaftType___";
			/// <summary>Member name ShaftType__</summary>
			public static readonly string ShaftType__ = "ShaftType__";
			/// <summary>Member name ShaftType_</summary>
			public static readonly string ShaftType_ = "ShaftType_";
			/// <summary>Member name ShaftType</summary>
			public static readonly string ShaftType = "ShaftType";
			/// <summary>Member name ShrinkElement</summary>
			public static readonly string ShrinkElement = "ShrinkElement";
			/// <summary>Member name Vibrations</summary>
			public static readonly string Vibrations = "Vibrations";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ComponentInspectionReportGearboxEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ComponentInspectionReportGearboxEntity():base("ComponentInspectionReportGearboxEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ComponentInspectionReportGearboxEntity(IEntityFields2 fields):base("ComponentInspectionReportGearboxEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportGearboxEntity</param>
		public ComponentInspectionReportGearboxEntity(IValidator validator):base("ComponentInspectionReportGearboxEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportGearboxId">PK value for ComponentInspectionReportGearbox which data should be fetched into this ComponentInspectionReportGearbox object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportGearboxEntity(System.Int64 componentInspectionReportGearboxId):base("ComponentInspectionReportGearboxEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ComponentInspectionReportGearboxId = componentInspectionReportGearboxId;
		}

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportGearboxId">PK value for ComponentInspectionReportGearbox which data should be fetched into this ComponentInspectionReportGearbox object</param>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportGearboxEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportGearboxEntity(System.Int64 componentInspectionReportGearboxId, IValidator validator):base("ComponentInspectionReportGearboxEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ComponentInspectionReportGearboxId = componentInspectionReportGearboxId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ComponentInspectionReportGearboxEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_bearingError___ = (BearingErrorEntity)info.GetValue("_bearingError___", typeof(BearingErrorEntity));
				if(_bearingError___!=null)
				{
					_bearingError___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingError____ = (BearingErrorEntity)info.GetValue("_bearingError____", typeof(BearingErrorEntity));
				if(_bearingError____!=null)
				{
					_bearingError____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingError_____ = (BearingErrorEntity)info.GetValue("_bearingError_____", typeof(BearingErrorEntity));
				if(_bearingError_____!=null)
				{
					_bearingError_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingError = (BearingErrorEntity)info.GetValue("_bearingError", typeof(BearingErrorEntity));
				if(_bearingError!=null)
				{
					_bearingError.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingError_ = (BearingErrorEntity)info.GetValue("_bearingError_", typeof(BearingErrorEntity));
				if(_bearingError_!=null)
				{
					_bearingError_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingError__ = (BearingErrorEntity)info.GetValue("_bearingError__", typeof(BearingErrorEntity));
				if(_bearingError__!=null)
				{
					_bearingError__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingPos____ = (BearingPosEntity)info.GetValue("_bearingPos____", typeof(BearingPosEntity));
				if(_bearingPos____!=null)
				{
					_bearingPos____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingPos_____ = (BearingPosEntity)info.GetValue("_bearingPos_____", typeof(BearingPosEntity));
				if(_bearingPos_____!=null)
				{
					_bearingPos_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingPos___ = (BearingPosEntity)info.GetValue("_bearingPos___", typeof(BearingPosEntity));
				if(_bearingPos___!=null)
				{
					_bearingPos___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingPos = (BearingPosEntity)info.GetValue("_bearingPos", typeof(BearingPosEntity));
				if(_bearingPos!=null)
				{
					_bearingPos.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingPos_ = (BearingPosEntity)info.GetValue("_bearingPos_", typeof(BearingPosEntity));
				if(_bearingPos_!=null)
				{
					_bearingPos_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingPos__ = (BearingPosEntity)info.GetValue("_bearingPos__", typeof(BearingPosEntity));
				if(_bearingPos__!=null)
				{
					_bearingPos__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingType = (BearingTypeEntity)info.GetValue("_bearingType", typeof(BearingTypeEntity));
				if(_bearingType!=null)
				{
					_bearingType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingType_____ = (BearingTypeEntity)info.GetValue("_bearingType_____", typeof(BearingTypeEntity));
				if(_bearingType_____!=null)
				{
					_bearingType_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingType____ = (BearingTypeEntity)info.GetValue("_bearingType____", typeof(BearingTypeEntity));
				if(_bearingType____!=null)
				{
					_bearingType____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingType___ = (BearingTypeEntity)info.GetValue("_bearingType___", typeof(BearingTypeEntity));
				if(_bearingType___!=null)
				{
					_bearingType___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingType__ = (BearingTypeEntity)info.GetValue("_bearingType__", typeof(BearingTypeEntity));
				if(_bearingType__!=null)
				{
					_bearingType__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bearingType_ = (BearingTypeEntity)info.GetValue("_bearingType_", typeof(BearingTypeEntity));
				if(_bearingType_!=null)
				{
					_bearingType_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer_ = (BooleanAnswerEntity)info.GetValue("_booleanAnswer_", typeof(BooleanAnswerEntity));
				if(_booleanAnswer_!=null)
				{
					_booleanAnswer_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_booleanAnswer = (BooleanAnswerEntity)info.GetValue("_booleanAnswer", typeof(BooleanAnswerEntity));
				if(_booleanAnswer!=null)
				{
					_booleanAnswer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_componentInspectionReport = (ComponentInspectionReportEntity)info.GetValue("_componentInspectionReport", typeof(ComponentInspectionReportEntity));
				if(_componentInspectionReport!=null)
				{
					_componentInspectionReport.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_coupling = (CouplingEntity)info.GetValue("_coupling", typeof(CouplingEntity));
				if(_coupling!=null)
				{
					_coupling.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision____________ = (DamageDecisionEntity)info.GetValue("_damageDecision____________", typeof(DamageDecisionEntity));
				if(_damageDecision____________!=null)
				{
					_damageDecision____________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision_____________ = (DamageDecisionEntity)info.GetValue("_damageDecision_____________", typeof(DamageDecisionEntity));
				if(_damageDecision_____________!=null)
				{
					_damageDecision_____________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision__________ = (DamageDecisionEntity)info.GetValue("_damageDecision__________", typeof(DamageDecisionEntity));
				if(_damageDecision__________!=null)
				{
					_damageDecision__________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision___________ = (DamageDecisionEntity)info.GetValue("_damageDecision___________", typeof(DamageDecisionEntity));
				if(_damageDecision___________!=null)
				{
					_damageDecision___________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision_______________ = (DamageDecisionEntity)info.GetValue("_damageDecision_______________", typeof(DamageDecisionEntity));
				if(_damageDecision_______________!=null)
				{
					_damageDecision_______________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision________________ = (DamageDecisionEntity)info.GetValue("_damageDecision________________", typeof(DamageDecisionEntity));
				if(_damageDecision________________!=null)
				{
					_damageDecision________________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision_________________ = (DamageDecisionEntity)info.GetValue("_damageDecision_________________", typeof(DamageDecisionEntity));
				if(_damageDecision_________________!=null)
				{
					_damageDecision_________________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision______________ = (DamageDecisionEntity)info.GetValue("_damageDecision______________", typeof(DamageDecisionEntity));
				if(_damageDecision______________!=null)
				{
					_damageDecision______________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision___ = (DamageDecisionEntity)info.GetValue("_damageDecision___", typeof(DamageDecisionEntity));
				if(_damageDecision___!=null)
				{
					_damageDecision___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision__ = (DamageDecisionEntity)info.GetValue("_damageDecision__", typeof(DamageDecisionEntity));
				if(_damageDecision__!=null)
				{
					_damageDecision__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision____ = (DamageDecisionEntity)info.GetValue("_damageDecision____", typeof(DamageDecisionEntity));
				if(_damageDecision____!=null)
				{
					_damageDecision____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision_____ = (DamageDecisionEntity)info.GetValue("_damageDecision_____", typeof(DamageDecisionEntity));
				if(_damageDecision_____!=null)
				{
					_damageDecision_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision________ = (DamageDecisionEntity)info.GetValue("_damageDecision________", typeof(DamageDecisionEntity));
				if(_damageDecision________!=null)
				{
					_damageDecision________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision_________ = (DamageDecisionEntity)info.GetValue("_damageDecision_________", typeof(DamageDecisionEntity));
				if(_damageDecision_________!=null)
				{
					_damageDecision_________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision______ = (DamageDecisionEntity)info.GetValue("_damageDecision______", typeof(DamageDecisionEntity));
				if(_damageDecision______!=null)
				{
					_damageDecision______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision_______ = (DamageDecisionEntity)info.GetValue("_damageDecision_______", typeof(DamageDecisionEntity));
				if(_damageDecision_______!=null)
				{
					_damageDecision_______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision__________________ = (DamageDecisionEntity)info.GetValue("_damageDecision__________________", typeof(DamageDecisionEntity));
				if(_damageDecision__________________!=null)
				{
					_damageDecision__________________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision_ = (DamageDecisionEntity)info.GetValue("_damageDecision_", typeof(DamageDecisionEntity));
				if(_damageDecision_!=null)
				{
					_damageDecision_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision = (DamageDecisionEntity)info.GetValue("_damageDecision", typeof(DamageDecisionEntity));
				if(_damageDecision!=null)
				{
					_damageDecision.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision___________________ = (DamageDecisionEntity)info.GetValue("_damageDecision___________________", typeof(DamageDecisionEntity));
				if(_damageDecision___________________!=null)
				{
					_damageDecision___________________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_damageDecision____________________ = (DamageDecisionEntity)info.GetValue("_damageDecision____________________", typeof(DamageDecisionEntity));
				if(_damageDecision____________________!=null)
				{
					_damageDecision____________________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_debrisGearbox = (DebrisGearboxEntity)info.GetValue("_debrisGearbox", typeof(DebrisGearboxEntity));
				if(_debrisGearbox!=null)
				{
					_debrisGearbox.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_debrisOnMagnet = (DebrisOnMagnetEntity)info.GetValue("_debrisOnMagnet", typeof(DebrisOnMagnetEntity));
				if(_debrisOnMagnet!=null)
				{
					_debrisOnMagnet.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_electricalPump = (ElectricalPumpEntity)info.GetValue("_electricalPump", typeof(ElectricalPumpEntity));
				if(_electricalPump!=null)
				{
					_electricalPump.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_filterBlockType = (FilterBlockTypeEntity)info.GetValue("_filterBlockType", typeof(FilterBlockTypeEntity));
				if(_filterBlockType!=null)
				{
					_filterBlockType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearboxManufacturer = (GearboxManufacturerEntity)info.GetValue("_gearboxManufacturer", typeof(GearboxManufacturerEntity));
				if(_gearboxManufacturer!=null)
				{
					_gearboxManufacturer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearboxRevision = (GearboxRevisionEntity)info.GetValue("_gearboxRevision", typeof(GearboxRevisionEntity));
				if(_gearboxRevision!=null)
				{
					_gearboxRevision.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearboxType = (GearboxTypeEntity)info.GetValue("_gearboxType", typeof(GearboxTypeEntity));
				if(_gearboxType!=null)
				{
					_gearboxType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError___________ = (GearErrorEntity)info.GetValue("_gearError___________", typeof(GearErrorEntity));
				if(_gearError___________!=null)
				{
					_gearError___________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError_______ = (GearErrorEntity)info.GetValue("_gearError_______", typeof(GearErrorEntity));
				if(_gearError_______!=null)
				{
					_gearError_______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError________ = (GearErrorEntity)info.GetValue("_gearError________", typeof(GearErrorEntity));
				if(_gearError________!=null)
				{
					_gearError________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError_____ = (GearErrorEntity)info.GetValue("_gearError_____", typeof(GearErrorEntity));
				if(_gearError_____!=null)
				{
					_gearError_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError______ = (GearErrorEntity)info.GetValue("_gearError______", typeof(GearErrorEntity));
				if(_gearError______!=null)
				{
					_gearError______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError____________ = (GearErrorEntity)info.GetValue("_gearError____________", typeof(GearErrorEntity));
				if(_gearError____________!=null)
				{
					_gearError____________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError_____________ = (GearErrorEntity)info.GetValue("_gearError_____________", typeof(GearErrorEntity));
				if(_gearError_____________!=null)
				{
					_gearError_____________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError_________ = (GearErrorEntity)info.GetValue("_gearError_________", typeof(GearErrorEntity));
				if(_gearError_________!=null)
				{
					_gearError_________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError__________ = (GearErrorEntity)info.GetValue("_gearError__________", typeof(GearErrorEntity));
				if(_gearError__________!=null)
				{
					_gearError__________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError__ = (GearErrorEntity)info.GetValue("_gearError__", typeof(GearErrorEntity));
				if(_gearError__!=null)
				{
					_gearError__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError______________ = (GearErrorEntity)info.GetValue("_gearError______________", typeof(GearErrorEntity));
				if(_gearError______________!=null)
				{
					_gearError______________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError____ = (GearErrorEntity)info.GetValue("_gearError____", typeof(GearErrorEntity));
				if(_gearError____!=null)
				{
					_gearError____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError___ = (GearErrorEntity)info.GetValue("_gearError___", typeof(GearErrorEntity));
				if(_gearError___!=null)
				{
					_gearError___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError = (GearErrorEntity)info.GetValue("_gearError", typeof(GearErrorEntity));
				if(_gearError!=null)
				{
					_gearError.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearError_ = (GearErrorEntity)info.GetValue("_gearError_", typeof(GearErrorEntity));
				if(_gearError_!=null)
				{
					_gearError_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType________ = (GearTypeEntity)info.GetValue("_gearType________", typeof(GearTypeEntity));
				if(_gearType________!=null)
				{
					_gearType________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType__________ = (GearTypeEntity)info.GetValue("_gearType__________", typeof(GearTypeEntity));
				if(_gearType__________!=null)
				{
					_gearType__________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType_________ = (GearTypeEntity)info.GetValue("_gearType_________", typeof(GearTypeEntity));
				if(_gearType_________!=null)
				{
					_gearType_________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType_____ = (GearTypeEntity)info.GetValue("_gearType_____", typeof(GearTypeEntity));
				if(_gearType_____!=null)
				{
					_gearType_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType______________ = (GearTypeEntity)info.GetValue("_gearType______________", typeof(GearTypeEntity));
				if(_gearType______________!=null)
				{
					_gearType______________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType____ = (GearTypeEntity)info.GetValue("_gearType____", typeof(GearTypeEntity));
				if(_gearType____!=null)
				{
					_gearType____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType____________ = (GearTypeEntity)info.GetValue("_gearType____________", typeof(GearTypeEntity));
				if(_gearType____________!=null)
				{
					_gearType____________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType_____________ = (GearTypeEntity)info.GetValue("_gearType_____________", typeof(GearTypeEntity));
				if(_gearType_____________!=null)
				{
					_gearType_____________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType__ = (GearTypeEntity)info.GetValue("_gearType__", typeof(GearTypeEntity));
				if(_gearType__!=null)
				{
					_gearType__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType_ = (GearTypeEntity)info.GetValue("_gearType_", typeof(GearTypeEntity));
				if(_gearType_!=null)
				{
					_gearType_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType = (GearTypeEntity)info.GetValue("_gearType", typeof(GearTypeEntity));
				if(_gearType!=null)
				{
					_gearType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType___ = (GearTypeEntity)info.GetValue("_gearType___", typeof(GearTypeEntity));
				if(_gearType___!=null)
				{
					_gearType___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType_______ = (GearTypeEntity)info.GetValue("_gearType_______", typeof(GearTypeEntity));
				if(_gearType_______!=null)
				{
					_gearType_______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType______ = (GearTypeEntity)info.GetValue("_gearType______", typeof(GearTypeEntity));
				if(_gearType______!=null)
				{
					_gearType______.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_gearType___________ = (GearTypeEntity)info.GetValue("_gearType___________", typeof(GearTypeEntity));
				if(_gearType___________!=null)
				{
					_gearType___________.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorManufacturer_ = (GeneratorManufacturerEntity)info.GetValue("_generatorManufacturer_", typeof(GeneratorManufacturerEntity));
				if(_generatorManufacturer_!=null)
				{
					_generatorManufacturer_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_generatorManufacturer = (GeneratorManufacturerEntity)info.GetValue("_generatorManufacturer", typeof(GeneratorManufacturerEntity));
				if(_generatorManufacturer!=null)
				{
					_generatorManufacturer.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_housingError_____ = (HousingErrorEntity)info.GetValue("_housingError_____", typeof(HousingErrorEntity));
				if(_housingError_____!=null)
				{
					_housingError_____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_housingError____ = (HousingErrorEntity)info.GetValue("_housingError____", typeof(HousingErrorEntity));
				if(_housingError____!=null)
				{
					_housingError____.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_housingError___ = (HousingErrorEntity)info.GetValue("_housingError___", typeof(HousingErrorEntity));
				if(_housingError___!=null)
				{
					_housingError___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_housingError = (HousingErrorEntity)info.GetValue("_housingError", typeof(HousingErrorEntity));
				if(_housingError!=null)
				{
					_housingError.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_housingError_ = (HousingErrorEntity)info.GetValue("_housingError_", typeof(HousingErrorEntity));
				if(_housingError_!=null)
				{
					_housingError_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_housingError__ = (HousingErrorEntity)info.GetValue("_housingError__", typeof(HousingErrorEntity));
				if(_housingError__!=null)
				{
					_housingError__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_inlineFilter = (InlineFilterEntity)info.GetValue("_inlineFilter", typeof(InlineFilterEntity));
				if(_inlineFilter!=null)
				{
					_inlineFilter.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_magnetPos = (MagnetPosEntity)info.GetValue("_magnetPos", typeof(MagnetPosEntity));
				if(_magnetPos!=null)
				{
					_magnetPos.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_mechanicalOilPump = (MechanicalOilPumpEntity)info.GetValue("_mechanicalOilPump", typeof(MechanicalOilPumpEntity));
				if(_mechanicalOilPump!=null)
				{
					_mechanicalOilPump.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_noise = (NoiseEntity)info.GetValue("_noise", typeof(NoiseEntity));
				if(_noise!=null)
				{
					_noise.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_oilLevel = (OilLevelEntity)info.GetValue("_oilLevel", typeof(OilLevelEntity));
				if(_oilLevel!=null)
				{
					_oilLevel.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_oilType = (OilTypeEntity)info.GetValue("_oilType", typeof(OilTypeEntity));
				if(_oilType!=null)
				{
					_oilType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_overallGearboxCondition = (OverallGearboxConditionEntity)info.GetValue("_overallGearboxCondition", typeof(OverallGearboxConditionEntity));
				if(_overallGearboxCondition!=null)
				{
					_overallGearboxCondition.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_shaftError__ = (ShaftErrorEntity)info.GetValue("_shaftError__", typeof(ShaftErrorEntity));
				if(_shaftError__!=null)
				{
					_shaftError__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_shaftError___ = (ShaftErrorEntity)info.GetValue("_shaftError___", typeof(ShaftErrorEntity));
				if(_shaftError___!=null)
				{
					_shaftError___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_shaftError = (ShaftErrorEntity)info.GetValue("_shaftError", typeof(ShaftErrorEntity));
				if(_shaftError!=null)
				{
					_shaftError.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_shaftError_ = (ShaftErrorEntity)info.GetValue("_shaftError_", typeof(ShaftErrorEntity));
				if(_shaftError_!=null)
				{
					_shaftError_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_shaftType___ = (ShaftTypeEntity)info.GetValue("_shaftType___", typeof(ShaftTypeEntity));
				if(_shaftType___!=null)
				{
					_shaftType___.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_shaftType__ = (ShaftTypeEntity)info.GetValue("_shaftType__", typeof(ShaftTypeEntity));
				if(_shaftType__!=null)
				{
					_shaftType__.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_shaftType_ = (ShaftTypeEntity)info.GetValue("_shaftType_", typeof(ShaftTypeEntity));
				if(_shaftType_!=null)
				{
					_shaftType_.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_shaftType = (ShaftTypeEntity)info.GetValue("_shaftType", typeof(ShaftTypeEntity));
				if(_shaftType!=null)
				{
					_shaftType.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_shrinkElement = (ShrinkElementEntity)info.GetValue("_shrinkElement", typeof(ShrinkElementEntity));
				if(_shrinkElement!=null)
				{
					_shrinkElement.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_vibrations = (VibrationsEntity)info.GetValue("_vibrations", typeof(VibrationsEntity));
				if(_vibrations!=null)
				{
					_vibrations.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ComponentInspectionReportGearboxFieldIndex)fieldIndex)
			{
				case ComponentInspectionReportGearboxFieldIndex.ComponentInspectionReportId:
					DesetupSyncComponentInspectionReport(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeId:
					DesetupSyncGearboxType(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxRevisionId:
					DesetupSyncGearboxRevision(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxManufacturerId:
					DesetupSyncGearboxManufacturer(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxOilTypeId:
					DesetupSyncOilType(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxMechanicalOilPumpId:
					DesetupSyncMechanicalOilPump(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxOilLevelId:
					DesetupSyncOilLevel(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGeneratorManufacturerId:
					DesetupSyncGeneratorManufacturer(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGeneratorManufacturerId2:
					DesetupSyncGeneratorManufacturer_(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxElectricalPumpId:
					DesetupSyncElectricalPump(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxShrinkElementId:
					DesetupSyncShrinkElement(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxCouplingId:
					DesetupSyncCoupling(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxFilterBlockTypeId:
					DesetupSyncFilterBlockType(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxInLineFilterId:
					DesetupSyncInlineFilter(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxOffLineFilterId:
					DesetupSyncBooleanAnswer(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation1ShaftTypeId:
					DesetupSyncShaftType(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation2ShaftTypeId:
					DesetupSyncShaftType_(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation3ShaftTypeId:
					DesetupSyncShaftType__(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation4ShaftTypeId:
					DesetupSyncShaftType___(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage1ShaftErrorId:
					DesetupSyncShaftError(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage2ShaftErrorId:
					DesetupSyncShaftError_(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage3ShaftErrorId:
					DesetupSyncShaftError__(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage4ShaftErrorId:
					DesetupSyncShaftError___(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation1GearTypeId:
					DesetupSyncGearType(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation2GearTypeId:
					DesetupSyncGearType_(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation3GearTypeId:
					DesetupSyncGearType__(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation4GearTypeId:
					DesetupSyncGearType___(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation5GearTypeId:
					DesetupSyncGearType____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage1GearErrorId:
					DesetupSyncGearError(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage2GearErrorId:
					DesetupSyncGearError_(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage3GearErrorId:
					DesetupSyncGearError__(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage4GearErrorId:
					DesetupSyncGearError___(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage5GearErrorId:
					DesetupSyncGearError____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation1BearingTypeId:
					DesetupSyncBearingType(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation2BearingTypeId:
					DesetupSyncBearingType_(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation3BearingTypeId:
					DesetupSyncBearingType__(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation4BearingTypeId:
					DesetupSyncBearingType___(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation5BearingTypeId:
					DesetupSyncBearingType____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition1BearingPosId:
					DesetupSyncBearingPos(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition2BearingPosId:
					DesetupSyncBearingPos_(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition3BearingPosId:
					DesetupSyncBearingPos__(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition4BearingPosId:
					DesetupSyncBearingPos___(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition5BearingPosId:
					DesetupSyncBearingPos____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage1BearingErrorId:
					DesetupSyncBearingError(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage2BearingErrorId:
					DesetupSyncBearingError_(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage3BearingErrorId:
					DesetupSyncBearingError__(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage4BearingErrorId:
					DesetupSyncBearingError___(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage5BearingErrorId:
					DesetupSyncBearingError____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxPlanetStage1HousingErrorId:
					DesetupSyncHousingError(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxPlanetStage2HousingErrorId:
					DesetupSyncHousingError_(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxHelicalStageHousingErrorId:
					DesetupSyncHousingError__(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxFrontPlateHousingErrorId:
					DesetupSyncHousingError___(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxAuxStageHousingErrorId:
					DesetupSyncHousingError____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxHsstageHousingErrorId:
					DesetupSyncHousingError_____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxVibrationsId:
					DesetupSyncVibrations(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxNoiseId:
					DesetupSyncNoise(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxDebrisOnMagnetId:
					DesetupSyncDebrisOnMagnet(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxDebrisStagesMagnetPosId:
					DesetupSyncMagnetPos(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxDebrisGearBoxId:
					DesetupSyncDebrisGearbox(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxClaimRelevantBooleanAnswerId:
					DesetupSyncBooleanAnswer_(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxOverallGearboxConditionId:
					DesetupSyncOverallGearboxCondition(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation6GearTypeId:
					DesetupSyncGearType_____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation7GearTypeId:
					DesetupSyncGearType____________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation8GearTypeId:
					DesetupSyncGearType_____________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation9GearTypeId:
					DesetupSyncGearType______________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation10GearTypeId:
					DesetupSyncGearType______(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation11GearTypeId:
					DesetupSyncGearType_______(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation12GearTypeId:
					DesetupSyncGearType________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation13GearTypeId:
					DesetupSyncGearType_________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation14GearTypeId:
					DesetupSyncGearType__________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation15GearTypeId:
					DesetupSyncGearType___________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage6GearErrorId:
					DesetupSyncGearError___________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage7GearErrorId:
					DesetupSyncGearError____________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage8GearErrorId:
					DesetupSyncGearError_____________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage9GearErrorId:
					DesetupSyncGearError______________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage10GearErrorId:
					DesetupSyncGearError_____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage11GearErrorId:
					DesetupSyncGearError______(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage12GearErrorId:
					DesetupSyncGearError_______(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage13GearErrorId:
					DesetupSyncGearError________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage14GearErrorId:
					DesetupSyncGearError_________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage15GearErrorId:
					DesetupSyncGearError__________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision1DamageDecisionId:
					DesetupSyncDamageDecision____________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision2DamageDecisionId:
					DesetupSyncDamageDecision_____________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision3DamageDecisionId:
					DesetupSyncDamageDecision______________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision4DamageDecisionId:
					DesetupSyncDamageDecision_______________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision5DamageDecisionId:
					DesetupSyncDamageDecision________________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision6DamageDecisionId:
					DesetupSyncDamageDecision_________________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision7DamageDecisionId:
					DesetupSyncDamageDecision__________________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision8DamageDecisionId:
					DesetupSyncDamageDecision___________________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision9DamageDecisionId:
					DesetupSyncDamageDecision____________________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision10DamageDecisionId:
					DesetupSyncDamageDecision______(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision11DamageDecisionId:
					DesetupSyncDamageDecision_______(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision12DamageDecisionId:
					DesetupSyncDamageDecision________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision13DamageDecisionId:
					DesetupSyncDamageDecision_________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision14DamageDecisionId:
					DesetupSyncDamageDecision__________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision15DamageDecisionId:
					DesetupSyncDamageDecision___________(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation6BearingTypeId:
					DesetupSyncBearingType_____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition6BearingPosId:
					DesetupSyncBearingPos_____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage6BearingErrorId:
					DesetupSyncBearingError_____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision1DamageDecisionId:
					DesetupSyncDamageDecision_(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision2DamageDecisionId:
					DesetupSyncDamageDecision(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision3DamageDecisionId:
					DesetupSyncDamageDecision__(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision4DamageDecisionId:
					DesetupSyncDamageDecision___(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision5DamageDecisionId:
					DesetupSyncDamageDecision____(true, false);
					break;
				case ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision6DamageDecisionId:
					DesetupSyncDamageDecision_____(true, false);
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
				case "BearingError___":
					this.BearingError___ = (BearingErrorEntity)entity;
					break;
				case "BearingError____":
					this.BearingError____ = (BearingErrorEntity)entity;
					break;
				case "BearingError_____":
					this.BearingError_____ = (BearingErrorEntity)entity;
					break;
				case "BearingError":
					this.BearingError = (BearingErrorEntity)entity;
					break;
				case "BearingError_":
					this.BearingError_ = (BearingErrorEntity)entity;
					break;
				case "BearingError__":
					this.BearingError__ = (BearingErrorEntity)entity;
					break;
				case "BearingPos____":
					this.BearingPos____ = (BearingPosEntity)entity;
					break;
				case "BearingPos_____":
					this.BearingPos_____ = (BearingPosEntity)entity;
					break;
				case "BearingPos___":
					this.BearingPos___ = (BearingPosEntity)entity;
					break;
				case "BearingPos":
					this.BearingPos = (BearingPosEntity)entity;
					break;
				case "BearingPos_":
					this.BearingPos_ = (BearingPosEntity)entity;
					break;
				case "BearingPos__":
					this.BearingPos__ = (BearingPosEntity)entity;
					break;
				case "BearingType":
					this.BearingType = (BearingTypeEntity)entity;
					break;
				case "BearingType_____":
					this.BearingType_____ = (BearingTypeEntity)entity;
					break;
				case "BearingType____":
					this.BearingType____ = (BearingTypeEntity)entity;
					break;
				case "BearingType___":
					this.BearingType___ = (BearingTypeEntity)entity;
					break;
				case "BearingType__":
					this.BearingType__ = (BearingTypeEntity)entity;
					break;
				case "BearingType_":
					this.BearingType_ = (BearingTypeEntity)entity;
					break;
				case "BooleanAnswer_":
					this.BooleanAnswer_ = (BooleanAnswerEntity)entity;
					break;
				case "BooleanAnswer":
					this.BooleanAnswer = (BooleanAnswerEntity)entity;
					break;
				case "ComponentInspectionReport":
					this.ComponentInspectionReport = (ComponentInspectionReportEntity)entity;
					break;
				case "Coupling":
					this.Coupling = (CouplingEntity)entity;
					break;
				case "DamageDecision____________":
					this.DamageDecision____________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision_____________":
					this.DamageDecision_____________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision__________":
					this.DamageDecision__________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision___________":
					this.DamageDecision___________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision_______________":
					this.DamageDecision_______________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision________________":
					this.DamageDecision________________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision_________________":
					this.DamageDecision_________________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision______________":
					this.DamageDecision______________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision___":
					this.DamageDecision___ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision__":
					this.DamageDecision__ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision____":
					this.DamageDecision____ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision_____":
					this.DamageDecision_____ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision________":
					this.DamageDecision________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision_________":
					this.DamageDecision_________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision______":
					this.DamageDecision______ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision_______":
					this.DamageDecision_______ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision__________________":
					this.DamageDecision__________________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision_":
					this.DamageDecision_ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision":
					this.DamageDecision = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision___________________":
					this.DamageDecision___________________ = (DamageDecisionEntity)entity;
					break;
				case "DamageDecision____________________":
					this.DamageDecision____________________ = (DamageDecisionEntity)entity;
					break;
				case "DebrisGearbox":
					this.DebrisGearbox = (DebrisGearboxEntity)entity;
					break;
				case "DebrisOnMagnet":
					this.DebrisOnMagnet = (DebrisOnMagnetEntity)entity;
					break;
				case "ElectricalPump":
					this.ElectricalPump = (ElectricalPumpEntity)entity;
					break;
				case "FilterBlockType":
					this.FilterBlockType = (FilterBlockTypeEntity)entity;
					break;
				case "GearboxManufacturer":
					this.GearboxManufacturer = (GearboxManufacturerEntity)entity;
					break;
				case "GearboxRevision":
					this.GearboxRevision = (GearboxRevisionEntity)entity;
					break;
				case "GearboxType":
					this.GearboxType = (GearboxTypeEntity)entity;
					break;
				case "GearError___________":
					this.GearError___________ = (GearErrorEntity)entity;
					break;
				case "GearError_______":
					this.GearError_______ = (GearErrorEntity)entity;
					break;
				case "GearError________":
					this.GearError________ = (GearErrorEntity)entity;
					break;
				case "GearError_____":
					this.GearError_____ = (GearErrorEntity)entity;
					break;
				case "GearError______":
					this.GearError______ = (GearErrorEntity)entity;
					break;
				case "GearError____________":
					this.GearError____________ = (GearErrorEntity)entity;
					break;
				case "GearError_____________":
					this.GearError_____________ = (GearErrorEntity)entity;
					break;
				case "GearError_________":
					this.GearError_________ = (GearErrorEntity)entity;
					break;
				case "GearError__________":
					this.GearError__________ = (GearErrorEntity)entity;
					break;
				case "GearError__":
					this.GearError__ = (GearErrorEntity)entity;
					break;
				case "GearError______________":
					this.GearError______________ = (GearErrorEntity)entity;
					break;
				case "GearError____":
					this.GearError____ = (GearErrorEntity)entity;
					break;
				case "GearError___":
					this.GearError___ = (GearErrorEntity)entity;
					break;
				case "GearError":
					this.GearError = (GearErrorEntity)entity;
					break;
				case "GearError_":
					this.GearError_ = (GearErrorEntity)entity;
					break;
				case "GearType________":
					this.GearType________ = (GearTypeEntity)entity;
					break;
				case "GearType__________":
					this.GearType__________ = (GearTypeEntity)entity;
					break;
				case "GearType_________":
					this.GearType_________ = (GearTypeEntity)entity;
					break;
				case "GearType_____":
					this.GearType_____ = (GearTypeEntity)entity;
					break;
				case "GearType______________":
					this.GearType______________ = (GearTypeEntity)entity;
					break;
				case "GearType____":
					this.GearType____ = (GearTypeEntity)entity;
					break;
				case "GearType____________":
					this.GearType____________ = (GearTypeEntity)entity;
					break;
				case "GearType_____________":
					this.GearType_____________ = (GearTypeEntity)entity;
					break;
				case "GearType__":
					this.GearType__ = (GearTypeEntity)entity;
					break;
				case "GearType_":
					this.GearType_ = (GearTypeEntity)entity;
					break;
				case "GearType":
					this.GearType = (GearTypeEntity)entity;
					break;
				case "GearType___":
					this.GearType___ = (GearTypeEntity)entity;
					break;
				case "GearType_______":
					this.GearType_______ = (GearTypeEntity)entity;
					break;
				case "GearType______":
					this.GearType______ = (GearTypeEntity)entity;
					break;
				case "GearType___________":
					this.GearType___________ = (GearTypeEntity)entity;
					break;
				case "GeneratorManufacturer_":
					this.GeneratorManufacturer_ = (GeneratorManufacturerEntity)entity;
					break;
				case "GeneratorManufacturer":
					this.GeneratorManufacturer = (GeneratorManufacturerEntity)entity;
					break;
				case "HousingError_____":
					this.HousingError_____ = (HousingErrorEntity)entity;
					break;
				case "HousingError____":
					this.HousingError____ = (HousingErrorEntity)entity;
					break;
				case "HousingError___":
					this.HousingError___ = (HousingErrorEntity)entity;
					break;
				case "HousingError":
					this.HousingError = (HousingErrorEntity)entity;
					break;
				case "HousingError_":
					this.HousingError_ = (HousingErrorEntity)entity;
					break;
				case "HousingError__":
					this.HousingError__ = (HousingErrorEntity)entity;
					break;
				case "InlineFilter":
					this.InlineFilter = (InlineFilterEntity)entity;
					break;
				case "MagnetPos":
					this.MagnetPos = (MagnetPosEntity)entity;
					break;
				case "MechanicalOilPump":
					this.MechanicalOilPump = (MechanicalOilPumpEntity)entity;
					break;
				case "Noise":
					this.Noise = (NoiseEntity)entity;
					break;
				case "OilLevel":
					this.OilLevel = (OilLevelEntity)entity;
					break;
				case "OilType":
					this.OilType = (OilTypeEntity)entity;
					break;
				case "OverallGearboxCondition":
					this.OverallGearboxCondition = (OverallGearboxConditionEntity)entity;
					break;
				case "ShaftError__":
					this.ShaftError__ = (ShaftErrorEntity)entity;
					break;
				case "ShaftError___":
					this.ShaftError___ = (ShaftErrorEntity)entity;
					break;
				case "ShaftError":
					this.ShaftError = (ShaftErrorEntity)entity;
					break;
				case "ShaftError_":
					this.ShaftError_ = (ShaftErrorEntity)entity;
					break;
				case "ShaftType___":
					this.ShaftType___ = (ShaftTypeEntity)entity;
					break;
				case "ShaftType__":
					this.ShaftType__ = (ShaftTypeEntity)entity;
					break;
				case "ShaftType_":
					this.ShaftType_ = (ShaftTypeEntity)entity;
					break;
				case "ShaftType":
					this.ShaftType = (ShaftTypeEntity)entity;
					break;
				case "ShrinkElement":
					this.ShrinkElement = (ShrinkElementEntity)entity;
					break;
				case "Vibrations":
					this.Vibrations = (VibrationsEntity)entity;
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
				case "BearingError___":
					SetupSyncBearingError___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingError____":
					SetupSyncBearingError____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingError_____":
					SetupSyncBearingError_____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingError":
					SetupSyncBearingError(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingError_":
					SetupSyncBearingError_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingError__":
					SetupSyncBearingError__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingPos____":
					SetupSyncBearingPos____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingPos_____":
					SetupSyncBearingPos_____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingPos___":
					SetupSyncBearingPos___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingPos":
					SetupSyncBearingPos(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingPos_":
					SetupSyncBearingPos_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingPos__":
					SetupSyncBearingPos__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingType":
					SetupSyncBearingType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingType_____":
					SetupSyncBearingType_____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingType____":
					SetupSyncBearingType____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingType___":
					SetupSyncBearingType___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingType__":
					SetupSyncBearingType__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BearingType_":
					SetupSyncBearingType_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_":
					SetupSyncBooleanAnswer_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BooleanAnswer":
					SetupSyncBooleanAnswer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					SetupSyncComponentInspectionReport(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "Coupling":
					SetupSyncCoupling(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision____________":
					SetupSyncDamageDecision____________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision_____________":
					SetupSyncDamageDecision_____________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision__________":
					SetupSyncDamageDecision__________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision___________":
					SetupSyncDamageDecision___________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision_______________":
					SetupSyncDamageDecision_______________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision________________":
					SetupSyncDamageDecision________________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision_________________":
					SetupSyncDamageDecision_________________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision______________":
					SetupSyncDamageDecision______________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision___":
					SetupSyncDamageDecision___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision__":
					SetupSyncDamageDecision__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision____":
					SetupSyncDamageDecision____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision_____":
					SetupSyncDamageDecision_____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision________":
					SetupSyncDamageDecision________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision_________":
					SetupSyncDamageDecision_________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision______":
					SetupSyncDamageDecision______(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision_______":
					SetupSyncDamageDecision_______(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision__________________":
					SetupSyncDamageDecision__________________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision_":
					SetupSyncDamageDecision_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision":
					SetupSyncDamageDecision(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision___________________":
					SetupSyncDamageDecision___________________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DamageDecision____________________":
					SetupSyncDamageDecision____________________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DebrisGearbox":
					SetupSyncDebrisGearbox(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "DebrisOnMagnet":
					SetupSyncDebrisOnMagnet(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ElectricalPump":
					SetupSyncElectricalPump(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "FilterBlockType":
					SetupSyncFilterBlockType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearboxManufacturer":
					SetupSyncGearboxManufacturer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearboxRevision":
					SetupSyncGearboxRevision(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearboxType":
					SetupSyncGearboxType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError___________":
					SetupSyncGearError___________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError_______":
					SetupSyncGearError_______(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError________":
					SetupSyncGearError________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError_____":
					SetupSyncGearError_____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError______":
					SetupSyncGearError______(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError____________":
					SetupSyncGearError____________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError_____________":
					SetupSyncGearError_____________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError_________":
					SetupSyncGearError_________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError__________":
					SetupSyncGearError__________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError__":
					SetupSyncGearError__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError______________":
					SetupSyncGearError______________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError____":
					SetupSyncGearError____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError___":
					SetupSyncGearError___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError":
					SetupSyncGearError(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearError_":
					SetupSyncGearError_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType________":
					SetupSyncGearType________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType__________":
					SetupSyncGearType__________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType_________":
					SetupSyncGearType_________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType_____":
					SetupSyncGearType_____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType______________":
					SetupSyncGearType______________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType____":
					SetupSyncGearType____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType____________":
					SetupSyncGearType____________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType_____________":
					SetupSyncGearType_____________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType__":
					SetupSyncGearType__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType_":
					SetupSyncGearType_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType":
					SetupSyncGearType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType___":
					SetupSyncGearType___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType_______":
					SetupSyncGearType_______(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType______":
					SetupSyncGearType______(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GearType___________":
					SetupSyncGearType___________(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorManufacturer_":
					SetupSyncGeneratorManufacturer_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "GeneratorManufacturer":
					SetupSyncGeneratorManufacturer(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "HousingError_____":
					SetupSyncHousingError_____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "HousingError____":
					SetupSyncHousingError____(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "HousingError___":
					SetupSyncHousingError___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "HousingError":
					SetupSyncHousingError(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "HousingError_":
					SetupSyncHousingError_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "HousingError__":
					SetupSyncHousingError__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "InlineFilter":
					SetupSyncInlineFilter(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "MagnetPos":
					SetupSyncMagnetPos(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "MechanicalOilPump":
					SetupSyncMechanicalOilPump(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "Noise":
					SetupSyncNoise(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OilLevel":
					SetupSyncOilLevel(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OilType":
					SetupSyncOilType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OverallGearboxCondition":
					SetupSyncOverallGearboxCondition(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ShaftError__":
					SetupSyncShaftError__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ShaftError___":
					SetupSyncShaftError___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ShaftError":
					SetupSyncShaftError(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ShaftError_":
					SetupSyncShaftError_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ShaftType___":
					SetupSyncShaftType___(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ShaftType__":
					SetupSyncShaftType__(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ShaftType_":
					SetupSyncShaftType_(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ShaftType":
					SetupSyncShaftType(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ShrinkElement":
					SetupSyncShrinkElement(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "Vibrations":
					SetupSyncVibrations(relatedEntity);
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
				case "BearingError___":
					DesetupSyncBearingError___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingError____":
					DesetupSyncBearingError____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingError_____":
					DesetupSyncBearingError_____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingError":
					DesetupSyncBearingError(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingError_":
					DesetupSyncBearingError_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingError__":
					DesetupSyncBearingError__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingPos____":
					DesetupSyncBearingPos____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingPos_____":
					DesetupSyncBearingPos_____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingPos___":
					DesetupSyncBearingPos___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingPos":
					DesetupSyncBearingPos(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingPos_":
					DesetupSyncBearingPos_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingPos__":
					DesetupSyncBearingPos__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingType":
					DesetupSyncBearingType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingType_____":
					DesetupSyncBearingType_____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingType____":
					DesetupSyncBearingType____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingType___":
					DesetupSyncBearingType___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingType__":
					DesetupSyncBearingType__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BearingType_":
					DesetupSyncBearingType_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer_":
					DesetupSyncBooleanAnswer_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BooleanAnswer":
					DesetupSyncBooleanAnswer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReport":
					DesetupSyncComponentInspectionReport(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "Coupling":
					DesetupSyncCoupling(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision____________":
					DesetupSyncDamageDecision____________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision_____________":
					DesetupSyncDamageDecision_____________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision__________":
					DesetupSyncDamageDecision__________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision___________":
					DesetupSyncDamageDecision___________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision_______________":
					DesetupSyncDamageDecision_______________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision________________":
					DesetupSyncDamageDecision________________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision_________________":
					DesetupSyncDamageDecision_________________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision______________":
					DesetupSyncDamageDecision______________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision___":
					DesetupSyncDamageDecision___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision__":
					DesetupSyncDamageDecision__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision____":
					DesetupSyncDamageDecision____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision_____":
					DesetupSyncDamageDecision_____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision________":
					DesetupSyncDamageDecision________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision_________":
					DesetupSyncDamageDecision_________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision______":
					DesetupSyncDamageDecision______(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision_______":
					DesetupSyncDamageDecision_______(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision__________________":
					DesetupSyncDamageDecision__________________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision_":
					DesetupSyncDamageDecision_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision":
					DesetupSyncDamageDecision(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision___________________":
					DesetupSyncDamageDecision___________________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DamageDecision____________________":
					DesetupSyncDamageDecision____________________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DebrisGearbox":
					DesetupSyncDebrisGearbox(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "DebrisOnMagnet":
					DesetupSyncDebrisOnMagnet(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ElectricalPump":
					DesetupSyncElectricalPump(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "FilterBlockType":
					DesetupSyncFilterBlockType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearboxManufacturer":
					DesetupSyncGearboxManufacturer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearboxRevision":
					DesetupSyncGearboxRevision(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearboxType":
					DesetupSyncGearboxType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError___________":
					DesetupSyncGearError___________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError_______":
					DesetupSyncGearError_______(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError________":
					DesetupSyncGearError________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError_____":
					DesetupSyncGearError_____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError______":
					DesetupSyncGearError______(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError____________":
					DesetupSyncGearError____________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError_____________":
					DesetupSyncGearError_____________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError_________":
					DesetupSyncGearError_________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError__________":
					DesetupSyncGearError__________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError__":
					DesetupSyncGearError__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError______________":
					DesetupSyncGearError______________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError____":
					DesetupSyncGearError____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError___":
					DesetupSyncGearError___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError":
					DesetupSyncGearError(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearError_":
					DesetupSyncGearError_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType________":
					DesetupSyncGearType________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType__________":
					DesetupSyncGearType__________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType_________":
					DesetupSyncGearType_________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType_____":
					DesetupSyncGearType_____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType______________":
					DesetupSyncGearType______________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType____":
					DesetupSyncGearType____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType____________":
					DesetupSyncGearType____________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType_____________":
					DesetupSyncGearType_____________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType__":
					DesetupSyncGearType__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType_":
					DesetupSyncGearType_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType":
					DesetupSyncGearType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType___":
					DesetupSyncGearType___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType_______":
					DesetupSyncGearType_______(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType______":
					DesetupSyncGearType______(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GearType___________":
					DesetupSyncGearType___________(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorManufacturer_":
					DesetupSyncGeneratorManufacturer_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "GeneratorManufacturer":
					DesetupSyncGeneratorManufacturer(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "HousingError_____":
					DesetupSyncHousingError_____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "HousingError____":
					DesetupSyncHousingError____(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "HousingError___":
					DesetupSyncHousingError___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "HousingError":
					DesetupSyncHousingError(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "HousingError_":
					DesetupSyncHousingError_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "HousingError__":
					DesetupSyncHousingError__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "InlineFilter":
					DesetupSyncInlineFilter(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "MagnetPos":
					DesetupSyncMagnetPos(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "MechanicalOilPump":
					DesetupSyncMechanicalOilPump(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "Noise":
					DesetupSyncNoise(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OilLevel":
					DesetupSyncOilLevel(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OilType":
					DesetupSyncOilType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OverallGearboxCondition":
					DesetupSyncOverallGearboxCondition(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ShaftError__":
					DesetupSyncShaftError__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ShaftError___":
					DesetupSyncShaftError___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ShaftError":
					DesetupSyncShaftError(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ShaftError_":
					DesetupSyncShaftError_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ShaftType___":
					DesetupSyncShaftType___(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ShaftType__":
					DesetupSyncShaftType__(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ShaftType_":
					DesetupSyncShaftType_(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ShaftType":
					DesetupSyncShaftType(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ShrinkElement":
					DesetupSyncShrinkElement(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "Vibrations":
					DesetupSyncVibrations(false, true);
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
			if(_bearingError___!=null)
			{
				toReturn.Add(_bearingError___);
			}
			if(_bearingError____!=null)
			{
				toReturn.Add(_bearingError____);
			}
			if(_bearingError_____!=null)
			{
				toReturn.Add(_bearingError_____);
			}
			if(_bearingError!=null)
			{
				toReturn.Add(_bearingError);
			}
			if(_bearingError_!=null)
			{
				toReturn.Add(_bearingError_);
			}
			if(_bearingError__!=null)
			{
				toReturn.Add(_bearingError__);
			}
			if(_bearingPos____!=null)
			{
				toReturn.Add(_bearingPos____);
			}
			if(_bearingPos_____!=null)
			{
				toReturn.Add(_bearingPos_____);
			}
			if(_bearingPos___!=null)
			{
				toReturn.Add(_bearingPos___);
			}
			if(_bearingPos!=null)
			{
				toReturn.Add(_bearingPos);
			}
			if(_bearingPos_!=null)
			{
				toReturn.Add(_bearingPos_);
			}
			if(_bearingPos__!=null)
			{
				toReturn.Add(_bearingPos__);
			}
			if(_bearingType!=null)
			{
				toReturn.Add(_bearingType);
			}
			if(_bearingType_____!=null)
			{
				toReturn.Add(_bearingType_____);
			}
			if(_bearingType____!=null)
			{
				toReturn.Add(_bearingType____);
			}
			if(_bearingType___!=null)
			{
				toReturn.Add(_bearingType___);
			}
			if(_bearingType__!=null)
			{
				toReturn.Add(_bearingType__);
			}
			if(_bearingType_!=null)
			{
				toReturn.Add(_bearingType_);
			}
			if(_booleanAnswer_!=null)
			{
				toReturn.Add(_booleanAnswer_);
			}
			if(_booleanAnswer!=null)
			{
				toReturn.Add(_booleanAnswer);
			}
			if(_componentInspectionReport!=null)
			{
				toReturn.Add(_componentInspectionReport);
			}
			if(_coupling!=null)
			{
				toReturn.Add(_coupling);
			}
			if(_damageDecision____________!=null)
			{
				toReturn.Add(_damageDecision____________);
			}
			if(_damageDecision_____________!=null)
			{
				toReturn.Add(_damageDecision_____________);
			}
			if(_damageDecision__________!=null)
			{
				toReturn.Add(_damageDecision__________);
			}
			if(_damageDecision___________!=null)
			{
				toReturn.Add(_damageDecision___________);
			}
			if(_damageDecision_______________!=null)
			{
				toReturn.Add(_damageDecision_______________);
			}
			if(_damageDecision________________!=null)
			{
				toReturn.Add(_damageDecision________________);
			}
			if(_damageDecision_________________!=null)
			{
				toReturn.Add(_damageDecision_________________);
			}
			if(_damageDecision______________!=null)
			{
				toReturn.Add(_damageDecision______________);
			}
			if(_damageDecision___!=null)
			{
				toReturn.Add(_damageDecision___);
			}
			if(_damageDecision__!=null)
			{
				toReturn.Add(_damageDecision__);
			}
			if(_damageDecision____!=null)
			{
				toReturn.Add(_damageDecision____);
			}
			if(_damageDecision_____!=null)
			{
				toReturn.Add(_damageDecision_____);
			}
			if(_damageDecision________!=null)
			{
				toReturn.Add(_damageDecision________);
			}
			if(_damageDecision_________!=null)
			{
				toReturn.Add(_damageDecision_________);
			}
			if(_damageDecision______!=null)
			{
				toReturn.Add(_damageDecision______);
			}
			if(_damageDecision_______!=null)
			{
				toReturn.Add(_damageDecision_______);
			}
			if(_damageDecision__________________!=null)
			{
				toReturn.Add(_damageDecision__________________);
			}
			if(_damageDecision_!=null)
			{
				toReturn.Add(_damageDecision_);
			}
			if(_damageDecision!=null)
			{
				toReturn.Add(_damageDecision);
			}
			if(_damageDecision___________________!=null)
			{
				toReturn.Add(_damageDecision___________________);
			}
			if(_damageDecision____________________!=null)
			{
				toReturn.Add(_damageDecision____________________);
			}
			if(_debrisGearbox!=null)
			{
				toReturn.Add(_debrisGearbox);
			}
			if(_debrisOnMagnet!=null)
			{
				toReturn.Add(_debrisOnMagnet);
			}
			if(_electricalPump!=null)
			{
				toReturn.Add(_electricalPump);
			}
			if(_filterBlockType!=null)
			{
				toReturn.Add(_filterBlockType);
			}
			if(_gearboxManufacturer!=null)
			{
				toReturn.Add(_gearboxManufacturer);
			}
			if(_gearboxRevision!=null)
			{
				toReturn.Add(_gearboxRevision);
			}
			if(_gearboxType!=null)
			{
				toReturn.Add(_gearboxType);
			}
			if(_gearError___________!=null)
			{
				toReturn.Add(_gearError___________);
			}
			if(_gearError_______!=null)
			{
				toReturn.Add(_gearError_______);
			}
			if(_gearError________!=null)
			{
				toReturn.Add(_gearError________);
			}
			if(_gearError_____!=null)
			{
				toReturn.Add(_gearError_____);
			}
			if(_gearError______!=null)
			{
				toReturn.Add(_gearError______);
			}
			if(_gearError____________!=null)
			{
				toReturn.Add(_gearError____________);
			}
			if(_gearError_____________!=null)
			{
				toReturn.Add(_gearError_____________);
			}
			if(_gearError_________!=null)
			{
				toReturn.Add(_gearError_________);
			}
			if(_gearError__________!=null)
			{
				toReturn.Add(_gearError__________);
			}
			if(_gearError__!=null)
			{
				toReturn.Add(_gearError__);
			}
			if(_gearError______________!=null)
			{
				toReturn.Add(_gearError______________);
			}
			if(_gearError____!=null)
			{
				toReturn.Add(_gearError____);
			}
			if(_gearError___!=null)
			{
				toReturn.Add(_gearError___);
			}
			if(_gearError!=null)
			{
				toReturn.Add(_gearError);
			}
			if(_gearError_!=null)
			{
				toReturn.Add(_gearError_);
			}
			if(_gearType________!=null)
			{
				toReturn.Add(_gearType________);
			}
			if(_gearType__________!=null)
			{
				toReturn.Add(_gearType__________);
			}
			if(_gearType_________!=null)
			{
				toReturn.Add(_gearType_________);
			}
			if(_gearType_____!=null)
			{
				toReturn.Add(_gearType_____);
			}
			if(_gearType______________!=null)
			{
				toReturn.Add(_gearType______________);
			}
			if(_gearType____!=null)
			{
				toReturn.Add(_gearType____);
			}
			if(_gearType____________!=null)
			{
				toReturn.Add(_gearType____________);
			}
			if(_gearType_____________!=null)
			{
				toReturn.Add(_gearType_____________);
			}
			if(_gearType__!=null)
			{
				toReturn.Add(_gearType__);
			}
			if(_gearType_!=null)
			{
				toReturn.Add(_gearType_);
			}
			if(_gearType!=null)
			{
				toReturn.Add(_gearType);
			}
			if(_gearType___!=null)
			{
				toReturn.Add(_gearType___);
			}
			if(_gearType_______!=null)
			{
				toReturn.Add(_gearType_______);
			}
			if(_gearType______!=null)
			{
				toReturn.Add(_gearType______);
			}
			if(_gearType___________!=null)
			{
				toReturn.Add(_gearType___________);
			}
			if(_generatorManufacturer_!=null)
			{
				toReturn.Add(_generatorManufacturer_);
			}
			if(_generatorManufacturer!=null)
			{
				toReturn.Add(_generatorManufacturer);
			}
			if(_housingError_____!=null)
			{
				toReturn.Add(_housingError_____);
			}
			if(_housingError____!=null)
			{
				toReturn.Add(_housingError____);
			}
			if(_housingError___!=null)
			{
				toReturn.Add(_housingError___);
			}
			if(_housingError!=null)
			{
				toReturn.Add(_housingError);
			}
			if(_housingError_!=null)
			{
				toReturn.Add(_housingError_);
			}
			if(_housingError__!=null)
			{
				toReturn.Add(_housingError__);
			}
			if(_inlineFilter!=null)
			{
				toReturn.Add(_inlineFilter);
			}
			if(_magnetPos!=null)
			{
				toReturn.Add(_magnetPos);
			}
			if(_mechanicalOilPump!=null)
			{
				toReturn.Add(_mechanicalOilPump);
			}
			if(_noise!=null)
			{
				toReturn.Add(_noise);
			}
			if(_oilLevel!=null)
			{
				toReturn.Add(_oilLevel);
			}
			if(_oilType!=null)
			{
				toReturn.Add(_oilType);
			}
			if(_overallGearboxCondition!=null)
			{
				toReturn.Add(_overallGearboxCondition);
			}
			if(_shaftError__!=null)
			{
				toReturn.Add(_shaftError__);
			}
			if(_shaftError___!=null)
			{
				toReturn.Add(_shaftError___);
			}
			if(_shaftError!=null)
			{
				toReturn.Add(_shaftError);
			}
			if(_shaftError_!=null)
			{
				toReturn.Add(_shaftError_);
			}
			if(_shaftType___!=null)
			{
				toReturn.Add(_shaftType___);
			}
			if(_shaftType__!=null)
			{
				toReturn.Add(_shaftType__);
			}
			if(_shaftType_!=null)
			{
				toReturn.Add(_shaftType_);
			}
			if(_shaftType!=null)
			{
				toReturn.Add(_shaftType);
			}
			if(_shrinkElement!=null)
			{
				toReturn.Add(_shrinkElement);
			}
			if(_vibrations!=null)
			{
				toReturn.Add(_vibrations);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();


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


				info.AddValue("_bearingError___", (!this.MarkedForDeletion?_bearingError___:null));
				info.AddValue("_bearingError____", (!this.MarkedForDeletion?_bearingError____:null));
				info.AddValue("_bearingError_____", (!this.MarkedForDeletion?_bearingError_____:null));
				info.AddValue("_bearingError", (!this.MarkedForDeletion?_bearingError:null));
				info.AddValue("_bearingError_", (!this.MarkedForDeletion?_bearingError_:null));
				info.AddValue("_bearingError__", (!this.MarkedForDeletion?_bearingError__:null));
				info.AddValue("_bearingPos____", (!this.MarkedForDeletion?_bearingPos____:null));
				info.AddValue("_bearingPos_____", (!this.MarkedForDeletion?_bearingPos_____:null));
				info.AddValue("_bearingPos___", (!this.MarkedForDeletion?_bearingPos___:null));
				info.AddValue("_bearingPos", (!this.MarkedForDeletion?_bearingPos:null));
				info.AddValue("_bearingPos_", (!this.MarkedForDeletion?_bearingPos_:null));
				info.AddValue("_bearingPos__", (!this.MarkedForDeletion?_bearingPos__:null));
				info.AddValue("_bearingType", (!this.MarkedForDeletion?_bearingType:null));
				info.AddValue("_bearingType_____", (!this.MarkedForDeletion?_bearingType_____:null));
				info.AddValue("_bearingType____", (!this.MarkedForDeletion?_bearingType____:null));
				info.AddValue("_bearingType___", (!this.MarkedForDeletion?_bearingType___:null));
				info.AddValue("_bearingType__", (!this.MarkedForDeletion?_bearingType__:null));
				info.AddValue("_bearingType_", (!this.MarkedForDeletion?_bearingType_:null));
				info.AddValue("_booleanAnswer_", (!this.MarkedForDeletion?_booleanAnswer_:null));
				info.AddValue("_booleanAnswer", (!this.MarkedForDeletion?_booleanAnswer:null));
				info.AddValue("_componentInspectionReport", (!this.MarkedForDeletion?_componentInspectionReport:null));
				info.AddValue("_coupling", (!this.MarkedForDeletion?_coupling:null));
				info.AddValue("_damageDecision____________", (!this.MarkedForDeletion?_damageDecision____________:null));
				info.AddValue("_damageDecision_____________", (!this.MarkedForDeletion?_damageDecision_____________:null));
				info.AddValue("_damageDecision__________", (!this.MarkedForDeletion?_damageDecision__________:null));
				info.AddValue("_damageDecision___________", (!this.MarkedForDeletion?_damageDecision___________:null));
				info.AddValue("_damageDecision_______________", (!this.MarkedForDeletion?_damageDecision_______________:null));
				info.AddValue("_damageDecision________________", (!this.MarkedForDeletion?_damageDecision________________:null));
				info.AddValue("_damageDecision_________________", (!this.MarkedForDeletion?_damageDecision_________________:null));
				info.AddValue("_damageDecision______________", (!this.MarkedForDeletion?_damageDecision______________:null));
				info.AddValue("_damageDecision___", (!this.MarkedForDeletion?_damageDecision___:null));
				info.AddValue("_damageDecision__", (!this.MarkedForDeletion?_damageDecision__:null));
				info.AddValue("_damageDecision____", (!this.MarkedForDeletion?_damageDecision____:null));
				info.AddValue("_damageDecision_____", (!this.MarkedForDeletion?_damageDecision_____:null));
				info.AddValue("_damageDecision________", (!this.MarkedForDeletion?_damageDecision________:null));
				info.AddValue("_damageDecision_________", (!this.MarkedForDeletion?_damageDecision_________:null));
				info.AddValue("_damageDecision______", (!this.MarkedForDeletion?_damageDecision______:null));
				info.AddValue("_damageDecision_______", (!this.MarkedForDeletion?_damageDecision_______:null));
				info.AddValue("_damageDecision__________________", (!this.MarkedForDeletion?_damageDecision__________________:null));
				info.AddValue("_damageDecision_", (!this.MarkedForDeletion?_damageDecision_:null));
				info.AddValue("_damageDecision", (!this.MarkedForDeletion?_damageDecision:null));
				info.AddValue("_damageDecision___________________", (!this.MarkedForDeletion?_damageDecision___________________:null));
				info.AddValue("_damageDecision____________________", (!this.MarkedForDeletion?_damageDecision____________________:null));
				info.AddValue("_debrisGearbox", (!this.MarkedForDeletion?_debrisGearbox:null));
				info.AddValue("_debrisOnMagnet", (!this.MarkedForDeletion?_debrisOnMagnet:null));
				info.AddValue("_electricalPump", (!this.MarkedForDeletion?_electricalPump:null));
				info.AddValue("_filterBlockType", (!this.MarkedForDeletion?_filterBlockType:null));
				info.AddValue("_gearboxManufacturer", (!this.MarkedForDeletion?_gearboxManufacturer:null));
				info.AddValue("_gearboxRevision", (!this.MarkedForDeletion?_gearboxRevision:null));
				info.AddValue("_gearboxType", (!this.MarkedForDeletion?_gearboxType:null));
				info.AddValue("_gearError___________", (!this.MarkedForDeletion?_gearError___________:null));
				info.AddValue("_gearError_______", (!this.MarkedForDeletion?_gearError_______:null));
				info.AddValue("_gearError________", (!this.MarkedForDeletion?_gearError________:null));
				info.AddValue("_gearError_____", (!this.MarkedForDeletion?_gearError_____:null));
				info.AddValue("_gearError______", (!this.MarkedForDeletion?_gearError______:null));
				info.AddValue("_gearError____________", (!this.MarkedForDeletion?_gearError____________:null));
				info.AddValue("_gearError_____________", (!this.MarkedForDeletion?_gearError_____________:null));
				info.AddValue("_gearError_________", (!this.MarkedForDeletion?_gearError_________:null));
				info.AddValue("_gearError__________", (!this.MarkedForDeletion?_gearError__________:null));
				info.AddValue("_gearError__", (!this.MarkedForDeletion?_gearError__:null));
				info.AddValue("_gearError______________", (!this.MarkedForDeletion?_gearError______________:null));
				info.AddValue("_gearError____", (!this.MarkedForDeletion?_gearError____:null));
				info.AddValue("_gearError___", (!this.MarkedForDeletion?_gearError___:null));
				info.AddValue("_gearError", (!this.MarkedForDeletion?_gearError:null));
				info.AddValue("_gearError_", (!this.MarkedForDeletion?_gearError_:null));
				info.AddValue("_gearType________", (!this.MarkedForDeletion?_gearType________:null));
				info.AddValue("_gearType__________", (!this.MarkedForDeletion?_gearType__________:null));
				info.AddValue("_gearType_________", (!this.MarkedForDeletion?_gearType_________:null));
				info.AddValue("_gearType_____", (!this.MarkedForDeletion?_gearType_____:null));
				info.AddValue("_gearType______________", (!this.MarkedForDeletion?_gearType______________:null));
				info.AddValue("_gearType____", (!this.MarkedForDeletion?_gearType____:null));
				info.AddValue("_gearType____________", (!this.MarkedForDeletion?_gearType____________:null));
				info.AddValue("_gearType_____________", (!this.MarkedForDeletion?_gearType_____________:null));
				info.AddValue("_gearType__", (!this.MarkedForDeletion?_gearType__:null));
				info.AddValue("_gearType_", (!this.MarkedForDeletion?_gearType_:null));
				info.AddValue("_gearType", (!this.MarkedForDeletion?_gearType:null));
				info.AddValue("_gearType___", (!this.MarkedForDeletion?_gearType___:null));
				info.AddValue("_gearType_______", (!this.MarkedForDeletion?_gearType_______:null));
				info.AddValue("_gearType______", (!this.MarkedForDeletion?_gearType______:null));
				info.AddValue("_gearType___________", (!this.MarkedForDeletion?_gearType___________:null));
				info.AddValue("_generatorManufacturer_", (!this.MarkedForDeletion?_generatorManufacturer_:null));
				info.AddValue("_generatorManufacturer", (!this.MarkedForDeletion?_generatorManufacturer:null));
				info.AddValue("_housingError_____", (!this.MarkedForDeletion?_housingError_____:null));
				info.AddValue("_housingError____", (!this.MarkedForDeletion?_housingError____:null));
				info.AddValue("_housingError___", (!this.MarkedForDeletion?_housingError___:null));
				info.AddValue("_housingError", (!this.MarkedForDeletion?_housingError:null));
				info.AddValue("_housingError_", (!this.MarkedForDeletion?_housingError_:null));
				info.AddValue("_housingError__", (!this.MarkedForDeletion?_housingError__:null));
				info.AddValue("_inlineFilter", (!this.MarkedForDeletion?_inlineFilter:null));
				info.AddValue("_magnetPos", (!this.MarkedForDeletion?_magnetPos:null));
				info.AddValue("_mechanicalOilPump", (!this.MarkedForDeletion?_mechanicalOilPump:null));
				info.AddValue("_noise", (!this.MarkedForDeletion?_noise:null));
				info.AddValue("_oilLevel", (!this.MarkedForDeletion?_oilLevel:null));
				info.AddValue("_oilType", (!this.MarkedForDeletion?_oilType:null));
				info.AddValue("_overallGearboxCondition", (!this.MarkedForDeletion?_overallGearboxCondition:null));
				info.AddValue("_shaftError__", (!this.MarkedForDeletion?_shaftError__:null));
				info.AddValue("_shaftError___", (!this.MarkedForDeletion?_shaftError___:null));
				info.AddValue("_shaftError", (!this.MarkedForDeletion?_shaftError:null));
				info.AddValue("_shaftError_", (!this.MarkedForDeletion?_shaftError_:null));
				info.AddValue("_shaftType___", (!this.MarkedForDeletion?_shaftType___:null));
				info.AddValue("_shaftType__", (!this.MarkedForDeletion?_shaftType__:null));
				info.AddValue("_shaftType_", (!this.MarkedForDeletion?_shaftType_:null));
				info.AddValue("_shaftType", (!this.MarkedForDeletion?_shaftType:null));
				info.AddValue("_shrinkElement", (!this.MarkedForDeletion?_shrinkElement:null));
				info.AddValue("_vibrations", (!this.MarkedForDeletion?_vibrations:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ComponentInspectionReportGearboxFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ComponentInspectionReportGearboxFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ComponentInspectionReportGearboxRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingError___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingErrorFields.BearingErrorId, null, ComparisonOperator.Equal, this.GearboxBearingsDamage4BearingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingError____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingErrorFields.BearingErrorId, null, ComparisonOperator.Equal, this.GearboxBearingsDamage5BearingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingError_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingErrorFields.BearingErrorId, null, ComparisonOperator.Equal, this.GearboxBearingsDamage6BearingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingError()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingErrorFields.BearingErrorId, null, ComparisonOperator.Equal, this.GearboxBearingsDamage1BearingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingError_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingErrorFields.BearingErrorId, null, ComparisonOperator.Equal, this.GearboxBearingsDamage2BearingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingError__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingErrorFields.BearingErrorId, null, ComparisonOperator.Equal, this.GearboxBearingsDamage3BearingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPos____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingPosFields.BearingPosId, null, ComparisonOperator.Equal, this.GearboxBearingsPosition5BearingPosId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPos_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingPosFields.BearingPosId, null, ComparisonOperator.Equal, this.GearboxBearingsPosition6BearingPosId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPos___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingPosFields.BearingPosId, null, ComparisonOperator.Equal, this.GearboxBearingsPosition4BearingPosId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPos()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingPosFields.BearingPosId, null, ComparisonOperator.Equal, this.GearboxBearingsPosition1BearingPosId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPos_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingPosFields.BearingPosId, null, ComparisonOperator.Equal, this.GearboxBearingsPosition2BearingPosId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPos__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingPosFields.BearingPosId, null, ComparisonOperator.Equal, this.GearboxBearingsPosition3BearingPosId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingTypeFields.BearingTypeId, null, ComparisonOperator.Equal, this.GearboxBearingsLocation1BearingTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingType_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingTypeFields.BearingTypeId, null, ComparisonOperator.Equal, this.GearboxBearingsLocation6BearingTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingType____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingTypeFields.BearingTypeId, null, ComparisonOperator.Equal, this.GearboxBearingsLocation5BearingTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingType___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingTypeFields.BearingTypeId, null, ComparisonOperator.Equal, this.GearboxBearingsLocation4BearingTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingType__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingTypeFields.BearingTypeId, null, ComparisonOperator.Equal, this.GearboxBearingsLocation3BearingTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BearingType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingType_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BearingTypeFields.BearingTypeId, null, ComparisonOperator.Equal, this.GearboxBearingsLocation2BearingTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.GearboxClaimRelevantBooleanAnswerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BooleanAnswerFields.BooleanAnswerId, null, ComparisonOperator.Equal, this.GearboxOffLineFilterId));
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
		/// the related entity of type 'Coupling' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCoupling()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CouplingFields.CouplingId, null, ComparisonOperator.Equal, this.GearboxCouplingId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision1DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision_____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision2DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision__________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision14DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision___________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision15DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision_______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision4DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision5DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision_________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision6DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision3DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxBearingDecision4DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxBearingDecision3DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxBearingDecision5DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxBearingDecision6DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision12DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision_________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision13DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision10DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision11DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision__________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision7DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxBearingDecision1DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxBearingDecision2DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision___________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision8DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecision____________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DamageDecisionFields.DamageDecisionId, null, ComparisonOperator.Equal, this.GearboxGearDecision9DamageDecisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DebrisGearbox' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDebrisGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DebrisGearboxFields.DebrisGearboxId, null, ComparisonOperator.Equal, this.GearboxDebrisGearBoxId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'DebrisOnMagnet' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDebrisOnMagnet()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(DebrisOnMagnetFields.DebrisOnMagnetId, null, ComparisonOperator.Equal, this.GearboxDebrisOnMagnetId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ElectricalPump' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoElectricalPump()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ElectricalPumpFields.ElectricalPumpId, null, ComparisonOperator.Equal, this.GearboxElectricalPumpId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'FilterBlockType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFilterBlockType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(FilterBlockTypeFields.FilterBlockTypeId, null, ComparisonOperator.Equal, this.GearboxFilterBlockTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearboxManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxManufacturer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearboxManufacturerFields.GearboxManufacturerId, null, ComparisonOperator.Equal, this.GearboxManufacturerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearboxRevision' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxRevision()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearboxRevisionFields.GearboxRevisionId, null, ComparisonOperator.Equal, this.GearboxRevisionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearboxType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearboxTypeFields.GearboxTypeId, null, ComparisonOperator.Equal, this.GearboxTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError___________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage6GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage12GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage13GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage10GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage11GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage7GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError_____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage8GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError_________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage14GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError__________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage15GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage3GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage9GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage5GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage4GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage1GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearError_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearErrorFields.GearErrorId, null, ComparisonOperator.Equal, this.GearboxTypeofDamage2GearErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation12GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType__________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation14GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType_________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation13GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation6GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation9GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation5GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation7GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType_____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation8GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation3GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation2GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation1GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation4GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation11GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation10GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GearType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearType___________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GearTypeFields.GearTypeId, null, ComparisonOperator.Equal, this.GearboxExactLocation15GearTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturer_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorManufacturerFields.GeneratorManufacturerId, null, ComparisonOperator.Equal, this.GearboxGeneratorManufacturerId2));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturer()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(GeneratorManufacturerFields.GeneratorManufacturerId, null, ComparisonOperator.Equal, this.GearboxGeneratorManufacturerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HousingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingError_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HousingErrorFields.HousingErrorId, null, ComparisonOperator.Equal, this.GearboxHsstageHousingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HousingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingError____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HousingErrorFields.HousingErrorId, null, ComparisonOperator.Equal, this.GearboxAuxStageHousingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HousingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingError___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HousingErrorFields.HousingErrorId, null, ComparisonOperator.Equal, this.GearboxFrontPlateHousingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HousingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingError()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HousingErrorFields.HousingErrorId, null, ComparisonOperator.Equal, this.GearboxPlanetStage1HousingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HousingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingError_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HousingErrorFields.HousingErrorId, null, ComparisonOperator.Equal, this.GearboxPlanetStage2HousingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'HousingError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingError__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(HousingErrorFields.HousingErrorId, null, ComparisonOperator.Equal, this.GearboxHelicalStageHousingErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'InlineFilter' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInlineFilter()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(InlineFilterFields.InlineFilterId, null, ComparisonOperator.Equal, this.GearboxInLineFilterId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MagnetPos' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMagnetPos()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MagnetPosFields.MagnetPosId, null, ComparisonOperator.Equal, this.GearboxDebrisStagesMagnetPosId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'MechanicalOilPump' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMechanicalOilPump()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(MechanicalOilPumpFields.MechanicalOilPumpId, null, ComparisonOperator.Equal, this.GearboxMechanicalOilPumpId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Noise' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNoise()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.GearboxNoiseId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OilLevel' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOilLevel()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OilLevelFields.OilLevelId, null, ComparisonOperator.Equal, this.GearboxOilLevelId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OilType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOilType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OilTypeFields.OilTypeId, null, ComparisonOperator.Equal, this.GearboxOilTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OverallGearboxCondition' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOverallGearboxCondition()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OverallGearboxConditionFields.OverallGearboxConditionId, null, ComparisonOperator.Equal, this.GearboxOverallGearboxConditionId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ShaftError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftError__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShaftErrorFields.ShaftErrorId, null, ComparisonOperator.Equal, this.GearboxShaftsTypeofDamage3ShaftErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ShaftError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftError___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShaftErrorFields.ShaftErrorId, null, ComparisonOperator.Equal, this.GearboxShaftsTypeofDamage4ShaftErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ShaftError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftError()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShaftErrorFields.ShaftErrorId, null, ComparisonOperator.Equal, this.GearboxShaftsTypeofDamage1ShaftErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ShaftError' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftError_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShaftErrorFields.ShaftErrorId, null, ComparisonOperator.Equal, this.GearboxShaftsTypeofDamage2ShaftErrorId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ShaftType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftType___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShaftTypeFields.ShaftTypeId, null, ComparisonOperator.Equal, this.GearboxShaftsExactLocation4ShaftTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ShaftType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftType__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShaftTypeFields.ShaftTypeId, null, ComparisonOperator.Equal, this.GearboxShaftsExactLocation3ShaftTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ShaftType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftType_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShaftTypeFields.ShaftTypeId, null, ComparisonOperator.Equal, this.GearboxShaftsExactLocation2ShaftTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ShaftType' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftType()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShaftTypeFields.ShaftTypeId, null, ComparisonOperator.Equal, this.GearboxShaftsExactLocation1ShaftTypeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ShrinkElement' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShrinkElement()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ShrinkElementFields.ShrinkElementId, null, ComparisonOperator.Equal, this.GearboxShrinkElementId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Vibrations' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoVibrations()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(VibrationsFields.VibrationsId, null, ComparisonOperator.Equal, this.GearboxVibrationsId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGearboxEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);


		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{


			return base.HasPopulatedMemberEntityCollections();
		}
		
		/// <summary>Creates the member entity collections queue.</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		/// <param name="requiredQueue">The required queue.</param>
		protected override void CreateMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue, Queue<bool> requiredQueue) 
		{
			base.CreateMemberEntityCollectionsQueue(collectionsQueue, requiredQueue);


		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("BearingError___", _bearingError___);
			toReturn.Add("BearingError____", _bearingError____);
			toReturn.Add("BearingError_____", _bearingError_____);
			toReturn.Add("BearingError", _bearingError);
			toReturn.Add("BearingError_", _bearingError_);
			toReturn.Add("BearingError__", _bearingError__);
			toReturn.Add("BearingPos____", _bearingPos____);
			toReturn.Add("BearingPos_____", _bearingPos_____);
			toReturn.Add("BearingPos___", _bearingPos___);
			toReturn.Add("BearingPos", _bearingPos);
			toReturn.Add("BearingPos_", _bearingPos_);
			toReturn.Add("BearingPos__", _bearingPos__);
			toReturn.Add("BearingType", _bearingType);
			toReturn.Add("BearingType_____", _bearingType_____);
			toReturn.Add("BearingType____", _bearingType____);
			toReturn.Add("BearingType___", _bearingType___);
			toReturn.Add("BearingType__", _bearingType__);
			toReturn.Add("BearingType_", _bearingType_);
			toReturn.Add("BooleanAnswer_", _booleanAnswer_);
			toReturn.Add("BooleanAnswer", _booleanAnswer);
			toReturn.Add("ComponentInspectionReport", _componentInspectionReport);
			toReturn.Add("Coupling", _coupling);
			toReturn.Add("DamageDecision____________", _damageDecision____________);
			toReturn.Add("DamageDecision_____________", _damageDecision_____________);
			toReturn.Add("DamageDecision__________", _damageDecision__________);
			toReturn.Add("DamageDecision___________", _damageDecision___________);
			toReturn.Add("DamageDecision_______________", _damageDecision_______________);
			toReturn.Add("DamageDecision________________", _damageDecision________________);
			toReturn.Add("DamageDecision_________________", _damageDecision_________________);
			toReturn.Add("DamageDecision______________", _damageDecision______________);
			toReturn.Add("DamageDecision___", _damageDecision___);
			toReturn.Add("DamageDecision__", _damageDecision__);
			toReturn.Add("DamageDecision____", _damageDecision____);
			toReturn.Add("DamageDecision_____", _damageDecision_____);
			toReturn.Add("DamageDecision________", _damageDecision________);
			toReturn.Add("DamageDecision_________", _damageDecision_________);
			toReturn.Add("DamageDecision______", _damageDecision______);
			toReturn.Add("DamageDecision_______", _damageDecision_______);
			toReturn.Add("DamageDecision__________________", _damageDecision__________________);
			toReturn.Add("DamageDecision_", _damageDecision_);
			toReturn.Add("DamageDecision", _damageDecision);
			toReturn.Add("DamageDecision___________________", _damageDecision___________________);
			toReturn.Add("DamageDecision____________________", _damageDecision____________________);
			toReturn.Add("DebrisGearbox", _debrisGearbox);
			toReturn.Add("DebrisOnMagnet", _debrisOnMagnet);
			toReturn.Add("ElectricalPump", _electricalPump);
			toReturn.Add("FilterBlockType", _filterBlockType);
			toReturn.Add("GearboxManufacturer", _gearboxManufacturer);
			toReturn.Add("GearboxRevision", _gearboxRevision);
			toReturn.Add("GearboxType", _gearboxType);
			toReturn.Add("GearError___________", _gearError___________);
			toReturn.Add("GearError_______", _gearError_______);
			toReturn.Add("GearError________", _gearError________);
			toReturn.Add("GearError_____", _gearError_____);
			toReturn.Add("GearError______", _gearError______);
			toReturn.Add("GearError____________", _gearError____________);
			toReturn.Add("GearError_____________", _gearError_____________);
			toReturn.Add("GearError_________", _gearError_________);
			toReturn.Add("GearError__________", _gearError__________);
			toReturn.Add("GearError__", _gearError__);
			toReturn.Add("GearError______________", _gearError______________);
			toReturn.Add("GearError____", _gearError____);
			toReturn.Add("GearError___", _gearError___);
			toReturn.Add("GearError", _gearError);
			toReturn.Add("GearError_", _gearError_);
			toReturn.Add("GearType________", _gearType________);
			toReturn.Add("GearType__________", _gearType__________);
			toReturn.Add("GearType_________", _gearType_________);
			toReturn.Add("GearType_____", _gearType_____);
			toReturn.Add("GearType______________", _gearType______________);
			toReturn.Add("GearType____", _gearType____);
			toReturn.Add("GearType____________", _gearType____________);
			toReturn.Add("GearType_____________", _gearType_____________);
			toReturn.Add("GearType__", _gearType__);
			toReturn.Add("GearType_", _gearType_);
			toReturn.Add("GearType", _gearType);
			toReturn.Add("GearType___", _gearType___);
			toReturn.Add("GearType_______", _gearType_______);
			toReturn.Add("GearType______", _gearType______);
			toReturn.Add("GearType___________", _gearType___________);
			toReturn.Add("GeneratorManufacturer_", _generatorManufacturer_);
			toReturn.Add("GeneratorManufacturer", _generatorManufacturer);
			toReturn.Add("HousingError_____", _housingError_____);
			toReturn.Add("HousingError____", _housingError____);
			toReturn.Add("HousingError___", _housingError___);
			toReturn.Add("HousingError", _housingError);
			toReturn.Add("HousingError_", _housingError_);
			toReturn.Add("HousingError__", _housingError__);
			toReturn.Add("InlineFilter", _inlineFilter);
			toReturn.Add("MagnetPos", _magnetPos);
			toReturn.Add("MechanicalOilPump", _mechanicalOilPump);
			toReturn.Add("Noise", _noise);
			toReturn.Add("OilLevel", _oilLevel);
			toReturn.Add("OilType", _oilType);
			toReturn.Add("OverallGearboxCondition", _overallGearboxCondition);
			toReturn.Add("ShaftError__", _shaftError__);
			toReturn.Add("ShaftError___", _shaftError___);
			toReturn.Add("ShaftError", _shaftError);
			toReturn.Add("ShaftError_", _shaftError_);
			toReturn.Add("ShaftType___", _shaftType___);
			toReturn.Add("ShaftType__", _shaftType__);
			toReturn.Add("ShaftType_", _shaftType_);
			toReturn.Add("ShaftType", _shaftType);
			toReturn.Add("ShrinkElement", _shrinkElement);
			toReturn.Add("Vibrations", _vibrations);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_bearingError___!=null)
			{
				_bearingError___.ActiveContext = base.ActiveContext;
			}
			if(_bearingError____!=null)
			{
				_bearingError____.ActiveContext = base.ActiveContext;
			}
			if(_bearingError_____!=null)
			{
				_bearingError_____.ActiveContext = base.ActiveContext;
			}
			if(_bearingError!=null)
			{
				_bearingError.ActiveContext = base.ActiveContext;
			}
			if(_bearingError_!=null)
			{
				_bearingError_.ActiveContext = base.ActiveContext;
			}
			if(_bearingError__!=null)
			{
				_bearingError__.ActiveContext = base.ActiveContext;
			}
			if(_bearingPos____!=null)
			{
				_bearingPos____.ActiveContext = base.ActiveContext;
			}
			if(_bearingPos_____!=null)
			{
				_bearingPos_____.ActiveContext = base.ActiveContext;
			}
			if(_bearingPos___!=null)
			{
				_bearingPos___.ActiveContext = base.ActiveContext;
			}
			if(_bearingPos!=null)
			{
				_bearingPos.ActiveContext = base.ActiveContext;
			}
			if(_bearingPos_!=null)
			{
				_bearingPos_.ActiveContext = base.ActiveContext;
			}
			if(_bearingPos__!=null)
			{
				_bearingPos__.ActiveContext = base.ActiveContext;
			}
			if(_bearingType!=null)
			{
				_bearingType.ActiveContext = base.ActiveContext;
			}
			if(_bearingType_____!=null)
			{
				_bearingType_____.ActiveContext = base.ActiveContext;
			}
			if(_bearingType____!=null)
			{
				_bearingType____.ActiveContext = base.ActiveContext;
			}
			if(_bearingType___!=null)
			{
				_bearingType___.ActiveContext = base.ActiveContext;
			}
			if(_bearingType__!=null)
			{
				_bearingType__.ActiveContext = base.ActiveContext;
			}
			if(_bearingType_!=null)
			{
				_bearingType_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer_!=null)
			{
				_booleanAnswer_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswer!=null)
			{
				_booleanAnswer.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReport!=null)
			{
				_componentInspectionReport.ActiveContext = base.ActiveContext;
			}
			if(_coupling!=null)
			{
				_coupling.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision____________!=null)
			{
				_damageDecision____________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision_____________!=null)
			{
				_damageDecision_____________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision__________!=null)
			{
				_damageDecision__________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision___________!=null)
			{
				_damageDecision___________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision_______________!=null)
			{
				_damageDecision_______________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision________________!=null)
			{
				_damageDecision________________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision_________________!=null)
			{
				_damageDecision_________________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision______________!=null)
			{
				_damageDecision______________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision___!=null)
			{
				_damageDecision___.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision__!=null)
			{
				_damageDecision__.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision____!=null)
			{
				_damageDecision____.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision_____!=null)
			{
				_damageDecision_____.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision________!=null)
			{
				_damageDecision________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision_________!=null)
			{
				_damageDecision_________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision______!=null)
			{
				_damageDecision______.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision_______!=null)
			{
				_damageDecision_______.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision__________________!=null)
			{
				_damageDecision__________________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision_!=null)
			{
				_damageDecision_.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision!=null)
			{
				_damageDecision.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision___________________!=null)
			{
				_damageDecision___________________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecision____________________!=null)
			{
				_damageDecision____________________.ActiveContext = base.ActiveContext;
			}
			if(_debrisGearbox!=null)
			{
				_debrisGearbox.ActiveContext = base.ActiveContext;
			}
			if(_debrisOnMagnet!=null)
			{
				_debrisOnMagnet.ActiveContext = base.ActiveContext;
			}
			if(_electricalPump!=null)
			{
				_electricalPump.ActiveContext = base.ActiveContext;
			}
			if(_filterBlockType!=null)
			{
				_filterBlockType.ActiveContext = base.ActiveContext;
			}
			if(_gearboxManufacturer!=null)
			{
				_gearboxManufacturer.ActiveContext = base.ActiveContext;
			}
			if(_gearboxRevision!=null)
			{
				_gearboxRevision.ActiveContext = base.ActiveContext;
			}
			if(_gearboxType!=null)
			{
				_gearboxType.ActiveContext = base.ActiveContext;
			}
			if(_gearError___________!=null)
			{
				_gearError___________.ActiveContext = base.ActiveContext;
			}
			if(_gearError_______!=null)
			{
				_gearError_______.ActiveContext = base.ActiveContext;
			}
			if(_gearError________!=null)
			{
				_gearError________.ActiveContext = base.ActiveContext;
			}
			if(_gearError_____!=null)
			{
				_gearError_____.ActiveContext = base.ActiveContext;
			}
			if(_gearError______!=null)
			{
				_gearError______.ActiveContext = base.ActiveContext;
			}
			if(_gearError____________!=null)
			{
				_gearError____________.ActiveContext = base.ActiveContext;
			}
			if(_gearError_____________!=null)
			{
				_gearError_____________.ActiveContext = base.ActiveContext;
			}
			if(_gearError_________!=null)
			{
				_gearError_________.ActiveContext = base.ActiveContext;
			}
			if(_gearError__________!=null)
			{
				_gearError__________.ActiveContext = base.ActiveContext;
			}
			if(_gearError__!=null)
			{
				_gearError__.ActiveContext = base.ActiveContext;
			}
			if(_gearError______________!=null)
			{
				_gearError______________.ActiveContext = base.ActiveContext;
			}
			if(_gearError____!=null)
			{
				_gearError____.ActiveContext = base.ActiveContext;
			}
			if(_gearError___!=null)
			{
				_gearError___.ActiveContext = base.ActiveContext;
			}
			if(_gearError!=null)
			{
				_gearError.ActiveContext = base.ActiveContext;
			}
			if(_gearError_!=null)
			{
				_gearError_.ActiveContext = base.ActiveContext;
			}
			if(_gearType________!=null)
			{
				_gearType________.ActiveContext = base.ActiveContext;
			}
			if(_gearType__________!=null)
			{
				_gearType__________.ActiveContext = base.ActiveContext;
			}
			if(_gearType_________!=null)
			{
				_gearType_________.ActiveContext = base.ActiveContext;
			}
			if(_gearType_____!=null)
			{
				_gearType_____.ActiveContext = base.ActiveContext;
			}
			if(_gearType______________!=null)
			{
				_gearType______________.ActiveContext = base.ActiveContext;
			}
			if(_gearType____!=null)
			{
				_gearType____.ActiveContext = base.ActiveContext;
			}
			if(_gearType____________!=null)
			{
				_gearType____________.ActiveContext = base.ActiveContext;
			}
			if(_gearType_____________!=null)
			{
				_gearType_____________.ActiveContext = base.ActiveContext;
			}
			if(_gearType__!=null)
			{
				_gearType__.ActiveContext = base.ActiveContext;
			}
			if(_gearType_!=null)
			{
				_gearType_.ActiveContext = base.ActiveContext;
			}
			if(_gearType!=null)
			{
				_gearType.ActiveContext = base.ActiveContext;
			}
			if(_gearType___!=null)
			{
				_gearType___.ActiveContext = base.ActiveContext;
			}
			if(_gearType_______!=null)
			{
				_gearType_______.ActiveContext = base.ActiveContext;
			}
			if(_gearType______!=null)
			{
				_gearType______.ActiveContext = base.ActiveContext;
			}
			if(_gearType___________!=null)
			{
				_gearType___________.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturer_!=null)
			{
				_generatorManufacturer_.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturer!=null)
			{
				_generatorManufacturer.ActiveContext = base.ActiveContext;
			}
			if(_housingError_____!=null)
			{
				_housingError_____.ActiveContext = base.ActiveContext;
			}
			if(_housingError____!=null)
			{
				_housingError____.ActiveContext = base.ActiveContext;
			}
			if(_housingError___!=null)
			{
				_housingError___.ActiveContext = base.ActiveContext;
			}
			if(_housingError!=null)
			{
				_housingError.ActiveContext = base.ActiveContext;
			}
			if(_housingError_!=null)
			{
				_housingError_.ActiveContext = base.ActiveContext;
			}
			if(_housingError__!=null)
			{
				_housingError__.ActiveContext = base.ActiveContext;
			}
			if(_inlineFilter!=null)
			{
				_inlineFilter.ActiveContext = base.ActiveContext;
			}
			if(_magnetPos!=null)
			{
				_magnetPos.ActiveContext = base.ActiveContext;
			}
			if(_mechanicalOilPump!=null)
			{
				_mechanicalOilPump.ActiveContext = base.ActiveContext;
			}
			if(_noise!=null)
			{
				_noise.ActiveContext = base.ActiveContext;
			}
			if(_oilLevel!=null)
			{
				_oilLevel.ActiveContext = base.ActiveContext;
			}
			if(_oilType!=null)
			{
				_oilType.ActiveContext = base.ActiveContext;
			}
			if(_overallGearboxCondition!=null)
			{
				_overallGearboxCondition.ActiveContext = base.ActiveContext;
			}
			if(_shaftError__!=null)
			{
				_shaftError__.ActiveContext = base.ActiveContext;
			}
			if(_shaftError___!=null)
			{
				_shaftError___.ActiveContext = base.ActiveContext;
			}
			if(_shaftError!=null)
			{
				_shaftError.ActiveContext = base.ActiveContext;
			}
			if(_shaftError_!=null)
			{
				_shaftError_.ActiveContext = base.ActiveContext;
			}
			if(_shaftType___!=null)
			{
				_shaftType___.ActiveContext = base.ActiveContext;
			}
			if(_shaftType__!=null)
			{
				_shaftType__.ActiveContext = base.ActiveContext;
			}
			if(_shaftType_!=null)
			{
				_shaftType_.ActiveContext = base.ActiveContext;
			}
			if(_shaftType!=null)
			{
				_shaftType.ActiveContext = base.ActiveContext;
			}
			if(_shrinkElement!=null)
			{
				_shrinkElement.ActiveContext = base.ActiveContext;
			}
			if(_vibrations!=null)
			{
				_vibrations.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_bearingError___ = null;
			_bearingError____ = null;
			_bearingError_____ = null;
			_bearingError = null;
			_bearingError_ = null;
			_bearingError__ = null;
			_bearingPos____ = null;
			_bearingPos_____ = null;
			_bearingPos___ = null;
			_bearingPos = null;
			_bearingPos_ = null;
			_bearingPos__ = null;
			_bearingType = null;
			_bearingType_____ = null;
			_bearingType____ = null;
			_bearingType___ = null;
			_bearingType__ = null;
			_bearingType_ = null;
			_booleanAnswer_ = null;
			_booleanAnswer = null;
			_componentInspectionReport = null;
			_coupling = null;
			_damageDecision____________ = null;
			_damageDecision_____________ = null;
			_damageDecision__________ = null;
			_damageDecision___________ = null;
			_damageDecision_______________ = null;
			_damageDecision________________ = null;
			_damageDecision_________________ = null;
			_damageDecision______________ = null;
			_damageDecision___ = null;
			_damageDecision__ = null;
			_damageDecision____ = null;
			_damageDecision_____ = null;
			_damageDecision________ = null;
			_damageDecision_________ = null;
			_damageDecision______ = null;
			_damageDecision_______ = null;
			_damageDecision__________________ = null;
			_damageDecision_ = null;
			_damageDecision = null;
			_damageDecision___________________ = null;
			_damageDecision____________________ = null;
			_debrisGearbox = null;
			_debrisOnMagnet = null;
			_electricalPump = null;
			_filterBlockType = null;
			_gearboxManufacturer = null;
			_gearboxRevision = null;
			_gearboxType = null;
			_gearError___________ = null;
			_gearError_______ = null;
			_gearError________ = null;
			_gearError_____ = null;
			_gearError______ = null;
			_gearError____________ = null;
			_gearError_____________ = null;
			_gearError_________ = null;
			_gearError__________ = null;
			_gearError__ = null;
			_gearError______________ = null;
			_gearError____ = null;
			_gearError___ = null;
			_gearError = null;
			_gearError_ = null;
			_gearType________ = null;
			_gearType__________ = null;
			_gearType_________ = null;
			_gearType_____ = null;
			_gearType______________ = null;
			_gearType____ = null;
			_gearType____________ = null;
			_gearType_____________ = null;
			_gearType__ = null;
			_gearType_ = null;
			_gearType = null;
			_gearType___ = null;
			_gearType_______ = null;
			_gearType______ = null;
			_gearType___________ = null;
			_generatorManufacturer_ = null;
			_generatorManufacturer = null;
			_housingError_____ = null;
			_housingError____ = null;
			_housingError___ = null;
			_housingError = null;
			_housingError_ = null;
			_housingError__ = null;
			_inlineFilter = null;
			_magnetPos = null;
			_mechanicalOilPump = null;
			_noise = null;
			_oilLevel = null;
			_oilType = null;
			_overallGearboxCondition = null;
			_shaftError__ = null;
			_shaftError___ = null;
			_shaftError = null;
			_shaftError_ = null;
			_shaftType___ = null;
			_shaftType__ = null;
			_shaftType_ = null;
			_shaftType = null;
			_shrinkElement = null;
			_vibrations = null;

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

			_fieldsCustomProperties.Add("ComponentInspectionReportGearboxId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("VestasUniqueIdentifier", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxRevisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("OtherGearboxType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxSerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxOtherManufacturer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxLastOilChangeDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxOilTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxMechanicalOilPumpId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxOilLevelId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxRunHours", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxOilTemperature", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxProduction", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGeneratorManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGeneratorManufacturerId2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxElectricalPumpId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxShrinkElementId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxShrinkElementSerialNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxCouplingId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxFilterBlockTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxInLineFilterId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxOffLineFilterId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxSoftwareRelease", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxShaftsExactLocation1ShaftTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxShaftsExactLocation2ShaftTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxShaftsExactLocation3ShaftTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxShaftsExactLocation4ShaftTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxShaftsTypeofDamage1ShaftErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxShaftsTypeofDamage2ShaftErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxShaftsTypeofDamage3ShaftErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxShaftsTypeofDamage4ShaftErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation1GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation2GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation3GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation4GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation5GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage1GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage2GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage3GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage4GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage5GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsLocation1BearingTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsLocation2BearingTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsLocation3BearingTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsLocation4BearingTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsLocation5BearingTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsPosition1BearingPosId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsPosition2BearingPosId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsPosition3BearingPosId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsPosition4BearingPosId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsPosition5BearingPosId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsDamage1BearingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsDamage2BearingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsDamage3BearingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsDamage4BearingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsDamage5BearingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxPlanetStage1HousingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxPlanetStage2HousingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxHelicalStageHousingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxFrontPlateHousingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxAuxStageHousingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxHsstageHousingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxLooseBolts", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBrokenBolts", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxDefectDamperElements", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTooMuchClearance", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxCrackedTorqueArm", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxNeedsToBeAligned", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxPt100Bearing1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxPt100Bearing2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxPt100Bearing3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxOilLevelSensor", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxOilPressure", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxPt100OilSump", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxFilterIndicator", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxImmersionHeater", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxDrainValve", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxAirBreather", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxSightGlass", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxChipDetector", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxVibrationsId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxNoiseId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxDebrisOnMagnetId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxDebrisStagesMagnetPosId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxDebrisGearBoxId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxMaxTempResetDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTempBearing1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTempBearing2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTempBearing3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTempOilSump", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxLssnrend", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxImsnrend", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxImsrend", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxHssnrend", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxHssrend", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxPitchTube", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxSplitLines", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxHoseAndPiping", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxInputShaft", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxHsspto", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxClaimRelevantBooleanAnswerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxOverallGearboxConditionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation6GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation7GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation8GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation9GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation10GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation11GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation12GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation13GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation14GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxExactLocation15GearTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage6GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage7GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage8GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage9GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage10GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage11GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage12GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage13GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage14GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxTypeofDamage15GearErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision1DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision2DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision3DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision4DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision5DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision6DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision7DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision8DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision9DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision10DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision11DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision12DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision13DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision14DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxGearDecision15DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsLocation6BearingTypeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsPosition6BearingPosId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingsDamage6BearingErrorId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingDecision1DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingDecision2DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingDecision3DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingDecision4DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingDecision5DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxBearingDecision6DamageDecisionId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("GearboxDefectCategorizationScore", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _bearingError___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingError___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingError___, new PropertyChangedEventHandler( OnBearingError___PropertyChanged ), "BearingError___", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage4BearingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage4BearingErrorId } );		
			_bearingError___ = null;
		}

		/// <summary> setups the sync logic for member _bearingError___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingError___(IEntity2 relatedEntity)
		{
			DesetupSyncBearingError___(true, true);
			_bearingError___ = (BearingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingError___, new PropertyChangedEventHandler( OnBearingError___PropertyChanged ), "BearingError___", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage4BearingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingError___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingError____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingError____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingError____, new PropertyChangedEventHandler( OnBearingError____PropertyChanged ), "BearingError____", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage5BearingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage5BearingErrorId } );		
			_bearingError____ = null;
		}

		/// <summary> setups the sync logic for member _bearingError____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingError____(IEntity2 relatedEntity)
		{
			DesetupSyncBearingError____(true, true);
			_bearingError____ = (BearingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingError____, new PropertyChangedEventHandler( OnBearingError____PropertyChanged ), "BearingError____", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage5BearingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingError____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingError_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingError_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingError_____, new PropertyChangedEventHandler( OnBearingError_____PropertyChanged ), "BearingError_____", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage6BearingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage6BearingErrorId } );		
			_bearingError_____ = null;
		}

		/// <summary> setups the sync logic for member _bearingError_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingError_____(IEntity2 relatedEntity)
		{
			DesetupSyncBearingError_____(true, true);
			_bearingError_____ = (BearingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingError_____, new PropertyChangedEventHandler( OnBearingError_____PropertyChanged ), "BearingError_____", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage6BearingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingError_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingError</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingError(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingError, new PropertyChangedEventHandler( OnBearingErrorPropertyChanged ), "BearingError", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage1BearingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage1BearingErrorId } );		
			_bearingError = null;
		}

		/// <summary> setups the sync logic for member _bearingError</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingError(IEntity2 relatedEntity)
		{
			DesetupSyncBearingError(true, true);
			_bearingError = (BearingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingError, new PropertyChangedEventHandler( OnBearingErrorPropertyChanged ), "BearingError", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage1BearingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingErrorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingError_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingError_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingError_, new PropertyChangedEventHandler( OnBearingError_PropertyChanged ), "BearingError_", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage2BearingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage2BearingErrorId } );		
			_bearingError_ = null;
		}

		/// <summary> setups the sync logic for member _bearingError_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingError_(IEntity2 relatedEntity)
		{
			DesetupSyncBearingError_(true, true);
			_bearingError_ = (BearingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingError_, new PropertyChangedEventHandler( OnBearingError_PropertyChanged ), "BearingError_", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage2BearingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingError_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingError__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingError__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingError__, new PropertyChangedEventHandler( OnBearingError__PropertyChanged ), "BearingError__", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage3BearingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage3BearingErrorId } );		
			_bearingError__ = null;
		}

		/// <summary> setups the sync logic for member _bearingError__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingError__(IEntity2 relatedEntity)
		{
			DesetupSyncBearingError__(true, true);
			_bearingError__ = (BearingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingError__, new PropertyChangedEventHandler( OnBearingError__PropertyChanged ), "BearingError__", ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage3BearingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingError__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingPos____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingPos____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingPos____, new PropertyChangedEventHandler( OnBearingPos____PropertyChanged ), "BearingPos____", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition5BearingPosId, true, signalRelatedEntity, "ComponentInspectionReportGearbox____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition5BearingPosId } );		
			_bearingPos____ = null;
		}

		/// <summary> setups the sync logic for member _bearingPos____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingPos____(IEntity2 relatedEntity)
		{
			DesetupSyncBearingPos____(true, true);
			_bearingPos____ = (BearingPosEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingPos____, new PropertyChangedEventHandler( OnBearingPos____PropertyChanged ), "BearingPos____", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition5BearingPosId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingPos____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingPos_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingPos_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingPos_____, new PropertyChangedEventHandler( OnBearingPos_____PropertyChanged ), "BearingPos_____", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition6BearingPosId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition6BearingPosId } );		
			_bearingPos_____ = null;
		}

		/// <summary> setups the sync logic for member _bearingPos_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingPos_____(IEntity2 relatedEntity)
		{
			DesetupSyncBearingPos_____(true, true);
			_bearingPos_____ = (BearingPosEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingPos_____, new PropertyChangedEventHandler( OnBearingPos_____PropertyChanged ), "BearingPos_____", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition6BearingPosId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingPos_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingPos___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingPos___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingPos___, new PropertyChangedEventHandler( OnBearingPos___PropertyChanged ), "BearingPos___", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition4BearingPosId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition4BearingPosId } );		
			_bearingPos___ = null;
		}

		/// <summary> setups the sync logic for member _bearingPos___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingPos___(IEntity2 relatedEntity)
		{
			DesetupSyncBearingPos___(true, true);
			_bearingPos___ = (BearingPosEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingPos___, new PropertyChangedEventHandler( OnBearingPos___PropertyChanged ), "BearingPos___", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition4BearingPosId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingPos___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingPos</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingPos(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingPos, new PropertyChangedEventHandler( OnBearingPosPropertyChanged ), "BearingPos", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition1BearingPosId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition1BearingPosId } );		
			_bearingPos = null;
		}

		/// <summary> setups the sync logic for member _bearingPos</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingPos(IEntity2 relatedEntity)
		{
			DesetupSyncBearingPos(true, true);
			_bearingPos = (BearingPosEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingPos, new PropertyChangedEventHandler( OnBearingPosPropertyChanged ), "BearingPos", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition1BearingPosId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingPosPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingPos_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingPos_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingPos_, new PropertyChangedEventHandler( OnBearingPos_PropertyChanged ), "BearingPos_", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition2BearingPosId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition2BearingPosId } );		
			_bearingPos_ = null;
		}

		/// <summary> setups the sync logic for member _bearingPos_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingPos_(IEntity2 relatedEntity)
		{
			DesetupSyncBearingPos_(true, true);
			_bearingPos_ = (BearingPosEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingPos_, new PropertyChangedEventHandler( OnBearingPos_PropertyChanged ), "BearingPos_", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition2BearingPosId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingPos_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingPos__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingPos__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingPos__, new PropertyChangedEventHandler( OnBearingPos__PropertyChanged ), "BearingPos__", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition3BearingPosId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition3BearingPosId } );		
			_bearingPos__ = null;
		}

		/// <summary> setups the sync logic for member _bearingPos__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingPos__(IEntity2 relatedEntity)
		{
			DesetupSyncBearingPos__(true, true);
			_bearingPos__ = (BearingPosEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingPos__, new PropertyChangedEventHandler( OnBearingPos__PropertyChanged ), "BearingPos__", ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition3BearingPosId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingPos__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingType, new PropertyChangedEventHandler( OnBearingTypePropertyChanged ), "BearingType", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation1BearingTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation1BearingTypeId } );		
			_bearingType = null;
		}

		/// <summary> setups the sync logic for member _bearingType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingType(IEntity2 relatedEntity)
		{
			DesetupSyncBearingType(true, true);
			_bearingType = (BearingTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingType, new PropertyChangedEventHandler( OnBearingTypePropertyChanged ), "BearingType", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation1BearingTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingType_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingType_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingType_____, new PropertyChangedEventHandler( OnBearingType_____PropertyChanged ), "BearingType_____", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation6BearingTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation6BearingTypeId } );		
			_bearingType_____ = null;
		}

		/// <summary> setups the sync logic for member _bearingType_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingType_____(IEntity2 relatedEntity)
		{
			DesetupSyncBearingType_____(true, true);
			_bearingType_____ = (BearingTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingType_____, new PropertyChangedEventHandler( OnBearingType_____PropertyChanged ), "BearingType_____", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation6BearingTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingType_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingType____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingType____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingType____, new PropertyChangedEventHandler( OnBearingType____PropertyChanged ), "BearingType____", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation5BearingTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation5BearingTypeId } );		
			_bearingType____ = null;
		}

		/// <summary> setups the sync logic for member _bearingType____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingType____(IEntity2 relatedEntity)
		{
			DesetupSyncBearingType____(true, true);
			_bearingType____ = (BearingTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingType____, new PropertyChangedEventHandler( OnBearingType____PropertyChanged ), "BearingType____", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation5BearingTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingType____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingType___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingType___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingType___, new PropertyChangedEventHandler( OnBearingType___PropertyChanged ), "BearingType___", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation4BearingTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation4BearingTypeId } );		
			_bearingType___ = null;
		}

		/// <summary> setups the sync logic for member _bearingType___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingType___(IEntity2 relatedEntity)
		{
			DesetupSyncBearingType___(true, true);
			_bearingType___ = (BearingTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingType___, new PropertyChangedEventHandler( OnBearingType___PropertyChanged ), "BearingType___", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation4BearingTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingType___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingType__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingType__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingType__, new PropertyChangedEventHandler( OnBearingType__PropertyChanged ), "BearingType__", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation3BearingTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation3BearingTypeId } );		
			_bearingType__ = null;
		}

		/// <summary> setups the sync logic for member _bearingType__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingType__(IEntity2 relatedEntity)
		{
			DesetupSyncBearingType__(true, true);
			_bearingType__ = (BearingTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingType__, new PropertyChangedEventHandler( OnBearingType__PropertyChanged ), "BearingType__", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation3BearingTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingType__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bearingType_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBearingType_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bearingType_, new PropertyChangedEventHandler( OnBearingType_PropertyChanged ), "BearingType_", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation2BearingTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation2BearingTypeId } );		
			_bearingType_ = null;
		}

		/// <summary> setups the sync logic for member _bearingType_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBearingType_(IEntity2 relatedEntity)
		{
			DesetupSyncBearingType_(true, true);
			_bearingType_ = (BearingTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bearingType_, new PropertyChangedEventHandler( OnBearingType_PropertyChanged ), "BearingType_", ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation2BearingTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBearingType_PropertyChanged( object sender, PropertyChangedEventArgs e )
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
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer_, new PropertyChangedEventHandler( OnBooleanAnswer_PropertyChanged ), "BooleanAnswer_", ComponentInspectionReportGearboxEntity.Relations.BooleanAnswerEntityUsingGearboxClaimRelevantBooleanAnswerId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxClaimRelevantBooleanAnswerId } );		
			_booleanAnswer_ = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer_(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer_(true, true);
			_booleanAnswer_ = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer_, new PropertyChangedEventHandler( OnBooleanAnswer_PropertyChanged ), "BooleanAnswer_", ComponentInspectionReportGearboxEntity.Relations.BooleanAnswerEntityUsingGearboxClaimRelevantBooleanAnswerId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _booleanAnswer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBooleanAnswer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportGearboxEntity.Relations.BooleanAnswerEntityUsingGearboxOffLineFilterId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxOffLineFilterId } );		
			_booleanAnswer = null;
		}

		/// <summary> setups the sync logic for member _booleanAnswer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBooleanAnswer(IEntity2 relatedEntity)
		{
			DesetupSyncBooleanAnswer(true, true);
			_booleanAnswer = (BooleanAnswerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _booleanAnswer, new PropertyChangedEventHandler( OnBooleanAnswerPropertyChanged ), "BooleanAnswer", ComponentInspectionReportGearboxEntity.Relations.BooleanAnswerEntityUsingGearboxOffLineFilterId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _componentInspectionReport</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncComponentInspectionReport(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportGearboxEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.ComponentInspectionReportId } );		
			_componentInspectionReport = null;
		}

		/// <summary> setups the sync logic for member _componentInspectionReport</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncComponentInspectionReport(IEntity2 relatedEntity)
		{
			DesetupSyncComponentInspectionReport(true, true);
			_componentInspectionReport = (ComponentInspectionReportEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _componentInspectionReport, new PropertyChangedEventHandler( OnComponentInspectionReportPropertyChanged ), "ComponentInspectionReport", ComponentInspectionReportGearboxEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, true, new string[] {  } );
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

		/// <summary> Removes the sync logic for member _coupling</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCoupling(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _coupling, new PropertyChangedEventHandler( OnCouplingPropertyChanged ), "Coupling", ComponentInspectionReportGearboxEntity.Relations.CouplingEntityUsingGearboxCouplingId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxCouplingId } );		
			_coupling = null;
		}

		/// <summary> setups the sync logic for member _coupling</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCoupling(IEntity2 relatedEntity)
		{
			DesetupSyncCoupling(true, true);
			_coupling = (CouplingEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _coupling, new PropertyChangedEventHandler( OnCouplingPropertyChanged ), "Coupling", ComponentInspectionReportGearboxEntity.Relations.CouplingEntityUsingGearboxCouplingId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCouplingPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision____________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision____________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision____________, new PropertyChangedEventHandler( OnDamageDecision____________PropertyChanged ), "DamageDecision____________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision1DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox____________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision1DamageDecisionId } );		
			_damageDecision____________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision____________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision____________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision____________(true, true);
			_damageDecision____________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision____________, new PropertyChangedEventHandler( OnDamageDecision____________PropertyChanged ), "DamageDecision____________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision1DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision____________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision_____________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision_____________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision_____________, new PropertyChangedEventHandler( OnDamageDecision_____________PropertyChanged ), "DamageDecision_____________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision2DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_____________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision2DamageDecisionId } );		
			_damageDecision_____________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision_____________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision_____________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision_____________(true, true);
			_damageDecision_____________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision_____________, new PropertyChangedEventHandler( OnDamageDecision_____________PropertyChanged ), "DamageDecision_____________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision2DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision_____________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision__________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision__________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision__________, new PropertyChangedEventHandler( OnDamageDecision__________PropertyChanged ), "DamageDecision__________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision14DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision14DamageDecisionId } );		
			_damageDecision__________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision__________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision__________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision__________(true, true);
			_damageDecision__________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision__________, new PropertyChangedEventHandler( OnDamageDecision__________PropertyChanged ), "DamageDecision__________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision14DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision__________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision___________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision___________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision___________, new PropertyChangedEventHandler( OnDamageDecision___________PropertyChanged ), "DamageDecision___________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision15DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision15DamageDecisionId } );		
			_damageDecision___________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision___________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision___________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision___________(true, true);
			_damageDecision___________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision___________, new PropertyChangedEventHandler( OnDamageDecision___________PropertyChanged ), "DamageDecision___________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision15DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision___________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision_______________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision_______________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision_______________, new PropertyChangedEventHandler( OnDamageDecision_______________PropertyChanged ), "DamageDecision_______________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision4DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_______________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision4DamageDecisionId } );		
			_damageDecision_______________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision_______________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision_______________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision_______________(true, true);
			_damageDecision_______________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision_______________, new PropertyChangedEventHandler( OnDamageDecision_______________PropertyChanged ), "DamageDecision_______________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision4DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision_______________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision________________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision________________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision________________, new PropertyChangedEventHandler( OnDamageDecision________________PropertyChanged ), "DamageDecision________________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision5DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox________________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision5DamageDecisionId } );		
			_damageDecision________________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision________________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision________________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision________________(true, true);
			_damageDecision________________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision________________, new PropertyChangedEventHandler( OnDamageDecision________________PropertyChanged ), "DamageDecision________________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision5DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision________________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision_________________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision_________________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision_________________, new PropertyChangedEventHandler( OnDamageDecision_________________PropertyChanged ), "DamageDecision_________________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision6DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_________________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision6DamageDecisionId } );		
			_damageDecision_________________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision_________________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision_________________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision_________________(true, true);
			_damageDecision_________________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision_________________, new PropertyChangedEventHandler( OnDamageDecision_________________PropertyChanged ), "DamageDecision_________________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision6DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision_________________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision______________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision______________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision______________, new PropertyChangedEventHandler( OnDamageDecision______________PropertyChanged ), "DamageDecision______________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision3DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox______________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision3DamageDecisionId } );		
			_damageDecision______________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision______________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision______________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision______________(true, true);
			_damageDecision______________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision______________, new PropertyChangedEventHandler( OnDamageDecision______________PropertyChanged ), "DamageDecision______________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision3DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision______________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision___, new PropertyChangedEventHandler( OnDamageDecision___PropertyChanged ), "DamageDecision___", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision4DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision4DamageDecisionId } );		
			_damageDecision___ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision___(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision___(true, true);
			_damageDecision___ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision___, new PropertyChangedEventHandler( OnDamageDecision___PropertyChanged ), "DamageDecision___", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision4DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision__, new PropertyChangedEventHandler( OnDamageDecision__PropertyChanged ), "DamageDecision__", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision3DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision3DamageDecisionId } );		
			_damageDecision__ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision__(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision__(true, true);
			_damageDecision__ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision__, new PropertyChangedEventHandler( OnDamageDecision__PropertyChanged ), "DamageDecision__", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision3DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision____, new PropertyChangedEventHandler( OnDamageDecision____PropertyChanged ), "DamageDecision____", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision5DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision5DamageDecisionId } );		
			_damageDecision____ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision____(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision____(true, true);
			_damageDecision____ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision____, new PropertyChangedEventHandler( OnDamageDecision____PropertyChanged ), "DamageDecision____", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision5DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision_____, new PropertyChangedEventHandler( OnDamageDecision_____PropertyChanged ), "DamageDecision_____", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision6DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision6DamageDecisionId } );		
			_damageDecision_____ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision_____(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision_____(true, true);
			_damageDecision_____ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision_____, new PropertyChangedEventHandler( OnDamageDecision_____PropertyChanged ), "DamageDecision_____", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision6DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision________, new PropertyChangedEventHandler( OnDamageDecision________PropertyChanged ), "DamageDecision________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision12DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision12DamageDecisionId } );		
			_damageDecision________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision________(true, true);
			_damageDecision________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision________, new PropertyChangedEventHandler( OnDamageDecision________PropertyChanged ), "DamageDecision________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision12DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision_________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision_________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision_________, new PropertyChangedEventHandler( OnDamageDecision_________PropertyChanged ), "DamageDecision_________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision13DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision13DamageDecisionId } );		
			_damageDecision_________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision_________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision_________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision_________(true, true);
			_damageDecision_________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision_________, new PropertyChangedEventHandler( OnDamageDecision_________PropertyChanged ), "DamageDecision_________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision13DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision_________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision______, new PropertyChangedEventHandler( OnDamageDecision______PropertyChanged ), "DamageDecision______", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision10DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox______", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision10DamageDecisionId } );		
			_damageDecision______ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision______(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision______(true, true);
			_damageDecision______ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision______, new PropertyChangedEventHandler( OnDamageDecision______PropertyChanged ), "DamageDecision______", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision10DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision_______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision_______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision_______, new PropertyChangedEventHandler( OnDamageDecision_______PropertyChanged ), "DamageDecision_______", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision11DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_______", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision11DamageDecisionId } );		
			_damageDecision_______ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision_______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision_______(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision_______(true, true);
			_damageDecision_______ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision_______, new PropertyChangedEventHandler( OnDamageDecision_______PropertyChanged ), "DamageDecision_______", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision11DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision_______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision__________________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision__________________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision__________________, new PropertyChangedEventHandler( OnDamageDecision__________________PropertyChanged ), "DamageDecision__________________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision7DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__________________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision7DamageDecisionId } );		
			_damageDecision__________________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision__________________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision__________________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision__________________(true, true);
			_damageDecision__________________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision__________________, new PropertyChangedEventHandler( OnDamageDecision__________________PropertyChanged ), "DamageDecision__________________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision7DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision__________________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision_, new PropertyChangedEventHandler( OnDamageDecision_PropertyChanged ), "DamageDecision_", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision1DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision1DamageDecisionId } );		
			_damageDecision_ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision_(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision_(true, true);
			_damageDecision_ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision_, new PropertyChangedEventHandler( OnDamageDecision_PropertyChanged ), "DamageDecision_", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision1DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision, new PropertyChangedEventHandler( OnDamageDecisionPropertyChanged ), "DamageDecision", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision2DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision2DamageDecisionId } );		
			_damageDecision = null;
		}

		/// <summary> setups the sync logic for member _damageDecision</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision(true, true);
			_damageDecision = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision, new PropertyChangedEventHandler( OnDamageDecisionPropertyChanged ), "DamageDecision", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision2DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecisionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision___________________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision___________________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision___________________, new PropertyChangedEventHandler( OnDamageDecision___________________PropertyChanged ), "DamageDecision___________________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision8DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___________________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision8DamageDecisionId } );		
			_damageDecision___________________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision___________________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision___________________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision___________________(true, true);
			_damageDecision___________________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision___________________, new PropertyChangedEventHandler( OnDamageDecision___________________PropertyChanged ), "DamageDecision___________________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision8DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision___________________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _damageDecision____________________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDamageDecision____________________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _damageDecision____________________, new PropertyChangedEventHandler( OnDamageDecision____________________PropertyChanged ), "DamageDecision____________________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision9DamageDecisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox____________________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision9DamageDecisionId } );		
			_damageDecision____________________ = null;
		}

		/// <summary> setups the sync logic for member _damageDecision____________________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDamageDecision____________________(IEntity2 relatedEntity)
		{
			DesetupSyncDamageDecision____________________(true, true);
			_damageDecision____________________ = (DamageDecisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _damageDecision____________________, new PropertyChangedEventHandler( OnDamageDecision____________________PropertyChanged ), "DamageDecision____________________", ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision9DamageDecisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDamageDecision____________________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _debrisGearbox</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDebrisGearbox(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _debrisGearbox, new PropertyChangedEventHandler( OnDebrisGearboxPropertyChanged ), "DebrisGearbox", ComponentInspectionReportGearboxEntity.Relations.DebrisGearboxEntityUsingGearboxDebrisGearBoxId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisGearBoxId } );		
			_debrisGearbox = null;
		}

		/// <summary> setups the sync logic for member _debrisGearbox</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDebrisGearbox(IEntity2 relatedEntity)
		{
			DesetupSyncDebrisGearbox(true, true);
			_debrisGearbox = (DebrisGearboxEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _debrisGearbox, new PropertyChangedEventHandler( OnDebrisGearboxPropertyChanged ), "DebrisGearbox", ComponentInspectionReportGearboxEntity.Relations.DebrisGearboxEntityUsingGearboxDebrisGearBoxId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDebrisGearboxPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _debrisOnMagnet</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncDebrisOnMagnet(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _debrisOnMagnet, new PropertyChangedEventHandler( OnDebrisOnMagnetPropertyChanged ), "DebrisOnMagnet", ComponentInspectionReportGearboxEntity.Relations.DebrisOnMagnetEntityUsingGearboxDebrisOnMagnetId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisOnMagnetId } );		
			_debrisOnMagnet = null;
		}

		/// <summary> setups the sync logic for member _debrisOnMagnet</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncDebrisOnMagnet(IEntity2 relatedEntity)
		{
			DesetupSyncDebrisOnMagnet(true, true);
			_debrisOnMagnet = (DebrisOnMagnetEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _debrisOnMagnet, new PropertyChangedEventHandler( OnDebrisOnMagnetPropertyChanged ), "DebrisOnMagnet", ComponentInspectionReportGearboxEntity.Relations.DebrisOnMagnetEntityUsingGearboxDebrisOnMagnetId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnDebrisOnMagnetPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _electricalPump</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncElectricalPump(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _electricalPump, new PropertyChangedEventHandler( OnElectricalPumpPropertyChanged ), "ElectricalPump", ComponentInspectionReportGearboxEntity.Relations.ElectricalPumpEntityUsingGearboxElectricalPumpId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxElectricalPumpId } );		
			_electricalPump = null;
		}

		/// <summary> setups the sync logic for member _electricalPump</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncElectricalPump(IEntity2 relatedEntity)
		{
			DesetupSyncElectricalPump(true, true);
			_electricalPump = (ElectricalPumpEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _electricalPump, new PropertyChangedEventHandler( OnElectricalPumpPropertyChanged ), "ElectricalPump", ComponentInspectionReportGearboxEntity.Relations.ElectricalPumpEntityUsingGearboxElectricalPumpId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnElectricalPumpPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _filterBlockType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncFilterBlockType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _filterBlockType, new PropertyChangedEventHandler( OnFilterBlockTypePropertyChanged ), "FilterBlockType", ComponentInspectionReportGearboxEntity.Relations.FilterBlockTypeEntityUsingGearboxFilterBlockTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxFilterBlockTypeId } );		
			_filterBlockType = null;
		}

		/// <summary> setups the sync logic for member _filterBlockType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncFilterBlockType(IEntity2 relatedEntity)
		{
			DesetupSyncFilterBlockType(true, true);
			_filterBlockType = (FilterBlockTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _filterBlockType, new PropertyChangedEventHandler( OnFilterBlockTypePropertyChanged ), "FilterBlockType", ComponentInspectionReportGearboxEntity.Relations.FilterBlockTypeEntityUsingGearboxFilterBlockTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFilterBlockTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearboxManufacturer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearboxManufacturer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearboxManufacturer, new PropertyChangedEventHandler( OnGearboxManufacturerPropertyChanged ), "GearboxManufacturer", ComponentInspectionReportGearboxEntity.Relations.GearboxManufacturerEntityUsingGearboxManufacturerId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxManufacturerId } );		
			_gearboxManufacturer = null;
		}

		/// <summary> setups the sync logic for member _gearboxManufacturer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearboxManufacturer(IEntity2 relatedEntity)
		{
			DesetupSyncGearboxManufacturer(true, true);
			_gearboxManufacturer = (GearboxManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearboxManufacturer, new PropertyChangedEventHandler( OnGearboxManufacturerPropertyChanged ), "GearboxManufacturer", ComponentInspectionReportGearboxEntity.Relations.GearboxManufacturerEntityUsingGearboxManufacturerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearboxManufacturerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearboxRevision</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearboxRevision(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearboxRevision, new PropertyChangedEventHandler( OnGearboxRevisionPropertyChanged ), "GearboxRevision", ComponentInspectionReportGearboxEntity.Relations.GearboxRevisionEntityUsingGearboxRevisionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxRevisionId } );		
			_gearboxRevision = null;
		}

		/// <summary> setups the sync logic for member _gearboxRevision</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearboxRevision(IEntity2 relatedEntity)
		{
			DesetupSyncGearboxRevision(true, true);
			_gearboxRevision = (GearboxRevisionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearboxRevision, new PropertyChangedEventHandler( OnGearboxRevisionPropertyChanged ), "GearboxRevision", ComponentInspectionReportGearboxEntity.Relations.GearboxRevisionEntityUsingGearboxRevisionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearboxRevisionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearboxType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearboxType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearboxType, new PropertyChangedEventHandler( OnGearboxTypePropertyChanged ), "GearboxType", ComponentInspectionReportGearboxEntity.Relations.GearboxTypeEntityUsingGearboxTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeId } );		
			_gearboxType = null;
		}

		/// <summary> setups the sync logic for member _gearboxType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearboxType(IEntity2 relatedEntity)
		{
			DesetupSyncGearboxType(true, true);
			_gearboxType = (GearboxTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearboxType, new PropertyChangedEventHandler( OnGearboxTypePropertyChanged ), "GearboxType", ComponentInspectionReportGearboxEntity.Relations.GearboxTypeEntityUsingGearboxTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearboxTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError___________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError___________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError___________, new PropertyChangedEventHandler( OnGearError___________PropertyChanged ), "GearError___________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage6GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage6GearErrorId } );		
			_gearError___________ = null;
		}

		/// <summary> setups the sync logic for member _gearError___________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError___________(IEntity2 relatedEntity)
		{
			DesetupSyncGearError___________(true, true);
			_gearError___________ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError___________, new PropertyChangedEventHandler( OnGearError___________PropertyChanged ), "GearError___________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage6GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError___________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError_______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError_______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError_______, new PropertyChangedEventHandler( OnGearError_______PropertyChanged ), "GearError_______", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage12GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_______", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage12GearErrorId } );		
			_gearError_______ = null;
		}

		/// <summary> setups the sync logic for member _gearError_______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError_______(IEntity2 relatedEntity)
		{
			DesetupSyncGearError_______(true, true);
			_gearError_______ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError_______, new PropertyChangedEventHandler( OnGearError_______PropertyChanged ), "GearError_______", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage12GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError_______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError________, new PropertyChangedEventHandler( OnGearError________PropertyChanged ), "GearError________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage13GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage13GearErrorId } );		
			_gearError________ = null;
		}

		/// <summary> setups the sync logic for member _gearError________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError________(IEntity2 relatedEntity)
		{
			DesetupSyncGearError________(true, true);
			_gearError________ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError________, new PropertyChangedEventHandler( OnGearError________PropertyChanged ), "GearError________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage13GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError_____, new PropertyChangedEventHandler( OnGearError_____PropertyChanged ), "GearError_____", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage10GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage10GearErrorId } );		
			_gearError_____ = null;
		}

		/// <summary> setups the sync logic for member _gearError_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError_____(IEntity2 relatedEntity)
		{
			DesetupSyncGearError_____(true, true);
			_gearError_____ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError_____, new PropertyChangedEventHandler( OnGearError_____PropertyChanged ), "GearError_____", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage10GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError______, new PropertyChangedEventHandler( OnGearError______PropertyChanged ), "GearError______", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage11GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox______", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage11GearErrorId } );		
			_gearError______ = null;
		}

		/// <summary> setups the sync logic for member _gearError______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError______(IEntity2 relatedEntity)
		{
			DesetupSyncGearError______(true, true);
			_gearError______ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError______, new PropertyChangedEventHandler( OnGearError______PropertyChanged ), "GearError______", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage11GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError____________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError____________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError____________, new PropertyChangedEventHandler( OnGearError____________PropertyChanged ), "GearError____________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage7GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox____________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage7GearErrorId } );		
			_gearError____________ = null;
		}

		/// <summary> setups the sync logic for member _gearError____________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError____________(IEntity2 relatedEntity)
		{
			DesetupSyncGearError____________(true, true);
			_gearError____________ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError____________, new PropertyChangedEventHandler( OnGearError____________PropertyChanged ), "GearError____________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage7GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError____________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError_____________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError_____________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError_____________, new PropertyChangedEventHandler( OnGearError_____________PropertyChanged ), "GearError_____________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage8GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_____________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage8GearErrorId } );		
			_gearError_____________ = null;
		}

		/// <summary> setups the sync logic for member _gearError_____________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError_____________(IEntity2 relatedEntity)
		{
			DesetupSyncGearError_____________(true, true);
			_gearError_____________ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError_____________, new PropertyChangedEventHandler( OnGearError_____________PropertyChanged ), "GearError_____________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage8GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError_____________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError_________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError_________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError_________, new PropertyChangedEventHandler( OnGearError_________PropertyChanged ), "GearError_________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage14GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage14GearErrorId } );		
			_gearError_________ = null;
		}

		/// <summary> setups the sync logic for member _gearError_________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError_________(IEntity2 relatedEntity)
		{
			DesetupSyncGearError_________(true, true);
			_gearError_________ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError_________, new PropertyChangedEventHandler( OnGearError_________PropertyChanged ), "GearError_________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage14GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError_________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError__________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError__________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError__________, new PropertyChangedEventHandler( OnGearError__________PropertyChanged ), "GearError__________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage15GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage15GearErrorId } );		
			_gearError__________ = null;
		}

		/// <summary> setups the sync logic for member _gearError__________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError__________(IEntity2 relatedEntity)
		{
			DesetupSyncGearError__________(true, true);
			_gearError__________ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError__________, new PropertyChangedEventHandler( OnGearError__________PropertyChanged ), "GearError__________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage15GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError__________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError__, new PropertyChangedEventHandler( OnGearError__PropertyChanged ), "GearError__", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage3GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage3GearErrorId } );		
			_gearError__ = null;
		}

		/// <summary> setups the sync logic for member _gearError__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError__(IEntity2 relatedEntity)
		{
			DesetupSyncGearError__(true, true);
			_gearError__ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError__, new PropertyChangedEventHandler( OnGearError__PropertyChanged ), "GearError__", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage3GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError______________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError______________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError______________, new PropertyChangedEventHandler( OnGearError______________PropertyChanged ), "GearError______________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage9GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox______________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage9GearErrorId } );		
			_gearError______________ = null;
		}

		/// <summary> setups the sync logic for member _gearError______________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError______________(IEntity2 relatedEntity)
		{
			DesetupSyncGearError______________(true, true);
			_gearError______________ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError______________, new PropertyChangedEventHandler( OnGearError______________PropertyChanged ), "GearError______________", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage9GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError______________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError____, new PropertyChangedEventHandler( OnGearError____PropertyChanged ), "GearError____", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage5GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage5GearErrorId } );		
			_gearError____ = null;
		}

		/// <summary> setups the sync logic for member _gearError____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError____(IEntity2 relatedEntity)
		{
			DesetupSyncGearError____(true, true);
			_gearError____ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError____, new PropertyChangedEventHandler( OnGearError____PropertyChanged ), "GearError____", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage5GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError___, new PropertyChangedEventHandler( OnGearError___PropertyChanged ), "GearError___", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage4GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage4GearErrorId } );		
			_gearError___ = null;
		}

		/// <summary> setups the sync logic for member _gearError___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError___(IEntity2 relatedEntity)
		{
			DesetupSyncGearError___(true, true);
			_gearError___ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError___, new PropertyChangedEventHandler( OnGearError___PropertyChanged ), "GearError___", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage4GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError, new PropertyChangedEventHandler( OnGearErrorPropertyChanged ), "GearError", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage1GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage1GearErrorId } );		
			_gearError = null;
		}

		/// <summary> setups the sync logic for member _gearError</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError(IEntity2 relatedEntity)
		{
			DesetupSyncGearError(true, true);
			_gearError = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError, new PropertyChangedEventHandler( OnGearErrorPropertyChanged ), "GearError", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage1GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearErrorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearError_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearError_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearError_, new PropertyChangedEventHandler( OnGearError_PropertyChanged ), "GearError_", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage2GearErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage2GearErrorId } );		
			_gearError_ = null;
		}

		/// <summary> setups the sync logic for member _gearError_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearError_(IEntity2 relatedEntity)
		{
			DesetupSyncGearError_(true, true);
			_gearError_ = (GearErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearError_, new PropertyChangedEventHandler( OnGearError_PropertyChanged ), "GearError_", ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage2GearErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearError_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType________, new PropertyChangedEventHandler( OnGearType________PropertyChanged ), "GearType________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation12GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation12GearTypeId } );		
			_gearType________ = null;
		}

		/// <summary> setups the sync logic for member _gearType________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType________(IEntity2 relatedEntity)
		{
			DesetupSyncGearType________(true, true);
			_gearType________ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType________, new PropertyChangedEventHandler( OnGearType________PropertyChanged ), "GearType________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation12GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType__________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType__________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType__________, new PropertyChangedEventHandler( OnGearType__________PropertyChanged ), "GearType__________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation14GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation14GearTypeId } );		
			_gearType__________ = null;
		}

		/// <summary> setups the sync logic for member _gearType__________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType__________(IEntity2 relatedEntity)
		{
			DesetupSyncGearType__________(true, true);
			_gearType__________ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType__________, new PropertyChangedEventHandler( OnGearType__________PropertyChanged ), "GearType__________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation14GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType__________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType_________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType_________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType_________, new PropertyChangedEventHandler( OnGearType_________PropertyChanged ), "GearType_________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation13GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation13GearTypeId } );		
			_gearType_________ = null;
		}

		/// <summary> setups the sync logic for member _gearType_________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType_________(IEntity2 relatedEntity)
		{
			DesetupSyncGearType_________(true, true);
			_gearType_________ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType_________, new PropertyChangedEventHandler( OnGearType_________PropertyChanged ), "GearType_________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation13GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType_________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType_____, new PropertyChangedEventHandler( OnGearType_____PropertyChanged ), "GearType_____", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation6GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation6GearTypeId } );		
			_gearType_____ = null;
		}

		/// <summary> setups the sync logic for member _gearType_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType_____(IEntity2 relatedEntity)
		{
			DesetupSyncGearType_____(true, true);
			_gearType_____ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType_____, new PropertyChangedEventHandler( OnGearType_____PropertyChanged ), "GearType_____", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation6GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType______________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType______________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType______________, new PropertyChangedEventHandler( OnGearType______________PropertyChanged ), "GearType______________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation9GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox______________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation9GearTypeId } );		
			_gearType______________ = null;
		}

		/// <summary> setups the sync logic for member _gearType______________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType______________(IEntity2 relatedEntity)
		{
			DesetupSyncGearType______________(true, true);
			_gearType______________ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType______________, new PropertyChangedEventHandler( OnGearType______________PropertyChanged ), "GearType______________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation9GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType______________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType____, new PropertyChangedEventHandler( OnGearType____PropertyChanged ), "GearType____", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation5GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation5GearTypeId } );		
			_gearType____ = null;
		}

		/// <summary> setups the sync logic for member _gearType____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType____(IEntity2 relatedEntity)
		{
			DesetupSyncGearType____(true, true);
			_gearType____ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType____, new PropertyChangedEventHandler( OnGearType____PropertyChanged ), "GearType____", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation5GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType____________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType____________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType____________, new PropertyChangedEventHandler( OnGearType____________PropertyChanged ), "GearType____________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation7GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox____________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation7GearTypeId } );		
			_gearType____________ = null;
		}

		/// <summary> setups the sync logic for member _gearType____________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType____________(IEntity2 relatedEntity)
		{
			DesetupSyncGearType____________(true, true);
			_gearType____________ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType____________, new PropertyChangedEventHandler( OnGearType____________PropertyChanged ), "GearType____________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation7GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType____________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType_____________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType_____________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType_____________, new PropertyChangedEventHandler( OnGearType_____________PropertyChanged ), "GearType_____________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation8GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_____________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation8GearTypeId } );		
			_gearType_____________ = null;
		}

		/// <summary> setups the sync logic for member _gearType_____________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType_____________(IEntity2 relatedEntity)
		{
			DesetupSyncGearType_____________(true, true);
			_gearType_____________ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType_____________, new PropertyChangedEventHandler( OnGearType_____________PropertyChanged ), "GearType_____________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation8GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType_____________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType__, new PropertyChangedEventHandler( OnGearType__PropertyChanged ), "GearType__", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation3GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation3GearTypeId } );		
			_gearType__ = null;
		}

		/// <summary> setups the sync logic for member _gearType__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType__(IEntity2 relatedEntity)
		{
			DesetupSyncGearType__(true, true);
			_gearType__ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType__, new PropertyChangedEventHandler( OnGearType__PropertyChanged ), "GearType__", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation3GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType_, new PropertyChangedEventHandler( OnGearType_PropertyChanged ), "GearType_", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation2GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation2GearTypeId } );		
			_gearType_ = null;
		}

		/// <summary> setups the sync logic for member _gearType_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType_(IEntity2 relatedEntity)
		{
			DesetupSyncGearType_(true, true);
			_gearType_ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType_, new PropertyChangedEventHandler( OnGearType_PropertyChanged ), "GearType_", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation2GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType, new PropertyChangedEventHandler( OnGearTypePropertyChanged ), "GearType", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation1GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation1GearTypeId } );		
			_gearType = null;
		}

		/// <summary> setups the sync logic for member _gearType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType(IEntity2 relatedEntity)
		{
			DesetupSyncGearType(true, true);
			_gearType = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType, new PropertyChangedEventHandler( OnGearTypePropertyChanged ), "GearType", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation1GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType___, new PropertyChangedEventHandler( OnGearType___PropertyChanged ), "GearType___", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation4GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation4GearTypeId } );		
			_gearType___ = null;
		}

		/// <summary> setups the sync logic for member _gearType___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType___(IEntity2 relatedEntity)
		{
			DesetupSyncGearType___(true, true);
			_gearType___ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType___, new PropertyChangedEventHandler( OnGearType___PropertyChanged ), "GearType___", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation4GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType_______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType_______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType_______, new PropertyChangedEventHandler( OnGearType_______PropertyChanged ), "GearType_______", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation11GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_______", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation11GearTypeId } );		
			_gearType_______ = null;
		}

		/// <summary> setups the sync logic for member _gearType_______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType_______(IEntity2 relatedEntity)
		{
			DesetupSyncGearType_______(true, true);
			_gearType_______ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType_______, new PropertyChangedEventHandler( OnGearType_______PropertyChanged ), "GearType_______", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation11GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType_______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType______</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType______(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType______, new PropertyChangedEventHandler( OnGearType______PropertyChanged ), "GearType______", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation10GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox______", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation10GearTypeId } );		
			_gearType______ = null;
		}

		/// <summary> setups the sync logic for member _gearType______</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType______(IEntity2 relatedEntity)
		{
			DesetupSyncGearType______(true, true);
			_gearType______ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType______, new PropertyChangedEventHandler( OnGearType______PropertyChanged ), "GearType______", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation10GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType______PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _gearType___________</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGearType___________(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _gearType___________, new PropertyChangedEventHandler( OnGearType___________PropertyChanged ), "GearType___________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation15GearTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___________", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation15GearTypeId } );		
			_gearType___________ = null;
		}

		/// <summary> setups the sync logic for member _gearType___________</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGearType___________(IEntity2 relatedEntity)
		{
			DesetupSyncGearType___________(true, true);
			_gearType___________ = (GearTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _gearType___________, new PropertyChangedEventHandler( OnGearType___________PropertyChanged ), "GearType___________", ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation15GearTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGearType___________PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorManufacturer_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorManufacturer_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorManufacturer_, new PropertyChangedEventHandler( OnGeneratorManufacturer_PropertyChanged ), "GeneratorManufacturer_", ComponentInspectionReportGearboxEntity.Relations.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId2, true, signalRelatedEntity, "ComponentInspectionReportGearbox_", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGeneratorManufacturerId2 } );		
			_generatorManufacturer_ = null;
		}

		/// <summary> setups the sync logic for member _generatorManufacturer_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorManufacturer_(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorManufacturer_(true, true);
			_generatorManufacturer_ = (GeneratorManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorManufacturer_, new PropertyChangedEventHandler( OnGeneratorManufacturer_PropertyChanged ), "GeneratorManufacturer_", ComponentInspectionReportGearboxEntity.Relations.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId2, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorManufacturer_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _generatorManufacturer</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncGeneratorManufacturer(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _generatorManufacturer, new PropertyChangedEventHandler( OnGeneratorManufacturerPropertyChanged ), "GeneratorManufacturer", ComponentInspectionReportGearboxEntity.Relations.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxGeneratorManufacturerId } );		
			_generatorManufacturer = null;
		}

		/// <summary> setups the sync logic for member _generatorManufacturer</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncGeneratorManufacturer(IEntity2 relatedEntity)
		{
			DesetupSyncGeneratorManufacturer(true, true);
			_generatorManufacturer = (GeneratorManufacturerEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _generatorManufacturer, new PropertyChangedEventHandler( OnGeneratorManufacturerPropertyChanged ), "GeneratorManufacturer", ComponentInspectionReportGearboxEntity.Relations.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnGeneratorManufacturerPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _housingError_____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHousingError_____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _housingError_____, new PropertyChangedEventHandler( OnHousingError_____PropertyChanged ), "HousingError_____", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxHsstageHousingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxHsstageHousingErrorId } );		
			_housingError_____ = null;
		}

		/// <summary> setups the sync logic for member _housingError_____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHousingError_____(IEntity2 relatedEntity)
		{
			DesetupSyncHousingError_____(true, true);
			_housingError_____ = (HousingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _housingError_____, new PropertyChangedEventHandler( OnHousingError_____PropertyChanged ), "HousingError_____", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxHsstageHousingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHousingError_____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _housingError____</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHousingError____(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _housingError____, new PropertyChangedEventHandler( OnHousingError____PropertyChanged ), "HousingError____", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxAuxStageHousingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox____", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxAuxStageHousingErrorId } );		
			_housingError____ = null;
		}

		/// <summary> setups the sync logic for member _housingError____</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHousingError____(IEntity2 relatedEntity)
		{
			DesetupSyncHousingError____(true, true);
			_housingError____ = (HousingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _housingError____, new PropertyChangedEventHandler( OnHousingError____PropertyChanged ), "HousingError____", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxAuxStageHousingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHousingError____PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _housingError___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHousingError___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _housingError___, new PropertyChangedEventHandler( OnHousingError___PropertyChanged ), "HousingError___", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxFrontPlateHousingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxFrontPlateHousingErrorId } );		
			_housingError___ = null;
		}

		/// <summary> setups the sync logic for member _housingError___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHousingError___(IEntity2 relatedEntity)
		{
			DesetupSyncHousingError___(true, true);
			_housingError___ = (HousingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _housingError___, new PropertyChangedEventHandler( OnHousingError___PropertyChanged ), "HousingError___", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxFrontPlateHousingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHousingError___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _housingError</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHousingError(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _housingError, new PropertyChangedEventHandler( OnHousingErrorPropertyChanged ), "HousingError", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxPlanetStage1HousingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxPlanetStage1HousingErrorId } );		
			_housingError = null;
		}

		/// <summary> setups the sync logic for member _housingError</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHousingError(IEntity2 relatedEntity)
		{
			DesetupSyncHousingError(true, true);
			_housingError = (HousingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _housingError, new PropertyChangedEventHandler( OnHousingErrorPropertyChanged ), "HousingError", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxPlanetStage1HousingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHousingErrorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _housingError_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHousingError_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _housingError_, new PropertyChangedEventHandler( OnHousingError_PropertyChanged ), "HousingError_", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxPlanetStage2HousingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxPlanetStage2HousingErrorId } );		
			_housingError_ = null;
		}

		/// <summary> setups the sync logic for member _housingError_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHousingError_(IEntity2 relatedEntity)
		{
			DesetupSyncHousingError_(true, true);
			_housingError_ = (HousingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _housingError_, new PropertyChangedEventHandler( OnHousingError_PropertyChanged ), "HousingError_", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxPlanetStage2HousingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHousingError_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _housingError__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncHousingError__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _housingError__, new PropertyChangedEventHandler( OnHousingError__PropertyChanged ), "HousingError__", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxHelicalStageHousingErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxHelicalStageHousingErrorId } );		
			_housingError__ = null;
		}

		/// <summary> setups the sync logic for member _housingError__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncHousingError__(IEntity2 relatedEntity)
		{
			DesetupSyncHousingError__(true, true);
			_housingError__ = (HousingErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _housingError__, new PropertyChangedEventHandler( OnHousingError__PropertyChanged ), "HousingError__", ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxHelicalStageHousingErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnHousingError__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _inlineFilter</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncInlineFilter(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _inlineFilter, new PropertyChangedEventHandler( OnInlineFilterPropertyChanged ), "InlineFilter", ComponentInspectionReportGearboxEntity.Relations.InlineFilterEntityUsingGearboxInLineFilterId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxInLineFilterId } );		
			_inlineFilter = null;
		}

		/// <summary> setups the sync logic for member _inlineFilter</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncInlineFilter(IEntity2 relatedEntity)
		{
			DesetupSyncInlineFilter(true, true);
			_inlineFilter = (InlineFilterEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _inlineFilter, new PropertyChangedEventHandler( OnInlineFilterPropertyChanged ), "InlineFilter", ComponentInspectionReportGearboxEntity.Relations.InlineFilterEntityUsingGearboxInLineFilterId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnInlineFilterPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _magnetPos</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMagnetPos(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _magnetPos, new PropertyChangedEventHandler( OnMagnetPosPropertyChanged ), "MagnetPos", ComponentInspectionReportGearboxEntity.Relations.MagnetPosEntityUsingGearboxDebrisStagesMagnetPosId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisStagesMagnetPosId } );		
			_magnetPos = null;
		}

		/// <summary> setups the sync logic for member _magnetPos</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMagnetPos(IEntity2 relatedEntity)
		{
			DesetupSyncMagnetPos(true, true);
			_magnetPos = (MagnetPosEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _magnetPos, new PropertyChangedEventHandler( OnMagnetPosPropertyChanged ), "MagnetPos", ComponentInspectionReportGearboxEntity.Relations.MagnetPosEntityUsingGearboxDebrisStagesMagnetPosId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMagnetPosPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _mechanicalOilPump</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncMechanicalOilPump(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _mechanicalOilPump, new PropertyChangedEventHandler( OnMechanicalOilPumpPropertyChanged ), "MechanicalOilPump", ComponentInspectionReportGearboxEntity.Relations.MechanicalOilPumpEntityUsingGearboxMechanicalOilPumpId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxMechanicalOilPumpId } );		
			_mechanicalOilPump = null;
		}

		/// <summary> setups the sync logic for member _mechanicalOilPump</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncMechanicalOilPump(IEntity2 relatedEntity)
		{
			DesetupSyncMechanicalOilPump(true, true);
			_mechanicalOilPump = (MechanicalOilPumpEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _mechanicalOilPump, new PropertyChangedEventHandler( OnMechanicalOilPumpPropertyChanged ), "MechanicalOilPump", ComponentInspectionReportGearboxEntity.Relations.MechanicalOilPumpEntityUsingGearboxMechanicalOilPumpId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnMechanicalOilPumpPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _noise</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNoise(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _noise, new PropertyChangedEventHandler( OnNoisePropertyChanged ), "Noise", ComponentInspectionReportGearboxEntity.Relations.NoiseEntityUsingGearboxNoiseId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxNoiseId } );		
			_noise = null;
		}

		/// <summary> setups the sync logic for member _noise</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNoise(IEntity2 relatedEntity)
		{
			DesetupSyncNoise(true, true);
			_noise = (NoiseEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _noise, new PropertyChangedEventHandler( OnNoisePropertyChanged ), "Noise", ComponentInspectionReportGearboxEntity.Relations.NoiseEntityUsingGearboxNoiseId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnNoisePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _oilLevel</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOilLevel(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _oilLevel, new PropertyChangedEventHandler( OnOilLevelPropertyChanged ), "OilLevel", ComponentInspectionReportGearboxEntity.Relations.OilLevelEntityUsingGearboxOilLevelId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxOilLevelId } );		
			_oilLevel = null;
		}

		/// <summary> setups the sync logic for member _oilLevel</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOilLevel(IEntity2 relatedEntity)
		{
			DesetupSyncOilLevel(true, true);
			_oilLevel = (OilLevelEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _oilLevel, new PropertyChangedEventHandler( OnOilLevelPropertyChanged ), "OilLevel", ComponentInspectionReportGearboxEntity.Relations.OilLevelEntityUsingGearboxOilLevelId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOilLevelPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _oilType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOilType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _oilType, new PropertyChangedEventHandler( OnOilTypePropertyChanged ), "OilType", ComponentInspectionReportGearboxEntity.Relations.OilTypeEntityUsingGearboxOilTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxOilTypeId } );		
			_oilType = null;
		}

		/// <summary> setups the sync logic for member _oilType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOilType(IEntity2 relatedEntity)
		{
			DesetupSyncOilType(true, true);
			_oilType = (OilTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _oilType, new PropertyChangedEventHandler( OnOilTypePropertyChanged ), "OilType", ComponentInspectionReportGearboxEntity.Relations.OilTypeEntityUsingGearboxOilTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOilTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _overallGearboxCondition</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOverallGearboxCondition(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _overallGearboxCondition, new PropertyChangedEventHandler( OnOverallGearboxConditionPropertyChanged ), "OverallGearboxCondition", ComponentInspectionReportGearboxEntity.Relations.OverallGearboxConditionEntityUsingGearboxOverallGearboxConditionId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxOverallGearboxConditionId } );		
			_overallGearboxCondition = null;
		}

		/// <summary> setups the sync logic for member _overallGearboxCondition</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOverallGearboxCondition(IEntity2 relatedEntity)
		{
			DesetupSyncOverallGearboxCondition(true, true);
			_overallGearboxCondition = (OverallGearboxConditionEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _overallGearboxCondition, new PropertyChangedEventHandler( OnOverallGearboxConditionPropertyChanged ), "OverallGearboxCondition", ComponentInspectionReportGearboxEntity.Relations.OverallGearboxConditionEntityUsingGearboxOverallGearboxConditionId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOverallGearboxConditionPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _shaftError__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncShaftError__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _shaftError__, new PropertyChangedEventHandler( OnShaftError__PropertyChanged ), "ShaftError__", ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage3ShaftErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage3ShaftErrorId } );		
			_shaftError__ = null;
		}

		/// <summary> setups the sync logic for member _shaftError__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncShaftError__(IEntity2 relatedEntity)
		{
			DesetupSyncShaftError__(true, true);
			_shaftError__ = (ShaftErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _shaftError__, new PropertyChangedEventHandler( OnShaftError__PropertyChanged ), "ShaftError__", ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage3ShaftErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShaftError__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _shaftError___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncShaftError___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _shaftError___, new PropertyChangedEventHandler( OnShaftError___PropertyChanged ), "ShaftError___", ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage4ShaftErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage4ShaftErrorId } );		
			_shaftError___ = null;
		}

		/// <summary> setups the sync logic for member _shaftError___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncShaftError___(IEntity2 relatedEntity)
		{
			DesetupSyncShaftError___(true, true);
			_shaftError___ = (ShaftErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _shaftError___, new PropertyChangedEventHandler( OnShaftError___PropertyChanged ), "ShaftError___", ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage4ShaftErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShaftError___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _shaftError</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncShaftError(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _shaftError, new PropertyChangedEventHandler( OnShaftErrorPropertyChanged ), "ShaftError", ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage1ShaftErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage1ShaftErrorId } );		
			_shaftError = null;
		}

		/// <summary> setups the sync logic for member _shaftError</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncShaftError(IEntity2 relatedEntity)
		{
			DesetupSyncShaftError(true, true);
			_shaftError = (ShaftErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _shaftError, new PropertyChangedEventHandler( OnShaftErrorPropertyChanged ), "ShaftError", ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage1ShaftErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShaftErrorPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _shaftError_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncShaftError_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _shaftError_, new PropertyChangedEventHandler( OnShaftError_PropertyChanged ), "ShaftError_", ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage2ShaftErrorId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage2ShaftErrorId } );		
			_shaftError_ = null;
		}

		/// <summary> setups the sync logic for member _shaftError_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncShaftError_(IEntity2 relatedEntity)
		{
			DesetupSyncShaftError_(true, true);
			_shaftError_ = (ShaftErrorEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _shaftError_, new PropertyChangedEventHandler( OnShaftError_PropertyChanged ), "ShaftError_", ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage2ShaftErrorId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShaftError_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _shaftType___</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncShaftType___(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _shaftType___, new PropertyChangedEventHandler( OnShaftType___PropertyChanged ), "ShaftType___", ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation4ShaftTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox___", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation4ShaftTypeId } );		
			_shaftType___ = null;
		}

		/// <summary> setups the sync logic for member _shaftType___</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncShaftType___(IEntity2 relatedEntity)
		{
			DesetupSyncShaftType___(true, true);
			_shaftType___ = (ShaftTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _shaftType___, new PropertyChangedEventHandler( OnShaftType___PropertyChanged ), "ShaftType___", ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation4ShaftTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShaftType___PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _shaftType__</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncShaftType__(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _shaftType__, new PropertyChangedEventHandler( OnShaftType__PropertyChanged ), "ShaftType__", ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation3ShaftTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox__", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation3ShaftTypeId } );		
			_shaftType__ = null;
		}

		/// <summary> setups the sync logic for member _shaftType__</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncShaftType__(IEntity2 relatedEntity)
		{
			DesetupSyncShaftType__(true, true);
			_shaftType__ = (ShaftTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _shaftType__, new PropertyChangedEventHandler( OnShaftType__PropertyChanged ), "ShaftType__", ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation3ShaftTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShaftType__PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _shaftType_</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncShaftType_(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _shaftType_, new PropertyChangedEventHandler( OnShaftType_PropertyChanged ), "ShaftType_", ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation2ShaftTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox_", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation2ShaftTypeId } );		
			_shaftType_ = null;
		}

		/// <summary> setups the sync logic for member _shaftType_</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncShaftType_(IEntity2 relatedEntity)
		{
			DesetupSyncShaftType_(true, true);
			_shaftType_ = (ShaftTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _shaftType_, new PropertyChangedEventHandler( OnShaftType_PropertyChanged ), "ShaftType_", ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation2ShaftTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShaftType_PropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _shaftType</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncShaftType(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _shaftType, new PropertyChangedEventHandler( OnShaftTypePropertyChanged ), "ShaftType", ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation1ShaftTypeId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation1ShaftTypeId } );		
			_shaftType = null;
		}

		/// <summary> setups the sync logic for member _shaftType</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncShaftType(IEntity2 relatedEntity)
		{
			DesetupSyncShaftType(true, true);
			_shaftType = (ShaftTypeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _shaftType, new PropertyChangedEventHandler( OnShaftTypePropertyChanged ), "ShaftType", ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation1ShaftTypeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShaftTypePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _shrinkElement</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncShrinkElement(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _shrinkElement, new PropertyChangedEventHandler( OnShrinkElementPropertyChanged ), "ShrinkElement", ComponentInspectionReportGearboxEntity.Relations.ShrinkElementEntityUsingGearboxShrinkElementId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxShrinkElementId } );		
			_shrinkElement = null;
		}

		/// <summary> setups the sync logic for member _shrinkElement</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncShrinkElement(IEntity2 relatedEntity)
		{
			DesetupSyncShrinkElement(true, true);
			_shrinkElement = (ShrinkElementEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _shrinkElement, new PropertyChangedEventHandler( OnShrinkElementPropertyChanged ), "ShrinkElement", ComponentInspectionReportGearboxEntity.Relations.ShrinkElementEntityUsingGearboxShrinkElementId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnShrinkElementPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _vibrations</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncVibrations(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _vibrations, new PropertyChangedEventHandler( OnVibrationsPropertyChanged ), "Vibrations", ComponentInspectionReportGearboxEntity.Relations.VibrationsEntityUsingGearboxVibrationsId, true, signalRelatedEntity, "ComponentInspectionReportGearbox", resetFKFields, new int[] { (int)ComponentInspectionReportGearboxFieldIndex.GearboxVibrationsId } );		
			_vibrations = null;
		}

		/// <summary> setups the sync logic for member _vibrations</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncVibrations(IEntity2 relatedEntity)
		{
			DesetupSyncVibrations(true, true);
			_vibrations = (VibrationsEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _vibrations, new PropertyChangedEventHandler( OnVibrationsPropertyChanged ), "Vibrations", ComponentInspectionReportGearboxEntity.Relations.VibrationsEntityUsingGearboxVibrationsId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnVibrationsPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ComponentInspectionReportGearboxEntity</param>
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
		public  static ComponentInspectionReportGearboxRelations Relations
		{
			get	{ return new ComponentInspectionReportGearboxRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingError___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage4BearingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, null, null, "BearingError___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingError____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage5BearingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, null, null, "BearingError____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingError_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage6BearingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, null, null, "BearingError_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingError
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage1BearingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, null, null, "BearingError", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingError_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage2BearingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, null, null, "BearingError_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingError__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage3BearingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, null, null, "BearingError__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPos____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition5BearingPosId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, null, null, "BearingPos____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPos_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition6BearingPosId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, null, null, "BearingPos_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPos___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition4BearingPosId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, null, null, "BearingPos___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPos
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition1BearingPosId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, null, null, "BearingPos", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPos_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition2BearingPosId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, null, null, "BearingPos_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPos__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition3BearingPosId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, null, null, "BearingPos__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation1BearingTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, null, null, "BearingType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingType_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation6BearingTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, null, null, "BearingType_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingType____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation5BearingTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, null, null, "BearingType____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingType___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation4BearingTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, null, null, "BearingType___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingType__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation3BearingTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, null, null, "BearingType__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingType_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation2BearingTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, null, null, "BearingType_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportGearboxEntity.Relations.BooleanAnswerEntityUsingGearboxClaimRelevantBooleanAnswerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportGearboxEntity.Relations.BooleanAnswerEntityUsingGearboxOffLineFilterId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, null, null, "BooleanAnswer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
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
					ComponentInspectionReportGearboxEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, null, null, "ComponentInspectionReport", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCoupling
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.CouplingEntityUsingGearboxCouplingId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, null, null, "Coupling", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision____________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision1DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision_____________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision2DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision_____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision__________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision14DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision__________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision___________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision15DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision___________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision_______________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision4DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision_______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision________________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision5DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision_________________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision6DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision_________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision______________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision3DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision4DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision3DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision5DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision6DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision12DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision_________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision13DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision_________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision10DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision_______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision11DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision__________________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision7DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision__________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision1DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision2DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision___________________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision8DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision___________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecision____________________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision9DamageDecisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, null, null, "DamageDecision____________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DebrisGearbox' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDebrisGearbox
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DebrisGearboxEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DebrisGearboxEntityUsingGearboxDebrisGearBoxId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DebrisGearboxEntity, 0, null, null, null, null, "DebrisGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DebrisOnMagnet' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDebrisOnMagnet
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(DebrisOnMagnetEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.DebrisOnMagnetEntityUsingGearboxDebrisOnMagnetId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.DebrisOnMagnetEntity, 0, null, null, null, null, "DebrisOnMagnet", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ElectricalPump' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathElectricalPump
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ElectricalPumpEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.ElectricalPumpEntityUsingGearboxElectricalPumpId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.ElectricalPumpEntity, 0, null, null, null, null, "ElectricalPump", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FilterBlockType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFilterBlockType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(FilterBlockTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.FilterBlockTypeEntityUsingGearboxFilterBlockTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.FilterBlockTypeEntity, 0, null, null, null, null, "FilterBlockType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearboxManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearboxManufacturer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearboxManufacturerEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearboxManufacturerEntityUsingGearboxManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxManufacturerEntity, 0, null, null, null, null, "GearboxManufacturer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearboxRevision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearboxRevision
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearboxRevisionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearboxRevisionEntityUsingGearboxRevisionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxRevisionEntity, 0, null, null, null, null, "GearboxRevision", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearboxType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearboxType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearboxTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearboxTypeEntityUsingGearboxTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxTypeEntity, 0, null, null, null, null, "GearboxType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError___________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage6GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError___________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError_______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage12GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage13GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage10GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage11GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError____________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage7GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError_____________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage8GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError_____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError_________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage14GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError_________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError__________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage15GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError__________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage3GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError______________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage9GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage5GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage4GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage1GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearError_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage2GearErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, null, null, "GearError_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation12GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType__________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation14GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType__________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType_________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation13GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType_________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation6GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType______________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation9GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation5GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType____________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation7GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType_____________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation8GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType_____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation3GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation2GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation1GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation4GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType_______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation11GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType______
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation10GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearType___________
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation15GearTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, null, null, "GearType___________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturer_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId2, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, null, null, "GeneratorManufacturer_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturer
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, null, null, "GeneratorManufacturer", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingError_____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxHsstageHousingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, null, null, "HousingError_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingError____
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxAuxStageHousingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, null, null, "HousingError____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingError___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxFrontPlateHousingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, null, null, "HousingError___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingError
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxPlanetStage1HousingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, null, null, "HousingError", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingError_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxPlanetStage2HousingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, null, null, "HousingError_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingError__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxHelicalStageHousingErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, null, null, "HousingError__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InlineFilter' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInlineFilter
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(InlineFilterEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.InlineFilterEntityUsingGearboxInLineFilterId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.InlineFilterEntity, 0, null, null, null, null, "InlineFilter", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MagnetPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMagnetPos
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MagnetPosEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.MagnetPosEntityUsingGearboxDebrisStagesMagnetPosId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.MagnetPosEntity, 0, null, null, null, null, "MagnetPos", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MechanicalOilPump' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMechanicalOilPump
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(MechanicalOilPumpEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.MechanicalOilPumpEntityUsingGearboxMechanicalOilPumpId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.MechanicalOilPumpEntity, 0, null, null, null, null, "MechanicalOilPump", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Noise' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNoise
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(NoiseEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.NoiseEntityUsingGearboxNoiseId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.NoiseEntity, 0, null, null, null, null, "Noise", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OilLevel' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOilLevel
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OilLevelEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.OilLevelEntityUsingGearboxOilLevelId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.OilLevelEntity, 0, null, null, null, null, "OilLevel", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OilType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOilType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OilTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.OilTypeEntityUsingGearboxOilTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.OilTypeEntity, 0, null, null, null, null, "OilType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OverallGearboxCondition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOverallGearboxCondition
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OverallGearboxConditionEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.OverallGearboxConditionEntityUsingGearboxOverallGearboxConditionId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.OverallGearboxConditionEntity, 0, null, null, null, null, "OverallGearboxCondition", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftError__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage3ShaftErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftErrorEntity, 0, null, null, null, null, "ShaftError__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftError___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage4ShaftErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftErrorEntity, 0, null, null, null, null, "ShaftError___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftError
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage1ShaftErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftErrorEntity, 0, null, null, null, null, "ShaftError", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftError_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage2ShaftErrorId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftErrorEntity, 0, null, null, null, null, "ShaftError_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftType___
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation4ShaftTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftTypeEntity, 0, null, null, null, null, "ShaftType___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftType__
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation3ShaftTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftTypeEntity, 0, null, null, null, null, "ShaftType__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftType_
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation2ShaftTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftTypeEntity, 0, null, null, null, null, "ShaftType_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftType
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation1ShaftTypeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftTypeEntity, 0, null, null, null, null, "ShaftType", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShrinkElement' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShrinkElement
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ShrinkElementEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.ShrinkElementEntityUsingGearboxShrinkElementId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.ShrinkElementEntity, 0, null, null, null, null, "ShrinkElement", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Vibrations' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathVibrations
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(VibrationsEntityFactory))),
					ComponentInspectionReportGearboxEntity.Relations.VibrationsEntityUsingGearboxVibrationsId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, (int)Cir.Data.LLBLGen.EntityType.VibrationsEntity, 0, null, null, null, null, "Vibrations", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ComponentInspectionReportGearboxEntity.CustomProperties;}
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
			get { return ComponentInspectionReportGearboxEntity.FieldsCustomProperties;}
		}

		/// <summary> The ComponentInspectionReportGearboxId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."ComponentInspectionReportGearboxId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ComponentInspectionReportGearboxId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.ComponentInspectionReportGearboxId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.ComponentInspectionReportGearboxId, value); }
		}

		/// <summary> The ComponentInspectionReportId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."ComponentInspectionReportId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.ComponentInspectionReportId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.ComponentInspectionReportId, value); }
		}

		/// <summary> The VestasUniqueIdentifier property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."VestasUniqueIdentifier"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String VestasUniqueIdentifier
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGearboxFieldIndex.VestasUniqueIdentifier, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.VestasUniqueIdentifier, value); }
		}

		/// <summary> The GearboxTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxTypeId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeId, value); }
		}

		/// <summary> The GearboxRevisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxRevisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxRevisionId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxRevisionId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxRevisionId, value); }
		}

		/// <summary> The GearboxManufacturerId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxManufacturerId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxManufacturerId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxManufacturerId, value); }
		}

		/// <summary> The OtherGearboxType property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."OtherGearboxType"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 1000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String OtherGearboxType
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGearboxFieldIndex.OtherGearboxType, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.OtherGearboxType, value); }
		}

		/// <summary> The GearboxSerialNumber property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxSerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String GearboxSerialNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxSerialNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxSerialNumber, value); }
		}

		/// <summary> The GearboxOtherManufacturer property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxOtherManufacturer"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GearboxOtherManufacturer
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOtherManufacturer, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOtherManufacturer, value); }
		}

		/// <summary> The GearboxLastOilChangeDate property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxLastOilChangeDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> GearboxLastOilChangeDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxLastOilChangeDate, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxLastOilChangeDate, value); }
		}

		/// <summary> The GearboxOilTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxOilTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxOilTypeId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOilTypeId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOilTypeId, value); }
		}

		/// <summary> The GearboxMechanicalOilPumpId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxMechanicalOilPumpId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxMechanicalOilPumpId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxMechanicalOilPumpId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxMechanicalOilPumpId, value); }
		}

		/// <summary> The GearboxOilLevelId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxOilLevelId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxOilLevelId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOilLevelId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOilLevelId, value); }
		}

		/// <summary> The GearboxRunHours property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxRunHours"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxRunHours
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxRunHours, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxRunHours, value); }
		}

		/// <summary> The GearboxOilTemperature property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxOilTemperature"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 6, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Decimal GearboxOilTemperature
		{
			get { return (System.Decimal)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOilTemperature, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOilTemperature, value); }
		}

		/// <summary> The GearboxProduction property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxProduction"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxProduction
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxProduction, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxProduction, value); }
		}

		/// <summary> The GearboxGeneratorManufacturerId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGeneratorManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGeneratorManufacturerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGeneratorManufacturerId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGeneratorManufacturerId, value); }
		}

		/// <summary> The GearboxGeneratorManufacturerId2 property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGeneratorManufacturerId2"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGeneratorManufacturerId2
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGeneratorManufacturerId2, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGeneratorManufacturerId2, value); }
		}

		/// <summary> The GearboxElectricalPumpId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxElectricalPumpId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxElectricalPumpId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxElectricalPumpId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxElectricalPumpId, value); }
		}

		/// <summary> The GearboxShrinkElementId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxShrinkElementId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxShrinkElementId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShrinkElementId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShrinkElementId, value); }
		}

		/// <summary> The GearboxShrinkElementSerialNumber property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxShrinkElementSerialNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GearboxShrinkElementSerialNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShrinkElementSerialNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShrinkElementSerialNumber, value); }
		}

		/// <summary> The GearboxCouplingId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxCouplingId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxCouplingId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxCouplingId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxCouplingId, value); }
		}

		/// <summary> The GearboxFilterBlockTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxFilterBlockTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxFilterBlockTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxFilterBlockTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxFilterBlockTypeId, value); }
		}

		/// <summary> The GearboxInLineFilterId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxInLineFilterId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxInLineFilterId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxInLineFilterId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxInLineFilterId, value); }
		}

		/// <summary> The GearboxOffLineFilterId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxOffLineFilterId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxOffLineFilterId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOffLineFilterId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOffLineFilterId, value); }
		}

		/// <summary> The GearboxSoftwareRelease property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxSoftwareRelease"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 200<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GearboxSoftwareRelease
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxSoftwareRelease, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxSoftwareRelease, value); }
		}

		/// <summary> The GearboxShaftsExactLocation1ShaftTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxShaftsExactLocation1ShaftTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxShaftsExactLocation1ShaftTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation1ShaftTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation1ShaftTypeId, value); }
		}

		/// <summary> The GearboxShaftsExactLocation2ShaftTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxShaftsExactLocation2ShaftTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxShaftsExactLocation2ShaftTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation2ShaftTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation2ShaftTypeId, value); }
		}

		/// <summary> The GearboxShaftsExactLocation3ShaftTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxShaftsExactLocation3ShaftTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxShaftsExactLocation3ShaftTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation3ShaftTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation3ShaftTypeId, value); }
		}

		/// <summary> The GearboxShaftsExactLocation4ShaftTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxShaftsExactLocation4ShaftTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxShaftsExactLocation4ShaftTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation4ShaftTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsExactLocation4ShaftTypeId, value); }
		}

		/// <summary> The GearboxShaftsTypeofDamage1ShaftErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxShaftsTypeofDamage1ShaftErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxShaftsTypeofDamage1ShaftErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage1ShaftErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage1ShaftErrorId, value); }
		}

		/// <summary> The GearboxShaftsTypeofDamage2ShaftErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxShaftsTypeofDamage2ShaftErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxShaftsTypeofDamage2ShaftErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage2ShaftErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage2ShaftErrorId, value); }
		}

		/// <summary> The GearboxShaftsTypeofDamage3ShaftErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxShaftsTypeofDamage3ShaftErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxShaftsTypeofDamage3ShaftErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage3ShaftErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage3ShaftErrorId, value); }
		}

		/// <summary> The GearboxShaftsTypeofDamage4ShaftErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxShaftsTypeofDamage4ShaftErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxShaftsTypeofDamage4ShaftErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage4ShaftErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxShaftsTypeofDamage4ShaftErrorId, value); }
		}

		/// <summary> The GearboxExactLocation1GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation1GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation1GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation1GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation1GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation2GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation2GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation2GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation2GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation2GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation3GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation3GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation3GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation3GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation3GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation4GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation4GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation4GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation4GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation4GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation5GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation5GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation5GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation5GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation5GearTypeId, value); }
		}

		/// <summary> The GearboxTypeofDamage1GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage1GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage1GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage1GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage1GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage2GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage2GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage2GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage2GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage2GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage3GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage3GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage3GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage3GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage3GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage4GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage4GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage4GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage4GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage4GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage5GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage5GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage5GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage5GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage5GearErrorId, value); }
		}

		/// <summary> The GearboxBearingsLocation1BearingTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsLocation1BearingTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsLocation1BearingTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation1BearingTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation1BearingTypeId, value); }
		}

		/// <summary> The GearboxBearingsLocation2BearingTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsLocation2BearingTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsLocation2BearingTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation2BearingTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation2BearingTypeId, value); }
		}

		/// <summary> The GearboxBearingsLocation3BearingTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsLocation3BearingTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsLocation3BearingTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation3BearingTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation3BearingTypeId, value); }
		}

		/// <summary> The GearboxBearingsLocation4BearingTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsLocation4BearingTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsLocation4BearingTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation4BearingTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation4BearingTypeId, value); }
		}

		/// <summary> The GearboxBearingsLocation5BearingTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsLocation5BearingTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsLocation5BearingTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation5BearingTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation5BearingTypeId, value); }
		}

		/// <summary> The GearboxBearingsPosition1BearingPosId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsPosition1BearingPosId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsPosition1BearingPosId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition1BearingPosId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition1BearingPosId, value); }
		}

		/// <summary> The GearboxBearingsPosition2BearingPosId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsPosition2BearingPosId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsPosition2BearingPosId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition2BearingPosId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition2BearingPosId, value); }
		}

		/// <summary> The GearboxBearingsPosition3BearingPosId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsPosition3BearingPosId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsPosition3BearingPosId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition3BearingPosId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition3BearingPosId, value); }
		}

		/// <summary> The GearboxBearingsPosition4BearingPosId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsPosition4BearingPosId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsPosition4BearingPosId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition4BearingPosId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition4BearingPosId, value); }
		}

		/// <summary> The GearboxBearingsPosition5BearingPosId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsPosition5BearingPosId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsPosition5BearingPosId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition5BearingPosId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition5BearingPosId, value); }
		}

		/// <summary> The GearboxBearingsDamage1BearingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsDamage1BearingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsDamage1BearingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage1BearingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage1BearingErrorId, value); }
		}

		/// <summary> The GearboxBearingsDamage2BearingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsDamage2BearingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsDamage2BearingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage2BearingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage2BearingErrorId, value); }
		}

		/// <summary> The GearboxBearingsDamage3BearingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsDamage3BearingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsDamage3BearingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage3BearingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage3BearingErrorId, value); }
		}

		/// <summary> The GearboxBearingsDamage4BearingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsDamage4BearingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsDamage4BearingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage4BearingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage4BearingErrorId, value); }
		}

		/// <summary> The GearboxBearingsDamage5BearingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsDamage5BearingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsDamage5BearingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage5BearingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage5BearingErrorId, value); }
		}

		/// <summary> The GearboxPlanetStage1HousingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxPlanetStage1HousingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxPlanetStage1HousingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPlanetStage1HousingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPlanetStage1HousingErrorId, value); }
		}

		/// <summary> The GearboxPlanetStage2HousingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxPlanetStage2HousingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxPlanetStage2HousingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPlanetStage2HousingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPlanetStage2HousingErrorId, value); }
		}

		/// <summary> The GearboxHelicalStageHousingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxHelicalStageHousingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxHelicalStageHousingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHelicalStageHousingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHelicalStageHousingErrorId, value); }
		}

		/// <summary> The GearboxFrontPlateHousingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxFrontPlateHousingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxFrontPlateHousingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxFrontPlateHousingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxFrontPlateHousingErrorId, value); }
		}

		/// <summary> The GearboxAuxStageHousingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxAuxStageHousingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxAuxStageHousingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxAuxStageHousingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxAuxStageHousingErrorId, value); }
		}

		/// <summary> The GearboxHsstageHousingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxHSStageHousingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxHsstageHousingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHsstageHousingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHsstageHousingErrorId, value); }
		}

		/// <summary> The GearboxLooseBolts property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxLooseBolts"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxLooseBolts
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxLooseBolts, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxLooseBolts, value); }
		}

		/// <summary> The GearboxBrokenBolts property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBrokenBolts"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxBrokenBolts
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBrokenBolts, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBrokenBolts, value); }
		}

		/// <summary> The GearboxDefectDamperElements property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxDefectDamperElements"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxDefectDamperElements
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDefectDamperElements, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDefectDamperElements, value); }
		}

		/// <summary> The GearboxTooMuchClearance property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTooMuchClearance"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxTooMuchClearance
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTooMuchClearance, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTooMuchClearance, value); }
		}

		/// <summary> The GearboxCrackedTorqueArm property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxCrackedTorqueArm"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxCrackedTorqueArm
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxCrackedTorqueArm, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxCrackedTorqueArm, value); }
		}

		/// <summary> The GearboxNeedsToBeAligned property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxNeedsToBeAligned"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxNeedsToBeAligned
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxNeedsToBeAligned, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxNeedsToBeAligned, value); }
		}

		/// <summary> The GearboxPt100Bearing1 property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxPT100Bearing1"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxPt100Bearing1
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100Bearing1, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100Bearing1, value); }
		}

		/// <summary> The GearboxPt100Bearing2 property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxPT100Bearing2"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxPt100Bearing2
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100Bearing2, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100Bearing2, value); }
		}

		/// <summary> The GearboxPt100Bearing3 property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxPT100Bearing3"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxPt100Bearing3
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100Bearing3, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100Bearing3, value); }
		}

		/// <summary> The GearboxOilLevelSensor property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxOilLevelSensor"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxOilLevelSensor
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOilLevelSensor, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOilLevelSensor, value); }
		}

		/// <summary> The GearboxOilPressure property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxOilPressure"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxOilPressure
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOilPressure, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOilPressure, value); }
		}

		/// <summary> The GearboxPt100OilSump property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxPT100OilSump"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxPt100OilSump
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100OilSump, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPt100OilSump, value); }
		}

		/// <summary> The GearboxFilterIndicator property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxFilterIndicator"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxFilterIndicator
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxFilterIndicator, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxFilterIndicator, value); }
		}

		/// <summary> The GearboxImmersionHeater property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxImmersionHeater"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxImmersionHeater
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxImmersionHeater, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxImmersionHeater, value); }
		}

		/// <summary> The GearboxDrainValve property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxDrainValve"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxDrainValve
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDrainValve, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDrainValve, value); }
		}

		/// <summary> The GearboxAirBreather property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxAirBreather"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxAirBreather
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxAirBreather, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxAirBreather, value); }
		}

		/// <summary> The GearboxSightGlass property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxSightGlass"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxSightGlass
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxSightGlass, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxSightGlass, value); }
		}

		/// <summary> The GearboxChipDetector property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxChipDetector"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxChipDetector
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxChipDetector, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxChipDetector, value); }
		}

		/// <summary> The GearboxVibrationsId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxVibrationsId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxVibrationsId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxVibrationsId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxVibrationsId, value); }
		}

		/// <summary> The GearboxNoiseId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxNoiseId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxNoiseId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxNoiseId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxNoiseId, value); }
		}

		/// <summary> The GearboxDebrisOnMagnetId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxDebrisOnMagnetId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxDebrisOnMagnetId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisOnMagnetId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisOnMagnetId, value); }
		}

		/// <summary> The GearboxDebrisStagesMagnetPosId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxDebrisStagesMagnetPosId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxDebrisStagesMagnetPosId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisStagesMagnetPosId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisStagesMagnetPosId, value); }
		}

		/// <summary> The GearboxDebrisGearBoxId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxDebrisGearBoxId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 GearboxDebrisGearBoxId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisGearBoxId, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDebrisGearBoxId, value); }
		}

		/// <summary> The GearboxMaxTempResetDate property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxMaxTempResetDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> GearboxMaxTempResetDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxMaxTempResetDate, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxMaxTempResetDate, value); }
		}

		/// <summary> The GearboxTempBearing1 property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTempBearing1"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 6, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> GearboxTempBearing1
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTempBearing1, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTempBearing1, value); }
		}

		/// <summary> The GearboxTempBearing2 property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTempBearing2"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 6, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> GearboxTempBearing2
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTempBearing2, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTempBearing2, value); }
		}

		/// <summary> The GearboxTempBearing3 property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTempBearing3"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 6, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> GearboxTempBearing3
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTempBearing3, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTempBearing3, value); }
		}

		/// <summary> The GearboxTempOilSump property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTempOilSump"<br/>
		/// Table field type characteristics (type, precision, scale, length): Decimal, 6, 2, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Decimal> GearboxTempOilSump
		{
			get { return (Nullable<System.Decimal>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTempOilSump, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTempOilSump, value); }
		}

		/// <summary> The GearboxLssnrend property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxLSSNRend"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxLssnrend
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxLssnrend, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxLssnrend, value); }
		}

		/// <summary> The GearboxImsnrend property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxIMSNRend"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxImsnrend
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxImsnrend, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxImsnrend, value); }
		}

		/// <summary> The GearboxImsrend property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxIMSRend"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxImsrend
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxImsrend, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxImsrend, value); }
		}

		/// <summary> The GearboxHssnrend property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxHSSNRend"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxHssnrend
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHssnrend, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHssnrend, value); }
		}

		/// <summary> The GearboxHssrend property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxHSSRend"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxHssrend
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHssrend, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHssrend, value); }
		}

		/// <summary> The GearboxPitchTube property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxPitchTube"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxPitchTube
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPitchTube, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxPitchTube, value); }
		}

		/// <summary> The GearboxSplitLines property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxSplitLines"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxSplitLines
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxSplitLines, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxSplitLines, value); }
		}

		/// <summary> The GearboxHoseAndPiping property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxHoseAndPiping"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxHoseAndPiping
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHoseAndPiping, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHoseAndPiping, value); }
		}

		/// <summary> The GearboxInputShaft property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxInputShaft"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxInputShaft
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxInputShaft, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxInputShaft, value); }
		}

		/// <summary> The GearboxHsspto property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxHSSPTO"<br/>
		/// Table field type characteristics (type, precision, scale, length): Bit, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Boolean GearboxHsspto
		{
			get { return (System.Boolean)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHsspto, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxHsspto, value); }
		}

		/// <summary> The GearboxClaimRelevantBooleanAnswerId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxClaimRelevantBooleanAnswerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxClaimRelevantBooleanAnswerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxClaimRelevantBooleanAnswerId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxClaimRelevantBooleanAnswerId, value); }
		}

		/// <summary> The GearboxOverallGearboxConditionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxOverallGearboxConditionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxOverallGearboxConditionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOverallGearboxConditionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxOverallGearboxConditionId, value); }
		}

		/// <summary> The GearboxExactLocation6GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation6GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation6GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation6GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation6GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation7GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation7GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation7GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation7GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation7GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation8GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation8GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation8GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation8GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation8GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation9GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation9GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation9GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation9GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation9GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation10GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation10GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation10GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation10GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation10GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation11GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation11GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation11GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation11GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation11GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation12GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation12GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation12GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation12GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation12GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation13GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation13GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation13GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation13GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation13GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation14GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation14GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation14GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation14GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation14GearTypeId, value); }
		}

		/// <summary> The GearboxExactLocation15GearTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxExactLocation15GearTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxExactLocation15GearTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation15GearTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxExactLocation15GearTypeId, value); }
		}

		/// <summary> The GearboxTypeofDamage6GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage6GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage6GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage6GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage6GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage7GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage7GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage7GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage7GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage7GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage8GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage8GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage8GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage8GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage8GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage9GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage9GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage9GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage9GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage9GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage10GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage10GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage10GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage10GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage10GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage11GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage11GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage11GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage11GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage11GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage12GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage12GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage12GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage12GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage12GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage13GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage13GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage13GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage13GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage13GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage14GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage14GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage14GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage14GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage14GearErrorId, value); }
		}

		/// <summary> The GearboxTypeofDamage15GearErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxTypeofDamage15GearErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxTypeofDamage15GearErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage15GearErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxTypeofDamage15GearErrorId, value); }
		}

		/// <summary> The GearboxGearDecision1DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision1DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision1DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision1DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision1DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision2DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision2DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision2DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision2DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision2DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision3DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision3DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision3DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision3DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision3DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision4DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision4DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision4DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision4DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision4DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision5DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision5DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision5DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision5DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision5DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision6DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision6DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision6DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision6DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision6DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision7DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision7DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision7DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision7DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision7DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision8DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision8DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision8DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision8DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision8DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision9DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision9DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision9DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision9DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision9DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision10DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision10DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision10DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision10DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision10DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision11DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision11DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision11DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision11DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision11DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision12DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision12DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision12DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision12DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision12DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision13DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision13DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision13DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision13DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision13DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision14DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision14DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision14DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision14DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision14DamageDecisionId, value); }
		}

		/// <summary> The GearboxGearDecision15DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxGearDecision15DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxGearDecision15DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision15DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxGearDecision15DamageDecisionId, value); }
		}

		/// <summary> The GearboxBearingsLocation6BearingTypeId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsLocation6BearingTypeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsLocation6BearingTypeId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation6BearingTypeId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsLocation6BearingTypeId, value); }
		}

		/// <summary> The GearboxBearingsPosition6BearingPosId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsPosition6BearingPosId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsPosition6BearingPosId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition6BearingPosId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsPosition6BearingPosId, value); }
		}

		/// <summary> The GearboxBearingsDamage6BearingErrorId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingsDamage6BearingErrorId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingsDamage6BearingErrorId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage6BearingErrorId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingsDamage6BearingErrorId, value); }
		}

		/// <summary> The GearboxBearingDecision1DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingDecision1DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingDecision1DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision1DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision1DamageDecisionId, value); }
		}

		/// <summary> The GearboxBearingDecision2DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingDecision2DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingDecision2DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision2DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision2DamageDecisionId, value); }
		}

		/// <summary> The GearboxBearingDecision3DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingDecision3DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingDecision3DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision3DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision3DamageDecisionId, value); }
		}

		/// <summary> The GearboxBearingDecision4DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingDecision4DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingDecision4DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision4DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision4DamageDecisionId, value); }
		}

		/// <summary> The GearboxBearingDecision5DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingDecision5DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingDecision5DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision5DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision5DamageDecisionId, value); }
		}

		/// <summary> The GearboxBearingDecision6DamageDecisionId property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxBearingDecision6DamageDecisionId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> GearboxBearingDecision6DamageDecisionId
		{
			get { return (Nullable<System.Int64>)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision6DamageDecisionId, false); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxBearingDecision6DamageDecisionId, value); }
		}

		/// <summary> The GearboxDefectCategorizationScore property of the Entity ComponentInspectionReportGearbox<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportGearbox"."GearboxDefectCategorizationScore"<br/>
		/// Table field type characteristics (type, precision, scale, length): Char, 0, 0, 10<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String GearboxDefectCategorizationScore
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDefectCategorizationScore, true); }
			set	{ SetValue((int)ComponentInspectionReportGearboxFieldIndex.GearboxDefectCategorizationScore, value); }
		}



		/// <summary> Gets / sets related entity of type 'BearingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingErrorEntity BearingError___
		{
			get
			{
				return _bearingError___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingError___(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingError___ != null)
						{
							_bearingError___.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingErrorEntity BearingError____
		{
			get
			{
				return _bearingError____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingError____(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingError____ != null)
						{
							_bearingError____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingErrorEntity BearingError_____
		{
			get
			{
				return _bearingError_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingError_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingError_____ != null)
						{
							_bearingError_____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingErrorEntity BearingError
		{
			get
			{
				return _bearingError;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingError(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingError != null)
						{
							_bearingError.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingErrorEntity BearingError_
		{
			get
			{
				return _bearingError_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingError_(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingError_ != null)
						{
							_bearingError_.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingErrorEntity BearingError__
		{
			get
			{
				return _bearingError__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingError__(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingError__ != null)
						{
							_bearingError__.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingPosEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingPosEntity BearingPos____
		{
			get
			{
				return _bearingPos____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingPos____(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingPos____ != null)
						{
							_bearingPos____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingPosEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingPosEntity BearingPos_____
		{
			get
			{
				return _bearingPos_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingPos_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingPos_____ != null)
						{
							_bearingPos_____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingPosEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingPosEntity BearingPos___
		{
			get
			{
				return _bearingPos___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingPos___(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingPos___ != null)
						{
							_bearingPos___.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingPosEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingPosEntity BearingPos
		{
			get
			{
				return _bearingPos;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingPos(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingPos != null)
						{
							_bearingPos.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingPosEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingPosEntity BearingPos_
		{
			get
			{
				return _bearingPos_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingPos_(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingPos_ != null)
						{
							_bearingPos_.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingPosEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingPosEntity BearingPos__
		{
			get
			{
				return _bearingPos__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingPos__(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingPos__ != null)
						{
							_bearingPos__.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingTypeEntity BearingType
		{
			get
			{
				return _bearingType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingType(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingType != null)
						{
							_bearingType.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingTypeEntity BearingType_____
		{
			get
			{
				return _bearingType_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingType_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingType_____ != null)
						{
							_bearingType_____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingTypeEntity BearingType____
		{
			get
			{
				return _bearingType____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingType____(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingType____ != null)
						{
							_bearingType____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingTypeEntity BearingType___
		{
			get
			{
				return _bearingType___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingType___(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingType___ != null)
						{
							_bearingType___.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingTypeEntity BearingType__
		{
			get
			{
				return _bearingType__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingType__(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingType__ != null)
						{
							_bearingType__.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BearingTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BearingTypeEntity BearingType_
		{
			get
			{
				return _bearingType_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBearingType_(value);
				}
				else
				{
					if(value==null)
					{
						if(_bearingType_ != null)
						{
							_bearingType_.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_");
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
							_booleanAnswer_.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_");
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
							_booleanAnswer.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
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
							_componentInspectionReport.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CouplingEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CouplingEntity Coupling
		{
			get
			{
				return _coupling;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCoupling(value);
				}
				else
				{
					if(value==null)
					{
						if(_coupling != null)
						{
							_coupling.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision____________
		{
			get
			{
				return _damageDecision____________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision____________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision____________ != null)
						{
							_damageDecision____________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox____________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox____________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision_____________
		{
			get
			{
				return _damageDecision_____________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision_____________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision_____________ != null)
						{
							_damageDecision_____________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_____________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_____________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision__________
		{
			get
			{
				return _damageDecision__________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision__________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision__________ != null)
						{
							_damageDecision__________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision___________
		{
			get
			{
				return _damageDecision___________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision___________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision___________ != null)
						{
							_damageDecision___________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision_______________
		{
			get
			{
				return _damageDecision_______________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision_______________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision_______________ != null)
						{
							_damageDecision_______________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_______________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_______________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision________________
		{
			get
			{
				return _damageDecision________________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision________________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision________________ != null)
						{
							_damageDecision________________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox________________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox________________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision_________________
		{
			get
			{
				return _damageDecision_________________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision_________________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision_________________ != null)
						{
							_damageDecision_________________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_________________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_________________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision______________
		{
			get
			{
				return _damageDecision______________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision______________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision______________ != null)
						{
							_damageDecision______________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox______________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox______________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision___
		{
			get
			{
				return _damageDecision___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision___(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision___ != null)
						{
							_damageDecision___.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision__
		{
			get
			{
				return _damageDecision__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision__(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision__ != null)
						{
							_damageDecision__.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision____
		{
			get
			{
				return _damageDecision____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision____(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision____ != null)
						{
							_damageDecision____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision_____
		{
			get
			{
				return _damageDecision_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision_____ != null)
						{
							_damageDecision_____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision________
		{
			get
			{
				return _damageDecision________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision________ != null)
						{
							_damageDecision________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision_________
		{
			get
			{
				return _damageDecision_________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision_________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision_________ != null)
						{
							_damageDecision_________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision______
		{
			get
			{
				return _damageDecision______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision______(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision______ != null)
						{
							_damageDecision______.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox______");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox______");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision_______
		{
			get
			{
				return _damageDecision_______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision_______(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision_______ != null)
						{
							_damageDecision_______.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_______");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_______");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision__________________
		{
			get
			{
				return _damageDecision__________________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision__________________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision__________________ != null)
						{
							_damageDecision__________________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__________________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__________________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision_
		{
			get
			{
				return _damageDecision_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision_(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision_ != null)
						{
							_damageDecision_.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision
		{
			get
			{
				return _damageDecision;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision != null)
						{
							_damageDecision.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision___________________
		{
			get
			{
				return _damageDecision___________________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision___________________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision___________________ != null)
						{
							_damageDecision___________________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___________________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___________________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DamageDecisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DamageDecisionEntity DamageDecision____________________
		{
			get
			{
				return _damageDecision____________________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDamageDecision____________________(value);
				}
				else
				{
					if(value==null)
					{
						if(_damageDecision____________________ != null)
						{
							_damageDecision____________________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox____________________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox____________________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DebrisGearboxEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DebrisGearboxEntity DebrisGearbox
		{
			get
			{
				return _debrisGearbox;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDebrisGearbox(value);
				}
				else
				{
					if(value==null)
					{
						if(_debrisGearbox != null)
						{
							_debrisGearbox.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'DebrisOnMagnetEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual DebrisOnMagnetEntity DebrisOnMagnet
		{
			get
			{
				return _debrisOnMagnet;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncDebrisOnMagnet(value);
				}
				else
				{
					if(value==null)
					{
						if(_debrisOnMagnet != null)
						{
							_debrisOnMagnet.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ElectricalPumpEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ElectricalPumpEntity ElectricalPump
		{
			get
			{
				return _electricalPump;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncElectricalPump(value);
				}
				else
				{
					if(value==null)
					{
						if(_electricalPump != null)
						{
							_electricalPump.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'FilterBlockTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual FilterBlockTypeEntity FilterBlockType
		{
			get
			{
				return _filterBlockType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncFilterBlockType(value);
				}
				else
				{
					if(value==null)
					{
						if(_filterBlockType != null)
						{
							_filterBlockType.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearboxManufacturerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearboxManufacturerEntity GearboxManufacturer
		{
			get
			{
				return _gearboxManufacturer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearboxManufacturer(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearboxManufacturer != null)
						{
							_gearboxManufacturer.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearboxRevisionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearboxRevisionEntity GearboxRevision
		{
			get
			{
				return _gearboxRevision;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearboxRevision(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearboxRevision != null)
						{
							_gearboxRevision.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearboxTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearboxTypeEntity GearboxType
		{
			get
			{
				return _gearboxType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearboxType(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearboxType != null)
						{
							_gearboxType.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError___________
		{
			get
			{
				return _gearError___________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError___________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError___________ != null)
						{
							_gearError___________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError_______
		{
			get
			{
				return _gearError_______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError_______(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError_______ != null)
						{
							_gearError_______.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_______");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_______");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError________
		{
			get
			{
				return _gearError________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError________ != null)
						{
							_gearError________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError_____
		{
			get
			{
				return _gearError_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError_____ != null)
						{
							_gearError_____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError______
		{
			get
			{
				return _gearError______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError______(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError______ != null)
						{
							_gearError______.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox______");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox______");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError____________
		{
			get
			{
				return _gearError____________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError____________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError____________ != null)
						{
							_gearError____________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox____________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox____________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError_____________
		{
			get
			{
				return _gearError_____________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError_____________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError_____________ != null)
						{
							_gearError_____________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_____________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_____________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError_________
		{
			get
			{
				return _gearError_________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError_________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError_________ != null)
						{
							_gearError_________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError__________
		{
			get
			{
				return _gearError__________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError__________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError__________ != null)
						{
							_gearError__________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError__
		{
			get
			{
				return _gearError__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError__(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError__ != null)
						{
							_gearError__.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError______________
		{
			get
			{
				return _gearError______________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError______________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError______________ != null)
						{
							_gearError______________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox______________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox______________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError____
		{
			get
			{
				return _gearError____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError____(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError____ != null)
						{
							_gearError____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError___
		{
			get
			{
				return _gearError___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError___(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError___ != null)
						{
							_gearError___.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError
		{
			get
			{
				return _gearError;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError != null)
						{
							_gearError.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearErrorEntity GearError_
		{
			get
			{
				return _gearError_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearError_(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearError_ != null)
						{
							_gearError_.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType________
		{
			get
			{
				return _gearType________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType________ != null)
						{
							_gearType________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType__________
		{
			get
			{
				return _gearType__________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType__________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType__________ != null)
						{
							_gearType__________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType_________
		{
			get
			{
				return _gearType_________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType_________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType_________ != null)
						{
							_gearType_________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType_____
		{
			get
			{
				return _gearType_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType_____ != null)
						{
							_gearType_____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType______________
		{
			get
			{
				return _gearType______________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType______________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType______________ != null)
						{
							_gearType______________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox______________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox______________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType____
		{
			get
			{
				return _gearType____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType____(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType____ != null)
						{
							_gearType____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType____________
		{
			get
			{
				return _gearType____________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType____________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType____________ != null)
						{
							_gearType____________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox____________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox____________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType_____________
		{
			get
			{
				return _gearType_____________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType_____________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType_____________ != null)
						{
							_gearType_____________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_____________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_____________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType__
		{
			get
			{
				return _gearType__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType__(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType__ != null)
						{
							_gearType__.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType_
		{
			get
			{
				return _gearType_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType_(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType_ != null)
						{
							_gearType_.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType
		{
			get
			{
				return _gearType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType != null)
						{
							_gearType.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType___
		{
			get
			{
				return _gearType___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType___(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType___ != null)
						{
							_gearType___.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType_______
		{
			get
			{
				return _gearType_______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType_______(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType_______ != null)
						{
							_gearType_______.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_______");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_______");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType______
		{
			get
			{
				return _gearType______;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType______(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType______ != null)
						{
							_gearType______.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox______");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox______");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GearTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GearTypeEntity GearType___________
		{
			get
			{
				return _gearType___________;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGearType___________(value);
				}
				else
				{
					if(value==null)
					{
						if(_gearType___________ != null)
						{
							_gearType___________.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___________");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___________");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorManufacturerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorManufacturerEntity GeneratorManufacturer_
		{
			get
			{
				return _generatorManufacturer_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorManufacturer_(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorManufacturer_ != null)
						{
							_generatorManufacturer_.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'GeneratorManufacturerEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual GeneratorManufacturerEntity GeneratorManufacturer
		{
			get
			{
				return _generatorManufacturer;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncGeneratorManufacturer(value);
				}
				else
				{
					if(value==null)
					{
						if(_generatorManufacturer != null)
						{
							_generatorManufacturer.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HousingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HousingErrorEntity HousingError_____
		{
			get
			{
				return _housingError_____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHousingError_____(value);
				}
				else
				{
					if(value==null)
					{
						if(_housingError_____ != null)
						{
							_housingError_____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HousingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HousingErrorEntity HousingError____
		{
			get
			{
				return _housingError____;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHousingError____(value);
				}
				else
				{
					if(value==null)
					{
						if(_housingError____ != null)
						{
							_housingError____.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox____");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox____");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HousingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HousingErrorEntity HousingError___
		{
			get
			{
				return _housingError___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHousingError___(value);
				}
				else
				{
					if(value==null)
					{
						if(_housingError___ != null)
						{
							_housingError___.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HousingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HousingErrorEntity HousingError
		{
			get
			{
				return _housingError;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHousingError(value);
				}
				else
				{
					if(value==null)
					{
						if(_housingError != null)
						{
							_housingError.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HousingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HousingErrorEntity HousingError_
		{
			get
			{
				return _housingError_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHousingError_(value);
				}
				else
				{
					if(value==null)
					{
						if(_housingError_ != null)
						{
							_housingError_.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'HousingErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual HousingErrorEntity HousingError__
		{
			get
			{
				return _housingError__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncHousingError__(value);
				}
				else
				{
					if(value==null)
					{
						if(_housingError__ != null)
						{
							_housingError__.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'InlineFilterEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual InlineFilterEntity InlineFilter
		{
			get
			{
				return _inlineFilter;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncInlineFilter(value);
				}
				else
				{
					if(value==null)
					{
						if(_inlineFilter != null)
						{
							_inlineFilter.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MagnetPosEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MagnetPosEntity MagnetPos
		{
			get
			{
				return _magnetPos;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMagnetPos(value);
				}
				else
				{
					if(value==null)
					{
						if(_magnetPos != null)
						{
							_magnetPos.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'MechanicalOilPumpEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual MechanicalOilPumpEntity MechanicalOilPump
		{
			get
			{
				return _mechanicalOilPump;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncMechanicalOilPump(value);
				}
				else
				{
					if(value==null)
					{
						if(_mechanicalOilPump != null)
						{
							_mechanicalOilPump.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'NoiseEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual NoiseEntity Noise
		{
			get
			{
				return _noise;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncNoise(value);
				}
				else
				{
					if(value==null)
					{
						if(_noise != null)
						{
							_noise.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OilLevelEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OilLevelEntity OilLevel
		{
			get
			{
				return _oilLevel;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOilLevel(value);
				}
				else
				{
					if(value==null)
					{
						if(_oilLevel != null)
						{
							_oilLevel.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OilTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OilTypeEntity OilType
		{
			get
			{
				return _oilType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOilType(value);
				}
				else
				{
					if(value==null)
					{
						if(_oilType != null)
						{
							_oilType.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'OverallGearboxConditionEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OverallGearboxConditionEntity OverallGearboxCondition
		{
			get
			{
				return _overallGearboxCondition;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOverallGearboxCondition(value);
				}
				else
				{
					if(value==null)
					{
						if(_overallGearboxCondition != null)
						{
							_overallGearboxCondition.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ShaftErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ShaftErrorEntity ShaftError__
		{
			get
			{
				return _shaftError__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncShaftError__(value);
				}
				else
				{
					if(value==null)
					{
						if(_shaftError__ != null)
						{
							_shaftError__.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ShaftErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ShaftErrorEntity ShaftError___
		{
			get
			{
				return _shaftError___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncShaftError___(value);
				}
				else
				{
					if(value==null)
					{
						if(_shaftError___ != null)
						{
							_shaftError___.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ShaftErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ShaftErrorEntity ShaftError
		{
			get
			{
				return _shaftError;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncShaftError(value);
				}
				else
				{
					if(value==null)
					{
						if(_shaftError != null)
						{
							_shaftError.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ShaftErrorEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ShaftErrorEntity ShaftError_
		{
			get
			{
				return _shaftError_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncShaftError_(value);
				}
				else
				{
					if(value==null)
					{
						if(_shaftError_ != null)
						{
							_shaftError_.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ShaftTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ShaftTypeEntity ShaftType___
		{
			get
			{
				return _shaftType___;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncShaftType___(value);
				}
				else
				{
					if(value==null)
					{
						if(_shaftType___ != null)
						{
							_shaftType___.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox___");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox___");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ShaftTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ShaftTypeEntity ShaftType__
		{
			get
			{
				return _shaftType__;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncShaftType__(value);
				}
				else
				{
					if(value==null)
					{
						if(_shaftType__ != null)
						{
							_shaftType__.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox__");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox__");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ShaftTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ShaftTypeEntity ShaftType_
		{
			get
			{
				return _shaftType_;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncShaftType_(value);
				}
				else
				{
					if(value==null)
					{
						if(_shaftType_ != null)
						{
							_shaftType_.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox_");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ShaftTypeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ShaftTypeEntity ShaftType
		{
			get
			{
				return _shaftType;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncShaftType(value);
				}
				else
				{
					if(value==null)
					{
						if(_shaftType != null)
						{
							_shaftType.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ShrinkElementEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ShrinkElementEntity ShrinkElement
		{
			get
			{
				return _shrinkElement;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncShrinkElement(value);
				}
				else
				{
					if(value==null)
					{
						if(_shrinkElement != null)
						{
							_shrinkElement.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'VibrationsEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual VibrationsEntity Vibrations
		{
			get
			{
				return _vibrations;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncVibrations(value);
				}
				else
				{
					if(value==null)
					{
						if(_vibrations != null)
						{
							_vibrations.UnsetRelatedEntity(this, "ComponentInspectionReportGearbox");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportGearbox");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity; }
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
