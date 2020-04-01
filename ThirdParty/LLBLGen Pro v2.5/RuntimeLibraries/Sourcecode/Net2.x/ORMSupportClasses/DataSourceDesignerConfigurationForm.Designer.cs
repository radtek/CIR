namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	partial class DataSourceDesignerConfigurationForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._containerTypeComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this._entityCollectionConfigurationGroupBox = new System.Windows.Forms.GroupBox();
			this._entityCollectionComboBox = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this._typedViewConfigurationGroupBox = new System.Windows.Forms.GroupBox();
			this._typedViewTypeComboBox = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this._typedListConfigurationGroupBox = new System.Windows.Forms.GroupBox();
			this._typedListTypeComboBox = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this._okButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this._configurationPanel = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this._entityCollectionConfigurationGroupBox.SuspendLayout();
			this._typedViewConfigurationGroupBox.SuspendLayout();
			this._typedListConfigurationGroupBox.SuspendLayout();
			this._configurationPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add( this._containerTypeComboBox );
			this.groupBox1.Controls.Add( this.label2 );
			this.groupBox1.Location = new System.Drawing.Point( 6, 5 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 534, 44 );
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Container type selection";
			// 
			// _containerTypeComboBox
			// 
			this._containerTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._containerTypeComboBox.FormattingEnabled = true;
			this._containerTypeComboBox.Items.AddRange( new object[] {
            "EntityCollection",
            "TypedList",
            "TypedView"} );
			this._containerTypeComboBox.Location = new System.Drawing.Point( 147, 13 );
			this._containerTypeComboBox.Name = "_containerTypeComboBox";
			this._containerTypeComboBox.Size = new System.Drawing.Size( 173, 21 );
			this._containerTypeComboBox.TabIndex = 1;
			this._containerTypeComboBox.SelectedIndexChanged += new System.EventHandler( this._containerTypeComboBox_SelectedIndexChanged );
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 7, 16 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 75, 13 );
			this.label2.TabIndex = 0;
			this.label2.Text = "Container type";
			// 
			// _entityCollectionConfigurationGroupBox
			// 
			this._entityCollectionConfigurationGroupBox.Controls.Add( this._entityCollectionComboBox );
			this._entityCollectionConfigurationGroupBox.Controls.Add( this.label4 );
			this._entityCollectionConfigurationGroupBox.Controls.Add( this.label5 );
			this._entityCollectionConfigurationGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._entityCollectionConfigurationGroupBox.Location = new System.Drawing.Point( 0, 0 );
			this._entityCollectionConfigurationGroupBox.Name = "_entityCollectionConfigurationGroupBox";
			this._entityCollectionConfigurationGroupBox.Size = new System.Drawing.Size( 534, 139 );
			this._entityCollectionConfigurationGroupBox.TabIndex = 1;
			this._entityCollectionConfigurationGroupBox.TabStop = false;
			this._entityCollectionConfigurationGroupBox.Text = "Entity collection setup";
			this._entityCollectionConfigurationGroupBox.Visible = false;
			// 
			// _entityCollectionComboBox
			// 
			this._entityCollectionComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._entityCollectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._entityCollectionComboBox.FormattingEnabled = true;
			this._entityCollectionComboBox.Location = new System.Drawing.Point( 172, 57 );
			this._entityCollectionComboBox.MaxDropDownItems = 15;
			this._entityCollectionComboBox.Name = "_entityCollectionComboBox";
			this._entityCollectionComboBox.Size = new System.Drawing.Size( 354, 21 );
			this._entityCollectionComboBox.Sorted = true;
			this._entityCollectionComboBox.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 7, 60 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 124, 13 );
			this.label4.TabIndex = 2;
			this.label4.Text = "Entity collection to select";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point( 7, 16 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 521, 32 );
			this.label5.TabIndex = 3;
			this.label5.Text = "Please select the entity collection to use.";
			// 
			// _typedViewConfigurationGroupBox
			// 
			this._typedViewConfigurationGroupBox.Controls.Add( this._typedViewTypeComboBox );
			this._typedViewConfigurationGroupBox.Controls.Add( this.label7 );
			this._typedViewConfigurationGroupBox.Controls.Add( this.label8 );
			this._typedViewConfigurationGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._typedViewConfigurationGroupBox.Location = new System.Drawing.Point( 0, 0 );
			this._typedViewConfigurationGroupBox.Name = "_typedViewConfigurationGroupBox";
			this._typedViewConfigurationGroupBox.Size = new System.Drawing.Size( 534, 139 );
			this._typedViewConfigurationGroupBox.TabIndex = 5;
			this._typedViewConfigurationGroupBox.TabStop = false;
			this._typedViewConfigurationGroupBox.Text = "TypedView setup";
			this._typedViewConfigurationGroupBox.Visible = false;
			// 
			// _typedViewTypeComboBox
			// 
			this._typedViewTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._typedViewTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._typedViewTypeComboBox.FormattingEnabled = true;
			this._typedViewTypeComboBox.Location = new System.Drawing.Point( 147, 60 );
			this._typedViewTypeComboBox.MaxDropDownItems = 15;
			this._typedViewTypeComboBox.Name = "_typedViewTypeComboBox";
			this._typedViewTypeComboBox.Size = new System.Drawing.Size( 381, 21 );
			this._typedViewTypeComboBox.Sorted = true;
			this._typedViewTypeComboBox.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label7.Location = new System.Drawing.Point( 7, 16 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 490, 32 );
			this.label7.TabIndex = 3;
			this.label7.Text = "Please select the TypedView type to use as the typed list for this data source co" +
				"ntrol.";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point( 7, 63 );
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size( 92, 13 );
			this.label8.TabIndex = 2;
			this.label8.Text = "TypedView to use";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point( 7, 16 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 519, 32 );
			this.label3.TabIndex = 3;
			this.label3.Text = "Please select the TypedList type to use as the typed list for this data source co" +
				"ntrol.";
			// 
			// _typedListConfigurationGroupBox
			// 
			this._typedListConfigurationGroupBox.Controls.Add( this._typedListTypeComboBox );
			this._typedListConfigurationGroupBox.Controls.Add( this.label3 );
			this._typedListConfigurationGroupBox.Controls.Add( this.label6 );
			this._typedListConfigurationGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this._typedListConfigurationGroupBox.Location = new System.Drawing.Point( 0, 0 );
			this._typedListConfigurationGroupBox.Name = "_typedListConfigurationGroupBox";
			this._typedListConfigurationGroupBox.Size = new System.Drawing.Size( 534, 139 );
			this._typedListConfigurationGroupBox.TabIndex = 5;
			this._typedListConfigurationGroupBox.TabStop = false;
			this._typedListConfigurationGroupBox.Text = "TypedList setup";
			this._typedListConfigurationGroupBox.Visible = false;
			// 
			// _typedListTypeComboBox
			// 
			this._typedListTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._typedListTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._typedListTypeComboBox.FormattingEnabled = true;
			this._typedListTypeComboBox.Location = new System.Drawing.Point( 147, 60 );
			this._typedListTypeComboBox.MaxDropDownItems = 15;
			this._typedListTypeComboBox.Name = "_typedListTypeComboBox";
			this._typedListTypeComboBox.Size = new System.Drawing.Size( 381, 21 );
			this._typedListTypeComboBox.Sorted = true;
			this._typedListTypeComboBox.TabIndex = 4;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 7, 63 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 85, 13 );
			this.label6.TabIndex = 2;
			this.label6.Text = "TypedList to use";
			// 
			// _okButton
			// 
			this._okButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this._okButton.Location = new System.Drawing.Point( 194, 200 );
			this._okButton.Name = "_okButton";
			this._okButton.Size = new System.Drawing.Size( 75, 23 );
			this._okButton.TabIndex = 2;
			this._okButton.Text = "OK";
			this._okButton.UseVisualStyleBackColor = true;
			this._okButton.Click += new System.EventHandler( this._okButton_Click );
			// 
			// _cancelButton
			// 
			this._cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._cancelButton.Location = new System.Drawing.Point( 275, 200 );
			this._cancelButton.Name = "_cancelButton";
			this._cancelButton.Size = new System.Drawing.Size( 75, 23 );
			this._cancelButton.TabIndex = 2;
			this._cancelButton.Text = "Cancel";
			this._cancelButton.UseVisualStyleBackColor = true;
			this._cancelButton.Click += new System.EventHandler( this._cancelButton_Click );
			// 
			// _configurationPanel
			// 
			this._configurationPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._configurationPanel.Controls.Add( this._entityCollectionConfigurationGroupBox );
			this._configurationPanel.Controls.Add( this._typedViewConfigurationGroupBox );
			this._configurationPanel.Controls.Add( this._typedListConfigurationGroupBox );
			this._configurationPanel.Location = new System.Drawing.Point( 6, 55 );
			this._configurationPanel.Name = "_configurationPanel";
			this._configurationPanel.Size = new System.Drawing.Size( 534, 139 );
			this._configurationPanel.TabIndex = 6;
			// 
			// DataSourceDesignerConfigurationForm
			// 
			this.AcceptButton = this._okButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._cancelButton;
			this.ClientSize = new System.Drawing.Size( 545, 233 );
			this.ControlBox = false;
			this.Controls.Add( this._configurationPanel );
			this.Controls.Add( this._cancelButton );
			this.Controls.Add( this._okButton );
			this.Controls.Add( this.groupBox1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "DataSourceDesignerConfigurationForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "LLBLGenProDataSource for SelfServicing Configuration";
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			this._entityCollectionConfigurationGroupBox.ResumeLayout( false );
			this._entityCollectionConfigurationGroupBox.PerformLayout();
			this._typedViewConfigurationGroupBox.ResumeLayout( false );
			this._typedViewConfigurationGroupBox.PerformLayout();
			this._typedListConfigurationGroupBox.ResumeLayout( false );
			this._typedListConfigurationGroupBox.PerformLayout();
			this._configurationPanel.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox _containerTypeComboBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox _entityCollectionConfigurationGroupBox;
		private System.Windows.Forms.Button _okButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.ComboBox _entityCollectionComboBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox _typedListConfigurationGroupBox;
		private System.Windows.Forms.ComboBox _typedListTypeComboBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox _typedViewConfigurationGroupBox;
		private System.Windows.Forms.ComboBox _typedViewTypeComboBox;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Panel _configurationPanel;
	}
}