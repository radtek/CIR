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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Base class for implementing an InheritanceInfoProvider object.
	/// </summary>
	[Serializable]
	public abstract class InheritanceInfoProviderBase : IInheritanceInfoProvider
	{
		#region Class Member Declarations
		private Hashtable	_entityToEntityInfo, _entityToPathToRoot, _entityToSubTypes, _entityToSuperType, _rootEntities, _entityToHierarchyLeafs;
		#endregion

		#region Private classes
		/// <summary>
		/// Private class which contains the entity information for an entity added to the provider's store.
		/// </summary>
		[Serializable]
		private class EntityInfo
		{
			#region Class Member Declarations
			private	string					_name, _superTypeName;
			private ArrayList		_subTypeNames;
			private IRelationFactory		_relationFactory;
			private IEntityFactoryCore		_entityFactory;
			private int[]					_distinguishingFieldIndexes;
			private int						_discriminatorColumnIndex;
			private object					_discriminatorColumnValue;
			private Hashtable				_discriminatorValueToTypeName;
			#endregion

			/// <summary>
			/// CTor
			/// </summary>
			/// <param name="name">Name.</param>
			/// <param name="superTypeName">Name of the super type.</param>
			/// <param name="relationFactory">Relation factory.</param>
			/// <param name="entityFactory">Entity factory.</param>
			/// <param name="distinguishingFieldIndexes">Distinguishing field indexes.</param>
			/// <remarks>TargetPerEntity specific constructor</remarks>
			internal EntityInfo(string name, string superTypeName, IRelationFactory relationFactory, IEntityFactoryCore entityFactory, params int[] distinguishingFieldIndexes)
			{
				_name = name;
				_superTypeName  = superTypeName;
				_relationFactory = relationFactory;
				_subTypeNames = new ArrayList();
				_entityFactory = entityFactory;
				_distinguishingFieldIndexes=distinguishingFieldIndexes;
				_discriminatorColumnIndex = -1;
				_discriminatorColumnValue = null;
				_discriminatorValueToTypeName = null;
			}

			/// <summary>
			/// CTor
			/// </summary>
			/// <param name="name">Name.</param>
			/// <param name="superTypeName">Name of the super type.</param>
			/// <param name="entityFactory">Entity factory.</param>
			/// <param name="discriminatorColumnIndex">Index of the discriminator column</param>
			/// <param name="discriminatorColumnValue">Discriminator column value which distinguishes this entity type.</param>
			/// <remarks>TargetPerEntityHierarchy specific constructor</remarks>
			internal EntityInfo(string name, string superTypeName, IEntityFactoryCore entityFactory, int discriminatorColumnIndex, object discriminatorColumnValue)
			{
				_name = name;
				_superTypeName  = superTypeName;
				_subTypeNames = new ArrayList();
				_entityFactory = entityFactory;
				_relationFactory = null;
				_discriminatorColumnIndex = discriminatorColumnIndex;
				_discriminatorColumnValue = discriminatorColumnValue;
				_discriminatorValueToTypeName = null;
			}

			/// <summary>
			/// adds the name passed in as a subtype of this entity.
			/// </summary>
			/// <param name="subTypeName"></param>
			internal void AddSubType(string subTypeName)
			{
				_subTypeNames.Add(subTypeName);
			}

			#region Class Property Declarations
		
			/// <summary>
			/// Gets / sets discriminatorValueToTypeName. This hashtable is only set in entityinfo objects of root entities in TargetPerEntityHierarchy hierarchies.
			/// </summary>
			public Hashtable DiscriminatorValueToTypeName
			{
				get
				{
					return _discriminatorValueToTypeName;
				}
				set
				{
					_discriminatorValueToTypeName = value;
				}
			}

			/// <summary>
			/// returns true if relationfactory is set, which is typical for TargetPerEntity hierarchies.
			/// </summary>
			public bool IsInTargetPerEntity
			{
				get { return (_relationFactory!=null);}
			}
			/// <summary>
			/// Gets / sets discriminatorColumnIndex
			/// </summary>
			public int DiscriminatorColumnIndex
			{
				get
				{
					return _discriminatorColumnIndex;
				}
				set
				{
					_discriminatorColumnIndex = value;
				}
			}

			/// <summary>
			/// Gets / sets discriminatorColumnValue
			/// </summary>
			public object DiscriminatorColumnValue
			{
				get
				{
					return _discriminatorColumnValue;
				}
				set
				{
					_discriminatorColumnValue = value;
				}
			}

			/// <summary>
			/// Gets / sets entityFactory
			/// </summary>
			public IEntityFactoryCore EntityFactory
			{
				get
				{
					return _entityFactory;
				}
				set
				{
					_entityFactory = value;
				}
			}

			/// <summary>
			/// Gets / sets distinguishingFieldIndexes
			/// </summary>
			public int[] DistinguishingFieldIndexes
			{
				get
				{
					return _distinguishingFieldIndexes;
				}
				set
				{
					_distinguishingFieldIndexes = value;
				}
			}

			/// <summary>
			/// Gets / sets name
			/// </summary>
			public string Name
			{
				get
				{
					return _name;
				}
				set
				{
					_name = value;
				}
			}

			/// <summary>
			/// Gets / sets superTypeName
			/// </summary>
			public string SuperTypeName
			{
				get
				{
					return _superTypeName;
				}
				set
				{
					_superTypeName = value;
				}
			}

			/// <summary>
			/// Gets / sets relationFactory
			/// </summary>
			public IRelationFactory RelationFactory
			{
				get
				{
					return _relationFactory;
				}
				set
				{
					_relationFactory = value;
				}
			}

			/// <summary>
			/// Gets / sets subTypeNames
			/// </summary>
			public ArrayList SubTypeNames
			{
				get
				{
					return _subTypeNames;
				}
			}

			/// <summary>
			/// Gets if the entity has any subtypes.
			/// </summary>
			public bool HasSubTypes
			{
				get { return (_subTypeNames.Count>0);}
			}

			public bool HasSuperType
			{
				get
				{
					return ((_superTypeName==null)||(_superTypeName.Length<=0));
				}
			}


			#endregion
		}
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		public InheritanceInfoProviderBase()
		{
			_entityToEntityInfo = new Hashtable();
			// Paths are stored from root entity down to the entity which owns the path, without the owner in the path.
			_entityToPathToRoot = new Hashtable();
			_entityToSubTypes = new Hashtable();
			_entityToSuperType = new Hashtable();
			// per entity all the leafs below the entity in the hierarchy the entity is in, are stored. In a ArrayList.
			_entityToHierarchyLeafs = new Hashtable();
			_rootEntities = new Hashtable();
		}


		/// <summary>
		/// Adds a new entity to the store. The supertype name is enough to build the complete hierarchy. 
		/// </summary>
		/// <param name="name">name of the entity to add, e.g. "CustomerEntity"</param>
		/// <param name="superTypeName">the name of the supertype of the passed in entity, e.g. "EmployeeEntity".</param>
		/// <param name="relationFactory">the relation factory of the entity with name, to produce relations to supertype and subtype.</param>
		/// <param name="entityFactory">Entity factory.</param>
		/// <param name="distinguishingFieldIndexes">Distinguishing field indexes.</param>
		/// <remarks>TargetPerEntity specific version</remarks>
		protected void AddEntityInfo(string name, string superTypeName, IRelationFactory relationFactory, IEntityFactoryCore entityFactory, params int[] distinguishingFieldIndexes)
		{
			if(_entityToEntityInfo.ContainsKey(name))
			{
				throw new ArgumentException("The entity with name '" + name + "' is already added to this provider.", "name");
			}

			EntityInfo newInfo = new EntityInfo(name, superTypeName, relationFactory, entityFactory, distinguishingFieldIndexes);
			_entityToEntityInfo.Add(name, newInfo);
			_entityToSuperType.Add(name, superTypeName);
			_entityToHierarchyLeafs.Add(name, new ArrayList());
			_entityToSubTypes.Add(name, newInfo.SubTypeNames);
			if(superTypeName.Length<=0)
			{
				// root entity
				_rootEntities.Add(name, null);
			}
		}


		/// <summary>
		/// Adds a new entity to the store. The supertype name is enough to build the complete hierarchy.
		/// </summary>
		/// <param name="name">name of the entity to add, e.g. "CustomerEntity"</param>
		/// <param name="superTypeName">the name of the supertype of the passed in entity, e.g. "EmployeeEntity".</param>
		/// <param name="entityFactory">Entity factory.</param>
		/// <param name="discriminatorColumnIndex">Index of the discriminator column.</param>
		/// <param name="discriminatorColumnValue">Discriminator column value which distinguishes this entity</param>
		/// <remarks>TargetPerEntityHierarchy specific version</remarks>
		protected void AddEntityInfo(string name, string superTypeName, IEntityFactoryCore entityFactory, int discriminatorColumnIndex, object discriminatorColumnValue)
		{
			if(_entityToEntityInfo.ContainsKey(name))
			{
				throw new ArgumentException("The entity with name '" + name + "' is already added to this provider.", "name");
			}

			EntityInfo newInfo = new EntityInfo(name, superTypeName, entityFactory, discriminatorColumnIndex, discriminatorColumnValue);
			_entityToEntityInfo.Add(name, newInfo);
			_entityToSuperType.Add(name, superTypeName);
			_entityToHierarchyLeafs.Add(name, new ArrayList());
			_entityToSubTypes.Add(name, newInfo.SubTypeNames);
			if(superTypeName.Length<=0)
			{
				// root entity
				_rootEntities.Add(name, null);
				if(!newInfo.IsInTargetPerEntity)
				{
					// in targetperentityhierarchy
					newInfo.DiscriminatorValueToTypeName = new Hashtable();
					newInfo.DiscriminatorValueToTypeName.Add(newInfo.DiscriminatorColumnValue, name);
				}
			}
		}


		/// <summary>
		/// Builds the hierarchy information from the added information though AddEntityInfo calls. 
		/// </summary>
		protected void BuildHierarchyInfoStore()
		{
			// build up subtypes.
			foreach(DictionaryEntry entry in _entityToSuperType)
			{
				string subTypeName = (string)entry.Key;
				string superTypeName = (string)entry.Value;
				if(superTypeName.Length<=0)
				{
					// root
					continue;
				}
				EntityInfo info = (EntityInfo)_entityToEntityInfo[superTypeName];
				info.AddSubType(subTypeName);
			}

			// build the paths from each entity to the root of its hierarchy.
			foreach(string rootEntityName in _rootEntities.Keys)
			{
				ConstructPath(rootEntityName);
			}
		}


		/// <summary>
		/// Constructs the path from entity to root of the hierarchy the entity is in. It also constructs entity to hierarchy leafs 
		/// </summary>
		/// <param name="entityName">Name of the entity.</param>
		private void ConstructPath(string entityName)
		{
			ArrayList path = new ArrayList();
			_entityToPathToRoot.Add(entityName, path);

			// construct the path of the entity passed in, by grabbing the path of its supertype, if any.
			string superType = (string)_entityToSuperType[entityName];
			if(superType.Length>0)
			{
				// has supertype, grab path of supertype.
				ArrayList pathSuperType = (ArrayList)_entityToPathToRoot[superType];
				// copy all entities in this path to our own path.
				foreach(string entityOnPath in pathSuperType)
				{
					path.Add(entityOnPath);
				}

				path.Add(superType);
			}

			EntityInfo info=(EntityInfo)_entityToEntityInfo[entityName];
			if(!info.IsInTargetPerEntity && !_rootEntities.ContainsKey(entityName))
			{
				EntityInfo infoRoot = (EntityInfo)_entityToEntityInfo[path[0]];
				infoRoot.DiscriminatorValueToTypeName.Add(info.DiscriminatorColumnValue, entityName);
			}

			// then, call recursion for each subtype of this path.
			ArrayList subTypes = (ArrayList)_entityToSubTypes[entityName];
			foreach(string subType in subTypes)
			{
				ConstructPath(subType);
			}

			if(subTypes.Count<=0)
			{
				// current entity is a leaf. Grab the path and add this entity to all the entities in the path so they know this 
				// entity is a leaf below them.
				foreach(string entityInPath in path)
				{
					ArrayList leafsBelowEntity = (ArrayList)_entityToHierarchyLeafs[entityInPath];
					leafsBelowEntity.Add(entityName);
				}
			}
		}


		/// <summary>
		/// Determines if typeToCheck is a subtype of superType.
		/// </summary>
		/// <param name="typeToCheck">Type to check.</param>
		/// <param name="superType">The super.</param>
		/// <returns>
		/// true if typeToCheck is a subtype of supertype, false otherwise. Also returns false is supertype isn't in a hierarchy.
		/// </returns>
		public bool CheckIfIsSubTypeOf(string typeToCheck, string superType)
		{
			if(!_entityToEntityInfo.ContainsKey(superType))
			{
				return false;
			}
			// typeToCheck is a subtype if typeToCheck is in the path to the leafs from supertype.
			ArrayList pathToRoot = (ArrayList)_entityToPathToRoot[typeToCheck];
			return pathToRoot.Contains( superType );
		}


		/// <summary>
		/// Gets the entity fields for the entity passed in. Only the fields defined in the entity are returned
		/// </summary>
		/// <param name="entityName">Name of the entity to grab the fields for</param>
		/// <returns>array of IEntityFieldCore fields</returns>
		public abstract IEntityFieldCore[] GetEntityFields(string entityName);


		/// <summary>
		/// Gets an IInheritanceInfo object with the inheritance information for the entity with the supplied name. 
		/// </summary>
		/// <param name="entityName">name of the entity, like "CustomerEntity". This name is used for retrieving the information from
		/// a thread safe hashtable</param>
		/// <param name="startWithRoot">Set to <see langword="true"/> if the relations in
		/// <see cref="IInheritanceInfo.RelationsToHierarchyRoot"/> have to start with the root and walk downwards to the entityName
		/// entity, or set to false if the relations have to start at the entityname and move upwards to the root.</param>
		/// <returns>Ready to use IInheritanceInfo object if entityName is part of a hierarchy. If entityName isn't part of a
		/// hierarchy, null is returned. (not part of a hierarchy means: not a supertype nor a subtype</returns>
		public IInheritanceInfo GetInheritanceInfo(string entityName, bool startWithRoot)
		{
			if(!_entityToEntityInfo.ContainsKey(entityName))
			{
				return null;
			}

			RelationCollection relations = new RelationCollection();
			ArrayList path = (ArrayList)_entityToPathToRoot[entityName];
			EntityInfo info = (EntityInfo)_entityToEntityInfo[entityName];

			if(!_rootEntities.ContainsKey(entityName) && info.IsInTargetPerEntity)
			{
				// it's a subtype
				// this routine uses two similar loops, though this isn't branched out into a routine to avoid thread unsafety.
				if(startWithRoot)
				{
					for (int i = 0; i < path.Count; i++)
					{
						EntityInfo infoOfPathEntity = (EntityInfo)_entityToEntityInfo[path[i]];
						string subType = string.Empty;
						if(i<(path.Count-1))
						{
							subType = (string)path[i+1];
						}
						else
						{
							subType = entityName;
						}
						EntityRelation relationToAdd = (EntityRelation)infoOfPathEntity.RelationFactory.GetSubTypeRelation(subType);
						relationToAdd.IsHierarchyRelation = true;
						relations.Add(relationToAdd);	
					}
				}
				else
				{
					// add first relation of entityName to supertype, as entityName isn't its path
					relations.Add(info.RelationFactory.GetSuperTypeRelation());

					// do not include the root of the path into the loop, as the root doesn't have a relation with its supertype anyway.
					for (int i = path.Count-1;i>0; i--)
					{
						EntityInfo infoOfPathEntity = (EntityInfo)_entityToEntityInfo[path[i]];
						EntityRelation relationToAdd = (EntityRelation)infoOfPathEntity.RelationFactory.GetSuperTypeRelation();
						relationToAdd.IsHierarchyRelation = true;
						relations.Add(relationToAdd);	
					}
				}
			}
			ArrayList entityNamesOnHierarchyPath = new ArrayList(path);
			entityNamesOnHierarchyPath.Insert(0, entityName);
			InheritanceHierarchyType hierarchyType = InheritanceHierarchyType.TargetPerEntity;
			IPredicateExpression typeFilter = null;
			if(!info.IsInTargetPerEntity)
			{
				hierarchyType = InheritanceHierarchyType.TargetPerEntityHierarchy;
				typeFilter = GetEntityTypeFilter(entityName, false);
			}

			// get all the entity names on paths below the passed in name till the entity leafs. Add these per path to a list and pass that as entityNamesOfPathsToLeafs
			ArrayList leafsBelowEntity = (ArrayList)_entityToHierarchyLeafs[entityName];
			UniqueValueList entityNamesOfPathsToLeafs = new UniqueValueList();
			foreach(string leafName in leafsBelowEntity)
			{
				// grab path to root for leaf and walk that path from the current entity position till the end.
				ArrayList leafPath = (ArrayList)_entityToPathToRoot[leafName];
				// has to be there.
				int indexOfCurrentEntity = leafPath.IndexOf(entityName);
				for(int i = (indexOfCurrentEntity+1); i < leafPath.Count; i++)
				{
					entityNamesOfPathsToLeafs.Add((string)leafPath[i]);
				}
				entityNamesOfPathsToLeafs.Add(leafName);
			}

			return new InheritanceInfo((string)_entityToSuperType[entityName], entityName, hierarchyType, 
					relations, info.DiscriminatorColumnIndex, info.DiscriminatorColumnValue, entityNamesOnHierarchyPath, typeFilter, 
					new ArrayList(entityNamesOfPathsToLeafs));
		}


		/// <summary>
		/// This method returns all relations from the entityName to the root and from the entityName downwards to all the reachable leafs 
		/// from entityName. All relations to the root are INNER JOIN, all relations from entityName to leafs are LEFT JOIN
		/// </summary>
		/// <param name="entityName">name of the current entity on the path of which the hierarchy has to be determined. Example: "CustomerEntity"</param>
		/// <returns>collection with relations if entityName was found, or null if not or if the entity is in a TargetPerEntityHierarchy.</returns>
		/// <remarks>This routine uses no subroutines to avoid thread unsafety.</remarks>
		public RelationCollection GetHierarchyRelations(string entityName)
		{
			if(!_entityToEntityInfo.ContainsKey(entityName))
			{
				return null;
			}

			EntityInfo infoOfEntityPassedIn =(EntityInfo)_entityToEntityInfo[entityName];
			if(!infoOfEntityPassedIn.IsInTargetPerEntity)
			{
				return null;
			}

			RelationCollection toReturn = new RelationCollection();

			// first the relations from entity passed in to its root, we use the path for that.
			ArrayList pathToRoot = (ArrayList)_entityToPathToRoot[entityName];
			for (int i = 0; i < pathToRoot.Count; i++)
			{
				EntityInfo infoOfPathEntity = (EntityInfo)_entityToEntityInfo[pathToRoot[i]];
				string subType = string.Empty;
				if(i<(pathToRoot.Count-1))
				{
					subType = (string)pathToRoot[i+1];
				}
				else
				{
					subType = entityName;
				}
				IEntityRelation relationToAdd = infoOfPathEntity.RelationFactory.GetSubTypeRelation(subType);
				((EntityRelation)relationToAdd).IsHierarchyRelation = true;
				toReturn.Add(relationToAdd);	// no hint needed, the relation is joined with INNER JOIN
			}

			// now add relations from passed in name to all subtypes below this type, till all leafs. These relations will be added with a left join hint.
			ArrayList leafsBelowEntity = (ArrayList)_entityToHierarchyLeafs[entityName];
			foreach(string leafName in leafsBelowEntity)
			{
				// grab path to root for leaf and walk that path from the current entity position till the end.
				ArrayList leafPath = (ArrayList)_entityToPathToRoot[leafName];
				// has to be there.
				int indexOfCurrentEntity = leafPath.IndexOf(entityName);
				for(int i=indexOfCurrentEntity;i<leafPath.Count;i++)
				{
					EntityInfo infoOfPathEntity = (EntityInfo)_entityToEntityInfo[leafPath[i]];
					string subType = string.Empty;
					if(i<(leafPath.Count-1))
					{
						subType = (string)leafPath[i+1];
					}
					else
					{
						subType = leafName;
					}
					IEntityRelation relationToAdd = infoOfPathEntity.RelationFactory.GetSubTypeRelation(subType);
					((EntityRelation)relationToAdd).IsHierarchyRelation = true;
					toReturn.Add(relationToAdd, JoinHint.Left); // specify LEFT join, as the relation has to be joined as supertype LEFT JOIN subtype
				}
			}

			return toReturn;
		}


		/// <summary>
		/// This method returns all relations from the lowest entity found in the passed in entityNames to the root and from the lowest entityName 
		/// downwards to all the reachable leafs from entityName. All relations to the root are INNER JOIN, all relations from the lowest entityName 
		/// to leafs are LEFT JOIN. 
		/// </summary>
		/// <param name="entityNames">1 or more names of entities on the same path of which the hierarchy has to be determined. Example of a name: "CustomerEntity"</param>
		/// <returns>collection with relations if all entityNames were found, or null if not.</returns>
		/// <remarks>This method is a wrapper around GetHierarchyRelations(name), to make finding the right collection more efficient. It finds the lowest
		/// entityname in the hierarchy and calls GetHierarchyRelations(name) with that name. It assumes the names are on the same path to the root.</remarks>
		/// <exception cref="ArgumentException">when not all entities specified in entityNames are on the same hierarchical path</exception>
		public RelationCollection GetHierarchyRelations(ArrayList entityNames)
		{
			if(entityNames.Count<=0)
			{
				return null;
			}
			if(entityNames.Count==1)
			{
				return GetHierarchyRelations((string)entityNames[0]);
			}

			// find the name which is the lowest on the path to the root. This is the one with the most entries in its path to the root. If one or more of
			// the entities are not on the same hierarchy path, an exception is thrown.
			ArrayList longestPath = new ArrayList();
			string entityWithLongestPath = string.Empty;
			foreach(string entityName in entityNames)
			{
				ArrayList pathToRoot = (ArrayList)_entityToPathToRoot[entityName];
				if(pathToRoot==null)
				{
					throw new ArgumentException("An entity name has been specified which isn't in an inheritance hierarchy. This is often caused by a typedlist fetch where no relations have been specified so LLBLGen Pro will assume all fields belong to a subtype in a hierarchy.", "entityNames");
				}
				else
				{
					if(pathToRoot.Count> longestPath.Count)
					{
						longestPath = pathToRoot;
						entityWithLongestPath = entityName;
					}
				}
			}

			// check if all entities are in this path (except entityWithLongestpath, which isn't in its own path)
			bool areAllInPath = true;
			foreach(string entityName in entityNames)
			{
				if(entityName==entityWithLongestPath)
				{
					continue;
				}
				areAllInPath &= longestPath.Contains(entityName);
				if(!areAllInPath)
				{
					throw new ArgumentException("Not all entities specified are on the same hierarchical path to the root. ", "entityNames");
				}
			}

			return GetHierarchyRelations(entityWithLongestPath);
		}


		/// <summary>
		/// This method returns an array of IEntityFieldCore objects which contains all fields of all entities on the path: 
		/// entityName upwards to the root and entityName downwards to all leafs reachable from entityName, including entityName.
		/// </summary>
		/// <param name="entityName">name of the current entity on the path of which the hierarchy fields has to be determined. Example: "CustomerEntity"</param>
		/// <returns>Array of IEntityFieldCore objects, each element represents one field, or null if entityName isn't found.
		/// When fields are returned, their aliases are set from front to back as 'Fx' where x is the index in the array, starting with 0.</returns>
		/// <remarks>This routine uses no subroutines to avoid thread unsafety.</remarks>
		public IEntityFieldCore[] GetHierarchyFields(string entityName)
		{
			if(!_entityToEntityInfo.ContainsKey(entityName))
			{
				return null;
			}

			ArrayList fieldsCollected = new ArrayList();

			MultiValueHashtable alreadyIncludedFields = new MultiValueHashtable();

			// first the fields from entity passed in to its root, we use the path for that.
			ArrayList pathToRoot = (ArrayList)_entityToPathToRoot[entityName];
			for (int i = 0; i < pathToRoot.Count; i++)
			{
				IEntityFieldCore[] fieldsOfEntityOnPath = GetEntityFields((string)pathToRoot[i]);
				if(fieldsOfEntityOnPath!=null)
				{
					// type has fields mapped, grab them.
					foreach(IEntityFieldCore field in fieldsOfEntityOnPath)
					{
						fieldsCollected.Add(field);
						alreadyIncludedFields.Add(pathToRoot[i], field.Name);
					}
				}
			}

			// add the fields of the current entity
			IEntityFieldCore[] fieldsOfEntity = GetEntityFields(entityName);
			if(fieldsOfEntity!=null)
			{
				// has fields mapped
				foreach(IEntityFieldCore field in fieldsOfEntity)
				{
					fieldsCollected.Add(field);
					alreadyIncludedFields.Add(entityName, field.Name);
				}
			}

			// now add all fields from passed in name to all subtypes below this type, till all leafs. 
			ArrayList leafsBelowEntity = (ArrayList)_entityToHierarchyLeafs[entityName];
			foreach(string leafName in leafsBelowEntity)
			{
				// grab path to root for leaf and walk that path from the current entity position + 1 till the end, as we've already included
				// the current entity's fields. 
				ArrayList leafPath = (ArrayList)_entityToPathToRoot[leafName];
				// has to be there.
				int indexOfCurrentEntity = leafPath.IndexOf(entityName);
				for(int i=indexOfCurrentEntity+1;i<leafPath.Count;i++)
				{
					IEntityFieldCore[] fieldsOfEntityOnPath = GetEntityFields((string)leafPath[i]);
					if(fieldsOfEntityOnPath!=null)
					{
						foreach(IEntityFieldCore field in fieldsOfEntityOnPath)
						{
							if(!alreadyIncludedFields.Contains(leafPath[i], field.Name))
							{
								fieldsCollected.Add(field);
								alreadyIncludedFields.Add(leafPath[i], field.Name);
							}
						}
					}
				}

				// add leaf's fields
				IEntityFieldCore[] fieldsOfLeaf = GetEntityFields(leafName);
				if(fieldsOfLeaf!=null)
				{
					foreach(IEntityFieldCore field in fieldsOfLeaf)
					{
						if(!alreadyIncludedFields.Contains(leafName, field.Name))
						{
							fieldsCollected.Add(field);
							alreadyIncludedFields.Add(leafName, field.Name);
						}
					}
				}
			}

			IEntityFieldCore[] toReturn = new IEntityFieldCore[fieldsCollected.Count];
			for (int i = 0; i < fieldsCollected.Count; i++)
			{
				IEntityFieldCore field = (IEntityFieldCore)fieldsCollected[i];
				field.Alias = "F" + i;
				toReturn[i]=field;
			}

			return toReturn;
		}

		

		/// <summary>
		/// Gets the type of the hierarchy.
		/// </summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <returns>the type of the hierarchy of the entity name specified</returns>
		public InheritanceHierarchyType GetHierarchyType(string entityName)
		{
			InheritanceHierarchyType toReturn = InheritanceHierarchyType.None;

			EntityInfo info = (EntityInfo)_entityToEntityInfo[entityName];
			if(info!=null)
			{
				if(info.IsInTargetPerEntity)
				{
					toReturn = InheritanceHierarchyType.TargetPerEntity;
				}
				else
				{
					toReturn = InheritanceHierarchyType.TargetPerEntityHierarchy;
				}
			}

			return toReturn;
		}


		/// <summary>
		/// Retrieves the factory for the entity represented by the values passed in, or null if entityName isn't present. The values have to 
		/// represent an entity of the type entityName or a subtype of that type. 
		/// </summary>
		/// <param name="entityName">name of the entity, like 'CustomerEntity'. This is the name of the root of the hierarchy to consider. 
		/// For example when fetching all managers, and manager derives from employee, this parameter is 'ManagerEntity', and only the manager type
		/// or its subtypes (direct or indirect) are considered. </param>
		/// <param name="values">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		public IEntityFactoryCore GetEntityFactory(string entityName, object[] values, Hashtable entityFieldStartIndexesPerEntity)
		{
			if(!_entityToEntityInfo.ContainsKey(entityName))
			{	
				return null;
			}

			EntityInfo info = (EntityInfo)_entityToEntityInfo[entityName];
			if(info.IsInTargetPerEntity)
			{
				return GetEntityFactoryTargetPerEntity(entityName, values, entityFieldStartIndexesPerEntity);
			}
			else
			{
				return GetEntityFactoryTargetPerEntityHierarchy(entityName, values);
			}
		}
	

		/// <summary>
		/// Gets the entity type filters for the entity names specified. It will use the object aliases specified for the entity names. 
		/// It will filter out supertypes if the subtype is also in the list. 
		/// </summary>
		/// <param name="entityNamesWithAliases">The entity names with per entity name (key) the object alias.</param>
		/// <returns>PredicateExpression with per entity which needed a typefilter a predicate, added with AND</returns>
		public IPredicateExpression GetEntityTypeFilters(Hashtable entityNamesWithAliases)
		{
			PredicateExpression toReturn = new PredicateExpression();
			foreach(DictionaryEntry entry in entityNamesWithAliases)
			{
				EntityInfo info = (EntityInfo)_entityToEntityInfo[(string)entry.Key];
				if(info==null)
				{
					continue;
				}

				// get subtypes. Check if a subtype is also in the list of names, if so, skip it.
				ArrayList subTypes = (ArrayList)_entityToSubTypes[(string)entry.Key];
				bool skipEntityName = false;
				foreach(string subType in subTypes)
				{
					if(subType == (string)entry.Key)
					{
						continue;
					}
					if(entityNamesWithAliases.ContainsKey(subType))
					{
						// subtype is also in the list to be examined, skip altogether.
						skipEntityName = true;
						break;
					}
				}
				if(skipEntityName)
				{
					continue;
				}
				toReturn.AddWithAnd(GetEntityTypeFilter((string)entry.Key, (string)entry.Value, false));
			}

			return toReturn;
		}


		/// <summary>
		/// Gets a predicateexpression which filters on the entity with type 'entityName'. Example of a valid name is 'CustomerEntity'. 
		/// </summary>
		/// <param name="entityName">Name of the entity to filter on, like 'CustomerEntity'</param>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false). </param>
		/// <returns>ready to use predicateexpression, or an empty predicate expression if entityName's value isn't an entity which is a hierarchical type.</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		public IPredicateExpression GetEntityTypeFilter(string entityName, bool negate)
		{
			return GetEntityTypeFilter(entityName, string.Empty, negate);
		}


		/// <summary>
		/// Gets a predicateexpression which filters on the entity with type 'entityName'. Example of a valid name is 'CustomerEntity'.
		/// </summary>
		/// <param name="entityName">Name of the entity to filter on, like 'CustomerEntity'</param>
		/// <param name="objectAlias">The object alias to use for the filter.</param>
		/// <param name="negate">Flag to produce a NOT filter, (true), or a normal filter (false).</param>
		/// <returns>ready to use predicateexpression, or an empty predicate expression if entityName's value isn't an entity which is a hierarchical type.</returns>
		/// <remarks>Only useful in entity fetches.</remarks>
		public IPredicateExpression GetEntityTypeFilter(string entityName, string objectAlias, bool negate)
		{
			IPredicateExpression toReturn = new PredicateExpression();
			if(!_entityToEntityInfo.ContainsKey(entityName))
			{
				return toReturn;
			}

			if(_rootEntities.ContainsKey(entityName))
			{
				// entity is root, no filter needed, all entities match
				return toReturn;
			}

			EntityInfo info = (EntityInfo)_entityToEntityInfo[entityName];
			IEntityFieldCore[] fields = null;
			if(info.IsInTargetPerEntity)
			{
				fields = GetEntityFields(entityName);
			}
			else
			{
				// get fields of root, if not root
				if(_rootEntities.ContainsKey(entityName))
				{
					fields = GetEntityFields(entityName);
				}
				else
				{
					string rootName = (string)((ArrayList)_entityToPathToRoot[entityName])[0];
					fields = GetEntityFields(rootName);
				}
			}
			
			bool isSelfServicing = false;
			IEntityField field = fields[0] as IEntityField;
			isSelfServicing = (field !=null);

			if(info.IsInTargetPerEntity)
			{
				foreach(int index in info.DistinguishingFieldIndexes)
				{
					// produce a filter which filters on any field NOT NULL, unless negated.
					if(isSelfServicing)
					{
						toReturn.Add(new FieldCompareNullPredicate((IEntityField)fields[index], objectAlias, !negate));
					}
					else
					{
						toReturn.Add(new FieldCompareNullPredicate(fields[index], null, objectAlias, !negate));
					}
				}
			}
			else
			{
				// target per entity hierarchy
				// add comparevalue predicate on the discriminator column of this type and ALL its subtypes.
				ArrayList leafsBelowEntity = (ArrayList)_entityToHierarchyLeafs[entityName];
				Hashtable seenEntities = new Hashtable();
				seenEntities.Add(entityName, null);
				foreach(string leafName in leafsBelowEntity)
				{
					// grab path to root for leaf and walk that path from the current entity position + 1 till the end, as we've already included
					// the current entity's fields. 
					ArrayList leafPath = (ArrayList)_entityToPathToRoot[leafName];
					foreach(string entityNameOnPath in leafPath)
					{
						if(!seenEntities.ContainsKey(entityNameOnPath))
						{
							seenEntities.Add(entityNameOnPath, null);
						}
					}

					if(!seenEntities.ContainsKey(leafName))
					{
						seenEntities.Add(leafName, null);
					}
				}

				ArrayList namesToProcess = new ArrayList(seenEntities.Keys);

				IEntityFieldCore discriminatorField = fields[info.DiscriminatorColumnIndex];
				if(namesToProcess.Count>1)
				{
					ArrayList discriminatorValues = new ArrayList();
					// create a field IN (value1, value2...) filter
					foreach(string nameOfType in namesToProcess)
					{
						EntityInfo infoOfType = (EntityInfo)_entityToEntityInfo[nameOfType];
						discriminatorValues.Add(infoOfType.DiscriminatorColumnValue);
					}
					if(isSelfServicing)
					{
						toReturn.Add(new FieldCompareRangePredicate((IEntityField)discriminatorField, objectAlias, negate, discriminatorValues));
					}
					else
					{
						toReturn.Add(new FieldCompareRangePredicate(discriminatorField, null, objectAlias, negate, discriminatorValues));
					}
				}
				else
				{
					// just 1, add a compare value predicate
					if(isSelfServicing)
					{
						toReturn.Add(new FieldCompareValuePredicate((IEntityField)discriminatorField, ComparisonOperator.Equal, info.DiscriminatorColumnValue, objectAlias, negate));
					}
					else
					{
						toReturn.Add(new FieldCompareValuePredicate(discriminatorField, null, ComparisonOperator.Equal, info.DiscriminatorColumnValue, objectAlias, negate));
					}
				}
			}

			return toReturn;
		}

		
		/// <summary>
		/// Gets all entity names in the provider.
		/// </summary>
		/// <returns>List with all entity names in the provider.</returns>
		public ArrayList GetAllEntityNamesInProvider()
		{
			return new ArrayList(_entityToEntityInfo.Keys);
		}


		/// <summary>
		/// Gets the entity names on hierarchy path, from this entity to the root starting with the OwnerEntityName and ending with the 
		/// root entity name of the hierarchy. If OwnerEntityName entity is a root entity, this collection contains one name: OwnerEntityName.
		/// </summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <returns></returns>
		internal ArrayList GetEntityNamesOnHierarchyPath( string entityName )
		{
			if( !_entityToEntityInfo.ContainsKey( entityName ) )
			{
				return null;
			}

			ArrayList entityNamesOnHierarchyPath = new ArrayList( (ArrayList)_entityToPathToRoot[entityName] );
			entityNamesOnHierarchyPath.Add(entityName );
			return entityNamesOnHierarchyPath;
		}


		/// <summary>
		/// Retrieves the factory for the entity represented by the values passed in, or null if entityName isn't present. The values have to 
		/// represent an entity of the type entityName or a subtype of that type. 
		/// </summary>
		/// <param name="entityName">name of the entity, like 'CustomerEntity'. This is the name of the root of the hierarchy to consider. 
		/// For example when fetching all managers, and manager derives from employee, this parameter is 'ManagerEntity', and only the manager type
		/// or its subtypes (direct or indirect) are considered. </param>
		/// <param name="values">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <param name="entityFieldStartIndexesPerEntity">indexes into values where per entity type their own fields start.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		private IEntityFactoryCore GetEntityFactoryTargetPerEntity(string entityName, object[] values, Hashtable entityFieldStartIndexesPerEntity)
		{
			IEntityFactoryCore toReturn = null;

			// get the info of ourselves, which contains our subtypes as well. 
			EntityInfo info = (EntityInfo)_entityToEntityInfo[entityName];

			// check if there is any subtype which is represented by this row. There is at most 1 subtype represented by this row, as
			// there isn't multiple inheritance. If no subtype is represented by this row, the row represents the entity of the name passed in.
			bool rowRepresentsSubType=false;
			foreach(string subTypeName in info.SubTypeNames)
			{
				EntityInfo subTypeInfo = (EntityInfo)_entityToEntityInfo[subTypeName];
				int startIndexOfSubtypeFields = (int)entityFieldStartIndexesPerEntity[subTypeName];
				bool allFieldsAreNotNull = true;
				foreach(int index in subTypeInfo.DistinguishingFieldIndexes)
				{
					int actualIndex = startIndexOfSubtypeFields + index;
					if(actualIndex >= values.Length)
					{
						// index out of bounds, not represented by this subtype;
						allFieldsAreNotNull = false;
						break;
					}
					allFieldsAreNotNull &= (values[actualIndex] != System.DBNull.Value);
					if(!allFieldsAreNotNull)
					{
						// already one is NULL, exit loop
						break;
					}
				}
				if(allFieldsAreNotNull)
				{
					// row is represented by this subtype (or one of its (indirect) subtypes)
					toReturn = GetEntityFactoryTargetPerEntity(subTypeName, values, entityFieldStartIndexesPerEntity);
					rowRepresentsSubType = true;
					break;
				}
			}

			if(!rowRepresentsSubType)
			{
				// no subtype is represented by this row, which means this row is representing entityname
				toReturn = info.EntityFactory;
			}

			return toReturn;
		}


		/// <summary>
		/// Retrieves the factory for the entity represented by the values passed in, or null if entityName isn't present. The values have to 
		/// represent an entity of the type entityName or a subtype of that type. 
		/// </summary>
		/// <param name="entityName">name of the entity, like 'CustomerEntity'. As all entity types are in the same target, the routine considers
		/// all subtypes. </param>
		/// <param name="values">Field values read from the db, to determine which factory to return, based on the field values passed in.</param>
		/// <returns>the factory for the entity which is represented by the values passed in.</returns>
		private IEntityFactoryCore GetEntityFactoryTargetPerEntityHierarchy(string entityName, object[] values)
		{
			// simply get the info of root of the hierarchy the entity is in and use the hashtable to find hte entity. 
			string rootEntityName = string.Empty;
			if(_rootEntities.ContainsKey(entityName))
			{
				// is root
				rootEntityName = entityName;
			}
			else
			{
				ArrayList pathToRoot = (ArrayList)_entityToPathToRoot[entityName];
				rootEntityName = (string)pathToRoot[0];
			}

			EntityInfo infoRoot = (EntityInfo)_entityToEntityInfo[rootEntityName];
			object discriminatorValue = values[infoRoot.DiscriminatorColumnIndex];
			if(!infoRoot.DiscriminatorValueToTypeName.ContainsKey(discriminatorValue))
			{
				// not available in the hierarchy. Unknown entity type
				throw new ORMInheritanceInfoException(
						string.Format("Unknown discriminator value '{0}' in row read from db, which doesn't exist in hierarchy of root '{1}'.",
							discriminatorValue, rootEntityName));
			}

			string entityType = (string)infoRoot.DiscriminatorValueToTypeName[discriminatorValue];
			return ((EntityInfo)_entityToEntityInfo[entityType]).EntityFactory;
		}
	}


	/// <summary>
	/// Simple class which contains the inheritance information of an entity, and which is produced by an inheritanceinfoprovider.
	/// </summary>
	[Serializable]
	public class InheritanceInfo : IInheritanceInfo
	{
		#region Class Member Declarations
		private InheritanceHierarchyType	_hierarchyType;
		private	RelationCollection			_relationsToHierarchyRoot;
		private string						_superTypeEntityName;
		private string						_ownerEntityName;
		private int							_discriminatorColumnIndex;
		private object						_discriminatorColumnValue;
		private ArrayList					_entityNamesOnHierarchyPath, _entityNamesOfPathsToLeafs;
		private IPredicateExpression		_typeFilterTargetPerEntityHierarchy;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="InheritanceInfo"/> class.
		/// </summary>
		/// <param name="superTypeEntityName">Name of the super type entity.</param>
		/// <param name="ownerEntityName">Name of the owner entity.</param>
		/// <param name="hierarchyType">Type of the hierarchy.</param>
		/// <param name="relationsToHierarchyRoot">Relations to hierarchy root.</param>
		/// <param name="discriminatorColumnIndex">Index of the discriminator column.</param>
		/// <param name="discriminatorColumnValue">Discriminator column value.</param>
		/// <param name="entityNamesOnHierarchyPath">Entity names on hierarchy path.</param>
		/// <param name="typeFilterTargetPerEntityHierarchy">Type filter target per entity hierarchy.</param>
		/// <param name="entityNamesOfPathsToLeafs">Entity names of paths to leafs</param>
		public InheritanceInfo(string superTypeEntityName, string ownerEntityName, InheritanceHierarchyType hierarchyType,
				RelationCollection relationsToHierarchyRoot, int discriminatorColumnIndex, object discriminatorColumnValue, 
				ArrayList entityNamesOnHierarchyPath, IPredicateExpression typeFilterTargetPerEntityHierarchy, 
				ArrayList entityNamesOfPathsToLeafs)
		{
			_superTypeEntityName = superTypeEntityName;
			_ownerEntityName = ownerEntityName;
			_hierarchyType = hierarchyType;
			_relationsToHierarchyRoot = relationsToHierarchyRoot;
			_discriminatorColumnIndex = discriminatorColumnIndex;
			_discriminatorColumnValue = discriminatorColumnValue;
			_entityNamesOnHierarchyPath = entityNamesOnHierarchyPath;
			_typeFilterTargetPerEntityHierarchy = typeFilterTargetPerEntityHierarchy;
			_entityNamesOfPathsToLeafs = entityNamesOfPathsToLeafs;
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets the type of the hierarchy.
		/// </summary>
		public InheritanceHierarchyType HierarchyType 
		{
			get { return _hierarchyType; }
		}

		/// <summary>
		/// Gets the relations to hierarchy root, starting at the root, to the owner entity, INNER JOINed
		/// </summary>
		public RelationCollection RelationsToHierarchyRoot 
		{
			get { return _relationsToHierarchyRoot; }
		}

		/// <summary>
		/// Gets the name of the super type entity. Example: "CustomerEntity"
		/// </summary>
		public string SuperTypeEntityName 
		{
			get { return _superTypeEntityName; }
		}

		/// <summary>
		/// The name of the entity which owns this information, of which this object belongs to.
		/// </summary>
		public string OwnerEntityName 
		{
			get { return _ownerEntityName; }
		}

		/// <summary>
		/// Gets the index of the discriminator column.
		/// </summary>
		/// <value>0 or higher for an entity in a TargetPerEntityHierarchy, otherwise undefined.</value>
		public int DiscriminatorColumnIndex
		{
			get { return _discriminatorColumnIndex; }
		}

		/// <summary>
		/// Gets the discriminator column value.
		/// </summary>
		/// <value>The discriminator value for the entity of this inheritance info, or undefined if the entity is not in a TargetPerEntityHierarchy.</value>
		public object DiscriminatorColumnValue
		{
			get { return _discriminatorColumnValue; }
		}

		/// <summary>
		/// Readonly arraylist with all teh entity names on the path to the root, starting with the <see cref="OwnerEntityName"/> and ending with the 
		/// root entity name of the hierarchy. If <see cref="OwnerEntityName"/> entity is a root entity, this collection contains one name: <see cref="OwnerEntityName"/>.
		/// </summary>
		public ArrayList EntityNamesOnHierarchyPath 
		{ 
#if CF
			get { return _entityNamesOnHierarchyPath;}
#else
			get { return ArrayList.ReadOnly(_entityNamesOnHierarchyPath);}
#endif
		}

		/// <summary>
		/// List with all the entity names on the paths from the <see cref="OwnerEntityName"/> entity to all the leafs in the hierarchy below the 
		/// <see cref="OwnerEntityName"/>. If the <see cref="OwnerEntityName"/> is a leaf, this list is empty.
		/// </summary>
		public ArrayList EntityNamesOfPathsToLeafs 
		{
			get { return _entityNamesOfPathsToLeafs; }
		}
		
		/// <summary>
		/// Gets the type filter if the entity which owns this information is in a TargetPerEntityHierarchy, null otherwise.
		/// </summary>
		public IPredicateExpression TypeFilterTargetPerEntityHierarchy 
		{ 
			get { return _typeFilterTargetPerEntityHierarchy;}
		}
		#endregion

	}

}
