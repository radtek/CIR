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
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// UnitOfWork class. Can collect actions to perform on the entities/entity collections specified. 
	/// Will not perform these actions until Commit(transaction) is called. A UnitOfWork is meant to make development easier.
	/// It will not prohibit the developer to persist the actions also using other methods. 
	/// Selfservicing Specific.
	/// </summary>
	[Serializable]
	public class UnitOfWork
	{
		#region Class Member Declarations
		private	ArrayList	_entitiesToDelete, _collectionsToDelete,
							_callBacksPreInsert, _callBacksPreUpdate, _callBacksPreDelete, _callBacksPostDelete,
							_deleteMultiCalls, _updateMultiCalls;
		private Hashtable	_objectIDsToDelete;
		private bool		_optimizedSerialization;
		private ArrayList	_commitOrder;

		[NonSerialized]
		private ArrayList	_entitiesToInsert;
		[NonSerialized]
		private ArrayList	_entitiesToUpdate;
		[NonSerialized]
		private ArrayList	_entitiesToSave;
		[NonSerialized]
		private ArrayList	_collectionsToSave;
		[NonSerialized]
		private Hashtable	_objectIDsToSave;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		public UnitOfWork()
		{
			InitClass(null);
			_optimizedSerialization = true;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="UnitOfWork"/> class.
		/// </summary>
		/// <param name="commitOrder">The commit order of the various blocks in the unit of work object.</param>
		public UnitOfWork(ArrayList commitOrder)
		{
			InitClass(commitOrder);
			_optimizedSerialization = true;
		}


		/// <summary>
		/// CTor for deserialization
		/// </summary>
		/// <param name="info">Info.</param>
		/// <param name="context">Context.</param>
		public UnitOfWork(SerializationInfo info, StreamingContext context)
		{
			_optimizedSerialization = info.GetBoolean("_optimizedSerialization");
			_commitOrder = (ArrayList)info.GetValue("_commitOrder", typeof(ArrayList));
			_entitiesToSave = (ArrayList)info.GetValue("_entitiesToSave", typeof(ArrayList));
			_entitiesToDelete = (ArrayList)info.GetValue("_entitiesToDelete", typeof(ArrayList));
			_collectionsToDelete = (ArrayList)info.GetValue("_collectionsToDelete", typeof(ArrayList));
			_objectIDsToDelete = (Hashtable)info.GetValue("_objectIDsToDelete", typeof(Hashtable));
			_objectIDsToSave = (Hashtable)info.GetValue("_objectIDsToSave", typeof(Hashtable));
			_callBacksPreInsert = (ArrayList)info.GetValue("_callBacksPreInsert", typeof(ArrayList));
			_callBacksPreUpdate = (ArrayList)info.GetValue("_callBacksPreUpdate", typeof(ArrayList));
			_callBacksPreDelete = (ArrayList)info.GetValue("_callBacksPreDelete", typeof(ArrayList));
			_callBacksPostDelete =(ArrayList)info.GetValue("_callBacksPostDelete", typeof(ArrayList));
			_deleteMultiCalls = (ArrayList)info.GetValue("_deleteMultiCalls", typeof(ArrayList));
			_updateMultiCalls = (ArrayList)info.GetValue("_updateMultiCalls", typeof(ArrayList));
			if(_optimizedSerialization)
			{
				// collections have been flattened into entitiesToSave.
				_collectionsToSave = new ArrayList();
			}
			else
			{
				_collectionsToSave = (ArrayList)info.GetValue("_collectionsToSave", typeof(ArrayList));
			}
			_entitiesToInsert = new ArrayList();
			_entitiesToUpdate = new ArrayList();
		}


		/// <summary>
		/// Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo"/>
		/// with the data needed to serialize the target object.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> to populate with data.</param>
		/// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext"/>) for this serialization.</param>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_optimizedSerialization", _optimizedSerialization);

			if(_optimizedSerialization)
			{
				// create queues, then reset the entities/collections to save, then rebuild them from the queues, all non-recursive saves,
				// then add these collections to the info object.
				ConstructSaveProcessQueues();

				Hashtable objectIDsToSave = new Hashtable();
				ArrayList entitiesToSave = new ArrayList();

				foreach(ActionQueueElement element in _entitiesToInsert)
				{
					if(!objectIDsToSave.ContainsKey(element.Entity.ObjectID))
					{
						UnitOfWorkElement newElement = new UnitOfWorkElement((IEntity)element.Entity, null, false);
						objectIDsToSave.Add(element.Entity.ObjectID, newElement);
						entitiesToSave.Add(newElement);
					}
				}

				foreach(ActionQueueElement element in _entitiesToUpdate)
				{
					if(!objectIDsToSave.ContainsKey(element.Entity.ObjectID))
					{
						UnitOfWorkElement newElement = new UnitOfWorkElement((IEntity)element.Entity, element.AdditionalUpdateFilter, false);
						objectIDsToSave.Add(element.Entity.ObjectID, newElement);
						entitiesToSave.Add(newElement);
					}
				}

				info.AddValue("_entitiesToSave", entitiesToSave, typeof(ArrayList));
				info.AddValue("_objectIDsToSave", objectIDsToSave, typeof(Hashtable));
			}
			else
			{
				info.AddValue("_entitiesToSave", _entitiesToSave, typeof(ArrayList));
				info.AddValue("_objectIDsToSave", _objectIDsToSave, typeof(Hashtable));
				info.AddValue("_collectionsToSave", _collectionsToSave, typeof(ArrayList));
			}
			info.AddValue("_entitiesToDelete", _entitiesToDelete, typeof(ArrayList));
			info.AddValue("_collectionsToDelete", _collectionsToDelete, typeof(ArrayList));
			info.AddValue("_callBacksPreInsert", _callBacksPreInsert, typeof(ArrayList));
			info.AddValue("_callBacksPreUpdate", _callBacksPreUpdate, typeof(ArrayList));
			info.AddValue("_callBacksPreDelete", _callBacksPreDelete, typeof(ArrayList));
			info.AddValue("_callBacksPostDelete", _callBacksPostDelete, typeof(ArrayList));
			info.AddValue("_deleteMultiCalls", _deleteMultiCalls, typeof(ArrayList));
			info.AddValue("_updateMultiCalls", _updateMultiCalls, typeof(ArrayList));
			info.AddValue("_objectIDsToDelete", _objectIDsToDelete, typeof(Hashtable));
			info.AddValue("_commitOrder", _commitOrder);
		}


		/// <summary>
		/// Gets the UnitOfWorkElements with the entities which are added with <see cref="AddForSave"/> and which are new UnitOfWorkElementCollection. 
		/// To remove an entity, call <see cref="RemoveFromUoW"/>
		/// </summary>
		/// <returns>new UnitOfWorkElementCollection with all UnitOfWorkElements with the entities which are added using AddForSave and which are new</returns>
		public UnitOfWorkElementCollection GetEntityElementsToInsert()
		{
			ArrayList toReturn = new ArrayList();
			foreach(UnitOfWorkElement element in _entitiesToSave)
			{
				if(element.Entity.IsNew)
				{
					toReturn.Add(element);
				}
			}
			return new UnitOfWorkElementCollection(toReturn);		
		}


		/// <summary>
		/// Gets the UnitOfWorkElements with the entities which are added with <see cref="AddForSave"/> and which are not new UnitOfWorkElementCollection. 
		/// To remove an entity, call <see cref="RemoveFromUoW"/>
		/// </summary>
		/// <returns>new UnitOfWorkElementCollection with all UnitOfWorkElements with the entities which are added using AddForSave and which are not new</returns>
		public UnitOfWorkElementCollection GetEntityElementsToUpdate()
		{
			ArrayList toReturn = new ArrayList();
			foreach(UnitOfWorkElement element in _entitiesToSave)
			{
				if(!element.Entity.IsNew)
				{
					toReturn.Add(element);
				}
			}
			return new UnitOfWorkElementCollection(toReturn);
		}


		/// <summary>
		/// Gets the insert queue, which is a readonly arraylist of entity objects which have been placed in the insert queue. 
		/// This queue is empty unless <see cref="ConstructSaveProcessQueues"/> has been called, or <see cref="Commit"/> has been called, which calls
		/// <see cref="ConstructSaveProcessQueues"/> under the hood. If this method is called after <see cref="Commit"/>, and Commit succeeded, the
		/// entities in the queue returned are saved succesfully. Calling <see cref="Reset"/> will not clear the queues, only <see cref="ConstructSaveProcessQueues"/>
		/// or <see cref="Commit"/> will.
		/// </summary>
		/// <returns>Readonly arraylist with the entities in the insert queue.</returns>
		public ArrayList GetInsertQueue()
		{
#if CF
			return new ArrayList(_entitiesToInsert);
#else
			return ArrayList.ReadOnly(_entitiesToInsert);
#endif
		}


		/// <summary>
		/// Gets the update queue, which is a readonly arraylist of entity objects which have been placed in the update queue. 
		/// This queue is empty unless <see cref="ConstructSaveProcessQueues"/> has been called, or <see cref="Commit"/> has been called, which calls
		/// <see cref="ConstructSaveProcessQueues"/> under the hood. If this method is called after <see cref="Commit"/>, and Commit succeeded, the
		/// entities in the queue returned are saved succesfully. Calling <see cref="Reset"/> will not clear the queues, only <see cref="ConstructSaveProcessQueues"/>
		/// or <see cref="Commit"/> will.
		/// </summary>
		/// <returns>Readonly arraylist with the entities in the insert queue.</returns>
		public ArrayList GetUpdateQueue()
		{
#if CF
			return new ArrayList(_entitiesToUpdate);
#else
			return ArrayList.ReadOnly(_entitiesToUpdate);
#endif
		}


		/// <summary>
		/// Gets the UnitOfWorkElements with the entities which are added with <see cref="AddForDelete"/>, in a new UnitOfWorkElementCollection. 
		/// To remove an entity, call <see cref="RemoveFromUoW"/>
		/// </summary>
		/// <returns>new UnitOfWorkElementCollection with all UnitOfWorkElements with the entities which are added using AddForDelete</returns>
		public UnitOfWorkElementCollection GetEntityElementsToDelete()
		{
			return new UnitOfWorkElementCollection(_entitiesToDelete);
		}


		/// <summary>
		/// Gets the UnitOfWorkCollectionElements with the collections which are added with <see cref="AddCollectionForSave"/>, in a new UnitOfWorkCollectionElementCollection. 
		/// To remove a collection, call <see cref="RemoveCollectionFromUoW"/>
		/// </summary>
		/// <returns>new UnitOfWorkCollectionElementCollection with all UnitOfWorkCollectionElements with the entities which are added using AddCollectionForSave</returns>
		public UnitOfWorkCollectionElementCollection GetCollectionElementsToSave()
		{
			return new UnitOfWorkCollectionElementCollection(_collectionsToSave);
		}


		/// <summary>
		/// Gets the UnitOfWorkCollectionElements with the collections which are added with <see cref="AddCollectionForDelete"/>, in a new UnitOfWorkCollectionElementCollection. 
		/// To remove a collection, call <see cref="RemoveCollectionFromUoW"/>
		/// </summary>
		/// <returns>new UnitOfWorkCollectionElementCollection with all UnitOfWorkCollectionElements with the entities which are added using AddCollectionForDelete</returns>
		public UnitOfWorkCollectionElementCollection GetCollectionElementsToDelete()
		{
			return new UnitOfWorkCollectionElementCollection(_collectionsToDelete);
		}


		/// <summary>
		/// Adds the passed in entity for saving. No recursion will be applied during the save of this entity when the unit of work is committed.
		/// </summary>
		/// <param name="entityToSave">The entity to save via this unit of work</param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (already added for a similar action)</returns>
		public bool AddForSave(IEntity entityToSave)
		{
			return AddForSave(entityToSave, null, false);
		}

		
		/// <summary>
		/// Adds the passed in entity for saving. No recursion will be applied during the save of this entity when the unit of work is committed.
		/// </summary>
		/// <param name="entityToSave">The entity to save via this unit of work</param>
		/// <param name="restriction">Filter to apply during save (ignored when the entity is new). This restriction will be AND-ed
		/// with the restriction constructed by a ConcurrencyPredicateFactory instance in entityToSave (if applicable).</param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (already added for a similar action)</returns>
		public bool AddForSave(IEntity entityToSave, IPredicate restriction)
		{
			return AddForSave(entityToSave, restriction, false);
		}


		/// <summary>
		/// Adds the passed in entity for saving. 
		/// </summary>
		/// <param name="entityToSave">The entity to save via this unit of work</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by this entity also.</param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (already added for a similar action)</returns>
		public bool AddForSave(IEntity entityToSave, bool recurse)
		{
			return AddForSave(entityToSave, null, recurse);
		}


		/// <summary>
		/// Adds the passed in entity for saving. 
		/// </summary>
		/// <param name="entityToSave">The entity to save via this unit of work</param>
		/// <param name="restriction">Filter to apply during save (ignored when the entity is new). This restriction will be AND-ed
		/// with the restriction constructed by a ConcurrencyPredicateFactory instance in entityToSave (if applicable).</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by this entity also.</param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (already added for a similar action)</returns>
		public virtual bool AddForSave(IEntity entityToSave, IPredicate restriction, bool recurse)
		{
			bool accept = false;
			UnitOfWorkElement newElement = null;
			if(!_objectIDsToSave.ContainsKey(entityToSave.ObjectID))
			{
				// accept
				accept = true;
				newElement = new UnitOfWorkElement(entityToSave, restriction, recurse);
				_objectIDsToSave.Add(entityToSave.ObjectID, newElement);
				_entitiesToSave.Add(newElement);
			}
			return accept;
		}


		/// <summary>
		/// Removes the specified entity from this UnitOfWork. If the entity is in an added collection, the entity will later on still be added. 
		/// </summary>
		/// <param name="entityToRemove">Entity to remove.</param>
		public virtual void RemoveFromUoW(IEntity entityToRemove)
		{
			if(_objectIDsToDelete.ContainsKey(entityToRemove.ObjectID))
			{
				UnitOfWorkElement element = (UnitOfWorkElement)_objectIDsToDelete[entityToRemove.ObjectID];
				_objectIDsToDelete.Remove(entityToRemove.ObjectID);
				_entitiesToDelete.Remove(element);
				return;
			}

			if(_objectIDsToSave.ContainsKey(entityToRemove.ObjectID))
			{
				UnitOfWorkElement element = (UnitOfWorkElement)_objectIDsToSave[entityToRemove.ObjectID];
				_objectIDsToSave.Remove(entityToRemove.ObjectID);
				_entitiesToSave.Remove(element);
				return;
			}
		}


		/// <summary>
		/// Removes the specified entity collection from this UnitOfWork. 
		/// </summary>
		/// <param name="collectionToRemove">Entity collection to remove.</param>
		public virtual void RemoveCollectionFromUoW(IEntityCollection collectionToRemove)
		{
			ArrayList elementsToRemove = new ArrayList();
			foreach(UnitOfWorkCollectionElement element in _collectionsToSave)
			{
				if(element.Collection==collectionToRemove)
				{
					elementsToRemove.Add(element);
				}
			}

			foreach(UnitOfWorkCollectionElement element in elementsToRemove)
			{
				_collectionsToSave.Remove(element);
			}

			elementsToRemove.Clear();

			foreach(UnitOfWorkCollectionElement element in _collectionsToDelete)
			{
				if(element.Collection==collectionToRemove)
				{
					elementsToRemove.Add(element);
				}
			}

			foreach(UnitOfWorkCollectionElement element in elementsToRemove)
			{
				_collectionsToDelete.Remove(element);
			}
		}


		/// <summary>
		/// Adds the collection with entities for saving. When the UnitOfWork is committed, the entities in the collection are added to the
		/// correct process bins to make sure the order is correct.
		/// </summary>
		/// <param name="collectionToSave">collection with entities to be added for saving</param>
		public void AddCollectionForSave(IEntityCollection collectionToSave)
		{
			AddCollectionForSave(collectionToSave, false);
		}


		/// <summary>
		/// Adds the collection with entities for saving. When the UnitOfWork is committed, the entities in the collection are added to the
		/// correct process bins to make sure the order is correct.
		/// </summary>
		/// <param name="collectionToSave">collection with entities to be added for saving</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by this entity also.</param>
		public virtual void AddCollectionForSave(IEntityCollection collectionToSave, bool recurse)
		{
			_collectionsToSave.Add(new UnitOfWorkCollectionElement(collectionToSave, recurse));
		}


		/// <summary>
		/// Adds the passed in entity for deletion. 
		/// </summary>
		/// <param name="entityToDelete">The entity to delete via this unit of work</param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (entity is new)</returns>
		public bool AddForDelete(IEntity entityToDelete)
		{
			return AddForDelete(entityToDelete, null, true);
		}

		
		/// <summary>
		/// Adds the passed in entity for deletion.
		/// </summary>
		/// <param name="entityToDelete">The entity to delete via this unit of work</param>
		/// <param name="restriction">Filter to apply during delete. This restriction will be AND-ed
		/// with the restriction constructed by a ConcurrencyPredicateFactory instance in entityToDelete (if applicable).</param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (entity is new)</returns>
		public virtual bool AddForDelete(IEntity entityToDelete, IPredicate restriction)
		{
			return AddForDelete(entityToDelete, restriction, true);
		}


		/// <summary>
		/// Adds the passed in object for delete. This is the actual routine performing the work.
		/// </summary>
		/// <param name="entityToDelete">Entity to delete.</param>
		/// <param name="restriction">Restriction.</param>
		/// <param name="append">If true (default), append the entity at the end of the list, otherwise insert it at the front. False in the case
		/// of inserting objects from collections marked for deletion.</param>
		internal bool AddForDelete(IEntity entityToDelete, IPredicate restriction, bool append)
		{
			bool accept = false;
			UnitOfWorkElement newElement = null;
			if(!entityToDelete.IsNew)
			{
				if(!_objectIDsToDelete.ContainsKey(entityToDelete.ObjectID))
				{
					// accept
					accept = true;
					newElement = new UnitOfWorkElement(entityToDelete, restriction);
					_objectIDsToDelete.Add(entityToDelete.ObjectID, newElement);
					if(append)
					{
						_entitiesToDelete.Add(newElement);
					}
					else
					{
						_entitiesToDelete.Insert(0, newElement);
					}
				}
			}
			else
			{
				// check if this entity is added for save as well. if so, remove it from the save queue.
				if(_objectIDsToSave.ContainsKey(entityToDelete.ObjectID))
				{
					UnitOfWorkElement element = (UnitOfWorkElement)_objectIDsToSave[entityToDelete.ObjectID];
					_objectIDsToSave.Remove(entityToDelete.ObjectID);
					_entitiesToSave.Remove(element);
				}
			}

			return accept;
		}


		/// <summary>
		/// Adds the collection with entities for deletion. When the UnitOfWork is committed, the entities in the collection are added to the
		/// correct process bins to make sure the order is correct.
		/// </summary>
		/// <param name="collectionToDelete">collection with entities to be added for deletion</param>
		public virtual void AddCollectionForDelete(IEntityCollection collectionToDelete)
		{
			_collectionsToDelete.Add(new UnitOfWorkCollectionElement(collectionToDelete));
		}


		/// <summary>
		/// Adds the call back passed in, to the slot specified with the parameters specified. 
		/// </summary>
		/// <param name="delegateToCall">Delegate to call.</param>
		/// <param name="schedulingSlot">Scheduling slot to call the delegate in.</param>
		/// <param name="parameters">Parameters to pass to the delegate.</param>
		/// <remarks>will pass in the used Transaction as the last parameter to the delegate.</remarks>
		public void AddCallBack(Delegate delegateToCall, UnitOfWorkCallBackScheduleSlot schedulingSlot, params object[] parameters)
		{
			AddCallBack(delegateToCall, schedulingSlot, true, parameters);
		}


		/// <summary>
		/// Adds the call back passed in, to the slot specified with the parameters specified. 
		/// </summary>
		/// <param name="delegateToCall">Delegate to call.</param>
		/// <param name="schedulingSlot">Scheduling slot to call the delegate in.</param>
		/// <param name="passInTransaction">Flag to tell the Commit routine to pass the used Transaction object as the last parameter to the delegate (true, default)
		/// or not (false).</param>
		/// <param name="parameters">Parameters to pass to the delegate. If you've specified true for passInTransaction,
		/// the Transaction object used during commit will be passed in as the last parameter.</param>
		public virtual void AddCallBack(Delegate delegateToCall, UnitOfWorkCallBackScheduleSlot schedulingSlot, bool passInTransaction, params object[] parameters)
		{
#if CF
			throw new NotSupportedException("Not supported on Compact Framework");
#else
			UnitOfWorkCallBackElement element = new UnitOfWorkCallBackElement(delegateToCall, passInTransaction, parameters);
			switch(schedulingSlot)
			{
				case UnitOfWorkCallBackScheduleSlot.PreEntityInsert:
					_callBacksPreInsert.Add(element);
					break;
				case UnitOfWorkCallBackScheduleSlot.PreEntityUpdate:
					_callBacksPreUpdate.Add(element);
					break;
				case UnitOfWorkCallBackScheduleSlot.PreEntityDelete:
					_callBacksPreDelete.Add(element);
					break;
				case UnitOfWorkCallBackScheduleSlot.PostEntityDelete:
					_callBacksPostDelete.Add(element);
					break;
			}
#endif
		}


		/// <summary>
		/// Resets the inner contents of this unit of work. 
		/// </summary>
		public virtual void Reset()
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "UnitOfWork.Reset", "Method Enter");

			_entitiesToDelete.Clear();
			_entitiesToSave.Clear();
			_collectionsToDelete.Clear();
			_collectionsToSave.Clear();
			_objectIDsToDelete.Clear();
			_objectIDsToSave.Clear();
			_callBacksPreInsert.Clear();
			_callBacksPreUpdate.Clear();
			_callBacksPreDelete.Clear();
			_callBacksPostDelete.Clear();
			_deleteMultiCalls.Clear();
			_updateMultiCalls.Clear();

			_deleteMultiCalls = new ArrayList();
			_updateMultiCalls = new ArrayList();
			_entitiesToDelete = new ArrayList();
			_entitiesToSave = new ArrayList();
			_collectionsToDelete = new ArrayList();
			_collectionsToSave = new ArrayList();
			_objectIDsToDelete = new Hashtable();
			_objectIDsToSave = new Hashtable();
			_callBacksPreInsert = new ArrayList();
			_callBacksPreUpdate = new ArrayList();
			_callBacksPreDelete = new ArrayList();
			_callBacksPostDelete = new ArrayList();

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "UnitOfWork.Reset", "Method Exit");
		}


		/// <summary>
		/// Adds a call to collection.DeleteMulti(filter) to delete entities directly from the database using the passed in
		/// criteria. The call will be executed inside the transaction used in Commit and will be executed after the last entity has been
		/// deleted but before the PostEntityDelete callbacks.
		/// </summary>
		/// <param name="collection">Collection object to call DeleteMulti on.</param>
		/// <param name="filter">Filter to use.</param>
		public void AddDeleteMultiCall(IEntityCollection collection, IPredicate filter)
		{
			AddDeleteMultiCall(collection, filter, null);
		}


		/// <summary>
		/// Adds a call to collection.DeleteMulti(filter, relations) to delete entities directly from the database using the passed in
		/// criteria. The call will be executed inside the transaction used in Commit and will be executed after the last entity has been
		/// deleted but before the PostEntityDelete callbacks.
		/// </summary>
		/// <param name="collection">Collection object to call DeleteMulti on.</param>
		/// <param name="filter">Filter to use.</param>
		/// <param name="relations">RelationCollection to use.</param>
		public virtual void AddDeleteMultiCall(IEntityCollection collection, IPredicate filter, IRelationCollection relations)
		{
			UnitOfWorkDeleteMultiElement element = new UnitOfWorkDeleteMultiElement(filter, relations, collection);
			_deleteMultiCalls.Add(element);
		}


		/// <summary>
		/// Adds a call to collection.UpdateMulti(Entity, filter) to update entities directly in the database using the passed in
		/// criteria. The call will be executed inside the transaction used in Commit and will be executed after the last entity has been
		/// updated but before the PreEntityUpdate callbacks.
		/// </summary>
		/// <param name="collection">Collection object to call UpdateMulti on.</param>
		/// <param name="entityWithNewValues">instance which holds the new values for the matching entities to update. Only changed fields are taken into account </param>
		/// <param name="filter">Filter to use.</param>
		public void AddUpdateMultiCall(IEntityCollection collection, IEntity entityWithNewValues, IPredicate filter)
		{
			AddUpdateMultiCall(collection, entityWithNewValues, filter, null);
		}


		/// <summary>
		/// Adds a call to collection.UpdateMulti(Entity, filter, relations) to update entities directly in the database using the passed in
		/// criteria. The call will be executed inside the transaction used in Commit and will be executed after the last entity has been
		/// updated but before the PreEntityUpdate callbacks.
		/// </summary>
		/// <param name="collection">Collection object to call UpdateMulti on.</param>
		/// <param name="entityWithNewValues">instance which holds the new values for the matching entities to update. Only changed fields are taken into account </param>
		/// <param name="filter">Filter to use.</param>
		/// <param name="relations">RelationCollection to use.</param>
		public virtual void AddUpdateMultiCall(IEntityCollection collection, IEntity entityWithNewValues, IPredicate filter, IRelationCollection relations)
		{
			UnitOfWorkUpdateMultiElement element = new UnitOfWorkUpdateMultiElement(filter, relations, collection, entityWithNewValues);
			_updateMultiCalls.Add(element);
		}


		/// <summary>
		/// Commits this unit of work. It will first add all entities in the added collections to the correct bins, then it will start
		/// by first inserting all new entities, then saving all updates and then performing the deletes. 
		/// </summary>
		/// <param name="transactionToUse">Transaction to use. All entities to process will be added to this transaction, unless they're already part
		/// of another transaction.</param>
		/// <remarks>It will not commit nor rollback the transaction.</remarks>
		/// <exception cref="ArgumentNullException">when transactionToUse is null</exception>
		/// <returns>The total # of entities affected by all actions performed in the Commit method</returns>
		public int Commit(ITransaction transactionToUse)
		{
			return Commit(transactionToUse, false);
		}


		/// <summary>
		/// Commits this unit of work. It will first add all entities in the added collections to the correct bins, then it will start
		/// by first inserting all new entities, then saving all updates and then performing the deletes. 
		/// </summary>
		/// <param name="transactionToUse">Transaction to use. All entities to process will be added to this transaction, unless they're already part
		/// of another transaction.</param>
		/// <param name="autoCommit">if true, it will commit/rollback the transaction passed in using the following rules:
		/// - if no exception is thrown: commit
		/// - if an exception is thrown: rollback</param>
		/// <exception cref="ArgumentNullException">when transactionToUse is null</exception>
		/// <returns>The total # of entities affected by all actions performed in the Commit method</returns>
		public virtual int Commit(ITransaction transactionToUse, bool autoCommit)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "UnitOfWork.Commit(2)", "Method Enter");
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, String.Format("\tTransaction to use: {0}. AutoCommit: {1}", transactionToUse.Name, autoCommit.ToString()));

			if(transactionToUse==null)
			{
				throw new ArgumentNullException("transactionToUse", "You have to specify a valid transaction object");
			}

			if((_commitOrder==null) || (_commitOrder.Count<=0))
			{
				// commit order is cleared. Error out.
				throw new ORMGeneralOperationException("CommitOrder is empty. The commit has been aborted to prevent dangling transactions. You shouldn't clear the CommitOrder of a unit of work object.");
			}

			int totalAmountAffected = 0;

			// collections are inserted at the front of the queue. However to keep the order in which they're added, process the collections from the back
			for (int i = _collectionsToDelete.Count-1;i>=0; i--)
			{
				UnitOfWorkCollectionElement currentElement = (UnitOfWorkCollectionElement)_collectionsToDelete[i];
				for (int j = 0; j < currentElement.Collection.Count; j++)
				{
					IEntity currentEntity = ((EntityCollectionBase)currentElement.Collection)[j];
					AddForDelete(currentEntity, null, false);
				}
			}

			// construct the process queues so they can be processed after this.
			ConstructSaveProcessQueues();

			////////////////
			// process the actual actions
			////////////////
			Hashtable processedBlocks = new Hashtable();
			int actionTotal = 0;
			try
			{
				foreach(UnitOfWorkBlockType blockToProcess in _commitOrder)
				{
					if(processedBlocks.ContainsKey(blockToProcess))
					{
						// already did this block
						continue;
					}
					processedBlocks.Add(blockToProcess, null);

					switch(blockToProcess)
					{
						case UnitOfWorkBlockType.Inserts:
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling Pre Insert CallBacks.");
#if !CF
							foreach(UnitOfWorkCallBackElement element in _callBacksPreInsert)
							{
								element.DelegateToCall.DynamicInvoke(ConstructParameters(element.Parameters, transactionToUse, element.PassInTransaction));
							}
#endif
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling Inserts.");
							bool saveResult = DaoBase.PersistQueue(_entitiesToInsert, true, transactionToUse, out actionTotal);
							totalAmountAffected += actionTotal;
							break;
						case UnitOfWorkBlockType.Updates:
#if !CF
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling Pre Update CallBacks.");
							foreach(UnitOfWorkCallBackElement element in _callBacksPreUpdate)
							{
								element.DelegateToCall.DynamicInvoke(ConstructParameters(element.Parameters, transactionToUse, element.PassInTransaction));
							}
#endif
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling Updates.");
							saveResult = DaoBase.PersistQueue(_entitiesToUpdate, false, transactionToUse, out actionTotal);
							totalAmountAffected += actionTotal;
							break;
						case UnitOfWorkBlockType.UpdatesPerformedDirectly:
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling UpdateMulti Calls.");
							foreach(UnitOfWorkUpdateMultiElement element in _updateMultiCalls)
							{
								transactionToUse.Add((ITransactionalElement)element.Collection);
								totalAmountAffected += ((EntityCollectionBase)element.Collection).UpdateMulti(element.Entity, element.Filter, element.Relations);
							}
							break;
						case UnitOfWorkBlockType.Deletes:
#if !CF
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling Pre Delete CallBacks.");
							foreach(UnitOfWorkCallBackElement element in _callBacksPreDelete)
							{
								element.DelegateToCall.DynamicInvoke(ConstructParameters(element.Parameters, transactionToUse, element.PassInTransaction));
							}
#endif
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling Deletes.");
							for (int i = 0; i < _entitiesToDelete.Count; i++)
							{
								UnitOfWorkElement currentElement = (UnitOfWorkElement)_entitiesToDelete[i];
								EntityBase entityToProcess = (EntityBase)currentElement.Entity;
								if(!entityToProcess.ParticipatesInTransaction)
								{
									transactionToUse.Add(entityToProcess);
								}

								IPredicateExpression restrictionFilter = ConstructRestrictionFilter(currentElement, ConcurrencyPredicateType.Delete);
								bool deleteResult = entityToProcess.Delete(restrictionFilter);
								if(!deleteResult)
								{
									throw new ORMConcurrencyException("During the commit of the UnitOfWork class, the delete action on an entity failed. The entity which failed is enclosed.", currentElement.Entity);
								}
								totalAmountAffected++;
							}
#if !CF
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling Post Delete CallBacks.");
							foreach(UnitOfWorkCallBackElement element in _callBacksPostDelete)
							{
								element.DelegateToCall.DynamicInvoke(ConstructParameters(element.Parameters, transactionToUse, element.PassInTransaction));
							}
#endif							
							break;
						case UnitOfWorkBlockType.DeletesPerformedDirectly:
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling DeleteMulti Calls.");
							foreach(UnitOfWorkDeleteMultiElement element in _deleteMultiCalls)
							{
								transactionToUse.Add((ITransactionalElement)element.Collection);
								totalAmountAffected+= ((EntityCollectionBase)element.Collection).DeleteMulti(element.Filter, element.Relations);
							}
							break;
					}
				}

				Reset();

				if(autoCommit)
				{
					transactionToUse.Commit();
				}

				return totalAmountAffected;
			}
			catch
			{
				if(autoCommit)
				{
					transactionToUse.Rollback();
				}

				throw;
			}
			finally
			{
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "UnitOfWork.Commit(2)", "Method Exit");
			}
		}


		/// <summary>
		/// Constructs the save process queues for insert and update actions. These queues are constructed from the entities added to this UoW 
		/// for save either individually or in a collection. Call this method to determine what the sequence will be for the insert and update
		/// actions executed during Commit(). Commit() uses this method as well as well as the serialization/deserialization logic, to avoid
		/// sending large object graphs with few changes.
		/// </summary>
		public void ConstructSaveProcessQueues()
		{
			// clear current queues
			_entitiesToInsert = new ArrayList(_entitiesToSave.Count);
			_entitiesToUpdate = new ArrayList(_entitiesToSave.Count);

			// some entities are added for recursive saves, others aren't. Use a per-entity queue build action.
			ObjectGraphUtils graphUtils = new ObjectGraphUtils();
			ArrayList elementsToProcess = new ArrayList(_entitiesToSave);
			Hashtable tmpObjectIDsToSave = new Hashtable(_objectIDsToSave);
			foreach(UnitOfWorkCollectionElement currentElement in _collectionsToSave)
			{
				foreach(IEntity currentEntity in currentElement.Collection)
				{
					if(!tmpObjectIDsToSave.ContainsKey(currentEntity.ObjectID) &&
						(
							currentElement.Recurse ||
							(
								!currentElement.Recurse &&
								(
									currentEntity.IsDirty || 
									(
										!currentEntity.IsDirty && currentEntity.IsNew && 
										(((EntityBase)currentEntity).GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntityHierarchy)
									)
								)
							)
						)
					)
					{
						UnitOfWorkElement newElement = new UnitOfWorkElement(currentEntity, null, currentElement.Recurse);
						tmpObjectIDsToSave.Add(currentEntity.ObjectID, newElement);
						elementsToProcess.Add(newElement);
					}
				}
			}

			Hashtable inQueue = new Hashtable(512);
			MergeableHashtable alreadyProcessed = new MergeableHashtable(512);
			foreach(UnitOfWorkElement element in elementsToProcess)
			{
				if(!inQueue.ContainsKey(element.Entity.ObjectID) && !alreadyProcessed.ContainsKey(element.Entity.ObjectID))
				{
					Hashtable entitiesInGraph = new Hashtable();
					if(element.Recurse)
					{
						graphUtils.DetermineActionQueues(element.Entity, element.Restriction, ref _entitiesToInsert, ref _entitiesToUpdate, ref inQueue, out entitiesInGraph);
					}
					else
					{
						if(element.Entity.IsNew)
						{
							_entitiesToInsert.Add(new ActionQueueElement(element.Entity, null, false));
						}
						else
						{
							if(element.Restriction!=null)
							{
								_entitiesToUpdate.Add(new ActionQueueElement(element.Entity, new PredicateExpression(element.Restriction), false));
							}
							else
							{
								_entitiesToUpdate.Add(new ActionQueueElement(element.Entity, element.Entity.GetConcurrencyPredicate(ConcurrencyPredicateType.Save), false));
							}
						}
						inQueue.Add(element.Entity.ObjectID, null);
						entitiesInGraph.Add(element.Entity.ObjectID, null);
					}
					// merge entitiesInGraph with alreadyProcessed. 
					alreadyProcessed.MergeHashtable(entitiesInGraph);
				}
			}
		}


		/// <summary>
		/// Constructs the parameters to pass
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		/// <param name="transactionToUse">Transaction to use.</param>
		/// <param name="passInTransaction">Pass in transaction.</param>
		private object[] ConstructParameters(object[] parameters, ITransaction transactionToUse, bool passInTransaction)
		{
			object[] toReturn = null;
			if(passInTransaction)
			{
				toReturn = new object[parameters.Length+1];
				parameters.CopyTo(toReturn, 0);
				toReturn[toReturn.Length-1] = transactionToUse;
			}
			else
			{
				toReturn = parameters;
			}

			return toReturn;
		}


		/// <summary>
		/// Constructs the restriction filter for the element passed in
		/// </summary>
		/// <param name="element">Element.</param>
		/// <param name="concurrencyType"></param>
		/// <returns></returns>
		private IPredicateExpression ConstructRestrictionFilter(UnitOfWorkElement element, ConcurrencyPredicateType concurrencyType)
		{
			IPredicateExpression toReturn = new PredicateExpression();
			IPredicate restrictionFilter = element.Restriction;
			IPredicateExpression concurrencyRestrictionFilter = element.Entity.GetConcurrencyPredicate(concurrencyType);

			if(restrictionFilter!=null)
			{
				toReturn.Add(restrictionFilter);
			}
			if(concurrencyRestrictionFilter!=null)
			{
				toReturn.Add(concurrencyRestrictionFilter);
			}
			if(toReturn.Count<=0)
			{
				toReturn=null;
			}
			return toReturn;
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="commitOrder">The commit order.</param>
		private void InitClass(ArrayList commitOrder)
		{
			if(commitOrder == null)
			{
				_commitOrder = new ArrayList();
				_commitOrder.Add(UnitOfWorkBlockType.Inserts);
				_commitOrder.Add(UnitOfWorkBlockType.Updates);
				_commitOrder.Add(UnitOfWorkBlockType.UpdatesPerformedDirectly);
				_commitOrder.Add(UnitOfWorkBlockType.Deletes);
				_commitOrder.Add(UnitOfWorkBlockType.DeletesPerformedDirectly);
			}
			else
			{
				_commitOrder = commitOrder;
			}
			_optimizedSerialization = true;
			_entitiesToSave = new ArrayList();
			_entitiesToDelete = new ArrayList();
			_entitiesToInsert = new ArrayList();
			_entitiesToUpdate = new ArrayList();
			_collectionsToDelete = new ArrayList();
			_collectionsToSave = new ArrayList();
			_objectIDsToDelete = new Hashtable();
			_objectIDsToSave = new Hashtable();
			_callBacksPreInsert = new ArrayList();
			_callBacksPreUpdate = new ArrayList();
			_callBacksPreDelete = new ArrayList();
			_callBacksPostDelete = new ArrayList();
			_deleteMultiCalls = new ArrayList();
			_updateMultiCalls = new ArrayList();
		}
		

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets the OptimizedSerialization flag. Default: true. When set to false, the serialization logic will simply serialize all entities inside the
		/// unit of work. When set to true, the unit of work will first calculate the save queues, which weeds out entities which aren't changed and won't be
		/// saved anyway, so these don't have to be sent over the wire. 
		/// </summary>
		public bool OptimizedSerialization
		{
			get
			{
				return _optimizedSerialization;
			}
			set
			{
				_optimizedSerialization = value;
			}
		}


		/// <summary>
		/// Gets / sets the Commit Order of the various blocks the unit of work groups the elements in.
		/// </summary>
		public ArrayList CommitOrder
		{
			get
			{
				return _commitOrder;
			}
			set
			{
				_commitOrder = value;
			}
		}
		#endregion
	}



	/// <summary>
	/// unit of work element to store in the update multi calls to execute
	/// </summary>
	[Serializable]
	internal class UnitOfWorkUpdateMultiElement
	{
		#region Class Member Declarations
		private IPredicate				_filter;
		private IRelationCollection		_relations;
		private IEntityCollection		_collection;
		private IEntity					_entity;
		#endregion


		/// <summary>
		/// CTor. 
		/// </summary>
		public UnitOfWorkUpdateMultiElement()
		{
			InitClass(null, null, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="UnitOfWorkUpdateMultiElement"/> instance.
		/// </summary>
		/// <param name="filter">Filter.</param>
		/// <param name="relations">Relations.</param>
		/// <param name="collection">Collection.</param>
		/// <param name="entity">Entity.</param>
		public UnitOfWorkUpdateMultiElement(IPredicate filter, IRelationCollection relations, IEntityCollection collection, IEntity entity)
		{
			InitClass(filter, relations, collection, entity);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="filter">Filter.</param>
		/// <param name="relations">Relations.</param>
		/// <param name="collection">Collection.</param>
		/// <param name="entity">Entity.</param>
		private void InitClass(IPredicate filter, IRelationCollection relations, IEntityCollection collection, IEntity entity)
		{
			_filter = filter;
			_relations = relations;
			_collection = collection;
			_entity = entity;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets entity
		/// </summary>
		public IEntity Entity
		{
			get
			{
				return _entity;
			}
			set
			{
				_entity = value;
			}
		}

		/// <summary>
		/// Gets / sets filter
		/// </summary>
		public IPredicate Filter
		{
			get
			{
				return _filter;
			}
			set
			{
				_filter = value;
			}
		}

		/// <summary>
		/// Gets / sets relations
		/// </summary>
		public IRelationCollection Relations
		{
			get
			{
				return _relations;
			}
			set
			{
				_relations = value;
			}
		}

		/// <summary>
		/// Gets / sets collection
		/// </summary>
		public IEntityCollection Collection
		{
			get
			{
				return _collection;
			}
			set
			{
				_collection = value;
			}
		}
		#endregion
	}



	/// <summary>
	/// unit of work element to store in the delete multi calls to execute
	/// </summary>
	[Serializable]
	internal class UnitOfWorkDeleteMultiElement
	{
		#region Class Member Declarations
		private IPredicate				_filter;
		private IRelationCollection		_relations;
		private IEntityCollection		_collection;
		#endregion


		/// <summary>
		/// CTor. 
		/// </summary>
		public UnitOfWorkDeleteMultiElement()
		{
			InitClass(null, null, null);
		}

		/// <summary>
		/// Creates a new <see cref="UnitOfWorkDeleteMultiElement"/> instance.
		/// </summary>
		/// <param name="filter">Filter.</param>
		/// <param name="relations">Relations.</param>
		/// <param name="collection">Collection.</param>
		public UnitOfWorkDeleteMultiElement(IPredicate filter, IRelationCollection relations, IEntityCollection collection)
		{
			InitClass(filter, relations, collection);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="filter">Filter.</param>
		/// <param name="relations">Relations.</param>
		/// <param name="collection">Collection.</param>
		private void InitClass(IPredicate filter, IRelationCollection relations, IEntityCollection collection)
		{
			_filter = filter;
			_relations = relations;
			_collection = collection;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets filter
		/// </summary>
		public IPredicate Filter
		{
			get
			{
				return _filter;
			}
			set
			{
				_filter = value;
			}
		}

		/// <summary>
		/// Gets / sets relations
		/// </summary>
		public IRelationCollection Relations
		{
			get
			{
				return _relations;
			}
			set
			{
				_relations = value;
			}
		}

		/// <summary>
		/// Gets / sets collection
		/// </summary>
		public IEntityCollection Collection
		{
			get
			{
				return _collection;
			}
			set
			{
				_collection = value;
			}
		}
		#endregion
	}


	/// <summary>
	/// unit of work element to store in the unit of work collections for insert/update/delete. 
	/// </summary>
	[Serializable]
	public class UnitOfWorkElement
	{
		#region Class Member Declarations
		private IPredicate				_restriction;
		private bool					_recurse;
		private IEntity					_entity;
		#endregion


		/// <summary>
		/// CTor. 
		/// </summary>
		public UnitOfWorkElement()
		{
			InitClass(null, null, false);
		}

		/// <summary>
		/// Creates a new <see cref="UnitOfWorkElement"/> instance.
		/// </summary>
		/// <param name="entity">entity involved</param>
		public UnitOfWorkElement(IEntity entity)
		{
			InitClass(entity, null, false);
		}


		/// <summary>
		/// Creates a new <see cref="UnitOfWorkElement"/> instance.
		/// </summary>
		/// <param name="entity">entity involved</param>
		/// <param name="restriction">Restriction.</param>
		public UnitOfWorkElement(IEntity entity, IPredicate restriction)
		{
			InitClass(entity, restriction, false);
		}


		/// <summary>
		/// Creates a new <see cref="UnitOfWorkElement"/> instance.
		/// </summary>
		/// <param name="entity">entity involved</param>
		/// <param name="restriction">Restriction.</param>
		/// <param name="recurse">recurse query. Ignored in Delete queries</param>
		public UnitOfWorkElement(IEntity entity, IPredicate restriction, bool recurse)
		{
			InitClass(entity, restriction, recurse);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="entity">entity involved</param>
		/// <param name="restriction">Restriction.</param>
		/// <param name="recurse">Recurse.</param>
		private void InitClass(IEntity entity, IPredicate restriction, bool recurse)
		{
			_entity = entity;
			_restriction = restriction;
			_recurse = recurse;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets recurse
		/// </summary>
		public bool Recurse
		{
			get
			{
				return _recurse;
			}
			set
			{
				_recurse = value;
			}
		}

		/// <summary>
		/// Gets / sets restriction
		/// </summary>
		public IPredicate Restriction
		{
			get
			{
				return _restriction;
			}
			set
			{
				_restriction = value;
			}
		}

		/// <summary>
		/// Gets / sets entity
		/// </summary>
		public IEntity Entity
		{
			get
			{
				return _entity;
			}
			set
			{
				_entity = value;
			}
		}
		#endregion
	}


	/// <summary>
	/// unit of work callback element to store in the unit of work collections for callbacks. 
	/// </summary>
	[Serializable]
	internal class UnitOfWorkCallBackElement
	{
		#region Class Member Declarations
		private Delegate		_delegateToCall;
		private object[]		_parameters;
		private bool			_passInTransaction;
		#endregion

		/// <summary>
		/// CTor. 
		/// </summary>
		public UnitOfWorkCallBackElement()
		{
			InitClass(null, null, true);
		}

		/// <summary>
		/// Creates a new <see cref="UnitOfWorkCallBackElement"/> instance.
		/// </summary>
		/// <param name="delegateToCall">Delegate to call.</param>
		/// <param name="passInTransaction">When true, the routine assumes that the last parameter specified is the placeholder for the transaction to use (default). 
		/// When false, it won't pass in a transaction and will assume the callback has to run outside the current transaction scope</param>
		/// <param name="parameters">Parameters.</param>
		public UnitOfWorkCallBackElement(Delegate delegateToCall, bool passInTransaction, params object[] parameters)
		{
			InitClass(delegateToCall, parameters, passInTransaction);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="delegateToCall">Delegate to call.</param>
		/// <param name="parameters">Parameters.</param>
		/// <param name="passInTransaction"></param>
		private void InitClass(Delegate delegateToCall, object[] parameters, bool passInTransaction)
		{
			_delegateToCall = delegateToCall;
			_parameters = parameters;
			_passInTransaction = passInTransaction;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets passInTransaction
		/// </summary>
		public bool PassInTransaction
		{
			get
			{
				return _passInTransaction;
			}
			set
			{
				_passInTransaction = value;
			}
		}

		/// <summary>
		/// Gets / sets delegateToCall
		/// </summary>
		public Delegate DelegateToCall
		{
			get
			{
				return _delegateToCall;
			}
			set
			{
				_delegateToCall = value;
			}
		}

		/// <summary>
		/// Gets / sets parameters
		/// </summary>
		public object[] Parameters
		{
			get
			{
				return _parameters;
			}
			set
			{
				_parameters = value;
			}
		}

		#endregion
	}


	/// <summary>
	/// unit of work element to store in the unit of work collections for insert/update/delete. 
	/// </summary>
	[Serializable]
	public class UnitOfWorkCollectionElement
	{
		#region Class Member Declarations
		private bool					_recurse;
		private IEntityCollection		_collection;
		#endregion


		/// <summary>
		/// CTor. 
		/// </summary>
		public UnitOfWorkCollectionElement()
		{
			InitClass(null, false);
		}

		/// <summary>
		/// Creates a new <see cref="UnitOfWorkCollectionElement"/> instance.
		/// </summary>
		/// <param name="collection">entity collection involved</param>
		public UnitOfWorkCollectionElement(IEntityCollection collection)
		{
			InitClass(collection, false);
		}


		/// <summary>
		/// Creates a new <see cref="UnitOfWorkCollectionElement"/> instance.
		/// </summary>
		/// <param name="collection">entity collection involved</param>
		/// <param name="recurse">recurse query. Ignored in Delete queries</param>
		public UnitOfWorkCollectionElement(IEntityCollection collection, bool recurse)
		{
			InitClass(collection, recurse);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="collection">entity collection involved</param>
		/// <param name="recurse">Recurse.</param>
		private void InitClass(IEntityCollection collection, bool recurse)
		{
			_collection = collection;
			_recurse = recurse;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets recurse
		/// </summary>
		public bool Recurse
		{
			get
			{
				return _recurse;
			}
			set
			{
				_recurse = value;
			}
		}

		/// <summary>
		/// Gets collection
		/// </summary>
		public IEntityCollection Collection
		{
			get
			{
				return _collection;
			}
		}


		#endregion
	}


	/// <summary>
	/// Typed collection which is used to return the UnitOfWorkCollectionElement elements in a UnitOfWork2 object
	/// </summary>
	public class UnitOfWorkCollectionElementCollection : ArrayList
	{
		/// <summary>
		/// Creates a new <see cref="UnitOfWorkCollectionElementCollection"/> instance.
		/// </summary>
		/// <param name="c">C.</param>
		public UnitOfWorkCollectionElementCollection(ICollection c):base(c)
		{
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the <see cref="UnitOfWorkCollectionElement"/> at the specified index.
		/// </summary>
		/// <value></value>
		public new UnitOfWorkCollectionElement this[int index]
		{
			get
			{
				return (UnitOfWorkCollectionElement)base[index];
			}
			set
			{
				base[index] = value;
			}
		}
		#endregion
	}


	/// <summary>
	/// Typed collection which is used to return the UnitOfWorkElement elements in a UnitOfWork2 object
	/// </summary>
	public class UnitOfWorkElementCollection : ArrayList
	{
		/// <summary>
		/// Creates a new <see cref="UnitOfWorkElementCollection"/> instance.
		/// </summary>
		/// <param name="c">C.</param>
		public UnitOfWorkElementCollection(ICollection c):base(c)
		{
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the <see cref="UnitOfWorkElement"/> at the specified index.
		/// </summary>
		/// <value></value>
		public new UnitOfWorkElement this[int index]
		{
			get
			{
				return (UnitOfWorkElement)base[index];
			}
			set
			{
				base[index] = value;
			}
		}
		#endregion
	}
}
