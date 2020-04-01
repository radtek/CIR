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
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// The de-serializer class which takes care of the fast deserialization of data serialized with the FastSerializer class when 
	/// SerializationHelper.Optimization is set to 'Fast'
	/// </summary>
	public class FastDeserializer
	{
		#region Class Member Declarations
		private SerializationReader _reader;
		private EntityBase2[] _referencedEntityList;
		#endregion

		/// <summary>
		/// Deserializes the specified serialized data.
		/// </summary>
		/// <param name="serializedData">The serialized data.</param>
		/// <param name="root">The root.</param>
		public void Deserialize(byte[] serializedData, object root)
		{
			_reader = new SerializationReader(serializedData);

			if(root is IFastSerializableEntityCollection2)
			{
				Deserialize(root as IFastSerializableEntityCollection2);
			}
			else
			{
				if(root is EntityBase2)
				{
					Deserialize(root as EntityBase2);
				}
				else
				{
					if(root is TypedListCore)
					{
						Deserialize(root as TypedListCore);
					}
					else
					{
						if(root is TypedViewBase)
						{
							Deserialize(root as TypedViewBase);
						}
						else
						{
							if(root is UnitOfWork2)
							{
								Deserialize(root as UnitOfWork2);
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
		/// Deserializes the specified unit of work.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		private void Deserialize(UnitOfWork2 unitOfWork)
		{
			// class is already inited by deserialization CTor. We now read the data back and re-build the UnitOfWork by adding the data again. 
			// this saves us serializing GUIDs and also saves us duplicating rebuild routines of the ObjectID stores inside a UoW.
			BitVector32 flags = _reader.ReadOptimizedBitVector32();

			if((flags.Data & SerializationHelper.UnitOfWorkHasEntitiesToSaveMask) != 0)
			{
				ReadUnitOfWorkElements(unitOfWork, true);
			}
			if((flags.Data & SerializationHelper.UnitOfWorkHasEntitiesToDeleteMask) != 0)
			{
				ReadUnitOfWorkElements(unitOfWork, false);
			}
			if((flags.Data & SerializationHelper.UnitOfWorkHasCollectionsToDeleteMask) != 0)
			{
				ReadUnitOfWorkCollectionElements(unitOfWork, false);
			}
			if((flags.Data & SerializationHelper.UnitOfWorkHasCollectionsToSaveMask) != 0)
			{
				ReadUnitOfWorkCollectionElements(unitOfWork, true);
			}
		}


		/// <summary>
		/// Deserializes the specified collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		private void Deserialize(IFastSerializableEntityCollection2 collection)
		{
			collection.InitClassInternal();

			BitVector32 serializationFlags = _reader.ReadOptimizedBitVector32();

			if((serializationFlags.Data & SerializationHelper.CollectionCombinedRelationsMask) != 0)
			{
				ReadReferencedEntities(null);
			}

			ReadCollection(collection, serializationFlags);
		}


		/// <summary>
		/// Deserializes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void Deserialize(EntityBase2 entity)
		{
			BitVector32 serializationFlags = _reader.ReadOptimizedBitVector32();

			if((serializationFlags.Data & SerializationHelper.CombinedEntityRelationsMask) != 0)
			{
				ReadReferencedEntities(entity);
			}
			else
			{
				ReadUnreferencedEntity(entity, serializationFlags);
			}
		}


		/// <summary>
		/// Deserializes the specified typed list.
		/// </summary>
		/// <param name="typedList">The typed list.</param>
		private void Deserialize(TypedListCore typedList)
		{
			BitVector32 serializationFlags = _reader.ReadOptimizedBitVector32();
			typedList.DeserializeOwnedData(_reader, serializationFlags);
		}


		/// <summary>
		/// Deserializes the specified typed view.
		/// </summary>
		/// <param name="typedView">The typed view.</param>
		private void Deserialize(TypedViewBase typedView)
		{
			typedView.DeserializeOwnedData(_reader, null);
		}


		/// <summary>
		/// Reads the collection from the set reader
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="serializationFlags">The serialization flags.</param>
		private void ReadCollection(IFastSerializableEntityCollection2 collection, BitVector32 serializationFlags)
		{
			collection.DeserializeOwnedData(_reader, serializationFlags);

			if(serializationFlags[SerializationHelper.CollectionHasEntitiesMask])
			{
				bool entityTypesAreCommon = serializationFlags[SerializationHelper.CollectionHasCommonEntityTypesMask];

				int count = _reader.ReadOptimizedInt32();
				IEntityFactory2 entityFactory;

				BitArray referencedEntityMap = _reader.ReadBitArray();
				if(referencedEntityMap != null && referencedEntityMap.Length == 0)
					referencedEntityMap = SerializationHelper.FullyReferencedEntityCollection;

				// Select an entity factory
				if(!entityTypesAreCommon || referencedEntityMap == SerializationHelper.FullyReferencedEntityCollection)
				{
					entityFactory = null;
				}
				else
				{
					if(serializationFlags[SerializationHelper.CollectionIsCommonEntityFactoryCollectionEntityFactoryMask])
					{
						entityFactory = collection.EntityFactoryToUse;
					}
					else
					{
						entityFactory = (IEntityFactory2)_reader.ReadTokenizedObject();
					}
				}

				bool wasReadOnly = collection.IsReadOnly;
				collection.IsReadOnly = false;
				IConcurrencyPredicateFactory wasConcurrencyPredicateFactoryToUse = collection.ConcurrencyPredicateFactoryToUse;
				collection.ConcurrencyPredicateFactoryToUse = null;
				for(int i = 0; i < count; i++)
				{
					EntityBase2 entity;

					if(referencedEntityMap == null || ((referencedEntityMap != SerializationHelper.FullyReferencedEntityCollection) && !referencedEntityMap[i]))
					{
						if(entityFactory == null)
						{
							entity = (EntityBase2)(_reader.ReadTokenizedObject() as IEntityFactory2).Create();
						}
						else
						{
							entity = (EntityBase2)entityFactory.Create();
						}
						ReadUnreferencedEntity(entity);
					}
					else
					{
						entity = _referencedEntityList[_reader.ReadOptimizedInt32()];
					}
					entity.IsDeserializing = true;
					collection.Add(entity);
					entity.IsDeserializing = false;
				}
				collection.IsReadOnly = wasReadOnly;
				collection.ConcurrencyPredicateFactoryToUse = wasConcurrencyPredicateFactoryToUse;
			}
		}


		/// <summary>
		/// Reads the unreferenced entity from the set reader.
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void ReadUnreferencedEntity(EntityBase2 entity)
		{
			BitVector32 serializationFlags = _reader.ReadOptimizedBitVector32();
			ReadUnreferencedEntity(entity, serializationFlags);
		}


		/// <summary>
		/// Reads the unreferenced entity from the set reader.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="serializationFlags">The serialization flags.</param>
		private void ReadUnreferencedEntity(EntityBase2 entity, BitVector32 serializationFlags)
		{
			// Save information directly owned by this entity
			entity.DeserializeOwnedData(_reader, serializationFlags);

			// Save any member collections (which will then recursively save their
			// entities and member collections etc.
			if(serializationFlags[SerializationHelper.EntityHasPopulatedMemberEntityCollections])
			{
				ReadEntityMemberCollections(entity);
			}
			if(serializationFlags[SerializationHelper.EntityHasDependingRelatedEntities])
			{
				ReadReferencedEntityInfo(entity);
			}
			if(serializationFlags[SerializationHelper.EntityHasOneWayRelations])
			{
				ReadOneWayRelationInfo(entity);
			}
		}


		/// <summary>
		/// Reads the entity member collections from the set reader.
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void ReadEntityMemberCollections(EntityBase2 entity)
		{
			BitArray populationFlags = _reader.ReadOptimizedBitArray();
			ArrayList list = new ArrayList(entity.GetCreatedMemberEntityCollectionsInternal(populationFlags));

			for(int i = 0; i < populationFlags.Count; i++)
			{
				if(list[i] != null)
				{
					BitVector32 memberCollectionFlags = _reader.ReadOptimizedBitVector32();
					((IEntityCollection2)list[i]).SetContainingEntityInfo(entity, _reader.ReadOptimizedString());
					ReadCollection((IFastSerializableEntityCollection2)list[i], memberCollectionFlags);
				}
			}
			entity.GetFromMemberEntityCollectionsQueue(new Queue(list));
		}


		/// <summary>
		/// Reads the unit of work elements and will rebuild the unitofwork passed in with the data read
		/// </summary>
		/// <param name="uow">The uow to rebuild.</param>
		/// <param name="forSave">true if the elements to read are save elements, false for delete elements</param>
		private void ReadUnitOfWorkElements(UnitOfWork2 uow, bool forSave)
		{
			// 4 blocks of data are in the stream
			EntityCollectionForFetch entities = new EntityCollectionForFetch(null);
			Deserialize(entities);
			BitArray refetchFlags = _reader.ReadBitArray();
			BitArray recurseFlags = _reader.ReadBitArray();
			object[] filters = _reader.ReadObjectArray();

			for(int i = 0; i < entities.Count; i++)
			{
				// rebuild uow with data read.
				if(forSave)
				{
					uow.AddForSave(entities[i], (IPredicateExpression)filters[i], refetchFlags[i], recurseFlags[i]);
				}
				else
				{
					uow.AddForDelete(entities[i], (IPredicateExpression)filters[i], true);
				}
			}
		}


		/// <summary>
		/// Reads the unit of work collection elements and will rebuild the unitofwork passed in with the data read
		/// </summary>
		/// <param name="uow">The uow to rebuild.</param>
		/// <param name="forSave">true if the elements to read are save elements, false for delete elements</param>
		private void ReadUnitOfWorkCollectionElements(UnitOfWork2 uow, bool forSave)
		{
			// first all the collections are stored, then the 2 fetch collections. 
			int amount = _reader.ReadOptimizedInt32();
			ArrayList collections = new ArrayList(amount);
			for(int i = 0; i < amount; i++)
			{
				// create an untyped collection, this is enough for the UoW to work with. 
				EntityCollectionForFetch toAdd = new EntityCollectionForFetch(null);
				Deserialize(toAdd);
				collections.Add(toAdd);
			}
			BitArray refetchFlags = _reader.ReadBitArray();
			BitArray recurseFlags = _reader.ReadBitArray();

			for(int i = 0; i < amount; i++)
			{
				if(forSave)
				{
					uow.AddCollectionForSave((IEntityCollection2)collections[i], refetchFlags[i], recurseFlags[i]);
				}
				else
				{
					uow.AddCollectionForDelete((IEntityCollection2)collections[i]);
				}
			}
		}


		/// <summary>
		/// Reads the referenced entities from the set reader.
		/// </summary>
		/// <param name="rootEntity">The root entity.</param>
		private void ReadReferencedEntities(EntityBase2 rootEntity)
		{
			int count = _reader.ReadOptimizedInt32();
			_referencedEntityList = new EntityBase2[count];
			bool[] referencesOtherEntitiesList = new bool[count];
			bool[] hasPopulatedMemberCollectionsList = new bool[count];
			bool[] hasOneWayRelations = new bool[count];

			// Read in the referenced entities
			for(int i = 0; i < count; i++)
			{
				EntityBase2 entity;
				if(rootEntity != null)
				{
					entity = rootEntity;
					rootEntity = null;
					_reader.ReadTokenizedObject();
				}
				else
				{
					// FUTURE ENHANCEMENT: Optimize this so only where necessary
					entity = (EntityBase2)(_reader.ReadTokenizedObject() as IEntityFactory2).Create();
				}
				BitVector32 flags = _reader.ReadOptimizedBitVector32();
				entity.DeserializeOwnedData(_reader, flags);
				_referencedEntityList[i] = entity;
				referencesOtherEntitiesList[i] = flags[SerializationHelper.EntityHasDependingRelatedEntities];
				hasPopulatedMemberCollectionsList[i] = flags[SerializationHelper.EntityHasPopulatedMemberEntityCollections];
				hasOneWayRelations[i] = flags[SerializationHelper.EntityHasOneWayRelations];
			}

			// Now fix up any which have references to other entities
			for(int i = 0; i < count; i++)
			{
				if(hasPopulatedMemberCollectionsList[i])
				{
					ReadEntityMemberCollections(_referencedEntityList[i]);
				}
				if(referencesOtherEntitiesList[i])
				{
					ReadReferencedEntityInfo((EntityBase2)_referencedEntityList[i]);
				}
				if(hasOneWayRelations[i])
				{
					ReadOneWayRelationInfo(_referencedEntityList[i]);
				}
			}
		}


		/// <summary>
		/// Reads the referenced entity info from the set reader.
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void ReadReferencedEntityInfo(EntityBase2 entity)
		{
			entity.IsDeserializing = true;

			// Read the property name (should always be at least one)
			string propertyName = _reader.ReadOptimizedString();

			// Keep going until we find a null property name
			while(propertyName != null)
			{
				// Lookup the entity and assign it to the propertyName
				_referencedEntityList[_reader.ReadOptimizedInt32()].SetRelatedEntityProperty(propertyName, entity);

				// Read the next property name or an end-of-list-indicator null
				propertyName = _reader.ReadOptimizedString();

			}

			entity.IsDeserializing = false;
		}


		/// <summary>
		/// Reads the one way relation info.
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void ReadOneWayRelationInfo(EntityBase2 entity)
		{
			entity.IsDeserializing = true;

			// Read the property name (should always be at least one)
			string propertyName = _reader.ReadOptimizedString();

			// Keep going until we find a null property name
			while(propertyName != null)
			{
				// Lookup the entity and assign it to the propertyName
				entity.SetRelatedEntityProperty(propertyName, _referencedEntityList[_reader.ReadOptimizedInt32()]);

				// Read the next property name or an end-of-list-indicator null
				propertyName = _reader.ReadOptimizedString();
			}

			entity.IsDeserializing = false;
		}
	}
}
