namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	partial class EntityFactorySelector
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( EntityFactorySelector ) );
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this._factoriesComboBox = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this._selectButton = new System.Windows.Forms.Button();
			this._cancelButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add( this._factoriesComboBox );
			this.groupBox1.Controls.Add( this.label2 );
			this.groupBox1.Controls.Add( this.label1 );
			this.groupBox1.Location = new System.Drawing.Point( 3, 3 );
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size( 553, 93 );
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Entity Factories found";
			// 
			// _factoriesComboBox
			// 
			this._factoriesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._factoriesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._factoriesComboBox.FormattingEnabled = true;
			this._factoriesComboBox.Location = new System.Drawing.Point( 126, 62 );
			this._factoriesComboBox.MaxDropDownItems = 15;
			this._factoriesComboBox.Name = "_factoriesComboBox";
			this._factoriesComboBox.Size = new System.Drawing.Size( 419, 21 );
			this._factoriesComboBox.Sorted = true;
			this._factoriesComboBox.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point( 9, 16 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 536, 43 );
			this.label2.TabIndex = 0;
			this.label2.Text = "Please select the entity factory to use for the entity collection. This factory w" +
				"ill set the type of the entity contained inside the entity collection.";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 9, 65 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 111, 13 );
			this.label1.TabIndex = 0;
			this.label1.Text = "Entity factory to select";
			// 
			// _selectButton
			// 
			this._selectButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this._selectButton.Location = new System.Drawing.Point( 194, 102 );
			this._selectButton.Name = "_selectButton";
			this._selectButton.Size = new System.Drawing.Size( 75, 23 );
			this._selectButton.TabIndex = 1;
			this._selectButton.Text = "Select";
			this._selectButton.UseVisualStyleBackColor = true;
			this._selectButton.Click += new System.EventHandler( this._selectButton_Click );
			// 
			// _cancelButton
			// 
			this._cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._cancelButton.Location = new System.Drawing.Point( 292, 102 );
			this._cancelButton.Name = "_cancelButton";
			this._cancelButton.Size = new System.Drawing.Size( 75, 23 );
			this._cancelButton.TabIndex = 1;
			this._cancelButton.Text = "Cancel";
			this._cancelButton.UseVisualStyleBackColor = true;
			this._cancelButton.Click += new System.EventHandler( this._cancelButton_Click );
			// 
			// EntityFactorySelector
			// 
			this.AcceptButton = this._selectButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this._cancelButton;
			this.ClientSize = new System.Drawing.Size( 560, 137 );
			this.ControlBox = false;
			this.Controls.Add( this._cancelButton );
			this.Controls.Add( this._selectButton );
			this.Controls.Add( this.groupBox1 );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject( "$this.Icon" )));
			this.MaximizeBox = false;
			this.Name = "EntityFactorySelector";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Select Entity Factory To Use";
			this.groupBox1.ResumeLayout( false );
			this.groupBox1.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox _factoriesComboBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button _selectButton;
		private System.Windows.Forms.Button _cancelButton;
		private System.Windows.Forms.Label label2;
	}
}