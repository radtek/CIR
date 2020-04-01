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
using System.Globalization;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Reflection;
using System.CodeDom;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web;
using System.Security.Permissions;
using System.Data;
using System.Drawing.Design;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Drawing;
using System.Web.Caching;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// General data source control which can be used in ASP.NET projects to perform design time databinding and runtime databinding. 
	/// </summary>
	/// <remarks>Adapter specific</remarks>
	[Designer( typeof( SD.LLBLGen.Pro.ORMSupportClasses.LLBLGenProDataSourceDesigner2 ) ),
	Description( "LLBLGen Pro DataSource control for Adapter." ),
    ParseChildren(true),
    PersistChildren(false),
	AspNetHostingPermission( SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal ),
	AspNetHostingPermission( SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal ),
	ToolboxBitmap(typeof(LLBLGenProDataSource2), "ToolBoxImage.ico"),
	DefaultEvent("PerformSelect")]
	public class LLBLGenProDataSource2 : LLBLGenProDataSourceBase
	{
		#region Events
		/// <summary>
		/// Event which is raised when LivePersistence is set to false and a select has to be performed. 
		/// </summary>
		public event EventHandler<PerformSelectEventArgs2> PerformSelect;
		/// <summary>
		/// Event which is raiseed when LivePersistence is set to false and a GetDbCount has to be performed.
		/// </summary>
		public event EventHandler<PerformGetDbCountEventArgs2> PerformGetDbCount;
		/// <summary>
		/// Event which is raised when LivePersistence is set to false and an insert/update/delete has to be performed.
		/// </summary>
		public event EventHandler<PerformWorkEventArgs2> PerformWork;

		#endregion

		#region Class Member Declarations
		private LLBLGenProDataSourceView2 _defaultView;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="LLBLGenProDataSource2"/> class.
		/// </summary>
		public LLBLGenProDataSource2()
		{
			base.InitClass();
		}


		/// <summary>
		/// Gets the view.
		/// </summary>
		/// <returns></returns>
		protected override LLBLGenProDataSourceViewBase GetView()
		{
			return GetViewInternal();
		}


		/// <summary>
		/// Gets the default view.
		/// </summary>
		/// <returns></returns>
		internal LLBLGenProDataSourceView2 GetViewInternal()
		{
			if( _defaultView == null )
			{
				_defaultView = new LLBLGenProDataSourceView2( this, LLBLGenProDataSourceBase.DefaultDataSourceViewName );
			}
			return _defaultView;
		}


		/// <summary>
		/// Called when the PerformSelect event has to be raised.
		/// </summary>
		/// <param name="eventArgs">The event args.</param>
		internal void OnPerformSelect( PerformSelectEventArgs2 eventArgs )
		{
			if( PerformSelect != null )
			{
				PerformSelect( this, eventArgs );
			}
		}

		/// <summary>
		/// Called when the PerformDbCount event has to be raised.
		/// </summary>
		/// <param name="eventArgs">The event args.</param>
		internal void OnPerformDbCount( PerformGetDbCountEventArgs2 eventArgs )
		{
			if( PerformGetDbCount != null )
			{
				PerformGetDbCount( this, eventArgs );
			}
		}


		/// <summary>
		/// Called when PerformWork event has to be raised
		/// </summary>
		/// <param name="eventArgs">The event args.</param>
		internal void OnPerformWork( PerformWorkEventArgs2 eventArgs )
		{
			if( PerformWork != null )
			{
				PerformWork( this, eventArgs );
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the name of the typed list type. Only valid if DataContainerType is set to TypedList
		/// </summary>
		[DefaultValue( "" )]
		[Description("Assembly qualified name of the Type of the TypedList contained in this DataSourceControl. Use 'Configure Data Source...' to set this property. Only valid if DataContainerType is set to TypedList.")]
		public string TypedListTypeName
		{
			get
			{
				return GetViewInternal().TypedListTypeName;
			}
			set
			{
				GetViewInternal().TypedListTypeName = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the typed view type. Only valid if DataContainerType is set to TypedView
		/// </summary>
		[DefaultValue( "" )]
		[Description( "Assembly qualified name of the Type of the TypedView contained in this DataSourceControl. Use 'Configure Data Source...' to set this property. Only valid if DataContainerType is set to TypedView." )]
		public string TypedViewTypeName
		{
			get
			{
				return GetViewInternal().TypedViewTypeName;
			}
			set
			{
				GetViewInternal().TypedViewTypeName = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the entity factory type. Only valid if DataContainerType is set to EntityCollection
		/// </summary>
		[DefaultValue( "" )]
		[Description( "Assembly qualified name of the Type of the entity factory to use with the EntityCollection object contained in this DataSourceControl. Use 'Configure Data Source...' to set this property. Only valid if DataContainerType is set to EntityCollection." )]
		public string EntityFactoryTypeName
		{
			get
			{
				return GetViewInternal().EntityFactoryTypeName;
			}
			set
			{
				GetViewInternal().EntityFactoryTypeName = value;
			}
		}


		/// <summary>
		/// Gets or sets the name of the DataAccessAdapter type.
		/// </summary>
		[DefaultValue( "" )]
		[Description( "Assembly qualified name of the Type of the DataAccessAdapter object used by this DataSourceControl. Use 'Configure Data Source...' to set this property." )]
		public string AdapterTypeName
		{
			get
			{
				return GetViewInternal().AdapterTypeName;
			}
			set
			{
				GetViewInternal().AdapterTypeName = value;
			}
		}


		/// <summary>
		/// Gets the UnitOfWork object used by this control. Not defined if LivePersistence is set to true.
		/// 
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public UnitOfWork2 UnitOfWorkObject
		{
			get
			{
				return GetViewInternal().UoW;
			}
		}


		/// <summary>
		/// Gets / sets the flag whether the control should refetch the data at the next select call from the bound control(s). Set this flag to true
		/// when you've persisted the embedded UnitOfWork object. This will also clear the unitofwork object on the next select.
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public bool Refetch
		{
			get { return GetViewInternal().Refetch; }
			set { GetViewInternal().Refetch = value; }
		}


		/// <summary>
		/// Gets or sets the adapter to use. Only valid if LivePersistence is set to true, otherwise persistence for selects is delegated to events and 
		/// for save/delete is delegated to a UnitOfWork object.
		/// </summary>
		/// <value>The adapter to use.</value>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public IDataAccessAdapter AdapterToUse
		{
			get
			{
				return GetViewInternal().AdapterToUse;
			}
			set
			{
				GetViewInternal().AdapterToUse = value;
			}
		}

		/// <summary>
		/// Gets or sets the filter to use.
		/// </summary>
		/// <value>The filter to use.</value>
		[Browsable( false ), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public IRelationPredicateBucket FilterToUse
		{
			get
			{
				return GetViewInternal().FilterToUse;
			}
			set
			{
				GetViewInternal().FilterToUse = value;
			}
		}


		/// <summary>
		/// Gets or sets the GroupByCollection to use. Only valid if DataContainerType is set to TypedList or TypedView
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public IGroupByCollection GroupBy
		{
			get
			{
				return GetViewInternal().GroupBy;
			}
			set
			{
				GetViewInternal().GroupBy = value;
			}
		}

		/// <summary>
		/// Gets or sets the PrefetchPath to use. Only valid if DataContainerType is set to EntityCollection.
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public IPrefetchPath2 PrefetchPathToUse
		{
			get
			{
				return GetViewInternal().PrefetchPath;
			}
			set
			{
				GetViewInternal().PrefetchPath = value;
			}
		}

		/// <summary>
		/// Gets the entity collection contained in this object. Only valid if DataContainerType is set to EntityCollection.
		/// The returned type is of type EntityCollectionNonGeneric, which is the base class for the generated EntityCollection non-generic class. 
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public IEntityCollection2 EntityCollection
		{
			get { return GetViewInternal().ContainedEntityCollection; }
			set { GetViewInternal().ContainedEntityCollection = value; }
		}

		/// <summary>
		/// Gets the typed list contained in this object. Only valid if DataContainerType is set to TypedList.
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public ITypedListLgp2 TypedList
		{
			get { return GetViewInternal().ContainedTypedList; }
			set { GetViewInternal().ContainedTypedList = value; }
		}

		/// <summary>
		/// Gets the typed view contained in this object. Only valid if DataContainerType is set to TypedView.
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public ITypedView2 TypedView
		{
			get { return GetViewInternal().ContainedTypedView; }
			set { GetViewInternal().ContainedTypedView = value; }
		}

		#endregion
	}



	/// <summary>
	/// General data source control which can be used in ASP.NET projects to perform design time databinding and runtime databinding. 
	/// </summary>
	/// <remarks>SelfServicing specific</remarks>
	[Designer( typeof( SD.LLBLGen.Pro.ORMSupportClasses.LLBLGenProDataSourceDesigner ) ),
	Description( "LLBLGen Pro DataSource control for SelfServicing." ),
	ParseChildren( true ),
	PersistChildren( false ),
	AspNetHostingPermission( SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal ),
	AspNetHostingPermission( SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal ),
	ToolboxBitmap( typeof( LLBLGenProDataSource ), "ToolBoxImage.ico" ),
	DefaultEvent( "PerformSelect" )]
	public class LLBLGenProDataSource : LLBLGenProDataSourceBase
	{
		#region Events
		/// <summary>
		/// Event which is raised when LivePersistence is set to false and a select has to be performed. 
		/// </summary>
		public event EventHandler<PerformSelectEventArgs> PerformSelect;
		/// <summary>
		/// Event which is raised when LivePersistence is set to false and a GetDbCount has to be performed.
		/// </summary>
		public event EventHandler<PerformGetDbCountEventArgs> PerformGetDbCount;
		/// <summary>
		/// Event which is raised when LivePersistence is set to false and an insert/update/delete has to be performed.
		/// </summary>
		public event EventHandler<PerformWorkEventArgs> PerformWork;
		#endregion

		#region Class Member Declarations
		private LLBLGenProDataSourceView _defaultView;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="LLBLGenProDataSource2"/> class.
		/// </summary>
		public LLBLGenProDataSource()
		{
			base.InitClass();
		}


		/// <summary>
		/// Gets the view.
		/// </summary>
		/// <returns></returns>
		protected override LLBLGenProDataSourceViewBase GetView()
		{
			return GetViewInternal();
		}


		/// <summary>
		/// Gets the default view.
		/// </summary>
		/// <returns></returns>
		internal LLBLGenProDataSourceView GetViewInternal()
		{
			if( _defaultView == null )
			{
				_defaultView = new LLBLGenProDataSourceView( this, LLBLGenProDataSourceBase.DefaultDataSourceViewName );
			}
			return _defaultView;
		}


		/// <summary>
		/// Called when the PerformSelect event has to be raised.
		/// </summary>
		/// <param name="eventArgs">The event args.</param>
		internal void OnPerformSelect( PerformSelectEventArgs eventArgs )
		{
			if( PerformSelect != null )
			{
				PerformSelect( this, eventArgs );
			}
		}


		/// <summary>
		/// Called when the PerformDbCount event has to be raised.
		/// </summary>
		/// <param name="eventArgs">The event args.</param>
		internal void OnPerformDbCount( PerformGetDbCountEventArgs eventArgs )
		{
			if( PerformGetDbCount != null )
			{
				PerformGetDbCount( this, eventArgs );
			}
		}


		/// <summary>
		/// Called when PerformWork event has to be raised
		/// </summary>
		/// <param name="eventArgs">The event args.</param>
		internal void OnPerformWork( PerformWorkEventArgs eventArgs )
		{
			if( PerformWork != null )
			{
				PerformWork( this, eventArgs );
			}
		}


		#region Class Property Declarations

		/// <summary>
		/// Gets or sets the name of the typed list type. Only valid if DataContainerType is set to TypedList
		/// </summary>
		[DefaultValue( "" )]
		[Description( "Assembly qualified name of the Type of the TypedList contained in this DataSourceControl. Use 'Configure Data Source...' to set this property. Only valid if DataContainerType is set to TypedList." )]
		public string TypedListTypeName
		{
			get
			{
				return GetViewInternal().TypedListTypeName;
			}
			set
			{
				GetViewInternal().TypedListTypeName = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the typed view type. Only valid if DataContainerType is set to TypedView
		/// </summary>
		[DefaultValue( "" )]
		[Description( "Assembly qualified name of the Type of the TypedView contained in this DataSourceControl. Use 'Configure Data Source...' to set this property. Only valid if DataContainerType is set to TypedView." )]
		public string TypedViewTypeName
		{
			get
			{
				return GetViewInternal().TypedViewTypeName;
			}
			set
			{
				GetViewInternal().TypedViewTypeName = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the entity collection. Only valid if DataContainerType is set to EntityCollection
		/// </summary>
		[DefaultValue( "" )]
		[Description( "Assembly qualified name of the Type of the entity collection contained in this DataSourceControl. Use 'Configure Data Source...' to set this property. Only valid if DataContainerType is set to EntityCollection." )]
		public string EntityCollectionTypeName
		{
			get
			{
				return GetViewInternal().EntityCollectionTypeName;
			}
			set
			{
				GetViewInternal().EntityCollectionTypeName = value;
			}
		}


		/// <summary>
		/// Gets the UnitOfWork object used by this control. Not defined if LivePersistence is set to true.
		/// 
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public UnitOfWork UnitOfWorkObject
		{
			get
			{
				return GetViewInternal().UoW;
			}
		}


		/// <summary>
		/// Gets / sets the flag whether the control should refetch the data at the next select call from the bound control(s). Set this flag to true
		/// when you've persisted the embedded UnitOfWork object. This will also clear the unitofwork object on the next select.
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public bool Refetch
		{
			get { return GetViewInternal().Refetch; }
			set { GetViewInternal().Refetch = value; }
		}


		/// <summary>
		/// Gets or sets the relations to use.
		/// </summary>
		/// <value>The relations to use.</value>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public IRelationCollection RelationsToUse
		{
			get
			{
				return GetViewInternal().RelationsToUse;
			}
			set
			{
				GetViewInternal().RelationsToUse = value;
			}
		}

		/// <summary>
		/// Gets or sets the filter to use.
		/// </summary>
		/// <value>The filter to use.</value>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public IPredicateExpression FilterToUse
		{
			get
			{
				return GetViewInternal().FilterToUse;
			}
			set
			{
				GetViewInternal().FilterToUse = value;
			}
		}


		/// <summary>
		/// Gets or sets the PrefetchPath to use. Only valid if DataContainerType is set to EntityCollection
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public IPrefetchPath PrefetchPathToUse
		{
			get
			{
				return GetViewInternal().PrefetchPath;
			}
			set
			{
				GetViewInternal().PrefetchPath = value;
			}
		}

		
		/// <summary>
		/// Gets or sets the GroupByCollection to use. Only valid if DataContainerType is set to TypedList or TypedView
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public IGroupByCollection GroupBy
		{
			get
			{
				return GetViewInternal().GroupBy;
			}
			set
			{
				GetViewInternal().GroupBy = value;
			}
		}


		/// <summary>
		/// Gets or sets the entity collection contained in this object. Only valid if DataContainerType is set to EntityCollection.
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public IEntityCollection EntityCollection
		{
			get { return GetViewInternal().ContainedEntityCollection; }
			set { GetViewInternal().ContainedEntityCollection = value; }
		}

		/// <summary>
		/// Gets or sets the typed list contained in this object. Only valid if DataContainerType is set to TypedList.
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public ITypedListLgp TypedList
		{
			get { return GetViewInternal().ContainedTypedList; }
			set { GetViewInternal().ContainedTypedList = value; }
		}

		/// <summary>
		/// Gets or sets the typed view contained in this object. Only valid if DataContainerType is set to TypedView.
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public ITypedView TypedView
		{
			get { return GetViewInternal().ContainedTypedView; }
			set { GetViewInternal().ContainedTypedView = value; }
		}

		#endregion
	}


	/// <summary>
	/// General implementation of the DataSourceView class to be used with LLBLGenProDataSource control in ASP.NET applications.
	/// </summary>
	/// <remarks>Adapter specific</remarks>
	[AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class LLBLGenProDataSourceView2 : LLBLGenProDataSourceViewBase, IDisposable
	{
		#region Class Member Declarations
		private IEntityCollection2 _containedCollection;
		private ITypedListLgp2 _containedTypedList;
		private ITypedView2 _containedTypedView;
		private IDataAccessAdapter _adapterToUse;
		private IRelationPredicateBucket _filterToUse;
		private bool _isDisposed;
		private UnitOfWork2		_uow;
		private IPrefetchPath2 _prefetchPath;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="LLBLGenProDataSourceView2"/> class.
		/// </summary>
		/// <param name="_owner">The _owner.</param>
		/// <param name="viewName">Name of the view.</param>
		public LLBLGenProDataSourceView2( LLBLGenProDataSource2 _owner, string viewName )
			: base( _owner, viewName )
		{
			_adapterToUse = null;
			_filterToUse = null;
			_isDisposed = false;
			_uow = null;
			_prefetchPath = null;
		}


		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public override void Dispose()
		{
			Dispose( true );
			GC.SuppressFinalize( this );
		}


		/// <summary>
		/// Implements the Dispose functionality. If a transaction is in progress, it will rollback that transaction.
		/// </summary>
		/// <param name="isDisposing">Flag which signals this routine if a dispose action should take place (true) or not (false)</param>
		protected virtual void Dispose( bool isDisposing )
		{
			// Check to see if Dispose has already been called.
			if( !_isDisposed )
			{
				if( isDisposing )
				{
					// Dispose managed resources.
					if( _adapterToUse != null )
					{
						((IDisposable)_adapterToUse).Dispose();
					}
					_isDisposed = true;
				}
			}
		}


		/// <summary>
		/// Sets the prefetch path.
		/// </summary>
		/// <param name="prefetchPath">The prefetch path.</param>
		protected override void SetPrefetchPath( object prefetchPath )
		{
			_prefetchPath = (IPrefetchPath2)prefetchPath;
		}


		/// <summary>
		/// Sets the filter.
		/// </summary>
		/// <param name="filterObject">The filter object.</param>
		protected override void SetFilter( object filterObject )
		{
			_filterToUse = (IRelationPredicateBucket)filterObject;
		}


		/// <summary>
		/// Sets the unit of work.
		/// </summary>
		/// <param name="uow">The unit of work.</param>
		protected override void SetUnitOfWork( object uow )
		{
			_uow = (UnitOfWork2)uow;
		}


		/// <summary>
		/// Sets the datacontainer object
		/// </summary>
		/// <param name="dataContainer">the datacontainer object to set.</param>
		protected override void SetDataContainer( object dataContainer )
		{
			switch( base.Owner.DataContainerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					_containedCollection = (IEntityCollection2)dataContainer;
					break;
				case DataSourceDataContainerType.TypedList:
					_containedTypedList = (ITypedListLgp2)dataContainer;
					break;
				case DataSourceDataContainerType.TypedView:
					_containedTypedView = (ITypedView2)dataContainer;
					break;
			}
		}


		/// <summary>
		/// Creates the state data object.
		/// </summary>
		/// <returns></returns>
		protected override object[] CreateStateDataObject()
		{
			object[] state = base.CreateStateDataObject();
			state[(int)StateSlot.Filter] = _filterToUse;
			switch( base.Owner.DataContainerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					state[(int)StateSlot.DataContainer] = _containedCollection;
					break;
				case DataSourceDataContainerType.TypedList:
					state[(int)StateSlot.DataContainer] = _containedTypedList;
					break;
				case DataSourceDataContainerType.TypedView:
					state[(int)StateSlot.DataContainer] = _containedTypedView;
					break;
			}
			state[(int)StateSlot.UnitOfWork] = _uow;
			state[(int)StateSlot.PrefetchPath] = _prefetchPath;

			return state;
		}


		/// <summary>
		/// Creates the filter from the parameters specified.
		/// </summary>
		/// <returns>PredicateExpression to use as additional filter for a select</returns>
		private IPredicateExpression CreateRuntimeFilter()
		{
			PredicateExpression toReturn = new PredicateExpression();
			IEntityFields2 fields = null;
			switch( base.Owner.DataContainerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					if( _containedCollection.EntityFactoryToUse == null )
					{
						return null;
					}
					fields = _containedCollection.EntityFactoryToUse.CreateFields();
					break;
				case DataSourceDataContainerType.TypedList:
					fields = _containedTypedList.GetFieldsInfo();
					break;
				case DataSourceDataContainerType.TypedView:
					fields = _containedTypedView.GetFieldsInfo();
					break;
			}
			ParameterCollection parameters = base.SelectParameters;
			IOrderedDictionary parameterValues = parameters.GetValues( base.Owner.GetContext(), base.Owner );

			// build filters
			foreach( Parameter p in parameters )
			{
				IEntityField2 field = fields[p.Name];
				if( field == null )
				{
					// mismatch, skip
					continue;
				}
				object parameterValue = parameterValues[p.Name];
				if( parameterValue == null )
				{
					toReturn.AddWithAnd( new FieldCompareNullPredicate( field, null));
				}
				else
				{
					toReturn.AddWithAnd( new FieldCompareValuePredicate( field, null, ComparisonOperator.Equal, 
						base.ConvertValueToDestinationType(field.DataType, parameterValues[p.Name], field.Alias) ) );
				}
			}

			if( toReturn.Count <= 0 )
			{
				toReturn = null;
			}

			return toReturn;
		}



		/// <summary>
		/// Performs an update operation on the list of data that the <see cref="T:System.Web.UI.DataSourceView"></see> object represents.
		/// </summary>
		/// <param name="keys">An <see cref="T:System.Collections.IDictionary"></see> of object or row keys to be updated by the update operation.</param>
		/// <param name="values">An <see cref="T:System.Collections.IDictionary"></see> of name/value pairs that represent data elements and their new values.</param>
		/// <param name="oldValues">An <see cref="T:System.Collections.IDictionary"></see> of name/value pairs that represent data elements and their original values.</param>
		/// <returns>
		/// The number of items that were updated in the underlying data storage.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="M:System.Web.UI.DataSourceView.ExecuteUpdate(System.Collections.IDictionary,System.Collections.IDictionary,System.Collections.IDictionary)"></see> operation is not supported by the <see cref="T:System.Web.UI.DataSourceView"></see>. </exception>
		protected override int ExecuteUpdate( IDictionary keys, IDictionary values, IDictionary oldValues )
		{
			if(( _adapterToUse == null ) || (_containedCollection==null) || (_containedCollection.Count<=0))
			{
				return 0;
			}

			if( !this.CanUpdate )
			{
				throw new NotSupportedException( "Updating data isn't supported in the current configuration." );
			}

			if( keys.Count <= 0 )
			{
				// can't update anything, no keys specified.
				throw new ORMGeneralOperationException( "There are no primary key fields specified in the bound control and/or the bound control didn't specify any primary key fields. Update can't continue." );
			}

			IDictionary valuesToSet = new OrderedDictionary( StringComparer.OrdinalIgnoreCase );
			base.MergeDictionaries(base.UpdateParameters, values, valuesToSet);

			IEntity2 matchingEntity = FindEntity( keys );
			if( matchingEntity == null )
			{
				// no match found
				return 0;
			}

			SetEntityValues( valuesToSet, matchingEntity );

			bool cancel = base.Owner.OnEntityUpdating(matchingEntity);
			if(cancel)
			{
				return 0;
			}

			if( base.Owner.LivePersistence )
			{
				// save now
				bool result = _adapterToUse.SaveEntity( matchingEntity );
				if(result)
				{
					base.Owner.OnEntityUpdated(matchingEntity);
				}
			}
			else
			{
				if( _uow == null )
				{
					_uow = new UnitOfWork2();
				}
				_uow.AddForSave( matchingEntity );
				try
				{
					// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
					base.SurpressChangedEvent = true;
					((LLBLGenProDataSource2)base.Owner).OnPerformWork( new PerformWorkEventArgs2( _uow ) );
				}
				finally
				{
					base.SurpressChangedEvent = false;
				}
			}

			this.Refetch = true;
			return 1;
		}


		/// <summary>
		/// Performs a delete operation on the list of data that the <see cref="T:System.Web.UI.DataSourceView"></see> object represents.
		/// </summary>
		/// <param name="keys">An <see cref="T:System.Collections.IDictionary"></see> of object or row keys to be deleted by the <see cref="M:System.Web.UI.DataSourceView.ExecuteDelete(System.Collections.IDictionary,System.Collections.IDictionary)"></see> operation.</param>
		/// <param name="oldValues">An <see cref="T:System.Collections.IDictionary"></see> of name/value pairs that represent data elements and their original values.</param>
		/// <returns>
		/// The number of items that were deleted from the underlying data storage.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="M:System.Web.UI.DataSourceView.ExecuteDelete(System.Collections.IDictionary,System.Collections.IDictionary)"></see> operation is not supported by the <see cref="T:System.Web.UI.DataSourceView"></see>. </exception>
		protected override int ExecuteDelete( IDictionary keys, IDictionary oldValues )
		{
			if( (_adapterToUse == null) || (_containedCollection == null) || (_containedCollection.Count <= 0) )
			{
				return 0;
			}

			if( !this.CanDelete )
			{
				throw new NotSupportedException( "Deleting data isn't supported in the current configuration." );
			}

			if( keys.Count <= 0 )
			{
				// can't update anything, no keys specified.
				throw new ORMGeneralOperationException( "There are no primary key fields specified in the bound control and/or the bound control didn't specify any primary key fields. Delete can't continue." );
			}

			IEntity2 matchingEntity = FindEntity( keys );
			if( matchingEntity == null )
			{
				// no match found
				return 0;
			}
			bool cancel = base.Owner.OnEntityDeleting(matchingEntity);
			if(cancel)
			{
				return 0;
			}

			if( base.Owner.LivePersistence )
			{
				// delete now.
				bool result = _adapterToUse.DeleteEntity( matchingEntity );
				if(result)
				{
					base.Owner.OnEntityDeleted(matchingEntity);
				}
			}
			else
			{
				if( _uow == null )
				{
					_uow = new UnitOfWork2();
				}
				_uow.AddForDelete( matchingEntity );
				try
				{
					// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
					base.SurpressChangedEvent = true;
					((LLBLGenProDataSource2)base.Owner).OnPerformWork( new PerformWorkEventArgs2( _uow ) );
				}
				finally
				{
					base.SurpressChangedEvent = false;
				}
			}

			if(matchingEntity.Fields.State == EntityState.Deleted)
			{
				// remove entity from datasource. This is necessary because multiple calls to this method without refetching the data would otherwise
				// result in exceptions.
				_containedCollection.Remove(matchingEntity);
			}

			base.Refetch = true;
			return 1;
		}


		/// <summary>
		/// Performs an insert operation on the list of data that the <see cref="T:System.Web.UI.DataSourceView"></see> object represents.
		/// </summary>
		/// <param name="values">An <see cref="T:System.Collections.IDictionary"></see> of name/value pairs used during an insert operation.</param>
		/// <returns>
		/// The number of items that were inserted into the underlying data storage.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="M:System.Web.UI.DataSourceView.ExecuteInsert(System.Collections.IDictionary)"></see> operation is not supported by the <see cref="T:System.Web.UI.DataSourceView"></see>. </exception>
		protected override int ExecuteInsert( IDictionary values )
		{
			if( (_adapterToUse == null) || (_containedCollection == null) || (_containedCollection.EntityFactoryToUse==null) )
			{
				return 0;
			}

			if( !this.CanInsert )
			{
				throw new NotSupportedException( "Inserting data isn't supported in the current configuration." );
			}

			IDictionary valuesToSet = new OrderedDictionary(StringComparer.OrdinalIgnoreCase);
			base.MergeDictionaries(base.InsertParameters, values, valuesToSet);
			IEntity2 newEntity = _containedCollection.EntityFactoryToUse.Create();
			SetEntityValues( valuesToSet, newEntity );

			bool cancel = base.Owner.OnEntityInserting(newEntity);
			if(cancel)
			{
				return 0;
			}

			if( base.Owner.LivePersistence )
			{
				// save now
				bool result = _adapterToUse.SaveEntity( newEntity );
				if(result)
				{
					base.Owner.OnEntityInserted(newEntity);
				}
			}
			else
			{
				if( _uow == null )
				{
					_uow = new UnitOfWork2();
				}
				_uow.AddForSave( newEntity );
				try
				{
					// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
					base.SurpressChangedEvent = true;
					((LLBLGenProDataSource2)base.Owner).OnPerformWork( new PerformWorkEventArgs2( _uow ) );
				}
				finally
				{
					base.SurpressChangedEvent = false;
				}
			}

			this.Refetch = true;
			return 1;
		}


		/// <summary>
		/// Gets a list of data from the underlying data storage.
		/// </summary>
		/// <param name="arguments">A <see cref="T:System.Web.UI.DataSourceSelectArguments"></see> that is used to request operations on the data beyond basic data retrieval.</param>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerable"></see> list of data from the underlying data storage.
		/// </returns>
		protected override IEnumerable ExecuteSelect( DataSourceSelectArguments arguments )
		{
			if(base.Owner.LivePersistence && (_adapterToUse==null))
			{
				return null;
			}

			if( this.CanPage )
			{
				arguments.AddSupportedCapabilities( DataSourceCapabilities.Page );
			}
			if( this.CanRetrieveTotalRowCount )
			{
				arguments.AddSupportedCapabilities( DataSourceCapabilities.RetrieveTotalRowCount );
			}

			arguments.RaiseUnsupportedCapabilitiesError( this );

			int pageSize = arguments.MaximumRows;
			int pageNumber = 0;
			if( pageSize > 0 )
			{
				pageNumber = (arguments.StartRowIndex / pageSize) + 1;
			}

			base.CompareSelectParameters();

			IEnumerable toReturn = null;
			switch( base.Owner.DataContainerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					if( _containedCollection != null )
					{
						toReturn = ExecuteSelectEntityCollection( pageSize, pageNumber, arguments );
					}
					break;
				case DataSourceDataContainerType.TypedList:
					if( _containedTypedList != null )
					{
						toReturn = ExecuteSelectTypedList( pageSize, pageNumber, arguments );
					}
					break;
				case DataSourceDataContainerType.TypedView:
					if( _containedTypedView != null )
					{
						toReturn = ExecuteSelectTypedView( pageSize, pageNumber, arguments );
					}
					break;
			}
			return toReturn;
		}


		/// <summary>
		/// Executes the select entity collection.
		/// </summary>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="arguments">The arguments.</param>
		/// <returns></returns>
		private IEnumerable ExecuteSelectEntityCollection(int pageSize, int pageNumber, DataSourceSelectArguments arguments )
		{
			if( _containedCollection == null )
			{
				return null;
			}
			ISortExpression sorterToUseForFetch = null;
			ISortExpression sorterToUseForView = null;
			ISortExpression sorter = ProduceSorterToUse( _containedCollection.EntityFactoryToUse.CreateFields(), arguments );
			switch( base.SortingMode )
			{
				case DataSourceSortingMode.ClientSide:
					sorterToUseForFetch = null;
					sorterToUseForView = sorter;
					break;
				case DataSourceSortingMode.ServerSide:
					sorterToUseForView = null;
					sorterToUseForFetch = sorter;
					break;
			}

			// test to see if we need to fetch new data or can re-use the existing data.
			if( (pageSize != base.PageSize) || (pageNumber != base.PageNumber) || 
					((arguments.SortExpression != base.SortExpression) && (base.SortingMode== DataSourceSortingMode.ServerSide)) || base.Refetch )
			{
				base.PageSize = pageSize;
				base.PageNumber = pageNumber;
				base.SortExpression = arguments.SortExpression;
				_containedCollection.Clear();

				IRelationPredicateBucket filter = ProduceFilterToUse( _filterToUse );

				if( base.Owner.LivePersistence )
				{
					try
					{
						_adapterToUse.KeepConnectionOpen = true;
						_adapterToUse.OpenConnection();
						// check the operation to perform
						if( arguments.RetrieveTotalRowCount )
						{
							// calculate the total rowcount
							arguments.TotalRowCount = _adapterToUse.GetDbCount( _containedCollection, filter );
							base.TotalRowCount = arguments.TotalRowCount;
						}
						_adapterToUse.FetchEntityCollection( _containedCollection, filter, base.Owner.MaxNumberOfItemsToReturn,
								sorterToUseForFetch, _prefetchPath, base.PageNumber, base.PageSize );
					}
					finally
					{
						_adapterToUse.CloseConnection();
						base.Owner.OnElementsFetched();
					}
				}
				else
				{
					try
					{
						// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
						base.SurpressChangedEvent = true;
						if( arguments.RetrieveTotalRowCount )
						{
							PerformGetDbCountEventArgs2 dbCountEventArgs = new PerformGetDbCountEventArgs2( filter, _containedCollection );
							((LLBLGenProDataSource2)base.Owner).OnPerformDbCount( dbCountEventArgs );
							arguments.TotalRowCount = dbCountEventArgs.DbCount;
							base.TotalRowCount = arguments.TotalRowCount;
						}
						((LLBLGenProDataSource2)base.Owner).OnPerformSelect( new PerformSelectEventArgs2( filter, base.Owner.MaxNumberOfItemsToReturn,
								base.PageSize, base.PageNumber, sorterToUseForFetch, _containedCollection, _prefetchPath ) );
					}
					finally
					{
						base.SurpressChangedEvent = false;
					}
					// clear unit of work
					_uow = null;
				}
				base.Refetch = false;
			}
			else
			{
				if( arguments.RetrieveTotalRowCount )
				{
					// calculate the total rowcount
					arguments.TotalRowCount = base.TotalRowCount;
				}
			}
			IEntityView2 toReturn = _containedCollection.DefaultView;
			toReturn.Sorter = sorterToUseForView;

			return toReturn;
		}


		/// <summary>
		/// Executes the select typed list
		/// </summary>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="arguments">The arguments.</param>
		/// <returns></returns>
		private IEnumerable ExecuteSelectTypedList( int pageSize, int pageNumber, DataSourceSelectArguments arguments )
		{
			if( _containedTypedList == null )
			{
				return null;
			}

			// test to see if we need to fetch new data or can re-use the existing data.
			if( (pageSize != base.PageSize) || (pageNumber != base.PageNumber) || (arguments.SortExpression != base.SortExpression) || base.Refetch )
			{
				base.PageSize = pageSize;
				base.PageNumber = pageNumber;
				base.SortExpression = arguments.SortExpression;
				((DataTable)_containedTypedList).Clear();

				// check the operation to perform
				IEntityFields2 fields = _containedTypedList.GetFieldsInfo();
				IRelationPredicateBucket filter = _containedTypedList.GetRelationInfo();
				if( filter == null )
				{
					filter = _filterToUse;
				}
				else
				{
					if( _filterToUse != null )
					{
						filter.Relations.AddRange( (RelationCollection)_filterToUse.Relations );
						if( _filterToUse.PredicateExpression.Count > 0 )
						{
							filter.PredicateExpression.AddWithAnd( _filterToUse.PredicateExpression );
						}
					}
				}

				// merge a runtime filter with this newly produced filter.
				filter = ProduceFilterToUse( filter );
				ISortExpression sorter = ProduceSorterToUse( fields, arguments );
				if( base.Owner.LivePersistence )
				{
					try
					{
						_adapterToUse.KeepConnectionOpen = true;
						_adapterToUse.OpenConnection();
						if( arguments.RetrieveTotalRowCount )
						{
							// calculate the total rowcount
							arguments.TotalRowCount = _adapterToUse.GetDbCount( fields, filter, base.GroupBy, base.Owner.AllowDuplicates );
							base.TotalRowCount = arguments.TotalRowCount;
						}
						_adapterToUse.FetchTypedList( fields, (DataTable)_containedTypedList, filter, base.Owner.MaxNumberOfItemsToReturn,
								sorter, base.Owner.AllowDuplicates, base.GroupBy, pageNumber, pageSize );
					}
					finally
					{
						_adapterToUse.CloseConnection();
						base.Owner.OnElementsFetched();
					}
				}
				else
				{
					try
					{
						// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
						base.SurpressChangedEvent = true;
						if( arguments.RetrieveTotalRowCount )
						{
							// calculate the total rowcount
							PerformGetDbCountEventArgs2 dbCountEventArgs = new PerformGetDbCountEventArgs2( filter, fields, base.Owner.AllowDuplicates,
									base.GroupBy );
							((LLBLGenProDataSource2)base.Owner).OnPerformDbCount( dbCountEventArgs );
							arguments.TotalRowCount = dbCountEventArgs.DbCount;
							base.TotalRowCount = arguments.TotalRowCount;
						}
						((LLBLGenProDataSource2)base.Owner).OnPerformSelect( new PerformSelectEventArgs2( filter, base.Owner.MaxNumberOfItemsToReturn,
								base.PageSize, base.PageNumber, sorter, _containedTypedList, fields, base.Owner.AllowDuplicates, base.GroupBy ) );
					}
					finally
					{
						base.SurpressChangedEvent = false;
					}
				}
				base.Refetch = false;
			}
			else
			{
				if( arguments.RetrieveTotalRowCount )
				{
					// calculate the total rowcount
					arguments.TotalRowCount = base.TotalRowCount;
				}
			}
			return ((DataTable)_containedTypedList).DefaultView;
		}


		/// <summary>
		/// Executes the select typed view
		/// </summary>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="arguments">The arguments.</param>
		/// <returns></returns>
		private IEnumerable ExecuteSelectTypedView( int pageSize, int pageNumber, DataSourceSelectArguments arguments )
		{
			if( _containedTypedView == null )
			{
				return null;
			}

			// test to see if we need to fetch new data or can re-use the existing data.
			if( (pageSize != base.PageSize) || (pageNumber != base.PageNumber) || (arguments.SortExpression != base.SortExpression) || base.Refetch )
			{
				base.PageSize = pageSize;
				base.PageNumber = pageNumber;
				base.SortExpression = arguments.SortExpression;
				((DataTable)_containedTypedView).Clear();

				IEntityFields2 fields = _containedTypedView.GetFieldsInfo();

				IRelationPredicateBucket filter = ProduceFilterToUse( _filterToUse );
				ISortExpression sorter = ProduceSorterToUse( fields, arguments );
				if(base.Owner.LivePersistence)
				{
					try
					{
						_adapterToUse.KeepConnectionOpen = true;
						_adapterToUse.OpenConnection();
						// check the operation to perform
						if( arguments.RetrieveTotalRowCount )
						{
							// calculate the total rowcount
							arguments.TotalRowCount = _adapterToUse.GetDbCount( fields, filter, base.GroupBy );
							base.TotalRowCount = arguments.TotalRowCount;
						}
						_adapterToUse.FetchTypedView( fields, (DataTable)_containedTypedView, filter, base.Owner.MaxNumberOfItemsToReturn,
								sorter, base.Owner.AllowDuplicates, null, pageNumber, pageSize );
					}
					finally
					{
						_adapterToUse.CloseConnection();
						base.Owner.OnElementsFetched();
					}
				}
				else
				{
					try
					{
						// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
						base.SurpressChangedEvent = true;
						if( arguments.RetrieveTotalRowCount )
						{
							PerformGetDbCountEventArgs2 dbCountEventArgs = new PerformGetDbCountEventArgs2( filter, fields, base.Owner.AllowDuplicates,
									base.GroupBy );
							((LLBLGenProDataSource2)base.Owner).OnPerformDbCount( dbCountEventArgs );
							arguments.TotalRowCount = dbCountEventArgs.DbCount;
							base.TotalRowCount = arguments.TotalRowCount;
						}
						((LLBLGenProDataSource2)base.Owner).OnPerformSelect( new PerformSelectEventArgs2( filter, base.Owner.MaxNumberOfItemsToReturn,
								base.PageSize, base.PageNumber, sorter, _containedTypedView, fields, base.GroupBy ) );
					}
					finally
					{
						base.SurpressChangedEvent = false;
					}
				}
				base.Refetch = false;
			}
			else
			{
				if( arguments.RetrieveTotalRowCount )
				{
					// calculate the total rowcount
					arguments.TotalRowCount = base.TotalRowCount;
				}
			}
			return ((DataTable)_containedTypedView).DefaultView;
		}


		/// <summary>
		/// Routine which produces a sortexpression to use for sorting, which merges a sortexpression produced from the arguments with the set sortexpression.
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <param name="arguments">The arguments.</param>
		/// <returns></returns>
		private ISortExpression ProduceSorterToUse( IEntityFields2 fields, DataSourceSelectArguments arguments )
		{
			ISortExpression sorter = new SortExpression();
			if( string.IsNullOrEmpty( arguments.SortExpression ) )
			{
				if( base.SorterToUse != null )
				{
					foreach( SortClause clause in base.SorterToUse )
					{
						sorter.Add( clause );
					}
				}
			}
			else
			{
				if( sorter == null )
				{
					sorter = base.ProduceSortExpressionFromString(fields, arguments.SortExpression );
				}
				else
				{
					ISortExpression argumentsSorter = base.ProduceSortExpressionFromString( fields, arguments.SortExpression );
					foreach( ISortClause clause in argumentsSorter )
					{
						sorter.Add( clause );
					}
				}
			}
			return sorter;
		}


		/// <summary>
		/// Routine which will use the base filter passed in and the runtime filter created internally to produce a new filter to use for a select operation.
		/// </summary>
		/// <param name="baseFilter"></param>
		/// <returns></returns>
		private IRelationPredicateBucket ProduceFilterToUse( IRelationPredicateBucket baseFilter )
		{
			IRelationPredicateBucket filter = null;
			if( baseFilter != null )
			{
				filter = (IRelationPredicateBucket)((ICloneable)baseFilter).Clone();
			}
			IPredicateExpression runtimeFilter = CreateRuntimeFilter();
			if( runtimeFilter != null )
			{
				if( filter == null )
				{
					filter = new RelationPredicateBucket();
				}
				filter.PredicateExpression.AddWithAnd( runtimeFilter );
			}

			return filter;
		}


		/// <summary>
		/// Sets the entity values.
		/// </summary>
		/// <param name="values">The values.</param>
		/// <param name="entity">The entity.</param>
		private void SetEntityValues( IDictionary values, IEntity2 entity )
		{
			// match found, update all fields. Do this through property descriptors so all properties can be updated properly.
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties( entity.GetType() );
			Dictionary<string, PropertyDescriptor> propertiesIndexed = new Dictionary<string, PropertyDescriptor>( properties.Count );
			foreach( PropertyDescriptor descriptor in properties )
			{
				propertiesIndexed.Add( descriptor.Name, descriptor );
			}

			List<string> fieldNamesKeepEmptyStringAsValue = base.FieldNamesKeepEmptyStringAsValue;

			Dictionary<string, object> illegalFieldValues = new Dictionary<string, object>();

			foreach( DictionaryEntry newValueEntry in values )
			{
				PropertyDescriptor descriptor = null;
				if( !propertiesIndexed.TryGetValue( (string)newValueEntry.Key, out descriptor ) )
				{
					// not found
					continue;
				}

				IEntityField2 field = entity.Fields[(string)newValueEntry.Key];
				object newValue = null;
				if(newValueEntry.Value!=null)
				{
					string fieldName = null;
					if(field!=null)
					{
						fieldName = field.Alias;
					}
					try
					{
						newValue = base.ConvertValueToDestinationType(descriptor.PropertyType, newValueEntry.Value, fieldName);
					}
					catch
					{
						// add field / value to dictionary and continue
						illegalFieldValues.Add(fieldName, newValueEntry.Value);
						continue;
					}
				}

				if( field != null )
				{
					if( field.IsReadOnly )
					{
						// can't set a readonly field
						continue;
					}
					if( (newValue == null) && (!field.IsNullable) )
					{
						// can't set a nonnullable field to null
						continue;
					}
					entity.SetNewFieldValue( field.Name, newValue );
				}
				else
				{
					descriptor.SetValue( entity, newValue );
				}
			}

			if(base.ThrowExceptionOnIllegalFieldInput && (illegalFieldValues.Count > 0))
			{
				throw new ORMValueTypeMismatchException("There were one or more values not convertable to their field types. Please examine the 'IllegalFieldValues' and 'TargetEntity' properties of this exception for more information.", illegalFieldValues, entity);
			}
		}
		

		/// <summary>
		/// Finds the entity matching the PK fields specified in keys in the contained collection.
		/// </summary>
		/// <param name="keys">The keys.</param>
		/// <returns></returns>
		private IEntity2 FindEntity(IDictionary keys)
		{
			IPredicateExpression filter = new PredicateExpression();
			foreach( DictionaryEntry key in keys )
			{
				filter.AddWithAnd( new FieldCompareValuePredicate( _containedCollection[0].Fields[(string)key.Key], null, ComparisonOperator.Equal, key.Value ) );
			}

			List<int> matchList = _containedCollection.FindMatches( filter );
			if( matchList.Count <= 0 )
			{
				// no match found
				return null;
			}

			return _containedCollection[matchList[0]];
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets or sets a value indicating whether refetching of data should be performed
		/// </summary>
		/// <value><c>true</c> if refetch; otherwise, <c>false</c>.</value>
		public override bool Refetch
		{
			get
			{
				return base.Refetch;
			}
			set
			{
				if( base.Refetch != value )
				{
					base.Refetch = value;
					RaiseChangedEvent();
				}
			}
		}
		
		
		/// <summary>
		/// Gets the UnitOfWork object for this control, if Livepersistence is set to false in the owner control.
		/// </summary>
		public UnitOfWork2 UoW
		{
			get { return _uow; }
		}


		/// <summary>
		/// Gets or sets the prefetch path.
		/// </summary>
		/// <value>The prefetch path.</value>
		internal IPrefetchPath2 PrefetchPath
		{
			get { return _prefetchPath; }
			set
			{
				_prefetchPath = value;
				this.Refetch = true;
			}
		}


		/// <summary>
		/// Gets or sets the filter to use.
		/// </summary>
		/// <value>The filter to use.</value>
		internal IRelationPredicateBucket FilterToUse
		{
			get
			{
				return _filterToUse;
			}
			set
			{
				_filterToUse = value;
				this.Refetch = true;
			}
		}


		/// <summary>
		/// Gets or sets the adapter to use.
		/// </summary>
		/// <value>The adapter to use.</value>
		internal IDataAccessAdapter AdapterToUse
		{
			get
			{
				return _adapterToUse;
			}
			set
			{
				_adapterToUse = value;
				this.Refetch = true;
			}
		}
				

		/// <summary>
		/// Gets or sets the name of the TypedList type
		/// </summary>
		public string TypedListTypeName
		{
			get
			{
				if(_containedTypedList == null)
				{
					return string.Empty;
				}
				else
				{
					return FieldUtilities.CreateFullTypeName( _containedTypedList.GetType() );
				}
			}
			set
			{
				if( value.Length <= 0 )
				{
					_containedTypedList = null;
					return;
				}
				if(( _containedTypedList == null ) || this.TypedListTypeName!=value)
				{
					Type typeToCreate = Type.GetType( value );
					if( typeToCreate != null )
					{
						_containedTypedList = (ITypedListLgp2)Activator.CreateInstance( typeToCreate);
					}
				}
			}
		}


		/// <summary>
		/// Gets or sets the name of the TypedView type
		/// </summary>
		public string TypedViewTypeName
		{
			get
			{
				if(_containedTypedView == null)
				{
					return string.Empty;
				}
				else
				{
					return FieldUtilities.CreateFullTypeName( _containedTypedView.GetType() );
				}
			}
			set
			{
				if( value.Length <= 0 )
				{
					_containedTypedView = null;
					return;
				}

				if(( _containedTypedView == null ) || this.TypedViewTypeName!=value)
				{
					Type typeToCreate = Type.GetType(value);
					if( typeToCreate != null )
					{
						_containedTypedView = (ITypedView2)Activator.CreateInstance( typeToCreate );
					}
				}
			}
		}


		/// <summary>
		/// Gets or sets the name of the entity factory type.
		/// </summary>
		/// <value>The name of the entity factory type.</value>
		public string EntityFactoryTypeName
		{
			get
			{
				if( (_containedCollection == null) || (_containedCollection.EntityFactoryToUse == null) )
				{
					return string.Empty;
				}
				else
				{
					return FieldUtilities.CreateFullTypeName(_containedCollection.EntityFactoryToUse.GetType());
				}
			}
			set
			{
				if( _containedCollection == null )
				{
					_containedCollection = new EntityCollectionNonGeneric();
				}

				if( this.EntityFactoryTypeName == value )
				{
					return;
				}
				if( value.Length <= 0 )
				{
					this.EntityFactoryToUse = null;
					return;
				}
				Type typeToCreate = Type.GetType(value);
				if( typeToCreate != null )
				{
					this.EntityFactoryToUse = (IEntityFactory2)Activator.CreateInstance( typeToCreate);
				}
			}
		}


		/// <summary>
		/// Gets or sets the name of the DataAccessAdapter type.
		/// </summary>
		/// <value>The name of the adapter type.</value>
		public string AdapterTypeName
		{
			get
			{
				if( _adapterToUse == null )
				{
					return string.Empty;
				}
				else
				{
					return FieldUtilities.CreateFullTypeName( _adapterToUse.GetType() );
				}
			}
			set
			{
				if( value.Length <= 0 )
				{
					this.AdapterToUse= null;
					return;
				}

				if( _adapterToUse == null )
				{
					this.AdapterToUse = (IDataAccessAdapter)Activator.CreateInstance( Type.GetType( value ) );
				}
				else
				{
					if( this.AdapterTypeName == value )
					{
						return;
					}
				}
			}
		}


		/// <summary>
		/// Gets the entity factory to use.
		/// </summary>
		/// <value>The entity factory to use.</value>
		public IEntityFactory2 EntityFactoryToUse
		{
			get
			{
				if( _containedCollection != null )
				{
					return _containedCollection.EntityFactoryToUse;
				}
				else
				{
					return null;
				}
			}
			set
			{
				if( _containedCollection == null )
				{
					_containedCollection = new EntityCollectionNonGeneric();
				}
				_containedCollection.EntityFactoryToUse = value;
				RaiseChangedEvent();
			}
		}


		/// <summary>
		/// Gets or sets the contained entity collection.
		/// </summary>
		/// <value>The contained entity collection.</value>
		public IEntityCollection2 ContainedEntityCollection
		{
			get
			{
				if(base.Owner.DataContainerType!= DataSourceDataContainerType.EntityCollection)
				{
					throw new InvalidOperationException("The contained entity collection is undefined when DataContainerType is set to '" + base.Owner.DataContainerType.ToString() + "'");
				}
				return _containedCollection;
			}
			set
			{
				_containedCollection = value;
				RaiseChangedEvent();
			}
		}


		/// <summary>
		/// Gets or sets the contained typed list
		/// </summary>
		public ITypedListLgp2 ContainedTypedList
		{
			get
			{
				if(base.Owner.DataContainerType!= DataSourceDataContainerType.TypedList)
				{
					throw new InvalidOperationException("The contained typed list is undefined when DataContainerType is set to '" + base.Owner.DataContainerType.ToString() + "'");
				}
				return _containedTypedList;
			}
			set
			{
				_containedTypedList = value;
				RaiseChangedEvent();
			}
		}


		/// <summary>
		/// Gets or sets the contained typed list
		/// </summary>
		public ITypedView2 ContainedTypedView
		{
			get
			{
				if(base.Owner.DataContainerType!= DataSourceDataContainerType.TypedView)
				{
					throw new InvalidOperationException("The contained typed view is undefined when DataContainerType is set to '" + base.Owner.DataContainerType.ToString() + "'");
				}
				return _containedTypedView;
			}
			set
			{
				_containedTypedView = value;
				RaiseChangedEvent();
			}
		}

		#endregion
	}




	/// <summary>
	/// General implementation of the DataSourceView class to be used with LLBLGenProDataSource control in ASP.NET applications.
	/// </summary>
	/// <remarks>Selfservicing specific</remarks>
	[AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public class LLBLGenProDataSourceView : LLBLGenProDataSourceViewBase, IDisposable
	{
		#region Class Member Declarations
		private IEntityCollection _containedCollection;
		private ITypedListLgp _containedTypedList;
		private ITypedView _containedTypedView;
		private IPredicateExpression _filterToUse;
		private IRelationCollection _relationsToUse;
		private bool _isDisposed;
		private UnitOfWork _uow;
		private IPrefetchPath _prefetchPath;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="LLBLGenProDataSourceView"/> class.
		/// </summary>
		/// <param name="_owner">The _owner.</param>
		/// <param name="viewName">Name of the view.</param>
		public LLBLGenProDataSourceView( LLBLGenProDataSource _owner, string viewName )
			: base( _owner, viewName )
		{
			_filterToUse = null;
			_isDisposed = false;
			_uow = null;
			_relationsToUse = null;
			_prefetchPath = null;
		}


		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public override void Dispose()
		{
			Dispose( true );
			GC.SuppressFinalize( this );
		}


		/// <summary>
		/// Implements the Dispose functionality. If a transaction is in progress, it will rollback that transaction.
		/// </summary>
		/// <param name="isDisposing">Flag which signals this routine if a dispose action should take place (true) or not (false)</param>
		protected virtual void Dispose( bool isDisposing )
		{
			// Check to see if Dispose has already been called.
			if( !_isDisposed )
			{
				if( isDisposing )
				{
					_isDisposed = true;
				}
			}
		}


		/// <summary>
		/// Sets the prefetch path.
		/// </summary>
		/// <param name="prefetchPath">The prefetch path.</param>
		protected override void SetPrefetchPath( object prefetchPath )
		{
			_prefetchPath = (IPrefetchPath)prefetchPath;
		}


		/// <summary>
		/// Sets the filter.
		/// </summary>
		/// <param name="filterObject">The filter object.</param>
		protected override void SetFilter( object filterObject )
		{
			_filterToUse = (IPredicateExpression)filterObject;
		}

		/// <summary>
		/// Sets the relation collection.
		/// </summary>
		/// <param name="relationCollection">The relation collection.</param>
		protected override void SetRelationCollection( object relationCollection )
		{
			_relationsToUse = (IRelationCollection)relationCollection;
		}


		/// <summary>
		/// Sets the unit of work.
		/// </summary>
		/// <param name="uow">The unit of work.</param>
		protected override void SetUnitOfWork( object uow )
		{
			_uow = (UnitOfWork)uow;
		}


		/// <summary>
		/// Sets the datacontainer object
		/// </summary>
		/// <param name="dataContainer">the datacontainer object to set.</param>
		protected override void SetDataContainer( object dataContainer )
		{
			switch( base.Owner.DataContainerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					_containedCollection = (IEntityCollection)dataContainer;
					break;
				case DataSourceDataContainerType.TypedList:
					_containedTypedList = (ITypedListLgp)dataContainer;
					break;
				case DataSourceDataContainerType.TypedView:
					_containedTypedView = (ITypedView)dataContainer;
					break;
			}
		}


		/// <summary>
		/// Creates the state data object.
		/// </summary>
		/// <returns></returns>
		protected override object[] CreateStateDataObject()
		{
			object[] state = base.CreateStateDataObject();
			state[(int)StateSlot.Filter] = _filterToUse;
			state[(int)StateSlot.RelationCollection] = _relationsToUse;
			switch( base.Owner.DataContainerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					state[(int)StateSlot.DataContainer] = _containedCollection;
					break;
				case DataSourceDataContainerType.TypedList:
					state[(int)StateSlot.DataContainer] = _containedTypedList;
					break;
				case DataSourceDataContainerType.TypedView:
					state[(int)StateSlot.DataContainer] = _containedTypedView;
					break;
			}
			state[(int)StateSlot.UnitOfWork] = _uow;
			state[(int)StateSlot.PrefetchPath] = _prefetchPath;

			return state;
		}


		/// <summary>
		/// Creates the filter from the parameters specified.
		/// </summary>
		/// <returns>PredicateExpression to use as additional filter for a select</returns>
		private IPredicateExpression CreateRuntimeFilter()
		{
			PredicateExpression toReturn = new PredicateExpression();
			IEntityFields fields = null;
			switch( base.Owner.DataContainerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					if( _containedCollection.EntityFactoryToUse == null )
					{
						return null;
					}
					fields = _containedCollection.EntityFactoryToUse.CreateFields();
					break;
				case DataSourceDataContainerType.TypedList:
					fields = _containedTypedList.BuildResultset();
					break;
				case DataSourceDataContainerType.TypedView:
					fields = _containedTypedView.GetFields();
					break;
			}
			ParameterCollection parameters = base.SelectParameters;
			IOrderedDictionary parameterValues = parameters.GetValues( base.Owner.GetContext(), base.Owner );

			// build filters
			foreach( Parameter p in parameters )
			{
				IEntityField field = fields[p.Name];
				if( field == null )
				{
					// mismatch, skip
					continue;
				}
				object parameterValue = parameterValues[p.Name];
				if( parameterValue == null )
				{
					toReturn.AddWithAnd( new FieldCompareNullPredicate( field) );
				}
				else
				{
					toReturn.AddWithAnd( new FieldCompareValuePredicate( field, ComparisonOperator.Equal,
						base.ConvertValueToDestinationType(field.DataType, parameterValues[p.Name], field.Alias)));
				}

			}

			if( toReturn.Count <= 0 )
			{
				toReturn = null;
			}

			return toReturn;
		}



		/// <summary>
		/// Performs an update operation on the list of data that the <see cref="T:System.Web.UI.DataSourceView"></see> object represents.
		/// </summary>
		/// <param name="keys">An <see cref="T:System.Collections.IDictionary"></see> of object or row keys to be updated by the update operation.</param>
		/// <param name="values">An <see cref="T:System.Collections.IDictionary"></see> of name/value pairs that represent data elements and their new values.</param>
		/// <param name="oldValues">An <see cref="T:System.Collections.IDictionary"></see> of name/value pairs that represent data elements and their original values.</param>
		/// <returns>
		/// The number of items that were updated in the underlying data storage.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="M:System.Web.UI.DataSourceView.ExecuteUpdate(System.Collections.IDictionary,System.Collections.IDictionary,System.Collections.IDictionary)"></see> operation is not supported by the <see cref="T:System.Web.UI.DataSourceView"></see>. </exception>
		protected override int ExecuteUpdate( IDictionary keys, IDictionary values, IDictionary oldValues )
		{
			if( (_containedCollection == null) || (_containedCollection.Count <= 0) )
			{
				return 0;
			}

			if( !this.CanUpdate )
			{
				throw new NotSupportedException( "Updating data isn't supported in the current configuration." );
			}

			if( keys.Count <= 0 )
			{
				// can't update anything, no keys specified.
				throw new ORMGeneralOperationException( "There are no primary key fields specified in the bound control and/or the bound control didn't specify any primary key fields. Update can't continue." );
			}

			IDictionary valuesToSet = new OrderedDictionary( StringComparer.OrdinalIgnoreCase );
			base.MergeDictionaries(base.UpdateParameters, values, valuesToSet);
			IEntity matchingEntity = FindEntity( keys );
			if( matchingEntity == null )
			{
				// no match found
				return 0;
			}

			SetEntityValues( valuesToSet, matchingEntity );

			bool cancel = base.Owner.OnEntityUpdating(matchingEntity);
			if(cancel)
			{
				return 0;
			}
			if( base.Owner.LivePersistence )
			{
				// save now
				bool result = matchingEntity.Save( true );
				if(result)
				{
					base.Owner.OnEntityUpdated(matchingEntity);
				}
			}
			else
			{
				if( _uow == null )
				{
					_uow = new UnitOfWork();
				}
				_uow.AddForSave( matchingEntity );
				try
				{
					// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
					base.SurpressChangedEvent = true;
					((LLBLGenProDataSource)base.Owner).OnPerformWork( new PerformWorkEventArgs( _uow ) );
				}
				finally
				{
					base.SurpressChangedEvent = false;
				}
			}

			this.Refetch = true;
			return 1;
		}


		/// <summary>
		/// Performs a delete operation on the list of data that the <see cref="T:System.Web.UI.DataSourceView"></see> object represents.
		/// </summary>
		/// <param name="keys">An <see cref="T:System.Collections.IDictionary"></see> of object or row keys to be deleted by the <see cref="M:System.Web.UI.DataSourceView.ExecuteDelete(System.Collections.IDictionary,System.Collections.IDictionary)"></see> operation.</param>
		/// <param name="oldValues">An <see cref="T:System.Collections.IDictionary"></see> of name/value pairs that represent data elements and their original values.</param>
		/// <returns>
		/// The number of items that were deleted from the underlying data storage.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="M:System.Web.UI.DataSourceView.ExecuteDelete(System.Collections.IDictionary,System.Collections.IDictionary)"></see> operation is not supported by the <see cref="T:System.Web.UI.DataSourceView"></see>. </exception>
		protected override int ExecuteDelete( IDictionary keys, IDictionary oldValues )
		{
			if((_containedCollection == null) || (_containedCollection.Count <= 0) )
			{
				return 0;
			}

			if( !this.CanDelete )
			{
				throw new NotSupportedException( "Deleting data isn't supported in the current configuration." );
			}

			if( keys.Count <= 0 )
			{
				// can't update anything, no keys specified.
				throw new ORMGeneralOperationException( "There are no primary key fields specified in the bound control and/or the bound control didn't specify any primary key fields. Delete can't continue." );
			}

			IEntity matchingEntity = FindEntity( keys );
			if( matchingEntity == null )
			{
				// no match found
				return 0;
			}
			bool cancel = base.Owner.OnEntityDeleting(matchingEntity);
			if(cancel)
			{
				return 0;
			}

			if( base.Owner.LivePersistence )
			{
				// delete now.
				bool result = matchingEntity.Delete();
				if(result)
				{
					base.Owner.OnEntityDeleted(matchingEntity);
				}
			}
			else
			{
				if( _uow == null )
				{
					_uow = new UnitOfWork();
				}
				_uow.AddForDelete( matchingEntity );
				try
				{
					// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
					base.SurpressChangedEvent = true;
					((LLBLGenProDataSource)base.Owner).OnPerformWork( new PerformWorkEventArgs( _uow ) );
				}
				finally
				{
					base.SurpressChangedEvent = false;
				}
			}

			if(matchingEntity.Fields.State == EntityState.Deleted)
			{
				// remove entity from datasource. This is necessary because multiple calls to this method without refetching the data would otherwise
				// result in exceptions.
				_containedCollection.Remove(matchingEntity);
			}

			this.Refetch = true;
			return 1;
		}


		/// <summary>
		/// Performs an insert operation on the list of data that the <see cref="T:System.Web.UI.DataSourceView"></see> object represents.
		/// </summary>
		/// <param name="values">An <see cref="T:System.Collections.IDictionary"></see> of name/value pairs used during an insert operation.</param>
		/// <returns>
		/// The number of items that were inserted into the underlying data storage.
		/// </returns>
		/// <exception cref="T:System.NotSupportedException">The <see cref="M:System.Web.UI.DataSourceView.ExecuteInsert(System.Collections.IDictionary)"></see> operation is not supported by the <see cref="T:System.Web.UI.DataSourceView"></see>. </exception>
		protected override int ExecuteInsert( IDictionary values )
		{
			if( (_containedCollection == null) || (_containedCollection.EntityFactoryToUse == null) )
			{
				return 0;
			}

			if( !this.CanInsert )
			{
				throw new NotSupportedException( "Inserting data isn't supported in the current configuration." );
			}

			IDictionary valuesToSet = new OrderedDictionary( StringComparer.OrdinalIgnoreCase );
			base.MergeDictionaries(base.InsertParameters, values, valuesToSet);
			IEntity newEntity = _containedCollection.EntityFactoryToUse.Create();
			SetEntityValues( valuesToSet, newEntity );

			bool cancel = base.Owner.OnEntityInserting(newEntity);
			if(cancel)
			{
				return 0;
			}

			if( base.Owner.LivePersistence )
			{
				// save now
				bool result = newEntity.Save( true );
				if(result)
				{
					base.Owner.OnEntityInserted(newEntity);
				}
			}
			else
			{
				if( _uow == null )
				{
					_uow = new UnitOfWork();
				}
				_uow.AddForSave( newEntity );
				try
				{
					// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
					base.SurpressChangedEvent = true;
					((LLBLGenProDataSource)base.Owner).OnPerformWork( new PerformWorkEventArgs( _uow ) );
				}
				finally
				{
					base.SurpressChangedEvent = false;
				}
			}

			this.Refetch = true;
			return 1;
		}


		/// <summary>
		/// Gets a list of data from the underlying data storage.
		/// </summary>
		/// <param name="arguments">A <see cref="T:System.Web.UI.DataSourceSelectArguments"></see> that is used to request operations on the data beyond basic data retrieval.</param>
		/// <returns>
		/// An <see cref="T:System.Collections.IEnumerable"></see> list of data from the underlying data storage.
		/// </returns>
		protected override IEnumerable ExecuteSelect( DataSourceSelectArguments arguments )
		{
			if( this.CanPage )
			{
				arguments.AddSupportedCapabilities( DataSourceCapabilities.Page );
			}
			if( this.CanRetrieveTotalRowCount )
			{
				arguments.AddSupportedCapabilities( DataSourceCapabilities.RetrieveTotalRowCount );
			}

			arguments.RaiseUnsupportedCapabilitiesError( this );

			int pageSize = arguments.MaximumRows;
			int pageNumber = 0;
			if( pageSize > 0 )
			{
				pageNumber = (arguments.StartRowIndex / pageSize) + 1;
			}

			base.CompareSelectParameters();

			IEnumerable toReturn = null;
			switch( base.Owner.DataContainerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					if( _containedCollection != null )
					{
						toReturn = ExecuteSelectEntityCollection( pageSize, pageNumber, arguments );
					}
					break;
				case DataSourceDataContainerType.TypedList:
					if( _containedTypedList != null )
					{
						toReturn = ExecuteSelectTypedList( pageSize, pageNumber, arguments );
					}
					break;
				case DataSourceDataContainerType.TypedView:
					if( _containedTypedView != null )
					{
						toReturn = ExecuteSelectTypedView( pageSize, pageNumber, arguments );
					}
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Executes the select entity collection.
		/// </summary>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="arguments">The arguments.</param>
		/// <returns></returns>
		private IEnumerable ExecuteSelectEntityCollection( int pageSize, int pageNumber, DataSourceSelectArguments arguments )
		{
			if( _containedCollection == null )
			{
				return null;
			}

			ISortExpression sorterToUseForFetch = null;
			ISortExpression sorterToUseForView = null;
			ISortExpression sorter = ProduceSorterToUse( _containedCollection.EntityFactoryToUse.CreateFields(), arguments );
			switch( base.SortingMode )
			{
				case DataSourceSortingMode.ClientSide:
					sorterToUseForFetch = null;
					sorterToUseForView = sorter;
					break;
				case DataSourceSortingMode.ServerSide:
					sorterToUseForView = null;
					sorterToUseForFetch = sorter;
					break;
			}
			// test to see if we need to fetch new data or can re-use the existing data.
			if( (pageSize != base.PageSize) || (pageNumber != base.PageNumber) ||
					((arguments.SortExpression != base.SortExpression) && (base.SortingMode == DataSourceSortingMode.ServerSide)) || base.Refetch )
			{
				base.PageSize = pageSize;
				base.PageNumber = pageNumber;
				base.SortExpression = arguments.SortExpression;
				_containedCollection.Clear();

				IPredicateExpression filter = ProduceFilterToUse( _filterToUse );

				if( base.Owner.LivePersistence )
				{
					// check the operation to perform
					if( arguments.RetrieveTotalRowCount )
					{
						// calculate the total rowcount
						arguments.TotalRowCount = _containedCollection.GetDbCount(filter, _relationsToUse);
						base.TotalRowCount = arguments.TotalRowCount;
					}
					_containedCollection.GetMulti( filter, (long)base.Owner.MaxNumberOfItemsToReturn, sorterToUseForFetch, _relationsToUse, _prefetchPath, base.PageNumber,
							base.PageSize );
					base.Owner.OnElementsFetched();
				}
				else
				{
					try
					{
						// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
						base.SurpressChangedEvent = true;
						if( arguments.RetrieveTotalRowCount )
						{
							PerformGetDbCountEventArgs dbCountEventArgs = new PerformGetDbCountEventArgs( filter, _relationsToUse, _containedCollection );
							((LLBLGenProDataSource)base.Owner).OnPerformDbCount( dbCountEventArgs );
							arguments.TotalRowCount = dbCountEventArgs.DbCount;
							base.TotalRowCount = arguments.TotalRowCount;
						}
						((LLBLGenProDataSource)base.Owner).OnPerformSelect( new PerformSelectEventArgs( filter, _relationsToUse, base.Owner.MaxNumberOfItemsToReturn,
								base.PageSize, base.PageNumber, sorterToUseForFetch, _containedCollection, _prefetchPath ) );
					}
					finally
					{
						base.SurpressChangedEvent = false;
					}
					// clear unit of work
					_uow = null;
				}
				base.Refetch = false;
			}
			else
			{
				if( arguments.RetrieveTotalRowCount )
				{
					// calculate the total rowcount
					arguments.TotalRowCount = base.TotalRowCount;
				}
			}
			IEntityView toReturn = _containedCollection.DefaultView;
			toReturn.Sorter = sorterToUseForView;

			return toReturn;
		}


		/// <summary>
		/// Executes the select typed list
		/// </summary>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="arguments">The arguments.</param>
		/// <returns></returns>
		private IEnumerable ExecuteSelectTypedList( int pageSize, int pageNumber, DataSourceSelectArguments arguments )
		{
			if( _containedTypedList == null )
			{
				return null;
			}

			// test to see if we need to fetch new data or can re-use the existing data.
			if( (pageSize != base.PageSize) || (pageNumber != base.PageNumber) || (arguments.SortExpression != base.SortExpression) || base.Refetch )
			{
				base.PageSize = pageSize;
				base.PageNumber = pageNumber;
				base.SortExpression = arguments.SortExpression;
				((DataTable)_containedTypedList).Clear();

				// check the operation to perform
				IEntityFields fields = _containedTypedList.BuildResultset();
				IPredicateExpression filter = ProduceFilterToUse( _filterToUse );

				ISortExpression sorter = ProduceSorterToUse( fields, arguments );
				if( base.Owner.LivePersistence )
				{
					if( arguments.RetrieveTotalRowCount )
					{
						// calculate the total rowcount
						arguments.TotalRowCount = _containedTypedList.GetDbCount(base.Owner.AllowDuplicates, filter, _relationsToUse, (GroupByCollection)base.GroupBy);
						base.TotalRowCount = arguments.TotalRowCount;
					}
					_containedTypedList.Fill( (long)base.Owner.MaxNumberOfItemsToReturn, sorter, base.Owner.AllowDuplicates, filter, null, base.GroupBy,
							pageNumber, pageSize );
					base.Owner.OnElementsFetched();
				}
				else
				{
					try
					{
						// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
						base.SurpressChangedEvent = true;
						if( arguments.RetrieveTotalRowCount )
						{
							// calculate the total rowcount
							PerformGetDbCountEventArgs dbCountEventArgs = new PerformGetDbCountEventArgs( filter, _relationsToUse, fields, base.Owner.AllowDuplicates,
									base.GroupBy );
							((LLBLGenProDataSource)base.Owner).OnPerformDbCount( dbCountEventArgs );
							arguments.TotalRowCount = dbCountEventArgs.DbCount;
							base.TotalRowCount = arguments.TotalRowCount;
						}
						((LLBLGenProDataSource)base.Owner).OnPerformSelect( new PerformSelectEventArgs( filter, _relationsToUse, base.Owner.MaxNumberOfItemsToReturn,
								base.PageSize, base.PageNumber, sorter, _containedTypedList, fields, base.Owner.AllowDuplicates, base.GroupBy ) );
					}
					finally
					{
						base.SurpressChangedEvent = false;
					}
				}
				base.Refetch = false;
			}
			else
			{
				if( arguments.RetrieveTotalRowCount )
				{
					// calculate the total rowcount
					arguments.TotalRowCount = base.TotalRowCount;
				}
			}
			return ((DataTable)_containedTypedList).DefaultView;
		}


		/// <summary>
		/// Executes the select typed view
		/// </summary>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="arguments">The arguments.</param>
		/// <returns></returns>
		private IEnumerable ExecuteSelectTypedView( int pageSize, int pageNumber, DataSourceSelectArguments arguments )
		{
			if( _containedTypedView == null )
			{
				return null;
			}

			// test to see if we need to fetch new data or can re-use the existing data.
			if( (pageSize != base.PageSize) || (pageNumber != base.PageNumber) || (arguments.SortExpression != base.SortExpression) || base.Refetch )
			{
				base.PageSize = pageSize;
				base.PageNumber = pageNumber;
				base.SortExpression = arguments.SortExpression;
				((DataTable)_containedTypedView).Clear();

				IEntityFields fields = _containedTypedView.GetFields();

				IPredicateExpression filter = ProduceFilterToUse( _filterToUse );
				ISortExpression sorter = ProduceSorterToUse( fields, arguments );
				if( base.Owner.LivePersistence )
				{
					// check the operation to perform
					if( arguments.RetrieveTotalRowCount )
					{
						// calculate the total rowcount
						arguments.TotalRowCount = _containedTypedView.GetDbCount( base.Owner.AllowDuplicates, filter, (GroupByCollection)base.GroupBy );
						base.TotalRowCount = arguments.TotalRowCount;
					}
					_containedTypedView.Fill( (long)base.Owner.MaxNumberOfItemsToReturn, sorter, base.Owner.AllowDuplicates, filter, null,
							base.GroupBy, pageNumber, pageSize );
					base.Owner.OnElementsFetched();
				}
				else
				{
					try
					{
						// surpress the changed event as the external call could cause the changed event to happen which could lead to infinite loops.
						base.SurpressChangedEvent = true;
						if( arguments.RetrieveTotalRowCount )
						{
							PerformGetDbCountEventArgs dbCountEventArgs = new PerformGetDbCountEventArgs( filter, _relationsToUse, fields, base.Owner.AllowDuplicates,
									base.GroupBy );
							((LLBLGenProDataSource)base.Owner).OnPerformDbCount( dbCountEventArgs );
							arguments.TotalRowCount = dbCountEventArgs.DbCount;
							base.TotalRowCount = arguments.TotalRowCount;
						}
						((LLBLGenProDataSource)base.Owner).OnPerformSelect( new PerformSelectEventArgs( filter, _relationsToUse, base.Owner.MaxNumberOfItemsToReturn,
								base.PageSize, base.PageNumber, sorter, _containedTypedView, fields, base.GroupBy ) );
					}
					finally
					{
						base.SurpressChangedEvent = false;
					}
				}
				base.Refetch = false;
			}
			else
			{
				if( arguments.RetrieveTotalRowCount )
				{
					// calculate the total rowcount
					arguments.TotalRowCount = base.TotalRowCount;
				}
			}
			return ((DataTable)_containedTypedView).DefaultView;
		}


		/// <summary>
		/// Routine which produces a sortexpression to use for sorting, which merges a sortexpression produced from the arguments with the set sortexpression.
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <param name="arguments">The arguments.</param>
		/// <returns></returns>
		private ISortExpression ProduceSorterToUse( IEntityFields fields, DataSourceSelectArguments arguments )
		{
			ISortExpression sorter = new SortExpression();
			if( string.IsNullOrEmpty( arguments.SortExpression ) )
			{
				if( base.SorterToUse != null )
				{
					foreach( SortClause clause in base.SorterToUse )
					{
						sorter.Add( clause );
					}
				}
			}
			else
			{
				if( sorter == null )
				{
					sorter = base.ProduceSortExpressionFromString( fields, arguments.SortExpression );
				}
				else
				{
					ISortExpression argumentsSorter = base.ProduceSortExpressionFromString( fields, arguments.SortExpression );
					foreach( ISortClause clause in argumentsSorter )
					{
						sorter.Add( clause );
					}
				}
			}
			return sorter;
		}


		/// <summary>
		/// Routine which will use the base filter passed in and the runtime filter created internally to produce a new filter to use for a select operation.
		/// </summary>
		/// <param name="baseFilter"></param>
		/// <returns></returns>
		private IPredicateExpression ProduceFilterToUse( IPredicateExpression baseFilter )
		{
			IPredicateExpression filter = null;
			if(( baseFilter != null ) && (baseFilter.Count>0))
			{
				filter = new PredicateExpression( baseFilter );
			}
			IPredicateExpression runtimeFilter = CreateRuntimeFilter();
			if( runtimeFilter != null )
			{
				if( filter == null )
				{
					filter = new PredicateExpression();
				}
				filter.AddWithAnd( runtimeFilter );
			}

			return filter;
		}


		/// <summary>
		/// Sets the entity values.
		/// </summary>
		/// <param name="values">The values.</param>
		/// <param name="entity">The entity.</param>
		private void SetEntityValues( IDictionary values, IEntity entity )
		{
			// match found, update all fields. Do this through property descriptors so all properties can be updated properly.
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties( entity.GetType() );
			Dictionary<string, PropertyDescriptor> propertiesIndexed = new Dictionary<string, PropertyDescriptor>( properties.Count );
			foreach( PropertyDescriptor descriptor in properties )
			{
				propertiesIndexed.Add( descriptor.Name, descriptor );
			}

			List<string> fieldNamesKeepEmptyStringAsValue = base.FieldNamesKeepEmptyStringAsValue;
			Dictionary<string, object> illegalFieldValues = new Dictionary<string, object>();

			foreach( DictionaryEntry newValueEntry in values )
			{
				PropertyDescriptor descriptor = null;
				if( !propertiesIndexed.TryGetValue( (string)newValueEntry.Key, out descriptor ) )
				{
					// not found
					continue;
				}

				IEntityField field = entity.Fields[(string)newValueEntry.Key];
				object newValue = null;
				if( newValueEntry.Value != null )
				{
					string fieldName = null;
					if(field != null)
					{
						fieldName = field.Alias;
					}
					try
					{
						newValue = base.ConvertValueToDestinationType(descriptor.PropertyType, newValueEntry.Value, fieldName);
					}
					catch
					{
						// add field / value to dictionary and continue
						illegalFieldValues.Add(fieldName, newValueEntry.Value);
						continue;
					}
				}

				if( field != null )
				{
					if( field.IsReadOnly )
					{
						// can't set a readonly field
						continue;
					}
					if( (newValue == null) && (!field.IsNullable) )
					{
						// can't set a nonnullable field to null
						continue;
					}
					entity.SetNewFieldValue( field.Name, newValue );
				}
				else
				{
					descriptor.SetValue( entity, newValue );
				}
			}
			
			if(base.ThrowExceptionOnIllegalFieldInput && (illegalFieldValues.Count > 0))
			{
				throw new ORMValueTypeMismatchException("There were one or more values not convertable to their field types. Please examine the 'IllegalFieldValues' and 'TargetEntity' properties of this exception for more information.", illegalFieldValues, entity);
			}
		}



		/// <summary>
		/// Finds the entity matching the PK fields specified in keys in the contained collection.
		/// </summary>
		/// <param name="keys">The keys.</param>
		/// <returns></returns>
		private IEntity FindEntity( IDictionary keys )
		{
			IPredicateExpression filter = new PredicateExpression();
			foreach( DictionaryEntry key in keys )
			{
				filter.AddWithAnd( new FieldCompareValuePredicate( _containedCollection[0].Fields[(string)key.Key], null, ComparisonOperator.Equal, key.Value ) );
			}

			List<int> matchList = _containedCollection.FindMatches( filter );
			if( matchList.Count <= 0 )
			{
				// no match found
				return null;
			}

			return _containedCollection[matchList[0]];
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets or sets a value indicating whether refetching of data should be performed
		/// </summary>
		/// <value><c>true</c> if refetch; otherwise, <c>false</c>.</value>
		public override bool Refetch
		{
			get
			{
				return base.Refetch;
			}
			set
			{
				if( base.Refetch != value )
				{
					base.Refetch = value;
					RaiseChangedEvent();
				}
			}
		}


		/// <summary>
		/// Gets the UnitOfWork object for this control, if Livepersistence is set to false in the owner control.
		/// </summary>
		public UnitOfWork UoW
		{
			get { return _uow; }
		}


		/// <summary>
		/// Gets or sets the prefetch path.
		/// </summary>
		/// <value>The prefetch path.</value>
		internal IPrefetchPath PrefetchPath
		{
			get { return _prefetchPath; }
			set
			{
				_prefetchPath = value;
				this.Refetch = true;
			}
		}


		/// <summary>
		/// Gets or sets the filter to use.
		/// </summary>
		/// <value>The filter to use.</value>
		internal IPredicateExpression FilterToUse
		{
			get
			{
				return _filterToUse;
			}
			set
			{
				_filterToUse = value;
				this.Refetch = true;
			}
		}


		/// <summary>
		/// Gets or sets the relations to use.
		/// </summary>
		/// <value>The relations to use.</value>
		internal IRelationCollection RelationsToUse
		{
			get
			{
				return _relationsToUse;
			}
			set
			{
				_relationsToUse = value;
				this.Refetch = true;
			}
		}


		/// <summary>
		/// Gets or sets the name of the TypedList type
		/// </summary>
		public string TypedListTypeName
		{
			get
			{
				if( _containedTypedList == null )
				{
					return string.Empty;
				}
				else
				{
					return FieldUtilities.CreateFullTypeName( _containedTypedList.GetType() );
				}
			}
			set
			{
				if( value.Length <= 0 )
				{
					_containedTypedList = null;
					return;
				}
				if( (_containedTypedList == null) || this.TypedListTypeName != value )
				{
					Type typeToCreate = Type.GetType( value );
					if( typeToCreate != null )
					{
						this.ContainedTypedList = (ITypedListLgp)Activator.CreateInstance( typeToCreate );
					}
				}
			}
		}


		/// <summary>
		/// Gets or sets the name of the TypedView type
		/// </summary>
		public string TypedViewTypeName
		{
			get
			{
				if( _containedTypedView == null )
				{
					return string.Empty;
				}
				else
				{
					return FieldUtilities.CreateFullTypeName( _containedTypedView.GetType() );
				}
			}
			set
			{
				if( value.Length <= 0 )
				{
					_containedTypedView = null;
					return;
				}

				if( (_containedTypedView == null) || this.TypedViewTypeName != value )
				{
					Type typeToCreate = Type.GetType( value );
					if( typeToCreate != null )
					{
						this.ContainedTypedView = (ITypedView)Activator.CreateInstance( typeToCreate );
					}
				}
			}
		}


		/// <summary>
		/// Gets or sets the name of the entity collection
		/// </summary>
		public string EntityCollectionTypeName
		{
			get
			{
				if( _containedCollection == null) 
				{
					return string.Empty;
				}
				else
				{
					return FieldUtilities.CreateFullTypeName( _containedCollection.GetType() );
				}
			}
			set
			{
				if( this.EntityCollectionTypeName == value )
				{
					return;
				}

				if( value.Length <= 0 )
				{
					_containedCollection = null;
					return;
				}
				Type typeToCreate = Type.GetType( value );
				if( typeToCreate != null )
				{
					this.ContainedEntityCollection = (IEntityCollection)Activator.CreateInstance( typeToCreate );
				}
			}
		}


		/// <summary>
		/// Gets or sets the contained entity collection.
		/// </summary>
		/// <value>The contained entity collection.</value>
		public IEntityCollection ContainedEntityCollection
		{
			get
			{
				if( base.Owner.DataContainerType != DataSourceDataContainerType.EntityCollection )
				{
					throw new InvalidOperationException( "The contained entity collection is undefined when DataContainerType is set to '" + base.Owner.DataContainerType.ToString() + "'" );
				}
				return _containedCollection;
			}
			set
			{
				_containedCollection = value;
				RaiseChangedEvent();
			}
		}


		/// <summary>
		/// Gets or sets the contained typed list
		/// </summary>
		public ITypedListLgp ContainedTypedList
		{
			get
			{
				if( base.Owner.DataContainerType != DataSourceDataContainerType.TypedList )
				{
					throw new InvalidOperationException( "The contained typed list is undefined when DataContainerType is set to '" + base.Owner.DataContainerType.ToString() + "'" );
				}
				return _containedTypedList;
			}
			set
			{
				_containedTypedList = value;
				RaiseChangedEvent();
			}
		}


		/// <summary>
		/// Gets or sets the contained typed list
		/// </summary>
		public ITypedView ContainedTypedView
		{
			get
			{
				if( base.Owner.DataContainerType != DataSourceDataContainerType.TypedView )
				{
					throw new InvalidOperationException( "The contained typed view is undefined when DataContainerType is set to '" + base.Owner.DataContainerType.ToString() + "'" );
				}
				return _containedTypedView;
			}
			set
			{
				_containedTypedView = value;
				RaiseChangedEvent();
			}
		}

		#endregion
	}


	/// <summary>
	/// General datasource control base class for the selfservicing/adapter datasource controls for ASP.NET
	/// </summary>
	[AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public abstract class LLBLGenProDataSourceBase : DataSourceControl
	{
		#region Events
		/// <summary>
		/// Event which is raised when this datasource control is about to perform the Insert action on an entity. If LivePersistence is set to false,
		/// this event is raised right before the entity to insert is added to the unitofwork(2) object. Cancelling this event will abort the insert action and
		/// the entity won't be inserted. The entity to insert is part of the event args.
		/// </summary>
		public event EventHandler<CancelableDataSourceActionEventArgs> EntityInserting;
		/// <summary>
		/// Event which is raised when this datasource control is about to perform the update action on an entity. If LivePersistence is set to false,
		/// this event is raised right before the entity to update is added to the unitofwork(2) object. Cancelling this event will abort the update action and
		/// the entity won't be inserted. The entity to update is part of the event args.
		/// </summary>
		public event EventHandler<CancelableDataSourceActionEventArgs> EntityUpdating;
		/// <summary>
		/// Event which is raised when this datasource control is about to perform the delete action on an entity. If LivePersistence is set to false,
		/// this event is raised right before the entity to delete is added to the unitofwork(2) object. Cancelling this event will abort the delete action and
		/// the entity won't be inserted. The entity to delete is part of the event args.
		/// </summary>
		public event EventHandler<CancelableDataSourceActionEventArgs> EntityDeleting;

		/// <summary>
		/// Event which is raised when LivePersistence is set to true and an entity was inserted successfully. The inserted entity is part of the 
		/// event args. 
		/// </summary>
		/// <remarks>Be aware that if you're using Adapter the entity is in general 'out-of-sync' so you can only access PK values without a problem. This
		/// is in general not a problem as this event is mostly used to obtain a newly inserted PK value of a new entity.</remarks>
		public event EventHandler<DataSourceActionEventArgs> EntityInserted;
		/// <summary>
		/// Event which is raised when LivePersistence is set to true and an entity was updated successfully. The updated entity is part of the 
		/// event args. 
		/// </summary>
		/// <remarks>Be aware that if you're using Adapter the entity is in general 'out-of-sync' so you can only access PK values without a problem.</remarks>
		public event EventHandler<DataSourceActionEventArgs> EntityUpdated;
		/// <summary>
		/// Event which is raised when LivePersistence is set to true and an entity was deleted successfully. The deleted entity is part of the 
		/// event args. 
		/// </summary>
		/// <remarks>Be aware that the entity in the event args has already been deleted and therefore reading its properties directly will cause an
		/// exception. If you need to obtain field values, please either set the 'State' property of the Fields object to Fetched, or read the field's
		/// CurrentValue property directly.</remarks>
		public event EventHandler<DataSourceActionEventArgs> EntityDeleted;

		/// <summary>
		/// Event which is raised when LivePersistence is set to true and the datasource control has performed a fetch of elements (be it entities, a typed list or
		/// a typedview). Use this event to be able to perform actions when a fetch takes place. The sender of the event is the datasource control so use that 
		/// object to obtain the data fetched.
		/// </summary>
		public event EventHandler ElementsFetched;
		#endregion

		#region Local Enums
		/// <summary>
		/// Enum for the state slots in the view state slot object
		/// </summary>
		internal enum ViewStateSlot
		{
			/// <summary>
			/// Slot for the state data of this object
			/// </summary>
			OwnState,
			/// <summary>
			/// slot for the state data of the default view object
			/// </summary>
			DefaultViewState,
			// add more here
			/// <summary>
			/// 
			/// </summary>
			NumberOfSlots
		}

		/// <summary>
		/// Enum for the state slots in the control state slot object
		/// </summary>
		internal enum ControlStateSlot
		{
			/// <summary>
			/// Slot for the key used for storage in the session
			/// </summary>
			DataStorageKey,
			/// <summary>
			/// Slot for the Cache location setting
			/// </summary>
			CacheLocation,
			/// <summary>
			/// Slot for the enable paging flag
			/// </summary>
			EnablePaging,
			/// <summary>
			/// Slot for the data container type
			/// </summary>
			DataContainerType,
			/// <summary>
			/// Slot for the max number of items to return
			/// </summary>
			MaxNumberOfItemsToReturn,
			/// <summary>
			/// Slot for the flag if duplicate instances should be fetched
			/// </summary>
			AllowDuplicates,
			/// <summary>
			/// Slot for the flag if manipulation of data should be send directly to the database or to a UnitOfWork object.
			/// </summary>
			LivePersistence,
			/// <summary>
			/// Slot for the ASPNetcacheDuration value.
			/// </summary>
			ASPNetCacheDuration,
			/// <summary>
			/// Slot for the key used for storing the data in the asp.net cache (if applicable)
			/// </summary>
			ASPNetCacheStorageKey,
			// add more here
			/// <summary>
			/// 
			/// </summary>
			NumberOfSlots
		}
		#endregion

		#region Static members
		/// <summary>
		/// The default datasource view name used by the datasourceview object returned by this data source control.
		/// </summary>
		public static readonly string DefaultDataSourceViewName = "DefaultView";
		#endregion

		#region Class Member Declarations
		private ICollection _viewNames;
		private string _dataStorageKey, _aspNETCacheStorageKey;
		private DataSourceCacheLocation _cacheLocation;
		private bool _enablePaging, _allowDuplicates, _livePersistence;
		private DataSourceDataContainerType _dataContainerType;
		private int _maxNumberOfItemsToReturn, _aspNETCacheDuration;
		#endregion


		/// <summary>
		/// Selects data from the underlying storage using the parameters set. You don't need to call this method if you've setup databinding using DataSourceID
		/// values.
		/// </summary>
		/// <returns>EntityView/EntityView2 object with the data requested.</returns>
		public IEnumerable Select()
		{
			return GetView().Select( DataSourceSelectArguments.Empty );
		}


		/// <summary>
		/// Called when the datasource control has fetched elements. Raises ElementsFetched. Has no effect if LivePersistence is set to false.
		/// </summary>
		internal void OnElementsFetched()
		{
			if(!_livePersistence)
			{
				// no effect
				return;
			}
			if(ElementsFetched != null)
			{
				ElementsFetched(this, new EventArgs());
			}
		}


		/// <summary>
		/// Called when the entity passed in is about the be inserted. Raises 'EntityInserting'
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		/// <returns>the value for 'Cancel'</returns>
		internal bool OnEntityInserting(IEntityCore involvedEntity)
		{
			bool toReturn = false;
			if(EntityInserting != null)
			{
				CancelableDataSourceActionEventArgs args = new CancelableDataSourceActionEventArgs(involvedEntity);
				EntityInserting(this, args);
				toReturn = args.Cancel;
			}

			return toReturn;
		}


		/// <summary>
		/// Called when the entity passed in is about the be updated. Raises 'EntityUpdating'
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		/// <returns>the value for 'Cancel'</returns>
		internal bool OnEntityUpdating(IEntityCore involvedEntity)
		{
			bool toReturn = false;
			if(EntityUpdating != null)
			{
				CancelableDataSourceActionEventArgs args = new CancelableDataSourceActionEventArgs(involvedEntity);
				EntityUpdating(this, args);
				toReturn = args.Cancel;
			}

			return toReturn;
		}


		/// <summary>
		/// Called when the entity passed in is about the be deleted. Raises 'EntityDeleting'
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		/// <returns>the value for 'Cancel'</returns>
		internal bool OnEntityDeleting(IEntityCore involvedEntity)
		{
			bool toReturn = false;
			if(EntityDeleting != null)
			{
				CancelableDataSourceActionEventArgs args = new CancelableDataSourceActionEventArgs(involvedEntity);
				EntityDeleting(this, args);
				toReturn = args.Cancel;
			}

			return toReturn;
		}


		/// <summary>
		/// Called when the entity passed in has been successfully inserted. Raises 'EntityInserted'. Has no effect if LivePersistence is set to false.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		internal void OnEntityInserted(IEntityCore involvedEntity)
		{
			if(!_livePersistence)
			{
				// ignore
				return;
			}

			if(EntityInserted != null)
			{
				DataSourceActionEventArgs args = new DataSourceActionEventArgs(involvedEntity);
				EntityInserted(this, args);
			}
		}


		/// <summary>
		/// Called when the entity passed in has been successfully updated. Raises 'EntityUpdated'. Has no effect if LivePersistence is set to false.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		internal void OnEntityUpdated(IEntityCore involvedEntity)
		{
			if(!_livePersistence)
			{
				// ignore
				return;
			}

			if(EntityUpdated != null)
			{
				DataSourceActionEventArgs args = new DataSourceActionEventArgs(involvedEntity);
				EntityUpdated(this, args);
			}
		}


		/// <summary>
		/// Called when the entity passed in has been successfully deleted. Raises 'EntityDeleted'. Has no effect if LivePersistence is set to false.
		/// </summary>
		/// <param name="involvedEntity">The involved entity.</param>
		internal void OnEntityDeleted(IEntityCore involvedEntity)
		{
			if(!_livePersistence)
			{
				// ignore
				return;
			}

			if(EntityDeleted != null)
			{
				DataSourceActionEventArgs args = new DataSourceActionEventArgs(involvedEntity);
				EntityDeleted(this, args);
			}
		}


		/// <summary>
		/// Raises the <see cref="E:System.Web.UI.Control.Init"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> object that contains the event data.</param>
		protected override void OnInit( EventArgs e )
		{
			base.OnInit(e);
			Page.RegisterRequiresControlState(this);
			Page.LoadComplete += new EventHandler( this.OnPageLoadComplete );
		}


		/// <summary>
		/// Called when [page load complete].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void OnPageLoadComplete( object sender, EventArgs e )
		{
			if(this.BindingContainer != null)
			{
				_dataStorageKey = string.Format("__LLBLGENPRODATASOURCEDATA_{0}_{1}", this.UniqueID, this.BindingContainer.ToString());
			}
			LLBLGenProDataSourceViewBase view = GetView();
			if(view != null)
			{
				view.SelectParameters.UpdateValues(base.Context, this);
			}
		}


		/// <summary>
		/// Saves any server control state changes that have occurred since the time the page was posted back to the server.
		/// </summary>
		/// <returns>
		/// Returns the server control's current state. If there is no state associated with the control, this method returns null.
		/// </returns>
		protected override object SaveControlState()
		{
			object[] state = new object[(int)ControlStateSlot.NumberOfSlots];
			state[(int)ControlStateSlot.DataStorageKey] = _dataStorageKey;
			state[(int)ControlStateSlot.CacheLocation] = _cacheLocation;
			state[(int)ControlStateSlot.EnablePaging] = _enablePaging;
			state[(int)ControlStateSlot.DataContainerType] = _dataContainerType;
			state[(int)ControlStateSlot.MaxNumberOfItemsToReturn] = _maxNumberOfItemsToReturn;
			state[(int)ControlStateSlot.AllowDuplicates] = _allowDuplicates;
			state[(int)ControlStateSlot.ASPNetCacheDuration] = _aspNETCacheDuration;
			state[(int)ControlStateSlot.ASPNetCacheStorageKey] = _aspNETCacheStorageKey;
			return state;
		}


		/// <summary>
		/// Restores control-state information from a previous page request that was saved by the <see cref="M:System.Web.UI.Control.SaveControlState"></see> method.
		/// </summary>
		/// <param name="savedState">An <see cref="T:System.Object"></see> that represents the control state to be restored.</param>
		protected override void LoadControlState( object savedState )
		{
			if( savedState != null )
			{
				object[] state = (object[])savedState;
				_dataStorageKey = (string)state[(int)ControlStateSlot.DataStorageKey];
				_cacheLocation = (DataSourceCacheLocation)state[(int)ControlStateSlot.CacheLocation];
				_enablePaging = (bool)state[(int)ControlStateSlot.EnablePaging];
				_dataContainerType = (DataSourceDataContainerType)state[(int)ControlStateSlot.DataContainerType];
				_maxNumberOfItemsToReturn = (int)state[(int)ControlStateSlot.MaxNumberOfItemsToReturn];
				_allowDuplicates = (bool)state[(int)ControlStateSlot.AllowDuplicates];
				_aspNETCacheDuration = (int)state[(int)ControlStateSlot.ASPNetCacheDuration];
				_aspNETCacheStorageKey = (string)state[(int)ControlStateSlot.ASPNetCacheStorageKey];
			}
		}


		/// <summary>
		/// Restores view-state information from a previous page request that was saved by the <see cref="M:System.Web.UI.Control.SaveViewState"></see> method.
		/// </summary>
		/// <param name="savedState">An <see cref="T:System.Object"></see> that represents the control state to be restored.</param>
		protected override void LoadViewState( object savedState )
		{
			if( savedState == null )
			{
				base.LoadViewState( savedState );
			}
			else
			{
				object[] state = (object[])savedState;
				base.LoadViewState( state[(int)ViewStateSlot.OwnState] );
				switch(_cacheLocation)
				{
					case DataSourceCacheLocation.ViewState:
						GetView().LoadState(state[(int)ViewStateSlot.DefaultViewState]);
						break;
					case DataSourceCacheLocation.Session:
						if(!this.DesignMode)
						{
							state = null;
							// load from session
							state = (object[])this.Context.Session[_dataStorageKey];
							if(state != null)
							{
								GetView().LoadState(state[(int)ViewStateSlot.DefaultViewState]);
							}
						}
						break;
					case DataSourceCacheLocation.ASPNetCache:
						if(!this.DesignMode)
						{
							state = null;
							// load from ASP.NET cache
							state = (object[])HttpRuntime.Cache[_aspNETCacheStorageKey];
							if(state != null)
							{
								GetView().LoadState(state[(int)ViewStateSlot.DefaultViewState]);
							}
						}
						break;
				}
			}
		}


		/// <summary>
		/// Saves any server control view-state changes that have occurred since the time the page was posted back to the server.
		/// </summary>
		/// <returns>
		/// Returns the server control's current view state. If there is no view state associated with the control, this method returns null.
		/// </returns>
		protected override object SaveViewState()
		{
			object[] toReturn = CreateStateDataObject();
			if( _cacheLocation != DataSourceCacheLocation.ViewState )
			{
				// clear default view's state object, as it's already saved in another location.
				toReturn[(int)ViewStateSlot.DefaultViewState] = null;
			}

			return toReturn;
		}


		/// <summary>
		/// Gets the named data source view associated with the data source control.
		/// </summary>
		/// <param name="viewName">The name of the <see cref="T:System.Web.UI.DataSourceView"></see> to retrieve. In data source controls that support only one view, such as <see cref="T:System.Web.UI.WebControls.SqlDataSource"></see>, this parameter is ignored.</param>
		/// <returns>
		/// Returns the named <see cref="T:System.Web.UI.DataSourceView"></see> associated with the <see cref="T:System.Web.UI.DataSourceControl"></see>.
		/// </returns>
		/// <remarks>viewName is ignored. Just one view is supported.</remarks>
		protected override DataSourceView GetView( string viewName )
		{
			if( (viewName == null) || ((viewName.Length > 0) && (viewName != LLBLGenProDataSourceBase.DefaultDataSourceViewName)) )
			{
				throw new ArgumentOutOfRangeException( "viewName", string.Format( "Expected name: {0}. Received name: {1}", LLBLGenProDataSourceBase.DefaultDataSourceViewName, viewName ) );
			}

			return GetView();
		}


		/// <summary>
		/// Gets a collection of names, representing the list of <see cref="T:System.Web.UI.DataSourceView"></see> objects associated with the <see cref="T:System.Web.UI.DataSourceControl"></see> control.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.ICollection"></see> that contains the names of the <see cref="T:System.Web.UI.DataSourceView"></see> objects associated with the <see cref="T:System.Web.UI.DataSourceControl"></see>.
		/// </returns>
		protected override ICollection GetViewNames()
		{
			if( _viewNames == null )
			{
				_viewNames = new string[] { LLBLGenProDataSourceBase.DefaultDataSourceViewName };
			}

			return _viewNames;
		}


		/// <summary>
		/// Causes tracking of view-state changes to the server control so they can be stored in the server control's <see cref="T:System.Web.UI.StateBag"></see> object. This object is accessible through the <see cref="P:System.Web.UI.Control.ViewState"></see> property.
		/// </summary>
		protected override void TrackViewState()
		{
			base.TrackViewState();
			GetView().TrackViewState();
		}


		/// <summary>
		/// Creates the state data object.
		/// </summary>
		/// <returns></returns>
		protected virtual object[] CreateStateDataObject()
		{
			object[] toReturn = new object[(int)ViewStateSlot.NumberOfSlots];
			toReturn[(int)ViewStateSlot.OwnState] = base.SaveViewState();
			toReturn[(int)ViewStateSlot.DefaultViewState] = GetView().SaveState();
			return toReturn;
		}


		/// <summary>
		/// Gets the view.
		/// </summary>
		/// <returns></returns>
		protected abstract LLBLGenProDataSourceViewBase GetView();


		/// <summary>
		/// Called when [data source unload].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void OnDataSourceUnload( object sender, EventArgs e )
		{
			if( !DesignMode )
			{
				switch( _cacheLocation )
				{
					case DataSourceCacheLocation.ViewState:
						// do nothing, is already handled
						break;
					case DataSourceCacheLocation.Session:
						// save to session
						this.Context.Session[_dataStorageKey] = CreateStateDataObject();
						break;
					case DataSourceCacheLocation.ASPNetCache:
						// save to cache. Overwrite existing element and store with a sliding scale and no dependencies.
						HttpRuntime.Cache.Insert(_aspNETCacheStorageKey, CreateStateDataObject(), null, Cache.NoAbsoluteExpiration, new TimeSpan(0, _aspNETCacheDuration, 0));
						break;
				}
				// dispose a loaded view, as it contains a live adapter
				GetView().Dispose();
			}
		}


		/// <summary>
		/// Inits the class
		/// </summary>
		protected void InitClass()
		{
			_cacheLocation = DataSourceCacheLocation.ViewState;
			_enablePaging = false;
			// set to a guid based key, as we don't know yet what the container name is, at this point.
			_dataStorageKey = "__LLBLGENPRODATASOURCEDATA_" + Guid.NewGuid().ToString();
			_aspNETCacheStorageKey = "__LLBLGENPRODATASOURCEDATA_" + Guid.NewGuid().ToString();
			_dataContainerType = DataSourceDataContainerType.EntityCollection;
			_maxNumberOfItemsToReturn = 0;
			_allowDuplicates = true;
			_livePersistence = true;
			_aspNETCacheDuration = 20;

			this.Unload += new EventHandler( OnDataSourceUnload );
		}



		/// <summary>
		/// Gets the context.
		/// </summary>
		/// <returns></returns>
		internal HttpContext GetContext()
		{
			return base.Context;
		}


		#region Class Property Declarations
		/// <summary>
		/// Parameters which are used to construct a PredicateExpression for live filtering. Hook up control properties or other parameters with the datasource
		/// so the datasource can filter based on values in other controls.
		/// </summary>
		[PersistenceMode( PersistenceMode.InnerProperty ), 
		DefaultValue( (string)null ), 
		Editor( "System.Web.UI.Design.WebControls.ParameterCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof( UITypeEditor ) ), 
		MergableProperty( false )]
		[Description( "The select parameters for the data fetch logic. The parameters are transformed into predicates." )]
		public ParameterCollection SelectParameters
		{
			get { return GetView().SelectParameters; }
		}


		/// <summary>
		/// Parameters which are used to construct a PredicateExpression for live filtering. Hook up control properties or other parameters with the datasource
		/// so the datasource can filter based on values in other controls.
		/// </summary>
		[PersistenceMode( PersistenceMode.InnerProperty ),
		DefaultValue( (string)null ),
		Editor( "System.Web.UI.Design.WebControls.ParameterCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof( UITypeEditor ) ),
		MergableProperty( false )]
		[Description( "The update parameters for the update logic. Use this collection to specify particular values for particular fields when an update (save of an existing, changed entity) has to take place." )]
		public ParameterCollection UpdateParameters
		{
			get { return GetView().UpdateParameters; }
		}


		/// <summary>
		/// Parameters which are used to construct a PredicateExpression for live filtering. Hook up control properties or other parameters with the datasource
		/// so the datasource can filter based on values in other controls.
		/// </summary>
		[PersistenceMode( PersistenceMode.InnerProperty ),
		DefaultValue( (string)null ),
		Editor( "System.Web.UI.Design.WebControls.ParameterCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof( UITypeEditor ) ),
		MergableProperty( false )]
		[Description( "The insert parameters for the insert logic. Use this collection to specify particular values for particular fields when an insert (save of a new entity) has to take place." )]
		public ParameterCollection InsertParameters
		{
			get { return GetView().InsertParameters; }
		}


		/// <summary>
		/// Gets or sets the value for LivePersistence, a flag which is used to determine whether fetches for data changes on the data (insert/update/delete) 
		/// have to be propagated to the database directly (true) or have to be added to a UnitOfWork object (false). Default is true.
		/// </summary>
		[DefaultValue( true )]
		[Description( "Specifies whether fetches for data and changes on the data (insert/update/delete) have to be propagated to the database directly (true) or have to be added to a UnitOfWork object (false). Default is true. Changes in entities are ignored when DataContainerType isn't set to EntityCollection (so only fetches are performed in those situations)." )]
		public bool LivePersistence
		{
			get { return _livePersistence; }
			set { _livePersistence = value; }
		}

		
		/// <summary>
		/// Gets or sets the maximum number of items to return. Is ignored if EnablePaging is specified.
		/// </summary>
		[DefaultValue(0)]
		[Description("Specifies the maximum number of items to fetch in a select. A value of 0 specifies that all items should be fetched, and this is the default. Value is ignored if EnablePaging is set to true")]
		public int MaxNumberOfItemsToReturn
		{
			get { return _maxNumberOfItemsToReturn; }
			set { _maxNumberOfItemsToReturn = value; }
		}


		/// <summary>
		/// Gets or sets if the DataSourceControl should allow duplicate instances in the data retrieved. If DataContainerType is set to EntityCollection,
		/// this setting is ignored, as entitycollection fetches always filter out duplicates.
		/// </summary>
		[DefaultValue(true)]
		[Description("Specifies if the DataSourceControl should allow duplicate instances in the data retrieved. If DataContainerType is set to EntityCollection, this setting is ignored, as entitycollection fetches always filter out duplicates.")]
		public bool AllowDuplicates
		{
			get { return _allowDuplicates; }
			set { _allowDuplicates = value; }
		}

		/// <summary>
		/// Gets or sets the type of the data container which contains the data inside this datasource control.
		/// </summary>
		[Description( "Setting to control what kind of data container object is contained in this DataSourceControl. Use 'Configure Data Source...' to set this property." )]
		public DataSourceDataContainerType DataContainerType
		{
			get { return _dataContainerType; }
			set { _dataContainerType = value; }
		}

		/// <summary>
		/// Gets or sets whether Paging is enabled on this control. Default is false. If you're using paging in a bound control, be sure to set this
		/// property to true so the LLBLGenProDataSourceControl will perform server-side paging instead of loading everything in memory and leave the paging to
		/// the bound control. 
		/// </summary>
		[Description( "Use this property to enable server side paging by the DataSourceControl. If set to false, the DataSourceControl will read all data matching the filter specified and paging has to occur in the bound control(s)." )]
		[DefaultValue(false)]
		public bool EnablePaging
		{
			get { return _enablePaging; }
			set { _enablePaging = value; }
		}


		/// <summary>
		/// Gets or sets the location where to store loaded data. Default is Viewstate. 
		/// </summary>
		[Description( "The location where this DataSourceControl stores its state data in between page postbacks." )]
		[DefaultValue(typeof(DataSourceCacheLocation), "ViewState")]
		public DataSourceCacheLocation CacheLocation
		{
			get { return _cacheLocation; }
			set { _cacheLocation = value; }
		}


		/// <summary>
		/// Gets or sets the duration in minutes the state data is stored in the ASP.NET cache in between page postbacks. Only valid if CacheLocation is set to ASPNetCache.
		/// </summary>
		[Description("The duration in minutes the state data is stored in the ASP.NET cache in between page postbacks, default is 20 minutes. Only valid if CacheLocation is set to ASPNetCache. If this value is set too low, it can be the data used to build the page has been removed from the cache and the postback doesn't work. To stay on the safe side, keep this value as high as you'd set the duration of the Session object.")]
		[DefaultValue(20)]
		public int ASPNetCacheDuration
		{
			get { return _aspNETCacheDuration; }
			set 
			{
				if(value <= 0)
				{
					throw new ArgumentOutOfRangeException("value", "ASPNetCacheDuration has to be set to a value greater than 0");
				}
				_aspNETCacheDuration = value; 
			}
		}


		/// <summary>
		/// Gets / sets the sortingmode.
		/// </summary>
		[Description("The sorting mode for the datasource control which controls how the data should be sorted: client-side or server-side (default). Not used in TypedList/TypedView fetches, as those sorting actions are always server-side.")]
		[DefaultValue(typeof(DataSourceSortingMode), "ServerSide")]
		public DataSourceSortingMode SortingMode
		{
			get { return GetView().SortingMode; }
			set { GetView().SortingMode = value; }
		}


		/// <summary>
		/// Gets or sets the SortExpression to use.
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public ISortExpression SorterToUse
		{
			get
			{
				return GetView().SorterToUse;
			}
			set
			{
				GetView().SorterToUse = value;
			}
		}


		/// <summary>
		/// Gets / sets the allFieldsKeepEmptyStringAsValue value. Setting this parameter to true will disable FieldNamesKeepEmptyStringAsValue. Default: false.
		/// </summary>
		[Description("Flag to signal the datasource control to simply see all empty strings as normal values instead of relying on the fields set in the list of the property FieldNamesKeepEmptyStringAsValue. Setting this flag to true completely bypasses FieldNamesKeepEmptyStringAsValue. Setting this flag to false (default) enables FieldNamesKeepEmptyStringAsValue.")]
		[DefaultValue(false)]
		public bool AllFieldsKeepEmptyStringAsValue
		{
			get
			{
				return GetView().AllFieldsKeepEmptyStringAsValue;
			}
			set
			{
				GetView().AllFieldsKeepEmptyStringAsValue = value;
			}
		}


		/// <summary>
		/// Gets or sets the flag which signals this datasource control when setting fields to new values it should throw an exception if one or more field values in the input are illegal and can't be converted to the field's .NET type.
		/// </summary>
		[Description("Flag which signals this datasource control when setting fields to new values it should throw an exception if one or more field values in the input are illegal and can't be converted to the field's .NET type. Default: false. Setting this flag to false means the illegal value is silently ignored.")]
		[DefaultValue(false)]
		public bool ThrowExceptionOnIllegalFieldInput
		{
			get { return GetView().ThrowExceptionOnIllegalFieldInput; }
			set { GetView().ThrowExceptionOnIllegalFieldInput = value; }
		}


		/// <summary>
		/// Gets / sets the list of fieldnames for which "" is a valid value and which shouldn't be converted to null.
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public List<string> FieldNamesKeepEmptyStringAsValue
		{
			get { return GetView().FieldNamesKeepEmptyStringAsValue; }
			set { GetView().FieldNamesKeepEmptyStringAsValue = value; }
		}


		/// <summary>
		/// Gets or sets the GroupByCollection to use. Only valid if DataContainerType is set to TypedList or TypedView
		/// </summary>
		[Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
		public IGroupByCollection GroupByToUse
		{
			get
			{
				return GetView().GroupBy;
			}
			set
			{
				GetView().GroupBy = value;
			}
		}
		#endregion

	}


	/// <summary>
	/// General base class for DatSourceView objects for selfservicing and adapter.
	/// </summary>
	[AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal), AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
	public abstract class LLBLGenProDataSourceViewBase : DataSourceView
	{
		#region Local Enums
		/// <summary>
		/// Enum for the state slots in the view state slot object
		/// </summary>
		internal enum StateSlot
		{
			/// <summary>
			/// Slot for the Filter object set
			/// </summary>
			Filter,
			/// <summary>
			/// Slot for the sorter object set.
			/// </summary>
			Sorter,
			/// <summary>
			/// Slot for the datacontainer object contained in this object
			/// </summary>
			DataContainer,
			/// <summary>
			/// Slot for the active page number
			/// </summary>
			PageNumber,
			/// <summary>
			/// Slot for the active page size
			/// </summary>
			PageSize,
			/// <summary>
			/// Slot for the total row count read during the last page load
			/// </summary>
			TotalRowCount,
			/// <summary>
			/// Slot for relationcollection object, if applicable
			/// </summary>
			RelationCollection,
			/// <summary>
			/// Slot for the last used sortexpression received by ExecuteSelect
			/// </summary>
			SortExpression,
			/// <summary>
			/// Slot for the flag to refetch the data because the current data is invalid.
			/// </summary>
			Refetch,
			/// <summary>
			/// Slot for the unitofwork object when LivePersistence is set to false.
			/// </summary>
			UnitOfWork,
			/// <summary>
			/// Slot for the groupby collection used for typedlist/view fetches
			/// </summary>
			GroupByCollection,
			/// <summary>
			/// Slot for the prefetch path used for entitycollection fetches.
			/// </summary>
			PrefetchPath,
			/// <summary>
			/// List of fieldnames for which "" is a valid value and shouldn't be converted to null.
			/// </summary>
			FieldNamesKeepEmptyStringAsValue,
			/// <summary>
			/// The sortingmode for the datasourcecontrol
			/// </summary>
			SortingMode,
			/// <summary>
			/// The slot for the selectparameter values of the previous page, so a compare can be done to see if a selectparameter has been changed and
			/// a refresh has to be performed or not.
			/// </summary>
			SelectedParameterValues,
			/// <summary>
			/// The select parameters data.
			/// </summary>
			SelectParameters,
			/// <summary>
			/// The slot for the AllFieldsKeepEmptyStringAsValue value which signals to simply keep empty strings as values, bypassing FieldNamesKeepEmptyStringAsValue.
			/// </summary>
			AllFieldsKeepEmptyStringAsValue,
			/// <summary>
			/// The slot for the ThrowExceptionOnIllegalFieldInput flag. 
			/// </summary>
			ThrowExceptionOnIllegalFieldInput,
			// add more here
			/// <summary>
			/// 
			/// </summary>
			NumberOfSlots
		}
		#endregion

		#region Class Member Declarations
		private LLBLGenProDataSourceBase _owner;
		private ISortExpression _sorterToUse;
		private bool _trackViewState, _refetch, _surpressChangedEvent, _allFieldsKeepEmptyStringAsValue, _throwExceptionOnIllegalFieldInput;
		private int _pageNumber, _pageSize, _totalRowCount;
		private string _sortExpression;
		private ParameterCollection _selectParameters, _insertParameters, _updateParameters;
		private IGroupByCollection _groupBy;
		private List<string> _fieldNamesKeepEmptyStringAsValue;
		private DataSourceSortingMode _sortingMode;
		private Dictionary<string, object> _cachedSelectParameterValues;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="LLBLGenProDataSourceView2"/> class.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="viewName">Name of the view.</param>
		protected LLBLGenProDataSourceViewBase( LLBLGenProDataSourceBase owner, string viewName )
			: base( owner, viewName )
		{
			_owner = owner;
			_trackViewState = false;
			_sorterToUse = null;
			_pageNumber = 0;
			_pageSize = 0;
			_refetch = true;			// initially always perform a fetch when a select is issued. 
			_totalRowCount = 0;
			_sortExpression = string.Empty;
			_fieldNamesKeepEmptyStringAsValue = new List<string>();
			_sortingMode = DataSourceSortingMode.ServerSide;
			_surpressChangedEvent = false;
			_cachedSelectParameterValues = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
			_allFieldsKeepEmptyStringAsValue = false;
			_throwExceptionOnIllegalFieldInput = false;
		}


		/// <summary>
		/// Loads the state for this object from the object passed in (which is an object array)
		/// </summary>
		/// <param name="savedState">Saved object state.</param>
		public void LoadState( object savedState )
		{
			if( savedState == null )
			{
				return;
			}
			object[] state = (object[])savedState;
			SetFilter(state[(int)StateSlot.Filter]);
			SetRelationCollection( state[(int)StateSlot.RelationCollection] );
			SetDataContainer( state[(int)StateSlot.DataContainer] );
			SetUnitOfWork( state[(int)StateSlot.UnitOfWork] );
			SetPrefetchPath(state[(int)StateSlot.PrefetchPath]);
			_groupBy = (IGroupByCollection)state[(int)StateSlot.GroupByCollection];
			_sorterToUse = (ISortExpression)state[(int)StateSlot.Sorter];
			_pageNumber = (int)state[(int)StateSlot.PageNumber];
			_pageSize = (int)state[(int)StateSlot.PageSize];
			_totalRowCount = (int)state[(int)StateSlot.TotalRowCount];
			_sortExpression = (string)state[(int)StateSlot.SortExpression];
			_refetch = (bool)state[(int)StateSlot.Refetch];
			_sortingMode = (DataSourceSortingMode)state[(int)StateSlot.SortingMode];
			_fieldNamesKeepEmptyStringAsValue = (List<string>)state[(int)StateSlot.FieldNamesKeepEmptyStringAsValue];
			_cachedSelectParameterValues = (Dictionary<string, object>)state[(int)StateSlot.SelectedParameterValues];
			_allFieldsKeepEmptyStringAsValue = (bool)state[(int)StateSlot.AllFieldsKeepEmptyStringAsValue];
			_throwExceptionOnIllegalFieldInput = (bool)state[(int)StateSlot.ThrowExceptionOnIllegalFieldInput];
			object selectParametersData = state[(int)StateSlot.SelectParameters];
			if(selectParametersData != null)
			{
				((IStateManager)this.SelectParameters).LoadViewState(selectParametersData);
			}
		}


		/// <summary>
		/// When implemented by a class, saves the changes to a server control's view state to an <see cref="T:System.Object"></see>.
		/// </summary>
		/// <returns>
		/// The <see cref="T:System.Object"></see> that contains the view state changes.
		/// </returns>
		public object SaveState()
		{
			return CreateStateDataObject();
		}


		/// <summary>
		/// Sets the datacontainer object
		/// </summary>
		/// <param name="dataContainer">the datacontainer object to set.</param>
		protected virtual void SetDataContainer( object dataContainer )
		{
			// nop
		}

		/// <summary>
		/// Sets the filter.
		/// </summary>
		/// <param name="filterObject">The filter object.</param>
		protected virtual void SetFilter( object filterObject )
		{
			// nop
		}


		/// <summary>
		/// Sets the relation collection.
		/// </summary>
		/// <param name="relationCollection">The relation collection.</param>
		protected virtual void SetRelationCollection( object relationCollection )
		{
			// nop
		}

		/// <summary>
		/// Sets the unit of work.
		/// </summary>
		/// <param name="uow">The unit of work.</param>
		protected virtual void SetUnitOfWork( object uow)
		{
			// nop
		}

		/// <summary>
		/// Sets the prefetch path.
		/// </summary>
		/// <param name="prefetchPath">The prefetch path.</param>
		protected virtual void SetPrefetchPath( object prefetchPath )
		{
			// nop
		}


		/// <summary>
		/// Compares the select parameters with the cached versions. If the current select parameters are different, Refresh is set to true.
		/// </summary>
		/// <remarks>Called by ExecuteSelect prior to branching out to the real select routines.</remarks>
		protected void CompareSelectParameters()
		{
			Dictionary<string, object> currentValues = new Dictionary<string, object>();
			GetParameterValues(this.SelectParameters, currentValues);

			bool areSame = true;
			foreach(KeyValuePair<string, object> entry in currentValues)
			{
				areSame = _cachedSelectParameterValues.ContainsKey(entry.Key);
				if(!areSame)
				{
					// already different
					break;
				}
				// exists, compare values
				object oldValue = _cachedSelectParameterValues[entry.Key];
				object currentValue = currentValues[entry.Key];
				areSame = FieldUtilities.ValuesAreEqual(oldValue, currentValue);
				if(!areSame)
				{
					// already not the same
					break;
				}
			}

			if(!areSame)
			{
				// perform a refetch
				_refetch=true;
			}
		}


		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public abstract void Dispose();

		/// <summary>
		/// Produces the sort expression from a string expression provided by ASP.NET
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <param name="sortargument">The sortargument.</param>
		/// <returns></returns>
		protected ISortExpression ProduceSortExpressionFromString( IEntityFields fields, string sortargument )
		{
			Dictionary<string, IEntityFieldCore> fieldsList = new Dictionary<string, IEntityFieldCore>( fields.Count, StringComparer.InvariantCultureIgnoreCase );
			foreach( IEntityField field in fields )
			{
				fieldsList.Add( field.Alias, field );
			}

			return ProduceSortExpressionFromString( fieldsList, sortargument );
		}


		/// <summary>
		/// Produces the sort expression from a string expression provided by ASP.NET
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <param name="sortargument">The sortargument.</param>
		/// <returns></returns>
		protected ISortExpression ProduceSortExpressionFromString( IEntityFields2 fields, string sortargument )
		{
			Dictionary<string, IEntityFieldCore> fieldsList = new Dictionary<string, IEntityFieldCore>( fields.Count, StringComparer.InvariantCultureIgnoreCase );
			foreach( IEntityField2 field in fields )
			{
				fieldsList.Add( field.Alias, field );
			}

			return ProduceSortExpressionFromString( fieldsList, sortargument );
		}



		/// <summary>
		/// Converts the passed in sourcevalue to the destination type. Used when converting field values in forms and parameter values in filters. 
		/// </summary>
		/// <param name="destinationType">Type of the destination.</param>
		/// <param name="sourceValue">The source value.</param>
		/// <param name="fieldName">Name of the field.</param>
		/// <returns>null if fieldName!= null and fieldName is part of the fieldNamesKeepEmptyStringAsValue collection and sourceValue is an empty string.
		/// Otherwise the sourcevalue converted to the destination type. If no conversion is possible, null is returned.</returns>
		protected virtual object ConvertValueToDestinationType(Type destinationType, object sourceValue, string fieldName)
		{
			if(sourceValue == null)
			{
				return null;
			}

			object toReturn = null;
			string sourceValueAsString = sourceValue as string;
			if((sourceValueAsString!=null) && (sourceValueAsString.Length<=0) && (fieldName != null))
			{
				// convert to null, if the fieldname isn't in the fieldNamesKeepEmptyStringAsValue list or if AllFieldsKeepEmptyStringAsValue is set to true.
				if(_allFieldsKeepEmptyStringAsValue || _fieldNamesKeepEmptyStringAsValue.Contains(fieldName))
				{
					toReturn = sourceValueAsString;
				}
				else
				{
					toReturn = null;
				}
			}
			else
			{
				try
				{
					Type typeToUse = null;
					if(destinationType.IsGenericType && destinationType.GetGenericTypeDefinition() == (typeof(Nullable<>)))
					{
						// use the parameter type instead. There's just 1
						Type[] parameterTypes = destinationType.GetGenericArguments();
						typeToUse = parameterTypes[0];
					}
					else
					{
						typeToUse = destinationType;
					}
					if((typeToUse == typeof(Guid)) && (sourceValueAsString!=null))
					{
						// special case
						toReturn = new Guid(sourceValueAsString);
					}
					else
					{
						
						toReturn = Convert.ChangeType(sourceValue, typeToUse);
					}
				}
				catch(InvalidCastException)
				{
					// check if the destinationType has a typeconverter attribute. If so, use that typeconverter, if possible. If not, give up by rethrowing
					// the exception.
					object[] typeConverterAttributes = destinationType.GetCustomAttributes(typeof(TypeConverterAttribute), false);
					if(typeConverterAttributes.Length <= 0)
					{
						// no type converter present, throw exception upwards.
						throw;
					}

					// pick first, instantiate the typeconverter
					TypeConverterAttribute attributeToUse = (TypeConverterAttribute)typeConverterAttributes[0];
					if(attributeToUse.ConverterTypeName.Length <= 0)
					{
						// no type specified
						throw;
					}
					Type converterType = Type.GetType(attributeToUse.ConverterTypeName);
					if(converterType==null)
					{
						// not found
						throw;
					}
					// create instance, using the fully qualified typename.
					TypeConverter converterToUse = (TypeConverter)Activator.CreateInstance(converterType);
					if(converterToUse == null)
					{
						// couldn't create converter
						throw;
					}

					if(!converterToUse.CanConvertFrom(sourceValue.GetType()))
					{
						// couldn't convert from the sourcevalue
						throw;
					}

					// we successfully handled the exception now, convert the sourcevalue to the real type. 
					toReturn = converterToUse.ConvertFrom(sourceValue);
				}
				catch(Exception ex)
				{
					// can't convert value to destination type. Can't handle this value
					throw new InvalidOperationException(string.Format(
							"Couldn't convert the value for field '{0}' to type '{1}' due to an exception: '{2}'. Please see inner exception for details.",
								fieldName, destinationType.FullName, ex.Message), ex);
				}
			}
			return toReturn;
		}


		/// <summary>
		/// Produces the sort expression from string.
		/// </summary>
		/// <param name="fieldsList">The fields list.</param>
		/// <param name="sortargument">The sortargument.</param>
		/// <returns></returns>
		private ISortExpression ProduceSortExpressionFromString( Dictionary<string, IEntityFieldCore> fieldsList, string sortargument )
		{
			ISortExpression toReturn = new SortExpression();

			string[] sortElements = sortargument.Split( ',' );
			// we ignore [] around fields, as fields with spaces in their names aren't possible.
			foreach( string sortElement in sortElements )
			{
				string fieldName = string.Empty;
				SortOperator sortOp = SortOperator.Ascending;
				if( sortElement.EndsWith(" DESC", StringComparison.InvariantCultureIgnoreCase) )
				{
					sortOp = SortOperator.Descending;
					fieldName = sortElement.Substring(0, sortElement.Length-5).Trim();
				}
				else
				{
					if( sortElement.EndsWith(" ASC", StringComparison.InvariantCultureIgnoreCase))
					{
						fieldName = sortElement.Substring(0, sortElement.Length-4).Trim();
					}
					else
					{
						fieldName = sortElement.Trim();
					}
				}
				IEntityFieldCore field = null;
				if( fieldsList.TryGetValue( fieldName, out field ) )
				{
					IFieldPersistenceInfo persistenceInfo = null;
					if(field is IEntityField)
					{
						persistenceInfo = (IFieldPersistenceInfo)field;
					}
					toReturn.Add( new SortClause( field, persistenceInfo, sortOp ) );
				}
				else
				{
					// Sort on EntityProperty. This means that we can still sort on this property, with the name 'fieldname'.
					// If the fieldname isn't present in any entity and SortMode is set to server side, this will go wrong, but that's the responsibility
					// of the developer.
					if(_sortingMode == DataSourceSortingMode.ServerSide)
					{
						toReturn.Add(new SortClause(new EntityField2(fieldName, new Expression()), new FieldPersistenceInfo(), sortOp));
					}
					else
					{
						toReturn.Add(new SortClause(new EntityProperty(fieldName), null, sortOp));
					}
				}
			}

			return toReturn;
		}


		/// <summary>
		/// Merges the dictionaries passed in. This is done to merge a parametercollection with a set of values.
		/// If a value is both in source and in parameters, the value in parameters is picked. If the value is only in source, or in parameters, the value is selected. 
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		/// <param name="source">The source.</param>
		/// <param name="destination">The destination.</param>
		protected void MergeDictionaries(ParameterCollection parameters, IDictionary source, IDictionary destination)
		{
			IOrderedDictionary parameterValues = parameters.GetValues( _owner.GetContext(), _owner );
			Dictionary<string, object> usedParameters = new Dictionary<string, object>(parameterValues.Count);
			if( source != null )
			{
				foreach( DictionaryEntry entry in source )
				{
					object value = entry.Value;
					string key = (string)entry.Key;

					if( parameterValues.Contains( key ) )
					{
						destination[key] = parameterValues[key];
						usedParameters.Add(key, null);
					}
					else
					{
						destination[key] = value;
					}
				}
			}

			foreach(DictionaryEntry entry in parameterValues)
			{
				if(usedParameters.ContainsKey((string)entry.Key))
				{
					// already processed
					continue;
				}
				destination[entry.Key] = entry.Value;
			}
		}


		/// <summary>
		/// Gets the parameter values from the parameters and the current context and stores them into the destination dictionary.
		/// </summary>
		/// <param name="parameters">parameter collection to retrieve the values for</param>
		/// <param name="destination">destination into which the values have to be stored. If a key already exists, the value is overwritten.</param>
		/// <remarks>Clears destination prior to filling it.</remarks>
		protected void GetParameterValues(ParameterCollection parameters, Dictionary<string, object> destination)
		{
			destination.Clear();
			IOrderedDictionary parameterValues = parameters.GetValues(_owner.GetContext(), _owner);
			foreach(DictionaryEntry entry in parameterValues)
			{
				destination[(string)entry.Key] = entry.Value;
			}
		}


		/// <summary>
		/// Raises the changed event.
		/// </summary>
		internal void RaiseChangedEvent()
		{
			if( !_surpressChangedEvent )
			{
				OnDataSourceViewChanged( EventArgs.Empty );
			}
		}


		/// <summary>
		/// Selects the data from the underlying storage using the ExecuteSelect method.
		/// </summary>
		/// <param name="arguments">The data source select arguments.</param>
		/// <returns>EntityView2 object with the data requested</returns>
		internal IEnumerable Select( DataSourceSelectArguments arguments )
		{
			return this.ExecuteSelect( arguments );
		}


		/// <summary>
		/// Creates the state data object.
		/// </summary>
		/// <returns></returns>
		protected virtual object[] CreateStateDataObject()
		{
			object[] state = new object[(int)StateSlot.NumberOfSlots];
			state[(int)StateSlot.Sorter] = _sorterToUse;
			state[(int)StateSlot.PageSize] = _pageSize;
			state[(int)StateSlot.PageNumber] = _pageNumber;
			state[(int)StateSlot.TotalRowCount] = _totalRowCount;
			state[(int)StateSlot.SortExpression] = _sortExpression;
			state[(int)StateSlot.Refetch] = _refetch;
			state[(int)StateSlot.GroupByCollection] = _groupBy;
			state[(int)StateSlot.FieldNamesKeepEmptyStringAsValue] = _fieldNamesKeepEmptyStringAsValue;
			state[(int)StateSlot.SortingMode] = _sortingMode;
			state[(int)StateSlot.AllFieldsKeepEmptyStringAsValue] = _allFieldsKeepEmptyStringAsValue;
			state[(int)StateSlot.ThrowExceptionOnIllegalFieldInput] = _throwExceptionOnIllegalFieldInput;
			// store current select parameters in cache
			GetParameterValues(this.SelectParameters, _cachedSelectParameterValues);
			state[(int)StateSlot.SelectedParameterValues] = _cachedSelectParameterValues;
			object selectParametersData = ((IStateManager)this.SelectParameters).SaveViewState();
			state[(int)StateSlot.SelectParameters] = selectParametersData;
			return state;
		}


		/// <summary>
		/// Called when [parameters changed].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void OnParametersChanged( object sender, EventArgs e )
		{
			RaiseChangedEvent();
		}

		/// <summary>
		/// Tracks the state of the view.
		/// </summary>
		internal void TrackViewState()
		{
			_trackViewState = true;
			if( _selectParameters != null )
			{
				((IStateManager)_selectParameters).TrackViewState();
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets or sets the flag which signals this datasource control when setting fields to new values it should throw an exception if one or more field values in the input are illegal and can't be converted to the field's .NET type.
		/// </summary>
		[Description("Flag which signals this datasource control when setting fields to new values it should throw an exception if one or more field values in the input are illegal and can't be converted to the field's .NET type. Default: false. Setting this flag to false means the illegal value is silently ignored.")]
		public bool ThrowExceptionOnIllegalFieldInput
		{
			get { return _throwExceptionOnIllegalFieldInput; }
			set { _throwExceptionOnIllegalFieldInput = value; }
		}


		/// <summary>
		/// Gets / sets the allFieldsKeepEmptyStringAsValue value. Setting this parameter to true will disable FieldNamesKeepEmptyStringAsValue. Default: false.
		/// </summary>
		[Description("Flag to signal the datasource control to simply see all empty strings as normal values instead of relying on the fields set in the list of the property FieldNamesKeepEmptyStringAsValue. Setting this flag to true completely bypasses FieldNamesKeepEmptyStringAsValue. Setting this flag to false (default) enables FieldNamesKeepEmptyStringAsValue.")]
		public bool AllFieldsKeepEmptyStringAsValue
		{
			get
			{
				return _allFieldsKeepEmptyStringAsValue;
			}
			set
			{
				_allFieldsKeepEmptyStringAsValue = value;
			}
		}
		
		/// <summary>
		/// Gets / sets the sortingmode.
		/// </summary>
		[Description("The sorting mode for the datasource control which controls how the data should be sorted: client-side or server-side (default)")]
		public DataSourceSortingMode SortingMode
		{
			get { return _sortingMode; }
			set { _sortingMode = value; }
		}

		/// <summary>
		/// Gets / sets the list of fieldnames for which "" has to be converted to null/Nothing
		/// </summary>
		[Description("The list of fieldnames for which an empty string is a valid value during inserts/updates. Only useful for string-typed fieldnames. This property is bypassed if AllFieldsKeepEmptyStringAsValue is set to true (default: false). Empty strings are the typical way an empty value is expressed in websites and are by default converted to null/Nothing.")]
		public List<string> FieldNamesKeepEmptyStringAsValue
		{
			get { return _fieldNamesKeepEmptyStringAsValue; }
			set { _fieldNamesKeepEmptyStringAsValue = value; }
		}

		/// <summary>
		/// Gets or sets the select parameters.
		/// </summary>
		/// <value>The select parameters.</value>
		[Description("The select parameters for the data fetch logic. The parameters are transformed into predicates.")]
		public ParameterCollection SelectParameters
		{
			get
			{
				if( _selectParameters == null )
				{
					_selectParameters = new ParameterCollection();
					_selectParameters.ParametersChanged += new EventHandler( this.OnParametersChanged );

					if( IsTrackingViewState )
					{
						((IStateManager)_selectParameters).TrackViewState();
					}
				}
				return _selectParameters;
			}
		}


		/// <summary>
		/// Gets the insert parameters.
		/// </summary>
		/// <value>The insert parameters.</value>
		[Description("The insert parameters for the insert logic. Use this collection to specify particular values for particular fields when an insert (save of a new entity) has to take place.")]
		public ParameterCollection InsertParameters
		{
			get
			{
				if( _insertParameters == null )
				{
					_insertParameters = new ParameterCollection();
				}
				return _insertParameters;
			}
		}


		/// <summary>
		/// Gets the update parameters.
		/// </summary>
		[Description( "The update parameters for the update logic. Use this collection to specify particular values for particular fields when an update (save of an existing, changed entity) has to take place." )]
		public ParameterCollection UpdateParameters
		{
			get
			{
				if( _updateParameters == null )
				{
					_updateParameters = new ParameterCollection();
				}
				return _updateParameters;
			}
		}


		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports the <see cref="M:System.Web.UI.DataSourceView.ExecuteDelete(System.Collections.IDictionary,System.Collections.IDictionary)"></see> operation.
		/// </summary>
		/// <value></value>
		/// <returns>true if the datacontainertype is set to entitycollection.</returns>
		public override bool CanDelete
		{
			get
			{
				return (_owner.DataContainerType == DataSourceDataContainerType.EntityCollection);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports the <see cref="M:System.Web.UI.DataSourceView.ExecuteInsert(System.Collections.IDictionary)"></see> operation.
		/// </summary>
		/// <value></value>
		/// <returns>true if the datacontainertype is set to entitycollection.</returns>
		public override bool CanInsert
		{
			get
			{
				return (_owner.DataContainerType == DataSourceDataContainerType.EntityCollection);
			}
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports the <see cref="M:System.Web.UI.DataSourceView.ExecuteUpdate(System.Collections.IDictionary,System.Collections.IDictionary,System.Collections.IDictionary)"></see> operation.
		/// </summary>
		/// <value></value>
		/// <returns>true if the datacontainertype is set to entitycollection.</returns>
		public override bool CanUpdate
		{
			get
			{
				return (_owner.DataContainerType == DataSourceDataContainerType.EntityCollection);
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether refetching of data should be performed
		/// </summary>
		/// <value><c>true</c> if refetch; otherwise, <c>false</c>.</value>
		public virtual bool Refetch
		{
			get { return _refetch; }
			set { _refetch = value; }
		}

		/// <summary>
		/// When implemented by a class, gets a value indicating whether a server control is tracking its view state changes.
		/// </summary>
		/// <value></value>
		/// <returns>true if a server control is tracking its view state changes; otherwise, false.</returns>
		public bool IsTrackingViewState
		{
			get { return _trackViewState; }
		}


		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports paging through the data retrieved by the <see cref="M:System.Web.UI.DataSourceView.ExecuteSelect(System.Web.UI.DataSourceSelectArguments)"></see> method.
		/// </summary>
		/// <remarks>Returns the value of the EnablePaging property of the owner control</remarks>
		public override bool CanPage
		{
			get
			{
				return _owner.EnablePaging;
			}
		}


		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports a sorted view on the underlying data source.
		/// </summary>
		/// <remarks>returns true. If you don't want sorting, disable it in the bound control.</remarks>
		public override bool CanSort
		{
			get
			{
				return true;
			}
		}


		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports retrieving the total number of data rows, instead of the data.
		/// </summary>
		/// <value></value>
		/// <returns>true if the operation is supported; otherwise, false. The base class implementation returns false.</returns>
		public override bool CanRetrieveTotalRowCount
		{
			get
			{
				return _owner.EnablePaging;
			}
		}


		/// <summary>
		/// Gets or sets the group by.
		/// </summary>
		/// <value>The group by.</value>
		internal IGroupByCollection GroupBy
		{
			get { return _groupBy; }
			set
			{
				_groupBy = value;
				RaiseChangedEvent();
			}
		}


		/// <summary>
		/// Gets or sets the sorter to use.
		/// </summary>
		/// <value>The sorter to use.</value>
		internal ISortExpression SorterToUse
		{
			get
			{
				return _sorterToUse;
			}
			set
			{
				_sorterToUse = value;
				Refetch = true;
			}
		}


		/// <summary>
		/// Gets or sets the page number.
		/// </summary>
		/// <value>The page number.</value>
		protected int PageNumber
		{
			get { return _pageNumber; }
			set { _pageNumber = value; }
		}


		/// <summary>
		/// Gets or sets the size of the page.
		/// </summary>
		/// <value>The size of the page.</value>
		protected int PageSize
		{
			get { return _pageSize; }
			set { _pageSize = value; }
		}

		/// <summary>
		/// Gets or sets the total row count.
		/// </summary>
		/// <value>The total row count.</value>
		protected int TotalRowCount
		{
			get { return _totalRowCount; }
			set { _totalRowCount = value; }
		}


		/// <summary>
		/// Gets the owner datasource control.
		/// </summary>
		/// <value>The owner.</value>
		internal LLBLGenProDataSourceBase Owner
		{
			get { return _owner; }
		}

		/// <summary>
		/// Gets or sets the sort expression.
		/// </summary>
		/// <value>The sort expression.</value>
		protected string SortExpression
		{
			get { return _sortExpression; }
			set { _sortExpression = value; }
		}

		/// <summary>
		/// Gets or sets a value indicating whether [surpress changed event].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [surpress changed event]; otherwise, <c>false</c>.
		/// </value>
		protected bool SurpressChangedEvent
		{
			get { return _surpressChangedEvent; }
			set { _surpressChangedEvent = value; }
		}
		#endregion
	}
}
