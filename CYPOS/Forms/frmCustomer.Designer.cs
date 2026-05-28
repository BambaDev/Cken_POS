namespace cypos
{
    partial class frmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtEmailAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCustomer = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnKbEmail = new System.Windows.Forms.Button();
            this.btnKbPhone = new System.Windows.Forms.Button();
            this.btnKbCity = new System.Windows.Forms.Button();
            this.btnKbAddress = new System.Windows.Forms.Button();
            this.btnKbName = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.clmInvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmInvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPayType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDueAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnPrintHistory = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.pnlMail = new System.Windows.Forms.Panel();
            this.pnlInner = new System.Windows.Forms.Panel();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.clmCustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCustomerDown = new System.Windows.Forms.Button();
            this.btnCustomerUp = new System.Windows.Forms.Button();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnKbCustomerSearch = new System.Windows.Forms.Button();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.pnlEntry = new System.Windows.Forms.Panel();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.pbxClose = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tbCustomer.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlMail.SuspendLayout();
            this.pnlInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.panel2.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlEntry.SuspendLayout();
            this.pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerId.Location = new System.Drawing.Point(129, 11);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(13, 16);
            this.lblCustomerId.TabIndex = 1;
            this.lblCustomerId.Text = "-";
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.Location = new System.Drawing.Point(328, 84);
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Size = new System.Drawing.Size(250, 23);
            this.txtEmailAddress.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(324, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Email:";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(18, 181);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(250, 23);
            this.txtCity.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "City:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Customer Name:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(18, 32);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 23);
            this.txtCustomerName.TabIndex = 1;
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerAddress.Location = new System.Drawing.Point(18, 84);
            this.txtCustomerAddress.Multiline = true;
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(250, 71);
            this.txtCustomerAddress.TabIndex = 6;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(329, 32);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(250, 23);
            this.txtPhone.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(325, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Phone:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Address:";
            // 
            // tbCustomer
            // 
            this.tbCustomer.Controls.Add(this.tabPage1);
            this.tbCustomer.Controls.Add(this.tabPage2);
            this.tbCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCustomer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCustomer.ItemSize = new System.Drawing.Size(150, 45);
            this.tbCustomer.Location = new System.Drawing.Point(5, 5);
            this.tbCustomer.Name = "tbCustomer";
            this.tbCustomer.SelectedIndex = 0;
            this.tbCustomer.Size = new System.Drawing.Size(830, 290);
            this.tbCustomer.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tbCustomer.TabIndex = 17;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDelete);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Controls.Add(this.btnExit);
            this.tabPage1.Controls.Add(this.btnKbEmail);
            this.tabPage1.Controls.Add(this.btnKbPhone);
            this.tabPage1.Controls.Add(this.btnKbCity);
            this.tabPage1.Controls.Add(this.btnKbAddress);
            this.tabPage1.Controls.Add(this.btnKbName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtPhone);
            this.tabPage1.Controls.Add(this.lblCustomerId);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtCustomerName);
            this.tabPage1.Controls.Add(this.txtCity);
            this.tabPage1.Controls.Add(this.txtEmailAddress);
            this.tabPage1.Controls.Add(this.txtCustomerAddress);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Location = new System.Drawing.Point(4, 49);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(822, 237);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Customer Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.BackgroundImage = global::cypos.Properties.Resources.delete100x45;
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(647, 112);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 45);
            this.btnDelete.TabIndex = 196;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::cypos.Properties.Resources.save100x45;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(647, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 45);
            this.btnSave.TabIndex = 195;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::cypos.Properties.Resources.clear100x45;
            this.btnClear.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(647, 18);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 45);
            this.btnClear.TabIndex = 194;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::cypos.Properties.Resources.exit100x45;
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(647, 159);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(117, 45);
            this.btnExit.TabIndex = 193;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnKbEmail
            // 
            this.btnKbEmail.FlatAppearance.BorderSize = 0;
            this.btnKbEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbEmail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbEmail.Image = ((System.Drawing.Image)(resources.GetObject("btnKbEmail.Image")));
            this.btnKbEmail.Location = new System.Drawing.Point(585, 78);
            this.btnKbEmail.Name = "btnKbEmail";
            this.btnKbEmail.Size = new System.Drawing.Size(50, 35);
            this.btnKbEmail.TabIndex = 191;
            this.btnKbEmail.UseVisualStyleBackColor = true;
            this.btnKbEmail.Click += new System.EventHandler(this.btnKbEmail_Click);
            // 
            // btnKbPhone
            // 
            this.btnKbPhone.FlatAppearance.BorderSize = 0;
            this.btnKbPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbPhone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbPhone.Image = ((System.Drawing.Image)(resources.GetObject("btnKbPhone.Image")));
            this.btnKbPhone.Location = new System.Drawing.Point(585, 24);
            this.btnKbPhone.Name = "btnKbPhone";
            this.btnKbPhone.Size = new System.Drawing.Size(50, 35);
            this.btnKbPhone.TabIndex = 190;
            this.btnKbPhone.UseVisualStyleBackColor = true;
            this.btnKbPhone.Click += new System.EventHandler(this.btnKbPhone_Click);
            // 
            // btnKbCity
            // 
            this.btnKbCity.FlatAppearance.BorderSize = 0;
            this.btnKbCity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbCity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbCity.Image = ((System.Drawing.Image)(resources.GetObject("btnKbCity.Image")));
            this.btnKbCity.Location = new System.Drawing.Point(274, 174);
            this.btnKbCity.Name = "btnKbCity";
            this.btnKbCity.Size = new System.Drawing.Size(50, 35);
            this.btnKbCity.TabIndex = 189;
            this.btnKbCity.UseVisualStyleBackColor = true;
            this.btnKbCity.Click += new System.EventHandler(this.btnKbCity_Click);
            // 
            // btnKbAddress
            // 
            this.btnKbAddress.FlatAppearance.BorderSize = 0;
            this.btnKbAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbAddress.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbAddress.Image = ((System.Drawing.Image)(resources.GetObject("btnKbAddress.Image")));
            this.btnKbAddress.Location = new System.Drawing.Point(273, 88);
            this.btnKbAddress.Name = "btnKbAddress";
            this.btnKbAddress.Size = new System.Drawing.Size(50, 35);
            this.btnKbAddress.TabIndex = 188;
            this.btnKbAddress.UseVisualStyleBackColor = true;
            this.btnKbAddress.Click += new System.EventHandler(this.btnKbAddress_Click);
            // 
            // btnKbName
            // 
            this.btnKbName.FlatAppearance.BorderSize = 0;
            this.btnKbName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbName.Image = ((System.Drawing.Image)(resources.GetObject("btnKbName.Image")));
            this.btnKbName.Location = new System.Drawing.Point(273, 24);
            this.btnKbName.Name = "btnKbName";
            this.btnKbName.Size = new System.Drawing.Size(50, 35);
            this.btnKbName.TabIndex = 187;
            this.btnKbName.UseVisualStyleBackColor = true;
            this.btnKbName.Click += new System.EventHandler(this.btnKbName_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvHistory);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 49);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(822, 237);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "History";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.AllowUserToResizeRows = false;
            this.dgvHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.ColumnHeadersHeight = 32;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmInvoiceNo,
            this.clmInvoiceDate,
            this.clmPayType,
            this.clmTotal,
            this.clmPaidAmount,
            this.clmDueAmount});
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.Location = new System.Drawing.Point(3, 3);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowTemplate.Height = 32;
            this.dgvHistory.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(728, 231);
            this.dgvHistory.TabIndex = 23;
            // 
            // clmInvoiceNo
            // 
            this.clmInvoiceNo.DataPropertyName = "Invoice_id";
            this.clmInvoiceNo.HeaderText = "Invoice #";
            this.clmInvoiceNo.Name = "clmInvoiceNo";
            this.clmInvoiceNo.ReadOnly = true;
            // 
            // clmInvoiceDate
            // 
            this.clmInvoiceDate.DataPropertyName = "invoice_date";
            this.clmInvoiceDate.HeaderText = "Date";
            this.clmInvoiceDate.Name = "clmInvoiceDate";
            this.clmInvoiceDate.ReadOnly = true;
            // 
            // clmPayType
            // 
            this.clmPayType.DataPropertyName = "payment_type";
            this.clmPayType.HeaderText = "Payment Type";
            this.clmPayType.Name = "clmPayType";
            this.clmPayType.ReadOnly = true;
            // 
            // clmTotal
            // 
            this.clmTotal.DataPropertyName = "payment_amount";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmTotal.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmTotal.HeaderText = "Total";
            this.clmTotal.Name = "clmTotal";
            this.clmTotal.ReadOnly = true;
            // 
            // clmPaidAmount
            // 
            this.clmPaidAmount.DataPropertyName = "paid_amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmPaidAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmPaidAmount.HeaderText = "Paid Amount";
            this.clmPaidAmount.Name = "clmPaidAmount";
            this.clmPaidAmount.ReadOnly = true;
            // 
            // clmDueAmount
            // 
            this.clmDueAmount.DataPropertyName = "due_amount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.clmDueAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.clmDueAmount.HeaderText = "Due Amount";
            this.clmDueAmount.Name = "clmDueAmount";
            this.clmDueAmount.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrintHistory);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(731, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(88, 231);
            this.panel1.TabIndex = 22;
            // 
            // btnPrintHistory
            // 
            this.btnPrintHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintHistory.Image")));
            this.btnPrintHistory.Location = new System.Drawing.Point(6, 120);
            this.btnPrintHistory.Name = "btnPrintHistory";
            this.btnPrintHistory.Size = new System.Drawing.Size(77, 55);
            this.btnPrintHistory.TabIndex = 103;
            this.btnPrintHistory.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Image = global::cypos.Properties.Resources.row_down;
            this.button8.Location = new System.Drawing.Point(6, 59);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 55);
            this.button8.TabIndex = 3;
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Image = global::cypos.Properties.Resources.row_up;
            this.button9.Location = new System.Drawing.Point(6, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 55);
            this.button9.TabIndex = 2;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // pnlMail
            // 
            this.pnlMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(156)))), ((int)(((byte)(218)))));
            this.pnlMail.Controls.Add(this.pnlInner);
            this.pnlMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMail.Location = new System.Drawing.Point(0, 38);
            this.pnlMail.Name = "pnlMail";
            this.pnlMail.Padding = new System.Windows.Forms.Padding(5, 0, 5, 5);
            this.pnlMail.Size = new System.Drawing.Size(850, 512);
            this.pnlMail.TabIndex = 165;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.SystemColors.Control;
            this.pnlInner.Controls.Add(this.dgvCustomers);
            this.pnlInner.Controls.Add(this.panel2);
            this.pnlInner.Controls.Add(this.pnlSearch);
            this.pnlInner.Controls.Add(this.pnlEntry);
            this.pnlInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInner.Location = new System.Drawing.Point(5, 0);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(840, 507);
            this.pnlInner.TabIndex = 18;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToResizeColumns = false;
            this.dgvCustomers.AllowUserToResizeRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.ColumnHeadersHeight = 32;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmCustomerId,
            this.clmCustomer,
            this.clmAddress,
            this.clmCity,
            this.clmPhone,
            this.clmEmail});
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(0, 47);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.RowTemplate.Height = 32;
            this.dgvCustomers.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(752, 160);
            this.dgvCustomers.TabIndex = 18;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            // 
            // clmCustomerId
            // 
            this.clmCustomerId.DataPropertyName = "id";
            this.clmCustomerId.HeaderText = "Id";
            this.clmCustomerId.Name = "clmCustomerId";
            this.clmCustomerId.ReadOnly = true;
            this.clmCustomerId.Visible = false;
            // 
            // clmCustomer
            // 
            this.clmCustomer.DataPropertyName = "name";
            this.clmCustomer.HeaderText = "Customer";
            this.clmCustomer.Name = "clmCustomer";
            this.clmCustomer.ReadOnly = true;
            // 
            // clmAddress
            // 
            this.clmAddress.DataPropertyName = "address";
            this.clmAddress.HeaderText = "Address";
            this.clmAddress.Name = "clmAddress";
            this.clmAddress.ReadOnly = true;
            // 
            // clmCity
            // 
            this.clmCity.DataPropertyName = "city";
            this.clmCity.HeaderText = "City";
            this.clmCity.Name = "clmCity";
            this.clmCity.ReadOnly = true;
            // 
            // clmPhone
            // 
            this.clmPhone.DataPropertyName = "phone";
            this.clmPhone.HeaderText = "Phone";
            this.clmPhone.Name = "clmPhone";
            this.clmPhone.ReadOnly = true;
            // 
            // clmEmail
            // 
            this.clmEmail.DataPropertyName = "email";
            this.clmEmail.HeaderText = "Email";
            this.clmEmail.Name = "clmEmail";
            this.clmEmail.ReadOnly = true;
            this.clmEmail.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.btnCustomerDown);
            this.panel2.Controls.Add(this.btnCustomerUp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(752, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(88, 160);
            this.panel2.TabIndex = 21;
            // 
            // btnCustomerDown
            // 
            this.btnCustomerDown.Image = global::cypos.Properties.Resources.row_down;
            this.btnCustomerDown.Location = new System.Drawing.Point(6, 59);
            this.btnCustomerDown.Name = "btnCustomerDown";
            this.btnCustomerDown.Size = new System.Drawing.Size(75, 55);
            this.btnCustomerDown.TabIndex = 3;
            this.btnCustomerDown.UseVisualStyleBackColor = true;
            this.btnCustomerDown.Click += new System.EventHandler(this.btnCustomerDown_Click);
            // 
            // btnCustomerUp
            // 
            this.btnCustomerUp.Image = global::cypos.Properties.Resources.row_up;
            this.btnCustomerUp.Location = new System.Drawing.Point(6, 0);
            this.btnCustomerUp.Name = "btnCustomerUp";
            this.btnCustomerUp.Size = new System.Drawing.Size(75, 55);
            this.btnCustomerUp.TabIndex = 2;
            this.btnCustomerUp.UseVisualStyleBackColor = true;
            this.btnCustomerUp.Click += new System.EventHandler(this.btnCustomerUp_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlSearch.Controls.Add(this.btnKbCustomerSearch);
            this.pnlSearch.Controls.Add(this.txtSearchCustomer);
            this.pnlSearch.Controls.Add(this.label17);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(10, 1, 1, 1);
            this.pnlSearch.Size = new System.Drawing.Size(840, 47);
            this.pnlSearch.TabIndex = 20;
            // 
            // btnKbCustomerSearch
            // 
            this.btnKbCustomerSearch.FlatAppearance.BorderSize = 0;
            this.btnKbCustomerSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKbCustomerSearch.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKbCustomerSearch.Image = global::cypos.Properties.Resources.keyboard;
            this.btnKbCustomerSearch.Location = new System.Drawing.Point(342, 4);
            this.btnKbCustomerSearch.Name = "btnKbCustomerSearch";
            this.btnKbCustomerSearch.Size = new System.Drawing.Size(58, 38);
            this.btnKbCustomerSearch.TabIndex = 176;
            this.btnKbCustomerSearch.UseVisualStyleBackColor = true;
            this.btnKbCustomerSearch.Click += new System.EventHandler(this.btnKbCustomerSearch_Click);
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCustomer.Location = new System.Drawing.Point(91, 10);
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(247, 26);
            this.txtSearchCustomer.TabIndex = 2;
            this.txtSearchCustomer.TextChanged += new System.EventHandler(this.txtSearchCustomer_TextChanged);
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Left;
            this.label17.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(10, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 45);
            this.label17.TabIndex = 1;
            this.label17.Text = "Search:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlEntry
            // 
            this.pnlEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.pnlEntry.Controls.Add(this.tbCustomer);
            this.pnlEntry.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEntry.Location = new System.Drawing.Point(0, 207);
            this.pnlEntry.Name = "pnlEntry";
            this.pnlEntry.Padding = new System.Windows.Forms.Padding(5);
            this.pnlEntry.Size = new System.Drawing.Size(840, 300);
            this.pnlEntry.TabIndex = 19;
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
            this.pnlTitle.Size = new System.Drawing.Size(850, 38);
            this.pnlTitle.TabIndex = 164;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // pbxClose
            // 
            this.pbxClose.BackColor = System.Drawing.Color.Transparent;
            this.pbxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbxClose.Image = global::cypos.Properties.Resources.close32x32;
            this.pbxClose.Location = new System.Drawing.Point(815, 3);
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
            this.lblTitle.Location = new System.Drawing.Point(14, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(79, 18);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Customer";
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.pnlMail);
            this.Controls.Add(this.pnlTitle);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.tbCustomer.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlMail.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.panel2.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlEntry.ResumeLayout(false);
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailAddress;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TabControl tbCustomer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.PictureBox pbxClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlMail;
        private System.Windows.Forms.Panel pnlInner;
        private System.Windows.Forms.Button btnKbEmail;
        private System.Windows.Forms.Button btnKbPhone;
        private System.Windows.Forms.Button btnKbCity;
        private System.Windows.Forms.Button btnKbAddress;
        private System.Windows.Forms.Button btnKbName;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEmail;
        private System.Windows.Forms.Panel pnlEntry;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnKbCustomerSearch;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCustomerDown;
        private System.Windows.Forms.Button btnCustomerUp;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrintHistory;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInvoiceNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmInvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPayType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDueAmount;
    }
}