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
using System.Collections.Specialized;
using System.Configuration;
using System.Xml;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// PrefetchPath class, which specifies a prefetch path to fetch related entities during a fetch.
	/// SelfServicing specific.
	/// </summary>
	[Serializable]
	public class PrefetchPath : CollectionBase, IPrefetchPath
	{
		#region Class Member Declarations
		private int	_rootEntityType, _graphLevel;

		/// <summary>
		/// Flag to switch off the usage of the max limit and sorter used to fetch the root of the path in subqueries.
		/// The root limit and sorter is added to the subquery filtering on the root entities in v2.5 by default as an optimization.
		/// Some queries/databases can suffer from this, so this should be optional. To switch it off, add a line to the config file
		/// appSettings section: useRootMaxLimitAndSorterInPrefetchPathSubQueries. Default is false.
		/// </summary>
		/// <remarks>This optimization is switched off in v2.5. A fix is necessary in v2.6 for some situations. Enabling this
		/// could make some queries fail at runtime on sqlserver.</remarks>
		internal static bool UseRootMaxLimitAndSorterInPrefetchPathSubQueries = false;
		#endregion
		
		/// <summary>
		/// Static CTor
		/// </summary>
		static PrefetchPath()
		{
#if !CF
			NameValueCollection appSettings = ConfigurationSettings.AppSettings;
			if(appSettings!=null)
			{
				string value = appSettings["useRootMaxLimitAndSorterInPrefetchPathSubQueries"];
				if(value != null)
				{
					PrefetchPath.UseRootMaxLimitAndSorterInPrefetchPathSubQueries = XmlConvert.ToBoolean(value);
				}
			}
#endif
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rootEntityType">the entity type enum value for the entity this path is for.</param>
		public PrefetchPath(int rootEntityType)
		{
			_rootEntityType = rootEntityType;
			_graphLevel = 0;
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="rootEntityType">the entity type enum value for the entity this path is for.</param>
		public PrefetchPath(Enum rootEntityType)
		{
			_rootEntityType = (int)Enum.ToObject(rootEntityType.GetType(), rootEntityType);
			_graphLevel = 0;
		}


		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		public IPrefetchPathElement Add(IPrefetchPathElement elementToAdd)
		{
			return Add(elementToAdd, elementToAdd.MaxAmountOfItemsToReturn, elementToAdd.Filter, elementToAdd.FilterRelations, elementToAdd.Sorter, null);
		}


		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		public IPrefetchPathElement Add(IPrefetchPathElement elementToAdd, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			return Add(elementToAdd, elementToAdd.MaxAmountOfItemsToReturn, elementToAdd.Filter, elementToAdd.FilterRelations, elementToAdd.Sorter, excludedIncludedFields);
		}


		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		public IPrefetchPathElement Add(IPrefetchPathElement elementToAdd, int maxAmountOfItemsToReturn)
		{
			return Add(elementToAdd, maxAmountOfItemsToReturn, elementToAdd.Filter, elementToAdd.FilterRelations, elementToAdd.Sorter, null);
		}


		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		public IPrefetchPathElement Add(IPrefetchPathElement elementToAdd, int maxAmountOfItemsToReturn, IPredicateExpression additionalFilter)
		{
			return Add(elementToAdd, maxAmountOfItemsToReturn, additionalFilter, elementToAdd.FilterRelations, elementToAdd.Sorter, null);
		}

		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <param name="additionalFilterRelations">Additional relations to be added to the relationcollection already in the PrefetchPathElement</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		public IPrefetchPathElement Add(IPrefetchPathElement elementToAdd, int maxAmountOfItemsToReturn, 
			IPredicateExpression additionalFilter, IRelationCollection additionalFilterRelations)
		{
			return Add(elementToAdd, maxAmountOfItemsToReturn, additionalFilter, additionalFilterRelations, elementToAdd.Sorter, null);
		}

		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <param name="additionalFilterRelations">Additional relations to be added to the relationcollection already in the PrefetchPathElement</param>
		/// <param name="additionalSorter">Additional sort clauses to be added added to the sortexpression already in the PrefetchPathElement</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When the elementToAdd is a node definition which is already added to this path.</exception>
		public IPrefetchPathElement Add(IPrefetchPathElement elementToAdd, int maxAmountOfItemsToReturn, 
			IPredicateExpression additionalFilter, IRelationCollection additionalFilterRelations, ISortExpression additionalSorter)
		{
			return Add(elementToAdd, maxAmountOfItemsToReturn, additionalFilter, additionalFilterRelations, additionalSorter, null);
		}


		/// <summary>
		/// Adds the specified element to the path.
		/// </summary>
		/// <param name="elementToAdd">The PrefetchPathElement to add</param>
		/// <param name="maxAmountOfItemsToReturn">Maximum amount of items to fetch of the set of entities specified by the element.</param>
		/// <param name="additionalFilter">Additional predicate expression to be added to the filter already in the PrefetchPathElement</param>
		/// <param name="additionalFilterRelations">Additional relations to be added to the relationcollection already in the PrefetchPathElement</param>
		/// <param name="additionalSorter">Additional sort clauses to be added added to the sortexpression already in the PrefetchPathElement</param>
		/// <param name="excludedIncludedFields">The list of IEntityField objects which have to be excluded or included for the fetch. 
		/// If null or empty, all fields are fetched (default). If an instance of ExcludeIncludeFieldsList is passed in and its ExcludeContainedFields property
		/// is set to false, the fields contained in excludedIncludedFields are kept in the query, the rest of the fields in the query are excluded.</param>
		/// <returns>the element added, so chaining of commands is possible</returns>
		/// <exception cref="ArgumentException">When the elementToAdd is a node definition which is already added to this path.</exception>
		public virtual IPrefetchPathElement Add(IPrefetchPathElement elementToAdd, int maxAmountOfItemsToReturn,
			IPredicateExpression additionalFilter, IRelationCollection additionalFilterRelations, ISortExpression additionalSorter, ExcludeIncludeFieldsList excludedIncludedFields)
		{
			if(List.Contains(elementToAdd))
			{
				throw new ArgumentException("The PrefetchPathElement you to tried to add is already added to this PrefetchPath.", "elementToAdd");
			}
			List.Add(elementToAdd);

			elementToAdd.MaxAmountOfItemsToReturn = maxAmountOfItemsToReturn;

			if((additionalFilter != null) && (additionalFilter.Count > 0) && (elementToAdd.Filter != additionalFilter))
			{
				elementToAdd.Filter.Add(additionalFilter);
			}

			if((additionalFilterRelations != null) && (additionalFilterRelations.Count > 0) && (elementToAdd.FilterRelations != additionalFilterRelations))
			{
				foreach(EntityRelation relation in (RelationCollection)additionalFilterRelations)
				{
					elementToAdd.FilterRelations.Add(relation, relation.AliasStartEntity, relation.AliasEndEntity, relation.HintForJoins);
				}
			}

			if((additionalSorter != null) && (additionalSorter.Count > 0) && (additionalSorter != elementToAdd.Sorter))
			{
				for (int i = 0; i < additionalSorter.Count; i++)
				{
					elementToAdd.Sorter.Add(additionalSorter[i]);
				}
			}
			elementToAdd.ExcludedIncludedFields = excludedIncludedFields;
			elementToAdd.GraphLevel = _graphLevel;
			return elementToAdd;
		}

		
		/// <summary>
		/// Sets the graph level.
		/// </summary>
		/// <param name="level">The level.</param>
		private void SetGraphLevel(int level)
		{
			_graphLevel = level;
			foreach(PrefetchPathElement element in this)
			{
				element.GraphLevel = level;
			}
		}

		#region Class Property Declaration
		/// <summary>
		/// Indexer in the prefetch path
		/// </summary>
		public IPrefetchPathElement this[int index] 
		{
			get { return List[index] as IPrefetchPathElement;}
			set
			{
				List[index] = value;
			}
		}

		/// <summary>
		/// The EntityType enum value for the entity which is the root type of this path.
		/// </summary>
		/// <remarks>Set in the constructor</remarks>
		public int	RootEntityType 
		{ 
			get { return _rootEntityType;}
		}

		/// <summary>
		/// Gets or sets the graph level.
		/// </summary>
		internal int GraphLevel
		{
			get { return _graphLevel; }
			set 
			{ 
				SetGraphLevel(value);
			}
		}
		#endregion
	}
}