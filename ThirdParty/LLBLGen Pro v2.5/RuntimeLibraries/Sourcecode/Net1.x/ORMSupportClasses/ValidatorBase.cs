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
using System.ComponentModel;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract class definition for a validator object, used to validate entity data. This class is the common base class for
	/// all generated entitynameValidator classes in the generated code. 
	/// </summary>
	[Serializable]
	public abstract class ValidatorBase : IValidator
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
		public virtual bool ValidateFieldValue(IEntityCore involvedEntity, int fieldIndex, object value )
		{
			return true;
		}


		/// <summary>
		/// Method to validate the containing entity after it is loaded. This method is called after the entity has been fully loaded.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		public virtual void ValidateEntityAfterLoad(IEntityCore involvedEntity)
		{
			// nop
		}


		/// <summary>
		/// Method to validate the containing entity right before the save sequence for the entity will start. LLBLGen Pro will call this method right after the
		/// containing entity is selected from the save queue to be saved.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		public virtual void ValidateEntityBeforeSave( IEntityCore involvedEntity )
		{
			// nop
		}


		/// <summary>
		/// Method to validate the containing entity right after the entity's save action has been completed and the entity has been refetched (if applicable).
		/// Note for adapter users: if the entity wasn't set to be refetched, take into account that reading properties from the containing entity will result in an
		/// OutOfSync exception.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		public virtual void ValidateEntityAfterSave( IEntityCore involvedEntity )
		{
			// nop
		}


		/// <summary>
		/// Method to validate the containig entity right beforethe entity's delete action will take place.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		public virtual void ValidateEntityBeforeDelete( IEntityCore involvedEntity )
		{
			// nop
		}


		/// <summary>
		/// General validation method which isn't used by the LLBLGen Pro framework, but can be used by your own code to validate an entity at any given moment.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		public virtual void ValidateEntity( IEntityCore involvedEntity )
		{
			// nop
		}


		/// <summary>
		/// Called when the implementing object is assinged to entity.Validator.
		/// </summary>
		/// <param name="involvedEntity">entity the validator is assigned to</param>
		public virtual void AssignedToEntity( IEntityCore involvedEntity )
		{
			// nop
		}

		/// <summary>
		/// Called when the implementing object is dereferenced from an assigned entity.
		/// </summary>
		/// <param name="involvedEntity">the entity the validator is unassigned from</param>
		public virtual void UnassignedFromEntity( IEntityCore involvedEntity )
		{
			// nop
		}
		
	}
}