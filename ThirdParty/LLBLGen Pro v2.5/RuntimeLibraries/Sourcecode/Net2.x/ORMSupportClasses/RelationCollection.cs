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
using System.Data;
using System.Collections;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class which is used to stack relation objects between several entities to build a complete join path
	/// </summary>
	[Serializable]
	public class RelationCollection : CollectionBase, IRelationCollection
	{
		#region Class Member Declarations
		private bool				_obeyWeakRelations;

		[NonSerialized]
		private List<IDataParameter>			_customFilterParameters;
		[NonSerialized]
		private IDbSpecificCreator	_databaseSpecificCreator;
		#endregion
		
		
		/// <summary>
		/// CTor
		/// </summary>
		public RelationCollection()
		{
			InitClass();
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="RelationCollection"/> class.
		/// </summary>
		/// <param name="toAdd">IEntityRelation instance to add</param>
		public RelationCollection(IEntityRelation toAdd)
		{
			InitClass();
			if(toAdd != null)
			{
				Add(toAdd);
			}
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="RelationCollection"/> class.
		/// </summary>
		/// <param name="toAdd">IEntityRelation instance to add</param>
		/// <param name="hint">Hint to signal the join type for this relation. Overrules obeyWeakRelations, except when the hint is JoinHint.None.</param>
		public RelationCollection(IEntityRelation toAdd, JoinHint hint)
		{
			InitClass();
			if(toAdd != null)
			{
				Add(toAdd, hint);
			}
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="RelationCollection"/> class.
		/// </summary>
		/// <param name="toAdd">IEntityRelation instance to add</param>
		/// <param name="aliasRelationEndEntity">the alias for the end entity in the relation (Customer.Relations.OrderUsingCustomerID: 
		/// Order is end entity). Alias is case sensitive</param>
		/// <param name="hint">Hint to signal the join type for this relation. Overrules obeyWeakRelations, except when the hint is JoinHint.None.</param>
		public RelationCollection(IEntityRelation toAdd, string aliasRelationEndEntity, JoinHint hint)
		{
			InitClass();
			if(toAdd != null)
			{
				Add(toAdd, aliasRelationEndEntity, hint);
			}
		}


		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list. 
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <returns>the added relation in the list, so you can chain commands on 1 line</returns>
		public IEntityRelation Add(IEntityRelation relationToAdd)
		{
			return Add(relationToAdd, relationToAdd.AliasStartEntity, relationToAdd.AliasEndEntity, relationToAdd.HintForJoins);
		}


		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list. 
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <param name="hint">Hint to signal the join type for this relation. Overrules obeyWeakRelations, except when the hint is JoinHint.None.</param>
		/// <returns>the added relation in the list, so you can chain commands on 1 line</returns>
		public IEntityRelation Add(IEntityRelation relationToAdd, JoinHint hint)
		{
			return Add(relationToAdd, relationToAdd.AliasStartEntity, relationToAdd.AliasEndEntity, hint);
		}


		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list, under the alias specified for the end entity. The start entity gets no alias. 
		/// The weakness of the relation is considered based on the ObeyWeakRelations setting.
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <param name="aliasRelationEndEntity">the alias for the end entity in the relation (Customer.Relations.OrderUsingCustomerID: 
		/// Order is end entity). Alias is case sensitive</param>
		/// <returns>the added relation in the list, so you can chain commands on 1 line</returns>
		/// <exception cref="ArgumentException">when aliasRelationEndEntity is an empty string, null or otherwise unusable alias (contains spaces)</exception>
		public IEntityRelation Add(IEntityRelation relationToAdd, string aliasRelationEndEntity)
		{
			return Add(relationToAdd, relationToAdd.AliasStartEntity, aliasRelationEndEntity, relationToAdd.HintForJoins);
		}


		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list, under the alias specified for the end entity and will consider the relation's weakness 
		/// based on the hint value. The start entity gets no alias. 
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <param name="aliasRelationEndEntity">the alias for the end entity in the relation (Customer.Relations.OrderUsingCustomerID: 
		/// Order is end entity). Alias is case sensitive</param>
		/// <param name="hint">Hint to signal the join type for this relation. Overrules obeyWeakRelations, except when the hint is JoinHint.None.</param>
		/// <returns>the added relation in the list, so you can chain commands on 1 line</returns>
		/// <exception cref="ArgumentException">when aliasRelationEndEntity is an empty string, null or otherwise unusable alias (contains spaces)</exception>
		public IEntityRelation Add(IEntityRelation relationToAdd, string aliasRelationEndEntity, JoinHint hint)
		{
			return Add(relationToAdd, relationToAdd.AliasStartEntity, aliasRelationEndEntity, hint);
		}


		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list, under the aliases specified and will consider the relation's weakness 
		/// based on the hint value. The start entity gets no alias. 
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <param name="aliasRelationStartEntity">the alias for the start entity in the relation (Customer.Relations.OrderUsingCustomerID: 
		/// Customer is start entity). Alias is case sensitive</param>
		/// <param name="aliasRelationEndEntity">the alias for the end entity in the relation (Customer.Relations.OrderUsingCustomerID: 
		/// Order is end entity). Alias is case sensitive</param>
		/// <param name="hint">Hint to signal the join type for this relation. Overrules obeyWeakRelations, except when the hint is JoinHint.None.</param>
		/// <returns>the added relation in the list, so you can chain commands on 1 line</returns>
		/// <exception cref="ArgumentException">when aliasRelationEndEntity or aliasRelationStartEntity are an empty string, null or otherwise unusable 
		/// alias (contains spaces)</exception>
		public virtual IEntityRelation Add(IEntityRelation relationToAdd, string aliasRelationStartEntity, string aliasRelationEndEntity, JoinHint hint)
		{
			List.Add(relationToAdd);
			EntityRelation relation = (EntityRelation)relationToAdd;
			relation.SetAliases(aliasRelationStartEntity, aliasRelationEndEntity);
			relation.HintForJoins = hint;

			return relationToAdd;
		}

		/// <summary>
		/// Adds the range of IEntityRelation objects stored in c to this collection.
		/// </summary>
		/// <param name="c">Collection with IEntityRelation objects to add</param>
		public void AddRange(ICollection c)
		{
			InnerList.AddRange(c);
		}


		/// <summary>
		/// Adds the passed in IEntityRelation instance to the list at position index. 
		/// </summary>
		/// <param name="relationToAdd">IEntityRelation instance to add</param>
		/// <param name="index">Index to add the relation to.</param>
		public void Insert(IEntityRelation relationToAdd, int index)
		{
			List.Insert(index, relationToAdd);
		}


		/// <summary>
		/// Removes the passed in IEntityRelation instance. Only the first instance will be removed.
		/// </summary>
		/// <param name="relationToRemove">IEntityRelation instance to remove</param>
		public void Remove(IEntityRelation relationToRemove)
		{
			List.Remove(relationToRemove);
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
			foreach(EntityRelation relation in List)
			{
				relation.GetUsedEntityTypeNamesAndAliases(entityNamesPerAlias, artificialAliasPerEntity);
			}
		}


		/// <summary>
		/// Converts the set of relations to a set of nested JOIN query elements using ANSI join syntaxis. Oracle 8i doesn't support ANSI join syntaxis
		/// and therefore the OracleDQE has its own join code.
		/// It uses a database specific creator object for database specific syntaxis, like the format of the tables / views and fields. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the custom filter predicates</param>
		/// <returns>The string representation of the INNER JOIN expressions of the contained relations, when ObeyWeakRelations is set to false (default)
		/// or the string representation of the LEFT/RIGHT JOIN expressions of the contained relations, when ObeyWeakRelations is set to true</returns>
		/// <exception cref="ApplicationException">When the DatabaseSpecificCreator is not set</exception>
		/// <exception cref="ORMRelationException">when the relation set contains an error and is badly formed. For example when the relation collection
		/// contains relations which do not have an entity in common, which can happen when a bad alias is specified</exception>
		public string ToQueryText(ref int uniqueMarker)
		{
			if(_databaseSpecificCreator==null)
			{
				throw new System.ApplicationException("DatabaseSpecificCreator object not set. Cannot create query part.");
			}

			// Hashtable with the Object name + the alias as key (f.e. "[dbo].[Customers] C") and a boolean as value which signals if the
			// object is added weakly or not.
			Dictionary<string, bool> objectsWithAliasesAdded = new Dictionary<string,bool>();
			StringBuilder queryText = new StringBuilder(256);
			
			// clear any previously created objects
			_customFilterParameters = new List<IDataParameter>();
			RelationCollection relationsToWalk = PreprocessRelations();

			int numberOfRelationsProcessed = 0;
			for(int i=0;i<relationsToWalk.Count;i++)
			{
				EntityRelation relation = (EntityRelation)relationsToWalk[i];
				string	pkElement, fkElement, aliasPKSide, aliasFKSide, pkElementReference, fkElementReference, joinTypeFKJoin, joinTypePKJoin, 
						tableHintPKSide, tableHintFKSide;
				bool pkElementAddedWeak=false, fkElementAddedWeak=false, addFKSide=true, addPKSide=true, relationChainIsWeak=false;

				tableHintFKSide = string.Empty; 
				tableHintPKSide = string.Empty;

				// construct the "PKelement jointype JOIN FKelement" join fragment
				aliasPKSide = relation.AliasPKSide;
				aliasFKSide = relation.AliasFKSide;
				relation.ResetArtificialAliases();
				// find real aliases using databasespecificcreator's scopes
				aliasPKSide = _databaseSpecificCreator.FindRealAlias(relation.GetPKEntityFieldCore(0).ContainingObjectName, aliasPKSide, relation.GetPKEntityFieldCore(0).ActualContainingObjectName);
				aliasFKSide = _databaseSpecificCreator.FindRealAlias(relation.GetFKEntityFieldCore(0).ContainingObjectName, aliasFKSide, relation.GetFKEntityFieldCore(0).ActualContainingObjectName);
				pkElement = _databaseSpecificCreator.CreateObjectName(relation.GetPKFieldPersistenceInfo(0));
				fkElement = _databaseSpecificCreator.CreateObjectName(relation.GetFKFieldPersistenceInfo(0));
				pkElementReference = pkElement;
				fkElementReference = fkElement;

				// determine the joinType. joins are by definition done as: PKside join FKside. If start entity is FK side, jointype is different 
				// from join hint, if hint is left/right. joinTypePKJoin is used when only the PK side can be joined, otherwise the joinTypeFKjoin is used.
				switch(relation.HintForJoins)
				{
					case JoinHint.Left:
						if(relation.StartEntityIsPkSide)
						{
							joinTypeFKJoin = "LEFT";
							joinTypePKJoin = "RIGHT";
						}
						else
						{
							joinTypeFKJoin = "RIGHT";
							joinTypePKJoin = "LEFT";
						}
						break;
					case JoinHint.Right:
						if(relation.StartEntityIsPkSide)
						{
							joinTypeFKJoin = "RIGHT";
							joinTypePKJoin = "LEFT";
						}
						else
						{
							joinTypeFKJoin = "LEFT";
							joinTypePKJoin = "RIGHT";
						}
						break;
					case JoinHint.Cross:
						joinTypeFKJoin = "CROSS";
						joinTypePKJoin = "CROSS";
						break;
					default:
						joinTypeFKJoin = "INNER";
						joinTypePKJoin = "INNER";
						break;
				}

				if(aliasPKSide.Length>0)
				{
					aliasPKSide = _databaseSpecificCreator.CreateValidAlias(aliasPKSide);
					pkElement+= " " + aliasPKSide;
					pkElementReference = aliasPKSide;
				}

				if(aliasFKSide.Length>0)
				{
					aliasFKSide = _databaseSpecificCreator.CreateValidAlias(aliasFKSide);
					fkElement+= " " + aliasFKSide;
					fkElementReference = aliasFKSide;
				}
				bool pkSideAlreadyAdded = objectsWithAliasesAdded.ContainsKey(pkElement);
				bool fkSideAlreadyAdded = objectsWithAliasesAdded.ContainsKey(fkElement);
				if(pkSideAlreadyAdded && fkSideAlreadyAdded)
				{
					// no element to add
					continue;
				}

				IDbSpecificHintCreator hintCreator = _databaseSpecificCreator as IDbSpecificHintCreator;
				if(hintCreator!=null)
				{
					tableHintFKSide = hintCreator.CreateHintStatement(RdbmsHint.TableInFromClauseHint, null);
					tableHintPKSide = hintCreator.CreateHintStatement(RdbmsHint.TableInFromClauseHint, null);
				}

				// check if PK side or FK side are already added to the query text. If so, and if we're not the first iteration,
				// we can drop the side already added. 
				if(i>0)
				{
					if(pkSideAlreadyAdded)
					{
						// PK side already added 
						addPKSide = false;
						relationChainIsWeak = (bool)objectsWithAliasesAdded[pkElement];
					}
					else
					{
						// pk side is not yet added and will be added, fk side has to be in the list of already added elements. If not, the relation
						// set contains an error (FROM A INNER JOIN B ON A.x = B.x INNER JOIN D on C.x = D.x -> error, C is not in the list)
						if(!fkSideAlreadyAdded)
						{
							// not added as well. Error
							throw new ORMRelationException("Relation at index " + i + " doesn't contain an entity already added to the FROM clause. Bad alias?");
						}
						relationChainIsWeak = (bool)objectsWithAliasesAdded[fkElement];
						addFKSide = false;
					}
				}

				if(!addFKSide && !addPKSide)
				{
					// neither side will be added, continue
					continue;
				}

				// process weakness of the relation if _obeyWeakRelations is set and join hint is not set to a hint and the relation is weak.
				if( _obeyWeakRelations && (relation.IsWeak || relationChainIsWeak) && relation.HintForJoins==JoinHint.None)
				{
					if(relation.TypeOfRelation==RelationType.ManyToOne)
					{
						// Always join towards the FK in this situation (m:1 relation).
						// Order.CustomerID - Customer.CustomerID, where Order.CustomerID can be null
						// PK side is mentioned first, FK side is mentioned second, so a RIGHT join will
						// include all elements of the FK side, in this case Order, despite a NULL.
						pkElementAddedWeak=true;
						fkElementAddedWeak=false;

						// swap join type from RIGHT to LEFT for PK join, as the join order of the elements will then changes: 
						// not: PK right join FK, but FK LEFT JOIN PK, as FK side is then already in the join list.
						joinTypeFKJoin = "RIGHT";
						joinTypePKJoin = "LEFT";
					}
					else
					{
						// Always join towards the PK in this situation (1:n or 1:1 relation)
						pkElementAddedWeak=false;
						fkElementAddedWeak=true;

						// swap join type from LEFT to RIGHT for PK join, as the join order of the elements changes: 
						// not: PK left join FK, but FK RIGHT JOIN PK, as FK side is then already in the join list.
						joinTypeFKJoin = "LEFT";
						joinTypePKJoin = "RIGHT";
					}
				}

				if(addFKSide)
				{
					objectsWithAliasesAdded[fkElement] = fkElementAddedWeak;
				}
				if(addPKSide)
				{
					objectsWithAliasesAdded[pkElement] = pkElementAddedWeak;
				}

				// construct query elements
				if(addPKSide && addFKSide)
				{
					queryText.AppendFormat(null, " {0} {1} {2} JOIN {3} {4}", pkElement, tableHintPKSide, joinTypeFKJoin, fkElement, tableHintFKSide);
				}
				else
				{
					if(addPKSide)
					{
						// pk side only
						queryText.AppendFormat(null, " {0} JOIN {1} {2}", joinTypePKJoin, pkElement, tableHintPKSide);
					}
					else
					{
						// fk side only
						queryText.AppendFormat(null, " {0} JOIN {1} {2}", joinTypeFKJoin, fkElement, tableHintFKSide);
					}
				}

				// cross join doesn't have an on clause
				bool emitFieldsInOnClause = (relation.HintForJoins!=JoinHint.Cross);
				bool emitCustomFilter = false;

				numberOfRelationsProcessed++;

				if(relation.CustomFilter!=null)
				{
					if(relation.CustomFilter.Count>0)
					{
						emitFieldsInOnClause = !relation.CustomFilterReplacesOnClause;
						emitCustomFilter = true;
						relation.CustomFilter.DatabaseSpecificCreator = _databaseSpecificCreator;
					}
				}

				if(emitFieldsInOnClause)
				{
					queryText.Append(" ON ");

					// create ON clauses.
					for(int j=0;j<relation.AmountFields;j++)
					{
						if(j>0)
						{
							queryText.Append(" AND");
						}
						queryText.AppendFormat(null, " {0}.{1}={2}.{3}", 
							pkElementReference, 
							_databaseSpecificCreator.CreateFieldNameSimple(relation.GetPKFieldPersistenceInfo(j), relation.GetPKEntityFieldCore(j).Name),
							fkElementReference,
							_databaseSpecificCreator.CreateFieldNameSimple(relation.GetFKFieldPersistenceInfo(j), relation.GetFKEntityFieldCore(j).Name));
					}
				}

				// if this EntityRelation has a custom filter, add that filter with AND. 
				if(emitCustomFilter)
				{
					if( emitFieldsInOnClause )
					{
						queryText.Append( " AND" );
					}
					else
					{
						// no ON clause generated yet, emit ON first
						queryText.Append( " ON " );
					}
					relation.CustomFilter.DatabaseSpecificCreator = _databaseSpecificCreator;
					queryText.AppendFormat(null, " {0}", relation.CustomFilter.ToQueryText(ref uniqueMarker));
					// add parameters created by this custom filter to our general list.
					_customFilterParameters.AddRange(relation.CustomFilter.Parameters);
				}

				// add end bracket
				queryText.Append(")");
			}

			return new String('(', numberOfRelationsProcessed) + queryText.ToString();
		}



		/// <summary>
		/// Preprocesses the relations in this relationcollection
		/// The start/end entity can have an inheritance info object with them, causing these relations to
		/// be inserted at that spot, where the additional relations for the start entity are added BEFORE the actual relation and the relations for the
		/// end entity AFTER the actual relation.
		/// </summary>
		/// <returns>the full set of relations to process</returns>
		public RelationCollection PreprocessRelations()
		{
			RelationCollection toReturn = new RelationCollection();
			Hashtable aliasesAlreadyInJoinList = new Hashtable();
			
			// traverse the relations in this relationcollection. For each relation, first the start and end entity alias (if no alias is specified,
			// the entity name is used) are checked to see if they're already in the join list. If so, the relation is skipped. If not, if
			// one side is already in the list, the other side is used, otherwise both are used. If both are used and this isn't the first relation, an
			// exception is thrown as the relation will lead to breaks in the join chain. 
			// Joins are defined by specifying teh join operator and the target to join to the already existing list. If the list is empty the specified
			// target is used (the first join). This means that if two new targets are joined to the list, it won't work, as none of the two can be 
			// replaced by the join list. 
			int iteration = 0;
			foreach(EntityRelation currentRelation in List)
			{
				string tmpAliasStartEntity = string.Empty;
				string tmpAliasEndEntity = string.Empty;

				// Determine aliases to be used internally for this routine. If no alias is specified for an entity, we still need to store a
				// reference to that entity in the list of already seen entities. So we use this routine to determine which alias to use for that
				// particular purpose. 
				DetermineAliasesForEntities(currentRelation, ref tmpAliasStartEntity, ref tmpAliasEndEntity);

				// check which side is already in the join list.
				bool startEntityIsInJoinList = aliasesAlreadyInJoinList.ContainsKey(tmpAliasStartEntity);
				bool endEntityIsInJoinList = aliasesAlreadyInJoinList.ContainsKey(tmpAliasEndEntity);
				bool useBothSides = (iteration == 0);

				if(currentRelation.IsHierarchyRelation)
				{
					// always accept
					toReturn.Add(currentRelation, currentRelation.AliasStartEntityInternal, currentRelation.AliasEndEntityInternal, currentRelation.HintForJoins);
				}
				else
				{
					if(startEntityIsInJoinList && endEntityIsInJoinList)
					{
						// duplicate, continue
						continue;
					}
					if(!startEntityIsInJoinList && !endEntityIsInJoinList && !useBothSides)
					{
						// apparently none of the sides are in the joinlist. It can be the startentity is a subtype and a supertype is in the joinlist.
						// if that's the case, useBothSides has to be set to true and the routine should continue. If it's not the case, we've to give up
						// as it's an orphaned relation (i.e. A JOIN B, B JOIN C and then this relation is D JOIN E.)
						IInheritanceInfo infoToExamine = null;
						if(currentRelation.StartEntityIsPkSide)
						{
							infoToExamine = currentRelation.InheritanceInfoPkSideEntity;
						}
						else
						{
							infoToExamine = currentRelation.InheritanceInfoFkSideEntity;
						}
						if(infoToExamine != null)
						{
							List<string> namesToRoot = infoToExamine.EntityNamesOnHierarchyPath;
							bool superTypeIsInJoinList = false;
							foreach(string superTypeName in namesToRoot)
							{
								superTypeIsInJoinList = (aliasesAlreadyInJoinList.ContainsKey(superTypeName));
								if(superTypeIsInJoinList)
								{
									break;
								}
							}
							if(superTypeIsInJoinList)
							{
								// can be used. Set to use both sides below, so 
								useBothSides = true;
							}
						}
						if(!useBothSides)
						{
							// no solution found, give up. 
							throw new ORMRelationException("Relation at index " + iteration + " doesn't contain an entity already added to the FROM clause. Bad alias?");
						}
					}

					// The relation will be swapped later on (e.g. A left join B becomes B right join A) if the END entity is in the join list AND iteration is > 0

					// Situation 0: iteration == 0 and both end up in the join list.
					if(useBothSides)
					{
						if(currentRelation.StartEntityIsPkSide)
						{
							if(currentRelation.InheritanceInfoPkSideEntity != null)
							{
								foreach(EntityRelation subRelation in currentRelation.InheritanceInfoPkSideEntity.RelationsToHierarchyRoot)
								{
									AddSubRelationToRelationsToReturn(toReturn, aliasesAlreadyInJoinList, currentRelation.AliasStartEntityInternal,
											currentRelation.AliasStartEntityInternal, subRelation, JoinHint.None);
								}
							}
							toReturn.Add(currentRelation, currentRelation.AliasStartEntityInternal, currentRelation.AliasEndEntityInternal, currentRelation.HintForJoins);
							if(currentRelation.InheritanceInfoFkSideEntity != null)
							{
								foreach(EntityRelation subRelation in currentRelation.InheritanceInfoFkSideEntity.RelationsToHierarchyRoot)
								{
									AddSubRelationToRelationsToReturn(toReturn, aliasesAlreadyInJoinList, currentRelation.AliasEndEntityInternal,
											currentRelation.AliasEndEntityInternal, subRelation, currentRelation.HintForJoins);
								}
							}
						}
						else
						{
							if(currentRelation.InheritanceInfoFkSideEntity != null)
							{
								foreach(EntityRelation subRelation in currentRelation.InheritanceInfoFkSideEntity.RelationsToHierarchyRoot)
								{
									AddSubRelationToRelationsToReturn(toReturn, aliasesAlreadyInJoinList, currentRelation.AliasStartEntityInternal,
											currentRelation.AliasStartEntityInternal, subRelation, JoinHint.None);
								}
							}
							toReturn.Add(currentRelation, currentRelation.AliasStartEntityInternal, currentRelation.AliasEndEntityInternal, currentRelation.HintForJoins);
							if(currentRelation.InheritanceInfoPkSideEntity != null)
							{
								foreach(EntityRelation subRelation in currentRelation.InheritanceInfoPkSideEntity.RelationsToHierarchyRoot)
								{
									AddSubRelationToRelationsToReturn(toReturn, aliasesAlreadyInJoinList, currentRelation.AliasEndEntityInternal,
											currentRelation.AliasEndEntityInternal, subRelation, currentRelation.HintForJoins);
								}
							}
						}
					}
					else
					{
						if(endEntityIsInJoinList)
						{
							// situation 2. SWAP start and end. This means that the relation will be used FIRST and the start entity's relations to the
							// root of the hierarchy (if any) will be appended afterwards, instead of having these be appended first and the current relation
							// be appended after that. The end entity's relations aren't added, as the end entity is already in the joinlist and therefore won't 
							// show up in the join list anyway and neither the relations as they're already in the joinlist as well. 
							if(currentRelation.StartEntityIsPkSide)
							{
								toReturn.Add(currentRelation, currentRelation.AliasStartEntityInternal, currentRelation.AliasEndEntityInternal, currentRelation.HintForJoins);
								if(currentRelation.InheritanceInfoPkSideEntity != null)
								{
									foreach(EntityRelation subRelation in currentRelation.InheritanceInfoPkSideEntity.RelationsToHierarchyRoot)
									{
										AddSubRelationToRelationsToReturn(toReturn, aliasesAlreadyInJoinList, currentRelation.AliasStartEntityInternal,
												currentRelation.AliasStartEntityInternal, subRelation, JoinHint.None);
									}
								}
							}
							else
							{
								toReturn.Add(currentRelation, currentRelation.AliasStartEntityInternal, currentRelation.AliasEndEntityInternal, currentRelation.HintForJoins);
								if(currentRelation.InheritanceInfoFkSideEntity != null)
								{
									foreach(EntityRelation subRelation in currentRelation.InheritanceInfoFkSideEntity.RelationsToHierarchyRoot)
									{
										AddSubRelationToRelationsToReturn(toReturn, aliasesAlreadyInJoinList, currentRelation.AliasStartEntityInternal,
												currentRelation.AliasStartEntityInternal, subRelation, JoinHint.None);
									}
								}
							}
						}
						else
						{
							// situation 3: use just the end entity
							if(currentRelation.StartEntityIsPkSide)
							{
								toReturn.Add(currentRelation, currentRelation.AliasStartEntityInternal, currentRelation.AliasEndEntityInternal, currentRelation.HintForJoins);
								if(currentRelation.InheritanceInfoFkSideEntity != null)
								{
									foreach(EntityRelation subRelation in currentRelation.InheritanceInfoFkSideEntity.RelationsToHierarchyRoot)
									{
										AddSubRelationToRelationsToReturn(toReturn, aliasesAlreadyInJoinList, currentRelation.AliasEndEntityInternal,
												currentRelation.AliasEndEntityInternal, subRelation, currentRelation.HintForJoins);
									}
								}
							}
							else
							{
								toReturn.Add(currentRelation, currentRelation.AliasStartEntityInternal, currentRelation.AliasEndEntityInternal, currentRelation.HintForJoins);
								if(currentRelation.InheritanceInfoPkSideEntity != null)
								{
									foreach(EntityRelation subRelation in currentRelation.InheritanceInfoPkSideEntity.RelationsToHierarchyRoot)
									{
										AddSubRelationToRelationsToReturn(toReturn, aliasesAlreadyInJoinList, currentRelation.AliasEndEntityInternal,
												currentRelation.AliasEndEntityInternal, subRelation, currentRelation.HintForJoins);
									}
								}
							}
						}
					}
				}
				aliasesAlreadyInJoinList[tmpAliasStartEntity] = null;
				aliasesAlreadyInJoinList[tmpAliasEndEntity] = null;
				iteration++;
			}
			return toReturn;
		}


		/// <summary>
		/// Enables / disables the artificial aliasing for target per entity relations. This method is used to enable the artificial aliasing of entities which
		/// are in a hierarchy of TargetPerEntity and which are in the relations of this collection. This is switched on for dyn/typedlist fetches to be sure 
		/// dyn/typedlists with fields from multiple entities in the same inheritance hierarchy will be retrievable properly, as they need aliasing under the hood
		/// but if the developer didn't alias the entities, the query will fail because the supertype(s) aren't joined multiple types. 
		/// </summary>
		/// <param name="enable">if set to true, enable artificial aliasing, otherwise false (default).</param>
		/// <remarks>Artificial aliasing is disabled by default</remarks>
		internal void ToggleArtificialAliasingForTargetPerEntityRelations(bool enable)
		{
			foreach(EntityRelation relation in this)
			{
				relation.ToggleArtificialAliasingForTargetPerEntityRelations(enable);
			}
		}


		/// <summary>
		/// Adds the sub relation to the relations to return collection.
		/// </summary>
		/// <param name="toReturn">To return.</param>
		/// <param name="aliasesAlreadyInJoinList">The aliases already in join list.</param>
		/// <param name="startEntityAlias">The start entity alias.</param>
		/// <param name="endEntityAlias">The end entity alias.</param>
		/// <param name="subRelation">The sub relation.</param>
		/// <param name="hintForJoins">The hint for joins.</param>
		private void AddSubRelationToRelationsToReturn(RelationCollection toReturn, Hashtable aliasesAlreadyInJoinList, 
				string startEntityAlias, string endEntityAlias, EntityRelation subRelation, JoinHint hintForJoins)
		{
			string aliasStartEntitySubRelation = string.Empty;
			string aliasEndEntitySubRelation = string.Empty;

			DetermineAliasesForEntities(subRelation, ref aliasStartEntitySubRelation, ref aliasEndEntitySubRelation);
			// pass the same join hint, to avoid making the actual relation's joinhint void.
			toReturn.Add(subRelation, startEntityAlias, endEntityAlias, hintForJoins);
			aliasesAlreadyInJoinList[aliasStartEntitySubRelation + startEntityAlias] = null;
			aliasesAlreadyInJoinList[aliasEndEntitySubRelation + endEntityAlias] = null;
		}
		

		/// <summary>
		/// Determines the aliases for the entities in the relation passed in.
		/// </summary>
		/// <param name="relation">The relation.</param>
		/// <param name="aliasStartEntity">The alias for the start entity of the relation.</param>
		/// <param name="aliasEndEntity">The alias for the end entity of the relation.</param>
		private void DetermineAliasesForEntities(EntityRelation relation, ref string aliasStartEntity, ref string aliasEndEntity)
		{
			aliasStartEntity = relation.AliasStartEntityInternal;
			aliasEndEntity = relation.AliasEndEntityInternal;

			if(aliasStartEntity.Length <= 0)
			{
				// determine the entity name
				if(relation.StartEntityIsPkSide)
				{
					// if there's inheritance info, use the ownername of the inheritance info, otherwise we can use the field's containing object name.
					if(relation.InheritanceInfoPkSideEntity != null)
					{
						aliasStartEntity = relation.InheritanceInfoPkSideEntity.OwnerEntityName;
					}
					else
					{
						aliasStartEntity = relation.GetPKEntityFieldCore(0).ActualContainingObjectName;
					}
				}
				else
				{
					if(relation.InheritanceInfoFkSideEntity != null)
					{
						aliasStartEntity = relation.InheritanceInfoFkSideEntity.OwnerEntityName;

					}
					else
					{
						aliasStartEntity = relation.GetFKEntityFieldCore(0).ActualContainingObjectName;
					}
				}
			}

			if(aliasEndEntity.Length <= 0)
			{
				// determine the entity name
				if(relation.StartEntityIsPkSide)
				{
					// if there's inheritance info, use the ownername of the inheritance info, otherwise we can use the field's containing object name.
					if(relation.InheritanceInfoFkSideEntity != null)
					{
						aliasEndEntity = relation.InheritanceInfoFkSideEntity.OwnerEntityName;
					}
					else
					{
						aliasEndEntity = relation.GetFKEntityFieldCore(0).ActualContainingObjectName;
					}
				}
				else
				{
					if(relation.InheritanceInfoPkSideEntity != null)
					{
						aliasEndEntity = relation.InheritanceInfoPkSideEntity.OwnerEntityName;
					}
					else
					{
						aliasEndEntity = relation.GetPKEntityFieldCore(0).ActualContainingObjectName;
					}
				}
			}
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		private void InitClass()
		{
			_obeyWeakRelations = false;
			_customFilterParameters = new List<IDataParameter>();
		}


		#region Class Property Declarations
		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		public IDbSpecificCreator DatabaseSpecificCreator
		{
			get { return _databaseSpecificCreator; }
			set 
			{ 
				_databaseSpecificCreator = value; 
				if(value!=null)
				{
					((DbSpecificCreatorBase)_databaseSpecificCreator).ProduceAliasScopeData(this);
				}
			}
		}

		/// <summary>
		/// Indexer in the collection.
		/// </summary>
		public IEntityRelation this [int index]
		{
			get { return (IEntityRelation)this.List[index]; }
			set { List[index] = value;}
		}

		/// <summary>
		/// Gets / sets ObeyWeakRelations, which is the flag to signal the collection what kind of join statements to generate in the
		/// ToQueryText statement, which is called by the DQE. Weak relationships are relationships which are optional, for example a
		/// customer with no orders is possible, because the relationship between customer and order is based on a field in order.
		/// When this property is set to true (default: false), weak relationships will result in LEFT JOIN statements. When
		/// set to false (which is the default), INNER JOIN statements are used.
		/// </summary>
		public bool ObeyWeakRelations
		{
			get
			{
				return _obeyWeakRelations;
			}
			set
			{
				_obeyWeakRelations = value;
			}
		}


		/// <summary>
		/// Gets Custom Filter Parameters, created in ToQueryText and which are used in custom filters.
		/// </summary>
		public List<IDataParameter> CustomFilterParameters
		{
			get
			{
				return _customFilterParameters;
			}
		}
		#endregion
	}
}
