namespace cypos
{
    partial class frmItemPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmItemPopup));
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.pnlItemList = new System.Windows.Forms.Panel();
            this.pnlFloPanel = new System.Windows.Forms.Panel();
            this.floItemList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblRows = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnKbSearch = new System.Windows.Forms.Button();
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSearchCategory = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.pnlItemList.SuspendLayout();
            this.pnlFloPanel.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlTitle.Size = new System.Drawing.Size(525, 38);
            this.pnlTitle.TabIndex = 163;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(490, 3);
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
            this.lblTitle.Size = new System.Drawing.Size(51, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Items";
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlInner);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(525, 562);
            this.pnlMain.TabIndex = 164;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.pnlItemList);
            this.pnlInner.Controls.Add(this.pnlSearch);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(5, 0);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Padding = new System.Windows.Forms.Padding(5);
            this.pnlInner.Size = new System.Drawing.Size(515, 557);
            this.pnlInner.TabIndex = 0;
            // 
            // pnlItemList
            // 
            this.pnlItemList.Controls.Add(this.pnlFloPanel);
            this.pnlItemList.Controls.Add(this.pnlTotal);
            this.pnlItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemList.Location = new System.Drawing.Point(5, 62);
            this.pnlItemList.Name = "pnlItemList";
            this.pnlItemList.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlItemList.Size = new System.Drawing.Size(505, 490);
            this.pnlItemList.TabIndex = 150;
            // 
            // pnlFloPanel
            // 
            this.pnlFloPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFloPanel.Controls.Add(this.floItemList);
            this.pnlFloPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFloPanel.Location = new System.Drawing.Point(0, 5);
            this.pnlFloPanel.Name = "pnlFloPanel";
            this.pnlFloPanel.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFloPanel.Size = new System.Drawing.Size(505, 463);
            this.pnlFloPanel.TabIndex = 7;
            // 
            // floItemList
            // 
            this.floItemList.AutoScroll = true;
            this.floItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floItemList.Location = new System.Drawing.Point(5, 5);
            this.floItemList.Name = "floItemList";
            this.floItemList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.floItemList.Size = new System.Drawing.Size(493, 451);
            this.floItemList.TabIndex = 5;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.lblRows);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotal.Location = new System.Drawing.Point(0, 468);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Padding = new System.Windows.Forms.Padding(1);
            this.pnlTotal.Size = new System.Drawing.Size(505, 22);
            this.pnlTotal.TabIndex = 6;
            // 
            // lblRows
            // 
            this.lblRows.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRows.Location = new System.Drawing.Point(156, 1);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(348, 20);
            this.lblRows.TabIndex = 160;
            this.lblRows.Text = "0";
            this.lblRows.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.btnKbSearch);
            this.pnlSearch.Controls.Add(this.txtSearchItem);
            this.pnlSearch.Controls.Add(this.label3);
            this.pnlSearch.Controls.Add(this.cmbSearchCategory);
            this.pnlSearch.Controls.Add(this.label24);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(5, 5);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(505, 57);
            this.pnlSearch.TabIndex = 149;
            // 
            // btnKbSearch
            // 
            this.btnKbSearch.FlatAppearance.BorderSize = 0;
            this.btnKbSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbSearch.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbSearch.Location = new System.Drawing.Point(216, 17);
            this.btnKbSearch.Name = "btnKbSearch";
            this.btnKbSearch.Size = new System.Drawing.Size(50, 35);
            this.btnKbSearch.TabIndex = 158;
            this.btnKbSearch.UseVisualStyleBackColor = true;
            this.btnKbSearch.Click += new System.EventHandler(this.btnKbSearch_Click);
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchItem.Location = new System.Drawing.Point(12, 22);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(200, 27);
            this.txtSearchItem.TabIndex = 147;
            this.txtSearchItem.TextChanged += new System.EventHandler(this.txtSearchItem_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 14);
            this.label3.TabIndex = 148;
            this.label3.Text = "Search Item:";
            // 
            // cmbSearchCategory
            // 
            this.cmbSearchCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSearchCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSearchCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchCategory.FormattingEnabled = true;
            this.cmbSearchCategory.Location = new System.Drawing.Point(270, 22);
            this.cmbSearchCategory.Name = "cmbSearchCategory";
            this.cmbSearchCategory.Size = new System.Drawing.Size(200, 24);
            this.cmbSearchCategory.TabIndex = 152;
            this.cmbSearchCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSearchCategory_SelectedIndexChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(267, 4);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(98, 14);
            this.label24.TabIndex = 151;
            this.label24.Text = "Select Category:";
            // 
            // frmItemPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(525, 600);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmItemPopup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items";
            this.Load += new System.EventHandler(this.frmItemPopup_Load);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlItemList.ResumeLayout(false);
            this.pnlFloPanel.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnKbSearch;
        private System.Windows.Forms.TextBox txtSearchItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSearchCategory;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel pnlItemList;
        private System.Windows.Forms.Panel pnlFloPanel;
        private System.Windows.Forms.FlowLayoutPanel floItemList;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Label lblRows;

    }
}