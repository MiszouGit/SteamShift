namespace SteamShift
{
	partial class Form1
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
			if ( disposing && ( components != null ) )
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.cboLeft = new System.Windows.Forms.ComboBox();
			this.cboRight = new System.Windows.Forms.ComboBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.labelFreeSpaceLeft = new System.Windows.Forms.Label();
			this.listLeft = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.btnMove = new System.Windows.Forms.Button();
			this.labelFreeSpaceRight = new System.Windows.Forms.Label();
			this.listRight = new System.Windows.Forms.ListView();
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cboLeft
			// 
			this.cboLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboLeft.FormattingEnabled = true;
			this.cboLeft.Location = new System.Drawing.Point(12, 12);
			this.cboLeft.Name = "cboLeft";
			this.cboLeft.Size = new System.Drawing.Size(317, 21);
			this.cboLeft.TabIndex = 0;
			// 
			// cboRight
			// 
			this.cboRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboRight.FormattingEnabled = true;
			this.cboRight.Location = new System.Drawing.Point(14, 12);
			this.cboRight.Name = "cboRight";
			this.cboRight.Size = new System.Drawing.Size(321, 21);
			this.cboRight.TabIndex = 1;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.labelFreeSpaceLeft);
			this.splitContainer1.Panel1.Controls.Add(this.listLeft);
			this.splitContainer1.Panel1.Controls.Add(this.cboLeft);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(747, 406);
			this.splitContainer1.SplitterDistance = 343;
			this.splitContainer1.TabIndex = 4;
			// 
			// labelFreeSpaceLeft
			// 
			this.labelFreeSpaceLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFreeSpaceLeft.Location = new System.Drawing.Point(12, 378);
			this.labelFreeSpaceLeft.Name = "labelFreeSpaceLeft";
			this.labelFreeSpaceLeft.Size = new System.Drawing.Size(317, 19);
			this.labelFreeSpaceLeft.TabIndex = 2;
			this.labelFreeSpaceLeft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// listLeft
			// 
			this.listLeft.AllowDrop = true;
			this.listLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listLeft.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listLeft.FullRowSelect = true;
			this.listLeft.HideSelection = false;
			this.listLeft.Location = new System.Drawing.Point(12, 39);
			this.listLeft.Name = "listLeft";
			this.listLeft.Size = new System.Drawing.Size(317, 336);
			this.listLeft.TabIndex = 1;
			this.listLeft.UseCompatibleStateImageBehavior = false;
			this.listLeft.View = System.Windows.Forms.View.Details;
			this.listLeft.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listLeft_ItemSelectionChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Application";
			this.columnHeader1.Width = 150;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Size on Disk (Gb)";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader2.Width = 100;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.btnMove);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.labelFreeSpaceRight);
			this.splitContainer2.Panel2.Controls.Add(this.cboRight);
			this.splitContainer2.Panel2.Controls.Add(this.listRight);
			this.splitContainer2.Size = new System.Drawing.Size(400, 406);
			this.splitContainer2.SplitterDistance = 47;
			this.splitContainer2.TabIndex = 0;
			// 
			// btnMove
			// 
			this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMove.Enabled = false;
			this.btnMove.Location = new System.Drawing.Point(3, 12);
			this.btnMove.Name = "btnMove";
			this.btnMove.Size = new System.Drawing.Size(41, 23);
			this.btnMove.TabIndex = 5;
			this.btnMove.Text = "-->";
			this.btnMove.UseVisualStyleBackColor = true;
			this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
			// 
			// labelFreeSpaceRight
			// 
			this.labelFreeSpaceRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelFreeSpaceRight.Location = new System.Drawing.Point(14, 378);
			this.labelFreeSpaceRight.Name = "labelFreeSpaceRight";
			this.labelFreeSpaceRight.Size = new System.Drawing.Size(321, 19);
			this.labelFreeSpaceRight.TabIndex = 3;
			this.labelFreeSpaceRight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// listRight
			// 
			this.listRight.AllowDrop = true;
			this.listRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
			this.listRight.FullRowSelect = true;
			this.listRight.HideSelection = false;
			this.listRight.Location = new System.Drawing.Point(14, 39);
			this.listRight.Name = "listRight";
			this.listRight.Size = new System.Drawing.Size(321, 336);
			this.listRight.TabIndex = 2;
			this.listRight.UseCompatibleStateImageBehavior = false;
			this.listRight.View = System.Windows.Forms.View.Details;
			this.listRight.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listRight_ItemSelectionChanged);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Application";
			this.columnHeader3.Width = 150;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Size on Disk (Gb)";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader4.Width = 100;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(747, 406);
			this.Controls.Add(this.splitContainer1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Steam Library Manager";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cboLeft;
		private System.Windows.Forms.ComboBox cboRight;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListView listLeft;
		private System.Windows.Forms.ListView listRight;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label labelFreeSpaceLeft;
		private System.Windows.Forms.Label labelFreeSpaceRight;
		private System.Windows.Forms.Button btnMove;
		private System.Windows.Forms.SplitContainer splitContainer2;
	}
}

