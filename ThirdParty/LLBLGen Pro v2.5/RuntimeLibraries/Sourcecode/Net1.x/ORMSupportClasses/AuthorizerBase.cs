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
using System.Text;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract base class for authorizers in the LLBLGen Pro system. Use this class to easily create authorizers. 
	/// </summary>
	[Serializable]
	public abstract class AuthorizerBase : IAuthorizer
	{
		/// <summary>
		/// Determines whether the caller can obtain the value for the field with the index specified from the entity type specified.
		/// </summary>
		/// <param name="entity">The entity instance to obtain the value from.</param>
		/// <param name="fieldIndex">Index of the field to obtain the value for.</param>
		/// <returns>true if the caller is allowed to obtain the value, false otherwise</returns>
		public virtual bool CanGetFieldValue(IEntityCore entity, int fieldIndex)
		{
			return true;
		}

		/// <summary>
		/// Determines whether the caller can set the value for the field with the index specified of the entity type specified.
		/// </summary>
		/// <param name="entity">The entity instance the field is located in.</param>
		/// <param name="fieldIndex">Index of the field to set the value of.</param>
		/// <returns>true if the caller is allowed to set the value, false otherwise</returns>
		public virtual bool CanSetFieldValue(IEntityCore entity, int fieldIndex)
		{
			return true;
		}

		/// <summary>
		/// Determines whether the caller is allowed to load the data into the entity instance specified.
		/// </summary>
		/// <param name="entity">The entity instance to fill with data</param>
		/// <returns>true if the caller is allowed to load the data in the entity specified.</returns>
		///<remarks>Data inside the entity is the data fetched from the db. If the method returns false, the entity will be reset with a new set of empty fields</remarks>
		public virtual bool CanLoadEntity(IEntityCore entity)
		{
			return true;
		}

		/// <summary>
		/// Determines whether the caller is allowed to save the new instance passed in.
		/// </summary>
		/// <param name="entity">The entity to save.</param>
		/// <returns>true if the caller is allowed to save the new instance passed in, false otherwise</returns>
		public virtual bool CanSaveNewEntity(IEntityCore entity)
		{
			return true;
		}

		/// <summary>
		/// Determines whether the caller is allowed to save the modified existing instance passed in.
		/// </summary>
		/// <param name="entity">The entity to save.</param>
		/// <returns>true if the caller is allowed to save the new instance passed in, false otherwise</returns>
		public virtual bool CanSaveExistingEntity(IEntityCore entity)
		{
			return true;
		}

		/// <summary>
		/// Determines whether the caller is allowed to update entities directly in the database. 
		/// </summary>
		/// <param name="entity">the entity which is passed in to the method to batch update the entities directly in the database, e.g. UpdateMulti (Selfservicing)
		/// or UpdateEntitiesDirectly (adapter)</param>
		/// <returns>true if the caller is allowed to perform the update, false otherwise</returns>
		public virtual bool CanBatchUpdateEntitiesDirectly(IEntityCore entity)
		{
			return true;
		}

		/// <summary>
		/// Determines whether the caller is allowed to delete of the entity type passed in
		/// </summary>
		/// <param name="entity">The entity to delete.</param>
		/// <returns>true if the caller is allowed to delete the entity passed in, false otherwise</returns>
		public virtual bool CanDeleteEntity(IEntityCore entity)
		{
			return true;
		}


		/// <summary>
		/// Determines whether the caller is allowed to delete entities directly in the database. 
		/// </summary>
		/// <param name="typeOfEntity">the type of the entity to batch delete instances of directly in the database, e.g. DeleteMulti (Selfservicing)
		/// or DeleteEntitiesDirectly (adapter)</param>
		/// <returns>true if the caller is allowed to perform the delete, false otherwise</returns>
		public virtual bool CanBatchDeleteEntitiesDirectly(Type typeOfEntity)
		{
			return true;
		}


		/// <summary>
		/// Gets the result hint what to do when authorization fails when fetch a new entity.
		/// </summary>
		/// <returns>any of the FetchNewAuthorizationFailureResultHint values</returns>
		public virtual FetchNewAuthorizationFailureResultHint GetFetchNewAuthorizationFailureResultHint()
		{
			return FetchNewAuthorizationFailureResultHint.ThrowAway;
		}


		/// <summary>
		/// Gets the EntityType value as integer for the entity type passed in
		/// </summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the EntityType value as integer for the entity type passed in</returns>
		protected int GetEntityTypeValueForType(Type typeOfEntity)
		{
			object instance = Activator.CreateInstance(typeOfEntity);
			IEntityCore entity = instance as IEntityCore;
			if(entity == null)
			{
				return 0;
			}
			return entity.LLBLGenProEntityTypeValue;
		}
	}
}
