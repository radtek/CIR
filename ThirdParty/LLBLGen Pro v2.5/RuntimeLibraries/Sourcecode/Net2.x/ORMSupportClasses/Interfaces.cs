//////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
// The sourcecode for the ORM Support classes is released as BSD2 licensed 
// open source, so licensees of LLBLGen Pro can modify, update and/or extend it. 
// Distribution of this sourcecode and binary compiled versions of this sourcecode
// are licensed to LLBLGen Pro licensees using the following license below.
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2002-2007 Solutions Design. All rights reserved.
// 
// The ORM Support classes library sourcecode is released under the following license: (BSD2)
// ----------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Frans Bouma [FB]
//		- Simon Hewitt
//////////////////////////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.Common;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Collections.Specialized;
using System.IO;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	#region SelfServicing specific interfaces

	/// <summary>
	/// Interface definition for the PrefetchPathElement type, which instances are used in a PrefetchPath instance.
	/// Selfservicing specific
	/// </summary>
	public interface IPrefetchPathElement: IPrefetchPathElementCore
	{
		/// <summary>
		/// The subpath containing path elements to retrieve in the ToFetch entity of this PrefetchPathElement. Can be empty.
		/// </summary>
		IPrefetchPath SubPath {get; set;}
		/// <summary>
		/// The entity collection to fill (and to use to retrieve the entities to fetch). After the fetch, this collection contains
		/// the entities to merge with the instances of the parent entity. 
		/// </summary>
		IEntityCollection RetrievalCollection {get;}
	}


	/// <summary>
	/// Interface definition for the PrefetchPath type, which specifies a prefetch path to fetch related entities during a fetch.
	/// SelfServicing specific.
	/// </summary>
	public interface IPrefetchPath
	{
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement Add(IPrefetchPathElement elementToAdd);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		IPrefetchPathElement Add(IPrefetchPathElement elementToAdd, ExcludeIncludeFieldsList excludedIncludedFields);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement Add(IPrefetchPathElement elementToAdd, int maxAmountOfItemsToReturn);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement Add(IPrefetchPathElement elementToAdd, int maxAmountOfItemsToReturn, IPredicateExpression additionalFilter);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <param name="additionalFilterRelations">Additional relations to be added to the relationcollection already in the PrefetchPathElement</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement Add(IPrefetchPathElement elementToAdd, int maxAmountOfItemsToReturn, 
			IPredicateExpression additionalFilter, IRelationCollection additionalFilterRelations);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <param name="additionalFilterRelations">Additional relations to be added to the relationcollection already in the PrefetchPathElement</param>
		/// <param name="additionalSorter">Additional sort clauses to be added added to the sortexpression already in the PrefetchPathElement</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement Add(IPrefetchPathElement elementToAdd, int maxAmountOfItemsToReturn, 
			IPredicateExpression additionalFilter, IRelationCollection additionalFilterRelations, ISortExpression additionalSorter);

		/// <summary>
		/// Indexer in the prefetch path
		/// </summary>
		IPrefetchPathElement this[int index] {get; set; }
		/// <summary>
		/// The EntityType enum value for the entity which is the root type of this path.
		/// </summary>
		/// <remarks>Set in the constructor</remarks>
		int	RootEntityType { get; }
		/// <summary>
		/// Returns the amount of PrefetchPathElement in this object
		/// </summary>
		int Count {get;}
	}


	/// <summary>
	/// Interface for the EntityField type. An EntityField is the unit which is used to hold the value for a given property of an entity.
	/// SelfServicing specific.
	/// </summary>
	public interface IEntityField : IEntityFieldCore, IFieldPersistenceInfo
	{
		/// <summary>
		/// Sets the entity field's ObjectAlias property to the specified value
		/// </summary>
		/// <param name="objectAlias">value to set</param>
		/// <returns>The entity field object the method was called on, for command chaining</returns>
		EntityField SetObjectAlias(string objectAlias);
		/// <summary>
		/// Sets the EntityField's AggregateFunctionToApply property
		/// </summary>
		/// <param name="functionToToApply">Function to apply.</param>
		/// <returns>The entity field object the method was called on, for command chaining</returns>
		EntityField SetAggregateFunction(AggregateFunction functionToToApply);
		/// <summary>
		/// Sets the Entity Field's ExpressionToToApply property
		/// </summary>
		/// <param name="expressionToToApply">Expression to to apply.</param>
		/// <returns>The entity field object the method was called on, for command chaining</returns>
		EntityField SetExpression(IExpression expressionToToApply);
		/// <summary>
		/// Sets the field alias.
		/// </summary>
		/// <param name="fieldAlias">The field alias.</param>
		/// <returns>The entity field object the method was called on, for command chaining</returns>
		EntityField SetFieldAlias( string fieldAlias );
		/// <summary>
		/// Converts this EntityField to an XmlNode. 
		/// </summary>
		/// <returns>This EntityField in XmlNode format</returns>
		XmlNode ToXml();
		/// <summary>
		/// Converts this EntityField2 to an XmlNode. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will return. This document is required
		/// to create the new node object</param>
		/// <param name="entityFieldNode">The output parameter which will represent this EntityField2 as XmlNode</param>
		void WriteXml(XmlFormatAspect aspects, XmlDocument parentDocument, out XmlNode entityFieldNode);
	}


	/// <summary>
	/// Interface for the EntityFields type. An EntityFields type is a collection of IEntityField objects which forms the total amount of fields for a given entity.
	/// SelfServicing specific
	/// </summary>
	public interface IEntityFields : IEditableObject, IEnumerable
	{
		/// <summary>
		/// Expands this entity fields object by appending numberOfCells new cells to this object. 
		/// </summary>
		/// <param name="numberOfNewCells">number of cells to append to this fieldsobject</param>
		/// <remarks>Use with care. Empty cells can cause the DQE's to produce undefined results. Use this routine to append fields to a
		/// Typed list in code for example. </remarks>
		void Expand( int numberOfNewCells );
		/// <summary>
		/// Contracts the list of fields so all empty slots at the end of the list of fields are removed. Doesn't perform a contract operation if the
		/// fields object is empty
		/// </summary>
		/// <returns>the new size of the fields object, or if the fields object is completely empty, the full size</returns>
		int Contract();
		/// <summary>
		/// Compacts the list of fields so all empty slots are removed. 
		/// </summary>
		void Compact();
		/// <summary>
		/// Overrides the GetHashCode routine. It will calculate a hashcode for this set of entity fields using the eXclusive OR of the 
		/// hashcodes of the primary key fields in this set of entity fields. That hashcode is returned. If no primary key fields are present,
		/// the hashcode of the base class is returned, which will not be unique.
		/// </summary>
		/// <returns>Hashcode for this entity object, based on its primary key field values</returns>
		int GetHashCode();
		/// <summary>
		/// Returns the complete list of IEntityField objects as an array of IFieldPersistenceInfo objects. IEntityField objects implement
		/// IFieldPersistenceInfo.
		/// </summary>
		/// <returns>Array of IFieldPersistenceInfo objects</returns>
		IFieldPersistenceInfo[] GetAsPersistenceInfoArray();
		/// <summary>
		/// Returns the complete list of IEntityField objects as an array of IEntityFieldCore objects. IEntityField objects implement
		/// IEntityFieldCore
		/// </summary>
		/// <returns>Array of IEntityFieldCore objects</returns>
		IEntityFieldCore[] GetAsEntityFieldCoreArray();
		/// <summary>
		/// Converts this EntityFields object to a set of XmlNodes with all the fields as individual nodes.
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="parentDocument">the XmlDocument which will contain the nodes this method will create. This document is required
		/// to create the new nodes for the fields</param>
		/// <param name="parentNode">the node the fields will have to be added to.</param>
		void WriteXml(XmlFormatAspect aspects, XmlDocument parentDocument, XmlNode parentNode);
		/// <summary>
		/// Reads the fields which are childnodes of the passed in fieldsElement into this object
		/// </summary>
		/// <param name="fieldsElement"></param>
		void ReadXml(XmlNode fieldsElement);
		/// <summary>
		/// Links the specified fields with eachother so setting one to a different value will automatically set the other one as well.
		/// This is required in target-per-entity entities which have multiple times the same PK field in their field list.
		/// </summary>
		/// <param name="superTypeFieldIndex">index of field in the supertype</param>
		/// <param name="subTypeFieldIndex">index of field in the subtype</param>
		void LinkFields(int superTypeFieldIndex, int subTypeFieldIndex);
		/// <summary>
		/// Links the supertype PK fields with the subtype PK fields IF there are PK fields of multiple entities in the set of PK fields.
		/// Linking is required in target-per-entity entities which have multiple times the same PK field in their field list.
		/// </summary>
		void LinkFields();
		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		void DefineField( IEntityField fieldToAdd, int indexInFields );
		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		void DefineField( IEntityField fieldToAdd, int indexInFields, string alias );
		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		void DefineField( IEntityField fieldToAdd, int indexInFields, AggregateFunction aggregateFunctionToApply );
		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		void DefineField( IEntityField fieldToAdd, int indexInFields, string alias, AggregateFunction aggregateFunctionToApply );
		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		void DefineField( IEntityField fieldToAdd, int indexInFields, string alias, string entityAlias );
		/// <summary>Adds the specified field on the position indexInFields in the resultset.</summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		void DefineField( IEntityField fieldToAdd, int indexInFields, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply );
		/// <summary>
		/// Clones this instance and its contents using a deep copy.
		/// </summary>
		/// <returns>an exact, deep copy of this EntityFields object and its contents.</returns>
		EntityFields Clone();
		/// <summary>
		/// Clones this object to a new EntityFields object where all fields are changed and the object itself is marked dirty.
		/// </summary>
		/// <returns></returns>
		EntityFields CloneAsDirty();
		/// <summary>
		/// Creates a shallow copy of this instance, which means that a new EntityFields object is created but all membervariables are kept the same. 
		/// </summary>
		/// <returns>Shallow copy of this instance</returns>
		EntityFields ShallowClone();

		/// <summary>
		/// The amount of IEntityFields allocated in the EntityFields object.
		/// </summary>
		int	Count {get;}
		/// <summary>
		/// Gets the flag if the contents of the EntityFields object is 'dirty', which means that one or more fields are changed. 
		/// </summary>
		bool IsDirty {get; set;}
		/// <summary>
		/// Gets / sets the EntityField on the specified Index. 
		/// </summary>
		/// <exception cref="System.IndexOutOfRangeException">When the index specified is not found in the internal datastorage.</exception>
		/// <exception cref="System.ArgumentNullException">When the passed in <see cref="IEntityField"/> is null</exception>
		/// <exception cref="System.ArgumentException">When the passed in <see cref="IEntityField"/> is already added. Fields have to be unique.</exception>
		IEntityField this [int index] {get; set;} 
		/// <summary>
		/// Gets the EntityField with the specified name.
		/// </summary>
		/// <exception cref="System.ArgumentException">When the specified name is the empty string or contains only spaces</exception>
		/// <remarks>This property is read-only. If you want to set a value, use the int indexer</remarks>
		IEntityField this [string name] {get;}
		/// <summary>
		/// List of IEntityField references which form the primary key
		/// </summary>
		List<IEntityField> PrimaryKeyFields {get;}
		/// <summary>
		/// The state of the EntityFields object, the heart and soul of every EntityObject.
		/// </summary>
		EntityState State {get; set;}
		/// <summary>
		/// Flag to signal if the entity fields have changed during an edit cycle which is controlled outside this IEntityFields object. If set to
		/// true, EndEdit will succeed, otherwise EndEdit will ignore any changes, since these are made in a previous edit cycle which is already
		/// ended.
		/// </summary>
		bool IsChangedInThisEditCycle {get; set;}
	}


	/// <summary>
	/// Interface used for all Entity classes, it's the interface implemented by the abstract base class which is used to derive every entity class from
	/// SelfServicing specific
	/// </summary>
	public interface IEntity : IEntityCore
	{
		/// <summary>
		/// Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		void SetRelatedEntityProperty( string propertyName, IEntity entity );
		/// <summary>
		/// Sets the internal parameter related to the fieldname passed to the instance relatedEntity. 
		/// </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		void SetRelatedEntity(IEntity relatedEntity, string fieldName);
		/// <summary>
		/// Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() 
		/// </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		void UnsetRelatedEntity(IEntity relatedEntity, string fieldName);
		/// <summary>
		/// Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() 
		/// </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		void UnsetRelatedEntity( IEntity relatedEntity, string fieldName, bool signalRelatedEntityManyToOne );
		/// <summary>
		/// Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These
		/// entities will have to be persisted after this entity during a recursive save.
		/// </summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		List<IEntity> GetDependingRelatedEntities();
		/// <summary>
		/// Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.
		/// </summary>
		/// <returns>Collection with 0 or more IEntity objects, referenced by this entity</returns>
		List<IEntity> GetDependentRelatedEntities();
		/// <summary>
		/// Gets a list of all entity collections stored as member variables in this entity. The contents of the list is
		/// used by the Save logic to perform recursive saves. Only 1:n related collections are returned.
		/// </summary>
		/// <returns>Collection with 0 or more IEntityCollection objects, referenced by this entity</returns>
		List<IEntityCollection> GetMemberEntityCollections();
		/// <summary>
		/// Saves the Entity class to the persistent storage. It updates or inserts the entity, which depends if the entity was originally read from the 
		/// database. Will not recursively save internal dirty entities. 
		/// Uses, if applicable, the ConcurrencyPredicateFactory to supply the predicate to limit save activity.
		/// </summary>
		/// <returns>true if Save succeeded, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the save process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		bool Save();
		/// <summary>
		/// Saves the Entity class to the persistent storage. It updates or inserts the entity, which depends if the entity was originally read from the 
		/// database.
		/// Uses, if applicable, the ConcurrencyPredicateFactory to supply the predicate to limit save activity.
		/// </summary>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by this entity also.</param>
		/// <returns>true if Save succeeded, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the save process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		bool Save(bool recurse);
		/// <summary>
		/// Saves the Entity class to the persistent storage. It updates or inserts the entity, which depends if the entity was originally read from the 
		/// database. If the entity is new, an insert is done and the updateRestriction is ignored. If the entity is not new, the updateRestriction
		/// predicate is used to create an additional where clause (it will be added with AND) for the update query. This predicate can be used for
		/// concurrency checks, like checks on timestamp column values. Will not recursively save internal dirty entities. 
		/// </summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query. Will be ignored when the entity is
		/// new. Overrules an optional set ConcurrencyPredicateFactory.</param>
		/// <returns>true if Save succeeded, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the save process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		bool Save(IPredicate updateRestriction);
		/// <summary>
		/// Saves the Entity class to the persistent storage. It updates or inserts the entity, which depends if the entity was originally read from the 
		/// database. If the entity is new, an insert is done and the updateRestriction is ignored. If the entity is not new, the updateRestriction
		/// predicate is used to create an additional where clause (it will be added with AND) for the update query. This predicate can be used for
		/// concurrency checks, like checks on timestamp column values.
		/// </summary>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query. Will be ignored when the entity is
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by this entity also.</param>
		/// new. Overrules an optional set ConcurrencyPredicateFactory.</param>
		/// <returns>true if Save succeeded, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the save process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		bool Save(IPredicate updateRestriction, bool recurse);
		/// <summary>
		/// Deletes the Entity from the persistent storage. This method succeeds also when the Entity is not present.
		/// Uses, if applicable, the ConcurrencyPredicateFactory to supply the predicate to limit delete activity.
		/// </summary>
		/// <returns>true if Delete succeeded, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the delete process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		bool Delete();
		/// <summary>
		/// Deletes the Entity from the persistent storage. This method succeeds also when the Entity is not present.
		/// </summary>
		/// <param name="deleteRestriction">Predicate expression, meant for concurrency checks in a delete query. Overrules the predicate returned
		/// by a set ConcurrencyPredicateFactory object.</param>
		/// <returns>true if Delete succeeded, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the delete process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		bool Delete(IPredicate deleteRestriction);
		/// <summary>
		/// Refetches the Entity from the persistent storage. Refetch is used to re-load an Entity which is marked "Out-of-sync", due to a save action. 
		/// Refetching an empty Entity has no effect.
		/// </summary>
		/// <returns>true if Refetch succeeded, false otherwise</returns>
		/// <exception cref="ORMQueryExecutionException">When an exception is caught during the save process. The caught exception is set as the
		/// inner exception. Encapsulation of database-related exceptions is necessary since these exceptions do not have a common exception framework
		/// implemented.</exception>
		bool Refetch();
		/// <summary>
		/// Returns a new ready to use factory for the type of this instance.
		/// </summary>
		/// <returns>a new ready to use factory for the type of this instance.</returns>
		IEntityFactory GetEntityFactory();
		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into this entity. 
		/// </summary>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the entity. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.</remarks>
		void FetchExcludedFields(ExcludeIncludeFieldsList excludedIncludedFields);

		/// <summary>
		/// The internal presentation of the data, which is an EntityFields object, which implements <see cref="IEntityFields"/>.
		/// </summary>
		IEntityFields Fields {get; set;}
		/// <summary>
		/// Returns true if this entity instance is in the middle of a serialization process, for example during a WriteXml() call.
		/// For internal use only. 
		/// </summary>
		bool IsSerializing {get; set;}
		/// <summary>
		/// List of IEntityField references which form the primary key. Reads/Affects .Fields.PrimaryKeyFields
		/// </summary>
		List<IEntityField> PrimaryKeyFields {get;}
	}


	/// <summary>
	/// Interface for the definition of a Transaction class which is used to control a serie of actions on multiple entities or entity collection classes.
	/// SelfServicing specific
	/// </summary>
	public interface ITransaction
	{
		/// <summary>
		/// Commits the transaction in action. It will end all database activity, since commiting a transaction is finalizing it. After
		/// calling Commit or Rollback, the ITransaction implementing class will reset itself. When used in combination of COM+, it will
		/// call ContextUtil.SetComplete() to commit the current COM+ transaction.
		/// </summary>
		void Commit();
		/// <summary>
		/// Rolls back the transaction in action. It will end all database activity, since commiting a transaction is finalizing it. After
		/// calling Commit or Rollback, the ITransaction implementing class will reset itself. When used in combination of COM+, it will
		/// call ContextUtil.SetAbort() to abort (rollback) the current COM+ transaction.
		/// </summary>
		void Rollback();
		/// <summary>
		/// Creates a savepoint with the name savePointName in the current transaction. You can roll back to this savepoint using
		/// <see cref="Rollback(string)"/>.
		/// </summary>
		/// <param name="savePointName">name of savepoint. Must be unique in an active transaction</param>
		/// <exception cref="InvalidOperationException">If no transaction is in progress.</exception>
		/// <exception cref="ArgumentException">if savePointName is empty or null</exception>
		/// <exception cref="NotSupportedException">if the .NET database provider doesn't support transaction saving or when COM+ is used.</exception>
		void Save( string savePointName );
		/// <summary>
		/// Rolls back the transaction in action to the savepoint with the name savepointName. No internal objects are being reset when this method is called,
		/// so call this Rollback overload only to roll back to a savepoint. To roll back a complete transaction, call Rollback() without specifying a savepoint
		/// name. Create a savepoint by calling Save(savePointName)
		/// </summary>
		/// <param name="savePointName">name of the savepoint to roll back to.</param>
		/// <exception cref="InvalidOperationException">If no transaction is in progress.</exception>
		/// <exception cref="ArgumentException">if savePointName is empty or null</exception>
		/// <exception cref="NotSupportedException">if the .NET database provider doesn't support transaction rolling back a transaction to a named
		/// point or when COM+ is used.</exception>
		/// <remarks>Not supported when using COM+</remarks>
		void Rollback( string savePointName );
		/// <summary>
		/// Disposes the instance
		/// </summary>
		void Dispose();
		/// <summary>
		/// Adds the passed in object as a participant of this transaction. 
		/// </summary>
		/// <param name="participant">The ITransactionalElement implementing object which actions have to be included in this transaction</param>
		void Add(ITransactionalElement participant);
		/// <summary>
		/// Removes the passed in object from the transaction.
		/// </summary>
		/// <param name="participant">The ITransactionalElement implementing object which should be removed from this transaction</param>
		void Remove(ITransactionalElement participant);
		/// <summary>
		/// Gets the isolation level the transaction should use. Only settable with the constructor.
		/// </summary>
		IsolationLevel TransactionIsolationLevel {get;}
		/// <summary>
		/// Gets the name of the transaction. Only settable with the constructor.
		/// </summary>
		string Name {get; }
		/// <summary>
		/// Gets the connection string used for the connection with the database. Only settable with the constructor.
		/// </summary>
		string ConnectionString {get; }
		/// <summary>
		/// The connection object to use with this transaction. 
		/// </summary>
		IDbConnection ConnectionToUse {get; }
		/// <summary>
		/// The physical transaction object used over <see cref="ConnectionToUse"/>.
		/// </summary>
		IDbTransaction PhysicalTransaction {get; }
		/// <summary>
		/// List of GUID's of the entities currently participating in this transaction. This collection is
		/// used to keep track of which entities already have been added during a recursive save.
		/// </summary>
		List<Guid> EntitiesInTransaction {get;}
	}


	/// <summary>
	/// Interface which is necessary for the Transaction class. Every class which has to be controlled by a Transaction object
	/// has to implement this interface. Examples are: an Entity class and an Entity Collection Class.
	/// SelfServicing specific
	/// </summary>
	public interface ITransactionalElement
	{
		/// <summary>
		/// The <see cref="ITransaction"/> this ITransactionalElement implementing object is participating in. Only valid if
		/// <see cref="ParticipatesInTransaction"/> is true. If set to null, the ITransactionalElement is no longer participating
		/// in a transaction.
		/// </summary>
		ITransaction Transaction {get; set;}
		/// <summary>
		/// Flag to check if the ITransactionalElement implementing object is participating in a transaction or not.
		/// </summary>
		bool ParticipatesInTransaction {get; }
		/// <summary>
		/// When the <see cref="ITransaction"/> in which this element participates is commited, this element can succesfully finish actions performed by this
		/// element. This method is called by <see cref="ITransaction"/>, you should not call it by yourself. When this element doesn't participate in a
		/// transaction it finishes the actions itself, calling this method is not needed.
		/// </summary>
		void TransactionCommit();
		/// <summary>
		/// When the <see cref="ITransaction"/> in which this element participates is rolled back, this element has to roll back its internal variables.
		/// This method is called by <see cref="ITransaction"/>, you should not call it by yourself. 
		/// </summary>
		void TransactionRollback();
	}


	/// <summary>
	/// Interface for Data Access Objects (DAO). Every IEntity implementation has one specific Dao object
	/// SelfServicing specific.
	/// </summary>
	public interface IDao
	{
		/// <summary>
		/// Adds the given fields to the database as a new entity. 
		/// </summary>
		/// <param name="fields">The EntityField data to use for the insert.</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <returns>true if the addition was succesful, false otherwise</returns>
		/// <exception cref="ArgumentNullException">When fields is null</exception>
		bool AddNew( IEntityFields fields, ITransaction containingTransaction );
		/// <summary>
		/// Updates an existing entity using the given fields. 
		/// </summary>
		/// <param name="fields">The EntityField data to use for the update</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <returns>true if the update was succesful, false otherwise</returns>
		/// <exception cref="ArgumentNullException">When fields is null</exception>
		bool UpdateExisting( IEntityFields fields, ITransaction containingTransaction );
		/// <summary>
		/// Updates an existing entity using the given fields. 
		/// </summary>
		/// <param name="fields">The EntityField data to use for the update</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query</param>
		/// <returns>true if the update was succesful, false otherwise</returns>
		/// <exception cref="ArgumentNullException">When fields is null</exception>
		bool UpdateExisting( IEntityFields fields, ITransaction containingTransaction, IPredicate updateRestriction );
		/// <summary>
		/// Reads the data of the entity passed in, and returns that object. Which data is read is determined using
		/// the set Primary Key field(s). If specified, it also processes the prefetch path.
		/// </summary>
		/// <param name="entityToFetch">The entity to fetch. Contained data will be overwritten.</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="selectFilter">Select filter.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="contextToUse">The context to fetch the prefetch path with.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		void PerformFetchEntityAction(IEntity entityToFetch, ITransaction containingTransaction, IPredicateExpression selectFilter,
				IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields);
		/// <summary>
		/// Retrieves in the calling Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to
		/// construct the total query.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IPredicate selectFilter,
			IRelationCollection relations, int pageNumber, int pageSize );
		/// <summary>
		/// Retrieves in the calling Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to
		/// construct the total query.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IPredicate selectFilter,
			IRelationCollection relations, IPrefetchPath prefetchPathToUse, int pageNumber, int pageSize );
		/// <summary>
		/// Retrieves in the calling entity collection object all entity objects
		/// which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to 
		/// construct the total query. It will also prefetch all related objects defined in the prefetchpath specified.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IPredicate selectFilter,
			IRelationCollection relations, IPrefetchPath prefetchPathToUse );
		/// <summary>
		/// Retrieves in the calling Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to
		/// construct the total query.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="collectionToFill">Collection to fill with the entity objects retrieved</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum number of items to return with this retrieval query.
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return.
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="entityFactoryToUse">The EntityFactory to use when creating entity objects during a GetMulti() call.</param>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct to total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti(ITransaction containingTransaction, IEntityCollection collectionToFill, long maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IEntityFactory entityFactoryToUse, IPredicate selectFilter,
			IRelationCollection relations, IPrefetchPath prefetchPathToUse, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize);
		/// <summary>
		/// Deletes from the persistent storage all entities which match with the specified filter, formulated in
		/// the predicate or predicate expression definition, of the type and subtypes of the entity owning this DAO.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="deleteFilter">A predicate or predicate expression which should be used as filter for the entities to delete.</param>
		/// <returns>Number of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		/// <remarks>Not supported for deleting entities which are part of a TargetPerEntity hierarchy</remarks>
		int DeleteMulti( ITransaction containingTransaction, IPredicate deleteFilter );
		/// <summary>
		/// Deletes from the persistent storage all 'Employee' entities which match with the specified filter, formulated in
		/// the predicate or predicate expression definition.
		/// </summary>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="deleteFilter">A predicate or predicate expression which should be used as filter for the entities to delete.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <returns>Number of entities affected, if the used persistent storage has rowcounting enabled.</returns>
		/// <remarks>Not supported for deleting entities which are part of a TargetPerEntity hierarchy</remarks>
		int DeleteMulti( ITransaction containingTransaction, IPredicate deleteFilter, IRelationCollection relations );
		/// <summary>
		/// Updates all entities of the same type or subtype of the entity <i>entityWithNewValues</i> directly in the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>. Only the fields changed in entityWithNewValues are updated for these fields. Entities of a subtype of the type
		/// of <i>entityWithNewValues</i> which are affected by the filterBucket's filter will thus also be updated. 
		/// </summary>
		/// <param name="entityWithNewValues">IEntity instance which holds the new values for the matching entities to update. Only
		/// changed fields are taken into account</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="updateFilter">A predicate or predicate expression which should be used as filter for the entities to update.</param>
		/// <returns>Number of entities affected, if the used persistent storage has rowcounting enabled. Use the returned value to determine if the
		/// update succeeded (value &gt; 0)</returns>
		int UpdateMulti( IEntity entityWithNewValues, ITransaction containingTransaction, IPredicate updateFilter );
		/// <summary>
		/// Updates all entities of the same type or subtype of the entity <i>entityWithNewValues</i> directly in the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>. Only the fields changed in entityWithNewValues are updated for these fields. Entities of a subtype of the type
		/// of <i>entityWithNewValues</i> which are affected by the filterBucket's filter will thus also be updated.
		/// </summary>
		/// <param name="entityWithNewValues">IEntity instance which holds the new values for the matching entities to update. Only
		/// changed fields are taken into account</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="updateFilter">A predicate or predicate expression which should be used as filter for the entities to update.</param>
		/// <param name="relations">Set of relations to walk to construct the total query</param>
		/// <returns>
		/// Number of entities affected, if the used persistent storage has rowcounting enabled. Use the returned value to determine if the
		/// update succeeded (value &gt; 0)
		/// </returns>
		int UpdateMulti( IEntity entityWithNewValues, ITransaction containingTransaction, IPredicate updateFilter, IRelationCollection relations );
		/// <summary>
		/// Executes the expression defined with the field in the fields collection specified, using the various elements defined. The expression is executed as a
		/// scalar query and a single value is returned.
		/// </summary>
		/// <param name="fields">IEntityFields instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="filter">filter to use</param>
		/// <param name="relations">The relations to walk</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>the value which is the result of the expression defined on the specified field</returns>
		object GetScalar( IEntityFields fields, ITransaction containingTransaction, IPredicate filter, IRelationCollection relations,
			IGroupByCollection groupByClause );
		/// <summary>
		/// Executes the expression defined with the field in the fields collection specified, using the various elements defined. The expression is executed as a
		/// scalar query and a single value is returned.
		/// </summary>
		/// <param name="fields">IEntityFields instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="filter">filter to use</param>
		/// <param name="relations">The relations to walk</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="allowDuplicates">Allow duplicates in the resultset.</param>
		/// <returns>
		/// the value which is the result of the expression defined on the specified field
		/// </returns>
		object GetScalar( IEntityFields fields, ITransaction containingTransaction, IPredicate filter, IRelationCollection relations,
			IGroupByCollection groupByClause, bool allowDuplicates );
		/// <summary>
		/// Gets the number of rows returned by a query for the fields specified, using the filter and groupby clause specified. 
		/// </summary>
		/// <param name="fields">IEntityFields instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="filter">filter to use</param>
		/// <param name="relations">The relations to walk</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>the number of rows in the set defined by the query elements passed in</returns>
		int GetDbCount( IEntityFields fields, ITransaction containingTransaction, IPredicate filter, IRelationCollection relations,
			IGroupByCollection groupByClause );
				/// <summary>
		/// Gets the number of rows returned by a query for the fields specified, using the filter and groupby clause specified.
		/// </summary>
		/// <param name="fields">IEntityFields instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="filter">filter to use</param>
		/// <param name="relations">The relations to walk</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="allowDuplicates">Allow duplicates in the resultset.</param>
		/// <returns>the number of rows in the set defined by the query elements passed in</returns>
		int GetDbCount( IEntityFields fields, ITransaction containingTransaction, IPredicate filter, IRelationCollection relations,
			IGroupByCollection groupByClause, bool allowDuplicates );
		/// <summary>
		/// Performs the polymorphic entity fetch for the entity type of this DAO. It will produce an entity of that type or a subtype of that type, based
		/// on the values retrieved, or an empty entity if not found. The passed in fields object has its PK fields filled, which are used to
		/// produce a PK filter.
		/// </summary>
		/// <param name="containingTransaction">Containing transaction.</param>
		/// <param name="fields">Fields required for PK construction</param>
		/// <param name="contextToUse">Context to use for fetch</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>New entity with the data filtered by the passed in PK filter, or an empty entity if not found. Entity can be of type
		/// produced by the set entity factory (which produces entities of the type this DAO is for) or a subtype.</returns>
		IEntity FetchExistingPolymorphic(ITransaction containingTransaction, IEntityFields fields, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields);
		/// <summary>
		/// Reads the data of an entity into the specified EntityFields object and returns that object. Which data is read is determined using
		/// the passed in Primary Key field(s). If specified, it also processes the prefetch path.
		/// </summary>
		/// <param name="entityToFetch">The entity to fetch. Contained data will be overwritten.</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="contextToUse">The context to fetch the prefetch path with.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <exception cref="ArgumentNullException">When fieldsToFetch is null</exception>
		void FetchExisting(IEntity entityToFetch, ITransaction containingTransaction, IPrefetchPath prefetchPathToUse, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields);
		/// <summary>
		/// Deletes an entity from the persistent storage. Which entity is deleted is determined from the passed in EntityFields object.
		/// </summary>
		/// <param name="fields">The EntityField data to use for the deletion</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="deleteRestriction">Predicate expression, meant for concurrency checks in a delete query. Can be null.</param>
		/// <returns>true if the delete was succesful, false otherwise</returns>
		/// <exception cref="ArgumentNullException">When fields is null</exception>
		bool DeleteExisting(IEntityFields fields, ITransaction containingTransaction, IPredicate deleteRestriction);
		/// <summary>
		/// Executes the passed in action query and, if not null, runs it inside the passed in transaction.
		/// </summary>
		/// <param name="queryToExecute">ActionQuery to execute.</param>
		/// <param name="containingTransaction">A containing transaction if caller is added to a transaction, or null of not.</param>
		/// <returns>execution result, which is the amount of rows affected (if applicable)</returns>
		int ExecuteActionQuery(IActionQuery queryToExecute, ITransaction containingTransaction);
		/// <summary>
		/// Executes the passed in retrieval query and, if not null, runs it inside the passed in transaction. Used to read 1 row.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="containingTransaction">A containing transaction if caller is added to a transaction, or null of not.</param>
		/// <param name="fieldsToFill">The IEntityFields object to store the fetched data in</param>
		/// <param name="fieldPersistenceInfos">The field persistence info objects used to produce the query. This array contains null for all excluded
		/// fields and is necessary for the row fetcher. Overriders of this method should pass fieldsToFill.GetAsPersistenceInfoArray() to this parameter</param>
		void ExecuteSingleRowRetrievalQuery(IRetrievalQuery queryToExecute, ITransaction containingTransaction, IEntityFields fieldsToFill,
			IFieldPersistenceInfo[] fieldPersistenceInfos);
		/// <summary>
		/// Executes the passed in retrieval query and, if not null, runs it inside the passed in transaction. Used to read 1 row.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="containingTransaction">A containing transaction if caller is added to a transaction, or null of not.</param>
		/// <param name="collectionToFill">Collection to fill with the retrieved rows.</param>
		/// <param name="allowDuplicates">Flag to signal if duplicates in the datastream should be loaded into the collection (true) or not (false)</param>
		/// <param name="fieldsUsedForQuery">Fields used for producing the query</param>
		/// <param name="fieldPersistenceInfos">The field persistence info objects used to produce the query. This array contains null for all excluded
		/// fields and is necessary for the row fetcher. Overriders of this method should pass fieldsToFill.GetAsPersistenceInfoArray() to this parameter</param>
		void ExecuteMultiRowRetrievalQuery(IRetrievalQuery queryToExecute, ITransaction containingTransaction,
			IEntityCollection collectionToFill, bool allowDuplicates, IEntityFields fieldsUsedForQuery, IFieldPersistenceInfo[] fieldPersistenceInfos);
		/// <summary>
		/// Executes the passed in query as a scalar query and returns the value returned from this scalar execution. 
		/// </summary>
		/// <param name="queryToExecute">a scalar query, which is a SELECT query which returns a single value</param>
		/// <param name="containingTransaction">A containing transaction if caller is added to a transaction, or null of not.</param>
		/// <returns>the scalar value returned from the query.</returns>
		object ExecuteScalarQuery(IRetrievalQuery queryToExecute, ITransaction containingTransaction);
		/// <summary>
		/// Executes the passed in retrievalquery and returns an open, ready to use IDataReader. The datareader's command behavior is set to the
		/// readerBehavior passed in. If a transaction is specified, the command is wired to the transaction.
		/// </summary>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="queryToExecute">The query to execute.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the connection used to open this datareader is also open</remarks>
		IDataReader GetAsDataReader(ITransaction transactionToUse, IRetrievalQuery queryToExecute, CommandBehavior readerBehavior );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is specified, the command is wired to the transaction.
		/// </summary>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the connection used to open this datareader is also open</remarks>
		IDataReader GetAsDataReader( ITransaction transactionToUse, IEntityFields fields, IPredicate filter, IRelationCollection relations, CommandBehavior readerBehavior, 
			int maxNumberOfItemsToReturn, bool allowDuplicates );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is specified, the command is wired to the transaction.
		/// </summary>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the connection used to open this datareader is also open</remarks>
		IDataReader GetAsDataReader( ITransaction transactionToUse, IEntityFields fields, IPredicate filter, IRelationCollection relations, CommandBehavior readerBehavior, 
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is specified, the command is wired to the transaction.
		/// </summary>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the connection used to open this datareader is also open</remarks>
		IDataReader GetAsDataReader( ITransaction transactionToUse, IEntityFields fields, IPredicate filter, IRelationCollection relations, CommandBehavior readerBehavior, 
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, int pageNumber, int pageSize );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is specified, the command is wired to the transaction.
		/// </summary>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the connection used to open this datareader is also open</remarks>
		IDataReader GetAsDataReader( ITransaction transactionToUse, IEntityFields fields, IPredicate filter, IRelationCollection relations, CommandBehavior readerBehavior, 
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, IGroupByCollection groupByClause, bool allowDuplicates, int pageNumber, int pageSize );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is in progress, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, ITransaction transactionToUse, IEntityFields fields,
			IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, bool allowDuplicates );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is specified, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, ITransaction transactionToUse, IEntityFields fields,
			IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is specified, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, ITransaction transactionToUse, IEntityFields fields,
			IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, int pageNumber, int pageSize );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is specified, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, ITransaction transactionToUse, IEntityFields fields,
			IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, ISortExpression sortClauses, IGroupByCollection groupByClause,
			bool allowDuplicates, int pageNumber, int pageSize );
		/// <summary>
		/// Executes the passed in retrievalquery and projects the resultset using the value projectors and the projector specified.
		/// IF a transaction is specified, the command is wired to the transaction and executed inside the transaction. The projection results
		/// will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="transactionToUse">The transaction to use, if you execute this method inside a transcation. Specify null otherwise</param>
		/// <param name="queryToExecute">The query to execute.</param>
		void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, ITransaction transactionToUse, IRetrievalQuery queryToExecute );
		/// <summary>
		/// Projects the current resultset of the passed in datareader using the value projectors and the projector specified. The reader will be left open
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="reader">The reader which points to the first row of a resultset</param>
		/// <remarks>Use this overload together with FetchDataReader if your datareader contains multiple resultsets, so you have fine-grained
		/// control over how you want to project which resultset in the datareader</remarks>
		void GetAsProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, IDataReader reader );
		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into the entity passed in. 
		/// </summary>
		/// <param name="entity">The entity to load the excluded field data into.</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the passed in entity. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.</remarks>
		void FetchExcludedFields(IEntity entity, ITransaction containingTransaction, ExcludeIncludeFieldsList excludedIncludedFields);
		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into all the entities in the entities collection passed in.
		/// </summary>
		/// <param name="entities">The entities to load the excluded field data into. The entities have to be either of the same type or have to be 
		/// in the same inheritance hierarchy as the entity which factory is set in the collection.</param>
		/// <param name="containingTransaction">A containing transaction, if caller is added to a transaction, or null if not.</param>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the passed in collection. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.
		/// This routine batches fetches to have at most 5*ParameterizedThreshold of parameters per fetch. Keep in mind that most databases have a limit
		/// on the # of parameters per query. 
		/// </remarks>
		void FetchExcludedFields(IEntityCollection entities, ITransaction containingTransaction, ExcludeIncludeFieldsList excludedIncludedFields);

		/// <summary>
		/// Gets / sets entityFactory to use
		/// </summary>
		IEntityFactory EntityFactoryToUse { get; set;}
	}


	/// <summary>
	/// Interface for the EntityCollection type. The collection defines typed basic collection behavior. 
	/// Selfservicing specific
	/// </summary>
	public interface IEntityCollection : IEnumerable
	{
		/// <summary>
		/// Event which is raised at the start of the Remove or RemoveAt(index) routine. To cancel the remove action, set cancel to true.
		/// </summary>
		event EventHandler<CancelableCollectionChangedEventArgs> EntityRemoving;
		/// <summary>
		/// Event which is raised at the End of the Remove or RemoveAt(index) routine.
		/// </summary>
		event EventHandler<CollectionChangedEventArgs> EntityRemoved;
		/// <summary>
		/// Event which is raised at the start of the Add or Insert(index) routine. To cancel the addition action, set cancel to true.
		/// </summary>
		event EventHandler<CancelableCollectionChangedEventArgs> EntityAdding;
		/// <summary>
		/// Event which is raised at the End of the Add or Insert(index) routine.
		/// </summary>
		event EventHandler<CollectionChangedEventArgs> EntityAdded;
		/// <summary>
		/// Event which is raised when the collection changed: an item changed, an item was removed, added, or the collection was cleared. 
		/// If possible, use one of the Entity* events of this collection.
		/// </summary>
		event ListChangedEventHandler ListChanged;

		/// <summary>
		/// Adds an IEntity object to the list.
		/// </summary>
		/// <param name="entityToAdd">Entity to add</param>
		/// <returns>Index in list</returns>
		int Add(IEntity entityToAdd);
		/// <summary>
		/// Adds the range of objects passed in. Objects have to be IEntity implementing objects
		/// </summary>
		/// <param name="c">Collection to add</param>
		void AddRange(IEntityCollection c);
		/// <summary>
		/// Inserts an IEntity on position Index
		/// </summary>
		/// <param name="index">Index where to insert the Object Entity</param>
		/// <param name="entityToAdd">Entity to insert</param>
		void Insert(int index, IEntity entityToAdd);
		/// <summary>
		/// Remove given IEntity from the list.
		/// </summary>
		/// <param name="entityToRemove">Entity object to remove from list.</param>
		void Remove(IEntity entityToRemove);
		/// <summary>
		/// Removes the IEntity instance at the index given.
		/// </summary>
		/// <param name="index">Index in list to remove the element.</param>
		void RemoveAt( int index );
		/// <summary>
		/// Returns true if the list contains the given IEntity Object
		/// </summary>
		/// <param name="entityToFind">Entity object to check.</param>
		/// <returns>true if Entity exists in list.</returns>
		bool Contains(IEntity entityToFind);
		/// <summary>
		/// Returns index in the list of given IEntity object.
		/// </summary>
		/// <param name="entityToFind">Entity Object to check</param>
		/// <returns>index in list.</returns>
		int IndexOf(IEntity entityToFind);
		/// <summary>
		/// Clears the collection.
		/// </summary>
		void Clear();
		/// <summary>
		/// copy the complete list of IEntity objects to an array of IEntity objects.
		/// </summary>
		/// <param name="destination">Array of IEntity Objects wherein the contents of the list will be copied.</param>
		/// <param name="index">Start index to copy from</param>
		void CopyTo(IEntity[] destination, int index);
		/// <summary>
		/// Sets the entity information of the entity object containing this collection. Call this method only from
		/// entity classes which contain IEntityCollection members, like 'Customer' which contains 'Orders' entity collection.
		/// </summary>
		/// <param name="containingEntity">The entity containing this entity collection as a member variable</param>
		/// <param name="fieldName">The field the containing entity has mapped onto the relation which delivers the entities contained
		/// in this collection</param>
		void SetContainingEntityInfo(IEntity containingEntity, string fieldName);
		/// <summary>
		/// Saves all new/dirty Entities in the IEntityCollection in the persistent storage. If this IEntityCollection is added
		/// to a transaction, the save processes will be done in that transaction, if the entity isn't already added to another transaction.
		/// If the entity is already in another transaction, it will use that transaction. If no transaction is present, the saves are done in a
		/// new Transaction (which is created in an inherited method.). Will not recursively save entities inside the collection.
		/// </summary>
		/// <returns>Amount of entities inserted</returns>
		/// <remarks>All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.</remarks>
		int SaveMulti();
		/// <summary>
		/// Saves all new/dirty Entities in the IEntityCollection in the persistent storage. If this IEntityCollection is added
		/// to a transaction, the save processes will be done in that transaction, if the entity isn't already added to another transaction.
		/// If the entity is already in another transaction, it will use that transaction. If no transaction is present, the saves are done in a
		/// new Transaction (which is created in an inherited method.)
		/// </summary>
		/// <param name="recurse">If true, will recursively save the entities inside the collection</param>
		/// <returns>Amount of entities inserted</returns>
		/// <remarks>All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.</remarks>
		int SaveMulti(bool recurse);
		/// <summary>
		/// Deletes all Entities in the IEntityCollection from the persistent storage. If this IEntityCollection is added
		/// to a transaction, the delete processes will be done in that transaction, if the entity isn't already added to another transaction.
		/// If the entity is already in another transaction, it will use that transaction. If no transaction is present, the deletes are done in a
		/// new Transaction (which is created in an inherited method.)
		/// Deleted entities are marked deleted and are removed from the collection.
		/// </summary>
		/// <returns>Amount of entities deleted</returns>
		/// <remarks>All exceptions will be bubbled upwards so transaction code can anticipate on exceptions.</remarks>
		int DeleteMulti();
		/// <summary>
		/// Converts this entity collection to XML, recursively. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml(out string entityCollectionXml);
		/// <summary>
		/// Converts this entity collection to XML. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		void WriteXml(XmlDocument parentDocument, out XmlNode entityCollectionNode);
		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml(string rootNodeName, out string entityCollectionXml);
		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		void WriteXml(string rootNodeName, XmlDocument parentDocument, out XmlNode entityCollectionNode);
		/// <summary>
		/// Converts this entity collection to XML, recursively. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml(XmlFormatAspect aspects, out string entityCollectionXml);
		/// <summary>
		/// Converts this entity collection to XML. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		void WriteXml( XmlFormatAspect aspects, XmlDocument parentDocument, out XmlNode entityCollectionNode );
		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml( XmlFormatAspect aspects, string rootNodeName, out string entityCollectionXml );
		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		void WriteXml( XmlFormatAspect aspects, string rootNodeName, XmlDocument parentDocument, out XmlNode entityCollectionNode );
		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element
		/// of the entity collection's Xml data</param>
		void ReadXml(XmlNode node);
		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="xmlData">string with Xml data which should be read into this entity collection and its members. This string has to be in the
		/// correct format and should be loadable into a new XmlDocument without problems</param>
		void ReadXml(string xmlData);
		/// <summary>
		/// Applies sorting like IBindingList.ApplySort, on the field with the index fieldIndex and with the direction specified.
		/// </summary>
		/// <param name="fieldIndex">Field to sort on</param>
		/// <param name="direction">the sort direction</param>
		void Sort(int fieldIndex, ListSortDirection direction);
		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="fieldIndex">Field to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		void Sort(int fieldIndex, ListSortDirection direction, IComparer<object> comparerToUse);
		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="propertyName">property to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		void Sort(string propertyName, ListSortDirection direction, IComparer<object> comparerToUse);
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( IPredicate selectFilter );
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn );
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti(IPredicate selectFilter, ExcludeIncludeFieldsList excludedIncludedFields, long maxNumberOfItemsToReturn);
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses );
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( IPredicate selectFilter, IRelationCollection relations );
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations );
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( IPredicate selectFilter, IPrefetchPath prefetchPathToUse );
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve. When set to null all entities will be retrieved (no filtering is being performed)</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti(IPredicate selectFilter, ExcludeIncludeFieldsList excludedIncludedFields, IPrefetchPath prefetchPathToUse);
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, int pageNumber, int pageSize );
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, IPrefetchPath prefetchPathToUse );
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti( IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations, 
			IPrefetchPath prefetchPathToUse, int pageNumber, int pageSize );
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="prefetchPathToUse">the PrefetchPath which defines the graph of objects to fetch.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool GetMulti(IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relations,
			IPrefetchPath prefetchPathToUse, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize);
		/// <summary>
		/// Gets all indices of all the entities in the current order of this collection which match the passed in filter. 
		/// </summary>
		/// <param name="filter">The filter the entity has to match with. If null, all entities match and every index is returned</param>
		/// <returns>List of indices of all entities matching the filter</returns>
		List<int> FindMatches( IPredicate filter );
		/// <summary> Gets the amount of Entity objects in the database.</summary>
		/// <returns>the amount of objects found</returns>
		int GetDbCount();
		/// <summary> Gets the amount of Entity objects in the database, when taking into account the filter specified.</summary>
		/// <param name="filter">the filter to apply</param>
		/// <returns>the amount of objects found</returns>
		int GetDbCount(IPredicate filter);
		/// <summary> Gets the amount of Entity objects in the database, when taking into account the filter specified and the relations specified.</summary>
		/// <param name="filter">the filter to apply</param>
		/// <param name="relations">The relations to walk</param>
		/// <returns>the amount of objects found</returns>
		int GetDbCount( IPredicate filter, IRelationCollection relations );
		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in 
		/// this collection. Per entity type found, a new datatable is created inside destination. It will simply project every data element. 
		/// </summary>
		/// <param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
		/// e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void CreateHierarchicalProjection(DataSet destination);
		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in this collection,
		/// using the collectionProjections data passed in. Per entity type found, a new datatable is created inside destination.
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
		/// e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, DataSet destination);
		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in 
		/// this collection. Per entity type found, an entry is stored inside the destination dictionary. It will simply project every data element. 
		/// </summary>
		/// <param name="destination">The destination dictionary in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void CreateHierarchicalProjection(Dictionary<Type, IEntityCollection> destination);
		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in this collection,
		/// using the collectionProjections data passed in. Per entity type found, an entry is stored inside the destination dictionary. 
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dictionary in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, Dictionary<Type, IEntityCollection> destination);
		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with no filter nor sorter applied.
		/// </summary>
		/// <returns>new EntityView on this collection</returns>
		IEntityView CreateView();
		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with the passed in filter applied
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns>new EntityView on this collection</returns>
		IEntityView CreateView(IPredicate filter);
		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with the passed in filter and sorter applied to it.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <returns>new EntityView on this collection</returns>
		IEntityView CreateView(IPredicate filter, ISortExpression sorter);
		/// <summary>
		/// Creates a new EntityView object of the right type on this collection with the passed in filter and sorter applied to it and the 
		/// dataChangeAction set to the passed in value.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="dataChangeAction">The data change action to take if data in the related collection changes.</param>
		/// <returns>new EntityView on this collection</returns>
		IEntityView CreateView(IPredicate filter, ISortExpression sorter, PostCollectionChangeAction dataChangeAction);
		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into all the entities in this collection.
		/// </summary>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the passed in collection. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.
		/// This routine batches fetches to have at most 5*DaoBase.ParameterisedPrefetchPathThreshold of parameters per fetch. Keep in mind 
		/// that most databases have a limit on the # of parameters per query. 
		/// </remarks>
		void FetchExcludedFields(ExcludeIncludeFieldsList excludedIncludedFields);

		/// <summary>
		/// Gets the default view for this entitycollection. The returned value is the same instance every time this property is read. 
		/// It's a new entity view without a filter or a sorter.
		/// </summary>
		/// <value>The default view.</value>
		IEntityView DefaultView { get;}
		/// <summary>
		/// Returns a readonly collection of entities which are flagged as dirty. 
		/// This collection is determined on the fly, you can use this collection to remove dirty entities from this entity collection.
		/// </summary>
		List<IEntity> DirtyEntities { get;}
		/// <summary>
		/// The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.
		/// </summary>
		long MaxNumberOfItemsToReturn {get; set;}
		/// <summary>
		/// The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.
		/// </summary>
		ISortExpression SortClauses {get; set;}
		/// <summary>
		/// Returns true if this collection contains dirty objects. If this collection contains dirty objects, an 
		/// already filled collection should not be refreshed until a save is performed. This property is calculated in real time
		/// and can be time consuming when the collection contains a lot of objects. Use this property only in cases when the value
		/// of this property is used to do a refetch or not.
		/// </summary>
		bool ContainsDirtyContents {get;}
		/// <summary>
		/// The EntityFactory to use when creating entity objects during a GetMulti() call or other logic which requires the creation of new entities.
		/// </summary>
		IEntityFactory EntityFactoryToUse {get; set;}
		/// <summary>
		/// Surpresses the removal of all contents of the collection in a GetMulti*() call. Used by code in related entities to prevent the removal
		/// of objects when collection properties are accessed.
		/// </summary>
		bool SuppressClearInGetMulti {get; set;}
		/// <summary>
		/// The amount of IEntity elements in this entity collection
		/// </summary>
		int Count {get;}
		/// <summary>
		/// Gets / sets the active context this entity collection is in. Setting this property is not adding the entity collection to the context, 
		/// it will make contained entities be added to the passed in context. If the entity collection is already in a context, setting this property has no effect. 
		/// Setting this property is done by framework code, use the Context's Add/Get methods to work with contexts and entity collections.
		/// </summary>
		Context ActiveContext { get; set; }
		/// <summary>
		/// Gets / sets the IConcurrencyPredicateFactory instance to use when creating entity objects during a GetMulti() call or when AddNew is called.
		/// </summary>
		IConcurrencyPredicateFactory ConcurrencyPredicateFactoryToUse { get; set;}
		/// <summary>
		/// Gets or sets the <see cref="IEntity"/> at the specified index.
		/// </summary>
		/// <value></value>
		IEntity this[int index] {get; set;}
		/// <summary>
		/// Default: true. If set to false, no new entities will be added through databinding. 
		/// </summary>
		bool AllowNew { get; set;}
		/// <summary>
		/// Default: false. If set to true, entities can be removed through databinding.
		/// </summary>
		bool AllowRemove { get; set;}
		/// <summary>
		/// Default: true. If set to false, entities inside this collection won't be editable in a complex databinding scenario.
		/// </summary>
		bool AllowEdit { get; set;}
		/// <summary>
		/// Get / set the readonly flag for this collection. 
		/// </summary>
		bool IsReadOnly { get; set;}
		/// <summary>
		/// When set to true, an entity passed to Add() or Insert() will be tested if it's already present. If so, the index is returned and the
		/// object is not added again. If set to false (default: true) this check is not performed. Setting this property to true can slow down fetch logic.
		/// DataAccessAdapter's fetch logic sets this property to false during a multi-entity fetch.
		/// </summary>
		bool DoNotPerformAddIfPresent { get; set;}
		/// <summary>
		/// Gets / sets the initial capacity of the entity collection. 
		/// </summary>
		int Capacity { get; set;}
		/// <summary>
		/// Gets or sets the entity collection which should be used as removed entities tracker. If this property is set to an IEntityCollection2 instance,
		/// all entities which are removed from this collection are marked for deletion and placed in this removed entities tracker collection.
		/// This collection can then later on be used to delete these entities from the database in one go.
		/// </summary>
		IEntityCollection RemovedEntitiesTracker { get; set;}
	}


	/// <summary>
	/// Interface for EntityFactory objects used by several methods which have to create entity objects on the fly.
	/// SelfServicing specific
	/// </summary>
