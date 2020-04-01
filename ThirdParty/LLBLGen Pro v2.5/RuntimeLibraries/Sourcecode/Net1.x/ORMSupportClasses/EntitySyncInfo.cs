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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// General synchronization information class for related entities to an existing entity. 
	/// Used to keep track of which entity is set as a related entity using which relation and which field mapped on that
	/// relation so when the related entity is saved, it will be synced with the correct fields. The related
	/// entity is called a Data Suppling Entity.
	/// AdapterVersion
	/// </summary>
	[Serializable]
	public class EntitySyncInfo
	{
		#region Class Member Declarations
		private IEntity2			_dataSupplyingEntity;
		private	IEntityRelation		_relation;
		private bool				_used;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		public EntitySyncInfo()
		{
			_dataSupplyingEntity = null;
			_relation = null;
			_used = false;
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets used flag. Flag to signal if the sync info has been used for syncing already. If not, it can be used to 
		/// determine if the entity holding this sync info has to be saved or not.
		/// </summary>
		internal bool Used
		{
			get
			{
				return _used;
			}
			set
			{
				_used = value;
			}
		}

		/// <summary>
		/// Gets / sets Data Supplying Entity value. Used for synchronization between related entities when they have to be synchronized.
		/// </summary>
		public IEntity2 DataSupplyingEntity
		{
			get
			{
				return _dataSupplyingEntity;
			}
			set
			{
				_dataSupplyingEntity = value;
			}
		}


		/// <summary>
		/// Gets / sets the specific Entity Relation between two related entities (the entity holding this object and the entity specified in
		/// DataSupplyingEntity) for synchronization of values.
		/// </summary>
		public IEntityRelation Relation
		{
			get
			{
				return _relation;
			}
			set
			{
				_relation = value;
			}
		}

		#endregion
	}


	/// <summary>
	/// General synchronization information class for related entities to an existing entity. 
	/// Used to keep track of which entity is set as a related entity using which relation and which field mapped on that
	/// relation so when the related entity is saved, it will be synced with the correct fields. The related
	/// entity is called a Data Suppling Entity.
	/// SelfServicing version
	/// </summary>
	[Serializable]
	public class EntitySyncInfoSS
	{
		#region Class Member Declarations
		private IEntity				_dataSupplyingEntity;
		private	IEntityRelation		_relation;
		private bool				_used;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		public EntitySyncInfoSS()
		{
			_dataSupplyingEntity = null;
			_relation = null;
			_used = false;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets used flag. Flag to signal if the sync info has been used for syncing already. If not, it can be used to 
		/// determine if the entity holding this sync info has to be saved or not.
		/// </summary>
		internal bool Used
		{
			get
			{
				return _used;
			}
			set
			{
				_used = value;
			}
		}

		/// <summary>
		/// Gets / sets Data Supplying Entity value. Used for synchronization between related entities when they have to be synchronized.
		/// </summary>
		public IEntity DataSupplyingEntity
		{
			get
			{
				return _dataSupplyingEntity;
			}
			set
			{
				_dataSupplyingEntity = value;
			}
		}


		/// <summary>
		/// Gets / sets the specific Entity Relation between two related entities (the entity holding this object and the entity specified in
		/// DataSupplyingEntity) for synchronization of values.
		/// </summary>
		public IEntityRelation Relation
		{
			get
			{
				return _relation;
			}
			set
			{
				_relation = value;
			}
		}

		#endregion


	}
}
