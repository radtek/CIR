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
//		- Simon Hewitt 
//		- Frans Bouma
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Helper class containing:
	/// - The default serialization to use.
	/// - Some string constants used as names in SerializationInfo
	/// - Some shared routines used for fast serialization to save duplication
	/// </summary>
	public static class SerializationHelper
	{
		#region Flag bitmask definitions
		// Collection bitmask definitions
		internal static readonly int CollectionHasEntitiesMask = BitVector32.CreateMask();
		internal static readonly int CollectionHasCommonEntityTypesMask = BitVector32.CreateMask(CollectionHasEntitiesMask);
		internal static readonly int CollectionIsCommonEntityFactoryCollectionEntityFactoryMask = BitVector32.CreateMask(CollectionHasCommonEntityTypesMask);
		internal static readonly int CollectionHasEntitiesWithDependentRelatedEntitiesMask = BitVector32.CreateMask(CollectionIsCommonEntityFactoryCollectionEntityFactoryMask);
		internal static readonly int CollectionHasEntitiesWithDependingRelatedEntitiesMask = BitVector32.CreateMask(CollectionHasEntitiesWithDependentRelatedEntitiesMask);
		internal static readonly int CollectionHasEntitiesWithPopulatedMemberCollectionsMask = BitVector32.CreateMask(CollectionHasEntitiesWithDependingRelatedEntitiesMask);
		internal static readonly int CollectionReadOnlyMask = BitVector32.CreateMask(CollectionHasEntitiesWithPopulatedMemberCollectionsMask);

		internal static readonly int CollectionNotHasEntityFactoryMask = BitVector32.CreateMask(CollectionReadOnlyMask);
		internal static readonly int CollectionNotAllowNewMask = BitVector32.CreateMask(CollectionNotHasEntityFactoryMask);
		internal static readonly int CollectionNotAllowRemoveMask = BitVector32.CreateMask(CollectionNotAllowNewMask);
		internal static readonly int CollectionNotAllowEditMask = BitVector32.CreateMask(CollectionNotAllowRemoveMask);
		internal static readonly int CollectionDoNotPerformAddIfPresentMask = BitVector32.CreateMask(CollectionNotAllowEditMask);
		internal static readonly int CollectionHasConcurrencyPredicateFactoryMask = BitVector32.CreateMask(CollectionDoNotPerformAddIfPresentMask);

		internal static readonly int CollectionCombinedRelationsMask = CollectionHasEntitiesWithDependentRelatedEntitiesMask |
		                                                               CollectionHasEntitiesWithDependingRelatedEntitiesMask |
		                                                               CollectionHasEntitiesWithPopulatedMemberCollectionsMask;
		// ---------------
		
		// Entity bitmask definitions. 
		internal static readonly int EntityHasPreservedObjectIDMask = BitVector32.CreateMask();
		internal static readonly int EntityHasPopulatedMemberEntityCollections = BitVector32.CreateMask(EntityHasPreservedObjectIDMask);
		internal static readonly int EntityHasDependentRelatedEntities = BitVector32.CreateMask(EntityHasPopulatedMemberEntityCollections);
		internal static readonly int EntityHasDependingRelatedEntities = BitVector32.CreateMask(EntityHasDependentRelatedEntities);
		internal static readonly int EntityIsNewMask = BitVector32.CreateMask(EntityHasDependingRelatedEntities);
		internal static readonly int EntityFieldStateBit0 = BitVector32.CreateMask(EntityIsNewMask);
		internal static readonly int EntityFieldStateBit1 = BitVector32.CreateMask(EntityFieldStateBit0);

		internal static readonly int EntityAreFieldsDirtyMask = BitVector32.CreateMask(EntityFieldStateBit1);
		internal static readonly int EntityHasValidatorMask = BitVector32.CreateMask(EntityAreFieldsDirtyMask);
		internal static readonly int EntityHasConcurrencyPredicateFactoryToUseMask = BitVector32.CreateMask(EntityHasValidatorMask);
		internal static readonly int EntityHasAuthorizerMask = BitVector32.CreateMask(EntityHasConcurrencyPredicateFactoryToUseMask);
		internal static readonly int EntityHasAuditorMask = BitVector32.CreateMask(EntityHasAuthorizerMask);
		internal static readonly int EntityHasDataErrorInfoErrorMask = BitVector32.CreateMask(EntityHasAuditorMask);
		internal static readonly int EntityHasDataErrorInfoErrorsPerFieldMask = BitVector32.CreateMask(EntityHasDataErrorInfoErrorMask);

		internal static readonly int EntityHasSavedFieldsMask = BitVector32.CreateMask(EntityHasDataErrorInfoErrorsPerFieldMask);
		internal static readonly int EntityIsNameNotDefaultMask = BitVector32.CreateMask(EntityHasSavedFieldsMask);
		internal static readonly int EntityHasOneWayRelations = BitVector32.CreateMask(EntityIsNameNotDefaultMask);

		internal static readonly int CombinedEntityRelationsMask = EntityHasPopulatedMemberEntityCollections |
																   EntityHasDependentRelatedEntities |
																   EntityHasDependingRelatedEntities;
		// ---------------

		// TypedList bitmask definitions
		internal static readonly int TypedListObeyWeakRelations = BitVector32.CreateMask();
		// ---------------

		// UnitOfWork2 bitmask definitions
		internal static readonly int UnitOfWorkHasCollectionsToDeleteMask = BitVector32.CreateMask();
		internal static readonly int UnitOfWorkHasCollectionsToSaveMask = BitVector32.CreateMask(UnitOfWorkHasCollectionsToDeleteMask);
		internal static readonly int UnitOfWorkHasEntitiesToSaveMask = BitVector32.CreateMask(UnitOfWorkHasCollectionsToSaveMask);
		internal static readonly int UnitOfWorkHasEntitiesToDeleteMask = BitVector32.CreateMask(UnitOfWorkHasEntitiesToSaveMask);
		#endregion

		#region Static Members and constants
		internal static readonly BitArray FullyReferencedEntityCollection = new BitArray(0);
		
		/// <summary>
		/// Set this field to the serialization optimization you want to use, application wide. Default: None (use the regular binary formatter serialization
		/// / deserialization). 
		/// </summary>
		public static SerializationOptimization Optimization = SerializationOptimization.None;

		/// <summary>
		/// Setting for the compressor to use on the serialized bytestream. Default: none. 
		/// </summary>
		public static IByteCompressor Compressor = null;

		/// <summary>
		/// Flag to signal if ObjectID's should be serialized into the output or not. Default: true.
		/// </summary>
		/// <remarks>Setting this to false will result in smaller datablocks. However if you use a context on the server/client or otherwise need to 
		/// have the entity objects look like the same object when a roundtrip occurs to server/client, you have to keep this flag set to 'false', otherwise
		/// every time the entity object is deserialized it will get a new ObjectID. </remarks>
		public static bool PreserveObjectIDs = true;
		
		/// <summary>
		/// Name under which the data is stored in the info block. 
		/// </summary>
		public const string SerializationKey = "_";
		#endregion

		/// <summary>
		/// Serializes the entity fields passed in. 
		/// </summary>
		/// <param name="writer">The writer.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="isDirty">flag if the fields passed in are dirty. </param>
		public static void SerializeEntityFields(SerializationWriter writer, IEntityFields2 fields, bool isDirty)
		{
			int fieldCount = fields.Count;
			if (isDirty)
			{
				// Save both current and database data
				object[] dbData = new object[fieldCount];
				object[] currentData = new object[fieldCount];
				BitArray changedBits = new BitArray(fieldCount);
				for (int i = 0; i < fieldCount; i++)
				{
					dbData[i] = fields[i].DbValue;
					currentData[i] = fields[i].CurrentValue;
					changedBits[i] = fields[i].IsChanged;
				}
				writer.WriteOptimized(dbData, currentData);
				writer.WriteOptimized(changedBits);
			}
			else
			{
				// Just save one of the sets of values
				object[] dbData = new object[fieldCount];
				for (int i = 0; i < fieldCount; i++) dbData[i] = fields[i].DbValue;
				writer.WriteOptimized(dbData);
			}
		}


		/// <summary>
		/// Deserializes the entity fields data passed in into the fields object passed in.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="isDirty">Flag to signal if the field data contains dirty field(s)</param>
		/// <param name="isNew">Flag to signal if the entity is new</param>
		public static void DeserializeEntityFields(SerializationReader reader, IEntityFields2 fields, bool isDirty, bool isNew)
		{
			if (isDirty)
			{
				// Full deserialization
				object[] currentData;
				object[] dbData;
				reader.ReadOptimizedObjectArrayPair(out dbData, out currentData);

				BitArray fieldsFlagBits = reader.ReadOptimizedBitArray();
				for (int j = 0; j < fields.Count; j++)
				{
					EntityField2 field = (EntityField2) fields[j];
					field.ForcedCurrentValueWrite(currentData[j], dbData[j]);
					field.ForcedChangedWrite(fieldsFlagBits[j]);
					if (!isNew && dbData[j] == null)
					{
						field.ForcedIsNullWrite(true);
					}
				}
				fields.IsDirty = true;
			}
			else
			{
				// Implied deserialization based on:
				//   IsNull is false when IsNew is true
				//   IsNull is true when DbValue of a field is null and IsNew is false. 
				object[] dbData = reader.ReadOptimizedObjectArray();
				for (int j = 0; j < fields.Count; j++)
				{
					EntityField2 field = (EntityField2) fields[j];
					if (dbData[j] != null)
					{
						field.ForcedCurrentValueWrite(dbData[j], dbData[j]);
					}
					else
					{
						if (!isNew)
						{
							field.ForcedIsNullWrite(true);
						}
					}
				}

			}
		}


		/// <summary>
		/// Serializes the simple read only table data, which are stored in datatables (which are the base class for typedlists/views)
		/// </summary>
		/// <param name="writer">The writer.</param>
		/// <param name="table">The table.</param>
		public static void SerializeSimpleReadOnlyTableData(SerializationWriter writer, DataTable table)
		{
			writer.WriteOptimized(table.Rows.Count);
			foreach(DataRow row in table.Rows)
			{
				writer.WriteOptimized(row.ItemArray);
			}
		}

		
		/// <summary>
		/// Deserializes the simple read only table data into the datatable passed in. 
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="table">The table.</param>
		public static void DeserializeSimpleReadOnlyTableData(SerializationReader reader, DataTable table)
		{
			int rowCount = reader.ReadOptimizedInt32();
			table.BeginLoadData();
			for(int i = 0; i < rowCount; i++)
			{
				table.LoadDataRow(reader.ReadOptimizedObjectArray(), true);
			}
			table.EndLoadData();
		}


		/// <summary>
		/// Gets the serialized bytes.
		/// </summary>
		/// <param name="info">The info.</param>
		/// <returns>The serialized bytes</returns>
		private static byte[] GetSerializedBytes(SerializationInfo info)
		{
			byte[] serializedData = (byte[]) info.GetValue(SerializationHelper.SerializationKey, typeof(byte[]));
			if (Compressor != null)
			{
				serializedData = Compressor.Decompress(serializedData);
			}
			return serializedData;
		}


		/// <summary>
		/// Puts the serialized bytes into the SerializationInfo block, under the SerializationHelper.SerializationKey key. 
		/// </summary>
		/// <param name="info">The info.</param>
		/// <param name="writer">The writer.</param>
		private static void PutSerializedBytes(SerializationInfo info, SerializationWriter writer)
		{
			byte[] serializedData;

			if (Compressor == null)
			{
				serializedData = writer.ToArray();
			}
			else 
			{
				writer.AppendTokenTables();
				MemoryStream stream = (MemoryStream) writer.BaseStream;
				if(Compressor is IMemoryStreamByteCompressor)
				{
					serializedData = (Compressor as IMemoryStreamByteCompressor).Compress(stream);
				}
				else
				{
					serializedData = Compressor.Compress(stream.ToArray());
				}
			}
			info.AddValue(SerializationHelper.SerializationKey, serializedData);
		}


		#region EntityCollection related serialization/deserialization routines.
		/// <summary>
		/// Serializes the specified entity collection.
		/// </summary>
		/// <param name="entityCollection">The entity collection.</param>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		public static void Serialize(IEntityCollection2 entityCollection, SerializationInfo info, StreamingContext context)
		{
			FastSerializer fastSerializer = new FastSerializer();
			PutSerializedBytes(info, fastSerializer.Serialize(entityCollection));
		}


		/// <summary>
		/// Deserializes the specified entity collection.
		/// </summary>
		/// <param name="entityCollection">The entity collection.</param>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		public static void Deserialize(IEntityCollection2 entityCollection, SerializationInfo info, StreamingContext context)
		{
			FastDeserializer fastDeserializer = new FastDeserializer();
			fastDeserializer.Deserialize(GetSerializedBytes(info), entityCollection);
		}
		#endregion

		#region Entity related serialization/deserialization routines.
		/// <summary>
		/// Serializes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		public static void Serialize(EntityBase2 entity, SerializationInfo info, StreamingContext context)
		{
			FastSerializer fastSerializer = new FastSerializer();
			PutSerializedBytes(info, fastSerializer.Serialize(entity));
		}


		/// <summary>
		/// Deserializes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		public static void Deserialize(EntityBase2 entity, SerializationInfo info, StreamingContext context)
		{
			FastDeserializer fastDeserializer = new FastDeserializer();
			fastDeserializer.Deserialize(GetSerializedBytes(info), entity);
		}
		#endregion

		#region TypedView related serialization/deserialization routines.
		/// <summary>
		/// Serializes the specified typed view.
		/// </summary>
		/// <param name="typedView">The typed view.</param>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		public static void Serialize(ITypedView2 typedView, SerializationInfo info, StreamingContext context)
		{
			FastSerializer fastSerializer = new FastSerializer();
			PutSerializedBytes(info, fastSerializer.Serialize(typedView));
			info.AddValue("XmlSchema", null);
			info.AddValue("XmlDiffGram", null);
		}


		/// <summary>
		/// Deserializes the specified typed view.
		/// </summary>
		/// <param name="typedView">The typed view.</param>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		public static void Deserialize(ITypedView2 typedView, SerializationInfo info, StreamingContext context)
		{
			FastDeserializer fastDeserializer = new FastDeserializer();
			fastDeserializer.Deserialize(GetSerializedBytes(info), typedView);
		}
		#endregion 

		#region TypedList related serialization/deserialization routines.
		/// <summary>
		/// Serializes the specified typed list.
		/// </summary>
		/// <param name="typedList">The typed list.</param>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		public static void Serialize(TypedListCore typedList, SerializationInfo info, StreamingContext context)
		{
			FastSerializer fastSerializer = new FastSerializer();
			PutSerializedBytes(info, fastSerializer.Serialize(typedList));
			info.AddValue("XmlSchema", null);
			info.AddValue("XmlDiffGram", null);
		}


		/// <summary>
		/// Deserializes the specified typed list.
		/// </summary>
		/// <param name="typedList">The typed list.</param>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		public static void Deserialize(TypedListCore typedList, SerializationInfo info, StreamingContext context)
		{
			FastDeserializer fastDeserializer = new FastDeserializer();
			fastDeserializer.Deserialize(GetSerializedBytes(info), typedList);
		}
		#endregion

		#region UnitOfWork related serialization/deserialization routines.
		/// <summary>
		/// Serializes the specified unit of work.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		public static void Serialize(UnitOfWork2 unitOfWork, SerializationInfo info, StreamingContext context)
		{
			FastSerializer serializer = new FastSerializer();
			PutSerializedBytes(info, serializer.Serialize(unitOfWork));
		}

		/// <summary>
		/// Deserializes the specified unit of work.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		public static void Deserialize(UnitOfWork2 unitOfWork, SerializationInfo info, StreamingContext context)
		{
			FastDeserializer deserializer = new FastDeserializer();
			deserializer.Deserialize(GetSerializedBytes(info), unitOfWork);
		}
		#endregion UnitOfWork
	}

	
	/// <summary>
	/// Cache class which ensures that only one instance of an entity factory is created/stored during serialization
	/// </summary>
	public static class EntityFactoryCache2
	{
		#region Class Member Declarations
		[ThreadStatic]
		private static Dictionary<Type, IEntityFactory2> _factoryTypeLookup;
		#endregion

		/// <summary>
		/// Gets the entity factory for the specified entity from the cache 
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <returns></returns>
		public static IEntityFactory2 GetEntityFactory(EntityBase2 entity)
		{
			if(_factoryTypeLookup == null)
			{
				_factoryTypeLookup = new Dictionary<Type, IEntityFactory2>();
			}

			if(entity == null)
			{
				throw new ArgumentNullException("entity");
			}

			Type entityType = entity.GetType();
			IEntityFactory2 result;
			if (!_factoryTypeLookup.TryGetValue(entityType, out result))
			{
				result = entity.CallCreateEntityFactory();
				_factoryTypeLookup.Add(entityType, result);
				_factoryTypeLookup.Add(result.GetType(), result);
			}
			return result;
		}


		/// <summary>
		/// Gets the unique entity factory instance for the entity factory passed in to use for serialization.
		/// </summary>
		/// <param name="factory">The factory.</param>
		/// <returns></returns>
		public static IEntityFactory2 GetEntityFactory(IEntityFactory2 factory)
		{
			if(factory == null)
			{
				throw new ArgumentNullException("factory");
			}

			if(_factoryTypeLookup == null)
			{
				_factoryTypeLookup = new Dictionary<Type, IEntityFactory2>();
			}

			Type factoryType = factory.GetType();
			IEntityFactory2 result;
			if(!_factoryTypeLookup.TryGetValue(factoryType, out result))
			{
				result = factory;
				_factoryTypeLookup.Add(factoryType, result);
				Type entityType = factory.Create().GetType();
				_factoryTypeLookup.Add(entityType, result);
			}
			return result;
		}


		/// <summary>
		/// Gets the entity factory instance to use for the type passed in. 
		/// </summary>
		/// <param name="factoryType">Type of the factory.</param>
		/// <returns></returns>
		public static IEntityFactory2 GetEntityFactory(Type factoryType)
		{
			if(factoryType == null)
			{
				throw new ArgumentNullException("factory");
			}

			if(_factoryTypeLookup == null)
			{
				_factoryTypeLookup = new Dictionary<Type, IEntityFactory2>();
			}

			IEntityFactory2 result;
			if(!_factoryTypeLookup.TryGetValue(factoryType, out result))
			{
				result = (IEntityFactory2) Activator.CreateInstance(factoryType);
			}
			return result;
		}
	}
	
	
	/// <summary>
	/// Class to act as a surrogate for the fast serializer.
	/// </summary>
	public class FastSerializerSurrogate: ISerializationSurrogate 
	{
		/// <summary>
		/// Constructs a new instance of the same type as the object passed in, using the default constructor.
		/// </summary>
		/// <param name="obj">The obj.</param>
		private static void ConstructFromDefaultConstructor(object obj)
		{
			ConstructorInfo ctor = obj.GetType().GetConstructor(Type.EmptyTypes);
			ctor.Invoke(obj, null);
		}


		/// <summary>
		/// Populates the provided <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> with the data needed to serialize the object.
		/// </summary>
		/// <param name="obj">The object to serialize.</param>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> to populate with data.</param>
		/// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"></see>) for this serialization.</param>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			if (obj is IFastSerializableEntityCollection2)
			{
				SerializationHelper.Serialize(obj as IEntityCollection2, info, context);
			}
			else
			{
				if (obj is EntityBase2)
				{
					SerializationHelper.Serialize(obj as EntityBase2, info, context);
				}
				else 
				{
					if (obj is TypedListCore)
					{
						SerializationHelper.Serialize(obj as TypedListCore, info, context);
					}
					else
					{
						if (obj is ITypedView2)
						{
							SerializationHelper.Serialize(obj as ITypedView2, info, context);
						}
						else
						{
							if(obj is UnitOfWork2)
							{
								SerializationHelper.Serialize(obj as UnitOfWork2, info, context);
							}
							else
							{
								throw new NotSupportedException("Unrecognized root type");
							}
						}
					}
				}
			}
		}


		/// <summary>
		/// Populates the object using the information in the <see cref="T:System.Runtime.Serialization.SerializationInfo"></see>.
		/// </summary>
		/// <param name="obj">The object to populate.</param>
		/// <param name="info">The information to populate the object.</param>
		/// <param name="context">The source from which the object is deserialized.</param>
		/// <param name="selector">The surrogate selector where the search for a compatible surrogate begins.</param>
		/// <returns>The populated deserialized object.</returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			if (obj is IFastSerializableEntityCollection2)
			{
				SerializationHelper.Deserialize(obj as IEntityCollection2, info, context);
			}
			else
			{
				if(obj is EntityBase2)
				{
					SerializationHelper.Deserialize(obj as EntityBase2, info, context);
				}
				else
				{
					if(obj is TypedListCore)
					{
						ConstructFromDefaultConstructor(obj);
						SerializationHelper.Deserialize(obj as TypedListCore, info, context);
					}
					else
					{
						if(obj is ITypedView2)
						{
							ConstructFromDefaultConstructor(obj);
							SerializationHelper.Deserialize(obj as ITypedView2, info, context);
						}
						else
						{
							if(obj is UnitOfWork2)
							{
								SerializationHelper.Deserialize(obj as UnitOfWork2, info, context);
							}
							else
							{
								throw new NotSupportedException("Unrecognized root type");
							}
						}
					}
				}
			}

			return obj;
		}
	}


	/// <summary>
	/// Class to select the proper surrogate for the fast serializer
	/// </summary>
	public class FastSerializerSurrogateSelector: ISurrogateSelector
	{
		#region Class Member Declarations
		private ISurrogateSelector _nextSelector;
		#endregion

		/// <summary>
		/// Chains the selector.
		/// </summary>
		/// <param name="nextSelector">The next selector.</param>
		public void ChainSelector(ISurrogateSelector nextSelector)
		{
			_nextSelector = nextSelector;
		}


		/// <summary>
		/// Returns the next surrogate selector in the chain.
		/// </summary>
		/// <returns>
		/// The next surrogate selector in the chain or null.
		/// </returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
		public ISurrogateSelector GetNextSelector()
		{
			return _nextSelector;
		}


		/// <summary>
		/// Finds the surrogate that represents the specified object's type, starting with the specified surrogate selector for the specified serialization context.
		/// </summary>
		/// <param name="type">The <see cref="T:System.Type"></see> of object (class) that needs a surrogate.</param>
		/// <param name="context">The source or destination context for the current serialization.</param>
		/// <param name="selector">When this method returns, contains a <see cref="T:System.Runtime.Serialization.ISurrogateSelector"></see> that holds a reference to the surrogate selector where the appropriate surrogate was found. This parameter is passed uninitialized.</param>
		/// <returns>
		/// The appropriate surrogate for the given type in the given context.
		/// </returns>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission. </exception>
		public ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector selector)
		{
			ISerializationSurrogate result = null;
			selector = null;

			if(typeof(IEntityCollection2).IsAssignableFrom(type))
			{
				result = new FastSerializerSurrogate();
			}
			else
			{
				if(typeof(EntityBase2).IsAssignableFrom(type))
				{
					result = new FastSerializerSurrogate();
				}
				else
				{
					if(typeof(TypedListCore).IsAssignableFrom(type))
					{
						result = new FastSerializerSurrogate();
					}
					else
					{
						if(typeof(ITypedView2).IsAssignableFrom(type))
						{
							result = new FastSerializerSurrogate();
						}
					}
				}
			}

			if(result != null)
			{
				selector = this;
			}
			return result;
		}
	}


	/// <summary>
	/// Class which is used to store maps to referenced entities to be able to serialize an entity which is referenced multiple times only once.
	/// </summary>
	public class ReferencedEntityMap
	{
		#region Class Member Declarations
		private UniqueList<EntityBase2> _seenEntities = new UniqueList<EntityBase2>(new ReferencedEntityComparer());
		private UniqueList<EntityBase2> _referencedEntities = new UniqueList<EntityBase2>(new ReferencedEntityComparer());
		private Queue<EntityBase2> _unreferencedQueue = new Queue<EntityBase2>();
		private Queue<EntityBase2> _referencedQueue = new Queue<EntityBase2>();
		#endregion


		#region Private Classes
		/// <summary>
		/// Comparer used for checking entity equality based on references, not contents. This is necessary as entities override Equals. 
		/// </summary>
		private class ReferencedEntityComparer : IEqualityComparer<EntityBase2>
		{
			public bool Equals(EntityBase2 x, EntityBase2 y)
			{
				return x == y;
			}

			public int GetHashCode(EntityBase2 obj)
			{
				Guid objectID = obj.GetObjectIDInternal();
				if(objectID != Guid.Empty)
					return objectID.GetHashCode();
				else
				{
					return obj.GetHashCode();
				}
			}
		}
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="ReferencedEntityMap"/> class.
		/// </summary>
		public ReferencedEntityMap() 
		{

		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ReferencedEntityMap"/> class.
		/// </summary>
		/// <param name="root">The root.</param>
		public ReferencedEntityMap(object root)
		{
			Add(root);
		}


		/// <summary>
		/// Gets the referenced entities.
		/// </summary>
		/// <returns></returns>
		public UniqueList<EntityBase2> GetReferencedEntities()
		{
			return _referencedEntities;
		}

		/// <summary>
		/// Gets the entities seen
		/// </summary>
		/// <returns></returns>
		public UniqueList<EntityBase2> GetSeenEntities()
		{
			return _seenEntities;
		}


		/// <summary>
		/// Adds the specified root.
		/// </summary>
		/// <param name="root">The root.</param>
		public void Add(object root)
		{
			if(root is EntityBase2)
			{
				// Always ensure the root Entity is treated as referenced
				_referencedQueue.Enqueue(root as EntityBase2);
			}
			else
			{
				if(root is IEntityCollection2)
				{
					foreach(EntityBase2 entity in (root as IEntityCollection2))
					{
						_unreferencedQueue.Enqueue(entity);
					}
				}
				else
				{
					throw new InvalidOperationException("Unrecognized root object");
				}
			}
			ProcessQueues();
		}


		/// <summary>
		/// Processes the queues.
		/// </summary>
		private void ProcessQueues()
		{
			while((_unreferencedQueue.Count != 0) || (_referencedQueue.Count != 0))
			{
				while (_unreferencedQueue.Count != 0)
				{
					AddEntity(_unreferencedQueue.Dequeue());
				}
				while (_referencedQueue.Count != 0)
				{
					EntityBase2 entity = _referencedQueue.Dequeue();
					_referencedEntities.Add(entity);
					AddEntity(entity);
				}
			}
		}


		/// <summary>
		/// Adds the entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void AddEntity(EntityBase2 entity)
		{
			if (!_seenEntities.Add(entity))
			{
				return;
			}
			
			foreach (IEntityCollection2 collection in entity.GetMemberEntityCollectionsInternal())
			{
				if (collection != null && collection.Count != 0)
				{
					foreach(EntityBase2 memberEntity in collection)
					{
						if(_seenEntities.Contains(memberEntity))
						{
							_referencedQueue.Enqueue(memberEntity);
						}
						else
						{
							_unreferencedQueue.Enqueue(memberEntity);
						}
					}
				}
			}

			foreach (EntityBase2 relatedEntity in entity.GetDependingRelatedEntities())
			{
				_referencedQueue.Enqueue(relatedEntity);
			}

			FastDictionary<Guid, FastDictionary<string, EntitySyncInfo<IEntity2>>> relatedEntitySyncInfos = entity.RelatedEntitySyncInfosInternal;
			if (relatedEntitySyncInfos != null)
			{
				foreach (FastDictionary<string, EntitySyncInfo<IEntity2>> mapping in relatedEntitySyncInfos.Values)
				{
					foreach (EntitySyncInfo<IEntity2> entitySyncInfo in mapping.Values)
					{
						EntityBase2 relatedEntity = (EntityBase2) entitySyncInfo.DataSupplyingEntity;
						_referencedQueue.Enqueue(relatedEntity);
					}
				}
			}

		}

		#region Class Property Declarations
		/// <summary>
		/// Gets the # of referenced entities
		/// </summary>
		public int ReferencedCount
		{
			get { return _referencedEntities.Count; }
		}


		/// <summary>
		/// Gets the seen entity count.
		/// </summary>
		public int SeenEntityCount
		{
			get { return _seenEntities.Count; }
		}


		/// <summary>
		/// Gets the # of referenced entities which have already an ObjectID set
		/// </summary>
		public int ReferencedWithGuidCount
		{
			get
			{
				int result = 0;
				foreach(EntityBase2 entity in _referencedEntities)
				{
					if(entity == null)
					{
						continue;
					}
					if(entity.GetObjectIDInternal() != Guid.Empty)
					{
						result++;
					}
				}
				return result;
			}
		}


		/// <summary>
		/// Gets the # of referenced entities which don't have an ObjectID set yet
		/// </summary>
		public int ReferencedWithoutGuidCount
		{
			get
			{
				int result = 0;
				foreach(EntityBase2 entity in _referencedEntities)
				{
					if(entity == null)
					{
						continue;
					}
					if(entity.GetObjectIDInternal() == Guid.Empty)
					{
						result++;
					}
				}
				return result;
			}
		}


		/// <summary>
		/// Gets the # of seen entities which have already an ObjectID set
		/// </summary>
		public int SeenWithGuidCount
		{
			get
			{
				int result = 0;
				foreach(EntityBase2 entity in _seenEntities)
				{
					if(entity == null)
					{
						continue;
					}
					if(entity.GetObjectIDInternal() != Guid.Empty)
					{
						result++;
					}
				}
				return result;
			}
		}


		/// <summary>
		/// Gets the # of seen entities which have already an ObjectID set
		/// </summary>
		public int SeenWithoutGuidCount
		{
			get
			{
				int result = 0;
				foreach(EntityBase2 entity in _seenEntities)
				{
					if(entity == null)
					{
						continue;
					}
					if(entity.GetObjectIDInternal() == Guid.Empty)
					{
						result++;
					}
				}
				return result;
			}
		}
		#endregion
	}
}
