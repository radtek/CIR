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
	/// The serializer class which takes care of the fast serialization when SerializationHelper.Optimization is set to 'Fast'
	/// </summary>
	public class FastSerializer
	{
		#region Class Member Declarations
		private SerializationWriter _writer;
		private UniqueEntityBase2List _referencedEntitiesLookup;
		#endregion

		/// <summary>
		/// Serializes the specified root.
		/// </summary>
		/// <param name="root">The root.</param>
		/// <returns>the writer used.</returns>
		public SerializationWriter Serialize(object root)
		{
			_writer = new SerializationWriter();

			if(root is IFastSerializableEntityCollection2)
			{
				Serialize(root as IFastSerializableEntityCollection2);
			}
			else
			{
				if(root is EntityBase2)
				{
					Serialize(root as EntityBase2);
				}
				else
				{
					if(root is TypedListCore)
					{
						Serialize(root as TypedListCore);
					}
					else
					{
						if(root is TypedViewBase)
						{
							Serialize(root as TypedViewBase);
						}
						else
						{
							if(root is UnitOfWork2)
							{
								Serialize(root as UnitOfWork2);
							}
							else
							{
								throw new NotSupportedException("Unrecognized root type");
							}
						}
					}
				}
			}
			return _writer;
		}


		/// <summary>
		/// Serializes the specified unit of work.
		/// </summary>
		/// <param name="unitOfWork">The unit of work.</param>
		private void Serialize(UnitOfWork2 unitOfWork)
		{
			BitVector32 flags = unitOfWork.GetSerializationFlags();
			_writer.WriteOptimized(flags);

			if((flags.Data & SerializationHelper.UnitOfWorkHasEntitiesToSaveMask) != 0)
			{
				WriteUnitOfWorkElements(unitOfWork.EntitiesToSave);
			}
			if((flags.Data & SerializationHelper.UnitOfWorkHasEntitiesToDeleteMask) != 0)
			{
				WriteUnitOfWorkElements(unitOfWork.EntitiesToDelete);
			}
			if((flags.Data & SerializationHelper.UnitOfWorkHasCollectionsToDeleteMask) != 0)
			{
				WriteUnitOfWorkCollectionElements(unitOfWork.CollectionsToDelete);
			}
			if((flags.Data & SerializationHelper.UnitOfWorkHasCollectionsToSaveMask) != 0)
			{
				WriteUnitOfWorkCollectionElements(unitOfWork.CollectionsToSave);
			}
		}


		/// <summary>
		/// Serializes the specified collection.
		/// </summary>
		/// <param name="collection">The collection.</param>
		private void Serialize(IFastSerializableEntityCollection2 collection)
		{
			// Get the flags for this collection and save them first
			BitVector32 serializationFlags = collection.GetSerializationFlags(true, true);
			_writer.WriteOptimized(serializationFlags);

			// Ensure that all referenced entities are processed first
			if((serializationFlags.Data & SerializationHelper.CollectionCombinedRelationsMask) != 0)
			{
				WriteReferencedEntities(collection);
			}

			WriteCollection(collection, serializationFlags);
		}


		/// <summary>
		/// Writes the collection to the writer. 
		/// </summary>
		/// <param name="collection">The collection.</param>
		/// <param name="serializationFlags">The serialization flags.</param>
		private void WriteCollection(IFastSerializableEntityCollection2 collection, BitVector32 serializationFlags)
		{
			collection.SerializeOwnedData(_writer, serializationFlags);

			// Save contained entities directly into this SerializerWriter
			if(serializationFlags[SerializationHelper.CollectionHasEntitiesMask])
			{
				bool entityTypesAreCommon = serializationFlags[SerializationHelper.CollectionHasCommonEntityTypesMask];

				int count = collection.Count;
				_writer.WriteOptimized(count);

				// Check whether entities are All/Partially/None referenced
				BitArray referencedEntityMap = null;
				if(_referencedEntitiesLookup != null)
				{
					int notReferenced = 0;
					for(int i = 0; i < collection.Count; i++)
					{
						if(!_referencedEntitiesLookup.Contains((EntityBase2)collection[i]))
						{
							notReferenced++;
						}
						else
						{
							if(referencedEntityMap == null)
							{
								referencedEntityMap = new BitArray(collection.Count);
							}
							referencedEntityMap[i] = true;
						}
					}
					if(notReferenced == 0) referencedEntityMap = SerializationHelper.FullyReferencedEntityCollection;
				}

				_writer.Write(referencedEntityMap);

				// If the entities are of a common type but not that of this collection's entity factory
				// save just one instance of the entity factory
				if(entityTypesAreCommon &&
					!serializationFlags[SerializationHelper.CollectionIsCommonEntityFactoryCollectionEntityFactoryMask] &&
						(referencedEntityMap != SerializationHelper.FullyReferencedEntityCollection)
					)
				{
					_writer.WriteTokenizedObject(EntityFactoryCache2.GetEntityFactory((EntityBase2)collection[0]), true);
				}

				for(int i = 0; i < count; i++)
				{
					EntityBase2 entity = (EntityBase2)collection[i];
					if(referencedEntityMap == null || (referencedEntityMap != SerializationHelper.FullyReferencedEntityCollection && !referencedEntityMap[i]))
					{
						if(!entityTypesAreCommon)
						{
							_writer.WriteTokenizedObject(EntityFactoryCache2.GetEntityFactory(entity), true);
						}
						WriteUnreferencedEntity(entity);
					}
					else
					{
						_writer.WriteOptimized(_referencedEntitiesLookup.IndexOf(entity));
					}
				}
			}
		}


		/// <summary>
		/// Serializes the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void Serialize(EntityBase2 entity)
		{
			// Get the flags for this entity and save them first
			BitVector32 serializationFlags = entity.GetSerializationFlags();
			_writer.WriteOptimized(serializationFlags);

			if((serializationFlags.Data & SerializationHelper.CombinedEntityRelationsMask) != 0)
			{
				WriteReferencedEntities(entity);
				System.Diagnostics.Debug.Assert(_referencedEntitiesLookup.IndexOf(entity) == 0);
			}
			else
			{
				WriteUnreferencedEntity(entity, serializationFlags);
			}
		}


		/// <summary>
		/// Serializes the specified typed list.
		/// </summary>
		/// <param name="typedList">The typed list.</param>
		private void Serialize(TypedListCore typedList)
		{
			BitVector32 serializationFlags = typedList.GetSerializationFlags();
			_writer.WriteOptimized(serializationFlags);
			typedList.SerializeOwnedData(_writer, serializationFlags);
		}


		/// <summary>
		/// Serializes the specified typed view.
		/// </summary>
		/// <param name="typedView">The typed view.</param>
		private void Serialize(TypedViewBase typedView)
		{
			typedView.SerializeOwnedData(_writer, null);
		}


		/// <summary>
		/// Writes the unreferenced entity to the writer.
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void WriteUnreferencedEntity(EntityBase2 entity)
		{
			// Get the flags for this entity and save them first
			BitVector32 serializationFlags = entity.GetSerializationFlags();
			_writer.WriteOptimized(serializationFlags);
			WriteUnreferencedEntity(entity, serializationFlags);
		}


		/// <summary>
		/// Writes the unreferenced entity to the writer. 
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="serializationFlags">The serialization flags.</param>
		private void WriteUnreferencedEntity(EntityBase2 entity, BitVector32 serializationFlags)
		{
			// Save information directly owned by this entity
			entity.SerializeOwnedData(_writer, serializationFlags);

			// Save any member collections (which will then recursively save their
			// entities and member collections etc.
			if(serializationFlags[SerializationHelper.EntityHasPopulatedMemberEntityCollections])
			{
				WriteEntityMemberCollections(entity);
			}

			if(serializationFlags[SerializationHelper.EntityHasDependingRelatedEntities])
			{
				WriteReferencedEntityInfo(entity);
			}
			
			if(serializationFlags[SerializationHelper.EntityHasOneWayRelations])
			{
				WriteOneWayRelationInfo(entity);
			}
		}


		/// <summary>
		/// Writes the referenced entities to the writer
		/// </summary>
		/// <param name="root">The root.</param>
		private void WriteReferencedEntities(object root)
		{
			ReferencedEntityMap referencedEntityMap = new ReferencedEntityMap(root);
			_referencedEntitiesLookup = referencedEntityMap.GetReferencedEntities();

			int count = _referencedEntitiesLookup.Count;
			_writer.WriteOptimized(count);

			bool[] hasDependingRelatedEntities = new bool[count];
			bool[] hasPopulatedMemberCollectionsList = new bool[count];
			bool[] hasOneWayRelations = new bool[count];

			// Go through each referenced entity in the list
			for(int i = 0; i < count; i++)
			{
				EntityBase2 entity = _referencedEntitiesLookup[i];

				// FUTURE ENHANCEMENT: Optimize this so only where necessary
				_writer.WriteTokenizedObject(EntityFactoryCache2.GetEntityFactory(entity), true);

				// Serialize flags and owned data
				BitVector32 flags = entity.GetSerializationFlags();
				_writer.WriteOptimized(flags);
				entity.SerializeOwnedData(_writer, flags);

				// Make a note of whether this entity references other entities
				hasDependingRelatedEntities[i] = flags[SerializationHelper.EntityHasDependingRelatedEntities];
				hasPopulatedMemberCollectionsList[i] = flags[SerializationHelper.EntityHasPopulatedMemberEntityCollections];
				hasOneWayRelations[i] = flags[SerializationHelper.EntityHasOneWayRelations];
			}

			// Save the references to other entities seperately
			for(int i = 0; i < count; i++)
			{
				if(hasPopulatedMemberCollectionsList[i])
				{
					WriteEntityMemberCollections(_referencedEntitiesLookup[i]);
				}
				if(hasDependingRelatedEntities[i])
				{
					WriteReferencedEntityInfo(_referencedEntitiesLookup[i]);
				}
				if(hasOneWayRelations[i])
				{
					WriteOneWayRelationInfo(_referencedEntitiesLookup[i]);
				}
			}
		}


		/// <summary>
		/// Writes the unit of work collection elements.
		/// </summary>
		/// <param name="elements">The elements.</param>
		private void WriteUnitOfWorkCollectionElements(ArrayList elements)
		{
			ArrayList collections = new ArrayList(elements.Count);
			BitArray refetchFlags = new BitArray(elements.Count);
			BitArray recurseFlags = new BitArray(elements.Count);

			for(int i = 0; i < elements.Count; i++)
			{
				collections.Add( ((UnitOfWorkCollectionElement2)elements[i]).Collection);
				refetchFlags[i] = ((UnitOfWorkCollectionElement2)elements[i]).Refetch;
				recurseFlags[i] = ((UnitOfWorkCollectionElement2)elements[i]).Recurse;
			}

			// first write the count so we can read it all back properly
			_writer.WriteOptimized(elements.Count);
			// write all collections one by one. 
			foreach(IEntityCollection2 collection in collections)
			{
				// FUTURE ENHANCEMENT: it might be there are dupes in these collections (entity X is in more than 1 collection). A reference map should be created from 
				// the complete set of collections instead of from one at a time. 
				Serialize((IFastSerializableEntityCollection2)collection);
			}
			// write the flags
			_writer.Write(refetchFlags);
			_writer.Write(recurseFlags);
		}


		/// <summary>
		/// Writes the unit of work elements.
		/// </summary>
		/// <param name="elements">The elements.</param>
		private void WriteUnitOfWorkElements(ArrayList elements)
		{
			// split the list into 4 different lists which are serialized separately. 
			EntityCollectionForFetch entities = new EntityCollectionForFetch(null);
			BitArray refetchFlags = new BitArray(elements.Count);
			BitArray recurseFlags = new BitArray(elements.Count);
			IPredicateExpression[] filters = new IPredicateExpression[elements.Count];

			for(int i = 0; i < elements.Count; i++)
			{
				entities.Add((EntityBase2)((UnitOfWorkElement2)elements[i]).Entity);
				refetchFlags[i] = ((UnitOfWorkElement2)elements[i]).Refetch;
				recurseFlags[i] = ((UnitOfWorkElement2)elements[i]).Recurse;
				filters[i] = ((UnitOfWorkElement2)elements[i]).Restriction;
			}

			Serialize(entities);
			_writer.Write(refetchFlags);
			_writer.Write(recurseFlags);
			_writer.Write(filters);
		}


		/// <summary>
		/// Writes the entity member collections to the writer
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void WriteEntityMemberCollections(EntityBase2 entity)
		{
			object[] memberEntityCollections = entity.GetMemberEntityCollectionsInternal().ToArray();
			BitArray populatationFlags = new BitArray(memberEntityCollections.Length);
			for(int i = 0; i < memberEntityCollections.Length; i++)
			{
				populatationFlags[i] = (IEntityCollection2)memberEntityCollections[i] != null;
			}
			_writer.WriteOptimized(populatationFlags);

			for(int i = 0; i < memberEntityCollections.Length; i++)
			{
				if(populatationFlags[i])
				{
					IFastSerializableEntityCollection2 memberEntityCollection = (IFastSerializableEntityCollection2)memberEntityCollections[i];
					BitVector32 memberCollectionFlags = memberEntityCollection.GetSerializationFlags(true, false);
					_writer.WriteOptimized(memberCollectionFlags);
					_writer.WriteOptimized(memberEntityCollection.ContainingEntityMappedFieldInternal);
					WriteCollection(memberEntityCollection, memberCollectionFlags);
				}
			}
		}


		/// <summary>
		/// Writes the referenced entity info to the writer
		/// </summary>
		/// <param name="entity">The entity.</param>
		private void WriteReferencedEntityInfo(EntityBase2 entity)
		{
			IEntityCollection2 dependingEntities = entity.GetDependingRelatedEntities();

			foreach(EntityBase2 dependingEntity in dependingEntities)
			{
				Hashtable relatedEntitySyncInfos = dependingEntity.RelatedEntitySyncInfosInternal;
				if (relatedEntitySyncInfos != null)
				{
					foreach(string propertyName in ((Hashtable)relatedEntitySyncInfos[entity.ObjectID]).Keys)
					{
						_writer.WriteOptimized(propertyName);
						_writer.WriteOptimized(_referencedEntitiesLookup.IndexOf(dependingEntity));
					}
				}
			}
			_writer.WriteOptimized((string) null);
		}

		/// <summary>
		/// Writes the one way relation info.
		/// </summary>
		/// <param name="entity">Entity.</param>
		private void WriteOneWayRelationInfo(EntityBase2 entity)
		{
			foreach(DictionaryEntry pair in entity.GetRelatedData())
			{
				if(pair.Value is IEntity2 && entity.CheckOneWayRelations((string)pair.Key))
				{
					// Write the property name and entity reference
					_writer.WriteOptimized((string)pair.Key);
					_writer.WriteOptimized(_referencedEntitiesLookup.IndexOf((EntityBase2)pair.Value));
				}
			}

			// Write a null property name as an end-of-list-indicator
			_writer.WriteOptimized((string) null);
		}
	}
}
