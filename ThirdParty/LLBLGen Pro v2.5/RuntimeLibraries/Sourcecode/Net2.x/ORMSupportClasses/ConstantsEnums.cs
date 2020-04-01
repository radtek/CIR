//////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
// The sourcecode for the ORM Support classes is released as BSD2 licensed 
// open source, so licensees of LLBLGen Pro can modify, update and/or extend it. 
// Distribution of this sourcecode and binary compiled versions of this sourcecode
// are licensed to LLBLGen Pro licensees using the following license below.
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2002-2006 Solutions Design. All rights reserved.
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
//		- Frans Bouma
//		- Simon Hewitt
//////////////////////////////////////////////////////////////////////
using System;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Enum which defines the action to take when a scale overflow is detected in the build-in validation for precision/scale values. This validation
	/// takes place when an entity field is set to a value and the validation isn't bypassed.
	/// </summary>
	public enum ScaleOverflowCorrectionAction : int
	{
		/// <summary>
		/// No action is taken, and the exception resulting from the scale overflow detection is thrown.
		/// </summary>
		None=0,
		/// <summary>
		/// Default. Chop off the digits which overflow the scale. Examples: scale is 2: 10.456 becomes 10.45. 10.450 becomes 10.45
		/// </summary>
		/// <remarks>SqlServer users should use this option if they want to mimic the SqlClient build-in truncation code.</remarks>
		Truncate=1,
		/// <summary>
		/// Round the fraction to a value which fits the scale and round values using Math.Round(value, scale)
		/// </summary>
		Round=2,
	}


	/// <summary>
	/// Enum which defines the strategy for the build-in validation logic for new values for entity fields. Build-in validation logic
	/// checks if the value to set matches the characteristics of the database field the entity field is mapped on, so when the
	/// entity is persisted there won't be any overflow exception.
	/// </summary>
	public enum BuildInValidationBypass : int
	{
		/// <summary>
		/// Default. Don't bypass the build-in validation logic and only call the validator if the build-in validation checks succeed.
		/// </summary>
		NoBypass = 0,
		/// <summary>
		/// Always bypass the build-in validation logic, even if there's no validator set for the entity.
		/// </summary>
		AlwaysBypass = 1,
		/// <summary>
		/// Only bypass the build-in validation logic if the entity has a validator object set. Otherwise execute the build-in validation logic 
		/// </summary>
		BypassWhenValidatorPresent = 2
	}


	/// <summary>
	/// Enum which is used to identify the various info elements in a db specific exception info hashtable/dictionary.
	/// </summary>
	public enum ExceptionInfoElement
	{
		/// <summary>
		/// The HRESULT error code (if available).
		/// </summary>
		ErrorCode,
		/// <summary>
		/// The set of error objects (e.g. SqlError, OracleError etc. objects) contained by the exception
		/// </summary>
		ErrorObjects,
		/// <summary>
		/// The error number as reported by the db engine.
		/// </summary>
		ErrorNumber,
		/// <summary>
		/// The server name or datasource the error occured on.
		/// </summary>
		ServerName,
		/// <summary>
		/// A hint provided by the db engine how to solve the error.
		/// </summary>
		Hint,
		/// <summary>
		/// The error message. This message is also copied to the exception message.
		/// </summary>
		Message,
		/// <summary>
		/// Link to help documentation about this error.
		/// </summary>
		HelpLink,
	}


	/// <summary>
	/// Enum which is used for fast serialization. It stores information about a type or type/value.
	/// </summary>
	internal enum SerializedType : byte
	{
		// Codes 0 to 127 reserved for String token tables

		NullType = 128,            // Used for all null values
		NullSequenceType,          // Used internally to identify sequences of null values in object[]
		DBNullType,                // Used for DBNull.Value
		DBNullSequenceType,        // Used internally to identify sequences of DBNull.Value values in object[] (DataSets)
		OtherType,                 // Used for any unrecognized types - uses an internal BinaryWriter/Reader.

		BooleanTrueType,           // Stores Boolean type and values
		BooleanFalseType,

		ByteType,                  // Standard numeric value types
		SByteType,
		CharType,
		DecimalType,
		DoubleType,
		SingleType,
		Int16Type,
		Int32Type,
		Int64Type,
		UInt16Type,
		UInt32Type,
		UInt64Type,

		ZeroByteType,              // Optimization to store type and a zero value - all numeric value types
		ZeroSByteType,
		ZeroCharType,
		ZeroDecimalType,
		ZeroDoubleType,
		ZeroSingleType,
		ZeroInt16Type,
		ZeroInt32Type,
		ZeroInt64Type,
		ZeroUInt16Type,
		ZeroUInt32Type,
		ZeroUInt64Type,

		OneByteType,               // Optimization to store type and a one value - all numeric value types
		OneSByteType,
		OneCharType,
		OneDecimalType,
		OneDoubleType,
		OneSingleType,
		OneInt16Type,
		OneInt32Type,
		OneInt64Type,
		OneUInt16Type,
		OneUInt32Type,
		OneUInt64Type,

		MinusOneInt16Type,         // Optimization to store type and a minus one value - Signed Integer types only
		MinusOneInt32Type,
		MinusOneInt64Type,

		OptimizedInt16Type,        // Optimizations for specific value types
		OptimizedInt16NegativeType,
		OptimizedUInt16Type,
		OptimizedInt32Type,
		OptimizedInt32NegativeType,
		OptimizedUInt32Type,
		OptimizedInt64Type,
		OptimizedInt64NegativeType,
		OptimizedUInt64Type,
		OptimizedDateTimeType,
		OptimizedTimeSpanType,


		EmptyStringType,           // String type and optimizations
		SingleSpaceType,
		SingleCharStringType,
		YStringType,
		NStringType,

		DateTimeType,              // Date type and optimizations
		MinDateTimeType,
		MaxDateTimeType,

		TimeSpanType,              // TimeSpan type and optimizations
		ZeroTimeSpanType,

		GuidType,                  // Guid type and optimizations
		EmptyGuidType,

		BitVector32Type,           // Specific optimization for BitVector32 type

		DuplicateValueType,        // Used internally by Optimized object[] pair to identify values in the 
		// second array that are identical to those in the first
		DuplicateValueSequenceType,

		BitArrayType,              // Specific optimization for BitArray

		TypeType,                  // Identifies a Type type 

		SingleInstanceType,        // Used internally to identify that a single instance object should be created
		// (by storing the Type and using Activator.GetInstance() at deserialization time)

		ArrayListType,             // Specific optimization for ArrayList type


		ObjectArrayType,           // Array types
		EmptyTypedArrayType,
		EmptyObjectArrayType,

		NonOptimizedTypedArrayType, // Identifies a typed array and how it is optimized
		FullyOptimizedTypedArrayType,
		PartiallyOptimizedTypedArrayType,
		OtherTypedArrayType,

		BooleanArrayType,
		ByteArrayType,
		CharArrayType,
		DateTimeArrayType,
		DecimalArrayType,
		DoubleArrayType,
		SingleArrayType,
		GuidArrayType,
		Int16ArrayType,
		Int32ArrayType,
		Int64ArrayType,
		SByteArrayType,
		TimeSpanArrayType,
		UInt16ArrayType,
		UInt32ArrayType,
		UInt64ArrayType,
		StringArrayType,

		OwnedDataSerializableAndRecreatableType,

		EnumType,
		OptimizedEnumType,

		SurrogateHandledType,
		// Placeholders to indicate number of Type Codes remaining
		Reserved24,
		Reserved23,
		Reserved22,
		Reserved21,
		Reserved20,
		Reserved19,
		Reserved18,
		Reserved17,
		Reserved16,
		Reserved15,
		Reserved14,
		Reserved13,
		Reserved12,
		Reserved11,
		Reserved10,
		Reserved9,
		Reserved8,
		Reserved7,
		Reserved6,
		Reserved5,
		Reserved4,
		Reserved3,
		Reserved2,
		Reserved1
	}
	

	/// <summary>
	/// Enum which defines the serialization settings available. 
	/// </summary>
	/// <remarks>Adapter specific</remarks>
	public enum SerializationOptimization
	{
		/// <summary>
		/// Uses the original LLBLGenPro serialization/deserialization code
		/// </summary>
		None,
		/// <summary>
		/// Uses the fast serialization code for compact, fast serialization. If you use this option, be sure that the deserialization has to take place
		/// using this same code. 
		/// </summary>
		Fast
	}


	/// <summary>
	/// Enum which is used in Auditors, to signal that this single statement query action is about to be executed and that the framework would like
	/// to know if the auditor expects to have entities to save after the statement so a transaction should be started.
	/// </summary>
	public enum SingleStatementQueryAction
	{
		/// <summary>
		/// An insert of a new entity is about to be started
		/// </summary>
		NewEntityInsert,
		/// <summary>
		/// An update of an existing entity is about to be started
		/// </summary>
		ExistingEntityUpdate,
		/// <summary>
		/// A delete of an existing entity is about to be started
		/// </summary>
		EntityDelete,
		/// <summary>
		/// A direct update of entities in the database with a single update statement is about to be started
		/// </summary>
		DirectUpdateEntities,
		/// <summary>
		/// A direct delete of entities in the database with a single delete statement is about to be started
		/// </summary>
		DirectDeleteEntities
	}


	/// <summary>
	/// Enum to specify the hint what to do when authorization fails on a newly fetched entity into a new object. 
	/// </summary>
	public enum FetchNewAuthorizationFailureResultHint
	{
		/// <summary>
		/// Clear the data of the entity. The entity is added to the collection, if the fetch was a collection fetch. 
		/// </summary>
		ClearData,
		/// <summary>
		/// The entity is thrown out and not added to a collection, if the fetch was a collection fetch. This is the default.
		/// </summary>
		ThrowAway
	}


	/// <summary>
	/// Enum defined for dependency injection information, to specify the targetkind 
	/// </summary>
	public enum DependencyInjectionTargetKind
	{
		/// <summary>
		/// The instance will be injected only in the type specified as targettype, all subtypes of targettype won't get the instance injected
		/// </summary>
		Absolute,
		/// <summary>
		/// The instance will be injected in the type specified as targettype and all subtypes of targettype. This is the default.
		/// </summary>
		Hierarchy
	}


	/// <summary>
	/// Enum defined to specify in which context the instance to inject lives in.
	/// </summary>
	public enum DependencyInjectionContextType
	{
		/// <summary>
		/// every target gets a new instance of the instance type injected. This is the default.
		/// </summary>
		NewInstancePerTarget,
		/// <summary>
		/// Every target gets the same instance of the instance type injected. 
		/// </summary>
		/// <remarks>The singleton instance is thread-specific, so different threads have different singletons</remarks>
		Singleton
	}


	/// <summary>
	/// Enum definition for LLBLGenProDataSource(2) controls to signal what sorting mode they have to use for selects.
	/// </summary>
	public enum DataSourceSortingMode
	{
		/// <summary>
		/// Use server-side sorting, which will use solely entity fields (default)
		/// </summary>
		ServerSide,
		/// <summary>
		/// Use client-side sorting, which will use all properties specified, also non-field properties. 
		/// </summary>
		ClientSide
	}


	/// <summary>
	/// Enum to define the data cache to use for the LLBLGen Pro DataSource controls in an ASP.NET application
	/// </summary>
	public enum DataSourceCacheLocation
	{
		/// <summary>
		/// Data is stored in the viewstate. Default.
		/// </summary>
		ViewState,
		/// <summary>
		/// Data is stored in the Session object using a key which is unique for control instance - page combination. 
		/// </summary>
		Session,
		/// <summary>
		/// Data is stored in the ASPNet cache using a GUID based key. As the data cached is used in a post-back
		/// scenario when data has changed, the duration of the cached data is set to the value specified in the ASPNetCacheDuration property of the
		/// datasource control. Duration is always sliding, i.e. expires after ASPNetCacheDuration if the data hasn't been requested from the ASPNet cache. 
		/// </summary>
		ASPNetCache
	}


	/// <summary>
	/// Enum which specifies the type of object which contains the data in an LLBLGenProDataSource(2) control in an ASP.NET application
	/// </summary>
	public enum DataSourceDataContainerType
	{
		/// <summary>
		/// The object containing the data is an entity collection (selfservicing style or adapter style). 
		/// </summary>
		EntityCollection,
		/// <summary>
		/// The object containing the data is a typed list
		/// </summary>
		TypedList,
		/// <summary>
		/// The object containing the data is a typed view.
		/// </summary>
		TypedView
	}


	/// <summary>
	/// Enum which specifies when the MemberPredicate should be considered 'true'
	/// </summary>
	public enum MemberOperator
	{
		/// <summary>
		/// The contained filter in the MemberPredicate has to return true for all elements in the specified member.
		/// </summary>
		All,
		/// <summary>
		/// The contained filter in the MemberPredicate has to return true for at least one element in the specified member.
		/// </summary>
		Any,
		/// <summary>
		/// The specified member has no data. The specified filter of the MemberPredicate is ignored. This operator can for example be used to test if
		/// the specified member is set, e.g. filter on all OrderEntity instances which have Customer set to an instance.
		/// </summary>
		Null
	}


	/// <summary>
	/// Enum for compatibility level in the SqlServer DQE
	/// </summary>
	public enum SqlServerCompatibilityLevel
	{
		/// <summary>
		/// Produce SQL which is compatible with SqlServer 7 and up
		/// </summary>
		SqlServer7,
		/// <summary>
		/// Produce SQL which is compatible with SqlServer 2000 and up (default)
		/// </summary>
		SqlServer2000,
		/// <summary>
		/// Produce SQL which is compatible with SqlServer 2005 and up
		/// </summary>
		SqlServer2005
	}


	/// <summary>
	/// Enum to specify what to do when the data in the related collection of an entity view changes. A change in data can be: entity added or changed.
	/// If an entity is removed from the underlying collection, the entity is simply removed from the entity view, as the view doesn't contain any data by itself.
	/// </summary>
	public enum PostCollectionChangeAction
	{
		/// <summary>
		/// A set filter or sorter isn't re-applied to the changed entity/ies, so the change won't affect the order of the entities in the view nor which rows are in 
		/// the view. 
		/// </summary>
		NoAction,
		/// <summary>
		/// The set filter and the set sorter are re-applied to the entity which caused the change. This is the default and will make the entity view
		/// a true 'live' view on the related entity collection
		/// </summary>
		ReapplyFilterAndSorter,
		/// <summary>
		/// The set sorter is re-applied to the entities in the view.
		/// </summary>
		ReapplySorter
	}

	/// <summary>
	/// Enum to specify to the IConcurrencyPredicateFactory what kind of predicate to produce
	/// </summary>
	public enum ConcurrencyPredicateType
	{
		/// <summary>
		/// The predicate type requested is for a Save action
		/// </summary>
		Save,
		/// <summary>
		/// The predicate type requested is for a Delete action
		/// </summary>
		Delete
	}


	/// <summary>
	/// Enum definition for defining the hierarchy type of the inheritance tree
	/// </summary>
	public enum InheritanceHierarchyType:int
	{
		/// <summary>
		/// No hierarchy defined for this entity or the entity isn't the root entity.
		/// </summary>
		None,
		/// <summary>
		/// All entities map to the single target (table/view)
		/// </summary>
		TargetPerEntityHierarchy,
		/// <summary>
		/// Per entity a target (table/view) is defined, with just the fields of the derived entity, not the fields of the parent entity.
		/// </summary>
		TargetPerEntity
	}


	/// <summary>
	/// Enum which is used to specify block types, to identity groups of actions under the same type, e.g. inserts or updates.
	/// </summary>
	public enum UnitOfWorkBlockType
	{
		/// <summary>
		/// All entity insert actions
		/// </summary>
		Inserts,
		/// <summary>
		/// All entity update actions
		/// </summary>
		Updates,
		/// <summary>
		/// All entity delete actions.
		/// </summary>
		Deletes,
		/// <summary>
		/// All delete actions performed directly on the database.
		/// </summary>
		DeletesPerformedDirectly,
		/// <summary>
		/// All update actions performed directly on the database.
		/// </summary>
		UpdatesPerformedDirectly
	}


	/// <summary>
	/// Enum definition to tell the UnitOfWork that the passed in callback should be executed in the slot specified.
	/// Entities are executed in the order: Insert, Update, Delete. 
	/// </summary>
	public enum UnitOfWorkCallBackScheduleSlot
	{
		/// <summary>
		/// Execute the callback before the first entity is inserted.
		/// </summary>
		PreEntityInsert,
		/// <summary>
		/// Execute the callback after the last entity has been inserted but before the first entity will be updated.
		/// </summary>
		PreEntityUpdate,
		/// <summary>
		/// Execute the callback after the last entity has been updated but before the first entity will be deleted.
		/// </summary>
		PreEntityDelete,
		/// <summary>
		/// Execute the callback after the last entity has been deleted.
		/// </summary>
		PostEntityDelete
	}


	/// <summary>
	/// Enum definition for the flags which can be passed to overloads of WriteXml(). These flags control the way the format of the output. 
	/// </summary>
	[Flags]
	public enum XmlFormatAspect:int
	{
		/// <summary>
		/// No aspects have been specified, the defaults are used.
		/// </summary>
		None=0,
		/// <summary>
		/// Produces more compact XML. This xml doesn't contain type information attributes, nor non-data fields for objects. The default is verbose.
		/// </summary>
		/// <remarks>Adapter: it's recommended that you use Compact25 instead of this format as it's more compact and faster to deserialize.</remarks>
		Compact=1,
		/// <summary>
		/// Places all strings with a &lt; and or &gt; in CDATA blocks. The default is not to do this.
		/// </summary>
		MLTextInCDataBlocks=2,
		/// <summary>
		/// Exports all DateTime values in the standard date/time format for XML: DateTime.ToString("yyyy-MM-ddTHH:mm:ss.fffffffzzzzzz");. The default is
		/// to export DateTime values in ticks. 
		/// </summary>
		DatesInXmlDataType=4,
		/// <summary>
		/// Adapter specific. More optimal XML than Compact, introduced in v2.5. Use this format to have the most compact XML output which still contains change tracking/state information
		/// for full round-tripping support for entities and entity graphs. If both Compact and Compact25 are specified, Compact25 is used. 
		/// Webservice support code in Adapter uses Compact25. 
		/// </summary>
		Compact25=8
	}


	/// <summary>
	/// SqlServer specific enum definition for Adapter template set. Specifies for the active DataAccessAdapter object what
	/// to do with the catalog name in persistence information set into fields. 
	/// </summary>
	public enum CatalogNameUsage:int
	{
		/// <summary>
		/// Use default behaviour, which means that nothing is done to the catalog name specified in the persistence info.
		/// </summary>
		Default,
		/// <summary>
		/// Force the name specified in the property DataAccessAdapter.CatalogNameToUse. 
		/// </summary>
		ForceName,
		/// <summary>
		/// Clears the catalog name specified in the persistence information. This means that the catalog name specified in the
		/// connection string is used by SqlServer where to locate specified tables etc.. Clearing of the catalog name makes the
		/// SqlServer DQE ignore the catalog name when generating names.
		/// </summary>
		Clear
	}


	/// <summary>
	/// Oracle specific enum definition for Adapter template set. Specifies for the active DataAccessAdapter object what
	/// to do with the schema name in persistence information set into fields. 
	/// </summary>
	public enum SchemaNameUsage:int
	{
		/// <summary>
		/// Use default behaviour, which means that nothing is done to the schema name specified in the persistence info.
		/// </summary>
		Default,
		/// <summary>
		/// Force the name specified in the property DataAccessAdapter.SchemaNameToUse. 
		/// </summary>
		ForceName,
		/// <summary>
		/// Clears the Schema name specified in the persistence information. This means that the schema name specified in the
		/// persistence info is cleared. This results in the fact that database objects are not prefixed with a schema, and
		/// will only result in a succesful query if global synonym equivalents are available.
		/// </summary>
		Clear
	}


	/// <summary>
	/// Enum definition for the hint specified in the Add method of RelationCollection.
	/// </summary>
	public enum JoinHint:int
	{
		/// <summary>
		/// No hint specified. Use INNER unless ObeyWeakRelations is set to true.
		/// </summary>
		None,
		/// <summary>
		/// Inner join between start and end entity of given relation
		/// Overrules the set ObeyWeakRelations flag for this relation.
		/// </summary>
		Inner,
		/// <summary>
		/// Hints a LEFT join between start and end entity in relation. 
		/// Overrules the set ObeyWeakRelations flag for this relation.
		/// </summary>
		Left,
		/// <summary>
		/// Hints a RIGHT join between start and end entity in relation. 
		/// Overrules the set ObeyWeakRelations flag for this relation.
		/// </summary>
		Right,
		/// <summary>
		/// Hints a CROSS join between start and end entity in relation.
		/// Overrules the set ObeyWeakRelations flag for this relation.
		/// </summary>
		Cross=4
	}


	/// <summary>
	/// Enum definition for the type of a PredicateExpressionElement
	/// </summary>
	public enum PredicateExpressionElementType:int
	{
		/// <summary>
		/// Element contains an Operator
		/// </summary>
		Operator,
		/// <summary>
		/// Element contains an IPredicate implementing object.
		/// </summary>
		Predicate,
		/// <summary>
		/// The element is empty.
		/// </summary>
		Empty
	}


	/// <summary>
	/// Enum definition for the type of a predicate instance.
	/// This enum is stored in Predicate as an int and is used in DataAccessAdapterBase derived classes.
	/// </summary>
	public enum PredicateType:int
	{
		/// <summary>
		/// Undefined type. 
		/// </summary>
		Undefined=0,
		/// <summary>
		/// A FieldBetweenPredicate instance
		/// </summary>
		FieldBetweenPredicate,
		/// <summary>
		/// A FieldCompareNullPredicate instance
		/// </summary>
		FieldCompareNullPredicate,
		/// <summary>
		/// A FieldCompareValuePredicate instance
		/// </summary>
		FieldCompareValuePredicate,
		/// <summary>
		/// A FieldLikePredicate instance
		/// </summary>
		FieldLikePredicate, 
		/// <summary>
		/// A predicate expression object containing 0 or more predicate elements.
		/// </summary>
		PredicateExpression,
		/// <summary>
		/// A FieldCompareRangePredicate instance.
		/// </summary>
		FieldCompareRangePredicate,
		/// <summary>
		/// A FieldFullTextSearchPredicate (SqlServer 2000 specific). Future enhancement.
		/// </summary>
		FieldFullTextSearchPredicate,
		/// <summary>
		/// A FieldCompareExpression predicate. 
		/// </summary>
		FieldCompareExpressionPredicate,
		/// <summary>
		/// A FieldCompareSet predicate
		/// </summary>
		FieldCompareSetPredicate
	}


	/// <summary>
	/// Enum definition for the type of relation an EntityRelation object represents.
	/// There is no definition for m:n relation because EntityRelation can't represent a m:n relation
	/// </summary>
	public enum RelationType:int
	{
		/// <summary>
		/// A 1:n relation
		/// </summary>
		OneToMany,
		/// <summary>
		/// A 1:1 relation
		/// </summary>
		OneToOne,
		/// <summary>
		/// A m:1 relation
		/// </summary>
		ManyToOne,
		/// <summary>
		/// A m:n relation
		/// </summary>
		ManyToMany
	}


	/// <summary>
	/// Enum definition for the operator used in the FieldCompareValue Predicate.
	/// </summary>
	public enum ComparisonOperator:int
	{
		/// <summary>
		/// == . The only operator useful for boolean (bit) Fields.
		/// </summary>
		Equal,
		/// <summary>
		/// &lt;=
		/// </summary>
		LessEqual,
		/// <summary>
		/// &lt;
		/// </summary>
		LesserThan,
		/// <summary>
		/// &gt;=
		/// </summary>
		GreaterEqual,
		/// <summary>
		/// &gt;
		/// </summary>
		GreaterThan,
		/// <summary>
		/// &lt;&gt; or !=
		/// </summary>
		NotEqual	
	}


	/// <summary>
	/// Enum definition for the operators used with the FieldCompareSetPredicate class.
	/// </summary>
	public enum SetOperator:int
	{
		/// <summary>
		/// IN (set) operator.
		/// </summary>
		/// <remarks>On MySql, don't use In with Negate set to true, as that will lead to unexpected results due to MySql not being correct in this. Use NotEqualAll instead</remarks>
		In,
		/// <summary>
		/// EXISTS(set) operator.
		/// </summary>
		Exist,
		/// <summary>
		/// == (set with 1 value) operator
		/// </summary>
		Equal,
		/// <summary>
		/// == ANY (set) operator
		/// </summary>
		EqualAny,
		/// <summary>
		/// == ALL (set) operator
		/// </summary>
		EqualAll,
		/// <summary>
		/// &lt;= (set with 1 value) operator
		/// </summary>
		LessEqual,
		/// <summary>
		/// &lt;= ANY (set) operator
		/// </summary>
		LessEqualAny,
		/// <summary>
		/// &lt;= ALL (set) operator
		/// </summary>
		LessEqualAll,
		/// <summary>
		/// &lt; (set with 1 value) operator
		/// </summary>
		LesserThan,
		/// <summary>
		/// &lt; ANY (set) operator
		/// </summary>
		LesserThanAny,
		/// <summary>
		/// &lt; ALL (set) operator
		/// </summary>
		LesserThanAll,
		/// <summary>
		/// &gt;= (set with 1 value) operator
		/// </summary>
		GreaterEqual,
		/// <summary>
		/// &gt;= ANY (set) operator
		/// </summary>
		GreaterEqualAny,
		/// <summary>
		/// &gt;= ALL (set) operator
		/// </summary>
		GreaterEqualAll,
		/// <summary>
		/// &gt; (set with 1 value) operator
		/// </summary>
		GreaterThan,
		/// <summary>
		/// &gt; ANY (set) operator
		/// </summary>
		GreaterThanAny,
		/// <summary>
		/// &gt; ALL (set) operator
		/// </summary>
		GreaterThanAll,
		/// <summary>
		/// &lt;&gt; (set with 1 value) operator
		/// </summary>
		NotEqual,
		/// <summary>
		/// &lt;&gt; ANY (set) operator
		/// </summary>
		NotEqualAny,
		/// <summary>
		/// &lt;&gt; ALL (set) operator
		/// </summary>
		NotEqualAll
	}



	/// <summary>
	/// Enum definition for the Operators used in PredicateExpressions
	/// </summary>
	public enum PredicateExpressionOperator:int
	{
		/// <summary>
		/// The AND operator.
		/// </summary>
		And,
		/// <summary>
		/// The OR operator.
		/// </summary>
		Or
	}


	/// <summary>
	/// Enum definition for the sort operator, which can be specified with IEntityField instances to create
	/// order by clauses.
	/// </summary>
	public enum SortOperator:int
	{
		/// <summary>
		/// Makes sorts Ascending
		/// </summary>
		Ascending,
		/// <summary>
		/// Makes sorts Descending
		/// </summary>
		Descending
	}


	/// <summary>
	/// Enum definition for the state an Entity can be in.
	/// </summary>
	public enum EntityState:int
	{
		/// <summary>
		/// Entity is new. It can be empty or filled, but is not saved (yet) to the persistent storage.
		/// </summary>
		New,
		/// <summary>
		/// Entity is filled with its data from the persistent storage. It can be changed since the fetch.
		/// </summary>
		Fetched,
		/// <summary>
		/// Entity is out of sync with its physical entity in the persistent storage. 
		/// An Entity is marked OutOfSync when a succesful Save action is performed. 
		/// An Entity will re-fetch itself when in the state OutOfSync when a property
		/// is read or Refetch() is called. The state will then be set to Fetched.
		/// </summary>
		OutOfSync,
		/// <summary>
		/// Adapter specific. If an entity has the state Deleted, it is no longer
		/// available in the persistent storage.
		/// </summary>
		Deleted
	}


	/// <summary>
	/// Enum definition for the various aggregate functions which can be applied to fields in a retrieval query. 
	/// Useful in typed lists. Use these in combination with a groupbycollection.
	/// Not all functions are legal on all fields. Some functions will produce errors when used with fields of a given type,
	/// like a Sum function with a character field. This is the responsibility of the developer. Aggregate functions are
	/// never applied to *lob fields. 
	/// </summary>
	public enum AggregateFunction:int
	{
		/// <summary>
		/// Default, do not apply an aggregate function to the field.
		/// </summary>
		None,
		/// <summary>
		/// Calculates the amount of rows for the field. Results in COUNT(field) 
		/// </summary>
		Count,
		/// <summary>
		/// Calculates the amount of rows with distinct values for field. Results in COUNT(DISTINCT field).
		/// Access, MySql: not supported
		/// </summary>
		CountDistinct,
		/// <summary>
		/// Calculates the amount of rows. Results in a COUNT(*)
		/// </summary>
		CountRow,
		/// <summary>
		/// Calculates the average value for the field. Results in an AVG(field)
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only</remarks>
		Avg,
		/// <summary>
		/// Calculates the average value for the distinct values for field. Results in an AVG(DISTINCT field).
		/// Access, MySql: not supported
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only</remarks>
		AvgDistinct,
		/// <summary>
		/// Calculates the max value for field. Results in a MAX(field). 
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only</remarks>
		Max,
		/// <summary>
		/// Calculates the min value for field. Results in a MIN(field)
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only</remarks>
		Min,
		/// <summary>
		/// Calculates the sum of all values of field. Results in a SUM(field)
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only</remarks>
		Sum,
		/// <summary>
		/// Calculates the sum of all distinct values of field. Results in a SUM(DISTINCT field). 
		/// Access, MySql: not supported
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only</remarks>
		SumDistinct,
		/// <summary>
		/// Calculates statistical standard deviation. Results in:
		/// SqlServer: STDEV(field)<br/>
		/// Oracle, MySql: STDDEV(field)<br/>
		/// Access: STDEV(field)<br/>
		/// Firebird: not supported
		/// </summary>
		/// <remarks>Works on float fields only</remarks>
		StDev,
		/// <summary>
		/// Calculates statistical standard deviation over distinct values. Results in:
		/// SqlServer: not supported<br/>
		/// Oracle: STDDEV(DISTINCT field)<br/>
		/// Access, Firebird, MySql: not supported<br/>
		/// </summary>
		/// <remarks>Works on float fields only</remarks>
		StDevDistinct,
		/// <summary>
		/// Calculates statistical variance. Results in:
		/// SqlServer: VAR(field)<br/>
		/// Oracle, MySql: VARIANCE(field)<br/>
		/// Access: VAR(field)<br/>
		/// Firebird: not supported.
		/// </summary>
		/// <remarks>Works on float fields only</remarks>
		Variance,
		/// <summary>
		/// Calculates statistical variance over distinct values. Results in:
		/// SqlServer: not supported<br/>
		/// Oracle: VARIANCE(DISTINCT field)<br/>
		/// Access, Firebird, MySql: not supported<br/>
		/// </summary>
		/// <remarks>Works on float fields only</remarks>
		VarianceDistinct
	}


	/// <summary>
	/// Enum definition for the various aggregate functions supported by the <see cref="AggregateSetPredicate"/> for in-memory filters.
	/// </summary>
	public enum AggregateSetFunction : int
	{
		/// <summary>
		/// Calculates the amount of elements matching the specified filter. Result is of type Int32
		/// </summary>
		Count,
		/// <summary>
		/// Calculates the amount of elements matching the specified filter, ignoring duplicates. Result is of type Int32. NULL/DBNull.Value is counted as a value.
		/// </summary>
		CountDistinct,
		/// <summary>
		/// Calculates the average value for the values in the set. Result is of type Decimal.
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only. </remarks>
		Avg,
		/// <summary>
		/// Calculates the average value for the values in the set, excluding duplicates. Result is of type Decimal
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only</remarks>
		AvgDistinct,
		/// <summary>
		/// Calculates the max value for the values in the set. Result is of the type of the values in the set.
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only</remarks>
		Max,
		/// <summary>
		/// Calculates the min value for the values in the set. Result is of the type of the values in the set.
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only</remarks>
		Min,
		/// <summary>
		/// Calculates the sum of all values in the set. Result is of the type of the values in the set.
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only</remarks>
		Sum,
		/// <summary>
		/// Calculates the sum of all values in the set excluding duplicates. Result is of the type of the values in the set.
		/// </summary>
		/// <remarks>works on numeric fields (decimal/int/float/byte/etc.) only</remarks>
		SumDistinct
	}


	
	/// <summary>
	/// Enum for defining the type of the expression element in an expression object
	/// </summary>
	public enum ExpressionElementType:int
	{
		/// <summary>
		/// The element contains a value
		/// </summary>
		Value,
		/// <summary>
		/// The element contains a field
		/// </summary>
		Field,
		/// <summary>
		/// The element contains an expression
		/// </summary>
		Expression,
		/// <summary>
		/// The element contains a function call.
		/// </summary>
		FunctionCall,
		/// <summary>
		/// The element contains a Scalar query
		/// </summary>
		ScalarQuery
	}


	/// <summary>
	/// Enum definition for the ExpressionOperators (ExOp). Name is shortened to limit typing.
	/// </summary>
	public enum ExOp:int
	{
		/// <summary>
		/// None specified. 
		/// </summary>
		None,
		/// <summary>
		/// Add arithmetic operator
		/// </summary>
		Add,
		/// <summary>
		/// Sub(tract) arithmetic operator
		/// </summary>
		Sub,
		/// <summary>
		/// Mul(tiply) arithmetic operator
		/// </summary>
		Mul,
		/// <summary>
		/// Div(ision) arithmetic operator
		/// </summary>
		Div,
		/// <summary>
		/// Mod(ulo) arithmetic operator
		/// </summary>
		Mod,
		/// <summary>
		/// Equal (==) logical operator
		/// </summary>
		Equal,
		/// <summary>
		/// GreaterEqual (&gt;=) logical operator
		/// </summary>
		GreaterEqual,
		/// <summary>
		/// Greater (&gt;) logical operator
		/// </summary>
		GreaterThan,
		/// <summary>
		/// LessEqual (&lt;=) logical operator
		/// </summary>
		LessEqual,
		/// <summary>
		/// Lesser (&lt;) logical operator
		/// </summary>
		LesserThan,
		/// <summary>
		/// Not Equal (!=) logical operator
		/// </summary>
		NotEqual,
		/// <summary>
		/// And logical operator
		/// </summary>
		And,
		/// <summary>
		/// Or logical operator
		/// </summary>
		Or,
		/// <summary>
		/// Bitwise and (&amp;) operator
		/// </summary>
		BitwiseAnd,
		/// <summary>
		/// Bitwise or (|) operator
		/// </summary>
		BitwiseOr,
		/// <summary>
		/// Bitwise exclusive or (Xor) (^) operator
		/// </summary>
		BitwiseXor
	}


	/// <summary>
	/// Operator to use with FieldFullTextSearchPredicate.
	/// SqlServer specific.
	/// </summary>
	public enum FullTextSearchOperator:int
	{
		/// <summary>
		/// Produces a CONTAINS() statement
		/// </summary>
		Contains,
		/// <summary>
		/// Produces a FREETEXT() statement
		/// </summary>
		Freetext
	}


	/// <summary>
	/// Enum definition for RDBMS hints, like table lock hints and other hints.
	/// </summary>
	public enum RdbmsHint:int
	{
		/// <summary>
		/// Hint for statements to apply to a table specification in a FROM clause. For example, in Sqlserver, if the setting is switched on, this hint
		/// will produce (NOLOCK) as a hint to use.
		/// </summary>
		TableInFromClauseHint
	}


	/// <summary>
	/// Enum to define the types of parameters in a dbfunction call. Used internally to quickly call the right routine for parameter to text conversion
	/// </summary>
	internal enum DbFunctionCallParameterType
	{
		/// <summary>
		/// Parameter is a field
		/// </summary>
		Field, 
		/// <summary>
		/// Parameter is a value.
		/// </summary>
		Value, 
		/// <summary>
		/// Parameter is an expression.
		/// </summary>
		Expression
	}


	/// <summary>
	/// Enum to signal what kind of data to output to XML
	/// </summary>
	internal enum KindOfDataToOutput
	{
		/// <summary>
		/// Data is XML
		/// </summary>
		Collection,
		/// <summary>
		/// Data is an entity
		/// </summary>
		Entity
	}


	/// <summary>
	/// Constant holder for the version of this library. Because the library is signed, it has a general version, like 1.0.2003.2, but
	/// it also has an internal version, stored in this struct, which reflects the build date. Versions are always equal for the DQE's and the ORM
	/// support classes.
	/// </summary>
	[Serializable]
	public struct RuntimeLibraryVersion
	{
		/// <summary>
		/// Version reflects the general version of this library, for example 1.0.2003.2
		/// </summary>
		public static readonly string Version = "2.5.0.0";
		/// <summary>
		/// Contains the build number of this version, which is build up like this: MMDDYYYY
		/// </summary>
		public static readonly string Build = "06182008";
	}

}
