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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Type converter class which is used during design time to serialize a correct constructor call for an entity factory2. 
	/// </summary>
	public class EntityFactory2Converter : TypeConverter 
	{
		/// <summary>
		/// Determines whether this instance [can convert to] the specified context.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="destinationType">Destination type.</param>
		/// <returns>
		/// 	<c>true</c> if this instance [can convert to] the specified context; otherwise, <c>false</c>.
		/// </returns>
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) 
		{
			if (destinationType == typeof(InstanceDescriptor)) 
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		/// <summary>
		/// Converts to the specified type, if applicable.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="culture">Culture.</param>
		/// <param name="value">Value.</param>
		/// <param name="destinationType">Destination type.</param>
		/// <returns></returns>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) 
		{
			IEntityFactory2 factory = value as IEntityFactory2;
			if (destinationType == typeof(InstanceDescriptor) && (value !=null)) 
			{
				ConstructorInfo ctor = value.GetType().GetConstructor(new Type[] {});
				if (ctor != null) 
				{
					return new InstanceDescriptor(ctor, new object[] {});
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);      
		}
	}

	
	/// <summary>
	/// Type converter class which is used during design time to serialize a correct constructor call for an entity factory. 
	/// </summary>
	public class EntityFactoryConverter : TypeConverter 
	{
		/// <summary>
		/// Determines whether this instance [can convert to] the specified context.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="destinationType">Destination type.</param>
		/// <returns>
		/// 	<c>true</c> if this instance [can convert to] the specified context; otherwise, <c>false</c>.
		/// </returns>
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) 
		{
			if (destinationType == typeof(InstanceDescriptor)) 
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		/// <summary>
		/// Converts to the specified type, if applicable.
		/// </summary>
		/// <param name="context">Context.</param>
		/// <param name="culture">Culture.</param>
		/// <param name="value">Value.</param>
		/// <param name="destinationType">Destination type.</param>
		/// <returns></returns>
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) 
		{
			IEntityFactory factory = value as IEntityFactory;
			if (destinationType == typeof(InstanceDescriptor) && (value !=null)) 
			{
				ConstructorInfo ctor = value.GetType().GetConstructor(new Type[] {});
				if (ctor != null) 
				{
					return new InstanceDescriptor(ctor, new object[] {});
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);      
		}
	}



	/// <summary>
	/// Simple designer class for adapter collections to set the entity factory when no factory is set.
	/// </summary>
	public class EntityCollectionComponentDesigner : System.ComponentModel.Design.ComponentDesigner
	{
		#region Static Members
		/// <summary>
		/// Variable which is set as soon as the code determines the objects are used in design mode, instead of runtime mode. 
		/// </summary>
		internal static bool InDesignMode = false;
		#endregion

		#region Class Member Declarations
		private IServiceProvider _host;
		#endregion

		/// <summary>
		/// Creates a new <see cref="EntityCollectionComponentDesigner"/> instance.
		/// </summary>
		public EntityCollectionComponentDesigner()
		{
			_host = null;
			EntityCollectionComponentDesigner.InDesignMode = true;
		}

		/// <summary>
		/// This method provides an opportunity to perform processing when a designer is initialized.
		/// The component parameter is the component that the designer is associated with.
		/// </summary>
		/// <param name="component">Component.</param>
		public override void Initialize(System.ComponentModel.IComponent component)
		{
			base.Initialize(component);
		}


		/// <summary>
		/// Gets the verbs.
		/// </summary>
		/// <value></value>
		public override System.ComponentModel.Design.DesignerVerbCollection Verbs
		{
			get
			{
				return new DesignerVerbCollection( new DesignerVerb[] { new DesignerVerb("Set EntityFactory to use", new EventHandler(this.OnSetEntityFactory)) } );
			}
		}

		/// <summary>
		/// Called when the user clicks the Set EntityFactory to use command in the menu
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void OnSetEntityFactory(object sender, EventArgs e)
		{
			IEntityFactory2 oldValue = ((IEntityCollection2)this.Component).EntityFactoryToUse;
			_host = this.Component.Site.Container as IDesignerHost;
			bool cancelClicked = false;
			IEntityFactory2 factory = SelectEntityFactoryToUse(oldValue, ref cancelClicked);
			if( cancelClicked )
			{
				return;
			}
			if( (factory == null) && (oldValue == null) )
			{
				return;
			}
			if( (factory != null) && (oldValue != null) && factory.GetType().Equals( oldValue.GetType() ) )
			{
				return;
			}
			((IEntityCollection2)this.Component).EntityFactoryToUse = factory;

			// different
			base.RaiseComponentChanged(
				TypeDescriptor.GetProperties( this.Component ).Find( "EntityFactoryToUse", false ),
				oldValue, factory );
		}


		/// <summary>
		/// Selects the entity factory to use for the EntityCollectionBase2 instance which is the component.
		/// </summary>
		/// <param name="currentFactory">The current factory.</param>
		/// <param name="cancelClicked">if set to <c>true</c> [cancel clicked].</param>
		/// <returns></returns>
		public IEntityFactory2 SelectEntityFactoryToUse( IEntityFactory2 currentFactory, ref bool cancelClicked )
		{
			// do a type discovery through the host received. Get the type discovery service from this host.
			ICollection factoriesDiscovered = DesignTimeUtilities.FindTypes( _host, typeof(IEntityFactory2), true);
			EntityFactorySelector selector = new EntityFactorySelector();
			selector.SetFactoriesComboBox( factoriesDiscovered, currentFactory );
			selector.ShowDialog();
			cancelClicked = (selector.DialogResult == DialogResult.Cancel);
			IEntityFactory2 factoryToReturn = null;
			if( selector.DialogResult == DialogResult.Cancel )
			{
				return null;
			}
			Type selectedFactoryType = selector.SelectedFactory;
			if( selectedFactoryType != null )
			{
				// create instance
				factoryToReturn = (IEntityFactory2)Activator.CreateInstance( selectedFactoryType );
			}

			return factoryToReturn;
		}


		/// <summary>
		/// Gets or sets the host.
		/// </summary>
		/// <value>The host.</value>
		public IServiceProvider Host
		{
			get { return _host; }
			set { _host = value; }
		}
	}

	
	/// <summary>
	/// Toolbox item for EntityCollectionBase2 derived classes. This class makes sure the designer pops up the first time an entity collection
	/// is dragged onto the form.
	/// </summary>
	[Serializable]
	public class EntityCollectionToolboxItem : System.Drawing.Design.ToolboxItem
	{
		/// <summary>
		/// Creates a new <see cref="EntityCollectionToolboxItem"/> instance.
		/// </summary>
		/// <param name="typeToRepresent">Type to represent.</param>
		public EntityCollectionToolboxItem( Type typeToRepresent )
			: base( typeToRepresent )
		{
			EntityCollectionComponentDesigner.InDesignMode = true;
		}

		/// <summary>
		/// Creates a new <see cref="EntityCollectionToolboxItem"/> instance.
		/// </summary>
		/// <param name="info">Info.</param>
		/// <param name="context">Context.</param>
		private EntityCollectionToolboxItem( SerializationInfo info, StreamingContext context )
		{
			EntityCollectionComponentDesigner.InDesignMode = true;
			base.Deserialize( info, context );
		}

		/// <summary>
		/// Creates the components core.
		/// </summary>
		/// <param name="host">Host.</param>
		protected override IComponent[] CreateComponentsCore( IDesignerHost host )
		{
			Type entityCollectionType = Type.GetType( base.TypeName );

			if( entityCollectionType == null )
			{
				MessageBox.Show( null, "Could not resolve the type '" + base.TypeName + "', which is likely caused by a missing reference to the assembly '" + base.AssemblyName + "'. ", "Missing reference", MessageBoxButtons.OK, MessageBoxIcon.Error );
				return null;
			}

			IComponent entityCollectionComponent = (IComponent)Activator.CreateInstance( entityCollectionType );
			host.Container.Add( entityCollectionComponent );

			// Show selector. 
			EntityCollectionComponentDesigner designer = new EntityCollectionComponentDesigner();
			designer.Host = (IServiceProvider)host;
			bool cancelClicked = false;
			IEntityFactory2 factory = designer.SelectEntityFactoryToUse( ((IEntityCollection2)entityCollectionComponent).EntityFactoryToUse, ref cancelClicked );
			if( !cancelClicked )
			{
				((IEntityCollection2)entityCollectionComponent).EntityFactoryToUse = factory;
			}

			// return the created component.
			return new IComponent[1] { entityCollectionComponent };
		}
	}


	/// <summary>
	/// General designer class for the LLBLGen Pro DataSource control.
	/// </summary>
	/// <remarks>Adapter specific</remarks>
	public class LLBLGenProDataSourceDesigner2 : DataSourceDesigner
	{
		#region Class Member Declarations
		private LLBLGenProDataSource2 _control;
		#endregion

		/// <summary>
		/// Initializes the control designer and loads the specified component.
		/// </summary>
		/// <param name="component">The control being designed.</param>
		public override void Initialize( IComponent component )
		{
			EntityCollectionComponentDesigner.InDesignMode = true;
			_control = (LLBLGenProDataSource2)component;
			base.Initialize( component );
		}


		/// <summary>
		/// Launches the data source configuration utility in the design host.
		/// </summary>
		public override void Configure()
		{
			ControlDesigner.InvokeTransactedChange( base.Component, new TransactedChangeCallback( this.ConfigureDataSource ), null, "LLBLGenProDataSource2" );
		}


		/// <summary>
		/// Retrieves a <see cref="T:System.Web.UI.Design.DesignerDataSourceView"></see> object that is identified by the view name.
		/// </summary>
		/// <param name="viewName">The name of the view.</param>
		/// <returns>This implementation always returns null.</returns>
		public override DesignerDataSourceView GetView( string viewName )
		{
			if( string.IsNullOrEmpty( viewName ) )
			{
				viewName = LLBLGenProDataSourceBase.DefaultDataSourceViewName;
			}
			return new LLBLGenProDesignerDataSourceView2( this, viewName );
		}


		/// <summary>
		/// Returns an array of the view names that are available in this data source.
		/// </summary>
		/// <returns>An array of view names.</returns>
		public override string[] GetViewNames()
		{
			return new string[] { LLBLGenProDataSourceBase.DefaultDataSourceViewName };
		}


		/// <summary>
		/// Configures the data source change callback.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns></returns>
		private bool ConfigureDataSource( object context )
		{
			DataSourceDesigner2ConfigurationForm configurationForm = new DataSourceDesigner2ConfigurationForm( base.Component.Site, _control );
			DialogResult result = configurationForm.ShowDialog( null );
			return (result == DialogResult.OK);
		}
				
		#region Class Property Declarations
		/// <summary>
		/// Gets a value indicating whether the <see cref="M:System.Web.UI.Design.DataSourceDesigner.Configure"></see> method can be called.
		/// </summary>
		/// <value></value>
		/// <returns>true, if <see cref="M:System.Web.UI.Design.DataSourceDesigner.Configure"></see> can be called; otherwise, false. The default is false.</returns>
		public override bool CanConfigure
		{
			get
			{
				return true;
			}
		}


		/// <summary>
		/// Gets the data source.
		/// </summary>
		/// <value>The data source.</value>
		internal LLBLGenProDataSource2 DataSource
		{
			get { return _control; }
		}
		#endregion
	}


	/// <summary>
	/// General designer class for the LLBLGen Pro DataSource control.
	/// </summary>
	/// <remarks>Selfservicing specific</remarks>
	public class LLBLGenProDataSourceDesigner : DataSourceDesigner
	{
		#region Class Member Declarations
		private LLBLGenProDataSource _control;
		#endregion

		/// <summary>
		/// Initializes the control designer and loads the specified component.
		/// </summary>
		/// <param name="component">The control being designed.</param>
		public override void Initialize( IComponent component )
		{
			EntityCollectionComponentDesigner.InDesignMode = true;
			_control = (LLBLGenProDataSource)component;
			base.Initialize( component );
		}


		/// <summary>
		/// Launches the data source configuration utility in the design host.
		/// </summary>
		public override void Configure()
		{
			ControlDesigner.InvokeTransactedChange( base.Component, new TransactedChangeCallback( this.ConfigureDataSource ), null, "LLBLGenProDataSource" );
		}


		/// <summary>
		/// Retrieves a <see cref="T:System.Web.UI.Design.DesignerDataSourceView"></see> object that is identified by the view name.
		/// </summary>
		/// <param name="viewName">The name of the view.</param>
		/// <returns>This implementation always returns null.</returns>
		public override DesignerDataSourceView GetView( string viewName )
		{
			if( string.IsNullOrEmpty( viewName ) )
			{
				viewName = LLBLGenProDataSourceBase.DefaultDataSourceViewName;
			}
			return new LLBLGenProDesignerDataSourceView( this, viewName );
		}


		/// <summary>
		/// Returns an array of the view names that are available in this data source.
		/// </summary>
		/// <returns>An array of view names.</returns>
		public override string[] GetViewNames()
		{
			return new string[] { LLBLGenProDataSourceBase.DefaultDataSourceViewName };
		}


		/// <summary>
		/// Configures the data source change callback.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <returns></returns>
		private bool ConfigureDataSource( object context )
		{
			DataSourceDesignerConfigurationForm configurationForm = new DataSourceDesignerConfigurationForm( base.Component.Site, _control );
			DialogResult result = configurationForm.ShowDialog( null );
			return (result == DialogResult.OK);
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets a value indicating whether the <see cref="M:System.Web.UI.Design.DataSourceDesigner.Configure"></see> method can be called.
		/// </summary>
		/// <value></value>
		/// <returns>true, if <see cref="M:System.Web.UI.Design.DataSourceDesigner.Configure"></see> can be called; otherwise, false. The default is false.</returns>
		public override bool CanConfigure
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Gets the data source.
		/// </summary>
		/// <value>The data source.</value>
		internal LLBLGenProDataSource DataSource
		{
			get { return _control; }
		}
		#endregion
	}
	


	/// <summary>
	/// General datasourceview for design time databinding
	/// </summary>
	/// <remarks>Adapter specific</remarks>
	public class LLBLGenProDesignerDataSourceView2 : DesignerDataSourceView
	{
		#region Class Member Declarations
		private LLBLGenProDataSourceDesigner2 _owner;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="LLBLGenProDesignerDataSourceView2"/> class.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="viewName">Name of the view.</param>
		public LLBLGenProDesignerDataSourceView2( LLBLGenProDataSourceDesigner2 owner, string viewName )
			: base( owner, viewName )
		{
			_owner = owner;
		}


		/// <summary>
		/// Generates design-time data that matches the schema of the associated data source control using the provided number of rows and returns a value indicating whether the data is sample or real data.
		/// </summary>
		/// <param name="minimumRows">The minimum number of rows to return.</param>
		/// <param name="isSampleData">true to indicate the returned data is sample data; false to indicate the returned data is live data.</param>
		/// <returns>
		/// A <see cref="T:System.Web.UI.DataSourceView"></see> containing data to display at design time.
		/// </returns>
		public override IEnumerable GetDesignTimeData( int minimumRows, out bool isSampleData )
		{
			IEnumerable toReturn = null; ;
			LLBLGenProDataSource2 dataSource = _owner.DataSource;
			switch( dataSource.DataContainerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					IEntityCollection2 collection = dataSource.GetViewInternal().ContainedEntityCollection;
					if( collection != null )
					{
						if(( collection.Count <= 0 ) && (collection.EntityFactoryToUse!=null))
						{
							for( int i = 0; i < minimumRows; i++ )
							{
								collection.Add( collection.EntityFactoryToUse.Create() );
							}
						}
						toReturn = collection.DefaultView;
					}
					break;
				case DataSourceDataContainerType.TypedList:
					toReturn = ((DataTable)dataSource.GetViewInternal().ContainedTypedList).DefaultView;
					break;
				case DataSourceDataContainerType.TypedView:
					toReturn = ((DataTable)dataSource.GetViewInternal().ContainedTypedView).DefaultView;
					break;
			} 

			isSampleData = true;
			return toReturn;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object that is associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports paging through the data that is retrieved by the <see cref="M:System.Web.UI.DataSourceView.ExecuteSelect(System.Web.UI.DataSourceSelectArguments)"></see> method.
		/// </summary>
		/// <value></value>
		/// <returns>true, if paging through the data retrieved by the <see cref="M:System.Web.UI.DataSourceView.ExecuteSelect(System.Web.UI.DataSourceSelectArguments)"></see> is supported; otherwise, false.</returns>
		public override bool CanPage
		{
			get
			{
				return _owner.DataSource.EnablePaging;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object that is associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports the <see cref="M:System.Web.UI.DataSourceView.ExecuteDelete(System.Collections.IDictionary,System.Collections.IDictionary)"></see> method.
		/// </summary>
		/// <value></value>
		/// <returns>true, if the <see cref="M:System.Web.UI.DataSourceView.ExecuteDelete(System.Collections.IDictionary,System.Collections.IDictionary)"></see> is supported; otherwise, false.</returns>
		public override bool CanDelete
		{
			get
			{
				return _owner.DataSource.DataContainerType == DataSourceDataContainerType.EntityCollection;
			}
		}


		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object that is associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports the <see cref="M:System.Web.UI.DataSourceView.ExecuteInsert(System.Collections.IDictionary)"></see> method.
		/// </summary>
		/// <value></value>
		/// <returns>true, if the <see cref="M:System.Web.UI.DataSourceView.ExecuteInsert(System.Collections.IDictionary)"></see> is supported; otherwise, false.</returns>
		public override bool CanInsert
		{
			get
			{
				return _owner.DataSource.DataContainerType == DataSourceDataContainerType.EntityCollection;
			}
		}
		

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object that is associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports the <see cref="M:System.Web.UI.DataSourceView.ExecuteUpdate(System.Collections.IDictionary,System.Collections.IDictionary,System.Collections.IDictionary)"></see> method.
		/// </summary>
		/// <value></value>
		/// <returns>true, if the <see cref="M:System.Web.UI.DataSourceView.ExecuteUpdate(System.Collections.IDictionary,System.Collections.IDictionary,System.Collections.IDictionary)"></see> is supported; otherwise, false.</returns>
		public override bool CanUpdate
		{
			get
			{
				return _owner.DataSource.DataContainerType == DataSourceDataContainerType.EntityCollection;
			}
		}


		/// <summary>
		/// Gets a schema that describes the data source view that is represented by this view object.
		/// </summary>
		/// <value></value>
		/// <returns>An <see cref="T:System.Web.UI.Design.IDataSourceViewSchema"></see>.</returns>
		public override IDataSourceViewSchema Schema
		{
			get
			{
				LLBLGenProDataSource2 dataSource = _owner.DataSource;
				LLBLGenProTypeSchemaView toReturn = null; 
				switch( dataSource.DataContainerType )
				{
					case DataSourceDataContainerType.EntityCollection:
						IEntityFactory2 factory = dataSource.GetViewInternal().EntityFactoryToUse;
						if(factory!=null)
						{
							toReturn = new LLBLGenProTypeSchemaView( factory.Create() );
						}
						break;
					case DataSourceDataContainerType.TypedList:
						ITypedListLgp2 typedList = dataSource.GetViewInternal().ContainedTypedList;
						if(typedList!=null)
						{
							toReturn = new LLBLGenProTypeSchemaView( ((DataTable)typedList).NewRow() );
						}
						break;
					case DataSourceDataContainerType.TypedView:
						ITypedView2 typedView = dataSource.GetViewInternal().ContainedTypedView;
						if(typedView!=null)
						{
							toReturn = new LLBLGenProTypeSchemaView( ((DataTable)typedView).NewRow() );
						}
						break;
				} 
				return toReturn;
			}
		}

		#endregion

	}

	
	/// <summary>
	/// General datasourceview for design time databinding
	/// </summary>
	/// <remarks>Selfservicing specific</remarks>
	public class LLBLGenProDesignerDataSourceView : DesignerDataSourceView
	{
		#region Class Member Declarations
		private LLBLGenProDataSourceDesigner _owner;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="LLBLGenProDesignerDataSourceView"/> class.
		/// </summary>
		/// <param name="owner">The owner.</param>
		/// <param name="viewName">Name of the view.</param>
		public LLBLGenProDesignerDataSourceView( LLBLGenProDataSourceDesigner owner, string viewName )
			: base( owner, viewName )
		{
			_owner = owner;
		}


		/// <summary>
		/// Generates design-time data that matches the schema of the associated data source control using the provided number of rows and returns a value indicating whether the data is sample or real data.
		/// </summary>
		/// <param name="minimumRows">The minimum number of rows to return.</param>
		/// <param name="isSampleData">true to indicate the returned data is sample data; false to indicate the returned data is live data.</param>
		/// <returns>
		/// A <see cref="T:System.Web.UI.DataSourceView"></see> containing data to display at design time.
		/// </returns>
		public override IEnumerable GetDesignTimeData( int minimumRows, out bool isSampleData )
		{
			IEnumerable toReturn = null; ;
			LLBLGenProDataSource dataSource = _owner.DataSource;
			switch( dataSource.DataContainerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					IEntityCollection collection = dataSource.GetViewInternal().ContainedEntityCollection;
					if( collection != null )
					{
						if( (collection.Count <= 0) && (collection.EntityFactoryToUse != null) )
						{
							for( int i = 0; i < minimumRows; i++ )
							{
								collection.Add( collection.EntityFactoryToUse.Create() );
							}
						}
						toReturn = collection.DefaultView;
					}
					break;
				case DataSourceDataContainerType.TypedList:
					toReturn = ((DataTable)dataSource.GetViewInternal().ContainedTypedList).DefaultView;
					break;
				case DataSourceDataContainerType.TypedView:
					toReturn = ((DataTable)dataSource.GetViewInternal().ContainedTypedView).DefaultView;
					break;
			}

			isSampleData = true;
			return toReturn;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object that is associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports paging through the data that is retrieved by the <see cref="M:System.Web.UI.DataSourceView.ExecuteSelect(System.Web.UI.DataSourceSelectArguments)"></see> method.
		/// </summary>
		/// <value></value>
		/// <returns>true, if paging through the data retrieved by the <see cref="M:System.Web.UI.DataSourceView.ExecuteSelect(System.Web.UI.DataSourceSelectArguments)"></see> is supported; otherwise, false.</returns>
		public override bool CanPage
		{
			get
			{
				return _owner.DataSource.EnablePaging;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object that is associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports the <see cref="M:System.Web.UI.DataSourceView.ExecuteDelete(System.Collections.IDictionary,System.Collections.IDictionary)"></see> method.
		/// </summary>
		/// <value></value>
		/// <returns>true, if the <see cref="M:System.Web.UI.DataSourceView.ExecuteDelete(System.Collections.IDictionary,System.Collections.IDictionary)"></see> is supported; otherwise, false.</returns>
		public override bool CanDelete
		{
			get
			{
				return _owner.DataSource.DataContainerType == DataSourceDataContainerType.EntityCollection;
			}
		}


		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object that is associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports the <see cref="M:System.Web.UI.DataSourceView.ExecuteInsert(System.Collections.IDictionary)"></see> method.
		/// </summary>
		/// <value></value>
		/// <returns>true, if the <see cref="M:System.Web.UI.DataSourceView.ExecuteInsert(System.Collections.IDictionary)"></see> is supported; otherwise, false.</returns>
		public override bool CanInsert
		{
			get
			{
				return _owner.DataSource.DataContainerType == DataSourceDataContainerType.EntityCollection;
			}
		}


		/// <summary>
		/// Gets a value indicating whether the <see cref="T:System.Web.UI.DataSourceView"></see> object that is associated with the current <see cref="T:System.Web.UI.DataSourceControl"></see> object supports the <see cref="M:System.Web.UI.DataSourceView.ExecuteUpdate(System.Collections.IDictionary,System.Collections.IDictionary,System.Collections.IDictionary)"></see> method.
		/// </summary>
		/// <value></value>
		/// <returns>true, if the <see cref="M:System.Web.UI.DataSourceView.ExecuteUpdate(System.Collections.IDictionary,System.Collections.IDictionary,System.Collections.IDictionary)"></see> is supported; otherwise, false.</returns>
		public override bool CanUpdate
		{
			get
			{
				return _owner.DataSource.DataContainerType == DataSourceDataContainerType.EntityCollection;
			}
		}


		/// <summary>
		/// Gets a schema that describes the data source view that is represented by this view object.
		/// </summary>
		/// <value></value>
		/// <returns>An <see cref="T:System.Web.UI.Design.IDataSourceViewSchema"></see>.</returns>
		public override IDataSourceViewSchema Schema
		{
			get
			{
				LLBLGenProDataSource dataSource = _owner.DataSource;
				LLBLGenProTypeSchemaView toReturn = null;
				switch( dataSource.DataContainerType )
				{
					case DataSourceDataContainerType.EntityCollection:
						IEntityFactory factory = dataSource.GetViewInternal().ContainedEntityCollection.EntityFactoryToUse;
						if( factory != null )
						{
							toReturn = new LLBLGenProTypeSchemaView( factory.Create() );
						}
						break;
					case DataSourceDataContainerType.TypedList:
						ITypedListLgp typedList = dataSource.GetViewInternal().ContainedTypedList;
						if( typedList != null )
						{
							toReturn = new LLBLGenProTypeSchemaView( ((DataTable)typedList).NewRow() );
						}
						break;
					case DataSourceDataContainerType.TypedView:
						ITypedView typedView = dataSource.GetViewInternal().ContainedTypedView;
						if( typedView != null )
						{
							toReturn = new LLBLGenProTypeSchemaView( ((DataTable)typedView).NewRow() );
						}
						break;
				}

				return toReturn;
			}
		}

		#endregion

	}

	
	/// <summary>
	/// Class to produce property descriptors for ASP.NET. This class is necessary because ASP.NET 2.0 TypeSchema object can't sort properties nor filter out
	/// properties marked with Browsable(false). 
	/// </summary>
	internal class LLBLGenProTypeSchemaView : IDataSourceViewSchema
	{
		#region Class Member Declarations
		private List<IDataSourceFieldSchema> _fields;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="LLBLGenProTypeSchemaView"/> class.
		/// </summary>
		/// <param name="row">The row.</param>
		public LLBLGenProTypeSchemaView(DataRow row)
		{
			PropertyDescriptorCollection typeProperties = TypeDescriptor.GetProperties( row.GetType() );
			CreateFieldSchemaObjects( typeProperties );
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="LLBLGenProTypeSchemaView"/> class.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public LLBLGenProTypeSchemaView( IEntity entity )
		{
			PropertyDescriptorCollection typeProperties = TypeDescriptor.GetProperties( entity.GetType() );
			// replace descriptors for fields by entitypropertydescriptors.
			List<PropertyDescriptor> instanceProperties = new List<PropertyDescriptor>();
			Dictionary<string, PropertyDescriptor> namesAdded = new Dictionary<string, PropertyDescriptor>();
			FieldUtilities utils = new FieldUtilities();
			utils.GetEntityFieldPropertyDescriptors( entity, ref instanceProperties, ref namesAdded );
			
			// now walk all properties in the property descriptor collection. Check if the name occurs in the hashtable. 
			// If not and if browsable, copy the descriptor over.
			foreach( PropertyDescriptor property in typeProperties )
			{
				if( !namesAdded.ContainsKey( property.Name ) )
				{
					if( !property.IsBrowsable )
					{
						continue;
					}
					// check if the property is of a type which is an LLBLGen Pro collection. If so, skip it
					if(property.PropertyType.GetInterface( "IEntityCollection" ) != null)
					{
						continue;
					}
					// add it
					instanceProperties.Add( property );
				}
			}
			PropertyDescriptorCollection toPass = new PropertyDescriptorCollection( instanceProperties.ToArray() );
			CreateFieldSchemaObjects( toPass );
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="LLBLGenProTypeSchemaView"/> class.
		/// </summary>
		/// <param name="entity">The entity.</param>
		public LLBLGenProTypeSchemaView( IEntity2 entity )
		{
			PropertyDescriptorCollection typeProperties = TypeDescriptor.GetProperties( entity.GetType() );
			// replace descriptors for fields by entitypropertydescriptors.
			List<PropertyDescriptor> instanceProperties = new List<PropertyDescriptor>();
			Dictionary<string, PropertyDescriptor> namesAdded = new Dictionary<string, PropertyDescriptor>();
			FieldUtilities utils = new FieldUtilities();
			utils.GetEntityFieldPropertyDescriptors( entity, ref instanceProperties, ref namesAdded );

			// now walk all properties in the property descriptor collection. Check if the name occurs in the hashtable. 
			// If not and if browsable, copy the descriptor over.
			foreach( PropertyDescriptor property in typeProperties )
			{
				if( !namesAdded.ContainsKey( property.Name ) )
				{
					if( !property.IsBrowsable )
					{
						continue;
					}
					// check if the property is of a type which is an LLBLGen Pro collection. If so, skip it
					if( property.PropertyType.GetInterface( "IEntityCollection2" ) != null )
					{
						continue;
					}
					// add it
					instanceProperties.Add( property );
				}
			}
			PropertyDescriptorCollection toPass = new PropertyDescriptorCollection( instanceProperties.ToArray() );
			CreateFieldSchemaObjects( toPass );
		}


		/// <summary>
		/// Gets an array representing the child views contained in the current view.
		/// </summary>
		/// <returns>
		/// An array of <see cref="T:System.Web.UI.Design.IDataSourceViewSchema"></see> objects that represent the child views contained in the current view.
		/// </returns>
		public IDataSourceViewSchema[] GetChildren()
		{
			return null;
		}

		/// <summary>
		/// Gets an array containing information about each field in the data source.
		/// </summary>
		/// <returns>
		/// An array of <see cref="T:System.Web.UI.Design.IDataSourceFieldSchema"></see> objects representing each of the fields in the data source.
		/// </returns>
		public IDataSourceFieldSchema[] GetFields()
		{
			return _fields.ToArray();
		}


		/// <summary>
		/// Creates the field schema objects.
		/// </summary>
		/// <param name="properties">The properties.</param>
		private void CreateFieldSchemaObjects(PropertyDescriptorCollection properties)
		{
			_fields = new List<IDataSourceFieldSchema>();

			if( properties != null )
			{
				// for each property which doesn't have the Browsable(false) attribute and which isn't implementing IList, create a
				// LLBLGenProTypeFieldSchema instance and add it to the list to return.
				foreach( PropertyDescriptor descriptor in properties )
				{
					if( !descriptor.IsBrowsable )
					{
						// not browsable, skip
						continue;
					}
					if( descriptor.PropertyType.GetInterface( "IList" ) != null )
					{
						// implements IList, skip
						continue;
					}
					// allowed
					_fields.Add( new LLBLGenProTypeFieldSchema( descriptor ) );
				}
			}
		}


		#region Class Property declarations
		/// <summary>
		/// Gets the name of the view.
		/// </summary>
		/// <value></value>
		/// <returns>The name of the view.</returns>
		public string Name
		{
			get { return string.Empty; }
		}

		#endregion
	}


	/// <summary>
	/// Class to produce information of a field type in an LLBLGenProTypeSchemaView object, which is used by ASP.NET to work with types during design time. 
	/// </summary>
	internal class LLBLGenProTypeFieldSchema : IDataSourceFieldSchema
	{
		#region Class Member Declarations
		private PropertyDescriptor _descriptor;
		private bool _isSelfServicingField, _isAdapterField;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="LLBLGenProTypeFieldSchema"/> class.
		/// </summary>
		/// <param name="descriptor">The descriptor.</param>
		public LLBLGenProTypeFieldSchema( PropertyDescriptor descriptor )
		{
			_descriptor = descriptor;
			_isSelfServicingField = (descriptor is EntityPropertyDescriptor);
			_isAdapterField = (descriptor is EntityPropertyDescriptor2);
		}


		#region Class Property declarations
		/// <summary>
		/// Gets the type of data stored in the field.
		/// </summary>
		/// <value></value>
		/// <returns>A <see cref="T:System.Type"></see> object.</returns>
		public Type DataType
		{
			get 
			{ 
				// if the propertyType is a generic nullable type, report the real type (== generic argument), not the Nullable<T> type. 
				if( _descriptor.PropertyType.IsGenericType  && _descriptor.PropertyType.GetGenericTypeDefinition() == typeof( Nullable<> ) )
				{
					return _descriptor.PropertyType.GetGenericArguments()[0];
				}
				else
				{
					return _descriptor.PropertyType;
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether the value of the field automatically increments for each new row.
		/// </summary>
		/// <value></value>
		/// <returns>true if the field's <see cref="P:System.Web.UI.Design.IDataSourceFieldSchema.DataType"></see> is numeric and the underlying field increments automatically as new rows are added; otherwise, false.</returns>
		public bool Identity
		{
			get 
			{
				if(_isSelfServicingField)
				{
					return ((EntityPropertyDescriptor)_descriptor).Field.IsIdentity;
				}
				else
				{
					// not determinable
					return false;
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether the field is editable.
		/// </summary>
		/// <value></value>
		/// <returns>true if the field is read-only; otherwise, false.</returns>
		public bool IsReadOnly
		{
			get 
			{
				if( _isSelfServicingField )
				{
					return ((EntityPropertyDescriptor)_descriptor).Field.IsReadOnly;
				}
				else
				{
					if( _isAdapterField )
					{
						return ((EntityPropertyDescriptor2)_descriptor).Field.IsReadOnly;
					}
					else
					{
						// not determinable
						return false;
					}
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether values in the field are required to be unique.
		/// </summary>
		/// <remarks>always false.</remarks>
		public bool IsUnique
		{
			get 
			{ 
				return false; 
			}
		}

		/// <summary>
		/// Gets a value indicting the size of data that can be stored in the field.
		/// </summary>
		/// <value></value>
		/// <returns>The number of bytes the field can store.</returns>
		public int Length
		{
			get
			{
				if( _isSelfServicingField )
				{
					return ((EntityPropertyDescriptor)_descriptor).Field.MaxLength;
				}
				else
				{
					if( _isAdapterField )
					{
						return ((EntityPropertyDescriptor2)_descriptor).Field.MaxLength;
					}
					else
					{
						// not determinable
						return -1;
					}
				}
			}
		}

		/// <summary>
		/// Gets the name of the field.
		/// </summary>
		/// <value></value>
		/// <returns>The name of the field.</returns>
		public string Name
		{
			get { return _descriptor.Name; }
		}

		/// <summary>
		/// Gets a value indicating whether the field can accept null values.
		/// </summary>
		/// <value></value>
		/// <returns>true if the field can accept null values; otherwise, false.</returns>
		public bool Nullable
		{
			get
			{
				if( _isSelfServicingField )
				{
					return ((EntityPropertyDescriptor)_descriptor).Field.IsNullable;
				}
				else
				{
					if( _isAdapterField )
					{
						return ((EntityPropertyDescriptor2)_descriptor).Field.IsNullable;
					}
					else
					{
						if( !_descriptor.PropertyType.IsValueType)
						{
							// not a value type, so is always nullable
							return true;
						}
						if( _descriptor.PropertyType.IsGenericType )
						{
							// return nullable if it's an instance of Nullable<T>
							return (_descriptor.PropertyType.GetGenericTypeDefinition() == typeof( Nullable<> ));
						}
						else
						{
							// not nullable
							return false;
						}
					}
				}
			}
		}

		/// <summary>
		/// Gets the maximum number of digits used to represent a numerical value in the field.
		/// </summary>
		/// <value></value>
		/// <returns>The maximum number of digits used to represent the values of the field if the <see cref="P:System.Web.UI.Design.IDataSourceFieldSchema.DataType"></see> of the field is numeric. If this property is not implemented, it should return -1.</returns>
		public int Precision
		{
			get
			{
				if( _isSelfServicingField )
				{
					return ((EntityPropertyDescriptor)_descriptor).Field.Precision;
				}
				else
				{
					if( _isAdapterField )
					{
						return ((EntityPropertyDescriptor2)_descriptor).Field.Precision;
					}
					else
					{
						// not determinable
						return -1;
					}
				}
			}
		}

		/// <summary>
		/// Gets a value indicating whether the field is in the primary key.
		/// </summary>
		/// <value></value>
		/// <returns>true if the field is in the primary key; otherwise, false.</returns>
		public bool PrimaryKey
		{
			get
			{
				if( _isSelfServicingField )
				{
					return ((EntityPropertyDescriptor)_descriptor).Field.IsPrimaryKey;
				}
				else
				{
					if( _isAdapterField )
					{
						return ((EntityPropertyDescriptor2)_descriptor).Field.IsPrimaryKey;
					}
					else
					{
						// not determinable
						return false;
					}
				}
			}
		}

		/// <summary>
		/// Gets the number of decimal places to which numerical values in the field are resolved.
		/// </summary>
		/// <value></value>
		/// <returns>If the <see cref="P:System.Web.UI.Design.IDataSourceFieldSchema.DataType"></see> of the field is numeric, returns the number of decimal places to which values are resolved, otherwise -1.</returns>
		public int Scale
		{
			get
			{
				if( _isSelfServicingField )
				{
					return ((EntityPropertyDescriptor)_descriptor).Field.Scale;
				}
				else
				{
					if( _isAdapterField )
					{
						return ((EntityPropertyDescriptor2)_descriptor).Field.Scale;
					}
					else
					{
						// not determinable
						return -1;
					}
				}
			}
		}

		#endregion
	}


	/// <summary>
	/// General class which contains utility methods for design time activities.
	/// </summary>
	internal static class DesignTimeUtilities
	{
		/// <summary>
		/// Finds the types in the projects loaded which implement / derive from the defining type. If excludeDefiningType is true, the 
		/// returned list won't include that type, if found.
		/// </summary>
		/// <param name="serviceProvider">The service provider.</param>
		/// <param name="definingType">Type of the defining.</param>
		/// <param name="excludeDefiningType">if set to <c>true</c> [exclude defining type].</param>
		/// <returns>List with Type objects which implement or derive from the defining type.</returns>
		internal static ICollection FindTypes( IServiceProvider serviceProvider, Type definingType, bool excludeDefiningType )
		{
			List<Type> typesFound = new List<Type>();

			// do a type discovery through the service provider received. Get the type discovery service from this host.
			ITypeDiscoveryService discoveryService = (ITypeDiscoveryService)serviceProvider.GetService( typeof( ITypeDiscoveryService ) );

			ICollection typesDiscovered = discoveryService.GetTypes(definingType, true);
			foreach(Type foundType in typesDiscovered)
			{
				if(excludeDefiningType && foundType == definingType)
				{
					//skip
					continue;
				}
				typesFound.Add(foundType);
			}

			return typesFound;
		}
	}
}