#if !CF && !MONO
	[TypeConverter(typeof(EntityFactoryConverter))]
#endif
	public interface IEntityFactory : IEntityFactoryCore
	{
		/// <summary>
		/// Creates a new <see cref="IEntity"/> instance 
		/// </summary>
		/// <returns>the new IEntity instance</returns>
		IEntity Create();
		/// <summary>
		/// Creates a new <see cref="IEntity"/> instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.
		/// </summary>
		/// <param name="fields">Populated IEntityFields object for the new entity to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields object) IEntity object</returns>
		IEntity Create(IEntityFields fields);
		/// <summary>
		/// Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used
		/// by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		IEntityFields CreateFields();
		/// <summary>
		/// Creates the hierarchy fields for the entity to which this factory belongs.
		/// </summary>
		/// <returns>IEntityFields object with the fields of all the entities in the hierarchy of this entity or the fields of this entity if
		/// the entity isn't in a hierarchy.</returns>
		IEntityFields CreateHierarchyFields();
		/// <summary>
		/// This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.
		/// </summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns></returns>
		IEntityFactory GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity);
		/// <summary>
		/// Creates a new entity collection for the entity of this factory.
		/// </summary>
		/// <returns>ready to use new entity collection, typed.</returns>
		IEntityCollection CreateEntityCollection();
		/// <summary>
		/// Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value
		/// </summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		IEntity CreateEntityFromEntityTypeValue(int entityTypeValue);
	}

	
	/// <summary>
	/// interface for the factory which creates different sets of property descriptor sets. Required for complex databinding. 
	/// Selfservicing specific.
	/// </summary>
	public interface IPropertyDescriptorFactory
	{
		/// <summary>
		/// Creates a new propertydescriptorcollection using the specialized methods of the types stored INSIDE the type specified.
		/// </summary>
		/// <param name="typeOfCollection">type which contains other types which properties we're interested in.</param>
		/// <returns>filled propertydescriptorcollection of type inside the type specified.</returns>
		PropertyDescriptorCollection GetItemProperties(Type typeOfCollection);
		/// <summary>
		/// Constructs the actual property descriptor collection.
		/// </summary>
		/// <param name="entityToCheck">entity instance which properties should be included in the collection</param>
		/// <param name="typeOfEntity">full type of the entity</param>
		/// <returns>filled in property descriptor collection</returns>
		PropertyDescriptorCollection GetPropertyDescriptors(IEntity entityToCheck, Type typeOfEntity);
	}


	/// <summary>
	/// Interface for TypedView classes. 
	/// Selfservicing specific.
	/// </summary>
	public interface ITypedView
	{
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query. 
		/// Will use no sort filter, no select filter, will allow duplicate rows and will not limit the amount of rows returned
		/// </summary>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill();
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query. 
		/// Will not use a filter, will allow duplicate rows.
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses);
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query. 
		/// Will not use a filter.
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates);
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate expression to filter on the rows inserted in this TypedView object.</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter);
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate expression to filter on the rows inserted in this TypedView object.</param>
		/// <param name="transactionToUse">The transaction object to use. Can be null. If specified, the connection object of the transaction is
		/// used to fill the TypedView, which avoids deadlocks on SqlServer.</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter, ITransaction transactionToUse);
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate expression to filter on the rows inserted in this TypedView object.</param>
		/// <param name="transactionToUse">The transaction object to use. Can be null. If specified, the connection object of the transaction is
		/// used to fill the TypedView, which avoids deadlocks on SqlServer.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on.</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter, ITransaction transactionToUse, 
				IGroupByCollection groupByClause);
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate expression to filter on the rows inserted in this TypedView object.</param>
		/// <param name="transactionToUse">The transaction object to use. Can be null. If specified, the connection object of the transaction is
		/// used to fill the TypedView, which avoids deadlocks on SqlServer.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on.</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter, ITransaction transactionToUse, 
				IGroupByCollection groupByClause, int pageNumber, int pageSize);
		/// <summary>
		/// Gets the amount of rows in the database for this typed view, not skipping duplicates
		/// </summary>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		int GetDbCount();
		/// <summary>
		/// Gets the amount of rows in the database for this typed view.
		/// </summary>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		int GetDbCount(bool allowDuplicates);
		/// <summary>
		/// Gets the amount of rows in the database for this typed view.
		/// </summary>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="filter">The filter to apply for the count retrieval</param>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		int GetDbCount(bool allowDuplicates, IPredicateExpression filter);
		/// <summary>
		/// Gets the amount of rows in the database for this typed view.
		/// </summary>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="filter">The filter to apply for the count retrieval</param>
		/// <param name="groupByClause">group by clause to embed in the query</param>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		int GetDbCount(bool allowDuplicates, IPredicateExpression filter, GroupByCollection groupByClause);
		/// <summary>
		/// Gets the fields of this typed view
		/// </summary>
		/// <returns>IEntityFields object</returns>
		IEntityFields GetFields();
		/// <summary>
		/// Returns the amount of rows in this typed view.
		/// </summary>
		int Count {get; }
	}


	/// <summary>
	/// Interface for TypedList classes. ITypedList is already defined in .NET, that's why it is suffixed with Lgp.
	/// Selfservicing specific.
	/// </summary>
	public interface ITypedListLgp : ITypedListCore
	{
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query. 
		/// Will use no sort filter, no select filter, will allow duplicate rows and will not limit the amount of rows returned
		/// </summary>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill();
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query. 
		/// Will not use a filter, will allow duplicate rows.
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses);
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query. 
		/// Will not use a filter.
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates);
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate which is used to filter the rows to insert in this Typed List instance</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter);
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate which is used to filter the rows to insert in this Typed List instance</param>
		/// <param name="transactionToUse">The transaction object to use. Can be null. If specified, the connection object of the transaction is
		/// used to fill the TypedView, which avoids deadlocks on SqlServer.</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter, ITransaction transactionToUse);
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate which is used to filter the rows to insert in this Typed List instance</param>
		/// <param name="transactionToUse">The transaction object to use. Can be null. If specified, the connection object of the transaction is
		/// used to fill the TypedView, which avoids deadlocks on SqlServer.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on.</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter, ITransaction transactionToUse, 
				IGroupByCollection groupByClause);
		/// <summary>
		/// Fills itself with data. it builds a dynamic query and loads itself with that query, using the specified filter
		/// </summary>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. specifying 0 means all rows are returned</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When null is specified, no sorting is applied.</param>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="selectFilter">Predicate which is used to filter the rows to insert in this Typed List instance</param>
		/// <param name="transactionToUse">The transaction object to use. Can be null. If specified, the connection object of the transaction is
		/// used to fill the TypedView, which avoids deadlocks on SqlServer.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on.</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <returns>true if fill succeeded, false otherwise</returns>
		bool Fill(long maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IPredicate selectFilter, ITransaction transactionToUse, 
				IGroupByCollection groupByClause, int pageNumber, int pageSize);
		/// <summary>
		/// Gets the amount of rows in the database for this typed list, not skipping duplicates
		/// </summary>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		int GetDbCount();
		/// <summary>
		/// Gets the amount of rows in the database for this typed list.
		/// </summary>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		int GetDbCount(bool allowDuplicates);
		/// <summary>
		/// Gets the amount of rows in the database for this typed list.
		/// </summary>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="filter">The filter to apply for the count retrieval</param>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		int GetDbCount(bool allowDuplicates, IPredicateExpression filter);
		/// <summary>
		/// Gets the amount of rows in the database for this typed list.
		/// </summary>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="filter">The filter to apply for the count retrieval</param>
		/// <param name="relations">The relations for the filter to apply</param>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		int GetDbCount(bool allowDuplicates, IPredicateExpression filter, IRelationCollection relations);
		/// <summary>
		/// Gets the amount of rows in the database for this typed list.
		/// </summary>
		/// <param name="allowDuplicates">Flag to allow duplicate rows (true) or not (false)</param>
		/// <param name="filter">The filter to apply for the count retrieval</param>
		/// <param name="relations">The relations for the filter to apply</param>
		/// <param name="groupByClause">group by clause to embed in the query</param>
		/// <returns>the number of rows in the set defined by the passed in query elements</returns>
		int GetDbCount(bool allowDuplicates, IPredicateExpression filter, IRelationCollection relations, GroupByCollection groupByClause);
		/// <summary>
		/// Builds the resultset fields.
		/// </summary>
		/// <returns>ready to use resultset</returns>
		IEntityFields BuildResultset();
		/// <summary>
		/// Builds the relation set for this typed list.
		/// </summary>
		/// <returns>ready to use relation set</returns>
		IRelationCollection BuildRelationSet();
	}


	/// <summary>
	/// General interface to access common properties of an EntityView(Of TEntity) without knowing the type of TEntity.
	/// </summary>
	public interface IEntityView : IEnumerable
	{
		/// <summary>
		/// Event which is fired when the entity collection related to this entityview is changed.
		/// </summary>
		event ListChangedEventHandler ListChanged;

		/// <summary>
		/// Determines whether this entity view contains the entity passed in. This method returns false if the entity is outside the filter, but in the related
		/// entity collection, as it's then not contained in the entity view.
		/// </summary>
		/// <param name="value">The entity to check</param>
		/// <returns>True if the entity is present, otherwise false.</returns>
		bool Contains( IEntity value );
		/// <summary>
		/// Determines the index of the entity passed in in the entity view in filtered and sorted state.
		/// </summary>
		/// <param name="value">The entity to get the index of.</param>
		/// <returns>Index of the entity in this entityview</returns>
		int IndexOf( IEntity value );
		/// <summary>
		/// Copies all entities in this view to a new entity collection and returns that collection. The returned collection is of
		/// the same type as the related collection. Entities aren't copied, just references to the entities.
		/// </summary>
		/// <returns>New collection with all entities in this view</returns>
		IEntityCollection ToEntityCollection();
		/// <summary>
		/// Copies all entities starting at startIndex in this view to a new entity collection and returns that collection. The returned collection is of
		/// the same type as the related collection. Entities aren't copied, just references to the entities.
		/// </summary>
		/// <param name="startIndex">The start index for the interval to copy to the entity collection</param>
		/// <returns>
		/// New collection with all entities in this view
		/// </returns>
		IEntityCollection ToEntityCollection(int startIndex);
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, DataTable destination );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, DataTable destination, bool allowDuplicates );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, DataTable destination, bool allowDuplicates, IPredicate filter );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityCollection destination );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection  using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityCollection destination, bool allowDuplicates );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection  using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityCollection destination, bool allowDuplicates, IPredicate filter );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the project does with the data is up to the projector.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the project does with the data is up to the projector.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector, bool allowDuplicates );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the project does with the data is up to the projector.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector, bool allowDuplicates, IPredicate filter );

		/// <summary>
		/// Gets or sets the sorter for this entity view. Setting this property will re-sort the view and will reset the view in databinding scenario's.
		/// </summary>
		/// <value>The sort expression to use.</value>
		ISortExpression Sorter { get; set;}
		/// <summary>
		/// Gets or sets the filter to use for this entity view.
		/// </summary>
		/// <value>The filter to use</value>
		IPredicate Filter { get; set;}
		/// <summary>
		/// Gets the count of the view.
		/// </summary>
		/// <value>The count.</value>
		int Count { get;}
		/// <summary>
		/// Gets the <see cref="IEntity"/> at the specified index in the view
		/// </summary>
		/// <value></value>
		IEntity this[int index] { get;}
		/// <summary>
		/// Gets/sets whether you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>; otherwise, false.</returns>
		/// <remarks>if the related collection is set to readonly, this operation is a no-op</remarks>
		bool AllowNew { get; set;}
		/// <summary>
		/// Gets whether you can remove items from the list, using <see cref="M:System.Collections.IList.Remove(System.Object)"></see> or <see cref="M:System.Collections.IList.RemoveAt(System.Int32)"></see>.
		/// </summary>
		/// <value></value>
		/// <remarks>if the related collection is set to readonly, this operation is a no-op</remarks>
		bool AllowEdit { get; set; }
		/// <summary>
		/// Gets / sets whether you can update items in the list.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can update the items in the list; otherwise, false.</returns>
		/// <remarks>if the related collection is set to readonly, this operation is a no-op</remarks>
		bool AllowRemove { get; set;}
		/// <summary>
		/// Gets the related collection set for this view.
		/// </summary>
		/// <value>The related collection.</value>
		IEntityCollection RelatedCollection { get; }
		/// <summary>
		/// Gets or sets the data change action which specifies what to do when the data in the related collection of an entity view changes. A change in 
		/// data can be: entity added or changed. If an entity is removed from the underlying collection, the entity is simply removed from the entity 
		/// view, as the view doesn't contain any data by itself.
		/// </summary>
		/// <value>The data change action.</value>
		PostCollectionChangeAction DataChangeAction { get; set;}
	}


	/// <summary>
	/// Internal interface for entity collection method access when the type of the collection isn't known.
	/// </summary>
	internal interface IEntityCollectionAccess : ICollectionMaintenance
	{
		/// <summary>
		/// Produces the actual XML for this entity collection, recursively. Because it recurses through contained entities, 
		/// it keeps track of which objects are processed so cyclic references are not resulting in cyclic recursion and thus a crash. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="processedObjectIDs">Hashtable with ObjectIDs of all the objects already processed. If an entity's ObjectID is in the
		/// hashtable's key list, a ProcessedObjectReference tag is emitted and the entity will not recurse further. </param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		void EntityCollection2Xml( string rootNodeName, XmlDocument parentDocument, Dictionary<Guid, IEntity> processedObjectIDs,
				XmlFormatAspect aspects, out XmlNode entityCollectionNode );
		/// <summary>
		/// Performs the actual conversion from Xml to entity collection data. 
		/// </summary>
		/// <param name="node">current node which points to an entity collection node.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">list with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		void Xml2EntityCollection( XmlNode node, Dictionary<Guid, IEntity> processedObjectIDs, List<NodeEntityReference> nodeEntityReferences );
		/// <summary>
		/// Gets the cached pk hashes, if available, otherwise null
		/// </summary>
		/// <returns></returns>
		Dictionary<int, List<IEntity>> GetCachedPkHashes();
		/// <summary>
		/// Sets the cached pk hashes to the passed dictionary
		/// </summary>
		/// <param name="pkHashes">The pk hashes.</param>
		void SetCachedPkHashes( Dictionary<int, List<IEntity>> pkHashes );
		/// <summary> Retrieves in this Collection object all Entity objects which match with the specified filter, formulated in the predicate or predicate expression definition, using the passed in relations to construct the total query.</summary>
		/// <param name="selectFilter">A predicate or predicate expression which should be used as filter for the entities to retrieve.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relations">The set of relations to walk to construct the total query.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">The page number to retrieve.</param>
		/// <param name="pageSize">The page size of the page to retrieve.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		/// <remarks>special version which is used by prefetch path code, and which modifies the relation collection and filter for hierarchical fetches</remarks>
		bool GetMultiInternal( ref IPredicateExpression selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, ref IRelationCollection relations,
				ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize);
	}



	#endregion

	#region Adapter specific interfaces
	/// <summary>
	/// Interface definition for the PrefetchPathElement2 type, which instances are used in a PrefetchPath2 instance.
	/// Adapter specific
	/// </summary>
	public interface IPrefetchPathElement2: IPrefetchPathElementCore
	{
		/// <summary>
		/// The subpath containing path elements to retrieve in the ToFetch entity of this PrefetchPathElement. Can be empty.
		/// </summary>
		IPrefetchPath2 SubPath {get; set;}
		/// <summary>
		/// The entity collection to fill (and to use to retrieve the entities to fetch). After the fetch, this collection contains
		/// the entities to merge with the instances of the parent entity. 
		/// </summary>
		IEntityCollection2 RetrievalCollection {get;}
		/// <summary>
		/// The factory to use during the fetch of the entities defined by this path element. If this property is not set, the entity factory
		/// in the RetrievalCollection is used. Use this property to override the default factory, 
		/// </summary>
		IEntityFactory2 EntityFactoryToUse {get; set;}
	}


	/// <summary>
	/// Interface definition for the PrefetchPath2 type, which specifies a prefetch path to fetch related entities during a fetch.
	/// Adapter specific.
	/// </summary>
	public interface IPrefetchPath2
	{
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement2 Add(IPrefetchPathElement2 elementToAdd);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		IPrefetchPathElement2 Add(IPrefetchPathElement2 elementToAdd, ExcludeIncludeFieldsList excludedIncludedFields);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="entityFactoryToUse">The entity factory to use to produce the related entities.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement2 Add(IPrefetchPathElement2 elementToAdd, IEntityFactory2 entityFactoryToUse);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement2 Add(IPrefetchPathElement2 elementToAdd, int maxAmountOfItemsToReturn);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement2 Add(IPrefetchPathElement2 elementToAdd, int maxAmountOfItemsToReturn, IPredicateExpression additionalFilter);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <param name="entityFactoryToUse">The entity factory to use to produce the related entities.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement2 Add(IPrefetchPathElement2 elementToAdd, int maxAmountOfItemsToReturn, 
				IPredicateExpression additionalFilter, IEntityFactory2 entityFactoryToUse);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <param name="additionalFilterRelations">Additional relations to be added to the relationcollection already in the PrefetchPathElement</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement2 Add(IPrefetchPathElement2 elementToAdd, int maxAmountOfItemsToReturn, 
				IPredicateExpression additionalFilter, IRelationCollection additionalFilterRelations);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <param name="additionalFilterRelations">Additional relations to be added to the relationcollection already in the PrefetchPathElement</param>
		/// <param name="entityFactoryToUse">The entity factory to use to produce the related entities.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement2 Add(IPrefetchPathElement2 elementToAdd, int maxAmountOfItemsToReturn, 
			IPredicateExpression additionalFilter, IRelationCollection additionalFilterRelations, IEntityFactory2 entityFactoryToUse);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <param name="additionalFilterRelations">Additional relations to be added to the relationcollection already in the PrefetchPathElement</param>
		/// <param name="additionalSorter">Additional sort clauses to be added added to the sortexpression already in the PrefetchPathElement</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement2 Add(IPrefetchPathElement2 elementToAdd, int maxAmountOfItemsToReturn, 
			IPredicateExpression additionalFilter, IRelationCollection additionalFilterRelations, ISortExpression additionalSorter);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <param name="additionalFilterRelations">Additional relations to be added to the relationcollection already in the PrefetchPathElement</param>
		/// <param name="additionalSorter">Additional sort clauses to be added added to the sortexpression already in the PrefetchPathElement</param>
		/// <param name="entityFactoryToUse">The entity factory to use to produce the related entities.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When elementToAdd is not specifying a fetch meant for an entity of type rootEntityType set in the
		/// constructor of this class</exception>
		IPrefetchPathElement2 Add(IPrefetchPathElement2 elementToAdd, int maxAmountOfItemsToReturn, IPredicateExpression additionalFilter, 
				IRelationCollection additionalFilterRelations, ISortExpression additionalSorter, IEntityFactory2 entityFactoryToUse);
		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <param name="additionalFilterRelations">Additional relations to be added to the relationcollection already in the PrefetchPathElement</param>
		/// <param name="additionalSorter">Additional sort clauses to be added added to the sortexpression already in the PrefetchPathElement</param>
		/// <param name="entityFactoryToUse">The entity factory to use to produce the related entities.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When the elementToAdd is a node definition which is already added to this path.</exception>
		IPrefetchPathElement2 Add(IPrefetchPathElement2 elementToAdd, int maxAmountOfItemsToReturn, IPredicateExpression additionalFilter,
			IRelationCollection additionalFilterRelations, ISortExpression additionalSorter, IEntityFactory2 entityFactoryToUse,
			ExcludeIncludeFieldsList excludedIncludedFields);

		/// <summary>
		/// Indexer in the prefetch path
		/// </summary>
		IPrefetchPathElement2 this[int index] {get; set; }
		/// <summary>
		/// The EntityType enum value for the entity which is the root type of this path.
		/// </summary>
		/// <remarks>Set in the constructor</remarks>
		int	RootEntityType { get; }
		/// <summary>
		/// Returns the amount of PrefetchPathElement2 in this object
		/// </summary>
		int Count {get;}
	}

	
	/// <summary>
	/// Interface for the EntityField2 type. An EntityField2 is the unit which is used to hold the value for a given property of an entity.
	/// Adapter specific.
	/// </summary>
	public interface IEntityField2 : IEntityFieldCore
	{
		/// <summary>
		/// Sets the entity field's ObjectAlias property to the specified value
		/// </summary>
		/// <param name="objectAlias">value to set</param>
		/// <returns>The entity field object the method was called on, for command chaining</returns>
		EntityField2 SetObjectAlias(string objectAlias);
		/// <summary>
		/// Sets the EntityField's AggregateFunctionToApply property
		/// </summary>
		/// <param name="functionToToApply">Function to apply.</param>
		/// <returns>The entity field object the method was called on, for command chaining</returns>
		EntityField2 SetAggregateFunction(AggregateFunction functionToToApply);
		/// <summary>
		/// Sets the Entity Field's ExpressionToToApply property
		/// </summary>
		/// <param name="expressionToToApply">Expression to to apply.</param>
		/// <returns>The entity field object the method was called on, for command chaining</returns>
		EntityField2 SetExpression(IExpression expressionToToApply);
		/// <summary>
		/// Sets the field alias.
		/// </summary>
		/// <param name="fieldAlias">The field alias.</param>
		/// <returns>The entity field object the method was called on, for command chaining</returns>
		EntityField2 SetFieldAlias( string fieldAlias );
	}


	/// <summary>
	/// Interface for the EntityFields2 type. An EntityFields2 type is a collection of IEntityField2 objects which forms the total amount of 
	/// fields for a given entity.
	/// Adapter specific
	/// </summary>
	public interface IEntityFields2 : IEditableObject, IEnumerable
	{
		/// <summary>
		/// Expands this entity fields object by appending numberOfCells new cells to this object. 
		/// </summary>
		/// <param name="numberOfNewCells">number of cells to append to this fieldsobject</param>
		/// <remarks>Use with care. Empty cells can cause the DQE's to produce undefined results. Use this routine to append fields to a
		/// Typed list in code for example. </remarks>
		void Expand( int numberOfNewCells );
		/// <summary>
		/// Contracts the list of fields so all empty slots at the end of the list of fields are removed. Doesn't perform a contract operation if the
		/// fields object is empty
		/// </summary>
		/// <returns>the new size of the fields object, or if the fields object is completely empty, the full size</returns>
		int Contract();
		/// <summary>
		/// Compacts the list of fields so all empty slots are removed. 
		/// </summary>
		void Compact();
		/// <summary>
		/// Clones this instance and its contents using a deep copy.
		/// </summary>
		/// <returns>an exact, deep copy of this EntityFields object and its contents.</returns>
		EntityFields2 Clone();
		/// <summary>
		/// Creates a shallow copy of this instance, which means that a new EntityFields2 object is created but all membervariables are kept the same. 
		/// </summary>
		/// <returns>Shallow copy of this instance</returns>
		EntityFields2 ShallowClone();
		/// <summary>
		/// Clones this object to a new EntityFields object where all fields are changed and the object itself is marked dirty.
		/// </summary>
		/// <returns></returns>
		EntityFields2 CloneAsDirty();
		/// <summary>
		/// Overrides the GetHashCode routine. It will calculate a hashcode for this set of entity fields using the eXclusive OR of the 
		/// hashcodes of the primary key fields in this set of entity fields. That hashcode is returned. If no primary key fields are present,
		/// the hashcode of the base class is returned, which will not be unique.
		/// </summary>
		/// <returns>Hashcode for this entity object, based on its primary key field values</returns>
		int GetHashCode();
		/// <summary>
		/// Returns the complete list of IEntityField objects as an array of IEntityFieldCore objects. IEntityField objects implement
		/// IEntityFieldCore
		/// </summary>
		/// <returns>Array of IEntityFieldCore objects</returns>
		IEntityFieldCore[] GetAsEntityFieldCoreArray();
		/// <summary>
		/// Reads the fields which are childnodes of the passed in fieldsElement into this object
		/// </summary>
		/// <param name="fieldsElement"></param>
		void ReadXml(XmlNode fieldsElement);
		/// <summary>
		/// Links the specified fields with eachother so setting one to a different value will automatically set the other one as well.
		/// This is required in target-per-entity entities which have multiple times the same PK field in their field list.
		/// </summary>
		/// <param name="superTypeFieldIndex">index of field in the supertype</param>
		/// <param name="subTypeFieldIndex">index of field in the subtype</param>
		void LinkFields(int superTypeFieldIndex, int subTypeFieldIndex);
		/// <summary>
		/// Links the supertype PK fields with the subtype PK fields IF there are PK fields of multiple entities in the set of PK fields.
		/// Linking is required in target-per-entity entities which have multiple times the same PK field in their field list.
		/// </summary>
		void LinkFields();
		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		void DefineField( IEntityField2 fieldToAdd, int indexInFields );
		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		void DefineField( IEntityField2 fieldToAdd, int indexInFields, string alias );
		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		void DefineField( IEntityField2 fieldToAdd, int indexInFields, AggregateFunction aggregateFunctionToApply );
		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		void DefineField( IEntityField2 fieldToAdd, int indexInFields, string alias, AggregateFunction aggregateFunctionToApply );
		/// <summary>
		/// Adds the specified field on the position indexInFields in the resultset.
		/// </summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		void DefineField( IEntityField2 fieldToAdd, int indexInFields, string alias, string entityAlias );
		/// <summary>Adds the specified field on the position indexInFields in the resultset.</summary>
		/// <param name="fieldToAdd">The field to add.</param>
		/// <param name="indexInFields">The position in the resultset where the field will be created on</param>
		/// <param name="alias">The alias to use for this field in the resultset</param>
		/// <param name="entityAlias">The alias to use for the entity this field belongs to. Required to specify multiple times the same entity in a typed list</param>
		/// <param name="aggregateFunctionToApply">the aggregate function to apply to this field.</param>
		void DefineField( IEntityField2 fieldToAdd, int indexInFields, string alias, string entityAlias, AggregateFunction aggregateFunctionToApply );

		/// <summary>
		/// The amount of IEntityFields2 allocated in the EntityFields object.
		/// </summary>
		int	Count {get;}
		/// <summary>
		/// Gets / sets the flag if the contents of the EntityFields2 object is 'dirty', which means that one or more fields are changed. 
		/// </summary>
		bool IsDirty {get; set;}
		/// <summary>
		/// Gets / sets the EntityField2 on the specified Index. 
		/// </summary>
		/// <exception cref="System.IndexOutOfRangeException">When the index specified is not found in the internal datastorage.</exception>
		/// <exception cref="System.ArgumentNullException">When the passed in <see cref="IEntityField2"/> is null</exception>
		/// <exception cref="System.ArgumentException">When the passed in <see cref="IEntityField2"/> is already added. Fields have to be unique.</exception>
		IEntityField2 this [int index] {get; set;} 
		/// <summary>
		/// Gets the EntityField with the specified name.
		/// </summary>
		/// <exception cref="System.ArgumentException">When the specified name is the empty string or contains only spaces</exception>
		/// <remarks>This property is read-only. If you want to set a value, use the int indexer</remarks>
		IEntityField2 this [string name] {get;}
		/// <summary>
		/// List of IEntityField2 references which form the 'primary key', or uniquely identifying set of values for this set of fields, thus for the entity
		/// holding these fields.
		/// </summary>
		List<IEntityField2> PrimaryKeyFields {get;}
		/// <summary>
		/// The state of the EntityFields object, the heart and soul of every EntityObject.
		/// </summary>
		EntityState State {get; set;}
		/// <summary>
		/// Flag to signal if the entity fields have changed during an edit cycle which is controlled outside this IEntityFields2 object. If set to
		/// true, EndEdit will succeed, otherwise EndEdit will ignore any changes, since these are made in a previous edit cycle which is already
		/// ended.
		/// </summary>
		bool IsChangedInThisEditCycle {get; set;}
	}


	/// <summary>
	/// Interface used for all Entity2 classes 
	/// Adapter specific
	/// </summary>
	public interface IEntity2 : IEntityCore
	{
		/// <summary>
		/// Sets the related entity property to the entity specified. If the property is a collection, it will add the entity specified to that collection.
		/// </summary>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="entity">Entity to set as an related entity</param>
		/// <remarks>Used by prefetch path logic.</remarks>
		void SetRelatedEntityProperty( string propertyName, IEntity2 entity );
		/// <summary>
		/// Sets the internal parameter related to the fieldname passed to the instance relatedEntity. 
		/// </summary>
		/// <param name="relatedEntity">Instance to set as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		void SetRelatedEntity(IEntity2 relatedEntity, string fieldName);
		/// <summary>
		/// Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() 
		/// </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		void UnsetRelatedEntity(IEntity2 relatedEntity, string fieldName);
		/// <summary>
		/// Unsets the internal parameter related to the fieldname passed to the instance relatedEntity. Reverses the actions taken by SetRelatedEntity() 
		/// </summary>
		/// <param name="relatedEntity">Instance to unset as the related entity of type entityType</param>
		/// <param name="fieldName">Name of field mapped onto the relation which resolves in the instance relatedEntity</param>
		/// <param name="signalRelatedEntityManyToOne">if set to true it will notify the manytoone side, if applicable.</param>
		void UnsetRelatedEntity( IEntity2 relatedEntity, string fieldName, bool signalRelatedEntityManyToOne );
		/// <summary>
		/// Gets a collection of related entities referenced by this entity which depend on this entity (this entity is the PK side of their FK fields). These
		/// entities will have to be persisted after this entity during a recursive save.
		/// </summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		List<IEntity2> GetDependingRelatedEntities();
		/// <summary>
		/// Gets a collection of related entities referenced by this entity which this entity depends on (this entity is the FK side of their PK fields). These
		/// entities will have to be persisted before this entity during a recursive save.
		/// </summary>
		/// <returns>Collection with 0 or more IEntity2 objects, referenced by this entity</returns>
		List<IEntity2> GetDependentRelatedEntities();
		/// <summary>
		/// Gets a list of all entity collections stored as member variables in this entity. The contents of the list is
		/// used by the DataAccessAdapter to perform recursive saves. Only 1:n related collections are returned.
		/// </summary>
		/// <returns>Collection with 0 or more IEntityCollection2 objects, referenced by this entity</returns>
		List<IEntityCollection2> GetMemberEntityCollections();
		/// <summary>
		/// Returns a new ready to use factory for the type of this instance.
		/// </summary>
		/// <returns>a new ready to use factory for the type of this instance.</returns>
		IEntityFactory2 GetEntityFactory();
		/// <summary>
		/// Converts this entity to XML
		/// </summary>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		void WriteXml(XmlWriter writer, XmlFormatAspect aspects);
		/// <summary>
		/// Converts this entity to XML
		/// </summary>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity.</param>
		void WriteXml(XmlWriter writer, XmlFormatAspect aspects, string rootNodeName);
		/// <summary>
		/// Converts this entity to XML
		/// </summary>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity.</param>
		/// <param name="processedObjectIDs">The objectIDs of entities already serialized.</param>
		/// <remarks>Used for serializing embedded entity data in for example auditors.</remarks>
		void WriteXml(XmlWriter writer, XmlFormatAspect aspects, string rootNodeName, Dictionary<Guid, IEntity2> processedObjectIDs);

		/// <summary>
		/// The internal presentation of the data, which is an EntityFields2 object, which implements <see cref="IEntityFields2"/>.
		/// </summary>
		IEntityFields2 Fields {get; set;}
		/// <summary>
		/// List of IEntityField2 references which form the primary key. Reads/Affects .Fields.PrimaryKeyFields
		/// </summary>
		List<IEntityField2> PrimaryKeyFields { get;}
	}


	/// <summary>
	/// Interface for EntityFactory2 objects used by several methods which have to create entity objects on the fly.
	/// Factories have to add a valid validator object to the entities.
	/// Adapter specific
	/// </summary>
