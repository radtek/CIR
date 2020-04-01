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
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// UnitOfWork2 class. Can collect actions to perform on the entities/entity collections specified. 
	/// Will not perform these actions until Commit(transaction) is called. A UnitOfWork is meant to make development easier.
	/// It will not prohibit the developer to persist the actions also using other methods. 
	/// Adapter Specific.
	/// </summary>
	[Serializable]
	public class UnitOfWork2 : ISerializable
	{
		#region Class Member Declarations
		private	ArrayList	_entitiesToDelete, _collectionsToDelete,
							_callBacksPreInsert, _callBacksPreUpdate, _callBacksPreDelete, _callBacksPostDelete,
							_deleteEntitiesDirectlyCalls, _updateEntitiesDirectlyCalls;
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
		public UnitOfWork2()
		{
			InitClass(null);
			_optimizedSerialization = true;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="UnitOfWork2"/> class.
		/// </summary>
		/// <param name="commitOrder">The commit order of the various blocks in the unit of work object.</param>
		public UnitOfWork2(ArrayList commitOrder)
		{
			InitClass(commitOrder);
			_optimizedSerialization = true;
		}


		/// <summary>
		/// CTor for deserialization
		/// </summary>
		/// <param name="info">Info.</param>
		/// <param name="context">Context.</param>
		public UnitOfWork2(SerializationInfo info, StreamingContext context)
		{
			_commitOrder = (ArrayList)info.GetValue("_commitOrder", typeof(ArrayList));
			if(SerializationHelper.Optimization == SerializationOptimization.None)
			{
				_optimizedSerialization = info.GetBoolean("_optimizedSerialization");
				_entitiesToSave = (ArrayList)info.GetValue("_entitiesToSave", typeof(ArrayList));
				_entitiesToDelete = (ArrayList)info.GetValue("_entitiesToDelete", typeof(ArrayList));
				_collectionsToDelete = (ArrayList)info.GetValue("_collectionsToDelete", typeof(ArrayList));
				_objectIDsToDelete = (Hashtable)info.GetValue("_objectIDsToDelete", typeof(Hashtable));
				_objectIDsToSave = (Hashtable)info.GetValue("_objectIDsToSave", typeof(Hashtable));
				_callBacksPreInsert = (ArrayList)info.GetValue("_callBacksPreInsert", typeof(ArrayList));
				_callBacksPreUpdate = (ArrayList)info.GetValue("_callBacksPreUpdate", typeof(ArrayList));
				_callBacksPreDelete = (ArrayList)info.GetValue("_callBacksPreDelete", typeof(ArrayList));
				_callBacksPostDelete =(ArrayList)info.GetValue("_callBacksPostDelete", typeof(ArrayList));
				_deleteEntitiesDirectlyCalls = (ArrayList)info.GetValue("_deleteEntitiesDirectlyCalls", typeof(ArrayList));
				_updateEntitiesDirectlyCalls = (ArrayList)info.GetValue("_updateEntitiesDirectlyCalls", typeof(ArrayList));
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
			else
			{
				InitClass(null);
				SerializationHelper.Deserialize(this, info, context);

				_callBacksPreInsert = (ArrayList)info.GetValue("_callBacksPreInsert", typeof(ArrayList));
				_callBacksPreUpdate = (ArrayList)info.GetValue("_callBacksPreUpdate", typeof(ArrayList));
				_callBacksPreDelete = (ArrayList)info.GetValue("_callBacksPreDelete", typeof(ArrayList));
				_callBacksPostDelete = (ArrayList)info.GetValue("_callBacksPostDelete", typeof(ArrayList));
				_deleteEntitiesDirectlyCalls = (ArrayList)info.GetValue("_deleteEntitiesDirectlyCalls", typeof(ArrayList));
				_updateEntitiesDirectlyCalls = (ArrayList)info.GetValue("_updateEntitiesDirectlyCalls", typeof(ArrayList));
			}
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
			if(SerializationHelper.Optimization == SerializationOptimization.None)
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
							UnitOfWorkElement2 newElement = new UnitOfWorkElement2((IEntity2)element.Entity, null, element.RefetchAfterAction, false);
							objectIDsToSave.Add(element.Entity.ObjectID, newElement);
							entitiesToSave.Add(newElement);
						}
					}

					foreach(ActionQueueElement element in _entitiesToUpdate)
					{
						if(!objectIDsToSave.ContainsKey(element.Entity.ObjectID))
						{
							UnitOfWorkElement2 newElement = new UnitOfWorkElement2((IEntity2)element.Entity, element.AdditionalUpdateFilter, element.RefetchAfterAction, false);
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
				info.AddValue("_deleteEntitiesDirectlyCalls", _deleteEntitiesDirectlyCalls, typeof(ArrayList));
				info.AddValue("_updateEntitiesDirectlyCalls", _updateEntitiesDirectlyCalls, typeof(ArrayList));
				info.AddValue("_objectIDsToDelete", _objectIDsToDelete, typeof(Hashtable));
			}
			else
			{
				SerializationHelper.Serialize(this, info, context);

				// additional non-optimizable data.
				info.AddValue("_callBacksPreInsert", _callBacksPreInsert);
				info.AddValue("_callBacksPreUpdate", _callBacksPreUpdate);
				info.AddValue("_callBacksPreDelete", _callBacksPreDelete);
				info.AddValue("_callBacksPostDelete", _callBacksPostDelete);
				info.AddValue("_deleteEntitiesDirectlyCalls", _deleteEntitiesDirectlyCalls);
				info.AddValue("_updateEntitiesDirectlyCalls", _updateEntitiesDirectlyCalls);
			}
			info.AddValue("_commitOrder", _commitOrder);
		}


		/// <summary>
		/// Gets the UnitOfWorkElement2s with the entities which are added with <see cref="AddForSave"/> and which are new, in a new UnitOfWorkElement2Collection. 
		/// To remove an entity, call <see cref="RemoveFromUoW"/>
		/// </summary>
		/// <returns>new UnitOfWorkElement2Collection with all UnitOfWorkElement2s with the entities which are added using AddForSave and which are new</returns>
		/// <remarks>Use this method to peek into the list of elements added to the UnitOfWork. Don't use this method to retrieve the exact list of
		/// entities which have been inserted/will be inserted by the UnitOfWork, use <see cref="GetUpdateQueue"/> instead</remarks>
		public UnitOfWorkElement2Collection GetEntityElementsToInsert()
		{
			ArrayList toReturn = new ArrayList();
			foreach(UnitOfWorkElement2 element in _entitiesToSave)
			{
				if(element.Entity.IsNew)
				{
					toReturn.Add(element);
				}
			}
			return new UnitOfWorkElement2Collection(toReturn);
		}


		/// <summary>
		/// Gets the UnitOfWorkElement2s with the entities which are added with <see cref="AddForSave"/> and which are not new, in a new UnitOfWorkElement2Collection. 
		/// To remove an entity, call <see cref="RemoveFromUoW"/>
		/// </summary>
		/// <returns>new UnitOfWorkElement2Collection with all UnitOfWorkElement2s with the entities which are added using AddForSave and which are not new</returns>
		/// <remarks>Use this method to peek into the list of elements added to the UnitOfWork. Don't use this method to retrieve the exact list of
		/// entities which have been updated/will be updated by the UnitOfWork, use <see cref="GetUpdateQueue"/> instead</remarks>
		public UnitOfWorkElement2Collection GetEntityElementsToUpdate()
		{
			ArrayList toReturn = new ArrayList();
			foreach(UnitOfWorkElement2 element in _entitiesToSave)
			{
				if(!element.Entity.IsNew)
				{
					toReturn.Add(element);
				}
			}
			return new UnitOfWorkElement2Collection(toReturn);
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
		/// Gets the UnitOfWorkElement2s with the entities which are added with <see cref="AddForDelete"/>, in a new UnitOfWorkElement2Collection. 
		/// To remove an entity, call <see cref="RemoveFromUoW"/>
		/// </summary>
		/// <returns>new UnitOfWorkElement2Collection with all UnitOfWorkElement2s with the entities which are added using AddForDelete</returns>
		public UnitOfWorkElement2Collection GetEntityElementsToDelete()
		{
			return new UnitOfWorkElement2Collection(_entitiesToDelete);
		}


		/// <summary>
		/// Gets the UnitOfWorkCollectionElement2s with the collections which are added with <see cref="AddCollectionForSave"/>, in a new UnitOfWorkCollectionElement2Collection. 
		/// To remove a collection, call <see cref="RemoveCollectionFromUoW"/>
		/// </summary>
		/// <returns>new UnitOfWorkCollectionElement2Collection with all UnitOfWorkCollectionElement2s with the entities which are added using AddCollectionForSave</returns>
		public UnitOfWorkCollectionElement2Collection GetCollectionElementsToSave()
		{
			return new UnitOfWorkCollectionElement2Collection(_collectionsToSave);
		}


		/// <summary>
		/// Gets the UnitOfWorkCollectionElement2s with the collections which are added with <see cref="AddCollectionForDelete"/>, in a new UnitOfWorkCollectionElement2Collection. 
		/// To remove a collection, call <see cref="RemoveCollectionFromUoW"/>
		/// </summary>
		/// <returns>new UnitOfWorkCollectionElement2Collection with all UnitOfWorkCollectionElement2s with the entities which are added using AddCollectionForDelete</returns>
		public UnitOfWorkCollectionElement2Collection GetCollectionElementsToDelete()
		{
			return new UnitOfWorkCollectionElement2Collection(_collectionsToDelete);
		}


		/// <summary>
		/// Adds the passed in entity for saving. No refetching will be applied.
		/// </summary>
		/// <param name="entityToSave">The entity2 to save via this unit of work</param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (already added for a similar action)</returns>
		public bool AddForSave(IEntity2 entityToSave)
		{
			return AddForSave(entityToSave, null, false, true);
		}

		
		/// <summary>
		/// Adds the passed in entity for saving. No refetching will be applied.
		/// </summary>
		/// <param name="entityToSave">The entity to save via this unit of work</param>
		/// <param name="restriction">Filter to apply during save (ignored when the entity is new). This restriction will be AND-ed
		/// with the restriction constructed by a ConcurrencyPredicateFactory instance in entityToSave (if applicable).</param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (already added for a similar action)</returns>
		public bool AddForSave(IEntity2 entityToSave, IPredicateExpression restriction)
		{
			return AddForSave(entityToSave, restriction, false, true);
		}


		/// <summary>
		/// Adds the passed in entity for saving. 
		/// </summary>
		/// <param name="entityToSave">The entity to save via this unit of work</param>
		/// <param name="refetch">When true, it will refetch the entity saved after the save action.</param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (already added for a similar action)</returns>
		public bool AddForSave(IEntity2 entityToSave, bool refetch)
		{
			return AddForSave(entityToSave, null, refetch, true);
		}


		/// <summary>
		/// Adds the passed in entity for saving. 
		/// </summary>
		/// <param name="entityToSave">The entity to save via this unit of work</param>
		/// <param name="restriction">Filter to apply during save (ignored when the entity is new). This restriction will be AND-ed
		/// with the restriction constructed by a ConcurrencyPredicateFactory instance in entityToSave (if applicable).</param>
		/// <param name="refetch">When true, it will refetch the entity saved after the save action. </param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (already added for a similar action)</returns>
		public bool AddForSave(IEntity2 entityToSave, IPredicateExpression restriction, bool refetch)
		{
			return AddForSave(entityToSave, restriction, refetch, true);
		}


		/// <summary>
		/// Adds the passed in entity for saving. 
		/// </summary>
		/// <param name="entityToSave">The entity to save via this unit of work</param>
		/// <param name="restriction">Filter to apply during save (ignored when the entity is new). This restriction will be AND-ed
		/// with the restriction constructed by a ConcurrencyPredicateFactory instance in entityToSave (if applicable).</param>
		/// <param name="refetch">When true, it will refetch the entity saved after the save action.</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by this entity also.</param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (already added for a similar action)</returns>
		public virtual bool AddForSave(IEntity2 entityToSave, IPredicateExpression restriction, bool refetch, bool recurse)
		{
			bool accept = false;
			UnitOfWorkElement2 newElement = null;
			// simply store the entity in the save list:
			if(!_objectIDsToSave.ContainsKey(entityToSave.ObjectID))
			{
				// accept
				accept = true;
				newElement = new UnitOfWorkElement2(entityToSave, restriction, refetch, recurse);
				_objectIDsToSave.Add(entityToSave.ObjectID, newElement);
				_entitiesToSave.Add(newElement);
			}

			return accept;
		}


		/// <summary>
		/// Removes the specified entity from this UnitOfWork. If the entity is in an added collection, the entity will later on still be added. 
		/// </summary>
		/// <param name="entityToRemove">Entity to remove.</param>
		public virtual void RemoveFromUoW(IEntity2 entityToRemove)
		{
			if(_objectIDsToDelete.ContainsKey(entityToRemove.ObjectID))
			{
				UnitOfWorkElement2 element = (UnitOfWorkElement2)_objectIDsToDelete[entityToRemove.ObjectID];
				_objectIDsToDelete.Remove(entityToRemove.ObjectID);
				_entitiesToDelete.Remove(element);
				return;
			}

			if(_objectIDsToSave.ContainsKey(entityToRemove.ObjectID))
			{
				UnitOfWorkElement2 element = (UnitOfWorkElement2)_objectIDsToSave[entityToRemove.ObjectID];
				_objectIDsToSave.Remove(entityToRemove.ObjectID);
				_entitiesToSave.Remove(element);
				return;
			}
		}


		/// <summary>
		/// Removes the specified entity collection from this UnitOfWork. 
		/// </summary>
		/// <param name="collectionToRemove">Entity collection to remove.</param>
		public virtual void RemoveCollectionFromUoW(IEntityCollection2 collectionToRemove)
		{
			ArrayList elementsToRemove = new ArrayList();
			foreach(UnitOfWorkCollectionElement2 element in _collectionsToSave)
			{
				if(element.Collection==collectionToRemove)
				{
					elementsToRemove.Add(element);
				}
			}

			foreach(UnitOfWorkCollectionElement2 element in elementsToRemove)
			{
				_collectionsToSave.Remove(element);
			}

			elementsToRemove.Clear();

			foreach(UnitOfWorkCollectionElement2 element in _collectionsToDelete)
			{
				if(element.Collection==collectionToRemove)
				{
					elementsToRemove.Add(element);
				}
			}

			foreach(UnitOfWorkCollectionElement2 element in elementsToRemove)
			{
				_collectionsToDelete.Remove(element);
			}
		}


		/// <summary>
		/// Adds the collection with entities for saving. When the UnitOfWork is committed, the entities in the collection are added to the
		/// correct process bins to make sure the order is correct. No recursion and no refetch are done for these entities.
		/// </summary>
		/// <param name="collectionToSave">collection with entities to be added for saving</param>
		public void AddCollectionForSave(IEntityCollection2 collectionToSave)
		{
			AddCollectionForSave(collectionToSave, false, false);
		}


		/// <summary>
		/// Adds the collection with entities for saving. When the UnitOfWork is committed, the entities in the collection are added to the
		/// correct process bins to make sure the order is correct.
		/// </summary>
		/// <param name="collectionToSave">collection with entities to be added for saving</param>
		/// <param name="refetch">When true, it will refetch all entities saved after the save action.</param>
		/// <param name="recurse">When true, the entities in the collection will be saved recursively.</param>
		public virtual void AddCollectionForSave(IEntityCollection2 collectionToSave, bool refetch, bool recurse)
		{
			_collectionsToSave.Add(new UnitOfWorkCollectionElement2(collectionToSave, refetch, recurse));
		}


		/// <summary>
		/// Adds the passed in entity for deletion. 
		/// </summary>
		/// <param name="entityToDelete">The entity to delete via this unit of work</param>
		/// <returns>true if the entity is accepted, false if the entity is rejected (entity is new)</returns>
		public bool AddForDelete(IEntity2 entityToDelete)
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
		public virtual bool AddForDelete(IEntity2 entityToDelete, IPredicateExpression restriction)
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
		internal bool AddForDelete(IEntity2 entityToDelete, IPredicateExpression restriction, bool append)
		{
			bool accept = false;
			UnitOfWorkElement2 newElement = null;
			if(!entityToDelete.IsNew)
			{
				if(!_objectIDsToDelete.ContainsKey(entityToDelete.ObjectID))
				{
					// accept
					accept = true;
					newElement = new UnitOfWorkElement2(entityToDelete, restriction);
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
					UnitOfWorkElement2 element = (UnitOfWorkElement2)_objectIDsToSave[entityToDelete.ObjectID];
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
		public virtual void AddCollectionForDelete(IEntityCollection2 collectionToDelete)
		{
			_collectionsToDelete.Add(new UnitOfWorkCollectionElement2(collectionToDelete));
		}


		/// <summary>
		/// Adds the call back passed in, to the slot specified with the parameters specified. 
		/// </summary>
		/// <param name="delegateToCall">Delegate to call.</param>
		/// <param name="schedulingSlot">Scheduling slot to call the delegate in.</param>
		/// <param name="parameters">Parameters to pass to the delegate.</param>
		/// <remarks>will pass in the used adapter as the last parameter to the delegate.</remarks>
		public void AddCallBack(Delegate delegateToCall, UnitOfWorkCallBackScheduleSlot schedulingSlot, params object[] parameters)
		{
			AddCallBack(delegateToCall, schedulingSlot, true, parameters);
		}


		/// <summary>
		/// Adds the call back passed in, to the slot specified with the parameters specified. 
		/// </summary>
		/// <param name="delegateToCall">Delegate to call.</param>
		/// <param name="schedulingSlot">Scheduling slot to call the delegate in.</param>
		/// <param name="passInAdapter">Flag to tell the Commit routine to pass the used adapter object as the last parameter to the delegate (true, default)
		/// or not (false).</param>
		/// <param name="parameters">Parameters to pass to the delegate. If you've specified true for passInAdapter,
		/// the adapter object used during commit will be passed in as the last parameter.</param>
		public virtual void AddCallBack(Delegate delegateToCall, UnitOfWorkCallBackScheduleSlot schedulingSlot, bool passInAdapter, params object[] parameters)
		{
#if CF
			throw new NotSupportedException("Not supported on Compact Framework");
#else
			UnitOfWorkCallBackElement2 element = new UnitOfWorkCallBackElement2(delegateToCall, passInAdapter, parameters);
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
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "UnitOfWork2.Reset", "Method Enter");

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
			_deleteEntitiesDirectlyCalls.Clear();
			_updateEntitiesDirectlyCalls.Clear();

			_deleteEntitiesDirectlyCalls = new ArrayList();
			_updateEntitiesDirectlyCalls = new ArrayList();
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

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "UnitOfWork2.Reset", "Method Exit");
		}


		/// <summary>
		/// Adds a DeleteEntitiesDirectly call to be scheduled during Commit. It is called right after the last entity has been deleted but before the post delete
		/// callbacks are called.
		/// </summary>
		/// <param name="entityName">The name of the entity to retrieve persistence information. For example "CustomerEntity". This name can be retrieved from an existing entity's LLBLGenProEntityName property.</param>
		/// <param name="filterBucket">filter information to filter out the entities to delete</param>
		/// <remarks>the method is called on the adapter passed in to Commit.
		/// <br/>
		/// This overload doesn't use the DataAccessAdapter.DeleteEntitiesDirectly overload which performs authorization and auditing as well. 
		/// If you need authorization and/or auditing, please use the overload of AddDeleteEntitiesDirectlyCall which accepts a type.
		/// </remarks>
		public void AddDeleteEntitiesDirectlyCall(string entityName, IRelationPredicateBucket filterBucket)
		{
			UnitOfWorkDeleteEntitiesDirectlyElement element = new UnitOfWorkDeleteEntitiesDirectlyElement(filterBucket, entityName);
			_deleteEntitiesDirectlyCalls.Add(element);
		}


		/// <summary>
		/// Adds a DeleteEntitiesDirectly call to be scheduled during Commit. It is called right after the last entity has been deleted but before the post delete
		/// callbacks are called.
		/// </summary>
		/// <param name="typeOfEntity">The type of the entity to delete</param>
		/// <param name="filterBucket">filter information to filter out the entities to delete</param>
		/// <remarks>the method is called on the adapter passed in to Commit.
		/// <br/>
		/// This overload uses the DataAccessAdapter.DeleteEntitiesDirectly overload which performs authorization as well. 
		/// </remarks>
		public void AddDeleteEntitiesDirectlyCall(Type typeOfEntity, IRelationPredicateBucket filterBucket)
		{
			UnitOfWorkDeleteEntitiesDirectlyElement element = new UnitOfWorkDeleteEntitiesDirectlyElement(filterBucket, typeOfEntity);
			_deleteEntitiesDirectlyCalls.Add(element);
		}


		/// <summary>
		/// Adds an UpdateEntitiesDirectly call to be scheduled during Commit. It is called right after the last entity has been updated but before the pre delete
		/// callbacks are called.
		/// </summary>
		/// <param name="entityWithNewValues">Entity object which contains the new values for the entities of the same type and which match the filter in filterBucket. Only fields which are changed are updated.</param>
		/// <param name="filterBucket">filter information to filter out the entities to update. </param>
		/// <remarks>the method is called on the adapter passed in to Commit.</remarks>
		public void AddUpdateEntitiesDirectlyCall(IEntity2 entityWithNewValues,	IRelationPredicateBucket filterBucket)
		{
			UnitOfWorkUpdateEntitiesDirectlyElement element = new UnitOfWorkUpdateEntitiesDirectlyElement(filterBucket, entityWithNewValues);
			_updateEntitiesDirectlyCalls.Add(element);
		}


		/// <summary>
		/// Commits this unit of work. It will first add all entities in the added collections to the correct bins, then it will start
		/// by first inserting all new entities, then saving all updates and then performing the deletes. 
		/// </summary>
		/// <param name="adapterToUse">Adapter to use. It will start a new transaction if no transaction is in progress.</param>
		/// <remarks>If no transaction is in progress on the passed in adapter, this unit of work object will autocommit the transaction started by
		/// this unit of work object.</remarks>
		/// <exception cref="ArgumentNullException">when adapterToUse is null</exception>
		/// <returns>The total # of entities affected by all actions performed in the Commit method</returns>
		public int Commit(IDataAccessAdapter adapterToUse)
		{
			return Commit(adapterToUse, !adapterToUse.IsTransactionInProgress);
		}


		/// <summary>
		/// Commits this unit of work. It will first add all entities in the added collections to the correct bins, then it will start
		/// by first inserting all new entities, then saving all updates and then performing the deletes. 
		/// </summary>
		/// <param name="adapterToUse">Adapter to use. It will start a new transaction if no transaction is in progress.</param>
		/// <param name="autoCommit">if true, it will commit/rollback the transaction passed in using the following rules:
		/// - if no exception is thrown: commit
		/// - if an exception is thrown: rollback</param>
		/// <exception cref="ArgumentNullException">when adapterToUse is null</exception>
		/// <returns>The total # of entities affected by all actions performed in the Commit method</returns>
		public virtual int Commit(IDataAccessAdapter adapterToUse, bool autoCommit)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "UnitOfWork2.Commit(2)", "Method Enter");

			if(adapterToUse==null)
			{
				throw new ArgumentNullException("adapterToUse", "You have to specify a valid adapter object");
			}

			if((_commitOrder==null) || (_commitOrder.Count<=0))
			{
				// commit order is cleared. Error out.
				throw new ORMGeneralOperationException("CommitOrder is empty. The commit has been aborted to prevent dangling transactions. You shouldn't clear the CommitOrder of a unit of work object.");
			}

			int totalAmountAffected = 0;

			if(adapterToUse.IsTransactionInProgress)
			{
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, String.Format("\tTransaction to use: {0}. AutoCommit: {1}", adapterToUse.TransactionName, autoCommit.ToString()));
			}

			// collections are inserted at the front of the queue. However to keep the order in which they're added, process the collections from the back
			for (int i = _collectionsToDelete.Count-1;i>=0; i--)
			{
				UnitOfWorkCollectionElement2 currentElement = (UnitOfWorkCollectionElement2)_collectionsToDelete[i];
				for (int j = 0; j < currentElement.Collection.Count; j++)
				{
					IEntity2 currentEntity = currentElement.Collection[j];
					AddForDelete(currentEntity, null, false);
				}
			}

			// construct the process queues so they can be processed after this.
			ConstructSaveProcessQueues();

			////////////////
			// process the actual actions
			////////////////
			int actionTotal = 0;
			Hashtable processedBlocks = new Hashtable();
			try
			{
				if(!adapterToUse.IsTransactionInProgress)
				{
					adapterToUse.StartTransaction(IsolationLevel.ReadCommitted, "UoWCommit");
				}

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
#if !CF
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling Pre Insert CallBacks.");
							foreach(UnitOfWorkCallBackElement2 element in _callBacksPreInsert)
							{
								element.DelegateToCall.DynamicInvoke(ConstructParameters(element.Parameters, adapterToUse, element.PassInAdapter));
							}
#endif
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandle Inserts.");
							bool saveResult = ((DataAccessAdapterBase)adapterToUse).PersistQueue(_entitiesToInsert, true, out actionTotal);
							totalAmountAffected+=actionTotal;
							break;
						case UnitOfWorkBlockType.Updates:
#if !CF
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling Pre Update CallBacks.");
							foreach(UnitOfWorkCallBackElement2 element in _callBacksPreUpdate)
							{
								element.DelegateToCall.DynamicInvoke(ConstructParameters(element.Parameters, adapterToUse, element.PassInAdapter));
							}
#endif
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandle Updates.");
							saveResult = ((DataAccessAdapterBase)adapterToUse).PersistQueue(_entitiesToUpdate, false, out actionTotal);
							totalAmountAffected+=actionTotal;
							break;
						case UnitOfWorkBlockType.UpdatesPerformedDirectly:
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling UpdateEntitiesDirectly Calls.");
							foreach(UnitOfWorkUpdateEntitiesDirectlyElement element in _updateEntitiesDirectlyCalls)
							{
								totalAmountAffected+= adapterToUse.UpdateEntitiesDirectly(element.Entity, element.Filter);
							}
							break;
						case UnitOfWorkBlockType.Deletes:
#if !CF
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling Pre Delete CallBacks.");
							foreach(UnitOfWorkCallBackElement2 element in _callBacksPreDelete)
							{
								element.DelegateToCall.DynamicInvoke(ConstructParameters(element.Parameters, adapterToUse, element.PassInAdapter));
							}
#endif
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandle Deletes.");
							for (int i = 0; i < _entitiesToDelete.Count; i++)
							{
								UnitOfWorkElement2 currentElement = (UnitOfWorkElement2)_entitiesToDelete[i];
								IPredicateExpression restrictionFilter = ConstructRestrictionFilter(currentElement, ConcurrencyPredicateType.Delete);
								bool deleteResult = adapterToUse.DeleteEntity(currentElement.Entity, restrictionFilter);
								if(!deleteResult)
								{
									throw new ORMConcurrencyException("During the commit of the UnitOfWork class, the delete action on an entity failed. The entity which failed is enclosed.", currentElement.Entity);
								}
								totalAmountAffected++;
							}
#if !CF
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling Post Delete CallBacks.");
							foreach(UnitOfWorkCallBackElement2 element in _callBacksPostDelete)
							{
								element.DelegateToCall.DynamicInvoke(ConstructParameters(element.Parameters, adapterToUse, element.PassInAdapter));
							}
#endif
							break;
						case UnitOfWorkBlockType.DeletesPerformedDirectly:
							TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, "\tHandling DeleteEntitiesDirectly Calls.");
							foreach(UnitOfWorkDeleteEntitiesDirectlyElement element in _deleteEntitiesDirectlyCalls)
							{
								if(element.UseNameOverload)
								{
									totalAmountAffected+= adapterToUse.DeleteEntitiesDirectly(element.EntityName, element.Filter);
								}
								else
								{
									totalAmountAffected+= adapterToUse.DeleteEntitiesDirectly(element.TypeOfEntity, element.Filter);
								}
							}
							break;
					}
				}

				Reset();

				if(autoCommit)
				{
					adapterToUse.Commit();
				}
				return totalAmountAffected;
			}
			catch
			{
				if(autoCommit)
				{
					adapterToUse.Rollback();
				}

				throw;
			}
			finally
			{
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "UnitOfWork2.Commit(2)", "Method Exit");
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
			foreach(UnitOfWorkCollectionElement2 currentElement in _collectionsToSave)
			{
				foreach(IEntity2 currentEntity in currentElement.Collection)
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
										(((EntityBase2)currentEntity).GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntityHierarchy)
									)
								)
							)
						)
					)
					{
						UnitOfWorkElement2 newElement = new UnitOfWorkElement2(currentEntity, null, currentElement.Refetch, currentElement.Recurse);
						tmpObjectIDsToSave.Add(currentEntity.ObjectID, newElement);
						elementsToProcess.Add(newElement);
					}
				}
			}

			Hashtable inQueue = new Hashtable(512);
			MergeableHashtable alreadyProcessed = new MergeableHashtable(512);
			foreach(UnitOfWorkElement2 element in elementsToProcess)
			{
				if(!inQueue.ContainsKey(element.Entity.ObjectID) && !alreadyProcessed.ContainsKey(element.Entity.ObjectID))
				{
					Hashtable entitiesInGraph = new Hashtable();
					if(element.Recurse)
					{
						graphUtils.DetermineActionQueues(element.Entity, element.Restriction, ref _entitiesToInsert, ref _entitiesToUpdate, ref inQueue, element.Refetch, out entitiesInGraph);
					}
					else
					{
						if(element.Entity.IsNew)
						{
							_entitiesToInsert.Add(new ActionQueueElement(element.Entity, null, element.Refetch));
						}
						else
						{
							if(element.Restriction!=null)
							{
								_entitiesToUpdate.Add(new ActionQueueElement(element.Entity, element.Restriction, element.Refetch));
							}
							else
							{
								_entitiesToUpdate.Add(new ActionQueueElement(element.Entity, element.Entity.GetConcurrencyPredicate(ConcurrencyPredicateType.Save), element.Refetch));
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
		/// <param name="adapterToUse"></param>
		/// <param name="passInAdapter">Pass in adapter.</param>
		private object[] ConstructParameters(object[] parameters, IDataAccessAdapter adapterToUse, bool passInAdapter)
		{
			object[] toReturn = null;
			if(passInAdapter)
			{
				toReturn = new object[parameters.Length+1];
				parameters.CopyTo(toReturn, 0);
				toReturn[toReturn.Length-1] = adapterToUse;
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
		private IPredicateExpression ConstructRestrictionFilter(UnitOfWorkElement2 element, ConcurrencyPredicateType concurrencyType)
		{
			IPredicateExpression toReturn = new PredicateExpression();
			IPredicateExpression restrictionFilter = element.Restriction;
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
		/// <param name="commitOrder">Commit order.</param>
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
			_deleteEntitiesDirectlyCalls = new ArrayList();
			_updateEntitiesDirectlyCalls = new ArrayList();
		}

#if !CF
		#region Optimized Serialization related code.
		/// <summary>
		/// Gets the serialization flags.
		/// </summary>
		/// <returns>Bitvector with flags which control what's serialized.</returns>
		internal BitVector32 GetSerializationFlags()
		{
			BitVector32 serializationFlags = new BitVector32();

			serializationFlags[SerializationHelper.UnitOfWorkHasCollectionsToDeleteMask] = (_collectionsToDelete.Count > 0);
			serializationFlags[SerializationHelper.UnitOfWorkHasCollectionsToSaveMask] = (_collectionsToSave.Count > 0);
			serializationFlags[SerializationHelper.UnitOfWorkHasEntitiesToDeleteMask] = (_entitiesToDelete.Count > 0);
			serializationFlags[SerializationHelper.UnitOfWorkHasEntitiesToSaveMask] = (_entitiesToSave.Count > 0);
			return serializationFlags;
		}


		/// <summary>
		/// Gets the list of UnitOfWorkElement2 objects for the entities to save.
		/// </summary>
		internal ArrayList EntitiesToSave
		{
			get	{ return _entitiesToSave; }
		}

		/// <summary>
		/// Gets the list of UnitOfWorkElement2 objects for the entities to delete.
		/// </summary>
		internal ArrayList EntitiesToDelete
		{
			get { return _entitiesToDelete; }
		}


		/// <summary>
		/// Gets the list of UnitOfWorkCollectionElement2 objects for the entities to save.
		/// </summary>
		internal ArrayList CollectionsToSave
		{
			get { return _collectionsToSave; }
		}


		/// <summary>
		/// Gets the list of UnitOfWorkCollectionElement2 objects for the entities to delete.
		/// </summary>
		internal ArrayList CollectionsToDelete
		{
			get { return _collectionsToDelete; }
		}
		#endregion
#endif
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
	/// unit of work element to store in the UpdateEntitiesDirectly calls to execute
	/// </summary>
	[Serializable]
	internal class UnitOfWorkUpdateEntitiesDirectlyElement
	{
		#region Class Member Declarations
		private IRelationPredicateBucket	_filter;
		private IEntity2					_entity;
		#endregion


		/// <summary>
		/// CTor. 
		/// </summary>
		public UnitOfWorkUpdateEntitiesDirectlyElement()
		{
			InitClass(null, null);
		}

		/// <summary>
		/// Creates a new <see cref="UnitOfWorkUpdateMultiElement"/> instance.
		/// </summary>
		/// <param name="filter">Filter.</param>
		/// <param name="entity">Entity.</param>
		public UnitOfWorkUpdateEntitiesDirectlyElement(IRelationPredicateBucket filter, IEntity2 entity)
		{
			InitClass(filter, entity);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="filter">Filter.</param>
		/// <param name="entity">Entity.</param>
		private void InitClass(IRelationPredicateBucket filter, IEntity2 entity)
		{
			_filter = filter;
			_entity = entity;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets entity
		/// </summary>
		public IEntity2 Entity
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
		public IRelationPredicateBucket Filter
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

		#endregion
	}



	/// <summary>
	/// unit of work element to store in the DeleteEntitiesDirectly calls to execute
	/// </summary>
	[Serializable]
	internal class UnitOfWorkDeleteEntitiesDirectlyElement
	{
		#region Class Member Declarations
		private IRelationPredicateBucket	_filter;
		private string						_entityName;
		private bool						_useNameOverload;
		private Type						_typeOfEntity;
		#endregion
		

		/// <summary>
		/// CTor. 
		/// </summary>
		public UnitOfWorkDeleteEntitiesDirectlyElement()
		{
			InitClass(null, string.Empty, null);
		}


		/// <summary>
		/// Creates a new <see cref="UnitOfWorkDeleteEntitiesDirectlyElement"/> instance.
		/// </summary>
		/// <param name="filter">Filter.</param>
		/// <param name="entityName">Name of the entity.</param>
		public UnitOfWorkDeleteEntitiesDirectlyElement(IRelationPredicateBucket filter, string entityName)
		{
			InitClass(filter, entityName, null);
		}


		/// <summary>
		/// Creates a new <see cref="UnitOfWorkDeleteEntitiesDirectlyElement"/> instance.
		/// </summary>
		/// <param name="filter">Filter.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		public UnitOfWorkDeleteEntitiesDirectlyElement(IRelationPredicateBucket filter, Type typeOfEntity)
		{
			InitClass(filter, string.Empty, typeOfEntity);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="filter">Filter.</param>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="typeOfEntity">The type of entity.</param>
		private void InitClass(IRelationPredicateBucket filter, string entityName, Type typeOfEntity)
		{
			_filter = filter;
			_entityName = entityName;
			_typeOfEntity = typeOfEntity;
			SelectOverLoad();
		}


		/// <summary>
		/// Selects the over load to use
		/// </summary>
		private void SelectOverLoad()
		{
			_useNameOverload = ((_entityName.Length > 0) && (_typeOfEntity == null));
		}



		#region Class Property Declarations
		/// <summary>
		/// Gets / sets typeOfEntity
		/// </summary>
		public Type TypeOfEntity
		{
			get
			{
				return _typeOfEntity;
			}
			set
			{
				_typeOfEntity = value;
				SelectOverLoad();
			}
		}

		/// <summary>
		/// Gets a value indicating whether [use name overload].
		/// </summary>
		/// <value><c>true</c> if [use name overload]; otherwise, <c>false</c>.</value>
		public bool UseNameOverload
		{
			get { return _useNameOverload; }
		}

		/// <summary>
		/// Gets / sets entityName
		/// </summary>
		public string EntityName
		{
			get
			{
				return _entityName;
			}
			set
			{
				_entityName = value;
				SelectOverLoad();
			}
		}


		/// <summary>
		/// Gets / sets filter
		/// </summary>
		public IRelationPredicateBucket Filter
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
		#endregion
	}


	/// <summary>
	/// unit of work element to store in the unit of work collections for insert/update/delete. 
	/// </summary>
	[Serializable]
	public class UnitOfWorkElement2
	{
		#region Class Member Declarations
		private IPredicateExpression	_restriction;
		private bool					_recurse, _refetch;
		private IEntity2				_entity;
		#endregion


		/// <summary>
		/// CTor. 
		/// </summary>
		public UnitOfWorkElement2()
		{
			InitClass(null, null, false, true);
		}

		/// <summary>
		/// Creates a new <see cref="UnitOfWorkElement"/> instance.
		/// </summary>
		/// <param name="entity">entity involved</param>
		public UnitOfWorkElement2(IEntity2 entity)
		{
			InitClass(entity, null, false, true);
		}


		/// <summary>
		/// Creates a new <see cref="UnitOfWorkElement"/> instance.
		/// </summary>
		/// <param name="entity">entity involved</param>
		/// <param name="restriction">Restriction.</param>
		public UnitOfWorkElement2(IEntity2 entity, IPredicateExpression restriction)
		{
			InitClass(entity, restriction, false, true);
		}


		/// <summary>
		/// Creates a new <see cref="UnitOfWorkElement"/> instance.
		/// </summary>
		/// <param name="entity">entity involved</param>
		/// <param name="restriction">Restriction.</param>
		/// <param name="refetch">When true, it will refetch the entity saved after the save action.</param>
		/// <param name="recurse">When true, it will save all dirty objects referenced (directly or indirectly) by this entity also.</param>
		public UnitOfWorkElement2(IEntity2 entity, IPredicateExpression restriction, bool refetch, bool recurse)
		{
			InitClass(entity, restriction, refetch, recurse);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="entity">entity involved</param>
		/// <param name="restriction">Restriction.</param>
		/// <param name="refetch"></param>
		/// <param name="recurse">Recurse.</param>
		private void InitClass(IEntity2 entity, IPredicateExpression restriction, bool refetch, bool recurse)
		{
			_entity = entity;
			_restriction = restriction;
			_recurse = recurse;
			_refetch = refetch;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets refetch
		/// </summary>
		public bool Refetch
		{
			get
			{
				return _refetch;
			}
			set
			{
				_refetch = value;
			}
		}

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
		public IPredicateExpression Restriction
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
		public IEntity2 Entity
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
	internal class UnitOfWorkCallBackElement2
	{
		#region Class Member Declarations
		private Delegate		_delegateToCall;
		private object[]		_parameters;
		private bool			_passInAdapter;
		#endregion


		/// <summary>
		/// CTor. 
		/// </summary>
		public UnitOfWorkCallBackElement2()
		{
			InitClass(null, null, true);
		}


		/// <summary>
		/// Creates a new <see cref="UnitOfWorkCallBackElement"/> instance.
		/// </summary>
		/// <param name="delegateToCall">Delegate to call.</param>
		/// <param name="passInAdapter">When true, the routine will pass in the current adapter used in commit to the delegate as the last parameter 
		/// When false, it won't pass in an adapter and will assume the callback has to run outside the current adapter's transaction scope</param>
		/// <param name="parameters">Parameters.</param>
		public UnitOfWorkCallBackElement2(Delegate delegateToCall, bool passInAdapter, params object[] parameters)
		{
			InitClass(delegateToCall, parameters, passInAdapter);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="delegateToCall">Delegate to call.</param>
		/// <param name="parameters">Parameters.</param>
		/// <param name="passInAdapter"></param>
		private void InitClass(Delegate delegateToCall, object[] parameters, bool passInAdapter)
		{
			_delegateToCall = delegateToCall;
			_parameters = parameters;
			_passInAdapter = passInAdapter;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets passInAdapter
		/// </summary>
		public bool PassInAdapter
		{
			get
			{
				return _passInAdapter;
			}
			set
			{
				_passInAdapter = value;
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
	public class UnitOfWorkCollectionElement2
	{
		#region Class Member Declarations
		private bool					_recurse, _refetch;
		private IEntityCollection2		_collection;
		#endregion


		/// <summary>
		/// CTor. 
		/// </summary>
		public UnitOfWorkCollectionElement2()
		{
			InitClass(null, false, false);
		}

		/// <summary>
		/// Creates a new <see cref="UnitOfWorkCollectionElement"/> instance.
		/// </summary>
		/// <param name="collection">entity collection involved</param>
		public UnitOfWorkCollectionElement2(IEntityCollection2 collection)
		{
			InitClass(collection, false, false);
		}

		/// <summary>
		/// Creates a new <see cref="UnitOfWorkCollectionElement"/> instance.
		/// </summary>
		/// <param name="collection">entity collection involved</param>
		/// <param name="refetch">When true, it will refetch all entities saved after the save action.</param>
		/// <param name="recurse">When true, the entities in the collection will be saved recursively.</param>
		public UnitOfWorkCollectionElement2(IEntityCollection2 collection, bool refetch, bool recurse)
		{
			InitClass(collection, refetch, recurse);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="collection">entity collection involved</param>
		/// <param name="refetch"></param>
		/// <param name="recurse">Recurse.</param>
		private void InitClass(IEntityCollection2 collection, bool refetch, bool recurse)
		{
			_collection = collection;
			_recurse = recurse;
			_refetch = refetch;
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
		public IEntityCollection2 Collection
		{
			get
			{
				return _collection;
			}
		}


		/// <summary>
		/// Gets / sets refetch
		/// </summary>
		public bool Refetch
		{
			get
			{
				return _refetch;
			}
			set
			{
				_refetch = value;
			}
		}
		#endregion
	}


	/// <summary>
	/// Typed collection which is used to return the UnitOfWorkCollectionElement2 elements in a UnitOfWork2 object
	/// </summary>
	public class UnitOfWorkCollectionElement2Collection : ArrayList
	{
		/// <summary>
		/// Creates a new <see cref="UnitOfWorkCollectionElement2Collection"/> instance.
		/// </summary>
		/// <param name="c">C.</param>
		public UnitOfWorkCollectionElement2Collection(ICollection c):base(c)
		{
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the <see cref="UnitOfWorkCollectionElement2"/> at the specified index.
		/// </summary>
		/// <value></value>
		public new UnitOfWorkCollectionElement2 this[int index]
		{
			get
			{
				return (UnitOfWorkCollectionElement2)base[index];
			}
			set
			{
				base[index] = value;
			}
		}
		#endregion
	}


	/// <summary>
	/// Typed collection which is used to return the UnitOfWorkElement2 elements in a UnitOfWork2 object
	/// </summary>
	public class UnitOfWorkElement2Collection : ArrayList
	{
		/// <summary>
		/// Creates a new <see cref="UnitOfWorkElement2Collection"/> instance.
		/// </summary>
		/// <param name="c">C.</param>
		public UnitOfWorkElement2Collection(ICollection c):base(c)
		{
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the <see cref="UnitOfWorkElement2"/> at the specified index.
		/// </summary>
		/// <value></value>
		public new UnitOfWorkElement2 this[int index]
		{
			get
			{
				return (UnitOfWorkElement2)base[index];
			}
			set
			{
				base[index] = value;
			}
		}
		#endregion
	}
}
