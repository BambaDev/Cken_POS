namespace cypos
{
    partial class frmCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCategory));
            this.lblCategoryId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlCategoryList = new System.Windows.Forms.Panel();
            this.pnlFloPanel = new System.Windows.Forms.Panel();
            this.floCategoryList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblRows = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearchCategory = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLeftInner = new System.Windows.Forms.Panel();
            this.btnKbSortOrder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSortOrder = new System.Windows.Forms.TextBox();
            this.crpForeColor = new cypos.ColorPicker();
            this.label5 = new System.Windows.Forms.Label();
            this.crpBackColor = new cypos.ColorPicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnKbCategory = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnKbSearch = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlCategoryList.SuspendLayout();
            this.pnlFloPanel.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftInner.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCategoryId
            // 
            this.lblCategoryId.AutoSize = true;
            this.lblCategoryId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblCategoryId.Location = new System.Drawing.Point(126, 76);
            this.lblCategoryId.Name = "lblCategoryId";
            this.lblCategoryId.Size = new System.Drawing.Size(8, 12);
            this.lblCategoryId.TabIndex = 1;
            this.lblCategoryId.Text = "-";
            this.lblCategoryId.Visible = false;
            this.lblCategoryId.TextChanged += new System.EventHandler(this.lblCategoryId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Category Name:";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoryName.Location = new System.Drawing.Point(22, 97);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(250, 23);
            this.txtCategoryName.TabIndex = 1;
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
            this.pnlMain.Size = new System.Drawing.Size(800, 512);
            this.pnlMain.TabIndex = 163;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlRight.Controls.Add(this.pnlCategoryList);
            this.pnlRight.Controls.Add(this.pnlSearch);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(356, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlRight.Size = new System.Drawing.Size(439, 507);
            this.pnlRight.TabIndex = 155;
            // 
            // pnlCategoryList
            // 
            this.pnlCategoryList.Controls.Add(this.pnlFloPanel);
            this.pnlCategoryList.Controls.Add(this.pnlTotal);
            this.pnlCategoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategoryList.Location = new System.Drawing.Point(6, 55);
            this.pnlCategoryList.Name = "pnlCategoryList";
            this.pnlCategoryList.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlCategoryList.Size = new System.Drawing.Size(427, 447);
            this.pnlCategoryList.TabIndex = 146;
            // 
            // pnlFloPanel
            // 
            this.pnlFloPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFloPanel.Controls.Add(this.floCategoryList);
            this.pnlFloPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFloPanel.Location = new System.Drawing.Point(0, 5);
            this.pnlFloPanel.Name = "pnlFloPanel";
            this.pnlFloPanel.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFloPanel.Size = new System.Drawing.Size(427, 418);
            this.pnlFloPanel.TabIndex = 7;
            // 
            // floCategoryList
            // 
            this.floCategoryList.AutoScroll = true;
            this.floCategoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floCategoryList.Location = new System.Drawing.Point(6, 5);
            this.floCategoryList.Name = "floCategoryList";
            this.floCategoryList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.floCategoryList.Size = new System.Drawing.Size(413, 406);
            this.floCategoryList.TabIndex = 5;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.lblRows);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotal.Location = new System.Drawing.Point(0, 423);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Padding = new System.Windows.Forms.Padding(1);
            this.pnlTotal.Size = new System.Drawing.Size(427, 24);
            this.pnlTotal.TabIndex = 6;
            // 
            // lblRows
            // 
            this.lblRows.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRows.Location = new System.Drawing.Point(20, 1);
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
            this.pnlSearch.Controls.Add(this.txtSearchCategory);
            this.pnlSearch.Controls.Add(this.label24);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(6, 5);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(427, 50);
            this.pnlSearch.TabIndex = 147;
            // 
            // txtSearchCategory
            // 
            this.txtSearchCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCategory.Location = new System.Drawing.Point(128, 13);
            this.txtSearchCategory.Name = "txtSearchCategory";
            this.txtSearchCategory.Size = new System.Drawing.Size(227, 23);
            this.txtSearchCategory.TabIndex = 152;
            this.txtSearchCategory.TextChanged += new System.EventHandler(this.txtSearchCategory_TextChanged);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(21, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(101, 14);
            this.label24.TabIndex = 151;
            this.label24.Text = "Search Category:";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlLeft.Controls.Add(this.pnlLeftInner);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(5, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlLeft.Size = new System.Drawing.Size(351, 507);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlLeftInner
            // 
            this.pnlLeftInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeftInner.Controls.Add(this.btnKbSortOrder);
            this.pnlLeftInner.Controls.Add(this.label2);
            this.pnlLeftInner.Controls.Add(this.txtSortOrder);
            this.pnlLeftInner.Controls.Add(this.crpForeColor);
            this.pnlLeftInner.Controls.Add(this.label5);
            this.pnlLeftInner.Controls.Add(this.crpBackColor);
            this.pnlLeftInner.Controls.Add(this.label3);
            this.pnlLeftInner.Controls.Add(this.btnSave);
            this.pnlLeftInner.Controls.Add(this.btnClear);
            this.pnlLeftInner.Controls.Add(this.btnExit);
            this.pnlLeftInner.Controls.Add(this.label1);
            this.pnlLeftInner.Controls.Add(this.btnDelete);
            this.pnlLeftInner.Controls.Add(this.lblCategoryId);
            this.pnlLeftInner.Controls.Add(this.btnKbCategory);
            this.pnlLeftInner.Controls.Add(this.txtCategoryName);
            this.pnlLeftInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftInner.Location = new System.Drawing.Point(6, 5);
            this.pnlLeftInner.Name = "pnlLeftInner";
            this.pnlLeftInner.Size = new System.Drawing.Size(339, 497);
            this.pnlLeftInner.TabIndex = 172;
            // 
            // btnKbSortOrder
            // 
            this.btnKbSortOrder.FlatAppearance.BorderSize = 0;
            this.btnKbSortOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbSortOrder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbSortOrder.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbSortOrder.Location = new System.Drawing.Point(128, 145);
            this.btnKbSortOrder.Name = "btnKbSortOrder";
            this.btnKbSortOrder.Size = new System.Drawing.Size(50, 35);
            this.btnKbSortOrder.TabIndex = 210;
            this.btnKbSortOrder.UseVisualStyleBackColor = true;
            this.btnKbSortOrder.Click += new System.EventHandler(this.btnKbSortOrder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 204;
            this.label2.Text = "Sort Order:";
            // 
            // txtSortOrder
            // 
            this.txtSortOrder.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSortOrder.Location = new System.Drawing.Point(22, 151);
            this.txtSortOrder.Name = "txtSortOrder";
            this.txtSortOrder.Size = new System.Drawing.Size(100, 23);
            this.txtSortOrder.TabIndex = 203;
            this.txtSortOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSortOrder_KeyPress);
            // 
            // crpForeColor
            // 
            this.crpForeColor.BoxHeight = 50;
            this.crpForeColor.BoxWidth = 50;
            this.crpForeColor.Location = new System.Drawing.Point(155, 214);
            this.crpForeColor.Name = "crpForeColor";
            this.crpForeColor.Size = new System.Drawing.Size(100, 40);
            this.crpForeColor.TabIndex = 202;
            this.crpForeColor.Text = "ForeColor";
            this.crpForeColor.Value = System.Drawing.Color.Black;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(155, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 201;
            this.label5.Text = "Fore Color:";
            // 
            // crpBackColor
            // 
            this.crpBackColor.BoxHeight = 50;
            this.crpBackColor.BoxWidth = 50;
            this.crpBackColor.Location = new System.Drawing.Point(21, 214);
            this.crpBackColor.Name = "crpBackColor";
            this.crpBackColor.Size = new System.Drawing.Size(100, 40);
            this.crpBackColor.TabIndex = 200;
            this.crpBackColor.Text = "BackColor";
            this.crpBackColor.Value = System.Drawing.Color.White;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 199;
            this.label3.Text = "Back Color:";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::cypos.Properties.Resources.save100x45;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(83, 363);
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
            this.btnClear.Location = new System.Drawing.Point(83, 415);
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
            this.btnExit.Location = new System.Drawing.Point(206, 415);
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
            this.btnDelete.Location = new System.Drawing.Point(206, 363);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 45);
            this.btnDelete.TabIndex = 182;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnKbCategory
            // 
            this.btnKbCategory.FlatAppearance.BorderSize = 0;
            this.btnKbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbCategory.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbCategory.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbCategory.Location = new System.Drawing.Point(278, 89);
            this.btnKbCategory.Name = "btnKbCategory";
            this.btnKbCategory.Size = new System.Drawing.Size(58, 38);
            this.btnKbCategory.TabIndex = 159;
            this.btnKbCategory.UseVisualStyleBackColor = true;
            this.btnKbCategory.Click += new System.EventHandler(this.btnKbCategory_Click);
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
            this.pnlTitle.Size = new System.Drawing.Size(800, 38);
            this.pnlTitle.TabIndex = 162;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(765, 3);
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
            this.lblTitle.Size = new System.Drawing.Size(76, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Category";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // btnKbSearch
            // 
            this.btnKbSearch.FlatAppearance.BorderSize = 0;
            this.btnKbSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbSearch.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbSearch.Location = new System.Drawing.Point(361, 4);
            this.btnKbSearch.Name = "btnKbSearch";
            this.btnKbSearch.Size = new System.Drawing.Size(58, 38);
            this.btnKbSearch.TabIndex = 160;
            this.btnKbSearch.UseVisualStyleBackColor = true;
            this.btnKbSearch.Click += new System.EventHandler(this.btnKbSearch_Click);
            // 
            // frmCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Category";
            this.Load += new System.EventHandler(this.frmCategory_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlCategoryList.ResumeLayout(false);
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

        private System.Windows.Forms.Label lblCategoryId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlCategoryList;
        private System.Windows.Forms.Panel pnlFloPanel;
        private System.Windows.Forms.FlowLayoutPanel floCategoryList;
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
        private System.Windows.Forms.Button btnKbCategory;
        private System.Windows.Forms.TextBox txtSearchCategory;
        private ColorPicker crpForeColor;
        private System.Windows.Forms.Label label5;
        private ColorPicker crpBackColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSortOrder;
        private System.Windows.Forms.Button btnKbSortOrder;
        private System.Windows.Forms.Button btnKbSearch;
    }
}