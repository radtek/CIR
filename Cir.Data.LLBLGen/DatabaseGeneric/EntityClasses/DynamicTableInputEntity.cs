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
	/// Entity class which represents the entity 'DynamicTableInput'.<br/><br/>
	/// 
	/// </summary>
	[Serializable]
	public partial class DynamicTableInputEntity : CommonEntityBase, ISerializable
		// __LLBLGENPRO_USER_CODE_REGION_START AdditionalInterfaces
		// __LLBLGENPRO_USER_CODE_REGION_END	
	{
		#region Class Member Declarations




		
		// __LLBLGENPRO_USER_CODE_REGION_START PrivateMembers
		// __LLBLGENPRO_USER_CODE_REGION_END
		#endregion

		#region Statics
		private static Dictionary<string, string>	_customProperties;
		private static Dictionary<string, Dictionary<string, string>>	_fieldsCustomProperties;

		/// <summary>All names of fields mapped onto a relation. Usable for in-memory filtering</summary>
		public static class MemberNames
		{




		}
		#endregion
		
		/// <summary> Static CTor for setting up custom property hashtables. Is executed before the first instance of this entity class or derived classes is constructed. </summary>
		static DynamicTableInputEntity()
		{
			SetupCustomPropertyHashtables();
		}

		/// <summary> CTor</summary>
		public DynamicTableInputEntity():base("DynamicTableInputEntity")
		{
			InitClassEmpty(null, CreateFields());
		}

		/// <summary> CTor</summary>
		/// <remarks>For framework usage.</remarks>
		/// <param name="fields">Fields object to set as the fields for this entity.</param>
		public DynamicTableInputEntity(IEntityFields2 fields):base("DynamicTableInputEntity")
		{
			InitClassEmpty(null, fields);
		}

		/// <summary> CTor</summary>
		/// <param name="validator">The custom validator object for this DynamicTableInputEntity</param>
		public DynamicTableInputEntity(IValidator validator):base("DynamicTableInputEntity")
		{
			InitClassEmpty(validator, CreateFields());
		}
				

		/// <summary> CTor</summary>
		/// <param name="id">PK value for DynamicTableInput which data should be fetched into this DynamicTableInput object</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public DynamicTableInputEntity(System.Int32 id):base("DynamicTableInputEntity")
		{
			InitClassEmpty(null, CreateFields());
			this.Id = id;
		}

		/// <summary> CTor</summary>
		/// <param name="id">PK value for DynamicTableInput which data should be fetched into this DynamicTableInput object</param>
		/// <param name="validator">The custom validator object for this DynamicTableInputEntity</param>
		/// <remarks>The entity is not fetched by this constructor. Use a DataAccessAdapter for that.</remarks>
		public DynamicTableInputEntity(System.Int32 id, IValidator validator):base("DynamicTableInputEntity")
		{
			InitClassEmpty(validator, CreateFields());
			this.Id = id;
		}

		/// <summary> Protected CTor for deserialization</summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected DynamicTableInputEntity(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			if(SerializationHelper.Optimization != SerializationOptimization.Fast) 
			{




				base.FixupDeserialization(FieldInfoProviderSingleton.GetInstance());
			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START DeserializationConstructor
			// __LLBLGENPRO_USER_CODE_REGION_END
		}

		
		/// <summary>Performs the desync setup when an FK field has been changed. The entity referenced based on the FK field will be dereferenced and sync info will be removed.</summary>
		/// <param name="fieldIndex">The fieldindex.</param>
		protected override void PerformDesyncSetupFKFieldChange(int fieldIndex)
		{
			switch((DynamicTableInputFieldIndex)fieldIndex)
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




			}
			
			// __LLBLGENPRO_USER_CODE_REGION_START GetObjectInfo
			// __LLBLGENPRO_USER_CODE_REGION_END
			base.GetObjectData(info, context);
		}

		/// <summary>Returns true if the original value for the field with the fieldIndex passed in, read from the persistent storage was NULL, false otherwise.
		/// Should not be used for testing if the current value is NULL, use <see cref="TestCurrentFieldValueForNull"/> for that.</summary>
		/// <param name="fieldIndex">Index of the field to test if that field was NULL in the persistent storage</param>
		/// <returns>true if the field with the passed in index was NULL in the persistent storage, false otherwise</returns>
		public bool TestOriginalFieldValueForNull(DynamicTableInputFieldIndex fieldIndex)
		{
			return base.Fields[(int)fieldIndex].IsNull;
		}
		
		/// <summary>Returns true if the current value for the field with the fieldIndex passed in represents null/not defined, false otherwise.
		/// Should not be used for testing if the original value (read from the db) is NULL</summary>
		/// <param name="fieldIndex">Index of the field to test if its currentvalue is null/undefined</param>
		/// <returns>true if the field's value isn't defined yet, false otherwise</returns>
		public bool TestCurrentFieldValueForNull(DynamicTableInputFieldIndex fieldIndex)
		{
			return base.CheckIfCurrentFieldValueIsNull((int)fieldIndex);
		}

				
		/// <summary>Gets a list of all the EntityRelation objects the type of this instance has.</summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		public override List<IEntityRelation> GetAllRelations()
		{
			return new DynamicTableInputRelations().GetAllRelations();
		}
		




	
		
		/// <summary>Creates entity fields object for this entity. Used in constructor to setup this entity in a polymorphic scenario.</summary>
		protected virtual IEntityFields2 CreateFields()
		{
			return EntityFieldsFactory.CreateEntityFieldsObject(Cir.Data.LLBLGen.EntityType.DynamicTableInputEntity);
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
			return EntityFactoryCache2.GetEntityFactory(typeof(DynamicTableInputEntityFactory));
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




			return toReturn;
		}
		
		/// <summary> Adds the internals to the active context. </summary>
		protected override void AddInternalsToContext()
		{




		}

		/// <summary> Initializes the class members</summary>
		protected virtual void InitClassMembers()
		{





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

			_fieldsCustomProperties.Add("Id", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("CirId", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row1Col1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row1Col2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row1Col3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row1Col4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row2Col1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row2Col2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row2Col3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row2Col4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row3Col1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row3Col2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row3Col3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row3Col4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row4Col1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row4Col2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row4Col3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row4Col4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row5Col1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row5Col2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row5Col3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row5Col4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row6Col1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row6Col2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row6Col3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row6Col4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row7Col1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row7Col2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row7Col3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row7Col4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row8Col1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row8Col2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row8Col3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row8Col4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row9Col1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row9Col2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row9Col3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row9Col4", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row10Col1", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row10Col2", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row10Col3", fieldHashtable);
			fieldHashtable = new Dictionary<string, string>();

			_fieldsCustomProperties.Add("Row10Col4", fieldHashtable);
		}
		#endregion



		/// <summary> Initializes the class with empty data, as if it is a new Entity.</summary>
		/// <param name="validator">The validator object for this DynamicTableInputEntity</param>
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
		public  static DynamicTableInputRelations Relations
		{
			get	{ return new DynamicTableInputRelations(); }
		}
		
		/// <summary> The custom properties for this entity type.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		public  static Dictionary<string, string> CustomProperties
		{
			get { return _customProperties;}
		}





		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		[Browsable(false), XmlIgnore]
		public override Dictionary<string, string> CustomPropertiesOfType
		{
			get { return DynamicTableInputEntity.CustomProperties;}
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
			get { return DynamicTableInputEntity.FieldsCustomProperties;}
		}

		/// <summary> The Id property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Id"<br/>
		/// Table field type characteristics (type, precision, scale, length): Int, 10, 0, 0<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): false, true, true</remarks>
		public virtual System.Int32 Id
		{
			get { return (System.Int32)GetValue((int)DynamicTableInputFieldIndex.Id, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Id, value); }
		}

		/// <summary> The CirId property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."CirId"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 50<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String CirId
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.CirId, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.CirId, value); }
		}

		/// <summary> The Row1Col1 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row1Col1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row1Col1
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row1Col1, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row1Col1, value); }
		}

		/// <summary> The Row1Col2 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row1Col2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row1Col2
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row1Col2, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row1Col2, value); }
		}

		/// <summary> The Row1Col3 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row1Col3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row1Col3
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row1Col3, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row1Col3, value); }
		}

		/// <summary> The Row1Col4 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row1Col4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row1Col4
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row1Col4, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row1Col4, value); }
		}

		/// <summary> The Row2Col1 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row2Col1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row2Col1
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row2Col1, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row2Col1, value); }
		}

		/// <summary> The Row2Col2 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row2Col2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row2Col2
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row2Col2, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row2Col2, value); }
		}

		/// <summary> The Row2Col3 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row2Col3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row2Col3
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row2Col3, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row2Col3, value); }
		}

		/// <summary> The Row2Col4 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row2Col4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row2Col4
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row2Col4, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row2Col4, value); }
		}

		/// <summary> The Row3Col1 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row3Col1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row3Col1
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row3Col1, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row3Col1, value); }
		}

		/// <summary> The Row3Col2 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row3Col2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row3Col2
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row3Col2, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row3Col2, value); }
		}

		/// <summary> The Row3Col3 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row3Col3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row3Col3
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row3Col3, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row3Col3, value); }
		}

		/// <summary> The Row3Col4 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row3Col4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row3Col4
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row3Col4, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row3Col4, value); }
		}

		/// <summary> The Row4Col1 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row4Col1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row4Col1
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row4Col1, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row4Col1, value); }
		}

		/// <summary> The Row4Col2 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row4Col2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row4Col2
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row4Col2, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row4Col2, value); }
		}

		/// <summary> The Row4Col3 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row4Col3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row4Col3
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row4Col3, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row4Col3, value); }
		}

		/// <summary> The Row4Col4 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row4Col4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row4Col4
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row4Col4, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row4Col4, value); }
		}

		/// <summary> The Row5Col1 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row5Col1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row5Col1
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row5Col1, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row5Col1, value); }
		}

		/// <summary> The Row5Col2 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row5Col2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row5Col2
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row5Col2, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row5Col2, value); }
		}

		/// <summary> The Row5Col3 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row5Col3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row5Col3
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row5Col3, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row5Col3, value); }
		}

		/// <summary> The Row5Col4 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row5Col4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row5Col4
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row5Col4, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row5Col4, value); }
		}

		/// <summary> The Row6Col1 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row6Col1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row6Col1
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row6Col1, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row6Col1, value); }
		}

		/// <summary> The Row6Col2 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row6Col2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row6Col2
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row6Col2, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row6Col2, value); }
		}

		/// <summary> The Row6Col3 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row6Col3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row6Col3
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row6Col3, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row6Col3, value); }
		}

		/// <summary> The Row6Col4 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row6Col4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row6Col4
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row6Col4, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row6Col4, value); }
		}

		/// <summary> The Row7Col1 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row7Col1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row7Col1
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row7Col1, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row7Col1, value); }
		}

		/// <summary> The Row7Col2 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row7Col2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row7Col2
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row7Col2, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row7Col2, value); }
		}

		/// <summary> The Row7Col3 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row7Col3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row7Col3
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row7Col3, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row7Col3, value); }
		}

		/// <summary> The Row7Col4 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row7Col4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row7Col4
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row7Col4, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row7Col4, value); }
		}

		/// <summary> The Row8Col1 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row8Col1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row8Col1
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row8Col1, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row8Col1, value); }
		}

		/// <summary> The Row8Col2 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row8Col2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row8Col2
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row8Col2, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row8Col2, value); }
		}

		/// <summary> The Row8Col3 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row8Col3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row8Col3
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row8Col3, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row8Col3, value); }
		}

		/// <summary> The Row8Col4 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row8Col4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row8Col4
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row8Col4, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row8Col4, value); }
		}

		/// <summary> The Row9Col1 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row9Col1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row9Col1
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row9Col1, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row9Col1, value); }
		}

		/// <summary> The Row9Col2 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row9Col2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row9Col2
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row9Col2, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row9Col2, value); }
		}

		/// <summary> The Row9Col3 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row9Col3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row9Col3
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row9Col3, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row9Col3, value); }
		}

		/// <summary> The Row9Col4 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row9Col4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row9Col4
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row9Col4, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row9Col4, value); }
		}

		/// <summary> The Row10Col1 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row10Col1"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row10Col1
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row10Col1, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row10Col1, value); }
		}

		/// <summary> The Row10Col2 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row10Col2"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row10Col2
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row10Col2, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row10Col2, value); }
		}

		/// <summary> The Row10Col3 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row10Col3"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row10Col3
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row10Col3, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row10Col3, value); }
		}

		/// <summary> The Row10Col4 property of the Entity DynamicTableInput<br/><br/>
		/// </summary>
		/// <remarks>Mapped on  table field: "DynamicTableInput"."Row10Col4"<br/>
		/// Table field type characteristics (type, precision, scale, length): VarChar, 0, 0, 100<br/>
		/// Table field behavior characteristics (is nullable, is PK, is identity): true, false, false</remarks>
		public virtual System.String Row10Col4
		{
			get { return (System.String)GetValue((int)DynamicTableInputFieldIndex.Row10Col4, true); }
			set	{ SetValue((int)DynamicTableInputFieldIndex.Row10Col4, value); }
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
			get { return (int)Cir.Data.LLBLGen.EntityType.DynamicTableInputEntity; }
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
