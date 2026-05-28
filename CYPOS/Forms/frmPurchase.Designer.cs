namespace cypos
{
    partial class frmPurchase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPurchase));
            this.label4 = new System.Windows.Forms.Label();
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.cmbSearchCategory = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pnlItemList = new System.Windows.Forms.Panel();
            this.pnlFloPanel = new System.Windows.Forms.Panel();
            this.floItemList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblRows = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnKbSearch = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLeftInner = new System.Windows.Forms.Panel();
            this.btnKbRef = new System.Windows.Forms.Button();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblReOrderLevel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblItemCode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.btnKbPrice = new System.Windows.Forms.Button();
            this.lblItemId = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRefNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblCurrentStock = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblSellingPrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.btnKbQty = new System.Windows.Forms.Button();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlItemList.SuspendLayout();
            this.pnlFloPanel.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftInner.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 33;
            this.label4.Text = "Supplier:";
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
            // cmbSearchCategory
            // 
            this.cmbSearchCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSearchCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSearchCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSearchCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSearchCategory.FormattingEnabled = true;
            this.cmbSearchCategory.Location = new System.Drawing.Point(270, 22);
            this.cmbSearchCategory.Name = "cmbSearchCategory";
            this.cmbSearchCategory.Size = new System.Drawing.Size(200, 24);
            this.cmbSearchCategory.TabIndex = 152;
            this.cmbSearchCategory.SelectedIndexChanged += new System.EventHandler(this.cmbSearchCategory_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pnlItemList
            // 
            this.pnlItemList.Controls.Add(this.pnlFloPanel);
            this.pnlItemList.Controls.Add(this.pnlTotal);
            this.pnlItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlItemList.Location = new System.Drawing.Point(5, 63);
            this.pnlItemList.Name = "pnlItemList";
            this.pnlItemList.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlItemList.Size = new System.Drawing.Size(503, 389);
            this.pnlItemList.TabIndex = 146;
            // 
            // pnlFloPanel
            // 
            this.pnlFloPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFloPanel.Controls.Add(this.floItemList);
            this.pnlFloPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFloPanel.Location = new System.Drawing.Point(0, 5);
            this.pnlFloPanel.Name = "pnlFloPanel";
            this.pnlFloPanel.Padding = new System.Windows.Forms.Padding(5);
            this.pnlFloPanel.Size = new System.Drawing.Size(503, 362);
            this.pnlFloPanel.TabIndex = 7;
            // 
            // floItemList
            // 
            this.floItemList.AutoScroll = true;
            this.floItemList.BackColor = System.Drawing.Color.Transparent;
            this.floItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floItemList.Location = new System.Drawing.Point(5, 5);
            this.floItemList.Name = "floItemList";
            this.floItemList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.floItemList.Size = new System.Drawing.Size(491, 350);
            this.floItemList.TabIndex = 5;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.lblRows);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotal.Location = new System.Drawing.Point(0, 367);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Padding = new System.Windows.Forms.Padding(1);
            this.pnlTotal.Size = new System.Drawing.Size(503, 22);
            this.pnlTotal.TabIndex = 6;
            // 
            // lblRows
            // 
            this.lblRows.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRows.Location = new System.Drawing.Point(154, 1);
            this.lblRows.Name = "lblRows";
            this.lblRows.Size = new System.Drawing.Size(348, 20);
            this.lblRows.TabIndex = 160;
            this.lblRows.Text = "0";
            this.lblRows.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(267, 4);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(101, 14);
            this.label24.TabIndex = 151;
            this.label24.Text = "Search Category:";
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlRight.Controls.Add(this.pnlItemList);
            this.pnlRight.Controls.Add(this.pnlSearch);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRight.Location = new System.Drawing.Point(5, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(5);
            this.pnlRight.Size = new System.Drawing.Size(513, 457);
            this.pnlRight.TabIndex = 155;
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
            this.pnlSearch.Size = new System.Drawing.Size(503, 58);
            this.pnlSearch.TabIndex = 147;
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
            this.btnKbSearch.Click += new System.EventHandler(this.btnKbSearchProduct_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(900, 462);
            this.pnlMain.TabIndex = 158;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlLeft.Controls.Add(this.pnlLeftInner);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(518, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(5, 5, 0, 5);
            this.pnlLeft.Size = new System.Drawing.Size(377, 457);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlLeftInner
            // 
            this.pnlLeftInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeftInner.Controls.Add(this.btnKbRef);
            this.pnlLeftInner.Controls.Add(this.lblAmount);
            this.pnlLeftInner.Controls.Add(this.label9);
            this.pnlLeftInner.Controls.Add(this.lblReOrderLevel);
            this.pnlLeftInner.Controls.Add(this.label7);
            this.pnlLeftInner.Controls.Add(this.lblItemCode);
            this.pnlLeftInner.Controls.Add(this.label1);
            this.pnlLeftInner.Controls.Add(this.txtPrice);
            this.pnlLeftInner.Controls.Add(this.btnKbPrice);
            this.pnlLeftInner.Controls.Add(this.lblItemId);
            this.pnlLeftInner.Controls.Add(this.dtpDate);
            this.pnlLeftInner.Controls.Add(this.label12);
            this.pnlLeftInner.Controls.Add(this.label10);
            this.pnlLeftInner.Controls.Add(this.txtRefNo);
            this.pnlLeftInner.Controls.Add(this.label8);
            this.pnlLeftInner.Controls.Add(this.txtQty);
            this.pnlLeftInner.Controls.Add(this.lblCurrentStock);
            this.pnlLeftInner.Controls.Add(this.label11);
            this.pnlLeftInner.Controls.Add(this.lblItemName);
            this.pnlLeftInner.Controls.Add(this.lblSellingPrice);
            this.pnlLeftInner.Controls.Add(this.label6);
            this.pnlLeftInner.Controls.Add(this.lblCostPrice);
            this.pnlLeftInner.Controls.Add(this.btnKbQty);
            this.pnlLeftInner.Controls.Add(this.cmbSupplier);
            this.pnlLeftInner.Controls.Add(this.label5);
            this.pnlLeftInner.Controls.Add(this.btnSave);
            this.pnlLeftInner.Controls.Add(this.btnClear);
            this.pnlLeftInner.Controls.Add(this.btnExit);
            this.pnlLeftInner.Controls.Add(this.label4);
            this.pnlLeftInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftInner.Location = new System.Drawing.Point(5, 5);
            this.pnlLeftInner.Name = "pnlLeftInner";
            this.pnlLeftInner.Size = new System.Drawing.Size(372, 447);
            this.pnlLeftInner.TabIndex = 172;
            // 
            // btnKbRef
            // 
            this.btnKbRef.FlatAppearance.BorderSize = 0;
            this.btnKbRef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbRef.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbRef.Image = ((System.Drawing.Image)(resources.GetObject("btnKbRef.Image")));
            this.btnKbRef.Location = new System.Drawing.Point(277, 161);
            this.btnKbRef.Name = "btnKbRef";
            this.btnKbRef.Size = new System.Drawing.Size(50, 35);
            this.btnKbRef.TabIndex = 232;
            this.btnKbRef.UseVisualStyleBackColor = true;
            this.btnKbRef.Click += new System.EventHandler(this.btnKbRef_Click);
            // 
            // lblAmount
            // 
            this.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAmount.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(225, 321);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(125, 24);
            this.lblAmount.TabIndex = 231;
            this.lblAmount.Text = "0";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(225, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 16);
            this.label9.TabIndex = 230;
            this.label9.Text = "Amount:";
            // 
            // lblReOrderLevel
            // 
            this.lblReOrderLevel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReOrderLevel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReOrderLevel.Location = new System.Drawing.Point(14, 116);
            this.lblReOrderLevel.Name = "lblReOrderLevel";
            this.lblReOrderLevel.Size = new System.Drawing.Size(125, 24);
            this.lblReOrderLevel.TabIndex = 229;
            this.lblReOrderLevel.Text = "0";
            this.lblReOrderLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.TabIndex = 228;
            this.label7.Text = "Re-Order Level";
            // 
            // lblItemCode
            // 
            this.lblItemCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemCode.Location = new System.Drawing.Point(14, 11);
            this.lblItemCode.Name = "lblItemCode";
            this.lblItemCode.Size = new System.Drawing.Size(125, 24);
            this.lblItemCode.TabIndex = 227;
            this.lblItemCode.Text = "Item Code";
            this.lblItemCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItemCode.TextChanged += new System.EventHandler(this.lblItemCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 299);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 226;
            this.label1.Text = "Price:";
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(14, 321);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 225;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // btnKbPrice
            // 
            this.btnKbPrice.FlatAppearance.BorderSize = 0;
            this.btnKbPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbPrice.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbPrice.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbPrice.Location = new System.Drawing.Point(119, 314);
            this.btnKbPrice.Name = "btnKbPrice";
            this.btnKbPrice.Size = new System.Drawing.Size(50, 35);
            this.btnKbPrice.TabIndex = 224;
            this.btnKbPrice.UseVisualStyleBackColor = true;
            this.btnKbPrice.Click += new System.EventHandler(this.btnKbPrice_Click);
            // 
            // lblItemId
            // 
            this.lblItemId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemId.Location = new System.Drawing.Point(277, 63);
            this.lblItemId.Name = "lblItemId";
            this.lblItemId.Size = new System.Drawing.Size(76, 24);
            this.lblItemId.TabIndex = 223;
            this.lblItemId.Text = "0";
            this.lblItemId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(14, 166);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(125, 23);
            this.dtpDate.TabIndex = 222;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(95, 16);
            this.label12.TabIndex = 221;
            this.label12.Text = "Purchase Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(143, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 16);
            this.label10.TabIndex = 219;
            this.label10.Text = "Reference No:";
            // 
            // txtRefNo
            // 
            this.txtRefNo.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNo.Location = new System.Drawing.Point(143, 167);
            this.txtRefNo.Name = "txtRefNo";
            this.txtRefNo.Size = new System.Drawing.Size(126, 23);
            this.txtRefNo.TabIndex = 218;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 217;
            this.label8.Text = "Qty:";
            // 
            // txtQty
            // 
            this.txtQty.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.Location = new System.Drawing.Point(14, 267);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(100, 23);
            this.txtQty.TabIndex = 216;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQty_KeyPress);
            // 
            // lblCurrentStock
            // 
            this.lblCurrentStock.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentStock.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentStock.ForeColor = System.Drawing.Color.Green;
            this.lblCurrentStock.Location = new System.Drawing.Point(146, 116);
            this.lblCurrentStock.Name = "lblCurrentStock";
            this.lblCurrentStock.Size = new System.Drawing.Size(125, 24);
            this.lblCurrentStock.TabIndex = 215;
            this.lblCurrentStock.Text = "0";
            this.lblCurrentStock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(146, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 16);
            this.label11.TabIndex = 214;
            this.label11.Text = "Current Stock:";
            // 
            // lblItemName
            // 
            this.lblItemName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblItemName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemName.Location = new System.Drawing.Point(146, 11);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(207, 24);
            this.lblItemName.TabIndex = 213;
            this.lblItemName.Text = "Selected Item";
            this.lblItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSellingPrice
            // 
            this.lblSellingPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSellingPrice.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSellingPrice.Location = new System.Drawing.Point(146, 63);
            this.lblSellingPrice.Name = "lblSellingPrice";
            this.lblSellingPrice.Size = new System.Drawing.Size(125, 24);
            this.lblSellingPrice.TabIndex = 212;
            this.lblSellingPrice.Text = "0.00";
            this.lblSellingPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(146, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 16);
            this.label6.TabIndex = 211;
            this.label6.Text = "Selling Price:";
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCostPrice.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostPrice.Location = new System.Drawing.Point(14, 63);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(125, 24);
            this.lblCostPrice.TabIndex = 210;
            this.lblCostPrice.Text = "0.00";
            this.lblCostPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnKbQty
            // 
            this.btnKbQty.FlatAppearance.BorderSize = 0;
            this.btnKbQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbQty.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbQty.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbQty.Location = new System.Drawing.Point(119, 260);
            this.btnKbQty.Name = "btnKbQty";
            this.btnKbQty.Size = new System.Drawing.Size(50, 35);
            this.btnKbQty.TabIndex = 209;
            this.btnKbQty.UseVisualStyleBackColor = true;
            this.btnKbQty.Click += new System.EventHandler(this.btnKbQty_Click);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(14, 215);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(336, 24);
            this.cmbSupplier.TabIndex = 193;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 190;
            this.label5.Text = "Cost Price:";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::cypos.Properties.Resources.save100x45;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(148, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 45);
            this.btnSave.TabIndex = 185;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::cypos.Properties.Resources.clear100x45;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(46, 374);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 45);
            this.btnClear.TabIndex = 184;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::cypos.Properties.Resources.exit100x45;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(250, 374);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 45);
            this.btnExit.TabIndex = 183;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.pnlTitle.Size = new System.Drawing.Size(900, 38);
            this.pnlTitle.TabIndex = 159;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(865, 3);
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
            this.lblTitle.Location = new System.Drawing.Point(10, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(77, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Purchase";
            // 
            // frmPurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPurchase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Purchase";
            this.Load += new System.EventHandler(this.frmItem_Load);
            this.pnlItemList.ResumeLayout(false);
            this.pnlFloPanel.ResumeLayout(false);
            this.pnlTotal.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeftInner.ResumeLayout(false);
            this.pnlLeftInner.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel pnlItemList;
        private System.Windows.Forms.FlowLayoutPanel floItemList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchItem;
        private System.Windows.Forms.ComboBox cmbSearchCategory;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnKbSearch;
        private System.Windows.Forms.Label lblRows;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTotal;
        private System.Windows.Forms.Panel pnlFloPanel;
        private System.Windows.Forms.Panel pnlLeftInner;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Button btnKbQty;
        private System.Windows.Forms.Label lblCurrentStock;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.Label lblSellingPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCostPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRefNo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblItemId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Button btnKbPrice;
        private System.Windows.Forms.Label lblItemCode;
        private System.Windows.Forms.Label lblReOrderLevel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnKbRef;
    }
}