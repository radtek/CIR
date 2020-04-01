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
	/// Entity class which represents the entity 'TurbineManufacturer'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class TurbineManufacturerEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations
		private EntityCollection<TurbineMatrixEntity> _turbineMatrix;
		private EntityCollection<TurbineEntity> _turbineCollectionViaTurbineMatrix;
		private EntityCollection<TurbineFrequencyEntity> _turbineFrequencyCollectionViaTurbineMatrix;
		private EntityCollection<TurbineMarkVersionEntity> _turbineMarkVersionCollectionViaTurbineMatrix;
		private EntityCollection<TurbineNominelPowerEntity> _turbineNominelPowerCollectionViaTurbineMatrix;
		private EntityCollection<TurbineOldEntity> _turbineOldCollectionViaTurbineMatrix;
		private EntityCollection<TurbinePlacementEntity> _turbinePlacementCollectionViaTurbineMatrix;
		private EntityCollection<TurbinePowerRegulationEntity> _turbinePowerRegulationCollectionViaTurbineMatrix;
		private EntityCollection<TurbineRotorDiameterEntity> _turbineRotorDiameterCollectionViaTurbineMatrix;
		private EntityCollection<TurbineSmallGeneratorEntity> _turbineSmallGeneratorCollectionViaTurbineMatrix;
		private EntityCollection<TurbineTemperatureVariantEntity> _turbineTemperatureVariantCollectionViaTurbineMatrix;
		private EntityCollection<TurbineVoltageEntity> _turbineVoltageCollectionViaTurbineMatrix;


		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{

			/// <summary>Member name TurbineMatrix</summary>
			public static readonly string TurbineMatrix = "TurbineMatrix";
			/// <summary>Member name TurbineCollectionViaTurbineMatrix</summary>
			public static readonly string TurbineCollectionViaTurbineMatrix = "TurbineCollectionViaTurbineMatrix";
			/// <summary>Member name TurbineFrequencyCollectionViaTurbineMatrix</summary>
			public static readonly string TurbineFrequencyCollectionViaTurbineMatrix = "TurbineFrequencyCollectionViaTurbineMatrix";
			/// <summary>Member name TurbineMarkVersionCollectionViaTurbineMatrix</summary>
			public static readonly string TurbineMarkVersionCollectionViaTurbineMatrix = "TurbineMarkVersionCollectionViaTurbineMatrix";
			/// <summary>Member name TurbineNominelPowerCollectionViaTurbineMatrix</summary>
			public static readonly string TurbineNominelPowerCollectionViaTurbineMatrix = "TurbineNominelPowerCollectionViaTurbineMatrix";
			/// <summary>Member name TurbineOldCollectionViaTurbineMatrix</summary>
			public static readonly string TurbineOldCollectionViaTurbineMatrix = "TurbineOldCollectionViaTurbineMatrix";
			/// <summary>Member name TurbinePlacementCollectionViaTurbineMatrix</summary>
			public static readonly string TurbinePlacementCollectionViaTurbineMatrix = "TurbinePlacementCollectionViaTurbineMatrix";
			/// <summary>Member name TurbinePowerRegulationCollectionViaTurbineMatrix</summary>
			public static readonly string TurbinePowerRegulationCollectionViaTurbineMatrix = "TurbinePowerRegulationCollectionViaTurbineMatrix";
			/// <summary>Member name TurbineRotorDiameterCollectionViaTurbineMatrix</summary>
			public static readonly string TurbineRotorDiameterCollectionViaTurbineMatrix = "TurbineRotorDiameterCollectionViaTurbineMatrix";
			/// <summary>Member name TurbineSmallGeneratorCollectionViaTurbineMatrix</summary>
			public static readonly string TurbineSmallGeneratorCollectionViaTurbineMatrix = "TurbineSmallGeneratorCollectionViaTurbineMatrix";
			/// <summary>Member name TurbineTemperatureVariantCollectionViaTurbineMatrix</summary>
			public static readonly string TurbineTemperatureVariantCollectionViaTurbineMatrix = "TurbineTemperatureVariantCollectionViaTurbineMatrix";
			/// <summary>Member name TurbineVoltageCollectionViaTurbineMatrix</summary>
			public static readonly string TurbineVoltageCollectionViaTurbineMatrix = "TurbineVoltageCollectionViaTurbineMatrix";

		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static TurbineManufacturerEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public TurbineManufacturerEntity():base("TurbineManufacturerEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public TurbineManufacturerEntity(IEntityFields2 fields):base("TurbineManufacturerEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this TurbineManufacturerEntity</param>
		public TurbineManufacturerEntity(IValidator validator):base("TurbineManufacturerEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="turbineManufacturerId">PK value for TurbineManufacturer which data should be fetched into this TurbineManufacturer object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TurbineManufacturerEntity(System.Int64 turbineManufacturerId):base("TurbineManufacturerEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.TurbineManufacturerId = turbineManufacturerId;
		}

		/// <summary> CTor</summary>
		/// <param name="turbineManufacturerId">PK value for TurbineManufacturer which data should be fetched into this TurbineManufacturer object</param>
		/// <param name="validator">The custom validator object for this TurbineManufacturerEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public TurbineManufacturerEntity(System.Int64 turbineManufacturerId, IValidator validator):base("TurbineManufacturerEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.TurbineManufacturerId = turbineManufacturerId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected TurbineManufacturerEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{
				_turbineMatrix = (EntityCollection<TurbineMatrixEntity>)info.GetValue("_turbineMatrix", typeof(EntityCollection<TurbineMatrixEntity>));
				_turbineCollectionViaTurbineMatrix = (EntityCollection<TurbineEntity>)info.GetValue("_turbineCollectionViaTurbineMatrix", typeof(EntityCollection<TurbineEntity>));
				_turbineFrequencyCollectionViaTurbineMatrix = (EntityCollection<TurbineFrequencyEntity>)info.GetValue("_turbineFrequencyCollectionViaTurbineMatrix", typeof(EntityCollection<TurbineFrequencyEntity>));
				_turbineMarkVersionCollectionViaTurbineMatrix = (EntityCollection<TurbineMarkVersionEntity>)info.GetValue("_turbineMarkVersionCollectionViaTurbineMatrix", typeof(EntityCollection<TurbineMarkVersionEntity>));
				_turbineNominelPowerCollectionViaTurbineMatrix = (EntityCollection<TurbineNominelPowerEntity>)info.GetValue("_turbineNominelPowerCollectionViaTurbineMatrix", typeof(EntityCollection<TurbineNominelPowerEntity>));
				_turbineOldCollectionViaTurbineMatrix = (EntityCollection<TurbineOldEntity>)info.GetValue("_turbineOldCollectionViaTurbineMatrix", typeof(EntityCollection<TurbineOldEntity>));
				_turbinePlacementCollectionViaTurbineMatrix = (EntityCollection<TurbinePlacementEntity>)info.GetValue("_turbinePlacementCollectionViaTurbineMatrix", typeof(EntityCollection<TurbinePlacementEntity>));
				_turbinePowerRegulationCollectionViaTurbineMatrix = (EntityCollection<TurbinePowerRegulationEntity>)info.GetValue("_turbinePowerRegulationCollectionViaTurbineMatrix", typeof(EntityCollection<TurbinePowerRegulationEntity>));
				_turbineRotorDiameterCollectionViaTurbineMatrix = (EntityCollection<TurbineRotorDiameterEntity>)info.GetValue("_turbineRotorDiameterCollectionViaTurbineMatrix", typeof(EntityCollection<TurbineRotorDiameterEntity>));
				_turbineSmallGeneratorCollectionViaTurbineMatrix = (EntityCollection<TurbineSmallGeneratorEntity>)info.GetValue("_turbineSmallGeneratorCollectionViaTurbineMatrix", typeof(EntityCollection<TurbineSmallGeneratorEntity>));
				_turbineTemperatureVariantCollectionViaTurbineMatrix = (EntityCollection<TurbineTemperatureVariantEntity>)info.GetValue("_turbineTemperatureVariantCollectionViaTurbineMatrix", typeof(EntityCollection<TurbineTemperatureVariantEntity>));
				_turbineVoltageCollectionViaTurbineMatrix = (EntityCollection<TurbineVoltageEntity>)info.GetValue("_turbineVoltageCollectionViaTurbineMatrix", typeof(EntityCollection<TurbineVoltageEntity>));


				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((TurbineManufacturerFieldIndex)fieldIndex)
			{
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

				case "TurbineMatrix":
					this.TurbineMatrix.Add((TurbineMatrixEntity)entity);
					break;
				case "TurbineCollectionViaTurbineMatrix":
					this.TurbineCollectionViaTurbineMatrix.IsReadOnly = false;
					this.TurbineCollectionViaTurbineMatrix.Add((TurbineEntity)entity);
					this.TurbineCollectionViaTurbineMatrix.IsReadOnly = true;
					break;
				case "TurbineFrequencyCollectionViaTurbineMatrix":
					this.TurbineFrequencyCollectionViaTurbineMatrix.IsReadOnly = false;
					this.TurbineFrequencyCollectionViaTurbineMatrix.Add((TurbineFrequencyEntity)entity);
					this.TurbineFrequencyCollectionViaTurbineMatrix.IsReadOnly = true;
					break;
				case "TurbineMarkVersionCollectionViaTurbineMatrix":
					this.TurbineMarkVersionCollectionViaTurbineMatrix.IsReadOnly = false;
					this.TurbineMarkVersionCollectionViaTurbineMatrix.Add((TurbineMarkVersionEntity)entity);
					this.TurbineMarkVersionCollectionViaTurbineMatrix.IsReadOnly = true;
					break;
				case "TurbineNominelPowerCollectionViaTurbineMatrix":
					this.TurbineNominelPowerCollectionViaTurbineMatrix.IsReadOnly = false;
					this.TurbineNominelPowerCollectionViaTurbineMatrix.Add((TurbineNominelPowerEntity)entity);
					this.TurbineNominelPowerCollectionViaTurbineMatrix.IsReadOnly = true;
					break;
				case "TurbineOldCollectionViaTurbineMatrix":
					this.TurbineOldCollectionViaTurbineMatrix.IsReadOnly = false;
					this.TurbineOldCollectionViaTurbineMatrix.Add((TurbineOldEntity)entity);
					this.TurbineOldCollectionViaTurbineMatrix.IsReadOnly = true;
					break;
				case "TurbinePlacementCollectionViaTurbineMatrix":
					this.TurbinePlacementCollectionViaTurbineMatrix.IsReadOnly = false;
					this.TurbinePlacementCollectionViaTurbineMatrix.Add((TurbinePlacementEntity)entity);
					this.TurbinePlacementCollectionViaTurbineMatrix.IsReadOnly = true;
					break;
				case "TurbinePowerRegulationCollectionViaTurbineMatrix":
					this.TurbinePowerRegulationCollectionViaTurbineMatrix.IsReadOnly = false;
					this.TurbinePowerRegulationCollectionViaTurbineMatrix.Add((TurbinePowerRegulationEntity)entity);
					this.TurbinePowerRegulationCollectionViaTurbineMatrix.IsReadOnly = true;
					break;
				case "TurbineRotorDiameterCollectionViaTurbineMatrix":
					this.TurbineRotorDiameterCollectionViaTurbineMatrix.IsReadOnly = false;
					this.TurbineRotorDiameterCollectionViaTurbineMatrix.Add((TurbineRotorDiameterEntity)entity);
					this.TurbineRotorDiameterCollectionViaTurbineMatrix.IsReadOnly = true;
					break;
				case "TurbineSmallGeneratorCollectionViaTurbineMatrix":
					this.TurbineSmallGeneratorCollectionViaTurbineMatrix.IsReadOnly = false;
					this.TurbineSmallGeneratorCollectionViaTurbineMatrix.Add((TurbineSmallGeneratorEntity)entity);
					this.TurbineSmallGeneratorCollectionViaTurbineMatrix.IsReadOnly = true;
					break;
				case "TurbineTemperatureVariantCollectionViaTurbineMatrix":
					this.TurbineTemperatureVariantCollectionViaTurbineMatrix.IsReadOnly = false;
					this.TurbineTemperatureVariantCollectionViaTurbineMatrix.Add((TurbineTemperatureVariantEntity)entity);
					this.TurbineTemperatureVariantCollectionViaTurbineMatrix.IsReadOnly = true;
					break;
				case "TurbineVoltageCollectionViaTurbineMatrix":
					this.TurbineVoltageCollectionViaTurbineMatrix.IsReadOnly = false;
					this.TurbineVoltageCollectionViaTurbineMatrix.Add((TurbineVoltageEntity)entity);
					this.TurbineVoltageCollectionViaTurbineMatrix.IsReadOnly = true;
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

				case "TurbineMatrix":
					this.TurbineMatrix.Add((TurbineMatrixEntity)relatedEntity);
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

				case "TurbineMatrix":
					base.PerformRelatedEntityRemoval(this.TurbineMatrix, relatedEntity, signalRelatedEntityManyToOne);
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


			return toReturn;
		}
		
		/// <summary>Gets a list of all entity collections stored as member variables in this entity. The contents of the ArrayList is used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.</summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		public override List<IEntityCollection2> GetMemberEntityCollections()
		{
			List<IEntityCollection2> toReturn = new List<IEntityCollection2>();
			toReturn.Add(this.TurbineMatrix);

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
				info.AddValue("_turbineMatrix", ((_turbineMatrix!=null) && (_turbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbineMatrix:null);
				info.AddValue("_turbineCollectionViaTurbineMatrix", ((_turbineCollectionViaTurbineMatrix!=null) && (_turbineCollectionViaTurbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbineCollectionViaTurbineMatrix:null);
				info.AddValue("_turbineFrequencyCollectionViaTurbineMatrix", ((_turbineFrequencyCollectionViaTurbineMatrix!=null) && (_turbineFrequencyCollectionViaTurbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbineFrequencyCollectionViaTurbineMatrix:null);
				info.AddValue("_turbineMarkVersionCollectionViaTurbineMatrix", ((_turbineMarkVersionCollectionViaTurbineMatrix!=null) && (_turbineMarkVersionCollectionViaTurbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbineMarkVersionCollectionViaTurbineMatrix:null);
				info.AddValue("_turbineNominelPowerCollectionViaTurbineMatrix", ((_turbineNominelPowerCollectionViaTurbineMatrix!=null) && (_turbineNominelPowerCollectionViaTurbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbineNominelPowerCollectionViaTurbineMatrix:null);
				info.AddValue("_turbineOldCollectionViaTurbineMatrix", ((_turbineOldCollectionViaTurbineMatrix!=null) && (_turbineOldCollectionViaTurbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbineOldCollectionViaTurbineMatrix:null);
				info.AddValue("_turbinePlacementCollectionViaTurbineMatrix", ((_turbinePlacementCollectionViaTurbineMatrix!=null) && (_turbinePlacementCollectionViaTurbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbinePlacementCollectionViaTurbineMatrix:null);
				info.AddValue("_turbinePowerRegulationCollectionViaTurbineMatrix", ((_turbinePowerRegulationCollectionViaTurbineMatrix!=null) && (_turbinePowerRegulationCollectionViaTurbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbinePowerRegulationCollectionViaTurbineMatrix:null);
				info.AddValue("_turbineRotorDiameterCollectionViaTurbineMatrix", ((_turbineRotorDiameterCollectionViaTurbineMatrix!=null) && (_turbineRotorDiameterCollectionViaTurbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbineRotorDiameterCollectionViaTurbineMatrix:null);
				info.AddValue("_turbineSmallGeneratorCollectionViaTurbineMatrix", ((_turbineSmallGeneratorCollectionViaTurbineMatrix!=null) && (_turbineSmallGeneratorCollectionViaTurbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbineSmallGeneratorCollectionViaTurbineMatrix:null);
				info.AddValue("_turbineTemperatureVariantCollectionViaTurbineMatrix", ((_turbineTemperatureVariantCollectionViaTurbineMatrix!=null) && (_turbineTemperatureVariantCollectionViaTurbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbineTemperatureVariantCollectionViaTurbineMatrix:null);
				info.AddValue("_turbineVoltageCollectionViaTurbineMatrix", ((_turbineVoltageCollectionViaTurbineMatrix!=null) && (_turbineVoltageCollectionViaTurbineMatrix.Count>0) && !this.MarkedForDeletion)?_turbineVoltageCollectionViaTurbineMatrix:null);


			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(TurbineManufacturerFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(TurbineManufacturerFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new TurbineManufacturerRelations().GetAllRelations();
		}
		

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineMatrix' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineMatrixFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'Turbine' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineCollectionViaTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
			bucket.Relations.Add(TurbineMatrixEntity.Relations.TurbineEntityUsingTurbineId, "TurbineMatrix_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId, "TurbineManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineFrequency' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineFrequencyCollectionViaTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
			bucket.Relations.Add(TurbineMatrixEntity.Relations.TurbineFrequencyEntityUsingTurbineFrequencyId, "TurbineMatrix_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId, "TurbineManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineMarkVersion' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineMarkVersionCollectionViaTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
			bucket.Relations.Add(TurbineMatrixEntity.Relations.TurbineMarkVersionEntityUsingTurbineMarkVersionId, "TurbineMatrix_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId, "TurbineManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineNominelPower' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineNominelPowerCollectionViaTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
			bucket.Relations.Add(TurbineMatrixEntity.Relations.TurbineNominelPowerEntityUsingTurbineNominelPowerId, "TurbineMatrix_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId, "TurbineManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineOld' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineOldCollectionViaTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
			bucket.Relations.Add(TurbineMatrixEntity.Relations.TurbineOldEntityUsingTurbineOldId, "TurbineMatrix_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId, "TurbineManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbinePlacement' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbinePlacementCollectionViaTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
			bucket.Relations.Add(TurbineMatrixEntity.Relations.TurbinePlacementEntityUsingTurbinePlacementId, "TurbineMatrix_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId, "TurbineManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbinePowerRegulation' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbinePowerRegulationCollectionViaTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
			bucket.Relations.Add(TurbineMatrixEntity.Relations.TurbinePowerRegulationEntityUsingTurbinePowerRegulationId, "TurbineMatrix_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId, "TurbineManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineRotorDiameter' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineRotorDiameterCollectionViaTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
			bucket.Relations.Add(TurbineMatrixEntity.Relations.TurbineRotorDiameterEntityUsingTurbineRotorDiameterId, "TurbineMatrix_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId, "TurbineManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineSmallGenerator' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineSmallGeneratorCollectionViaTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
			bucket.Relations.Add(TurbineMatrixEntity.Relations.TurbineSmallGeneratorEntityUsingTurbineSmallGeneratorId, "TurbineMatrix_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId, "TurbineManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineTemperatureVariant' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineTemperatureVariantCollectionViaTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
			bucket.Relations.Add(TurbineMatrixEntity.Relations.TurbineTemperatureVariantEntityUsingTurbineTemperatureVariantId, "TurbineMatrix_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId, "TurbineManufacturerEntity__"));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entities of type 'TurbineVoltage' to this entity. Use DataAccessAdapter.FetchEntityCollection() to fetch these related entities.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoTurbineVoltageCollectionViaTurbineMatrix()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.Relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
			bucket.Relations.Add(TurbineMatrixEntity.Relations.TurbineVoltageEntityUsingTurbineVoltageId, "TurbineMatrix_", string.Empty, JoinHint.None);
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(TurbineManufacturerFields.TurbineManufacturerId, null, ComparisonOperator.Equal, this.TurbineManufacturerId, "TurbineManufacturerEntity__"));
			return bucket;
		}


	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(TurbineManufacturerEntityFactory));
		}
#if !CF
		/// <summary>Adds the member collections to the collections queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void AddToMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue) 
		{
			base.AddToMemberEntityCollectionsQueue(collectionsQueue);
			collectionsQueue.Enqueue(this._turbineMatrix);
			collectionsQueue.Enqueue(this._turbineCollectionViaTurbineMatrix);
			collectionsQueue.Enqueue(this._turbineFrequencyCollectionViaTurbineMatrix);
			collectionsQueue.Enqueue(this._turbineMarkVersionCollectionViaTurbineMatrix);
			collectionsQueue.Enqueue(this._turbineNominelPowerCollectionViaTurbineMatrix);
			collectionsQueue.Enqueue(this._turbineOldCollectionViaTurbineMatrix);
			collectionsQueue.Enqueue(this._turbinePlacementCollectionViaTurbineMatrix);
			collectionsQueue.Enqueue(this._turbinePowerRegulationCollectionViaTurbineMatrix);
			collectionsQueue.Enqueue(this._turbineRotorDiameterCollectionViaTurbineMatrix);
			collectionsQueue.Enqueue(this._turbineSmallGeneratorCollectionViaTurbineMatrix);
			collectionsQueue.Enqueue(this._turbineTemperatureVariantCollectionViaTurbineMatrix);
			collectionsQueue.Enqueue(this._turbineVoltageCollectionViaTurbineMatrix);
		}
		
		/// <summary>Gets the member collections queue from the queue (base first)</summary>
		/// <param name="collectionsQueue">The collections queue.</param>
		protected override void GetFromMemberEntityCollectionsQueue(Queue<IEntityCollection2> collectionsQueue)
		{
			base.GetFromMemberEntityCollectionsQueue(collectionsQueue);
			this._turbineMatrix = (EntityCollection<TurbineMatrixEntity>) collectionsQueue.Dequeue();
			this._turbineCollectionViaTurbineMatrix = (EntityCollection<TurbineEntity>) collectionsQueue.Dequeue();
			this._turbineFrequencyCollectionViaTurbineMatrix = (EntityCollection<TurbineFrequencyEntity>) collectionsQueue.Dequeue();
			this._turbineMarkVersionCollectionViaTurbineMatrix = (EntityCollection<TurbineMarkVersionEntity>) collectionsQueue.Dequeue();
			this._turbineNominelPowerCollectionViaTurbineMatrix = (EntityCollection<TurbineNominelPowerEntity>) collectionsQueue.Dequeue();
			this._turbineOldCollectionViaTurbineMatrix = (EntityCollection<TurbineOldEntity>) collectionsQueue.Dequeue();
			this._turbinePlacementCollectionViaTurbineMatrix = (EntityCollection<TurbinePlacementEntity>) collectionsQueue.Dequeue();
			this._turbinePowerRegulationCollectionViaTurbineMatrix = (EntityCollection<TurbinePowerRegulationEntity>) collectionsQueue.Dequeue();
			this._turbineRotorDiameterCollectionViaTurbineMatrix = (EntityCollection<TurbineRotorDiameterEntity>) collectionsQueue.Dequeue();
			this._turbineSmallGeneratorCollectionViaTurbineMatrix = (EntityCollection<TurbineSmallGeneratorEntity>) collectionsQueue.Dequeue();
			this._turbineTemperatureVariantCollectionViaTurbineMatrix = (EntityCollection<TurbineTemperatureVariantEntity>) collectionsQueue.Dequeue();
			this._turbineVoltageCollectionViaTurbineMatrix = (EntityCollection<TurbineVoltageEntity>) collectionsQueue.Dequeue();
		}
		
		/// <summary>Determines whether the entity has populated member collections</summary>
		/// <returns>true if the entity has populated member collections.</returns>
		protected override bool HasPopulatedMemberEntityCollections()
		{
			if (this._turbineMatrix != null)
			{
				return true;
			}
			if (this._turbineCollectionViaTurbineMatrix != null)
			{
				return true;
			}
			if (this._turbineFrequencyCollectionViaTurbineMatrix != null)
			{
				return true;
			}
			if (this._turbineMarkVersionCollectionViaTurbineMatrix != null)
			{
				return true;
			}
			if (this._turbineNominelPowerCollectionViaTurbineMatrix != null)
			{
				return true;
			}
			if (this._turbineOldCollectionViaTurbineMatrix != null)
			{
				return true;
			}
			if (this._turbinePlacementCollectionViaTurbineMatrix != null)
			{
				return true;
			}
			if (this._turbinePowerRegulationCollectionViaTurbineMatrix != null)
			{
				return true;
			}
			if (this._turbineRotorDiameterCollectionViaTurbineMatrix != null)
			{
				return true;
			}
			if (this._turbineSmallGeneratorCollectionViaTurbineMatrix != null)
			{
				return true;
			}
			if (this._turbineTemperatureVariantCollectionViaTurbineMatrix != null)
			{
				return true;
			}
			if (this._turbineVoltageCollectionViaTurbineMatrix != null)
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
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineFrequencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineFrequencyEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineMarkVersionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMarkVersionEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineNominelPowerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineNominelPowerEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineOldEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineOldEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbinePlacementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbinePlacementEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbinePowerRegulationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbinePowerRegulationEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineRotorDiameterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRotorDiameterEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineSmallGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineSmallGeneratorEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineTemperatureVariantEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineTemperatureVariantEntityFactory))) : null);
			collectionsQueue.Enqueue(requiredQueue.Dequeue() ? new EntityCollection<TurbineVoltageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineVoltageEntityFactory))) : null);
		}
#endif
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		public override Dictionary<string, object> GetRelatedData()
		{
			Dictionary<string, object> toReturn = new Dictionary<string, object>();

			toReturn.Add("TurbineMatrix", _turbineMatrix);
			toReturn.Add("TurbineCollectionViaTurbineMatrix", _turbineCollectionViaTurbineMatrix);
			toReturn.Add("TurbineFrequencyCollectionViaTurbineMatrix", _turbineFrequencyCollectionViaTurbineMatrix);
			toReturn.Add("TurbineMarkVersionCollectionViaTurbineMatrix", _turbineMarkVersionCollectionViaTurbineMatrix);
			toReturn.Add("TurbineNominelPowerCollectionViaTurbineMatrix", _turbineNominelPowerCollectionViaTurbineMatrix);
			toReturn.Add("TurbineOldCollectionViaTurbineMatrix", _turbineOldCollectionViaTurbineMatrix);
			toReturn.Add("TurbinePlacementCollectionViaTurbineMatrix", _turbinePlacementCollectionViaTurbineMatrix);
			toReturn.Add("TurbinePowerRegulationCollectionViaTurbineMatrix", _turbinePowerRegulationCollectionViaTurbineMatrix);
			toReturn.Add("TurbineRotorDiameterCollectionViaTurbineMatrix", _turbineRotorDiameterCollectionViaTurbineMatrix);
			toReturn.Add("TurbineSmallGeneratorCollectionViaTurbineMatrix", _turbineSmallGeneratorCollectionViaTurbineMatrix);
			toReturn.Add("TurbineTemperatureVariantCollectionViaTurbineMatrix", _turbineTemperatureVariantCollectionViaTurbineMatrix);
			toReturn.Add("TurbineVoltageCollectionViaTurbineMatrix", _turbineVoltageCollectionViaTurbineMatrix);

			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{
			if(_turbineMatrix!=null)
			{
				_turbineMatrix.ActiveContext = base.ActiveContext;
			}
			if(_turbineCollectionViaTurbineMatrix!=null)
			{
				_turbineCollectionViaTurbineMatrix.ActiveContext = base.ActiveContext;
			}
			if(_turbineFrequencyCollectionViaTurbineMatrix!=null)
			{
				_turbineFrequencyCollectionViaTurbineMatrix.ActiveContext = base.ActiveContext;
			}
			if(_turbineMarkVersionCollectionViaTurbineMatrix!=null)
			{
				_turbineMarkVersionCollectionViaTurbineMatrix.ActiveContext = base.ActiveContext;
			}
			if(_turbineNominelPowerCollectionViaTurbineMatrix!=null)
			{
				_turbineNominelPowerCollectionViaTurbineMatrix.ActiveContext = base.ActiveContext;
			}
			if(_turbineOldCollectionViaTurbineMatrix!=null)
			{
				_turbineOldCollectionViaTurbineMatrix.ActiveContext = base.ActiveContext;
			}
			if(_turbinePlacementCollectionViaTurbineMatrix!=null)
			{
				_turbinePlacementCollectionViaTurbineMatrix.ActiveContext = base.ActiveContext;
			}
			if(_turbinePowerRegulationCollectionViaTurbineMatrix!=null)
			{
				_turbinePowerRegulationCollectionViaTurbineMatrix.ActiveContext = base.ActiveContext;
			}
			if(_turbineRotorDiameterCollectionViaTurbineMatrix!=null)
			{
				_turbineRotorDiameterCollectionViaTurbineMatrix.ActiveContext = base.ActiveContext;
			}
			if(_turbineSmallGeneratorCollectionViaTurbineMatrix!=null)
			{
				_turbineSmallGeneratorCollectionViaTurbineMatrix.ActiveContext = base.ActiveContext;
			}
			if(_turbineTemperatureVariantCollectionViaTurbineMatrix!=null)
			{
				_turbineTemperatureVariantCollectionViaTurbineMatrix.ActiveContext = base.ActiveContext;
			}
			if(_turbineVoltageCollectionViaTurbineMatrix!=null)
			{
				_turbineVoltageCollectionViaTurbineMatrix.ActiveContext = base.ActiveContext;
			}


		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{

			_turbineMatrix = null;
			_turbineCollectionViaTurbineMatrix = null;
			_turbineFrequencyCollectionViaTurbineMatrix = null;
			_turbineMarkVersionCollectionViaTurbineMatrix = null;
			_turbineNominelPowerCollectionViaTurbineMatrix = null;
			_turbineOldCollectionViaTurbineMatrix = null;
			_turbinePlacementCollectionViaTurbineMatrix = null;
			_turbinePowerRegulationCollectionViaTurbineMatrix = null;
			_turbineRotorDiameterCollectionViaTurbineMatrix = null;
			_turbineSmallGeneratorCollectionViaTurbineMatrix = null;
			_turbineTemperatureVariantCollectionViaTurbineMatrix = null;
			_turbineVoltageCollectionViaTurbineMatrix = null;


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

			_fieldsCustomProperties.Add("TurbineManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Manufacturer", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Created", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CreatedBy", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Deleted", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("DeletedBy", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this TurbineManufacturerEntity</param>
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
		public  static TurbineManufacturerRelations Relations
		{
			get	{ return new TurbineManufacturerRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineMatrix' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineMatrix
		{
			get
			{
				return new PrefetchPathElement2( new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory))),
					TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, 
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineMatrixEntity, 0, null, null, null, null, "TurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Turbine' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineCollectionViaTurbineMatrix
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "TurbineMatrix_");
				relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
				relations.Add(TurbineMatrixEntity.Relations.TurbineEntityUsingTurbineId, "TurbineMatrix_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineEntity, 0, null, null, relations, null, "TurbineCollectionViaTurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineFrequency' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineFrequencyCollectionViaTurbineMatrix
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "TurbineMatrix_");
				relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
				relations.Add(TurbineMatrixEntity.Relations.TurbineFrequencyEntityUsingTurbineFrequencyId, "TurbineMatrix_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineFrequencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineFrequencyEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineFrequencyEntity, 0, null, null, relations, null, "TurbineFrequencyCollectionViaTurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineMarkVersion' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineMarkVersionCollectionViaTurbineMatrix
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "TurbineMatrix_");
				relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
				relations.Add(TurbineMatrixEntity.Relations.TurbineMarkVersionEntityUsingTurbineMarkVersionId, "TurbineMatrix_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineMarkVersionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMarkVersionEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineMarkVersionEntity, 0, null, null, relations, null, "TurbineMarkVersionCollectionViaTurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineNominelPower' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineNominelPowerCollectionViaTurbineMatrix
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "TurbineMatrix_");
				relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
				relations.Add(TurbineMatrixEntity.Relations.TurbineNominelPowerEntityUsingTurbineNominelPowerId, "TurbineMatrix_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineNominelPowerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineNominelPowerEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineNominelPowerEntity, 0, null, null, relations, null, "TurbineNominelPowerCollectionViaTurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineOld' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineOldCollectionViaTurbineMatrix
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "TurbineMatrix_");
				relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
				relations.Add(TurbineMatrixEntity.Relations.TurbineOldEntityUsingTurbineOldId, "TurbineMatrix_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineOldEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineOldEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineOldEntity, 0, null, null, relations, null, "TurbineOldCollectionViaTurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbinePlacement' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbinePlacementCollectionViaTurbineMatrix
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "TurbineMatrix_");
				relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
				relations.Add(TurbineMatrixEntity.Relations.TurbinePlacementEntityUsingTurbinePlacementId, "TurbineMatrix_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbinePlacementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbinePlacementEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbinePlacementEntity, 0, null, null, relations, null, "TurbinePlacementCollectionViaTurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbinePowerRegulation' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbinePowerRegulationCollectionViaTurbineMatrix
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "TurbineMatrix_");
				relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
				relations.Add(TurbineMatrixEntity.Relations.TurbinePowerRegulationEntityUsingTurbinePowerRegulationId, "TurbineMatrix_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbinePowerRegulationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbinePowerRegulationEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbinePowerRegulationEntity, 0, null, null, relations, null, "TurbinePowerRegulationCollectionViaTurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineRotorDiameter' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineRotorDiameterCollectionViaTurbineMatrix
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "TurbineMatrix_");
				relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
				relations.Add(TurbineMatrixEntity.Relations.TurbineRotorDiameterEntityUsingTurbineRotorDiameterId, "TurbineMatrix_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineRotorDiameterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRotorDiameterEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineRotorDiameterEntity, 0, null, null, relations, null, "TurbineRotorDiameterCollectionViaTurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineSmallGenerator' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineSmallGeneratorCollectionViaTurbineMatrix
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "TurbineMatrix_");
				relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
				relations.Add(TurbineMatrixEntity.Relations.TurbineSmallGeneratorEntityUsingTurbineSmallGeneratorId, "TurbineMatrix_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineSmallGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineSmallGeneratorEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineSmallGeneratorEntity, 0, null, null, relations, null, "TurbineSmallGeneratorCollectionViaTurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineTemperatureVariant' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineTemperatureVariantCollectionViaTurbineMatrix
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "TurbineMatrix_");
				relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
				relations.Add(TurbineMatrixEntity.Relations.TurbineTemperatureVariantEntityUsingTurbineTemperatureVariantId, "TurbineMatrix_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineTemperatureVariantEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineTemperatureVariantEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineTemperatureVariantEntity, 0, null, null, relations, null, "TurbineTemperatureVariantCollectionViaTurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'TurbineVoltage' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathTurbineVoltageCollectionViaTurbineMatrix
		{
			get
			{
				IRelationCollection relations = new RelationCollection();
				IEntityRelation intermediateRelation = TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId;
				intermediateRelation.SetAliases(string.Empty, "TurbineMatrix_");
				relations.Add(TurbineManufacturerEntity.Relations.TurbineMatrixEntityUsingTurbineManufacturerId, "TurbineManufacturerEntity__", "TurbineMatrix_", JoinHint.None);
				relations.Add(TurbineMatrixEntity.Relations.TurbineVoltageEntityUsingTurbineVoltageId, "TurbineMatrix_", string.Empty, JoinHint.None);
				return new PrefetchPathElement2(new EntityCollection<TurbineVoltageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineVoltageEntityFactory))),	intermediateRelation,
					(int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity, (int)Cir.Data.LLBLGen.EntityType.TurbineVoltageEntity, 0, null, null, relations, null, "TurbineVoltageCollectionViaTurbineMatrix", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToMany);
			}
		}



		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return TurbineManufacturerEntity.CustomProperties;}
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
			get { return TurbineManufacturerEntity.FieldsCustomProperties;}
		}

		/// <summary> The TurbineManufacturerId property of the Entity TurbineManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineManufacturer"."TurbineManufacturerId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 TurbineManufacturerId
		{
			get { return (System.Int64)GetValue((int)TurbineManufacturerFieldIndex.TurbineManufacturerId, true); }
			set	{ SetValue((int)TurbineManufacturerFieldIndex.TurbineManufacturerId, value); }
		}

		/// <summary> The Manufacturer property of the Entity TurbineManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineManufacturer"."Manufacturer"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String Manufacturer
		{
			get { return (System.String)GetValue((int)TurbineManufacturerFieldIndex.Manufacturer, true); }
			set	{ SetValue((int)TurbineManufacturerFieldIndex.Manufacturer, value); }
		}

		/// <summary> The Created property of the Entity TurbineManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineManufacturer"."Created"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.DateTime Created
		{
			get { return (System.DateTime)GetValue((int)TurbineManufacturerFieldIndex.Created, true); }
			set	{ SetValue((int)TurbineManufacturerFieldIndex.Created, value); }
		}

		/// <summary> The CreatedBy property of the Entity TurbineManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineManufacturer"."CreatedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String CreatedBy
		{
			get { return (System.String)GetValue((int)TurbineManufacturerFieldIndex.CreatedBy, true); }
			set	{ SetValue((int)TurbineManufacturerFieldIndex.CreatedBy, value); }
		}

		/// <summary> The Deleted property of the Entity TurbineManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineManufacturer"."Deleted"<br/>
		/// Table field type characteristics (type, precision, scale, length): SmallDateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> Deleted
		{
			get { return (Nullable<System.DateTime>)GetValue((int)TurbineManufacturerFieldIndex.Deleted, false); }
			set	{ SetValue((int)TurbineManufacturerFieldIndex.Deleted, value); }
		}

		/// <summary> The DeletedBy property of the Entity TurbineManufacturer<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "TurbineManufacturer"."DeletedBy"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String DeletedBy
		{
			get { return (System.String)GetValue((int)TurbineManufacturerFieldIndex.DeletedBy, true); }
			set	{ SetValue((int)TurbineManufacturerFieldIndex.DeletedBy, value); }
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineMatrixEntity' which are related to this entity via a relation of type '1:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineMatrixEntity))]
		public virtual EntityCollection<TurbineMatrixEntity> TurbineMatrix
		{
			get
			{
				if(_turbineMatrix==null)
				{
					_turbineMatrix = new EntityCollection<TurbineMatrixEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMatrixEntityFactory)));
					_turbineMatrix.SetContainingEntityInfo(this, "TurbineManufacturer");
				}
				return _turbineMatrix;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineEntity))]
		public virtual EntityCollection<TurbineEntity> TurbineCollectionViaTurbineMatrix
		{
			get
			{
				if(_turbineCollectionViaTurbineMatrix==null)
				{
					_turbineCollectionViaTurbineMatrix = new EntityCollection<TurbineEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineEntityFactory)));
					_turbineCollectionViaTurbineMatrix.IsReadOnly=true;
				}
				return _turbineCollectionViaTurbineMatrix;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineFrequencyEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineFrequencyEntity))]
		public virtual EntityCollection<TurbineFrequencyEntity> TurbineFrequencyCollectionViaTurbineMatrix
		{
			get
			{
				if(_turbineFrequencyCollectionViaTurbineMatrix==null)
				{
					_turbineFrequencyCollectionViaTurbineMatrix = new EntityCollection<TurbineFrequencyEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineFrequencyEntityFactory)));
					_turbineFrequencyCollectionViaTurbineMatrix.IsReadOnly=true;
				}
				return _turbineFrequencyCollectionViaTurbineMatrix;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineMarkVersionEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineMarkVersionEntity))]
		public virtual EntityCollection<TurbineMarkVersionEntity> TurbineMarkVersionCollectionViaTurbineMatrix
		{
			get
			{
				if(_turbineMarkVersionCollectionViaTurbineMatrix==null)
				{
					_turbineMarkVersionCollectionViaTurbineMatrix = new EntityCollection<TurbineMarkVersionEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineMarkVersionEntityFactory)));
					_turbineMarkVersionCollectionViaTurbineMatrix.IsReadOnly=true;
				}
				return _turbineMarkVersionCollectionViaTurbineMatrix;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineNominelPowerEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineNominelPowerEntity))]
		public virtual EntityCollection<TurbineNominelPowerEntity> TurbineNominelPowerCollectionViaTurbineMatrix
		{
			get
			{
				if(_turbineNominelPowerCollectionViaTurbineMatrix==null)
				{
					_turbineNominelPowerCollectionViaTurbineMatrix = new EntityCollection<TurbineNominelPowerEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineNominelPowerEntityFactory)));
					_turbineNominelPowerCollectionViaTurbineMatrix.IsReadOnly=true;
				}
				return _turbineNominelPowerCollectionViaTurbineMatrix;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineOldEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineOldEntity))]
		public virtual EntityCollection<TurbineOldEntity> TurbineOldCollectionViaTurbineMatrix
		{
			get
			{
				if(_turbineOldCollectionViaTurbineMatrix==null)
				{
					_turbineOldCollectionViaTurbineMatrix = new EntityCollection<TurbineOldEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineOldEntityFactory)));
					_turbineOldCollectionViaTurbineMatrix.IsReadOnly=true;
				}
				return _turbineOldCollectionViaTurbineMatrix;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbinePlacementEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbinePlacementEntity))]
		public virtual EntityCollection<TurbinePlacementEntity> TurbinePlacementCollectionViaTurbineMatrix
		{
			get
			{
				if(_turbinePlacementCollectionViaTurbineMatrix==null)
				{
					_turbinePlacementCollectionViaTurbineMatrix = new EntityCollection<TurbinePlacementEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbinePlacementEntityFactory)));
					_turbinePlacementCollectionViaTurbineMatrix.IsReadOnly=true;
				}
				return _turbinePlacementCollectionViaTurbineMatrix;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbinePowerRegulationEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbinePowerRegulationEntity))]
		public virtual EntityCollection<TurbinePowerRegulationEntity> TurbinePowerRegulationCollectionViaTurbineMatrix
		{
			get
			{
				if(_turbinePowerRegulationCollectionViaTurbineMatrix==null)
				{
					_turbinePowerRegulationCollectionViaTurbineMatrix = new EntityCollection<TurbinePowerRegulationEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbinePowerRegulationEntityFactory)));
					_turbinePowerRegulationCollectionViaTurbineMatrix.IsReadOnly=true;
				}
				return _turbinePowerRegulationCollectionViaTurbineMatrix;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineRotorDiameterEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineRotorDiameterEntity))]
		public virtual EntityCollection<TurbineRotorDiameterEntity> TurbineRotorDiameterCollectionViaTurbineMatrix
		{
			get
			{
				if(_turbineRotorDiameterCollectionViaTurbineMatrix==null)
				{
					_turbineRotorDiameterCollectionViaTurbineMatrix = new EntityCollection<TurbineRotorDiameterEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineRotorDiameterEntityFactory)));
					_turbineRotorDiameterCollectionViaTurbineMatrix.IsReadOnly=true;
				}
				return _turbineRotorDiameterCollectionViaTurbineMatrix;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineSmallGeneratorEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineSmallGeneratorEntity))]
		public virtual EntityCollection<TurbineSmallGeneratorEntity> TurbineSmallGeneratorCollectionViaTurbineMatrix
		{
			get
			{
				if(_turbineSmallGeneratorCollectionViaTurbineMatrix==null)
				{
					_turbineSmallGeneratorCollectionViaTurbineMatrix = new EntityCollection<TurbineSmallGeneratorEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineSmallGeneratorEntityFactory)));
					_turbineSmallGeneratorCollectionViaTurbineMatrix.IsReadOnly=true;
				}
				return _turbineSmallGeneratorCollectionViaTurbineMatrix;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineTemperatureVariantEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineTemperatureVariantEntity))]
		public virtual EntityCollection<TurbineTemperatureVariantEntity> TurbineTemperatureVariantCollectionViaTurbineMatrix
		{
			get
			{
				if(_turbineTemperatureVariantCollectionViaTurbineMatrix==null)
				{
					_turbineTemperatureVariantCollectionViaTurbineMatrix = new EntityCollection<TurbineTemperatureVariantEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineTemperatureVariantEntityFactory)));
					_turbineTemperatureVariantCollectionViaTurbineMatrix.IsReadOnly=true;
				}
				return _turbineTemperatureVariantCollectionViaTurbineMatrix;
			}
		}

		/// <summary> Gets the EntityCollection with the related entities of type 'TurbineVoltageEntity' which are related to this entity via a relation of type 'm:n'.
		/// If the EntityCollection hasn't been fetched yet, the collection returned will be empty.</summary>
		[TypeContainedAttribute(typeof(TurbineVoltageEntity))]
		public virtual EntityCollection<TurbineVoltageEntity> TurbineVoltageCollectionViaTurbineMatrix
		{
			get
			{
				if(_turbineVoltageCollectionViaTurbineMatrix==null)
				{
					_turbineVoltageCollectionViaTurbineMatrix = new EntityCollection<TurbineVoltageEntity>(EntityFactoryCache2.GetEntityFactory(typeof(TurbineVoltageEntityFactory)));
					_turbineVoltageCollectionViaTurbineMatrix.IsReadOnly=true;
				}
				return _turbineVoltageCollectionViaTurbineMatrix;
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
			get { return (int)Cir.Data.LLBLGen.EntityType.TurbineManufacturerEntity; }
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