#if !CF && !MONO
	[TypeConverter(typeof(EntityFactory2Converter))]
#endif
	public interface IEntityFactory2 : IEntityFactoryCore
	{
		/// <summary>
		/// Creates a new <see cref="IEntity2"/> instance 
		/// </summary>
		/// <returns>the new IEntity2 instance</returns>
		IEntity2 Create();
		/// <summary>
		/// Creates a new <see cref="IEntity2"/> instance but uses a special constructor which will set the Fields object of the new
		/// IEntity2 instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.
		/// </summary>
		/// <param name="fields">Populated IEntityFields2 object for the new entity2 to create</param>
		/// <returns>Fully created and populated (due to the IEntityFields2 object) IEntity2 object</returns>
		IEntity2 Create(IEntityFields2 fields);
		/// <summary>
		/// Creates, using the generated EntityFieldsFactory, the IEntityFields2 object for the entity to create. This method is used
		/// by internal code to create the fields object to store fetched data. 
		/// </summary>
		/// <returns>Empty IEntityFields2 object.</returns>
		IEntityFields2 CreateFields();
		/// <summary>
		/// Creates the hierarchy fields for the entity to which this factory belongs.
		/// </summary>
		/// <returns>IEntityFields2 object with the fields of all the entities in the hierarchy of this entity or the fields of this entity if
		/// the entity isn't in a hierarchy.</returns>
		IEntityFields2 CreateHierarchyFields();
		/// <summary>
		/// This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.
		/// </summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns></returns>
		IEntityFactory2 GetEntityFactory( object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity );
		/// <summary>Gets a predicateexpression which filters on the entity with type belonging to this factory.</summary>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false). </param>
		/// <returns>ready to use predicateexpression, or an empty predicate expression if the belonging entity isn't a hierarchical type.</returns>
		IPredicateExpression GetEntityTypeFilter(bool negate);
		/// <summary>
		/// Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value
		/// </summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity2 instance</returns>
		IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue);
	}


	/// <summary>
	/// Interface for Data Access Adapter (DAA) objects. Instances of this interface are used as 'adapters' to work with databases. 
	/// Adapter specific.
	/// </summary>
	public interface IDataAccessAdapter : IDisposable
	{
		/// <summary>
		/// Creates a new predicate expression which filters on the primary key fields and the set values for the
		/// given primary key fields. If no primary key fields are specified, null is returned.
		/// </summary>
		/// <param name="primaryKeyFields">ArrayList with IEntityField2 instances which form the primary key for which the filter has to be constructed</param>
		/// <returns>filled in predicate expression or null if no primary key fields are specified.</returns>
		/// <remarks>Call this method passing IEntity2.Fields.PrimaryKeyFields</remarks>
		IPredicateExpression CreatePrimaryKeyFilter(List<IEntityField2> primaryKeyFields);
		/// <summary>
		/// Executes the passed in action query and, if not null, runs it inside the passed in transaction.
		/// </summary>
		/// <param name="queryToExecute">ActionQuery to execute.</param>
		/// <returns>execution result, which is the amount of rows affected (if applicable)</returns>
		int ExecuteActionQuery(IActionQuery queryToExecute);
		/// <summary>
		/// Executes the passed in retrieval query and, if not null, runs it inside the passed in transaction. Used to read 1 row.
		/// It sets the connection object of the command object of query object passed in to the connection object of this class.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="fieldsToFill">The IEntityFields2 object to store the fetched data in</param>
		/// <param name="fieldsPersistenceInfo">The IFieldPersistenceInfo objects for the fieldsToFill fields</param>
		void ExecuteSingleRowRetrievalQuery(IRetrievalQuery queryToExecute, IEntityFields2 fieldsToFill, IFieldPersistenceInfo[] fieldsPersistenceInfo);
		/// <summary>
		/// Executes the passed in retrieval query and, if not null, runs it inside the passed in transaction. Used to read 1 or more rows.
		/// It sets the connection object of the command object of query object passed in to the connection object of this class.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="entityFactory">the factory object which can produce the entities this method has to fill.</param>
		/// <param name="collectionToFill">Collection to fill with the retrieved rows.</param>
		/// <param name="fieldsPersistenceInfo">The persistence information for the fields of the entity created by entityFactory</param>
		/// <param name="allowDuplicates">Flag to signal if duplicates in the datastream should be loaded into the collection (true) or not (false)</param>
		/// <param name="fieldsUsedForQuery">Fields used for producing the query</param>
		void ExecuteMultiRowRetrievalQuery(IRetrievalQuery queryToExecute, IEntityFactory2 entityFactory, 
			IEntityCollection2 collectionToFill, IFieldPersistenceInfo[] fieldsPersistenceInfo, bool allowDuplicates, IEntityFields2 fieldsUsedForQuery);
		/// <summary>
		/// Executes the passed in retrieval query and returns the results as a datatable using the passed in data-adapter. 
		/// It sets the connection object of the command object of query object passed in to the connection object of this class.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="dataAdapterToUse">The dataadapter to use to fill the datatable.</param>
		/// <param name="fieldsPersistenceInfo">Fields persistence info objects for the fields used for the query. Required for type conversion on values.</param>
		/// <returns>DataTable with the rows requested</returns>
		DataTable ExecuteMultiRowDataTableRetrievalQuery(IRetrievalQuery queryToExecute, DbDataAdapter dataAdapterToUse, IFieldPersistenceInfo[] fieldsPersistenceInfo);
		/// <summary>
		/// Executes the passed in retrieval query and returns the results in thedatatable specified using the passed in data-adapter. 
		/// It sets the connection object of the command object of query object passed in to the connection object of this class.
		/// </summary>
		/// <param name="queryToExecute">Retrieval query to execute</param>
		/// <param name="dataAdapterToUse">The dataadapter to use to fill the datatable.</param>
		/// <param name="tableToFill">DataTable to fill</param>
		/// <param name="fieldsPersistenceInfo">Fields persistence info objects for the fields used for the query. Required for type conversion on values.</param>
		/// <returns>true if succeeded, false otherwise</returns>
		bool ExecuteMultiRowDataTableRetrievalQuery(IRetrievalQuery queryToExecute, DbDataAdapter dataAdapterToUse, DataTable tableToFill, IFieldPersistenceInfo[] fieldsPersistenceInfo);
		/// <summary>
		/// Starts a new transaction. All database activity after this call will be ran in this transaction and all objects will participate
		/// in this transaction until its committed or rolled back. 
		/// If there is a transaction in progress, an exception is thrown.
		/// Will create and open a new connection if a transaction is not open and/or available.
		/// </summary>
		/// <param name="isolationLevelToUse">The isolation level to use for this transaction</param>
		/// <param name="name">The name for this transaction</param>
		/// <exception cref="InvalidOperationException">If a transaction is already in progress.</exception>
		void StartTransaction(IsolationLevel isolationLevelToUse, string name);
		/// <summary>
		/// Creates a savepoint with the name savePointName in the current transaction. You can roll back to this savepoint using
		/// <see cref="Rollback(string)"/>.
		/// </summary>
		/// <param name="savePointName">name of savepoint. Must be unique in an active transaction</param>
		/// <exception cref="InvalidOperationException">If no transaction is in progress.</exception>
		/// <exception cref="ArgumentException">if savePointName is empty or null</exception>
		/// <exception cref="NotSupportedException">if the .NET database provider doesn't support transaction saving or when COM+ is used.</exception>
		void SaveTransaction(string savePointName);
		/// <summary>
		/// Commits the transaction in action. It will end all database activity, since commiting a transaction is finalizing it. After
		/// calling Commit or Rollback, the ITransaction implementing class will reset itself.
		/// </summary>
		/// <remarks>Will close the active connection unless KeepConnectionOpen has been set to true</remarks>
		void Commit();
		/// <summary>
		/// Rolls back the transaction in action. It will end all database activity, since commiting a transaction is finalizing it. After
		/// calling Commit or Rollback, the ITransaction implementing class will reset itself. 
		/// </summary>
		/// <remarks>Will close the active connection unless KeepConnectionOpen has been set to true</remarks>
		void Rollback();
		/// <summary>
		/// Rolls back the transaction in action to the savepoint with the name savepointName. No internal objects are being reset when this method is called,
		/// so call this Rollback overload only to roll back to a savepoint. To roll back a complete transaction, call Rollback() without specifying a savepoint
		/// name. Create a savepoint by calling SaveTransaction(savePointName)
		/// </summary>
		/// <exception cref="InvalidOperationException">If no transaction is in progress.</exception>
		/// <exception cref="ArgumentException">if savePointName is empty or null</exception>
		/// <exception cref="NotSupportedException">if the .NET database provider doesn't support transaction rolling back a transaction to a named
		/// point or when COM+ is used.</exception>
		/// <param name="savePointName">name of the savepoint to roll back to.</param>
		void Rollback(string savePointName);
		/// <summary>
		/// Opens the active connection object. If the connection is already open, nothing is done.
		/// If no connection object is present, a new one is created
		/// </summary>
		void OpenConnection();
		/// <summary>
		/// Closes the active connection. If no connection is available or the connection is closed, nothing is done.
		/// </summary>
		void CloseConnection();
		/// <summary>
		/// Saves the passed in entity to the persistent storage. Will <i>not</i> refetch the entity after this save.
		/// The entity will stay out-of-sync. If the entity is new, it will be inserted, if the entity is existent, the changed
		/// entity fields will be changed in the database. Will do a recursive save.
		/// </summary>
		/// <param name="entityToSave">The entity to save</param>
		/// <returns>true if the save was succesful, false otherwise.</returns>
		/// <remarks>Will use a current transaction if a transaction is in progress</remarks>
		bool SaveEntity(IEntity2 entityToSave);
		/// <summary>
		/// Saves the passed in entity to the persistent storage. If the entity is new, it will be inserted, if the entity is existent, the changed
		/// entity fields will be changed in the database. Will do a recursive save.
		/// Will pass the concurrency predicate returned by GetConcurrencyPredicate(ConcurrencyPredicateType.Save) as update restriction.
		/// </summary>
		/// <param name="entityToSave">The entity to save</param>
		/// <param name="refetchAfterSave">When true, it will refetch the entity from the persistent storage so it will be up-to-date
		/// after the save action.</param>
		/// <returns>true if the save was succesful, false otherwise.</returns>
		/// <remarks>Will use a current transaction if a transaction is in progress</remarks>
		bool SaveEntity(IEntity2 entityToSave, bool refetchAfterSave);
		/// <summary>
		/// Saves the passed in entity to the persistent storage. If the entity is new, it will be inserted, if the entity is existent, the changed
		/// entity fields will be changed in the database. Will do a recursive save.
		/// Will pass the concurrency predicate returned by GetConcurrencyPredicate(ConcurrencyPredicateType.Save) as update restriction.
		/// </summary>
		/// <param name="entityToSave">The entity to save</param>
		/// <param name="refetchAfterSave">When true, it will refetch the entity from the persistent storage so it will be up-to-date
		/// after the save action.</param>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query. Will be ignored when the entity is new.</param>
		/// <returns>true if the save was succesful, false otherwise.</returns>
		/// <remarks>Will use a current transaction if a transaction is in progress</remarks>
		bool SaveEntity(IEntity2 entityToSave, bool refetchAfterSave, IPredicateExpression updateRestriction);
		/// <summary>
		/// Saves the passed in entity to the persistent storage. If the entity is new, it will be inserted, if the entity is existent, the changed
		/// entity fields will be changed in the database.
		/// </summary>
		/// <param name="entityToSave">The entity to save</param>
		/// <param name="refetchAfterSave">When true, it will refetch the entity from the persistent storage so it will be up-to-date
		/// after the save action.</param>
		/// <param name="updateRestriction">Predicate expression, meant for concurrency checks in an Update query. Will be ignored when the entity is new.</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by entityToSave also.</param>
		/// <returns>true if the save was succesful, false otherwise.</returns>
		/// <remarks>Will use a current transaction if a transaction is in progress</remarks>
		bool SaveEntity(IEntity2 entityToSave, bool refetchAfterSave, IPredicateExpression updateRestriction, bool recurse);
		/// <summary>
		/// Saves the passed in entity to the persistent storage. If the entity is new, it will be inserted, if the entity is existent, the changed
		/// entity fields will be changed in the database. 
		/// Will pass the concurrency predicate returned by GetConcurrencyPredicate(ConcurrencyPredicateType.Save) as update restriction.
		/// </summary>
		/// <param name="entityToSave">The entity to save</param>
		/// <param name="refetchAfterSave">When true, it will refetch the entity from the persistent storage so it will be up-to-date
		/// after the save action.</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by entityToSave also.</param>
		/// <returns>true if the save was succesful, false otherwise.</returns>
		/// <remarks>Will use a current transaction if a transaction is in progress</remarks>
		bool SaveEntity(IEntity2 entityToSave, bool refetchAfterSave, bool recurse);
		/// <summary>
		/// Fetches an entity from the persistent storage into the passed in Entity2 object using a primary key filter. The primary key fields of
		/// the entity passed in have to have the primary key values. (Example: CustomerID has to have a value, when you want to fetch a CustomerEntity
		/// from the persistent storage into the passed in object)
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored. The primary key fields have to have a value.</param>
		/// <remarks>Will use a current transaction if a transaction is in progress, so MVCC or other concurrency scheme used by the database can be
		/// utilized</remarks>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		bool FetchEntity(IEntity2 entityToFetch);
		/// <summary>
		/// Fetches an entity from the persistent storage into the passed in Entity2 object using a primary key filter. The primary key fields of
		/// the entity passed in have to have the primary key values. (Example: CustomerID has to have a value, when you want to fetch a CustomerEntity
		/// from the persistent storage into the passed in object)
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored. The primary key fields have to have a value.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <remarks>Will use a current transaction if a transaction is in progress, so MVCC or other concurrency scheme used by the database can be
		/// utilized</remarks>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		bool FetchEntity(IEntity2 entityToFetch, IPrefetchPath2 prefetchPath);
		/// <summary>
		/// Fetches an entity from the persistent storage into the passed in Entity2 object using a primary key filter. The primary key fields of
		/// the entity passed in have to have the primary key values. (Example: CustomerID has to have a value, when you want to fetch a CustomerEntity
		/// from the persistent storage into the passed in object)
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored. The primary key fields have to have a value.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <remarks>Will use a current transaction if a transaction is in progress, so MVCC or other concurrency scheme used by the database can be
		/// utilized</remarks>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		bool FetchEntity(IEntity2 entityToFetch, Context contextToUse);
		/// <summary>
		/// Fetches an entity from the persistent storage into the passed in Entity2 object using a primary key filter. The primary key fields of
		/// the entity passed in have to have the primary key values. (Example: CustomerID has to have a value, when you want to fetch a CustomerEntity
		/// from the persistent storage into the passed in object)
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored. The primary key fields have to have a value.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <remarks>Will use a current transaction if a transaction is in progress, so MVCC or other concurrency scheme used by the database can be utilized</remarks>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		bool FetchEntity(IEntity2 entityToFetch, IPrefetchPath2 prefetchPath, Context contextToUse);
		/// <summary>
		/// Fetches an entity from the persistent storage into the passed in Entity2 object using a primary key filter. The primary key fields of
		/// the entity passed in have to have the primary key values. (Example: CustomerID has to have a value, when you want to fetch a CustomerEntity
		/// from the persistent storage into the passed in object). All fields specified in excludedFields are excluded from the fetch so the entity won't
		/// get any value set for those fields. <b>excludedFields</b> can be null or empty, in which case all fields are fetched (default).
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored. The primary key fields have to have a value.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <remarks>Will use a current transaction if a transaction is in progress, so MVCC or other concurrency scheme used by the database can be utilized</remarks>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		bool FetchEntity(IEntity2 entityToFetch, IPrefetchPath2 prefetchPath, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields);
		/// <summary>
		/// Fetches an entity from the persistent storage into the object specified using the filter specified. 
		/// Use the entity's uniqueconstraint filter construction methods to construct the required uniqueConstraintFilter for the 
		/// unique constraint you want to use.
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored.</param>
		/// <param name="uniqueConstraintFilter">The filter which should filter on fields with a unique constraint.</param>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		bool FetchEntityUsingUniqueConstraint(IEntity2 entityToFetch, IPredicateExpression uniqueConstraintFilter);
		/// <summary>
		/// Fetches an entity from the persistent storage into the object specified using the filter specified. 
		/// Use the entity's uniqueconstraint filter construction methods to construct the required uniqueConstraintFilter for the 
		/// unique constraint you want to use.
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored.</param>
		/// <param name="uniqueConstraintFilter">The filter which should filter on fields with a unique constraint.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		bool FetchEntityUsingUniqueConstraint(IEntity2 entityToFetch, IPredicateExpression uniqueConstraintFilter, IPrefetchPath2 prefetchPath);
		/// <summary>
		/// Fetches an entity from the persistent storage into the object specified using the filter specified. 
		/// Use the entity's uniqueconstraint filter construction methods to construct the required uniqueConstraintFilter for the 
		/// unique constraint you want to use.
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored.</param>
		/// <param name="uniqueConstraintFilter">The filter which should filter on fields with a unique constraint.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		bool FetchEntityUsingUniqueConstraint(IEntity2 entityToFetch, IPredicateExpression uniqueConstraintFilter, Context contextToUse);
		/// <summary>
		/// Fetches an entity from the persistent storage into the object specified using the filter specified. 
		/// Use the entity's uniqueconstraint filter construction methods to construct the required uniqueConstraintFilter for the 
		/// unique constraint you want to use.
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored.</param>
		/// <param name="uniqueConstraintFilter">The filter which should filter on fields with a unique constraint.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		bool FetchEntityUsingUniqueConstraint(IEntity2 entityToFetch, IPredicateExpression uniqueConstraintFilter, IPrefetchPath2 prefetchPath, Context contextToUse);
		/// <summary>
		/// Fetches an entity from the persistent storage into the object specified using the filter specified. 
		/// Use the entity's uniqueconstraint filter construction methods to construct the required uniqueConstraintFilter for the 
		/// unique constraint you want to use.
		/// </summary>
		/// <param name="entityToFetch">The entity object in which the fetched entity data will be stored.</param>
		/// <param name="uniqueConstraintFilter">The filter which should filter on fields with a unique constraint.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>true if the Fetch was succesful, false otherwise</returns>
		bool FetchEntityUsingUniqueConstraint(IEntity2 entityToFetch, IPredicateExpression uniqueConstraintFilter, IPrefetchPath2 prefetchPath, Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields);
		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// passed in entity factory. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="entityFactoryToUse">The factory which will be used to create a new entity object which will be fetched</param>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <returns>The new entity fetched.</returns>
		IEntity2 FetchNewEntity(IEntityFactory2 entityFactoryToUse, IRelationPredicateBucket filterBucket);
		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// passed in entity factory. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="entityFactoryToUse">The factory which will be used to create a new entity object which will be fetched</param>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <returns>The new entity fetched.</returns>
		IEntity2 FetchNewEntity(IEntityFactory2 entityFactoryToUse, IRelationPredicateBucket filterBucket, IPrefetchPath2 prefetchPath);
		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// passed in entity factory. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="entityFactoryToUse">The factory which will be used to create a new entity object which will be fetched</param>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>The new entity fetched, or a previous entity fetched if that entity was in the context specified</returns>
		IEntity2 FetchNewEntity(IEntityFactory2 entityFactoryToUse, IRelationPredicateBucket filterBucket, Context contextToUse);
		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// passed in entity factory. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="entityFactoryToUse">The factory which will be used to create a new entity object which will be fetched</param>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <returns>The new entity fetched, or a previous entity fetched if that entity was in the context specified</returns>
		IEntity2 FetchNewEntity(IEntityFactory2 entityFactoryToUse, IRelationPredicateBucket filterBucket, IPrefetchPath2 prefetchPath, Context contextToUse);
		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// passed in entity factory. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="entityFactoryToUse">The factory which will be used to create a new entity object which will be fetched</param>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>The new entity fetched, or a previous entity fetched if that entity was in the context specified</returns>
		IEntity2 FetchNewEntity(IEntityFactory2 entityFactoryToUse, IRelationPredicateBucket filterBucket, IPrefetchPath2 prefetchPath,	Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields);
		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// specified generic type. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <returns>The new entity fetched.</returns>
		/// <typeparam name="TEntity">The type of entity to fetch</typeparam>
		/// <remarks>TEntity can't be a type which is an abstract entity. If you want to fetch an instance of an abstract entity (e.g. polymorphic fetch)
		/// please use the overload which accepts an entity factory instead</remarks>
		TEntity FetchNewEntity<TEntity>(IRelationPredicateBucket filterBucket)
			where TEntity : EntityBase2, IEntity2, new();
		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// specified generic type. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful. </param>
		/// <returns>The new entity fetched, or a previous entity fetched if that entity was in the context specified</returns>
		/// <typeparam name="TEntity">The type of entity to fetch</typeparam>
		/// <remarks>TEntity can't be a type which is an abstract entity. If you want to fetch an instance of an abstract entity (e.g. polymorphic fetch)
		/// please use the overload which accepts an entity factory instead</remarks>
		TEntity FetchNewEntity<TEntity>(IRelationPredicateBucket filterBucket, Context contextToUse)
			where TEntity : EntityBase2, IEntity2, new();
		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// specified generic type. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <returns>The new entity fetched.</returns>
		/// <typeparam name="TEntity">The type of entity to fetch</typeparam>
		/// <remarks>TEntity can't be a type which is an abstract entity. If you want to fetch an instance of an abstract entity (e.g. polymorphic fetch)
		/// please use the overload which accepts an entity factory instead</remarks>
		TEntity FetchNewEntity<TEntity>(IRelationPredicateBucket filterBucket, IPrefetchPath2 prefetchPath)
			where TEntity : EntityBase2, IEntity2, new();
		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// specified generic type. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <returns>The new entity fetched, or a previous entity fetched if that entity was in the context specified</returns>
		/// <typeparam name="TEntity">The type of entity to fetch</typeparam>
		/// <remarks>TEntity can't be a type which is an abstract entity. If you want to fetch an instance of an abstract entity (e.g. polymorphic fetch)
		/// please use the overload which accepts an entity factory instead</remarks>
		TEntity FetchNewEntity<TEntity>(IRelationPredicateBucket filterBucket, IPrefetchPath2 prefetchPath, Context contextToUse)
			where TEntity : EntityBase2, IEntity2, new();
		/// <summary>
		/// Fetches a new entity using the filter/relation combination filter passed in via <i>filterBucket</i> and the new entity is created using the
		/// specified generic type. Use this method when fetching a related entity using a current entity (for example, fetch the related Customer entity
		/// of an existing Order entity)
		/// </summary>
		/// <param name="filterBucket">the completely filled in IRelationPredicateBucket object which will be used as a filter for the fetch. The fetch
		/// will only load the first entity loaded, even if the filter results into more entities being fetched</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="contextToUse">The context to add the entity to if the fetch was succesful, and before the prefetch path is fetched. This ensures
		/// that the prefetch path is fetched using the context specified and will re-use already loaded entity objects.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>The new entity fetched, or a previous entity fetched if that entity was in the context specified</returns>
		/// <typeparam name="TEntity">The type of entity to fetch</typeparam>
		/// <remarks>TEntity can't be a type which is an abstract entity. If you want to fetch an instance of an abstract entity (e.g. polymorphic fetch)
		/// please use the overload which accepts an entity factory instead</remarks>
		TEntity FetchNewEntity<TEntity>(IRelationPredicateBucket filterBucket, IPrefetchPath2 prefetchPath,
				Context contextToUse, ExcludeIncludeFieldsList excludedIncludedFields)
			where TEntity : EntityBase2, IEntity2, new();
		/// <summary>
		/// Deletes the specified entity from the persistent storage. The entity is not usable after this call, the state is set to
		/// OutOfSync.
		/// Will use the current transaction if a transaction is in progress.
		/// </summary>
		/// <param name="entityToDelete">The entity instance to delete from the persistent storage</param>
		/// <returns>true if the delete was succesful, otherwise false.</returns>
		bool DeleteEntity(IEntity2 entityToDelete);
		/// <summary>
		/// Deletes the specified entity from the persistent storage. The entity is not usable after this call, the state is set to
		/// OutOfSync.
		/// Will use the current transaction if a transaction is in progress.
		/// </summary>
		/// <param name="entityToDelete">The entity instance to delete from the persistent storage</param>
		/// <param name="deleteRestriction">Predicate expression, meant for concurrency checks in a delete query</param>
		/// <returns>true if the delete was succesful, otherwise false.</returns>
		bool DeleteEntity(IEntity2 entityToDelete, IPredicateExpression deleteRestriction);
		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// This overload returns all found entities and doesn't apply sorting
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket);
		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// This overload returns all found entities and doesn't apply sorting
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		void FetchEntityCollection(IEntityCollection2 collectionToFill, ExcludeIncludeFieldsList excludedIncludedFields, IRelationPredicateBucket filterBucket);
		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// This overload returns all found entities and doesn't apply sorting
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, IPrefetchPath2 prefetchPath);
		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// This overload doesn't apply sorting
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn);
		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, ISortExpression sortClauses);
		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, IPrefetchPath2 prefetchPath);
		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="prefetchPath">The prefetch path to use for this fetch, which will fetch all related entities defined by the path as well.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields);
		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
				ISortExpression sortClauses, int pageNumber, int pageSize);
		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// It will apply paging and it will from there use a prefetch path fetch using the read page. It's important that pageSize
		/// is smaller than the set ParameterisedPrefetchPathThreshold. It will work, though if pagesize is larger than the limits set for
		/// the ParameterisedPrefetchPathThreshold value, the query is likely to be slower than expected.
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="prefetchPath">Prefetch path to use.</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IPrefetchPath2 prefetchPath, int pageNumber, int pageSize);
		/// <summary>
		/// Fetches one or more entities which match the filter information in the filterBucket into the EntityCollection passed.
		/// The entity collection object has to contain an entity factory object which will be the factory for the entity instances
		/// to be fetched.
		/// It will apply paging and it will from there use a prefetch path fetch using the read page. It's important that pageSize
		/// is smaller than the set <see cref="ParameterisedPrefetchPathThreshold"/>. If pagesize is larger than the limits set for
		/// the <see cref="ParameterisedPrefetchPathThreshold"/> value, the query is likely to be slower than expected, though will work.
		/// If pageNumber / pageSize are set to values which disable paging, a normal prefetch path fetch will be performed. 
		/// </summary>
		/// <param name="collectionToFill">EntityCollection object containing an entity factory which has to be filled</param>
		/// <param name="filterBucket">filter information for retrieving the entities. If null, all entities are returned of the type created by
		/// the factory in the passed in EntityCollection instance.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of entities to return. If 0, all entities matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="prefetchPath">Prefetch path to use.</param>
		/// <param name="excludedIncludedFields">The list of IEntityField2 objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <exception cref="ArgumentException">If the passed in collectionToFill doesn't contain an entity factory.</exception>
		/// <remarks>Special thanks to Marcus Mac Innes (http://www.styledesign.biz) for the paging optimization code.</remarks>
		void FetchEntityCollection(IEntityCollection2 collectionToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IPrefetchPath2 prefetchPath, ExcludeIncludeFieldsList excludedIncludedFields, int pageNumber, int pageSize);
		/// <summary>
		/// Saves all dirty objects inside the collection passed to the persistent storage. It will do this inside a transaction if a transaction
		/// is not yet available. Will not refetch saved entities and will not recursively save the entities.
		/// </summary>
		/// <param name="collectionToSave">EntityCollection with one or more dirty entities which have to be persisted</param>
		/// <returns>the amount of persisted entities</returns>
		int SaveEntityCollection(IEntityCollection2 collectionToSave);
		/// <summary>
		/// Saves all dirty objects inside the collection passed to the persistent storage. It will do this inside a transaction if a transaction
		/// is not yet available.
		/// </summary>
		/// <param name="collectionToSave">EntityCollection with one or more dirty entities which have to be persisted</param>
		/// <param name="refetchSavedEntitiesAfterSave">Refetches a saved entity from the database, so the entity will not be 'out of sync'</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by the entities inside collectionToSave also.</param>
		/// <returns>the amount of persisted entities</returns>
		int SaveEntityCollection(IEntityCollection2 collectionToSave, bool refetchSavedEntitiesAfterSave, bool recurse);
		/// <summary>
		/// Deletes all dirty objects inside the collection passed from the persistent storage. It will do this inside a transaction if a transaction
		/// is not yet available. Entities which are physically deleted from the persistent storage are marked with the state 'Deleted' but are not
		/// removed from the collection.
		/// If the passed in entity has a concurrency predicate factory object, the returned predicate expression is used to restrict the delete process.		
		/// </summary>
		/// <param name="collectionToDelete">EntityCollection with one or more dirty entities which have to be persisted</param>
		/// <returns>the amount of physically deleted entities</returns>
		int DeleteEntityCollection(IEntityCollection2 collectionToDelete);
		/// <summary>
		/// Deletes all entities of the name passed in as <i>entityName</i> (e.g. "CustomerEntity") from the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>.
		/// </summary>
		/// <param name="entityName">The name of the entity to retrieve persistence information. For example "CustomerEntity". This name can be
		/// retrieved from an existing entity's Name property.</param>
		/// <param name="filterBucket">filter information to filter out the entities to delete</param>
		/// <returns>the amount of physically deleted entities</returns>
		int DeleteEntitiesDirectly(string entityName, IRelationPredicateBucket filterBucket);
		/// <summary>
		/// Deletes all entities of the name passed in as <i>entityName</i> (e.g. "CustomerEntity") from the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>.
		/// </summary>
		/// <param name="typeOfEntity">The type of the entity to retrieve persistence information. </param>
		/// <param name="filterBucket">filter information to filter out the entities to delete</param>
		/// <returns>the amount of physically deleted entities</returns>
		/// <remarks>Not supported for entities which are in a TargetPerEntity hierarchy.</remarks>
		int DeleteEntitiesDirectly(Type typeOfEntity, IRelationPredicateBucket filterBucket);
		/// <summary>
		/// Updates all entities of the same type of the entity <i>entityWithNewValues</i> directly in the persistent storage if they match the filter
		/// supplied in <i>filterBucket</i>. Only the fields changed in entityWithNewValues are updated for these fields. 
		/// </summary>
		/// <param name="entityWithNewValues">Entity object which contains the new values for the entities of the same type and which match the filter
		/// in filterBucket. Only fields which are changed are updated.</param>
		/// <param name="filterBucket">filter information to filter out the entities to update.</param>
		/// <returns>the amount of physically updated entities</returns>
		int UpdateEntitiesDirectly(IEntity2 entityWithNewValues, IRelationPredicateBucket filterBucket);
		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. Doesn't apply any sorting, doesn't limit
		/// the resultset on the amount of rows to return, does allow duplicates.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket);
		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. Doesn't apply any sorting, doesn't limit
		/// the resultset on the amount of rows to return.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, bool allowDuplicates);
		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. Doesn't apply any sorting.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, 
			int maxNumberOfItemsToReturn, bool allowDuplicates);
		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. 
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset. Use the typed list's method GetFieldsInfo() to retrieve
		/// this IEntityField2 information</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, 
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates);
		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. 
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset. Use the typed list's method GetFieldsInfo() to retrieve
		/// this IEntityField2 information</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on</param>
		void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, 
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IGroupByCollection groupByClause);
		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a typed list object. 
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields to fetch into the datatable. The fields
		/// inside this object are used to construct the selection resultset. Use the typed list's method GetFieldsInfo() to retrieve
		/// this IEntityField2 information</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		void FetchTypedList(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, bool allowDuplicates, IGroupByCollection groupByClause, int pageNumber, int pageSize);
		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// the passed in typed list.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="typedListToFill">Typed list to fill.</param>
		/// <remarks>Grabs the fields list and relations set from the typed list passed in. </remarks>
		void FetchTypedList(ITypedListLgp2 typedListToFill);
		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// the passed in typed list.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="typedListToFill">Typed list to fill.</param>
		/// <param name="additionalFilter">An additional filter to use to filter the fetch of the typed list. If you need a more sophisticated
		/// filter approach, please use the overload which accepts an IRelationalPredicateBucket and add your filter to the bucket you receive
		/// when calling typedListToFill.GetRelationInfo().</param>
		/// <remarks>Grabs the fields list and relations set from the typed list passed in. </remarks>
		void FetchTypedList(ITypedListLgp2 typedListToFill, IPredicateExpression additionalFilter);
		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// the passed in typed list.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="typedListToFill">Typed list to fill.</param>
		/// <param name="additionalFilter">An additional filter to use to filter the fetch of the typed list. If you need a more sophisticated
		/// filter approach, please use the overload which accepts an IRelationalPredicateBucket and add your filter to the bucket you receive
		/// when calling typedListToFill.GetRelationInfo().</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <remarks>Grabs the fields list and relations set from the typed list passed in. </remarks>
		void FetchTypedList(ITypedListLgp2 typedListToFill, IPredicateExpression additionalFilter, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, bool allowDuplicates);
		/// <summary>
		/// Fetches the fields passed in fieldCollectionToFetch from the persistent storage using the relations and filter information stored in
		/// the passed in typed list.
		/// For TypedView filling, use the method FetchTypedView()
		/// </summary>
		/// <param name="typedListToFill">Typed list to fill.</param>
		/// <param name="additionalFilter">An additional filter to use to filter the fetch of the typed list. If you need a more sophisticated
		/// filter approach, please use the overload which accepts an IRelationalPredicateBucket and add your filter to the bucket you receive
		/// when calling typedListToFill.GetRelationInfo().</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <remarks>Grabs the fields list and relations set from the typed list passed in. </remarks>
		void FetchTypedList(ITypedListLgp2 typedListToFill, IPredicateExpression additionalFilter, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, bool allowDuplicates, int pageNumber, int pageSize);
		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage into the DataTable object passed in. Doesn't apply any sorting, doesn't limit the amount of rows returned by the query, doesn't
		/// apply any filtering, allows duplicate rows.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill);
		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage using the filter information stored in
		/// filterBucket into the DataTable object passed in. Doesn't apply any sorting, doesn't limit the amount of rows returned by the query.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, bool allowDuplicates);
		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage using the filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.
		/// Use the Typed View's method GetFieldsInfo() to get this IEntityField2 field collection</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <remarks>To fill a DataTable with entity rows, use this method as well, by passing the Fields collection of an entity of the same type
		/// as the one you want to fetch as fieldCollectionToFetch.</remarks>
		void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, 
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates);
		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage using the filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.
		/// Use the Typed View's method GetFieldsInfo() to get this IEntityField2 field collection</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on</param>
		/// <remarks>To fill a DataTable with entity rows, use this method as well, by passing the Fields collection of an entity of the same type
		/// as the one you want to fetch as fieldCollectionToFetch.</remarks>
		void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, 
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IGroupByCollection groupByClause);
		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage using the filter information stored in
		/// filterBucket into the DataTable object passed in. Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.
		/// Use the Typed View's method GetFieldsInfo() to get this IEntityField2 field collection</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on</param>
		/// <param name="pageNumber">the page number to retrieve. First page is 1. When set to 0, no paging logic is applied</param>
		/// <param name="pageSize">the size of the page. When set to 0, no paging logic is applied</param>
		/// <remarks>To fill a DataTable with entity rows, use this method as well, by passing the Fields collection of an entity of the same type
		/// as the one you want to fetch as fieldCollectionToFetch.</remarks>
		void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
			ISortExpression sortClauses, bool allowDuplicates, IGroupByCollection groupByClause, int pageNumber, int pageSize);
		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage using the filter information stored in
		/// filterBucket into the DataTable object passed in. Doesn't apply any sorting
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, IRelationPredicateBucket filterBucket, 
				int maxNumberOfItemsToReturn, bool allowDuplicates);
		/// <summary>
		/// Fetches the Typed View fields passed in fieldCollectionToFetch from the persistent storage into the DataTable object passed in. Doesn't apply any sorting, doesn't limit the amount of rows returned by the query, doesn't
		/// apply any filtering.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="fieldCollectionToFetch">IEntityField2 collection which contains the fields of the typed view to fetch into the datatable.</param>
		/// <param name="dataTableToFill">The datatable object to fill with the data for the fields in fieldCollectionToFetch</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		void FetchTypedView(IEntityFields2 fieldCollectionToFetch, DataTable dataTableToFill, bool allowDuplicates);

		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage
		/// Doesn't apply any sorting, doesn't limit the amount of rows returned by the query, doesn't apply any filtering, allows duplicate rows.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		void FetchTypedView(ITypedView2 typedViewToFill);
		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage 
		/// Doesn't apply any sorting, doesn't limit the amount of rows returned by the query.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		void FetchTypedView(ITypedView2 typedViewToFill, IRelationPredicateBucket filterBucket, bool allowDuplicates);
		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage 
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <remarks>To fill a DataTable with entity rows, use this method as well, by passing the Fields collection of an entity of the same type
		/// as the one you want to fetch as fieldCollectionToFetch.</remarks>
		void FetchTypedView(ITypedView2 typedViewToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, 
				ISortExpression sortClauses, bool allowDuplicates);
		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage 
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="sortClauses">SortClause expression which is applied to the query executed, sorting the fetch result.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <param name="groupByClause">GroupByCollection with fields to group by on</param>
		/// <remarks>To fill a DataTable with entity rows, use this method as well, by passing the Fields collection of an entity of the same type
		/// as the one you want to fetch as fieldCollectionToFetch.</remarks>
		void FetchTypedView(ITypedView2 typedViewToFill, IRelationPredicateBucket filterBucket, 
			int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, IGroupByCollection groupByClause);
		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage 
		/// Doesn't apply any sorting. Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		/// <param name="filterBucket">filter information (relations and predicate expressions) for retrieving the data. 
		/// Use the TypedList's method GetRelationInfo() to retrieve this bucket.</param>
		/// <param name="maxNumberOfItemsToReturn">The maximum amount of rows to return. If 0, all rows matching the filter are returned</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		void FetchTypedView(ITypedView2 typedViewToFill, IRelationPredicateBucket filterBucket, int maxNumberOfItemsToReturn, bool allowDuplicates);
		/// <summary>
		/// Fetches the Typed View passed in from the persistent storage 
		/// Doesn't apply any sorting, doesn't limit the amount of rows returned by the query, doesn't apply any filtering.
		/// Use this routine to fill a TypedView object.
		/// </summary>
		/// <param name="typedViewToFill">Typed view to fill.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		void FetchTypedView(ITypedView2 typedViewToFill, bool allowDuplicates);
		/// <summary>
		/// Executes the passed in retrievalquery and returns an open, ready to use IDataReader. The datareader's command behavior is set to the 
		/// readerBehavior passed in. If a transaction is in progress, the command is wired to the transaction. 
		/// </summary>
		/// <param name="queryToExecute">The query to execute.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the dataaccessadapter's connection is also open</remarks>
		IDataReader FetchDataReader( IRetrievalQuery queryToExecute, CommandBehavior readerBehavior );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is in progress, the command is wired to the transaction.
		/// </summary>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the dataaccessadapter's connection is also open</remarks>
		IDataReader FetchDataReader( IEntityFields2 fields, IRelationPredicateBucket filter, CommandBehavior readerBehavior, int maxNumberOfItemsToReturn,
			bool allowDuplicates );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is in progress, the command is wired to the transaction.
		/// </summary>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the dataaccessadapter's connection is also open</remarks>
		IDataReader FetchDataReader( IEntityFields2 fields, IRelationPredicateBucket filter, CommandBehavior readerBehavior, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, bool allowDuplicates);
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is in progress, the command is wired to the transaction.
		/// </summary>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the dataaccessadapter's connection is also open</remarks>
		IDataReader FetchDataReader( IEntityFields2 fields, IRelationPredicateBucket filter, CommandBehavior readerBehavior, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, bool allowDuplicates, int pageNumber, int pageSize );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in and executes that retrievalquery to return an open, ready to use IDataReader.
		/// The datareader's command behavior is set to the readerBehavior passed in. If a transaction is in progress, the command is wired to the transaction.
		/// </summary>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="readerBehavior">The reader behavior to set.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <returns>Open, ready to use IDataReader</returns>
		/// <remarks>Advanced functionality: be aware that the datareader returned is open, and the dataaccessadapter's connection is also open</remarks>
		IDataReader FetchDataReader( IEntityFields2 fields, IRelationPredicateBucket filter, CommandBehavior readerBehavior, int maxNumberOfItemsToReturn,
			ISortExpression sortClauses, IGroupByCollection groupByClause, bool allowDuplicates, int pageNumber, int pageSize );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is in progress, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		void FetchProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, IEntityFields2 fields, 
			IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, bool allowDuplicates );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is in progress, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		void FetchProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, IEntityFields2 fields, 
			IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is in progress, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		void FetchProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, IEntityFields2 fields, 
			IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, ISortExpression sortClauses, bool allowDuplicates, int pageNumber, int pageSize );
		/// <summary>
		/// Creates a new Retrieval query from the elements passed in, executes that retrievalquery and projects the resultset of that query using the
		/// value projectors and the projector specified. If a transaction is in progress, the command is wired to the transaction and executed inside the
		/// transaction. The projection results will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="fields">The fields to use to build the query.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return. Specify 0 to return all elements</param>
		/// <param name="sortClauses">The sort clauses.</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="allowDuplicates">If set to true, allow duplicates in the resultset, otherwise it will emit DISTINCT into the query (if possible).</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		void FetchProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, IEntityFields2 fields, 
			IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, ISortExpression sortClauses, IGroupByCollection groupByClause, 
			bool allowDuplicates, int pageNumber, int pageSize );
		/// <summary>
		/// Executes the passed in retrievalquery and projects the resultset using the value projectors and the projector specified.
		/// IF a transaction is in progress, the command is wired to the transaction and executed inside the transaction. The projection results
		/// will be stored in the projector.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="queryToExecute">The query to execute.</param>
		void FetchProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, IRetrievalQuery queryToExecute );
		/// <summary>
		/// Projects the current resultset of the passed in datareader using the value projectors and the projector specified. The reader will be left open
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector to use for projecting a raw row onto a new object provided by the projector.</param>
		/// <param name="reader">The reader which points to the first row of a resultset</param>
		/// <remarks>Use this overload together with FetchDataReader if your datareader contains multiple resultsets, so you have fine-grained
		/// control over how you want to project which resultset in the datareader</remarks>
		void FetchProjection( List<IDataValueProjector> valueProjectors, IGeneralDataProjector projector, IDataReader reader );
		/// <summary>
		/// Gets a scalar value, calculated with the aggregate and expression specified. the field specified is the field the expression and aggregate are
		/// applied on.
		/// </summary>
		/// <param name="field">Field to which to apply the aggregate function and expression</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <returns>the scalar value requested</returns>
		object GetScalar(IEntityField2 field, AggregateFunction aggregateToApply);
		/// <summary>
		/// Gets a scalar value, calculated with the aggregate and expression specified. the field specified is the field the expression and aggregate are
		/// applied on.
		/// </summary>
		/// <param name="field">Field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <returns>the scalar value requested</returns>
		object GetScalar(IEntityField2 field, IExpression expressionToExecute, AggregateFunction aggregateToApply);
		/// <summary>
		/// Gets a scalar value, calculated with the aggregate and expression specified. the field specified is the field the expression and aggregate are
		/// applied on.
		/// </summary>
		/// <param name="field">Field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <param name="filter">The filter to apply to retrieve the scalar</param>
		/// <returns>the scalar value requested</returns>
		object GetScalar(IEntityField2 field, IExpression expressionToExecute, AggregateFunction aggregateToApply, IPredicate filter);
		/// <summary>
		/// Gets a scalar value, calculated with the aggregate and expression specified. the field specified is the field the expression and aggregate are
		/// applied on.
		/// </summary>
		/// <param name="field">Field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <param name="filter">The filter to apply to retrieve the scalar</param>
		/// <param name="groupByClause">The groupby clause to apply to retrieve the scalar</param>
		/// <returns>the scalar value requested</returns>
		object GetScalar(IEntityField2 field, IExpression expressionToExecute, AggregateFunction aggregateToApply, IPredicate filter, 
			IGroupByCollection groupByClause);
		/// <summary>
		/// Gets a scalar value, calculated with the aggregate and expression specified. the field specified is the field the expression and aggregate are
		/// applied on.
		/// </summary>
		/// <param name="field">Field to which to apply the aggregate function and expression</param>
		/// <param name="expressionToExecute">The expression to execute. Can be null</param>
		/// <param name="aggregateToApply">Aggregate function to apply. </param>
		/// <param name="filter">The filter to apply to retrieve the scalar</param>
		/// <param name="groupByClause">The groupby clause to apply to retrieve the scalar</param>
		/// <param name="relations">The relations part of the filter.</param>
		/// <returns>the scalar value requested</returns>
		object GetScalar(IEntityField2 field, IExpression expressionToExecute, AggregateFunction aggregateToApply, IPredicate filter, 
			IGroupByCollection groupByClause, IRelationCollection relations);
		/// <summary>
		/// Executes the expression defined with the field in the fields collection specified, using the various elements defined. The expression is executed as a
		/// scalar query and a single value is returned.
		/// </summary>
		/// <param name="fields">IEntityFields2 instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="filter">filter to use</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>the value which is the result of the expression defined on the specified field</returns>
		object GetScalar(IEntityFields2 fields, IPredicate filter, IGroupByCollection groupByClause);
		/// <summary>
		/// Executes the expression defined with the field in the fields collection specified, using the various elements defined. The expression is executed as a
		/// scalar query and a single value is returned.
		/// </summary>
		/// <param name="fields">IEntityFields2 instance with a single field with an expression defined and eventually aggregates</param>
		/// <param name="filter">filter to use</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="relations">The relations part of the filter.</param>
		/// <returns>the value which is the result of the expression defined on the specified field</returns>
		object GetScalar(IEntityFields2 fields, IPredicate filter, IGroupByCollection groupByClause, IRelationCollection relations);
		/// <summary>
		/// Gets the estimated number of objects returned by a query for objects to store in the entity collection passed in, using the filter and 
		/// groupby clause specified. The number is estimated as duplicate objects can be present in the raw query results, but will be filtered out
		/// when the query result is transformed into objects.
		/// </summary>
		/// <param name="collection">EntityCollection instance which will be fetched by the query to get the rowcount for</param>
		/// <param name="filter">filter to use by the query to get the rowcount for</param>
		/// <returns>the number of rows the query for the fields specified, using the filter, relations and groupbyClause specified.</returns>
		/// <remarks>This method performs a SELECT COUNT(*) FROM (actual query) and executes that as a scalar query. This construct is not supported on
		/// Firebird. You can try to achieve the same results by using GetScalar and AggregateFunction.CountRow, though those results can differ from
		/// the result returned by GetDbCount if you use a group by clause. </remarks>
		int GetDbCount(IEntityCollection2 collection, IRelationPredicateBucket filter);
		/// <summary>
		/// Gets the estimated number of objects returned by a query for objects to store in the entity collection passed in, using the filter and 
		/// groupby clause specified. The number is estimated as duplicate objects can be present in the raw query results, but will be filtered out
		/// when the query result is transformed into objects.
		/// </summary>
		/// <param name="collection">EntityCollection instance which will be fetched by the query to get the rowcount for</param>
		/// <param name="filter">filter to use by the query to get the rowcount for</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>the number of rows the query for the fields specified, using the filter, relations and groupbyClause specified.</returns>
		/// <remarks>This method performs a SELECT COUNT(*) FROM (actual query) and executes that as a scalar query. This construct is not supported on
		/// Firebird. You can try to achieve the same results by using GetScalar and AggregateFunction.CountRow, though those results can differ from
		/// the result returned by GetDbCount if you use a group by clause. </remarks>
		int GetDbCount(IEntityCollection2 collection, IRelationPredicateBucket filter, IGroupByCollection groupByClause);
		/// <summary>
		/// Gets the number of rows returned by a query for the fields specified, using the filter and groupby clause specified. 
		/// </summary>
		/// <param name="fields">IEntityFields2 instance with the fields returned by the query to get the rowcount for</param>
		/// <param name="filter">filter to use by the query to get the rowcount for</param>
		/// <returns>the number of rows the query for the fields specified, using the filter, relations and groupbyClause specified.</returns>
		/// <remarks>This method performs a SELECT COUNT(*) FROM (actual query) and executes that as a scalar query. This construct is not supported on
		/// Firebird. You can try to achieve the same results by using GetScalar and AggregateFunction.CountRow, though those results can differ from
		/// the result returned by GetDbCount if you use a group by clause. </remarks>
		int GetDbCount(IEntityFields2 fields, IRelationPredicateBucket filter);
		/// <summary>
		/// Gets the number of rows returned by a query for the fields specified, using the filter and groupby clause specified. 
		/// </summary>
		/// <param name="fields">IEntityFields2 instance with the fields returned by the query to get the rowcount for</param>
		/// <param name="filter">filter to use by the query to get the rowcount for</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <returns>the number of rows the query for the fields specified, using the filter, relations and groupbyClause specified.</returns>
		/// <remarks>This method performs a SELECT COUNT(*) FROM (actual query) and executes that as a scalar query. This construct is not supported on
		/// Firebird. You can try to achieve the same results by using GetScalar and AggregateFunction.CountRow, though those results can differ from
		/// the result returned by GetDbCount if you use a group by clause. </remarks>
		int GetDbCount(IEntityFields2 fields, IRelationPredicateBucket filter, IGroupByCollection groupByClause);
		/// <summary>
		/// Gets the number of rows returned by a query for the fields specified, using the filter and groupby clause specified. 
		/// </summary>
		/// <param name="fields">IEntityFields2 instance with the fields returned by the query to get the rowcount for</param>
		/// <param name="filter">filter to use by the query to get the rowcount for</param>
		/// <param name="groupByClause">The list of fields to group by on. When not specified or an empty collection is specified, no group by clause
		/// is added to the query. A check is performed for each field in the selectList. If a field in the selectList is not present in the groupByClause
		/// collection, an exception is thrown.</param>
		/// <param name="allowDuplicates">When true, it will not filter out duplicate rows, otherwise it will DISTINCT duplicate rows.</param>
		/// <returns>the number of rows the query for the fields specified, using the filter, relations and groupbyClause specified.</returns>
		/// <remarks>This method performs a SELECT COUNT(*) FROM (actual query) and executes that as a scalar query. This construct is not supported on
		/// Firebird. You can try to achieve the same results by using GetScalar and AggregateFunction.CountRow, though those results can differ from
		/// the result returned by GetDbCount if you use a group by clause. </remarks>
		int GetDbCount(IEntityFields2 fields, IRelationPredicateBucket filter, IGroupByCollection groupByClause, bool allowDuplicates);
		/// <summary>
		/// Executes the passed in query as a scalar query and returns the value returned from this scalar execution. 
		/// </summary>
		/// <param name="queryToExecute">a scalar query, which is a SELECT query which returns a single value</param>
		/// <returns>the scalar value returned from the query.</returns>
		object ExecuteScalarQuery(IRetrievalQuery queryToExecute);
		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into the entity passed in. 
		/// </summary>
		/// <param name="entity">The entity to load the excluded field data into.</param>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the passed in entity. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.</remarks>
		void FetchExcludedFields(IEntity2 entity, ExcludeIncludeFieldsList excludedIncludedFields);
		/// <summary>
		/// Loads the data for the excluded fields specified in the list of excluded fields into all the entities in the entities collection passed in.
		/// </summary>
		/// <param name="entities">The entities to load the excluded field data into. The entities have to be either of the same type or have to be 
		/// in the same inheritance hierarchy as the entity which factory is set in the collection.</param>
		/// <param name="excludedIncludedFields">The excludedIncludedFields object as it is used when fetching the passed in collection. If you used 
		/// the excludedIncludedFields object to fetch only the fields in that list (i.e. excludedIncludedFields.ExcludeContainedFields==false), the routine
		/// will fetch all other fields in the resultset for the entities in the collection excluding the fields in excludedIncludedFields.</param>
		/// <remarks>The field data is set like a normal field value set, so authorization is applied to it.
		/// This routine batches fetches to have at most 5*ParameterisedPrefetchPathThreshold of parameters per fetch. Keep in mind that most databases have a limit
		/// on the # of parameters per query. 
		/// </remarks>
		void FetchExcludedFields(IEntityCollection2 entities, ExcludeIncludeFieldsList excludedIncludedFields);
		
		/// <summary>
		/// Gets or sets the parameterised prefetch path threshold. This threshold is used to determine when the prefetch path logic should switch to a 
		/// subquery or when it should use a WHERE field IN (value1, value2, ... valueN) construct, based on the # of elements in the parent collection.
		/// If that # of elements exceeds this threshold, a subquery is constructed, otherwise field IN (value1, value2, ...) construct is used.
		/// The default value is 50. On average, this is faster than using a subquery which returns 50 elements. Use this to tune prefetch path fetch logic
		/// for your particular needs. 
		/// <br/><br/>
		/// This threshold is also used to determine if paging is possible. A page size bigger than this threshold will disable the paging functionality
		/// when using paging + prefetch paths. 
		/// </summary>
		/// <remarks>Testing showed that values larger than 300 will be slower than a subquery.
		/// <br/><br/>
		/// Special thanks to Marcus Mac Innes (http://www.styledesign.biz) for this optimization code. 
		/// </remarks>
		int ParameterisedPrefetchPathThreshold { get; set; }
		/// <summary>
		/// Gets IsTransactionInProgress. True when there is a transaction in progress.
		/// </summary>
		bool IsTransactionInProgress {get;}
		/// <summary>
		/// Gets / sets the isolation level a transaction should use. 
		/// Setting this during a transaction in progress has no effect on the current running transaction.
		/// </summary>
		IsolationLevel TransactionIsolationLevel {get; set;}
		/// <summary>
		/// Gets the name of the transaction. Setting this during a transaction in progress has no effect on the current running transaction.
		/// </summary>
		string TransactionName {get; set;}
		/// <summary>
		/// Gets / sets the connection string to use for the connection with the database.
		/// </summary>
		string ConnectionString {get; set;}
		/// <summary>
		/// Gets / sets KeepConnectionOpen, a flag used to keep open connections after a database action has finished.
		/// </summary>
		bool KeepConnectionOpen {get; set;}
		/// <summary>
		/// Gets / sets the timeout value to use with the command object(s) created by the adapter.
		/// Default is 30 seconds
		/// Set this prior to calling a method which executes database logic.
		/// </summary>
		int CommandTimeOut {get; set;}
		/// <summary>
		/// Returns true if this DataAccessAdapter is hosted inside an IComPlusAdapterContext implementing object.
		/// This means that all transactions by this DataAccessAdapter object are routed through COM+ and not controlled by ADO.NET.
		/// </summary>
		bool InComPlusTransaction {get;}
		/// <summary>
		/// Gets a value indicating whether a System.Transactions transaction is going on. If not, false is returned.
		/// </summary>
		/// <value><c>true</c> if [in system transaction]; otherwise, <c>false</c>.</value>
		bool InSystemTransaction { get; }
	}


	/// <summary>
	/// Interface for the EntityCollection2 type. The collection defines typed basic collection behavior. 
	/// Adapter specific
	/// </summary>
	public interface IEntityCollection2 : IEnumerable
	{
		/// <summary>
		/// Event which is raised at the start of the Remove or RemoveAt(index) routine. To cancel the remove action, set cancel to true.
		/// </summary>
		event EventHandler<CancelableCollectionChangedEventArgs> EntityRemoving;
		/// <summary>
		/// Event which is raised at the End of the Remove or RemoveAt(index) routine.
		/// </summary>
		event EventHandler<CollectionChangedEventArgs> EntityRemoved;
		/// <summary>
		/// Event which is raised at the start of the Add or Insert(index) routine. To cancel the addition action, set cancel to true.
		/// </summary>
		event EventHandler<CancelableCollectionChangedEventArgs> EntityAdding;
		/// <summary>
		/// Event which is raised at the End of the Add or Insert(index) routine.
		/// </summary>
		event EventHandler<CollectionChangedEventArgs> EntityAdded;
		/// <summary>
		/// Event which is raised when the collection changed: an item changed, an item was removed, added, or the collection was cleared. 
		/// If possible, use one of the Entity* events of this collection.
		/// </summary>
		event ListChangedEventHandler ListChanged;

		/// <summary>
		/// Adds an IEntity2 object to the list.
		/// </summary>
		/// <param name="entityToAdd">Entity2 to add</param>
		/// <returns>Index in list</returns>
		int Add(IEntity2 entityToAdd);
		/// <summary>
		/// Adds the range of objects passed in. Objects have to be IEntity2 implementing objects
		/// </summary>
		/// <param name="c">Collection to add</param>
		void AddRange(IEntityCollection2 c);
		/// <summary>
		/// Inserts an IEntity2 on position Index
		/// </summary>
		/// <param name="index">Index where to insert the Object Entity</param>
		/// <param name="entityToAdd">Entity2 to insert</param>
		void Insert(int index, IEntity2 entityToAdd);
		/// <summary>
		/// Remove given IEntity2 instance from the list.
		/// </summary>
		/// <param name="entityToRemove">Entity2 object to remove from list.</param>
		void Remove(IEntity2 entityToRemove);
		/// <summary>
		/// Removes the IEntity instance at the index given.
		/// </summary>
		/// <param name="index">Index in list to remove the element.</param>
		void RemoveAt( int index );
		/// <summary>
		/// Returns true if the list contains the given IEntity2 Object
		/// </summary>
		/// <param name="entityToFind">Entity2 object to check.</param>
		/// <returns>true if Entity2 exists in list.</returns>
		bool Contains(IEntity2 entityToFind);
		/// <summary>
		/// Clears the collection.
		/// </summary>
		void Clear();
		/// <summary>
		/// Returns index in the list of given IEntity2 object.
		/// </summary>
		/// <param name="entityToFind">Entity2 Object to check</param>
		/// <returns>index in list.</returns>
		int IndexOf(IEntity2 entityToFind);
		/// <summary>
		/// copy the complete list of IEntity2 objects to an array of IEntity objects.
		/// </summary>
		/// <param name="destination">Array of IEntity2 Objects wherein the contents of the list will be copied.</param>
		/// <param name="index">Start index to copy from</param>
		void CopyTo(IEntity2[] destination, int index);
		/// <summary>
		/// Sets the entity information of the entity object containing this collection. Call this method only from
		/// entity classes which contain EntityCollection members, like 'Customer' which contains 'Orders' entity collection.
		/// </summary>
		/// <param name="containingEntity">The entity containing this entity collection as a member variable</param>
		/// <param name="fieldName">The field the containing entity has mapped onto the relation which delivers the entities contained
		/// in this collection</param>
		void SetContainingEntityInfo(IEntity2 containingEntity, string fieldName);
		/// <summary>
		/// Converts this entity collection to XML, recursively. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml(out string entityCollectionXml);
		/// <summary>
		/// Converts this entity collection to XML. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		void WriteXml(XmlDocument parentDocument, out XmlNode entityCollectionNode);
		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml(string rootNodeName, out string entityCollectionXml);
		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		void WriteXml(string rootNodeName, XmlDocument parentDocument, out XmlNode entityCollectionNode);
		/// <summary>
		/// Converts this entity collection to XML, recursively. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml( XmlFormatAspect aspects, out string entityCollectionXml );
		/// <summary>
		/// Converts this entity collection to XML. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		void WriteXml( XmlFormatAspect aspects, XmlDocument parentDocument, out XmlNode entityCollectionNode );
		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml( XmlFormatAspect aspects, string rootNodeName, out string entityCollectionXml );
		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		void WriteXml( XmlFormatAspect aspects, string rootNodeName, XmlDocument parentDocument, out XmlNode entityCollectionNode );
		/// <summary>
		/// Converts this entity collection to XML
		/// </summary>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		void WriteXml(XmlWriter writer, XmlFormatAspect aspects);
		/// <summary>
		/// Converts this entity collection to XML
		/// </summary>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		void WriteXml(XmlWriter writer, XmlFormatAspect aspects, string rootNodeName);
		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element
		/// of the entity collection's Xml data</param>
		void ReadXml(XmlNode node);
		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="xmlData">string with Xml data which should be read into this entity collection and its members. This string has to be in the
		/// correct format and should be loadable into a new XmlDocument without problems</param>
		void ReadXml(string xmlData);
		/// <summary>
		/// Applies sorting like IBindingList.ApplySort, on the field with the index fieldIndex and with the direction specified.
		/// </summary>
		/// <param name="fieldIndex">Field to sort on</param>
		/// <param name="direction">the sort direction</param>
		void Sort(int fieldIndex, ListSortDirection direction);
		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="fieldIndex">Field to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		void Sort(int fieldIndex, ListSortDirection direction, IComparer<object> comparerToUse);
		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="propertyName">property to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		void Sort(string propertyName, ListSortDirection direction, IComparer<object> comparerToUse);
		/// <summary>
		/// Gets all indices of all the entities in the current order of this collection which match the passed in filter. 
		/// </summary>
		/// <param name="filter">The filter the entity has to match with. If null, all entities match and every index is returned</param>
		/// <returns>List of indices of all entities matching the filter</returns>
		List<int> FindMatches( IPredicate filter );
		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in 
		/// this collection. Per entity type found, a new datatable is created inside destination. It will simply project every data element. 
		/// </summary>
		/// <param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
		/// e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void CreateHierarchicalProjection(DataSet destination);
		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in this collection,
		/// using the collectionProjections data passed in. Per entity type found, a new datatable is created inside destination.
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
		/// e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, DataSet destination);
		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in 
		/// this collection. Per entity type found, an entry is stored inside the destination dictionary. It will simply project every data element. 
		/// </summary>
		/// <param name="destination">The destination dictionary in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void CreateHierarchicalProjection(Dictionary<Type, IEntityCollection2> destination);
		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in this collection,
		/// using the collectionProjections data passed in. Per entity type found, an entry is stored inside the destination dictionary. 
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dictionary in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, Dictionary<Type, IEntityCollection2> destination);
		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with no filter nor sorter applied.
		/// </summary>
		/// <returns>new EntityView2 on this collection</returns>
		IEntityView2 CreateView();
		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter applied
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns>new EntityView2 on this collection</returns>
		IEntityView2 CreateView(IPredicate filter);
		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter and sorter applied to it.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <returns>new EntityView2 on this collection</returns>
		IEntityView2 CreateView(IPredicate filter, ISortExpression sorter);
		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter and sorter applied to it and the 
		/// dataChangeAction set to the passed in value.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="dataChangeAction">The data change action to take if data in the related collection changes.</param>
		/// <returns>new EntityView2 on this collection</returns>
		IEntityView2 CreateView(IPredicate filter, ISortExpression sorter, PostCollectionChangeAction dataChangeAction);
		
		/// <summary>
		/// Gets the default view for this entitycollection. The returned value is the same instance every time this property is read. 
		/// It's a new entity view without a filter or a sorter.
		/// </summary>
		/// <value>The default view.</value>
		IEntityView2 DefaultView { get;}
		/// <summary>
		/// Returns true if this collection contains dirty objects. If this collection contains dirty objects, an 
		/// already filled collection should not be refreshed until a save is performed. 
		/// </summary>
		bool ContainsDirtyContents {get;}
		/// <summary>
		/// The EntityFactory2 to use when creating entity objects when bound to a control and AddNew is enabled.
		/// </summary>
		IEntityFactory2 EntityFactoryToUse {get; set;}
		/// <summary>
		/// Simple indexer. 
		/// </summary>
		IEntity2 this [int index] {get; set;}
		/// <summary>
		/// The amount of IEntity2 elements in this entity collection
		/// </summary>
		int Count {get;}
		/// <summary>
		/// Get / set the readonly flag for this collection. 
		/// </summary>
		bool IsReadOnly {get; set;}
		/// <summary>
		/// Returns a readonly collection of entities which are flagged as dirty. 
		/// This collection is determined on the fly, you can use this collection to remove dirty entities from this entity collection.
		/// </summary>
		List<IEntity2> DirtyEntities {get;}
		/// <summary>
		/// When set to true, an entity passed to Add() or Insert() will be tested if it's already present. If so, the index is returned and the
		/// object is not added again. If set to false (default: true) this check is not performed. Setting this property to true can slow down fetch logic.
		/// DataAccessAdapter's fetch logic sets this property to false during a multi-entity fetch.
		/// </summary>
		bool DoNotPerformAddIfPresent {get; set;}
		/// <summary>
		/// Gets / sets the active context this entity collection is in. Setting this property is not adding the entity collection to the context, 
		/// it will make contained entities be added to the passed in context. If the entity collection is already in a context, setting this property has no effect. 
		/// Setting this property is done by framework code, use the Context's Add/Get methods to work with contexts and entity collections.
		/// </summary>
		Context ActiveContext { get; set; }	
		/// <summary>
		/// Gets / sets the IConcurrencyPredicateFactory instance to use when creating entity objects during an entity collection fetch
		/// </summary>
		IConcurrencyPredicateFactory ConcurrencyPredicateFactoryToUse { get; set;}
		/// <summary>
		/// Default: true. If set to false, no new entities will be added through databinding. 
		/// </summary>
		bool AllowNew { get; set;}
		/// <summary>
		/// Default: false. If set to true, entities can be removed through databinding.
		/// </summary>
		bool AllowRemove { get; set;}
		/// <summary>
		/// Default: true. If set to false, entities inside this collection won't be editable in a complex databinding scenario.
		/// </summary>
		bool AllowEdit { get; set;}
		/// <summary>
		/// Gets / sets the initial capacity of the entity collection. 
		/// </summary>
		int Capacity { get; set;}
		/// <summary>
		/// Gets or sets the entity collection which should be used as removed entities tracker. If this property is set to an IEntityCollection2 instance,
		/// all entities which are removed from this collection are marked for deletion and placed in this removed entities tracker collection.
		/// This collection can then later on be used to delete these entities from the database in one go.
		/// </summary>
		IEntityCollection2 RemovedEntitiesTracker { get; set;}
	}


	/// <summary>
	/// Interface for TypedView classes. 
	/// Adapter specific.
	/// </summary>
	public interface ITypedView2
