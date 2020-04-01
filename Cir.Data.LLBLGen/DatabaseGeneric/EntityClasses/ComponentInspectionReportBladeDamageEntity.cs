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
	/// Entity class which represents the entity 'ComponentInspectionReportBladeDamage'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class ComponentInspectionReportBladeDamageEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private BladeDamagePlacementEntity _bladeDamagePlacement;
		private BladeEdgeEntity _bladeEdge;
		private BladeInspectionDataEntity _bladeInspectionData;
		private ComponentInspectionReportBladeEntity _componentInspectionReportBlade;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name BladeDamagePlacement</summary>
			public static readonly string BladeDamagePlacement = "BladeDamagePlacement";
			/// <summary>Member name BladeEdge</summary>
			public static readonly string BladeEdge = "BladeEdge";
			/// <summary>Member name BladeInspectionData</summary>
			public static readonly string BladeInspectionData = "BladeInspectionData";
			/// <summary>Member name ComponentInspectionReportBlade</summary>
			public static readonly string ComponentInspectionReportBlade = "ComponentInspectionReportBlade";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static ComponentInspectionReportBladeDamageEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public ComponentInspectionReportBladeDamageEntity():base("ComponentInspectionReportBladeDamageEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public ComponentInspectionReportBladeDamageEntity(IEntityFields2 fields):base("ComponentInspectionReportBladeDamageEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportBladeDamageEntity</param>
		public ComponentInspectionReportBladeDamageEntity(IValidator validator):base("ComponentInspectionReportBladeDamageEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportBladeDamageId">PK value for ComponentInspectionReportBladeDamage which data should be fetched into this ComponentInspectionReportBladeDamage object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportBladeDamageEntity(System.Int64 componentInspectionReportBladeDamageId):base("ComponentInspectionReportBladeDamageEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.ComponentInspectionReportBladeDamageId = componentInspectionReportBladeDamageId;
		}

		/// <summary> CTor</summary>
		/// <param name="componentInspectionReportBladeDamageId">PK value for ComponentInspectionReportBladeDamage which data should be fetched into this ComponentInspectionReportBladeDamage object</param>
		/// <param name="validator">The custom validator object for this ComponentInspectionReportBladeDamageEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public ComponentInspectionReportBladeDamageEntity(System.Int64 componentInspectionReportBladeDamageId, IValidator validator):base("ComponentInspectionReportBladeDamageEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.ComponentInspectionReportBladeDamageId = componentInspectionReportBladeDamageId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected ComponentInspectionReportBladeDamageEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_bladeDamagePlacement = (BladeDamagePlacementEntity)info.GetValue("_bladeDamagePlacement", typeof(BladeDamagePlacementEntity));
				if(_bladeDamagePlacement!=null)
				{
					_bladeDamagePlacement.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bladeEdge = (BladeEdgeEntity)info.GetValue("_bladeEdge", typeof(BladeEdgeEntity));
				if(_bladeEdge!=null)
				{
					_bladeEdge.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_bladeInspectionData = (BladeInspectionDataEntity)info.GetValue("_bladeInspectionData", typeof(BladeInspectionDataEntity));
				if(_bladeInspectionData!=null)
				{
					_bladeInspectionData.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_componentInspectionReportBlade = (ComponentInspectionReportBladeEntity)info.GetValue("_componentInspectionReportBlade", typeof(ComponentInspectionReportBladeEntity));
				if(_componentInspectionReportBlade!=null)
				{
					_componentInspectionReportBlade.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((ComponentInspectionReportBladeDamageFieldIndex)fieldIndex)
			{
				case ComponentInspectionReportBladeDamageFieldIndex.ComponentInspectionReportBladeId:
					DesetupSyncComponentInspectionReportBlade(true, false);
					break;
				case ComponentInspectionReportBladeDamageFieldIndex.BladeDamagePlacementId:
					DesetupSyncBladeDamagePlacement(true, false);
					break;
				case ComponentInspectionReportBladeDamageFieldIndex.BladeInspectionDataId:
					DesetupSyncBladeInspectionData(true, false);
					break;
				case ComponentInspectionReportBladeDamageFieldIndex.BladeEdgeId:
					DesetupSyncBladeEdge(true, false);
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
				case "BladeDamagePlacement":
					this.BladeDamagePlacement = (BladeDamagePlacementEntity)entity;
					break;
				case "BladeEdge":
					this.BladeEdge = (BladeEdgeEntity)entity;
					break;
				case "BladeInspectionData":
					this.BladeInspectionData = (BladeInspectionDataEntity)entity;
					break;
				case "ComponentInspectionReportBlade":
					this.ComponentInspectionReportBlade = (ComponentInspectionReportBladeEntity)entity;
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
				case "BladeDamagePlacement":
					SetupSyncBladeDamagePlacement(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BladeEdge":
					SetupSyncBladeEdge(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "BladeInspectionData":
					SetupSyncBladeInspectionData(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportBlade":
					SetupSyncComponentInspectionReportBlade(relatedEntity);
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
				case "BladeDamagePlacement":
					DesetupSyncBladeDamagePlacement(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BladeEdge":
					DesetupSyncBladeEdge(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "BladeInspectionData":
					DesetupSyncBladeInspectionData(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "ComponentInspectionReportBlade":
					DesetupSyncComponentInspectionReportBlade(false, true);
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
			if(_bladeDamagePlacement!=null)
			{
				toReturn.Add(_bladeDamagePlacement);
			}
			if(_bladeEdge!=null)
			{
				toReturn.Add(_bladeEdge);
			}
			if(_bladeInspectionData!=null)
			{
				toReturn.Add(_bladeInspectionData);
			}
			if(_componentInspectionReportBlade!=null)
			{
				toReturn.Add(_componentInspectionReportBlade);
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


				info.AddValue("_bladeDamagePlacement", (!this.MarkedForDeletion?_bladeDamagePlacement:null));
				info.AddValue("_bladeEdge", (!this.MarkedForDeletion?_bladeEdge:null));
				info.AddValue("_bladeInspectionData", (!this.MarkedForDeletion?_bladeInspectionData:null));
				info.AddValue("_componentInspectionReportBlade", (!this.MarkedForDeletion?_componentInspectionReportBlade:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(ComponentInspectionReportBladeDamageFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(ComponentInspectionReportBladeDamageFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new ComponentInspectionReportBladeDamageRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BladeDamagePlacement' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeDamagePlacement()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeDamagePlacementFields.BladeDamagePlacementId, null, ComparisonOperator.Equal, this.BladeDamagePlacementId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BladeEdge' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeEdge()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeEdgeFields.BladeEdgeId, null, ComparisonOperator.Equal, this.BladeEdgeId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'BladeInspectionData' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoBladeInspectionData()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(BladeInspectionDataFields.BladeInspectionDataId, null, ComparisonOperator.Equal, this.BladeInspectionDataId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'ComponentInspectionReportBlade' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoComponentInspectionReportBlade()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(ComponentInspectionReportBladeFields.ComponentInspectionReportBladeId, null, ComparisonOperator.Equal, this.ComponentInspectionReportBladeId));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeDamageEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeDamageEntityFactory));
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
			toReturn.Add("BladeDamagePlacement", _bladeDamagePlacement);
			toReturn.Add("BladeEdge", _bladeEdge);
			toReturn.Add("BladeInspectionData", _bladeInspectionData);
			toReturn.Add("ComponentInspectionReportBlade", _componentInspectionReportBlade);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_bladeDamagePlacement!=null)
			{
				_bladeDamagePlacement.ActiveContext = base.ActiveContext;
			}
			if(_bladeEdge!=null)
			{
				_bladeEdge.ActiveContext = base.ActiveContext;
			}
			if(_bladeInspectionData!=null)
			{
				_bladeInspectionData.ActiveContext = base.ActiveContext;
			}
			if(_componentInspectionReportBlade!=null)
			{
				_componentInspectionReportBlade.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_bladeDamagePlacement = null;
			_bladeEdge = null;
			_bladeInspectionData = null;
			_componentInspectionReportBlade = null;

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

			_fieldsCustomProperties.Add("ComponentInspectionReportBladeDamageId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportBladeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeDamagePlacementId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeInspectionDataId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeRadius", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeEdgeId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladeDescription", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("BladePictureNumber", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("PictureOrder", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _bladeDamagePlacement</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBladeDamagePlacement(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bladeDamagePlacement, new PropertyChangedEventHandler( OnBladeDamagePlacementPropertyChanged ), "BladeDamagePlacement", ComponentInspectionReportBladeDamageEntity.Relations.BladeDamagePlacementEntityUsingBladeDamagePlacementId, true, signalRelatedEntity, "ComponentInspectionReportBladeDamage", resetFKFields, new int[] { (int)ComponentInspectionReportBladeDamageFieldIndex.BladeDamagePlacementId } );		
			_bladeDamagePlacement = null;
		}

		/// <summary> setups the sync logic for member _bladeDamagePlacement</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBladeDamagePlacement(IEntity2 relatedEntity)
		{
			DesetupSyncBladeDamagePlacement(true, true);
			_bladeDamagePlacement = (BladeDamagePlacementEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bladeDamagePlacement, new PropertyChangedEventHandler( OnBladeDamagePlacementPropertyChanged ), "BladeDamagePlacement", ComponentInspectionReportBladeDamageEntity.Relations.BladeDamagePlacementEntityUsingBladeDamagePlacementId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBladeDamagePlacementPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bladeEdge</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBladeEdge(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bladeEdge, new PropertyChangedEventHandler( OnBladeEdgePropertyChanged ), "BladeEdge", ComponentInspectionReportBladeDamageEntity.Relations.BladeEdgeEntityUsingBladeEdgeId, true, signalRelatedEntity, "ComponentInspectionReportBladeDamage", resetFKFields, new int[] { (int)ComponentInspectionReportBladeDamageFieldIndex.BladeEdgeId } );		
			_bladeEdge = null;
		}

		/// <summary> setups the sync logic for member _bladeEdge</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBladeEdge(IEntity2 relatedEntity)
		{
			DesetupSyncBladeEdge(true, true);
			_bladeEdge = (BladeEdgeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bladeEdge, new PropertyChangedEventHandler( OnBladeEdgePropertyChanged ), "BladeEdge", ComponentInspectionReportBladeDamageEntity.Relations.BladeEdgeEntityUsingBladeEdgeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBladeEdgePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _bladeInspectionData</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncBladeInspectionData(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _bladeInspectionData, new PropertyChangedEventHandler( OnBladeInspectionDataPropertyChanged ), "BladeInspectionData", ComponentInspectionReportBladeDamageEntity.Relations.BladeInspectionDataEntityUsingBladeInspectionDataId, true, signalRelatedEntity, "ComponentInspectionReportBladeDamage", resetFKFields, new int[] { (int)ComponentInspectionReportBladeDamageFieldIndex.BladeInspectionDataId } );		
			_bladeInspectionData = null;
		}

		/// <summary> setups the sync logic for member _bladeInspectionData</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncBladeInspectionData(IEntity2 relatedEntity)
		{
			DesetupSyncBladeInspectionData(true, true);
			_bladeInspectionData = (BladeInspectionDataEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _bladeInspectionData, new PropertyChangedEventHandler( OnBladeInspectionDataPropertyChanged ), "BladeInspectionData", ComponentInspectionReportBladeDamageEntity.Relations.BladeInspectionDataEntityUsingBladeInspectionDataId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnBladeInspectionDataPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _componentInspectionReportBlade</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncComponentInspectionReportBlade(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _componentInspectionReportBlade, new PropertyChangedEventHandler( OnComponentInspectionReportBladePropertyChanged ), "ComponentInspectionReportBlade", ComponentInspectionReportBladeDamageEntity.Relations.ComponentInspectionReportBladeEntityUsingComponentInspectionReportBladeId, true, signalRelatedEntity, "ComponentInspectionReportBladeDamage", resetFKFields, new int[] { (int)ComponentInspectionReportBladeDamageFieldIndex.ComponentInspectionReportBladeId } );		
			_componentInspectionReportBlade = null;
		}

		/// <summary> setups the sync logic for member _componentInspectionReportBlade</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncComponentInspectionReportBlade(IEntity2 relatedEntity)
		{
			DesetupSyncComponentInspectionReportBlade(true, true);
			_componentInspectionReportBlade = (ComponentInspectionReportBladeEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _componentInspectionReportBlade, new PropertyChangedEventHandler( OnComponentInspectionReportBladePropertyChanged ), "ComponentInspectionReportBlade", ComponentInspectionReportBladeDamageEntity.Relations.ComponentInspectionReportBladeEntityUsingComponentInspectionReportBladeId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnComponentInspectionReportBladePropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this ComponentInspectionReportBladeDamageEntity</param>
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
		public  static ComponentInspectionReportBladeDamageRelations Relations
		{
			get	{ return new ComponentInspectionReportBladeDamageRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeDamagePlacement' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeDamagePlacement
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BladeDamagePlacementEntityFactory))),
					ComponentInspectionReportBladeDamageEntity.Relations.BladeDamagePlacementEntityUsingBladeDamagePlacementId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeDamageEntity, (int)Cir.Data.LLBLGen.EntityType.BladeDamagePlacementEntity, 0, null, null, null, null, "BladeDamagePlacement", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeEdge' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeEdge
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BladeEdgeEntityFactory))),
					ComponentInspectionReportBladeDamageEntity.Relations.BladeEdgeEntityUsingBladeEdgeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeDamageEntity, (int)Cir.Data.LLBLGen.EntityType.BladeEdgeEntity, 0, null, null, null, null, "BladeEdge", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'BladeInspectionData' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathBladeInspectionData
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(BladeInspectionDataEntityFactory))),
					ComponentInspectionReportBladeDamageEntity.Relations.BladeInspectionDataEntityUsingBladeInspectionDataId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeDamageEntity, (int)Cir.Data.LLBLGen.EntityType.BladeInspectionDataEntity, 0, null, null, null, null, "BladeInspectionData", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'ComponentInspectionReportBlade' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathComponentInspectionReportBlade
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(ComponentInspectionReportBladeEntityFactory))),
					ComponentInspectionReportBladeDamageEntity.Relations.ComponentInspectionReportBladeEntityUsingComponentInspectionReportBladeId, 
					(int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeDamageEntity, (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeEntity, 0, null, null, null, null, "ComponentInspectionReportBlade", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return ComponentInspectionReportBladeDamageEntity.CustomProperties;}
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
			get { return ComponentInspectionReportBladeDamageEntity.FieldsCustomProperties;}
		}

		/// <summary> The ComponentInspectionReportBladeDamageId property of the Entity ComponentInspectionReportBladeDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeDamage"."ComponentInspectionReportBladeDamageId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 ComponentInspectionReportBladeDamageId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeDamageFieldIndex.ComponentInspectionReportBladeDamageId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeDamageFieldIndex.ComponentInspectionReportBladeDamageId, value); }
		}

		/// <summary> The ComponentInspectionReportBladeId property of the Entity ComponentInspectionReportBladeDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeDamage"."ComponentInspectionReportBladeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportBladeId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeDamageFieldIndex.ComponentInspectionReportBladeId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeDamageFieldIndex.ComponentInspectionReportBladeId, value); }
		}

		/// <summary> The BladeDamagePlacementId property of the Entity ComponentInspectionReportBladeDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeDamage"."BladeDamagePlacementId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 BladeDamagePlacementId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladeDamagePlacementId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladeDamagePlacementId, value); }
		}

		/// <summary> The BladeInspectionDataId property of the Entity ComponentInspectionReportBladeDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeDamage"."BladeInspectionDataId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 BladeInspectionDataId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladeInspectionDataId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladeInspectionDataId, value); }
		}

		/// <summary> The BladeRadius property of the Entity ComponentInspectionReportBladeDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeDamage"."BladeRadius"<br/>
		/// Table field type characteristics (type, precision, scale, length): Float, 38, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Double BladeRadius
		{
			get { return (System.Double)GetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladeRadius, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladeRadius, value); }
		}

		/// <summary> The BladeEdgeId property of the Entity ComponentInspectionReportBladeDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeDamage"."BladeEdgeId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 BladeEdgeId
		{
			get { return (System.Int64)GetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladeEdgeId, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladeEdgeId, value); }
		}

		/// <summary> The BladeDescription property of the Entity ComponentInspectionReportBladeDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeDamage"."BladeDescription"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String BladeDescription
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladeDescription, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladeDescription, value); }
		}

		/// <summary> The BladePictureNumber property of the Entity ComponentInspectionReportBladeDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeDamage"."BladePictureNumber"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String BladePictureNumber
		{
			get { return (System.String)GetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladePictureNumber, true); }
			set	{ SetValue((int)ComponentInspectionReportBladeDamageFieldIndex.BladePictureNumber, value); }
		}

		/// <summary> The PictureOrder property of the Entity ComponentInspectionReportBladeDamage<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "ComponentInspectionReportBladeDamage"."PictureOrder"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int32> PictureOrder
		{
			get { return (Nullable<System.Int32>)GetValue((int)ComponentInspectionReportBladeDamageFieldIndex.PictureOrder, false); }
			set	{ SetValue((int)ComponentInspectionReportBladeDamageFieldIndex.PictureOrder, value); }
		}



		/// <summary> Gets / sets related entity of type 'BladeDamagePlacementEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BladeDamagePlacementEntity BladeDamagePlacement
		{
			get
			{
				return _bladeDamagePlacement;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBladeDamagePlacement(value);
				}
				else
				{
					if(value==null)
					{
						if(_bladeDamagePlacement != null)
						{
							_bladeDamagePlacement.UnsetRelatedEntity(this, "ComponentInspectionReportBladeDamage");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBladeDamage");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BladeEdgeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BladeEdgeEntity BladeEdge
		{
			get
			{
				return _bladeEdge;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBladeEdge(value);
				}
				else
				{
					if(value==null)
					{
						if(_bladeEdge != null)
						{
							_bladeEdge.UnsetRelatedEntity(this, "ComponentInspectionReportBladeDamage");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBladeDamage");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'BladeInspectionDataEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual BladeInspectionDataEntity BladeInspectionData
		{
			get
			{
				return _bladeInspectionData;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncBladeInspectionData(value);
				}
				else
				{
					if(value==null)
					{
						if(_bladeInspectionData != null)
						{
							_bladeInspectionData.UnsetRelatedEntity(this, "ComponentInspectionReportBladeDamage");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBladeDamage");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'ComponentInspectionReportBladeEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual ComponentInspectionReportBladeEntity ComponentInspectionReportBlade
		{
			get
			{
				return _componentInspectionReportBlade;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncComponentInspectionReportBlade(value);
				}
				else
				{
					if(value==null)
					{
						if(_componentInspectionReportBlade != null)
						{
							_componentInspectionReportBlade.UnsetRelatedEntity(this, "ComponentInspectionReportBladeDamage");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "ComponentInspectionReportBladeDamage");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.ComponentInspectionReportBladeDamageEntity; }
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
