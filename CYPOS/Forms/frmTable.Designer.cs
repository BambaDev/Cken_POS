namespace cypos
{
    partial class frmTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTable));
            this.lblTableId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlTableList = new System.Windows.Forms.Panel();
            this.pnlFloPanel = new System.Windows.Forms.Panel();
            this.floTableList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblRows = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnKbSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLeftInner = new System.Windows.Forms.Panel();
            this.btnKbNoOfCharge = new System.Windows.Forms.Button();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoOfChairs = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnKbTable = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlTableList.SuspendLayout();
            this.pnlFloPanel.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftInner.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTableId
            // 
            this.lblTableId.AutoSize = true;
            this.lblTableId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblTableId.Location = new System.Drawing.Point(126, 76);
            this.lblTableId.Name = "lblTableId";
            this.lblTableId.Size = new System.Drawing.Size(8, 12);
            this.lblTableId.TabIndex = 1;
            this.lblTableId.Text = "-";
            this.lblTableId.Visible = false;
            this.lblTableId.TextChanged += new System.EventHandler(this.lblTableId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Table Name:";
            // 
            // txtTableName
            // 
            this.txtTableName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTableName.Location = new System.Drawing.Point(22, 97);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(250, 23);
            this.txtTableName.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(725, 412);
            this.pnlMain.TabIndex = 163;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlRight.Controls.Add(this.pnlTableList);
            this.pnlRight.Controls.Add(this.pnlSearch);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(356, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlRight.Size = new System.Drawing.Size(364, 407);
            this.pnlRight.TabIndex = 155;
            // 
            // pnlTableList
            // 
            this.pnlTableList.Controls.Add(this.pnlFloPanel);
            this.pnlTableList.Controls.Add(this.pnlTotal);
            this.pnlTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableList.Location = new System.Drawing.Point(6, 55);
            this.pnlTableList.Name = "pnlTableList";
            this.pnlTableList.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlTableList.Size = new System.Drawing.Size(352, 347);
            this.pnlTableList.TabIndex = 146;
            // 
            // pnlFloPanel
            // 
            this.pnlFloPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFloPanel.Controls.Add(this.floTableList);
            this.pnlFloPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFloPanel.Location = new System.Drawing.Point(0, 5);
            this.pnlFloPanel.Name = "pnlFloPanel";
            this.pnlFloPanel.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFloPanel.Size = new System.Drawing.Size(352, 318);
            this.pnlFloPanel.TabIndex = 7;
            // 
            // floTableList
            // 
            this.floTableList.AutoScroll = true;
            this.floTableList.BackColor = System.Drawing.Color.Transparent;
            this.floTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floTableList.Location = new System.Drawing.Point(6, 5);
            this.floTableList.Name = "floTableList";
            this.floTableList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.floTableList.Size = new System.Drawing.Size(338, 306);
            this.floTableList.TabIndex = 5;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.lblRows);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotal.Location = new System.Drawing.Point(0, 323);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Padding = new System.Windows.Forms.Padding(1);
            this.pnlTotal.Size = new System.Drawing.Size(352, 24);
            this.pnlTotal.TabIndex = 6;
            // 
            // lblRows
            // 
            this.lblRows.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRows.Location = new System.Drawing.Point(-55, 1);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(406, 22);
            this.lblRows.TabIndex = 160;
            this.lblRows.Text = "0";
            this.lblRows.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.btnKbSearch);
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.label24);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(6, 5);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(352, 50);
            this.pnlSearch.TabIndex = 147;
            // 
            // btnKbSearch
            // 
            this.btnKbSearch.FlatAppearance.BorderSize = 0;
            this.btnKbSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbSearch.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbSearch.Location = new System.Drawing.Point(274, 4);
            this.btnKbSearch.Name = "btnKbSearch";
            this.btnKbSearch.Size = new System.Drawing.Size(58, 38);
            this.btnKbSearch.TabIndex = 160;
            this.btnKbSearch.UseVisualStyleBackColor = true;
            this.btnKbSearch.Click += new System.EventHandler(this.btnKbSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(93, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(175, 23);
            this.txtSearch.TabIndex = 152;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(7, 16);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(82, 14);
            this.label24.TabIndex = 151;
            this.label24.Text = "Search Table:";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlLeft.Controls.Add(this.pnlLeftInner);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(5, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlLeft.Size = new System.Drawing.Size(351, 407);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlLeftInner
            // 
            this.pnlLeftInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeftInner.Controls.Add(this.btnKbNoOfCharge);
            this.pnlLeftInner.Controls.Add(this.cmbLocation);
            this.pnlLeftInner.Controls.Add(this.label4);
            this.pnlLeftInner.Controls.Add(this.label2);
            this.pnlLeftInner.Controls.Add(this.txtNoOfChairs);
            this.pnlLeftInner.Controls.Add(this.btnSave);
            this.pnlLeftInner.Controls.Add(this.btnClear);
            this.pnlLeftInner.Controls.Add(this.btnExit);
            this.pnlLeftInner.Controls.Add(this.label1);
            this.pnlLeftInner.Controls.Add(this.btnDelete);
            this.pnlLeftInner.Controls.Add(this.lblTableId);
            this.pnlLeftInner.Controls.Add(this.btnKbTable);
            this.pnlLeftInner.Controls.Add(this.txtTableName);
            this.pnlLeftInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftInner.Location = new System.Drawing.Point(6, 5);
            this.pnlLeftInner.Name = "pnlLeftInner";
            this.pnlLeftInner.Size = new System.Drawing.Size(339, 397);
            this.pnlLeftInner.TabIndex = 172;
            // 
            // btnKbNoOfCharge
            // 
            this.btnKbNoOfCharge.FlatAppearance.BorderSize = 0;
            this.btnKbNoOfCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbNoOfCharge.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbNoOfCharge.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbNoOfCharge.Location = new System.Drawing.Point(128, 145);
            this.btnKbNoOfCharge.Name = "btnKbNoOfCharge";
            this.btnKbNoOfCharge.Size = new System.Drawing.Size(50, 35);
            this.btnKbNoOfCharge.TabIndex = 210;
            this.btnKbNoOfCharge.UseVisualStyleBackColor = true;
            this.btnKbNoOfCharge.Click += new System.EventHandler(this.btnKbNoOfCharge_Click);
            // 
            // cmbLocation
            // 
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(22, 202);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(250, 24);
            this.cmbLocation.TabIndex = 206;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 205;
            this.label4.Text = "Location:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 204;
            this.label2.Text = "No of Chairs:";
            // 
            // txtNoOfChairs
            // 
            this.txtNoOfChairs.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfChairs.Location = new System.Drawing.Point(22, 151);
            this.txtNoOfChairs.Name = "txtNoOfChairs";
            this.txtNoOfChairs.Size = new System.Drawing.Size(100, 23);
            this.txtNoOfChairs.TabIndex = 203;
            this.txtNoOfChairs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoOfChairs_KeyPress);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::cypos.Properties.Resources.save100x45;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(81, 286);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 45);
            this.btnSave.TabIndex = 185;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::cypos.Properties.Resources.clear100x45;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(81, 338);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 45);
            this.btnClear.TabIndex = 184;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::cypos.Properties.Resources.exit100x45;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(204, 338);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 45);
            this.btnExit.TabIndex = 183;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::cypos.Properties.Resources.delete100x45;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(204, 286);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 45);
            this.btnDelete.TabIndex = 182;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnKbTable
            // 
            this.btnKbTable.FlatAppearance.BorderSize = 0;
            this.btnKbTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbTable.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbTable.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbTable.Location = new System.Drawing.Point(278, 89);
            this.btnKbTable.Name = "btnKbTable";
            this.btnKbTable.Size = new System.Drawing.Size(58, 38);
            this.btnKbTable.TabIndex = 159;
            this.btnKbTable.UseVisualStyleBackColor = true;
            this.btnKbTable.Click += new System.EventHandler(this.btnKbTable_Click);
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackgroundImage = global::cypos.Properties.Resources.title_bg;
            this.pnlTitle.Controls.Add(this.pbxClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Padding = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.pnlTitle.Size = new System.Drawing.Size(725, 38);
            this.pnlTitle.TabIndex = 162;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(690, 3);
            this.pbxClose.Name = "pbxClose";
            this.pbxClose.Size = new System.Drawing.Size(32, 32);
            this.pbxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxClose.TabIndex = 9;
            this.pbxClose.TabStop = false;
            this.pbxClose.Click += new System.EventHandler(this.pbxClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(12, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(49, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Table";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // frmTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 450);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Table";
            this.Load += new System.EventHandler(this.frmTable_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlTableList.ResumeLayout(false);
            this.pnlFloPanel.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeftInner.ResumeLayout(false);
            this.pnlLeftInner.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTableId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlTableList;
        private System.Windows.Forms.Panel pnlFloPanel;
        private System.Windows.Forms.FlowLayoutPanel floTableList;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlLeftInner;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnKbTable;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNoOfChairs;
        private System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKbSearch;
        private System.Windows.Forms.Button btnKbNoOfCharge;
    }
}