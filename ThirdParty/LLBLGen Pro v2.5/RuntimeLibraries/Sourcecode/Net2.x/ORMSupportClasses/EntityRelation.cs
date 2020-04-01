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
	/// Generic implementation of the IEntityRelation interface, which is used for relations between IEntity* instances.
	/// </summary>
	[Serializable]
	public class EntityRelation : IEntityRelation
	{
		#region Class Member Declarations
		private List<IEntityFieldCore>		_primaryKeyFields, _foreignKeyFields;
		private List<IFieldPersistenceInfo>	_pkFieldsPersistenceInfo, _fkFieldsPersistenceInfo;
		private RelationType				_typeOfRelation;
		private bool						_startEntityIsPkSide, _customFilterReplacesOnClause, _enableArtificialAliasing, _isHierarchyRelation;
		private IPredicateExpression		_customFilter;
		private string						_aliasStartEntity, _aliasEndEntity, _mappedFieldName;
		private JoinHint					_hintForJoins;
		private IInheritanceInfo			_inheritanceInfoPkSideEntity, _inheritanceInfoFkSideEntity;

		[NonSerialized]
		private IPredicateExpression		_cachedBuildCustomFilter;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public EntityRelation()
		{
			InitClass();
			_typeOfRelation = RelationType.OneToMany;
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="typeOfRelation">The type of relation this instance represents</param>
		public EntityRelation(RelationType typeOfRelation)
		{
			InitClass();
			_typeOfRelation = typeOfRelation;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="EntityRelation"/> class.
		/// </summary>
		/// <param name="typeOfRelation">The type of relation this instance represents</param>
		/// <param name="mappedFieldName">Name of the mapped field in the start entity onto this relation.</param>
		public EntityRelation(RelationType typeOfRelation, string mappedFieldName)
		{
			InitClass();
			_typeOfRelation = typeOfRelation;
			_mappedFieldName = mappedFieldName;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="EntityRelation"/> class.
		/// </summary>
		/// <param name="typeOfRelation">The type of relation.</param>
		/// <param name="startEntityIsPkSide">Set to true if the start entity of the relation is the PK side of the relation. This is set in the generated code. 
		/// This property is true in 1:n relations and in 1:1 relations where the start entity is the PK side and the end entity is thus the
		/// FK side. Required for determining which alias belongs to which entity.</param>
		public EntityRelation(RelationType typeOfRelation, bool startEntityIsPkSide)
		{
			InitClass();
			_typeOfRelation = typeOfRelation;
			_startEntityIsPkSide = startEntityIsPkSide;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="EntityRelation"/> class.
		/// </summary>
		/// <param name="typeOfRelation">The type of relation.</param>
		/// <param name="mappedFieldName">Name of the mapped field in the start entity onto this relation.</param>
		/// <param name="startEntityIsPkSide">Set to true if the start entity of the relation is the PK side of the relation. This is set in the generated code. 
		/// This property is true in 1:n relations and in 1:1 relations where the start entity is the PK side and the end entity is thus the
		/// FK side. Required for determining which alias belongs to which entity.</param>
		public EntityRelation(RelationType typeOfRelation, string mappedFieldName, bool startEntityIsPkSide)
		{
			InitClass();
			_typeOfRelation = typeOfRelation;
			_mappedFieldName = mappedFieldName;
			_startEntityIsPkSide = startEntityIsPkSide;
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="primaryKeyField">The IEntityField instance which represents the primary key in the relation</param>
		/// <param name="foreignKeyField">The IEntityField instance which represents the foreign key in the relation</param>
		/// <param name="typeOfRelation">The type of relation this instance represents</param>
		/// <remarks>Selfservicing specific</remarks>
		public EntityRelation(IEntityField primaryKeyField, IEntityField foreignKeyField, RelationType typeOfRelation)
			: this(primaryKeyField, foreignKeyField, typeOfRelation, false, string.Empty)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="EntityRelation"/> class.
		/// </summary>
		/// <param name="primaryKeyField">The IEntityField instance which represents the primary key in the relation</param>
		/// <param name="foreignKeyField">The IEntityField instance which represents the foreign key in the relation</param>
		/// <param name="typeOfRelation">The type of relation this instance represents</param>
		/// <param name="startEntityIsPkSide">Set to true if the start entity of the relation is the PK side of the relation. This is set in the generated code. 
		/// This property is true in 1:n relations and in 1:1 relations where the start entity is the PK side and the end entity is thus the
		/// FK side. Required for determining which alias belongs to which entity.</param>
		/// <param name="mappedFieldName">Name of the mapped field.</param>
		/// <remarks>Selfservicing specific</remarks>
		public EntityRelation(IEntityField primaryKeyField, IEntityField foreignKeyField, RelationType typeOfRelation, bool startEntityIsPkSide,
			string mappedFieldName)
		{
			InitClass();
			_primaryKeyFields.Add(primaryKeyField);
			_foreignKeyFields.Add(foreignKeyField);
			_pkFieldsPersistenceInfo.Add(primaryKeyField);
			_fkFieldsPersistenceInfo.Add(foreignKeyField);
			_typeOfRelation = typeOfRelation;
			_startEntityIsPkSide = startEntityIsPkSide;
			_mappedFieldName = mappedFieldName;
		}



		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="primaryKeyField">The IEntityField2 instance which represents the primary key in the relation</param>
		/// <param name="foreignKeyField">The IEntityField2 instance which represents the foreign key in the relation</param>
		/// <param name="typeOfRelation">The type of relation this instance represents</param>
		/// <remarks>Adapter specific</remarks>
		public EntityRelation(IEntityField2 primaryKeyField, IEntityField2 foreignKeyField, RelationType typeOfRelation)
			:this(primaryKeyField, foreignKeyField, typeOfRelation, false, string.Empty)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="EntityRelation"/> class.
		/// </summary>
		/// <param name="primaryKeyField">The IEntityField2 instance which represents the primary key in the relation</param>
		/// <param name="foreignKeyField">The IEntityField2 instance which represents the foreign key in the relation</param>
		/// <param name="typeOfRelation">The type of relation this instance represents</param>
		/// <param name="startEntityIsPkSide">Set to true if the start entity of the relation is the PK side of the relation. This is set in the generated code. 
		/// This property is true in 1:n relations and in 1:1 relations where the start entity is the PK side and the end entity is thus the
		/// FK side. Required for determining which alias belongs to which entity.</param>
		/// <param name="mappedFieldName">Name of the mapped field in the start entity onto this relation.</param>
		/// <remarks>Adapter specific</remarks>
		public EntityRelation(IEntityField2 primaryKeyField, IEntityField2 foreignKeyField, RelationType typeOfRelation, bool startEntityIsPkSide,
			string mappedFieldName)
		{
			InitClass();
			_primaryKeyFields.Add(primaryKeyField);
			_foreignKeyFields.Add(foreignKeyField);
			_typeOfRelation = typeOfRelation;
			_startEntityIsPkSide = startEntityIsPkSide;
			_mappedFieldName = mappedFieldName;
		}


		/// <summary>
		/// Adds a new pair of entity field instances to the relation. Primary Key fields and Foreign Key Fields have to be added
		/// in pairs. 
		/// </summary>
		/// <param name="primaryKeyField">The Entity field instance which represents a field in the primary key in the relation</param>
		/// <param name="foreignKeyField">The Entity field instance which represents the corresponding field in the foreign key in the relation</param>
		public void AddEntityFieldPair<TEntityField>(TEntityField primaryKeyField, TEntityField foreignKeyField)
			where TEntityField : IEntityFieldCore
		{
			_primaryKeyFields.Add(primaryKeyField);
			_foreignKeyFields.Add(foreignKeyField);
			if( primaryKeyField is IFieldPersistenceInfo )
			{
				_pkFieldsPersistenceInfo.Add((IFieldPersistenceInfo) primaryKeyField );
				_fkFieldsPersistenceInfo.Add( (IFieldPersistenceInfo)foreignKeyField );
			}
		}


		/// <summary>
		/// Initializes the class' member variables.
		/// </summary>
		private void InitClass()
		{
			_primaryKeyFields = new List<IEntityFieldCore>();
			_foreignKeyFields = new List<IEntityFieldCore>();
			_pkFieldsPersistenceInfo = new List<IFieldPersistenceInfo>();
			_fkFieldsPersistenceInfo = new List<IFieldPersistenceInfo>();
			_customFilter = null;
			_hintForJoins = JoinHint.None;
			_aliasEndEntity = string.Empty;
			_aliasStartEntity = string.Empty;
			_startEntityIsPkSide = false;
			_customFilterReplacesOnClause = false;
			_inheritanceInfoFkSideEntity=null;
			_inheritanceInfoPkSideEntity=null;
			_mappedFieldName = string.Empty;
			_enableArtificialAliasing = false;
			_isHierarchyRelation = false;
		}


		/// <summary>
		/// Gets the IFieldPersistenceInfo data for the PK field at index specified.
		/// </summary>
		/// <param name="index">index of the field in the list of PK fields.</param>
		/// <returns>IFieldPersistenceInfo object</returns>
		public IFieldPersistenceInfo GetPKFieldPersistenceInfo(int index)
		{
			return _pkFieldsPersistenceInfo[index];
		}


		/// <summary>
		/// Gets per alias specified in a relation all entity names covered by that alias. This means that if an entity in a relation is based on multiple entities
		/// (through inheritance) it will return all entity names the entity is based on, from the actual entity to the root of the hierarchy path and every
		/// entity name in between.
		/// </summary>
		/// <param name="entityNamesPerAlias">Entity names per alias multivaluehashtable: per alias (key) all entity names are stored in a uniquevaluelist.</param>
		/// <param name="artificialAliasPerEntity">The artificial alias per entity. This collection contains per entity (key) the artificial alias (value), IF 
		/// such an artificial alias has been given out. (only done with entities which are part of a hierarchy of type TargetPerEntity)</param>
		public void GetUsedEntityTypeNamesAndAliases(MultiValueHashtable<string, string> entityNamesPerAlias, Dictionary<string, string> artificialAliasPerEntity)
		{
			IEntityFieldCore pkField = this.GetPKEntityFieldCore(0);
			IEntityFieldCore fkField = this.GetFKEntityFieldCore(0);
			string aliasPKSide = this.AliasPKSide;
			string aliasFKSide = this.AliasFKSide;

			IInheritanceInfo infoPKSide = this.InheritanceInfoPkSideEntity;
			IInheritanceInfo infoFKSide = this.InheritanceInfoFkSideEntity;
			if(aliasPKSide.Length > 0)
			{
				if(infoPKSide != null)
				{
					entityNamesPerAlias.Add(aliasPKSide, GetListOfEntityNamesOnHierarchyPath(infoPKSide));
					if(CheckifAliasIsArtificial(true))
					{
						// add entity to list of artifical aliases
						artificialAliasPerEntity[GetPKEntityFieldCore(0).ActualContainingObjectName] = aliasPKSide;
					}
				}
				else
				{
					if(_isHierarchyRelation)
					{
						entityNamesPerAlias.Add(aliasPKSide, pkField.ContainingObjectName + ";" + (int)InheritanceHierarchyType.TargetPerEntity);
						if(CheckifAliasIsArtificial(true))
						{
							// add entity to list of artifical aliases
							artificialAliasPerEntity[GetPKEntityFieldCore(0).ActualContainingObjectName] = aliasPKSide;
						}
					}
					else
					{
						entityNamesPerAlias.Add(aliasPKSide, pkField.ContainingObjectName);
					}
				}
			}
			if(aliasFKSide.Length>0)
			{
				if(infoFKSide!=null)
				{
					entityNamesPerAlias.Add(aliasFKSide, GetListOfEntityNamesOnHierarchyPath(infoFKSide));
					if(CheckifAliasIsArtificial(false))
					{
						// add entity to list of artifical aliases
						artificialAliasPerEntity[GetFKEntityFieldCore(0).ActualContainingObjectName] = aliasFKSide;
					}
				}
				else
				{
					if(_isHierarchyRelation)
					{
						entityNamesPerAlias.Add(aliasFKSide, fkField.ContainingObjectName + ";" + (int)InheritanceHierarchyType.TargetPerEntity);
						if(CheckifAliasIsArtificial(false))
						{
							// add entity to list of artifical aliases
							artificialAliasPerEntity[GetFKEntityFieldCore(0).ActualContainingObjectName] = aliasFKSide;
						}
					}
					else
					{
						entityNamesPerAlias.Add(aliasFKSide, fkField.ContainingObjectName);
					}
				}
			}
		}


		/// <summary>
		/// Returns in an arraylist all IEntityFieldCore objects for the PK fields in this entityrelation
		/// </summary>
		/// <returns>List with the requested objects</returns>
		public List<IEntityFieldCore> GetAllPKEntityFieldCoreObjects()
		{
			return _primaryKeyFields;
		}


		/// <summary>
		/// Returns in an arraylist all IEntityFieldCore objects for the FK fields in this entityrelation
		/// </summary>
		/// <returns>ArrayList with the requested objects</returns>
		public List<IEntityFieldCore> GetAllFKEntityFieldCoreObjects()
		{
			return _foreignKeyFields;
		}


		/// <summary>
		/// Returns in an arraylist all IFieldPersistenceInfo objects for the FK fields in this entityrelation
		/// </summary>
		/// <returns>ArrayList with the requested objects</returns>
		public List<IFieldPersistenceInfo> GetAllFKFieldPersistenceInfoObjects()
		{
			return _fkFieldsPersistenceInfo;
		}


		/// <summary>
		/// Returns in an arraylist all IFieldPersistenceInfo objects for the PK fields in this entityrelation
		/// </summary>
		/// <returns>ArrayList with the requested objects</returns>
		public List<IFieldPersistenceInfo> GetAllPKFieldPersistenceInfoObjects()
		{
			return _pkFieldsPersistenceInfo;
		}


		/// <summary>
		/// Gets the IFieldPersistenceInfo data for the FK field at index specified.
		/// </summary>
		/// <param name="index">index of the field in the list of FK fields.</param>
		/// <returns>IFieldPersistenceInfo object</returns>
		public IFieldPersistenceInfo GetFKFieldPersistenceInfo(int index)
		{
			return _fkFieldsPersistenceInfo[index];
		}


		/// <summary>
		/// Gets the IEntityFieldCode information about the PK field at index specified
		/// </summary>
		/// <param name="index">index of field in the list of PK fields</param>
		/// <returns>IEntityFieldCode object</returns>
		public IEntityFieldCore GetPKEntityFieldCore(int index)
		{
			return _primaryKeyFields[index];
		}


		/// <summary>
		/// Gets the IEntityFieldCode information about the FK field at index specified
		/// </summary>
		/// <param name="index">index of field in the list of FK fields</param>
		/// <returns>IEntityFieldCode object</returns>
		public IEntityFieldCore GetFKEntityFieldCore(int index)
		{
			return _foreignKeyFields[index];
		}


		/// <summary>
		/// Sets the IFieldPersistenceInfo data for the PK field at index specified.
		/// </summary>
		/// <param name="index">index of the field in the list of PK fields.</param>
		/// <param name="persistenceInfo">The persistence info for the entity field at position index.</param>
		/// <remarks>Used by DataAccessAdapter objects.</remarks>
		public void SetPKFieldPersistenceInfo(int index, IFieldPersistenceInfo persistenceInfo)
		{
			_pkFieldsPersistenceInfo.Insert(index, persistenceInfo);
		}


		/// <summary>
		/// Sets the IFieldPersistenceInfo data for the FK field at index specified.
		/// </summary>
		/// <param name="index">index of the field in the list of FK fields.</param>
		/// <param name="persistenceInfo">The persistence info for the entity field at position index.</param>
		/// <remarks>Used by DataAccessAdapter objects.</remarks>
		public void SetFKFieldPersistenceInfo(int index, IFieldPersistenceInfo persistenceInfo)
		{
			_fkFieldsPersistenceInfo.Insert(index, persistenceInfo);
		}


		/// <summary>
		/// Sets the aliases for the start entity and the end entity formed by the fields stored in this entityrelation. The start entity and end entity
		/// are determined based on the type of the relation and the primary key / foreign key fields. Mainly used by RelationCollection.Add(). 
		/// </summary>
		/// <param name="aliasStartEntity">the alias for the start entity in the relation. Alias is case sensitive. An alias with solely spaces or
		/// an empty string is ignored.</param>
		/// <param name="aliasEndEntity">the alias for the end entity in the relation Alias is case sensitive. An alias with solely spaces or
		/// an empty string is ignored.</param>
		public void SetAliases(string aliasStartEntity, string aliasEndEntity)
		{
			_aliasStartEntity = aliasStartEntity;
			_aliasEndEntity = aliasEndEntity;
		}
		

		/// <summary>
		/// Enables / disables the artificial aliasing for target per entity relations. This method is used to enable the artificial aliasing of entities which
		/// are in a hierarchy of TargetPerEntity and which are in this relation. This is switched on for dyn/typedlist fetches to be sure 
		/// dyn/typedlists with fields from multiple entities in the same inheritance hierarchy will be retrievable properly, as they need aliasing under the hood
		/// but if the developer didn't alias the entities, the query will fail because the supertype(s) aren't joined multiple types. 
		/// </summary>
		/// <param name="enable">if set to true, enable artificial aliasing, otherwise false (default).</param>
		/// <remarks>Artificial aliasing is disabled by default</remarks>
		internal void ToggleArtificialAliasingForTargetPerEntityRelations(bool enable)
		{
			_enableArtificialAliasing = enable;
			if(_inheritanceInfoFkSideEntity != null)
			{
				foreach(EntityRelation inheritanceRelation in _inheritanceInfoFkSideEntity.RelationsToHierarchyRoot)
				{
					inheritanceRelation.ToggleArtificialAliasingForTargetPerEntityRelations(enable);
				}
			}
			if(_inheritanceInfoPkSideEntity != null)
			{
				foreach(EntityRelation inheritanceRelation in _inheritanceInfoPkSideEntity.RelationsToHierarchyRoot)
				{
					inheritanceRelation.ToggleArtificialAliasingForTargetPerEntityRelations(enable);
				}
			}
		}


		/// <summary>
		/// Resets the aliases for start/end entity if they're artificial.
		/// </summary>
		internal void ResetArtificialAliases()
		{
			if((_aliasStartEntity!=null) && _aliasStartEntity.StartsWith("LPAA_"))
			{
				_aliasStartEntity = string.Empty;
			}
			if((_aliasEndEntity != null) && _aliasEndEntity.StartsWith("LPAA_"))
			{
				_aliasEndEntity = string.Empty;
			}
		}


		/// <summary>
		/// Gets the list of entity names on hierarchy path. This routine will first obtain the list of entity names from the passed in inheritance info object.
		/// If the hierarchy is of type TargetPerEntityHierarchy, it will suffix each name with ';1'. If the inheritance hierarchy is TargetPerEntityHierarchy, 
		/// it will suffix each name with ';2'. This suffix is then used in DbSpecificCreatorBase to produce the proper aliases: a different one for each
		/// Alias - Entity combination if the hierarchy type is TargetPerEntityHierarchy, and the same for each Alias - Entity combination if they're in the same
		/// hierarchy.
		/// </summary>
		/// <param name="info">The info.</param>
		/// <returns>List of names, suffixed with the hierarchy type. </returns>
		private List<string> GetListOfEntityNamesOnHierarchyPath(IInheritanceInfo info)
		{
			List<string> toReturn = new List<string>(info.EntityNamesOnHierarchyPath);
			int hierarchyType = (int)info.HierarchyType;
			if(info.HierarchyType == InheritanceHierarchyType.TargetPerEntityHierarchy)
			{
				toReturn.AddRange(info.EntityNamesOfPathsToLeafs);
			}
			for(int i = 0; i < toReturn.Count; i++)
			{
				toReturn[i] += ";" + hierarchyType;
			}

			return toReturn;
		}


		/// <summary>
		/// Determines if this relation is a weak relation (true) or not (false). 1:m is always weak by definition. 1:1
		/// relations are weak when relation is seen from PK entity, otherwise always strong (when seen from FK entity).
		/// This can't be determined here, so 1:1 relations are always reported 'weak'. 
		/// </summary>
		/// <returns>true when this relation is weak, false otherwise. Returns false by default.</returns>
		/// <remarks>Sees 1:1 not as a strong relation per se. Earlier versions did so.</remarks>
		private bool DetermineIfIsWeak()
		{
			bool relationIsWeak = false;

			switch(_typeOfRelation)
			{
				case RelationType.ManyToOne:
					// weak if the FK field is nullable. 
					relationIsWeak = false;
					if(_foreignKeyFields.Count<=0)
					{
						// no fields set, return false;
						relationIsWeak = false;
					}

					for(int j=0;j<_foreignKeyFields.Count;j++)
					{
						if(_foreignKeyFields[j].IsNullable)
						{
							// can be nulled, weak relation
							relationIsWeak=true;
							break;
						}
					}
					break;
				case RelationType.OneToMany:
					// always weak
					relationIsWeak = true;
					break;
				case RelationType.OneToOne:
					// check if the PK side is the start entity. If so, the relation is weak, otherwise the
					// relation is strong, UNLESS the FK side is nullable.
					if(_startEntityIsPkSide)
					{
						relationIsWeak = true;
					}
					else
					{
						relationIsWeak = false;
						for(int j=0;j<_foreignKeyFields.Count;j++)
						{
							if(_foreignKeyFields[j].IsNullable)
							{
								// can be nulled, weak relation
								relationIsWeak=true;
								break;
							}
						}
					}
					break;
				default:
					// default behaviour. 
					relationIsWeak = false;
					break;
			}

			return relationIsWeak;
		}


		/// <summary>
		/// Determines the alias for the side specified with the pkSide flag.
		/// </summary>
		/// <param name="pkSide">if true, the alias for teh PK side is determined, otherwise the FK side</param>
		/// <returns>the alias for the side requested</returns>
		private string DetermineAlias(bool pkSide)
		{
			string toReturn = string.Empty;

			if(pkSide)
			{
				if(_startEntityIsPkSide)
				{
					toReturn = _aliasStartEntity;
				}
				else
				{
					toReturn = _aliasEndEntity;
				}
			}
			else
			{
				if(_startEntityIsPkSide)
				{
					toReturn = _aliasEndEntity;
				}
				else
				{
					toReturn = _aliasStartEntity;
				}
			}

			if(toReturn.Length <= 0)
			{
				// if this alias is actually artificial, or has to be so, create an artificial alias instead
				if(CheckifAliasIsArtificial(pkSide))
				{
					// yes. 
					if(pkSide)
					{
						toReturn = FieldUtilities.CreateArtificialObjectAlias(GetPKEntityFieldCore(0).ActualContainingObjectName);
					}
					else
					{
						toReturn = FieldUtilities.CreateArtificialObjectAlias(GetFKEntityFieldCore(0).ActualContainingObjectName);
					}
				}
			}

			return toReturn;
		}

		
		/// <summary>
		/// Checks if the alias for the side specified is indeed an artificial alias. Artificial aliases are issued for sides which don't have
		/// an alias set and which are in a targetperentity hierarchy.
		/// </summary>
		/// <param name="pkSide">if set to <c>true</c> [pk side].</param>
		/// <returns>true if the side has an artificial alias so Alias*Side and Alias*Entity return an artificial alias. </returns>
		/// <remarks>Returns always false if artificial aliasing is disabled (default).</remarks>
		private bool CheckifAliasIsArtificial(bool pkSide)
		{
			bool toReturn = false;

			if(!_enableArtificialAliasing || (_primaryKeyFields.Count <= 0) || (_foreignKeyFields.Count <= 0))
			{
				return toReturn;
			}

			if(pkSide)
			{
				IEntityFieldCore pkField = GetPKEntityFieldCore(0);
				if(_isHierarchyRelation || ((InheritanceInfoPkSideEntity != null) && (InheritanceInfoPkSideEntity.HierarchyType == InheritanceHierarchyType.TargetPerEntity)))
				{
					if(_startEntityIsPkSide)
					{
						toReturn = ((_aliasStartEntity.Length <= 0) || _aliasStartEntity.StartsWith("LPAA_"));
					}
					else
					{
						toReturn = ((_aliasEndEntity.Length <= 0) || _aliasEndEntity.StartsWith("LPAA_"));
					}
				}
			}
			else
			{
				IEntityFieldCore fkField = GetFKEntityFieldCore(0);
				if(_isHierarchyRelation || ((InheritanceInfoFkSideEntity != null) && (InheritanceInfoFkSideEntity.HierarchyType == InheritanceHierarchyType.TargetPerEntity)))
				{
					if(_startEntityIsPkSide)
					{
						toReturn = ((_aliasEndEntity.Length <= 0) || _aliasEndEntity.StartsWith("LPAA_"));
					}
					else
					{
						toReturn = ((_aliasStartEntity.Length <= 0) || _aliasStartEntity.StartsWith("LPAA_"));
					}
				}
			}
			return toReturn;
		}


		/// <summary>
		/// Builds the custom filter. If there's a custom filter specified and one or both sides are in a targetperentityhierarchy and have a typefilter
		/// in the inheritanceinfo, these filters are merged: customfilter AND (typefilterSTART AND typeFilterEND)
		/// </summary>
		/// <returns>Ready to use custom filter.</returns>
		private IPredicateExpression BuildCustomFilter()
		{
			if(_cachedBuildCustomFilter != null)
			{
				return _cachedBuildCustomFilter;
			}

			PredicateExpression toReturn = new PredicateExpression();
			if(_customFilter != null)
			{
				toReturn.Add(_customFilter);
			}
			if((_inheritanceInfoFkSideEntity != null) && (_inheritanceInfoFkSideEntity.TypeFilterTargetPerEntityHierarchy != null))
			{
				IPredicateExpression filterFkSide = _inheritanceInfoFkSideEntity.TypeFilterTargetPerEntityHierarchy;
				if(filterFkSide.Count > 0) 
				{
					if(AliasFKSide.Length > 0)
					{
						// set alias
						if(filterFkSide[0].Contents is FieldCompareRangePredicate)
						{
							((FieldCompareRangePredicate)filterFkSide[0].Contents).FieldCore.ObjectAlias = AliasFKSide;
						}
						else
						{
							if(filterFkSide[0].Contents is FieldCompareValuePredicate)
							{
								((FieldCompareValuePredicate)filterFkSide[0].Contents).FieldCore.ObjectAlias = AliasFKSide;
							}
						}
					}
					toReturn.AddWithAnd(filterFkSide);
				}
			}
			if((_inheritanceInfoPkSideEntity != null) && (_inheritanceInfoPkSideEntity.TypeFilterTargetPerEntityHierarchy != null))
			{
				IPredicateExpression filterPkSide = _inheritanceInfoPkSideEntity.TypeFilterTargetPerEntityHierarchy;
				if(filterPkSide.Count > 0) 
				{
					if(AliasPKSide.Length > 0)
					{
						// set alias
						if(filterPkSide[0].Contents is FieldCompareRangePredicate)
						{
							((FieldCompareRangePredicate)filterPkSide[0].Contents).FieldCore.ObjectAlias = AliasPKSide;
						}
						else
						{
							if(filterPkSide[0].Contents is FieldCompareValuePredicate)
							{
								((FieldCompareValuePredicate)filterPkSide[0].Contents).FieldCore.ObjectAlias = AliasPKSide;
							}
						}
					}
					toReturn.AddWithAnd(filterPkSide);
				}
			}

			if(toReturn.Count <= 0)
			{
				return null;
			}
			else
			{
				_cachedBuildCustomFilter = toReturn;
				return toReturn;
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// The relation type the IEntityRelation instance represents.
		/// </summary>
		public RelationType TypeOfRelation 
		{ 
			get { return _typeOfRelation;}
			set { _typeOfRelation = value;}
		}

		/// <summary>
		/// Flag to signal if this relation is a 'weak' relation or not. Weak relations are optional relations, which means when A and B have a 
		/// weak relation, not all instances of A have to have a related instance of B.
		/// </summary>
		public bool IsWeak 
		{
			get { return DetermineIfIsWeak(); }
		}

		/// <summary>
		/// Returns the amount of fields in the EntityRelation object.
		/// </summary>
		public int AmountFields 
		{	
			get { return _primaryKeyFields.Count;}
		}


		/// <summary>
		/// Flag to signal the join creator logic to use the CustomFilter specified as the ON clause, instead of appending the CustomFilter to the ON
		/// clause. Ignored if CustomFilter is null or empty. Default is false.
		/// </summary>
		public bool CustomFilterReplacesOnClause 
		{
			get { return _customFilterReplacesOnClause; }
			set { _customFilterReplacesOnClause = value;}
		}


		/// <summary>
		/// Custom filter for JOIN clauses which are added with AND to the ON clause resulting from this EntityRelation. By adding a
		/// predicate expression with fieldcomparevalue predicate objects for example, you can add extra filtering inside the JOIN.
		/// </summary>
		public IPredicateExpression CustomFilter
		{
			get
			{
				return BuildCustomFilter();
			}
			set
			{
				_customFilter = value;
			}
		}


		/// <summary>
		/// Hint value for the consideration of the jointype of this relation. 
		/// Default: JoinHint.None
		/// </summary>
		public JoinHint HintForJoins
		{
			get { return _hintForJoins;}
			set {_hintForJoins = value;}
		}


		/// <summary>
		/// Alias value for the entity which is on the PK side of the relation. Determined from the relation type and the pk/fk fields
		/// </summary>
		public string AliasPKSide
		{ 
			get 
			{ 
				return DetermineAlias(true);
			}
		}
		
		
		/// <summary>
		/// Alias value for the entity which is on the FK side of the relation. Determined from the relation type and the pk/fk fields
		/// </summary>
		public string AliasFKSide
		{ 
			get 
			{ 
				return DetermineAlias(false);
			}
		}

		/// <summary>
		/// Set to true if the start entity of the relation is the PK side of the relation. This is set in the generated code. 
		/// This property is true in 1:n relations and in 1:1 relations where the start entity is the PK side and the end entity is thus the
		/// FK side. Required for determining which alias belongs to which entity.
		/// </summary>
		public bool StartEntityIsPkSide 
		{ 
			get { return _startEntityIsPkSide; }
			set { _startEntityIsPkSide = value; }
		}


		/// <summary>
		/// Gets the alias of the start entity.
		/// </summary>
		/// <value></value>
		public string AliasStartEntity
		{
			get 
			{
				return  _aliasStartEntity;
			}
		}

		/// <summary>
		/// Gets the alias of the end entity.
		/// </summary>
		/// <value></value>
		public string AliasEndEntity
		{
			get
			{
				return _aliasEndEntity;
			}
		}

		
		/// <summary>
		/// Gets or sets the inheritance info for the pk side entity.
		/// </summary>
		public IInheritanceInfo InheritanceInfoPkSideEntity 
		{
			get
			{
				return _inheritanceInfoPkSideEntity;
			}
			set
			{
				_inheritanceInfoPkSideEntity = value;
			}
		}
		/// <summary>
		/// Gets or sets the inheritance info for the fk side entity.
		/// </summary>
		public IInheritanceInfo InheritanceInfoFkSideEntity
		{
			get
			{
				return _inheritanceInfoFkSideEntity;
			}
			set
			{
				_inheritanceInfoFkSideEntity = value;
			}
		}


		/// <summary>
		/// Gets or sets the name of the field mapped onto this relation in the start entity.
		/// </summary>
		public string MappedFieldName
		{
			get { return _mappedFieldName; }
		}


		/// <summary>
		/// Gets the alias start entity internal.
		/// </summary>
		internal string AliasStartEntityInternal
		{
			get
			{
				if(StartEntityIsPkSide)
				{
					return AliasPKSide;
				}
				else
				{
					return AliasFKSide;
				}
			}
		}

		/// <summary>
		/// Gets the alias end entity internal.
		/// </summary>
		internal string AliasEndEntityInternal
		{
			get
			{
				if(StartEntityIsPkSide)
				{
					return AliasFKSide;
				}
				else
				{
					return AliasPKSide;
				}
			}
		}


		/// <summary>
		/// Gets or sets a value indicating whether this instance is a hierarchy relation.
		/// </summary>
		internal bool IsHierarchyRelation
		{
			get { return _isHierarchyRelation; }
			set { _isHierarchyRelation = value; }
		}

		#endregion
	}
}

