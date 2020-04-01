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
	/// PrefetchPathElement2 class. 
	/// </summary>
	[Serializable]
	public class PrefetchPathElement2 : IPrefetchPathElement2
	{
		#region Class Member Declarations
		private IPrefetchPath2			_subPath;
		private IEntityCollection2		_retrievalCollection;
		private IEntityRelation			_relation;
		private int						_destinationEntityType, _toFetchEntityType, _maxAmountOfItemsToReturn, _graphLevel;
		private ISortExpression			_sorter;
		private IPredicateExpression	_filter;
		private IRelationCollection		_filterRelations;
		private IEntityFactory2			_entityFactoryToUse;
		private string					_propertyName;
		private RelationType			_typeOfRelation;
		private ExcludeIncludeFieldsList _excludedIncludedFields;
		#endregion


		/// <summary>
		/// CTor. Creates a new <see cref="PrefetchPathElement"/> instance.
		/// </summary>
		/// <param name="retrievalCollection">Retrieval collection.</param>
		/// <param name="relation">Relation.</param>
		/// <param name="destinationEntityType">Destination entity type.</param>
		/// <param name="toFetchEntityType">To fetch entity type.</param>
		/// <param name="maxAmountOfItemsToReturn">Max amount of items to return.</param>
		/// <param name="sorter">Sorter.</param>
		/// <param name="filter">Filter.</param>
		/// <param name="filterRelations">Filter relations.</param>
		/// <param name="entityFactoryToUse"></param>
		/// <param name="propertyName">Name of the property the entities fetched by the definition of this path element are stored.</param>
		/// <param name="typeOfRelation">The type of relation between the entity to fetch and the entity which will hold the entity to fetch</param>
		public PrefetchPathElement2(IEntityCollection2 retrievalCollection, IEntityRelation relation, 
			int destinationEntityType, int toFetchEntityType, int maxAmountOfItemsToReturn, ISortExpression sorter, IPredicateExpression filter,
			IRelationCollection	filterRelations, IEntityFactory2 entityFactoryToUse, string propertyName, RelationType typeOfRelation)
		{
			_propertyName = propertyName;
			_graphLevel = 0;

			_subPath = new PrefetchPath2(toFetchEntityType);
			if(filterRelations==null)
			{
				_filterRelations = new RelationCollection();
			}
			else
			{
				_filterRelations = filterRelations;
			}
			_retrievalCollection = retrievalCollection;
			_relation = relation;
			_destinationEntityType = destinationEntityType;
			_toFetchEntityType = toFetchEntityType;
			_maxAmountOfItemsToReturn = maxAmountOfItemsToReturn;
			if(sorter==null)
			{
				_sorter = new SortExpression();
			}
			else
			{
				_sorter = sorter;
			}
			if(filter==null)
			{
				_filter = new PredicateExpression();
			}
			else
			{
				_filter = filter;
			}

			// retrievalCollection is already set.
			_entityFactoryToUse = entityFactoryToUse;
			if(entityFactoryToUse!=null)
			{
				_retrievalCollection.EntityFactoryToUse = entityFactoryToUse;
			}
			_typeOfRelation = typeOfRelation;
			_excludedIncludedFields = null;
		}

		
		/// <summary>
		/// Gets the hash code.
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}


		/// <summary>
		/// Compares the object passed in. Performs a compare on Property name, destination entity type and tofetch entity type
		/// </summary>
		/// <param name="obj">Obj.</param>
		/// <returns></returns>
		public override bool Equals(object obj)
		{
			PrefetchPathElement2 toCompareWith = obj as PrefetchPathElement2;
			if(toCompareWith==null)
			{
				return false;
			}
			
			return (_propertyName.Equals(toCompareWith.PropertyName) && (_destinationEntityType==toCompareWith.DestinationEntityType) && (_toFetchEntityType==toCompareWith.ToFetchEntityType));
		}


		#region Class Property Declarations
		/// <summary>
		/// The subpath containing path elements to retrieve in the ToFetch entity of this PrefetchPathElement. Can be empty.
		/// </summary>
		public IPrefetchPath2 SubPath
		{
			get
			{
				return _subPath;
			}
			set
			{
				_subPath = value;
			}
		}

		/// <summary>
		/// The entity collection to fill (and to use to retrieve the entities to fetch). After the fetch, this collection contains
		/// the entities to merge with the instances of the parent entity. 
		/// </summary>
		public IEntityCollection2 RetrievalCollection
		{
			get
			{
				return _retrievalCollection;
			}
		}

		/// <summary>
		/// The relation between the destination (parent) entity and the entity to fetch with this path element
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
		
		/// <summary>
		/// The EntityType enum value for the entity the entities to fetch are to be stored in. 
		/// </summary>
		/// <remarks>Set in the constructor</remarks>
		public int DestinationEntityType
		{
			get
			{
				return _destinationEntityType;
			}
		}


		/// <summary>
		/// The EntityType enum value for the entity to fetch defined by this path element.
		/// </summary>
		/// <remarks>Set in the constructor</remarks>
		public int ToFetchEntityType
		{
			get
			{
				return _toFetchEntityType;
			}
		}


		/// <summary>
		/// The maximum amount of entities to set per destination instance.
		/// </summary>
		public int MaxAmountOfItemsToReturn
		{
			get
			{
				return _maxAmountOfItemsToReturn;
			}
			set
			{
				_maxAmountOfItemsToReturn = value;
			}
		}


		/// <summary>
		/// The sort expression to sort the entities per destination instance. 
		/// </summary>
		public ISortExpression Sorter
		{
			get
			{
				return _sorter;
			}
			set
			{
				_sorter = value;
			}
		}


		/// <summary>
		/// The filter predicate expression to fetch the ToFetch entities. Initially this is set in the constructor.
		/// Add additional predicates to this predicate expression.
		/// </summary>
		public IPredicateExpression Filter
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
		/// The relations to use in the filters. Initially this is an empty collection, as the fetches use subqueries. 
		/// Add additional relations to this relation collection to have multi-entity filters.
		/// </summary>
		public IRelationCollection FilterRelations
		{
			get
			{
				return _filterRelations;
			}
			set
			{
				_filterRelations = value;
			}
		}


		/// <summary>
		/// The factory to use during the fetch of the entities defined by this path element. If this property is not set, the entity factory
		/// in the RetrievalCollection is used. Use this property to override the default factory, 
		/// </summary>
		public IEntityFactory2 EntityFactoryToUse 
		{
			get { return _entityFactoryToUse; }
			set 
			{
				if(value!=null)
				{
					if(_retrievalCollection!=null)
					{
						_retrievalCollection.EntityFactoryToUse = value;
					}
				}
			}
		}


		/// <summary>
		/// The name of the property which is the destination for the entities fetched by the definition of this path element.
		/// </summary>
		public string PropertyName 
		{
			get { return _propertyName;}
			set { _propertyName = value;}
		}


		/// <summary>
		/// The type of relation between the entity to fetch and the entity which will hold the entity to fetch
		/// </summary>
		public RelationType TypeOfRelation
		{
			get
			{
				return _typeOfRelation;
			}
			set
			{
				_typeOfRelation = value;
			}
		}


		/// <summary>
		/// Gets or sets the graph level.
		/// </summary>
		public int GraphLevel
		{
			get { return _graphLevel; }
			set 
			{
				_graphLevel = value;
				((PrefetchPath2)_subPath).GraphLevel = value + 1;
			}
		}
		
		/// <summary>Gets / sets the list of IEntityFieldCore objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.
		/// </summary>
		public ExcludeIncludeFieldsList ExcludedIncludedFields
		{
			get
			{
				return _excludedIncludedFields;
			}
			set
			{
				_excludedIncludedFields = value;
			}
		}
		#endregion
	}
}
