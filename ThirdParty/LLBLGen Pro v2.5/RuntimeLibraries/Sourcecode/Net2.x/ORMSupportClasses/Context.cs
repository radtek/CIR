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
//		- Frans Bouma [FB]
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// General Context class which provides uniquing support for the object fetcher. A developer
	/// can use this class to create a space for objects where every entity is loaded just once.
	/// </summary>
	public class Context
	{
		#region Class Member Declarations
		private Dictionary<Guid, IEntityCore>	_objectIDToEntityInstance;
		private Dictionary<Type, Dictionary<int, Dictionary<Guid, IEntityCore>>>		_entityTypeHashtables;	// hashtables with per entity hash value the objectid
		private Dictionary<Guid, IEntityCore>	_newEntities;
		private bool			_setExistingEntityFieldsInGet;
		#endregion


		/// <summary>
		/// Creates a new <see cref="Context"/> instance.
		/// </summary>
		public Context()
		{
			InitClass(true);
		}


		/// <summary>
		/// Creates a new <see cref="Context"/> instance.
		/// </summary>
		/// <param name="setExistingEntityFieldsInGet">Flag to set existing entity fields in get. Default is true. When set to false, an existing
		/// entity's fields is not set to the fields of the passed in entity. Fields are only set if the entity isn't dirty.</param>
		public Context(bool setExistingEntityFieldsInGet)
		{
			InitClass(setExistingEntityFieldsInGet);
		}


		/// <summary>
		/// Clears this context. It removes all cached entity references from this context and also all type definitions. 
		/// </summary>
		public void Clear()
		{
			List<Type> typesToRemove = new List<Type>( _entityTypeHashtables.Keys );
			foreach( Type typeToRemove in typesToRemove )
			{
				Dictionary<int, Dictionary<Guid, IEntityCore>> typeCache = null;
				if( !_entityTypeHashtables.TryGetValue( typeToRemove, out typeCache ) )
				{
					// type not found
					continue;
				}

				List<Dictionary<Guid, IEntityCore>> entityInfos = new List<Dictionary<Guid, IEntityCore>>( typeCache.Values );
				List<Guid> entitiesToRemove = new List<Guid>();
				foreach( Dictionary<Guid, IEntityCore> guidEntity in entityInfos )
				{
					entitiesToRemove.AddRange( guidEntity.Keys );
				}

				foreach( Guid toRemove in entitiesToRemove )
				{
					IEntityCore entityToRemove = null;
					if( _objectIDToEntityInstance.TryGetValue( toRemove, out entityToRemove ) )
					{
						_objectIDToEntityInstance.Remove( toRemove );
						entityToRemove.ActiveContext = null;
					}
				}

				_entityTypeHashtables.Remove( typeToRemove );
			}
			foreach(IEntityCore newEntity in _newEntities.Values)
			{
				newEntity.ActiveContext = null;
			}
			_newEntities.Clear();
			_entityTypeHashtables.Clear();
			_objectIDToEntityInstance.Clear();
		}


		/// <summary>
		/// Adds the specified entity to the Context. If the passed in entity is already in a context, the Add is a no-op.
		/// Also if the entity isn't new and there is already an entity with the same PK values, the Add is a no-op.
		/// </summary>
		/// <param name="toAdd">entity to add to this context.</param>
		public void Add( IEntity toAdd )
		{
			this.Add<IEntity>( toAdd );
		}

		/// <summary>
		/// Adds the specified entity to the Context. If the passed in entity is already in a context, the Add is a no-op.
		/// Also if the entity isn't new and there is already an entity with the same PK values, the Add is a no-op.
		/// </summary>
		/// <param name="toAdd">entity to add to this context.</param>
		public void Add( IEntity2 toAdd )
		{
			this.Add<IEntity2>( toAdd );
		}


		/// <summary>
		/// Adds the specified collection to this context. All contained entities are added to the context as well, if they're not already in the / a context.
		/// This will make sure that any entity added to the entity collection will be added to this context as well. 
		/// </summary>
		/// <param name="toAdd">To add.</param>
		/// <remarks>SelfServicing specific version</remarks>
		public void Add(IEntityCollection toAdd)
		{
			toAdd.ActiveContext = this;	// will add all contained entities.
		}


		/// <summary>
		/// Adds the specified collection to this context. All contained entities are added to the context as well, if they're not already in the / a context.
		/// This will make sure that any entity added to the entity collection will be added to this context as well. 
		/// </summary>
		/// <param name="toAdd">To add.</param>
		/// <remarks>Adapter specific version</remarks>
		public void Add(IEntityCollection2 toAdd)
		{
			toAdd.ActiveContext = this;	// will add all contained entities.
		}


		/// <summary>
		/// After an entity has been saved and the transaction has been committed (or if no transaction was used: the entity was saved), this routine is called
		/// to move entities which are in the list of new entities and which are now saved to the store. 
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <remarks>Routine for the framework, you don't have to call this routine yourself</remarks>
		public void EntitySaveCommitted<TEntity>(TEntity entity)
			where TEntity : class, IEntityCore
		{
			if(_newEntities.ContainsKey(entity.ObjectID))
			{
				// was new -> add
				Add(entity);
				_newEntities.Remove(entity.ObjectID);
			}
		}


		/// <summary>
		/// Returns a readonly arraylist with all the objects of the type passed in which are currently stored in the internal object cache.
		/// No new entities are returned. If the type is not found, an empty array list is returned.
		/// </summary>
		/// <param name="typeOfEntity">The type of the entity for which the objects should be returned.</param>
		/// <returns>List with the requested data</returns>
		public List<IEntityCore> GetAll(Type typeOfEntity)
		{
			List<IEntityCore> toReturn = new List<IEntityCore>();

			if(!_entityTypeHashtables.ContainsKey(typeOfEntity))
			{
				return toReturn;
			}

			Dictionary<int, Dictionary<Guid, IEntityCore>> typeHashes = _entityTypeHashtables[typeOfEntity];

			foreach( Dictionary<Guid, IEntityCore> bucket in typeHashes.Values )
			{
				toReturn.AddRange(bucket.Values);
			}
			return toReturn;
		}


		/// <summary>
		/// Gets all the Type objects for which objects are located in this Context
		/// </summary>
		/// <returns>List with the requested data</returns>
		public List<Type> GetAllTypes()
		{
			List<Type> toReturn = new List<Type>();
			toReturn.AddRange(_entityTypeHashtables.Keys);
			return toReturn;
		}


		/// <summary>
		/// The passed in entity is checked if the contained data is already in this / a context in another entity object.
		/// If that's the case, that entity object is returned. If the data is not in this context in another entity object,
		/// the passed in entity is returned and added to this context.
		/// </summary>
		/// <param name="toCheck">entity to check</param>
		/// <returns>an already loaded entity with the same data, or the passed in entity if the data hasn't been loaded in another entity in this context
		/// or the entity passed in is new or the existing entity is deleted and its transaction has been completed.</returns>
		/// <remarks>if toCheck is new, it is added to the new entities pool (if not already present) and its context is set to this instance. 
		/// New entities aren't yet added to the context until they're saved. A new entity passed in is returned as well.
		/// SelfServicing specific version.</remarks>
		public IEntity Get(IEntity toCheck)
		{
			if(toCheck.IsNew)
			{
				if(_newEntities.ContainsKey(toCheck.ObjectID))
				{
					return toCheck;
				}
				_newEntities.Add(toCheck.ObjectID, toCheck);
				return toCheck;
			}
			// not new, check if the store already has an entity with the same data. 
			IEntity toReturn = FindEntity(toCheck);
			if(toReturn==null)
			{
				// not yet, add passed in entity and return it as well.
				Add(toCheck);
				toReturn = toCheck;
			}
			else
			{
				// found an existing entity with the same PK values. Check if the entity is dirty. If not, set its fields to the fields
				// passed in.
				if((!toReturn.IsDirty)&&(_setExistingEntityFieldsInGet))
				{
					toReturn.Fields = toCheck.Fields;
				}
			}

			if((toReturn.Fields.State==EntityState.Deleted)&&( !((EntityBase)toReturn).ParticipatesInTransaction))
			{
				// deleted, remove from store
				Remove(toReturn);
				toReturn = toCheck;
			}

			// found another object which contains the data.
			return toReturn;
		}


		/// <summary>
		/// The passed in entity is checked if the contained data is already in this / a context in another entity object.
		/// </summary>
		/// <param name="toCheck">entity to check</param>
		/// <returns>an already loaded entity with the same data, or the passed in entity if the data hasn't been loaded in another entity in this context
		/// or the entity passed in is new or the existing entity is deleted and its transaction has been completed.</returns>
		/// <remarks>if toCheck is new, it is added to the new entities pool (if not already present) and its context is set to this instance. 
		/// New entities aren't yet added to the context until they're saved. A new entity passed in is returned as well.
		/// Adapter specific version</remarks>
		public IEntity2 Get(IEntity2 toCheck)
		{
			if(toCheck.IsNew)
			{
				if(_newEntities.ContainsKey(toCheck.ObjectID))
				{
					return toCheck;
				}
				_newEntities.Add(toCheck.ObjectID, toCheck);
				return toCheck;
			}
			// not new, check if the store already has an entity with the same data. 
			IEntity2 toReturn = FindEntity(toCheck);
			if(toReturn==null)
			{
				// not yet, add passed in entity and return it as well.
				Add(toCheck);
				toReturn = toCheck;
			}
			else
			{
				// found an existing entity with the same PK values. Check if the entity is dirty. If not, set its fields to the fields
				// passed in.
				if((!toReturn.IsDirty)&&(_setExistingEntityFieldsInGet))
				{
					toReturn.Fields = toCheck.Fields;
				}
			}

			if((toReturn.Fields.State==EntityState.Deleted)&&( !((EntityBase2)toReturn).ParticipatesInTransaction))
			{
				// deleted, remove from store
				Remove(toReturn);
				toReturn = toCheck;
			}

			// found another object which contains the data.
			return toReturn;
		}


		/// <summary>
		/// Tries to find an entity with the same PK values as passed in. The PK values have to be in the same order as they appear in the constructor of the 
		/// entity. If an entity in the context has the same PK values, that entity is returned, otherwise a new entity is returned, created with the 
		/// factory passed in, with its PK values initialized, though not fetched. 
		/// </summary>
		/// <param name="factory">Factory to use for entity to find</param>
		/// <param name="pkValues">Pk values. Have to be specified in the same order as the PK fields in the entity constructor created by the factory passed in.</param>
		/// <returns>Entity with the same PK values if that entity was already added to the context, or a new entity if no entity was previously added to
		/// this context with the same PK values</returns>
		/// <exception cref="ArgumentException">if more/less pkvalues are passed in as there are in the PK of the entity created with the factory passed in</exception>
		/// <remarks>SelfServicing specific version</remarks>
		public IEntity Get(IEntityFactory factory, params object[] pkValues)
		{
			IEntity toFind = factory.Create();
			List<IEntityField> pkFieldsToExamine = null;

			if(((EntityBase)toFind).GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntity)
			{
				// special case, only use the PK fields which don't have a link to a supertype. These are linked to subtype PK fields, so the values will be set
				// OK
				pkFieldsToExamine = new List<IEntityField>();
				foreach(IEntityField pkField in toFind.PrimaryKeyFields)
				{
					if(pkField.LinkedSuperTypeField!=null)
					{
						// reached the subtype PK's. Quit with the loop
						break;
					}
					pkFieldsToExamine.Add(pkField);
				}
			}
			else
			{
				pkFieldsToExamine = toFind.PrimaryKeyFields;
			}

			if(pkFieldsToExamine.Count!=pkValues.Length)
			{
				throw new ArgumentException("The number of passed in PK values doesn't match the number of PK fields in the entity.", "pkValues");
			}

			// fill PK fields
			for (int i = 0; i < pkValues.Length; i++)
			{
				IEntityField field = pkFieldsToExamine[i];

				if(field.IsReadOnly)
				{
					// sequenced PK field.
					field.ForcedCurrentValueWrite(pkValues[i]);
					field.IsChanged = true;
					toFind.IsDirty = true;
				}
				else
				{
					toFind.SetNewFieldValue(field.FieldIndex, pkValues[i]);
				}
			}

			toFind.IsNew = false; // so Equals can be used
			IEntity toReturn = FindEntity(toFind);
			if(toReturn == null)
			{
				// not found
				toReturn = toFind;
				toReturn.IsNew = true;
			}

			if((toReturn.Fields.State==EntityState.Deleted)&&( !((EntityBase)toReturn).ParticipatesInTransaction))
			{
				// deleted, remove from store
				Remove(toReturn);
				toReturn = toFind;
			}

			return toReturn;
		}


		/// <summary>
		/// Tries to find an entity with the same PK values as passed in. The PK values have to be in the same order as they appear in the constructor of the 
		/// entity. If an entity in the context has the same PK values, that entity is returned, otherwise a new entity is returned, created with the 
		/// factory passed in, with its PK values initialized, though not fetched. 
		/// </summary>
		/// <param name="factory">Factory to use for entity to find</param>
		/// <param name="pkValues">Pk values. Have to be specified in the same order as the PK fields in the entity constructor created by the factory passed in.</param>
		/// <returns>Entity with the same PK values if that entity was already added to the context, or a new entity if no entity was previously added to
		/// this context with the same PK values</returns>
		/// <exception cref="ArgumentException">if more/less pkvalues are passed in as there are in the PK of the entity created with the factory passed in</exception>
		/// <remarks>Adapter specific version</remarks>
		public IEntity2 Get(IEntityFactory2 factory, params object[] pkValues)
		{
			IEntity2 toFind = factory.Create();
			List<IEntityField2> pkFieldsToExamine = null;

			if(((EntityBase2)toFind).GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntity)
			{
				// special case, only use the PK fields which don't have a link to a supertype. These are linked to subtype PK fields, so the values will be set
				// OK
				pkFieldsToExamine = new List<IEntityField2>();
				foreach(IEntityField2 pkField in toFind.PrimaryKeyFields)
				{
					if(pkField.LinkedSuperTypeField!=null)
					{
						// reached the subtype PK's. Quit with the loop
						break;
					}
					pkFieldsToExamine.Add(pkField);
				}
			}
			else
			{
				pkFieldsToExamine = toFind.PrimaryKeyFields;
			}

			if(pkFieldsToExamine.Count!=pkValues.Length)
			{
				throw new ArgumentException("The number of passed in PK values doesn't match the number of PK fields in the entity.", "pkValues");
			}

			// fill PK fields
			for (int i = 0; i < pkValues.Length; i++)
			{
				IEntityField2 field = pkFieldsToExamine[i];

				toFind.SetNewFieldValue(field.FieldIndex, pkValues[i]);
			}

			toFind.IsNew = false; // so Equals can be used
			IEntity2 toReturn = FindEntity(toFind);
			if(toReturn == null)
			{
				// not found
				toReturn = toFind;
				toReturn.IsNew = true;
			}

			if((toReturn.Fields.State==EntityState.Deleted)&&( !((EntityBase2)toReturn).ParticipatesInTransaction))
			{
				// deleted, remove from store
				Remove(toReturn);
				toReturn = toFind;
			}

			return toReturn;
		}


		/// <summary>
		/// Removes the specified entity from the store
		/// </summary>
		/// <param name="toRemove">To remove.</param>
		/// <remarks>generic version for both SelfServicing and Adapter.</remarks>
		public void Remove(IEntityCore toRemove)
		{
			if(toRemove.IsNew)
			{
				if(_newEntities.ContainsKey(toRemove.ObjectID))
				{
					_newEntities.Remove(toRemove.ObjectID);
					toRemove.ActiveContext = null;
				}
				return;
			}

			if(!_objectIDToEntityInstance.ContainsKey(toRemove.ObjectID))
			{
				// not part of store
				return;
			}

			_objectIDToEntityInstance.Remove(toRemove.ObjectID);

			// find hashbucket
			Type typeOfEntity = toRemove.GetType();
			Dictionary<int, Dictionary<Guid, IEntityCore>> typeHashes = null;
			if(! _entityTypeHashtables.TryGetValue( typeOfEntity, out typeHashes ) )
			{
				// can't happen.
				return;
			}

			int hash = toRemove.GetHashCode();
			Dictionary<Guid, IEntityCore> hashBucket = null;
			if(typeHashes.TryGetValue(hash, out hashBucket))
			{
				hashBucket.Remove(toRemove.ObjectID);
				toRemove.ActiveContext=null;
			}
		}


		/// <summary>
		/// Tries to find the passed in entity in the store, based on its contained data. It assumes the passed in entity isn't new. 
		/// </summary>
		/// <param name="toCheck">Entity object which contains entity data to </param>
		/// <returns></returns>
		private TEntity FindEntity<TEntity>(TEntity toCheck)
			where TEntity : class, IEntityCore
		{
			TEntity toReturn = null;

			if(_entityTypeHashtables.ContainsKey(toCheck.GetType()))
			{
				Dictionary<int, Dictionary<Guid, IEntityCore>> typeHashes = _entityTypeHashtables[toCheck.GetType()];
				// already hashes for this type, find the object
				int hash = toCheck.GetHashCode();
				Dictionary<Guid, IEntityCore> hashBucket = null;
				if(typeHashes.ContainsKey(hash))
				{
					// bucket with this hash available, could be in the store.
					hashBucket = typeHashes[hash];

					// traverse all objectid's in this bucket, to see if one has the same PK values. We need these buckets as 
					// some compound PK's can give the same hashvalue.
					foreach(TEntity entity in hashBucket.Values)
					{
						// use Equals, which is overriden to check PK fields
						if(entity.Equals(toCheck))
						{
							// found an entity with the same PK values
							toReturn = entity;
							break;
						}
					}
				}
				// otherwise not in the store, so just return the initially set object.
			}
			return toReturn;
		}


		/// <summary>
		/// Adds the entity passed in. The entity passed in is not new and the object isn't in the store as it isn't in a context yet. 
		/// It assumes that there is no entity with the same PK in the store, as that's checked by the public Add() methods.
		/// </summary>
		/// <param name="toAdd">entity to add</param>
		private void AddEntity(IEntityCore toAdd)
		{
			_objectIDToEntityInstance.Add(toAdd.ObjectID, toAdd);
			Type typeOfEntity = toAdd.GetType();
			Dictionary<int, Dictionary<Guid, IEntityCore>> typeHashes = null;

			if( _entityTypeHashtables.ContainsKey( typeOfEntity ) )
			{
				typeHashes = _entityTypeHashtables[typeOfEntity];
			}

			if(typeHashes==null)
			{
				// no type hashes yet, add empty hashtable
				typeHashes = new Dictionary<int,Dictionary<Guid,IEntityCore>>();
				_entityTypeHashtables.Add(typeOfEntity, typeHashes);
			}

			int hash = toAdd.GetHashCode();
			Dictionary<Guid, IEntityCore> hashBucket = null;
			if(typeHashes.ContainsKey(hash))
			{
				hashBucket = typeHashes[hash];
			}
			else
			{
				hashBucket = new Dictionary<Guid,IEntityCore>();
				typeHashes.Add(hash, hashBucket);
			}

			hashBucket.Add(toAdd.ObjectID, toAdd);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="setExistingEntityFieldsInGet"></param>
		private void InitClass(bool setExistingEntityFieldsInGet)
		{
			_objectIDToEntityInstance = new Dictionary<Guid,IEntityCore>();
			_entityTypeHashtables = new Dictionary<Type,Dictionary<int,Dictionary<Guid,IEntityCore>>>();
			_newEntities = new Dictionary<Guid,IEntityCore>();
			_setExistingEntityFieldsInGet = setExistingEntityFieldsInGet;
		}


		/// <summary>
		/// Adds the specified entity to the Context. If the passed in entity is already in a context, the Add is a no-op.
		/// Also if the entity isn't new and there is already an entity with the same PK values, the Add is a no-op.
		/// </summary>
		/// <param name="toAdd">entity to add to this context.</param>
		private void Add<TEntity>( TEntity toAdd )
			where TEntity : class, IEntityCore
		{
			if( toAdd.IsNew )
			{
				if( !_newEntities.ContainsKey( toAdd.ObjectID ) )
				{
					// not yet in the store
					_newEntities.Add( toAdd.ObjectID, toAdd );
				}
				// otherwise ignore, it's already been added.
			}
			else
			{
				// not new, check if it's already in a context
				if( toAdd.ActiveContext != null )
				{
					// yes already in a context, check if it's in here
					if( toAdd.ActiveContext == this )
					{
						if( _objectIDToEntityInstance.ContainsKey( toAdd.ObjectID ) )
						{
							// already added, already in the store
							return;
						}
					}
					else
					{
						// In other context, don't bother
						return;
					}
				}
				// not in a context yet, or in this context but not in the entity instance store (so was new). Check if there
				// is already an entity with the same PK values in this store. If so, skip, otherwise, add
				TEntity toFind = FindEntity( toAdd );
				if( toFind == null )
				{
					// not yet available in the store
					AddEntity( toAdd );
				}
			}

			// every entity passed into this method is physically set to this context, if not already in a context. 
			toAdd.ActiveContext = this;
		}



		#region Class Property Declarations
		/// <summary>
		/// Gets / sets SetExistingEntityFieldsInGet flag. When set to false (default is true), an existing
		/// entity's fields is not set to the fields of the passed in entity. Fields are only set if the entity isn't dirty.
		/// </summary>
		public bool SetExistingEntityFieldsInGet
		{
			get
			{
				return _setExistingEntityFieldsInGet;
			}
			set
			{
				_setExistingEntityFieldsInGet = value;
			}
		}

		#endregion
	}
}
