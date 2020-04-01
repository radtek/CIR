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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// EntityFactorySelector form.
	/// </summary>
	public class EntityFactorySelector : System.Windows.Forms.Form
	{
		#region Class Member Declarations
		private bool		_cancelClicked;
		#endregion


		#region Controls
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox _entityFactoriesComboBox;
		private System.Windows.Forms.Button _selectButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.ComponentModel.Container components = null;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public EntityFactorySelector()
		{
			InitializeComponent();
			_cancelClicked = false;
		}


		/// <summary>
		/// Sets the factories combo box.
		/// </summary>
		/// <param name="factories">ArrayList with names of the factories found</param>
		/// <param name="currentFactory">Current factory.</param>
		public void SetFactoriesComboBox(ArrayList factories, IEntityFactory2 currentFactory)
		{
			_entityFactoriesComboBox.DataSource = factories;
			if(currentFactory!=null)
			{
				_entityFactoriesComboBox.SelectedItem = currentFactory.GetType();
			}
		}


		#region Windows Form Designer generated code
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this._entityFactoriesComboBox = new System.Windows.Forms.ComboBox();
			this._selectButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this._entityFactoriesComboBox);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(531, 51);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Entity Factories found";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 18);
			this.label1.TabIndex = 0;
			this.label1.Text = "Factory to select";
			// 
			// _entityFactoriesComboBox
			// 
			this._entityFactoriesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this._entityFactoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._entityFactoriesComboBox.Location = new System.Drawing.Point(117, 21);
			this._entityFactoriesComboBox.Name = "_entityFactoriesComboBox";
			this._entityFactoriesComboBox.Size = new System.Drawing.Size(405, 21);
			this._entityFactoriesComboBox.Sorted = true;
			this._entityFactoriesComboBox.TabIndex = 1;
			// 
			// _selectButton
			// 
			this._selectButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this._selectButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._selectButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._selectButton.Location = new System.Drawing.Point(187, 63);
			this._selectButton.Name = "_selectButton";
			this._selectButton.TabIndex = 1;
			this._selectButton.Text = "Select";
			this._selectButton.Click += new System.EventHandler(this._selectButton_Click);
			// 
			// _cancelButton
			// 
			this._cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._cancelButton.Location = new System.Drawing.Point(283, 63);
			this._cancelButton.Name = "_cancelButton";
			this._cancelButton.TabIndex = 1;
			this._cancelButton.Text = "Cancel";
			this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
			// 
			// EntityFactorySelector
			// 
			this.AcceptButton = this._selectButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this._cancelButton;
			this.ClientSize = new System.Drawing.Size(544, 97);
			this.Controls.Add(this._selectButton);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this._cancelButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "EntityFactorySelector";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select EntityFactory to use";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void _selectButton_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void _cancelButton_Click(object sender, System.EventArgs e)
		{
			_cancelClicked = true;
			this.Close();
		}


		/// <summary>
		/// Gets cancelClicked
		/// </summary>
		public bool CancelClicked
		{
			get
			{
				return _cancelClicked;
			}
		}


		/// <summary>
		/// Gets the selected factory.
		/// </summary>
		/// <value></value>
		public Type SelectedFactory
		{
			get
			{
				if(_entityFactoriesComboBox.SelectedItem==null)
				{
					return null;
				}
				return (Type)_entityFactoriesComboBox.SelectedItem;
			}
		}
	}
}
