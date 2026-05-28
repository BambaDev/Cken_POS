namespace cypos
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.txtInvoiceDeleteDays = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnKbKotStart = new System.Windows.Forms.Button();
            this.btnKbKotZeros = new System.Windows.Forms.Button();
            this.btnKbKotPrefix = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtKotStartingNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtKotZeroCount = new System.Windows.Forms.TextBox();
            this.cbxKotLeadingZeros = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtKotPrefix = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbOrderType = new System.Windows.Forms.ComboBox();
            this.cbxShowOtAfterBill = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnKbInDeleteDays = new System.Windows.Forms.Button();
            this.btnKbDiscRate = new System.Windows.Forms.Button();
            this.btnKbPageItems = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbxShowLogo = new System.Windows.Forms.CheckBox();
            this.cbxPreviewB4Print = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnKbScRate = new System.Windows.Forms.Button();
            this.cbxEnableServiceCharge = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtScRate = new System.Windows.Forms.TextBox();
            this.txtItemPerPage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStartingNo = new System.Windows.Forms.Button();
            this.btnKbInZeros = new System.Windows.Forms.Button();
            this.btnKbInPrefix = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInvoiceStartingNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtZeroCount = new System.Windows.Forms.TextBox();
            this.cbxShowLeadingZeros = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtInvoiceNoPrefix = new System.Windows.Forms.TextBox();
            this.cbxCustomerAfterPo = new System.Windows.Forms.CheckBox();
            this.cbxCustomerAfterDo = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDefaultDiscRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxEnableWaiter = new System.Windows.Forms.CheckBox();
            this.cbxEnableGuestCount = new System.Windows.Forms.CheckBox();
            this.cbxEnableTable = new System.Windows.Forms.CheckBox();
            this.cbxAutoItemNo = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMain.Controls.Add(this.pnlInner);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 38);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMain.Size = new System.Drawing.Size(750, 437);
            this.pnlMain.TabIndex = 7;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlInner.Controls.Add(this.txtInvoiceDeleteDays);
            this.pnlInner.Controls.Add(this.groupBox5);
            this.pnlInner.Controls.Add(this.groupBox6);
            this.pnlInner.Controls.Add(this.btnExit);
            this.pnlInner.Controls.Add(this.groupBox4);
            this.pnlInner.Controls.Add(this.btnSave);
            this.pnlInner.Controls.Add(this.btnKbInDeleteDays);
            this.pnlInner.Controls.Add(this.btnKbDiscRate);
            this.pnlInner.Controls.Add(this.btnKbPageItems);
            this.pnlInner.Controls.Add(this.groupBox3);
            this.pnlInner.Controls.Add(this.groupBox2);
            this.pnlInner.Controls.Add(this.txtItemPerPage);
            this.pnlInner.Controls.Add(this.groupBox1);
            this.pnlInner.Controls.Add(this.cbxCustomerAfterPo);
            this.pnlInner.Controls.Add(this.cbxCustomerAfterDo);
            this.pnlInner.Controls.Add(this.label4);
            this.pnlInner.Controls.Add(this.txtDefaultDiscRate);
            this.pnlInner.Controls.Add(this.label2);
            this.pnlInner.Controls.Add(this.cbxEnableWaiter);
            this.pnlInner.Controls.Add(this.cbxEnableGuestCount);
            this.pnlInner.Controls.Add(this.cbxEnableTable);
            this.pnlInner.Controls.Add(this.cbxAutoItemNo);
            this.pnlInner.Controls.Add(this.label1);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(5, 0);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(740, 432);
            this.pnlInner.TabIndex = 0;
            // 
            // txtInvoiceDeleteDays
            // 
            this.txtInvoiceDeleteDays.Location = new System.Drawing.Point(599, 268);
            this.txtInvoiceDeleteDays.Name = "txtInvoiceDeleteDays";
            this.txtInvoiceDeleteDays.Size = new System.Drawing.Size(75, 22);
            this.txtInvoiceDeleteDays.TabIndex = 7;
            this.txtInvoiceDeleteDays.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvoiceDeleteDays_KeyPress);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Location = new System.Drawing.Point(13, 276);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(347, 54);
            this.groupBox5.TabIndex = 29;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Kitchen order ticket (KOT)";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(10, 21);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(195, 18);
            this.checkBox2.TabIndex = 23;
            this.checkBox2.Text = "Preview before printing invoice";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnKbKotStart);
            this.groupBox6.Controls.Add(this.btnKbKotZeros);
            this.groupBox6.Controls.Add(this.btnKbKotPrefix);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.txtKotStartingNo);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.txtKotZeroCount);
            this.groupBox6.Controls.Add(this.cbxKotLeadingZeros);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.txtKotPrefix);
            this.groupBox6.Location = new System.Drawing.Point(377, 139);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(353, 117);
            this.groupBox6.TabIndex = 201;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "KOT Number Settings";
            // 
            // btnKbKotStart
            // 
            this.btnKbKotStart.FlatAppearance.BorderSize = 0;
            this.btnKbKotStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbKotStart.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbKotStart.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbKotStart.Location = new System.Drawing.Point(120, 75);
            this.btnKbKotStart.Name = "btnKbKotStart";
            this.btnKbKotStart.Size = new System.Drawing.Size(50, 35);
            this.btnKbKotStart.TabIndex = 167;
            this.btnKbKotStart.UseVisualStyleBackColor = true;
            this.btnKbKotStart.Click += new System.EventHandler(this.btnKbKotStart_Click);
            // 
            // btnKbKotZeros
            // 
            this.btnKbKotZeros.FlatAppearance.BorderSize = 0;
            this.btnKbKotZeros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbKotZeros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbKotZeros.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbKotZeros.Location = new System.Drawing.Point(293, 72);
            this.btnKbKotZeros.Name = "btnKbKotZeros";
            this.btnKbKotZeros.Size = new System.Drawing.Size(50, 35);
            this.btnKbKotZeros.TabIndex = 166;
            this.btnKbKotZeros.UseVisualStyleBackColor = true;
            this.btnKbKotZeros.Click += new System.EventHandler(this.btnKbKotZeros_Click);
            // 
            // btnKbKotPrefix
            // 
            this.btnKbKotPrefix.FlatAppearance.BorderSize = 0;
            this.btnKbKotPrefix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbKotPrefix.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbKotPrefix.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbKotPrefix.Location = new System.Drawing.Point(120, 29);
            this.btnKbKotPrefix.Name = "btnKbKotPrefix";
            this.btnKbKotPrefix.Size = new System.Drawing.Size(50, 35);
            this.btnKbKotPrefix.TabIndex = 159;
            this.btnKbKotPrefix.UseVisualStyleBackColor = true;
            this.btnKbKotPrefix.Click += new System.EventHandler(this.btnKbKotPrefix_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 14);
            this.label10.TabIndex = 25;
            this.label10.Text = "Starting No.:";
            // 
            // txtKotStartingNo
            // 
            this.txtKotStartingNo.Location = new System.Drawing.Point(15, 81);
            this.txtKotStartingNo.Name = "txtKotStartingNo";
            this.txtKotStartingNo.Size = new System.Drawing.Size(100, 22);
            this.txtKotStartingNo.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(190, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 14);
            this.label11.TabIndex = 23;
            this.label11.Text = "Zeros Count:";
            // 
            // txtKotZeroCount
            // 
            this.txtKotZeroCount.Location = new System.Drawing.Point(190, 79);
            this.txtKotZeroCount.Name = "txtKotZeroCount";
            this.txtKotZeroCount.Size = new System.Drawing.Size(100, 22);
            this.txtKotZeroCount.TabIndex = 22;
            // 
            // cbxKotLeadingZeros
            // 
            this.cbxKotLeadingZeros.AutoSize = true;
            this.cbxKotLeadingZeros.Location = new System.Drawing.Point(190, 39);
            this.cbxKotLeadingZeros.Name = "cbxKotLeadingZeros";
            this.cbxKotLeadingZeros.Size = new System.Drawing.Size(131, 18);
            this.cbxKotLeadingZeros.TabIndex = 21;
            this.cbxKotLeadingZeros.Text = "Show leading zeros";
            this.cbxKotLeadingZeros.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 14);
            this.label12.TabIndex = 20;
            this.label12.Text = "Prefix:";
            // 
            // txtKotPrefix
            // 
            this.txtKotPrefix.Location = new System.Drawing.Point(15, 37);
            this.txtKotPrefix.Name = "txtKotPrefix";
            this.txtKotPrefix.Size = new System.Drawing.Size(100, 22);
            this.txtKotPrefix.TabIndex = 19;
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::cypos.Properties.Resources.exit100x45;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(619, 379);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 45);
            this.btnExit.TabIndex = 200;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbOrderType);
            this.groupBox4.Controls.Add(this.cbxShowOtAfterBill);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(13, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(360, 76);
            this.groupBox4.TabIndex = 189;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Order Type";
            // 
            // cmbOrderType
            // 
            this.cmbOrderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrderType.FormattingEnabled = true;
            this.cmbOrderType.Items.AddRange(new object[] {
            "Dine In",
            "Take Away",
            "Delivery Order",
            "Pickup Order"});
            this.cmbOrderType.Location = new System.Drawing.Point(133, 21);
            this.cmbOrderType.Name = "cmbOrderType";
            this.cmbOrderType.Size = new System.Drawing.Size(154, 22);
            this.cmbOrderType.TabIndex = 13;
            // 
            // cbxShowOtAfterBill
            // 
            this.cbxShowOtAfterBill.AutoSize = true;
            this.cbxShowOtAfterBill.Location = new System.Drawing.Point(41, 49);
            this.cbxShowOtAfterBill.Name = "cbxShowOtAfterBill";
            this.cbxShowOtAfterBill.Size = new System.Drawing.Size(246, 18);
            this.cbxShowOtAfterBill.TabIndex = 188;
            this.cbxShowOtAfterBill.Text = "Select order type after each transaction";
            this.cbxShowOtAfterBill.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 14);
            this.label5.TabIndex = 12;
            this.label5.Text = "Default order type:";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::cypos.Properties.Resources.update100x45;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(513, 379);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 45);
            this.btnSave.TabIndex = 187;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnKbInDeleteDays
            // 
            this.btnKbInDeleteDays.FlatAppearance.BorderSize = 0;
            this.btnKbInDeleteDays.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbInDeleteDays.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbInDeleteDays.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbInDeleteDays.Location = new System.Drawing.Point(678, 262);
            this.btnKbInDeleteDays.Name = "btnKbInDeleteDays";
            this.btnKbInDeleteDays.Size = new System.Drawing.Size(50, 35);
            this.btnKbInDeleteDays.TabIndex = 165;
            this.btnKbInDeleteDays.UseVisualStyleBackColor = true;
            this.btnKbInDeleteDays.Click += new System.EventHandler(this.btnKbInDeleteDays_Click);
            // 
            // btnKbDiscRate
            // 
            this.btnKbDiscRate.FlatAppearance.BorderSize = 0;
            this.btnKbDiscRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbDiscRate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbDiscRate.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbDiscRate.Location = new System.Drawing.Point(678, 331);
            this.btnKbDiscRate.Name = "btnKbDiscRate";
            this.btnKbDiscRate.Size = new System.Drawing.Size(50, 35);
            this.btnKbDiscRate.TabIndex = 164;
            this.btnKbDiscRate.UseVisualStyleBackColor = true;
            this.btnKbDiscRate.Click += new System.EventHandler(this.btnKbDiscRate_Click);
            // 
            // btnKbPageItems
            // 
            this.btnKbPageItems.FlatAppearance.BorderSize = 0;
            this.btnKbPageItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbPageItems.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbPageItems.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbPageItems.Location = new System.Drawing.Point(678, 295);
            this.btnKbPageItems.Name = "btnKbPageItems";
            this.btnKbPageItems.Size = new System.Drawing.Size(50, 35);
            this.btnKbPageItems.TabIndex = 163;
            this.btnKbPageItems.UseVisualStyleBackColor = true;
            this.btnKbPageItems.Click += new System.EventHandler(this.btnKbPageItems_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxShowLogo);
            this.groupBox3.Controls.Add(this.cbxPreviewB4Print);
            this.groupBox3.Location = new System.Drawing.Point(13, 198);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 73);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Invoice Printing";
            // 
            // cbxShowLogo
            // 
            this.cbxShowLogo.AutoSize = true;
            this.cbxShowLogo.Location = new System.Drawing.Point(10, 45);
            this.cbxShowLogo.Name = "cbxShowLogo";
            this.cbxShowLogo.Size = new System.Drawing.Size(138, 18);
            this.cbxShowLogo.TabIndex = 6;
            this.cbxShowLogo.Text = "Show logo in invoice";
            this.cbxShowLogo.UseVisualStyleBackColor = true;
            // 
            // cbxPreviewB4Print
            // 
            this.cbxPreviewB4Print.AutoSize = true;
            this.cbxPreviewB4Print.Location = new System.Drawing.Point(10, 21);
            this.cbxPreviewB4Print.Name = "cbxPreviewB4Print";
            this.cbxPreviewB4Print.Size = new System.Drawing.Size(195, 18);
            this.cbxPreviewB4Print.TabIndex = 23;
            this.cbxPreviewB4Print.Text = "Preview before printing invoice";
            this.cbxPreviewB4Print.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnKbScRate);
            this.groupBox2.Controls.Add(this.cbxEnableServiceCharge);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtScRate);
            this.groupBox2.Location = new System.Drawing.Point(13, 333);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 87);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Service Charge";
            // 
            // btnKbScRate
            // 
            this.btnKbScRate.FlatAppearance.BorderSize = 0;
            this.btnKbScRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbScRate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbScRate.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbScRate.Location = new System.Drawing.Point(154, 46);
            this.btnKbScRate.Name = "btnKbScRate";
            this.btnKbScRate.Size = new System.Drawing.Size(50, 35);
            this.btnKbScRate.TabIndex = 168;
            this.btnKbScRate.UseVisualStyleBackColor = true;
            this.btnKbScRate.Click += new System.EventHandler(this.btnKbScRate_Click);
            // 
            // cbxEnableServiceCharge
            // 
            this.cbxEnableServiceCharge.AutoSize = true;
            this.cbxEnableServiceCharge.Location = new System.Drawing.Point(18, 30);
            this.cbxEnableServiceCharge.Name = "cbxEnableServiceCharge";
            this.cbxEnableServiceCharge.Size = new System.Drawing.Size(147, 18);
            this.cbxEnableServiceCharge.TabIndex = 16;
            this.cbxEnableServiceCharge.Text = "Enable Service Charge";
            this.cbxEnableServiceCharge.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 14);
            this.label6.TabIndex = 15;
            this.label6.Text = "Rate %:";
            // 
            // txtScRate
            // 
            this.txtScRate.Location = new System.Drawing.Point(73, 54);
            this.txtScRate.Name = "txtScRate";
            this.txtScRate.Size = new System.Drawing.Size(75, 22);
            this.txtScRate.TabIndex = 14;
            this.txtScRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtScRate_KeyPress);
            this.txtScRate.Leave += new System.EventHandler(this.txtScRate_Leave);
            // 
            // txtItemPerPage
            // 
            this.txtItemPerPage.Location = new System.Drawing.Point(599, 303);
            this.txtItemPerPage.Name = "txtItemPerPage";
            this.txtItemPerPage.Size = new System.Drawing.Size(75, 22);
            this.txtItemPerPage.TabIndex = 26;
            this.txtItemPerPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtItemPerPage_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStartingNo);
            this.groupBox1.Controls.Add(this.btnKbInZeros);
            this.groupBox1.Controls.Add(this.btnKbInPrefix);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtInvoiceStartingNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtZeroCount);
            this.groupBox1.Controls.Add(this.cbxShowLeadingZeros);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtInvoiceNoPrefix);
            this.groupBox1.Location = new System.Drawing.Point(379, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(351, 127);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Number Settings";
            // 
            // btnStartingNo
            // 
            this.btnStartingNo.FlatAppearance.BorderSize = 0;
            this.btnStartingNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartingNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartingNo.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnStartingNo.Location = new System.Drawing.Point(114, 82);
            this.btnStartingNo.Name = "btnStartingNo";
            this.btnStartingNo.Size = new System.Drawing.Size(50, 35);
            this.btnStartingNo.TabIndex = 167;
            this.btnStartingNo.UseVisualStyleBackColor = true;
            this.btnStartingNo.Click += new System.EventHandler(this.btnStartingNo_Click);
            // 
            // btnKbInZeros
            // 
            this.btnKbInZeros.FlatAppearance.BorderSize = 0;
            this.btnKbInZeros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbInZeros.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbInZeros.Image = global::cypos.Properties.Resources.numeric_keypad;
            this.btnKbInZeros.Location = new System.Drawing.Point(288, 82);
            this.btnKbInZeros.Name = "btnKbInZeros";
            this.btnKbInZeros.Size = new System.Drawing.Size(50, 35);
            this.btnKbInZeros.TabIndex = 166;
            this.btnKbInZeros.UseVisualStyleBackColor = true;
            this.btnKbInZeros.Click += new System.EventHandler(this.btnKbInZeros_Click);
            // 
            // btnKbInPrefix
            // 
            this.btnKbInPrefix.FlatAppearance.BorderSize = 0;
            this.btnKbInPrefix.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbInPrefix.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbInPrefix.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbInPrefix.Location = new System.Drawing.Point(114, 34);
            this.btnKbInPrefix.Name = "btnKbInPrefix";
            this.btnKbInPrefix.Size = new System.Drawing.Size(50, 35);
            this.btnKbInPrefix.TabIndex = 159;
            this.btnKbInPrefix.UseVisualStyleBackColor = true;
            this.btnKbInPrefix.Click += new System.EventHandler(this.btnKbInPrefix_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 25;
            this.label9.Text = "Starting No.:";
            // 
            // txtInvoiceStartingNo
            // 
            this.txtInvoiceStartingNo.Location = new System.Drawing.Point(11, 89);
            this.txtInvoiceStartingNo.Name = "txtInvoiceStartingNo";
            this.txtInvoiceStartingNo.Size = new System.Drawing.Size(100, 22);
            this.txtInvoiceStartingNo.TabIndex = 24;
            this.txtInvoiceStartingNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInvoiceStartingNo_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(181, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 14);
            this.label8.TabIndex = 23;
            this.label8.Text = "Zeros Count:";
            // 
            // txtZeroCount
            // 
            this.txtZeroCount.Location = new System.Drawing.Point(184, 89);
            this.txtZeroCount.Name = "txtZeroCount";
            this.txtZeroCount.Size = new System.Drawing.Size(100, 22);
            this.txtZeroCount.TabIndex = 22;
            this.txtZeroCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtZeroCount_KeyPress);
            // 
            // cbxShowLeadingZeros
            // 
            this.cbxShowLeadingZeros.AutoSize = true;
            this.cbxShowLeadingZeros.Location = new System.Drawing.Point(184, 45);
            this.cbxShowLeadingZeros.Name = "cbxShowLeadingZeros";
            this.cbxShowLeadingZeros.Size = new System.Drawing.Size(131, 18);
            this.cbxShowLeadingZeros.TabIndex = 21;
            this.cbxShowLeadingZeros.Text = "Show leading zeros";
            this.cbxShowLeadingZeros.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 14);
            this.label7.TabIndex = 20;
            this.label7.Text = "Prefix:";
            // 
            // txtInvoiceNoPrefix
            // 
            this.txtInvoiceNoPrefix.Location = new System.Drawing.Point(11, 40);
            this.txtInvoiceNoPrefix.Name = "txtInvoiceNoPrefix";
            this.txtInvoiceNoPrefix.Size = new System.Drawing.Size(100, 22);
            this.txtInvoiceNoPrefix.TabIndex = 19;
            // 
            // cbxCustomerAfterPo
            // 
            this.cbxCustomerAfterPo.AutoSize = true;
            this.cbxCustomerAfterPo.Location = new System.Drawing.Point(13, 120);
            this.cbxCustomerAfterPo.Name = "cbxCustomerAfterPo";
            this.cbxCustomerAfterPo.Size = new System.Drawing.Size(266, 18);
            this.cbxCustomerAfterPo.TabIndex = 18;
            this.cbxCustomerAfterPo.Text = "Show customer after pickup order selection";
            this.cbxCustomerAfterPo.UseVisualStyleBackColor = true;
            // 
            // cbxCustomerAfterDo
            // 
            this.cbxCustomerAfterDo.AutoSize = true;
            this.cbxCustomerAfterDo.Location = new System.Drawing.Point(13, 92);
            this.cbxCustomerAfterDo.Name = "cbxCustomerAfterDo";
            this.cbxCustomerAfterDo.Size = new System.Drawing.Size(272, 18);
            this.cbxCustomerAfterDo.TabIndex = 17;
            this.cbxCustomerAfterDo.Text = "Show customer after delivery order selection";
            this.cbxCustomerAfterDo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(376, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 14);
            this.label4.TabIndex = 11;
            this.label4.Text = "Default discount rate %:";
            // 
            // txtDefaultDiscRate
            // 
            this.txtDefaultDiscRate.Location = new System.Drawing.Point(599, 338);
            this.txtDefaultDiscRate.Name = "txtDefaultDiscRate";
            this.txtDefaultDiscRate.Size = new System.Drawing.Size(75, 22);
            this.txtDefaultDiscRate.TabIndex = 10;
            this.txtDefaultDiscRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDefaultDiscRate_KeyPress);
            this.txtDefaultDiscRate.Leave += new System.EventHandler(this.txtDefaultDiscRate_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(376, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "Delete incomplete invoices after (days):";
            // 
            // cbxEnableWaiter
            // 
            this.cbxEnableWaiter.AutoSize = true;
            this.cbxEnableWaiter.Location = new System.Drawing.Point(166, 146);
            this.cbxEnableWaiter.Name = "cbxEnableWaiter";
            this.cbxEnableWaiter.Size = new System.Drawing.Size(102, 18);
            this.cbxEnableWaiter.TabIndex = 4;
            this.cbxEnableWaiter.Text = "Enable Waiter";
            this.cbxEnableWaiter.UseVisualStyleBackColor = true;
            // 
            // cbxEnableGuestCount
            // 
            this.cbxEnableGuestCount.AutoSize = true;
            this.cbxEnableGuestCount.Location = new System.Drawing.Point(167, 173);
            this.cbxEnableGuestCount.Name = "cbxEnableGuestCount";
            this.cbxEnableGuestCount.Size = new System.Drawing.Size(135, 18);
            this.cbxEnableGuestCount.TabIndex = 3;
            this.cbxEnableGuestCount.Text = "Enable Guest Count";
            this.cbxEnableGuestCount.UseVisualStyleBackColor = true;
            // 
            // cbxEnableTable
            // 
            this.cbxEnableTable.AutoSize = true;
            this.cbxEnableTable.Location = new System.Drawing.Point(13, 173);
            this.cbxEnableTable.Name = "cbxEnableTable";
            this.cbxEnableTable.Size = new System.Drawing.Size(96, 18);
            this.cbxEnableTable.TabIndex = 2;
            this.cbxEnableTable.Text = "Enable Table";
            this.cbxEnableTable.UseVisualStyleBackColor = true;
            // 
            // cbxAutoItemNo
            // 
            this.cbxAutoItemNo.AutoSize = true;
            this.cbxAutoItemNo.Location = new System.Drawing.Point(13, 146);
            this.cbxAutoItemNo.Name = "cbxAutoItemNo";
            this.cbxAutoItemNo.Size = new System.Drawing.Size(130, 18);
            this.cbxAutoItemNo.TabIndex = 1;
            this.cbxAutoItemNo.Text = "Auto Item Number";
            this.cbxAutoItemNo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(376, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Items Per Page in POS Screen:";
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
            this.pnlTitle.Size = new System.Drawing.Size(750, 38);
            this.pnlTitle.TabIndex = 163;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(715, 3);
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
            this.lblTitle.Size = new System.Drawing.Size(70, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Settings";
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(750, 475);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlInner.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxAutoItemNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInvoiceDeleteDays;
        private System.Windows.Forms.CheckBox cbxShowLogo;
        private System.Windows.Forms.CheckBox cbxEnableWaiter;
        private System.Windows.Forms.CheckBox cbxEnableGuestCount;
        private System.Windows.Forms.CheckBox cbxEnableTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDefaultDiscRate;
        private System.Windows.Forms.ComboBox cmbOrderType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cbxEnableServiceCharge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtScRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtInvoiceNoPrefix;
        private System.Windows.Forms.CheckBox cbxCustomerAfterPo;
        private System.Windows.Forms.CheckBox cbxCustomerAfterDo;
        private System.Windows.Forms.CheckBox cbxPreviewB4Print;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInvoiceStartingNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtZeroCount;
        private System.Windows.Forms.CheckBox cbxShowLeadingZeros;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtItemPerPage;
        private System.Windows.Forms.Button btnKbInDeleteDays;
        private System.Windows.Forms.Button btnKbDiscRate;
        private System.Windows.Forms.Button btnKbPageItems;
        private System.Windows.Forms.Button btnKbInPrefix;
        private System.Windows.Forms.Button btnStartingNo;
        private System.Windows.Forms.Button btnKbInZeros;
        private System.Windows.Forms.Button btnKbScRate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox cbxShowOtAfterBill;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnKbKotStart;
        private System.Windows.Forms.Button btnKbKotZeros;
        private System.Windows.Forms.Button btnKbKotPrefix;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtKotStartingNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtKotZeroCount;
        private System.Windows.Forms.CheckBox cbxKotLeadingZeros;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtKotPrefix;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}