#if !CF
		: IOwnedDataSerializable
#endif
	{
		/// <summary>
		/// Gets the IEntityFields2 collection of fields of this typed view. Use this method in combination with the FetchTypedView() methods in 
		/// DataAccessAdapter.
		/// </summary>
		/// <returns>Ready to use IEntityFields2 collection object.</returns>
		IEntityFields2 GetFieldsInfo();

		/// <summary>
		/// Returns the amount of rows in this typed view.
		/// </summary>
		int Count {get;}
	}


	/// <summary>
	/// Interface for TypedList classes. ITypedList is already defined in .NET, that's why it is suffixed with Lgp.
	/// Adapter specific.
	/// </summary>
	public interface ITypedListLgp2 : ITypedListCore
	{
		/// <summary>
		/// Gets the IEntityFields2 collection of fields of this typed view. Use this method in combination with the FetchTypedView() methods in 
		/// DataAccessAdapter.
		/// </summary>
		/// <returns>Ready to use IEntityFields2 collection object.</returns>
		IEntityFields2 GetFieldsInfo();
		/// <summary>
		/// Gets the IRelationPredicateBucket object which contains the relation information for this Typed List. Use this method in combination with the 
		/// FetchTypedList() methods in DataAccessAdapter.
		/// </summary>
		/// <returns>Ready to use IRelationPredicateBucket object.</returns>
		IRelationPredicateBucket GetRelationInfo();
	}


	/// <summary>
	/// Interface for the COM+ context class which controls the COM+ transaction flow towards the database server, if applicable. 
	/// It contains a normal DataAccessAdapter class to do the work, and the IComPlusAdapterContext implementing class is consulted
	/// by the DataAccessAdapter class in cases of transaction control and database connection creation. 
	/// </summary>
	public interface IComPlusAdapterContext
	{
		/// <summary>
		/// Returns the DataAccessAdapter object related to this COM+ context. Use this adapter instance to perform persistence actions
		/// inside the COM+ transaction this IComPlusAdapterContext implementing object is participating in.
		/// </summary>
		IDataAccessAdapter Adapter {get;}
	}


	/// <summary>
	/// General interface to access common properties of an EntityView(Of TEntity) without knowing the type of TEntity.
	/// </summary>
	public interface IEntityView2 : IEnumerable
	{
		/// <summary>
		/// Event which is fired when the entity collection related to this entityview is changed.
		/// </summary>
		event ListChangedEventHandler ListChanged;

		/// <summary>
		/// Determines whether this entity view contains the entity passed in. This method returns false if the entity is outside the filter, but in the related
		/// entity collection, as it's then not contained in the entity view.
		/// </summary>
		/// <param name="value">The entity to check</param>
		/// <returns>True if the entity is present, otherwise false.</returns>
		bool Contains( IEntity2 value );
		/// <summary>
		/// Determines the index of the entity passed in in the entity view in filtered and sorted state.
		/// </summary>
		/// <param name="value">The entity to get the index of.</param>
		/// <returns>Index of the entity in this entityview</returns>
		int IndexOf( IEntity2 value );
		/// <summary>
		/// Copies all entities in this view to a new entity collection and returns that collection. The returned collection is of
		/// the same type as the related collection. Entities aren't copied, just references to the entities.
		/// </summary>
		/// <returns>New collection with all entities in this view</returns>
		IEntityCollection2 ToEntityCollection();
		/// <summary>
		/// Copies all entities starting at startIndex in this view to a new entity collection and returns that collection. The returned collection is of
		/// the same type as the related collection. Entities aren't copied, just references to the entities.
		/// </summary>
		/// <param name="startIndex">The start index for the interval to copy to the entity collection</param>
		/// <returns>
		/// New collection with all entities in this view
		/// </returns>
		IEntityCollection2 ToEntityCollection( int startIndex );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, DataTable destination );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		void CreateProjection(List<IEntityPropertyProjector> propertyProjectors, DataTable destination , bool allowDuplicates);
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		void CreateProjection(List<IEntityPropertyProjector> propertyProjectors, DataTable destination , bool allowDuplicates, IPredicate filter);
		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityCollection2 destination );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection  using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		void CreateProjection(List<IEntityPropertyProjector> propertyProjectors, IEntityCollection2 destination , bool allowDuplicates);
		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection  using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		void CreateProjection(List<IEntityPropertyProjector> propertyProjectors, IEntityCollection2 destination , bool allowDuplicates, IPredicate filter);
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the project does with the data is up to the projector.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector );
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the project does with the data is up to the projector.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector, bool allowDuplicates);
		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the project does with the data is up to the projector.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector, bool allowDuplicates, IPredicate filter);

		/// <summary>
		/// Gets or sets the sorter for this entity view. Setting this property will re-sort the view and will reset the view in databinding scenario's.
		/// </summary>
		/// <value>The sort expression to use.</value>
		ISortExpression Sorter { get; set;}
		/// <summary>
		/// Gets or sets the filter to use for this entity view.
		/// </summary>
		/// <value>The filter to use</value>
		IPredicate Filter { get; set;}
		/// <summary>
		/// Gets the count of the view.
		/// </summary>
		/// <value>The count.</value>
		int Count { get;}
		/// <summary>
		/// Gets the <see cref="IEntity2"/> at the specified index in the view
		/// </summary>
		/// <value></value>
		IEntity2 this[int index] { get;}
		/// <summary>
		/// Gets/sets whether you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>; otherwise, false.</returns>
		/// <remarks>if the related collection is set to readonly, this operation is a no-op</remarks>
		bool AllowNew { get; set;}
		/// <summary>
		/// Gets whether you can remove items from the list, using <see cref="M:System.Collections.IList.Remove(System.Object)"></see> or <see cref="M:System.Collections.IList.RemoveAt(System.Int32)"></see>.
		/// </summary>
		/// <value></value>
		/// <remarks>if the related collection is set to readonly, this operation is a no-op</remarks>
		bool AllowEdit { get; set; }
		/// <summary>
		/// Gets / sets whether you can update items in the list.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can update the items in the list; otherwise, false.</returns>
		/// <remarks>if the related collection is set to readonly, this operation is a no-op</remarks>
		bool AllowRemove { get; set;}
		/// <summary>
		/// Gets the related collection set for this view.
		/// </summary>
		/// <value>The related collection.</value>
		IEntityCollection2 RelatedCollection { get; }
		/// <summary>
		/// Gets or sets the data change action which specifies what to do when the data in the related collection of an entity view changes. A change in 
		/// data can be: entity added or changed. If an entity is removed from the underlying collection, the entity is simply removed from the entity 
		/// view, as the view doesn't contain any data by itself.
		/// </summary>
		/// <value>The data change action.</value>
		PostCollectionChangeAction DataChangeAction { get; set;}
	}


	/// <summary>
	/// Internal interface for entity collection method access when the type of the collection isn't known.
	/// </summary>
	internal interface IEntityCollectionAccess2 : ICollectionMaintenance
	{
		/// <summary>
		/// Produces the actual XML for this entity collection, recursively. Because it recurses through contained entities,
		/// it keeps track of which objects are processed so cyclic references are not resulting in cyclic recursion and thus a crash.
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="processedObjectIDs">Hashtable with ObjectIDs of all the objects already processed. If an entity's ObjectID is in the
		/// hashtable's key list, a ProcessedObjectReference tag is emitted and the entity will not recurse further.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="emitFactory">if set to true, the XML will contain the factory name, otherwise it won't. Used in Compact25 format</param>
		/// <param name="isRootElement">if set to true, the start element produced is the absolute root element of the xml to produce.</param>
		void EntityCollection2Xml(string rootNodeName, XmlWriter writer, Dictionary<Guid, IEntity2> processedObjectIDs,
						XmlFormatAspect aspects, bool emitFactory, bool isRootElement);
		/// <summary>
		/// Performs the actual conversion from Xml to entity collection data. 
		/// </summary>
		/// <param name="node">current node which points to an entity collection node.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">list with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		void Xml2EntityCollection( XmlNode node, Dictionary<Guid, IEntity2> processedObjectIDs, List<NodeEntityReference> nodeEntityReferences );
		/// <summary>
		/// Performs the actual conversion from Xml to entity collection data.
		/// </summary>
		/// <param name="reader">The reader to read xml from.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">list with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		/// <remarks>Assumes Compact25 formatted xml is present in the reader.</remarks>
		void Xml2EntityCollection(XmlReader reader, Dictionary<Guid, IEntity2> processedObjectIDs, List<NodeEntityReference> nodeEntityReferences);
		/// <summary>
		/// Gets the cached pk hashes, if available, otherwise null
		/// </summary>
		/// <returns></returns>
		Dictionary<int, List<IEntity2>> GetCachedPkHashes();
		/// <summary>
		/// Sets the cached pk hashes to the passed dictionary
		/// </summary>
		/// <param name="pkHashes">The pk hashes.</param>
		void SetCachedPkHashes( Dictionary<int, List<IEntity2>> pkHashes );
	}

	#endregion

	#region Interfaces used by both adapter and selfservicing
	/// <summary>
	/// Interface for the auditor to be used with entity instances at runtime. Auditors audit at runtime various actions on entities and allow automatic persistence
	/// of audit information in audit entities when transactions are committed. 
	/// </summary>
	public interface IAuditor
	{
		/// <summary>
		/// Audits when an entity field's value is succesfully obtained from the passed in entity
		/// </summary>
		/// <param name="entity">The entity a field's value was obtained.</param>
		/// <param name="fieldIndex">Index of the field which value was obtained.</param>
		/// <remarks>Be careful when using this auditing routine, because a lot of calls will be made to this routine when data is for example shown in 
		/// a grid. Another thing to realize is that the audit information is stored inside the auditor which is inside an entity which might not be
		/// persisted/deleted later on. This means that if you use the audit data to produce entities which are then returned by GetAuditEntitiesToSave
		/// are never persisted if the entity this auditor is the auditor of is never persisted/deleted. In that situation, to get reliable journalling, 
		/// use an external service to log the audit data.</remarks>
		void AuditEntityFieldGet(IEntityCore entity, int fieldIndex);
		/// <summary>
		/// Audits when an entity field is set succesfully to a new value. 
		/// </summary>
		/// <param name="entity">The entity a field was set to a new value.</param>
		/// <param name="fieldIndex">Index of the field which got a new value.</param>
		/// <param name="originalValue">The original value of the field with the index passed in before it received a new value.</param>
		void AuditEntityFieldSet(IEntityCore entity, int fieldIndex, object originalValue);
		/// <summary>
		/// Audits the successful dereference of related entity from the entity passed in. 
		/// </summary>
		/// <param name="entity">The entity of which the related entity was dereferenced from.</param>
		/// <param name="relatedEntity">The related entity which was dereferenced from entity</param>
		/// <param name="mappedFieldName">Name of the mapped field onto the relation from entity to related entity for which the related entity was dereferenced.</param>
		void AuditDereferenceOfRelatedEntity(IEntityCore entity, IEntityCore relatedEntity, string mappedFieldName);
		/// <summary>
		/// Audits the successful reference of related entity from the entity passed in. 
		/// </summary>
		/// <param name="entity">The entity of which the related entity was dereferenced from.</param>
		/// <param name="relatedEntity">The related entity which was dereferenced from entity</param>
		/// <param name="mappedFieldName">Name of the mapped field onto the relation from entity to related entity for which the related entity was referenced.</param>
		void AuditReferenceOfRelatedEntity(IEntityCore entity, IEntityCore relatedEntity, string mappedFieldName);
		/// <summary>
		/// Audits the successful insert of a new entity into the database.
		/// </summary>
		/// <param name="entity">The entity saved successfully into the database.</param>
		void AuditInsertOfNewEntity(IEntityCore entity);
		/// <summary>
		/// Audits the successful update of an existing entity in the database
		/// </summary>
		/// <param name="entity">The entity updated successfully in the database.</param>
		void AuditUpdateOfExistingEntity(IEntityCore entity);
		/// <summary>
		/// Audits the succesful direct update of entities in the database.
		/// </summary>
		/// <param name="entity">The entity with the changed values which is used to produce the update query.</param>
		/// <param name="filter">The filter to filter out the entities to update. Can be null and can be an IPredicateExpression.</param>
		/// <param name="relations">The relations to use with the filter. Can be null.</param>
		/// <param name="numberOfEntitiesUpdated">The number of entities updated.</param>
		void AuditDirectUpdateOfEntities(IEntityCore entity, IPredicate filter, IRelationCollection relations, int numberOfEntitiesUpdated);
		/// <summary>
		/// Audits the successful delete of an entity from the database
		/// </summary>
		/// <param name="entity">The entity which was deleted.</param>
		/// <remarks>As the entity passed in was deleted succesfully, reading values from the passed in entity is only possible in this routine. After this call, the 
		/// state of the entity will be reset to Deleted again and reading the fields will result in an exception. It's also recommended not to reference
		/// the passed in entity in any audit entity you might want to persist as the entity doesn't exist anymore in the database.</remarks>
		void AuditDeleteOfEntity(IEntityCore entity);
		/// <summary>
		/// Audits the successful load of an entity from the database
		/// </summary>
		/// <param name="entity">The entity which was loaded. All data of the entity which was loaded is inside the entity.</param>
		/// <remarks>Be careful when using this auditing routine, because the audit information is stored inside the auditor which is inside an entity 
		/// which might not be persisted/deleted later on. This means that if you use the audit data to produce entities which are then 
		/// returned by GetAuditEntitiesToSave are never persisted if the entity this auditor is the auditor of is never persisted/deleted. 
		/// In that situation, to get reliable journalling, use an external service to log the audit data.</remarks>
		void AuditLoadOfEntity(IEntityCore entity);
		/// <summary>
		/// Audits the successful direct delete of entities in the database
		/// </summary>
		/// <param name="typeOfEntity">The type of entity of which entities were deleted.</param>
		/// <param name="filter">The filter to filter out the entities to delete. Can be null and can be an IPredicateExpression.</param>
		/// <param name="relations">The relations to use with the filter. Can be null.</param>
		/// <param name="numberOfEntitiesDeleted">The number of entities deleted.</param>
		void AuditDirectDeleteOfEntities(Type typeOfEntity, IPredicate filter, IRelationCollection relations, int numberOfEntitiesDeleted);
		/// <summary>
		/// Gets the audit entities to save. Audit entities contain the audit information stored inside this auditor.
		/// </summary>
		/// <returns>The list of audit entities to save, or null if there are no audit entities to save</returns>
		/// <remarks>Do not remove the audit entities and audit information from this auditor when this method is called, as the transaction in which 
		/// the save takes place can fail and retried which will result in another call to this method</remarks>
		IList GetAuditEntitiesToSave();
		/// <summary>
		/// Method which returns true if this auditor expects to have audit entities to persist and therefore needs a transaction.
		/// This method is called in the situation when there's no transaction going on though one should be started right before the single-statement action
		/// in the case if the auditor has entities to save afterwards. It's recommended to return true if the auditor might have audit entities
		/// to persist after an entity save/delete/direct update/direct delete of entities. Default: true
		/// </summary>
		/// <param name="actionToStart">The single statement action which is about to be started.</param>
		/// <returns>
		/// true if a transaction should be started prior to the action to perform (entity save/delete/direct update/direct delete of entities)
		/// false otherwise.
		/// </returns>
		/// <remarks>If false is returned and GetAuditEntitiesToSave returns 1 or more entities, a new transaction is started to save these audit entities
		/// which means that this transaction isn't re-tryable if this transaction might fail.</remarks>
		bool RequiresTransactionForAuditEntities(SingleStatementQueryAction actionToStart);
		/// <summary>
		/// The transaction with which the audit entities requested from GetAuditEntitiesToSave were saved. 
		/// Use this method to clear any audit data in this auditor as all audit information is persisted successfully.
		/// </summary>
		void TransactionCommitted();
		/// <summary>
		/// Method to serialze audit data to XML. Use the aspects passed in to determine various aspects of the XML format.
		/// If the audit data consists of entity instances, be sure to pass the passed in processedObjectIDs object to the WriteXml routine of IEntity2, so
		/// use the overload of IEntity2.WriteXml() which accepts a reader and the processedObjectIDs. Though it's recommended not to serialize entity objects
		/// in audit data, keep audit data as clean as possible from entity references.
		/// The start element 'Auditor' has already been written, the end element /Auditor will be written for you after this routine.
		/// </summary>
		/// <param name="writer">The writer.</param>
		/// <param name="aspects">The aspects.</param>
		/// <param name="processedObjectIDs">The objectIDs of entities already serialized.</param>
		/// <remarks>Adapter specific.</remarks>
		void WriteXml(XmlWriter writer, XmlFormatAspect aspects, Dictionary<Guid, IEntity2> processedObjectIDs);
		/// <summary>
		/// Reads the auditor data XML.
		/// </summary>
		/// <param name="auditorNode">The auditor node, which is the node of the Auditor element. The elements serialized by WriteXml are the children of
		/// this node.</param>
		/// <remarks>Adapter specific. Used in Verbose/Compact scenarios. For Compact25 format, use the XmlReader consuming overload.</remarks>
		void ReadXml(XmlNode auditorNode);
		/// <summary>
		/// Reads the auditor data XML.
		/// </summary>
		/// <param name="reader">The xml reader to read the xml from. The reader is positioned on the Auditor element. 
		/// The elements serialized by WriteXml are the children of this element. Read all xml till the reader is positioned on the end element of the Auditor
		/// element</param>
		/// <remarks>Adapter specific, Compact25 specific. For Verbose/Compact scenario's use the XmlNode consuming overload</remarks>
		void ReadXml(XmlReader reader);

		/// <summary>
		/// Gets if the auditor object has data which should be Xml serialized. If this property returns false, no serialization (and thus no deserialization) 
		/// will take place of the data to XML.
		/// </summary>
		/// <remarks>Used in Adapter</remarks>
		bool HasDataToXmlSerialize { get;}

	}


	/// <summary>
	/// Interface for the authorizer to be used with entity instances at runtime. Authorizers authorize at runtime field get/set actions as well as save/load/delete
	/// actions on entities. 
	/// </summary>
	public interface IAuthorizer
	{
		/// <summary>
		/// Determines whether the caller can obtain the value for the field with the index specified from the entity type specified. 
		/// </summary>
		/// <param name="entity">The entity instance to obtain the value from.</param>
		/// <param name="fieldIndex">Index of the field to obtain the value for.</param>
		/// <returns>true if the caller is allowed to obtain the value, false otherwise</returns>
		bool CanGetFieldValue(IEntityCore entity, int fieldIndex);
		/// <summary>
		/// Determines whether the caller can set the value for the field with the index specified of the entity type specified. 
		/// </summary>
		/// <param name="entity">The entity instance the field is located in.</param>
		/// <param name="fieldIndex">Index of the field to set the value of.</param>
		/// <returns>true if the caller is allowed to set the value, false otherwise</returns>
		bool CanSetFieldValue(IEntityCore entity, int fieldIndex);
		/// <summary>
		/// Determines whether the caller is allowed to load the data into the entity instance specified.
		/// </summary>
		/// <param name="entity">The entity instance to fill with data</param>
		/// <returns>true if the caller is allowed to load the data in the entity specified.</returns>
		///<remarks>Data inside the entity is the data fetched from the db. If the method returns false, the entity will be reset with a new set of empty fields</remarks>
		bool CanLoadEntity(IEntityCore entity);
		/// <summary>
		/// Determines whether the caller is allowed to save the new instance passed in.
		/// </summary>
		/// <param name="entity">The entity to save.</param>
		/// <returns>true if the caller is allowed to save the new instance passed in, false otherwise</returns>
		bool CanSaveNewEntity(IEntityCore entity);
		/// <summary>
		/// Determines whether the caller is allowed to save the modified existing instance passed in.
		/// </summary>
		/// <param name="entity">The entity to save.</param>
		/// <returns>true if the caller is allowed to save the new instance passed in, false otherwise</returns>
		bool CanSaveExistingEntity(IEntityCore entity);
		/// <summary>
		/// Determines whether the caller is allowed to update entities directly in the database. 
		/// </summary>
		/// <param name="entity">the entity which is passed in to the method to batch update the entities directly in the database, e.g. UpdateMulti (Selfservicing)
		/// or UpdateEntitiesDirectly (adapter)</param>
		/// <returns>true if the caller is allowed to perform the update, false otherwise</returns>
		bool CanBatchUpdateEntitiesDirectly(IEntityCore entity);
		/// <summary>
		/// Determines whether the caller is allowed to delete of the entity type passed in
		/// </summary>
		/// <param name="entity">The entity to delete.</param>
		/// <returns>true if the caller is allowed to delete the entity passed in, false otherwise</returns>
		bool CanDeleteEntity(IEntityCore entity);
		/// <summary>
		/// Determines whether the caller is allowed to delete entities directly in the database. 
		/// </summary>
		/// <param name="typeOfEntity">the type of the entity to batch delete instances of directly in the database, e.g. DeleteMulti (Selfservicing)
		/// or DeleteEntitiesDirectly (adapter)</param>
		/// <returns>true if the caller is allowed to perform the delete, false otherwise</returns>
		bool CanBatchDeleteEntitiesDirectly(Type typeOfEntity);
		/// <summary>
		/// Gets the result hint what to do when authorization fails when fetch a new entity.
		/// </summary>
		/// <returns>any of the FetchNewAuthorizationFailureResultHint values</returns>
		FetchNewAuthorizationFailureResultHint GetFetchNewAuthorizationFailureResultHint();
	}


	/// <summary>
	/// Interface for the generic ViewProjectionData class which contains projection data for entity views, used in hierarchical projections of data. 
	/// The data is applied to a view of all entities with the type specified as TEntity.
	/// </summary>
	public interface IViewProjectionData
	{
		/// <summary>
		/// Gets / sets the list of entity property projectors to project the view's data
		/// </summary>
		List<IEntityPropertyProjector> Projectors { get; set;}
		/// <summary>
		/// Gets / sets allowDuplicates, a flag to signal if duplicate results are allowed.
		/// </summary>
		bool AllowDuplicates { get; set;}
		/// <summary>
		/// Gets the type of the target entity.
		/// </summary>
		Type TypeOfTargetEntity { get; }
		///<summary>
		/// Gets the additional filter to apply to the data before projection. Only matching entities are projected
		/// </summary>
		/// <value>The additional filter.</value>
		IPredicate AdditionalFilter { get;}
		/// <summary>
		/// Creates the data relations in the dataset passed in for the relations passed in. Only create relations where the start entity is the PK side.
		/// </summary>
		/// <param name="destination">The destination to create the datarelations in.</param>
		/// <param name="relations">The relations to use for creating the datarelations.</param>
		void CreateDataRelations(DataSet destination, List<IEntityRelation> relations);
	}


	/// <summary>
	/// Interface which is used internally for getting a field's value when passing in an entity.
	/// </summary>
	public interface IEntityFieldCoreInterpret
	{
		/// <summary>
		/// Gets the value for the field implementing this interface for the entity passed in.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns>the value of the field in the entity passed in. If the field isn't present in the entity passed in, null is returned</returns>
		object GetValue( IEntityCore entity );
	}

	/// <summary>
	/// Interface which is used internally on a Predicate class to make the predicate interpret itself on the passed in entity.
	/// </summary>
	public interface IPredicateInterpret
	{
		/// <summary>
		/// Interprets the implementing class on the entity passed in.
		/// </summary>
		/// <param name="entity"></param>
		/// <returns>true if the predicte resolves to true for this entity, false otherwise</returns>
		bool Interpret( IEntityCore entity );
	}

	/// <summary>
	/// Interface which is used internally on an Expression class to make the expression interpret itself on the passed in entity.
	/// </summary>
	public interface IExpressionInterpret
	{
		/// <summary>
		/// Interprets the implementing expression class on the passed in entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns>The value the expression resolves to based on the entity passed in. Returns DBNull.Value if it resolves to null</returns>
		object GetValue( IEntityCore entity );
	}

	/// <summary>
	/// Interface to define a common interface between the factory interfaces for adapter and selfservicing.
	/// </summary>
	public interface IEntityFactoryCore
	{
		/// <summary>
		/// Creates the relations collection to the entity to join all targets so this entity can be fetched. 
		/// </summary>
		/// <returns>null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to
		/// join all targets together to fetch all subtypes of this entity and this entity itself</returns>
		IRelationCollection CreateHierarchyRelations();
		/// <summary>
		/// returns the name of the entity this factory is for, e.g. "EmployeeEntity"
		/// </summary>
		string ForEntityName { get;}
	}

	/// <summary>
	/// Relation factory interface for the Relations objects for each entity. This interface is used by InheritanceInfoProvider objects to produce
	/// relations which relate to the type/entity specified. 
	/// </summary>
	/// <remarks>This interface is only implemented on entities which are in a hierarchy of type TargetPerEntity</remarks>
	public interface IRelationFactory
	{
		/// <summary>
		/// Returns the relation object the entity, to which this relation factory belongs, has with the subtype with the specified name
		/// </summary>
		/// <param name="subTypeEntityName">name of direct subtype which is a subtype of the current entity through the relation to return.</param>
		/// <returns>relation which makes the current entity a supertype of the subtype entity with the name specified, or null if not applicable/found</returns>
		IEntityRelation GetSubTypeRelation(string subTypeEntityName);
		/// <summary>
		/// Returns the relation object the entity, to which this relation factory belongs, has with its supertype, if applicable.
		/// </summary>
		/// <returns>relation which makes the current entity a subtype of its supertype entity or null if not applicable/found</returns>
		IEntityRelation GetSuperTypeRelation();
	}


	/// <summary>
	/// Interface for inheritanceinfo provider objects and other inheritance information. 
	/// InheritanceInfo objects provide inheritance information at runtime for the DQE's and helper classes.
	/// The information inside these providers has to be statically constructed and should not change at runtime to make it threadsafe.
	/// These providers supply the DQE with detailed inheritance information so queries can be formed for any entity hierarchy.
	/// </summary>
	public interface IInheritanceInfoProvider
	{
		/// <summary>
		/// Gets an IInheritanceInfo object with the inheritance information for the entity with the supplied name. 
		/// </summary>
		/// <param name="entityName">name of the entity, like "CustomerEntity". This name is used for retrieving the information from
		/// a thread safe hashtable</param>
		/// <param name="startWithRoot">Set to <see langword="true"/> if the relations in
		/// <see cref="IInheritanceInfo.RelationsToHierarchyRoot"/> have to start with the root and walk downwards to the entityName
		/// entity, or set to false if the relations have to start at the entityname and move upwards to the root.</param>
		/// <returns>Ready to use IInheritanceInfo object if entityName is part of a hierarchy. If entityName isn't part of a
		/// hierarchy, null is returned. (not part of a hierarchy means: not a supertype nor a subtype</returns>
		IInheritanceInfo GetInheritanceInfo(string entityName, bool startWithRoot);
		/// <summary>
		/// This method returns all relations from the entityName to the root and from the entityName downwards to all the reachable leafs 
		/// from entityName. All relations to the root are INNER JOIN, all relations from entityName to leafs are LEFT JOIN
		/// </summary>
		/// <param name="entityName">name of the current entity on the path of which the hierarchy has to be determined. Example: "CustomerEntity"</param>
		/// <returns>collection with relations if entityName was found, or null if not.
		/// </returns>
		RelationCollection GetHierarchyRelations(string entityName);
		/// <summary>
		/// This method returns all relations from the lowest entity found in the passed in entityNames to the root and from the lowest entityName 
		/// downwards to all the reachable leafs from entityName. All relations to the root are INNER JOIN, all relations from the lowest entityName 
		/// to leafs are LEFT JOIN
		/// </summary>
		/// <param name="entityNames">1 or more names of entities on the same path of which the hierarchy has to be determined. Example of a name: "CustomerEntity"</param>
		/// <returns>collection with relations if all entityNames were found, or null if not.</returns>
		/// <remarks>This method is a wrapper around GetHierarchyRelations(name), to make finding the right collection more efficient. It finds the lowest
		/// entityname in the hierarchy and calls GetHierarchyRelations(name) with that name.</remarks>
		RelationCollection GetHierarchyRelations(List<string> entityNames);
		/// <summary>
		/// This method returns an array of IEntityFieldCore objects which contains all fields of all entities on the path: 
		/// entityName upwards to the root and entityName downwards to all leafs reachable from entityName, including entityName.
		/// </summary>
		/// <param name="entityName">name of the current entity on the path of which the hierarchy fields has to be determined. Example: "CustomerEntity"</param>
		/// <returns>Array of IEntityFieldCore objects, each element represents one field, or null if entityName isn't found</returns>
		IEntityFieldCore[] GetHierarchyFields(string entityName);
		/// <summary>
		/// Retrieves the factory for the entity represented by the values passed in, or null if entityName isn't present. The values have to 
		/// represent an entity of the type entityName or a subtype of that type. 
		/// </summary>
		/// <param name="entityName">name of the entity, like 'CustomerEntity'. This is the name of the root of the hierarchy to consider. 
		/// For example when fetching all managers, and manager derives from employee, this parameter is 'ManagerEntity', and only the manager type
		/// or its subtypes (direct or indirect) are considered. </param>
		/// <param name="values">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		IEntityFactoryCore GetEntityFactory(string entityName, object[] values, Dictionary<string, int> entityFieldStartIndexesPerEntity);
		/// <summary>
		/// Gets a predicateexpression which filters on the entity with type 'entityName'. Example of a valid name is 'CustomerEntity'. 
		/// </summary>
		/// <param name="entityName">Name of the entity to filter on, like 'CustomerEntity'</param>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false). </param>
		/// <returns>ready to use predicateexpression, or an empty predicate expression if entityName's value isn't an entity which is a hierarchical type.</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		IPredicateExpression GetEntityTypeFilter(string entityName, bool negate);
		/// <summary>
		/// Gets a predicateexpression which filters on the entity with type 'entityName'. Example of a valid name is 'CustomerEntity'.
		/// </summary>
		/// <param name="entityName">Name of the entity to filter on, like 'CustomerEntity'</param>
		/// <param name="objectAlias">The object alias to use for the filter.</param>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false).</param>
		/// <returns>ready to use predicateexpression, or an empty predicate expression if entityName's value isn't an entity which is a hierarchical type.</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		IPredicateExpression GetEntityTypeFilter(string entityName, string objectAlias, bool negate);
		/// <summary>
		/// Determines if typeToCheck is a subtype of superType.
		/// </summary>
		/// <param name="typeToCheck">Type to check.</param>
		/// <param name="superType">The supertype.</param>
		/// <returns>true if typeToCheck is a subtype of supertype, false otherwise. Also returns false is supertype isn't in a hierarchy.</returns>
		bool CheckIfIsSubTypeOf(string typeToCheck, string superType);
		/// <summary>
		/// Gets the type of the hierarchy.
		/// </summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <returns>the type of the hierarchy of the entity name specified</returns>
		InheritanceHierarchyType GetHierarchyType(string entityName);
		/// <summary>
		/// Gets all entity names in the provider.
		/// </summary>
		/// <returns>List with all entity names in the provider.</returns>
		List<string> GetAllEntityNamesInProvider();
		/// <summary>
		/// Gets the entity type filters for the entity names specified. It will use the object aliases specified for the entity names. 
		/// It will filter out entities which are in a hierarchy of type TargetPerEntity and will also filter out supertypes if the subtype
		/// is also in the list. Routine is used to add type filters to typedlists automatically for fields in TargetPerEntityHierarchy hierarchies.
		/// </summary>
		/// <param name="entityNamesWithAliases">The entity names with per entity name (key) the object alias.</param>
		/// <returns>PredicateExpression with per entity which needed a typefilter a predicate, added with AND</returns>
		IPredicateExpression GetEntityTypeFilters(Dictionary<string, string> entityNamesWithAliases);
	}


	/// <summary>
	/// Interface for objects which specify inheritance information for a certain entity. Instances of this interface are produced by
	/// <see cref="IInheritanceInfoProvider.GetInheritanceInfo"/>
	/// </summary>
	public interface IInheritanceInfo
	{
		/// <summary>
		/// Gets the type of the hierarchy.
		/// </summary>
		InheritanceHierarchyType HierarchyType {get; }
		/// <summary>
		/// Gets the relations to hierarchy root, starting at the root, to the owner entity, INNER JOINed
		/// </summary>
		RelationCollection RelationsToHierarchyRoot { get; }
		/// <summary>
		/// Gets the name of the super type entity. Example: "CustomerEntity"
		/// </summary>
		string SuperTypeEntityName { get; }
		/// <summary>
		/// The name of the entity which owns this information, of which this object belongs to.
		/// </summary>
		string OwnerEntityName { get; }
		/// <summary>
		/// List with all the entity names on the path to the root, starting with the <see cref="OwnerEntityName"/> and ending with the 
		/// root entity name of the hierarchy. If <see cref="OwnerEntityName"/> entity is a root entity, this collection contains one name: <see cref="OwnerEntityName"/>.
		/// </summary>
		List<string> EntityNamesOnHierarchyPath { get;}
		/// <summary>
		/// List with all the entity names on the paths from the <see cref="OwnerEntityName"/> entity to all the leafs in the hierarchy below the 
		/// <see cref="OwnerEntityName"/>. If the <see cref="OwnerEntityName"/> is a leaf, this list is empty.
		/// </summary>
		List<string> EntityNamesOfPathsToLeafs { get; }
		/// <summary>
		/// Gets the index of the discriminator column.
		/// </summary>
		/// <value>0 or higher for an entity in a TargetPerEntityHierarchy, otherwise undefined.</value>
		int DiscriminatorColumnIndex {get;}
		/// <summary>
		/// Gets the discriminator column value.
		/// </summary>
		/// <value>The discriminator value for the entity of this inheritance info, or undefined if the entity is not in a TargetPerEntityHierarchy.</value>
		object DiscriminatorColumnValue { get;}
		/// <summary>
		/// Gets the type filter if the entity which owns this information is in a TargetPerEntityHierarchy, null otherwise.
		/// </summary>
		IPredicateExpression TypeFilterTargetPerEntityHierarchy { get;}
	}

	
	/// <summary>
	/// Interface for ConcurrencyPredicateFactory objects which can be provided by the developer to produce at runtime predicate objects which will
	/// be added to the update query or delete query. The predicate is returned by the IEntity2 method GetConcurrencyPredicate. Especially useful
	/// in recursive saves.
	/// </summary>
	public interface IConcurrencyPredicateFactory
	{
		/// <summary>
		/// Creates the requested predicate of the type specified
		/// </summary>
		/// <param name="predicateTypeToCreate">The type of predicate to create</param>
		/// <param name="containingEntity">the entity object containing this IConcurrencyPredicateFactory instance.</param>
		/// <returns>A ready to use predicate to use in the query to execute. Can be null/Nothing, in which case the predicate is ignored</returns>
		IPredicateExpression CreatePredicate(ConcurrencyPredicateType predicateTypeToCreate, object containingEntity);
	}


	/// <summary>
	/// Interface definition for a bucket class which contains both a predicate expression and a relation collection which are related to each other 
	/// (the predicate expression works in combination with the relation collection's contents). Used in adapter's context however can also be used
	/// in other situations, for example custom templates.
	/// </summary>
	public interface IRelationPredicateBucket
	{
		/// <summary>
		/// The relation collection with EntityRelation objects which is used in combination with the PredicateExpression in this bucket
		/// </summary>
		IRelationCollection Relations {get;}
		/// <summary>
		/// The predicate expression to use in combination with the Relations in this bucket.
		/// </summary>
		IPredicateExpression PredicateExpression {get;}
	}


	/// <summary>
	/// Interface definition which defines the core IEntityField set. Is implemented by other interfaces like IEntityField and IEntityField2.
	/// Generic.
	/// </summary>
	public interface IEntityFieldCore : IEditableObject, IFieldInfo
	{
		/// <summary>
		/// Overwrites the current value with the value passed. This bypasses value checking and field properties like readonly. 
		/// Used by internal code only. Do not call this from your code.
		/// </summary>
		/// <param name="value">Value to store as the current value</param>
		void ForcedCurrentValueWrite(object value);
		/// <summary>
		/// Overwrites the current value with the value passed. This bypasses value checking and field properties like readonly. 
		/// Used by internal code only. Do not call this from your code.
		/// </summary>
		/// <param name="value">Value to store as the current value</param>
		/// <param name="dbValue">the value read from the database.</param>
		void ForcedCurrentValueWrite(object value, object dbValue);
		/// <summary>
		/// Overrides the GetHashCode() method. It will return the hashcode of the value of the field as the hashcode. 
		/// </summary>
		/// <returns>hashcode of the value of the field.</returns>
		int GetHashCode();
		/// <summary>
		/// Gets the discriminator column flag.
		/// </summary>
		/// <returns></returns>
		bool GetDiscriminatorColumnFlag();

		/// <summary>
		/// The alias to use for this field. Only used when this field object is part of a typed list. 
		/// Adapter: returns the alias set in the designer
		/// SelfServicing: returns Name
		/// </summary>
		string Alias {get; set;}
		/// <summary>
		/// Gets the current value for this field and sets the new value for this field, by overwriting current value. The value in 
		/// currentValue is discarded, versioning control has to save the original value of currentValue before this property is called. 
		/// </summary>
		/// <remarks>
		/// Calling this property directly will not trigger versioning control,
		/// thus calling this property directly is not recommended. Call <see cref="EntityBase.SetNewFieldValue(string, object)"/> instead.
		/// Type of the new value has to be the same as IFieldInfo.DataType, which is set in the
		/// constructor. If this field is set to readonly, an exception is raised. 
		/// </remarks>
		/// <exception cref="ORMFieldIsReadonlyException">The field is set to readonly and can't be changed.</exception>
		/// <exception cref="ORMValueTypeMismatchException">The value specified is not of the same IFieldInfo.DataType as this field.</exception>
		object CurrentValue {get;set;}
		/// <summary>
		/// Gets the value read from the database for this field. Use this field in optimistic concurrency predicates.
		/// Set by ForcedCurrentValueWrite(object, value) by the object fetcher logic.
		/// </summary>
		object DbValue {get;}
		/// <summary>
		/// If the value of this field is changed, this property is set to true. Set when <see cref="CurrentValue"/> receives a valid value. 
		/// </summary>
		bool IsChanged {get; set;}
		/// <summary>
		/// If the original value in the column for this entityfield is DBNull (NULL), this parameter should be set to true, otherwise to false.
		/// In BL Logic, it's impractical to work with NULL values, so these are converted to handable values. The developer can still determine if
		/// the original value was DBNull by checking this field. Using NULL values is not recommended. 
		/// If <see cref="IFieldPersistenceInfo.SourceColumnIsNullable"/> is false, IsNull is undefined.
		/// </summary>
		bool IsNull {get; set;}
		/// <summary>
		/// Alias for the object containing the field this entity field is mapped on. Used in typed list selection lists.
		/// </summary>
		string ObjectAlias {get; set;}
		/// <summary>
		/// The aggregate function to apply on this field in a select query. Ignored in INSERT/UPDATE/DELETE queries. 
		/// Designed to be used in TypedList/TypedView classes.
		/// </summary>
		AggregateFunction AggregateFunctionToApply {get; set;}
		/// <summary>
		/// The expression to apply to this field in a select list, update statement or predicate or expression.
		/// Expression is applied before AggregateFunctionToApply. 
		/// </summary>
		IExpression ExpressionToApply {get; set;}
		/// <summary>
		/// Gets / sets linkedSuperTypeField. Fields of PK/UC's are linked with eachother in a target-per-entity hierarchy. This is managed in
		/// the EntityFields(2) object.
		/// </summary>
		IEntityFieldCore LinkedSuperTypeField {get;set;}
	}


	/// <summary>
	/// General interface for static entity field information and isn't related to persistence info.
	/// </summary>
	public interface IFieldInfo
	{
		/// <summary>
		/// The name of the field. Name cannot be of zero length nor can they consist of solely spaces. Leading and trailing spaces are trimmed.
		/// </summary>
		/// <exception cref="ArgumentException">The value specified for Name is invalid.</exception>
		string Name { get;}
		/// <summary>
		/// The <see cref="System.Type"/> of the values of this field.
		/// </summary>
		System.Type DataType { get;}
		/// <summary>
		/// If set to true, in the constructor, this field will end up in the PrimaryKey field list of the containing IEntityFields object.
		/// </summary>
		bool IsPrimaryKey { get;}
		/// <summary>
		/// Will be true if this field can be set to NULL in the database, false otherwise. The Field Validation logic in an entity will use this
		/// flag to check if the field indeed can be set to NULL or not. Set by constructor.
		/// </summary>
		bool IsNullable { get; }
		/// <summary>
		/// Gets the field index related to this IEntityField, so the field can be used to retrieve the field index.
		/// </summary>
		int FieldIndex { get;}
		/// <summary>
		/// Name of the containing object this field belongs to (entity or typed view). This name is required to retrieve persistence information in Adapter
		/// Set via constructor. This name is also used by EntityRelation to determine alias - table connection.
		/// </summary>
		string ContainingObjectName { get;}
		/// <summary>
		/// If set to true, in the constructor, this field is part of a foreign key. This field is not used in LLBLGen Pro's code, however
		/// can be useful in user code.
		/// </summary>
		bool IsForeignKey { get;}
		/// <summary>
		/// If set to true, in the constructor, no changes can be made to this field. 
		/// </summary>
		bool IsReadOnly { get;}
		/// <summary>
		/// The maximum length of the value of the entityfield (string/binary data). Is ignored for entityfields which hold non-string and non-binary values.
		/// Value initially set for this field is the length of the database column this field is mapped on.
		/// </summary>
		int MaxLength { get; }
		/// <summary>
		/// The scale of the value for this field. 
		/// Value initially set for this field is the scale of the database column this field is mapped on.
		/// </summary>
		byte Scale { get; }
		/// <summary>
		/// The precision of the value for this field.
		/// Value initially set for this field is the precision of the database column this field is mapped on.
		/// </summary>
		byte Precision { get; }
		/// <summary>
		/// The name of the object this field is currently in. Differs only from ContainingObjectName if the field instance is in a subtype while it is
		/// originally defined in a supertype. 
		/// </summary>
		/// <example>EmployeeEntity.Name and a subtype, ClerkEntity, inherits this field. For ClerkEntity.Name ContainingObjectName is still 'EmployeeEntity'
		/// however ActualContainingObjectName is 'ClerkEntity'.</example>
		string ActualContainingObjectName { get;}
		/// <summary>
		/// Flag to signal if the field is in a multi-target entity. Used for alias production during query building in scenario's with inheritance.
		/// </summary>
		bool IsInMultiTargetEntity { get;}
	}


	/// <summary>
	/// Interface used for as a base for all Entity classes
	/// Generic specific
	/// </summary>
	public interface IEntityCore : IEditableObject
	{
		/// <summary>
		/// Event handler declaration for the event that is raised each time the one of values of this entity are changed.
		/// The event does not contain the value / field which is changed, it only signals subscribers the entity is changed
		/// and the subscriber should act accordingly, f.e. fire a ListChanged event.
		/// </summary>
		event EventHandler EntityContentsChanged;
		/// <summary>
		/// Event fired when a field / property is changed. To fire this event from a derived class, call OnPropertyChanged.
		/// </summary>
		event PropertyChangedEventHandler PropertyChanged;
		/// <summary>
		/// Event handler declaration for the event that is raised each time this entity is persisted. Related entities can subscribe to
		/// this event to start housekeeping actions, like syncing internal FK fields with the PK fields of this entity.
		/// </summary>
		event EventHandler AfterSave;
		/// <summary>
		/// Event which is raised at the start of the initialization routine of the entity. The entity is clean and has no entity fields object yet. 
		/// </summary>
		event EventHandler Initializing;
		/// <summary>
		/// Event which is raised at the end of the initialization routine of the entity. This event is also raised if the entity is pre-filled with a 
		/// filled EntityFields(2) object. In your handler, check the State property of the entity Fields to see if you're dealing with a new entity or with an 
		/// entity which is new, but pre-initialized with filled field objects.
		/// </summary>
		event EventHandler Initialized;

		/// <summary>
		/// Method which will fire the AfterSave event to signal that this entity is persisted and refetched succesfully.
		/// </summary>
		void FlagAsSaved();
		/// <summary>
		/// Sets the EntityField with the name fieldName to the new value value. Marks also the entityfields as dirty. Will refetch the complete entity's fields
		/// from the database if necessary (i.e. the entity is outofsync.).
		/// </summary>
		/// <param name="fieldName">Name of EntityField to set the new value of</param>
		/// <param name="value">Value to set</param>
		/// <returns>true if the value is actually set, false otherwise.</returns>
		/// <exception cref="ORMValueTypeMismatchException">The value specified is not of the same IEntityField.DataType as the field.</exception>
		/// <exception cref="ArgumentOutOfRangeException">The value specified has a size that is larger than the maximum size defined for the related column in the databas</exception>
		bool SetNewFieldValue(string fieldName, object value);
		/// <summary>
		/// Sets the EntityField on index fieldIndex to the new value value. Marks also the entityfields as dirty. Will refetch the complete entity's fields
		/// from the database if necessary (i.e. the entity is outofsync.).
		/// </summary>
		/// <param name="fieldIndex">Index of EntityField to set the new value of</param>
		/// <param name="value">Value to set</param>
		/// <returns>true if the value is actually set, false otherwise.</returns>
		bool SetNewFieldValue(int fieldIndex, object value);
		/// <summary>
		/// Gets the current value of the EntityField with the index fieldIndex. Will refetch the complete entity's fields
		/// from the database if necessary (i.e. the entity is outofsync.).
		/// </summary>
		/// <param name="fieldIndex">Index of EntityField to get the current value of</param>
		/// <returns>The current value of the EntityField specified</returns>
		/// <exception cref="ORMEntityIsDeletedException">When the entity is marked as deleted.</exception>
		/// <exception cref="ArgumentOutOfRangeException">When fieldIndex is smaller than 0 or bigger than the amount of fields in the fields collection.</exception>
		object GetCurrentFieldValue(int fieldIndex);
		/// <summary>
		/// Routine which will flag all subscribers of the EntityContentsChanged event that this entity's contents is changed.
		/// </summary>
		void FlagMeAsChanged();
		/// <summary>
		/// Creates the requested predicate of the type specified. If no IConcurrencyPredicateFactory instance is stored in this entity instance, null
		/// is returned.
		/// </summary>
		/// <param name="predicateTypeToCreate">The type of predicate to create</param>
		/// <returns>A ready to use predicate to use in the query to execute, or null/Nothing if no IConcurrencyPredicateFactory instance is present, 
		/// in which case the predicate is ignored</returns>
		IPredicateExpression GetConcurrencyPredicate(ConcurrencyPredicateType predicateTypeToCreate);
		/// <summary>
		/// Saves the current set of fields under the name specified in an internal hashtable. All data inside the field objects is preserved.
		/// If there is already a set of fields saved under the name specified, that set of fields is overwritten.
		/// </summary>
		/// <param name="name">Name to store the fields under. Case sensitive</param>
		/// <remarks>Creates a deep copy of the fields object.</remarks>
		/// <exception cref="InvalidOperationException">when this method is called while the object is participating in a transaction.</exception>
		void SaveFields(string name);
		/// <summary>
		/// Replaces the current set of fields with the fields saved under the name specified. If no set of fields is found with the name specified
		/// an exception is thrown. Removes the entry after a succesful rollback.
		/// </summary>
		/// <param name="name">Name under which the fields are stored which have to replace the current set of fields. Case sensitive</param>
		/// <remarks>replaces the current set of fields with the set of fields saved under the name specified. The current set of fields, with all the
		/// data are lost after a succesful rollback.</remarks>
		/// <exception cref="ArgumentException">thrown when the name specified is not found.</exception>
		/// <exception cref="InvalidOperationException">when this method is called while the object is participating in a transaction.</exception>
		void RollbackFields(string name);
		/// <summary>
		/// Removes all saved field sets from the internal hashtable, clearing up space. This method is also called when 
		/// an entity is saved.
		/// </summary>
		void DiscardSavedFields();
		/// <summary>Determines whether this entity is a subType of the entity represented by the passed in enum value, which represents a value in the EntityType enum</summary>
		/// <param name="typeOfEntity">Type of entity.</param>
		/// <returns>true if the passed in type is a supertype of this entity, otherwise false</returns>
		bool CheckIfIsSubTypeOf(int typeOfEntity);
		/// <summary>
		/// Sets the error message which is returned by IDataErrorInfo.Error
		/// </summary>
		/// <param name="errorMessage">the message to set</param>
		void SetEntityError( string errorMessage );
		/// <summary>
		/// Sets the error message for the field specified. If there's already a message stored for this field, it's overwritten unless append is
		/// set to true, which appends the message to the existing error using a semi-colon as separator. The message stored
		/// is returned by IDataErrorInfo[fieldName];
		/// </summary>
		/// <param name="fieldName">name of the field</param>
		/// <param name="errorMessage">message to store</param>
		/// <param name="append">If true, the value is appended to an already existing error message. As separator a semi-colon is used.</param>
		void SetEntityFieldError( string fieldName, string errorMessage, bool append );
		/// <summary>
		/// General validation method which isn't used by the LLBLGen Pro framework, but can be used by your own code to validate an entity at any given moment.
		/// </summary>
		void ValidateEntity();
		/// <summary>
		/// Converts the data inside inside this entity into XML, recursively. 
		/// </summary>
		/// <param name="entityXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml( out string entityXml );
		/// <summary>
		/// Converts the data inside inside this entity into XML, recursively. 
		/// </summary>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityNode">The XmlNode representing this complete entity object, including containing data.</param>
		void WriteXml( XmlDocument parentDocument, out XmlNode entityNode );
		/// <summary>
		/// Converts the data inside inside this entity into XML, recursively.
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity.</param>
		/// <param name="entityXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml( string rootNodeName, out string entityXml );
		/// <summary>
		/// Converts the data inside inside this entity into XML, recursively.
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityNode">The XmlNode representing this complete entity object, including containing data.</param>
		void WriteXml( string rootNodeName, XmlDocument parentDocument, out XmlNode entityNode );
		/// <summary>
		/// Converts this entity to XML, recursively. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="entityXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml( XmlFormatAspect aspects, out string entityXml );
		/// <summary>
		/// Converts this entity to XML, recursively. Uses the LLBLGenProEntityName for the rootnode name
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityNode">The XmlNode representing this complete entity object, including containing data.</param>
		void WriteXml( XmlFormatAspect aspects, XmlDocument parentDocument, out XmlNode entityNode );
		/// <summary>
		/// Converts this entity to XML, recursively. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity.</param>
		/// <param name="entityXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		void WriteXml( XmlFormatAspect aspects, string rootNodeName, out string entityXml );
		/// <summary>
		/// Converts this entity to XML, recursively. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityNode">The XmlNode representing this complete entity object, including containing data.</param>
		void WriteXml( XmlFormatAspect aspects, string rootNodeName, XmlDocument parentDocument, out XmlNode entityNode );
		/// <summary>
		/// Will fill the entity and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntity.WriteXml() and the Xml has to be compatible with the structure of this entity.
		/// </summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity and its members. Node's root element is the root element
		/// of the entity's Xml data</param>
		void ReadXml( XmlNode node );
		/// <summary>
		/// Will fill the entity and its containing members (recursively) with the data stored in the Xml string passed in. The string xmlData has to
		/// be filled with Xml in the format written by IEntity.WriteXml() and the Xml has to be compatible with the structure of this entity.
		/// </summary>
		/// <param name="xmlData">string with Xml data which should be read into this entity and its members. This string has to be in the
		/// correct format and should be loadable into a new XmlDocument without problems</param>
		void ReadXml( string xmlData );
		/// <summary>
		/// Gets a list of all the EntityRelation objects the type of this instance has. 
		/// </summary>
		/// <returns>A list of all the EntityRelation objects the type of this instance has. Hierarchy relations are excluded.</returns>
		List<IEntityRelation> GetAllRelations();

		/// <summary>
		/// Marker for the entity object if the object is new and should be inserted when saved (true) or read from the
		/// database (false).
		/// </summary>
		bool IsNew {get; set;}
		/// <summary>
		/// Marker for the entity object if the object is 'dirty' (changed, true) or not (false). Affects/reads .Fields.IsDirty.
		/// </summary>
		bool IsDirty {get; set;}
		/// <summary>
		/// The validator object used to validate the entity on several moments in the entity's life.
		/// </summary>
		IValidator Validator {get; set;}
		/// <summary>
		/// Gets / sets the unique Object ID which is created at runtime when the entity is instantiated. Can be used for external caches.
		/// </summary>
		Guid ObjectID {get; set;}
		/// <summary>
		/// Returns true if this entity instance is in the middle of a deserialization process, for example during a ReadXml() call.
		/// For internal use only. 
		/// </summary>
		bool IsDeserializing {get; set;}
		/// <summary>
		/// Gets / sets the IConcurrencyPredicateFactory to use for <see cref="GetConcurrencyPredicate"/>.
		/// </summary>
		IConcurrencyPredicateFactory ConcurrencyPredicateFactoryToUse {get; set;}
		/// <summary>
		/// Gets / sets the active context this entity is in. Setting this property is not adding the entity to the context, it will make contained
		/// entities be added to the passed in context. If the entity is already in a context, setting this property has no effect. 
		/// Setting this property is done by framework code, use the Context's Add/Get methods to work with contexts and entities.
		/// </summary>
		Context ActiveContext { get; set; }
		/// <summary>
		/// Returns the EntityType enum value for this entity.
		/// </summary>
		int LLBLGenProEntityTypeValue { get; }
		/// <summary>
		/// Returns the full name for this entity, which is important for the DAO to find back persistence info for this entity.
		/// </summary>
		/// <example>CustomerEntity</example>
		string LLBLGenProEntityName { get;}
		/// <summary>
		/// Gets or sets the TypeDefaultValue provider to use. This object is used to provide default values for value typed fields which are null 
		/// and not of type Nullable(Of T)
		/// </summary>
		ITypeDefaultValue TypeDefaultValueProviderToUse { get; set;}
		/// <summary>
		/// Gets or sets the Authorizer for this entity.
		/// </summary>
		IAuthorizer AuthorizerToUse { get; set;}
		/// <summary>
		/// Gets or sets the Auditor for this entity.
		/// </summary>
		IAuditor AuditorToUse { get; set;}
		/// <summary> The custom properties for the type of this entity instance.</summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		Dictionary<string, string> CustomPropertiesOfType { get;}
		/// <summary> The custom properties for the fields of the type of this entity instance. The returned Hashtable contains per fieldname a hashtable of name-value pairs. </summary>
		/// <remarks>The data returned from this property should be considered read-only: it is not thread safe to alter this data at runtime.</remarks>
		Dictionary<string, Dictionary<string, string>> FieldsCustomPropertiesOfType { get;}
	}


	/// <summary>
	/// Interface used for relations between IEntity* instances. 
	/// Generic
	/// </summary>
	public interface IEntityRelation
	{
		/// <summary>
		/// Adds a new pair of entity fields of type TEntityField to the relation, including persistence info. 
		/// Primary Key fields and Foreign Key Fields have to be added in pairs. Used by Adapter template set.
		/// </summary>
		/// <param name="primaryKeyField">The entity field instance which represents a field in the primary key in the relation</param>
		/// <param name="foreignKeyField">The entity field instance which represents the corresponding field in the foreign key in the relation</param>
		/// <typeparam name="TEntityField">The type of the fields.</typeparam>
		void AddEntityFieldPair<TEntityField>( TEntityField primaryKeyField, TEntityField foreignKeyField ) where TEntityField : IEntityFieldCore;
		/// <summary>
		/// Returns in an arraylist all IFieldPersistenceInfo objects for the FK fields in this entityrelation
		/// </summary>
		/// <returns>ArrayList with the requested objects</returns>
		List<IFieldPersistenceInfo> GetAllFKFieldPersistenceInfoObjects();
		/// <summary>
		/// Returns in an arraylist all IFieldPersistenceInfo objects for the PK fields in this entityrelation
		/// </summary>
		/// <returns>ArrayList with the requested objects</returns>
		List<IFieldPersistenceInfo> GetAllPKFieldPersistenceInfoObjects();
		/// <summary>
		/// Gets the IFieldPersistenceInfo data for the PK field at index specified.
		/// </summary>
		/// <param name="index">index of the field in the list of PK fields.</param>
		/// <returns>IFieldPersistenceInfo object</returns>
		IFieldPersistenceInfo GetPKFieldPersistenceInfo(int index);
		/// <summary>
		/// Gets the IFieldPersistenceInfo data for the FK field at index specified.
		/// </summary>
		/// <param name="index">index of the field in the list of FK fields.</param>
		/// <returns>IFieldPersistenceInfo object</returns>
		IFieldPersistenceInfo GetFKFieldPersistenceInfo(int index);
		/// <summary>
		/// Sets the IFieldPersistenceInfo data for the PK field at index specified.
		/// </summary>
		/// <param name="index">index of the field in the list of PK fields.</param>
		/// <param name="persistenceInfo">The persistence info for the entity field at position index.</param>
		/// <remarks>Used by DataAccessAdapter objects.</remarks>
		void SetPKFieldPersistenceInfo(int index, IFieldPersistenceInfo persistenceInfo);
		/// <summary>
		/// Sets the IFieldPersistenceInfo data for the FK field at index specified.
		/// </summary>
		/// <param name="index">index of the field in the list of FK fields.</param>
		/// <param name="persistenceInfo">The persistence info for the entity field at position index.</param>
		/// <remarks>Used by DataAccessAdapter objects.</remarks>
		void SetFKFieldPersistenceInfo(int index, IFieldPersistenceInfo persistenceInfo);
		/// <summary>
		/// Gets the IEntityFieldCode information about the PK field at index specified
		/// </summary>
		/// <param name="index">index of field in the list of PK fields</param>
		/// <returns>IEntityFieldCode object</returns>
		IEntityFieldCore GetPKEntityFieldCore(int index);
		/// <summary>
		/// Gets the IEntityFieldCode information about the FK field at index specified
		/// </summary>
		/// <param name="index">index of field in the list of FK fields</param>
		/// <returns>IEntityFieldCode object</returns>
		IEntityFieldCore GetFKEntityFieldCore(int index);
		/// <summary>
		/// Returns in an arraylist all IEntityFieldCore objects for the PK fields in this entityrelation
		/// </summary>
		/// <returns>ArrayList with the requested objects</returns>
		List<IEntityFieldCore> GetAllPKEntityFieldCoreObjects();
		/// <summary>
		/// Returns in an arraylist all IEntityFieldCore objects for the FK fields in this entityrelation
		/// </summary>
		/// <returns>ArrayList with the requested objects</returns>
		List<IEntityFieldCore> GetAllFKEntityFieldCoreObjects();
		/// <summary>
		/// Sets the aliases for the start entity and the end entity formed by the fields stored in this entityrelation. The start entity and end entity
		/// are determined based on the type of the relation and the primary key / foreign key fields. Mainly used by RelationCollection.Add(). 
		/// </summary>
		/// <param name="aliasStartEntity">the alias for the start entity in the relation. Alias is case sensitive. An alias with solely spaces or
		/// an empty string is ignored.</param>
		/// <param name="aliasEndEntity">the alias for the end entity in the relation Alias is case sensitive. An alias with solely spaces or
		/// an empty string is ignored.</param>
		void SetAliases(string aliasStartEntity, string aliasEndEntity);

		/// <summary>
		/// Custom filter for JOIN clauses which are added with AND to the ON clause resulting from this EntityRelation. By adding a
		/// predicate expression with fieldcomparevalue predicate objects for example, you can add extra filtering inside the JOIN.
		/// </summary>
		/// <remarks>If CustomFilterReplacesOnClause is set to true (default: false), the CustomFilter simply represents the ON clause.</remarks>
		IPredicateExpression CustomFilter { get; set;}
		/// <summary>
		/// The relation type the IEntityRelation instance represents.
		/// </summary>
		RelationType TypeOfRelation {get; set;}
		/// <summary>
		/// Flag to signal if this relation is a 'weak' relation or not. Weak relations are optional relations, which means when A and B have a 
		/// weak relation, not all instances of A have to have a related instance of B.
		/// </summary>
		bool IsWeak {get; }
		/// <summary>
		/// Returns the amount of fields in the EntityRelation object.
		/// </summary>
		int AmountFields {get;}
		/// <summary>
		/// Set to true if the start entity of the relation is the PK side of the relation. This is set in the generated code. 
		/// This property is true in 1:n relations and in 1:1 relations where the start entity is the PK side and the end entity is thus the
		/// FK side. Required for determining which alias belongs to which entity.
		/// </summary>
		bool StartEntityIsPkSide { get; set;}
		/// <summary>
		/// Flag to signal the join creator logic to use the CustomFilter specified as the ON clause, instead of appending the CustomFilter to the ON
		/// clause. Ignored if CustomFilter is null or empty. Default is false.
		/// </summary>
		bool CustomFilterReplacesOnClause {get; set;}
		/// <summary>
		/// Gets or sets the inheritance info for the pk side entity.
		/// </summary>
		IInheritanceInfo InheritanceInfoPkSideEntity { get; set;}
		/// <summary>
		/// Gets or sets the inheritance info for the fk side entity.
		/// </summary>
		IInheritanceInfo InheritanceInfoFkSideEntity { get; set;}
		/// <summary>
		/// Hint value for the consideration of the jointype of this relation. 
		/// Default: JoinHint.None
		/// </summary>
		JoinHint HintForJoins { get; set;}
		/// <summary>
		/// Alias value for the entity which is on the PK side of the relation. Determined from the relation type and the pk/fk fields
		/// </summary>
		string AliasPKSide { get; }
		/// <summary>
		/// Alias value for the entity which is on the FK side of the relation. Determined from the relation type and the pk/fk fields
		/// </summary>
		string AliasFKSide { get; }
		/// <summary>
		/// Gets the alias value for the start entity of the relation
		/// </summary>
		string AliasStartEntity { get;}
		/// <summary>
		/// Gets the alias value for the end entity of the relation
		/// </summary>
		string AliasEndEntity { get;}
		/// <summary>
		/// Gets or sets the name of the field mapped onto this relation in the start entity.
		/// </summary>
		string MappedFieldName { get;}
	}



	/// <summary>
	/// Interface for the GroupByCollection class which is used to collect EntityField(2) instances which are used for the 
	/// GROUP BY clause in a retrieval query. When a group by collection is specified in a retrieval query, all
	/// fields in the resultset have to be in this collection.
	/// Generic
	/// </summary>
	public interface IGroupByCollection
	{
		/// <summary>
		/// Adds the range of IEntityFieldCore fields to the groupbycollection.
		/// </summary>
		/// <param name="fieldsToAdd">The fields to add to this groupbycollection.</param>
		void AddRange(IEnumerable fieldsToAdd);
		/// <summary>
		/// Adds the passed in entity field instance to the list. Field objects can be added just once.
		/// </summary>
		/// <param name="fieldToAdd">entity field instance to add</param>
		/// <returns>Index of added field in the list.</returns>
		int Add<TEntityField>( TEntityField fieldToAdd ) where TEntityField : IEntityFieldCore;
		/// <summary>
		/// Inserts the field passed in on index specified.
		/// </summary>
		/// <param name="fieldToInsert">Entity field to insert</param>
		/// <param name="index">index on which the field should be inserted</param>
		/// <exception cref="InvalidOperationException">If the field is already added.</exception>
		void Insert<TEntityField>( TEntityField fieldToInsert, int index ) where TEntityField : IEntityFieldCore;
		/// <summary>
		/// Removes the passed in entity field instance. Finds the object to remove using value compare.
		/// </summary>
		/// <param name="fieldToRemove">Entity field instance to remove</param>
		void Remove<TEntityField>( TEntityField fieldToRemove ) where TEntityField : IEntityFieldCore;
		/// <summary>
		/// Removes the entity field instance at index specified from the collection.
		/// </summary>
		/// <param name="index">the index of the field to remove</param>
		void RemoveAt(int index);
		/// <summary>
		/// Returns the index of the field specified. 
		/// </summary>
		/// <param name="fieldToFind">field to determine the index of</param>
		/// <returns>index of field, if found, otherwise -1</returns>
		int IndexOf<TEntityField>( TEntityField fieldToFind ) where TEntityField : IEntityFieldCore;
		/// <summary>
		/// Checks if the field is in the list. Does a value compare, not an object reference compare. 
		/// </summary>
		/// <param name="fieldToCheck">Entity field to check for presence.</param>
		/// <returns>true if a similar field is found in the collection, false otherwise.</returns>
		bool Contains<TEntityField>( TEntityField fieldToCheck ) where TEntityField : IEntityFieldCore;
		/// <summary>
		/// Returns the IEntityFieldCore part of the field at position index
		/// </summary>
		/// <param name="index">index of field to return the IEntityFieldCore portion of</param>
		/// <returns>the IEntityFieldCore part of the field at position index</returns>
		IEntityFieldCore GetEntityFieldCore(int index);
		/// <summary>
		/// Returns the IFieldPersistenceInfo part of the field at position index
		/// </summary>
		/// <param name="index">index of field to return the IFieldPersistenceInfo portion of</param>
		/// <returns>the IFieldPersistenceInfo part of the field at position index</returns>
		IFieldPersistenceInfo GetFieldPersistenceInfo(int index);
		/// <summary>
		/// Sets the IFieldPersistenceInfo part of the field at position index.
		/// Adapter specific.
		/// </summary>
		/// <param name="persistenceInfo">The field persistence info object to set</param>
		/// <param name="index">index of field to set the persistence info of</param>
		void SetFieldPersistenceInfo(IFieldPersistenceInfo persistenceInfo, int index);
		/// <summary>
		/// Retrieves a ready to use text representation for the groupby collection
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the query</param>
		/// <returns>string which is usable as the argument for the GROUP BY clause in a query</returns>
		/// <remarks>Emits expressions on fields instead of the field names, if applicable.</remarks>
		string ToQueryText( ref int uniqueMarker );
		/// <summary>
		/// Retrieves a ready to use text representation for the groupby collection.
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the query</param>
		/// <param name="ignoreExpressions">If set to false (default), it will emit the expression of a field in the groupbycollection instead of the
		/// fieldname.</param>
		/// <returns>
		/// string which is usable as the argument for the GROUP BY clause in a query
		/// </returns>
		string ToQueryText( ref int uniqueMarker, bool ignoreExpressions );

		/// <summary>
		/// Indexer in the collection.
		/// </summary>
		IEntityFieldCore this [int index] {get;}
		/// <summary>
		/// The amount of items currently stored in the IGroupByCollection
		/// </summary>
		int Count {get;}
		/// <summary>
		/// Gets/sets the predicate expression which forms the having clause for this group by collection.
		/// </summary>
		IPredicateExpression HavingClause {get; set;}
		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		IDbSpecificCreator DatabaseSpecificCreator { get; set;}
		/// <summary>
		/// The list of parameters created when the groupby collection was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		List<IDataParameter> Parameters { get; }
	}



	/// <summary>
	/// Interface to define the relation between a parameter of a query and a field. This relation is used to find back a related EntityField
	/// when an Output Parameter is found in a query so the value of the Output Parameter can be assigned to the related EntityField.
	/// Generic
	/// </summary>
	public interface IParameterFieldRelation
	{
		/// <summary>
		/// The <see cref="IEntityFieldCore"/> in the relationship. Only settable via a constructor.
		/// </summary>
		IEntityFieldCore Field {get;}
		/// <summary>
		/// The Parameter in the relationship. Only settable via a constructor.
		/// </summary>
		IDataParameter Parameter {get; }
		/// <summary>
		/// The Typeconverter to use, if applicable.
		/// </summary>
		TypeConverter TypeConverterToUse {get;}

		/// <summary>
		/// Sets the field's value using ForceCurrentValueWrite with the value of the parameter.
		/// </summary>
		void Sync();
	}


	/// <summary>
	/// The interface for dynamic created queries.
	/// Generic
	/// </summary>
	public interface IQuery : IDisposable
	{
		/// <summary>
		/// The connection object to use with the <see cref="Command"/>
		/// </summary>
		IDbConnection Connection {get; set;}
		/// <summary>
		/// The command used for this query.
		/// </summary>
		IDbCommand Command {get; set;}
		/// <summary>
		/// The list of parameters used in the <see cref="Command"/>. 
		/// </summary>
		IList Parameters {get; }
		/// <summary>
		/// Array list with the <see cref="IParameterFieldRelation"/> instances for the relations between IEntityFields and output parameters.
		/// </summary>
		List<IParameterFieldRelation> ParameterFieldRelations {get;}
		/// <summary>
		/// Gets / sets the ExceptionInfoRetriever object to retrieve db specific info from a db specific exception.
		/// </summary>
		ExceptionInfoRetrieverBase ExceptionInfoRetriever { get; set;}

		/// <summary>
		/// Adds a new <see cref="IParameterFieldRelation"/> to the collection of <see cref="ParameterFieldRelations"/>. An output parameter can be
		/// stored once in the collection.
		/// </summary>
		/// <param name="relation">The <see cref="IParameterFieldRelation"/> to add</param>
		void AddParameterFieldRelation(IParameterFieldRelation relation);
		/// <summary>
		/// Will walk all <see cref="IParameterFieldRelation"/> instances of this query and reflect the parameter values in the related fields.
		/// Only output parameters are taken into account.
		/// </summary>
		void ReflectOutputValuesInRelatedFields();
		/// <summary>
		/// Wires the command of this query with the transaction passed in.
		/// </summary>
		/// <param name="transactionToWire">the transaction to wire the command with</param>
		void WireTransaction(IDbTransaction transactionToWire);
		/// <summary>
		/// Sets the command timeout.
		/// </summary>
		/// <param name="timeoutInterval">Timeout interval, in seconds.</param>
		void SetCommandTimeout(int timeoutInterval);
	}


	/// <summary>
	/// Interface for retrieval queries. These queries do return a resultset. Retrieval queries execute Select statements.
	/// Generic
	/// </summary>
	public interface IRetrievalQuery : IQuery
	{
		/// <summary>
		/// Executes the query contained by the IQuery instance. The connection has to be opened before calling Execute().
		/// </summary>
		/// <param name="behavior">The behavior setting to pass to the ExecuteReader method.</param>
		/// <returns>An open, ready to use IDataReader instance</returns>
		/// <exception cref="System.InvalidOperationException">When there is no command object inside the query object, 
		/// or no connection object inside the query object or the connection is closed.</exception>
		IDataReader Execute(CommandBehavior behavior);
		/// <summary>
		/// Executes the query contained by the IQuery instance as a scalar query. 
		/// </summary>
		/// <returns>the value returned by the scalar execution of the query</returns>
		object ExecuteScalar();

		/// <summary>
		/// Gets / sets the flag which signals fetch code to use client side (i.e. in code) limitation logic and it should not rely on the amount of rows
		/// returned for row limitations. This flag is set by DQEs if DISTINCT can't be used but row limitations are required and TOP is thus not reliable.
		/// Default: false.
		/// </summary>
		bool RequiresClientSideLimitation {get; set;}
		/// <summary>
		/// Used to set the amount of items to return for client side limitations. Only used if <see cref="RequiresClientSideLimitation"/> is true.
		/// </summary>
		long MaxNumberOfItemsToReturnClientSide {get; set;}
		/// <summary>
		/// Flag to tell the object fetcher to use manual distinct filtering, as the DISTINCT command couldn't be applied. Used to tell paging wrappers
		/// to set RequiresClientSidePaging.  
		/// </summary>
		bool RequiresClientSideDistinctFiltering { get; set;}
		/// <summary>
		/// Flag to tell the object fetcher to use manual paging. This is required when DISTINCT is required however due to DISTINCT violating types
		/// it can't be applied to the query. This then causes duplicates in the resultset, which shouldn't be there and thus causing pages with much
		/// lesser data. Only set by a DQE, normally false.
		/// </summary>
		bool RequiresClientSidePaging {get; set;}
		/// <summary>
		/// Only valid when RequiresClientSidePaging is set to true. Required to calculate the actual page start.
		/// </summary>
		int ManualPageNumber { get; set;}
		/// <summary>
		/// Only valid when RequiresClientSidePaging is set to true. Required to calculate the actual page start.
		/// </summary>
		int ManualPageSize { get; set;}
	}


	/// <summary>
	/// Interface for a predicate. Predicates are expressions which result in true or false, and which are used in WHERE clauses.
	/// Generic
	/// </summary>
	public interface IPredicate
	{
		/// <summary>
		/// The list of parameters created when the Predicate was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		List<IDataParameter> Parameters {get;}
		/// <summary>
		/// Flag for setting the Predicate to negate itself, i.e. to add 'NOT' to its result.
		/// </summary>
		bool Negate {get; set;}
		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		IDbSpecificCreator DatabaseSpecificCreator {get; set;}
		/// <summary>
		/// The PredicateType of this instance. Used to determine the instance nature without a lot of casting.
		/// </summary>
		int InstanceType {get; set;}

		/// <summary>
		/// Retrieves a ready to use text representation of the contained Predicate. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the predicate and also in the predicate expression(s) containing the predicate.</param>
		/// <returns>The contained Predicate in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IPredicate.DatabaseSpecificCreator is not set to a valid value.</exception>
		string ToQueryText(ref int uniqueMarker);
		/// <summary>
		/// Retrieves a ready to use text representation of the contained Predicate. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the predicate and also in the predicate expression(s) containing the predicate.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>The contained Predicate in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IPredicate.DatabaseSpecificCreator is not set to a valid value.</exception>
		string ToQueryText(ref int uniqueMarker, bool inHavingClause);
	}

	
	/// <summary>
	/// Interface for a PredicateExpression, which is a grouped set of Predicates. A predicate expression is usable as a WHERE clause.
	/// Generic
	/// </summary>
	public interface IPredicateExpression : IPredicate, IEnumerable
	{
		/// <summary>
		/// Adds an IPredicate implementing object to the PredicateExpression. This can be a Predicate derived class or a PredicateExpression. 
		/// If no object is present yet in the PredicateExpression, no operator is added, otherwise the object is added with an 'And'-operator. 
		/// </summary>
		/// <param name="predicateToAdd">The IPredicate implementing object to add</param>
		/// <exception cref="ArgumentNullException">When prPredicateToAdd is null</exception>
		/// <returns>the PredicateExpression on which this method is called, for command chaining</returns>
		IPredicateExpression Add(IPredicate predicateToAdd);
		/// <summary>
		/// Adds an IPredicate implementing object to the PredicateExpression with an 'Or'-operator. 
		/// The object added can be a Predicate derived class or a PredicateExpression. If no objects are present yet in the PredicateExpression,
		/// the operator is ignored. 
		/// </summary>
		/// <param name="predicateToAdd">The IPredicate implementing object to add</param>
		/// <exception cref="ArgumentNullException">When prPredicateToAdd is null</exception>
		/// <returns>the PredicateExpression on which this method is called, for command chaining</returns>
		IPredicateExpression AddWithOr(IPredicate predicateToAdd);
		/// <summary>
		/// Adds an IPredicate implementing object to the PredicateExpression with an 'And'-operator. 
		/// The object added can be a Predicate derived class or a PredicateExpression. If no objects are present yet in the PredicateExpression,
		/// the operator is ignored. 
		/// </summary>
		/// <param name="predicateToAdd">The IPredicate implementing object to add</param>
		/// <exception cref="ArgumentNullException">When prPredicateToAdd is null</exception>
		/// <returns>the PredicateExpression on which this method is called, for command chaining</returns>
		IPredicateExpression AddWithAnd(IPredicate predicateToAdd);
		/// <summary>
		/// Clears this instance.
		/// </summary>
		void Clear();

		/// <summary>
		/// Gets the predicate expression element at the index specified
		/// </summary>
		IPredicateExpressionElement this[int index] {get;}
		/// <summary>
		/// Gets the amount of predicate expression elements in this predicate expression. This is including all operators.
		/// </summary>
		int Count {get;}
	}

	
	/// <summary>
	/// Interface for action queries. These queries do not return a resultset. Action queries execute Insert, Delete and Update statements.
	/// Generic
	/// </summary>
	public interface IActionQuery : IQuery
	{
		/// <summary>
		/// Executes the query contained by the IQuery instance. 
		/// </summary>
		/// <returns>The number of rows affected (if applicable), otherwise 0.</returns>
		/// <exception cref="System.InvalidOperationException">When there is no command object inside the query object, 
		/// or no connection object inside the query object</exception>
		/// <exception cref="ORMQueryExecutionException">when an exception was caught during query execution</exception>
		int Execute();

		/// <summary>
		/// Array list of ISequenceRetrievalQuery objects which are used to produce sequence values for input/output parameters in
		/// this query. Normally this collection is empty, as it is only used when the target database provider doesn't support batched
		/// queries (firebird/access/sqlce and others). Execute will wire the transaction if present. 
		/// </summary>
		List<ISequenceRetrievalQuery> SequenceRetrievalQueries { get; }
		/// <summary>
		/// Gets the parameter parameter relations for this IActionQuery. These definitions are used for insert queries in multi-target entity inserts.
		/// </summary>
		List<ParameterParameterRelation> ParameterParameterRelations { get;}
	}


	/// <summary>
	/// Interface for sequence retrieval queries. Sequence retrieval queries are scalar queries (returning a value) which
	/// are used to retrieve the actual / to use sequence value in systems which do not support batched queries. Normally
	/// every DQE will batch the sequence retrieval query into the INSERT query as a batched query, however some systems
	/// do not support this and the only solution is the SequenceRetrievalQuery. Used for Access, Firebird and other systems.
	/// SequenceRetrievalQueries can be added to IActionQuery instances and will use the IActionQuery object's connection object.
	/// </summary>
	public interface ISequenceRetrievalQuery : IDisposable
	{
		/// <summary>
		/// Executes the scalar query contained in this object. (Executed with ExecuteScalar())
		/// Expects that the command can be executed without problems.
		/// </summary>
		/// <remarks>Will store its value in the sequence parameters after execution</remarks>
		/// <exception cref="System.InvalidOperationException">When there is no command object set</exception>
		/// <exception cref="ORMQueryExecutionException">when an exception was caught during query execution</exception>
		void Execute();

		/// <summary>
		/// The Scalar command used to retrieve the used/to use sequence value. This command will be executed as a scalar query and depending on
		/// ExecuteSequenceCommandFirst it will be executed before or after the actual query.
		/// </summary>
		IDbCommand SequenceRetrievalCommand {get; set;}
		/// <summary>
		/// Flag to signal if SequenceRetrievalCommand has to be executed before (true) or after (false) the 
		/// actual query in this ActionQuery object. 
		/// </summary>
		bool ExecuteSequenceCommandFirst {get; set;}
		/// <summary>
		/// Array list with the parameter objects in the actual query which need the value returned by the execution of the command
		/// </summary>
		List<IDataParameter> SequenceParameters {get;}
		/// <summary>
		/// Used to make SequenceParameters 'output' parameters. Required for Access. Default: false;
		/// </summary>
		bool SetParametersAsOutputParameters { get ; set;}
	}


	/// <summary>
	/// Interface used for the elements which are physically stored in a PredicateExpression.
	/// Generic
	/// </summary>
	public interface IPredicateExpressionElement
	{
		/// <summary>
		/// The type of the Element. 
		/// </summary>
		PredicateExpressionElementType Type {get; set;}
		/// <summary>
		/// The contents of the Element
		/// </summary>
		object Contents {get; set;}
	}
	
	
	/// <summary>
	/// Interface which holds the generic information for entity field persistence of an entity field. Instances of this interface
	/// are passed to logic with an instance of the IEntityFieldCore interface. SelfServicing implements both interfaces in one interface: IEntityField.
	/// Generic
	/// </summary>
	public interface IFieldPersistenceInfo
	{
		/// <summary>
		/// The name of the catalog the SourceSchemaName is located in. 
		/// </summary>
		string SourceCatalogName {get;}
		/// <summary>
		/// The name of the schema which holds <see cref="SourceObjectName"/>. Schema is used to generate SQL on the fly. 
		/// A common schema name in SqlServer is f.e. 'dbo'.
		/// </summary>
		string SourceSchemaName {get;}
		/// <summary>
		/// The name of the source object which holds <see cref="SourceColumnName"/>. Can be a view or a table (or synonym of those). 
		/// Used to generate SQL on the fly.
		/// </summary>
		string SourceObjectName {get;}
		/// <summary>
		/// The name of the corresponding column in a view or table for an entityfield. This name is used to map a column in a resultset onto the entity field.
		/// </summary>
		string SourceColumnName {get;}
		/// <summary>
		/// The maximum length of the value of the entityfield (string/binary data). Is ignored for entityfields which hold non-string and non-binary values.
		/// ColumnMaxLength
		/// Used for update/insert operations on the column
		/// </summary>
		int SourceColumnMaxLength {get;}
		/// <summary>
		/// The type of the Column mapped onto the EntityField. The value stored here is the integer representation of the enum value of the type, f.e.
		/// SqlDbType.Int or OracleType.Int16
		/// Used for update/insert operations on the column
		/// </summary>
		int SourceColumnDbType {get;}
		/// <summary>
		/// Flag if the Column mapped onto the entityfield is nullable or not. 
		/// Used for update/insert operations on the column
		/// </summary>
		bool SourceColumnIsNullable {get;}
		/// <summary>
		/// The scale of the Column mapped onto the entityfield.
		/// Used for update/insert operations on the column
		/// </summary>
		byte SourceColumnScale {get;}
		/// <summary>
		/// The precision of the Column mapped onto the entityfield.
		/// Used for update/insert operations on the column
		/// </summary>
		byte SourceColumnPrecision {get;}
		/// <summary>
		/// If set to true, the Dynamic Query Engine (DQE) will assume the field is an Identity field and will act accordingly (i.e.: as the target database
		/// handles Identity fields: SqlServer will generate a new value itself, Oracle wants to have a sequence input.
		/// </summary>
		bool IsIdentity {get; }
		/// <summary>
		/// If <see cref="IsIdentity"/> is set to true, this property has to be set to the name of the sequence which supplies the value for the EntityField's
		/// corresponding table field. On SqlServer this is @@IDENTITY or SCOPE_IDENTITY() and only used when the row is succesfully inserted, however on Oracle
		/// this value is used to specify a new value and to retrieve the new value. Is undefined when <see cref="IsIdentity"/> is set to false.
		/// </summary>
		string IdentityValueSequenceName {get;}
		/// <summary>
		/// Gets the type converter to use. Only set through constructor and when a conversion is required from the .NET type returned by the 
		/// ADO.NET provider and the defined .NET type for this field.
		/// </summary>
		TypeConverter TypeConverterToUse { get; }
		/// <summary>
		/// The .NET type of the field in the DB. This value is used to convert a currentvalue back to this type using TypeConverterToUse. 
		/// </summary>
		Type ActualDotNetType { get;}
	}


	/// <summary>
	/// Interface for DatabaseSpecificCreator objects, which use the Strategy pattern to supply IPredicate implementations with a way to
	/// create parameter objects, field names, including prefix/postfix characters, and conversion routines, which suit the target database.
	/// Generic
	/// </summary>
	public interface IDbSpecificCreator
	{
		/// <summary>
		/// Creates a valid Parameter based on the passed in IEntityField implementation.
		/// </summary>
		/// <param name="field">IEntityField instance used to base the parameter on.</param>
		/// <param name="direction">The direction for the parameter</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		IDataParameter CreateParameter(IEntityField field, ParameterDirection direction);
		/// <summary>
		/// Creates a valid Parameter based on the passed in IEntityFieldCore implementation and the passed in IFieldPersistenceInfo instance
		/// </summary>
		/// <param name="field">IEntityFieldCore instance used to base the parameter on.</param>
		/// <param name="persistenceInfo">Persistence information to create the parameter.</param>
		/// <param name="direction">The direction for the parameter</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		IDataParameter CreateParameter(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ParameterDirection direction);
		/// <summary>
		/// Creates a valid Parameter based on the passed in IEntityFieldCore implementation and the passed in IFieldPersistenceInfo instance
		/// </summary>
		/// <param name="field">IEntityFieldCore instance used to base the parameter on.</param>
		/// <param name="persistenceInfo">Persistence information to create the parameter.</param>
		/// <param name="direction">The direction for the parameter</param>
		/// <param name="value">Value to set the parameter to.</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		IDataParameter CreateParameter(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, ParameterDirection direction, object value);
		/// <summary>
		/// Creates a parameter based on the fieldcore passed in and the value passed in. The value is used to determine the DB type. 
		/// No precision/scale/length is set, this is left to the IDataParameter implementing object. This method is used to
		/// produce parameters for expression values. 
		/// </summary>
		/// <param name="name">name to be used for the parameter.</param>
		/// <param name="direction">Direction for the parameter</param>
		/// <param name="value">value the parameter is for.</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		IDataParameter CreateParameter(string name, ParameterDirection direction, object value);
		/// <summary>
		/// Creates a valid Parameter for the pattern in a LIKE statement. This is a special case, because it shouldn't rely on the type of the
		/// field the LIKE statement is used with but should be the unicode varchar type. 
		/// </summary>
		/// <param name="fieldName">The name of the field the LIKE statement is used with.</param>
		/// <param name="pattern">The pattern to be passed as the value for the parameter. Is used to determine length of the parameter.</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		IDataParameter CreateLikeParameter(string fieldName, string pattern);
		/// <summary>
		/// Creates a valid Parameter for the pattern in a LIKE statement. This is a special case, because it shouldn't rely on the type of the
		/// field the LIKE statement is used with but should be the unicode varchar type. 
		/// </summary>
		/// <param name="fieldName">The name of the field the LIKE statement is used with.</param>
		/// <param name="pattern">The pattern to be passed as the value for the parameter. Is used to determine length of the parameter.</param>
		/// <param name="targetFieldDbType">Type of the target field db</param>
		/// <returns>Valid parameter for usage with the target database.</returns>
		IDataParameter CreateLikeParameter(string fieldName, string pattern, int targetFieldDbType);
		/// <summary>
		/// Creates a valid field name based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. This field name is
		/// not padded with an alias if that alias should be created. Effectively, this is the
		/// same as CreateFieldName(field persistence info, fieldname, false);
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance used to formulate the fieldname</param>
		/// <param name="fieldName">name of the entity field, to determine if an alias is required</param>
		/// <param name="objectAlias">Alias of object the field maps to. Only specified when called from a predicate.</param>
		/// <param name="containingObjectName">Name of the containing object which defined the field with name fieldName.</param>
		/// <param name="actualContainingObjectName">Name of the containing object which actually holds the field with the name fieldname.</param>
		/// <returns>Valid field name for usage with the target database.</returns>
		string CreateFieldName(IFieldPersistenceInfo persistenceInfo, string fieldName, string objectAlias, string containingObjectName, string actualContainingObjectName);
		/// <summary>
		/// Creats a valid field name based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. 
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance used to formulate the fieldname</param>
		/// <param name="fieldName">name of the entity field, to determine if an alias is required</param>
		/// <param name="objectAlias">Alias of object the field maps to. Only specified when called from a predicate.</param>
		/// <param name="appendAlias">When true, the routine should construct an alias construction statement.</param>
		/// <param name="containingObjectName">Name of the containing object which defined the field with name fieldName.</param>
		/// <param name="actualContainingObjectName">Name of the containing object which actually holds the field with the name fieldname.</param>
		/// <returns>Valid field name for usage with the target database.</returns>
		string CreateFieldName(IFieldPersistenceInfo persistenceInfo, string fieldName, string objectAlias, bool appendAlias, string containingObjectName, string actualContainingObjectName);
		/// <summary>
		/// Creates the name for the field, and takes into account an aggregate function present and an expression present. If one or both are present, the
		/// field is replaced with (expression) or surrounded with (aggregate) the function (if applyAggregateFunction is true).
		/// </summary>
		/// <param name="fieldCore">fieldcore part of the field. Required to determine expression and aggregate function</param>
		/// <param name="persistenceInfo">persistence info object for the field.</param>
		/// <param name="fieldName">name for the field to be used</param>
		/// <param name="objectAlias">Alias for object hte field belongs to</param>
		/// <param name="uniqueMarker">uniquemarker variable for expression's toquerytext method.</param>
		/// <param name="applyAggregateFunction">flag to apply aggregate function or not. Aggregate functions can't be applied when the call originates
		/// from a predicate which is not part of a having clause.</param>
		/// <returns>string representing the field</returns>
		string CreateFieldName(IEntityFieldCore fieldCore, IFieldPersistenceInfo persistenceInfo, string fieldName, string objectAlias, ref int uniqueMarker, bool applyAggregateFunction);
		/// <summary>
		/// Creates a valid field name based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. This field name is
		/// not padded with an alias if that alias should be created. Effectively, this is the
		/// same as CreateFieldNameSimple(field persistence info, fieldname, false);. The fieldname is 'simple' in that
		/// it doesn't contain any catalog, schema or table references. 
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance used to formulate the fieldname</param>
		/// <param name="fieldName">name of the entity field, to determine if an alias is required</param>
		/// <returns>Valid field name for usage with the target database.</returns>
		string CreateFieldNameSimple(IFieldPersistenceInfo persistenceInfo, string fieldName);
		/// <summary>
		/// Creats a valid field name based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. The fieldname is 'simple' in that
		/// it doesn't contain any catalog, schema or table references. 
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance used to formulate the fieldname</param>
		/// <param name="fieldName">name of the entity field, to determine if an alias is required</param>
		/// <param name="appendAlias">When true, the routine should construct an alias construction statement.</param>
		/// <returns>Valid field name for usage with the target database.</returns>
		string CreateFieldNameSimple(IFieldPersistenceInfo persistenceInfo, string fieldName, bool appendAlias);
		/// <summary>
		/// Creates a valid object name (f.e. a name for a table or view) based on the passed in IFieldPersistenceInfo implementation. The fieldname is
		/// ready to use in queries and contains all pre/postfix characters required. 
		/// </summary>
		/// <param name="persistenceInfo">IFieldPersistenceInfo instance which source object info is used to formulate the objectname</param>
		/// <returns>Valid object name</returns>
		string CreateObjectName(IFieldPersistenceInfo persistenceInfo);
		/// <summary>
		/// Converts the passed in comparison operator to a string usable in a query.
		/// </summary>
		/// <param name="operatorToConvert">Operator to convert to string</param>
		/// <returns>The string representation usable in a query of the operator passed in.</returns>
		string ConvertComparisonOperator(ComparisonOperator operatorToConvert);
		/// <summary>
		/// Converts the passed in sort operator to a string usable in a query
		/// </summary>
		/// <param name="operatorToConvert">sort operator to convert to a string</param>
		/// <returns>The string representation usable in a query of the operator passed in.</returns>
		string ConvertSortOperator(SortOperator operatorToConvert);
		/// <summary>
		/// Converts the passed in expression operator (exop) to a string usable in a query 
		/// </summary>
		/// <param name="operatorToConvert">Expression operator to convert to a string</param>
		/// <returns>The string representation usable in a query of the operator passed in.</returns>
		string ConvertExpressionOperator(ExOp operatorToConvert);
		/// <summary>
		/// Converts the passed in set operator to a string usable in a query 
		/// </summary>
		/// <param name="operatorToConvert">Set operator to convert to a string</param>
		/// <returns>The string representation usable in a query of the operator passed in.</returns>
		string ConvertSetOperator(SetOperator operatorToConvert);
		/// <summary>
		/// Returns the SQL functionname to make a string uppercase.
		/// </summary>
		/// <returns></returns>
		string ToUpperFunctionName();
		/// <summary>
		/// Creates a new Select Query which is ready to use as a subquery, based on the specified select list and the specified set of relations.
		/// </summary>
		/// <param name="selectList">list of IEntityFieldCore objects to select</param>
		/// <param name="fieldPersistenceInfos">Array of IFieldPersistenceInfo objects to use to build the select query</param>
		/// <param name="selectFilter">A complete IPredicate implementing object which contains the filter for the rows to select. When set to null, no 
		/// filtering is done, and all rows are returned.</param>
		/// <param name="maxNumberOfItemsToReturn"> The maximum number of items to return with this retrieval query. 
		/// If the used Dynamic Query Engine supports it, 'TOP' is used to limit the amount of rows to return. 
		/// When set to 0, no limitations are specified.</param>
		/// <param name="sortClauses">The order by specifications for the sorting of the resultset. When not specified, no sorting is applied.</param>
		/// <param name="relationsToWalk">list of EntityRelation objects, which will be used to formulate a FROM clause with INNER JOINs.</param>
		/// <param name="groupByClause">the group by clause to use</param>
		/// <param name="uniqueMarker">a unique marker value to use. </param>
		/// <returns>IRetrievalQuery instance which is ready to be used.</returns>
		/// <exception cref="System.ArgumentNullException">When selectList is null or fieldsPersistenceInfo is null or relationsToWalk is null</exception>
		/// <exception cref="System.ArgumentException">When selectList contains no EntityFieldCore instances or fieldsPersistenceInfo is empty.</exception>
		IRetrievalQuery CreateSubQuery(IEntityFieldCore[] selectList, IFieldPersistenceInfo[] fieldPersistenceInfos,
			IPredicate selectFilter, long maxNumberOfItemsToReturn, ISortExpression sortClauses, IRelationCollection relationsToWalk, 
			IGroupByCollection groupByClause, ref int uniqueMarker);
		/// <summary>
		/// Routine which creates a valid alias string for the raw alias passed in. For example, the alias will be surrounded by "[]" on sqlserver. 
		/// Used by the RelationCollection to produce a valid alias for joins.
		/// </summary>
		/// <param name="rawAlias">the raw alias to make valid</param>
		/// <returns>valid alias string to use.</returns>
		string CreateValidAlias(string rawAlias);
		/// <summary>
		/// Finds the real alias for the entity + objectalias combination. A real alias is necessary as an entity mapped onto multiple tables (through inheritance)
		/// is aliased with a single object alias but each target has to have a different real alias. 
		/// </summary>
		/// <param name="containingObjectName">Name of the entity the holder of the objectAlias is defined in</param>
		/// <param name="objectAlias">Object alias.</param>
		/// <param name="actualContainingObjectName">The name of the entity the holder of the object alias is actually present in (is only different from
		/// entityName if holder is a subtype and did inherit the field)</param>
		/// <returns>the real alias for the entityname + objectAlias combination. If not found, objectAlias is returned.</returns>
		string FindRealAlias(string containingObjectName, string objectAlias, string actualContainingObjectName);
		/// <summary>
		/// Gets the new catalog name from the per-call hashtable name overwrites set into this object. If no per call name pairs are defined or the
		/// name passed in isn't found, the same name passed in is returned
		/// </summary>
		/// <param name="currentName">Name of the current.</param>
		/// <returns>the new name </returns>
		string GetNewPerCallCatalogName( string currentName );
		/// <summary>
		/// Gets the new schema name from the per-call hashtable name overwrites set into this object. If no per call name pairs are defined or the
		/// name passed in isn't found, the same name passed in is returned
		/// </summary>
		/// <param name="currentName">Name of the current.</param>
		/// <returns>the new name </returns>
		string GetNewPerCallSchemaName( string currentName );

		/// <summary>
		/// Gets / sets perCallCatalogNameOverwrites name pairs
		/// </summary>
		CatalogNameOverwriteHashtable PerCallCatalogNameOverwrites { get; set;}
		/// <summary>
		/// Gets / sets perCallSchemaNameOverwrites name pairs
		/// </summary>
		SchemaNameOverwriteHashtable PerCallSchemaNameOverwrites { get; set;}
	}


	/// <summary>
	/// Interface for the class which supplies a default value for a specified .NET type. Necessary for NULL values read from the database.
	/// Generic
	/// </summary>
	public interface ITypeDefaultValue
	{
		/// <summary>
		/// Returns a default value for the type specified
		/// </summary>
		/// <param name="defaultValueType">The type which default value should be returned.</param>
		/// <returns>The default value for the type specified.</returns>
		object DefaultValue(System.Type defaultValueType);
	}


	/// <summary>
	/// Interface definition for a class which forms a single sort clause, thus an order by
	/// definition defined for a single IEntityField or IEntityField - IFieldPersistenceInfo combination
	/// PersistenceInfo will return the same object when an IEntityField is added to the object.
	/// Generic
	/// </summary>
	public interface ISortClause
	{
		/// <summary>
		/// IEntityFieldCore to sort on.
		/// </summary>
		IEntityFieldCore FieldToSortCore {get; set;}
		/// <summary>
		/// Persistence information for FieldToSort. Can be a cast of the same object, when an IEntityField is
		/// added to this sort clause
		/// </summary>
		IFieldPersistenceInfo PersistenceInfo {get; set;}
		/// <summary>
		/// The sort operator to use for this sort clause
		/// </summary>
		SortOperator SortOperatorToUse {get; set;}
		/// <summary>
		/// Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used).
		/// </summary>
		string ObjectAlias {get; set;}
		/// <summary>
		/// Gets / sets the CaseSensitiveCollation flag. If set to true, the UPPER() function (or db specific equivalent) is applied to the field in the ORDER BY clause. Default: false
		/// </summary>
		/// <remarks>CaseSensitiveCollation is also used for in-memory sorts. If set to true, sorts in-memory will be case insensitive, otherwise 
		/// sorts will be case sensitive. The default for in-memory sorts is the same as for sorts on the db: false.</remarks>
		bool CaseSensitiveCollation {get;set;}
	}


	/// <summary>
	/// Interface for the class which contains the sort clauses used in IRetrievalQuery instances.
	/// Generic
	/// </summary>
	public interface ISortExpression : IEnumerable
	{
		/// <summary>
		/// Adds the passed in sort clause to the list. 
		/// </summary>
		/// <param name="sortClauseToAdd">the sort clause to add</param>
		/// <returns>The index the sort clause was added to</returns>
		int Add(ISortClause sortClauseToAdd);
		/// <summary>
		/// Inserts the passed in sort clause at the index provided.
		/// </summary>
		/// <param name="index">Index to insert the sortclause at</param>
		/// <param name="sortClauseToAdd">the sort clause to insert</param>
		void Insert(int index, ISortClause sortClauseToAdd);
		/// <summary>
		/// Removes the given sort clause from the list.
		/// </summary>
		/// <param name="sortClauseToRemove">the sort clause to remove.</param>
		void Remove(ISortClause sortClauseToRemove);
		/// <summary>
		/// Retrieves a ready to use text representation for the sort clauses contained in this expression.
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the query</param>
		/// <returns>string which is usable as the argument for the ORDER BY clause in a query</returns>
		/// <remarks>uses aliases for fields which have an expression and/or aggregate applied.</remarks>
		string ToQueryText( ref int uniqueMarker );
		/// <summary>
		/// Retrieves a ready to use text representation for the sort clauses contained in this expression.
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the query</param>
		/// <param name="aliasesForExpressionsAggregates">If set to false (default is true), the full field name with expression / aggregate is placed in
		/// the result string instead of the alias of the field. If set to true, aliases are used for fields with an expression and/or aggregate applied.</param>
		/// <returns>string which is usable as the argument for the ORDER BY clause in a query</returns>
		string ToQueryText( ref int uniqueMarker, bool aliasesForExpressionsAggregates );

		/// <summary>
		/// Indexer for this list.
		/// </summary>
		ISortClause this [int index] {get; set;}
		/// <summary>
		/// The amount of items currently stored in the ISortExpression
		/// </summary>
		int Count {get;}
		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		IDbSpecificCreator DatabaseSpecificCreator { get; set;}
		/// <summary>
		/// The list of parameters created when the sortexpression was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		List<IDataParameter> Parameters { get; }
	}


	/// <summary>
	/// Interface for validation classes used by <see cref="IEntityCore"/> implementing classes. 
	/// Generic
	/// </summary>
	public interface IValidator
	{
		/// <summary>
		/// Validates the given EntityFieldCore object on the given fieldIndex with the given value.
		/// This routine is called by the Entity's own value validator after the value has passed validation for destination column type and
		/// null values. 
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		/// <param name="fieldIndex">Index of IEntityFieldCore to validate</param>
		/// <param name="value">Value which should be stored in field with index fieldIndex. Will not be null (earlier logic filters out nulls before
		/// a call will be made to this routine).</param>
		/// <returns>
		/// true if the value is valid for the field, false otherwise
		/// </returns>
		/// <remarks>Use the entity.SetEntityFieldError() and entity.SetEntityError() methods if you want to set a IDataErrorInfo error string after the
		/// validation.</remarks>
		bool ValidateFieldValue(IEntityCore involvedEntity, int fieldIndex, object value );
		/// <summary>
		/// Method to validate the containing entity after it is loaded. This method is called after the entity has been fully loaded.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		void ValidateEntityAfterLoad( IEntityCore involvedEntity );
		/// <summary>
		/// Method to validate the containing entity right before the save sequence for the entity will start. LLBLGen Pro will call this method right after the
		/// containing entity is selected from the save queue to be saved.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		void ValidateEntityBeforeSave( IEntityCore involvedEntity );
		/// <summary>
		/// Method to validate the containing entity right after the entity's save action has been completed and the entity has been refetched (if applicable).
		/// Note for adapter users: if the entity wasn't set to be refetched, take into account that reading properties from the containing entity will result in an
		/// OutOfSync exception.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		void ValidateEntityAfterSave( IEntityCore involvedEntity );
		/// <summary>
		/// Method to validate the containig entity right beforethe entity's delete action will take place.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		void ValidateEntityBeforeDelete( IEntityCore involvedEntity );
		/// <summary>
		/// General validation method which isn't used by the LLBLGen Pro framework, but can be used by your own code to validate an entity at any given moment.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		void ValidateEntity( IEntityCore involvedEntity );
		/// <summary>
		/// Called when the implementing object is assinged to entity.Validator.
		/// </summary>
		/// <param name="involvedEntity">entity the validator is assigned to</param>
		void AssignedToEntity( IEntityCore involvedEntity );
		/// <summary>
		/// Called when the implementing object is dereferenced from an assigned entity.
		/// </summary>
		/// <param name="involvedEntity">the entity the validator is unassigned from</param>
		void UnassignedFromEntity( IEntityCore involvedEntity );
	}


	/// <summary>
	/// Interface for the RelationCollection class which is used to stack relation objects between several entities to build
	/// a complete join path
	/// Generic
	/// NB: ToQueryText() has been removed, query text producing logic is moved to the DQE's, since Oracle 8i doesn't support ANSI
	/// joins.
	/// </summary>
	public interface IRelationCollection
	{
		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list. 
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <returns>the added relation in the list, so you can chain commands on 1 line</returns>
		IEntityRelation Add(IEntityRelation relationToAdd);
		/// <summary>
		/// Adds the range of IEntityRelation objects stored in c to this collection.
		/// </summary>
		/// <param name="c">Collection with IEntityRelation objects to add</param>
		void AddRange(ICollection c);
		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list. 
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <param name="hint">Hint to signal the join type for this relation. Overrules obeyWeakRelations, except when the hint is JoinHint.None.</param>
		/// <returns>the added relation in the list, so you can chain commands on 1 line</returns>
		IEntityRelation Add(IEntityRelation relationToAdd, JoinHint hint);
		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list, under the alias specified for the end entity. The start entity gets no alias. 
		/// The weakness of the relation is considered based on the ObeyWeakRelations setting.
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <param name="aliasRelationEndEntity">the alias for the end entity in the relation (Customer.Relations.OrderUsingCustomerID: 
		/// Order is end entity). Alias is case sensitive</param>
		/// <returns>the added relation in the list, so you can chain commands on 1 line</returns>
		/// <exception cref="ArgumentException">when aliasRelationEndEntity is an empty string, null or otherwise unusable alias (contains spaces)</exception>
		IEntityRelation Add(IEntityRelation relationToAdd, string aliasRelationEndEntity);
		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list, under the alias specified for the end entity and will consider the relation's weakness 
		/// based on the hint value. The start entity gets no alias. 
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <param name="aliasRelationEndEntity">the alias for the end entity in the relation (Customer.Relations.OrderUsingCustomerID: 
		/// Order is end entity). Alias is case sensitive</param>
		/// <param name="hint">Hint to signal the join type for this relation. Overrules obeyWeakRelations, except when the hint is JoinHint.None.</param>
		/// <returns>the added relation in the list, so you can chain commands on 1 line</returns>
		/// <exception cref="ArgumentException">when aliasRelationEndEntity is an empty string, null or otherwise unusable alias (contains spaces)</exception>
		IEntityRelation Add(IEntityRelation relationToAdd, string aliasRelationEndEntity, JoinHint hint);
		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list, under the aliases specified and will consider the relation's weakness 
		/// based on the hint value. The start entity gets no alias. 
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <param name="aliasRelationStartEntity">the alias for the start entity in the relation (Customer.Relations.OrderUsingCustomerID: 
		/// Customer is start entity). Alias is case sensitive</param>
		/// <param name="aliasRelationEndEntity">the alias for the end entity in the relation (Customer.Relations.OrderUsingCustomerID: 
		/// Order is end entity). Alias is case sensitive</param>
		/// <param name="hint">Hint to signal the join type for this relation. Overrules obeyWeakRelations, except when the hint is JoinHint.None.</param>
		/// <returns>the added relation in the list, so you can chain commands on 1 line</returns>
		/// <exception cref="ArgumentException">when aliasRelationEndEntity or aliasRelationStartEntity are an empty string, null or otherwise unusable 
		/// alias (contains spaces)</exception>
		IEntityRelation Add(IEntityRelation relationToAdd, string aliasRelationStartEntity, string aliasRelationEndEntity, JoinHint hint);
		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list at position index. 
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <param name="index">Index to add the relation to.</param>
		void Insert(IEntityRelation relationToAdd, int index);
		/// <summary>
		/// Removes the passed in IEntityRelation instance. Only the first instance will be removed.
		/// </summary>
		/// <param name="relationToRemove">IEntityRelation instance to remove</param>
		void Remove(IEntityRelation relationToRemove);
		/// <summary>
		/// Converts the set of relations to a set of nested JOIN query elements using ANSI join syntaxis. Oracle 8i doesn't support ANSI join syntaxis
		/// and therefore the OracleDQE has its own join code.
		/// It uses a database specific creator object for database specific syntaxis, like the format of the tables / views and fields. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the custom filter predicates</param>
		/// <returns>The string representation of the INNER JOIN expressions of the contained relations, when ObeyWeakRelations is set to false (default)
		/// or the string representation of the LEFT/RIGHT JOIN expressions of the contained relations, when ObeyWeakRelations is set to true</returns>
		/// <exception cref="ApplicationException">When the DatabaseSpecificCreator is not set.</exception>
		string ToQueryText(ref int uniqueMarker);
		/// <summary>
		/// Gets per alias specified in a relation all entity names covered by that alias. This means that if an entity in a relation is based on multiple entities
		/// (through inheritance) it will return all entity names the entity is based on, from the actual entity to the root of the hierarchy path and every
		/// entity name in between.
		/// </summary>
		/// <param name="entityNamesPerAlias">Entity names per alias multivaluehashtable: per alias (key) all entity names are stored in a uniquevaluelist.</param>
		/// <param name="artificialAliasPerEntity">The artificial alias per entity. This collection contains per entity (key) the artificial alias (value), IF 
		/// such an artificial alias has been given out. (only done with entities which are part of a hierarchy of type TargetPerEntity)</param>
		void GetUsedEntityTypeNamesAndAliases(MultiValueHashtable<string, string> entityNamesPerAlias, Dictionary<string, string> artificialAliasPerEntity);

		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		IDbSpecificCreator DatabaseSpecificCreator {get; set;}
		/// <summary>
		/// Indexer in the collection.
		/// </summary>
		IEntityRelation this [int index] {get; set;}
		/// <summary>
		/// Gets / sets ObeyWeakRelations, which is the flag to signal the collection what kind of join statements to generate in the
		/// ToQueryText statement, which is called by the DQE. Weak relationships are relationships which are optional, for example a
		/// customer with no orders is possible, because the relationship between customer and order is based on a field in order.
		/// When this property is set to true (default: false), weak relationships will result in LEFT JOIN statements. When
		/// set to false (which is the default), INNER JOIN statements are used.
		/// </summary>
		bool ObeyWeakRelations { get; set;}
		/// <summary>
		/// Returns the amount of relations in this object
		/// </summary>
		int Count {get;}
	}


	/// <summary>
	/// Interface base definition for TypedList classes
	/// </summary>
	public interface ITypedListCore
	{
		/// <summary>
		/// Returns the amount of rows in this typed list.
		/// </summary>
		int Count {get; }
		/// <summary>
		/// Gets / sets ObeyWeakRelations, which is the flag to signal the collection what kind of join statements to generate in the
		/// query statement. Weak relationships are relationships which are optional, for example a
		/// customer with no orders is possible, because the relationship between customer and order is based on a field in order.
		/// When this property is set to true (default: false), weak relationships will result in LEFT JOIN statements. When
		/// set to false (which is the default), INNER JOIN statements are used.
		/// </summary>
		bool ObeyWeakRelations {get; set;}
	}


	/// <summary>
	/// General interface definition for the Expression class which defines field expressions which are
	/// applied to fields in a select list, in update queries or in field predicates.
	/// </summary>
	public interface IExpression
	{
		/// <summary>
		/// Retrieves a ready to use text representation of the contained expression. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the expression and also in the expression(s) containing the expression.</param>
		/// <returns>The contained expression in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IExpression.DatabaseSpecificCreator is not set to a valid value.</exception>
		string ToQueryText(ref int uniqueMarker);
		/// <summary>
		/// Retrieves a ready to use text representation of the contained expression. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the expression and also in the expression(s) containing the expression.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>The contained expression in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IExpression.DatabaseSpecificCreator is not set to a valid value.</exception>
		string ToQueryText(ref int uniqueMarker, bool inHavingClause);

		/// <summary>
		/// The list of parameters created when the Expression was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		List<IDataParameter> Parameters {get;}	
		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		IDbSpecificCreator DatabaseSpecificCreator {get; set;}
		/// <summary>
		/// Gets the left expression operand. Set by the constructor used.
		/// </summary>
		IExpressionElement LeftOperand {get;}
		/// <summary>
		/// Gets the right expression operand. Set by the constructor used.
		/// Can be null
		/// </summary>
		IExpressionElement RightOperand {get;}
		/// <summary>
		/// Gets the operator of the expression. Not valid (ExOp.None) if RightOperand is null. Set by the constructor used.
		/// </summary>
		ExOp Operator {get;}
	}


	/// <summary>
	/// Interface definition for elements contained in an expression.
	/// </summary>
	public interface IExpressionElement
	{
		/// <summary>
		/// The type of the element 
		/// </summary>
		ExpressionElementType Type {get; set;}
		/// <summary>
		/// The contents of the element
		/// </summary>
		object Contents {get; set;}
	}
	

	/// <summary>
	/// Interface definition for field elements contained in an expression
	/// </summary>
	public interface IExpressionFieldElement:IExpressionElement
	{
		/// <summary>
		/// The persistence info for the field contained in the field.
		/// </summary>
		IFieldPersistenceInfo PersistenceInfo { get; set;}
	}


	/// <summary>
	/// Interface which defines a scalar query which can be used inside an Expression object. The scalar query results a single value, and because
	/// it can be used as an expression, it can be used in the select list of a dynamic list. 
	/// </summary>
	public interface IScalarQueryExpression
	{
		/// <summary>
		/// Retrieves a ready to use text representation of the scalar query
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the complete query.</param>
		/// <returns>The contained function call in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IScalarQueryExpression.DatabaseSpecificCreator is not set to a valid value.</exception>
		string ToQueryText( ref int uniqueMarker );
		/// <summary>
		/// Retrieves a ready to use text representation of the scalar query
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the complete query.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>
		/// The contained function call in textual format.
		/// </returns>
		/// <exception cref="System.ApplicationException">When IScalarQueryExpression.DatabaseSpecificCreator is not set to a valid value.</exception>
		string ToQueryText( ref int uniqueMarker, bool inHavingClause );

		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		IDbSpecificCreator DatabaseSpecificCreator { get; set;}
		/// <summary>
		/// The field which will be the resultvalue of this scalar query
		/// </summary>
		IEntityFieldCore SelectField { get; set;}
		/// <summary>
		/// The persistence info for the SelectField
		/// </summary>
		IFieldPersistenceInfo SelectFieldPersistenceInfo { get; set;}
		/// <summary>
		/// The filter to use in the scalar query. 
		/// </summary>
		IPredicateExpression FilterToUse { get; set;}
		/// <summary>
		/// The relations to use in the scalar query.
		/// </summary>
		IRelationCollection RelationsToUse { get; set; }
		/// <summary>
		/// The sorter to use in the scalar query.
		/// </summary>
		ISortExpression SorterToUse { get; set; }
		/// <summary>
		/// The list of parameters created when the ScalarQueryExpression was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		List<IDataParameter> Parameters { get;}
		/// <summary>
		/// The group by clause to use in this scalar query.
		/// </summary>
		IGroupByCollection GroupByClause { get; set; }
	}


	/// <summary>
	/// Interface which defines a database function call type, used for specifying a function call in a filter, resultset or sortclause. 
	/// </summary>
	public interface IDbFunctionCall
	{
		/// <summary>
		/// Retrieves a ready to use text representation of the contained function call
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the complete query.</param>
		/// <returns>The contained function call in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IDbFunctionCall.DatabaseSpecificCreator is not set to a valid value.</exception>
		string ToQueryText( ref int uniqueMarker );
		/// <summary>
		/// Retrieves a ready to use text representation of the contained function call
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the complete query.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>
		/// The contained function call in textual format.
		/// </returns>
		/// <exception cref="System.ApplicationException">When IDbFunctionCall.DatabaseSpecificCreator is not set to a valid value.</exception>
		string ToQueryText( ref int uniqueMarker, bool inHavingClause );

		/// <summary>
		/// The list of database parameters created when the DbFunctionCall was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		List<IDataParameter> DatabaseParameters { get;}
		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		IDbSpecificCreator DatabaseSpecificCreator { get; set;}
		/// <summary>
		/// Gets or sets the name of the catalog the function is located in. Can be ignored on databases which don't support catalogs. 
		/// </summary>
		/// <remarks>If catalog name isn't supplied, the function has to be present in the active catalog the user is connected with.</remarks>
		/// <value>The name of the catalog.</value>
		string CatalogName { get; set;}
		/// <summary>
		/// Gets or sets the name of the schema the function is located in. Can be ignored on databases which don't support schemas.
		/// </summary>
		/// <remarks>If schema name isn't supplied, the function has to be present in the default schema the user has access to in the current catalog.
		/// If you've specified a catalog, always specify the schema.</remarks>
		/// <value>The name of the schema.</value>
		string SchemaName { get; set; }
		/// <summary>
		/// Gets or sets the name of the function to call. This is without catalog or schema name. 
		/// </summary>
		/// <value>The name of the function.</value>
		string FunctionName { get; set; }
		/// <summary>
		/// Gets the function parameters to pass to the function. You can pass fields and values to the function as parameters. A field can have a function call and/or
		/// expression applied to make nested function calls possible. 
		/// </summary>
		/// <value>The function parameters.</value>
		object[] FunctionParameters { get; set; }
		/// <summary>
		/// Per field in FunctionParameters, this list contains the fieldPersistenceinfo object. If a parameter in FunctionParameters is not an IEntityFieldCore implementing
		/// object, the value for that parameter is null/Nothing.
		/// </summary>
		IFieldPersistenceInfo[] FieldPersistenceInfos { get; set;}
	}


	/// <summary>
	/// Interface definition for the core of a PrefetchPathElement instances contained in a PrefetchPath. 
	/// This interface is used as a base interface for the specialised IPrefetchPathElement (selfservicing) and IPrefetchPathElement2 (Adapter).
	/// </summary>
	public interface IPrefetchPathElementCore
	{
		/// <summary>
		/// The relation between the destination (parent) entity and the entity to fetch with this path element
		/// </summary>
		IEntityRelation	Relation { get; set; }
		/// <summary>
		/// The EntityType enum value for the entity the entities to fetch are to be stored in. 
		/// </summary>
		/// <remarks>Set in the constructor</remarks>
		int	DestinationEntityType { get; }
		/// <summary>
		/// The EntityType enum value for the entity to fetch defined by this path element.
		/// </summary>
		/// <remarks>Set in the constructor</remarks>
		int ToFetchEntityType { get; }
		/// <summary>
		/// The maximum amount of entities to set per destination instance.
		/// </summary>
		int MaxAmountOfItemsToReturn { get; set; }
		/// <summary>
		/// The sort expression to sort the entities per destination instance. 
		/// </summary>
		ISortExpression Sorter { get; set;}
		/// <summary>
		/// The filter predicate expression to fetch the ToFetch entities. Initially this is set in the constructor.
		/// Add additional predicates to this predicate expression.
		/// </summary>
		IPredicateExpression Filter { get; set; }
		/// <summary>
		/// The relations to use in the filters. Initially this is an empty collection, as the fetches use subqueries. 
		/// Add additional relations to this relation collection to have multi-entity filters.
		/// </summary>
		IRelationCollection FilterRelations { get; set;}
		/// <summary>
		/// The name of the property which is the destination for the entities fetched by the definition of this path element.
		/// </summary>
		string PropertyName {get; set;}
		/// <summary>
		/// The type of relation between the entity to fetch and the entity which will hold the entity to fetch
		/// </summary>
		RelationType TypeOfRelation { get; set;}
		/// <summary>
		/// Gets or sets the graph level.
		/// </summary>
		int GraphLevel { get; set;}
		/// <summary>Gets / sets the list of IEntityFieldCore objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.
		/// </summary>
		ExcludeIncludeFieldsList ExcludedIncludedFields { get; set; }
	}


	/// <summary>
	/// Interface for creating hints based on the input specified. Hints are used to tell the RDBMS to produce different SQL. 
	/// This interface is implemented on those IDatabaseSpecificGenerator implementing classes for which the RDBMS supports hints.
	/// </summary>
	public interface IDbSpecificHintCreator
	{
		/// <summary>
		/// Creates the hint statement for the hint passed in.
		/// </summary>
		/// <param name="hint">Hint specification to create the statement for.</param>
		/// <param name="values">Additional parameters for the hint statement producer. The values can be very provider specific.</param>
		/// <returns>the hint statement, ready to use.</returns>
		string CreateHintStatement(RdbmsHint hint, params object[] values);
	}


	/// <summary>
	/// Interface for the PersistenceInfoProvider classes which are used to provide persistence information for adapter/selfservicing fields.
	/// </summary>
	public interface IPersistenceInfoProvider
	{
		/// <summary>
		/// Retrieves for each field of entity / typed view with the name passed in the corresponding IFieldPersistenceInfo instance.
		/// The order of these IFieldPersistenceInfo objects is the same as the corresponding fields in an 
		/// entity / typed view with the name objectName.
		/// </summary>
		/// <param name="entity">Name of the entity / typed view to retrieve the IFieldPersistenceInfo objects for. Example: CustomerEntity</param>
		/// <returns>Array of IFieldPersistenceInfo objects</returns>
		IFieldPersistenceInfo[] GetAllFieldPersistenceInfos( IEntity2 entity );
		/// <summary>
		/// Retrieves for each field of the entity instance passed in the corresponding IFieldPersistenceInfo instance.
		/// </summary>
		/// <param name="entity">Entity instance to return the IFieldPersistenceInfo objects for.</param>
		/// <returns>Array of IFieldPersistenceInfo objects</returns>
		IFieldPersistenceInfo[] GetAllFieldPersistenceInfos( string entity );
		/// <summary>
		/// Retrieves for the field with name fieldName of entity / typed view with the name passed in the corresonding IFieldPersistenceInfo instance.
		/// </summary>
		/// <param name="elementName">Name of the entity / typed view the field belongs to. Example: CustomerEntity</param>
		/// <param name="fieldName">Name of the field which fieldpersistenceinfo should be returned. Example: CustomerID</param>
		/// <returns>Requested IFieldPersistenceInfo object</returns>
		IFieldPersistenceInfo GetFieldPersistenceInfo( string elementName, string fieldName );
	}


	/// <summary>
	/// Interface for the FieldInfoProvider class which is used to provide field info information for adapter/selfservicing fields / entityfields(2) objects. 
	/// </summary>
	public interface IFieldInfoProvider
	{
		/// <summary>
		/// Gets the field info for the field passed in for the element passed in
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <param name="elementFieldName">Name of the element field.</param>
		/// <returns></returns>
		IFieldInfo GetFieldInfo( string elementName, string elementFieldName );
		/// <summary>
		/// Gets the field info for the field passed in for the element passed in
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <param name="elementFieldIndex">Index of the element field.</param>
		/// <returns></returns>
		IFieldInfo GetFieldInfo(string elementName, int elementFieldIndex);
		/// <summary>
		/// Gets the field infos for the element passed in.
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <returns></returns>
		IFieldInfo[] GetFieldInfos( string elementName );
		/// <summary>
		/// Gets the field indexes object for the element passed in. This is an object which is used by EntityFields(2) objects to quickly find a field
		/// based on the field name.
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <returns></returns>
		Dictionary<string, int> GetFieldIndexes( string elementName );
		/// <summary>
		/// Fills the entity fields object for the adapter entity with the name specified.
		/// </summary>
		/// <param name="inheritanceProvider">The inheritance provider.</param>
		/// <param name="entityName">Name of the entity.</param>
		/// <remarks>Adapter specific</remarks>
		IEntityFields2 GetEntityFields(IInheritanceInfoProvider inheritanceProvider, string entityName);
		/// <summary>
		/// Fills the entity fields object for the adapter entity with the name specified.
		/// </summary>
		/// <param name="inheritanceProvider">The inheritance provider.</param>
		/// <param name="persistenceInfoProvider">The persistence info provider.</param>
		/// <param name="entityName">Name of the entity.</param>
		/// <returns></returns>
		/// <remarks>SelfServicing specific</remarks>
		IEntityFields GetEntityFields(IInheritanceInfoProvider inheritanceProvider, IPersistenceInfoProvider persistenceInfoProvider, string entityName);
		/// <summary>
		/// Gets the entity fields array.
		/// </summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <returns>array of the fields which solely belong to the entity specified so no inherited fields are present.</returns>
		/// <remarks>Used in adapter.</remarks>
		IEntityFieldCore[] GetEntityFieldsArray(string entityName);
		/// <summary>
		/// Gets the entity fields array.
		/// </summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="persistenceProvider">The persistence provider.</param>
		/// <returns>
		/// array of the fields which solely belong to the entity specified so no inherited fields are present.
		/// </returns>
		/// <remarks>selfservicing specific.</remarks>
		IEntityFieldCore[] GetEntityFieldsArray(string entityName, IPersistenceInfoProvider persistenceProvider);
	}


	/// <summary>
	/// Interface for defining the IEntityPropertyProjector type which is used for entity property projections when projecting an entityview's content onto another
	/// data store format.
	/// </summary>
	public interface IEntityPropertyProjector : IProjector
	{
		/// <summary>
		/// Projects the entity through this entity property projector and results into a single value, based on what the DefaultValueProducer is and
		/// what filter is specified (if any)
		/// </summary>
		/// <param name="entity">The entity to project. The DefaultValueProducer, ValueFilter, AlternativeValueProducer and the method to post process
		/// the value will determine what the returned value is</param>
		/// <returns>Projection result of an entity's property using this entity property descriptor.</returns>
		object ProjectEntityProperty( IEntityCore entity);

		/// <summary>
		/// Gets or sets the default value producer. This object produces the value returned by ProjectEntityProperty if ValueFilter isn't set or resolves to true
		/// for the entity passed into ProjectEntityProperty.
		/// </summary>
		IEntityFieldCore DefaultValueProducer { get; set;}
		/// <summary>
		/// Gets or sets the value filter which can be used to select between the DefaultValueProducer and the AlternativeValueProducer. If this filter isn't
		/// set (null) or set to an IPredicate implementing object and at runtime the filter resolves to true for the entity passed into ProjectEntityProperty, 
		/// the DefaultValueProducer is used, otherwise the AlternativeValueProducer. If AlternativeValueProducer isn't set, an
		/// ORMInterpretationException is thrown.
		/// </summary>
		IPredicate ValueFilter { get; set;}
		/// <summary>
		/// Gets or sets the alternative value producer. Only used if ValueFilter is set to a valid filter and that filter resolves to false for the
		/// entity passed into ProjectEntityProperty.
		/// </summary>
		IEntityFieldCore AlternativeValueProducer { get; set;}
	}


	/// <summary>
	/// Interface for defining the IDataValueProjector type which is used for value projections when projecting an object[] content onto another
	/// data store format.
	/// </summary>
	public interface IDataValueProjector : IProjector
	{
		/// <summary>
		/// Projects the entity through this entity property projector and results into a single value, based on what the DefaultValueProducer is and
		/// what filter is specified (if any)
		/// </summary>
		/// <param name="sourceValues">The source values of which this projector will pick a value to project. The projection result is returned.</param>
		/// <returns>
		/// Projection result of a value in the sourcevalues.
		/// </returns>
		object ProjectValue( object[] sourceValues);

		/// <summary>
		/// Gets or sets the index of the value to return when Projectvalue is called. 
		/// </summary>
		/// <value>The index of the default value.</value>
		int ValueIndex { get; set;}
	}


	/// <summary>
	/// Core interface for projectors
	/// </summary>
	public interface IProjector
	{
		/// <summary>
		/// Name for the projection result. Projection result consumers can use this name to further handle the projection result.
		/// </summary>
		string ProjectedResultName { get;}
		/// <summary>
		/// Gets or sets the type of the value returned by the value producer or producers routine of the projector.
		/// </summary>
		Type ValueType { get; set;}
	}


	/// <summary>
	/// Interface which defines a projector engine for projecting entity data. The engine consumes projected raw data and produces an object which 
	/// from then on contains the raw data. 
	/// </summary>
	public interface IEntityDataProjector
	{
		/// <summary>
		/// Adds a new projection result to the container contained into this instance. The container has to be set in the constructor.
		/// </summary>
		/// <param name="propertyProjectors">List of property projectors used to create the projection result</param>
		/// <param name="rawProjectionResult">The raw projection result.</param>
		void AddProjectionResultToContainer( List<IEntityPropertyProjector> propertyProjectors, object[] rawProjectionResult );
	}


	/// <summary>
	/// Interface which defines a projector engine for projecting general data in object[] arrays (e.g. datareader results). 
	/// The engine consumes projected raw data and produces an object which from then on contains the raw data. 
	/// </summary>
	public interface IGeneralDataProjector
	{
		/// <summary>
		/// Adds a new projection result to the container contained into this instance. The container has to be set in the constructor.
		/// </summary>
		/// <param name="valueProjectors">List of value projectors used to create the projection result</param>
		/// <param name="rawProjectionResult">The raw projection result.</param>
		void AddProjectionResultToContainer( List<IDataValueProjector> valueProjectors, object[] rawProjectionResult );
	}


	/// <summary>
	/// Internal maintenance interface for collections. This interface is necessary so methods can be called by casting to this interface without
	/// needing the type of the element used in the collection when the collection is for example passed in with just IEntityCollection or IEntityCollection2.
	/// </summary>
	internal interface ICollectionMaintenance
	{
		/// <summary>
		/// Resets the CachedPkHashes. 
		/// </summary>
		void ResetCachedPkHashes();
		/// <summary>
		/// Clears this instance. 
		/// </summary>
		void Clear();
		/// <summary>
		/// Creates a dummy instance using the entity factory stored in an inherited collection. This dummy instance is then used to produce
		/// property descriptors.
		/// </summary>
		/// <returns>Dummy instance of entity contained in this collection, using the set factory.</returns>
		IEntityCore CreateDummyInstance();
		/// <summary>
		/// Gets the entity collection description. This string is used in verbose trace messages.
		/// </summary>
		/// <param name="switchFlag">switch flag.</param>
		/// <returns></returns>
		string GetEntityCollectionDescription( bool switchFlag );
		/// <summary>
		/// Raises the list changed event, with the parameters passed in.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="typeOfChange">The type of change.</param>
		void RaiseListChanged( int index, ListChangedType typeOfChange );
		/// <summary>
		/// Removes the passed in entity from the collection without notifying the entity to remove that it has been removed from this collection.
		/// </summary>
		/// <param name="toRemove">To remove.</param>
		void SilentRemove( IEntityCore toRemove );

		/// <summary>
		/// Gets / sets the DeserializationInProgress flag.
		/// </summary>
		bool DeserializationInProgress { get; set;}
		/// <summary>
		/// Gets or sets a value indicating whether [surpress list changed events].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [surpress list changed events]; otherwise, <c>false</c>.
		/// </value>
		bool SurpressListChangedEvents { get; set;}
	}


	/// <summary>
	/// Interface which defines the core elements of an LLBLGen Pro transaction manager object. 
	/// </summary>
	internal interface ITransactionNotification
	{
		/// <summary>
		/// Will notify all transaction participating entities that the transaction they're in, has been committed. 
		/// </summary>
		void NotifyCommit();
		/// <summary>
		/// Will notify all transaction participating entities that the transaction they're in, has been rolled back.
		/// </summary>
		void NotifyRollback();
	}


	/// <summary>
	/// Internal interface which is used to call entity methods in generic code where there's just an IEntityCore instance.
	/// </summary>
	internal interface IEntityCoreInternal
	{
		/// <summary>
		/// Gets all related data objects, stored by name. The name is the field name mapped onto the relation for that particular data element. 
		/// </summary>
		/// <returns>Dictionary with per name the related referenced data element, which can be an entity collection or an entity or null</returns>
		Dictionary<string, object> CallGetRelatedData();
	}
	#endregion


#if !CF
	#region Fast Serialization oriented interfaces
	/// <summary>
	/// Interface which allows a class to specify that it can be recreated during deserialization using a default constructor
	/// and then calling DeserializeOwnedData()
	/// </summary>
	public interface IOwnedDataSerializableAndRecreatable : IOwnedDataSerializable 
	{ 
	}


	/// <summary>
	/// Interface which allows a class to save/retrieve their internal data to/from an existing SerializationWriter/SerializationReader.
	/// </summary>
	public interface IOwnedDataSerializable
	{
		/// <summary>
		/// Lets the implementing class store internal data directly into a SerializationWriter.
		/// </summary>
		/// <param name="writer">The SerializationWriter to use</param>
		/// <param name="context">Optional context to use as a hint as to what to store (BitVector32 is useful)</param>
		void SerializeOwnedData(SerializationWriter writer, object context);
		/// <summary>
		/// Lets the implementing class retrieve internal data directly from a SerializationReader.
		/// </summary>
		/// <param name="reader">The SerializationReader to use</param>
		/// <param name="context">Optional context to use as a hint as to what to retrieve (BitVector32 is useful) </param>
		void DeserializeOwnedData(SerializationReader reader, object context);
	}


	/// <summary>
	/// Interface to allow helper classes to be used to serialize objects
	/// that are not directly supported by SerializationWriter/SerializationReader
	/// </summary>
	public interface IFastSerializationTypeSurrogate
	{
		/// <summary>
		/// Allows a surrogate to be queried as to whether a particular type is supported
		/// </summary>
		/// <param name="type">The type being queried</param>
		/// <returns>true if the type is supported; otherwise false</returns>
		bool SupportsType(Type type);
		/// <summary>
		/// FastSerializes the object into the SerializationWriter.
		/// </summary>
		/// <param name="writer">The SerializationWriter into which the object is to be serialized.</param>
		/// <param name="value">The object to serialize.</param>
		void Serialize(SerializationWriter writer, object value);
		/// <summary>
		/// Deserializes an object of the supplied type from the SerializationReader.
		/// </summary>
		/// <param name="reader">The SerializationReader containing the serialized object.</param>
		/// <param name="type">The type of object required to be deserialized.</param>
		/// <returns></returns>
		object Deserialize(SerializationReader reader, Type type);
	}


	/// <summary>
	/// Interface for entitycollection2 objects which are usable with the fast serializer
	/// </summary>
	internal interface IFastSerializableEntityCollection2 : IEntityCollection2, IOwnedDataSerializable
	{
		/// <summary>
		/// Gets the serialization flags.
		/// </summary>
		/// <param name="parseEntityList">If set to true, serialization flags are parsed</param>
		/// <param name="includeEntityMemberCollections">If set to true, entity menber collections are included as well. </param>
		/// <returns>Bitvector with the serialization flags</returns>
		BitVector32 GetSerializationFlags(bool parseEntityList, bool includeEntityMemberCollections);
		/// <summary>
		/// Adds the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void Add(EntityBase2 entity);
		/// <summary>
		/// Inits the class
		/// </summary>
		void InitClassInternal();

		/// <summary>
		/// Gets or sets the containing entity mapped field
		/// </summary>
		string ContainingEntityMappedFieldInternal { get; set; }
	}

	/// <summary>
	/// Interface to implement on a compressor class which can be used to compres/decompress the resulting byte array of the Fast serializer. 
	/// </summary>
	public interface IByteCompressor
	{
		/// <summary>
		/// Compresses the specified serialized data.
		/// </summary>
		/// <param name="serializedData">The serialized data.</param>
		/// <returns>The  passed in serialized data in compressed form</returns>
		byte[] Compress(byte[] serializedData);
		/// <summary>
		/// Decompresses the specified compressed data.
		/// </summary>
		/// <param name="compressedData">The compressed data.</param>
		/// <returns>The  passed in de-serialized data in compressed form</returns>
		byte[] Decompress(byte[] compressedData);
	}

	/// <summary>
	/// Interface to implement on specialized compressor classes to compress a passed in memory stream
	/// </summary>
	public interface IMemoryStreamByteCompressor : IByteCompressor
	{
		/// <summary>
		/// Compresses the specified memory stream.
		/// </summary>
		/// <param name="memoryStream">The memory stream.</param>
		/// <returns>the data in the memory stream in compressed format.</returns>
		byte[] Compress(MemoryStream memoryStream);
	}
	#endregion
#endif

	#region Obsolete interfaces
	/// <summary>
	/// Entity validator interface which is now obsolete. Move your code from IEntityValidator implementing objects to the generated validator classes and
	/// override the proper base class methods. Place your code in a partial class.
	/// </summary>
	[Obsolete("This interface is now obsolete. Please move your code to the validator classes and override the proper base class methods to perform your validation work.", true)]
	public interface IEntityValidator
	{
	}
	#endregion
}
