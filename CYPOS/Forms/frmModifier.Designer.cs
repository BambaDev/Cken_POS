namespace cypos
{
    partial class frmModifiers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmModifiers));
            this.lblModifierId = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModifierName = new System.Windows.Forms.TextBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlCategoryList = new System.Windows.Forms.Panel();
            this.pnlFloPanel = new System.Windows.Forms.Panel();
            this.floModifierList = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlTotal = new System.Windows.Forms.Panel();
            this.lblRows = new System.Windows.Forms.Label();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnKbSearch = new System.Windows.Forms.Button();
            this.txtSearchModifier = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlLeftInner = new System.Windows.Forms.Panel();
            this.btnKbSortOrder = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSortOrder = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnItem = new System.Windows.Forms.Button();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKbPrice = new System.Windows.Forms.Button();
            this.rdbPriceAdd = new System.Windows.Forms.RadioButton();
            this.rdbPriceDeduct = new System.Windows.Forms.RadioButton();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbKitchenYes = new System.Windows.Forms.RadioButton();
            this.rdbKitchenNo = new System.Windows.Forms.RadioButton();
            this.crpForeColor = new cypos.ColorPicker();
            this.label5 = new System.Windows.Forms.Label();
            this.crpBackColor = new cypos.ColorPicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnKbName = new System.Windows.Forms.Button();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlCategoryList.SuspendLayout();
            this.pnlFloPanel.SuspendLayout();
            this.pnlTotal.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlLeftInner.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModifierId
            // 
            this.lblModifierId.AutoSize = true;
            this.lblModifierId.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.25F);
            this.lblModifierId.Location = new System.Drawing.Point(111, 10);
            this.lblModifierId.Name = "lblModifierId";
            this.lblModifierId.Size = new System.Drawing.Size(8, 12);
            this.lblModifierId.TabIndex = 1;
            this.lblModifierId.Text = "-";
            this.lblModifierId.Visible = false;
            this.lblModifierId.TextChanged += new System.EventHandler(this.lblModifierId_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Modifier Name:";
            // 
            // txtModifierName
            // 
            this.txtModifierName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModifierName.Location = new System.Drawing.Point(12, 31);
            this.txtModifierName.Name = "txtModifierName";
            this.txtModifierName.Size = new System.Drawing.Size(262, 23);
            this.txtModifierName.TabIndex = 1;
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
            this.pnlRight.Location = new System.Drawing.Point(363, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(5);
            this.pnlRight.Size = new System.Drawing.Size(432, 507);
            this.pnlRight.TabIndex = 155;
            // 
            // pnlCategoryList
            // 
            this.pnlCategoryList.Controls.Add(this.pnlFloPanel);
            this.pnlCategoryList.Controls.Add(this.pnlTotal);
            this.pnlCategoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCategoryList.Location = new System.Drawing.Point(5, 58);
            this.pnlCategoryList.Name = "pnlCategoryList";
            this.pnlCategoryList.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.pnlCategoryList.Size = new System.Drawing.Size(422, 444);
            this.pnlCategoryList.TabIndex = 146;
            // 
            // pnlFloPanel
            // 
            this.pnlFloPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFloPanel.Controls.Add(this.floModifierList);
            this.pnlFloPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFloPanel.Location = new System.Drawing.Point(0, 5);
            this.pnlFloPanel.Name = "pnlFloPanel";
            this.pnlFloPanel.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlFloPanel.Size = new System.Drawing.Size(422, 415);
            this.pnlFloPanel.TabIndex = 7;
            // 
            // floModifierList
            // 
            this.floModifierList.AutoScroll = true;
            this.floModifierList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.floModifierList.Location = new System.Drawing.Point(6, 5);
            this.floModifierList.Name = "floModifierList";
            this.floModifierList.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.floModifierList.Size = new System.Drawing.Size(408, 403);
            this.floModifierList.TabIndex = 5;
            // 
            // pnlTotal
            // 
            this.pnlTotal.Controls.Add(this.lblRows);
            this.pnlTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTotal.Location = new System.Drawing.Point(0, 420);
            this.pnlTotal.Name = "pnlTotal";
            this.pnlTotal.Padding = new System.Windows.Forms.Padding(1);
            this.pnlTotal.Size = new System.Drawing.Size(422, 24);
            this.pnlTotal.TabIndex = 6;
            // 
            // lblRows
            // 
            this.lblRows.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblRows.Location = new System.Drawing.Point(15, 1);
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
            this.pnlSearch.Controls.Add(this.txtSearchModifier);
            this.pnlSearch.Controls.Add(this.label24);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(5, 5);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(422, 53);
            this.pnlSearch.TabIndex = 147;
            // 
            // btnKbSearch
            // 
            this.btnKbSearch.FlatAppearance.BorderSize = 0;
            this.btnKbSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbSearch.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbSearch.Location = new System.Drawing.Point(347, 7);
            this.btnKbSearch.Name = "btnKbSearch";
            this.btnKbSearch.Size = new System.Drawing.Size(58, 38);
            this.btnKbSearch.TabIndex = 160;
            this.btnKbSearch.UseVisualStyleBackColor = true;
            this.btnKbSearch.Click += new System.EventHandler(this.btnKbSearch_Click);
            // 
            // txtSearchModifier
            // 
            this.txtSearchModifier.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchModifier.Location = new System.Drawing.Point(105, 15);
            this.txtSearchModifier.Name = "txtSearchModifier";
            this.txtSearchModifier.Size = new System.Drawing.Size(234, 23);
            this.txtSearchModifier.TabIndex = 152;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(7, 19);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(94, 14);
            this.label24.TabIndex = 151;
            this.label24.Text = "Search Modifier:";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlLeft.Controls.Add(this.pnlLeftInner);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(5, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(5);
            this.pnlLeft.Size = new System.Drawing.Size(358, 507);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlLeftInner
            // 
            this.pnlLeftInner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeftInner.Controls.Add(this.btnKbSortOrder);
            this.pnlLeftInner.Controls.Add(this.label7);
            this.pnlLeftInner.Controls.Add(this.txtSortOrder);
            this.pnlLeftInner.Controls.Add(this.groupBox3);
            this.pnlLeftInner.Controls.Add(this.groupBox2);
            this.pnlLeftInner.Controls.Add(this.groupBox1);
            this.pnlLeftInner.Controls.Add(this.crpForeColor);
            this.pnlLeftInner.Controls.Add(this.label5);
            this.pnlLeftInner.Controls.Add(this.crpBackColor);
            this.pnlLeftInner.Controls.Add(this.label3);
            this.pnlLeftInner.Controls.Add(this.btnSave);
            this.pnlLeftInner.Controls.Add(this.btnClear);
            this.pnlLeftInner.Controls.Add(this.btnExit);
            this.pnlLeftInner.Controls.Add(this.label1);
            this.pnlLeftInner.Controls.Add(this.btnDelete);
            this.pnlLeftInner.Controls.Add(this.lblModifierId);
            this.pnlLeftInner.Controls.Add(this.btnKbName);
            this.pnlLeftInner.Controls.Add(this.txtModifierName);
            this.pnlLeftInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeftInner.Location = new System.Drawing.Point(5, 5);
            this.pnlLeftInner.Name = "pnlLeftInner";
            this.pnlLeftInner.Size = new System.Drawing.Size(348, 497);
            this.pnlLeftInner.TabIndex = 172;
            // 
            // btnKbSortOrder
            // 
            this.btnKbSortOrder.FlatAppearance.BorderSize = 0;
            this.btnKbSortOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbSortOrder.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbSortOrder.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbSortOrder.Location = new System.Drawing.Point(288, 328);
            this.btnKbSortOrder.Name = "btnKbSortOrder";
            this.btnKbSortOrder.Size = new System.Drawing.Size(50, 35);
            this.btnKbSortOrder.TabIndex = 215;
            this.btnKbSortOrder.UseVisualStyleBackColor = true;
            this.btnKbSortOrder.Click += new System.EventHandler(this.btnKbSortOrder_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(186, 313);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 208;
            this.label7.Text = "Sort Order:";
            // 
            // txtSortOrder
            // 
            this.txtSortOrder.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSortOrder.Location = new System.Drawing.Point(186, 334);
            this.txtSortOrder.Name = "txtSortOrder";
            this.txtSortOrder.Size = new System.Drawing.Size(100, 23);
            this.txtSortOrder.TabIndex = 207;
            this.txtSortOrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSortOrder_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnItem);
            this.groupBox3.Controls.Add(this.txtItemCode);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(13, 148);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 57);
            this.groupBox3.TabIndex = 203;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modifier of Item:";
            // 
            // btnItem
            // 
            this.btnItem.Location = new System.Drawing.Point(220, 14);
            this.btnItem.Name = "btnItem";
            this.btnItem.Size = new System.Drawing.Size(90, 36);
            this.btnItem.TabIndex = 201;
            this.btnItem.Text = "Select Item";
            this.btnItem.UseVisualStyleBackColor = true;
            this.btnItem.Click += new System.EventHandler(this.btnItem_Click);
            // 
            // txtItemCode
            // 
            this.txtItemCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItemCode.Location = new System.Drawing.Point(84, 21);
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(125, 23);
            this.txtItemCode.TabIndex = 196;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 200;
            this.label6.Text = "Item Code:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKbPrice);
            this.groupBox2.Controls.Add(this.rdbPriceAdd);
            this.groupBox2.Controls.Add(this.rdbPriceDeduct);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 72);
            this.groupBox2.TabIndex = 202;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price:";
            // 
            // btnKbPrice
            // 
            this.btnKbPrice.FlatAppearance.BorderSize = 0;
            this.btnKbPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbPrice.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbPrice.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbPrice.Location = new System.Drawing.Point(146, 19);
            this.btnKbPrice.Name = "btnKbPrice";
            this.btnKbPrice.Size = new System.Drawing.Size(50, 35);
            this.btnKbPrice.TabIndex = 214;
            this.btnKbPrice.UseVisualStyleBackColor = true;
            this.btnKbPrice.Click += new System.EventHandler(this.btnKbPrice_Click);
            // 
            // rdbPriceAdd
            // 
            this.rdbPriceAdd.AutoSize = true;
            this.rdbPriceAdd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPriceAdd.Location = new System.Drawing.Point(215, 14);
            this.rdbPriceAdd.Name = "rdbPriceAdd";
            this.rdbPriceAdd.Size = new System.Drawing.Size(85, 23);
            this.rdbPriceAdd.TabIndex = 194;
            this.rdbPriceAdd.TabStop = true;
            this.rdbPriceAdd.Text = "Add (+)";
            this.rdbPriceAdd.UseVisualStyleBackColor = true;
            // 
            // rdbPriceDeduct
            // 
            this.rdbPriceDeduct.AutoSize = true;
            this.rdbPriceDeduct.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPriceDeduct.Location = new System.Drawing.Point(215, 43);
            this.rdbPriceDeduct.Name = "rdbPriceDeduct";
            this.rdbPriceDeduct.Size = new System.Drawing.Size(99, 23);
            this.rdbPriceDeduct.TabIndex = 195;
            this.rdbPriceDeduct.TabStop = true;
            this.rdbPriceDeduct.Text = "Deduct (-)";
            this.rdbPriceDeduct.UseVisualStyleBackColor = true;
            // 
            // txtPrice
            // 
            this.txtPrice.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(16, 27);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(125, 23);
            this.txtPrice.TabIndex = 186;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbKitchenYes);
            this.groupBox1.Controls.Add(this.rdbKitchenNo);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(22, 298);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 59);
            this.groupBox1.TabIndex = 201;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print to Kitchen:";
            // 
            // rdbKitchenYes
            // 
            this.rdbKitchenYes.AutoSize = true;
            this.rdbKitchenYes.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbKitchenYes.Location = new System.Drawing.Point(11, 22);
            this.rdbKitchenYes.Name = "rdbKitchenYes";
            this.rdbKitchenYes.Size = new System.Drawing.Size(52, 23);
            this.rdbKitchenYes.TabIndex = 192;
            this.rdbKitchenYes.TabStop = true;
            this.rdbKitchenYes.Text = "Yes";
            this.rdbKitchenYes.UseVisualStyleBackColor = true;
            // 
            // rdbKitchenNo
            // 
            this.rdbKitchenNo.AutoSize = true;
            this.rdbKitchenNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbKitchenNo.Location = new System.Drawing.Point(97, 22);
            this.rdbKitchenNo.Name = "rdbKitchenNo";
            this.rdbKitchenNo.Size = new System.Drawing.Size(47, 23);
            this.rdbKitchenNo.TabIndex = 193;
            this.rdbKitchenNo.TabStop = true;
            this.rdbKitchenNo.Text = "No";
            this.rdbKitchenNo.UseVisualStyleBackColor = true;
            // 
            // crpForeColor
            // 
            this.crpForeColor.BoxHeight = 50;
            this.crpForeColor.BoxWidth = 50;
            this.crpForeColor.Location = new System.Drawing.Point(153, 243);
            this.crpForeColor.Name = "crpForeColor";
            this.crpForeColor.Size = new System.Drawing.Size(100, 40);
            this.crpForeColor.TabIndex = 198;
            this.crpForeColor.Text = "ForeColor";
            this.crpForeColor.Value = System.Drawing.Color.White;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(153, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 197;
            this.label5.Text = "Fore Color:";
            // 
            // crpBackColor
            // 
            this.crpBackColor.BoxHeight = 50;
            this.crpBackColor.BoxWidth = 50;
            this.crpBackColor.Location = new System.Drawing.Point(19, 243);
            this.crpBackColor.Name = "crpBackColor";
            this.crpBackColor.Size = new System.Drawing.Size(100, 40);
            this.crpBackColor.TabIndex = 196;
            this.crpBackColor.Text = "BackColor";
            this.crpBackColor.Value = System.Drawing.Color.White;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 190;
            this.label3.Text = "Back Color:";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::cypos.Properties.Resources.save100x45;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(83, 383);
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
            this.btnClear.Location = new System.Drawing.Point(83, 432);
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
            this.btnExit.Location = new System.Drawing.Point(206, 432);
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
            this.btnDelete.Location = new System.Drawing.Point(206, 383);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 45);
            this.btnDelete.TabIndex = 182;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnKbName
            // 
            this.btnKbName.FlatAppearance.BorderSize = 0;
            this.btnKbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbName.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbName.Location = new System.Drawing.Point(280, 23);
            this.btnKbName.Name = "btnKbName";
            this.btnKbName.Size = new System.Drawing.Size(58, 38);
            this.btnKbName.TabIndex = 159;
            this.btnKbName.UseVisualStyleBackColor = true;
            this.btnKbName.Click += new System.EventHandler(this.btnKbName_Click);
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
            this.lblTitle.Size = new System.Drawing.Size(79, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Modifiers";
            // 
            // frmModifiers
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
            this.Name = "frmModifiers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modifiers";
            this.Load += new System.EventHandler(this.frmModifier_Load);
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
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblModifierId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModifierName;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlCategoryList;
        private System.Windows.Forms.Panel pnlFloPanel;
        private System.Windows.Forms.FlowLayoutPanel floModifierList;
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
        private System.Windows.Forms.Button btnKbName;
        private System.Windows.Forms.TextBox txtSearchModifier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.RadioButton rdbKitchenNo;
        private System.Windows.Forms.RadioButton rdbKitchenYes;
        private System.Windows.Forms.RadioButton rdbPriceDeduct;
        private System.Windows.Forms.RadioButton rdbPriceAdd;
        private ColorPicker crpBackColor;
        private ColorPicker crpForeColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnKbSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSortOrder;
        private System.Windows.Forms.Button btnItem;
        private System.Windows.Forms.Button btnKbSortOrder;
        private System.Windows.Forms.Button btnKbPrice;
    }
}