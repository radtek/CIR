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
using System.Collections;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Callback for the AggregateSetPredicate, which is used to aggregate over the set of values passed in. 
	/// </summary>
	/// <param name="valuesToAggregate">the values to aggregate. </param>
	/// <returns>the aggregation result of the values passed in.</returns>
	public delegate object AggregateSetPredicateCallback(IList valuesToAggregate);
	/// <summary>
	/// Callback for the AggregateSetPredicate, which is used to interpret a passed in entity and return the value to add to the set of values to aggregate
	/// in the AggregateSetPredicate. 
	/// </summary>
	/// <param name="toInterpret">The entity to interpret</param>
	/// <returns>the interpretation result of the passed in entity. This value is then added to the list of values to aggregate in the AggregateSetPredicate</returns>
	public delegate object InterpretSetValueCallback(IEntityCore toInterpret);
	/// <summary>
	/// Callback for the DelegatePredicate, which is used to perform the interpretation of the passed in entity. 
	/// </summary>
	/// <param name="toInterpret">The entity to interpret</param>
	/// <returns>true if the entity is accepted by the callback, otherwise false.</returns>
	public delegate bool DelegatePredicateCallback(IEntityCore toInterpret);

	/// <summary>
	/// EventArgs class for events raised by the entity collection classes for various actions. 
	/// </summary>
	public class CollectionChangedEventArgs : EventArgs
	{
		#region Class Member Declarations
		private IEntityCore _involvedEntity;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="CollectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		public CollectionChangedEventArgs( IEntityCore involvedEntity )
		{
			_involvedEntity = involvedEntity;
		}

		/// <summary>
		/// Gets / sets the entity involved in the action which took place and which triggered the raised event.
		/// </summary>
		public IEntityCore InvolvedEntity
		{
			get
			{
				return _involvedEntity;
			}
			set
			{
				_involvedEntity = value;
			}
		}
	}


	/// <summary>
	/// Event args class which is used with LLBLGenProDataSource(2) action events. This is the non-cancelable variant. 
	/// </summary>
	public class DataSourceActionEventArgs : EventArgs
	{
		#region Class Member Declarations
		private IEntityCore _involvedEntity;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="DataSourceActionEventArgs"/> class.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		public DataSourceActionEventArgs(IEntityCore involvedEntity)
		{
			_involvedEntity = involvedEntity;
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets involvedEntity
		/// </summary>
		public IEntityCore InvolvedEntity
		{
			get
			{
				return _involvedEntity;
			}
			set
			{
				_involvedEntity = value;
			}
		}
		#endregion
	}


	/// <summary>
	/// Event args class which is the cancelable variant of the DataSourceActionEventArgs event args class
	/// </summary>
	public class CancelableDataSourceActionEventArgs : DataSourceActionEventArgs
	{
		#region Class Property Declarations
		private bool _cancel;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="CancelableDataSourceActionEventArgs"/> class.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		public CancelableDataSourceActionEventArgs(IEntityCore involvedEntity)
			: base(involvedEntity)
		{
			_cancel = false;
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets the cancel flag to cancel the action.
		/// </summary>
		public bool Cancel
		{
			get
			{
				return _cancel;
			}
			set
			{
				_cancel = value;
			}
		}
		#endregion
	}


	/// <summary>
	/// Event args which are used for collection changed events and which is raised by cancelable actions. Set the Cancel flag to cancel the action
	/// which raised the event. 
	/// </summary>
	public class CancelableCollectionChangedEventArgs : CollectionChangedEventArgs
	{
		#region Class Member Declarations
		private bool _cancel;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="CancelableCollectionChangedEventArgs"/> class.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		public CancelableCollectionChangedEventArgs( IEntityCore involvedEntity )
			: base( involvedEntity )
		{
			_cancel = false;
		}

		/// <summary>
		/// Gets / sets the cancel flag to cancel the action.
		/// </summary>
		public bool Cancel
		{
			get
			{
				return _cancel;
			}
			set
			{
				_cancel = value;
			}
		}
	}


	/// <summary>
	/// Event arguments class which is passed as argument in the PerformDbCount event on an LLBLGenProDataSource2 control.
	/// </summary>
	public class PerformGetDbCountEventArgs2 : EventArgs
	{
		#region Class Member Declarations
		private DataSourceDataContainerType _dataContainerType;
		private IEntityCollection2 _containedCollection;
		private IRelationPredicateBucket _filter;
		private IEntityFields2 _fields;
		private IGroupByCollection _groupBy;
		private int _dbCount;
		private bool _allowDuplicates;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="PerformGetDbCountEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="containedCollection">The contained collection.</param>
		public PerformGetDbCountEventArgs2( IRelationPredicateBucket filter, IEntityCollection2 containedCollection )
		{
			InitClass( filter, containedCollection, null, false, DataSourceDataContainerType.EntityCollection, null );
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="PerformGetDbCountEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="allowDuplicates">if set to <c>true</c> [allow duplicates].</param>
		/// <param name="groupBy">The group by.</param>
		public PerformGetDbCountEventArgs2( IRelationPredicateBucket filter, IEntityFields2 fields, bool allowDuplicates, IGroupByCollection groupBy)
		{
			InitClass( filter, null, fields, allowDuplicates, DataSourceDataContainerType.TypedList, groupBy );
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="PerformGetDbCountEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="groupBy">The group by.</param>
		public PerformGetDbCountEventArgs2( IRelationPredicateBucket filter, IEntityFields2 fields, IGroupByCollection groupBy)
		{
			InitClass( filter, null, fields, true, DataSourceDataContainerType.TypedView, groupBy );
		}

		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="containedCollection">The contained collection.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="allowDuplicates">if set to <c>true</c> [allow duplicates].</param>
		/// <param name="dataContainerType">Type of the data container.</param>
		/// <param name="groupBy">The group by.</param>
		private void InitClass( IRelationPredicateBucket filter, IEntityCollection2 containedCollection, IEntityFields2 fields, bool allowDuplicates, 
				DataSourceDataContainerType dataContainerType, IGroupByCollection groupBy )
		{
			_dataContainerType = dataContainerType;
			_containedCollection = containedCollection;
			_fields = fields;
			_filter = filter;
			_allowDuplicates = allowDuplicates;
			_groupBy = groupBy;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the GroupByCollection to use for the DbCount fetch. Only valid if DataContainerType is set to TypedList or TypedView.
		/// </summary>
		public IGroupByCollection GroupBy
		{
			get { return _groupBy; }
		}

		/// <summary>
		/// Gets a value indicating whether duplicates should be considered in the DbCount fetch. Only valid if DataContainerType is set to Typedlist
		/// </summary>
		public bool AllowDuplicates
		{
			get { return _allowDuplicates; }
		}

		/// <summary>
		/// Gets or sets the db count retrieved.
		/// </summary>
		/// <value>The db count.</value>
		public int DbCount
		{
			get { return _dbCount; }
			set { _dbCount = value; }
		}

		/// <summary>
		/// Gets the type of the data container. Use this value to determine which values to retrieve from this event arguments object to perform the GetDbCount action
		/// </summary>
		/// <value>The type of the data container.</value>
		public DataSourceDataContainerType DataContainerType
		{
			get { return _dataContainerType; }
		}

		/// <summary>
		/// Gets the contained collection in the data source control
		/// </summary>
		/// <value>The contained collection.</value>
		public IEntityCollection2 ContainedCollection
		{
			get { return _containedCollection; }
		}

		/// <summary>
		/// Gets the filter.
		/// </summary>
		/// <value>The filter.</value>
		public IRelationPredicateBucket Filter
		{
			get { return _filter; }
		}

		/// <summary>
		/// Gets the fields for TypedList or TypedView fetches.
		/// </summary>
		/// <value>The fields.</value>
		public IEntityFields2 Fields
		{
			get { return _fields; }
		}

		#endregion
	}

	/// <summary>
	/// Event arguments class which is passed as argument in the PerformSelect event on an LLBLGenProDataSource2 control
	/// </summary>
	/// <remarks>Adapter specific</remarks>
	public class PerformSelectEventArgs2 : EventArgs
	{
		#region Class Member Declarations
		private DataSourceDataContainerType _dataContainerType;
		private IEntityCollection2 _containedCollection;
		private ITypedListLgp2 _containedTypedList;
		private ITypedView2 _containedTypedView;
		private IRelationPredicateBucket _filter;
		private int _maxNumberOfItemsToReturn, _pageNumber, _pageSize;
		private ISortExpression _sorter;
		private IEntityFields2 _fields;
		private bool _allowDuplicates;
		private IGroupByCollection _groupBy;
		private IPrefetchPath2 _prefetchPath;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="PerformSelectEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="containedCollection">The contained collection.</param>
		/// <param name="prefetchPath">The prefetch path.</param>
		public PerformSelectEventArgs2( IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, int pageSize, int pageNumber, ISortExpression sorter,
				IEntityCollection2 containedCollection, IPrefetchPath2 prefetchPath )
		{
			InitClass( filter, maxNumberOfItemsToReturn, pageNumber, pageSize, sorter, containedCollection, null, null, null, false, DataSourceDataContainerType.EntityCollection, 
					prefetchPath, null );
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PerformSelectEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="containedTypedList">The contained typed list.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="allowDuplicates">if set to <c>true</c> [allow duplicates].</param>
		/// <param name="groupBy">The group by.</param>
		public PerformSelectEventArgs2( IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, int pageSize, int pageNumber, ISortExpression sorter,
				ITypedListLgp2 containedTypedList, IEntityFields2 fields, bool allowDuplicates, IGroupByCollection groupBy)
		{
			InitClass( filter, maxNumberOfItemsToReturn, pageNumber, pageSize, sorter, null, containedTypedList, null, fields, allowDuplicates, DataSourceDataContainerType.TypedList, null, groupBy );
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PerformSelectEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="containedTypedView">The contained typed view.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="groupBy">The group by.</param>
		public PerformSelectEventArgs2( IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, int pageSize, int pageNumber, ISortExpression sorter,
				ITypedView2 containedTypedView, IEntityFields2 fields, IGroupByCollection groupBy )
		{
			InitClass( filter, maxNumberOfItemsToReturn, pageNumber, pageSize, sorter, null, null, containedTypedView, fields, true, DataSourceDataContainerType.TypedView, null, groupBy  );
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="containedCollection">The contained collection.</param>
		/// <param name="containedTypedList">The contained typed list.</param>
		/// <param name="containedTypedView">The contained typed view.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="allowDuplicates">if set to <c>true</c> [allow duplicates].</param>
		/// <param name="dataSourceDataContainerType">Type of the data source data container.</param>
		/// <param name="prefetchPath">The prefetch path.</param>
		/// <param name="groupBy">The group by.</param>
		private void InitClass( IRelationPredicateBucket filter, int maxNumberOfItemsToReturn, int pageNumber, int pageSize, 
				ISortExpression sorter, IEntityCollection2 containedCollection, ITypedListLgp2 containedTypedList, ITypedView2 containedTypedView,
				IEntityFields2 fields, bool allowDuplicates, DataSourceDataContainerType dataSourceDataContainerType, IPrefetchPath2 prefetchPath, IGroupByCollection groupBy )
		{
			_fields = fields;
			_filter = filter;
			_maxNumberOfItemsToReturn = maxNumberOfItemsToReturn;
			_pageNumber = pageNumber;
			_pageSize = pageSize;
			_allowDuplicates = allowDuplicates;
			_sorter = sorter;
			_containedCollection = containedCollection;
			_containedTypedList = containedTypedList;
			_containedTypedView = containedTypedView;
			_dataContainerType = dataSourceDataContainerType;
			_prefetchPath = prefetchPath;
			_groupBy = groupBy;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the GroupByCollection to use for the fetch. Only valid if DataContainerType is set to TypedList or TypedView.
		/// </summary>
		public IGroupByCollection GroupBy
		{
			get { return _groupBy; }
		}

		/// <summary>
		/// Gets the prefetch path to use for the fetch. Only valid if DataContainerType is set to EntityCollection. 
		/// </summary>
		/// <value>The prefetch path.</value>
		public IPrefetchPath2 PrefetchPath
		{
			get { return _prefetchPath;}
		}

		/// <summary>
		/// Gets a value indicating whether duplicates should be considered in the fetch. Only valid if DataContainerType is set to Typedlist
		/// </summary>
		public bool AllowDuplicates
		{
			get { return _allowDuplicates; }
		}

		/// <summary>
		/// Gets the type of the data container. Use this value to determine which values to retrieve from this event arguments object to perform the select action
		/// </summary>
		/// <value>The type of the data container.</value>
		public DataSourceDataContainerType DataContainerType
		{
			get { return _dataContainerType; }
		}

		/// <summary>
		/// Gets the contained collection in the data source control
		/// </summary>
		/// <value>The contained collection.</value>
		public IEntityCollection2 ContainedCollection
		{
			get { return _containedCollection; }
		}

		/// <summary>
		/// Gets the contained typed list in the data source control
		/// </summary>
		/// <value>The contained typed list.</value>
		public ITypedListLgp2 ContainedTypedList
		{
			get { return _containedTypedList; }
		}

		/// <summary>
		/// Gets the contained typed view in the data source control
		/// </summary>
		/// <value>The contained typed view.</value>
		public ITypedView2 ContainedTypedView
		{
			get { return _containedTypedView; }
		}

		/// <summary>
		/// Gets the filter.
		/// </summary>
		/// <value>The filter.</value>
		public IRelationPredicateBucket Filter
		{
			get { return _filter; }
		}

		/// <summary>
		/// Gets the max number of items to return.
		/// </summary>
		/// <value>The max number of items to return.</value>
		public int MaxNumberOfItemsToReturn
		{
			get { return _maxNumberOfItemsToReturn; }
		}

		/// <summary>
		/// Gets the page number for paging. 
		/// </summary>
		/// <value>The page number.</value>
		public int PageNumber
		{
			get { return _pageNumber; }
		}

		/// <summary>
		/// Gets the page size for paging. 
		/// </summary>
		/// <value>The size of the page.</value>
		public int PageSize
		{
			get { return _pageSize; }
		}

		/// <summary>
		/// Gets the sortexpression.
		/// </summary>
		/// <value>The sorter.</value>
		public ISortExpression Sorter
		{
			get { return _sorter; }
		}

		/// <summary>
		/// Gets the fields for TypedList or TypedView fetches.
		/// </summary>
		/// <value>The fields.</value>
		public IEntityFields2 Fields
		{
			get { return _fields; }
		}

		#endregion
	}

	
	/// <summary>
	/// Event arguments class which is passed as argument in the PerformDbCount event on an LLBLGenProDataSource control.
	/// </summary>
	public class PerformGetDbCountEventArgs : EventArgs
	{
		#region Class Member Declarations
		private DataSourceDataContainerType _dataContainerType;
		private IEntityCollection _containedCollection;
		private IPredicateExpression _filter;
		private IRelationCollection _relations;
		private IEntityFields _fields;
		private IGroupByCollection _groupBy;
		private int _dbCount;
		private bool _allowDuplicates;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="PerformGetDbCountEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="containedCollection">The contained collection.</param>
		public PerformGetDbCountEventArgs( IPredicateExpression filter, IRelationCollection relations, IEntityCollection containedCollection )
		{
			InitClass( filter, relations, containedCollection, null, false, DataSourceDataContainerType.EntityCollection, null );
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="PerformGetDbCountEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="allowDuplicates">if set to <c>true</c> [allow duplicates].</param>
		/// <param name="groupBy">The group by.</param>
		public PerformGetDbCountEventArgs( IPredicateExpression filter, IRelationCollection relations, IEntityFields fields, bool allowDuplicates, 
				IGroupByCollection groupBy )
		{
			InitClass( filter, relations, null, fields, allowDuplicates, DataSourceDataContainerType.TypedList, groupBy );
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="PerformGetDbCountEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="groupBy">The group by.</param>
		public PerformGetDbCountEventArgs( IPredicateExpression filter, IRelationCollection relations, IEntityFields fields, IGroupByCollection groupBy )
		{
			InitClass( filter, relations, null, fields, true, DataSourceDataContainerType.TypedView, groupBy );
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="containedCollection">The contained collection.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="allowDuplicates">if set to <c>true</c> [allow duplicates].</param>
		/// <param name="dataContainerType">Type of the data container.</param>
		/// <param name="groupBy">The group by.</param>
		private void InitClass( IPredicateExpression filter, IRelationCollection relations, IEntityCollection containedCollection, IEntityFields fields, 
				bool allowDuplicates, DataSourceDataContainerType dataContainerType, IGroupByCollection groupBy )
		{
			_dataContainerType = dataContainerType;
			_containedCollection = containedCollection;
			_fields = fields;
			_filter = filter;
			_allowDuplicates = allowDuplicates;
			_groupBy = groupBy;
			_relations = relations;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the relations.
		/// </summary>
		/// <value>The relations.</value>
		public IRelationCollection Relations
		{
			get { return _relations; }
		}

		/// <summary>
		/// Gets the GroupByCollection to use for the DbCount fetch. Only valid if DataContainerType is set to TypedList or TypedView.
		/// </summary>
		public IGroupByCollection GroupBy
		{
			get { return _groupBy; }
		}

		/// <summary>
		/// Gets a value indicating whether duplicates should be considered in the DbCount fetch. Only valid if DataContainerType is set to Typedlist
		/// </summary>
		public bool AllowDuplicates
		{
			get { return _allowDuplicates; }
		}

		/// <summary>
		/// Gets or sets the db count retrieved.
		/// </summary>
		/// <value>The db count.</value>
		public int DbCount
		{
			get { return _dbCount; }
			set { _dbCount = value; }
		}

		/// <summary>
		/// Gets the type of the data container. Use this value to determine which values to retrieve from this event arguments object to perform the GetDbCount action
		/// </summary>
		/// <value>The type of the data container.</value>
		public DataSourceDataContainerType DataContainerType
		{
			get { return _dataContainerType; }
		}

		/// <summary>
		/// Gets the contained collection in the data source control
		/// </summary>
		/// <value>The contained collection.</value>
		public IEntityCollection ContainedCollection
		{
			get { return _containedCollection; }
		}

		/// <summary>
		/// Gets the filter.
		/// </summary>
		/// <value>The filter.</value>
		public IPredicateExpression Filter
		{
			get { return _filter; }
		}

		/// <summary>
		/// Gets the fields for TypedList or TypedView fetches.
		/// </summary>
		/// <value>The fields.</value>
		public IEntityFields Fields
		{
			get { return _fields; }
		}

		#endregion
	}


	/// <summary>
	/// Event arguments class which is passed as argument in the PerformWork event on an LLBLGenProDataSource control.
	/// </summary>
	/// <remarks>SelfServicing specific</remarks>
	public class PerformWorkEventArgs : EventArgs
	{
		#region Class Member Declarations
		private UnitOfWork _uow;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="PerformWorkEventArgs"/> class.
		/// </summary>
		/// <param name="uow">The unit of work.</param>
		public PerformWorkEventArgs( UnitOfWork uow )
		{
			_uow = uow;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets the UnitOfWork object
		/// </summary>
		public UnitOfWork Uow
		{
			get
			{
				return _uow;
			}
			internal set
			{
				_uow = value;
			}
		}
		#endregion
	}




	/// <summary>
	/// Event arguments class which is passed as argument in the PerformWork event on an LLBLGenProDataSource control.
	/// </summary>
	/// <remarks>SelfServicing specific</remarks>
	public class PerformWorkEventArgs2 : EventArgs
	{
		#region Class Member Declarations
		private UnitOfWork2 _uow;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="PerformWorkEventArgs2"/> class.
		/// </summary>
		/// <param name="uow">The unit of work</param>
		public PerformWorkEventArgs2( UnitOfWork2 uow )
		{
			_uow = uow;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets the UnitOfWorkw object
		/// </summary>
		public UnitOfWork2 Uow
		{
			get
			{
				return _uow;
			}
			internal set
			{
				_uow = value;
			}
		}
		#endregion
	}
	

	/// <summary>
	/// Event arguments class which is passed as argument in the PerformSelect event on an LLBLGenProDataSource2 control
	/// </summary>
	/// <remarks>Adapter specific</remarks>
	public class PerformSelectEventArgs : EventArgs
	{
		#region Class Member Declarations
		private DataSourceDataContainerType _dataContainerType;
		private IEntityCollection _containedCollection;
		private ITypedListLgp _containedTypedList;
		private ITypedView _containedTypedView;
		private IPredicateExpression _filter;
		private IRelationCollection _relations;
		private int _maxNumberOfItemsToReturn, _pageNumber, _pageSize;
		private ISortExpression _sorter;
		private IEntityFields _fields;
		private bool _allowDuplicates;
		private IGroupByCollection _groupBy;
		private IPrefetchPath _prefetchPath;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="PerformSelectEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="containedCollection">The contained collection.</param>
		/// <param name="prefetchPath">The prefetch path.</param>
		public PerformSelectEventArgs( IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, int pageSize, 
				int pageNumber, ISortExpression sorter,	IEntityCollection containedCollection, IPrefetchPath prefetchPath )
		{
			InitClass( filter, relations, maxNumberOfItemsToReturn, pageNumber, pageSize, sorter, containedCollection, null, null, null, false, 
					DataSourceDataContainerType.EntityCollection,
					prefetchPath, null );
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="PerformSelectEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="containedTypedList">The contained typed list.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="allowDuplicates">if set to <c>true</c> [allow duplicates].</param>
		/// <param name="groupBy">The group by.</param>
		public PerformSelectEventArgs( IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, int pageSize, 
				int pageNumber, ISortExpression sorter,	ITypedListLgp containedTypedList, IEntityFields fields, bool allowDuplicates, 
				IGroupByCollection groupBy )
		{
			InitClass( filter, relations, maxNumberOfItemsToReturn, pageNumber, pageSize, sorter, null, containedTypedList, null, fields, allowDuplicates, DataSourceDataContainerType.TypedList, null, groupBy );
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="PerformSelectEventArgs2"/> class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="containedTypedView">The contained typed view.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="groupBy">The group by.</param>
		public PerformSelectEventArgs( IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, int pageSize, 
				int pageNumber, ISortExpression sorter,	ITypedView containedTypedView, IEntityFields fields, IGroupByCollection groupBy )
		{
			InitClass( filter, relations, maxNumberOfItemsToReturn, pageNumber, pageSize, sorter, null, null, containedTypedView, 
						fields, true, DataSourceDataContainerType.TypedView, null, groupBy );
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="containedCollection">The contained collection.</param>
		/// <param name="containedTypedList">The contained typed list.</param>
		/// <param name="containedTypedView">The contained typed view.</param>
		/// <param name="fields">The fields.</param>
		/// <param name="allowDuplicates">if set to <c>true</c> [allow duplicates].</param>
		/// <param name="dataSourceDataContainerType">Type of the data source data container.</param>
		/// <param name="prefetchPath">The prefetch path.</param>
		/// <param name="groupBy">The group by.</param>
		private void InitClass( IPredicateExpression filter, IRelationCollection relations, int maxNumberOfItemsToReturn, int pageNumber, int pageSize,
				ISortExpression sorter, IEntityCollection containedCollection, ITypedListLgp containedTypedList, ITypedView containedTypedView,
				IEntityFields fields, bool allowDuplicates, DataSourceDataContainerType dataSourceDataContainerType, 
				IPrefetchPath prefetchPath, IGroupByCollection groupBy )
		{
			_fields = fields;
			_filter = filter;
			_relations = relations;
			_maxNumberOfItemsToReturn = maxNumberOfItemsToReturn;
			_pageNumber = pageNumber;
			_pageSize = pageSize;
			_allowDuplicates = allowDuplicates;
			_sorter = sorter;
			_containedCollection = containedCollection;
			_containedTypedList = containedTypedList;
			_containedTypedView = containedTypedView;
			_dataContainerType = dataSourceDataContainerType;
			_prefetchPath = prefetchPath;
			_groupBy = groupBy;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the relations.
		/// </summary>
		/// <value>The relations.</value>
		public IRelationCollection Relations
		{
			get { return _relations; }
		}
		
		
		/// <summary>
		/// Gets the GroupByCollection to use for the fetch. Only valid if DataContainerType is set to TypedList or TypedView.
		/// </summary>
		public IGroupByCollection GroupBy
		{
			get { return _groupBy; }
		}

		/// <summary>
		/// Gets the prefetch path to use for the fetch. Only valid if DataContainerType is set to EntityCollection. 
		/// </summary>
		/// <value>The prefetch path.</value>
		public IPrefetchPath PrefetchPath
		{
			get { return _prefetchPath; }
		}

		/// <summary>
		/// Gets a value indicating whether duplicates should be considered in the fetch. Only valid if DataContainerType is set to Typedlist
		/// </summary>
		public bool AllowDuplicates
		{
			get { return _allowDuplicates; }
		}

		/// <summary>
		/// Gets the type of the data container. Use this value to determine which values to retrieve from this event arguments object to perform the select action
		/// </summary>
		/// <value>The type of the data container.</value>
		public DataSourceDataContainerType DataContainerType
		{
			get { return _dataContainerType; }
		}

		/// <summary>
		/// Gets the contained collection in the data source control
		/// </summary>
		/// <value>The contained collection.</value>
		public IEntityCollection ContainedCollection
		{
			get { return _containedCollection; }
		}

		/// <summary>
		/// Gets the contained typed list in the data source control
		/// </summary>
		/// <value>The contained typed list.</value>
		public ITypedListLgp ContainedTypedList
		{
			get { return _containedTypedList; }
		}

		/// <summary>
		/// Gets the contained typed view in the data source control
		/// </summary>
		/// <value>The contained typed view.</value>
		public ITypedView ContainedTypedView
		{
			get { return _containedTypedView; }
		}

		/// <summary>
		/// Gets the filter.
		/// </summary>
		/// <value>The filter.</value>
		public IPredicateExpression Filter
		{
			get { return _filter; }
		}

		/// <summary>
		/// Gets the max number of items to return.
		/// </summary>
		/// <value>The max number of items to return.</value>
		public int MaxNumberOfItemsToReturn
		{
			get { return _maxNumberOfItemsToReturn; }
		}

		/// <summary>
		/// Gets the page number for paging. 
		/// </summary>
		/// <value>The page number.</value>
		public int PageNumber
		{
			get { return _pageNumber; }
		}

		/// <summary>
		/// Gets the page size for paging. 
		/// </summary>
		/// <value>The size of the page.</value>
		public int PageSize
		{
			get { return _pageSize; }
		}

		/// <summary>
		/// Gets the sortexpression.
		/// </summary>
		/// <value>The sorter.</value>
		public ISortExpression Sorter
		{
			get { return _sorter; }
		}

		/// <summary>
		/// Gets the fields for TypedList or TypedView fetches.
		/// </summary>
		/// <value>The fields.</value>
		public IEntityFields Fields
		{
			get { return _fields; }
		}

		#endregion
	}
}
