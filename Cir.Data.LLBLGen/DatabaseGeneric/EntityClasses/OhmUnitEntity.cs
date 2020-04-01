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
	/// Entity class which represents the entity 'OhmUnit'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class OhmUnitEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGenerator______;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGenerator_____;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGenerator________;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGenerator_______;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGenerator____;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGenerator_;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGenerator;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGenerator___;
		private EntityCollection<ComponentInspectionReportGeneratorEntity> _componentInspectionReportGenerator__;
		private EntityCollection<OhmUnitEntity> _ohmUnit_;
		private EntityCollection<ActionToBeTakenOnGeneratorEntity> _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______;
		private EntityCollection<ActionToBeTakenOnGeneratorEntity> _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____;
		private EntityCollection<ActionToBeTakenOnGeneratorEntity> _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________;
		private EntityCollection<ActionToBeTakenOnGeneratorEntity> _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______;
		private EntityCollection<ActionToBeTakenOnGeneratorEntity> _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____;
		private EntityCollection<ActionToBeTakenOnGeneratorEntity> _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_;
		private EntityCollection<ActionToBeTakenOnGeneratorEntity> _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<ActionToBeTakenOnGeneratorEntity> _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___;
		private EntityCollection<ActionToBeTakenOnGeneratorEntity> _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGenerator______;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGenerator_____;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGenerator________;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGenerator_______;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGenerator____;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGenerator_;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGenerator___;
		private EntityCollection<BooleanAnswerEntity> _booleanAnswerCollectionViaComponentInspectionReportGenerator__;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGenerator______;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGenerator_____;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGenerator________;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGenerator_______;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGenerator____;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGenerator_;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGenerator___;
		private EntityCollection<ComponentInspectionReportEntity> _componentInspectionReportCollectionViaComponentInspectionReportGenerator__;
		private EntityCollection<CouplingEntity> _couplingCollectionViaComponentInspectionReportGenerator______;
		private EntityCollection<CouplingEntity> _couplingCollectionViaComponentInspectionReportGenerator_____;
		private EntityCollection<CouplingEntity> _couplingCollectionViaComponentInspectionReportGenerator________;
		private EntityCollection<CouplingEntity> _couplingCollectionViaComponentInspectionReportGenerator_______;
		private EntityCollection<CouplingEntity> _couplingCollectionViaComponentInspectionReportGenerator____;
		private EntityCollection<CouplingEntity> _couplingCollectionViaComponentInspectionReportGenerator_;
		private EntityCollection<CouplingEntity> _couplingCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<CouplingEntity> _couplingCollectionViaComponentInspectionReportGenerator___;
		private EntityCollection<CouplingEntity> _couplingCollectionViaComponentInspectionReportGenerator__;
		private EntityCollection<GeneratorCoverEntity> _generatorCoverCollectionViaComponentInspectionReportGenerator______;
		private EntityCollection<GeneratorCoverEntity> _generatorCoverCollectionViaComponentInspectionReportGenerator_____;
		private EntityCollection<GeneratorCoverEntity> _generatorCoverCollectionViaComponentInspectionReportGenerator________;
		private EntityCollection<GeneratorCoverEntity> _generatorCoverCollectionViaComponentInspectionReportGenerator_______;
		private EntityCollection<GeneratorCoverEntity> _generatorCoverCollectionViaComponentInspectionReportGenerator____;
		private EntityCollection<GeneratorCoverEntity> _generatorCoverCollectionViaComponentInspectionReportGenerator_;
		private EntityCollection<GeneratorCoverEntity> _generatorCoverCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<GeneratorCoverEntity> _generatorCoverCollectionViaComponentInspectionReportGenerator___;
		private EntityCollection<GeneratorCoverEntity> _generatorCoverCollectionViaComponentInspectionReportGenerator__;
		private EntityCollection<GeneratorDriveEndEntity> _generatorDriveEndCollectionViaComponentInspectionReportGenerator______;
		private EntityCollection<GeneratorDriveEndEntity> _generatorDriveEndCollectionViaComponentInspectionReportGenerator_____;
		private EntityCollection<GeneratorDriveEndEntity> _generatorDriveEndCollectionViaComponentInspectionReportGenerator________;
		private EntityCollection<GeneratorDriveEndEntity> _generatorDriveEndCollectionViaComponentInspectionReportGenerator_______;
		private EntityCollection<GeneratorDriveEndEntity> _generatorDriveEndCollectionViaComponentInspectionReportGenerator____;
		private EntityCollection<GeneratorDriveEndEntity> _generatorDriveEndCollectionViaComponentInspectionReportGenerator_;
		private EntityCollection<GeneratorDriveEndEntity> _generatorDriveEndCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<GeneratorDriveEndEntity> _generatorDriveEndCollectionViaComponentInspectionReportGenerator___;
		private EntityCollection<GeneratorDriveEndEntity> _generatorDriveEndCollectionViaComponentInspectionReportGenerator__;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGenerator______;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGenerator_____;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGenerator________;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGenerator_______;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGenerator____;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGenerator_;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGenerator___;
		private EntityCollection<GeneratorManufacturerEntity> _generatorManufacturerCollectionViaComponentInspectionReportGenerator__;
		private EntityCollection<GeneratorNonDriveEndEntity> _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______;
		private EntityCollection<GeneratorNonDriveEndEntity> _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____;
		private EntityCollection<GeneratorNonDriveEndEntity> _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________;
		private EntityCollection<GeneratorNonDriveEndEntity> _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______;
		private EntityCollection<GeneratorNonDriveEndEntity> _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____;
		private EntityCollection<GeneratorNonDriveEndEntity> _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_;
		private EntityCollection<GeneratorNonDriveEndEntity> _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<GeneratorNonDriveEndEntity> _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___;
		private EntityCollection<GeneratorNonDriveEndEntity> _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__;
		private EntityCollection<GeneratorRotorEntity> _generatorRotorCollectionViaComponentInspectionReportGenerator______;
		private EntityCollection<GeneratorRotorEntity> _generatorRotorCollectionViaComponentInspectionReportGenerator_____;
		private EntityCollection<GeneratorRotorEntity> _generatorRotorCollectionViaComponentInspectionReportGenerator________;
		private EntityCollection<GeneratorRotorEntity> _generatorRotorCollectionViaComponentInspectionReportGenerator_______;
		private EntityCollection<GeneratorRotorEntity> _generatorRotorCollectionViaComponentInspectionReportGenerator____;
		private EntityCollection<GeneratorRotorEntity> _generatorRotorCollectionViaComponentInspectionReportGenerator_;
		private EntityCollection<GeneratorRotorEntity> _generatorRotorCollectionViaComponentInspectionReportGenerator;
		private EntityCollection<GeneratorRotorEntity> _generatorRotorCollectionViaComponentInspectionReportGenerator___;
		private EntityCollection<GeneratorRotorEntity> _generatorRotorCollectionViaComponentInspectionReportGenerator__;
		private OhmUnitEntity _ohmUnit;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name OhmUnit</summary>
			public static readonly string OhmUnit = "OhmUnit";
			/// <summary>Member name ComponentInspectionReportGenerator______</summary>
			public static readonly string ComponentInspectionReportGenerator______ = "ComponentInspectionReportGenerator______";
			/// <summary>Member name ComponentInspectionReportGenerator_____</summary>
			public static readonly string ComponentInspectionReportGenerator_____ = "ComponentInspectionReportGenerator_____";
			/// <summary>Member name ComponentInspectionReportGenerator________</summary>
			public static readonly string ComponentInspectionReportGenerator________ = "ComponentInspectionReportGenerator________";
			/// <summary>Member name ComponentInspectionReportGenerator_______</summary>
			public static readonly string ComponentInspectionReportGenerator_______ = "ComponentInspectionReportGenerator_______";
			/// <summary>Member name ComponentInspectionReportGenerator____</summary>
			public static readonly string ComponentInspectionReportGenerator____ = "ComponentInspectionReportGenerator____";
			/// <summary>Member name ComponentInspectionReportGenerator_</summary>
			public static readonly string ComponentInspectionReportGenerator_ = "ComponentInspectionReportGenerator_";
			/// <summary>Member name ComponentInspectionReportGenerator</summary>
			public static readonly string ComponentInspectionReportGenerator = "ComponentInspectionReportGenerator";
			/// <summary>Member name ComponentInspectionReportGenerator___</summary>
			public static readonly string ComponentInspectionReportGenerator___ = "ComponentInspectionReportGenerator___";
			/// <summary>Member name ComponentInspectionReportGenerator__</summary>
			public static readonly string ComponentInspectionReportGenerator__ = "ComponentInspectionReportGenerator__";
			/// <summary>Member name OhmUnit_</summary>
			public static readonly string OhmUnit_ = "OhmUnit_";
			/// <summary>Member name ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______</summary>
			public static readonly string ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______ = "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______";
			/// <summary>Member name ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____</summary>
			public static readonly string ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____ = "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____";
			/// <summary>Member name ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________</summary>
			public static readonly string ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________ = "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________";
			/// <summary>Member name ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______</summary>
			public static readonly string ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______ = "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______";
			/// <summary>Member name ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____</summary>
			public static readonly string ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____ = "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____";
			/// <summary>Member name ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_</summary>
			public static readonly string ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_ = "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_";
			/// <summary>Member name ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator = "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___</summary>
			public static readonly string ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___ = "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___";
			/// <summary>Member name ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__</summary>
			public static readonly string ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__ = "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGenerator______</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGenerator______ = "BooleanAnswerCollectionViaComponentInspectionReportGenerator______";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGenerator_____</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGenerator_____ = "BooleanAnswerCollectionViaComponentInspectionReportGenerator_____";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGenerator________</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGenerator________ = "BooleanAnswerCollectionViaComponentInspectionReportGenerator________";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGenerator_______</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGenerator_______ = "BooleanAnswerCollectionViaComponentInspectionReportGenerator_______";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGenerator____</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGenerator____ = "BooleanAnswerCollectionViaComponentInspectionReportGenerator____";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGenerator_</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGenerator_ = "BooleanAnswerCollectionViaComponentInspectionReportGenerator_";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGenerator = "BooleanAnswerCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGenerator___</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGenerator___ = "BooleanAnswerCollectionViaComponentInspectionReportGenerator___";
			/// <summary>Member name BooleanAnswerCollectionViaComponentInspectionReportGenerator__</summary>
			public static readonly string BooleanAnswerCollectionViaComponentInspectionReportGenerator__ = "BooleanAnswerCollectionViaComponentInspectionReportGenerator__";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGenerator______</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGenerator______ = "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator______";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____ = "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGenerator________</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGenerator________ = "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator________";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______ = "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGenerator____</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGenerator____ = "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator____";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_ = "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGenerator = "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGenerator___</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGenerator___ = "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator___";
			/// <summary>Member name ComponentInspectionReportCollectionViaComponentInspectionReportGenerator__</summary>
			public static readonly string ComponentInspectionReportCollectionViaComponentInspectionReportGenerator__ = "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator__";
			/// <summary>Member name CouplingCollectionViaComponentInspectionReportGenerator______</summary>
			public static readonly string CouplingCollectionViaComponentInspectionReportGenerator______ = "CouplingCollectionViaComponentInspectionReportGenerator______";
			/// <summary>Member name CouplingCollectionViaComponentInspectionReportGenerator_____</summary>
			public static readonly string CouplingCollectionViaComponentInspectionReportGenerator_____ = "CouplingCollectionViaComponentInspectionReportGenerator_____";
			/// <summary>Member name CouplingCollectionViaComponentInspectionReportGenerator________</summary>
			public static readonly string CouplingCollectionViaComponentInspectionReportGenerator________ = "CouplingCollectionViaComponentInspectionReportGenerator________";
			/// <summary>Member name CouplingCollectionViaComponentInspectionReportGenerator_______</summary>
			public static readonly string CouplingCollectionViaComponentInspectionReportGenerator_______ = "CouplingCollectionViaComponentInspectionReportGenerator_______";
			/// <summary>Member name CouplingCollectionViaComponentInspectionReportGenerator____</summary>
			public static readonly string CouplingCollectionViaComponentInspectionReportGenerator____ = "CouplingCollectionViaComponentInspectionReportGenerator____";
			/// <summary>Member name CouplingCollectionViaComponentInspectionReportGenerator_</summary>
			public static readonly string CouplingCollectionViaComponentInspectionReportGenerator_ = "CouplingCollectionViaComponentInspectionReportGenerator_";
			/// <summary>Member name CouplingCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string CouplingCollectionViaComponentInspectionReportGenerator = "CouplingCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name CouplingCollectionViaComponentInspectionReportGenerator___</summary>
			public static readonly string CouplingCollectionViaComponentInspectionReportGenerator___ = "CouplingCollectionViaComponentInspectionReportGenerator___";
			/// <summary>Member name CouplingCollectionViaComponentInspectionReportGenerator__</summary>
			public static readonly string CouplingCollectionViaComponentInspectionReportGenerator__ = "CouplingCollectionViaComponentInspectionReportGenerator__";
			/// <summary>Member name GeneratorCoverCollectionViaComponentInspectionReportGenerator______</summary>
			public static readonly string GeneratorCoverCollectionViaComponentInspectionReportGenerator______ = "GeneratorCoverCollectionViaComponentInspectionReportGenerator______";
			/// <summary>Member name GeneratorCoverCollectionViaComponentInspectionReportGenerator_____</summary>
			public static readonly string GeneratorCoverCollectionViaComponentInspectionReportGenerator_____ = "GeneratorCoverCollectionViaComponentInspectionReportGenerator_____";
			/// <summary>Member name GeneratorCoverCollectionViaComponentInspectionReportGenerator________</summary>
			public static readonly string GeneratorCoverCollectionViaComponentInspectionReportGenerator________ = "GeneratorCoverCollectionViaComponentInspectionReportGenerator________";
			/// <summary>Member name GeneratorCoverCollectionViaComponentInspectionReportGenerator_______</summary>
			public static readonly string GeneratorCoverCollectionViaComponentInspectionReportGenerator_______ = "GeneratorCoverCollectionViaComponentInspectionReportGenerator_______";
			/// <summary>Member name GeneratorCoverCollectionViaComponentInspectionReportGenerator____</summary>
			public static readonly string GeneratorCoverCollectionViaComponentInspectionReportGenerator____ = "GeneratorCoverCollectionViaComponentInspectionReportGenerator____";
			/// <summary>Member name GeneratorCoverCollectionViaComponentInspectionReportGenerator_</summary>
			public static readonly string GeneratorCoverCollectionViaComponentInspectionReportGenerator_ = "GeneratorCoverCollectionViaComponentInspectionReportGenerator_";
			/// <summary>Member name GeneratorCoverCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string GeneratorCoverCollectionViaComponentInspectionReportGenerator = "GeneratorCoverCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name GeneratorCoverCollectionViaComponentInspectionReportGenerator___</summary>
			public static readonly string GeneratorCoverCollectionViaComponentInspectionReportGenerator___ = "GeneratorCoverCollectionViaComponentInspectionReportGenerator___";
			/// <summary>Member name GeneratorCoverCollectionViaComponentInspectionReportGenerator__</summary>
			public static readonly string GeneratorCoverCollectionViaComponentInspectionReportGenerator__ = "GeneratorCoverCollectionViaComponentInspectionReportGenerator__";
			/// <summary>Member name GeneratorDriveEndCollectionViaComponentInspectionReportGenerator______</summary>
			public static readonly string GeneratorDriveEndCollectionViaComponentInspectionReportGenerator______ = "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator______";
			/// <summary>Member name GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____</summary>
			public static readonly string GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____ = "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____";
			/// <summary>Member name GeneratorDriveEndCollectionViaComponentInspectionReportGenerator________</summary>
			public static readonly string GeneratorDriveEndCollectionViaComponentInspectionReportGenerator________ = "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator________";
			/// <summary>Member name GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______</summary>
			public static readonly string GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______ = "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______";
			/// <summary>Member name GeneratorDriveEndCollectionViaComponentInspectionReportGenerator____</summary>
			public static readonly string GeneratorDriveEndCollectionViaComponentInspectionReportGenerator____ = "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator____";
			/// <summary>Member name GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_</summary>
			public static readonly string GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_ = "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_";
			/// <summary>Member name GeneratorDriveEndCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string GeneratorDriveEndCollectionViaComponentInspectionReportGenerator = "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name GeneratorDriveEndCollectionViaComponentInspectionReportGenerator___</summary>
			public static readonly string GeneratorDriveEndCollectionViaComponentInspectionReportGenerator___ = "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator___";
			/// <summary>Member name GeneratorDriveEndCollectionViaComponentInspectionReportGenerator__</summary>
			public static readonly string GeneratorDriveEndCollectionViaComponentInspectionReportGenerator__ = "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator__";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGenerator______</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGenerator______ = "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator______";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____ = "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGenerator________</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGenerator________ = "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator________";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______ = "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGenerator____</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGenerator____ = "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator____";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_ = "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGenerator = "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGenerator___</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGenerator___ = "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator___";
			/// <summary>Member name GeneratorManufacturerCollectionViaComponentInspectionReportGenerator__</summary>
			public static readonly string GeneratorManufacturerCollectionViaComponentInspectionReportGenerator__ = "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator__";
			/// <summary>Member name GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______</summary>
			public static readonly string GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______ = "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______";
			/// <summary>Member name GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____</summary>
			public static readonly string GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____ = "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____";
			/// <summary>Member name GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________</summary>
			public static readonly string GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________ = "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________";
			/// <summary>Member name GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______</summary>
			public static readonly string GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______ = "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______";
			/// <summary>Member name GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____</summary>
			public static readonly string GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____ = "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____";
			/// <summary>Member name GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_</summary>
			public static readonly string GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_ = "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_";
			/// <summary>Member name GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator = "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___</summary>
			public static readonly string GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___ = "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___";
			/// <summary>Member name GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__</summary>
			public static readonly string GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__ = "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__";
			/// <summary>Member name GeneratorRotorCollectionViaComponentInspectionReportGenerator______</summary>
			public static readonly string GeneratorRotorCollectionViaComponentInspectionReportGenerator______ = "GeneratorRotorCollectionViaComponentInspectionReportGenerator______";
			/// <summary>Member name GeneratorRotorCollectionViaComponentInspectionReportGenerator_____</summary>
			public static readonly string GeneratorRotorCollectionViaComponentInspectionReportGenerator_____ = "GeneratorRotorCollectionViaComponentInspectionReportGenerator_____";
			/// <summary>Member name GeneratorRotorCollectionViaComponentInspectionReportGenerator________</summary>
			public static readonly string GeneratorRotorCollectionViaComponentInspectionReportGenerator________ = "GeneratorRotorCollectionViaComponentInspectionReportGenerator________";
			/// <summary>Member name GeneratorRotorCollectionViaComponentInspectionReportGenerator_______</summary>
			public static readonly string GeneratorRotorCollectionViaComponentInspectionReportGenerator_______ = "GeneratorRotorCollectionViaComponentInspectionReportGenerator_______";
			/// <summary>Member name GeneratorRotorCollectionViaComponentInspectionReportGenerator____</summary>
			public static readonly string GeneratorRotorCollectionViaComponentInspectionReportGenerator____ = "GeneratorRotorCollectionViaComponentInspectionReportGenerator____";
			/// <summary>Member name GeneratorRotorCollectionViaComponentInspectionReportGenerator_</summary>
			public static readonly string GeneratorRotorCollectionViaComponentInspectionReportGenerator_ = "GeneratorRotorCollectionViaComponentInspectionReportGenerator_";
			/// <summary>Member name GeneratorRotorCollectionViaComponentInspectionReportGenerator</summary>
			public static readonly string GeneratorRotorCollectionViaComponentInspectionReportGenerator = "GeneratorRotorCollectionViaComponentInspectionReportGenerator";
			/// <summary>Member name GeneratorRotorCollectionViaComponentInspectionReportGenerator___</summary>
			public static readonly string GeneratorRotorCollectionViaComponentInspectionReportGenerator___ = "GeneratorRotorCollectionViaComponentInspectionReportGenerator___";
			/// <summary>Member name GeneratorRotorCollectionViaComponentInspectionReportGenerator__</summary>
			public static readonly string GeneratorRotorCollectionViaComponentInspectionReportGenerator__ = "GeneratorRotorCollectionViaComponentInspectionReportGenerator__";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static OhmUnitEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public OhmUnitEntity():base("OhmUnitEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public OhmUnitEntity(IEntityFields2 fields):base("OhmUnitEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this OhmUnitEntity</param>
		public OhmUnitEntity(IValidator validator):base("OhmUnitEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="ohmUnitId">PK value for OhmUnit which data should be fetched into this OhmUnit object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OhmUnitEntity(System.Int64 ohmUnitId):base("OhmUnitEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.OhmUnitId = ohmUnitId;
		}

		/// <summary> CTor</summary>
		/// <param name="ohmUnitId">PK value for OhmUnit which data should be fetched into this OhmUnit object</param>
		/// <param name="validator">The custom validator object for this OhmUnitEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public OhmUnitEntity(System.Int64 ohmUnitId, IValidator validator):base("OhmUnitEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.OhmUnitId = ohmUnitId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected OhmUnitEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_componentInspectionReportGenerator______ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGenerator______", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGenerator_____ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGenerator_____", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGenerator________ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGenerator________", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGenerator_______ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGenerator_______", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGenerator____ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGenerator____", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGenerator_ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGenerator_", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGenerator = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGenerator", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGenerator___ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGenerator___", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_componentInspectionReportGenerator__ = (EntityCollection<ComponentInspectionReportGeneratorEntity>)info.GetValue("_componentInspectionReportGenerator__", typeof(EntityCollection<ComponentInspectionReportGeneratorEntity>));
				_ohmUnit_ = (EntityCollection<OhmUnitEntity>)info.GetValue("_ohmUnit_", typeof(EntityCollection<OhmUnitEntity>));
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>)info.GetValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______", typeof(EntityCollection<ActionToBeTakenOnGeneratorEntity>));
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>)info.GetValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____", typeof(EntityCollection<ActionToBeTakenOnGeneratorEntity>));
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>)info.GetValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________", typeof(EntityCollection<ActionToBeTakenOnGeneratorEntity>));
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>)info.GetValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______", typeof(EntityCollection<ActionToBeTakenOnGeneratorEntity>));
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>)info.GetValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____", typeof(EntityCollection<ActionToBeTakenOnGeneratorEntity>));
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>)info.GetValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_", typeof(EntityCollection<ActionToBeTakenOnGeneratorEntity>));
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator = (EntityCollection<ActionToBeTakenOnGeneratorEntity>)info.GetValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<ActionToBeTakenOnGeneratorEntity>));
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>)info.GetValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___", typeof(EntityCollection<ActionToBeTakenOnGeneratorEntity>));
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>)info.GetValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__", typeof(EntityCollection<ActionToBeTakenOnGeneratorEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator______", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator_____", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator________", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator_______", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator____", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator_", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGenerator = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator___", typeof(EntityCollection<BooleanAnswerEntity>));
				_booleanAnswerCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<BooleanAnswerEntity>)info.GetValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator__", typeof(EntityCollection<BooleanAnswerEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator______", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator________", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator____", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator_", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator___", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<ComponentInspectionReportEntity>)info.GetValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator__", typeof(EntityCollection<ComponentInspectionReportEntity>));
				_couplingCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<CouplingEntity>)info.GetValue("_couplingCollectionViaComponentInspectionReportGenerator______", typeof(EntityCollection<CouplingEntity>));
				_couplingCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<CouplingEntity>)info.GetValue("_couplingCollectionViaComponentInspectionReportGenerator_____", typeof(EntityCollection<CouplingEntity>));
				_couplingCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<CouplingEntity>)info.GetValue("_couplingCollectionViaComponentInspectionReportGenerator________", typeof(EntityCollection<CouplingEntity>));
				_couplingCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<CouplingEntity>)info.GetValue("_couplingCollectionViaComponentInspectionReportGenerator_______", typeof(EntityCollection<CouplingEntity>));
				_couplingCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<CouplingEntity>)info.GetValue("_couplingCollectionViaComponentInspectionReportGenerator____", typeof(EntityCollection<CouplingEntity>));
				_couplingCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<CouplingEntity>)info.GetValue("_couplingCollectionViaComponentInspectionReportGenerator_", typeof(EntityCollection<CouplingEntity>));
				_couplingCollectionViaComponentInspectionReportGenerator = (EntityCollection<CouplingEntity>)info.GetValue("_couplingCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<CouplingEntity>));
				_couplingCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<CouplingEntity>)info.GetValue("_couplingCollectionViaComponentInspectionReportGenerator___", typeof(EntityCollection<CouplingEntity>));
				_couplingCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<CouplingEntity>)info.GetValue("_couplingCollectionViaComponentInspectionReportGenerator__", typeof(EntityCollection<CouplingEntity>));
				_generatorCoverCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<GeneratorCoverEntity>)info.GetValue("_generatorCoverCollectionViaComponentInspectionReportGenerator______", typeof(EntityCollection<GeneratorCoverEntity>));
				_generatorCoverCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<GeneratorCoverEntity>)info.GetValue("_generatorCoverCollectionViaComponentInspectionReportGenerator_____", typeof(EntityCollection<GeneratorCoverEntity>));
				_generatorCoverCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<GeneratorCoverEntity>)info.GetValue("_generatorCoverCollectionViaComponentInspectionReportGenerator________", typeof(EntityCollection<GeneratorCoverEntity>));
				_generatorCoverCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<GeneratorCoverEntity>)info.GetValue("_generatorCoverCollectionViaComponentInspectionReportGenerator_______", typeof(EntityCollection<GeneratorCoverEntity>));
				_generatorCoverCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<GeneratorCoverEntity>)info.GetValue("_generatorCoverCollectionViaComponentInspectionReportGenerator____", typeof(EntityCollection<GeneratorCoverEntity>));
				_generatorCoverCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<GeneratorCoverEntity>)info.GetValue("_generatorCoverCollectionViaComponentInspectionReportGenerator_", typeof(EntityCollection<GeneratorCoverEntity>));
				_generatorCoverCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorCoverEntity>)info.GetValue("_generatorCoverCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<GeneratorCoverEntity>));
				_generatorCoverCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<GeneratorCoverEntity>)info.GetValue("_generatorCoverCollectionViaComponentInspectionReportGenerator___", typeof(EntityCollection<GeneratorCoverEntity>));
				_generatorCoverCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<GeneratorCoverEntity>)info.GetValue("_generatorCoverCollectionViaComponentInspectionReportGenerator__", typeof(EntityCollection<GeneratorCoverEntity>));
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<GeneratorDriveEndEntity>)info.GetValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator______", typeof(EntityCollection<GeneratorDriveEndEntity>));
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<GeneratorDriveEndEntity>)info.GetValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____", typeof(EntityCollection<GeneratorDriveEndEntity>));
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<GeneratorDriveEndEntity>)info.GetValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator________", typeof(EntityCollection<GeneratorDriveEndEntity>));
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<GeneratorDriveEndEntity>)info.GetValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______", typeof(EntityCollection<GeneratorDriveEndEntity>));
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<GeneratorDriveEndEntity>)info.GetValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator____", typeof(EntityCollection<GeneratorDriveEndEntity>));
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<GeneratorDriveEndEntity>)info.GetValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator_", typeof(EntityCollection<GeneratorDriveEndEntity>));
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorDriveEndEntity>)info.GetValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<GeneratorDriveEndEntity>));
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<GeneratorDriveEndEntity>)info.GetValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator___", typeof(EntityCollection<GeneratorDriveEndEntity>));
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<GeneratorDriveEndEntity>)info.GetValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator__", typeof(EntityCollection<GeneratorDriveEndEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator______", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator________", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator____", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator_", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator___", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<GeneratorManufacturerEntity>)info.GetValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator__", typeof(EntityCollection<GeneratorManufacturerEntity>));
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<GeneratorNonDriveEndEntity>)info.GetValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______", typeof(EntityCollection<GeneratorNonDriveEndEntity>));
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<GeneratorNonDriveEndEntity>)info.GetValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____", typeof(EntityCollection<GeneratorNonDriveEndEntity>));
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<GeneratorNonDriveEndEntity>)info.GetValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________", typeof(EntityCollection<GeneratorNonDriveEndEntity>));
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<GeneratorNonDriveEndEntity>)info.GetValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______", typeof(EntityCollection<GeneratorNonDriveEndEntity>));
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<GeneratorNonDriveEndEntity>)info.GetValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____", typeof(EntityCollection<GeneratorNonDriveEndEntity>));
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<GeneratorNonDriveEndEntity>)info.GetValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_", typeof(EntityCollection<GeneratorNonDriveEndEntity>));
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorNonDriveEndEntity>)info.GetValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<GeneratorNonDriveEndEntity>));
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<GeneratorNonDriveEndEntity>)info.GetValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___", typeof(EntityCollection<GeneratorNonDriveEndEntity>));
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<GeneratorNonDriveEndEntity>)info.GetValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__", typeof(EntityCollection<GeneratorNonDriveEndEntity>));
				_generatorRotorCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<GeneratorRotorEntity>)info.GetValue("_generatorRotorCollectionViaComponentInspectionReportGenerator______", typeof(EntityCollection<GeneratorRotorEntity>));
				_generatorRotorCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<GeneratorRotorEntity>)info.GetValue("_generatorRotorCollectionViaComponentInspectionReportGenerator_____", typeof(EntityCollection<GeneratorRotorEntity>));
				_generatorRotorCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<GeneratorRotorEntity>)info.GetValue("_generatorRotorCollectionViaComponentInspectionReportGenerator________", typeof(EntityCollection<GeneratorRotorEntity>));
				_generatorRotorCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<GeneratorRotorEntity>)info.GetValue("_generatorRotorCollectionViaComponentInspectionReportGenerator_______", typeof(EntityCollection<GeneratorRotorEntity>));
				_generatorRotorCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<GeneratorRotorEntity>)info.GetValue("_generatorRotorCollectionViaComponentInspectionReportGenerator____", typeof(EntityCollection<GeneratorRotorEntity>));
				_generatorRotorCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<GeneratorRotorEntity>)info.GetValue("_generatorRotorCollectionViaComponentInspectionReportGenerator_", typeof(EntityCollection<GeneratorRotorEntity>));
				_generatorRotorCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorRotorEntity>)info.GetValue("_generatorRotorCollectionViaComponentInspectionReportGenerator", typeof(EntityCollection<GeneratorRotorEntity>));
				_generatorRotorCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<GeneratorRotorEntity>)info.GetValue("_generatorRotorCollectionViaComponentInspectionReportGenerator___", typeof(EntityCollection<GeneratorRotorEntity>));
				_generatorRotorCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<GeneratorRotorEntity>)info.GetValue("_generatorRotorCollectionViaComponentInspectionReportGenerator__", typeof(EntityCollection<GeneratorRotorEntity>));
				_ohmUnit = (OhmUnitEntity)info.GetValue("_ohmUnit", typeof(OhmUnitEntity));
				if(_ohmUnit!=null)
				{
					_ohmUnit.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((OhmUnitFieldIndex)fieldIndex)
			{
				case OhmUnitFieldIndex.ParentOhmUnitId:
					DesetupSyncOhmUnit(true, false);
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
				case "OhmUnit":
					this.OhmUnit = (OhmUnitEntity)entity;
					break;
				case "ComponentInspectionReportGenerator______":
					this.ComponentInspectionReportGenerator______.Add((ComponentInspectionReportGeneratorEntity)entity);
					break;
				case "ComponentInspectionReportGenerator_____":
					this.ComponentInspectionReportGenerator_____.Add((ComponentInspectionReportGeneratorEntity)entity);
					break;
				case "ComponentInspectionReportGenerator________":
					this.ComponentInspectionReportGenerator________.Add((ComponentInspectionReportGeneratorEntity)entity);
					break;
				case "ComponentInspectionReportGenerator_______":
					this.ComponentInspectionReportGenerator_______.Add((ComponentInspectionReportGeneratorEntity)entity);
					break;
				case "ComponentInspectionReportGenerator____":
					this.ComponentInspectionReportGenerator____.Add((ComponentInspectionReportGeneratorEntity)entity);
					break;
				case "ComponentInspectionReportGenerator_":
					this.ComponentInspectionReportGenerator_.Add((ComponentInspectionReportGeneratorEntity)entity);
					break;
				case "ComponentInspectionReportGenerator":
					this.ComponentInspectionReportGenerator.Add((ComponentInspectionReportGeneratorEntity)entity);
					break;
				case "ComponentInspectionReportGenerator___":
					this.ComponentInspectionReportGenerator___.Add((ComponentInspectionReportGeneratorEntity)entity);
					break;
				case "ComponentInspectionReportGenerator__":
					this.ComponentInspectionReportGenerator__.Add((ComponentInspectionReportGeneratorEntity)entity);
					break;
				case "OhmUnit_":
					this.OhmUnit_.Add((OhmUnitEntity)entity);
					break;
				case "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______":
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______.IsReadOnly = false;
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______.Add((ActionToBeTakenOnGeneratorEntity)entity);
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______.IsReadOnly = true;
					break;
				case "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____":
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = false;
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____.Add((ActionToBeTakenOnGeneratorEntity)entity);
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = true;
					break;
				case "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________":
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________.IsReadOnly = false;
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________.Add((ActionToBeTakenOnGeneratorEntity)entity);
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________.IsReadOnly = true;
					break;
				case "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______":
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = false;
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______.Add((ActionToBeTakenOnGeneratorEntity)entity);
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = true;
					break;
				case "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____":
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____.IsReadOnly = false;
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____.Add((ActionToBeTakenOnGeneratorEntity)entity);
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____.IsReadOnly = true;
					break;
				case "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_":
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_.IsReadOnly = false;
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_.Add((ActionToBeTakenOnGeneratorEntity)entity);
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_.IsReadOnly = true;
					break;
				case "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator":
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.Add((ActionToBeTakenOnGeneratorEntity)entity);
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___":
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___.IsReadOnly = false;
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___.Add((ActionToBeTakenOnGeneratorEntity)entity);
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___.IsReadOnly = true;
					break;
				case "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__":
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__.IsReadOnly = false;
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__.Add((ActionToBeTakenOnGeneratorEntity)entity);
					this.ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGenerator______":
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator______.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator______.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator______.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGenerator_____":
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator_____.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGenerator________":
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator________.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator________.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator________.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGenerator_______":
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator_______.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGenerator____":
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator____.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator____.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator____.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGenerator_":
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator_.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator_.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator_.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGenerator":
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGenerator___":
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator___.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator___.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator___.IsReadOnly = true;
					break;
				case "BooleanAnswerCollectionViaComponentInspectionReportGenerator__":
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator__.IsReadOnly = false;
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator__.Add((BooleanAnswerEntity)entity);
					this.BooleanAnswerCollectionViaComponentInspectionReportGenerator__.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator______":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator______.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator______.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator______.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator________":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator________.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator________.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator________.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator____":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator____.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator____.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator____.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator___":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator___.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator___.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator___.IsReadOnly = true;
					break;
				case "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator__":
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator__.IsReadOnly = false;
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator__.Add((ComponentInspectionReportEntity)entity);
					this.ComponentInspectionReportCollectionViaComponentInspectionReportGenerator__.IsReadOnly = true;
					break;
				case "CouplingCollectionViaComponentInspectionReportGenerator______":
					this.CouplingCollectionViaComponentInspectionReportGenerator______.IsReadOnly = false;
					this.CouplingCollectionViaComponentInspectionReportGenerator______.Add((CouplingEntity)entity);
					this.CouplingCollectionViaComponentInspectionReportGenerator______.IsReadOnly = true;
					break;
				case "CouplingCollectionViaComponentInspectionReportGenerator_____":
					this.CouplingCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = false;
					this.CouplingCollectionViaComponentInspectionReportGenerator_____.Add((CouplingEntity)entity);
					this.CouplingCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = true;
					break;
				case "CouplingCollectionViaComponentInspectionReportGenerator________":
					this.CouplingCollectionViaComponentInspectionReportGenerator________.IsReadOnly = false;
					this.CouplingCollectionViaComponentInspectionReportGenerator________.Add((CouplingEntity)entity);
					this.CouplingCollectionViaComponentInspectionReportGenerator________.IsReadOnly = true;
					break;
				case "CouplingCollectionViaComponentInspectionReportGenerator_______":
					this.CouplingCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = false;
					this.CouplingCollectionViaComponentInspectionReportGenerator_______.Add((CouplingEntity)entity);
					this.CouplingCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = true;
					break;
				case "CouplingCollectionViaComponentInspectionReportGenerator____":
					this.CouplingCollectionViaComponentInspectionReportGenerator____.IsReadOnly = false;
					this.CouplingCollectionViaComponentInspectionReportGenerator____.Add((CouplingEntity)entity);
					this.CouplingCollectionViaComponentInspectionReportGenerator____.IsReadOnly = true;
					break;
				case "CouplingCollectionViaComponentInspectionReportGenerator_":
					this.CouplingCollectionViaComponentInspectionReportGenerator_.IsReadOnly = false;
					this.CouplingCollectionViaComponentInspectionReportGenerator_.Add((CouplingEntity)entity);
					this.CouplingCollectionViaComponentInspectionReportGenerator_.IsReadOnly = true;
					break;
				case "CouplingCollectionViaComponentInspectionReportGenerator":
					this.CouplingCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.CouplingCollectionViaComponentInspectionReportGenerator.Add((CouplingEntity)entity);
					this.CouplingCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "CouplingCollectionViaComponentInspectionReportGenerator___":
					this.CouplingCollectionViaComponentInspectionReportGenerator___.IsReadOnly = false;
					this.CouplingCollectionViaComponentInspectionReportGenerator___.Add((CouplingEntity)entity);
					this.CouplingCollectionViaComponentInspectionReportGenerator___.IsReadOnly = true;
					break;
				case "CouplingCollectionViaComponentInspectionReportGenerator__":
					this.CouplingCollectionViaComponentInspectionReportGenerator__.IsReadOnly = false;
					this.CouplingCollectionViaComponentInspectionReportGenerator__.Add((CouplingEntity)entity);
					this.CouplingCollectionViaComponentInspectionReportGenerator__.IsReadOnly = true;
					break;
				case "GeneratorCoverCollectionViaComponentInspectionReportGenerator______":
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator______.IsReadOnly = false;
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator______.Add((GeneratorCoverEntity)entity);
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator______.IsReadOnly = true;
					break;
				case "GeneratorCoverCollectionViaComponentInspectionReportGenerator_____":
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = false;
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator_____.Add((GeneratorCoverEntity)entity);
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = true;
					break;
				case "GeneratorCoverCollectionViaComponentInspectionReportGenerator________":
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator________.IsReadOnly = false;
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator________.Add((GeneratorCoverEntity)entity);
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator________.IsReadOnly = true;
					break;
				case "GeneratorCoverCollectionViaComponentInspectionReportGenerator_______":
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = false;
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator_______.Add((GeneratorCoverEntity)entity);
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = true;
					break;
				case "GeneratorCoverCollectionViaComponentInspectionReportGenerator____":
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator____.IsReadOnly = false;
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator____.Add((GeneratorCoverEntity)entity);
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator____.IsReadOnly = true;
					break;
				case "GeneratorCoverCollectionViaComponentInspectionReportGenerator_":
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator_.IsReadOnly = false;
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator_.Add((GeneratorCoverEntity)entity);
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator_.IsReadOnly = true;
					break;
				case "GeneratorCoverCollectionViaComponentInspectionReportGenerator":
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator.Add((GeneratorCoverEntity)entity);
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "GeneratorCoverCollectionViaComponentInspectionReportGenerator___":
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator___.IsReadOnly = false;
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator___.Add((GeneratorCoverEntity)entity);
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator___.IsReadOnly = true;
					break;
				case "GeneratorCoverCollectionViaComponentInspectionReportGenerator__":
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator__.IsReadOnly = false;
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator__.Add((GeneratorCoverEntity)entity);
					this.GeneratorCoverCollectionViaComponentInspectionReportGenerator__.IsReadOnly = true;
					break;
				case "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator______":
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator______.IsReadOnly = false;
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator______.Add((GeneratorDriveEndEntity)entity);
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator______.IsReadOnly = true;
					break;
				case "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____":
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = false;
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____.Add((GeneratorDriveEndEntity)entity);
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = true;
					break;
				case "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator________":
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator________.IsReadOnly = false;
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator________.Add((GeneratorDriveEndEntity)entity);
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator________.IsReadOnly = true;
					break;
				case "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______":
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = false;
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______.Add((GeneratorDriveEndEntity)entity);
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = true;
					break;
				case "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator____":
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator____.IsReadOnly = false;
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator____.Add((GeneratorDriveEndEntity)entity);
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator____.IsReadOnly = true;
					break;
				case "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_":
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_.IsReadOnly = false;
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_.Add((GeneratorDriveEndEntity)entity);
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_.IsReadOnly = true;
					break;
				case "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator":
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator.Add((GeneratorDriveEndEntity)entity);
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator___":
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator___.IsReadOnly = false;
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator___.Add((GeneratorDriveEndEntity)entity);
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator___.IsReadOnly = true;
					break;
				case "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator__":
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator__.IsReadOnly = false;
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator__.Add((GeneratorDriveEndEntity)entity);
					this.GeneratorDriveEndCollectionViaComponentInspectionReportGenerator__.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator______":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator______.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator______.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator______.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator________":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator________.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator________.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator________.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator____":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator____.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator____.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator____.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator___":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator___.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator___.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator___.IsReadOnly = true;
					break;
				case "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator__":
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator__.IsReadOnly = false;
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator__.Add((GeneratorManufacturerEntity)entity);
					this.GeneratorManufacturerCollectionViaComponentInspectionReportGenerator__.IsReadOnly = true;
					break;
				case "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______":
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______.IsReadOnly = false;
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______.Add((GeneratorNonDriveEndEntity)entity);
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______.IsReadOnly = true;
					break;
				case "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____":
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = false;
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____.Add((GeneratorNonDriveEndEntity)entity);
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = true;
					break;
				case "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________":
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________.IsReadOnly = false;
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________.Add((GeneratorNonDriveEndEntity)entity);
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________.IsReadOnly = true;
					break;
				case "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______":
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = false;
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______.Add((GeneratorNonDriveEndEntity)entity);
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = true;
					break;
				case "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____":
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____.IsReadOnly = false;
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____.Add((GeneratorNonDriveEndEntity)entity);
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____.IsReadOnly = true;
					break;
				case "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_":
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_.IsReadOnly = false;
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_.Add((GeneratorNonDriveEndEntity)entity);
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_.IsReadOnly = true;
					break;
				case "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator":
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator.Add((GeneratorNonDriveEndEntity)entity);
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___":
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___.IsReadOnly = false;
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___.Add((GeneratorNonDriveEndEntity)entity);
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___.IsReadOnly = true;
					break;
				case "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__":
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__.IsReadOnly = false;
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__.Add((GeneratorNonDriveEndEntity)entity);
					this.GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__.IsReadOnly = true;
					break;
				case "GeneratorRotorCollectionViaComponentInspectionReportGenerator______":
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator______.IsReadOnly = false;
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator______.Add((GeneratorRotorEntity)entity);
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator______.IsReadOnly = true;
					break;
				case "GeneratorRotorCollectionViaComponentInspectionReportGenerator_____":
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = false;
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator_____.Add((GeneratorRotorEntity)entity);
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator_____.IsReadOnly = true;
					break;
				case "GeneratorRotorCollectionViaComponentInspectionReportGenerator________":
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator________.IsReadOnly = false;
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator________.Add((GeneratorRotorEntity)entity);
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator________.IsReadOnly = true;
					break;
				case "GeneratorRotorCollectionViaComponentInspectionReportGenerator_______":
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = false;
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator_______.Add((GeneratorRotorEntity)entity);
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator_______.IsReadOnly = true;
					break;
				case "GeneratorRotorCollectionViaComponentInspectionReportGenerator____":
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator____.IsReadOnly = false;
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator____.Add((GeneratorRotorEntity)entity);
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator____.IsReadOnly = true;
					break;
				case "GeneratorRotorCollectionViaComponentInspectionReportGenerator_":
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator_.IsReadOnly = false;
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator_.Add((GeneratorRotorEntity)entity);
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator_.IsReadOnly = true;
					break;
				case "GeneratorRotorCollectionViaComponentInspectionReportGenerator":
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator.IsReadOnly = false;
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator.Add((GeneratorRotorEntity)entity);
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator.IsReadOnly = true;
					break;
				case "GeneratorRotorCollectionViaComponentInspectionReportGenerator___":
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator___.IsReadOnly = false;
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator___.Add((GeneratorRotorEntity)entity);
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator___.IsReadOnly = true;
					break;
				case "GeneratorRotorCollectionViaComponentInspectionReportGenerator__":
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator__.IsReadOnly = false;
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator__.Add((GeneratorRotorEntity)entity);
					this.GeneratorRotorCollectionViaComponentInspectionReportGenerator__.IsReadOnly = true;
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
				case "OhmUnit":
					SetupSyncOhmUnit(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator______":
					this.ComponentInspectionReportGenerator______.Add((ComponentInspectionReportGeneratorEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator_____":
					this.ComponentInspectionReportGenerator_____.Add((ComponentInspectionReportGeneratorEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator________":
					this.ComponentInspectionReportGenerator________.Add((ComponentInspectionReportGeneratorEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator_______":
					this.ComponentInspectionReportGenerator_______.Add((ComponentInspectionReportGeneratorEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator____":
					this.ComponentInspectionReportGenerator____.Add((ComponentInspectionReportGeneratorEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator_":
					this.ComponentInspectionReportGenerator_.Add((ComponentInspectionReportGeneratorEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator":
					this.ComponentInspectionReportGenerator.Add((ComponentInspectionReportGeneratorEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator___":
					this.ComponentInspectionReportGenerator___.Add((ComponentInspectionReportGeneratorEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator__":
					this.ComponentInspectionReportGenerator__.Add((ComponentInspectionReportGeneratorEntity)relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "OhmUnit_":
					this.OhmUnit_.Add((OhmUnitEntity)relatedEntity);
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
				case "OhmUnit":
					DesetupSyncOhmUnit(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator______":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGenerator______, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator_____":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGenerator_____, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator________":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGenerator________, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator_______":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGenerator_______, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator____":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGenerator____, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator_":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGenerator_, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGenerator, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator___":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGenerator___, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportGenerator__":
					base.PerformRelatedEntityRemoval(this.ComponentInspectionReportGenerator__, relatedEntity, signalRelatedEntityManyToOne);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "OhmUnit_":
					base.PerformRelatedEntityRemoval(this.OhmUnit_, relatedEntity, signalRelatedEntityManyToOne);
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
			if(_ohmUnit!=null)
			{
				toReturn.Add(_ohmUnit);
			}

			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.ComponentInspectionReportGenerator______);
			toReturn.Add(this.ComponentInspectionReportGenerator_____);
			toReturn.Add(this.ComponentInspectionReportGenerator________);
			toReturn.Add(this.ComponentInspectionReportGenerator_______);
			toReturn.Add(this.ComponentInspectionReportGenerator____);
			toReturn.Add(this.ComponentInspectionReportGenerator_);
			toReturn.Add(this.ComponentInspectionReportGenerator);
			toReturn.Add(this.ComponentInspectionReportGenerator___);
			toReturn.Add(this.ComponentInspectionReportGenerator__);
			toReturn.Add(this.OhmUnit_);

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
				info.AddValue("_componentInspectionReportGenerator______", ((_componentInspectionReportGenerator______!=null) && (_componentInspectionReportGenerator______.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGenerator______:null);
				info.AddValue("_componentInspectionReportGenerator_____", ((_componentInspectionReportGenerator_____!=null) && (_componentInspectionReportGenerator_____.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGenerator_____:null);
				info.AddValue("_componentInspectionReportGenerator________", ((_componentInspectionReportGenerator________!=null) && (_componentInspectionReportGenerator________.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGenerator________:null);
				info.AddValue("_componentInspectionReportGenerator_______", ((_componentInspectionReportGenerator_______!=null) && (_componentInspectionReportGenerator_______.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGenerator_______:null);
				info.AddValue("_componentInspectionReportGenerator____", ((_componentInspectionReportGenerator____!=null) && (_componentInspectionReportGenerator____.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGenerator____:null);
				info.AddValue("_componentInspectionReportGenerator_", ((_componentInspectionReportGenerator_!=null) && (_componentInspectionReportGenerator_.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGenerator_:null);
				info.AddValue("_componentInspectionReportGenerator", ((_componentInspectionReportGenerator!=null) && (_componentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGenerator:null);
				info.AddValue("_componentInspectionReportGenerator___", ((_componentInspectionReportGenerator___!=null) && (_componentInspectionReportGenerator___.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGenerator___:null);
				info.AddValue("_componentInspectionReportGenerator__", ((_componentInspectionReportGenerator__!=null) && (_componentInspectionReportGenerator__.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportGenerator__:null);
				info.AddValue("_ohmUnit_", ((_ohmUnit_!=null) && (_ohmUnit_.Count>0) && !this.MarkedForDeletion)?_ohmUnit_:null);
				info.AddValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______", ((_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______!=null) && (_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______.Count>0) && !this.MarkedForDeletion)?_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______:null);
				info.AddValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____", ((_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____!=null) && (_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____.Count>0) && !this.MarkedForDeletion)?_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____:null);
				info.AddValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________", ((_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________!=null) && (_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________.Count>0) && !this.MarkedForDeletion)?_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________:null);
				info.AddValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______", ((_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______!=null) && (_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______.Count>0) && !this.MarkedForDeletion)?_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______:null);
				info.AddValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____", ((_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____!=null) && (_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____.Count>0) && !this.MarkedForDeletion)?_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____:null);
				info.AddValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_", ((_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_!=null) && (_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_.Count>0) && !this.MarkedForDeletion)?_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_:null);
				info.AddValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator", ((_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator!=null) && (_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___", ((_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___!=null) && (_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___.Count>0) && !this.MarkedForDeletion)?_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___:null);
				info.AddValue("_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__", ((_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__!=null) && (_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__.Count>0) && !this.MarkedForDeletion)?_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator______", ((_booleanAnswerCollectionViaComponentInspectionReportGenerator______!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGenerator______.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGenerator______:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator_____", ((_booleanAnswerCollectionViaComponentInspectionReportGenerator_____!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGenerator_____.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGenerator_____:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator________", ((_booleanAnswerCollectionViaComponentInspectionReportGenerator________!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGenerator________.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGenerator________:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator_______", ((_booleanAnswerCollectionViaComponentInspectionReportGenerator_______!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGenerator_______.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGenerator_______:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator____", ((_booleanAnswerCollectionViaComponentInspectionReportGenerator____!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGenerator____.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGenerator____:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator_", ((_booleanAnswerCollectionViaComponentInspectionReportGenerator_!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGenerator_.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGenerator_:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator", ((_booleanAnswerCollectionViaComponentInspectionReportGenerator!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator___", ((_booleanAnswerCollectionViaComponentInspectionReportGenerator___!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGenerator___.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGenerator___:null);
				info.AddValue("_booleanAnswerCollectionViaComponentInspectionReportGenerator__", ((_booleanAnswerCollectionViaComponentInspectionReportGenerator__!=null) && (_booleanAnswerCollectionViaComponentInspectionReportGenerator__.Count>0) && !this.MarkedForDeletion)?_booleanAnswerCollectionViaComponentInspectionReportGenerator__:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator______", ((_componentInspectionReportCollectionViaComponentInspectionReportGenerator______!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGenerator______.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGenerator______:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____", ((_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator________", ((_componentInspectionReportCollectionViaComponentInspectionReportGenerator________!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGenerator________.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGenerator________:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______", ((_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator____", ((_componentInspectionReportCollectionViaComponentInspectionReportGenerator____!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGenerator____.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGenerator____:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator_", ((_componentInspectionReportCollectionViaComponentInspectionReportGenerator_!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGenerator_.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGenerator_:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator", ((_componentInspectionReportCollectionViaComponentInspectionReportGenerator!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator___", ((_componentInspectionReportCollectionViaComponentInspectionReportGenerator___!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGenerator___.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGenerator___:null);
				info.AddValue("_componentInspectionReportCollectionViaComponentInspectionReportGenerator__", ((_componentInspectionReportCollectionViaComponentInspectionReportGenerator__!=null) && (_componentInspectionReportCollectionViaComponentInspectionReportGenerator__.Count>0) && !this.MarkedForDeletion)?_componentInspectionReportCollectionViaComponentInspectionReportGenerator__:null);
				info.AddValue("_couplingCollectionViaComponentInspectionReportGenerator______", ((_couplingCollectionViaComponentInspectionReportGenerator______!=null) && (_couplingCollectionViaComponentInspectionReportGenerator______.Count>0) && !this.MarkedForDeletion)?_couplingCollectionViaComponentInspectionReportGenerator______:null);
				info.AddValue("_couplingCollectionViaComponentInspectionReportGenerator_____", ((_couplingCollectionViaComponentInspectionReportGenerator_____!=null) && (_couplingCollectionViaComponentInspectionReportGenerator_____.Count>0) && !this.MarkedForDeletion)?_couplingCollectionViaComponentInspectionReportGenerator_____:null);
				info.AddValue("_couplingCollectionViaComponentInspectionReportGenerator________", ((_couplingCollectionViaComponentInspectionReportGenerator________!=null) && (_couplingCollectionViaComponentInspectionReportGenerator________.Count>0) && !this.MarkedForDeletion)?_couplingCollectionViaComponentInspectionReportGenerator________:null);
				info.AddValue("_couplingCollectionViaComponentInspectionReportGenerator_______", ((_couplingCollectionViaComponentInspectionReportGenerator_______!=null) && (_couplingCollectionViaComponentInspectionReportGenerator_______.Count>0) && !this.MarkedForDeletion)?_couplingCollectionViaComponentInspectionReportGenerator_______:null);
				info.AddValue("_couplingCollectionViaComponentInspectionReportGenerator____", ((_couplingCollectionViaComponentInspectionReportGenerator____!=null) && (_couplingCollectionViaComponentInspectionReportGenerator____.Count>0) && !this.MarkedForDeletion)?_couplingCollectionViaComponentInspectionReportGenerator____:null);
				info.AddValue("_couplingCollectionViaComponentInspectionReportGenerator_", ((_couplingCollectionViaComponentInspectionReportGenerator_!=null) && (_couplingCollectionViaComponentInspectionReportGenerator_.Count>0) && !this.MarkedForDeletion)?_couplingCollectionViaComponentInspectionReportGenerator_:null);
				info.AddValue("_couplingCollectionViaComponentInspectionReportGenerator", ((_couplingCollectionViaComponentInspectionReportGenerator!=null) && (_couplingCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_couplingCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_couplingCollectionViaComponentInspectionReportGenerator___", ((_couplingCollectionViaComponentInspectionReportGenerator___!=null) && (_couplingCollectionViaComponentInspectionReportGenerator___.Count>0) && !this.MarkedForDeletion)?_couplingCollectionViaComponentInspectionReportGenerator___:null);
				info.AddValue("_couplingCollectionViaComponentInspectionReportGenerator__", ((_couplingCollectionViaComponentInspectionReportGenerator__!=null) && (_couplingCollectionViaComponentInspectionReportGenerator__.Count>0) && !this.MarkedForDeletion)?_couplingCollectionViaComponentInspectionReportGenerator__:null);
				info.AddValue("_generatorCoverCollectionViaComponentInspectionReportGenerator______", ((_generatorCoverCollectionViaComponentInspectionReportGenerator______!=null) && (_generatorCoverCollectionViaComponentInspectionReportGenerator______.Count>0) && !this.MarkedForDeletion)?_generatorCoverCollectionViaComponentInspectionReportGenerator______:null);
				info.AddValue("_generatorCoverCollectionViaComponentInspectionReportGenerator_____", ((_generatorCoverCollectionViaComponentInspectionReportGenerator_____!=null) && (_generatorCoverCollectionViaComponentInspectionReportGenerator_____.Count>0) && !this.MarkedForDeletion)?_generatorCoverCollectionViaComponentInspectionReportGenerator_____:null);
				info.AddValue("_generatorCoverCollectionViaComponentInspectionReportGenerator________", ((_generatorCoverCollectionViaComponentInspectionReportGenerator________!=null) && (_generatorCoverCollectionViaComponentInspectionReportGenerator________.Count>0) && !this.MarkedForDeletion)?_generatorCoverCollectionViaComponentInspectionReportGenerator________:null);
				info.AddValue("_generatorCoverCollectionViaComponentInspectionReportGenerator_______", ((_generatorCoverCollectionViaComponentInspectionReportGenerator_______!=null) && (_generatorCoverCollectionViaComponentInspectionReportGenerator_______.Count>0) && !this.MarkedForDeletion)?_generatorCoverCollectionViaComponentInspectionReportGenerator_______:null);
				info.AddValue("_generatorCoverCollectionViaComponentInspectionReportGenerator____", ((_generatorCoverCollectionViaComponentInspectionReportGenerator____!=null) && (_generatorCoverCollectionViaComponentInspectionReportGenerator____.Count>0) && !this.MarkedForDeletion)?_generatorCoverCollectionViaComponentInspectionReportGenerator____:null);
				info.AddValue("_generatorCoverCollectionViaComponentInspectionReportGenerator_", ((_generatorCoverCollectionViaComponentInspectionReportGenerator_!=null) && (_generatorCoverCollectionViaComponentInspectionReportGenerator_.Count>0) && !this.MarkedForDeletion)?_generatorCoverCollectionViaComponentInspectionReportGenerator_:null);
				info.AddValue("_generatorCoverCollectionViaComponentInspectionReportGenerator", ((_generatorCoverCollectionViaComponentInspectionReportGenerator!=null) && (_generatorCoverCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_generatorCoverCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_generatorCoverCollectionViaComponentInspectionReportGenerator___", ((_generatorCoverCollectionViaComponentInspectionReportGenerator___!=null) && (_generatorCoverCollectionViaComponentInspectionReportGenerator___.Count>0) && !this.MarkedForDeletion)?_generatorCoverCollectionViaComponentInspectionReportGenerator___:null);
				info.AddValue("_generatorCoverCollectionViaComponentInspectionReportGenerator__", ((_generatorCoverCollectionViaComponentInspectionReportGenerator__!=null) && (_generatorCoverCollectionViaComponentInspectionReportGenerator__.Count>0) && !this.MarkedForDeletion)?_generatorCoverCollectionViaComponentInspectionReportGenerator__:null);
				info.AddValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator______", ((_generatorDriveEndCollectionViaComponentInspectionReportGenerator______!=null) && (_generatorDriveEndCollectionViaComponentInspectionReportGenerator______.Count>0) && !this.MarkedForDeletion)?_generatorDriveEndCollectionViaComponentInspectionReportGenerator______:null);
				info.AddValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____", ((_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____!=null) && (_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____.Count>0) && !this.MarkedForDeletion)?_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____:null);
				info.AddValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator________", ((_generatorDriveEndCollectionViaComponentInspectionReportGenerator________!=null) && (_generatorDriveEndCollectionViaComponentInspectionReportGenerator________.Count>0) && !this.MarkedForDeletion)?_generatorDriveEndCollectionViaComponentInspectionReportGenerator________:null);
				info.AddValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______", ((_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______!=null) && (_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______.Count>0) && !this.MarkedForDeletion)?_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______:null);
				info.AddValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator____", ((_generatorDriveEndCollectionViaComponentInspectionReportGenerator____!=null) && (_generatorDriveEndCollectionViaComponentInspectionReportGenerator____.Count>0) && !this.MarkedForDeletion)?_generatorDriveEndCollectionViaComponentInspectionReportGenerator____:null);
				info.AddValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator_", ((_generatorDriveEndCollectionViaComponentInspectionReportGenerator_!=null) && (_generatorDriveEndCollectionViaComponentInspectionReportGenerator_.Count>0) && !this.MarkedForDeletion)?_generatorDriveEndCollectionViaComponentInspectionReportGenerator_:null);
				info.AddValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator", ((_generatorDriveEndCollectionViaComponentInspectionReportGenerator!=null) && (_generatorDriveEndCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_generatorDriveEndCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator___", ((_generatorDriveEndCollectionViaComponentInspectionReportGenerator___!=null) && (_generatorDriveEndCollectionViaComponentInspectionReportGenerator___.Count>0) && !this.MarkedForDeletion)?_generatorDriveEndCollectionViaComponentInspectionReportGenerator___:null);
				info.AddValue("_generatorDriveEndCollectionViaComponentInspectionReportGenerator__", ((_generatorDriveEndCollectionViaComponentInspectionReportGenerator__!=null) && (_generatorDriveEndCollectionViaComponentInspectionReportGenerator__.Count>0) && !this.MarkedForDeletion)?_generatorDriveEndCollectionViaComponentInspectionReportGenerator__:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator______", ((_generatorManufacturerCollectionViaComponentInspectionReportGenerator______!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGenerator______.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGenerator______:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____", ((_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator________", ((_generatorManufacturerCollectionViaComponentInspectionReportGenerator________!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGenerator________.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGenerator________:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______", ((_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator____", ((_generatorManufacturerCollectionViaComponentInspectionReportGenerator____!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGenerator____.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGenerator____:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator_", ((_generatorManufacturerCollectionViaComponentInspectionReportGenerator_!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGenerator_.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGenerator_:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator", ((_generatorManufacturerCollectionViaComponentInspectionReportGenerator!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator___", ((_generatorManufacturerCollectionViaComponentInspectionReportGenerator___!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGenerator___.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGenerator___:null);
				info.AddValue("_generatorManufacturerCollectionViaComponentInspectionReportGenerator__", ((_generatorManufacturerCollectionViaComponentInspectionReportGenerator__!=null) && (_generatorManufacturerCollectionViaComponentInspectionReportGenerator__.Count>0) && !this.MarkedForDeletion)?_generatorManufacturerCollectionViaComponentInspectionReportGenerator__:null);
				info.AddValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______", ((_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______!=null) && (_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______.Count>0) && !this.MarkedForDeletion)?_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______:null);
				info.AddValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____", ((_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____!=null) && (_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____.Count>0) && !this.MarkedForDeletion)?_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____:null);
				info.AddValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________", ((_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________!=null) && (_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________.Count>0) && !this.MarkedForDeletion)?_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________:null);
				info.AddValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______", ((_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______!=null) && (_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______.Count>0) && !this.MarkedForDeletion)?_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______:null);
				info.AddValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____", ((_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____!=null) && (_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____.Count>0) && !this.MarkedForDeletion)?_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____:null);
				info.AddValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_", ((_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_!=null) && (_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_.Count>0) && !this.MarkedForDeletion)?_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_:null);
				info.AddValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator", ((_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator!=null) && (_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___", ((_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___!=null) && (_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___.Count>0) && !this.MarkedForDeletion)?_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___:null);
				info.AddValue("_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__", ((_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__!=null) && (_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__.Count>0) && !this.MarkedForDeletion)?_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__:null);
				info.AddValue("_generatorRotorCollectionViaComponentInspectionReportGenerator______", ((_generatorRotorCollectionViaComponentInspectionReportGenerator______!=null) && (_generatorRotorCollectionViaComponentInspectionReportGenerator______.Count>0) && !this.MarkedForDeletion)?_generatorRotorCollectionViaComponentInspectionReportGenerator______:null);
				info.AddValue("_generatorRotorCollectionViaComponentInspectionReportGenerator_____", ((_generatorRotorCollectionViaComponentInspectionReportGenerator_____!=null) && (_generatorRotorCollectionViaComponentInspectionReportGenerator_____.Count>0) && !this.MarkedForDeletion)?_generatorRotorCollectionViaComponentInspectionReportGenerator_____:null);
				info.AddValue("_generatorRotorCollectionViaComponentInspectionReportGenerator________", ((_generatorRotorCollectionViaComponentInspectionReportGenerator________!=null) && (_generatorRotorCollectionViaComponentInspectionReportGenerator________.Count>0) && !this.MarkedForDeletion)?_generatorRotorCollectionViaComponentInspectionReportGenerator________:null);
				info.AddValue("_generatorRotorCollectionViaComponentInspectionReportGenerator_______", ((_generatorRotorCollectionViaComponentInspectionReportGenerator_______!=null) && (_generatorRotorCollectionViaComponentInspectionReportGenerator_______.Count>0) && !this.MarkedForDeletion)?_generatorRotorCollectionViaComponentInspectionReportGenerator_______:null);
				info.AddValue("_generatorRotorCollectionViaComponentInspectionReportGenerator____", ((_generatorRotorCollectionViaComponentInspectionReportGenerator____!=null) && (_generatorRotorCollectionViaComponentInspectionReportGenerator____.Count>0) && !this.MarkedForDeletion)?_generatorRotorCollectionViaComponentInspectionReportGenerator____:null);
				info.AddValue("_generatorRotorCollectionViaComponentInspectionReportGenerator_", ((_generatorRotorCollectionViaComponentInspectionReportGenerator_!=null) && (_generatorRotorCollectionViaComponentInspectionReportGenerator_.Count>0) && !this.MarkedForDeletion)?_generatorRotorCollectionViaComponentInspectionReportGenerator_:null);
				info.AddValue("_generatorRotorCollectionViaComponentInspectionReportGenerator", ((_generatorRotorCollectionViaComponentInspectionReportGenerator!=null) && (_generatorRotorCollectionViaComponentInspectionReportGenerator.Count>0) && !this.MarkedForDeletion)?_generatorRotorCollectionViaComponentInspectionReportGenerator:null);
				info.AddValue("_generatorRotorCollectionViaComponentInspectionReportGenerator___", ((_generatorRotorCollectionViaComponentInspectionReportGenerator___!=null) && (_generatorRotorCollectionViaComponentInspectionReportGenerator___.Count>0) && !this.MarkedForDeletion)?_generatorRotorCollectionViaComponentInspectionReportGenerator___:null);
				info.AddValue("_generatorRotorCollectionViaComponentInspectionReportGenerator__", ((_generatorRotorCollectionViaComponentInspectionReportGenerator__!=null) && (_generatorRotorCollectionViaComponentInspectionReportGenerator__.Count>0) && !this.MarkedForDeletion)?_generatorRotorCollectionViaComponentInspectionReportGenerator__:null);
				info.AddValue("_ohmUnit", (!this.MarkedForDeletion?_ohmUnit:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(OhmUnitFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(OhmUnitFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new OhmUnitRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGenerator______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.KgroundOhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGenerator_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.VwohmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGenerator________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.MgroundOhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGenerator_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.LgroundOhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGenerator____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.UwohmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGenerator_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.VgroundOhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.UgroundOhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGenerator___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.UvohmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReportGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportGenerator__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportGeneratorFields.WgroundOhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnit_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.ParentOhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionToBeTakenOnGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionToBeTakenOnGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionToBeTakenOnGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionToBeTakenOnGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionToBeTakenOnGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionToBeTakenOnGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionToBeTakenOnGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionToBeTakenOnGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ActionToBeTakenOnGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGenerator______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGenerator_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGenerator________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGenerator_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGenerator____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGenerator_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGenerator___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'BooleanAnswer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBooleanAnswerCollectionViaComponentInspectionReportGenerator__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGenerator______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGenerator________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGenerator____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGenerator_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGenerator___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'ComponentInspectionReport' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportCollectionViaComponentInspectionReportGenerator__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupling' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouplingCollectionViaComponentInspectionReportGenerator______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupling' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouplingCollectionViaComponentInspectionReportGenerator_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupling' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouplingCollectionViaComponentInspectionReportGenerator________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupling' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouplingCollectionViaComponentInspectionReportGenerator_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupling' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouplingCollectionViaComponentInspectionReportGenerator____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupling' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouplingCollectionViaComponentInspectionReportGenerator_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupling' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouplingCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupling' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouplingCollectionViaComponentInspectionReportGenerator___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Coupling' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCouplingCollectionViaComponentInspectionReportGenerator__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorCover' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorCoverCollectionViaComponentInspectionReportGenerator______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorCover' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorCoverCollectionViaComponentInspectionReportGenerator_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorCover' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorCoverCollectionViaComponentInspectionReportGenerator________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorCover' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorCoverCollectionViaComponentInspectionReportGenerator_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorCover' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorCoverCollectionViaComponentInspectionReportGenerator____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorCover' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorCoverCollectionViaComponentInspectionReportGenerator_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorCover' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorCoverCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorCover' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorCoverCollectionViaComponentInspectionReportGenerator___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorCover' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorCoverCollectionViaComponentInspectionReportGenerator__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDriveEndCollectionViaComponentInspectionReportGenerator______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDriveEndCollectionViaComponentInspectionReportGenerator________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDriveEndCollectionViaComponentInspectionReportGenerator____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDriveEndCollectionViaComponentInspectionReportGenerator_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDriveEndCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDriveEndCollectionViaComponentInspectionReportGenerator___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorDriveEndCollectionViaComponentInspectionReportGenerator__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGenerator______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGenerator________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGenerator____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGenerator_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGenerator___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorManufacturer' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorManufacturerCollectionViaComponentInspectionReportGenerator__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorNonDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorNonDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorNonDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorNonDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorNonDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorNonDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorNonDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorNonDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorNonDriveEnd' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotorCollectionViaComponentInspectionReportGenerator______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotorCollectionViaComponentInspectionReportGenerator_____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotorCollectionViaComponentInspectionReportGenerator________()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotorCollectionViaComponentInspectionReportGenerator_______()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotorCollectionViaComponentInspectionReportGenerator____()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotorCollectionViaComponentInspectionReportGenerator_()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotorCollectionViaComponentInspectionReportGenerator()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotorCollectionViaComponentInspectionReportGenerator___()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'GeneratorRotor' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoGeneratorRotorCollectionViaComponentInspectionReportGenerator__()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
			bucket.Relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.OhmUnitId, "OhmUnitEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'OhmUnit' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoOhmUnit()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(OhmUnitFields.OhmUnitId, null, ComparisonOperator.Equal, this.ParentOhmUnitId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.OhmUnitEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._componentInspectionReportGenerator______);
			collectionsQueue.Enqueue(this._componentInspectionReportGenerator_____);
			collectionsQueue.Enqueue(this._componentInspectionReportGenerator________);
			collectionsQueue.Enqueue(this._componentInspectionReportGenerator_______);
			collectionsQueue.Enqueue(this._componentInspectionReportGenerator____);
			collectionsQueue.Enqueue(this._componentInspectionReportGenerator_);
			collectionsQueue.Enqueue(this._componentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._componentInspectionReportGenerator___);
			collectionsQueue.Enqueue(this._componentInspectionReportGenerator__);
			collectionsQueue.Enqueue(this._ohmUnit_);
			collectionsQueue.Enqueue(this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______);
			collectionsQueue.Enqueue(this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____);
			collectionsQueue.Enqueue(this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________);
			collectionsQueue.Enqueue(this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______);
			collectionsQueue.Enqueue(this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____);
			collectionsQueue.Enqueue(this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_);
			collectionsQueue.Enqueue(this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___);
			collectionsQueue.Enqueue(this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGenerator______);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGenerator_____);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGenerator________);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGenerator_______);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGenerator____);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGenerator_);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGenerator___);
			collectionsQueue.Enqueue(this._booleanAnswerCollectionViaComponentInspectionReportGenerator__);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGenerator______);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGenerator_____);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGenerator________);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGenerator_______);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGenerator____);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGenerator_);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGenerator___);
			collectionsQueue.Enqueue(this._componentInspectionReportCollectionViaComponentInspectionReportGenerator__);
			collectionsQueue.Enqueue(this._couplingCollectionViaComponentInspectionReportGenerator______);
			collectionsQueue.Enqueue(this._couplingCollectionViaComponentInspectionReportGenerator_____);
			collectionsQueue.Enqueue(this._couplingCollectionViaComponentInspectionReportGenerator________);
			collectionsQueue.Enqueue(this._couplingCollectionViaComponentInspectionReportGenerator_______);
			collectionsQueue.Enqueue(this._couplingCollectionViaComponentInspectionReportGenerator____);
			collectionsQueue.Enqueue(this._couplingCollectionViaComponentInspectionReportGenerator_);
			collectionsQueue.Enqueue(this._couplingCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._couplingCollectionViaComponentInspectionReportGenerator___);
			collectionsQueue.Enqueue(this._couplingCollectionViaComponentInspectionReportGenerator__);
			collectionsQueue.Enqueue(this._generatorCoverCollectionViaComponentInspectionReportGenerator______);
			collectionsQueue.Enqueue(this._generatorCoverCollectionViaComponentInspectionReportGenerator_____);
			collectionsQueue.Enqueue(this._generatorCoverCollectionViaComponentInspectionReportGenerator________);
			collectionsQueue.Enqueue(this._generatorCoverCollectionViaComponentInspectionReportGenerator_______);
			collectionsQueue.Enqueue(this._generatorCoverCollectionViaComponentInspectionReportGenerator____);
			collectionsQueue.Enqueue(this._generatorCoverCollectionViaComponentInspectionReportGenerator_);
			collectionsQueue.Enqueue(this._generatorCoverCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._generatorCoverCollectionViaComponentInspectionReportGenerator___);
			collectionsQueue.Enqueue(this._generatorCoverCollectionViaComponentInspectionReportGenerator__);
			collectionsQueue.Enqueue(this._generatorDriveEndCollectionViaComponentInspectionReportGenerator______);
			collectionsQueue.Enqueue(this._generatorDriveEndCollectionViaComponentInspectionReportGenerator_____);
			collectionsQueue.Enqueue(this._generatorDriveEndCollectionViaComponentInspectionReportGenerator________);
			collectionsQueue.Enqueue(this._generatorDriveEndCollectionViaComponentInspectionReportGenerator_______);
			collectionsQueue.Enqueue(this._generatorDriveEndCollectionViaComponentInspectionReportGenerator____);
			collectionsQueue.Enqueue(this._generatorDriveEndCollectionViaComponentInspectionReportGenerator_);
			collectionsQueue.Enqueue(this._generatorDriveEndCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._generatorDriveEndCollectionViaComponentInspectionReportGenerator___);
			collectionsQueue.Enqueue(this._generatorDriveEndCollectionViaComponentInspectionReportGenerator__);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGenerator______);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGenerator_____);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGenerator________);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGenerator_______);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGenerator____);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGenerator_);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGenerator___);
			collectionsQueue.Enqueue(this._generatorManufacturerCollectionViaComponentInspectionReportGenerator__);
			collectionsQueue.Enqueue(this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______);
			collectionsQueue.Enqueue(this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____);
			collectionsQueue.Enqueue(this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________);
			collectionsQueue.Enqueue(this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______);
			collectionsQueue.Enqueue(this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____);
			collectionsQueue.Enqueue(this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_);
			collectionsQueue.Enqueue(this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___);
			collectionsQueue.Enqueue(this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__);
			collectionsQueue.Enqueue(this._generatorRotorCollectionViaComponentInspectionReportGenerator______);
			collectionsQueue.Enqueue(this._generatorRotorCollectionViaComponentInspectionReportGenerator_____);
			collectionsQueue.Enqueue(this._generatorRotorCollectionViaComponentInspectionReportGenerator________);
			collectionsQueue.Enqueue(this._generatorRotorCollectionViaComponentInspectionReportGenerator_______);
			collectionsQueue.Enqueue(this._generatorRotorCollectionViaComponentInspectionReportGenerator____);
			collectionsQueue.Enqueue(this._generatorRotorCollectionViaComponentInspectionReportGenerator_);
			collectionsQueue.Enqueue(this._generatorRotorCollectionViaComponentInspectionReportGenerator);
			collectionsQueue.Enqueue(this._generatorRotorCollectionViaComponentInspectionReportGenerator___);
			collectionsQueue.Enqueue(this._generatorRotorCollectionViaComponentInspectionReportGenerator__);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._componentInspectionReportGenerator______ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGenerator_____ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGenerator________ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGenerator_______ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGenerator____ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGenerator_ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGenerator = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGenerator___ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportGenerator__ = (EntityCollection<ComponentInspectionReportGeneratorEntity>) collectionsQueue.Dequeue();
			this._ohmUnit_ = (EntityCollection<OhmUnitEntity>) collectionsQueue.Dequeue();
			this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>) collectionsQueue.Dequeue();
			this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>) collectionsQueue.Dequeue();
			this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>) collectionsQueue.Dequeue();
			this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>) collectionsQueue.Dequeue();
			this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>) collectionsQueue.Dequeue();
			this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>) collectionsQueue.Dequeue();
			this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator = (EntityCollection<ActionToBeTakenOnGeneratorEntity>) collectionsQueue.Dequeue();
			this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>) collectionsQueue.Dequeue();
			this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<ActionToBeTakenOnGeneratorEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGenerator = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._booleanAnswerCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<BooleanAnswerEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGenerator = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._componentInspectionReportCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<ComponentInspectionReportEntity>) collectionsQueue.Dequeue();
			this._couplingCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<CouplingEntity>) collectionsQueue.Dequeue();
			this._couplingCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<CouplingEntity>) collectionsQueue.Dequeue();
			this._couplingCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<CouplingEntity>) collectionsQueue.Dequeue();
			this._couplingCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<CouplingEntity>) collectionsQueue.Dequeue();
			this._couplingCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<CouplingEntity>) collectionsQueue.Dequeue();
			this._couplingCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<CouplingEntity>) collectionsQueue.Dequeue();
			this._couplingCollectionViaComponentInspectionReportGenerator = (EntityCollection<CouplingEntity>) collectionsQueue.Dequeue();
			this._couplingCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<CouplingEntity>) collectionsQueue.Dequeue();
			this._couplingCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<CouplingEntity>) collectionsQueue.Dequeue();
			this._generatorCoverCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<GeneratorCoverEntity>) collectionsQueue.Dequeue();
			this._generatorCoverCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<GeneratorCoverEntity>) collectionsQueue.Dequeue();
			this._generatorCoverCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<GeneratorCoverEntity>) collectionsQueue.Dequeue();
			this._generatorCoverCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<GeneratorCoverEntity>) collectionsQueue.Dequeue();
			this._generatorCoverCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<GeneratorCoverEntity>) collectionsQueue.Dequeue();
			this._generatorCoverCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<GeneratorCoverEntity>) collectionsQueue.Dequeue();
			this._generatorCoverCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorCoverEntity>) collectionsQueue.Dequeue();
			this._generatorCoverCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<GeneratorCoverEntity>) collectionsQueue.Dequeue();
			this._generatorCoverCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<GeneratorCoverEntity>) collectionsQueue.Dequeue();
			this._generatorDriveEndCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<GeneratorDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorDriveEndCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<GeneratorDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorDriveEndCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<GeneratorDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorDriveEndCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<GeneratorDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorDriveEndCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<GeneratorDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorDriveEndCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<GeneratorDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorDriveEndCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorDriveEndCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<GeneratorDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorDriveEndCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<GeneratorDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorManufacturerCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<GeneratorManufacturerEntity>) collectionsQueue.Dequeue();
			this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<GeneratorNonDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<GeneratorNonDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<GeneratorNonDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<GeneratorNonDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<GeneratorNonDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<GeneratorNonDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorNonDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<GeneratorNonDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<GeneratorNonDriveEndEntity>) collectionsQueue.Dequeue();
			this._generatorRotorCollectionViaComponentInspectionReportGenerator______ = (EntityCollection<GeneratorRotorEntity>) collectionsQueue.Dequeue();
			this._generatorRotorCollectionViaComponentInspectionReportGenerator_____ = (EntityCollection<GeneratorRotorEntity>) collectionsQueue.Dequeue();
			this._generatorRotorCollectionViaComponentInspectionReportGenerator________ = (EntityCollection<GeneratorRotorEntity>) collectionsQueue.Dequeue();
			this._generatorRotorCollectionViaComponentInspectionReportGenerator_______ = (EntityCollection<GeneratorRotorEntity>) collectionsQueue.Dequeue();
			this._generatorRotorCollectionViaComponentInspectionReportGenerator____ = (EntityCollection<GeneratorRotorEntity>) collectionsQueue.Dequeue();
			this._generatorRotorCollectionViaComponentInspectionReportGenerator_ = (EntityCollection<GeneratorRotorEntity>) collectionsQueue.Dequeue();
			this._generatorRotorCollectionViaComponentInspectionReportGenerator = (EntityCollection<GeneratorRotorEntity>) collectionsQueue.Dequeue();
			this._generatorRotorCollectionViaComponentInspectionReportGenerator___ = (EntityCollection<GeneratorRotorEntity>) collectionsQueue.Dequeue();
			this._generatorRotorCollectionViaComponentInspectionReportGenerator__ = (EntityCollection<GeneratorRotorEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._componentInspectionReportGenerator______ != null)
			{
				return true;
			}
			if (this._componentInspectionReportGenerator_____ != null)
			{
				return true;
			}
			if (this._componentInspectionReportGenerator________ != null)
			{
				return true;
			}
			if (this._componentInspectionReportGenerator_______ != null)
			{
				return true;
			}
			if (this._componentInspectionReportGenerator____ != null)
			{
				return true;
			}
			if (this._componentInspectionReportGenerator_ != null)
			{
				return true;
			}
			if (this._componentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._componentInspectionReportGenerator___ != null)
			{
				return true;
			}
			if (this._componentInspectionReportGenerator__ != null)
			{
				return true;
			}
			if (this._ohmUnit_ != null)
			{
				return true;
			}
			if (this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______ != null)
			{
				return true;
			}
			if (this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____ != null)
			{
				return true;
			}
			if (this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________ != null)
			{
				return true;
			}
			if (this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______ != null)
			{
				return true;
			}
			if (this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____ != null)
			{
				return true;
			}
			if (this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_ != null)
			{
				return true;
			}
			if (this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___ != null)
			{
				return true;
			}
			if (this._actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGenerator______ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGenerator_____ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGenerator________ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGenerator_______ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGenerator____ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGenerator_ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGenerator___ != null)
			{
				return true;
			}
			if (this._booleanAnswerCollectionViaComponentInspectionReportGenerator__ != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGenerator______ != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGenerator_____ != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGenerator________ != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGenerator_______ != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGenerator____ != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGenerator_ != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGenerator___ != null)
			{
				return true;
			}
			if (this._componentInspectionReportCollectionViaComponentInspectionReportGenerator__ != null)
			{
				return true;
			}
			if (this._couplingCollectionViaComponentInspectionReportGenerator______ != null)
			{
				return true;
			}
			if (this._couplingCollectionViaComponentInspectionReportGenerator_____ != null)
			{
				return true;
			}
			if (this._couplingCollectionViaComponentInspectionReportGenerator________ != null)
			{
				return true;
			}
			if (this._couplingCollectionViaComponentInspectionReportGenerator_______ != null)
			{
				return true;
			}
			if (this._couplingCollectionViaComponentInspectionReportGenerator____ != null)
			{
				return true;
			}
			if (this._couplingCollectionViaComponentInspectionReportGenerator_ != null)
			{
				return true;
			}
			if (this._couplingCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._couplingCollectionViaComponentInspectionReportGenerator___ != null)
			{
				return true;
			}
			if (this._couplingCollectionViaComponentInspectionReportGenerator__ != null)
			{
				return true;
			}
			if (this._generatorCoverCollectionViaComponentInspectionReportGenerator______ != null)
			{
				return true;
			}
			if (this._generatorCoverCollectionViaComponentInspectionReportGenerator_____ != null)
			{
				return true;
			}
			if (this._generatorCoverCollectionViaComponentInspectionReportGenerator________ != null)
			{
				return true;
			}
			if (this._generatorCoverCollectionViaComponentInspectionReportGenerator_______ != null)
			{
				return true;
			}
			if (this._generatorCoverCollectionViaComponentInspectionReportGenerator____ != null)
			{
				return true;
			}
			if (this._generatorCoverCollectionViaComponentInspectionReportGenerator_ != null)
			{
				return true;
			}
			if (this._generatorCoverCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._generatorCoverCollectionViaComponentInspectionReportGenerator___ != null)
			{
				return true;
			}
			if (this._generatorCoverCollectionViaComponentInspectionReportGenerator__ != null)
			{
				return true;
			}
			if (this._generatorDriveEndCollectionViaComponentInspectionReportGenerator______ != null)
			{
				return true;
			}
			if (this._generatorDriveEndCollectionViaComponentInspectionReportGenerator_____ != null)
			{
				return true;
			}
			if (this._generatorDriveEndCollectionViaComponentInspectionReportGenerator________ != null)
			{
				return true;
			}
			if (this._generatorDriveEndCollectionViaComponentInspectionReportGenerator_______ != null)
			{
				return true;
			}
			if (this._generatorDriveEndCollectionViaComponentInspectionReportGenerator____ != null)
			{
				return true;
			}
			if (this._generatorDriveEndCollectionViaComponentInspectionReportGenerator_ != null)
			{
				return true;
			}
			if (this._generatorDriveEndCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._generatorDriveEndCollectionViaComponentInspectionReportGenerator___ != null)
			{
				return true;
			}
			if (this._generatorDriveEndCollectionViaComponentInspectionReportGenerator__ != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGenerator______ != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGenerator_____ != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGenerator________ != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGenerator_______ != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGenerator____ != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGenerator_ != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGenerator___ != null)
			{
				return true;
			}
			if (this._generatorManufacturerCollectionViaComponentInspectionReportGenerator__ != null)
			{
				return true;
			}
			if (this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______ != null)
			{
				return true;
			}
			if (this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____ != null)
			{
				return true;
			}
			if (this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________ != null)
			{
				return true;
			}
			if (this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______ != null)
			{
				return true;
			}
			if (this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____ != null)
			{
				return true;
			}
			if (this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_ != null)
			{
				return true;
			}
			if (this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___ != null)
			{
				return true;
			}
			if (this._generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__ != null)
			{
				return true;
			}
			if (this._generatorRotorCollectionViaComponentInspectionReportGenerator______ != null)
			{
				return true;
			}
			if (this._generatorRotorCollectionViaComponentInspectionReportGenerator_____ != null)
			{
				return true;
			}
			if (this._generatorRotorCollectionViaComponentInspectionReportGenerator________ != null)
			{
				return true;
			}
			if (this._generatorRotorCollectionViaComponentInspectionReportGenerator_______ != null)
			{
				return true;
			}
			if (this._generatorRotorCollectionViaComponentInspectionReportGenerator____ != null)
			{
				return true;
			}
			if (this._generatorRotorCollectionViaComponentInspectionReportGenerator_ != null)
			{
				return true;
			}
			if (this._generatorRotorCollectionViaComponentInspectionReportGenerator != null)
			{
				return true;
			}
			if (this._generatorRotorCollectionViaComponentInspectionReportGenerator___ != null)
			{
				return true;
			}
			if (this._generatorRotorCollectionViaComponentInspectionReportGenerator__ != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))) : null);
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();
			toReturn.Add("OhmUnit", _ohmUnit);
			toReturn.Add("ComponentInspectionReportGenerator______", _componentInspectionReportGenerator______);
			toReturn.Add("ComponentInspectionReportGenerator_____", _componentInspectionReportGenerator_____);
			toReturn.Add("ComponentInspectionReportGenerator________", _componentInspectionReportGenerator________);
			toReturn.Add("ComponentInspectionReportGenerator_______", _componentInspectionReportGenerator_______);
			toReturn.Add("ComponentInspectionReportGenerator____", _componentInspectionReportGenerator____);
			toReturn.Add("ComponentInspectionReportGenerator_", _componentInspectionReportGenerator_);
			toReturn.Add("ComponentInspectionReportGenerator", _componentInspectionReportGenerator);
			toReturn.Add("ComponentInspectionReportGenerator___", _componentInspectionReportGenerator___);
			toReturn.Add("ComponentInspectionReportGenerator__", _componentInspectionReportGenerator__);
			toReturn.Add("OhmUnit_", _ohmUnit_);
			toReturn.Add("ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______", _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______);
			toReturn.Add("ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____", _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____);
			toReturn.Add("ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________", _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________);
			toReturn.Add("ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______", _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______);
			toReturn.Add("ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____", _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____);
			toReturn.Add("ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_", _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_);
			toReturn.Add("ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator", _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___", _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___);
			toReturn.Add("ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__", _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGenerator______", _booleanAnswerCollectionViaComponentInspectionReportGenerator______);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGenerator_____", _booleanAnswerCollectionViaComponentInspectionReportGenerator_____);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGenerator________", _booleanAnswerCollectionViaComponentInspectionReportGenerator________);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGenerator_______", _booleanAnswerCollectionViaComponentInspectionReportGenerator_______);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGenerator____", _booleanAnswerCollectionViaComponentInspectionReportGenerator____);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGenerator_", _booleanAnswerCollectionViaComponentInspectionReportGenerator_);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGenerator", _booleanAnswerCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGenerator___", _booleanAnswerCollectionViaComponentInspectionReportGenerator___);
			toReturn.Add("BooleanAnswerCollectionViaComponentInspectionReportGenerator__", _booleanAnswerCollectionViaComponentInspectionReportGenerator__);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGenerator______", _componentInspectionReportCollectionViaComponentInspectionReportGenerator______);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____", _componentInspectionReportCollectionViaComponentInspectionReportGenerator_____);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGenerator________", _componentInspectionReportCollectionViaComponentInspectionReportGenerator________);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______", _componentInspectionReportCollectionViaComponentInspectionReportGenerator_______);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGenerator____", _componentInspectionReportCollectionViaComponentInspectionReportGenerator____);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_", _componentInspectionReportCollectionViaComponentInspectionReportGenerator_);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGenerator", _componentInspectionReportCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGenerator___", _componentInspectionReportCollectionViaComponentInspectionReportGenerator___);
			toReturn.Add("ComponentInspectionReportCollectionViaComponentInspectionReportGenerator__", _componentInspectionReportCollectionViaComponentInspectionReportGenerator__);
			toReturn.Add("CouplingCollectionViaComponentInspectionReportGenerator______", _couplingCollectionViaComponentInspectionReportGenerator______);
			toReturn.Add("CouplingCollectionViaComponentInspectionReportGenerator_____", _couplingCollectionViaComponentInspectionReportGenerator_____);
			toReturn.Add("CouplingCollectionViaComponentInspectionReportGenerator________", _couplingCollectionViaComponentInspectionReportGenerator________);
			toReturn.Add("CouplingCollectionViaComponentInspectionReportGenerator_______", _couplingCollectionViaComponentInspectionReportGenerator_______);
			toReturn.Add("CouplingCollectionViaComponentInspectionReportGenerator____", _couplingCollectionViaComponentInspectionReportGenerator____);
			toReturn.Add("CouplingCollectionViaComponentInspectionReportGenerator_", _couplingCollectionViaComponentInspectionReportGenerator_);
			toReturn.Add("CouplingCollectionViaComponentInspectionReportGenerator", _couplingCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("CouplingCollectionViaComponentInspectionReportGenerator___", _couplingCollectionViaComponentInspectionReportGenerator___);
			toReturn.Add("CouplingCollectionViaComponentInspectionReportGenerator__", _couplingCollectionViaComponentInspectionReportGenerator__);
			toReturn.Add("GeneratorCoverCollectionViaComponentInspectionReportGenerator______", _generatorCoverCollectionViaComponentInspectionReportGenerator______);
			toReturn.Add("GeneratorCoverCollectionViaComponentInspectionReportGenerator_____", _generatorCoverCollectionViaComponentInspectionReportGenerator_____);
			toReturn.Add("GeneratorCoverCollectionViaComponentInspectionReportGenerator________", _generatorCoverCollectionViaComponentInspectionReportGenerator________);
			toReturn.Add("GeneratorCoverCollectionViaComponentInspectionReportGenerator_______", _generatorCoverCollectionViaComponentInspectionReportGenerator_______);
			toReturn.Add("GeneratorCoverCollectionViaComponentInspectionReportGenerator____", _generatorCoverCollectionViaComponentInspectionReportGenerator____);
			toReturn.Add("GeneratorCoverCollectionViaComponentInspectionReportGenerator_", _generatorCoverCollectionViaComponentInspectionReportGenerator_);
			toReturn.Add("GeneratorCoverCollectionViaComponentInspectionReportGenerator", _generatorCoverCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("GeneratorCoverCollectionViaComponentInspectionReportGenerator___", _generatorCoverCollectionViaComponentInspectionReportGenerator___);
			toReturn.Add("GeneratorCoverCollectionViaComponentInspectionReportGenerator__", _generatorCoverCollectionViaComponentInspectionReportGenerator__);
			toReturn.Add("GeneratorDriveEndCollectionViaComponentInspectionReportGenerator______", _generatorDriveEndCollectionViaComponentInspectionReportGenerator______);
			toReturn.Add("GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____", _generatorDriveEndCollectionViaComponentInspectionReportGenerator_____);
			toReturn.Add("GeneratorDriveEndCollectionViaComponentInspectionReportGenerator________", _generatorDriveEndCollectionViaComponentInspectionReportGenerator________);
			toReturn.Add("GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______", _generatorDriveEndCollectionViaComponentInspectionReportGenerator_______);
			toReturn.Add("GeneratorDriveEndCollectionViaComponentInspectionReportGenerator____", _generatorDriveEndCollectionViaComponentInspectionReportGenerator____);
			toReturn.Add("GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_", _generatorDriveEndCollectionViaComponentInspectionReportGenerator_);
			toReturn.Add("GeneratorDriveEndCollectionViaComponentInspectionReportGenerator", _generatorDriveEndCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("GeneratorDriveEndCollectionViaComponentInspectionReportGenerator___", _generatorDriveEndCollectionViaComponentInspectionReportGenerator___);
			toReturn.Add("GeneratorDriveEndCollectionViaComponentInspectionReportGenerator__", _generatorDriveEndCollectionViaComponentInspectionReportGenerator__);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGenerator______", _generatorManufacturerCollectionViaComponentInspectionReportGenerator______);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____", _generatorManufacturerCollectionViaComponentInspectionReportGenerator_____);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGenerator________", _generatorManufacturerCollectionViaComponentInspectionReportGenerator________);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______", _generatorManufacturerCollectionViaComponentInspectionReportGenerator_______);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGenerator____", _generatorManufacturerCollectionViaComponentInspectionReportGenerator____);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_", _generatorManufacturerCollectionViaComponentInspectionReportGenerator_);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGenerator", _generatorManufacturerCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGenerator___", _generatorManufacturerCollectionViaComponentInspectionReportGenerator___);
			toReturn.Add("GeneratorManufacturerCollectionViaComponentInspectionReportGenerator__", _generatorManufacturerCollectionViaComponentInspectionReportGenerator__);
			toReturn.Add("GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______", _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______);
			toReturn.Add("GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____", _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____);
			toReturn.Add("GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________", _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________);
			toReturn.Add("GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______", _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______);
			toReturn.Add("GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____", _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____);
			toReturn.Add("GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_", _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_);
			toReturn.Add("GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator", _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___", _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___);
			toReturn.Add("GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__", _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__);
			toReturn.Add("GeneratorRotorCollectionViaComponentInspectionReportGenerator______", _generatorRotorCollectionViaComponentInspectionReportGenerator______);
			toReturn.Add("GeneratorRotorCollectionViaComponentInspectionReportGenerator_____", _generatorRotorCollectionViaComponentInspectionReportGenerator_____);
			toReturn.Add("GeneratorRotorCollectionViaComponentInspectionReportGenerator________", _generatorRotorCollectionViaComponentInspectionReportGenerator________);
			toReturn.Add("GeneratorRotorCollectionViaComponentInspectionReportGenerator_______", _generatorRotorCollectionViaComponentInspectionReportGenerator_______);
			toReturn.Add("GeneratorRotorCollectionViaComponentInspectionReportGenerator____", _generatorRotorCollectionViaComponentInspectionReportGenerator____);
			toReturn.Add("GeneratorRotorCollectionViaComponentInspectionReportGenerator_", _generatorRotorCollectionViaComponentInspectionReportGenerator_);
			toReturn.Add("GeneratorRotorCollectionViaComponentInspectionReportGenerator", _generatorRotorCollectionViaComponentInspectionReportGenerator);
			toReturn.Add("GeneratorRotorCollectionViaComponentInspectionReportGenerator___", _generatorRotorCollectionViaComponentInspectionReportGenerator___);
			toReturn.Add("GeneratorRotorCollectionViaComponentInspectionReportGenerator__", _generatorRotorCollectionViaComponentInspectionReportGenerator__);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_componentInspectionReportGenerator______!=null)
			{
				_componentInspectionReportGenerator______.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGenerator_____!=null)
			{
				_componentInspectionReportGenerator_____.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGenerator________!=null)
			{
				_componentInspectionReportGenerator________.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGenerator_______!=null)
			{
				_componentInspectionReportGenerator_______.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGenerator____!=null)
			{
				_componentInspectionReportGenerator____.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGenerator_!=null)
			{
				_componentInspectionReportGenerator_.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGenerator!=null)
			{
				_componentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGenerator___!=null)
			{
				_componentInspectionReportGenerator___.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportGenerator__!=null)
			{
				_componentInspectionReportGenerator__.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnit_!=null)
			{
				_ohmUnit_.ActiveContext = base.ActiveContext;
			}
			if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______!=null)
			{
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______.ActiveContext = base.ActiveContext;
			}
			if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____!=null)
			{
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____.ActiveContext = base.ActiveContext;
			}
			if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________!=null)
			{
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________.ActiveContext = base.ActiveContext;
			}
			if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______!=null)
			{
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______.ActiveContext = base.ActiveContext;
			}
			if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____!=null)
			{
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____.ActiveContext = base.ActiveContext;
			}
			if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_!=null)
			{
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_.ActiveContext = base.ActiveContext;
			}
			if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator!=null)
			{
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___!=null)
			{
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___.ActiveContext = base.ActiveContext;
			}
			if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__!=null)
			{
				_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGenerator______!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGenerator______.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGenerator_____!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGenerator_____.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGenerator________!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGenerator________.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGenerator_______!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGenerator_______.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGenerator____!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGenerator____.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGenerator_!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGenerator_.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGenerator!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGenerator___!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGenerator___.ActiveContext = base.ActiveContext;
			}
			if(_booleanAnswerCollectionViaComponentInspectionReportGenerator__!=null)
			{
				_booleanAnswerCollectionViaComponentInspectionReportGenerator__.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator______!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator______.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator________!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator________.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator____!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator____.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator_!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator_.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator___!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator___.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator__!=null)
			{
				_componentInspectionReportCollectionViaComponentInspectionReportGenerator__.ActiveContext = base.ActiveContext;
			}
			if(_couplingCollectionViaComponentInspectionReportGenerator______!=null)
			{
				_couplingCollectionViaComponentInspectionReportGenerator______.ActiveContext = base.ActiveContext;
			}
			if(_couplingCollectionViaComponentInspectionReportGenerator_____!=null)
			{
				_couplingCollectionViaComponentInspectionReportGenerator_____.ActiveContext = base.ActiveContext;
			}
			if(_couplingCollectionViaComponentInspectionReportGenerator________!=null)
			{
				_couplingCollectionViaComponentInspectionReportGenerator________.ActiveContext = base.ActiveContext;
			}
			if(_couplingCollectionViaComponentInspectionReportGenerator_______!=null)
			{
				_couplingCollectionViaComponentInspectionReportGenerator_______.ActiveContext = base.ActiveContext;
			}
			if(_couplingCollectionViaComponentInspectionReportGenerator____!=null)
			{
				_couplingCollectionViaComponentInspectionReportGenerator____.ActiveContext = base.ActiveContext;
			}
			if(_couplingCollectionViaComponentInspectionReportGenerator_!=null)
			{
				_couplingCollectionViaComponentInspectionReportGenerator_.ActiveContext = base.ActiveContext;
			}
			if(_couplingCollectionViaComponentInspectionReportGenerator!=null)
			{
				_couplingCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_couplingCollectionViaComponentInspectionReportGenerator___!=null)
			{
				_couplingCollectionViaComponentInspectionReportGenerator___.ActiveContext = base.ActiveContext;
			}
			if(_couplingCollectionViaComponentInspectionReportGenerator__!=null)
			{
				_couplingCollectionViaComponentInspectionReportGenerator__.ActiveContext = base.ActiveContext;
			}
			if(_generatorCoverCollectionViaComponentInspectionReportGenerator______!=null)
			{
				_generatorCoverCollectionViaComponentInspectionReportGenerator______.ActiveContext = base.ActiveContext;
			}
			if(_generatorCoverCollectionViaComponentInspectionReportGenerator_____!=null)
			{
				_generatorCoverCollectionViaComponentInspectionReportGenerator_____.ActiveContext = base.ActiveContext;
			}
			if(_generatorCoverCollectionViaComponentInspectionReportGenerator________!=null)
			{
				_generatorCoverCollectionViaComponentInspectionReportGenerator________.ActiveContext = base.ActiveContext;
			}
			if(_generatorCoverCollectionViaComponentInspectionReportGenerator_______!=null)
			{
				_generatorCoverCollectionViaComponentInspectionReportGenerator_______.ActiveContext = base.ActiveContext;
			}
			if(_generatorCoverCollectionViaComponentInspectionReportGenerator____!=null)
			{
				_generatorCoverCollectionViaComponentInspectionReportGenerator____.ActiveContext = base.ActiveContext;
			}
			if(_generatorCoverCollectionViaComponentInspectionReportGenerator_!=null)
			{
				_generatorCoverCollectionViaComponentInspectionReportGenerator_.ActiveContext = base.ActiveContext;
			}
			if(_generatorCoverCollectionViaComponentInspectionReportGenerator!=null)
			{
				_generatorCoverCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_generatorCoverCollectionViaComponentInspectionReportGenerator___!=null)
			{
				_generatorCoverCollectionViaComponentInspectionReportGenerator___.ActiveContext = base.ActiveContext;
			}
			if(_generatorCoverCollectionViaComponentInspectionReportGenerator__!=null)
			{
				_generatorCoverCollectionViaComponentInspectionReportGenerator__.ActiveContext = base.ActiveContext;
			}
			if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator______!=null)
			{
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator______.ActiveContext = base.ActiveContext;
			}
			if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____!=null)
			{
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____.ActiveContext = base.ActiveContext;
			}
			if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator________!=null)
			{
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator________.ActiveContext = base.ActiveContext;
			}
			if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______!=null)
			{
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______.ActiveContext = base.ActiveContext;
			}
			if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator____!=null)
			{
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator____.ActiveContext = base.ActiveContext;
			}
			if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator_!=null)
			{
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator_.ActiveContext = base.ActiveContext;
			}
			if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator!=null)
			{
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator___!=null)
			{
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator___.ActiveContext = base.ActiveContext;
			}
			if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator__!=null)
			{
				_generatorDriveEndCollectionViaComponentInspectionReportGenerator__.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator______!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator______.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator________!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator________.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator____!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator____.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator_!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator_.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator___!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator___.ActiveContext = base.ActiveContext;
			}
			if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator__!=null)
			{
				_generatorManufacturerCollectionViaComponentInspectionReportGenerator__.ActiveContext = base.ActiveContext;
			}
			if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______!=null)
			{
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______.ActiveContext = base.ActiveContext;
			}
			if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____!=null)
			{
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____.ActiveContext = base.ActiveContext;
			}
			if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________!=null)
			{
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________.ActiveContext = base.ActiveContext;
			}
			if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______!=null)
			{
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______.ActiveContext = base.ActiveContext;
			}
			if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____!=null)
			{
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____.ActiveContext = base.ActiveContext;
			}
			if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_!=null)
			{
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_.ActiveContext = base.ActiveContext;
			}
			if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator!=null)
			{
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___!=null)
			{
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___.ActiveContext = base.ActiveContext;
			}
			if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__!=null)
			{
				_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotorCollectionViaComponentInspectionReportGenerator______!=null)
			{
				_generatorRotorCollectionViaComponentInspectionReportGenerator______.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotorCollectionViaComponentInspectionReportGenerator_____!=null)
			{
				_generatorRotorCollectionViaComponentInspectionReportGenerator_____.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotorCollectionViaComponentInspectionReportGenerator________!=null)
			{
				_generatorRotorCollectionViaComponentInspectionReportGenerator________.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotorCollectionViaComponentInspectionReportGenerator_______!=null)
			{
				_generatorRotorCollectionViaComponentInspectionReportGenerator_______.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotorCollectionViaComponentInspectionReportGenerator____!=null)
			{
				_generatorRotorCollectionViaComponentInspectionReportGenerator____.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotorCollectionViaComponentInspectionReportGenerator_!=null)
			{
				_generatorRotorCollectionViaComponentInspectionReportGenerator_.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotorCollectionViaComponentInspectionReportGenerator!=null)
			{
				_generatorRotorCollectionViaComponentInspectionReportGenerator.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotorCollectionViaComponentInspectionReportGenerator___!=null)
			{
				_generatorRotorCollectionViaComponentInspectionReportGenerator___.ActiveContext = base.ActiveContext;
			}
			if(_generatorRotorCollectionViaComponentInspectionReportGenerator__!=null)
			{
				_generatorRotorCollectionViaComponentInspectionReportGenerator__.ActiveContext = base.ActiveContext;
			}
			if(_ohmUnit!=null)
			{
				_ohmUnit.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_componentInspectionReportGenerator______ = null;
			_componentInspectionReportGenerator_____ = null;
			_componentInspectionReportGenerator________ = null;
			_componentInspectionReportGenerator_______ = null;
			_componentInspectionReportGenerator____ = null;
			_componentInspectionReportGenerator_ = null;
			_componentInspectionReportGenerator = null;
			_componentInspectionReportGenerator___ = null;
			_componentInspectionReportGenerator__ = null;
			_ohmUnit_ = null;
			_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______ = null;
			_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____ = null;
			_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________ = null;
			_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______ = null;
			_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____ = null;
			_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_ = null;
			_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator = null;
			_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___ = null;
			_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGenerator______ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGenerator_____ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGenerator________ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGenerator_______ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGenerator____ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGenerator_ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGenerator = null;
			_booleanAnswerCollectionViaComponentInspectionReportGenerator___ = null;
			_booleanAnswerCollectionViaComponentInspectionReportGenerator__ = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGenerator______ = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____ = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGenerator________ = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______ = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGenerator____ = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGenerator_ = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGenerator = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGenerator___ = null;
			_componentInspectionReportCollectionViaComponentInspectionReportGenerator__ = null;
			_couplingCollectionViaComponentInspectionReportGenerator______ = null;
			_couplingCollectionViaComponentInspectionReportGenerator_____ = null;
			_couplingCollectionViaComponentInspectionReportGenerator________ = null;
			_couplingCollectionViaComponentInspectionReportGenerator_______ = null;
			_couplingCollectionViaComponentInspectionReportGenerator____ = null;
			_couplingCollectionViaComponentInspectionReportGenerator_ = null;
			_couplingCollectionViaComponentInspectionReportGenerator = null;
			_couplingCollectionViaComponentInspectionReportGenerator___ = null;
			_couplingCollectionViaComponentInspectionReportGenerator__ = null;
			_generatorCoverCollectionViaComponentInspectionReportGenerator______ = null;
			_generatorCoverCollectionViaComponentInspectionReportGenerator_____ = null;
			_generatorCoverCollectionViaComponentInspectionReportGenerator________ = null;
			_generatorCoverCollectionViaComponentInspectionReportGenerator_______ = null;
			_generatorCoverCollectionViaComponentInspectionReportGenerator____ = null;
			_generatorCoverCollectionViaComponentInspectionReportGenerator_ = null;
			_generatorCoverCollectionViaComponentInspectionReportGenerator = null;
			_generatorCoverCollectionViaComponentInspectionReportGenerator___ = null;
			_generatorCoverCollectionViaComponentInspectionReportGenerator__ = null;
			_generatorDriveEndCollectionViaComponentInspectionReportGenerator______ = null;
			_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____ = null;
			_generatorDriveEndCollectionViaComponentInspectionReportGenerator________ = null;
			_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______ = null;
			_generatorDriveEndCollectionViaComponentInspectionReportGenerator____ = null;
			_generatorDriveEndCollectionViaComponentInspectionReportGenerator_ = null;
			_generatorDriveEndCollectionViaComponentInspectionReportGenerator = null;
			_generatorDriveEndCollectionViaComponentInspectionReportGenerator___ = null;
			_generatorDriveEndCollectionViaComponentInspectionReportGenerator__ = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGenerator______ = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____ = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGenerator________ = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______ = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGenerator____ = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGenerator_ = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGenerator = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGenerator___ = null;
			_generatorManufacturerCollectionViaComponentInspectionReportGenerator__ = null;
			_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______ = null;
			_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____ = null;
			_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________ = null;
			_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______ = null;
			_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____ = null;
			_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_ = null;
			_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator = null;
			_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___ = null;
			_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__ = null;
			_generatorRotorCollectionViaComponentInspectionReportGenerator______ = null;
			_generatorRotorCollectionViaComponentInspectionReportGenerator_____ = null;
			_generatorRotorCollectionViaComponentInspectionReportGenerator________ = null;
			_generatorRotorCollectionViaComponentInspectionReportGenerator_______ = null;
			_generatorRotorCollectionViaComponentInspectionReportGenerator____ = null;
			_generatorRotorCollectionViaComponentInspectionReportGenerator_ = null;
			_generatorRotorCollectionViaComponentInspectionReportGenerator = null;
			_generatorRotorCollectionViaComponentInspectionReportGenerator___ = null;
			_generatorRotorCollectionViaComponentInspectionReportGenerator__ = null;
			_ohmUnit = null;

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

			_fieldsCustomProperties.Add("OhmUnitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Name", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("LanguageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ParentOhmUnitId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sort", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("StartVersion", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EndVersion", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _ohmUnit</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncOhmUnit(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _ohmUnit, new PropertyChangedEventHandler( OnOhmUnitPropertyChanged ), "OhmUnit", OhmUnitEntity.Relations.OhmUnitEntityUsingOhmUnitIdParentOhmUnitId, true, signalRelatedEntity, "OhmUnit_", resetFKFields, new int[] { (int)OhmUnitFieldIndex.ParentOhmUnitId } );		
			_ohmUnit = null;
		}

		/// <summary> setups the sync logic for member _ohmUnit</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncOhmUnit(IEntity2 relatedEntity)
		{
			DesetupSyncOhmUnit(true, true);
			_ohmUnit = (OhmUnitEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _ohmUnit, new PropertyChangedEventHandler( OnOhmUnitPropertyChanged ), "OhmUnit", OhmUnitEntity.Relations.OhmUnitEntityUsingOhmUnitIdParentOhmUnitId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnOhmUnitPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this OhmUnitEntity</param>
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
		public  static OhmUnitRelations Relations
		{
			get	{ return new OhmUnitRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGenerator______
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),
					OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, null, null, "ComponentInspectionReportGenerator______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGenerator_____
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),
					OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, null, null, "ComponentInspectionReportGenerator_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGenerator________
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),
					OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, null, null, "ComponentInspectionReportGenerator________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGenerator_______
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),
					OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, null, null, "ComponentInspectionReportGenerator_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGenerator____
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),
					OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, null, null, "ComponentInspectionReportGenerator____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGenerator_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),
					OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, null, null, "ComponentInspectionReportGenerator_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGenerator
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),
					OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, null, null, "ComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGenerator___
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),
					OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, null, null, "ComponentInspectionReportGenerator___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportGenerator__
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory))),
					OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportGeneratorEntity, 0, null, null, null, null, "ComponentInspectionReportGenerator__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}
		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnit_
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),
					OhmUnitEntity.Relations.OhmUnitEntityUsingParentOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, null, null, "OhmUnit_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionToBeTakenOnGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity, 0, null, null, relations, null, "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionToBeTakenOnGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity, 0, null, null, relations, null, "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionToBeTakenOnGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity, 0, null, null, relations, null, "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionToBeTakenOnGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity, 0, null, null, relations, null, "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionToBeTakenOnGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity, 0, null, null, relations, null, "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionToBeTakenOnGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity, 0, null, null, relations, null, "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionToBeTakenOnGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity, 0, null, null, relations, null, "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionToBeTakenOnGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity, 0, null, null, relations, null, "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ActionToBeTakenOnGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ActionToBeTakenOnGeneratorEntityUsingActionToBeTakenOnGeneratorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ActionToBeTakenOnGeneratorEntity, 0, null, null, relations, null, "ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGenerator______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGenerator_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGenerator________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGenerator_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGenerator____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGenerator_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGenerator___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BooleanAnswer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBooleanAnswerCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.BooleanAnswerEntityUsingGeneratorClaimRelevantBooleanAnswerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.BooleanAnswerEntity, 0, null, null, relations, null, "BooleanAnswerCollectionViaComponentInspectionReportGenerator__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReport' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.ComponentInspectionReportEntityUsingComponentInspectionReportId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportEntity, 0, null, null, relations, null, "ComponentInspectionReportCollectionViaComponentInspectionReportGenerator__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouplingCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, relations, null, "CouplingCollectionViaComponentInspectionReportGenerator______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouplingCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, relations, null, "CouplingCollectionViaComponentInspectionReportGenerator_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouplingCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, relations, null, "CouplingCollectionViaComponentInspectionReportGenerator________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouplingCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, relations, null, "CouplingCollectionViaComponentInspectionReportGenerator_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouplingCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, relations, null, "CouplingCollectionViaComponentInspectionReportGenerator____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouplingCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, relations, null, "CouplingCollectionViaComponentInspectionReportGenerator_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouplingCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, relations, null, "CouplingCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouplingCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, relations, null, "CouplingCollectionViaComponentInspectionReportGenerator___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Coupling' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCouplingCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.CouplingEntityUsingCouplingId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.CouplingEntity, 0, null, null, relations, null, "CouplingCollectionViaComponentInspectionReportGenerator__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorCover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorCoverCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity, 0, null, null, relations, null, "GeneratorCoverCollectionViaComponentInspectionReportGenerator______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorCover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorCoverCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity, 0, null, null, relations, null, "GeneratorCoverCollectionViaComponentInspectionReportGenerator_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorCover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorCoverCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity, 0, null, null, relations, null, "GeneratorCoverCollectionViaComponentInspectionReportGenerator________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorCover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorCoverCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity, 0, null, null, relations, null, "GeneratorCoverCollectionViaComponentInspectionReportGenerator_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorCover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorCoverCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity, 0, null, null, relations, null, "GeneratorCoverCollectionViaComponentInspectionReportGenerator____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorCover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorCoverCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity, 0, null, null, relations, null, "GeneratorCoverCollectionViaComponentInspectionReportGenerator_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorCover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorCoverCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity, 0, null, null, relations, null, "GeneratorCoverCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorCover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorCoverCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity, 0, null, null, relations, null, "GeneratorCoverCollectionViaComponentInspectionReportGenerator___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorCover' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorCoverCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorCoverEntityUsingGeneratorCoverId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorCoverEntity, 0, null, null, relations, null, "GeneratorCoverCollectionViaComponentInspectionReportGenerator__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDriveEndCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity, 0, null, null, relations, null, "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity, 0, null, null, relations, null, "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDriveEndCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity, 0, null, null, relations, null, "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity, 0, null, null, relations, null, "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDriveEndCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity, 0, null, null, relations, null, "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDriveEndCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity, 0, null, null, relations, null, "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDriveEndCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity, 0, null, null, relations, null, "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDriveEndCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity, 0, null, null, relations, null, "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorDriveEndCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorDriveEndEntityUsingGeneratorDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorDriveEndEntity, 0, null, null, relations, null, "GeneratorDriveEndCollectionViaComponentInspectionReportGenerator__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorManufacturer' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorManufacturerCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorManufacturerEntityUsingGeneratorManufacturerId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorManufacturerEntity, 0, null, null, relations, null, "GeneratorManufacturerCollectionViaComponentInspectionReportGenerator__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorNonDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity, 0, null, null, relations, null, "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorNonDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity, 0, null, null, relations, null, "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorNonDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity, 0, null, null, relations, null, "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorNonDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity, 0, null, null, relations, null, "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorNonDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity, 0, null, null, relations, null, "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorNonDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity, 0, null, null, relations, null, "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorNonDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity, 0, null, null, relations, null, "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorNonDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity, 0, null, null, relations, null, "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorNonDriveEnd' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorNonDriveEndEntityUsingGeneratorNonDriveEndId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorNonDriveEndEntity, 0, null, null, relations, null, "GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotorCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingKgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, relations, null, "GeneratorRotorCollectionViaComponentInspectionReportGenerator______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotorCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, relations, null, "GeneratorRotorCollectionViaComponentInspectionReportGenerator_____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotorCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingMgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, relations, null, "GeneratorRotorCollectionViaComponentInspectionReportGenerator________", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotorCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingLgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, relations, null, "GeneratorRotorCollectionViaComponentInspectionReportGenerator_______", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotorCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUwohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, relations, null, "GeneratorRotorCollectionViaComponentInspectionReportGenerator____", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotorCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingVgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, relations, null, "GeneratorRotorCollectionViaComponentInspectionReportGenerator_", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotorCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, relations, null, "GeneratorRotorCollectionViaComponentInspectionReportGenerator", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotorCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingUvohmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, relations, null, "GeneratorRotorCollectionViaComponentInspectionReportGenerator___", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'GeneratorRotor' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathGeneratorRotorCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId;
				intermediateRelation.SetAliases(string.Empty, "ComponentInspectionReportGenerator_");
				relations.Add(OhmUnitEntity.Relations.ComponentInspectionReportGeneratorEntityUsingWgroundOhmUnitId, "OhmUnitEntity__", "ComponentInspectionReportGenerator_", JoinHint.None);
				relations.Add(ComponentInspectionReportGeneratorEntity.Relations.GeneratorRotorEntityUsingGeneratorRotorId, "ComponentInspectionReportGenerator_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.GeneratorRotorEntity, 0, null, null, relations, null, "GeneratorRotorCollectionViaComponentInspectionReportGenerator__", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'OhmUnit' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathOhmUnit
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory))),
					OhmUnitEntity.Relations.OhmUnitEntityUsingOhmUnitIdParentOhmUnitId, 
					(int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity, 0, null, null, null, null, "OhmUnit", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return OhmUnitEntity.CustomProperties;}
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
			get { return OhmUnitEntity.FieldsCustomProperties;}
		}

		/// <summary> The OhmUnitId property of the Entity OhmUnit<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "OhmUnit"."OhmUnitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 OhmUnitId
		{
			get { return (System.Int64)GetValue((int)OhmUnitFieldIndex.OhmUnitId, true); }
			set	{ SetValue((int)OhmUnitFieldIndex.OhmUnitId, value); }
		}

		/// <summary> The Name property of the Entity OhmUnit<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "OhmUnit"."Name"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Name
		{
			get { return (System.String)GetValue((int)OhmUnitFieldIndex.Name, true); }
			set	{ SetValue((int)OhmUnitFieldIndex.Name, value); }
		}

		/// <summary> The LanguageId property of the Entity OhmUnit<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "OhmUnit"."LanguageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 LanguageId
		{
			get { return (System.Int64)GetValue((int)OhmUnitFieldIndex.LanguageId, true); }
			set	{ SetValue((int)OhmUnitFieldIndex.LanguageId, value); }
		}

		/// <summary> The ParentOhmUnitId property of the Entity OhmUnit<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "OhmUnit"."ParentOhmUnitId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ParentOhmUnitId
		{
			get { return (Nullable<System.Int64>)GetValue((int)OhmUnitFieldIndex.ParentOhmUnitId, false); }
			set	{ SetValue((int)OhmUnitFieldIndex.ParentOhmUnitId, value); }
		}

		/// <summary> The Sort property of the Entity OhmUnit<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "OhmUnit"."Sort"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sort
		{
			get { return (System.Int64)GetValue((int)OhmUnitFieldIndex.Sort, true); }
			set	{ SetValue((int)OhmUnitFieldIndex.Sort, value); }
		}

		/// <summary> The StartVersion property of the Entity OhmUnit<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "OhmUnit"."StartVersion"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 StartVersion
		{
			get { return (System.Int32)GetValue((int)OhmUnitFieldIndex.StartVersion, true); }
			set	{ SetValue((int)OhmUnitFieldIndex.StartVersion, value); }
		}

		/// <summary> The EndVersion property of the Entity OhmUnit<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "OhmUnit"."EndVersion"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int32 EndVersion
		{
			get { return (System.Int32)GetValue((int)OhmUnitFieldIndex.EndVersion, true); }
			set	{ SetValue((int)OhmUnitFieldIndex.EndVersion, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGenerator______
		{
			get
			{
				if(_componentInspectionReportGenerator______==null)
				{
					_componentInspectionReportGenerator______ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGenerator______.SetContainingEntityInfo(this, "OhmUnit______");
				}
				return _componentInspectionReportGenerator______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGenerator_____
		{
			get
			{
				if(_componentInspectionReportGenerator_____==null)
				{
					_componentInspectionReportGenerator_____ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGenerator_____.SetContainingEntityInfo(this, "OhmUnit_____");
				}
				return _componentInspectionReportGenerator_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGenerator________
		{
			get
			{
				if(_componentInspectionReportGenerator________==null)
				{
					_componentInspectionReportGenerator________ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGenerator________.SetContainingEntityInfo(this, "OhmUnit________");
				}
				return _componentInspectionReportGenerator________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGenerator_______
		{
			get
			{
				if(_componentInspectionReportGenerator_______==null)
				{
					_componentInspectionReportGenerator_______ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGenerator_______.SetContainingEntityInfo(this, "OhmUnit_______");
				}
				return _componentInspectionReportGenerator_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGenerator____
		{
			get
			{
				if(_componentInspectionReportGenerator____==null)
				{
					_componentInspectionReportGenerator____ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGenerator____.SetContainingEntityInfo(this, "OhmUnit____");
				}
				return _componentInspectionReportGenerator____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGenerator_
		{
			get
			{
				if(_componentInspectionReportGenerator_==null)
				{
					_componentInspectionReportGenerator_ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGenerator_.SetContainingEntityInfo(this, "OhmUnit_");
				}
				return _componentInspectionReportGenerator_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGenerator
		{
			get
			{
				if(_componentInspectionReportGenerator==null)
				{
					_componentInspectionReportGenerator = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGenerator.SetContainingEntityInfo(this, "OhmUnit");
				}
				return _componentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGenerator___
		{
			get
			{
				if(_componentInspectionReportGenerator___==null)
				{
					_componentInspectionReportGenerator___ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGenerator___.SetContainingEntityInfo(this, "OhmUnit___");
				}
				return _componentInspectionReportGenerator___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportGeneratorEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportGeneratorEntity))]
		public virtual EntityCollection<ComponentInspectionReportGeneratorEntity> ComponentInspectionReportGenerator__
		{
			get
			{
				if(_componentInspectionReportGenerator__==null)
				{
					_componentInspectionReportGenerator__ = new EntityCollection<ComponentInspectionReportGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportGeneratorEntityFactory)));
					_componentInspectionReportGenerator__.SetContainingEntityInfo(this, "OhmUnit__");
				}
				return _componentInspectionReportGenerator__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'OhmUnitEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(OhmUnitEntity))]
		public virtual EntityCollection<OhmUnitEntity> OhmUnit_
		{
			get
			{
				if(_ohmUnit_==null)
				{
					_ohmUnit_ = new EntityCollection<OhmUnitEntity>(EntityFactoryCache2.GetEntityFactory(typeof(OhmUnitEntityFactory)));
					_ohmUnit_.SetContainingEntityInfo(this, "OhmUnit");
				}
				return _ohmUnit_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionToBeTakenOnGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionToBeTakenOnGeneratorEntity))]
		public virtual EntityCollection<ActionToBeTakenOnGeneratorEntity> ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______==null)
				{
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______ = new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory)));
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______.IsReadOnly=true;
				}
				return _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionToBeTakenOnGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionToBeTakenOnGeneratorEntity))]
		public virtual EntityCollection<ActionToBeTakenOnGeneratorEntity> ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____==null)
				{
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____ = new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory)));
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____.IsReadOnly=true;
				}
				return _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionToBeTakenOnGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionToBeTakenOnGeneratorEntity))]
		public virtual EntityCollection<ActionToBeTakenOnGeneratorEntity> ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________==null)
				{
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________ = new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory)));
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________.IsReadOnly=true;
				}
				return _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionToBeTakenOnGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionToBeTakenOnGeneratorEntity))]
		public virtual EntityCollection<ActionToBeTakenOnGeneratorEntity> ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______==null)
				{
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______ = new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory)));
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______.IsReadOnly=true;
				}
				return _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionToBeTakenOnGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionToBeTakenOnGeneratorEntity))]
		public virtual EntityCollection<ActionToBeTakenOnGeneratorEntity> ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____==null)
				{
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____ = new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory)));
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____.IsReadOnly=true;
				}
				return _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionToBeTakenOnGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionToBeTakenOnGeneratorEntity))]
		public virtual EntityCollection<ActionToBeTakenOnGeneratorEntity> ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_==null)
				{
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_ = new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory)));
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_.IsReadOnly=true;
				}
				return _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionToBeTakenOnGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionToBeTakenOnGeneratorEntity))]
		public virtual EntityCollection<ActionToBeTakenOnGeneratorEntity> ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator==null)
				{
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator = new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory)));
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionToBeTakenOnGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionToBeTakenOnGeneratorEntity))]
		public virtual EntityCollection<ActionToBeTakenOnGeneratorEntity> ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___==null)
				{
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___ = new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory)));
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___.IsReadOnly=true;
				}
				return _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ActionToBeTakenOnGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ActionToBeTakenOnGeneratorEntity))]
		public virtual EntityCollection<ActionToBeTakenOnGeneratorEntity> ActionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				if(_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__==null)
				{
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__ = new EntityCollection<ActionToBeTakenOnGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ActionToBeTakenOnGeneratorEntityFactory)));
					_actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__.IsReadOnly=true;
				}
				return _actionToBeTakenOnGeneratorCollectionViaComponentInspectionReportGenerator__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGenerator______==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGenerator______ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGenerator______.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGenerator______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGenerator_____==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGenerator_____ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGenerator_____.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGenerator_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGenerator________==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGenerator________ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGenerator________.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGenerator________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGenerator_______==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGenerator_______ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGenerator_______.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGenerator_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGenerator____==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGenerator____ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGenerator____.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGenerator____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGenerator_==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGenerator_ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGenerator_.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGenerator_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGenerator==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGenerator = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGenerator___==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGenerator___ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGenerator___.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGenerator___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'BooleanAnswerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(BooleanAnswerEntity))]
		public virtual EntityCollection<BooleanAnswerEntity> BooleanAnswerCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				if(_booleanAnswerCollectionViaComponentInspectionReportGenerator__==null)
				{
					_booleanAnswerCollectionViaComponentInspectionReportGenerator__ = new EntityCollection<BooleanAnswerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(BooleanAnswerEntityFactory)));
					_booleanAnswerCollectionViaComponentInspectionReportGenerator__.IsReadOnly=true;
				}
				return _booleanAnswerCollectionViaComponentInspectionReportGenerator__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator______==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator______ = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator______.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGenerator______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____ = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator_____.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGenerator_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator________==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator________ = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator________.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGenerator________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______ = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator_______.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGenerator_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator____==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator____ = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator____.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGenerator____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator_==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator_ = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator_.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGenerator_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator___==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator___ = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator___.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGenerator___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'ComponentInspectionReportEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(ComponentInspectionReportEntity))]
		public virtual EntityCollection<ComponentInspectionReportEntity> ComponentInspectionReportCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				if(_componentInspectionReportCollectionViaComponentInspectionReportGenerator__==null)
				{
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator__ = new EntityCollection<ComponentInspectionReportEntity>(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportEntityFactory)));
					_componentInspectionReportCollectionViaComponentInspectionReportGenerator__.IsReadOnly=true;
				}
				return _componentInspectionReportCollectionViaComponentInspectionReportGenerator__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouplingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouplingEntity))]
		public virtual EntityCollection<CouplingEntity> CouplingCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				if(_couplingCollectionViaComponentInspectionReportGenerator______==null)
				{
					_couplingCollectionViaComponentInspectionReportGenerator______ = new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory)));
					_couplingCollectionViaComponentInspectionReportGenerator______.IsReadOnly=true;
				}
				return _couplingCollectionViaComponentInspectionReportGenerator______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouplingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouplingEntity))]
		public virtual EntityCollection<CouplingEntity> CouplingCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				if(_couplingCollectionViaComponentInspectionReportGenerator_____==null)
				{
					_couplingCollectionViaComponentInspectionReportGenerator_____ = new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory)));
					_couplingCollectionViaComponentInspectionReportGenerator_____.IsReadOnly=true;
				}
				return _couplingCollectionViaComponentInspectionReportGenerator_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouplingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouplingEntity))]
		public virtual EntityCollection<CouplingEntity> CouplingCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				if(_couplingCollectionViaComponentInspectionReportGenerator________==null)
				{
					_couplingCollectionViaComponentInspectionReportGenerator________ = new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory)));
					_couplingCollectionViaComponentInspectionReportGenerator________.IsReadOnly=true;
				}
				return _couplingCollectionViaComponentInspectionReportGenerator________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouplingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouplingEntity))]
		public virtual EntityCollection<CouplingEntity> CouplingCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				if(_couplingCollectionViaComponentInspectionReportGenerator_______==null)
				{
					_couplingCollectionViaComponentInspectionReportGenerator_______ = new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory)));
					_couplingCollectionViaComponentInspectionReportGenerator_______.IsReadOnly=true;
				}
				return _couplingCollectionViaComponentInspectionReportGenerator_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouplingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouplingEntity))]
		public virtual EntityCollection<CouplingEntity> CouplingCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				if(_couplingCollectionViaComponentInspectionReportGenerator____==null)
				{
					_couplingCollectionViaComponentInspectionReportGenerator____ = new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory)));
					_couplingCollectionViaComponentInspectionReportGenerator____.IsReadOnly=true;
				}
				return _couplingCollectionViaComponentInspectionReportGenerator____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouplingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouplingEntity))]
		public virtual EntityCollection<CouplingEntity> CouplingCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				if(_couplingCollectionViaComponentInspectionReportGenerator_==null)
				{
					_couplingCollectionViaComponentInspectionReportGenerator_ = new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory)));
					_couplingCollectionViaComponentInspectionReportGenerator_.IsReadOnly=true;
				}
				return _couplingCollectionViaComponentInspectionReportGenerator_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouplingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouplingEntity))]
		public virtual EntityCollection<CouplingEntity> CouplingCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_couplingCollectionViaComponentInspectionReportGenerator==null)
				{
					_couplingCollectionViaComponentInspectionReportGenerator = new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory)));
					_couplingCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _couplingCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouplingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouplingEntity))]
		public virtual EntityCollection<CouplingEntity> CouplingCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				if(_couplingCollectionViaComponentInspectionReportGenerator___==null)
				{
					_couplingCollectionViaComponentInspectionReportGenerator___ = new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory)));
					_couplingCollectionViaComponentInspectionReportGenerator___.IsReadOnly=true;
				}
				return _couplingCollectionViaComponentInspectionReportGenerator___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'CouplingEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(CouplingEntity))]
		public virtual EntityCollection<CouplingEntity> CouplingCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				if(_couplingCollectionViaComponentInspectionReportGenerator__==null)
				{
					_couplingCollectionViaComponentInspectionReportGenerator__ = new EntityCollection<CouplingEntity>(EntityFactoryCache2.GetEntityFactory(typeof(CouplingEntityFactory)));
					_couplingCollectionViaComponentInspectionReportGenerator__.IsReadOnly=true;
				}
				return _couplingCollectionViaComponentInspectionReportGenerator__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorCoverEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorCoverEntity))]
		public virtual EntityCollection<GeneratorCoverEntity> GeneratorCoverCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				if(_generatorCoverCollectionViaComponentInspectionReportGenerator______==null)
				{
					_generatorCoverCollectionViaComponentInspectionReportGenerator______ = new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory)));
					_generatorCoverCollectionViaComponentInspectionReportGenerator______.IsReadOnly=true;
				}
				return _generatorCoverCollectionViaComponentInspectionReportGenerator______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorCoverEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorCoverEntity))]
		public virtual EntityCollection<GeneratorCoverEntity> GeneratorCoverCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				if(_generatorCoverCollectionViaComponentInspectionReportGenerator_____==null)
				{
					_generatorCoverCollectionViaComponentInspectionReportGenerator_____ = new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory)));
					_generatorCoverCollectionViaComponentInspectionReportGenerator_____.IsReadOnly=true;
				}
				return _generatorCoverCollectionViaComponentInspectionReportGenerator_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorCoverEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorCoverEntity))]
		public virtual EntityCollection<GeneratorCoverEntity> GeneratorCoverCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				if(_generatorCoverCollectionViaComponentInspectionReportGenerator________==null)
				{
					_generatorCoverCollectionViaComponentInspectionReportGenerator________ = new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory)));
					_generatorCoverCollectionViaComponentInspectionReportGenerator________.IsReadOnly=true;
				}
				return _generatorCoverCollectionViaComponentInspectionReportGenerator________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorCoverEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorCoverEntity))]
		public virtual EntityCollection<GeneratorCoverEntity> GeneratorCoverCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				if(_generatorCoverCollectionViaComponentInspectionReportGenerator_______==null)
				{
					_generatorCoverCollectionViaComponentInspectionReportGenerator_______ = new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory)));
					_generatorCoverCollectionViaComponentInspectionReportGenerator_______.IsReadOnly=true;
				}
				return _generatorCoverCollectionViaComponentInspectionReportGenerator_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorCoverEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorCoverEntity))]
		public virtual EntityCollection<GeneratorCoverEntity> GeneratorCoverCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				if(_generatorCoverCollectionViaComponentInspectionReportGenerator____==null)
				{
					_generatorCoverCollectionViaComponentInspectionReportGenerator____ = new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory)));
					_generatorCoverCollectionViaComponentInspectionReportGenerator____.IsReadOnly=true;
				}
				return _generatorCoverCollectionViaComponentInspectionReportGenerator____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorCoverEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorCoverEntity))]
		public virtual EntityCollection<GeneratorCoverEntity> GeneratorCoverCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				if(_generatorCoverCollectionViaComponentInspectionReportGenerator_==null)
				{
					_generatorCoverCollectionViaComponentInspectionReportGenerator_ = new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory)));
					_generatorCoverCollectionViaComponentInspectionReportGenerator_.IsReadOnly=true;
				}
				return _generatorCoverCollectionViaComponentInspectionReportGenerator_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorCoverEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorCoverEntity))]
		public virtual EntityCollection<GeneratorCoverEntity> GeneratorCoverCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_generatorCoverCollectionViaComponentInspectionReportGenerator==null)
				{
					_generatorCoverCollectionViaComponentInspectionReportGenerator = new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory)));
					_generatorCoverCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _generatorCoverCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorCoverEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorCoverEntity))]
		public virtual EntityCollection<GeneratorCoverEntity> GeneratorCoverCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				if(_generatorCoverCollectionViaComponentInspectionReportGenerator___==null)
				{
					_generatorCoverCollectionViaComponentInspectionReportGenerator___ = new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory)));
					_generatorCoverCollectionViaComponentInspectionReportGenerator___.IsReadOnly=true;
				}
				return _generatorCoverCollectionViaComponentInspectionReportGenerator___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorCoverEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorCoverEntity))]
		public virtual EntityCollection<GeneratorCoverEntity> GeneratorCoverCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				if(_generatorCoverCollectionViaComponentInspectionReportGenerator__==null)
				{
					_generatorCoverCollectionViaComponentInspectionReportGenerator__ = new EntityCollection<GeneratorCoverEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorCoverEntityFactory)));
					_generatorCoverCollectionViaComponentInspectionReportGenerator__.IsReadOnly=true;
				}
				return _generatorCoverCollectionViaComponentInspectionReportGenerator__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDriveEndEntity))]
		public virtual EntityCollection<GeneratorDriveEndEntity> GeneratorDriveEndCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator______==null)
				{
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator______ = new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory)));
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator______.IsReadOnly=true;
				}
				return _generatorDriveEndCollectionViaComponentInspectionReportGenerator______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDriveEndEntity))]
		public virtual EntityCollection<GeneratorDriveEndEntity> GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____==null)
				{
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____ = new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory)));
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator_____.IsReadOnly=true;
				}
				return _generatorDriveEndCollectionViaComponentInspectionReportGenerator_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDriveEndEntity))]
		public virtual EntityCollection<GeneratorDriveEndEntity> GeneratorDriveEndCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator________==null)
				{
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator________ = new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory)));
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator________.IsReadOnly=true;
				}
				return _generatorDriveEndCollectionViaComponentInspectionReportGenerator________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDriveEndEntity))]
		public virtual EntityCollection<GeneratorDriveEndEntity> GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______==null)
				{
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______ = new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory)));
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator_______.IsReadOnly=true;
				}
				return _generatorDriveEndCollectionViaComponentInspectionReportGenerator_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDriveEndEntity))]
		public virtual EntityCollection<GeneratorDriveEndEntity> GeneratorDriveEndCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator____==null)
				{
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator____ = new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory)));
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator____.IsReadOnly=true;
				}
				return _generatorDriveEndCollectionViaComponentInspectionReportGenerator____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDriveEndEntity))]
		public virtual EntityCollection<GeneratorDriveEndEntity> GeneratorDriveEndCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator_==null)
				{
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator_ = new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory)));
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator_.IsReadOnly=true;
				}
				return _generatorDriveEndCollectionViaComponentInspectionReportGenerator_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDriveEndEntity))]
		public virtual EntityCollection<GeneratorDriveEndEntity> GeneratorDriveEndCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator==null)
				{
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator = new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory)));
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _generatorDriveEndCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDriveEndEntity))]
		public virtual EntityCollection<GeneratorDriveEndEntity> GeneratorDriveEndCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator___==null)
				{
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator___ = new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory)));
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator___.IsReadOnly=true;
				}
				return _generatorDriveEndCollectionViaComponentInspectionReportGenerator___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorDriveEndEntity))]
		public virtual EntityCollection<GeneratorDriveEndEntity> GeneratorDriveEndCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				if(_generatorDriveEndCollectionViaComponentInspectionReportGenerator__==null)
				{
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator__ = new EntityCollection<GeneratorDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorDriveEndEntityFactory)));
					_generatorDriveEndCollectionViaComponentInspectionReportGenerator__.IsReadOnly=true;
				}
				return _generatorDriveEndCollectionViaComponentInspectionReportGenerator__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator______==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator______ = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator______.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGenerator______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____ = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator_____.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGenerator_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator________==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator________ = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator________.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGenerator________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______ = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator_______.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGenerator_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator____==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator____ = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator____.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGenerator____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator_==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator_ = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator_.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGenerator_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator___==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator___ = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator___.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGenerator___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorManufacturerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorManufacturerEntity))]
		public virtual EntityCollection<GeneratorManufacturerEntity> GeneratorManufacturerCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				if(_generatorManufacturerCollectionViaComponentInspectionReportGenerator__==null)
				{
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator__ = new EntityCollection<GeneratorManufacturerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorManufacturerEntityFactory)));
					_generatorManufacturerCollectionViaComponentInspectionReportGenerator__.IsReadOnly=true;
				}
				return _generatorManufacturerCollectionViaComponentInspectionReportGenerator__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorNonDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorNonDriveEndEntity))]
		public virtual EntityCollection<GeneratorNonDriveEndEntity> GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______==null)
				{
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______ = new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory)));
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______.IsReadOnly=true;
				}
				return _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorNonDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorNonDriveEndEntity))]
		public virtual EntityCollection<GeneratorNonDriveEndEntity> GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____==null)
				{
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____ = new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory)));
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____.IsReadOnly=true;
				}
				return _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorNonDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorNonDriveEndEntity))]
		public virtual EntityCollection<GeneratorNonDriveEndEntity> GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________==null)
				{
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________ = new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory)));
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________.IsReadOnly=true;
				}
				return _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorNonDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorNonDriveEndEntity))]
		public virtual EntityCollection<GeneratorNonDriveEndEntity> GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______==null)
				{
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______ = new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory)));
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______.IsReadOnly=true;
				}
				return _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorNonDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorNonDriveEndEntity))]
		public virtual EntityCollection<GeneratorNonDriveEndEntity> GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____==null)
				{
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____ = new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory)));
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____.IsReadOnly=true;
				}
				return _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorNonDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorNonDriveEndEntity))]
		public virtual EntityCollection<GeneratorNonDriveEndEntity> GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_==null)
				{
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_ = new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory)));
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_.IsReadOnly=true;
				}
				return _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorNonDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorNonDriveEndEntity))]
		public virtual EntityCollection<GeneratorNonDriveEndEntity> GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator==null)
				{
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator = new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory)));
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorNonDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorNonDriveEndEntity))]
		public virtual EntityCollection<GeneratorNonDriveEndEntity> GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___==null)
				{
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___ = new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory)));
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___.IsReadOnly=true;
				}
				return _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorNonDriveEndEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorNonDriveEndEntity))]
		public virtual EntityCollection<GeneratorNonDriveEndEntity> GeneratorNonDriveEndCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				if(_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__==null)
				{
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__ = new EntityCollection<GeneratorNonDriveEndEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorNonDriveEndEntityFactory)));
					_generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__.IsReadOnly=true;
				}
				return _generatorNonDriveEndCollectionViaComponentInspectionReportGenerator__;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorRotorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorRotorEntity))]
		public virtual EntityCollection<GeneratorRotorEntity> GeneratorRotorCollectionViaComponentInspectionReportGenerator______
		{
			get
			{
				if(_generatorRotorCollectionViaComponentInspectionReportGenerator______==null)
				{
					_generatorRotorCollectionViaComponentInspectionReportGenerator______ = new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory)));
					_generatorRotorCollectionViaComponentInspectionReportGenerator______.IsReadOnly=true;
				}
				return _generatorRotorCollectionViaComponentInspectionReportGenerator______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorRotorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorRotorEntity))]
		public virtual EntityCollection<GeneratorRotorEntity> GeneratorRotorCollectionViaComponentInspectionReportGenerator_____
		{
			get
			{
				if(_generatorRotorCollectionViaComponentInspectionReportGenerator_____==null)
				{
					_generatorRotorCollectionViaComponentInspectionReportGenerator_____ = new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory)));
					_generatorRotorCollectionViaComponentInspectionReportGenerator_____.IsReadOnly=true;
				}
				return _generatorRotorCollectionViaComponentInspectionReportGenerator_____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorRotorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorRotorEntity))]
		public virtual EntityCollection<GeneratorRotorEntity> GeneratorRotorCollectionViaComponentInspectionReportGenerator________
		{
			get
			{
				if(_generatorRotorCollectionViaComponentInspectionReportGenerator________==null)
				{
					_generatorRotorCollectionViaComponentInspectionReportGenerator________ = new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory)));
					_generatorRotorCollectionViaComponentInspectionReportGenerator________.IsReadOnly=true;
				}
				return _generatorRotorCollectionViaComponentInspectionReportGenerator________;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorRotorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorRotorEntity))]
		public virtual EntityCollection<GeneratorRotorEntity> GeneratorRotorCollectionViaComponentInspectionReportGenerator_______
		{
			get
			{
				if(_generatorRotorCollectionViaComponentInspectionReportGenerator_______==null)
				{
					_generatorRotorCollectionViaComponentInspectionReportGenerator_______ = new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory)));
					_generatorRotorCollectionViaComponentInspectionReportGenerator_______.IsReadOnly=true;
				}
				return _generatorRotorCollectionViaComponentInspectionReportGenerator_______;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorRotorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorRotorEntity))]
		public virtual EntityCollection<GeneratorRotorEntity> GeneratorRotorCollectionViaComponentInspectionReportGenerator____
		{
			get
			{
				if(_generatorRotorCollectionViaComponentInspectionReportGenerator____==null)
				{
					_generatorRotorCollectionViaComponentInspectionReportGenerator____ = new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory)));
					_generatorRotorCollectionViaComponentInspectionReportGenerator____.IsReadOnly=true;
				}
				return _generatorRotorCollectionViaComponentInspectionReportGenerator____;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorRotorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorRotorEntity))]
		public virtual EntityCollection<GeneratorRotorEntity> GeneratorRotorCollectionViaComponentInspectionReportGenerator_
		{
			get
			{
				if(_generatorRotorCollectionViaComponentInspectionReportGenerator_==null)
				{
					_generatorRotorCollectionViaComponentInspectionReportGenerator_ = new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory)));
					_generatorRotorCollectionViaComponentInspectionReportGenerator_.IsReadOnly=true;
				}
				return _generatorRotorCollectionViaComponentInspectionReportGenerator_;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorRotorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorRotorEntity))]
		public virtual EntityCollection<GeneratorRotorEntity> GeneratorRotorCollectionViaComponentInspectionReportGenerator
		{
			get
			{
				if(_generatorRotorCollectionViaComponentInspectionReportGenerator==null)
				{
					_generatorRotorCollectionViaComponentInspectionReportGenerator = new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory)));
					_generatorRotorCollectionViaComponentInspectionReportGenerator.IsReadOnly=true;
				}
				return _generatorRotorCollectionViaComponentInspectionReportGenerator;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorRotorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorRotorEntity))]
		public virtual EntityCollection<GeneratorRotorEntity> GeneratorRotorCollectionViaComponentInspectionReportGenerator___
		{
			get
			{
				if(_generatorRotorCollectionViaComponentInspectionReportGenerator___==null)
				{
					_generatorRotorCollectionViaComponentInspectionReportGenerator___ = new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory)));
					_generatorRotorCollectionViaComponentInspectionReportGenerator___.IsReadOnly=true;
				}
				return _generatorRotorCollectionViaComponentInspectionReportGenerator___;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'GeneratorRotorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(GeneratorRotorEntity))]
		public virtual EntityCollection<GeneratorRotorEntity> GeneratorRotorCollectionViaComponentInspectionReportGenerator__
		{
			get
			{
				if(_generatorRotorCollectionViaComponentInspectionReportGenerator__==null)
				{
					_generatorRotorCollectionViaComponentInspectionReportGenerator__ = new EntityCollection<GeneratorRotorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(GeneratorRotorEntityFactory)));
					_generatorRotorCollectionViaComponentInspectionReportGenerator__.IsReadOnly=true;
				}
				return _generatorRotorCollectionViaComponentInspectionReportGenerator__;
			}
		}

		/// <summary> Gets / sets related entity of type 'OhmUnitEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual OhmUnitEntity OhmUnit
		{
			get
			{
				return _ohmUnit;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncOhmUnit(value);
				}
				else
				{
					if(value==null)
					{
						if(_ohmUnit != null)
						{
							_ohmUnit.UnsetRelatedEntity(this, "OhmUnit_");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "OhmUnit_");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.OhmUnitEntity; }
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
