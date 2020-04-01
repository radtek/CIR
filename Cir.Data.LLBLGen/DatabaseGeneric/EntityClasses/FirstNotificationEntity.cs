﻿///////////////////////////////////////////////////////////////
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
	/// Entity class which represents the entity 'FirstNotification'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class FirstNotificationEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations


		private CirDataEntity _cirData;
		private CountryIsoEntity _countryIso;
		private SbuEntity _sbu;

		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{
			/// <summary>Member name CirData</summary>
			public static readonly string CirData = "CirData";
			/// <summary>Member name CountryIso</summary>
			public static readonly string CountryIso = "CountryIso";
			/// <summary>Member name Sbu</summary>
			public static readonly string Sbu = "Sbu";



		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static FirstNotificationEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public FirstNotificationEntity():base("FirstNotificationEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public FirstNotificationEntity(IEntityFields2 fields):base("FirstNotificationEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this FirstNotificationEntity</param>
		public FirstNotificationEntity(IValidator validator):base("FirstNotificationEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="firstNotificationId">PK value for FirstNotification which data should be fetched into this FirstNotification object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FirstNotificationEntity(System.Int64 firstNotificationId):base("FirstNotificationEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.FirstNotificationId = firstNotificationId;
		}

		/// <summary> CTor</summary>
		/// <param name="firstNotificationId">PK value for FirstNotification which data should be fetched into this FirstNotification object</param>
		/// <param name="validator">The custom validator object for this FirstNotificationEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public FirstNotificationEntity(System.Int64 firstNotificationId, IValidator validator):base("FirstNotificationEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.FirstNotificationId = firstNotificationId;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected FirstNotificationEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{


				_cirData = (CirDataEntity)info.GetValue("_cirData", typeof(CirDataEntity));
				if(_cirData!=null)
				{
					_cirData.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_countryIso = (CountryIsoEntity)info.GetValue("_countryIso", typeof(CountryIsoEntity));
				if(_countryIso!=null)
				{
					_countryIso.AfterSave+=new EventHandler(OnEntityAfterSave);
				}
				_sbu = (SbuEntity)info.GetValue("_sbu", typeof(SbuEntity));
				if(_sbu!=null)
				{
					_sbu.AfterSave+=new EventHandler(OnEntityAfterSave);
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
			switch((FirstNotificationFieldIndex)fieldIndex)
			{
				case FirstNotificationFieldIndex.Sbuid:
					DesetupSyncSbu(true, false);
					break;
				case FirstNotificationFieldIndex.CountryIsoid:
					DesetupSyncCountryIso(true, false);
					break;
				case FirstNotificationFieldIndex.CirDataId:
					DesetupSyncCirData(true, false);
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
				case "CirData":
					this.CirData = (CirDataEntity)entity;
					break;
				case "CountryIso":
					this.CountryIso = (CountryIsoEntity)entity;
					break;
				case "Sbu":
					this.Sbu = (SbuEntity)entity;
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
				case "CirData":
					SetupSyncCirData(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "CountryIso":
					SetupSyncCountryIso(relatedEntity);
					OnRelatedEntitySet(relatedEntity, fieldName);
					break;
				case "Sbu":
					SetupSyncSbu(relatedEntity);
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
				case "CirData":
					DesetupSyncCirData(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "CountryIso":
					DesetupSyncCountryIso(false, true);
					OnRelatedEntityUnset(relatedEntity, fieldName);
					break;
				case "Sbu":
					DesetupSyncSbu(false, true);
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
			if(_cirData!=null)
			{
				toReturn.Add(_cirData);
			}
			if(_countryIso!=null)
			{
				toReturn.Add(_countryIso);
			}
			if(_sbu!=null)
			{
				toReturn.Add(_sbu);
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


				info.AddValue("_cirData", (!this.MarkedForDeletion?_cirData:null));
				info.AddValue("_countryIso", (!this.MarkedForDeletion?_countryIso:null));
				info.AddValue("_sbu", (!this.MarkedForDeletion?_sbu:null));

			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(FirstNotificationFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(FirstNotificationFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new FirstNotificationRelations().GetAllRelations();
		}
		



		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CirData' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCirData()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CirDataFields.CirDataId, null, ComparisonOperator.Equal, this.CirDataId));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'CountryIso' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoCountryIso()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(CountryIsoFields.CountryIsoid, null, ComparisonOperator.Equal, this.CountryIsoid));
			return bucket;
		}

		/// <summary> Creates a new IRelationPredicateBucket object which contains the predicate expression and relation collection to fetch
		/// the related entity of type 'Sbu' to this entity. Use DataAccessAdapter.FetchNewEntity() to fetch this related entity.</summary>
		/// <returns></returns>
		public virtual IRelationPredicateBucket GetRelationInfoSbu()
		{
			IRelationPredicateBucket bucket = new RelationPredicateBucket();
			bucket.PredicateExpression.Add(new FieldCompareValuePredicate(SbuFields.Sbuid, null, ComparisonOperator.Equal, this.Sbuid));
			return bucket;
		}

	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.FirstNotificationEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(FirstNotificationEntityFactory));
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
			toReturn.Add("CirData", _cirData);
			toReturn.Add("CountryIso", _countryIso);
			toReturn.Add("Sbu", _sbu);



			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{


			if(_cirData!=null)
			{
				_cirData.ActiveContext = base.ActiveContext;
			}
			if(_countryIso!=null)
			{
				_countryIso.ActiveContext = base.ActiveContext;
			}
			if(_sbu!=null)
			{
				_sbu.ActiveContext = base.ActiveContext;
			}

		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{



			_cirData = null;
			_countryIso = null;
			_sbu = null;

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

			_fieldsCustomProperties.Add("FirstNotificationId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentInspectionReportId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SendOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sbuid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EditDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("EditInitials", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("TurbineMatrixId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Sitename", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CountryIsoid", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ComponentType", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("ManufacturerId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("SerialNo", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CommisioningDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("FailureDate", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("QueuedOn", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CirDataId", fieldHashtable);
		}
		#endregion

		/// <summary> Removes the sync logic for member _cirData</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCirData(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _cirData, new PropertyChangedEventHandler( OnCirDataPropertyChanged ), "CirData", FirstNotificationEntity.Relations.CirDataEntityUsingCirDataId, true, signalRelatedEntity, "FirstNotification", resetFKFields, new int[] { (int)FirstNotificationFieldIndex.CirDataId } );		
			_cirData = null;
		}

		/// <summary> setups the sync logic for member _cirData</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCirData(IEntity2 relatedEntity)
		{
			DesetupSyncCirData(true, true);
			_cirData = (CirDataEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _cirData, new PropertyChangedEventHandler( OnCirDataPropertyChanged ), "CirData", FirstNotificationEntity.Relations.CirDataEntityUsingCirDataId, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCirDataPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _countryIso</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncCountryIso(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _countryIso, new PropertyChangedEventHandler( OnCountryIsoPropertyChanged ), "CountryIso", FirstNotificationEntity.Relations.CountryIsoEntityUsingCountryIsoid, true, signalRelatedEntity, "FirstNotification", resetFKFields, new int[] { (int)FirstNotificationFieldIndex.CountryIsoid } );		
			_countryIso = null;
		}

		/// <summary> setups the sync logic for member _countryIso</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncCountryIso(IEntity2 relatedEntity)
		{
			DesetupSyncCountryIso(true, true);
			_countryIso = (CountryIsoEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _countryIso, new PropertyChangedEventHandler( OnCountryIsoPropertyChanged ), "CountryIso", FirstNotificationEntity.Relations.CountryIsoEntityUsingCountryIsoid, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnCountryIsoPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}

		/// <summary> Removes the sync logic for member _sbu</summary>
		/// <param name="signalRelatedEntity">If set to true, it will call the related entity's UnsetRelatedEntity method</param>
		/// <param name="resetFKFields">if set to true it will also reset the FK fields pointing to the related entity</param>
		private void DesetupSyncSbu(bool signalRelatedEntity, bool resetFKFields)
		{
			base.PerformDesetupSyncRelatedEntity( _sbu, new PropertyChangedEventHandler( OnSbuPropertyChanged ), "Sbu", FirstNotificationEntity.Relations.SbuEntityUsingSbuid, true, signalRelatedEntity, "FirstNotification", resetFKFields, new int[] { (int)FirstNotificationFieldIndex.Sbuid } );		
			_sbu = null;
		}

		/// <summary> setups the sync logic for member _sbu</summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		private void SetupSyncSbu(IEntity2 relatedEntity)
		{
			DesetupSyncSbu(true, true);
			_sbu = (SbuEntity)relatedEntity;
			base.PerformSetupSyncRelatedEntity( _sbu, new PropertyChangedEventHandler( OnSbuPropertyChanged ), "Sbu", FirstNotificationEntity.Relations.SbuEntityUsingSbuid, true, new string[] {  } );
		}
		
		/// <summary>Handles property change events of properties in a related entity.</summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnSbuPropertyChanged( object sender, PropertyChangedEventArgs e )
		{
			switch( e.PropertyName )
			{
				default:
					break;
			}
		}


		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this FirstNotificationEntity</param>
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
		public  static FirstNotificationRelations Relations
		{
			get	{ return new FirstNotificationRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}



		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CirData' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCirData
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CirDataEntityFactory))),
					FirstNotificationEntity.Relations.CirDataEntityUsingCirDataId, 
					(int)Cir.Data.LLBLGen.EntityType.FirstNotificationEntity, (int)Cir.Data.LLBLGen.EntityType.CirDataEntity, 0, null, null, null, null, "CirData", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'CountryIso' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathCountryIso
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(CountryIsoEntityFactory))),
					FirstNotificationEntity.Relations.CountryIsoEntityUsingCountryIsoid, 
					(int)Cir.Data.LLBLGen.EntityType.FirstNotificationEntity, (int)Cir.Data.LLBLGen.EntityType.CountryIsoEntity, 0, null, null, null, null, "CountryIso", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}

		/// <summary> Creates a new PrefetchPathElement2 object which contains all the information to prefetch the related entities of type 'Sbu' 
		/// for this entity. Add the object returned by this property to an existing PrefetchPath2 instance.</summary>
		/// <returns>Ready to use IPrefetchPathElement2 implementation.</returns>
		public static IPrefetchPathElement2 PrefetchPathSbu
		{
			get
			{
				return new PrefetchPathElement2(new EntityCollection(EntityFactoryCache2.GetEntityFactory(typeof(SbuEntityFactory))),
					FirstNotificationEntity.Relations.SbuEntityUsingSbuid, 
					(int)Cir.Data.LLBLGen.EntityType.FirstNotificationEntity, (int)Cir.Data.LLBLGen.EntityType.SbuEntity, 0, null, null, null, null, "Sbu", SD.LLBLGen.Pro.ORMSupportClasses.RelationType.ManyToOne);
			}
		}


		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return FirstNotificationEntity.CustomProperties;}
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
			get { return FirstNotificationEntity.FieldsCustomProperties;}
		}

		/// <summary> The FirstNotificationId property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."FirstNotificationId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int64 FirstNotificationId
		{
			get { return (System.Int64)GetValue((int)FirstNotificationFieldIndex.FirstNotificationId, true); }
			set	{ SetValue((int)FirstNotificationFieldIndex.FirstNotificationId, value); }
		}

		/// <summary> The ComponentInspectionReportId property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."ComponentInspectionReportId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 ComponentInspectionReportId
		{
			get { return (System.Int64)GetValue((int)FirstNotificationFieldIndex.ComponentInspectionReportId, true); }
			set	{ SetValue((int)FirstNotificationFieldIndex.ComponentInspectionReportId, value); }
		}

		/// <summary> The SendOn property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."SendOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> SendOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)FirstNotificationFieldIndex.SendOn, false); }
			set	{ SetValue((int)FirstNotificationFieldIndex.SendOn, value); }
		}

		/// <summary> The Sbuid property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."SBUId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 Sbuid
		{
			get { return (System.Int64)GetValue((int)FirstNotificationFieldIndex.Sbuid, true); }
			set	{ SetValue((int)FirstNotificationFieldIndex.Sbuid, value); }
		}

		/// <summary> The EditDate property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."EditDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> EditDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)FirstNotificationFieldIndex.EditDate, false); }
			set	{ SetValue((int)FirstNotificationFieldIndex.EditDate, value); }
		}

		/// <summary> The EditInitials property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."EditInitials"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String EditInitials
		{
			get { return (System.String)GetValue((int)FirstNotificationFieldIndex.EditInitials, true); }
			set	{ SetValue((int)FirstNotificationFieldIndex.EditInitials, value); }
		}

		/// <summary> The TurbineMatrixId property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."TurbineMatrixId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 TurbineMatrixId
		{
			get { return (System.Int64)GetValue((int)FirstNotificationFieldIndex.TurbineMatrixId, true); }
			set	{ SetValue((int)FirstNotificationFieldIndex.TurbineMatrixId, value); }
		}

		/// <summary> The Sitename property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."Sitename"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Sitename
		{
			get { return (System.String)GetValue((int)FirstNotificationFieldIndex.Sitename, true); }
			set	{ SetValue((int)FirstNotificationFieldIndex.Sitename, value); }
		}

		/// <summary> The CountryIsoid property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."CountryISOId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.Int64 CountryIsoid
		{
			get { return (System.Int64)GetValue((int)FirstNotificationFieldIndex.CountryIsoid, true); }
			set	{ SetValue((int)FirstNotificationFieldIndex.CountryIsoid, value); }
		}

		/// <summary> The ComponentType property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."ComponentType"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, false, false</remarks>
		public virtual System.String ComponentType
		{
			get { return (System.String)GetValue((int)FirstNotificationFieldIndex.ComponentType, true); }
			set	{ SetValue((int)FirstNotificationFieldIndex.ComponentType, value); }
		}

		/// <summary> The ManufacturerId property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."ManufacturerID"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> ManufacturerId
		{
			get { return (Nullable<System.Int64>)GetValue((int)FirstNotificationFieldIndex.ManufacturerId, false); }
			set	{ SetValue((int)FirstNotificationFieldIndex.ManufacturerId, value); }
		}

		/// <summary> The SerialNo property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."SerialNo"<br/>
		/// Table field type characteristics (type, precision, scale, length): NVarChar, 0, 0, 2000<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String SerialNo
		{
			get { return (System.String)GetValue((int)FirstNotificationFieldIndex.SerialNo, true); }
			set	{ SetValue((int)FirstNotificationFieldIndex.SerialNo, value); }
		}

		/// <summary> The CommisioningDate property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."CommisioningDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> CommisioningDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)FirstNotificationFieldIndex.CommisioningDate, false); }
			set	{ SetValue((int)FirstNotificationFieldIndex.CommisioningDate, value); }
		}

		/// <summary> The FailureDate property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."FailureDate"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> FailureDate
		{
			get { return (Nullable<System.DateTime>)GetValue((int)FirstNotificationFieldIndex.FailureDate, false); }
			set	{ SetValue((int)FirstNotificationFieldIndex.FailureDate, value); }
		}

		/// <summary> The QueuedOn property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."QueuedOn"<br/>
		/// Table field type characteristics (type, precision, scale, length): DateTime, 0, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.DateTime> QueuedOn
		{
			get { return (Nullable<System.DateTime>)GetValue((int)FirstNotificationFieldIndex.QueuedOn, false); }
			set	{ SetValue((int)FirstNotificationFieldIndex.QueuedOn, value); }
		}

		/// <summary> The CirDataId property of the Entity FirstNotification<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "FirstNotification"."CirDataId"<br/>
		/// Table field type characteristics (type, precision, scale, length): BigInt, 19, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual Nullable<System.Int64> CirDataId
		{
			get { return (Nullable<System.Int64>)GetValue((int)FirstNotificationFieldIndex.CirDataId, false); }
			set	{ SetValue((int)FirstNotificationFieldIndex.CirDataId, value); }
		}



		/// <summary> Gets / sets related entity of type 'CirDataEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CirDataEntity CirData
		{
			get
			{
				return _cirData;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCirData(value);
				}
				else
				{
					if(value==null)
					{
						if(_cirData != null)
						{
							_cirData.UnsetRelatedEntity(this, "FirstNotification");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "FirstNotification");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'CountryIsoEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual CountryIsoEntity CountryIso
		{
			get
			{
				return _countryIso;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncCountryIso(value);
				}
				else
				{
					if(value==null)
					{
						if(_countryIso != null)
						{
							_countryIso.UnsetRelatedEntity(this, "FirstNotification");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "FirstNotification");
					}
				}
			}
		}

		/// <summary> Gets / sets related entity of type 'SbuEntity' which has to be set using a fetch action earlier. If no related entity
		/// is set for this property, null is returned. This property is not visible in databound grids.</summary>
		[Browsable(false)]
		public virtual SbuEntity Sbu
		{
			get
			{
				return _sbu;
			}
			set
			{
				if(base.IsDeserializing)
				{
					SetupSyncSbu(value);
				}
				else
				{
					if(value==null)
					{
						if(_sbu != null)
						{
							_sbu.UnsetRelatedEntity(this, "FirstNotification");
						}
					}
					else
					{
						((IEntity2)value).SetRelatedEntity(this, "FirstNotification");
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
			get { return (int)Cir.Data.LLBLGen.EntityType.FirstNotificationEntity; }
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