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
using System.Text;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract base class for entity factories. The class is suffixed with 'Core' as the generated code contains another base class, EntityFactoryBase, which
	/// is the direct base class for the generated entity factories. 
	/// </summary>
	/// <remarks>SelfServicing specific</remarks>
	[Serializable]
	public abstract class EntityFactoryCore : IEntityFactory
	{
		/// <summary>
		/// Creates a new <see cref="IEntity"/> instance
		/// </summary>
		/// <returns>the new IEntity instance</returns>
		public virtual IEntity Create()
		{
			return null;
		}

		/// <summary>
		/// Creates a new <see cref="IEntity"/> instance but uses a special constructor which will set the Fields object of the new
		/// IEntity instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.
		/// </summary>
		/// <param name="fields">Populated IEntityFields object for the new entity to create</param>
		/// <returns>
		/// Fully created and populated (due to the IEntityFields object) IEntity object
		/// </returns>
		public virtual IEntity Create(IEntityFields fields)
		{
			return null;
		}

		/// <summary>
		/// Creates, using the generated EntityFieldsFactory, the IEntityFields object for the entity to create. This method is used
		/// by internal code to create the fields object to store fetched data.
		/// </summary>
		/// <returns>Empty IEntityFields object.</returns>
		public virtual IEntityFields CreateFields()
		{
			return null;
		}

		/// <summary>
		/// Creates the hierarchy fields for the entity to which this factory belongs.
		/// </summary>
		/// <returns>
		/// IEntityFields object with the fields of all the entities in the hierarchy of this entity or the fields of this entity if
		/// the entity isn't in a hierarchy.
		/// </returns>
		public virtual IEntityFields CreateHierarchyFields()
		{
			return this.CreateFields();
		}

		/// <summary>
		/// This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.
		/// </summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns></returns>
		public virtual IEntityFactory GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity)
		{
			return this;
		}

		/// <summary>
		/// Creates a new entity collection for the entity of this factory.
		/// </summary>
		/// <returns>
		/// ready to use new entity collection, typed.
		/// </returns>
		public virtual IEntityCollection CreateEntityCollection()
		{
			return null;
		}


		/// <summary>
		/// Creates the relations collection to the entity to join all targets so this entity can be fetched.
		/// </summary>
		/// <returns>
		/// null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to
		/// join all targets together to fetch all subtypes of this entity and this entity itself
		/// </returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;
		}


		/// <summary>
		/// Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value
		/// </summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity instance</returns>
		public virtual IEntity CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return null;
		}


		#region Class Property Declarations
		/// <summary>
		/// returns the name of the entity this factory is for, e.g. "EmployeeEntity"
		/// </summary>
		/// <value></value>
		public virtual string ForEntityName
		{
			get { return string.Empty; }
		}
		#endregion
	}


	/// <summary>
	/// Abstract base class for entity factories. The class is suffixed with 'Core' as the generated code contains another base class, EntityFactoryBase2, which
	/// is the direct base class for the generated entity factories. 
	/// </summary>
	/// <remarks>Adapter specific</remarks>
	[Serializable]
	public abstract class EntityFactoryCore2 : IEntityFactory2
	{
		/// <summary>
		/// Creates a new <see cref="IEntity2"/> instance
		/// </summary>
		/// <returns>the new IEntity2 instance</returns>
		public virtual IEntity2 Create()
		{
			return null;
		}

		/// <summary>
		/// Creates a new <see cref="IEntity2"/> instance but uses a special constructor which will set the Fields object of the new
		/// IEntity2 instance to the passed in fields object. Implement this method to support multi-type in single table inheritance.
		/// </summary>
		/// <param name="fields">Populated IEntityFields2 object for the new entity2 to create</param>
		/// <returns>
		/// Fully created and populated (due to the IEntityFields2 object) IEntity2 object
		/// </returns>
		public virtual IEntity2 Create(IEntityFields2 fields)
		{
			return null;
		}

		/// <summary>
		/// Creates, using the generated EntityFieldsFactory, the IEntityFields2 object for the entity to create. This method is used
		/// by internal code to create the fields object to store fetched data.
		/// </summary>
		/// <returns>Empty IEntityFields2 object.</returns>
		public virtual IEntityFields2 CreateFields()
		{
			return null;
		}

		/// <summary>
		/// Creates the hierarchy fields for the entity to which this factory belongs.
		/// </summary>
		/// <returns>
		/// IEntityFields2 object with the fields of all the entities in the hierarchy of this entity or the fields of this entity if
		/// the entity isn't in a hierarchy.
		/// </returns>
		public virtual IEntityFields2 CreateHierarchyFields()
		{
			return this.CreateFields();
		}

		/// <summary>
		/// This method retrieves, using the InheritanceInfoprovider, the factory for the entity represented by the values passed in.
		/// </summary>
		/// <param name="fieldValues">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns></returns>
		public virtual IEntityFactory2 GetEntityFactory(object[] fieldValues, Dictionary<string, int> entityFieldStartIndexesPerEntity)
		{
			return this;
		}

		/// <summary>
		/// Gets a predicateexpression which filters on the entity with type belonging to this factory.
		/// </summary>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false).</param>
		/// <returns>
		/// ready to use predicateexpression, or an empty predicate expression if the belonging entity isn't a hierarchical type.
		/// </returns>
		public virtual IPredicateExpression GetEntityTypeFilter(bool negate)
		{
			return new PredicateExpression();
		}

		/// <summary>
		/// Creates the relations collection to the entity to join all targets so this entity can be fetched.
		/// </summary>
		/// <returns>
		/// null if the entity isn't in a hierarchy of type TargetPerEntity, otherwise the relations collection needed to
		/// join all targets together to fetch all subtypes of this entity and this entity itself
		/// </returns>
		public virtual IRelationCollection CreateHierarchyRelations()
		{
			return null;
		}


		/// <summary>
		/// Creates a new entity instance using the GeneralEntityFactory in the generated code, using the passed in entitytype value
		/// </summary>
		/// <param name="entityTypeValue">The entity type value of the entity to create an instance for.</param>
		/// <returns>new IEntity2 instance</returns>
		public virtual IEntity2 CreateEntityFromEntityTypeValue(int entityTypeValue)
		{
			return null;
		}

		#region Class Property Declarations
		/// <summary>
		/// returns the name of the entity this factory is for, e.g. "EmployeeEntity"
		/// </summary>
		/// <value></value>
		public virtual string ForEntityName
		{
			get { return string.Empty; }
		}
		#endregion

	}
}
