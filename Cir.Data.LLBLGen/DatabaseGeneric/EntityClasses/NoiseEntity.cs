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
	/// Entity class which represents the entity 'Noise'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class NoiseEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportGearboxEntity> _componentInspectionReportGearbox;
		private EntityCollection<NoiseEntity> _noise_;
		private EntityCollection<BearingErrorEntity> _bearingErrorCollectionViaComponentInspectionReportGearbox___;
		private EntityCollection<BearingErrorEntity> _bearingErrorCollectionViaComponentInspectionReportGearbox____;
		private EntityCollection<BearingErrorEntity> _bearingErrorCollectionViaComponentInspectionReportGearbox_____;
		private EntityCollection<BearingErrorEntity> _bearingErrorCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<BearingErrorEntity> _bearingErrorCollectionViaComponentInspectionReportGearbox_;
		private EntityCollection<BearingErrorEntity> _bearingErrorCollectionViaComponentInspectionReportGearbox__;
		private EntityCollection<BearingPosEntity> _bearingPosCollectionViaComponentInspectionReportGearbox____;
		private EntityCollection<BearingPosEntity> _bearingPosCollectionViaComponentInspectionReportGearbox_____;
		private EntityCollection<BearingPosEntity> _bearingPosCollectionViaComponentInspectionReportGearbox___;
		private EntityCollection<BearingPosEntity> _bearingPosCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<BearingPosEntity> _bearingPosCollectionViaComponentInspectionReportGearbox_;
		private EntityCollection<BearingPosEntity> _bearingPosCollectionViaComponentInspectionReportGearbox__;
		private EntityCollection<BearingTypeEntity> _bearingTypeCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<BearingTypeEntity> _bearingTypeCollectionViaComponentInspectionReportGearbox_____;
		private EntityCollection<BearingTypeEntity> _bearingTypeCollectionViaComponentInspectionReportGearbox____;
		private EntityCollection<BearingTypeEntity> _bearingTypeCollectionViaComponentInspectionReportGearbox___;
		private EntityCollection<BearingTypeEntity> _bearingTypeCollectionViaComponentInspectionReportGearbox__;
		private EntityCollection<BearingTypeEntity> _bearingTypeCollectionViaComponentInspectionReportGearbox_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGearbox_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<CouplingEntity> _couplingCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox____________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox_____________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox__________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox___________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox_______________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox________________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox_________________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox______________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox___;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox__;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox____;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox_____;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox_________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox______;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox_______;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox__________________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox_;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox___________________;
		private EntityCollection<DamageDecisionEntity> _damageDecisionCollectionViaComponentInspectionReportGearbox____________________;
		private EntityCollection<DebrisGearboxEntity> _debrisGearboxCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<DebrisOnMagnetEntity> _debrisOnMagnetCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<ElectricalPumpEntity> _electricalPumpCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<FilterBlockTypeEntity> _filterBlockTypeCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<GearboxManufacturerEntity> _gearboxManufacturerCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<GearboxRevisionEntity> _gearboxRevisionCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<GearboxTypeEntity> _gearboxTypeCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox___________;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox_______;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox________;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox_____;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox______;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox____________;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox_____________;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox_________;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox__________;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox__;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox____;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox______________;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox___;
		private EntityCollection<GearErrorEntity> _gearErrorCollectionViaComponentInspectionReportGearbox_;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox_____;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox_________;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox__________;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox______________;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox____;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox____________;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox_____________;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox________;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox_;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox___________;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox__;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox_______;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox______;
		private EntityCollection<GearTypeEntity> _gearTypeCollectionViaComponentInspectionReportGearbox___;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGearbox_;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<HousingErrorEntity> _housingErrorCollectionViaComponentInspectionReportGearbox___;
		private EntityCollection<HousingErrorEntity> _housingErrorCollectionViaComponentInspectionReportGearbox__;
		private EntityCollection<HousingErrorEntity> _housingErrorCollectionViaComponentInspectionReportGearbox_;
		private EntityCollection<HousingErrorEntity> _housingErrorCollectionViaComponentInspectionReportGearbox____;
		private EntityCollection<HousingErrorEntity> _housingErrorCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<HousingErrorEntity> _housingErrorCollectionViaComponentInspectionReportGearbox_____;
		private EntityCollection<InlineFilterEntity> _inlineFilterCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<MagnetPosEntity> _magnetPosCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<MechanicalOilPumpEntity> _mechanicalOilPumpCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<OilLevelEntity> _oilLevelCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<OilTypeEntity> _oilTypeCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<OverallGearboxConditionEntity> _overallGearboxConditionCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<ShaftErrorEntity> _shaftErrorCollectionViaComponentInspectionReportGearbox__;
		private EntityCollection<ShaftErrorEntity> _shaftErrorCollectionViaComponentInspectionReportGearbox___;
		private EntityCollection<ShaftErrorEntity> _shaftErrorCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<ShaftErrorEntity> _shaftErrorCollectionViaComponentInspectionReportGearbox_;
		private EntityCollection<ShaftTypeEntity> _shaftTypeCollectionViaComponentInspectionReportGearbox__;
		private EntityCollection<ShaftTypeEntity> _shaftTypeCollectionViaComponentInspectionReportGearbox___;
		private EntityCollection<ShaftTypeEntity> _shaftTypeCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<ShaftTypeEntity> _shaftTypeCollectionViaComponentInspectionReportGearbox_;
		private EntityCollection<ShrinkElementEntity> _shrinkElementCollectionViaComponentInspectionReportGearbox;
		private EntityCollection<VibrationsEntity> _vibrationsCollectionViaComponentInspectionReportGearbox;
		private NoiseEntity _noise;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name Noise</summary>
			public static readonly string Noise = "Noise";
			/// <summary>Member name ComponentInspectionReportGearbox</summary>
			public static readonly string ComponentInspectionReportGearbox = "ComponentInspectionReportGearbox";
			/// <summary>Member name Noise_</summary>
			public static readonly string Noise_ = "Noise_";
			/// <summary>Member name BearingErrorCollectionViaComponentInspectionReportGearbox___</summary>
			public static readonly string BearingErrorCollectionViaComponentInspectionReportGearbox___ = "BearingErrorCollectionViaComponentInspectionReportGearbox___";
			/// <summary>Member name BearingErrorCollectionViaComponentInspectionReportGearbox____</summary>
			public static readonly string BearingErrorCollectionViaComponentInspectionReportGearbox____ = "BearingErrorCollectionViaComponentInspectionReportGearbox____";
			/// <summary>Member name BearingErrorCollectionViaComponentInspectionReportGearbox_____</summary>
			public static readonly string BearingErrorCollectionViaComponentInspectionReportGearbox_____ = "BearingErrorCollectionViaComponentInspectionReportGearbox_____";
			/// <summary>Member name BearingErrorCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string BearingErrorCollectionViaComponentInspectionReportGearbox = "BearingErrorCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name BearingErrorCollectionViaComponentInspectionReportGearbox_</summary>
			public static readonly string BearingErrorCollectionViaComponentInspectionReportGearbox_ = "BearingErrorCollectionViaComponentInspectionReportGearbox_";
			/// <summary>Member name BearingErrorCollectionViaComponentInspectionReportGearbox__</summary>
			public static readonly string BearingErrorCollectionViaComponentInspectionReportGearbox__ = "BearingErrorCollectionViaComponentInspectionReportGearbox__";
			/// <summary>Member name BearingPosCollectionViaComponentInspectionReportGearbox____</summary>
			public static readonly string BearingPosCollectionViaComponentInspectionReportGearbox____ = "BearingPosCollectionViaComponentInspectionReportGearbox____";
			/// <summary>Member name BearingPosCollectionViaComponentInspectionReportGearbox_____</summary>
			public static readonly string BearingPosCollectionViaComponentInspectionReportGearbox_____ = "BearingPosCollectionViaComponentInspectionReportGearbox_____";
			/// <summary>Member name BearingPosCollectionViaComponentInspectionReportGearbox___</summary>
			public static readonly string BearingPosCollectionViaComponentInspectionReportGearbox___ = "BearingPosCollectionViaComponentInspectionReportGearbox___";
			/// <summary>Member name BearingPosCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string BearingPosCollectionViaComponentInspectionReportGearbox = "BearingPosCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name BearingPosCollectionViaComponentInspectionReportGearbox_</summary>
			public static readonly string BearingPosCollectionViaComponentInspectionReportGearbox_ = "BearingPosCollectionViaComponentInspectionReportGearbox_";
			/// <summary>Member name BearingPosCollectionViaComponentInspectionReportGearbox__</summary>
			public static readonly string BearingPosCollectionViaComponentInspectionReportGearbox__ = "BearingPosCollectionViaComponentInspectionReportGearbox__";
			/// <summary>Member name BearingTypeCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string BearingTypeCollectionViaComponentInspectionReportGearbox = "BearingTypeCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name BearingTypeCollectionViaComponentInspectionReportGearbox_____</summary>
			public static readonly string BearingTypeCollectionViaComponentInspectionReportGearbox_____ = "BearingTypeCollectionViaComponentInspectionReportGearbox_____";
			/// <summary>Member name BearingTypeCollectionViaComponentInspectionReportGearbox____</summary>
			public static readonly string BearingTypeCollectionViaComponentInspectionReportGearbox____ = "BearingTypeCollectionViaComponentInspectionReportGearbox____";
			/// <summary>Member name BearingTypeCollectionViaComponentInspectionReportGearbox___</summary>
			public static readonly string BearingTypeCollectionViaComponentInspectionReportGearbox___ = "BearingTypeCollectionViaComponentInspectionReportGearbox___";
			/// <summary>Member name BearingTypeCollectionViaComponentInspectionReportGearbox__</summary>
			public static readonly string BearingTypeCollectionViaComponentInspectionReportGearbox__ = "BearingTypeCollectionViaComponentInspectionReportGearbox__";
			/// <summary>Member name BearingTypeCollectionViaComponentInspectionReportGearbox_</summary>
			public static readonly string BearingTypeCollectionViaComponentInspectionReportGearbox_ = "BearingTypeCollectionViaComponentInspectionReportGearbox_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGearbox_</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGearbox_ = "BooleanAnswerCollectionViaComponentInspectionReportGearbox_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGearbox = "BooleanAnswerCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGearbox = "ComponentInspectionReportCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name CouplingCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string CouplingCollectionViaComponentInspectionReportGearbox = "CouplingCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox____________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox____________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox____________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox_____________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox_____________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox_____________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox__________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox__________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox__________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox___________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox___________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox___________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox_______________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox_______________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox_______________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox________________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox________________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox________________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox_________________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox_________________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox_________________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox______________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox______________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox______________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox___</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox___ = "DamageDecisionCollectionViaComponentInspectionReportGearbox___";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox__</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox__ = "DamageDecisionCollectionViaComponentInspectionReportGearbox__";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox____</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox____ = "DamageDecisionCollectionViaComponentInspectionReportGearbox____";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox_____</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox_____ = "DamageDecisionCollectionViaComponentInspectionReportGearbox_____";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox_________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox_________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox_________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox______</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox______ = "DamageDecisionCollectionViaComponentInspectionReportGearbox______";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox_______</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox_______ = "DamageDecisionCollectionViaComponentInspectionReportGearbox_______";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox__________________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox__________________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox__________________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox_</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox_ = "DamageDecisionCollectionViaComponentInspectionReportGearbox_";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox = "DamageDecisionCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox___________________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox___________________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox___________________";
			/// <summary>Member name DamageDecisionCollectionViaComponentInspectionReportGearbox____________________</summary>
			public static readonly string DamageDecisionCollectionViaComponentInspectionReportGearbox____________________ = "DamageDecisionCollectionViaComponentInspectionReportGearbox____________________";
			/// <summary>Member name DebrisGearboxCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string DebrisGearboxCollectionViaComponentInspectionReportGearbox = "DebrisGearboxCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name DebrisOnMagnetCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string DebrisOnMagnetCollectionViaComponentInspectionReportGearbox = "DebrisOnMagnetCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name ElectricalPumpCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string ElectricalPumpCollectionViaComponentInspectionReportGearbox = "ElectricalPumpCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name FilterBlockTypeCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string FilterBlockTypeCollectionViaComponentInspectionReportGearbox = "FilterBlockTypeCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name GearboxManufacturerCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string GearboxManufacturerCollectionViaComponentInspectionReportGearbox = "GearboxManufacturerCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name GearboxRevisionCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string GearboxRevisionCollectionViaComponentInspectionReportGearbox = "GearboxRevisionCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name GearboxTypeCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string GearboxTypeCollectionViaComponentInspectionReportGearbox = "GearboxTypeCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox___________</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox___________ = "GearErrorCollectionViaComponentInspectionReportGearbox___________";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox_______</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox_______ = "GearErrorCollectionViaComponentInspectionReportGearbox_______";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox________</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox________ = "GearErrorCollectionViaComponentInspectionReportGearbox________";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox_____</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox_____ = "GearErrorCollectionViaComponentInspectionReportGearbox_____";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox______</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox______ = "GearErrorCollectionViaComponentInspectionReportGearbox______";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox____________</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox____________ = "GearErrorCollectionViaComponentInspectionReportGearbox____________";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox_____________</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox_____________ = "GearErrorCollectionViaComponentInspectionReportGearbox_____________";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox_________</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox_________ = "GearErrorCollectionViaComponentInspectionReportGearbox_________";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox__________</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox__________ = "GearErrorCollectionViaComponentInspectionReportGearbox__________";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox__</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox__ = "GearErrorCollectionViaComponentInspectionReportGearbox__";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox____</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox____ = "GearErrorCollectionViaComponentInspectionReportGearbox____";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox______________</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox______________ = "GearErrorCollectionViaComponentInspectionReportGearbox______________";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox = "GearErrorCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox___</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox___ = "GearErrorCollectionViaComponentInspectionReportGearbox___";
			/// <summary>Member name GearErrorCollectionViaComponentInspectionReportGearbox_</summary>
			public static readonly string GearErrorCollectionViaComponentInspectionReportGearbox_ = "GearErrorCollectionViaComponentInspectionReportGearbox_";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox_____</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox_____ = "GearTypeCollectionViaComponentInspectionReportGearbox_____";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox_________</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox_________ = "GearTypeCollectionViaComponentInspectionReportGearbox_________";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox__________</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox__________ = "GearTypeCollectionViaComponentInspectionReportGearbox__________";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox______________</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox______________ = "GearTypeCollectionViaComponentInspectionReportGearbox______________";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox____</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox____ = "GearTypeCollectionViaComponentInspectionReportGearbox____";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox____________</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox____________ = "GearTypeCollectionViaComponentInspectionReportGearbox____________";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox_____________</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox_____________ = "GearTypeCollectionViaComponentInspectionReportGearbox_____________";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox________</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox________ = "GearTypeCollectionViaComponentInspectionReportGearbox________";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox_</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox_ = "GearTypeCollectionViaComponentInspectionReportGearbox_";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox = "GearTypeCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox___________</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox___________ = "GearTypeCollectionViaComponentInspectionReportGearbox___________";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox__</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox__ = "GearTypeCollectionViaComponentInspectionReportGearbox__";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox_______</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox_______ = "GearTypeCollectionViaComponentInspectionReportGearbox_______";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox______</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox______ = "GearTypeCollectionViaComponentInspectionReportGearbox______";
			/// <summary>Member name GearTypeCollectionViaComponentInspectionReportGearbox___</summary>
			public static readonly string GearTypeCollectionViaComponentInspectionReportGearbox___ = "GearTypeCollectionViaComponentInspectionReportGearbox___";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGearbox_</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGearbox_ = "GeneratorManufacturerCollectionViaComponentInspectionReportGearbox_";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGearbox = "GeneratorManufacturerCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name HousingErrorCollectionViaComponentInspectionReportGearbox___</summary>
			public static readonly string HousingErrorCollectionViaComponentInspectionReportGearbox___ = "HousingErrorCollectionViaComponentInspectionReportGearbox___";
			/// <summary>Member name HousingErrorCollectionViaComponentInspectionReportGearbox__</summary>
			public static readonly string HousingErrorCollectionViaComponentInspectionReportGearbox__ = "HousingErrorCollectionViaComponentInspectionReportGearbox__";
			/// <summary>Member name HousingErrorCollectionViaComponentInspectionReportGearbox_</summary>
			public static readonly string HousingErrorCollectionViaComponentInspectionReportGearbox_ = "HousingErrorCollectionViaComponentInspectionReportGearbox_";
			/// <summary>Member name HousingErrorCollectionViaComponentInspectionReportGearbox____</summary>
			public static readonly string HousingErrorCollectionViaComponentInspectionReportGearbox____ = "HousingErrorCollectionViaComponentInspectionReportGearbox____";
			/// <summary>Member name HousingErrorCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string HousingErrorCollectionViaComponentInspectionReportGearbox = "HousingErrorCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name HousingErrorCollectionViaComponentInspectionReportGearbox_____</summary>
			public static readonly string HousingErrorCollectionViaComponentInspectionReportGearbox_____ = "HousingErrorCollectionViaComponentInspectionReportGearbox_____";
			/// <summary>Member name InlineFilterCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string InlineFilterCollectionViaComponentInspectionReportGearbox = "InlineFilterCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name MagnetPosCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string MagnetPosCollectionViaComponentInspectionReportGearbox = "MagnetPosCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name MechanicalOilPumpCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string MechanicalOilPumpCollectionViaComponentInspectionReportGearbox = "MechanicalOilPumpCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name OilLevelCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string OilLevelCollectionViaComponentInspectionReportGearbox = "OilLevelCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name OilTypeCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string OilTypeCollectionViaComponentInspectionReportGearbox = "OilTypeCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name OverallGearboxConditionCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string OverallGearboxConditionCollectionViaComponentInspectionReportGearbox = "OverallGearboxConditionCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name ShaftErrorCollectionViaComponentInspectionReportGearbox__</summary>
			public static readonly string ShaftErrorCollectionViaComponentInspectionReportGearbox__ = "ShaftErrorCollectionViaComponentInspectionReportGearbox__";
			/// <summary>Member name ShaftErrorCollectionViaComponentInspectionReportGearbox___</summary>
			public static readonly string ShaftErrorCollectionViaComponentInspectionReportGearbox___ = "ShaftErrorCollectionViaComponentInspectionReportGearbox___";
			/// <summary>Member name ShaftErrorCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string ShaftErrorCollectionViaComponentInspectionReportGearbox = "ShaftErrorCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name ShaftErrorCollectionViaComponentInspectionReportGearbox_</summary>
			public static readonly string ShaftErrorCollectionViaComponentInspectionReportGearbox_ = "ShaftErrorCollectionViaComponentInspectionReportGearbox_";
			/// <summary>Member name ShaftTypeCollectionViaComponentInspectionReportGearbox__</summary>
			public static readonly string ShaftTypeCollectionViaComponentInspectionReportGearbox__ = "ShaftTypeCollectionViaComponentInspectionReportGearbox__";
			/// <summary>Member name ShaftTypeCollectionViaComponentInspectionReportGearbox___</summary>
			public static readonly string ShaftTypeCollectionViaComponentInspectionReportGearbox___ = "ShaftTypeCollectionViaComponentInspectionReportGearbox___";
			/// <summary>Member name ShaftTypeCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string ShaftTypeCollectionViaComponentInspectionReportGearbox = "ShaftTypeCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name ShaftTypeCollectionViaComponentInspectionReportGearbox_</summary>
			public static readonly string ShaftTypeCollectionViaComponentInspectionReportGearbox_ = "ShaftTypeCollectionViaComponentInspectionReportGearbox_";
			/// <summary>Member name ShrinkElementCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string ShrinkElementCollectionViaComponentInspectionReportGearbox = "ShrinkElementCollectionViaComponentInspectionReportGearbox";
			/// <summary>Member name VibrationsCollectionViaComponentInspectionReportGearbox</summary>
			public static readonly string VibrationsCollectionViaComponentInspectionReportGearbox = "VibrationsCollectionViaComponentInspectionReportGearbox";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static NoiseEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public NoiseEntity():base("NoiseEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public NoiseEntity(IEntityFields2 fields):base("NoiseEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this NoiseEntity</param>
		public NoiseEntity(IValidator validator):base("NoiseEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="noiseId">PK value for Noise which data should be fetched into this Noise object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NoiseEntity(System.Int64 noiseId):base("NoiseEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.NoiseId = noiseId;
		}

		/// <summary> CTor</summary>
		/// <param name="noiseId">PK value for Noise which data should be fetched into this Noise object</param>
		/// <param name="validator">The custom validator object for this NoiseEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public NoiseEntity(System.Int64 noiseId, IValidator validator):base("NoiseEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.NoiseId = noiseId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected NoiseEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReportGearbox = (EntityCollection<ComponentInspectionReportGearboxEntity>)info.GetValue("_componentInspectionReportGearbox", typeof(EntityCollection<ComponentInspectionReportGearboxEntity>));
				_noise_ = (EntityCollection<NoiseEntity>)info.GetValue("_noise_", typeof(EntityCollection<NoiseEntity>));
				_bearingErrorCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<BearingErrorEntity>)info.GetValue("_bearingErrorCollectionViaComponentInspectionReportGearbox___", typeof(EntityCollection<BearingErrorEntity>));
				_bearingErrorCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<BearingErrorEntity>)info.GetValue("_bearingErrorCollectionViaComponentInspectionReportGearbox____", typeof(EntityCollection<BearingErrorEntity>));
				_bearingErrorCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<BearingErrorEntity>)info.GetValue("_bearingErrorCollectionViaComponentInspectionReportGearbox_____", typeof(EntityCollection<BearingErrorEntity>));
				_bearingErrorCollectionViaComponentInspectionReportGearbox = (EntityCollection<BearingErrorEntity>)info.GetValue("_bearingErrorCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<BearingErrorEntity>));
				_bearingErrorCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<BearingErrorEntity>)info.GetValue("_bearingErrorCollectionViaComponentInspectionReportGearbox_", typeof(EntityCollection<BearingErrorEntity>));
				_bearingErrorCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<BearingErrorEntity>)info.GetValue("_bearingErrorCollectionViaComponentInspectionReportGearbox__", typeof(EntityCollection<BearingErrorEntity>));
				_bearingPosCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<BearingPosEntity>)info.GetValue("_bearingPosCollectionViaComponentInspectionReportGearbox____", typeof(EntityCollection<BearingPosEntity>));
				_bearingPosCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<BearingPosEntity>)info.GetValue("_bearingPosCollectionViaComponentInspectionReportGearbox_____", typeof(EntityCollection<BearingPosEntity>));
				_bearingPosCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<BearingPosEntity>)info.GetValue("_bearingPosCollectionViaComponentInspectionReportGearbox___", typeof(EntityCollection<BearingPosEntity>));
				_bearingPosCollectionViaComponentInspectionReportGearbox = (EntityCollection<BearingPosEntity>)info.GetValue("_bearingPosCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<BearingPosEntity>));
				_bearingPosCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<BearingPosEntity>)info.GetValue("_bearingPosCollectionViaComponentInspectionReportGearbox_", typeof(EntityCollection<BearingPosEntity>));
				_bearingPosCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<BearingPosEntity>)info.GetValue("_bearingPosCollectionViaComponentInspectionReportGearbox__", typeof(EntityCollection<BearingPosEntity>));
				_bearingTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<BearingTypeEntity>)info.GetValue("_bearingTypeCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<BearingTypeEntity>));
				_bearingTypeCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<BearingTypeEntity>)info.GetValue("_bearingTypeCollectionViaComponentInspectionReportGearbox_____", typeof(EntityCollection<BearingTypeEntity>));
				_bearingTypeCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<BearingTypeEntity>)info.GetValue("_bearingTypeCollectionViaComponentInspectionReportGearbox____", typeof(EntityCollection<BearingTypeEntity>));
				_bearingTypeCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<BearingTypeEntity>)info.GetValue("_bearingTypeCollectionViaComponentInspectionReportGearbox___", typeof(EntityCollection<BearingTypeEntity>));
				_bearingTypeCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<BearingTypeEntity>)info.GetValue("_bearingTypeCollectionViaComponentInspectionReportGearbox__", typeof(EntityCollection<BearingTypeEntity>));
				_bearingTypeCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<BearingTypeEntity>)info.GetValue("_bearingTypeCollectionViaComponentInspectionReportGearbox_", typeof(EntityCollection<BearingTypeEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGearbox_", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGearbox = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<BooleanAnswerEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGearbox = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_couplingCollectionViaComponentInspectionReportGearbox = (EntityCollection<CouplingEntity>)info.GetValue("_couplingCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<CouplingEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox____________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox____________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox_____________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_____________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox__________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox__________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox___________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox___________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox_______________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_______________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox________________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox________________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox_________________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_________________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox______________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox______________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox___", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox__", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox____", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_____", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox_________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox______ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox______", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox_______ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_______", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox__________________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox__________________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox___________________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox___________________", typeof(EntityCollection<DamageDecisionEntity>));
				_damageDecisionCollectionViaComponentInspectionReportGearbox____________________ = (EntityCollection<DamageDecisionEntity>)info.GetValue("_damageDecisionCollectionViaComponentInspectionReportGearbox____________________", typeof(EntityCollection<DamageDecisionEntity>));
				_debrisGearboxCollectionViaComponentInspectionReportGearbox = (EntityCollection<DebrisGearboxEntity>)info.GetValue("_debrisGearboxCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<DebrisGearboxEntity>));
				_debrisOnMagnetCollectionViaComponentInspectionReportGearbox = (EntityCollection<DebrisOnMagnetEntity>)info.GetValue("_debrisOnMagnetCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<DebrisOnMagnetEntity>));
				_electricalPumpCollectionViaComponentInspectionReportGearbox = (EntityCollection<ElectricalPumpEntity>)info.GetValue("_electricalPumpCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<ElectricalPumpEntity>));
				_filterBlockTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<FilterBlockTypeEntity>)info.GetValue("_filterBlockTypeCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<FilterBlockTypeEntity>));
				_gearboxManufacturerCollectionViaComponentInspectionReportGearbox = (EntityCollection<GearboxManufacturerEntity>)info.GetValue("_gearboxManufacturerCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<GearboxManufacturerEntity>));
				_gearboxRevisionCollectionViaComponentInspectionReportGearbox = (EntityCollection<GearboxRevisionEntity>)info.GetValue("_gearboxRevisionCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<GearboxRevisionEntity>));
				_gearboxTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<GearboxTypeEntity>)info.GetValue("_gearboxTypeCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<GearboxTypeEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox___________ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox___________", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox_______ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox_______", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox________ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox________", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox_____", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox______ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox______", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox____________ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox____________", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox_____________ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox_____________", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox_________ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox_________", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox__________ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox__________", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox__", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox____", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox______________ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox______________", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox___", typeof(EntityCollection<GearErrorEntity>));
				_gearErrorCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<GearErrorEntity>)info.GetValue("_gearErrorCollectionViaComponentInspectionReportGearbox_", typeof(EntityCollection<GearErrorEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox_____", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox_________ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox_________", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox__________ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox__________", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox______________ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox______________", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox____", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox____________ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox____________", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox_____________ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox_____________", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox________ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox________", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox_", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox___________ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox___________", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox__", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox_______ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox_______", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox______ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox______", typeof(EntityCollection<GearTypeEntity>));
				_gearTypeCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<GearTypeEntity>)info.GetValue("_gearTypeCollectionViaComponentInspectionReportGearbox___", typeof(EntityCollection<GearTypeEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGearbox_", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGearbox = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_housingErrorCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<HousingErrorEntity>)info.GetValue("_housingErrorCollectionViaComponentInspectionReportGearbox___", typeof(EntityCollection<HousingErrorEntity>));
				_housingErrorCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<HousingErrorEntity>)info.GetValue("_housingErrorCollectionViaComponentInspectionReportGearbox__", typeof(EntityCollection<HousingErrorEntity>));
				_housingErrorCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<HousingErrorEntity>)info.GetValue("_housingErrorCollectionViaComponentInspectionReportGearbox_", typeof(EntityCollection<HousingErrorEntity>));
				_housingErrorCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<HousingErrorEntity>)info.GetValue("_housingErrorCollectionViaComponentInspectionReportGearbox____", typeof(EntityCollection<HousingErrorEntity>));
				_housingErrorCollectionViaComponentInspectionReportGearbox = (EntityCollection<HousingErrorEntity>)info.GetValue("_housingErrorCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<HousingErrorEntity>));
				_housingErrorCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<HousingErrorEntity>)info.GetValue("_housingErrorCollectionViaComponentInspectionReportGearbox_____", typeof(EntityCollection<HousingErrorEntity>));
				_inlineFilterCollectionViaComponentInspectionReportGearbox = (EntityCollection<InlineFilterEntity>)info.GetValue("_inlineFilterCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<InlineFilterEntity>));
				_magnetPosCollectionViaComponentInspectionReportGearbox = (EntityCollection<MagnetPosEntity>)info.GetValue("_magnetPosCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<MagnetPosEntity>));
				_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox = (EntityCollection<MechanicalOilPumpEntity>)info.GetValue("_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<MechanicalOilPumpEntity>));
				_oilLevelCollectionViaComponentInspectionReportGearbox = (EntityCollection<OilLevelEntity>)info.GetValue("_oilLevelCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<OilLevelEntity>));
				_oilTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<OilTypeEntity>)info.GetValue("_oilTypeCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<OilTypeEntity>));
				_overallGearboxConditionCollectionViaComponentInspectionReportGearbox = (EntityCollection<OverallGearboxConditionEntity>)info.GetValue("_overallGearboxConditionCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<OverallGearboxConditionEntity>));
				_shaftErrorCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<ShaftErrorEntity>)info.GetValue("_shaftErrorCollectionViaComponentInspectionReportGearbox__", typeof(EntityCollection<ShaftErrorEntity>));
				_shaftErrorCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<ShaftErrorEntity>)info.GetValue("_shaftErrorCollectionViaComponentInspectionReportGearbox___", typeof(EntityCollection<ShaftErrorEntity>));
				_shaftErrorCollectionViaComponentInspectionReportGearbox = (EntityCollection<ShaftErrorEntity>)info.GetValue("_shaftErrorCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<ShaftErrorEntity>));
				_shaftErrorCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<ShaftErrorEntity>)info.GetValue("_shaftErrorCollectionViaComponentInspectionReportGearbox_", typeof(EntityCollection<ShaftErrorEntity>));
				_shaftTypeCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<ShaftTypeEntity>)info.GetValue("_shaftTypeCollectionViaComponentInspectionReportGearbox__", typeof(EntityCollection<ShaftTypeEntity>));
				_shaftTypeCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<ShaftTypeEntity>)info.GetValue("_shaftTypeCollectionViaComponentInspectionReportGearbox___", typeof(EntityCollection<ShaftTypeEntity>));
				_shaftTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<ShaftTypeEntity>)info.GetValue("_shaftTypeCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<ShaftTypeEntity>));
				_shaftTypeCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<ShaftTypeEntity>)info.GetValue("_shaftTypeCollectionViaComponentInspectionReportGearbox_", typeof(EntityCollection<ShaftTypeEntity>));
				_shrinkElementCollectionViaComponentInspectionReportGearbox = (EntityCollection<ShrinkElementEntity>)info.GetValue("_shrinkElementCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<ShrinkElementEntity>));
				_vibrationsCollectionViaComponentInspectionReportGearbox = (EntityCollection<VibrationsEntity>)info.GetValue("_vibrationsCollectionViaComponentInspectionReportGearbox", typeof(EntityCollection<VibrationsEntity>));
				_noise = (NoiseEntity)info.GetValue("_noise", typeof(NoiseEntity));
				if(_noise!=null)
				{
					_noise.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((NoiseFieldIndex)fieldIndex)
			{
				case NoiseFieldIndex.ParentNoiseId:
					DesetupSyncNoise(true, false);
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
				case "Noise":
					this.Noise = (NoiseEntity)entity;
					break;
				case "ComponentInspectionReportGearbox":
					this.ComponentInspectionReportGearbox.Add((ComponentInspectionReportGearboxEntity)entity);
					break;
				case "Noise_":
					this.Noise_.Add((NoiseEntity)entity);
					break;
				case "BearingErrorCollectionViaComponentInspectionReportGearbox___":
					this.BearingErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly = false;
					this.BearingErrorCollectionViaComponentInspectionReportGearbox___.Add((BearingErrorEntity)entity);
					this.BearingErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly = true;
					break;
				case "BearingErrorCollectionViaComponentInspectionReportGearbox____":
					this.BearingErrorCollectionViaComponentInspectionReportGearbox____.IsReadOnly = false;
					this.BearingErrorCollectionViaComponentInspectionReportGearbox____.Add((BearingErrorEntity)entity);
					this.BearingErrorCollectionViaComponentInspectionReportGearbox____.IsReadOnly = true;
					break;
				case "BearingErrorCollectionViaComponentInspectionReportGearbox_____":
					this.BearingErrorCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = false;
					this.BearingErrorCollectionViaComponentInspectionReportGearbox_____.Add((BearingErrorEntity)entity);
					this.BearingErrorCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = true;
					break;
				case "BearingErrorCollectionViaComponentInspectionReportGearbox":
					this.BearingErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.BearingErrorCollectionViaComponentInspectionReportGearbox.Add((BearingErrorEntity)entity);
					this.BearingErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "BearingErrorCollectionViaComponentInspectionReportGearbox_":
					this.BearingErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly = false;
					this.BearingErrorCollectionViaComponentInspectionReportGearbox_.Add((BearingErrorEntity)entity);
					this.BearingErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly = true;
					break;
				case "BearingErrorCollectionViaComponentInspectionReportGearbox__":
					this.BearingErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly = false;
					this.BearingErrorCollectionViaComponentInspectionReportGearbox__.Add((BearingErrorEntity)entity);
					this.BearingErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly = true;
					break;
				case "BearingPosCollectionViaComponentInspectionReportGearbox____":
					this.BearingPosCollectionViaComponentInspectionReportGearbox____.IsReadOnly = false;
					this.BearingPosCollectionViaComponentInspectionReportGearbox____.Add((BearingPosEntity)entity);
					this.BearingPosCollectionViaComponentInspectionReportGearbox____.IsReadOnly = true;
					break;
				case "BearingPosCollectionViaComponentInspectionReportGearbox_____":
					this.BearingPosCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = false;
					this.BearingPosCollectionViaComponentInspectionReportGearbox_____.Add((BearingPosEntity)entity);
					this.BearingPosCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = true;
					break;
				case "BearingPosCollectionViaComponentInspectionReportGearbox___":
					this.BearingPosCollectionViaComponentInspectionReportGearbox___.IsReadOnly = false;
					this.BearingPosCollectionViaComponentInspectionReportGearbox___.Add((BearingPosEntity)entity);
					this.BearingPosCollectionViaComponentInspectionReportGearbox___.IsReadOnly = true;
					break;
				case "BearingPosCollectionViaComponentInspectionReportGearbox":
					this.BearingPosCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.BearingPosCollectionViaComponentInspectionReportGearbox.Add((BearingPosEntity)entity);
					this.BearingPosCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "BearingPosCollectionViaComponentInspectionReportGearbox_":
					this.BearingPosCollectionViaComponentInspectionReportGearbox_.IsReadOnly = false;
					this.BearingPosCollectionViaComponentInspectionReportGearbox_.Add((BearingPosEntity)entity);
					this.BearingPosCollectionViaComponentInspectionReportGearbox_.IsReadOnly = true;
					break;
				case "BearingPosCollectionViaComponentInspectionReportGearbox__":
					this.BearingPosCollectionViaComponentInspectionReportGearbox__.IsReadOnly = false;
					this.BearingPosCollectionViaComponentInspectionReportGearbox__.Add((BearingPosEntity)entity);
					this.BearingPosCollectionViaComponentInspectionReportGearbox__.IsReadOnly = true;
					break;
				case "BearingTypeCollectionViaComponentInspectionReportGearbox":
					this.BearingTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.BearingTypeCollectionViaComponentInspectionReportGearbox.Add((BearingTypeEntity)entity);
					this.BearingTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "BearingTypeCollectionViaComponentInspectionReportGearbox_____":
					this.BearingTypeCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = false;
					this.BearingTypeCollectionViaComponentInspectionReportGearbox_____.Add((BearingTypeEntity)entity);
					this.BearingTypeCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = true;
					break;
				case "BearingTypeCollectionViaComponentInspectionReportGearbox____":
					this.BearingTypeCollectionViaComponentInspectionReportGearbox____.IsReadOnly = false;
					this.BearingTypeCollectionViaComponentInspectionReportGearbox____.Add((BearingTypeEntity)entity);
					this.BearingTypeCollectionViaComponentInspectionReportGearbox____.IsReadOnly = true;
					break;
				case "BearingTypeCollectionViaComponentInspectionReportGearbox___":
					this.BearingTypeCollectionViaComponentInspectionReportGearbox___.IsReadOnly = false;
					this.BearingTypeCollectionViaComponentInspectionReportGearbox___.Add((BearingTypeEntity)entity);
					this.BearingTypeCollectionViaComponentInspectionReportGearbox___.IsReadOnly = true;
					break;
				case "BearingTypeCollectionViaComponentInspectionReportGearbox__":
					this.BearingTypeCollectionViaComponentInspectionReportGearbox__.IsReadOnly = false;
					this.BearingTypeCollectionViaComponentInspectionReportGearbox__.Add((BearingTypeEntity)entity);
					this.BearingTypeCollectionViaComponentInspectionReportGearbox__.IsReadOnly = true;
					break;
				case "BearingTypeCollectionViaComponentInspectionReportGearbox_":
					this.BearingTypeCollectionViaComponentInspectionReportGearbox_.IsReadOnly = false;
					this.BearingTypeCollectionViaComponentInspectionReportGearbox_.Add((BearingTypeEntity)entity);
					this.BearingTypeCollectionViaComponentInspectionReportGearbox_.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGearbox_":
					this.BooleanAnswerCollectionViaComponentInspectionReportGearbox_.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGearbox_.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGearbox_.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGearbox":
					this.BooleanAnswerCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGearbox.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGearbox":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGearbox.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "CouplingCollectionViaComponentInspectionReportGearbox":
					this.CouplingCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.CouplingCollectionViaComponentInspectionReportGearbox.Add((CouplingEntity)entity);
					this.CouplingCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox____________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox____________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox____________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox____________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox_____________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_____________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_____________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_____________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox__________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox__________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox__________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox__________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox___________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox___________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox___________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox___________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox_______________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_______________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_______________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_______________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox________________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox________________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox________________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox________________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox_________________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_________________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_________________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_________________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox______________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox______________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox______________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox______________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox___":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox___.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox___.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox___.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox__":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox__.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox__.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox__.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox____":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox____.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox____.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox____.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox_____":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_____.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox_________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox______":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox______.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox______.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox______.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox_______":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_______.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_______.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_______.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox__________________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox__________________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox__________________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox__________________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox_":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox_.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox___________________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox___________________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox___________________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox___________________.IsReadOnly = true;
					break;
				case "DamageDecisionCollectionViaComponentInspectionReportGearbox____________________":
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox____________________.IsReadOnly = false;
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox____________________.Add((DamageDecisionEntity)entity);
					this.DamageDecisionCollectionViaComponentInspectionReportGearbox____________________.IsReadOnly = true;
					break;
				case "DebrisGearboxCollectionViaComponentInspectionReportGearbox":
					this.DebrisGearboxCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.DebrisGearboxCollectionViaComponentInspectionReportGearbox.Add((DebrisGearboxEntity)entity);
					this.DebrisGearboxCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "DebrisOnMagnetCollectionViaComponentInspectionReportGearbox":
					this.DebrisOnMagnetCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.DebrisOnMagnetCollectionViaComponentInspectionReportGearbox.Add((DebrisOnMagnetEntity)entity);
					this.DebrisOnMagnetCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "ElectricalPumpCollectionViaComponentInspectionReportGearbox":
					this.ElectricalPumpCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.ElectricalPumpCollectionViaComponentInspectionReportGearbox.Add((ElectricalPumpEntity)entity);
					this.ElectricalPumpCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "FilterBlockTypeCollectionViaComponentInspectionReportGearbox":
					this.FilterBlockTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.FilterBlockTypeCollectionViaComponentInspectionReportGearbox.Add((FilterBlockTypeEntity)entity);
					this.FilterBlockTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "GearboxManufacturerCollectionViaComponentInspectionReportGearbox":
					this.GearboxManufacturerCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.GearboxManufacturerCollectionViaComponentInspectionReportGearbox.Add((GearboxManufacturerEntity)entity);
					this.GearboxManufacturerCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "GearboxRevisionCollectionViaComponentInspectionReportGearbox":
					this.GearboxRevisionCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.GearboxRevisionCollectionViaComponentInspectionReportGearbox.Add((GearboxRevisionEntity)entity);
					this.GearboxRevisionCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "GearboxTypeCollectionViaComponentInspectionReportGearbox":
					this.GearboxTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.GearboxTypeCollectionViaComponentInspectionReportGearbox.Add((GearboxTypeEntity)entity);
					this.GearboxTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox___________":
					this.GearErrorCollectionViaComponentInspectionReportGearbox___________.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox___________.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox___________.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox_______":
					this.GearErrorCollectionViaComponentInspectionReportGearbox_______.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox_______.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox_______.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox________":
					this.GearErrorCollectionViaComponentInspectionReportGearbox________.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox________.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox________.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox_____":
					this.GearErrorCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox_____.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox______":
					this.GearErrorCollectionViaComponentInspectionReportGearbox______.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox______.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox______.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox____________":
					this.GearErrorCollectionViaComponentInspectionReportGearbox____________.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox____________.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox____________.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox_____________":
					this.GearErrorCollectionViaComponentInspectionReportGearbox_____________.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox_____________.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox_____________.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox_________":
					this.GearErrorCollectionViaComponentInspectionReportGearbox_________.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox_________.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox_________.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox__________":
					this.GearErrorCollectionViaComponentInspectionReportGearbox__________.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox__________.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox__________.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox__":
					this.GearErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox__.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox____":
					this.GearErrorCollectionViaComponentInspectionReportGearbox____.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox____.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox____.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox______________":
					this.GearErrorCollectionViaComponentInspectionReportGearbox______________.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox______________.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox______________.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox":
					this.GearErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox___":
					this.GearErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox___.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly = true;
					break;
				case "GearErrorCollectionViaComponentInspectionReportGearbox_":
					this.GearErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly = false;
					this.GearErrorCollectionViaComponentInspectionReportGearbox_.Add((GearErrorEntity)entity);
					this.GearErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox_____":
					this.GearTypeCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox_____.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox_________":
					this.GearTypeCollectionViaComponentInspectionReportGearbox_________.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox_________.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox_________.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox__________":
					this.GearTypeCollectionViaComponentInspectionReportGearbox__________.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox__________.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox__________.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox______________":
					this.GearTypeCollectionViaComponentInspectionReportGearbox______________.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox______________.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox______________.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox____":
					this.GearTypeCollectionViaComponentInspectionReportGearbox____.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox____.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox____.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox____________":
					this.GearTypeCollectionViaComponentInspectionReportGearbox____________.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox____________.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox____________.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox_____________":
					this.GearTypeCollectionViaComponentInspectionReportGearbox_____________.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox_____________.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox_____________.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox________":
					this.GearTypeCollectionViaComponentInspectionReportGearbox________.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox________.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox________.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox_":
					this.GearTypeCollectionViaComponentInspectionReportGearbox_.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox_.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox_.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox":
					this.GearTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox___________":
					this.GearTypeCollectionViaComponentInspectionReportGearbox___________.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox___________.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox___________.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox__":
					this.GearTypeCollectionViaComponentInspectionReportGearbox__.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox__.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox__.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox_______":
					this.GearTypeCollectionViaComponentInspectionReportGearbox_______.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox_______.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox_______.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox______":
					this.GearTypeCollectionViaComponentInspectionReportGearbox______.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox______.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox______.IsReadOnly = true;
					break;
				case "GearTypeCollectionViaComponentInspectionReportGearbox___":
					this.GearTypeCollectionViaComponentInspectionReportGearbox___.IsReadOnly = false;
					this.GearTypeCollectionViaComponentInspectionReportGearbox___.Add((GearTypeEntity)entity);
					this.GearTypeCollectionViaComponentInspectionReportGearbox___.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGearbox_":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGearbox_.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGearbox_.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGearbox_.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGearbox":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGearbox.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "HousingErrorCollectionViaComponentInspectionReportGearbox___":
					this.HousingErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly = false;
					this.HousingErrorCollectionViaComponentInspectionReportGearbox___.Add((HousingErrorEntity)entity);
					this.HousingErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly = true;
					break;
				case "HousingErrorCollectionViaComponentInspectionReportGearbox__":
					this.HousingErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly = false;
					this.HousingErrorCollectionViaComponentInspectionReportGearbox__.Add((HousingErrorEntity)entity);
					this.HousingErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly = true;
					break;
				case "HousingErrorCollectionViaComponentInspectionReportGearbox_":
					this.HousingErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly = false;
					this.HousingErrorCollectionViaComponentInspectionReportGearbox_.Add((HousingErrorEntity)entity);
					this.HousingErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly = true;
					break;
				case "HousingErrorCollectionViaComponentInspectionReportGearbox____":
					this.HousingErrorCollectionViaComponentInspectionReportGearbox____.IsReadOnly = false;
					this.HousingErrorCollectionViaComponentInspectionReportGearbox____.Add((HousingErrorEntity)entity);
					this.HousingErrorCollectionViaComponentInspectionReportGearbox____.IsReadOnly = true;
					break;
				case "HousingErrorCollectionViaComponentInspectionReportGearbox":
					this.HousingErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.HousingErrorCollectionViaComponentInspectionReportGearbox.Add((HousingErrorEntity)entity);
					this.HousingErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "HousingErrorCollectionViaComponentInspectionReportGearbox_____":
					this.HousingErrorCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = false;
					this.HousingErrorCollectionViaComponentInspectionReportGearbox_____.Add((HousingErrorEntity)entity);
					this.HousingErrorCollectionViaComponentInspectionReportGearbox_____.IsReadOnly = true;
					break;
				case "InlineFilterCollectionViaComponentInspectionReportGearbox":
					this.InlineFilterCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.InlineFilterCollectionViaComponentInspectionReportGearbox.Add((InlineFilterEntity)entity);
					this.InlineFilterCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "MagnetPosCollectionViaComponentInspectionReportGearbox":
					this.MagnetPosCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.MagnetPosCollectionViaComponentInspectionReportGearbox.Add((MagnetPosEntity)entity);
					this.MagnetPosCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "MechanicalOilPumpCollectionViaComponentInspectionReportGearbox":
					this.MechanicalOilPumpCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.MechanicalOilPumpCollectionViaComponentInspectionReportGearbox.Add((MechanicalOilPumpEntity)entity);
					this.MechanicalOilPumpCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "OilLevelCollectionViaComponentInspectionReportGearbox":
					this.OilLevelCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.OilLevelCollectionViaComponentInspectionReportGearbox.Add((OilLevelEntity)entity);
					this.OilLevelCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "OilTypeCollectionViaComponentInspectionReportGearbox":
					this.OilTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.OilTypeCollectionViaComponentInspectionReportGearbox.Add((OilTypeEntity)entity);
					this.OilTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "OverallGearboxConditionCollectionViaComponentInspectionReportGearbox":
					this.OverallGearboxConditionCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.OverallGearboxConditionCollectionViaComponentInspectionReportGearbox.Add((OverallGearboxConditionEntity)entity);
					this.OverallGearboxConditionCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "ShaftErrorCollectionViaComponentInspectionReportGearbox__":
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly = false;
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox__.Add((ShaftErrorEntity)entity);
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly = true;
					break;
				case "ShaftErrorCollectionViaComponentInspectionReportGearbox___":
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly = false;
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox___.Add((ShaftErrorEntity)entity);
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly = true;
					break;
				case "ShaftErrorCollectionViaComponentInspectionReportGearbox":
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox.Add((ShaftErrorEntity)entity);
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "ShaftErrorCollectionViaComponentInspectionReportGearbox_":
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly = false;
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox_.Add((ShaftErrorEntity)entity);
					this.ShaftErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly = true;
					break;
				case "ShaftTypeCollectionViaComponentInspectionReportGearbox__":
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox__.IsReadOnly = false;
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox__.Add((ShaftTypeEntity)entity);
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox__.IsReadOnly = true;
					break;
				case "ShaftTypeCollectionViaComponentInspectionReportGearbox___":
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox___.IsReadOnly = false;
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox___.Add((ShaftTypeEntity)entity);
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox___.IsReadOnly = true;
					break;
				case "ShaftTypeCollectionViaComponentInspectionReportGearbox":
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox.Add((ShaftTypeEntity)entity);
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "ShaftTypeCollectionViaComponentInspectionReportGearbox_":
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox_.IsReadOnly = false;
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox_.Add((ShaftTypeEntity)entity);
					this.ShaftTypeCollectionViaComponentInspectionReportGearbox_.IsReadOnly = true;
					break;
				case "ShrinkElementCollectionViaComponentInspectionReportGearbox":
					this.ShrinkElementCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.ShrinkElementCollectionViaComponentInspectionReportGearbox.Add((ShrinkElementEntity)entity);
					this.ShrinkElementCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
					break;
				case "VibrationsCollectionViaComponentInspectionReportGearbox":
					this.VibrationsCollectionViaComponentInspectionReportGearbox.IsReadOnly = false;
					this.VibrationsCollectionViaComponentInspectionReportGearbox.Add((VibrationsEntity)entity);
					this.VibrationsCollectionViaComponentInspectionReportGearbox.IsReadOnly = true;
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
				case "Noise":
					SetupSyncNoise(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGearbox":
					this.ComponentInspectionReportGearbox.Add((ComponentInspectionReportGearboxEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "Noise_":
					this.Noise_.Add((NoiseEntity)relatedEntity);
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
				case "Noise":
					DesetupSyncNoise(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGearbox":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGearbox, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "Noise_":
					base.PerformRelatedEntityRemoval(this.Noise_, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_noise!=null)
			{
				toReturn.Add(_noise);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReportGearbox);
			toReturn.Add(this.Noise_);

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
				info.AddValue("_componentInspectionReportGearbox", ((_componentInspectionReportGearbox!=null) && (_componentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGearbox:null);
				info.AddValue("_noise_", ((_noise_!=null) && (_noise_.Count>0) && !this.MarkedForDeletion)?_noise_:null);
				info.AddValue("_bearingErrorCollectionViaComponentInspectionReportGearbox___", ((_bearingErrorCollectionViaComponentInspectionReportGearbox___!=null) && (_bearingErrorCollectionViaComponentInspectionReportGearbox___.Count>0) && !this.MarkedForDeletion)?_bearingErrorCollectionViaComponentInspectionReportGearbox___:null);
				info.AddValue("_bearingErrorCollectionViaComponentInspectionReportGearbox____", ((_bearingErrorCollectionViaComponentInspectionReportGearbox____!=null) && (_bearingErrorCollectionViaComponentInspectionReportGearbox____.Count>0) && !this.MarkedForDeletion)?_bearingErrorCollectionViaComponentInspectionReportGearbox____:null);
				info.AddValue("_bearingErrorCollectionViaComponentInspectionReportGearbox_____", ((_bearingErrorCollectionViaComponentInspectionReportGearbox_____!=null) && (_bearingErrorCollectionViaComponentInspectionReportGearbox_____.Count>0) && !this.MarkedForDeletion)?_bearingErrorCollectionViaComponentInspectionReportGearbox_____:null);
				info.AddValue("_bearingErrorCollectionViaComponentInspectionReportGearbox", ((_bearingErrorCollectionViaComponentInspectionReportGearbox!=null) && (_bearingErrorCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_bearingErrorCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_bearingErrorCollectionViaComponentInspectionReportGearbox_", ((_bearingErrorCollectionViaComponentInspectionReportGearbox_!=null) && (_bearingErrorCollectionViaComponentInspectionReportGearbox_.Count>0) && !this.MarkedForDeletion)?_bearingErrorCollectionViaComponentInspectionReportGearbox_:null);
				info.AddValue("_bearingErrorCollectionViaComponentInspectionReportGearbox__", ((_bearingErrorCollectionViaComponentInspectionReportGearbox__!=null) && (_bearingErrorCollectionViaComponentInspectionReportGearbox__.Count>0) && !this.MarkedForDeletion)?_bearingErrorCollectionViaComponentInspectionReportGearbox__:null);
				info.AddValue("_bearingPosCollectionViaComponentInspectionReportGearbox____", ((_bearingPosCollectionViaComponentInspectionReportGearbox____!=null) && (_bearingPosCollectionViaComponentInspectionReportGearbox____.Count>0) && !this.MarkedForDeletion)?_bearingPosCollectionViaComponentInspectionReportGearbox____:null);
				info.AddValue("_bearingPosCollectionViaComponentInspectionReportGearbox_____", ((_bearingPosCollectionViaComponentInspectionReportGearbox_____!=null) && (_bearingPosCollectionViaComponentInspectionReportGearbox_____.Count>0) && !this.MarkedForDeletion)?_bearingPosCollectionViaComponentInspectionReportGearbox_____:null);
				info.AddValue("_bearingPosCollectionViaComponentInspectionReportGearbox___", ((_bearingPosCollectionViaComponentInspectionReportGearbox___!=null) && (_bearingPosCollectionViaComponentInspectionReportGearbox___.Count>0) && !this.MarkedForDeletion)?_bearingPosCollectionViaComponentInspectionReportGearbox___:null);
				info.AddValue("_bearingPosCollectionViaComponentInspectionReportGearbox", ((_bearingPosCollectionViaComponentInspectionReportGearbox!=null) && (_bearingPosCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_bearingPosCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_bearingPosCollectionViaComponentInspectionReportGearbox_", ((_bearingPosCollectionViaComponentInspectionReportGearbox_!=null) && (_bearingPosCollectionViaComponentInspectionReportGearbox_.Count>0) && !this.MarkedForDeletion)?_bearingPosCollectionViaComponentInspectionReportGearbox_:null);
				info.AddValue("_bearingPosCollectionViaComponentInspectionReportGearbox__", ((_bearingPosCollectionViaComponentInspectionReportGearbox__!=null) && (_bearingPosCollectionViaComponentInspectionReportGearbox__.Count>0) && !this.MarkedForDeletion)?_bearingPosCollectionViaComponentInspectionReportGearbox__:null);
				info.AddValue("_bearingTypeCollectionViaComponentInspectionReportGearbox", ((_bearingTypeCollectionViaComponentInspectionReportGearbox!=null) && (_bearingTypeCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_bearingTypeCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_bearingTypeCollectionViaComponentInspectionReportGearbox_____", ((_bearingTypeCollectionViaComponentInspectionReportGearbox_____!=null) && (_bearingTypeCollectionViaComponentInspectionReportGearbox_____.Count>0) && !this.MarkedForDeletion)?_bearingTypeCollectionViaComponentInspectionReportGearbox_____:null);
				info.AddValue("_bearingTypeCollectionViaComponentInspectionReportGearbox____", ((_bearingTypeCollectionViaComponentInspectionReportGearbox____!=null) && (_bearingTypeCollectionViaComponentInspectionReportGearbox____.Count>0) && !this.MarkedForDeletion)?_bearingTypeCollectionViaComponentInspectionReportGearbox____:null);
				info.AddValue("_bearingTypeCollectionViaComponentInspectionReportGearbox___", ((_bearingTypeCollectionViaComponentInspectionReportGearbox___!=null) && (_bearingTypeCollectionViaComponentInspectionReportGearbox___.Count>0) && !this.MarkedForDeletion)?_bearingTypeCollectionViaComponentInspectionReportGearbox___:null);
				info.AddValue("_bearingTypeCollectionViaComponentInspectionReportGearbox__", ((_bearingTypeCollectionViaComponentInspectionReportGearbox__!=null) && (_bearingTypeCollectionViaComponentInspectionReportGearbox__.Count>0) && !this.MarkedForDeletion)?_bearingTypeCollectionViaComponentInspectionReportGearbox__:null);
				info.AddValue("_bearingTypeCollectionViaComponentInspectionReportGearbox_", ((_bearingTypeCollectionViaComponentInspectionReportGearbox_!=null) && (_bearingTypeCollectionViaComponentInspectionReportGearbox_.Count>0) && !this.MarkedForDeletion)?_bearingTypeCollectionViaComponentInspectionReportGearbox_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGearbox_", ((_booleanAnswerCollectionViaComponentInspectionReportGearbox_!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGearbox_.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGearbox_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGearbox", ((_booleanAnswerCollectionViaComponentInspectionReportGearbox!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGearbox", ((_componentInspectionReportCollectionViaComponentInspectionReportGearbox!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_couplingCollectionViaComponentInspectionReportGearbox", ((_couplingCollectionViaComponentInspectionReportGearbox!=null) && (_couplingCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_couplingCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox____________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox____________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox____________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox____________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_____________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox_____________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox_____________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox_____________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox__________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox__________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox__________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox__________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox___________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox___________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox___________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox___________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_______________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox_______________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox_______________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox_______________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox________________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox________________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox________________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox________________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_________________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox_________________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox_________________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox_________________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox______________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox______________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox______________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox______________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox___", ((_damageDecisionCollectionViaComponentInspectionReportGearbox___!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox___.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox___:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox__", ((_damageDecisionCollectionViaComponentInspectionReportGearbox__!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox__.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox__:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox____", ((_damageDecisionCollectionViaComponentInspectionReportGearbox____!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox____.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox____:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_____", ((_damageDecisionCollectionViaComponentInspectionReportGearbox_____!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox_____.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox_____:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox_________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox_________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox_________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox______", ((_damageDecisionCollectionViaComponentInspectionReportGearbox______!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox______.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox______:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_______", ((_damageDecisionCollectionViaComponentInspectionReportGearbox_______!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox_______.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox_______:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox__________________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox__________________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox__________________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox__________________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox_", ((_damageDecisionCollectionViaComponentInspectionReportGearbox_!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox_.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox_:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox", ((_damageDecisionCollectionViaComponentInspectionReportGearbox!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox___________________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox___________________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox___________________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox___________________:null);
				info.AddValue("_damageDecisionCollectionViaComponentInspectionReportGearbox____________________", ((_damageDecisionCollectionViaComponentInspectionReportGearbox____________________!=null) && (_damageDecisionCollectionViaComponentInspectionReportGearbox____________________.Count>0) && !this.MarkedForDeletion)?_damageDecisionCollectionViaComponentInspectionReportGearbox____________________:null);
				info.AddValue("_debrisGearboxCollectionViaComponentInspectionReportGearbox", ((_debrisGearboxCollectionViaComponentInspectionReportGearbox!=null) && (_debrisGearboxCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_debrisGearboxCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_debrisOnMagnetCollectionViaComponentInspectionReportGearbox", ((_debrisOnMagnetCollectionViaComponentInspectionReportGearbox!=null) && (_debrisOnMagnetCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_debrisOnMagnetCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_electricalPumpCollectionViaComponentInspectionReportGearbox", ((_electricalPumpCollectionViaComponentInspectionReportGearbox!=null) && (_electricalPumpCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_electricalPumpCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_filterBlockTypeCollectionViaComponentInspectionReportGearbox", ((_filterBlockTypeCollectionViaComponentInspectionReportGearbox!=null) && (_filterBlockTypeCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_filterBlockTypeCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_gearboxManufacturerCollectionViaComponentInspectionReportGearbox", ((_gearboxManufacturerCollectionViaComponentInspectionReportGearbox!=null) && (_gearboxManufacturerCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_gearboxManufacturerCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_gearboxRevisionCollectionViaComponentInspectionReportGearbox", ((_gearboxRevisionCollectionViaComponentInspectionReportGearbox!=null) && (_gearboxRevisionCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_gearboxRevisionCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_gearboxTypeCollectionViaComponentInspectionReportGearbox", ((_gearboxTypeCollectionViaComponentInspectionReportGearbox!=null) && (_gearboxTypeCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_gearboxTypeCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox___________", ((_gearErrorCollectionViaComponentInspectionReportGearbox___________!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox___________.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox___________:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox_______", ((_gearErrorCollectionViaComponentInspectionReportGearbox_______!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox_______.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox_______:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox________", ((_gearErrorCollectionViaComponentInspectionReportGearbox________!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox________.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox________:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox_____", ((_gearErrorCollectionViaComponentInspectionReportGearbox_____!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox_____.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox_____:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox______", ((_gearErrorCollectionViaComponentInspectionReportGearbox______!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox______.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox______:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox____________", ((_gearErrorCollectionViaComponentInspectionReportGearbox____________!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox____________.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox____________:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox_____________", ((_gearErrorCollectionViaComponentInspectionReportGearbox_____________!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox_____________.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox_____________:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox_________", ((_gearErrorCollectionViaComponentInspectionReportGearbox_________!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox_________.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox_________:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox__________", ((_gearErrorCollectionViaComponentInspectionReportGearbox__________!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox__________.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox__________:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox__", ((_gearErrorCollectionViaComponentInspectionReportGearbox__!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox__.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox__:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox____", ((_gearErrorCollectionViaComponentInspectionReportGearbox____!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox____.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox____:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox______________", ((_gearErrorCollectionViaComponentInspectionReportGearbox______________!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox______________.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox______________:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox", ((_gearErrorCollectionViaComponentInspectionReportGearbox!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox___", ((_gearErrorCollectionViaComponentInspectionReportGearbox___!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox___.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox___:null);
				info.AddValue("_gearErrorCollectionViaComponentInspectionReportGearbox_", ((_gearErrorCollectionViaComponentInspectionReportGearbox_!=null) && (_gearErrorCollectionViaComponentInspectionReportGearbox_.Count>0) && !this.MarkedForDeletion)?_gearErrorCollectionViaComponentInspectionReportGearbox_:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox_____", ((_gearTypeCollectionViaComponentInspectionReportGearbox_____!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox_____.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox_____:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox_________", ((_gearTypeCollectionViaComponentInspectionReportGearbox_________!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox_________.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox_________:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox__________", ((_gearTypeCollectionViaComponentInspectionReportGearbox__________!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox__________.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox__________:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox______________", ((_gearTypeCollectionViaComponentInspectionReportGearbox______________!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox______________.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox______________:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox____", ((_gearTypeCollectionViaComponentInspectionReportGearbox____!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox____.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox____:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox____________", ((_gearTypeCollectionViaComponentInspectionReportGearbox____________!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox____________.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox____________:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox_____________", ((_gearTypeCollectionViaComponentInspectionReportGearbox_____________!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox_____________.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox_____________:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox________", ((_gearTypeCollectionViaComponentInspectionReportGearbox________!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox________.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox________:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox_", ((_gearTypeCollectionViaComponentInspectionReportGearbox_!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox_.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox_:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox", ((_gearTypeCollectionViaComponentInspectionReportGearbox!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox___________", ((_gearTypeCollectionViaComponentInspectionReportGearbox___________!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox___________.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox___________:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox__", ((_gearTypeCollectionViaComponentInspectionReportGearbox__!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox__.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox__:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox_______", ((_gearTypeCollectionViaComponentInspectionReportGearbox_______!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox_______.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox_______:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox______", ((_gearTypeCollectionViaComponentInspectionReportGearbox______!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox______.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox______:null);
				info.AddValue("_gearTypeCollectionViaComponentInspectionReportGearbox___", ((_gearTypeCollectionViaComponentInspectionReportGearbox___!=null) && (_gearTypeCollectionViaComponentInspectionReportGearbox___.Count>0) && !this.MarkedForDeletion)?_gearTypeCollectionViaComponentInspectionReportGearbox___:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGearbox_", ((_generatorManufacturerCollectionViaComponentInspectionReportGearbox_!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGearbox_.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGearbox_:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGearbox", ((_generatorManufacturerCollectionViaComponentInspectionReportGearbox!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_housingErrorCollectionViaComponentInspectionReportGearbox___", ((_housingErrorCollectionViaComponentInspectionReportGearbox___!=null) && (_housingErrorCollectionViaComponentInspectionReportGearbox___.Count>0) && !this.MarkedForDeletion)?_housingErrorCollectionViaComponentInspectionReportGearbox___:null);
				info.AddValue("_housingErrorCollectionViaComponentInspectionReportGearbox__", ((_housingErrorCollectionViaComponentInspectionReportGearbox__!=null) && (_housingErrorCollectionViaComponentInspectionReportGearbox__.Count>0) && !this.MarkedForDeletion)?_housingErrorCollectionViaComponentInspectionReportGearbox__:null);
				info.AddValue("_housingErrorCollectionViaComponentInspectionReportGearbox_", ((_housingErrorCollectionViaComponentInspectionReportGearbox_!=null) && (_housingErrorCollectionViaComponentInspectionReportGearbox_.Count>0) && !this.MarkedForDeletion)?_housingErrorCollectionViaComponentInspectionReportGearbox_:null);
				info.AddValue("_housingErrorCollectionViaComponentInspectionReportGearbox____", ((_housingErrorCollectionViaComponentInspectionReportGearbox____!=null) && (_housingErrorCollectionViaComponentInspectionReportGearbox____.Count>0) && !this.MarkedForDeletion)?_housingErrorCollectionViaComponentInspectionReportGearbox____:null);
				info.AddValue("_housingErrorCollectionViaComponentInspectionReportGearbox", ((_housingErrorCollectionViaComponentInspectionReportGearbox!=null) && (_housingErrorCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_housingErrorCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_housingErrorCollectionViaComponentInspectionReportGearbox_____", ((_housingErrorCollectionViaComponentInspectionReportGearbox_____!=null) && (_housingErrorCollectionViaComponentInspectionReportGearbox_____.Count>0) && !this.MarkedForDeletion)?_housingErrorCollectionViaComponentInspectionReportGearbox_____:null);
				info.AddValue("_inlineFilterCollectionViaComponentInspectionReportGearbox", ((_inlineFilterCollectionViaComponentInspectionReportGearbox!=null) && (_inlineFilterCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_inlineFilterCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_magnetPosCollectionViaComponentInspectionReportGearbox", ((_magnetPosCollectionViaComponentInspectionReportGearbox!=null) && (_magnetPosCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_magnetPosCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox", ((_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox!=null) && (_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_oilLevelCollectionViaComponentInspectionReportGearbox", ((_oilLevelCollectionViaComponentInspectionReportGearbox!=null) && (_oilLevelCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_oilLevelCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_oilTypeCollectionViaComponentInspectionReportGearbox", ((_oilTypeCollectionViaComponentInspectionReportGearbox!=null) && (_oilTypeCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_oilTypeCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_overallGearboxConditionCollectionViaComponentInspectionReportGearbox", ((_overallGearboxConditionCollectionViaComponentInspectionReportGearbox!=null) && (_overallGearboxConditionCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_overallGearboxConditionCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_shaftErrorCollectionViaComponentInspectionReportGearbox__", ((_shaftErrorCollectionViaComponentInspectionReportGearbox__!=null) && (_shaftErrorCollectionViaComponentInspectionReportGearbox__.Count>0) && !this.MarkedForDeletion)?_shaftErrorCollectionViaComponentInspectionReportGearbox__:null);
				info.AddValue("_shaftErrorCollectionViaComponentInspectionReportGearbox___", ((_shaftErrorCollectionViaComponentInspectionReportGearbox___!=null) && (_shaftErrorCollectionViaComponentInspectionReportGearbox___.Count>0) && !this.MarkedForDeletion)?_shaftErrorCollectionViaComponentInspectionReportGearbox___:null);
				info.AddValue("_shaftErrorCollectionViaComponentInspectionReportGearbox", ((_shaftErrorCollectionViaComponentInspectionReportGearbox!=null) && (_shaftErrorCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_shaftErrorCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_shaftErrorCollectionViaComponentInspectionReportGearbox_", ((_shaftErrorCollectionViaComponentInspectionReportGearbox_!=null) && (_shaftErrorCollectionViaComponentInspectionReportGearbox_.Count>0) && !this.MarkedForDeletion)?_shaftErrorCollectionViaComponentInspectionReportGearbox_:null);
				info.AddValue("_shaftTypeCollectionViaComponentInspectionReportGearbox__", ((_shaftTypeCollectionViaComponentInspectionReportGearbox__!=null) && (_shaftTypeCollectionViaComponentInspectionReportGearbox__.Count>0) && !this.MarkedForDeletion)?_shaftTypeCollectionViaComponentInspectionReportGearbox__:null);
				info.AddValue("_shaftTypeCollectionViaComponentInspectionReportGearbox___", ((_shaftTypeCollectionViaComponentInspectionReportGearbox___!=null) && (_shaftTypeCollectionViaComponentInspectionReportGearbox___.Count>0) && !this.MarkedForDeletion)?_shaftTypeCollectionViaComponentInspectionReportGearbox___:null);
				info.AddValue("_shaftTypeCollectionViaComponentInspectionReportGearbox", ((_shaftTypeCollectionViaComponentInspectionReportGearbox!=null) && (_shaftTypeCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_shaftTypeCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_shaftTypeCollectionViaComponentInspectionReportGearbox_", ((_shaftTypeCollectionViaComponentInspectionReportGearbox_!=null) && (_shaftTypeCollectionViaComponentInspectionReportGearbox_.Count>0) && !this.MarkedForDeletion)?_shaftTypeCollectionViaComponentInspectionReportGearbox_:null);
				info.AddValue("_shrinkElementCollectionViaComponentInspectionReportGearbox", ((_shrinkElementCollectionViaComponentInspectionReportGearbox!=null) && (_shrinkElementCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_shrinkElementCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_vibrationsCollectionViaComponentInspectionReportGearbox", ((_vibrationsCollectionViaComponentInspectionReportGearbox!=null) && (_vibrationsCollectionViaComponentInspectionReportGearbox.Count>0) && !this.MarkedForDeletion)?_vibrationsCollectionViaComponentInspectionReportGearbox:null);
				info.AddValue("_noise", (!this.MarkedForDeletion?_noise:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(NoiseFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(NoiseFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new NoiseRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGearbox' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGearboxFields.GearboxNoiseId, null, ComparisonOperator.Equal, this.NoiseId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Noise' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNoise_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.ParentNoiseId, null, ComparisonOperator.Equal, this.NoiseId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingErrorCollectionViaComponentInspectionReportGearbox___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage4BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingErrorCollectionViaComponentInspectionReportGearbox____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage5BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingErrorCollectionViaComponentInspectionReportGearbox_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage6BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingErrorCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage1BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingErrorCollectionViaComponentInspectionReportGearbox_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage2BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingErrorCollectionViaComponentInspectionReportGearbox__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage3BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPosCollectionViaComponentInspectionReportGearbox____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition5BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPosCollectionViaComponentInspectionReportGearbox_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition6BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPosCollectionViaComponentInspectionReportGearbox___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition4BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPosCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition1BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPosCollectionViaComponentInspectionReportGearbox_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition2BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingPos' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingPosCollectionViaComponentInspectionReportGearbox__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition3BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingTypeCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation1BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingTypeCollectionViaComponentInspectionReportGearbox_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation6BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingTypeCollectionViaComponentInspectionReportGearbox____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation5BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingTypeCollectionViaComponentInspectionReportGearbox___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation4BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingTypeCollectionViaComponentInspectionReportGearbox__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation3BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BearingType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBearingTypeCollectionViaComponentInspectionReportGearbox_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation2BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGearbox_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BooleanAnswerEntityUsingGearboxClaimRelevantBooleanAnswerId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.BooleanAnswerEntityUsingGearboxOffLineFilterId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupling' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouplingCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.CouplingEntityUsingGearboxCouplingId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision1DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox_____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision2DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox__________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision14DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox___________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision15DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox_______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision4DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision5DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox_________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision6DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision3DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision4DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision3DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision5DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision6DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision12DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox_________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision13DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision10DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision11DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox__________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision7DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision1DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision2DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox___________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision8DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DamageDecision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDamageDecisionCollectionViaComponentInspectionReportGearbox____________________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision9DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DebrisGearbox' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDebrisGearboxCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DebrisGearboxEntityUsingGearboxDebrisGearBoxId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'DebrisOnMagnet' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoDebrisOnMagnetCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.DebrisOnMagnetEntityUsingGearboxDebrisOnMagnetId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ElectricalPump' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoElectricalPumpCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.ElectricalPumpEntityUsingGearboxElectricalPumpId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'FilterBlockType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoFilterBlockTypeCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.FilterBlockTypeEntityUsingGearboxFilterBlockTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearboxManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxManufacturerCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearboxManufacturerEntityUsingGearboxManufacturerId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearboxRevision' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxRevisionCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearboxRevisionEntityUsingGearboxRevisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearboxType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearboxTypeCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearboxTypeEntityUsingGearboxTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox___________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage6GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage12GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage13GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage10GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage11GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage7GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox_____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage8GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox_________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage14GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox__________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage15GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage3GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage5GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage9GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage1GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage4GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearErrorCollectionViaComponentInspectionReportGearbox_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage2GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation6GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox_________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation13GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox__________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation14GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox______________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation9GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation5GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation7GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox_____________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation8GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation12GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation2GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation1GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox___________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation15GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation3GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation11GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation10GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GearType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGearTypeCollectionViaComponentInspectionReportGearbox___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation4GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGearbox_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId2, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HousingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingErrorCollectionViaComponentInspectionReportGearbox___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxFrontPlateHousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HousingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingErrorCollectionViaComponentInspectionReportGearbox__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxHelicalStageHousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HousingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingErrorCollectionViaComponentInspectionReportGearbox_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxPlanetStage2HousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HousingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingErrorCollectionViaComponentInspectionReportGearbox____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxAuxStageHousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HousingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingErrorCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxPlanetStage1HousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'HousingError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoHousingErrorCollectionViaComponentInspectionReportGearbox_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxHsstageHousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'InlineFilter' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoInlineFilterCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.InlineFilterEntityUsingGearboxInLineFilterId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MagnetPos' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMagnetPosCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.MagnetPosEntityUsingGearboxDebrisStagesMagnetPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'MechanicalOilPump' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoMechanicalOilPumpCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.MechanicalOilPumpEntityUsingGearboxMechanicalOilPumpId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OilLevel' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOilLevelCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.OilLevelEntityUsingGearboxOilLevelId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OilType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOilTypeCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.OilTypeEntityUsingGearboxOilTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OverallGearboxCondition' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOverallGearboxConditionCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.OverallGearboxConditionEntityUsingGearboxOverallGearboxConditionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShaftError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftErrorCollectionViaComponentInspectionReportGearbox__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage3ShaftErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShaftError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftErrorCollectionViaComponentInspectionReportGearbox___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage4ShaftErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShaftError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftErrorCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage1ShaftErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShaftError' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftErrorCollectionViaComponentInspectionReportGearbox_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage2ShaftErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShaftType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftTypeCollectionViaComponentInspectionReportGearbox__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation3ShaftTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShaftType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftTypeCollectionViaComponentInspectionReportGearbox___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation4ShaftTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShaftType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftTypeCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation1ShaftTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShaftType' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShaftTypeCollectionViaComponentInspectionReportGearbox_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation2ShaftTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ShrinkElement' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoShrinkElementCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShrinkElementEntityUsingGearboxShrinkElementId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Vibrations' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoVibrationsCollectionViaComponentInspectionReportGearbox()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGearboxEntity.Relations.VibrationsEntityUsingGearboxVibrationsId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.NoiseId, "NoiseEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Noise' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoNoise()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(NoiseFields.NoiseId, null, ComparisonOperator.Equal, this.ParentNoiseId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.NoiseEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(NoiseEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._noise_);
			collectionsQueue.Enqueue(this._bearingErrorCollectionViaComponentInspectionReportGearbox___);
			collectionsQueue.Enqueue(this._bearingErrorCollectionViaComponentInspectionReportGearbox____);
			collectionsQueue.Enqueue(this._bearingErrorCollectionViaComponentInspectionReportGearbox_____);
			collectionsQueue.Enqueue(this._bearingErrorCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._bearingErrorCollectionViaComponentInspectionReportGearbox_);
			collectionsQueue.Enqueue(this._bearingErrorCollectionViaComponentInspectionReportGearbox__);
			collectionsQueue.Enqueue(this._bearingPosCollectionViaComponentInspectionReportGearbox____);
			collectionsQueue.Enqueue(this._bearingPosCollectionViaComponentInspectionReportGearbox_____);
			collectionsQueue.Enqueue(this._bearingPosCollectionViaComponentInspectionReportGearbox___);
			collectionsQueue.Enqueue(this._bearingPosCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._bearingPosCollectionViaComponentInspectionReportGearbox_);
			collectionsQueue.Enqueue(this._bearingPosCollectionViaComponentInspectionReportGearbox__);
			collectionsQueue.Enqueue(this._bearingTypeCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._bearingTypeCollectionViaComponentInspectionReportGearbox_____);
			collectionsQueue.Enqueue(this._bearingTypeCollectionViaComponentInspectionReportGearbox____);
			collectionsQueue.Enqueue(this._bearingTypeCollectionViaComponentInspectionReportGearbox___);
			collectionsQueue.Enqueue(this._bearingTypeCollectionViaComponentInspectionReportGearbox__);
			collectionsQueue.Enqueue(this._bearingTypeCollectionViaComponentInspectionReportGearbox_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGearbox_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._couplingCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox____________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox_____________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox__________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox___________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox_______________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox________________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox_________________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox______________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox___);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox__);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox____);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox_____);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox_________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox______);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox_______);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox__________________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox_);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox___________________);
			collectionsQueue.Enqueue(this._damageDecisionCollectionViaComponentInspectionReportGearbox____________________);
			collectionsQueue.Enqueue(this._debrisGearboxCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._debrisOnMagnetCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._electricalPumpCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._filterBlockTypeCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._gearboxManufacturerCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._gearboxRevisionCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._gearboxTypeCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox___________);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox_______);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox________);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox_____);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox______);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox____________);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox_____________);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox_________);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox__________);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox__);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox____);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox______________);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox___);
			collectionsQueue.Enqueue(this._gearErrorCollectionViaComponentInspectionReportGearbox_);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox_____);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox_________);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox__________);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox______________);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox____);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox____________);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox_____________);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox________);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox_);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox___________);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox__);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox_______);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox______);
			collectionsQueue.Enqueue(this._gearTypeCollectionViaComponentInspectionReportGearbox___);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGearbox_);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._housingErrorCollectionViaComponentInspectionReportGearbox___);
			collectionsQueue.Enqueue(this._housingErrorCollectionViaComponentInspectionReportGearbox__);
			collectionsQueue.Enqueue(this._housingErrorCollectionViaComponentInspectionReportGearbox_);
			collectionsQueue.Enqueue(this._housingErrorCollectionViaComponentInspectionReportGearbox____);
			collectionsQueue.Enqueue(this._housingErrorCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._housingErrorCollectionViaComponentInspectionReportGearbox_____);
			collectionsQueue.Enqueue(this._inlineFilterCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._magnetPosCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._mechanicalOilPumpCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._oilLevelCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._oilTypeCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._overallGearboxConditionCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._shaftErrorCollectionViaComponentInspectionReportGearbox__);
			collectionsQueue.Enqueue(this._shaftErrorCollectionViaComponentInspectionReportGearbox___);
			collectionsQueue.Enqueue(this._shaftErrorCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._shaftErrorCollectionViaComponentInspectionReportGearbox_);
			collectionsQueue.Enqueue(this._shaftTypeCollectionViaComponentInspectionReportGearbox__);
			collectionsQueue.Enqueue(this._shaftTypeCollectionViaComponentInspectionReportGearbox___);
			collectionsQueue.Enqueue(this._shaftTypeCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._shaftTypeCollectionViaComponentInspectionReportGearbox_);
			collectionsQueue.Enqueue(this._shrinkElementCollectionViaComponentInspectionReportGearbox);
			collectionsQueue.Enqueue(this._vibrationsCollectionViaComponentInspectionReportGearbox);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReportGearbox = (EntityCollection<ComponentInspectionReportGearboxEntity>) collectionsQueue.Dequeue();
			this._noise_ = (EntityCollection<NoiseEntity>) collectionsQueue.Dequeue();
			this._bearingErrorCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<BearingErrorEntity>) collectionsQueue.Dequeue();
			this._bearingErrorCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<BearingErrorEntity>) collectionsQueue.Dequeue();
			this._bearingErrorCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<BearingErrorEntity>) collectionsQueue.Dequeue();
			this._bearingErrorCollectionViaComponentInspectionReportGearbox = (EntityCollection<BearingErrorEntity>) collectionsQueue.Dequeue();
			this._bearingErrorCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<BearingErrorEntity>) collectionsQueue.Dequeue();
			this._bearingErrorCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<BearingErrorEntity>) collectionsQueue.Dequeue();
			this._bearingPosCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<BearingPosEntity>) collectionsQueue.Dequeue();
			this._bearingPosCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<BearingPosEntity>) collectionsQueue.Dequeue();
			this._bearingPosCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<BearingPosEntity>) collectionsQueue.Dequeue();
			this._bearingPosCollectionViaComponentInspectionReportGearbox = (EntityCollection<BearingPosEntity>) collectionsQueue.Dequeue();
			this._bearingPosCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<BearingPosEntity>) collectionsQueue.Dequeue();
			this._bearingPosCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<BearingPosEntity>) collectionsQueue.Dequeue();
			this._bearingTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<BearingTypeEntity>) collectionsQueue.Dequeue();
			this._bearingTypeCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<BearingTypeEntity>) collectionsQueue.Dequeue();
			this._bearingTypeCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<BearingTypeEntity>) collectionsQueue.Dequeue();
			this._bearingTypeCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<BearingTypeEntity>) collectionsQueue.Dequeue();
			this._bearingTypeCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<BearingTypeEntity>) collectionsQueue.Dequeue();
			this._bearingTypeCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<BearingTypeEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGearbox = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGearbox = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._couplingCollectionViaComponentInspectionReportGearbox = (EntityCollection<CouplingEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox____________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox_____________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox__________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox___________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox_______________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox________________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox_________________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox______________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox_________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox______ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox_______ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox__________________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox___________________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._damageDecisionCollectionViaComponentInspectionReportGearbox____________________ = (EntityCollection<DamageDecisionEntity>) collectionsQueue.Dequeue();
			this._debrisGearboxCollectionViaComponentInspectionReportGearbox = (EntityCollection<DebrisGearboxEntity>) collectionsQueue.Dequeue();
			this._debrisOnMagnetCollectionViaComponentInspectionReportGearbox = (EntityCollection<DebrisOnMagnetEntity>) collectionsQueue.Dequeue();
			this._electricalPumpCollectionViaComponentInspectionReportGearbox = (EntityCollection<ElectricalPumpEntity>) collectionsQueue.Dequeue();
			this._filterBlockTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<FilterBlockTypeEntity>) collectionsQueue.Dequeue();
			this._gearboxManufacturerCollectionViaComponentInspectionReportGearbox = (EntityCollection<GearboxManufacturerEntity>) collectionsQueue.Dequeue();
			this._gearboxRevisionCollectionViaComponentInspectionReportGearbox = (EntityCollection<GearboxRevisionEntity>) collectionsQueue.Dequeue();
			this._gearboxTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<GearboxTypeEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox___________ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox_______ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox________ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox______ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox____________ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox_____________ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox_________ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox__________ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox______________ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearErrorCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<GearErrorEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox_________ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox__________ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox______________ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox____________ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox_____________ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox________ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox___________ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox_______ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox______ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._gearTypeCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<GearTypeEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGearbox = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._housingErrorCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<HousingErrorEntity>) collectionsQueue.Dequeue();
			this._housingErrorCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<HousingErrorEntity>) collectionsQueue.Dequeue();
			this._housingErrorCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<HousingErrorEntity>) collectionsQueue.Dequeue();
			this._housingErrorCollectionViaComponentInspectionReportGearbox____ = (EntityCollection<HousingErrorEntity>) collectionsQueue.Dequeue();
			this._housingErrorCollectionViaComponentInspectionReportGearbox = (EntityCollection<HousingErrorEntity>) collectionsQueue.Dequeue();
			this._housingErrorCollectionViaComponentInspectionReportGearbox_____ = (EntityCollection<HousingErrorEntity>) collectionsQueue.Dequeue();
			this._inlineFilterCollectionViaComponentInspectionReportGearbox = (EntityCollection<InlineFilterEntity>) collectionsQueue.Dequeue();
			this._magnetPosCollectionViaComponentInspectionReportGearbox = (EntityCollection<MagnetPosEntity>) collectionsQueue.Dequeue();
			this._mechanicalOilPumpCollectionViaComponentInspectionReportGearbox = (EntityCollection<MechanicalOilPumpEntity>) collectionsQueue.Dequeue();
			this._oilLevelCollectionViaComponentInspectionReportGearbox = (EntityCollection<OilLevelEntity>) collectionsQueue.Dequeue();
			this._oilTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<OilTypeEntity>) collectionsQueue.Dequeue();
			this._overallGearboxConditionCollectionViaComponentInspectionReportGearbox = (EntityCollection<OverallGearboxConditionEntity>) collectionsQueue.Dequeue();
			this._shaftErrorCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<ShaftErrorEntity>) collectionsQueue.Dequeue();
			this._shaftErrorCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<ShaftErrorEntity>) collectionsQueue.Dequeue();
			this._shaftErrorCollectionViaComponentInspectionReportGearbox = (EntityCollection<ShaftErrorEntity>) collectionsQueue.Dequeue();
			this._shaftErrorCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<ShaftErrorEntity>) collectionsQueue.Dequeue();
			this._shaftTypeCollectionViaComponentInspectionReportGearbox__ = (EntityCollection<ShaftTypeEntity>) collectionsQueue.Dequeue();
			this._shaftTypeCollectionViaComponentInspectionReportGearbox___ = (EntityCollection<ShaftTypeEntity>) collectionsQueue.Dequeue();
			this._shaftTypeCollectionViaComponentInspectionReportGearbox = (EntityCollection<ShaftTypeEntity>) collectionsQueue.Dequeue();
			this._shaftTypeCollectionViaComponentInspectionReportGearbox_ = (EntityCollection<ShaftTypeEntity>) collectionsQueue.Dequeue();
			this._shrinkElementCollectionViaComponentInspectionReportGearbox = (EntityCollection<ShrinkElementEntity>) collectionsQueue.Dequeue();
			this._vibrationsCollectionViaComponentInspectionReportGearbox = (EntityCollection<VibrationsEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._noise_ != null)
			{
				return true;
			}
			if (this._bearingErrorCollectionViaComponentInspectionReportGearbox___ != null)
			{
				return true;
			}
			if (this._bearingErrorCollectionViaComponentInspectionReportGearbox____ != null)
			{
				return true;
			}
			if (this._bearingErrorCollectionViaComponentInspectionReportGearbox_____ != null)
			{
				return true;
			}
			if (this._bearingErrorCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._bearingErrorCollectionViaComponentInspectionReportGearbox_ != null)
			{
				return true;
			}
			if (this._bearingErrorCollectionViaComponentInspectionReportGearbox__ != null)
			{
				return true;
			}
			if (this._bearingPosCollectionViaComponentInspectionReportGearbox____ != null)
			{
				return true;
			}
			if (this._bearingPosCollectionViaComponentInspectionReportGearbox_____ != null)
			{
				return true;
			}
			if (this._bearingPosCollectionViaComponentInspectionReportGearbox___ != null)
			{
				return true;
			}
			if (this._bearingPosCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._bearingPosCollectionViaComponentInspectionReportGearbox_ != null)
			{
				return true;
			}
			if (this._bearingPosCollectionViaComponentInspectionReportGearbox__ != null)
			{
				return true;
			}
			if (this._bearingTypeCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._bearingTypeCollectionViaComponentInspectionReportGearbox_____ != null)
			{
				return true;
			}
			if (this._bearingTypeCollectionViaComponentInspectionReportGearbox____ != null)
			{
				return true;
			}
			if (this._bearingTypeCollectionViaComponentInspectionReportGearbox___ != null)
			{
				return true;
			}
			if (this._bearingTypeCollectionViaComponentInspectionReportGearbox__ != null)
			{
				return true;
			}
			if (this._bearingTypeCollectionViaComponentInspectionReportGearbox_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGearbox_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._couplingCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox____________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox_____________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox__________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox___________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox_______________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox________________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox_________________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox______________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox___ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox__ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox____ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox_____ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox_________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox______ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox_______ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox__________________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox_ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox___________________ != null)
			{
				return true;
			}
			if (this._damageDecisionCollectionViaComponentInspectionReportGearbox____________________ != null)
			{
				return true;
			}
			if (this._debrisGearboxCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._debrisOnMagnetCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._electricalPumpCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._filterBlockTypeCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._gearboxManufacturerCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._gearboxRevisionCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._gearboxTypeCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox___________ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox_______ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox________ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox_____ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox______ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox____________ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox_____________ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox_________ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox__________ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox__ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox____ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox______________ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox___ != null)
			{
				return true;
			}
			if (this._gearErrorCollectionViaComponentInspectionReportGearbox_ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox_____ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox_________ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox__________ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox______________ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox____ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox____________ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox_____________ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox________ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox_ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox___________ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox__ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox_______ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox______ != null)
			{
				return true;
			}
			if (this._gearTypeCollectionViaComponentInspectionReportGearbox___ != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGearbox_ != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._housingErrorCollectionViaComponentInspectionReportGearbox___ != null)
			{
				return true;
			}
			if (this._housingErrorCollectionViaComponentInspectionReportGearbox__ != null)
			{
				return true;
			}
			if (this._housingErrorCollectionViaComponentInspectionReportGearbox_ != null)
			{
				return true;
			}
			if (this._housingErrorCollectionViaComponentInspectionReportGearbox____ != null)
			{
				return true;
			}
			if (this._housingErrorCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._housingErrorCollectionViaComponentInspectionReportGearbox_____ != null)
			{
				return true;
			}
			if (this._inlineFilterCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._magnetPosCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._mechanicalOilPumpCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._oilLevelCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._oilTypeCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._overallGearboxConditionCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._shaftErrorCollectionViaComponentInspectionReportGearbox__ != null)
			{
				return true;
			}
			if (this._shaftErrorCollectionViaComponentInspectionReportGearbox___ != null)
			{
				return true;
			}
			if (this._shaftErrorCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._shaftErrorCollectionViaComponentInspectionReportGearbox_ != null)
			{
				return true;
			}
			if (this._shaftTypeCollectionViaComponentInspectionReportGearbox__ != null)
			{
				return true;
			}
			if (this._shaftTypeCollectionViaComponentInspectionReportGearbox___ != null)
			{
				return true;
			}
			if (this._shaftTypeCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._shaftTypeCollectionViaComponentInspectionReportGearbox_ != null)
			{
				return true;
			}
			if (this._shrinkElementCollectionViaComponentInspectionReportGearbox != null)
			{
				return true;
			}
			if (this._vibrationsCollectionViaComponentInspectionReportGearbox != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGearboxEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGearboxEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<NoiseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoiseEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DebrisGearboxEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DebrisGearboxEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<DebrisOnMagnetEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DebrisOnMagnetEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ElectricalPumpEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ElectricalPumpEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<FilterBlockTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FilterBlockTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearboxManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearboxRevisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxRevisionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearboxTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<InlineFilterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InlineFilterEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MagnetPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MagnetPosEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<MechanicalOilPumpEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MechanicalOilPumpEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OilLevelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OilLevelEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OilTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OilTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OverallGearboxConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OverallGearboxConditionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ShrinkElementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShrinkElementEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<VibrationsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(VibrationsEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("Noise", _noise);
			toReturn.Add("ComponentInspectionReportGearbox", _componentInspectionReportGearbox);
			toReturn.Add("Noise_", _noise_);
			toReturn.Add("BearingErrorCollectionViaComponentInspectionReportGearbox___", _bearingErrorCollectionViaComponentInspectionReportGearbox___);
			toReturn.Add("BearingErrorCollectionViaComponentInspectionReportGearbox____", _bearingErrorCollectionViaComponentInspectionReportGearbox____);
			toReturn.Add("BearingErrorCollectionViaComponentInspectionReportGearbox_____", _bearingErrorCollectionViaComponentInspectionReportGearbox_____);
			toReturn.Add("BearingErrorCollectionViaComponentInspectionReportGearbox", _bearingErrorCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("BearingErrorCollectionViaComponentInspectionReportGearbox_", _bearingErrorCollectionViaComponentInspectionReportGearbox_);
			toReturn.Add("BearingErrorCollectionViaComponentInspectionReportGearbox__", _bearingErrorCollectionViaComponentInspectionReportGearbox__);
			toReturn.Add("BearingPosCollectionViaComponentInspectionReportGearbox____", _bearingPosCollectionViaComponentInspectionReportGearbox____);
			toReturn.Add("BearingPosCollectionViaComponentInspectionReportGearbox_____", _bearingPosCollectionViaComponentInspectionReportGearbox_____);
			toReturn.Add("BearingPosCollectionViaComponentInspectionReportGearbox___", _bearingPosCollectionViaComponentInspectionReportGearbox___);
			toReturn.Add("BearingPosCollectionViaComponentInspectionReportGearbox", _bearingPosCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("BearingPosCollectionViaComponentInspectionReportGearbox_", _bearingPosCollectionViaComponentInspectionReportGearbox_);
			toReturn.Add("BearingPosCollectionViaComponentInspectionReportGearbox__", _bearingPosCollectionViaComponentInspectionReportGearbox__);
			toReturn.Add("BearingTypeCollectionViaComponentInspectionReportGearbox", _bearingTypeCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("BearingTypeCollectionViaComponentInspectionReportGearbox_____", _bearingTypeCollectionViaComponentInspectionReportGearbox_____);
			toReturn.Add("BearingTypeCollectionViaComponentInspectionReportGearbox____", _bearingTypeCollectionViaComponentInspectionReportGearbox____);
			toReturn.Add("BearingTypeCollectionViaComponentInspectionReportGearbox___", _bearingTypeCollectionViaComponentInspectionReportGearbox___);
			toReturn.Add("BearingTypeCollectionViaComponentInspectionReportGearbox__", _bearingTypeCollectionViaComponentInspectionReportGearbox__);
			toReturn.Add("BearingTypeCollectionViaComponentInspectionReportGearbox_", _bearingTypeCollectionViaComponentInspectionReportGearbox_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGearbox_", _booleanAnswerCollectionViaComponentInspectionReportGearbox_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGearbox", _booleanAnswerCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGearbox", _componentInspectionReportCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("CouplingCollectionViaComponentInspectionReportGearbox", _couplingCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox____________", _damageDecisionCollectionViaComponentInspectionReportGearbox____________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox_____________", _damageDecisionCollectionViaComponentInspectionReportGearbox_____________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox__________", _damageDecisionCollectionViaComponentInspectionReportGearbox__________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox___________", _damageDecisionCollectionViaComponentInspectionReportGearbox___________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox_______________", _damageDecisionCollectionViaComponentInspectionReportGearbox_______________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox________________", _damageDecisionCollectionViaComponentInspectionReportGearbox________________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox_________________", _damageDecisionCollectionViaComponentInspectionReportGearbox_________________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox______________", _damageDecisionCollectionViaComponentInspectionReportGearbox______________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox___", _damageDecisionCollectionViaComponentInspectionReportGearbox___);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox__", _damageDecisionCollectionViaComponentInspectionReportGearbox__);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox____", _damageDecisionCollectionViaComponentInspectionReportGearbox____);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox_____", _damageDecisionCollectionViaComponentInspectionReportGearbox_____);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox________", _damageDecisionCollectionViaComponentInspectionReportGearbox________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox_________", _damageDecisionCollectionViaComponentInspectionReportGearbox_________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox______", _damageDecisionCollectionViaComponentInspectionReportGearbox______);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox_______", _damageDecisionCollectionViaComponentInspectionReportGearbox_______);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox__________________", _damageDecisionCollectionViaComponentInspectionReportGearbox__________________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox_", _damageDecisionCollectionViaComponentInspectionReportGearbox_);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox", _damageDecisionCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox___________________", _damageDecisionCollectionViaComponentInspectionReportGearbox___________________);
			toReturn.Add("DamageDecisionCollectionViaComponentInspectionReportGearbox____________________", _damageDecisionCollectionViaComponentInspectionReportGearbox____________________);
			toReturn.Add("DebrisGearboxCollectionViaComponentInspectionReportGearbox", _debrisGearboxCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("DebrisOnMagnetCollectionViaComponentInspectionReportGearbox", _debrisOnMagnetCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("ElectricalPumpCollectionViaComponentInspectionReportGearbox", _electricalPumpCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("FilterBlockTypeCollectionViaComponentInspectionReportGearbox", _filterBlockTypeCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("GearboxManufacturerCollectionViaComponentInspectionReportGearbox", _gearboxManufacturerCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("GearboxRevisionCollectionViaComponentInspectionReportGearbox", _gearboxRevisionCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("GearboxTypeCollectionViaComponentInspectionReportGearbox", _gearboxTypeCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox___________", _gearErrorCollectionViaComponentInspectionReportGearbox___________);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox_______", _gearErrorCollectionViaComponentInspectionReportGearbox_______);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox________", _gearErrorCollectionViaComponentInspectionReportGearbox________);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox_____", _gearErrorCollectionViaComponentInspectionReportGearbox_____);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox______", _gearErrorCollectionViaComponentInspectionReportGearbox______);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox____________", _gearErrorCollectionViaComponentInspectionReportGearbox____________);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox_____________", _gearErrorCollectionViaComponentInspectionReportGearbox_____________);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox_________", _gearErrorCollectionViaComponentInspectionReportGearbox_________);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox__________", _gearErrorCollectionViaComponentInspectionReportGearbox__________);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox__", _gearErrorCollectionViaComponentInspectionReportGearbox__);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox____", _gearErrorCollectionViaComponentInspectionReportGearbox____);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox______________", _gearErrorCollectionViaComponentInspectionReportGearbox______________);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox", _gearErrorCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox___", _gearErrorCollectionViaComponentInspectionReportGearbox___);
			toReturn.Add("GearErrorCollectionViaComponentInspectionReportGearbox_", _gearErrorCollectionViaComponentInspectionReportGearbox_);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox_____", _gearTypeCollectionViaComponentInspectionReportGearbox_____);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox_________", _gearTypeCollectionViaComponentInspectionReportGearbox_________);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox__________", _gearTypeCollectionViaComponentInspectionReportGearbox__________);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox______________", _gearTypeCollectionViaComponentInspectionReportGearbox______________);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox____", _gearTypeCollectionViaComponentInspectionReportGearbox____);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox____________", _gearTypeCollectionViaComponentInspectionReportGearbox____________);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox_____________", _gearTypeCollectionViaComponentInspectionReportGearbox_____________);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox________", _gearTypeCollectionViaComponentInspectionReportGearbox________);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox_", _gearTypeCollectionViaComponentInspectionReportGearbox_);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox", _gearTypeCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox___________", _gearTypeCollectionViaComponentInspectionReportGearbox___________);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox__", _gearTypeCollectionViaComponentInspectionReportGearbox__);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox_______", _gearTypeCollectionViaComponentInspectionReportGearbox_______);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox______", _gearTypeCollectionViaComponentInspectionReportGearbox______);
			toReturn.Add("GearTypeCollectionViaComponentInspectionReportGearbox___", _gearTypeCollectionViaComponentInspectionReportGearbox___);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGearbox_", _generatorManufacturerCollectionViaComponentInspectionReportGearbox_);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGearbox", _generatorManufacturerCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("HousingErrorCollectionViaComponentInspectionReportGearbox___", _housingErrorCollectionViaComponentInspectionReportGearbox___);
			toReturn.Add("HousingErrorCollectionViaComponentInspectionReportGearbox__", _housingErrorCollectionViaComponentInspectionReportGearbox__);
			toReturn.Add("HousingErrorCollectionViaComponentInspectionReportGearbox_", _housingErrorCollectionViaComponentInspectionReportGearbox_);
			toReturn.Add("HousingErrorCollectionViaComponentInspectionReportGearbox____", _housingErrorCollectionViaComponentInspectionReportGearbox____);
			toReturn.Add("HousingErrorCollectionViaComponentInspectionReportGearbox", _housingErrorCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("HousingErrorCollectionViaComponentInspectionReportGearbox_____", _housingErrorCollectionViaComponentInspectionReportGearbox_____);
			toReturn.Add("InlineFilterCollectionViaComponentInspectionReportGearbox", _inlineFilterCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("MagnetPosCollectionViaComponentInspectionReportGearbox", _magnetPosCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("MechanicalOilPumpCollectionViaComponentInspectionReportGearbox", _mechanicalOilPumpCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("OilLevelCollectionViaComponentInspectionReportGearbox", _oilLevelCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("OilTypeCollectionViaComponentInspectionReportGearbox", _oilTypeCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("OverallGearboxConditionCollectionViaComponentInspectionReportGearbox", _overallGearboxConditionCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("ShaftErrorCollectionViaComponentInspectionReportGearbox__", _shaftErrorCollectionViaComponentInspectionReportGearbox__);
			toReturn.Add("ShaftErrorCollectionViaComponentInspectionReportGearbox___", _shaftErrorCollectionViaComponentInspectionReportGearbox___);
			toReturn.Add("ShaftErrorCollectionViaComponentInspectionReportGearbox", _shaftErrorCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("ShaftErrorCollectionViaComponentInspectionReportGearbox_", _shaftErrorCollectionViaComponentInspectionReportGearbox_);
			toReturn.Add("ShaftTypeCollectionViaComponentInspectionReportGearbox__", _shaftTypeCollectionViaComponentInspectionReportGearbox__);
			toReturn.Add("ShaftTypeCollectionViaComponentInspectionReportGearbox___", _shaftTypeCollectionViaComponentInspectionReportGearbox___);
			toReturn.Add("ShaftTypeCollectionViaComponentInspectionReportGearbox", _shaftTypeCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("ShaftTypeCollectionViaComponentInspectionReportGearbox_", _shaftTypeCollectionViaComponentInspectionReportGearbox_);
			toReturn.Add("ShrinkElementCollectionViaComponentInspectionReportGearbox", _shrinkElementCollectionViaComponentInspectionReportGearbox);
			toReturn.Add("VibrationsCollectionViaComponentInspectionReportGearbox", _vibrationsCollectionViaComponentInspectionReportGearbox);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReportGearbox!=null)
			{
				_componentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_noise_!=null)
			{
				_noise_.ActiveContext = base.ActiveContext;
			}
			if(_bearingErrorCollectionViaComponentInspectionReportGearbox___!=null)
			{
				_bearingErrorCollectionViaComponentInspectionReportGearbox___.ActiveContext = base.ActiveContext;
			}
			if(_bearingErrorCollectionViaComponentInspectionReportGearbox____!=null)
			{
				_bearingErrorCollectionViaComponentInspectionReportGearbox____.ActiveContext = base.ActiveContext;
			}
			if(_bearingErrorCollectionViaComponentInspectionReportGearbox_____!=null)
			{
				_bearingErrorCollectionViaComponentInspectionReportGearbox_____.ActiveContext = base.ActiveContext;
			}
			if(_bearingErrorCollectionViaComponentInspectionReportGearbox!=null)
			{
				_bearingErrorCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_bearingErrorCollectionViaComponentInspectionReportGearbox_!=null)
			{
				_bearingErrorCollectionViaComponentInspectionReportGearbox_.ActiveContext = base.ActiveContext;
			}
			if(_bearingErrorCollectionViaComponentInspectionReportGearbox__!=null)
			{
				_bearingErrorCollectionViaComponentInspectionReportGearbox__.ActiveContext = base.ActiveContext;
			}
			if(_bearingPosCollectionViaComponentInspectionReportGearbox____!=null)
			{
				_bearingPosCollectionViaComponentInspectionReportGearbox____.ActiveContext = base.ActiveContext;
			}
			if(_bearingPosCollectionViaComponentInspectionReportGearbox_____!=null)
			{
				_bearingPosCollectionViaComponentInspectionReportGearbox_____.ActiveContext = base.ActiveContext;
			}
			if(_bearingPosCollectionViaComponentInspectionReportGearbox___!=null)
			{
				_bearingPosCollectionViaComponentInspectionReportGearbox___.ActiveContext = base.ActiveContext;
			}
			if(_bearingPosCollectionViaComponentInspectionReportGearbox!=null)
			{
				_bearingPosCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_bearingPosCollectionViaComponentInspectionReportGearbox_!=null)
			{
				_bearingPosCollectionViaComponentInspectionReportGearbox_.ActiveContext = base.ActiveContext;
			}
			if(_bearingPosCollectionViaComponentInspectionReportGearbox__!=null)
			{
				_bearingPosCollectionViaComponentInspectionReportGearbox__.ActiveContext = base.ActiveContext;
			}
			if(_bearingTypeCollectionViaComponentInspectionReportGearbox!=null)
			{
				_bearingTypeCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_bearingTypeCollectionViaComponentInspectionReportGearbox_____!=null)
			{
				_bearingTypeCollectionViaComponentInspectionReportGearbox_____.ActiveContext = base.ActiveContext;
			}
			if(_bearingTypeCollectionViaComponentInspectionReportGearbox____!=null)
			{
				_bearingTypeCollectionViaComponentInspectionReportGearbox____.ActiveContext = base.ActiveContext;
			}
			if(_bearingTypeCollectionViaComponentInspectionReportGearbox___!=null)
			{
				_bearingTypeCollectionViaComponentInspectionReportGearbox___.ActiveContext = base.ActiveContext;
			}
			if(_bearingTypeCollectionViaComponentInspectionReportGearbox__!=null)
			{
				_bearingTypeCollectionViaComponentInspectionReportGearbox__.ActiveContext = base.ActiveContext;
			}
			if(_bearingTypeCollectionViaComponentInspectionReportGearbox_!=null)
			{
				_bearingTypeCollectionViaComponentInspectionReportGearbox_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGearbox_!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGearbox_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGearbox!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGearbox!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_couplingCollectionViaComponentInspectionReportGearbox!=null)
			{
				_couplingCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox____________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox____________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox_____________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox_____________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox__________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox__________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox___________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox___________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox_______________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox_______________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox________________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox________________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox_________________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox_________________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox______________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox______________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox___!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox___.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox__!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox__.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox____!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox____.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox_____!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox_____.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox_________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox_________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox______!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox______.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox_______!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox_______.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox__________________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox__________________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox_!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox_.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox___________________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox___________________.ActiveContext = base.ActiveContext;
			}
			if(_damageDecisionCollectionViaComponentInspectionReportGearbox____________________!=null)
			{
				_damageDecisionCollectionViaComponentInspectionReportGearbox____________________.ActiveContext = base.ActiveContext;
			}
			if(_debrisGearboxCollectionViaComponentInspectionReportGearbox!=null)
			{
				_debrisGearboxCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_debrisOnMagnetCollectionViaComponentInspectionReportGearbox!=null)
			{
				_debrisOnMagnetCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_electricalPumpCollectionViaComponentInspectionReportGearbox!=null)
			{
				_electricalPumpCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_filterBlockTypeCollectionViaComponentInspectionReportGearbox!=null)
			{
				_filterBlockTypeCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_gearboxManufacturerCollectionViaComponentInspectionReportGearbox!=null)
			{
				_gearboxManufacturerCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_gearboxRevisionCollectionViaComponentInspectionReportGearbox!=null)
			{
				_gearboxRevisionCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_gearboxTypeCollectionViaComponentInspectionReportGearbox!=null)
			{
				_gearboxTypeCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox___________!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox___________.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox_______!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox_______.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox________!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox________.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox_____!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox_____.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox______!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox______.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox____________!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox____________.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox_____________!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox_____________.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox_________!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox_________.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox__________!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox__________.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox__!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox__.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox____!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox____.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox______________!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox______________.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox___!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox___.ActiveContext = base.ActiveContext;
			}
			if(_gearErrorCollectionViaComponentInspectionReportGearbox_!=null)
			{
				_gearErrorCollectionViaComponentInspectionReportGearbox_.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox_____!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox_____.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox_________!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox_________.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox__________!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox__________.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox______________!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox______________.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox____!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox____.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox____________!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox____________.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox_____________!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox_____________.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox________!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox________.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox_!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox_.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox___________!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox___________.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox__!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox__.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox_______!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox_______.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox______!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox______.ActiveContext = base.ActiveContext;
			}
			if(_gearTypeCollectionViaComponentInspectionReportGearbox___!=null)
			{
				_gearTypeCollectionViaComponentInspectionReportGearbox___.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGearbox_!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGearbox_.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGearbox!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_housingErrorCollectionViaComponentInspectionReportGearbox___!=null)
			{
				_housingErrorCollectionViaComponentInspectionReportGearbox___.ActiveContext = base.ActiveContext;
			}
			if(_housingErrorCollectionViaComponentInspectionReportGearbox__!=null)
			{
				_housingErrorCollectionViaComponentInspectionReportGearbox__.ActiveContext = base.ActiveContext;
			}
			if(_housingErrorCollectionViaComponentInspectionReportGearbox_!=null)
			{
				_housingErrorCollectionViaComponentInspectionReportGearbox_.ActiveContext = base.ActiveContext;
			}
			if(_housingErrorCollectionViaComponentInspectionReportGearbox____!=null)
			{
				_housingErrorCollectionViaComponentInspectionReportGearbox____.ActiveContext = base.ActiveContext;
			}
			if(_housingErrorCollectionViaComponentInspectionReportGearbox!=null)
			{
				_housingErrorCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_housingErrorCollectionViaComponentInspectionReportGearbox_____!=null)
			{
				_housingErrorCollectionViaComponentInspectionReportGearbox_____.ActiveContext = base.ActiveContext;
			}
			if(_inlineFilterCollectionViaComponentInspectionReportGearbox!=null)
			{
				_inlineFilterCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_magnetPosCollectionViaComponentInspectionReportGearbox!=null)
			{
				_magnetPosCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox!=null)
			{
				_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_oilLevelCollectionViaComponentInspectionReportGearbox!=null)
			{
				_oilLevelCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_oilTypeCollectionViaComponentInspectionReportGearbox!=null)
			{
				_oilTypeCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_overallGearboxConditionCollectionViaComponentInspectionReportGearbox!=null)
			{
				_overallGearboxConditionCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_shaftErrorCollectionViaComponentInspectionReportGearbox__!=null)
			{
				_shaftErrorCollectionViaComponentInspectionReportGearbox__.ActiveContext = base.ActiveContext;
			}
			if(_shaftErrorCollectionViaComponentInspectionReportGearbox___!=null)
			{
				_shaftErrorCollectionViaComponentInspectionReportGearbox___.ActiveContext = base.ActiveContext;
			}
			if(_shaftErrorCollectionViaComponentInspectionReportGearbox!=null)
			{
				_shaftErrorCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_shaftErrorCollectionViaComponentInspectionReportGearbox_!=null)
			{
				_shaftErrorCollectionViaComponentInspectionReportGearbox_.ActiveContext = base.ActiveContext;
			}
			if(_shaftTypeCollectionViaComponentInspectionReportGearbox__!=null)
			{
				_shaftTypeCollectionViaComponentInspectionReportGearbox__.ActiveContext = base.ActiveContext;
			}
			if(_shaftTypeCollectionViaComponentInspectionReportGearbox___!=null)
			{
				_shaftTypeCollectionViaComponentInspectionReportGearbox___.ActiveContext = base.ActiveContext;
			}
			if(_shaftTypeCollectionViaComponentInspectionReportGearbox!=null)
			{
				_shaftTypeCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_shaftTypeCollectionViaComponentInspectionReportGearbox_!=null)
			{
				_shaftTypeCollectionViaComponentInspectionReportGearbox_.ActiveContext = base.ActiveContext;
			}
			if(_shrinkElementCollectionViaComponentInspectionReportGearbox!=null)
			{
				_shrinkElementCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_vibrationsCollectionViaComponentInspectionReportGearbox!=null)
			{
				_vibrationsCollectionViaComponentInspectionReportGearbox.ActiveContext = base.ActiveContext;
			}
			if(_noise!=null)
			{
				_noise.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReportGearbox = null;
			_noise_ = null;
			_bearingErrorCollectionViaComponentInspectionReportGearbox___ = null;
			_bearingErrorCollectionViaComponentInspectionReportGearbox____ = null;
			_bearingErrorCollectionViaComponentInspectionReportGearbox_____ = null;
			_bearingErrorCollectionViaComponentInspectionReportGearbox = null;
			_bearingErrorCollectionViaComponentInspectionReportGearbox_ = null;
			_bearingErrorCollectionViaComponentInspectionReportGearbox__ = null;
			_bearingPosCollectionViaComponentInspectionReportGearbox____ = null;
			_bearingPosCollectionViaComponentInspectionReportGearbox_____ = null;
			_bearingPosCollectionViaComponentInspectionReportGearbox___ = null;
			_bearingPosCollectionViaComponentInspectionReportGearbox = null;
			_bearingPosCollectionViaComponentInspectionReportGearbox_ = null;
			_bearingPosCollectionViaComponentInspectionReportGearbox__ = null;
			_bearingTypeCollectionViaComponentInspectionReportGearbox = null;
			_bearingTypeCollectionViaComponentInspectionReportGearbox_____ = null;
			_bearingTypeCollectionViaComponentInspectionReportGearbox____ = null;
			_bearingTypeCollectionViaComponentInspectionReportGearbox___ = null;
			_bearingTypeCollectionViaComponentInspectionReportGearbox__ = null;
			_bearingTypeCollectionViaComponentInspectionReportGearbox_ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGearbox_ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGearbox = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGearbox = null;
			_couplingCollectionViaComponentInspectionReportGearbox = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox____________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox_____________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox__________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox___________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox_______________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox________________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox_________________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox______________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox___ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox__ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox____ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox_____ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox_________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox______ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox_______ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox__________________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox_ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox___________________ = null;
			_damageDecisionCollectionViaComponentInspectionReportGearbox____________________ = null;
			_debrisGearboxCollectionViaComponentInspectionReportGearbox = null;
			_debrisOnMagnetCollectionViaComponentInspectionReportGearbox = null;
			_electricalPumpCollectionViaComponentInspectionReportGearbox = null;
			_filterBlockTypeCollectionViaComponentInspectionReportGearbox = null;
			_gearboxManufacturerCollectionViaComponentInspectionReportGearbox = null;
			_gearboxRevisionCollectionViaComponentInspectionReportGearbox = null;
			_gearboxTypeCollectionViaComponentInspectionReportGearbox = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox___________ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox_______ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox________ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox_____ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox______ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox____________ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox_____________ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox_________ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox__________ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox__ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox____ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox______________ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox___ = null;
			_gearErrorCollectionViaComponentInspectionReportGearbox_ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox_____ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox_________ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox__________ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox______________ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox____ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox____________ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox_____________ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox________ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox_ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox___________ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox__ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox_______ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox______ = null;
			_gearTypeCollectionViaComponentInspectionReportGearbox___ = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGearbox_ = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGearbox = null;
			_housingErrorCollectionViaComponentInspectionReportGearbox___ = null;
			_housingErrorCollectionViaComponentInspectionReportGearbox__ = null;
			_housingErrorCollectionViaComponentInspectionReportGearbox_ = null;
			_housingErrorCollectionViaComponentInspectionReportGearbox____ = null;
			_housingErrorCollectionViaComponentInspectionReportGearbox = null;
			_housingErrorCollectionViaComponentInspectionReportGearbox_____ = null;
			_inlineFilterCollectionViaComponentInspectionReportGearbox = null;
			_magnetPosCollectionViaComponentInspectionReportGearbox = null;
			_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox = null;
			_oilLevelCollectionViaComponentInspectionReportGearbox = null;
			_oilTypeCollectionViaComponentInspectionReportGearbox = null;
			_overallGearboxConditionCollectionViaComponentInspectionReportGearbox = null;
			_shaftErrorCollectionViaComponentInspectionReportGearbox__ = null;
			_shaftErrorCollectionViaComponentInspectionReportGearbox___ = null;
			_shaftErrorCollectionViaComponentInspectionReportGearbox = null;
			_shaftErrorCollectionViaComponentInspectionReportGearbox_ = null;
			_shaftTypeCollectionViaComponentInspectionReportGearbox__ = null;
			_shaftTypeCollectionViaComponentInspectionReportGearbox___ = null;
			_shaftTypeCollectionViaComponentInspectionReportGearbox = null;
			_shaftTypeCollectionViaComponentInspectionReportGearbox_ = null;
			_shrinkElementCollectionViaComponentInspectionReportGearbox = null;
			_vibrationsCollectionViaComponentInspectionReportGearbox = null;
			_noise = null;

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

			_fieldsCustomProperties.Add("NoiseId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentNoiseId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _noise</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncNoise(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _noise, new PropertyChangedEventHandler( OnNoisePropertyChanged ), "Noise", NoiseEntity.Relations.NoiseEntityUsingNoiseIdParentNoiseId, true, signalRelatedEntity, "Noise_", resetFKFields, new int[] { (int)NoiseFieldIndex.ParentNoiseId } );		
			_noise = null;
		}

		/// <summary> setups the sync logic for member _noise</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncNoise(IEntity2 relatedEntity)
		{
			DesetupSyncNoise(true, true);
			_noise = (NoiseEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _noise, new PropertyChangedEventHandler( OnNoisePropertyChanged ), "Noise", NoiseEntity.Relations.NoiseEntityUsingNoiseIdParentNoiseId, true, new string[] {  } );
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


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this NoiseEntity</param>
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
		public  static NoiseRelations Relations
		{
			get	{ return new NoiseRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGearbox' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGearbox
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGearboxEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGearboxEntityFactory))),
					NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, 
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGearboxEntity, 0, null, null, null, null, "ComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Noise' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathNoise_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<NoiseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoiseEntityFactory))),
					NoiseEntity.Relations.NoiseEntityUsingParentNoiseId, 
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.NoiseEntity, 0, null, null, null, null, "Noise_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingErrorCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage4BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, relations, null, "BearingErrorCollectionViaComponentInspectionReportGearbox___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingErrorCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage5BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, relations, null, "BearingErrorCollectionViaComponentInspectionReportGearbox____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingErrorCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage6BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, relations, null, "BearingErrorCollectionViaComponentInspectionReportGearbox_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingErrorCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage1BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, relations, null, "BearingErrorCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingErrorCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage2BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, relations, null, "BearingErrorCollectionViaComponentInspectionReportGearbox_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingErrorCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingErrorEntityUsingGearboxBearingsDamage3BearingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingErrorEntity, 0, null, null, relations, null, "BearingErrorCollectionViaComponentInspectionReportGearbox__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPosCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition5BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, relations, null, "BearingPosCollectionViaComponentInspectionReportGearbox____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPosCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition6BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, relations, null, "BearingPosCollectionViaComponentInspectionReportGearbox_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPosCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition4BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, relations, null, "BearingPosCollectionViaComponentInspectionReportGearbox___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPosCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition1BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, relations, null, "BearingPosCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPosCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition2BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, relations, null, "BearingPosCollectionViaComponentInspectionReportGearbox_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingPosCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingPosEntityUsingGearboxBearingsPosition3BearingPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingPosEntity, 0, null, null, relations, null, "BearingPosCollectionViaComponentInspectionReportGearbox__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation1BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, relations, null, "BearingTypeCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingTypeCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation6BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, relations, null, "BearingTypeCollectionViaComponentInspectionReportGearbox_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingTypeCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation5BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, relations, null, "BearingTypeCollectionViaComponentInspectionReportGearbox____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingTypeCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation4BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, relations, null, "BearingTypeCollectionViaComponentInspectionReportGearbox___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingTypeCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation3BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, relations, null, "BearingTypeCollectionViaComponentInspectionReportGearbox__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BearingType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBearingTypeCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BearingTypeEntityUsingGearboxBearingsLocation2BearingTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BearingTypeEntity, 0, null, null, relations, null, "BearingTypeCollectionViaComponentInspectionReportGearbox_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BooleanAnswerEntityUsingGearboxClaimRelevantBooleanAnswerId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGearbox_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.BooleanAnswerEntityUsingGearboxOffLineFilterId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouplingCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.CouplingEntityUsingGearboxCouplingId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, relations, null, "CouplingCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox____________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision1DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox_____________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision2DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox_____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox__________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision14DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox__________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox___________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision15DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox___________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox_______________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision4DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox_______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox________________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision5DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox_________________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision6DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox_________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox______________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision3DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision4DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision3DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision5DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision6DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision12DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox_________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision13DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox_________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision10DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision11DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox__________________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision7DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox__________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision1DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxBearingDecision2DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox___________________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision8DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox___________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DamageDecision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDamageDecisionCollectionViaComponentInspectionReportGearbox____________________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DamageDecisionEntityUsingGearboxGearDecision9DamageDecisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DamageDecisionEntity, 0, null, null, relations, null, "DamageDecisionCollectionViaComponentInspectionReportGearbox____________________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DebrisGearbox' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDebrisGearboxCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DebrisGearboxEntityUsingGearboxDebrisGearBoxId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DebrisGearboxEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DebrisGearboxEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DebrisGearboxEntity, 0, null, null, relations, null, "DebrisGearboxCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'DebrisOnMagnet' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathDebrisOnMagnetCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.DebrisOnMagnetEntityUsingGearboxDebrisOnMagnetId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<DebrisOnMagnetEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DebrisOnMagnetEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.DebrisOnMagnetEntity, 0, null, null, relations, null, "DebrisOnMagnetCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ElectricalPump' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathElectricalPumpCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.ElectricalPumpEntityUsingGearboxElectricalPumpId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ElectricalPumpEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ElectricalPumpEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ElectricalPumpEntity, 0, null, null, relations, null, "ElectricalPumpCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'FilterBlockType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathFilterBlockTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.FilterBlockTypeEntityUsingGearboxFilterBlockTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<FilterBlockTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FilterBlockTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.FilterBlockTypeEntity, 0, null, null, relations, null, "FilterBlockTypeCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearboxManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearboxManufacturerCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearboxManufacturerEntityUsingGearboxManufacturerId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearboxManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxManufacturerEntity, 0, null, null, relations, null, "GearboxManufacturerCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearboxRevision' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearboxRevisionCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearboxRevisionEntityUsingGearboxRevisionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearboxRevisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxRevisionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxRevisionEntity, 0, null, null, relations, null, "GearboxRevisionCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearboxType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearboxTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearboxTypeEntityUsingGearboxTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearboxTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearboxTypeEntity, 0, null, null, relations, null, "GearboxTypeCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox___________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage6GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox___________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage12GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage13GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage10GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage11GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox____________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage7GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox_____________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage8GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox_____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox_________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage14GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox_________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox__________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage15GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox__________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage3GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage5GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox______________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage9GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage1GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage4GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearErrorCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearErrorEntityUsingGearboxTypeofDamage2GearErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearErrorEntity, 0, null, null, relations, null, "GearErrorCollectionViaComponentInspectionReportGearbox_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation6GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox_________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation13GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox_________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox__________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation14GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox__________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox______________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation9GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox______________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation5GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox____________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation7GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox_____________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation8GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox_____________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation12GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation2GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation1GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox___________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation15GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox___________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation3GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation11GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation10GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GearType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGearTypeCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GearTypeEntityUsingGearboxExactLocation4GearTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GearTypeEntity, 0, null, null, relations, null, "GearTypeCollectionViaComponentInspectionReportGearbox___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId2, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGearbox_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.GeneratorManufacturerEntityUsingGearboxGeneratorManufacturerId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingErrorCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxFrontPlateHousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, relations, null, "HousingErrorCollectionViaComponentInspectionReportGearbox___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingErrorCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxHelicalStageHousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, relations, null, "HousingErrorCollectionViaComponentInspectionReportGearbox__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingErrorCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxPlanetStage2HousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, relations, null, "HousingErrorCollectionViaComponentInspectionReportGearbox_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingErrorCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxAuxStageHousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, relations, null, "HousingErrorCollectionViaComponentInspectionReportGearbox____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingErrorCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxPlanetStage1HousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, relations, null, "HousingErrorCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'HousingError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathHousingErrorCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.HousingErrorEntityUsingGearboxHsstageHousingErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.HousingErrorEntity, 0, null, null, relations, null, "HousingErrorCollectionViaComponentInspectionReportGearbox_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'InlineFilter' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathInlineFilterCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.InlineFilterEntityUsingGearboxInLineFilterId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<InlineFilterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InlineFilterEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.InlineFilterEntity, 0, null, null, relations, null, "InlineFilterCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MagnetPos' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMagnetPosCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.MagnetPosEntityUsingGearboxDebrisStagesMagnetPosId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<MagnetPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MagnetPosEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.MagnetPosEntity, 0, null, null, relations, null, "MagnetPosCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'MechanicalOilPump' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathMechanicalOilPumpCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.MechanicalOilPumpEntityUsingGearboxMechanicalOilPumpId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<MechanicalOilPumpEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MechanicalOilPumpEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.MechanicalOilPumpEntity, 0, null, null, relations, null, "MechanicalOilPumpCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OilLevel' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOilLevelCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.OilLevelEntityUsingGearboxOilLevelId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OilLevelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OilLevelEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.OilLevelEntity, 0, null, null, relations, null, "OilLevelCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OilType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOilTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.OilTypeEntityUsingGearboxOilTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OilTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OilTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.OilTypeEntity, 0, null, null, relations, null, "OilTypeCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OverallGearboxCondition' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOverallGearboxConditionCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.OverallGearboxConditionEntityUsingGearboxOverallGearboxConditionId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<OverallGearboxConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OverallGearboxConditionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.OverallGearboxConditionEntity, 0, null, null, relations, null, "OverallGearboxConditionCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftErrorCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage3ShaftErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftErrorEntity, 0, null, null, relations, null, "ShaftErrorCollectionViaComponentInspectionReportGearbox__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftErrorCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage4ShaftErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftErrorEntity, 0, null, null, relations, null, "ShaftErrorCollectionViaComponentInspectionReportGearbox___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftErrorCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage1ShaftErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftErrorEntity, 0, null, null, relations, null, "ShaftErrorCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftError' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftErrorCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftErrorEntityUsingGearboxShaftsTypeofDamage2ShaftErrorId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftErrorEntity, 0, null, null, relations, null, "ShaftErrorCollectionViaComponentInspectionReportGearbox_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftTypeCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation3ShaftTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftTypeEntity, 0, null, null, relations, null, "ShaftTypeCollectionViaComponentInspectionReportGearbox__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftTypeCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation4ShaftTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftTypeEntity, 0, null, null, relations, null, "ShaftTypeCollectionViaComponentInspectionReportGearbox___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation1ShaftTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftTypeEntity, 0, null, null, relations, null, "ShaftTypeCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShaftType' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShaftTypeCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShaftTypeEntityUsingGearboxShaftsExactLocation2ShaftTypeId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ShaftTypeEntity, 0, null, null, relations, null, "ShaftTypeCollectionViaComponentInspectionReportGearbox_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ShrinkElement' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathShrinkElementCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.ShrinkElementEntityUsingGearboxShrinkElementId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ShrinkElementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShrinkElementEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.ShrinkElementEntity, 0, null, null, relations, null, "ShrinkElementCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Vibrations' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathVibrationsCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGearbox_");
				relations.Add(NoiseEntity.Relations.ComponentInspectionReportGearboxEntityUsingGearboxNoiseId, "NoiseEntity__", "ComponentInspectionReportGearbox_", JoinHint.None);
				relations.Add(ComponentInspectionReportGearboxEntity.Relations.VibrationsEntityUsingGearboxVibrationsId, "ComponentInspectionReportGearbox_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<VibrationsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(VibrationsEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.VibrationsEntity, 0, null, null, relations, null, "VibrationsCollectionViaComponentInspectionReportGearbox", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
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
					NoiseEntity.Relations.NoiseEntityUsingNoiseIdParentNoiseId, 
					(int)Cir.Data.LLBLGen.EntityType.NoiseEntity, (int)Cir.Data.LLBLGen.EntityType.NoiseEntity, 0, null, null, null, null, "Noise", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return NoiseEntity.CustomProperties;}
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
			get { return NoiseEntity.FieldsCustomProperties;}
		}

		/// <summary> The NoiseId property of the Entity Noise<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Noise"."NoiseId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 NoiseId
		{
			get { return (System.Int64)GetValue((int)NoiseFieldIndex.NoiseId, true); }
			set	{ SetValue((int)NoiseFieldIndex.NoiseId, value); }
		}

		/// <summary> The Name property of the Entity Noise<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Noise"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)NoiseFieldIndex.Name, true); }
			set	{ SetValue((int)NoiseFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity Noise<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Noise"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)NoiseFieldIndex.LanguageId, true); }
			set	{ SetValue((int)NoiseFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentNoiseId property of the Entity Noise<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Noise"."ParentNoiseId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentNoiseId
		{
			get { return (Nullable<System.Int64>)GetValue((int)NoiseFieldIndex.ParentNoiseId, false); }
			set	{ SetValue((int)NoiseFieldIndex.ParentNoiseId, value); }
		}

		/// <summary> The Sort property of the Entity Noise<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "Noise"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)NoiseFieldIndex.Sort, true); }
			set	{ SetValue((int)NoiseFieldIndex.Sort, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGearboxEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGearboxEntity))]
		public virtual EntityCollection<ComponentInspectionReportGearboxEntity> ComponentInspectionReportGearbox
		{
			get
			{
				if(_componentInspectionReportGearbox==null)
				{
					_componentInspectionReportGearbox = new EntityCollection<ComponentInspectionReportGearboxEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGearboxEntityFactory)));
					_componentInspectionReportGearbox.SetContainingEntityInfo(this, "Noise");
				}
				return _componentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'NoiseEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(NoiseEntity))]
		public virtual EntityCollection<NoiseEntity> Noise_
		{
			get
			{
				if(_noise_==null)
				{
					_noise_ = new EntityCollection<NoiseEntity>(EntityFactoryCache2.GetEntityFactory(typeof(NoiseEntityFactory)));
					_noise_.SetContainingEntityInfo(this, "Noise");
				}
				return _noise_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingErrorEntity))]
		public virtual EntityCollection<BearingErrorEntity> BearingErrorCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				if(_bearingErrorCollectionViaComponentInspectionReportGearbox___==null)
				{
					_bearingErrorCollectionViaComponentInspectionReportGearbox___ = new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory)));
					_bearingErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly=true;
				}
				return _bearingErrorCollectionViaComponentInspectionReportGearbox___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingErrorEntity))]
		public virtual EntityCollection<BearingErrorEntity> BearingErrorCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				if(_bearingErrorCollectionViaComponentInspectionReportGearbox____==null)
				{
					_bearingErrorCollectionViaComponentInspectionReportGearbox____ = new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory)));
					_bearingErrorCollectionViaComponentInspectionReportGearbox____.IsReadOnly=true;
				}
				return _bearingErrorCollectionViaComponentInspectionReportGearbox____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingErrorEntity))]
		public virtual EntityCollection<BearingErrorEntity> BearingErrorCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				if(_bearingErrorCollectionViaComponentInspectionReportGearbox_____==null)
				{
					_bearingErrorCollectionViaComponentInspectionReportGearbox_____ = new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory)));
					_bearingErrorCollectionViaComponentInspectionReportGearbox_____.IsReadOnly=true;
				}
				return _bearingErrorCollectionViaComponentInspectionReportGearbox_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingErrorEntity))]
		public virtual EntityCollection<BearingErrorEntity> BearingErrorCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_bearingErrorCollectionViaComponentInspectionReportGearbox==null)
				{
					_bearingErrorCollectionViaComponentInspectionReportGearbox = new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory)));
					_bearingErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _bearingErrorCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingErrorEntity))]
		public virtual EntityCollection<BearingErrorEntity> BearingErrorCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				if(_bearingErrorCollectionViaComponentInspectionReportGearbox_==null)
				{
					_bearingErrorCollectionViaComponentInspectionReportGearbox_ = new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory)));
					_bearingErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly=true;
				}
				return _bearingErrorCollectionViaComponentInspectionReportGearbox_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingErrorEntity))]
		public virtual EntityCollection<BearingErrorEntity> BearingErrorCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				if(_bearingErrorCollectionViaComponentInspectionReportGearbox__==null)
				{
					_bearingErrorCollectionViaComponentInspectionReportGearbox__ = new EntityCollection<BearingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingErrorEntityFactory)));
					_bearingErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly=true;
				}
				return _bearingErrorCollectionViaComponentInspectionReportGearbox__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingPosEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingPosEntity))]
		public virtual EntityCollection<BearingPosEntity> BearingPosCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				if(_bearingPosCollectionViaComponentInspectionReportGearbox____==null)
				{
					_bearingPosCollectionViaComponentInspectionReportGearbox____ = new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory)));
					_bearingPosCollectionViaComponentInspectionReportGearbox____.IsReadOnly=true;
				}
				return _bearingPosCollectionViaComponentInspectionReportGearbox____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingPosEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingPosEntity))]
		public virtual EntityCollection<BearingPosEntity> BearingPosCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				if(_bearingPosCollectionViaComponentInspectionReportGearbox_____==null)
				{
					_bearingPosCollectionViaComponentInspectionReportGearbox_____ = new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory)));
					_bearingPosCollectionViaComponentInspectionReportGearbox_____.IsReadOnly=true;
				}
				return _bearingPosCollectionViaComponentInspectionReportGearbox_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingPosEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingPosEntity))]
		public virtual EntityCollection<BearingPosEntity> BearingPosCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				if(_bearingPosCollectionViaComponentInspectionReportGearbox___==null)
				{
					_bearingPosCollectionViaComponentInspectionReportGearbox___ = new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory)));
					_bearingPosCollectionViaComponentInspectionReportGearbox___.IsReadOnly=true;
				}
				return _bearingPosCollectionViaComponentInspectionReportGearbox___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingPosEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingPosEntity))]
		public virtual EntityCollection<BearingPosEntity> BearingPosCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_bearingPosCollectionViaComponentInspectionReportGearbox==null)
				{
					_bearingPosCollectionViaComponentInspectionReportGearbox = new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory)));
					_bearingPosCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _bearingPosCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingPosEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingPosEntity))]
		public virtual EntityCollection<BearingPosEntity> BearingPosCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				if(_bearingPosCollectionViaComponentInspectionReportGearbox_==null)
				{
					_bearingPosCollectionViaComponentInspectionReportGearbox_ = new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory)));
					_bearingPosCollectionViaComponentInspectionReportGearbox_.IsReadOnly=true;
				}
				return _bearingPosCollectionViaComponentInspectionReportGearbox_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingPosEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingPosEntity))]
		public virtual EntityCollection<BearingPosEntity> BearingPosCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				if(_bearingPosCollectionViaComponentInspectionReportGearbox__==null)
				{
					_bearingPosCollectionViaComponentInspectionReportGearbox__ = new EntityCollection<BearingPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingPosEntityFactory)));
					_bearingPosCollectionViaComponentInspectionReportGearbox__.IsReadOnly=true;
				}
				return _bearingPosCollectionViaComponentInspectionReportGearbox__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingTypeEntity))]
		public virtual EntityCollection<BearingTypeEntity> BearingTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_bearingTypeCollectionViaComponentInspectionReportGearbox==null)
				{
					_bearingTypeCollectionViaComponentInspectionReportGearbox = new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory)));
					_bearingTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _bearingTypeCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingTypeEntity))]
		public virtual EntityCollection<BearingTypeEntity> BearingTypeCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				if(_bearingTypeCollectionViaComponentInspectionReportGearbox_____==null)
				{
					_bearingTypeCollectionViaComponentInspectionReportGearbox_____ = new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory)));
					_bearingTypeCollectionViaComponentInspectionReportGearbox_____.IsReadOnly=true;
				}
				return _bearingTypeCollectionViaComponentInspectionReportGearbox_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingTypeEntity))]
		public virtual EntityCollection<BearingTypeEntity> BearingTypeCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				if(_bearingTypeCollectionViaComponentInspectionReportGearbox____==null)
				{
					_bearingTypeCollectionViaComponentInspectionReportGearbox____ = new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory)));
					_bearingTypeCollectionViaComponentInspectionReportGearbox____.IsReadOnly=true;
				}
				return _bearingTypeCollectionViaComponentInspectionReportGearbox____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingTypeEntity))]
		public virtual EntityCollection<BearingTypeEntity> BearingTypeCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				if(_bearingTypeCollectionViaComponentInspectionReportGearbox___==null)
				{
					_bearingTypeCollectionViaComponentInspectionReportGearbox___ = new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory)));
					_bearingTypeCollectionViaComponentInspectionReportGearbox___.IsReadOnly=true;
				}
				return _bearingTypeCollectionViaComponentInspectionReportGearbox___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingTypeEntity))]
		public virtual EntityCollection<BearingTypeEntity> BearingTypeCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				if(_bearingTypeCollectionViaComponentInspectionReportGearbox__==null)
				{
					_bearingTypeCollectionViaComponentInspectionReportGearbox__ = new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory)));
					_bearingTypeCollectionViaComponentInspectionReportGearbox__.IsReadOnly=true;
				}
				return _bearingTypeCollectionViaComponentInspectionReportGearbox__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BearingTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BearingTypeEntity))]
		public virtual EntityCollection<BearingTypeEntity> BearingTypeCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				if(_bearingTypeCollectionViaComponentInspectionReportGearbox_==null)
				{
					_bearingTypeCollectionViaComponentInspectionReportGearbox_ = new EntityCollection<BearingTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BearingTypeEntityFactory)));
					_bearingTypeCollectionViaComponentInspectionReportGearbox_.IsReadOnly=true;
				}
				return _bearingTypeCollectionViaComponentInspectionReportGearbox_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGearbox_==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGearbox_ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGearbox_.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGearbox_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGearbox==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGearbox = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGearbox==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGearbox = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouplingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouplingEntity))]
		public virtual EntityCollection<CouplingEntity> CouplingCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_couplingCollectionViaComponentInspectionReportGearbox==null)
				{
					_couplingCollectionViaComponentInspectionReportGearbox = new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory)));
					_couplingCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _couplingCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox____________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox____________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox____________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox____________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox____________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox_____________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox_____________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox_____________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox_____________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox_____________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox__________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox__________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox__________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox__________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox__________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox___________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox___________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox___________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox___________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox___________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox_______________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox_______________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox_______________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox_______________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox_______________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox________________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox________________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox________________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox________________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox_________________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox_________________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox_________________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox_________________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox_________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox______________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox______________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox______________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox______________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox______________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox___==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox___ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox___.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox__==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox__ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox__.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox____==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox____ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox____.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox_____==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox_____ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox_____.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox_________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox_________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox_________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox_________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox_________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox______
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox______==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox______ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox______.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox_______
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox_______==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox_______ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox_______.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox__________________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox__________________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox__________________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox__________________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox__________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox_==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox_ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox_.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox___________________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox___________________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox___________________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox___________________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox___________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DamageDecisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DamageDecisionEntity))]
		public virtual EntityCollection<DamageDecisionEntity> DamageDecisionCollectionViaComponentInspectionReportGearbox____________________
		{
			get
			{
				if(_damageDecisionCollectionViaComponentInspectionReportGearbox____________________==null)
				{
					_damageDecisionCollectionViaComponentInspectionReportGearbox____________________ = new EntityCollection<DamageDecisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DamageDecisionEntityFactory)));
					_damageDecisionCollectionViaComponentInspectionReportGearbox____________________.IsReadOnly=true;
				}
				return _damageDecisionCollectionViaComponentInspectionReportGearbox____________________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DebrisGearboxEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DebrisGearboxEntity))]
		public virtual EntityCollection<DebrisGearboxEntity> DebrisGearboxCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_debrisGearboxCollectionViaComponentInspectionReportGearbox==null)
				{
					_debrisGearboxCollectionViaComponentInspectionReportGearbox = new EntityCollection<DebrisGearboxEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DebrisGearboxEntityFactory)));
					_debrisGearboxCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _debrisGearboxCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'DebrisOnMagnetEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(DebrisOnMagnetEntity))]
		public virtual EntityCollection<DebrisOnMagnetEntity> DebrisOnMagnetCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_debrisOnMagnetCollectionViaComponentInspectionReportGearbox==null)
				{
					_debrisOnMagnetCollectionViaComponentInspectionReportGearbox = new EntityCollection<DebrisOnMagnetEntity>(EntityFactoryCache2.GetEntityFactory(typeof(DebrisOnMagnetEntityFactory)));
					_debrisOnMagnetCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _debrisOnMagnetCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ElectricalPumpEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ElectricalPumpEntity))]
		public virtual EntityCollection<ElectricalPumpEntity> ElectricalPumpCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_electricalPumpCollectionViaComponentInspectionReportGearbox==null)
				{
					_electricalPumpCollectionViaComponentInspectionReportGearbox = new EntityCollection<ElectricalPumpEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ElectricalPumpEntityFactory)));
					_electricalPumpCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _electricalPumpCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'FilterBlockTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(FilterBlockTypeEntity))]
		public virtual EntityCollection<FilterBlockTypeEntity> FilterBlockTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_filterBlockTypeCollectionViaComponentInspectionReportGearbox==null)
				{
					_filterBlockTypeCollectionViaComponentInspectionReportGearbox = new EntityCollection<FilterBlockTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(FilterBlockTypeEntityFactory)));
					_filterBlockTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _filterBlockTypeCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearboxManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearboxManufacturerEntity))]
		public virtual EntityCollection<GearboxManufacturerEntity> GearboxManufacturerCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_gearboxManufacturerCollectionViaComponentInspectionReportGearbox==null)
				{
					_gearboxManufacturerCollectionViaComponentInspectionReportGearbox = new EntityCollection<GearboxManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxManufacturerEntityFactory)));
					_gearboxManufacturerCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _gearboxManufacturerCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearboxRevisionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearboxRevisionEntity))]
		public virtual EntityCollection<GearboxRevisionEntity> GearboxRevisionCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_gearboxRevisionCollectionViaComponentInspectionReportGearbox==null)
				{
					_gearboxRevisionCollectionViaComponentInspectionReportGearbox = new EntityCollection<GearboxRevisionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxRevisionEntityFactory)));
					_gearboxRevisionCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _gearboxRevisionCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearboxTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearboxTypeEntity))]
		public virtual EntityCollection<GearboxTypeEntity> GearboxTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_gearboxTypeCollectionViaComponentInspectionReportGearbox==null)
				{
					_gearboxTypeCollectionViaComponentInspectionReportGearbox = new EntityCollection<GearboxTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearboxTypeEntityFactory)));
					_gearboxTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _gearboxTypeCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox___________
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox___________==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox___________ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox___________.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox___________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox_______
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox_______==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox_______ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox_______.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox________
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox________==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox________ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox________.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox_____==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox_____ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox_____.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox______
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox______==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox______ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox______.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox____________
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox____________==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox____________ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox____________.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox____________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox_____________
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox_____________==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox_____________ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox_____________.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox_____________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox_________
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox_________==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox_________ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox_________.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox_________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox__________
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox__________==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox__________ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox__________.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox__________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox__==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox__ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox____==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox____ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox____.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox______________
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox______________==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox______________ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox______________.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox______________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox___==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox___ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearErrorEntity))]
		public virtual EntityCollection<GearErrorEntity> GearErrorCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				if(_gearErrorCollectionViaComponentInspectionReportGearbox_==null)
				{
					_gearErrorCollectionViaComponentInspectionReportGearbox_ = new EntityCollection<GearErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearErrorEntityFactory)));
					_gearErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly=true;
				}
				return _gearErrorCollectionViaComponentInspectionReportGearbox_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox_____==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox_____ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox_____.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox_________
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox_________==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox_________ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox_________.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox_________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox__________
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox__________==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox__________ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox__________.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox__________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox______________
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox______________==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox______________ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox______________.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox______________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox____==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox____ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox____.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox____________
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox____________==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox____________ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox____________.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox____________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox_____________
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox_____________==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox_____________ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox_____________.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox_____________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox________
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox________==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox________ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox________.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox_==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox_ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox_.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox___________
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox___________==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox___________ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox___________.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox___________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox__==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox__ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox__.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox_______
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox_______==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox_______ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox_______.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox______
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox______==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox______ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox______.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GearTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GearTypeEntity))]
		public virtual EntityCollection<GearTypeEntity> GearTypeCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				if(_gearTypeCollectionViaComponentInspectionReportGearbox___==null)
				{
					_gearTypeCollectionViaComponentInspectionReportGearbox___ = new EntityCollection<GearTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GearTypeEntityFactory)));
					_gearTypeCollectionViaComponentInspectionReportGearbox___.IsReadOnly=true;
				}
				return _gearTypeCollectionViaComponentInspectionReportGearbox___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGearbox_==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGearbox_ = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGearbox_.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGearbox_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGearbox==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGearbox = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HousingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HousingErrorEntity))]
		public virtual EntityCollection<HousingErrorEntity> HousingErrorCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				if(_housingErrorCollectionViaComponentInspectionReportGearbox___==null)
				{
					_housingErrorCollectionViaComponentInspectionReportGearbox___ = new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory)));
					_housingErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly=true;
				}
				return _housingErrorCollectionViaComponentInspectionReportGearbox___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HousingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HousingErrorEntity))]
		public virtual EntityCollection<HousingErrorEntity> HousingErrorCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				if(_housingErrorCollectionViaComponentInspectionReportGearbox__==null)
				{
					_housingErrorCollectionViaComponentInspectionReportGearbox__ = new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory)));
					_housingErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly=true;
				}
				return _housingErrorCollectionViaComponentInspectionReportGearbox__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HousingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HousingErrorEntity))]
		public virtual EntityCollection<HousingErrorEntity> HousingErrorCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				if(_housingErrorCollectionViaComponentInspectionReportGearbox_==null)
				{
					_housingErrorCollectionViaComponentInspectionReportGearbox_ = new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory)));
					_housingErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly=true;
				}
				return _housingErrorCollectionViaComponentInspectionReportGearbox_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HousingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HousingErrorEntity))]
		public virtual EntityCollection<HousingErrorEntity> HousingErrorCollectionViaComponentInspectionReportGearbox____
		{
			get
			{
				if(_housingErrorCollectionViaComponentInspectionReportGearbox____==null)
				{
					_housingErrorCollectionViaComponentInspectionReportGearbox____ = new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory)));
					_housingErrorCollectionViaComponentInspectionReportGearbox____.IsReadOnly=true;
				}
				return _housingErrorCollectionViaComponentInspectionReportGearbox____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HousingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HousingErrorEntity))]
		public virtual EntityCollection<HousingErrorEntity> HousingErrorCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_housingErrorCollectionViaComponentInspectionReportGearbox==null)
				{
					_housingErrorCollectionViaComponentInspectionReportGearbox = new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory)));
					_housingErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _housingErrorCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'HousingErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(HousingErrorEntity))]
		public virtual EntityCollection<HousingErrorEntity> HousingErrorCollectionViaComponentInspectionReportGearbox_____
		{
			get
			{
				if(_housingErrorCollectionViaComponentInspectionReportGearbox_____==null)
				{
					_housingErrorCollectionViaComponentInspectionReportGearbox_____ = new EntityCollection<HousingErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(HousingErrorEntityFactory)));
					_housingErrorCollectionViaComponentInspectionReportGearbox_____.IsReadOnly=true;
				}
				return _housingErrorCollectionViaComponentInspectionReportGearbox_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'InlineFilterEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(InlineFilterEntity))]
		public virtual EntityCollection<InlineFilterEntity> InlineFilterCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_inlineFilterCollectionViaComponentInspectionReportGearbox==null)
				{
					_inlineFilterCollectionViaComponentInspectionReportGearbox = new EntityCollection<InlineFilterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(InlineFilterEntityFactory)));
					_inlineFilterCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _inlineFilterCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MagnetPosEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MagnetPosEntity))]
		public virtual EntityCollection<MagnetPosEntity> MagnetPosCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_magnetPosCollectionViaComponentInspectionReportGearbox==null)
				{
					_magnetPosCollectionViaComponentInspectionReportGearbox = new EntityCollection<MagnetPosEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MagnetPosEntityFactory)));
					_magnetPosCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _magnetPosCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'MechanicalOilPumpEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(MechanicalOilPumpEntity))]
		public virtual EntityCollection<MechanicalOilPumpEntity> MechanicalOilPumpCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox==null)
				{
					_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox = new EntityCollection<MechanicalOilPumpEntity>(EntityFactoryCache2.GetEntityFactory(typeof(MechanicalOilPumpEntityFactory)));
					_mechanicalOilPumpCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _mechanicalOilPumpCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OilLevelEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OilLevelEntity))]
		public virtual EntityCollection<OilLevelEntity> OilLevelCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_oilLevelCollectionViaComponentInspectionReportGearbox==null)
				{
					_oilLevelCollectionViaComponentInspectionReportGearbox = new EntityCollection<OilLevelEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OilLevelEntityFactory)));
					_oilLevelCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _oilLevelCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OilTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OilTypeEntity))]
		public virtual EntityCollection<OilTypeEntity> OilTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_oilTypeCollectionViaComponentInspectionReportGearbox==null)
				{
					_oilTypeCollectionViaComponentInspectionReportGearbox = new EntityCollection<OilTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OilTypeEntityFactory)));
					_oilTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _oilTypeCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OverallGearboxConditionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OverallGearboxConditionEntity))]
		public virtual EntityCollection<OverallGearboxConditionEntity> OverallGearboxConditionCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_overallGearboxConditionCollectionViaComponentInspectionReportGearbox==null)
				{
					_overallGearboxConditionCollectionViaComponentInspectionReportGearbox = new EntityCollection<OverallGearboxConditionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OverallGearboxConditionEntityFactory)));
					_overallGearboxConditionCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _overallGearboxConditionCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShaftErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShaftErrorEntity))]
		public virtual EntityCollection<ShaftErrorEntity> ShaftErrorCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				if(_shaftErrorCollectionViaComponentInspectionReportGearbox__==null)
				{
					_shaftErrorCollectionViaComponentInspectionReportGearbox__ = new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory)));
					_shaftErrorCollectionViaComponentInspectionReportGearbox__.IsReadOnly=true;
				}
				return _shaftErrorCollectionViaComponentInspectionReportGearbox__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShaftErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShaftErrorEntity))]
		public virtual EntityCollection<ShaftErrorEntity> ShaftErrorCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				if(_shaftErrorCollectionViaComponentInspectionReportGearbox___==null)
				{
					_shaftErrorCollectionViaComponentInspectionReportGearbox___ = new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory)));
					_shaftErrorCollectionViaComponentInspectionReportGearbox___.IsReadOnly=true;
				}
				return _shaftErrorCollectionViaComponentInspectionReportGearbox___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShaftErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShaftErrorEntity))]
		public virtual EntityCollection<ShaftErrorEntity> ShaftErrorCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_shaftErrorCollectionViaComponentInspectionReportGearbox==null)
				{
					_shaftErrorCollectionViaComponentInspectionReportGearbox = new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory)));
					_shaftErrorCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _shaftErrorCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShaftErrorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShaftErrorEntity))]
		public virtual EntityCollection<ShaftErrorEntity> ShaftErrorCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				if(_shaftErrorCollectionViaComponentInspectionReportGearbox_==null)
				{
					_shaftErrorCollectionViaComponentInspectionReportGearbox_ = new EntityCollection<ShaftErrorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftErrorEntityFactory)));
					_shaftErrorCollectionViaComponentInspectionReportGearbox_.IsReadOnly=true;
				}
				return _shaftErrorCollectionViaComponentInspectionReportGearbox_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShaftTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShaftTypeEntity))]
		public virtual EntityCollection<ShaftTypeEntity> ShaftTypeCollectionViaComponentInspectionReportGearbox__
		{
			get
			{
				if(_shaftTypeCollectionViaComponentInspectionReportGearbox__==null)
				{
					_shaftTypeCollectionViaComponentInspectionReportGearbox__ = new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory)));
					_shaftTypeCollectionViaComponentInspectionReportGearbox__.IsReadOnly=true;
				}
				return _shaftTypeCollectionViaComponentInspectionReportGearbox__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShaftTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShaftTypeEntity))]
		public virtual EntityCollection<ShaftTypeEntity> ShaftTypeCollectionViaComponentInspectionReportGearbox___
		{
			get
			{
				if(_shaftTypeCollectionViaComponentInspectionReportGearbox___==null)
				{
					_shaftTypeCollectionViaComponentInspectionReportGearbox___ = new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory)));
					_shaftTypeCollectionViaComponentInspectionReportGearbox___.IsReadOnly=true;
				}
				return _shaftTypeCollectionViaComponentInspectionReportGearbox___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShaftTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShaftTypeEntity))]
		public virtual EntityCollection<ShaftTypeEntity> ShaftTypeCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_shaftTypeCollectionViaComponentInspectionReportGearbox==null)
				{
					_shaftTypeCollectionViaComponentInspectionReportGearbox = new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory)));
					_shaftTypeCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _shaftTypeCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShaftTypeEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShaftTypeEntity))]
		public virtual EntityCollection<ShaftTypeEntity> ShaftTypeCollectionViaComponentInspectionReportGearbox_
		{
			get
			{
				if(_shaftTypeCollectionViaComponentInspectionReportGearbox_==null)
				{
					_shaftTypeCollectionViaComponentInspectionReportGearbox_ = new EntityCollection<ShaftTypeEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShaftTypeEntityFactory)));
					_shaftTypeCollectionViaComponentInspectionReportGearbox_.IsReadOnly=true;
				}
				return _shaftTypeCollectionViaComponentInspectionReportGearbox_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ShrinkElementEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ShrinkElementEntity))]
		public virtual EntityCollection<ShrinkElementEntity> ShrinkElementCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_shrinkElementCollectionViaComponentInspectionReportGearbox==null)
				{
					_shrinkElementCollectionViaComponentInspectionReportGearbox = new EntityCollection<ShrinkElementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ShrinkElementEntityFactory)));
					_shrinkElementCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _shrinkElementCollectionViaComponentInspectionReportGearbox;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'VibrationsEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(VibrationsEntity))]
		public virtual EntityCollection<VibrationsEntity> VibrationsCollectionViaComponentInspectionReportGearbox
		{
			get
			{
				if(_vibrationsCollectionViaComponentInspectionReportGearbox==null)
				{
					_vibrationsCollectionViaComponentInspectionReportGearbox = new EntityCollection<VibrationsEntity>(EntityFactoryCache2.GetEntityFactory(typeof(VibrationsEntityFactory)));
					_vibrationsCollectionViaComponentInspectionReportGearbox.IsReadOnly=true;
				}
				return _vibrationsCollectionViaComponentInspectionReportGearbox;
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
							_noise.UnsetRelatedEntity(this, "Noise_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "Noise_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.NoiseEntity; }
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
