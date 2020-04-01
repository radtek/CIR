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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel.Design;
using System.Collections;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Special designer form which is popped up when the user clicks 'Configure data source' on an LLBLGenProDataSource2 component on an ASP.NET webform.
	/// </summary>
	public partial class DataSourceDesigner2ConfigurationForm : Form
	{
		#region Class Member Declarations
		private IServiceProvider _serviceProvider;
		private DataSourceDataContainerType _containerType;
		private LLBLGenProDataSource2 _dataSourceControl;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="DataSourceDesigner2ConfigurationForm"/> class.
		/// </summary>
		/// <param name="serviceProvider">The service provider.</param>
		/// <param name="dataSourceControl">The data source control.</param>
		public DataSourceDesigner2ConfigurationForm(IServiceProvider serviceProvider, LLBLGenProDataSource2 dataSourceControl)
		{
			_serviceProvider = serviceProvider;
			_dataSourceControl = dataSourceControl;

			InitializeComponent();

			// don't let resizing below this current size.
			this.MinimumSize = this.Size;

			// select entitycollection by default.
			_containerTypeComboBox.SelectedIndex = (int)_dataSourceControl.DataContainerType;

			// fill all type combo boxes.
			_adapterTypeComboBox.DataSource = DesignTimeUtilities.FindTypes( _serviceProvider, typeof( IDataAccessAdapter ), true );
			_adapterTypeComboBox.DisplayMember = "FullName";
			if( _dataSourceControl.AdapterToUse != null )
			{
				_adapterTypeComboBox.SelectedItem = _dataSourceControl.AdapterToUse.GetType();
			}
			_entityFactoriesComboBox.DataSource = DesignTimeUtilities.FindTypes( _serviceProvider, typeof( IEntityFactory2 ), true );
			_entityFactoriesComboBox.DisplayMember = "FullName";
			_typedListTypeComboBox.DataSource = DesignTimeUtilities.FindTypes( _serviceProvider, typeof( ITypedListLgp2 ), true );
			_typedListTypeComboBox.DisplayMember = "FullName";
			_typedViewTypeComboBox.DataSource = DesignTimeUtilities.FindTypes( _serviceProvider, typeof( ITypedView2 ), true );
			_typedViewTypeComboBox.DisplayMember = "FullName";

			switch( _containerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					if((_dataSourceControl.EntityCollection!=null) && ( _dataSourceControl.EntityCollection.EntityFactoryToUse != null ))
					{
						_entityFactoriesComboBox.SelectedItem = _dataSourceControl.EntityCollection.EntityFactoryToUse.GetType();
					}
					break;
				case DataSourceDataContainerType.TypedList:
					if( _dataSourceControl.TypedList != null )
					{
						_typedListTypeComboBox.SelectedItem = _dataSourceControl.TypedList.GetType();
					}
					break;
				case DataSourceDataContainerType.TypedView:
					if( _dataSourceControl.TypedView != null )
					{
						_typedViewTypeComboBox.SelectedItem = _dataSourceControl.TypedView.GetType();
					}
					break;
			}
		}


		private void _containerTypeComboBox_SelectedIndexChanged( object sender, EventArgs e )
		{
			_containerType = (DataSourceDataContainerType)_containerTypeComboBox.SelectedIndex;
			_entityCollectionConfigurationGroupBox.Visible = (_containerType == DataSourceDataContainerType.EntityCollection);
			_typedListConfigurationGroupBox.Visible = (_containerType == DataSourceDataContainerType.TypedList);
			_typedViewConfigurationGroupBox.Visible = (_containerType == DataSourceDataContainerType.TypedView);

		}

		private void _okButton_Click( object sender, EventArgs e )
		{
			// set info.
			_dataSourceControl.DataContainerType = _containerType;
			_dataSourceControl.EntityFactoryTypeName = string.Empty;
			_dataSourceControl.TypedListTypeName = string.Empty;
			_dataSourceControl.TypedViewTypeName = string.Empty;
			switch( _containerType )
			{
				case DataSourceDataContainerType.EntityCollection:
					if( _entityFactoriesComboBox.SelectedItem != null )
					{
						_dataSourceControl.EntityFactoryTypeName = FieldUtilities.CreateFullTypeName( (Type)_entityFactoriesComboBox.SelectedItem );
					}
					break;
				case DataSourceDataContainerType.TypedList:
					if( _typedListTypeComboBox.SelectedItem != null )
					{
						_dataSourceControl.TypedListTypeName = FieldUtilities.CreateFullTypeName( (Type)_typedListTypeComboBox.SelectedItem );
					}
					break;
				case DataSourceDataContainerType.TypedView:
					if( _typedViewTypeComboBox.SelectedItem != null )
					{
						_dataSourceControl.TypedViewTypeName = FieldUtilities.CreateFullTypeName( (Type)_typedViewTypeComboBox.SelectedItem );
					}
					break;
			}
			if( _adapterTypeComboBox.SelectedItem != null )
			{
				_dataSourceControl.AdapterTypeName = FieldUtilities.CreateFullTypeName( (Type)_adapterTypeComboBox.SelectedItem );
			}

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void _cancelButton_Click( object sender, EventArgs e )
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}